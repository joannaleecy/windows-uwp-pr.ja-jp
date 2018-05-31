---
author: adwilso
Description: Windows Push Notification Services (WNS) enables third-party developers to send toast, tile, badge, and raw updates from their own cloud service. There are many ways to send the notifications depending on the needs of your application
title: 適切なプッシュ通知チャネルの種類を選択する
ms.author: mijacobs
ms.date: 07/07/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 88040d6eb1c5d198de0a446348e114b7e59a2dad
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654901"
---
# <a name="choosing-the-right-push-notification-channel-type"></a><span data-ttu-id="740f2-103">適切なプッシュ通知チャネルの種類を選択する</span><span class="sxs-lookup"><span data-stu-id="740f2-103">Choosing the right push notification channel type</span></span>

<span data-ttu-id="740f2-104">この記事では、アプリのコンテンツの提供に役立つ、3 つの種類の UWP プッシュ通知 (プライマリ、セカンダリ、および代替) について説明します。</span><span class="sxs-lookup"><span data-stu-id="740f2-104">This article covers the three types of UWP push notification channels (primary, secondary, and alternate) that help you deliver content to your app.</span></span> 

<span data-ttu-id="740f2-105">(プッシュ通知の作成について詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](../tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="740f2-105">(For details on how to create push notifications, see the the [Windows Push Notification Services (WNS) overview](../tiles-and-notifications/windows-push-notification-services--wns--overview.md).)</span></span> 

## <a name="types-of-push-channels"></a><span data-ttu-id="740f2-106">プッシュ チャネルの種類</span><span class="sxs-lookup"><span data-stu-id="740f2-106">Types of push channels</span></span> 

<span data-ttu-id="740f2-107">UWP アプリに通知を送信するために使用される、3 種類のプッシュ チャネルがあります。</span><span class="sxs-lookup"><span data-stu-id="740f2-107">There are three types of push channels that can be used to send notifications to a UWP app.</span></span> <span data-ttu-id="740f2-108">それらは以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="740f2-108">They are:</span></span> 

<span data-ttu-id="740f2-109">[プライマリ チャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - "従来型" のプッシュ チャネルです。</span><span class="sxs-lookup"><span data-stu-id="740f2-109">[Primary channel](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - the "traditional" push channel.</span></span> <span data-ttu-id="740f2-110">任意のストア アプリで、トースト通知、タイル通知、直接通知、バッジ通知 (トースト、タイル、バッジの説明へのリンク) の送信に使用できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-110">Can be used by any app in the store to send toast, tile, raw, or badge notifications (Link to descriptions of toast/tiles/badge)</span></span>

<span data-ttu-id="740f2-111">[セカンダリ タイルのチャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - セカンダリ タイルへのタイルの更新をプッシュするために使用します。</span><span class="sxs-lookup"><span data-stu-id="740f2-111">[Secondary tile channel](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - used to push tile updates for a secondary tile.</span></span> <span data-ttu-id="740f2-112">ユーザーのスタート画面にピン留めされているセカンダリ タイルに、タイルやバッジ通知を送信するためのみに使用できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-112">Can only be used to send tile or badge notifications to a secondary tile pinned on the user's start screen</span></span>

<span data-ttu-id="740f2-113">[代替チャネル](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - Creators Update で追加された新しい種類のチャネルです。</span><span class="sxs-lookup"><span data-stu-id="740f2-113">[Alternate channel](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanagerforuser#Methods_) - A new type of channel added in the Creators Update.</span></span> <span data-ttu-id="740f2-114">ストアに登録されていないアプリを含め、任意の UWP アプリに直接通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-114">It allows for raw notifications to be sent to any UWP app, including those which aren't registered in the Store.</span></span> 

> [!NOTE]
> <span data-ttu-id="740f2-115">どのプッシュ チャネルを使用する場合でも、アプリがデバイスで実行されると、ローカルのトースト、タイル、バッジ通知をいつでも送信することができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-115">No matter which push channel you use, once your app is running on the device, it will always be able to send local toast, tile, or badge notifications.</span></span> <span data-ttu-id="740f2-116">アプリは、フォア グラウンド アプリ プロセスまたはバックグラウンド タスクから、ローカル通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-116">It can send local notifications from the foreground app processes or from a background task.</span></span> 


## <a name="primary-channels"></a><span data-ttu-id="740f2-117">プライマリ チャネル</span><span class="sxs-lookup"><span data-stu-id="740f2-117">Primary channels</span></span>

<span data-ttu-id="740f2-118">これは、Windows で現在、最も一般的に使用されているチャネルです。Microsoft Store を通じて配布されるアプリのほとんどのシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="740f2-118">These are the most commonly used channels on Windows right now, and are good for almost any scenario where your app is going to be distributed through the Microsoft Store.</span></span> <span data-ttu-id="740f2-119">アプリにすべての種類の通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-119">They allow you to send all types of notifications to the app.</span></span> 

### <a name="what-do-primary-channels-enable"></a><span data-ttu-id="740f2-120">プライマリ チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="740f2-120">What do primary channels enable?</span></span>

-   **<span data-ttu-id="740f2-121">プライマリ タイルへのタイルやバッジの更新を送信します。</span><span class="sxs-lookup"><span data-stu-id="740f2-121">Sending tile or badge updates to the primary tile.</span></span>** <span data-ttu-id="740f2-122">ユーザーがスタート画面にタイルをピン留めした場合、プライマリ チャネルの効果を発揮できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-122">If the user has chosen to pin your tile to the start screen, this is your chance to show off.</span></span> <span data-ttu-id="740f2-123">アプリ内で、役に立つ情報の更新やエクスペリエンスのリマインダーを送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-123">Send updates with useful information or reminders of experiences within your app.</span></span> 
-   **<span data-ttu-id="740f2-124">トースト通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="740f2-124">Sending toast notifications.</span></span>** <span data-ttu-id="740f2-125">トースト通知を使うと、ユーザーの前に直ちに情報を提供できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-125">Toast notifications are a chance to get some information in front of the user immediately.</span></span> <span data-ttu-id="740f2-126">シェルによりほとんどのアプリの一番上に描画され、さらにアクション センターに残るため、ユーザーは後から参照して操作することができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-126">They are painted by the shell over top of most apps, and live in the action center so the user can go back and interact with them later.</span></span> 
-   **<span data-ttu-id="740f2-127">バックグラウンド タスクをトリガーする直接通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="740f2-127">Sending raw notifications to trigger a background task.</span></span>** <span data-ttu-id="740f2-128">通知に基づいて、ユーザーに代わって作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-128">Sometimes you want to do some work on behalf of the user based on a notification.</span></span> <span data-ttu-id="740f2-129">直接通知を使うと、アプリのバックグラウンド タスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-129">Raw notifications allow your app's background tasks to run</span></span> 
-   **<span data-ttu-id="740f2-130">Windows は TLS を使用して、転送中のメッセージを暗号化します。</span><span class="sxs-lookup"><span data-stu-id="740f2-130">Message encryption in transit provided by Windows using TLS.</span></span>** <span data-ttu-id="740f2-131">ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="740f2-131">Messages are encrypted on the wire both coming into WNS and going to the user's device.</span></span>  

### <a name="limitations-of-primary-channels"></a><span data-ttu-id="740f2-132">プライマリ チャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="740f2-132">Limitations of primary channels</span></span>

-   <span data-ttu-id="740f2-133">デバイス ベンダー間で標準ではないプッシュ通知には、WNS REST API を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="740f2-133">Requires using the WNS REST API to push notifications, which isn't standard across device vendors.</span></span> 
-   <span data-ttu-id="740f2-134">アプリごとに 1 つだけのチャネルを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-134">Only one channel can be created per app</span></span> 
-   <span data-ttu-id="740f2-135">アプリを Microsoft Store に登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="740f2-135">Requires your app to be registered in the Microsoft Store</span></span>

### <a name="creating-a-primary-channel"></a><span data-ttu-id="740f2-136">プライマリ チャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="740f2-136">Creating a primary channel</span></span> 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
```

## <a name="secondary-tile-channels"></a><span data-ttu-id="740f2-137">セカンダリ タイル チャネル</span><span class="sxs-lookup"><span data-stu-id="740f2-137">Secondary tile channels</span></span>

<span data-ttu-id="740f2-138">セカンダリ タイルへタイルとバッジの更新をプッシュするために使用できるチャネルです。</span><span class="sxs-lookup"><span data-stu-id="740f2-138">These are channels that can be used to push tile and badge updates to a secondary tile.</span></span> <span data-ttu-id="740f2-139">アプリが使用して、ユーザーに関心のあるアクションを通知したり、アプリで操作できる情報を通知したりできます。たとえば、グループ チャットの新しいメッセージや試合のスコアの最新情報などです。</span><span class="sxs-lookup"><span data-stu-id="740f2-139">These are used by apps to notify users of interesting actions or information that they can interact with in the app, such as new messages in a group chat or an updated sports score.</span></span> 

### <a name="what-do-secondary-tile-channels-enable"></a><span data-ttu-id="740f2-140">セカンダリ タイル チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="740f2-140">What do secondary tile channels enable?</span></span>

-   <span data-ttu-id="740f2-141">セカンダリ タイルにタイル通知またはバッジ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="740f2-141">Sending tile or badge notifications to secondary tiles.</span></span> <span data-ttu-id="740f2-142">セカンダリ タイルは、ユーザーがアプリを繰り返して使うための優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="740f2-142">Secondary tiles are a great way to pull users back into your app.</span></span> <span data-ttu-id="740f2-143">セカンダリ タイルは、ユーザーが関心を持つ情報へのディープ リンクです。タイルにユーザーが関心を持つ情報を表示することにより、アプリを繰り返して使用するようにできます。</span><span class="sxs-lookup"><span data-stu-id="740f2-143">They are a deep link to information they care about, and putting relevant information on the tiles helps to bring them back again and again.</span></span>
-   <span data-ttu-id="740f2-144">さまざまなタイル間のチャネルを分離 (期限切れに) します。</span><span class="sxs-lookup"><span data-stu-id="740f2-144">Separation of channels (and expiries) between various tiles.</span></span> <span data-ttu-id="740f2-145">これにより、ユーザーによってスタート画面にピン留めされた、さまざまな種類のセカンダリ タイルの間で、バックエンドのロジックを分離することができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-145">This allows you to separate the logic in the backend between the various types of secondary tiles that a user might pin to their start screen.</span></span> 
-   <span data-ttu-id="740f2-146">Windows は TLS を使用して、転送中のメッセージを暗号化します。</span><span class="sxs-lookup"><span data-stu-id="740f2-146">Message encryption in transit provided by Windows using TLS.</span></span> <span data-ttu-id="740f2-147">ネットワーク上のメッセージは、WNS の受信メッセージとデバイスへの送信メッセージの両方が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="740f2-147">Messages are encrypted on the wire both coming into WNS and going to the user's device.</span></span>  

### <a name="limitations-of-secondary-tile-channels"></a><span data-ttu-id="740f2-148">セカンダリ タイルのチャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="740f2-148">Limitations of secondary tile channels</span></span>

-   <span data-ttu-id="740f2-149">トースト通知または直接通知はできません。</span><span class="sxs-lookup"><span data-stu-id="740f2-149">No toast or raw notifications allowed.</span></span> <span data-ttu-id="740f2-150">セカンダリ タイルに送信されるトースト通知または直接通知は、システムによって無視されます。</span><span class="sxs-lookup"><span data-stu-id="740f2-150">Toast or raw notifications sent to a secondary tile are ignored by the system.</span></span>
-   <span data-ttu-id="740f2-151">アプリを Microsoft Store に登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="740f2-151">Requires your app to be registered in the Microsoft Store</span></span>


### <a name="creating-a-secondary-tile-channel"></a><span data-ttu-id="740f2-152">セカンダリ タイルのチャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="740f2-152">Creating a secondary tile channel</span></span> 

```csharp
PushNotificationChannel channel = 
    await PushNotificationChannelManager.CreatePushNotificationChannelForSecondaryTileAsync(tileId);
```

## <a name="alternate-channels"></a><span data-ttu-id="740f2-153">代替チャネル</span><span class="sxs-lookup"><span data-stu-id="740f2-153">Alternate channels</span></span>

<span data-ttu-id="740f2-154">代替チャネルを使うと、アプリは、Microsoft Store へ登録したりアプリに作成されたプライマリ チャネル以外にプッシュ チャネルを作成したりすることなく、プッシュ通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-154">Alternate channels enable apps to send push notifications without registering to the Microsoft Store or creating push channels outside of the primary one used for the app.</span></span> 
 
### <a name="what-do-alternate-channels-enable"></a><span data-ttu-id="740f2-155">代替チャネルで可能なこと</span><span class="sxs-lookup"><span data-stu-id="740f2-155">What do alternate channels enable?</span></span>
-   <span data-ttu-id="740f2-156">任意の Windows デバイスで実行されている UWP への直接プッシュ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="740f2-156">Send raw push notifications to a UWP running on any Windows device.</span></span> <span data-ttu-id="740f2-157">代替チャネルのみが直接通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-157">Alternate channels only allow for raw notifications.</span></span>
-   <span data-ttu-id="740f2-158">アプリは、アプリ内でのさまざまな機能のために、複数の直接プッシュ チャネルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-158">Allows apps to create multiple raw push channels for different features within the app.</span></span> <span data-ttu-id="740f2-159">アプリは、最大 1000 の代替チャネルを作成できます。各チャネルは 30 日間有効です。</span><span class="sxs-lookup"><span data-stu-id="740f2-159">An app can create up to 1000 alternate channels, and each one is valid for 30 days.</span></span> <span data-ttu-id="740f2-160">アプリは各チャネルを個別に管理したり、取り消したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-160">Each of these channels can be managed or revoked separately by the app.</span></span>
-   <span data-ttu-id="740f2-161">代替プッシュ チャネルは、アプリを Microsoft Store に登録することなく、作成できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-161">Alternate push channels can be created without registering an app with the Microsoft Store.</span></span> <span data-ttu-id="740f2-162">アプリを Microsoft Store に登録することなく、デバイスにインストールする場合でも、プッシュ通知を受信することができます。</span><span class="sxs-lookup"><span data-stu-id="740f2-162">If you app is going to be installed on devices without registering it in the Microsoft Store, it will still be able to receive push notifications.</span></span>
-   <span data-ttu-id="740f2-163">サーバーは、W3C 標準の REST API および VAPID プロトコルを使用して、通知をプッシュできます。</span><span class="sxs-lookup"><span data-stu-id="740f2-163">Servers can push notifications using the W3C standard REST APIs and VAPID protocol.</span></span> <span data-ttu-id="740f2-164">代替チャネルは、W3C 標準プロトコルを使用します。これにより、保守が必要なサーバー ロジックを簡素化できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-164">Alternate channels use the W3C standard protocol, this allows you to simplify the server logic that needs to be maintained.</span></span>
-   <span data-ttu-id="740f2-165">エンド ツー エンドでメッセージの完全な暗号化を行います。</span><span class="sxs-lookup"><span data-stu-id="740f2-165">Full, end-to-end, message encryption.</span></span> <span data-ttu-id="740f2-166">プライマリ チャネルは転送中の暗号化を提供しますが、より高いセキュリティを必要とする場合には、代替チャネルを使うと、アプリは暗号化ヘッダーをパス スルーしてメッセージを保護できます。</span><span class="sxs-lookup"><span data-stu-id="740f2-166">While the primary channel provides encryption while in transit, if you want to be extra secure, alternate channels enable your app to pass through encryption headers to protect a message.</span></span> 

### <a name="limitations-of-alternate-channels"></a><span data-ttu-id="740f2-167">代替チャネルの制限事項</span><span class="sxs-lookup"><span data-stu-id="740f2-167">Limitations of alternate channels</span></span>
-   <span data-ttu-id="740f2-168">アプリは、トースト通知、タイル通知、バッジ通知を送信できません。</span><span class="sxs-lookup"><span data-stu-id="740f2-168">Apps cannot send toast, tile, or badge type notifications.</span></span> <span data-ttu-id="740f2-169">代替チャネルは、他の種類の通知の送信機能を制限します。</span><span class="sxs-lookup"><span data-stu-id="740f2-169">The alternate channel limits your ability to send other notification types.</span></span> <span data-ttu-id="740f2-170">アプリは、バックグラウンド タスクから、ローカル通知を送信することは可能です。</span><span class="sxs-lookup"><span data-stu-id="740f2-170">Your app is still able to send local notifications from your background task.</span></span> 
-   <span data-ttu-id="740f2-171">プライマリ チャネルやセカンダリ タイルのチャネルとは異なる REST API が必要です。</span><span class="sxs-lookup"><span data-stu-id="740f2-171">Requires a different REST API than either primary or secondary tile channels.</span></span> <span data-ttu-id="740f2-172">標準 W3C REST API を使用するため、アプリでは、トーストやタイルのプッシュ更新を送信するロジックとは異なるロジックを必要とします。</span><span class="sxs-lookup"><span data-stu-id="740f2-172">Using the standard W3C REST API means that your app will need to have different logic for sending push toast or tile updates</span></span>

### <a name="creating-an-alternate-channel"></a><span data-ttu-id="740f2-173">代替チャネルを作成する</span><span class="sxs-lookup"><span data-stu-id="740f2-173">Creating an alternate channel</span></span> 

```csharp
PushNotificationChannel webChannel = 
    await PushNotificationChannelManager.Current.CreateRawPushNotificationChannelWithAlternateKeyForApplicationAsync(applicationServerKey, appChannelId);
```

## <a name="channel-type-comparison"></a><span data-ttu-id="740f2-174">チャネルの種類の比較</span><span class="sxs-lookup"><span data-stu-id="740f2-174">Channel type comparison</span></span>
<span data-ttu-id="740f2-175">さまざまな種類のチャネルの比較表を次に示します。</span><span class="sxs-lookup"><span data-stu-id="740f2-175">Here is a quick comparison between the different types of channels:</span></span>

<table>

<tr class="header">
<th align="left"><b><span data-ttu-id="740f2-176">種類</span><span class="sxs-lookup"><span data-stu-id="740f2-176">Type</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-177">トーストをプッシュする</span><span class="sxs-lookup"><span data-stu-id="740f2-177">Push toast?</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-178">タイルバッジをプッシュする</span><span class="sxs-lookup"><span data-stu-id="740f2-178">Push tile/badge?</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-179">直接通知をプッシュする</span><span class="sxs-lookup"><span data-stu-id="740f2-179">Push raw notifications?</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-180">認証</span><span class="sxs-lookup"><span data-stu-id="740f2-180">Authentication</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-181">API</span><span class="sxs-lookup"><span data-stu-id="740f2-181">API</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-182">ストアへの登録の必要性</span><span class="sxs-lookup"><span data-stu-id="740f2-182">Store registration required?</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-183">チャネル</span><span class="sxs-lookup"><span data-stu-id="740f2-183">Channels</span></span></b></th>
<th align="left"><b><span data-ttu-id="740f2-184">暗号化</span><span class="sxs-lookup"><span data-stu-id="740f2-184">Encryption</span></span></b></th>
</tr>


<tr class="odd">
<td align="left"><span data-ttu-id="740f2-185">プライマリ</span><span class="sxs-lookup"><span data-stu-id="740f2-185">Primary</span></span></td>
<td align="left"><span data-ttu-id="740f2-186">〇</span><span class="sxs-lookup"><span data-stu-id="740f2-186">Yes</span></span></td>
<td align="left"><span data-ttu-id="740f2-187">〇 - プライマリ タイルのみ</span><span class="sxs-lookup"><span data-stu-id="740f2-187">Yes - primary tile only</span></span></td>
<td align="left"><span data-ttu-id="740f2-188">〇</span><span class="sxs-lookup"><span data-stu-id="740f2-188">Yes</span></span></td>
<td align="left"><span data-ttu-id="740f2-189">OAuth</span><span class="sxs-lookup"><span data-stu-id="740f2-189">OAuth</span></span></td>
<td align="left"><span data-ttu-id="740f2-190">WNS REST API</span><span class="sxs-lookup"><span data-stu-id="740f2-190">WNS REST API</span></span></td>
<td align="left"><span data-ttu-id="740f2-191">〇</span><span class="sxs-lookup"><span data-stu-id="740f2-191">Yes</span></span></td>
<td align="left"><span data-ttu-id="740f2-192">アプリごとに 1 つ</span><span class="sxs-lookup"><span data-stu-id="740f2-192">One per app</span></span></td>
<td align="left"><span data-ttu-id="740f2-193">転送中</span><span class="sxs-lookup"><span data-stu-id="740f2-193">In Transit</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="740f2-194">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="740f2-194">Secondary Tile</span></span></td>
<td align="left"><span data-ttu-id="740f2-195">X</span><span class="sxs-lookup"><span data-stu-id="740f2-195">No</span></span></td>
<td align="left"><span data-ttu-id="740f2-196">〇 - セカンダリ タイルのみ</span><span class="sxs-lookup"><span data-stu-id="740f2-196">Yes - secondary tile only</span></span></td>
<td align="left"><span data-ttu-id="740f2-197">X</span><span class="sxs-lookup"><span data-stu-id="740f2-197">No</span></span></td>
<td align="left"><span data-ttu-id="740f2-198">OAuth</span><span class="sxs-lookup"><span data-stu-id="740f2-198">OAuth</span></span></td>
<td align="left"><span data-ttu-id="740f2-199">WNS REST API</span><span class="sxs-lookup"><span data-stu-id="740f2-199">WNS REST API</span></span></td>
<td align="left"><span data-ttu-id="740f2-200">〇</span><span class="sxs-lookup"><span data-stu-id="740f2-200">Yes</span></span></td>
<td align="left"><span data-ttu-id="740f2-201">セカンダリ タイルごとに 1 つ</span><span class="sxs-lookup"><span data-stu-id="740f2-201">One per secondary tile</span></span></td>
<td align="left"><span data-ttu-id="740f2-202">転送中</span><span class="sxs-lookup"><span data-stu-id="740f2-202">In Transit</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="740f2-203">代替</span><span class="sxs-lookup"><span data-stu-id="740f2-203">Alternate</span></span></td>
<td align="left"><span data-ttu-id="740f2-204">X</span><span class="sxs-lookup"><span data-stu-id="740f2-204">No</span></span></td>
<td align="left"><span data-ttu-id="740f2-205">いいえ</span><span class="sxs-lookup"><span data-stu-id="740f2-205">No</span></span></td>
<td align="left"><span data-ttu-id="740f2-206">〇</span><span class="sxs-lookup"><span data-stu-id="740f2-206">Yes</span></span></td>
<td align="left"><span data-ttu-id="740f2-207">VAPID</span><span class="sxs-lookup"><span data-stu-id="740f2-207">VAPID</span></span></td>
<td align="left"><span data-ttu-id="740f2-208">WebPush W3C 標準</span><span class="sxs-lookup"><span data-stu-id="740f2-208">WebPush W3C Standard</span></span></td>
<td align="left"><span data-ttu-id="740f2-209">X</span><span class="sxs-lookup"><span data-stu-id="740f2-209">No</span></span></td>
<td align="left"><span data-ttu-id="740f2-210">アプリあたり 1,000</span><span class="sxs-lookup"><span data-stu-id="740f2-210">1,000 per app</span></span></td>
<td align="left"><span data-ttu-id="740f2-211">転送中 + ヘッダー パススルーによりエンドツーエンドの暗号化が可能 (アプリ コードが必要)</span><span class="sxs-lookup"><span data-stu-id="740f2-211">In transit + end to end encryption possible with header pass through (requires app code)</span></span></td>
</tr>
</table>

## <a name="choosing-the-right-channel"></a><span data-ttu-id="740f2-212">適切なチャンネルを選択する</span><span class="sxs-lookup"><span data-stu-id="740f2-212">Choosing the right channel</span></span>

<span data-ttu-id="740f2-213">一般に、いくつかの例外を除き、アプリではプライマリ チャネルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="740f2-213">In general, we recommend using the primary channel in your app, with a few exceptions:</span></span> 

1. <span data-ttu-id="740f2-214">セカンダリ タイルにタイルの更新をプッシュする場合は、セカンダリ タイルのプッシュ チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="740f2-214">If you are pushing a tile update to a secondary tile, use the secondary tile push channel.</span></span>
2. <span data-ttu-id="740f2-215">他のサービス (ブラウザーの場合など) にチャネルを渡す場合には、代替チャンネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="740f2-215">If you are passing out channels to other services (such as in the case of a browser) use the alternate channel.</span></span>
3. <span data-ttu-id="740f2-216">Windows ストアに登録しないアプリ (LOB アプリなど) を作成する場合、代替チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="740f2-216">If you are creating an app that won't be listed in the Windows store (such as an LOB app) use an alternate channel.</span></span>
4. <span data-ttu-id="740f2-217">サーバーにある既存の Web プッシュ コードを再利用する場合や、バックエンド サービスで複数のチャネルの必要性がある場合には、代替チャネルを使用します。</span><span class="sxs-lookup"><span data-stu-id="740f2-217">If you have existing web push code on your server you wish to reuse or have a need for multiple channels in your backend service, use alternate channels.</span></span>

## <a name="related-articles"></a><span data-ttu-id="740f2-218">関連記事</span><span class="sxs-lookup"><span data-stu-id="740f2-218">Related articles</span></span>

* [<span data-ttu-id="740f2-219">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="740f2-219">Send a local tile notification</span></span>](../tiles-and-notifications/sending-a-local-tile-notification.md)
* [<span data-ttu-id="740f2-220">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="740f2-220">Adaptive and interactive toast notifications</span></span>](../tiles-and-notifications/adaptive-interactive-toasts.md)
* [<span data-ttu-id="740f2-221">クイック スタート: プッシュ通知の送信</span><span class="sxs-lookup"><span data-stu-id="740f2-221">Quickstart: Sending a push notification</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)
* [<span data-ttu-id="740f2-222">プッシュ通知を使用してバッジを更新する方法</span><span class="sxs-lookup"><span data-stu-id="740f2-222">How to update a badge through push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [<span data-ttu-id="740f2-223">通知チャネルを要求、作成、保存する方法</span><span class="sxs-lookup"><span data-stu-id="740f2-223">How to request, create, and save a notification channel</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465412)
* [<span data-ttu-id="740f2-224">実行中のアプリの通知を中断する方法</span><span class="sxs-lookup"><span data-stu-id="740f2-224">How to intercept notifications for running applications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [<span data-ttu-id="740f2-225">Windows プッシュ通知サービス (WNS) に対して認証する方法</span><span class="sxs-lookup"><span data-stu-id="740f2-225">How to authenticate with the Windows Push Notification Service (WNS)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465407)
* [<span data-ttu-id="740f2-226">プッシュ通知サービスの要求ヘッダーと応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="740f2-226">Push notification service request and response headers</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465435)
* [<span data-ttu-id="740f2-227">プッシュ通知のガイドラインとチェック リスト</span><span class="sxs-lookup"><span data-stu-id="740f2-227">Guidelines and checklist for push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [<span data-ttu-id="740f2-228">直接通知</span><span class="sxs-lookup"><span data-stu-id="740f2-228">Raw notifications</span></span>](raw-notification-overview.md)
