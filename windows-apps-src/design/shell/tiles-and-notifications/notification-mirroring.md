---
author: andrewleader
Description: Learn how to use notification mirroring on your toast notifications.
title: 通知のミラーリング
label: Notification mirroring
template: detail.hbs
ms.author: mijacobs
ms.date: 12/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, 通知のミラーリング, 通知, クロス デバイス
ms.localizationpriority: medium
ms.openlocfilehash: eb8e2ceb16add551f3c8e3a71a69d36b99f21c62
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4091896"
---
# <a name="notification-mirroring"></a><span data-ttu-id="0e3cf-103">通知のミラーリング</span><span class="sxs-lookup"><span data-stu-id="0e3cf-103">Notification mirroring</span></span>

<span data-ttu-id="0e3cf-104">クラウド環境にあるアクション センターが提供する通知のミラーリング機能を使用すると、電話宛ての通知を PC で表示できます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-104">Notification mirroring, powered by Action Center in the Cloud, allows you to see your phone's notifications on your PC.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0e3cf-105">**Anniversary Update が必要**: 通知のミラーリングを使用するには、ビルド 14393 以上を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-105">**Requires Anniversary Update**: You must be running build 14393 or higher to see notification mirroring work.</span></span> <span data-ttu-id="0e3cf-106">アプリ単位で通知のミラーリングをオプトアウトするには、SDK 14393 をターゲットに設定して、ミラーリング API にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-106">If you would like to opt your app out of notification mirroring, you must target SDK 14393 to access the mirroring APIs.</span></span>

<span data-ttu-id="0e3cf-107">通知のミラーリングと Cortana を併用すると、ユーザーは電話宛ての通知 (Windows Mobile および Android) を PC で便利に受け取って、対応することができます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-107">With notification mirroring and Cortana, users can receive and act on their phone's notifications (Windows Mobile and Android) from the convenience of their PC.</span></span> <span data-ttu-id="0e3cf-108">開発者は、通知のミラーリングを有効にするために、特に操作する必要はありません。ミラーリングは自動的に動作します。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-108">As a developer, you don't have to do anything to enable notification mirroring, mirroring automatically works!</span></span> <span data-ttu-id="0e3cf-109">ミラー化されたトーストでボタンをクリックすると (メッセージにすばやく応答する場合など)、電話にルーティングされて、バックグラウンド タスクまたはフォアグラウンド アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-109">Clicking buttons on the mirrored toast, like message quick replies, will be routed back to the phone, invoking you background task or launching your foreground app.</span></span>

<img alt="Notification mirroring diagram" src="images/toast-mirroring.gif" width="350"/>

<span data-ttu-id="0e3cf-110">開発者は、通知のミラーリングから 2 つの主な利点を取得する: ミラー化された通知が発生すると、サービスのユーザー エンゲージメントと、ユーザーが、Microsoft Store のデスクトップ アプリを検出も役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-110">Developers get two great benefits from notification mirroring: The mirrored notifications result in more user engagement with your service, and they also help users discover your Microsoft Store desktop app!</span></span> <span data-ttu-id="0e3cf-111">開発者が Windows 10 デスクトップ向けの優れた UWP アプリを提供していても、それがユーザーに認知されていないことがあります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-111">Your users might not even know that you have an awesome UWP app available for their Windows 10 desktop.</span></span> <span data-ttu-id="0e3cf-112">ユーザーが自分の電話からミラー化された通知を受信ユーザーできる UWP デスクトップ アプリをインストールする、Microsoft Store にトースト通知] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-112">When users receive the mirrored notification from their phone, users can click the toast notification to be taken to the Microsoft Store, where they can install your UWP desktop app.</span></span>

<span data-ttu-id="0e3cf-113">ミラーリングは、Windows Phone と Android の両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-113">Mirroring works with both Windows Phone and Android.</span></span> <span data-ttu-id="0e3cf-114">通知のミラーリングを使用するには、ユーザーが電話とデスクトップの両方で Cortana にログインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-114">Users need to be logged into Cortana on both their phone and desktop for notification mirroring to work.</span></span>


## <a name="what-if-the-app-is-installed-on-both-devices"></a><span data-ttu-id="0e3cf-115">両方のデバイスでアプリがインストールされている場合</span><span class="sxs-lookup"><span data-stu-id="0e3cf-115">What if the app is installed on both devices?</span></span>

<span data-ttu-id="0e3cf-116">ユーザーの PC にアプリが既にインストールされている場合、通知が重複して表示されないように、ミラー化された電話の通知が自動的にミュートされます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-116">If the user already has your app on their PC, we will automatically mute the mirrored phone notification so that they don't see duplicate notifications.</span></span> <span data-ttu-id="0e3cf-117">ミラー化された通知は、次の条件に基いて自動的にミュートされます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-117">Mirrored notifications will be auto-muted based on the following criteria...</span></span>

1. <span data-ttu-id="0e3cf-118">**同じ表示名または同じ PFN** (パッケージ ファミリ名) のアプリが PC 上に存在する</span><span class="sxs-lookup"><span data-stu-id="0e3cf-118">An app on the PC exists with either the **same display name or the same PFN** (Package Family Name)</span></span>
2. <span data-ttu-id="0e3cf-119">その PC アプリがトースト通知を送信した</span><span class="sxs-lookup"><span data-stu-id="0e3cf-119">That PC app has sent a toast notification</span></span>

