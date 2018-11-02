---
author: andrewleader
Description: Learn how to use custom timestamps on your toast notifications.
title: トーストでのカスタム タイムスタンプの表示
label: Custom timestamps on toasts
template: detail.hbs
ms.author: mijacobs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, カスタム タイムスタンプ, タイムスタンプ, 通知, アクション センター
ms.localizationpriority: medium
ms.openlocfilehash: 290825fa079052b79fb2feaec8af928f8da93f95
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5975212"
---
# <a name="custom-timestamps-on-toasts"></a><span data-ttu-id="b6e62-103">トーストでのカスタム タイムスタンプの表示</span><span class="sxs-lookup"><span data-stu-id="b6e62-103">Custom timestamps on toasts</span></span>

<span data-ttu-id="b6e62-104">既定では、トースト通知のタイムスタンプ (アクション センター内に表示される) は、通知が送信された時刻に設定されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-104">By default, the timestamp on toast notifications (visible within Action Center) is set to the time that the notification was sent.</span></span>

<img alt="Toast with custom timestamp" src="images/toast-customtimestamp.jpg" width="396"/>

<span data-ttu-id="b6e62-105">開発者は、必要に応じてこのタイムスタンプを上書きし、通知の送信時刻ではなく、メッセージ、情報、コンテンツが実際に作成された時刻を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-105">You can optionally override the timestamp with your own custom date and time, so that the timestamp represents the time the message/information/content was actually created, rather than the time that the notification was sent.</span></span> <span data-ttu-id="b6e62-106">これにより、アクション センター内で通知が正しい順序 (時間順) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-106">This also ensures that your notifications appear in the correct order within Action Center (which are sorted by time).</span></span> <span data-ttu-id="b6e62-107">ほとんどのアプリでは、カスタム タイムスタンプを指定することが適切です。</span><span class="sxs-lookup"><span data-stu-id="b6e62-107">We recommend that most apps specify a custom timestamp.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b6e62-108">**Creators Update と Notifications ライブラリ 1.4.0 が必要**: カスタム タイムスタンプを表示するには、ビルド 15063 以上を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6e62-108">**Requires Creators Update and 1.4.0 of Notifications library**: You must be running build 15063 or higher to see custom timestamps.</span></span> <span data-ttu-id="b6e62-109">トーストのコンテンツにタイムスタンプを割り当てるには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6e62-109">You must use version 1.4.0 or higher of the [UWP Community Toolkit Notifications NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to assign the timestamp on your toast's content.</span></span>

<span data-ttu-id="b6e62-110">カスタム タイムスタンプは、**DisplayTimestamp** プロパティを **ToastContent** に割り当てるだけで使用できます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-110">To use a custom timestamp, simply assign the **DisplayTimestamp** property on your **ToastContent**.</span></span>

```csharp
ToastContent toastContent = new ToastContent()
{
    DisplayTimestamp = new DateTime(2017, 04, 15, 19, 45, 00, DateTimeKind.Utc),
    ...
};
```

```xml
<toast displayTimestamp="2017-04-15T19:45:00Z">
  ...
</toast>
```

<span data-ttu-id="b6e62-111">XML を使用している場合、日付を [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) で書式設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6e62-111">If you are using XML, the date must be formatted in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601).</span></span>

