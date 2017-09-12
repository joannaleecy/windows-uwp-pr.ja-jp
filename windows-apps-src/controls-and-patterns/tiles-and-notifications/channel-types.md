---
author: adwilso
Description: "Windows プッシュ通知サービス (WNS) を利用することで、サード パーティの開発者が独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。 アプリケーションのニーズに応じて、通知を送信するさまざまな方法があります。"
title: "適切なプッシュ通知チャネルの種類を選択する"
ms.author: mijacobs
ms.date: 07/07/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: e6af1c2708c220467ed56669f836ef46149143e4
ms.sourcegitcommit: 0fa9ae00117e8e6b04ed38956e605bb74c1261c6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/07/2017
---
# <a name="choosing-the-right-push-notification-channel-type"></a><span data-ttu-id="f0a4d-105">適切なプッシュ通知チャネルの種類を選択する</span><span class="sxs-lookup"><span data-stu-id="f0a4d-105">Choosing the right push notification channel type</span></span>

<span data-ttu-id="f0a4d-106">この記事では、アプリのコンテンツの提供に役立つ、3 つの種類の UWP プッシュ通知 (プライマリ、セカンダリ、および代替) について説明します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-106">This article covers the three types of UWP push notification channels (primary, secondary, and alternate) that help you deliver content to your app.</span></span> 

<span data-ttu-id="f0a4d-107">(プッシュ通知の作成について詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](../tiles-and-notifications-windows-push-notification-services--wns--overview.md)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="f0a4d-107">(For details on how to create push notifications, see the the [Windows Push Notification Services (WNS) overview](../tiles-and-notifications-windows-push-notification-services--wns--overview.md).)</span></span> 

## <a name="types-of-push-channels"></a><span data-ttu-id="f0a4d-108">プッシュ チャネルの種類</span><span class="sxs-lookup"><span data-stu-id="f0a4d-108">Types of push channels</span></span> 

<span data-ttu-id="f0a4d-109">UWP アプリに通知を送信するために使用される、3 種類のプッシュ チャネルがあります。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-109">There are three types of push channels that can be used to send notifications to a UWP app.</span></span> <span data-ttu-id="f0a4d-110">それらは以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-110">They are:</span></span> 

