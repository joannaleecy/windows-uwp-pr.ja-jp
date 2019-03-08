---
title: メディア キャプチャ API のリファレンス
description: メディア キャプチャ API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 3f92c8fd-4096-4972-97da-01ae5db6423c
ms.localizationpriority: medium
ms.openlocfilehash: 7a27d13f7ceedd14a84d5b4b4aa1233445037a1f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640767"
---
# <a name="media-capture-api-reference"></a><span data-ttu-id="40fc8-104">メディア キャプチャ API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="40fc8-104">Media Capture API reference</span></span> #

<span data-ttu-id="40fc8-105">**要求**</span><span class="sxs-lookup"><span data-stu-id="40fc8-105">**Request**</span></span>

<span data-ttu-id="40fc8-106">次の要求形式を使用して、現在の画面の PNG 画像を取得できます。</span><span class="sxs-lookup"><span data-stu-id="40fc8-106">You can capture a PNG representation of the current screen by using the following request format.</span></span>

| <span data-ttu-id="40fc8-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="40fc8-107">Method</span></span>        | <span data-ttu-id="40fc8-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="40fc8-108">Request URI</span></span>     | 
| ------------- |-----------------|
| <span data-ttu-id="40fc8-109">GET</span><span class="sxs-lookup"><span data-stu-id="40fc8-109">GET</span></span>           | <span data-ttu-id="40fc8-110">/ext/screenshot</span><span class="sxs-lookup"><span data-stu-id="40fc8-110">/ext/screenshot</span></span> |
<br>

<span data-ttu-id="40fc8-111">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="40fc8-111">**URI parameters**</span></span>

<span data-ttu-id="40fc8-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="40fc8-112">You can specify the following additional parameters on the request URI:</span></span>


| <span data-ttu-id="40fc8-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40fc8-113">URI parameter</span></span>      | <span data-ttu-id="40fc8-114">説明</span><span class="sxs-lookup"><span data-stu-id="40fc8-114">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="40fc8-115">download (省略可能)</span><span class="sxs-lookup"><span data-stu-id="40fc8-115">download (optional)</span></span>| <span data-ttu-id="40fc8-116">ホスト ブラウザーでスクリーンショットをブラウザーにレンダリングするのではなく添付ファイルとしてダウンロードする必要があることを、HTTP 応答ヘッダーで設定する必要があるかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="40fc8-116">A boolean value indicating if HTTP response headers should be set indicating that the host browser should download the screenshot as an attachment rather than rendering it in the browser.</span></span>  |
<br>

<span data-ttu-id="40fc8-117">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="40fc8-117">**Request headers**</span></span>

* <span data-ttu-id="40fc8-118">なし</span><span class="sxs-lookup"><span data-stu-id="40fc8-118">None</span></span>

<span data-ttu-id="40fc8-119">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="40fc8-119">**Request body**</span></span>

* <span data-ttu-id="40fc8-120">なし</span><span class="sxs-lookup"><span data-stu-id="40fc8-120">None</span></span>

###<a name="response"></a><span data-ttu-id="40fc8-121">応答 ###</span><span class="sxs-lookup"><span data-stu-id="40fc8-121">Response###</span></span>

<span data-ttu-id="40fc8-122">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="40fc8-122">**Status code**</span></span>

<span data-ttu-id="40fc8-123">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="40fc8-123">This API has the following expected status codes.</span></span>

| <span data-ttu-id="40fc8-124">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="40fc8-124">HTTP status code</span></span>   | <span data-ttu-id="40fc8-125">説明</span><span class="sxs-lookup"><span data-stu-id="40fc8-125">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="40fc8-126">200</span><span class="sxs-lookup"><span data-stu-id="40fc8-126">200</span></span>                | <span data-ttu-id="40fc8-127">スクリーンショットの要求が成功し、キャプチャが返される</span><span class="sxs-lookup"><span data-stu-id="40fc8-127">Screenshot request successful and capture returned</span></span> |
| <span data-ttu-id="40fc8-128">5XX</span><span class="sxs-lookup"><span data-stu-id="40fc8-128">5XX</span></span>                | <span data-ttu-id="40fc8-129">予期しないエラーのエラー コード</span><span class="sxs-lookup"><span data-stu-id="40fc8-129">Error codes for unexpected failures</span></span> |
<br>

<span data-ttu-id="40fc8-130">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="40fc8-130">**Available device families**</span></span>

* <span data-ttu-id="40fc8-131">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="40fc8-131">Windows Xbox</span></span>

