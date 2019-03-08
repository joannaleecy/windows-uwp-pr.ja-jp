---
title: UWP で Webpush と VAPID を使用して代替のプッシュ チャネル
description: UWP アプリから VAPID プロトコルを使用した代替のプッシュ チャネルを使用して、手順
ms.date: 01/10/2017
ms.topic: article
keywords: windows 10、uwp、WinRT API では、WNS
localizationpriority: medium
ms.openlocfilehash: ba8630a2e877345adeac7eb443dd3e418d3ed277
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639527"
---
# <a name="alternate-push-channels-using-webpush-and-vapid-in-uwp"></a><span data-ttu-id="950fd-104">UWP で Webpush と VAPID を使用して代替のプッシュ チャネル</span><span class="sxs-lookup"><span data-stu-id="950fd-104">Alternate push channels using Webpush and VAPID in UWP</span></span> 
<span data-ttu-id="950fd-105">以降、Fall Creators Update では、UWP アプリを使用できます web プッシュ VAPID 認証を使用したプッシュ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="950fd-105">Starting in the Fall Creators Update, UWP apps can use web push with VAPID authentication to send push notifications.</span></span>  

## <a name="introduction"></a><span data-ttu-id="950fd-106">概要</span><span class="sxs-lookup"><span data-stu-id="950fd-106">Introduction</span></span>
<span data-ttu-id="950fd-107">Web 標準のプッシュの導入により、web サイトは、アプリ、web サイトにユーザーが登録されていない場合でも、通知を送信するようにより機能できます。</span><span class="sxs-lookup"><span data-stu-id="950fd-107">The introduction of the web push standard allows websites can act more like apps, sending notifications even when users aren’t on the website.</span></span>

<span data-ttu-id="950fd-108">仕入先でのプッシュのサーバーで認証する web サイト作成された VAPID 認証プロトコルに依存しない方法です。</span><span class="sxs-lookup"><span data-stu-id="950fd-108">The VAPID authentication protocol was created to allow websites to authenticate with push servers in a vendor agnostic way.</span></span> <span data-ttu-id="950fd-109">VAPID プロトコルを使用して、すべてのベンダーと web サイトが実行されているブラウザーを知らなくてもプッシュ通知を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="950fd-109">With all vendors using the VAPID protocol, websites can send push notifications without knowing the browser on which it is running.</span></span> <span data-ttu-id="950fd-110">これは、各プラットフォームのプッシュのさまざまなプロトコルの実装を大幅に強化です。</span><span class="sxs-lookup"><span data-stu-id="950fd-110">This is a significant improvement over implementing a different push protocol for each platform.</span></span> 

<span data-ttu-id="950fd-111">UWP アプリでは、こうしたメリットを使用したプッシュ通知を送信するのに webpush と VAPID を使用できます。</span><span class="sxs-lookup"><span data-stu-id="950fd-111">UWP apps can use webpush and VAPID to send push notifications with these advantages, as well.</span></span> <span data-ttu-id="950fd-112">これらのプロトコルでは、新しいアプリの開発時間を節約でき、既存のアプリのクロス プラットフォーム サポートを簡略化することができます。</span><span class="sxs-lookup"><span data-stu-id="950fd-112">These protocols can save development time for new apps and simplify cross platform support for existing apps.</span></span> <span data-ttu-id="950fd-113">さらに、エンタープライズ アプリまたはアプリのサイドロードできますようになりましたなく通知を送信 Microsoft Store での登録します。</span><span class="sxs-lookup"><span data-stu-id="950fd-113">Additionally, enterprise apps or sideloaded apps can now send notifications without registering in the Microsoft Store.</span></span> <span data-ttu-id="950fd-114">うまくいけば、これがすべてのプラットフォームでユーザーと交流する新しい方法を開きます。</span><span class="sxs-lookup"><span data-stu-id="950fd-114">Hopefully, this will open up new ways to engage with users across all platforms.</span></span>  

