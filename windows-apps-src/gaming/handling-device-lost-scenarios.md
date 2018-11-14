---
author: mtoepke
title: Direct3D 11 でのデバイス削除シナリオの処理
description: このトピックでは、グラフィックス アダプターが削除または再初期化されたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成する方法について説明します。
ms.assetid: 8f905acd-08f3-ff6f-85a5-aaa99acb389a
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 11, デバイス喪失
ms.localizationpriority: medium
ms.openlocfilehash: 888b3ec7ab667a8a92ae638a9d5c456c3180df0d
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6272328"
---
# <a name="span-iddevgaminghandlingdevice-lostscenariosspanhandle-device-removed-scenarios-in-direct3d-11"></a><span data-ttu-id="42d5e-104"><span id="dev_gaming.handling_device-lost_scenarios"></span>Direct3D 11 でのデバイス削除シナリオの処理</span><span class="sxs-lookup"><span data-stu-id="42d5e-104"><span id="dev_gaming.handling_device-lost_scenarios"></span>Handle device removed scenarios in Direct3D 11</span></span>



<span data-ttu-id="42d5e-105">このトピックでは、グラフィックス アダプターが削除または再初期化されたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-105">This topic explains how to recreate the Direct3D and DXGI device interface chain when the graphics adapter is removed or reinitialized.</span></span>

