---
title: アプリの URI ハンドラーを使用して web サイト向けアプリを有効にします。
description: ユーザーを導くアプリと web サイトの機能のアプリをサポートします。
keywords: Windows でのディープ リンクの設定
ms.date: 08/25/2017
ms.topic: article
ms.assetid: 260cf387-88be-4a3d-93bc-7e4560f90abc
ms.localizationpriority: medium
ms.openlocfilehash: 66284538c97aee1a11c27beaa483dcfe109b6615
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7847914"
---
# <a name="enable-apps-for-websites-using-app-uri-handlers"></a><span data-ttu-id="197f9-104">アプリの URI ハンドラーを使用して web サイト向けアプリを有効にします。</span><span class="sxs-lookup"><span data-stu-id="197f9-104">Enable apps for websites using app URI handlers</span></span>

<span data-ttu-id="197f9-105">Web サイト用のアプリ、アプリと web サイトに関連付けるため、ブラウザーが開くのではなく、アプリが起動して web サイトへのリンクを開いたときです。</span><span class="sxs-lookup"><span data-stu-id="197f9-105">Apps for Websites associates your app with a website so that when someone opens a link to your website, your app is launched instead of opening the browser.</span></span> <span data-ttu-id="197f9-106">アプリがインストールされていない場合、web サイトは通常どおり、ブラウザーで開きます。</span><span class="sxs-lookup"><span data-stu-id="197f9-106">If your app is not installed, your website opens in the browser as usual.</span></span> <span data-ttu-id="197f9-107">検証済みのコンテンツ所有者だけがリンクに登録できるため、ユーザーはこのエクスペリエンスを信頼することができます。</span><span class="sxs-lookup"><span data-stu-id="197f9-107">Users can trust this experience because only verified content owners can register for a link.</span></span> <span data-ttu-id="197f9-108">ユーザーはすべて、登録されている web アプリへのリンクの設定に移動して確認することが > アプリ > web サイト用のアプリです。</span><span class="sxs-lookup"><span data-stu-id="197f9-108">Users will be able to check all of their registered web-to-app links by going to Settings > Apps > Apps for websites.</span></span>

<span data-ttu-id="197f9-109">Web とアプリのリンクを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="197f9-109">To enable web-to-app linking you will need to:</span></span>
- <span data-ttu-id="197f9-110">アプリが処理する URI をマニフェスト ファイル内に指定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-110">Identify the URIs your app will handle in the manifest file</span></span>
- <span data-ttu-id="197f9-111">アプリと web サイトの間の関連付けを定義する JSON ファイルです。</span><span class="sxs-lookup"><span data-stu-id="197f9-111">A JSON file that defines the association between your app and your website.</span></span> <span data-ttu-id="197f9-112">アプリと同じホストのルートに、アプリのパッケージ ファミリ名には、マニフェストの宣言をします。</span><span class="sxs-lookup"><span data-stu-id="197f9-112">with the app Package Family Name at the same host root as the app manifest declaration.</span></span>
- <span data-ttu-id="197f9-113">アプリでアクティブ化を処理します。</span><span class="sxs-lookup"><span data-stu-id="197f9-113">Handle the activation in the app.</span></span>

> [!Note]
> <span data-ttu-id="197f9-114">クリックしてされた Microsoft Edge でサポートされているリンクは、Windows 10 Creators update 以降では、対応するアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="197f9-114">Starting with the Windows 10 Creators update, supported links clicked in Microsoft Edge will launch the corresponding app.</span></span> <span data-ttu-id="197f9-115">サポートされているへのリンク (例: Internet Explorer など)、その他のブラウザーでクリックしてでは、閲覧エクスペリエンスで保持されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-115">Supported links clicked in other browsers (e.g. Internet Explorer, etc.), will keep you in the browsing experience.</span></span>

## <a name="register-to-handle-http-and-https-links-in-the-app-manifest"></a><span data-ttu-id="197f9-116">http リンクや https リンクを処理できるようにアプリ マニフェストに登録する</span><span class="sxs-lookup"><span data-stu-id="197f9-116">Register to handle http and https links in the app manifest</span></span>

<span data-ttu-id="197f9-117">アプリでは、処理する Web サイトの URI を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="197f9-117">Your app needs to identify the URIs for the websites it will handle.</span></span> <span data-ttu-id="197f9-118">そのためには、**Windows.appUriHandler** 拡張機能登録をアプリのマニフェスト ファイル **Package.appxmanifest** に追加します。</span><span class="sxs-lookup"><span data-stu-id="197f9-118">To do so, add the **Windows.appUriHandler** extension registration to your app’s manifest file **Package.appxmanifest**.</span></span>