## <a name="alternate-channels"></a><span data-ttu-id="950fd-115">代替チャネル</span><span class="sxs-lookup"><span data-stu-id="950fd-115">Alternate channels</span></span> 
<span data-ttu-id="950fd-116">UWP では、これらの VAPID チャネルは代替チャネルと呼ばれ、web のプッシュ チャネルと同様の機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="950fd-116">In UWP, these VAPID channels are called alternate channels and provide similar functionality to a web push channel.</span></span> <span data-ttu-id="950fd-117">1 つのアプリから複数のチャネルを許可して、アプリのバック グラウンド タスクを実行して、メッセージの暗号化を有効にするトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="950fd-117">They can trigger an app background task to run, enable message encryption, and allow for multiple channels from a single app.</span></span> <span data-ttu-id="950fd-118">別のチャネルの種類の違いの詳細についてを参照してください[適切なチャネルを選択する](channel-types.md)します。</span><span class="sxs-lookup"><span data-stu-id="950fd-118">For more information about the difference between the different channel types, please see [Choosing the right channel](channel-types.md).</span></span>

<span data-ttu-id="950fd-119">代替のチャネルを使用するは、プッシュ通知へのアクセス、アプリは、プライマリ チャネルを使用できない場合、または web サイトとアプリのコードを共有する場合に優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="950fd-119">Using alternate channels is a great way to access push notifications if your app can’t use a primary channel or if you want to share code between your website and app.</span></span> <span data-ttu-id="950fd-120">簡単では、web 標準のプッシュを使用するか、または前にプッシュ通知を Windows で作業するすべてのユーザーにとって馴染み深いは、チャネルを設定します。</span><span class="sxs-lookup"><span data-stu-id="950fd-120">Setting up a channel is easy and familiar to anyone who has either used the web push standard or worked with Windows push notifications before.</span></span>

## <a name="code-example"></a><span data-ttu-id="950fd-121">コードの例</span><span class="sxs-lookup"><span data-stu-id="950fd-121">Code example</span></span>

<span data-ttu-id="950fd-122">UWP アプリ用の別のチャネルの設定の基本的なプロセスは、プライマリまたはセカンダリ チャネルの設定に似ています。</span><span class="sxs-lookup"><span data-stu-id="950fd-122">The basic process of setting up an alternate channel for a UWP app is similar to setting up a primary or secondary channel.</span></span> <span data-ttu-id="950fd-123">最初に、チャネルでの登録、 [WNS server](windows-push-notification-services--wns--overview.md)します。</span><span class="sxs-lookup"><span data-stu-id="950fd-123">First, register for a channel with the [WNS server](windows-push-notification-services--wns--overview.md).</span></span> <span data-ttu-id="950fd-124">次に、バック グラウンド タスクとして実行する登録します。</span><span class="sxs-lookup"><span data-stu-id="950fd-124">Then, register to run as a background task.</span></span> <span data-ttu-id="950fd-125">通知が送信され、バック グラウンド タスクがトリガーされた、イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="950fd-125">After the notification is sent and the background task is triggered, handle the event.</span></span>  

### <a name="get-a-channel"></a><span data-ttu-id="950fd-126">チャネルを取得します。</span><span class="sxs-lookup"><span data-stu-id="950fd-126">Get a channel</span></span> 
<span data-ttu-id="950fd-127">代替のチャネルを作成するには、アプリが 2 つの情報を提供する必要があります。 そのサーバーとそれを作成するチャネルの名前の公開キー。</span><span class="sxs-lookup"><span data-stu-id="950fd-127">To create an alternate channel, the app must provide two pieces of information: the public key for its server and the name of the channel it is creating.</span></span> <span data-ttu-id="950fd-128">サーバー キーに関する詳細については、web プッシュ仕様でがサーバーの標準的な web プッシュ ライブラリを使用するキーを生成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="950fd-128">The details about the server keys are available in the web push spec, but we recommend using a standard web push library on the server to generate the keys.</span></span>  

