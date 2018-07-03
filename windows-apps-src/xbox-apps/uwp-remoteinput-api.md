---
author: WilliamsJason
title: Device Portal リモコン入力 API リファレンス
description: Xbox でコントローラー、キーボード、およびマウス入力をリモートで送信する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: a2217b87d840bc95010e2e1ce47ea72e991e8fa3
ms.sourcegitcommit: c104b653601d9b81cfc8bb6032ca434cff8fe9b1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/25/2018
ms.locfileid: "1921264"
---
# <a name="remote-input-api-reference"></a><span data-ttu-id="4a156-103">リモート入力 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="4a156-103">Remote Input API reference</span></span>   
<span data-ttu-id="4a156-104">この API を介してリモートからリアルタイムでコントローラー、キーボード、およびマウス入力を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="4a156-104">You can send controller, keyboard, and mouse input in real time remotely via this API.</span></span>

**<span data-ttu-id="4a156-105">要求</span><span class="sxs-lookup"><span data-stu-id="4a156-105">Request</span></span>**

<span data-ttu-id="4a156-106">メソッド</span><span class="sxs-lookup"><span data-stu-id="4a156-106">Method</span></span>      | <span data-ttu-id="4a156-107">要求 URI</span><span class="sxs-lookup"><span data-stu-id="4a156-107">Request URI</span></span>
:------     | :-----
<span data-ttu-id="4a156-108">WebSocket</span><span class="sxs-lookup"><span data-stu-id="4a156-108">Websocket</span></span> | <span data-ttu-id="4a156-109">/ext/remoteinput</span><span class="sxs-lookup"><span data-stu-id="4a156-109">/ext/remoteinput</span></span>
<br />
**<span data-ttu-id="4a156-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4a156-110">URI parameters</span></span>**

- <span data-ttu-id="4a156-111">なし</span><span class="sxs-lookup"><span data-stu-id="4a156-111">None</span></span>

**<span data-ttu-id="4a156-112">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4a156-112">Request headers</span></span>**

- <span data-ttu-id="4a156-113">なし</span><span class="sxs-lookup"><span data-stu-id="4a156-113">None</span></span>

**<span data-ttu-id="4a156-114">要求</span><span class="sxs-lookup"><span data-stu-id="4a156-114">Request</span></span>**

<span data-ttu-id="4a156-115">一連のバイト配列メッセージの websocket です。</span><span class="sxs-lookup"><span data-stu-id="4a156-115">The websocket a series of byte array messages.</span></span> <span data-ttu-id="4a156-116">各メッセージについて、形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4a156-116">For each message the format is as follows.</span></span>

<span data-ttu-id="4a156-117">最初のバイトは、入力タイプを示します。</span><span class="sxs-lookup"><span data-stu-id="4a156-117">The first byte indicates the input type.</span></span> <span data-ttu-id="4a156-118">次の入力タイプがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="4a156-118">The following input types are supported:</span></span>

| <span data-ttu-id="4a156-119">入力タイプ</span><span class="sxs-lookup"><span data-stu-id="4a156-119">Input Type</span></span>        | <span data-ttu-id="4a156-120">バイト値</span><span class="sxs-lookup"><span data-stu-id="4a156-120">Byte Value</span></span> |
|------------|-------------|
<span data-ttu-id="4a156-121">キーボード キーコード</span><span class="sxs-lookup"><span data-stu-id="4a156-121">Keyboard KeyCodes</span></span> | <span data-ttu-id="4a156-122">0x01</span><span class="sxs-lookup"><span data-stu-id="4a156-122">0x01</span></span>
<span data-ttu-id="4a156-123">キーボード スキャンコード</span><span class="sxs-lookup"><span data-stu-id="4a156-123">Keyboard ScanCodes</span></span> | <span data-ttu-id="4a156-124">0x02</span><span class="sxs-lookup"><span data-stu-id="4a156-124">0x02</span></span>
<span data-ttu-id="4a156-125">マウス</span><span class="sxs-lookup"><span data-stu-id="4a156-125">Mouse</span></span> | <span data-ttu-id="4a156-126">0x03</span><span class="sxs-lookup"><span data-stu-id="4a156-126">0x03</span></span>
<span data-ttu-id="4a156-127">すべてクリア</span><span class="sxs-lookup"><span data-stu-id="4a156-127">Clear All</span></span> | <span data-ttu-id="4a156-128">0x04</span><span class="sxs-lookup"><span data-stu-id="4a156-128">0x04</span></span>

