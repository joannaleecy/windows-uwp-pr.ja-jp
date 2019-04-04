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
# <a name="device-portal-api-reference-for-hololens"></a><span data-ttu-id="955bd-104">HoloLens 用 Device Portal API リファレンス</span><span class="sxs-lookup"><span data-stu-id="955bd-104">Device Portal API reference for HoloLens</span></span>

<span data-ttu-id="955bd-105">Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-105">Everything in the Windows Device Portal is built on top of REST API's that you can use to access the data and control your device programmatically.</span></span>

## <a name="holographic-os"></a><span data-ttu-id="955bd-106">ホログラフィック OS</span><span class="sxs-lookup"><span data-stu-id="955bd-106">Holographic OS</span></span>

### <a name="get-https-requirements-for-the-device-portal"></a><span data-ttu-id="955bd-107">Device Portal の HTTPS 要件を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-107">Get HTTPS requirements for the Device Portal</span></span>

**<span data-ttu-id="955bd-108">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-108">Request</span></span>**

<span data-ttu-id="955bd-109">次の要求型式を使用して、Device Portal の HTTPS 要件を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-109">You can get the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-110">Method</span></span>      | <span data-ttu-id="955bd-111">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-111">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-112">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-112">GET</span></span> | <span data-ttu-id="955bd-113">/api/holographic/os/webmanagement/settings/https</span><span class="sxs-lookup"><span data-stu-id="955bd-113">/api/holographic/os/webmanagement/settings/https</span></span> |


**<span data-ttu-id="955bd-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-114">URI parameters</span></span>**

- <span data-ttu-id="955bd-115">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-115">None</span></span>

**<span data-ttu-id="955bd-116">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-116">Request headers</span></span>**

- <span data-ttu-id="955bd-117">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-117">None</span></span>

**<span data-ttu-id="955bd-118">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-118">Request body</span></span>**

- <span data-ttu-id="955bd-119">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-119">None</span></span>

**<span data-ttu-id="955bd-120">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-120">Response</span></span>**

- <span data-ttu-id="955bd-121">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-121">None</span></span>

**<span data-ttu-id="955bd-122">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-122">Status code</span></span>**

- <span data-ttu-id="955bd-123">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-123">Standard status codes.</span></span>

### <a name="get-the-stored-interpupillary-distance-ipd"></a><span data-ttu-id="955bd-124">保存されている瞳孔間距離 (IPD) を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-124">Get the stored interpupillary distance (IPD)</span></span>

**<span data-ttu-id="955bd-125">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-125">Request</span></span>**

<span data-ttu-id="955bd-126">次の要求型式を使用して、保存されている IPD の値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-126">You can get the stored IPD value by using the following request format.</span></span> <span data-ttu-id="955bd-127">値はミリメートル単位で返されます。</span><span class="sxs-lookup"><span data-stu-id="955bd-127">The value is returned in millimeters.</span></span>
 
| <span data-ttu-id="955bd-128">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-128">Method</span></span>      | <span data-ttu-id="955bd-129">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-129">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-130">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-130">GET</span></span> | <span data-ttu-id="955bd-131">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="955bd-131">/api/holographic/os/settings/ipd</span></span> |


**<span data-ttu-id="955bd-132">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-132">URI parameters</span></span>**

- <span data-ttu-id="955bd-133">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-133">None</span></span>

**<span data-ttu-id="955bd-134">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-134">Request headers</span></span>**

- <span data-ttu-id="955bd-135">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-135">None</span></span>

**<span data-ttu-id="955bd-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-136">Request body</span></span>**

- <span data-ttu-id="955bd-137">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-137">None</span></span>

**<span data-ttu-id="955bd-138">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-138">Response</span></span>**

- <span data-ttu-id="955bd-139">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-139">None</span></span>

**<span data-ttu-id="955bd-140">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-140">Status code</span></span>**

- <span data-ttu-id="955bd-141">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-141">Standard status codes.</span></span>

### <a name="get-a-list-of-hololens-specific-etw-providers"></a><span data-ttu-id="955bd-142">HoloLens 固有の ETW プロバイダーの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-142">Get a list of HoloLens specific ETW providers</span></span>

**<span data-ttu-id="955bd-143">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-143">Request</span></span>**

<span data-ttu-id="955bd-144">次の要求型式を使用して、システムには登録されていない HoloLens 固有の ETW プロバイダーの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-144">You can get a list of HoloLens specific ETW providers that are not registered with the system by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-145">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-145">Method</span></span>      | <span data-ttu-id="955bd-146">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-146">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-147">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-147">GET</span></span> | <span data-ttu-id="955bd-148">/api/holographic/os/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="955bd-148">/api/holographic/os/etw/customproviders</span></span> |


**<span data-ttu-id="955bd-149">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-149">URI parameters</span></span>**

- <span data-ttu-id="955bd-150">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-150">None</span></span>

**<span data-ttu-id="955bd-151">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-151">Request headers</span></span>**

- <span data-ttu-id="955bd-152">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-152">None</span></span>

**<span data-ttu-id="955bd-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-153">Request body</span></span>**

- <span data-ttu-id="955bd-154">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-154">None</span></span>

**<span data-ttu-id="955bd-155">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-155">Response</span></span>**

- <span data-ttu-id="955bd-156">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-156">None</span></span>

**<span data-ttu-id="955bd-157">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-157">Status code</span></span>**

- <span data-ttu-id="955bd-158">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-158">Standard status codes.</span></span>


### <a name="return-the-state-for-all-active-services"></a><span data-ttu-id="955bd-159">アクティブなすべてのサービスの状態を返す</span><span class="sxs-lookup"><span data-stu-id="955bd-159">Return the state for all active services</span></span>

**<span data-ttu-id="955bd-160">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-160">Request</span></span>**

<span data-ttu-id="955bd-161">次の要求形式を使用して、現在実行されているすべてのサービスの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-161">You can get the state of all services that are currently running by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-162">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-162">Method</span></span>      | <span data-ttu-id="955bd-163">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-163">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-164">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-164">GET</span></span> | <span data-ttu-id="955bd-165">/api/holographic/os/services</span><span class="sxs-lookup"><span data-stu-id="955bd-165">/api/holographic/os/services</span></span> |


**<span data-ttu-id="955bd-166">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-166">URI parameters</span></span>**

- <span data-ttu-id="955bd-167">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-167">None</span></span>

**<span data-ttu-id="955bd-168">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-168">Request headers</span></span>**

- <span data-ttu-id="955bd-169">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-169">None</span></span>

**<span data-ttu-id="955bd-170">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-170">Request body</span></span>**

- <span data-ttu-id="955bd-171">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-171">None</span></span>

**<span data-ttu-id="955bd-172">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-172">Response</span></span>**

- <span data-ttu-id="955bd-173">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-173">None</span></span>

**<span data-ttu-id="955bd-174">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-174">Status code</span></span>**

- <span data-ttu-id="955bd-175">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-175">Standard status codes.</span></span>


### <a name="set-the-https-requirement-for-the-device-portal"></a><span data-ttu-id="955bd-176">Device Portal の HTTPS 要件を設定する</span><span class="sxs-lookup"><span data-stu-id="955bd-176">Set the HTTPS requirement for the Device Portal.</span></span>

**<span data-ttu-id="955bd-177">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-177">Request</span></span>**

<span data-ttu-id="955bd-178">次の要求形式を使用して、Device Portal の HTTPS 要件を設定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-178">You can set the HTTPS requirements for the Device Portal by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-179">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-179">Method</span></span>      | <span data-ttu-id="955bd-180">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-180">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-181">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-181">POST</span></span> | <span data-ttu-id="955bd-182">/api/holographic/management/settings/https</span><span class="sxs-lookup"><span data-stu-id="955bd-182">/api/holographic/management/settings/https</span></span> |


**<span data-ttu-id="955bd-183">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-183">URI parameters</span></span>**

<span data-ttu-id="955bd-184">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-184">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-185">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-185">URI parameter</span></span> | <span data-ttu-id="955bd-186">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-186">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-187">required</span><span class="sxs-lookup"><span data-stu-id="955bd-187">required</span></span>   | <span data-ttu-id="955bd-188">(**必須**) Device Portal で HTTPS を必要とするかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-188">(**required**) Determines whether or not HTTPS is required for the Device Portal.</span></span> <span data-ttu-id="955bd-189">指定できる値は、**yes**、**no**、**default** です。</span><span class="sxs-lookup"><span data-stu-id="955bd-189">Possible values are **yes**, **no**, and **default**.</span></span> |

**<span data-ttu-id="955bd-190">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-190">Request headers</span></span>**

- <span data-ttu-id="955bd-191">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-191">None</span></span>

**<span data-ttu-id="955bd-192">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-192">Request body</span></span>**

- <span data-ttu-id="955bd-193">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-193">None</span></span>

**<span data-ttu-id="955bd-194">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-194">Response</span></span>**

- <span data-ttu-id="955bd-195">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-195">None</span></span>

**<span data-ttu-id="955bd-196">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-196">Status code</span></span>**

- <span data-ttu-id="955bd-197">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-197">Standard status codes.</span></span>


### <a name="set-the-interpupillary-distance-ipd"></a><span data-ttu-id="955bd-198">瞳孔間距離 (IPD) を設定する</span><span class="sxs-lookup"><span data-stu-id="955bd-198">Set the interpupillary distance (IPD)</span></span>

**<span data-ttu-id="955bd-199">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-199">Request</span></span>**

<span data-ttu-id="955bd-200">次の要求形式を使用して、保存されている IPD を設定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-200">You can set the stored IPD by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-201">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-201">Method</span></span>      | <span data-ttu-id="955bd-202">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-202">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-203">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-203">POST</span></span> | <span data-ttu-id="955bd-204">/api/holographic/os/settings/ipd</span><span class="sxs-lookup"><span data-stu-id="955bd-204">/api/holographic/os/settings/ipd</span></span> |


