---
author: PatrickFarley
ms.assetid: 41ac0142-4d86-4bb3-b580-36d0d6956091
title: "HoloLens 用 Device Portal API リファレンス"
description: "HoloLens 用の Windows Device Portal REST API について説明します。これらの API を使うと、プログラムからデータにアクセスしてデバイスを制御できます。"
ms.openlocfilehash: 3c000bc19c0bd45050e5be1ca73e5dc7b73d8103
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
---
# <a name="device-portal-api-reference-for-hololens"></a><span data-ttu-id="4581f-103">HoloLens 用 Device Portal API リファレンス</span><span class="sxs-lookup"><span data-stu-id="4581f-103">Device Portal API reference for HoloLens</span></span>

<span data-ttu-id="4581f-104">Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-104">Everything in the Windows Device Portal is built on top of REST API's that you can use to access the data and control your device programmatically.</span></span>

## <a name="holographic-os"></a><span data-ttu-id="4581f-105">ホログラフィック OS</span><span class="sxs-lookup"><span data-stu-id="4581f-105">Holographic OS</span></span>
---
### <a name="get-https-requirements-for-the-device-portal"></a><span data-ttu-id="4581f-106">Device Portal の HTTPS 要件を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-106">Get HTTPS requirements for the Device Portal</span></span>

**<span data-ttu-id="4581f-107">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-107">Request</span></span>**

<span data-ttu-id="4581f-108">次の要求型式を使用して、Device Portal の HTTPS 要件を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-108">You can get the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
<span data-ttu-id="4581f-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-109">Method</span></span>      | <span data-ttu-id="4581f-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-111">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-111">GET</span></span> | <span data-ttu-id="4581f-112">/api/holographic/os/webmanagement/settings/https</span><span class="sxs-lookup"><span data-stu-id="4581f-112">/api/holographic/os/webmanagement/settings/https</span></span>


**<span data-ttu-id="4581f-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-113">URI parameters</span></span>**

- <span data-ttu-id="4581f-114">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-114">None</span></span>

**<span data-ttu-id="4581f-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-115">Request headers</span></span>**

- <span data-ttu-id="4581f-116">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-116">None</span></span>

**<span data-ttu-id="4581f-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-117">Request body</span></span>**

- <span data-ttu-id="4581f-118">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-118">None</span></span>

**<span data-ttu-id="4581f-119">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-119">Response</span></span>**

- <span data-ttu-id="4581f-120">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-120">None</span></span>

**<span data-ttu-id="4581f-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-121">Status code</span></span>**

- <span data-ttu-id="4581f-122">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-122">Standard status codes.</span></span>

---
### <a name="get-the-stored-interpupillary-distance-ipd"></a><span data-ttu-id="4581f-123">保存されている瞳孔間距離 (IPD) を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-123">Get the stored interpupillary distance (IPD)</span></span>

**<span data-ttu-id="4581f-124">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-124">Request</span></span>**

<span data-ttu-id="4581f-125">次の要求型式を使用して、保存されている IPD の値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-125">You can get the stored IPD value by using the following request format.</span></span> <span data-ttu-id="4581f-126">値はミリメートル単位で返されます。</span><span class="sxs-lookup"><span data-stu-id="4581f-126">The value is returned in millimeters.</span></span>
 
<span data-ttu-id="4581f-127">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-127">Method</span></span>      | <span data-ttu-id="4581f-128">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-128">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-129">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-129">GET</span></span> | <span data-ttu-id="4581f-130">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="4581f-130">/api/holographic/os/settings/ipd</span></span>


**<span data-ttu-id="4581f-131">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-131">URI parameters</span></span>**

- <span data-ttu-id="4581f-132">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-132">None</span></span>

**<span data-ttu-id="4581f-133">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-133">Request headers</span></span>**

- <span data-ttu-id="4581f-134">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-134">None</span></span>

**<span data-ttu-id="4581f-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-135">Request body</span></span>**

- <span data-ttu-id="4581f-136">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-136">None</span></span>

**<span data-ttu-id="4581f-137">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-137">Response</span></span>**

- <span data-ttu-id="4581f-138">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-138">None</span></span>

**<span data-ttu-id="4581f-139">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-139">Status code</span></span>**

- <span data-ttu-id="4581f-140">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-140">Standard status codes.</span></span>

---
### <a name="get-a-list-of-hololens-specific-etw-providers"></a><span data-ttu-id="4581f-141">HoloLens 固有の ETW プロバイダーの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-141">Get a list of HoloLens specific ETW providers</span></span>

**<span data-ttu-id="4581f-142">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-142">Request</span></span>**

<span data-ttu-id="4581f-143">次の要求型式を使用して、システムには登録されていない HoloLens 固有の ETW プロバイダーの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-143">You can get a list of HoloLens specific ETW providers that are not registered with the system by using the following request format.</span></span>
 
<span data-ttu-id="4581f-144">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-144">Method</span></span>      | <span data-ttu-id="4581f-145">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-145">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-146">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-146">GET</span></span> | <span data-ttu-id="4581f-147">/api/holographic/os/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="4581f-147">/api/holographic/os/etw/customproviders</span></span>


**<span data-ttu-id="4581f-148">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-148">URI parameters</span></span>**

- <span data-ttu-id="4581f-149">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-149">None</span></span>

**<span data-ttu-id="4581f-150">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-150">Request headers</span></span>**

- <span data-ttu-id="4581f-151">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-151">None</span></span>

**<span data-ttu-id="4581f-152">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-152">Request body</span></span>**

- <span data-ttu-id="4581f-153">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-153">None</span></span>

**<span data-ttu-id="4581f-154">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-154">Response</span></span>**

- <span data-ttu-id="4581f-155">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-155">None</span></span>

**<span data-ttu-id="4581f-156">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-156">Status code</span></span>**

- <span data-ttu-id="4581f-157">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-157">Standard status codes.</span></span>

---
### <a name="return-the-state-for-all-active-services"></a><span data-ttu-id="4581f-158">アクティブなすべてのサービスの状態を返す</span><span class="sxs-lookup"><span data-stu-id="4581f-158">Return the state for all active services</span></span>

**<span data-ttu-id="4581f-159">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-159">Request</span></span>**

<span data-ttu-id="4581f-160">次の要求形式を使用して、現在実行されているすべてのサービスの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-160">You can get the state of all services that are currently running by using the following request format.</span></span>
 
<span data-ttu-id="4581f-161">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-161">Method</span></span>      | <span data-ttu-id="4581f-162">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-162">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-163">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-163">GET</span></span> | <span data-ttu-id="4581f-164">/api/holographic/os/services</span><span class="sxs-lookup"><span data-stu-id="4581f-164">/api/holographic/os/services</span></span>


**<span data-ttu-id="4581f-165">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-165">URI parameters</span></span>**

- <span data-ttu-id="4581f-166">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-166">None</span></span>

**<span data-ttu-id="4581f-167">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-167">Request headers</span></span>**

- <span data-ttu-id="4581f-168">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-168">None</span></span>

**<span data-ttu-id="4581f-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-169">Request body</span></span>**

- <span data-ttu-id="4581f-170">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-170">None</span></span>

**<span data-ttu-id="4581f-171">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-171">Response</span></span>**

- <span data-ttu-id="4581f-172">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-172">None</span></span>

**<span data-ttu-id="4581f-173">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-173">Status code</span></span>**

- <span data-ttu-id="4581f-174">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-174">Standard status codes.</span></span>

---
### <a name="set-the-https-requirement-for-the-device-portal"></a><span data-ttu-id="4581f-175">Device Portal の HTTPS 要件を設定する</span><span class="sxs-lookup"><span data-stu-id="4581f-175">Set the HTTPS requirement for the Device Portal.</span></span>

**<span data-ttu-id="4581f-176">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-176">Request</span></span>**

<span data-ttu-id="4581f-177">次の要求形式を使用して、Device Portal の HTTPS 要件を設定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-177">You can set the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
<span data-ttu-id="4581f-178">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-178">Method</span></span>      | <span data-ttu-id="4581f-179">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-179">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-180">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-180">POST</span></span> | <span data-ttu-id="4581f-181">/api/holographic/management/settings/https</span><span class="sxs-lookup"><span data-stu-id="4581f-181">/api/holographic/management/settings/https</span></span>


**<span data-ttu-id="4581f-182">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-182">URI parameters</span></span>**

<span data-ttu-id="4581f-183">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-183">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-184">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-184">URI parameter</span></span> | <span data-ttu-id="4581f-185">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-185">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-186">required</span><span class="sxs-lookup"><span data-stu-id="4581f-186">required</span></span>   | <span data-ttu-id="4581f-187">(**必須**) Device Portal で HTTPS を必要とするかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-187">(**required**) Determines whether or not HTTPS is required for the Device Portal.</span></span> <span data-ttu-id="4581f-188">指定できる値は、**yes**、**no**、**default** です。</span><span class="sxs-lookup"><span data-stu-id="4581f-188">Possible values are **yes**, **no**, and **default**.</span></span>

**<span data-ttu-id="4581f-189">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-189">Request headers</span></span>**

- <span data-ttu-id="4581f-190">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-190">None</span></span>

**<span data-ttu-id="4581f-191">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-191">Request body</span></span>**

- <span data-ttu-id="4581f-192">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-192">None</span></span>

**<span data-ttu-id="4581f-193">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-193">Response</span></span>**

- <span data-ttu-id="4581f-194">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-194">None</span></span>