<span data-ttu-id="4a156-129">KeyboardKeyCodes および KeyboardScanCodes では、2 番目のバイトはキーコードまたはスキャン コードの値で、3 番目のバイトは 押下の 0x01 とリリースの 0x00 です。</span><span class="sxs-lookup"><span data-stu-id="4a156-129">For KeyboardKeyCodes and KeyboardScanCodes, the second byte is the value of the keycode or scancode and the third byte is 0x01 for a down press and 0x00 for a release.</span></span>

<span data-ttu-id="4a156-130">マウス メッセージでは、次の値はマウス イベントの種類を示す、ネットワーク順序の UINT16 (2 バイト) です。</span><span class="sxs-lookup"><span data-stu-id="4a156-130">For a Mouse message, the next value is a UINT16 in network order (2 bytes) indicating the type of mouse event:</span></span>

| <span data-ttu-id="4a156-131">アクションの種類</span><span class="sxs-lookup"><span data-stu-id="4a156-131">Action Type</span></span>        | <span data-ttu-id="4a156-132">UINT16 値</span><span class="sxs-lookup"><span data-stu-id="4a156-132">UINT16 Value</span></span> |
|------------|-------------|
<span data-ttu-id="4a156-133">移動</span><span class="sxs-lookup"><span data-stu-id="4a156-133">Move</span></span> | <span data-ttu-id="4a156-134">0x0001</span><span class="sxs-lookup"><span data-stu-id="4a156-134">0x0001</span></span>
<span data-ttu-id="4a156-135">LeftDown</span><span class="sxs-lookup"><span data-stu-id="4a156-135">LeftDown</span></span> | <span data-ttu-id="4a156-136">0x0002</span><span class="sxs-lookup"><span data-stu-id="4a156-136">0x0002</span></span>
<span data-ttu-id="4a156-137">LeftUp</span><span class="sxs-lookup"><span data-stu-id="4a156-137">LeftUp</span></span> | <span data-ttu-id="4a156-138">0x0004</span><span class="sxs-lookup"><span data-stu-id="4a156-138">0x0004</span></span>
<span data-ttu-id="4a156-139">RightDown</span><span class="sxs-lookup"><span data-stu-id="4a156-139">RightDown</span></span> | <span data-ttu-id="4a156-140">0x0008</span><span class="sxs-lookup"><span data-stu-id="4a156-140">0x0008</span></span>
<span data-ttu-id="4a156-141">RightUp</span><span class="sxs-lookup"><span data-stu-id="4a156-141">RightUp</span></span> | <span data-ttu-id="4a156-142">0x0010</span><span class="sxs-lookup"><span data-stu-id="4a156-142">0x0010</span></span>
<span data-ttu-id="4a156-143">MiddleDown</span><span class="sxs-lookup"><span data-stu-id="4a156-143">MiddleDown</span></span> | <span data-ttu-id="4a156-144">0x0020</span><span class="sxs-lookup"><span data-stu-id="4a156-144">0x0020</span></span>
<span data-ttu-id="4a156-145">MiddleUp</span><span class="sxs-lookup"><span data-stu-id="4a156-145">MiddleUp</span></span> | <span data-ttu-id="4a156-146">0x0040</span><span class="sxs-lookup"><span data-stu-id="4a156-146">0x0040</span></span>
<span data-ttu-id="4a156-147">X1Down</span><span class="sxs-lookup"><span data-stu-id="4a156-147">X1Down</span></span> | <span data-ttu-id="4a156-148">0x0080</span><span class="sxs-lookup"><span data-stu-id="4a156-148">0x0080</span></span>
<span data-ttu-id="4a156-149">X1Up</span><span class="sxs-lookup"><span data-stu-id="4a156-149">X1Up</span></span> | <span data-ttu-id="4a156-150">0x0100</span><span class="sxs-lookup"><span data-stu-id="4a156-150">0x0100</span></span>
<span data-ttu-id="4a156-151">X2Down</span><span class="sxs-lookup"><span data-stu-id="4a156-151">X2Down</span></span> | <span data-ttu-id="4a156-152">0x0200</span><span class="sxs-lookup"><span data-stu-id="4a156-152">0x0200</span></span>
<span data-ttu-id="4a156-153">X2Up</span><span class="sxs-lookup"><span data-stu-id="4a156-153">X2Up</span></span> | <span data-ttu-id="4a156-154">0x0400</span><span class="sxs-lookup"><span data-stu-id="4a156-154">0x0400</span></span>
<span data-ttu-id="4a156-155">VerticalWheelMoved</span><span class="sxs-lookup"><span data-stu-id="4a156-155">VerticalWheelMoved</span></span> | <span data-ttu-id="4a156-156">0x0800</span><span class="sxs-lookup"><span data-stu-id="4a156-156">0x0800</span></span>
<span data-ttu-id="4a156-157">HorizontalWheelMoved</span><span class="sxs-lookup"><span data-stu-id="4a156-157">HorizontalWheelMoved</span></span> | <span data-ttu-id="4a156-158">0x1000</span><span class="sxs-lookup"><span data-stu-id="4a156-158">0x1000</span></span>