**<span data-ttu-id="955bd-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-205">URI parameters</span></span>**

<span data-ttu-id="955bd-206">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-206">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-207">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-207">URI parameter</span></span> | <span data-ttu-id="955bd-208">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-208">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-209">ipd</span><span class="sxs-lookup"><span data-stu-id="955bd-209">ipd</span></span>   | <span data-ttu-id="955bd-210">(**必須**) 保存する新しい IPD 値。</span><span class="sxs-lookup"><span data-stu-id="955bd-210">(**required**) The new IPD value to be stored.</span></span> <span data-ttu-id="955bd-211">この値はミリメートル単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-211">This value should be in millimeters.</span></span> |

**<span data-ttu-id="955bd-212">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-212">Request headers</span></span>**

- <span data-ttu-id="955bd-213">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-213">None</span></span>

**<span data-ttu-id="955bd-214">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-214">Request body</span></span>**

- <span data-ttu-id="955bd-215">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-215">None</span></span>

**<span data-ttu-id="955bd-216">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-216">Response</span></span>**

- <span data-ttu-id="955bd-217">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-217">None</span></span>

**<span data-ttu-id="955bd-218">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-218">Status code</span></span>**

- <span data-ttu-id="955bd-219">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-219">Standard status codes.</span></span>


## <a name="holographic-perception"></a><span data-ttu-id="955bd-220">ホログラフィックの認識</span><span class="sxs-lookup"><span data-stu-id="955bd-220">Holographic perception</span></span>

### <a name="accept-websocket-upgrades-and-run-a-mirage-client-that-sends-updates"></a><span data-ttu-id="955bd-221">WebSocket のアップグレードを受け入れ、ミラージュ クライアントを実行する</span><span class="sxs-lookup"><span data-stu-id="955bd-221">Accept websocket upgrades and run a mirage client that sends updates</span></span>

**<span data-ttu-id="955bd-222">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-222">Request</span></span>**

<span data-ttu-id="955bd-223">次の要求型式を使用して、WebSocket のアップグレードを受け入れ、30fps で更新を送信するミラージュ クライアントを実行できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-223">You can accept websocket upgrades and run a mirage client that sends updates at 30 fps by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-224">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-224">Method</span></span>      | <span data-ttu-id="955bd-225">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-225">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-226">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="955bd-226">GET/WebSocket</span></span> | <span data-ttu-id="955bd-227">/api/holographic/perception/client</span><span class="sxs-lookup"><span data-stu-id="955bd-227">/api/holographic/perception/client</span></span> |


**<span data-ttu-id="955bd-228">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-228">URI parameters</span></span>**

<span data-ttu-id="955bd-229">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-229">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-230">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-230">URI parameter</span></span> | <span data-ttu-id="955bd-231">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-231">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-232">clientmode</span><span class="sxs-lookup"><span data-stu-id="955bd-232">clientmode</span></span>   | <span data-ttu-id="955bd-233">(**必須**) 追跡モードを決定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-233">(**required**) Determines the tracking mode.</span></span> <span data-ttu-id="955bd-234">値を **active** に設定すると、パッシブに確立できない場合は視覚追跡モードが強制されます。</span><span class="sxs-lookup"><span data-stu-id="955bd-234">A value of **active** forces visual tracking mode when it can't be established passively.</span></span> |

**<span data-ttu-id="955bd-235">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-235">Request headers</span></span>**

- <span data-ttu-id="955bd-236">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-236">None</span></span>

**<span data-ttu-id="955bd-237">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-237">Request body</span></span>**

- <span data-ttu-id="955bd-238">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-238">None</span></span>

**<span data-ttu-id="955bd-239">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-239">Response</span></span>**

- <span data-ttu-id="955bd-240">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-240">None</span></span>

**<span data-ttu-id="955bd-241">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-241">Status code</span></span>**

- <span data-ttu-id="955bd-242">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-242">Standard status codes.</span></span>


## <a name="holographic-thermal"></a><span data-ttu-id="955bd-243">ホログラフィックの温度</span><span class="sxs-lookup"><span data-stu-id="955bd-243">Holographic thermal</span></span>

### <a name="get-the-thermal-stage-of-the-device"></a><span data-ttu-id="955bd-244">デバイスの温度ステージを取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-244">Get the thermal stage of the device</span></span>

**<span data-ttu-id="955bd-245">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-245">Request</span></span>**

<span data-ttu-id="955bd-246">次の要求形式を使用して、デバイスの温度ステージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-246">You can get the thermal stage of the device by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-247">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-247">Method</span></span>      | <span data-ttu-id="955bd-248">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-248">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-249">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-249">GET</span></span> | <span data-ttu-id="955bd-250">/api/holographic/</span><span class="sxs-lookup"><span data-stu-id="955bd-250">/api/holographic/</span></span> |

**<span data-ttu-id="955bd-251">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-251">URI parameters</span></span>**

- <span data-ttu-id="955bd-252">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-252">None</span></span>

**<span data-ttu-id="955bd-253">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-253">Request headers</span></span>**

- <span data-ttu-id="955bd-254">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-254">None</span></span>

**<span data-ttu-id="955bd-255">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-255">Request body</span></span>**

- <span data-ttu-id="955bd-256">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-256">None</span></span>

**<span data-ttu-id="955bd-257">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-257">Response</span></span>**

<span data-ttu-id="955bd-258">返される可能性のある値を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-258">The possible values are indicated by the following table.</span></span>

| <span data-ttu-id="955bd-259">Value</span><span class="sxs-lookup"><span data-stu-id="955bd-259">Value</span></span> | <span data-ttu-id="955bd-260">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-260">Description</span></span> |
| --- | --- |
| <span data-ttu-id="955bd-261">1</span><span class="sxs-lookup"><span data-stu-id="955bd-261">1</span></span> | <span data-ttu-id="955bd-262">標準</span><span class="sxs-lookup"><span data-stu-id="955bd-262">Normal</span></span> |
| <span data-ttu-id="955bd-263">2</span><span class="sxs-lookup"><span data-stu-id="955bd-263">2</span></span> | <span data-ttu-id="955bd-264">中温</span><span class="sxs-lookup"><span data-stu-id="955bd-264">Warm</span></span> |
| <span data-ttu-id="955bd-265">3</span><span class="sxs-lookup"><span data-stu-id="955bd-265">3</span></span> | <span data-ttu-id="955bd-266">重大</span><span class="sxs-lookup"><span data-stu-id="955bd-266">Critical</span></span> |

**<span data-ttu-id="955bd-267">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-267">Status code</span></span>**

- <span data-ttu-id="955bd-268">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-268">Standard status codes.</span></span>

## <a name="hsimulation-control"></a><span data-ttu-id="955bd-269">HSimulation の制御</span><span class="sxs-lookup"><span data-stu-id="955bd-269">HSimulation control</span></span>
### <a name="create-a-control-stream-or-post-data-to-a-created-stream"></a><span data-ttu-id="955bd-270">制御ストリームを作成する、または作成されたストリームにデータをポストする</span><span class="sxs-lookup"><span data-stu-id="955bd-270">Create a control stream or post data to a created stream</span></span>

**<span data-ttu-id="955bd-271">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-271">Request</span></span>**

<span data-ttu-id="955bd-272">次の要求形式を使用して、制御ストリームを作成したり、作成されたストリームにデータをポストしたりできます。</span><span class="sxs-lookup"><span data-stu-id="955bd-272">You can create a control stream or post data to a created stream by using the following request format.</span></span> <span data-ttu-id="955bd-273">ポストされるデータの種類は **application/octet-stream** と想定されます。</span><span class="sxs-lookup"><span data-stu-id="955bd-273">The posted data is expected to be of type **application/octet-stream**.</span></span>
 
| <span data-ttu-id="955bd-274">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-274">Method</span></span>      | <span data-ttu-id="955bd-275">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-275">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-276">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-276">POST</span></span> | <span data-ttu-id="955bd-277">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="955bd-277">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="955bd-278">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-278">URI parameters</span></span>**

<span data-ttu-id="955bd-279">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-279">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-280">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-280">URI parameter</span></span> | <span data-ttu-id="955bd-281">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-281">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-282">priority</span><span class="sxs-lookup"><span data-stu-id="955bd-282">priority</span></span>   | <span data-ttu-id="955bd-283">(**制御ストリームを作成する場合は必須**) ストリームの優先度を示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-283">(**required if creating a control stream**) Indicates the priority of the stream.</span></span> |
| <span data-ttu-id="955bd-284">streamid</span><span class="sxs-lookup"><span data-stu-id="955bd-284">streamid</span></span>   | <span data-ttu-id="955bd-285">(**作成されたストリームにポストする場合は必須**) ポスト先のストリームの識別子。</span><span class="sxs-lookup"><span data-stu-id="955bd-285">(**required if posting to a created stream**) The identifier for the stream to post to.</span></span> |

**<span data-ttu-id="955bd-286">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-286">Request headers</span></span>**

- <span data-ttu-id="955bd-287">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-287">None</span></span>

**<span data-ttu-id="955bd-288">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-288">Request body</span></span>**

- <span data-ttu-id="955bd-289">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-289">None</span></span>

**<span data-ttu-id="955bd-290">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-290">Response</span></span>**

- <span data-ttu-id="955bd-291">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-291">None</span></span>

**<span data-ttu-id="955bd-292">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-292">Status code</span></span>**

- <span data-ttu-id="955bd-293">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-293">Standard status codes.</span></span>

