---
author: mcleanbyron
ms.assetid: 2A454057-FF14-40D2-8ED2-CEB5F27E0226
description: Use these methods in the Windows Store submission API to manage package flight submissions for apps that are registered to your Windows Dev Center account.
title: Manage package flight submissions using the Windows Store submission API
---

# Manage package flight submissions using the Windows Store submission API




Use the following methods in the Windows Store submission API to manage package flight submissions for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, including prerequisites for using the API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled. Before you can use these methods to create or manage submissions for package flight, the package flight must already exist in your Dev Center account. You can create a package flight by [using the Dev Center dashboard](https://msdn.microsoft.com/windows/uwp/publish/package-flights) or by using the Windows Store submission API methods in described in [Manage package flights](manage-flights.md).

| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | Gets data for an existing package flight submission. For more information, see [Get a package flight submission](get-a-flight-submission.md). |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status``` | Gets the status of an existing package flight submission. For more information, see [Get the status of a package flight submission](get-status-for-a-flight-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/applications/{applicationId}/flights/{flightId}/submissions``` | Creates a new package flight submission for an app that is registered to your Windows Dev Center account. For more information, see [Create a package flight submission](create-a-flight-submission.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit``` | Commits a new or updated package flight submission to Windows Dev Center. For more information, see [Commit a package flight submission](commit-a-flight-submission.md). |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | Updates an existing package flight submission. For more information, see [Update a package flight submission](update-a-flight-submission.md). |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | Deletes a package flight submission. For more information, see [Delete a package flight submission](delete-a-flight-submission.md). |

<span id="create-a-package-flight-submission">
## Create a package flight submission

To create a submission for a package flight, follow this process.

1. If you have not yet done so, complete the prerequisites described in [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md), including associating an Azure AD application with your Windows Dev Center account and obtaining your client ID and key. You only need to do this one time; after you have the client ID and key, you can reuse them any time you need to create a new Azure AD access token.  

2. [Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token). You must pass this access token to the methods in the Windows Store submission API. After you obtain an access token, you have 60 minutes to use it before it expires. After the token expires, you can obtain a new one.

3. Execute the following method in the Windows Store submission API. This method creates a new in-progress submission, which is a copy of your last published submission. For more information, see [Create a package flight submission](create-a-flight-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications{applicationId}/flights/{flightId}/submissions
  ```

  The response body contains three items: the ID of the new submission, the data for the new submission (including all the listings and pricing information), and the shared access signature (SAS) URI for uploading any packages for the submission. For more information about SAS, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/).

4. If you are adding new packages for the submission, [prepare the packages](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements) and add them to a ZIP archive.

5. Update the submission data with any required changes for the new submission, and execute the following method to update the submission. For more information, see [Update a package flight submission](update-a-flight-submission.md).

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}
  ```

  >**Note**&nbsp;&nbsp;If you are adding new packages for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.

4. If you are adding new packages for the submission, upload the ZIP archive to the SAS URI that was provided in the response body of the POST method you called in step 2. For more information, see [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).

  The following code snippet demonstrates how to upload the archive using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. Commit the submission by executing the following method. This will alert Dev Center that you are done with your submission and that your updates should now be applied to your account. For more information, see [Commit a package flight submission](commit-a-flight-submission.md).

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit
  ```

6. Check on the commit status by executing the following method. For more information, see [Get the status of a package flight submission](get-status-for-a-flight-submission.md).

  ```
  GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status
  ```

  To confirm the submission status, review the *status* value in the response body. This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request. If there are errors, the *statusDetails* field contains further details about the error.

7. After the commit has successfully completed, the submission is sent to the Store for ingestion. You can continue to monitor the submission progress by using the previous method, or by visiting the Dev Center dashboard.

## Resources

These methods use the following data resources.

<span id="flight-submission-object" />
### Package flight submission

This resource represents a submission for a package flight. The following example demonstrates the format of this resource.

```json
{
  "id": "1152921504621243649",
  "flightId": "cd2e368a-0da5-4026-9f34-0e7934bc6f23",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

This resource has the following values.

| Value      | Type   | Description                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | The ID for the submission.  |
| flightId           | string  |  The ID of the package flight that the submission is associated with.  |  
| status           | string  | The status of the submission. This can be one of the following values: <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  Contains additional details about the status of the submission, including information about any errors. For more information, see the [Status details](#status-details-object) section below. |
| flightPackages           | array  | Contains objects that provide details about each package in the submission. For more information, see the [Flight package](#flight-package-object) section below.  |
| fileUploadUrl           | string  | The shared access signature (SAS) URI for uploading any packages for the submission. If you are adding new packages for the submission, upload the ZIP archive that contains the packages to this URI. For more information, see [Create a package flight submission](#create-a-package-flight-submission).  |
| targetPublishMode           | string  | The publish mode for the submission. This can be one of the following values: <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.  |
| notesForCertification           | string  |  Provides additional info for the certification testers, such as test account credentials and steps to access and verify features. For more information, see [Notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification). |

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


<span id="flight-package-object" />
### Flight package

This resource provides details about a package in a submission. The following example demonstrates the format of this resource.

```json
{
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
}
```

This resource has the following values.

>**Note**&nbsp;&nbsp;When calling the [update a package flight submission](update-a-flight-submission.md) method, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of this object are required in the request body. The other values are populated by Dev Center.

| Value           | Type    | Description                                                                                                                                                                                                                          |
|-----------------|---------|------|
| fileName   |   string      |  The name of the package.    |  
| fileStatus    | string    |  The status of the package. This can be one of the following values: <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>    |  
| id    |  string   |  An ID that uniquely identifies the package. This value is used by Dev Center.   |     
| version    |  string   |  The version of the app package. For more information, see [Package version numbering](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering).   |   
| architecture    |  string   |  The architecture of the app package (for example, ARM).   |     
| languages    | array    |  An array of language codes for the languages the app supports. For more information, see For more information, see [Supported languages](https://msdn.microsoft.com/windows/uwp/publish/supported-languages).    |     
| capabilities    |  array   |  An array of capabilities required by the package. For more information about capabilities, see [App capability declarations](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations).   |     
| minimumDirectXVersion    |  string   |  The minimum DirectX version that is supported by the app package. This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions. This can be one of the following values: <ul><li>None</li><li>DirectX93</li><li>DirectX100</li></ul>   |     
| minimumSystemRam    | string    |  The minimum RAM that is required by the app package. This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions. This can be one of the following values: <ul><li>None</li><li>Memory2GB</li></ul>   |    

<span/>

## Enums

These methods use the following enums.

<span id="submission-status-code" />
### Submission status code

The following codes represent the status of a submission.

| Code           |  Description      |
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
* [Manage package flights using the Windows Store submission API](manage-flights.md)
* [Get a package flight submission](get-a-flight-submission.md)
* [Create a package flight submission](create-a-flight-submission.md)
* [Update a package flight submission](update-a-flight-submission.md)
* [Commit a package flight submission](commit-a-flight-submission.md)
* [Delete a package flight submission](delete-a-flight-submission.md)
* [Get the status of a package flight submission](get-status-for-a-flight-submission.md)
