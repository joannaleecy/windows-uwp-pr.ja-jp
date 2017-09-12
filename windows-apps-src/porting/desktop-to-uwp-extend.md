---
author: normesta
Description: "Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張"
Search.Product: eADQiWindows 10XVcnh
title: "Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張"
ms.author: normesta
ms.date: 07/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: fce6076f07957b50e83cf80e8d12350630b99456
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a>最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張

一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。 こうしたエクスペリエンスを追加するには、UWP コンポーネントを使ってデスクトップ アプリケーションを拡張します。

多くの場合、デスクトップ アプリケーションから UWP API を直接呼び出すことができます。そのため、このガイドを確認する前に、「[Windows 10 のための拡張](desktop-to-uwp-enhance.md)」をご覧ください。

>[!NOTE]
>このガイドは、デスクトップ ブリッジを使用してデスクトップ アプリケーションの Windows アプリ パッケージを作成済みであることを前提としています。 この作業をまだ行っていない場合は、「[デスクトップ ブリッジ](desktop-to-uwp-root.md)」をご覧ください。

準備ができたら始めましょう。

## <a name="show-a-modern-xaml-ui"></a>最新の XAML UI を表示する

アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。 これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。

たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。

次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している VB6 アプリケーションを示しています。

![アダプティブ デザイン](images\desktop-to-uwp\extend-xaml-ui.png)

### <a name="have-a-closer-look-at-this-app"></a>このアプリを詳しく確認する

:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Add-a-XAML-UI-and-Toast-Notification-to-a-VB6-Application-OsJHC7WhD_8006218965)

:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/vb6-app-with-xaml-sample/9n191ncxf2f6)

:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/VB6withXaml)

### <a name="the-design-pattern"></a>設計パターン

XAML ベースの UI を表示するには、以下の手順を実行します。

:1: [UWP プロジェクトをソリューションに追加する](#project)

:2: [そのプロジェクトにプロトコル拡張機能を追加する](#protocol)

:3: [デスクトップ アプリから UWP アプリを起動する](#start)

:4: [UWP プロジェクトで目的のページを表示する](#parse)

<span id="project" />
### <a name="add-a-uwp-project"></a>UWP プロジェクトを追加する

ソリューションに **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。

<span id="protocol" />
### <a name="add-a-protocol-extension"></a>プロトコル拡張機能を追加する

**ソリューション エクスプ ローラー**で、プロジェクトの **package.appxmanifest** ファイルを開き、目的の拡張機能を追加します。

```xml
<Extensions>
      <uap:Extension
          Category="windows.protocol"
          Executable="MapUI.exe"
          EntryPoint=" MapUI.App">
        <uap:Protocol Name="desktopbridgemapsample" />
      </uap:Extension>
    </Extensions>     
```

プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。

デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。

![[宣言] タブ](images\desktop-to-uwp\protocol-properties.png)



> [!NOTE]
> マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。

<span id="start" />
### <a name="start-the-uwp-app"></a>UWP アプリを起動する

まず、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。 次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) メソッドを呼び出します。

C# の基本的な例を次に示します。

```csharp

private async void showMap(double lat, double lon)
{
    string str = "desktopbridgemapsample://";

    Uri uri = new Uri(str + "location?lat=" +
        lat.ToString() + "&?lon=" + lon.ToString());

    var success = await Windows.System.Launcher.LaunchUriAsync(uri);

    if (success)
    {
        // URI launched
    }
    else
    {
        // URI launch failed
    }
}
```
このサンプルでは、もう少し間接的な作業を行います。 ``LaunchMap`` という名前の VB6 で呼び出せる相互運用関数に呼び出しをラップしました。 この関数は C++ を使用して記述されています。

VB ブロックを次に示します。

```VB
Private Declare Function LaunchMap Lib "UWPWrappers.dll" _
  (ByVal lat As Double, ByVal lon As Double) As Boolean
 
Private Sub EiffelTower_Click()
    LaunchMap 48.858222, 2.2945
End Sub
```

C++ 関数を次に示します。

```C++

DllExport bool __stdcall LaunchMap(double lat, double lon)
{
  try
  {
    String ^str = ref new String(L"desktopbridgemapsample://");
    Uri ^uri = ref new Uri(
      str + L"location?lat=" + lat.ToString() + L"&?lon=" + lon.ToString());
 
    // now launch the UWP component
    Launcher::LaunchUriAsync(uri);
  }
  catch (Exception^ ex) { return false; }
  return true;
}

```

<span id="parse" />
### <a name="parse-parameters-and-show-a-page"></a>パラメーターを解析してページを表示する

UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。 アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。

```C++
void App::OnActivated(Windows::ApplicationModel::Activation::IActivatedEventArgs^ e)
{
  if (e->Kind == ActivationKind::Protocol)
  {
    ProtocolActivatedEventArgs^ protocolArgs = (ProtocolActivatedEventArgs^)e;
    Uri ^uri = protocolArgs->Uri;
    if (uri->SchemeName == "desktopbridgemapsample")
    {
      Frame ^rootFrame = ref new Frame();
      Window::Current->Content = rootFrame;
      rootFrame->Navigate(TypeName(MainPage::typeid), uri->Query);
      Window::Current->Activate();
    }
  }
}
```

### <a name="similar-samples"></a>類似のサンプル

[Northwind サンプル: UWA UI および Win32 レガシ コードのエンド ツー エンドの例](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/NorthwindSample)

[Northwind サンプル: SQL Server に接続する UWP アプリ](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SQLServer)

## <a name="provide-services-to-other-apps"></a>サービスを他のアプリに提供する

他のアプリで利用できるサービスを追加します。 たとえば、アプリの背後でデータベースが実行されている場合に、そのデータベースへの制御されたアクセスを他のアプリに提供するサービスを追加できます。 バックグラウンド タスクを実装することで、デスクトップ アプリが実行されていない場合でも他のアプリからサービスにアクセスできます。

これを実行するサンプルを次に示します。

![アダプティブ デザイン](images\desktop-to-uwp\winforms-app-service.png)

### <a name="have-a-closer-look-at-this-app"></a>このアプリを詳しく確認する

:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Expose-an-AppService-from-a-Windows-Forms-Data-Application-GiqNS7WhD_706218965)

:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/winforms-appservice/9p7d9b6nk5tn)

:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinformsAppService)

