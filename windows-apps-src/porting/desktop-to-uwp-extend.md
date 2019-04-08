---
Description: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
Search.Product: eADQiWindows 10XVcnh
title: Windows UI とコンポーネントによるデスクトップ アプリケーションの拡張
ms.date: 06/08/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 2d1fac6d735d4f6915dea1af531dffa666607fe3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641707"
---
# <a name="extend-your-desktop-application-with-modern-uwp-components"></a>最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張

一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。 こうしたエクスペリエンスを追加するには、UWP プロジェクトと Windows ランタイム コンポーネントを使ってデスクトップ アプリケーションを拡張します。

多くの場合、デスクトップ アプリケーションから直接 Windows ランタイム Api を呼び出し、そのため、このガイドを確認する前に表示[Windows 10 の強化](desktop-to-uwp-enhance.md)します。

>[!NOTE]
>このガイドでは、お客様のデスクトップ アプリケーションの Windows アプリ パッケージを作成したことを前提としています。 これはまだ完了していない場合を参照してください。[デスクトップ アプリケーションをパッケージ化](desktop-to-uwp-root.md)します。

準備ができたら始めましょう。

<a id="setup" />

## <a name="first-setup-your-solution"></a>まず、ソリューションをセットアップする

UWP プロジェクトとランタイム コンポーネントを 1 つ以上ソリューションに追加します。

**Windows アプリケーション パッケージ プロジェクト**とデスクトップ アプリケーションへの参照が含まれるソリューションから始めます。

次の画像は、ソリューションの例を示しています。

![開始プロジェクトを拡張する](images/desktop-to-uwp/extend-start-project.png)

場合は、ソリューションには、パッケージのプロジェクトが含まれていないを参照してください。 [Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化](desktop-to-uwp-packaging-dot-net.md)します。

### <a name="configure-the-desktop-application"></a>デスクトップ アプリケーションを構成します。

デスクトップ アプリケーションの Windows ランタイム Api を呼び出すために必要なファイルへの参照を確認します。