<span data-ttu-id="197f9-119">たとえば、Web サイトのアドレスが “msn.com” である場合は、アプリのマニフェスト内に次のエントリを作成します。</span><span class="sxs-lookup"><span data-stu-id="197f9-119">For example, if your website’s address is “msn.com” you would make the following entry in your app’s manifest:</span></span>

```xml
<Applications>
  <Application ... >
      ...
      <Extensions>
         <uap3:Extension Category="windows.appUriHandler">
          <uap3:AppUriHandler>
            <uap3:Host Name="msn.com" />
          </uap3:AppUriHandler>
        </uap3:Extension>
      </Extensions>
  </Application>
</Applications>
```

<span data-ttu-id="197f9-120">上記の宣言によって、指定されたホストからのリンクを処理するようにアプリが登録されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-120">The declaration above registers your app to handle links from the specified host.</span></span> <span data-ttu-id="197f9-121">Web サイトに複数のアドレス (m.example.com、www.example.com、example.com など) がある場合は、各アドレスに対応するように、`<uap3:AppUriHandler>` 内に個別の `<uap3:Host Name=... />` エントリを追加します。</span><span class="sxs-lookup"><span data-stu-id="197f9-121">If your website has multiple addresses (for example: m.example.com, www.example.com, and example.com) then add a separate `<uap3:Host Name=... />` entry inside of the `<uap3:AppUriHandler>` for each address.</span></span>

## <a name="associate-your-app-and-website-with-a-json-file"></a><span data-ttu-id="197f9-122">アプリと Web サイトを JSON ファイルに関連付ける</span><span class="sxs-lookup"><span data-stu-id="197f9-122">Associate your app and website with a JSON file</span></span>

<span data-ttu-id="197f9-123">アプリで開くことができるのがお客様の Web サイトのコンテンツのみにする場合は、Web サーバーのルートまたはドメイン上の既知のディレクトリに配置されている JSON ファイル内に、アプリのパッケージ ファミリ名を指定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-123">To ensure that only your app can open content on your website, include your app's package family name in a JSON file located in the web server root, or at the well-known directory on the domain.</span></span> <span data-ttu-id="197f9-124">これにより、お客様の Web サイトは、指定されている一連のアプリがサイト上のコンテンツを開くことに同意したことになります。</span><span class="sxs-lookup"><span data-stu-id="197f9-124">This signifies that your website gives consent for the listed apps to open content on your site.</span></span> <span data-ttu-id="197f9-125">パッケージ ファミリ名は、アプリケーション マニフェスト デザイナーの [パッケージ] セクションで確認できます。</span><span class="sxs-lookup"><span data-stu-id="197f9-125">You can find the package family name in the Packages section in the app manifest designer.</span></span>

>[!Important]
> <span data-ttu-id="197f9-126">JSON ファイルには、.json ファイル接尾辞を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="197f9-126">The JSON file should not have a .json file suffix.</span></span>

<span data-ttu-id="197f9-127">**windows-app-web-link** という名前で JSON ファイルを作成し (.json ファイル拡張子は付加しない)、アプリのパッケージ ファミリ名を指定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-127">Create a JSON file (without the .json file extension) named **windows-app-web-link** and provide your app’s package family name.</span></span> <span data-ttu-id="197f9-128">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="197f9-128">For example:</span></span>

``` JSON
[{
  "packageFamilyName": "Your app's package family name, e.g MyApp_9jmtgj1pbbz6e",
  "paths": [ "*" ],
  "excludePaths" : [ "/news/*", "/blog/*" ]
 }]
```

<span data-ttu-id="197f9-129">Windows によって、Web サイトへの https 接続が行われ、Web サーバー上の対応する JSON ファイルが検索されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-129">Windows will make an https connection to your website and will look for the corresponding JSON file on your web server.</span></span>

### <a name="wildcards"></a><span data-ttu-id="197f9-130">ワイルドカード</span><span class="sxs-lookup"><span data-stu-id="197f9-130">Wildcards</span></span>

