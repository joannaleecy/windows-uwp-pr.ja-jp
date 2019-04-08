---
ms.assetid: 41ac0142-4d86-4bb3-b580-36d0d6956091
title: HoloLens 用 Device Portal API リファレンス
description: HoloLens 用の Windows Device Portal REST API について説明します。これらの API を使うと、プログラムからデータにアクセスしてデバイスを制御できます。
ms.date: 03/22/2018
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 3aeb068908adf6d6c40a50cee3aececba1861ee8
ms.sourcegitcommit: 81511fddf1393dffcfc069c769bb149da99529b1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "59013339"
---
# <a name="device-portal-api-reference-for-hololens"></a><span data-ttu-id="21558-104">HoloLens 用 Device Portal API リファレンス</span><span class="sxs-lookup"><span data-stu-id="21558-104">Device Portal API reference for HoloLens</span></span>

<span data-ttu-id="21558-105">Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="21558-105">Everything in the Windows Device Portal is built on top of REST API's that you can use to access the data and control your device programmatically.</span></span>

## <a name="holographic-os"></a><span data-ttu-id="21558-106">ホログラフィック OS</span><span class="sxs-lookup"><span data-stu-id="21558-106">Holographic OS</span></span>

### <a name="get-https-requirements-for-the-device-portal"></a><span data-ttu-id="21558-107">Device Portal の HTTPS 要件を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-107">Get HTTPS requirements for the Device Portal</span></span>

**<span data-ttu-id="21558-108">要求</span><span class="sxs-lookup"><span data-stu-id="21558-108">Request</span></span>**

<span data-ttu-id="21558-109">次の要求型式を使用して、Device Portal の HTTPS 要件を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-109">You can get the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
| <span data-ttu-id="21558-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-110">Method</span></span>      | <span data-ttu-id="21558-111">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-111">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-112">GET</span><span class="sxs-lookup"><span data-stu-id="21558-112">GET</span></span> | <span data-ttu-id="21558-113">/api/holographic/os/webmanagement/settings/https</span><span class="sxs-lookup"><span data-stu-id="21558-113">/api/holographic/os/webmanagement/settings/https</span></span> |


**<span data-ttu-id="21558-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-114">URI parameters</span></span>**

- <span data-ttu-id="21558-115">なし</span><span class="sxs-lookup"><span data-stu-id="21558-115">None</span></span>

**<span data-ttu-id="21558-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-116">Request headers</span></span>**

- <span data-ttu-id="21558-117">なし</span><span class="sxs-lookup"><span data-stu-id="21558-117">None</span></span>

**<span data-ttu-id="21558-118">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-118">Request body</span></span>**

- <span data-ttu-id="21558-119">なし</span><span class="sxs-lookup"><span data-stu-id="21558-119">None</span></span>

**<span data-ttu-id="21558-120">応答</span><span class="sxs-lookup"><span data-stu-id="21558-120">Response</span></span>**

- <span data-ttu-id="21558-121">なし</span><span class="sxs-lookup"><span data-stu-id="21558-121">None</span></span>

**<span data-ttu-id="21558-122">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-122">Status code</span></span>**

- <span data-ttu-id="21558-123">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-123">Standard status codes.</span></span>

### <a name="get-the-stored-interpupillary-distance-ipd"></a><span data-ttu-id="21558-124">保存されている瞳孔間距離 (IPD) を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-124">Get the stored interpupillary distance (IPD)</span></span>

**<span data-ttu-id="21558-125">要求</span><span class="sxs-lookup"><span data-stu-id="21558-125">Request</span></span>**

<span data-ttu-id="21558-126">次の要求型式を使用して、保存されている IPD の値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-126">You can get the stored IPD value by using the following request format.</span></span> <span data-ttu-id="21558-127">値はミリメートル単位で返されます。</span><span class="sxs-lookup"><span data-stu-id="21558-127">The value is returned in millimeters.</span></span>
 
| <span data-ttu-id="21558-128">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-128">Method</span></span>      | <span data-ttu-id="21558-129">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-129">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-130">GET</span><span class="sxs-lookup"><span data-stu-id="21558-130">GET</span></span> | <span data-ttu-id="21558-131">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="21558-131">/api/holographic/os/settings/ipd</span></span> |


**<span data-ttu-id="21558-132">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-132">URI parameters</span></span>**

- <span data-ttu-id="21558-133">なし</span><span class="sxs-lookup"><span data-stu-id="21558-133">None</span></span>

**<span data-ttu-id="21558-134">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-134">Request headers</span></span>**

- <span data-ttu-id="21558-135">なし</span><span class="sxs-lookup"><span data-stu-id="21558-135">None</span></span>

**<span data-ttu-id="21558-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-136">Request body</span></span>**

- <span data-ttu-id="21558-137">なし</span><span class="sxs-lookup"><span data-stu-id="21558-137">None</span></span>

**<span data-ttu-id="21558-138">応答</span><span class="sxs-lookup"><span data-stu-id="21558-138">Response</span></span>**

- <span data-ttu-id="21558-139">なし</span><span class="sxs-lookup"><span data-stu-id="21558-139">None</span></span>

**<span data-ttu-id="21558-140">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-140">Status code</span></span>**

- <span data-ttu-id="21558-141">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-141">Standard status codes.</span></span>

### <a name="get-a-list-of-hololens-specific-etw-providers"></a><span data-ttu-id="21558-142">HoloLens 固有の ETW プロバイダーの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-142">Get a list of HoloLens specific ETW providers</span></span>

**<span data-ttu-id="21558-143">要求</span><span class="sxs-lookup"><span data-stu-id="21558-143">Request</span></span>**

<span data-ttu-id="21558-144">次の要求型式を使用して、システムには登録されていない HoloLens 固有の ETW プロバイダーの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-144">You can get a list of HoloLens specific ETW providers that are not registered with the system by using the following request format.</span></span>
 
| <span data-ttu-id="21558-145">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-145">Method</span></span>      | <span data-ttu-id="21558-146">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-146">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-147">GET</span><span class="sxs-lookup"><span data-stu-id="21558-147">GET</span></span> | <span data-ttu-id="21558-148">/api/holographic/os/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="21558-148">/api/holographic/os/etw/customproviders</span></span> |


**<span data-ttu-id="21558-149">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-149">URI parameters</span></span>**

- <span data-ttu-id="21558-150">なし</span><span class="sxs-lookup"><span data-stu-id="21558-150">None</span></span>

**<span data-ttu-id="21558-151">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-151">Request headers</span></span>**

- <span data-ttu-id="21558-152">なし</span><span class="sxs-lookup"><span data-stu-id="21558-152">None</span></span>

**<span data-ttu-id="21558-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-153">Request body</span></span>**

- <span data-ttu-id="21558-154">なし</span><span class="sxs-lookup"><span data-stu-id="21558-154">None</span></span>

**<span data-ttu-id="21558-155">応答</span><span class="sxs-lookup"><span data-stu-id="21558-155">Response</span></span>**

- <span data-ttu-id="21558-156">なし</span><span class="sxs-lookup"><span data-stu-id="21558-156">None</span></span>

**<span data-ttu-id="21558-157">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-157">Status code</span></span>**

- <span data-ttu-id="21558-158">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-158">Standard status codes.</span></span>


### <a name="return-the-state-for-all-active-services"></a><span data-ttu-id="21558-159">アクティブなすべてのサービスの状態を返す</span><span class="sxs-lookup"><span data-stu-id="21558-159">Return the state for all active services</span></span>

**<span data-ttu-id="21558-160">要求</span><span class="sxs-lookup"><span data-stu-id="21558-160">Request</span></span>**

<span data-ttu-id="21558-161">次の要求形式を使用して、現在実行されているすべてのサービスの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-161">You can get the state of all services that are currently running by using the following request format.</span></span>
 
| <span data-ttu-id="21558-162">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-162">Method</span></span>      | <span data-ttu-id="21558-163">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-163">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-164">GET</span><span class="sxs-lookup"><span data-stu-id="21558-164">GET</span></span> | <span data-ttu-id="21558-165">/api/holographic/os/services</span><span class="sxs-lookup"><span data-stu-id="21558-165">/api/holographic/os/services</span></span> |


**<span data-ttu-id="21558-166">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-166">URI parameters</span></span>**

- <span data-ttu-id="21558-167">なし</span><span class="sxs-lookup"><span data-stu-id="21558-167">None</span></span>

**<span data-ttu-id="21558-168">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-168">Request headers</span></span>**

- <span data-ttu-id="21558-169">なし</span><span class="sxs-lookup"><span data-stu-id="21558-169">None</span></span>

**<span data-ttu-id="21558-170">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-170">Request body</span></span>**

- <span data-ttu-id="21558-171">なし</span><span class="sxs-lookup"><span data-stu-id="21558-171">None</span></span>

**<span data-ttu-id="21558-172">応答</span><span class="sxs-lookup"><span data-stu-id="21558-172">Response</span></span>**

- <span data-ttu-id="21558-173">なし</span><span class="sxs-lookup"><span data-stu-id="21558-173">None</span></span>

**<span data-ttu-id="21558-174">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-174">Status code</span></span>**

- <span data-ttu-id="21558-175">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-175">Standard status codes.</span></span>


### <a name="set-the-https-requirement-for-the-device-portal"></a><span data-ttu-id="21558-176">Device Portal の HTTPS 要件を設定する</span><span class="sxs-lookup"><span data-stu-id="21558-176">Set the HTTPS requirement for the Device Portal.</span></span>

**<span data-ttu-id="21558-177">要求</span><span class="sxs-lookup"><span data-stu-id="21558-177">Request</span></span>**

<span data-ttu-id="21558-178">次の要求形式を使用して、Device Portal の HTTPS 要件を設定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-178">You can set the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
| <span data-ttu-id="21558-179">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-179">Method</span></span>      | <span data-ttu-id="21558-180">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-180">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-181">POST</span><span class="sxs-lookup"><span data-stu-id="21558-181">POST</span></span> | <span data-ttu-id="21558-182">/api/holographic/management/settings/https</span><span class="sxs-lookup"><span data-stu-id="21558-182">/api/holographic/management/settings/https</span></span> |


**<span data-ttu-id="21558-183">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-183">URI parameters</span></span>**

<span data-ttu-id="21558-184">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-184">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-185">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-185">URI parameter</span></span> | <span data-ttu-id="21558-186">説明</span><span class="sxs-lookup"><span data-stu-id="21558-186">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-187">required</span><span class="sxs-lookup"><span data-stu-id="21558-187">required</span></span>   | <span data-ttu-id="21558-188">(**必須**) Device Portal で HTTPS を必要とするかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="21558-188">(**required**) Determines whether or not HTTPS is required for the Device Portal.</span></span> <span data-ttu-id="21558-189">指定できる値は、**yes**、**no**、**default** です。</span><span class="sxs-lookup"><span data-stu-id="21558-189">Possible values are **yes**, **no**, and **default**.</span></span> |

**<span data-ttu-id="21558-190">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-190">Request headers</span></span>**

- <span data-ttu-id="21558-191">なし</span><span class="sxs-lookup"><span data-stu-id="21558-191">None</span></span>

**<span data-ttu-id="21558-192">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-192">Request body</span></span>**

- <span data-ttu-id="21558-193">なし</span><span class="sxs-lookup"><span data-stu-id="21558-193">None</span></span>

**<span data-ttu-id="21558-194">応答</span><span class="sxs-lookup"><span data-stu-id="21558-194">Response</span></span>**

- <span data-ttu-id="21558-195">なし</span><span class="sxs-lookup"><span data-stu-id="21558-195">None</span></span>

