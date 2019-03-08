---
Description: 通知がトースト通知でミラーリングを使用する方法について説明します。
title: 通知のミラーリング
label: Notification mirroring
template: detail.hbs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, 通知のミラーリング, 通知, クロス デバイス
ms.localizationpriority: medium
ms.openlocfilehash: dc870601159a80bc6d03a287fd19f082e968e09e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657317"
---
# <a name="notification-mirroring"></a><span data-ttu-id="3674c-104">通知のミラーリング</span><span class="sxs-lookup"><span data-stu-id="3674c-104">Notification mirroring</span></span>

<span data-ttu-id="3674c-105">クラウド環境にあるアクション センターが提供する通知のミラーリング機能を使用すると、電話宛ての通知を PC で表示できます。</span><span class="sxs-lookup"><span data-stu-id="3674c-105">Notification mirroring, powered by Action Center in the Cloud, allows you to see your phone's notifications on your PC.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3674c-106">**Anniversary Update が必要です**:ミラーリングの通知が表示するには、14393 以上現在のビルドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3674c-106">**Requires Anniversary Update**: You must be running build 14393 or higher to see notification mirroring work.</span></span> <span data-ttu-id="3674c-107">アプリ単位で通知のミラーリングをオプトアウトするには、SDK 14393 をターゲットに設定して、ミラーリング API にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3674c-107">If you would like to opt your app out of notification mirroring, you must target SDK 14393 to access the mirroring APIs.</span></span>

<span data-ttu-id="3674c-108">通知のミラーリングと Cortana を併用すると、ユーザーは電話宛ての通知 (Windows Mobile および Android) を PC で便利に受け取って、対応することができます。</span><span class="sxs-lookup"><span data-stu-id="3674c-108">With notification mirroring and Cortana, users can receive and act on their phone's notifications (Windows Mobile and Android) from the convenience of their PC.</span></span> <span data-ttu-id="3674c-109">開発者は、通知のミラーリングを有効にするために、特に操作する必要はありません。ミラーリングは自動的に動作します。</span><span class="sxs-lookup"><span data-stu-id="3674c-109">As a developer, you don't have to do anything to enable notification mirroring, mirroring automatically works!</span></span> <span data-ttu-id="3674c-110">ミラー化されたトーストでボタンをクリックすると (メッセージにすばやく応答する場合など)、電話にルーティングされて、バックグラウンド タスクまたはフォアグラウンド アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="3674c-110">Clicking buttons on the mirrored toast, like message quick replies, will be routed back to the phone, invoking you background task or launching your foreground app.</span></span>

<img alt="Notification mirroring diagram" src="images/toast-mirroring.gif" width="350"/>

<span data-ttu-id="3674c-111">開発者は、通知のミラーリングを 2 つの大きな特典がありますを取得します。ミラー化された通知が発生する、サービスで複数のユーザー エンゲージメントと、ユーザーは、Microsoft Store のデスクトップ アプリの検出にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3674c-111">Developers get two great benefits from notification mirroring: The mirrored notifications result in more user engagement with your service, and they also help users discover your Microsoft Store desktop app!</span></span> <span data-ttu-id="3674c-112">開発者が Windows 10 デスクトップ向けの優れた UWP アプリを提供していても、それがユーザーに認知されていないことがあります。</span><span class="sxs-lookup"><span data-stu-id="3674c-112">Your users might not even know that you have an awesome UWP app available for their Windows 10 desktop.</span></span> <span data-ttu-id="3674c-113">ユーザーが自分のスマート フォンからミラー化された通知を受信すると、ユーザーは、するため、UWP のデスクトップ アプリをインストールできる、Microsoft Store にトースト通知をクリックできます。</span><span class="sxs-lookup"><span data-stu-id="3674c-113">When users receive the mirrored notification from their phone, users can click the toast notification to be taken to the Microsoft Store, where they can install your UWP desktop app.</span></span>

