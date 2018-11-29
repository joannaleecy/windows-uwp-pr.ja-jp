---
description: アプリの申請に関するパッケージのロールアウト率を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請に関するロールアウト率の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, アプリの申請, 更新, 割合
ms.assetid: 4c82d837-7a25-4f3a-997e-b7be33b521cc
ms.localizationpriority: medium
ms.openlocfilehash: 172c750d370f8fd8822d78265a04e694bc958ddf
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7989781"
---
# <a name="update-the-rollout-percentage-for-an-app-submission"></a><span data-ttu-id="c5c29-104">アプリの申請に関するロールアウト率の更新</span><span class="sxs-lookup"><span data-stu-id="c5c29-104">Update the rollout percentage for an app submission</span></span>


<span data-ttu-id="c5c29-105">アプリの申請に関する[ロールアウト率を更新する](../publish/gradual-package-rollout.md#setting-the-rollout-percentage)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="c5c29-105">Use this method in the Microsoft Store submission API to [update the rollout percentage](../publish/gradual-package-rollout.md#setting-the-rollout-percentage) for an app submission.</span></span> <span data-ttu-id="c5c29-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5c29-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>


## <a name="prerequisites"></a><span data-ttu-id="c5c29-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="c5c29-107">Prerequisites</span></span>

<span data-ttu-id="c5c29-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5c29-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c5c29-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c5c29-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="c5c29-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c5c29-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c5c29-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c5c29-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c5c29-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c5c29-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="c5c29-113">アプリの 1 つの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="c5c29-113">Create a submission for one of your apps.</span></span> <span data-ttu-id="c5c29-114">パートナー センターで、これを行うか、[アプリの申請の作成](create-an-app-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c5c29-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="c5c29-115">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="c5c29-115">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="c5c29-116">[パートナー センターで](../publish/gradual-package-rollout.md)、これを行うか、 [Microsoft Store 申請 API を使用](manage-app-submissions.md#manage-gradual-package-rollout)してこれを行います。</span><span class="sxs-lookup"><span data-stu-id="c5c29-116">You can do this in [in Partner Center](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-app-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="c5c29-117">要求</span><span class="sxs-lookup"><span data-stu-id="c5c29-117">Request</span></span>

<span data-ttu-id="c5c29-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c5c29-118">This method has the following syntax.</span></span> <span data-ttu-id="c5c29-119">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5c29-119">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="c5c29-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="c5c29-120">Method</span></span> | <span data-ttu-id="c5c29-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c5c29-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="c5c29-122">POST</span><span class="sxs-lookup"><span data-stu-id="c5c29-122">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/updatepackagerolloutpercentage``` |


### <a name="request-header"></a><span data-ttu-id="c5c29-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c5c29-123">Request header</span></span>

| <span data-ttu-id="c5c29-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c5c29-124">Header</span></span>        | <span data-ttu-id="c5c29-125">型</span><span class="sxs-lookup"><span data-stu-id="c5c29-125">Type</span></span>   | <span data-ttu-id="c5c29-126">説明</span><span class="sxs-lookup"><span data-stu-id="c5c29-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c5c29-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="c5c29-127">Authorization</span></span> | <span data-ttu-id="c5c29-128">string</span><span class="sxs-lookup"><span data-stu-id="c5c29-128">string</span></span> | <span data-ttu-id="c5c29-129">必須。</span><span class="sxs-lookup"><span data-stu-id="c5c29-129">Required.</span></span> <span data-ttu-id="c5c29-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c5c29-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c5c29-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c5c29-131">Request parameters</span></span>

| <span data-ttu-id="c5c29-132">名前</span><span class="sxs-lookup"><span data-stu-id="c5c29-132">Name</span></span>        | <span data-ttu-id="c5c29-133">種類</span><span class="sxs-lookup"><span data-stu-id="c5c29-133">Type</span></span>   | <span data-ttu-id="c5c29-134">説明</span><span class="sxs-lookup"><span data-stu-id="c5c29-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c5c29-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="c5c29-135">applicationId</span></span> | <span data-ttu-id="c5c29-136">string</span><span class="sxs-lookup"><span data-stu-id="c5c29-136">string</span></span> | <span data-ttu-id="c5c29-137">必須。</span><span class="sxs-lookup"><span data-stu-id="c5c29-137">Required.</span></span> <span data-ttu-id="c5c29-138">パッケージ ロールアウト率を更新する対象の申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="c5c29-138">The Store ID of the app that contains the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="c5c29-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5c29-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="c5c29-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="c5c29-140">submissionId</span></span> | <span data-ttu-id="c5c29-141">string</span><span class="sxs-lookup"><span data-stu-id="c5c29-141">string</span></span> | <span data-ttu-id="c5c29-142">必須。</span><span class="sxs-lookup"><span data-stu-id="c5c29-142">Required.</span></span> <span data-ttu-id="c5c29-143">パッケージ ロールアウト率を更新する対象の申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="c5c29-143">The ID of the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="c5c29-144">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="c5c29-144">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="c5c29-145">パートナー センターで作成された申請ではこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="c5c29-145">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>   |
| <span data-ttu-id="c5c29-146">percentage</span><span class="sxs-lookup"><span data-stu-id="c5c29-146">percentage</span></span>  |  <span data-ttu-id="c5c29-147">float</span><span class="sxs-lookup"><span data-stu-id="c5c29-147">float</span></span>  |  <span data-ttu-id="c5c29-148">必須。</span><span class="sxs-lookup"><span data-stu-id="c5c29-148">Required.</span></span> <span data-ttu-id="c5c29-149">段階的なロールアウト パッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="c5c29-149">The percentage of users who will receive the gradual rollout package.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="c5c29-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="c5c29-150">Request body</span></span>

<span data-ttu-id="c5c29-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c5c29-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="c5c29-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="c5c29-152">Request example</span></span>

<span data-ttu-id="c5c29-153">アプリの申請のパッケージ ロールアウト率を更新する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c5c29-153">The following example demonstrates how to update the package rollout percentage for an app submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243680/updatepackagerolloutpercentage?percentage=25 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c5c29-154">応答</span><span class="sxs-lookup"><span data-stu-id="c5c29-154">Response</span></span>

<span data-ttu-id="c5c29-155">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="c5c29-155">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="c5c29-156">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5c29-156">For more details about the values in the response body, see [Package rollout resource](manage-app-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="c5c29-157">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c5c29-157">Error codes</span></span>

<span data-ttu-id="c5c29-158">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="c5c29-158">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="c5c29-159">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c5c29-159">Error code</span></span> |  <span data-ttu-id="c5c29-160">説明</span><span class="sxs-lookup"><span data-stu-id="c5c29-160">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="c5c29-161">404</span><span class="sxs-lookup"><span data-stu-id="c5c29-161">404</span></span>  | <span data-ttu-id="c5c29-162">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c5c29-162">The submission could not be found.</span></span> |
| <span data-ttu-id="c5c29-163">409</span><span class="sxs-lookup"><span data-stu-id="c5c29-163">409</span></span>  | <span data-ttu-id="c5c29-164">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="c5c29-164">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="c5c29-165">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-app-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="c5c29-165">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-app-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="c5c29-166">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="c5c29-166">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="c5c29-167">アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="c5c29-167">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="c5c29-168">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c5c29-168">Related topics</span></span>

* [<span data-ttu-id="c5c29-169">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="c5c29-169">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="c5c29-170">Microsoft Store 申請 API を使用したアプリの申請の管理</span><span class="sxs-lookup"><span data-stu-id="c5c29-170">Manage app submissions using the Microsoft Store submission API</span></span>](manage-app-submissions.md)
* [<span data-ttu-id="c5c29-171">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="c5c29-171">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