### <a name="delete-a-control-stream"></a><span data-ttu-id="955bd-294">制御ストリームを削除する</span><span class="sxs-lookup"><span data-stu-id="955bd-294">Delete a control stream</span></span>

**<span data-ttu-id="955bd-295">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-295">Request</span></span>**

<span data-ttu-id="955bd-296">次の要求形式を使用して、制御ストリームを削除できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-296">You can delete a control stream by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-297">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-297">Method</span></span>      | <span data-ttu-id="955bd-298">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-298">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-299">Del</span><span class="sxs-lookup"><span data-stu-id="955bd-299">DELETE</span></span> | <span data-ttu-id="955bd-300">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="955bd-300">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="955bd-301">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-301">URI parameters</span></span>**

- <span data-ttu-id="955bd-302">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-302">None</span></span>

**<span data-ttu-id="955bd-303">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-303">Request headers</span></span>**

- <span data-ttu-id="955bd-304">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-304">None</span></span>

**<span data-ttu-id="955bd-305">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-305">Request body</span></span>**

- <span data-ttu-id="955bd-306">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-306">None</span></span>

**<span data-ttu-id="955bd-307">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-307">Response</span></span>**

- <span data-ttu-id="955bd-308">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-308">None</span></span>

**<span data-ttu-id="955bd-309">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-309">Status code</span></span>**

- <span data-ttu-id="955bd-310">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-310">Standard status codes.</span></span>

### <a name="get-a-control-stream"></a><span data-ttu-id="955bd-311">制御ストリームを取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-311">Get a control stream</span></span>

**<span data-ttu-id="955bd-312">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-312">Request</span></span>**

<span data-ttu-id="955bd-313">次の要求形式を使用して、制御ストリームの Web ソケット接続を開くことができます。</span><span class="sxs-lookup"><span data-stu-id="955bd-313">You can open a web socket connection for a control stream by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-314">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-314">Method</span></span>      | <span data-ttu-id="955bd-315">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-315">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-316">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="955bd-316">GET/WebSocket</span></span> | <span data-ttu-id="955bd-317">/api/holographic/simulation/control/stream</span><span class="sxs-lookup"><span data-stu-id="955bd-317">/api/holographic/simulation/control/stream</span></span> |


**<span data-ttu-id="955bd-318">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-318">URI parameters</span></span>**

- <span data-ttu-id="955bd-319">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-319">None</span></span>

**<span data-ttu-id="955bd-320">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-320">Request headers</span></span>**

- <span data-ttu-id="955bd-321">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-321">None</span></span>

**<span data-ttu-id="955bd-322">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-322">Request body</span></span>**

- <span data-ttu-id="955bd-323">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-323">None</span></span>

**<span data-ttu-id="955bd-324">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-324">Response</span></span>**

- <span data-ttu-id="955bd-325">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-325">None</span></span>

**<span data-ttu-id="955bd-326">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-326">Status code</span></span>**

- <span data-ttu-id="955bd-327">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-327">Standard status codes.</span></span>

### <a name="get-the-simulation-mode"></a><span data-ttu-id="955bd-328">シミュレーションのモードを取得します。</span><span class="sxs-lookup"><span data-stu-id="955bd-328">Get the simulation mode</span></span>

**<span data-ttu-id="955bd-329">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-329">Request</span></span>**

<span data-ttu-id="955bd-330">次の要求形式を使用して、シミュレーション モードを取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-330">You can get the simluation mode by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-331">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-331">Method</span></span>      | <span data-ttu-id="955bd-332">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-332">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-333">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-333">GET</span></span> | <span data-ttu-id="955bd-334">/api/holographic/simulation/control/mode</span><span class="sxs-lookup"><span data-stu-id="955bd-334">/api/holographic/simulation/control/mode</span></span> |


**<span data-ttu-id="955bd-335">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-335">URI parameters</span></span>**

- <span data-ttu-id="955bd-336">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-336">None</span></span>

**<span data-ttu-id="955bd-337">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-337">Request headers</span></span>**

- <span data-ttu-id="955bd-338">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-338">None</span></span>

**<span data-ttu-id="955bd-339">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-339">Request body</span></span>**

- <span data-ttu-id="955bd-340">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-340">None</span></span>

**<span data-ttu-id="955bd-341">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-341">Response</span></span>**

- <span data-ttu-id="955bd-342">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-342">None</span></span>

**<span data-ttu-id="955bd-343">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-343">Status code</span></span>**

- <span data-ttu-id="955bd-344">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-344">Standard status codes.</span></span>

### <a name="set-the-simulation-mode"></a><span data-ttu-id="955bd-345">シミュレーションのモードを設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-345">Set the simulation mode</span></span>

**<span data-ttu-id="955bd-346">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-346">Request</span></span>**

<span data-ttu-id="955bd-347">次の要求型式を使用して、シミュレーション モードを設定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-347">You can set the simulation mode by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-348">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-348">Method</span></span>      | <span data-ttu-id="955bd-349">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-349">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-350">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-350">POST</span></span> | <span data-ttu-id="955bd-351">/api/holographic/simluation/control/mode</span><span class="sxs-lookup"><span data-stu-id="955bd-351">/api/holographic/simluation/control/mode</span></span> |


**<span data-ttu-id="955bd-352">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-352">URI parameters</span></span>**

<span data-ttu-id="955bd-353">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-353">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-354">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-354">URI parameter</span></span> | <span data-ttu-id="955bd-355">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-355">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-356">mode</span><span class="sxs-lookup"><span data-stu-id="955bd-356">mode</span></span>   | <span data-ttu-id="955bd-357">(**必須**) シミュレーション モードを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-357">(**required**) Indicates the simulation mode.</span></span> <span data-ttu-id="955bd-358">指定できる値は、**default**、**simulation**、**remote**、**legacy** です。</span><span class="sxs-lookup"><span data-stu-id="955bd-358">Possible values include **default**, **simulation**, **remote**, and **legacy**.</span></span> |

**<span data-ttu-id="955bd-359">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-359">Request headers</span></span>**

- <span data-ttu-id="955bd-360">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-360">None</span></span>

**<span data-ttu-id="955bd-361">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-361">Request body</span></span>**

- <span data-ttu-id="955bd-362">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-362">None</span></span>

**<span data-ttu-id="955bd-363">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-363">Response</span></span>**

- <span data-ttu-id="955bd-364">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-364">None</span></span>

**<span data-ttu-id="955bd-365">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-365">Status code</span></span>**

- <span data-ttu-id="955bd-366">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-366">Standard status codes.</span></span>

## <a name="hsimulation-playback"></a><span data-ttu-id="955bd-367">HSimulation の再生</span><span class="sxs-lookup"><span data-stu-id="955bd-367">HSimulation playback</span></span>

### <a name="delete-a-recording"></a><span data-ttu-id="955bd-368">レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="955bd-368">Delete a recording</span></span>

**<span data-ttu-id="955bd-369">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-369">Request</span></span>**

<span data-ttu-id="955bd-370">次の要求型式を使用して、レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-370">You can delete a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-371">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-371">Method</span></span>      | <span data-ttu-id="955bd-372">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-372">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-373">Del</span><span class="sxs-lookup"><span data-stu-id="955bd-373">DELETE</span></span> | <span data-ttu-id="955bd-374">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="955bd-374">/api/holographic/simulation/playback/file</span></span> |


**<span data-ttu-id="955bd-375">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-375">URI parameters</span></span>**

<span data-ttu-id="955bd-376">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-376">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-377">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-377">URI parameter</span></span> | <span data-ttu-id="955bd-378">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-378">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-379">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-379">recording</span></span>   | <span data-ttu-id="955bd-380">(**必須**) 削除するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-380">(**required**) The name of the recording to delete.</span></span> |

**<span data-ttu-id="955bd-381">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-381">Request headers</span></span>**

- <span data-ttu-id="955bd-382">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-382">None</span></span>

**<span data-ttu-id="955bd-383">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-383">Request body</span></span>**

- <span data-ttu-id="955bd-384">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-384">None</span></span>

**<span data-ttu-id="955bd-385">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-385">Response</span></span>**

- <span data-ttu-id="955bd-386">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-386">None</span></span>

**<span data-ttu-id="955bd-387">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-387">Status code</span></span>**

- <span data-ttu-id="955bd-388">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-388">Standard status codes.</span></span>

### <a name="get-all-recordings"></a><span data-ttu-id="955bd-389">すべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-389">Get all recordings</span></span>

**<span data-ttu-id="955bd-390">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-390">Request</span></span>**

<span data-ttu-id="955bd-391">次の要求形式を使用して、利用可能なすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-391">You can get all the available recordings by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-392">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-392">Method</span></span>      | <span data-ttu-id="955bd-393">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-393">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-394">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-394">GET</span></span> | <span data-ttu-id="955bd-395">/api/holographic/simulation/playback/files</span><span class="sxs-lookup"><span data-stu-id="955bd-395">/api/holographic/simulation/playback/files</span></span> |


**<span data-ttu-id="955bd-396">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-396">URI parameters</span></span>**

- <span data-ttu-id="955bd-397">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-397">None</span></span>

**<span data-ttu-id="955bd-398">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-398">Request headers</span></span>**

- <span data-ttu-id="955bd-399">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-399">None</span></span>

**<span data-ttu-id="955bd-400">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-400">Request body</span></span>**

- <span data-ttu-id="955bd-401">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-401">None</span></span>

**<span data-ttu-id="955bd-402">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-402">Response</span></span>**

- <span data-ttu-id="955bd-403">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-403">None</span></span>

**<span data-ttu-id="955bd-404">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-404">Status code</span></span>**

- <span data-ttu-id="955bd-405">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-405">Standard status codes.</span></span>