<span data-ttu-id="3674c-114">ミラーリングは、Windows Phone と Android の両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="3674c-114">Mirroring works with both Windows Phone and Android.</span></span> <span data-ttu-id="3674c-115">通知のミラーリングを使用するには、ユーザーが電話とデスクトップの両方で Cortana にログインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3674c-115">Users need to be logged into Cortana on both their phone and desktop for notification mirroring to work.</span></span>


## <a name="what-if-the-app-is-installed-on-both-devices"></a><span data-ttu-id="3674c-116">両方のデバイスでアプリがインストールされている場合</span><span class="sxs-lookup"><span data-stu-id="3674c-116">What if the app is installed on both devices?</span></span>

<span data-ttu-id="3674c-117">ユーザーの PC にアプリが既にインストールされている場合、通知が重複して表示されないように、ミラー化された電話の通知が自動的にミュートされます。</span><span class="sxs-lookup"><span data-stu-id="3674c-117">If the user already has your app on their PC, we will automatically mute the mirrored phone notification so that they don't see duplicate notifications.</span></span> <span data-ttu-id="3674c-118">ミラー化された通知は、次の条件に基いて自動的にミュートされます。</span><span class="sxs-lookup"><span data-stu-id="3674c-118">Mirrored notifications will be auto-muted based on the following criteria...</span></span>

1. <span data-ttu-id="3674c-119">**同じ表示名または同じ PFN** (パッケージ ファミリ名) のアプリが PC 上に存在する</span><span class="sxs-lookup"><span data-stu-id="3674c-119">An app on the PC exists with either the **same display name or the same PFN** (Package Family Name)</span></span>
2. <span data-ttu-id="3674c-120">その PC アプリがトースト通知を送信した</span><span class="sxs-lookup"><span data-stu-id="3674c-120">That PC app has sent a toast notification</span></span>

<span data-ttu-id="3674c-121">PC アプリがトーストをまだ送信していない場合は、ユーザーがまだ PC を起動していない可能性があるため、引き続き電話に通知が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3674c-121">If the PC app hasn't sent a toast yet, we'll still show the phone notifications, since chances are, the user hasn't actually launched the PC app yet).</span></span>


## <a name="how-to-opt-out-of-mirroring"></a><span data-ttu-id="3674c-122">ミラーリングをオプトアウトする方法</span><span class="sxs-lookup"><span data-stu-id="3674c-122">How to opt out of mirroring</span></span>

<span data-ttu-id="3674c-123">UWP アプリ開発者、企業、ユーザーは、通知のミラーリングを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="3674c-123">UWP app developers, enterprises, and users can choose to disable notification mirroring.</span></span>

> [!NOTE]
> <span data-ttu-id="3674c-124">ミラーリングを無効にすると、[ユニバーサル無視](universal-dismiss.md)も無効になります。</span><span class="sxs-lookup"><span data-stu-id="3674c-124">Disabling mirroring will also disable [Universal Dismiss](universal-dismiss.md).</span></span>


### <a name="as-a-developer-opt-out-an-individual-notification"></a><span data-ttu-id="3674c-125">開発者として、個別の通知をオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="3674c-125">As a developer, opt out an individual notification</span></span>

<span data-ttu-id="3674c-126">たとえば、デバイス固有の通知を他のデバイスにミラーリングすることはあまり意味がありません。</span><span class="sxs-lookup"><span data-stu-id="3674c-126">You occasionally might have a device-specific notification that you don't want to be mirrored to other devices.</span></span> <span data-ttu-id="3674c-127">特定の通知についてミラーリングを無効にするには、トースト通知の **Mirroring**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3674c-127">You can prevent a specific notification from being mirrored by setting the **Mirroring** property on the toast notification.</span></span> <span data-ttu-id="3674c-128">現時点では、このミラーリング プロパティは、ローカルの通知にのみ設定できます (WNS プッシュ通知の送信時には設定できません)。</span><span class="sxs-lookup"><span data-stu-id="3674c-128">Currently, this mirroring property can only be set on local notifications (it can not be specified when sending a WNS push notification).</span></span>

