---
ms.assetid: 3569C505-8D8C-4D85-B383-4839F13B2466
description: Microsoft Store のキーを更新するには、以下のメソッドを使います。
title: Microsoft Store ID キーの更新
ms.date: 03/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store コレクション API, Microsoft Store 購入 API, Microsoft Store ID キー, 更新
ms.localizationpriority: medium
ms.openlocfilehash: 0f1c6248b2d87a68b77cad6f1bdc7cce0fae587e
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8939093"
---
# <a name="renew-a-microsoft-store-id-key"></a><span data-ttu-id="fb1c5-104">Microsoft Store ID キーの更新</span><span class="sxs-lookup"><span data-stu-id="fb1c5-104">Renew a Microsoft Store ID key</span></span>


<span data-ttu-id="fb1c5-105">Microsoft Store のキーを更新するには、以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-105">Use this method to renew a Microsoft Store key.</span></span> <span data-ttu-id="fb1c5-106">[Microsoft Store ID キーを生成](view-and-grant-products-from-a-service.md#step-4)する場合、キーは 90 日間有効です。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-106">When you [generate a Microsoft Store ID key](view-and-grant-products-from-a-service.md#step-4), the key is valid for 90 days.</span></span> <span data-ttu-id="fb1c5-107">キーの有効期限が切れたら、有効期限切れのキーとこのメソッドを使って、新しいキーを再ネゴシエートできます。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-107">After the key expires, you can use the expired key to renegotiate a new key by using this method.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="fb1c5-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="fb1c5-108">Prerequisites</span></span>


<span data-ttu-id="fb1c5-109">このメソッドを使用するための要件:</span><span class="sxs-lookup"><span data-stu-id="fb1c5-109">To use this method, you will need:</span></span>

* <span data-ttu-id="fb1c5-110">対象ユーザー URI の値が `https://onestore.microsoft.com` の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-110">An Azure AD access token that has the audience URI value `https://onestore.microsoft.com`.</span></span>
* <span data-ttu-id="fb1c5-111">[アプリのクライアント側コードから生成](view-and-grant-products-from-a-service.md#step-4)された有効期限切れの Microsoft Store ID キー。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-111">An expired Microsoft Store ID key that was [generated from client-side code in your app](view-and-grant-products-from-a-service.md#step-4).</span></span>

<span data-ttu-id="fb1c5-112">詳しくは、「[サービスによる製品の権利の管理](view-and-grant-products-from-a-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-112">For more information, see [Manage product entitlements from a service](view-and-grant-products-from-a-service.md).</span></span>

## <a name="request"></a><span data-ttu-id="fb1c5-113">要求</span><span class="sxs-lookup"><span data-stu-id="fb1c5-113">Request</span></span>

### <a name="request-syntax"></a><span data-ttu-id="fb1c5-114">要求の構文</span><span class="sxs-lookup"><span data-stu-id="fb1c5-114">Request syntax</span></span>

| <span data-ttu-id="fb1c5-115">キーの種類</span><span class="sxs-lookup"><span data-stu-id="fb1c5-115">Key type</span></span>    | <span data-ttu-id="fb1c5-116">メソッド</span><span class="sxs-lookup"><span data-stu-id="fb1c5-116">Method</span></span> | <span data-ttu-id="fb1c5-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="fb1c5-117">Request URI</span></span>                                              |
|-------------|--------|----------------------------------------------------------|
| <span data-ttu-id="fb1c5-118">コレクション</span><span class="sxs-lookup"><span data-stu-id="fb1c5-118">Collections</span></span> | <span data-ttu-id="fb1c5-119">POST</span><span class="sxs-lookup"><span data-stu-id="fb1c5-119">POST</span></span>   | ```https://collections.mp.microsoft.com/v6.0/b2b/keys/renew``` |
| <span data-ttu-id="fb1c5-120">購入</span><span class="sxs-lookup"><span data-stu-id="fb1c5-120">Purchase</span></span>    | <span data-ttu-id="fb1c5-121">POST</span><span class="sxs-lookup"><span data-stu-id="fb1c5-121">POST</span></span>   | ```https://purchase.mp.microsoft.com/v6.0/b2b/keys/renew```    |


### <a name="request-header"></a><span data-ttu-id="fb1c5-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb1c5-122">Request header</span></span>

| <span data-ttu-id="fb1c5-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fb1c5-123">Header</span></span>         | <span data-ttu-id="fb1c5-124">型</span><span class="sxs-lookup"><span data-stu-id="fb1c5-124">Type</span></span>   | <span data-ttu-id="fb1c5-125">説明</span><span class="sxs-lookup"><span data-stu-id="fb1c5-125">Description</span></span>                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="fb1c5-126">Host</span><span class="sxs-lookup"><span data-stu-id="fb1c5-126">Host</span></span>           | <span data-ttu-id="fb1c5-127">string</span><span class="sxs-lookup"><span data-stu-id="fb1c5-127">string</span></span> | <span data-ttu-id="fb1c5-128">**collections.mp.microsoft.com** または **purchase.mp.microsoft.com** の値に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-128">Must be set to the value **collections.mp.microsoft.com** or **purchase.mp.microsoft.com**.</span></span>           |
| <span data-ttu-id="fb1c5-129">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fb1c5-129">Content-Length</span></span> | <span data-ttu-id="fb1c5-130">number</span><span class="sxs-lookup"><span data-stu-id="fb1c5-130">number</span></span> | <span data-ttu-id="fb1c5-131">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-131">The length of the request body.</span></span>                                                                       |
| <span data-ttu-id="fb1c5-132">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fb1c5-132">Content-Type</span></span>   | <span data-ttu-id="fb1c5-133">string</span><span class="sxs-lookup"><span data-stu-id="fb1c5-133">string</span></span> | <span data-ttu-id="fb1c5-134">要求と応答の種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-134">Specifies the request and response type.</span></span> <span data-ttu-id="fb1c5-135">現時点では、サポートされている唯一の値は **application/json** です。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-135">Currently, the only supported value is **application/json**.</span></span> |


### <a name="request-body"></a><span data-ttu-id="fb1c5-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="fb1c5-136">Request body</span></span>

| <span data-ttu-id="fb1c5-137">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb1c5-137">Parameter</span></span>     | <span data-ttu-id="fb1c5-138">型</span><span class="sxs-lookup"><span data-stu-id="fb1c5-138">Type</span></span>   | <span data-ttu-id="fb1c5-139">説明</span><span class="sxs-lookup"><span data-stu-id="fb1c5-139">Description</span></span>                       | <span data-ttu-id="fb1c5-140">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="fb1c5-140">Required</span></span> |
|---------------|--------|-----------------------------------|----------|
| <span data-ttu-id="fb1c5-141">serviceTicket</span><span class="sxs-lookup"><span data-stu-id="fb1c5-141">serviceTicket</span></span> | <span data-ttu-id="fb1c5-142">string</span><span class="sxs-lookup"><span data-stu-id="fb1c5-142">string</span></span> | <span data-ttu-id="fb1c5-143">Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-143">The Azure AD access token.</span></span>        | <span data-ttu-id="fb1c5-144">必須</span><span class="sxs-lookup"><span data-stu-id="fb1c5-144">Yes</span></span>      |
| <span data-ttu-id="fb1c5-145">key</span><span class="sxs-lookup"><span data-stu-id="fb1c5-145">key</span></span>           | <span data-ttu-id="fb1c5-146">string</span><span class="sxs-lookup"><span data-stu-id="fb1c5-146">string</span></span> | <span data-ttu-id="fb1c5-147">有効期限が切れた Microsoft Store ID キー。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-147">The expired Microsoft Store ID key.</span></span> | <span data-ttu-id="fb1c5-148">はい</span><span class="sxs-lookup"><span data-stu-id="fb1c5-148">Yes</span></span>       |


### <a name="request-example"></a><span data-ttu-id="fb1c5-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="fb1c5-149">Request example</span></span>

```syntax
POST https://collections.mp.microsoft.com/v6.0/b2b/keys/renew HTTP/1.1
Content-Length: 2774
Content-Type: application/json
Host: collections.mp.microsoft.com

{
    "serviceTicket": "eyJ0eXAiOiJKV1QiLCJhb….",
    "Key": "eyJ0eXAiOiJKV1QiLCJhbG…."
}
```

## <a name="response"></a><span data-ttu-id="fb1c5-150">応答</span><span class="sxs-lookup"><span data-stu-id="fb1c5-150">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="fb1c5-151">応答本文</span><span class="sxs-lookup"><span data-stu-id="fb1c5-151">Response body</span></span>

| <span data-ttu-id="fb1c5-152">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fb1c5-152">Parameter</span></span> | <span data-ttu-id="fb1c5-153">型</span><span class="sxs-lookup"><span data-stu-id="fb1c5-153">Type</span></span>   | <span data-ttu-id="fb1c5-154">説明</span><span class="sxs-lookup"><span data-stu-id="fb1c5-154">Description</span></span>                                                                                                            |
|-----------|--------|------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="fb1c5-155">key</span><span class="sxs-lookup"><span data-stu-id="fb1c5-155">key</span></span>       | <span data-ttu-id="fb1c5-156">string</span><span class="sxs-lookup"><span data-stu-id="fb1c5-156">string</span></span> | <span data-ttu-id="fb1c5-157">以降の Microsoft Store コレクション API または Microsoft Store 購入 API の呼び出しで使用できる、更新された Microsoft Store のキー。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-157">The refreshed Microsoft Store key that can be used in future calls to the Microsoft Store collections API or purchase API.</span></span> |


### <a name="response-example"></a><span data-ttu-id="fb1c5-158">応答の例</span><span class="sxs-lookup"><span data-stu-id="fb1c5-158">Response example</span></span>

```syntax
HTTP/1.1 200 OK
Content-Length: 1646
Content-Type: application/json
MS-CorrelationId: bfebe80c-ff89-4c4b-8897-67b45b916e47
MS-RequestId: 1b5fa630-d672-4971-b2c0-3713f4ea6c85
MS-CV: xu2HW6SrSkyfHyFh.0.0
MS-ServerId: 030011428
Date: Tue, 13 Sep 2015 07:31:12 GMT

{
    "key":"eyJ0eXAi….."
}
```

## <a name="error-codes"></a><span data-ttu-id="fb1c5-159">エラー コード</span><span class="sxs-lookup"><span data-stu-id="fb1c5-159">Error codes</span></span>


| <span data-ttu-id="fb1c5-160">コード</span><span class="sxs-lookup"><span data-stu-id="fb1c5-160">Code</span></span> | <span data-ttu-id="fb1c5-161">エラー</span><span class="sxs-lookup"><span data-stu-id="fb1c5-161">Error</span></span>        | <span data-ttu-id="fb1c5-162">内部エラー コード</span><span class="sxs-lookup"><span data-stu-id="fb1c5-162">Inner error code</span></span>           | <span data-ttu-id="fb1c5-163">説明</span><span class="sxs-lookup"><span data-stu-id="fb1c5-163">Description</span></span>   |
|------|--------------|----------------------------|---------------|
| <span data-ttu-id="fb1c5-164">401</span><span class="sxs-lookup"><span data-stu-id="fb1c5-164">401</span></span>  | <span data-ttu-id="fb1c5-165">権限がありません</span><span class="sxs-lookup"><span data-stu-id="fb1c5-165">Unauthorized</span></span> | <span data-ttu-id="fb1c5-166">AuthenticationTokenInvalid</span><span class="sxs-lookup"><span data-stu-id="fb1c5-166">AuthenticationTokenInvalid</span></span> | <span data-ttu-id="fb1c5-167">Azure AD アクセス トークンが無効です。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-167">The Azure AD access token is invalid.</span></span> <span data-ttu-id="fb1c5-168">場合によっては、ServiceError の詳細に追加情報が含まれていることがあります (トークンの有効期限切れや *appid* 要求の欠落など)。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-168">In some cases the details of the ServiceError will contain more information, such as when the token is expired or the *appid* claim is missing.</span></span> |
| <span data-ttu-id="fb1c5-169">401</span><span class="sxs-lookup"><span data-stu-id="fb1c5-169">401</span></span>  | <span data-ttu-id="fb1c5-170">権限がありません</span><span class="sxs-lookup"><span data-stu-id="fb1c5-170">Unauthorized</span></span> | <span data-ttu-id="fb1c5-171">InconsistentClientId</span><span class="sxs-lookup"><span data-stu-id="fb1c5-171">InconsistentClientId</span></span>       | <span data-ttu-id="fb1c5-172">Microsoft Store ID キーの *clientId* 要求と Azure AD アクセス トークンの *appid* 要求が一致しません。</span><span class="sxs-lookup"><span data-stu-id="fb1c5-172">The *clientId* claim in the Microsoft Store ID key and the *appid* claim in the Azure AD access token do not match.</span></span>                                                                     |


## <a name="related-topics"></a><span data-ttu-id="fb1c5-173">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fb1c5-173">Related topics</span></span>


* [<span data-ttu-id="fb1c5-174">サービスから製品の権利を管理する</span><span class="sxs-lookup"><span data-stu-id="fb1c5-174">Manage product entitlements from a service</span></span>](view-and-grant-products-from-a-service.md)
* [<span data-ttu-id="fb1c5-175">製品の照会</span><span class="sxs-lookup"><span data-stu-id="fb1c5-175">Query for products</span></span>](query-for-products.md)
* [<span data-ttu-id="fb1c5-176">コンシューマブルな製品をフルフィルメント完了として報告する</span><span class="sxs-lookup"><span data-stu-id="fb1c5-176">Report consumable products as fulfilled</span></span>](report-consumable-products-as-fulfilled.md)
* [<span data-ttu-id="fb1c5-177">無料の製品の付与</span><span class="sxs-lookup"><span data-stu-id="fb1c5-177">Grant free products</span></span>](grant-free-products.md)
