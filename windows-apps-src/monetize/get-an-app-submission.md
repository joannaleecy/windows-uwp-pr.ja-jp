---
author: Xansky
ms.assetid: BF296C25-A2E6-48E4-9D08-0CCDB5FAE0C8
description: 既存のアプリの申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請
ms.localizationpriority: medium
ms.openlocfilehash: 9838798778a2d66b2a52fcfe02defce0c9167d2d
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4954478"
---
# <a name="get-an-app-submission"></a><span data-ttu-id="c5d75-104">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="c5d75-104">Get an app submission</span></span>


<span data-ttu-id="c5d75-105">既存のアプリの申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="c5d75-105">Use this method in the Microsoft Store submission API to get data for an existing app submission.</span></span> <span data-ttu-id="c5d75-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5d75-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c5d75-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="c5d75-107">Prerequisites</span></span>

<span data-ttu-id="c5d75-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5d75-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c5d75-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c5d75-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="c5d75-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c5d75-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c5d75-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c5d75-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c5d75-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c5d75-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="c5d75-113">デベロッパー センターのアカウントでアプリの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="c5d75-113">Create a submission for an app in your Dev Center account.</span></span> <span data-ttu-id="c5d75-114">この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="c5d75-114">You can do this in the Dev Center dashboard, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="c5d75-115">要求</span><span class="sxs-lookup"><span data-stu-id="c5d75-115">Request</span></span>