> [!NOTE]
> <span data-ttu-id="b6e62-112">秒単位で使用できる小数点以下の桁数は、第 3 位までです (現実的には、それ以上精密な時刻を表示する意味はありません)。</span><span class="sxs-lookup"><span data-stu-id="b6e62-112">You can only use at most 3 decimal places on the seconds (although realistically there's no value in providing anything that granular).</span></span> <span data-ttu-id="b6e62-113">それ以上の桁数を指定した場合は、ペイロードが無効になり、開発者に "New notification" 通知が送信されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-113">If you provide more, the payload will be invalid and you will receive the "New notification" notification.</span></span>


## <a name="usage-guidance"></a><span data-ttu-id="b6e62-114">使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="b6e62-114">Usage guidance</span></span>

<span data-ttu-id="b6e62-115">一般に、ほとんどのアプリでは、カスタム タイムスタンプを指定することが適切です。</span><span class="sxs-lookup"><span data-stu-id="b6e62-115">In general, we recommend that most apps specify a custom timestamp.</span></span> <span data-ttu-id="b6e62-116">これにより、ネットワーク遅延、機内モード、定期的なバックグラウンド タスクのための一定間隔の中断があっても、それらに関係なく、メッセージ、情報、コンテンツの生成時刻が通知のタイムスタンプに正確に反映されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-116">This ensures that the notification's timestamp accurately represents when the message/information/content was generated, regardless of network delays, airplane mode, or the fixed interval of periodic background tasks.</span></span>

<span data-ttu-id="b6e62-117">たとえば、ニュース アプリが 15 分ごとにバックグラウンド タスクを実行して、新しい記事を確認し、通知を表示する場合があります。</span><span class="sxs-lookup"><span data-stu-id="b6e62-117">For example, a news app might run a background task every 15 minutes that checks for new articles and displays notifications.</span></span> <span data-ttu-id="b6e62-118">カスタム スタンプが導入されるまで、タイムスタンプはトースト通知が生成された時刻に対応していました (そのため、常に 15 分間隔でした)。</span><span class="sxs-lookup"><span data-stu-id="b6e62-118">Before custom timestamps, the timestamp corresponded to when the toast notification was generated (therefore always in 15 minute intervals).</span></span> <span data-ttu-id="b6e62-119">しかし今では、記事が実際に発行された時刻が表示されるように、アプリがタイムスタンプを設定できます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-119">However, now the app can set the timestamp to the time the article was actually published.</span></span> <span data-ttu-id="b6e62-120">同様に、メール アプリやソーシャル ネットワーク アプリで、同じようなパターンの定期的なチェックを使用して通知が行われている場合も、この機能が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-120">Similarly, email apps and social network apps can benefit from this feature if a similar pattern of periodic pulling is used for their notifications.</span></span>

<span data-ttu-id="b6e62-121">さらに、カスタム タイムスタンプを使用すると、ユーザーがインターネットから切断された場合でも、タイムスタンプが正確に表示されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-121">Additionally, providing a custom timestamp ensures that the timestamp is correct even if the user was disconnected from the internet.</span></span> <span data-ttu-id="b6e62-122">たとえば、ユーザーがコンピューターをオンにし、バックグラウンド タスクを実行してようやく通知が表示された場合でも、通知のタイムスタンプは、ユーザーがコンピューターのスイッチを入れた時刻ではなく、メッセージが送信された時間を表します。</span><span class="sxs-lookup"><span data-stu-id="b6e62-122">For example, when the user turns their computer on and your background task runs, you can finally ensure that the timestamp on your notifications represents the time that the messages were sent, rather than the time the user turned on their computer.</span></span>


## <a name="default-timestamp"></a><span data-ttu-id="b6e62-123">既定のタイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="b6e62-123">Default timestamp</span></span>

<span data-ttu-id="b6e62-124">カスタム タイムスタンプを設定しない場合、通知が送信された時刻が使用されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-124">If you don't provide a custom timestamp, we use the time that your notification was sent.</span></span>

<span data-ttu-id="b6e62-125">WNS 経由でプッシュ通知を送信した場合は、WNS サーバーが通知を受信した時刻が使用されます (したがって、デバイスへの通知の配信が遅れても、タイムスタンプには影響はありません)。</span><span class="sxs-lookup"><span data-stu-id="b6e62-125">If you sent a push notification through WNS, we use the time when the notification was received by WNS server (so any latency on delivering the notification to the device won't impact the timestamp).</span></span>

<span data-ttu-id="b6e62-126">ローカルの通知を送信した場合、通知プラットフォームが通知を受信した時刻 (通常は送信直後) が使用されます。</span><span class="sxs-lookup"><span data-stu-id="b6e62-126">If you sent a local notification, we use the time when the notification platform received the notification (which should be immediately).</span></span>


## <a name="related-topics"></a><span data-ttu-id="b6e62-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b6e62-127">Related topics</span></span>

- [<span data-ttu-id="b6e62-128">ローカル トーストの送信</span><span class="sxs-lookup"><span data-stu-id="b6e62-128">Send a local toast</span></span>](send-local-toast.md)
- [<span data-ttu-id="b6e62-129">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="b6e62-129">Toast content documentation</span></span>](adaptive-interactive-toasts.md)