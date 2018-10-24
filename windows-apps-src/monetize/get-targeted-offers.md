---
author: Xansky
ms.assetid: A4C6098B-6CB9-4FAF-B2EA-50B03D027FF1
description: 現在のアプリのコンテキストで現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API の以下のメソッドを使います。
title: ターゲット オファーを取得する
ms.author: mhopkins
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファーの取得
ms.localizationpriority: medium
ms.openlocfilehash: 1032831492443460bd63671012a09edfceca2690
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5479078"
---
# <a name="get-targeted-offers"></a><span data-ttu-id="39657-104">ターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="39657-104">Get targeted offers</span></span>

<span data-ttu-id="39657-105">ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得するには、このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="39657-105">Use this method to get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span> <span data-ttu-id="39657-106">詳しくは、「[ストア サービスを使用したターゲット オファーの管理](manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39657-106">For more information, see [Manage targeted offers using Store services](manage-targeted-offers-using-windows-store-services.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="39657-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="39657-107">Prerequisites</span></span>

<span data-ttu-id="39657-108">このメソッドを使うには、まずアプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39657-108">To use this method, you need to first [obtain a Microsoft Account token](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span> <span data-ttu-id="39657-109">このトークンを、このメソッドの ```Authorization``` 要求ヘッダーで渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="39657-109">You must pass this token in the ```Authorization``` request header for this method.</span></span> <span data-ttu-id="39657-110">このトークンは、現在のユーザーのターゲット オファーを取得するために Store によって使われます。</span><span class="sxs-lookup"><span data-stu-id="39657-110">This token is used by the Store to get targeted offers for the current user.</span></span>

## <a name="request"></a><span data-ttu-id="39657-111">要求</span><span class="sxs-lookup"><span data-stu-id="39657-111">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="39657-112">要求の構文</span><span class="sxs-lookup"><span data-stu-id="39657-112">Request syntax</span></span>

| <span data-ttu-id="39657-113">メソッド</span><span class="sxs-lookup"><span data-stu-id="39657-113">Method</span></span> | <span data-ttu-id="39657-114">要求 URI</span><span class="sxs-lookup"><span data-stu-id="39657-114">Request URI</span></span>                                                                |
|--------|----------------------------------------------------------------------------|
| <span data-ttu-id="39657-115">GET</span><span class="sxs-lookup"><span data-stu-id="39657-115">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` |


### <a name="request-header"></a><span data-ttu-id="39657-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="39657-116">Request header</span></span>

| <span data-ttu-id="39657-117">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="39657-117">Header</span></span>        | <span data-ttu-id="39657-118">型</span><span class="sxs-lookup"><span data-stu-id="39657-118">Type</span></span>   | <span data-ttu-id="39657-119">説明</span><span class="sxs-lookup"><span data-stu-id="39657-119">Description</span></span>  |
|---------------|--------|--------------|
| <span data-ttu-id="39657-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="39657-120">Authorization</span></span> | <span data-ttu-id="39657-121">string</span><span class="sxs-lookup"><span data-stu-id="39657-121">string</span></span> | <span data-ttu-id="39657-122">必須。</span><span class="sxs-lookup"><span data-stu-id="39657-122">Required.</span></span> <span data-ttu-id="39657-123">アプリの現在のサインインしているユーザーの Microsoft アカウント トークン (**Bearer** &lt;*トークン*&gt; の形式)。</span><span class="sxs-lookup"><span data-stu-id="39657-123">The Microsoft Account token for the current signed-in user of your app in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="39657-124">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="39657-124">Request parameters</span></span>

<span data-ttu-id="39657-125">このメソッドには URI またはクエリ パラメーターはありません。</span><span class="sxs-lookup"><span data-stu-id="39657-125">This method has no URI or query parameters.</span></span>

### <a name="request-example"></a><span data-ttu-id="39657-126">要求の例</span><span class="sxs-lookup"><span data-stu-id="39657-126">Request example</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user HTTP/1.1
Authorization: Bearer <Microsoft Account token>
```

## <a name="response"></a><span data-ttu-id="39657-127">応答</span><span class="sxs-lookup"><span data-stu-id="39657-127">Response</span></span>

<span data-ttu-id="39657-128">このメソッドは、次のフィールドを持つオブジェクトの配列を含む JSON 形式の応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="39657-128">This method returns a JSON-formatted response body that contains an array of objects with the following fields.</span></span> <span data-ttu-id="39657-129">配列内の各オブジェクトは、特定の顧客セグメントの一部として指定されたユーザーが利用可能なターゲット オファーを表します。</span><span class="sxs-lookup"><span data-stu-id="39657-129">Each object in the array represents the targeted offers that are available for the specified user as part of a particular customer segment.</span></span>

| <span data-ttu-id="39657-130">フィールド</span><span class="sxs-lookup"><span data-stu-id="39657-130">Field</span></span>      | <span data-ttu-id="39657-131">型</span><span class="sxs-lookup"><span data-stu-id="39657-131">Type</span></span>   | <span data-ttu-id="39657-132">説明</span><span class="sxs-lookup"><span data-stu-id="39657-132">Description</span></span>         |
|------------|--------|------------------|
| <span data-ttu-id="39657-133">offers</span><span class="sxs-lookup"><span data-stu-id="39657-133">offers</span></span>      | <span data-ttu-id="39657-134">array</span><span class="sxs-lookup"><span data-stu-id="39657-134">array</span></span>  | <span data-ttu-id="39657-135">現在のユーザーが利用できるターゲット オファーに関連付けられているアドオンの製品 ID の配列。</span><span class="sxs-lookup"><span data-stu-id="39657-135">An array of product IDs for the add-ons that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="39657-136">これらの製品 ID は、Windows デベロッパー センター ダッシュボードにあるアプリの **[ターゲット オファー]** ページで指定されます。</span><span class="sxs-lookup"><span data-stu-id="39657-136">These product IDs are specified in the **Targeted offers** page for your app in the Windows Dev Center dashboard.</span></span>            |
| <span data-ttu-id="39657-137">trackingId</span><span class="sxs-lookup"><span data-stu-id="39657-137">trackingId</span></span>  | <span data-ttu-id="39657-138">string</span><span class="sxs-lookup"><span data-stu-id="39657-138">string</span></span> | <span data-ttu-id="39657-139">必要に応じて独自のコードまたはサービスでターゲット オファーの追跡に使用できる GUID です。</span><span class="sxs-lookup"><span data-stu-id="39657-139">A GUID that you can optionally use to keep track of the targeted offer in your own code or services.</span></span> |


### <a name="example"></a><span data-ttu-id="39657-140">例</span><span class="sxs-lookup"><span data-stu-id="39657-140">Example</span></span>

<span data-ttu-id="39657-141">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="39657-141">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="39657-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="39657-142">Related topics</span></span>

* [<span data-ttu-id="39657-143">Store サービスを使ってターゲット オファーを管理する</span><span class="sxs-lookup"><span data-stu-id="39657-143">Manage targeted offers using Store services</span></span>](manage-targeted-offers-using-windows-store-services.md)

 

 