<span data-ttu-id="42d5e-106">DirectX 9 では、D3D デバイスが非動作状態になったときに、アプリケーションが "[デバイス喪失](https://msdn.microsoft.com/library/windows/desktop/bb174714)" 状態に見舞われることがあります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-106">In DirectX 9, applications could encounter a "[device lost](https://msdn.microsoft.com/library/windows/desktop/bb174714)" condition where the D3D device enters a non-operational state.</span></span> <span data-ttu-id="42d5e-107">たとえば、全画面 Direct3D 9 アプリケーションがフォーカスを失うと、Direct3D デバイスは "喪失" 状態になります。喪失したデバイスを使って描画しようとしても、エラー表示なしで失敗します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-107">For example, when a full-screen Direct3D 9 application loses focus, the Direct3D device becomes "lost;" any attempts to draw with a lost device will silently fail.</span></span> <span data-ttu-id="42d5e-108">Direct3D 11 では、仮想グラフィックス デバイス インターフェイスを使って、複数のプログラムが同一の物理グラフィックス デバイスを共有することができるため、アプリが Direct3D デバイスをコントロールできなくなることはなくなっています。</span><span class="sxs-lookup"><span data-stu-id="42d5e-108">Direct3D 11 uses virtual graphics device interfaces, enabling multiple programs to share the same physical graphics device and eliminating conditions where apps lose control of the Direct3D device.</span></span> <span data-ttu-id="42d5e-109">ただし、それでもグラフィックス アダプターが使用できなくなったり、逆に使用できるようになったりすることはありえます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-109">However, it is still possible for graphics adapter availability to change.</span></span> <span data-ttu-id="42d5e-110">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-110">For example:</span></span>

-   <span data-ttu-id="42d5e-111">グラフィックス ドライバーがアップグレードされた場合。</span><span class="sxs-lookup"><span data-stu-id="42d5e-111">The graphics driver is upgraded.</span></span>
-   <span data-ttu-id="42d5e-112">システムのグラフィックス アダプターが省電力モードから性能重視モードに変わった場合。</span><span class="sxs-lookup"><span data-stu-id="42d5e-112">The system changes from a power-saving graphics adapter to a performance graphics adapter.</span></span>
-   <span data-ttu-id="42d5e-113">グラフィックス デバイスが応答を停止してリセットされた場合。</span><span class="sxs-lookup"><span data-stu-id="42d5e-113">The graphics device stops responding and is reset.</span></span>
-   <span data-ttu-id="42d5e-114">グラフィックス アダプターが物理的に接続された場合、または取り外された場合。</span><span class="sxs-lookup"><span data-stu-id="42d5e-114">A graphics adapter is physically attached or removed.</span></span>

<span data-ttu-id="42d5e-115">このような状況になると、DXGI はエラー コードを返して、Direct3D デバイスの再起動とデバイス リソースの再作成が必要であることを知らせます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-115">When such circumstances arise, DXGI returns an error code indicating that the Direct3D device must be reinitialized and device resources must be recreated.</span></span> <span data-ttu-id="42d5e-116">このチュートリアルでは、グラフィックス アダプターのリセット、削除、変更という事態が生じた場合に、Direct3D 11 アプリとゲームがそれを検出して対応できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-116">This walkthrough explains how Direct3D 11 apps and games can detect and respond to any circumstance where the graphics adapter is reset, removed, or changed.</span></span> <span data-ttu-id="42d5e-117">コード例は、Microsoft Visual Studio2015 付属の DirectX 11 アプリ (ユニバーサル Windows) テンプレートから採用されます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-117">Code examples are provided from the DirectX 11 App (Universal Windows) template provided with Microsoft Visual Studio2015.</span></span>

## <a name="instructions"></a><span data-ttu-id="42d5e-118">手順</span><span class="sxs-lookup"><span data-stu-id="42d5e-118">Instructions</span></span>

### <a name="spanspanstep-1"></a><span data-ttu-id="42d5e-119"><span></span>手順 1: </span><span class="sxs-lookup"><span data-stu-id="42d5e-119"><span></span>Step 1:</span></span>

<span data-ttu-id="42d5e-120">レンダリング ループにデバイス削除エラーのチェックを加えます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-120">Include a check for the device removed error in the rendering loop.</span></span> <span data-ttu-id="42d5e-121">[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) (または [**Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) など) を呼び出して、フレームを表示します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-121">Present the frame by calling [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) (or [**Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797), and so on).</span></span> <span data-ttu-id="42d5e-122">次に、[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) または **DXGI\_ERROR\_DEVICE\_RESET** が返されたかどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="42d5e-122">Then, check whether it returned [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) or **DXGI\_ERROR\_DEVICE\_RESET**.</span></span>

<span data-ttu-id="42d5e-123">まず、テンプレートは DXGI スワップ チェーンから返された HRESULT を保存します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-123">First, the template stores the HRESULT returned by the DXGI swap chain:</span></span>

```cpp
HRESULT hr = m_swapChain->Present(1, 0);
```

<span data-ttu-id="42d5e-124">その他のフレーム表示作業の面倒をすべてみた後、テンプレートはデバイス削除エラーをチェックします。</span><span class="sxs-lookup"><span data-stu-id="42d5e-124">After taking care of all other work for presenting the frame, the template checks for the device removed error.</span></span> <span data-ttu-id="42d5e-125">必要な場合は、デバイス削除状態を処理するメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-125">If necessary, it calls a method to handle the device removed condition:</span></span>

```cpp
// If the device was removed either by a disconnection or a driver upgrade, we
// must recreate all device resources.
if (hr == DXGI_ERROR_DEVICE_REMOVED || hr == DXGI_ERROR_DEVICE_RESET)
{
    HandleDeviceLost();
}
else
{
    DX::ThrowIfFailed(hr);
}
```

### <a name="step-2"></a><span data-ttu-id="42d5e-126">手順 2:</span><span class="sxs-lookup"><span data-stu-id="42d5e-126">Step 2:</span></span>

<span data-ttu-id="42d5e-127">また、ウィンドウ サイズの変更に対応する箇所にも、デバイス削除エラーのチェックを加えます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-127">Also, include a check for the device removed error when responding to window size changes.</span></span> <span data-ttu-id="42d5e-128">これは、いくつかの理由から [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) または **DXGI\_ERROR\_DEVICE\_RESET** のチェックに適した場所です。</span><span class="sxs-lookup"><span data-stu-id="42d5e-128">This is a good place to check for [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) or **DXGI\_ERROR\_DEVICE\_RESET** for several reasons:</span></span>

-   <span data-ttu-id="42d5e-129">スワップ チェーンのサイズを変更するには、土台となる DXGI アダプターを呼び出す必要があり、その際にデバイス削除エラーが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-129">Resizing the swap chain requires a call to the underlying DXGI adapter, which can return the device removed error.</span></span>
-   <span data-ttu-id="42d5e-130">異なるグラフィックス デバイスに接続されたモニターにアプリが移動された可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-130">The app might have moved to a monitor that's attached to a different graphics device.</span></span>
-   <span data-ttu-id="42d5e-131">グラフィックス デバイスが削除またはリセットされると、多くの場合、デスクトップの解像度が変わり、その結果ウィンドウ サイズが変わります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-131">When a graphics device is removed or reset, the desktop resolution often changes, resulting in a window size change.</span></span>

<span data-ttu-id="42d5e-132">テンプレートは、[**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) から返された HRESULT を確認します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-132">The template checks the HRESULT returned by [**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577):</span></span>

```cpp
// If the swap chain already exists, resize it.
HRESULT hr = m_swapChain->ResizeBuffers(
    2, // Double-buffered swap chain.
    static_cast<UINT>(m_d3dRenderTargetSize.Width),
    static_cast<UINT>(m_d3dRenderTargetSize.Height),
    DXGI_FORMAT_B8G8R8A8_UNORM,
    0
    );

if (hr == DXGI_ERROR_DEVICE_REMOVED || hr == DXGI_ERROR_DEVICE_RESET)
{
    // If the device was removed for any reason, a new device and swap chain will need to be created.
    HandleDeviceLost();

    // Everything is set up now. Do not continue execution of this method. HandleDeviceLost will reenter this method 
    // and correctly set up the new device.
    return;
}
else
{
    DX::ThrowIfFailed(hr);
}
```

### <a name="step-3"></a><span data-ttu-id="42d5e-133">手順 3:</span><span class="sxs-lookup"><span data-stu-id="42d5e-133">Step 3:</span></span>

<span data-ttu-id="42d5e-134">[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) エラーを受け取ったアプリは、常に Direct3D デバイスを再作成し、デバイス依存リソースを再初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-134">Any time your app receives the [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) error, it must reinitialize the Direct3D device and recreate any device-dependent resources.</span></span> <span data-ttu-id="42d5e-135">以前の Direct3D デバイスを使って作成したグラフィックス デバイス リソースに対する参照はすべて解放します。このようなリソースは無効になっているため、スワップ チェーンに対する参照はすべて、新しいスワップ チェーンを作成する前に解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-135">Release any references to graphics device resources created with the previous Direct3D device; those resources are now invalid, and all references to the swap chain must be released before a new one can be created.</span></span>

<span data-ttu-id="42d5e-136">HandleDeviceLost メソッドは、スワップ チェーンを解放し、アプリ コンポーネントに対してデバイス リソースを解放するよう通知します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-136">The HandleDeviceLost method releases the swap chain and notifies app components to release device resources:</span></span>

```cpp
m_swapChain = nullptr;

if (m_deviceNotify != nullptr)
{
    // Notify the renderers that device resources need to be released.
    // This ensures all references to the existing swap chain are released so that a new one can be created.
    m_deviceNotify->OnDeviceLost();
}
```

<span data-ttu-id="42d5e-137">続いて、新しいスワップ チェーンを作成し、デバイス管理クラスによって制御されるデバイス依存リソースを再初期化します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-137">Then, it creates a new swap chain and reinitializes the device-dependent resources controlled by the device management class:</span></span>

```cpp
// Create the new device and swap chain.
CreateDeviceResources();
m_d2dContext->SetDpi(m_dpi, m_dpi);
CreateWindowSizeDependentResources();
```

<span data-ttu-id="42d5e-138">デバイスとスワップ チェーンが再確立された後、アプリ コンポーネントに対してデバイス依存リソースを再初期化するよう通知します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-138">After the device and swap chain have been re-established, it notifies app components to reinitialize device-dependent resources:</span></span>

```cpp
// Create the new device and swap chain.
CreateDeviceResources();
m_d2dContext->SetDpi(m_dpi, m_dpi);
CreateWindowSizeDependentResources();

if (m_deviceNotify != nullptr)
{
    // Notify the renderers that resources can now be created again.
    m_deviceNotify->OnDeviceRestored();
}
```

<span data-ttu-id="42d5e-139">HandleDeviceLost メソッドが終了すると、制御はレンダリング ループに戻り、処理が続行されて次のフレームが描画されます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-139">When the HandleDeviceLost method exits, control returns to the rendering loop, which continues on to draw the next frame.</span></span>

## <a name="remarks"></a><span data-ttu-id="42d5e-140">注釈</span><span class="sxs-lookup"><span data-stu-id="42d5e-140">Remarks</span></span>


### <a name="investigating-the-cause-of-device-removed-errors"></a><span data-ttu-id="42d5e-141">デバイス削除エラーの原因の調査</span><span class="sxs-lookup"><span data-stu-id="42d5e-141">Investigating the cause of device removed errors</span></span>

<span data-ttu-id="42d5e-142">DXGI デバイス削除エラーが繰り返し発生する場合は、アプリケーションのグラフィックス コードが描画ルーチン内で無効な状態を作り出している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-142">Repeat issues with DXGI device removed errors can indicate that your graphics code is creating invalid conditions during a drawing routine.</span></span> <span data-ttu-id="42d5e-143">また、ハードウェア障害やグラフィックス ドライバーのバグが原因の可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-143">It can also indicate a hardware failure or a bug in the graphics driver.</span></span> <span data-ttu-id="42d5e-144">デバイス削除エラーの原因を調査するには、Direct3D デバイスを解放する前に [**ID3D11Device::GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-144">To investigate the cause of device removed errors, call [**ID3D11Device::GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526) before releasing the Direct3D device.</span></span> <span data-ttu-id="42d5e-145">このメソッドは、デバイス削除エラーの理由を示す 6 種類の DXGI エラー コードの 1 つを返します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-145">This method returns one of six possible DXGI error codes indicating the reason for the device removed error:</span></span>

-   <span data-ttu-id="42d5e-146">**DXGI\_ERROR\_DEVICE\_HUNG**: アプリが送信したグラフィックス コマンドの組み合わせが無効であったため、グラフィックス ドライバーが応答を停止しました。</span><span class="sxs-lookup"><span data-stu-id="42d5e-146">**DXGI\_ERROR\_DEVICE\_HUNG**: The graphics driver stopped responding because of an invalid combination of graphics commands sent by the app.</span></span> <span data-ttu-id="42d5e-147">このエラーが繰り返し発生する場合は、デバイスがハングする原因はアプリにあり、デバッグの必要があることを示している可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-147">If you get this error repeatedly, it is a likely indication that your app caused the device to hang and needs to be debugged.</span></span>
-   <span data-ttu-id="42d5e-148">**DXGI\_ERROR\_DEVICE\_REMOVED**: グラフィックス デバイスが物理的に取り外されたか、電源が切られたか、ドライバーのアップグレードが発生しました。</span><span class="sxs-lookup"><span data-stu-id="42d5e-148">**DXGI\_ERROR\_DEVICE\_REMOVED**: The graphics device has been physically removed, turned off, or a driver upgrade has occurred.</span></span> <span data-ttu-id="42d5e-149">このエラーはときどき起こることであり、異常ではありません。アプリまたはゲームは、このトピックで説明しているようにデバイス リソースを再作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-149">This happens occasionally and is normal; your app or game should recreate device resources as described in this topic.</span></span>
-   <span data-ttu-id="42d5e-150">**DXGI\_ERROR\_DEVICE\_RESET**: コマンドの形式が無効であるためにグラフィックス デバイスが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="42d5e-150">**DXGI\_ERROR\_DEVICE\_RESET**: The graphics device failed because of a badly formed command.</span></span> <span data-ttu-id="42d5e-151">このエラーが繰り返し発生する場合は、コードが無効な描画コマンドを送っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-151">If you get this error repeatedly, it may mean that your code is sending invalid drawing commands.</span></span>
-   <span data-ttu-id="42d5e-152">**DXGI\_ERROR\_DRIVER\_INTERNAL\_ERROR**: グラフィックス ドライバーでエラーが発生して、デバイスをリセットしました。</span><span class="sxs-lookup"><span data-stu-id="42d5e-152">**DXGI\_ERROR\_DRIVER\_INTERNAL\_ERROR**: The graphics driver encountered an error and reset the device.</span></span>
-   <span data-ttu-id="42d5e-153">**DXGI\_ERROR\_INVALID\_CALL**: アプリケーションが無効なパラメーター データを指定しました。</span><span class="sxs-lookup"><span data-stu-id="42d5e-153">**DXGI\_ERROR\_INVALID\_CALL**: The application provided invalid parameter data.</span></span> <span data-ttu-id="42d5e-154">このエラーが 1 回でも発生する場合は、デバイス削除状態の原因がアプリのコードにあり、デバッグの必要があることを意味しています。</span><span class="sxs-lookup"><span data-stu-id="42d5e-154">If you get this error even once, it means that your code caused the device removed condition and must be debugged.</span></span>
-   <span data-ttu-id="42d5e-155">**S\_OK**: 現在のグラフィックス デバイスを無効にすることなく、グラフィックス デバイスの使用が許可または禁止されたり、リセットされたりしたときに返されます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-155">**S\_OK**: Returned when a graphics device was enabled, disabled, or reset without invalidating the current graphics device.</span></span> <span data-ttu-id="42d5e-156">たとえば、このエラー コードは、アプリが [Windows Advanced Rasterization Platform (WARP)](https://msdn.microsoft.com/library/windows/desktop/gg615082) を使っていて、ハードウェア アダプターが利用可能になった場合に返されます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-156">For example, this error code can be returned if an app is using [Windows Advanced Rasterization Platform (WARP)](https://msdn.microsoft.com/library/windows/desktop/gg615082) and a hardware adapter becomes available.</span></span>

<span data-ttu-id="42d5e-157">次のコードは、[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) エラー コードを取得して、それをデバッグ コンソールに出力します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-157">The following code will retrieve the [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) error code and print it to the debug console.</span></span> <span data-ttu-id="42d5e-158">次のコードを HandleDeviceLost メソッドの先頭に挿入します。</span><span class="sxs-lookup"><span data-stu-id="42d5e-158">Insert this code at the beginning of the HandleDeviceLost method:</span></span>

```cpp
    HRESULT reason = m_d3dDevice->GetDeviceRemovedReason();

#if defined(_DEBUG)
    wchar_t outString[100];
    size_t size = 100;
    swprintf_s(outString, size, L"Device removed! DXGI_ERROR code: 0x%X\n", reason);
    OutputDebugStringW(outString);
#endif
```

<span data-ttu-id="42d5e-159">詳しくは、「[**GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526)」および「[**DXGI\_ERROR**](https://msdn.microsoft.com/library/windows/desktop/bb509553)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="42d5e-159">For more details, see [**GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526) and [**DXGI\_ERROR**](https://msdn.microsoft.com/library/windows/desktop/bb509553).</span></span>

### <a name="testing-device-removed-handling"></a><span data-ttu-id="42d5e-160">デバイスの削除完了処理のテスト</span><span class="sxs-lookup"><span data-stu-id="42d5e-160">Testing Device Removed Handling</span></span>

<span data-ttu-id="42d5e-161">Visual Studio の開発者コマンド プロンプトでは、Visual Studio グラフィックス診断に関連する Direct3D イベントのキャプチャと再生を行うコマンド ライン ツール "dxcap" がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-161">Visual Studio's Developer Command Prompt supports a command line tool 'dxcap' for Direct3D event capture and playback related to the Visual Studio Graphics Diagnostics.</span></span> <span data-ttu-id="42d5e-162">アプリの実行中はコマンド ライン オプション "-forcetdr" を使って、GPU タイムアウトの検出と回復イベントを強制できるため、DXGI\_ERROR\_DEVICE\_REMOVED がトリガーされ、エラー処理コードをテストできます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-162">You can use the command line option "-forcetdr" while your app is running which will force a GPU Timeout Detection and Recovery event, thereby triggering DXGI\_ERROR\_DEVICE\_REMOVED and allowing you to test your error handling code.</span></span>

> <span data-ttu-id="42d5e-163">**注** DXCap とそのサポート DLL は、Windows 10 向けグラフィックス ツール (Windows SDK では配布されなくなりました) の一部として system32/syswow64 にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="42d5e-163">**Note** DXCap and its support DLLs are installed into system32/syswow64 as part of the Graphics Tools for Windows 10 which are no longer distributed via the Windows SDK.</span></span> <span data-ttu-id="42d5e-164">代わりに、オプションの OS コンポーネントであるオンデマンドのグラフィックス ツール機能を通じて提供され、Windows 10 でグラフィックス ツールを有効にして使うにはこれをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-164">Instead they are provided via the Graphics Tools Feature on Demand that is an optional OS component and must be installed in order to enable and use the Graphics Tools on Windows 10.</span></span> <span data-ttu-id="42d5e-165">Windows 10 向けグラフィックス ツールをインストールする方法について詳しくはここにあります。</span><span class="sxs-lookup"><span data-stu-id="42d5e-165">More information on how to Install the Graphics Tools for Windows 10 can be found here:</span></span> <https://msdn.microsoft.com/library/mt125501.aspx#InstallGraphicsTools>