**<span data-ttu-id="4581f-195">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-195">Status code</span></span>**

- <span data-ttu-id="4581f-196">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-196">Standard status codes.</span></span>

---
### <a name="set-the-interpupillary-distance-ipd"></a><span data-ttu-id="4581f-197">瞳孔間距離 (IPD) を設定する</span><span class="sxs-lookup"><span data-stu-id="4581f-197">Set the interpupillary distance (IPD)</span></span>

**<span data-ttu-id="4581f-198">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-198">Request</span></span>**

<span data-ttu-id="4581f-199">次の要求形式を使用して、保存されている IPD を設定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-199">You can set the stored IPD by using the following request format.</span></span>
 
<span data-ttu-id="4581f-200">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-200">Method</span></span>      | <span data-ttu-id="4581f-201">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-201">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-202">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-202">POST</span></span> | <span data-ttu-id="4581f-203">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="4581f-203">/api/holographic/os/settings/ipd</span></span>


**<span data-ttu-id="4581f-204">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-204">URI parameters</span></span>**

<span data-ttu-id="4581f-205">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-205">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-206">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-206">URI parameter</span></span> | <span data-ttu-id="4581f-207">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-207">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-208">ipd</span><span class="sxs-lookup"><span data-stu-id="4581f-208">ipd</span></span>   | <span data-ttu-id="4581f-209">(**必須**) 保存する新しい IPD 値。</span><span class="sxs-lookup"><span data-stu-id="4581f-209">(**required**) The new IPD value to be stored.</span></span> <span data-ttu-id="4581f-210">この値はミリメートル単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-210">This value should be in millimeters.</span></span>

**<span data-ttu-id="4581f-211">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-211">Request headers</span></span>**

- <span data-ttu-id="4581f-212">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-212">None</span></span>

**<span data-ttu-id="4581f-213">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-213">Request body</span></span>**

- <span data-ttu-id="4581f-214">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-214">None</span></span>

**<span data-ttu-id="4581f-215">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-215">Response</span></span>**

- <span data-ttu-id="4581f-216">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-216">None</span></span>

**<span data-ttu-id="4581f-217">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-217">Status code</span></span>**

- <span data-ttu-id="4581f-218">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-218">Standard status codes.</span></span>

---
## Holographic perception
---
### <a name="accept-websocket-upgrades-and-run-a-mirage-client-that-sends-updates"></a><span data-ttu-id="4581f-219">WebSocket のアップグレードを受け入れ、ミラージュ クライアントを実行する</span><span class="sxs-lookup"><span data-stu-id="4581f-219">Accept websocket upgrades and run a mirage client that sends updates</span></span>

**<span data-ttu-id="4581f-220">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-220">Request</span></span>**

<span data-ttu-id="4581f-221">次の要求型式を使用して、WebSocket のアップグレードを受け入れ、30fps で更新を送信するミラージュ クライアントを実行できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-221">You can accept websocket upgrades and run a mirage client that sends updates at 30 fps by using the following request format.</span></span>
 
<span data-ttu-id="4581f-222">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-222">Method</span></span>      | <span data-ttu-id="4581f-223">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-223">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-224">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="4581f-224">GET/WebSocket</span></span> | <span data-ttu-id="4581f-225">/api/holographic/perception/client</span><span class="sxs-lookup"><span data-stu-id="4581f-225">/api/holographic/perception/client</span></span>


**<span data-ttu-id="4581f-226">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-226">URI parameters</span></span>**

<span data-ttu-id="4581f-227">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-227">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-228">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-228">URI parameter</span></span> | <span data-ttu-id="4581f-229">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-229">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-230">clientmode</span><span class="sxs-lookup"><span data-stu-id="4581f-230">clientmode</span></span>   | <span data-ttu-id="4581f-231">(**必須**) 追跡モードを決定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-231">(**required**) Determines the tracking mode.</span></span> <span data-ttu-id="4581f-232">値を **active** に設定すると、パッシブに確立できない場合は視覚追跡モードが強制されます。</span><span class="sxs-lookup"><span data-stu-id="4581f-232">A value of **active** forces visual tracking mode when it can't be established passively.</span></span>

**<span data-ttu-id="4581f-233">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-233">Request headers</span></span>**

- <span data-ttu-id="4581f-234">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-234">None</span></span>

**<span data-ttu-id="4581f-235">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-235">Request body</span></span>**

- <span data-ttu-id="4581f-236">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-236">None</span></span>

**<span data-ttu-id="4581f-237">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-237">Response</span></span>**

- <span data-ttu-id="4581f-238">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-238">None</span></span>

**<span data-ttu-id="4581f-239">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-239">Status code</span></span>**

- <span data-ttu-id="4581f-240">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-240">Standard status codes.</span></span>

---
## Holographic thermal
---
### <a name="get-the-thermal-stage-of-the-device"></a><span data-ttu-id="4581f-241">デバイスの温度ステージを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-241">Get the thermal stage of the device</span></span>

**<span data-ttu-id="4581f-242">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-242">Request</span></span>**

<span data-ttu-id="4581f-243">次の要求形式を使用して、デバイスの温度ステージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-243">You can get the thermal stage of the device by using the following request format.</span></span>
 
<span data-ttu-id="4581f-244">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-244">Method</span></span>      | <span data-ttu-id="4581f-245">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-245">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-246">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-246">GET</span></span> | <span data-ttu-id="4581f-247">/api/holographic/</span><span class="sxs-lookup"><span data-stu-id="4581f-247">/api/holographic/</span></span>

**<span data-ttu-id="4581f-248">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-248">URI parameters</span></span>**

- <span data-ttu-id="4581f-249">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-249">None</span></span>

**<span data-ttu-id="4581f-250">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-250">Request headers</span></span>**

- <span data-ttu-id="4581f-251">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-251">None</span></span>

**<span data-ttu-id="4581f-252">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-252">Request body</span></span>**

- <span data-ttu-id="4581f-253">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-253">None</span></span>

**<span data-ttu-id="4581f-254">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-254">Response</span></span>**

<span data-ttu-id="4581f-255">返される可能性のある値を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-255">The possible values are indicated by the following table.</span></span>

<span data-ttu-id="4581f-256">値</span><span class="sxs-lookup"><span data-stu-id="4581f-256">Value</span></span> | <span data-ttu-id="4581f-257">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-257">Description</span></span>
--- | ---
<span data-ttu-id="4581f-258">1</span><span class="sxs-lookup"><span data-stu-id="4581f-258">1</span></span> | <span data-ttu-id="4581f-259">正常</span><span class="sxs-lookup"><span data-stu-id="4581f-259">Normal</span></span>
<span data-ttu-id="4581f-260">2</span><span class="sxs-lookup"><span data-stu-id="4581f-260">2</span></span> | <span data-ttu-id="4581f-261">中温</span><span class="sxs-lookup"><span data-stu-id="4581f-261">Warm</span></span>
<span data-ttu-id="4581f-262">3</span><span class="sxs-lookup"><span data-stu-id="4581f-262">3</span></span> | <span data-ttu-id="4581f-263">重大</span><span class="sxs-lookup"><span data-stu-id="4581f-263">Critical</span></span>

**<span data-ttu-id="4581f-264">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-264">Status code</span></span>**

- <span data-ttu-id="4581f-265">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-265">Standard status codes.</span></span>

---
## HSimulation control
---
### <a name="create-a-control-stream-or-post-data-to-a-created-stream"></a><span data-ttu-id="4581f-266">制御ストリームを作成する、または作成されたストリームにデータをポストする</span><span class="sxs-lookup"><span data-stu-id="4581f-266">Create a control stream or post data to a created stream</span></span>

**<span data-ttu-id="4581f-267">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-267">Request</span></span>**

<span data-ttu-id="4581f-268">次の要求形式を使用して、制御ストリームを作成したり、作成されたストリームにデータをポストしたりできます。</span><span class="sxs-lookup"><span data-stu-id="4581f-268">You can create a control stream or post data to a created stream by using the following request format.</span></span> <span data-ttu-id="4581f-269">ポストされるデータの種類は **application/octet-stream** と想定されます。</span><span class="sxs-lookup"><span data-stu-id="4581f-269">The posted data is expected to be of type **application/octet-stream**.</span></span>
 
<span data-ttu-id="4581f-270">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-270">Method</span></span>      | <span data-ttu-id="4581f-271">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-271">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-272">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-272">POST</span></span> | <span data-ttu-id="4581f-273">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="4581f-273">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="4581f-274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-274">URI parameters</span></span>**

<span data-ttu-id="4581f-275">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-275">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-276">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-276">URI parameter</span></span> | <span data-ttu-id="4581f-277">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-277">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-278">priority</span><span class="sxs-lookup"><span data-stu-id="4581f-278">priority</span></span>   | <span data-ttu-id="4581f-279">(**制御ストリームを作成する場合は必須**) ストリームの優先度を示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-279">(**required if creating a control stream**) Indicates the priority of the stream.</span></span>
<span data-ttu-id="4581f-280">streamid</span><span class="sxs-lookup"><span data-stu-id="4581f-280">streamid</span></span>   | <span data-ttu-id="4581f-281">(**作成されたストリームにポストする場合は必須**) ポスト先のストリームの識別子。</span><span class="sxs-lookup"><span data-stu-id="4581f-281">(**required if posting to a created stream**) The identifier for the stream to post to.</span></span>

**<span data-ttu-id="4581f-282">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-282">Request headers</span></span>**

