---
author: mijacobs
Description: This article covers the four notification options&\#8212;local, scheduled, periodic, and push&\#8212;that deliver tile and badge updates and toast notification content.
title: 通知配信方法の選択
ms.assetid: FDB43EDE-C5F2-493F-952C-55401EC5172B
label: Choose a notification delivery method
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c01b96f70bd39c43f321935aa47393ada0400319
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5928010"
---
# <a name="choose-a-notification-delivery-method"></a><span data-ttu-id="3e697-103">通知配信方法の選択</span><span class="sxs-lookup"><span data-stu-id="3e697-103">Choose a notification delivery method</span></span>

 


<span data-ttu-id="3e697-104">この記事では、タイルとバッジの更新およびトースト通知のコンテンツを配信するための 4 つの通知オプション (ローカル、スケジュール、定期的、プッシュ) について説明します。</span><span class="sxs-lookup"><span data-stu-id="3e697-104">This article covers the four notification options—local, scheduled, periodic, and push—that deliver tile and badge updates and toast notification content.</span></span> <span data-ttu-id="3e697-105">タイルやトースト通知では、ユーザーがアプリを直接利用していないときでもユーザーに情報を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="3e697-105">A tile or a toast notification can get information to your user even when the user is not directly engaged with your app.</span></span> <span data-ttu-id="3e697-106">アプリおよび配信する情報の性質と内容から、シナリオに最適な通知方法を決めることができます。</span><span class="sxs-lookup"><span data-stu-id="3e697-106">The nature and content of your app and the information that you want to deliver can help you determine which notification method or methods is best for your scenario.</span></span>

## <a name="notification-delivery-methods-overview"></a><span data-ttu-id="3e697-107">通知配信方法の概要</span><span class="sxs-lookup"><span data-stu-id="3e697-107">Notification delivery methods overview</span></span>


<span data-ttu-id="3e697-108">通知を配信するためにアプリで使用できるメカニズムには、次の 4 種類があります。</span><span class="sxs-lookup"><span data-stu-id="3e697-108">There are four mechanisms that an app can use to deliver a notification:</span></span>

-   **<span data-ttu-id="3e697-109">ローカル</span><span class="sxs-lookup"><span data-stu-id="3e697-109">Local</span></span>**
-   **<span data-ttu-id="3e697-110">スケジュール</span><span class="sxs-lookup"><span data-stu-id="3e697-110">Scheduled</span></span>**
-   **<span data-ttu-id="3e697-111">定期的</span><span class="sxs-lookup"><span data-stu-id="3e697-111">Periodic</span></span>**
-   **<span data-ttu-id="3e697-112">プッシュ</span><span class="sxs-lookup"><span data-stu-id="3e697-112">Push</span></span>**

