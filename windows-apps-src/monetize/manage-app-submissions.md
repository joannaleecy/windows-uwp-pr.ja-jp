---
author: mcleanbyron
ms.assetid: C7428551-4B31-4259-93CD-EE229007C4B8
description: Use these methods in the Windows Store submission API to manage submissions for apps that are registered to your Windows Dev Center account.
title: Manage app submissions using the Windows Store submission API
---

# Manage app submissions using the Windows Store submission API




Use the following methods in the Windows Store submission API to manage submissions for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, including prerequisites for using the API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled.


| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | Gets data for an existing app submission. For more information, see [Get an app submission](get-an-app-submission.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status``` | Gets the status of an existing app submission. For more information, see [Get the status of an app submission](get-status-for-an-app-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions``` | Creates a new submission for an app that is registered to your Windows Dev Center account. For more information, see [Create an app submission](create-an-app-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/commit``` | Commits a new or updated app submission to Windows Dev Center. For more information, see [Commit an app submission](commit-an-app-submission.md). |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | Updates an existing app submission. For more information, see [Update an app submission](update-an-app-submission.md). |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | Deletes an app submission. For more information, see [Delete an app submission](delete-an-app-submission.md). |

<span id="create-an-app-submission">
## Create an app submission

To create a submission for an app, follow this process.

1. If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.

  >**Note**&nbsp;&nbsp;Make sure the app already has at least one completed submission with the [age ratings](https://msdn.microsoft.com/windows/uwp/publish/age-ratings) information completed.

3. [Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token). You must pass this access token to the methods in the Windows Store submission API. After you obtain an access token, you have 60 minutes to use it before it expires. After the token expires, you can obtain a new one.

4. Execute the following method in the Windows Store submission API. This method creates a new in-progress submission, which is a copy of your last published submission. For more information, see [Create an app submission](create-an-app-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions
  ```

  The response body contains three items: the ID of the new submission, the data for the new submission (including all the listings and pricing information), and the shared access signature (SAS) URI for uploading any app packages and listing images for the submission. For more information about SAS, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/).

3. If you are adding new packages or images for the submission, [prepare the app packages](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements) and [prepare the app screenshots and images](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images). Add all of these files to a ZIP archive.

4. Update the submission data with any required changes for the new submission, and execute the following method to update the submission. For more information, see [Update an app submission](update-an-app-submission.md).

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}
  ```

  >**Note**&nbsp;&nbsp;If you are adding new packages or images for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.

4. If you are adding new packages or images for the submission, upload the ZIP archive to the SAS URI that was provided in the response body of the POST method you called in step 2. For more information, see [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).

  The following code snippet demonstrates how to upload the archive using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. Commit the submission by executing the following method. This will alert Dev Center that you are done with your submission and that your updates should now be applied to your account. For more information, see [Commit an app submission](commit-an-app-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/commit
  ```

