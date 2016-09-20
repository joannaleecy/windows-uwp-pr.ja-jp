---
title: "Web アカウント マネージャーによる ID プロバイダーへの接続"
description: "この記事では、新しい Windows 10 Web アカウント マネージャー API を使って、AccountsSettingsPane を使い、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft、Facebook など) に接続する方法について説明します。"
author: awkoren
translationtype: Human Translation
ms.sourcegitcommit: f3cdb187ec4056d4c7db6acde471b0bc91c78390
ms.openlocfilehash: 093ca8906853121bbf33a729c523717d26cb7b0d

---
# Web アカウント マネージャーによる ID プロバイダーへの接続

この記事では、新しい Windows 10 Web アカウント マネージャー API を使って、AccountsSettingsPane を表示し、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft、Facebook など) に接続する方法について説明します。 ユーザーの Microsoft アカウントを使うためのユーザーの許可を求める方法、アクセス トークンを取得する方法、基本的な操作 (プロファイル データの取得や OneDrive へのファイルのアップロードなど) を実行する方法について説明します。 この手順は、ユーザーの許可を得て、Web アカウント マネージャーをサポートする ID プロバイダーにアクセスするための手順と似ています。

> 注: 完全なコード サンプルについては、「[GitHub の WebAccountManagement サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620621)」をご覧ください。

## 準備

まず、Visual Studio で新しい空白のアプリを作成します。 

次に、ID プロバイダーに接続するために、アプリをストアに関連付ける必要があります。 これを行うには、プロジェクトを右クリックして、**[ストア]** > **[アプリケーションをストアと関連付ける]** を選択し、ウィザードの指示に従います。 

3 番目に、シンプルな XAML ボタンと 2 つのテキスト ボックスから成る、非常に基本的な UI を作成します。

```XML
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
    <Button x:Name="LoginButton" Content="Log in" Click="LoginButton_Click" />
    <TextBlock x:Name="UserIdTextBlock"/>
    <TextBlock x:Name="UserNameTextBlock"/>
</StackPanel>
```

そして、コード ビハインドでイベント ハンドラーをボタンにアタッチします。

```C#
private void LoginButton_Click(object sender, RoutedEventArgs e)
{   
}
```

最後に、後で参照の問題について心配する必要がなくなるように、次の名前空間を追加します。 

```C#
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

## AccountSettingsPane の表示

システムには、ID プロバイダーを管理するための組み込みのユーザー インターフェイスと、AccountSettingsPane という名前の Web アカウントが用意されています。 これを次のように表示することができます。

```C#
private void LoginButton_Click(object sender, RoutedEventArgs e)
{
    AccountsSettingsPane.Show(); 
}
```

アプリを実行して「ログイン」ボタンをクリックすると、空のウィンドウが表示されます。 

![アカウント設定ウィンドウ](images/tb-1.png)

システムは UI シェルのみを提供するため、このウィンドウは空になっています。開発者がこのウィンドウに ID プロバイダーをプログラムで入力します。 

## AccountCommandsRequested への登録

ウィンドウにコマンドを追加するには、まず AccountCommandsRequested イベント ハンドラーに登録します。 これにより、ユーザーがウィンドウを表示するよう求めたとき (XAML ボタンのクリックなど) に構築したロジックをシステムが実行するようにできます。 

コードビハインドで、OnNavigatedTo イベントと OnNavigatedFrom イベントを上書きし、次のコードを追加します。 

```C#
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested += BuildPaneAsync; 
}
```

```C#
protected override void OnNavigatedFrom(NavigationEventArgs e)
{
    AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested -= BuildPaneAsync; 
}
```

ユーザーは頻繁にはアカウントを操作しないため、この方法でイベント ハンドラーを登録および登録解除することは、メモリ リークを防ぐために役立ちます。 この方法では、カスタマイズしたウィンドウは (ユーザーが "設定" ページや "ログイン" ページにいるなどの理由で) ユーザーが使う可能性が高いときにのみメモリ内にあります。 

## アカウント設定ウィンドウを構築します。

AccountSettingsPane を表示するたびに、BuildPaneAsync メソッドが呼び出されます。 ここに、ウィンドウに表示されるコマンドをカスタマイズするコードを記述します。 

まず、遅延を取得します。 これにより、構築が完了するまで AccountsSettingsPane の表示を遅延するようシステムに指示を出すことができます。

```C#
private async void BuildPaneAsync(AccountsSettingsPane s,
    AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    var deferral = e.GetDeferral();
        
    deferral.Complete(); 
}
```

次に、WebAuthenticationCoreManager.FindAccountProviderAsync メソッドを使ってプロバイダーを取得します。 プロバイダーの URL はプロバイダーによって異なり、プロバイダーのドキュメントに記載されています。 Microsoft アカウントと Azure Active Directory では、"https://login.microsoft.com" です。 

```C#
private async void BuildPaneAsync(AccountsSettingsPane s,
    AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    var deferral = e.GetDeferral();
        
    var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
        "https://login.microsoft.com", "consumers"); 
        
    deferral.Complete(); 
}
```

文字列 "consumers" をオプションの *authority* パラメーターに渡すことにも注意してください。 これは、Microsoft は "消費者 (consumers)" 向けの Microsoft アカウント (MSA) と、"組織 (organizations)" 向けの Azure Active Directory (AAD) という、2 種類の認証を提供しているためです。 "consumers" 権限では、前者のオプションに関心があることをプロバイダーに知らせます。

企業向けのアプリを開発している場合は、代わりに AAD グラフ エンドポイントを使います。 これを行う方法について詳しくは、「[GitHub の WebAccountManagement サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620621)」全体と、Azure のドキュメントをご覧ください。 

最後に、次のような新しい WebAccountProviderCommand を作成して、AccountsSettingsPane にプロバイダーを追加します。 

```C#
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

