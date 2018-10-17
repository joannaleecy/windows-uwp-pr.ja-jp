---
author: Xansky
ms.assetid: 4F9657E5-1AF8-45E0-9617-45AF64E144FC
description: Windows デベロッパー センター アカウントに登録されているアプリのアドオンを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: be0d383fc271084fe20a958d20f6fa3a340da187
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4744646"
---
# <a name="manage-add-ons"></a><span data-ttu-id="7ab84-104">アドオンの管理</span><span class="sxs-lookup"><span data-stu-id="7ab84-104">Manage add-ons</span></span>

<span data-ttu-id="7ab84-105">アプリのアドオンを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="7ab84-105">Use the following methods in the Microsoft Store submission API to manage add-ons for your apps.</span></span> <span data-ttu-id="7ab84-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="7ab84-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

<span data-ttu-id="7ab84-107">以下のメソッドは、アドオンの取得、作成、または削除にしか使用できません。</span><span class="sxs-lookup"><span data-stu-id="7ab84-107">These methods can only be used to get, create, or delete add-ons.</span></span> <span data-ttu-id="7ab84-108">アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ab84-108">To create submissions for add-ons, see the methods in [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="7ab84-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="7ab84-109">Method</span></span></th>
<th align="left"><span data-ttu-id="7ab84-110">URI</span><span class="sxs-lookup"><span data-stu-id="7ab84-110">URI</span></span></th>
<th align="left"><span data-ttu-id="7ab84-111">説明</span><span class="sxs-lookup"><span data-stu-id="7ab84-111">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="7ab84-112">GET</span><span class="sxs-lookup"><span data-stu-id="7ab84-112">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts</td>
<td align="left"><a href="get-all-add-ons.md"><span data-ttu-id="7ab84-113">アプリのすべてのアドオンを取得します</span><span class="sxs-lookup"><span data-stu-id="7ab84-113">Get all add-ons for your apps</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7ab84-114">GET</span><span class="sxs-lookup"><span data-stu-id="7ab84-114">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}</td>
<td align="left"><a href="get-an-add-on.md"><span data-ttu-id="7ab84-115">特定のアドオンを取得します</span><span class="sxs-lookup"><span data-stu-id="7ab84-115">Get a specific add-on</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7ab84-116">POST</span><span class="sxs-lookup"><span data-stu-id="7ab84-116">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts</td>
<td align="left"><a href="create-an-add-on.md"><span data-ttu-id="7ab84-117">アドオンを作成します</span><span class="sxs-lookup"><span data-stu-id="7ab84-117">Create an add-on</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7ab84-118">DELETE</span><span class="sxs-lookup"><span data-stu-id="7ab84-118">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}</td>
<td align="left"><a href="delete-an-add-on.md"><span data-ttu-id="7ab84-119">アドオンを削除します</span><span class="sxs-lookup"><span data-stu-id="7ab84-119">Delete an add-on</span></span></a></td>
</tr>
</tbody>
</table>

## <a name="prerequisites"></a><span data-ttu-id="7ab84-120">前提条件</span><span class="sxs-lookup"><span data-stu-id="7ab84-120">Prerequisites</span></span>

<span data-ttu-id="7ab84-121">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。</span><span class="sxs-lookup"><span data-stu-id="7ab84-121">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API before trying to use any of these methods.</span></span>

## <a name="data-resources"></a><span data-ttu-id="7ab84-122">データ リソース</span><span class="sxs-lookup"><span data-stu-id="7ab84-122">Data resources</span></span>

<span data-ttu-id="7ab84-123">アドオンを管理するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="7ab84-123">The Microsoft Store submission API methods for managing add-ons use the following JSON data resources.</span></span>

<span id="add-on-object" />

### <a name="add-on-resource"></a><span data-ttu-id="7ab84-124">アドオン リソース</span><span class="sxs-lookup"><span data-stu-id="7ab84-124">Add-on resource</span></span>

