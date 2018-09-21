---
author: andrewleader
Description: Learn how to use Universal Dismiss on your toast notifications.
title: ユニバーサル無視
label: Universal Dismiss
template: detail.hbs
ms.author: mijacobs
ms.date: 12/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, ユニバーサル無視, 通知, クロス デバイス, 一括承諾
ms.localizationpriority: medium
ms.openlocfilehash: 90ad60949504d4478341ff9455fe0f7da90d78a9
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4116298"
---
# <a name="universal-dismiss"></a><span data-ttu-id="2c77d-103">ユニバーサル無視</span><span class="sxs-lookup"><span data-stu-id="2c77d-103">Universal Dismiss</span></span>

<span data-ttu-id="2c77d-104">ユニバーサル無視は、クラウド環境にあるアクション センターによって提供され、1 つのデバイスで通知を無視すると、他のデバイス上の同じ通知が併せて無視される機能です。</span><span class="sxs-lookup"><span data-stu-id="2c77d-104">Universal Dismiss, powered by Action Center in the Cloud, means that when you dismiss a notification from one device, the same notification on your other devices is also dismissed.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2c77d-105">**Anniversary Update が必要**: ユニバーサル無視を使用するには、SDK 14393 以降をターゲットとし、ビルド 14393 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="2c77d-105">**Requires Anniversary Update**: You must target SDK 14393 and be running build 14393 or higher to use Universal Dismiss.</span></span>

<span data-ttu-id="2c77d-106">このシナリオの一般的な例に、カレンダーのリマインダーがあります。電話とデスクトップの両方にカレンダー アプリがインストールされていて、両方のデバイスでリマインダーを受け取った場合、デスクトップで無視のボタンをクリックすれば、ユニバーサル無視の機能により、電話のリマインダーも併せて無視されます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-106">The common example of this scenario is calendar reminders... you have a calendar app on both of your devices... you get a reminder on your phone and desktop... you click dismiss on your desktop... thanks to Universal Dismiss, the reminder on your phone is also dismissed!</span></span> **<span data-ttu-id="2c77d-107">ユニバーサル無視は、コードに 1 行追加するだけで有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-107">Enabling Universal Dismiss only requires one line of code!</span></span>**

<img alt="Diagram of Universal Dismiss" src="images/universal-dismiss.gif" width="406"/>

<span data-ttu-id="2c77d-108">このシナリオの重要なポイントは、**複数のデバイスに同じアプリがインストールされていること**、つまり、**既に両方のデバイスが通知を受信する状態にあること**です。</span><span class="sxs-lookup"><span data-stu-id="2c77d-108">In this scenario, the key fact is that **the same app is installed on multiple devices**, meaning that **each device is already receiving notifications**.</span></span> <span data-ttu-id="2c77d-109">カレンダー アプリはこの代表的な例です。通常、カレンダー アプリは、Windows PC と電話の両方にインストールされ、アプリのそれぞれのインスタンスが既にそれそれのデバイスにリマインダーを送信しています。</span><span class="sxs-lookup"><span data-stu-id="2c77d-109">A calendar app is the iconic example, since you typically have the same calendar app installed on both your Windows PC and your phone, and each instance of the app already sends you reminders on each device.</span></span> <span data-ttu-id="2c77d-110">ユニバーサル無視のサポートを追加すると、同じリマインダーの複数のインスタンスをデバイス間でリンクできます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-110">By adding support for Universal Dismiss, those instances of the same reminders can be linked across devices.</span></span>


## <a name="how-to-enable-universal-dismiss"></a><span data-ttu-id="2c77d-111">ユニバーサル無視を有効にする方法</span><span class="sxs-lookup"><span data-stu-id="2c77d-111">How to enable Universal Dismiss</span></span>

<span data-ttu-id="2c77d-112">開発者にとって、ユニバーサル無視を有効にする手順は非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="2c77d-112">As a developer, enabling Universal Dismiss is extremely easy.</span></span> <span data-ttu-id="2c77d-113">必要なのは、デバイス間で通知をリンクできるように ID を指定することだけです。これにより、ユーザーが 1 つのデバイスで通知を無視すると、それに対応するリンクされた通知が他のデバイスで無視されます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-113">You simply need to provide an ID that allows us to link each notification across devices, so that when the user dismisses a notification from one device, the corresponding linked notification is dismissed from the other device.</span></span>

![ユニバーサル無視の RemoteId の図](images/universal-dismiss-remoteid.jpg)

> <span data-ttu-id="2c77d-115">**RemoteId**: *複数のデバイス間で*通知を一意に識別する識別子です。</span><span class="sxs-lookup"><span data-stu-id="2c77d-115">**RemoteId**: An identifier that uniquely identifies a notification *across devices*.</span></span>

