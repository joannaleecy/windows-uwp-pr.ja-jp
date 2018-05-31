---
author: anbare
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
ms.openlocfilehash: 00774817574c209826050a084bba77084d404ace
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1674619"
---
# <a name="notification-listener-access-all-notifications"></a>通知リスナー: すべての通知にアクセスする

通知リスナーを使用すると、ユーザーの通知にアクセスすることができます。 スマートウォッチや他のウェアラブルでは、通知リスナーを使用して、電話の通知をウェアラブル デバイスに送信することができます。 ホーム オートメーション アプリでは、通知リスナーを使用して、通知を受信したときに特定のアクション (電話がかかってきたときにランプを点滅するなど) を実行することができます。 

> [!IMPORTANT]
> **Anniversary Update が必要**: 通知リスナーを使用するには、SDK 14393 以降をターゲットとし、ビルド 14393 以降を実行している必要があります。


> **重要な API**: [UserNotificationListener クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.Management.UserNotificationListener)、[UserNotificationChangedTrigger クラス](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.UserNotificationChangedTrigger)


## <a name="enable-the-listener-by-adding-the-user-notification-capability"></a>ユーザー通知機能を追加して、リスナーを有効にする 

通知リスナーを使用するには、ユーザー通知リスナー機能をアプリ マニフェストに追加する必要があります。

1. Visual Studio のソリューション エクスプローラーで、`Package.appxmanifest` ファイルをダブルクリックし、マニフェスト デザイナーを開きます。
2. [機能] タブを開きます。
3. **[ユーザー通知リスナー]** 機能をオンにします。


## <a name="check-whether-the-listener-is-supported"></a>リスナーがサポートされているかどうかを確認する