- <span data-ttu-id="4581f-283">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-283">None</span></span>

**<span data-ttu-id="4581f-284">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-284">Request body</span></span>**

- <span data-ttu-id="4581f-285">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-285">None</span></span>

**<span data-ttu-id="4581f-286">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-286">Response</span></span>**

- <span data-ttu-id="4581f-287">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-287">None</span></span>

**<span data-ttu-id="4581f-288">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-288">Status code</span></span>**

- <span data-ttu-id="4581f-289">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-289">Standard status codes.</span></span>

---
### <a name="delete-a-control-stream"></a><span data-ttu-id="4581f-290">制御ストリームを削除する</span><span class="sxs-lookup"><span data-stu-id="4581f-290">Delete a control stream</span></span>

**<span data-ttu-id="4581f-291">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-291">Request</span></span>**

<span data-ttu-id="4581f-292">次の要求形式を使用して、制御ストリームを削除できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-292">You can delete a control stream by using the following request format.</span></span>
 
<span data-ttu-id="4581f-293">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-293">Method</span></span>      | <span data-ttu-id="4581f-294">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-294">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-295">DELETE</span><span class="sxs-lookup"><span data-stu-id="4581f-295">DELETE</span></span> | <span data-ttu-id="4581f-296">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="4581f-296">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="4581f-297">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-297">URI parameters</span></span>**

- <span data-ttu-id="4581f-298">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-298">None</span></span>

**<span data-ttu-id="4581f-299">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-299">Request headers</span></span>**

- <span data-ttu-id="4581f-300">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-300">None</span></span>

**<span data-ttu-id="4581f-301">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-301">Request body</span></span>**

- <span data-ttu-id="4581f-302">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-302">None</span></span>

**<span data-ttu-id="4581f-303">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-303">Response</span></span>**

- <span data-ttu-id="4581f-304">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-304">None</span></span>

**<span data-ttu-id="4581f-305">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-305">Status code</span></span>**

- <span data-ttu-id="4581f-306">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-306">Standard status codes.</span></span>

---
### <a name="get-a-control-stream"></a><span data-ttu-id="4581f-307">制御ストリームを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-307">Get a control stream</span></span>

**<span data-ttu-id="4581f-308">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-308">Request</span></span>**

<span data-ttu-id="4581f-309">次の要求形式を使用して、制御ストリームの Web ソケット接続を開くことができます。</span><span class="sxs-lookup"><span data-stu-id="4581f-309">You can open a web socket connection for a control stream by using the following request format.</span></span>
 
<span data-ttu-id="4581f-310">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-310">Method</span></span>      | <span data-ttu-id="4581f-311">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-311">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-312">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="4581f-312">GET/WebSocket</span></span> | <span data-ttu-id="4581f-313">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="4581f-313">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="4581f-314">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-314">URI parameters</span></span>**

- <span data-ttu-id="4581f-315">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-315">None</span></span>

**<span data-ttu-id="4581f-316">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-316">Request headers</span></span>**

- <span data-ttu-id="4581f-317">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-317">None</span></span>

**<span data-ttu-id="4581f-318">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-318">Request body</span></span>**

- <span data-ttu-id="4581f-319">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-319">None</span></span>

**<span data-ttu-id="4581f-320">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-320">Response</span></span>**

- <span data-ttu-id="4581f-321">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-321">None</span></span>

**<span data-ttu-id="4581f-322">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-322">Status code</span></span>**

- <span data-ttu-id="4581f-323">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-323">Standard status codes.</span></span>

---
### <a name="get-the-simluation-mode"></a><span data-ttu-id="4581f-324">シミュレーション モードを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-324">Get the simluation mode</span></span>

**<span data-ttu-id="4581f-325">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-325">Request</span></span>**

<span data-ttu-id="4581f-326">次の要求形式を使用して、シミュレーション モードを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-326">You can get the simluation mode by using the following request format.</span></span>
 
<span data-ttu-id="4581f-327">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-327">Method</span></span>      | <span data-ttu-id="4581f-328">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-328">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-329">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-329">GET</span></span> | <span data-ttu-id="4581f-330">/api/holographic/simulation/control/mode</span><span class="sxs-lookup"><span data-stu-id="4581f-330">/api/holographic/simulation/control/mode</span></span>


**<span data-ttu-id="4581f-331">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-331">URI parameters</span></span>**

- <span data-ttu-id="4581f-332">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-332">None</span></span>

**<span data-ttu-id="4581f-333">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-333">Request headers</span></span>**

- <span data-ttu-id="4581f-334">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-334">None</span></span>

**<span data-ttu-id="4581f-335">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-335">Request body</span></span>**

- <span data-ttu-id="4581f-336">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-336">None</span></span>

**<span data-ttu-id="4581f-337">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-337">Response</span></span>**

- <span data-ttu-id="4581f-338">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-338">None</span></span>

**<span data-ttu-id="4581f-339">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-339">Status code</span></span>**

- <span data-ttu-id="4581f-340">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-340">Standard status codes.</span></span>

---
### <a name="set-the-simluation-mode"></a><span data-ttu-id="4581f-341">シミュレーション モードを設定する</span><span class="sxs-lookup"><span data-stu-id="4581f-341">Set the simluation mode</span></span>

**<span data-ttu-id="4581f-342">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-342">Request</span></span>**

<span data-ttu-id="4581f-343">次の要求型式を使用して、シミュレーション モードを設定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-343">You can set the simulation mode by using the following request format.</span></span>
 
<span data-ttu-id="4581f-344">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-344">Method</span></span>      | <span data-ttu-id="4581f-345">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-345">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-346">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-346">POST</span></span> | <span data-ttu-id="4581f-347">/api/holographic/simluation/control/mode</span><span class="sxs-lookup"><span data-stu-id="4581f-347">/api/holographic/simluation/control/mode</span></span>


**<span data-ttu-id="4581f-348">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-348">URI parameters</span></span>**

<span data-ttu-id="4581f-349">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-349">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-350">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-350">URI parameter</span></span> | <span data-ttu-id="4581f-351">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-351">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-352">mode</span><span class="sxs-lookup"><span data-stu-id="4581f-352">mode</span></span>   | <span data-ttu-id="4581f-353">(**必須**) シミュレーション モードを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-353">(**required**) Indicates the simulation mode.</span></span> <span data-ttu-id="4581f-354">指定できる値は、**default**、**simulation**、**remote**、**legacy** です。</span><span class="sxs-lookup"><span data-stu-id="4581f-354">Possible values include **default**, **simulation**, **remote**, and **legacy**.</span></span>

**<span data-ttu-id="4581f-355">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-355">Request headers</span></span>**

- <span data-ttu-id="4581f-356">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-356">None</span></span>

**<span data-ttu-id="4581f-357">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-357">Request body</span></span>**

- <span data-ttu-id="4581f-358">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-358">None</span></span>

**<span data-ttu-id="4581f-359">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-359">Response</span></span>**

- <span data-ttu-id="4581f-360">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-360">None</span></span>

**<span data-ttu-id="4581f-361">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-361">Status code</span></span>**

- <span data-ttu-id="4581f-362">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-362">Standard status codes.</span></span>

---
## HSimulation playback
---
### <a name="delete-a-recording"></a><span data-ttu-id="4581f-363">レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="4581f-363">Delete a recording</span></span>

**<span data-ttu-id="4581f-364">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-364">Request</span></span>**

<span data-ttu-id="4581f-365">次の要求型式を使用して、レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-365">You can delete a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-366">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-366">Method</span></span>      | <span data-ttu-id="4581f-367">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-367">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-368">DELETE</span><span class="sxs-lookup"><span data-stu-id="4581f-368">DELETE</span></span> | <span data-ttu-id="4581f-369">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="4581f-369">/api/holographic/simulation/playback/file</span></span>


**<span data-ttu-id="4581f-370">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-370">URI parameters</span></span>**

<span data-ttu-id="4581f-371">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-371">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-372">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-372">URI parameter</span></span> | <span data-ttu-id="4581f-373">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-373">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-374">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-374">recording</span></span>   | <span data-ttu-id="4581f-375">(**必須**) 削除するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-375">(**required**) The name of the recording to delete.</span></span>

**<span data-ttu-id="4581f-376">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-376">Request headers</span></span>**

- <span data-ttu-id="4581f-377">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-377">None</span></span>

**<span data-ttu-id="4581f-378">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-378">Request body</span></span>**

- <span data-ttu-id="4581f-379">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-379">None</span></span>

**<span data-ttu-id="4581f-380">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-380">Response</span></span>**

- <span data-ttu-id="4581f-381">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-381">None</span></span>

**<span data-ttu-id="4581f-382">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-382">Status code</span></span>**

- <span data-ttu-id="4581f-383">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-383">Standard status codes.</span></span>

---
### <a name="get-all-recordings"></a><span data-ttu-id="4581f-384">すべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-384">Get all recordings</span></span>

**<span data-ttu-id="4581f-385">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-385">Request</span></span>**

<span data-ttu-id="4581f-386">次の要求形式を使用して、利用可能なすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-386">You can get all the available recordings by using the following request format.</span></span>
 
<span data-ttu-id="4581f-387">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-387">Method</span></span>      | <span data-ttu-id="4581f-388">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-388">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-389">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-389">GET</span></span> | <span data-ttu-id="4581f-390">/api/holographic/simulation/playback/files</span><span class="sxs-lookup"><span data-stu-id="4581f-390">/api/holographic/simulation/playback/files</span></span>


