---
description: パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請に関するロールアウトの情報を取得する
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, フライトの申請
ms.assetid: 397f1b99-2be7-4f65-bcf1-9433a3d496ad
ms.localizationpriority: medium
ms.openlocfilehash: 1afc53a6f798fa5a85ddb3ec329d6c6b3fbee8ed
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334460"
---
# <a name="get-rollout-info-for-a-flight-submission"></a><span data-ttu-id="5990f-104">パッケージ フライトの申請に関するロールアウトの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="5990f-104">Get rollout info for a flight submission</span></span>


<span data-ttu-id="5990f-105">パッケージ フライトの申請に関する[パッケージのロールアウト](../publish/gradual-package-rollout.md)の情報を取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="5990f-105">Use this method in the Microsoft Store submission API to get [package rollout](../publish/gradual-package-rollout.md) info for a package flight submission.</span></span> <span data-ttu-id="5990f-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5990f-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="5990f-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="5990f-107">Prerequisites</span></span>

<span data-ttu-id="5990f-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5990f-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="5990f-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="5990f-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="5990f-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="5990f-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="5990f-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="5990f-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="5990f-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="5990f-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="5990f-113">アプリのいずれかのパッケージのフライトの送信を作成します。</span><span class="sxs-lookup"><span data-stu-id="5990f-113">Create a package flight submission for one of your apps.</span></span> <span data-ttu-id="5990f-114">パートナー センターでこれを行うかを使用してこれを行う、[パッケージ フライトの提出の作成](create-a-flight-submission.md)メソッド。</span><span class="sxs-lookup"><span data-stu-id="5990f-114">You can do this in Partner Center, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="5990f-115">要求</span><span class="sxs-lookup"><span data-stu-id="5990f-115">Request</span></span>

