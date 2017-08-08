---
author: mcleblanc
ms.assetid: 41ac0142-4d86-4bb3-b580-36d0d6956091
title: "HoloLens 用 Device Portal API リファレンス"
description: "HoloLens 用の Windows Device Portal REST API について説明します。これらの API を使うと、プログラムからデータにアクセスしてデバイスを制御できます。"
ms.openlocfilehash: 638ebca167b2ca56f00a83aab13b15c57b2dca2a
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: HT
ms.contentlocale: ja-JP
---
# <a name="device-portal-api-reference-for-hololens"></a><span data-ttu-id="0be03-103">HoloLens 用 Device Portal API リファレンス</span><span class="sxs-lookup"><span data-stu-id="0be03-103">Device Portal API reference for HoloLens</span></span>

<span data-ttu-id="0be03-104">Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-104">Everything in the Windows Device Portal is built on top of REST API's that you can use to access the data and control your device programmatically.</span></span>

## <a name="holographic-os"></a><span data-ttu-id="0be03-105">ホログラフィック OS</span><span class="sxs-lookup"><span data-stu-id="0be03-105">Holographic OS</span></span>
---
### <a name="get-https-requirements-for-the-device-portal"></a><span data-ttu-id="0be03-106">Device Portal の HTTPS 要件を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-106">Get HTTPS requirements for the Device Portal</span></span>

**<span data-ttu-id="0be03-107">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-107">Request</span></span>**

<span data-ttu-id="0be03-108">次の要求型式を使用して、Device Portal の HTTPS 要件を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-108">You can get the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
<span data-ttu-id="0be03-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-109">Method</span></span>      | <span data-ttu-id="0be03-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-111">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-111">GET</span></span> | <span data-ttu-id="0be03-112">/api/holographic/os/webmanagement/settings/https</span><span class="sxs-lookup"><span data-stu-id="0be03-112">/api/holographic/os/webmanagement/settings/https</span></span>


**<span data-ttu-id="0be03-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-113">URI parameters</span></span>**

- <span data-ttu-id="0be03-114">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-114">None</span></span>

**<span data-ttu-id="0be03-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-115">Request headers</span></span>**

- <span data-ttu-id="0be03-116">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-116">None</span></span>

**<span data-ttu-id="0be03-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-117">Request body</span></span>**

- <span data-ttu-id="0be03-118">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-118">None</span></span>

**<span data-ttu-id="0be03-119">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-119">Response</span></span>**

- <span data-ttu-id="0be03-120">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-120">None</span></span>

**<span data-ttu-id="0be03-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-121">Status code</span></span>**

- <span data-ttu-id="0be03-122">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-122">Standard status codes.</span></span>

---
### <a name="get-the-stored-interpupillary-distance-ipd"></a><span data-ttu-id="0be03-123">保存されている瞳孔間距離 (IPD) を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-123">Get the stored interpupillary distance (IPD)</span></span>

**<span data-ttu-id="0be03-124">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-124">Request</span></span>**

<span data-ttu-id="0be03-125">次の要求型式を使用して、保存されている IPD の値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-125">You can get the stored IPD value by using the following request format.</span></span> <span data-ttu-id="0be03-126">値はミリメートル単位で返されます。</span><span class="sxs-lookup"><span data-stu-id="0be03-126">The value is returned in millimeters.</span></span>
 
<span data-ttu-id="0be03-127">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-127">Method</span></span>      | <span data-ttu-id="0be03-128">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-128">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-129">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-129">GET</span></span> | <span data-ttu-id="0be03-130">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="0be03-130">/api/holographic/os/settings/ipd</span></span>


**<span data-ttu-id="0be03-131">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-131">URI parameters</span></span>**

- <span data-ttu-id="0be03-132">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-132">None</span></span>

**<span data-ttu-id="0be03-133">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-133">Request headers</span></span>**

- <span data-ttu-id="0be03-134">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-134">None</span></span>

**<span data-ttu-id="0be03-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-135">Request body</span></span>**

- <span data-ttu-id="0be03-136">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-136">None</span></span>

**<span data-ttu-id="0be03-137">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-137">Response</span></span>**

- <span data-ttu-id="0be03-138">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-138">None</span></span>

**<span data-ttu-id="0be03-139">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-139">Status code</span></span>**

- <span data-ttu-id="0be03-140">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-140">Standard status codes.</span></span>

---
### <a name="get-a-list-of-hololens-specific-etw-providers"></a><span data-ttu-id="0be03-141">HoloLens 固有の ETW プロバイダーの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-141">Get a list of HoloLens specific ETW providers</span></span>

**<span data-ttu-id="0be03-142">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-142">Request</span></span>**

<span data-ttu-id="0be03-143">次の要求型式を使用して、システムには登録されていない HoloLens 固有の ETW プロバイダーの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-143">You can get a list of HoloLens specific ETW providers that are not registered with the system by using the following request format.</span></span>
 
<span data-ttu-id="0be03-144">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-144">Method</span></span>      | <span data-ttu-id="0be03-145">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-145">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-146">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-146">GET</span></span> | <span data-ttu-id="0be03-147">/api/holographic/os/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="0be03-147">/api/holographic/os/etw/customproviders</span></span>


**<span data-ttu-id="0be03-148">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-148">URI parameters</span></span>**

- <span data-ttu-id="0be03-149">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-149">None</span></span>

**<span data-ttu-id="0be03-150">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-150">Request headers</span></span>**

- <span data-ttu-id="0be03-151">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-151">None</span></span>

**<span data-ttu-id="0be03-152">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-152">Request body</span></span>**

- <span data-ttu-id="0be03-153">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-153">None</span></span>

**<span data-ttu-id="0be03-154">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-154">Response</span></span>**

- <span data-ttu-id="0be03-155">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-155">None</span></span>

**<span data-ttu-id="0be03-156">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-156">Status code</span></span>**

- <span data-ttu-id="0be03-157">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-157">Standard status codes.</span></span>

---
### <a name="return-the-state-for-all-active-services"></a><span data-ttu-id="0be03-158">アクティブなすべてのサービスの状態を返す</span><span class="sxs-lookup"><span data-stu-id="0be03-158">Return the state for all active services</span></span>

**<span data-ttu-id="0be03-159">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-159">Request</span></span>**

<span data-ttu-id="0be03-160">次の要求形式を使用して、現在実行されているすべてのサービスの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-160">You can get the state of all services that are currently running by using the following request format.</span></span>
 
<span data-ttu-id="0be03-161">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-161">Method</span></span>      | <span data-ttu-id="0be03-162">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-162">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-163">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-163">GET</span></span> | <span data-ttu-id="0be03-164">/api/holographic/os/services</span><span class="sxs-lookup"><span data-stu-id="0be03-164">/api/holographic/os/services</span></span>


**<span data-ttu-id="0be03-165">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-165">URI parameters</span></span>**

- <span data-ttu-id="0be03-166">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-166">None</span></span>

**<span data-ttu-id="0be03-167">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-167">Request headers</span></span>**

- <span data-ttu-id="0be03-168">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-168">None</span></span>

**<span data-ttu-id="0be03-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-169">Request body</span></span>**

- <span data-ttu-id="0be03-170">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-170">None</span></span>

**<span data-ttu-id="0be03-171">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-171">Response</span></span>**

- <span data-ttu-id="0be03-172">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-172">None</span></span>

**<span data-ttu-id="0be03-173">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-173">Status code</span></span>**

- <span data-ttu-id="0be03-174">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-174">Standard status codes.</span></span>

---
### <a name="set-the-https-requirement-for-the-device-portal"></a><span data-ttu-id="0be03-175">Device Portal の HTTPS 要件を設定する</span><span class="sxs-lookup"><span data-stu-id="0be03-175">Set the HTTPS requirement for the Device Portal.</span></span>

**<span data-ttu-id="0be03-176">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-176">Request</span></span>**

<span data-ttu-id="0be03-177">次の要求形式を使用して、Device Portal の HTTPS 要件を設定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-177">You can set the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
<span data-ttu-id="0be03-178">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-178">Method</span></span>      | <span data-ttu-id="0be03-179">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-179">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-180">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-180">POST</span></span> | <span data-ttu-id="0be03-181">/api/holographic/management/settings/https</span><span class="sxs-lookup"><span data-stu-id="0be03-181">/api/holographic/management/settings/https</span></span>


**<span data-ttu-id="0be03-182">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-182">URI parameters</span></span>**

<span data-ttu-id="0be03-183">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-183">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-184">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-184">URI parameter</span></span> | <span data-ttu-id="0be03-185">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-185">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-186">required</span><span class="sxs-lookup"><span data-stu-id="0be03-186">required</span></span>   | <span data-ttu-id="0be03-187">(**必須**) Device Portal で HTTPS を必要とするかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-187">(**required**) Determines whether or not HTTPS is required for the Device Portal.</span></span> <span data-ttu-id="0be03-188">指定できる値は、**yes**、**no**、**default** です。</span><span class="sxs-lookup"><span data-stu-id="0be03-188">Possible values are **yes**, **no**, and **default**.</span></span>

**<span data-ttu-id="0be03-189">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-189">Request headers</span></span>**

- <span data-ttu-id="0be03-190">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-190">None</span></span>

**<span data-ttu-id="0be03-191">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-191">Request body</span></span>**

- <span data-ttu-id="0be03-192">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-192">None</span></span>

**<span data-ttu-id="0be03-193">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-193">Response</span></span>**

- <span data-ttu-id="0be03-194">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-194">None</span></span>