### <a name="the-design-pattern"></a>設計パターン

サービスの提供を示すには、以下の手順を実行します。

:1: [Windows ランタイム コンポーネントを追加する](#component)

:2: [アプリ サービスの拡張機能を追加する](#extension)

:3: [アプリ サービスを実装する](#appservice)

:4: [アプリ サービスをテストする](#test)

<span id="component" />

### <a name="add-a-windows-runtime-component"></a>Windows ランタイム コンポーネントを追加する

ソリューションに **[Windows ランタイム コンポーネント (ユニバーサル Windows)]** プロジェクトを追加します。

次に、UWP パッケージ プロジェクトからそのランタイム コンポーネント プロジェクトを参照します。

<span id="extension" />
### <a name="add-an-app-service-extension"></a>アプリ サービスの拡張機能を追加する

**ソリューション エクスプ ローラー**で、パッケージ プロジェクトの **package.appxmanifest** ファイルを開き、アプリ サービスの拡張機能を追加します。

```xml
<Extensions>
      <uap:Extension
          Category="windows.appService"
          EntryPoint="MyAppService.AppServiceTask">
        <uap:AppService Name="com.microsoft.samples.winforms" />
      </uap:Extension>
    </Extensions>    
```

そのアプリ サービスに名前を付けて、エントリ ポイント クラスの名前を指定します。 このクラスは、アプリ サービスを実装するために使用します。

<span id="appservice" />
### <a name="implement-the-app-service"></a>アプリ サービスを実装する

以下では、他のアプリからの要求を検証して処理します。

```csharp
public sealed class AppServiceTask : IBackgroundTask
{
    private BackgroundTaskDeferral backgroundTaskDeferral;
 
    public void Run(IBackgroundTaskInstance taskInstance)
    {
        this.backgroundTaskDeferral = taskInstance.GetDeferral();
        taskInstance.Canceled += OnTaskCanceled;
        var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
        details.AppServiceConnection.RequestReceived += OnRequestReceived;
    }
 
    private async void OnRequestReceived(AppServiceConnection sender,
                                         AppServiceRequestReceivedEventArgs args)
    {
        var messageDeferral = args.GetDeferral();
        ValueSet message = args.Request.Message;
        string id = message["ID"] as string;
        ValueSet returnData = DataBase.GetData(id);
        await args.Request.SendResponseAsync(returnData);
        messageDeferral.Complete();
    }
 
 
    private void OnTaskCanceled(IBackgroundTaskInstance sender,
                                BackgroundTaskCancellationReason reason)
    {
        if (this.backgroundTaskDeferral != null)
        {
            this.backgroundTaskDeferral.Complete();
        }
    }
}
```

<span id="test" />
### <a name="test-the-app-service"></a>アプリ サービスをテストする

別のアプリからサービスを呼び出すことにより、サービスをテストします。

```csharp
private async void button_Click(object sender, RoutedEventArgs e)
{
    AppServiceConnection dataService = new AppServiceConnection();
    dataService.AppServiceName = "com.microsoft.samples.winforms";
    dataService.PackageFamilyName = "Microsoft.SDKSamples.WinformWithAppService";
 
    var status = await dataService.OpenAsync();
    if (status == AppServiceConnectionStatus.Success)
    {
        string id = int.Parse(textBox.Text);
        var message = new ValueSet();
        message.Add("ID", id);
        AppServiceResponse response = await dataService.SendMessageAsync(message);
        string result = "";
 
        if (response.Status == AppServiceResponseStatus.Success)
        {
            if (response.Message["Status"] as string == "OK")
            {
                DisplayResult(response.Message["Result"]);
            }
        }
    }
}
```

アプリ サービスについて詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。

### <a name="similar-samples"></a>類似のサンプル

[アプリ サービス ブリッジのサンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample)

[C++ Win32 アプリを使ったアプリ サービス ブリッジのサンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/AppServiceBridgeSample_C%2B%2B)

[プッシュ通知を受け取る MFC アプリケーション](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/MFCwithPush)


## <a name="making-your-desktop-application-a-share-target"></a>デスクトップ アプリケーションを共有ターゲットにする

デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。

たとえば、ユーザーは、Microsoft Edge やフォト アプリから画像を共有するためにアプリを選択できます。 そのような機能を備えた WPF サンプル アプリは次のとおりです。

![共有ターゲット](images\desktop-to-uwp\share-target.png)

### <a name="have-a-closer-look-at-this-app"></a>このアプリを詳しく確認する

:heavy_check_mark: [ビデオを見る](https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373/Demo-Make-a-WPF-Application-a-Share-Target-xd6Fu6WhD_8406218965)

:heavy_check_mark: [アプリを入手する](https://www.microsoft.com/en-us/store/p/wpf-app-as-sharetarget/9pjcjljlck37)

:heavy_check_mark: [コードを参照する](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WPFasShareTarget)

### <a name="the-design-pattern"></a>設計パターン

アプリケーションを共有ターゲットにするには、以下の手順を実行します。

:1: [UWP プロジェクトをソリューションに追加する](#project2)

:2: [共有ターゲットの拡張機能を追加する](#share-extension)

:3: [OnNavigatedTo イベント ハンドラーをオーバーライドする](#override)

<span id="project2" />
### <a name="add-a-uwp-project-to-your-solution"></a>UWP プロジェクトをソリューションに追加する

ソリューションに **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。

<span id="share-extension" />
### <a name="add-a-share-target-extension"></a>共有ターゲットの拡張機能を追加する

**ソリューション エクスプ ローラー**で、プロジェクトの **package.appxmanifest** ファイルを開き、目的の拡張機能を追加します。

```xml
<Extensions>
      <uap:Extension
          Category="windows.shareTarget"
          Executable="ShareTarget.exe"
          EntryPoint="ShareTarget.App">
        <uap:ShareTarget>
          <uap:SupportedFileTypes>
            <uap:SupportsAnyFileType />
          </uap:SupportedFileTypes>
          <uap:DataFormat>Bitmap</uap:DataFormat>
        </uap:ShareTarget>
      </uap:Extension>
</Extensions>  
```

UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。 アプリとの間で共有できるようにするファイルの種類を指定することも必要です。

<span id="override" />
### <a name="override-the-onnavigatedto-event-handler"></a>OnNavigatedTo イベント ハンドラーをオーバーライドする

UWP プロジェクトの **App** クラスで、**OnNavigatedTo** イベント ハンドラーをオーバーライドします。

このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。

```csharp
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
  this.shareOperation = (ShareOperation)e.Parameter;
  if (this.shareOperation.Data.Contains(StandardDataFormats.StorageItems))
  {
      this.sharedStorageItems =
        await this.shareOperation.Data.GetStorageItemsAsync();
       
      foreach (StorageFile item in this.sharedStorageItems)
      {
          ProcessSharedFile(item);
      }
  }
}
```

## <a name="support-and-feedback"></a>サポートとフィードバック

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。
