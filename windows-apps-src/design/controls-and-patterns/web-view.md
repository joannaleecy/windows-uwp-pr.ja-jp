---
Description: A web view control embeds a view into your app that renders web content using the Microsoft Edge rendering engine. Hyperlinks can also appear and function in a web view control.
title: Web ビュー
ms.assetid: D3CFD438-F9D6-4B72-AF1D-16EF2DFC1BB1
label: Web view
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2a29f58ff8dc842fd985a44f94ff44baea51dc2e
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8205477"
---
# <a name="web-view"></a><span data-ttu-id="e92df-103">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="e92df-103">Web view</span></span>
 

<span data-ttu-id="e92df-104">Web ビュー コントロールは、Microsoft Edge レンダリング エンジンを使って、Web コンテンツをレンダリングするアプリにビューを埋め込みます。</span><span class="sxs-lookup"><span data-stu-id="e92df-104">A web view control embeds a view into your app that renders web content using the Microsoft Edge rendering engine.</span></span> <span data-ttu-id="e92df-105">また、Web ビュー コントロールでは、ハイパーリンクの表示と動作が可能です。</span><span class="sxs-lookup"><span data-stu-id="e92df-105">Hyperlinks can also appear and function in a web view control.</span></span>

> <span data-ttu-id="e92df-106">**重要な API**: [WebView クラス](https://msdn.microsoft.com/library/windows/apps/br227702)</span><span class="sxs-lookup"><span data-stu-id="e92df-106">**Important APIs**: [WebView class](https://msdn.microsoft.com/library/windows/apps/br227702)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="e92df-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="e92df-107">Is this the right control?</span></span>

<span data-ttu-id="e92df-108">リモート Web サーバー、動的に生成されたコード、またはアプリ パッケージのコンテンツ ファイルの、書式がリッチな HTML コンテンツを表示するには、Web ビュー コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-108">Use a web view control to display richly formatted HTML content from a remote web server, dynamically generated code, or content files in your app package.</span></span> <span data-ttu-id="e92df-109">また、リッチ コンテンツは、スクリプト コードを含めることができ、さらに、スクリプトとアプリのコード間で通信を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-109">Rich content can also contain script code and communicate between the script and your app's code.</span></span>

## <a name="create-a-web-view"></a><span data-ttu-id="e92df-110">Web ビューを作成する</span><span class="sxs-lookup"><span data-stu-id="e92df-110">Create a web view</span></span>

**<span data-ttu-id="e92df-111">Web ビューの外観を変更する</span><span class="sxs-lookup"><span data-stu-id="e92df-111">Modify the appearance of a web view</span></span>**

<span data-ttu-id="e92df-112">[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) は、[Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) サブクラスではないため、コントロール テンプレートがありません。</span><span class="sxs-lookup"><span data-stu-id="e92df-112">[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) is not a [Control](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.aspx) subclass, so it doesn't have a control template.</span></span> <span data-ttu-id="e92df-113">ただし、さまざまなプロパティを設定して、Web ビューのビジュアル要素の一部を制御することはできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-113">However, you can set various properties to control some visual aspects of the web view.</span></span>
- <span data-ttu-id="e92df-114">表示領域を制限するには、[Width](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) プロパティと [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e92df-114">To constrain the display area, set the [Width](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) and [Height](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) properties.</span></span> 
- <span data-ttu-id="e92df-115">Web ビューの変換、拡大縮小、傾斜、そして回転には、[RenderTransform](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.rendertransform.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-115">To translate, scale, skew, and rotate a web view, use the [RenderTransform](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.rendertransform.aspx) property.</span></span>
- <span data-ttu-id="e92df-116">Web ビューの不透明度を調整するには、[Opacity](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.opacity.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e92df-116">To control the opacity of the web view, set the [Opacity](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.opacity.aspx) property.</span></span>
- <span data-ttu-id="e92df-117">HTML コンテンツが色を指定していないときに、Web ページの背景として色を指定するには、[DefaultBackgroundColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultbackgroundcolor.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e92df-117">To specify a color to use as the web page background when the HTML content does not specify a color, set the [DefaultBackgroundColor](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultbackgroundcolor.aspx) property.</span></span> 

**<span data-ttu-id="e92df-118">Web ページのタイトルを取得する</span><span class="sxs-lookup"><span data-stu-id="e92df-118">Get the web page title</span></span>**

<span data-ttu-id="e92df-119">[DocumentTitle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.documenttitle.aspx) プロパティを使うと、現在 Web ビューに表示されている HTML ドキュメントのタイトルを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="e92df-119">You can get the title of the HTML document currently displayed in the web view by using the [DocumentTitle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.documenttitle.aspx) property.</span></span> 

**<span data-ttu-id="e92df-120">入力イベントとタブ オーダー</span><span class="sxs-lookup"><span data-stu-id="e92df-120">Input events and tab order</span></span>**

<span data-ttu-id="e92df-121">WebView は Control サブクラスではありませんが、キーボードの入力フォーカスを受け取って、タブ順に関与します。</span><span class="sxs-lookup"><span data-stu-id="e92df-121">Although WebView is not a Control subclass, it will receive keyboard input focus and participate in the tab sequence.</span></span> <span data-ttu-id="e92df-122">ただし、[Focus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.focus.aspx) メソッド、そして [GotFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.gotfocus.aspx) イベントと [LostFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.lostfocus.aspx) イベントを提供しますが、タブ関連のプロパティはありません。</span><span class="sxs-lookup"><span data-stu-id="e92df-122">It provides a [Focus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.focus.aspx) method, and [GotFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.gotfocus.aspx) and [LostFocus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.lostfocus.aspx) events, but it has no tab-related properties.</span></span> <span data-ttu-id="e92df-123">タブ順での位置は、XAML ドキュメントの順序での位置と同じです。</span><span class="sxs-lookup"><span data-stu-id="e92df-123">Its position in the tab sequence is the same as its position in the XAML document order.</span></span> <span data-ttu-id="e92df-124">タブ順には、入力フォーカスを受け取ることができる Web ビューのコンテンツの要素がすべて含まれています。</span><span class="sxs-lookup"><span data-stu-id="e92df-124">The tab sequence includes all elements in the web view content that can receive input focus.</span></span> 

<span data-ttu-id="e92df-125">[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) クラスのページの「Event」表からも分かるとおり、Web ビューは、[KeyDown](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keydown.aspx) や [KeyUp](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keyup.aspx)、[PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) といった [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) から継承したユーザー入力イベントのほとんどをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="e92df-125">As indicated in the Events table on the [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) class page, web view doesn’t support most of the user input events inherited from [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), such as [KeyDown](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keydown.aspx), [KeyUp](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.keyup.aspx), and [PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx).</span></span> <span data-ttu-id="e92df-126">その代わり、[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) を JavaScript の **eval** 関数と使って、HTML イベント ハンドラーを利用したり、HTML イベント ハンドラーの **window.external.notify** を通じて [WebView.ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) に対応するアプリに通知したりできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-126">Instead, you can use [InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) with the JavaScript **eval** function to use the HTML event handlers, and to use **window.external.notify** from the HTML event handler to notify the application using [WebView.ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx).</span></span>

### <a name="navigating-to-content"></a><span data-ttu-id="e92df-127">コンテンツに移動する</span><span class="sxs-lookup"><span data-stu-id="e92df-127">Navigating to content</span></span>

<span data-ttu-id="e92df-128">Web ビューには、[GoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goback.aspx)、[GoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goforward.aspx)、[Stop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.stop.aspx)、[Refresh](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.refresh.aspx)、[CanGoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoback.aspx)、そして [CanGoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoforward.aspx) という基本的な操作用の API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e92df-128">Web view provides several APIs for basic navigation: [GoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goback.aspx), [GoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.goforward.aspx), [Stop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.stop.aspx), [Refresh](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.refresh.aspx), [CanGoBack](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoback.aspx), and [CanGoForward](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cangoforward.aspx).</span></span> <span data-ttu-id="e92df-129">これらの API を使うと、一般的な Web 閲覧機能をアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="e92df-129">You can use these to add typical web browsing capabilities to your app.</span></span> 

<span data-ttu-id="e92df-130">Web ビューの初期コンテンツを設定するには、XAML の [Source](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.source.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-130">To set the initial content of the web view, set the [Source](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.source.aspx) property in XAML.</span></span> <span data-ttu-id="e92df-131">XAML パーサーは文字列を [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.uri.aspx)に自動的に変換します。</span><span class="sxs-lookup"><span data-stu-id="e92df-131">The XAML parser automatically converts the string to a [Uri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.uri.aspx).</span></span> 

```xaml
<!-- Source file is on the web. -->
<WebView x:Name="webView1" Source="http://www.contoso.com"/>

<!-- Source file is in local storage. -->
<WebView x:Name="webView2" Source="ms-appdata:///local/intro/welcome.html"/>

<!-- Source file is in the app package. -->
<WebView x:Name="webView3" Source="ms-appx-web:///help/about.html"/>
```

<span data-ttu-id="e92df-132">Source プロパティはコードで設定できますが、それよりも **Navigate** メソッドの 1 つを使ってコンテンツを読み込むほうがよいでしょう。</span><span class="sxs-lookup"><span data-stu-id="e92df-132">The Source property can be set in code, but rather than doing so, you typically use one of the **Navigate** methods to load content in code.</span></span> 

<span data-ttu-id="e92df-133">Web コンテンツを読み込むには、[Navigate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigate.aspx)  メソッドを http または https スキームを使う **Uri** と用います。</span><span class="sxs-lookup"><span data-stu-id="e92df-133">To load web content, use the [Navigate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigate.aspx) method with a **Uri** that uses the http or https scheme.</span></span> 

```csharp
webView1.Navigate("http://www.contoso.com");
```

<span data-ttu-id="e92df-134">POST 要求と HTTP ヘッダーを有する URI へと移動するには、[NavigateWithHttpRequestMessage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatewithhttprequestmessage.aspx) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-134">To navigate to a URI with a POST request and HTTP headers, use the [NavigateWithHttpRequestMessage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatewithhttprequestmessage.aspx) method.</span></span> <span data-ttu-id="e92df-135">このメソッドは、[HttpRequestMessage.Method](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httprequestmessage.method.aspx) プロパティの値として [HttpMethod.Post](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.post.aspx) と [HttpMethod.Get](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.get.aspx) のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="e92df-135">This method supports only [HttpMethod.Post](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.post.aspx) and [HttpMethod.Get](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httpmethod.get.aspx) for the [HttpRequestMessage.Method](https://msdn.microsoft.com/library/windows/apps/xaml/windows.web.http.httprequestmessage.method.aspx) property value.</span></span> 

<span data-ttu-id="e92df-136">圧縮されておらず、暗号化もされていないコンテンツをアプリの [LocalFolder]() データ ストアまたは [TemporaryFolder]() データ ストアから読み込むには、**Navigate** メソッドを、[ms-appdata]() スキームを使う **Uri** と用います。</span><span class="sxs-lookup"><span data-stu-id="e92df-136">To load uncompressed and unencrypted content from your app’s [LocalFolder]() or [TemporaryFolder]() data stores, use the **Navigate** method with a **Uri** that uses the [ms-appdata scheme]().</span></span> <span data-ttu-id="e92df-137">このスキームを Web ビューがサポートするには、ローカル フォルダーまたは一時フォルダーの下にサブフォルダーを設け、そこにコンテンツを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-137">The web view support for this scheme requires you to place your content in a subfolder under the local or temporary folder.</span></span> <span data-ttu-id="e92df-138">これにより、「ms-appdata:///local/*フォルダー*/*ファイル*.html」や「ms-appdata:///temp/*フォルダー*/*ファイル*.html」といった URI への移動が可能になります </span><span class="sxs-lookup"><span data-stu-id="e92df-138">This enables navigation to URIs such as ms-appdata:///local/*folder*/*file*.html and ms-appdata:///temp/*folder*/*file*.html .</span></span> <span data-ttu-id="e92df-139">(圧縮され、暗号化されたファイルを読み込む場合は、[NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx) に関するページをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="e92df-139">(To load compressed or encrypted files, see [NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx).)</span></span> 

<span data-ttu-id="e92df-140">これらの第 1 レベルのサブフォルダーは、他の第 1 レベルのサブフォルダー内のコンテンツから分離されます。</span><span class="sxs-lookup"><span data-stu-id="e92df-140">Each of these first-level subfolders is isolated from the content in other first-level subfolders.</span></span> <span data-ttu-id="e92df-141">たとえば「ms-appdata:///temp/folder1/file.html」に移動はできますが、そのファイル内のリンクに「ms-appdata:///temp/folder2/file.html」は指定できません。</span><span class="sxs-lookup"><span data-stu-id="e92df-141">For example, you can navigate to ms-appdata:///temp/folder1/file.html, but you can’t have a link in this file to ms-appdata:///temp/folder2/file.html.</span></span> <span data-ttu-id="e92df-142">ただし、**ms-appx-web** スキームを使ってアプリ パッケージの HTML コンテンツにリンクしたり、**http** または **https** の URI スキームを使って Web コンテンツにリンクしたりはできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-142">However, you can still link to HTML content in the app package using the **ms-appx-web scheme**, and to web content using the **http** and **https** URI schemes.</span></span>

```csharp
webView1.Navigate("ms-appdata:///local/intro/welcome.html");
```

<span data-ttu-id="e92df-143">アプリ パッケージからコンテンツを読み込むには、**Navigate** メソッドを [ms-appx-web](https://msdn.microsoft.com/library/windows/apps/xaml/jj655406.aspx#ms_appx_web) スキームを使った **Uri** と用います。</span><span class="sxs-lookup"><span data-stu-id="e92df-143">To load content from the your app package, use the **Navigate** method with a **Uri** that uses the [ms-appx-web scheme](https://msdn.microsoft.com/library/windows/apps/xaml/jj655406.aspx#ms_appx_web).</span></span> 

```csharp
webView1.Navigate("ms-appx-web:///help/about.html");
```

<span data-ttu-id="e92df-144">[NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx) メソッドを使えば、カスタム リゾルバーを通じてローカルのコンテンツも読み込めます。</span><span class="sxs-lookup"><span data-stu-id="e92df-144">You can load local content through a custom resolver using the [NavigateToLocalStreamUri](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetolocalstreamuri.aspx) method.</span></span> <span data-ttu-id="e92df-145">これにより、Web ベースのコンテンツをオフライン用にダウンロードないしキャッシングしたり、圧縮ファイルからコンテンツを抽出したりといった高度なシナリオも可能です。</span><span class="sxs-lookup"><span data-stu-id="e92df-145">This enables advanced scenarios such as downloading and caching web-based content for offline use, or extracting content from a compressed file.</span></span>

### <a name="responding-to-navigation-events"></a><span data-ttu-id="e92df-146">ナビゲーション イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="e92df-146">Responding to navigation events</span></span>

<span data-ttu-id="e92df-147">Web ビュー コントロールでは、ナビゲーションやコンテンツの読み込みの状態に対する処理に使うことができるイベントがいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="e92df-147">The web view control provides several events that you can use to respond to navigation and content loading states.</span></span> <span data-ttu-id="e92df-148">ルートとなる Web ビュー コンテンツについて、イベントは次の順番で発生します。[NavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationstarting.aspx)、[ContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.contentloading.aspx)、[DOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.domcontentloaded.aspx)、[NavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationcompleted.aspx)</span><span class="sxs-lookup"><span data-stu-id="e92df-148">The events occur in the following order for the root web view content: [NavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationstarting.aspx), [ContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.contentloading.aspx), [DOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.domcontentloaded.aspx), [NavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigationcompleted.aspx)</span></span>


<span data-ttu-id="e92df-149">**NavigationStarting** - Web ビューが新しいコンテンツに移動する前に発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-149">**NavigationStarting** - Occurs before the web view navigates to new content.</span></span> <span data-ttu-id="e92df-150">WebViewNavigationStartingEventArgs.Cancel プロパティを "true" に設定することで、このイベントのハンドラーで移動をキャンセルできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-150">You can cancel navigation in a handler for this event by setting the WebViewNavigationStartingEventArgs.Cancel property to true.</span></span> 

```csharp
webView1.NavigationStarting += webView1_NavigationStarting;

private void webView1_NavigationStarting(object sender, WebViewNavigationStartingEventArgs args)
{
    // Cancel navigation if URL is not allowed. (Implemetation of IsAllowedUri not shown.)
    if (!IsAllowedUri(args.Uri))
        args.Cancel = true;
}
```

<span data-ttu-id="e92df-151">**ContentLoading** - Web ビューが新しいコンテンツの読み込みを開始すると発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-151">**ContentLoading** - Occurs when the web view has started loading new content.</span></span> 

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

<span data-ttu-id="e92df-152">**DOMContentLoaded** - Web ビューが現在の HTML のコンテンツの解析を完了すると発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-152">**DOMContentLoaded** - Occurs when the web view has finished parsing the current HTML content.</span></span> 

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

<span data-ttu-id="e92df-153">**NavigationCompleted** - Web ビューが現在のコンテンツの読み込みを完了したとき、またはナビゲーションに失敗したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-153">**NavigationCompleted** - Occurs when the web view has finished loading the current content or if navigation has failed.</span></span> <span data-ttu-id="e92df-154">ナビゲーションが失敗したかを判断するには、[WebViewNavigationCompletedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.aspx) クラスの [IsSuccess](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.issuccess.aspx) プロパティと [WebErrorStatus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.weberrorstatus.aspx) プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="e92df-154">To determine whether navigation has failed, check the [IsSuccess](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.issuccess.aspx) and [WebErrorStatus](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.weberrorstatus.aspx) properties of the [WebViewNavigationCompletedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewnavigationcompletedeventargs.aspx) class.</span></span> 

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

<span data-ttu-id="e92df-155">Web ビューのコンテンツの各 **iframe** についても、同様のイベントが同じ順序で発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-155">Similar events occur in the same order for each **iframe** in the web view content:</span></span> 
- <span data-ttu-id="e92df-156">[FrameNavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationstarting.aspx) - - Web ビューのフレームが新しいコンテンツに移動する前に発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-156">[FrameNavigationStarting](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationstarting.aspx) - Occurs before a frame in the web view navigates to new content.</span></span> 
- <span data-ttu-id="e92df-157">[FrameContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framecontentloading.aspx) - Web ビューのフレームが新しいコンテンツの読み込みを開始すると発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-157">[FrameContentLoading](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framecontentloading.aspx) - Occurs when a frame in the web view has started loading new content.</span></span> 
- <span data-ttu-id="e92df-158">[FrameDOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framedomcontentloaded.aspx) - Web ビューのフレームが現在の HTML のコンテンツの解析を完了すると発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-158">[FrameDOMContentLoaded](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framedomcontentloaded.aspx) - Occurs when a frame in the web view has finished parsing its current HTML content.</span></span> 
- <span data-ttu-id="e92df-159">[FrameNavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationcompleted.aspx) - Web ビューのフレームがコンテンツの読み込みを完了すると発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-159">[FrameNavigationCompleted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.framenavigationcompleted.aspx) - Occurs when a frame in the web view has finished loading its content.</span></span> 

### <a name="responding-to-potential-problems"></a><span data-ttu-id="e92df-160">潜在的な問題に対処する</span><span class="sxs-lookup"><span data-stu-id="e92df-160">Responding to potential problems</span></span>

<span data-ttu-id="e92df-161">長時間実行されているスクリプトや、Web ビューが読み込めないコンテンツ、安全でないコンテンツに関する警告など潜在的な問題があれば、それに対処することができます。</span><span class="sxs-lookup"><span data-stu-id="e92df-161">You can respond to potential problems with the content such as long running scripts, content that web view can't load, and warnings of unsafe content.</span></span> 

<span data-ttu-id="e92df-162">スクリプトを実行中にアプリが応答しないような場合があったとします。</span><span class="sxs-lookup"><span data-stu-id="e92df-162">Your app might appear unresponsive while scripts are running.</span></span> <span data-ttu-id="e92df-163">すると、Web ビューが JavaScript 実行中に [LongRunningScriptDetected](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.longrunningscriptdetected.aspx) イベントが発生し、スクリプトを中断する機会を提供します。</span><span class="sxs-lookup"><span data-stu-id="e92df-163">The [LongRunningScriptDetected](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.longrunningscriptdetected.aspx) event occurs periodically while the web view executes JavaScript and provides an opportunity to interrupt the script.</span></span> <span data-ttu-id="e92df-164">スクリプトがどれくらいの時間実行されているのかを調べるには、[WebViewLongRunningScriptDetectedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.aspx) の [ExecutionTime](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.executiontime.aspx) プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="e92df-164">To determine how long the script has been running, check the [ExecutionTime](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.executiontime.aspx) property of the [WebViewLongRunningScriptDetectedEventArgs](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.aspx).</span></span> <span data-ttu-id="e92df-165">スクリプトを停止するには、イベント引数の [StopPageScriptExecution](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.stoppagescriptexecution.aspx) プロパティを **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e92df-165">To halt the script, set the event args [StopPageScriptExecution](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewlongrunningscriptdetectedeventargs.stoppagescriptexecution.aspx) property to **true**.</span></span> <span data-ttu-id="e92df-166">停止されたスクリプトは、以降の Web ビューのナビゲーションでもう一度読み込まれるまで、実行されません。</span><span class="sxs-lookup"><span data-stu-id="e92df-166">The halted script will not execute again unless it is reloaded during a subsequent web view navigation.</span></span> 

<span data-ttu-id="e92df-167">Web ビュー コントロールは、任意のファイルの種類をホストすることができません。</span><span class="sxs-lookup"><span data-stu-id="e92df-167">The web view control cannot host arbitrary file types.</span></span> <span data-ttu-id="e92df-168">Web ビューがホストできないコンテンツを読み込もうすると、[UnviewableContentIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unviewablecontentidentified.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-168">When an attempt is made to load content that the web view can't host, the [UnviewableContentIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unviewablecontentidentified.aspx) event occurs.</span></span> <span data-ttu-id="e92df-169">このイベントを処理してユーザーに通知することも、[Launcher](https://msdn.microsoft.com/library/windows/apps/xaml/windows.system.launcher.aspx) クラスを使ってファイルを外部のブラウザーまたは別のアプリにリダイレクトすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-169">You can handle this event and notify the user, or use the [Launcher](https://msdn.microsoft.com/library/windows/apps/xaml/windows.system.launcher.aspx) class to redirect the file to an external browser or another app.</span></span>

<span data-ttu-id="e92df-170">同様に、fbconnect:// や mailto:// といったサポートされていない URI スキームが Web コンテンツで呼び出されると、[UnsupportedUriSchemeIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsupportedurischemeidentified.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-170">Similarly, the [UnsupportedUriSchemeIdentified](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsupportedurischemeidentified.aspx) event occurs when a URI scheme that's not supported is invoked in the web content, such as fbconnect:// or mailto://.</span></span> <span data-ttu-id="e92df-171">既定のシステム起動プログラムに URI を起動させるのではなく、このイベントを処理してカスタム動作を定義してもよいでしょう。</span><span class="sxs-lookup"><span data-stu-id="e92df-171">You can handle this event to provide custom behavior instead of allowing the default system launcher to launch the URI.</span></span>

<span data-ttu-id="e92df-172">Web ビューが、SmartScreen フィルターにより安全でないと報告されているコンテンツの警告ページを表示すると、[UnsafeContentWarningDisplayingevent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsafecontentwarningdisplaying.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e92df-172">The [UnsafeContentWarningDisplayingevent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.unsafecontentwarningdisplaying.aspx) occurs when the web view shows a warning page for content that was reported as unsafe by the SmartScreen Filter.</span></span> <span data-ttu-id="e92df-173">ユーザーがナビゲーションの続行を選んだ場合は、そのページへの移動では以降、警告が表示されたり、イベントが発されたりすることはありません。</span><span class="sxs-lookup"><span data-stu-id="e92df-173">If the user chooses to continue the navigation, subsequent navigation to the page will not display the warning nor fire the event.</span></span>

### <a name="handling-special-cases-for-web-view-content"></a><span data-ttu-id="e92df-174">Web ビューのコンテンツの特殊ケースを処理する</span><span class="sxs-lookup"><span data-stu-id="e92df-174">Handling special cases for web view content</span></span>

<span data-ttu-id="e92df-175">[ContainsFullScreenElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelement.aspx) プロパティと [ContainsFullScreenElementChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelementchanged.aspx) イベントを使うと、全画面での動画の再生といった、全画面表示を可能にしたり、検出したり、または処理したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="e92df-175">You can use the [ContainsFullScreenElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelement.aspx) property and [ContainsFullScreenElementChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.containsfullscreenelementchanged.aspx) event to detect, respond to, and enable full-screen experiences in web content, such as full-screen video playback.</span></span> <span data-ttu-id="e92df-176">たとえば、ContainsFullScreenElementChanged イベントを使えば、Web ビューのサイズを変更して、アプリ ビュー全体を占有することができます。もしくは、次の例で示すとおり、全画面表示が望ましいときは、ウィンドウ内のアプリを全画面表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-176">For example, you may use the ContainsFullScreenElementChanged event to resize the web view to occupy the entirety of your app view, or, as the following example illustrates, put a windowed app in full screen mode when a full screen web experience is desired.</span></span>

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

<span data-ttu-id="e92df-177">[NewWindowRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.newwindowrequested.aspx) イベントを使えば、たとえばポップアップ ウィンドウのように、ホストされている Web コンテンツが新しいウィンドウを表示するよう要求しているようなケースに対処できます。</span><span class="sxs-lookup"><span data-stu-id="e92df-177">You can use the [NewWindowRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.newwindowrequested.aspx) event to handle cases where hosted web content requests a new window to be displayed, such as a popup window.</span></span> <span data-ttu-id="e92df-178">別の WebView コントロールで、要求されたウィンドウのコンテンツを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-178">You can use another WebView control to display the contents of the requested window.</span></span>

<span data-ttu-id="e92df-179">特別な機能を必要とする Web オプションを有効にするには、[PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) イベントを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-179">Use [PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) event to enable web features that require special capabilities.</span></span> <span data-ttu-id="e92df-180">そういった特別な機能には、位置情報、IndexedDB ストレージ、ユーザーのオーディオやビデオ (たとえば、マイクまたは Web カメラからの入力) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e92df-180">These currently include geolocation, IndexedDB storage, and user audio and video (for example, from a microphone or webcam).</span></span> <span data-ttu-id="e92df-181">アプリがユーザーの位置情報またはユーザーのメディアにアクセスする場合も、アプリのマニフェストでそうした機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-181">If your app accesses user location or user media, you still are required to declare this capability in the app manifest.</span></span> <span data-ttu-id="e92df-182">たとえば、位置情報を使うアプリでは少なくとも Package.appxmanifest で次の機能の宣言が必要です。</span><span class="sxs-lookup"><span data-stu-id="e92df-182">For example, an app that uses geolocation needs the following capability declarations at minimum in Package.appxmanifest:</span></span>

```xml
  <Capabilities>
    <Capability Name="internetClient" />
    <DeviceCapability Name="location" />
  </Capabilities>
```

<span data-ttu-id="e92df-183">アプリによる [PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) イベントの処理に加えて、Web オプションを有効にするには、位置情報やメディアの機能を要求するアプリに関する、標準的なシステム ダイアログをユーザーが承認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-183">In addition to the app handling the [PermissionRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.permissionrequested.aspx) event, the user will have to approve standard system dialogs for apps requesting location or media capabilities in order for these features to be enabled.</span></span>

<span data-ttu-id="e92df-184">次の例は、アプリが Bing のマップで位置情報を有効にする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e92df-184">Here is an example of how an app would enable geolocation in a map from Bing:</span></span>

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

<span data-ttu-id="e92df-185">アプリが許可の要求に応答するにあたってユーザーの入力をはじめ非同期の操作を要求する場合は、[WebViewPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.aspx) の [Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx) メソッドを使い、後で処理できる [WebViewDeferredPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewdeferredpermissionrequest.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="e92df-185">If your app requires user input or other asynchronous operations to respond to a permission request, use the [Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx) method of [WebViewPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.aspx) to create a [WebViewDeferredPermissionRequest](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewdeferredpermissionrequest.aspx) that can be acted upon at a later time.</span></span> <span data-ttu-id="e92df-186">[WebViewPermissionRequest.Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx) に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e92df-186">See [WebViewPermissionRequest.Defer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewpermissionrequest.defer.aspx).</span></span> 

<span data-ttu-id="e92df-187">Web ビューでホストされている Web サイトからユーザーが安全にログアウトしなければならない場合や、セキュリティが重要であるような場合は、静的メソッドである [ClearTemporaryWebDataAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cleartemporarywebdataasync.aspx) を呼び出し、当該の Web ビュー セッションでローカルにキャッシュされたコンテンツを消去します。</span><span class="sxs-lookup"><span data-stu-id="e92df-187">If users must securely log out of a website hosted in a web view, or in other cases when security is important, call the static method [ClearTemporaryWebDataAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.cleartemporarywebdataasync.aspx) to clear out all locally cached content from a web view session.</span></span> <span data-ttu-id="e92df-188">これにより、悪意あるユーザーが重要なデータにアクセスするのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="e92df-188">This prevents malicious users from accessing sensitive data.</span></span> 

### <a name="interacting-with-web-view-content"></a><span data-ttu-id="e92df-189">Web ビューのコンテンツとインタラクトする</span><span class="sxs-lookup"><span data-stu-id="e92df-189">Interacting with web view content</span></span>

<span data-ttu-id="e92df-190">[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) メソッドで Web ビューのコンテンツにスクリプトを呼び出し、または挿入し、そして [ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) イベントで Web ビューのコンテンツから情報を反対に取得することで、Web ビューのコンテンツとインタラクトできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-190">You can interact with the content of the web view by using the [InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) method to invoke or inject script into the web view content, and the [ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) event to get information back from the web view content.</span></span>

<span data-ttu-id="e92df-191">Web ビューのコンテンツ内で JavaScript を呼び出すには、[InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-191">To invoke JavaScript inside the web view content, use the [InvokeScriptAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.invokescriptasync.aspx) method.</span></span> <span data-ttu-id="e92df-192">呼び出されたスクリプトは、文字列型の値のみを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="e92df-192">The invoked script can return only string values.</span></span> 

<span data-ttu-id="e92df-193">たとえば、`webView1` という名前の Web ビューのコンテンツに、3 つのパラメーターを要する `setDate` という名前の関数が含まれている場合は、このように呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="e92df-193">For example, if the content of a web view named `webView1` contains a function named `setDate` that takes 3 parameters, you can invoke it like this.</span></span> 

```csharp
string[] args = {"January", "1", "2000"};
string returnValue = await webView1.InvokeScriptAsync("setDate", args);
```


<span data-ttu-id="e92df-194">**InvokeScriptAsync** を JavaScript の **eval** 関数と使って、Web ページにコンテンツを挿入します。</span><span class="sxs-lookup"><span data-stu-id="e92df-194">You can use **InvokeScriptAsync** with the JavaScript **eval** function to inject content into the web page.</span></span>

<span data-ttu-id="e92df-195">ここでは、XAML のテキストボックス (`nameTextBox.Text`) のテキストは、`webView1` でホストされている HTML ページの div に書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="e92df-195">Here, the text of a XAML text box (`nameTextBox.Text`) is written to a div in an HTML page hosted in `webView1`.</span></span> 

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    string functionString = String.Format("document.getElementById('nameDiv').innerText = 'Hello, {0}';", nameTextBox.Text);
    await webView1.InvokeScriptAsync("eval", new string[] { functionString });
}
```

<span data-ttu-id="e92df-196">Web ビューのコンテンツのスクリプトは、文字列型パラメーターの **window.external.notify** を使えば、情報をアプリに戻せます。</span><span class="sxs-lookup"><span data-stu-id="e92df-196">Scripts in the web view content can use **window.external.notify** with a string parameter to send information back to your app.</span></span> <span data-ttu-id="e92df-197">これらのメッセージを受け取るには、[ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e92df-197">To receive these messages, handle the [ScriptNotify](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.scriptnotify.aspx) event.</span></span> 

<span data-ttu-id="e92df-198">外部の Web ページを有効にして、window.external.notify を呼び出した際に **ScriptNotify** イベントを発するには、当該のページの URI をアプリの宣言の **ApplicationContentUriRules** セクションに含める必要があります </span><span class="sxs-lookup"><span data-stu-id="e92df-198">To enable an external web page to fire the **ScriptNotify** event when calling window.external.notify, you must include the page's URI in the **ApplicationContentUriRules** section of the app manifest.</span></span> <span data-ttu-id="e92df-199">(これは、Package.appxmanifest デザイナーの [コンテンツ URI] タブにある Microsoft Visual Studio で可能です)。この一覧にある URI は HTTPS を使う必要があります。また、サブドメインのワイルドカード (たとえば、`https://*.microsoft.com`) を含めることはできますが、ドメインのワイルドカード (たとえば、`https://*.com` や `https://*.*`) を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="e92df-199">(You can do this in Microsoft Visual Studio on the Content URIs tab of the Package.appxmanifest designer.) The URIs in this list must use HTTPS, and may contain subdomain wildcards (for example, `https://*.microsoft.com`) but they cannot contain domain wildcards (for example, `https://*.com` and `https://*.*`).</span></span> <span data-ttu-id="e92df-200">マニフェスト要件は、アプリ パッケージから生成されたコンテンツには適用されず、ms-local-stream:// URI を使う、または [NavigateToString](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetostring.aspx) を使って読み込まれる、のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="e92df-200">The manifest requirement does not apply to content that originates from the app package, uses an ms-local-stream:// URI, or is loaded using [NavigateToString](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.navigatetostring.aspx).</span></span> 

### <a name="accessing-the-windows-runtime-in-a-web-view"></a><span data-ttu-id="e92df-201">Web ビューの Windows ランタイムにアクセスする</span><span class="sxs-lookup"><span data-stu-id="e92df-201">Accessing the Windows Runtime in a web view</span></span>

<span data-ttu-id="e92df-202">[AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx) メソッドを使うと、Windows ランタイム コンポーネントから Web ビューの JavaScript コンテンツにネイティブ クラスのインスタンスを挿入できます。</span><span class="sxs-lookup"><span data-stu-id="e92df-202">You can use the [AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx) method to inject an instance of a native class from a Windows Runtime component into the JavaScript context of the web view.</span></span> <span data-ttu-id="e92df-203">それにより、その Web ビューの JavaScript コンテンツにあるオブジェクトの、ネイティブのメソッドやプロパティ、イベントにフルにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e92df-203">This allows full access to the native methods, properties, and events of that object in the JavaScript content of that web view.</span></span> <span data-ttu-id="e92df-204">クラスは、[AllowForWeb](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.metadata.allowforwebattribute.aspx) 属性で修飾する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-204">The class must be decorated with the [AllowForWeb](https://msdn.microsoft.com/library/windows/apps/xaml/windows.foundation.metadata.allowforwebattribute.aspx) attribute.</span></span> 

<span data-ttu-id="e92df-205">たとえば、このコードは、Windows ランタイム コンポーネントから Web ビューにインポートされた `MyClass` のインスタンスを挿入します。</span><span class="sxs-lookup"><span data-stu-id="e92df-205">For example, this code injects an instance of `MyClass` imported from a Windows Runtime component into a web view.</span></span>

```csharp
private void webView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args) 
{ 
    if (args.Uri.Host == "www.contoso.com")  
    { 
        webView.AddWebAllowedObject("nativeObject", new MyClass()); 
    } 
}
```

<span data-ttu-id="e92df-206">詳しくは、[WebView.AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx) に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e92df-206">For more info, see [WebView.AddWebAllowedObject](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.addweballowedobject.aspx).</span></span> 

<span data-ttu-id="e92df-207">さらに、Web ビューの信頼できる JavaScript コンテンツは、Windows ランタイム API に直接アクセスも許されています。</span><span class="sxs-lookup"><span data-stu-id="e92df-207">In addition, trusted JavaScript content in a web view can be allowed to directly access Windows Runtime APIs.</span></span> <span data-ttu-id="e92df-208">これにより、Web ビューでホストされている Web アプリの強力なネイティブ機能が利用できます。</span><span class="sxs-lookup"><span data-stu-id="e92df-208">This provides powerful native capabilities for web apps hosted in a web view.</span></span> <span data-ttu-id="e92df-209">この機能を有効にするには、WindowsRuntimeAccess を "all" に設定して、信頼できるコンテンツの URI が Package.appxmanifest のアプリの ApplicationContentUriRules でホワイトリスト化される必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-209">To enable this feature, the URI for trusted content must be whitelisted in the ApplicationContentUriRules of the app in Package.appxmanifest, with WindowsRuntimeAccess specifically set to "all".</span></span> 

<span data-ttu-id="e92df-210">この例は、アプリ マニフェストのセクションを示しています。</span><span class="sxs-lookup"><span data-stu-id="e92df-210">This example shows a section of the app manifest.</span></span> <span data-ttu-id="e92df-211">ここでは、ローカル URI が Windows ランタイムへのアクセスを与えられます。</span><span class="sxs-lookup"><span data-stu-id="e92df-211">Here, a local URI is given access to the Windows Runtime.</span></span> 

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

### <a name="options-for-web-content-hosting"></a><span data-ttu-id="e92df-212">Web コンテンツのホスティングのオプション</span><span class="sxs-lookup"><span data-stu-id="e92df-212">Options for web content hosting</span></span>

<span data-ttu-id="e92df-213">[WebView.Settings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.settings.aspx) プロパティ ([WebViewSettings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewsettings.aspx) 型のプロパティ) を使うと、JavaScript と IndexedDB のオン/ オフをコントロールできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-213">You can use the [WebView.Settings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.settings.aspx) property (of type [WebViewSettings](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewsettings.aspx)) to control whether JavaScript and IndexedDB are enabled.</span></span> <span data-ttu-id="e92df-214">たとえば、Web ビューで完全に静的なコンテンツを表示するような場合は、JavaScript を無効にすることでパフォーマンスを高められます。</span><span class="sxs-lookup"><span data-stu-id="e92df-214">For example, if you use a web view to display strictly static content, you might want to disable JavaScript for best performance.</span></span>

### <a name="capturing-web-view-content"></a><span data-ttu-id="e92df-215">Web ビューのコンテンツをキャプチャする</span><span class="sxs-lookup"><span data-stu-id="e92df-215">Capturing web view content</span></span>

<span data-ttu-id="e92df-216">Web ビューのコンテンツを他のアプリと共有できるようにするには、[CaptureSelectedContentToDataPackageAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.captureselectedcontenttodatapackageasync.aspx) メソッドを使います。このメソッドは、[DataPackage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datapackage.aspx) として選択したコンテンツを返します。</span><span class="sxs-lookup"><span data-stu-id="e92df-216">To enable sharing web view content with other apps, use the [CaptureSelectedContentToDataPackageAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.captureselectedcontenttodatapackageasync.aspx) method, which returns the selected content as a [DataPackage](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datapackage.aspx).</span></span> <span data-ttu-id="e92df-217">このメソッドは非同期であるため、[DataRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx) イベント ハンドラーが、非同期呼び出しが完了する前に戻されてしまうのを防ぐために、遅延を適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-217">This method is asynchronous, so you must use a deferral to prevent your [DataRequested](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx) event handler from returning before the asynchronous call is complete.</span></span> 

<span data-ttu-id="e92df-218">Web ビューの現在のコンテンツに関するプレビュー イメージを取得するには、[CapturePreviewToStreamAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.capturepreviewtostreamasync.aspx) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="e92df-218">To get a preview image of the web view's current content, use the [CapturePreviewToStreamAsync](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.capturepreviewtostreamasync.aspx) method.</span></span> <span data-ttu-id="e92df-219">このメソッドは、現在のコンテンツのイメージを作成し、指定のストリームに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="e92df-219">This method creates an image of the current content and writes it to the specified stream.</span></span> 

### <a name="threading-behavior"></a><span data-ttu-id="e92df-220">スレッド処理の動作</span><span class="sxs-lookup"><span data-stu-id="e92df-220">Threading behavior</span></span>

<span data-ttu-id="e92df-221">既定では、Web ビューのコンテンツは、デスクトップ デバイス ファミリのデバイス上の UI スレッドにホストされており、その他のデバイス上の UI スレッドからは分離されています。</span><span class="sxs-lookup"><span data-stu-id="e92df-221">By default, web view content is hosted on the UI thread on devices in the desktop device family, and off the UI thread on all other devices.</span></span> <span data-ttu-id="e92df-222">[WebView.DefaultExecutionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultexecutionmode.aspx) 静的プロパティを使うと、現在のクライアントに対する既定のスレッド処理動作を照会できます。</span><span class="sxs-lookup"><span data-stu-id="e92df-222">You can use the [WebView.DefaultExecutionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.defaultexecutionmode.aspx) static property to query the default threading behavior for the current client.</span></span> <span data-ttu-id="e92df-223">必要であれば、[WebView(WebViewExecutionMode)](https://msdn.microsoft.com/library/windows/apps/xaml/dn932036.aspx) コンストラクターを使ってその動作をオーバーライドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e92df-223">If necessary, you can use the [WebView(WebViewExecutionMode)](https://msdn.microsoft.com/library/windows/apps/xaml/dn932036.aspx) constructor to override this behavior.</span></span> 

> <span data-ttu-id="e92df-224">**注**&nbsp;&nbsp;モバイル デバイスの UI スレッドでコンテンツをホストしている場合は、パフォーマンス上の問題が発生する可能性があります。DefaultExecutionMode を変更するときは、対象となるすべてのデバイスを必ずテストしてください。</span><span class="sxs-lookup"><span data-stu-id="e92df-224">**Note**&nbsp;&nbsp;There might be performance issues when hosting content on the UI thread on mobile devices, so be sure to test on all target devices when you change DefaultExecutionMode.</span></span>

<span data-ttu-id="e92df-225">UI スレッドから外れてコンテンツをホストしている Web ビューは、[FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)といった、Web ビューのコントロールから親へと伝達するジェスチャを必要とする親コントロールや、その他の関連コントロールと互換性がありません。</span><span class="sxs-lookup"><span data-stu-id="e92df-225">A web view that hosts content off the UI thread is not compatible with parent controls that require gestures to propagate up from the web view control to the parent, such as [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx), [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx), and other related controls.</span></span> <span data-ttu-id="e92df-226">そうしたコントロールは、オフ スレッドの Web ビューで開始されるジェスチャを受け取ることができません。</span><span class="sxs-lookup"><span data-stu-id="e92df-226">These controls will not be able to receive gestures initiated in the off-thread web view.</span></span> <span data-ttu-id="e92df-227">さらに、オフ スレッドの Web コンテンツの出力は、直接サポートされていません。つまり、要素は [WebViewBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewbrush.aspx) フィルで代わりに出力することになります。</span><span class="sxs-lookup"><span data-stu-id="e92df-227">In addition, printing off-thread web content is not directly supported – you should print an element with [WebViewBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewbrush.aspx) fill instead.</span></span>

## <a name="recommendations"></a><span data-ttu-id="e92df-228">推奨事項</span><span class="sxs-lookup"><span data-stu-id="e92df-228">Recommendations</span></span>


-   <span data-ttu-id="e92df-229">読み込まれた Web サイトがデバイスに応じて正しく書式設定されており、アプリの他の部分と一貫性のある色、文字体裁、ナビゲーションが使われていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e92df-229">Make sure that the website loaded is formatted correctly for the device and uses colors, typography, and navigation that are consistent with the rest of your app.</span></span>
-   <span data-ttu-id="e92df-230">入力フィールドのサイズを適切に調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-230">Input fields should be appropriately sized.</span></span> <span data-ttu-id="e92df-231">テキストを入力する際にズームインできることにユーザーが気付かない場合があります。</span><span class="sxs-lookup"><span data-stu-id="e92df-231">Users may not realize that they can zoom in to enter text.</span></span>
-   <span data-ttu-id="e92df-232">Web ビューがアプリの他の部分とは異なって見える場合は、関連タスクを実行するための代替のコントロールまたは手段を検討します。</span><span class="sxs-lookup"><span data-stu-id="e92df-232">If a web view doesn't look like the rest of your app, consider alternative controls or ways to accomplish relevant tasks.</span></span> <span data-ttu-id="e92df-233">Web ビューがアプリの他の部分にマッチしていると、ユーザーには、すべての部分が 1 つのシームレスなエクスペリエンスとして認識されます。</span><span class="sxs-lookup"><span data-stu-id="e92df-233">If your web view matches the rest of your app, users will see it all as one seamless experience.</span></span>



## <a name="related-topics"></a><span data-ttu-id="e92df-234">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e92df-234">Related topics</span></span>

* [<span data-ttu-id="e92df-235">WebView クラス</span><span class="sxs-lookup"><span data-stu-id="e92df-235">WebView class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227702)
 

 