**<span data-ttu-id="0be03-195">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-195">Status code</span></span>**

- <span data-ttu-id="0be03-196">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-196">Standard status codes.</span></span>

---
### <a name="set-the-interpupillary-distance-ipd"></a><span data-ttu-id="0be03-197">瞳孔間距離 (IPD) を設定する</span><span class="sxs-lookup"><span data-stu-id="0be03-197">Set the interpupillary distance (IPD)</span></span>

**<span data-ttu-id="0be03-198">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-198">Request</span></span>**

<span data-ttu-id="0be03-199">次の要求形式を使用して、保存されている IPD を設定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-199">You can set the stored IPD by using the following request format.</span></span>
 
<span data-ttu-id="0be03-200">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-200">Method</span></span>      | <span data-ttu-id="0be03-201">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-201">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-202">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-202">POST</span></span> | <span data-ttu-id="0be03-203">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="0be03-203">/api/holographic/os/settings/ipd</span></span>


**<span data-ttu-id="0be03-204">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-204">URI parameters</span></span>**

<span data-ttu-id="0be03-205">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-205">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-206">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-206">URI parameter</span></span> | <span data-ttu-id="0be03-207">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-207">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-208">ipd</span><span class="sxs-lookup"><span data-stu-id="0be03-208">ipd</span></span>   | <span data-ttu-id="0be03-209">(**必須**) 保存する新しい IPD 値。</span><span class="sxs-lookup"><span data-stu-id="0be03-209">(**required**) The new IPD value to be stored.</span></span> <span data-ttu-id="0be03-210">この値はミリメートル単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-210">This value should be in millimeters.</span></span>

**<span data-ttu-id="0be03-211">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-211">Request headers</span></span>**

- <span data-ttu-id="0be03-212">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-212">None</span></span>

**<span data-ttu-id="0be03-213">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-213">Request body</span></span>**

- <span data-ttu-id="0be03-214">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-214">None</span></span>

**<span data-ttu-id="0be03-215">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-215">Response</span></span>**

- <span data-ttu-id="0be03-216">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-216">None</span></span>

**<span data-ttu-id="0be03-217">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-217">Status code</span></span>**

- <span data-ttu-id="0be03-218">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-218">Standard status codes.</span></span>

---
## Holographic perception
---
### <a name="accept-websocket-upgrades-and-run-a-mirage-client-that-sends-updates"></a><span data-ttu-id="0be03-219">WebSocket のアップグレードを受け入れ、ミラージュ クライアントを実行する</span><span class="sxs-lookup"><span data-stu-id="0be03-219">Accept websocket upgrades and run a mirage client that sends updates</span></span>

**<span data-ttu-id="0be03-220">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-220">Request</span></span>**

<span data-ttu-id="0be03-221">次の要求型式を使用して、WebSocket のアップグレードを受け入れ、30fps で更新を送信するミラージュ クライアントを実行できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-221">You can accept websocket upgrades and run a mirage client that sends updates at 30 fps by using the following request format.</span></span>
 
<span data-ttu-id="0be03-222">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-222">Method</span></span>      | <span data-ttu-id="0be03-223">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-223">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-224">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="0be03-224">GET/WebSocket</span></span> | <span data-ttu-id="0be03-225">/api/holographic/perception/client</span><span class="sxs-lookup"><span data-stu-id="0be03-225">/api/holographic/perception/client</span></span>


**<span data-ttu-id="0be03-226">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-226">URI parameters</span></span>**

<span data-ttu-id="0be03-227">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-227">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-228">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-228">URI parameter</span></span> | <span data-ttu-id="0be03-229">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-229">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-230">clientmode</span><span class="sxs-lookup"><span data-stu-id="0be03-230">clientmode</span></span>   | <span data-ttu-id="0be03-231">(**必須**) 追跡モードを決定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-231">(**required**) Determines the tracking mode.</span></span> <span data-ttu-id="0be03-232">値を **active** に設定すると、パッシブに確立できない場合は視覚追跡モードが強制されます。</span><span class="sxs-lookup"><span data-stu-id="0be03-232">A value of **active** forces visual tracking mode when it can't be established passively.</span></span>

**<span data-ttu-id="0be03-233">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-233">Request headers</span></span>**

- <span data-ttu-id="0be03-234">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-234">None</span></span>

**<span data-ttu-id="0be03-235">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-235">Request body</span></span>**

- <span data-ttu-id="0be03-236">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-236">None</span></span>

**<span data-ttu-id="0be03-237">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-237">Response</span></span>**

- <span data-ttu-id="0be03-238">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-238">None</span></span>

**<span data-ttu-id="0be03-239">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-239">Status code</span></span>**

- <span data-ttu-id="0be03-240">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-240">Standard status codes.</span></span>

---
## Holographic thermal
---
### <a name="get-the-thermal-stage-of-the-device"></a><span data-ttu-id="0be03-241">デバイスの温度ステージを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-241">Get the thermal stage of the device</span></span>

**<span data-ttu-id="0be03-242">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-242">Request</span></span>**

<span data-ttu-id="0be03-243">次の要求形式を使用して、デバイスの温度ステージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-243">You can get the thermal stage of the device by using the following request format.</span></span>
 
<span data-ttu-id="0be03-244">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-244">Method</span></span>      | <span data-ttu-id="0be03-245">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-245">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-246">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-246">GET</span></span> | <span data-ttu-id="0be03-247">/api/holographic/</span><span class="sxs-lookup"><span data-stu-id="0be03-247">/api/holographic/</span></span>

**<span data-ttu-id="0be03-248">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-248">URI parameters</span></span>**

- <span data-ttu-id="0be03-249">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-249">None</span></span>

**<span data-ttu-id="0be03-250">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-250">Request headers</span></span>**

- <span data-ttu-id="0be03-251">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-251">None</span></span>

**<span data-ttu-id="0be03-252">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-252">Request body</span></span>**

- <span data-ttu-id="0be03-253">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-253">None</span></span>

**<span data-ttu-id="0be03-254">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-254">Response</span></span>**

<span data-ttu-id="0be03-255">返される可能性のある値を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-255">The possible values are indicated by the following table.</span></span>

<span data-ttu-id="0be03-256">値</span><span class="sxs-lookup"><span data-stu-id="0be03-256">Value</span></span> | <span data-ttu-id="0be03-257">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-257">Description</span></span>
--- | ---
<span data-ttu-id="0be03-258">1</span><span class="sxs-lookup"><span data-stu-id="0be03-258">1</span></span> | <span data-ttu-id="0be03-259">正常</span><span class="sxs-lookup"><span data-stu-id="0be03-259">Normal</span></span>
<span data-ttu-id="0be03-260">2</span><span class="sxs-lookup"><span data-stu-id="0be03-260">2</span></span> | <span data-ttu-id="0be03-261">中温</span><span class="sxs-lookup"><span data-stu-id="0be03-261">Warm</span></span>
<span data-ttu-id="0be03-262">3</span><span class="sxs-lookup"><span data-stu-id="0be03-262">3</span></span> | <span data-ttu-id="0be03-263">重大</span><span class="sxs-lookup"><span data-stu-id="0be03-263">Critical</span></span>

**<span data-ttu-id="0be03-264">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-264">Status code</span></span>**

- <span data-ttu-id="0be03-265">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-265">Standard status codes.</span></span>

---
## HSimulation control
---
### <a name="create-a-control-stream-or-post-data-to-a-created-stream"></a><span data-ttu-id="0be03-266">制御ストリームを作成する、または作成されたストリームにデータをポストする</span><span class="sxs-lookup"><span data-stu-id="0be03-266">Create a control stream or post data to a created stream</span></span>

**<span data-ttu-id="0be03-267">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-267">Request</span></span>**

<span data-ttu-id="0be03-268">次の要求形式を使用して、制御ストリームを作成したり、作成されたストリームにデータをポストしたりできます。</span><span class="sxs-lookup"><span data-stu-id="0be03-268">You can create a control stream or post data to a created stream by using the following request format.</span></span> <span data-ttu-id="0be03-269">ポストされるデータの種類は **application/octet-stream** と想定されます。</span><span class="sxs-lookup"><span data-stu-id="0be03-269">The posted data is expected to be of type **application/octet-stream**.</span></span>
 
<span data-ttu-id="0be03-270">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-270">Method</span></span>      | <span data-ttu-id="0be03-271">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-271">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-272">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-272">POST</span></span> | <span data-ttu-id="0be03-273">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="0be03-273">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="0be03-274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-274">URI parameters</span></span>**

<span data-ttu-id="0be03-275">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-275">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-276">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-276">URI parameter</span></span> | <span data-ttu-id="0be03-277">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-277">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-278">priority</span><span class="sxs-lookup"><span data-stu-id="0be03-278">priority</span></span>   | <span data-ttu-id="0be03-279">(**制御ストリームを作成する場合は必須**) ストリームの優先度を示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-279">(**required if creating a control stream**) Indicates the priority of the stream.</span></span>
<span data-ttu-id="0be03-280">streamid</span><span class="sxs-lookup"><span data-stu-id="0be03-280">streamid</span></span>   | <span data-ttu-id="0be03-281">(**作成されたストリームにポストする場合は必須**) ポスト先のストリームの識別子。</span><span class="sxs-lookup"><span data-stu-id="0be03-281">(**required if posting to a created stream**) The identifier for the stream to post to.</span></span>

**<span data-ttu-id="0be03-282">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-282">Request headers</span></span>**

- <span data-ttu-id="0be03-283">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-283">None</span></span>