6. Check on the commit status by executing the following method. For more information, see [Get the status of an app submission](get-status-for-an-app-submission.md).

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status
    ```

    To confirm the submission status, review the *status* value in the response body. This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request. If there are errors, the *statusDetails* field contains further details about the error.

7. After the commit has successfully completed, the submission is sent to the Store for ingestion. You can continue to monitor the submission progress by using the previous method, or by visiting the Dev Center dashboard.

## Resources

These methods use the following resources to format data.

<span id="app-submission-object" />
### App submission

This resource represents a submission for an app. The following example demonstrates the format of this resource.

```json
{
  "id": "1152921504621243540",
  "applicationCategory": "BooksAndReference_EReader",
  "pricing": {
    "trialPeriod": "FifteenDays",
    "marketSpecificPricings": {},
    "sales": [],
    "priceId": "Tier2"
  },
  "visibility": "Public",
  "targetPublishMode": "Manual",
  "targetPublishDate": "1601-01-01T00:00:00Z",
  "listings": {
    "en-us": {
      "baseListing": {
        "copyrightAndTrademarkInfo": "",
        "keywords": [],
        "licenseTerms": "",
        "privacyPolicy": "",
        "supportContact": "",
        "websiteUrl": "",
        "description": "Description",
        "features": [],
        "releaseNotes": "",
        "images": [
          {
            "fileName": "contoso.png",
            "fileStatus": "Uploaded",
            "id": "1152921504672272757",
            "imageType": "Screenshot"
          }
        ],
        "recommendedHardware": [],
        "title": "ApiTestApp For Devbox"
      },
      "platformOverrides": {}
    }
  },
  "hardwarePreferences": [
    "Touch"
  ],
  "automaticBackupEnabled": false,
  "canInstallOnRemovableMedia": true,
  "isGameDvrEnabled": false,
  "hasExternalInAppProducts": false,
  "meetAccessibilityGuidelines": true,
  "notesForCertification": "",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/387a9ea8-a412-43a9-8fb3-a38d03eb483d?sv=2014-02-14&sr=b&sig=sdd12JmoaT6BhvC%2BZUrwRweA%2Fkvj%2BEBCY09C2SZZowg%3D&se=2016-06-17T18:32:26Z&sp=rwl",
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "Uploaded",
      "id": "1152921504620138797",
      "version": "1.0.0.0",
      "architecture": "ARM",
      "languages": [
        "en-US"
      ],
      "capabilities": [
        "ID_RESOLUTION_HD720P",
        "ID_RESOLUTION_WVGA",
        "ID_RESOLUTION_WXGA"
      ],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None",
      "targetDeviceFamilies": [
        "Windows.Mobile min version 10.0.10240.0"
      ]
    }
  ],
  "enterpriseLicensing": "Online",
  "allowMicrosoftDecideAppAvailabilityToFutureDeviceFamilies": true,
  "allowTargetFutureDeviceFamilies": {
    "Desktop": false,
    "Mobile": true,
    "Holographic": true,
    "Xbox": false,
    "Team": true
  },
  "friendlyName": "Submission 2"
}
```

This resource has the following values.

| Value      | Type   | Description                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | The ID of the submission.  |
| applicationCategory           | string  |   A string that specifies the [category and/or subcategory](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table) for your app. Categories and subcategories are combined into a single string with the underscore '_' character, such as **BooksAndReference_EReader**.      |  
| pricing           |  object  | An object that contains pricing info for the app. For more information, see the [Pricing resource](#pricing-object) section below.       |   
| visibility           |  string  |  The visibility of the app. This can be one of the following values: <ul><li>Hidden</li><li>Public</li><li>Private</li><li>NotSet</li></ul>       |   
| targetPublishMode           | string  | The publish mode for the submission. This can be one of the following values: <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.  |  
| listings           |   object  |  A dictionary of key and value pairs, where each key is a country code and each value is a [Listing resource](#listing-object) object that contains listing info for the app.       |   
| hardwarePreferences           |  array  |   An array of strings that define the [hardware preferences](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences) for your app. This can be one of the following values: <ul><li>Touch</li><li>Keyboard</li><li>Mouse</li><li>Camera</li><li>NfcHce</li><li>Nfc</li><li>BluetoothLE</li><li>Telephony</li></ul>     |   
| automaticBackupEnabled           |  boolean  |   Indicates whether Windows can include your app's data in automatic backups to OneDrive. For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).   |   
| canInstallOnRemovableMedia           |  boolean  |   Indicates whether customers can install your app to removable storage. For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).     |   
| isGameDvrEnabled           |  boolean |   Indicates whether game DVR is enabled for the app.    |   
| hasExternalInAppProducts           |     boolean          |   Indicates whether your app allows users to make purchase outside the Windows Store commerce system. For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).     |   
| meetAccessibilityGuidelines           |    boolean           |  Indicates whether your app has been tested to meet accessibility guidelines. For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).      |   
| notesForCertification           |  string  |   Contains [notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification) for your app.    |    
| status           |   string  |  The status of the submission. This can be one of the following values: <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>      |    
| statusDetails           |   object  |  Contains additional details about the status of the submission, including information about any errors. For more information, see the [Status details](#status-details-object) section below.       |    
| fileUploadUrl           |   string  | The shared access signature (SAS) URI for uploading any packages for the submission. If you are adding new packages or images for the submission, upload the ZIP archive that contains the packages and images to this URI. For more information, see [Create an app submission](#create-an-app-submission).       |    
| applicationPackages           |   array  | Contains objects that provide details about each package in the submission. For more information, see the [Application package](#application-package-object) section below. |    
| enterpriseLicensing           |  string  |  One of the [enterprise licensing values](#enterprise-licensing) values that indicate the enterprise licensing behavior for the app.  |    
| allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies           |  boolean   |  Indicates whether Microsoft is allowed to [make the app available to future Windows 10 device families](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families).    |    
| allowTargetFutureDeviceFamilies           | object   |  A dictionary of key and value pairs, where each key is a [Windows 10 device family](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families) and each value is a boolean that indicates whether your app is allowed to target the specified device family.     |    
| friendlyName           |   string  |  The friendly name of the app, used for display purposes.       |  


<span id="listing-object" />
### Listing

This resource contains listing info for an app. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  baseListing               |   object      |  The [base listing](#base-listing-object) info for the app, which defines the default listing info for all platforms.   |     
|  platformOverrides               | object |   A dictionary of key and value pairs, where each key is string that identifies a platform for which to override the listing info, and each value is a [base listing](#base-listing-object)  object (containing only the values from description to title) that specifies the listing info to override for the specified platform. The keys can have the following values: <ul><li>Unknown</li><li>Windows80</li><li>Windows81</li><li>WindowsPhone71</li><li>WindowsPhone80</li><li>WindowsPhone81</li></ul>     |      |     

<span id="base-listing-object" />
### Base listing

This resource contains base listing info for an app. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  copyrightAndTrademarkInfo                |   string      |  Optional [copyright and/or trademark info](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#copyright-and-trademark-info).  |
|  keywords                |  array       |  An array of [keyword](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#keywords) to help your app appear in search results.    |
|  licenseTerms                |    string     | The optional [license terms](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#additional-license-terms) for your app.     |
|  privacyPolicy                |   string      |   The URL for the [privacy policy](https://msdn.microsoft.com/windows/uwp/publish/privacy-policy) for your app.    |
|  supportContact                |   string      |  The URL or email address for the [support contact info](https://msdn.microsoft.com/windows/uwp/publish/support-contact-info) for your app.     |
|  websiteUrl                |   string      |  The URL of the [web page](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#website) for your app.    |    
|  description               |    string     |   The [description](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#description) for the app listing.   |     
|  features               |    array     |  An array of up to 20 strings that list the [features](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#app-features) for your app.     |
|  releaseNotes               |  string       |  The [release notes](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#release-notes) for your app.    |
|  images               |   array      |  An array of [image and icon](#image-object) data for the app listing.  |
|  recommendedHardware               |   array      |  An array of up to 11 strings that list the [recommended hardware configurations](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#recommended-hardware) for your app.     |
|  title               |     string    |   The title for the app listing.   |  


<span id="image-object" />
### Image

This resource contains image and icon data for an app listing. For more information about images and icons for listing, see [App screenshots and images](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images). This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  fileName               |    string     |   The name of the image file in the ZIP archive that you uploaded for the submission.    |     
|  fileStatus               |   string      |  The status of the image file. This can be one of the following values: <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>   |
|  id  |  string  | The ID for the image, as specified by Dev Center.  |
|  description  |  string  | The description for the image.  |
|  imageType  |  string  | One of the following strings that indicates the type of the image: <ul><li>Unknown</li><li>Screenshot</li><li>PromotionalArtwork414X180</li><li>PromotionalArtwork846X468</li><li>PromotionalArtwork558X756</li><li>PromotionalArtwork414X468</li><li>PromotionalArtwork558X558</li><li>PromotionalArtwork2400X1200</li><li>Icon</li><li>WideIcon358X173</li><li>BackgroundImage1000X800</li><li>SquareIcon358X358</li><li>MobileScreenshot</li><li>XboxScreenshot</li><li>SurfaceHubScreenshot</li><li>HoloLensScreenshot</li></ul>      |


<span id="pricing-object" />
### Pricing

This resource contains pricing info for the app. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  trialPeriod               |    string     |  A string that specifies the trial period for the app. This can be one of the following values: <ul><li>NoFreeTrial</li><li>OneDay</li><li>TrialNeverExpires</li><li>SevenDays</li><li>FifteenDays</li><li>ThirtyDays</li></ul>    |
|  marketSpecificPricings               |    object     |  A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers). These items represent the [custom prices for your app in specific markets](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#markets-and-custom-prices). Any items in this dictionary override the base price specified by the *priceId* value for the specified market.      |     
|  sales               |   array      |  An array of objects that contain sales information for the app. For more information, see the [Sale](#sale-object) section below.    |     
|  priceId               |   string      |  A [price tier](#price-tier) that specifies the [base price](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#base-price) for the app.   |


<span id="sale-object" />
### Sale

This resources contains sale info for an app. This resource has the following values.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  name               |    string     |   The name of the sale.    |     
|  basePriceId               |   string      |  The [price tier](#price-tiers) to use for the base price of the sale.    |     
|  startDate               |   string      |   The start date for the sale in ISO 8601 format.  |     
|  endDate               |   string      |  The end date for the sale in ISO 8601 format.      |     
|  marketSpecificPricings               |   object      |   A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers). These items represent the [custom prices for your app in specific markets](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#markets-and-custom-prices). Any items in this dictionary override the base price specified by the *basePriceId* value for the specified market.    |


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


<span id="application-package-object" />
### Application package

This resource contains details about an app package for the submission. The following example demonstrates the format of this resource.

```json
{
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "Uploaded",
      "id": "1152921504620138797",
      "version": "1.0.0.0",
      "architecture": "ARM",
      "languages": [
        "en-US"
      ],
      "capabilities": [
        "ID_RESOLUTION_HD720P",
        "ID_RESOLUTION_WVGA",
        "ID_RESOLUTION_WXGA"
      ],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None",
      "targetDeviceFamilies": [
        "Windows.Mobile min version 10.0.10240.0"
      ]
    }
  ],
}
```

This resource has the following values.  

>**Note**&nbsp;&nbsp;When calling the [update an app submission](update-an-app-submission.md) method, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of this object are required in the request body. The other values are populated by Dev Center.

| Value           | Type    | Description                   |
|-----------------|---------|------|
| fileName   |   string      |  The name of the package.    |  
| fileStatus    | string    |  The status of the package. This can be one of the following values: <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>    |  
| id    |  string   |  An ID that uniquely identifies the package. This value is used by Dev Center.   |     
| version    |  string   |  The version of the app package. For more information, see [Package version numbering](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering).   |   
| architecture    |  string   |  The architecture of the package (for example, ARM).   |     
| languages    | array    |  An array of language codes for the languages the app supports. For more information, see For more information, see [Supported languages](https://msdn.microsoft.com/windows/uwp/publish/supported-languages).    |     
| capabilities    |  array   |  An array of capabilities required by the package. For more information about capabilities, see [App capability declarations](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations).   |     
| minimumDirectXVersion    |  string   |  The minimum DirectX version that is supported by the app package. This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions. This can be one of the following values: <ul><li>None</li><li>DirectX93</li><li>DirectX100</li></ul>   |     
| minimumSystemRam    | string    |  The minimum RAM that is required by the app package. This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions. This can be one of the following values: <ul><li>None</li><li>Memory2GB</li></ul>   |       
| targetDeviceFamilies    | array    |  An array of strings that represent the device families that the package targets. This value is used only for packages that target Windows 10; for packages that target earlier releases, this value has the value **None**. The following device family strings are currently supported for Windows 10 packages, where *{0}* is a Windows 10 version string such as 10.0.10240.0, 10.0.10586.0 or 10.0.14393.0: <ul><li>Windows.Universal min version *{0}*</li><li>Windows.Desktop min version *{0}*</li><li>Windows.Mobile min version *{0}*</li><li>Windows.Xbox min version *{0}*</li><li>Windows.Holographic min version *{0}*</li></ul>   |    

<span/>

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

The following values represent available price tiers for an app submission.

| Value           | Description                                                                                                                                                                                                                          |
|-----------------|------|
|  Base               |   The price tier is not set; use the base price for the app.      |     
|  NotAvailable              |   The app is not available in the specified region.    |     
|  Free              |   The app is free.    |    
|  Tier2 through Tier194               |   Tier2 represents the .99 USD price tier. Each additional tier represents additional increments (1.29 USD, 1.49 USD, 1.99 USD, and so on).    |


<span id="enterprise-licensing" />
### Enterprise licensing values

The following values represent the enterprise licensing behavior for the app. For more information about these options, see [Organizational licensing options](https://msdn.microsoft.com/windows/uwp/publish/organizational-licensing).

| Value           |  Description      |
|-----------------|---------------|
| None            |     Do not make your app available to enterprises with Store-managed (online) volume licensing.         |     
| Online        |     Make your app available to enterprises with Store-managed (online) volume licensing.  |
| OnlineAndOffline | Make your app available to enterprises with Store-managed (online) volume licensing, and make your app available to enterprises via disconnected (offline) licensing. |


<span id="submission-status-code" />
### Submission status code

The following values represent the status code of a submission.

| Value           |  Description      |
|-----------------|---------------|
| None            |     No code was specified.         |     
| InvalidArchive        |     The ZIP archive containing the package is invalid or has an unrecognized archive format.  |
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
* [Get app data using the Windows Store submission API](get-app-data.md)
* [App submissions in the Dev Center dashboard](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)
