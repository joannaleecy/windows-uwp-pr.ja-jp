---
author: Xansky
description: アプリの申請に関するパッケージのロールアウトを停止するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請に関するロールアウトの停止
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, アプリの申請, 停止
ms.assetid: 4ce79fe3-deda-4d31-b938-d672c3869051
ms.localizationpriority: medium
ms.openlocfilehash: 90ebfa61fa200342e32beb87be6cd27ea11e8f40
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5514756"
---
# <a name="halt-the-rollout-for-an-app-submission"></a><span data-ttu-id="3c7a9-104">アプリの申請に関するロールアウトの停止</span><span class="sxs-lookup"><span data-stu-id="3c7a9-104">Halt the rollout for an app submission</span></span>


<span data-ttu-id="3c7a9-105">アプリの申請に関する[パッケージのロールアウトを停止する](../publish/gradual-package-rollout.md#completing-the-rollout)には、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-105">Use this method in the Microsoft Store submission API to [halt the package rollout](../publish/gradual-package-rollout.md#completing-the-rollout) for an app submission.</span></span> <span data-ttu-id="3c7a9-106">Microsoft Store 申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-106">For more information about the process of process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

> [!NOTE]
> <span data-ttu-id="3c7a9-107">アプリの申請に関するロールアウトを停止してから、[新しいアプリの申請を作成する](create-an-app-submission.md)場合、新しい申請は停止した申請を複製したものになります。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-107">If you halt the rollout for an app submission and then [create a new app submission](create-an-app-submission.md), the new submission is a clone of the halted submission.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="3c7a9-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="3c7a9-108">Prerequisites</span></span>

<span data-ttu-id="3c7a9-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3c7a9-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="3c7a9-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3c7a9-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3c7a9-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="3c7a9-114">デベロッパー センターのアカウントでアプリの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-114">Create a submission for an app in your Dev Center account.</span></span> <span data-ttu-id="3c7a9-115">この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-115">You can do this in the Dev Center dashboard, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>
* <span data-ttu-id="3c7a9-116">申請に関する段階的なパッケージのロールアウトを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-116">Enable a gradual package rollout for the submission.</span></span> <span data-ttu-id="3c7a9-117">これは、[デベロッパー センター ダッシュボード](../publish/gradual-package-rollout.md)で行うことも、[Microsoft Store 申請 API](manage-app-submissions.md#manage-gradual-package-rollout) を使って行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-117">You can do this in the [Dev Center dashboard](../publish/gradual-package-rollout.md), or you can do this by [using the Microsoft Store submission API](manage-app-submissions.md#manage-gradual-package-rollout).</span></span>

## <a name="request"></a><span data-ttu-id="3c7a9-118">要求</span><span class="sxs-lookup"><span data-stu-id="3c7a9-118">Request</span></span>

<span data-ttu-id="3c7a9-119">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-119">This method has the following syntax.</span></span> <span data-ttu-id="3c7a9-120">ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-120">See the following sections for usage examples and descriptions of the header and request parameters.</span></span>

| <span data-ttu-id="3c7a9-121">メソッド</span><span class="sxs-lookup"><span data-stu-id="3c7a9-121">Method</span></span> | <span data-ttu-id="3c7a9-122">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3c7a9-122">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="3c7a9-123">POST</span><span class="sxs-lookup"><span data-stu-id="3c7a9-123">POST</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/haltpackagerollout``` |


### <a name="request-header"></a><span data-ttu-id="3c7a9-124">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c7a9-124">Request header</span></span>

| <span data-ttu-id="3c7a9-125">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c7a9-125">Header</span></span>        | <span data-ttu-id="3c7a9-126">型</span><span class="sxs-lookup"><span data-stu-id="3c7a9-126">Type</span></span>   | <span data-ttu-id="3c7a9-127">説明</span><span class="sxs-lookup"><span data-stu-id="3c7a9-127">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3c7a9-128">Authorization</span><span class="sxs-lookup"><span data-stu-id="3c7a9-128">Authorization</span></span> | <span data-ttu-id="3c7a9-129">string</span><span class="sxs-lookup"><span data-stu-id="3c7a9-129">string</span></span> | <span data-ttu-id="3c7a9-130">必須。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-130">Required.</span></span> <span data-ttu-id="3c7a9-131">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-131">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="3c7a9-132">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c7a9-132">Request parameters</span></span>

| <span data-ttu-id="3c7a9-133">名前</span><span class="sxs-lookup"><span data-stu-id="3c7a9-133">Name</span></span>        | <span data-ttu-id="3c7a9-134">種類</span><span class="sxs-lookup"><span data-stu-id="3c7a9-134">Type</span></span>   | <span data-ttu-id="3c7a9-135">説明</span><span class="sxs-lookup"><span data-stu-id="3c7a9-135">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3c7a9-136">applicationId</span><span class="sxs-lookup"><span data-stu-id="3c7a9-136">applicationId</span></span> | <span data-ttu-id="3c7a9-137">string</span><span class="sxs-lookup"><span data-stu-id="3c7a9-137">string</span></span> | <span data-ttu-id="3c7a9-138">必須。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-138">Required.</span></span> <span data-ttu-id="3c7a9-139">停止するパッケージのロールアウトの対象となる申請が含まれているアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-139">The Store ID of the app that contains the submission with the package rollout you want to halt.</span></span> <span data-ttu-id="3c7a9-140">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-140">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="3c7a9-141">submissionId</span><span class="sxs-lookup"><span data-stu-id="3c7a9-141">submissionId</span></span> | <span data-ttu-id="3c7a9-142">string</span><span class="sxs-lookup"><span data-stu-id="3c7a9-142">string</span></span> | <span data-ttu-id="3c7a9-143">必須。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-143">Required.</span></span> <span data-ttu-id="3c7a9-144">停止するパッケージのロールアウトの対象となる申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-144">The ID of the submission with the package rollout you want to halt.</span></span> <span data-ttu-id="3c7a9-145">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-145">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="3c7a9-146">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-146">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="3c7a9-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="3c7a9-147">Request body</span></span>

<span data-ttu-id="3c7a9-148">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-148">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="3c7a9-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="3c7a9-149">Request example</span></span>

<span data-ttu-id="3c7a9-150">アプリの申請に関するパッケージのロールアウトを停止する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-150">The following example demonstrates how to halt the package rollout for an app submission.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243680/haltpackagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="3c7a9-151">応答</span><span class="sxs-lookup"><span data-stu-id="3c7a9-151">Response</span></span>

<span data-ttu-id="3c7a9-152">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-152">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="3c7a9-153">応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-153">For more details about the values in the response body, see [Package rollout resource](manage-app-submissions.md#package-rollout-object).</span></span>

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutStopped",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a><span data-ttu-id="3c7a9-154">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3c7a9-154">Error codes</span></span>

<span data-ttu-id="3c7a9-155">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-155">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="3c7a9-156">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3c7a9-156">Error code</span></span> |  <span data-ttu-id="3c7a9-157">説明</span><span class="sxs-lookup"><span data-stu-id="3c7a9-157">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="3c7a9-158">404</span><span class="sxs-lookup"><span data-stu-id="3c7a9-158">404</span></span>  | <span data-ttu-id="3c7a9-159">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-159">The submission could not be found.</span></span> |
| <span data-ttu-id="3c7a9-160">409</span><span class="sxs-lookup"><span data-stu-id="3c7a9-160">409</span></span>  | <span data-ttu-id="3c7a9-161">このコードは、次のエラーのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-161">This code indicates one of the following errors:</span></span><br/><br/><ul><li><span data-ttu-id="3c7a9-162">申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-app-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-162">The submission is not in a valid state for the gradual rollout operation (before calling this method, the submission must be published and the [packageRolloutStatus](manage-app-submissions.md#package-rollout-object) value must be set to **PackageRolloutInProgress**).</span></span></li><li><span data-ttu-id="3c7a9-163">申請が、指定されたアプリに属していません。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-163">The submission does not belong to the specified app.</span></span></li><li><span data-ttu-id="3c7a9-164">アプリが、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能を使用しています。</span><span class="sxs-lookup"><span data-stu-id="3c7a9-164">The app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span></li></ul> |   


## <a name="related-topics"></a><span data-ttu-id="3c7a9-165">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3c7a9-165">Related topics</span></span>

* [<span data-ttu-id="3c7a9-166">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="3c7a9-166">Gradual package rollout</span></span>](../publish/gradual-package-rollout.md)
* [<span data-ttu-id="3c7a9-167">Microsoft Store 申請 API を使用したアプリの申請の管理</span><span class="sxs-lookup"><span data-stu-id="3c7a9-167">Manage app submissions using the Microsoft Store submission API</span></span>](manage-app-submissions.md)
* [<span data-ttu-id="3c7a9-168">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="3c7a9-168">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