**<span data-ttu-id="0be03-284">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-284">Request body</span></span>**

- <span data-ttu-id="0be03-285">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-285">None</span></span>

**<span data-ttu-id="0be03-286">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-286">Response</span></span>**

- <span data-ttu-id="0be03-287">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-287">None</span></span>

**<span data-ttu-id="0be03-288">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-288">Status code</span></span>**

- <span data-ttu-id="0be03-289">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-289">Standard status codes.</span></span>

---
### <a name="delete-a-control-stream"></a><span data-ttu-id="0be03-290">制御ストリームを削除する</span><span class="sxs-lookup"><span data-stu-id="0be03-290">Delete a control stream</span></span>

**<span data-ttu-id="0be03-291">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-291">Request</span></span>**

<span data-ttu-id="0be03-292">次の要求形式を使用して、制御ストリームを削除できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-292">You can delete a control stream by using the following request format.</span></span>
 
<span data-ttu-id="0be03-293">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-293">Method</span></span>      | <span data-ttu-id="0be03-294">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-294">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-295">DELETE</span><span class="sxs-lookup"><span data-stu-id="0be03-295">DELETE</span></span> | <span data-ttu-id="0be03-296">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="0be03-296">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="0be03-297">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-297">URI parameters</span></span>**

- <span data-ttu-id="0be03-298">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-298">None</span></span>

**<span data-ttu-id="0be03-299">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-299">Request headers</span></span>**

- <span data-ttu-id="0be03-300">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-300">None</span></span>

**<span data-ttu-id="0be03-301">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-301">Request body</span></span>**

- <span data-ttu-id="0be03-302">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-302">None</span></span>

**<span data-ttu-id="0be03-303">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-303">Response</span></span>**

- <span data-ttu-id="0be03-304">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-304">None</span></span>

**<span data-ttu-id="0be03-305">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-305">Status code</span></span>**

- <span data-ttu-id="0be03-306">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-306">Standard status codes.</span></span>

---
### <a name="get-a-control-stream"></a><span data-ttu-id="0be03-307">制御ストリームを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-307">Get a control stream</span></span>

**<span data-ttu-id="0be03-308">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-308">Request</span></span>**

<span data-ttu-id="0be03-309">次の要求形式を使用して、制御ストリームの Web ソケット接続を開くことができます。</span><span class="sxs-lookup"><span data-stu-id="0be03-309">You can open a web socket connection for a control stream by using the following request format.</span></span>
 
<span data-ttu-id="0be03-310">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-310">Method</span></span>      | <span data-ttu-id="0be03-311">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-311">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-312">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="0be03-312">GET/WebSocket</span></span> | <span data-ttu-id="0be03-313">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="0be03-313">/api/holographic/simulation/control/stream</span></span>


**<span data-ttu-id="0be03-314">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-314">URI parameters</span></span>**

- <span data-ttu-id="0be03-315">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-315">None</span></span>

**<span data-ttu-id="0be03-316">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-316">Request headers</span></span>**

- <span data-ttu-id="0be03-317">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-317">None</span></span>

**<span data-ttu-id="0be03-318">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-318">Request body</span></span>**

- <span data-ttu-id="0be03-319">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-319">None</span></span>

**<span data-ttu-id="0be03-320">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-320">Response</span></span>**

- <span data-ttu-id="0be03-321">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-321">None</span></span>

**<span data-ttu-id="0be03-322">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-322">Status code</span></span>**

- <span data-ttu-id="0be03-323">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-323">Standard status codes.</span></span>

---
### <a name="get-the-simluation-mode"></a><span data-ttu-id="0be03-324">シミュレーション モードを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-324">Get the simluation mode</span></span>

**<span data-ttu-id="0be03-325">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-325">Request</span></span>**

<span data-ttu-id="0be03-326">次の要求形式を使用して、シミュレーション モードを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-326">You can get the simluation mode by using the following request format.</span></span>
 
<span data-ttu-id="0be03-327">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-327">Method</span></span>      | <span data-ttu-id="0be03-328">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-328">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-329">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-329">GET</span></span> | <span data-ttu-id="0be03-330">/api/holographic/simulation/control/mode</span><span class="sxs-lookup"><span data-stu-id="0be03-330">/api/holographic/simulation/control/mode</span></span>


**<span data-ttu-id="0be03-331">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-331">URI parameters</span></span>**

- <span data-ttu-id="0be03-332">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-332">None</span></span>

**<span data-ttu-id="0be03-333">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-333">Request headers</span></span>**

- <span data-ttu-id="0be03-334">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-334">None</span></span>

**<span data-ttu-id="0be03-335">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-335">Request body</span></span>**

- <span data-ttu-id="0be03-336">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-336">None</span></span>

**<span data-ttu-id="0be03-337">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-337">Response</span></span>**

- <span data-ttu-id="0be03-338">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-338">None</span></span>

**<span data-ttu-id="0be03-339">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-339">Status code</span></span>**

- <span data-ttu-id="0be03-340">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-340">Standard status codes.</span></span>

---
### <a name="set-the-simluation-mode"></a><span data-ttu-id="0be03-341">シミュレーション モードを設定する</span><span class="sxs-lookup"><span data-stu-id="0be03-341">Set the simluation mode</span></span>

**<span data-ttu-id="0be03-342">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-342">Request</span></span>**

<span data-ttu-id="0be03-343">次の要求型式を使用して、シミュレーション モードを設定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-343">You can set the simulation mode by using the following request format.</span></span>
 
<span data-ttu-id="0be03-344">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-344">Method</span></span>      | <span data-ttu-id="0be03-345">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-345">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-346">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-346">POST</span></span> | <span data-ttu-id="0be03-347">/api/holographic/simluation/control/mode</span><span class="sxs-lookup"><span data-stu-id="0be03-347">/api/holographic/simluation/control/mode</span></span>


**<span data-ttu-id="0be03-348">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-348">URI parameters</span></span>**

<span data-ttu-id="0be03-349">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-349">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-350">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-350">URI parameter</span></span> | <span data-ttu-id="0be03-351">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-351">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-352">mode</span><span class="sxs-lookup"><span data-stu-id="0be03-352">mode</span></span>   | <span data-ttu-id="0be03-353">(**必須**) シミュレーション モードを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-353">(**required**) Indicates the simulation mode.</span></span> <span data-ttu-id="0be03-354">指定できる値は、**default**、**simulation**、**remote**、**legacy** です。</span><span class="sxs-lookup"><span data-stu-id="0be03-354">Possible values include **default**, **simulation**, **remote**, and **legacy**.</span></span>

**<span data-ttu-id="0be03-355">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-355">Request headers</span></span>**

- <span data-ttu-id="0be03-356">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-356">None</span></span>

**<span data-ttu-id="0be03-357">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-357">Request body</span></span>**

- <span data-ttu-id="0be03-358">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-358">None</span></span>

**<span data-ttu-id="0be03-359">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-359">Response</span></span>**

- <span data-ttu-id="0be03-360">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-360">None</span></span>

**<span data-ttu-id="0be03-361">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-361">Status code</span></span>**

- <span data-ttu-id="0be03-362">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-362">Standard status codes.</span></span>

---
## HSimulation playback
---
### <a name="delete-a-recording"></a><span data-ttu-id="0be03-363">レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="0be03-363">Delete a recording</span></span>

**<span data-ttu-id="0be03-364">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-364">Request</span></span>**

<span data-ttu-id="0be03-365">次の要求型式を使用して、レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-365">You can delete a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-366">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-366">Method</span></span>      | <span data-ttu-id="0be03-367">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-367">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-368">DELETE</span><span class="sxs-lookup"><span data-stu-id="0be03-368">DELETE</span></span> | <span data-ttu-id="0be03-369">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="0be03-369">/api/holographic/simulation/playback/file</span></span>


**<span data-ttu-id="0be03-370">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-370">URI parameters</span></span>**

<span data-ttu-id="0be03-371">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-371">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-372">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-372">URI parameter</span></span> | <span data-ttu-id="0be03-373">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-373">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-374">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-374">recording</span></span>   | <span data-ttu-id="0be03-375">(**必須**) 削除するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-375">(**required**) The name of the recording to delete.</span></span>

**<span data-ttu-id="0be03-376">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-376">Request headers</span></span>**

- <span data-ttu-id="0be03-377">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-377">None</span></span>

**<span data-ttu-id="0be03-378">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-378">Request body</span></span>**

- <span data-ttu-id="0be03-379">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-379">None</span></span>

**<span data-ttu-id="0be03-380">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-380">Response</span></span>**

- <span data-ttu-id="0be03-381">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-381">None</span></span>

**<span data-ttu-id="0be03-382">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-382">Status code</span></span>**

- <span data-ttu-id="0be03-383">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-383">Standard status codes.</span></span>

---
### <a name="get-all-recordings"></a><span data-ttu-id="0be03-384">すべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-384">Get all recordings</span></span>

**<span data-ttu-id="0be03-385">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-385">Request</span></span>**

<span data-ttu-id="0be03-386">次の要求形式を使用して、利用可能なすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-386">You can get all the available recordings by using the following request format.</span></span>
 
<span data-ttu-id="0be03-387">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-387">Method</span></span>      | <span data-ttu-id="0be03-388">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-388">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-389">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-389">GET</span></span> | <span data-ttu-id="0be03-390">/api/holographic/simulation/playback/files</span><span class="sxs-lookup"><span data-stu-id="0be03-390">/api/holographic/simulation/playback/files</span></span>