**<span data-ttu-id="21558-196">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-196">Status code</span></span>**

- <span data-ttu-id="21558-197">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-197">Standard status codes.</span></span>


### <a name="set-the-interpupillary-distance-ipd"></a><span data-ttu-id="21558-198">瞳孔間距離 (IPD) を設定する</span><span class="sxs-lookup"><span data-stu-id="21558-198">Set the interpupillary distance (IPD)</span></span>

**<span data-ttu-id="21558-199">要求</span><span class="sxs-lookup"><span data-stu-id="21558-199">Request</span></span>**

<span data-ttu-id="21558-200">次の要求形式を使用して、保存されている IPD を設定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-200">You can set the stored IPD by using the following request format.</span></span>
 
| <span data-ttu-id="21558-201">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-201">Method</span></span>      | <span data-ttu-id="21558-202">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-202">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-203">POST</span><span class="sxs-lookup"><span data-stu-id="21558-203">POST</span></span> | <span data-ttu-id="21558-204">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="21558-204">/api/holographic/os/settings/ipd</span></span> |


**<span data-ttu-id="21558-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-205">URI parameters</span></span>**

<span data-ttu-id="21558-206">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-206">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-207">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-207">URI parameter</span></span> | <span data-ttu-id="21558-208">説明</span><span class="sxs-lookup"><span data-stu-id="21558-208">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-209">ipd</span><span class="sxs-lookup"><span data-stu-id="21558-209">ipd</span></span>   | <span data-ttu-id="21558-210">(**必須**) 保存する新しい IPD 値。</span><span class="sxs-lookup"><span data-stu-id="21558-210">(**required**) The new IPD value to be stored.</span></span> <span data-ttu-id="21558-211">この値はミリメートル単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="21558-211">This value should be in millimeters.</span></span> |

**<span data-ttu-id="21558-212">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-212">Request headers</span></span>**

- <span data-ttu-id="21558-213">なし</span><span class="sxs-lookup"><span data-stu-id="21558-213">None</span></span>

**<span data-ttu-id="21558-214">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-214">Request body</span></span>**

- <span data-ttu-id="21558-215">なし</span><span class="sxs-lookup"><span data-stu-id="21558-215">None</span></span>

**<span data-ttu-id="21558-216">応答</span><span class="sxs-lookup"><span data-stu-id="21558-216">Response</span></span>**

- <span data-ttu-id="21558-217">なし</span><span class="sxs-lookup"><span data-stu-id="21558-217">None</span></span>

**<span data-ttu-id="21558-218">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-218">Status code</span></span>**

- <span data-ttu-id="21558-219">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-219">Standard status codes.</span></span>


## <a name="holographic-perception"></a><span data-ttu-id="21558-220">ホログラフィックの認識</span><span class="sxs-lookup"><span data-stu-id="21558-220">Holographic perception</span></span>

### <a name="accept-websocket-upgrades-and-run-a-mirage-client-that-sends-updates"></a><span data-ttu-id="21558-221">WebSocket のアップグレードを受け入れ、ミラージュ クライアントを実行する</span><span class="sxs-lookup"><span data-stu-id="21558-221">Accept websocket upgrades and run a mirage client that sends updates</span></span>

**<span data-ttu-id="21558-222">要求</span><span class="sxs-lookup"><span data-stu-id="21558-222">Request</span></span>**

<span data-ttu-id="21558-223">次の要求型式を使用して、WebSocket のアップグレードを受け入れ、30fps で更新を送信するミラージュ クライアントを実行できます。</span><span class="sxs-lookup"><span data-stu-id="21558-223">You can accept websocket upgrades and run a mirage client that sends updates at 30 fps by using the following request format.</span></span>
 
| <span data-ttu-id="21558-224">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-224">Method</span></span>      | <span data-ttu-id="21558-225">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-225">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-226">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="21558-226">GET/WebSocket</span></span> | <span data-ttu-id="21558-227">/api/holographic/perception/client</span><span class="sxs-lookup"><span data-stu-id="21558-227">/api/holographic/perception/client</span></span> |


**<span data-ttu-id="21558-228">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-228">URI parameters</span></span>**

<span data-ttu-id="21558-229">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-229">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-230">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-230">URI parameter</span></span> | <span data-ttu-id="21558-231">説明</span><span class="sxs-lookup"><span data-stu-id="21558-231">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-232">clientmode</span><span class="sxs-lookup"><span data-stu-id="21558-232">clientmode</span></span>   | <span data-ttu-id="21558-233">(**必須**) 追跡モードを決定します。</span><span class="sxs-lookup"><span data-stu-id="21558-233">(**required**) Determines the tracking mode.</span></span> <span data-ttu-id="21558-234">値を **active** に設定すると、パッシブに確立できない場合は視覚追跡モードが強制されます。</span><span class="sxs-lookup"><span data-stu-id="21558-234">A value of **active** forces visual tracking mode when it can't be established passively.</span></span> |

**<span data-ttu-id="21558-235">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-235">Request headers</span></span>**

- <span data-ttu-id="21558-236">なし</span><span class="sxs-lookup"><span data-stu-id="21558-236">None</span></span>

**<span data-ttu-id="21558-237">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-237">Request body</span></span>**

- <span data-ttu-id="21558-238">なし</span><span class="sxs-lookup"><span data-stu-id="21558-238">None</span></span>

**<span data-ttu-id="21558-239">応答</span><span class="sxs-lookup"><span data-stu-id="21558-239">Response</span></span>**

- <span data-ttu-id="21558-240">なし</span><span class="sxs-lookup"><span data-stu-id="21558-240">None</span></span>

**<span data-ttu-id="21558-241">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-241">Status code</span></span>**

- <span data-ttu-id="21558-242">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-242">Standard status codes.</span></span>


## <a name="holographic-thermal"></a><span data-ttu-id="21558-243">ホログラフィックの温度</span><span class="sxs-lookup"><span data-stu-id="21558-243">Holographic thermal</span></span>

### <a name="get-the-thermal-stage-of-the-device"></a><span data-ttu-id="21558-244">デバイスの温度ステージを取得する</span><span class="sxs-lookup"><span data-stu-id="21558-244">Get the thermal stage of the device</span></span>

**<span data-ttu-id="21558-245">要求</span><span class="sxs-lookup"><span data-stu-id="21558-245">Request</span></span>**

<span data-ttu-id="21558-246">次の要求形式を使用して、デバイスの温度ステージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-246">You can get the thermal stage of the device by using the following request format.</span></span>
 
| <span data-ttu-id="21558-247">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-247">Method</span></span>      | <span data-ttu-id="21558-248">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-248">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-249">GET</span><span class="sxs-lookup"><span data-stu-id="21558-249">GET</span></span> | <span data-ttu-id="21558-250">/api/holographic/</span><span class="sxs-lookup"><span data-stu-id="21558-250">/api/holographic/</span></span> |

**<span data-ttu-id="21558-251">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-251">URI parameters</span></span>**

- <span data-ttu-id="21558-252">なし</span><span class="sxs-lookup"><span data-stu-id="21558-252">None</span></span>

**<span data-ttu-id="21558-253">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-253">Request headers</span></span>**

- <span data-ttu-id="21558-254">なし</span><span class="sxs-lookup"><span data-stu-id="21558-254">None</span></span>

**<span data-ttu-id="21558-255">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-255">Request body</span></span>**

- <span data-ttu-id="21558-256">なし</span><span class="sxs-lookup"><span data-stu-id="21558-256">None</span></span>

**<span data-ttu-id="21558-257">応答</span><span class="sxs-lookup"><span data-stu-id="21558-257">Response</span></span>**

<span data-ttu-id="21558-258">返される可能性のある値を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="21558-258">The possible values are indicated by the following table.</span></span>

| <span data-ttu-id="21558-259">値</span><span class="sxs-lookup"><span data-stu-id="21558-259">Value</span></span> | <span data-ttu-id="21558-260">説明</span><span class="sxs-lookup"><span data-stu-id="21558-260">Description</span></span> |
| --- | --- |
| <span data-ttu-id="21558-261">1</span><span class="sxs-lookup"><span data-stu-id="21558-261">1</span></span> | <span data-ttu-id="21558-262">標準</span><span class="sxs-lookup"><span data-stu-id="21558-262">Normal</span></span> |
| <span data-ttu-id="21558-263">2</span><span class="sxs-lookup"><span data-stu-id="21558-263">2</span></span> | <span data-ttu-id="21558-264">中温</span><span class="sxs-lookup"><span data-stu-id="21558-264">Warm</span></span> |
| <span data-ttu-id="21558-265">3</span><span class="sxs-lookup"><span data-stu-id="21558-265">3</span></span> | <span data-ttu-id="21558-266">重大</span><span class="sxs-lookup"><span data-stu-id="21558-266">Critical</span></span> |

**<span data-ttu-id="21558-267">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-267">Status code</span></span>**

- <span data-ttu-id="21558-268">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-268">Standard status codes.</span></span>

## <a name="hsimulation-control"></a><span data-ttu-id="21558-269">HSimulation の制御</span><span class="sxs-lookup"><span data-stu-id="21558-269">HSimulation control</span></span>
### <a name="create-a-control-stream-or-post-data-to-a-created-stream"></a><span data-ttu-id="21558-270">制御ストリームを作成する、または作成されたストリームにデータをポストする</span><span class="sxs-lookup"><span data-stu-id="21558-270">Create a control stream or post data to a created stream</span></span>

**<span data-ttu-id="21558-271">要求</span><span class="sxs-lookup"><span data-stu-id="21558-271">Request</span></span>**

<span data-ttu-id="21558-272">次の要求形式を使用して、制御ストリームを作成したり、作成されたストリームにデータをポストしたりできます。</span><span class="sxs-lookup"><span data-stu-id="21558-272">You can create a control stream or post data to a created stream by using the following request format.</span></span> <span data-ttu-id="21558-273">ポストされるデータの種類は **application/octet-stream** と想定されます。</span><span class="sxs-lookup"><span data-stu-id="21558-273">The posted data is expected to be of type **application/octet-stream**.</span></span>
 
| <span data-ttu-id="21558-274">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-274">Method</span></span>      | <span data-ttu-id="21558-275">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-275">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-276">POST</span><span class="sxs-lookup"><span data-stu-id="21558-276">POST</span></span> | <span data-ttu-id="21558-277">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="21558-277">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="21558-278">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-278">URI parameters</span></span>**

<span data-ttu-id="21558-279">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-279">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-280">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-280">URI parameter</span></span> | <span data-ttu-id="21558-281">説明</span><span class="sxs-lookup"><span data-stu-id="21558-281">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-282">priority</span><span class="sxs-lookup"><span data-stu-id="21558-282">priority</span></span>   | <span data-ttu-id="21558-283">(**制御ストリームを作成する場合は必須**) ストリームの優先度を示します。</span><span class="sxs-lookup"><span data-stu-id="21558-283">(**required if creating a control stream**) Indicates the priority of the stream.</span></span> |
| <span data-ttu-id="21558-284">streamid</span><span class="sxs-lookup"><span data-stu-id="21558-284">streamid</span></span>   | <span data-ttu-id="21558-285">(**作成されたストリームにポストする場合は必須**) ポスト先のストリームの識別子。</span><span class="sxs-lookup"><span data-stu-id="21558-285">(**required if posting to a created stream**) The identifier for the stream to post to.</span></span> |

**<span data-ttu-id="21558-286">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-286">Request headers</span></span>**

- <span data-ttu-id="21558-287">なし</span><span class="sxs-lookup"><span data-stu-id="21558-287">None</span></span>

