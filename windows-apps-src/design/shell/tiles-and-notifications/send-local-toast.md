---
author: andrewleader
Description: Learn how to send a local toast notification and handle the user clicking the toast.
title: ローカル トースト通知の送信
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Send a local toast notification
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト通知の送信, 通知, 通知の送信, トースト通知, 方法, クイックスタート, 作業の開始, コード サンプル, チュートリアル
ms.localizationpriority: medium
ms.openlocfilehash: 3004b7041838656890b3a967e858dddc64c29ee5
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4612397"
---
# <a name="send-a-local-toast-notification"></a>ローカル トースト通知の送信


トースト通知は、ユーザーが現在アプリ内にいないときに、アプリが作成してユーザーに配信できるメッセージです。 このクイック スタートでは、新しいアダプティブ テンプレートと対話型の操作を使って Windows 10 のトースト通知を作成、配信、表示する手順について紹介します。 これらの操作をローカル通知を使って説明します。これは、最も簡単に実装できる通知です。

> [!IMPORTANT]
> デスクトップ アプリケーション (デスクトップ ブリッジと従来の Win32) では、通知の送信とアクティブ化の処理の手順が以下とは異なります。 トーストを実装する方法については、「[デスクトップ アプリ](toast-desktop-apps.md)」のドキュメントを参照してください。

ここでは、次の操作について説明します。

### <a name="sending-a-toast"></a>トーストの送信

* 通知の視覚的に訴える部分 (テキストと画像) を作成する
* 通知に操作を追加する
* トーストに有効期限を設定する
* 後でトーストの置き換えや削除を実行できるように、タグやグループを設定する
* ローカル API を使ってトーストを送信する

### <a name="handling-activation"></a>アクティブ化の処理

* 本文またはボタンがクリックされたときにアクティブ化を処理する
* フォアグラウンドのアクティブ化を処理する
* バックグラウンドのアクティブ化を処理する

> **重要な API**: [ToastNotification クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)、[ToastNotificationActivatedEventArgs クラス](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs)


## <a name="prerequisites"></a>前提条件

このトピックを十分に理解するには、次のものが役立ちます。

* トースト通知に関する用語と概念についての実用的知識。 詳しくは、[トーストとアクション センターの概要](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/toast-notification-and-action-center-overview-for-windows-10/)に関するブログをご覧ください。
* Windows 10 のトースト通知のコンテンツに関する知識。 詳しくは、[トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)をご覧ください。
* Windows 10 UWP アプリ プロジェクト

> [!NOTE]
> Windows 8/8.1 とは異なり、アプリがトースト通知を表示できることをアプリのマニフェストで宣言する必要はなくなりました。 すべてのアプリがトースト通知を送信して表示できます。