**<span data-ttu-id="0be03-391">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-391">URI parameters</span></span>**

- <span data-ttu-id="0be03-392">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-392">None</span></span>

**<span data-ttu-id="0be03-393">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-393">Request headers</span></span>**

- <span data-ttu-id="0be03-394">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-394">None</span></span>

**<span data-ttu-id="0be03-395">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-395">Request body</span></span>**

- <span data-ttu-id="0be03-396">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-396">None</span></span>

**<span data-ttu-id="0be03-397">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-397">Response</span></span>**

- <span data-ttu-id="0be03-398">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-398">None</span></span>

**<span data-ttu-id="0be03-399">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-399">Status code</span></span>**

- <span data-ttu-id="0be03-400">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-400">Standard status codes.</span></span>

---
### <a name="get-the-types-of-data-in-a-loaded-recording"></a><span data-ttu-id="0be03-401">読み込まれたレコーディング内のデータの種類を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-401">Get the types of data in a loaded recording</span></span>

**<span data-ttu-id="0be03-402">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-402">Request</span></span>**

<span data-ttu-id="0be03-403">次の要求形式を使用して、読み込まれたレコーディング内のデータの種類を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-403">You can get the types of data in a loaded recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-404">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-404">Method</span></span>      | <span data-ttu-id="0be03-405">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-405">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-406">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-406">GET</span></span> | <span data-ttu-id="0be03-407">/api/holographic/simulation/playback/session/types</span><span class="sxs-lookup"><span data-stu-id="0be03-407">/api/holographic/simulation/playback/session/types</span></span>


**<span data-ttu-id="0be03-408">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-408">URI parameters</span></span>**

<span data-ttu-id="0be03-409">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-409">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-410">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-410">URI parameter</span></span> | <span data-ttu-id="0be03-411">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-411">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-412">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-412">recording</span></span>   | <span data-ttu-id="0be03-413">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-413">(**required**) The name of the recording you are interested in.</span></span>

**<span data-ttu-id="0be03-414">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-414">Request headers</span></span>**

- <span data-ttu-id="0be03-415">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-415">None</span></span>

**<span data-ttu-id="0be03-416">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-416">Request body</span></span>**

- <span data-ttu-id="0be03-417">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-417">None</span></span>

**<span data-ttu-id="0be03-418">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-418">Response</span></span>**

- <span data-ttu-id="0be03-419">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-419">None</span></span>

**<span data-ttu-id="0be03-420">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-420">Status code</span></span>**

- <span data-ttu-id="0be03-421">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-421">Standard status codes.</span></span>

---
### <a name="get-all-the-loaded-recordings"></a><span data-ttu-id="0be03-422">読み込まれたすべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-422">Get all the loaded recordings</span></span>

**<span data-ttu-id="0be03-423">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-423">Request</span></span>**

<span data-ttu-id="0be03-424">次の要求形式を使用して、読み込まれたすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-424">You can get all the loaded recordings by using the following request format.</span></span>
 
<span data-ttu-id="0be03-425">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-425">Method</span></span>      | <span data-ttu-id="0be03-426">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-426">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-427">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-427">GET</span></span> | <span data-ttu-id="0be03-428">/api/holographic/simulation/playback/session/files</span><span class="sxs-lookup"><span data-stu-id="0be03-428">/api/holographic/simulation/playback/session/files</span></span>


**<span data-ttu-id="0be03-429">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-429">URI parameters</span></span>**

- <span data-ttu-id="0be03-430">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-430">None</span></span>

**<span data-ttu-id="0be03-431">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-431">Request headers</span></span>**

- <span data-ttu-id="0be03-432">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-432">None</span></span>

**<span data-ttu-id="0be03-433">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-433">Request body</span></span>**

- <span data-ttu-id="0be03-434">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-434">None</span></span>

**<span data-ttu-id="0be03-435">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-435">Response</span></span>**

- <span data-ttu-id="0be03-436">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-436">None</span></span>

**<span data-ttu-id="0be03-437">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-437">Status code</span></span>**

- <span data-ttu-id="0be03-438">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-438">Standard status codes.</span></span>

---
### <a name="get-the-current-playback-state-of-a-recording"></a><span data-ttu-id="0be03-439">レコーディングの現在の再生状態を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-439">Get the current playback state of a recording</span></span> 

**<span data-ttu-id="0be03-440">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-440">Request</span></span>**

<span data-ttu-id="0be03-441">次の要求形式を使用して、レコーディングの現在の再生状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-441">You can get the current playback state of a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-442">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-442">Method</span></span>      | <span data-ttu-id="0be03-443">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-443">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-444">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-444">GET</span></span> | <span data-ttu-id="0be03-445">/api/holographic/simulation/playback/session</span><span class="sxs-lookup"><span data-stu-id="0be03-445">/api/holographic/simulation/playback/session</span></span>


**<span data-ttu-id="0be03-446">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-446">URI parameters</span></span>**

<span data-ttu-id="0be03-447">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-447">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-448">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-448">URI parameter</span></span> | <span data-ttu-id="0be03-449">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-449">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-450">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-450">recording</span></span>   | <span data-ttu-id="0be03-451">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-451">(**required**) The name of the recording that you are interested in.</span></span>

**<span data-ttu-id="0be03-452">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-452">Request headers</span></span>**

- <span data-ttu-id="0be03-453">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-453">None</span></span>

**<span data-ttu-id="0be03-454">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-454">Request body</span></span>**

- <span data-ttu-id="0be03-455">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-455">None</span></span>

**<span data-ttu-id="0be03-456">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-456">Response</span></span>**

- <span data-ttu-id="0be03-457">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-457">None</span></span>

**<span data-ttu-id="0be03-458">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-458">Status code</span></span>**

- <span data-ttu-id="0be03-459">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-459">Standard status codes.</span></span>

---
### <a name="load-a-recording"></a><span data-ttu-id="0be03-460">レコーディングを読み込む</span><span class="sxs-lookup"><span data-stu-id="0be03-460">Load a recording</span></span>

**<span data-ttu-id="0be03-461">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-461">Request</span></span>**

<span data-ttu-id="0be03-462">次の要求形式を使用して、レコーディングを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0be03-462">You can load a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-463">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-463">Method</span></span>      | <span data-ttu-id="0be03-464">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-464">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-465">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-465">POST</span></span> | <span data-ttu-id="0be03-466">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="0be03-466">/api/holographic/simulation/playback/session/file</span></span>


**<span data-ttu-id="0be03-467">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-467">URI parameters</span></span>**

<span data-ttu-id="0be03-468">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-468">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-469">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-469">URI parameter</span></span> | <span data-ttu-id="0be03-470">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-470">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-471">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-471">recording</span></span>   | <span data-ttu-id="0be03-472">(**必須**) 読み込むレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-472">(**required**) The name of the recording to load.</span></span>

**<span data-ttu-id="0be03-473">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-473">Request headers</span></span>**

- <span data-ttu-id="0be03-474">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-474">None</span></span>

**<span data-ttu-id="0be03-475">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-475">Request body</span></span>**

- <span data-ttu-id="0be03-476">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-476">None</span></span>

**<span data-ttu-id="0be03-477">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-477">Response</span></span>**

- <span data-ttu-id="0be03-478">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-478">None</span></span>

**<span data-ttu-id="0be03-479">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-479">Status code</span></span>**

- <span data-ttu-id="0be03-480">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-480">Standard status codes.</span></span>

---
### <a name="pause-a-recording"></a><span data-ttu-id="0be03-481">レコーディングを一時停止する</span><span class="sxs-lookup"><span data-stu-id="0be03-481">Pause a recording</span></span>

**<span data-ttu-id="0be03-482">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-482">Request</span></span>**

<span data-ttu-id="0be03-483">次の要求形式を使用して、レコーディングを一時停止できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-483">You can pause a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-484">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-484">Method</span></span>      | <span data-ttu-id="0be03-485">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-485">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-486">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-486">POST</span></span> | <span data-ttu-id="0be03-487">/api/holographic/simulation/playback/session/pause</span><span class="sxs-lookup"><span data-stu-id="0be03-487">/api/holographic/simulation/playback/session/pause</span></span>


**<span data-ttu-id="0be03-488">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-488">URI parameters</span></span>**

<span data-ttu-id="0be03-489">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-489">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-490">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-490">URI parameter</span></span> | <span data-ttu-id="0be03-491">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-491">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-492">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-492">recording</span></span>   | <span data-ttu-id="0be03-493">(**必須**) 一時停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-493">(**required**) The name of the recording to pause.</span></span>

**<span data-ttu-id="0be03-494">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-494">Request headers</span></span>**

- <span data-ttu-id="0be03-495">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-495">None</span></span>

**<span data-ttu-id="0be03-496">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-496">Request body</span></span>**

- <span data-ttu-id="0be03-497">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-497">None</span></span>

**<span data-ttu-id="0be03-498">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-498">Response</span></span>**

- <span data-ttu-id="0be03-499">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-499">None</span></span>

**<span data-ttu-id="0be03-500">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-500">Status code</span></span>**

- <span data-ttu-id="0be03-501">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-501">Standard status codes.</span></span>

---
### <a name="play-a-recording"></a><span data-ttu-id="0be03-502">レコーディングを再生する</span><span class="sxs-lookup"><span data-stu-id="0be03-502">Play a recording</span></span>

**<span data-ttu-id="0be03-503">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-503">Request</span></span>**

