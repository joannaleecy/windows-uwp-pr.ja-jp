---
author: manoskow
Description: Learn how to group notifications in Action Center using collections.
title: トースト コレクション
label: Toast Collections
template: detail.hbs
ms.author: mijacobs
ms.date: 05/16/2018
ms.topic: article
keywords: windows 10, uwp, 通知, コレクション, コレクション, グループの通知, 通知のグループ化, グループ、整理, アクション センター, トースト
ms.localizationpriority: medium
ms.openlocfilehash: be7c4ec2e9a47eeeb00663ae94f89e44c6751352
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6661953"
---
# <a name="grouping-toast-notifications-with-collections"></a><span data-ttu-id="3efc8-103">コレクションを使用したトースト通知のグループ化</span><span class="sxs-lookup"><span data-stu-id="3efc8-103">Grouping toast notifications with collections</span></span>
<span data-ttu-id="3efc8-104">コレクションを使用してアクション センターでアプリのトーストを整理します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-104">Use collections to organize your app's toasts in Action Center.</span></span> <span data-ttu-id="3efc8-105">コレクションにより、ユーザーはアクション センター内での情報をより簡単に見つけることができ、開発者が通知をより適切に管理できるようになります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-105">Collections help users locate information within Action Center more easily and allow for developers to better manage their notifications.</span></span>  <span data-ttu-id="3efc8-106">下の API では、通知のコレクションの削除、作成、および更新が可能です。</span><span class="sxs-lookup"><span data-stu-id="3efc8-106">The APIs below allow for removing, creating, and updating notification collections.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3efc8-107">**Creators Update が必要**: トースト コレクションを使用するには、SDK 15063 をターゲットとし、ビルド 15063 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-107">**Requires Creators Update**: You must target SDK 15063 and be running build 15063 or higher to use toast collections.</span></span> <span data-ttu-id="3efc8-108">関連する API には、[Windows.UI.Notifications.ToastCollection](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollection) および [Windows.UI.Notifications.ToastCollectionManager](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollectionmanager) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-108">Related APIs include [Windows.UI.Notifications.ToastCollection](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollection), and [Windows.UI.Notifications.ToastCollectionManager](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollectionmanager)</span></span>

<span data-ttu-id="3efc8-109">以下の例には、チャット グループに基づいた通知を分離するメッセージング アプリがあります。それぞれのタイル (Comp Sci 160A Project Chat、Direct Messages、Lacrosse Team Chat) は別のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="3efc8-109">You can see the example below with a messaging app that separates the notifications based on the chat group; each title (Comp Sci 160A Project Chat, Direct Messages, Lacrosse Team Chat) is a separate collection.</span></span>  <span data-ttu-id="3efc8-110">すべて同じアプリからの通知である場合でも、別のアプリからの通知であるかのように、通知が明確にグループ化されているのがわかります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-110">Notice how the notifications are distinctly grouped as if they were from a seperate app, even though they are all notifications from the same app.</span></span>  <span data-ttu-id="3efc8-111">通知を整理するより巧妙な方法を探している場合は、「[トースト ヘッダー](toast-headers.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3efc8-111">If you are looking for a more subtle way to organize your notifications, see [toast headers](toast-headers.md).</span></span>  
![2 つ異なる通知のグループを持つコレクションの例](images/toast-collection-example.png)

## <a name="creating-collections"></a><span data-ttu-id="3efc8-113">コレクションの作成</span><span class="sxs-lookup"><span data-stu-id="3efc8-113">Creating collections</span></span>
<span data-ttu-id="3efc8-114">各コレクションを作成するときは、表示名とアイコンを指定する必要があります。表示名とアイコンは上のイメージに示すように、コレクションのタイトルの一部としてアクション センターの内部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-114">When creating each collection, you are required to provide a display name and an icon, which are displayed inside Action Center as part of the collection's title, as shown in the image above.</span></span> <span data-ttu-id="3efc8-115">また、ユーザーがコレクションのタイトルをクリックしたときにアプリがアプリ内の適切な場所に移動できるように、コレクションには起動引数が必要です。</span><span class="sxs-lookup"><span data-stu-id="3efc8-115">Collections also require a launch argument to help the app navigate to the right location within the app when the collection’s title is clicked on by the user.</span></span>  

### <a name="create-a-collection"></a><span data-ttu-id="3efc8-116">コレクションの作成</span><span class="sxs-lookup"><span data-stu-id="3efc8-116">Create a collection</span></span>

