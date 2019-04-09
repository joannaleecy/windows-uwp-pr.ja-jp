---
title: ゲーム コントローラーのレジストリ データ
description: UWP ゲームで使用されるコントローラーを有効にするために、PC のレジストリに追加できるデータについて説明します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.date: 4/8/2019
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, レジストリ, カスタム
ms.localizationpriority: medium
ms.openlocfilehash: 5578faeb5a35ae909e590741de759c2597b9c7ed
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244398"
---
# <a name="registry-data-for-game-controllers"></a><span data-ttu-id="8f156-104">ゲーム コントローラーのレジストリ データ</span><span class="sxs-lookup"><span data-stu-id="8f156-104">Registry data for game controllers</span></span>

> [!NOTE]
> <span data-ttu-id="8f156-105">このトピックは、Windows 10 互換のゲーム コントローラーの製造元向けです。開発者の大部分には適用されません。</span><span class="sxs-lookup"><span data-stu-id="8f156-105">This topic is meant for manufacturers of Windows 10-compatible game controllers, and doesn't apply to the majority of developers.</span></span>

<span data-ttu-id="8f156-106">[Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)を使うと、独立系ハードウェア ベンダー (IHV) は、PC のレジストリにデータを追加して、デバイスが [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad)、[RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel)、[ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) として表示されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="8f156-106">The [Windows.Gaming.Input namespace](https://docs.microsoft.com/uwp/api/windows.gaming.input) allows independent hardware vendors (IHVs) to add data to the PC's registry, enabling their devices to appear as [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad), [RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel), [ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick), [FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick), and [UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) as appropriate.</span></span> <span data-ttu-id="8f156-107">互換性のあるコントローラー用にこのデータを追加することを、すべての IHV に推奨します。</span><span class="sxs-lookup"><span data-stu-id="8f156-107">All IHVs should add this data for their compatible controllers.</span></span> <span data-ttu-id="8f156-108">これにより、すべての UWP ゲーム (および WinRT API を使用するすべてのデスクトップ ゲーム) でゲーム コントローラーをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="8f156-108">By doing this, all UWP games (and any desktop games that use the WinRT API) will be able to support your game controller.</span></span>

## <a name="mapping-scheme"></a><span data-ttu-id="8f156-109">マッピング スキーム</span><span class="sxs-lookup"><span data-stu-id="8f156-109">Mapping scheme</span></span>

<span data-ttu-id="8f156-110">デバイスのマッピングとして、ベンダー ID (VID) **VVVV**、製品 ID (PID) **PPPP**、使用ページ **UUUU**、使用 ID **XXXX** が、レジストリのこの場所から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="8f156-110">Mappings for a device with Vendor ID (VID) **VVVV**, Product ID (PID) **PPPP**, Usage Page **UUUU**, and Usage ID **XXXX**, will be read out from this location in the registry:</span></span>

`HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\VVVVPPPPUUUUXXXX`

<span data-ttu-id="8f156-111">次の表は、デバイスのルートの場所で予期される値を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-111">The table below explains the expected values under the device root location:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-112">名前</span><span class="sxs-lookup"><span data-stu-id="8f156-112">Name</span></span></th>
        <th><span data-ttu-id="8f156-113">種類</span><span class="sxs-lookup"><span data-stu-id="8f156-113">Type</span></span></th>
        <th><span data-ttu-id="8f156-114">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-114">Required?</span></span></th>
        <th><span data-ttu-id="8f156-115">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-115">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-116">Disabled</span><span class="sxs-lookup"><span data-stu-id="8f156-116">Disabled</span></span></td>
        <td><span data-ttu-id="8f156-117">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-117">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-118">X</span><span class="sxs-lookup"><span data-stu-id="8f156-118">No</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-119">この特定のデバイスを無効になっていることを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-119">Indicates that this particular device should be disabled.</span></span></p>
            <ul>
                <li><span data-ttu-id="8f156-120"><b>0</b>:デバイスが無効になっていません。</span><span class="sxs-lookup"><span data-stu-id="8f156-120"><b>0</b>: Device is not disabled.</span></span></li>
                <li><span data-ttu-id="8f156-121"><b>1</b>:デバイスが無効です。</span><span class="sxs-lookup"><span data-stu-id="8f156-121"><b>1</b>: Device is disabled.</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-122">説明</span><span class="sxs-lookup"><span data-stu-id="8f156-122">Description</span></span></td>
        <td><span data-ttu-id="8f156-123">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="8f156-123">REG_SZ</span></span> <td><span data-ttu-id="8f156-124">X</span><span class="sxs-lookup"><span data-stu-id="8f156-124">No</span></span></td>
        <td><span data-ttu-id="8f156-125">デバイスの簡単な説明です。</span><span class="sxs-lookup"><span data-stu-id="8f156-125">A short description of the device.</span></span></td>
    </tr>
</table>

<span data-ttu-id="8f156-126">デバイスのインストーラーが (セットアップ、または [INF ファイル](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)によって) このデータをレジストリに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f156-126">Your device installer should add this data to the registry (either via setup or an [INF file](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)).</span></span>

<span data-ttu-id="8f156-127">デバイスのルートの場所の下のサブキーは、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="8f156-127">Subkeys under the device root location are detailed in the following sections.</span></span>

### <a name="gamepad"></a><span data-ttu-id="8f156-128">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="8f156-128">Gamepad</span></span>

<span data-ttu-id="8f156-129">次の表は **Gamepad** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-129">The table below lists the required and optional subkeys under the **Gamepad** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-130">サブキー</span><span class="sxs-lookup"><span data-stu-id="8f156-130">Subkey</span></span></th>
        <th><span data-ttu-id="8f156-131">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-131">Required?</span></span></th>
        <th><span data-ttu-id="8f156-132">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-132">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-133">Menu</span><span class="sxs-lookup"><span data-stu-id="8f156-133">Menu</span></span></td>
        <td><span data-ttu-id="8f156-134">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-134">Yes</span></span></td>
        <td rowspan="18" style="vertical-align: middle;"><span data-ttu-id="8f156-135">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-135">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-136">表示</span><span class="sxs-lookup"><span data-stu-id="8f156-136">View</span></span></td>
        <td><span data-ttu-id="8f156-137">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-137">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-138">A</span><span class="sxs-lookup"><span data-stu-id="8f156-138">A</span></span></td>
        <td><span data-ttu-id="8f156-139">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-139">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-140">B</span><span class="sxs-lookup"><span data-stu-id="8f156-140">B</span></span></td>
        <td><span data-ttu-id="8f156-141">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-141">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-142">x</span><span class="sxs-lookup"><span data-stu-id="8f156-142">X</span></span></td>
        <td><span data-ttu-id="8f156-143">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-143">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-144">Y</span><span class="sxs-lookup"><span data-stu-id="8f156-144">Y</span></span></td>
        <td><span data-ttu-id="8f156-145">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-145">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-146">LeftShoulder</span><span class="sxs-lookup"><span data-stu-id="8f156-146">LeftShoulder</span></span></td>
        <td><span data-ttu-id="8f156-147">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-147">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-148">RightShoulder</span><span class="sxs-lookup"><span data-stu-id="8f156-148">RightShoulder</span></span></td>
        <td><span data-ttu-id="8f156-149">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-149">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-150">LeftThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="8f156-150">LeftThumbstickButton</span></span></td>
        <td><span data-ttu-id="8f156-151">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-151">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-152">RightThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="8f156-152">RightThumbstickButton</span></span></td>
        <td><span data-ttu-id="8f156-153">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-153">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-154">DPadUp</span><span class="sxs-lookup"><span data-stu-id="8f156-154">DPadUp</span></span></td>
        <td><span data-ttu-id="8f156-155">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-155">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-156">DPadDown</span><span class="sxs-lookup"><span data-stu-id="8f156-156">DPadDown</span></span></td>
        <td><span data-ttu-id="8f156-157">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-157">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-158">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-158">DPadLeft</span></span></td>
        <td><span data-ttu-id="8f156-159">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-159">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-160">DPadRight</span><span class="sxs-lookup"><span data-stu-id="8f156-160">DPadRight</span></span></td>
        <td><span data-ttu-id="8f156-161">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-161">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-162">Paddle1</span><span class="sxs-lookup"><span data-stu-id="8f156-162">Paddle1</span></span></td>
        <td><span data-ttu-id="8f156-163">X</span><span class="sxs-lookup"><span data-stu-id="8f156-163">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-164">Paddle2</span><span class="sxs-lookup"><span data-stu-id="8f156-164">Paddle2</span></span></td>
        <td><span data-ttu-id="8f156-165">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-165">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-166">Paddle3</span><span class="sxs-lookup"><span data-stu-id="8f156-166">Paddle3</span></span></td>
        <td><span data-ttu-id="8f156-167">X</span><span class="sxs-lookup"><span data-stu-id="8f156-167">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-168">Paddle4</span><span class="sxs-lookup"><span data-stu-id="8f156-168">Paddle4</span></span></td>
        <td><span data-ttu-id="8f156-169">X</span><span class="sxs-lookup"><span data-stu-id="8f156-169">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-170">LeftTrigger</span><span class="sxs-lookup"><span data-stu-id="8f156-170">LeftTrigger</span></span></td>
        <td><span data-ttu-id="8f156-171">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-171">Yes</span></span></td>
        <td rowspan="6" style="vertical-align: middle;"><span data-ttu-id="8f156-172">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-172">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-173">RightTrigger</span><span class="sxs-lookup"><span data-stu-id="8f156-173">RightTrigger</span></span></td>
        <td><span data-ttu-id="8f156-174">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-174">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-175">LeftThumbstickX</span><span class="sxs-lookup"><span data-stu-id="8f156-175">LeftThumbstickX</span></span></td>
        <td><span data-ttu-id="8f156-176">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-176">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-177">LeftThumbstickY</span><span class="sxs-lookup"><span data-stu-id="8f156-177">LeftThumbstickY</span></span></td>
        <td><span data-ttu-id="8f156-178">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-178">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-179">RightThumbstickX</span><span class="sxs-lookup"><span data-stu-id="8f156-179">RightThumbstickX</span></span></td>
        <td><span data-ttu-id="8f156-180">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-180">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-181">RightThumbstickY</span><span class="sxs-lookup"><span data-stu-id="8f156-181">RightThumbstickY</span></span></td>
        <td><span data-ttu-id="8f156-182">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-182">Yes</span></span></td>
    </tr>
</table>

> [!NOTE]
> <span data-ttu-id="8f156-183">サポートされる **Gamepad** として、ゲーム コントローラーを追加する場合には、サポートされる **UINavigationController** としても、ゲーム コントローラーを追加することを強く推奨します。</span><span class="sxs-lookup"><span data-stu-id="8f156-183">If you add your game controller as a supported **Gamepad**, we highly recommend that you also add it as a supported **UINavigationController**.</span></span>

### <a name="racingwheel"></a><span data-ttu-id="8f156-184">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="8f156-184">RacingWheel</span></span>

<span data-ttu-id="8f156-185">次の表は **RacingWheel** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-185">The table below lists the required and optional subkeys under the **RacingWheel** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-186">サブキー</span><span class="sxs-lookup"><span data-stu-id="8f156-186">Subkey</span></span></th>
        <th><span data-ttu-id="8f156-187">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-187">Required?</span></span></th>
        <th><span data-ttu-id="8f156-188">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-188">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-189">PreviousGear</span><span class="sxs-lookup"><span data-stu-id="8f156-189">PreviousGear</span></span></td>
        <td><span data-ttu-id="8f156-190">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-190">Yes</span></span></td>
        <td rowspan="30" style="vertical-align: middle;"><span data-ttu-id="8f156-191">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-191">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-192">NextGear</span><span class="sxs-lookup"><span data-stu-id="8f156-192">NextGear</span></span></td>
        <td><span data-ttu-id="8f156-193">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-193">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-194">DPadUp</span><span class="sxs-lookup"><span data-stu-id="8f156-194">DPadUp</span></span></td>
        <td><span data-ttu-id="8f156-195">X</span><span class="sxs-lookup"><span data-stu-id="8f156-195">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-196">DPadDown</span><span class="sxs-lookup"><span data-stu-id="8f156-196">DPadDown</span></span></td>
        <td><span data-ttu-id="8f156-197">X</span><span class="sxs-lookup"><span data-stu-id="8f156-197">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-198">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-198">DPadLeft</span></span></td>
        <td><span data-ttu-id="8f156-199">X</span><span class="sxs-lookup"><span data-stu-id="8f156-199">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-200">DPadRight</span><span class="sxs-lookup"><span data-stu-id="8f156-200">DPadRight</span></span></td>
        <td><span data-ttu-id="8f156-201">X</span><span class="sxs-lookup"><span data-stu-id="8f156-201">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-202">Button1</span><span class="sxs-lookup"><span data-stu-id="8f156-202">Button1</span></span></td>
        <td><span data-ttu-id="8f156-203">X</span><span class="sxs-lookup"><span data-stu-id="8f156-203">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-204">Button2</span><span class="sxs-lookup"><span data-stu-id="8f156-204">Button2</span></span></td>
        <td><span data-ttu-id="8f156-205">X</span><span class="sxs-lookup"><span data-stu-id="8f156-205">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-206">Button3</span><span class="sxs-lookup"><span data-stu-id="8f156-206">Button3</span></span></td>
        <td><span data-ttu-id="8f156-207">X</span><span class="sxs-lookup"><span data-stu-id="8f156-207">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-208">Button4</span><span class="sxs-lookup"><span data-stu-id="8f156-208">Button4</span></span></td>
        <td><span data-ttu-id="8f156-209">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-209">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-210">Button5</span><span class="sxs-lookup"><span data-stu-id="8f156-210">Button5</span></span></td>
        <td><span data-ttu-id="8f156-211">X</span><span class="sxs-lookup"><span data-stu-id="8f156-211">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-212">Button6</span><span class="sxs-lookup"><span data-stu-id="8f156-212">Button6</span></span></td>
        <td><span data-ttu-id="8f156-213">X</span><span class="sxs-lookup"><span data-stu-id="8f156-213">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-214">Button7</span><span class="sxs-lookup"><span data-stu-id="8f156-214">Button7</span></span></td>
        <td><span data-ttu-id="8f156-215">X</span><span class="sxs-lookup"><span data-stu-id="8f156-215">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-216">Button8</span><span class="sxs-lookup"><span data-stu-id="8f156-216">Button8</span></span></td>
        <td><span data-ttu-id="8f156-217">X</span><span class="sxs-lookup"><span data-stu-id="8f156-217">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-218">Button9</span><span class="sxs-lookup"><span data-stu-id="8f156-218">Button9</span></span></td>
        <td><span data-ttu-id="8f156-219">X</span><span class="sxs-lookup"><span data-stu-id="8f156-219">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-220">Button10</span><span class="sxs-lookup"><span data-stu-id="8f156-220">Button10</span></span></td>
        <td><span data-ttu-id="8f156-221">X</span><span class="sxs-lookup"><span data-stu-id="8f156-221">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-222">Button11</span><span class="sxs-lookup"><span data-stu-id="8f156-222">Button11</span></span></td>
        <td><span data-ttu-id="8f156-223">X</span><span class="sxs-lookup"><span data-stu-id="8f156-223">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-224">Button12</span><span class="sxs-lookup"><span data-stu-id="8f156-224">Button12</span></span></td>
        <td><span data-ttu-id="8f156-225">X</span><span class="sxs-lookup"><span data-stu-id="8f156-225">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-226">Button13</span><span class="sxs-lookup"><span data-stu-id="8f156-226">Button13</span></span></td>
        <td><span data-ttu-id="8f156-227">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-227">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-228">Button14</span><span class="sxs-lookup"><span data-stu-id="8f156-228">Button14</span></span></td>
        <td><span data-ttu-id="8f156-229">X</span><span class="sxs-lookup"><span data-stu-id="8f156-229">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-230">Button15</span><span class="sxs-lookup"><span data-stu-id="8f156-230">Button15</span></span></td>
        <td><span data-ttu-id="8f156-231">X</span><span class="sxs-lookup"><span data-stu-id="8f156-231">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-232">Button16</span><span class="sxs-lookup"><span data-stu-id="8f156-232">Button16</span></span></td>
        <td><span data-ttu-id="8f156-233">X</span><span class="sxs-lookup"><span data-stu-id="8f156-233">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-234">FirstGear</span><span class="sxs-lookup"><span data-stu-id="8f156-234">FirstGear</span></span></td>
        <td><span data-ttu-id="8f156-235">X</span><span class="sxs-lookup"><span data-stu-id="8f156-235">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-236">SecondGear</span><span class="sxs-lookup"><span data-stu-id="8f156-236">SecondGear</span></span></td>
        <td><span data-ttu-id="8f156-237">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-237">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-238">ThirdGear</span><span class="sxs-lookup"><span data-stu-id="8f156-238">ThirdGear</span></span></td>
        <td><span data-ttu-id="8f156-239">X</span><span class="sxs-lookup"><span data-stu-id="8f156-239">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-240">FourthGear</span><span class="sxs-lookup"><span data-stu-id="8f156-240">FourthGear</span></span></td>
        <td><span data-ttu-id="8f156-241">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-241">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-242">FifthGear</span><span class="sxs-lookup"><span data-stu-id="8f156-242">FifthGear</span></span></td>
        <td><span data-ttu-id="8f156-243">X</span><span class="sxs-lookup"><span data-stu-id="8f156-243">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-244">SixthGear</span><span class="sxs-lookup"><span data-stu-id="8f156-244">SixthGear</span></span></td>
        <td><span data-ttu-id="8f156-245">X</span><span class="sxs-lookup"><span data-stu-id="8f156-245">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-246">SeventhGear</span><span class="sxs-lookup"><span data-stu-id="8f156-246">SeventhGear</span></span></td>
        <td><span data-ttu-id="8f156-247">X</span><span class="sxs-lookup"><span data-stu-id="8f156-247">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-248">ReverseGear</span><span class="sxs-lookup"><span data-stu-id="8f156-248">ReverseGear</span></span></td>
        <td><span data-ttu-id="8f156-249">X</span><span class="sxs-lookup"><span data-stu-id="8f156-249">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-250">Wheel</span><span class="sxs-lookup"><span data-stu-id="8f156-250">Wheel</span></span></td>
        <td><span data-ttu-id="8f156-251">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-251">Yes</span></span></td>
        <td rowspan="5" style="vertical-align: middle;"><span data-ttu-id="8f156-252">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-252">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-253">Throttle</span><span class="sxs-lookup"><span data-stu-id="8f156-253">Throttle</span></span></td>
        <td><span data-ttu-id="8f156-254">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-254">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-255">Brake</span><span class="sxs-lookup"><span data-stu-id="8f156-255">Brake</span></span></td>
        <td><span data-ttu-id="8f156-256">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-256">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-257">Clutch</span><span class="sxs-lookup"><span data-stu-id="8f156-257">Clutch</span></span></td>
        <td><span data-ttu-id="8f156-258">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-258">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-259">Handbrake</span><span class="sxs-lookup"><span data-stu-id="8f156-259">Handbrake</span></span></td>
        <td><span data-ttu-id="8f156-260">X</span><span class="sxs-lookup"><span data-stu-id="8f156-260">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-261">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="8f156-261">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="8f156-262">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-262">Yes</span></span></td>
        <td><span data-ttu-id="8f156-263">「<a href="#properties-mapping">プロパティ マッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-263">See <a href="#properties-mapping">Properties mapping</a></span></span></td>
    </tr>
</table>

### <a name="arcadestick"></a><span data-ttu-id="8f156-264">ArcadeStick</span><span class="sxs-lookup"><span data-stu-id="8f156-264">ArcadeStick</span></span>

<span data-ttu-id="8f156-265">次の表は **ArcadeStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-265">The table below lists the required and optional subkeys under the **ArcadeStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-266">サブキー</span><span class="sxs-lookup"><span data-stu-id="8f156-266">Subkey</span></span></th>
        <th><span data-ttu-id="8f156-267">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-267">Required?</span></span></th>
        <th><span data-ttu-id="8f156-268">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-268">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-269">Action1</span><span class="sxs-lookup"><span data-stu-id="8f156-269">Action 1</span></span></td>
        <td><span data-ttu-id="8f156-270">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-270">Yes</span></span></td>
        <td rowspan="12" style="vertical-align: middle;"><span data-ttu-id="8f156-271">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-271">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-272">Action2</span><span class="sxs-lookup"><span data-stu-id="8f156-272">Action2</span></span></td>
        <td><span data-ttu-id="8f156-273">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-273">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-274">Action3</span><span class="sxs-lookup"><span data-stu-id="8f156-274">Action3</span></span></td>
        <td><span data-ttu-id="8f156-275">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-275">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-276">Action4</span><span class="sxs-lookup"><span data-stu-id="8f156-276">Action4</span></span></td>
        <td><span data-ttu-id="8f156-277">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-277">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-278">Action5</span><span class="sxs-lookup"><span data-stu-id="8f156-278">Action5</span></span></td>
        <td><span data-ttu-id="8f156-279">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-279">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-280">Action6</span><span class="sxs-lookup"><span data-stu-id="8f156-280">Action6</span></span></td>
        <td><span data-ttu-id="8f156-281">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-281">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-282">Special1</span><span class="sxs-lookup"><span data-stu-id="8f156-282">Special1</span></span></td>
        <td><span data-ttu-id="8f156-283">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-283">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-284">Special2</span><span class="sxs-lookup"><span data-stu-id="8f156-284">Special2</span></span></td>
        <td><span data-ttu-id="8f156-285">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-285">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-286">StickUp</span><span class="sxs-lookup"><span data-stu-id="8f156-286">StickUp</span></span></td>
        <td><span data-ttu-id="8f156-287">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-287">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-288">StickDown</span><span class="sxs-lookup"><span data-stu-id="8f156-288">StickDown</span></span></td>
        <td><span data-ttu-id="8f156-289">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-289">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-290">StickLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-290">StickLeft</span></span></td>
        <td><span data-ttu-id="8f156-291">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-291">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-292">StickRight</span><span class="sxs-lookup"><span data-stu-id="8f156-292">StickRight</span></span></td>
        <td><span data-ttu-id="8f156-293">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-293">Yes</span></span></td>
    </tr>
</table>

### <a name="flightstick"></a><span data-ttu-id="8f156-294">FlightStick</span><span class="sxs-lookup"><span data-stu-id="8f156-294">FlightStick</span></span>

<span data-ttu-id="8f156-295">次の表は **FlightStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-295">The table below lists the required and optional subkeys under the **FlightStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-296">サブキー</span><span class="sxs-lookup"><span data-stu-id="8f156-296">Subkey</span></span></th>
        <th><span data-ttu-id="8f156-297">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-297">Required?</span></span></th>
        <th><span data-ttu-id="8f156-298">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-298">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-299">FirePrimary</span><span class="sxs-lookup"><span data-stu-id="8f156-299">FirePrimary</span></span></td>
        <td><span data-ttu-id="8f156-300">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-300">Yes</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-301">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-301">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-302">FireSecondary</span><span class="sxs-lookup"><span data-stu-id="8f156-302">FireSecondary</span></span></td>
        <td><span data-ttu-id="8f156-303">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-303">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-304">Roll</span><span class="sxs-lookup"><span data-stu-id="8f156-304">Roll</span></span></td>
        <td><span data-ttu-id="8f156-305">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-305">Yes</span></span></td>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="8f156-306">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-306">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-307">Pitch</span><span class="sxs-lookup"><span data-stu-id="8f156-307">Pitch</span></span></td>
        <td><span data-ttu-id="8f156-308">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-308">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-309">Yaw</span><span class="sxs-lookup"><span data-stu-id="8f156-309">Yaw</span></span></td>
        <td><span data-ttu-id="8f156-310">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-310">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-311">Throttle</span><span class="sxs-lookup"><span data-stu-id="8f156-311">Throttle</span></span></td>
        <td><span data-ttu-id="8f156-312">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-312">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-313">HatSwitch</span><span class="sxs-lookup"><span data-stu-id="8f156-313">HatSwitch</span></span></td>
        <td><span data-ttu-id="8f156-314">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-314">Yes</span></span></td>
        <td><span data-ttu-id="8f156-315">「<a href="#switch-mapping">スイッチのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-315">See <a href="#switch-mapping">Switch mapping</a></span></span></td>
    </tr>
</table>

### <a name="uinavigation"></a><span data-ttu-id="8f156-316">UINavigation</span><span class="sxs-lookup"><span data-stu-id="8f156-316">UINavigation</span></span>

<span data-ttu-id="8f156-317">次の表は **UINavigation** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-317">The table below lists the required and optional subkeys under **UINavigation** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-318">サブキー</span><span class="sxs-lookup"><span data-stu-id="8f156-318">Subkey</span></span></th>
        <th><span data-ttu-id="8f156-319">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-319">Required?</span></span></th>
        <th><span data-ttu-id="8f156-320">Info</span><span class="sxs-lookup"><span data-stu-id="8f156-320">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-321">Menu</span><span class="sxs-lookup"><span data-stu-id="8f156-321">Menu</span></span></td>
        <td><span data-ttu-id="8f156-322">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-322">Yes</span></span></td>
        <td rowspan="24" style="vertical-align: middle;"><span data-ttu-id="8f156-323">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-323">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-324">表示</span><span class="sxs-lookup"><span data-stu-id="8f156-324">View</span></span></td>
        <td><span data-ttu-id="8f156-325">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-325">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-326">OK</span><span class="sxs-lookup"><span data-stu-id="8f156-326">Accept</span></span></td>
        <td><span data-ttu-id="8f156-327">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-327">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-328">Cancel</span><span class="sxs-lookup"><span data-stu-id="8f156-328">Cancel</span></span></td>
        <td><span data-ttu-id="8f156-329">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-329">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-330">PrimaryUp</span><span class="sxs-lookup"><span data-stu-id="8f156-330">PrimaryUp</span></span></td>
        <td><span data-ttu-id="8f156-331">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-331">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-332">PrimaryDown</span><span class="sxs-lookup"><span data-stu-id="8f156-332">PrimaryDown</span></span></td>
        <td><span data-ttu-id="8f156-333">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-333">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-334">PrimaryLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-334">PrimaryLeft</span></span></td>
        <td><span data-ttu-id="8f156-335">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-335">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-336">PrimaryRight</span><span class="sxs-lookup"><span data-stu-id="8f156-336">PrimaryRight</span></span></td>
        <td><span data-ttu-id="8f156-337">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-337">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-338">Context1</span><span class="sxs-lookup"><span data-stu-id="8f156-338">Context1</span></span></td>
        <td><span data-ttu-id="8f156-339">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-339">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-340">Context2</span><span class="sxs-lookup"><span data-stu-id="8f156-340">Context2</span></span></td>
        <td><span data-ttu-id="8f156-341">X</span><span class="sxs-lookup"><span data-stu-id="8f156-341">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-342">Context3</span><span class="sxs-lookup"><span data-stu-id="8f156-342">Context3</span></span></td>
        <td><span data-ttu-id="8f156-343">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-343">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-344">Context4</span><span class="sxs-lookup"><span data-stu-id="8f156-344">Context4</span></span></td>
        <td><span data-ttu-id="8f156-345">X</span><span class="sxs-lookup"><span data-stu-id="8f156-345">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-346">PageUp</span><span class="sxs-lookup"><span data-stu-id="8f156-346">PageUp</span></span></td>
        <td><span data-ttu-id="8f156-347">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-347">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-348">PageDown</span><span class="sxs-lookup"><span data-stu-id="8f156-348">PageDown</span></span></td>
        <td><span data-ttu-id="8f156-349">X</span><span class="sxs-lookup"><span data-stu-id="8f156-349">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-350">PageLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-350">PageLeft</span></span></td>
        <td><span data-ttu-id="8f156-351">X</span><span class="sxs-lookup"><span data-stu-id="8f156-351">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-352">PageRight</span><span class="sxs-lookup"><span data-stu-id="8f156-352">PageRight</span></span></td>
        <td><span data-ttu-id="8f156-353">X</span><span class="sxs-lookup"><span data-stu-id="8f156-353">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-354">ScrollUp</span><span class="sxs-lookup"><span data-stu-id="8f156-354">ScrollUp</span></span></td>
        <td><span data-ttu-id="8f156-355">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-355">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-356">ScrollDown</span><span class="sxs-lookup"><span data-stu-id="8f156-356">ScrollDown</span></span></td>
        <td><span data-ttu-id="8f156-357">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-357">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-358">ScrollLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-358">ScrollLeft</span></span></td>
        <td><span data-ttu-id="8f156-359">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-359">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-360">ScrollRight</span><span class="sxs-lookup"><span data-stu-id="8f156-360">ScrollRight</span></span></td>
        <td><span data-ttu-id="8f156-361">X</span><span class="sxs-lookup"><span data-stu-id="8f156-361">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-362">SecondaryUp</span><span class="sxs-lookup"><span data-stu-id="8f156-362">SecondaryUp</span></span></td>
        <td><span data-ttu-id="8f156-363">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-363">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-364">SecondaryDown</span><span class="sxs-lookup"><span data-stu-id="8f156-364">SecondaryDown</span></span></td>
        <td><span data-ttu-id="8f156-365">X</span><span class="sxs-lookup"><span data-stu-id="8f156-365">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-366">SecondaryLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-366">SecondaryLeft</span></span></td>
        <td><span data-ttu-id="8f156-367">X</span><span class="sxs-lookup"><span data-stu-id="8f156-367">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-368">SecondaryRight</span><span class="sxs-lookup"><span data-stu-id="8f156-368">SecondaryRight</span></span></td>
        <td><span data-ttu-id="8f156-369">X</span><span class="sxs-lookup"><span data-stu-id="8f156-369">No</span></span></td>
    </tr>
</table>

<span data-ttu-id="8f156-370">UI ナビゲーション コントローラーと上記のコマンドについて詳しくは、「[UI ナビゲーション コントローラー](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f156-370">For more information about UI navigation controllers and the above commands, see [UI navigation controller](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller).</span></span>

## <a name="keys"></a><span data-ttu-id="8f156-371">キー</span><span class="sxs-lookup"><span data-stu-id="8f156-371">Keys</span></span>

<span data-ttu-id="8f156-372">次のセクションでは、**Gamepad**、**RacingWheel**、**ArcadeStick**、**FlightStick**、**UINavigation** キーの下のサブキーのそれぞれのコンテンツについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8f156-372">The following sections explain the contents of each of the subkeys under the **Gamepad**, **RacingWheel**, **ArcadeStick**, **FlightStick**, and **UINavigation** keys.</span></span>

### <a name="button-mapping"></a><span data-ttu-id="8f156-373">ボタンのマッピング</span><span class="sxs-lookup"><span data-stu-id="8f156-373">Button mapping</span></span>

<span data-ttu-id="8f156-374">次の表は、ボタンのマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-374">The table below lists the values that are needed to map a button.</span></span> <span data-ttu-id="8f156-375">たとえば、ゲーム コントローラーの **DPadUp** キーを押すと、**DPadUp** のマッピングには **ButtonIndex** 値が含まれます (**Source** は **Button** です)。</span><span class="sxs-lookup"><span data-stu-id="8f156-375">For example, if pressing **DPadUp** on the game controller, the mapping for **DPadUp** should contain the **ButtonIndex** value (**Source** is **Button**).</span></span> <span data-ttu-id="8f156-376">**DPadUp** がスイッチの位置からマッピングされる必要がある場合は、**DPadUp** マッピングには **SwitchIndex** と **SwitchPosition** の値が含まれます (**Source** は **Switch** です)。</span><span class="sxs-lookup"><span data-stu-id="8f156-376">If **DPadUp** needs to be mapped from a switch position, then the **DPadUp** mapping should contain the values **SwitchIndex** and **SwitchPosition** (**Source** is **Switch**).</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-377">Source</span><span class="sxs-lookup"><span data-stu-id="8f156-377">Source</span></span></th>
        <th><span data-ttu-id="8f156-378">値の名前</span><span class="sxs-lookup"><span data-stu-id="8f156-378">Value name</span></span></th>
        <th><span data-ttu-id="8f156-379">[値の型]</span><span class="sxs-lookup"><span data-stu-id="8f156-379">Value type</span></span></th>
        <th><span data-ttu-id="8f156-380">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-380">Required?</span></span></th>
        <th><span data-ttu-id="8f156-381">値の情報</span><span class="sxs-lookup"><span data-stu-id="8f156-381">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-382">Button</span><span class="sxs-lookup"><span data-stu-id="8f156-382">Button</span></span></td>
        <td><span data-ttu-id="8f156-383">ButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-383">ButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-384">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-384">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-385">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-385">Yes</span></span></td>
        <td><span data-ttu-id="8f156-386"><b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-386">Index in the <b>RawGameController</b> button array.</span></span></td>
    </tr>
    <tr>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="8f156-387">Axis</span><span class="sxs-lookup"><span data-stu-id="8f156-387">Axis</span></span></td>
        <td><span data-ttu-id="8f156-388">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-388">AxisIndex</span></span></td>
        <td><span data-ttu-id="8f156-389">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-389">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-390">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-390">Yes</span></span></td>
        <td><span data-ttu-id="8f156-391"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-391">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-392">Invert</span><span class="sxs-lookup"><span data-stu-id="8f156-392">Invert</span></span></td>
        <td><span data-ttu-id="8f156-393">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-393">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-394">X</span><span class="sxs-lookup"><span data-stu-id="8f156-394">No</span></span></td>
        <td><span data-ttu-id="8f156-395"><b>ThresholdPercent</b> と <b>DebouncePercent</b> 要素を適用する前に、軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-395">Indicates that the axis value should be inverted before the <b>Threshold Percent</b> and <b>DebouncePercent</b> factors are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-396">ThresholdPercent</span><span class="sxs-lookup"><span data-stu-id="8f156-396">ThresholdPercent</span></span></td>
        <td><span data-ttu-id="8f156-397">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-397">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-398">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-398">Yes</span></span></td>
        <td><span data-ttu-id="8f156-399">マッピングされたボタンの値の (押した状態と離した状態の間の) 遷移の軸の位置を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-399">Indicates the axis position at which the mapped button value transitions between the pressed and released states.</span></span> <span data-ttu-id="8f156-400">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="8f156-400">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="8f156-401">軸の値がこの値以上の場合、ボタンが押されたと見なされます。</span><span class="sxs-lookup"><span data-stu-id="8f156-401">The button is considered pressed if the axis value is greater than or equal to this value.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-402">DebouncePercent</span><span class="sxs-lookup"><span data-stu-id="8f156-402">DebouncePercent</span></span></td>
        <td><span data-ttu-id="8f156-403">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-403">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-404">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-404">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-405"><b>ThresholdPercent</b> 値の周囲のウィンドウのサイズを定義します。報告されたボタンの状態をデバウンスするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-405">Defines the size of a window around the <b>ThresholdPercent</b> value, which is used to debounce the reported button state.</span></span> <span data-ttu-id="8f156-406">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="8f156-406">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="8f156-407">ボタンの状態の遷移は、軸の値がデバウンス ウィンドウの上限または下限を超えたときにのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="8f156-407">Button state transitions can only occur when the axis value crosses the upper or lower boundaries of the debounce window.</span></span> <span data-ttu-id="8f156-408">たとえば、<b>ThresholdPercent</b> が 50 で、<b>DebouncePercent</b> が 10 の場合には、デバウンスの下限と上限は、全範囲の軸の値で 45% と 55% となります。</span><span class="sxs-lookup"><span data-stu-id="8f156-408">For example, a <b>ThresholdPercent</b> of 50 and <b>DebouncePercent</b> of 10 results in debounce boundaries at 45% and 55% of the full-range axis values.</span></span> <span data-ttu-id="8f156-409">軸の値が 55% 以上に達すると、ボタンは押された状態に遷移し、軸の値が 45% 以下に達すると、ボタンはリリースされた状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="8f156-409">The button can't transition to the pressed state until the axis value reaches 55% or above, and it can't transition back to the released state until the axis value reaches 45% or below.</span></span></p>
            <p><span data-ttu-id="8f156-410">計算されるデバウンス ウィンドウの境界は 0% ～ 100% の間でクランプされます。</span><span class="sxs-lookup"><span data-stu-id="8f156-410">The computed debounce window boundaries are clamped between 0% and 100%.</span></span> <span data-ttu-id="8f156-411">たとえば、しきい値が 5% で、デバウンス ウィンドウが 20% の場合、デバウンス ウィンドウの境界は 0% と 15% となります。</span><span class="sxs-lookup"><span data-stu-id="8f156-411">For example, a threshold of 5% and a debounce window of 20% would result in the debounce window boundaries falling at 0% and 15%.</span></span> <span data-ttu-id="8f156-412">しきい値とデバウンスの値にかかわらず、軸の値が 0% ～ 100% にあるボタンの状態は常に、押されるか、または離されるかとして報告されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-412">The button state for axis values of 0% and 100% are always reported as released and pressed, respectively, regardless of the threshold and debounce values.</span></span></p>
        </td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="8f156-413">Switch</span><span class="sxs-lookup"><span data-stu-id="8f156-413">Switch</span></span></td>
        <td><span data-ttu-id="8f156-414">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-414">SwitchIndex</span></span></td>
        <td><span data-ttu-id="8f156-415">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-415">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-416">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-416">Yes</span></span></td>
        <td><span data-ttu-id="8f156-417"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-417">Index in the <b>RawGameController</b> switch array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-418">SwitchPosition</span><span class="sxs-lookup"><span data-stu-id="8f156-418">SwitchPosition</span></span></td>
        <td><span data-ttu-id="8f156-419">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="8f156-419">REG_SZ</span></span></td>
        <td><span data-ttu-id="8f156-420">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-420">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-421">マッピングされたボタンが押されたことを報告するスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-421">Indicates the switch position that will cause the mapped button to report that it's being pressed.</span></span> <span data-ttu-id="8f156-422">位置の値には、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="8f156-422">The position values can be one of these strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="8f156-423">Up</span><span class="sxs-lookup"><span data-stu-id="8f156-423">Up</span></span></li>
                <li><span data-ttu-id="8f156-424">UpRight</span><span class="sxs-lookup"><span data-stu-id="8f156-424">UpRight</span></span></li>
                <li><span data-ttu-id="8f156-425">右</span><span class="sxs-lookup"><span data-stu-id="8f156-425">Right</span></span></li>
                <li><span data-ttu-id="8f156-426">DownRight</span><span class="sxs-lookup"><span data-stu-id="8f156-426">DownRight</span></span></li>
                <li><span data-ttu-id="8f156-427">Down</span><span class="sxs-lookup"><span data-stu-id="8f156-427">Down</span></span></li>
                <li><span data-ttu-id="8f156-428">DownLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-428">DownLeft</span></span></li>
                <li><span data-ttu-id="8f156-429">Left</span><span class="sxs-lookup"><span data-stu-id="8f156-429">Left</span></span></li>
                <li><span data-ttu-id="8f156-430">UpLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-430">UpLeft</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-431">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="8f156-431">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="8f156-432">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-432">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-433">X</span><span class="sxs-lookup"><span data-stu-id="8f156-433">No</span></span></td>
        <td><span data-ttu-id="8f156-434">隣接するスイッチの位置も、マッピングされたボタンが押されたことを報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-434">Indicates that adjacent switch positions will also cause the mapped button to report that it's being pressed.</span></span></td>
    </tr>
</table>

### <a name="axis-mapping"></a><span data-ttu-id="8f156-435">軸のマッピング</span><span class="sxs-lookup"><span data-stu-id="8f156-435">Axis mapping</span></span>

<span data-ttu-id="8f156-436">次の表は、軸のマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-436">The table below lists the values that are needed to map an axis:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-437">Source</span><span class="sxs-lookup"><span data-stu-id="8f156-437">Source</span></span></th>
        <th><span data-ttu-id="8f156-438">値の名前</span><span class="sxs-lookup"><span data-stu-id="8f156-438">Value name</span></span></th>
        <th><span data-ttu-id="8f156-439">[値の型]</span><span class="sxs-lookup"><span data-stu-id="8f156-439">Value type</span></span></th>
        <th><span data-ttu-id="8f156-440">必須/省略可能</span><span class="sxs-lookup"><span data-stu-id="8f156-440">Required?</span></span></th>
        <th><span data-ttu-id="8f156-441">値の情報</span><span class="sxs-lookup"><span data-stu-id="8f156-441">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-442">Button</span><span class="sxs-lookup"><span data-stu-id="8f156-442">Button</span></span></td>
        <td><span data-ttu-id="8f156-443">MaxValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-443">MaxValueButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-444">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-444">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-445">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-445">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-446">マッピングされた一方向の軸の値に変換される、<b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-446">Index in the <b>RawGameController</b> button array which gets translated to the mapped unidirectional axis value.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="8f156-447">MaxButton</span><span class="sxs-lookup"><span data-stu-id="8f156-447">MaxButton</span></span></th>
                    <th><span data-ttu-id="8f156-448">AxisValue</span><span class="sxs-lookup"><span data-stu-id="8f156-448">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-449">FALSE</span><span class="sxs-lookup"><span data-stu-id="8f156-449">FALSE</span></span></td>
                    <td><span data-ttu-id="8f156-450">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-450">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-451">TRUE</span><span class="sxs-lookup"><span data-stu-id="8f156-451">TRUE</span></span></td>
                    <td><span data-ttu-id="8f156-452">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-452">1.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-453">MinValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-453">MinValueButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-454">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-454">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-455">X</span><span class="sxs-lookup"><span data-stu-id="8f156-455">No</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-456">マッピングされた軸が双方向であることを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-456">Indicates that the mapped axis is bidirectional.</span></span> <span data-ttu-id="8f156-457"><b>MaxButton</b> と <b>MinButton</b> の値は結合され、次に示すように 1 つの双方向の軸となります。</span><span class="sxs-lookup"><span data-stu-id="8f156-457">Values of <b>MaxButton</b> and <b>MinButton</b> are combined into a single bidirectional axis as shown below.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="8f156-458">MinButton</span><span class="sxs-lookup"><span data-stu-id="8f156-458">MinButton</span></span></th>
                    <th><span data-ttu-id="8f156-459">MaxButton</span><span class="sxs-lookup"><span data-stu-id="8f156-459">MaxButton</span></span></th>
                    <th><span data-ttu-id="8f156-460">AxisValue</span><span class="sxs-lookup"><span data-stu-id="8f156-460">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-461">FALSE</span><span class="sxs-lookup"><span data-stu-id="8f156-461">FALSE</span></span></td>
                    <td><span data-ttu-id="8f156-462">FALSE</span><span class="sxs-lookup"><span data-stu-id="8f156-462">FALSE</span></span></td>
                    <td><span data-ttu-id="8f156-463">0.5</span><span class="sxs-lookup"><span data-stu-id="8f156-463">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-464">FALSE</span><span class="sxs-lookup"><span data-stu-id="8f156-464">FALSE</span></span></td>
                    <td><span data-ttu-id="8f156-465">TRUE</span><span class="sxs-lookup"><span data-stu-id="8f156-465">TRUE</span></span></td>
                    <td><span data-ttu-id="8f156-466">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-466">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-467">TRUE</span><span class="sxs-lookup"><span data-stu-id="8f156-467">TRUE</span></span></td>
                    <td><span data-ttu-id="8f156-468">FALSE</span><span class="sxs-lookup"><span data-stu-id="8f156-468">FALSE</span></span></td>
                    <td><span data-ttu-id="8f156-469">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-469">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-470">TRUE</span><span class="sxs-lookup"><span data-stu-id="8f156-470">TRUE</span></span></td>
                    <td><span data-ttu-id="8f156-471">TRUE</span><span class="sxs-lookup"><span data-stu-id="8f156-471">TRUE</span></span></td>
                    <td><span data-ttu-id="8f156-472">0.5</span><span class="sxs-lookup"><span data-stu-id="8f156-472">0.5</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-473">Axis</span><span class="sxs-lookup"><span data-stu-id="8f156-473">Axis</span></span></td>
        <td><span data-ttu-id="8f156-474">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-474">AxisIndex</span></span></td>
        <td><span data-ttu-id="8f156-475">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-475">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-476">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-476">Yes</span></span></td>
        <td><span data-ttu-id="8f156-477"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-477">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-478">Invert</span><span class="sxs-lookup"><span data-stu-id="8f156-478">Invert</span></span></td>
        <td><span data-ttu-id="8f156-479">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-479">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-480">いいえ</span><span class="sxs-lookup"><span data-stu-id="8f156-480">No</span></span></td>
        <td><span data-ttu-id="8f156-481">マッピングされた軸の値を返す前に反転するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-481">Indicates that the mapped axis value should be inverted before it's returned.</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="8f156-482">Switch</span><span class="sxs-lookup"><span data-stu-id="8f156-482">Switch</span></span></td>
        <td><span data-ttu-id="8f156-483">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-483">SwitchIndex</span></span></td>
        <td><span data-ttu-id="8f156-484">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-484">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-485">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-485">Yes</span></span></td>
        <td><span data-ttu-id="8f156-486"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-486">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-487">MaxValueSwitchPosition</span><span class="sxs-lookup"><span data-stu-id="8f156-487">MaxValueSwitchPosition</span></span></td>
        <td><span data-ttu-id="8f156-488">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="8f156-488">REG_SZ</span></span></td>
        <td><span data-ttu-id="8f156-489">〇</span><span class="sxs-lookup"><span data-stu-id="8f156-489">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-490">次のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="8f156-490">One of the following strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="8f156-491">Up</span><span class="sxs-lookup"><span data-stu-id="8f156-491">Up</span></span></li>
                <li><span data-ttu-id="8f156-492">UpRight</span><span class="sxs-lookup"><span data-stu-id="8f156-492">UpRight</span></span></li>
                <li><span data-ttu-id="8f156-493">右</span><span class="sxs-lookup"><span data-stu-id="8f156-493">Right</span></span></li>
                <li><span data-ttu-id="8f156-494">DownRight</span><span class="sxs-lookup"><span data-stu-id="8f156-494">DownRight</span></span></li>
                <li><span data-ttu-id="8f156-495">Down</span><span class="sxs-lookup"><span data-stu-id="8f156-495">Down</span></span></li>
                <li><span data-ttu-id="8f156-496">DownLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-496">DownLeft</span></span></li>
                <li><span data-ttu-id="8f156-497">Left</span><span class="sxs-lookup"><span data-stu-id="8f156-497">Left</span></span></li>
                <li><span data-ttu-id="8f156-498">UpLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-498">UpLeft</span></span></li>
            </ul>
            <p><span data-ttu-id="8f156-499">マッピングされた軸の値が 1.0 として報告されるスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-499">It indicates the position of the switch that causes the mapped axis value to be reported as 1.0.</span></span> <span data-ttu-id="8f156-500">反対方向の <b>MaxValueSwitchPosition</b> は 0.0 と見なされます。</span><span class="sxs-lookup"><span data-stu-id="8f156-500">The opposing direction of <b>MaxValueSwitchPosition</b> is treated as 0.0.</span></span> <span data-ttu-id="8f156-501">たとえば、<b>MaxValueSwitchPosition</b> が <b>Up</b> の場合、軸の値は次を意味します。</span><span class="sxs-lookup"><span data-stu-id="8f156-501">For example, if <b>MaxValueSwitchPosition</b> is <b>Up</b>, the axis value translation is shown below:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="8f156-502">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="8f156-502">Switch position</span></span></th>
                    <th><span data-ttu-id="8f156-503">AxisValue</span><span class="sxs-lookup"><span data-stu-id="8f156-503">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-504">Up</span><span class="sxs-lookup"><span data-stu-id="8f156-504">Up</span></span></td>
                    <td><span data-ttu-id="8f156-505">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-505">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-506">Center</span><span class="sxs-lookup"><span data-stu-id="8f156-506">Center</span></span></td>
                    <td><span data-ttu-id="8f156-507">0.5</span><span class="sxs-lookup"><span data-stu-id="8f156-507">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-508">Down</span><span class="sxs-lookup"><span data-stu-id="8f156-508">Down</span></span></td>
                    <td><span data-ttu-id="8f156-509">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-509">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-510">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="8f156-510">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="8f156-511">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-511">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-512">X</span><span class="sxs-lookup"><span data-stu-id="8f156-512">No</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-513">隣接するスイッチの位置も、マッピングされた軸が 1.0 を報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-513">Indicates that adjacent switch positions will also cause the mapped axis to report 1.0.</span></span> <span data-ttu-id="8f156-514">上記の例では、<b>IncludeAdjacent</b> が設定されている場合、軸は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8f156-514">In the above example, if <b>IncludeAdjacent</b> is set, then the axis translation is done as follows:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="8f156-515">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="8f156-515">Switch position</span></span></th>
                    <th><span data-ttu-id="8f156-516">AxisValue</span><span class="sxs-lookup"><span data-stu-id="8f156-516">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-517">Up</span><span class="sxs-lookup"><span data-stu-id="8f156-517">Up</span></span></td>
                    <td><span data-ttu-id="8f156-518">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-518">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-519">UpRight</span><span class="sxs-lookup"><span data-stu-id="8f156-519">UpRight</span></span></td>
                    <td><span data-ttu-id="8f156-520">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-520">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-521">UpLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-521">UpLeft</span></span></td>
                    <td><span data-ttu-id="8f156-522">1.0</span><span class="sxs-lookup"><span data-stu-id="8f156-522">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-523">Center</span><span class="sxs-lookup"><span data-stu-id="8f156-523">Center</span></span></td>
                    <td><span data-ttu-id="8f156-524">0.5</span><span class="sxs-lookup"><span data-stu-id="8f156-524">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-525">Down</span><span class="sxs-lookup"><span data-stu-id="8f156-525">Down</span></span></td>
                    <td><span data-ttu-id="8f156-526">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-526">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-527">DownRight</span><span class="sxs-lookup"><span data-stu-id="8f156-527">DownRight</span></span></td>
                    <td><span data-ttu-id="8f156-528">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-528">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-529">DownLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-529">DownLeft</span></span></td>
                    <td><span data-ttu-id="8f156-530">0.0</span><span class="sxs-lookup"><span data-stu-id="8f156-530">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

### <a name="switch-mapping"></a><span data-ttu-id="8f156-531">スイッチのマッピング</span><span class="sxs-lookup"><span data-stu-id="8f156-531">Switch mapping</span></span>

<span data-ttu-id="8f156-532">スイッチの位置は、**RawGameController** のボタンの配列のボタンのセットから、またはスイッチの配列のインデックスからマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="8f156-532">Switch positions can be mapped either from a set of buttons in the buttons array of the **RawGameController** or from an index in the switches array.</span></span> <span data-ttu-id="8f156-533">軸からスイッチの位置をマッピングすることはできません。</span><span class="sxs-lookup"><span data-stu-id="8f156-533">Switch positions can't be mapped from axes.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-534">Source</span><span class="sxs-lookup"><span data-stu-id="8f156-534">Source</span></span></th>
        <th><span data-ttu-id="8f156-535">値の名前</span><span class="sxs-lookup"><span data-stu-id="8f156-535">Value name</span></span></th>
        <th><span data-ttu-id="8f156-536">[値の型]</span><span class="sxs-lookup"><span data-stu-id="8f156-536">Value type</span></span></th>
        <th><span data-ttu-id="8f156-537">値の情報</span><span class="sxs-lookup"><span data-stu-id="8f156-537">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="10" style="vertical-align: middle;"><span data-ttu-id="8f156-538">Button</span><span class="sxs-lookup"><span data-stu-id="8f156-538">Button</span></span></td>
        <td><span data-ttu-id="8f156-539">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="8f156-539">ButtonCount</span></span></td>
        <td><span data-ttu-id="8f156-540">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-540">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-541">2、4、または 8</span><span class="sxs-lookup"><span data-stu-id="8f156-541">2, 4, or 8</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-542">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="8f156-542">SwitchKind</span></span></td>
        <td><span data-ttu-id="8f156-543">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="8f156-543">REG_SZ</span></span></td>
        <td><span data-ttu-id="8f156-544"><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></span><span class="sxs-lookup"><span data-stu-id="8f156-544"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b></span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-545">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-545">UpButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-546">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-546">DWORD</span></span></td>
        <td rowspan="8" style="vertical-align: middle;"><span data-ttu-id="8f156-547">「<a href="#buttonindex-values">\*ButtonIndex の値</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="8f156-547">See <a href="#buttonindex-values">\*ButtonIndex values</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-548">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-548">DownButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-549">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-549">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-550">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-550">LeftButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-551">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-551">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-552">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-552">RightButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-553">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-553">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-554">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-554">UpRightButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-555">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-555">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-556">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-556">DownRightButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-557">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-557">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-558">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-558">DownLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-559">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-559">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-560">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-560">UpLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="8f156-561">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-561">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="9" style="vertical-align: middle;"><span data-ttu-id="8f156-562">Axis</span><span class="sxs-lookup"><span data-stu-id="8f156-562">Axis</span></span></td>
        <td><span data-ttu-id="8f156-563">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="8f156-563">SwitchKind</span></span></td>
        <td><span data-ttu-id="8f156-564">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="8f156-564">REG_SZ</span></span></td>
        <td><span data-ttu-id="8f156-565"><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></span><span class="sxs-lookup"><span data-stu-id="8f156-565"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-566">XAxisIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-566">XAxisIndex</span></span></td>
        <td><span data-ttu-id="8f156-567">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-567">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-568"><b>YAxisIndex</b> は常に存在します。</span><span class="sxs-lookup"><span data-stu-id="8f156-568"><b>YAxisIndex</b> is always present.</span></span> <span data-ttu-id="8f156-569"><b>XAxisIndex</b> は、<b>SwitchKind</b> が <b>FourWay</b> または <b>EightWay</b> の場合のみ存在します。</span><span class="sxs-lookup"><span data-stu-id="8f156-569"><b>XAxisIndex</b> is only present when <b>SwitchKind</b> is <b>FourWay</b> or <b>EightWay</b>.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-570">YAxisIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-570">YAxisIndex</span></span></td>
        <td><span data-ttu-id="8f156-571">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-571">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-572">XDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="8f156-572">XDeadZonePercent</span></span></td>
        <td><span data-ttu-id="8f156-573">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-573">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-574">軸の中央位置の周囲のデッド ゾーンのサイズを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-574">Indicate the size of the dead zone around the center position of the axes.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-575">YDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="8f156-575">YDeadZonePercent</span></span></td>
        <td><span data-ttu-id="8f156-576">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-576">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-577">XDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="8f156-577">XDebouncePercent</span></span></td>
        <td><span data-ttu-id="8f156-578">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-578">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-579">デッド ゾーンの上限と下限の周囲のウィンドウのサイズを定義します。これは報告されたスイッチの状態のデバウンスに使用されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-579">Define the size of the windows around the upper and lower dead zone limits, which are used to de-bounce the reported switch state.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-580">YDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="8f156-580">YDebouncePercent</span></span></td>
        <td><span data-ttu-id="8f156-581">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-581">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-582">XInvert</span><span class="sxs-lookup"><span data-stu-id="8f156-582">XInvert</span></span></td>
        <td><span data-ttu-id="8f156-583">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-583">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="8f156-584">デッド ゾーンとデバウンス ウィンドウの計算を適用する前に、対応する軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-584">Indicate that the corresponding axis values should be inverted before the dead zone and debounce window calculations are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-585">YInvert</span><span class="sxs-lookup"><span data-stu-id="8f156-585">YInvert</span></span></td>
        <td><span data-ttu-id="8f156-586">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-586">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="8f156-587">Switch</span><span class="sxs-lookup"><span data-stu-id="8f156-587">Switch</span></span></td>
        <td><span data-ttu-id="8f156-588">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-588">SwitchIndex</span></span></td>
        <td><span data-ttu-id="8f156-589">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-589">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-590"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="8f156-590">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-591">Invert</span><span class="sxs-lookup"><span data-stu-id="8f156-591">Invert</span></span></td>
        <td><span data-ttu-id="8f156-592">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-592">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-593">スイッチが位置を、既定の時計回りの順序ではなく、反時計回りの順序で報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-593">Indicates that the switch reports its positions in a counter-clockwise order, rather than the default clockwise order.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-594">PositionBias</span><span class="sxs-lookup"><span data-stu-id="8f156-594">PositionBias</span></span></td>
        <td><span data-ttu-id="8f156-595">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-595">DWORD</span></span></td>
        <td>
            <p><span data-ttu-id="8f156-596">位置の報告の開始点を指定した量だけ移動します。</span><span class="sxs-lookup"><span data-stu-id="8f156-596">Shifts the starting point of how positions are reported by the specified amount.</span></span> <span data-ttu-id="8f156-597"><b>PositionBias</b> は常に元の開始点から時計回りにカウントされます。値の順序が反転される前に適用されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-597"><b>PositionBias</b> is always counted clockwise from the original starting point, and is applied before the order of values is reversed.</span></span></p>
            <p><span data-ttu-id="8f156-598">たとえば、<b>DownRight</b>で始まる位置を反時計回りの順序で報告するスイッチは、<b>Invert</b> フラグを設定して、<b>PositionBias</b> を 5 と設定することによって正規化されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-598">For example, a switch that reports positions starting with <b>DownRight</b> in counter-clockwise order can be normalized by setting the <b>Invert</b> flag and specifying a <b>PositionBias</b> of 5:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="8f156-599">位置</span><span class="sxs-lookup"><span data-stu-id="8f156-599">Position</span></span></th>
                    <th><span data-ttu-id="8f156-600">報告される値</span><span class="sxs-lookup"><span data-stu-id="8f156-600">Reported value</span></span></th>
                    <th><span data-ttu-id="8f156-601">PositionBias と Invert フラグの設定後</span><span class="sxs-lookup"><span data-stu-id="8f156-601">After PositionBias and Invert flags</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-602">DownRight</span><span class="sxs-lookup"><span data-stu-id="8f156-602">DownRight</span></span></td>
                    <td><span data-ttu-id="8f156-603">0</span><span class="sxs-lookup"><span data-stu-id="8f156-603">0</span></span></td>
                    <td><span data-ttu-id="8f156-604">3</span><span class="sxs-lookup"><span data-stu-id="8f156-604">3</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-605">右</span><span class="sxs-lookup"><span data-stu-id="8f156-605">Right</span></span></td>
                    <td><span data-ttu-id="8f156-606">1</span><span class="sxs-lookup"><span data-stu-id="8f156-606">1</span></span></td>
                    <td><span data-ttu-id="8f156-607">2</span><span class="sxs-lookup"><span data-stu-id="8f156-607">2</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-608">UpRight</span><span class="sxs-lookup"><span data-stu-id="8f156-608">UpRight</span></span></td>
                    <td><span data-ttu-id="8f156-609">2</span><span class="sxs-lookup"><span data-stu-id="8f156-609">2</span></span></td>
                    <td><span data-ttu-id="8f156-610">1</span><span class="sxs-lookup"><span data-stu-id="8f156-610">1</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-611">Up</span><span class="sxs-lookup"><span data-stu-id="8f156-611">Up</span></span></td>
                    <td><span data-ttu-id="8f156-612">3</span><span class="sxs-lookup"><span data-stu-id="8f156-612">3</span></span></td>
                    <td><span data-ttu-id="8f156-613">0</span><span class="sxs-lookup"><span data-stu-id="8f156-613">0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-614">UpLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-614">UpLeft</span></span></td>
                    <td><span data-ttu-id="8f156-615">4</span><span class="sxs-lookup"><span data-stu-id="8f156-615">4</span></span></td>
                    <td><span data-ttu-id="8f156-616">7</span><span class="sxs-lookup"><span data-stu-id="8f156-616">7</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-617">Left</span><span class="sxs-lookup"><span data-stu-id="8f156-617">Left</span></span></td>
                    <td><span data-ttu-id="8f156-618">5</span><span class="sxs-lookup"><span data-stu-id="8f156-618">5</span></span></td>
                    <td><span data-ttu-id="8f156-619">6</span><span class="sxs-lookup"><span data-stu-id="8f156-619">6</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-620">DownLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-620">DownLeft</span></span></td>
                    <td><span data-ttu-id="8f156-621">6</span><span class="sxs-lookup"><span data-stu-id="8f156-621">6</span></span></td>
                    <td><span data-ttu-id="8f156-622">5</span><span class="sxs-lookup"><span data-stu-id="8f156-622">5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="8f156-623">Down</span><span class="sxs-lookup"><span data-stu-id="8f156-623">Down</span></span></td>
                    <td><span data-ttu-id="8f156-624">7</span><span class="sxs-lookup"><span data-stu-id="8f156-624">7</span></span></td>
                    <td><span data-ttu-id="8f156-625">4</span><span class="sxs-lookup"><span data-stu-id="8f156-625">4</span></span></td>
                </tr>
            </table>
    </tr>
</table>

#### <a name="buttonindex-values"></a><span data-ttu-id="8f156-626">\*ButtonIndex の値</span><span class="sxs-lookup"><span data-stu-id="8f156-626">\*ButtonIndex values</span></span>

<span data-ttu-id="8f156-627">\*ButtonIndex 値にインデックスを付ける、 **RawGameController**のボタン配列。</span><span class="sxs-lookup"><span data-stu-id="8f156-627">\*ButtonIndex values index into the **RawGameController**'s button array:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-628">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="8f156-628">ButtonCount</span></span></th>
        <th><span data-ttu-id="8f156-629">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="8f156-629">SwitchKind</span></span></th>
        <th><span data-ttu-id="8f156-630">RequiredMappings</span><span class="sxs-lookup"><span data-stu-id="8f156-630">RequiredMappings</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-631">2</span><span class="sxs-lookup"><span data-stu-id="8f156-631">2</span></span></td>
        <td><span data-ttu-id="8f156-632">TwoWay</span><span class="sxs-lookup"><span data-stu-id="8f156-632">TwoWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="8f156-633">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-633">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-634">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-634">DownButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-635">4</span><span class="sxs-lookup"><span data-stu-id="8f156-635">4</span></span></td>
        <td><span data-ttu-id="8f156-636">FourWay</span><span class="sxs-lookup"><span data-stu-id="8f156-636">FourWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="8f156-637">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-637">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-638">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-638">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-639">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-639">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-640">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-640">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-641">4</span><span class="sxs-lookup"><span data-stu-id="8f156-641">4</span></span></td>
        <td><span data-ttu-id="8f156-642">EightWay</span><span class="sxs-lookup"><span data-stu-id="8f156-642">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="8f156-643">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-643">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-644">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-644">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-645">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-645">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-646">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-646">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-647">8</span><span class="sxs-lookup"><span data-stu-id="8f156-647">8</span></span></td>
        <td><span data-ttu-id="8f156-648">EightWay</span><span class="sxs-lookup"><span data-stu-id="8f156-648">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="8f156-649">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-649">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-650">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-650">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-651">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-651">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-652">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-652">RightButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-653">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-653">UpRightButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-654">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-654">DownRightButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-655">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-655">DownLeftButtonIndex</span></span></li>
                <li><span data-ttu-id="8f156-656">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="8f156-656">UpLeftButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
</table>

### <a name="properties-mapping"></a><span data-ttu-id="8f156-657">プロパティ マッピング</span><span class="sxs-lookup"><span data-stu-id="8f156-657">Properties mapping</span></span>

<span data-ttu-id="8f156-658">これらは、別のマッピングの種類の、静的マッピング値です。</span><span class="sxs-lookup"><span data-stu-id="8f156-658">These are static mapping values for different mapping types.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-659">マッピング</span><span class="sxs-lookup"><span data-stu-id="8f156-659">Mapping</span></span></th>
        <th><span data-ttu-id="8f156-660">値の名前</span><span class="sxs-lookup"><span data-stu-id="8f156-660">Value name</span></span></th>
        <th><span data-ttu-id="8f156-661">[値の型]</span><span class="sxs-lookup"><span data-stu-id="8f156-661">Value type</span></span></th>
        <th><span data-ttu-id="8f156-662">値の情報</span><span class="sxs-lookup"><span data-stu-id="8f156-662">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-663">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="8f156-663">RacingWheel</span></span></td>
        <td><span data-ttu-id="8f156-664">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="8f156-664">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="8f156-665">DWORD</span><span class="sxs-lookup"><span data-stu-id="8f156-665">DWORD</span></span></td>
        <td><span data-ttu-id="8f156-666">ホイールでサポートされている、単一方向の物理ホイールの最大角度を示します。</span><span class="sxs-lookup"><span data-stu-id="8f156-666">Indicates the maximum physical wheel angle supported by the wheel in a single direction.</span></span> <span data-ttu-id="8f156-667">たとえば、-90 度から 90 度まで回転できるホイールでは、90 を指定します。</span><span class="sxs-lookup"><span data-stu-id="8f156-667">For example, a wheel with a possible rotation of -90 degrees to 90 degrees would specify 90.</span></span></td>
    </tr>
</table>

## <a name="labels"></a><span data-ttu-id="8f156-668">ラベル</span><span class="sxs-lookup"><span data-stu-id="8f156-668">Labels</span></span>

<span data-ttu-id="8f156-669">ラベルは、デバイス ルートの下の **Labels** キーの下に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f156-669">Labels should be present under the **Labels** key under the device root.</span></span> <span data-ttu-id="8f156-670">**ラベル**3 つのサブキーを持つことができます。**ボタン**、**軸**、および**スイッチ**します。</span><span class="sxs-lookup"><span data-stu-id="8f156-670">**Labels** can have 3 subkeys: **Buttons**, **Axes**, and **Switches**.</span></span>

### <a name="button-labels"></a><span data-ttu-id="8f156-671">ボタンのラベル</span><span class="sxs-lookup"><span data-stu-id="8f156-671">Button labels</span></span>

<span data-ttu-id="8f156-672">**Buttons** キーは、**RawGameController** のボタンの配列の各ボタンの位置を文字列にマッピングします。</span><span class="sxs-lookup"><span data-stu-id="8f156-672">The **Buttons** key maps each of the button positions in the **RawGameController**'s buttons array to a string.</span></span> <span data-ttu-id="8f156-673">各文字列は、対応する [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) 列挙値に内部的にマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="8f156-673">Each string is mapped internally to the corresponding [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) enum value.</span></span> <span data-ttu-id="8f156-674">たとえば、ゲームパッドに 10 個のボタンと、**RawGameController** がボタンを解析してボタンを表示する順序がある場合、レポートは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8f156-674">For example, if a gamepad has ten buttons and the order in which the **RawGameController** parses out the buttons and presents them in the buttons report is like this:</span></span>

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

<span data-ttu-id="8f156-675">ラベルは **Buttons** キーの下にこの順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="8f156-675">The labels should appear in this order under the **Buttons** key:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-676">名前</span><span class="sxs-lookup"><span data-stu-id="8f156-676">Name</span></span></th>
        <th><span data-ttu-id="8f156-677">値 (型。REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="8f156-677">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-678">Button0</span><span class="sxs-lookup"><span data-stu-id="8f156-678">Button0</span></span></td>
        <td><span data-ttu-id="8f156-679">Menu</span><span class="sxs-lookup"><span data-stu-id="8f156-679">Menu</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-680">Button1</span><span class="sxs-lookup"><span data-stu-id="8f156-680">Button1</span></span></td>
        <td><span data-ttu-id="8f156-681">表示</span><span class="sxs-lookup"><span data-stu-id="8f156-681">View</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-682">Button2</span><span class="sxs-lookup"><span data-stu-id="8f156-682">Button2</span></span></td>
        <td><span data-ttu-id="8f156-683">LeftStickButton</span><span class="sxs-lookup"><span data-stu-id="8f156-683">LeftStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-684">Button3</span><span class="sxs-lookup"><span data-stu-id="8f156-684">Button3</span></span></td>
        <td><span data-ttu-id="8f156-685">RightStickButton</span><span class="sxs-lookup"><span data-stu-id="8f156-685">RightStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-686">Button4</span><span class="sxs-lookup"><span data-stu-id="8f156-686">Button4</span></span></td>
        <td><span data-ttu-id="8f156-687">LetterA</span><span class="sxs-lookup"><span data-stu-id="8f156-687">LetterA</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-688">Button5</span><span class="sxs-lookup"><span data-stu-id="8f156-688">Button5</span></span></td>
        <td><span data-ttu-id="8f156-689">LetterB</span><span class="sxs-lookup"><span data-stu-id="8f156-689">LetterB</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-690">Button6</span><span class="sxs-lookup"><span data-stu-id="8f156-690">Button6</span></span></td>
        <td><span data-ttu-id="8f156-691">LetterX</span><span class="sxs-lookup"><span data-stu-id="8f156-691">LetterX</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-692">Button7</span><span class="sxs-lookup"><span data-stu-id="8f156-692">Button7</span></span></td>
        <td><span data-ttu-id="8f156-693">LetterY</span><span class="sxs-lookup"><span data-stu-id="8f156-693">LetterY</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-694">Button8</span><span class="sxs-lookup"><span data-stu-id="8f156-694">Button8</span></span></td>
        <td><span data-ttu-id="8f156-695">LeftBumper</span><span class="sxs-lookup"><span data-stu-id="8f156-695">LeftBumper</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-696">Button9</span><span class="sxs-lookup"><span data-stu-id="8f156-696">Button9</span></span></td>
        <td><span data-ttu-id="8f156-697">RightBumper</span><span class="sxs-lookup"><span data-stu-id="8f156-697">RightBumper</span></span></td>
    </tr>
</table>

### <a name="axis-labels"></a><span data-ttu-id="8f156-698">軸ラベル</span><span class="sxs-lookup"><span data-stu-id="8f156-698">Axis labels</span></span>

<span data-ttu-id="8f156-699">**Axes** キーは、**RawGameController** の軸の配列の各軸の位置を、ボタンのラベルのように、[GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) に一覧表示されたラベルの 1 つにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="8f156-699">The **Axes** key will map each of the axis positions in the **RawGameController**'s axis array to one of the labels listed in [GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) just like the button labels.</span></span> <span data-ttu-id="8f156-700">「[ボタンのラベル](#button-labels)」の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f156-700">See the example in [Button labels](#button-labels).</span></span>

### <a name="switch-labels"></a><span data-ttu-id="8f156-701">スイッチのラベル</span><span class="sxs-lookup"><span data-stu-id="8f156-701">Switch labels</span></span>

<span data-ttu-id="8f156-702">**Switches** キーはスイッチの位置をラベルにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="8f156-702">The **Switches** key maps switch positions to labels.</span></span> <span data-ttu-id="8f156-703">値は次の名前付け規則に従います: インデックスが **RawGameController** のスイッチの配列の *x*であるスイッチの位置にラベルを付けるには、次の値を **Switches** サブキーの下に追加します。</span><span class="sxs-lookup"><span data-stu-id="8f156-703">The values follow this naming convention: to label a position of a switch, whose index is *x* in the **RawGameController**'s switch array, add these values under the **Switches** subkey:</span></span>

* <span data-ttu-id="8f156-704">SwitchxUp</span><span class="sxs-lookup"><span data-stu-id="8f156-704">SwitchxUp</span></span>
* <span data-ttu-id="8f156-705">SwitchxUpRight</span><span class="sxs-lookup"><span data-stu-id="8f156-705">SwitchxUpRight</span></span>
* <span data-ttu-id="8f156-706">SwitchxRight</span><span class="sxs-lookup"><span data-stu-id="8f156-706">SwitchxRight</span></span>
* <span data-ttu-id="8f156-707">SwitchxDownRight</span><span class="sxs-lookup"><span data-stu-id="8f156-707">SwitchxDownRight</span></span>
* <span data-ttu-id="8f156-708">SwitchxDown</span><span class="sxs-lookup"><span data-stu-id="8f156-708">SwitchxDown</span></span>
* <span data-ttu-id="8f156-709">SwitchxDownLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-709">SwitchxDownLeft</span></span>
* <span data-ttu-id="8f156-710">SwitchxUpLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-710">SwitchxUpLeft</span></span>
* <span data-ttu-id="8f156-711">SwitchxLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-711">SwitchxLeft</span></span>

<span data-ttu-id="8f156-712">次の表は、4 方向スイッチの位置が **RawGameController** でインデックス 0 を示しているスイッチにラベルを付ける例を示しています。</span><span class="sxs-lookup"><span data-stu-id="8f156-712">The following table shows an example set of labels for switch positions of a 4-way switch which shows up at index 0 in the **RawGameController**:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="8f156-713">名前</span><span class="sxs-lookup"><span data-stu-id="8f156-713">Name</span></span></th>
        <th><span data-ttu-id="8f156-714">値 (型。REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="8f156-714">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-715">Switch0Up</span><span class="sxs-lookup"><span data-stu-id="8f156-715">Switch0Up</span></span></td>
        <td><span data-ttu-id="8f156-716">XboxUp</span><span class="sxs-lookup"><span data-stu-id="8f156-716">XboxUp</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-717">Switch0Right</span><span class="sxs-lookup"><span data-stu-id="8f156-717">Switch0Right</span></span></td>
        <td><span data-ttu-id="8f156-718">XboxRight</span><span class="sxs-lookup"><span data-stu-id="8f156-718">XboxRight</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-719">Switch0Down</span><span class="sxs-lookup"><span data-stu-id="8f156-719">Switch0Down</span></span></td>
        <td><span data-ttu-id="8f156-720">XboxDown</span><span class="sxs-lookup"><span data-stu-id="8f156-720">XboxDown</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="8f156-721">Switch0Left</span><span class="sxs-lookup"><span data-stu-id="8f156-721">Switch0Left</span></span></td>
        <td><span data-ttu-id="8f156-722">XboxLeft</span><span class="sxs-lookup"><span data-stu-id="8f156-722">XboxLeft</span></span></td>
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

## <a name="example-registry-file"></a><span data-ttu-id="8f156-723">レジストリ ファイルの例</span><span class="sxs-lookup"><span data-stu-id="8f156-723">Example registry file</span></span>

<span data-ttu-id="8f156-724">これらのマッピングと値のすべての例を示すため、汎用の **RacingWheel** のレジストリ ファイルを示す次の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f156-724">To show how all of these mappings and values come together, here is an example registry file for a generic **RacingWheel**:</span></span>

```text
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

## <a name="see-also"></a><span data-ttu-id="8f156-725">関連項目</span><span class="sxs-lookup"><span data-stu-id="8f156-725">See also</span></span>

* [<span data-ttu-id="8f156-726">Windows.Gaming.Input 名前空間</span><span class="sxs-lookup"><span data-stu-id="8f156-726">Windows.Gaming.Input Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [<span data-ttu-id="8f156-727">Windows.Gaming.Input.Custom 名前空間</span><span class="sxs-lookup"><span data-stu-id="8f156-727">Windows.Gaming.Input.Custom Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)
* [<span data-ttu-id="8f156-728">INF ファイル</span><span class="sxs-lookup"><span data-stu-id="8f156-728">INF Files</span></span>](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)
