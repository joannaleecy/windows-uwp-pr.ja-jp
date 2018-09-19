---
author: andrewleader
Description: Learn how to use Notification Listener to access all of the user's notifications.
title: 通知リスナー
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Chaseable tiles
template: detail.hbs
ms.author: mijacobs
ms.date: 06/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 通知リスナー, usernotificationlistener, ドキュメント, 通知へのアクセス
ms.localizationpriority: medium
ms.openlocfilehash: f4d8cb9ef7589bd8f0c56586ab8fcfec7c1f01e3
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4060954"
---
# <a name="notification-listener-access-all-notifications"></a><span data-ttu-id="6fbf2-103">通知リスナー: すべての通知にアクセスする</span><span class="sxs-lookup"><span data-stu-id="6fbf2-103">Notification listener: Access all notifications</span></span>

<span data-ttu-id="6fbf2-104">通知リスナーを使用すると、ユーザーの通知にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-104">The notification listener provides access to a user's notifications.</span></span> <span data-ttu-id="6fbf2-105">スマートウォッチや他のウェアラブルでは、通知リスナーを使用して、電話の通知をウェアラブル デバイスに送信することができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-105">Smartwatches and other wearables can use the notification listener to send the phone's notifications to the wearable device.</span></span> <span data-ttu-id="6fbf2-106">ホーム オートメーション アプリでは、通知リスナーを使用して、通知を受信したときに特定のアクション (電話がかかってきたときにランプを点滅するなど) を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-106">Home automation apps can use notification listener to perform specific actions when notifications are received, such as making the lights blink when you recieve a call.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="6fbf2-107">**Anniversary Update が必要**: 通知リスナーを使用するには、SDK 14393 以降をターゲットとし、ビルド 14393 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-107">**Requires Anniversary Update**: You must target SDK 14393 and be running build 14393 or higher to use Notification Listener.</span></span>


> <span data-ttu-id="6fbf2-108">**重要な API**: [UserNotificationListener クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.Management.UserNotificationListener)、[UserNotificationChangedTrigger クラス](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.UserNotificationChangedTrigger)</span><span class="sxs-lookup"><span data-stu-id="6fbf2-108">**Important APIs**: [UserNotificationListener class](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.Management.UserNotificationListener), [UserNotificationChangedTrigger class](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.UserNotificationChangedTrigger)</span></span>


## <a name="enable-the-listener-by-adding-the-user-notification-capability"></a><span data-ttu-id="6fbf2-109">ユーザー通知機能を追加して、リスナーを有効にする</span><span class="sxs-lookup"><span data-stu-id="6fbf2-109">Enable the listener by adding the User Notification capability</span></span> 

<span data-ttu-id="6fbf2-110">通知リスナーを使用するには、ユーザー通知リスナー機能をアプリ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-110">To use the notification listener, you must add the User Notification Listener capability to your app manifest.</span></span>

1. <span data-ttu-id="6fbf2-111">Visual Studio のソリューション エクスプローラーで、`Package.appxmanifest` ファイルをダブルクリックし、マニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-111">In Visual Studio, in the Solution Explorer, double click your `Package.appxmanifest` file to open the manifest designer.</span></span>
2. <span data-ttu-id="6fbf2-112">[機能] タブを開きます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-112">Open the Capabilities tab.</span></span>
3. <span data-ttu-id="6fbf2-113">**[ユーザー通知リスナー]** 機能をオンにします。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-113">Check the **User Notification Listener** capability.</span></span>


## <a name="check-whether-the-listener-is-supported"></a><span data-ttu-id="6fbf2-114">リスナーがサポートされているかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="6fbf2-114">Check whether the listener is supported</span></span>

