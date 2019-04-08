---
title: デバイス ポータル コントローラー API リファレンス
description: 接続された物理コントローラーの数を取得し、プログラムでオフにする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 8b5061f9193d78d4ff23f5fa707b0bea67a10f98
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657007"
---
# <a name="controller-api-reference"></a><span data-ttu-id="33339-104">コントローラー API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="33339-104">Controller API reference</span></span>   
<span data-ttu-id="33339-105">接続された物理コントローラーの数を取得し、REST API を使用してオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="33339-105">You can get the number of attached physical controllers and turn them off using this REST API.</span></span>

## <a name="determine-the-number-of-attached-physical-controllers"></a><span data-ttu-id="33339-106">接続された物理コントローラーの数の決定</span><span class="sxs-lookup"><span data-stu-id="33339-106">Determine the number of attached physical controllers</span></span>

<span data-ttu-id="33339-107">**要求**</span><span class="sxs-lookup"><span data-stu-id="33339-107">**Request**</span></span>

<span data-ttu-id="33339-108">次の要求を使用して、デバイス上に接続された物理コントローラーの数を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="33339-108">You can check the number of attached physical controllers on the device using the following request.</span></span>

<span data-ttu-id="33339-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="33339-109">Method</span></span>      | <span data-ttu-id="33339-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33339-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="33339-111">GET</span><span class="sxs-lookup"><span data-stu-id="33339-111">GET</span></span> | <span data-ttu-id="33339-112">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="33339-112">/ext/remoteinput/controllers</span></span>
<br />
<span data-ttu-id="33339-113">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="33339-113">**URI parameters**</span></span>

- <span data-ttu-id="33339-114">なし</span><span class="sxs-lookup"><span data-stu-id="33339-114">None</span></span>

<span data-ttu-id="33339-115">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="33339-115">**Request headers**</span></span>

- <span data-ttu-id="33339-116">なし</span><span class="sxs-lookup"><span data-stu-id="33339-116">None</span></span>

<span data-ttu-id="33339-117">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="33339-117">**Request body**</span></span>   

- <span data-ttu-id="33339-118">なし</span><span class="sxs-lookup"><span data-stu-id="33339-118">None</span></span>

<span data-ttu-id="33339-119">**応答**</span><span class="sxs-lookup"><span data-stu-id="33339-119">**Response**</span></span>   

- <span data-ttu-id="33339-120">接続された物理コントローラーの数を指定する JSON 数値プロパティ ConnectedControllerCount です。</span><span class="sxs-lookup"><span data-stu-id="33339-120">JSON number property ConnectedControllerCount which specifies the number of attached physical controllers.</span></span>

<span data-ttu-id="33339-121">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="33339-121">**Status code**</span></span>

<span data-ttu-id="33339-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33339-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="33339-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="33339-123">HTTP status code</span></span>      | <span data-ttu-id="33339-124">説明</span><span class="sxs-lookup"><span data-stu-id="33339-124">Description</span></span>
:------     | :-----
<span data-ttu-id="33339-125">200</span><span class="sxs-lookup"><span data-stu-id="33339-125">200</span></span> | <span data-ttu-id="33339-126">成功</span><span class="sxs-lookup"><span data-stu-id="33339-126">Success</span></span>
<span data-ttu-id="33339-127">4XX</span><span class="sxs-lookup"><span data-stu-id="33339-127">4XX</span></span> | <span data-ttu-id="33339-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33339-128">Error codes</span></span>
<span data-ttu-id="33339-129">5XX</span><span class="sxs-lookup"><span data-stu-id="33339-129">5XX</span></span> | <span data-ttu-id="33339-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33339-130">Error codes</span></span>

## <a name="disconnect-all-physical-controllers-on-the-devkit"></a><span data-ttu-id="33339-131">開発キット上のすべての物理コントローラーの切断</span><span class="sxs-lookup"><span data-stu-id="33339-131">Disconnect all physical controllers on the devkit</span></span>

<span data-ttu-id="33339-132">**要求**</span><span class="sxs-lookup"><span data-stu-id="33339-132">**Request**</span></span>

<span data-ttu-id="33339-133">次の要求を使って、デバイス上のすべての物理コントローラーを切断することができます。</span><span class="sxs-lookup"><span data-stu-id="33339-133">You can disconnect all physical controllers on the device using the following request.</span></span>

<span data-ttu-id="33339-134">メソッド</span><span class="sxs-lookup"><span data-stu-id="33339-134">Method</span></span>      | <span data-ttu-id="33339-135">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33339-135">Request URI</span></span>
:------     | :-----
<span data-ttu-id="33339-136">Del</span><span class="sxs-lookup"><span data-stu-id="33339-136">DELETE</span></span> | <span data-ttu-id="33339-137">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="33339-137">/ext/remoteinput/controllers</span></span>
<br />
<span data-ttu-id="33339-138">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="33339-138">**URI parameters**</span></span>

- <span data-ttu-id="33339-139">なし</span><span class="sxs-lookup"><span data-stu-id="33339-139">None</span></span>

<span data-ttu-id="33339-140">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="33339-140">**Request headers**</span></span>

- <span data-ttu-id="33339-141">なし</span><span class="sxs-lookup"><span data-stu-id="33339-141">None</span></span>

<span data-ttu-id="33339-142">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="33339-142">**Request body**</span></span>   

- <span data-ttu-id="33339-143">なし</span><span class="sxs-lookup"><span data-stu-id="33339-143">None</span></span>

<span data-ttu-id="33339-144">**応答**</span><span class="sxs-lookup"><span data-stu-id="33339-144">**Response**</span></span>   

- <span data-ttu-id="33339-145">なし</span><span class="sxs-lookup"><span data-stu-id="33339-145">None</span></span> 

<span data-ttu-id="33339-146">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="33339-146">**Status code**</span></span>

<span data-ttu-id="33339-147">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33339-147">This API has the following expected status codes.</span></span>

<span data-ttu-id="33339-148">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="33339-148">HTTP status code</span></span>      | <span data-ttu-id="33339-149">説明</span><span class="sxs-lookup"><span data-stu-id="33339-149">Description</span></span>
:------     | :-----
<span data-ttu-id="33339-150">204</span><span class="sxs-lookup"><span data-stu-id="33339-150">204</span></span> | <span data-ttu-id="33339-151">コントローラーを接続する要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="33339-151">The request to disconnect controllers was successful.</span></span>
<span data-ttu-id="33339-152">4XX</span><span class="sxs-lookup"><span data-stu-id="33339-152">4XX</span></span> | <span data-ttu-id="33339-153">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33339-153">Error codes</span></span>
<span data-ttu-id="33339-154">5XX</span><span class="sxs-lookup"><span data-stu-id="33339-154">5XX</span></span> | <span data-ttu-id="33339-155">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33339-155">Error codes</span></span>

<br />
<span data-ttu-id="33339-156">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="33339-156">**Available device families**</span></span>

* <span data-ttu-id="33339-157">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="33339-157">Windows Xbox</span></span>