<span data-ttu-id="950fd-129">チャネル ID は、アプリが複数の代替チャネルを作成するために特に重要です。</span><span class="sxs-lookup"><span data-stu-id="950fd-129">The channel ID is particularly important because an app can create multiple alternate channels.</span></span> <span data-ttu-id="950fd-130">各チャネルは、そのチャネルを介して送信されるすべての通知ペイロードに含まれる一意の ID で識別される必要があります。</span><span class="sxs-lookup"><span data-stu-id="950fd-130">Each channel must be identified by a unique ID that will be included with any notification payloads sent along that channel.</span></span>  

```csharp
private async void AppCreateVAPIDChannelAsync(string appChannelId, IBuffer applicationServerKey) 
{ 
    // From the spec: applicationServer Key (p256dh):  
    //               An Elliptic curve Diffie–Hellman public key on the P-256 curve 
    //               (that is, the NIST secp256r1 elliptic curve).   
    //               The resulting key is an uncompressed point in ANSI X9.62 format             
    // ChannelId is an app provided value for it to identify the channel later.  
    // case of this app it is from the set { "Football", "News", "Baseball" } 
    PushNotificationChannel webChannel = await PushNotificationChannelManager.Current.CreateRawPushNotificationChannelWithAlternateKeyForApplicationAsync(applicationServerKey, appChannelId); 
 
    //Save the channel  
    AppUpdateChannelMapping(appChannelId, webChannel); 
             
    //Tell our web service that we have a new channel to push notifications to 
    AppPassChannelToSite(webChannel.Uri); 
} 
```
<span data-ttu-id="950fd-131">アプリでは、そのサーバーへのバックアップのチャネルに送信し、ローカルに保存します。</span><span class="sxs-lookup"><span data-stu-id="950fd-131">The app sends the channel back up to its server and saves it locally.</span></span> <span data-ttu-id="950fd-132">チャネルの区別および期限切れにならないようにするためにチャネルを更新するアプリをチャネル ID をローカルに保存できます。</span><span class="sxs-lookup"><span data-stu-id="950fd-132">Saving the channel ID locally allows the app to differentiate between channels and renew channels in order to prevent them from expiring.</span></span>

<span data-ttu-id="950fd-133">プッシュ通知チャネルの他の型がすべてのように、web のチャネルが期限切れできます。</span><span class="sxs-lookup"><span data-stu-id="950fd-133">Like every other type of push notification channel, web channels can expire.</span></span> <span data-ttu-id="950fd-134">チャネルが、アプリを知ることがなく期限切れにならないことを防ぐために、アプリが起動されるたびに新しいチャネルを作成します。</span><span class="sxs-lookup"><span data-stu-id="950fd-134">To prevent channels from expiring without your app knowing, create a new channel every time your app is launched.</span></span>    

### <a name="register-for-a-background-task"></a><span data-ttu-id="950fd-135">バック グラウンド タスクに登録します。</span><span class="sxs-lookup"><span data-stu-id="950fd-135">Register for a background task</span></span> 

<span data-ttu-id="950fd-136">アプリには、代替のチャネルが作成、フォア グラウンドまたはバック グラウンドでの通知を受信するに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="950fd-136">Once your app has created an alternate channel, it should register to receive the notifications either in the foreground or the background.</span></span> <span data-ttu-id="950fd-137">次の例は、バック グラウンドで通知を受信する 1 つのプロセス モデルを使用して登録します。</span><span class="sxs-lookup"><span data-stu-id="950fd-137">The example below registers to use the one-process model to receive the notifications in the background.</span></span>  

```csharp
var builder = new BackgroundTaskBuilder(); 
builder.Name = "Push Trigger"; 
builder.SetTrigger(new PushNotificationTrigger()); 
BackgroundTaskRegistration task = builder.Register(); 
```
### <a name="receive-the-notifications"></a><span data-ttu-id="950fd-138">通知を受け取る</span><span class="sxs-lookup"><span data-stu-id="950fd-138">Receive the notifications</span></span> 

