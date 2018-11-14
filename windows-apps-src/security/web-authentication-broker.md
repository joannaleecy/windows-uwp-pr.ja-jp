---
title: Web 認証ブローカー
description: この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にユニバーサル Windows プラットフォーム (UWP) アプリを接続する方法について説明します。
ms.assetid: 05F06961-1768-44A7-B185-BCDB74488F85
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 88210182f46fa8149e4b2d0278d7df89033e62b6
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6667002"
---
# <a name="web-authentication-broker"></a><span data-ttu-id="3882f-104">Web 認証ブローカー</span><span class="sxs-lookup"><span data-stu-id="3882f-104">Web authentication broker</span></span>




<span data-ttu-id="3882f-105">この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にユニバーサル Windows プラットフォーム (UWP) アプリを接続する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3882f-105">This article explains how to connect your Universal Windows Platform (UWP) app to an online identity provider that uses authentication protocols like OpenID or OAuth, such as Facebook, Twitter, Flickr, Instagram, and so on.</span></span> <span data-ttu-id="3882f-106">[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドは、要求をオンライン ID プロバイダーに送信し、アプリがアクセスできるプロバイダー リソースを示すアクセス トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="3882f-106">The [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) method sends a request to the online identity provider and gets back an access token that describes the provider resources to which the app has access.</span></span>