**<span data-ttu-id="21558-288">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-288">Request body</span></span>**

- <span data-ttu-id="21558-289">なし</span><span class="sxs-lookup"><span data-stu-id="21558-289">None</span></span>

**<span data-ttu-id="21558-290">応答</span><span class="sxs-lookup"><span data-stu-id="21558-290">Response</span></span>**

- <span data-ttu-id="21558-291">なし</span><span class="sxs-lookup"><span data-stu-id="21558-291">None</span></span>

**<span data-ttu-id="21558-292">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-292">Status code</span></span>**

- <span data-ttu-id="21558-293">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-293">Standard status codes.</span></span>

### <a name="delete-a-control-stream"></a><span data-ttu-id="21558-294">制御ストリームを削除する</span><span class="sxs-lookup"><span data-stu-id="21558-294">Delete a control stream</span></span>

**<span data-ttu-id="21558-295">要求</span><span class="sxs-lookup"><span data-stu-id="21558-295">Request</span></span>**

<span data-ttu-id="21558-296">次の要求形式を使用して、制御ストリームを削除できます。</span><span class="sxs-lookup"><span data-stu-id="21558-296">You can delete a control stream by using the following request format.</span></span>
 
| <span data-ttu-id="21558-297">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-297">Method</span></span>      | <span data-ttu-id="21558-298">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-298">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-299">Del</span><span class="sxs-lookup"><span data-stu-id="21558-299">DELETE</span></span> | <span data-ttu-id="21558-300">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="21558-300">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="21558-301">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-301">URI parameters</span></span>**

- <span data-ttu-id="21558-302">なし</span><span class="sxs-lookup"><span data-stu-id="21558-302">None</span></span>

**<span data-ttu-id="21558-303">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-303">Request headers</span></span>**

- <span data-ttu-id="21558-304">なし</span><span class="sxs-lookup"><span data-stu-id="21558-304">None</span></span>

**<span data-ttu-id="21558-305">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-305">Request body</span></span>**

- <span data-ttu-id="21558-306">なし</span><span class="sxs-lookup"><span data-stu-id="21558-306">None</span></span>

**<span data-ttu-id="21558-307">応答</span><span class="sxs-lookup"><span data-stu-id="21558-307">Response</span></span>**

- <span data-ttu-id="21558-308">なし</span><span class="sxs-lookup"><span data-stu-id="21558-308">None</span></span>

**<span data-ttu-id="21558-309">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-309">Status code</span></span>**

- <span data-ttu-id="21558-310">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-310">Standard status codes.</span></span>

### <a name="get-a-control-stream"></a><span data-ttu-id="21558-311">制御ストリームを取得する</span><span class="sxs-lookup"><span data-stu-id="21558-311">Get a control stream</span></span>

**<span data-ttu-id="21558-312">要求</span><span class="sxs-lookup"><span data-stu-id="21558-312">Request</span></span>**

<span data-ttu-id="21558-313">次の要求形式を使用して、制御ストリームの Web ソケット接続を開くことができます。</span><span class="sxs-lookup"><span data-stu-id="21558-313">You can open a web socket connection for a control stream by using the following request format.</span></span>
 
| <span data-ttu-id="21558-314">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-314">Method</span></span>      | <span data-ttu-id="21558-315">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-315">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-316">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="21558-316">GET/WebSocket</span></span> | <span data-ttu-id="21558-317">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="21558-317">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="21558-318">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-318">URI parameters</span></span>**

- <span data-ttu-id="21558-319">なし</span><span class="sxs-lookup"><span data-stu-id="21558-319">None</span></span>

**<span data-ttu-id="21558-320">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-320">Request headers</span></span>**

- <span data-ttu-id="21558-321">なし</span><span class="sxs-lookup"><span data-stu-id="21558-321">None</span></span>

**<span data-ttu-id="21558-322">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-322">Request body</span></span>**

- <span data-ttu-id="21558-323">なし</span><span class="sxs-lookup"><span data-stu-id="21558-323">None</span></span>

**<span data-ttu-id="21558-324">応答</span><span class="sxs-lookup"><span data-stu-id="21558-324">Response</span></span>**

- <span data-ttu-id="21558-325">なし</span><span class="sxs-lookup"><span data-stu-id="21558-325">None</span></span>

**<span data-ttu-id="21558-326">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-326">Status code</span></span>**

- <span data-ttu-id="21558-327">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-327">Standard status codes.</span></span>

### <a name="get-the-simulation-mode"></a><span data-ttu-id="21558-328">シミュレーションのモードを取得します。</span><span class="sxs-lookup"><span data-stu-id="21558-328">Get the simulation mode</span></span>

**<span data-ttu-id="21558-329">要求</span><span class="sxs-lookup"><span data-stu-id="21558-329">Request</span></span>**

<span data-ttu-id="21558-330">次の要求形式を使用して、シミュレーション モードを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-330">You can get the simluation mode by using the following request format.</span></span>
 
| <span data-ttu-id="21558-331">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-331">Method</span></span>      | <span data-ttu-id="21558-332">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-332">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-333">GET</span><span class="sxs-lookup"><span data-stu-id="21558-333">GET</span></span> | <span data-ttu-id="21558-334">/api/holographic/simulation/control/mode</span><span class="sxs-lookup"><span data-stu-id="21558-334">/api/holographic/simulation/control/mode</span></span> |


**<span data-ttu-id="21558-335">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-335">URI parameters</span></span>**

- <span data-ttu-id="21558-336">なし</span><span class="sxs-lookup"><span data-stu-id="21558-336">None</span></span>

**<span data-ttu-id="21558-337">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-337">Request headers</span></span>**

- <span data-ttu-id="21558-338">なし</span><span class="sxs-lookup"><span data-stu-id="21558-338">None</span></span>

**<span data-ttu-id="21558-339">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-339">Request body</span></span>**

- <span data-ttu-id="21558-340">なし</span><span class="sxs-lookup"><span data-stu-id="21558-340">None</span></span>

**<span data-ttu-id="21558-341">応答</span><span class="sxs-lookup"><span data-stu-id="21558-341">Response</span></span>**

- <span data-ttu-id="21558-342">なし</span><span class="sxs-lookup"><span data-stu-id="21558-342">None</span></span>

**<span data-ttu-id="21558-343">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-343">Status code</span></span>**

- <span data-ttu-id="21558-344">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-344">Standard status codes.</span></span>

### <a name="set-the-simulation-mode"></a><span data-ttu-id="21558-345">シミュレーションのモードを設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-345">Set the simulation mode</span></span>

**<span data-ttu-id="21558-346">要求</span><span class="sxs-lookup"><span data-stu-id="21558-346">Request</span></span>**

<span data-ttu-id="21558-347">次の要求型式を使用して、シミュレーション モードを設定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-347">You can set the simulation mode by using the following request format.</span></span>
 
| <span data-ttu-id="21558-348">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-348">Method</span></span>      | <span data-ttu-id="21558-349">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-349">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-350">POST</span><span class="sxs-lookup"><span data-stu-id="21558-350">POST</span></span> | <span data-ttu-id="21558-351">/api/holographic/simluation/control/mode</span><span class="sxs-lookup"><span data-stu-id="21558-351">/api/holographic/simluation/control/mode</span></span> |


**<span data-ttu-id="21558-352">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-352">URI parameters</span></span>**

<span data-ttu-id="21558-353">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-353">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-354">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-354">URI parameter</span></span> | <span data-ttu-id="21558-355">説明</span><span class="sxs-lookup"><span data-stu-id="21558-355">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-356">mode</span><span class="sxs-lookup"><span data-stu-id="21558-356">mode</span></span>   | <span data-ttu-id="21558-357">(**必須**) シミュレーション モードを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-357">(**required**) Indicates the simulation mode.</span></span> <span data-ttu-id="21558-358">指定できる値は、**default**、**simulation**、**remote**、**legacy** です。</span><span class="sxs-lookup"><span data-stu-id="21558-358">Possible values include **default**, **simulation**, **remote**, and **legacy**.</span></span> |

**<span data-ttu-id="21558-359">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-359">Request headers</span></span>**

- <span data-ttu-id="21558-360">なし</span><span class="sxs-lookup"><span data-stu-id="21558-360">None</span></span>

**<span data-ttu-id="21558-361">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-361">Request body</span></span>**

- <span data-ttu-id="21558-362">なし</span><span class="sxs-lookup"><span data-stu-id="21558-362">None</span></span>

**<span data-ttu-id="21558-363">応答</span><span class="sxs-lookup"><span data-stu-id="21558-363">Response</span></span>**

- <span data-ttu-id="21558-364">なし</span><span class="sxs-lookup"><span data-stu-id="21558-364">None</span></span>

**<span data-ttu-id="21558-365">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-365">Status code</span></span>**

- <span data-ttu-id="21558-366">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-366">Standard status codes.</span></span>

## <a name="hsimulation-playback"></a><span data-ttu-id="21558-367">HSimulation の再生</span><span class="sxs-lookup"><span data-stu-id="21558-367">HSimulation playback</span></span>

### <a name="delete-a-recording"></a><span data-ttu-id="21558-368">レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="21558-368">Delete a recording</span></span>

**<span data-ttu-id="21558-369">要求</span><span class="sxs-lookup"><span data-stu-id="21558-369">Request</span></span>**

<span data-ttu-id="21558-370">次の要求型式を使用して、レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="21558-370">You can delete a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-371">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-371">Method</span></span>      | <span data-ttu-id="21558-372">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-372">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-373">Del</span><span class="sxs-lookup"><span data-stu-id="21558-373">DELETE</span></span> | <span data-ttu-id="21558-374">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="21558-374">/api/holographic/simulation/playback/file</span></span> |


**<span data-ttu-id="21558-375">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-375">URI parameters</span></span>**

<span data-ttu-id="21558-376">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-376">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-377">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-377">URI parameter</span></span> | <span data-ttu-id="21558-378">説明</span><span class="sxs-lookup"><span data-stu-id="21558-378">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-379">recording</span><span class="sxs-lookup"><span data-stu-id="21558-379">recording</span></span>   | <span data-ttu-id="21558-380">(**必須**) 削除するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-380">(**required**) The name of the recording to delete.</span></span> |

**<span data-ttu-id="21558-381">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-381">Request headers</span></span>**

- <span data-ttu-id="21558-382">なし</span><span class="sxs-lookup"><span data-stu-id="21558-382">None</span></span>

**<span data-ttu-id="21558-383">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-383">Request body</span></span>**

- <span data-ttu-id="21558-384">なし</span><span class="sxs-lookup"><span data-stu-id="21558-384">None</span></span>

**<span data-ttu-id="21558-385">応答</span><span class="sxs-lookup"><span data-stu-id="21558-385">Response</span></span>**

- <span data-ttu-id="21558-386">なし</span><span class="sxs-lookup"><span data-stu-id="21558-386">None</span></span>

**<span data-ttu-id="21558-387">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-387">Status code</span></span>**

- <span data-ttu-id="21558-388">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-388">Standard status codes.</span></span>

### <a name="get-all-recordings"></a><span data-ttu-id="21558-389">すべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="21558-389">Get all recordings</span></span>

**<span data-ttu-id="21558-390">要求</span><span class="sxs-lookup"><span data-stu-id="21558-390">Request</span></span>**

<span data-ttu-id="21558-391">次の要求形式を使用して、利用可能なすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-391">You can get all the available recordings by using the following request format.</span></span>
 
