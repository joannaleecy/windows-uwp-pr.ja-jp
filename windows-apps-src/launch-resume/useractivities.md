---
author: TylerMSFT
title: デバイス間でもユーザーのアクティビティを継続する
description: このトピックでは、前回ユーザーがアプリで実行していた状態から再開できるようにする方法 (複数のデバイス間で再開する場合にも対応) について説明します。
keywords: ユーザー アクティビティ、ユーザー アクティビティ、タイムライン、Cortana の前回終了した位置から再開する、Cortana の前回終了した位置から再開する、Project Rome
ms.author: twhitney
ms.date: 04/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 53aac2375d60df3cd9493f315b20431961378fe8
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4356737"
---
# <a name="continue-user-activity-even-across-devices"></a><span data-ttu-id="5a862-104">デバイス間でもユーザーのアクティビティを継続する</span><span class="sxs-lookup"><span data-stu-id="5a862-104">Continue user activity, even across devices</span></span>

<span data-ttu-id="5a862-105">このトピックでは、前回ユーザーがアプリで実行していた状態から再開できるようにする方法 (PC およびデバイス間で再開する場合にも対応) について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a862-105">This topic describes how to help users resume what they were doing in your app on their PC, and across devices.</span></span>

## <a name="user-activities-and-timeline"></a><span data-ttu-id="5a862-106">ユーザー アクティビティとタイムライン</span><span class="sxs-lookup"><span data-stu-id="5a862-106">User Activities and Timeline</span></span>

<span data-ttu-id="5a862-107">私たちの毎日の時間は、複数のデバイス間に広がっています。</span><span class="sxs-lookup"><span data-stu-id="5a862-107">Our time each day is spread across multiple devices.</span></span> <span data-ttu-id="5a862-108">私たちは、バスの中でスマートフォンを、日中は PC を、夜は電話やタブレットを使用しています。</span><span class="sxs-lookup"><span data-stu-id="5a862-108">We might use our phone while on the bus, a PC during the day, then a phone or tablet in the evening.</span></span> <span data-ttu-id="5a862-109">Windows 10 ビルド 1803 以降では、[ユーザー アクティビティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) を作成すると、そのアクティビティが Windows タイムラインと Cortana の 前回終了した位置から再開機能に表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="5a862-109">Starting in Windows 10 Build 1803 or higher, creating a [User Activity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) makes that activity appear in Windows Timeline and in Cortana's Pick up where I left off feature.</span></span> <span data-ttu-id="5a862-110">タイムラインは、ユーザー アクティビティを活用して作業していることを時系列に表示する豊富な機能を備えたタスク ビューです。</span><span class="sxs-lookup"><span data-stu-id="5a862-110">Timeline is a rich task view that takes advantage of User Activities to show a chronological view of what you’ve been working on.</span></span> <span data-ttu-id="5a862-111">また、さまざまなデバイス間で作業していた内容も含めることができます。</span><span class="sxs-lookup"><span data-stu-id="5a862-111">It can also include what you were working on across devices.</span></span>

![Windows タイムラインのイメージ](images/timeline.png)

<span data-ttu-id="5a862-113">同様に、お使いの電話を Windows PC に接続すると、以前に iOS やAndroid デバイスで行っていた作業を続けることができます。</span><span class="sxs-lookup"><span data-stu-id="5a862-113">Likewise, linking your phone to your Windows PC allows you to continue what you were doing previously on your iOS or Android device.</span></span>