<span data-ttu-id="0be03-504">次の要求形式を使用して、レコーディングを再生できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-504">You can play a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-505">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-505">Method</span></span>      | <span data-ttu-id="0be03-506">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-506">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-507">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-507">POST</span></span> | <span data-ttu-id="0be03-508">/api/holographic/simulation/playback/session/play</span><span class="sxs-lookup"><span data-stu-id="0be03-508">/api/holographic/simulation/playback/session/play</span></span>


**<span data-ttu-id="0be03-509">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-509">URI parameters</span></span>**

<span data-ttu-id="0be03-510">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-510">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-511">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-511">URI parameter</span></span> | <span data-ttu-id="0be03-512">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-512">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-513">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-513">recording</span></span>   | <span data-ttu-id="0be03-514">(**必須**) 再生するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-514">(**required**) The name of the recording to play.</span></span>

**<span data-ttu-id="0be03-515">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-515">Request headers</span></span>**

- <span data-ttu-id="0be03-516">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-516">None</span></span>

**<span data-ttu-id="0be03-517">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-517">Request body</span></span>**

- <span data-ttu-id="0be03-518">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-518">None</span></span>

**<span data-ttu-id="0be03-519">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-519">Response</span></span>**

- <span data-ttu-id="0be03-520">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-520">None</span></span>

**<span data-ttu-id="0be03-521">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-521">Status code</span></span>**

- <span data-ttu-id="0be03-522">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-522">Standard status codes.</span></span>

---
### <a name="stop-a-recording"></a><span data-ttu-id="0be03-523">レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="0be03-523">Stop a recording</span></span>

**<span data-ttu-id="0be03-524">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-524">Request</span></span>**

<span data-ttu-id="0be03-525">次の要求形式を使用して、レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-525">You can stop a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-526">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-526">Method</span></span>      | <span data-ttu-id="0be03-527">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-527">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-528">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-528">POST</span></span> | <span data-ttu-id="0be03-529">/api/holographic/simulation/playback/session/stop</span><span class="sxs-lookup"><span data-stu-id="0be03-529">/api/holographic/simulation/playback/session/stop</span></span>


**<span data-ttu-id="0be03-530">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-530">URI parameters</span></span>**

<span data-ttu-id="0be03-531">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-531">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-532">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-532">URI parameter</span></span> | <span data-ttu-id="0be03-533">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-533">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-534">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-534">recording</span></span>   | <span data-ttu-id="0be03-535">(**必須**) 停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-535">(**required**) The name of the recording to stop.</span></span>

**<span data-ttu-id="0be03-536">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-536">Request headers</span></span>**

- <span data-ttu-id="0be03-537">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-537">None</span></span>

**<span data-ttu-id="0be03-538">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-538">Request body</span></span>**

- <span data-ttu-id="0be03-539">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-539">None</span></span>

**<span data-ttu-id="0be03-540">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-540">Response</span></span>**

- <span data-ttu-id="0be03-541">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-541">None</span></span>

**<span data-ttu-id="0be03-542">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-542">Status code</span></span>**

- <span data-ttu-id="0be03-543">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-543">Standard status codes.</span></span>

---
### <a name="unload-a-recording"></a><span data-ttu-id="0be03-544">レコーディングをアンロードする</span><span class="sxs-lookup"><span data-stu-id="0be03-544">Unload a recording</span></span>

**<span data-ttu-id="0be03-545">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-545">Request</span></span>**

<span data-ttu-id="0be03-546">次の要求形式を使用して、レコーディングをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="0be03-546">You can unload a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-547">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-547">Method</span></span>      | <span data-ttu-id="0be03-548">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-548">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-549">DELETE</span><span class="sxs-lookup"><span data-stu-id="0be03-549">DELETE</span></span> | <span data-ttu-id="0be03-550">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="0be03-550">/api/holographic/simulation/playback/session/file</span></span>


**<span data-ttu-id="0be03-551">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-551">URI parameters</span></span>**

<span data-ttu-id="0be03-552">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-552">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-553">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-553">URI parameter</span></span> | <span data-ttu-id="0be03-554">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-554">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-555">recording</span><span class="sxs-lookup"><span data-stu-id="0be03-555">recording</span></span>   | <span data-ttu-id="0be03-556">(**必須**) アンロードするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-556">(**required**) The name of the recording to unload.</span></span>

**<span data-ttu-id="0be03-557">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-557">Request headers</span></span>**

- <span data-ttu-id="0be03-558">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-558">None</span></span>

**<span data-ttu-id="0be03-559">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-559">Request body</span></span>**

- <span data-ttu-id="0be03-560">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-560">None</span></span>

**<span data-ttu-id="0be03-561">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-561">Response</span></span>**

- <span data-ttu-id="0be03-562">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-562">None</span></span>

**<span data-ttu-id="0be03-563">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-563">Status code</span></span>**

- <span data-ttu-id="0be03-564">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-564">Standard status codes.</span></span>

---
### <a name="upload-a-recording"></a><span data-ttu-id="0be03-565">レコーディングをアップロードする</span><span class="sxs-lookup"><span data-stu-id="0be03-565">Upload a recording</span></span>

**<span data-ttu-id="0be03-566">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-566">Request</span></span>**

<span data-ttu-id="0be03-567">次の要求形式を使用して、レコーディングをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="0be03-567">You can upload a recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-568">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-568">Method</span></span>      | <span data-ttu-id="0be03-569">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-569">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-570">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-570">POST</span></span> | <span data-ttu-id="0be03-571">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="0be03-571">/api/holographic/simulation/playback/file</span></span>


**<span data-ttu-id="0be03-572">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-572">URI parameters</span></span>**

- <span data-ttu-id="0be03-573">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-573">None</span></span>

**<span data-ttu-id="0be03-574">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-574">Request headers</span></span>**

- <span data-ttu-id="0be03-575">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-575">None</span></span>

**<span data-ttu-id="0be03-576">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-576">Request body</span></span>**

- <span data-ttu-id="0be03-577">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-577">None</span></span>

**<span data-ttu-id="0be03-578">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-578">Response</span></span>**

- <span data-ttu-id="0be03-579">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-579">None</span></span>

**<span data-ttu-id="0be03-580">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-580">Status code</span></span>**

- <span data-ttu-id="0be03-581">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-581">Standard status codes.</span></span>

---
## HSimulation recording
---
### <a name="get-the-recording-state"></a><span data-ttu-id="0be03-582">レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-582">Get the recording state</span></span>

**<span data-ttu-id="0be03-583">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-583">Request</span></span>**

<span data-ttu-id="0be03-584">次の要求形式を使用して、現在のレコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-584">You can get the current recording state by using the following request format.</span></span>
 
<span data-ttu-id="0be03-585">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-585">Method</span></span>      | <span data-ttu-id="0be03-586">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-586">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-587">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-587">GET</span></span> | <span data-ttu-id="0be03-588">/api/holographic/simulation/recording/status</span><span class="sxs-lookup"><span data-stu-id="0be03-588">/api/holographic/simulation/recording/status</span></span>


**<span data-ttu-id="0be03-589">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-589">URI parameters</span></span>**

- <span data-ttu-id="0be03-590">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-590">None</span></span>

**<span data-ttu-id="0be03-591">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-591">Request headers</span></span>**

- <span data-ttu-id="0be03-592">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-592">None</span></span>

**<span data-ttu-id="0be03-593">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-593">Request body</span></span>**

- <span data-ttu-id="0be03-594">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-594">None</span></span>

**<span data-ttu-id="0be03-595">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-595">Response</span></span>**

- <span data-ttu-id="0be03-596">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-596">None</span></span>

**<span data-ttu-id="0be03-597">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-597">Status code</span></span>**

- <span data-ttu-id="0be03-598">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-598">Standard status codes.</span></span>

---
### <a name="start-a-recording"></a><span data-ttu-id="0be03-599">レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-599">Start a recording</span></span>

**<span data-ttu-id="0be03-600">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-600">Request</span></span>**

<span data-ttu-id="0be03-601">次の要求形式を使用して、レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-601">You can start a recording by using the following request format.</span></span> <span data-ttu-id="0be03-602">アクティブにできるレコーディングは一度に 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="0be03-602">There can only be one active recording at a time.</span></span> 
 
<span data-ttu-id="0be03-603">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-603">Method</span></span>      | <span data-ttu-id="0be03-604">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-604">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-605">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-605">POST</span></span> | <span data-ttu-id="0be03-606">/api/holographic/simulation/recording/start</span><span class="sxs-lookup"><span data-stu-id="0be03-606">/api/holographic/simulation/recording/start</span></span>


**<span data-ttu-id="0be03-607">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-607">URI parameters</span></span>**