### <a name="get-the-types-of-data-in-a-loaded-recording"></a><span data-ttu-id="955bd-406">読み込まれたレコーディング内のデータの種類を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-406">Get the types of data in a loaded recording</span></span>

**<span data-ttu-id="955bd-407">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-407">Request</span></span>**

<span data-ttu-id="955bd-408">次の要求形式を使用して、読み込まれたレコーディング内のデータの種類を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-408">You can get the types of data in a loaded recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-409">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-409">Method</span></span>      | <span data-ttu-id="955bd-410">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-410">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-411">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-411">GET</span></span> | <span data-ttu-id="955bd-412">/api/holographic/simulation/playback/session/types</span><span class="sxs-lookup"><span data-stu-id="955bd-412">/api/holographic/simulation/playback/session/types</span></span> |


**<span data-ttu-id="955bd-413">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-413">URI parameters</span></span>**

<span data-ttu-id="955bd-414">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-414">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-415">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-415">URI parameter</span></span> | <span data-ttu-id="955bd-416">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-416">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-417">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-417">recording</span></span>   | <span data-ttu-id="955bd-418">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-418">(**required**) The name of the recording you are interested in.</span></span> |

**<span data-ttu-id="955bd-419">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-419">Request headers</span></span>**

- <span data-ttu-id="955bd-420">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-420">None</span></span>

**<span data-ttu-id="955bd-421">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-421">Request body</span></span>**

- <span data-ttu-id="955bd-422">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-422">None</span></span>

**<span data-ttu-id="955bd-423">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-423">Response</span></span>**

- <span data-ttu-id="955bd-424">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-424">None</span></span>

**<span data-ttu-id="955bd-425">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-425">Status code</span></span>**

- <span data-ttu-id="955bd-426">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-426">Standard status codes.</span></span>

### <a name="get-all-the-loaded-recordings"></a><span data-ttu-id="955bd-427">読み込まれたすべてのレコーディングを取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-427">Get all the loaded recordings</span></span>

**<span data-ttu-id="955bd-428">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-428">Request</span></span>**

<span data-ttu-id="955bd-429">次の要求形式を使用して、読み込まれたすべてのレコーディングを取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-429">You can get all the loaded recordings by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-430">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-430">Method</span></span>      | <span data-ttu-id="955bd-431">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-431">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-432">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-432">GET</span></span> | <span data-ttu-id="955bd-433">/api/holographic/simulation/playback/session/files</span><span class="sxs-lookup"><span data-stu-id="955bd-433">/api/holographic/simulation/playback/session/files</span></span> |


**<span data-ttu-id="955bd-434">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-434">URI parameters</span></span>**

- <span data-ttu-id="955bd-435">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-435">None</span></span>

**<span data-ttu-id="955bd-436">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-436">Request headers</span></span>**

- <span data-ttu-id="955bd-437">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-437">None</span></span>

**<span data-ttu-id="955bd-438">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-438">Request body</span></span>**

- <span data-ttu-id="955bd-439">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-439">None</span></span>

**<span data-ttu-id="955bd-440">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-440">Response</span></span>**

- <span data-ttu-id="955bd-441">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-441">None</span></span>

**<span data-ttu-id="955bd-442">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-442">Status code</span></span>**

- <span data-ttu-id="955bd-443">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-443">Standard status codes.</span></span>

### <a name="get-the-current-playback-state-of-a-recording"></a><span data-ttu-id="955bd-444">レコーディングの現在の再生状態を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-444">Get the current playback state of a recording</span></span> 

**<span data-ttu-id="955bd-445">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-445">Request</span></span>**

<span data-ttu-id="955bd-446">次の要求形式を使用して、レコーディングの現在の再生状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-446">You can get the current playback state of a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-447">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-447">Method</span></span>      | <span data-ttu-id="955bd-448">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-448">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-449">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-449">GET</span></span> | <span data-ttu-id="955bd-450">/api/holographic/simulation/playback/session</span><span class="sxs-lookup"><span data-stu-id="955bd-450">/api/holographic/simulation/playback/session</span></span> |


**<span data-ttu-id="955bd-451">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-451">URI parameters</span></span>**

<span data-ttu-id="955bd-452">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-452">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-453">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-453">URI parameter</span></span> | <span data-ttu-id="955bd-454">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-454">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-455">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-455">recording</span></span>   | <span data-ttu-id="955bd-456">(**必須**) 対象とするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-456">(**required**) The name of the recording that you are interested in.</span></span> |

**<span data-ttu-id="955bd-457">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-457">Request headers</span></span>**

- <span data-ttu-id="955bd-458">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-458">None</span></span>

**<span data-ttu-id="955bd-459">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-459">Request body</span></span>**

- <span data-ttu-id="955bd-460">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-460">None</span></span>

**<span data-ttu-id="955bd-461">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-461">Response</span></span>**

- <span data-ttu-id="955bd-462">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-462">None</span></span>

**<span data-ttu-id="955bd-463">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-463">Status code</span></span>**

- <span data-ttu-id="955bd-464">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-464">Standard status codes.</span></span>

### <a name="load-a-recording"></a><span data-ttu-id="955bd-465">レコーディングを読み込む</span><span class="sxs-lookup"><span data-stu-id="955bd-465">Load a recording</span></span>

**<span data-ttu-id="955bd-466">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-466">Request</span></span>**

<span data-ttu-id="955bd-467">次の要求形式を使用して、レコーディングを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="955bd-467">You can load a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-468">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-468">Method</span></span>      | <span data-ttu-id="955bd-469">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-469">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-470">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-470">POST</span></span> | <span data-ttu-id="955bd-471">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="955bd-471">/api/holographic/simulation/playback/session/file</span></span> |


**<span data-ttu-id="955bd-472">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-472">URI parameters</span></span>**

<span data-ttu-id="955bd-473">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-473">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-474">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-474">URI parameter</span></span> | <span data-ttu-id="955bd-475">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-475">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-476">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-476">recording</span></span>   | <span data-ttu-id="955bd-477">(**必須**) 読み込むレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-477">(**required**) The name of the recording to load.</span></span> |

**<span data-ttu-id="955bd-478">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-478">Request headers</span></span>**

- <span data-ttu-id="955bd-479">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-479">None</span></span>

**<span data-ttu-id="955bd-480">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-480">Request body</span></span>**

- <span data-ttu-id="955bd-481">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-481">None</span></span>

**<span data-ttu-id="955bd-482">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-482">Response</span></span>**

- <span data-ttu-id="955bd-483">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-483">None</span></span>

**<span data-ttu-id="955bd-484">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-484">Status code</span></span>**

- <span data-ttu-id="955bd-485">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-485">Standard status codes.</span></span>

### <a name="pause-a-recording"></a><span data-ttu-id="955bd-486">レコーディングを一時停止する</span><span class="sxs-lookup"><span data-stu-id="955bd-486">Pause a recording</span></span>

**<span data-ttu-id="955bd-487">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-487">Request</span></span>**

<span data-ttu-id="955bd-488">次の要求形式を使用して、レコーディングを一時停止できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-488">You can pause a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-489">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-489">Method</span></span>      | <span data-ttu-id="955bd-490">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-490">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-491">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-491">POST</span></span> | <span data-ttu-id="955bd-492">/api/holographic/simulation/playback/session/pause</span><span class="sxs-lookup"><span data-stu-id="955bd-492">/api/holographic/simulation/playback/session/pause</span></span> |


**<span data-ttu-id="955bd-493">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-493">URI parameters</span></span>**

<span data-ttu-id="955bd-494">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-494">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-495">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-495">URI parameter</span></span> | <span data-ttu-id="955bd-496">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-496">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-497">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-497">recording</span></span>   | <span data-ttu-id="955bd-498">(**必須**) 一時停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-498">(**required**) The name of the recording to pause.</span></span> |

**<span data-ttu-id="955bd-499">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-499">Request headers</span></span>**

- <span data-ttu-id="955bd-500">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-500">None</span></span>

**<span data-ttu-id="955bd-501">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-501">Request body</span></span>**

- <span data-ttu-id="955bd-502">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-502">None</span></span>

**<span data-ttu-id="955bd-503">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-503">Response</span></span>**

- <span data-ttu-id="955bd-504">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-504">None</span></span>

**<span data-ttu-id="955bd-505">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-505">Status code</span></span>**

- <span data-ttu-id="955bd-506">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-506">Standard status codes.</span></span>

### <a name="play-a-recording"></a><span data-ttu-id="955bd-507">レコーディングを再生する</span><span class="sxs-lookup"><span data-stu-id="955bd-507">Play a recording</span></span>

**<span data-ttu-id="955bd-508">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-508">Request</span></span>**

<span data-ttu-id="955bd-509">次の要求形式を使用して、レコーディングを再生できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-509">You can play a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-510">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-510">Method</span></span>      | <span data-ttu-id="955bd-511">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-511">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-512">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-512">POST</span></span> | <span data-ttu-id="955bd-513">/api/holographic/simulation/playback/session/play</span><span class="sxs-lookup"><span data-stu-id="955bd-513">/api/holographic/simulation/playback/session/play</span></span> |


**<span data-ttu-id="955bd-514">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-514">URI parameters</span></span>**

<span data-ttu-id="955bd-515">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-515">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-516">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-516">URI parameter</span></span> | <span data-ttu-id="955bd-517">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-517">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-518">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-518">recording</span></span>   | <span data-ttu-id="955bd-519">(**必須**) 再生するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-519">(**required**) The name of the recording to play.</span></span> |

**<span data-ttu-id="955bd-520">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-520">Request headers</span></span>**

- <span data-ttu-id="955bd-521">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-521">None</span></span>

**<span data-ttu-id="955bd-522">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-522">Request body</span></span>**

- <span data-ttu-id="955bd-523">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-523">None</span></span>

