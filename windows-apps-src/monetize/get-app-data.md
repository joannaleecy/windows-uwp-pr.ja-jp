---
author: mcleanbyron
ms.assetid: 8D4AE532-22EF-4743-9555-A828B24B8F16
description: Use these methods in the Windows Store submission API to retrieve data for apps that are registered to your Windows Dev Center account.
title: Get app data using the Windows Store submission API
---

# Get app data using the Windows Store submission API

Use the following methods in the Windows Store submission API to get data for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled. These methods can only be used to get data for apps. To create or manage submissions for apps, see the methods in [Manage app submissions](manage-app-submissions.md).

| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications``` | Retrieves data for all the apps that are registered to your Windows Dev Center account. For more information, see [Get all apps](get-all-apps.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}``` | Retrieves data about a specific app that is registered to your Windows Dev Center account. For more information, see [Get an app](get-an-app.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listinappproducts``` | Lists the add-ons (also known as in-app products or IAPs) for an app that is registered to your Windows Dev Center account. For more information, see [Get add-ons for an app](get-add-ons-for-an-app.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listflights``` | Lists the package flights for an app that is registered to your Windows Dev Center account. For more information, see [Get package flights for an app](get-flights-for-an-app.md). |

<span/>

## Prerequisites

If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API before trying to use any of these methods.

## Resources

These methods use the following resources to format data.

<span id="application_object" />
### Application

This resource represents an app that is registered to your account. The following example demonstrates the format of this resource.

```json
{
  "id": "9NBLGGH4R315",
  "primaryName": "ApiTestApp",
  "packageFamilyName": "30481DevCenterAPITester.ApiTestAppForDevbox_ng6try80pwt52",
  "packageIdentityName": "30481DevCenterAPITester.ApiTestAppForDevbox",
  "publisherName": "CN=…",
  "firstPublishedDate": "1601-01-01T00:00:00Z",
  "lastPublishedApplicationSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621086517"
  },
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621243487"
  }
}
```

This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | The Store ID of the app. For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).   |
| primaryName   | string  | The primary name of the app.                                                                                                                                                   |
| packageFamilyName | string  | The package family name of the app.                                                                                                                                                                                                         |
| packageIdentityName          | string  | The package identity name of the app.                                                                                                                                                              |
| publisherName       | string  | The Windows publisher ID that is associated with the app. This corresponds to the **Package/Identity/Publisher** value that appears on the [App identity](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details) page for the app in the Windows Dev Center dashboard.                                                                                             |
| firstPublishedDate      | string  | The date the app was first published, in ISO 8601 format.                                                                                         |
| lastPublishedApplicationSubmission       | object | An object that provides information about the last published submission for the app. For more information, see the [Submission](#submission_object) section below.                                                                                                                                                          |
| pendingApplicationSubmission        | object  |  An object that provides information about the current pending submission for the app. For more information, see the [Submission](#submission_object) section below.  |   |


<span id="add-on-object" />
### Add-on

This resource provides information about an add-on. The following example demonstrates the format of this resource.

```json
{
    "inAppProductId": "9WZDNCRD7DLK"
}
```

This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| inAppProductId            | string  | The Store ID of the add-on. This value is supplied by the Store. An example Store ID is 9NBLGGH4TNMP.   |


<span id="flight-object" />
### Flight

This resource provides information about a package flight for an app. The following example demonstrates the format of this resource.

```json
{
    "flightId": "7bfc11d5-f710-47c5-8a98-e04bb5aad310",
    "friendlyName": "myflight",
    "lastPublishedFlightSubmission": {
        "id": "1152921504621086517",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621086517"
    },
    "pendingFlightSubmission": {
        "id": "1152921504621215786",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621215786"
    },
    "groupIds": [
        "1152921504606962205"
    ],
    "rankHigherThan": "Non-flighted submission"
}
```

This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| flightId            | string  | The ID for the package flight. This value is supplied by Dev Center.  |
| friendlyName           | string  | The name of the package flight, as specified by the developer.   |
| lastPublishedFlightSubmission       | object | An object that provides information about the last published submission for the package flight. For more information, see the [Submission](#submission_object) section below.  |
| pendingFlightSubmission        | object  |  An object that provides information about the current pending submission for the package flight. For more information, see the [Submission](#submission_object) section below.  |    
| groupIds           | array  | An array of strings that contain the IDs of the flight groups that are associated with the package flight. For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).   |
| rankHigherThan           | string  | The friendly name of the package flight that is ranked immediately lower than the current package flight. For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).  |


<span id="submission_object" />
### Submission

This resource provides information about a submission. The following example demonstrates the format of this resource.

```json
{
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9WZDNCRD9MMD/submissions/1152921504621243487"
  }
}
```

This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | The ID of the submission.    |
| resourceLocation   | string  | A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the submission.                                                                                                                                               |
 
<span/>

## Related topics

* [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md)
* [Manage app submissions using the Windows Store submission API](manage-app-submissions.md)
* [Get all apps](get-all-apps.md)
* [Get an app](get-an-app.md)
* [Get add-ons for an app](get-add-ons-for-an-app.md)
* [Get package flights for an app](get-flights-for-an-app.md)