アプリで Windows 10 の以前のバージョンをサポートする場合は、[ApiInformation クラス](https://docs.microsoft.com/uwp/api/Windows.Foundation.Metadata.ApiInformation) を使用して、リスナーがサポートされているかどうかを確認する必要があります。  リスナーがサポートされていない場合は、リスナー API の呼び出しを実行しないでください。

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


## <a name="requesting-access-to-the-listener"></a>リスナーへのアクセスを要求する

リスナーではユーザーの通知へのアクセスが許可されるため、ユーザーは、通知へのアクセス許可をアプリに付与する必要があります。 アプリの最初の実行エクスペリエンスの際に、通知リスナーを使用するためのアクセスを要求する必要があります。 必要な場合は、[RequestAccessAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.RequestAccessAsync) を呼び出す前に、アプリがユーザーの通知にアクセスする必要がある理由を説明する UI を事前に表示することができます。これにより、ユーザーはアクセスが許可される理由を理解することができます。

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

ユーザーは Windows 設定アプリを使用して、アクセスをいつでも取り消すことができます。 そのため、アプリでは常に、通知リスナーを使用するコードを実行する前に、[GetAccessStatus](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetAccessStatus) メソッドを使用してアクセス状態を確認する必要があります。 ユーザーがアクセスを取り消すと、API は例外をスローせず、警告なしに失敗します (たとえば、すべての通知を取得する API は空のリストを返すだけです)。


## <a name="access-the-users-notifications"></a>ユーザーの通知にアクセスする

通知リスナーを使用すると、ユーザーの現在の通知に関する一覧を取得できます。 [GetNotificationsAsync](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.GetNotificationsAsync) メソッドを呼び出し、取得する必要がある通知の種類を指定するだけです (現時点では、サポートされている通知の種類はトースト通知のみです)。

```csharp
// Get the toast notifications
IReadOnlyList<UserNotification> notifs = await listener.GetNotificationsAsync(NotificationKinds.Toast);
```


## <a name="displaying-the-notifications"></a>通知の表示

各通知は [UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification) として表されます。このクラスは、通知の送信元となるアプリに関する情報、通知が作成された時間、通知の ID、および通知自体を提供します。

```csharp
public sealed class UserNotification
{
    public AppInfo AppInfo { get; }
    public DateTimeOffset CreationTime { get; }
    public uint Id { get; }
    public Notification Notification { get; }
}
```

[AppInfo](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.AppInfo) プロパティは、通知の表示に必要な情報を提供します。

> [!NOTE]
> 1 つの通知をキャプチャしたときに予期しない例外が発生する場合に備えて、1 つの通知を処理するコードはすべて、try/catch で囲むことをお勧めします。 ある特定の通知で問題が発生した場合でも、他の通知の表示がすべて失敗するのを防ぐ必要があります。

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

通知の本文などの通知自体のコンテンツは、[Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification.Notification) プロパティに含まれています。 このプロパティには、通知の視覚的な部分が含まれます。 (Windows での通知の送信について詳しく理解している方は、[Notification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification) オブジェクトの [Visual](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notification.Visual) プロパティと [Visual.Bindings](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationvisual.Bindings) プロパティが、通知が表示されるときに開発者が送信するデータに対応するということにお気づきでしょう)。

トーストのバインディングを調べる必要があります (エラー防止コードのために、バインディングが null でないことを確認する必要があります)。 バインディングから、テキスト要素を取得できます。 テキスト要素は、必要な数だけ表示するように選択できます  (テキスト要素はすべて表示することをお勧めします)。それぞれのテキスト要素を異なる方法で処理することができます。たとえば、最初のテキスト要素をタイトル テキストとして扱い、後続の要素を本文テキストとして扱うことができます。

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


## <a name="remove-a-specific-notification"></a>特定の通知を削除する

お使いのウェアラブルやサービスで、ユーザーが通知を無視することが許可されている場合、実際の通知を削除し、ユーザーの電話や PC に後で通知が表示されないようにすることができます。 そのためには、削除する通知の通知 ID ([UserNotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.usernotification) オブジェクトから取得します) を指定するだけです。 

```csharp
// Remove the notification
listener.RemoveNotification(notifId);
```


## <a name="clear-all-notifications"></a>すべての通知を消去する

[UserNotificationListener.ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) メソッドは、すべてのユーザーの通知を消去します。 このメソッドは慎重に使用してください。 お使いのウェアラブルやサービスですべての通知が表示される場合にのみ、すべての通知を消去してください。 ウェアラブルやサービスで表示されるのが特定の通知のみである場合、ユーザーが [通知を消去する] ボタンをクリックしたとき、ユーザーは特定の通知のみが削除されると想定しますが、[ClearNotifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener.ClearNotifications) メソッドが呼び出されると、実際にはすべての通知 (ウェアラブルやサービスでは表示されていなかった通知を含む) が削除されてしまいます。

```csharp
// Clear all notifications. Use with caution.
listener.ClearNotifications();
```


## <a name="background-task-for-notification-addeddismissed"></a>追加/無視される通知のバックグラウンド タスク

アプリで通知をリッスンできるようにするための一般的な方法は、バックグラウンド タスクのセットアップです。これにより、アプリが現在実行されているかどうかに関係なく、いつ通知が追加されたかまたは無視されたかを把握することができます。

Anniversary Update には[シングル プロセス モデル](../../../launch-resume/create-and-register-an-inproc-background-task.md)が導入されたため、バックグラウンド タスクの追加が非常に簡単になりました。 メイン アプリのコードで、通知リスナーへのユーザー アクセスを取得し、バックグラウンド タスクを実行するためのアクセスを取得した後で、新しいバックグラウンド タスクを登録し、[トースト通知の種類](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationkinds)を使用して [UserNotificationChangedTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.usernotificationchangedtrigger) を設定するだけです。

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

その後で、App.xaml.cs で [OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.OnBackgroundActivated) メソッドをオーバーライドします (まだオーバーライドしていない場合)。タスク名に対して switch ステートメントを使用して、どのバックグラウンド タスク トリガーが起動されたかを特定します。

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

バックグラウンド タスクは単純な "ショルダー タップ" です。追加または削除された特定の通知に関する情報は提供しません。 バックグラウンド タスクがトリガーされたら、プラットフォームでの通知が反映されるように、ウェアラブルの通知を同期する必要があります。 これにより、バックグラウンド タスクが失敗した場合でも、次回バックグラウンド タスクが実行されたときに、ウェアラブルの通知を復旧することができます。

`SyncNotifications` は、実装するメソッドです。次のセクションでその方法を説明します。 


## <a name="determining-which-notifications-were-added-and-removed"></a>追加または削除された通知を特定する

`SyncNotifications` では、(ウェアラブルと通知を同期するときに) 追加または削除された通知を特定するために、現在の通知のコレクションとプラットフォームの通知との差分を計算する必要があります。

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


## <a name="foreground-event-for-notification-addeddismissed"></a>追加/無視される通知のフォアグラウンド イベント

> [!IMPORTANT] 
> 既知の問題: フォアグラウンド イベントは機能しません (弊社ではこの問題を直ちに解決する計画はありません)。 

フォアグラウンド イベントが必要となるシナリオがある場合は、弊社までお知らせください。 ただし、シナリオの (すべてではなく) ほとんどで実際にはバックグラウンド タスクが使用されます。これは、アプリでは多くの場合、通知イベントに対してバックグラウンドでウェイクアップする必要があるためです。 たとえば、ウェアラブル アクセサリ用アプリはフォアグラウンドで実行されることはほとんどありませんが、バックグラウンドで新しい通知を認識する必要はあります。

また、[シングル プロセス モデル](../../../launch-resume/create-and-register-an-inproc-background-task.md)を利用できるため、バックグラウンド タスク トリガーはフォアグラウンド アプリから簡単に使用することができます。 そのため、フォアグラウンド イベントを受け取る必要がある場合は、シングル プロセス モデルでバックグラウンド トリガーを使用するだけで十分です。

```csharp
// Subscribe to foreground event
listener.NotificationChanged += Listener_NotificationChanged;
 
private void Listener_NotificationChanged(UserNotificationListener sender, UserNotificationChangedEventArgs args)
{
    // NOTE: This event DOES NOT WORK. Use the background task instead.
}
```


## <a name="how-to-fix-delays-in-the-background-task"></a>バックグラウンド タスクの遅延を解決する方法

アプリをテストするとき、バックグラウンド タスクが遅延し、数分間トリガーされない場合があります。 この問題を解決するには、ユーザーに対して、[システム設定] -> [システム] -> [バッテリー] -> [アプリによるバッテリーの使用] に移動して、一覧でアプリを探して選択し、[バックグラウンドで常に許可] に変更するように要求する必要があります。 この操作を行うと、バックグラウンド タスクは、通知の受信後数秒以内にトリガーされるようになります。