新しい WebAccountProviderCommand に渡した GetMsaToken メソッドはまだ存在していないため (次の手順で構築します)、今のところは遠慮なく空のメソッドとして追加してください。

上記のコードを実行すると、ウィンドウは次のようになります。 

![アカウント設定ウィンドウ](images/tb-2.png)

### トークンの要求

AccountsSettingsPane に Microsoft アカウントのオプションが表示されたら、ユーザーがこのオプションを選択したときに何が起こるかを扱う必要があります。 ユーザーが自分の Microsoft アカウントを使ってログインしたときに GetMsaToken メソッドが発生するように登録しているため、ここでトークンを取得します。 

トークンを取得するには、次のような RequestTokenAsync メソッドを使います。 

```C#
private async void GetMsaTokenAsync(WebAccountProviderCommand command)
{
    WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
    WebTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(request);
}
```

この例では、スコープ パラメーターに文字列 "wl.basic" を渡します。 スコープは、特定のユーザーの提供サービスから要求する情報の種類を表します。 一部のスコープは、名前やメール アドレスなどの、ユーザーの基本的な情報のみへのアクセスを提供します。 その他のスコープは、ユーザーの写真やメールの受信トレイなどの機密情報へのアクセス権を付与する場合があります。 一般的に、アプリが追加の権限を明確に必要としない限り、アプリは最低限の権限のスコープを使う必要があります。たとえば、アプリでどうしても必要ではない場合は、機密情報へのアクセスを求めないようにします。 

サービス プロバイダーは、サービス プロバイダーのサービスで使うトークンを取得するためにどのスコープを指定する必要があるかに関するドキュメントを提供します。 

