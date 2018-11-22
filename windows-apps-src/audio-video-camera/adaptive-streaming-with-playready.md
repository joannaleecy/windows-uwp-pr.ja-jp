---
author: drewbatgit
ms.assetid: BF877F23-1238-4586-9C16-246F3F25AE35
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。
title: PlayReady を使ったアダプティブ ストリーミング
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7132de481f22f53269cd9bd69a38819c5b71cb55
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7569753"
---
# <a name="adaptive-streaming-with-playready"></a>PlayReady を使ったアダプティブ ストリーミング


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。 

現在、この機能では、Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。

HLS (Apple の HTTP ライブ ストリーミング) は、PlayReady ではサポートされていません。

Smooth Streaming も、現在、ネイティブではサポートされていません。ただし、PlayReady は拡張可能であるため、追加のコードまたはライブラリを使うことで、PlayReady で保護された Smooth Streaming をサポートして、ソフトウェアまたはハードウェアの DRM (デジタル著作権管理) を活用できます。

この記事では、アダプティブ ストリーミングの PlayReady 固有の側面についてのみ扱います。 アダプティブ ストリーミングの実装に関する全般的な情報については、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。

この記事では、GitHub の Microsoft の **Windows-universal-samples** リポジトリにある[アダプティブ ストリーミングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AdaptiveStreaming)のコードを使っています。 PlayReady を使ったアダプティブ ストリーミングはシナリオ 4 で取り上げられています。 リポジトリを含む ZIP ファイルをダウンロードするには、リポジトリのルート レベルに移動して、**[Download ZIP]** ボタンを選びます。

次の **using** ステートメントが必要です。

```csharp
using LicenseRequest;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Media.Protection;
using Windows.Media.Protection.PlayReady;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml.Controls;
```

**LicenseRequest** 名前空間は、Microsoft がライセンス使用者に提供する PlayReady ファイル **CommonLicenseRequest.cs** にあります。

いくつかのグローバル変数を宣言する必要があります。

```csharp
private AdaptiveMediaSource ams = null;
private MediaProtectionManager protectionManager = null;
private string playReadyLicenseUrl = "";
private string playReadyChallengeCustomData = "";
```

次の定数を宣言することもできます。

```csharp
private const uint MSPR_E_CONTENT_ENABLING_ACTION_REQUIRED = 0x8004B895;
```

## <a name="setting-up-the-mediaprotectionmanager"></a>MediaProtectionManager の設定

PlayReady コンテンツ保護を UWP アプリに追加するには、[MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040) オブジェクトを設定する必要があります。 これは、[**AdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn946912) オブジェクトを初期化するときに行います。

次のコードは、[MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040) をセットアップします。

```csharp
private void SetUpProtectionManager(ref MediaElement mediaElement)
{
    protectionManager = new MediaProtectionManager();

    protectionManager.ComponentLoadFailed += 
        new ComponentLoadFailedEventHandler(ProtectionManager_ComponentLoadFailed);

    protectionManager.ServiceRequested += 
        new ServiceRequestedEventHandler(ProtectionManager_ServiceRequested);

    PropertySet cpSystems = new PropertySet();

    cpSystems.Add(
        "{F4637010-03C3-42CD-B932-B48ADF3A6A54}", 
        "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput");

    protectionManager.Properties.Add("Windows.Media.Protection.MediaProtectionSystemIdMapping", cpSystems);

    protectionManager.Properties.Add(
        "Windows.Media.Protection.MediaProtectionSystemId", 
        "{F4637010-03C3-42CD-B932-B48ADF3A6A54}");

    protectionManager.Properties.Add(
        "Windows.Media.Protection.MediaProtectionContainerGuid", 
        "{9A04F079-9840-4286-AB92-E65BE0885F95}");

    mediaElement.ProtectionManager = protectionManager;
}
```

コンテンツ保護の設定は必須のため、このコードはそのままアプリにコピーできます。

