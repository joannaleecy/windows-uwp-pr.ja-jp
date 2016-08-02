---
author: normesta
description: 'Shows how to integrate social feeds into the People app'
MSHAttr: 'PreferredLib:/library/windows/apps'
title: 'Provide social feeds to the People app'
---

# Provide social feeds to the People app

Integrate social feed data from your database into the People app.

Your feed data will appear in the **What's New** pages of the People app or in the **Profile** page of a contact.

![Social Feeds in People App](images/social-feeds.png)

To get started, create a foreground app that tags contacts for social feeds and a background agent that sends feed data to the People app.

For a more complete sample, see [Social Info Sample](https://github.com/Microsoft/Windows-Social-Samples/tree/master/SocialInfoSampleApp).

## Create a foreground app

First, create a Universal Windows Platform (UWP) project and then add the **Windows Mobile Extensions for UWP** to it.

![Mobile Extensions](images/mobile-extensions.png)

### Find or create contacts

You can find contacts by using a name, email address, or phone number.

```cs
ContactStore contactStore = await ContactManager.RequestStoreAsync();

IReadOnlyList<Contact> contacts = null;

contacts = await contactStore.FindContactsAsync(emailAddress);

Contact contact = contacts[0];
```
You can also create contacts and then add them to a contact list.

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

### Tag each contact with an annotation

This *annotation* causes the People app to request feed data for the contact from your background agent.

As part of the annotation, associate the ID of the contact to an ID that your app uses internally to identify that contact.

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
### Provision the background agent

Make sure that the [SocialInfoContract](https://msdn.microsoft.com/library/windows/apps/dn706146.aspx) API contract is available on the device that will run your app.

If it's available, then provision the background agent.

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
## Create the background agent

The background agent is a Windows Runtime Component that responds to feed requests from the People app.

In your agent, you'll respond to those requests by giving the People app feed data from your database.

### Create a Windows Runtime Component

Add a **Windows Runtime Component (Universal Windows)** project to your solution.

![Windows Runtime Component](images/windows-runtime-component.png)

### Register the background agent as an app service

Register by adding protocol handlers to the ``Extensions`` element of the manifest.

```xml
<Extensions>
  <uap:Extension Category="windows.appService" EntryPoint="SocialFeeds.BackgroundAgent">
    <uap:AppService Name="com.microsoft.windows.social-feeds" />
  </uap:Extension>
</Extensions>
```
You can also add these in the **Declarations** tab of the manifest designer in Visual Studio.

![App Service in Manifest Designer](images/manifest-designer-app-service.png)

### Request operations from the People app

Ask the People app what type of data it wants next. The People app will respond to your request with a code that indicates which feed it wants data for.

This table describes each feed:

| Feed | Description |
|-------|-------------|
| Home | Feed that appears in the What's New page of the People app. |
| Contact | Feed that appears in the What's New page of a contact. |
| Dashboard | Feed that appears in the contact card next to the profile picture. |
<br>
You'll ask the People app by requesting an *operation*. Implement the [IBackgroundTask](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.aspx) interface and override the [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) method.

In the [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) method, send the People app two key-value pairs. One of them contains the version of the protocol and the other one contains the type of the operation.

Then listen for a response from the People app. That response will contain a code.

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

Refer to the ``Type`` element of the [AppServiceResponse.Message](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceresponse.message.aspx) property to get that code. Here's a complete list of the codes.

| Type| Description |
|-----|-------------|
| 0x10 | A request to the People app for the next operation. |
| 0x11 | A request from the People app to provide the home feed for the primary user. |
| 0x13 | A request from the People app to get the contact feed for the selected contact. |
| 0x15 | A request from the People app to get the dashboard item of the selected contact. |
| 0x80 | Indicates that the operation is completed. This notifies the People app that the data is now available. |
| 0xF1 | A message from the People app indicating that it does not require any other operations. The background agent can shut down now. |
<br>
The [AppServiceResponse.Message](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceresponse.message.aspx) property also returns a collection of other key-value pairs that describe the response. Here's a list of them.

| Key | Type | Description |
|-----|------|-------------|
| Version | UINT32 | (Required) Identifies the version of the message protocol. The upper 16 bits are the major version, and the lower 16 bits are the minor version. |
| Type | UINT32 | (Required) The type of operation to perform. The previous example uses the Type key to determine what operation the People app is asking for.
| OperationId | UINT32 | The ID of the operation. |
| OwnerRemoteId | String | ID that your app uses internally to identify that contact. |
| LastFeedItemTimeStamp | String | The ID of the last feed item that was retrieved. |
| LastFeedItemTimeStamp | DateTime | The time stamp of the last feed item that was retrieved. |
| ItemCount | UINT32 | The number of items that the People app asks for. |
| IsFetchMore | BOOLEAN | Determines when the internal cache is updated. |
| ErrorCode | UINT32 | The error code associated with the background agent operation. |
<br>
### Provide a data feed to the People app

A **Type** value of ``0x11``, ``0x13``, or ``0x15`` is a request from the People app for feed data.  

The next few snippets show an approach to providing that data to the People app.

> [!NOTE]
> These snippets come from the [Social Info Sample](https://github.com/Microsoft/Windows-Social-Samples/tree/master/SocialInfoSampleApp). They contain references to interfaces, classes and members that are defined elsewhere in the sample. Use these snippets along with the other examples in this topic to understand the flow of tasks and refer to the sample if you're interested in diving further into the stack of interfaces, classes, and types.

**Get contact feed items**

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

**Get dashboard items**

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

**Get home feed items**

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

### Send success or failure notification back to the People app

Encapsulate your calls in a try catch block and then pass back a success or failure message to the People app after you've provided feed data.

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