これを行うには、次を参照してください。、[プロジェクトを最初に、セットアップ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)」の「 [Windows 10 のデスクトップ アプリケーションの拡張](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance#first-set-up-your-project)します。

### <a name="add-a-uwp-project"></a>UWP プロジェクトを追加する

ソリューションに **[空白のアプリ (ユニバーサル Windows)]** を追加します。

ここでは、最新の XAML UI をビルドするか、UWP プロセス内でのみ実行される API を使います。

![UWP プロジェクト](images/desktop-to-uwp/add-uwp-project-to-solution.png)

パッケージ プロジェクトで、**[アプリケーション]** ノードを右クリックして **[参照の追加]** をクリックします。

![UWP プロジェクトを参照する](images/desktop-to-uwp/add-uwp-project-reference.png)

次に、UWP プロジェクトに参照を追加します。

![UWP プロジェクトを参照する](images/desktop-to-uwp/choose-uwp-project.png)

ソリューションは次のようになります。

![UWP プロジェクトのあるソリューション](images/desktop-to-uwp/uwp-project-reference.png)

### <a name="optional-add-a-windows-runtime-component"></a>(省略可能) Windows ランタイム コンポーネントを追加する

いくつかのシナリオでは、Windows ランタイム コンポーネントにコードを追加する必要があります。

![ランタイム コンポーネントのアプリ サービス](images/desktop-to-uwp/add-runtime-component.png)

次に、UWP プロジェクトからランタイム コンポーネントに参照を追加します。 ソリューションは次のようになります。

![ランタイム コンポーネント参照](images/desktop-to-uwp/runtime-component-reference.png)

### <a name="build-your-solution"></a>ソリューションを構築します。

エラーが表示されないことを確認するソリューションをビルドします。 エラーが発生した場合は開きます**Configuration Manager**プロジェクトのターゲット プラットフォームが同じことを確認してください。

![構成マネージャー](images/desktop-to-uwp/config-manager.png)

UWP プロジェクトとランタイム コンポーネントで行うことができる操作をいくつか見てみましょう。

## <a name="show-a-modern-xaml-ui"></a>最新の XAML UI を表示する

アプリケーション フローの一環として、最新の XAML ベースのユーザー インターフェイスをデスクトップ アプリケーションに組み込むことができます。 これらのユーザー インターフェイスは、さまざまな画面サイズと解像度に適応し、タッチや手描きなどの最新の対話モデルをサポートする性質を備えています。

たとえば、少量の XAML マークアップを使用して、地図関連の強力な視覚化機能をユーザーに提供できます。

次の画像に、マップ コントロールを含む XAML ベースの最新の UI を表示している Windows フォーム アプリケーションを示しています。

![アダプティブ デザイン](images/desktop-to-uwp/extend-xaml-ui.png)

>[!NOTE]
>この例では、UWP プロジェクトをソリューションに追加することで、XAML UI を示します。 デスクトップ アプリケーションで XAML の Ui を表示する場合は、安定したサポートされているアプローチです。 代わりに、この方法では、XAML の島を使用して、デスクトップ アプリケーションに直接 UWP XAML コントロールを追加します。 XAML アイランドは、現在開発者プレビューとして使用できます。 実際に試してみて、プロトタイプのコードで今すぐするを勧めしますが、使用することに実稼働コードでこの時点でをしないでください。 これらの Api とコントロールが成熟し、将来のリリースの Windows を安定化を続けます。 XAML 諸島の詳細については、次を参照してください[デスクトップ アプリケーションでの UWP コントロール。](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)

### <a name="the-design-pattern"></a>設計パターン

XAML ベースの UI を表示するには、以下の手順を実行します。

: 1 つ。[ソリューションをセットアップします。](#solution-setup)

: 2。[XAML UI を作成します。](#xaml-UI)

: 3。[プロトコルの拡張機能を UWP プロジェクトに追加します。](#add-a-protocol-extension)

: 4。[UWP アプリ、デスクトップ アプリを起動します。](#start)

: 5。[UWP プロジェクトでのページを表示します。](#parse)

<a id="solution-setup" />

### <a name="setup-your-solution"></a>ソリューションをセットアップする

ソリューションのセットアップ方法に関する一般的なガイダンスについては、このガイドの冒頭の「[まず、ソリューションをセットアップする](#setup)」セクションを参照してください。

ソリューションは次のようになります。

![XAML UI ソリューション](images/desktop-to-uwp/xaml-ui-solution.png)

この例では、Windows フォーム プロジェクトは **Landmarks** という名前で、XAML UI を含む UWP プロジェクトは **MapUI** という名前です。

<a id="xaml-UI" />

### <a name="create-a-xaml-ui"></a>XAML UI の作成

XAML UI を UWP プロジェクトに追加します。 基本的なマップの XAML を次に示します。

```xml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" Margin="12,20,12,14">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <maps:MapControl x:Name="myMap" Grid.Column="0" Width="500" Height="500"
                     ZoomLevel="{Binding ElementName=zoomSlider,Path=Value, Mode=TwoWay}"
                     Heading="{Binding ElementName=headingSlider,Path=Value, Mode=TwoWay}"
                     DesiredPitch="{Binding ElementName=desiredPitchSlider,Path=Value, Mode=TwoWay}"
                     HorizontalAlignment="Left"
                     MapServiceToken="<Your Key Goes Here" />
    <Grid Grid.Column="1" Margin="12">
        <StackPanel>
            <Slider Minimum="1" Maximum="20" Header="ZoomLevel" Name="zoomSlider" Value="17.5"/>
            <Slider Minimum="0" Maximum="360" Header="Heading" Name="headingSlider" Value="0"/>
            <Slider Minimum="0" Maximum="64" Header=" DesiredPitch" Name="desiredPitchSlider" Value="32"/>
        </StackPanel>
    </Grid>
</Grid>
```

### <a name="add-a-protocol-extension"></a>プロトコル拡張機能を追加する

**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージ プロジェクト、ソリューション内のファイルし、この拡張機能を追加します。

```xml
<Extensions>
  <uap:Extension Category="windows.protocol" Executable="MapUI.exe" EntryPoint="MapUI.App">
    <uap:Protocol Name="xamluidemo" />
  </uap:Extension>
</Extensions>
```

プロトコルに名前を付けて、UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。

デザイナーで **package.appxmanifest** 開き、**[宣言]** タブを選んで、そこで拡張機能を追加することもできます。

![[宣言] タブ](images/desktop-to-uwp/protocol-properties.png)

> [!NOTE]
> マップ コントロールはインターネットからデータをダウンロードします。そのため、マップ コントロールを使用する場合は、"インターネット クライアント" 機能もマニフェストに追加する必要があります。

<a id="start" />

### <a name="start-the-uwp-app"></a>UWP アプリを起動する

まず、デスクトップ アプリケーションから、プロトコル名と UWP アプリに渡すパラメーターが含まれた [URI](https://msdn.microsoft.com/library/system.uri.aspx) を作成します。 次に、[LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを呼び出します。

```csharp

private void Statue_Of_Liberty_Click(object sender, EventArgs e)
{
    ShowMap(40.689247, -74.044502);
}

private async void ShowMap(double lat, double lon)
{
    string str = "xamluidemo://";

    Uri uri = new Uri(str + "location?lat=" +
        lat.ToString() + "&?lon=" + lon.ToString());

    var success = await Windows.System.Launcher.LaunchUriAsync(uri);

}
```

<a id="parse" />

### <a name="parse-parameters-and-show-a-page"></a>パラメーターを解析してページを表示する

UWP プロジェクトの **App** クラスで、**OnActivated** イベント ハンドラーをオーバーライドします。 アプリがプロトコルによってアクティブ化されている場合は、パラメーターを解析して目的のページを開きます。

```csharp
protected override void OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs e)
{
    if (e.Kind == ActivationKind.Protocol)
    {
        ProtocolActivatedEventArgs protocolArgs = (ProtocolActivatedEventArgs)e;
        Uri uri = protocolArgs.Uri;
        if (uri.Scheme == "xamluidemo")
        {
            Frame rootFrame = new Frame();
            Window.Current.Content = rootFrame;
            rootFrame.Navigate(typeof(MainPage), uri.Query);
            Window.Current.Activate();
        }
    }
}
```

XAML ページの背後にあるコードでは、オーバーライド、``OnNavigatedTo``パラメーターを使用するメソッドがページに渡されます。 この場合、このページに渡された緯度と経度を使用してマップに場所を表示します。

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
 {
     if (e.Parameter != null)
     {
         WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Parameter.ToString());

         double lat = Convert.ToDouble(decoder[0].Value);
         double lon = Convert.ToDouble(decoder[1].Value);

         BasicGeoposition pos = new BasicGeoposition();

         pos.Latitude = lat;
         pos.Longitude = lon;

         myMap.Center = new Geopoint(pos);

         myMap.Style = MapStyle.Aerial3D;

     }

     base.OnNavigatedTo(e);
 }
```

## <a name="making-your-desktop-application-a-share-target"></a>デスクトップ アプリケーションを共有ターゲットにする

デスクトップ アプリケーションを共有ターゲットにすることで、共有をサポートしている他のアプリのデータ (画像など) をユーザーが簡単に共有できるようになります。

たとえば、ユーザーは、Microsoft Edge、写真アプリからの画像を共有するアプリケーションを選択できます。 ここで、その機能を持つ WPF サンプル アプリケーションです。

![共有ターゲット](images/desktop-to-uwp/share-target.png).

完全なサンプルを参照してください[ここ。](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/ShareTarget)

### <a name="the-design-pattern"></a>設計パターン

アプリケーションを共有ターゲットにするには、以下の手順を実行します。

: 1 つ。[共有ターゲットの拡張機能を追加します。](#share-extension)

: 2。[OnShareTargetActivated イベント ハンドラーをオーバーライドします。](#override)

: 3。[拡張機能のデスクトップ、UWP プロジェクトを追加します。](#desktop-extensions)

: 4。[完全信頼プロセスの拡張機能を追加します。](#full-trust)

: 5。[共有のファイルを取得するデスクトップ アプリケーションを変更します。](#modify-desktop)

<a id="share-extension" />

次の手順  

### <a name="add-a-share-target-extension"></a>共有ターゲットの拡張機能を追加する

**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージのファイルがソリューションにプロジェクトし、共有ターゲットの拡張機能を追加します。

```xml
<Extensions>
      <uap:Extension
          Category="windows.shareTarget"
          Executable="ShareTarget.exe"
          EntryPoint="App">
        <uap:ShareTarget>
          <uap:SupportedFileTypes>
            <uap:SupportsAnyFileType />
          </uap:SupportedFileTypes>
          <uap:DataFormat>Bitmap</uap:DataFormat>
        </uap:ShareTarget>
      </uap:Extension>
</Extensions>  
```

UWP プロジェクトによって生成された実行可能ファイルの名前と、エントリ ポイント クラスの名前を指定します。 このマークアップは、UWP アプリの実行可能ファイルの名前がある前提としています。`ShareTarget.exe`します。

アプリとの間で共有できるようにするファイルの種類を指定することも必要です。 この例で行っています、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)ビットマップの共有ターゲット イメージのでデスクトップ アプリケーション`Bitmap`サポートされているファイルの種類。

<a id="override" />

### <a name="override-the-onsharetargetactivated-event-handler"></a>OnShareTargetActivated イベント ハンドラーをオーバーライドします。

上書き、 **OnShareTargetActivated**内のイベント ハンドラー、**アプリ**UWP プロジェクトのクラス。

このイベント ハンドラーは、ユーザーがファイルを共有するためにアプリを選択するときに呼び出されます。

```csharp

protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    shareWithDesktopApplication(args.ShareOperation);
}

private async void shareWithDesktopApplication(ShareOperation shareOperation)
{
    if (shareOperation.Data.Contains(StandardDataFormats.StorageItems))
    {
        var items = await shareOperation.Data.GetStorageItemsAsync();
        StorageFile file = items[0] as StorageFile;
        IRandomAccessStreamWithContentType stream = await file.OpenReadAsync();

        await file.CopyAsync(ApplicationData.Current.LocalFolder);
            shareOperation.ReportCompleted();

        await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
    }
}
```

このコードでは、アプリのローカル ストレージ フォルダーに、ユーザーが共有されているイメージを保存します。 後でその同じフォルダーからイメージをプルするデスクトップ アプリケーションを変更します。 UWP アプリと同じパッケージに含まれているために、デスクトップ アプリケーションはことで実現できます。

<a id="desktop-extensions" />

### <a name="add-desktop-extensions-to-the-uwp-project"></a>拡張機能のデスクトップ、UWP プロジェクトを追加します。

追加、 **UWP 用 Windows デスクトップの拡張機能**UWP アプリ プロジェクトを拡張します。

![デスクトップ拡張機能](images/desktop-to-uwp/desktop-extensions.png)

<a id="full-trust" />

### <a name="add-the-full-trust-process-extension"></a>完全信頼プロセスの拡張機能を追加します。

**ソリューション エクスプ ローラー**、オープン、 **package.appxmanifest**パッケージ プロジェクト、ソリューション内のファイルし、これを追加すること、共有ターゲットの拡張機能の横にある完全信頼プロセスの拡張機能を追加ファイルの前。

```xml
<Extensions>
  ...
      <desktop:Extension Category="windows.fullTrustProcess" Executable="PhotoStoreDemo\PhotoStoreDemo.exe" />
  ...
</Extensions>  
```

この拡張機能は、ファイル共有が希望されるデスクトップ アプリケーションを起動する UWP アプリを有効になります。 実行可能ファイルの例では、言及、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)デスクトップ アプリケーションです。

<a id="modify-desktop" />

### <a name="modify-the-desktop-application-to-get-the-shared-file"></a>共有のファイルを取得するデスクトップ アプリケーションを変更します。

見つけて共有ファイルを処理するデスクトップ アプリケーションを変更します。 この例では、UWP アプリは、データのローカルのアプリ フォルダーに共有ファイルを格納します。 そのため、変更します、 [WPF PhotoStoreDemo](https://github.com/Microsoft/WPF-Samples/tree/master/Sample%20Applications/PhotoStoreDemo)プル写真をそのフォルダーからのデスクトップ アプリケーションです。

```csharp
Photos.Path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
```

処理がありますも、ユーザーが既にあるデスクトップ アプリケーションのインスタンスを開いて、 [FileSystemWatcher](https://docs.microsoft.com/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2)イベントとファイルの場所にパスを渡します。 これにより、デスクトップ アプリケーションの開いているすべてのインスタンスは共有フォトに表示されます。

```csharp
...

   FileSystemWatcher watcher = new FileSystemWatcher(Photos.Path);

...

private void Watcher_Created(object sender, FileSystemEventArgs e)
{
    // new file got created, adding it to the list
    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
    {
        if (File.Exists(e.FullPath))
        {
            ImageFile item = new ImageFile(e.FullPath);
            Photos.Insert(0, item);
            PhotoListBox.SelectedIndex = 0;
            CurrentPhoto.Source = (BitmapSource)item.Image;
        }
    }));
}

```

## <a name="create-a-background-task"></a>バックグラウンド タスクを作成する

バックグラウンド タスクを追加して、アプリが一時停止されているときでもコードを実行できます。 バックグラウンド タスクは、ユーザーの操作を必要としない小さなタスクに最適です。 たとえば、タスクはメールのダウンロード、受信チャット メッセージに関するトースト通知の表示、システムの状態の変化に対する対応を行うことができます。

バック グラウンド タスクを登録する WPF サンプル アプリケーションです。

![バックグラウンド タスク](images/desktop-to-uwp/sample-background-task.png)

タスクは http 要求を行い、要求が応答を返すのにかかる時間を測定します。 タスクはさらに興味深いものと考えられますが、このサンプルはバックグラウンド タスクの基本的なしくみを学習するのに適しています。

完全なサンプルを参照してください。[ここ](https://github.com/Microsoft/Windows-Packaging-Samples/tree/master/BGTask)します。

### <a name="the-design-pattern"></a>設計パターン

バックグラウンド サービスを作成するには、以下の手順を実行します。

: 1 つ。[バック グラウンド タスクを実装します。](#implement-task)

: 2。[バック グラウンド タスクを構成します。](#configure-background-task)

: 3。[バック グラウンド タスクを登録します。](#register-background-task)

<a id="implement-task" />

### <a name="implement-the-background-task"></a>バックグラウンド タスクの実装

Windows ランタイム コンポーネント プロジェクトにコードを追加することで、バックグラウンド タスクを実装します。

```csharp
public sealed class SiteVerifier : IBackgroundTask
{
    public async void Run(IBackgroundTaskInstance taskInstance)
    {

        taskInstance.Canceled += TaskInstance_Canceled;
        BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
        var msg = await MeasureRequestTime();
        ShowToast(msg);
        deferral.Complete();
    }

    private async Task<string> MeasureRequestTime()
    {
        string msg;
        try
        {
            var url = ApplicationData.Current.LocalSettings.Values["UrlToVerify"] as string;
            var http = new HttpClient();
            Stopwatch clock = Stopwatch.StartNew();
            var response = await http.GetAsync(new Uri(url));
            response.EnsureSuccessStatusCode();
            var elapsed = clock.ElapsedMilliseconds;
            clock.Stop();
            msg = $"{url} took {elapsed.ToString()} ms";
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }
```

<a id="configure-background-task" />

### <a name="configure-the-background-task"></a>バックグラウンド タスクの構成

マニフェスト デザイナーで開く、 **package.appxmanifest**ソリューションのパッケージ化プロジェクトのファイル。

**[宣言]** タブで、**[バックグラウンド タスク]** 宣言を追加します。

![バックグラウンド タスクのオプション](images/desktop-to-uwp/background-task-option.png)

次に、必要なプロパティを選択します。 サンプルでは、**Timer** プロパティを使います。

![Timer プロパティ](images/desktop-to-uwp/timer-property.png)

バックグラウンド タスクを実装する Windows ランタイム コンポーネントでクラスの完全修飾名を指定します。

![Timer プロパティ](images/desktop-to-uwp/background-task-entry-point.png)

<a id="register-background-task" />

### <a name="register-the-background-task"></a>バックグラウンド タスクの登録

バックグラウンド タスクを登録するデスクトップ アプリケーション プロジェクトにコードを追加します。

```csharp
public void RegisterBackgroundTask(String triggerName)
{
    var current = BackgroundTaskRegistration.AllTasks
        .Where(b => b.Value.Name == triggerName).FirstOrDefault().Value;

    if (current is null)
    {
        BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
        builder.Name = triggerName;
        builder.SetTrigger(new MaintenanceTrigger(15, false));
        builder.TaskEntryPoint = "HttpPing.SiteVerifier";
        builder.Register();
        System.Diagnostics.Debug.WriteLine("BGTask registered:" + triggerName);
    }
    else
    {
        System.Diagnostics.Debug.WriteLine("Task already:" + triggerName);
    }
}
```

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