**<span data-ttu-id="4581f-391">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-391">URI parameters</span></span>**

- <span data-ttu-id="4581f-392">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-392">None</span></span>

**<span data-ttu-id="4581f-393">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-393">Request headers</span></span>**

- <span data-ttu-id="4581f-394">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-394">None</span></span>

**<span data-ttu-id="4581f-395">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-395">Request body</span></span>**

- <span data-ttu-id="4581f-396">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-396">None</span></span>

**<span data-ttu-id="4581f-397">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-397">Response</span></span>**

- <span data-ttu-id="4581f-398">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-398">None</span></span>

**<span data-ttu-id="4581f-399">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-399">Status code</span></span>**

- <span data-ttu-id="4581f-400">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-400">Standard status codes.</span></span>

---
### <a name="get-the-types-of-data-in-a-loaded-recording"></a><span data-ttu-id="4581f-401">読み込まれたレコーディング内のデータの種類を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-401">Get the types of data in a loaded recording</span></span>

**<span data-ttu-id="4581f-402">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-402">Request</span></span>**

<span data-ttu-id="4581f-403">次の要求形式を使用して、読み込まれたレコーディング内のデータの種類を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-403">You can get the types of data in a loaded recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-404">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-404">Method</span></span>      | <span data-ttu-id="4581f-405">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-405">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-406">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-406">GET</span></span> | <span data-ttu-id="4581f-407">/api/holographic/simulation/playback/session/types</span><span class="sxs-lookup"><span data-stu-id="4581f-407">/api/holographic/simulation/playback/session/types</span></span>


**<span data-ttu-id="4581f-408">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-408">URI parameters</span></span>**

<span data-ttu-id="4581f-409">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-409">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-410">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-410">URI parameter</span></span> | <span data-ttu-id="4581f-411">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-411">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-412">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-412">recording</span></span>   | <span data-ttu-id="4581f-413">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-413">(**required**) The name of the recording you are interested in.</span></span>

**<span data-ttu-id="4581f-414">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-414">Request headers</span></span>**

- <span data-ttu-id="4581f-415">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-415">None</span></span>

**<span data-ttu-id="4581f-416">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-416">Request body</span></span>**

- <span data-ttu-id="4581f-417">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-417">None</span></span>

**<span data-ttu-id="4581f-418">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-418">Response</span></span>**

- <span data-ttu-id="4581f-419">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-419">None</span></span>

**<span data-ttu-id="4581f-420">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-420">Status code</span></span>**

- <span data-ttu-id="4581f-421">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-421">Standard status codes.</span></span>

---
### <a name="get-all-the-loaded-recordings"></a><span data-ttu-id="4581f-422">読み込まれたすべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-422">Get all the loaded recordings</span></span>

**<span data-ttu-id="4581f-423">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-423">Request</span></span>**

<span data-ttu-id="4581f-424">次の要求形式を使用して、読み込まれたすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-424">You can get all the loaded recordings by using the following request format.</span></span>
 
<span data-ttu-id="4581f-425">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-425">Method</span></span>      | <span data-ttu-id="4581f-426">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-426">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-427">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-427">GET</span></span> | <span data-ttu-id="4581f-428">/api/holographic/simulation/playback/session/files</span><span class="sxs-lookup"><span data-stu-id="4581f-428">/api/holographic/simulation/playback/session/files</span></span>


**<span data-ttu-id="4581f-429">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-429">URI parameters</span></span>**

- <span data-ttu-id="4581f-430">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-430">None</span></span>

**<span data-ttu-id="4581f-431">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-431">Request headers</span></span>**

- <span data-ttu-id="4581f-432">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-432">None</span></span>

**<span data-ttu-id="4581f-433">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-433">Request body</span></span>**

- <span data-ttu-id="4581f-434">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-434">None</span></span>

**<span data-ttu-id="4581f-435">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-435">Response</span></span>**

- <span data-ttu-id="4581f-436">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-436">None</span></span>

**<span data-ttu-id="4581f-437">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-437">Status code</span></span>**

- <span data-ttu-id="4581f-438">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-438">Standard status codes.</span></span>

---
### <a name="get-the-current-playback-state-of-a-recording"></a><span data-ttu-id="4581f-439">レコーディングの現在の再生状態を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-439">Get the current playback state of a recording</span></span> 

**<span data-ttu-id="4581f-440">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-440">Request</span></span>**

<span data-ttu-id="4581f-441">次の要求形式を使用して、レコーディングの現在の再生状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-441">You can get the current playback state of a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-442">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-442">Method</span></span>      | <span data-ttu-id="4581f-443">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-443">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-444">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-444">GET</span></span> | <span data-ttu-id="4581f-445">/api/holographic/simulation/playback/session</span><span class="sxs-lookup"><span data-stu-id="4581f-445">/api/holographic/simulation/playback/session</span></span>


**<span data-ttu-id="4581f-446">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-446">URI parameters</span></span>**

<span data-ttu-id="4581f-447">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-447">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-448">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-448">URI parameter</span></span> | <span data-ttu-id="4581f-449">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-449">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-450">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-450">recording</span></span>   | <span data-ttu-id="4581f-451">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-451">(**required**) The name of the recording that you are interested in.</span></span>

**<span data-ttu-id="4581f-452">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-452">Request headers</span></span>**

- <span data-ttu-id="4581f-453">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-453">None</span></span>

**<span data-ttu-id="4581f-454">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-454">Request body</span></span>**

- <span data-ttu-id="4581f-455">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-455">None</span></span>

**<span data-ttu-id="4581f-456">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-456">Response</span></span>**

- <span data-ttu-id="4581f-457">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-457">None</span></span>

**<span data-ttu-id="4581f-458">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-458">Status code</span></span>**

- <span data-ttu-id="4581f-459">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-459">Standard status codes.</span></span>

---
### <a name="load-a-recording"></a><span data-ttu-id="4581f-460">レコーディングを読み込む</span><span class="sxs-lookup"><span data-stu-id="4581f-460">Load a recording</span></span>

**<span data-ttu-id="4581f-461">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-461">Request</span></span>**

<span data-ttu-id="4581f-462">次の要求形式を使用して、レコーディングを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="4581f-462">You can load a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-463">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-463">Method</span></span>      | <span data-ttu-id="4581f-464">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-464">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-465">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-465">POST</span></span> | <span data-ttu-id="4581f-466">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="4581f-466">/api/holographic/simulation/playback/session/file</span></span>


**<span data-ttu-id="4581f-467">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-467">URI parameters</span></span>**

<span data-ttu-id="4581f-468">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-468">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-469">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-469">URI parameter</span></span> | <span data-ttu-id="4581f-470">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-470">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-471">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-471">recording</span></span>   | <span data-ttu-id="4581f-472">(**必須**) 読み込むレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-472">(**required**) The name of the recording to load.</span></span>

**<span data-ttu-id="4581f-473">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-473">Request headers</span></span>**

- <span data-ttu-id="4581f-474">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-474">None</span></span>

**<span data-ttu-id="4581f-475">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-475">Request body</span></span>**

- <span data-ttu-id="4581f-476">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-476">None</span></span>

**<span data-ttu-id="4581f-477">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-477">Response</span></span>**

- <span data-ttu-id="4581f-478">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-478">None</span></span>

**<span data-ttu-id="4581f-479">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-479">Status code</span></span>**

- <span data-ttu-id="4581f-480">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-480">Standard status codes.</span></span>

---
### <a name="pause-a-recording"></a><span data-ttu-id="4581f-481">レコーディングを一時停止する</span><span class="sxs-lookup"><span data-stu-id="4581f-481">Pause a recording</span></span>

**<span data-ttu-id="4581f-482">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-482">Request</span></span>**

<span data-ttu-id="4581f-483">次の要求形式を使用して、レコーディングを一時停止できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-483">You can pause a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-484">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-484">Method</span></span>      | <span data-ttu-id="4581f-485">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-485">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-486">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-486">POST</span></span> | <span data-ttu-id="4581f-487">/api/holographic/simulation/playback/session/pause</span><span class="sxs-lookup"><span data-stu-id="4581f-487">/api/holographic/simulation/playback/session/pause</span></span>


**<span data-ttu-id="4581f-488">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-488">URI parameters</span></span>**

<span data-ttu-id="4581f-489">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-489">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-490">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-490">URI parameter</span></span> | <span data-ttu-id="4581f-491">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-491">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-492">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-492">recording</span></span>   | <span data-ttu-id="4581f-493">(**必須**) 一時停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-493">(**required**) The name of the recording to pause.</span></span>

**<span data-ttu-id="4581f-494">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-494">Request headers</span></span>**

- <span data-ttu-id="4581f-495">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-495">None</span></span>

**<span data-ttu-id="4581f-496">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-496">Request body</span></span>**

- <span data-ttu-id="4581f-497">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-497">None</span></span>

**<span data-ttu-id="4581f-498">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-498">Response</span></span>**

- <span data-ttu-id="4581f-499">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-499">None</span></span>

**<span data-ttu-id="4581f-500">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-500">Status code</span></span>**

- <span data-ttu-id="4581f-501">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-501">Standard status codes.</span></span>

---
### <a name="play-a-recording"></a><span data-ttu-id="4581f-502">レコーディングを再生する</span><span class="sxs-lookup"><span data-stu-id="4581f-502">Play a recording</span></span>

**<span data-ttu-id="4581f-503">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-503">Request</span></span>**

