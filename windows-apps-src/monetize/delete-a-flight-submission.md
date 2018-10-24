---
author: Xansky
ms.assetid: 1A69A388-B1CC-4D2C-886B-EA07E6E60252
description: 既存のパッケージ フライトの申請を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの申請の削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請, 削除, パッケージ フライト
ms.localizationpriority: medium
ms.openlocfilehash: 8618d93b1a6ec465a95956d01648444313cdf142
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5437913"
---
# <a name="delete-a-package-flight-submission"></a><span data-ttu-id="ad64c-104">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="ad64c-104">Delete a package flight submission</span></span>

<span data-ttu-id="ad64c-105">既存のパッケージ フライトの申請を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ad64c-105">Use this method in the Microsoft Store submission API to delete an existing package flight submission.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ad64c-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="ad64c-106">Prerequisites</span></span>

<span data-ttu-id="ad64c-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ad64c-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="ad64c-108">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="ad64c-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="ad64c-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="ad64c-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="ad64c-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="ad64c-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="ad64c-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ad64c-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="ad64c-112">要求</span><span class="sxs-lookup"><span data-stu-id="ad64c-112">Request</span></span>

<span data-ttu-id="ad64c-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ad64c-113">This method has the following syntax.</span></span> <span data-ttu-id="ad64c-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad64c-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="ad64c-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="ad64c-115">Method</span></span> | <span data-ttu-id="ad64c-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="ad64c-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="ad64c-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="ad64c-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/flights/{flightId}/submissions/{submissionId}``` |


### <a name="request-header"></a><span data-ttu-id="ad64c-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ad64c-118">Request header</span></span>

| <span data-ttu-id="ad64c-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ad64c-119">Header</span></span>        | <span data-ttu-id="ad64c-120">型</span><span class="sxs-lookup"><span data-stu-id="ad64c-120">Type</span></span>   | <span data-ttu-id="ad64c-121">説明</span><span class="sxs-lookup"><span data-stu-id="ad64c-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="ad64c-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="ad64c-122">Authorization</span></span> | <span data-ttu-id="ad64c-123">string</span><span class="sxs-lookup"><span data-stu-id="ad64c-123">string</span></span> | <span data-ttu-id="ad64c-124">必須。</span><span class="sxs-lookup"><span data-stu-id="ad64c-124">Required.</span></span> <span data-ttu-id="ad64c-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="ad64c-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="ad64c-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="ad64c-126">Request parameters</span></span>

| <span data-ttu-id="ad64c-127">名前</span><span class="sxs-lookup"><span data-stu-id="ad64c-127">Name</span></span>        | <span data-ttu-id="ad64c-128">種類</span><span class="sxs-lookup"><span data-stu-id="ad64c-128">Type</span></span>   | <span data-ttu-id="ad64c-129">説明</span><span class="sxs-lookup"><span data-stu-id="ad64c-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="ad64c-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="ad64c-130">applicationId</span></span> | <span data-ttu-id="ad64c-131">string</span><span class="sxs-lookup"><span data-stu-id="ad64c-131">string</span></span> | <span data-ttu-id="ad64c-132">必須。</span><span class="sxs-lookup"><span data-stu-id="ad64c-132">Required.</span></span> <span data-ttu-id="ad64c-133">削除するパッケージ フライトの申請が含まれるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="ad64c-133">The Store ID of the app that contains the package flight submission you want to delete.</span></span> <span data-ttu-id="ad64c-134">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad64c-134">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="ad64c-135">flightId</span><span class="sxs-lookup"><span data-stu-id="ad64c-135">flightId</span></span> | <span data-ttu-id="ad64c-136">string</span><span class="sxs-lookup"><span data-stu-id="ad64c-136">string</span></span> | <span data-ttu-id="ad64c-137">必須。</span><span class="sxs-lookup"><span data-stu-id="ad64c-137">Required.</span></span> <span data-ttu-id="ad64c-138">削除する申請が含まれるパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="ad64c-138">The ID of the package flight that contains the submission to delete.</span></span> <span data-ttu-id="ad64c-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="ad64c-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span> <span data-ttu-id="ad64c-140">デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="ad64c-140">For a flight that was created in the Dev Center dashboard, this ID is also available in the URL for the flight page in the dashboard.</span></span>  |
| <span data-ttu-id="ad64c-141">submissionId</span><span class="sxs-lookup"><span data-stu-id="ad64c-141">submissionId</span></span> | <span data-ttu-id="ad64c-142">string</span><span class="sxs-lookup"><span data-stu-id="ad64c-142">string</span></span> | <span data-ttu-id="ad64c-143">必須。</span><span class="sxs-lookup"><span data-stu-id="ad64c-143">Required.</span></span> <span data-ttu-id="ad64c-144">削除する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="ad64c-144">The ID of the submission to delete.</span></span> <span data-ttu-id="ad64c-145">この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="ad64c-145">This ID is available in the response data for requests to [create a package flight submission](create-a-flight-submission.md).</span></span> <span data-ttu-id="ad64c-146">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="ad64c-146">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="ad64c-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="ad64c-147">Request body</span></span>

<span data-ttu-id="ad64c-148">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="ad64c-148">Do not provide a request body for this method.</span></span>


### <a name="request-example"></a><span data-ttu-id="ad64c-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="ad64c-149">Request example</span></span>

<span data-ttu-id="ad64c-150">次の例は、パッケージ フライトの申請を削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ad64c-150">The following example demonstrates how to delete a submission for a package flight.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="ad64c-151">応答</span><span class="sxs-lookup"><span data-stu-id="ad64c-151">Response</span></span>

<span data-ttu-id="ad64c-152">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="ad64c-152">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="ad64c-153">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ad64c-153">Error codes</span></span>

<span data-ttu-id="ad64c-154">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad64c-154">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="ad64c-155">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ad64c-155">Error code</span></span> |  <span data-ttu-id="ad64c-156">説明</span><span class="sxs-lookup"><span data-stu-id="ad64c-156">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="ad64c-157">400</span><span class="sxs-lookup"><span data-stu-id="ad64c-157">400</span></span>  | <span data-ttu-id="ad64c-158">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="ad64c-158">The request parameters are invalid.</span></span> |
| <span data-ttu-id="ad64c-159">404</span><span class="sxs-lookup"><span data-stu-id="ad64c-159">404</span></span>  | <span data-ttu-id="ad64c-160">指定した申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ad64c-160">The specified submission could not be found.</span></span> |
| <span data-ttu-id="ad64c-161">409</span><span class="sxs-lookup"><span data-stu-id="ad64c-161">409</span></span>  | <span data-ttu-id="ad64c-162">指定した申請は見つかりましたが、現在の状態で削除できなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="ad64c-162">The specified submission was found but it could not be deleted in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |


## <a name="related-topics"></a><span data-ttu-id="ad64c-163">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ad64c-163">Related topics</span></span>

* [<span data-ttu-id="ad64c-164">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="ad64c-164">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="ad64c-165">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="ad64c-165">Manage package flight submissions</span></span>](manage-flight-submissions.md)
* [<span data-ttu-id="ad64c-166">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="ad64c-166">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="ad64c-167">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="ad64c-167">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="ad64c-168">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="ad64c-168">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="ad64c-169">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="ad64c-169">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="ad64c-170">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="ad64c-170">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