<span data-ttu-id="0e3cf-120">PC アプリがトーストをまだ送信していない場合は、ユーザーがまだ PC を起動していない可能性があるため、引き続き電話に通知が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-120">If the PC app hasn't sent a toast yet, we'll still show the phone notifications, since chances are, the user hasn't actually launched the PC app yet).</span></span>


## <a name="how-to-opt-out-of-mirroring"></a><span data-ttu-id="0e3cf-121">ミラーリングをオプトアウトする方法</span><span class="sxs-lookup"><span data-stu-id="0e3cf-121">How to opt out of mirroring</span></span>

<span data-ttu-id="0e3cf-122">UWP アプリ開発者、企業、ユーザーは、通知のミラーリングを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-122">UWP app developers, enterprises, and users can choose to disable notification mirroring.</span></span>

> [!NOTE]
> <span data-ttu-id="0e3cf-123">ミラーリングを無効にすると、[ユニバーサル無視](universal-dismiss.md)も無効になります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-123">Disabling mirroring will also disable [Universal Dismiss](universal-dismiss.md).</span></span>


### <a name="as-a-developer-opt-out-an-individual-notification"></a><span data-ttu-id="0e3cf-124">開発者として、個別の通知をオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="0e3cf-124">As a developer, opt out an individual notification</span></span>

<span data-ttu-id="0e3cf-125">たとえば、デバイス固有の通知を他のデバイスにミラーリングすることはあまり意味がありません。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-125">You occasionally might have a device-specific notification that you don't want to be mirrored to other devices.</span></span> <span data-ttu-id="0e3cf-126">特定の通知についてミラーリングを無効にするには、トースト通知の **Mirroring**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-126">You can prevent a specific notification from being mirrored by setting the **Mirroring** property on the toast notification.</span></span> <span data-ttu-id="0e3cf-127">現時点では、このミラーリング プロパティは、ローカルの通知にのみ設定できます (WNS プッシュ通知の送信時には設定できません)。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-127">Currently, this mirroring property can only be set on local notifications (it can not be specified when sending a WNS push notification).</span></span>

<span data-ttu-id="0e3cf-128">**既知の問題**: `ToastNotificationHistory.GetHistory()` API 経由で Mirroring プロパティを取得すると、指定したオプションではなく、常に既定値 (**Allowed**) が返されます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-128">**Known Issue**: Retrieving the Mirroring property via the `ToastNotificationHistory.GetHistory()` API's will always return the default value (**Allowed**) rather than the option you specified.</span></span> <span data-ttu-id="0e3cf-129">しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-129">Don't worry, everything is functional - it's only retrieving the value that's broken.</span></span>

```csharp
var toast = new ToastNotification(xml)
{
    // Disable mirroring of this notification
    Mirroring = NotificationMirroring.Disabled
};
  
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


### <a name="as-a-developer-opt-out-completely"></a><span data-ttu-id="0e3cf-130">開発者として、すべてをオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="0e3cf-130">As a developer, opt out completely</span></span>

<span data-ttu-id="0e3cf-131">開発者によっては、開発するアプリで通知のミラーリングを完全にオプトアウトすることがあります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-131">Some developers might choose to completely opt their app out of notification mirroring.</span></span> <span data-ttu-id="0e3cf-132">ミラーリングの使用はすべてのアプリにとってメリットがありますが、オプトアウトすることも簡単です。次のメソッドを 1 回呼び出すだけで、アプリがオプトアウトされます。この呼び出しは、たとえば、アプリの `App.xaml.cs` 内のコンストラクターに配置できます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-132">While we believe that all apps would benefit from mirroring, we make it easy to opt out. Just call the following method once, and your app will be opted out. For example, you can place this call in your app's constructor inside `App.xaml.cs`...</span></span>

```csharp
public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;
 
    // Disable notification mirroring for entire app
    ToastNotificationManager.ConfigureNotificationMirroring(NotificationMirroring.Disabled);
}
```


### <a name="as-an-enterprise-how-do-i-opt-out"></a><span data-ttu-id="0e3cf-133">企業としてオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="0e3cf-133">As an enterprise, how do I opt out?</span></span>

<span data-ttu-id="0e3cf-134">企業は、通知のミラーリングを完全に無効にできます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-134">Enterprises can choose to completely disable notification mirroring.</span></span> <span data-ttu-id="0e3cf-135">これには、単純にグループ ポリシーを編集して、通知のミラーリングをオフにします。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-135">To do so, they simply edit the Group Policy to turn off notification mirroring.</span></span>


### <a name="as-a-user-how-do-i-opt-out"></a><span data-ttu-id="0e3cf-136">ユーザーとしてオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="0e3cf-136">As a user, how do I opt out?</span></span>

<span data-ttu-id="0e3cf-137">ユーザーは個別のアプリでオプトアウトすることも、機能を無効にして完全にオプトアウトすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-137">Users are able to opt out on individual apps, or completely opt out by disabling the feature.</span></span> <span data-ttu-id="0e3cf-138">特定のアプリの通知をデスクトップにミラーリングしない場合は、その特定のアプリについてのみ無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-138">You may not want a specific app's notifications mirrored to your desktop, so you can simply disable that specific app.</span></span> <span data-ttu-id="0e3cf-139">このオプションは、電話と PC の両方の Cortana の設定にあります。</span><span class="sxs-lookup"><span data-stu-id="0e3cf-139">You can find these options in Cortana's settings on both your phone and PC.</span></span>