---
author: WilliamsJason
title: メディア キャプチャ API のリファレンス
description: メディア キャプチャ API にプログラムでアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 3f92c8fd-4096-4972-97da-01ae5db6423c
ms.localizationpriority: medium
ms.openlocfilehash: f58fa4c3a9a1abd407f635f27de3a545c3aafc6c
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6983085"
---
# <a name="media-capture-api-reference"></a><span data-ttu-id="9a954-104">メディア キャプチャ API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="9a954-104">Media Capture API reference</span></span> #

**<span data-ttu-id="9a954-105">要求</span><span class="sxs-lookup"><span data-stu-id="9a954-105">Request</span></span>**

<span data-ttu-id="9a954-106">次の要求形式を使用して、現在の画面の PNG 画像を取得できます。</span><span class="sxs-lookup"><span data-stu-id="9a954-106">You can capture a PNG representation of the current screen by using the following request format.</span></span>

| <span data-ttu-id="9a954-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="9a954-107">Method</span></span>        | <span data-ttu-id="9a954-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="9a954-108">Request URI</span></span>     | 
| ------------- |-----------------|
| <span data-ttu-id="9a954-109">GET</span><span class="sxs-lookup"><span data-stu-id="9a954-109">GET</span></span>           | <span data-ttu-id="9a954-110">/ext/screenshot</span><span class="sxs-lookup"><span data-stu-id="9a954-110">/ext/screenshot</span></span> |
<br>

**<span data-ttu-id="9a954-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9a954-111">URI parameters</span></span>**

<span data-ttu-id="9a954-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="9a954-112">You can specify the following additional parameters on the request URI:</span></span>


| <span data-ttu-id="9a954-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9a954-113">URI parameter</span></span>      | <span data-ttu-id="9a954-114">説明</span><span class="sxs-lookup"><span data-stu-id="9a954-114">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="9a954-115">download (省略可能)</span><span class="sxs-lookup"><span data-stu-id="9a954-115">download (optional)</span></span>| <span data-ttu-id="9a954-116">ホスト ブラウザーでスクリーンショットをブラウザーにレンダリングするのではなく添付ファイルとしてダウンロードする必要があることを、HTTP 応答ヘッダーで設定する必要があるかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="9a954-116">A boolean value indicating if HTTP response headers should be set indicating that the host browser should download the screenshot as an attachment rather than rendering it in the browser.</span></span>  |
<br>

**<span data-ttu-id="9a954-117">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9a954-117">Request headers</span></span>**

* <span data-ttu-id="9a954-118">なし</span><span class="sxs-lookup"><span data-stu-id="9a954-118">None</span></span>

**<span data-ttu-id="9a954-119">要求本文</span><span class="sxs-lookup"><span data-stu-id="9a954-119">Request body</span></span>**

* <span data-ttu-id="9a954-120">なし</span><span class="sxs-lookup"><span data-stu-id="9a954-120">None</span></span>

###<a name="response"></a><span data-ttu-id="9a954-121">応答番号</span><span class="sxs-lookup"><span data-stu-id="9a954-121">Response###</span></span>

**<span data-ttu-id="9a954-122">状態コード</span><span class="sxs-lookup"><span data-stu-id="9a954-122">Status code</span></span>**

<span data-ttu-id="9a954-123">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9a954-123">This API has the following expected status codes.</span></span>

| <span data-ttu-id="9a954-124">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="9a954-124">HTTP status code</span></span>   | <span data-ttu-id="9a954-125">説明</span><span class="sxs-lookup"><span data-stu-id="9a954-125">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="9a954-126">200</span><span class="sxs-lookup"><span data-stu-id="9a954-126">200</span></span>                | <span data-ttu-id="9a954-127">スクリーンショットの要求が成功し、キャプチャが返される</span><span class="sxs-lookup"><span data-stu-id="9a954-127">Screenshot request successful and capture returned</span></span> |
| <span data-ttu-id="9a954-128">5XX</span><span class="sxs-lookup"><span data-stu-id="9a954-128">5XX</span></span>                | <span data-ttu-id="9a954-129">予期しないエラーのエラー コード</span><span class="sxs-lookup"><span data-stu-id="9a954-129">Error codes for unexpected failures</span></span> |
<br>

**<span data-ttu-id="9a954-130">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="9a954-130">Available device families</span></span>**

* <span data-ttu-id="9a954-131">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="9a954-131">Windows Xbox</span></span>

