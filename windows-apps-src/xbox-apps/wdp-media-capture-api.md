---
author: WilliamsJason
title: メディア キャプチャ API のリファレンス
description: メディア キャプチャ API にプログラムでアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 3f92c8fd-4096-4972-97da-01ae5db6423c
ms.openlocfilehash: 9236b0cd9ac658a34283e54ba70b7e70d19c6bb3
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "244504"
---
# <a name="media-capture-api-reference"></a><span data-ttu-id="4df4e-104">メディア キャプチャ API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="4df4e-104">Media Capture API reference</span></span> #

**<span data-ttu-id="4df4e-105">要求</span><span class="sxs-lookup"><span data-stu-id="4df4e-105">Request</span></span>**

<span data-ttu-id="4df4e-106">次の要求形式を使用して、現在の画面の PNG 画像を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4df4e-106">You can capture a PNG representation of the current screen by using the following request format.</span></span>

| <span data-ttu-id="4df4e-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="4df4e-107">Method</span></span>        | <span data-ttu-id="4df4e-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4df4e-108">Request URI</span></span>     | 
| ------------- |-----------------|
| <span data-ttu-id="4df4e-109">GET</span><span class="sxs-lookup"><span data-stu-id="4df4e-109">GET</span></span>           | <span data-ttu-id="4df4e-110">/ext/screenshot</span><span class="sxs-lookup"><span data-stu-id="4df4e-110">/ext/screenshot</span></span> |
<br>

**<span data-ttu-id="4df4e-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4df4e-111">URI parameters</span></span>**

<span data-ttu-id="4df4e-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4df4e-112">You can specify the following additional parameters on the request URI:</span></span>


| <span data-ttu-id="4df4e-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4df4e-113">URI parameter</span></span>      | <span data-ttu-id="4df4e-114">説明</span><span class="sxs-lookup"><span data-stu-id="4df4e-114">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="4df4e-115">download (省略可能)</span><span class="sxs-lookup"><span data-stu-id="4df4e-115">download (optional)</span></span>| <span data-ttu-id="4df4e-116">ホスト ブラウザーでスクリーンショットをブラウザーにレンダリングするのではなく添付ファイルとしてダウンロードする必要があることを、HTTP 応答ヘッダーで設定する必要があるかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="4df4e-116">A boolean value indicating if HTTP response headers should be set indicating that the host browser should download the screenshot as an attachment rather than rendering it in the browser.</span></span>  |
<br>

**<span data-ttu-id="4df4e-117">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4df4e-117">Request headers</span></span>**

* <span data-ttu-id="4df4e-118">なし</span><span class="sxs-lookup"><span data-stu-id="4df4e-118">None</span></span>

**<span data-ttu-id="4df4e-119">要求本文</span><span class="sxs-lookup"><span data-stu-id="4df4e-119">Request body</span></span>**

* <span data-ttu-id="4df4e-120">なし</span><span class="sxs-lookup"><span data-stu-id="4df4e-120">None</span></span>

###<a name="response"></a><span data-ttu-id="4df4e-121">応答</span><span class="sxs-lookup"><span data-stu-id="4df4e-121">Response</span></span>###

**<span data-ttu-id="4df4e-122">状態コード</span><span class="sxs-lookup"><span data-stu-id="4df4e-122">Status code</span></span>**

<span data-ttu-id="4df4e-123">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4df4e-123">This API has the following expected status codes.</span></span>

| <span data-ttu-id="4df4e-124">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4df4e-124">HTTP status code</span></span>   | <span data-ttu-id="4df4e-125">説明</span><span class="sxs-lookup"><span data-stu-id="4df4e-125">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="4df4e-126">200</span><span class="sxs-lookup"><span data-stu-id="4df4e-126">200</span></span>                | <span data-ttu-id="4df4e-127">スクリーンショットの要求が成功し、キャプチャが返される</span><span class="sxs-lookup"><span data-stu-id="4df4e-127">Screenshot request successful and capture returned</span></span> |
| <span data-ttu-id="4df4e-128">5XX</span><span class="sxs-lookup"><span data-stu-id="4df4e-128">5XX</span></span>                | <span data-ttu-id="4df4e-129">予期しないエラーのエラー コード</span><span class="sxs-lookup"><span data-stu-id="4df4e-129">Error codes for unexpected failures</span></span> |
<br>

**<span data-ttu-id="4df4e-130">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="4df4e-130">Available device families</span></span>**

* <span data-ttu-id="4df4e-131">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="4df4e-131">Windows Xbox</span></span>