<span data-ttu-id="197f9-131">上記の JSON ファイルの例では、ワイルドカードの使用も示しています。</span><span class="sxs-lookup"><span data-stu-id="197f9-131">The JSON file example above demonstrates the use of wildcards.</span></span> <span data-ttu-id="197f9-132">ワイルドカードを使用すると、数行のコードでさまざまなリンクをサポートすることができます。</span><span class="sxs-lookup"><span data-stu-id="197f9-132">Wildcards allow you to support a wide variety of links with fewer lines of code.</span></span> <span data-ttu-id="197f9-133">Web とアプリのリンクでは、JSON ファイルで 2 種類のワイルドカードを使用できます。</span><span class="sxs-lookup"><span data-stu-id="197f9-133">Web-to-app linking supports two types of wildcards in the JSON file:</span></span>

| **<span data-ttu-id="197f9-134">ワイルドカード</span><span class="sxs-lookup"><span data-stu-id="197f9-134">Wildcard</span></span>** | **<span data-ttu-id="197f9-135">説明</span><span class="sxs-lookup"><span data-stu-id="197f9-135">Description</span></span>**               |
|--------------|-------------------------------|
| **\***       | <span data-ttu-id="197f9-136">任意の部分文字列を表します</span><span class="sxs-lookup"><span data-stu-id="197f9-136">Represents any substring</span></span>      |
| **<span data-ttu-id="197f9-137">?</span><span class="sxs-lookup"><span data-stu-id="197f9-137">?</span></span>**        | <span data-ttu-id="197f9-138">1 つの文字を表します</span><span class="sxs-lookup"><span data-stu-id="197f9-138">Represents a single character</span></span> |

<span data-ttu-id="197f9-139">たとえば、`"excludePaths" : [ "/news/*", "/blog/*" ]`上記の例では、アプリが下にあるもの**を除き**web サイトのアドレス (例: msn.com) で始まるすべてのパスをサポート`/news/`と`/blog/`します。</span><span class="sxs-lookup"><span data-stu-id="197f9-139">For example, given `"excludePaths" : [ "/news/*", "/blog/*" ]` in the example above, your app will support all paths that start with your website’s address (e.g. msn.com), **except** those under `/news/` and `/blog/`.</span></span> <span data-ttu-id="197f9-140">つまり、**msn.com/weather.html** はサポートされますが、\*\*\*\*msn.com/news/topnews.html\*\*\*\* はサポートされません。</span><span class="sxs-lookup"><span data-stu-id="197f9-140">**msn.com/weather.html** will be supported, but not \*\*\*\*msn.com/news/topnews.html\*\*\*\*.</span></span>

### <a name="multiple-apps"></a><span data-ttu-id="197f9-141">複数のアプリ</span><span class="sxs-lookup"><span data-stu-id="197f9-141">Multiple apps</span></span>

<span data-ttu-id="197f9-142">Web サイトにリンクするアプリが 2 つある場合、両方のアプリケーションのパッケージ ファミリ名を **windows-app-web-link** JSON ファイルに指定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-142">If you have two apps that you would like to link to your website, list both of the application package family names in your **windows-app-web-link** JSON file.</span></span> <span data-ttu-id="197f9-143">これで、どちらのアプリもサポートされます。</span><span class="sxs-lookup"><span data-stu-id="197f9-143">Both apps can be supported.</span></span> <span data-ttu-id="197f9-144">両方のアプリがインストールされている場合、ユーザーに対して、どちらを既定のリンクとして選ぶかが示されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-144">The user will be presented with a choice of which is the default link if both are installed.</span></span> <span data-ttu-id="197f9-145">既定のリンクを後で変更する場合は、**[設定] > [Web サイト用のアプリ]** で変更できます。</span><span class="sxs-lookup"><span data-stu-id="197f9-145">If they want to change the default link later, they can change it in **Settings > Apps for Websites**.</span></span> <span data-ttu-id="197f9-146">また、開発者はいつでも JSON ファイルを変更できます。変更内容は、変更と同日内になるべく早く確認するか、更新後 8 日以内に確認してください。</span><span class="sxs-lookup"><span data-stu-id="197f9-146">Developers can also change the JSON file at any time and see the change as early as the same day but no later than eight days after the update.</span></span>

``` JSON
[{
  "packageFamilyName": "Your apps's package family name, e.g MyApp_9jmtgj1pbbz6e",
  "paths": [ "*" ],
  "excludePaths" : [ "/news/*", "/blog/*" ]
 },
 {
  "packageFamilyName": "Your second app's package family name, e.g. MyApp2_8jmtgj2pbbz6e",
  "paths": [ "/example/*", "/links/*" ]
 }]
```