<span data-ttu-id="6fbf2-115">アプリで Windows 10 の以前のバージョンをサポートする場合は、[ApiInformation クラス](https://docs.microsoft.com/uwp/api/Windows.Foundation.Metadata.ApiInformation) を使用して、リスナーがサポートされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-115">If your app supports older versions of Windows 10, you need to use the [ApiInformation class](https://docs.microsoft.com/uwp/api/Windows.Foundation.Metadata.ApiInformation) to check whether the listener is supported.</span></span>  <span data-ttu-id="6fbf2-116">リスナーがサポートされていない場合は、リスナー API の呼び出しを実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-116">If the listener isn't supported, avoid executing any calls to the listener APIs.</span></span>

```csharp
if (ApiInformation.IsTypePresent("Windows.UI.Notifications.Management.UserNotificationListener"))
{
    // Listener supported!
}
 
else
{
    // Older version of Windows, no Listener
}
```


## <a name="requesting-access-to-the-listener"></a><span data-ttu-id="6fbf2-117">リスナーへのアクセスを要求する</span><span class="sxs-lookup"><span data-stu-id="6fbf2-117">Requesting access to the listener</span></span>

<span data-ttu-id="6fbf2-118">リスナーではユーザーの通知へのアクセスが許可されるため、ユーザーは、通知へのアクセス許可をアプリに付与する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-118">Since the listener allows access to the user's notifications, users must give your app permission to access their notifications.</span></span> <span data-ttu-id="6fbf2-119">アプリの最初の実行エクスペリエンスの際に、通知リスナーを使用するためのアクセスを要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-119">During your app's first-run experience, you should request access to use the notification listener.</span></span> <span data-ttu-id="6fbf2-120">必要な場合は、[RequestAccessAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.RequestAccessAsync) を呼び出す前に、アプリがユーザーの通知にアクセスする必要がある理由を説明する UI を事前に表示することができます。これにより、ユーザーはアクセスが許可される理由を理解することができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-120">If you want, you can show some preliminary UI that explains why your app needs access to the user's notifications before you call [RequestAccessAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.RequestAccessAsync), so that the user understands why they should allow access.</span></span>

```csharp
// Get the listener
UserNotificationListener listener = UserNotificationListener.Current;
 
// And request access to the user's notifications (must be called from UI thread)
UserNotificationListenerAccessStatus accessStatus = await listener.RequestAccessAsync();
 
switch (accessStatus)
{
    // This means the user has granted access.
    case UserNotificationListenerAccessStatus.Allowed:
 
        // Yay! Proceed as normal
        break;
 
    // This means the user has denied access.
    // Any further calls to RequestAccessAsync will instantly
    // return Denied. The user must go to the Windows settings
    // and manually allow access.
    case UserNotificationListenerAccessStatus.Denied:
 
        // Show UI explaining that listener features will not
        // work until user allows access.
        break;
 
    // This means the user closed the prompt without
    // selecting either allow or deny. Further calls to
    // RequestAccessAsync will show the dialog again.
    case UserNotificationListenerAccessStatus.Unspecified:
 
        // Show UI that allows the user to bring up the prompt again
        break;
}
```

<span data-ttu-id="6fbf2-121">ユーザーは Windows 設定アプリを使用して、アクセスをいつでも取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-121">The user can revoke access at any time via Windows Settings.</span></span> <span data-ttu-id="6fbf2-122">そのため、アプリでは常に、通知リスナーを使用するコードを実行する前に、[GetAccessStatus](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetAccessStatus) メソッドを使用してアクセス状態を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-122">Therefore, your app should always check the access status via the [GetAccessStatus](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetAccessStatus) method before executing code that uses the notfication listener.</span></span> <span data-ttu-id="6fbf2-123">ユーザーがアクセスを取り消すと、API は例外をスローせず、警告なしに失敗します (たとえば、すべての通知を取得する API は空のリストを返すだけです)。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-123">If the user revokes access, the APIs will silently fail rather than throwing an exception (for example, the API to get all notifications will simply return an empty list).</span></span>


## <a name="access-the-users-notifications"></a><span data-ttu-id="6fbf2-124">ユーザーの通知にアクセスする</span><span class="sxs-lookup"><span data-stu-id="6fbf2-124">Access the user's notifications</span></span>

<span data-ttu-id="6fbf2-125">通知リスナーを使用すると、ユーザーの現在の通知に関する一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-125">With the notification listener, you can get a list of the user's current notifications.</span></span> <span data-ttu-id="6fbf2-126">[GetNotificationsAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetNotificationsAsync) メソッドを呼び出し、取得する必要がある通知の種類を指定するだけです (現時点では、サポートされている通知の種類はトースト通知のみです)。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-126">Simply call the [GetNotificationsAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetNotificationsAsync) method, and specify the type of notifications you want to get (currently, the only type of notifications supported are toast notifications).</span></span>

```csharp
// Get the toast notifications
IReadOnlyList<UserNotification> notifs = await listener.GetNotificationsAsync(NotificationKinds.Toast);
```


## <a name="displaying-the-notifications"></a><span data-ttu-id="6fbf2-127">通知の表示</span><span class="sxs-lookup"><span data-stu-id="6fbf2-127">Displaying the notifications</span></span>

<span data-ttu-id="6fbf2-128">各通知は [UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification) として表されます。このクラスは、通知の送信元となるアプリに関する情報、通知が作成された時間、通知の ID、および通知自体を提供します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-128">Each notification is represented as a [UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification), which provides information about the app that the notification is from, the time the notification was created, the notification's ID, and the notification itself.</span></span>

```csharp
public sealed class UserNotification
{
    public AppInfo AppInfo { get; }
    public DateTimeOffset CreationTime { get; }
    public uint Id { get; }
    public Notification Notification { get; }
}
```

<span data-ttu-id="6fbf2-129">[AppInfo](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.AppInfo) プロパティは、通知の表示に必要な情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-129">The [AppInfo](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.AppInfo) property provides the info you need to display the notification.</span></span>

> [!NOTE]
> <span data-ttu-id="6fbf2-130">1 つの通知をキャプチャしたときに予期しない例外が発生する場合に備えて、1 つの通知を処理するコードはすべて、try/catch で囲むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-130">We recommend surrounding all your code for processing a single notification in a try/catch, in case an unexpected exception occurs when you are capturing a single notification.</span></span> <span data-ttu-id="6fbf2-131">ある特定の通知で問題が発生した場合でも、他の通知の表示がすべて失敗するのを防ぐ必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-131">You shouldn't completely fail to display other notifications just because of an issue with one specific notification.</span></span>

```csharp
// Select the first notification
UserNotification notif = notifs[0];
 
// Get the app's display name
string appDisplayName = notif.AppInfo.DisplayInfo.DisplayName;
 
// Get the app's logo
BitmapImage appLogo = new BitmapImage();
RandomAccessStreamReference appLogoStream = notif.AppInfo.DisplayInfo.GetLogo(new Size(16, 16));
await appLogo.SetSourceAsync(await appLogoStream.OpenReadAsync());
```

<span data-ttu-id="6fbf2-132">通知の本文などの通知自体のコンテンツは、[Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.Notification) プロパティに含まれています。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-132">The content of the notification itself, such as the notification text, is contained in the [Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.Notification) property.</span></span> <span data-ttu-id="6fbf2-133">このプロパティには、通知の視覚的な部分が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-133">This property contains the visual portion of the notification.</span></span> <span data-ttu-id="6fbf2-134">(Windows での通知の送信について詳しく理解している方は、[Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification) オブジェクトの [Visual](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification.Visual) プロパティと [Visual.Bindings](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationvisual.Bindings) プロパティが、通知が表示されるときに開発者が送信するデータに対応するということにお気づきでしょう)。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-134">(If you are familiar with sending notifications on Windows, you will notice that the [Visual](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification.Visual) and [Visual.Bindings](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationvisual.Bindings) properties in the [Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification) object correspond to what developers send when popping a notification.)</span></span>

<span data-ttu-id="6fbf2-135">トーストのバインディングを調べる必要があります (エラー防止コードのために、バインディングが null でないことを確認する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-135">We want to look for the toast binding (for error-proof code, you should check that the binding isn't null).</span></span> <span data-ttu-id="6fbf2-136">バインディングから、テキスト要素を取得できます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-136">From the binding, you can obtain the text elements.</span></span> <span data-ttu-id="6fbf2-137">テキスト要素は、必要な数だけ表示するように選択できます </span><span class="sxs-lookup"><span data-stu-id="6fbf2-137">You can choose to display as many text elements as you would like.</span></span> <span data-ttu-id="6fbf2-138">(テキスト要素はすべて表示することをお勧めします)。それぞれのテキスト要素を異なる方法で処理することができます。たとえば、最初のテキスト要素をタイトル テキストとして扱い、後続の要素を本文テキストとして扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-138">(Ideally, you should display them all.) You can choose to treat the text elements differently; for example, treat the first one as title text, and subsequent elements as body text.</span></span>

```csharp
// Get the toast binding, if present
NotificationBinding toastBinding = notif.Notification.Visual.GetBinding(KnownNotificationBindings.ToastGeneric);
 
if (toastBinding != null)
{
    // And then get the text elements from the toast binding
    IReadOnlyList<AdaptiveNotificationText> textElements = toastBinding.GetTextElements();
 
    // Treat the first text element as the title text
    string titleText = textElements.FirstOrDefault()?.Text;
 
    // We'll treat all subsequent text elements as body text,
    // joining them together via newlines.
    string bodyText = string.Join("\n", textElements.Skip(1).Select(t => t.Text));
}
```


## <a name="remove-a-specific-notification"></a><span data-ttu-id="6fbf2-139">特定の通知を削除する</span><span class="sxs-lookup"><span data-stu-id="6fbf2-139">Remove a specific notification</span></span>

<span data-ttu-id="6fbf2-140">お使いのウェアラブルやサービスで、ユーザーが通知を無視することが許可されている場合、実際の通知を削除し、ユーザーの電話や PC に後で通知が表示されないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-140">If your wearable or service allows the user to dismiss notifications, you can remove the actual notification so the user doesn't see it later on their phone or PC.</span></span> <span data-ttu-id="6fbf2-141">そのためには、削除する通知の通知 ID ([UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification) オブジェクトから取得します) を指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-141">Simply provide the notification ID (obtained from the [UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification) object) of the notification you'd like to remove:</span></span> 

```csharp
// Remove the notification
listener.RemoveNotification(notifId);
```


## <a name="clear-all-notifications"></a><span data-ttu-id="6fbf2-142">すべての通知を消去する</span><span class="sxs-lookup"><span data-stu-id="6fbf2-142">Clear all notifications</span></span>

<span data-ttu-id="6fbf2-143">[UserNotificationListener.ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) メソッドは、すべてのユーザーの通知を消去します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-143">The [UserNotificationListener.ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) method clears all the user's notifications.</span></span> <span data-ttu-id="6fbf2-144">このメソッドは慎重に使用してください。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-144">Use this method with caution.</span></span> <span data-ttu-id="6fbf2-145">お使いのウェアラブルやサービスですべての通知が表示される場合にのみ、すべての通知を消去してください。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-145">You should only clear all notifications if your wearable or service displays ALL notifications.</span></span> <span data-ttu-id="6fbf2-146">ウェアラブルやサービスで表示されるのが特定の通知のみである場合、ユーザーが [通知を消去する] ボタンをクリックしたとき、ユーザーは特定の通知のみが削除されると想定しますが、[ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) メソッドが呼び出されると、実際にはすべての通知 (ウェアラブルやサービスでは表示されていなかった通知を含む) が削除されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-146">If your wearable or service only displays certain notifications, when the user clicks your "Clear notifications" button, the user is only expecting those specific notifications to be removed; however, calling the [ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) method would actually cause all the notifications, including ones that your wearable or service wasn't displaying, to be removed.</span></span>

```csharp
// Clear all notifications. Use with caution.
listener.ClearNotifications();
```


## <a name="background-task-for-notification-addeddismissed"></a><span data-ttu-id="6fbf2-147">追加/無視される通知のバックグラウンド タスク</span><span class="sxs-lookup"><span data-stu-id="6fbf2-147">Background task for notification added/dismissed</span></span>

<span data-ttu-id="6fbf2-148">アプリで通知をリッスンできるようにするための一般的な方法は、バックグラウンド タスクのセットアップです。これにより、アプリが現在実行されているかどうかに関係なく、いつ通知が追加されたかまたは無視されたかを把握することができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-148">A common way to enable an app to listen to notifications is to set up a background task, so that you can know when a notification was added or dismissed regardless of whether your app is currently running.</span></span>

<span data-ttu-id="6fbf2-149">Anniversary Update には[シングル プロセス モデル](../../../launch-resume/create-and-register-an-inproc-background-task.md)が導入されたため、バックグラウンド タスクの追加が非常に簡単になりました。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-149">Thanks to the [single process model](../../../launch-resume/create-and-register-an-inproc-background-task.md) added in the Anniversary Update, adding background tasks is fairly simple.</span></span> <span data-ttu-id="6fbf2-150">メイン アプリのコードで、通知リスナーへのユーザー アクセスを取得し、バックグラウンド タスクを実行するためのアクセスを取得した後で、新しいバックグラウンド タスクを登録し、[トースト通知の種類](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationkinds)を使用して [UserNotificationChangedTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.usernotificationchangedtrigger) を設定するだけです。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-150">In your main app's code, after you have obtained the user's access to Notification Listener and obtained access to run background tasks, simply register a new background task, and set the [UserNotificationChangedTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.usernotificationchangedtrigger) using the [Toast notification kind](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationkinds).</span></span>

```csharp
// TODO: Request/check Listener access via UserNotificationListener.Current.RequestAccessAsync
 
// TODO: Request/check background task access via BackgroundExecutionManager.RequestAccessAsync
 
// If background task isn't registered yet
if (!BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals("UserNotificationChanged")))
{
    // Specify the background task
    var builder = new BackgroundTaskBuilder()
    {
        Name = "UserNotificationChanged"
    };
 
    // Set the trigger for Listener, listening to Toast Notifications
    builder.SetTrigger(new UserNotificationChangedTrigger(NotificationKinds.Toast));
 
    // Register the task
    builder.Register();
}
```

<span data-ttu-id="6fbf2-151">その後で、App.xaml.cs で [OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.OnBackgroundActivated) メソッドをオーバーライドします (まだオーバーライドしていない場合)。タスク名に対して switch ステートメントを使用して、どのバックグラウンド タスク トリガーが起動されたかを特定します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-151">Then, in your App.xaml.cs, override the [OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.OnBackgroundActivated) method if you haven't yet, and use a switch statement on the task name to determine which of your many background task triggers was invoked.</span></span>

```csharp
protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
{
    var deferral = args.TaskInstance.GetDeferral();
 
    switch (args.TaskInstance.Task.Name)
    {
        case "UserNotificationChanged":
            // Call your own method to process the new/removed notifications
            // The next section of documentation discusses this code
            await MyWearableHelpers.SyncNotifications();
            break;
    }
 
    deferral.Complete();
}
```

<span data-ttu-id="6fbf2-152">バックグラウンド タスクは単純な "ショルダー タップ" です。追加または削除された特定の通知に関する情報は提供しません。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-152">The background task is simply a "shoulder tap": it doesn't provide any information about which specific notification was added or removed.</span></span> <span data-ttu-id="6fbf2-153">バックグラウンド タスクがトリガーされたら、プラットフォームでの通知が反映されるように、ウェアラブルの通知を同期する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-153">When your background task is triggered, you should sync the notifications on your wearable so that they reflect the notifications in the platform.</span></span> <span data-ttu-id="6fbf2-154">これにより、バックグラウンド タスクが失敗した場合でも、次回バックグラウンド タスクが実行されたときに、ウェアラブルの通知を復旧することができます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-154">This ensures that if your background task fails, notifications on your wearable can still be recovered the next time your background task executes.</span></span>

`SyncNotifications` <span data-ttu-id="6fbf2-155">は、実装するメソッドです。次のセクションでその方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-155">is a method you implement; the next section shows how.</span></span> 


## <a name="determining-which-notifications-were-added-and-removed"></a><span data-ttu-id="6fbf2-156">追加または削除された通知を特定する</span><span class="sxs-lookup"><span data-stu-id="6fbf2-156">Determining which notifications were added and removed</span></span>

<span data-ttu-id="6fbf2-157">`SyncNotifications` では、(ウェアラブルと通知を同期するときに) 追加または削除された通知を特定するために、現在の通知のコレクションとプラットフォームの通知との差分を計算する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-157">In your `SyncNotifications` method, to determine which notifications have been added or removed (syncing notifications with your wearable), you have to calculate the delta between your current notification collection, and the notifications in the platform.</span></span>

```csharp
// Get all the current notifications from the platform
IReadOnlyList<UserNotification> userNotifications = await listener.GetNotificationsAsync(NotificationKinds.Toast);
 
// Obtain the notifications that our wearable currently has displayed
IList<uint> wearableNotificationIds = GetNotificationsOnWearable();
 
// Copy the currently displayed into a list of notification ID's to be removed
var toBeRemoved = new List<uint>(wearableNotificationIds);
 
// For each notification in the platform
foreach (UserNotification userNotification in userNotifications)
{
    // If we've already displayed this notification
    if (wearableNotificationIds.Contains(userNotification.Id))
    {
        // We want to KEEP it displayed, so take it out of the list
        // of notifications to remove.
        toBeRemoved.Remove(userNotification.Id);
    }
 
    // Othwerise it's a new notification
    else
    {
        // Display it on the Wearable
        SendNotificationToWearable(userNotification);
    }
}
 
// Now our toBeRemoved list only contains notification ID's that no longer exist in the platform.
// So we will remove all those notifications from the wearable.
foreach (uint id in toBeRemoved)
{
    RemoveNotificationFromWearable(id);
}
```


## <a name="foreground-event-for-notification-addeddismissed"></a><span data-ttu-id="6fbf2-158">追加/無視される通知のフォアグラウンド イベント</span><span class="sxs-lookup"><span data-stu-id="6fbf2-158">Foreground event for notification added/dismissed</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="6fbf2-159">既知の問題: フォア グラウンド イベントの最新バージョンの Windows では、CPU ループが発生し、以前、その前に機能しませんでした。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-159">Known issue: The foreground event will cause a CPU loop on recent versions of Windows, and previously did not work before that.</span></span> <span data-ttu-id="6fbf2-160">フォア グラウンド イベントを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-160">Do NOT use the foreground event.</span></span> <span data-ttu-id="6fbf2-161">Windows に予定されている更新プログラムでこれを解決しますされます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-161">In an upcoming update to Windows, we will fix this.</span></span>

<span data-ttu-id="6fbf2-162">フォア グラウンド イベントを使用するのではなく、[シングル プロセス モデル](../../../launch-resume/create-and-register-an-inproc-background-task.md)のバック グラウンド タスクの前に示したコードを使用します。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-162">Instead of using the foreground event, use the code shown earlier for a [single process model](../../../launch-resume/create-and-register-an-inproc-background-task.md) background task.</span></span> <span data-ttu-id="6fbf2-163">バック グラウンド タスクでは、アプリが終了または実行中には、両方の変更イベント通知を受け取るもできます。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-163">The background task will also allow you to receive change event notifications both while your app is closed or running.</span></span>

```csharp
// Subscribe to foreground event (DON'T USE THIS)
listener.NotificationChanged += Listener_NotificationChanged;
 
private void Listener_NotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
{
    // NOTE: This event WILL CAUSE CPU LOOPS, DO NOT USE. Use the background task instead.
}
```


## <a name="how-to-fix-delays-in-the-background-task"></a><span data-ttu-id="6fbf2-164">バックグラウンド タスクの遅延を解決する方法</span><span class="sxs-lookup"><span data-stu-id="6fbf2-164">How to fix delays in the background task</span></span>

<span data-ttu-id="6fbf2-165">アプリをテストするとき、バックグラウンド タスクが遅延し、数分間トリガーされない場合があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-165">When testing your app, you might notice that the background task is sometimes delayed, and doesn't trigger for several minutes.</span></span> <span data-ttu-id="6fbf2-166">この問題を解決するには、ユーザーに対して、[システム設定] -> [システム] -> [バッテリー] -> [アプリによるバッテリーの使用] に移動して、一覧でアプリを探して選択し、[バックグラウンドで常に許可] に変更するように要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-166">To fix this, you'll want to prompt the user to go to the system settings -> System -> Battery -> Battery usage by app, find your app in the list, select it, and change it to be "Always allowed in background".</span></span> <span data-ttu-id="6fbf2-167">この操作を行うと、バックグラウンド タスクは、通知の受信後数秒以内にトリガーされるようになります。</span><span class="sxs-lookup"><span data-stu-id="6fbf2-167">After this, the background task should always be triggered within around a second of the notification being received.</span></span>