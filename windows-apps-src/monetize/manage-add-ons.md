---
author: mcleanbyron
ms.assetid: 4F9657E5-1AF8-45E0-9617-45AF64E144FC
description: Use these methods in the Windows Store submission API to manage add-ons for apps that are registered to your Windows Dev Center account.
title: Manage add-ons using the Windows Store submission API
---

# Manage add-ons using the Windows Store submission API




Use the following methods in the Windows Store submission API to manage add-ons (also known as in-app products or IAPs) for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled. These methods can only be used to get, create, or delete add-ons. To create submissions for add-ons, see the methods in [Manage add-on submissions](manage-add-on-submissions.md).

| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` | Gets data for all add-ons for all the apps that are registered to your Windows Dev Center account. For more information, see [Get all add-ons](get-all-add-ons.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId} ``` | Gets data for a specific add-on. For more information, see [Get an add-on](get-an-add-on.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` | Creates a new add-on. For more information, see [Create an add-on](create-an-add-on.md).  |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` | Deletes an add-on. For more information, see [Delete an add-on](delete-an-add-on.md). |

## Prerequisites

If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API before trying to use any of these methods.

## Resources

These methods use the following resources to format data.

<span id="add-on-object" />
### Add-on

This resource represents an add-on. The following example demonstrates the format of this resource.

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
  "id": "9NBLGGH4TNMP",
  "productId": "TestAddOn",
  "productType": "Durable",
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
  "lastPublishedInAppProductSubmission": {
    "id": "1152921504621243705",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243705"
  }
}
```

This resource has the following values.

| Value      | Type   | Description                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| applications      | array  | An array that contains an object that represents the app that this add-on is associated with. For more information about the data in this object, see the [Application object](#application-object) section below. Only one item is supported in this array.  |
| id | string  | The Store ID of the add-on. This value is supplied by the Store. An example Store ID is 9NBLGGH4TNMP.  |
| productId | string  | The product ID of the add-on. This is the ID that was provided by the developer when the add-on was created. For more information, see [Set your product type and product ID](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id). |
| productType | string  | The product type of the add-on. The following values are supported: **Durable** and **Consumable**.  |
| lastPublishedInAppProductSubmission       | object | An object that provides information about the last published submission for the add-on. For more information, see the [Submission](#submission-object) section below.                                                                                                                                                          |
| pendingInAppProductSubmission        | object  |  An object that provides information about the current pending submission for the add-on. For more information, see the [Submission](#submission-object) section below.  |   |

<span id="application-object" />
### Application

This resource represents an app that an add-on is associated with. The following example demonstrates the format of this resource.

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
}
```

This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|-----------|
| value            | object  |  An object that contains the following values: <br/><br/> <ul><li>*id*. The Store ID of the app. For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</li><li>*resourceLocation*. A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the app.</li></ul>   |
| totalCount   | int  | The number of app objects in the *applications* array of the response body.                                                                                                                                                 |

<span id="submission-object" />
### Submission

This resource provides information about a submission for an add-on. The following example demonstrates the format of this resource.

```json
{
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
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
* [Manage add-on submissions using the Windows Store submission API](manage-add-on-submissions.md)
* [Get all add-ons](get-all-add-ons.md)
* [Get an add-on](get-an-add-on.md)
* [Create an add-on](create-an-add-on.md)
* [Delete an add-on](delete-an-add-on.md)
