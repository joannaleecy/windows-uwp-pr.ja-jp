---
author: mcleanbyron
description: "パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの申請に関するロールアウトの情報を取得する"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, パッケージのロールアウト, フライトの申請"
ms.assetid: 397f1b99-2be7-4f65-bcf1-9433a3d496ad
ms.openlocfilehash: f9245f5887521535da77c5d7e4d795e15ce8d2b4
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="get-rollout-info-for-a-flight-submission"></a><span data-ttu-id="f6f11-104">パッケージ フライトの申請に関するロールアウトの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="f6f11-104">Get rollout info for a flight submission</span></span>


<span data-ttu-id="f6f11-105">パッケージ フライトの申請に関する[パッケージのロールアウト](../publish/gradual-package-rollout.md)の情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="f6f11-105">Use this method in the Windows Store submission API to get [package rollout](../publish/gradual-package-rollout.md) info for a package flight submission.</span></span> <span data-ttu-id="f6f11-106">Windows ストア申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f6f11-106">For more information about the process of process of creating a package flight submission by using the Windows Store submission API, see [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f6f11-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="f6f11-107">Prerequisites</span></span>

<span data-ttu-id="f6f11-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6f11-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="f6f11-109">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f6f11-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="f6f11-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f6f11-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="f6f11-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f6f11-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f6f11-112">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f6f11-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="f6f11-113">デベロッパー センターのアカウントでアプリのパッケージ フライトの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="f6f11-113">Create a package flight submission for an app in your Dev Center account.</span></span> <span data-ttu-id="f6f11-114">これは、デベロッパー センターのダッシュボードで行うことも、[パッケージ フライトの申請の作成](create-a-flight-submission.md)メソッドを使って行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="f6f11-114">You can do this in the Dev Center dashboard, or you can do this by using the [create a package flight submission](create-a-flight-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="f6f11-115">要求</span><span class="sxs-lookup"><span data-stu-id="f6f11-115">Request</span></span>

<span data-ttu-id="f6f11-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f6f11-116">This method has the following syntax.</span></span> <span data-ttu-id="f6f11-117">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f6f11-117">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="f6f11-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="f6f11-118">Method</span></span> | <span data-ttu-id="f6f11-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f6f11-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="f6f11-120">GET</span><span class="sxs-lookup"><span data-stu-id="f6f11-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout   ``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="f6f11-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f6f11-121">Request header</span></span>

| <span data-ttu-id="f6f11-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f6f11-122">Header</span></span>        | <span data-ttu-id="f6f11-123">型</span><span class="sxs-lookup"><span data-stu-id="f6f11-123">Type</span></span>   | <span data-ttu-id="f6f11-124">説明</span><span class="sxs-lookup"><span data-stu-id="f6f11-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f6f11-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="f6f11-125">Authorization</span></span> | <span data-ttu-id="f6f11-126">string</span><span class="sxs-lookup"><span data-stu-id="f6f11-126">string</span></span> | <span data-ttu-id="f6f11-127">必須。</span><span class="sxs-lookup"><span data-stu-id="f6f11-127">Required.</span></span> <span data-ttu-id="f6f11-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f6f11-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="f6f11-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6f11-129">Request parameters</span></span>

| <span data-ttu-id="f6f11-130">名前</span><span class="sxs-lookup"><span data-stu-id="f6f11-130">Name</span></span>        | <span data-ttu-id="f6f11-131">種類</span><span class="sxs-lookup"><span data-stu-id="f6f11-131">Type</span></span>   | <span data-ttu-id="f6f11-132">説明</span><span class="sxs-lookup"><span data-stu-id="f6f11-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f6f11-133">applicationId</span><span class="sxs-lookup"><span data-stu-id="f6f11-133">applicationId</span></span> | <span data-ttu-id="f6f11-134">string</span><span class="sxs-lookup"><span data-stu-id="f6f11-134">string</span></span> | <span data-ttu-id="f6f11-135">必須。</span><span class="sxs-lookup"><span data-stu-id="f6f11-135">Required.</span></span> <span data-ttu-id="f6f11-136">取得するパッケージのロールアウトの情報を持つパッケージ フライトの申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="f6f11-136">The Store ID of the app that contains the package flight submission with the package rollout info you want to get.</span></span> <span data-ttu-id="f6f11-137">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f6f11-137">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="f6f11-138">flightId</span><span class="sxs-lookup"><span data-stu-id="f6f11-138">flightId</span></span> | <span data-ttu-id="f6f11-139">string</span><span class="sxs-lookup"><span data-stu-id="f6f11-139">string</span></span> | <span data-ttu-id="f6f11-140">必須。</span><span class="sxs-lookup"><span data-stu-id="f6f11-140">Required.</span></span> <span data-ttu-id="f6f11-141">取得するパッケージのロールアウトの情報を持つ申請が含まれているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="f6f11-141">The ID of the package flight that contains the submission with the package rollout info you want to get.</span></span> <span data-ttu-id="f6f11-142">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="f6f11-142">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |
| <span data-ttu-id="f6f11-143">submissionId</span><span class="sxs-lookup"><span data-stu-id="f6f11-143">submissionId</span></span> | <span data-ttu-id="f6f11-144">string</span><span class="sxs-lookup"><span data-stu-id="f6f11-144">string</span></span> | <span data-ttu-id="f6f11-145">必須。</span><span class="sxs-lookup"><span data-stu-id="f6f11-145">Required.</span></span> <span data-ttu-id="f6f11-146">取得するパッケージのロールアウトの情報を持つ申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="f6f11-146">The ID of the submission with the package rollout info to get.</span></span> <span data-ttu-id="f6f11-147">この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求の応答データに含まれています。</span><span class="sxs-lookup"><span data-stu-id="f6f11-147">This ID is available in the Dev Center dashboard, and it is included in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="f6f11-148">要求本文</span><span class="sxs-lookup"><span data-stu-id="f6f11-148">Request body</span></span>

<span data-ttu-id="f6f11-149">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="f6f11-149">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="f6f11-150">要求の例</span><span class="sxs-lookup"><span data-stu-id="f6f11-150">Request example</span></span>

<span data-ttu-id="f6f11-151">パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f6f11-151">The following example demonstrates how to get the package rollout info for a package flight submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/packagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f6f11-152">応答</span><span class="sxs-lookup"><span data-stu-id="f6f11-152">Response</span></span>

<span data-ttu-id="f6f11-153">次の例は、段階的なパッケージのロールアウトが有効になっているパッケージ フライトの申請に対して、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="f6f11-153">The following example demonstrates the JSON response body for a successful call to this method for a package flight submission with gradual package rollout enabled.</span></span> <span data-ttu-id="f6f11-154">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f6f11-154">For more details about the values in the response body, see [Package rollout resource](manage-flight-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

<span data-ttu-id="f6f11-155">パッケージ フライトの申請で段階的なパッケージのロールアウトが有効になっていない場合は、次の応答の本文が返されます。</span><span class="sxs-lookup"><span data-stu-id="f6f11-155">If the package flight submission does not have gradual package rollout enabled, the following response body will be returned.</span></span>

```json
{
    "isPackageRollout": false,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutNotStarted",
    "fallbackSubmissionId": "0"
}
```

## <a name="error-codes"></a><span data-ttu-id="f6f11-156">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f6f11-156">Error codes</span></span>

<span data-ttu-id="f6f11-157">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="f6f11-157">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="f6f11-158">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f6f11-158">Error code</span></span> |  <span data-ttu-id="f6f11-159">説明</span><span class="sxs-lookup"><span data-stu-id="f6f11-159">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="f6f11-160">404</span><span class="sxs-lookup"><span data-stu-id="f6f11-160">404</span></span>  | <span data-ttu-id="f6f11-161">パッケージ フライトの申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="f6f11-161">The package flight submission could not be found.</span></span> |
| <span data-ttu-id="f6f11-162">409</span><span class="sxs-lookup"><span data-stu-id="f6f11-162">409</span></span>  | <span data-ttu-id="f6f11-163">指定されたパッケージ フライトにパッケージ フライトの申請が属していないか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能をアプリが使用しています。</span><span class="sxs-lookup"><span data-stu-id="f6f11-163">The package flight submission does not belong to the specified package flight, or the app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   

<span/>


## <a name="related-topics"></a><span data-ttu-id="f6f11-164">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f6f11-164">Related topics</span></span>

* [<span data-ttu-id="f6f11-165">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="f6f11-165">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="f6f11-166">Windows ストア申請 API を使用したパッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="f6f11-166">Manage package flight submissions using the Windows Store submission API</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="f6f11-167">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="f6f11-167">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