| <span data-ttu-id="21558-392">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-392">Method</span></span>      | <span data-ttu-id="21558-393">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-393">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-394">GET</span><span class="sxs-lookup"><span data-stu-id="21558-394">GET</span></span> | <span data-ttu-id="21558-395">/api/holographic/simulation/playback/files</span><span class="sxs-lookup"><span data-stu-id="21558-395">/api/holographic/simulation/playback/files</span></span> |


**<span data-ttu-id="21558-396">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-396">URI parameters</span></span>**

- <span data-ttu-id="21558-397">なし</span><span class="sxs-lookup"><span data-stu-id="21558-397">None</span></span>

**<span data-ttu-id="21558-398">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-398">Request headers</span></span>**

- <span data-ttu-id="21558-399">なし</span><span class="sxs-lookup"><span data-stu-id="21558-399">None</span></span>

**<span data-ttu-id="21558-400">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-400">Request body</span></span>**

- <span data-ttu-id="21558-401">なし</span><span class="sxs-lookup"><span data-stu-id="21558-401">None</span></span>

**<span data-ttu-id="21558-402">応答</span><span class="sxs-lookup"><span data-stu-id="21558-402">Response</span></span>**

- <span data-ttu-id="21558-403">なし</span><span class="sxs-lookup"><span data-stu-id="21558-403">None</span></span>

**<span data-ttu-id="21558-404">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-404">Status code</span></span>**

- <span data-ttu-id="21558-405">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-405">Standard status codes.</span></span>

### <a name="get-the-types-of-data-in-a-loaded-recording"></a><span data-ttu-id="21558-406">読み込まれたレコーディング内のデータの種類を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-406">Get the types of data in a loaded recording</span></span>

**<span data-ttu-id="21558-407">要求</span><span class="sxs-lookup"><span data-stu-id="21558-407">Request</span></span>**

<span data-ttu-id="21558-408">次の要求形式を使用して、読み込まれたレコーディング内のデータの種類を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-408">You can get the types of data in a loaded recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-409">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-409">Method</span></span>      | <span data-ttu-id="21558-410">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-410">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-411">GET</span><span class="sxs-lookup"><span data-stu-id="21558-411">GET</span></span> | <span data-ttu-id="21558-412">/api/holographic/simulation/playback/session/types</span><span class="sxs-lookup"><span data-stu-id="21558-412">/api/holographic/simulation/playback/session/types</span></span> |


**<span data-ttu-id="21558-413">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-413">URI parameters</span></span>**

<span data-ttu-id="21558-414">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-414">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-415">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-415">URI parameter</span></span> | <span data-ttu-id="21558-416">説明</span><span class="sxs-lookup"><span data-stu-id="21558-416">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-417">recording</span><span class="sxs-lookup"><span data-stu-id="21558-417">recording</span></span>   | <span data-ttu-id="21558-418">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-418">(**required**) The name of the recording you are interested in.</span></span> |

**<span data-ttu-id="21558-419">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-419">Request headers</span></span>**

- <span data-ttu-id="21558-420">なし</span><span class="sxs-lookup"><span data-stu-id="21558-420">None</span></span>

**<span data-ttu-id="21558-421">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-421">Request body</span></span>**

- <span data-ttu-id="21558-422">なし</span><span class="sxs-lookup"><span data-stu-id="21558-422">None</span></span>

**<span data-ttu-id="21558-423">応答</span><span class="sxs-lookup"><span data-stu-id="21558-423">Response</span></span>**

- <span data-ttu-id="21558-424">なし</span><span class="sxs-lookup"><span data-stu-id="21558-424">None</span></span>

**<span data-ttu-id="21558-425">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-425">Status code</span></span>**

- <span data-ttu-id="21558-426">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-426">Standard status codes.</span></span>

### <a name="get-all-the-loaded-recordings"></a><span data-ttu-id="21558-427">読み込まれたすべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="21558-427">Get all the loaded recordings</span></span>

**<span data-ttu-id="21558-428">要求</span><span class="sxs-lookup"><span data-stu-id="21558-428">Request</span></span>**

<span data-ttu-id="21558-429">次の要求形式を使用して、読み込まれたすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-429">You can get all the loaded recordings by using the following request format.</span></span>
 
| <span data-ttu-id="21558-430">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-430">Method</span></span>      | <span data-ttu-id="21558-431">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-431">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-432">GET</span><span class="sxs-lookup"><span data-stu-id="21558-432">GET</span></span> | <span data-ttu-id="21558-433">/api/holographic/simulation/playback/session/files</span><span class="sxs-lookup"><span data-stu-id="21558-433">/api/holographic/simulation/playback/session/files</span></span> |


**<span data-ttu-id="21558-434">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-434">URI parameters</span></span>**

- <span data-ttu-id="21558-435">なし</span><span class="sxs-lookup"><span data-stu-id="21558-435">None</span></span>

**<span data-ttu-id="21558-436">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-436">Request headers</span></span>**

- <span data-ttu-id="21558-437">なし</span><span class="sxs-lookup"><span data-stu-id="21558-437">None</span></span>

**<span data-ttu-id="21558-438">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-438">Request body</span></span>**

- <span data-ttu-id="21558-439">なし</span><span class="sxs-lookup"><span data-stu-id="21558-439">None</span></span>

**<span data-ttu-id="21558-440">応答</span><span class="sxs-lookup"><span data-stu-id="21558-440">Response</span></span>**

- <span data-ttu-id="21558-441">なし</span><span class="sxs-lookup"><span data-stu-id="21558-441">None</span></span>

**<span data-ttu-id="21558-442">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-442">Status code</span></span>**

- <span data-ttu-id="21558-443">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-443">Standard status codes.</span></span>

### <a name="get-the-current-playback-state-of-a-recording"></a><span data-ttu-id="21558-444">レコーディングの現在の再生状態を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-444">Get the current playback state of a recording</span></span> 

**<span data-ttu-id="21558-445">要求</span><span class="sxs-lookup"><span data-stu-id="21558-445">Request</span></span>**

<span data-ttu-id="21558-446">次の要求形式を使用して、レコーディングの現在の再生状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-446">You can get the current playback state of a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-447">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-447">Method</span></span>      | <span data-ttu-id="21558-448">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-448">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-449">GET</span><span class="sxs-lookup"><span data-stu-id="21558-449">GET</span></span> | <span data-ttu-id="21558-450">/api/holographic/simulation/playback/session</span><span class="sxs-lookup"><span data-stu-id="21558-450">/api/holographic/simulation/playback/session</span></span> |


**<span data-ttu-id="21558-451">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-451">URI parameters</span></span>**

<span data-ttu-id="21558-452">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-452">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-453">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-453">URI parameter</span></span> | <span data-ttu-id="21558-454">説明</span><span class="sxs-lookup"><span data-stu-id="21558-454">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-455">recording</span><span class="sxs-lookup"><span data-stu-id="21558-455">recording</span></span>   | <span data-ttu-id="21558-456">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-456">(**required**) The name of the recording that you are interested in.</span></span> |

**<span data-ttu-id="21558-457">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-457">Request headers</span></span>**

- <span data-ttu-id="21558-458">なし</span><span class="sxs-lookup"><span data-stu-id="21558-458">None</span></span>

**<span data-ttu-id="21558-459">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-459">Request body</span></span>**

- <span data-ttu-id="21558-460">なし</span><span class="sxs-lookup"><span data-stu-id="21558-460">None</span></span>

**<span data-ttu-id="21558-461">応答</span><span class="sxs-lookup"><span data-stu-id="21558-461">Response</span></span>**

- <span data-ttu-id="21558-462">なし</span><span class="sxs-lookup"><span data-stu-id="21558-462">None</span></span>

**<span data-ttu-id="21558-463">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-463">Status code</span></span>**

- <span data-ttu-id="21558-464">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-464">Standard status codes.</span></span>

### <a name="load-a-recording"></a><span data-ttu-id="21558-465">レコーディングを読み込む</span><span class="sxs-lookup"><span data-stu-id="21558-465">Load a recording</span></span>

**<span data-ttu-id="21558-466">要求</span><span class="sxs-lookup"><span data-stu-id="21558-466">Request</span></span>**

<span data-ttu-id="21558-467">次の要求形式を使用して、レコーディングを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="21558-467">You can load a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-468">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-468">Method</span></span>      | <span data-ttu-id="21558-469">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-469">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-470">POST</span><span class="sxs-lookup"><span data-stu-id="21558-470">POST</span></span> | <span data-ttu-id="21558-471">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="21558-471">/api/holographic/simulation/playback/session/file</span></span> |


**<span data-ttu-id="21558-472">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-472">URI parameters</span></span>**

<span data-ttu-id="21558-473">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-473">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-474">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-474">URI parameter</span></span> | <span data-ttu-id="21558-475">説明</span><span class="sxs-lookup"><span data-stu-id="21558-475">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-476">recording</span><span class="sxs-lookup"><span data-stu-id="21558-476">recording</span></span>   | <span data-ttu-id="21558-477">(**必須**) 読み込むレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-477">(**required**) The name of the recording to load.</span></span> |

**<span data-ttu-id="21558-478">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-478">Request headers</span></span>**

- <span data-ttu-id="21558-479">なし</span><span class="sxs-lookup"><span data-stu-id="21558-479">None</span></span>

**<span data-ttu-id="21558-480">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-480">Request body</span></span>**

- <span data-ttu-id="21558-481">なし</span><span class="sxs-lookup"><span data-stu-id="21558-481">None</span></span>

**<span data-ttu-id="21558-482">応答</span><span class="sxs-lookup"><span data-stu-id="21558-482">Response</span></span>**

- <span data-ttu-id="21558-483">なし</span><span class="sxs-lookup"><span data-stu-id="21558-483">None</span></span>

**<span data-ttu-id="21558-484">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-484">Status code</span></span>**

- <span data-ttu-id="21558-485">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-485">Standard status codes.</span></span>

### <a name="pause-a-recording"></a><span data-ttu-id="21558-486">レコーディングを一時停止する</span><span class="sxs-lookup"><span data-stu-id="21558-486">Pause a recording</span></span>

**<span data-ttu-id="21558-487">要求</span><span class="sxs-lookup"><span data-stu-id="21558-487">Request</span></span>**

<span data-ttu-id="21558-488">次の要求形式を使用して、レコーディングを一時停止できます。</span><span class="sxs-lookup"><span data-stu-id="21558-488">You can pause a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-489">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-489">Method</span></span>      | <span data-ttu-id="21558-490">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-490">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-491">POST</span><span class="sxs-lookup"><span data-stu-id="21558-491">POST</span></span> | <span data-ttu-id="21558-492">/api/holographic/simulation/playback/session/pause</span><span class="sxs-lookup"><span data-stu-id="21558-492">/api/holographic/simulation/playback/session/pause</span></span> |


**<span data-ttu-id="21558-493">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-493">URI parameters</span></span>**

<span data-ttu-id="21558-494">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-494">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-495">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-495">URI parameter</span></span> | <span data-ttu-id="21558-496">説明</span><span class="sxs-lookup"><span data-stu-id="21558-496">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-497">recording</span><span class="sxs-lookup"><span data-stu-id="21558-497">recording</span></span>   | <span data-ttu-id="21558-498">(**必須**) 一時停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-498">(**required**) The name of the recording to pause.</span></span> |

**<span data-ttu-id="21558-499">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-499">Request headers</span></span>**

- <span data-ttu-id="21558-500">なし</span><span class="sxs-lookup"><span data-stu-id="21558-500">None</span></span>

**<span data-ttu-id="21558-501">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-501">Request body</span></span>**