**<span data-ttu-id="955bd-524">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-524">Response</span></span>**

- <span data-ttu-id="955bd-525">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-525">None</span></span>

**<span data-ttu-id="955bd-526">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-526">Status code</span></span>**

- <span data-ttu-id="955bd-527">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-527">Standard status codes.</span></span>

### <a name="stop-a-recording"></a><span data-ttu-id="955bd-528">レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="955bd-528">Stop a recording</span></span>

**<span data-ttu-id="955bd-529">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-529">Request</span></span>**

<span data-ttu-id="955bd-530">次の要求形式を使用して、レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-530">You can stop a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-531">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-531">Method</span></span>      | <span data-ttu-id="955bd-532">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-532">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-533">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-533">POST</span></span> | <span data-ttu-id="955bd-534">/api/holographic/simulation/playback/session/stop</span><span class="sxs-lookup"><span data-stu-id="955bd-534">/api/holographic/simulation/playback/session/stop</span></span> |


**<span data-ttu-id="955bd-535">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-535">URI parameters</span></span>**

<span data-ttu-id="955bd-536">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-536">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-537">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-537">URI parameter</span></span> | <span data-ttu-id="955bd-538">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-538">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-539">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-539">recording</span></span>   | <span data-ttu-id="955bd-540">(**必須**) 停止するレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-540">(**required**) The name of the recording to stop.</span></span> |

**<span data-ttu-id="955bd-541">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-541">Request headers</span></span>**

- <span data-ttu-id="955bd-542">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-542">None</span></span>

**<span data-ttu-id="955bd-543">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-543">Request body</span></span>**

- <span data-ttu-id="955bd-544">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-544">None</span></span>

**<span data-ttu-id="955bd-545">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-545">Response</span></span>**

- <span data-ttu-id="955bd-546">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-546">None</span></span>

**<span data-ttu-id="955bd-547">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-547">Status code</span></span>**

- <span data-ttu-id="955bd-548">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-548">Standard status codes.</span></span>

### <a name="unload-a-recording"></a><span data-ttu-id="955bd-549">レコーディングをアンロードする</span><span class="sxs-lookup"><span data-stu-id="955bd-549">Unload a recording</span></span>

**<span data-ttu-id="955bd-550">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-550">Request</span></span>**

<span data-ttu-id="955bd-551">次の要求形式を使用して、レコーディングをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="955bd-551">You can unload a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-552">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-552">Method</span></span>      | <span data-ttu-id="955bd-553">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-553">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-554">Del</span><span class="sxs-lookup"><span data-stu-id="955bd-554">DELETE</span></span> | <span data-ttu-id="955bd-555">/api/holographic/simulation/playback/session/file</span><span class="sxs-lookup"><span data-stu-id="955bd-555">/api/holographic/simulation/playback/session/file</span></span> |


**<span data-ttu-id="955bd-556">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-556">URI parameters</span></span>**

<span data-ttu-id="955bd-557">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-557">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-558">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-558">URI parameter</span></span> | <span data-ttu-id="955bd-559">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-559">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-560">recording</span><span class="sxs-lookup"><span data-stu-id="955bd-560">recording</span></span>   | <span data-ttu-id="955bd-561">(**必須**) アンロードするレコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-561">(**required**) The name of the recording to unload.</span></span> |

**<span data-ttu-id="955bd-562">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-562">Request headers</span></span>**

- <span data-ttu-id="955bd-563">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-563">None</span></span>

**<span data-ttu-id="955bd-564">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-564">Request body</span></span>**

- <span data-ttu-id="955bd-565">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-565">None</span></span>

**<span data-ttu-id="955bd-566">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-566">Response</span></span>**

- <span data-ttu-id="955bd-567">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-567">None</span></span>

**<span data-ttu-id="955bd-568">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-568">Status code</span></span>**

- <span data-ttu-id="955bd-569">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-569">Standard status codes.</span></span>

### <a name="upload-a-recording"></a><span data-ttu-id="955bd-570">レコーディングをアップロードする</span><span class="sxs-lookup"><span data-stu-id="955bd-570">Upload a recording</span></span>

**<span data-ttu-id="955bd-571">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-571">Request</span></span>**

<span data-ttu-id="955bd-572">次の要求形式を使用して、レコーディングをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="955bd-572">You can upload a recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-573">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-573">Method</span></span>      | <span data-ttu-id="955bd-574">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-574">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-575">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-575">POST</span></span> | <span data-ttu-id="955bd-576">/api/holographic/simulation/playback/file</span><span class="sxs-lookup"><span data-stu-id="955bd-576">/api/holographic/simulation/playback/file</span></span> |


**<span data-ttu-id="955bd-577">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-577">URI parameters</span></span>**

- <span data-ttu-id="955bd-578">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-578">None</span></span>

**<span data-ttu-id="955bd-579">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-579">Request headers</span></span>**

- <span data-ttu-id="955bd-580">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-580">None</span></span>

**<span data-ttu-id="955bd-581">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-581">Request body</span></span>**

- <span data-ttu-id="955bd-582">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-582">None</span></span>

**<span data-ttu-id="955bd-583">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-583">Response</span></span>**

- <span data-ttu-id="955bd-584">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-584">None</span></span>

**<span data-ttu-id="955bd-585">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-585">Status code</span></span>**

- <span data-ttu-id="955bd-586">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-586">Standard status codes.</span></span>

## <a name="hsimulation-recording"></a><span data-ttu-id="955bd-587">HSimulation のレコーディング</span><span class="sxs-lookup"><span data-stu-id="955bd-587">HSimulation recording</span></span>

### <a name="get-the-recording-state"></a><span data-ttu-id="955bd-588">レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-588">Get the recording state</span></span>

**<span data-ttu-id="955bd-589">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-589">Request</span></span>**

<span data-ttu-id="955bd-590">次の要求形式を使用して、現在のレコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-590">You can get the current recording state by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-591">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-591">Method</span></span>      | <span data-ttu-id="955bd-592">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-592">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-593">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-593">GET</span></span> | <span data-ttu-id="955bd-594">/api/holographic/simulation/recording/status</span><span class="sxs-lookup"><span data-stu-id="955bd-594">/api/holographic/simulation/recording/status</span></span> |


**<span data-ttu-id="955bd-595">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-595">URI parameters</span></span>**

- <span data-ttu-id="955bd-596">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-596">None</span></span>

**<span data-ttu-id="955bd-597">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-597">Request headers</span></span>**

- <span data-ttu-id="955bd-598">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-598">None</span></span>

**<span data-ttu-id="955bd-599">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-599">Request body</span></span>**

- <span data-ttu-id="955bd-600">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-600">None</span></span>

**<span data-ttu-id="955bd-601">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-601">Response</span></span>**

- <span data-ttu-id="955bd-602">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-602">None</span></span>

**<span data-ttu-id="955bd-603">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-603">Status code</span></span>**

- <span data-ttu-id="955bd-604">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-604">Standard status codes.</span></span>

### <a name="start-a-recording"></a><span data-ttu-id="955bd-605">レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-605">Start a recording</span></span>

**<span data-ttu-id="955bd-606">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-606">Request</span></span>**

<span data-ttu-id="955bd-607">次の要求形式を使用して、レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-607">You can start a recording by using the following request format.</span></span> <span data-ttu-id="955bd-608">アクティブにできるレコーディングは一度に 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="955bd-608">There can only be one active recording at a time.</span></span> 
 
| <span data-ttu-id="955bd-609">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-609">Method</span></span>      | <span data-ttu-id="955bd-610">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-610">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-611">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-611">POST</span></span> | <span data-ttu-id="955bd-612">/api/holographic/simulation/recording/start</span><span class="sxs-lookup"><span data-stu-id="955bd-612">/api/holographic/simulation/recording/start</span></span> |


**<span data-ttu-id="955bd-613">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-613">URI parameters</span></span>**

<span data-ttu-id="955bd-614">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-614">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-615">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-615">URI parameter</span></span> | <span data-ttu-id="955bd-616">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-616">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-617">head</span><span class="sxs-lookup"><span data-stu-id="955bd-617">head</span></span>   | <span data-ttu-id="955bd-618">(**下記参照**) システムで頭部のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-618">(**see below**) Set this value to 1 to indicate the system should record head data.</span></span> |
| <span data-ttu-id="955bd-619">hands</span><span class="sxs-lookup"><span data-stu-id="955bd-619">hands</span></span>   | <span data-ttu-id="955bd-620">(**下記参照**) システムで手のデータを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-620">(**see below**) Set this value to 1 to indicate the system should record hands data.</span></span> |
| <span data-ttu-id="955bd-621">spatialMapping</span><span class="sxs-lookup"><span data-stu-id="955bd-621">spatialMapping</span></span>   | <span data-ttu-id="955bd-622">(**下記参照**) システムで空間マッピング データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-622">(**see below**) Set this value to 1 to indicate the system should record spatial mapping data.</span></span> |
| <span data-ttu-id="955bd-623">environment</span><span class="sxs-lookup"><span data-stu-id="955bd-623">environment</span></span>   | <span data-ttu-id="955bd-624">(**下記参照**) システムで環境データを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-624">(**see below**) Set this value to 1 to indicate the system should record environment data.</span></span> |
| <span data-ttu-id="955bd-625">name</span><span class="sxs-lookup"><span data-stu-id="955bd-625">name</span></span>   | <span data-ttu-id="955bd-626">(**必須**) レコーディングの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-626">(**required**) The name of the recording.</span></span> |
| <span data-ttu-id="955bd-627">singleSpatialMappingFrame</span><span class="sxs-lookup"><span data-stu-id="955bd-627">singleSpatialMappingFrame</span></span>   | <span data-ttu-id="955bd-628">(**省略可能**) 単一の空間マッピング フレームのみを記録する必要があることを示すには、この値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-628">(**optional**) Set this value to 1 to indicate that only a single sptial mapping frame should be recorded.</span></span> |