<span data-ttu-id="4a156-159">このバイトの後に、ネットワーク順序の 2 つの UINT32 値とホイール アクションを示す 3 つ目のオプションの UINT32 が続きます。</span><span class="sxs-lookup"><span data-stu-id="4a156-159">This byte is followed by two UINT32 values in network order, and an optional third UINT32 for wheel actions.</span></span> <span data-ttu-id="4a156-160">最初の 2 つの値は X 座標と Y 座標で、3 つ目の値はホイールのデルタです。</span><span class="sxs-lookup"><span data-stu-id="4a156-160">The first two values are the X and Y coordinate and the third is the wheel delta.</span></span> <span data-ttu-id="4a156-161">X 座標と Y 座標は、水平面および垂直面でマウスの相対位置を示す 0 ～ 65535 の間の値になることが期待されます。</span><span class="sxs-lookup"><span data-stu-id="4a156-161">The X and Y coordinates are expected to be a value between 0 and 65535 indicating the relative position of the mouse in the horizontal and vertical planes.</span></span>

<span data-ttu-id="4a156-162">ClearAll は、現在押されているキーを離す必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="4a156-162">ClearAll indicates any currently held down keys should be released.</span></span> <span data-ttu-id="4a156-163">他のバイトは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="4a156-163">No other bytes are expected.</span></span>

<span data-ttu-id="4a156-164">ゲームパッド入力を送信するために、ゲームパッドのボタンの押下を表すキーコードの値を KeyboardKeyCodes で使用できます。</span><span class="sxs-lookup"><span data-stu-id="4a156-164">For sending Gamepad input, the keycode values which represent Gamepad button presses can be used with KeyboardKeyCodes.</span></span> <span data-ttu-id="4a156-165">これらの値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4a156-165">Those values are as follows:</span></span>

