---
author: seksenov
title: "ホストされた Web アプリ - ユニバーサル Windows プラットフォーム (UWP) の機能とランタイム API へのアクセス"
description: "ユニバーサル Windows プラットフォーム (UWP) のネイティブ機能と Windows 10 ランタイム API (Cortona 音声コマンド、ライブ タイル、セキュリティのための ACUR、OpenID や OAuth など) のすべてに、リモートの JavaScript からアクセスします。"
kw: Hosted Web Apps, Accessing Windows 10 features from remote JavaScript, Building a Win10 Web Application, Windows JavaScript Apps, Microsoft Web Apps, HTML5 app for PC, ACUR URI Rules for Windows App, Call Live Tiles with web app, Use Cortana with web app, Access Cortana from website, msapplication-cortanavcd
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "ホストされた Web アプリ, JavaScript 用 WinRT API, Win10 Web アプリ, Windows JavaScript アプリ, ApplicationContentUriRules, ACUR, msapplication-cortanavcd, Web アプリ用 Cortana"
ms.openlocfilehash: 86661353916e64cb2ed4d7f0ca7b8830bfe95685
ms.sourcegitcommit: a704e3c259400fc6fbfa5c756c54c12c30692a31
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/12/2017
---
# <a name="accessing-uwp-features"></a><span data-ttu-id="1eab0-104">UWP 機能へのアクセス</span><span class="sxs-lookup"><span data-stu-id="1eab0-104">Accessing UWP features</span></span>