- <span data-ttu-id="21558-502">なし</span><span class="sxs-lookup"><span data-stu-id="21558-502">None</span></span>

**<span data-ttu-id="21558-503">応答</span><span class="sxs-lookup"><span data-stu-id="21558-503">Response</span></span>**

- <span data-ttu-id="21558-504">なし</span><span class="sxs-lookup"><span data-stu-id="21558-504">None</span></span>

**<span data-ttu-id="21558-505">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-505">Status code</span></span>**

- <span data-ttu-id="21558-506">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-506">Standard status codes.</span></span>

### <a name="play-a-recording"></a><span data-ttu-id="21558-507">レコーディングを再生する</span><span class="sxs-lookup"><span data-stu-id="21558-507">Play a recording</span></span>

**<span data-ttu-id="21558-508">要求</span><span class="sxs-lookup"><span data-stu-id="21558-508">Request</span></span>**

<span data-ttu-id="21558-509">次の要求形式を使用して、レコーディングを再生できます。</span><span class="sxs-lookup"><span data-stu-id="21558-509">You can play a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-510">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-510">Method</span></span>      | <span data-ttu-id="21558-511">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-511">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-512">POST</span><span class="sxs-lookup"><span data-stu-id="21558-512">POST</span></span> | <span data-ttu-id="21558-513">/api/holographic/simulation/playback/session/play</span><span class="sxs-lookup"><span data-stu-id="21558-513">/api/holographic/simulation/playback/session/play</span></span> |


**<span data-ttu-id="21558-514">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-514">URI parameters</span></span>**

<span data-ttu-id="21558-515">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-515">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-516">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-516">URI parameter</span></span> | <span data-ttu-id="21558-517">説明</span><span class="sxs-lookup"><span data-stu-id="21558-517">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-518">recording</span><span class="sxs-lookup"><span data-stu-id="21558-518">recording</span></span>   | <span data-ttu-id="21558-519">(**必須**) 再生するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-519">(**required**) The name of the recording to play.</span></span> |

**<span data-ttu-id="21558-520">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-520">Request headers</span></span>**

- <span data-ttu-id="21558-521">なし</span><span class="sxs-lookup"><span data-stu-id="21558-521">None</span></span>

**<span data-ttu-id="21558-522">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-522">Request body</span></span>**

- <span data-ttu-id="21558-523">なし</span><span class="sxs-lookup"><span data-stu-id="21558-523">None</span></span>

**<span data-ttu-id="21558-524">応答</span><span class="sxs-lookup"><span data-stu-id="21558-524">Response</span></span>**

- <span data-ttu-id="21558-525">なし</span><span class="sxs-lookup"><span data-stu-id="21558-525">None</span></span>

**<span data-ttu-id="21558-526">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-526">Status code</span></span>**

- <span data-ttu-id="21558-527">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-527">Standard status codes.</span></span>

### <a name="stop-a-recording"></a><span data-ttu-id="21558-528">レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="21558-528">Stop a recording</span></span>

**<span data-ttu-id="21558-529">要求</span><span class="sxs-lookup"><span data-stu-id="21558-529">Request</span></span>**

<span data-ttu-id="21558-530">次の要求形式を使用して、レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="21558-530">You can stop a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-531">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-531">Method</span></span>      | <span data-ttu-id="21558-532">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-532">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-533">POST</span><span class="sxs-lookup"><span data-stu-id="21558-533">POST</span></span> | <span data-ttu-id="21558-534">/api/holographic/simulation/playback/session/stop</span><span class="sxs-lookup"><span data-stu-id="21558-534">/api/holographic/simulation/playback/session/stop</span></span> |


**<span data-ttu-id="21558-535">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-535">URI parameters</span></span>**

<span data-ttu-id="21558-536">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-536">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-537">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-537">URI parameter</span></span> | <span data-ttu-id="21558-538">説明</span><span class="sxs-lookup"><span data-stu-id="21558-538">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-539">recording</span><span class="sxs-lookup"><span data-stu-id="21558-539">recording</span></span>   | <span data-ttu-id="21558-540">(**必須**) 停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-540">(**required**) The name of the recording to stop.</span></span> |

**<span data-ttu-id="21558-541">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-541">Request headers</span></span>**

- <span data-ttu-id="21558-542">なし</span><span class="sxs-lookup"><span data-stu-id="21558-542">None</span></span>

**<span data-ttu-id="21558-543">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-543">Request body</span></span>**

- <span data-ttu-id="21558-544">なし</span><span class="sxs-lookup"><span data-stu-id="21558-544">None</span></span>

**<span data-ttu-id="21558-545">応答</span><span class="sxs-lookup"><span data-stu-id="21558-545">Response</span></span>**

- <span data-ttu-id="21558-546">なし</span><span class="sxs-lookup"><span data-stu-id="21558-546">None</span></span>

**<span data-ttu-id="21558-547">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-547">Status code</span></span>**

- <span data-ttu-id="21558-548">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-548">Standard status codes.</span></span>

### <a name="unload-a-recording"></a><span data-ttu-id="21558-549">レコーディングをアンロードする</span><span class="sxs-lookup"><span data-stu-id="21558-549">Unload a recording</span></span>

**<span data-ttu-id="21558-550">要求</span><span class="sxs-lookup"><span data-stu-id="21558-550">Request</span></span>**

<span data-ttu-id="21558-551">次の要求形式を使用して、レコーディングをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="21558-551">You can unload a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-552">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-552">Method</span></span>      | <span data-ttu-id="21558-553">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-553">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-554">Del</span><span class="sxs-lookup"><span data-stu-id="21558-554">DELETE</span></span> | <span data-ttu-id="21558-555">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="21558-555">/api/holographic/simulation/playback/session/file</span></span> |


**<span data-ttu-id="21558-556">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-556">URI parameters</span></span>**

<span data-ttu-id="21558-557">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-557">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-558">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-558">URI parameter</span></span> | <span data-ttu-id="21558-559">説明</span><span class="sxs-lookup"><span data-stu-id="21558-559">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-560">recording</span><span class="sxs-lookup"><span data-stu-id="21558-560">recording</span></span>   | <span data-ttu-id="21558-561">(**必須**) アンロードするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-561">(**required**) The name of the recording to unload.</span></span> |

**<span data-ttu-id="21558-562">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-562">Request headers</span></span>**

- <span data-ttu-id="21558-563">なし</span><span class="sxs-lookup"><span data-stu-id="21558-563">None</span></span>

**<span data-ttu-id="21558-564">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-564">Request body</span></span>**

- <span data-ttu-id="21558-565">なし</span><span class="sxs-lookup"><span data-stu-id="21558-565">None</span></span>

**<span data-ttu-id="21558-566">応答</span><span class="sxs-lookup"><span data-stu-id="21558-566">Response</span></span>**

- <span data-ttu-id="21558-567">なし</span><span class="sxs-lookup"><span data-stu-id="21558-567">None</span></span>

**<span data-ttu-id="21558-568">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-568">Status code</span></span>**

- <span data-ttu-id="21558-569">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-569">Standard status codes.</span></span>

### <a name="upload-a-recording"></a><span data-ttu-id="21558-570">レコーディングをアップロードする</span><span class="sxs-lookup"><span data-stu-id="21558-570">Upload a recording</span></span>

**<span data-ttu-id="21558-571">要求</span><span class="sxs-lookup"><span data-stu-id="21558-571">Request</span></span>**

<span data-ttu-id="21558-572">次の要求形式を使用して、レコーディングをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="21558-572">You can upload a recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-573">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-573">Method</span></span>      | <span data-ttu-id="21558-574">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-574">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-575">POST</span><span class="sxs-lookup"><span data-stu-id="21558-575">POST</span></span> | <span data-ttu-id="21558-576">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="21558-576">/api/holographic/simulation/playback/file</span></span> |


**<span data-ttu-id="21558-577">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-577">URI parameters</span></span>**

- <span data-ttu-id="21558-578">なし</span><span class="sxs-lookup"><span data-stu-id="21558-578">None</span></span>

**<span data-ttu-id="21558-579">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-579">Request headers</span></span>**

- <span data-ttu-id="21558-580">なし</span><span class="sxs-lookup"><span data-stu-id="21558-580">None</span></span>

**<span data-ttu-id="21558-581">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-581">Request body</span></span>**

- <span data-ttu-id="21558-582">なし</span><span class="sxs-lookup"><span data-stu-id="21558-582">None</span></span>

**<span data-ttu-id="21558-583">応答</span><span class="sxs-lookup"><span data-stu-id="21558-583">Response</span></span>**

- <span data-ttu-id="21558-584">なし</span><span class="sxs-lookup"><span data-stu-id="21558-584">None</span></span>

**<span data-ttu-id="21558-585">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-585">Status code</span></span>**

- <span data-ttu-id="21558-586">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-586">Standard status codes.</span></span>

## <a name="hsimulation-recording"></a><span data-ttu-id="21558-587">HSimulation のレコーディング</span><span class="sxs-lookup"><span data-stu-id="21558-587">HSimulation recording</span></span>

### <a name="get-the-recording-state"></a><span data-ttu-id="21558-588">レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-588">Get the recording state</span></span>

**<span data-ttu-id="21558-589">要求</span><span class="sxs-lookup"><span data-stu-id="21558-589">Request</span></span>**

<span data-ttu-id="21558-590">次の要求形式を使用して、現在のレコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-590">You can get the current recording state by using the following request format.</span></span>
 
| <span data-ttu-id="21558-591">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-591">Method</span></span>      | <span data-ttu-id="21558-592">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-592">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-593">GET</span><span class="sxs-lookup"><span data-stu-id="21558-593">GET</span></span> | <span data-ttu-id="21558-594">/api/holographic/simulation/recording/status</span><span class="sxs-lookup"><span data-stu-id="21558-594">/api/holographic/simulation/recording/status</span></span> |


**<span data-ttu-id="21558-595">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-595">URI parameters</span></span>**

- <span data-ttu-id="21558-596">なし</span><span class="sxs-lookup"><span data-stu-id="21558-596">None</span></span>

**<span data-ttu-id="21558-597">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-597">Request headers</span></span>**

- <span data-ttu-id="21558-598">なし</span><span class="sxs-lookup"><span data-stu-id="21558-598">None</span></span>

**<span data-ttu-id="21558-599">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-599">Request body</span></span>**

- <span data-ttu-id="21558-600">なし</span><span class="sxs-lookup"><span data-stu-id="21558-600">None</span></span>

**<span data-ttu-id="21558-601">応答</span><span class="sxs-lookup"><span data-stu-id="21558-601">Response</span></span>**

- <span data-ttu-id="21558-602">なし</span><span class="sxs-lookup"><span data-stu-id="21558-602">None</span></span>

**<span data-ttu-id="21558-603">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-603">Status code</span></span>**

- <span data-ttu-id="21558-604">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-604">Standard status codes.</span></span>

### <a name="start-a-recording"></a><span data-ttu-id="21558-605">レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-605">Start a recording</span></span>

**<span data-ttu-id="21558-606">要求</span><span class="sxs-lookup"><span data-stu-id="21558-606">Request</span></span>**

<span data-ttu-id="21558-607">次の要求形式を使用して、レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-607">You can start a recording by using the following request format.</span></span> <span data-ttu-id="21558-608">アクティブにできるレコーディングは一度に 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="21558-608">There can only be one active recording at a time.</span></span> 
 
| <span data-ttu-id="21558-609">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-609">Method</span></span>      | <span data-ttu-id="21558-610">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-610">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-611">POST</span><span class="sxs-lookup"><span data-stu-id="21558-611">POST</span></span> | <span data-ttu-id="21558-612">/api/holographic/simulation/recording/start</span><span class="sxs-lookup"><span data-stu-id="21558-612">/api/holographic/simulation/recording/start</span></span> |