<span data-ttu-id="0be03-608">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-608">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-609">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-609">URI parameter</span></span> | <span data-ttu-id="0be03-610">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-610">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-611">head</span><span class="sxs-lookup"><span data-stu-id="0be03-611">head</span></span>   | <span data-ttu-id="0be03-612">(**下記参照**) システムで頭部のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-612">(**see below**) Set this value to 1 to indicate the system should record head data.</span></span>
<span data-ttu-id="0be03-613">hands</span><span class="sxs-lookup"><span data-stu-id="0be03-613">hands</span></span>   | <span data-ttu-id="0be03-614">(**下記参照**) システムで手のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-614">(**see below**) Set this value to 1 to indicate the system should record hands data.</span></span>
<span data-ttu-id="0be03-615">spatialMapping</span><span class="sxs-lookup"><span data-stu-id="0be03-615">spatialMapping</span></span>   | <span data-ttu-id="0be03-616">(**下記参照**) システムで空間マッピング データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-616">(**see below**) Set this value to 1 to indicate the system should record spatial mapping data.</span></span>
<span data-ttu-id="0be03-617">environment</span><span class="sxs-lookup"><span data-stu-id="0be03-617">environment</span></span>   | <span data-ttu-id="0be03-618">(**下記参照**) システムで環境データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-618">(**see below**) Set this value to 1 to indicate the system should record environment data.</span></span>
<span data-ttu-id="0be03-619">name</span><span class="sxs-lookup"><span data-stu-id="0be03-619">name</span></span>   | <span data-ttu-id="0be03-620">(**必須**) レコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-620">(**required**) The name of the recording.</span></span>
<span data-ttu-id="0be03-621">singleSpatialMappingFrame</span><span class="sxs-lookup"><span data-stu-id="0be03-621">singleSpatialMappingFrame</span></span>   | <span data-ttu-id="0be03-622">(**省略可能**) 単一の空間マッピング フレームのみを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-622">(**optional**) Set this value to 1 to indicate that only a single sptial mapping frame should be recorded.</span></span>

<span data-ttu-id="0be03-623">これらのパラメーターについては、*head*、*hands*、*spatialMapping*、*environment* のいずれか 1 つだけを 1 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-623">For these parameters, exactly one of the following parameters must be set to 1: *head*, *hands*, *spatialMapping*, or *environment*.</span></span>

**<span data-ttu-id="0be03-624">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-624">Request headers</span></span>**

- <span data-ttu-id="0be03-625">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-625">None</span></span>

**<span data-ttu-id="0be03-626">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-626">Request body</span></span>**

- <span data-ttu-id="0be03-627">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-627">None</span></span>

**<span data-ttu-id="0be03-628">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-628">Response</span></span>**

- <span data-ttu-id="0be03-629">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-629">None</span></span>

**<span data-ttu-id="0be03-630">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-630">Status code</span></span>**

- <span data-ttu-id="0be03-631">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-631">Standard status codes.</span></span>

---
### <a name="stop-the-current-recording"></a><span data-ttu-id="0be03-632">現在のレコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="0be03-632">Stop the current recording</span></span>

**<span data-ttu-id="0be03-633">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-633">Request</span></span>**

<span data-ttu-id="0be03-634">次の要求形式を使用して、現在のレコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-634">You can stop the current recording by using the following request format.</span></span> <span data-ttu-id="0be03-635">レコーディングはファイルとして返されます。</span><span class="sxs-lookup"><span data-stu-id="0be03-635">The recording will be returned as a file.</span></span>
 
<span data-ttu-id="0be03-636">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-636">Method</span></span>      | <span data-ttu-id="0be03-637">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-637">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-638">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-638">POST</span></span> | <span data-ttu-id="0be03-639">/api/holographic/simulation/recording/stop</span><span class="sxs-lookup"><span data-stu-id="0be03-639">/api/holographic/simulation/recording/stop</span></span>


**<span data-ttu-id="0be03-640">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-640">URI parameters</span></span>**

- <span data-ttu-id="0be03-641">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-641">None</span></span>

**<span data-ttu-id="0be03-642">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-642">Request headers</span></span>**

- <span data-ttu-id="0be03-643">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-643">None</span></span>

**<span data-ttu-id="0be03-644">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-644">Request body</span></span>**

- <span data-ttu-id="0be03-645">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-645">None</span></span>

**<span data-ttu-id="0be03-646">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-646">Response</span></span>**

- <span data-ttu-id="0be03-647">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-647">None</span></span>

**<span data-ttu-id="0be03-648">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-648">Status code</span></span>**

- <span data-ttu-id="0be03-649">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-649">Standard status codes.</span></span>

---
## Mixed reality capture
---
### <a name="delete-a-mixed-reality-capture-mrc-recording-from-the-device"></a><span data-ttu-id="0be03-650">デバイスから Mixed Reality キャプチャ (MRC) レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="0be03-650">Delete a mixed reality capture (MRC) recording from the device</span></span>

**<span data-ttu-id="0be03-651">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-651">Request</span></span>**

<span data-ttu-id="0be03-652">次の要求形式を使用して、MRC レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-652">You can delete an MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-653">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-653">Method</span></span>      | <span data-ttu-id="0be03-654">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-654">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-655">DELETE</span><span class="sxs-lookup"><span data-stu-id="0be03-655">DELETE</span></span> | <span data-ttu-id="0be03-656">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="0be03-656">/api/holographic/mrc/file</span></span>


**<span data-ttu-id="0be03-657">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-657">URI parameters</span></span>**

<span data-ttu-id="0be03-658">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-658">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-659">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-659">URI parameter</span></span> | <span data-ttu-id="0be03-660">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-660">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-661">filename</span><span class="sxs-lookup"><span data-stu-id="0be03-661">filename</span></span>   | <span data-ttu-id="0be03-662">(**必須**) 削除するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-662">(**required**) The name of the video file to delete.</span></span> <span data-ttu-id="0be03-663">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-663">The name should be hex64 encoded.</span></span>

**<span data-ttu-id="0be03-664">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-664">Request headers</span></span>**

- <span data-ttu-id="0be03-665">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-665">None</span></span>

**<span data-ttu-id="0be03-666">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-666">Request body</span></span>**

- <span data-ttu-id="0be03-667">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-667">None</span></span>

**<span data-ttu-id="0be03-668">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-668">Response</span></span>**

- <span data-ttu-id="0be03-669">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-669">None</span></span>

**<span data-ttu-id="0be03-670">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-670">Status code</span></span>**

- <span data-ttu-id="0be03-671">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-671">Standard status codes.</span></span>

---
### <a name="download-a-mixed-reality-capture-mrc-file"></a><span data-ttu-id="0be03-672">Mixed Reality キャプチャ (MRC) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="0be03-672">Download a mixed reality capture (MRC) file</span></span>

**<span data-ttu-id="0be03-673">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-673">Request</span></span>**

<span data-ttu-id="0be03-674">次の要求形式を使用して、デバイスから MRC ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="0be03-674">You can download an MRC file from the device by using the following request format.</span></span>
 
<span data-ttu-id="0be03-675">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-675">Method</span></span>      | <span data-ttu-id="0be03-676">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-676">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-677">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-677">GET</span></span> | <span data-ttu-id="0be03-678">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="0be03-678">/api/holographic/mrc/file</span></span>


**<span data-ttu-id="0be03-679">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-679">URI parameters</span></span>**

<span data-ttu-id="0be03-680">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-680">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-681">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-681">URI parameter</span></span> | <span data-ttu-id="0be03-682">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-682">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-683">filename</span><span class="sxs-lookup"><span data-stu-id="0be03-683">filename</span></span>   | <span data-ttu-id="0be03-684">(**必須**) 取得するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="0be03-684">(**required**) The name of the video file you want to get.</span></span> <span data-ttu-id="0be03-685">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-685">The name should be hex64 encoded.</span></span>
<span data-ttu-id="0be03-686">op</span><span class="sxs-lookup"><span data-stu-id="0be03-686">op</span></span>   | <span data-ttu-id="0be03-687">(**省略可能**) ストリームをダウンロードする場合は、この値を **stream** に設定します。</span><span class="sxs-lookup"><span data-stu-id="0be03-687">(**optional**) Set this value to **stream** if you want to download a stream.</span></span>

**<span data-ttu-id="0be03-688">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-688">Request headers</span></span>**

- <span data-ttu-id="0be03-689">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-689">None</span></span>

**<span data-ttu-id="0be03-690">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-690">Request body</span></span>**

- <span data-ttu-id="0be03-691">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-691">None</span></span>

**<span data-ttu-id="0be03-692">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-692">Response</span></span>**

- <span data-ttu-id="0be03-693">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-693">None</span></span>

**<span data-ttu-id="0be03-694">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-694">Status code</span></span>**

- <span data-ttu-id="0be03-695">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-695">Standard status codes.</span></span>

---
### <a name="get-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="0be03-696">Mixed Reality キャプチャ (MRC) の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-696">Get the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="0be03-697">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-697">Request</span></span>**

<span data-ttu-id="0be03-698">次の要求形式を使用して、MRC の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-698">You can get the MRC settings by using the following request format.</span></span>
 
<span data-ttu-id="0be03-699">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-699">Method</span></span>      | <span data-ttu-id="0be03-700">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-700">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-701">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-701">GET</span></span> | <span data-ttu-id="0be03-702">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="0be03-702">/api/holographic/mrc/settings</span></span>


**<span data-ttu-id="0be03-703">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-703">URI parameters</span></span>**

- <span data-ttu-id="0be03-704">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-704">None</span></span>

**<span data-ttu-id="0be03-705">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-705">Request headers</span></span>**

- <span data-ttu-id="0be03-706">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-706">None</span></span>

**<span data-ttu-id="0be03-707">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-707">Request body</span></span>**

- <span data-ttu-id="0be03-708">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-708">None</span></span>

**<span data-ttu-id="0be03-709">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-709">Response</span></span>**

- <span data-ttu-id="0be03-710">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-710">None</span></span>

**<span data-ttu-id="0be03-711">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-711">Status code</span></span>**

- <span data-ttu-id="0be03-712">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-712">Standard status codes.</span></span>

---
### <a name="get-the-status-of-the-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="0be03-713">Mixed Reality キャプチャ (MRC) レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-713">Get the status of the mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="0be03-714">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-714">Request</span></span>**