<span data-ttu-id="7ab84-125">このリソースは、アドオンを記述しています。</span><span class="sxs-lookup"><span data-stu-id="7ab84-125">This resource describes an add-on.</span></span>

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
  "id": "9NBLGGH4TNMP",
  "productId": "TestAddOn",
  "productType": "Durable",
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
  "lastPublishedInAppProductSubmission": {
    "id": "1152921504621243705",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243705"
  }
}
```

<span data-ttu-id="7ab84-126">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7ab84-126">This resource has the following values.</span></span>

| <span data-ttu-id="7ab84-127">値</span><span class="sxs-lookup"><span data-stu-id="7ab84-127">Value</span></span>      | <span data-ttu-id="7ab84-128">型</span><span class="sxs-lookup"><span data-stu-id="7ab84-128">Type</span></span>   | <span data-ttu-id="7ab84-129">説明</span><span class="sxs-lookup"><span data-stu-id="7ab84-129">Description</span></span>        |
|------------|--------|--------------|
| <span data-ttu-id="7ab84-130">applications</span><span class="sxs-lookup"><span data-stu-id="7ab84-130">applications</span></span>      | <span data-ttu-id="7ab84-131">array</span><span class="sxs-lookup"><span data-stu-id="7ab84-131">array</span></span>  | <span data-ttu-id="7ab84-132">このアドオンが関連付けられるアプリを表す 1 つの[アプリケーション リソース](#application-object)を格納する配列です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-132">An array that contains one [application resource](#application-object) that represents the app that this add-on is associated with.</span></span> <span data-ttu-id="7ab84-133">この配列でサポートされる項目は 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="7ab84-133">Only one item is supported in this array.</span></span>  |
| <span data-ttu-id="7ab84-134">id</span><span class="sxs-lookup"><span data-stu-id="7ab84-134">id</span></span> | <span data-ttu-id="7ab84-135">string</span><span class="sxs-lookup"><span data-stu-id="7ab84-135">string</span></span>  | <span data-ttu-id="7ab84-136">アドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-136">The Store ID of the add-on.</span></span> <span data-ttu-id="7ab84-137">この値は、ストアによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="7ab84-137">This value is supplied by the Store.</span></span> <span data-ttu-id="7ab84-138">ストア ID の例は 9NBLGGH4TNMP です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-138">An example Store ID is 9NBLGGH4TNMP.</span></span>  |
| <span data-ttu-id="7ab84-139">productId</span><span class="sxs-lookup"><span data-stu-id="7ab84-139">productId</span></span> | <span data-ttu-id="7ab84-140">string</span><span class="sxs-lookup"><span data-stu-id="7ab84-140">string</span></span>  | <span data-ttu-id="7ab84-141">アドオンの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-141">The product ID of the add-on.</span></span> <span data-ttu-id="7ab84-142">これは、アドオンの作成時に開発者が指定した ID です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-142">This is the ID that was provided by the developer when the add-on was created.</span></span> <span data-ttu-id="7ab84-143">詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ab84-143">For more information, see [Set your product type and product ID](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id).</span></span> |
| <span data-ttu-id="7ab84-144">productType</span><span class="sxs-lookup"><span data-stu-id="7ab84-144">productType</span></span> | <span data-ttu-id="7ab84-145">string</span><span class="sxs-lookup"><span data-stu-id="7ab84-145">string</span></span>  | <span data-ttu-id="7ab84-146">アドオンの製品の種類です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-146">The product type of the add-on.</span></span> <span data-ttu-id="7ab84-147">値 **Durable** と **Consumable** がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="7ab84-147">The following values are supported: **Durable** and **Consumable**.</span></span>  |
| <span data-ttu-id="7ab84-148">lastPublishedInAppProductSubmission</span><span class="sxs-lookup"><span data-stu-id="7ab84-148">lastPublishedInAppProductSubmission</span></span>       | <span data-ttu-id="7ab84-149">object</span><span class="sxs-lookup"><span data-stu-id="7ab84-149">object</span></span> | <span data-ttu-id="7ab84-150">アドオンの最後に公開された申請に関する情報を提供する[申請のリソース](#submission-object)。</span><span class="sxs-lookup"><span data-stu-id="7ab84-150">A [submission resource](#submission-object) that provides information about the last published submission for the add-on.</span></span>         |
| <span data-ttu-id="7ab84-151">pendingInAppProductSubmission</span><span class="sxs-lookup"><span data-stu-id="7ab84-151">pendingInAppProductSubmission</span></span>        | <span data-ttu-id="7ab84-152">object</span><span class="sxs-lookup"><span data-stu-id="7ab84-152">object</span></span>  |  <span data-ttu-id="7ab84-153">アドオンの現在保留中の申請に関する情報を提供する[申請のリソース](#submission-object)。</span><span class="sxs-lookup"><span data-stu-id="7ab84-153">A [submission resource](#submission-object) that provides information about the current pending submission for the add-on.</span></span>  |   |

<span id="application-object" />

### <a name="application-resource"></a><span data-ttu-id="7ab84-154">アプリケーション リソース</span><span class="sxs-lookup"><span data-stu-id="7ab84-154">Application resource</span></span>

<span data-ttu-id="7ab84-155">このリソースは、アドオンが関連付けられているアプリを説明します。</span><span class="sxs-lookup"><span data-stu-id="7ab84-155">This resource descries the app that an add-on is associated with.</span></span> <span data-ttu-id="7ab84-156">次の例は、このリソースの書式設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="7ab84-156">The following example demonstrates the format of this resource.</span></span>

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
}
```

<span data-ttu-id="7ab84-157">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7ab84-157">This resource has the following values.</span></span>