<span data-ttu-id="2c77d-116">RemoteId は、コードに 1 行追加するだけで設定でき、それによってユニバーサル無視のサポートが有効になります。</span><span class="sxs-lookup"><span data-stu-id="2c77d-116">t only takes one line of code to add RemoteId, enabling support for Universal Dismiss!</span></span> <span data-ttu-id="2c77d-117">RemoteId の生成方法は開発者が自由に決定できますが、複数のデバイス間で通知を一意に識別でき、かつ異なるデバイス上で動作する同じアプリの異なるインスタンスで、同一の識別子を生成できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="2c77d-117">How you generate your RemoteId is up to you - however, you need to make sure that it uniquely identifies your notification across devices, and that the same identifier can be generated from different instances of your app running on different devices.</span></span>

<span data-ttu-id="2c77d-118">たとえば、宿題プランナー アプリについて有効にする場合を考えてみましょう。まず、種類が "reminder" であることを指定して RemoteId を生成した後、宿題項目のオンライン アカウント ID とオンライン識別子を設定します。</span><span class="sxs-lookup"><span data-stu-id="2c77d-118">For example, in my homework planner app, I generate my RemoteId by saying that it is of type "reminder", and then I include the online account ID and the online identifier of the homework item.</span></span> <span data-ttu-id="2c77d-119">これらのオンライン ID はデバイス間で共有されているため、通知を送信するデバイスにかかわらず、同じ正確な RemoteId を一貫して生成することができます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-119">I can consistently generate the exact same RemoteId, regardless of which device is sending the notification, since these online IDs are shared across the devices.</span></span>

```csharp
var toast = new ScheduledToastNotification(content.GetXml(), startTime);
 
// If the RemoteId property is present
if (ApiInformation.IsPropertyPresent(typeof(ScheduledToastNotification).FullName, nameof(ScheduledToastNotification.RemoteId)))
{
    // Assign the RemoteId to add support for Universal Dismiss
    toast.RemoteId = $"reminder_{account.AccountId}_{homework.Identifier}"
}
  
ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
```

<span data-ttu-id="2c77d-120">以下のコードは、電話アプリとデスクトップ アプリの両方で実行されるため、両方のデバイスの通知は、同じ RemoteId を持つことになります。</span><span class="sxs-lookup"><span data-stu-id="2c77d-120">The following code runs on both my phone and desktop app, meaning that the notification on both devices will have the same RemoteId.</span></span>

<span data-ttu-id="2c77d-121">必要な作業はこれだけです。</span><span class="sxs-lookup"><span data-stu-id="2c77d-121">That's all you have to do!</span></span> <span data-ttu-id="2c77d-122">ユーザーが通知を無視 (またはクリック) すると、アプリはそれが RemoteId であるかどうかを確認し、そうである場合は、ユーザーのすべてのデバイスに対してその RemoteId を無視するように情報を拡散します。</span><span class="sxs-lookup"><span data-stu-id="2c77d-122">When the user dismisses (or clicks on) a notification, we'll check if it has a RemoteId, and if so, we'll fan out a dismiss of that RemoteId across all the user's devices.</span></span>

<span data-ttu-id="2c77d-123">**既知の問題**: `ToastNotificationHistory.GetHistory()` API 経由で **RemoteId** を取得すると、指定した **RemoteId** ではなく、常に空の文字列が返されます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-123">**Known Issue**: Retrieving the **RemoteId** via the `ToastNotificationHistory.GetHistory()` API's will always return empty string rather than the **RemoteId** you specified.</span></span> <span data-ttu-id="2c77d-124">しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。</span><span class="sxs-lookup"><span data-stu-id="2c77d-124">Don't worry, everything is functional - it's only retrieving the value that's broken.</span></span>

> [!NOTE]
> <span data-ttu-id="2c77d-125">通知はクラウド上には存在しないため、ユーザーや企業がアプリで[通知のミラーリング](notification-mirroring.md)を無効にすると (または通知のミラーリング自体を完全に無効にすると)、ユニバーサル無視が機能しなくなります。</span><span class="sxs-lookup"><span data-stu-id="2c77d-125">If the user or enterprise disables [notification mirroring](notification-mirroring.md) for your app (or completely disables notification mirroring), then Universal Dismiss will not work, since we do not have your notifications in the cloud.</span></span>


## <a name="supported-devices"></a><span data-ttu-id="2c77d-126">サポートされるデバイス</span><span class="sxs-lookup"><span data-stu-id="2c77d-126">Supported devices</span></span>

<span data-ttu-id="2c77d-127">Anniversary Update 以降、ユニバーサル無視は、Windows Mobile および Windows デスクトップでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="2c77d-127">Since the Anniversary Update, Universal Dismiss is supported on Windows Mobile and Windows Desktop.</span></span> <span data-ttu-id="2c77d-128">ユニバーサル無視は、PC 間、PC と電話間、電話間で双方向に機能します。</span><span class="sxs-lookup"><span data-stu-id="2c77d-128">Universal Dismiss works both directions, between PC-PC, PC-Phone, and Phone-Phone.</span></span>