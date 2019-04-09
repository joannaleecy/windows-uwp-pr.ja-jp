---
title: UWP で Webpush と VAPID を使用して代替のプッシュ チャネル
description: UWP アプリから VAPID プロトコルを使用した代替のプッシュ チャネルを使用して、手順
ms.date: 01/10/2017
ms.topic: article
keywords: windows 10、uwp、WinRT API では、WNS
localizationpriority: medium
ms.openlocfilehash: bf224b6c0997ce8af86ab2919a1d0513f619a8a3
ms.sourcegitcommit: 681c1e3836d2a51cd3b31d824ece344281932bcd
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59067827"
---
# <a name="alternate-push-channels-using-webpush-and-vapid-in-uwp"></a>UWP で Webpush と VAPID を使用して代替のプッシュ チャネル 
以降、Fall Creators Update では、UWP アプリを使用できます web プッシュ VAPID 認証を使用したプッシュ通知を送信します。  

## <a name="introduction"></a>概要
Web 標準のプッシュの導入により、web サイトは、アプリ、web サイトにユーザーが登録されていない場合でも、通知を送信するようにより機能できます。

仕入先でのプッシュのサーバーで認証する web サイト作成された VAPID 認証プロトコルに依存しない方法です。 VAPID プロトコルを使用して、すべてのベンダーと web サイトが実行されているブラウザーを知らなくてもプッシュ通知を送信することができます。 これは、各プラットフォームのプッシュのさまざまなプロトコルの実装を大幅に強化です。 

UWP アプリでは、こうしたメリットを使用したプッシュ通知を送信するのに webpush と VAPID を使用できます。 これらのプロトコルでは、新しいアプリの開発時間を節約でき、既存のアプリのクロス プラットフォーム サポートを簡略化することができます。 さらに、エンタープライズ アプリまたはアプリのサイドロードできますようになりましたなく通知を送信 Microsoft Store での登録します。 うまくいけば、これがすべてのプラットフォームでユーザーと交流する新しい方法を開きます。  

## <a name="alternate-channels"></a>代替チャネル 
UWP では、これらの VAPID チャネルは代替チャネルと呼ばれ、web のプッシュ チャネルと同様の機能を提供します。 1 つのアプリから複数のチャネルを許可して、アプリのバック グラウンド タスクを実行して、メッセージの暗号化を有効にするトリガーできます。 別のチャネルの種類の違いの詳細についてを参照してください[適切なチャネルを選択する](channel-types.md)します。

代替のチャネルを使用するは、プッシュ通知へのアクセス、アプリは、プライマリ チャネルを使用できない場合、または web サイトとアプリのコードを共有する場合に優れた方法です。 簡単では、web 標準のプッシュを使用するか、または前にプッシュ通知を Windows で作業するすべてのユーザーにとって馴染み深いは、チャネルを設定します。

## <a name="code-example"></a>コードの例

UWP アプリ用の別のチャネルの設定の基本的なプロセスは、プライマリまたはセカンダリ チャネルの設定に似ています。 最初に、チャネルでの登録、 [WNS server](windows-push-notification-services--wns--overview.md)します。 次に、バック グラウンド タスクとして実行する登録します。 通知が送信され、バック グラウンド タスクがトリガーされた、イベントを処理します。  

### <a name="get-a-channel"></a>チャネルを取得します。 
代替のチャネルを作成するには、アプリが 2 つの情報を提供する必要があります。 そのサーバーとそれを作成するチャネルの名前の公開キー。 サーバー キーに関する詳細については、web プッシュ仕様でがサーバーの標準的な web プッシュ ライブラリを使用するキーを生成することをお勧めします。  

チャネル ID は、アプリが複数の代替チャネルを作成するために特に重要です。 各チャネルは、そのチャネルを介して送信されるすべての通知ペイロードに含まれる一意の ID で識別される必要があります。  

```csharp
private async void AppCreateVAPIDChannelAsync(string appChannelId, IBuffer applicationServerKey) 
{ 
    // From the spec: applicationServer Key (p256dh):  
    //               An Elliptic curve Diffie–Hellman public key on the P-256 curve 
    //               (that is, the NIST secp256r1 elliptic curve).   
    //               The resulting key is an uncompressed point in ANSI X9.62 format             
    // ChannelId is an app provided value for it to identify the channel later.  
    // case of this app it is from the set { "Football", "News", "Baseball" } 
    PushNotificationChannel webChannel = await PushNotificationChannelManager.GetDefault().CreateRawPushNotificationChannelWithAlternateKeyForApplicationAsync(applicationServerKey, appChannelId); 
 
    //Save the channel  
    AppUpdateChannelMapping(appChannelId, webChannel); 
             
    //Tell our web service that we have a new channel to push notifications to 
    AppPassChannelToSite(webChannel.Uri); 
} 
```
アプリでは、そのサーバーへのバックアップのチャネルに送信し、ローカルに保存します。 チャネルの区別および期限切れにならないようにするためにチャネルを更新するアプリをチャネル ID をローカルに保存できます。

プッシュ通知チャネルの他の型がすべてのように、web のチャネルが期限切れできます。 チャネルが、アプリを知ることがなく期限切れにならないことを防ぐために、アプリが起動されるたびに新しいチャネルを作成します。    

### <a name="register-for-a-background-task"></a>バック グラウンド タスクに登録します。 

アプリには、代替のチャネルが作成、フォア グラウンドまたはバック グラウンドでの通知を受信するに登録する必要があります。 次の例は、バック グラウンドで通知を受信する 1 つのプロセス モデルを使用して登録します。  

```csharp
var builder = new BackgroundTaskBuilder(); 
builder.Name = "Push Trigger"; 
builder.SetTrigger(new PushNotificationTrigger()); 
BackgroundTaskRegistration task = builder.Register(); 
```
### <a name="receive-the-notifications"></a>通知を受け取る 

通知を受信するアプリを登録すると、受信した通知を処理できるように、必要があります。 1 つのアプリが複数のチャネルを登録するためには、通知を処理する前にチャネル ID を確認してください。  

```csharp
protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args) 
{ 
    base.OnBackgroundActivated(args); 
    var raw = args.TaskInstance.TriggerDetails as RawNotification; 
    switch (raw.ChannelId) 
    { 
        case "Football": 
            AppPostFootballScore(raw.Content); 
            break; 
        case "News": 
            AppProcessNewsItem(raw.Content); 
            break; 
        case "Baseball": 
            AppProcessBaseball(raw.Content); 
            break; 
 
        default: 
            //We don't have the channelID registered, should only happen in the case of a 
            //caching issue on the application server 
            break; 
    }                           
} 
```

プライマリ チャネルから通知が送られて場合に、チャネルの ID は設定されませんに注意してください。  

## <a name="note-on-encryption"></a>暗号化に注意してください。 

どのような暗号化方式をより役に立つアプリを使用できます。 場合によっては、標準の TLS サーバーとすべての Windows デバイスの間に依存するで十分です。 それ以外の場合、web プッシュ暗号化スキームまたは設計の別のスキームを使用する際に必要があります。  

別の形式の暗号化を使用する場合は、キー、生の使用です。ヘッダーのプロパティです。 すべてのプッシュのサーバーに POST 要求に含まれていた暗号化ヘッダーが含まれています。 そこから、アプリは、メッセージを解読するのにキーを使用できます。  

## <a name="related-topics"></a>関連トピック
- [通知チャンネルの種類](channel-types.md)
- [Windows プッシュ通知サービス (WNS)](windows-push-notification-services--wns--overview.md)
- [PushNotificationChannel クラス](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannel)
- [PushNotificationChannelManager クラス](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanager)


