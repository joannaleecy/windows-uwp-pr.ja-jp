---
author: mcleanbyron
ms.assetid: A4C6098B-6CB9-4FAF-B2EA-50B03D027FF1
description: 現在のアプリのコンテキストで現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API の以下のメソッドを使います。
title: ターゲット オファーを取得する
ms.author: mcleans
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファーの取得
ms.localizationpriority: medium
ms.openlocfilehash: 188561fb5dc6dda318a0b2aa7f1d91aa04c32548
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1661892"
---
# <a name="get-targeted-offers"></a><span data-ttu-id="4595b-104">ターゲット オファーを取得する</span><span class="sxs-lookup"><span data-stu-id="4595b-104">Get targeted offers</span></span>

<span data-ttu-id="4595b-105">ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得するには、このメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="4595b-105">Use this method to get the targeted offers that are available for the current user, based on whether or not the user is part of the customer segment for the targeted offer.</span></span> <span data-ttu-id="4595b-106">詳しくは、「[ストア サービスを使用したターゲット オファーの管理](manage-targeted-offers-using-windows-store-services.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4595b-106">For more information, see [Manage targeted offers using Store services](manage-targeted-offers-using-windows-store-services.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4595b-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="4595b-107">Prerequisites</span></span>

<span data-ttu-id="4595b-108">このメソッドを使うには、まずアプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4595b-108">To use this method, you need to first [obtain a Microsoft Account token](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token) for the current signed-in user of your app.</span></span> <span data-ttu-id="4595b-109">このトークンを、このメソッドの ```Authorization``` 要求ヘッダーで渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4595b-109">You must pass this token in the ```Authorization``` request header for this method.</span></span> <span data-ttu-id="4595b-110">このトークンは、現在のユーザーのターゲット オファーを取得するために Store によって使われます。</span><span class="sxs-lookup"><span data-stu-id="4595b-110">This token is used by the Store to get targeted offers for the current user.</span></span>

## <a name="request"></a><span data-ttu-id="4595b-111">要求</span><span class="sxs-lookup"><span data-stu-id="4595b-111">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="4595b-112">要求の構文</span><span class="sxs-lookup"><span data-stu-id="4595b-112">Request syntax</span></span>

| <span data-ttu-id="4595b-113">メソッド</span><span class="sxs-lookup"><span data-stu-id="4595b-113">Method</span></span> | <span data-ttu-id="4595b-114">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4595b-114">Request URI</span></span>                                                                |
|--------|----------------------------------------------------------------------------|
| <span data-ttu-id="4595b-115">GET</span><span class="sxs-lookup"><span data-stu-id="4595b-115">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` |


### <a name="request-header"></a><span data-ttu-id="4595b-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4595b-116">Request header</span></span>

| <span data-ttu-id="4595b-117">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4595b-117">Header</span></span>        | <span data-ttu-id="4595b-118">型</span><span class="sxs-lookup"><span data-stu-id="4595b-118">Type</span></span>   | <span data-ttu-id="4595b-119">説明</span><span class="sxs-lookup"><span data-stu-id="4595b-119">Description</span></span>  |
|---------------|--------|--------------|
| <span data-ttu-id="4595b-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="4595b-120">Authorization</span></span> | <span data-ttu-id="4595b-121">文字列</span><span class="sxs-lookup"><span data-stu-id="4595b-121">string</span></span> | <span data-ttu-id="4595b-122">必須。</span><span class="sxs-lookup"><span data-stu-id="4595b-122">Required.</span></span> <span data-ttu-id="4595b-123">アプリの現在のサインインしているユーザーの Microsoft アカウント トークン (**Bearer** &lt;*トークン*&gt; の形式)。</span><span class="sxs-lookup"><span data-stu-id="4595b-123">The Microsoft Account token for the current signed-in user of your app in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="4595b-124">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="4595b-124">Request parameters</span></span>

<span data-ttu-id="4595b-125">このメソッドには URI またはクエリ パラメーターはありません。</span><span class="sxs-lookup"><span data-stu-id="4595b-125">This method has no URI or query parameters.</span></span>

### <a name="request-example"></a><span data-ttu-id="4595b-126">要求の例</span><span class="sxs-lookup"><span data-stu-id="4595b-126">Request example</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user HTTP/1.1
Authorization: Bearer <Microsoft Account token>
```

## <a name="response"></a><span data-ttu-id="4595b-127">応答</span><span class="sxs-lookup"><span data-stu-id="4595b-127">Response</span></span>

<span data-ttu-id="4595b-128">このメソッドは、次のフィールドを持つオブジェクトの配列を含む JSON 形式の応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="4595b-128">This method returns a JSON-formatted response body that contains an array of objects with the following fields.</span></span> <span data-ttu-id="4595b-129">配列内の各オブジェクトは、特定の顧客セグメントの一部として指定されたユーザーが利用可能なターゲット オファーを表します。</span><span class="sxs-lookup"><span data-stu-id="4595b-129">Each object in the array represents the targeted offers that are available for the specified user as part of a particular customer segment.</span></span>

| <span data-ttu-id="4595b-130">フィールド</span><span class="sxs-lookup"><span data-stu-id="4595b-130">Field</span></span>      | <span data-ttu-id="4595b-131">型</span><span class="sxs-lookup"><span data-stu-id="4595b-131">Type</span></span>   | <span data-ttu-id="4595b-132">説明</span><span class="sxs-lookup"><span data-stu-id="4595b-132">Description</span></span>         |
|------------|--------|------------------|
| <span data-ttu-id="4595b-133">offers</span><span class="sxs-lookup"><span data-stu-id="4595b-133">offers</span></span>      | <span data-ttu-id="4595b-134">array</span><span class="sxs-lookup"><span data-stu-id="4595b-134">array</span></span>  | <span data-ttu-id="4595b-135">現在のユーザーが利用できるターゲット オファーに関連付けられているアドオンの製品 ID の配列。</span><span class="sxs-lookup"><span data-stu-id="4595b-135">An array of product IDs for the add-ons that are associated with the targeted offers that are available for the current user.</span></span> <span data-ttu-id="4595b-136">これらの製品 ID は、Windows デベロッパー センター ダッシュボードにあるアプリの **[ターゲット オファー]** ページで指定されます。</span><span class="sxs-lookup"><span data-stu-id="4595b-136">These product IDs are specified in the **Targeted offers** page for your app in the Windows Dev Center dashboard.</span></span>            |
| <span data-ttu-id="4595b-137">trackingId</span><span class="sxs-lookup"><span data-stu-id="4595b-137">trackingId</span></span>  | <span data-ttu-id="4595b-138">string</span><span class="sxs-lookup"><span data-stu-id="4595b-138">string</span></span> | <span data-ttu-id="4595b-139">必要に応じて独自のコードまたはサービスでターゲット オファーの追跡に使用できる GUID です。</span><span class="sxs-lookup"><span data-stu-id="4595b-139">A GUID that you can optionally use to keep track of the targeted offer in your own code or services.</span></span> |


### <a name="example"></a><span data-ttu-id="4595b-140">例</span><span class="sxs-lookup"><span data-stu-id="4595b-140">Example</span></span>

<span data-ttu-id="4595b-141">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4595b-141">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="4595b-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4595b-142">Related topics</span></span>

* [<span data-ttu-id="4595b-143">Store サービスを使ってターゲット オファーを管理する</span><span class="sxs-lookup"><span data-stu-id="4595b-143">Manage targeted offers using Store services</span></span>](manage-targeted-offers-using-windows-store-services.md)

 

 