バイナリ データの読み込みに失敗すると、[ComponentLoadFailed](https://msdn.microsoft.com/library/windows/apps/br207041) イベントが発生します。 これを処理するにはイベント ハンドラーを追加して、読み込みが完了していないことを通知する必要があります。

```csharp
private void ProtectionManager_ComponentLoadFailed(
    MediaProtectionManager sender, 
    ComponentLoadFailedEventArgs e)
{
    e.Completion.Complete(false);
}
```

同様に、サービスが要求されたときに発生する [ServiceRequested](https://msdn.microsoft.com/library/windows/apps/br207045) イベントのイベント ハンドラーを追加する必要があります。 このコードは、要求の種類を確認し、それに応じて応答します。

```csharp
private async void ProtectionManager_ServiceRequested(
    MediaProtectionManager sender, 
    ServiceRequestedEventArgs e)
{
    if (e.Request is PlayReadyIndividualizationServiceRequest)
    {
        PlayReadyIndividualizationServiceRequest IndivRequest = 
            e.Request as PlayReadyIndividualizationServiceRequest;

        bool bResultIndiv = await ReactiveIndivRequest(IndivRequest, e.Completion);
    }
    else if (e.Request is PlayReadyLicenseAcquisitionServiceRequest)
    {
        PlayReadyLicenseAcquisitionServiceRequest licenseRequest = 
            e.Request as PlayReadyLicenseAcquisitionServiceRequest;

        LicenseAcquisitionRequest(
            licenseRequest, 
            e.Completion, 
            playReadyLicenseUrl, 
            playReadyChallengeCustomData);
    }
}
```

## <a name="individualization-service-requests"></a>個別化サービス要求

次のコードでは、PlayReady 個別化サービス要求を事後対応的に行います。 要求は、パラメーターとして関数に渡します。 呼び出しは try/catch ブロックで囲み、例外がない場合は要求が正常に完了したと見なされます。

```csharp
async Task<bool> ReactiveIndivRequest(
    PlayReadyIndividualizationServiceRequest IndivRequest, 
    MediaProtectionServiceCompletion CompletionNotifier)
{
    bool bResult = false;
    Exception exception = null;

    try
    {
        await IndivRequest.BeginServiceRequest();
    }
    catch (Exception ex)
    {
        exception = ex;
    }
    finally
    {
        if (exception == null)
        {
            bResult = true;
        }
        else
        {
            COMException comException = exception as COMException;
            if (comException != null && comException.HResult == MSPR_E_CONTENT_ENABLING_ACTION_REQUIRED)
            {
                IndivRequest.NextServiceRequest();
            }
        }
    }

    if (CompletionNotifier != null) CompletionNotifier.Complete(bResult);
    return bResult;
}
```

または、個別化サービス要求を事前に行うこともできます。その場合、`ProtectionManager_ServiceRequested` で `ReactiveIndivRequest` を呼び出すコードの代わりに次の関数を呼び出します。

```csharp
async void ProActiveIndivRequest()
{
    PlayReadyIndividualizationServiceRequest indivRequest = new PlayReadyIndividualizationServiceRequest();
    bool bResultIndiv = await ReactiveIndivRequest(indivRequest, null);
}
```

## <a name="license-acquisition-service-requests"></a>ライセンス取得サービス要求

代わりに、要求が [PlayReadyLicenseAcquisitionServiceRequest](https://msdn.microsoft.com/library/windows/apps/dn986285) であった場合、次の関数を呼び出して PlayReady ライセンスを要求および取得します。 要求が成功したかどうかを、渡した **MediaProtectionServiceCompletion** オブジェクトに通知し、要求を完了します。

```csharp
async void LicenseAcquisitionRequest(
    PlayReadyLicenseAcquisitionServiceRequest licenseRequest, 
    MediaProtectionServiceCompletion CompletionNotifier, 
    string Url, 
    string ChallengeCustomData)
{
    bool bResult = false;
    string ExceptionMessage = string.Empty;

    try
    {
        if (!string.IsNullOrEmpty(Url))
        {
            if (!string.IsNullOrEmpty(ChallengeCustomData))
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] b = encoding.GetBytes(ChallengeCustomData);
                licenseRequest.ChallengeCustomData = Convert.ToBase64String(b, 0, b.Length);
            }

            PlayReadySoapMessage soapMessage = licenseRequest.GenerateManualEnablingChallenge();

            byte[] messageBytes = soapMessage.GetMessageBody();
            HttpContent httpContent = new ByteArrayContent(messageBytes);

            IPropertySet propertySetHeaders = soapMessage.MessageHeaders;

            foreach (string strHeaderName in propertySetHeaders.Keys)
            {
                string strHeaderValue = propertySetHeaders[strHeaderName].ToString();

                if (strHeaderName.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(strHeaderValue);
                }
                else
                {
                    httpContent.Headers.Add(strHeaderName.ToString(), strHeaderValue);
                }
            }

            CommonLicenseRequest licenseAcquision = new CommonLicenseRequest();

            HttpContent responseHttpContent = 
                await licenseAcquision.AcquireLicense(new Uri(Url), httpContent);

            if (responseHttpContent != null)
            {
                Exception exResult = licenseRequest.ProcessManualEnablingResponse(
                                         await responseHttpContent.ReadAsByteArrayAsync());

                if (exResult != null)
                {
                    throw exResult;
                }
                bResult = true;
            }
            else
            {
                ExceptionMessage = licenseAcquision.GetLastErrorMessage();
            }
        }
        else
        {
            await licenseRequest.BeginServiceRequest();
            bResult = true;
        }
    }
    catch (Exception e)
    {
        ExceptionMessage = e.Message;
    }

    CompletionNotifier.Complete(bResult);
}
```

## <a name="initializing-the-adaptivemediasource"></a>AdaptiveMediaSource の初期化

最後に、特定の [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) と [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) から作成された [AdaptiveMediaSource](https://msdn.microsoft.com/library/windows/apps/dn946912) を初期化するための関数が必要になります。 **Uri** は、メディア ファイル (HLS または DASH) へのリンクです。**MediaElement** は、XAML で定義されます。

```csharp
async private void InitializeAdaptiveMediaSource(System.Uri uri, MediaElement m)
{
    AdaptiveMediaSourceCreationResult result = await AdaptiveMediaSource.CreateFromUriAsync(uri);
    if (result.Status == AdaptiveMediaSourceCreationStatus.Success)
    {
        ams = result.MediaSource;
        SetUpProtectionManager(ref m);
        m.SetMediaStreamSource(ams);
    }
    else
    {
        // Error handling
    }
}
```

この関数は、アダプティブ ストリーミングの開始をどのイベント (たとえば、ボタン クリック イベント) で処理する場合でも呼び出すことができます。

## <a name="see-also"></a>関連項目
- [PlayReady DRM](playready-client-sdk.md)




