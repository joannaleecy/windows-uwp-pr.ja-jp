---
author: drewbatgit
ms.assetid: BF877F23-1238-4586-9C16-246F3F25AE35
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。"
title: "PlayReady を使ったアダプティブ ストリーミング"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: aebd2e2de0b1c4991b69b02f1f215ab58feef4a9
ms.sourcegitcommit: cd9b4bdc9c3a0b537a6e910a15df8541b49abf9c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/21/2017
---
# <a name="adaptive-streaming-with-playready"></a><span data-ttu-id="3fe31-104">PlayReady を使ったアダプティブ ストリーミング</span><span class="sxs-lookup"><span data-stu-id="3fe31-104">Adaptive streaming with PlayReady</span></span>

<span data-ttu-id="3fe31-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="3fe31-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="3fe31-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="3fe31-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="3fe31-107">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-107">This article describes how to add adaptive streaming of multimedia content with Microsoft PlayReady content protection to a Universal Windows Platform (UWP) app.</span></span> 

<span data-ttu-id="3fe31-108">現在、この機能では、Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="3fe31-108">This feature currently supports playback of Dynamic streaming over HTTP (DASH) content.</span></span>

<span data-ttu-id="3fe31-109">HLS (Apple の HTTP ライブ ストリーミング) は、PlayReady ではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3fe31-109">HLS (Apple's HTTP Live Streaming) is not supported with PlayReady.</span></span>

<span data-ttu-id="3fe31-110">Smooth Streaming も、現在、ネイティブではサポートされていません。ただし、PlayReady は拡張可能であるため、追加のコードまたはライブラリを使うことで、PlayReady で保護された Smooth Streaming をサポートして、ソフトウェアまたはハードウェアの DRM (デジタル著作権管理) を活用できます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-110">Smooth streaming is also currently not supported natively; however, PlayReady is extensible and by using additional code or libraries, PlayReady-protected Smooth streaming can be supported, leveraging software or even hardware DRM (digital rights management).</span></span>

<span data-ttu-id="3fe31-111">この記事では、アダプティブ ストリーミングの PlayReady 固有の側面についてのみ扱います。</span><span class="sxs-lookup"><span data-stu-id="3fe31-111">This article only deals with the aspects of adaptive streaming specific to PlayReady.</span></span> <span data-ttu-id="3fe31-112">アダプティブ ストリーミングの実装に関する全般的な情報については、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fe31-112">For information about implementing adaptive streaming in general, see [Adaptive streaming](adaptive-streaming.md).</span></span>

<span data-ttu-id="3fe31-113">この記事では、GitHub の Microsoft の **Windows-universal-samples** リポジトリにある[アダプティブ ストリーミングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AdaptiveStreaming)のコードを使っています。</span><span class="sxs-lookup"><span data-stu-id="3fe31-113">This article uses code from the [Adaptive streaming sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AdaptiveStreaming) in Microsoft's **Windows-universal-samples** repository on GitHub.</span></span> <span data-ttu-id="3fe31-114">PlayReady を使ったアダプティブ ストリーミングはシナリオ 4 で取り上げられています。</span><span class="sxs-lookup"><span data-stu-id="3fe31-114">Scenario 4 deals with using adaptive streaming with PlayReady.</span></span> <span data-ttu-id="3fe31-115">リポジトリを含む ZIP ファイルをダウンロードするには、リポジトリのルート レベルに移動して、**[Download ZIP]** ボタンを選びます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-115">You can download the repo in a ZIP file by navigating to the root level of the repository and selecting the **Download ZIP** button.</span></span>

<span data-ttu-id="3fe31-116">次の **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="3fe31-116">You will need the following **using** statements:</span></span>

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

<span data-ttu-id="3fe31-117">**LicenseRequest** 名前空間は、Microsoft がライセンス使用者に提供する PlayReady ファイル **CommonLicenseRequest.cs** にあります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-117">The **LicenseRequest** namespace is from **CommonLicenseRequest.cs**, a PlayReady file provided by Microsoft to licensees.</span></span>

<span data-ttu-id="3fe31-118">いくつかのグローバル変数を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-118">You will need to declare a few global variables:</span></span>

```csharp
private AdaptiveMediaSource ams = null;
private MediaProtectionManager protectionManager = null;
private string playReadyLicenseUrl = "";
private string playReadyChallengeCustomData = "";
```

<span data-ttu-id="3fe31-119">次の定数を宣言することもできます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-119">You will also want to declare the following constant:</span></span>

```csharp
private const uint MSPR_E_CONTENT_ENABLING_ACTION_REQUIRED = 0x8004B895;
```

## <a name="setting-up-the-mediaprotectionmanager"></a><span data-ttu-id="3fe31-120">MediaProtectionManager の設定</span><span class="sxs-lookup"><span data-stu-id="3fe31-120">Setting up the MediaProtectionManager</span></span>

<span data-ttu-id="3fe31-121">PlayReady コンテンツ保護を UWP アプリに追加するには、[MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040) オブジェクトを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-121">To add PlayReady content protection to your UWP app, you will need to set up a [MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040) object.</span></span> <span data-ttu-id="3fe31-122">これは、[**AdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn946912) オブジェクトを初期化するときに行います。</span><span class="sxs-lookup"><span data-stu-id="3fe31-122">You do this when initializing your [**AdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn946912) object.</span></span>