``` csharp 
public const string toastCollectionId = "ToastCollection";

// Create a toast collection
public async void CreateToastCollection()
{
    string displayName = "Work Email"; 
    string launchArg = "NavigateToWorkEmailInbox"; 
    Uri icon = new Windows.Foundation.Uri("ms-appx:///Assets/workEmail.png");

    // Constructor
    ToastCollection workEmailToastCollection = new ToastCollection(MainPage.toastCollectionId, 
        displayName,
        launchArg, 
        icon);

    // Calls the platform to create the collection
    await ToastNotificationManager.GetDefault().GetToastCollectionManager().SaveToastCollectionAsync(workEmailToastCollection);                                 
}
```

## <a name="sending-notifications-to-a-collection"></a><span data-ttu-id="3efc8-117">コレクションへの通知の送信</span><span class="sxs-lookup"><span data-stu-id="3efc8-117">Sending notifications to a collection</span></span>
<span data-ttu-id="3efc8-118">3 つの異なるトースト パイプライン (ローカル、スケジュール、プッシュ) からの通知の送信について説明します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-118">We will cover sending notifications from three different toast pipelines: local, scheduled, and push.</span></span>  <span data-ttu-id="3efc8-119">このそれぞれの例について、サンプルのトーストを作成して直後のコードと共に送信し、各パイプラインを介してコレクションにトーストを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-119">For each of these examples we will be creating a sample toast to send with the code immediately below, then we will focus on how to add the toast to a collection via each pipeline.</span></span>

<span data-ttu-id="3efc8-120">通知ペイロードの作成:</span><span class="sxs-lookup"><span data-stu-id="3efc8-120">Construct the notification payload:</span></span>

``` csharp
public const string toastCollectionId = "MyToastCollection";

public async void SendToastToToastCollection()
{
    // Construct the notification Content
    string toastXmlString = 
        $@"<toast launch=’’>
            <visual>
                <binding template=’ToastGeneric’>
                    <text>Hello,</text>
                    <text>it’s me</text>
                </binding>
            </visual>
        </toast>";
    // Convert to XML
    XmlDocument toastXml = new XmlDocment();
    toastXml.LoadXml(toastXmlString);
    ToastNotification toast = new ToastNotification(toastXml);
```

### <a name="send-a-toast-to-a-collection"></a><span data-ttu-id="3efc8-121">コレクションへのトーストの送信</span><span class="sxs-lookup"><span data-stu-id="3efc8-121">Send a toast to a collection</span></span>

```csharp
// Get the collection notifier
var notifier = await ToastNotificationManager.GetDefault().GetToastNotifierForToastCollectionIdAsync(MainPage.toastCollectionId);

// And show the toast
notifier.Show(toast);
```

### <a name="add-a-scheduled-toast-to-a-collection"></a><span data-ttu-id="3efc8-122">コレクションへのスケジュールされたトーストの追加</span><span class="sxs-lookup"><span data-stu-id="3efc8-122">Add a scheduled toast to a collection</span></span>

``` csharp
// Create scheduled toast from XML above
ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, DateTimeOffset.Now.AddSeconds(10));

// Get notifier
var notifier = await ToastNotificationManager.GetDefault().GetToastNotifierForToastCollectionIdAsync(MainPage.toastCollectionId);
    
// Add to schedule
notifier.AddToSchedule(scheduledToast);
```

### <a name="send-a-push-toast-to-a-collection"></a><span data-ttu-id="3efc8-123">コレクションへのプッシュ トーストの送信</span><span class="sxs-lookup"><span data-stu-id="3efc8-123">Send a push toast to a collection</span></span>
<span data-ttu-id="3efc8-124">プッシュ トーストでは、X-WNS-CollectionId ヘッダーを POST メッセージに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-124">For push toasts, you need to add the X-WNS-CollectionId header to the POST message.</span></span>
```csharp
// Add header to HTTP request
request.Headers.Add("X-WNS-CollectionId", collectionId); 

```

## <a name="managing-collections"></a><span data-ttu-id="3efc8-125">コレクションの管理</span><span class="sxs-lookup"><span data-stu-id="3efc8-125">Managing collections</span></span>
#### <a name="create-the-toast-collection-manager"></a><span data-ttu-id="3efc8-126">トースト コレクション マネージャーの作成</span><span class="sxs-lookup"><span data-stu-id="3efc8-126">Create the toast collection manager</span></span>
<span data-ttu-id="3efc8-127">この「コレクションの管理」セクションの残りのコード スニペットでは、以下の collectionManager を使用します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-127">For the rest of the code snippets in this 'Managing Collections' section we will be using the collectionManager below.</span></span>
```csharp
ToastCollectionManger collectionManager = ToastNotificationManager.GetDefault().GetToastCollectionManager();
```