<span data-ttu-id="4581f-504">次の要求形式を使用して、レコーディングを再生できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-504">You can play a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-505">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-505">Method</span></span>      | <span data-ttu-id="4581f-506">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-506">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-507">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-507">POST</span></span> | <span data-ttu-id="4581f-508">/api/holographic/simulation/playback/session/play</span><span class="sxs-lookup"><span data-stu-id="4581f-508">/api/holographic/simulation/playback/session/play</span></span>


**<span data-ttu-id="4581f-509">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-509">URI parameters</span></span>**

<span data-ttu-id="4581f-510">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-510">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-511">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-511">URI parameter</span></span> | <span data-ttu-id="4581f-512">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-512">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-513">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-513">recording</span></span>   | <span data-ttu-id="4581f-514">(**必須**) 再生するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-514">(**required**) The name of the recording to play.</span></span>

**<span data-ttu-id="4581f-515">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-515">Request headers</span></span>**

- <span data-ttu-id="4581f-516">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-516">None</span></span>

**<span data-ttu-id="4581f-517">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-517">Request body</span></span>**

- <span data-ttu-id="4581f-518">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-518">None</span></span>

**<span data-ttu-id="4581f-519">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-519">Response</span></span>**

- <span data-ttu-id="4581f-520">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-520">None</span></span>

**<span data-ttu-id="4581f-521">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-521">Status code</span></span>**

- <span data-ttu-id="4581f-522">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-522">Standard status codes.</span></span>

---
### <a name="stop-a-recording"></a><span data-ttu-id="4581f-523">レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="4581f-523">Stop a recording</span></span>

**<span data-ttu-id="4581f-524">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-524">Request</span></span>**

<span data-ttu-id="4581f-525">次の要求形式を使用して、レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-525">You can stop a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-526">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-526">Method</span></span>      | <span data-ttu-id="4581f-527">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-527">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-528">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-528">POST</span></span> | <span data-ttu-id="4581f-529">/api/holographic/simulation/playback/session/stop</span><span class="sxs-lookup"><span data-stu-id="4581f-529">/api/holographic/simulation/playback/session/stop</span></span>


**<span data-ttu-id="4581f-530">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-530">URI parameters</span></span>**

<span data-ttu-id="4581f-531">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-531">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-532">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-532">URI parameter</span></span> | <span data-ttu-id="4581f-533">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-533">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-534">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-534">recording</span></span>   | <span data-ttu-id="4581f-535">(**必須**) 停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-535">(**required**) The name of the recording to stop.</span></span>

**<span data-ttu-id="4581f-536">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-536">Request headers</span></span>**

- <span data-ttu-id="4581f-537">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-537">None</span></span>

**<span data-ttu-id="4581f-538">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-538">Request body</span></span>**

- <span data-ttu-id="4581f-539">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-539">None</span></span>

**<span data-ttu-id="4581f-540">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-540">Response</span></span>**

- <span data-ttu-id="4581f-541">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-541">None</span></span>

**<span data-ttu-id="4581f-542">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-542">Status code</span></span>**

- <span data-ttu-id="4581f-543">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-543">Standard status codes.</span></span>

---
### <a name="unload-a-recording"></a><span data-ttu-id="4581f-544">レコーディングをアンロードする</span><span class="sxs-lookup"><span data-stu-id="4581f-544">Unload a recording</span></span>

**<span data-ttu-id="4581f-545">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-545">Request</span></span>**

<span data-ttu-id="4581f-546">次の要求形式を使用して、レコーディングをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="4581f-546">You can unload a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-547">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-547">Method</span></span>      | <span data-ttu-id="4581f-548">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-548">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-549">DELETE</span><span class="sxs-lookup"><span data-stu-id="4581f-549">DELETE</span></span> | <span data-ttu-id="4581f-550">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="4581f-550">/api/holographic/simulation/playback/session/file</span></span>


**<span data-ttu-id="4581f-551">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-551">URI parameters</span></span>**

<span data-ttu-id="4581f-552">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-552">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-553">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-553">URI parameter</span></span> | <span data-ttu-id="4581f-554">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-554">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-555">recording</span><span class="sxs-lookup"><span data-stu-id="4581f-555">recording</span></span>   | <span data-ttu-id="4581f-556">(**必須**) アンロードするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-556">(**required**) The name of the recording to unload.</span></span>

**<span data-ttu-id="4581f-557">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-557">Request headers</span></span>**

- <span data-ttu-id="4581f-558">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-558">None</span></span>

**<span data-ttu-id="4581f-559">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-559">Request body</span></span>**

- <span data-ttu-id="4581f-560">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-560">None</span></span>

**<span data-ttu-id="4581f-561">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-561">Response</span></span>**

- <span data-ttu-id="4581f-562">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-562">None</span></span>

**<span data-ttu-id="4581f-563">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-563">Status code</span></span>**

- <span data-ttu-id="4581f-564">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-564">Standard status codes.</span></span>

---
### <a name="upload-a-recording"></a><span data-ttu-id="4581f-565">レコーディングをアップロードする</span><span class="sxs-lookup"><span data-stu-id="4581f-565">Upload a recording</span></span>

**<span data-ttu-id="4581f-566">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-566">Request</span></span>**

<span data-ttu-id="4581f-567">次の要求形式を使用して、レコーディングをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="4581f-567">You can upload a recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-568">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-568">Method</span></span>      | <span data-ttu-id="4581f-569">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-569">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-570">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-570">POST</span></span> | <span data-ttu-id="4581f-571">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="4581f-571">/api/holographic/simulation/playback/file</span></span>


**<span data-ttu-id="4581f-572">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-572">URI parameters</span></span>**

- <span data-ttu-id="4581f-573">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-573">None</span></span>

**<span data-ttu-id="4581f-574">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-574">Request headers</span></span>**

- <span data-ttu-id="4581f-575">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-575">None</span></span>

**<span data-ttu-id="4581f-576">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-576">Request body</span></span>**

- <span data-ttu-id="4581f-577">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-577">None</span></span>

**<span data-ttu-id="4581f-578">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-578">Response</span></span>**

- <span data-ttu-id="4581f-579">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-579">None</span></span>

**<span data-ttu-id="4581f-580">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-580">Status code</span></span>**

- <span data-ttu-id="4581f-581">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-581">Standard status codes.</span></span>

---
## HSimulation recording
---
### <a name="get-the-recording-state"></a><span data-ttu-id="4581f-582">レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-582">Get the recording state</span></span>

**<span data-ttu-id="4581f-583">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-583">Request</span></span>**

<span data-ttu-id="4581f-584">次の要求形式を使用して、現在のレコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-584">You can get the current recording state by using the following request format.</span></span>
 
<span data-ttu-id="4581f-585">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-585">Method</span></span>      | <span data-ttu-id="4581f-586">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-586">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-587">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-587">GET</span></span> | <span data-ttu-id="4581f-588">/api/holographic/simulation/recording/status</span><span class="sxs-lookup"><span data-stu-id="4581f-588">/api/holographic/simulation/recording/status</span></span>


**<span data-ttu-id="4581f-589">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-589">URI parameters</span></span>**

- <span data-ttu-id="4581f-590">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-590">None</span></span>

**<span data-ttu-id="4581f-591">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-591">Request headers</span></span>**

- <span data-ttu-id="4581f-592">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-592">None</span></span>

**<span data-ttu-id="4581f-593">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-593">Request body</span></span>**

- <span data-ttu-id="4581f-594">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-594">None</span></span>

**<span data-ttu-id="4581f-595">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-595">Response</span></span>**

- <span data-ttu-id="4581f-596">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-596">None</span></span>

**<span data-ttu-id="4581f-597">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-597">Status code</span></span>**

- <span data-ttu-id="4581f-598">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-598">Standard status codes.</span></span>

---
### <a name="start-a-recording"></a><span data-ttu-id="4581f-599">レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-599">Start a recording</span></span>

**<span data-ttu-id="4581f-600">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-600">Request</span></span>**

<span data-ttu-id="4581f-601">次の要求形式を使用して、レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-601">You can start a recording by using the following request format.</span></span> <span data-ttu-id="4581f-602">アクティブにできるレコーディングは一度に 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="4581f-602">There can only be one active recording at a time.</span></span> 
 
<span data-ttu-id="4581f-603">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-603">Method</span></span>      | <span data-ttu-id="4581f-604">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-604">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-605">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-605">POST</span></span> | <span data-ttu-id="4581f-606">/api/holographic/simulation/recording/start</span><span class="sxs-lookup"><span data-stu-id="4581f-606">/api/holographic/simulation/recording/start</span></span>


**<span data-ttu-id="4581f-607">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-607">URI parameters</span></span>**

