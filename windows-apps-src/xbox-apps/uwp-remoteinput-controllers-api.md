---
author: WilliamsJason
title: デバイス ポータル コントローラー API リファレンス
description: 接続された物理コントローラーの数を取得し、プログラムでオフにする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 292c9c29149b56b9be4255215e97e703278d8abf
ms.sourcegitcommit: c104b653601d9b81cfc8bb6032ca434cff8fe9b1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/25/2018
ms.locfileid: "1921262"
---
# <a name="controller-api-reference"></a><span data-ttu-id="6a238-104">コントローラー API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="6a238-104">Controller API reference</span></span>   
<span data-ttu-id="6a238-105">接続された物理コントローラーの数を取得し、REST API を使用してオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="6a238-105">You can get the number of attached physical controllers and turn them off using this REST API.</span></span>

## <a name="determine-the-number-of-attached-physical-controllers"></a><span data-ttu-id="6a238-106">接続された物理コントローラーの数の決定</span><span class="sxs-lookup"><span data-stu-id="6a238-106">Determine the number of attached physical controllers</span></span>

**<span data-ttu-id="6a238-107">要求</span><span class="sxs-lookup"><span data-stu-id="6a238-107">Request</span></span>**

<span data-ttu-id="6a238-108">次の要求を使用して、デバイス上に接続された物理コントローラーの数を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="6a238-108">You can check the number of attached physical controllers on the device using the following request.</span></span>

<span data-ttu-id="6a238-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="6a238-109">Method</span></span>      | <span data-ttu-id="6a238-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="6a238-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="6a238-111">GET</span><span class="sxs-lookup"><span data-stu-id="6a238-111">GET</span></span> | <span data-ttu-id="6a238-112">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="6a238-112">/ext/remoteinput/controllers</span></span>
<br />
**<span data-ttu-id="6a238-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6a238-113">URI parameters</span></span>**

- <span data-ttu-id="6a238-114">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-114">None</span></span>

**<span data-ttu-id="6a238-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6a238-115">Request headers</span></span>**

- <span data-ttu-id="6a238-116">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-116">None</span></span>

**<span data-ttu-id="6a238-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="6a238-117">Request body</span></span>**   

- <span data-ttu-id="6a238-118">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-118">None</span></span>

**<span data-ttu-id="6a238-119">応答</span><span class="sxs-lookup"><span data-stu-id="6a238-119">Response</span></span>**   

- <span data-ttu-id="6a238-120">接続された物理コントローラーの数を指定する JSON 数値プロパティ ConnectedControllerCount です。</span><span class="sxs-lookup"><span data-stu-id="6a238-120">JSON number property ConnectedControllerCount which specifies the number of attached physical controllers.</span></span>

**<span data-ttu-id="6a238-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="6a238-121">Status code</span></span>**

<span data-ttu-id="6a238-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6a238-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="6a238-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="6a238-123">HTTP status code</span></span>      | <span data-ttu-id="6a238-124">説明</span><span class="sxs-lookup"><span data-stu-id="6a238-124">Description</span></span>
:------     | :-----
<span data-ttu-id="6a238-125">200</span><span class="sxs-lookup"><span data-stu-id="6a238-125">200</span></span> | <span data-ttu-id="6a238-126">成功</span><span class="sxs-lookup"><span data-stu-id="6a238-126">Success</span></span>
<span data-ttu-id="6a238-127">4XX</span><span class="sxs-lookup"><span data-stu-id="6a238-127">4XX</span></span> | <span data-ttu-id="6a238-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6a238-128">Error codes</span></span>
<span data-ttu-id="6a238-129">5XX</span><span class="sxs-lookup"><span data-stu-id="6a238-129">5XX</span></span> | <span data-ttu-id="6a238-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6a238-130">Error codes</span></span>

## <a name="disconnect-all-physical-controllers-on-the-devkit"></a><span data-ttu-id="6a238-131">開発キット上のすべての物理コントローラーの切断</span><span class="sxs-lookup"><span data-stu-id="6a238-131">Disconnect all physical controllers on the devkit</span></span>

**<span data-ttu-id="6a238-132">要求</span><span class="sxs-lookup"><span data-stu-id="6a238-132">Request</span></span>**

<span data-ttu-id="6a238-133">次の要求を使って、デバイス上のすべての物理コントローラーを切断することができます。</span><span class="sxs-lookup"><span data-stu-id="6a238-133">You can disconnect all physical controllers on the device using the following request.</span></span>

<span data-ttu-id="6a238-134">メソッド</span><span class="sxs-lookup"><span data-stu-id="6a238-134">Method</span></span>      | <span data-ttu-id="6a238-135">要求 URI</span><span class="sxs-lookup"><span data-stu-id="6a238-135">Request URI</span></span>
:------     | :-----
<span data-ttu-id="6a238-136">DELETE</span><span class="sxs-lookup"><span data-stu-id="6a238-136">DELETE</span></span> | <span data-ttu-id="6a238-137">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="6a238-137">/ext/remoteinput/controllers</span></span>
<br />
**<span data-ttu-id="6a238-138">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6a238-138">URI parameters</span></span>**

- <span data-ttu-id="6a238-139">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-139">None</span></span>

**<span data-ttu-id="6a238-140">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6a238-140">Request headers</span></span>**

- <span data-ttu-id="6a238-141">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-141">None</span></span>

**<span data-ttu-id="6a238-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="6a238-142">Request body</span></span>**   

- <span data-ttu-id="6a238-143">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-143">None</span></span>

**<span data-ttu-id="6a238-144">応答</span><span class="sxs-lookup"><span data-stu-id="6a238-144">Response</span></span>**   

- <span data-ttu-id="6a238-145">なし</span><span class="sxs-lookup"><span data-stu-id="6a238-145">None</span></span> 

**<span data-ttu-id="6a238-146">状態コード</span><span class="sxs-lookup"><span data-stu-id="6a238-146">Status code</span></span>**

<span data-ttu-id="6a238-147">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6a238-147">This API has the following expected status codes.</span></span>

<span data-ttu-id="6a238-148">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="6a238-148">HTTP status code</span></span>      | <span data-ttu-id="6a238-149">説明</span><span class="sxs-lookup"><span data-stu-id="6a238-149">Description</span></span>
:------     | :-----
<span data-ttu-id="6a238-150">204</span><span class="sxs-lookup"><span data-stu-id="6a238-150">204</span></span> | <span data-ttu-id="6a238-151">コントローラーを接続する要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="6a238-151">The request to disconnect controllers was successful.</span></span>
<span data-ttu-id="6a238-152">4XX</span><span class="sxs-lookup"><span data-stu-id="6a238-152">4XX</span></span> | <span data-ttu-id="6a238-153">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6a238-153">Error codes</span></span>
<span data-ttu-id="6a238-154">5XX</span><span class="sxs-lookup"><span data-stu-id="6a238-154">5XX</span></span> | <span data-ttu-id="6a238-155">エラー コード</span><span class="sxs-lookup"><span data-stu-id="6a238-155">Error codes</span></span>

<br />
**<span data-ttu-id="6a238-156">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="6a238-156">Available device families</span></span>**

* <span data-ttu-id="6a238-157">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="6a238-157">Windows Xbox</span></span>
