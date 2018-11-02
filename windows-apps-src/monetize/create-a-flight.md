---
author: Xansky
ms.assetid: 8C1E9E36-13AF-4386-9D0F-F9CB320F02F5
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトを作成する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの作成
ms.author: mhopkins
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの作成
ms.localizationpriority: medium
ms.openlocfilehash: 1e7fec507497784849bdda76ed0fdd4993181731
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5977562"
---
# <a name="create-a-package-flight"></a><span data-ttu-id="4f85b-104">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="4f85b-104">Create a package flight</span></span>

<span data-ttu-id="4f85b-105">パートナー センター アカウントに登録されているアプリのパッケージ フライトを作成する、Microsoft Store 申請 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="4f85b-105">Use this method in the Microsoft Store submission API to create a package flight for an app that is registered to your Partner Center account.</span></span>

> [!NOTE]
> <span data-ttu-id="4f85b-106">このメソッドは、申請なしでパッケージ フライトを作成します。</span><span class="sxs-lookup"><span data-stu-id="4f85b-106">This method creates a package flight without any submissions.</span></span> <span data-ttu-id="4f85b-107">パッケージ フライトの申請を作成するには、「[パッケージ フライト申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-107">To create a submission for package flight, see the methods in [Manage package flight submissions](manage-flight-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4f85b-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="4f85b-108">Prerequisites</span></span>

<span data-ttu-id="4f85b-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f85b-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="4f85b-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="4f85b-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="4f85b-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="4f85b-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="4f85b-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="4f85b-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="4f85b-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4f85b-113">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="4f85b-114">要求</span><span class="sxs-lookup"><span data-stu-id="4f85b-114">Request</span></span>

<span data-ttu-id="4f85b-115">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4f85b-115">This method has the following syntax.</span></span> <span data-ttu-id="4f85b-116">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-116">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="4f85b-117">メソッド</span><span class="sxs-lookup"><span data-stu-id="4f85b-117">Method</span></span> | <span data-ttu-id="4f85b-118">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4f85b-118">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="4f85b-119">POST</span><span class="sxs-lookup"><span data-stu-id="4f85b-119">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights``` |


### <a name="request-header"></a><span data-ttu-id="4f85b-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4f85b-120">Request header</span></span>

| <span data-ttu-id="4f85b-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4f85b-121">Header</span></span>        | <span data-ttu-id="4f85b-122">型</span><span class="sxs-lookup"><span data-stu-id="4f85b-122">Type</span></span>   | <span data-ttu-id="4f85b-123">説明</span><span class="sxs-lookup"><span data-stu-id="4f85b-123">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="4f85b-124">Authorization</span><span class="sxs-lookup"><span data-stu-id="4f85b-124">Authorization</span></span> | <span data-ttu-id="4f85b-125">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-125">string</span></span> | <span data-ttu-id="4f85b-126">必須。</span><span class="sxs-lookup"><span data-stu-id="4f85b-126">Required.</span></span> <span data-ttu-id="4f85b-127">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="4f85b-127">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="4f85b-128">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="4f85b-128">Request parameters</span></span>

| <span data-ttu-id="4f85b-129">名前</span><span class="sxs-lookup"><span data-stu-id="4f85b-129">Name</span></span>        | <span data-ttu-id="4f85b-130">種類</span><span class="sxs-lookup"><span data-stu-id="4f85b-130">Type</span></span>   | <span data-ttu-id="4f85b-131">説明</span><span class="sxs-lookup"><span data-stu-id="4f85b-131">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="4f85b-132">applicationId</span><span class="sxs-lookup"><span data-stu-id="4f85b-132">applicationId</span></span> | <span data-ttu-id="4f85b-133">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-133">string</span></span> | <span data-ttu-id="4f85b-134">必須。</span><span class="sxs-lookup"><span data-stu-id="4f85b-134">Required.</span></span> <span data-ttu-id="4f85b-135">パッケージ フライトを作成するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="4f85b-135">The Store ID of the app for which you want to create a package flight.</span></span> <span data-ttu-id="4f85b-136">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-136">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |


### <a name="request-body"></a><span data-ttu-id="4f85b-137">要求本文</span><span class="sxs-lookup"><span data-stu-id="4f85b-137">Request body</span></span>

<span data-ttu-id="4f85b-138">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="4f85b-138">The request body has the following parameters.</span></span>

|  <span data-ttu-id="4f85b-139">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4f85b-139">Parameter</span></span>  |  <span data-ttu-id="4f85b-140">型</span><span class="sxs-lookup"><span data-stu-id="4f85b-140">Type</span></span>  |  <span data-ttu-id="4f85b-141">説明</span><span class="sxs-lookup"><span data-stu-id="4f85b-141">Description</span></span>  |  <span data-ttu-id="4f85b-142">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="4f85b-142">Required</span></span>  |
|------|------|------|------|
|  <span data-ttu-id="4f85b-143">friendlyName</span><span class="sxs-lookup"><span data-stu-id="4f85b-143">friendlyName</span></span>  |  <span data-ttu-id="4f85b-144">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-144">string</span></span>  |  <span data-ttu-id="4f85b-145">開発者によって指定されているパッケージ フライトの名前。</span><span class="sxs-lookup"><span data-stu-id="4f85b-145">The name of the package flight, as specified by the developer.</span></span>  |  <span data-ttu-id="4f85b-146">いいえ</span><span class="sxs-lookup"><span data-stu-id="4f85b-146">No</span></span>  |
|  <span data-ttu-id="4f85b-147">groupIds</span><span class="sxs-lookup"><span data-stu-id="4f85b-147">groupIds</span></span>  |  <span data-ttu-id="4f85b-148">array</span><span class="sxs-lookup"><span data-stu-id="4f85b-148">array</span></span>  |  <span data-ttu-id="4f85b-149">パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="4f85b-149">An array of strings that contain the IDs of the flight groups that are associated with the package flight.</span></span> <span data-ttu-id="4f85b-150">フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-150">For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>  |  <span data-ttu-id="4f85b-151">いいえ</span><span class="sxs-lookup"><span data-stu-id="4f85b-151">No</span></span>  |
|  <span data-ttu-id="4f85b-152">rankHigherThan</span><span class="sxs-lookup"><span data-stu-id="4f85b-152">rankHigherThan</span></span>  |  <span data-ttu-id="4f85b-153">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-153">string</span></span>  |  <span data-ttu-id="4f85b-154">現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="4f85b-154">The friendly name of the package flight that is ranked immediately lower than the current package flight.</span></span> <span data-ttu-id="4f85b-155">このパラメーターを設定しない場合、新しいパッケージ フライトの順位は、すべてのパッケージ フライトで最も高くなります。</span><span class="sxs-lookup"><span data-stu-id="4f85b-155">If you do not set this parameter, the new package flight will have the highest rank of all package flights.</span></span> <span data-ttu-id="4f85b-156">フライト グループの順位について詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-156">For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>    |  <span data-ttu-id="4f85b-157">いいえ</span><span class="sxs-lookup"><span data-stu-id="4f85b-157">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="4f85b-158">要求の例</span><span class="sxs-lookup"><span data-stu-id="4f85b-158">Request example</span></span>

<span data-ttu-id="4f85b-159">次の例は、ストア ID 9WZDNCRD911W を持つアプリの新しいパッケージ フライトを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f85b-159">The following example demonstrates how to create a new package flight for an app that has the Store ID 9WZDNCRD911W.</span></span>

```syntax
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q...
Content-Type: application/json
{
  "friendlyName": "myflight",
  "groupIds": [
    0
  ],
  "rankHigherThan": null
}

```

## <a name="response"></a><span data-ttu-id="4f85b-160">応答</span><span class="sxs-lookup"><span data-stu-id="4f85b-160">Response</span></span>

<span data-ttu-id="4f85b-161">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f85b-161">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="4f85b-162">応答本文の値について詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-162">For more details about the values in the response body, see the following sections.</span></span>

```json
{
  "flightId": "43e448df-97c9-4a43-a0bc-2a445e736bcd",
  "friendlyName": "myflight",
  "groupIds": [
    "0"
  ],
  "rankHigherThan": "671c2857-725e-4faf-9e9e-ea1191ef879c"
}
```

### <a name="response-body"></a><span data-ttu-id="4f85b-163">応答本文</span><span class="sxs-lookup"><span data-stu-id="4f85b-163">Response body</span></span>

| <span data-ttu-id="4f85b-164">値</span><span class="sxs-lookup"><span data-stu-id="4f85b-164">Value</span></span>      | <span data-ttu-id="4f85b-165">型</span><span class="sxs-lookup"><span data-stu-id="4f85b-165">Type</span></span>   | <span data-ttu-id="4f85b-166">説明</span><span class="sxs-lookup"><span data-stu-id="4f85b-166">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="4f85b-167">flightId</span><span class="sxs-lookup"><span data-stu-id="4f85b-167">flightId</span></span>            | <span data-ttu-id="4f85b-168">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-168">string</span></span>  | <span data-ttu-id="4f85b-169">パッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="4f85b-169">The ID for the package flight.</span></span> <span data-ttu-id="4f85b-170">この値は、パートナー センターによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="4f85b-170">This value is supplied by Partner Center.</span></span>  |
| <span data-ttu-id="4f85b-171">friendlyName</span><span class="sxs-lookup"><span data-stu-id="4f85b-171">friendlyName</span></span>           | <span data-ttu-id="4f85b-172">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-172">string</span></span>  | <span data-ttu-id="4f85b-173">要求で指定されているパッケージ フライトの名前。</span><span class="sxs-lookup"><span data-stu-id="4f85b-173">The name of the package flight, as specified in the request.</span></span>   |  
| <span data-ttu-id="4f85b-174">groupIds</span><span class="sxs-lookup"><span data-stu-id="4f85b-174">groupIds</span></span>           | <span data-ttu-id="4f85b-175">array</span><span class="sxs-lookup"><span data-stu-id="4f85b-175">array</span></span>  | <span data-ttu-id="4f85b-176">要求で指定されている、パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="4f85b-176">An array of strings that contain the IDs of the flight groups that are associated with the package flight, as specified in the request.</span></span> <span data-ttu-id="4f85b-177">フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-177">For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>   |
| <span data-ttu-id="4f85b-178">rankHigherThan</span><span class="sxs-lookup"><span data-stu-id="4f85b-178">rankHigherThan</span></span>           | <span data-ttu-id="4f85b-179">string</span><span class="sxs-lookup"><span data-stu-id="4f85b-179">string</span></span>  | <span data-ttu-id="4f85b-180">要求で指定されている、現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="4f85b-180">The friendly name of the package flight that is ranked immediately lower than the current package flight, as specified in the request.</span></span> <span data-ttu-id="4f85b-181">フライト グループの順位について詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f85b-181">For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>  |


## <a name="error-codes"></a><span data-ttu-id="4f85b-182">エラー コード</span><span class="sxs-lookup"><span data-stu-id="4f85b-182">Error codes</span></span>

<span data-ttu-id="4f85b-183">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="4f85b-183">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="4f85b-184">エラー コード</span><span class="sxs-lookup"><span data-stu-id="4f85b-184">Error code</span></span> |  <span data-ttu-id="4f85b-185">説明</span><span class="sxs-lookup"><span data-stu-id="4f85b-185">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="4f85b-186">400</span><span class="sxs-lookup"><span data-stu-id="4f85b-186">400</span></span>  | <span data-ttu-id="4f85b-187">要求が無効です。</span><span class="sxs-lookup"><span data-stu-id="4f85b-187">The request is invalid.</span></span> |
| <span data-ttu-id="4f85b-188">409</span><span class="sxs-lookup"><span data-stu-id="4f85b-188">409</span></span>  | <span data-ttu-id="4f85b-189">現在の状態が原因パッケージ フライトを作成できませんでしたまたは[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能、アプリで使用します。</span><span class="sxs-lookup"><span data-stu-id="4f85b-189">The package flight could not be created because of its current state, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="4f85b-190">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4f85b-190">Related topics</span></span>

* [<span data-ttu-id="4f85b-191">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="4f85b-191">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="4f85b-192">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="4f85b-192">Get a package flight</span></span>](get-a-flight.md)
* [<span data-ttu-id="4f85b-193">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="4f85b-193">Delete a package flight</span></span>](delete-a-flight.md)