#### <a name="get-all-collections"></a><span data-ttu-id="3efc8-128">すべてのコレクションの取得</span><span class="sxs-lookup"><span data-stu-id="3efc8-128">Get all collections</span></span>

``` csharp
IReadOnlyList<ToastCollection> collections = await collectionManager.FindAllToastCollectionsAsync();
``` 

#### <a name="get-the-number-of-collections-created"></a><span data-ttu-id="3efc8-129">作成されたコレクション数の取得</span><span class="sxs-lookup"><span data-stu-id="3efc8-129">Get the number of collections created</span></span>

``` csharp
int toastCollectionCount = (await collectionManager.FindAllToastCollectionsAsync()).Count;
```

#### <a name="remove-a-collection"></a><span data-ttu-id="3efc8-130">コレクションの削除</span><span class="sxs-lookup"><span data-stu-id="3efc8-130">Remove a collection</span></span>

``` csharp
await collectionManager.RemoveToastCollectionAsync(MainPage.toastCollectionId);
```

#### <a name="update-a-collection"></a><span data-ttu-id="3efc8-131">コレクションの更新</span><span class="sxs-lookup"><span data-stu-id="3efc8-131">Update a collection</span></span>
<span data-ttu-id="3efc8-132">同じ ID で新しいコレクションを作成し、コレクションの新しいインスタンスを保存して、コレクションを更新することができます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-132">You can update collections by creating a new collection with the same ID and saving the new instance of the collection.</span></span>
``` csharp
string displayName = "Updated Display Name"; 
string launchArg = "UpdatedLaunchArgs"; 
Uri icon = new Windows.Foundation.Uri("ms-appx:///Assets/updatedPicture.png");

// Construct a new toast collection with the same collection id
ToastCollection updatedToastCollection = new ToastCollection(MainPage.toastCollectionId, 
            displayName,
            launchArg, 
            icon);

// Calls the platform to update the collection by saving the new instance
await collectionManager.SaveToastCollectionAsync(updatedToastCollection);                               
```
## <a name="managing-toasts-within-a-collection"></a><span data-ttu-id="3efc8-133">コレクション内でのトーストの管理</span><span class="sxs-lookup"><span data-stu-id="3efc8-133">Managing toasts within a collection</span></span>
#### <a name="group-and-tag-properties"></a><span data-ttu-id="3efc8-134">グループとタグのプロパティ</span><span class="sxs-lookup"><span data-stu-id="3efc8-134">Group and tag properties</span></span>
<span data-ttu-id="3efc8-135">グループとタグのプロパティを合わせてコレクション内で一意に通知を識別します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-135">The group and tag properties together uniquely identify a notification within a collection.</span></span>  <span data-ttu-id="3efc8-136">グループ (およびタグ) は、復号主キー (1 つ以上の識別子) として機能し、通知を識別します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-136">Group (and Tag) serves as a composite primary key (more than one identifier) to identify your notification.</span></span> <span data-ttu-id="3efc8-137">たとえば、通知を削除するか置換する必要がある場合、削除または置換する*通知*を指定できる必要があります。これは、タグとグループを指定することによって行います。</span><span class="sxs-lookup"><span data-stu-id="3efc8-137">For example, if you want to remove or replace a notification, you have to be able to specify *what notification* you want to remove/replace; you do that by specifying the Tag and Group.</span></span> <span data-ttu-id="3efc8-138">例として、メッセージング アプリがあります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-138">An example is a messaging app.</span></span>  <span data-ttu-id="3efc8-139">開発者は、会話 ID をグループとして、メッセージ ID をタグとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-139">The developer could use the conversation ID as the Group, and the message ID as the Tag.</span></span>

#### <a name="remove-a-toast-from-a-collection"></a><span data-ttu-id="3efc8-140">コレクションからのトーストの削除</span><span class="sxs-lookup"><span data-stu-id="3efc8-140">Remove a toast from a collection</span></span>
<span data-ttu-id="3efc8-141">タグとグループの ID を使用して個々のトーストを削除したり、コレクション内のすべてのトーストをクリアできます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-141">You can remove individual toasts using the tag and group IDs, or clear all toasts in a collection.</span></span>
``` csharp
// Get the history
var collectionHistory = await ToastNotificationManager.GetDefault().GetHistoryForToastCollectionAsync(MainPage.toastCollectionId);

// Remove toast
collectionHistory.Remove(tag, group); 
```