<span data-ttu-id="5990f-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="5990f-116">This method has the following syntax.</span></span> <span data-ttu-id="5990f-117">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5990f-117">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="5990f-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="5990f-118">Method</span></span> | <span data-ttu-id="5990f-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5990f-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="5990f-120">GET</span><span class="sxs-lookup"><span data-stu-id="5990f-120">GET</span></span>   | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout   ` |


### <a name="request-header"></a><span data-ttu-id="5990f-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5990f-121">Request header</span></span>

| <span data-ttu-id="5990f-122">Header</span><span class="sxs-lookup"><span data-stu-id="5990f-122">Header</span></span>        | <span data-ttu-id="5990f-123">種類</span><span class="sxs-lookup"><span data-stu-id="5990f-123">Type</span></span>   | <span data-ttu-id="5990f-124">説明</span><span class="sxs-lookup"><span data-stu-id="5990f-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="5990f-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="5990f-125">Authorization</span></span> | <span data-ttu-id="5990f-126">string</span><span class="sxs-lookup"><span data-stu-id="5990f-126">string</span></span> | <span data-ttu-id="5990f-127">必須。</span><span class="sxs-lookup"><span data-stu-id="5990f-127">Required.</span></span> <span data-ttu-id="5990f-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="5990f-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="5990f-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="5990f-129">Request parameters</span></span>

| <span data-ttu-id="5990f-130">名前</span><span class="sxs-lookup"><span data-stu-id="5990f-130">Name</span></span>        | <span data-ttu-id="5990f-131">種類</span><span class="sxs-lookup"><span data-stu-id="5990f-131">Type</span></span>   | <span data-ttu-id="5990f-132">説明</span><span class="sxs-lookup"><span data-stu-id="5990f-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="5990f-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="5990f-133">applicationId</span></span> | <span data-ttu-id="5990f-134">string</span><span class="sxs-lookup"><span data-stu-id="5990f-134">string</span></span> | <span data-ttu-id="5990f-135">必須。</span><span class="sxs-lookup"><span data-stu-id="5990f-135">Required.</span></span> <span data-ttu-id="5990f-136">取得するパッケージのロールアウトの情報を持つパッケージ フライトの申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="5990f-136">The Store ID of the app that contains the package flight submission with the package rollout info you want to get.</span></span> <span data-ttu-id="5990f-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5990f-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="5990f-138">flightId</span><span class="sxs-lookup"><span data-stu-id="5990f-138">flightId</span></span> | <span data-ttu-id="5990f-139">string</span><span class="sxs-lookup"><span data-stu-id="5990f-139">string</span></span> | <span data-ttu-id="5990f-140">必須。</span><span class="sxs-lookup"><span data-stu-id="5990f-140">Required.</span></span> <span data-ttu-id="5990f-141">取得するパッケージのロールアウトの情報を持つ申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="5990f-141">The ID of the package flight that contains the submission with the package rollout info you want to get.</span></span> <span data-ttu-id="5990f-142">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="5990f-142">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="5990f-143">パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="5990f-143">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center .</span></span>    |
| <span data-ttu-id="5990f-144">submissionId</span><span class="sxs-lookup"><span data-stu-id="5990f-144">submissionId</span></span> | <span data-ttu-id="5990f-145">string</span><span class="sxs-lookup"><span data-stu-id="5990f-145">string</span></span> | <span data-ttu-id="5990f-146">必須。</span><span class="sxs-lookup"><span data-stu-id="5990f-146">Required.</span></span> <span data-ttu-id="5990f-147">取得するパッケージのロールアウトの情報を持つ申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="5990f-147">The ID of the submission with the package rollout info to get.</span></span> <span data-ttu-id="5990f-148">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="5990f-148">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="5990f-149">パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="5990f-149">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>   |


### <a name="request-body"></a><span data-ttu-id="5990f-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="5990f-150">Request body</span></span>

<span data-ttu-id="5990f-151">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="5990f-151">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="5990f-152">要求の例</span><span class="sxs-lookup"><span data-stu-id="5990f-152">Request example</span></span>

<span data-ttu-id="5990f-153">パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="5990f-153">The following example demonstrates how to get the package rollout info for a package flight submission.</span></span>

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/packagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="5990f-154">応答</span><span class="sxs-lookup"><span data-stu-id="5990f-154">Response</span></span>

<span data-ttu-id="5990f-155">次の例は、段階的なパッケージのロールアウトが有効になっているパッケージ フライトの申請に対して、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="5990f-155">The following example demonstrates the JSON response body for a successful call to this method for a package flight submission with gradual package rollout enabled.</span></span> <span data-ttu-id="5990f-156">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5990f-156">For more details about the values in the response body, see [Package rollout resource](manage-flight-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

<span data-ttu-id="5990f-157">パッケージ フライトの申請で段階的なパッケージのロールアウトが有効になっていない場合は、次の応答の本文が返されます。</span><span class="sxs-lookup"><span data-stu-id="5990f-157">If the package flight submission does not have gradual package rollout enabled, the following response body will be returned.</span></span>

```json
{
    "isPackageRollout": false,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutNotStarted",
    "fallbackSubmissionId": "0"
}
```

## <a name="error-codes"></a><span data-ttu-id="5990f-158">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5990f-158">Error codes</span></span>

<span data-ttu-id="5990f-159">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="5990f-159">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="5990f-160">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5990f-160">Error code</span></span> |  <span data-ttu-id="5990f-161">説明</span><span class="sxs-lookup"><span data-stu-id="5990f-161">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="5990f-162">404</span><span class="sxs-lookup"><span data-stu-id="5990f-162">404</span></span>  | <span data-ttu-id="5990f-163">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="5990f-163">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="5990f-164">409</span><span class="sxs-lookup"><span data-stu-id="5990f-164">409</span></span>  | <span data-ttu-id="5990f-165">パッケージのフライトの送信は、指定したパッケージの航空券に属していませんまたはアプリであるパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="5990f-165">The package flight submission does not belong to the specified package flight, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="5990f-166">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5990f-166">Related topics</span></span>

* [<span data-ttu-id="5990f-167">パッケージの段階的なロールアウト</span><span class="sxs-lookup"><span data-stu-id="5990f-167">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="5990f-168">Microsoft Store 送信 API を使用してパッケージのフライトの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="5990f-168">Manage package flight submissions using the Microsoft Store submission API</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="5990f-169">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="5990f-169">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