<span data-ttu-id="f0a4d-111">[プライマリ チャネル](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - "従来型" のプッシュ チャネルです。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-111">[Primary channel](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - the "traditional" push channel.</span></span> <span data-ttu-id="f0a4d-112">任意のストア アプリで、トースト通知、タイル通知、直接通知、バッジ通知 (トースト、タイル、バッジの説明へのリンク) の送信に使用できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-112">Can be used by any app in the store to send toast, tile, raw, or badge notifications (Link to descriptions of toast/tiles/badge)</span></span>

<span data-ttu-id="f0a4d-113">[セカンダリ タイルのチャネル](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - セカンダリ タイルへのタイルの更新をプッシュするために使用します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-113">[Secondary tile channel](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - used to push tile updates for a secondary tile.</span></span> <span data-ttu-id="f0a4d-114">ユーザーのスタート画面にピン留めされているセカンダリ タイルに、タイルやバッジ通知を送信するためのみに使用できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-114">Can only be used to send tile or badge notifications to a secondary tile pinned on the user's start screen</span></span>

<span data-ttu-id="f0a4d-115">[代替チャネル](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - Creators Update で追加された新しい種類のチャネルです。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-115">[Alternate channel](https://docs.microsoft.com/en-us/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#methods_) - A new type of channel added in the Creators Update.</span></span> <span data-ttu-id="f0a4d-116">ストアに登録されていないアプリを含め、任意の UWP アプリに直接通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-116">It allows for raw notifications to be sent to any UWP app, including those which aren't registered in the Store.</span></span> 

> [!NOTE]
> <span data-ttu-id="f0a4d-117">どのプッシュ チャネルを使用する場合でも、アプリがデバイスで実行されると、ローカルのトースト、タイル、バッジ通知をいつでも送信することができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-117">No matter which push channel you use, once your app is running on the device, it will always be able to send local toast, tile, or badge notifications.</span></span> <span data-ttu-id="f0a4d-118">アプリは、フォア グラウンド アプリ プロセスまたはバック グラウンド タスクから、ローカル通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-118">It can send local notifications from the foreground app processes or from a background task.</span></span> 


## <a name="primary-channels"></a><span data-ttu-id="f0a4d-119">プライマリ チャネル</span><span class="sxs-lookup"><span data-stu-id="f0a4d-119">Primary channels</span></span>

<span data-ttu-id="f0a4d-120">これは、Windows で現在、最も一般的に使用されているチャネルです。Windows ストアを通じて配布されるアプリのほとんどのシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-120">These are the most commonly used channels on Windows right now, and are good for almost any scenario where your app is going to be distributed through the Windows Store.</span></span> <span data-ttu-id="f0a4d-121">アプリにすべての種類の通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-121">They allow you to send all types of notifications to the app.</span></span> 

### <a name="what-do-primary-channels-enable"></a><span data-ttu-id="f0a4d-122">プライマリ チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="f0a4d-122">What do primary channels enable?</span></span>

-   **<span data-ttu-id="f0a4d-123">プライマリ タイルへのタイルやバッジの更新を送信します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-123">Sending tile or badge updates to the primary tile.</span></span>** <span data-ttu-id="f0a4d-124">ユーザーがスタート画面にタイルをピン留めした場合、プライマリ チャネルの効果を発揮できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-124">If the user has chosen to pin your tile to the start screen, this is your chance to show off.</span></span> <span data-ttu-id="f0a4d-125">アプリ内で、役に立つ情報の更新やエクスペリエンスのリマインダーを送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-125">Send updates with useful information or reminders of experiences within your app.</span></span> 
-   **<span data-ttu-id="f0a4d-126">トースト通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-126">Sending toast notifications.</span></span>** <span data-ttu-id="f0a4d-127">トースト通知を使うと、ユーザーの前に直ちに情報を提供できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-127">Toast notifications are a chance to get some information in front of the user immediately.</span></span> <span data-ttu-id="f0a4d-128">シェルによりほとんどのアプリの一番上に描画され、さらにアクション センターに残るため、ユーザーは後から参照して操作することができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-128">They are painted by the shell over top of most apps, and live in the action center so the user can go back and interact with them later.</span></span> 
-   **<span data-ttu-id="f0a4d-129">バックグラウンド タスクをトリガーする直接通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-129">Sending raw notifications to trigger a background task.</span></span>** <span data-ttu-id="f0a4d-130">通知に基づいて、ユーザーに代わって作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-130">Sometimes you want to do some work on behalf of the user based on a notification.</span></span> <span data-ttu-id="f0a4d-131">直接通知を使うと、アプリのバック グラウンド タスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-131">Raw notifications allow your app's background tasks to run</span></span> 
-   **<span data-ttu-id="f0a4d-132">Windows は TLS を使用して、転送中のメッセージを暗号化します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-132">Message encryption in transit provided by Windows using TLS.</span></span>** <span data-ttu-id="f0a4d-133">ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-133">Messages are encrypted on the wire both coming into WNS and going to the user's device.</span></span>  

### <a name="limitations-of-primary-channels"></a><span data-ttu-id="f0a4d-134">プライマリ チャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="f0a4d-134">Limitations of primary channels</span></span>

-   <span data-ttu-id="f0a4d-135">デバイス ベンダー間で標準ではないプッシュ通知には、WNS REST API を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-135">Requires using the WNS REST API to push notifications, which isn't standard across device vendors.</span></span> 
-   <span data-ttu-id="f0a4d-136">アプリごとに 1 つだけのチャネルを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-136">Only one channel can be created per app</span></span> 
-   <span data-ttu-id="f0a4d-137">アプリを Windows ストアに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-137">Requires your app to be registered in the Windows Store</span></span>

### <a name="creating-a-primary-channel"></a><span data-ttu-id="f0a4d-138">プライマリ チャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="f0a4d-138">Creating a primary channel</span></span> 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
```

## <a name="secondary-tile-channels"></a><span data-ttu-id="f0a4d-139">セカンダリ タイル チャネル</span><span class="sxs-lookup"><span data-stu-id="f0a4d-139">Secondary tile channels</span></span>

<span data-ttu-id="f0a4d-140">セカンダリ タイルへタイルとバッジの更新をプッシュするために使用できるチャネルです。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-140">These are channels that can be used to push tile and badge updates to a secondary tile.</span></span> <span data-ttu-id="f0a4d-141">アプリが使用して、ユーザーに関心のあるアクションを通知したり、アプリで操作できる情報を通知したりできます。たとえば、グループ チャットの新しいメッセージや試合のスコアの最新情報などです。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-141">These are used by apps to notify users of interesting actions or information that they can interact with in the app, such as new messages in a group chat or an updated sports score.</span></span> 

### <a name="what-do-secondary-tile-channels-enable"></a><span data-ttu-id="f0a4d-142">セカンダリ タイル チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="f0a4d-142">What do secondary tile channels enable?</span></span>

-   <span data-ttu-id="f0a4d-143">セカンダリ タイルにタイル通知またはバッジ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-143">Sending tile or badge notifications to secondary tiles.</span></span> <span data-ttu-id="f0a4d-144">セカンダリ タイルは、ユーザーがアプリを繰り返して使うための優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-144">Secondary tiles are a great way to pull users back into your app.</span></span> <span data-ttu-id="f0a4d-145">セカンダリ タイルは、ユーザーが関心を持つ情報へのディープ リンクです。タイルにユーザーが関心を持つ情報を表示することにより、アプリを繰り返して使用するようにできます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-145">They are a deep link to information they care about, and putting relevant information on the tiles helps to bring them back again and again.</span></span>
-   <span data-ttu-id="f0a4d-146">さまざまなタイル間のチャネルを分離 (期限切れに) します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-146">Separation of channels (and expiries) between various tiles.</span></span> <span data-ttu-id="f0a4d-147">これにより、ユーザーによってスタート画面にピン留めされた、さまざまな種類のセカンダリ タイルの間で、バックエンドのロジックを分離することができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-147">This allows you to separate the logic in the backend between the various types of secondary tiles that a user might pin to their start screen.</span></span> 
-   <span data-ttu-id="f0a4d-148">Windows は TLS を使用して、転送中のメッセージを暗号化します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-148">Message encryption in transit provided by Windows using TLS.</span></span> <span data-ttu-id="f0a4d-149">ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-149">Messages are encrypted on the wire both coming into WNS and going to the user's device.</span></span>  

### <a name="limitations-of-secondary-tile-channels"></a><span data-ttu-id="f0a4d-150">セカンダリ タイルのチャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="f0a4d-150">Limitations of secondary tile channels</span></span>

-   <span data-ttu-id="f0a4d-151">トースト通知または直接通知はできません。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-151">No toast or raw notifications allowed.</span></span> <span data-ttu-id="f0a4d-152">セカンダリ タイルに送信されるトースト通知または直接通知は、システムによって無視されます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-152">Toast or raw notifications sent to a secondary tile are ignored by the system.</span></span>
-   <span data-ttu-id="f0a4d-153">アプリを Windows ストアに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-153">Requires your app to be registered in the Windows Store</span></span>


### <a name="creating-a-secondary-tile-channel"></a><span data-ttu-id="f0a4d-154">セカンダリ タイルのチャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="f0a4d-154">Creating a secondary tile channel</span></span> 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForSecondaryTileAsync(tileId);
```

## <a name="alternate-channels"></a><span data-ttu-id="f0a4d-155">代替チャネル</span><span class="sxs-lookup"><span data-stu-id="f0a4d-155">Alternate channels</span></span>

<span data-ttu-id="f0a4d-156">代替チャネルを使うと、アプリは、Windows ストアへ登録したりアプリに作成されたプライマリ チャネル以外にプッシュ チャネルを作成したりすることなく、プッシュ通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-156">Alternate channels enable apps to send push notifications without registering to the Windows Store or creating push channels outside of the primary one used for the app.</span></span> 
 
### <a name="what-do-alternate-channels-enable"></a><span data-ttu-id="f0a4d-157">代替チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="f0a4d-157">What do alternate channels enable?</span></span>
-   <span data-ttu-id="f0a4d-158">任意の Windows デバイスで実行されている UWP への直接プッシュ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-158">Send raw push notifications to a UWP running on any Windows device.</span></span> <span data-ttu-id="f0a4d-159">代替チャネルのみが直接通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-159">Alternate channels only allow for raw notifications.</span></span>
-   <span data-ttu-id="f0a4d-160">アプリは、アプリ内でのさまざまな機能のために、複数の直接プッシュ チャネルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-160">Allows apps to create multiple raw push channels for different features within the app.</span></span> <span data-ttu-id="f0a4d-161">アプリは、最大 1000 の代替チャネルを作成できます。各チャネルは 30 日間有効です。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-161">An app can create up to 1000 alternate channels, and each one is valid for 30 days.</span></span> <span data-ttu-id="f0a4d-162">アプリは各チャネルを個別に管理したり、取り消したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-162">Each of these channels can be managed or revoked separately by the app.</span></span>
-   <span data-ttu-id="f0a4d-163">代替プッシュ チャネルは、アプリを Windows ストアに登録することなく、作成できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-163">Alternate push channels can be created without registering an app with the Windows Store.</span></span> <span data-ttu-id="f0a4d-164">アプリを Windows ストアに登録することなく、デバイスにインストールする場合でも、プッシュ通知を受信することができます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-164">If you app is going to be installed on devices without registering it in the Windows Store, it will still be able to receive push notifications.</span></span>
-   <span data-ttu-id="f0a4d-165">サーバーは、W3C 標準の REST API および VAPID プロトコルを使用して、通知をプッシュできます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-165">Servers can push notifications using the W3C standard REST APIs and VAPID protocol.</span></span> <span data-ttu-id="f0a4d-166">代替チャネルは、W3C 標準プロトコルを使用します。これにより、保守が必要なサーバー ロジックを簡素化できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-166">Alternate channels use the W3C standard protocol, this allows you to simplify the server logic that needs to be maintained.</span></span>
-   <span data-ttu-id="f0a4d-167">エンド ツー エンドでメッセージの完全な暗号化を行います。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-167">Full, end-to-end, message encryption.</span></span> <span data-ttu-id="f0a4d-168">プライマリ チャネルは転送中の暗号化を提供しますが、より高いセキュリティを必要とする場合には、代替チャネルを使うと、アプリは暗号化ヘッダーをパス スルーしてメッセージを保護できます。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-168">While the primary channel provides encryption while in transit, if you want to be extra secure, alternate channels enable your app to pass through encryption headers to protect a message.</span></span> 

### <a name="limitations-of-alternate-channels"></a><span data-ttu-id="f0a4d-169">代替チャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="f0a4d-169">Limitations of alternate channels</span></span>
-   <span data-ttu-id="f0a4d-170">アプリは、トースト通知、タイル通知、バッジ通知を送信できません。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-170">Apps cannot send toast, tile, or badge type notifications.</span></span> <span data-ttu-id="f0a4d-171">代替チャネルは、他の種類の通知の送信機能を制限します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-171">The alternate channel limits your ability to send other notification types.</span></span> <span data-ttu-id="f0a4d-172">アプリは、バック グラウンド タスクから、ローカル通知を送信することは可能です。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-172">Your app is still able to send local notifications from your background task.</span></span> 
-   <span data-ttu-id="f0a4d-173">プライマリ チャネルやセカンダリ タイルのチャネルとは異なる REST API が必要です。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-173">Requires a different REST API than either primary or secondary tile channels.</span></span> <span data-ttu-id="f0a4d-174">標準 W3C REST API を使用するため、アプリでは、トーストやタイルのプッシュ更新を送信するロジックとは異なるロジックを必要とします。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-174">Using the standard W3C REST API means that your app will need to have different logic for sending push toast or tile updates</span></span>

### <a name="creating-an-alternate-channel"></a><span data-ttu-id="f0a4d-175">代替チャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="f0a4d-175">Creating an alternate channel</span></span> 

```csharp
PushNotificationChannel webChannel = 
    await PushNotificationChannelManager.Current.CreateRawPushNotificationChannelWithAlternateKeyForApplicationAsync(applicationServerKey, appChannelId);
```

## <a name="channel-type-comparison"></a><span data-ttu-id="f0a4d-176">チャネルの種類の比較</span><span class="sxs-lookup"><span data-stu-id="f0a4d-176">Channel type comparison</span></span>
<span data-ttu-id="f0a4d-177">さまざまな種類のチャネルの比較表を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-177">Here is a quick comparison between the different types of channels:</span></span>

<table>

<tr class="header">
<th align="left">**<span data-ttu-id="f0a4d-178">種類</span><span class="sxs-lookup"><span data-stu-id="f0a4d-178">Type</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-179">トーストをプッシュする</span><span class="sxs-lookup"><span data-stu-id="f0a4d-179">Push toast?</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-180">タイルバッジをプッシュする</span><span class="sxs-lookup"><span data-stu-id="f0a4d-180">Push tile/badge?</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-181">直接通知をプッシュする</span><span class="sxs-lookup"><span data-stu-id="f0a4d-181">Push raw notifications?</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-182">認証</span><span class="sxs-lookup"><span data-stu-id="f0a4d-182">Authentication</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-183">API</span><span class="sxs-lookup"><span data-stu-id="f0a4d-183">API</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-184">ストアへの登録の必要性</span><span class="sxs-lookup"><span data-stu-id="f0a4d-184">Store registration required?</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-185">チャネル</span><span class="sxs-lookup"><span data-stu-id="f0a4d-185">Channels</span></span>**</th>
<th align="left">**<span data-ttu-id="f0a4d-186">暗号化</span><span class="sxs-lookup"><span data-stu-id="f0a4d-186">Encryption</span></span>**</th>
</tr>


<tr class="odd">
<td align="left"><span data-ttu-id="f0a4d-187">プライマリ</span><span class="sxs-lookup"><span data-stu-id="f0a4d-187">Primary</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-188">〇</span><span class="sxs-lookup"><span data-stu-id="f0a4d-188">Yes</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-189">〇 - プライマリ タイルのみ</span><span class="sxs-lookup"><span data-stu-id="f0a4d-189">Yes - primary tile only</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-190">〇</span><span class="sxs-lookup"><span data-stu-id="f0a4d-190">Yes</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-191">OAuth</span><span class="sxs-lookup"><span data-stu-id="f0a4d-191">OAuth</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-192">WNS REST API</span><span class="sxs-lookup"><span data-stu-id="f0a4d-192">WNS REST API</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-193">〇</span><span class="sxs-lookup"><span data-stu-id="f0a4d-193">Yes</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-194">アプリごとに 1 つ</span><span class="sxs-lookup"><span data-stu-id="f0a4d-194">One per app</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-195">転送中</span><span class="sxs-lookup"><span data-stu-id="f0a4d-195">In Transit</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="f0a4d-196">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="f0a4d-196">Secondary Tile</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-197">X</span><span class="sxs-lookup"><span data-stu-id="f0a4d-197">No</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-198">〇 - セカンダリ タイルのみ</span><span class="sxs-lookup"><span data-stu-id="f0a4d-198">Yes - secondary tile only</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-199">X</span><span class="sxs-lookup"><span data-stu-id="f0a4d-199">No</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-200">OAuth</span><span class="sxs-lookup"><span data-stu-id="f0a4d-200">OAuth</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-201">WNS REST API</span><span class="sxs-lookup"><span data-stu-id="f0a4d-201">WNS REST API</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-202">〇</span><span class="sxs-lookup"><span data-stu-id="f0a4d-202">Yes</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-203">セカンダリ タイルごとに 1 つ</span><span class="sxs-lookup"><span data-stu-id="f0a4d-203">One per secondary tile</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-204">転送中</span><span class="sxs-lookup"><span data-stu-id="f0a4d-204">In Transit</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="f0a4d-205">代替</span><span class="sxs-lookup"><span data-stu-id="f0a4d-205">Alternate</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-206">X</span><span class="sxs-lookup"><span data-stu-id="f0a4d-206">No</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-207">X</span><span class="sxs-lookup"><span data-stu-id="f0a4d-207">No</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-208">〇</span><span class="sxs-lookup"><span data-stu-id="f0a4d-208">Yes</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-209">VAPID</span><span class="sxs-lookup"><span data-stu-id="f0a4d-209">VAPID</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-210">WebPush W3C 標準</span><span class="sxs-lookup"><span data-stu-id="f0a4d-210">WebPush W3C Standard</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-211">X</span><span class="sxs-lookup"><span data-stu-id="f0a4d-211">No</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-212">アプリあたり 1,000</span><span class="sxs-lookup"><span data-stu-id="f0a4d-212">1,000 per app</span></span></td>
<td align="left"><span data-ttu-id="f0a4d-213">転送中 + ヘッダー パススルーによりエンドツーエンドの暗号化が可能 (アプリ コードが必要)</span><span class="sxs-lookup"><span data-stu-id="f0a4d-213">In transit + end to end encryption possible with header pass through (requires app code)</span></span></td>
</tr>
</table>

## <a name="choosing-the-right-channel"></a><span data-ttu-id="f0a4d-214">適切なチャンネルを選択する</span><span class="sxs-lookup"><span data-stu-id="f0a4d-214">Choosing the right channel</span></span>

<span data-ttu-id="f0a4d-215">一般に、いくつかの例外を除き、アプリではプライマリ チャネルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-215">In general, we recommend using the primary channel in your app, with a few exceptions:</span></span> 

1. <span data-ttu-id="f0a4d-216">セカンダリ タイルにタイルの更新をプッシュする場合は、セカンダリ タイルのプッシュ チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-216">If you are pushing a tile update to a secondary tile, use the secondary tile push channel.</span></span>
2. <span data-ttu-id="f0a4d-217">他のサービス (ブラウザーの場合など) にチャネルを渡す場合には、代替チャンネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-217">If you are passing out channels to other services (such as in the case of a browser) use the alternate channel.</span></span>
3. <span data-ttu-id="f0a4d-218">Windows ストアに登録しないアプリ (LOB アプリなど) を作成する場合、代替チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-218">If you are creating an app that won't be listed in the Windows store (such as an LOB app) use an alternate channel.</span></span>
4. <span data-ttu-id="f0a4d-219">サーバーにある既存の Web プッシュ コードを再利用する場合や、バックエンド サービスで複数のチャネルの必要性がある場合には、代替チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f0a4d-219">If you have existing web push code on your server you wish to reuse or have a need for multiple channels in your backend service, use alternate channels.</span></span>

## <a name="related-articles"></a><span data-ttu-id="f0a4d-220">関連記事</span><span class="sxs-lookup"><span data-stu-id="f0a4d-220">Related articles</span></span>

* [<span data-ttu-id="f0a4d-221">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="f0a4d-221">Send a local tile notification</span></span>](../tiles-and-notifications-sending-a-local-tile-notification.md)
* [<span data-ttu-id="f0a4d-222">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="f0a4d-222">Adaptive and interactive toast notifications</span></span>](../tiles-and-notifications-adaptive-interactive-toasts.md)
* [<span data-ttu-id="f0a4d-223">クイック スタート: プッシュ通知の送信</span><span class="sxs-lookup"><span data-stu-id="f0a4d-223">Quickstart: Sending a push notification</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)
* [<span data-ttu-id="f0a4d-224">プッシュ通知を使用してバッジを更新する方法</span><span class="sxs-lookup"><span data-stu-id="f0a4d-224">How to update a badge through push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [<span data-ttu-id="f0a4d-225">通知チャネルを要求、作成、保存する方法</span><span class="sxs-lookup"><span data-stu-id="f0a4d-225">How to request, create, and save a notification channel</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465412)
* [<span data-ttu-id="f0a4d-226">実行中のアプリの通知を中断する方法</span><span class="sxs-lookup"><span data-stu-id="f0a4d-226">How to intercept notifications for running applications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [<span data-ttu-id="f0a4d-227">Windows プッシュ通知サービス (WNS) に対して認証する方法</span><span class="sxs-lookup"><span data-stu-id="f0a4d-227">How to authenticate with the Windows Push Notification Service (WNS)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465407)
* [<span data-ttu-id="f0a4d-228">プッシュ通知サービスの要求ヘッダーと応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f0a4d-228">Push notification service request and response headers</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465435)
* [<span data-ttu-id="f0a4d-229">プッシュ通知のガイドラインとチェック リスト</span><span class="sxs-lookup"><span data-stu-id="f0a4d-229">Guidelines and checklist for push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [<span data-ttu-id="f0a4d-230">直接通知</span><span class="sxs-lookup"><span data-stu-id="f0a4d-230">Raw notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761488)