<span data-ttu-id="4581f-608">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-608">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-609">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-609">URI parameter</span></span> | <span data-ttu-id="4581f-610">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-610">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-611">head</span><span class="sxs-lookup"><span data-stu-id="4581f-611">head</span></span>   | <span data-ttu-id="4581f-612">(**下記参照**) システムで頭部のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-612">(**see below**) Set this value to 1 to indicate the system should record head data.</span></span>
<span data-ttu-id="4581f-613">hands</span><span class="sxs-lookup"><span data-stu-id="4581f-613">hands</span></span>   | <span data-ttu-id="4581f-614">(**下記参照**) システムで手のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-614">(**see below**) Set this value to 1 to indicate the system should record hands data.</span></span>
<span data-ttu-id="4581f-615">spatialMapping</span><span class="sxs-lookup"><span data-stu-id="4581f-615">spatialMapping</span></span>   | <span data-ttu-id="4581f-616">(**下記参照**) システムで空間マッピング データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-616">(**see below**) Set this value to 1 to indicate the system should record spatial mapping data.</span></span>
<span data-ttu-id="4581f-617">environment</span><span class="sxs-lookup"><span data-stu-id="4581f-617">environment</span></span>   | <span data-ttu-id="4581f-618">(**下記参照**) システムで環境データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-618">(**see below**) Set this value to 1 to indicate the system should record environment data.</span></span>
<span data-ttu-id="4581f-619">name</span><span class="sxs-lookup"><span data-stu-id="4581f-619">name</span></span>   | <span data-ttu-id="4581f-620">(**必須**) レコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-620">(**required**) The name of the recording.</span></span>
<span data-ttu-id="4581f-621">singleSpatialMappingFrame</span><span class="sxs-lookup"><span data-stu-id="4581f-621">singleSpatialMappingFrame</span></span>   | <span data-ttu-id="4581f-622">(**省略可能**) 単一の空間マッピング フレームのみを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-622">(**optional**) Set this value to 1 to indicate that only a single sptial mapping frame should be recorded.</span></span>

<span data-ttu-id="4581f-623">これらのパラメーターについては、*head*、*hands*、*spatialMapping*、*environment* のいずれか 1 つだけを 1 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-623">For these parameters, exactly one of the following parameters must be set to 1: *head*, *hands*, *spatialMapping*, or *environment*.</span></span>

**<span data-ttu-id="4581f-624">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-624">Request headers</span></span>**

- <span data-ttu-id="4581f-625">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-625">None</span></span>

**<span data-ttu-id="4581f-626">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-626">Request body</span></span>**

- <span data-ttu-id="4581f-627">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-627">None</span></span>

**<span data-ttu-id="4581f-628">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-628">Response</span></span>**

- <span data-ttu-id="4581f-629">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-629">None</span></span>

**<span data-ttu-id="4581f-630">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-630">Status code</span></span>**

- <span data-ttu-id="4581f-631">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-631">Standard status codes.</span></span>

---
### <a name="stop-the-current-recording"></a><span data-ttu-id="4581f-632">現在のレコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="4581f-632">Stop the current recording</span></span>

**<span data-ttu-id="4581f-633">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-633">Request</span></span>**

<span data-ttu-id="4581f-634">次の要求形式を使用して、現在のレコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-634">You can stop the current recording by using the following request format.</span></span> <span data-ttu-id="4581f-635">レコーディングはファイルとして返されます。</span><span class="sxs-lookup"><span data-stu-id="4581f-635">The recording will be returned as a file.</span></span>
 
<span data-ttu-id="4581f-636">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-636">Method</span></span>      | <span data-ttu-id="4581f-637">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-637">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-638">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-638">POST</span></span> | <span data-ttu-id="4581f-639">/api/holographic/simulation/recording/stop</span><span class="sxs-lookup"><span data-stu-id="4581f-639">/api/holographic/simulation/recording/stop</span></span>


**<span data-ttu-id="4581f-640">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-640">URI parameters</span></span>**

- <span data-ttu-id="4581f-641">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-641">None</span></span>

**<span data-ttu-id="4581f-642">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-642">Request headers</span></span>**

- <span data-ttu-id="4581f-643">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-643">None</span></span>

**<span data-ttu-id="4581f-644">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-644">Request body</span></span>**

- <span data-ttu-id="4581f-645">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-645">None</span></span>

**<span data-ttu-id="4581f-646">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-646">Response</span></span>**

- <span data-ttu-id="4581f-647">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-647">None</span></span>

**<span data-ttu-id="4581f-648">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-648">Status code</span></span>**

- <span data-ttu-id="4581f-649">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-649">Standard status codes.</span></span>

---
## Mixed reality capture
---
### <a name="delete-a-mixed-reality-capture-mrc-recording-from-the-device"></a><span data-ttu-id="4581f-650">デバイスから Mixed Reality キャプチャ (MRC) レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="4581f-650">Delete a mixed reality capture (MRC) recording from the device</span></span>

**<span data-ttu-id="4581f-651">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-651">Request</span></span>**

<span data-ttu-id="4581f-652">次の要求形式を使用して、MRC レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-652">You can delete an MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-653">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-653">Method</span></span>      | <span data-ttu-id="4581f-654">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-654">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-655">DELETE</span><span class="sxs-lookup"><span data-stu-id="4581f-655">DELETE</span></span> | <span data-ttu-id="4581f-656">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="4581f-656">/api/holographic/mrc/file</span></span>


**<span data-ttu-id="4581f-657">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-657">URI parameters</span></span>**

<span data-ttu-id="4581f-658">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-658">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-659">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-659">URI parameter</span></span> | <span data-ttu-id="4581f-660">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-660">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-661">filename</span><span class="sxs-lookup"><span data-stu-id="4581f-661">filename</span></span>   | <span data-ttu-id="4581f-662">(**必須**) 削除するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-662">(**required**) The name of the video file to delete.</span></span> <span data-ttu-id="4581f-663">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-663">The name should be hex64 encoded.</span></span>

**<span data-ttu-id="4581f-664">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-664">Request headers</span></span>**

- <span data-ttu-id="4581f-665">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-665">None</span></span>

**<span data-ttu-id="4581f-666">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-666">Request body</span></span>**

- <span data-ttu-id="4581f-667">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-667">None</span></span>

**<span data-ttu-id="4581f-668">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-668">Response</span></span>**

- <span data-ttu-id="4581f-669">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-669">None</span></span>

**<span data-ttu-id="4581f-670">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-670">Status code</span></span>**

- <span data-ttu-id="4581f-671">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-671">Standard status codes.</span></span>

---
### <a name="download-a-mixed-reality-capture-mrc-file"></a><span data-ttu-id="4581f-672">Mixed Reality キャプチャ (MRC) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="4581f-672">Download a mixed reality capture (MRC) file</span></span>

**<span data-ttu-id="4581f-673">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-673">Request</span></span>**

<span data-ttu-id="4581f-674">次の要求形式を使用して、デバイスから MRC ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="4581f-674">You can download an MRC file from the device by using the following request format.</span></span>
 
<span data-ttu-id="4581f-675">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-675">Method</span></span>      | <span data-ttu-id="4581f-676">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-676">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-677">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-677">GET</span></span> | <span data-ttu-id="4581f-678">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="4581f-678">/api/holographic/mrc/file</span></span>


**<span data-ttu-id="4581f-679">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-679">URI parameters</span></span>**

<span data-ttu-id="4581f-680">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-680">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-681">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-681">URI parameter</span></span> | <span data-ttu-id="4581f-682">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-682">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-683">filename</span><span class="sxs-lookup"><span data-stu-id="4581f-683">filename</span></span>   | <span data-ttu-id="4581f-684">(**必須**) 取得するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="4581f-684">(**required**) The name of the video file you want to get.</span></span> <span data-ttu-id="4581f-685">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-685">The name should be hex64 encoded.</span></span>
<span data-ttu-id="4581f-686">op</span><span class="sxs-lookup"><span data-stu-id="4581f-686">op</span></span>   | <span data-ttu-id="4581f-687">(**省略可能**) ストリームをダウンロードする場合は、この値を **stream** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4581f-687">(**optional**) Set this value to **stream** if you want to download a stream.</span></span>

**<span data-ttu-id="4581f-688">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-688">Request headers</span></span>**

- <span data-ttu-id="4581f-689">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-689">None</span></span>

**<span data-ttu-id="4581f-690">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-690">Request body</span></span>**

- <span data-ttu-id="4581f-691">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-691">None</span></span>

**<span data-ttu-id="4581f-692">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-692">Response</span></span>**

- <span data-ttu-id="4581f-693">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-693">None</span></span>

**<span data-ttu-id="4581f-694">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-694">Status code</span></span>**

- <span data-ttu-id="4581f-695">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-695">Standard status codes.</span></span>

---
### <a name="get-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="4581f-696">Mixed Reality キャプチャ (MRC) の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-696">Get the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="4581f-697">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-697">Request</span></span>**

<span data-ttu-id="4581f-698">次の要求形式を使用して、MRC の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-698">You can get the MRC settings by using the following request format.</span></span>
 
<span data-ttu-id="4581f-699">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-699">Method</span></span>      | <span data-ttu-id="4581f-700">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-700">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-701">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-701">GET</span></span> | <span data-ttu-id="4581f-702">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="4581f-702">/api/holographic/mrc/settings</span></span>


**<span data-ttu-id="4581f-703">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-703">URI parameters</span></span>**

- <span data-ttu-id="4581f-704">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-704">None</span></span>

**<span data-ttu-id="4581f-705">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-705">Request headers</span></span>**

- <span data-ttu-id="4581f-706">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-706">None</span></span>

**<span data-ttu-id="4581f-707">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-707">Request body</span></span>**

- <span data-ttu-id="4581f-708">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-708">None</span></span>

**<span data-ttu-id="4581f-709">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-709">Response</span></span>**

- <span data-ttu-id="4581f-710">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-710">None</span></span>

**<span data-ttu-id="4581f-711">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-711">Status code</span></span>**

- <span data-ttu-id="4581f-712">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-712">Standard status codes.</span></span>

---
### <a name="get-the-status-of-the-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="4581f-713">Mixed Reality キャプチャ (MRC) レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-713">Get the status of the mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="4581f-714">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-714">Request</span></span>**