**<span data-ttu-id="21558-613">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-613">URI parameters</span></span>**

<span data-ttu-id="21558-614">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-614">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-615">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-615">URI parameter</span></span> | <span data-ttu-id="21558-616">説明</span><span class="sxs-lookup"><span data-stu-id="21558-616">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-617">head</span><span class="sxs-lookup"><span data-stu-id="21558-617">head</span></span>   | <span data-ttu-id="21558-618">(**下記参照**) システムで頭部のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-618">(**see below**) Set this value to 1 to indicate the system should record head data.</span></span> |
| <span data-ttu-id="21558-619">hands</span><span class="sxs-lookup"><span data-stu-id="21558-619">hands</span></span>   | <span data-ttu-id="21558-620">(**下記参照**) システムで手のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-620">(**see below**) Set this value to 1 to indicate the system should record hands data.</span></span> |
| <span data-ttu-id="21558-621">spatialMapping</span><span class="sxs-lookup"><span data-stu-id="21558-621">spatialMapping</span></span>   | <span data-ttu-id="21558-622">(**下記参照**) システムで空間マッピング データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-622">(**see below**) Set this value to 1 to indicate the system should record spatial mapping data.</span></span> |
| <span data-ttu-id="21558-623">environment</span><span class="sxs-lookup"><span data-stu-id="21558-623">environment</span></span>   | <span data-ttu-id="21558-624">(**下記参照**) システムで環境データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-624">(**see below**) Set this value to 1 to indicate the system should record environment data.</span></span> |
| <span data-ttu-id="21558-625">name</span><span class="sxs-lookup"><span data-stu-id="21558-625">name</span></span>   | <span data-ttu-id="21558-626">(**必須**) レコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-626">(**required**) The name of the recording.</span></span> |
| <span data-ttu-id="21558-627">singleSpatialMappingFrame</span><span class="sxs-lookup"><span data-stu-id="21558-627">singleSpatialMappingFrame</span></span>   | <span data-ttu-id="21558-628">(**省略可能**) 単一の空間マッピング フレームのみを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-628">(**optional**) Set this value to 1 to indicate that only a single sptial mapping frame should be recorded.</span></span> |

<span data-ttu-id="21558-629">これらのパラメーターについては、*head*、*hands*、*spatialMapping*、*environment* のいずれか 1 つだけを 1 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-629">For these parameters, exactly one of the following parameters must be set to 1: *head*, *hands*, *spatialMapping*, or *environment*.</span></span>

**<span data-ttu-id="21558-630">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-630">Request headers</span></span>**

- <span data-ttu-id="21558-631">なし</span><span class="sxs-lookup"><span data-stu-id="21558-631">None</span></span>

**<span data-ttu-id="21558-632">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-632">Request body</span></span>**

- <span data-ttu-id="21558-633">なし</span><span class="sxs-lookup"><span data-stu-id="21558-633">None</span></span>

**<span data-ttu-id="21558-634">応答</span><span class="sxs-lookup"><span data-stu-id="21558-634">Response</span></span>**

- <span data-ttu-id="21558-635">なし</span><span class="sxs-lookup"><span data-stu-id="21558-635">None</span></span>

**<span data-ttu-id="21558-636">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-636">Status code</span></span>**

- <span data-ttu-id="21558-637">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-637">Standard status codes.</span></span>

### <a name="stop-the-current-recording"></a><span data-ttu-id="21558-638">現在のレコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="21558-638">Stop the current recording</span></span>

**<span data-ttu-id="21558-639">要求</span><span class="sxs-lookup"><span data-stu-id="21558-639">Request</span></span>**

<span data-ttu-id="21558-640">次の要求形式を使用して、現在のレコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="21558-640">You can stop the current recording by using the following request format.</span></span> <span data-ttu-id="21558-641">レコーディングはファイルとして返されます。</span><span class="sxs-lookup"><span data-stu-id="21558-641">The recording will be returned as a file.</span></span>
 
| <span data-ttu-id="21558-642">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-642">Method</span></span>      | <span data-ttu-id="21558-643">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-643">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-644">POST</span><span class="sxs-lookup"><span data-stu-id="21558-644">POST</span></span> | <span data-ttu-id="21558-645">/api/holographic/simulation/recording/stop</span><span class="sxs-lookup"><span data-stu-id="21558-645">/api/holographic/simulation/recording/stop</span></span> |


**<span data-ttu-id="21558-646">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-646">URI parameters</span></span>**

- <span data-ttu-id="21558-647">なし</span><span class="sxs-lookup"><span data-stu-id="21558-647">None</span></span>

**<span data-ttu-id="21558-648">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-648">Request headers</span></span>**

- <span data-ttu-id="21558-649">なし</span><span class="sxs-lookup"><span data-stu-id="21558-649">None</span></span>

**<span data-ttu-id="21558-650">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-650">Request body</span></span>**

- <span data-ttu-id="21558-651">なし</span><span class="sxs-lookup"><span data-stu-id="21558-651">None</span></span>

**<span data-ttu-id="21558-652">応答</span><span class="sxs-lookup"><span data-stu-id="21558-652">Response</span></span>**

- <span data-ttu-id="21558-653">なし</span><span class="sxs-lookup"><span data-stu-id="21558-653">None</span></span>

**<span data-ttu-id="21558-654">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-654">Status code</span></span>**

- <span data-ttu-id="21558-655">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-655">Standard status codes.</span></span>

## <a name="mixed-reality-capture"></a><span data-ttu-id="21558-656">複合現実キャプチャ</span><span class="sxs-lookup"><span data-stu-id="21558-656">Mixed reality capture</span></span>

### <a name="delete-a-mixed-reality-capture-mrc-recording-from-the-device"></a><span data-ttu-id="21558-657">デバイスから Mixed Reality キャプチャ (MRC) レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="21558-657">Delete a mixed reality capture (MRC) recording from the device</span></span>

**<span data-ttu-id="21558-658">要求</span><span class="sxs-lookup"><span data-stu-id="21558-658">Request</span></span>**

<span data-ttu-id="21558-659">次の要求形式を使用して、MRC レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="21558-659">You can delete an MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-660">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-660">Method</span></span>      | <span data-ttu-id="21558-661">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-661">Request URI</span></span> |
| :------     | :----- |
<span data-ttu-id="21558-662">Del</span><span class="sxs-lookup"><span data-stu-id="21558-662">DELETE</span></span> | <span data-ttu-id="21558-663">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="21558-663">/api/holographic/mrc/file</span></span> |


**<span data-ttu-id="21558-664">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-664">URI parameters</span></span>**

<span data-ttu-id="21558-665">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-665">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-666">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-666">URI parameter</span></span> | <span data-ttu-id="21558-667">説明</span><span class="sxs-lookup"><span data-stu-id="21558-667">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-668">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="21558-668">filename</span></span>   | <span data-ttu-id="21558-669">(**必須**) 削除するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-669">(**required**) The name of the video file to delete.</span></span> <span data-ttu-id="21558-670">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-670">The name should be hex64 encoded.</span></span> |

**<span data-ttu-id="21558-671">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-671">Request headers</span></span>**

- <span data-ttu-id="21558-672">なし</span><span class="sxs-lookup"><span data-stu-id="21558-672">None</span></span>

**<span data-ttu-id="21558-673">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-673">Request body</span></span>**

- <span data-ttu-id="21558-674">なし</span><span class="sxs-lookup"><span data-stu-id="21558-674">None</span></span>

**<span data-ttu-id="21558-675">応答</span><span class="sxs-lookup"><span data-stu-id="21558-675">Response</span></span>**

- <span data-ttu-id="21558-676">なし</span><span class="sxs-lookup"><span data-stu-id="21558-676">None</span></span>

**<span data-ttu-id="21558-677">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-677">Status code</span></span>**

- <span data-ttu-id="21558-678">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-678">Standard status codes.</span></span>

### <a name="download-a-mixed-reality-capture-mrc-file"></a><span data-ttu-id="21558-679">Mixed Reality キャプチャ (MRC) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="21558-679">Download a mixed reality capture (MRC) file</span></span>

**<span data-ttu-id="21558-680">要求</span><span class="sxs-lookup"><span data-stu-id="21558-680">Request</span></span>**

<span data-ttu-id="21558-681">次の要求形式を使用して、デバイスから MRC ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="21558-681">You can download an MRC file from the device by using the following request format.</span></span>
 
| <span data-ttu-id="21558-682">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-682">Method</span></span>      | <span data-ttu-id="21558-683">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-683">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-684">GET</span><span class="sxs-lookup"><span data-stu-id="21558-684">GET</span></span> | <span data-ttu-id="21558-685">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="21558-685">/api/holographic/mrc/file</span></span> |


**<span data-ttu-id="21558-686">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-686">URI parameters</span></span>**

<span data-ttu-id="21558-687">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-687">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-688">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-688">URI parameter</span></span> | <span data-ttu-id="21558-689">説明</span><span class="sxs-lookup"><span data-stu-id="21558-689">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-690">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="21558-690">filename</span></span>   | <span data-ttu-id="21558-691">(**必須**) 取得するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="21558-691">(**required**) The name of the video file you want to get.</span></span> <span data-ttu-id="21558-692">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-692">The name should be hex64 encoded.</span></span> |
| <span data-ttu-id="21558-693">op</span><span class="sxs-lookup"><span data-stu-id="21558-693">op</span></span>   | <span data-ttu-id="21558-694">(**省略可能**) ストリームをダウンロードする場合は、この値を **stream** に設定します。</span><span class="sxs-lookup"><span data-stu-id="21558-694">(**optional**) Set this value to **stream** if you want to download a stream.</span></span> |

**<span data-ttu-id="21558-695">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-695">Request headers</span></span>**

- <span data-ttu-id="21558-696">なし</span><span class="sxs-lookup"><span data-stu-id="21558-696">None</span></span>

**<span data-ttu-id="21558-697">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-697">Request body</span></span>**

- <span data-ttu-id="21558-698">なし</span><span class="sxs-lookup"><span data-stu-id="21558-698">None</span></span>

**<span data-ttu-id="21558-699">応答</span><span class="sxs-lookup"><span data-stu-id="21558-699">Response</span></span>**

- <span data-ttu-id="21558-700">なし</span><span class="sxs-lookup"><span data-stu-id="21558-700">None</span></span>

**<span data-ttu-id="21558-701">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-701">Status code</span></span>**

- <span data-ttu-id="21558-702">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-702">Standard status codes.</span></span>

### <a name="get-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="21558-703">Mixed Reality キャプチャ (MRC) の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-703">Get the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="21558-704">要求</span><span class="sxs-lookup"><span data-stu-id="21558-704">Request</span></span>**

<span data-ttu-id="21558-705">次の要求形式を使用して、MRC の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-705">You can get the MRC settings by using the following request format.</span></span>
 
| <span data-ttu-id="21558-706">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-706">Method</span></span>      | <span data-ttu-id="21558-707">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-707">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-708">GET</span><span class="sxs-lookup"><span data-stu-id="21558-708">GET</span></span> | <span data-ttu-id="21558-709">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="21558-709">/api/holographic/mrc/settings</span></span> |


**<span data-ttu-id="21558-710">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-710">URI parameters</span></span>**

- <span data-ttu-id="21558-711">なし</span><span class="sxs-lookup"><span data-stu-id="21558-711">None</span></span>

