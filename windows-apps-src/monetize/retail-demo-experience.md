---
title: 小売デモ (RDX) 機能をアプリに追加します。
description: 小売販売部門でアプリを支援小売デモ モードでアプリを準備します。
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, UWP, 市販デモ アプリ
ms.localizationpriority: medium
ms.openlocfilehash: b66435dd7c94762874461b48e19e9a60224f287b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596757"
---
# <a name="add-retail-demo-rdx-features-to-your-app"></a>小売デモ (RDX) 機能をアプリに追加します。

Pc や販売フロアにデバイスを試しているお客様はすぐに開始できるように、Windows アプリで、小売デモ モードが含まれます。

お客様は、小売店が、Pc とデバイスのデモを試すことができるものと考えます。 利用してアプリでいろいろ試して、時間のかなりのチャンクを割くこと多くの場合、[デモ エクスペリエンス (RDX) の小売](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)します。

アプリをセットアップするには、中にさまざまなエクスペリエンスを提供する_通常_または_小売_モード。 たとえば、アプリは、セットアップ プロセスを起動する場合小売モードでスキップし、ですぐできるようにサンプル データと既定の設定でアプリを事前可能性があります。

お客様の観点からは、1 つだけのアプリです。 2 つのモードを区別する顧客のため、お勧めしますリテール モードでは、アプリが、表示される、単語"Retail"目立つようタイトル バーで、または適切な場所。

アプリの Microsoft Store の要件だけでなく RDX に対応するアプリの RDX セットアップ、クリーンアップ、および更新プログラムのプロセスを肯定的なエクスペリエンスは、小売店でに顧客との互換性も場合があります。

## <a name="design-principles"></a>設計原則

* **最善の表示**します。 Showcase アプリ rocks 理由に、小売デモ エクスペリエンスを使用します。 最初に、顧客が表示されます、最適なピースをもらうために、アプリを可能性があります。

* **高速表示**します。 お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。

* **単純なストーリー**します。 小売デモ操作では、アプリの値、概要です。

* **エクスペリエンスに注目**します。 お客様がコンテンツを理解する時間を設けましょう。 魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。

## <a name="technical-requirements"></a>技術的要件

RDX に対応するアプリは、小売り店へのアプリのベストを紹介するものとは技術的な要件を満たしている必要があります、小売デモ エクスペリエンスのすべてのアプリを Microsoft Store を含むプライバシー規制を遵守します。

検証プロセスの準備に役立つとわかりやすくするためのテストのプロセスを提供するチェックリストとして使用できます。 これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。

### <a name="critical-requirements"></a>重要な要件

これらの重要な要件を満たしていない RDX に対応するアプリは、できるだけ早く製品デモのすべてのデバイスから削除されます。

* **個人情報 (PII) のメッセージを表示しない**します。 これはログイン情報、Microsoft アカウント情報、または連絡先が含まれます。 詳細情報。

* **エラーのない経験**します。 アプリは、エラーなしで動作する必要があります。 また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。 エラーは、自体、ブランド、デバイスのブランド、デバイスの製造元のブランド、および Microsoft のブランドに、アプリの悪影響を及ぼす反映されます。

* **有料のアプリは試用版モードで必要があります**します。 無料または含めるか、アプリで必要な[試用版モード](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)します。 お客様は小売店での試用に料金を支払うことは想定していません。

### <a name="high-priority-requirements"></a>優先度の高い要件

これらの優先度の高い要件を満たしていない RDX に対応するアプリは、修正プログラムを直ちに調査する必要があります。 直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。

* **覚えやすいオフライン エクスペリエンス**します。 アプリを販売店で、デバイスの約 50% がオフライン、優れたオフライン エクスペリエンスを示す必要があります。 この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。

* **更新コンテンツ エクスペリエンス**します。 アプリは、オンラインの場合、更新プログラムの入力を求めるしない場合があります。 更新プログラムが必要な場合、サイレント モードで実行する必要があります。

