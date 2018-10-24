---
author: joannaleecy
title: 市販デモ (RDX) 機能をアプリに追加します。
description: 市販デモ モード、製品版の販売現場でアプリを広く告知を支援するには、アプリを準備します。
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
ms.author: joanlee
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, 市販デモ アプリ
ms.localizationpriority: medium
ms.openlocfilehash: 152c775c1b69bfd82d8969aed7e638f98646bdd7
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5472793"
---
# <a name="add-retail-demo-rdx-features-to-your-app"></a>市販デモ (RDX) 機能をアプリに追加します。

Pc やデバイス販売フロアに試すお客様にすぐに、Windows アプリで、市販デモ モードが含まれます。

小売店でお客様と、Pc やデバイスのデモを試すことができることを期待します。 多くはか、[市販デモ エクスペリエンス (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)を通じて、アプリを時間のします。

_標準_または_リテール_モードでのさまざまなエクスペリエンスを提供するアプリを設定することができます。 たとえば、アプリは、セットアップ プロセスを起動する場合は、リテール モードで飛ばしてをで直接ジャンプできるように、アプリのサンプル データと既定の設定を事前設定があります。

お客様の観点から、アプリを 1 つがあります。 区別できるように、2 つのモードをお勧めしますリテール モードでは、アプリが、その表示される単語「市販」目立つように、タイトル バーまたは適切な場所。

アプリの Microsoft Store の要件に加え RDX 認識アプリの RDX セットアップ、整理、および、小売店で、常に肯定的なエクスペリエンスをユーザーがあることを確認する更新プログラムのプロセスとの互換性も場合があります。

## <a name="design-principles"></a>設計原則

* **メリットを提示**します。 ショーケース アプリ岩理由を市販デモ エクスペリエンスを使用します。 これは、問題は発生初めて顧客のため最適な部分を表示して、アプリが表示されます。

* **高速に表示**されます。 お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。

* **シンプルなストーリー**をします。 市販デモ エクスペリエンスは、アプリの値の真価です。

* **エクスペリエンスにフォーカス**を移動します。 お客様がコンテンツを理解する時間を設けましょう。 魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。

## <a name="technical-requirements"></a>技術的要件

認識 RDX アプリは、小売顧客にアプリの来店に置き換わるものは、技術的要件を満たしているし、Microsoft Store を持つすべての市販デモ エクスペリエンス アプリ定めるプライバシー規則に従っている必要があります。

テスト プロセスの明確化と、検証プロセスの準備に役立つチェックリストとして使用できます。 これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。

### <a name="critical-requirements"></a>重要な要件

これらの必須要件を満たしていない RDX 対応のアプリは、できるだけ早くすべての市販デモ デバイスから削除されます。

* **個人情報 (PII) を求めないように**します。 ここではログイン情報、Microsoft アカウントの情報、または連絡先の詳細です。

* **エラーのないが発生**します。 アプリは、エラーなしで動作する必要があります。 また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。 エラーは、自体、ブランド、デバイスのブランド、デバイスの製造元のブランド、および Microsoft のブランドに、アプリの悪影響反映されます。

* **有料アプリの試用モード必要があります**。 アプリはか無料または[試用モード](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)を含める必要があります。 お客様は小売店での試用に料金を支払うことは想定していません。

### <a name="high-priority-requirements"></a>優先度の高い要件

これらの優先順位の高い要件を満たしていない RDX 対応のアプリは、すぐに修正プログラムを調査する必要があります。 直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。

* **オフライン エクスペリエンス Memorable**します。 アプリは、小売拠点でデバイスの約 50% がオフラインに優れたオフライン エクスペリエンスを示す必要があります。 この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。

* **最新のコンテンツ エクスペリエンス**。 アプリは、オンラインの場合、更新プログラムの入力を求めるしない場合があります。 更新プログラムが必要な場合サイレント モードで実行する必要があります。

* **匿名通信の禁止**します。 市販デモ デバイスを使用して顧客は、匿名ユーザーであるため、すべきメッセージやコンテンツの共有をデバイスからです。

* **クリーンアップ処理を使用して、一貫したエクスペリエンスを提供**します。 市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。 アプリは、[クリーンアップ処理](#clean-up-process)を使用する必要があります、使用後、同じ既定の状態に戻ります。 次のお客様にどのような前のお客様の背後にあるたいしないでください。 これには、スコアボード、達成度、ロック解除が含まれます。

* **年齢に応じた適切なコンテンツ**です。 アプリのすべてのコンテンツがある必要があります、ティーン区分します。 詳細については、[アプリが iarc 評価の取得](https://www.globalratings.com/for-developers.aspx)と[ESRB 評価に関するページ](https://www.esrb.org/ratings/ratings_guide.aspx)を参照してください。

### <a name="medium-priority-requirements"></a>中程度の要件

Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。

* **多様なデバイスで正常に実行することができます**。 アプリは、ローエンド仕様のデバイスを含むすべてのデバイスで適切に実行する必要があります。 最小要件を満たしていないデバイスでアプリをインストールする場合、アプリをこれについてユーザーに明確に通知する必要があります。 アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。

* **小売店用アプリ サイズ要件を満たしている**ください。 アプリのサイズは、800 MB 未満である必要があります。 RDX に対応して、アプリがサイズ要件を満たしていない場合は、Windows リテール ストア チーム詳細については直接問い合わせてください。

## <a name="retailinfo-api-preparing-your-code-for-demo-mode"></a>RetailInfo API: デモ モードのコードを準備します。

### <a name="isdemomodeenabled"></a>IsDemoModeEnabled
これは、Windows 10 SDK に[Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile)名前空間の一部、 [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo)ユーティリティ クラスで[**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled)プロパティは - でアプリを実行するコード パスを指定するブール インジケーターとして使用_法線_モードまたは_リテール_モードです。

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

[**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) から true が返されたら、[**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。 これらのプロパティには、[**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername)、[**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize)、[**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) などが含まれます。

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

## <a name="cleanup-process"></a>クリーンアップ処理

クリーンアップ、買い物では、デバイスとのやり取りが停止したら、2 分が開始されます。 市販デモの再生中、Windows では、連絡先、写真、および他のアプリのサンプル データがすべてのリセットが開始されます。 デバイスに応じてが完全にすべての情報を正常にリセットする 1 ~ 5 分間かかります。 これにより、小売店でのすべてのユーザーがデバイスに手順について説明し、デバイスを操作するとき、同じエクスペリエンスがあることができます。

手順 1: クリーンアップ
* すべての Win32 アプリとストア アプリが終了します
* __ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます
* 構造化されていないローミング状態と構造化されたローミング状態が削除されます
* 構造化されたローカル状態が削除されます

手順 2: セットアップ
* オフライン デバイスの場合: フォルダーは空のままです
* オンライン デバイスの場合: Microsoft Store から市販デモ アセットがデバイスにプッシュされます

### <a name="store-data-across-user-sessions"></a>ユーザー セッション間でデータを保存します。

ユーザー セッション間でデータを保存するには、と、既定のクリーンアップ処理がこのフォルダー内のデータを自動的に削除されません__ApplicationData.Current.TemporaryFolder__で情報を格納することができます。 クリーンアップ処理中に*LocalState*を使用して格納されている情報が削除されたことに注意してください。

### <a name="customize-the-cleanup-process"></a>クリーンアップ処理をカスタマイズします。

クリーンアップ処理をカスタマイズするには、実装、`Microsoft-RetailDemo-Cleanup`アプリ サービスをアプリにします。

カスタムのクリーンアップ ロジックが必要なシナリオには、ダウンロードしキャッシュ データ、またはいない*LocalState*データを削除しようとしている、広範なセットアップの実行が含まれています。

手順 1: アプリ マニフェスト内の_Microsoft のクリーンアップ RetailDemo_サービスを宣言します。
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

手順 2: は、次のサンプル テンプレートを使用して_AppdataCleanup_ケース関数の下にカスタムのクリーンアップ ロジックを実装します。
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

* [アプリ データの保存と取得](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [アプリ サービスの作成と利用の方法](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [グローバリゼーションとローカライズ](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)
* [市販デモ エクスペリエンス (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)
