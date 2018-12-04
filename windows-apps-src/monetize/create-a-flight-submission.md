---
ms.assetid: CD866083-EB7F-4389-A907-FC43DC2FCB5E
description: パートナー センター アカウントに登録されているアプリの新しいパッケージ フライトの申請を作成する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの申請の作成
ms.date: 08/03/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請の作成
ms.localizationpriority: medium
ms.openlocfilehash: 1e303027aaf3b10260090c500df573f1bf484e20
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8468596"
---
# <a name="create-a-package-flight-submission"></a><span data-ttu-id="33eb4-104">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="33eb4-104">Create a package flight submission</span></span>

<span data-ttu-id="33eb4-105">アプリのパッケージ フライトの新しい申請を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="33eb4-105">Use this method in the Microsoft Store submission API to create a new submission for a package flight for an app.</span></span> <span data-ttu-id="33eb4-106">このメソッドを使って新しい申請を正常に作成したら、[申請を更新](update-a-flight-submission.md)して申請データに必要な変更を加え、取り込んで公開するために[申請をコミット](commit-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="33eb4-106">After you successfully create a new submission by using this method, [update the submission](update-a-flight-submission.md) to make any necessary changes to the submission data, and then [commit the submission](commit-a-flight-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="33eb4-107">このメソッドが Microsoft Store 申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-107">For more information about how this method fits into the process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

> [!NOTE]
> <span data-ttu-id="33eb4-108">このメソッドは、既存のパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="33eb4-108">This method creates a submission for an existing package flight.</span></span> <span data-ttu-id="33eb4-109">パッケージ フライトを作成するには、[パッケージ フライトの作成](create-a-flight.md)のメソッドを使用してください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-109">To create a package flight, use the [create a package flight](create-a-flight.md) method.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="33eb4-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="33eb4-110">Prerequisites</span></span>

<span data-ttu-id="33eb4-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="33eb4-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="33eb4-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="33eb4-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="33eb4-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="33eb4-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="33eb4-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="33eb4-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="33eb4-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="33eb4-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="33eb4-116">アプリのパッケージ フライトを作成します。</span><span class="sxs-lookup"><span data-stu-id="33eb4-116">Create a package flight for an app.</span></span> <span data-ttu-id="33eb4-117">パートナー センターで、これを行うか、[パッケージ フライトの作成](create-a-flight.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="33eb4-117">You can do this in Partner Center, or you can do this by using the [create a package flight](create-a-flight.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="33eb4-118">要求</span><span class="sxs-lookup"><span data-stu-id="33eb4-118">Request</span></span>

<span data-ttu-id="33eb4-119">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="33eb4-119">This method has the following syntax.</span></span> <span data-ttu-id="33eb4-120">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-120">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="33eb4-121">メソッド</span><span class="sxs-lookup"><span data-stu-id="33eb4-121">Method</span></span> | <span data-ttu-id="33eb4-122">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33eb4-122">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="33eb4-123">POST</span><span class="sxs-lookup"><span data-stu-id="33eb4-123">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions``` |


### <a name="request-header"></a><span data-ttu-id="33eb4-124">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33eb4-124">Request header</span></span>

| <span data-ttu-id="33eb4-125">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33eb4-125">Header</span></span>        | <span data-ttu-id="33eb4-126">型</span><span class="sxs-lookup"><span data-stu-id="33eb4-126">Type</span></span>   | <span data-ttu-id="33eb4-127">説明</span><span class="sxs-lookup"><span data-stu-id="33eb4-127">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="33eb4-128">Authorization</span><span class="sxs-lookup"><span data-stu-id="33eb4-128">Authorization</span></span> | <span data-ttu-id="33eb4-129">string</span><span class="sxs-lookup"><span data-stu-id="33eb4-129">string</span></span> | <span data-ttu-id="33eb4-130">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb4-130">Required.</span></span> <span data-ttu-id="33eb4-131">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="33eb4-131">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="33eb4-132">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="33eb4-132">Request parameters</span></span>

| <span data-ttu-id="33eb4-133">名前</span><span class="sxs-lookup"><span data-stu-id="33eb4-133">Name</span></span>        | <span data-ttu-id="33eb4-134">種類</span><span class="sxs-lookup"><span data-stu-id="33eb4-134">Type</span></span>   | <span data-ttu-id="33eb4-135">説明</span><span class="sxs-lookup"><span data-stu-id="33eb4-135">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="33eb4-136">applicationId</span><span class="sxs-lookup"><span data-stu-id="33eb4-136">applicationId</span></span> | <span data-ttu-id="33eb4-137">string</span><span class="sxs-lookup"><span data-stu-id="33eb4-137">string</span></span> | <span data-ttu-id="33eb4-138">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb4-138">Required.</span></span> <span data-ttu-id="33eb4-139">パッケージ フライトの申請を作成するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="33eb4-139">The Store ID of the app for which you want to create a package flight submission.</span></span> <span data-ttu-id="33eb4-140">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-140">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="33eb4-141">flightId</span><span class="sxs-lookup"><span data-stu-id="33eb4-141">flightId</span></span> | <span data-ttu-id="33eb4-142">string</span><span class="sxs-lookup"><span data-stu-id="33eb4-142">string</span></span> | <span data-ttu-id="33eb4-143">必須。</span><span class="sxs-lookup"><span data-stu-id="33eb4-143">Required.</span></span> <span data-ttu-id="33eb4-144">申請を追加するパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="33eb4-144">The ID of the package flight for which you want to add the submission.</span></span> <span data-ttu-id="33eb4-145">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="33eb4-145">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |


### <a name="request-body"></a><span data-ttu-id="33eb4-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="33eb4-146">Request body</span></span>

<span data-ttu-id="33eb4-147">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-147">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="33eb4-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="33eb4-148">Request example</span></span>

<span data-ttu-id="33eb4-149">次の例は、ストア ID 9WZDNCRD91MD を持つアプリの新しいパッケージ フライトの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="33eb4-149">The following example demonstrates how to create a new package flight submission for an app that has the Store ID 9WZDNCRD91MD.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="33eb4-150">応答</span><span class="sxs-lookup"><span data-stu-id="33eb4-150">Response</span></span>

<span data-ttu-id="33eb4-151">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="33eb4-151">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="33eb4-152">応答本文には、新しい申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="33eb4-152">The response body contains information about the new submission.</span></span> <span data-ttu-id="33eb4-153">応答本文の値について詳しくは、[パッケージ フライトの申請のリソース](manage-flight-submissions.md#flight-submission-object)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="33eb4-153">For more details about the values in the response body, see [Package flight submission resource](manage-flight-submissions.md#flight-submission-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="33eb4-154">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33eb4-154">Error codes</span></span>

<span data-ttu-id="33eb4-155">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="33eb4-155">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="33eb4-156">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33eb4-156">Error code</span></span> |  <span data-ttu-id="33eb4-157">説明</span><span class="sxs-lookup"><span data-stu-id="33eb4-157">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="33eb4-158">400</span><span class="sxs-lookup"><span data-stu-id="33eb4-158">400</span></span>  | <span data-ttu-id="33eb4-159">要求が無効なため、パッケージ フライトの申請を作成できませんでした。</span><span class="sxs-lookup"><span data-stu-id="33eb4-159">The package flight submission could not be created because the request is invalid.</span></span> |
| <span data-ttu-id="33eb4-160">409</span><span class="sxs-lookup"><span data-stu-id="33eb4-160">409</span></span>  | <span data-ttu-id="33eb4-161">アプリの現在の状態が原因パッケージ フライトの申請を作成できませんでしたまたは[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能、アプリで使用します。</span><span class="sxs-lookup"><span data-stu-id="33eb4-161">The package flight submission could not be created because of the current state of the app, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="33eb4-162">関連トピック</span><span class="sxs-lookup"><span data-stu-id="33eb4-162">Related topics</span></span>

* [<span data-ttu-id="33eb4-163">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="33eb4-163">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="33eb4-164">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="33eb4-164">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="33eb4-165">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="33eb4-165">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="33eb4-166">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="33eb4-166">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="33eb4-167">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="33eb4-167">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="33eb4-168">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="33eb4-168">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="33eb4-169">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="33eb4-169">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