* **匿名の通信がありません**します。 小売デモ デバイスを使用して、顧客は、匿名ユーザーであるため、すべきメッセージまたは共有のコンテンツをデバイスから。

* **クリーンアップ プロセスを使用して一貫したエクスペリエンスを提供**します。 市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。 アプリで使用する必要があります[クリーンアップ処理](#cleanup-process)使用後に同じ既定の状態に戻ります。 残されたどのような最終顧客を表示する次の顧客をほしくありません。 これには、スコアボード、達成度、ロック解除が含まれます。

* **適切なコンテンツの年齢**します。 すべてのアプリ コンテンツがある必要があります楽しむ十代のお子様または低い評価カテゴリに割り当てられます。 詳細についてを参照してください。 [IARC により、規制、アプリを取得する](https://www.globalratings.com/for-developers.aspx)と[ESRB 評価](https://www.esrb.org/ratings/ratings_guide.aspx)します。

### <a name="medium-priority-requirements"></a>中程度の要件

Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。

* **さまざまなデバイスで正常に実行するための機能**します。 アプリは、ローエンドの仕様でデバイスを含め、すべてのデバイスで適切に実行する必要があります。 最小要件を満たしていないデバイスでアプリがインストールされている場合、アプリを明らかにこのユーザーに通知する必要があります。 アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。

* **小売ストア アプリのサイズ要件を満たす**します。 アプリのサイズは、800 MB 未満である必要があります。 RDX に対応したアプリがサイズ要件を満たしていない場合の議論を直接 Windows 小売店のチームに問い合わせてください。

## <a name="retailinfo-api-preparing-your-code-for-demo-mode"></a>RetailInfo API:デモ モードのコードを準備します。

### <a name="isdemomodeenabled"></a>IsDemoModeEnabled
[ **IsDemoModeEnabled** ](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled)プロパティ、 [ **RetailInfo** ](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo)ユーティリティ クラスは、一部の[Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) - でアプリを実行するコード パスを指定する、Windows 10 SDK で名前空間を示すブール値として使用される、_通常_モードまたは_小売_モード。

``` csharp
using Windows.Storage;

StorageFolder folder = ApplicationData.Current.LocalFolder;

if (Windows.System.Profile.RetailInfo.IsDemoModeEnabled) 
{
    // Use the demo specific directory
    folder = await folder.GetFolderAsync(“demo”);
}

StorageFile file = await folder.GetFileAsync(“hello.txt”);
// Now read from file
```

``` cpp
using namespace Windows::Storage;

StorageFolder^ localFolder = ApplicationData::Current->LocalFolder;

if (Windows::System::Profile::RetailInfo::IsDemoModeEnabled) 
{
    // Use the demo specific directory
    create_task(localFolder->GetFolderAsync(“demo”).then([this](StorageFolder^ demoFolder)
    {
        return demoFolder->GetFileAsync(“hello.txt”);
    }).then([this](task<StorageFile^> fileTask)
    {
        StorageFile^ file = fileTask.get();
    });
    // Do something with file
}
else
{
    create_task(localFolder->GetFileAsync(“hello.txt”).then([this](StorageFile^ file)
    {
        // Do something with file
    });
}
```

``` javascript
if (Windows.System.Profile.retailInfo.isDemoModeEnabled) {
    console.log(“Retail mode is enabled.”);
} else {
    Console.log(“Retail mode is not enabled.”);
}
```

### <a name="retailinfoproperties"></a>RetailInfo.Properties

[  **IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) から true が返されたら、[**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。 これらのプロパティには、[**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername)、[**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize)、[**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) などが含まれます。

```csharp
using Windows.UI.Xaml.Controls;
using Windows.System.Profile

TextBlock priceText = new TextBlock();
priceText.Text = RetailInfo.Properties[KnownRetailInfo.Price];
// Assume infoPanel is a StackPanel declared in XAML
this.infoPanel.Children.Add(priceText);
```

```cpp
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::System::Profile;

TextBlock ^manufacturerText = ref new TextBlock();
manufacturerText.set_Text(RetailInfo::Properties[KnownRetailInfoProperties::Price]);
// Assume infoPanel is a StackPanel declared in XAML
this->infoPanel->Children->Add(manufacturerText);
```

```javascript
var pro = Windows.System.Profile;
console.log(pro.retailInfo.properties[pro.KnownRetailInfoProperties.price);
```

#### <a name="idl"></a>IDL

```
//  Copyright (c) Microsoft Corporation. All rights reserved.
//
//  WindowsRuntimeAPISet

import "oaidl.idl";
import "inspectable.idl";
import "Windows.Foundation.idl";
#include <sdkddkver.h>

namespace Windows.System.Profile
{
    runtimeclass RetailInfo;
    runtimeclass KnownRetailInfoProperties;

    [version(NTDDI_WINTHRESHOLD), uuid(0712C6B8-8B92-4F2A-8499-031F1798D6EF), exclusiveto(RetailInfo)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    interface IRetailInfoStatics : IInspectable
    {
        [propget] HRESULT IsDemoModeEnabled([out, retval] boolean *value);
        [propget] HRESULT Properties([out, retval, hasvariant] Windows.Foundation.Collections.IMapView<HSTRING, IInspectable *> **value);
    }

    [version(NTDDI_WINTHRESHOLD), uuid(50BA207B-33C4-4A5C-AD8A-CD39F0A9C2E9), exclusiveto(KnownRetailInfoProperties)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    interface IKnownRetailInfoPropertiesStatics : IInspectable
    {
        [propget] HRESULT RetailAccessCode([out, retval] HSTRING *value);
        [propget] HRESULT ManufacturerName([out, retval] HSTRING *value);
        [propget] HRESULT ModelName([out, retval] HSTRING *value);
        [propget] HRESULT DisplayModelName([out, retval] HSTRING *value);
        [propget] HRESULT Price([out, retval] HSTRING *value);
        [propget] HRESULT IsFeatured([out, retval] HSTRING *value);
        [propget] HRESULT FormFactor([out, retval] HSTRING *value);
        [propget] HRESULT ScreenSize([out, retval] HSTRING *value);
        [propget] HRESULT Weight([out, retval] HSTRING *value);
        [propget] HRESULT DisplayDescription([out, retval] HSTRING *value);
        [propget] HRESULT BatteryLifeDescription([out, retval] HSTRING *value);
        [propget] HRESULT ProcessorDescription([out, retval] HSTRING *value);
        [propget] HRESULT Memory([out, retval] HSTRING *value);
        [propget] HRESULT StorageDescription([out, retval] HSTRING *value);
        [propget] HRESULT GraphicsDescription([out, retval] HSTRING *value);
        [propget] HRESULT FrontCameraDescription([out, retval] HSTRING *value);
        [propget] HRESULT RearCameraDescription([out, retval] HSTRING *value);
        [propget] HRESULT HasNfc([out, retval] HSTRING *value);
        [propget] HRESULT HasSdSlot([out, retval] HSTRING *value);
        [propget] HRESULT HasOpticalDrive([out, retval] HSTRING *value);
        [propget] HRESULT IsOfficeInstalled([out, retval] HSTRING *value);
        [propget] HRESULT WindowsVersion([out, retval] HSTRING *value);
    }

    [version(NTDDI_WINTHRESHOLD), static(IRetailInfoStatics, NTDDI_WINTHRESHOLD)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone), static(IRetailInfoStatics, NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    [threading(both)]
    [marshaling_behavior(agile)]
    runtimeclass RetailInfo
    {
    }

    [version(NTDDI_WINTHRESHOLD), static(IKnownRetailInfoPropertiesStatics, NTDDI_WINTHRESHOLD)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone), static(IKnownRetailInfoPropertiesStatics, NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    [threading(both)]
    [marshaling_behavior(agile)]
    runtimeclass KnownRetailInfoProperties
    {
    }
}
```

## <a name="cleanup-process"></a>クリーンアップ プロセス

クリーンアップは、買い物客は、デバイスとのやり取りが停止した後、2 分を開始します。 小売デモを再生し、Windows は、連絡先、写真、およびその他のアプリ内のサンプル データのリセットを開始します。 デバイスによっては、完全にすべてを正常にリセットする 1 ~ 5 分間かかります。 これにより、小売店ですべての顧客がデバイスに方法について説明し、デバイスと対話するときに、同じエクスペリエンスがあることができます。

手順 1:クリーンアップ
* すべての Win32 アプリとストア アプリが終了します
* __ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます
* 構造化されていないローミング状態と構造化されたローミング状態が削除されます
* 構造化されたローカル状態が削除されます

手順 2:セットアップ
* オフライン デバイス。フォルダーは空のまま
* オンライン デバイス。小売デモ資産は、Microsoft Store からデバイスにプッシュできます。

### <a name="store-data-across-user-sessions"></a>ユーザー セッション間でデータの格納

ユーザー セッション間でデータを格納するには、情報を格納できる__ApplicationData.Current.TemporaryFolder__既定値としてクリーンアップ プロセスは自動的に削除されませんこのフォルダー内のデータ。 使用して格納されている情報に注意してください*LocalState*クリーンアップ プロセス中に削除されます。

### <a name="customize-the-cleanup-process"></a>クリーンアップ プロセスをカスタマイズします。

クリーンアップ プロセスをカスタマイズするには、実装、`Microsoft-RetailDemo-Cleanup`をアプリにアプリ サービス。

カスタム クリーンアップ ロジックが必要なシナリオには、ダウンロードし、データをキャッシュまたは突っ立ったの広範なセットアップの実行が含まれています*LocalState*データを削除します。

手順 1:宣言、 _Microsoft のクリーンアップ RetailDemo_アプリケーション マニフェストでサービス。
``` CSharp
  <Applications>
      <Extensions>
        <uap:Extension Category="windows.appService" EntryPoint="MyCompany.MyApp.RDXCustomCleanupTask">
          <uap:AppService Name="Microsoft-RetailDemo-Cleanup" />
        </uap:Extension>
      </Extensions>
   </Application>
  </Applications>

```

手順 2:カスタム クリーンアップ ロジックを実装、 _AppdataCleanup_以下のサンプル テンプレートを使用する大文字と小文字の関数。
``` CSharp
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace MyCompany.MyApp
{
    public sealed class RDXCustomCleanupTask : IBackgroundTask
    {
        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        BackgroundTaskDeferral _deferral = null;
        IBackgroundTaskInstance _taskInstance = null;
        AppServiceConnection _appServiceConnection = null;

        const string MessageCommand = "Command";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            _taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            AppServiceTriggerDetails appService = _taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if ((appService != null) && (appService.Name == "Microsoft-RetailDemo-Cleanup"))
            {
                _appServiceConnection = appService.AppServiceConnection;
                _appServiceConnection.RequestReceived += _appServiceConnection_RequestReceived;
                _appServiceConnection.ServiceClosed += _appServiceConnection_ServiceClosed;
            }
            else
            {
                _deferral.Complete();
            }
        }

        void _appServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
        }

        async void _appServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            //Get a deferral because we will be calling async code
            AppServiceDeferral requestDeferral = args.GetDeferral();
            string command = null;
            var returnData = new ValueSet();

            try
            {
                ValueSet message = args.Request.Message;
                if (message.ContainsKey(MessageCommand))
                {
                    command = message[MessageCommand] as string;
                }

                if (command != null)
                {
                    switch (command)
                    {
                        case "AppdataCleanup":
                            {
                                // Do custom clean up logic here
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                requestDeferral.Complete();
                // Also release the task deferral since we only process one request per instance.
                _deferral.Complete();
            }
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _cancelReason = reason;
        }
    }
}
```

## <a name="related-links"></a>関連リンク

* [アプリ データの格納と取得](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [作成し、app service を使用する方法](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [アプリの内容をローカライズします。](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)
* [小売デモ エクスペリエンス (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)
