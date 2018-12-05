---
description: パッケージ フライトの申請に関するパッケージ ロールアウト率を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: フライトの申請に関するロールアウト率の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, フライトの申請, 更新, 割合
ms.assetid: ee9aa223-e945-4c11-b430-1f4b1e559743
ms.localizationpriority: medium
ms.openlocfilehash: 025db5cb0beb36a5b4a3ca1b765b5da3434c9d7a
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8741127"
---
# <a name="update-the-rollout-percentage-for-a-flight-submission"></a><span data-ttu-id="161fe-104">フライトの申請に関するロールアウト率の更新</span><span class="sxs-lookup"><span data-stu-id="161fe-104">Update the rollout percentage for a flight submission</span></span>


<span data-ttu-id="161fe-105">パッケージ フライトの申請に関する[パッケージ ロールアウト率を更新する](../publish/gradual-package-rollout.md#setting-the-rollout-percentage)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="161fe-105">Use this method in the Microsoft Store submission API to [update the rollout percentage](../publish/gradual-package-rollout.md#setting-the-rollout-percentage) for a package flight submission.</span></span> <span data-ttu-id="161fe-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="161fe-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="161fe-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="161fe-107">Prerequisites</span></span>

<span data-ttu-id="161fe-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="161fe-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="161fe-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="161fe-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="161fe-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="161fe-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="161fe-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="161fe-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="161fe-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="161fe-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="161fe-113">アプリの 1 つの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="161fe-113">Create a submission for one of your apps.</span></span> <span data-ttu-id="161fe-114">パートナー センターで、これを行うか、[アプリの申請の作成](create-an-app-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="161fe-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="161fe-115">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="161fe-115">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="161fe-116">この[パートナー センターで](../publish/gradual-package-rollout.md)行うことができますか、 [Microsoft Store 申請 API を使用](manage-flight-submissions.md#manage-gradual-package-rollout)してこれを行います。</span><span class="sxs-lookup"><span data-stu-id="161fe-116">You can do this [in Partner Center](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-flight-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="161fe-117">要求</span><span class="sxs-lookup"><span data-stu-id="161fe-117">Request</span></span>

<span data-ttu-id="161fe-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="161fe-118">This method has the following syntax.</span></span> <span data-ttu-id="161fe-119">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="161fe-119">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="161fe-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="161fe-120">Method</span></span> | <span data-ttu-id="161fe-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="161fe-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="161fe-122">POST</span><span class="sxs-lookup"><span data-stu-id="161fe-122">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/updatepackagerolloutpercentage``` |


### <a name="request-header"></a><span data-ttu-id="161fe-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="161fe-123">Request header</span></span>

| <span data-ttu-id="161fe-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="161fe-124">Header</span></span>        | <span data-ttu-id="161fe-125">型</span><span class="sxs-lookup"><span data-stu-id="161fe-125">Type</span></span>   | <span data-ttu-id="161fe-126">説明</span><span class="sxs-lookup"><span data-stu-id="161fe-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="161fe-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="161fe-127">Authorization</span></span> | <span data-ttu-id="161fe-128">string</span><span class="sxs-lookup"><span data-stu-id="161fe-128">string</span></span> | <span data-ttu-id="161fe-129">必須。</span><span class="sxs-lookup"><span data-stu-id="161fe-129">Required.</span></span> <span data-ttu-id="161fe-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="161fe-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="161fe-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="161fe-131">Request parameters</span></span>

| <span data-ttu-id="161fe-132">名前</span><span class="sxs-lookup"><span data-stu-id="161fe-132">Name</span></span>        | <span data-ttu-id="161fe-133">種類</span><span class="sxs-lookup"><span data-stu-id="161fe-133">Type</span></span>   | <span data-ttu-id="161fe-134">説明</span><span class="sxs-lookup"><span data-stu-id="161fe-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="161fe-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="161fe-135">applicationId</span></span> | <span data-ttu-id="161fe-136">string</span><span class="sxs-lookup"><span data-stu-id="161fe-136">string</span></span> | <span data-ttu-id="161fe-137">必須。</span><span class="sxs-lookup"><span data-stu-id="161fe-137">Required.</span></span> <span data-ttu-id="161fe-138">パッケージ ロールアウト率を更新する対象のパッケージ フライト申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="161fe-138">The Store ID of the app that contains the package flight submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="161fe-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="161fe-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="161fe-140">flightId</span><span class="sxs-lookup"><span data-stu-id="161fe-140">flightId</span></span> | <span data-ttu-id="161fe-141">string</span><span class="sxs-lookup"><span data-stu-id="161fe-141">string</span></span> | <span data-ttu-id="161fe-142">必須。</span><span class="sxs-lookup"><span data-stu-id="161fe-142">Required.</span></span> <span data-ttu-id="161fe-143">パッケージ ロールアウト率を更新する対象の申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="161fe-143">The ID of the package flight that contains the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="161fe-144">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="161fe-144">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="161fe-145">パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="161fe-145">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |
| <span data-ttu-id="161fe-146">submissionId</span><span class="sxs-lookup"><span data-stu-id="161fe-146">submissionId</span></span> | <span data-ttu-id="161fe-147">string</span><span class="sxs-lookup"><span data-stu-id="161fe-147">string</span></span> | <span data-ttu-id="161fe-148">必須。</span><span class="sxs-lookup"><span data-stu-id="161fe-148">Required.</span></span> <span data-ttu-id="161fe-149">パッケージ ロールアウト率を更新する対象の申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="161fe-149">The ID of the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="161fe-150">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="161fe-150">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="161fe-151">パートナー センターで作成された申請ではこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="161fe-151">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |
| <span data-ttu-id="161fe-152">percentage</span><span class="sxs-lookup"><span data-stu-id="161fe-152">percentage</span></span>  |  <span data-ttu-id="161fe-153">float</span><span class="sxs-lookup"><span data-stu-id="161fe-153">float</span></span>  |  <span data-ttu-id="161fe-154">必須。</span><span class="sxs-lookup"><span data-stu-id="161fe-154">Required.</span></span> <span data-ttu-id="161fe-155">段階的なロールアウト パッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="161fe-155">The percentage of users who will receive the gradual rollout package.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="161fe-156">要求本文</span><span class="sxs-lookup"><span data-stu-id="161fe-156">Request body</span></span>

<span data-ttu-id="161fe-157">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="161fe-157">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="161fe-158">要求の例</span><span class="sxs-lookup"><span data-stu-id="161fe-158">Request example</span></span>

<span data-ttu-id="161fe-159">パッケージ フライト申請のパッケージ ロールアウト率を更新する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="161fe-159">The following example demonstrates how to update the package rollout percentage for a package flight submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243680/updatepackagerolloutpercentage?percentage=25 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="161fe-160">応答</span><span class="sxs-lookup"><span data-stu-id="161fe-160">Response</span></span>

<span data-ttu-id="161fe-161">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="161fe-161">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="161fe-162">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="161fe-162">For more details about the values in the response body, see [Package rollout resource](manage-flight-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="161fe-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="161fe-163">Error codes</span></span>

<span data-ttu-id="161fe-164">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="161fe-164">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="161fe-165">エラー コード</span><span class="sxs-lookup"><span data-stu-id="161fe-165">Error code</span></span> |  <span data-ttu-id="161fe-166">説明</span><span class="sxs-lookup"><span data-stu-id="161fe-166">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="161fe-167">404</span><span class="sxs-lookup"><span data-stu-id="161fe-167">404</span></span>  | <span data-ttu-id="161fe-168">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="161fe-168">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="161fe-169">409</span><span class="sxs-lookup"><span data-stu-id="161fe-169">409</span></span>  | <span data-ttu-id="161fe-170">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="161fe-170">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="161fe-171">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="161fe-171">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="161fe-172">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="161fe-172">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="161fe-173">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="161fe-173">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="161fe-174">関連トピック</span><span class="sxs-lookup"><span data-stu-id="161fe-174">Related topics</span></span>

* [<span data-ttu-id="161fe-175">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="161fe-175">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="161fe-176">Microsoft Store 申請 API を使用したパッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="161fe-176">Manage package flight submissions using the Microsoft Store submission API</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="161fe-177">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="161fe-177">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