<span data-ttu-id="c5d75-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c5d75-116">This method has the following syntax.</span></span> <span data-ttu-id="c5d75-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5d75-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="c5d75-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="c5d75-118">Method</span></span> | <span data-ttu-id="c5d75-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c5d75-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="c5d75-120">GET</span><span class="sxs-lookup"><span data-stu-id="c5d75-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId} ``` |


### <a name="request-header"></a><span data-ttu-id="c5d75-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c5d75-121">Request header</span></span>

| <span data-ttu-id="c5d75-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c5d75-122">Header</span></span>        | <span data-ttu-id="c5d75-123">型</span><span class="sxs-lookup"><span data-stu-id="c5d75-123">Type</span></span>   | <span data-ttu-id="c5d75-124">説明</span><span class="sxs-lookup"><span data-stu-id="c5d75-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c5d75-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="c5d75-125">Authorization</span></span> | <span data-ttu-id="c5d75-126">string</span><span class="sxs-lookup"><span data-stu-id="c5d75-126">string</span></span> | <span data-ttu-id="c5d75-127">必須。</span><span class="sxs-lookup"><span data-stu-id="c5d75-127">Required.</span></span> <span data-ttu-id="c5d75-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c5d75-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c5d75-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c5d75-129">Request parameters</span></span>

| <span data-ttu-id="c5d75-130">名前</span><span class="sxs-lookup"><span data-stu-id="c5d75-130">Name</span></span>        | <span data-ttu-id="c5d75-131">種類</span><span class="sxs-lookup"><span data-stu-id="c5d75-131">Type</span></span>   | <span data-ttu-id="c5d75-132">説明</span><span class="sxs-lookup"><span data-stu-id="c5d75-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c5d75-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="c5d75-133">applicationId</span></span> | <span data-ttu-id="c5d75-134">string</span><span class="sxs-lookup"><span data-stu-id="c5d75-134">string</span></span> | <span data-ttu-id="c5d75-135">必須。</span><span class="sxs-lookup"><span data-stu-id="c5d75-135">Required.</span></span> <span data-ttu-id="c5d75-136">取得する申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="c5d75-136">The Store ID of the app with the submission you want to get.</span></span> <span data-ttu-id="c5d75-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5d75-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="c5d75-138">submissionId</span><span class="sxs-lookup"><span data-stu-id="c5d75-138">submissionId</span></span> | <span data-ttu-id="c5d75-139">string</span><span class="sxs-lookup"><span data-stu-id="c5d75-139">string</span></span> | <span data-ttu-id="c5d75-140">必須。</span><span class="sxs-lookup"><span data-stu-id="c5d75-140">Required.</span></span> <span data-ttu-id="c5d75-141">取得する申請の ID。</span><span class="sxs-lookup"><span data-stu-id="c5d75-141">The ID of the submission to get.</span></span> <span data-ttu-id="c5d75-142">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="c5d75-142">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="c5d75-143">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="c5d75-143">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="c5d75-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="c5d75-144">Request body</span></span>

<span data-ttu-id="c5d75-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c5d75-145">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="c5d75-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="c5d75-146">Request example</span></span>

<span data-ttu-id="c5d75-147">次の例は、アプリの申請を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c5d75-147">The following example demonstrates how to get an app submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243680 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c5d75-148">応答</span><span class="sxs-lookup"><span data-stu-id="c5d75-148">Response</span></span>

<span data-ttu-id="c5d75-149">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="c5d75-149">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="c5d75-150">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c5d75-150">The response body contains information about the specified submission.</span></span> <span data-ttu-id="c5d75-151">応答本文内の値について詳しくは、[アプリの申請のリソース](manage-app-submissions.md#app-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5d75-151">For more details about the values in the response body, see [App submission resource](manage-app-submissions.md#app-submission-object).</span></span>

```json
{
  "id": "1152921504621243540",
  "applicationCategory": "BooksAndReference_EReader",
  "pricing": {
    "trialPeriod": "FifteenDays",
    "marketSpecificPricings": {},
    "sales": [],
    "priceId": "Tier2",
    "isAdvancedPricingModel": true
  },
  "visibility": "Public",
  "targetPublishMode": "Manual",
  "targetPublishDate": "1601-01-01T00:00:00Z",
  "listings": {
    "en-us": {
      "baseListing": {
        "copyrightAndTrademarkInfo": "",
        "keywords": [
           "epub"
        ],
        "licenseTerms": "",
        "privacyPolicy": "",
        "supportContact": "",
        "websiteUrl": "",
        "description": "Description",
        "features": [
          "Free ebook reader"
        ],
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
        "title": "Contoso ebook reader"
      },
      "platformOverrides": {
        "Windows81": {
          "description": "Ebook reader for Windows 8.1"
        }
      }
    }
  },
  "hardwarePreferences": [
    "Touch"
  ],
  "automaticBackupEnabled": false,
  "canInstallOnRemovableMedia": true,
  "isGameDvrEnabled": false,
  "gamingOptions": [],
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
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0.0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
  "enterpriseLicensing": "Online",
  "allowMicrosoftDecideAppAvailabilityToFutureDeviceFamilies": true,
  "allowTargetFutureDeviceFamilies": {
    "Desktop": false,
    "Mobile": true,
    "Holographic": true,
    "Xbox": false,
    "Team": true
  },
  "friendlyName": "Submission 2",
  "trailers": []
}
```

## <a name="error-codes"></a><span data-ttu-id="c5d75-152">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c5d75-152">Error codes</span></span>

<span data-ttu-id="c5d75-153">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="c5d75-153">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="c5d75-154">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c5d75-154">Error code</span></span> |  <span data-ttu-id="c5d75-155">説明</span><span class="sxs-lookup"><span data-stu-id="c5d75-155">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="c5d75-156">404</span><span class="sxs-lookup"><span data-stu-id="c5d75-156">404</span></span>  | <span data-ttu-id="c5d75-157">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c5d75-157">The submission could not be found.</span></span> |
| <span data-ttu-id="c5d75-158">409</span><span class="sxs-lookup"><span data-stu-id="c5d75-158">409</span></span>  | <span data-ttu-id="c5d75-159">指定されたアプリに申請が属していないか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能をアプリが使用しています。</span><span class="sxs-lookup"><span data-stu-id="c5d75-159">The submission does not belong to the specified app, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="c5d75-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c5d75-160">Related topics</span></span>

* [<span data-ttu-id="c5d75-161">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="c5d75-161">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="c5d75-162">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="c5d75-162">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="c5d75-163">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="c5d75-163">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="c5d75-164">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="c5d75-164">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="c5d75-165">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="c5d75-165">Delete an app submission</span></span>](delete-an-app-submission.md)
* [<span data-ttu-id="c5d75-166">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="c5d75-166">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
