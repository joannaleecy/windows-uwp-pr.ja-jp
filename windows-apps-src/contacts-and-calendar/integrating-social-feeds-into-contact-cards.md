---
author: normesta
description: "People アプリにソーシャル フィードを統合する方法を紹介する"
MSHAttr: PreferredLib:/library/windows/apps
title: "People アプリにソーシャル フィードを提供する"
translationtype: Human Translation
ms.sourcegitcommit: 767acdc847e1897cc17918ce7f49f9807681f4a3
ms.openlocfilehash: c5b9666d8654a4065bc0e4e400d3e47de4773b8b

---

# People アプリにソーシャル フィードを提供する

データベースのソーシャル フィード データを People アプリに統合します。

フィード データは、People アプリの **[新着情報]** ページまたは連絡先の **[プロファイル]** ページに表示されます。

ユーザーはフィード項目をタップしてアプリを開くことができます。

![People アプリのソーシャル フィード](images/social-feeds.png)

最初に、連絡先にソーシャル フィードのタグを付けるフォアグラウンド アプリと、People アプリにフィード データを送信するバックグラウンド エージェントを作成します。

完全なサンプルについては、[ソーシャル情報のサンプル](https://github.com/Microsoft/Windows-Social-Samples/tree/master/SocialInfoSampleApp)をご覧ください。

## フォアグラウンド アプリを作成する

まず、ユニバーサル Windows プラットフォーム (UWP) プロジェクトを作成し、**[Windows Mobile Extensions for UWP]** を追加します。

![モバイル拡張](images/mobile-extensions.png)

### 連絡先を検索または作成する

連絡先は、名前、メール アドレス、または電話番号を使って検索できます。

```cs
ContactStore contactStore = await ContactManager.RequestStoreAsync();

IReadOnlyList<Contact> contacts = null;

contacts = await contactStore.FindContactsAsync(emailAddress);

Contact contact = contacts[0];
```
連絡先は、作成してから連絡先一覧に追加することもできます。

```cs
Contact contact = new Contact();
contact.FirstName = "TestContact";

ContactEmail email = new ContactEmail();
email.Address = "TestContact@contoso.com";
email.Kind = ContactEmailKind.Other;
contact.Emails.Add(email);

ContactPhone phone = new ContactPhone();
phone.Number = "4255550101";
phone.Kind = ContactPhoneKind.Mobile;
contact.Phones.Add(phone);

ContactStore store = await
    ContactManager.RequestStoreAsync(ContactStoreAccessType.AppContactsReadWrite);

ContactList contactList;

IReadOnlyList<ContactList> contactLists = await store.FindContactListsAsync();

if (0 == contactLists.Count)
    contactList = await store.CreateContactListAsync("TestContactList");
else
    contactList = contactLists[0];

await contactList.SaveContactAsync(contact);
```

### 注釈を使って各連絡先にタグを付ける

この*注釈*によって、People アプリはバックグラウンド エージェントから連絡先のフィード データを要求します。

注釈の一部として、連絡先の ID を、アプリがその連絡先を識別するために内部で使っている ID に関連付けます。

```cs
ContactAnnotationStore annotationStore = await
   ContactManager.RequestAnnotationStoreAsync(ContactAnnotationStoreAccessType.AppAnnotationsReadWrite);

ContactAnnotationList annotationList;

IReadOnlyList<ContactAnnotationList> annotationLists = await annotationStore.FindAnnotationListsAsync();
if (0 == annotationLists.Count)
    annotationList = await annotationStore.CreateAnnotationListAsync();
else
    annotationList = annotationLists[0];

ContactAnnotation annotation = new ContactAnnotation();
annotation.ContactId = contact.Id;
annotation.RemoteId = "user22";

annotation.SupportedOperations = ContactAnnotationOperations.SocialFeeds;

await annotationList.TrySaveAnnotationAsync(annotation);

```
### バックグラウンド エージェントをプロビジョニングする

アプリを実行するデバイスで [SocialInfoContract](https://msdn.microsoft.com/library/windows/apps/dn706146.aspx) API コントラクトを利用できることを確認してください。

利用できる場合は、バックグラウンド エージェントをプロビジョニングします。

```cs
if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent(
"Windows.ApplicationModel.SocialInfo.SocialInfoContract",
1))
{
    bool isProvisionSuccessful = await Windows.ApplicationModel.SocialInfo.Provider.SocialInfoProviderManager.ProvisionAsync();

    // Throw an exception if the app could not be provisioned
    if (!isProvisionSuccessful)
    {
        throw new Exception("Could not provision the app with the SocialInfoProviderManager");
    }
}
```
## バック グラウンド エージェントを作成する

バックグラウンド エージェントは、People アプリからのフィード要求に応答する Windows ランタイム コンポーネントです。

お使いのエージェントでは、データベースのフィード データを People アプリに提供することで、それらの要求に応答します。

### Windows ランタイム コンポーネントを作成する

ソリューションに **[Windows ランタイム コンポーネント (ユニバーサル Windows)]** プロジェクトを追加します。

![Windows ランタイム コンポーネント](images/windows-runtime-component.png)

### バックグラウンド エージェントをアプリ サービスとして登録する

登録するには、プロトコル ハンドラーをマニフェストの ``Extensions`` 要素に追加します。

```xml
<Extensions>
  <uap:Extension Category="windows.appService" EntryPoint="SocialFeeds.BackgroundAgent">
    <uap:AppService Name="com.microsoft.windows.social-feeds" />
  </uap:Extension>
</Extensions>
```
Visual Studio のマニフェスト デザイナーの **[宣言]** タブで追加することもできます。

![マニフェスト デザイナーの App Service](images/manifest-designer-app-service.png)

### People アプリから操作を要求する

次に必要なデータの種類を People アプリに要求します。 People アプリは、どのフィードのデータが必要なのかを示すコードを使って要求に応答します。

次の表で、各フィードについて説明します。

| フィード | 説明 |
|-------|-------------|
| ホーム | People アプリの [新着情報] ページに表示するフィード。 |
| 連絡先 | 連絡先の [新着情報] ページに表示するフィード。 |
| ダッシュボード | プロフィール画像の横にある連絡先カードに表示するフィード。 |
<br>
*操作*を要求することによって、People アプリに要求します。 [IBackgroundTask](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.aspx) インターフェイスを実装し、[Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドをオーバーライドします。

[Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドで、People アプリに 2 組のキーと値のペアを送信します。 それらのペアの 1 つにはプロトコルのバージョンが含まれ、もう 1 つには操作の種類が含まれます。

People アプリからの応答をリッスンします。 その応答にはコードが含まれます。

```cs
public sealed class BackgroundAgent : IBackgroundTask
{
    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        BackgroundTaskDeferral backgroundTaskDeferral = taskInstance.GetDeferral();

        AppServiceTriggerDetails triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;

        AppServiceConnection appServiceConnection = triggerDetails.AppServiceConnection;

        bool continueProcessing = true;

        while (continueProcessing)
        {
            // Get next operation.
            ValueSet fields =
                new ValueSet();

            fields.Add("Version",
                (1 << 16) | 0);

            fields.Add(
                "Type", 0x10);

            AppServiceResponse response =
                await appServiceConnection.SendMessageAsync(fields);

            if (response == null || response.Status != AppServiceResponseStatus.Success)
            { /* throw exception */ }

            UInt32 type = (UInt32)response.Message["Type"];

            switch (type)
            {
                //Get Next Operation.
                case 0x10:
                    break;
                //Download Home Feed Operation.
                case 0x11:
                    break;
                //Download Contact Feed Operation.
                case 0x13:
                    break;
                //Download Dashboard Feed Operation.
                case 0x15:
                    break;
                //Operation Result.
                case 0x80:
                    break;
                //Good Bye.
                case 0xF1:
                    continueProcessing = false;
                    break;
            }
        }
        // Complete the task deferral
        backgroundTaskDeferral.Complete();

        backgroundTaskDeferral = null;
        appServiceConnection = null;
    }

}
```

[AppServiceResponse.Message](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceresponse.message.aspx) プロパティの ``Type`` 要素を参照して、そのコードを取得します。 以下に、コードの完全な一覧を示します。

| 型| 説明 |
|-----|-------------|
| 0x10 | People アプリへの次の操作の要求。 |
| 0x11 | プライマリ ユーザーにホーム フィードを提供するための People アプリからの要求。 |
| 0x13 | 選択した連絡先の連絡先フィードを取得するための People アプリからの要求。 |
| 0x15 | 選択した連絡先のダッシュボード アイテムを取得するための People アプリからの要求。 |
| 0x80 | 操作が完了したことを示します。 データが利用できるようになったことが People アプリに通知されます。 |
| 0xF1 | 他の操作を要求していないことを示す People アプリからのメッセージ。 この時点で、バックグラウンド エージェントはシャットダウンできます。 |
<br>
また、[AppServiceResponse.Message](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceresponse.message.aspx) プロパティは、応答について説明する他のキーと値のペアのコレクションを返します。 その一覧を次に示します。

| キー | 型 | 説明 |
|-----|------|-------------|
| Version | UINT32 | (必須) メッセージ プロトコルのバージョンを識別します。 上位 16 ビットはメジャー バージョンで、下位 16 ビットはマイナー バージョンです。 |
| 型 | UINT32 | (必須) 実行する操作の種類。 上記の例では、Type キーを使って People アプリが要求している操作を判断しています。
| OperationId | UINT32 | 操作の ID。 |
| OwnerRemoteId | String | 対象の連絡先を識別するためにアプリが内部で使っている ID。 |
| LastFeedItemTimeStamp | String | 最後に取得されたフィード項目の ID。 |
| LastFeedItemTimeStamp | DateTime | 最後に取得されたフィード項目のタイム スタンプ。 |
| ItemCount | UINT32 | People アプリが要求する項目の数。 |
| IsFetchMore | BOOLEAN | 内部キャッシュを更新するタイミングを決定します。 |
| ErrorCode | UINT32 | バックグラウンド エージェントの操作に関連付けられたエラー コード。 |
<br>
### People アプリにデータ フィードを提供する

**Type** の値 ``0x11``、``0x13``、``0x15`` は、フィード データに対する People アプリからの要求です。  

次に示すいくつかのスニペットは、People アプリに対象のデータを提供するアプローチを示しています。

> [!NOTE]
> これらのスニペットは、[ソーシャル情報のサンプル](https://github.com/Microsoft/Windows-Social-Samples/tree/master/SocialInfoSampleApp)から引用しています。 そのため、サンプルの他の部分で定義されているインターフェイス、クラス、メンバーへの参照が含まれています。 これらのスニペットをこのトピックの他の例と一緒に使って、タスクのフローを理解し、多数のインターフェイス、クラス、型の詳細に関心がある場合はサンプルを参照してください。

**連絡先フィード項目を取得する**

```cs
public override async Task DownloadFeedAsync()
{
    // Get the contact feeds
    IEnumerable<FeedItem> contactFeedItems =
        InMemorySocialCache.Instance.GetContactFeeds(OwnerRemoteId, ItemCount);

    // Check if the platform supports the SocialInfo APIs
    if (!Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent(
         "Windows.ApplicationModel.SocialInfo.SocialInfoContract", 1))
    {

        return;
    }

    // Create the social feed updater.
    SocialFeedUpdater feedUpdater = await SocialInfoProviderManager.CreateSocialFeedUpdaterAsync(
        SocialFeedKind.ContactFeed,
        SocialFeedUpdateMode.Replace,
        OwnerRemoteId);

    // Translate the sample feed into Social info feed items.
    foreach (FeedItem fi in contactFeedItems)
    {
        SocialFeedItem item = new SocialFeedItem();

        item.Timestamp = fi.Timestamp;
        item.RemoteId = fi.Id;
        item.TargetUri = fi.TargetUri;
        item.Author.DisplayName = fi.AuthorDisplayName;
        item.Author.RemoteId = fi.AuthorId;
        item.PrimaryContent.Title = fi.Title;
        item.PrimaryContent.Message = fi.Message;

        if (fi.ImageUri != null)
        {
            item.Thumbnails.Add(new SocialItemThumbnail()
            {
                TargetUri = fi.TargetUri,
                ImageUri = fi.ImageUri
            });
        }

        feedUpdater.Items.Add(item);
    }

    await feedUpdater.CommitAsync();
}
```

**ダッシュボード項目を取得する**

```cs
public override async Task DownloadFeedAsync()
{
    // Get the dashboard feed item from your database.
    FeedItem dashboardFeedItem = InMemorySocialCache.Instance.GetDashboardFeed(OwnerRemoteId);

    if (dashboardFeedItem != null)
    {
        // Check if the platform supports the social info APIs.
        if (!Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent(
             "Windows.ApplicationModel.SocialInfo.SocialInfoContract", 1))
        {

            return;
        }

        SocialDashboardItemUpdater dashboard =
            await SocialInfoProviderManager.CreateDashboardItemUpdaterAsync(OwnerRemoteId);

        dashboard.Content.Message = dashboardFeedItem.Message;
        dashboard.Content.Title = dashboardFeedItem.Title;
        dashboard.Timestamp = dashboardFeedItem.Timestamp;

        // The TargetUri of the dashboard always has to be set.
        dashboard.TargetUri = dashboardFeedItem.TargetUri;

        // For a thumbnail, there must always be a target Uri.
        if ((dashboardFeedItem.ImageUri != null) && (dashboardFeedItem.TargetUri != null))
        {
            dashboard.Thumbnail = new SocialItemThumbnail()
            {
                ImageUri = dashboardFeedItem.ImageUri,
                TargetUri = dashboardFeedItem.TargetUri
            };
        }

        await dashboard.CommitAsync();
    }
}
```

**ホーム フィード項目を取得する**

```cs
public override async Task DownloadFeedAsync()
{
    // Query the "database" for the home feeds.
    IEnumerable<FeedItem> homeFeedItems =
        InMemorySocialCache.Instance.GetHomeFeeds(OwnerRemoteId, ItemCount);

    // Check if the platform supports the social info APIs.
    if (!Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent(
         "Windows.ApplicationModel.SocialInfo.SocialInfoContract", 1))
    {

        return;
    }

    // Create the social feed updater.
    SocialFeedUpdater feedUpdater = await SocialInfoProviderManager.CreateSocialFeedUpdaterAsync(
        SocialFeedKind.HomeFeed,
        SocialFeedUpdateMode.Replace,
        OwnerRemoteId);

    // Generate each of the feed items.
    foreach (FeedItem fi in homeFeedItems)
    {
        SocialFeedItem item = new SocialFeedItem();

        item.Timestamp = fi.Timestamp;
        item.RemoteId = fi.Id;
        item.TargetUri = fi.TargetUri;
        item.Author.DisplayName = fi.AuthorDisplayName;
        item.Author.RemoteId = fi.AuthorId;
        item.PrimaryContent.Title = fi.Title;
        item.PrimaryContent.Message = fi.Message;

        if (fi.ImageUri != null)
        {
            item.Thumbnails.Add(new SocialItemThumbnail()
            {
                TargetUri = fi.TargetUri,
                ImageUri = fi.ImageUri
            });
        }

        feedUpdater.Items.Add(item);
    }

    await feedUpdater.CommitAsync();
}
```

### People アプリに成功か失敗かの通知を送信する

フィード データを指定した後、try catch ブロックで呼び出しをカプセル化し、People アプリに成功か失敗かのメッセージを返します。

```cs
try
{
    // Calls to methods that fetch data and populate feed.
}
catch (Exception exception)
{
    errorCode = (UInt32)exception.HResult;
}

// Send status back to the people app.
ValueSet fields =
    new ValueSet();

fields.Add("ErrorCode", errorCode);

UInt32 operationID = (UInt32)response.Message["OperationId"];

fields.Add("OperationId", operationID);

await this.mAppServiceConnection.SendMessageAsync(fields);

```



<!--HONumber=Aug16_HO4-->