<span data-ttu-id="955bd-629">これらのパラメーターについては、*head*、*hands*、*spatialMapping*、*environment* のいずれか 1 つだけを 1 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-629">For these parameters, exactly one of the following parameters must be set to 1: *head*, *hands*, *spatialMapping*, or *environment*.</span></span>

**<span data-ttu-id="955bd-630">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-630">Request headers</span></span>**

- <span data-ttu-id="955bd-631">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-631">None</span></span>

**<span data-ttu-id="955bd-632">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-632">Request body</span></span>**

- <span data-ttu-id="955bd-633">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-633">None</span></span>

**<span data-ttu-id="955bd-634">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-634">Response</span></span>**

- <span data-ttu-id="955bd-635">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-635">None</span></span>

**<span data-ttu-id="955bd-636">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-636">Status code</span></span>**

- <span data-ttu-id="955bd-637">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-637">Standard status codes.</span></span>

### <a name="stop-the-current-recording"></a><span data-ttu-id="955bd-638">現在のレコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="955bd-638">Stop the current recording</span></span>

**<span data-ttu-id="955bd-639">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-639">Request</span></span>**

<span data-ttu-id="955bd-640">次の要求形式を使用して、現在のレコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-640">You can stop the current recording by using the following request format.</span></span> <span data-ttu-id="955bd-641">レコーディングはファイルとして返されます。</span><span class="sxs-lookup"><span data-stu-id="955bd-641">The recording will be returned as a file.</span></span>
 
| <span data-ttu-id="955bd-642">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-642">Method</span></span>      | <span data-ttu-id="955bd-643">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-643">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-644">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-644">POST</span></span> | <span data-ttu-id="955bd-645">/api/holographic/simulation/recording/stop</span><span class="sxs-lookup"><span data-stu-id="955bd-645">/api/holographic/simulation/recording/stop</span></span> |


**<span data-ttu-id="955bd-646">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-646">URI parameters</span></span>**

- <span data-ttu-id="955bd-647">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-647">None</span></span>

**<span data-ttu-id="955bd-648">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-648">Request headers</span></span>**

- <span data-ttu-id="955bd-649">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-649">None</span></span>

**<span data-ttu-id="955bd-650">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-650">Request body</span></span>**

- <span data-ttu-id="955bd-651">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-651">None</span></span>

**<span data-ttu-id="955bd-652">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-652">Response</span></span>**

- <span data-ttu-id="955bd-653">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-653">None</span></span>

**<span data-ttu-id="955bd-654">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-654">Status code</span></span>**

- <span data-ttu-id="955bd-655">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-655">Standard status codes.</span></span>

## <a name="mixed-reality-capture"></a><span data-ttu-id="955bd-656">複合現実キャプチャ</span><span class="sxs-lookup"><span data-stu-id="955bd-656">Mixed reality capture</span></span>

### <a name="delete-a-mixed-reality-capture-mrc-recording-from-the-device"></a><span data-ttu-id="955bd-657">デバイスから Mixed Reality キャプチャ (MRC) レコーディングを削除する</span><span class="sxs-lookup"><span data-stu-id="955bd-657">Delete a mixed reality capture (MRC) recording from the device</span></span>

**<span data-ttu-id="955bd-658">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-658">Request</span></span>**

<span data-ttu-id="955bd-659">次の要求形式を使用して、MRC レコーディングを削除できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-659">You can delete an MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-660">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-660">Method</span></span>      | <span data-ttu-id="955bd-661">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-661">Request URI</span></span> |
| :------     | :----- |
<span data-ttu-id="955bd-662">Del</span><span class="sxs-lookup"><span data-stu-id="955bd-662">DELETE</span></span> | <span data-ttu-id="955bd-663">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="955bd-663">/api/holographic/mrc/file</span></span> |


**<span data-ttu-id="955bd-664">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-664">URI parameters</span></span>**

<span data-ttu-id="955bd-665">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-665">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-666">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-666">URI parameter</span></span> | <span data-ttu-id="955bd-667">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-667">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-668">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="955bd-668">filename</span></span>   | <span data-ttu-id="955bd-669">(**必須**) 削除するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-669">(**required**) The name of the video file to delete.</span></span> <span data-ttu-id="955bd-670">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-670">The name should be hex64 encoded.</span></span> |

**<span data-ttu-id="955bd-671">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-671">Request headers</span></span>**

- <span data-ttu-id="955bd-672">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-672">None</span></span>

**<span data-ttu-id="955bd-673">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-673">Request body</span></span>**

- <span data-ttu-id="955bd-674">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-674">None</span></span>

**<span data-ttu-id="955bd-675">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-675">Response</span></span>**

- <span data-ttu-id="955bd-676">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-676">None</span></span>

**<span data-ttu-id="955bd-677">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-677">Status code</span></span>**

- <span data-ttu-id="955bd-678">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-678">Standard status codes.</span></span>

### <a name="download-a-mixed-reality-capture-mrc-file"></a><span data-ttu-id="955bd-679">Mixed Reality キャプチャ (MRC) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="955bd-679">Download a mixed reality capture (MRC) file</span></span>

**<span data-ttu-id="955bd-680">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-680">Request</span></span>**

<span data-ttu-id="955bd-681">次の要求形式を使用して、デバイスから MRC ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="955bd-681">You can download an MRC file from the device by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-682">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-682">Method</span></span>      | <span data-ttu-id="955bd-683">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-683">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-684">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-684">GET</span></span> | <span data-ttu-id="955bd-685">/api/holographic/mrc/file</span><span class="sxs-lookup"><span data-stu-id="955bd-685">/api/holographic/mrc/file</span></span> |


**<span data-ttu-id="955bd-686">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-686">URI parameters</span></span>**

<span data-ttu-id="955bd-687">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-687">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-688">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-688">URI parameter</span></span> | <span data-ttu-id="955bd-689">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-689">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-690">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="955bd-690">filename</span></span>   | <span data-ttu-id="955bd-691">(**必須**) 取得するビデオ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="955bd-691">(**required**) The name of the video file you want to get.</span></span> <span data-ttu-id="955bd-692">この名前は hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-692">The name should be hex64 encoded.</span></span> |
| <span data-ttu-id="955bd-693">op</span><span class="sxs-lookup"><span data-stu-id="955bd-693">op</span></span>   | <span data-ttu-id="955bd-694">(**省略可能**) ストリームをダウンロードする場合は、この値を **stream** に設定します。</span><span class="sxs-lookup"><span data-stu-id="955bd-694">(**optional**) Set this value to **stream** if you want to download a stream.</span></span> |

**<span data-ttu-id="955bd-695">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-695">Request headers</span></span>**

- <span data-ttu-id="955bd-696">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-696">None</span></span>

**<span data-ttu-id="955bd-697">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-697">Request body</span></span>**

- <span data-ttu-id="955bd-698">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-698">None</span></span>

**<span data-ttu-id="955bd-699">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-699">Response</span></span>**

- <span data-ttu-id="955bd-700">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-700">None</span></span>

**<span data-ttu-id="955bd-701">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-701">Status code</span></span>**

- <span data-ttu-id="955bd-702">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-702">Standard status codes.</span></span>

### <a name="get-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="955bd-703">Mixed Reality キャプチャ (MRC) の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-703">Get the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="955bd-704">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-704">Request</span></span>**

<span data-ttu-id="955bd-705">次の要求形式を使用して、MRC の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-705">You can get the MRC settings by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-706">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-706">Method</span></span>      | <span data-ttu-id="955bd-707">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-707">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-708">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-708">GET</span></span> | <span data-ttu-id="955bd-709">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="955bd-709">/api/holographic/mrc/settings</span></span> |


**<span data-ttu-id="955bd-710">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-710">URI parameters</span></span>**

- <span data-ttu-id="955bd-711">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-711">None</span></span>

**<span data-ttu-id="955bd-712">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-712">Request headers</span></span>**

- <span data-ttu-id="955bd-713">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-713">None</span></span>

**<span data-ttu-id="955bd-714">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-714">Request body</span></span>**

- <span data-ttu-id="955bd-715">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-715">None</span></span>

**<span data-ttu-id="955bd-716">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-716">Response</span></span>**

- <span data-ttu-id="955bd-717">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-717">None</span></span>

**<span data-ttu-id="955bd-718">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-718">Status code</span></span>**

- <span data-ttu-id="955bd-719">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-719">Standard status codes.</span></span>

### <a name="get-the-status-of-the-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="955bd-720">Mixed Reality キャプチャ (MRC) レコーディングの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-720">Get the status of the mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="955bd-721">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-721">Request</span></span>**

<span data-ttu-id="955bd-722">次の要求形式を使用して、MRC レコーディングの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-722">You can get the MRC recording status by using the following request format.</span></span> <span data-ttu-id="955bd-723">返される可能性のある値は、**running** と **stopped** です。</span><span class="sxs-lookup"><span data-stu-id="955bd-723">The possible values include **running** and **stopped**.</span></span>
 
| <span data-ttu-id="955bd-724">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-724">Method</span></span>      | <span data-ttu-id="955bd-725">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-725">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-726">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-726">GET</span></span> | <span data-ttu-id="955bd-727">/api/holographic/mrc/status</span><span class="sxs-lookup"><span data-stu-id="955bd-727">/api/holographic/mrc/status</span></span> |


**<span data-ttu-id="955bd-728">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-728">URI parameters</span></span>**

- <span data-ttu-id="955bd-729">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-729">None</span></span>

**<span data-ttu-id="955bd-730">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-730">Request headers</span></span>**

