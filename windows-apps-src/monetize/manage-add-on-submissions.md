---
author: mcleanbyron
ms.assetid: 66400066-24BF-4AF2-B52A-577F5C3CA474
description: Use these methods in the Windows Store submission API to manage add-on submissions for apps that are registered to your Windows Dev Center account.
title: Manage add-on submissions using the Windows Store submission API
---

# Manage add-on submissions using the Windows Store submission API



Use the following methods in the Windows Store submission API to manage add-on (also known as in-app product or IAP) submissions for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, including prerequisites for using the API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled. Before you can use these methods to create or manage submissions for an add-on, the add-on must already exist in your Dev Center account. You can create an add-on by [using the Dev Center dashboard](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions) or by using the Windows Store submission API methods in described in [Manage add-ons](manage-add-ons.md).

| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | Gets data for an existing add-on submission. For more information, see [Get an add-on submission](get-an-add-on-submission.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status``` | Gets the status of an existing add-on submission. For more information, see [Get the status of an add-on submission](get-status-for-an-add-on-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions``` | Creates a new add-on submission for an app that is registered to your Windows Dev Center account. For more information, see [Create an add-on submission](create-an-add-on-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit``` | Commits a new or updated add-on submission to Windows Dev Center. For more information, see [Commit an add-on submission](commit-an-add-on-submission.md). |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | Updates an existing add-on submission. For more information, see [Update an add-on submission](update-an-add-on-submission.md). |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | Deletes an add-on submission. For more information, see [Delete an add-on submission](delete-an-add-on-submission.md). |

<span id="create-an-add-on-submission">
## Create an add-on submission

To create a submission for an add-on, follow this process.

1. If you have not yet done so, complete the prerequisites described in [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md), including associating an Azure AD application with your Windows Dev Center account and obtaining your client ID and key. You only need to do this one time; after you have the client ID and key, you can reuse them any time you need to create a new Azure AD access token.  

2. [Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token). You must pass this access token to the methods in the Windows Store submission API. After you obtain an access token, you have 60 minutes to use it before it expires. After the token expires, you can obtain a new one.

3. Execute the following method in the Windows Store submission API. This method creates a new in-progress submission, which is a copy of your last published submission. For more information, see [Create an add-on submission](create-an-add-on-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions
  ```

  The response body contains three items: the ID of the new submission, the data for the new submission (including all the listings and pricing information), and the shared access signature (SAS) URI for uploading any add-on icons for the submission. For more information about SAS, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/).

4. If you are adding new icons for the submission, [prepare the icons](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon) and add them to a ZIP archive.

5. Update the submission data with any required changes for the new submission, and execute the following method to update the submission. For more information, see [Update an add-on submission](update-an-add-on-submission.md).

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}
  ```

  >**Note**&nbsp;&nbsp;If you are adding new icons for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.

4. If you are adding new icons for the submission, upload the ZIP archive to the SAS URI that was provided in the response body of the POST method you called in step 2. For more information, see [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).

  The following code snippet demonstrates how to upload the archive using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. Commit the submission by executing the following method. This will alert Dev Center that you are done with your submission and that your updates should now be applied to your account. For more information, see [Commit an add-on submission](commit-an-add-on-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit
  ```

6. Check on the commit status by executing the following method. For more information, see [Get the status of an add-on submission](get-status-for-an-add-on-submission.md).

  ```
  GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status
  ```

  To confirm the submission status, review the *status* value in the response body. This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request. If there are errors, the *statusDetails* field contains further details about the error.

7. After the commit has successfully completed, the submission is sent to the Store for ingestion. You can continue to monitor the submission progress by using the previous method, or by visiting the Dev Center dashboard.

## Resources

These methods use the following resources to format data.

<span id="add-on-submission-object" />
### Add-on submission

This resource represents a submission for an add-on. The following example demonstrates the format of this resource.