Office 365 と Outlook.com のスコープについては、「(v2.0 認証エンドポイントを使用した Office 365 および Outlook.com の API の認証)[https://msdn.microsoft.com/office/office365/howto/authenticate-Office-365-APIs-using-v2]」をご覧ください。 

OneDrive については、「(OneDrive の認証とサインイン)[https://dev.onedrive.com/auth/msa_oauth.htm#authentication-scopes]」をご覧ください。 

## トークンの使用

RequestTokenAsync メソッドは、要求の結果を含む WebTokenRequestResult オブジェクトを返します。 要求が成功した場合には、トークンが含まれます。  

```C#
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

> 注: トークンを要求したときにエラーが発生した場合、最初の手順で説明したように、アプリをストアに関連付けたことを確認してください。 この手順を省略すると、アプリでトークンを取得することはできません。 

トークンを取得したら、プロバイダーの API を呼び出すためにトークンを使うことができます。 次のコードでは、Microsoft Live API を呼び出してユーザーに関する基本情報を取得し、UI に表示します。 

```C#
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

さまざまな REST API の呼び出し方法は、プロバイダーによって異なります。トークンの使い方に関する情報については、プロバイダーの API ドキュメントをご覧ください。 

## アカウントの状態の保存

トークンはユーザーに関する情報をすぐに取得するために便利ですが、通常はさまざまな有効期限を持ちます。たとえば、MSA トークンは数時間のみ有効です。 さいわい、トークンの有効期限が切れるたびに AccountsSettingsPane を再表示する必要はありません。 ユーザーが一度アプリを承認すると、将来使うためにユーザーのアカウント情報を保存できます。 

これを行うには、WebAccount クラスを使います。 トークンを要求すると、WebAccount が返されます。

```C#
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

WebAccount を取得したら、簡単に保存することができます。 次の例では、LocalSettings を使います。 

```C#
private async void StoreWebAccount(WebAccount account)
{
    ApplicationData.Current.LocalSettings.Values["CurrentUserProviderId"] = account.WebAccountProvider.Id;
    ApplicationData.Current.LocalSettings.Values["CurrentUserId"] = account.Id; 
}
```

ユーザーが次にアプリを起動したときは、次のように通知なしで (バックグラウンドで) トークンの取得を試みることができます。 

```C#
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

通知なしでのトークンの取得は非常に単純なため、(トークンの有効期限がいつ切れても大丈夫なように) セッション間でのトークンの更新には、既存のトークンをキャッシュするのではなく、このプロセスを使います。

上記の例は、基本的な成功と失敗のケースのみを扱っていることに注意してください。 アプリは特殊なシナリオ (ユーザーによってアプリのアクセス許可が無効にされた場合や、Windows からユーザーのアカウントが削除された場合など) も考慮し、適切に処理する必要があります。  

## アカウントのログアウト 

WebAccount を保持する場合は、ユーザーがアプリでアカウントを切り替えたり、単に自分のアカウントの関連付けを解除することができるように、"ログアウト" 機能を提供する場合があります。 これを行うには、まず保存されたアカウントとプロバイダーの情報を削除します。 次に、WebAccount.SignOutAsync() を呼び出してキャッシュをクリアし、アプリが保持している可能性がある既存のトークンをすべて無効にします。 

```C#
private async Task SignOutAccountAsync(WebAccount account)
{
    ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserProviderId");
    ApplicationData.Current.LocalSettings.Values.Remove("CurrentUserId"); 
    account.SignOutAsync(); 
}
```

## WebAccountManager をサポートしていないプロバイダーの追加

サービスからの認証をアプリに統合するときに、そのサービスが WebAccountManager をサポートしていない場合でも (Google+ や Twitter など)、そのプロバイダーを AccountsSettingsPane に手動で追加できます。 これを行うには、新しい WebAccountProvider オブジェクトを作成し、独自の名前と .png アイコンを提供してから、WebAccountProviderCommands に追加します。 いくつかのスタブ コードを次に示します。 

 ```C#
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

これはアイコンを AccountsSettingsPane に追加し、アイコンがクリックされたときに指定されたメソッド (この場合は GetTwitterTokenAsync) を実行するだけなことに注意してください。 実際の認証を処理するコードを提供する必要があります。 詳しくは、「(Web 認証ブローカー)[web-authentication-broker]」を参照してください。REST サービスを使った認証のためのヘルパー メソッドが提供されています。 

## カスタム ヘッダーの追加

次のように、HeaderText プロパティを使ってアカウント設定ウィンドウをカスタマイズできます。 

```C#
private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
{
    // other code here 
    
    args.HeaderText = "MyAwesomeApp works best if you're signed in.";   
    
    // other code here
}
```

![アカウント設定ウィンドウ](images/tb-3.png)

ヘッダー テキストを長くしすぎないでください。短く簡潔なテキストにします。 ログイン プロセスが複雑で、詳しい情報を表示する必要がある場合には、カスタム リンクを使ってユーザーを別のページにリンクします。 

## カスタム リンクの追加

サポートされている WebAccountProviders の下にリンクとして表示されるカスタム コマンドを AccountsSettingsPane に追加することができます。 カスタム コマンドは、プライバシー ポリシーの表示や問題が発生したユーザーのためのサポート ページの起動などの、ユーザー アカウントに関連する単純なタスクに適しています。 

次に例を示します。 

```C#
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

理論上は、あらゆることのために設定コマンドを使うことができます。 ただし、上記のような、直観的なアカウント関連のシナリオにのみ使うことをお勧めします。 

## 関連項目

[Windows.Security.Authentication.Web.Core 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.security.authentication.web.core.aspx)

[Windows.Security.Credentials 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.security.credentials.aspx)

[AccountsSettingsPane](https://msdn.microsoft.com/library/windows/apps/windows.ui.applicationsettings.accountssettingspane)

[Web 認証ブローカー](web-authentication-broker.md)

[WebAccountManagement サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620621)



<!--HONumber=Aug16_HO3-->