<span data-ttu-id="0be03-715">次の要求形式を使用して、MRC レコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-715">You can get the MRC recording status by using the following request format.</span></span> <span data-ttu-id="0be03-716">返される可能性のある値は、**running** と **stopped** です。</span><span class="sxs-lookup"><span data-stu-id="0be03-716">The possible values include **running** and **stopped**.</span></span>
 
<span data-ttu-id="0be03-717">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-717">Method</span></span>      | <span data-ttu-id="0be03-718">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-718">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-719">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-719">GET</span></span> | <span data-ttu-id="0be03-720">/api/holographic/mrc/status</span><span class="sxs-lookup"><span data-stu-id="0be03-720">/api/holographic/mrc/status</span></span>


**<span data-ttu-id="0be03-721">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-721">URI parameters</span></span>**

- <span data-ttu-id="0be03-722">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-722">None</span></span>

**<span data-ttu-id="0be03-723">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-723">Request headers</span></span>**

- <span data-ttu-id="0be03-724">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-724">None</span></span>

**<span data-ttu-id="0be03-725">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-725">Request body</span></span>**

- <span data-ttu-id="0be03-726">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-726">None</span></span>

**<span data-ttu-id="0be03-727">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-727">Response</span></span>**

- <span data-ttu-id="0be03-728">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-728">None</span></span>

**<span data-ttu-id="0be03-729">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-729">Status code</span></span>**

- <span data-ttu-id="0be03-730">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-730">Standard status codes.</span></span>

---
### <a name="get-the-list-of-mixed-reality-capture-mrc-files"></a><span data-ttu-id="0be03-731">Mixed Reality キャプチャ (MRC) ファイルのリストを取得する</span><span class="sxs-lookup"><span data-stu-id="0be03-731">Get the list of mixed reality capture (MRC) files</span></span>

**<span data-ttu-id="0be03-732">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-732">Request</span></span>**

<span data-ttu-id="0be03-733">次の要求形式を使用して、デバイスに保存されている MRC ファイルを取得できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-733">You can get the MRC files stored on the device by using the following request format.</span></span>
 
<span data-ttu-id="0be03-734">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-734">Method</span></span>      | <span data-ttu-id="0be03-735">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-735">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-736">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-736">GET</span></span> | <span data-ttu-id="0be03-737">/api/holographic/mrc/files</span><span class="sxs-lookup"><span data-stu-id="0be03-737">/api/holographic/mrc/files</span></span>


**<span data-ttu-id="0be03-738">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-738">URI parameters</span></span>**

- <span data-ttu-id="0be03-739">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-739">None</span></span>

**<span data-ttu-id="0be03-740">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-740">Request headers</span></span>**

- <span data-ttu-id="0be03-741">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-741">None</span></span>

**<span data-ttu-id="0be03-742">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-742">Request body</span></span>**

- <span data-ttu-id="0be03-743">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-743">None</span></span>

**<span data-ttu-id="0be03-744">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-744">Response</span></span>**

- <span data-ttu-id="0be03-745">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-745">None</span></span>

**<span data-ttu-id="0be03-746">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-746">Status code</span></span>**

- <span data-ttu-id="0be03-747">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-747">Standard status codes.</span></span>

---
### <a name="set-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="0be03-748">Mixed Reality キャプチャ (MRC) の設定を行う</span><span class="sxs-lookup"><span data-stu-id="0be03-748">Set the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="0be03-749">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-749">Request</span></span>**

<span data-ttu-id="0be03-750">次の要求形式を使用して、MRC の設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0be03-750">You can set the MRC settings by using the following request format.</span></span>
 
<span data-ttu-id="0be03-751">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-751">Method</span></span>      | <span data-ttu-id="0be03-752">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-752">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-753">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-753">POST</span></span> | <span data-ttu-id="0be03-754">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="0be03-754">/api/holographic/mrc/settings</span></span>


**<span data-ttu-id="0be03-755">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-755">URI parameters</span></span>**

- <span data-ttu-id="0be03-756">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-756">None</span></span>

**<span data-ttu-id="0be03-757">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-757">Request headers</span></span>**

- <span data-ttu-id="0be03-758">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-758">None</span></span>

**<span data-ttu-id="0be03-759">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-759">Request body</span></span>**

- <span data-ttu-id="0be03-760">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-760">None</span></span>

**<span data-ttu-id="0be03-761">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-761">Response</span></span>**

- <span data-ttu-id="0be03-762">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-762">None</span></span>

**<span data-ttu-id="0be03-763">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-763">Status code</span></span>**

- <span data-ttu-id="0be03-764">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-764">Standard status codes.</span></span>

---
### <a name="starts-a-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="0be03-765">Mixed Reality キャプチャ (MRC) レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-765">Starts a mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="0be03-766">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-766">Request</span></span>**

<span data-ttu-id="0be03-767">次の要求形式を使用して、MRC レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-767">You can start an MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-768">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-768">Method</span></span>      | <span data-ttu-id="0be03-769">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-769">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-770">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-770">POST</span></span> | <span data-ttu-id="0be03-771">/api/holographic/mrc/video/control/start</span><span class="sxs-lookup"><span data-stu-id="0be03-771">/api/holographic/mrc/video/control/start</span></span>


**<span data-ttu-id="0be03-772">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-772">URI parameters</span></span>**

- <span data-ttu-id="0be03-773">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-773">None</span></span>

**<span data-ttu-id="0be03-774">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-774">Request headers</span></span>**

- <span data-ttu-id="0be03-775">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-775">None</span></span>

**<span data-ttu-id="0be03-776">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-776">Request body</span></span>**

- <span data-ttu-id="0be03-777">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-777">None</span></span>

**<span data-ttu-id="0be03-778">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-778">Response</span></span>**

- <span data-ttu-id="0be03-779">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-779">None</span></span>

**<span data-ttu-id="0be03-780">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-780">Status code</span></span>**

- <span data-ttu-id="0be03-781">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-781">Standard status codes.</span></span>

---
### <a name="stop-the-current-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="0be03-782">現在の Mixed Reality キャプチャ (MRC) レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="0be03-782">Stop the current mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="0be03-783">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-783">Request</span></span>**

<span data-ttu-id="0be03-784">次の要求形式を使用して、現在の MRC レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-784">You can stop the current MRC recording by using the following request format.</span></span>
 
<span data-ttu-id="0be03-785">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-785">Method</span></span>      | <span data-ttu-id="0be03-786">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-786">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-787">POST</span><span class="sxs-lookup"><span data-stu-id="0be03-787">POST</span></span> | <span data-ttu-id="0be03-788">/api/holographic/mrc/video/control/stop</span><span class="sxs-lookup"><span data-stu-id="0be03-788">/api/holographic/mrc/video/control/stop</span></span>


**<span data-ttu-id="0be03-789">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-789">URI parameters</span></span>**

- <span data-ttu-id="0be03-790">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-790">None</span></span>

**<span data-ttu-id="0be03-791">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-791">Request headers</span></span>**

- <span data-ttu-id="0be03-792">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-792">None</span></span>

**<span data-ttu-id="0be03-793">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-793">Request body</span></span>**

- <span data-ttu-id="0be03-794">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-794">None</span></span>

**<span data-ttu-id="0be03-795">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-795">Response</span></span>**

- <span data-ttu-id="0be03-796">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-796">None</span></span>

**<span data-ttu-id="0be03-797">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-797">Status code</span></span>**

- <span data-ttu-id="0be03-798">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-798">Standard status codes.</span></span>

---
### <a name="take-a-mixed-reality-capture-mrc-photo"></a><span data-ttu-id="0be03-799">Mixed Reality キャプチャ (MRC) の写真を撮る</span><span class="sxs-lookup"><span data-stu-id="0be03-799">Take a mixed reality capture (MRC) photo</span></span>

**<span data-ttu-id="0be03-800">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-800">Request</span></span>**

<span data-ttu-id="0be03-801">次の要求形式を使用して、MRC の写真を撮ることができます。</span><span class="sxs-lookup"><span data-stu-id="0be03-801">You can take an MRC photo by using the following request format.</span></span> <span data-ttu-id="0be03-802">写真は JPEG 形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="0be03-802">The photo is returned in JPEG format.</span></span>
 
<span data-ttu-id="0be03-803">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-803">Method</span></span>      | <span data-ttu-id="0be03-804">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-804">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-805">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-805">GET</span></span> | <span data-ttu-id="0be03-806">/api/holographic/mrc/photo</span><span class="sxs-lookup"><span data-stu-id="0be03-806">/api/holographic/mrc/photo</span></span>


**<span data-ttu-id="0be03-807">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-807">URI parameters</span></span>**

- <span data-ttu-id="0be03-808">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-808">None</span></span>

**<span data-ttu-id="0be03-809">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-809">Request headers</span></span>**

- <span data-ttu-id="0be03-810">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-810">None</span></span>

**<span data-ttu-id="0be03-811">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-811">Request body</span></span>**

- <span data-ttu-id="0be03-812">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-812">None</span></span>

**<span data-ttu-id="0be03-813">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-813">Response</span></span>**

- <span data-ttu-id="0be03-814">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-814">None</span></span>

**<span data-ttu-id="0be03-815">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-815">Status code</span></span>**

- <span data-ttu-id="0be03-816">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-816">Standard status codes.</span></span>

---
## Mixed reality streaming
---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="0be03-817">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-817">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="0be03-818">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-818">Request</span></span>**

<span data-ttu-id="0be03-819">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-819">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="0be03-820">この API では既定の品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="0be03-820">This API uses the default quality.</span></span>
 
