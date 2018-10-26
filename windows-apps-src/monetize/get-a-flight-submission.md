---
author: Xansky
ms.assetid: A0DFF26B-FE06-459B-ABDC-3EA4FEB7A21E
description: 既存のパッケージ フライトの申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請
ms.localizationpriority: medium
ms.openlocfilehash: 1a1c1e60a722fbba6f2a5c13e75078a11932b84e
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5557313"
---
# <a name="get-a-package-flight-submission"></a><span data-ttu-id="45b30-104">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="45b30-104">Get a package flight submission</span></span>

<span data-ttu-id="45b30-105">既存のパッケージ フライトの申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="45b30-105">Use this method in the Microsoft Store submission API to get data for an existing package flight submission.</span></span> <span data-ttu-id="45b30-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45b30-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="45b30-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="45b30-107">Prerequisites</span></span>

<span data-ttu-id="45b30-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="45b30-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="45b30-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="45b30-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="45b30-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="45b30-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="45b30-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="45b30-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="45b30-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="45b30-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="45b30-113">デベロッパー センターのアカウントでアプリのパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="45b30-113">Create a package flight submission for an app in your Dev Center account.</span></span> <span data-ttu-id="45b30-114">これは、デベロッパー センターのダッシュボードで行うことも、[パッケージ フライトの申請の作成](create-a-flight-submission.md)メソッドを使って行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="45b30-114">You can do this in the Dev Center dashboard, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="45b30-115">要求</span><span class="sxs-lookup"><span data-stu-id="45b30-115">Request</span></span>

<span data-ttu-id="45b30-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="45b30-116">This method has the following syntax.</span></span> <span data-ttu-id="45b30-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45b30-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="45b30-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="45b30-118">Method</span></span> | <span data-ttu-id="45b30-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="45b30-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="45b30-120">GET</span><span class="sxs-lookup"><span data-stu-id="45b30-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions{submissionId}``` |


### <a name="request-header"></a><span data-ttu-id="45b30-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="45b30-121">Request header</span></span>

| <span data-ttu-id="45b30-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="45b30-122">Header</span></span>        | <span data-ttu-id="45b30-123">型</span><span class="sxs-lookup"><span data-stu-id="45b30-123">Type</span></span>   | <span data-ttu-id="45b30-124">説明</span><span class="sxs-lookup"><span data-stu-id="45b30-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="45b30-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="45b30-125">Authorization</span></span> | <span data-ttu-id="45b30-126">string</span><span class="sxs-lookup"><span data-stu-id="45b30-126">string</span></span> | <span data-ttu-id="45b30-127">必須。</span><span class="sxs-lookup"><span data-stu-id="45b30-127">Required.</span></span> <span data-ttu-id="45b30-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="45b30-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="45b30-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="45b30-129">Request parameters</span></span>

| <span data-ttu-id="45b30-130">名前</span><span class="sxs-lookup"><span data-stu-id="45b30-130">Name</span></span>        | <span data-ttu-id="45b30-131">種類</span><span class="sxs-lookup"><span data-stu-id="45b30-131">Type</span></span>   | <span data-ttu-id="45b30-132">説明</span><span class="sxs-lookup"><span data-stu-id="45b30-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="45b30-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="45b30-133">applicationId</span></span> | <span data-ttu-id="45b30-134">string</span><span class="sxs-lookup"><span data-stu-id="45b30-134">string</span></span> | <span data-ttu-id="45b30-135">必須。</span><span class="sxs-lookup"><span data-stu-id="45b30-135">Required.</span></span> <span data-ttu-id="45b30-136">取得するパッケージ フライトの申請が含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="45b30-136">The Store ID of the app that contains the package flight submission you want to get.</span></span> <span data-ttu-id="45b30-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45b30-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="45b30-138">flightId</span><span class="sxs-lookup"><span data-stu-id="45b30-138">flightId</span></span> | <span data-ttu-id="45b30-139">string</span><span class="sxs-lookup"><span data-stu-id="45b30-139">string</span></span> | <span data-ttu-id="45b30-140">必須。</span><span class="sxs-lookup"><span data-stu-id="45b30-140">Required.</span></span> <span data-ttu-id="45b30-141">取得する申請が含まれるパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="45b30-141">The ID of the package flight that contains the submission you want to get.</span></span> <span data-ttu-id="45b30-142">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="45b30-142">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="45b30-143">デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="45b30-143">For a flight that was created in the Dev Center dashboard, this ID is also available in the URL for the flight page in the dashboard.</span></span>  |
| <span data-ttu-id="45b30-144">submissionId</span><span class="sxs-lookup"><span data-stu-id="45b30-144">submissionId</span></span> | <span data-ttu-id="45b30-145">string</span><span class="sxs-lookup"><span data-stu-id="45b30-145">string</span></span> | <span data-ttu-id="45b30-146">必須。</span><span class="sxs-lookup"><span data-stu-id="45b30-146">Required.</span></span> <span data-ttu-id="45b30-147">取得する申請の ID。</span><span class="sxs-lookup"><span data-stu-id="45b30-147">The ID of the submission to get.</span></span> <span data-ttu-id="45b30-148">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="45b30-148">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="45b30-149">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="45b30-149">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="45b30-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="45b30-150">Request body</span></span>

<span data-ttu-id="45b30-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="45b30-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="45b30-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="45b30-152">Request example</span></span>

<span data-ttu-id="45b30-153">次の例では、9WZDNCRD91MD というストア ID を持つアプリのパッケージ フライトの申請の取得方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="45b30-153">The following example demonstrates how to get a package flight submission for an app that has the Store ID 9WZDNCRD91MD.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="45b30-154">応答</span><span class="sxs-lookup"><span data-stu-id="45b30-154">Response</span></span>

<span data-ttu-id="45b30-155">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="45b30-155">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="45b30-156">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="45b30-156">The response body contains information about the specified submission.</span></span> <span data-ttu-id="45b30-157">応答本文の値について詳しくは、「[パッケージ フライトの申請のリソース](manage-flight-submissions.md#flight-submission-object)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="45b30-157">For more details about the values in the response body, see [Package flight submission resource](manage-flight-submissions.md#flight-submission-object).</span></span>

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
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

## <a name="error-codes"></a><span data-ttu-id="45b30-158">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45b30-158">Error codes</span></span>

<span data-ttu-id="45b30-159">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="45b30-159">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="45b30-160">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45b30-160">Error code</span></span> |  <span data-ttu-id="45b30-161">説明</span><span class="sxs-lookup"><span data-stu-id="45b30-161">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="45b30-162">404</span><span class="sxs-lookup"><span data-stu-id="45b30-162">404</span></span>  | <span data-ttu-id="45b30-163">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="45b30-163">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="45b30-164">409</span><span class="sxs-lookup"><span data-stu-id="45b30-164">409</span></span>  | <span data-ttu-id="45b30-165">指定されたパッケージ フライトにパッケージ フライトの申請が属していないか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能をアプリが使用しています。</span><span class="sxs-lookup"><span data-stu-id="45b30-165">The package flight submission does not belong to the specified package flight, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="45b30-166">関連トピック</span><span class="sxs-lookup"><span data-stu-id="45b30-166">Related topics</span></span>

* [<span data-ttu-id="45b30-167">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="45b30-167">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="45b30-168">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="45b30-168">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="45b30-169">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="45b30-169">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="45b30-170">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="45b30-170">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="45b30-171">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="45b30-171">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="45b30-172">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="45b30-172">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