#### <a name="clear-all-toasts-within-a-collection"></a><span data-ttu-id="3efc8-142">コレクション内のすべてのトーストのクリア</span><span class="sxs-lookup"><span data-stu-id="3efc8-142">Clear all toasts within a collection</span></span>
``` csharp
// Get the history
var collectionHistory = await ToastNotificationManager.GetDefault().GetHistoryForToastCollectionAsync(MainPage.toastCollectionId);

// Remove toast
collectionHistory.Clear();
```


## <a name="collections-in-notifications-visualizer"></a><span data-ttu-id="3efc8-143">Notifications Visualizer のコレクション</span><span class="sxs-lookup"><span data-stu-id="3efc8-143">Collections in Notifications Visualizer</span></span>
<span data-ttu-id="3efc8-144">[Notifications Visualizer](notifications-visualizer.md) ツールを使用するとコレクションの設計に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-144">You can use the [Notifications Visualizer](notifications-visualizer.md) tool to help design your collections.</span></span> <span data-ttu-id="3efc8-145">次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-145">Follow the steps below:</span></span>

* <span data-ttu-id="3efc8-146">右下隅にある歯車アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="3efc8-146">Click on the gear icon in the bottom right corner.</span></span> 
* <span data-ttu-id="3efc8-147">[Toast collections] (トースト コレクション) を選択します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-147">Select 'Toast collections'.</span></span>
* <span data-ttu-id="3efc8-148">トーストのプレビューの上に、[トースト コレクション] ドロップダウン メニューがあります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-148">Above the preview of the toast, there is a 'Toast Collection' dropdown menu.</span></span> <span data-ttu-id="3efc8-149">[manage collections] (コレクションの管理) を選択します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-149">Select manage collections.</span></span>
* <span data-ttu-id="3efc8-150">[コレクションの追加] をクリックし、コレクションの詳細を入力し、保存します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-150">Click 'Add collection', fill out the details for the collection, and save.</span></span>
* <span data-ttu-id="3efc8-151">コレクションを追加するか、または [コレクションの管理] ボックスをオフにしてメイン画面に戻ることができます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-151">You can add more collections, or click off of the manage collections box to return to the main screen.</span></span>
* <span data-ttu-id="3efc8-152">[トースト コレクション] ドロップダウン メニューからトーストを追加するコレクションを選択します。</span><span class="sxs-lookup"><span data-stu-id="3efc8-152">Select the collection you want to add the toast to from the 'Toast Collection' dropdown menu.</span></span>
* <span data-ttu-id="3efc8-153">トーストを生成するときに、アクション センターの適切なコレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-153">When you fire the toast, it will be added to the appropriate collection in Action Center.</span></span>


## <a name="other-details"></a><span data-ttu-id="3efc8-154">その他の詳細</span><span class="sxs-lookup"><span data-stu-id="3efc8-154">Other details</span></span>
<span data-ttu-id="3efc8-155">作成するトースト コレクションは、ユーザーの通知の設定にも反映されます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-155">The toast collections that you create will also be reflected in the user's notification settings.</span></span>  <span data-ttu-id="3efc8-156">ユーザーは、個々のコレクションの設定を切り替えて、これらのサブグループをオンまたはオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-156">Users can toggle the settings for each individual collection to turn these subgroups on or off.</span></span>  <span data-ttu-id="3efc8-157">アプリの最上位で通知がオフになると、すべてのコレクションの通知もオフになります。</span><span class="sxs-lookup"><span data-stu-id="3efc8-157">If notifications are turned off at the top level for the app, then all collections notifications will be turned off as well.</span></span>  <span data-ttu-id="3efc8-158">さらに、各コレクションでは、既定でアクション センターに 3 つの通知が表示され、ユーザーはこれを展開して最大 20 の通知を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="3efc8-158">In addition, each collection will by default show 3 notifications in Action Center, and the user can expand it to show up to 20 notifications.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3efc8-159">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3efc8-159">Related topics</span></span>

* [<span data-ttu-id="3efc8-160">トーストのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3efc8-160">Toast content</span></span>](adaptive-interactive-toasts.md)
* [<span data-ttu-id="3efc8-161">トースト ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3efc8-161">Toast headers</span></span>](toast-headers.md)
* [<span data-ttu-id="3efc8-162">GitHub の通知ライブラリ (Windows コミュニティ ツールキットの一部)</span><span class="sxs-lookup"><span data-stu-id="3efc8-162">Notifications library on GitHub (part of the Windows Community Toolkit)</span></span>](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)