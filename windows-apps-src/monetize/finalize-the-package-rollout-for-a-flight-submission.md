---
description: パッケージ フライトの申請に関するパッケージのロールアウトを完了するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: フライトの申請に関するロールアウトを完了する
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, フライトの申請, 最終処理
ms.assetid: e4a645f6-1f00-4af5-80d6-d2ee179acc8a
ms.localizationpriority: medium
ms.openlocfilehash: c2864dae721d572ef9e340eddfed0149aa0b621f
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334650"
---
# <a name="finalize-the-rollout-for-a-flight-submission"></a><span data-ttu-id="71f0d-104">フライトの申請に関するロールアウトを完了する</span><span class="sxs-lookup"><span data-stu-id="71f0d-104">Finalize the rollout for a flight submission</span></span>


<span data-ttu-id="71f0d-105">パッケージ フライトの申請に関する[パッケージのロールアウトを完了する](../publish/gradual-package-rollout.md#completing-the-rollout)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="71f0d-105">Use this method in the Microsoft Store submission API to [finalize the package rollout](../publish/gradual-package-rollout.md#completing-the-rollout) for a package flight submission.</span></span> <span data-ttu-id="71f0d-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0d-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>


## <a name="prerequisites"></a><span data-ttu-id="71f0d-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="71f0d-107">Prerequisites</span></span>

<span data-ttu-id="71f0d-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="71f0d-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="71f0d-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="71f0d-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="71f0d-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="71f0d-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="71f0d-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="71f0d-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="71f0d-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="71f0d-113">パートナー センターでアプリの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-113">Create a submission for an app in Partner Center.</span></span> <span data-ttu-id="71f0d-114">パートナー センターでこれを行うかを使用してこれを行う、[アプリの提出を作成](create-an-app-submission.md)メソッド。</span><span class="sxs-lookup"><span data-stu-id="71f0d-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="71f0d-115">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="71f0d-115">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="71f0d-116">これを行う[パートナー センター](../publish/gradual-package-rollout.md)、これを行うまたは[Microsoft Store 送信 API を使用して](manage-flight-submissions.md#manage-gradual-package-rollout)します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-116">You can do this in [Partner Center](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-flight-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="71f0d-117">要求</span><span class="sxs-lookup"><span data-stu-id="71f0d-117">Request</span></span>

<span data-ttu-id="71f0d-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="71f0d-118">This method has the following syntax.</span></span> <span data-ttu-id="71f0d-119">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0d-119">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="71f0d-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="71f0d-120">Method</span></span> | <span data-ttu-id="71f0d-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="71f0d-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="71f0d-122">POST</span><span class="sxs-lookup"><span data-stu-id="71f0d-122">POST</span></span>   | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/finalizepackagerollout` |


### <a name="request-header"></a><span data-ttu-id="71f0d-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="71f0d-123">Request header</span></span>

| <span data-ttu-id="71f0d-124">Header</span><span class="sxs-lookup"><span data-stu-id="71f0d-124">Header</span></span>        | <span data-ttu-id="71f0d-125">種類</span><span class="sxs-lookup"><span data-stu-id="71f0d-125">Type</span></span>   | <span data-ttu-id="71f0d-126">説明</span><span class="sxs-lookup"><span data-stu-id="71f0d-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="71f0d-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="71f0d-127">Authorization</span></span> | <span data-ttu-id="71f0d-128">string</span><span class="sxs-lookup"><span data-stu-id="71f0d-128">string</span></span> | <span data-ttu-id="71f0d-129">必須。</span><span class="sxs-lookup"><span data-stu-id="71f0d-129">Required.</span></span> <span data-ttu-id="71f0d-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="71f0d-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="71f0d-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="71f0d-131">Request parameters</span></span>

| <span data-ttu-id="71f0d-132">名前</span><span class="sxs-lookup"><span data-stu-id="71f0d-132">Name</span></span>        | <span data-ttu-id="71f0d-133">種類</span><span class="sxs-lookup"><span data-stu-id="71f0d-133">Type</span></span>   | <span data-ttu-id="71f0d-134">説明</span><span class="sxs-lookup"><span data-stu-id="71f0d-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="71f0d-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="71f0d-135">applicationId</span></span> | <span data-ttu-id="71f0d-136">string</span><span class="sxs-lookup"><span data-stu-id="71f0d-136">string</span></span> | <span data-ttu-id="71f0d-137">必須。</span><span class="sxs-lookup"><span data-stu-id="71f0d-137">Required.</span></span> <span data-ttu-id="71f0d-138">完了するパッケージのロールアウトの対象となるパッケージ フライトの申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="71f0d-138">The Store ID of the app that contains the package flight submission with the package rollout you want to finalize.</span></span> <span data-ttu-id="71f0d-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0d-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="71f0d-140">flightId</span><span class="sxs-lookup"><span data-stu-id="71f0d-140">flightId</span></span> | <span data-ttu-id="71f0d-141">string</span><span class="sxs-lookup"><span data-stu-id="71f0d-141">string</span></span> | <span data-ttu-id="71f0d-142">必須。</span><span class="sxs-lookup"><span data-stu-id="71f0d-142">Required.</span></span> <span data-ttu-id="71f0d-143">完了するパッケージのロールアウトの対象となる申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="71f0d-143">The ID of the package flight that contains the submission with the package rollout you want to finalize.</span></span> <span data-ttu-id="71f0d-144">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="71f0d-144">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="71f0d-145">パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="71f0d-145">For a flight that was created in Partner Center , this ID is also available in the URL for the flight page in Partner Center.</span></span> |
| <span data-ttu-id="71f0d-146">submissionId</span><span class="sxs-lookup"><span data-stu-id="71f0d-146">submissionId</span></span> | <span data-ttu-id="71f0d-147">string</span><span class="sxs-lookup"><span data-stu-id="71f0d-147">string</span></span> | <span data-ttu-id="71f0d-148">必須。</span><span class="sxs-lookup"><span data-stu-id="71f0d-148">Required.</span></span> <span data-ttu-id="71f0d-149">完了するパッケージのロールアウトの対象となる申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="71f0d-149">The ID of the submission with the package rollout you want to finalize.</span></span> <span data-ttu-id="71f0d-150">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="71f0d-150">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="71f0d-151">パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="71f0d-151">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="71f0d-152">要求本文</span><span class="sxs-lookup"><span data-stu-id="71f0d-152">Request body</span></span>

<span data-ttu-id="71f0d-153">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="71f0d-153">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="71f0d-154">要求の例</span><span class="sxs-lookup"><span data-stu-id="71f0d-154">Request example</span></span>

<span data-ttu-id="71f0d-155">パッケージ フライトの申請に関するパッケージのロールアウトを完了する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-155">The following example demonstrates how to finalize the package rollout for a package flight submission.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243680/finalizepackagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="71f0d-156">応答</span><span class="sxs-lookup"><span data-stu-id="71f0d-156">Response</span></span>

<span data-ttu-id="71f0d-157">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="71f0d-157">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="71f0d-158">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71f0d-158">For more details about the values in the response body, see [Package rollout resource](manage-flight-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 100.0,
    "packageRolloutStatus": "PackageRolloutComplete",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="71f0d-159">エラー コード</span><span class="sxs-lookup"><span data-stu-id="71f0d-159">Error codes</span></span>

<span data-ttu-id="71f0d-160">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="71f0d-160">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="71f0d-161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="71f0d-161">Error code</span></span> |  <span data-ttu-id="71f0d-162">説明</span><span class="sxs-lookup"><span data-stu-id="71f0d-162">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="71f0d-163">404</span><span class="sxs-lookup"><span data-stu-id="71f0d-163">404</span></span>  | <span data-ttu-id="71f0d-164">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="71f0d-164">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="71f0d-165">409</span><span class="sxs-lookup"><span data-stu-id="71f0d-165">409</span></span>  | <span data-ttu-id="71f0d-166">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-166">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="71f0d-167">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="71f0d-167">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="71f0d-168">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="71f0d-168">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="71f0d-169">アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-169">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="71f0d-170">関連トピック</span><span class="sxs-lookup"><span data-stu-id="71f0d-170">Related topics</span></span>

* [<span data-ttu-id="71f0d-171">パッケージの段階的なロールアウト</span><span class="sxs-lookup"><span data-stu-id="71f0d-171">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="71f0d-172">Microsoft Store 送信 API を使用してパッケージのフライトの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="71f0d-172">Manage package flight submissions using the Microsoft Store submission API</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="71f0d-173">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="71f0d-173">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
