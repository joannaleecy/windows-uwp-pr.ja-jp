---
author: Xansky
ms.assetid: A4C6098B-6CB9-4FAF-B2EA-50B03D027FF1
description: 現在のアプリのコンテキストで現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API の以下のメソッドを使います。
title: ターゲット オファーを取得する
ms.author: mhopkins
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファーの取得
ms.localizationpriority: medium
ms.openlocfilehash: 87d59a4b5dabbc76c231e84034d701fccfe36fcf
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7287919"
---
# <a name="get-targeted-offers"></a><span data-ttu-id="d0f1b-104">ターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="d0f1b-104">Get targeted offers</span></span>

<span data-ttu-id="d0f1b-105">ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得するには、このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-105">Use this method to get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span> <span data-ttu-id="d0f1b-106">詳しくは、「[ストア サービスを使用したターゲット オファーの管理](manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-106">For more information, see [Manage targeted offers using Store services](manage-targeted-offers-using-windows-store-services.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d0f1b-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="d0f1b-107">Prerequisites</span></span>

<span data-ttu-id="d0f1b-108">このメソッドを使うには、まずアプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-108">To use this method, you need to first [obtain a Microsoft Account token](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span> <span data-ttu-id="d0f1b-109">このトークンを、このメソッドの ```Authorization``` 要求ヘッダーで渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-109">You must pass this token in the ```Authorization``` request header for this method.</span></span> <span data-ttu-id="d0f1b-110">このトークンは、現在のユーザーのターゲット オファーを取得するために Store によって使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-110">This token is used by the Store to get targeted offers for the current user.</span></span>

## <a name="request"></a><span data-ttu-id="d0f1b-111">要求</span><span class="sxs-lookup"><span data-stu-id="d0f1b-111">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="d0f1b-112">要求の構文</span><span class="sxs-lookup"><span data-stu-id="d0f1b-112">Request syntax</span></span>

| <span data-ttu-id="d0f1b-113">メソッド</span><span class="sxs-lookup"><span data-stu-id="d0f1b-113">Method</span></span> | <span data-ttu-id="d0f1b-114">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d0f1b-114">Request URI</span></span>                                                                |
|--------|----------------------------------------------------------------------------|
| <span data-ttu-id="d0f1b-115">GET</span><span class="sxs-lookup"><span data-stu-id="d0f1b-115">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` |


### <a name="request-header"></a><span data-ttu-id="d0f1b-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d0f1b-116">Request header</span></span>

| <span data-ttu-id="d0f1b-117">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d0f1b-117">Header</span></span>        | <span data-ttu-id="d0f1b-118">型</span><span class="sxs-lookup"><span data-stu-id="d0f1b-118">Type</span></span>   | <span data-ttu-id="d0f1b-119">説明</span><span class="sxs-lookup"><span data-stu-id="d0f1b-119">Description</span></span>  |
|---------------|--------|--------------|
| <span data-ttu-id="d0f1b-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="d0f1b-120">Authorization</span></span> | <span data-ttu-id="d0f1b-121">string</span><span class="sxs-lookup"><span data-stu-id="d0f1b-121">string</span></span> | <span data-ttu-id="d0f1b-122">必須。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-122">Required.</span></span> <span data-ttu-id="d0f1b-123">アプリの現在のサインインしているユーザーの Microsoft アカウント トークン (**Bearer** &lt;*トークン*&gt; の形式)。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-123">The Microsoft Account token for the current signed-in user of your app in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d0f1b-124">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d0f1b-124">Request parameters</span></span>

<span data-ttu-id="d0f1b-125">このメソッドには URI またはクエリ パラメーターはありません。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-125">This method has no URI or query parameters.</span></span>

### <a name="request-example"></a><span data-ttu-id="d0f1b-126">要求の例</span><span class="sxs-lookup"><span data-stu-id="d0f1b-126">Request example</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user HTTP/1.1
Authorization: Bearer <Microsoft Account token>
```

## <a name="response"></a><span data-ttu-id="d0f1b-127">応答</span><span class="sxs-lookup"><span data-stu-id="d0f1b-127">Response</span></span>

<span data-ttu-id="d0f1b-128">このメソッドは、次のフィールドを持つオブジェクトの配列を含む JSON 形式の応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-128">This method returns a JSON-formatted response body that contains an array of objects with the following fields.</span></span> <span data-ttu-id="d0f1b-129">配列内の各オブジェクトは、特定の顧客セグメントの一部として指定されたユーザーが利用可能なターゲット オファーを表します。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-129">Each object in the array represents the targeted offers that are available for the specified user as part of a particular customer segment.</span></span>

| <span data-ttu-id="d0f1b-130">フィールド</span><span class="sxs-lookup"><span data-stu-id="d0f1b-130">Field</span></span>      | <span data-ttu-id="d0f1b-131">型</span><span class="sxs-lookup"><span data-stu-id="d0f1b-131">Type</span></span>   | <span data-ttu-id="d0f1b-132">説明</span><span class="sxs-lookup"><span data-stu-id="d0f1b-132">Description</span></span>         |
|------------|--------|------------------|
| <span data-ttu-id="d0f1b-133">offers</span><span class="sxs-lookup"><span data-stu-id="d0f1b-133">offers</span></span>      | <span data-ttu-id="d0f1b-134">array</span><span class="sxs-lookup"><span data-stu-id="d0f1b-134">array</span></span>  | <span data-ttu-id="d0f1b-135">現在のユーザーが利用できるターゲット オファーに関連付けられているアドオンの製品 ID の配列。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-135">An array of product IDs for the add-ons that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="d0f1b-136">これらの製品 Id は、パートナー センターでのアプリの**対象のプラン**] ページで指定されます。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-136">These product IDs are specified in the **Targeted offers** page for your app in Partner Center.</span></span>            |
| <span data-ttu-id="d0f1b-137">trackingId</span><span class="sxs-lookup"><span data-stu-id="d0f1b-137">trackingId</span></span>  | <span data-ttu-id="d0f1b-138">string</span><span class="sxs-lookup"><span data-stu-id="d0f1b-138">string</span></span> | <span data-ttu-id="d0f1b-139">必要に応じて独自のコードまたはサービスでターゲット オファーの追跡に使用できる GUID です。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-139">A GUID that you can optionally use to keep track of the targeted offer in your own code or services.</span></span> |


### <a name="example"></a><span data-ttu-id="d0f1b-140">例</span><span class="sxs-lookup"><span data-stu-id="d0f1b-140">Example</span></span>

<span data-ttu-id="d0f1b-141">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d0f1b-141">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="d0f1b-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d0f1b-142">Related topics</span></span>

* [<span data-ttu-id="d0f1b-143">Store サービスを使ってターゲット オファーを管理する</span><span class="sxs-lookup"><span data-stu-id="d0f1b-143">Manage targeted offers using Store services</span></span>](manage-targeted-offers-using-windows-store-services.md)

 

 