```json
{
  "id": "1152921504621243680",
  "contentType": "EMagazine",
  "keywords": [
    "books"
  ],
  "lifetime": "FiveDays",
  "listings": {
    "en": {
      "description": "English add-on description",
      "icon": {
        "fileName": "add-on-en-us-listing2.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (English)"
    },
    "ru": {
      "description": "Russian add-on description",
      "icon": {
        "fileName": "add-on-ru-listing.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (Russian)"
    }
  },
  "pricing": {
    "marketSpecificPricings": {
      "RU": "Tier3",
      "US": "Tier4",
    },
    "sales": [
      {
         "name": "Sale1",
         "basePriceId": "Free",
         "startDate": "2016-05-21T18:40:11.7369008Z",
         "endDate": "2016-05-22T18:40:11.7369008Z",
         "marketSpecificPricings": {
            "RU": "NotAvailable"
         }
      }
    ],
    "priceId": "Free"
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [
      {
        "code": "None",
        "details": "string"
      }
    ],
    "warnings": [
      {
        "code": "ListingOptOutWarning",
        "details": "You have removed listing language(s): []"
      }
    ],
    "certificationReports": [
      {
      }
    ]
  },

    "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl",
    "friendlyName": "Submission 2"
}
```

This resource has the following values.

| Value      | Type   | Description                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | The ID of the submission.  |
| contentType           | string  |  The [type of content](https://msdn.microsoft.com/windows/uwp/publish/enter-iap-properties#content-type) that is provided in the add-on. This can be one of the following values: <ul><li>NotSet</li><li>BookDownload</li><li>EMagazine</li><li>ENewspaper</li><li>MusicDownload</li><li>MusicStream</li><li>OnlineDataStorage</li><li>VideoDownload</li><li>VideoStream</li><li>Asp</li><li>OnlineDownload</li></ul> |  
| keywords           | array  | An array of strings that contain up to 10 [keywords](../publish/enter-iap-properties.md#keywords) for the add-on. Your app can query for add-ons using these keywords.   |
| lifetime           | string  |  The lifetime of the add-on. This can be one of the following values: <ul><li>Forever</li><li>OneDay</li><li>ThreeDays</li><li>FiveDays</li><li>OneWeek</li><li>TwoWeeks</li><li>OneMonth</li><li>TwoMonths</li><li>ThreeMonths</li><li>SixMonths</li><li>OneYear</li></ul> |
| listings           | object  |  A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [Listing resource](#listing-object) object that contains listing info for the add-on.  |
| pricing           | object  | An object that contains pricing info for the add-on. For more information, see the [Pricing resource](#pricing-object) section below.  |
| targetPublishMode           | string  | The publish mode for the submission. This can be one of the following values: <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.  |
| tag           | string  |  The [tag](../publish/enter-iap-properties.md#tag) for the add-on.   |
| visibility  | string  |  The visibility of the add-on. This can be one of the following values: <ul><li>Hidden</li><li>Public</li><li>Private</li><li>NotSet</li></ul>  |
| status  | string  |  The status of the submission. This can be one of the following values: <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  Contains additional details about the status of the submission, including information about any errors. For more information, see the [Status details](#status-details-object) section below. |
| fileUploadUrl           | string  | The shared access signature (SAS) URI for uploading any packages for the submission. If you are adding new packages for the submission, upload the ZIP archive that contains the packages to this URI. For more information, see [Create an add-on submission](#create-an-add-on-submission).  |
| friendlyName  | string  |  The friendly name of the add-on, used for display purposes.  |

<span id="listing-object" />
### Listing

This resource contains listing info for an add-on. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  description               |    string     |   The description for the add-on listing.   |     
|  icon               |   object      |  Contains data for the icon for the add-on listing. For more information, see the [Icon](#icon-object) section below.   |
|  title               |     string    |   The title for the add-on listing.   |  

<span id="icon-object" />
### Icon

This resource contains icon data for an add-on listing. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  fileName               |    string     |   The name of the icon file in the ZIP archive that you uploaded for the submission.    |     
|  fileStatus               |   string      |  The status of the icon file. This can be one of the following values: <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>   |

<span id="pricing-object" />
### Pricing

This resource contains pricing info for the add-on. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  marketSpecificPricings               |    object     |  A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers). These items represent the [custom prices for your add-on in specific markets](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-prices). Any items in this dictionary override the base price specified by the *priceId* value for the specified market.     |     
|  sales               |   array      |  An array of objects that contain sales information for the add-on. For more information, see the [Sale](#sale-object) section below.    |     
|  priceId               |   string      |  A [price tier](#price-tier) that specifies the [base price](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#base-price) for the add-on.    |


<span id="sale-object" />
### Sale

This resources contains sale info for an add-on. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  name               |    string     |   The name of the sale.    |     
|  basePriceId               |   string      |  The [price tier](#price-tiers) to use for the base price of the sale.    |     
|  startDate               |   string      |   The start date for the sale in ISO 8601 format.  |     
|  endDate               |   string      |  The end date for the sale in ISO 8601 format.      |     
|  marketSpecificPricings               |   object      |   A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers). These items represent the [custom prices for your add-on in specific markets](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-pricess). Any items in this dictionary override the base price specified by the *basePriceId* value for the specified market.    |



<span id="status-details-object" />
### Status details

This resource contains additional details about the status of a submission. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  errors               |    object     |   An array of objects that contain error details for the submission. For more information, see the [Status detail](#status-detail-object) section below.   |     
|  warnings               |   object      | An array of objects that contain warning details for the submission. For more information, see the [Status detail](#status-detail-object) section below.     |
|  certificationReports               |     object    |   An array of objects that provide access to the certification report data for the submission. You can examine these reports for more information if the certification fails. For more information, see the [Certification report](#certification-report-object) section below.   |  


<span id="status-detail-object" />
### Status detail

This resource contains additional information about any related errors or warnings for a submission. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  code               |    string     |   A string that describes the type of error or warning. For more information, see the [Submission status code](#submission-status-code) section below.   |     
|  details               |     string    |  A message with more details about the issue.     |


<span id="certification-report-object" />
### Certification report

This resource provides access to the certification report data for a submission. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|     date            |    string     |  The date and time the report was generated, in in ISO 8601 format.    |
|     reportUrl            |    string     |  The URL at which you can access the report.    |



## Enums

These methods use the following enums.


<span id="price-tiers" />
### Price tiers

The following values represent available price tiers for an add-on submission.

| Value           | Description                                                                                                                                                                                                                          |
|-----------------|------|
|  Base               |   The price tier is not set; use the base price for the add-on.      |     
|  NotAvailable              |   The add-on is not available in the specified region.    |     
|  Free              |   The add-on is free.    |    
|  Tier2 through Tier194               |   Tier2 represents the .99 USD price tier. Each additional tier represents additional increments (1.29 USD, 1.49 USD, 1.99 USD, and so on).    |


<span id="submission-status-code" />
### Submission status code

The following values represent the status code of a submission.

| Value           |  Description      |
|-----------------|---------------|
|  None            |     No code was specified.         |     
|      InvalidArchive        |     The ZIP archive containing the package is invalid or has an unrecognized archive format.  |
| MissingFiles | The ZIP archive does not have all files which were listed in your submission data, or they are in the wrong location in the archive. |
| PackageValidationFailed | One or more packages in your submission failed to validate. |
| InvalidParameterValue | One of the parameters in the request body is invalid. |
| InvalidOperation | The operation you attempted is invalid. |
| InvalidState | The operation you attempted is not valid for the current state of the package flight. |
| ResourceNotFound | The specified package flight could not be found. |
| ServiceError | An internal service error prevented the request from succeeding. Try the request again. |
| ListingOptOutWarning | The developer removed a listing from a previous submission, or did not include listing information that is supported by the package. |
| ListingOptInWarning  | The developer added a listing. |
| UpdateOnlyWarning | The developer is trying to insert something that only has update support. |
| Other  | The submission is in an unrecognized or uncategorized state. |
| PackageValidationWarning | The package validation process resulted in a warning. |

<span/>

## Related topics

* [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md)
* [Manage add-ons using the Windows Store submission API](manage-add-ons.md)
* [Add-on submissions in the Dev Center dashboard](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)
