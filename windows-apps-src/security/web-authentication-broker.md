---
title: "Web 認証ブローカー"
description: "この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にユニバーサル Windows プラットフォーム (UWP) アプリを接続する方法について説明します。"
ms.assetid: 05F06961-1768-44A7-B185-BCDB74488F85
author: awkoren
translationtype: Human Translation
ms.sourcegitcommit: 36bc5dcbefa6b288bf39aea3df42f1031f0b43df
ms.openlocfilehash: ea3d3e1df07c8cf9701e7bd39af006cd681ef1fe

---

# Web 認証ブローカー


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にユニバーサル Windows プラットフォーム (UWP) アプリを接続する方法について説明します。 [**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドは、要求をオンライン ID プロバイダーに送信し、アプリがアクセスできるプロバイダー リソースを示すアクセス トークンを返します。

**注:** 動作する完全なコード サンプルが必要な場合は、[GitHub の WebAuthenticationBroker レポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=620622)をコピーしてください。

 

## アプリのオンライン プロバイダーへの登録


アプリを接続先のオンライン ID プロバイダーに登録する必要があります。 アプリを登録する方法については、ID プロバイダーに確認してください。 通常、登録すると、オンライン プロバイダーからアプリの ID や秘密鍵が提供されます。

## 認証要求の URI の作成


要求の URI は、オンライン プロバイダーに対する認証要求の送信先のアドレスと、必要なその他の情報 (アプリ ID またはシークレット、認証後にユーザーが転送されるリダイレクト URI、必要な応答の型など) で構成されます。 必要なパラメーターについては、プロバイダーに確認してください。

要求の URI は、[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドの *requestUri* パラメーターとして送信されます。 また、セキュリティで保護されたアドレスである (https:// で始まる) 必要があります。

次の例は、要求の URI を作成する方法を示しています。

```cs
string startURL = "https://<providerendpoint>?client_id=<clientid>&scope=<scopes>&response_type=token";
string endURL = "http://<appendpoint>";

System.Uri startURI = new System.Uri(startURL);
System.Uri endURI = new System.Uri(endURL);
```

## オンライン プロバイダーへの接続


[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドを呼び出してオンライン ID プロバイダーに接続し、アクセス トークンを取得します。 このメソッドは、前の手順で作った URI を *requestUri* パラメーターとして受け取り、ユーザーのリダイレクト先の URI を *callbackUri* パラメーターとして受け取ります。

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

[**AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) に加え、[**Windows.Security.Authentication.Web**](https://msdn.microsoft.com/library/windows/apps/br227044) 名前空間には [**AuthenticateAndContinue**](https://msdn.microsoft.com/library/windows/apps/dn632425) メソッドが含まれています。 このメソッドは呼び出さないでください。 これは Windows Phone 8.1 のみを対象とするアプリ用に設計されたもので、Windows 10 以降では推奨されません。

## シングル サインオン (SSO) を使った接続


既定では、Web 認証ブローカーは Cookie の保存を許可していません。 そのため、アプリ ユーザーは (たとえば、プロバイダーのログイン ダイアログのチェック ボックスをオンにして) ログオン状態を維持することを示した場合でも、そのプロバイダーのリソースにアクセスするたびにログインする必要があります。 SSO を使ってログインするには、オンライン ID プロバイダーが Web 認証ブローカーに対して SSO を有効にしており、*callbackUri * パラメーターを受け取らない [**AuthenticateAsync **](https://msdn.microsoft.com/library/windows/apps/br212068) のオーバーロードをアプリで呼び出す必要があります。

SSO をサポートするには、オンライン プロバイダーが `ms-app://`*appSID* 形式のリダイレクト URI の登録を許可している必要があります。*appSID* は、アプリの SID です。 アプリの SID は、アプリ開発者のページか、[**GetCurrentApplicationCallbackUri**](https://msdn.microsoft.com/library/windows/apps/br212069) メソッドを呼び出すことで確認できます。

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

## デバッグ


Web 認証ブローカー API のトラブルシューティングには、操作ログの確認や Fiddler を使った Web 要求と応答の確認など、いくつかの方法があります。

### 操作ログ

問題の原因の多くは、操作ログを使って特定できます。 Web サイト開発者向けの専用のイベント ログ チャネルである Microsoft-Windows-WebAuth\\Operational を使うと、Web 認証ブローカーで Web ページが処理される過程を把握できます。 これを有効にするには、eventvwr.exe を起動し、アプリケーションとサービス ログvices\\Microsoft\\Windows\\WebAuth で操作ログを有効にします。 また、Web 認証ブローカーは Web サーバー上で自身を識別するために、ユーザー エージェント文字列に一意の文字列を追加します。 その文字列は、"MSAuthHost/1.0" です。 バージョン番号は今後変更される可能性があるため、コード内のそれに依存しないようにしてください。 ユーザー エージェント文字列全体の例とデバッグの全ステップは次のとおりです。

`User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0; MSAuthHost/1.0)`

1.  操作ログを有効にします。
2.  Contoso ソーシャル アプリを実行します。 ![WebAuth 操作ログが表示されたイベント ビューアー](images/wab-event-viewer-1.png)
3.  生成されたログ エントリで、Web 認証ブローカーの動作を把握することができます。 この例では、次の情報を知ることができます。
    -   ナビゲーションの開始: AuthHost が開始された時点のログ。開始 URL と終了 URL に関する情報が含まれています。
    -   ![ナビゲーションの開始の例](images/wab-event-viewer-2.png)
    -   ナビゲーションの完了: Web ページの読み込み完了時のログ。
    -   メタ タグ: メタ タグが検出されたときのログ。詳しい情報を含みます。
    -   ナビゲーションの停止: ユーザーによって停止されたナビゲーション。
    -   ナビゲーション エラー: AuthHost が HttpStatusCode を含む URL でナビゲーション エラーを検出。
    -   ナビゲーションの終了: 終了 URL を検出。

### Fiddler

Fiddler Web デバッガーはアプリに対して使うことができます。

1.  AuthHost はプライベート ネットワーク機能を実現するために専用のアプリ コンテナー内で実行されるため、Windows Registry Editor Version 5.00 というレジストリ キーを設定する必要があります。

    **HKEY\_LOCAL\_MACHINE**\\**SOFTWARE**\\**Microsoft**\\**Windows NT**\\**CurrentVersion**\\**Image File Execution Options**\\**authhost.exe**\\**EnablePrivateNetwork** = 00000001

                         Data type  
                         DWORD

2.  送信トラフィックを生成するのは AuthHost であるため、AuthHost 用の規則を追加します。
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

3.  Fiddler への受信トラフィック用のファイアウォール規則を追加します。


<!--HONumber=Aug16_HO3-->