<span data-ttu-id="950fd-139">通知を受信するアプリを登録すると、受信した通知を処理できるように、必要があります。</span><span class="sxs-lookup"><span data-stu-id="950fd-139">Once the app has registered to receive the notifications, it needs to be able to process the incoming notifications.</span></span> <span data-ttu-id="950fd-140">1 つのアプリが複数のチャネルを登録するためには、通知を処理する前にチャネル ID を確認してください。</span><span class="sxs-lookup"><span data-stu-id="950fd-140">Since a single app can register multiple channels, be sure to check the channel ID before processing the notification.</span></span>  

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

<span data-ttu-id="950fd-141">プライマリ チャネルから通知が送られて場合に、チャネルの ID は設定されませんに注意してください。</span><span class="sxs-lookup"><span data-stu-id="950fd-141">Note that if the notification is coming from a primary channel, then the channel ID will not be set.</span></span>  

## <a name="note-on-encryption"></a><span data-ttu-id="950fd-142">暗号化に注意してください。</span><span class="sxs-lookup"><span data-stu-id="950fd-142">Note on encryption</span></span> 

<span data-ttu-id="950fd-143">どのような暗号化方式をより役に立つアプリを使用できます。</span><span class="sxs-lookup"><span data-stu-id="950fd-143">You can use whatever encryption scheme you find more useful for your app.</span></span> <span data-ttu-id="950fd-144">場合によっては、標準の TLS サーバーとすべての Windows デバイスの間に依存するで十分です。</span><span class="sxs-lookup"><span data-stu-id="950fd-144">In some cases, it is enough to rely on the TLS standard between the server and any Windows device.</span></span> <span data-ttu-id="950fd-145">それ以外の場合、web プッシュ暗号化スキームまたは設計の別のスキームを使用する際に必要があります。</span><span class="sxs-lookup"><span data-stu-id="950fd-145">In other cases, it might make more sense to use the web push encryption scheme, or another scheme of your design.</span></span>  

<span data-ttu-id="950fd-146">別の形式の暗号化を使用する場合は、キー、生の使用です。ヘッダーのプロパティです。</span><span class="sxs-lookup"><span data-stu-id="950fd-146">If you wish to use another form of encryption, the key is the use the raw.Headers property.</span></span> <span data-ttu-id="950fd-147">すべてのプッシュのサーバーに POST 要求に含まれていた暗号化ヘッダーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="950fd-147">It contains all of the encryption headers that were included in the POST request to the push server.</span></span> <span data-ttu-id="950fd-148">そこから、アプリは、メッセージを解読するのにキーを使用できます。</span><span class="sxs-lookup"><span data-stu-id="950fd-148">From there, your app can use the keys to decrypt the message.</span></span>  

## <a name="related-topics"></a><span data-ttu-id="950fd-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="950fd-149">Related topics</span></span>
- [<span data-ttu-id="950fd-150">通知チャネルの種類</span><span class="sxs-lookup"><span data-stu-id="950fd-150">Notification channel types</span></span>](channel-types.md)
- [<span data-ttu-id="950fd-151">Windows プッシュ通知サービス (WNS)</span><span class="sxs-lookup"><span data-stu-id="950fd-151">Windows Push Notification Services (WNS)</span></span>](windows-push-notification-services--wns--overview.md)
- [<span data-ttu-id="950fd-152">PushNotificationChannel クラス</span><span class="sxs-lookup"><span data-stu-id="950fd-152">PushNotificationChannel class</span></span>](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannel)
- [<span data-ttu-id="950fd-153">PushNotificationChannelManager クラス</span><span class="sxs-lookup"><span data-stu-id="950fd-153">PushNotificationChannelManager class</span></span>](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanager)