**<span data-ttu-id="21558-712">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-712">Request headers</span></span>**

- <span data-ttu-id="21558-713">なし</span><span class="sxs-lookup"><span data-stu-id="21558-713">None</span></span>

**<span data-ttu-id="21558-714">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-714">Request body</span></span>**

- <span data-ttu-id="21558-715">なし</span><span class="sxs-lookup"><span data-stu-id="21558-715">None</span></span>

**<span data-ttu-id="21558-716">応答</span><span class="sxs-lookup"><span data-stu-id="21558-716">Response</span></span>**

- <span data-ttu-id="21558-717">なし</span><span class="sxs-lookup"><span data-stu-id="21558-717">None</span></span>

**<span data-ttu-id="21558-718">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-718">Status code</span></span>**

- <span data-ttu-id="21558-719">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-719">Standard status codes.</span></span>

### <a name="get-the-status-of-the-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="21558-720">Mixed Reality キャプチャ (MRC) レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="21558-720">Get the status of the mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="21558-721">要求</span><span class="sxs-lookup"><span data-stu-id="21558-721">Request</span></span>**

<span data-ttu-id="21558-722">次の要求形式を使用して、MRC レコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-722">You can get the MRC recording status by using the following request format.</span></span> <span data-ttu-id="21558-723">返される可能性のある値は、**running** と **stopped** です。</span><span class="sxs-lookup"><span data-stu-id="21558-723">The possible values include **running** and **stopped**.</span></span>
 
| <span data-ttu-id="21558-724">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-724">Method</span></span>      | <span data-ttu-id="21558-725">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-725">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-726">GET</span><span class="sxs-lookup"><span data-stu-id="21558-726">GET</span></span> | <span data-ttu-id="21558-727">/api/holographic/mrc/status</span><span class="sxs-lookup"><span data-stu-id="21558-727">/api/holographic/mrc/status</span></span> |


**<span data-ttu-id="21558-728">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-728">URI parameters</span></span>**

- <span data-ttu-id="21558-729">なし</span><span class="sxs-lookup"><span data-stu-id="21558-729">None</span></span>

**<span data-ttu-id="21558-730">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-730">Request headers</span></span>**

- <span data-ttu-id="21558-731">なし</span><span class="sxs-lookup"><span data-stu-id="21558-731">None</span></span>

**<span data-ttu-id="21558-732">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-732">Request body</span></span>**

- <span data-ttu-id="21558-733">なし</span><span class="sxs-lookup"><span data-stu-id="21558-733">None</span></span>

**<span data-ttu-id="21558-734">応答</span><span class="sxs-lookup"><span data-stu-id="21558-734">Response</span></span>**

- <span data-ttu-id="21558-735">なし</span><span class="sxs-lookup"><span data-stu-id="21558-735">None</span></span>

**<span data-ttu-id="21558-736">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-736">Status code</span></span>**

- <span data-ttu-id="21558-737">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-737">Standard status codes.</span></span>

### <a name="get-the-list-of-mixed-reality-capture-mrc-files"></a><span data-ttu-id="21558-738">Mixed Reality キャプチャ (MRC) ファイルのリストを取得する</span><span class="sxs-lookup"><span data-stu-id="21558-738">Get the list of mixed reality capture (MRC) files</span></span>

**<span data-ttu-id="21558-739">要求</span><span class="sxs-lookup"><span data-stu-id="21558-739">Request</span></span>**

<span data-ttu-id="21558-740">次の要求形式を使用して、デバイスに保存されている MRC ファイルを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21558-740">You can get the MRC files stored on the device by using the following request format.</span></span>
 
| <span data-ttu-id="21558-741">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-741">Method</span></span>      | <span data-ttu-id="21558-742">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-742">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-743">GET</span><span class="sxs-lookup"><span data-stu-id="21558-743">GET</span></span> | <span data-ttu-id="21558-744">/api/holographic/mrc/files</span><span class="sxs-lookup"><span data-stu-id="21558-744">/api/holographic/mrc/files</span></span> |


**<span data-ttu-id="21558-745">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-745">URI parameters</span></span>**

- <span data-ttu-id="21558-746">なし</span><span class="sxs-lookup"><span data-stu-id="21558-746">None</span></span>

**<span data-ttu-id="21558-747">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-747">Request headers</span></span>**

- <span data-ttu-id="21558-748">なし</span><span class="sxs-lookup"><span data-stu-id="21558-748">None</span></span>

**<span data-ttu-id="21558-749">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-749">Request body</span></span>**

- <span data-ttu-id="21558-750">なし</span><span class="sxs-lookup"><span data-stu-id="21558-750">None</span></span>

**<span data-ttu-id="21558-751">応答</span><span class="sxs-lookup"><span data-stu-id="21558-751">Response</span></span>**

- <span data-ttu-id="21558-752">なし</span><span class="sxs-lookup"><span data-stu-id="21558-752">None</span></span>

**<span data-ttu-id="21558-753">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-753">Status code</span></span>**

- <span data-ttu-id="21558-754">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-754">Standard status codes.</span></span>

### <a name="set-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="21558-755">Mixed Reality キャプチャ (MRC) の設定を行う</span><span class="sxs-lookup"><span data-stu-id="21558-755">Set the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="21558-756">要求</span><span class="sxs-lookup"><span data-stu-id="21558-756">Request</span></span>**

<span data-ttu-id="21558-757">次の要求形式を使用して、MRC の設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="21558-757">You can set the MRC settings by using the following request format.</span></span>
 
| <span data-ttu-id="21558-758">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-758">Method</span></span>      | <span data-ttu-id="21558-759">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-759">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-760">POST</span><span class="sxs-lookup"><span data-stu-id="21558-760">POST</span></span> | <span data-ttu-id="21558-761">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="21558-761">/api/holographic/mrc/settings</span></span> |


**<span data-ttu-id="21558-762">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-762">URI parameters</span></span>**

- <span data-ttu-id="21558-763">なし</span><span class="sxs-lookup"><span data-stu-id="21558-763">None</span></span>

**<span data-ttu-id="21558-764">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-764">Request headers</span></span>**

- <span data-ttu-id="21558-765">なし</span><span class="sxs-lookup"><span data-stu-id="21558-765">None</span></span>

**<span data-ttu-id="21558-766">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-766">Request body</span></span>**

- <span data-ttu-id="21558-767">なし</span><span class="sxs-lookup"><span data-stu-id="21558-767">None</span></span>

**<span data-ttu-id="21558-768">応答</span><span class="sxs-lookup"><span data-stu-id="21558-768">Response</span></span>**

- <span data-ttu-id="21558-769">なし</span><span class="sxs-lookup"><span data-stu-id="21558-769">None</span></span>

**<span data-ttu-id="21558-770">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-770">Status code</span></span>**

- <span data-ttu-id="21558-771">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-771">Standard status codes.</span></span>

### <a name="starts-a-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="21558-772">Mixed Reality キャプチャ (MRC) レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-772">Starts a mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="21558-773">要求</span><span class="sxs-lookup"><span data-stu-id="21558-773">Request</span></span>**

<span data-ttu-id="21558-774">次の要求形式を使用して、MRC レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-774">You can start an MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-775">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-775">Method</span></span>      | <span data-ttu-id="21558-776">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-776">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-777">POST</span><span class="sxs-lookup"><span data-stu-id="21558-777">POST</span></span> | <span data-ttu-id="21558-778">/api/holographic/mrc/video/control/start</span><span class="sxs-lookup"><span data-stu-id="21558-778">/api/holographic/mrc/video/control/start</span></span> |


**<span data-ttu-id="21558-779">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-779">URI parameters</span></span>**

- <span data-ttu-id="21558-780">なし</span><span class="sxs-lookup"><span data-stu-id="21558-780">None</span></span>

**<span data-ttu-id="21558-781">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-781">Request headers</span></span>**

- <span data-ttu-id="21558-782">なし</span><span class="sxs-lookup"><span data-stu-id="21558-782">None</span></span>

**<span data-ttu-id="21558-783">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-783">Request body</span></span>**

- <span data-ttu-id="21558-784">なし</span><span class="sxs-lookup"><span data-stu-id="21558-784">None</span></span>

**<span data-ttu-id="21558-785">応答</span><span class="sxs-lookup"><span data-stu-id="21558-785">Response</span></span>**

- <span data-ttu-id="21558-786">なし</span><span class="sxs-lookup"><span data-stu-id="21558-786">None</span></span>

**<span data-ttu-id="21558-787">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-787">Status code</span></span>**

- <span data-ttu-id="21558-788">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-788">Standard status codes.</span></span>

### <a name="stop-the-current-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="21558-789">現在の Mixed Reality キャプチャ (MRC) レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="21558-789">Stop the current mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="21558-790">要求</span><span class="sxs-lookup"><span data-stu-id="21558-790">Request</span></span>**

<span data-ttu-id="21558-791">次の要求形式を使用して、現在の MRC レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="21558-791">You can stop the current MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="21558-792">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-792">Method</span></span>      | <span data-ttu-id="21558-793">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-793">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-794">POST</span><span class="sxs-lookup"><span data-stu-id="21558-794">POST</span></span> | <span data-ttu-id="21558-795">/api/holographic/mrc/video/control/stop</span><span class="sxs-lookup"><span data-stu-id="21558-795">/api/holographic/mrc/video/control/stop</span></span> |


**<span data-ttu-id="21558-796">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-796">URI parameters</span></span>**

- <span data-ttu-id="21558-797">なし</span><span class="sxs-lookup"><span data-stu-id="21558-797">None</span></span>

**<span data-ttu-id="21558-798">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-798">Request headers</span></span>**

- <span data-ttu-id="21558-799">なし</span><span class="sxs-lookup"><span data-stu-id="21558-799">None</span></span>

**<span data-ttu-id="21558-800">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-800">Request body</span></span>**

- <span data-ttu-id="21558-801">なし</span><span class="sxs-lookup"><span data-stu-id="21558-801">None</span></span>

**<span data-ttu-id="21558-802">応答</span><span class="sxs-lookup"><span data-stu-id="21558-802">Response</span></span>**

- <span data-ttu-id="21558-803">なし</span><span class="sxs-lookup"><span data-stu-id="21558-803">None</span></span>

**<span data-ttu-id="21558-804">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-804">Status code</span></span>**

- <span data-ttu-id="21558-805">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-805">Standard status codes.</span></span>

### <a name="take-a-mixed-reality-capture-mrc-photo"></a><span data-ttu-id="21558-806">Mixed Reality キャプチャ (MRC) の写真を撮る</span><span class="sxs-lookup"><span data-stu-id="21558-806">Take a mixed reality capture (MRC) photo</span></span>

**<span data-ttu-id="21558-807">要求</span><span class="sxs-lookup"><span data-stu-id="21558-807">Request</span></span>**

<span data-ttu-id="21558-808">次の要求形式を使用して、MRC の写真を撮ることができます。</span><span class="sxs-lookup"><span data-stu-id="21558-808">You can take an MRC photo by using the following request format.</span></span> <span data-ttu-id="21558-809">写真は JPEG 形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="21558-809">The photo is returned in JPEG format.</span></span>
 
| <span data-ttu-id="21558-810">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-810">Method</span></span>      | <span data-ttu-id="21558-811">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-811">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-812">GET</span><span class="sxs-lookup"><span data-stu-id="21558-812">GET</span></span> | <span data-ttu-id="21558-813">/api/holographic/mrc/photo</span><span class="sxs-lookup"><span data-stu-id="21558-813">/api/holographic/mrc/photo</span></span> |


**<span data-ttu-id="21558-814">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-814">URI parameters</span></span>**