<span data-ttu-id="3fe31-123">次のコードは、[MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040) をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="3fe31-123">The following code sets up a [MediaProtectionManager](https://msdn.microsoft.com/library/windows/apps/br207040):</span></span>

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

<span data-ttu-id="3fe31-124">コンテンツ保護の設定は必須のため、このコードはそのままアプリにコピーできます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-124">This code can simply be copied to your app, since it is mandatory for setting up content protection.</span></span>

<span data-ttu-id="3fe31-125">バイナリ データの読み込みに失敗すると、[ComponentLoadFailed](https://msdn.microsoft.com/library/windows/apps/br207041) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-125">The [ComponentLoadFailed](https://msdn.microsoft.com/library/windows/apps/br207041) event is fired when the load of binary data fails.</span></span> <span data-ttu-id="3fe31-126">これを処理するにはイベント ハンドラーを追加して、読み込みが完了していないことを通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-126">We need to add an event handler to handle this, signaling that the load did not complete:</span></span>

```csharp
private void ProtectionManager_ComponentLoadFailed(
    MediaProtectionManager sender, 
    ComponentLoadFailedEventArgs e)
{
    e.Completion.Complete(false);
}
```

<span data-ttu-id="3fe31-127">同様に、サービスが要求されたときに発生する [ServiceRequested](https://msdn.microsoft.com/library/windows/apps/br207045) イベントのイベント ハンドラーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-127">Similarly, we need to add an event handler for the [ServiceRequested](https://msdn.microsoft.com/library/windows/apps/br207045) event, which fires when a service is requested.</span></span> <span data-ttu-id="3fe31-128">このコードは、要求の種類を確認し、それに応じて応答します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-128">This code checks what kind of request it is, and responds appropriately:</span></span>

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

## <a name="individualization-service-requests"></a><span data-ttu-id="3fe31-129">個別化サービス要求</span><span class="sxs-lookup"><span data-stu-id="3fe31-129">Individualization service requests</span></span>

<span data-ttu-id="3fe31-130">次のコードでは、PlayReady 個別化サービス要求を事後対応的に行います。</span><span class="sxs-lookup"><span data-stu-id="3fe31-130">The following code reactively makes a PlayReady individualization service request.</span></span> <span data-ttu-id="3fe31-131">要求は、パラメーターとして関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-131">We pass in the request as a parameter to the function.</span></span> <span data-ttu-id="3fe31-132">呼び出しは try/catch ブロックで囲み、例外がない場合は要求が正常に完了したと見なされます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-132">We surround the call in a try/catch block, and if there are no exceptions, we say the request completed successfully:</span></span>

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

<span data-ttu-id="3fe31-133">または、個別化サービス要求を事前に行うこともできます。その場合、`ProtectionManager_ServiceRequested` で `ReactiveIndivRequest` を呼び出すコードの代わりに次の関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-133">Alternatively, we may want to proactively make an individualization service request, in which case we call the following function in place of the code calling `ReactiveIndivRequest` in `ProtectionManager_ServiceRequested`:</span></span>

```csharp
async void ProActiveIndivRequest()
{
    PlayReadyIndividualizationServiceRequest indivRequest = new PlayReadyIndividualizationServiceRequest();
    bool bResultIndiv = await ReactiveIndivRequest(indivRequest, null);
}
```

## <a name="license-acquisition-service-requests"></a><span data-ttu-id="3fe31-134">ライセンス取得サービス要求</span><span class="sxs-lookup"><span data-stu-id="3fe31-134">License acquisition service requests</span></span>

<span data-ttu-id="3fe31-135">代わりに、要求が [PlayReadyLicenseAcquisitionServiceRequest](https://msdn.microsoft.com/library/windows/apps/dn986285) であった場合、次の関数を呼び出して PlayReady ライセンスを要求および取得します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-135">If instead the request was a [PlayReadyLicenseAcquisitionServiceRequest](https://msdn.microsoft.com/library/windows/apps/dn986285), we call the following function to request and acquire the PlayReady license.</span></span> <span data-ttu-id="3fe31-136">要求が成功したかどうかを、渡した **MediaProtectionServiceCompletion** オブジェクトに通知し、要求を完了します。</span><span class="sxs-lookup"><span data-stu-id="3fe31-136">We tell the **MediaProtectionServiceCompletion** object that we passed in whether the request was successful or not, and we complete the request:</span></span>

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

## <a name="initializing-the-adaptivemediasource"></a><span data-ttu-id="3fe31-137">AdaptiveMediaSource の初期化</span><span class="sxs-lookup"><span data-stu-id="3fe31-137">Initializing the AdaptiveMediaSource</span></span>

<span data-ttu-id="3fe31-138">最後に、特定の [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) と [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) から作成された [AdaptiveMediaSource](https://msdn.microsoft.com/library/windows/apps/dn946912) を初期化するための関数が必要になります。</span><span class="sxs-lookup"><span data-stu-id="3fe31-138">Finally, you will need a function to initialize the [AdaptiveMediaSource](https://msdn.microsoft.com/library/windows/apps/dn946912), created from a given [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) and [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926).</span></span> <span data-ttu-id="3fe31-139">**Uri** は、メディア ファイル (HLS または DASH) へのリンクです。**MediaElement** は、XAML で定義されます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-139">The **Uri** should be the link to the media file (HLS or DASH); the **MediaElement** should be defined in your XAML.</span></span>

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

<span data-ttu-id="3fe31-140">この関数は、アダプティブ ストリーミングの開始をどのイベント (たとえば、ボタン クリック イベント) で処理する場合でも呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3fe31-140">You can call this function in whichever event handles the start of adaptive streaming; for example, in a button click event.</span></span>

## <a name="see-also"></a><span data-ttu-id="3fe31-141">関連項目</span><span class="sxs-lookup"><span data-stu-id="3fe31-141">See also</span></span>
- [<span data-ttu-id="3fe31-142">PlayReady DRM</span><span class="sxs-lookup"><span data-stu-id="3fe31-142">PlayReady DRM</span></span>](playready-client-sdk.md)