<span data-ttu-id="3e697-113">次の表は、通知配信の種類をまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="3e697-113">This table summarizes the notification delivery types.</span></span>

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="3e697-114">配信方法</span><span class="sxs-lookup"><span data-stu-id="3e697-114">Delivery method</span></span></th>
<th align="left"><span data-ttu-id="3e697-115">使用対象</span><span class="sxs-lookup"><span data-stu-id="3e697-115">Use with</span></span></th>
<th align="left"><span data-ttu-id="3e697-116">説明</span><span class="sxs-lookup"><span data-stu-id="3e697-116">Description</span></span></th>
<th align="left"><span data-ttu-id="3e697-117">例</span><span class="sxs-lookup"><span data-stu-id="3e697-117">Examples</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="3e697-118">ローカル</span><span class="sxs-lookup"><span data-stu-id="3e697-118">Local</span></span></td>
<td align="left"><span data-ttu-id="3e697-119">タイル、バッジ、トースト</span><span class="sxs-lookup"><span data-stu-id="3e697-119">Tile, Badge, Toast</span></span></td>
<td align="left"><span data-ttu-id="3e697-120">アプリが実行されている間、タイルやバッジを直接更新している間、またはトースト通知を送信している間に通知を送信する API 呼び出しのセットです。</span><span class="sxs-lookup"><span data-stu-id="3e697-120">A set of API calls that send notifications while your app is running, directly updating the tile or badge, or sending a toast notification.</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="3e697-121">音楽アプリでは、タイルを更新して &quot;再生中&quot; の音楽を表示します。</span><span class="sxs-lookup"><span data-stu-id="3e697-121">A music app updates its tile to show what's &quot;Now Playing&quot;.</span></span></li>
<li><span data-ttu-id="3e697-122">ゲーム アプリでは、ユーザーがゲームから離れるとタイルを更新してユーザーのハイ スコアを表示します。</span><span class="sxs-lookup"><span data-stu-id="3e697-122">A game app updates its tile with the user's high score when the user leaves the game.</span></span></li>
<li><span data-ttu-id="3e697-123">グリフでアプリに新しい情報があることが示されたバッジは、アプリがアクティブ化されるとクリアされます。</span><span class="sxs-lookup"><span data-stu-id="3e697-123">A badge whose glyph indicates that there's new info int the app is cleared when the app is activated.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="3e697-124">スケジュール</span><span class="sxs-lookup"><span data-stu-id="3e697-124">Scheduled</span></span></td>
<td align="left"><span data-ttu-id="3e697-125">タイル、トースト</span><span class="sxs-lookup"><span data-stu-id="3e697-125">Tile, Toast</span></span></td>
<td align="left"><span data-ttu-id="3e697-126">指定した時間に更新が行われるように事前に通知をスケジュールする API 呼び出しのセットです。</span><span class="sxs-lookup"><span data-stu-id="3e697-126">A set of API calls that schedule a notification in advance, to update at the time you specify.</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="3e697-127">カレンダー アプリでは、予定されている会議用のトースト通知のアラームを設定します。</span><span class="sxs-lookup"><span data-stu-id="3e697-127">A calendar app sets a toast notification reminder for an upcoming meeting.</span></span></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="3e697-128">定期的</span><span class="sxs-lookup"><span data-stu-id="3e697-128">Periodic</span></span></td>
<td align="left"><span data-ttu-id="3e697-129">タイル、バッジ</span><span class="sxs-lookup"><span data-stu-id="3e697-129">Tile, Badge</span></span></td>
<td align="left"><span data-ttu-id="3e697-130">クラウド サービスをポーリングして新しいコンテンツの有無を調べて、タイルとバッジを一定の間隔で定期的に更新する通知です。</span><span class="sxs-lookup"><span data-stu-id="3e697-130">Notifications that update tiles and badges regularly at a fixed time interval by polling a cloud service for new content.</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="3e697-131">天気予報アプリでは、予報を表示するタイルを 30 分間隔で更新します。</span><span class="sxs-lookup"><span data-stu-id="3e697-131">A weather app updates its tile, which shows the forecast, at 30-minute intervals.</span></span></li>
<li><span data-ttu-id="3e697-132">&quot;日替わりセール情報&quot; サイトでは、本日のお買い得品を毎朝更新します。</span><span class="sxs-lookup"><span data-stu-id="3e697-132">A &quot;daily deals&quot; site updates its deal-of-the-day every morning.</span></span></li>
<li><span data-ttu-id="3e697-133">イベントまでの日数を表示するタイルでは、表示される日数のカウントダウンを毎日深夜 0 時に更新します。</span><span class="sxs-lookup"><span data-stu-id="3e697-133">A tile that displays the days until an event updates the displayed countdown each day at midnight.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="3e697-134">プッシュ</span><span class="sxs-lookup"><span data-stu-id="3e697-134">Push</span></span></td>
<td align="left"><span data-ttu-id="3e697-135">タイル、バッジ、トースト、直接</span><span class="sxs-lookup"><span data-stu-id="3e697-135">Tile, Badge, Toast, Raw</span></span></td>
<td align="left"><span data-ttu-id="3e697-136">アプリが実行されていなくてもクラウド サーバーから送信される通知です。</span><span class="sxs-lookup"><span data-stu-id="3e697-136">Notifications sent from a cloud server, even if your app isn't running.</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="3e697-137">ショッピング アプリでは、トースト通知を送信して、ユーザーが注目している商品のセール情報を知らせます。</span><span class="sxs-lookup"><span data-stu-id="3e697-137">A shopping app sends a toast notification to let a user know about a sale on an item that they're watching.</span></span></li>
<li><span data-ttu-id="3e697-138">ニュース アプリでは、ニュース速報が発生したときにタイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="3e697-138">A news app updates its tile with breaking news as it happens.</span></span></li>
<li><span data-ttu-id="3e697-139">スポーツ アプリでは、試合の進行中にタイルを更新し続けます。</span><span class="sxs-lookup"><span data-stu-id="3e697-139">A sports app keeps its tile up-to-date during an ongoing game.</span></span></li>
<li><span data-ttu-id="3e697-140">通信アプリでは、メッセージや電話の着信をアラートで知らせます。</span><span class="sxs-lookup"><span data-stu-id="3e697-140">A communication app provides alerts about incoming messages or phone calls.</span></span></li>
</ul></td>
</tr>
</tbody>
</table>

 