- <span data-ttu-id="21558-815">なし</span><span class="sxs-lookup"><span data-stu-id="21558-815">None</span></span>

**<span data-ttu-id="21558-816">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-816">Request headers</span></span>**

- <span data-ttu-id="21558-817">なし</span><span class="sxs-lookup"><span data-stu-id="21558-817">None</span></span>

**<span data-ttu-id="21558-818">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-818">Request body</span></span>**

- <span data-ttu-id="21558-819">なし</span><span class="sxs-lookup"><span data-stu-id="21558-819">None</span></span>

**<span data-ttu-id="21558-820">応答</span><span class="sxs-lookup"><span data-stu-id="21558-820">Response</span></span>**

- <span data-ttu-id="21558-821">なし</span><span class="sxs-lookup"><span data-stu-id="21558-821">None</span></span>

**<span data-ttu-id="21558-822">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-822">Status code</span></span>**

- <span data-ttu-id="21558-823">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-823">Standard status codes.</span></span>

## <a name="mixed-reality-streaming"></a><span data-ttu-id="21558-824">複合現実のストリーミング</span><span class="sxs-lookup"><span data-stu-id="21558-824">Mixed reality streaming</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="21558-825">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-825">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="21558-826">要求</span><span class="sxs-lookup"><span data-stu-id="21558-826">Request</span></span>**

<span data-ttu-id="21558-827">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-827">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="21558-828">この API では既定の品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="21558-828">This API uses the default quality.</span></span>
 
| <span data-ttu-id="21558-829">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-829">Method</span></span>      | <span data-ttu-id="21558-830">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-830">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-831">GET</span><span class="sxs-lookup"><span data-stu-id="21558-831">GET</span></span> | <span data-ttu-id="21558-832">/api/holographic/stream/live.mp4</span><span class="sxs-lookup"><span data-stu-id="21558-832">/api/holographic/stream/live.mp4</span></span> |


**<span data-ttu-id="21558-833">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-833">URI parameters</span></span>**

<span data-ttu-id="21558-834">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-834">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-835">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-835">URI parameter</span></span> | <span data-ttu-id="21558-836">説明</span><span class="sxs-lookup"><span data-stu-id="21558-836">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-837">pv</span><span class="sxs-lookup"><span data-stu-id="21558-837">pv</span></span>   | <span data-ttu-id="21558-838">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-838">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="21558-839">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-839">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-840">holo</span><span class="sxs-lookup"><span data-stu-id="21558-840">holo</span></span>   | <span data-ttu-id="21558-841">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-841">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="21558-842">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-842">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-843">mic</span><span class="sxs-lookup"><span data-stu-id="21558-843">mic</span></span>   | <span data-ttu-id="21558-844">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-844">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="21558-845">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-845">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-846">loopback</span><span class="sxs-lookup"><span data-stu-id="21558-846">loopback</span></span>   | <span data-ttu-id="21558-847">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-847">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="21558-848">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-848">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="21558-849">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-849">Request headers</span></span>**

- <span data-ttu-id="21558-850">なし</span><span class="sxs-lookup"><span data-stu-id="21558-850">None</span></span>

**<span data-ttu-id="21558-851">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-851">Request body</span></span>**

- <span data-ttu-id="21558-852">なし</span><span class="sxs-lookup"><span data-stu-id="21558-852">None</span></span>

**<span data-ttu-id="21558-853">応答</span><span class="sxs-lookup"><span data-stu-id="21558-853">Response</span></span>**

- <span data-ttu-id="21558-854">なし</span><span class="sxs-lookup"><span data-stu-id="21558-854">None</span></span>

**<span data-ttu-id="21558-855">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-855">Status code</span></span>**

- <span data-ttu-id="21558-856">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-856">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="21558-857">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-857">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="21558-858">要求</span><span class="sxs-lookup"><span data-stu-id="21558-858">Request</span></span>**

<span data-ttu-id="21558-859">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-859">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="21558-860">この API では高品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="21558-860">This API uses the high quality.</span></span>
 
| <span data-ttu-id="21558-861">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-861">Method</span></span>      | <span data-ttu-id="21558-862">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-862">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-863">GET</span><span class="sxs-lookup"><span data-stu-id="21558-863">GET</span></span> | <span data-ttu-id="21558-864">/api/holographic/stream/live_high.mp4</span><span class="sxs-lookup"><span data-stu-id="21558-864">/api/holographic/stream/live_high.mp4</span></span> |


**<span data-ttu-id="21558-865">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-865">URI parameters</span></span>**

<span data-ttu-id="21558-866">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-866">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-867">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-867">URI parameter</span></span> | <span data-ttu-id="21558-868">説明</span><span class="sxs-lookup"><span data-stu-id="21558-868">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-869">pv</span><span class="sxs-lookup"><span data-stu-id="21558-869">pv</span></span>   | <span data-ttu-id="21558-870">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-870">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="21558-871">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-871">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-872">holo</span><span class="sxs-lookup"><span data-stu-id="21558-872">holo</span></span>   | <span data-ttu-id="21558-873">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-873">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="21558-874">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-874">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-875">mic</span><span class="sxs-lookup"><span data-stu-id="21558-875">mic</span></span>   | <span data-ttu-id="21558-876">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-876">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="21558-877">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-877">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-878">loopback</span><span class="sxs-lookup"><span data-stu-id="21558-878">loopback</span></span>   | <span data-ttu-id="21558-879">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-879">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="21558-880">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-880">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="21558-881">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-881">Request headers</span></span>**

- <span data-ttu-id="21558-882">なし</span><span class="sxs-lookup"><span data-stu-id="21558-882">None</span></span>

**<span data-ttu-id="21558-883">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-883">Request body</span></span>**

- <span data-ttu-id="21558-884">なし</span><span class="sxs-lookup"><span data-stu-id="21558-884">None</span></span>

**<span data-ttu-id="21558-885">応答</span><span class="sxs-lookup"><span data-stu-id="21558-885">Response</span></span>**

- <span data-ttu-id="21558-886">なし</span><span class="sxs-lookup"><span data-stu-id="21558-886">None</span></span>

**<span data-ttu-id="21558-887">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-887">Status code</span></span>**

- <span data-ttu-id="21558-888">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-888">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="21558-889">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-889">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="21558-890">要求</span><span class="sxs-lookup"><span data-stu-id="21558-890">Request</span></span>**

<span data-ttu-id="21558-891">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-891">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="21558-892">この API では低品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="21558-892">This API uses the low quality.</span></span>
 
| <span data-ttu-id="21558-893">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-893">Method</span></span>      | <span data-ttu-id="21558-894">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-894">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-895">GET</span><span class="sxs-lookup"><span data-stu-id="21558-895">GET</span></span> | <span data-ttu-id="21558-896">/api/holographic/stream/live_low.mp4</span><span class="sxs-lookup"><span data-stu-id="21558-896">/api/holographic/stream/live_low.mp4</span></span> |


**<span data-ttu-id="21558-897">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-897">URI parameters</span></span>**

<span data-ttu-id="21558-898">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-898">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-899">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-899">URI parameter</span></span> | <span data-ttu-id="21558-900">説明</span><span class="sxs-lookup"><span data-stu-id="21558-900">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-901">pv</span><span class="sxs-lookup"><span data-stu-id="21558-901">pv</span></span>   | <span data-ttu-id="21558-902">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-902">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="21558-903">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-903">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-904">holo</span><span class="sxs-lookup"><span data-stu-id="21558-904">holo</span></span>   | <span data-ttu-id="21558-905">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-905">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="21558-906">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-906">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-907">mic</span><span class="sxs-lookup"><span data-stu-id="21558-907">mic</span></span>   | <span data-ttu-id="21558-908">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-908">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="21558-909">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-909">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-910">loopback</span><span class="sxs-lookup"><span data-stu-id="21558-910">loopback</span></span>   | <span data-ttu-id="21558-911">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-911">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="21558-912">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-912">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="21558-913">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-913">Request headers</span></span>**

- <span data-ttu-id="21558-914">なし</span><span class="sxs-lookup"><span data-stu-id="21558-914">None</span></span>

**<span data-ttu-id="21558-915">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-915">Request body</span></span>**

- <span data-ttu-id="21558-916">なし</span><span class="sxs-lookup"><span data-stu-id="21558-916">None</span></span>

**<span data-ttu-id="21558-917">応答</span><span class="sxs-lookup"><span data-stu-id="21558-917">Response</span></span>**

- <span data-ttu-id="21558-918">なし</span><span class="sxs-lookup"><span data-stu-id="21558-918">None</span></span>

**<span data-ttu-id="21558-919">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-919">Status code</span></span>**

- <span data-ttu-id="21558-920">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-920">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="21558-921">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="21558-921">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="21558-922">要求</span><span class="sxs-lookup"><span data-stu-id="21558-922">Request</span></span>**

<span data-ttu-id="21558-923">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="21558-923">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="21558-924">この API では中品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="21558-924">This API uses the medium quality.</span></span>
 
| <span data-ttu-id="21558-925">メソッド</span><span class="sxs-lookup"><span data-stu-id="21558-925">Method</span></span>      | <span data-ttu-id="21558-926">要求 URI</span><span class="sxs-lookup"><span data-stu-id="21558-926">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="21558-927">GET</span><span class="sxs-lookup"><span data-stu-id="21558-927">GET</span></span> | <span data-ttu-id="21558-928">/api/holographic/stream/live_med.mp4</span><span class="sxs-lookup"><span data-stu-id="21558-928">/api/holographic/stream/live_med.mp4</span></span> |


**<span data-ttu-id="21558-929">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-929">URI parameters</span></span>**

<span data-ttu-id="21558-930">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="21558-930">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="21558-931">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21558-931">URI parameter</span></span> | <span data-ttu-id="21558-932">説明</span><span class="sxs-lookup"><span data-stu-id="21558-932">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="21558-933">pv</span><span class="sxs-lookup"><span data-stu-id="21558-933">pv</span></span>   | <span data-ttu-id="21558-934">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-934">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="21558-935">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-935">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-936">holo</span><span class="sxs-lookup"><span data-stu-id="21558-936">holo</span></span>   | <span data-ttu-id="21558-937">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-937">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="21558-938">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-938">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-939">mic</span><span class="sxs-lookup"><span data-stu-id="21558-939">mic</span></span>   | <span data-ttu-id="21558-940">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-940">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="21558-941">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-941">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="21558-942">loopback</span><span class="sxs-lookup"><span data-stu-id="21558-942">loopback</span></span>   | <span data-ttu-id="21558-943">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="21558-943">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="21558-944">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21558-944">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="21558-945">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="21558-945">Request headers</span></span>**

- <span data-ttu-id="21558-946">なし</span><span class="sxs-lookup"><span data-stu-id="21558-946">None</span></span>

**<span data-ttu-id="21558-947">要求本文</span><span class="sxs-lookup"><span data-stu-id="21558-947">Request body</span></span>**

- <span data-ttu-id="21558-948">なし</span><span class="sxs-lookup"><span data-stu-id="21558-948">None</span></span>

**<span data-ttu-id="21558-949">応答</span><span class="sxs-lookup"><span data-stu-id="21558-949">Response</span></span>**

- <span data-ttu-id="21558-950">なし</span><span class="sxs-lookup"><span data-stu-id="21558-950">None</span></span>

**<span data-ttu-id="21558-951">状態コード</span><span class="sxs-lookup"><span data-stu-id="21558-951">Status code</span></span>**

- <span data-ttu-id="21558-952">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="21558-952">Standard status codes.</span></span>