<span data-ttu-id="197f9-147">ユーザーに最適なエクスペリエンスを提供するには、JSON ファイル内のサポート対象のパスからオンラインのみのコンテンツが除外されるように、除外パスを使用してください。</span><span class="sxs-lookup"><span data-stu-id="197f9-147">To provide the best experience for your users, use exclude paths to make sure that online-only content is excluded from the supported paths in your JSON file.</span></span>

<span data-ttu-id="197f9-148">最初に除外パスが確認され、除外パスが一致すると、そのパスに対応するページは、指定されたアプリではなくブラウザーで開かれます。</span><span class="sxs-lookup"><span data-stu-id="197f9-148">Exclude paths are checked first and if there is a match the corresponding page will be opened with the browser instead of the designated app.</span></span> <span data-ttu-id="197f9-149">上記の例では、‘/news/\*’ と指定すると、そのパスの下にあるすべてのページが対象となりますが、‘/news\*’ ('news' の後にスラッシュを付けない) と指定すると、‘news\*’ で始まるパス (‘newslocal/’、‘newsinternational/’ など) の下にあるすべてのパスが対象となります。</span><span class="sxs-lookup"><span data-stu-id="197f9-149">In the example above, ‘/news/\*’ includes any pages under that path while ‘/news\*’ (no forward slash trails 'news') includes any paths under ‘news\*’ such as ‘newslocal/’, ‘newsinternational/’, and so on.</span></span>

## <a name="handle-links-on-activation-to-link-to-content"></a><span data-ttu-id="197f9-150">コンテンツにリンクするためのアクティブ化でリンクを処理する</span><span class="sxs-lookup"><span data-stu-id="197f9-150">Handle links on Activation to link to content</span></span>

<span data-ttu-id="197f9-151">アプリの Visual Studio ソリューションで **App.xaml.cs** に移動し、**OnActivated()** に、リンクされたコンテンツの処理を追加します。</span><span class="sxs-lookup"><span data-stu-id="197f9-151">Navigate to **App.xaml.cs** in your app’s Visual Studio solution and in **OnActivated()** add handling for linked content.</span></span> <span data-ttu-id="197f9-152">次の例では、アプリで開かれるページは URI パスによって異なります。</span><span class="sxs-lookup"><span data-stu-id="197f9-152">In the following example, the page that is opened in the app depends on the URI path:</span></span>

``` CS
protected override void OnActivated(IActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame == null)
    {
        ...
    }

    // Check ActivationKind, Parse URI, and Navigate user to content
    Type deepLinkPageType = typeof(MainPage);
    if (e.Kind == ActivationKind.Protocol)
    {
        var protocolArgs = (ProtocolActivatedEventArgs)e;        
        switch (protocolArgs.Uri.AbsolutePath)
        {
            case "/":
                break;
            case "/index.html":
                break;
            case "/sports.html":
                deepLinkPageType = typeof(SportsPage);
                break;
            case "/technology.html":
                deepLinkPageType = typeof(TechnologyPage);
                break;
            case "/business.html":
                deepLinkPageType = typeof(BusinessPage);
                break;
            case "/science.html":
                deepLinkPageType = typeof(SciencePage);
                break;
        }
    }

    if (rootFrame.Content == null)
    {
        // Default navigation
        rootFrame.Navigate(deepLinkPageType, e);
    }

    // Ensure the current window is active
    Window.Current.Activate();
}
```

<span data-ttu-id="197f9-153">**重要** 上記の例で示したように、最後の `if (rootFrame.Content == null)` ロジックは `rootFrame.Navigate(deepLinkPageType, e);` に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="197f9-153">**Important** Make sure to replace the final `if (rootFrame.Content == null)` logic with `rootFrame.Navigate(deepLinkPageType, e);` as shown in the example above.</span></span>

## <a name="test-it-out-local-validation-tool"></a><span data-ttu-id="197f9-154">テストの実行: ローカルの検証ツール</span><span class="sxs-lookup"><span data-stu-id="197f9-154">Test it out: Local validation tool</span></span>

<span data-ttu-id="197f9-155">アプリ ホスト登録検証ツールを実行して、アプリと Web サイトの構成をテストできます。このツールは次の場所にあります。</span><span class="sxs-lookup"><span data-stu-id="197f9-155">You can test the configuration of your app and website by running the App host registration verifier tool which is available in:</span></span>

<span data-ttu-id="197f9-156">%windir%\\system32\\**AppHostRegistrationVerifier.exe**</span><span class="sxs-lookup"><span data-stu-id="197f9-156">%windir%\\system32\\**AppHostRegistrationVerifier.exe**</span></span>

