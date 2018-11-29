---
title: デバイス ポータル コントローラー API リファレンス
description: 接続された物理コントローラーの数を取得し、プログラムでオフにする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 8b5061f9193d78d4ff23f5fa707b0bea67a10f98
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7988279"
---
# <a name="controller-api-reference"></a><span data-ttu-id="44310-104">コントローラー API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="44310-104">Controller API reference</span></span>   
<span data-ttu-id="44310-105">接続された物理コントローラーの数を取得し、REST API を使用してオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="44310-105">You can get the number of attached physical controllers and turn them off using this REST API.</span></span>

## <a name="determine-the-number-of-attached-physical-controllers"></a><span data-ttu-id="44310-106">接続された物理コントローラーの数の決定</span><span class="sxs-lookup"><span data-stu-id="44310-106">Determine the number of attached physical controllers</span></span>

**<span data-ttu-id="44310-107">要求</span><span class="sxs-lookup"><span data-stu-id="44310-107">Request</span></span>**

<span data-ttu-id="44310-108">次の要求を使用して、デバイス上に接続された物理コントローラーの数を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="44310-108">You can check the number of attached physical controllers on the device using the following request.</span></span>

<span data-ttu-id="44310-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="44310-109">Method</span></span>      | <span data-ttu-id="44310-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="44310-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="44310-111">GET</span><span class="sxs-lookup"><span data-stu-id="44310-111">GET</span></span> | <span data-ttu-id="44310-112">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="44310-112">/ext/remoteinput/controllers</span></span>
<br />
**<span data-ttu-id="44310-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44310-113">URI parameters</span></span>**

- <span data-ttu-id="44310-114">なし</span><span class="sxs-lookup"><span data-stu-id="44310-114">None</span></span>

**<span data-ttu-id="44310-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="44310-115">Request headers</span></span>**

- <span data-ttu-id="44310-116">なし</span><span class="sxs-lookup"><span data-stu-id="44310-116">None</span></span>

**<span data-ttu-id="44310-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="44310-117">Request body</span></span>**   

- <span data-ttu-id="44310-118">なし</span><span class="sxs-lookup"><span data-stu-id="44310-118">None</span></span>

**<span data-ttu-id="44310-119">応答</span><span class="sxs-lookup"><span data-stu-id="44310-119">Response</span></span>**   

- <span data-ttu-id="44310-120">接続された物理コントローラーの数を指定する JSON 数値プロパティ ConnectedControllerCount です。</span><span class="sxs-lookup"><span data-stu-id="44310-120">JSON number property ConnectedControllerCount which specifies the number of attached physical controllers.</span></span>

**<span data-ttu-id="44310-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="44310-121">Status code</span></span>**

<span data-ttu-id="44310-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="44310-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="44310-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="44310-123">HTTP status code</span></span>      | <span data-ttu-id="44310-124">説明</span><span class="sxs-lookup"><span data-stu-id="44310-124">Description</span></span>
:------     | :-----
<span data-ttu-id="44310-125">200</span><span class="sxs-lookup"><span data-stu-id="44310-125">200</span></span> | <span data-ttu-id="44310-126">成功</span><span class="sxs-lookup"><span data-stu-id="44310-126">Success</span></span>
<span data-ttu-id="44310-127">4XX</span><span class="sxs-lookup"><span data-stu-id="44310-127">4XX</span></span> | <span data-ttu-id="44310-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="44310-128">Error codes</span></span>
<span data-ttu-id="44310-129">5XX</span><span class="sxs-lookup"><span data-stu-id="44310-129">5XX</span></span> | <span data-ttu-id="44310-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="44310-130">Error codes</span></span>

## <a name="disconnect-all-physical-controllers-on-the-devkit"></a><span data-ttu-id="44310-131">開発キット上のすべての物理コントローラーの切断</span><span class="sxs-lookup"><span data-stu-id="44310-131">Disconnect all physical controllers on the devkit</span></span>

**<span data-ttu-id="44310-132">要求</span><span class="sxs-lookup"><span data-stu-id="44310-132">Request</span></span>**

<span data-ttu-id="44310-133">次の要求を使って、デバイス上のすべての物理コントローラーを切断することができます。</span><span class="sxs-lookup"><span data-stu-id="44310-133">You can disconnect all physical controllers on the device using the following request.</span></span>

<span data-ttu-id="44310-134">メソッド</span><span class="sxs-lookup"><span data-stu-id="44310-134">Method</span></span>      | <span data-ttu-id="44310-135">要求 URI</span><span class="sxs-lookup"><span data-stu-id="44310-135">Request URI</span></span>
:------     | :-----
<span data-ttu-id="44310-136">DELETE</span><span class="sxs-lookup"><span data-stu-id="44310-136">DELETE</span></span> | <span data-ttu-id="44310-137">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="44310-137">/ext/remoteinput/controllers</span></span>
<br />
**<span data-ttu-id="44310-138">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44310-138">URI parameters</span></span>**

- <span data-ttu-id="44310-139">なし</span><span class="sxs-lookup"><span data-stu-id="44310-139">None</span></span>

**<span data-ttu-id="44310-140">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="44310-140">Request headers</span></span>**

- <span data-ttu-id="44310-141">なし</span><span class="sxs-lookup"><span data-stu-id="44310-141">None</span></span>

**<span data-ttu-id="44310-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="44310-142">Request body</span></span>**   

- <span data-ttu-id="44310-143">なし</span><span class="sxs-lookup"><span data-stu-id="44310-143">None</span></span>

**<span data-ttu-id="44310-144">応答</span><span class="sxs-lookup"><span data-stu-id="44310-144">Response</span></span>**   

- <span data-ttu-id="44310-145">なし</span><span class="sxs-lookup"><span data-stu-id="44310-145">None</span></span> 

**<span data-ttu-id="44310-146">状態コード</span><span class="sxs-lookup"><span data-stu-id="44310-146">Status code</span></span>**

<span data-ttu-id="44310-147">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="44310-147">This API has the following expected status codes.</span></span>

<span data-ttu-id="44310-148">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="44310-148">HTTP status code</span></span>      | <span data-ttu-id="44310-149">説明</span><span class="sxs-lookup"><span data-stu-id="44310-149">Description</span></span>
:------     | :-----
<span data-ttu-id="44310-150">204</span><span class="sxs-lookup"><span data-stu-id="44310-150">204</span></span> | <span data-ttu-id="44310-151">コントローラーを接続する要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="44310-151">The request to disconnect controllers was successful.</span></span>
<span data-ttu-id="44310-152">4XX</span><span class="sxs-lookup"><span data-stu-id="44310-152">4XX</span></span> | <span data-ttu-id="44310-153">エラー コード</span><span class="sxs-lookup"><span data-stu-id="44310-153">Error codes</span></span>
<span data-ttu-id="44310-154">5XX</span><span class="sxs-lookup"><span data-stu-id="44310-154">5XX</span></span> | <span data-ttu-id="44310-155">エラー コード</span><span class="sxs-lookup"><span data-stu-id="44310-155">Error codes</span></span>

<br />
**<span data-ttu-id="44310-156">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="44310-156">Available device families</span></span>**

* <span data-ttu-id="44310-157">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="44310-157">Windows Xbox</span></span>
