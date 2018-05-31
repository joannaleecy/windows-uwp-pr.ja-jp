---
author: Jwmsft
Description: A web view control embeds a view into your app that renders web content using the Microsoft Edge rendering engine. Hyperlinks can also appear and function in a web view control.
title: Web ビュー
ms.assetid: D3CFD438-F9D6-4B72-AF1D-16EF2DFC1BB1
label: Web view
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 78c057d1d92f5fa6ca24e11c279179d432dd0f58
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
ms.locfileid: "1396671"
---
# <a name="web-view"></a>Web ビュー
 

Web ビュー コントロールは、Microsoft Edge レンダリング エンジンを使って、Web コンテンツをレンダリングするアプリにビューを埋め込みます。 また、Web ビュー コントロールでは、ハイパーリンクの表示と動作が可能です。

> **重要な API**: [WebView クラス](https://msdn.microsoft.com/library/windows/apps/br227702)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

リモート Web サーバー、動的に生成されたコード、またはアプリ パッケージのコンテンツ ファイルの、書式がリッチな HTML コンテンツを表示するには、Web ビュー コントロールを使います。 また、リッチ コンテンツは、スクリプト コードを含めることができ、さらに、スクリプトとアプリのコード間で通信を行うこともできます。

## <a name="create-a-web-view"></a>Web ビューを作成する

**Web ビューの外観を変更する**

[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) は、[Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) サブクラスではないため、コントロール テンプレートがありません。 ただし、さまざまなプロパティを設定して、Web ビューのビジュアル要素の一部を制御することはできます。
- 表示領域を制限するには、[Width](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) プロパティと [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティを設定します。 
- Web ビューの変換、拡大縮小、傾斜、そして回転には、[RenderTransform](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.rendertransform.aspx) プロパティを使います。
- Web ビューの不透明度を調整するには、[Opacity](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.opacity.aspx) プロパティを設定します。
- HTML コンテンツが色を指定していないときに、Web ページの背景として色を指定するには、[DefaultBackgroundColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultbackgroundcolor.aspx) プロパティを設定します。 

**Web ページのタイトルを取得する**

[DocumentTitle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.documenttitle.aspx) プロパティを使うと、現在 Web ビューに表示されている HTML ドキュメントのタイトルを取得することができます。 

**入力イベントとタブ オーダー**

WebView は Control サブクラスではありませんが、キーボードの入力フォーカスを受け取って、タブ順に関与します。 ただし、[Focus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.focus.aspx) メソッド、そして [GotFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.gotfocus.aspx) イベントと [LostFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.lostfocus.aspx) イベントを提供しますが、タブ関連のプロパティはありません。 タブ順での位置は、XAML ドキュメントの順序での位置と同じです。 タブ順には、入力フォーカスを受け取ることができる Web ビューのコンテンツの要素がすべて含まれています。 

[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) クラスのページの「Event」表からも分かるとおり、Web ビューは、[KeyDown](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keydown.aspx) や [KeyUp](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keyup.aspx)、[PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) といった [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) から継承したユーザー入力イベントのほとんどをサポートしていません。 その代わり、[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) を JavaScript の **eval** 関数と使って、HTML イベント ハンドラーを利用したり、HTML イベント ハンドラーの **window.external.notify** を通じて [WebView.ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) に対応するアプリに通知したりできます。

### <a name="navigating-to-content"></a>コンテンツに移動する

Web ビューには、[GoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goback.aspx)、[GoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goforward.aspx)、[Stop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.stop.aspx)、[Refresh](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.refresh.aspx)、[CanGoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoback.aspx)、そして [CanGoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoforward.aspx) という基本的な操作用の API が用意されています。 これらの API を使うと、一般的な Web 閲覧機能をアプリに追加できます。 

Web ビューの初期コンテンツを設定するには、XAML の [Source](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.source.aspx) プロパティを使います。 XAML パーサーは文字列を [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.uri.aspx)に自動的に変換します。 

```xaml
<!-- Source file is on the web. -->
<WebView x:Name="webView1" Source="http://www.contoso.com"/>

<!-- Source file is in local storage. -->
<WebView x:Name="webView2" Source="ms-appdata:///local/intro/welcome.html"/>

<!-- Source file is in the app package. -->
<WebView x:Name="webView3" Source="ms-appx-web:///help/about.html"/>
```

Source プロパティはコードで設定できますが、それよりも **Navigate** メソッドの 1 つを使ってコンテンツを読み込むほうがよいでしょう。 

Web コンテンツを読み込むには、[Navigate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigate.aspx)  メソッドを http または https スキームを使う **Uri** と用います。 

```csharp
webView1.Navigate("http://www.contoso.com");
```

POST 要求と HTTP ヘッダーを有する URI へと移動するには、[NavigateWithHttpRequestMessage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatewithhttprequestmessage.aspx) メソッドを使います。 このメソッドは、[HttpRequestMessage.Method](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httprequestmessage.method.aspx) プロパティの値として [HttpMethod.Post](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.post.aspx) と [HttpMethod.Get](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.get.aspx) のみをサポートします。 

圧縮されておらず、暗号化もされていないコンテンツをアプリの [LocalFolder]() データ ストアまたは [TemporaryFolder]() データ ストアから読み込むには、**Navigate** メソッドを、[ms-appdata]() スキームを使う **Uri** と用います。 このスキームを Web ビューがサポートするには、ローカル フォルダーまたは一時フォルダーの下にサブフォルダーを設け、そこにコンテンツを配置する必要があります。 これにより、「ms-appdata:///local/*フォルダー*/*ファイル*.html」や「ms-appdata:///temp/*フォルダー*/*ファイル*.html」といった URI への移動が可能になります  (圧縮され、暗号化されたファイルを読み込む場合は、[NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx) に関するページをご覧ください)。 

これらの第 1 レベルのサブフォルダーは、他の第 1 レベルのサブフォルダー内のコンテンツから分離されます。 たとえば「ms-appdata:///temp/folder1/file.html」に移動はできますが、そのファイル内のリンクに「ms-appdata:///temp/folder2/file.html」は指定できません。 ただし、**ms-appx-web** スキームを使ってアプリ パッケージの HTML コンテンツにリンクしたり、**http** または **https** の URI スキームを使って Web コンテンツにリンクしたりはできます。

```csharp
webView1.Navigate("ms-appdata:///local/intro/welcome.html");
```

アプリ パッケージからコンテンツを読み込むには、**Navigate** メソッドを [ms-appx-web](https://msdn.microsoft.com/library/windows/apps/xaml/jj655406.aspx#ms_appx_web) スキームを使った **Uri** と用います。 

```csharp
webView1.Navigate("ms-appx-web:///help/about.html");
```

[NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx) メソッドを使えば、カスタム リゾルバーを通じてローカルのコンテンツも読み込めます。 これにより、Web ベースのコンテンツをオフライン用にダウンロードないしキャッシングしたり、圧縮ファイルからコンテンツを抽出したりといった高度なシナリオも可能です。

### <a name="responding-to-navigation-events"></a>ナビゲーション イベントを処理する

Web ビュー コントロールでは、ナビゲーションやコンテンツの読み込みの状態に対する処理に使うことができるイベントがいくつか用意されています。 ルートとなる Web ビュー コンテンツについて、イベントは次の順番で発生します。[NavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationstarting.aspx)、[ContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.contentloading.aspx)、[DOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.domcontentloaded.aspx)、[NavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationcompleted.aspx)


**NavigationStarting** - Web ビューが新しいコンテンツに移動する前に発生します。 WebViewNavigationStartingEventArgs.Cancel プロパティを "true" に設定することで、このイベントのハンドラーで移動をキャンセルできます。 

```csharp
webView1.NavigationStarting += webView1_NavigationStarting;

private void webView1_NavigationStarting(object sender, WebViewNavigationStartingEventArgs args)
{
    // Cancel navigation if URL is not allowed. (Implemetation of IsAllowedUri not shown.)
    if (!IsAllowedUri(args.Uri))
        args.Cancel = true;
}
```

**ContentLoading** - Web ビューが新しいコンテンツの読み込みを開始すると発生します。 

```csharp
webView1.ContentLoading += webView1_ContentLoading;

private void webView1_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
{
    // Show status.
    if (args.Uri != null)
    {
        statusTextBlock.Text = "Loading content for " + args.Uri.ToString();
    }
}
```

**DOMContentLoaded** - Web ビューが現在の HTML のコンテンツの解析を完了すると発生します。 

```csharp
webView1.DOMContentLoaded += webView1_DOMContentLoaded;

private void webView1_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
{
    // Show status.
    if (args.Uri != null)
    {
        statusTextBlock.Text = "Content for " + args.Uri.ToString() + " has finished loading";
    }
}
```

**NavigationCompleted** - Web ビューが現在のコンテンツの読み込みを完了したとき、またはナビゲーションに失敗したときに発生します。 ナビゲーションが失敗したかを判断するには、[WebViewNavigationCompletedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.aspx) クラスの [IsSuccess](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.issuccess.aspx) プロパティと [WebErrorStatus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.weberrorstatus.aspx) プロパティを確認します。 

```csharp
webView1.NavigationCompleted += webView1_NavigationCompleted;

private void webView1_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
{
    if (args.IsSuccess == true)
    {
        statusTextBlock.Text = "Navigation to " + args.Uri.ToString() + " completed successfully.";
    }
    else
    {
        statusTextBlock.Text = "Navigation to: " + args.Uri.ToString() + 
                               " failed with error " + args.WebErrorStatus.ToString();
    }
}
```

Web ビューのコンテンツの各 **iframe** についても、同様のイベントが同じ順序で発生します。 
- [FrameNavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationstarting.aspx) - - Web ビューのフレームが新しいコンテンツに移動する前に発生します。 
- [FrameContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framecontentloading.aspx) - Web ビューのフレームが新しいコンテンツの読み込みを開始すると発生します。 
- [FrameDOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framedomcontentloaded.aspx) - Web ビューのフレームが現在の HTML のコンテンツの解析を完了すると発生します。 
- [FrameNavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationcompleted.aspx) - Web ビューのフレームがコンテンツの読み込みを完了すると発生します。 

### <a name="responding-to-potential-problems"></a>潜在的な問題に対処する

長時間実行されているスクリプトや、Web ビューが読み込めないコンテンツ、安全でないコンテンツに関する警告など潜在的な問題があれば、それに対処することができます。 

スクリプトを実行中にアプリが応答しないような場合があったとします。 すると、Web ビューが JavaScript 実行中に [LongRunningScriptDetected](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.longrunningscriptdetected.aspx) イベントが発生し、スクリプトを中断する機会を提供します。 スクリプトがどれくらいの時間実行されているのかを調べるには、[WebViewLongRunningScriptDetectedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.aspx) の [ExecutionTime](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.executiontime.aspx) プロパティを確認します。 スクリプトを停止するには、イベント引数の [StopPageScriptExecution](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.stoppagescriptexecution.aspx) プロパティを **true** に設定します。 停止されたスクリプトは、以降の Web ビューのナビゲーションでもう一度読み込まれるまで、実行されません。 

Web ビュー コントロールは、任意のファイルの種類をホストすることができません。 Web ビューがホストできないコンテンツを読み込もうすると、[UnviewableContentIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unviewablecontentidentified.aspx) イベントが発生します。 このイベントを処理してユーザーに通知することも、[Launcher](https://msdn.microsoft.com/library/windows/apps/xaml/windows.system.launcher.aspx) クラスを使ってファイルを外部のブラウザーまたは別のアプリにリダイレクトすることもできます。

同様に、fbconnect:// や mailto:// といったサポートされていない URI スキームが Web コンテンツで呼び出されると、[UnsupportedUriSchemeIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsupportedurischemeidentified.aspx) イベントが発生します。 既定のシステム起動プログラムに URI を起動させるのではなく、このイベントを処理してカスタム動作を定義してもよいでしょう。

Web ビューが、SmartScreen フィルターにより安全でないと報告されているコンテンツの警告ページを表示すると、[UnsafeContentWarningDisplayingevent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsafecontentwarningdisplaying.aspx) イベントが発生します。 ユーザーがナビゲーションの続行を選んだ場合は、そのページへの移動では以降、警告が表示されたり、イベントが発されたりすることはありません。

### <a name="handling-special-cases-for-web-view-content"></a>Web ビューのコンテンツの特殊ケースを処理する

[ContainsFullScreenElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelement.aspx) プロパティと [ContainsFullScreenElementChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelementchanged.aspx) イベントを使うと、全画面での動画の再生といった、全画面表示を可能にしたり、検出したり、または処理したりすることができます。 たとえば、ContainsFullScreenElementChanged イベントを使えば、Web ビューのサイズを変更して、アプリ ビュー全体を占有することができます。もしくは、次の例で示すとおり、全画面表示が望ましいときは、ウィンドウ内のアプリを全画面表示にすることもできます。

```csharp
// Assume webView is defined in XAML
webView.ContainsFullScreenElementChanged += webView_ContainsFullScreenElementChanged;

private void webView_ContainsFullScreenElementChanged(WebView sender, object args)
{
    var applicationView = ApplicationView.GetForCurrentView();

    if (sender.ContainsFullScreenElement)
    {
        applicationView.TryEnterFullScreenMode();
    }
    else if (applicationView.IsFullScreenMode)
    {
        applicationView.ExitFullScreenMode();
    }
}
```

[NewWindowRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.newwindowrequested.aspx) イベントを使えば、たとえばポップアップ ウィンドウのように、ホストされている Web コンテンツが新しいウィンドウを表示するよう要求しているようなケースに対処できます。 別の WebView コントロールで、要求されたウィンドウのコンテンツを表示することもできます。

特別な機能を必要とする Web オプションを有効にするには、[PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) イベントを使います。 そういった特別な機能には、位置情報、IndexedDB ストレージ、ユーザーのオーディオやビデオ (たとえば、マイクまたは Web カメラからの入力) が含まれます。 アプリがユーザーの位置情報またはユーザーのメディアにアクセスする場合も、アプリのマニフェストでそうした機能を宣言する必要があります。 たとえば、位置情報を使うアプリでは少なくとも Package.appxmanifest で次の機能の宣言が必要です。

```xml
  <Capabilities>
    <Capability Name="internetClient" />
    <DeviceCapability Name="location" />
  </Capabilities>
```

アプリによる [PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) イベントの処理に加えて、Web オプションを有効にするには、位置情報やメディアの機能を要求するアプリに関する、標準的なシステム ダイアログをユーザーが承認する必要があります。

次の例は、アプリが Bing のマップで位置情報を有効にする方法を示しています。

```csharp
// Assume webView is defined in XAML
webView.PermissionRequested += webView_PermissionRequested;

private void webView_PermissionRequested(WebView sender, WebViewPermissionRequestedEventArgs args)
{
    if (args.PermissionRequest.PermissionType == WebViewPermissionType.Geolocation &&
        args.PermissionRequest.Uri.Host == "www.bing.com")
    {
        args.PermissionRequest.Allow();
    }
}
```

アプリが許可の要求に応答するにあたってユーザーの入力をはじめ非同期の操作を要求する場合は、[WebViewPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.aspx) の [Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx) メソッドを使い、後で処理できる [WebViewDeferredPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewdeferredpermissionrequest.aspx) を作成します。 [WebViewPermissionRequest.Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx) に関するページをご覧ください。 

Web ビューでホストされている Web サイトからユーザーが安全にログアウトしなければならない場合や、セキュリティが重要であるような場合は、静的メソッドである [ClearTemporaryWebDataAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cleartemporarywebdataasync.aspx) を呼び出し、当該の Web ビュー セッションでローカルにキャッシュされたコンテンツを消去します。 これにより、悪意あるユーザーが重要なデータにアクセスするのを防ぎます。 

### <a name="interacting-with-web-view-content"></a>Web ビューのコンテンツとインタラクトする

[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) メソッドで Web ビューのコンテンツにスクリプトを呼び出し、または挿入し、そして [ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) イベントで Web ビューのコンテンツから情報を反対に取得することで、Web ビューのコンテンツとインタラクトできます。

Web ビューのコンテンツ内で JavaScript を呼び出すには、[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) メソッドを使います。 呼び出されたスクリプトは、文字列型の値のみを返すことができます。 

たとえば、`webView1` という名前の Web ビューのコンテンツに、3 つのパラメーターを要する `setDate` という名前の関数が含まれている場合は、このように呼び出すことができます。 

```csharp
string[] args = {"January", "1", "2000"};
string returnValue = await webView1.InvokeScriptAsync("setDate", args);
```


**InvokeScriptAsync** を JavaScript の **eval** 関数と使って、Web ページにコンテンツを挿入します。

ここでは、XAML のテキストボックス (`nameTextBox.Text`) のテキストは、`webView1` でホストされている HTML ページの div に書き込まれます。 

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    string functionString = String.Format("document.getElementById('nameDiv').innerText = 'Hello, {0}';", nameTextBox.Text);
    await webView1.InvokeScriptAsync("eval", new string[] { functionString });
}
```

Web ビューのコンテンツのスクリプトは、文字列型パラメーターの **window.external.notify** を使えば、情報をアプリに戻せます。 これらのメッセージを受け取るには、[ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) イベントを処理します。 

外部の Web ページを有効にして、window.external.notify を呼び出した際に **ScriptNotify** イベントを発するには、当該のページの URI をアプリの宣言の **ApplicationContentUriRules** セクションに含める必要があります  (これは、Package.appxmanifest デザイナーの [コンテンツ URI] タブにある Microsoft Visual Studio で可能です)。この一覧にある URI は HTTPS を使う必要があります。また、サブドメインのワイルドカード (たとえば、`https://*.microsoft.com`) を含めることはできますが、ドメインのワイルドカード (たとえば、`https://*.com` や `https://*.*`) を含めることはできません。 マニフェスト要件は、アプリ パッケージから生成されたコンテンツには適用されず、ms-local-stream:// URI を使う、または [NavigateToString](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetostring.aspx) を使って読み込まれる、のいずれかです。 

### <a name="accessing-the-windows-runtime-in-a-web-view"></a>Web ビューの Windows ランタイムにアクセスする

[AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx) メソッドを使うと、Windows ランタイム コンポーネントから Web ビューの JavaScript コンテンツにネイティブ クラスのインスタンスを挿入できます。 それにより、その Web ビューの JavaScript コンテンツにあるオブジェクトの、ネイティブのメソッドやプロパティ、イベントにフルにアクセスできるようになります。 クラスは、[AllowForWeb](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.metadata.allowforwebattribute.aspx) 属性で修飾する必要があります。 

たとえば、このコードは、Windows ランタイム コンポーネントから Web ビューにインポートされた `MyClass` のインスタンスを挿入します。

```csharp
private void webView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args) 
{ 
    if (args.Uri.Host == "www.contoso.com")  
    { 
        webView.AddWebAllowedObject("nativeObject", new MyClass()); 
    } 
}
```

詳しくは、[WebView.AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx) に関するページをご覧ください。 

さらに、Web ビューの信頼できる JavaScript コンテンツは、Windows ランタイム API に直接アクセスも許されています。 これにより、Web ビューでホストされている Web アプリの強力なネイティブ機能が利用できます。 この機能を有効にするには、WindowsRuntimeAccess を "all" に設定して、信頼できるコンテンツの URI が Package.appxmanifest のアプリの ApplicationContentUriRules でホワイトリスト化される必要があります。 

この例は、アプリ マニフェストのセクションを示しています。 ここでは、ローカル URI が Windows ランタイムへのアクセスを与えられます。 

```csharp
  <Applications>
    <Application Id="App"
      ...

      <uap:ApplicationContentUriRules>
        <uap:Rule Match="ms-appx-web:///Web/App.html" WindowsRuntimeAccess="all" Type="include"/>
      </uap:ApplicationContentUriRules>
    </Application>
  </Applications>
```

### <a name="options-for-web-content-hosting"></a>Web コンテンツのホスティングのオプション

[WebView.Settings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.settings.aspx) プロパティ ([WebViewSettings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewsettings.aspx) 型のプロパティ) を使うと、JavaScript と IndexedDB のオン/ オフをコントロールできます。 たとえば、Web ビューで完全に静的なコンテンツを表示するような場合は、JavaScript を無効にすることでパフォーマンスを高められます。

### <a name="capturing-web-view-content"></a>Web ビューのコンテンツをキャプチャする

Web ビューのコンテンツを他のアプリと共有できるようにするには、[CaptureSelectedContentToDataPackageAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.captureselectedcontenttodatapackageasync.aspx) メソッドを使います。このメソッドは、[DataPackage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datapackage.aspx) として選択したコンテンツを返します。 このメソッドは非同期であるため、[DataRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx) イベント ハンドラーが、非同期呼び出しが完了する前に戻されてしまうのを防ぐために、遅延を適用する必要があります。 

Web ビューの現在のコンテンツに関するプレビュー イメージを取得するには、[CapturePreviewToStreamAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.capturepreviewtostreamasync.aspx) メソッドを使います。 このメソッドは、現在のコンテンツのイメージを作成し、指定のストリームに書き込みます。 

### <a name="threading-behavior"></a>スレッド処理の動作

既定では、Web ビューのコンテンツは、デスクトップ デバイス ファミリのデバイス上の UI スレッドにホストされており、その他のデバイス上の UI スレッドからは分離されています。 [WebView.DefaultExecutionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultexecutionmode.aspx) 静的プロパティを使うと、現在のクライアントに対する既定のスレッド処理動作を照会できます。 必要であれば、[WebView(WebViewExecutionMode)](https://msdn.microsoft.com/library/windows/apps/xaml/dn932036.aspx) コンストラクターを使ってその動作をオーバーライドすることもできます。 

> **注**&nbsp;&nbsp;モバイル デバイスの UI スレッドでコンテンツをホストしている場合は、パフォーマンス上の問題が発生する可能性があります。DefaultExecutionMode を変更するときは、対象となるすべてのデバイスを必ずテストしてください。

UI スレッドから外れてコンテンツをホストしている Web ビューは、[FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)といった、Web ビューのコントロールから親へと伝達するジェスチャを必要とする親コントロールや、その他の関連コントロールと互換性がありません。 そうしたコントロールは、オフ スレッドの Web ビューで開始されるジェスチャを受け取ることができません。 さらに、オフ スレッドの Web コンテンツの出力は、直接サポートされていません。つまり、要素は [WebViewBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewbrush.aspx) フィルで代わりに出力することになります。

## <a name="recommendations"></a>推奨事項


-   読み込まれた Web サイトがデバイスに応じて正しく書式設定されており、アプリの他の部分と一貫性のある色、文字体裁、ナビゲーションが使われていることを確認します。
-   入力フィールドのサイズを適切に調整する必要があります。 テキストを入力する際にズームインできることにユーザーが気付かない場合があります。
-   Web ビューがアプリの他の部分とは異なって見える場合は、関連タスクを実行するための代替のコントロールまたは手段を検討します。 Web ビューがアプリの他の部分にマッチしていると、ユーザーには、すべての部分が 1 つのシームレスなエクスペリエンスとして認識されます。



## <a name="related-topics"></a>関連トピック

* [WebView クラス](https://msdn.microsoft.com/library/windows/apps/br227702)
 

 