>[!NOTE]
><span data-ttu-id="3882f-107">動作する完全なコード例が必要な場合は、[GitHub の WebAuthenticationBroker リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=620622)をコピーしてください。</span><span class="sxs-lookup"><span data-stu-id="3882f-107">For a complete, working code sample, clone the [WebAuthenticationBroker repo on GitHub](http://go.microsoft.com/fwlink/p/?LinkId=620622).</span></span>

 

## <a name="register-your-app-with-your-online-provider"></a><span data-ttu-id="3882f-108">アプリのオンライン プロバイダーへの登録</span><span class="sxs-lookup"><span data-stu-id="3882f-108">Register your app with your online provider</span></span>


<span data-ttu-id="3882f-109">アプリを接続先のオンライン ID プロバイダーに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3882f-109">You must register your app with the online identity provider to which you want to connect.</span></span> <span data-ttu-id="3882f-110">アプリを登録する方法については、ID プロバイダーに確認してください。</span><span class="sxs-lookup"><span data-stu-id="3882f-110">You can find out how to register your app from the identity provider.</span></span> <span data-ttu-id="3882f-111">通常、登録すると、オンライン プロバイダーからアプリの ID や秘密鍵が提供されます。</span><span class="sxs-lookup"><span data-stu-id="3882f-111">After registering, the online provider typically gives you an Id or secret key for your app.</span></span>

## <a name="build-the-authentication-request-uri"></a><span data-ttu-id="3882f-112">認証要求の URI の作成</span><span class="sxs-lookup"><span data-stu-id="3882f-112">Build the authentication request URI</span></span>


<span data-ttu-id="3882f-113">要求の URI は、オンライン プロバイダーに対する認証要求の送信先のアドレスと、必要なその他の情報 (アプリ ID またはシークレット、認証後にユーザーが転送されるリダイレクト URI、必要な応答の型など) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="3882f-113">The request URI consists of the address where you send the authentication request to your online provider appended with other required information, such as an app ID or secret, a redirect URI where the user is sent after completing authentication, and the expected response type.</span></span> <span data-ttu-id="3882f-114">必要なパラメーターについては、プロバイダーに確認してください。</span><span class="sxs-lookup"><span data-stu-id="3882f-114">You can find out from your provider what parameters are required.</span></span>

<span data-ttu-id="3882f-115">要求の URI は、[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドの *requestUri* パラメーターとして送信されます。</span><span class="sxs-lookup"><span data-stu-id="3882f-115">The request URI is sent as the *requestUri* parameter of the [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) method.</span></span> <span data-ttu-id="3882f-116">また、セキュリティで保護されたアドレスである (`https://` で始まる) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="3882f-116">It must be a secure address (it must start with `https://`)</span></span>

<span data-ttu-id="3882f-117">次の例は、要求の URI を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3882f-117">The following example shows how to build the request URI.</span></span>

```cs
string startURL = "https://<providerendpoint>?client_id=<clientid>&scope=<scopes>&response_type=token";
string endURL = "http://<appendpoint>";

System.Uri startURI = new System.Uri(startURL);
System.Uri endURI = new System.Uri(endURL);
```

## <a name="connect-to-the-online-provider"></a><span data-ttu-id="3882f-118">オンライン プロバイダーへの接続</span><span class="sxs-lookup"><span data-stu-id="3882f-118">Connect to the online provider</span></span>


<span data-ttu-id="3882f-119">[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドを呼び出してオンライン ID プロバイダーに接続し、アクセス トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="3882f-119">You call the [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) method to connect to the online identity provider and get an access token.</span></span> <span data-ttu-id="3882f-120">このメソッドは、前の手順で作った URI を *requestUri* パラメーターとして受け取り、ユーザーのリダイレクト先の URI を *callbackUri* パラメーターとして受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3882f-120">The method takes the URI constructed in the previous step as the *requestUri* parameter, and a URI to which you want the user to be redirected as the *callbackUri* parameter.</span></span>

```cs
string result;

try
{
    var webAuthenticationResult = 
        await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync( 
        Windows.Security.Authentication.Web.WebAuthenticationOptions.None, 
        startURI, 
        endURI);

    switch (webAuthenticationResult.ResponseStatus)
    {
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
            // Successful authentication. 
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
            // HTTP error. 
            result = webAuthenticationResult.ResponseErrorDetail.ToString(); 
            break;
        default:
            // Other error.
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
    } 
}
catch (Exception ex)
{
    // Authentication failed. Handle parameter, SSL/TLS, and Network Unavailable errors here. 
    result = ex.Message;
}
```

>[!WARNING]
><span data-ttu-id="3882f-121">[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) に加え、[**Windows.Security.Authentication.Web**](https://msdn.microsoft.com/library/windows/apps/br227044) 名前空間には [**AuthenticateAndContinue**](https://msdn.microsoft.com/library/windows/apps/dn632425) メソッドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3882f-121">In addition to [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066), the [**Windows.Security.Authentication.Web**](https://msdn.microsoft.com/library/windows/apps/br227044) namespace contains an [**AuthenticateAndContinue**](https://msdn.microsoft.com/library/windows/apps/dn632425) method.</span></span> <span data-ttu-id="3882f-122">このメソッドは呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="3882f-122">Do not call this method.</span></span> <span data-ttu-id="3882f-123">Windows Phone 8.1 のみをターゲットとするアプリのように設計され、windows 10 以降は推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="3882f-123">It is designed for apps targeting Windows Phone 8.1 only and is deprecated starting with Windows10.</span></span>

## <a name="connecting-with-single-sign-on-sso"></a><span data-ttu-id="3882f-124">シングル サインオン (SSO) を使った接続</span><span class="sxs-lookup"><span data-stu-id="3882f-124">Connecting with single sign-on (SSO).</span></span>


<span data-ttu-id="3882f-125">既定では、Web 認証ブローカーは Cookie の保存を許可していません。</span><span class="sxs-lookup"><span data-stu-id="3882f-125">By default, Web authentication broker does not allow cookies to persist.</span></span> <span data-ttu-id="3882f-126">そのため、アプリ ユーザーは (たとえば、プロバイダーのログイン ダイアログのチェック ボックスをオンにして) ログオン状態を維持することを示した場合でも、そのプロバイダーのリソースにアクセスするたびにログインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3882f-126">Because of this, even if the app user indicates that they want to stay logged in (for example, by selecting a check box in the provider's login dialog), they will have to login each time they want to access resources for that provider.</span></span> <span data-ttu-id="3882f-127">SSO を使ってログインするには、オンライン ID プロバイダーが Web 認証ブローカーに対して SSO を有効にしており、\*callbackUri \* パラメーターを受け取らない [\*\*AuthenticateAsync \*\*](https://msdn.microsoft.com/library/windows/apps/br212068) のオーバーロードをアプリで呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="3882f-127">To login with SSO, your online identity provider must have enabled SSO for Web authentication broker, and your app must call the overload of [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212068) that does not take a *callbackUri* parameter.</span></span> <span data-ttu-id="3882f-128">これで Web 認証ブローカーが永続 cookie を保存でき、これ以降に同じアプリから認証を求められたときに、ユーザーは再びサインインを行う必要がありません (アクセス トークンの期限が切れるまで、ユーザーは実質的に "ログイン" した状態になります)。</span><span class="sxs-lookup"><span data-stu-id="3882f-128">This will allow persisted cookies to be stored by the web authentication broker, so that future authentication calls by the same app will not require repeated sign-in by the user (the user is effectively "logged in" until the access token expires).</span></span>

<span data-ttu-id="3882f-129">SSO をサポートするには、オンライン プロバイダーが `ms-app://<appSID>` という形式のリダイレクト URI の登録を許可している必要があります。`<appSID>` は、アプリの SID です。</span><span class="sxs-lookup"><span data-stu-id="3882f-129">To support SSO, the online provider must allow you to register a redirect URI in the form `ms-app://<appSID>`, where `<appSID>` is the SID for your app.</span></span> <span data-ttu-id="3882f-130">アプリの SID は、アプリ開発者のページか、[**GetCurrentApplicationCallbackUri**](https://msdn.microsoft.com/library/windows/apps/br212069) メソッドを呼び出すことで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3882f-130">You can find your app's SID from the app developer page for your app, or by calling the [**GetCurrentApplicationCallbackUri**](https://msdn.microsoft.com/library/windows/apps/br212069) method.</span></span>

```cs
string result;

try
{
    var webAuthenticationResult = 
        await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync( 
        Windows.Security.Authentication.Web.WebAuthenticationOptions.None, 
        startURI);

    switch (webAuthenticationResult.ResponseStatus)
    {
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
            // Successful authentication. 
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
            // HTTP error. 
            result = webAuthenticationResult.ResponseErrorDetail.ToString(); 
            break;
        default:
            // Other error.
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
    } 
}
catch (Exception ex)
{
    // Authentication failed. Handle parameter, SSL/TLS, and Network Unavailable errors here. 
    result = ex.Message;
}
```

## <a name="debugging"></a><span data-ttu-id="3882f-131">デバッグ</span><span class="sxs-lookup"><span data-stu-id="3882f-131">Debugging</span></span>


<span data-ttu-id="3882f-132">Web 認証ブローカー API のトラブルシューティングには、操作ログの確認や Fiddler を使った Web 要求と応答の確認など、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="3882f-132">There are several ways to troubleshoot the web authentication broker APIs, including reviewing operational logs and reviewing web requests and responses using Fiddler.</span></span>

### <a name="operational-logs"></a><span data-ttu-id="3882f-133">操作ログ</span><span class="sxs-lookup"><span data-stu-id="3882f-133">Operational logs</span></span>

<span data-ttu-id="3882f-134">問題の原因の多くは、操作ログを使って特定できます。</span><span class="sxs-lookup"><span data-stu-id="3882f-134">Often you can determine what is not working by using the operational logs.</span></span> <span data-ttu-id="3882f-135">Web サイト開発者向けの専用のイベント ログ チャネルである Microsoft-Windows-WebAuth\\Operational を使うと、Web 認証ブローカーで Web ページが処理される過程を把握できます。</span><span class="sxs-lookup"><span data-stu-id="3882f-135">There is a dedicated event log channel Microsoft-Windows-WebAuth\\Operational that allows website developers to understand how their web pages are being processed by the Web authentication broker.</span></span> <span data-ttu-id="3882f-136">これを有効にするには、eventvwr.exe を起動し、アプリケーションとサービス ログvices\\Microsoft\\Windows\\WebAuth で操作ログを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3882f-136">To enable it, launch eventvwr.exe and enable Operational log under the Application and Services\\Microsoft\\Windows\\WebAuth.</span></span> <span data-ttu-id="3882f-137">また、Web 認証ブローカーは Web サーバー上で自身を識別するために、ユーザー エージェント文字列に一意の文字列を追加します。</span><span class="sxs-lookup"><span data-stu-id="3882f-137">Also, the Web authentication broker appends a unique string to the user agent string to identify itself on the web server.</span></span> <span data-ttu-id="3882f-138">その文字列は、"MSAuthHost/1.0" です。</span><span class="sxs-lookup"><span data-stu-id="3882f-138">The string is "MSAuthHost/1.0".</span></span> <span data-ttu-id="3882f-139">バージョン番号は今後変更される可能性があるため、コード内のそれに依存しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3882f-139">Note that the version number may change in the future, so you should not to depend on that version number in your code.</span></span> <span data-ttu-id="3882f-140">ユーザー エージェント文字列全体の例とデバッグの全ステップは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3882f-140">An example of the full user agent string, followed by full debugging steps, is as follows.</span></span>

`User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0; MSAuthHost/1.0)`

1.  <span data-ttu-id="3882f-141">操作ログを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3882f-141">Enable operational logs.</span></span>
2.  <span data-ttu-id="3882f-142">Contoso ソーシャル アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="3882f-142">Run Contoso social application.</span></span> ![WebAuth 操作ログが表示されたイベント ビューアー](images/wab-event-viewer-1.png)
3.  <span data-ttu-id="3882f-144">生成されたログ エントリで、Web 認証ブローカーの動作を把握することができます。</span><span class="sxs-lookup"><span data-stu-id="3882f-144">The generated logs entries can be used to understand the behavior of Web authentication broker in greater detail.</span></span> <span data-ttu-id="3882f-145">この例では、次の情報を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="3882f-145">In this case, these can include:</span></span>
    -   <span data-ttu-id="3882f-146">ナビゲーションの開始: AuthHost が開始された時点のログ。開始 URL と終了 URL に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3882f-146">Navigation Start: Logs when the AuthHost is started and contains information about the start and termination URLs.</span></span>
    -   ![ナビゲーションの開始の例](images/wab-event-viewer-2.png)
    -   <span data-ttu-id="3882f-148">ナビゲーションの完了: Web ページの読み込み完了時のログ。</span><span class="sxs-lookup"><span data-stu-id="3882f-148">Navigation Complete: Logs the completion of loading a web page.</span></span>
    -   <span data-ttu-id="3882f-149">メタ タグ: メタ タグが検出されたときのログ。詳しい情報を含みます。</span><span class="sxs-lookup"><span data-stu-id="3882f-149">Meta Tag: Logs when a meta-tag is encountered including the details.</span></span>
    -   <span data-ttu-id="3882f-150">ナビゲーションの停止: ユーザーによって停止されたナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="3882f-150">Navigation Terminate: Navigation terminated by the user.</span></span>
    -   <span data-ttu-id="3882f-151">ナビゲーション エラー: AuthHost が HttpStatusCode を含む URL でナビゲーション エラーを検出。</span><span class="sxs-lookup"><span data-stu-id="3882f-151">Navigation Error: AuthHost encounters a navigation error at a URL including HttpStatusCode.</span></span>
    -   <span data-ttu-id="3882f-152">ナビゲーションの終了: 終了 URL を検出。</span><span class="sxs-lookup"><span data-stu-id="3882f-152">Navigation End: Terminating URL is encountered.</span></span>

### <a name="fiddler"></a><span data-ttu-id="3882f-153">Fiddler</span><span class="sxs-lookup"><span data-stu-id="3882f-153">Fiddler</span></span>

<span data-ttu-id="3882f-154">Fiddler Web デバッガーはアプリに対して使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3882f-154">The Fiddler web debugger can be used with apps.</span></span>

1.  <span data-ttu-id="3882f-155">独自のアプリ コンテナー内であるため、AuthHost が実行されるとので、プライベート ネットワーク機能を提供する必要があります設定するレジストリ キー: Windows レジストリ エディター Version 5.00 という</span><span class="sxs-lookup"><span data-stu-id="3882f-155">Since the AuthHost runs in its own app container, to give it the private network capability you must set a registry key: Windows Registry Editor Version 5.00</span></span>

    <span data-ttu-id="3882f-156">**HKEY\_LOCAL\_MACHINE**\\**SOFTWARE**\\**Microsoft**\\**Windows NT**\\**CurrentVersion**\\**Image File Execution Options**\\**authhost.exe**\\**EnablePrivateNetwork** = 00000001</span><span class="sxs-lookup"><span data-stu-id="3882f-156">**HKEY\_LOCAL\_MACHINE**\\**SOFTWARE**\\**Microsoft**\\**Windows NT**\\**CurrentVersion**\\**Image File Execution Options**\\**authhost.exe**\\**EnablePrivateNetwork** = 00000001</span></span>

    <span data-ttu-id="3882f-157">このレジストリ キーを用意していない場合は、管理者特権でコマンド プロンプトで作成できます。</span><span class="sxs-lookup"><span data-stu-id="3882f-157">If you do not have this registry key, you can create it in a Command Prompt with administrator privileges.</span></span>

    ```cmd 
    REG ADD "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\authhost.exe" /v EnablePrivateNetwork /t REG_DWORD /d 1 /f
    ```

2.  <span data-ttu-id="3882f-158">送信トラフィックを生成するのは AuthHost であるため、AuthHost 用の規則を追加します。</span><span class="sxs-lookup"><span data-stu-id="3882f-158">Add a rule for the AuthHost as this is what is generating the outbound traffic.</span></span>
    ```syntax
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.a.p_8wekyb3d8bbwe
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.sso.p_8wekyb3d8bbwe
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.sso.c_8wekyb3d8bbwe
    D:\Windows\System32>CheckNetIsolation.exe LoopbackExempt -s
    List Loopback Exempted AppContainers
    [1] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.sso.c_8wekyb3d8bbwe
        SID:  S-1-15-2-1973105767-3975693666-32999980-3747492175-1074076486-3102532000-500629349
    [2] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.sso.p_8wekyb3d8bbwe
        SID:  S-1-15-2-166260-4150837609-3669066492-3071230600-3743290616-3683681078-2492089544
    [3] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.a.p_8wekyb3d8bbwe
        SID:  S-1-15-2-3506084497-1208594716-3384433646-2514033508-1838198150-1980605558-3480344935
    ```

3.  <span data-ttu-id="3882f-159">Fiddler への受信トラフィック用のファイアウォール規則を追加します。</span><span class="sxs-lookup"><span data-stu-id="3882f-159">Add a firewall rule for incoming traffic to Fiddler.</span></span>