---
author: Xansky
ms.assetid: D34447FF-21D2-44D0-92B0-B3FF9B32D6F7
description: Windows デベロッパー センター アカウントに登録されているアプリの新しい申請を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の作成
ms.author: mhopkins
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請の作成
ms.localizationpriority: medium
ms.openlocfilehash: 02aa06359f4f15d8763d75d0ab5381ce890ede4a
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5409572"
---
# <a name="create-an-app-submission"></a><span data-ttu-id="6f2f9-104">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="6f2f9-104">Create an app submission</span></span>

<span data-ttu-id="6f2f9-105">Windows デベロッパー センター アカウントに登録されているアプリの新しい申請を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-105">Use this method in the Microsoft Store submission API to create a new submission for an app that is registered to your Windows Dev Center account.</span></span> <span data-ttu-id="6f2f9-106">このメソッドを使って新しい申請を正常に作成したら、[申請を更新](update-an-app-submission.md)して申請データに必要な変更を加え、取り込んで公開するために[申請をコミット](commit-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-106">After you successfully create a new submission by using this method, [update the submission](update-an-app-submission.md) to make any necessary changes to the submission data, and then [commit the submission](commit-an-app-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="6f2f9-107">このメソッドが Microsoft Store 申請 API を使ったアプリの申請の作成プロセスにどのように適合するかについては、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-107">For more information about how this method fits into the process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>


## <a name="prerequisites"></a><span data-ttu-id="6f2f9-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="6f2f9-108">Prerequisites</span></span>

<span data-ttu-id="6f2f9-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="6f2f9-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="6f2f9-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="6f2f9-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="6f2f9-113">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="6f2f9-114">[年齢区分](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)の情報を含む 1 つ以上の申請がアプリで既に完了していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-114">Make sure the app already has at least one submission with the [age ratings](https://msdn.microsoft.com/windows/uwp/publish/age-ratings) information completed.</span></span>

## <a name="request"></a><span data-ttu-id="6f2f9-115">要求</span><span class="sxs-lookup"><span data-stu-id="6f2f9-115">Request</span></span>

<span data-ttu-id="6f2f9-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-116">This method has the following syntax.</span></span> <span data-ttu-id="6f2f9-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="6f2f9-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="6f2f9-118">Method</span></span> | <span data-ttu-id="6f2f9-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="6f2f9-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="6f2f9-120">POST</span><span class="sxs-lookup"><span data-stu-id="6f2f9-120">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions``` |


### <a name="request-header"></a><span data-ttu-id="6f2f9-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f2f9-121">Request header</span></span>

| <span data-ttu-id="6f2f9-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6f2f9-122">Header</span></span>        | <span data-ttu-id="6f2f9-123">型</span><span class="sxs-lookup"><span data-stu-id="6f2f9-123">Type</span></span>   | <span data-ttu-id="6f2f9-124">説明</span><span class="sxs-lookup"><span data-stu-id="6f2f9-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="6f2f9-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="6f2f9-125">Authorization</span></span> | <span data-ttu-id="6f2f9-126">string</span><span class="sxs-lookup"><span data-stu-id="6f2f9-126">string</span></span> | <span data-ttu-id="6f2f9-127">必須。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-127">Required.</span></span> <span data-ttu-id="6f2f9-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="6f2f9-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="6f2f9-129">Request parameters</span></span>

| <span data-ttu-id="6f2f9-130">名前</span><span class="sxs-lookup"><span data-stu-id="6f2f9-130">Name</span></span>        | <span data-ttu-id="6f2f9-131">種類</span><span class="sxs-lookup"><span data-stu-id="6f2f9-131">Type</span></span>   | <span data-ttu-id="6f2f9-132">説明</span><span class="sxs-lookup"><span data-stu-id="6f2f9-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="6f2f9-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="6f2f9-133">applicationId</span></span> | <span data-ttu-id="6f2f9-134">string</span><span class="sxs-lookup"><span data-stu-id="6f2f9-134">string</span></span> | <span data-ttu-id="6f2f9-135">必須。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-135">Required.</span></span> <span data-ttu-id="6f2f9-136">申請を作成するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-136">The Store ID of the app for which you want to create a submission.</span></span> <span data-ttu-id="6f2f9-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |


### <a name="request-body"></a><span data-ttu-id="6f2f9-138">要求本文</span><span class="sxs-lookup"><span data-stu-id="6f2f9-138">Request body</span></span>

<span data-ttu-id="6f2f9-139">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-139">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="6f2f9-140">要求の例</span><span class="sxs-lookup"><span data-stu-id="6f2f9-140">Request example</span></span>

<span data-ttu-id="6f2f9-141">次の例は、アプリの新しい申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-141">The following example demonstrates how to create a new submission for an app.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="6f2f9-142">応答</span><span class="sxs-lookup"><span data-stu-id="6f2f9-142">Response</span></span>

<span data-ttu-id="6f2f9-143">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-143">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="6f2f9-144">応答本文には、新しい申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-144">The response body contains information about the new submission.</span></span> <span data-ttu-id="6f2f9-145">応答本文内の値について詳しくは、[アプリの申請のリソース](manage-app-submissions.md#app-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-145">For more details about the values in the response body, see [App submission resource](manage-app-submissions.md#app-submission-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="6f2f9-146">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6f2f9-146">Error codes</span></span>

<span data-ttu-id="6f2f9-147">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-147">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="6f2f9-148">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6f2f9-148">Error code</span></span> |  <span data-ttu-id="6f2f9-149">説明</span><span class="sxs-lookup"><span data-stu-id="6f2f9-149">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="6f2f9-150">400</span><span class="sxs-lookup"><span data-stu-id="6f2f9-150">400</span></span>  | <span data-ttu-id="6f2f9-151">要求が無効なため、申請を作成できませんでした。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-151">The submission could not be created because the request is invalid.</span></span> |
| <span data-ttu-id="6f2f9-152">409</span><span class="sxs-lookup"><span data-stu-id="6f2f9-152">409</span></span>  | <span data-ttu-id="6f2f9-153">アプリの現在の状態が原因で申請を作成できませんでした。または、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="6f2f9-153">The submission could not be created because of the current state of the app, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="6f2f9-154">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6f2f9-154">Related topics</span></span>

* [<span data-ttu-id="6f2f9-155">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="6f2f9-155">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="6f2f9-156">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="6f2f9-156">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="6f2f9-157">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="6f2f9-157">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="6f2f9-158">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="6f2f9-158">Update an app submission</span></span>](update-an-app-submission.md)
* [<span data-ttu-id="6f2f9-159">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="6f2f9-159">Delete an app submission</span></span>](delete-an-app-submission.md)
* [<span data-ttu-id="6f2f9-160">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="6f2f9-160">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
