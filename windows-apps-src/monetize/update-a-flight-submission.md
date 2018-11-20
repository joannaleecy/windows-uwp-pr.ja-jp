---
author: Xansky
ms.assetid: 24C5F796-5FB8-4B5D-B428-C3154B3098BD
description: 既存のパッケージ フライトの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請の更新
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請, 更新
ms.localizationpriority: medium
ms.openlocfilehash: 670522e9842ca5e048777a1168caa1efbca6ce94
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419896"
---
# <a name="update-a-package-flight-submission"></a><span data-ttu-id="7c1b9-104">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="7c1b9-104">Update a package flight submission</span></span>


<span data-ttu-id="7c1b9-105">既存のパッケージ フライトの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-105">Use this method in the Microsoft Store submission API to update an existing package flight submission.</span></span> <span data-ttu-id="7c1b9-106">このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-a-flight-submission.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-106">After you successfully update a submission by using this method, you must [commit the submission](commit-a-flight-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="7c1b9-107">このメソッドが Microsoft Store 申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-107">For more information about how this method fits into the process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7c1b9-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="7c1b9-108">Prerequisites</span></span>

<span data-ttu-id="7c1b9-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="7c1b9-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="7c1b9-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="7c1b9-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7c1b9-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="7c1b9-114">アプリのいずれかのパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-114">Create a package flight submission for one of your apps.</span></span> <span data-ttu-id="7c1b9-115">パートナー センターで、これを行うか、[パッケージ フライトの申請を作成する](create-a-flight-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-115">You can do this in Partner Center, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="7c1b9-116">要求</span><span class="sxs-lookup"><span data-stu-id="7c1b9-116">Request</span></span>

<span data-ttu-id="7c1b9-117">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-117">This method has the following syntax.</span></span> <span data-ttu-id="7c1b9-118">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-118">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="7c1b9-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="7c1b9-119">Method</span></span> | <span data-ttu-id="7c1b9-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="7c1b9-120">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="7c1b9-121">PUT</span><span class="sxs-lookup"><span data-stu-id="7c1b9-121">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` |


### <a name="request-header"></a><span data-ttu-id="7c1b9-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7c1b9-122">Request header</span></span>

| <span data-ttu-id="7c1b9-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7c1b9-123">Header</span></span>        | <span data-ttu-id="7c1b9-124">型</span><span class="sxs-lookup"><span data-stu-id="7c1b9-124">Type</span></span>   | <span data-ttu-id="7c1b9-125">説明</span><span class="sxs-lookup"><span data-stu-id="7c1b9-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7c1b9-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="7c1b9-126">Authorization</span></span> | <span data-ttu-id="7c1b9-127">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-127">string</span></span> | <span data-ttu-id="7c1b9-128">必須。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-128">Required.</span></span> <span data-ttu-id="7c1b9-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="7c1b9-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c1b9-130">Request parameters</span></span>

| <span data-ttu-id="7c1b9-131">名前</span><span class="sxs-lookup"><span data-stu-id="7c1b9-131">Name</span></span>        | <span data-ttu-id="7c1b9-132">種類</span><span class="sxs-lookup"><span data-stu-id="7c1b9-132">Type</span></span>   | <span data-ttu-id="7c1b9-133">説明</span><span class="sxs-lookup"><span data-stu-id="7c1b9-133">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7c1b9-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="7c1b9-134">applicationId</span></span> | <span data-ttu-id="7c1b9-135">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-135">string</span></span> | <span data-ttu-id="7c1b9-136">必須。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-136">Required.</span></span> <span data-ttu-id="7c1b9-137">パッケージ フライト申請を更新するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-137">The Store ID of the app for which you want to update a package flight submission.</span></span> <span data-ttu-id="7c1b9-138">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-138">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="7c1b9-139">flightId</span><span class="sxs-lookup"><span data-stu-id="7c1b9-139">flightId</span></span> | <span data-ttu-id="7c1b9-140">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-140">string</span></span> | <span data-ttu-id="7c1b9-141">必須。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-141">Required.</span></span> <span data-ttu-id="7c1b9-142">申請を更新するパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-142">The ID of the package flight for which you want to update a submission.</span></span> <span data-ttu-id="7c1b9-143">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-143">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="7c1b9-144">パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-144">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |
| <span data-ttu-id="7c1b9-145">submissionId</span><span class="sxs-lookup"><span data-stu-id="7c1b9-145">submissionId</span></span> | <span data-ttu-id="7c1b9-146">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-146">string</span></span> | <span data-ttu-id="7c1b9-147">必須。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-147">Required.</span></span> <span data-ttu-id="7c1b9-148">更新する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-148">The ID of the submission to update.</span></span> <span data-ttu-id="7c1b9-149">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-149">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="7c1b9-150">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-150">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="7c1b9-151">要求本文</span><span class="sxs-lookup"><span data-stu-id="7c1b9-151">Request body</span></span>

<span data-ttu-id="7c1b9-152">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-152">The request body has the following parameters.</span></span>

| <span data-ttu-id="7c1b9-153">値</span><span class="sxs-lookup"><span data-stu-id="7c1b9-153">Value</span></span>      | <span data-ttu-id="7c1b9-154">型</span><span class="sxs-lookup"><span data-stu-id="7c1b9-154">Type</span></span>   | <span data-ttu-id="7c1b9-155">説明</span><span class="sxs-lookup"><span data-stu-id="7c1b9-155">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="7c1b9-156">flightPackages</span><span class="sxs-lookup"><span data-stu-id="7c1b9-156">flightPackages</span></span>           | <span data-ttu-id="7c1b9-157">array</span><span class="sxs-lookup"><span data-stu-id="7c1b9-157">array</span></span>  | <span data-ttu-id="7c1b9-158">申請の各パッケージに関する詳細を提供するオブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-158">Contains objects that provide details about each package in the submission.</span></span> <span data-ttu-id="7c1b9-159">応答本文の値について詳しくは、「[フライト パッケージ リソース](manage-flight-submissions.md#flight-package-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-159">For more details about the values in the response body, see [Flight package resource](manage-flight-submissions.md#flight-package-object).</span></span> <span data-ttu-id="7c1b9-160">このメソッドを呼び出してアプリの申請を更新するとき、要求の本文では、これらのオブジェクトの値 *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* だけが必須です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-160">When calling this method to update an app submission, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of these objects are required in the request body.</span></span> <span data-ttu-id="7c1b9-161">パートナー センターによっては、他の値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-161">The other values are populated by Partner Center.</span></span> |
| <span data-ttu-id="7c1b9-162">packageDeliveryOptions</span><span class="sxs-lookup"><span data-stu-id="7c1b9-162">packageDeliveryOptions</span></span>    | <span data-ttu-id="7c1b9-163">object</span><span class="sxs-lookup"><span data-stu-id="7c1b9-163">object</span></span>  | <span data-ttu-id="7c1b9-164">申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-164">Contains gradual package rollout and mandatory update settings for the submission.</span></span> <span data-ttu-id="7c1b9-165">詳しくは、「[パッケージの配信オプション オブジェクト](manage-flight-submissions.md#package-delivery-options-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-165">For more information, see [Package delivery options object](manage-flight-submissions.md#package-delivery-options-object).</span></span>  |
| <span data-ttu-id="7c1b9-166">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="7c1b9-166">targetPublishMode</span></span>           | <span data-ttu-id="7c1b9-167">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-167">string</span></span>  | <span data-ttu-id="7c1b9-168">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-168">The publish mode for the submission.</span></span> <span data-ttu-id="7c1b9-169">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-169">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7c1b9-170">Immediate</span><span class="sxs-lookup"><span data-stu-id="7c1b9-170">Immediate</span></span></li><li><span data-ttu-id="7c1b9-171">Manual</span><span class="sxs-lookup"><span data-stu-id="7c1b9-171">Manual</span></span></li><li><span data-ttu-id="7c1b9-172">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="7c1b9-172">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="7c1b9-173">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="7c1b9-173">targetPublishDate</span></span>           | <span data-ttu-id="7c1b9-174">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-174">string</span></span>  | <span data-ttu-id="7c1b9-175">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-175">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="7c1b9-176">notesForCertification</span><span class="sxs-lookup"><span data-stu-id="7c1b9-176">notesForCertification</span></span>           | <span data-ttu-id="7c1b9-177">string</span><span class="sxs-lookup"><span data-stu-id="7c1b9-177">string</span></span>  |  <span data-ttu-id="7c1b9-178">テスト アカウントの資格情報や、機能のアクセスおよび検証手順など、審査担当者に対して追加情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-178">Provides additional info for the certification testers, such as test account credentials and steps to access and verify features.</span></span> <span data-ttu-id="7c1b9-179">詳しくは、「[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-179">For more information, see [Notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification).</span></span> |


### <a name="request-example"></a><span data-ttu-id="7c1b9-180">要求の例</span><span class="sxs-lookup"><span data-stu-id="7c1b9-180">Request example</span></span>

<span data-ttu-id="7c1b9-181">アプリのパッケージ フライト申請を更新する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-181">The following example demonstrates how to update a package flight submission for an app.</span></span>

```json
PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649 HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
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
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

## <a name="response"></a><span data-ttu-id="7c1b9-182">応答</span><span class="sxs-lookup"><span data-stu-id="7c1b9-182">Response</span></span>

<span data-ttu-id="7c1b9-183">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-183">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="7c1b9-184">応答本文には、更新された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-184">The response body contains information about the updated submission.</span></span> <span data-ttu-id="7c1b9-185">応答本文の値について詳しくは、「[パッケージ フライトの申請のリソース](manage-flight-submissions.md#flight-submission-object)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-185">For more details about the values in the response body, see [Package flight submission resource](manage-flight-submissions.md#flight-submission-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="7c1b9-186">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7c1b9-186">Error codes</span></span>

<span data-ttu-id="7c1b9-187">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-187">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="7c1b9-188">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7c1b9-188">Error code</span></span> |  <span data-ttu-id="7c1b9-189">説明</span><span class="sxs-lookup"><span data-stu-id="7c1b9-189">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="7c1b9-190">400</span><span class="sxs-lookup"><span data-stu-id="7c1b9-190">400</span></span>  | <span data-ttu-id="7c1b9-191">要求が正しくないため、パッケージ フライト申請を更新できませんでした。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-191">The package flight submission could not be updated because the request is invalid.</span></span> |
| <span data-ttu-id="7c1b9-192">409</span><span class="sxs-lookup"><span data-stu-id="7c1b9-192">409</span></span>  | <span data-ttu-id="7c1b9-193">アプリの現在の状態があるため、パッケージ フライトの申請を更新できませんでしたまたは[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能、アプリで使用します。</span><span class="sxs-lookup"><span data-stu-id="7c1b9-193">The package flight submission could not be updated because of the current state of the app, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="7c1b9-194">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7c1b9-194">Related topics</span></span>

* [<span data-ttu-id="7c1b9-195">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="7c1b9-195">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="7c1b9-196">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="7c1b9-196">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="7c1b9-197">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="7c1b9-197">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="7c1b9-198">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="7c1b9-198">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="7c1b9-199">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="7c1b9-199">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="7c1b9-200">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="7c1b9-200">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="7c1b9-201">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="7c1b9-201">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