| <span data-ttu-id="7ab84-158">値</span><span class="sxs-lookup"><span data-stu-id="7ab84-158">Value</span></span>           | <span data-ttu-id="7ab84-159">型</span><span class="sxs-lookup"><span data-stu-id="7ab84-159">Type</span></span>    | <span data-ttu-id="7ab84-160">説明</span><span class="sxs-lookup"><span data-stu-id="7ab84-160">Description</span></span>        |
|-----------------|---------|-----------|
| <span data-ttu-id="7ab84-161">value</span><span class="sxs-lookup"><span data-stu-id="7ab84-161">value</span></span>            | <span data-ttu-id="7ab84-162">object</span><span class="sxs-lookup"><span data-stu-id="7ab84-162">object</span></span>  |  <span data-ttu-id="7ab84-163">次の値を格納するオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="7ab84-163">An object that contains the following values:</span></span> <br/><br/> <ul><li><span data-ttu-id="7ab84-164">*id*. アプリの Store ID です。</span><span class="sxs-lookup"><span data-stu-id="7ab84-164">*id*. The Store ID of the app.</span></span> <span data-ttu-id="7ab84-165">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ab84-165">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span></li><li><span data-ttu-id="7ab84-166">*resourceLocation*。</span><span class="sxs-lookup"><span data-stu-id="7ab84-166">*resourceLocation*.</span></span> <span data-ttu-id="7ab84-167">アプリの完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</span><span class="sxs-lookup"><span data-stu-id="7ab84-167">A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the app.</span></span></li></ul>   |
| <span data-ttu-id="7ab84-168">totalCount</span><span class="sxs-lookup"><span data-stu-id="7ab84-168">totalCount</span></span>   | <span data-ttu-id="7ab84-169">int</span><span class="sxs-lookup"><span data-stu-id="7ab84-169">int</span></span>  | <span data-ttu-id="7ab84-170">応答本文の *applications* 配列のアプリ オブジェクトの数。</span><span class="sxs-lookup"><span data-stu-id="7ab84-170">The number of app objects in the *applications* array of the response body.</span></span>                                                                                                                                                 |

<span id="submission-object" />

### <a name="submission-resource"></a><span data-ttu-id="7ab84-171">申請のリソース</span><span class="sxs-lookup"><span data-stu-id="7ab84-171">Submission resource</span></span>

<span data-ttu-id="7ab84-172">このリソースは、アドオンの申請に関する情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="7ab84-172">This resource provides information about a submission for an add-on.</span></span> <span data-ttu-id="7ab84-173">次の例は、このリソースの書式設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="7ab84-173">The following example demonstrates the format of this resource.</span></span>

```json
{
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
}
```

<span data-ttu-id="7ab84-174">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7ab84-174">This resource has the following values.</span></span>

| <span data-ttu-id="7ab84-175">値</span><span class="sxs-lookup"><span data-stu-id="7ab84-175">Value</span></span>           | <span data-ttu-id="7ab84-176">型</span><span class="sxs-lookup"><span data-stu-id="7ab84-176">Type</span></span>    | <span data-ttu-id="7ab84-177">説明</span><span class="sxs-lookup"><span data-stu-id="7ab84-177">Description</span></span>     |
|-----------------|---------|------------------|
| <span data-ttu-id="7ab84-178">id</span><span class="sxs-lookup"><span data-stu-id="7ab84-178">id</span></span>            | <span data-ttu-id="7ab84-179">string</span><span class="sxs-lookup"><span data-stu-id="7ab84-179">string</span></span>  | <span data-ttu-id="7ab84-180">申請 ID。</span><span class="sxs-lookup"><span data-stu-id="7ab84-180">The ID of the submission.</span></span>    |
| <span data-ttu-id="7ab84-181">resourceLocation</span><span class="sxs-lookup"><span data-stu-id="7ab84-181">resourceLocation</span></span>   | <span data-ttu-id="7ab84-182">string</span><span class="sxs-lookup"><span data-stu-id="7ab84-182">string</span></span>  | <span data-ttu-id="7ab84-183">申請の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</span><span class="sxs-lookup"><span data-stu-id="7ab84-183">A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the submission.</span></span>     |
 
<span/>

## <a name="related-topics"></a><span data-ttu-id="7ab84-184">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7ab84-184">Related topics</span></span>

* [<span data-ttu-id="7ab84-185">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="7ab84-185">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="7ab84-186">Microsoft Store 申請 API を使用したアドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="7ab84-186">Manage add-on submissions using the Microsoft Store submission API</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="7ab84-187">すべてのアドオンの取得</span><span class="sxs-lookup"><span data-stu-id="7ab84-187">Get all add-ons</span></span>](get-all-add-ons.md)
* [<span data-ttu-id="7ab84-188">アドオンの入手</span><span class="sxs-lookup"><span data-stu-id="7ab84-188">Get an add-on</span></span>](get-an-add-on.md)
* [<span data-ttu-id="7ab84-189">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="7ab84-189">Create an add-on</span></span>](create-an-add-on.md)
* [<span data-ttu-id="7ab84-190">アドオンの削除</span><span class="sxs-lookup"><span data-stu-id="7ab84-190">Delete an add-on</span></span>](delete-an-add-on.md)
