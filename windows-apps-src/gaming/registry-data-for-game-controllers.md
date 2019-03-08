---
title: ゲーム コントローラーのレジストリ データ
description: UWP ゲームで使用されるコントローラーを有効にするために、PC のレジストリに追加できるデータについて説明します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.date: 06/25/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, レジストリ, カスタム
ms.localizationpriority: medium
ms.openlocfilehash: 3d30c19a7fd7641d76e810912d33a96dbbeb3132
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633607"
---
# <a name="registry-data-for-game-controllers"></a><span data-ttu-id="5612a-104">ゲーム コントローラーのレジストリ データ</span><span class="sxs-lookup"><span data-stu-id="5612a-104">Registry data for game controllers</span></span>

> [!NOTE]
> <span data-ttu-id="5612a-105">このトピックは、Windows 10 互換のゲーム コントローラーの製造元向けです。開発者の大部分には適用されません。</span><span class="sxs-lookup"><span data-stu-id="5612a-105">This topic is meant for manufacturers of Windows 10-compatible game controllers, and doesn't apply to the majority of developers.</span></span>

<span data-ttu-id="5612a-106">[Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)を使うと、独立系ハードウェア ベンダー (IHV) は、PC のレジストリにデータを追加して、デバイスが [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad)、[RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel)、[ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) として表示されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="5612a-106">The [Windows.Gaming.Input namespace](https://docs.microsoft.com/uwp/api/windows.gaming.input) allows independent hardware vendors (IHVs) to add data to the PC's registry, enabling their devices to appear as [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad), [RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel), [ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick), [FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick), and [UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) as appropriate.</span></span> <span data-ttu-id="5612a-107">互換性のあるコントローラー用にこのデータを追加することを、すべての IHV に推奨します。</span><span class="sxs-lookup"><span data-stu-id="5612a-107">All IHVs should add this data for their compatible controllers.</span></span> <span data-ttu-id="5612a-108">これにより、すべての UWP ゲーム (および WinRT API を使用するすべてのデスクトップ ゲーム) でゲーム コントローラーをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="5612a-108">By doing this, all UWP games (and any desktop games that use the WinRT API) will be able to support your game controller.</span></span>

## <a name="mapping-scheme"></a><span data-ttu-id="5612a-109">マッピング スキーム</span><span class="sxs-lookup"><span data-stu-id="5612a-109">Mapping scheme</span></span>

<span data-ttu-id="5612a-110">デバイスのマッピングとして、ベンダー ID (VID) **VVVV**、製品 ID (PID) **PPPP**、使用ページ **UUUU**、使用 ID **XXXX** が、レジストリのこの場所から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="5612a-110">Mappings for a device with Vendor ID (VID) **VVVV**, Product ID (PID) **PPPP**, Usage Page **UUUU**, and Usage ID **XXXX**, will be read out from this location in the registry:</span></span>

`HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\VVVVPPPPUUUUXXXX`

<span data-ttu-id="5612a-111">次の表は、デバイスのルートの場所で予期される値を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-111">The table below explains the expected values under the device root location:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-112">名前</span><span class="sxs-lookup"><span data-stu-id="5612a-112">Name</span></span></th>
        <th><span data-ttu-id="5612a-113">種類</span><span class="sxs-lookup"><span data-stu-id="5612a-113">Type</span></span></th>
        <th><span data-ttu-id="5612a-114">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-114">Required?</span></span></th>
        <th><span data-ttu-id="5612a-115">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-115">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-116">無効</span><span class="sxs-lookup"><span data-stu-id="5612a-116">Disabled</span></span></td>
        <td><span data-ttu-id="5612a-117">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-117">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-118">X</span><span class="sxs-lookup"><span data-stu-id="5612a-118">No</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-119">この特定のデバイスを無効になっていることを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-119">Indicates that this particular device should be disabled.</span></span></p>
            <ul>
                <li><span data-ttu-id="5612a-120"><b>0</b>:デバイスが無効になっていません。</span><span class="sxs-lookup"><span data-stu-id="5612a-120"><b>0</b>: Device is not disabled.</span></span></li>
                <li><span data-ttu-id="5612a-121"><b>1</b>:デバイスが無効です。</span><span class="sxs-lookup"><span data-stu-id="5612a-121"><b>1</b>: Device is disabled.</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-122">説明</span><span class="sxs-lookup"><span data-stu-id="5612a-122">Description</span></span></td>
        <td><span data-ttu-id="5612a-123">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="5612a-123">REG_SZ</span></span> <td><span data-ttu-id="5612a-124">X</span><span class="sxs-lookup"><span data-stu-id="5612a-124">No</span></span></td>
        <td><span data-ttu-id="5612a-125">デバイスの簡単な説明です。</span><span class="sxs-lookup"><span data-stu-id="5612a-125">A short description of the device.</span></span></td>
    </tr>
</table>

<span data-ttu-id="5612a-126">デバイスのインストーラーが (セットアップ、または [INF ファイル](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)によって) このデータをレジストリに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5612a-126">Your device installer should add this data to the registry (either via setup or an [INF file](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)).</span></span>

<span data-ttu-id="5612a-127">デバイスのルートの場所の下のサブキーは、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="5612a-127">Subkeys under the device root location are detailed in the following sections.</span></span>

### <a name="gamepad"></a><span data-ttu-id="5612a-128">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="5612a-128">Gamepad</span></span>

<span data-ttu-id="5612a-129">次の表は **Gamepad** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-129">The table below lists the required and optional subkeys under the **Gamepad** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-130">サブキー</span><span class="sxs-lookup"><span data-stu-id="5612a-130">Subkey</span></span></th>
        <th><span data-ttu-id="5612a-131">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-131">Required?</span></span></th>
        <th><span data-ttu-id="5612a-132">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-132">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-133">Menu</span><span class="sxs-lookup"><span data-stu-id="5612a-133">Menu</span></span></td>
        <td><span data-ttu-id="5612a-134">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-134">Yes</span></span></td>
        <td rowspan="18" style="vertical-align: middle;"><span data-ttu-id="5612a-135">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-135">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-136">ビュー</span><span class="sxs-lookup"><span data-stu-id="5612a-136">View</span></span></td>
        <td><span data-ttu-id="5612a-137">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-137">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-138">A</span><span class="sxs-lookup"><span data-stu-id="5612a-138">A</span></span></td>
        <td><span data-ttu-id="5612a-139">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-139">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-140">B</span><span class="sxs-lookup"><span data-stu-id="5612a-140">B</span></span></td>
        <td><span data-ttu-id="5612a-141">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-141">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-142">X</span><span class="sxs-lookup"><span data-stu-id="5612a-142">X</span></span></td>
        <td><span data-ttu-id="5612a-143">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-143">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-144">Y</span><span class="sxs-lookup"><span data-stu-id="5612a-144">Y</span></span></td>
        <td><span data-ttu-id="5612a-145">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-145">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-146">LeftShoulder</span><span class="sxs-lookup"><span data-stu-id="5612a-146">LeftShoulder</span></span></td>
        <td><span data-ttu-id="5612a-147">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-147">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-148">RightShoulder</span><span class="sxs-lookup"><span data-stu-id="5612a-148">RightShoulder</span></span></td>
        <td><span data-ttu-id="5612a-149">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-149">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-150">LeftThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="5612a-150">LeftThumbstickButton</span></span></td>
        <td><span data-ttu-id="5612a-151">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-151">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-152">RightThumbstickButton</span><span class="sxs-lookup"><span data-stu-id="5612a-152">RightThumbstickButton</span></span></td>
        <td><span data-ttu-id="5612a-153">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-153">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-154">DPadUp</span><span class="sxs-lookup"><span data-stu-id="5612a-154">DPadUp</span></span></td>
        <td><span data-ttu-id="5612a-155">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-155">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-156">DPadDown</span><span class="sxs-lookup"><span data-stu-id="5612a-156">DPadDown</span></span></td>
        <td><span data-ttu-id="5612a-157">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-157">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-158">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-158">DPadLeft</span></span></td>
        <td><span data-ttu-id="5612a-159">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-159">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-160">DPadRight</span><span class="sxs-lookup"><span data-stu-id="5612a-160">DPadRight</span></span></td>
        <td><span data-ttu-id="5612a-161">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-161">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-162">Paddle1</span><span class="sxs-lookup"><span data-stu-id="5612a-162">Paddle1</span></span></td>
        <td><span data-ttu-id="5612a-163">X</span><span class="sxs-lookup"><span data-stu-id="5612a-163">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-164">Paddle2</span><span class="sxs-lookup"><span data-stu-id="5612a-164">Paddle2</span></span></td>
        <td><span data-ttu-id="5612a-165">X</span><span class="sxs-lookup"><span data-stu-id="5612a-165">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-166">Paddle3</span><span class="sxs-lookup"><span data-stu-id="5612a-166">Paddle3</span></span></td>
        <td><span data-ttu-id="5612a-167">X</span><span class="sxs-lookup"><span data-stu-id="5612a-167">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-168">Paddle4</span><span class="sxs-lookup"><span data-stu-id="5612a-168">Paddle4</span></span></td>
        <td><span data-ttu-id="5612a-169">X</span><span class="sxs-lookup"><span data-stu-id="5612a-169">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-170">LeftTrigger</span><span class="sxs-lookup"><span data-stu-id="5612a-170">LeftTrigger</span></span></td>
        <td><span data-ttu-id="5612a-171">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-171">Yes</span></span></td>
        <td rowspan="6" style="vertical-align: middle;"><span data-ttu-id="5612a-172">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-172">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-173">RightTrigger</span><span class="sxs-lookup"><span data-stu-id="5612a-173">RightTrigger</span></span></td>
        <td><span data-ttu-id="5612a-174">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-174">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-175">LeftThumbstickX</span><span class="sxs-lookup"><span data-stu-id="5612a-175">LeftThumbstickX</span></span></td>
        <td><span data-ttu-id="5612a-176">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-176">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-177">LeftThumbstickY</span><span class="sxs-lookup"><span data-stu-id="5612a-177">LeftThumbstickY</span></span></td>
        <td><span data-ttu-id="5612a-178">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-178">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-179">RightThumbstickX</span><span class="sxs-lookup"><span data-stu-id="5612a-179">RightThumbstickX</span></span></td>
        <td><span data-ttu-id="5612a-180">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-180">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-181">RightThumbstickY</span><span class="sxs-lookup"><span data-stu-id="5612a-181">RightThumbstickY</span></span></td>
        <td><span data-ttu-id="5612a-182">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-182">Yes</span></span></td>
    </tr>
</table>

> [!NOTE]
> <span data-ttu-id="5612a-183">サポートされる **Gamepad** として、ゲーム コントローラーを追加する場合には、サポートされる **UINavigationController** としても、ゲーム コントローラーを追加することを強く推奨します。</span><span class="sxs-lookup"><span data-stu-id="5612a-183">If you add your game controller as a supported **Gamepad**, we highly recommend that you also add it as a supported **UINavigationController**.</span></span>

### <a name="racingwheel"></a><span data-ttu-id="5612a-184">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="5612a-184">RacingWheel</span></span>

<span data-ttu-id="5612a-185">次の表は **RacingWheel** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-185">The table below lists the required and optional subkeys under the **RacingWheel** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-186">サブキー</span><span class="sxs-lookup"><span data-stu-id="5612a-186">Subkey</span></span></th>
        <th><span data-ttu-id="5612a-187">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-187">Required?</span></span></th>
        <th><span data-ttu-id="5612a-188">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-188">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-189">PreviousGear</span><span class="sxs-lookup"><span data-stu-id="5612a-189">PreviousGear</span></span></td>
        <td><span data-ttu-id="5612a-190">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-190">Yes</span></span></td>
        <td rowspan="30" style="vertical-align: middle;"><span data-ttu-id="5612a-191">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-191">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-192">NextGear</span><span class="sxs-lookup"><span data-stu-id="5612a-192">NextGear</span></span></td>
        <td><span data-ttu-id="5612a-193">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-193">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-194">DPadUp</span><span class="sxs-lookup"><span data-stu-id="5612a-194">DPadUp</span></span></td>
        <td><span data-ttu-id="5612a-195">X</span><span class="sxs-lookup"><span data-stu-id="5612a-195">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-196">DPadDown</span><span class="sxs-lookup"><span data-stu-id="5612a-196">DPadDown</span></span></td>
        <td><span data-ttu-id="5612a-197">X</span><span class="sxs-lookup"><span data-stu-id="5612a-197">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-198">DPadLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-198">DPadLeft</span></span></td>
        <td><span data-ttu-id="5612a-199">X</span><span class="sxs-lookup"><span data-stu-id="5612a-199">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-200">DPadRight</span><span class="sxs-lookup"><span data-stu-id="5612a-200">DPadRight</span></span></td>
        <td><span data-ttu-id="5612a-201">X</span><span class="sxs-lookup"><span data-stu-id="5612a-201">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-202">Button1</span><span class="sxs-lookup"><span data-stu-id="5612a-202">Button1</span></span></td>
        <td><span data-ttu-id="5612a-203">X</span><span class="sxs-lookup"><span data-stu-id="5612a-203">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-204">Button2</span><span class="sxs-lookup"><span data-stu-id="5612a-204">Button2</span></span></td>
        <td><span data-ttu-id="5612a-205">X</span><span class="sxs-lookup"><span data-stu-id="5612a-205">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-206">Button3</span><span class="sxs-lookup"><span data-stu-id="5612a-206">Button3</span></span></td>
        <td><span data-ttu-id="5612a-207">X</span><span class="sxs-lookup"><span data-stu-id="5612a-207">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-208">Button4</span><span class="sxs-lookup"><span data-stu-id="5612a-208">Button4</span></span></td>
        <td><span data-ttu-id="5612a-209">X</span><span class="sxs-lookup"><span data-stu-id="5612a-209">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-210">Button5</span><span class="sxs-lookup"><span data-stu-id="5612a-210">Button5</span></span></td>
        <td><span data-ttu-id="5612a-211">X</span><span class="sxs-lookup"><span data-stu-id="5612a-211">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-212">Button6</span><span class="sxs-lookup"><span data-stu-id="5612a-212">Button6</span></span></td>
        <td><span data-ttu-id="5612a-213">X</span><span class="sxs-lookup"><span data-stu-id="5612a-213">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-214">Button7</span><span class="sxs-lookup"><span data-stu-id="5612a-214">Button7</span></span></td>
        <td><span data-ttu-id="5612a-215">X</span><span class="sxs-lookup"><span data-stu-id="5612a-215">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-216">Button8</span><span class="sxs-lookup"><span data-stu-id="5612a-216">Button8</span></span></td>
        <td><span data-ttu-id="5612a-217">X</span><span class="sxs-lookup"><span data-stu-id="5612a-217">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-218">Button9</span><span class="sxs-lookup"><span data-stu-id="5612a-218">Button9</span></span></td>
        <td><span data-ttu-id="5612a-219">X</span><span class="sxs-lookup"><span data-stu-id="5612a-219">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-220">Button10</span><span class="sxs-lookup"><span data-stu-id="5612a-220">Button10</span></span></td>
        <td><span data-ttu-id="5612a-221">X</span><span class="sxs-lookup"><span data-stu-id="5612a-221">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-222">Button11</span><span class="sxs-lookup"><span data-stu-id="5612a-222">Button11</span></span></td>
        <td><span data-ttu-id="5612a-223">X</span><span class="sxs-lookup"><span data-stu-id="5612a-223">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-224">Button12</span><span class="sxs-lookup"><span data-stu-id="5612a-224">Button12</span></span></td>
        <td><span data-ttu-id="5612a-225">X</span><span class="sxs-lookup"><span data-stu-id="5612a-225">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-226">Button13</span><span class="sxs-lookup"><span data-stu-id="5612a-226">Button13</span></span></td>
        <td><span data-ttu-id="5612a-227">X</span><span class="sxs-lookup"><span data-stu-id="5612a-227">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-228">Button14</span><span class="sxs-lookup"><span data-stu-id="5612a-228">Button14</span></span></td>
        <td><span data-ttu-id="5612a-229">X</span><span class="sxs-lookup"><span data-stu-id="5612a-229">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-230">Button15</span><span class="sxs-lookup"><span data-stu-id="5612a-230">Button15</span></span></td>
        <td><span data-ttu-id="5612a-231">X</span><span class="sxs-lookup"><span data-stu-id="5612a-231">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-232">Button16</span><span class="sxs-lookup"><span data-stu-id="5612a-232">Button16</span></span></td>
        <td><span data-ttu-id="5612a-233">X</span><span class="sxs-lookup"><span data-stu-id="5612a-233">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-234">FirstGear</span><span class="sxs-lookup"><span data-stu-id="5612a-234">FirstGear</span></span></td>
        <td><span data-ttu-id="5612a-235">X</span><span class="sxs-lookup"><span data-stu-id="5612a-235">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-236">SecondGear</span><span class="sxs-lookup"><span data-stu-id="5612a-236">SecondGear</span></span></td>
        <td><span data-ttu-id="5612a-237">X</span><span class="sxs-lookup"><span data-stu-id="5612a-237">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-238">ThirdGear</span><span class="sxs-lookup"><span data-stu-id="5612a-238">ThirdGear</span></span></td>
        <td><span data-ttu-id="5612a-239">X</span><span class="sxs-lookup"><span data-stu-id="5612a-239">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-240">FourthGear</span><span class="sxs-lookup"><span data-stu-id="5612a-240">FourthGear</span></span></td>
        <td><span data-ttu-id="5612a-241">X</span><span class="sxs-lookup"><span data-stu-id="5612a-241">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-242">FifthGear</span><span class="sxs-lookup"><span data-stu-id="5612a-242">FifthGear</span></span></td>
        <td><span data-ttu-id="5612a-243">X</span><span class="sxs-lookup"><span data-stu-id="5612a-243">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-244">SixthGear</span><span class="sxs-lookup"><span data-stu-id="5612a-244">SixthGear</span></span></td>
        <td><span data-ttu-id="5612a-245">X</span><span class="sxs-lookup"><span data-stu-id="5612a-245">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-246">SeventhGear</span><span class="sxs-lookup"><span data-stu-id="5612a-246">SeventhGear</span></span></td>
        <td><span data-ttu-id="5612a-247">X</span><span class="sxs-lookup"><span data-stu-id="5612a-247">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-248">ReverseGear</span><span class="sxs-lookup"><span data-stu-id="5612a-248">ReverseGear</span></span></td>
        <td><span data-ttu-id="5612a-249">X</span><span class="sxs-lookup"><span data-stu-id="5612a-249">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-250">Wheel</span><span class="sxs-lookup"><span data-stu-id="5612a-250">Wheel</span></span></td>
        <td><span data-ttu-id="5612a-251">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-251">Yes</span></span></td>
        <td rowspan="5" style="vertical-align: middle;"><span data-ttu-id="5612a-252">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-252">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-253">Throttle</span><span class="sxs-lookup"><span data-stu-id="5612a-253">Throttle</span></span></td>
        <td><span data-ttu-id="5612a-254">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-254">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-255">Brake</span><span class="sxs-lookup"><span data-stu-id="5612a-255">Brake</span></span></td>
        <td><span data-ttu-id="5612a-256">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-256">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-257">Clutch</span><span class="sxs-lookup"><span data-stu-id="5612a-257">Clutch</span></span></td>
        <td><span data-ttu-id="5612a-258">X</span><span class="sxs-lookup"><span data-stu-id="5612a-258">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-259">Handbrake</span><span class="sxs-lookup"><span data-stu-id="5612a-259">Handbrake</span></span></td>
        <td><span data-ttu-id="5612a-260">X</span><span class="sxs-lookup"><span data-stu-id="5612a-260">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-261">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="5612a-261">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="5612a-262">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-262">Yes</span></span></td>
        <td><span data-ttu-id="5612a-263">「<a href="#properties-mapping">プロパティ マッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-263">See <a href="#properties-mapping">Properties mapping</a></span></span></td>
    </tr>
</table>

### <a name="arcadestick"></a><span data-ttu-id="5612a-264">ArcadeStick</span><span class="sxs-lookup"><span data-stu-id="5612a-264">ArcadeStick</span></span>

<span data-ttu-id="5612a-265">次の表は **ArcadeStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-265">The table below lists the required and optional subkeys under the **ArcadeStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-266">サブキー</span><span class="sxs-lookup"><span data-stu-id="5612a-266">Subkey</span></span></th>
        <th><span data-ttu-id="5612a-267">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-267">Required?</span></span></th>
        <th><span data-ttu-id="5612a-268">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-268">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-269">Action1</span><span class="sxs-lookup"><span data-stu-id="5612a-269">Action 1</span></span></td>
        <td><span data-ttu-id="5612a-270">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-270">Yes</span></span></td>
        <td rowspan="12" style="vertical-align: middle;"><span data-ttu-id="5612a-271">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-271">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-272">Action2</span><span class="sxs-lookup"><span data-stu-id="5612a-272">Action2</span></span></td>
        <td><span data-ttu-id="5612a-273">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-273">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-274">Action3</span><span class="sxs-lookup"><span data-stu-id="5612a-274">Action3</span></span></td>
        <td><span data-ttu-id="5612a-275">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-275">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-276">Action4</span><span class="sxs-lookup"><span data-stu-id="5612a-276">Action4</span></span></td>
        <td><span data-ttu-id="5612a-277">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-277">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-278">Action5</span><span class="sxs-lookup"><span data-stu-id="5612a-278">Action5</span></span></td>
        <td><span data-ttu-id="5612a-279">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-279">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-280">Action6</span><span class="sxs-lookup"><span data-stu-id="5612a-280">Action6</span></span></td>
        <td><span data-ttu-id="5612a-281">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-281">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-282">Special1</span><span class="sxs-lookup"><span data-stu-id="5612a-282">Special1</span></span></td>
        <td><span data-ttu-id="5612a-283">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-283">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-284">Special2</span><span class="sxs-lookup"><span data-stu-id="5612a-284">Special2</span></span></td>
        <td><span data-ttu-id="5612a-285">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-285">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-286">StickUp</span><span class="sxs-lookup"><span data-stu-id="5612a-286">StickUp</span></span></td>
        <td><span data-ttu-id="5612a-287">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-287">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-288">StickDown</span><span class="sxs-lookup"><span data-stu-id="5612a-288">StickDown</span></span></td>
        <td><span data-ttu-id="5612a-289">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-289">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-290">StickLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-290">StickLeft</span></span></td>
        <td><span data-ttu-id="5612a-291">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-291">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-292">StickRight</span><span class="sxs-lookup"><span data-stu-id="5612a-292">StickRight</span></span></td>
        <td><span data-ttu-id="5612a-293">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-293">Yes</span></span></td>
    </tr>
</table>

### <a name="flightstick"></a><span data-ttu-id="5612a-294">FlightStick</span><span class="sxs-lookup"><span data-stu-id="5612a-294">FlightStick</span></span>

<span data-ttu-id="5612a-295">次の表は **FlightStick** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-295">The table below lists the required and optional subkeys under the **FlightStick** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-296">サブキー</span><span class="sxs-lookup"><span data-stu-id="5612a-296">Subkey</span></span></th>
        <th><span data-ttu-id="5612a-297">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-297">Required?</span></span></th>
        <th><span data-ttu-id="5612a-298">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-298">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-299">FirePrimary</span><span class="sxs-lookup"><span data-stu-id="5612a-299">FirePrimary</span></span></td>
        <td><span data-ttu-id="5612a-300">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-300">Yes</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-301">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-301">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-302">FireSecondary</span><span class="sxs-lookup"><span data-stu-id="5612a-302">FireSecondary</span></span></td>
        <td><span data-ttu-id="5612a-303">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-303">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-304">Roll</span><span class="sxs-lookup"><span data-stu-id="5612a-304">Roll</span></span></td>
        <td><span data-ttu-id="5612a-305">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-305">Yes</span></span></td>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="5612a-306">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-306">See <a href="#axis-mapping">Axis mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-307">Pitch</span><span class="sxs-lookup"><span data-stu-id="5612a-307">Pitch</span></span></td>
        <td><span data-ttu-id="5612a-308">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-308">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-309">Yaw</span><span class="sxs-lookup"><span data-stu-id="5612a-309">Yaw</span></span></td>
        <td><span data-ttu-id="5612a-310">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-310">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-311">Throttle</span><span class="sxs-lookup"><span data-stu-id="5612a-311">Throttle</span></span></td>
        <td><span data-ttu-id="5612a-312">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-312">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-313">HatSwitch</span><span class="sxs-lookup"><span data-stu-id="5612a-313">HatSwitch</span></span></td>
        <td><span data-ttu-id="5612a-314">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-314">Yes</span></span></td>
        <td><span data-ttu-id="5612a-315">「<a href="#switch-mapping">スイッチのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-315">See <a href="#switch-mapping">Switch mapping</a></span></span></td>
    </tr>
</table>

### <a name="uinavigation"></a><span data-ttu-id="5612a-316">UINavigation</span><span class="sxs-lookup"><span data-stu-id="5612a-316">UINavigation</span></span>

<span data-ttu-id="5612a-317">次の表は **UINavigation** サブキーの下の必須およびオプションのサブキーを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-317">The table below lists the required and optional subkeys under **UINavigation** subkey:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-318">サブキー</span><span class="sxs-lookup"><span data-stu-id="5612a-318">Subkey</span></span></th>
        <th><span data-ttu-id="5612a-319">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-319">Required?</span></span></th>
        <th><span data-ttu-id="5612a-320">Info</span><span class="sxs-lookup"><span data-stu-id="5612a-320">Info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-321">Menu</span><span class="sxs-lookup"><span data-stu-id="5612a-321">Menu</span></span></td>
        <td><span data-ttu-id="5612a-322">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-322">Yes</span></span></td>
        <td rowspan="24" style="vertical-align: middle;"><span data-ttu-id="5612a-323">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-323">See <a href="#button-mapping">Button mapping</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-324">ビュー</span><span class="sxs-lookup"><span data-stu-id="5612a-324">View</span></span></td>
        <td><span data-ttu-id="5612a-325">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-325">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-326">OK</span><span class="sxs-lookup"><span data-stu-id="5612a-326">Accept</span></span></td>
        <td><span data-ttu-id="5612a-327">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-327">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-328">Cancel</span><span class="sxs-lookup"><span data-stu-id="5612a-328">Cancel</span></span></td>
        <td><span data-ttu-id="5612a-329">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-329">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-330">PrimaryUp</span><span class="sxs-lookup"><span data-stu-id="5612a-330">PrimaryUp</span></span></td>
        <td><span data-ttu-id="5612a-331">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-331">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-332">PrimaryDown</span><span class="sxs-lookup"><span data-stu-id="5612a-332">PrimaryDown</span></span></td>
        <td><span data-ttu-id="5612a-333">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-333">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-334">PrimaryLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-334">PrimaryLeft</span></span></td>
        <td><span data-ttu-id="5612a-335">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-335">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-336">PrimaryRight</span><span class="sxs-lookup"><span data-stu-id="5612a-336">PrimaryRight</span></span></td>
        <td><span data-ttu-id="5612a-337">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-337">Yes</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-338">Context1</span><span class="sxs-lookup"><span data-stu-id="5612a-338">Context1</span></span></td>
        <td><span data-ttu-id="5612a-339">X</span><span class="sxs-lookup"><span data-stu-id="5612a-339">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-340">Context2</span><span class="sxs-lookup"><span data-stu-id="5612a-340">Context2</span></span></td>
        <td><span data-ttu-id="5612a-341">X</span><span class="sxs-lookup"><span data-stu-id="5612a-341">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-342">Context3</span><span class="sxs-lookup"><span data-stu-id="5612a-342">Context3</span></span></td>
        <td><span data-ttu-id="5612a-343">X</span><span class="sxs-lookup"><span data-stu-id="5612a-343">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-344">Context4</span><span class="sxs-lookup"><span data-stu-id="5612a-344">Context4</span></span></td>
        <td><span data-ttu-id="5612a-345">X</span><span class="sxs-lookup"><span data-stu-id="5612a-345">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-346">PageUp</span><span class="sxs-lookup"><span data-stu-id="5612a-346">PageUp</span></span></td>
        <td><span data-ttu-id="5612a-347">X</span><span class="sxs-lookup"><span data-stu-id="5612a-347">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-348">PageDown</span><span class="sxs-lookup"><span data-stu-id="5612a-348">PageDown</span></span></td>
        <td><span data-ttu-id="5612a-349">X</span><span class="sxs-lookup"><span data-stu-id="5612a-349">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-350">PageLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-350">PageLeft</span></span></td>
        <td><span data-ttu-id="5612a-351">X</span><span class="sxs-lookup"><span data-stu-id="5612a-351">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-352">PageRight</span><span class="sxs-lookup"><span data-stu-id="5612a-352">PageRight</span></span></td>
        <td><span data-ttu-id="5612a-353">X</span><span class="sxs-lookup"><span data-stu-id="5612a-353">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-354">ScrollUp</span><span class="sxs-lookup"><span data-stu-id="5612a-354">ScrollUp</span></span></td>
        <td><span data-ttu-id="5612a-355">X</span><span class="sxs-lookup"><span data-stu-id="5612a-355">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-356">ScrollDown</span><span class="sxs-lookup"><span data-stu-id="5612a-356">ScrollDown</span></span></td>
        <td><span data-ttu-id="5612a-357">X</span><span class="sxs-lookup"><span data-stu-id="5612a-357">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-358">ScrollLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-358">ScrollLeft</span></span></td>
        <td><span data-ttu-id="5612a-359">X</span><span class="sxs-lookup"><span data-stu-id="5612a-359">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-360">ScrollRight</span><span class="sxs-lookup"><span data-stu-id="5612a-360">ScrollRight</span></span></td>
        <td><span data-ttu-id="5612a-361">X</span><span class="sxs-lookup"><span data-stu-id="5612a-361">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-362">SecondaryUp</span><span class="sxs-lookup"><span data-stu-id="5612a-362">SecondaryUp</span></span></td>
        <td><span data-ttu-id="5612a-363">X</span><span class="sxs-lookup"><span data-stu-id="5612a-363">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-364">SecondaryDown</span><span class="sxs-lookup"><span data-stu-id="5612a-364">SecondaryDown</span></span></td>
        <td><span data-ttu-id="5612a-365">X</span><span class="sxs-lookup"><span data-stu-id="5612a-365">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-366">SecondaryLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-366">SecondaryLeft</span></span></td>
        <td><span data-ttu-id="5612a-367">X</span><span class="sxs-lookup"><span data-stu-id="5612a-367">No</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-368">SecondaryRight</span><span class="sxs-lookup"><span data-stu-id="5612a-368">SecondaryRight</span></span></td>
        <td><span data-ttu-id="5612a-369">X</span><span class="sxs-lookup"><span data-stu-id="5612a-369">No</span></span></td>
    </tr>
</table>

<span data-ttu-id="5612a-370">UI ナビゲーション コントローラーと上記のコマンドについて詳しくは、「[UI ナビゲーション コントローラー](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5612a-370">For more information about UI navigation controllers and the above commands, see [UI navigation controller](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller).</span></span>

## <a name="keys"></a><span data-ttu-id="5612a-371">キー</span><span class="sxs-lookup"><span data-stu-id="5612a-371">Keys</span></span>

<span data-ttu-id="5612a-372">次のセクションでは、**Gamepad**、**RacingWheel**、**ArcadeStick**、**FlightStick**、**UINavigation** キーの下のサブキーのそれぞれのコンテンツについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5612a-372">The following sections explain the contents of each of the subkeys under the **Gamepad**, **RacingWheel**, **ArcadeStick**, **FlightStick**, and **UINavigation** keys.</span></span>

### <a name="button-mapping"></a><span data-ttu-id="5612a-373">ボタンのマッピング</span><span class="sxs-lookup"><span data-stu-id="5612a-373">Button mapping</span></span>

<span data-ttu-id="5612a-374">次の表は、ボタンのマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-374">The table below lists the values that are needed to map a button.</span></span> <span data-ttu-id="5612a-375">たとえば、ゲーム コントローラーの **DPadUp** キーを押すと、**DPadUp** のマッピングには **ButtonIndex** 値が含まれます (**Source** は **Button** です)。</span><span class="sxs-lookup"><span data-stu-id="5612a-375">For example, if pressing **DPadUp** on the game controller, the mapping for **DPadUp** should contain the **ButtonIndex** value (**Source** is **Button**).</span></span> <span data-ttu-id="5612a-376">**DPadUp** がスイッチの位置からマッピングされる必要がある場合は、**DPadUp** マッピングには **SwitchIndex** と **SwitchPosition** の値が含まれます (**Source** は **Switch** です)。</span><span class="sxs-lookup"><span data-stu-id="5612a-376">If **DPadUp** needs to be mapped from a switch position, then the **DPadUp** mapping should contain the values **SwitchIndex** and **SwitchPosition** (**Source** is **Switch**).</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-377">Source</span><span class="sxs-lookup"><span data-stu-id="5612a-377">Source</span></span></th>
        <th><span data-ttu-id="5612a-378">値の名前</span><span class="sxs-lookup"><span data-stu-id="5612a-378">Value name</span></span></th>
        <th><span data-ttu-id="5612a-379">値の種類</span><span class="sxs-lookup"><span data-stu-id="5612a-379">Value type</span></span></th>
        <th><span data-ttu-id="5612a-380">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-380">Required?</span></span></th>
        <th><span data-ttu-id="5612a-381">値の情報</span><span class="sxs-lookup"><span data-stu-id="5612a-381">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-382">Button</span><span class="sxs-lookup"><span data-stu-id="5612a-382">Button</span></span></td>
        <td><span data-ttu-id="5612a-383">ButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-383">ButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-384">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-384">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-385">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-385">Yes</span></span></td>
        <td><span data-ttu-id="5612a-386"><b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-386">Index in the <b>RawGameController</b> button array.</span></span></td>
    </tr>
    <tr>
        <td rowspan="4" style="vertical-align: middle;"><span data-ttu-id="5612a-387">Axis</span><span class="sxs-lookup"><span data-stu-id="5612a-387">Axis</span></span></td>
        <td><span data-ttu-id="5612a-388">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-388">AxisIndex</span></span></td>
        <td><span data-ttu-id="5612a-389">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-389">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-390">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-390">Yes</span></span></td>
        <td><span data-ttu-id="5612a-391"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-391">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-392">Invert</span><span class="sxs-lookup"><span data-stu-id="5612a-392">Invert</span></span></td>
        <td><span data-ttu-id="5612a-393">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-393">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-394">X</span><span class="sxs-lookup"><span data-stu-id="5612a-394">No</span></span></td>
        <td><span data-ttu-id="5612a-395"><b>ThresholdPercent</b> と <b>DebouncePercent</b> 要素を適用する前に、軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-395">Indicates that the axis value should be inverted before the <b>Threshold Percent</b> and <b>DebouncePercent</b> factors are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-396">ThresholdPercent</span><span class="sxs-lookup"><span data-stu-id="5612a-396">ThresholdPercent</span></span></td>
        <td><span data-ttu-id="5612a-397">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-397">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-398">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-398">Yes</span></span></td>
        <td><span data-ttu-id="5612a-399">マッピングされたボタンの値の (押した状態と離した状態の間の) 遷移の軸の位置を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-399">Indicates the axis position at which the mapped button value transitions between the pressed and released states.</span></span> <span data-ttu-id="5612a-400">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="5612a-400">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="5612a-401">軸の値がこの値以上の場合、ボタンが押されたと見なされます。</span><span class="sxs-lookup"><span data-stu-id="5612a-401">The button is considered pressed if the axis value is greater than or equal to this value.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-402">DebouncePercent</span><span class="sxs-lookup"><span data-stu-id="5612a-402">DebouncePercent</span></span></td>
        <td><span data-ttu-id="5612a-403">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-403">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-404">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-404">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-405"><b>ThresholdPercent</b> 値の周囲のウィンドウのサイズを定義します。報告されたボタンの状態をデバウンスするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-405">Defines the size of a window around the <b>ThresholdPercent</b> value, which is used to debounce the reported button state.</span></span> <span data-ttu-id="5612a-406">有効な値の範囲は 0 から 100 です。</span><span class="sxs-lookup"><span data-stu-id="5612a-406">The valid range of values is 0 to 100.</span></span> <span data-ttu-id="5612a-407">ボタンの状態の遷移は、軸の値がデバウンス ウィンドウの上限または下限を超えたときにのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="5612a-407">Button state transitions can only occur when the axis value crosses the upper or lower boundaries of the debounce window.</span></span> <span data-ttu-id="5612a-408">たとえば、<b>ThresholdPercent</b> が 50 で、<b>DebouncePercent</b> が 10 の場合には、デバウンスの下限と上限は、全範囲の軸の値で 45% と 55% となります。</span><span class="sxs-lookup"><span data-stu-id="5612a-408">For example, a <b>ThresholdPercent</b> of 50 and <b>DebouncePercent</b> of 10 results in debounce boundaries at 45% and 55% of the full-range axis values.</span></span> <span data-ttu-id="5612a-409">軸の値が 55% 以上に達すると、ボタンは押された状態に遷移し、軸の値が 45% 以下に達すると、ボタンはリリースされた状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="5612a-409">The button can't transition to the pressed state until the axis value reaches 55% or above, and it can't transition back to the released state until the axis value reaches 45% or below.</span></span></p>
            <p><span data-ttu-id="5612a-410">計算されるデバウンス ウィンドウの境界は 0% ～ 100% の間でクランプされます。</span><span class="sxs-lookup"><span data-stu-id="5612a-410">The computed debounce window boundaries are clamped between 0% and 100%.</span></span> <span data-ttu-id="5612a-411">たとえば、しきい値が 5% で、デバウンス ウィンドウが 20% の場合、デバウンス ウィンドウの境界は 0% と 15% となります。</span><span class="sxs-lookup"><span data-stu-id="5612a-411">For example, a threshold of 5% and a debounce window of 20% would result in the debounce window boundaries falling at 0% and 15%.</span></span> <span data-ttu-id="5612a-412">しきい値とデバウンスの値にかかわらず、軸の値が 0% ～ 100% にあるボタンの状態は常に、押されるか、または離されるかとして報告されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-412">The button state for axis values of 0% and 100% are always reported as released and pressed, respectively, regardless of the threshold and debounce values.</span></span></p>
        </td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="5612a-413">Switch</span><span class="sxs-lookup"><span data-stu-id="5612a-413">Switch</span></span></td>
        <td><span data-ttu-id="5612a-414">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-414">SwitchIndex</span></span></td>
        <td><span data-ttu-id="5612a-415">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-415">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-416">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-416">Yes</span></span></td>
        <td><span data-ttu-id="5612a-417"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-417">Index in the <b>RawGameController</b> switch array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-418">SwitchPosition</span><span class="sxs-lookup"><span data-stu-id="5612a-418">SwitchPosition</span></span></td>
        <td><span data-ttu-id="5612a-419">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="5612a-419">REG_SZ</span></span></td>
        <td><span data-ttu-id="5612a-420">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-420">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-421">マッピングされたボタンが押されたことを報告するスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-421">Indicates the switch position that will cause the mapped button to report that it's being pressed.</span></span> <span data-ttu-id="5612a-422">位置の値には、次の文字列のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="5612a-422">The position values can be one of these strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="5612a-423">Up</span><span class="sxs-lookup"><span data-stu-id="5612a-423">Up</span></span></li> 
                <li><span data-ttu-id="5612a-424">UpRight</span><span class="sxs-lookup"><span data-stu-id="5612a-424">UpRight</span></span></li>
                <li><span data-ttu-id="5612a-425">右</span><span class="sxs-lookup"><span data-stu-id="5612a-425">Right</span></span></li>
                <li><span data-ttu-id="5612a-426">DownRight</span><span class="sxs-lookup"><span data-stu-id="5612a-426">DownRight</span></span></li>
                <li><span data-ttu-id="5612a-427">Down</span><span class="sxs-lookup"><span data-stu-id="5612a-427">Down</span></span></li>
                <li><span data-ttu-id="5612a-428">DownLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-428">DownLeft</span></span></li>
                <li><span data-ttu-id="5612a-429">Left</span><span class="sxs-lookup"><span data-stu-id="5612a-429">Left</span></span></li>
                <li><span data-ttu-id="5612a-430">UpLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-430">UpLeft</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-431">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="5612a-431">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="5612a-432">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-432">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-433">X</span><span class="sxs-lookup"><span data-stu-id="5612a-433">No</span></span></td>
        <td><span data-ttu-id="5612a-434">隣接するスイッチの位置も、マッピングされたボタンが押されたことを報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-434">Indicates that adjacent switch positions will also cause the mapped button to report that it's being pressed.</span></span></td>
    </tr>
</table>

### <a name="axis-mapping"></a><span data-ttu-id="5612a-435">軸のマッピング</span><span class="sxs-lookup"><span data-stu-id="5612a-435">Axis mapping</span></span>

<span data-ttu-id="5612a-436">次の表は、軸のマッピングに必要な値を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-436">The table below lists the values that are needed to map an axis:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-437">Source</span><span class="sxs-lookup"><span data-stu-id="5612a-437">Source</span></span></th>
        <th><span data-ttu-id="5612a-438">値の名前</span><span class="sxs-lookup"><span data-stu-id="5612a-438">Value name</span></span></th>
        <th><span data-ttu-id="5612a-439">値の種類</span><span class="sxs-lookup"><span data-stu-id="5612a-439">Value type</span></span></th>
        <th><span data-ttu-id="5612a-440">必須?</span><span class="sxs-lookup"><span data-stu-id="5612a-440">Required?</span></span></th>
        <th><span data-ttu-id="5612a-441">値の情報</span><span class="sxs-lookup"><span data-stu-id="5612a-441">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-442">Button</span><span class="sxs-lookup"><span data-stu-id="5612a-442">Button</span></span></td>
        <td><span data-ttu-id="5612a-443">MaxValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-443">MaxValueButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-444">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-444">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-445">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-445">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-446">マッピングされた一方向の軸の値に変換される、<b>RawGameController</b> ボタンの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-446">Index in the <b>RawGameController</b> button array which gets translated to the mapped unidirectional axis value.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="5612a-447">MaxButton</span><span class="sxs-lookup"><span data-stu-id="5612a-447">MaxButton</span></span></th>
                    <th><span data-ttu-id="5612a-448">AxisValue</span><span class="sxs-lookup"><span data-stu-id="5612a-448">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-449">FALSE</span><span class="sxs-lookup"><span data-stu-id="5612a-449">FALSE</span></span></td>
                    <td><span data-ttu-id="5612a-450">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-450">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-451">TRUE</span><span class="sxs-lookup"><span data-stu-id="5612a-451">TRUE</span></span></td>
                    <td><span data-ttu-id="5612a-452">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-452">1.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-453">MinValueButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-453">MinValueButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-454">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-454">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-455">X</span><span class="sxs-lookup"><span data-stu-id="5612a-455">No</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-456">マッピングされた軸が双方向であることを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-456">Indicates that the mapped axis is bidirectional.</span></span> <span data-ttu-id="5612a-457"><b>MaxButton</b> と <b>MinButton</b> の値は結合され、次に示すように 1 つの双方向の軸となります。</span><span class="sxs-lookup"><span data-stu-id="5612a-457">Values of <b>MaxButton</b> and <b>MinButton</b> are combined into a single bidirectional axis as shown below.</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="5612a-458">MinButton</span><span class="sxs-lookup"><span data-stu-id="5612a-458">MinButton</span></span></th>
                    <th><span data-ttu-id="5612a-459">MaxButton</span><span class="sxs-lookup"><span data-stu-id="5612a-459">MaxButton</span></span></th>
                    <th><span data-ttu-id="5612a-460">AxisValue</span><span class="sxs-lookup"><span data-stu-id="5612a-460">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-461">FALSE</span><span class="sxs-lookup"><span data-stu-id="5612a-461">FALSE</span></span></td>
                    <td><span data-ttu-id="5612a-462">FALSE</span><span class="sxs-lookup"><span data-stu-id="5612a-462">FALSE</span></span></td>
                    <td><span data-ttu-id="5612a-463">0.5</span><span class="sxs-lookup"><span data-stu-id="5612a-463">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-464">FALSE</span><span class="sxs-lookup"><span data-stu-id="5612a-464">FALSE</span></span></td>
                    <td><span data-ttu-id="5612a-465">TRUE</span><span class="sxs-lookup"><span data-stu-id="5612a-465">TRUE</span></span></td>
                    <td><span data-ttu-id="5612a-466">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-466">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-467">TRUE</span><span class="sxs-lookup"><span data-stu-id="5612a-467">TRUE</span></span></td>
                    <td><span data-ttu-id="5612a-468">FALSE</span><span class="sxs-lookup"><span data-stu-id="5612a-468">FALSE</span></span></td>
                    <td><span data-ttu-id="5612a-469">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-469">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-470">TRUE</span><span class="sxs-lookup"><span data-stu-id="5612a-470">TRUE</span></span></td>
                    <td><span data-ttu-id="5612a-471">TRUE</span><span class="sxs-lookup"><span data-stu-id="5612a-471">TRUE</span></span></td>
                    <td><span data-ttu-id="5612a-472">0.5</span><span class="sxs-lookup"><span data-stu-id="5612a-472">0.5</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-473">Axis</span><span class="sxs-lookup"><span data-stu-id="5612a-473">Axis</span></span></td>
        <td><span data-ttu-id="5612a-474">AxisIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-474">AxisIndex</span></span></td>
        <td><span data-ttu-id="5612a-475">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-475">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-476">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-476">Yes</span></span></td>
        <td><span data-ttu-id="5612a-477"><b>RawGameController</b> 軸の配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-477">Index in the <b>RawGameController</b> axis array.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-478">Invert</span><span class="sxs-lookup"><span data-stu-id="5612a-478">Invert</span></span></td>
        <td><span data-ttu-id="5612a-479">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-479">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-480">X</span><span class="sxs-lookup"><span data-stu-id="5612a-480">No</span></span></td>
        <td><span data-ttu-id="5612a-481">マッピングされた軸の値を返す前に反転するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-481">Indicates that the mapped axis value should be inverted before it's returned.</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="5612a-482">Switch</span><span class="sxs-lookup"><span data-stu-id="5612a-482">Switch</span></span></td>
        <td><span data-ttu-id="5612a-483">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-483">SwitchIndex</span></span></td>
        <td><span data-ttu-id="5612a-484">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-484">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-485">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-485">Yes</span></span></td>
        <td><span data-ttu-id="5612a-486"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-486">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-487">MaxValueSwitchPosition</span><span class="sxs-lookup"><span data-stu-id="5612a-487">MaxValueSwitchPosition</span></span></td>
        <td><span data-ttu-id="5612a-488">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="5612a-488">REG_SZ</span></span></td>
        <td><span data-ttu-id="5612a-489">〇</span><span class="sxs-lookup"><span data-stu-id="5612a-489">Yes</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-490">次のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="5612a-490">One of the following strings:</span></span></p>
            <ul>
                <li><span data-ttu-id="5612a-491">Up</span><span class="sxs-lookup"><span data-stu-id="5612a-491">Up</span></span></li>
                <li><span data-ttu-id="5612a-492">UpRight</span><span class="sxs-lookup"><span data-stu-id="5612a-492">UpRight</span></span></li>
                <li><span data-ttu-id="5612a-493">右</span><span class="sxs-lookup"><span data-stu-id="5612a-493">Right</span></span></li>
                <li><span data-ttu-id="5612a-494">DownRight</span><span class="sxs-lookup"><span data-stu-id="5612a-494">DownRight</span></span></li>
                <li><span data-ttu-id="5612a-495">Down</span><span class="sxs-lookup"><span data-stu-id="5612a-495">Down</span></span></li>
                <li><span data-ttu-id="5612a-496">DownLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-496">DownLeft</span></span></li>
                <li><span data-ttu-id="5612a-497">Left</span><span class="sxs-lookup"><span data-stu-id="5612a-497">Left</span></span></li>
                <li><span data-ttu-id="5612a-498">UpLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-498">UpLeft</span></span></li>
            </ul>
            <p><span data-ttu-id="5612a-499">マッピングされた軸の値が 1.0 として報告されるスイッチの位置を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-499">It indicates the position of the switch that causes the mapped axis value to be reported as 1.0.</span></span> <span data-ttu-id="5612a-500">反対方向の <b>MaxValueSwitchPosition</b> は 0.0 と見なされます。</span><span class="sxs-lookup"><span data-stu-id="5612a-500">The opposing direction of <b>MaxValueSwitchPosition</b> is treated as 0.0.</span></span> <span data-ttu-id="5612a-501">たとえば、<b>MaxValueSwitchPosition</b> が <b>Up</b> の場合、軸の値は次を意味します。</span><span class="sxs-lookup"><span data-stu-id="5612a-501">For example, if <b>MaxValueSwitchPosition</b> is <b>Up</b>, the axis value translation is shown below:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="5612a-502">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="5612a-502">Switch position</span></span></th>
                    <th><span data-ttu-id="5612a-503">AxisValue</span><span class="sxs-lookup"><span data-stu-id="5612a-503">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-504">Up</span><span class="sxs-lookup"><span data-stu-id="5612a-504">Up</span></span></td>
                    <td><span data-ttu-id="5612a-505">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-505">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-506">Center</span><span class="sxs-lookup"><span data-stu-id="5612a-506">Center</span></span></td>
                    <td><span data-ttu-id="5612a-507">0.5</span><span class="sxs-lookup"><span data-stu-id="5612a-507">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-508">Down</span><span class="sxs-lookup"><span data-stu-id="5612a-508">Down</span></span></td>
                    <td><span data-ttu-id="5612a-509">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-509">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-510">IncludeAdjacent</span><span class="sxs-lookup"><span data-stu-id="5612a-510">IncludeAdjacent</span></span></td>
        <td><span data-ttu-id="5612a-511">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-511">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-512">X</span><span class="sxs-lookup"><span data-stu-id="5612a-512">No</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-513">隣接するスイッチの位置も、マッピングされた軸が 1.0 を報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-513">Indicates that adjacent switch positions will also cause the mapped axis to report 1.0.</span></span> <span data-ttu-id="5612a-514">上記の例では、<b>IncludeAdjacent</b> が設定されている場合、軸は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5612a-514">In the above example, if <b>IncludeAdjacent</b> is set, then the axis translation is done as follows:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="5612a-515">スイッチの位置</span><span class="sxs-lookup"><span data-stu-id="5612a-515">Switch position</span></span></th>
                    <th><span data-ttu-id="5612a-516">AxisValue</span><span class="sxs-lookup"><span data-stu-id="5612a-516">AxisValue</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-517">Up</span><span class="sxs-lookup"><span data-stu-id="5612a-517">Up</span></span></td>
                    <td><span data-ttu-id="5612a-518">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-518">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-519">UpRight</span><span class="sxs-lookup"><span data-stu-id="5612a-519">UpRight</span></span></td>
                    <td><span data-ttu-id="5612a-520">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-520">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-521">UpLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-521">UpLeft</span></span></td>
                    <td><span data-ttu-id="5612a-522">1.0</span><span class="sxs-lookup"><span data-stu-id="5612a-522">1.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-523">Center</span><span class="sxs-lookup"><span data-stu-id="5612a-523">Center</span></span></td>
                    <td><span data-ttu-id="5612a-524">0.5</span><span class="sxs-lookup"><span data-stu-id="5612a-524">0.5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-525">Down</span><span class="sxs-lookup"><span data-stu-id="5612a-525">Down</span></span></td>
                    <td><span data-ttu-id="5612a-526">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-526">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-527">DownRight</span><span class="sxs-lookup"><span data-stu-id="5612a-527">DownRight</span></span></td>
                    <td><span data-ttu-id="5612a-528">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-528">0.0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-529">DownLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-529">DownLeft</span></span></td>
                    <td><span data-ttu-id="5612a-530">0.0</span><span class="sxs-lookup"><span data-stu-id="5612a-530">0.0</span></span></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

### <a name="switch-mapping"></a><span data-ttu-id="5612a-531">スイッチのマッピング</span><span class="sxs-lookup"><span data-stu-id="5612a-531">Switch mapping</span></span>

<span data-ttu-id="5612a-532">スイッチの位置は、**RawGameController** のボタンの配列のボタンのセットから、またはスイッチの配列のインデックスからマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="5612a-532">Switch positions can be mapped either from a set of buttons in the buttons array of the **RawGameController** or from an index in the switches array.</span></span> <span data-ttu-id="5612a-533">軸からスイッチの位置をマッピングすることはできません。</span><span class="sxs-lookup"><span data-stu-id="5612a-533">Switch positions can't be mapped from axes.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-534">Source</span><span class="sxs-lookup"><span data-stu-id="5612a-534">Source</span></span></th>
        <th><span data-ttu-id="5612a-535">値の名前</span><span class="sxs-lookup"><span data-stu-id="5612a-535">Value name</span></span></th>
        <th><span data-ttu-id="5612a-536">値の種類</span><span class="sxs-lookup"><span data-stu-id="5612a-536">Value type</span></span></th>
        <th><span data-ttu-id="5612a-537">値の情報</span><span class="sxs-lookup"><span data-stu-id="5612a-537">Value info</span></span></th>
    </tr>
    <tr>
        <td rowspan="10" style="vertical-align: middle;"><span data-ttu-id="5612a-538">Button</span><span class="sxs-lookup"><span data-stu-id="5612a-538">Button</span></span></td>
        <td><span data-ttu-id="5612a-539">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="5612a-539">ButtonCount</span></span></td>
        <td><span data-ttu-id="5612a-540">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-540">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-541">2、4、または 8</span><span class="sxs-lookup"><span data-stu-id="5612a-541">2, 4, or 8</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-542">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="5612a-542">SwitchKind</span></span></td>
        <td><span data-ttu-id="5612a-543">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="5612a-543">REG_SZ</span></span></td>
        <td><span data-ttu-id="5612a-544"><b>TwoWay</b>、 <b>FourWay</b>、または<b>EightWay</b>
    </span><span class="sxs-lookup"><span data-stu-id="5612a-544"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b>
    </span></span></tr>
    <tr>
        <td><span data-ttu-id="5612a-545">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-545">UpButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-546">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-546">DWORD</span></span></td>
        <td rowspan="8" style="vertical-align: middle;"><span data-ttu-id="5612a-547">「<a href="#buttonindex-values">\*ButtonIndex の値</a>」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="5612a-547">See <a href="#buttonindex-values">\*ButtonIndex values</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-548">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-548">DownButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-549">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-549">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-550">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-550">LeftButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-551">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-551">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-552">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-552">RightButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-553">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-553">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-554">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-554">UpRightButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-555">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-555">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-556">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-556">DownRightButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-557">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-557">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-558">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-558">DownLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-559">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-559">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-560">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-560">UpLeftButtonIndex</span></span></td>
        <td><span data-ttu-id="5612a-561">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-561">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="9" style="vertical-align: middle;"><span data-ttu-id="5612a-562">Axis</span><span class="sxs-lookup"><span data-stu-id="5612a-562">Axis</span></span></td>
        <td><span data-ttu-id="5612a-563">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="5612a-563">SwitchKind</span></span></td>
        <td><span data-ttu-id="5612a-564">REG_SZ</span><span class="sxs-lookup"><span data-stu-id="5612a-564">REG_SZ</span></span></td>
        <td><span data-ttu-id="5612a-565"><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></span><span class="sxs-lookup"><span data-stu-id="5612a-565"><b>TwoWay</b>, <b>FourWay</b>, or <b>EightWay</b></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-566">XAxisIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-566">XAxisIndex</span></span></td>
        <td><span data-ttu-id="5612a-567">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-567">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-568"><b>YAxisIndex</b> は常に存在します。</span><span class="sxs-lookup"><span data-stu-id="5612a-568"><b>YAxisIndex</b> is always present.</span></span> <span data-ttu-id="5612a-569"><b>XAxisIndex</b> は、<b>SwitchKind</b> が <b>FourWay</b> または <b>EightWay</b> の場合のみ存在します。</span><span class="sxs-lookup"><span data-stu-id="5612a-569"><b>XAxisIndex</b> is only present when <b>SwitchKind</b> is <b>FourWay</b> or <b>EightWay</b>.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-570">YAxisIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-570">YAxisIndex</span></span></td>
        <td><span data-ttu-id="5612a-571">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-571">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-572">XDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="5612a-572">XDeadZonePercent</span></span></td>
        <td><span data-ttu-id="5612a-573">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-573">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-574">軸の中央位置の周囲のデッド ゾーンのサイズを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-574">Indicate the size of the dead zone around the center position of the axes.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-575">YDeadZonePercent</span><span class="sxs-lookup"><span data-stu-id="5612a-575">YDeadZonePercent</span></span></td>
        <td><span data-ttu-id="5612a-576">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-576">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-577">XDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="5612a-577">XDebouncePercent</span></span></td>
        <td><span data-ttu-id="5612a-578">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-578">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-579">デッド ゾーンの上限と下限の周囲のウィンドウのサイズを定義します。これは報告されたスイッチの状態のデバウンスに使用されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-579">Define the size of the windows around the upper and lower dead zone limits, which are used to de-bounce the reported switch state.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-580">YDebouncePercent</span><span class="sxs-lookup"><span data-stu-id="5612a-580">YDebouncePercent</span></span></td>
        <td><span data-ttu-id="5612a-581">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-581">DWORD</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-582">XInvert</span><span class="sxs-lookup"><span data-stu-id="5612a-582">XInvert</span></span></td>
        <td><span data-ttu-id="5612a-583">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-583">DWORD</span></span></td>
        <td rowspan="2" style="vertical-align: middle;"><span data-ttu-id="5612a-584">デッド ゾーンとデバウンス ウィンドウの計算を適用する前に、対応する軸の値を反転する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-584">Indicate that the corresponding axis values should be inverted before the dead zone and debounce window calculations are applied.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-585">YInvert</span><span class="sxs-lookup"><span data-stu-id="5612a-585">YInvert</span></span></td>
        <td><span data-ttu-id="5612a-586">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-586">DWORD</span></span></td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;"><span data-ttu-id="5612a-587">Switch</span><span class="sxs-lookup"><span data-stu-id="5612a-587">Switch</span></span></td>
        <td><span data-ttu-id="5612a-588">SwitchIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-588">SwitchIndex</span></span></td>
        <td><span data-ttu-id="5612a-589">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-589">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-590"><b>RawGameController</b> スイッチの配列のインデックス。</span><span class="sxs-lookup"><span data-stu-id="5612a-590">Index in the <b>RawGameController</b> switch array.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-591">Invert</span><span class="sxs-lookup"><span data-stu-id="5612a-591">Invert</span></span></td>
        <td><span data-ttu-id="5612a-592">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-592">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-593">スイッチが位置を、既定の時計回りの順序ではなく、反時計回りの順序で報告することを示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-593">Indicates that the switch reports its positions in a counter-clockwise order, rather than the default clockwise order.</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-594">PositionBias</span><span class="sxs-lookup"><span data-stu-id="5612a-594">PositionBias</span></span></td>
        <td><span data-ttu-id="5612a-595">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-595">DWORD</span></span></td>
        <td>
            <p><span data-ttu-id="5612a-596">位置の報告の開始点を指定した量だけ移動します。</span><span class="sxs-lookup"><span data-stu-id="5612a-596">Shifts the starting point of how positions are reported by the specified amount.</span></span> <span data-ttu-id="5612a-597"><b>PositionBias</b> は常に元の開始点から時計回りにカウントされます。値の順序が反転される前に適用されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-597"><b>PositionBias</b> is always counted clockwise from the original starting point, and is applied before the order of values is reversed.</span></span></p>
            <p><span data-ttu-id="5612a-598">たとえば、<b>DownRight</b>で始まる位置を反時計回りの順序で報告するスイッチは、<b>Invert</b> フラグを設定して、<b>PositionBias</b> を 5 と設定することによって正規化されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-598">For example, a switch that reports positions starting with <b>DownRight</b> in counter-clockwise order can be normalized by setting the <b>Invert</b> flag and specifying a <b>PositionBias</b> of 5:</span></span></p>
            <table>
                <tr>
                    <th><span data-ttu-id="5612a-599">位置</span><span class="sxs-lookup"><span data-stu-id="5612a-599">Position</span></span></th>
                    <th><span data-ttu-id="5612a-600">報告される値</span><span class="sxs-lookup"><span data-stu-id="5612a-600">Reported value</span></span></th>
                    <th><span data-ttu-id="5612a-601">PositionBias と Invert フラグの設定後</span><span class="sxs-lookup"><span data-stu-id="5612a-601">After PositionBias and Invert flags</span></span></th>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-602">DownRight</span><span class="sxs-lookup"><span data-stu-id="5612a-602">DownRight</span></span></td>
                    <td><span data-ttu-id="5612a-603">0</span><span class="sxs-lookup"><span data-stu-id="5612a-603">0</span></span></td>
                    <td><span data-ttu-id="5612a-604">3</span><span class="sxs-lookup"><span data-stu-id="5612a-604">3</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-605">右</span><span class="sxs-lookup"><span data-stu-id="5612a-605">Right</span></span></td>
                    <td><span data-ttu-id="5612a-606">1</span><span class="sxs-lookup"><span data-stu-id="5612a-606">1</span></span></td>
                    <td><span data-ttu-id="5612a-607">2</span><span class="sxs-lookup"><span data-stu-id="5612a-607">2</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-608">UpRight</span><span class="sxs-lookup"><span data-stu-id="5612a-608">UpRight</span></span></td>
                    <td><span data-ttu-id="5612a-609">2</span><span class="sxs-lookup"><span data-stu-id="5612a-609">2</span></span></td>
                    <td><span data-ttu-id="5612a-610">1</span><span class="sxs-lookup"><span data-stu-id="5612a-610">1</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-611">Up</span><span class="sxs-lookup"><span data-stu-id="5612a-611">Up</span></span></td>
                    <td><span data-ttu-id="5612a-612">3</span><span class="sxs-lookup"><span data-stu-id="5612a-612">3</span></span></td>
                    <td><span data-ttu-id="5612a-613">0</span><span class="sxs-lookup"><span data-stu-id="5612a-613">0</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-614">UpLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-614">UpLeft</span></span></td>
                    <td><span data-ttu-id="5612a-615">4</span><span class="sxs-lookup"><span data-stu-id="5612a-615">4</span></span></td>
                    <td><span data-ttu-id="5612a-616">7</span><span class="sxs-lookup"><span data-stu-id="5612a-616">7</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-617">Left</span><span class="sxs-lookup"><span data-stu-id="5612a-617">Left</span></span></td>
                    <td><span data-ttu-id="5612a-618">5</span><span class="sxs-lookup"><span data-stu-id="5612a-618">5</span></span></td>
                    <td><span data-ttu-id="5612a-619">6</span><span class="sxs-lookup"><span data-stu-id="5612a-619">6</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-620">DownLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-620">DownLeft</span></span></td>
                    <td><span data-ttu-id="5612a-621">6</span><span class="sxs-lookup"><span data-stu-id="5612a-621">6</span></span></td>
                    <td><span data-ttu-id="5612a-622">5</span><span class="sxs-lookup"><span data-stu-id="5612a-622">5</span></span></td>
                </tr>
                <tr>
                    <td><span data-ttu-id="5612a-623">Down</span><span class="sxs-lookup"><span data-stu-id="5612a-623">Down</span></span></td>
                    <td><span data-ttu-id="5612a-624">7</span><span class="sxs-lookup"><span data-stu-id="5612a-624">7</span></span></td>
                    <td><span data-ttu-id="5612a-625">4</span><span class="sxs-lookup"><span data-stu-id="5612a-625">4</span></span></td>
                </tr>
            </table>
    </tr>
</table>

#### <a name="buttonindex-values"></a><span data-ttu-id="5612a-626">\*ButtonIndex の値</span><span class="sxs-lookup"><span data-stu-id="5612a-626">\*ButtonIndex values</span></span>

<span data-ttu-id="5612a-627">\*ButtonIndex 値にインデックスを付ける、 **RawGameController**のボタン配列。</span><span class="sxs-lookup"><span data-stu-id="5612a-627">\*ButtonIndex values index into the **RawGameController**'s button array:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-628">ButtonCount</span><span class="sxs-lookup"><span data-stu-id="5612a-628">ButtonCount</span></span></th>
        <th><span data-ttu-id="5612a-629">SwitchKind</span><span class="sxs-lookup"><span data-stu-id="5612a-629">SwitchKind</span></span></th>
        <th><span data-ttu-id="5612a-630">RequiredMappings</span><span class="sxs-lookup"><span data-stu-id="5612a-630">RequiredMappings</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-631">2</span><span class="sxs-lookup"><span data-stu-id="5612a-631">2</span></span></td>
        <td><span data-ttu-id="5612a-632">TwoWay</span><span class="sxs-lookup"><span data-stu-id="5612a-632">TwoWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="5612a-633">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-633">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-634">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-634">DownButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-635">4</span><span class="sxs-lookup"><span data-stu-id="5612a-635">4</span></span></td>
        <td><span data-ttu-id="5612a-636">FourWay</span><span class="sxs-lookup"><span data-stu-id="5612a-636">FourWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="5612a-637">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-637">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-638">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-638">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-639">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-639">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-640">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-640">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-641">4</span><span class="sxs-lookup"><span data-stu-id="5612a-641">4</span></span></td>
        <td><span data-ttu-id="5612a-642">EightWay</span><span class="sxs-lookup"><span data-stu-id="5612a-642">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="5612a-643">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-643">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-644">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-644">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-645">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-645">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-646">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-646">RightButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-647">8</span><span class="sxs-lookup"><span data-stu-id="5612a-647">8</span></span></td>
        <td><span data-ttu-id="5612a-648">EightWay</span><span class="sxs-lookup"><span data-stu-id="5612a-648">EightWay</span></span></td>
        <td>
            <ul>
                <li><span data-ttu-id="5612a-649">UpButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-649">UpButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-650">DownButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-650">DownButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-651">LeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-651">LeftButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-652">RightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-652">RightButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-653">UpRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-653">UpRightButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-654">DownRightButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-654">DownRightButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-655">DownLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-655">DownLeftButtonIndex</span></span></li>
                <li><span data-ttu-id="5612a-656">UpLeftButtonIndex</span><span class="sxs-lookup"><span data-stu-id="5612a-656">UpLeftButtonIndex</span></span></li>
            </ul>
        </td>
    </tr>
</table>

### <a name="properties-mapping"></a><span data-ttu-id="5612a-657">プロパティ マッピング</span><span class="sxs-lookup"><span data-stu-id="5612a-657">Properties mapping</span></span>

<span data-ttu-id="5612a-658">これらは、別のマッピングの種類の、静的マッピング値です。</span><span class="sxs-lookup"><span data-stu-id="5612a-658">These are static mapping values for different mapping types.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-659">マッピング</span><span class="sxs-lookup"><span data-stu-id="5612a-659">Mapping</span></span></th>
        <th><span data-ttu-id="5612a-660">値の名前</span><span class="sxs-lookup"><span data-stu-id="5612a-660">Value name</span></span></th>
        <th><span data-ttu-id="5612a-661">値の種類</span><span class="sxs-lookup"><span data-stu-id="5612a-661">Value type</span></span></th>
        <th><span data-ttu-id="5612a-662">値の情報</span><span class="sxs-lookup"><span data-stu-id="5612a-662">Value info</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-663">RacingWheel</span><span class="sxs-lookup"><span data-stu-id="5612a-663">RacingWheel</span></span></td>
        <td><span data-ttu-id="5612a-664">MaxWheelAngle</span><span class="sxs-lookup"><span data-stu-id="5612a-664">MaxWheelAngle</span></span></td>
        <td><span data-ttu-id="5612a-665">DWORD</span><span class="sxs-lookup"><span data-stu-id="5612a-665">DWORD</span></span></td>
        <td><span data-ttu-id="5612a-666">ホイールでサポートされている、単一方向の物理ホイールの最大角度を示します。</span><span class="sxs-lookup"><span data-stu-id="5612a-666">Indicates the maximum physical wheel angle supported by the wheel in a single direction.</span></span> <span data-ttu-id="5612a-667">たとえば、-90 度から 90 度まで回転できるホイールでは、90 を指定します。</span><span class="sxs-lookup"><span data-stu-id="5612a-667">For example, a wheel with a possible rotation of -90 degrees to 90 degrees would specify 90.</span></span></td>
    </tr>
</table>

## <a name="labels"></a><span data-ttu-id="5612a-668">ラベル</span><span class="sxs-lookup"><span data-stu-id="5612a-668">Labels</span></span>

<span data-ttu-id="5612a-669">ラベルは、デバイス ルートの下の **Labels** キーの下に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5612a-669">Labels should be present under the **Labels** key under the device root.</span></span> <span data-ttu-id="5612a-670">**ラベル**3 つのサブキーを持つことができます。**ボタン**、**軸**、および**スイッチ**します。</span><span class="sxs-lookup"><span data-stu-id="5612a-670">**Labels** can have 3 subkeys: **Buttons**, **Axes**, and **Switches**.</span></span>

### <a name="button-labels"></a><span data-ttu-id="5612a-671">ボタンのラベル</span><span class="sxs-lookup"><span data-stu-id="5612a-671">Button labels</span></span>

<span data-ttu-id="5612a-672">**Buttons** キーは、**RawGameController** のボタンの配列の各ボタンの位置を文字列にマッピングします。</span><span class="sxs-lookup"><span data-stu-id="5612a-672">The **Buttons** key maps each of the button positions in the **RawGameController**'s buttons array to a string.</span></span> <span data-ttu-id="5612a-673">各文字列は、対応する [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) 列挙値に内部的にマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="5612a-673">Each string is mapped internally to the corresponding [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) enum value.</span></span> <span data-ttu-id="5612a-674">たとえば、ゲームパッドに 10 個のボタンと、**RawGameController** がボタンを解析してボタンを表示する順序がある場合、レポートは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5612a-674">For example, if a gamepad has ten buttons and the order in which the **RawGameController** parses out the buttons and presents them in the buttons report is like this:</span></span>

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

<span data-ttu-id="5612a-675">ラベルは **Buttons** キーの下にこの順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="5612a-675">The labels should appear in this order under the **Buttons** key:</span></span>

<table>
    <tr>
        <th><span data-ttu-id="5612a-676">名前</span><span class="sxs-lookup"><span data-stu-id="5612a-676">Name</span></span></th>
        <th><span data-ttu-id="5612a-677">値 (型。REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="5612a-677">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-678">Button0</span><span class="sxs-lookup"><span data-stu-id="5612a-678">Button0</span></span></td>
        <td><span data-ttu-id="5612a-679">Menu</span><span class="sxs-lookup"><span data-stu-id="5612a-679">Menu</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-680">Button1</span><span class="sxs-lookup"><span data-stu-id="5612a-680">Button1</span></span></td>
        <td><span data-ttu-id="5612a-681">ビュー</span><span class="sxs-lookup"><span data-stu-id="5612a-681">View</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-682">Button2</span><span class="sxs-lookup"><span data-stu-id="5612a-682">Button2</span></span></td>
        <td><span data-ttu-id="5612a-683">LeftStickButton</span><span class="sxs-lookup"><span data-stu-id="5612a-683">LeftStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-684">Button3</span><span class="sxs-lookup"><span data-stu-id="5612a-684">Button3</span></span></td>
        <td><span data-ttu-id="5612a-685">RightStickButton</span><span class="sxs-lookup"><span data-stu-id="5612a-685">RightStickButton</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-686">Button4</span><span class="sxs-lookup"><span data-stu-id="5612a-686">Button4</span></span></td>
        <td><span data-ttu-id="5612a-687">LetterA</span><span class="sxs-lookup"><span data-stu-id="5612a-687">LetterA</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-688">Button5</span><span class="sxs-lookup"><span data-stu-id="5612a-688">Button5</span></span></td>
        <td><span data-ttu-id="5612a-689">LetterB</span><span class="sxs-lookup"><span data-stu-id="5612a-689">LetterB</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-690">Button6</span><span class="sxs-lookup"><span data-stu-id="5612a-690">Button6</span></span></td>
        <td><span data-ttu-id="5612a-691">LetterX</span><span class="sxs-lookup"><span data-stu-id="5612a-691">LetterX</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-692">Button7</span><span class="sxs-lookup"><span data-stu-id="5612a-692">Button7</span></span></td>
        <td><span data-ttu-id="5612a-693">LetterY</span><span class="sxs-lookup"><span data-stu-id="5612a-693">LetterY</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-694">Button8</span><span class="sxs-lookup"><span data-stu-id="5612a-694">Button8</span></span></td>
        <td><span data-ttu-id="5612a-695">LeftBumper</span><span class="sxs-lookup"><span data-stu-id="5612a-695">LeftBumper</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-696">Button9</span><span class="sxs-lookup"><span data-stu-id="5612a-696">Button9</span></span></td>
        <td><span data-ttu-id="5612a-697">RightBumper</span><span class="sxs-lookup"><span data-stu-id="5612a-697">RightBumper</span></span></td>
    </tr>
</table>

### <a name="axis-labels"></a><span data-ttu-id="5612a-698">軸ラベル</span><span class="sxs-lookup"><span data-stu-id="5612a-698">Axis labels</span></span>

<span data-ttu-id="5612a-699">**Axes** キーは、**RawGameController** の軸の配列の各軸の位置を、ボタンのラベルのように、[GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) に一覧表示されたラベルの 1 つにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="5612a-699">The **Axes** key will map each of the axis positions in the **RawGameController**'s axis array to one of the labels listed in [GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) just like the button labels.</span></span> <span data-ttu-id="5612a-700">「[ボタンのラベル](#button-labels)」の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5612a-700">See the example in [Button labels](#button-labels).</span></span>

### <a name="switch-labels"></a><span data-ttu-id="5612a-701">スイッチのラベル</span><span class="sxs-lookup"><span data-stu-id="5612a-701">Switch labels</span></span>

<span data-ttu-id="5612a-702">**Switches** キーはスイッチの位置をラベルにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="5612a-702">The **Switches** key maps switch positions to labels.</span></span> <span data-ttu-id="5612a-703">値は次の名前付け規則に従います: インデックスが **RawGameController** のスイッチの配列の *x*であるスイッチの位置にラベルを付けるには、次の値を **Switches** サブキーの下に追加します。</span><span class="sxs-lookup"><span data-stu-id="5612a-703">The values follow this naming convention: to label a position of a switch, whose index is *x* in the **RawGameController**'s switch array, add these values under the **Switches** subkey:</span></span> 

* <span data-ttu-id="5612a-704">SwitchxUp</span><span class="sxs-lookup"><span data-stu-id="5612a-704">SwitchxUp</span></span> 
* <span data-ttu-id="5612a-705">SwitchxUpRight</span><span class="sxs-lookup"><span data-stu-id="5612a-705">SwitchxUpRight</span></span> 
* <span data-ttu-id="5612a-706">SwitchxRight</span><span class="sxs-lookup"><span data-stu-id="5612a-706">SwitchxRight</span></span>
* <span data-ttu-id="5612a-707">SwitchxDownRight</span><span class="sxs-lookup"><span data-stu-id="5612a-707">SwitchxDownRight</span></span>
* <span data-ttu-id="5612a-708">SwitchxDown</span><span class="sxs-lookup"><span data-stu-id="5612a-708">SwitchxDown</span></span>
* <span data-ttu-id="5612a-709">SwitchxDownLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-709">SwitchxDownLeft</span></span>
* <span data-ttu-id="5612a-710">SwitchxUpLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-710">SwitchxUpLeft</span></span>
* <span data-ttu-id="5612a-711">SwitchxLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-711">SwitchxLeft</span></span>

<span data-ttu-id="5612a-712">次の表は、4 方向スイッチの位置が **RawGameController** でインデックス 0 を示しているスイッチにラベルを付ける例を示しています。</span><span class="sxs-lookup"><span data-stu-id="5612a-712">The following table shows an example set of labels for switch positions of a 4-way switch which shows up at index 0 in the **RawGameController**:</span></span> 

<table>
    <tr>
        <th><span data-ttu-id="5612a-713">名前</span><span class="sxs-lookup"><span data-stu-id="5612a-713">Name</span></span></th>
        <th><span data-ttu-id="5612a-714">値 (型。REG_SZ)</span><span class="sxs-lookup"><span data-stu-id="5612a-714">Value (type: REG_SZ)</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-715">Switch0Up</span><span class="sxs-lookup"><span data-stu-id="5612a-715">Switch0Up</span></span></td>
        <td><span data-ttu-id="5612a-716">XboxUp</span><span class="sxs-lookup"><span data-stu-id="5612a-716">XboxUp</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-717">Switch0Right</span><span class="sxs-lookup"><span data-stu-id="5612a-717">Switch0Right</span></span></td>
        <td><span data-ttu-id="5612a-718">XboxRight</span><span class="sxs-lookup"><span data-stu-id="5612a-718">XboxRight</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-719">Switch0Down</span><span class="sxs-lookup"><span data-stu-id="5612a-719">Switch0Down</span></span></td>
        <td><span data-ttu-id="5612a-720">XboxDown</span><span class="sxs-lookup"><span data-stu-id="5612a-720">XboxDown</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="5612a-721">Switch0Left</span><span class="sxs-lookup"><span data-stu-id="5612a-721">Switch0Left</span></span></td>
        <td><span data-ttu-id="5612a-722">XboxLeft</span><span class="sxs-lookup"><span data-stu-id="5612a-722">XboxLeft</span></span></td>
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

## <a name="example-registry-file"></a><span data-ttu-id="5612a-723">レジストリ ファイルの例</span><span class="sxs-lookup"><span data-stu-id="5612a-723">Example registry file</span></span>

<span data-ttu-id="5612a-724">これらのマッピングと値のすべての例を示すため、汎用の **RacingWheel** のレジストリ ファイルを示す次の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5612a-724">To show how all of these mappings and values come together, here is an example registry file for a generic **RacingWheel**:</span></span>

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

## <a name="see-also"></a><span data-ttu-id="5612a-725">関連項目</span><span class="sxs-lookup"><span data-stu-id="5612a-725">See also</span></span>

* [<span data-ttu-id="5612a-726">Windows.Gaming.Input Namespace</span><span class="sxs-lookup"><span data-stu-id="5612a-726">Windows.Gaming.Input Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [<span data-ttu-id="5612a-727">Windows.Gaming.Input.Custom Namespace</span><span class="sxs-lookup"><span data-stu-id="5612a-727">Windows.Gaming.Input.Custom Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)
* [<span data-ttu-id="5612a-728">INF ファイル</span><span class="sxs-lookup"><span data-stu-id="5612a-728">INF Files</span></span>](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)