---
ms.assetid: A4C6098B-6CB9-4FAF-B2EA-50B03D027FF1
description: 現在のアプリのコンテキストで現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API の以下のメソッドを使います。
title: 対象のプランを取得する
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファーの取得
ms.localizationpriority: medium
ms.openlocfilehash: 71cd6ce3b9736b812f8ccdf4d21d35357928c63c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622767"
---
# <a name="get-targeted-offers"></a><span data-ttu-id="b3578-104">対象のプランを取得する</span><span class="sxs-lookup"><span data-stu-id="b3578-104">Get targeted offers</span></span>

<span data-ttu-id="b3578-105">ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得するには、このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="b3578-105">Use this method to get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span> <span data-ttu-id="b3578-106">詳しくは、「[ストア サービスを使用したターゲット オファーの管理](manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3578-106">For more information, see [Manage targeted offers using Store services](manage-targeted-offers-using-windows-store-services.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b3578-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="b3578-107">Prerequisites</span></span>

<span data-ttu-id="b3578-108">このメソッドを使うには、まずアプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b3578-108">To use this method, you need to first [obtain a Microsoft Account token](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span> <span data-ttu-id="b3578-109">このトークンは、このメソッドの ```Authorization``` 要求ヘッダーで渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="b3578-109">You must pass this token in the ```Authorization``` request header for this method.</span></span> <span data-ttu-id="b3578-110">このトークンは、現在のユーザーのターゲット オファーを取得するために Store によって使われます。</span><span class="sxs-lookup"><span data-stu-id="b3578-110">This token is used by the Store to get targeted offers for the current user.</span></span>

## <a name="request"></a><span data-ttu-id="b3578-111">要求</span><span class="sxs-lookup"><span data-stu-id="b3578-111">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="b3578-112">要求の構文</span><span class="sxs-lookup"><span data-stu-id="b3578-112">Request syntax</span></span>

| <span data-ttu-id="b3578-113">メソッド</span><span class="sxs-lookup"><span data-stu-id="b3578-113">Method</span></span> | <span data-ttu-id="b3578-114">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b3578-114">Request URI</span></span>                                                                |
|--------|----------------------------------------------------------------------------|
| <span data-ttu-id="b3578-115">GET</span><span class="sxs-lookup"><span data-stu-id="b3578-115">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` |


### <a name="request-header"></a><span data-ttu-id="b3578-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b3578-116">Request header</span></span>

| <span data-ttu-id="b3578-117">Header</span><span class="sxs-lookup"><span data-stu-id="b3578-117">Header</span></span>        | <span data-ttu-id="b3578-118">種類</span><span class="sxs-lookup"><span data-stu-id="b3578-118">Type</span></span>   | <span data-ttu-id="b3578-119">説明</span><span class="sxs-lookup"><span data-stu-id="b3578-119">Description</span></span>  |
|---------------|--------|--------------|
| <span data-ttu-id="b3578-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="b3578-120">Authorization</span></span> | <span data-ttu-id="b3578-121">string</span><span class="sxs-lookup"><span data-stu-id="b3578-121">string</span></span> | <span data-ttu-id="b3578-122">必須。</span><span class="sxs-lookup"><span data-stu-id="b3578-122">Required.</span></span> <span data-ttu-id="b3578-123">フォームのアプリの現在のサインイン ユーザーの Microsoft アカウント トークン**ベアラー** &lt;*トークン*&gt;します。</span><span class="sxs-lookup"><span data-stu-id="b3578-123">The Microsoft Account token for the current signed-in user of your app in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="b3578-124">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="b3578-124">Request parameters</span></span>

<span data-ttu-id="b3578-125">このメソッドには URI またはクエリ パラメーターはありません。</span><span class="sxs-lookup"><span data-stu-id="b3578-125">This method has no URI or query parameters.</span></span>

### <a name="request-example"></a><span data-ttu-id="b3578-126">要求の例</span><span class="sxs-lookup"><span data-stu-id="b3578-126">Request example</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user HTTP/1.1
Authorization: Bearer <Microsoft Account token>
```

## <a name="response"></a><span data-ttu-id="b3578-127">応答</span><span class="sxs-lookup"><span data-stu-id="b3578-127">Response</span></span>

<span data-ttu-id="b3578-128">このメソッドは、次のフィールドを持つオブジェクトの配列を含む JSON 形式の応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="b3578-128">This method returns a JSON-formatted response body that contains an array of objects with the following fields.</span></span> <span data-ttu-id="b3578-129">配列内の各オブジェクトは、特定の顧客セグメントの一部として指定されたユーザーが利用可能なターゲット オファーを表します。</span><span class="sxs-lookup"><span data-stu-id="b3578-129">Each object in the array represents the targeted offers that are available for the specified user as part of a particular customer segment.</span></span>

| <span data-ttu-id="b3578-130">フィールド</span><span class="sxs-lookup"><span data-stu-id="b3578-130">Field</span></span>      | <span data-ttu-id="b3578-131">種類</span><span class="sxs-lookup"><span data-stu-id="b3578-131">Type</span></span>   | <span data-ttu-id="b3578-132">説明</span><span class="sxs-lookup"><span data-stu-id="b3578-132">Description</span></span>         |
|------------|--------|------------------|
| <span data-ttu-id="b3578-133">offers</span><span class="sxs-lookup"><span data-stu-id="b3578-133">offers</span></span>      | <span data-ttu-id="b3578-134">array</span><span class="sxs-lookup"><span data-stu-id="b3578-134">array</span></span>  | <span data-ttu-id="b3578-135">現在のユーザーが利用できるターゲット オファーに関連付けられているアドオンの製品 ID の配列。</span><span class="sxs-lookup"><span data-stu-id="b3578-135">An array of product IDs for the add-ons that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="b3578-136">これらの製品 Id がで指定された、**オファーを対象となる**パートナー センターで、アプリのページ。</span><span class="sxs-lookup"><span data-stu-id="b3578-136">These product IDs are specified in the **Targeted offers** page for your app in Partner Center.</span></span>            |
| <span data-ttu-id="b3578-137">trackingId</span><span class="sxs-lookup"><span data-stu-id="b3578-137">trackingId</span></span>  | <span data-ttu-id="b3578-138">string</span><span class="sxs-lookup"><span data-stu-id="b3578-138">string</span></span> | <span data-ttu-id="b3578-139">必要に応じて独自のコードまたはサービスでターゲット オファーの追跡に使用できる GUID です。</span><span class="sxs-lookup"><span data-stu-id="b3578-139">A GUID that you can optionally use to keep track of the targeted offer in your own code or services.</span></span> |


### <a name="example"></a><span data-ttu-id="b3578-140">例</span><span class="sxs-lookup"><span data-stu-id="b3578-140">Example</span></span>

<span data-ttu-id="b3578-141">この要求の JSON 返信の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b3578-141">The following example demonstrates an example JSON response body for this request.</span></span>

```json
[
  {
    "offers": [
      "10x gold coins",
      "100x gold coins"
    ],
    "trackingId": "5de5dd29-6dce-4e68-b45e-d8ee6c2cd203"
  }
]
```

## <a name="related-topics"></a><span data-ttu-id="b3578-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b3578-142">Related topics</span></span>

* [<span data-ttu-id="b3578-143">ストア サービスを使用して、対象となるプランを管理します。</span><span class="sxs-lookup"><span data-stu-id="b3578-143">Manage targeted offers using Store services</span></span>](manage-targeted-offers-using-windows-store-services.md)

 

 