<span data-ttu-id="4581f-715">次の要求形式を使用して、MRC レコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-715">You can get the MRC recording status by using the following request format.</span></span> <span data-ttu-id="4581f-716">返される可能性のある値は、**running** と **stopped** です。</span><span class="sxs-lookup"><span data-stu-id="4581f-716">The possible values include **running** and **stopped**.</span></span>
 
<span data-ttu-id="4581f-717">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-717">Method</span></span>      | <span data-ttu-id="4581f-718">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-718">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-719">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-719">GET</span></span> | <span data-ttu-id="4581f-720">/api/holographic/mrc/status</span><span class="sxs-lookup"><span data-stu-id="4581f-720">/api/holographic/mrc/status</span></span>


**<span data-ttu-id="4581f-721">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-721">URI parameters</span></span>**

- <span data-ttu-id="4581f-722">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-722">None</span></span>

**<span data-ttu-id="4581f-723">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-723">Request headers</span></span>**

- <span data-ttu-id="4581f-724">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-724">None</span></span>

**<span data-ttu-id="4581f-725">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-725">Request body</span></span>**

- <span data-ttu-id="4581f-726">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-726">None</span></span>

**<span data-ttu-id="4581f-727">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-727">Response</span></span>**

- <span data-ttu-id="4581f-728">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-728">None</span></span>

**<span data-ttu-id="4581f-729">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-729">Status code</span></span>**

- <span data-ttu-id="4581f-730">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-730">Standard status codes.</span></span>

---
### <a name="get-the-list-of-mixed-reality-capture-mrc-files"></a><span data-ttu-id="4581f-731">Mixed Reality キャプチャ (MRC) ファイルのリストを取得する</span><span class="sxs-lookup"><span data-stu-id="4581f-731">Get the list of mixed reality capture (MRC) files</span></span>

**<span data-ttu-id="4581f-732">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-732">Request</span></span>**

<span data-ttu-id="4581f-733">次の要求形式を使用して、デバイスに保存されている MRC ファイルを取得できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-733">You can get the MRC files stored on the device by using the following request format.</span></span>
 
<span data-ttu-id="4581f-734">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-734">Method</span></span>      | <span data-ttu-id="4581f-735">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-735">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-736">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-736">GET</span></span> | <span data-ttu-id="4581f-737">/api/holographic/mrc/files</span><span class="sxs-lookup"><span data-stu-id="4581f-737">/api/holographic/mrc/files</span></span>


**<span data-ttu-id="4581f-738">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-738">URI parameters</span></span>**

- <span data-ttu-id="4581f-739">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-739">None</span></span>

**<span data-ttu-id="4581f-740">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-740">Request headers</span></span>**

- <span data-ttu-id="4581f-741">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-741">None</span></span>

**<span data-ttu-id="4581f-742">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-742">Request body</span></span>**

- <span data-ttu-id="4581f-743">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-743">None</span></span>

**<span data-ttu-id="4581f-744">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-744">Response</span></span>**

- <span data-ttu-id="4581f-745">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-745">None</span></span>

**<span data-ttu-id="4581f-746">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-746">Status code</span></span>**

- <span data-ttu-id="4581f-747">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-747">Standard status codes.</span></span>

---
### <a name="set-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="4581f-748">Mixed Reality キャプチャ (MRC) の設定を行う</span><span class="sxs-lookup"><span data-stu-id="4581f-748">Set the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="4581f-749">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-749">Request</span></span>**

<span data-ttu-id="4581f-750">次の要求形式を使用して、MRC の設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="4581f-750">You can set the MRC settings by using the following request format.</span></span>
 
<span data-ttu-id="4581f-751">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-751">Method</span></span>      | <span data-ttu-id="4581f-752">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-752">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-753">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-753">POST</span></span> | <span data-ttu-id="4581f-754">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="4581f-754">/api/holographic/mrc/settings</span></span>


**<span data-ttu-id="4581f-755">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-755">URI parameters</span></span>**

- <span data-ttu-id="4581f-756">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-756">None</span></span>

**<span data-ttu-id="4581f-757">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-757">Request headers</span></span>**

- <span data-ttu-id="4581f-758">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-758">None</span></span>

**<span data-ttu-id="4581f-759">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-759">Request body</span></span>**

- <span data-ttu-id="4581f-760">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-760">None</span></span>

**<span data-ttu-id="4581f-761">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-761">Response</span></span>**

- <span data-ttu-id="4581f-762">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-762">None</span></span>

**<span data-ttu-id="4581f-763">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-763">Status code</span></span>**

- <span data-ttu-id="4581f-764">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-764">Standard status codes.</span></span>

---
### <a name="starts-a-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="4581f-765">Mixed Reality キャプチャ (MRC) レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-765">Starts a mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="4581f-766">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-766">Request</span></span>**

<span data-ttu-id="4581f-767">次の要求形式を使用して、MRC レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-767">You can start an MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-768">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-768">Method</span></span>      | <span data-ttu-id="4581f-769">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-769">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-770">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-770">POST</span></span> | <span data-ttu-id="4581f-771">/api/holographic/mrc/video/control/start</span><span class="sxs-lookup"><span data-stu-id="4581f-771">/api/holographic/mrc/video/control/start</span></span>


**<span data-ttu-id="4581f-772">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-772">URI parameters</span></span>**

- <span data-ttu-id="4581f-773">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-773">None</span></span>

**<span data-ttu-id="4581f-774">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-774">Request headers</span></span>**

- <span data-ttu-id="4581f-775">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-775">None</span></span>

**<span data-ttu-id="4581f-776">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-776">Request body</span></span>**

- <span data-ttu-id="4581f-777">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-777">None</span></span>

**<span data-ttu-id="4581f-778">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-778">Response</span></span>**

- <span data-ttu-id="4581f-779">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-779">None</span></span>

**<span data-ttu-id="4581f-780">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-780">Status code</span></span>**

- <span data-ttu-id="4581f-781">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-781">Standard status codes.</span></span>

---
### <a name="stop-the-current-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="4581f-782">現在の Mixed Reality キャプチャ (MRC) レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="4581f-782">Stop the current mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="4581f-783">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-783">Request</span></span>**

<span data-ttu-id="4581f-784">次の要求形式を使用して、現在の MRC レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-784">You can stop the current MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="4581f-785">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-785">Method</span></span>      | <span data-ttu-id="4581f-786">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-786">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-787">POST</span><span class="sxs-lookup"><span data-stu-id="4581f-787">POST</span></span> | <span data-ttu-id="4581f-788">/api/holographic/mrc/video/control/stop</span><span class="sxs-lookup"><span data-stu-id="4581f-788">/api/holographic/mrc/video/control/stop</span></span>


**<span data-ttu-id="4581f-789">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-789">URI parameters</span></span>**

- <span data-ttu-id="4581f-790">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-790">None</span></span>

**<span data-ttu-id="4581f-791">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-791">Request headers</span></span>**

- <span data-ttu-id="4581f-792">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-792">None</span></span>

**<span data-ttu-id="4581f-793">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-793">Request body</span></span>**

- <span data-ttu-id="4581f-794">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-794">None</span></span>

**<span data-ttu-id="4581f-795">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-795">Response</span></span>**

- <span data-ttu-id="4581f-796">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-796">None</span></span>

**<span data-ttu-id="4581f-797">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-797">Status code</span></span>**

- <span data-ttu-id="4581f-798">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-798">Standard status codes.</span></span>

---
### <a name="take-a-mixed-reality-capture-mrc-photo"></a><span data-ttu-id="4581f-799">Mixed Reality キャプチャ (MRC) の写真を撮る</span><span class="sxs-lookup"><span data-stu-id="4581f-799">Take a mixed reality capture (MRC) photo</span></span>

**<span data-ttu-id="4581f-800">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-800">Request</span></span>**

<span data-ttu-id="4581f-801">次の要求形式を使用して、MRC の写真を撮ることができます。</span><span class="sxs-lookup"><span data-stu-id="4581f-801">You can take an MRC photo by using the following request format.</span></span> <span data-ttu-id="4581f-802">写真は JPEG 形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="4581f-802">The photo is returned in JPEG format.</span></span>
 
<span data-ttu-id="4581f-803">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-803">Method</span></span>      | <span data-ttu-id="4581f-804">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-804">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-805">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-805">GET</span></span> | <span data-ttu-id="4581f-806">/api/holographic/mrc/photo</span><span class="sxs-lookup"><span data-stu-id="4581f-806">/api/holographic/mrc/photo</span></span>


**<span data-ttu-id="4581f-807">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-807">URI parameters</span></span>**

- <span data-ttu-id="4581f-808">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-808">None</span></span>

**<span data-ttu-id="4581f-809">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-809">Request headers</span></span>**

- <span data-ttu-id="4581f-810">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-810">None</span></span>

**<span data-ttu-id="4581f-811">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-811">Request body</span></span>**

- <span data-ttu-id="4581f-812">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-812">None</span></span>

**<span data-ttu-id="4581f-813">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-813">Response</span></span>**

- <span data-ttu-id="4581f-814">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-814">None</span></span>

**<span data-ttu-id="4581f-815">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-815">Status code</span></span>**

- <span data-ttu-id="4581f-816">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-816">Standard status codes.</span></span>

---
## Mixed reality streaming
---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="4581f-817">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-817">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="4581f-818">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-818">Request</span></span>**