> [!NOTE]
> **Windows 8/8.1 アプリ**: [アーカイブ ドキュメント](https://msdn.microsoft.com/library/windows/apps/xaml/hh868254.aspx)をご覧ください。


## <a name="install-nuget-packages"></a>NuGet パッケージをインストールする

プロジェクトに次の 2 つの NuGet パッケージをインストールすることをお勧めします。 今回のコード サンプルではそれらのパッケージを使います。 このページの最後に、NuGet パッケージを使わない "古典的な" コード スニペットを示します。

* [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/): 生の XML ではなく、オブジェクトを通じてトーストのペイロードを生成します。
* [QueryString.NET](https://www.nuget.org/packages/QueryString.NET/): C# を使ってクエリ文字列を生成、解析します。


## <a name="add-namespace-declarations"></a>名前空間宣言を追加する

`Windows.UI.Notifications` にはトースト API が含まれます。

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET
```


## <a name="send-a-toast"></a>トーストを送信する

Windows 10 では、トースト通知のコンテンツは、通知の外観にすばらしい柔軟性を持たせることができるアダプティブ言語を使って表されます。 詳しくは、[トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)をご覧ください。

### <a name="constructing-the-visual-part-of-the-content"></a>コンテンツの視覚的に訴える部分を作成する

まずは、コンテンツの視覚的に訴える部分を作成しましょう。これには、ユーザーに表示するテキストと画像が含まれます。

Notifications ライブラリのおかげで、XML コンテンツを簡単に生成できます。 NuGet から Notifications ライブラリをインストールしていない場合は、XML を手動で作成する必要があるので、エラーが残ってしまう可能性があります。

> [!NOTE]
> 画像は、アプリのパッケージ、アプリのローカル ストレージ、または Web から使用できます。 Fall Creators Update の時点で、Web 画像の上限は通常の接続で 3 MB、従量制課金接続で 1 MB です。 まだ Fall Creators Update を実行していないデバイスでは、Web イメージは 200 KB を上限とします。

```csharp
// In a real app, these would be initialized with actual data
string title = "Andrew sent you a picture";
string content = "Check this out, Happy Canyon in Utah!";
string image = "https://picsum.photos/360/202?image=883";
string logo = "ms-appdata:///local/Andrew.jpg";
 
// Construct the visuals of the toast
ToastVisual visual = new ToastVisual()
{
    BindingGeneric = new ToastBindingGeneric()
    {
        Children =
        {
            new AdaptiveText()
            {
                Text = title
            },
 
            new AdaptiveText()
            {
                Text = content
            },
 
            new AdaptiveImage()
            {
                Source = image
            }
        },
 
        AppLogoOverride = new ToastGenericAppLogo()
        {
            Source = logo,
            HintCrop = ToastGenericAppLogoCrop.Circle
        }
    }
};
```


### <a name="constructing-actions-part-of-the-content"></a>コンテンツの操作部分を作成する

次に、コンテンツに操作を追加しましょう。

以下の例には、ユーザーがテキストを入力できる入力要素が含まれています。ユーザーはテキストを入力し、ユーザーがボタンの 1 つまたはトースト自体をクリックしたときに、それがアプリに返されます。

次に、2 つのボタンが追加され、それぞれのボタンには、個別にアクティブ化の種類、コンテンツ、引数が指定されています。
* **ActivationType** は、ユーザーがこの操作を実行したときに、アプリをアクティブ化する方法を指定するために使われています。 フォアグラウンドでアプリを起動するか、バックグラウンド タスクを起動するか、別のアプリをプロトコル起動するかを選択できます。 アプリでフォアグラウンドかバックグラウンドのいずれを選択するかに関係なく、ユーザー入力と指定した引数が常に提供されるため、アプリはメッセージの送信や会話の開始など、正しいアクションを実行できます。

```csharp
// In a real app, these would be initialized with actual data
int conversationId = 384928;
 
// Construct the actions for the toast (inputs and buttons)
ToastActionsCustom actions = new ToastActionsCustom()
{
    Inputs =
    {
        new ToastTextBox("tbReply")
        {
            PlaceholderContent = "Type a response"
        }
    },
 
    Buttons =
    {
        new ToastButton("Reply", new QueryString()
        {
            { "action", "reply" },
            { "conversationId", conversationId.ToString() }
 
        }.ToString())
        {
            ActivationType = ToastActivationType.Background,
            ImageUri = "Assets/Reply.png",
 
            // Reference the text box's ID in order to
            // place this button next to the text box
            TextBoxId = "tbReply"
        },
 
        new ToastButton("Like", new QueryString()
        {
            { "action", "like" },
            { "conversationId", conversationId.ToString() }
 
        }.ToString())
        {
            ActivationType = ToastActivationType.Background
        },
 
        new ToastButton("View", new QueryString()
        {
            { "action", "viewImage" },
            { "imageUrl", image }
 
        }.ToString())
    }
};
```


### <a name="combining-the-above-to-construct-the-full-content"></a>上記を組み合わせてコンテンツを完成させる

これでコンテンツの作成は完了です。作成したコンテンツを使用して [**ToastNotification**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification) オブジェクトをインスタンス化できます。

**注**: ユーザーがトースト通知の本文をタップしたときにどの種類のアクティブ化が必要なのかを指定するために、ルート要素にアクティブ化の種類を提供することもできます。 通常、トーストの本文がタップされたら、一貫性したユーザー エクスペリエンスを作成するためにフォアグラウンドでアプリを起動する必要がありますが、ユーザーに適した特定のシナリオに合うように他のアクティブ化の種類を使うこともできます。

ユーザーがトーストの本文をタップしたときや、アプリが起動したときに、どのコンテンツを表示するかをアプリが判断できるように、**Launch** プロパティは常に設定する必要があります。

```csharp
// Now we can construct the final toast content
ToastContent toastContent = new ToastContent()
{
    Visual = visual,
    Actions = actions,
 
    // Arguments when the user taps body of toast
    Launch = new QueryString()
    {
        { "action", "viewConversation" },
        { "conversationId", conversationId.ToString() }
 
    }.ToString()
};
 
// And create the toast notification
var toast = new ToastNotification(toastContent.GetXml());
```


## <a name="set-an-expiration-time"></a>有効期限を設定する

Windows 10 では、ユーザーが閉じるか無視したすべてのトースト通知はアクション センター に送られるため、ユーザーはポップアップが消えた後も通知を表示できます。

ただし、通知に含まれているメッセージが一定期間だけ関係する場合は、トースト通知に有効期限を設定して、アプリからユーザーに古い情報が表示されないようにする必要があります。 たとえば、12 時間限りのキャンペーンの場合は、有効期限を 12 時間に設定します。 以下のコードでは、有効期限が 2 日間に設定されています。

> [!NOTE]
> ローカル トースト通知の既定の最長有効期限は 3 日間です。

```csharp
toast.ExpirationTime = DateTime.Now.AddDays(2);
```


## <a name="provide-a-primary-key-for-your-toast"></a>トーストの主キーを提供する

送信した通知をプログラムで削除するか差し替える必要がある場合、Tag プロパティ (および必要に応じて Group プロパティ) を使って通知の主キーを提供する必要があります。 そうすると、今後この主キーを使って、通知の削除や差し替えができるようになります。

既に配信されたトースト通知の差し替えと削除の方法について詳しくは、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。

Tag と Group を組み合わせると、復号主キーとして機能します。 Group はより汎用的な ID で、"wallPosts"、"messages"、"friendRequests" などのグループを割り当てることができます。Tag はグループ内から通知自体を一意に識別する必要があります。 汎用グループを使うことで、[RemoveGroup API](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使ってそのグループからすべての通知を削除できます。

```csharp
toast.Tag = "18365";
toast.Group = "wallPosts";
```


## <a name="send-the-notification"></a>通知を送信する

トーストを初期化した後は、[ToastNotifier](https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotifier) を作成し、トースト通知を渡して Show() を呼び出すだけです。

```csharp
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


## <a name="clear-your-notifications"></a>通知を消去する

UWP アプリが独自の通知の削除と消去を行います。 アプリを起動したときに、通知が自動的に消去されることはありません。

Windows では、ユーザーが明示的に通知をクリックした場合のみ、通知を自動的に削除します。

メッセージング アプリの処理の例を以下に示します。

1. ユーザーが会話の中で新しいメッセージに関する複数のトーストを受け取る
2. ユーザーがそれらのトーストのいずれかをタップして会話を開く
3. アプリが会話を開き、その会話のすべてのトーストを消去する (その会話用にアプリが提供するグループで [RemoveGroup](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使う)
4. ユーザーのアクション センターが通知の状態を正しく反映して、その会話の古い通知がアクション センターに残らないように処理する

すべての通知を消去する方法または特定の通知を削除する方法については、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。


## <a name="handling-activation"></a>アクティブ化を処理する

Windows 10 では、ユーザーがトーストをクリックしたときに、次の 2 つの方法でトーストにアプリをアクティブ化させることができます。

* フォアグラウンドのアクティブ化
* バックグラウンドのアクティブ化

> [!NOTE]
> Windows 8.1 のレガシのトースト テンプレートを使っている場合は、**OnActivated** の代わりに、**OnLaunched** が呼び出されます。 次のドキュメントは、Notifications ライブラリ (生の XML を使っている場合は ToastGeneric テンプレート) を使っている Windows 10 の最新の通知のみに該当します。


### <a name="handling-foreground-activation"></a>フォアグラウンドのアクティブ化を処理する

Windows 10 では、ユーザーが最新のトースト (またはトースト上のボタン) をクリックすると、**OnLaunched** ではなく、**OnActivated** が新しいアクティブ化の種類 **ToastNotification** を使って呼び出されます。 したがって、開発者はトーストのアクティブ化を簡単に識別し、それに応じてタスクを実行できます。

次の例では、トースト コンテンツに最初に指定した arguments の文字列を取得できます。 また、ユーザーがテキスト ボックスと選択ボックスで指定した入力も取得できます。

> [!IMPORTANT]
> **OnLaunched** コードと同様に、フレームを初期化してウィンドウをアクティブ化する必要があります。 **OnLaunched は、ユーザーがトーストをクリックしても呼び出されません**。アプリが閉じられてから初めて起動している場合も同様です。 通常は、**OnLaunched** と **OnActivated** を組み合わせて独自の `OnLaunchedOrActivated` メソッドにまとめることをお勧めします。これは、両方で同じ初期化を実行する必要があるためです。

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    // Get the root frame
    Frame rootFrame = Window.Current.Content as Frame;
 
    // TODO: Initialize root frame just like in OnLaunched
 
    // Handle toast activation
    if (e is ToastNotificationActivatedEventArgs)
    {
        var toastActivationArgs = e as ToastNotificationActivatedEventArgs;
                 
        // Parse the query string (using QueryString.NET)
        QueryString args = QueryString.Parse(toastActivationArgs.Argument);
 
        // See what action is being requested 
        switch (args["action"])
        {
            // Open the image
            case "viewImage":
 
                // The URL retrieved from the toast args
                string imageUrl = args["imageUrl"];
 
                // If we're already viewing that image, do nothing
                if (rootFrame.Content is ImagePage && (rootFrame.Content as ImagePage).ImageUrl.Equals(imageUrl))
                    break;
 
                // Otherwise navigate to view it
                rootFrame.Navigate(typeof(ImagePage), imageUrl);
                break;
                             
 
            // Open the conversation
            case "viewConversation":
 
                // The conversation ID retrieved from the toast args
                int conversationId = int.Parse(args["conversationId"]);
 
                // If we're already viewing that conversation, do nothing
                if (rootFrame.Content is ConversationPage && (rootFrame.Content as ConversationPage).ConversationId == conversationId)
                    break;
 
                // Otherwise navigate to view it
                rootFrame.Navigate(typeof(ConversationPage), conversationId);
                break;
        }
 
        // If we're loading the app for the first time, place the main page on
        // the back stack so that user can go back after they've been
        // navigated to the specific page
        if (rootFrame.BackStack.Count == 0)
            rootFrame.BackStack.Add(new PageStackEntry(typeof(MainPage), null, null));
    }
 
    // TODO: Handle other types of activation
 
    // Ensure the current window is active
    Window.Current.Activate();
}
```


## <a name="handling-background-activation"></a>バックグラウンドのアクティブ化を処理する

トースト (またはトースト内のボタンで) でバックグラウンドのアクティブ化を指定すると、フォアグラウンド アプリがアクティブ化されるのではなく、バックグラウンド タスクが実行されます。

バックグラウンド タスクについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](/launch-resume/support-your-app-with-background-tasks.md)」をご覧ください。

ビルド 14393 以降をターゲットとしている場合、インプロセス バックグラウンド タスクを使用できるため、大幅に簡略化できます。 インプロセス バックグラウンド タスクは古いバージョンの Windows では実行できないことに注意してください。 次のコード サンプルでは、インプロセス バックグラウンド タスクが使用されています。

```csharp
const string taskName = "ToastBackgroundTask";

// If background task is already registered, do nothing
if (BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals(taskName)))
    return;

// Otherwise request access
BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();

// Create the background task
BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
{
    Name = taskName
};

// Assign the toast action trigger
builder.SetTrigger(new ToastNotificationActionTrigger());

// And register the task
BackgroundTaskRegistration registration = builder.Register();
```


App.xaml.cs で、フォアグラウンドのアクティブ化と同様、定義済みの arguments とユーザー入力を取得できる OnBackgroundActivated メソッドをオーバーライドします。

```csharp
protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
{
    var deferral = args.TaskInstance.GetDeferral();
 
    switch (args.TaskInstance.Task.Name)
    {
        case "ToastBackgroundTask":
            var details = args.TaskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
            if (details != null)
            {
                string arguments = details.Argument;
                var userInput = details.UserInput;

                // Perform tasks
            }
            break;
    }
 
    deferral.Complete();
}
```



## <a name="plain-vanilla-code-snippets"></a>シンプルで "古典的な" のコード スニペット

NuGet から Notifications ライブラリを使っていない場合、次のように手動で XML を構築して [ToastNotification](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification) を作成できます。

```csharp
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// In a real app, these would be initialized with actual data
string title = "Andrew sent you a picture";
string content = "Check this out, Happy Canyon in Utah!";
string image = "http://blogs.msdn.com/cfs-filesystemfile.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-71-81-permanent/2727.happycanyon1_5B00_1_5D00_.jpg";
string logo = "ms-appdata:///local/Andrew.jpg";
 
// TODO: all values need to be XML escaped
 
// Construct the visuals of the toast
string toastVisual =
$@"<visual>
  <binding template='ToastGeneric'>
    <text>{title}</text>
    <text>{content}</text>
    <image src='{image}'/>
    <image src='{logo}' placement='appLogoOverride' hint-crop='circle'/>
  </binding>
</visual>";

// In a real app, these would be initialized with actual data
int conversationId = 384928;
 
// Generate the arguments we'll be passing in the toast
string argsReply = $"action=reply&conversationId={conversationId}";
string argsLike = $"action=like&conversationId={conversationId}";
string argsView = $"action=viewImage&imageUrl={Uri.EscapeDataString(image)}";
 
// TODO: all args need to be XML escaped
 
string toastActions =
$@"<actions>
 
  <input
      type='text'
      id='tbReply'
      placeHolderContent='Type a response'/>
 
  <action
      content='Reply'
      arguments='{argsReply}'
      activationType='background'
      imageUri='Assets/Reply.png'
      hint-inputId='tbReply'/>
 
  <action
      content='Like'
      arguments='{argsLike}'
      activationType='background'/>
 
  <action
      content='View'
      arguments='{argsView}'/>
 
</actions>";

// Now we can construct the final toast content
string argsLaunch = $"action=viewConversation&conversationId={conversationId}";
 
// TODO: all args need to be XML escaped
 
string toastXmlString =
$@"<toast launch='{argsLaunch}'>
    {toastVisual}
    {toastActions}
</toast>";
 
// Parse to XML
XmlDocument toastXml = new XmlDocument();
toastXml.LoadXml(toastXmlString);
 
// Generate toast
var toast = new ToastNotification(toastXml);
```


## <a name="resources"></a>リソース

* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-sending-local-toast)
* [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)
* [ToastNotification クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)
* [ToastNotificationActivatedEventArgs クラス](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs)