| <span data-ttu-id="4a156-166">ゲームパッドの種類</span><span class="sxs-lookup"><span data-stu-id="4a156-166">Gamepad Type</span></span>        | <span data-ttu-id="4a156-167">バイト値</span><span class="sxs-lookup"><span data-stu-id="4a156-167">Byte Value</span></span> |
|------------|-------------|
<span data-ttu-id="4a156-168">VK_GAMEPAD_A</span><span class="sxs-lookup"><span data-stu-id="4a156-168">VK_GAMEPAD_A</span></span>                       |  <span data-ttu-id="4a156-169">0xC3</span><span class="sxs-lookup"><span data-stu-id="4a156-169">0xC3</span></span>
<span data-ttu-id="4a156-170">VK_GAMEPAD_B</span><span class="sxs-lookup"><span data-stu-id="4a156-170">VK_GAMEPAD_B</span></span>                       |  <span data-ttu-id="4a156-171">0xC4</span><span class="sxs-lookup"><span data-stu-id="4a156-171">0xC4</span></span>
<span data-ttu-id="4a156-172">VK_GAMEPAD_X</span><span class="sxs-lookup"><span data-stu-id="4a156-172">VK_GAMEPAD_X</span></span>                       |  <span data-ttu-id="4a156-173">0xC5</span><span class="sxs-lookup"><span data-stu-id="4a156-173">0xC5</span></span>
<span data-ttu-id="4a156-174">VK_GAMEPAD_Y</span><span class="sxs-lookup"><span data-stu-id="4a156-174">VK_GAMEPAD_Y</span></span>                       |  <span data-ttu-id="4a156-175">0xC6</span><span class="sxs-lookup"><span data-stu-id="4a156-175">0xC6</span></span>
<span data-ttu-id="4a156-176">VK_GAMEPAD_RIGHT_SHOULDER</span><span class="sxs-lookup"><span data-stu-id="4a156-176">VK_GAMEPAD_RIGHT_SHOULDER</span></span>          |  <span data-ttu-id="4a156-177">0xC7</span><span class="sxs-lookup"><span data-stu-id="4a156-177">0xC7</span></span>
<span data-ttu-id="4a156-178">VK_GAMEPAD_LEFT_SHOULDER</span><span class="sxs-lookup"><span data-stu-id="4a156-178">VK_GAMEPAD_LEFT_SHOULDER</span></span>           |  <span data-ttu-id="4a156-179">0xC8</span><span class="sxs-lookup"><span data-stu-id="4a156-179">0xC8</span></span>
<span data-ttu-id="4a156-180">VK_GAMEPAD_LEFT_TRIGGER</span><span class="sxs-lookup"><span data-stu-id="4a156-180">VK_GAMEPAD_LEFT_TRIGGER</span></span>            |  <span data-ttu-id="4a156-181">0xC9</span><span class="sxs-lookup"><span data-stu-id="4a156-181">0xC9</span></span>
<span data-ttu-id="4a156-182">VK_GAMEPAD_RIGHT_TRIGGER</span><span class="sxs-lookup"><span data-stu-id="4a156-182">VK_GAMEPAD_RIGHT_TRIGGER</span></span>           |  <span data-ttu-id="4a156-183">0xCA</span><span class="sxs-lookup"><span data-stu-id="4a156-183">0xCA</span></span>
<span data-ttu-id="4a156-184">VK_GAMEPAD_DPAD_UP</span><span class="sxs-lookup"><span data-stu-id="4a156-184">VK_GAMEPAD_DPAD_UP</span></span>                 |  <span data-ttu-id="4a156-185">0xCB</span><span class="sxs-lookup"><span data-stu-id="4a156-185">0xCB</span></span>
<span data-ttu-id="4a156-186">VK_GAMEPAD_DPAD_DOWN</span><span class="sxs-lookup"><span data-stu-id="4a156-186">VK_GAMEPAD_DPAD_DOWN</span></span>               |  <span data-ttu-id="4a156-187">0xCC</span><span class="sxs-lookup"><span data-stu-id="4a156-187">0xCC</span></span>
<span data-ttu-id="4a156-188">VK_GAMEPAD_DPAD_LEFT</span><span class="sxs-lookup"><span data-stu-id="4a156-188">VK_GAMEPAD_DPAD_LEFT</span></span>               |  <span data-ttu-id="4a156-189">0xCD</span><span class="sxs-lookup"><span data-stu-id="4a156-189">0xCD</span></span>
<span data-ttu-id="4a156-190">VK_GAMEPAD_DPAD_RIGHT</span><span class="sxs-lookup"><span data-stu-id="4a156-190">VK_GAMEPAD_DPAD_RIGHT</span></span>              |  <span data-ttu-id="4a156-191">0xCE</span><span class="sxs-lookup"><span data-stu-id="4a156-191">0xCE</span></span>
<span data-ttu-id="4a156-192">VK_GAMEPAD_MENU</span><span class="sxs-lookup"><span data-stu-id="4a156-192">VK_GAMEPAD_MENU</span></span>                    |  <span data-ttu-id="4a156-193">0xCF</span><span class="sxs-lookup"><span data-stu-id="4a156-193">0xCF</span></span>
<span data-ttu-id="4a156-194">VK_GAMEPAD_VIEW</span><span class="sxs-lookup"><span data-stu-id="4a156-194">VK_GAMEPAD_VIEW</span></span>                    |  <span data-ttu-id="4a156-195">0xD0</span><span class="sxs-lookup"><span data-stu-id="4a156-195">0xD0</span></span>
<span data-ttu-id="4a156-196">VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON</span><span class="sxs-lookup"><span data-stu-id="4a156-196">VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON</span></span>  |  <span data-ttu-id="4a156-197">0xD1</span><span class="sxs-lookup"><span data-stu-id="4a156-197">0xD1</span></span>
<span data-ttu-id="4a156-198">VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON</span><span class="sxs-lookup"><span data-stu-id="4a156-198">VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON</span></span> |  <span data-ttu-id="4a156-199">0xD2</span><span class="sxs-lookup"><span data-stu-id="4a156-199">0xD2</span></span>
<span data-ttu-id="4a156-200">VK_GAMEPAD_LEFT_THUMBSTICK_UP</span><span class="sxs-lookup"><span data-stu-id="4a156-200">VK_GAMEPAD_LEFT_THUMBSTICK_UP</span></span>      |  <span data-ttu-id="4a156-201">0xD3</span><span class="sxs-lookup"><span data-stu-id="4a156-201">0xD3</span></span>
<span data-ttu-id="4a156-202">VK_GAMEPAD_LEFT_THUMBSTICK_DOWN</span><span class="sxs-lookup"><span data-stu-id="4a156-202">VK_GAMEPAD_LEFT_THUMBSTICK_DOWN</span></span>    |  <span data-ttu-id="4a156-203">0xD4</span><span class="sxs-lookup"><span data-stu-id="4a156-203">0xD4</span></span>
<span data-ttu-id="4a156-204">VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT</span><span class="sxs-lookup"><span data-stu-id="4a156-204">VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT</span></span>   |  <span data-ttu-id="4a156-205">0xD5</span><span class="sxs-lookup"><span data-stu-id="4a156-205">0xD5</span></span>
<span data-ttu-id="4a156-206">VK_GAMEPAD_LEFT_THUMBSTICK_LEFT</span><span class="sxs-lookup"><span data-stu-id="4a156-206">VK_GAMEPAD_LEFT_THUMBSTICK_LEFT</span></span>    |  <span data-ttu-id="4a156-207">0xD6</span><span class="sxs-lookup"><span data-stu-id="4a156-207">0xD6</span></span>
<span data-ttu-id="4a156-208">VK_GAMEPAD_RIGHT_THUMBSTICK_UP</span><span class="sxs-lookup"><span data-stu-id="4a156-208">VK_GAMEPAD_RIGHT_THUMBSTICK_UP</span></span>     |  <span data-ttu-id="4a156-209">0xD7</span><span class="sxs-lookup"><span data-stu-id="4a156-209">0xD7</span></span>
<span data-ttu-id="4a156-210">VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN</span><span class="sxs-lookup"><span data-stu-id="4a156-210">VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN</span></span>   |  <span data-ttu-id="4a156-211">0xD8</span><span class="sxs-lookup"><span data-stu-id="4a156-211">0xD8</span></span>
<span data-ttu-id="4a156-212">VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT</span><span class="sxs-lookup"><span data-stu-id="4a156-212">VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT</span></span>  |  <span data-ttu-id="4a156-213">0xD9</span><span class="sxs-lookup"><span data-stu-id="4a156-213">0xD9</span></span>
<span data-ttu-id="4a156-214">VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT</span><span class="sxs-lookup"><span data-stu-id="4a156-214">VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT</span></span>   |  <span data-ttu-id="4a156-215">0xDA</span><span class="sxs-lookup"><span data-stu-id="4a156-215">0xDA</span></span>