<span data-ttu-id="5a862-114">**UserActivity** は、ユーザーがあなたのアプリ内で作業していたことと考えてください。</span><span class="sxs-lookup"><span data-stu-id="5a862-114">Think of a **UserActivity** as something specific the user was working on within your app.</span></span> <span data-ttu-id="5a862-115">たとえば、RSSリーダーを使用している場合、**UserActivity** はあなたが読んでいるフィードになります。</span><span class="sxs-lookup"><span data-stu-id="5a862-115">For example, if you are using a RSS reader, a **UserActivity** could be the feed that you are reading.</span></span> <span data-ttu-id="5a862-116">ゲームをプレイしている場合、**UserActivity** はあなたがプレイしているレベルになります。</span><span class="sxs-lookup"><span data-stu-id="5a862-116">If you are playing a game, the **UserActivity** could be the level that you are playing.</span></span> <span data-ttu-id="5a862-117">音楽アプリを聴いている場合は、**UserActivity** があなたが聴いているプレイリストになります。</span><span class="sxs-lookup"><span data-stu-id="5a862-117">If you are listening to a music app, the **UserActivity** could be the playlist that you are listening to.</span></span> <span data-ttu-id="5a862-118">ドキュメントで作業している場合、**UserActivity** は作業を中断した場所になるなどです。</span><span class="sxs-lookup"><span data-stu-id="5a862-118">If you are working on a document, the **UserActivity** could be where you left off working on it, and so on.</span></span>  <span data-ttu-id="5a862-119">要するに、**UserActivity** は、ユーザーが自分のやっていることを再開できるように、アプリ内の目的地を表すものです。</span><span class="sxs-lookup"><span data-stu-id="5a862-119">In short, a **UserActivity** represents a destination within your app so that enables the user to resume what they were doing.</span></span>

<span data-ttu-id="5a862-120">[UserActivity.CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession) を呼び出して **UserActivity** を使用すると、システムは **UserActivity**の開始時刻と終了時刻を示す履歴レコードを作成します。</span><span class="sxs-lookup"><span data-stu-id="5a862-120">When you engage with a **UserActivity** by calling [UserActivity.CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession), the system creates a history record indicating the start and end time for that **UserActivity**.</span></span> <span data-ttu-id="5a862-121">時間の経過とともに **UserActivity** を再使用していくと、複数の履歴レコードが記録されます。</span><span class="sxs-lookup"><span data-stu-id="5a862-121">As you re-engage with that **UserActivity** over time, multiple history records are recorded for it.</span></span>

## <a name="add-user-activities-to-your-app"></a><span data-ttu-id="5a862-122">アプリにユーザー アクティビティを追加する</span><span class="sxs-lookup"><span data-stu-id="5a862-122">Add User Activities to your app</span></span>

<span data-ttu-id="5a862-123">[UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) は、Windows でのユーザー エンゲージメントの単位です。</span><span class="sxs-lookup"><span data-stu-id="5a862-123">A [UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) is the unit of user engagement in Windows.</span></span> <span data-ttu-id="5a862-124">これには、アクティビティが属するアプリをアクティブ化するために使用される URI、ビジュアル、およびアクティビティを記述するメタデータの 3 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="5a862-124">It has three parts: a URI used to activate the app the activity belongs to, visuals, and metadata that describes the activity.</span></span>

