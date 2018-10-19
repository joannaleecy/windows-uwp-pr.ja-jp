---
title: Web アカウント マネージャー
description: この記事では、Windows 10 Web アカウント マネージャー API を使い、AccountsSettingsPane を利用して、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft や Facebook など) に接続する方法について説明します。
author: PatrickFarley
ms.author: pafarley
ms.date: 12/6/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.assetid: ec9293a1-237d-47b4-bcde-18112586241a
ms.localizationpriority: medium
ms.openlocfilehash: 2de5c969610aa6b4fa1a3af01af565d35854b5f2
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5129231"
---
# <a name="web-account-manager"></a><span data-ttu-id="da2d9-104">Web アカウント マネージャー</span><span class="sxs-lookup"><span data-stu-id="da2d9-104">Web Account Manager</span></span>

<span data-ttu-id="da2d9-105">この記事では、Windows 10 Web アカウント マネージャー API を使い、**[AccountsSettingsPane](https://docs.microsoft.com/uwp/api/Windows.UI.ApplicationSettings.AccountsSettingsPane)** を利用して、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft や Facebook など) に接続する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-105">This article describes how to use the **[AccountsSettingsPane](https://docs.microsoft.com/uwp/api/Windows.UI.ApplicationSettings.AccountsSettingsPane)** to connect your Universal Windows Platform (UWP) app to external identity providers, like Microsoft or Facebook, using the Windows 10 Web Account Manager APIs.</span></span> <span data-ttu-id="da2d9-106">ユーザーの Microsoft アカウントを使用するためにユーザーの許可を求める方法、アクセス トークンを取得する方法、アクセス トークンを使って基本的な操作 (プロファイル データの取得や OneDrive アカウントへのファイルのアップロードなど) を実行する方法を学習してください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-106">You'll learn how to request a user's permission to use their Microsoft account, obtain an access token, and use it to perform basic operations (like get profile data or upload files to their OneDrive account).</span></span> <span data-ttu-id="da2d9-107">この手順は、ユーザーの許可を得て、Web アカウント マネージャーをサポートする ID プロバイダーにアクセスするための手順と似ています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-107">The steps are similar for getting user permission and access with any identity provider that supports the Web Account Manager.</span></span>

> [!NOTE]
> <span data-ttu-id="da2d9-108">完全なコード サンプルについては、[GitHub の WebAccountManagement サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620621)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-108">For a complete code sample, see the [WebAccountManagement sample on GitHub](http://go.microsoft.com/fwlink/p/?LinkId=620621).</span></span>

## <a name="get-set-up"></a><span data-ttu-id="da2d9-109">準備</span><span class="sxs-lookup"><span data-stu-id="da2d9-109">Get set up</span></span>

<span data-ttu-id="da2d9-110">まず、Visual Studio で新しい空白のアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-110">First, create a new, blank app in Visual Studio.</span></span> 

<span data-ttu-id="da2d9-111">次に、ID プロバイダーに接続するために、アプリをストアに関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-111">Second, in order to connect to identity providers, you'll need to associate your app with the Store.</span></span> <span data-ttu-id="da2d9-112">これを行うには、プロジェクトを右クリックして、**[ストア]** > **[アプリケーションをストアと関連付ける]** を選択し、ウィザードの指示に従います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-112">To do this, right click your project, choose **Store** > **Associate app with the store**, and follow the wizard's instructions.</span></span> 

<span data-ttu-id="da2d9-113">3 番目に、シンプルな XAML ボタンと 2 つのテキスト ボックスから成る、非常に基本的な UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-113">Third, create a very basic UI consisting of a simple XAML button and two text boxes.</span></span>

```XML
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
    <Button x:Name="LoginButton" Content="Log in" Click="LoginButton_Click" />
    <TextBlock x:Name="UserIdTextBlock"/>
    <TextBlock x:Name="UserNameTextBlock"/>
</StackPanel>
```

<span data-ttu-id="da2d9-114">そして、コード ビハインドでイベント ハンドラーをボタンにアタッチします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-114">And an event handler attached to your button in the code-behind:</span></span>

```csharp
private void LoginButton_Click(object sender, RoutedEventArgs e)
{   
}
```

<span data-ttu-id="da2d9-115">最後に、次の名前空間を追加します。これにより、後で参照の問題について考える必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-115">Lastly, add the following namespaces so you don't have to worry about any reference issues later:</span></span> 

```csharp
using System;
using Windows.Security.Authentication.Web.Core;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Data.Json;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
```

## <a name="show-the-accounts-settings-pane"></a><span data-ttu-id="da2d9-116">アカウント設定ウィンドウの表示</span><span class="sxs-lookup"><span data-stu-id="da2d9-116">Show the accounts settings pane</span></span>

<span data-ttu-id="da2d9-117">システムには、ID プロバイダーを管理するための組み込みのユーザー インターフェイスと、**AccountsSettingsPane** という名前の Web アカウントが用意されています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-117">The system provides a built-in user interface for managing identity providers and web accounts called **AccountsSettingsPane**.</span></span> <span data-ttu-id="da2d9-118">これを次のように表示することができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-118">You can show it like this:</span></span>

```csharp
private void LoginButton_Click(object sender, RoutedEventArgs e)
{
    AccountsSettingsPane.Show(); 
}
```

<span data-ttu-id="da2d9-119">アプリを実行して「ログイン」ボタンをクリックすると、空のウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-119">If you run your app and click the "Log in" button, it should display an empty window.</span></span> 

![アカウント設定ウィンドウ](images/tb-1.png)

<span data-ttu-id="da2d9-121">システムは UI シェルのみを提供するため、このウィンドウは空になっています。開発者がこのウィンドウに ID プロバイダーをプログラムで入力します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-121">The pane is empty because the system only provides a UI shell - it's up to the developer to programatically populate the pane with the identity providers.</span></span> 

## <a name="register-for-accountcommandsrequested"></a><span data-ttu-id="da2d9-122">AccountCommandsRequested への登録</span><span class="sxs-lookup"><span data-stu-id="da2d9-122">Register for AccountCommandsRequested</span></span>

<span data-ttu-id="da2d9-123">ウィンドウにコマンドを追加するには、まず AccountCommandsRequested イベント ハンドラーに登録します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-123">To add commands to the pane, we start by registering for the AccountCommandsRequested event handler.</span></span> <span data-ttu-id="da2d9-124">これにより、ユーザーがウィンドウを表示するよう求めたとき (XAML ボタンのクリックなど) に構築したロジックをシステムが実行するようにできます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-124">This tells the system to run our build logic when the user asks to see the pane (e.g., clicks our XAML button).</span></span> 

<span data-ttu-id="da2d9-125">コードビハインドで、OnNavigatedTo イベントと OnNavigatedFrom イベントを上書きし、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-125">In your code behind, override the OnNavigatedTo and OnNavigatedFrom events and add the following code to them:</span></span> 

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested += BuildPaneAsync; 
}
```

```csharp
protected override void OnNavigatedFrom(NavigationEventArgs e)
{
    AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested -= BuildPaneAsync; 
}
```

<span data-ttu-id="da2d9-126">ユーザーは頻繁にはアカウントを操作しないため、この方法でイベント ハンドラーを登録および登録解除することは、メモリ リークを防ぐために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-126">Users don't interact with accounts very often, so registering and deregistering your event handler in this fashion helps prevent memory leaks.</span></span> <span data-ttu-id="da2d9-127">この方法では、カスタマイズしたウィンドウは (ユーザーが "設定" ページや "ログイン" ページにいるなどの理由で) ユーザーが使う可能性が高いときにのみメモリ内にあります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-127">This way, your customized pane is only in memory when there's a high chance a user is going to ask for it (because they're on a "settings" or "login" page, for example).</span></span> 

## <a name="build-the-account-settings-pane"></a><span data-ttu-id="da2d9-128">アカウント設定ウィンドウを構築します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-128">Build the account settings pane</span></span>

<span data-ttu-id="da2d9-129">**AccountsSettingsPane** が表示されるたびに、BuildPaneAsync メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-129">The BuildPaneAsync method is called whenever the **AccountsSettingsPane** is shown.</span></span> <span data-ttu-id="da2d9-130">ここに、ウィンドウに表示されるコマンドをカスタマイズするコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-130">This is where we'll put the code to customize the commands shown in the pane.</span></span> 

<span data-ttu-id="da2d9-131">まず、遅延を取得します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-131">Start by obtaining a deferral.</span></span> <span data-ttu-id="da2d9-132">これにより、構築が完了するまで **AccountsSettingsPane** の表示を遅延するようシステムに指示を出すことができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-132">This tells the system to delay showing the **AccountsSettingsPane** until we're finished building it.</span></span>

```csharp
private async void BuildPaneAsync(AccountsSettingsPane s,
    AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    var deferral = e.GetDeferral();
        
    deferral.Complete(); 
}
```

<span data-ttu-id="da2d9-133">次に、WebAuthenticationCoreManager.FindAccountProviderAsync メソッドを使ってプロバイダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-133">Next, get a provider using the WebAuthenticationCoreManager.FindAccountProviderAsync method.</span></span> <span data-ttu-id="da2d9-134">プロバイダーの URL はプロバイダーによって異なり、プロバイダーのドキュメントに記載されています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-134">The URL for the provider varies based on the provider and can be found in the provider's documentation.</span></span> <span data-ttu-id="da2d9-135">Microsoft アカウントと Azure Active Directory では、"https://login.microsoft.com" です。</span><span class="sxs-lookup"><span data-stu-id="da2d9-135">For Microsoft Accounts and Azure Active Directory, it's "https://login.microsoft.com".</span></span> 

```csharp
private async void BuildPaneAsync(AccountsSettingsPane s,
    AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    var deferral = e.GetDeferral();
        
    var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
        "https://login.microsoft.com", "consumers"); 
        
    deferral.Complete(); 
}
```

<span data-ttu-id="da2d9-136">文字列 "consumers" をオプションの *authority* パラメーターに渡すことにも注意してください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-136">Notice that we also pass the string "consumers" to the optional *authority* parameter.</span></span> <span data-ttu-id="da2d9-137">これは、Microsoft は "消費者 (consumers)" 向けの Microsoft アカウント (MSA) と、"組織 (organizations)" 向けの Azure Active Directory (AAD) という、2 種類の認証を提供しているためです。</span><span class="sxs-lookup"><span data-stu-id="da2d9-137">This is because Microsoft provides two different types of authentication - Microsoft Accounts (MSA) for "consumers", and Azure Active Directory (AAD) for "organizations".</span></span> <span data-ttu-id="da2d9-138">"consumers" 権限は、MSA オプションを必要としていることを示します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-138">The "consumers" authority indicates we want the MSA option.</span></span> <span data-ttu-id="da2d9-139">企業向けのアプリを開発している場合は、代わりに文字列 "organizations" を使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-139">If you're developing an enterprise app, use the string "organizations" instead.</span></span>

<span data-ttu-id="da2d9-140">最後に、次のような新しい **[WebAccountProviderCommand](https://docs.microsoft.com/uwp/api/windows.ui.applicationsettings.webaccountprovidercommand)** を作成して、**AccountsSettingsPane** にプロバイダーを追加します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-140">Finally, add the provider to the **AccountsSettingsPane** by creating a new **[WebAccountProviderCommand](https://docs.microsoft.com/uwp/api/windows.ui.applicationsettings.webaccountprovidercommand)** like this:</span></span> 

```csharp
private async void BuildPaneAsync(AccountsSettingsPane s,
    AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    var deferral = e.GetDeferral();

    var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
        "https://login.microsoft.com", "consumers");

    var command = new WebAccountProviderCommand(msaProvider, GetMsaTokenAsync);  

    e.WebAccountProviderCommands.Add(command);

    deferral.Complete(); 
}
```

<span data-ttu-id="da2d9-141">新しい **WebAccountProviderCommand** に渡した GetMsaToken メソッドはまだ存在していないため (次の手順で構築します)、現時点では、このメソッドを空のメソッドとして自由に追加できます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-141">The GetMsaToken method we passed to our new **WebAccountProviderCommand** doesn't exist yet (we'll build that in the next step), so feel free to add it as an empty method for now.</span></span>

<span data-ttu-id="da2d9-142">上記のコードを実行すると、ウィンドウは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-142">Run the above code and your pane should look something like this:</span></span> 

![アカウント設定ウィンドウ](images/tb-2.png)

### <a name="request-a-token"></a><span data-ttu-id="da2d9-144">トークンの要求</span><span class="sxs-lookup"><span data-stu-id="da2d9-144">Request a token</span></span>

<span data-ttu-id="da2d9-145">Microsoft アカウントのオプションが **AccountsSettingsPane** に 表示されたら、ユーザーがこのオプションを選択したときに、どのような動作を行うかを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-145">Once we have the Microsoft Account option displaying in the **AccountsSettingsPane**, we need to handle what happens when the user selects it.</span></span> <span data-ttu-id="da2d9-146">ユーザーが自分の Microsoft アカウントを使ってログインしたときに GetMsaToken メソッドが発生するように登録しているため、ここでトークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-146">We registered our GetMsaToken method to fire when the user chooses to log in with their Microsoft Account, so we'll obtain the token there.</span></span> 

<span data-ttu-id="da2d9-147">トークンを取得するには、次のような RequestTokenAsync メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-147">To obtain a token, use the RequestTokenAsync method like this:</span></span> 

```csharp
private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
}
```

<span data-ttu-id="da2d9-148">この例では、_スコープ_ パラメーターに文字列 "wl.basic" を渡します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-148">In this example, we pass the string "wl.basic" to the _scope_ parameter.</span></span> <span data-ttu-id="da2d9-149">スコープは、特定のユーザーの提供サービスから要求する情報の種類を表します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-149">Scope represents the type of information you are requesting from the providing service on a specific user.</span></span> <span data-ttu-id="da2d9-150">スコープには、名前やメール アドレスなど、ユーザーの基本情報のみへのアクセス権を与えるものや、ユーザーの写真やメールの受信トレイなど、機密情報へのアクセス権を与えるものもあります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-150">Certain scopes provide access only to a user's basic information, like name and email address, while other scopes might grant access to sensitive information such as the user's photos or email inbox.</span></span> <span data-ttu-id="da2d9-151">一般的に、アプリではその機能を実行するために必要な最も制限の多いスコープが使われます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-151">Generally, your app should use the least permissive scope necessary to achieve its function.</span></span> <span data-ttu-id="da2d9-152">サービス プロバイダーからは、サービス プロバイダーのサービスで使うトークンを取得する場合に必要となるスコープについて示したドキュメントが提供されます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-152">Service providers will provide documentation on which scopes are needed to get tokens for use with their services.</span></span> 

* <span data-ttu-id="da2d9-153">Office 365 と Outlook.com のスコープについては、「[v2.0 認証エンドポイントを使用した Office 365 および Outlook.com の API の認証](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-153">For Office 365 and Outlook.com scopes, see [Authenticate Office 365 and Outlook.com APIs using the v2.0 authentication endpoint](https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2).</span></span> 
* <span data-ttu-id="da2d9-154">OneDrive のスコープについては、「[OneDrive の認証とサインイン](https://dev.onedrive.com/auth/msa_oauth.htm#authentication-scopes)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-154">For OneDrive scopes, see [OneDrive authentication and sign-in](https://dev.onedrive.com/auth/msa_oauth.htm#authentication-scopes).</span></span> 

> [!TIP]
> <span data-ttu-id="da2d9-155">必要に応じて、アプリは、(既定のメール アドレスを持つユーザー フィールドを入力) へのログイン ヒントまたはサインイン エクスペリエンスに関連するその他の特殊なプロパティを使用する場合は、 **[WebTokenRequest.AppProperties](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webtokenrequest.appproperties#Windows_Security_Authentication_Web_Core_WebTokenRequest_AppProperties)** プロパティの一覧します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-155">Optionally, if your app uses a login hint (to populate the user field with a default email address) or other special property related to the sign-in experience, list it in the **[WebTokenRequest.AppProperties](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webtokenrequest.appproperties#Windows_Security_Authentication_Web_Core_WebTokenRequest_AppProperties)** property.</span></span> <span data-ttu-id="da2d9-156">これにより、キャッシュ内のアカウントの不一致を防止する web アカウントをキャッシュする場合は、プロパティを無視するようにシステムです。</span><span class="sxs-lookup"><span data-stu-id="da2d9-156">This will cause the system to ignore the property when caching the web account, which prevents account mismatches in the cache.</span></span>

<span data-ttu-id="da2d9-157">企業向けのアプリを開発している場合は、Azure Active Directory (AAD) インスタンスに接続し、通常の MSA サービスではなく Microsoft Graph API を使用します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-157">If you're developing an enterprise app, you'll likely want to connect to an Azure Active Directory (AAD) instance and use the Microsoft Graph API instead of regular MSA services.</span></span> <span data-ttu-id="da2d9-158">このシナリオでは、次のコードを代わりに使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-158">In this scenario, use the following code instead:</span></span> 

```csharp
private async void GetAadTokenAsync(WebAccountProviderCommand command)
{
    string clientId = "your_guid_here"; // Obtain your clientId from the Azure Portal
    WebTokenRequest request = new WebTokenRequest(provider, "User.Read", clientId);
    request.Properties.Add("resource", "https://graph.microsoft.com");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
}
```

<span data-ttu-id="da2d9-159">この記事の残りの部分では、引き続き MSA シナリオについて説明しますが、AAD 用のコードもよく似ています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-159">The rest of this article continues describing the MSA scenario, but the code for AAD is very similar.</span></span> <span data-ttu-id="da2d9-160">GitHub の完全なサンプルを含め、AAD/Graph について詳しくは、[Microsoft Graph のドキュメント](https://graph.microsoft.io/docs/platform/get-started)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-160">For more info on AAD/Graph, including a full sample on GitHub, see the [Microsoft Graph documentation](https://graph.microsoft.io/docs/platform/get-started).</span></span>

## <a name="use-the-token"></a><span data-ttu-id="da2d9-161">トークンの使用</span><span class="sxs-lookup"><span data-stu-id="da2d9-161">Use the token</span></span>

<span data-ttu-id="da2d9-162">RequestTokenAsync メソッドは、要求の結果を含む WebTokenRequestResult オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-162">The RequestTokenAsync method returns a WebTokenRequestResult object, which contains the results of your request.</span></span> <span data-ttu-id="da2d9-163">要求が成功した場合には、トークンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-163">If your request was successful, it will contain a token.</span></span>  

```csharp
private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
    
    if (result.ResponseStatus == WebTokenRequestStatus.Success)
    {
        string token = result.ResponseData[0].Token; 
    }
}
```

> [!NOTE]
> <span data-ttu-id="da2d9-164">トークンを要求したときにエラーが発生した場合、最初の手順で説明したように、アプリを Microsoft Store に関連付けたかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-164">If you receive an error when requesting a token, make sure you've associated your app with the Store as described in step one.</span></span> <span data-ttu-id="da2d9-165">この手順を省略すると、アプリでトークンを取得することはできません。</span><span class="sxs-lookup"><span data-stu-id="da2d9-165">Your app won't be able to get a token if you skipped this step.</span></span> 

<span data-ttu-id="da2d9-166">トークンを取得したら、トークンを使って、プロバイダーの API を呼び出ことができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-166">Once you have a token, you can use it to call your provider's API.</span></span> <span data-ttu-id="da2d9-167">次のコードでは、[ユーザー情報のための Microsoft Live API](https://msdn.microsoft.com/library/hh826533.aspx) を呼び出してユーザーに関する基本情報を取得し、UI に表示します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-167">In the code below, we'll call the [user info Microsoft Live API](https://msdn.microsoft.com/library/hh826533.aspx) to obtain basic information about the user and display it in our UI.</span></span> <span data-ttu-id="da2d9-168">ただし、ほとんどの場合、取得したトークンは保存してから、別のメソッドで使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-168">Note however that in most cases it is recommended that you store the token once obtained and then use it in a separate method.</span></span>

```csharp
private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
    
    if (result.ResponseStatus == WebTokenRequestStatus.Success)
    {
        string token = result.ResponseData[0].Token; 
        
        var restApi = new Uri(@"https://apis.live.net/v5.0/me?access_token=" + token);

        using (var client = new HttpClient())
        {
            var infoResult = await client.GetAsync(restApi);
            string content = await infoResult.Content.ReadAsStringAsync();

            var jsonObject = JsonObject.Parse(content);
            string id = jsonObject["id"].GetString();
            string name = jsonObject["name"].GetString();

            UserIdTextBlock.Text = "Id: " + id; 
            UserNameTextBlock.Text = "Name: " + name;
        }
    }
}
```

<span data-ttu-id="da2d9-169">さまざまな REST API の呼び出し方法は、プロバイダーによって異なります。トークンの使い方に関する情報については、プロバイダーの API ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-169">How you call various REST APIs varies between providers; see the provider's API documentation for information on how to use your token.</span></span> 

## <a name="store-the-account-for-future-use"></a><span data-ttu-id="da2d9-170">将来の使用に備えてアカウントを保存する</span><span class="sxs-lookup"><span data-stu-id="da2d9-170">Store the account for future use</span></span>

<span data-ttu-id="da2d9-171">トークンはユーザーに関する情報をすぐに取得するために便利ですが、通常はさまざまな有効期限を持ちます。たとえば、MSA トークンは数時間のみ有効です。</span><span class="sxs-lookup"><span data-stu-id="da2d9-171">Tokens are useful for immediately obtaining information about a user, but they usually have varying lifespans - MSA tokens, for instance, are only valid for a few hours.</span></span> <span data-ttu-id="da2d9-172">ただし、トークンの有効期限が切れるたびに **AccountsSettingsPane** を再表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="da2d9-172">Fortunately, you don't need to re-show the **AccountsSettingsPane** each time a token expires.</span></span> <span data-ttu-id="da2d9-173">ユーザーが一度アプリを承認すると、将来使うためにユーザーのアカウント情報を保存できます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-173">Once a user has authorized your app once, you can store the user's account information for future use.</span></span> 

<span data-ttu-id="da2d9-174">これを行うには、**[WebAccount](https://docs.microsoft.com/uwp/api/windows.security.credentials.webaccount)** クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-174">To do this, use the **[WebAccount](https://docs.microsoft.com/uwp/api/windows.security.credentials.webaccount)** class.</span></span> <span data-ttu-id="da2d9-175">**WebAccount** は、トークンの要求で使ったメソッドと同じメソッドによって返されます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-175">A **WebAccount** is returned by the same method you used to request the token:</span></span>

```csharp
private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
    WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
    
    if (result.ResponseStatus == WebTokenRequestStatus.Success)
    {
        WebAccount account = result.ResponseData[0].WebAccount; 
    }
}
```

<span data-ttu-id="da2d9-176">**WebAccount** インスタンスを取得すると、これを簡単に保存することができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-176">Once you have a **WebAccount** instance, you can easily store it.</span></span> <span data-ttu-id="da2d9-177">次の例では、LocalSettings を使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-177">In the following example, we use LocalSettings.</span></span> <span data-ttu-id="da2d9-178">LocalSettings やユーザー データを保存するための他のメソッドの使用方法について詳しくは、「[Store and retrieve app settings and data](https://docs.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)」(アプリの設定とデータを保存して取得する) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da2d9-178">For more information on using LocalSettings and other methods to store user data, see [Store and retrieve app settings and data](https://docs.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data).</span></span>

```csharp
private async void StoreWebAccount(WebAccount account)
{
    ApplicationData.Current.LocalSettings.Values["CurrentUserProviderId"] = account.WebAccountProvider.Id;
    ApplicationData.Current.LocalSettings.Values["CurrentUserId"] = account.Id; 
}
```

<span data-ttu-id="da2d9-179">その後で、次のような非同期メソッドを使い、保存された **WebAccount** を利用して、トークンの取得をバックグラウンドで実行することができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-179">Then, we can use an asynchronous method like the following to attempt to obtain a token in the background with the stored **WebAccount**.</span></span>

```csharp
private async Task<string> GetTokenSilentlyAsync()
{
    string providerId = ApplicationData.Current.LocalSettings.Values["CurrentUserProviderId"]?.ToString();
    string accountId = ApplicationData.Current.LocalSettings.Values["CurrentUserId"]?.ToString();

    if (null == providerId || null == accountId)
    {
        return null; 
    }

    WebAccountProvider provider = await WebAuthenticationCoreManager.FindAccountProviderAsync(providerId);
    WebAccount account = await WebAuthenticationCoreManager.FindAccountAsync(provider, accountId);

    WebTokenRequest request = new WebTokenRequest(provider, "wl.basic");

    WebTokenRequestResult result = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(request, account);
    if (result.ResponseStatus == WebTokenRequestStatus.UserInteractionRequired)
    {
        // Unable to get a token silently - you'll need to show the UI
        return null; 
    }
    else if (result.ResponseStatus == WebTokenRequestStatus.Success)
    {
        // Success
        return result.ResponseData[0].Token;
    }
    else
    {
        // Other error 
        return null; 
    }
}
```

<span data-ttu-id="da2d9-180">上記のメソッドは、**AccountsSettingsPane** を構築するコードの直前に配置します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-180">Place the above method just before the code that builds the **AccountsSettingsPane**.</span></span> <span data-ttu-id="da2d9-181">トークンをバックグラウンドで取得する場合は、ウィンドウを表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="da2d9-181">If the token is obtained in the background, there is no need to show the pane.</span></span> 

```csharp
private void LoginButton_Click(object sender, RoutedEventArgs e)
{
    string silentToken = await GetMsaTokenSilentlyAsync();

    if (silentToken != null)
    {
        // the token was obtained. store a reference to it or do something with it here.
    }
    else
    {
        // the token could not be obtained silently. Show the AccountsSettingsPane
        AccountsSettingsPane.Show();
    }
}
```

<span data-ttu-id="da2d9-182">通知なしでのトークンの取得は非常に単純なため、(トークンの有効期限がいつ切れても大丈夫なように) セッション間でのトークンの更新には、既存のトークンをキャッシュするのではなく、このプロセスを使います。</span><span class="sxs-lookup"><span data-stu-id="da2d9-182">Because obtaining a token silently is very simple, you should use this process to refresh your token between sessions rather than caching an existing token (since that token might expire at any time).</span></span>

> [!NOTE]
> <span data-ttu-id="da2d9-183">上記の例は、基本的な成功と失敗のケースのみを扱っています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-183">The example above only covers basic success and fail cases.</span></span> <span data-ttu-id="da2d9-184">アプリは特殊なシナリオ (ユーザーによってアプリのアクセス許可が無効にされた場合や、Windows からユーザーのアカウントが削除された場合など) も考慮し、適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-184">Your app should also account for unusual scenarios (like a user revoking your app's permission or removing their account from Windows, for example) and handle them gracefully.</span></span>  

## <a name="remove-a-stored-account"></a><span data-ttu-id="da2d9-185">保存されたアカウントの削除</span><span class="sxs-lookup"><span data-stu-id="da2d9-185">Remove a stored account</span></span>

<span data-ttu-id="da2d9-186">Web アカウントを保持するとき、場合によっては、ユーザーが自分のアカウントとアプリの関連付けを解除できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-186">If you persist a web account, you may want to give your users the ability to disassociate their account with your app.</span></span> <span data-ttu-id="da2d9-187">これにより、ユーザーはアプリから効率的に "ログアウト" することができます。起動時、ユーザーのアカウント情報は自動的に読み込まれなくなります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-187">This way, they can can effectively "log out" of the app: their account information will no longer be loaded automatically upon launch.</span></span> <span data-ttu-id="da2d9-188">これを行うには、まず保存されたアカウントとプロバイダーの情報を記憶域から削除します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-188">To do this, first remove any saved account and provider information from storage.</span></span> <span data-ttu-id="da2d9-189">次に、**[SignOutAsync](https://docs.microsoft.com/uwp/api/windows.security.credentials.webaccount.SignOutAsync)** を呼び出してキャッシュをクリアし、アプリが保持している可能性がある既存のトークンをすべて無効にします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-189">Then call **[SignOutAsync](https://docs.microsoft.com/uwp/api/windows.security.credentials.webaccount.SignOutAsync)** to clear the cache and invalidate any existing tokens your app may have.</span></span> 

```csharp
private async Task SignOutAccountAsync(WebAccount account)
{
    ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserProviderId");
    ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserId"); 
    account.SignOutAsync(); 
}
```

## <a name="add-providers-that-dont-support-webaccountmanager"></a><span data-ttu-id="da2d9-190">WebAccountManager をサポートしていないプロバイダーの追加</span><span class="sxs-lookup"><span data-stu-id="da2d9-190">Add providers that don't support WebAccountManager</span></span>

<span data-ttu-id="da2d9-191">サービスからの認証をアプリに統合するときに、そのサービスが WebAccountManager をサポートしていない場合でも (Google+ や Twitter など)、そのプロバイダーを **AccountsSettingsPane** に手動で追加できます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-191">If you want to integrate authentication from a service into your app but that service doesn't support WebAccountManager - Google+ or Twitter, for example - you can still manually add that provider to the **AccountsSettingsPane**.</span></span> <span data-ttu-id="da2d9-192">これを行うには、新しい WebAccountProvider オブジェクトを作成し、独自の名前と .png アイコンを指定してから、WebAccountProviderCommands リストに追加します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-192">To do so, create a new WebAccountProvider object and provide your own name and .png icon, then and add it to the WebAccountProviderCommands list.</span></span> <span data-ttu-id="da2d9-193">いくつかのスタブ コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-193">Here's some stub code:</span></span> 

 ```csharp
