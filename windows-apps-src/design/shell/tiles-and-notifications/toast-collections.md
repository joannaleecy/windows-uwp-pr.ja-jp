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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7300190"
---
# <a name="grouping-toast-notifications-with-collections"></a>コレクションを使用したトースト通知のグループ化
コレクションを使用してアクション センターでアプリのトーストを整理します。 コレクションにより、ユーザーはアクション センター内での情報をより簡単に見つけることができ、開発者が通知をより適切に管理できるようになります。  下の API では、通知のコレクションの削除、作成、および更新が可能です。

> [!IMPORTANT]
> **Creators Update が必要**: トースト コレクションを使用するには、SDK 15063 をターゲットとし、ビルド 15063 以降を実行している必要があります。 関連する API には、[Windows.UI.Notifications.ToastCollection](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollection) および [Windows.UI.Notifications.ToastCollectionManager](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollectionmanager) が含まれます。

以下の例には、チャット グループに基づいた通知を分離するメッセージング アプリがあります。それぞれのタイル (Comp Sci 160A Project Chat、Direct Messages、Lacrosse Team Chat) は別のコレクションです。  すべて同じアプリからの通知である場合でも、別のアプリからの通知であるかのように、通知が明確にグループ化されているのがわかります。  通知を整理するより巧妙な方法を探している場合は、「[トースト ヘッダー](toast-headers.md)」を参照してください。  
![2 つ異なる通知のグループを持つコレクションの例](images/toast-collection-example.png)

## <a name="creating-collections"></a>コレクションの作成
各コレクションを作成するときは、表示名とアイコンを指定する必要があります。表示名とアイコンは上のイメージに示すように、コレクションのタイトルの一部としてアクション センターの内部に表示されます。 また、ユーザーがコレクションのタイトルをクリックしたときにアプリがアプリ内の適切な場所に移動できるように、コレクションには起動引数が必要です。  

### <a name="create-a-collection"></a>コレクションの作成

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

## <a name="sending-notifications-to-a-collection"></a>コレクションへの通知の送信
3 つの異なるトースト パイプライン (ローカル、スケジュール、プッシュ) からの通知の送信について説明します。  このそれぞれの例について、サンプルのトーストを作成して直後のコードと共に送信し、各パイプラインを介してコレクションにトーストを追加する方法について説明します。

通知ペイロードの作成:

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

### <a name="send-a-toast-to-a-collection"></a>コレクションへのトーストの送信

```csharp
// Get the collection notifier
var notifier = await ToastNotificationManager.GetDefault().GetToastNotifierForToastCollectionIdAsync(MainPage.toastCollectionId);

// And show the toast
notifier.Show(toast);
```

### <a name="add-a-scheduled-toast-to-a-collection"></a>コレクションへのスケジュールされたトーストの追加

``` csharp
// Create scheduled toast from XML above
ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, DateTimeOffset.Now.AddSeconds(10));

// Get notifier
var notifier = await ToastNotificationManager.GetDefault().GetToastNotifierForToastCollectionIdAsync(MainPage.toastCollectionId);
    
// Add to schedule
notifier.AddToSchedule(scheduledToast);
```

### <a name="send-a-push-toast-to-a-collection"></a>コレクションへのプッシュ トーストの送信
プッシュ トーストでは、X-WNS-CollectionId ヘッダーを POST メッセージに追加する必要があります。
```csharp
// Add header to HTTP request
request.Headers.Add("X-WNS-CollectionId", collectionId); 

```

## <a name="managing-collections"></a>コレクションの管理
#### <a name="create-the-toast-collection-manager"></a>トースト コレクション マネージャーの作成
この「コレクションの管理」セクションの残りのコード スニペットでは、以下の collectionManager を使用します。
```csharp
ToastCollectionManger collectionManager = ToastNotificationManager.GetDefault().GetToastCollectionManager();
```

#### <a name="get-all-collections"></a>すべてのコレクションの取得

``` csharp
IReadOnlyList<ToastCollection> collections = await collectionManager.FindAllToastCollectionsAsync();
``` 

#### <a name="get-the-number-of-collections-created"></a>作成されたコレクション数の取得

``` csharp
int toastCollectionCount = (await collectionManager.FindAllToastCollectionsAsync()).Count;
```

#### <a name="remove-a-collection"></a>コレクションの削除

``` csharp
await collectionManager.RemoveToastCollectionAsync(MainPage.toastCollectionId);
```

#### <a name="update-a-collection"></a>コレクションの更新
同じ ID で新しいコレクションを作成し、コレクションの新しいインスタンスを保存して、コレクションを更新することができます。
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
## <a name="managing-toasts-within-a-collection"></a>コレクション内でのトーストの管理
#### <a name="group-and-tag-properties"></a>グループとタグのプロパティ
グループとタグのプロパティを合わせてコレクション内で一意に通知を識別します。  グループ (およびタグ) は、復号主キー (1 つ以上の識別子) として機能し、通知を識別します。 たとえば、通知を削除するか置換する必要がある場合、削除または置換する*通知*を指定できる必要があります。これは、タグとグループを指定することによって行います。 例として、メッセージング アプリがあります。  開発者は、会話 ID をグループとして、メッセージ ID をタグとして使用できます。

#### <a name="remove-a-toast-from-a-collection"></a>コレクションからのトーストの削除
タグとグループの ID を使用して個々のトーストを削除したり、コレクション内のすべてのトーストをクリアできます。
``` csharp
// Get the history
var collectionHistory = await ToastNotificationManager.GetDefault().GetHistoryForToastCollectionAsync(MainPage.toastCollectionId);

// Remove toast
collectionHistory.Remove(tag, group); 
```

#### <a name="clear-all-toasts-within-a-collection"></a>コレクション内のすべてのトーストのクリア
``` csharp
// Get the history
var collectionHistory = await ToastNotificationManager.GetDefault().GetHistoryForToastCollectionAsync(MainPage.toastCollectionId);

// Remove toast
collectionHistory.Clear();
```


## <a name="collections-in-notifications-visualizer"></a>Notifications Visualizer のコレクション
[Notifications Visualizer](notifications-visualizer.md) ツールを使用するとコレクションの設計に役立ちます。 次の手順を実行します。

* 右下隅にある歯車アイコンをクリックします。 
* [Toast collections] (トースト コレクション) を選択します。
* トーストのプレビューの上に、[トースト コレクション] ドロップダウン メニューがあります。 [manage collections] (コレクションの管理) を選択します。
* [コレクションの追加] をクリックし、コレクションの詳細を入力し、保存します。
* コレクションを追加するか、または [コレクションの管理] ボックスをオフにしてメイン画面に戻ることができます。
* [トースト コレクション] ドロップダウン メニューからトーストを追加するコレクションを選択します。
* トーストを生成するときに、アクション センターの適切なコレクションに追加されます。


## <a name="other-details"></a>その他の詳細
作成するトースト コレクションは、ユーザーの通知の設定にも反映されます。  ユーザーは、個々のコレクションの設定を切り替えて、これらのサブグループをオンまたはオフにすることができます。  アプリの最上位で通知がオフになると、すべてのコレクションの通知もオフになります。  さらに、各コレクションでは、既定でアクション センターに 3 つの通知が表示され、ユーザーはこれを展開して最大 20 の通知を表示することができます。

## <a name="related-topics"></a>関連トピック

* [トーストのコンテンツ](adaptive-interactive-toasts.md)
* [トースト ヘッダー](toast-headers.md)
* [GitHub の通知ライブラリ (Windows コミュニティ ツールキットの一部)](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)