## <a name="local-notifications"></a><span data-ttu-id="3e697-141">ローカル通知</span><span class="sxs-lookup"><span data-stu-id="3e697-141">Local notifications</span></span>


<span data-ttu-id="3e697-142">アプリの実行中に行われるタイルまたはバッジの更新やトースト通知の表示は、ローカルの API 呼び出しのみが必要となる、最もシンプルな通知配信メカニズムです。</span><span class="sxs-lookup"><span data-stu-id="3e697-142">Updating the app tile or badge or raising a toast notification while the app is running is the simplest of the notification delivery mechanisms; it only requires local API calls.</span></span> <span data-ttu-id="3e697-143">どのアプリでも、役立つ情報や興味を引く情報をタイルに表示することができます。これは、ユーザーがアプリを起動して操作を開始した後でのみコンテンツが変更される場合でも可能です。</span><span class="sxs-lookup"><span data-stu-id="3e697-143">Every app can have useful or interesting information to show on the tile, even if that content only changes after the user launches and interacts with the app.</span></span> <span data-ttu-id="3e697-144">他の通知メカニズムと併用する場合でも、ローカル通知はアプリのタイルを最新の状態にする手段として適しています。</span><span class="sxs-lookup"><span data-stu-id="3e697-144">Local notifications are also a good way to keep the app tile current, even if you also use one of the other notification mechanisms.</span></span> <span data-ttu-id="3e697-145">たとえば、フォト アプリのタイルでは、最近追加されたアルバムの写真を表示できます。</span><span class="sxs-lookup"><span data-stu-id="3e697-145">For instance, a photo app tile could show photos from a recently added album.</span></span>

<span data-ttu-id="3e697-146">アプリによるタイルのローカルな更新は、アプリが最初に起動されたとき、またはアプリによってタイルに反映される変更をユーザーが加えた直後に行うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3e697-146">We recommended that your app update its tile locally on first launch, or at least immediately after the user makes a change that your app would normally reflect on the tile.</span></span> <span data-ttu-id="3e697-147">この更新内容は、ユーザーがアプリから離れるまで表示されせんが、アプリが使われている間にタイルを更新することで、ユーザーがアプリから離れたときにタイルは確実に最新の状態になります。</span><span class="sxs-lookup"><span data-stu-id="3e697-147">That update isn't seen until the user leaves the app, but by making that change while the app is being used ensures that the tile is already up-to-date when the user departs.</span></span>