<span data-ttu-id="0be03-821">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-821">Method</span></span>      | <span data-ttu-id="0be03-822">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-822">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-823">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-823">GET</span></span> | <span data-ttu-id="0be03-824">/api/holographic/stream/live.mp4</span><span class="sxs-lookup"><span data-stu-id="0be03-824">/api/holographic/stream/live.mp4</span></span>


**<span data-ttu-id="0be03-825">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-825">URI parameters</span></span>**

<span data-ttu-id="0be03-826">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-826">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-827">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-827">URI parameter</span></span> | <span data-ttu-id="0be03-828">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-828">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-829">pv</span><span class="sxs-lookup"><span data-stu-id="0be03-829">pv</span></span>   | <span data-ttu-id="0be03-830">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-830">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="0be03-831">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-831">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-832">holo</span><span class="sxs-lookup"><span data-stu-id="0be03-832">holo</span></span>   | <span data-ttu-id="0be03-833">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-833">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="0be03-834">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-834">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-835">mic</span><span class="sxs-lookup"><span data-stu-id="0be03-835">mic</span></span>   | <span data-ttu-id="0be03-836">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-836">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="0be03-837">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-837">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-838">loopback</span><span class="sxs-lookup"><span data-stu-id="0be03-838">loopback</span></span>   | <span data-ttu-id="0be03-839">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-839">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="0be03-840">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-840">Should be **true** or **false**.</span></span>

**<span data-ttu-id="0be03-841">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-841">Request headers</span></span>**

- <span data-ttu-id="0be03-842">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-842">None</span></span>

**<span data-ttu-id="0be03-843">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-843">Request body</span></span>**

- <span data-ttu-id="0be03-844">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-844">None</span></span>

**<span data-ttu-id="0be03-845">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-845">Response</span></span>**

- <span data-ttu-id="0be03-846">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-846">None</span></span>

**<span data-ttu-id="0be03-847">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-847">Status code</span></span>**

- <span data-ttu-id="0be03-848">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-848">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="0be03-849">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-849">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="0be03-850">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-850">Request</span></span>**

<span data-ttu-id="0be03-851">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-851">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="0be03-852">この API では高品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="0be03-852">This API uses the high quality.</span></span>
 
<span data-ttu-id="0be03-853">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-853">Method</span></span>      | <span data-ttu-id="0be03-854">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-854">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-855">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-855">GET</span></span> | <span data-ttu-id="0be03-856">/api/holographic/stream/live_high.mp4</span><span class="sxs-lookup"><span data-stu-id="0be03-856">/api/holographic/stream/live_high.mp4</span></span>


**<span data-ttu-id="0be03-857">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-857">URI parameters</span></span>**

<span data-ttu-id="0be03-858">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-858">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-859">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-859">URI parameter</span></span> | <span data-ttu-id="0be03-860">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-860">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-861">pv</span><span class="sxs-lookup"><span data-stu-id="0be03-861">pv</span></span>   | <span data-ttu-id="0be03-862">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-862">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="0be03-863">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-863">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-864">holo</span><span class="sxs-lookup"><span data-stu-id="0be03-864">holo</span></span>   | <span data-ttu-id="0be03-865">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-865">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="0be03-866">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-866">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-867">mic</span><span class="sxs-lookup"><span data-stu-id="0be03-867">mic</span></span>   | <span data-ttu-id="0be03-868">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-868">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="0be03-869">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-869">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-870">loopback</span><span class="sxs-lookup"><span data-stu-id="0be03-870">loopback</span></span>   | <span data-ttu-id="0be03-871">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-871">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="0be03-872">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-872">Should be **true** or **false**.</span></span>

**<span data-ttu-id="0be03-873">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-873">Request headers</span></span>**

- <span data-ttu-id="0be03-874">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-874">None</span></span>

**<span data-ttu-id="0be03-875">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-875">Request body</span></span>**

- <span data-ttu-id="0be03-876">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-876">None</span></span>

**<span data-ttu-id="0be03-877">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-877">Response</span></span>**

- <span data-ttu-id="0be03-878">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-878">None</span></span>

**<span data-ttu-id="0be03-879">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-879">Status code</span></span>**

- <span data-ttu-id="0be03-880">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-880">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="0be03-881">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-881">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="0be03-882">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-882">Request</span></span>**

<span data-ttu-id="0be03-883">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-883">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="0be03-884">この API では低品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="0be03-884">This API uses the low quality.</span></span>
 
<span data-ttu-id="0be03-885">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-885">Method</span></span>      | <span data-ttu-id="0be03-886">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-886">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-887">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-887">GET</span></span> | <span data-ttu-id="0be03-888">/api/holographic/stream/live_low.mp4</span><span class="sxs-lookup"><span data-stu-id="0be03-888">/api/holographic/stream/live_low.mp4</span></span>


**<span data-ttu-id="0be03-889">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-889">URI parameters</span></span>**

<span data-ttu-id="0be03-890">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-890">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-891">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-891">URI parameter</span></span> | <span data-ttu-id="0be03-892">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-892">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-893">pv</span><span class="sxs-lookup"><span data-stu-id="0be03-893">pv</span></span>   | <span data-ttu-id="0be03-894">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-894">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="0be03-895">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-895">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-896">holo</span><span class="sxs-lookup"><span data-stu-id="0be03-896">holo</span></span>   | <span data-ttu-id="0be03-897">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-897">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="0be03-898">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-898">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-899">mic</span><span class="sxs-lookup"><span data-stu-id="0be03-899">mic</span></span>   | <span data-ttu-id="0be03-900">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-900">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="0be03-901">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-901">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-902">loopback</span><span class="sxs-lookup"><span data-stu-id="0be03-902">loopback</span></span>   | <span data-ttu-id="0be03-903">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-903">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="0be03-904">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-904">Should be **true** or **false**.</span></span>

**<span data-ttu-id="0be03-905">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-905">Request headers</span></span>**

- <span data-ttu-id="0be03-906">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-906">None</span></span>

**<span data-ttu-id="0be03-907">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-907">Request body</span></span>**

- <span data-ttu-id="0be03-908">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-908">None</span></span>

**<span data-ttu-id="0be03-909">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-909">Response</span></span>**

- <span data-ttu-id="0be03-910">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-910">None</span></span>

**<span data-ttu-id="0be03-911">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-911">Status code</span></span>**

- <span data-ttu-id="0be03-912">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-912">Standard status codes.</span></span>

---
### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="0be03-913">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="0be03-913">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="0be03-914">要求</span><span class="sxs-lookup"><span data-stu-id="0be03-914">Request</span></span>**

<span data-ttu-id="0be03-915">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-915">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="0be03-916">この API では中品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="0be03-916">This API uses the medium quality.</span></span>
 
<span data-ttu-id="0be03-917">メソッド</span><span class="sxs-lookup"><span data-stu-id="0be03-917">Method</span></span>      | <span data-ttu-id="0be03-918">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0be03-918">Request URI</span></span>
:------     | :-----
<span data-ttu-id="0be03-919">GET</span><span class="sxs-lookup"><span data-stu-id="0be03-919">GET</span></span> | <span data-ttu-id="0be03-920">/api/holographic/stream/live_med.mp4</span><span class="sxs-lookup"><span data-stu-id="0be03-920">/api/holographic/stream/live_med.mp4</span></span>


**<span data-ttu-id="0be03-921">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-921">URI parameters</span></span>**

<span data-ttu-id="0be03-922">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="0be03-922">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="0be03-923">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0be03-923">URI parameter</span></span> | <span data-ttu-id="0be03-924">説明</span><span class="sxs-lookup"><span data-stu-id="0be03-924">Description</span></span>
:---          | :---
<span data-ttu-id="0be03-925">pv</span><span class="sxs-lookup"><span data-stu-id="0be03-925">pv</span></span>   | <span data-ttu-id="0be03-926">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-926">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="0be03-927">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-927">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-928">holo</span><span class="sxs-lookup"><span data-stu-id="0be03-928">holo</span></span>   | <span data-ttu-id="0be03-929">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-929">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="0be03-930">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-930">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-931">mic</span><span class="sxs-lookup"><span data-stu-id="0be03-931">mic</span></span>   | <span data-ttu-id="0be03-932">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-932">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="0be03-933">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-933">Should be **true** or **false**.</span></span>
<span data-ttu-id="0be03-934">loopback</span><span class="sxs-lookup"><span data-stu-id="0be03-934">loopback</span></span>   | <span data-ttu-id="0be03-935">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0be03-935">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="0be03-936">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0be03-936">Should be **true** or **false**.</span></span>

**<span data-ttu-id="0be03-937">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0be03-937">Request headers</span></span>**

- <span data-ttu-id="0be03-938">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-938">None</span></span>

**<span data-ttu-id="0be03-939">要求本文</span><span class="sxs-lookup"><span data-stu-id="0be03-939">Request body</span></span>**

- <span data-ttu-id="0be03-940">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-940">None</span></span>

**<span data-ttu-id="0be03-941">応答</span><span class="sxs-lookup"><span data-stu-id="0be03-941">Response</span></span>**

- <span data-ttu-id="0be03-942">なし</span><span class="sxs-lookup"><span data-stu-id="0be03-942">None</span></span>

**<span data-ttu-id="0be03-943">状態コード</span><span class="sxs-lookup"><span data-stu-id="0be03-943">Status code</span></span>**

- <span data-ttu-id="0be03-944">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="0be03-944">Standard status codes.</span></span>