- <span data-ttu-id="955bd-731">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-731">None</span></span>

**<span data-ttu-id="955bd-732">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-732">Request body</span></span>**

- <span data-ttu-id="955bd-733">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-733">None</span></span>

**<span data-ttu-id="955bd-734">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-734">Response</span></span>**

- <span data-ttu-id="955bd-735">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-735">None</span></span>

**<span data-ttu-id="955bd-736">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-736">Status code</span></span>**

- <span data-ttu-id="955bd-737">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-737">Standard status codes.</span></span>

### <a name="get-the-list-of-mixed-reality-capture-mrc-files"></a><span data-ttu-id="955bd-738">Mixed Reality キャプチャ (MRC) ファイルのリストを取得する</span><span class="sxs-lookup"><span data-stu-id="955bd-738">Get the list of mixed reality capture (MRC) files</span></span>

**<span data-ttu-id="955bd-739">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-739">Request</span></span>**

<span data-ttu-id="955bd-740">次の要求形式を使用して、デバイスに保存されている MRC ファイルを取得できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-740">You can get the MRC files stored on the device by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-741">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-741">Method</span></span>      | <span data-ttu-id="955bd-742">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-742">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-743">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-743">GET</span></span> | <span data-ttu-id="955bd-744">/api/holographic/mrc/files</span><span class="sxs-lookup"><span data-stu-id="955bd-744">/api/holographic/mrc/files</span></span> |


**<span data-ttu-id="955bd-745">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-745">URI parameters</span></span>**

- <span data-ttu-id="955bd-746">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-746">None</span></span>

**<span data-ttu-id="955bd-747">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-747">Request headers</span></span>**

- <span data-ttu-id="955bd-748">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-748">None</span></span>

**<span data-ttu-id="955bd-749">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-749">Request body</span></span>**

- <span data-ttu-id="955bd-750">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-750">None</span></span>

**<span data-ttu-id="955bd-751">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-751">Response</span></span>**

- <span data-ttu-id="955bd-752">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-752">None</span></span>

**<span data-ttu-id="955bd-753">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-753">Status code</span></span>**

- <span data-ttu-id="955bd-754">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-754">Standard status codes.</span></span>

### <a name="set-the-mixed-reality-capture-mrc-settings"></a><span data-ttu-id="955bd-755">Mixed Reality キャプチャ (MRC) の設定を行う</span><span class="sxs-lookup"><span data-stu-id="955bd-755">Set the mixed reality capture (MRC) settings</span></span>

**<span data-ttu-id="955bd-756">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-756">Request</span></span>**

<span data-ttu-id="955bd-757">次の要求形式を使用して、MRC の設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="955bd-757">You can set the MRC settings by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-758">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-758">Method</span></span>      | <span data-ttu-id="955bd-759">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-759">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-760">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-760">POST</span></span> | <span data-ttu-id="955bd-761">/api/holographic/mrc/settings</span><span class="sxs-lookup"><span data-stu-id="955bd-761">/api/holographic/mrc/settings</span></span> |


**<span data-ttu-id="955bd-762">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-762">URI parameters</span></span>**

- <span data-ttu-id="955bd-763">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-763">None</span></span>

**<span data-ttu-id="955bd-764">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-764">Request headers</span></span>**

- <span data-ttu-id="955bd-765">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-765">None</span></span>

**<span data-ttu-id="955bd-766">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-766">Request body</span></span>**

- <span data-ttu-id="955bd-767">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-767">None</span></span>

**<span data-ttu-id="955bd-768">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-768">Response</span></span>**

- <span data-ttu-id="955bd-769">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-769">None</span></span>

**<span data-ttu-id="955bd-770">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-770">Status code</span></span>**

- <span data-ttu-id="955bd-771">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-771">Standard status codes.</span></span>

### <a name="starts-a-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="955bd-772">Mixed Reality キャプチャ (MRC) レコーディングを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-772">Starts a mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="955bd-773">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-773">Request</span></span>**

<span data-ttu-id="955bd-774">次の要求形式を使用して、MRC レコーディングを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-774">You can start an MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-775">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-775">Method</span></span>      | <span data-ttu-id="955bd-776">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-776">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-777">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-777">POST</span></span> | <span data-ttu-id="955bd-778">/api/holographic/mrc/video/control/start</span><span class="sxs-lookup"><span data-stu-id="955bd-778">/api/holographic/mrc/video/control/start</span></span> |


**<span data-ttu-id="955bd-779">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-779">URI parameters</span></span>**

- <span data-ttu-id="955bd-780">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-780">None</span></span>

**<span data-ttu-id="955bd-781">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-781">Request headers</span></span>**

- <span data-ttu-id="955bd-782">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-782">None</span></span>

**<span data-ttu-id="955bd-783">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-783">Request body</span></span>**

- <span data-ttu-id="955bd-784">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-784">None</span></span>

**<span data-ttu-id="955bd-785">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-785">Response</span></span>**

- <span data-ttu-id="955bd-786">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-786">None</span></span>

**<span data-ttu-id="955bd-787">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-787">Status code</span></span>**

- <span data-ttu-id="955bd-788">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-788">Standard status codes.</span></span>

### <a name="stop-the-current-mixed-reality-capture-mrc-recording"></a><span data-ttu-id="955bd-789">現在の Mixed Reality キャプチャ (MRC) レコーディングを停止する</span><span class="sxs-lookup"><span data-stu-id="955bd-789">Stop the current mixed reality capture (MRC) recording</span></span>

**<span data-ttu-id="955bd-790">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-790">Request</span></span>**

<span data-ttu-id="955bd-791">次の要求形式を使用して、現在の MRC レコーディングを停止できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-791">You can stop the current MRC recording by using the following request format.</span></span>
 
| <span data-ttu-id="955bd-792">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-792">Method</span></span>      | <span data-ttu-id="955bd-793">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-793">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-794">POST</span><span class="sxs-lookup"><span data-stu-id="955bd-794">POST</span></span> | <span data-ttu-id="955bd-795">/api/holographic/mrc/video/control/stop</span><span class="sxs-lookup"><span data-stu-id="955bd-795">/api/holographic/mrc/video/control/stop</span></span> |


**<span data-ttu-id="955bd-796">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-796">URI parameters</span></span>**

- <span data-ttu-id="955bd-797">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-797">None</span></span>

**<span data-ttu-id="955bd-798">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-798">Request headers</span></span>**

- <span data-ttu-id="955bd-799">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-799">None</span></span>

**<span data-ttu-id="955bd-800">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-800">Request body</span></span>**

- <span data-ttu-id="955bd-801">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-801">None</span></span>

**<span data-ttu-id="955bd-802">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-802">Response</span></span>**

- <span data-ttu-id="955bd-803">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-803">None</span></span>

**<span data-ttu-id="955bd-804">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-804">Status code</span></span>**

- <span data-ttu-id="955bd-805">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-805">Standard status codes.</span></span>

### <a name="take-a-mixed-reality-capture-mrc-photo"></a><span data-ttu-id="955bd-806">Mixed Reality キャプチャ (MRC) の写真を撮る</span><span class="sxs-lookup"><span data-stu-id="955bd-806">Take a mixed reality capture (MRC) photo</span></span>

**<span data-ttu-id="955bd-807">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-807">Request</span></span>**

<span data-ttu-id="955bd-808">次の要求形式を使用して、MRC の写真を撮ることができます。</span><span class="sxs-lookup"><span data-stu-id="955bd-808">You can take an MRC photo by using the following request format.</span></span> <span data-ttu-id="955bd-809">写真は JPEG 形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="955bd-809">The photo is returned in JPEG format.</span></span>
 
| <span data-ttu-id="955bd-810">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-810">Method</span></span>      | <span data-ttu-id="955bd-811">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-811">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-812">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-812">GET</span></span> | <span data-ttu-id="955bd-813">/api/holographic/mrc/photo</span><span class="sxs-lookup"><span data-stu-id="955bd-813">/api/holographic/mrc/photo</span></span> |


**<span data-ttu-id="955bd-814">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-814">URI parameters</span></span>**

- <span data-ttu-id="955bd-815">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-815">None</span></span>

**<span data-ttu-id="955bd-816">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-816">Request headers</span></span>**

- <span data-ttu-id="955bd-817">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-817">None</span></span>

**<span data-ttu-id="955bd-818">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-818">Request body</span></span>**

- <span data-ttu-id="955bd-819">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-819">None</span></span>

**<span data-ttu-id="955bd-820">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-820">Response</span></span>**

- <span data-ttu-id="955bd-821">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-821">None</span></span>

**<span data-ttu-id="955bd-822">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-822">Status code</span></span>**

- <span data-ttu-id="955bd-823">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-823">Standard status codes.</span></span>

## <a name="mixed-reality-streaming"></a><span data-ttu-id="955bd-824">複合現実のストリーミング</span><span class="sxs-lookup"><span data-stu-id="955bd-824">Mixed reality streaming</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="955bd-825">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-825">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="955bd-826">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-826">Request</span></span>**

<span data-ttu-id="955bd-827">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-827">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="955bd-828">この API では既定の品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="955bd-828">This API uses the default quality.</span></span>
 
| <span data-ttu-id="955bd-829">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-829">Method</span></span>      | <span data-ttu-id="955bd-830">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-830">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-831">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-831">GET</span></span> | <span data-ttu-id="955bd-832">/api/holographic/stream/live.mp4</span><span class="sxs-lookup"><span data-stu-id="955bd-832">/api/holographic/stream/live.mp4</span></span> |


**<span data-ttu-id="955bd-833">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-833">URI parameters</span></span>**

