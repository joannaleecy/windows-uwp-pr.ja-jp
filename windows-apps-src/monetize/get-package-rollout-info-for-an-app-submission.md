---
description: アプリの申請に関するパッケージのロールアウトの情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請に関するロールアウト情報の取得
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, アプリの申請
ms.assetid: 9ada5ac3-a86e-4bb6-8ebc-915ba9649e3c
ms.localizationpriority: medium
ms.openlocfilehash: 301973fd231570f0fe63b8838971906c25e2d55c
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8459208"
---
# <a name="get-rollout-info-for-an-app-submission"></a><span data-ttu-id="bfaa5-104">アプリの申請に関するロールアウト情報の取得</span><span class="sxs-lookup"><span data-stu-id="bfaa5-104">Get rollout info for an app submission</span></span>


<span data-ttu-id="bfaa5-105">パッケージ フライトの申請に関する[パッケージのロールアウト](../publish/gradual-package-rollout.md)の情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-105">Use this method in the Microsoft Store submission API to get [package rollout](../publish/gradual-package-rollout.md) info for a package flight submission.</span></span> <span data-ttu-id="bfaa5-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="bfaa5-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="bfaa5-107">Prerequisites</span></span>

<span data-ttu-id="bfaa5-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="bfaa5-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="bfaa5-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="bfaa5-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="bfaa5-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="bfaa5-113">アプリの 1 つの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-113">Create a submission for one of your apps.</span></span> <span data-ttu-id="bfaa5-114">パートナー センターで、これを行うか、[アプリの申請の作成](create-an-app-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="bfaa5-115">要求</span><span class="sxs-lookup"><span data-stu-id="bfaa5-115">Request</span></span>

<span data-ttu-id="bfaa5-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-116">This method has the following syntax.</span></span> <span data-ttu-id="bfaa5-117">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-117">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="bfaa5-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="bfaa5-118">Method</span></span> | <span data-ttu-id="bfaa5-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="bfaa5-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="bfaa5-120">GET</span><span class="sxs-lookup"><span data-stu-id="bfaa5-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/packagerollout   ``` |


### <a name="request-header"></a><span data-ttu-id="bfaa5-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfaa5-121">Request header</span></span>

| <span data-ttu-id="bfaa5-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfaa5-122">Header</span></span>        | <span data-ttu-id="bfaa5-123">型</span><span class="sxs-lookup"><span data-stu-id="bfaa5-123">Type</span></span>   | <span data-ttu-id="bfaa5-124">説明</span><span class="sxs-lookup"><span data-stu-id="bfaa5-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="bfaa5-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="bfaa5-125">Authorization</span></span> | <span data-ttu-id="bfaa5-126">string</span><span class="sxs-lookup"><span data-stu-id="bfaa5-126">string</span></span> | <span data-ttu-id="bfaa5-127">必須。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-127">Required.</span></span> <span data-ttu-id="bfaa5-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="bfaa5-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfaa5-129">Request parameters</span></span>

| <span data-ttu-id="bfaa5-130">名前</span><span class="sxs-lookup"><span data-stu-id="bfaa5-130">Name</span></span>        | <span data-ttu-id="bfaa5-131">種類</span><span class="sxs-lookup"><span data-stu-id="bfaa5-131">Type</span></span>   | <span data-ttu-id="bfaa5-132">説明</span><span class="sxs-lookup"><span data-stu-id="bfaa5-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="bfaa5-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="bfaa5-133">applicationId</span></span> | <span data-ttu-id="bfaa5-134">string</span><span class="sxs-lookup"><span data-stu-id="bfaa5-134">string</span></span> | <span data-ttu-id="bfaa5-135">必須。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-135">Required.</span></span> <span data-ttu-id="bfaa5-136">取得するパッケージのロールアウトの情報を持つ申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-136">The Store ID of the app that contains the submission with the package rollout info you want to get.</span></span> <span data-ttu-id="bfaa5-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="bfaa5-138">submissionId</span><span class="sxs-lookup"><span data-stu-id="bfaa5-138">submissionId</span></span> | <span data-ttu-id="bfaa5-139">string</span><span class="sxs-lookup"><span data-stu-id="bfaa5-139">string</span></span> | <span data-ttu-id="bfaa5-140">必須。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-140">Required.</span></span> <span data-ttu-id="bfaa5-141">取得するパッケージのロールアウトの情報を持つ申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-141">The ID of the submission with the package rollout info you want to get.</span></span> <span data-ttu-id="bfaa5-142">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-142">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="bfaa5-143">パートナー センターで作成された申請ではこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-143">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="bfaa5-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="bfaa5-144">Request body</span></span>

<span data-ttu-id="bfaa5-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-145">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="bfaa5-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="bfaa5-146">Request example</span></span>

<span data-ttu-id="bfaa5-147">アプリの申請に関するパッケージのロールアウトの情報を取得する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-147">The following example demonstrates how to get the package rollout info for an app submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243649/packagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="bfaa5-148">応答</span><span class="sxs-lookup"><span data-stu-id="bfaa5-148">Response</span></span>

<span data-ttu-id="bfaa5-149">次の例は、段階的なパッケージのロールアウトが有効になっているアプリの申請に対して、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-149">The following example demonstrates the JSON response body for a successful call to this method for an app submission with gradual package rollout enabled.</span></span> <span data-ttu-id="bfaa5-150">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-150">For more details about the values in the response body, see [Package rollout resource](manage-app-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

<span data-ttu-id="bfaa5-151">アプリの申請で段階的なパッケージのロールアウトが有効になっていない場合は、次の応答の本文が返されます。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-151">If the app submission does not have gradual package rollout enabled, the following response body will be returned.</span></span>

```json
{
    "isPackageRollout": false,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutNotStarted",
    "fallbackSubmissionId": "0"
}
```

## <a name="error-codes"></a><span data-ttu-id="bfaa5-152">エラー コード</span><span class="sxs-lookup"><span data-stu-id="bfaa5-152">Error codes</span></span>

<span data-ttu-id="bfaa5-153">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-153">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="bfaa5-154">エラー コード</span><span class="sxs-lookup"><span data-stu-id="bfaa5-154">Error code</span></span> |  <span data-ttu-id="bfaa5-155">説明</span><span class="sxs-lookup"><span data-stu-id="bfaa5-155">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="bfaa5-156">404</span><span class="sxs-lookup"><span data-stu-id="bfaa5-156">404</span></span>  | <span data-ttu-id="bfaa5-157">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-157">The submission could not be found.</span></span> |
| <span data-ttu-id="bfaa5-158">409</span><span class="sxs-lookup"><span data-stu-id="bfaa5-158">409</span></span>  | <span data-ttu-id="bfaa5-159">指定されたアプリに、申請が属していないか、アプリは[、Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="bfaa5-159">The submission does not belong to the specified app, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="bfaa5-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bfaa5-160">Related topics</span></span>

* [<span data-ttu-id="bfaa5-161">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="bfaa5-161">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="bfaa5-162">Microsoft Store 申請 API を使用したアプリの申請の管理</span><span class="sxs-lookup"><span data-stu-id="bfaa5-162">Manage app submissions using the Microsoft Store submission API</span></span>](manage-app-submissions.md)
* [<span data-ttu-id="bfaa5-163">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="bfaa5-163">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