**<span data-ttu-id="4a156-216">応答</span><span class="sxs-lookup"><span data-stu-id="4a156-216">Response</span></span>**   

- <span data-ttu-id="4a156-217">なし</span><span class="sxs-lookup"><span data-stu-id="4a156-217">None</span></span>

**<span data-ttu-id="4a156-218">状態コード</span><span class="sxs-lookup"><span data-stu-id="4a156-218">Status code</span></span>**

<span data-ttu-id="4a156-219">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4a156-219">This API has the following expected status codes.</span></span>

<span data-ttu-id="4a156-220">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4a156-220">HTTP status code</span></span>      | <span data-ttu-id="4a156-221">説明</span><span class="sxs-lookup"><span data-stu-id="4a156-221">Description</span></span>
:------     | :-----
<span data-ttu-id="4a156-222">200</span><span class="sxs-lookup"><span data-stu-id="4a156-222">200</span></span> | <span data-ttu-id="4a156-223">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="4a156-223">Request was successful</span></span>
<span data-ttu-id="4a156-224">4XX</span><span class="sxs-lookup"><span data-stu-id="4a156-224">4XX</span></span> | <span data-ttu-id="4a156-225">エラー コード</span><span class="sxs-lookup"><span data-stu-id="4a156-225">Error codes</span></span>
<span data-ttu-id="4a156-226">5XX</span><span class="sxs-lookup"><span data-stu-id="4a156-226">5XX</span></span> | <span data-ttu-id="4a156-227">エラー コード</span><span class="sxs-lookup"><span data-stu-id="4a156-227">Error codes</span></span>

<br />
**<span data-ttu-id="4a156-228">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="4a156-228">Available device families</span></span>**

* <span data-ttu-id="4a156-229">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="4a156-229">Windows Xbox</span></span>