<span data-ttu-id="3674c-129">**既知の問題**:使用してミラーリングのプロパティを取得する、`ToastNotificationHistory.GetHistory()`の API には、既定値は常に返します (**許可**) 指定したオプションではなく。</span><span class="sxs-lookup"><span data-stu-id="3674c-129">**Known Issue**: Retrieving the Mirroring property via the `ToastNotificationHistory.GetHistory()` API's will always return the default value (**Allowed**) rather than the option you specified.</span></span> <span data-ttu-id="3674c-130">しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。</span><span class="sxs-lookup"><span data-stu-id="3674c-130">Don't worry, everything is functional - it's only retrieving the value that's broken.</span></span>

```csharp
var toast = new ToastNotification(xml)
{
    // Disable mirroring of this notification
    Mirroring = NotificationMirroring.Disabled
};
  
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


### <a name="as-a-developer-opt-out-completely"></a><span data-ttu-id="3674c-131">開発者として、すべてをオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="3674c-131">As a developer, opt out completely</span></span>

<span data-ttu-id="3674c-132">開発者によっては、開発するアプリで通知のミラーリングを完全にオプトアウトすることがあります。</span><span class="sxs-lookup"><span data-stu-id="3674c-132">Some developers might choose to completely opt their app out of notification mirroring.</span></span> <span data-ttu-id="3674c-133">ミラーリングからすべてのアプリができればと考えています中に簡単にオプトアウトします。1 回、次のメソッドを呼び出すだけと、アプリをオプトアウトします。たとえば、この呼び出しを配置内で、アプリのコンス トラクターで`App.xaml.cs`.</span><span class="sxs-lookup"><span data-stu-id="3674c-133">While we believe that all apps would benefit from mirroring, we make it easy to opt out. Just call the following method once, and your app will be opted out. For example, you can place this call in your app's constructor inside `App.xaml.cs`...</span></span>

```csharp
public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;
 
    // Disable notification mirroring for entire app
    ToastNotificationManager.ConfigureNotificationMirroring(NotificationMirroring.Disabled);
}
```


### <a name="as-an-enterprise-how-do-i-opt-out"></a><span data-ttu-id="3674c-134">企業としてオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="3674c-134">As an enterprise, how do I opt out?</span></span>

<span data-ttu-id="3674c-135">企業は、通知のミラーリングを完全に無効にできます。</span><span class="sxs-lookup"><span data-stu-id="3674c-135">Enterprises can choose to completely disable notification mirroring.</span></span> <span data-ttu-id="3674c-136">これには、単純にグループ ポリシーを編集して、通知のミラーリングをオフにします。</span><span class="sxs-lookup"><span data-stu-id="3674c-136">To do so, they simply edit the Group Policy to turn off notification mirroring.</span></span>


### <a name="as-a-user-how-do-i-opt-out"></a><span data-ttu-id="3674c-137">ユーザーとしてオプトアウトする</span><span class="sxs-lookup"><span data-stu-id="3674c-137">As a user, how do I opt out?</span></span>

<span data-ttu-id="3674c-138">ユーザーは個別のアプリでオプトアウトすることも、機能を無効にして完全にオプトアウトすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3674c-138">Users are able to opt out on individual apps, or completely opt out by disabling the feature.</span></span> <span data-ttu-id="3674c-139">特定のアプリの通知をデスクトップにミラーリングしない場合は、その特定のアプリについてのみ無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="3674c-139">You may not want a specific app's notifications mirrored to your desktop, so you can simply disable that specific app.</span></span> <span data-ttu-id="3674c-140">このオプションは、電話と PC の両方の Cortana の設定にあります。</span><span class="sxs-lookup"><span data-stu-id="3674c-140">You can find these options in Cortana's settings on both your phone and PC.</span></span>