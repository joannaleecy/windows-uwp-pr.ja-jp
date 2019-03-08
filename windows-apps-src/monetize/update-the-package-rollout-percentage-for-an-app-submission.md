---
description: アプリの申請に関するパッケージのロールアウト率を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請に関するロールアウト率の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, アプリの申請, 更新, 割合
ms.assetid: 4c82d837-7a25-4f3a-997e-b7be33b521cc
ms.localizationpriority: medium
ms.openlocfilehash: 172c750d370f8fd8822d78265a04e694bc958ddf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605707"
---
# <a name="update-the-rollout-percentage-for-an-app-submission"></a><span data-ttu-id="48296-104">アプリの申請に関するロールアウト率の更新</span><span class="sxs-lookup"><span data-stu-id="48296-104">Update the rollout percentage for an app submission</span></span>


<span data-ttu-id="48296-105">アプリの申請に関する[ロールアウト率を更新する](../publish/gradual-package-rollout.md#setting-the-rollout-percentage)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="48296-105">Use this method in the Microsoft Store submission API to [update the rollout percentage](../publish/gradual-package-rollout.md#setting-the-rollout-percentage) for an app submission.</span></span> <span data-ttu-id="48296-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48296-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>


## <a name="prerequisites"></a><span data-ttu-id="48296-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="48296-107">Prerequisites</span></span>

<span data-ttu-id="48296-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="48296-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="48296-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="48296-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="48296-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="48296-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="48296-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="48296-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="48296-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="48296-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="48296-113">アプリのいずれかの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="48296-113">Create a submission for one of your apps.</span></span> <span data-ttu-id="48296-114">パートナー センターでこれを行うかを使用してこれを行う、[アプリの提出を作成](create-an-app-submission.md)メソッド。</span><span class="sxs-lookup"><span data-stu-id="48296-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="48296-115">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="48296-115">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="48296-116">これを行う[パートナー センターで](../publish/gradual-package-rollout.md)、これを行うまたは[Microsoft Store 送信 API を使用して](manage-app-submissions.md#manage-gradual-package-rollout)します。</span><span class="sxs-lookup"><span data-stu-id="48296-116">You can do this in [in Partner Center](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-app-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="48296-117">要求</span><span class="sxs-lookup"><span data-stu-id="48296-117">Request</span></span>

<span data-ttu-id="48296-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="48296-118">This method has the following syntax.</span></span> <span data-ttu-id="48296-119">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48296-119">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="48296-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="48296-120">Method</span></span> | <span data-ttu-id="48296-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="48296-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="48296-122">POST</span><span class="sxs-lookup"><span data-stu-id="48296-122">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/updatepackagerolloutpercentage``` |


### <a name="request-header"></a><span data-ttu-id="48296-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="48296-123">Request header</span></span>

| <span data-ttu-id="48296-124">Header</span><span class="sxs-lookup"><span data-stu-id="48296-124">Header</span></span>        | <span data-ttu-id="48296-125">種類</span><span class="sxs-lookup"><span data-stu-id="48296-125">Type</span></span>   | <span data-ttu-id="48296-126">説明</span><span class="sxs-lookup"><span data-stu-id="48296-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="48296-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="48296-127">Authorization</span></span> | <span data-ttu-id="48296-128">string</span><span class="sxs-lookup"><span data-stu-id="48296-128">string</span></span> | <span data-ttu-id="48296-129">必須。</span><span class="sxs-lookup"><span data-stu-id="48296-129">Required.</span></span> <span data-ttu-id="48296-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="48296-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="48296-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="48296-131">Request parameters</span></span>

| <span data-ttu-id="48296-132">名前</span><span class="sxs-lookup"><span data-stu-id="48296-132">Name</span></span>        | <span data-ttu-id="48296-133">種類</span><span class="sxs-lookup"><span data-stu-id="48296-133">Type</span></span>   | <span data-ttu-id="48296-134">説明</span><span class="sxs-lookup"><span data-stu-id="48296-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="48296-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="48296-135">applicationId</span></span> | <span data-ttu-id="48296-136">string</span><span class="sxs-lookup"><span data-stu-id="48296-136">string</span></span> | <span data-ttu-id="48296-137">必須。</span><span class="sxs-lookup"><span data-stu-id="48296-137">Required.</span></span> <span data-ttu-id="48296-138">パッケージ ロールアウト率を更新する対象の申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="48296-138">The Store ID of the app that contains the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="48296-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48296-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="48296-140">submissionId</span><span class="sxs-lookup"><span data-stu-id="48296-140">submissionId</span></span> | <span data-ttu-id="48296-141">string</span><span class="sxs-lookup"><span data-stu-id="48296-141">string</span></span> | <span data-ttu-id="48296-142">必須。</span><span class="sxs-lookup"><span data-stu-id="48296-142">Required.</span></span> <span data-ttu-id="48296-143">パッケージ ロールアウト率を更新する対象の申請の ID。</span><span class="sxs-lookup"><span data-stu-id="48296-143">The ID of the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="48296-144">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="48296-144">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="48296-145">パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="48296-145">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>   |
| <span data-ttu-id="48296-146">percentage</span><span class="sxs-lookup"><span data-stu-id="48296-146">percentage</span></span>  |  <span data-ttu-id="48296-147">float</span><span class="sxs-lookup"><span data-stu-id="48296-147">float</span></span>  |  <span data-ttu-id="48296-148">必須。</span><span class="sxs-lookup"><span data-stu-id="48296-148">Required.</span></span> <span data-ttu-id="48296-149">段階的なロールアウト パッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="48296-149">The percentage of users who will receive the gradual rollout package.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="48296-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="48296-150">Request body</span></span>

<span data-ttu-id="48296-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="48296-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="48296-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="48296-152">Request example</span></span>

<span data-ttu-id="48296-153">アプリの申請のパッケージ ロールアウト率を更新する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="48296-153">The following example demonstrates how to update the package rollout percentage for an app submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243680/updatepackagerolloutpercentage?percentage=25 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="48296-154">応答</span><span class="sxs-lookup"><span data-stu-id="48296-154">Response</span></span>

<span data-ttu-id="48296-155">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="48296-155">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="48296-156">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48296-156">For more details about the values in the response body, see [Package rollout resource](manage-app-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="48296-157">エラー コード</span><span class="sxs-lookup"><span data-stu-id="48296-157">Error codes</span></span>

<span data-ttu-id="48296-158">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="48296-158">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="48296-159">エラー コード</span><span class="sxs-lookup"><span data-stu-id="48296-159">Error code</span></span> |  <span data-ttu-id="48296-160">説明</span><span class="sxs-lookup"><span data-stu-id="48296-160">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="48296-161">404</span><span class="sxs-lookup"><span data-stu-id="48296-161">404</span></span>  | <span data-ttu-id="48296-162">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="48296-162">The submission could not be found.</span></span> |
| <span data-ttu-id="48296-163">409</span><span class="sxs-lookup"><span data-stu-id="48296-163">409</span></span>  | <span data-ttu-id="48296-164">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="48296-164">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="48296-165">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-app-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="48296-165">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-app-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="48296-166">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="48296-166">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="48296-167">アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="48296-167">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="48296-168">関連トピック</span><span class="sxs-lookup"><span data-stu-id="48296-168">Related topics</span></span>

* [<span data-ttu-id="48296-169">パッケージの段階的なロールアウト</span><span class="sxs-lookup"><span data-stu-id="48296-169">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="48296-170">Microsoft Store 送信 API を使用してアプリ送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="48296-170">Manage app submissions using the Microsoft Store submission API</span></span>](manage-app-submissions.md)
* [<span data-ttu-id="48296-171">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="48296-171">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