<span data-ttu-id="197f9-157">次のパラメーターを使用してこのツールを実行し、アプリと Web サイトの構成をテストしてください。</span><span class="sxs-lookup"><span data-stu-id="197f9-157">Test the configuration of your app and website by running this tool with the following parameters:</span></span>

<span data-ttu-id="197f9-158">**AppHostRegistrationVerifier.exe** *hostname packagefamilyname filepath*</span><span class="sxs-lookup"><span data-stu-id="197f9-158">**AppHostRegistrationVerifier.exe** *hostname packagefamilyname filepath*</span></span>

-   <span data-ttu-id="197f9-159">ホスト名: Web サイト (microsoft.com など)</span><span class="sxs-lookup"><span data-stu-id="197f9-159">Hostname: Your website (e.g. microsoft.com)</span></span>
-   <span data-ttu-id="197f9-160">パッケージ ファミリ名 (PFN): アプリの PFN</span><span class="sxs-lookup"><span data-stu-id="197f9-160">Package Family Name (PFN): Your app’s PFN</span></span>
-   <span data-ttu-id="197f9-161">ファイル パス: ローカルな検証のための JSON ファイル (C:\\SomeFolder\\windows-app-web-link など)</span><span class="sxs-lookup"><span data-stu-id="197f9-161">File path: The JSON file for local validation (e.g. C:\\SomeFolder\\windows-app-web-link)</span></span>

<span data-ttu-id="197f9-162">場合は、ツールは何も返さない、そのファイルをアップロードするときの検証が動作します。</span><span class="sxs-lookup"><span data-stu-id="197f9-162">If the tool does not return anything, validation will work on that file when uploaded.</span></span> <span data-ttu-id="197f9-163">エラー コードがある場合は機能しません。</span><span class="sxs-lookup"><span data-stu-id="197f9-163">If there is an error code, it will not work.</span></span>

<span data-ttu-id="197f9-164">ローカルの検証の一部としてサイドロード アプリの対応付けのパスを強制する次のレジストリ キーを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="197f9-164">You can enable the following registry key to force path matching for side-loaded apps as part of local validation:</span></span>

`HKCU\Software\Classes\LocalSettings\Software\Microsoft\Windows\CurrentVersion\
AppModel\SystemAppData\YourApp\AppUriHandlers`

<span data-ttu-id="197f9-165">キー名:`ForceValidation`値。</span><span class="sxs-lookup"><span data-stu-id="197f9-165">Keyname: `ForceValidation` Value:</span></span> `1`

## <a name="test-it-web-validation"></a><span data-ttu-id="197f9-166">テストの実行: Web 検証</span><span class="sxs-lookup"><span data-stu-id="197f9-166">Test it: Web validation</span></span>

<span data-ttu-id="197f9-167">リンクをクリックしたときにアプリがアクティブ化されるかどうか確認するには、アプリケーションを閉じておきます。</span><span class="sxs-lookup"><span data-stu-id="197f9-167">Close your application to verify that the app is activated when you click a link.</span></span> <span data-ttu-id="197f9-168">次に、Web サイトでサポートされるパスのいずれかのアドレスをコピーします。</span><span class="sxs-lookup"><span data-stu-id="197f9-168">Then, copy the address of one of the supported paths in your website.</span></span> <span data-ttu-id="197f9-169">たとえば、Web サイトのアドレスが “msn.com” であり、サポートされるパスの 1 つが “path1” である場合、アドレスは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="197f9-169">For example, if your website’s address is “msn.com”, and one of the support paths is “path1”, you would use</span></span> `http://msn.com/path1`

<span data-ttu-id="197f9-170">アプリが閉じていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="197f9-170">Verify that your app is closed.</span></span> <span data-ttu-id="197f9-171">**Windows キー + R** キーを押し、**[ファイル名を指定して実行]** ダイアログ ボックスを開き、ウィンドウにリンクを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="197f9-171">Press **Windows Key + R** to open the **Run** dialog box and paste the link in the window.</span></span> <span data-ttu-id="197f9-172">Web ブラウザーではなく、アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="197f9-172">Your app should launch instead of the web browser.</span></span>

<span data-ttu-id="197f9-173">また、[LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) API を使用し、他のアプリから目的のアプリを起動してテストすることもできます。</span><span class="sxs-lookup"><span data-stu-id="197f9-173">Additionally, you can test your app by launching it from another app using the [LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) API.</span></span> <span data-ttu-id="197f9-174">この API を使用して、電話でテストすることもできます。</span><span class="sxs-lookup"><span data-stu-id="197f9-174">You can use this API to test on phones as well.</span></span>

