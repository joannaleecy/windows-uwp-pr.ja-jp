---
description: パッケージ フライトの申請に関するパッケージ ロールアウト率を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: フライトの申請に関するロールアウト率の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, フライトの申請, 更新, 割合
ms.assetid: ee9aa223-e945-4c11-b430-1f4b1e559743
ms.localizationpriority: medium
ms.openlocfilehash: 025db5cb0beb36a5b4a3ca1b765b5da3434c9d7a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57638977"
---
# <a name="update-the-rollout-percentage-for-a-flight-submission"></a><span data-ttu-id="d3b64-104">フライトの申請に関するロールアウト率の更新</span><span class="sxs-lookup"><span data-stu-id="d3b64-104">Update the rollout percentage for a flight submission</span></span>


<span data-ttu-id="d3b64-105">パッケージ フライトの申請に関する[パッケージ ロールアウト率を更新する](../publish/gradual-package-rollout.md#setting-the-rollout-percentage)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d3b64-105">Use this method in the Microsoft Store submission API to [update the rollout percentage](../publish/gradual-package-rollout.md#setting-the-rollout-percentage) for a package flight submission.</span></span> <span data-ttu-id="d3b64-106">Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d3b64-106">For more information about the process of process of creating a package flight submission by using the Microsoft Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d3b64-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="d3b64-107">Prerequisites</span></span>

<span data-ttu-id="d3b64-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d3b64-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d3b64-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d3b64-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="d3b64-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d3b64-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d3b64-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d3b64-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d3b64-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="d3b64-113">アプリのいずれかの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-113">Create a submission for one of your apps.</span></span> <span data-ttu-id="d3b64-114">パートナー センターでこれを行うかを使用してこれを行う、[アプリの提出を作成](create-an-app-submission.md)メソッド。</span><span class="sxs-lookup"><span data-stu-id="d3b64-114">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="d3b64-115">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="d3b64-115">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="d3b64-116">これを行うことができます[パートナー センターで](../publish/gradual-package-rollout.md)、これを行うまたは[Microsoft Store 送信 API を使用して](manage-flight-submissions.md#manage-gradual-package-rollout)します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-116">You can do this [in Partner Center](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-flight-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="d3b64-117">要求</span><span class="sxs-lookup"><span data-stu-id="d3b64-117">Request</span></span>

<span data-ttu-id="d3b64-118">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d3b64-118">This method has the following syntax.</span></span> <span data-ttu-id="d3b64-119">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d3b64-119">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="d3b64-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="d3b64-120">Method</span></span> | <span data-ttu-id="d3b64-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d3b64-121">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="d3b64-122">POST</span><span class="sxs-lookup"><span data-stu-id="d3b64-122">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/updatepackagerolloutpercentage``` |


### <a name="request-header"></a><span data-ttu-id="d3b64-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d3b64-123">Request header</span></span>

| <span data-ttu-id="d3b64-124">Header</span><span class="sxs-lookup"><span data-stu-id="d3b64-124">Header</span></span>        | <span data-ttu-id="d3b64-125">種類</span><span class="sxs-lookup"><span data-stu-id="d3b64-125">Type</span></span>   | <span data-ttu-id="d3b64-126">説明</span><span class="sxs-lookup"><span data-stu-id="d3b64-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d3b64-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="d3b64-127">Authorization</span></span> | <span data-ttu-id="d3b64-128">string</span><span class="sxs-lookup"><span data-stu-id="d3b64-128">string</span></span> | <span data-ttu-id="d3b64-129">必須。</span><span class="sxs-lookup"><span data-stu-id="d3b64-129">Required.</span></span> <span data-ttu-id="d3b64-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d3b64-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d3b64-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d3b64-131">Request parameters</span></span>

| <span data-ttu-id="d3b64-132">名前</span><span class="sxs-lookup"><span data-stu-id="d3b64-132">Name</span></span>        | <span data-ttu-id="d3b64-133">種類</span><span class="sxs-lookup"><span data-stu-id="d3b64-133">Type</span></span>   | <span data-ttu-id="d3b64-134">説明</span><span class="sxs-lookup"><span data-stu-id="d3b64-134">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d3b64-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="d3b64-135">applicationId</span></span> | <span data-ttu-id="d3b64-136">string</span><span class="sxs-lookup"><span data-stu-id="d3b64-136">string</span></span> | <span data-ttu-id="d3b64-137">必須。</span><span class="sxs-lookup"><span data-stu-id="d3b64-137">Required.</span></span> <span data-ttu-id="d3b64-138">パッケージ ロールアウト率を更新する対象のパッケージ フライト申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="d3b64-138">The Store ID of the app that contains the package flight submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="d3b64-139">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d3b64-139">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="d3b64-140">flightId</span><span class="sxs-lookup"><span data-stu-id="d3b64-140">flightId</span></span> | <span data-ttu-id="d3b64-141">string</span><span class="sxs-lookup"><span data-stu-id="d3b64-141">string</span></span> | <span data-ttu-id="d3b64-142">必須。</span><span class="sxs-lookup"><span data-stu-id="d3b64-142">Required.</span></span> <span data-ttu-id="d3b64-143">パッケージ ロールアウト率を更新する対象の申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="d3b64-143">The ID of the package flight that contains the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="d3b64-144">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d3b64-144">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="d3b64-145">パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="d3b64-145">For a flight that was created in Partner Center, this ID is also available in the URL for the flight page in Partner Center.</span></span>  |
| <span data-ttu-id="d3b64-146">submissionId</span><span class="sxs-lookup"><span data-stu-id="d3b64-146">submissionId</span></span> | <span data-ttu-id="d3b64-147">string</span><span class="sxs-lookup"><span data-stu-id="d3b64-147">string</span></span> | <span data-ttu-id="d3b64-148">必須。</span><span class="sxs-lookup"><span data-stu-id="d3b64-148">Required.</span></span> <span data-ttu-id="d3b64-149">パッケージ ロールアウト率を更新する対象の申請の ID。</span><span class="sxs-lookup"><span data-stu-id="d3b64-149">The ID of the submission with the package rollout percentage you want to update.</span></span> <span data-ttu-id="d3b64-150">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d3b64-150">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="d3b64-151">パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。</span><span class="sxs-lookup"><span data-stu-id="d3b64-151">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |
| <span data-ttu-id="d3b64-152">percentage</span><span class="sxs-lookup"><span data-stu-id="d3b64-152">percentage</span></span>  |  <span data-ttu-id="d3b64-153">float</span><span class="sxs-lookup"><span data-stu-id="d3b64-153">float</span></span>  |  <span data-ttu-id="d3b64-154">必須。</span><span class="sxs-lookup"><span data-stu-id="d3b64-154">Required.</span></span> <span data-ttu-id="d3b64-155">段階的なロールアウト パッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="d3b64-155">The percentage of users who will receive the gradual rollout package.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="d3b64-156">要求本文</span><span class="sxs-lookup"><span data-stu-id="d3b64-156">Request body</span></span>

<span data-ttu-id="d3b64-157">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="d3b64-157">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="d3b64-158">要求の例</span><span class="sxs-lookup"><span data-stu-id="d3b64-158">Request example</span></span>

<span data-ttu-id="d3b64-159">パッケージ フライト申請のパッケージ ロールアウト率を更新する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-159">The following example demonstrates how to update the package rollout percentage for a package flight submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243680/updatepackagerolloutpercentage?percentage=25 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d3b64-160">応答</span><span class="sxs-lookup"><span data-stu-id="d3b64-160">Response</span></span>

<span data-ttu-id="d3b64-161">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="d3b64-161">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="d3b64-162">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d3b64-162">For more details about the values in the response body, see [Package rollout resource](manage-flight-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="d3b64-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d3b64-163">Error codes</span></span>

<span data-ttu-id="d3b64-164">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="d3b64-164">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="d3b64-165">エラー コード</span><span class="sxs-lookup"><span data-stu-id="d3b64-165">Error code</span></span> |  <span data-ttu-id="d3b64-166">説明</span><span class="sxs-lookup"><span data-stu-id="d3b64-166">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="d3b64-167">404</span><span class="sxs-lookup"><span data-stu-id="d3b64-167">404</span></span>  | <span data-ttu-id="d3b64-168">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d3b64-168">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="d3b64-169">409</span><span class="sxs-lookup"><span data-stu-id="d3b64-169">409</span></span>  | <span data-ttu-id="d3b64-170">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-170">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="d3b64-171">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="d3b64-171">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="d3b64-172">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="d3b64-172">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="d3b64-173">アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-173">The app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="d3b64-174">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d3b64-174">Related topics</span></span>

* [<span data-ttu-id="d3b64-175">パッケージの段階的なロールアウト</span><span class="sxs-lookup"><span data-stu-id="d3b64-175">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="d3b64-176">Microsoft Store 送信 API を使用してパッケージのフライトの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="d3b64-176">Manage package flight submissions using the Microsoft Store submission API</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="d3b64-177">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="d3b64-177">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