1. <span data-ttu-id="5a862-125">[ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri#Windows_ApplicationModel_UserActivities_UserActivity_ActivationUri) は、特定のコンテキストでアプリケーションを再開するために使用します。</span><span class="sxs-lookup"><span data-stu-id="5a862-125">The [ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri#Windows_ApplicationModel_UserActivities_UserActivity_ActivationUri) is used to resume the application with a specific context.</span></span> <span data-ttu-id="5a862-126">通常、このリンクは、スキームのプロトコル ハンドラー (例: “my-app://page2?action=edit”) または AppUriHandler (例: http://constoso.com/page2?action=edit) のフォームをとります。</span><span class="sxs-lookup"><span data-stu-id="5a862-126">Typically, this link takes the form of protocol handler for a scheme (e.g. “my-app://page2?action=edit”) or of an AppUriHandler (e.g. http://constoso.com/page2?action=edit).</span></span>
2. <span data-ttu-id="5a862-127">[VisualElements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.visualelements) は、タイトル、説明、またはアダプティブ カード要素でアクティビティを視覚的に識別できるようにするクラスを公開します。</span><span class="sxs-lookup"><span data-stu-id="5a862-127">[VisualElements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.visualelements) exposes a class that allows the user to visually identify an activity with a title, description, or Adaptive Card elements.</span></span>
3. <span data-ttu-id="5a862-128">最後に、[コンテンツ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.content#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_Content) は、特定のコンテキストでアクティビティをグループ化したり取得したりするために使用できるアクティビティのメタデータを格納できます。</span><span class="sxs-lookup"><span data-stu-id="5a862-128">Finally, [Content](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.content#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_Content) is where you can store metadata for the activity that can be used to group and retrieve activities under a specific context.</span></span> <span data-ttu-id="5a862-129">多くの場合、これは [http://schema.org](http://schema.org) データのフォームとなります。</span><span class="sxs-lookup"><span data-stu-id="5a862-129">Often, this takes the form of [http://schema.org](http://schema.org) data.</span></span>

<span data-ttu-id="5a862-130">**UserActivity** をアプリに追加するには:</span><span class="sxs-lookup"><span data-stu-id="5a862-130">To add a **UserActivity** to your app:</span></span>

1. <span data-ttu-id="5a862-131">アプリケーション内でユーザーのコンテキスト (ページ ナビゲーション、新しいゲームレベルなど) が変更されたときに **UserActivity** オブジェクトを生成する</span><span class="sxs-lookup"><span data-stu-id="5a862-131">Generate **UserActivity** objects when your user’s context changes within the app (such as page navigation, new game level, etc.)</span></span>
2. <span data-ttu-id="5a862-132">**UserActivity** オブジェクトに必要なフィールドの最小セットを入力します。 [ActivityId](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activityid#Windows_ApplicationModel_UserActivities_UserActivity_ActivityId)、[ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri)、および [UserActivity.VisualElements.DisplayText](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.displaytext#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_DisplayText)。</span><span class="sxs-lookup"><span data-stu-id="5a862-132">Populate **UserActivity** objects with the minimum set of required fields: [ActivityId](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activityid#Windows_ApplicationModel_UserActivities_UserActivity_ActivityId), [ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri), and [UserActivity.VisualElements.DisplayText](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.displaytext#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_DisplayText).</span></span>
3. <span data-ttu-id="5a862-133">**UserActivity** によって再アクティブ化できるように、カスタム スキーム ハンドラーをアプリケーションに追加します。</span><span class="sxs-lookup"><span data-stu-id="5a862-133">Add a custom scheme handler to your app so it can be re-activated by a **UserActivity**.</span></span>

<span data-ttu-id="5a862-134">**UserActivity** はわずか数行のコードでアプリに統合できます。</span><span class="sxs-lookup"><span data-stu-id="5a862-134">A **UserActivity** can be integrated into an app with just a few lines of code.</span></span> <span data-ttu-id="5a862-135">たとえば、MainPage.xaml.cs の MainPage クラス内でこのコードを想像してみてください (注: `using Windows.ApplicationModel.UserActivities;` を前提としています)。</span><span class="sxs-lookup"><span data-stu-id="5a862-135">For example, imagine this code in MainPage.xaml.cs, inside the MainPage class (note: assumes `using Windows.ApplicationModel.UserActivities;`):</span></span>

```csharp
UserActivitySession _currentActivity;
private async Task GenerateActivityAsync()
{
    // Get the default UserActivityChannel and query it for our UserActivity. If the activity doesn't exist, one is created.
    UserActivityChannel channel = UserActivityChannel.GetDefault();
    UserActivity userActivity = await channel.GetOrCreateUserActivityAsync("MainPage");
 
    // Populate required properties
    userActivity.VisualElements.DisplayText = "Hello Activities";
    userActivity.ActivationUri = new Uri("my-app://page2?action=edit");
     
    //Save
    await userActivity.SaveAsync(); //save the new metadata
 
    // Dispose of any current UserActivitySession, and create a new one.
    _currentActivity?.Dispose();
    _currentActivity = userActivity.CreateSession();
}
```

<span data-ttu-id="5a862-136">上の `GenerateActivityAsync()` メソッドの最初の行は、ユーザの [UserActivityChannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel) を取得します。</span><span class="sxs-lookup"><span data-stu-id="5a862-136">The first line in the `GenerateActivityAsync()` method above gets a user’s [UserActivityChannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel).</span></span> <span data-ttu-id="5a862-137">これは、このアプリのアクティビティが公開されるフィードです。</span><span class="sxs-lookup"><span data-stu-id="5a862-137">This is the feed that this app’s activities will be published to.</span></span> <span data-ttu-id="5a862-138">次の行は、`MainPage` と呼ばれるアクティビティのチャネルを照会します。</span><span class="sxs-lookup"><span data-stu-id="5a862-138">The next line queries the channel of an activity called `MainPage`.</span></span>

* <span data-ttu-id="5a862-139">ユーザーがアプリの特定の場所にいるたびに同じ ID が生成されるように、アクティビティに名前を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a862-139">Your app should name activities in such a way that same ID is generated each time the user is in a particular location in the app.</span></span> <span data-ttu-id="5a862-140">たとえば、アプリがページ ベースの場合は、ページの識別子を使用します。ドキュメント ベースの場合は、ドキュメントの名前 (または名前のハッシュ) を使用します。</span><span class="sxs-lookup"><span data-stu-id="5a862-140">For example, if your app is page-based, use an identifier for the page; if its document based, use the name of the doc (or a hash of the name).</span></span>
* <span data-ttu-id="5a862-141">同じ ID を持つフィードに既存のアクティビティがある場合、そのアクティビティは `UserActivity.State` が [公開済み](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitystate) に設定されているチャンネルから返されます</span><span class="sxs-lookup"><span data-stu-id="5a862-141">If there is an existing activity in the feed with the same ID, that activity will be returned from the channel with `UserActivity.State` set to [Published](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitystate)).</span></span> <span data-ttu-id="5a862-142">その名前のアクティビティがない場合、`UserActivity.State` が **New** に設定された状態で新しいアクティビティが返されます。</span><span class="sxs-lookup"><span data-stu-id="5a862-142">If there is no activity with that name, and new activity is returned with `UserActivity.State` set to **New**.</span></span>
* <span data-ttu-id="5a862-143">アクティビティがアプリに適用されます。</span><span class="sxs-lookup"><span data-stu-id="5a862-143">Activities are scoped to your app.</span></span> <span data-ttu-id="5a862-144">アクティビティ ID が他のアプリの ID と競合するのを心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5a862-144">You do not need to worry about your activity ID colliding with IDs in other apps.</span></span>

<span data-ttu-id="5a862-145">**UserActivity** を取得または作成した後で、他の 2 つの必須フィールド、 `UserActivity.VisualElements.DisplayText` と `UserActivity.ActivationUri` を指定します。</span><span class="sxs-lookup"><span data-stu-id="5a862-145">After getting or creating the **UserActivity**, specify the other two required fields:  `UserActivity.VisualElements.DisplayText`and `UserActivity.ActivationUri`.</span></span>

<span data-ttu-id="5a862-146">次に、[SaveAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.saveasync) を呼び出して **UserActivity** を保存し、最後に [CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession) を保存します。これは [UserActivitySession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysession) を返します。</span><span class="sxs-lookup"><span data-stu-id="5a862-146">Next, save the **UserActivity** metadata by calling [SaveAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.saveasync), and finally [CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession), which returns a [UserActivitySession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysession).</span></span> <span data-ttu-id="5a862-147">**UserActivitySession** は、ユーザーが実際に **UserActivity** を使用しているときに、管理するために使用できるオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5a862-147">The **UserActivitySession** is the object that we can use to manage when the user is actually engaged with the **UserActivity**.</span></span> <span data-ttu-id="5a862-148">たとえば、**UserActivitySession** 上でユーザーがページを離れるときに `Dispose()` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a862-148">For example, we should call `Dispose()` on the **UserActivitySession** when the user leaves the page.</span></span> <span data-ttu-id="5a862-149">上記の例では、`CreateSession()` を呼び出す前に `_currentActivity` で` `Dispose()\` を呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="5a862-149">In the example above, we also call `Dispose()` on `_currentActivity` before calling `CreateSession()`.</span></span> <span data-ttu-id="5a862-150">これは、`_currentActivity` をページのメンバー フィールドにして、新しいものを開始する前に既存のアクティビティを停止したいからです (注:`?` は [null 条件演算子](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators) で、メンバー アクセスを実行する前に null をテストします)。</span><span class="sxs-lookup"><span data-stu-id="5a862-150">This is because we made `_currentActivity` a member field of our page, and we want to stop any existing activity before we start the new one (note: the `?` is the [null-conditional operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators) which tests for null before performing the member access).</span></span>

<span data-ttu-id="5a862-151">この場合、`ActivationUri` はカスタム スキームであるため、アプリケーション マニフェストにプロトコルを登録する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="5a862-151">Since, in this case, the `ActivationUri` is a custom scheme, we also need to register the protocol in the application manifest.</span></span> <span data-ttu-id="5a862-152">これは、Package.appmanifest XML ファイルで、またはデザイナーを使用して行います。</span><span class="sxs-lookup"><span data-stu-id="5a862-152">This is done in the Package.appmanifest XML file, or by using the designer.</span></span>

<span data-ttu-id="5a862-153">デザイナーで変更を加えるには、プロジェクトの Package.appmanifest ファイルをダブルクリックしてデザイナーを起動し、**[宣言]** タブを選択して、**[プロトコル]** 定義を追加します。</span><span class="sxs-lookup"><span data-stu-id="5a862-153">To make the change with the designer, double-click the Package.appmanifest file in your project to launch the designer, select the **Declarations** tab and add a **Protocol** definition.</span></span> <span data-ttu-id="5a862-154">記入する必要がある唯一のプロパティは、現在、**名前**です。</span><span class="sxs-lookup"><span data-stu-id="5a862-154">The only property that needs to be filled out, for now, is **Name**.</span></span> <span data-ttu-id="5a862-155">上記で指定した URI の `my-app` と一致するはずです。</span><span class="sxs-lookup"><span data-stu-id="5a862-155">It should match the URI we specified above, `my-app`.</span></span>

<span data-ttu-id="5a862-156">ここで、プロトコルによって起動されたときに何をすべきかをアプリに伝えるコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a862-156">Now we need to write some code to tell the app what to do when it’s been activated by a protocol.</span></span> <span data-ttu-id="5a862-157">App.xaml.cs の `OnActivated` メソッドを上書きして、メイン ページに URI を渡します。</span><span class="sxs-lookup"><span data-stu-id="5a862-157">We’ll override the `OnActivated` method in App.xaml.cs to pass the URI on to the main page, like so:</span></span>

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    if (e.Kind == ActivationKind.Protocol)
    {
        var uriArgs = e as ProtocolActivatedEventArgs;
        if (uriArgs != null)
        {
            if (uriArgs.Uri.Host == "page2")
            {
                // Navigate to the 2nd page of the  app
            }
        }
    }
    Window.Current.Activate();
}
```

<span data-ttu-id="5a862-158">このコードは、アプリがプロトコル経由でアクティブ化されたかどうかを検出します。</span><span class="sxs-lookup"><span data-stu-id="5a862-158">What this code does is detect whether the app was activated via a protocol.</span></span> <span data-ttu-id="5a862-159">アクティブ化されていた場合は、アプリがアクティブ化されているタスクを再開するためにアプリが何をすべきかを確認します。</span><span class="sxs-lookup"><span data-stu-id="5a862-159">If it was, then it looks to see what the app should do to resume the task it is being activated for.</span></span> <span data-ttu-id="5a862-160">シンプルなアプリであるため、このアプリが再開する唯一のアクティビティは、アプリが起動したときにセカンダリページにユーザーを入れることです。</span><span class="sxs-lookup"><span data-stu-id="5a862-160">Being a simple app, the only activity this app resumes is putting you on on the secondary page when the app comes up.</span></span>

## <a name="use-adaptive-cards-to-improve-the-timeline-experience"></a><span data-ttu-id="5a862-161">アダプティブ カードを使用して、タイムラインのエクスペリエンスを向上させる</span><span class="sxs-lookup"><span data-stu-id="5a862-161">Use Adaptive Cards to improve the Timeline experience</span></span>

<span data-ttu-id="5a862-162">ユーザーのアクティビティは、Cortana とタイムラインに表示されます。</span><span class="sxs-lookup"><span data-stu-id="5a862-162">User Activities appear in Cortana and Timeline.</span></span> <span data-ttu-id="5a862-163">アクティビティがタイムラインに表示されたら、[アダプティブ カード](http://adaptivecards.io/)フレームワークを使用してアクティビティを表示します。</span><span class="sxs-lookup"><span data-stu-id="5a862-163">When activities appear in Timeline, we display them using the [Adaptive Card](http://adaptivecards.io/) framework.</span></span> <span data-ttu-id="5a862-164">アクティビティごとにアダプティブ カードを用意していない場合、タイムラインはアプリケーション名とアイコン、タイトル フィールド、およびオプションの説明フィールドに基づいて、簡単なアクティビティ カードを自動的に作成します。</span><span class="sxs-lookup"><span data-stu-id="5a862-164">If you do not provide an adaptive card for each activity, Timeline will automatically create a simple activity card based on your application name and icon, the title field and optional description field.</span></span> <span data-ttu-id="5a862-165">以下は、アダプティブ カードのペイロードとそれが生成するカードの例です。</span><span class="sxs-lookup"><span data-stu-id="5a862-165">Below is an example Adaptive Card payload and the card it produces.</span></span>

![アダプティブ カード](images/adaptivecard.png)<span data-ttu-id="5a862-167">]</span><span class="sxs-lookup"><span data-stu-id="5a862-167">]</span></span>

<span data-ttu-id="5a862-168">アダプティブ カードのペイロード JSON 文字列の例:</span><span class="sxs-lookup"><span data-stu-id="5a862-168">Example adaptive card payload JSON string:</span></span>

```json
{ 
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json", 
  "type": "AdaptiveCard", 
  "version": "1.0",
  "backgroundImage": "https://winblogs.azureedge.net/win/2017/11/eb5d872c743f8f54b957ff3f5ef3066b.jpg", 
  "body": [ 
    { 
      "type": "Container", 
      "items": [ 
        { 
          "type": "TextBlock", 
          "text": "Windows Blog", 
          "weight": "bolder", 
          "size": "large", 
          "wrap": true, 
          "maxLines": 3 
        }, 
        { 
          "type": "TextBlock", 
          "text": "Training Haiti’s radiologists: St. Louis doctor takes her teaching global", 
          "size": "default", 
          "wrap": true, 
          "maxLines": 3 
        } 
      ] 
    } 
  ]
}
```

<span data-ttu-id="5a862-169">以下のように、**UserActivity** に JSON 文字列としてアダプティブ カードのペイロードを追加します。</span><span class="sxs-lookup"><span data-stu-id="5a862-169">Add the Adaptive Cards payload as a JSON string to the **UserActivity** like this:</span></span>

```csharp
activity.VisualElements.Content = 
Windows.UI.Shell.AdaptiveCardBuilder.CreateAdaptiveCardFromJson(jsonCardText); // where jsonCardText is a JSON string that represents the card
```

## <a name="cross-platform-and-service-to-service-integration"></a><span data-ttu-id="5a862-170">クロス プラットフォームとサービス間の統合</span><span class="sxs-lookup"><span data-stu-id="5a862-170">Cross-platform and Service-to-service integration</span></span>

<span data-ttu-id="5a862-171">アプリがクロスプラットフォーム (Android や iOS など) で稼働している場合や、クラウドにユーザーの状態を保持している場合は、[Microsoft Graph](https://developer.microsoft.com/graph/) で UserActivities を公開できます。</span><span class="sxs-lookup"><span data-stu-id="5a862-171">If your app runs cross-platform (for example on Android and iOS), or maintains user state in the cloud, you can publish UserActivities via [Microsoft Graph](https://developer.microsoft.com/graph/).</span></span>
<span data-ttu-id="5a862-172">アプリケーションまたはサービスが Microsoft アカウントで認証されると、上記と同じデータを使用して [アクティビティ](https://developer.microsoft.com/graph/docs/api-reference/beta/api/projectrome_put_activity) オブジェクトと [履歴](https://developer.microsoft.com/graph/docs/api-reference/beta/resources/projectrome_historyitem) オブジェクトを生成するための 2 回の単純な REST 呼び出しが必要です。</span><span class="sxs-lookup"><span data-stu-id="5a862-172">Once your application or service is authenticated with a Microsoft Account, it just takes two simple REST calls to generate [Activity](https://developer.microsoft.com/graph/docs/api-reference/beta/api/projectrome_put_activity) and [History](https://developer.microsoft.com/graph/docs/api-reference/beta/resources/projectrome_historyitem) objects, using the same data as described above.</span></span>

## <a name="summary"></a><span data-ttu-id="5a862-173">まとめ</span><span class="sxs-lookup"><span data-stu-id="5a862-173">Summary</span></span>

<span data-ttu-id="5a862-174">[UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) API を使用して、アプリをタイムラインと Cortana に表示させることができます。</span><span class="sxs-lookup"><span data-stu-id="5a862-174">You can use the [UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) API to make your app appear in Timeline and Cortana.</span></span>
* <span data-ttu-id="5a862-175">詳しくは、[Windows デベロッパー センター](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) で **UserActivity** API についてご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a862-175">Learn more about the **UserActivity** API on the [Windows Dev Center](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)</span></span>
* <span data-ttu-id="5a862-176">「[sample code](https://github.com/Microsoft/project-rome)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a862-176">Check out the [sample code](https://github.com/Microsoft/project-rome).</span></span>
* <span data-ttu-id="5a862-177">「[more sophisticated Adaptive Cards](http://adaptivecards.io/)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5a862-177">See [more sophisticated Adaptive Cards](http://adaptivecards.io/).</span></span>
* <span data-ttu-id="5a862-178">[Microsoft Graph](https://developer.microsoft.com/graph/) を介して、iOS、Android、または Web サービスから **UserActivity** を公開します。</span><span class="sxs-lookup"><span data-stu-id="5a862-178">Publish a **UserActivity** from iOS, Android or your web service via [Microsoft Graph](https://developer.microsoft.com/graph/).</span></span>
* <span data-ttu-id="5a862-179">[Project Rome on GitHub](https://github.com/Microsoft/project-rome) について詳しく知る</span><span class="sxs-lookup"><span data-stu-id="5a862-179">Learn more about [Project Rome on GitHub](https://github.com/Microsoft/project-rome).</span></span>

## <a name="key-apis"></a><span data-ttu-id="5a862-180">キー API</span><span class="sxs-lookup"><span data-stu-id="5a862-180">Key APIs</span></span>

* [<span data-ttu-id="5a862-181">UserActivities 名前空間</span><span class="sxs-lookup"><span data-stu-id="5a862-181">UserActivities namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

## <a name="related-topics"></a><span data-ttu-id="5a862-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5a862-182">Related topics</span></span>

* [<span data-ttu-id="5a862-183">ユーザー アクティビティ ("rome"プロジェクト ドキュメント)</span><span class="sxs-lookup"><span data-stu-id="5a862-183">User Activities (Project Rome docs)</span></span>](https://docs.microsoft.com/windows/project-rome/user-activities/)
* [<span data-ttu-id="5a862-184">アダプティブ カード</span><span class="sxs-lookup"><span data-stu-id="5a862-184">Adaptive cards</span></span>](https://docs.microsoft.com/adaptive-cards/)
* [<span data-ttu-id="5a862-185">アダプティブ カード ビジュアライザー、サンプル</span><span class="sxs-lookup"><span data-stu-id="5a862-185">Adaptive cards visualizer, samples</span></span>](http://adaptivecards.io/)
* [<span data-ttu-id="5a862-186">URI のアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="5a862-186">Handle URI activation</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)
* [<span data-ttu-id="5a862-187">Microsoft Graph、アクティビティ フィード、およびアダプティブ カードを使用して、どのプラットフォームでも顧客の関心を惹きつける</span><span class="sxs-lookup"><span data-stu-id="5a862-187">Engaging with your customers on any platform using the Microsoft Graph, Activity Feed, and Adaptive Cards</span></span>](https://channel9.msdn.com/Events/Connect/2017/B111)
* [<span data-ttu-id="5a862-188">Microsoft Graph</span><span class="sxs-lookup"><span data-stu-id="5a862-188">Microsoft Graph</span></span>](https://developer.microsoft.com/graph/)