<span data-ttu-id="3e697-148">API 呼び出しはローカルですが、通知では Web 画像を参照できます。</span><span class="sxs-lookup"><span data-stu-id="3e697-148">While the API calls are local, the notifications can reference web images.</span></span> <span data-ttu-id="3e697-149">Web 画像が、ダウンロードできない場合、破損している場合、または画像の仕様を満たしていない場合、タイルとトーストでは応答が次のように異なります。</span><span class="sxs-lookup"><span data-stu-id="3e697-149">If the web image is not available for download, is corrupted, or doesn't meet the image specifications, tiles and toast respond differently:</span></span>

-   <span data-ttu-id="3e697-150">タイル: 更新情報が表示されません。</span><span class="sxs-lookup"><span data-stu-id="3e697-150">Tiles: The update is not shown</span></span>
-   <span data-ttu-id="3e697-151">トースト: 通知が表示されますが、画像は削除されます。</span><span class="sxs-lookup"><span data-stu-id="3e697-151">Toast: The notification is displayed, but your image is dropped</span></span>

<span data-ttu-id="3e697-152">既定では、ローカル トースト通知は 3 日後に有効期限が切れ、ローカル タイル通知には有効期限がありません。</span><span class="sxs-lookup"><span data-stu-id="3e697-152">By default, local toast notifications expire in three days, and local tile notifications never expire.</span></span> <span data-ttu-id="3e697-153">これらの既定値を、具体的な通知に適した有効期限で上書きすることをお勧めします (トースト通知の有効期限は、最大 3 日間です)。</span><span class="sxs-lookup"><span data-stu-id="3e697-153">We recommend overriding these defaults with an explicit expiration time that makes sense for your notifications (toasts have a max of three days).</span></span> 

<span data-ttu-id="3e697-154">詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e697-154">For more information, see these topics:</span></span>