<span data-ttu-id="955bd-834">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-834">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-835">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-835">URI parameter</span></span> | <span data-ttu-id="955bd-836">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-836">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-837">pv</span><span class="sxs-lookup"><span data-stu-id="955bd-837">pv</span></span>   | <span data-ttu-id="955bd-838">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-838">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="955bd-839">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-839">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-840">holo</span><span class="sxs-lookup"><span data-stu-id="955bd-840">holo</span></span>   | <span data-ttu-id="955bd-841">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-841">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="955bd-842">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-842">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-843">mic</span><span class="sxs-lookup"><span data-stu-id="955bd-843">mic</span></span>   | <span data-ttu-id="955bd-844">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-844">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="955bd-845">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-845">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-846">loopback</span><span class="sxs-lookup"><span data-stu-id="955bd-846">loopback</span></span>   | <span data-ttu-id="955bd-847">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-847">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="955bd-848">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-848">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="955bd-849">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-849">Request headers</span></span>**

- <span data-ttu-id="955bd-850">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-850">None</span></span>

**<span data-ttu-id="955bd-851">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-851">Request body</span></span>**

- <span data-ttu-id="955bd-852">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-852">None</span></span>

**<span data-ttu-id="955bd-853">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-853">Response</span></span>**

- <span data-ttu-id="955bd-854">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-854">None</span></span>

**<span data-ttu-id="955bd-855">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-855">Status code</span></span>**

- <span data-ttu-id="955bd-856">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-856">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="955bd-857">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-857">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="955bd-858">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-858">Request</span></span>**

<span data-ttu-id="955bd-859">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-859">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="955bd-860">この API では高品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="955bd-860">This API uses the high quality.</span></span>
 
| <span data-ttu-id="955bd-861">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-861">Method</span></span>      | <span data-ttu-id="955bd-862">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-862">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-863">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-863">GET</span></span> | <span data-ttu-id="955bd-864">/api/holographic/stream/live_high.mp4</span><span class="sxs-lookup"><span data-stu-id="955bd-864">/api/holographic/stream/live_high.mp4</span></span> |


**<span data-ttu-id="955bd-865">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-865">URI parameters</span></span>**

<span data-ttu-id="955bd-866">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-866">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-867">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-867">URI parameter</span></span> | <span data-ttu-id="955bd-868">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-868">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-869">pv</span><span class="sxs-lookup"><span data-stu-id="955bd-869">pv</span></span>   | <span data-ttu-id="955bd-870">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-870">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="955bd-871">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-871">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-872">holo</span><span class="sxs-lookup"><span data-stu-id="955bd-872">holo</span></span>   | <span data-ttu-id="955bd-873">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-873">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="955bd-874">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-874">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-875">mic</span><span class="sxs-lookup"><span data-stu-id="955bd-875">mic</span></span>   | <span data-ttu-id="955bd-876">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-876">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="955bd-877">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-877">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-878">loopback</span><span class="sxs-lookup"><span data-stu-id="955bd-878">loopback</span></span>   | <span data-ttu-id="955bd-879">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-879">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="955bd-880">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-880">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="955bd-881">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-881">Request headers</span></span>**

- <span data-ttu-id="955bd-882">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-882">None</span></span>

**<span data-ttu-id="955bd-883">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-883">Request body</span></span>**

- <span data-ttu-id="955bd-884">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-884">None</span></span>

**<span data-ttu-id="955bd-885">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-885">Response</span></span>**

- <span data-ttu-id="955bd-886">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-886">None</span></span>

**<span data-ttu-id="955bd-887">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-887">Status code</span></span>**

- <span data-ttu-id="955bd-888">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-888">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="955bd-889">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-889">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="955bd-890">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-890">Request</span></span>**

<span data-ttu-id="955bd-891">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-891">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="955bd-892">この API では低品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="955bd-892">This API uses the low quality.</span></span>
 
| <span data-ttu-id="955bd-893">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-893">Method</span></span>      | <span data-ttu-id="955bd-894">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-894">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-895">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-895">GET</span></span> | <span data-ttu-id="955bd-896">/api/holographic/stream/live_low.mp4</span><span class="sxs-lookup"><span data-stu-id="955bd-896">/api/holographic/stream/live_low.mp4</span></span> |


**<span data-ttu-id="955bd-897">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-897">URI parameters</span></span>**

<span data-ttu-id="955bd-898">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-898">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-899">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-899">URI parameter</span></span> | <span data-ttu-id="955bd-900">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-900">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-901">pv</span><span class="sxs-lookup"><span data-stu-id="955bd-901">pv</span></span>   | <span data-ttu-id="955bd-902">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-902">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="955bd-903">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-903">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-904">holo</span><span class="sxs-lookup"><span data-stu-id="955bd-904">holo</span></span>   | <span data-ttu-id="955bd-905">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-905">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="955bd-906">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-906">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-907">mic</span><span class="sxs-lookup"><span data-stu-id="955bd-907">mic</span></span>   | <span data-ttu-id="955bd-908">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-908">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="955bd-909">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-909">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-910">loopback</span><span class="sxs-lookup"><span data-stu-id="955bd-910">loopback</span></span>   | <span data-ttu-id="955bd-911">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-911">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="955bd-912">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-912">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="955bd-913">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-913">Request headers</span></span>**

- <span data-ttu-id="955bd-914">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-914">None</span></span>

**<span data-ttu-id="955bd-915">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-915">Request body</span></span>**

- <span data-ttu-id="955bd-916">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-916">None</span></span>

**<span data-ttu-id="955bd-917">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-917">Response</span></span>**

- <span data-ttu-id="955bd-918">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-918">None</span></span>

**<span data-ttu-id="955bd-919">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-919">Status code</span></span>**

- <span data-ttu-id="955bd-920">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-920">Standard status codes.</span></span>

### <a name="initiates-a-chunked-download-of-a-fragmented-mp4"></a><span data-ttu-id="955bd-921">フラグメント化 mp4 のチャンク ダウンロードを開始する</span><span class="sxs-lookup"><span data-stu-id="955bd-921">Initiates a chunked download of a fragmented mp4</span></span>

**<span data-ttu-id="955bd-922">要求</span><span class="sxs-lookup"><span data-stu-id="955bd-922">Request</span></span>**

<span data-ttu-id="955bd-923">次の要求型式を使用して、フラグメント化 mp4 のチャンク ダウンロードを開始できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-923">You can initiate a chunked download of a fragmented mp4 by using the following request format.</span></span> <span data-ttu-id="955bd-924">この API では中品質が使われます。</span><span class="sxs-lookup"><span data-stu-id="955bd-924">This API uses the medium quality.</span></span>
 
| <span data-ttu-id="955bd-925">メソッド</span><span class="sxs-lookup"><span data-stu-id="955bd-925">Method</span></span>      | <span data-ttu-id="955bd-926">要求 URI</span><span class="sxs-lookup"><span data-stu-id="955bd-926">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="955bd-927">GET</span><span class="sxs-lookup"><span data-stu-id="955bd-927">GET</span></span> | <span data-ttu-id="955bd-928">/api/holographic/stream/live_med.mp4</span><span class="sxs-lookup"><span data-stu-id="955bd-928">/api/holographic/stream/live_med.mp4</span></span> |


**<span data-ttu-id="955bd-929">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-929">URI parameters</span></span>**

<span data-ttu-id="955bd-930">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="955bd-930">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="955bd-931">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="955bd-931">URI parameter</span></span> | <span data-ttu-id="955bd-932">説明</span><span class="sxs-lookup"><span data-stu-id="955bd-932">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="955bd-933">pv</span><span class="sxs-lookup"><span data-stu-id="955bd-933">pv</span></span>   | <span data-ttu-id="955bd-934">(**省略可能**) PV カメラをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-934">(**optional**) Indiates whether to capture the PV camera.</span></span> <span data-ttu-id="955bd-935">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-935">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-936">holo</span><span class="sxs-lookup"><span data-stu-id="955bd-936">holo</span></span>   | <span data-ttu-id="955bd-937">(**省略可能**) ホログラムをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-937">(**optional**) Indiates whether to capture holograms.</span></span> <span data-ttu-id="955bd-938">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-938">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-939">mic</span><span class="sxs-lookup"><span data-stu-id="955bd-939">mic</span></span>   | <span data-ttu-id="955bd-940">(**省略可能**) マイクをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-940">(**optional**) Indiates whether to capture the microphone.</span></span> <span data-ttu-id="955bd-941">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-941">Should be **true** or **false**.</span></span> |
| <span data-ttu-id="955bd-942">loopback</span><span class="sxs-lookup"><span data-stu-id="955bd-942">loopback</span></span>   | <span data-ttu-id="955bd-943">(**省略可能**) アプリケーション オーディオをキャプチャするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="955bd-943">(**optional**) Indiates whether to capture the application audio.</span></span> <span data-ttu-id="955bd-944">**true** または **false** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="955bd-944">Should be **true** or **false**.</span></span> |

**<span data-ttu-id="955bd-945">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="955bd-945">Request headers</span></span>**

- <span data-ttu-id="955bd-946">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-946">None</span></span>

**<span data-ttu-id="955bd-947">要求本文</span><span class="sxs-lookup"><span data-stu-id="955bd-947">Request body</span></span>**

- <span data-ttu-id="955bd-948">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-948">None</span></span>

**<span data-ttu-id="955bd-949">応答</span><span class="sxs-lookup"><span data-stu-id="955bd-949">Response</span></span>**

- <span data-ttu-id="955bd-950">なし</span><span class="sxs-lookup"><span data-stu-id="955bd-950">None</span></span>

**<span data-ttu-id="955bd-951">状態コード</span><span class="sxs-lookup"><span data-stu-id="955bd-951">Status code</span></span>**

- <span data-ttu-id="955bd-952">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="955bd-952">Standard status codes.</span></span>