<span data-ttu-id="4581f-819">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-819">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="4581f-820">この API では既定の品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="4581f-820">This API uses the default quality.</span></span>
 
<span data-ttu-id="4581f-821">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-821">Method</span></span>      | <span data-ttu-id="4581f-822">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-822">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-823">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-823">GET</span></span> | <span data-ttu-id="4581f-824">/api/holographic/stream/live.mp4</span><span class="sxs-lookup"><span data-stu-id="4581f-824">/api/holographic/stream/live.mp4</span></span>


**<span data-ttu-id="4581f-825">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-825">URI parameters</span></span>**

<span data-ttu-id="4581f-826">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-826">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-827">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-827">URI parameter</span></span> | <span data-ttu-id="4581f-828">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-828">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-829">pv</span><span class="sxs-lookup"><span data-stu-id="4581f-829">pv</span></span>   | <span data-ttu-id="4581f-830">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-830">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="4581f-831">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-831">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-832">holo</span><span class="sxs-lookup"><span data-stu-id="4581f-832">holo</span></span>   | <span data-ttu-id="4581f-833">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-833">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="4581f-834">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-834">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-835">mic</span><span class="sxs-lookup"><span data-stu-id="4581f-835">mic</span></span>   | <span data-ttu-id="4581f-836">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-836">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="4581f-837">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-837">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-838">loopback</span><span class="sxs-lookup"><span data-stu-id="4581f-838">loopback</span></span>   | <span data-ttu-id="4581f-839">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-839">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="4581f-840">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-840">Should be **true** or **false**.</span></span>

**<span data-ttu-id="4581f-841">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-841">Request headers</span></span>**

- <span data-ttu-id="4581f-842">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-842">None</span></span>

**<span data-ttu-id="4581f-843">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-843">Request body</span></span>**

- <span data-ttu-id="4581f-844">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-844">None</span></span>

**<span data-ttu-id="4581f-845">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-845">Response</span></span>**

- <span data-ttu-id="4581f-846">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-846">None</span></span>

**<span data-ttu-id="4581f-847">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-847">Status code</span></span>**

- <span data-ttu-id="4581f-848">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-848">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="4581f-849">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-849">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="4581f-850">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-850">Request</span></span>**

<span data-ttu-id="4581f-851">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-851">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="4581f-852">この API では高品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="4581f-852">This API uses the high quality.</span></span>
 
<span data-ttu-id="4581f-853">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-853">Method</span></span>      | <span data-ttu-id="4581f-854">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-854">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-855">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-855">GET</span></span> | <span data-ttu-id="4581f-856">/api/holographic/stream/live_high.mp4</span><span class="sxs-lookup"><span data-stu-id="4581f-856">/api/holographic/stream/live_high.mp4</span></span>


**<span data-ttu-id="4581f-857">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-857">URI parameters</span></span>**

<span data-ttu-id="4581f-858">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-858">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-859">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-859">URI parameter</span></span> | <span data-ttu-id="4581f-860">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-860">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-861">pv</span><span class="sxs-lookup"><span data-stu-id="4581f-861">pv</span></span>   | <span data-ttu-id="4581f-862">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-862">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="4581f-863">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-863">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-864">holo</span><span class="sxs-lookup"><span data-stu-id="4581f-864">holo</span></span>   | <span data-ttu-id="4581f-865">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-865">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="4581f-866">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-866">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-867">mic</span><span class="sxs-lookup"><span data-stu-id="4581f-867">mic</span></span>   | <span data-ttu-id="4581f-868">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-868">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="4581f-869">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-869">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-870">loopback</span><span class="sxs-lookup"><span data-stu-id="4581f-870">loopback</span></span>   | <span data-ttu-id="4581f-871">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-871">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="4581f-872">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-872">Should be **true** or **false**.</span></span>

**<span data-ttu-id="4581f-873">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-873">Request headers</span></span>**

- <span data-ttu-id="4581f-874">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-874">None</span></span>

**<span data-ttu-id="4581f-875">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-875">Request body</span></span>**

- <span data-ttu-id="4581f-876">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-876">None</span></span>

**<span data-ttu-id="4581f-877">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-877">Response</span></span>**

- <span data-ttu-id="4581f-878">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-878">None</span></span>

**<span data-ttu-id="4581f-879">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-879">Status code</span></span>**

- <span data-ttu-id="4581f-880">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-880">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="4581f-881">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-881">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="4581f-882">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-882">Request</span></span>**

<span data-ttu-id="4581f-883">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-883">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="4581f-884">この API では低品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="4581f-884">This API uses the low quality.</span></span>
 
<span data-ttu-id="4581f-885">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-885">Method</span></span>      | <span data-ttu-id="4581f-886">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-886">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-887">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-887">GET</span></span> | <span data-ttu-id="4581f-888">/api/holographic/stream/live_low.mp4</span><span class="sxs-lookup"><span data-stu-id="4581f-888">/api/holographic/stream/live_low.mp4</span></span>


**<span data-ttu-id="4581f-889">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-889">URI parameters</span></span>**

<span data-ttu-id="4581f-890">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-890">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-891">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-891">URI parameter</span></span> | <span data-ttu-id="4581f-892">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-892">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-893">pv</span><span class="sxs-lookup"><span data-stu-id="4581f-893">pv</span></span>   | <span data-ttu-id="4581f-894">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-894">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="4581f-895">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-895">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-896">holo</span><span class="sxs-lookup"><span data-stu-id="4581f-896">holo</span></span>   | <span data-ttu-id="4581f-897">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-897">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="4581f-898">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-898">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-899">mic</span><span class="sxs-lookup"><span data-stu-id="4581f-899">mic</span></span>   | <span data-ttu-id="4581f-900">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-900">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="4581f-901">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-901">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-902">loopback</span><span class="sxs-lookup"><span data-stu-id="4581f-902">loopback</span></span>   | <span data-ttu-id="4581f-903">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-903">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="4581f-904">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-904">Should be **true** or **false**.</span></span>

**<span data-ttu-id="4581f-905">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-905">Request headers</span></span>**

- <span data-ttu-id="4581f-906">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-906">None</span></span>

**<span data-ttu-id="4581f-907">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-907">Request body</span></span>**

- <span data-ttu-id="4581f-908">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-908">None</span></span>

**<span data-ttu-id="4581f-909">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-909">Response</span></span>**

- <span data-ttu-id="4581f-910">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-910">None</span></span>

**<span data-ttu-id="4581f-911">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-911">Status code</span></span>**

- <span data-ttu-id="4581f-912">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-912">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="4581f-913">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="4581f-913">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="4581f-914">要求</span><span class="sxs-lookup"><span data-stu-id="4581f-914">Request</span></span>**

<span data-ttu-id="4581f-915">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-915">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="4581f-916">この API では中品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="4581f-916">This API uses the medium quality.</span></span>
 
<span data-ttu-id="4581f-917">メソッド</span><span class="sxs-lookup"><span data-stu-id="4581f-917">Method</span></span>      | <span data-ttu-id="4581f-918">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4581f-918">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4581f-919">GET</span><span class="sxs-lookup"><span data-stu-id="4581f-919">GET</span></span> | <span data-ttu-id="4581f-920">/api/holographic/stream/live_med.mp4</span><span class="sxs-lookup"><span data-stu-id="4581f-920">/api/holographic/stream/live_med.mp4</span></span>


**<span data-ttu-id="4581f-921">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-921">URI parameters</span></span>**

<span data-ttu-id="4581f-922">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="4581f-922">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="4581f-923">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4581f-923">URI parameter</span></span> | <span data-ttu-id="4581f-924">説明</span><span class="sxs-lookup"><span data-stu-id="4581f-924">Description</span></span>
:---          | :---
<span data-ttu-id="4581f-925">pv</span><span class="sxs-lookup"><span data-stu-id="4581f-925">pv</span></span>   | <span data-ttu-id="4581f-926">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-926">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="4581f-927">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-927">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-928">holo</span><span class="sxs-lookup"><span data-stu-id="4581f-928">holo</span></span>   | <span data-ttu-id="4581f-929">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-929">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="4581f-930">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-930">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-931">mic</span><span class="sxs-lookup"><span data-stu-id="4581f-931">mic</span></span>   | <span data-ttu-id="4581f-932">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-932">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="4581f-933">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-933">Should be **true** or **false**.</span></span>
<span data-ttu-id="4581f-934">loopback</span><span class="sxs-lookup"><span data-stu-id="4581f-934">loopback</span></span>   | <span data-ttu-id="4581f-935">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="4581f-935">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="4581f-936">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4581f-936">Should be **true** or **false**.</span></span>

**<span data-ttu-id="4581f-937">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4581f-937">Request headers</span></span>**

- <span data-ttu-id="4581f-938">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-938">None</span></span>

**<span data-ttu-id="4581f-939">要求本文</span><span class="sxs-lookup"><span data-stu-id="4581f-939">Request body</span></span>**

- <span data-ttu-id="4581f-940">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-940">None</span></span>

**<span data-ttu-id="4581f-941">応答</span><span class="sxs-lookup"><span data-stu-id="4581f-941">Response</span></span>**

- <span data-ttu-id="4581f-942">なし</span><span class="sxs-lookup"><span data-stu-id="4581f-942">None</span></span>

**<span data-ttu-id="4581f-943">状態コード</span><span class="sxs-lookup"><span data-stu-id="4581f-943">Status code</span></span>**

- <span data-ttu-id="4581f-944">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="4581f-944">Standard status codes.</span></span>