private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    // other code here 

    var twitterProvider = new WebAccountProvider("twitter", "Twitter", new Uri(@"ms-appx:///Assets/twitter-auth-icon.png")); 
    var twitterCmd = new WebAccountProviderCommand(twitterProvider, GetTwitterTokenAsync);
    e.WebAccountProviderCommands.Add(twitterCmd);   
    
    // other code here
}

private async void GetTwitterTokenAsync(WebAccountProviderCommand command)
{
    // Manually handle Twitter login here
}

```

> [!NOTE] 
> <span data-ttu-id="da2d9-194">この例では、アイコンを **AccountsSettingsPane** に追加し、指定されたメソッド (この場合は GetTwitterTokenAsync) をアイコンのクリック時に実行するだけです。</span><span class="sxs-lookup"><span data-stu-id="da2d9-194">This only adds an icon to the **AccountsSettingsPane** and runs the method you specify when the icon is clicked (GetTwitterTokenAsync, in this case).</span></span> <span data-ttu-id="da2d9-195">実際の認証を処理するコードを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="da2d9-195">You must provide the code that handles the actual authentication.</span></span> <span data-ttu-id="da2d9-196">詳しくは、「(Web 認証ブローカー)[web-authentication-broker]」を参照してください。REST サービスを使った認証のためのヘルパー メソッドが提供されています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-196">For more information, see (Web authentication broker)[web-authentication-broker], which provides helper methods for authenticating using REST services.</span></span> 

## <a name="add-a-custom-header"></a><span data-ttu-id="da2d9-197">カスタム ヘッダーの追加</span><span class="sxs-lookup"><span data-stu-id="da2d9-197">Add a custom header</span></span>

<span data-ttu-id="da2d9-198">次のように、HeaderText プロパティを使ってアカウント設定ウィンドウをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-198">You can customize the account settings pane using the HeaderText property, like this:</span></span> 

```csharp
private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    // other code here 
    
    args.HeaderText = "MyAwesomeApp works best if you're signed in.";   
    
    // other code here
}
```

![アカウント設定ウィンドウ](images/tb-3.png)

<span data-ttu-id="da2d9-200">ヘッダー テキストを長くしすぎないでください。短く簡潔なテキストにします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-200">Don't go overboard with header text; keep it short and sweet.</span></span> <span data-ttu-id="da2d9-201">ログイン プロセスが複雑で、詳しい情報を表示する必要がある場合には、カスタム リンクを使ってユーザーを別のページにリンクします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-201">If your login process is complicated and you need to display more information, link the user to a separate page using a custom link.</span></span> 

## <a name="add-custom-links"></a><span data-ttu-id="da2d9-202">カスタム リンクの追加</span><span class="sxs-lookup"><span data-stu-id="da2d9-202">Add custom links</span></span>

<span data-ttu-id="da2d9-203">サポートされている WebAccountProviders の下にリンクとして表示されるカスタム コマンドを AccountsSettingsPane に追加することができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-203">You can add custom commands to the AccountsSettingsPane, which appear as links below your supported WebAccountProviders.</span></span> <span data-ttu-id="da2d9-204">カスタム コマンドは、プライバシー ポリシーの表示や問題が発生したユーザーのためのサポート ページの起動などの、ユーザー アカウントに関連する単純なタスクに適しています。</span><span class="sxs-lookup"><span data-stu-id="da2d9-204">Custom commands are great for simple tasks related to user accounts, like displaying a privacy policy or launching a support page for users having trouble.</span></span> 

<span data-ttu-id="da2d9-205">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="da2d9-205">Here's an example:</span></span> 

```csharp
private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    // other code here 
    
    var settingsCmd = new SettingsCommand(
        "settings_privacy", 
        "Privacy policy", 
        async (x) => await Launcher.LaunchUriAsync(new Uri(@"https://privacy.microsoft.com/en-US/"))); 

    e.Commands.Add(settingsCmd); 
    
    // other code here
}
```

![アカウント設定ウィンドウ](images/tb-4.png)

<span data-ttu-id="da2d9-207">理論上は、あらゆることのために設定コマンドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="da2d9-207">Theoretically, you can use settings commands for anything.</span></span> <span data-ttu-id="da2d9-208">ただし、上記のような、直観的なアカウント関連のシナリオにのみ使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="da2d9-208">However, we suggest limiting their use to intuitive, account-related scenarios like those described above.</span></span> 

## <a name="see-also"></a><span data-ttu-id="da2d9-209">関連項目</span><span class="sxs-lookup"><span data-stu-id="da2d9-209">See also</span></span>

[<span data-ttu-id="da2d9-210">Windows.Security.Authentication.Web.Core 名前空間</span><span class="sxs-lookup"><span data-stu-id="da2d9-210">Windows.Security.Authentication.Web.Core namespace</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.authentication.web.core.aspx)

[<span data-ttu-id="da2d9-211">Windows.Security.Credentials 名前空間</span><span class="sxs-lookup"><span data-stu-id="da2d9-211">Windows.Security.Credentials namespace</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.credentials.aspx)

[<span data-ttu-id="da2d9-212">AccountsSettingsPane クラス</span><span class="sxs-lookup"><span data-stu-id="da2d9-212">AccountsSettingsPane class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.applicationsettings.accountssettingspane)

[<span data-ttu-id="da2d9-213">Web 認証ブローカー</span><span class="sxs-lookup"><span data-stu-id="da2d9-213">Web authentication broker</span></span>](web-authentication-broker.md)

[<span data-ttu-id="da2d9-214">Web アカウント管理のサンプル</span><span class="sxs-lookup"><span data-stu-id="da2d9-214">Web account management sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620621)

[<span data-ttu-id="da2d9-215">ランチ スケジューラ アプリ</span><span class="sxs-lookup"><span data-stu-id="da2d9-215">Lunch Scheduler app</span></span>](https://github.com/Microsoft/Windows-appsample-lunch-scheduler)