<span data-ttu-id="197f9-175">プロトコルのアクティブ化ロジックを実行する場合は、**OnActivated** イベント ハンドラーにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-175">If you would like to follow the protocol activation logic, set a breakpoint in the **OnActivated** event handler.</span></span>

## <a name="appurihandlers-tips"></a><span data-ttu-id="197f9-176">AppUriHandlers のヒント:</span><span class="sxs-lookup"><span data-stu-id="197f9-176">AppUriHandlers tips:</span></span>

- <span data-ttu-id="197f9-177">アプリで処理できるリンクのみを必ず指定してください。</span><span class="sxs-lookup"><span data-stu-id="197f9-177">Make sure to only specify links that your app can handle.</span></span>
- <span data-ttu-id="197f9-178">サポートするすべてのホストの一覧を指定します。</span><span class="sxs-lookup"><span data-stu-id="197f9-178">List all of the hosts that you will support.</span></span>  <span data-ttu-id="197f9-179">www.example.com と example.com は、異なるホストになります。</span><span class="sxs-lookup"><span data-stu-id="197f9-179">Note that www.example.com and example.com are different hosts.</span></span>
- <span data-ttu-id="197f9-180">ユーザーは、Web サイトを処理する特定のアプリを [設定] で選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="197f9-180">Users can choose which app they prefer to handle websites in Settings.</span></span>
- <span data-ttu-id="197f9-181">JSON ファイルは、https サーバーにアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="197f9-181">Your JSON file must be uploaded to an https server.</span></span>
- <span data-ttu-id="197f9-182">サポートするパスを変更する場合は、アプリを再公開しなくても、JSON ファイルを再公開することができます。</span><span class="sxs-lookup"><span data-stu-id="197f9-182">If you need to change the paths that you wish to support, you can republish your JSON file without republishing your app.</span></span> <span data-ttu-id="197f9-183">ユーザーには、1 ~ 8 日の間、変更内容が表示されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-183">Users will see the changes in 1-8 days.</span></span>
- <span data-ttu-id="197f9-184">AppUriHandlers と共にサイドロードされたすべてのアプリでは、インストール時にホストのリンクが検証されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-184">All sideloaded apps with AppUriHandlers will have validated links for the host on install.</span></span> <span data-ttu-id="197f9-185">機能をテストするために JSON ファイルをアップロードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="197f9-185">You do not need to have a JSON file uploaded to test the feature.</span></span>
- <span data-ttu-id="197f9-186">この機能は、アプリが [LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) によって起動された UWP アプリである場合、または [ShellExecuteEx](https://msdn.microsoft.com/library/windows/desktop/bb762154(v=vs.85).aspx) によって起動された Windows デスクトップ アプリである場合は、必ず動作します。</span><span class="sxs-lookup"><span data-stu-id="197f9-186">This feature works whenever your app is a UWP app launched with  [LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) or a Windows desktop app launched with  [ShellExecuteEx](https://msdn.microsoft.com/library/windows/desktop/bb762154(v=vs.85).aspx).</span></span> <span data-ttu-id="197f9-187">URL が、登録されているアプリの URI ハンドラーに対応している場合、ブラウザーではなくアプリが起動されます。</span><span class="sxs-lookup"><span data-stu-id="197f9-187">If the URL corresponds to a registered App URI handler, the app will be launched instead of the browser.</span></span>

## <a name="see-also"></a><span data-ttu-id="197f9-188">関連項目</span><span class="sxs-lookup"><span data-stu-id="197f9-188">See also</span></span>

<span data-ttu-id="197f9-189">[Web とアプリのサンプル プロジェクト](https://github.com/project-rome/AppUriHandlers/tree/master/NarwhalFacts)
[windows.protocol の登録](https://msdn.microsoft.com/library/windows/apps/br211458.aspx)
[URI のアクティブ化を処理する](https://msdn.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)
[関連付けを起動するサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AssociationLaunching)では、LaunchUriAsync() API を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="197f9-189">[Web-to-App example project](https://github.com/project-rome/AppUriHandlers/tree/master/NarwhalFacts)
[windows.protocol registration](https://msdn.microsoft.com/library/windows/apps/br211458.aspx)
[Handle URI Activation](https://msdn.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)
[Association Launching sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AssociationLaunching) illustrates how to use the LaunchUriAsync() API.</span></span>