-   [<span data-ttu-id="3e697-155">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="3e697-155">Send a local tile notification</span></span>](sending-a-local-tile-notification.md)
-   [<span data-ttu-id="3e697-156">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="3e697-156">Send a local toast notification</span></span>](send-local-toast.md)
-   [<span data-ttu-id="3e697-157">ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル</span><span class="sxs-lookup"><span data-stu-id="3e697-157">Universal Windows Platform (UWP) notifications code samples</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <a name="scheduled-notifications"></a><span data-ttu-id="3e697-158">スケジュールされた通知</span><span class="sxs-lookup"><span data-stu-id="3e697-158">Scheduled notifications</span></span>


<span data-ttu-id="3e697-159">スケジュールされた通知は、タイルを更新する時刻またはトースト通知を表示する時刻を正確に指定できるローカル通知のサブセットです。</span><span class="sxs-lookup"><span data-stu-id="3e697-159">Scheduled notifications are the subset of local notifications that can specify the precise time when a tile should be updated or a toast notification should be shown.</span></span> <span data-ttu-id="3e697-160">スケジュールされた通知は、会議の招集など、更新される内容があらかじめわかっている場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="3e697-160">Scheduled notifications are ideal in situations where the content to be updated is known in advance, such as a meeting invitation.</span></span> <span data-ttu-id="3e697-161">通知の内容が事前にわからない場合は、プッシュ通知または定期的な通知を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e697-161">If you don't have advance knowledge of the notification content, you should use a push or periodic notification.</span></span>

<span data-ttu-id="3e697-162">バッジ通知には、スケジュールされた通知を使うことはできません。バッジ通知は、ローカル通知、定期的な通知、プッシュ通知に最も適しています。</span><span class="sxs-lookup"><span data-stu-id="3e697-162">Note that scheduled notifications cannot be used for badge notifications; badge notifications are best served by local, periodic, or push notifications.</span></span>

<span data-ttu-id="3e697-163">スケジュールされた通知は、既定で配信されたときから 3 日後に有効期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="3e697-163">By default, scheduled notifications expire three days from the time they are delivered.</span></span> <span data-ttu-id="3e697-164">スケジュールされたタイル通知では、この既定の有効期限を上書きできますが、スケジュールされたトースト通知の有効期限を上書きすることはできません。</span><span class="sxs-lookup"><span data-stu-id="3e697-164">You can override this default expiration time on scheduled tile notifications, but you cannot override the expiration time on scheduled toasts.</span></span>

<span data-ttu-id="3e697-165">詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e697-165">For more information, see these topics:</span></span>

-   [<span data-ttu-id="3e697-166">ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル</span><span class="sxs-lookup"><span data-stu-id="3e697-166">Universal Windows Platform (UWP) notifications code samples</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <a name="periodic-notifications"></a><span data-ttu-id="3e697-167">定期的な通知</span><span class="sxs-lookup"><span data-stu-id="3e697-167">Periodic notifications</span></span>


<span data-ttu-id="3e697-168">定期的な通知では、最小限のクラウド サービスとクライアントの投資で、ライブ タイルを更新することができます。</span><span class="sxs-lookup"><span data-stu-id="3e697-168">Periodic notifications give you live tile updates with a minimal cloud service and client investment.</span></span> <span data-ttu-id="3e697-169">この通知は、同じコンテンツを多数のユーザーに配信する方法としても優れています。</span><span class="sxs-lookup"><span data-stu-id="3e697-169">They are also an excellent method of distributing the same content to a wide audience.</span></span> <span data-ttu-id="3e697-170">クライアント コードでは、Windows がタイルまたはバッジの更新の有無を確認するためにポーリングするクラウドの場所の URL と、ポーリングの頻度を指定します。</span><span class="sxs-lookup"><span data-stu-id="3e697-170">Your client code specifies the URL of a cloud location that Windows polls for tile or badge updates, and how often the location should be polled.</span></span> <span data-ttu-id="3e697-171">各ポーリング間隔で、Windows は URL にアクセスして指定された XML コンテンツをダウンロードして、タイルに表示します。</span><span class="sxs-lookup"><span data-stu-id="3e697-171">At each polling interval, Windows contacts the URL to download the specified XML content and display it on the tile.</span></span>

<span data-ttu-id="3e697-172">定期的な通知では、アプリがクラウド サービスをホストする必要があります。このサービスは、アプリをインストールしたすべてのユーザーから指定した間隔でポーリングされます。</span><span class="sxs-lookup"><span data-stu-id="3e697-172">Periodic notifications require the app to host a cloud service, and this service will be polled at the specified interval by all users who have the app installed.</span></span> <span data-ttu-id="3e697-173">トースト通知には定期的な更新を使うことができないので注意してください。トースト通知は、スケジュールされた通知またはプッシュ通知で適切に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e697-173">Note that periodic updates cannot be used for toast notifications; toast notifications are best served by scheduled or push notifications.</span></span>

<span data-ttu-id="3e697-174">定期的な通知は、既定でポーリングが実行されたときから 3 日後に有効期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="3e697-174">By default, periodic notifications expire three days from the time polling occurs.</span></span> <span data-ttu-id="3e697-175">必要に応じて、明示的な有効期限を設定してこの既定値を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="3e697-175">If needed, you can override this default with an explicit expiration time.</span></span>

<span data-ttu-id="3e697-176">詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e697-176">For more information, see these topics:</span></span>

-   [<span data-ttu-id="3e697-177">定期的な通知の概要</span><span class="sxs-lookup"><span data-stu-id="3e697-177">Periodic notification overview</span></span>](periodic-notification-overview.md)
-   [<span data-ttu-id="3e697-178">ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル</span><span class="sxs-lookup"><span data-stu-id="3e697-178">Universal Windows Platform (UWP) notifications code samples</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)

## <a name="push-notifications"></a><span data-ttu-id="3e697-179">プッシュ通知</span><span class="sxs-lookup"><span data-stu-id="3e697-179">Push notifications</span></span>


<span data-ttu-id="3e697-180">プッシュ通知は、リアルタイム データまたはユーザー向けにカスタマイズされたデータと通信する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="3e697-180">Push notifications are ideal to communicate real-time data or data that is personalized for your user.</span></span> <span data-ttu-id="3e697-181">また、ニュース速報、ソーシャル ネットワークの更新、インスタント メッセージなどの予測不可能なタイミングで生成されるコンテンツについても、プッシュ通知が使われます。</span><span class="sxs-lookup"><span data-stu-id="3e697-181">Push notifications are used for content that is generated at unpredictable times, such as breaking news, social network updates, or instant messages.</span></span> <span data-ttu-id="3e697-182">プッシュ通知は、定期的な通知が適さない即時性を必要とするデータ (スポーツの試合中の得点など) にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3e697-182">Push notifications are also useful in situations where the data is time-sensitive in a way that would not suit periodic notifications, such as sports scores during a game.</span></span>

<span data-ttu-id="3e697-183">プッシュ通知を利用するには、プッシュ通知チャネルを管理して、通知を送信するタイミングと送信先のユーザーを判断するクラウド サービスが必要です。</span><span class="sxs-lookup"><span data-stu-id="3e697-183">Push notifications require a cloud service that manages push notification channels and chooses when and to whom to send notifications.</span></span>

<span data-ttu-id="3e697-184">プッシュ通知は、既定でデバイスで受信されたときから 3 日後に有効期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="3e697-184">By default, push notifications expire three days from the time they are received by the device.</span></span> <span data-ttu-id="3e697-185">必要に応じて、明示的な有効期限を設定してこの既定値を上書きできます (トースト通知の有効期限は、最大 3 日間です)。</span><span class="sxs-lookup"><span data-stu-id="3e697-185">If needed, you can override this default with an explicit expiration time (toasts have a max of three days).</span></span>

<span data-ttu-id="3e697-186">詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e697-186">For more information, see:</span></span>

-   [<span data-ttu-id="3e697-187">Windows プッシュ通知サービス (WNS) の概要</span><span class="sxs-lookup"><span data-stu-id="3e697-187">Windows Push Notification Services (WNS) overview</span></span>](windows-push-notification-services--wns--overview.md)
-   [<span data-ttu-id="3e697-188">プッシュ通知のガイドライン</span><span class="sxs-lookup"><span data-stu-id="3e697-188">Guidelines for push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761462)
-   [<span data-ttu-id="3e697-189">ユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル</span><span class="sxs-lookup"><span data-stu-id="3e697-189">Universal Windows Platform (UWP) notifications code samples</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)


## <a name="related-topics"></a><span data-ttu-id="3e697-190">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3e697-190">Related topics</span></span>


* [<span data-ttu-id="3e697-191">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="3e697-191">Send a local tile notification</span></span>](sending-a-local-tile-notification.md)
* [<span data-ttu-id="3e697-192">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="3e697-192">Send a local toast notification</span></span>](send-local-toast.md)
* [<span data-ttu-id="3e697-193">プッシュ通知のガイドライン</span><span class="sxs-lookup"><span data-stu-id="3e697-193">Guidelines for push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [<span data-ttu-id="3e697-194">トースト通知のガイドライン</span><span class="sxs-lookup"><span data-stu-id="3e697-194">Guidelines for toast notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465391)
* [<span data-ttu-id="3e697-195">定期的な通知の概要</span><span class="sxs-lookup"><span data-stu-id="3e697-195">Periodic notification overview</span></span>](periodic-notification-overview.md)
* [<span data-ttu-id="3e697-196">Windows プッシュ通知サービス (WNS) の概要</span><span class="sxs-lookup"><span data-stu-id="3e697-196">Windows Push Notification Services (WNS) overview</span></span>](windows-push-notification-services--wns--overview.md)
* [<span data-ttu-id="3e697-197">GitHub でのユニバーサル Windows プラットフォーム (UWP) の通知コード サンプル</span><span class="sxs-lookup"><span data-stu-id="3e697-197">Universal Windows Platform (UWP) notifications code samples on GitHub</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)
 

 




