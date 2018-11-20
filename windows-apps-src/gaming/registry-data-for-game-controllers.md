---
author: eliotcowley
title: ゲーム コントローラーのレジストリ データ
description: UWP ゲームで使用されるコントローラーを有効にするために、PC のレジストリに追加できるデータについて説明します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.author: wdg-dev-content
ms.date: 06/25/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, レジストリ, カスタム
ms.localizationpriority: medium
ms.openlocfilehash: 4bbd4074c52514b9cb66fd6f2dd189421f61d5ee
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304774"
---
# <a name="registry-data-for-game-controllers"></a><span data-ttu-id="2435b-104">ゲーム コントローラーのレジストリ データ</span><span class="sxs-lookup"><span data-stu-id="2435b-104">Registry data for game controllers</span></span>

> [!NOTE]
> <span data-ttu-id="2435b-105">このトピックは、Windows 10 互換のゲーム コントローラーの製造元向けです。開発者の大部分には適用されません。</span><span class="sxs-lookup"><span data-stu-id="2435b-105">This topic is meant for manufacturers of Windows 10-compatible game controllers, and doesn't apply to the majority of developers.</span></span>

<span data-ttu-id="2435b-106">[Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)を使うと、独立系ハードウェア ベンダー (IHV) は、PC のレジストリにデータを追加して、デバイスが [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad)、[RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel)、[ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) として表示されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="2435b-106">The [Windows.Gaming.Input namespace](https://docs.microsoft.com/uwp/api/windows.gaming.input) allows independent hardware vendors (IHVs) to add data to the PC's registry, enabling their devices to appear as [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad), [RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel), [ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick), [FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick), and [UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) as appropriate.</span></span> <span data-ttu-id="2435b-107">互換性のあるコントローラー用にこのデータを追加することを、すべての IHV に推奨します。</span><span class="sxs-lookup"><span data-stu-id="2435b-107">All IHVs should add this data for their compatible controllers.</span></span> <span data-ttu-id="2435b-108">これにより、すべての UWP ゲーム (および WinRT API を使用するすべてのデスクトップ ゲーム) でゲーム コントローラーをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="2435b-108">By doing this, all UWP games (and any desktop games that use the WinRT API) will be able to support your game controller.</span></span>

## <a name="mapping-scheme"></a><span data-ttu-id="2435b-109">マッピング スキーム</span><span class="sxs-lookup"><span data-stu-id="2435b-109">Mapping scheme</span></span>

<span data-ttu-id="2435b-110">デバイスのマッピングとして、ベンダー ID (VID) **VVVV**、製品 ID (PID) **PPPP**、使用ページ **UUUU**、使用 ID **XXXX** が、レジストリのこの場所から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="2435b-110">Mappings for a device with Vendor ID (VID) **VVVV**, Product ID (PID) **PPPP**, Usage Page **UUUU**, and Usage ID **XXXX**, will be read out from this location in the registry:</span></span>

`HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\VVVVPPPPUUUUXXXX`

<span data-ttu-id="2435b-111">次の表は、デバイスのルートの場所で予期される値を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-111">The table below explains the expected values under the device root location:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-112">名前</span><span class="sxs-lookup"><span data-stu-id="2435b-112">Name</span></span></th>
        <th><span data-ttu-id="2435b-113">種類</span><span class="sxs-lookup"><span data-stu-id="2435b-113">Type</span></span></th>
        <th><span data-ttu-id="2435b-114">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-114">Required?</span></span></th>
        <th><span data-ttu-id="2435b-115">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-115">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-116">Disabled</span><span class="sxs-lookup"><span data-stu-id="2435b-116">Disabled</span></span></td>
        <td><span data-ttu-id="2435b-117">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-117">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-118">いいえ</span><span class="sxs-lookup"><span data-stu-id="2435b-118">No</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-119">この特定のデバイスを無効にすることを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-119">Indicates that this particular device should be disabled.</span></span></p>
            <ul>
                <li><span data-ttu-id="2435b-120"><b>0</b>: デバイスは無効ではありません。</span><span class="sxs-lookup"><span data-stu-id="2435b-120"><b>0</b>: Device is not disabled.</span></span></li>
                <li><span data-ttu-id="2435b-121"><b>1</b>: デバイスは無効です。</span><span class="sxs-lookup"><span data-stu-id="2435b-121"><b>1</b>: Device is disabled.</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-122">説明</span><span class="sxs-lookup"><span data-stu-id="2435b-122">Description</span></span></td>
        <td><span data-ttu-id="2435b-123">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="2435b-123">REG_SZ</span></span> <td><span data-ttu-id="2435b-124">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-124">No</span></span></td>
        <td><span data-ttu-id="2435b-125">デバイスの簡単な説明です。</span><span class="sxs-lookup"><span data-stu-id="2435b-125">A short description of the device.</span></span></td>
    </tr>
</table>

<span data-ttu-id="2435b-126">デバイスのインストーラーが (セットアップ、または [INF ファイル](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)によって) このデータをレジストリに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2435b-126">Your device installer should add this data to the registry (either via setup or an [INF file](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)).</span></span>

<span data-ttu-id="2435b-127">デバイスのルートの場所の下のサブキーは、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="2435b-127">Subkeys under the device root location are detailed in the following sections.</span></span>

### <a name="gamepad"></a><span data-ttu-id="2435b-128">Gamepad</span><span class="sxs-lookup"><span data-stu-id="2435b-128">Gamepad</span></span>

<span data-ttu-id="2435b-129">次の表は **Gamepad** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-129">The table below lists the required and optional subkeys under the **Gamepad** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-130">サブキー</span><span class="sxs-lookup"><span data-stu-id="2435b-130">Subkey</span></span></th>
        <th><span data-ttu-id="2435b-131">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-131">Required?</span></span></th>
        <th><span data-ttu-id="2435b-132">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-132">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-133">Menu</span><span class="sxs-lookup"><span data-stu-id="2435b-133">Menu</span></span></td>
        <td><span data-ttu-id="2435b-134">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-134">Yes</span></span></td>
        <td rowspan="18" style="vertical-align: middle;"><span data-ttu-id="2435b-135">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-135">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-136">View</span><span class="sxs-lookup"><span data-stu-id="2435b-136">View</span></span></td>
        <td><span data-ttu-id="2435b-137">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-137">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-138">A</span><span class="sxs-lookup"><span data-stu-id="2435b-138">A</span></span></td>
        <td><span data-ttu-id="2435b-139">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-139">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-140">B</span><span class="sxs-lookup"><span data-stu-id="2435b-140">B</span></span></td>
        <td><span data-ttu-id="2435b-141">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-141">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-142">X</span><span class="sxs-lookup"><span data-stu-id="2435b-142">X</span></span></td>
        <td><span data-ttu-id="2435b-143">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-143">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-144">Y</span><span class="sxs-lookup"><span data-stu-id="2435b-144">Y</span></span></td>
        <td><span data-ttu-id="2435b-145">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-145">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-146">LeftShoulder</span><span class="sxs-lookup"><span data-stu-id="2435b-146">LeftShoulder</span></span></td>
        <td><span data-ttu-id="2435b-147">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-147">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-148">RightShoulder</span><span class="sxs-lookup"><span data-stu-id="2435b-148">RightShoulder</span></span></td>
        <td><span data-ttu-id="2435b-149">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-149">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-150">LeftThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="2435b-150">LeftThumbstickButton</span></span></td>
        <td><span data-ttu-id="2435b-151">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-151">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-152">RightThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="2435b-152">RightThumbstickButton</span></span></td>
        <td><span data-ttu-id="2435b-153">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-153">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-154">DPadUp</span><span class="sxs-lookup"><span data-stu-id="2435b-154">DPadUp</span></span></td>
        <td><span data-ttu-id="2435b-155">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-155">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-156">DPadDown</span><span class="sxs-lookup"><span data-stu-id="2435b-156">DPadDown</span></span></td>
        <td><span data-ttu-id="2435b-157">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-157">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-158">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-158">DPadLeft</span></span></td>
        <td><span data-ttu-id="2435b-159">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-159">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-160">DPadRight</span><span class="sxs-lookup"><span data-stu-id="2435b-160">DPadRight</span></span></td>
        <td><span data-ttu-id="2435b-161">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-161">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-162">Paddle1</span><span class="sxs-lookup"><span data-stu-id="2435b-162">Paddle1</span></span></td>
        <td><span data-ttu-id="2435b-163">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-163">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-164">Paddle2</span><span class="sxs-lookup"><span data-stu-id="2435b-164">Paddle2</span></span></td>
        <td><span data-ttu-id="2435b-165">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-165">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-166">Paddle3</span><span class="sxs-lookup"><span data-stu-id="2435b-166">Paddle3</span></span></td>
        <td><span data-ttu-id="2435b-167">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-167">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-168">Paddle4</span><span class="sxs-lookup"><span data-stu-id="2435b-168">Paddle4</span></span></td>
        <td><span data-ttu-id="2435b-169">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-169">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-170">LeftTrigger</span><span class="sxs-lookup"><span data-stu-id="2435b-170">LeftTrigger</span></span></td>
        <td><span data-ttu-id="2435b-171">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-171">Yes</span></span></td>
        <td rowspan="6" style="vertical-align: middle;"><span data-ttu-id="2435b-172">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-172">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-173">RightTrigger</span><span class="sxs-lookup"><span data-stu-id="2435b-173">RightTrigger</span></span></td>
        <td><span data-ttu-id="2435b-174">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-174">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-175">LeftThumbstickX</span><span class="sxs-lookup"><span data-stu-id="2435b-175">LeftThumbstickX</span></span></td>
        <td><span data-ttu-id="2435b-176">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-176">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-177">LeftThumbstickY</span><span class="sxs-lookup"><span data-stu-id="2435b-177">LeftThumbstickY</span></span></td>
        <td><span data-ttu-id="2435b-178">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-178">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-179">RightThumbstickX</span><span class="sxs-lookup"><span data-stu-id="2435b-179">RightThumbstickX</span></span></td>
        <td><span data-ttu-id="2435b-180">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-180">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-181">RightThumbstickY</span><span class="sxs-lookup"><span data-stu-id="2435b-181">RightThumbstickY</span></span></td>
        <td><span data-ttu-id="2435b-182">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-182">Yes</span></span></td>
    </tr>
</table>

> [!NOTE]
> <span data-ttu-id="2435b-183">サポートされる **Gamepad** として、ゲーム コントローラーを追加する場合には、サポートされる **UINavigationController** としても、ゲーム コントローラーを追加することを強く推奨します。</span><span class="sxs-lookup"><span data-stu-id="2435b-183">If you add your game controller as a supported **Gamepad**, we highly recommend that you also add it as a supported **UINavigationController**.</span></span>

### <a name="racingwheel"></a><span data-ttu-id="2435b-184">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="2435b-184">RacingWheel</span></span>

<span data-ttu-id="2435b-185">次の表は **RacingWheel** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-185">The table below lists the required and optional subkeys under the **RacingWheel** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-186">サブキー</span><span class="sxs-lookup"><span data-stu-id="2435b-186">Subkey</span></span></th>
        <th><span data-ttu-id="2435b-187">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-187">Required?</span></span></th>
        <th><span data-ttu-id="2435b-188">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-188">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-189">PreviousGear</span><span class="sxs-lookup"><span data-stu-id="2435b-189">PreviousGear</span></span></td>
        <td><span data-ttu-id="2435b-190">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-190">Yes</span></span></td>
        <td rowspan="30" style="vertical-align: middle;"><span data-ttu-id="2435b-191">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-191">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-192">NextGear</span><span class="sxs-lookup"><span data-stu-id="2435b-192">NextGear</span></span></td>
        <td><span data-ttu-id="2435b-193">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-193">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-194">DPadUp</span><span class="sxs-lookup"><span data-stu-id="2435b-194">DPadUp</span></span></td>
        <td><span data-ttu-id="2435b-195">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-195">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-196">DPadDown</span><span class="sxs-lookup"><span data-stu-id="2435b-196">DPadDown</span></span></td>
        <td><span data-ttu-id="2435b-197">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-197">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-198">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-198">DPadLeft</span></span></td>
        <td><span data-ttu-id="2435b-199">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-199">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-200">DPadRight</span><span class="sxs-lookup"><span data-stu-id="2435b-200">DPadRight</span></span></td>
        <td><span data-ttu-id="2435b-201">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-201">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-202">Button1</span><span class="sxs-lookup"><span data-stu-id="2435b-202">Button1</span></span></td>
        <td><span data-ttu-id="2435b-203">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-203">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-204">Button2</span><span class="sxs-lookup"><span data-stu-id="2435b-204">Button2</span></span></td>
        <td><span data-ttu-id="2435b-205">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-205">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-206">Button3</span><span class="sxs-lookup"><span data-stu-id="2435b-206">Button3</span></span></td>
        <td><span data-ttu-id="2435b-207">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-207">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-208">Button4</span><span class="sxs-lookup"><span data-stu-id="2435b-208">Button4</span></span></td>
        <td><span data-ttu-id="2435b-209">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-209">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-210">Button5</span><span class="sxs-lookup"><span data-stu-id="2435b-210">Button5</span></span></td>
        <td><span data-ttu-id="2435b-211">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-211">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-212">Button6</span><span class="sxs-lookup"><span data-stu-id="2435b-212">Button6</span></span></td>
        <td><span data-ttu-id="2435b-213">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-213">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-214">Button7</span><span class="sxs-lookup"><span data-stu-id="2435b-214">Button7</span></span></td>
        <td><span data-ttu-id="2435b-215">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-215">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-216">Button8</span><span class="sxs-lookup"><span data-stu-id="2435b-216">Button8</span></span></td>
        <td><span data-ttu-id="2435b-217">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-217">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-218">Button9</span><span class="sxs-lookup"><span data-stu-id="2435b-218">Button9</span></span></td>
        <td><span data-ttu-id="2435b-219">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-219">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-220">Button10</span><span class="sxs-lookup"><span data-stu-id="2435b-220">Button10</span></span></td>
        <td><span data-ttu-id="2435b-221">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-221">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-222">Button11</span><span class="sxs-lookup"><span data-stu-id="2435b-222">Button11</span></span></td>
        <td><span data-ttu-id="2435b-223">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-223">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-224">Button12</span><span class="sxs-lookup"><span data-stu-id="2435b-224">Button12</span></span></td>
        <td><span data-ttu-id="2435b-225">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-225">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-226">Button13</span><span class="sxs-lookup"><span data-stu-id="2435b-226">Button13</span></span></td>
        <td><span data-ttu-id="2435b-227">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-227">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-228">Button14</span><span class="sxs-lookup"><span data-stu-id="2435b-228">Button14</span></span></td>
        <td><span data-ttu-id="2435b-229">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-229">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-230">Button15</span><span class="sxs-lookup"><span data-stu-id="2435b-230">Button15</span></span></td>
        <td><span data-ttu-id="2435b-231">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-231">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-232">Button16</span><span class="sxs-lookup"><span data-stu-id="2435b-232">Button16</span></span></td>
        <td><span data-ttu-id="2435b-233">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-233">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-234">FirstGear</span><span class="sxs-lookup"><span data-stu-id="2435b-234">FirstGear</span></span></td>
        <td><span data-ttu-id="2435b-235">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-235">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-236">SecondGear</span><span class="sxs-lookup"><span data-stu-id="2435b-236">SecondGear</span></span></td>
        <td><span data-ttu-id="2435b-237">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-237">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-238">ThirdGear</span><span class="sxs-lookup"><span data-stu-id="2435b-238">ThirdGear</span></span></td>
        <td><span data-ttu-id="2435b-239">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-239">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-240">FourthGear</span><span class="sxs-lookup"><span data-stu-id="2435b-240">FourthGear</span></span></td>
        <td><span data-ttu-id="2435b-241">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-241">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-242">FifthGear</span><span class="sxs-lookup"><span data-stu-id="2435b-242">FifthGear</span></span></td>
        <td><span data-ttu-id="2435b-243">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-243">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-244">SixthGear</span><span class="sxs-lookup"><span data-stu-id="2435b-244">SixthGear</span></span></td>
        <td><span data-ttu-id="2435b-245">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-245">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-246">SeventhGear</span><span class="sxs-lookup"><span data-stu-id="2435b-246">SeventhGear</span></span></td>
        <td><span data-ttu-id="2435b-247">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-247">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-248">ReverseGear</span><span class="sxs-lookup"><span data-stu-id="2435b-248">ReverseGear</span></span></td>
        <td><span data-ttu-id="2435b-249">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-249">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-250">Wheel</span><span class="sxs-lookup"><span data-stu-id="2435b-250">Wheel</span></span></td>
        <td><span data-ttu-id="2435b-251">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-251">Yes</span></span></td>
        <td rowspan="5" style="vertical-align: middle;"><span data-ttu-id="2435b-252">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-252">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-253">Throttle</span><span class="sxs-lookup"><span data-stu-id="2435b-253">Throttle</span></span></td>
        <td><span data-ttu-id="2435b-254">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-254">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-255">Brake</span><span class="sxs-lookup"><span data-stu-id="2435b-255">Brake</span></span></td>
        <td><span data-ttu-id="2435b-256">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-256">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-257">Clutch</span><span class="sxs-lookup"><span data-stu-id="2435b-257">Clutch</span></span></td>
        <td><span data-ttu-id="2435b-258">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-258">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-259">Handbrake</span><span class="sxs-lookup"><span data-stu-id="2435b-259">Handbrake</span></span></td>
        <td><span data-ttu-id="2435b-260">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-260">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-261">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="2435b-261">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="2435b-262">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-262">Yes</span></span></td>
        <td><span data-ttu-id="2435b-263">「<a href="#properties-mapping">プロパティ マッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-263">See <a href="#properties-mapping">Properties mapping</a></span></span></td>
    </tr>
</table>

### <a name="arcadestick"></a><span data-ttu-id="2435b-264">ArcadeStick</span><span class="sxs-lookup"><span data-stu-id="2435b-264">ArcadeStick</span></span>

<span data-ttu-id="2435b-265">次の表は **ArcadeStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-265">The table below lists the required and optional subkeys under the **ArcadeStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-266">サブキー</span><span class="sxs-lookup"><span data-stu-id="2435b-266">Subkey</span></span></th>
        <th><span data-ttu-id="2435b-267">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-267">Required?</span></span></th>
        <th><span data-ttu-id="2435b-268">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-268">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-269">Action1</span><span class="sxs-lookup"><span data-stu-id="2435b-269">Action 1</span></span></td>
        <td><span data-ttu-id="2435b-270">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-270">Yes</span></span></td>
        <td rowspan="12" style="vertical-align: middle;"><span data-ttu-id="2435b-271">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-271">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-272">Action2</span><span class="sxs-lookup"><span data-stu-id="2435b-272">Action2</span></span></td>
        <td><span data-ttu-id="2435b-273">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-273">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-274">Action3</span><span class="sxs-lookup"><span data-stu-id="2435b-274">Action3</span></span></td>
        <td><span data-ttu-id="2435b-275">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-275">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-276">Action4</span><span class="sxs-lookup"><span data-stu-id="2435b-276">Action4</span></span></td>
        <td><span data-ttu-id="2435b-277">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-277">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-278">Action5</span><span class="sxs-lookup"><span data-stu-id="2435b-278">Action5</span></span></td>
        <td><span data-ttu-id="2435b-279">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-279">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-280">Action6</span><span class="sxs-lookup"><span data-stu-id="2435b-280">Action6</span></span></td>
        <td><span data-ttu-id="2435b-281">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-281">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-282">Special1</span><span class="sxs-lookup"><span data-stu-id="2435b-282">Special1</span></span></td>
        <td><span data-ttu-id="2435b-283">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-283">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-284">Special2</span><span class="sxs-lookup"><span data-stu-id="2435b-284">Special2</span></span></td>
        <td><span data-ttu-id="2435b-285">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-285">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-286">StickUp</span><span class="sxs-lookup"><span data-stu-id="2435b-286">StickUp</span></span></td>
        <td><span data-ttu-id="2435b-287">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-287">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-288">StickDown</span><span class="sxs-lookup"><span data-stu-id="2435b-288">StickDown</span></span></td>
        <td><span data-ttu-id="2435b-289">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-289">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-290">StickLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-290">StickLeft</span></span></td>
        <td><span data-ttu-id="2435b-291">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-291">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-292">StickRight</span><span class="sxs-lookup"><span data-stu-id="2435b-292">StickRight</span></span></td>
        <td><span data-ttu-id="2435b-293">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-293">Yes</span></span></td>
    </tr>
</table>

### <a name="flightstick"></a><span data-ttu-id="2435b-294">FlightStick</span><span class="sxs-lookup"><span data-stu-id="2435b-294">FlightStick</span></span>

<span data-ttu-id="2435b-295">次の表は **FlightStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-295">The table below lists the required and optional subkeys under the **FlightStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-296">サブキー</span><span class="sxs-lookup"><span data-stu-id="2435b-296">Subkey</span></span></th>
        <th><span data-ttu-id="2435b-297">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-297">Required?</span></span></th>
        <th><span data-ttu-id="2435b-298">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-298">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-299">FirePrimary</span><span class="sxs-lookup"><span data-stu-id="2435b-299">FirePrimary</span></span></td>
        <td><span data-ttu-id="2435b-300">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-300">Yes</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-301">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-301">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-302">FireSecondary</span><span class="sxs-lookup"><span data-stu-id="2435b-302">FireSecondary</span></span></td>
        <td><span data-ttu-id="2435b-303">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-303">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-304">Roll</span><span class="sxs-lookup"><span data-stu-id="2435b-304">Roll</span></span></td>
        <td><span data-ttu-id="2435b-305">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-305">Yes</span></span></td>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="2435b-306">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-306">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-307">Pitch</span><span class="sxs-lookup"><span data-stu-id="2435b-307">Pitch</span></span></td>
        <td><span data-ttu-id="2435b-308">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-308">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-309">Yaw</span><span class="sxs-lookup"><span data-stu-id="2435b-309">Yaw</span></span></td>
        <td><span data-ttu-id="2435b-310">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-310">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-311">Throttle</span><span class="sxs-lookup"><span data-stu-id="2435b-311">Throttle</span></span></td>
        <td><span data-ttu-id="2435b-312">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-312">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-313">HatSwitch</span><span class="sxs-lookup"><span data-stu-id="2435b-313">HatSwitch</span></span></td>
        <td><span data-ttu-id="2435b-314">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-314">Yes</span></span></td>
        <td><span data-ttu-id="2435b-315">「<a href="#switch-mapping">スイッチのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-315">See <a href="#switch-mapping">Switch mapping</a></span></span></td>
    </tr>
</table>

### <a name="uinavigation"></a><span data-ttu-id="2435b-316">UINavigation</span><span class="sxs-lookup"><span data-stu-id="2435b-316">UINavigation</span></span>

<span data-ttu-id="2435b-317">次の表は **UINavigation** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-317">The table below lists the required and optional subkeys under **UINavigation** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-318">サブキー</span><span class="sxs-lookup"><span data-stu-id="2435b-318">Subkey</span></span></th>
        <th><span data-ttu-id="2435b-319">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-319">Required?</span></span></th>
        <th><span data-ttu-id="2435b-320">情報</span><span class="sxs-lookup"><span data-stu-id="2435b-320">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-321">Menu</span><span class="sxs-lookup"><span data-stu-id="2435b-321">Menu</span></span></td>
        <td><span data-ttu-id="2435b-322">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-322">Yes</span></span></td>
        <td rowspan="24" style="vertical-align: middle;"><span data-ttu-id="2435b-323">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-323">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-324">View</span><span class="sxs-lookup"><span data-stu-id="2435b-324">View</span></span></td>
        <td><span data-ttu-id="2435b-325">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-325">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-326">Accept</span><span class="sxs-lookup"><span data-stu-id="2435b-326">Accept</span></span></td>
        <td><span data-ttu-id="2435b-327">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-327">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-328">Cancel</span><span class="sxs-lookup"><span data-stu-id="2435b-328">Cancel</span></span></td>
        <td><span data-ttu-id="2435b-329">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-329">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-330">PrimaryUp</span><span class="sxs-lookup"><span data-stu-id="2435b-330">PrimaryUp</span></span></td>
        <td><span data-ttu-id="2435b-331">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-331">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-332">PrimaryDown</span><span class="sxs-lookup"><span data-stu-id="2435b-332">PrimaryDown</span></span></td>
        <td><span data-ttu-id="2435b-333">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-333">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-334">PrimaryLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-334">PrimaryLeft</span></span></td>
        <td><span data-ttu-id="2435b-335">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-335">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-336">PrimaryRight</span><span class="sxs-lookup"><span data-stu-id="2435b-336">PrimaryRight</span></span></td>
        <td><span data-ttu-id="2435b-337">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-337">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-338">Context1</span><span class="sxs-lookup"><span data-stu-id="2435b-338">Context1</span></span></td>
        <td><span data-ttu-id="2435b-339">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-339">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-340">Context2</span><span class="sxs-lookup"><span data-stu-id="2435b-340">Context2</span></span></td>
        <td><span data-ttu-id="2435b-341">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-341">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-342">Context3</span><span class="sxs-lookup"><span data-stu-id="2435b-342">Context3</span></span></td>
        <td><span data-ttu-id="2435b-343">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-343">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-344">Context4</span><span class="sxs-lookup"><span data-stu-id="2435b-344">Context4</span></span></td>
        <td><span data-ttu-id="2435b-345">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-345">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-346">PageUp</span><span class="sxs-lookup"><span data-stu-id="2435b-346">PageUp</span></span></td>
        <td><span data-ttu-id="2435b-347">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-347">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-348">PageDown</span><span class="sxs-lookup"><span data-stu-id="2435b-348">PageDown</span></span></td>
        <td><span data-ttu-id="2435b-349">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-349">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-350">PageLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-350">PageLeft</span></span></td>
        <td><span data-ttu-id="2435b-351">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-351">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-352">PageRight</span><span class="sxs-lookup"><span data-stu-id="2435b-352">PageRight</span></span></td>
        <td><span data-ttu-id="2435b-353">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-353">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-354">ScrollUp</span><span class="sxs-lookup"><span data-stu-id="2435b-354">ScrollUp</span></span></td>
        <td><span data-ttu-id="2435b-355">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-355">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-356">ScrollDown</span><span class="sxs-lookup"><span data-stu-id="2435b-356">ScrollDown</span></span></td>
        <td><span data-ttu-id="2435b-357">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-357">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-358">ScrollLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-358">ScrollLeft</span></span></td>
        <td><span data-ttu-id="2435b-359">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-359">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-360">ScrollRight</span><span class="sxs-lookup"><span data-stu-id="2435b-360">ScrollRight</span></span></td>
        <td><span data-ttu-id="2435b-361">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-361">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-362">SecondaryUp</span><span class="sxs-lookup"><span data-stu-id="2435b-362">SecondaryUp</span></span></td>
        <td><span data-ttu-id="2435b-363">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-363">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-364">SecondaryDown</span><span class="sxs-lookup"><span data-stu-id="2435b-364">SecondaryDown</span></span></td>
        <td><span data-ttu-id="2435b-365">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-365">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-366">SecondaryLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-366">SecondaryLeft</span></span></td>
        <td><span data-ttu-id="2435b-367">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-367">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-368">SecondaryRight</span><span class="sxs-lookup"><span data-stu-id="2435b-368">SecondaryRight</span></span></td>
        <td><span data-ttu-id="2435b-369">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-369">No</span></span></td>
    </tr>
</table>

<span data-ttu-id="2435b-370">UI ナビゲーション コントローラーと上記のコマンドについて詳しくは、「[UI ナビゲーション コントローラー](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2435b-370">For more information about UI navigation controllers and the above commands, see [UI navigation controller](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller).</span></span>

## <a name="keys"></a><span data-ttu-id="2435b-371">キー</span><span class="sxs-lookup"><span data-stu-id="2435b-371">Keys</span></span>

<span data-ttu-id="2435b-372">次のセクションでは、**Gamepad**、**RacingWheel**、**ArcadeStick**、**FlightStick**、**UINavigation** キーの下のサブキーのそれぞれのコンテンツについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2435b-372">The following sections explain the contents of each of the subkeys under the **Gamepad**, **RacingWheel**, **ArcadeStick**, **FlightStick**, and **UINavigation** keys.</span></span>

### <a name="button-mapping"></a><span data-ttu-id="2435b-373">ボタンのマッピング</span><span class="sxs-lookup"><span data-stu-id="2435b-373">Button mapping</span></span>

<span data-ttu-id="2435b-374">次の表は、ボタンのマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-374">The table below lists the values that are needed to map a button.</span></span> <span data-ttu-id="2435b-375">たとえば、ゲーム コントローラーの **DPadUp** キーを押すと、**DPadUp** のマッピングには **ButtonIndex** 値が含まれます (**Source** は **Button** です)。</span><span class="sxs-lookup"><span data-stu-id="2435b-375">For example, if pressing **DPadUp** on the game controller, the mapping for **DPadUp** should contain the **ButtonIndex** value (**Source** is **Button**).</span></span> <span data-ttu-id="2435b-376">**DPadUp** がスイッチの位置からマッピングされる必要がある場合は、**DPadUp** マッピングには **SwitchIndex** と **SwitchPosition** の値が含まれます (**Source** は **Switch** です)。</span><span class="sxs-lookup"><span data-stu-id="2435b-376">If **DPadUp** needs to be mapped from a switch position, then the **DPadUp** mapping should contain the values **SwitchIndex** and **SwitchPosition** (**Source** is **Switch**).</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-377">Source (ソース)</span><span class="sxs-lookup"><span data-stu-id="2435b-377">Source</span></span></th>
        <th><span data-ttu-id="2435b-378">値の名前</span><span class="sxs-lookup"><span data-stu-id="2435b-378">Value name</span></span></th>
        <th><span data-ttu-id="2435b-379">値の種類</span><span class="sxs-lookup"><span data-stu-id="2435b-379">Value type</span></span></th>
        <th><span data-ttu-id="2435b-380">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-380">Required?</span></span></th>
        <th><span data-ttu-id="2435b-381">値の情報</span><span class="sxs-lookup"><span data-stu-id="2435b-381">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-382">Button</span><span class="sxs-lookup"><span data-stu-id="2435b-382">Button</span></span></td>
        <td><span data-ttu-id="2435b-383">ButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-383">ButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-384">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-384">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-385">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-385">Yes</span></span></td>
        <td><span data-ttu-id="2435b-386"><b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-386">Index in the <b>RawGameController</b> button array.</span></span></td>
    </tr>
    <tr>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="2435b-387">Axis</span><span class="sxs-lookup"><span data-stu-id="2435b-387">Axis</span></span></td>
        <td><span data-ttu-id="2435b-388">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-388">AxisIndex</span></span></td>
        <td><span data-ttu-id="2435b-389">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-389">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-390">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-390">Yes</span></span></td>
        <td><span data-ttu-id="2435b-391"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-391">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-392">Invert</span><span class="sxs-lookup"><span data-stu-id="2435b-392">Invert</span></span></td>
        <td><span data-ttu-id="2435b-393">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-393">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-394">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-394">No</span></span></td>
        <td><span data-ttu-id="2435b-395"><b>ThresholdPercent</b> と <b>DebouncePercent</b> 要素を適用する前に、軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-395">Indicates that the axis value should be inverted before the <b>Threshold Percent</b> and <b>DebouncePercent</b> factors are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-396">ThresholdPercent</span><span class="sxs-lookup"><span data-stu-id="2435b-396">ThresholdPercent</span></span></td>
        <td><span data-ttu-id="2435b-397">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-397">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-398">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-398">Yes</span></span></td>
        <td><span data-ttu-id="2435b-399">マッピングされたボタンの値の (押した状態と離した状態の間の) 遷移の軸の位置を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-399">Indicates the axis position at which the mapped button value transitions between the pressed and released states.</span></span> <span data-ttu-id="2435b-400">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="2435b-400">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="2435b-401">軸の値がこの値以上の場合、ボタンが押されたと見なされます。</span><span class="sxs-lookup"><span data-stu-id="2435b-401">The button is considered pressed if the axis value is greater than or equal to this value.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-402">DebouncePercent</span><span class="sxs-lookup"><span data-stu-id="2435b-402">DebouncePercent</span></span></td>
        <td><span data-ttu-id="2435b-403">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-403">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-404">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-404">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-405"><b>ThresholdPercent</b> 値の周囲のウィンドウのサイズを定義します。報告されたボタンの状態をデバウンスするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-405">Defines the size of a window around the <b>ThresholdPercent</b> value, which is used to debounce the reported button state.</span></span> <span data-ttu-id="2435b-406">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="2435b-406">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="2435b-407">ボタンの状態の遷移は、軸の値がデバウンス ウィンドウの上限または下限を超えたときにのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="2435b-407">Button state transitions can only occur when the axis value crosses the upper or lower boundaries of the debounce window.</span></span> <span data-ttu-id="2435b-408">たとえば、<b>ThresholdPercent</b> が 50 で、<b>DebouncePercent</b> が 10 の場合には、デバウンスの下限と上限は、全範囲の軸の値で 45% と 55% となります。</span><span class="sxs-lookup"><span data-stu-id="2435b-408">For example, a <b>ThresholdPercent</b> of 50 and <b>DebouncePercent</b> of 10 results in debounce boundaries at 45% and 55% of the full-range axis values.</span></span> <span data-ttu-id="2435b-409">軸の値が 55% 以上に達すると、ボタンは押された状態に遷移し、軸の値が 45% 以下に達すると、ボタンはリリースされた状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="2435b-409">The button can't transition to the pressed state until the axis value reaches 55% or above, and it can't transition back to the released state until the axis value reaches 45% or below.</span></span></p>
            <p><span data-ttu-id="2435b-410">計算されるデバウンス ウィンドウの境界は 0% ～ 100% の間でクランプされます。</span><span class="sxs-lookup"><span data-stu-id="2435b-410">The computed debounce window boundaries are clamped between 0% and 100%.</span></span> <span data-ttu-id="2435b-411">たとえば、しきい値が 5% で、デバウンス ウィンドウが 20% の場合、デバウンス ウィンドウの境界は 0% と 15% となります。</span><span class="sxs-lookup"><span data-stu-id="2435b-411">For example, a threshold of 5% and a debounce window of 20% would result in the debounce window boundaries falling at 0% and 15%.</span></span> <span data-ttu-id="2435b-412">しきい値とデバウンスの値にかかわらず、軸の値が 0% ～ 100% にあるボタンの状態は常に、押されるか、または離されるかとして報告されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-412">The button state for axis values of 0% and 100% are always reported as released and pressed, respectively, regardless of the threshold and debounce values.</span></span></p>
        </td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="2435b-413">Switch</span><span class="sxs-lookup"><span data-stu-id="2435b-413">Switch</span></span></td>
        <td><span data-ttu-id="2435b-414">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-414">SwitchIndex</span></span></td>
        <td><span data-ttu-id="2435b-415">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-415">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-416">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-416">Yes</span></span></td>
        <td><span data-ttu-id="2435b-417"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-417">Index in the <b>RawGameController</b> switch array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-418">SwitchPosition</span><span class="sxs-lookup"><span data-stu-id="2435b-418">SwitchPosition</span></span></td>
        <td><span data-ttu-id="2435b-419">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="2435b-419">REG_SZ</span></span></td>
        <td><span data-ttu-id="2435b-420">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-420">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-421">マッピングされたボタンが押されたことを報告するスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-421">Indicates the switch position that will cause the mapped button to report that it's being pressed.</span></span> <span data-ttu-id="2435b-422">位置の値には、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="2435b-422">The position values can be one of these strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="2435b-423">Up</span><span class="sxs-lookup"><span data-stu-id="2435b-423">Up</span></span></li> 
                <li><span data-ttu-id="2435b-424">UpRight</span><span class="sxs-lookup"><span data-stu-id="2435b-424">UpRight</span></span></li>
                <li><span data-ttu-id="2435b-425">Right</span><span class="sxs-lookup"><span data-stu-id="2435b-425">Right</span></span></li>
                <li><span data-ttu-id="2435b-426">DownRight</span><span class="sxs-lookup"><span data-stu-id="2435b-426">DownRight</span></span></li>
                <li><span data-ttu-id="2435b-427">Down</span><span class="sxs-lookup"><span data-stu-id="2435b-427">Down</span></span></li>
                <li><span data-ttu-id="2435b-428">DownLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-428">DownLeft</span></span></li>
                <li><span data-ttu-id="2435b-429">Left</span><span class="sxs-lookup"><span data-stu-id="2435b-429">Left</span></span></li>
                <li><span data-ttu-id="2435b-430">UpLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-430">UpLeft</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-431">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="2435b-431">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="2435b-432">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-432">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-433">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-433">No</span></span></td>
        <td><span data-ttu-id="2435b-434">隣接するスイッチの位置も、マッピングされたボタンが押されたことを報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-434">Indicates that adjacent switch positions will also cause the mapped button to report that it's being pressed.</span></span></td>
    </tr>
</table>

### <a name="axis-mapping"></a><span data-ttu-id="2435b-435">軸のマッピング</span><span class="sxs-lookup"><span data-stu-id="2435b-435">Axis mapping</span></span>

<span data-ttu-id="2435b-436">次の表は、軸のマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-436">The table below lists the values that are needed to map an axis:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-437">Source (ソース)</span><span class="sxs-lookup"><span data-stu-id="2435b-437">Source</span></span></th>
        <th><span data-ttu-id="2435b-438">値の名前</span><span class="sxs-lookup"><span data-stu-id="2435b-438">Value name</span></span></th>
        <th><span data-ttu-id="2435b-439">値の種類</span><span class="sxs-lookup"><span data-stu-id="2435b-439">Value type</span></span></th>
        <th><span data-ttu-id="2435b-440">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="2435b-440">Required?</span></span></th>
        <th><span data-ttu-id="2435b-441">値の情報</span><span class="sxs-lookup"><span data-stu-id="2435b-441">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-442">Button</span><span class="sxs-lookup"><span data-stu-id="2435b-442">Button</span></span></td>
        <td><span data-ttu-id="2435b-443">MaxValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-443">MaxValueButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-444">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-444">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-445">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-445">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-446">マッピングされた一方向の軸の値に変換される、<b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-446">Index in the <b>RawGameController</b> button array which gets translated to the mapped unidirectional axis value.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="2435b-447">MaxButton</span><span class="sxs-lookup"><span data-stu-id="2435b-447">MaxButton</span></span></th>
                    <th><span data-ttu-id="2435b-448">AxisValue</span><span class="sxs-lookup"><span data-stu-id="2435b-448">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-449">FALSE</span><span class="sxs-lookup"><span data-stu-id="2435b-449">FALSE</span></span></td>
                    <td><span data-ttu-id="2435b-450">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-450">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-451">TRUE</span><span class="sxs-lookup"><span data-stu-id="2435b-451">TRUE</span></span></td>
                    <td><span data-ttu-id="2435b-452">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-452">1.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-453">MinValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-453">MinValueButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-454">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-454">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-455">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-455">No</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-456">マッピングされた軸が双方向であることを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-456">Indicates that the mapped axis is bidirectional.</span></span> <span data-ttu-id="2435b-457"><b>MaxButton</b> と <b>MinButton</b> の値は結合され、次に示すように 1 つの双方向の軸となります。</span><span class="sxs-lookup"><span data-stu-id="2435b-457">Values of <b>MaxButton</b> and <b>MinButton</b> are combined into a single bidirectional axis as shown below.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="2435b-458">MinButton</span><span class="sxs-lookup"><span data-stu-id="2435b-458">MinButton</span></span></th>
                    <th><span data-ttu-id="2435b-459">MaxButton</span><span class="sxs-lookup"><span data-stu-id="2435b-459">MaxButton</span></span></th>
                    <th><span data-ttu-id="2435b-460">AxisValue</span><span class="sxs-lookup"><span data-stu-id="2435b-460">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-461">FALSE</span><span class="sxs-lookup"><span data-stu-id="2435b-461">FALSE</span></span></td>
                    <td><span data-ttu-id="2435b-462">FALSE</span><span class="sxs-lookup"><span data-stu-id="2435b-462">FALSE</span></span></td>
                    <td><span data-ttu-id="2435b-463">0.5</span><span class="sxs-lookup"><span data-stu-id="2435b-463">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-464">FALSE</span><span class="sxs-lookup"><span data-stu-id="2435b-464">FALSE</span></span></td>
                    <td><span data-ttu-id="2435b-465">TRUE</span><span class="sxs-lookup"><span data-stu-id="2435b-465">TRUE</span></span></td>
                    <td><span data-ttu-id="2435b-466">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-466">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-467">TRUE</span><span class="sxs-lookup"><span data-stu-id="2435b-467">TRUE</span></span></td>
                    <td><span data-ttu-id="2435b-468">FALSE</span><span class="sxs-lookup"><span data-stu-id="2435b-468">FALSE</span></span></td>
                    <td><span data-ttu-id="2435b-469">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-469">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-470">TRUE</span><span class="sxs-lookup"><span data-stu-id="2435b-470">TRUE</span></span></td>
                    <td><span data-ttu-id="2435b-471">TRUE</span><span class="sxs-lookup"><span data-stu-id="2435b-471">TRUE</span></span></td>
                    <td><span data-ttu-id="2435b-472">0.5</span><span class="sxs-lookup"><span data-stu-id="2435b-472">0.5</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-473">Axis</span><span class="sxs-lookup"><span data-stu-id="2435b-473">Axis</span></span></td>
        <td><span data-ttu-id="2435b-474">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-474">AxisIndex</span></span></td>
        <td><span data-ttu-id="2435b-475">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-475">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-476">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-476">Yes</span></span></td>
        <td><span data-ttu-id="2435b-477"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-477">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-478">Invert</span><span class="sxs-lookup"><span data-stu-id="2435b-478">Invert</span></span></td>
        <td><span data-ttu-id="2435b-479">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-479">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-480">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-480">No</span></span></td>
        <td><span data-ttu-id="2435b-481">マッピングされた軸の値を返す前に反転するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-481">Indicates that the mapped axis value should be inverted before it's returned.</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="2435b-482">Switch</span><span class="sxs-lookup"><span data-stu-id="2435b-482">Switch</span></span></td>
        <td><span data-ttu-id="2435b-483">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-483">SwitchIndex</span></span></td>
        <td><span data-ttu-id="2435b-484">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-484">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-485">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-485">Yes</span></span></td>
        <td><span data-ttu-id="2435b-486"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-486">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-487">MaxValueSwitchPosition</span><span class="sxs-lookup"><span data-stu-id="2435b-487">MaxValueSwitchPosition</span></span></td>
        <td><span data-ttu-id="2435b-488">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="2435b-488">REG_SZ</span></span></td>
        <td><span data-ttu-id="2435b-489">必須</span><span class="sxs-lookup"><span data-stu-id="2435b-489">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-490">次のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="2435b-490">One of the following strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="2435b-491">Up</span><span class="sxs-lookup"><span data-stu-id="2435b-491">Up</span></span></li>
                <li><span data-ttu-id="2435b-492">UpRight</span><span class="sxs-lookup"><span data-stu-id="2435b-492">UpRight</span></span></li>
                <li><span data-ttu-id="2435b-493">Right</span><span class="sxs-lookup"><span data-stu-id="2435b-493">Right</span></span></li>
                <li><span data-ttu-id="2435b-494">DownRight</span><span class="sxs-lookup"><span data-stu-id="2435b-494">DownRight</span></span></li>
                <li><span data-ttu-id="2435b-495">Down</span><span class="sxs-lookup"><span data-stu-id="2435b-495">Down</span></span></li>
                <li><span data-ttu-id="2435b-496">DownLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-496">DownLeft</span></span></li>
                <li><span data-ttu-id="2435b-497">Left</span><span class="sxs-lookup"><span data-stu-id="2435b-497">Left</span></span></li>
                <li><span data-ttu-id="2435b-498">UpLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-498">UpLeft</span></span></li>
            </ul>
            <p><span data-ttu-id="2435b-499">マッピングされた軸の値が 1.0 として報告されるスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-499">It indicates the position of the switch that causes the mapped axis value to be reported as 1.0.</span></span> <span data-ttu-id="2435b-500">反対方向の <b>MaxValueSwitchPosition</b> は 0.0 と見なされます。</span><span class="sxs-lookup"><span data-stu-id="2435b-500">The opposing direction of <b>MaxValueSwitchPosition</b> is treated as 0.0.</span></span> <span data-ttu-id="2435b-501">たとえば、<b>MaxValueSwitchPosition</b> が <b>Up</b> の場合、軸の値は次を意味します。</span><span class="sxs-lookup"><span data-stu-id="2435b-501">For example, if <b>MaxValueSwitchPosition</b> is <b>Up</b>, the axis value translation is shown below:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="2435b-502">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="2435b-502">Switch position</span></span></th>
                    <th><span data-ttu-id="2435b-503">AxisValue</span><span class="sxs-lookup"><span data-stu-id="2435b-503">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-504">Up</span><span class="sxs-lookup"><span data-stu-id="2435b-504">Up</span></span></td>
                    <td><span data-ttu-id="2435b-505">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-505">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-506">Center</span><span class="sxs-lookup"><span data-stu-id="2435b-506">Center</span></span></td>
                    <td><span data-ttu-id="2435b-507">0.5</span><span class="sxs-lookup"><span data-stu-id="2435b-507">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-508">Down</span><span class="sxs-lookup"><span data-stu-id="2435b-508">Down</span></span></td>
                    <td><span data-ttu-id="2435b-509">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-509">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-510">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="2435b-510">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="2435b-511">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-511">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-512">必須ではない</span><span class="sxs-lookup"><span data-stu-id="2435b-512">No</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-513">隣接するスイッチの位置も、マッピングされた軸が 1.0 を報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-513">Indicates that adjacent switch positions will also cause the mapped axis to report 1.0.</span></span> <span data-ttu-id="2435b-514">上記の例では、<b>IncludeAdjacent</b> が設定されている場合、軸は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2435b-514">In the above example, if <b>IncludeAdjacent</b> is set, then the axis translation is done as follows:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="2435b-515">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="2435b-515">Switch position</span></span></th>
                    <th><span data-ttu-id="2435b-516">AxisValue</span><span class="sxs-lookup"><span data-stu-id="2435b-516">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-517">Up</span><span class="sxs-lookup"><span data-stu-id="2435b-517">Up</span></span></td>
                    <td><span data-ttu-id="2435b-518">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-518">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-519">UpRight</span><span class="sxs-lookup"><span data-stu-id="2435b-519">UpRight</span></span></td>
                    <td><span data-ttu-id="2435b-520">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-520">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-521">UpLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-521">UpLeft</span></span></td>
                    <td><span data-ttu-id="2435b-522">1.0</span><span class="sxs-lookup"><span data-stu-id="2435b-522">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-523">Center</span><span class="sxs-lookup"><span data-stu-id="2435b-523">Center</span></span></td>
                    <td><span data-ttu-id="2435b-524">0.5</span><span class="sxs-lookup"><span data-stu-id="2435b-524">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-525">Down</span><span class="sxs-lookup"><span data-stu-id="2435b-525">Down</span></span></td>
                    <td><span data-ttu-id="2435b-526">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-526">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-527">DownRight</span><span class="sxs-lookup"><span data-stu-id="2435b-527">DownRight</span></span></td>
                    <td><span data-ttu-id="2435b-528">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-528">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-529">DownLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-529">DownLeft</span></span></td>
                    <td><span data-ttu-id="2435b-530">0.0</span><span class="sxs-lookup"><span data-stu-id="2435b-530">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

### <a name="switch-mapping"></a><span data-ttu-id="2435b-531">スイッチのマッピング</span><span class="sxs-lookup"><span data-stu-id="2435b-531">Switch mapping</span></span>

<span data-ttu-id="2435b-532">スイッチの位置は、**RawGameController** のボタンの配列のボタンのセットから、またはスイッチの配列のインデックスからマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="2435b-532">Switch positions can be mapped either from a set of buttons in the buttons array of the **RawGameController** or from an index in the switches array.</span></span> <span data-ttu-id="2435b-533">軸からスイッチの位置をマッピングすることはできません。</span><span class="sxs-lookup"><span data-stu-id="2435b-533">Switch positions can't be mapped from axes.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-534">Source (ソース)</span><span class="sxs-lookup"><span data-stu-id="2435b-534">Source</span></span></th>
        <th><span data-ttu-id="2435b-535">値の名前</span><span class="sxs-lookup"><span data-stu-id="2435b-535">Value name</span></span></th>
        <th><span data-ttu-id="2435b-536">値の種類</span><span class="sxs-lookup"><span data-stu-id="2435b-536">Value type</span></span></th>
        <th><span data-ttu-id="2435b-537">値の情報</span><span class="sxs-lookup"><span data-stu-id="2435b-537">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="10" style="vertical-align: middle;"><span data-ttu-id="2435b-538">Button</span><span class="sxs-lookup"><span data-stu-id="2435b-538">Button</span></span></td>
        <td><span data-ttu-id="2435b-539">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="2435b-539">ButtonCount</span></span></td>
        <td><span data-ttu-id="2435b-540">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-540">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-541">2、4、または 8</span><span class="sxs-lookup"><span data-stu-id="2435b-541">2, 4, or 8</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-542">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="2435b-542">SwitchKind</span></span></td>
        <td><span data-ttu-id="2435b-543">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="2435b-543">REG_SZ</span></span></td>
        <td><span data-ttu-id="2435b-544"><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></span><span class="sxs-lookup"><span data-stu-id="2435b-544"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b></span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-545">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-545">UpButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-546">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-546">DWORD</span></span></td>
        <td rowspan="8" style="vertical-align: middle;"><span data-ttu-id="2435b-547">「<a href="#buttonindex-values">\*ButtonIndex の値</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2435b-547">See <a href="#buttonindex-values">\*ButtonIndex values</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-548">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-548">DownButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-549">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-549">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-550">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-550">LeftButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-551">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-551">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-552">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-552">RightButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-553">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-553">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-554">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-554">UpRightButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-555">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-555">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-556">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-556">DownRightButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-557">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-557">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-558">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-558">DownLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-559">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-559">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-560">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-560">UpLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="2435b-561">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-561">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="9" style="vertical-align: middle;"><span data-ttu-id="2435b-562">Axis</span><span class="sxs-lookup"><span data-stu-id="2435b-562">Axis</span></span></td>
        <td><span data-ttu-id="2435b-563">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="2435b-563">SwitchKind</span></span></td>
        <td><span data-ttu-id="2435b-564">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="2435b-564">REG_SZ</span></span></td>
        <td><span data-ttu-id="2435b-565"><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></span><span class="sxs-lookup"><span data-stu-id="2435b-565"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-566">XAxisIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-566">XAxisIndex</span></span></td>
        <td><span data-ttu-id="2435b-567">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-567">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-568"><b>YAxisIndex</b> は常に存在します。</span><span class="sxs-lookup"><span data-stu-id="2435b-568"><b>YAxisIndex</b> is always present.</span></span> <span data-ttu-id="2435b-569"><b>XAxisIndex</b> は、<b>SwitchKind</b> が <b>FourWay</b> または <b>EightWay</b> の場合のみ存在します。</span><span class="sxs-lookup"><span data-stu-id="2435b-569"><b>XAxisIndex</b> is only present when <b>SwitchKind</b> is <b>FourWay</b> or <b>EightWay</b>.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-570">YAxisIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-570">YAxisIndex</span></span></td>
        <td><span data-ttu-id="2435b-571">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-571">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-572">XDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="2435b-572">XDeadZonePercent</span></span></td>
        <td><span data-ttu-id="2435b-573">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-573">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-574">軸の中央位置の周囲のデッド ゾーンのサイズを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-574">Indicate the size of the dead zone around the center position of the axes.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-575">YDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="2435b-575">YDeadZonePercent</span></span></td>
        <td><span data-ttu-id="2435b-576">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-576">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-577">XDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="2435b-577">XDebouncePercent</span></span></td>
        <td><span data-ttu-id="2435b-578">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-578">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-579">デッド ゾーンの上限と下限の周囲のウィンドウのサイズを定義します。これは報告されたスイッチの状態のデバウンスに使用されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-579">Define the size of the windows around the upper and lower dead zone limits, which are used to de-bounce the reported switch state.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-580">YDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="2435b-580">YDebouncePercent</span></span></td>
        <td><span data-ttu-id="2435b-581">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-581">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-582">XInvert</span><span class="sxs-lookup"><span data-stu-id="2435b-582">XInvert</span></span></td>
        <td><span data-ttu-id="2435b-583">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-583">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="2435b-584">デッド ゾーンとデバウンス ウィンドウの計算を適用する前に、対応する軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-584">Indicate that the corresponding axis values should be inverted before the dead zone and debounce window calculations are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-585">YInvert</span><span class="sxs-lookup"><span data-stu-id="2435b-585">YInvert</span></span></td>
        <td><span data-ttu-id="2435b-586">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-586">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="2435b-587">Switch</span><span class="sxs-lookup"><span data-stu-id="2435b-587">Switch</span></span></td>
        <td><span data-ttu-id="2435b-588">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-588">SwitchIndex</span></span></td>
        <td><span data-ttu-id="2435b-589">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-589">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-590"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="2435b-590">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-591">Invert</span><span class="sxs-lookup"><span data-stu-id="2435b-591">Invert</span></span></td>
        <td><span data-ttu-id="2435b-592">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-592">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-593">スイッチが位置を、既定の時計回りの順序ではなく、反時計回りの順序で報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-593">Indicates that the switch reports its positions in a counter-clockwise order, rather than the default clockwise order.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-594">PositionBias</span><span class="sxs-lookup"><span data-stu-id="2435b-594">PositionBias</span></span></td>
        <td><span data-ttu-id="2435b-595">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-595">DWORD</span></span></td>
        <td>
            <p><span data-ttu-id="2435b-596">位置の報告の開始点を指定した量だけ移動します。</span><span class="sxs-lookup"><span data-stu-id="2435b-596">Shifts the starting point of how positions are reported by the specified amount.</span></span> <span data-ttu-id="2435b-597"><b>PositionBias</b> は常に元の開始点から時計回りにカウントされます。値の順序が反転される前に適用されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-597"><b>PositionBias</b> is always counted clockwise from the original starting point, and is applied before the order of values is reversed.</span></span></p>
            <p><span data-ttu-id="2435b-598">たとえば、<b>DownRight</b>で始まる位置を反時計回りの順序で報告するスイッチは、<b>Invert</b> フラグを設定して、<b>PositionBias</b> を 5 と設定することによって正規化されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-598">For example, a switch that reports positions starting with <b>DownRight</b> in counter-clockwise order can be normalized by setting the <b>Invert</b> flag and specifying a <b>PositionBias</b> of 5:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="2435b-599">位置</span><span class="sxs-lookup"><span data-stu-id="2435b-599">Position</span></span></th>
                    <th><span data-ttu-id="2435b-600">報告される値</span><span class="sxs-lookup"><span data-stu-id="2435b-600">Reported value</span></span></th>
                    <th><span data-ttu-id="2435b-601">PositionBias と Invert フラグの設定後</span><span class="sxs-lookup"><span data-stu-id="2435b-601">After PositionBias and Invert flags</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-602">DownRight</span><span class="sxs-lookup"><span data-stu-id="2435b-602">DownRight</span></span></td>
                    <td><span data-ttu-id="2435b-603">0</span><span class="sxs-lookup"><span data-stu-id="2435b-603">0</span></span></td>
                    <td><span data-ttu-id="2435b-604">3</span><span class="sxs-lookup"><span data-stu-id="2435b-604">3</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-605">Right</span><span class="sxs-lookup"><span data-stu-id="2435b-605">Right</span></span></td>
                    <td><span data-ttu-id="2435b-606">1</span><span class="sxs-lookup"><span data-stu-id="2435b-606">1</span></span></td>
                    <td><span data-ttu-id="2435b-607">2</span><span class="sxs-lookup"><span data-stu-id="2435b-607">2</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-608">UpRight</span><span class="sxs-lookup"><span data-stu-id="2435b-608">UpRight</span></span></td>
                    <td><span data-ttu-id="2435b-609">2</span><span class="sxs-lookup"><span data-stu-id="2435b-609">2</span></span></td>
                    <td><span data-ttu-id="2435b-610">1</span><span class="sxs-lookup"><span data-stu-id="2435b-610">1</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-611">Up</span><span class="sxs-lookup"><span data-stu-id="2435b-611">Up</span></span></td>
                    <td><span data-ttu-id="2435b-612">3</span><span class="sxs-lookup"><span data-stu-id="2435b-612">3</span></span></td>
                    <td><span data-ttu-id="2435b-613">0</span><span class="sxs-lookup"><span data-stu-id="2435b-613">0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-614">UpLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-614">UpLeft</span></span></td>
                    <td><span data-ttu-id="2435b-615">4</span><span class="sxs-lookup"><span data-stu-id="2435b-615">4</span></span></td>
                    <td><span data-ttu-id="2435b-616">7</span><span class="sxs-lookup"><span data-stu-id="2435b-616">7</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-617">Left</span><span class="sxs-lookup"><span data-stu-id="2435b-617">Left</span></span></td>
                    <td><span data-ttu-id="2435b-618">5</span><span class="sxs-lookup"><span data-stu-id="2435b-618">5</span></span></td>
                    <td><span data-ttu-id="2435b-619">6</span><span class="sxs-lookup"><span data-stu-id="2435b-619">6</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-620">DownLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-620">DownLeft</span></span></td>
                    <td><span data-ttu-id="2435b-621">6</span><span class="sxs-lookup"><span data-stu-id="2435b-621">6</span></span></td>
                    <td><span data-ttu-id="2435b-622">5</span><span class="sxs-lookup"><span data-stu-id="2435b-622">5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="2435b-623">Down</span><span class="sxs-lookup"><span data-stu-id="2435b-623">Down</span></span></td>
                    <td><span data-ttu-id="2435b-624">7</span><span class="sxs-lookup"><span data-stu-id="2435b-624">7</span></span></td>
                    <td><span data-ttu-id="2435b-625">4</span><span class="sxs-lookup"><span data-stu-id="2435b-625">4</span></span></td>
                </tr>
            </table>
    </tr>
</table>

#### <a name="buttonindex-values"></a><span data-ttu-id="2435b-626">\*ButtonIndex の値</span><span class="sxs-lookup"><span data-stu-id="2435b-626">\*ButtonIndex values</span></span>

<span data-ttu-id="2435b-627">**RawGameController** のボタンの配列への \*ButtonIndex の値のインデックス:</span><span class="sxs-lookup"><span data-stu-id="2435b-627">\*ButtonIndex values index into the **RawGameController**'s button array:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-628">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="2435b-628">ButtonCount</span></span></th>
        <th><span data-ttu-id="2435b-629">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="2435b-629">SwitchKind</span></span></th>
        <th><span data-ttu-id="2435b-630">RequiredMappings</span><span class="sxs-lookup"><span data-stu-id="2435b-630">RequiredMappings</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-631">2</span><span class="sxs-lookup"><span data-stu-id="2435b-631">2</span></span></td>
        <td><span data-ttu-id="2435b-632">TwoWay</span><span class="sxs-lookup"><span data-stu-id="2435b-632">TwoWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="2435b-633">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-633">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-634">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-634">DownButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-635">4</span><span class="sxs-lookup"><span data-stu-id="2435b-635">4</span></span></td>
        <td><span data-ttu-id="2435b-636">FourWay</span><span class="sxs-lookup"><span data-stu-id="2435b-636">FourWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="2435b-637">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-637">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-638">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-638">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-639">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-639">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-640">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-640">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-641">4</span><span class="sxs-lookup"><span data-stu-id="2435b-641">4</span></span></td>
        <td><span data-ttu-id="2435b-642">EightWay</span><span class="sxs-lookup"><span data-stu-id="2435b-642">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="2435b-643">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-643">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-644">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-644">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-645">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-645">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-646">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-646">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-647">8</span><span class="sxs-lookup"><span data-stu-id="2435b-647">8</span></span></td>
        <td><span data-ttu-id="2435b-648">EightWay</span><span class="sxs-lookup"><span data-stu-id="2435b-648">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="2435b-649">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-649">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-650">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-650">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-651">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-651">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-652">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-652">RightButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-653">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-653">UpRightButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-654">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-654">DownRightButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-655">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-655">DownLeftButtonIndex</span></span></li>
                <li><span data-ttu-id="2435b-656">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="2435b-656">UpLeftButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
</table>

### <a name="properties-mapping"></a><span data-ttu-id="2435b-657">プロパティ マッピング</span><span class="sxs-lookup"><span data-stu-id="2435b-657">Properties mapping</span></span>

<span data-ttu-id="2435b-658">これらは、別のマッピングの種類の、静的マッピング値です。</span><span class="sxs-lookup"><span data-stu-id="2435b-658">These are static mapping values for different mapping types.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-659">マッピング</span><span class="sxs-lookup"><span data-stu-id="2435b-659">Mapping</span></span></th>
        <th><span data-ttu-id="2435b-660">値の名前</span><span class="sxs-lookup"><span data-stu-id="2435b-660">Value name</span></span></th>
        <th><span data-ttu-id="2435b-661">値の種類</span><span class="sxs-lookup"><span data-stu-id="2435b-661">Value type</span></span></th>
        <th><span data-ttu-id="2435b-662">値の情報</span><span class="sxs-lookup"><span data-stu-id="2435b-662">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-663">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="2435b-663">RacingWheel</span></span></td>
        <td><span data-ttu-id="2435b-664">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="2435b-664">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="2435b-665">DWORD</span><span class="sxs-lookup"><span data-stu-id="2435b-665">DWORD</span></span></td>
        <td><span data-ttu-id="2435b-666">ホイールでサポートされている、単一方向の物理ホイールの最大角度を示します。</span><span class="sxs-lookup"><span data-stu-id="2435b-666">Indicates the maximum physical wheel angle supported by the wheel in a single direction.</span></span> <span data-ttu-id="2435b-667">たとえば、-90 度から 90 度まで回転できるホイールでは、90 を指定します。</span><span class="sxs-lookup"><span data-stu-id="2435b-667">For example, a wheel with a possible rotation of -90 degrees to 90 degrees would specify 90.</span></span></td>
    </tr>
</table>

## <a name="labels"></a><span data-ttu-id="2435b-668">Labels</span><span class="sxs-lookup"><span data-stu-id="2435b-668">Labels</span></span>

<span data-ttu-id="2435b-669">ラベルは、デバイス ルートの下の **Labels** キーの下に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2435b-669">Labels should be present under the **Labels** key under the device root.</span></span> <span data-ttu-id="2435b-670">**Labels** は 3 つのサブキー: **Buttons**、**Axes**、**Switches** を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="2435b-670">**Labels** can have 3 subkeys: **Buttons**, **Axes**, and **Switches**.</span></span>

### <a name="button-labels"></a><span data-ttu-id="2435b-671">ボタンのラベル</span><span class="sxs-lookup"><span data-stu-id="2435b-671">Button labels</span></span>

<span data-ttu-id="2435b-672">**Buttons** キーは、**RawGameController** のボタンの配列の各ボタンの位置を文字列にマッピングします。</span><span class="sxs-lookup"><span data-stu-id="2435b-672">The **Buttons** key maps each of the button positions in the **RawGameController**'s buttons array to a string.</span></span> <span data-ttu-id="2435b-673">各文字列は、対応する [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) 列挙値に内部的にマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="2435b-673">Each string is mapped internally to the corresponding [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) enum value.</span></span> <span data-ttu-id="2435b-674">たとえば、ゲームパッドに 10 個のボタンと、**RawGameController** がボタンを解析してボタンを表示する順序がある場合、レポートは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2435b-674">For example, if a gamepad has ten buttons and the order in which the **RawGameController** parses out the buttons and presents them in the buttons report is like this:</span></span>

```cpp
Menu,               // Index 0
View,               // Index 1
LeftStickButton,    // Index 2
RightStickButton,   // Index 3
LetterA,            // Index 4
LetterB,            // Index 5
LetterX,            // Index 6
LetterY,            // Index 7
LeftBumper,         // Index 8
RightBumper         // Index 9
```

<span data-ttu-id="2435b-675">ラベルは **Buttons** キーの下にこの順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="2435b-675">The labels should appear in this order under the **Buttons** key:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="2435b-676">名前</span><span class="sxs-lookup"><span data-stu-id="2435b-676">Name</span></span></th>
        <th><span data-ttu-id="2435b-677">値 (種類: REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="2435b-677">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-678">Button0</span><span class="sxs-lookup"><span data-stu-id="2435b-678">Button0</span></span></td>
        <td><span data-ttu-id="2435b-679">Menu</span><span class="sxs-lookup"><span data-stu-id="2435b-679">Menu</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-680">Button1</span><span class="sxs-lookup"><span data-stu-id="2435b-680">Button1</span></span></td>
        <td><span data-ttu-id="2435b-681">View</span><span class="sxs-lookup"><span data-stu-id="2435b-681">View</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-682">Button2</span><span class="sxs-lookup"><span data-stu-id="2435b-682">Button2</span></span></td>
        <td><span data-ttu-id="2435b-683">LeftStickButton</span><span class="sxs-lookup"><span data-stu-id="2435b-683">LeftStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-684">Button3</span><span class="sxs-lookup"><span data-stu-id="2435b-684">Button3</span></span></td>
        <td><span data-ttu-id="2435b-685">RightStickButton</span><span class="sxs-lookup"><span data-stu-id="2435b-685">RightStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-686">Button4</span><span class="sxs-lookup"><span data-stu-id="2435b-686">Button4</span></span></td>
        <td><span data-ttu-id="2435b-687">LetterA</span><span class="sxs-lookup"><span data-stu-id="2435b-687">LetterA</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-688">Button5</span><span class="sxs-lookup"><span data-stu-id="2435b-688">Button5</span></span></td>
        <td><span data-ttu-id="2435b-689">LetterB</span><span class="sxs-lookup"><span data-stu-id="2435b-689">LetterB</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-690">Button6</span><span class="sxs-lookup"><span data-stu-id="2435b-690">Button6</span></span></td>
        <td><span data-ttu-id="2435b-691">LetterX</span><span class="sxs-lookup"><span data-stu-id="2435b-691">LetterX</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-692">Button7</span><span class="sxs-lookup"><span data-stu-id="2435b-692">Button7</span></span></td>
        <td><span data-ttu-id="2435b-693">LetterY</span><span class="sxs-lookup"><span data-stu-id="2435b-693">LetterY</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-694">Button8</span><span class="sxs-lookup"><span data-stu-id="2435b-694">Button8</span></span></td>
        <td><span data-ttu-id="2435b-695">LeftBumper</span><span class="sxs-lookup"><span data-stu-id="2435b-695">LeftBumper</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-696">Button9</span><span class="sxs-lookup"><span data-stu-id="2435b-696">Button9</span></span></td>
        <td><span data-ttu-id="2435b-697">RightBumper</span><span class="sxs-lookup"><span data-stu-id="2435b-697">RightBumper</span></span></td>
    </tr>
</table>

### <a name="axis-labels"></a><span data-ttu-id="2435b-698">軸ラベル</span><span class="sxs-lookup"><span data-stu-id="2435b-698">Axis labels</span></span>

<span data-ttu-id="2435b-699">**Axes** キーは、**RawGameController** の軸の配列の各軸の位置を、ボタンのラベルのように、[GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) に一覧表示されたラベルの 1 つにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="2435b-699">The **Axes** key will map each of the axis positions in the **RawGameController**'s axis array to one of the labels listed in [GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) just like the button labels.</span></span> <span data-ttu-id="2435b-700">「[ボタンのラベル](#button-labels)」の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2435b-700">See the example in [Button labels](#button-labels).</span></span>

### <a name="switch-labels"></a><span data-ttu-id="2435b-701">スイッチのラベル</span><span class="sxs-lookup"><span data-stu-id="2435b-701">Switch labels</span></span>

<span data-ttu-id="2435b-702">**Switches** キーはスイッチの位置をラベルにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="2435b-702">The **Switches** key maps switch positions to labels.</span></span> <span data-ttu-id="2435b-703">値は次の名前付け規則に従います: インデックスが **RawGameController** のスイッチの配列の *x*であるスイッチの位置にラベルを付けるには、次の値を **Switches** サブキーの下に追加します。</span><span class="sxs-lookup"><span data-stu-id="2435b-703">The values follow this naming convention: to label a position of a switch, whose index is *x* in the **RawGameController**'s switch array, add these values under the **Switches** subkey:</span></span> 

* <span data-ttu-id="2435b-704">SwitchxUp</span><span class="sxs-lookup"><span data-stu-id="2435b-704">SwitchxUp</span></span> 
* <span data-ttu-id="2435b-705">SwitchxUpRight</span><span class="sxs-lookup"><span data-stu-id="2435b-705">SwitchxUpRight</span></span> 
* <span data-ttu-id="2435b-706">SwitchxRight</span><span class="sxs-lookup"><span data-stu-id="2435b-706">SwitchxRight</span></span>
* <span data-ttu-id="2435b-707">SwitchxDownRight</span><span class="sxs-lookup"><span data-stu-id="2435b-707">SwitchxDownRight</span></span>
* <span data-ttu-id="2435b-708">SwitchxDown</span><span class="sxs-lookup"><span data-stu-id="2435b-708">SwitchxDown</span></span>
* <span data-ttu-id="2435b-709">SwitchxDownLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-709">SwitchxDownLeft</span></span>
* <span data-ttu-id="2435b-710">SwitchxUpLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-710">SwitchxUpLeft</span></span>
* <span data-ttu-id="2435b-711">SwitchxLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-711">SwitchxLeft</span></span>

<span data-ttu-id="2435b-712">次の表は、4 方向スイッチの位置が **RawGameController** でインデックス 0 を示しているスイッチにラベルを付ける例を示しています。</span><span class="sxs-lookup"><span data-stu-id="2435b-712">The following table shows an example set of labels for switch positions of a 4-way switch which shows up at index 0 in the **RawGameController**:</span></span> 

<table>
    <tr>
        <th><span data-ttu-id="2435b-713">名前</span><span class="sxs-lookup"><span data-stu-id="2435b-713">Name</span></span></th>
        <th><span data-ttu-id="2435b-714">値 (種類: REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="2435b-714">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-715">Switch0Up</span><span class="sxs-lookup"><span data-stu-id="2435b-715">Switch0Up</span></span></td>
        <td><span data-ttu-id="2435b-716">XboxUp</span><span class="sxs-lookup"><span data-stu-id="2435b-716">XboxUp</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-717">Switch0Right</span><span class="sxs-lookup"><span data-stu-id="2435b-717">Switch0Right</span></span></td>
        <td><span data-ttu-id="2435b-718">XboxRight</span><span class="sxs-lookup"><span data-stu-id="2435b-718">XboxRight</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-719">Switch0Down</span><span class="sxs-lookup"><span data-stu-id="2435b-719">Switch0Down</span></span></td>
        <td><span data-ttu-id="2435b-720">XboxDown</span><span class="sxs-lookup"><span data-stu-id="2435b-720">XboxDown</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="2435b-721">Switch0Left</span><span class="sxs-lookup"><span data-stu-id="2435b-721">Switch0Left</span></span></td>
        <td><span data-ttu-id="2435b-722">XboxLeft</span><span class="sxs-lookup"><span data-stu-id="2435b-722">XboxLeft</span></span></td>
    </tr>
</table>

<!--### Label strings

* XboxBack
* XboxStart
* XboxMenu
* XboxView
* XboxUp
* XboxDown
* XboxLeft
* XboxRight
* XboxA
* XboxB
* XboxX
* XboxY
* XboxLeftBumper
* XboxLeftTrigger
* XboxLeftStickButton
* XboxRightBumper
* XboxRightTrigger
* XboxRightStickButton
* XboxPaddle1
* XboxPaddle2
* XboxPaddle3
* XboxPaddle4
* Mode
* Select
* Menu
* View
* Back
* Start
* Options
* Share
* Up
* Down
* Left
* Right
* LetterA
* LetterB
* LetterC
* LetterL
* LetterR
* LetterX
* LetterY
* LetterZ
* Cross
* Circle
* Square
* Triangle
* LeftBumper
* LeftTrigger
* LeftStickButton
* Left1
* Left2
* Left3
* RightBumper
* RightTrigger
* RightStickButton
* Right1
* Right2
* Right3
* Paddle1
* Paddle2
* Paddle3
* Paddle4
* Plus
* Minus
* DownLeftArrow
* DialLeft
* DialRight
* Suspension-->

## <a name="example-registry-file"></a><span data-ttu-id="2435b-723">レジストリ ファイルの例</span><span class="sxs-lookup"><span data-stu-id="2435b-723">Example registry file</span></span>

<span data-ttu-id="2435b-724">これらのマッピングと値のすべての例を示すため、汎用の **RacingWheel** のレジストリ ファイルを示す次の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2435b-724">To show how all of these mappings and values come together, here is an example registry file for a generic **RacingWheel**:</span></span>

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004]
"Description" = "Example Wheel Device"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\Labels\Buttons]
"Button0" = "LetterA"
"Button1" = "LetterB"
"Button2" = "LetterX"
"Button3" = "LetterY"
"Button6" = "Menu"
"Button7" = "View"
"Button8" = "RightStickButton"
"Button9" = "LeftStickButton"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\Labels\Switches]
"Switch0Down" = "Down"
"Switch0Left" = "Left"
"Switch0Right" = "Right"
"Switch0Up" = "Up"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel]
"MaxWheelAngle" = dword:000001c2

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Brake]
"AxisIndex" = dword:00000002
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button1]
"ButtonIndex" = dword:00000000

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button2]
"ButtonIndex" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button3]
"ButtonIndex" = dword:00000002

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button4]
"ButtonIndex" = dword:00000003

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button5]
"ButtonIndex" = dword:00000009

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button6]
"ButtonIndex" = dword:00000008

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button7]
"ButtonIndex" = dword:00000007

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button8]
"ButtonIndex" = dword:00000006

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Clutch]
"AxisIndex" = dword:00000003
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadDown]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Down"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadLeft]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Left"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadRight]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Right"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadUp]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Up"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FifthGear]
"ButtonIndex" = dword:00000010

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FirstGear]
"ButtonIndex" = dword:0000000c

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FourthGear]
"ButtonIndex" = dword:0000000f

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\NextGear]
"ButtonIndex" = dword:00000004

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\PreviousGear]
"ButtonIndex" = dword:00000005

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\ReverseGear]
"ButtonIndex" = dword:0000000b

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\SecondGear]
"ButtonIndex" = dword:0000000d

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\SixthGear]
"ButtonIndex" = dword:00000011

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\ThirdGear]
"ButtonIndex" = dword:0000000e

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Throttle]
"AxisIndex" = dword:00000001
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Wheel]
"AxisIndex" = dword:00000000
"Invert" = dword:00000000
```

## <a name="see-also"></a><span data-ttu-id="2435b-725">関連項目</span><span class="sxs-lookup"><span data-stu-id="2435b-725">See also</span></span>

* [<span data-ttu-id="2435b-726">Windows.Gaming.Input 名前空間</span><span class="sxs-lookup"><span data-stu-id="2435b-726">Windows.Gaming.Input Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [<span data-ttu-id="2435b-727">Windows.Gaming.Input.Custom 名前空間</span><span class="sxs-lookup"><span data-stu-id="2435b-727">Windows.Gaming.Input.Custom Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)
* [<span data-ttu-id="2435b-728">INF ファイル</span><span class="sxs-lookup"><span data-stu-id="2435b-728">INF Files</span></span>](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)