<span data-ttu-id="1eab0-105">Web アプリケーションは、ユニバーサル Windows プラットフォーム (UWP) へのフル アクセスが可能で、Windows デバイスのネイティブ機能のアクティブ化、[Windows セキュリティのメリットの活用](#keep-your-app-secure--setting-application-content-uri-rules-acurs)、サーバーでホストされるスクリプトからの直接的な [Windows ランタイム API の呼び出し](#call-windows-runtime-apis)、[Cortana の統合](#integrate-cortana-voice-commands)の活用、[オンライン認証プロバイダー](#web-authentication-broker)の使用を実現できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-105">Your web application can have full access to the Universal Windows Platform (UWP), activating native features on Windows devices, [benefiting from Windows security](#keep-your-app-secure--setting-application-content-uri-rules-acurs), [calling Windows Runtime APIs](#call-windows-runtime-apis) directly from script hosted on a server, leveraging [Cortana integration](#integrate-cortana-voice-commands), and using an [online authentication provider](#web-authentication-broker).</span></span> <span data-ttu-id="1eab0-106">[ハイブリッド アプリ](##create-hybrid-apps--packaged-web-apps-vs-hosted-web-apps)もサポートされているため、ホストされているスクリプトから呼び出されるローカル コードを使って、リモートとローカルのページ間でのアプリのナビゲーションを管理することができます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-106">[Hybrid apps](##create-hybrid-apps--packaged-web-apps-vs-hosted-web-apps) are also supported as you can include local code to be called from the hosted script and manage app navigation between remote and local pages.</span></span>

## <a name="keep-your-app-secure--setting-application-content-uri-rules-acurs"></a><span data-ttu-id="1eab0-107">アプリのセキュリティの保護: アプリケーション コンテンツ URI 規則 (ACUR) の設定</span><span class="sxs-lookup"><span data-stu-id="1eab0-107">Keep your app secure – Setting Application Content URI Rules (ACURs)</span></span>

<span data-ttu-id="1eab0-108">ACUR (URL 許可リストとも呼ばれる) によって、リモートの HTML、CSS、JavaScript からユニバーサル Windows API への直接的なアクセスを、リモート URL に許可できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-108">Through ACURs, otherwise known as a URL allow list, you are able to give remote URLs direct access to Universal Windows APIs from remote HTML, CSS, and JavaScript.</span></span> <span data-ttu-id="1eab0-109">Windows OS レベルでは、Web サーバーでホストされているコードがプラットフォーム API を直接呼び出すことができるように、適切なポリシーの境界が設定されています。</span><span class="sxs-lookup"><span data-stu-id="1eab0-109">At the Windows OS level, the right policy bounds have been set to allow code hosted on your web server to directly call platform APIs.</span></span> <span data-ttu-id="1eab0-110">ホストされた Web アプリを構成する一連の URL を、アプリケーション コンテンツ URI 規則 (ACUR) に配置する場合は、アプリ パッケージ マニフェストでこれらの境界を定義します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-110">You define these bounds in the app package manifest when you place the set of URLs that make up your Hosted Web App in the Application Content URI Rules (ACURs).</span></span> <span data-ttu-id="1eab0-111">この規則には、アプリのスタート ページと、アプリのページとして含めるその他のあらゆるページを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="1eab0-111">Your rules should include your app’s start page and any other pages you want included as app pages.</span></span> <span data-ttu-id="1eab0-112">必要に応じて、特定の URL を除外することもできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-112">Optionally, you can exclude specific URLs, too.</span></span>

<span data-ttu-id="1eab0-113">規則では、次のような方法で URL 照合を指定します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-113">There are several ways to specify a URL match in your rules:</span></span>

- <span data-ttu-id="1eab0-114">完全なホスト名</span><span class="sxs-lookup"><span data-stu-id="1eab0-114">An exact hostname</span></span>
- <span data-ttu-id="1eab0-115">任意のサブドメインを指定した URI を含むホスト名、またはサブドメインを指定した URI を除外したホスト名</span><span class="sxs-lookup"><span data-stu-id="1eab0-115">A hostname for which a URI with any subdomain of that hostname is included or excluded</span></span>
- <span data-ttu-id="1eab0-116">完全な URI</span><span class="sxs-lookup"><span data-stu-id="1eab0-116">An exact URI</span></span>
- <span data-ttu-id="1eab0-117">クエリ プロパティを含むことができる完全な URI</span><span class="sxs-lookup"><span data-stu-id="1eab0-117">An exact URI that can contain a query property</span></span>
- <span data-ttu-id="1eab0-118">対象に含めるルールの場合は、部分的なパスと、特定のファイル拡張子を示すワイルドカード</span><span class="sxs-lookup"><span data-stu-id="1eab0-118">A partial path and a wildcard to indicate a particular file extension for an include rule</span></span>
- <span data-ttu-id="1eab0-119">対象から除外する規則の場合は、相対パス</span><span class="sxs-lookup"><span data-stu-id="1eab0-119">Relative paths for exclude rules</span></span>

<span data-ttu-id="1eab0-120">規則に含まれない URL にユーザーが移動した場合は、Windows によってターゲット URL がブラウザーで開かれます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-120">If your user navigates to a URL that is not included in your rules, then Windows opens the target URL in a browser.</span></span>

<span data-ttu-id="1eab0-121">以下に、ACUR の例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-121">Here are a few examples of ACURs.</span></span>

```HTML
<Application
Id="App"
StartPage="https://contoso.com/home">
<uap:ApplicationContentUriRules>
    <uap:Rule Type="include" Match="https://contoso.com/" WindowsRuntimeAccess="all" />
    <uap:Rule Type="include" Match="https://*.contoso.com/" WindowsRuntimeAccess="all" />
    <uap:Rule Type="exclude" Match="https://contoso.com/excludethispage.aspx" />
</uap:ApplicationContentUriRules>
```

## <a name="call-windows-runtime-apis"></a><span data-ttu-id="1eab0-122">Windows ランタイム API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="1eab0-122">Call Windows Runtime APIs</span></span>

<span data-ttu-id="1eab0-123">URL がアプリの境界内 (ACUR) で定義されている場合、JavaScript で "WindowsRuntimeAccess" 属性を使って、Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-123">If a URL is defined within the app’s bounds (ACURs), it can call Windows Runtime APIs with JavaScript using the “WindowsRuntimeAccess” attribute.</span></span> <span data-ttu-id="1eab0-124">適切なアクセス権を持つ URL がアプリ ホスティング プロセスに読み込まれたときに、Windows 名前空間がスクリプト エンジンに挿入されて存在しています。</span><span class="sxs-lookup"><span data-stu-id="1eab0-124">The Windows namespace will be injected and present in the script engine when a URL with appropriate access is loaded in the App Host.</span></span> <span data-ttu-id="1eab0-125">これにより、アプリのスクリプトでユニバーサル Windows API を直接呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-125">This makes Universal Windows APIs available for the app’s scripts to call directly.</span></span> <span data-ttu-id="1eab0-126">開発者として必要な作業は、呼び出す Windows API の機能を検出し、必要に応じて、プラットフォームの機能の実行に進むことだけです。</span><span class="sxs-lookup"><span data-stu-id="1eab0-126">As a developer, you just need to feature detect for the Windows API you would like to call and, if available, proceed to light-up platform features.</span></span>

<span data-ttu-id="1eab0-127">これを実現するには、ACUR で `(WindowsRuntimeAccess="<<level>>")` 属性を、次のいずれかの値で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1eab0-127">To enable this, you need to specify the `(WindowsRuntimeAccess="<<level>>")` attribute in the ACURs with the one of these values:</span></span>

- <span data-ttu-id="1eab0-128">**all**: リモート JavaScript コードは、すべての UWP API とローカルのパッケージ化されたコンポーネントにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-128">**all**: Remote JavaScript code has access to all UWP APIs and any local packaged components.</span></span>
- <span data-ttu-id="1eab0-129">**allowForWeb**: リモート JavaScript コードは、パッケージ コード内のカスタム コンポーネントにのみアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-129">**allowForWeb**: Remote JavaScript code has access to custom in package code only.</span></span> <span data-ttu-id="1eab0-130">カスタム C++/C# コンポーネントにローカルにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-130">Local access to custom C++/C# components.</span></span>
- <span data-ttu-id="1eab0-131">**none**: 既定値。</span><span class="sxs-lookup"><span data-stu-id="1eab0-131">**none**: Default.</span></span> <span data-ttu-id="1eab0-132">指定された URL はプラットフォームにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="1eab0-132">The specified URL has no platform access.</span></span>

<span data-ttu-id="1eab0-133">以下に、規則の種類の例を示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-133">Here is an example rule type:</span></span>

```HTML
<uap:ApplicationContentUriRules>
    <uap:Rule Type="include" Match="http://contoso.com/" WindowsRuntimeAccess="all"  />
</uap:ApplicationContentUriRules>
```

<span data-ttu-id="1eab0-134">これにより、https://contoso.com/ で動作しているスクリプトに、Windows ランタイム名前空間と、パッケージに含まれるカスタム コンポーネントへのアクセスが許可されます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-134">This gives script running on https://contoso.com/ access to Windows Runtime namespaces and custom packaged components in the package.</span></span> <span data-ttu-id="1eab0-135">トースト通知用の GitHub のサンプル [Windows.UI.Notifications.js](https://gist.github.com/Gr8Gatsby/3d471150e5b317eb1813#file-windows-ui-notifications-js) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-135">See the [Windows.UI.Notifications.js](https://gist.github.com/Gr8Gatsby/3d471150e5b317eb1813#file-windows-ui-notifications-js) example on GitHub for toast notifications.</span></span>

<span data-ttu-id="1eab0-136">ライブ タイルを実装し、リモート JavaScript からそれを更新する例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-136">Here is an example of how to implement a Live Tile and update it from remote JavaScript:</span></span>

```Javascript
function updateTile(message, imgUrl, imgAlt) {
    // Namespace: Windows.UI.Notifications

    if (typeof Windows !== 'undefined'&&
            typeof Windows.UI !== 'undefined' &&
            typeof Windows.UI.Notifications !== 'undefined') {  
        var notifications = Windows.UI.Notifications,
        tile = notifications.TileTemplateType.tileSquare150x150PeekImageAndText01,
        tileContent = notifications.TileUpdateManager.getTemplateContent(tile),
        tileText = tileContent.getElementsByTagName('text'),
        tileImage = tileContent.getElementsByTagName('image');  
        tileText[0].appendChild(tileContent.createTextNode(message || 'Demo Message'));
        tileImage[0].setAttribute('src', imgUrl || 'https://unsplash.it/150/150/?random');
        tileImage[0].setAttribute('alt', imgAlt || 'Random demo image');    
        var tileNotification = new notifications.TileNotification(tileContent);
        var currentTime = new Date();
        tileNotification.expirationTime = new Date(currentTime.getTime() + 600 * 1000);
        notifications.TileUpdateManager.createTileUpdaterForApplication().update(tileNotification);
    } else {
        //Alternative behavior

    }
}
```

<span data-ttu-id="1eab0-137">このコードは、次のような外観のタイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-137">This code will produce a tile that looks something like this:</span></span>

![Windows 10 のライブ タイルの呼び出し](images/hwa-to-uwp/hwa_livetile.png)

<span data-ttu-id="1eab0-139">呼び出しの前にサーバー上のリソースで常に Windows の機能を検出することによって、最も使い慣れた任意の環境や手法を用いて Windows ランタイム API を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-139">Call Windows Runtime APIs with whatever environment or technique is most familiar to you by keeping your resources on a server feature detecting for Windows capabilities prior to calling them.</span></span> <span data-ttu-id="1eab0-140">プラットフォームの機能が利用できず、Web アプリが別のホストで実行されている場合は、ブラウザーで動作する標準的な既定のエクスペリエンスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-140">If platform capabilities are not available, and the web app is running in another host, you can provide the user with a standard default experience that works in the browser.</span></span>

## <a name="integrate-cortana-voice-commands"></a><span data-ttu-id="1eab0-141">Cortana 音声コマンドの統合</span><span class="sxs-lookup"><span data-stu-id="1eab0-141">Integrate Cortana voice commands</span></span>

<span data-ttu-id="1eab0-142">html ページで音声コマンド定義 (VCD) ファイルを指定すると、Cortana 統合を利用できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-142">You can take advantage of Cortana integration by specifying a Voice Command Definition (VCD) file in your html page.</span></span> <span data-ttu-id="1eab0-143">VCD ファイルは、コマンドに特定の語句をマップする xml ファイルです。</span><span class="sxs-lookup"><span data-stu-id="1eab0-143">The VCD file is an xml file that maps commands to specific phrases.</span></span> <span data-ttu-id="1eab0-144">たとえば、[スタート] ボタンをタップし、「Contoso Books、ベスト セラーを表示」と発声すると、Contoso Books アプリを起動して、アプリ内の "ベスト セラー" ページに移動できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-144">For example, a user could tap the Start button and say “Contoso Books, show best sellers” to both launch the Contoso Books app and to navigate to a “best sellers” page.</span></span>

<span data-ttu-id="1eab0-145">VCD ファイルの場所の一覧を含む `<meta>` 要素タグを追加すると、Windows によって音声コマンド定義ファイルが自動的にダウンロードされ、登録されます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-145">When you add a `<meta>` element tag that lists the location of your VCD file, Windows automatically downloads and registers the Voice Command Definition file.</span></span>

<span data-ttu-id="1eab0-146">ホストされた Web アプリの html ページでの meta タグの使用例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-146">Here is an example of the use of the tag in an html page in a hosted web app:</span></span>

```HTML
<meta name="msapplication-cortanavcd" content="https:// contoso.com/vcd.xml"/>
```

<span data-ttu-id="1eab0-147">Cortana の統合と VCD について詳しくは、「Cortana の操作」と「音声コマンド定義 (VCD) の要素および属性 v1.2」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-147">For more info on Cortana integration and VCDs, see Cortana interactions and Voice Command Defintion (VCD) elements and attributes v1.2.</span></span>

## <a name="create-hybrid-apps--packaged-web-apps-vs-hosted-web-apps"></a><span data-ttu-id="1eab0-148">ハイブリッド アプリの作成: ページ Web アプリとホストされた Web アプリ</span><span class="sxs-lookup"><span data-stu-id="1eab0-148">Create Hybrid apps – Packaged web apps vs. Hosted web apps</span></span>

<span data-ttu-id="1eab0-149">UWP アプリを作成するためのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1eab0-149">You have options for creating your UWP app.</span></span> <span data-ttu-id="1eab0-150">アプリは、Windows ストアからダウンロードし、ローカル クライアントで完全にホストするように設計することができます (一般的に**パッケージ Web アプリ**と呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="1eab0-150">The app might be designed to be downloaded from the Windows Store and fully hosted on the local client; often referred to as a **Packaged Web App**.</span></span> <span data-ttu-id="1eab0-151">これにより、互換性のある任意のプラットフォームでアプリをオフラインで実行できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-151">This lets you run your app offline on any compatible platform.</span></span> <span data-ttu-id="1eab0-152">または、アプリはリモート Web サーバーで実行する完全にホストされた Web アプリ (一般的に**ホストされた Web アプリ**と呼ばれます) とすることができます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-152">Or the app might be a fully hosted web app that runs on a remote web server; typically known as a **Hosted Web App**.</span></span> <span data-ttu-id="1eab0-153">ただし、3 つ目のオプションもあります。アプリはローカル クライアントで部分的にホストされるか、リモート Web サーバーで部分的にホストできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-153">But there is also a third option: the app can be hosted partially on the local client and partially on a remote web server.</span></span> <span data-ttu-id="1eab0-154">この 3 つ目のオプションを**ハイブリッド アプリ**と呼び、通常 **WebView** コンポーネントを使って、リモート コンテンツをローカル コンテンツのように表示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-154">We call this third option a **Hybrid app** and it typically uses the **WebView** component to make remote content look like local content.</span></span> <span data-ttu-id="1eab0-155">ハイブリッド アプリ パッケージには、ローカル アプリ コンテンツ内のパッケージとして実行される HTML5、CSS、Javascript コードを格納し、リモート コンテンツを操作する機能を保持できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-155">Hybrid apps can include your HTML5, CSS, and Javascript code running as a package inside the local app client and retain the ability to interact with remote content.</span></span>

## <a name="web-authentication-broker"></a><span data-ttu-id="1eab0-156">Web 認証ブローカー</span><span class="sxs-lookup"><span data-stu-id="1eab0-156">Web authentication broker</span></span>

<span data-ttu-id="1eab0-157">インターネット認証と、OpenID や OAuth などの認証プロトコルを使用するオンライン ID プロバイダーがある場合は、Web 認証ブローカーを使って、ユーザーのログイン フローを処理できます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-157">You can use the web authentication broker to handle the login flow for your users if you have an online identity provider that uses internet authentication and authorization protocols like OpenID or OAuth.</span></span> <span data-ttu-id="1eab0-158">アプリの html ページ上の `<meta>` タグに、開始 URI と終了 URI を指定します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-158">You specify the start and end URIs in a `<meta>` tag on an html page in your app.</span></span> <span data-ttu-id="1eab0-159">これらの URI が Windows で検出され、Web 認証ブローカーに渡されて、ログイン フローが完了します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-159">Windows detects these URIs and passes them to the web authentication broker to complete the login flow.</span></span> <span data-ttu-id="1eab0-160">開始 URI は、オンライン プロバイダーに対する認証要求の送信先のアドレスと、必要なその他の情報 (アプリ ID、認証後にユーザーが転送されるリダイレクト URI、必要な応答の型など) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-160">The start URI consists of the address where you send the authentication request to your online provider appended with other required information, such as an app ID, a redirect URI where the user is sent after completing authentication, and the expected response type.</span></span> <span data-ttu-id="1eab0-161">必要なパラメーターについては、プロバイダーに確認してください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-161">You can find out from your provider what parameters are required.</span></span> <span data-ttu-id="1eab0-162">`<meta>` タグの使用例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-162">Here is an example use of the `<meta>` tag:</span></span>

```HTML
<meta name="ms-webauth-uris" content="https://<providerstartpoint>?client_id=<clientid>&response_type=token, https://<appendpoint>"/>
```

<span data-ttu-id="1eab0-163">詳しいガイダンスが必要な場合は、「[Web 認証ブローカーに関する考慮事項 (オンライン プロバイダー向け)](../security/web-authentication-broker.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-163">For more guidance, see [Web authentication broker considerations for online providers](../security/web-authentication-broker.md).</span></span>

## <a name="app-capability-declarations"></a><span data-ttu-id="1eab0-164">アプリ機能の宣言</span><span class="sxs-lookup"><span data-stu-id="1eab0-164">App capability declarations</span></span>

<span data-ttu-id="1eab0-165">アプリでユーザー リソース (ピクチャや音楽など) やデバイス (カメラやマイクなど) に対してプログラムによるアクセスが必要な場合は、適切な機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1eab0-165">If your app needs programmatic access to user resources like pictures or music, or to devices like a camera or a microphone, you must declare the appropriate capability.</span></span> <span data-ttu-id="1eab0-166">アプリ機能の宣言には次の 3 つのカテゴリがあります。</span><span class="sxs-lookup"><span data-stu-id="1eab0-166">There are three app capability declaration categories:</span></span> 

- <span data-ttu-id="1eab0-167">ストア アプリのほとんどのシナリオに適用される[一般的な用途の機能](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#general-use-capabilities)。</span><span class="sxs-lookup"><span data-stu-id="1eab0-167">[General-use capabilities](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#general-use-capabilities) that apply to most common app scenarios.</span></span> 
- <span data-ttu-id="1eab0-168">アプリが周辺機器と内部デバイスにアクセスできるようにする[デバイス機能](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#device-capabilities)。</span><span class="sxs-lookup"><span data-stu-id="1eab0-168">[Device capabilities](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#device-capabilities) that allow your app to access peripheral and internal devices.</span></span> 
- <span data-ttu-id="1eab0-169">ストアに提出して使用可能にするために特別な会社のアカウントが必要になる[特殊な用途の機能](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities)。</span><span class="sxs-lookup"><span data-stu-id="1eab0-169">[Special-use capabilities](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities) that require a special company account for submission to the Store to use them.</span></span> 

<span data-ttu-id="1eab0-170">会社のアカウントについて詳しくは、「[アカウントの種類、場所、料金](https://docs.microsoft.com/en-us/windows/uwp/publish/account-types-locations-and-fees)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-170">For more info about company accounts, see [Account types, locations, and fees](https://docs.microsoft.com/en-us/windows/uwp/publish/account-types-locations-and-fees).</span></span>

> [!NOTE]
> <span data-ttu-id="1eab0-171">ユーザーが Windows ストアからアプリを入手するときに、アプリで宣言されているすべての機能が通知されることを知っておくのは重要です。</span><span class="sxs-lookup"><span data-stu-id="1eab0-171">It is important to know that when customers get your app from the Windows Store, they are notified of all the capabilities that the app declares.</span></span> <span data-ttu-id="1eab0-172">そのため、アプリに不要な機能は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-172">So do not use capabilities that your app does not need.</span></span>

<span data-ttu-id="1eab0-173">アクセスを要求するには、アプリの[パッケージ マニフェスト](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest)で機能を宣言します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-173">You request access by declaring capabilities in your app’s [package manifest](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest).</span></span> <span data-ttu-id="1eab0-174">詳しくは、[ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化](https://docs.microsoft.com/en-us/windows/uwp/packaging/index)に関する記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-174">For more information, see these articles on [Packaging for Universal Windows Platform (UWP) apps](https://docs.microsoft.com/en-us/windows/uwp/packaging/index).</span></span>

<span data-ttu-id="1eab0-175">一部の機能では、アプリが機密性の高いリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-175">Some capabilities provide apps access to a sensitive resource.</span></span> <span data-ttu-id="1eab0-176">ユーザーの個人データにアクセスしたり、ユーザーに課金したりできるため、これらのリソースは機密性の高いリソースと見なされます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-176">These resources are considered sensitive because they can access the user’s personal data or cost the user money.</span></span> <span data-ttu-id="1eab0-177">設定アプリで管理されるプライバシー設定で、機密性の高いリソースへのアクセスを動的に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-177">Privacy settings, managed by the Settings app, let the user dynamically control access to sensitive resources.</span></span> <span data-ttu-id="1eab0-178">したがって、機密性の高いリソースが常に利用できるとアプリで認識されないことが重要です。</span><span class="sxs-lookup"><span data-stu-id="1eab0-178">Thus, it’s important that your app doesn’t assume a sensitive resource is always available.</span></span> <span data-ttu-id="1eab0-179">機密性の高いリソースへのアクセスについて詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-179">For more info about accessing sensitive resources, see [Guidelines for privacy-aware apps](https://msdn.microsoft.com/library/windows/apps/hh768223.aspx).</span></span>

## <a name="manifoldjs-and-the-app-manifest"></a><span data-ttu-id="1eab0-180">manifoldjs とアプリ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="1eab0-180">manifoldjs and the app manifest</span></span>

<span data-ttu-id="1eab0-181">Web サイトを UWP アプリに変換する簡単な方法は、**アプリ マニフェスト**と **manifoldjs** を使うことです。</span><span class="sxs-lookup"><span data-stu-id="1eab0-181">An easy way to turn your website into a UWP app is to use an **app manifest** and **manifoldjs**.</span></span> <span data-ttu-id="1eab0-182">アプリ マニフェストは、アプリに関するメタデータを格納する xml ファイルです。</span><span class="sxs-lookup"><span data-stu-id="1eab0-182">The app manifest is an xml file that contains metadata about the app.</span></span> <span data-ttu-id="1eab0-183">アプリ マニフェストでは、アプリの名前、リソースへのリンク、表示モード、URL など、アプリを展開し、実行する方法を説明するデータを指定します。</span><span class="sxs-lookup"><span data-stu-id="1eab0-183">It specifies such things as the app’s name, links to resources, display mode, URLs, and other data that describes how the app should be deployed and run.</span></span> <span data-ttu-id="1eab0-184">manifoldjs は、このプロセスを簡単にします。Web アプリをサポートしないシステムでも同様です。</span><span class="sxs-lookup"><span data-stu-id="1eab0-184">manifoldjs makes this process very easy, even on systems that do not support web apps.</span></span> <span data-ttu-id="1eab0-185">詳しくは、「[manifoldjs.com](http://www.manifoldjs.com/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1eab0-185">Please go to [manifoldjs.com](http://www.manifoldjs.com/) for more information on how it works.</span></span> <span data-ttu-id="1eab0-186">この [Windows 10 Web Apps プレゼンテーション](http://channel9.msdn.com/Events/WebPlatformSummit/2015/Hosted-web-apps-and-web-platform-innovations?wt.mc_id=relatedsession)の一部として、manifoldjs のデモを見ることもできます。</span><span class="sxs-lookup"><span data-stu-id="1eab0-186">You can also view a manifoldjs demonstration as part of this [Windows 10 Web Apps presentation](http://channel9.msdn.com/Events/WebPlatformSummit/2015/Hosted-web-apps-and-web-platform-innovations?wt.mc_id=relatedsession).</span></span>

## <a name="related-topics"></a><span data-ttu-id="1eab0-187">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1eab0-187">Related topics</span></span>
- [<span data-ttu-id="1eab0-188">Windows ランタイム API: JavaScript コード サンプル</span><span class="sxs-lookup"><span data-stu-id="1eab0-188">Windows Runtime API: JavaScript Code Samples</span></span>](https://microsoft.github.io/WindowsRuntimeAPIs_Javascript_snippets/)
- [<span data-ttu-id="1eab0-189">Codepen: Windows ランタイム API の呼び出しに使用するサンドボックス</span><span class="sxs-lookup"><span data-stu-id="1eab0-189">Codepen: sandbox to use for calling Windows Runtime APIs</span></span>](http://codepen.io/seksenov/pen/wBbVyb/)
- [<span data-ttu-id="1eab0-190">Cortana の操作</span><span class="sxs-lookup"><span data-stu-id="1eab0-190">Cortana interactions</span></span>](https://developer.microsoft.com/en-us/cortana)
- [<span data-ttu-id="1eab0-191">音声コマンド定義 (VCD) の要素および属性 v1.2</span><span class="sxs-lookup"><span data-stu-id="1eab0-191">Voice Command Definition (VCD) elements and attributes v1.2</span></span>](https://msdn.microsoft.com/library/windows/apps/dn954977.aspx)
- [<span data-ttu-id="1eab0-192">Web 認証ブローカーに関する考慮事項 (オンライン プロバイダー向け)</span><span class="sxs-lookup"><span data-stu-id="1eab0-192">Web authentication broker considerations for online providers</span></span>](https://docs.microsoft.com/en-us/windows/uwp/security/web-authentication-broker)
- [<span data-ttu-id="1eab0-193">アプリ機能の宣言 (Windows ストア アプリ)</span><span class="sxs-lookup"><span data-stu-id="1eab0-193">App capability declarations</span></span>](https://docs.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations)
