---
author: mtoepke
title: スワップ チェーンのスケーリングとオーバーレイ
description: モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーン (使用できる場合) を使って画質を高める方法について説明します。
ms.assetid: 3e4d2d19-cac3-eebc-52dd-daa7a7bc30d1
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, スワップ チェーン スケーリング, オーバーレイ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 9d159a78412bea528c1a12428288daebe31d1fe1
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5705391"
---
# <a name="swap-chain-scaling-and-overlays"></a><span data-ttu-id="a8690-104">スワップ チェーンのスケーリングとオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="a8690-104">Swap chain scaling and overlays</span></span>



<span data-ttu-id="a8690-105">モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーン (使用できる場合) を使って画質を高める方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a8690-105">Learn how to create scaled swap chains for faster rendering on mobile devices, and use overlay swap chains (when available) to increase the visual quality.</span></span>

## <a name="swap-chains-in-directx-112"></a><span data-ttu-id="a8690-106">DirectX 11.2 でのスワップ チェーン</span><span class="sxs-lookup"><span data-stu-id="a8690-106">Swap chains in DirectX 11.2</span></span>


<span data-ttu-id="a8690-107">Direct3D 11.2 では、ネイティブでない (より低い) 解像度から拡大されたスワップ チェーンを使ったユニバーサル Windows プラットフォーム (UWP) アプリを作成でき、フィル レートを高速化できます。</span><span class="sxs-lookup"><span data-stu-id="a8690-107">Direct3D 11.2 allows you to create Universal Windows Platform (UWP) apps with swap chains that are scaled up from non-native (reduced) resolutions, enabling faster fill rates.</span></span> <span data-ttu-id="a8690-108">また、Direct3D 11.2 には、別のスワップ チェーンでネイティブの解像度で UI を表示できる、ハードウェア オーバーレイを使ったレンダリング用の API も含まれています。</span><span class="sxs-lookup"><span data-stu-id="a8690-108">Direct3D 11.2 also includes APIs for rendering with hardware overlays so that you can present a UI in another swap chain at native resolution.</span></span> <span data-ttu-id="a8690-109">これにより、ゲームで高いフレームレートを維持しながらネイティブのフル解像度で UI を描画できるため、モバイル デバイスと高 DPI ディスプレイ (3840 x 2160 など) の性能を最大限引き出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a8690-109">This allows your game to draw UI at full native resolution while maintaining a high framerate, thereby making the best use of mobile devices and high DPI displays (such as 3840 by 2160).</span></span> <span data-ttu-id="a8690-110">この記事では、オーバーラップ スワップ チェーンを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a8690-110">This article explains how to use overlapping swap chains.</span></span>

<span data-ttu-id="a8690-111">Direct3D 11.2 には、フリップ モデルのスワップ チェーンで待機時間を短縮するための新しい機能も含まれています。</span><span class="sxs-lookup"><span data-stu-id="a8690-111">Direct3D 11.2 also introduces a new feature for reduced latency with flip model swap chains.</span></span> <span data-ttu-id="a8690-112">「[DXGI 1.3 スワップ チェーンによる遅延の減少](reduce-latency-with-dxgi-1-3-swap-chains.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a8690-112">See [Reduce latency with DXGI 1.3 swap chains](reduce-latency-with-dxgi-1-3-swap-chains.md).</span></span>

## <a name="use-swap-chain-scaling"></a><span data-ttu-id="a8690-113">スワップ チェーンのスケーリングの使用</span><span class="sxs-lookup"><span data-stu-id="a8690-113">Use swap chain scaling</span></span>


<span data-ttu-id="a8690-114">下位のハードウェアまたは電力消費を抑えるために最適化されたハードウェアでゲームを実行するときに、ディスプレイのネイティブの機能よりも低い解像度を使って、リアルタイムのゲーム コンテンツをレンダリングする方法が有効である場合があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-114">When your game is running on downlevel hardware - or hardware optimized for power savings - it can be beneficial to render real-time game content at a lower resolution than the display is natively capable of.</span></span> <span data-ttu-id="a8690-115">そのためには、ゲーム コンテンツをレンダリングするために使うスワップ チェーンをネイティブの解像度よりも小さくするか、スワップ チェーンのサブ領域を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-115">To do this, the swap chain that is used for rendering game content must be smaller than the native resolution, or a subregion of the swapchain must be used.</span></span>

1.  <span data-ttu-id="a8690-116">最初に、ネイティブのフル解像度でスワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a8690-116">First, create a swap chain at full native resolution.</span></span>

    ```cpp
    DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};

    swapChainDesc.Width = static_cast<UINT>(m_d3dRenderTargetSize.Width); // Match the size of the window.
    swapChainDesc.Height = static_cast<UINT>(m_d3dRenderTargetSize.Height);
    swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM; // This is the most common swap chain format.
    swapChainDesc.Stereo = false;
    swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
    swapChainDesc.SampleDesc.Quality = 0;
    swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    swapChainDesc.BufferCount = 2; // Use double-buffering to minimize latency.
    swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // All UWP apps must use this SwapEffect.
    swapChainDesc.Flags = 0;
    swapChainDesc.Scaling = DXGI_SCALING_STRETCH;

    // This sequence obtains the DXGI factory that was used to create the Direct3D device above.
    ComPtr<IDXGIDevice3> dxgiDevice;
    DX::ThrowIfFailed(
        m_d3dDevice.As(&dxgiDevice)
        );

    ComPtr<IDXGIAdapter> dxgiAdapter;
    DX::ThrowIfFailed(
        dxgiDevice->GetAdapter(&dxgiAdapter)
        );

    ComPtr<IDXGIFactory2> dxgiFactory;
    DX::ThrowIfFailed(
        dxgiAdapter->GetParent(IID_PPV_ARGS(&dxgiFactory))
        );

    ComPtr<IDXGISwapChain1> swapChain;
    DX::ThrowIfFailed(
        dxgiFactory->CreateSwapChainForCoreWindow(
            m_d3dDevice.Get(),
            reinterpret_cast<IUnknown*>(m_window.Get()),
            &swapChainDesc,
            nullptr,
            &swapChain
            )
        );

    DX::ThrowIfFailed(
        swapChain.As(&m_swapChain)
        );
    ```

2.  <span data-ttu-id="a8690-117">次に、ソース サイズを低い解像度に設定して拡大するスワップ チェーンのサブ領域を選びます。</span><span class="sxs-lookup"><span data-stu-id="a8690-117">Then, choose a subregion of the swap chain to scale up by setting the source size to a reduced resolution.</span></span>

    <span data-ttu-id="a8690-118">DX 前景スワップ チェーンのサンプルでは、小さくした解像度をパーセントで計算しています。</span><span class="sxs-lookup"><span data-stu-id="a8690-118">The DX Foreground Swap Chains sample calculates a reduced size based on a percentage:</span></span>

    ```cpp
    m_d3dRenderSizePercentage = percentage;

    UINT renderWidth = static_cast<UINT>(m_d3dRenderTargetSize.Width * percentage + 0.5f);
    UINT renderHeight = static_cast<UINT>(m_d3dRenderTargetSize.Height * percentage + 0.5f);

    // Change the region of the swap chain that will be presented to the screen.
    DX::ThrowIfFailed(
        m_swapChain->SetSourceSize(
            renderWidth,
            renderHeight
            )
        );
    ```

3.  <span data-ttu-id="a8690-119">スワップ チェーンのサブ領域に合わせてビューポートを作成します。</span><span class="sxs-lookup"><span data-stu-id="a8690-119">Create a viewport to match the subregion of the swap chain.</span></span>

    ```cpp
    // In Direct3D, change the Viewport to match the region of the swap
    // chain that will now be presented from.
    m_screenViewport = CD3D11_VIEWPORT(
        0.0f,
        0.0f,
        static_cast<float>(renderWidth),
        static_cast<float>(renderHeight)
        );

    m_d3dContext->RSSetViewports(1, &m_screenViewport);
    ```

4.  <span data-ttu-id="a8690-120">Direct2D が使われている場合は、ソース領域に合わせて回転の変換を調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-120">If Direct2D is being used, the rotation transform needs to be adjusted to compensate for the source region.</span></span>

## <a name="create-a-hardware-overlay-swap-chain-for-ui-elements"></a><span data-ttu-id="a8690-121">UI 要素のためのハードウェア オーバーレイ スワップ チェーンの作成</span><span class="sxs-lookup"><span data-stu-id="a8690-121">Create a hardware overlay swap chain for UI elements</span></span>


<span data-ttu-id="a8690-122">スワップ チェーンのスケーリングを使った場合、この手法に固有の短所として、UI も縮小され、ぼやけて使いづらくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-122">When using swap chain scaling, there is an inherent disadvantage in that the UI is also scaled down, potentially making it blurry and harder to use.</span></span> <span data-ttu-id="a8690-123">オーバーレイ スナップ チェーンがハードウェア サポートされているデバイスでは、この問題を解決するために、リアルタイムのゲーム コンテンツとは別のスワップ チェーンを使ってネイティブの解像度で UI をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="a8690-123">On devices with hardware support for overlay swap chains, this problem is alleviated entirely by rendering the UI at native resolution in a swap chain that's separate from the real-time game content.</span></span> <span data-ttu-id="a8690-124">この手法は [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) スワップ チェーンにのみ適用される点に注意してください。XAML との相互運用には使用できません。</span><span class="sxs-lookup"><span data-stu-id="a8690-124">Note that this technique applies only to [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) swap chains - it cannot be used with XAML interop.</span></span>

<span data-ttu-id="a8690-125">ハードウェア オーバーレイ機能を使う前景スワップ チェーンを作成するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="a8690-125">Use the following steps to create a foreground swap chain that uses hardware overlay capability.</span></span> <span data-ttu-id="a8690-126">この手順は、前に述べたように最初にリアルタイムのゲーム コンテンツ用のスワップ チェーンを作成した後で実行されます。</span><span class="sxs-lookup"><span data-stu-id="a8690-126">These steps are performed after first creating a swap chain for real-time game content as described above.</span></span>

1.  <span data-ttu-id="a8690-127">まず、DXGI アダプターでオーバーレイがサポートされているかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="a8690-127">First, determine whether the DXGI adapter supports overlays.</span></span> <span data-ttu-id="a8690-128">スワップ チェーンから DXGI 出力アダプターを取得します。</span><span class="sxs-lookup"><span data-stu-id="a8690-128">Get the DXGI output adapter from the swap chain:</span></span>

    ```cpp
    ComPtr<IDXGIAdapter> outputDxgiAdapter;
    DX::ThrowIfFailed(
        dxgiFactory->EnumAdapters(0, &outputDxgiAdapter)
        );

    ComPtr<IDXGIOutput> dxgiOutput;
    DX::ThrowIfFailed(
        outputDxgiAdapter->EnumOutputs(0, &dxgiOutput)
        );

    ComPtr<IDXGIOutput2> dxgiOutput2;
    DX::ThrowIfFailed(
        dxgiOutput.As(&dxgiOutput2)
        );
    ```

    <span data-ttu-id="a8690-129">DXGI アダプターでは、出力アダプターが [**SupportsOverlays**](https://msdn.microsoft.com/library/windows/desktop/dn280411) に対して True を返す場合はオーバーレイがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a8690-129">The DXGI adapter supports overlays if the output adapter returns True for [**SupportsOverlays**](https://msdn.microsoft.com/library/windows/desktop/dn280411).</span></span>

    ```cpp
    m_overlaySupportExists = dxgiOutput2->SupportsOverlays() ? true : false;
    ```
    
    > <span data-ttu-id="a8690-130">**注:**  、DXGI アダプターでは、オーバーレイをサポートする場合、次の手順に進みます。</span><span class="sxs-lookup"><span data-stu-id="a8690-130">**Note** If the DXGI adapter supports overlays, continue to the next step.</span></span> <span data-ttu-id="a8690-131">デバイスがオーバーレイをサポートしない場合は、複数のスワップ チェーンを使ったレンダリングは効率的ではありません。</span><span class="sxs-lookup"><span data-stu-id="a8690-131">If the device does not support overlays, rendering with multiple swap chains will not be efficient.</span></span> <span data-ttu-id="a8690-132">代わりに、リアルタイムのゲーム コンテンツと同じスワップ チェーンで解像度を下げて UI をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="a8690-132">Instead, render the UI at reduced resolution in the same swap chain as real-time game content.</span></span>

     

2.  <span data-ttu-id="a8690-133">[**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を使って前景スワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a8690-133">Create the foreground swap chain with [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559).</span></span> <span data-ttu-id="a8690-134">次のオプションを [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定し、*pDesc* パラメーターに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-134">The following options must be set in the [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) supplied to the *pDesc* parameter:</span></span>

    -   <span data-ttu-id="a8690-135">前景スワップ チェーンを示す [**DXGI\_SWAP\_CHAIN\_FLAG\_FOREGROUND\_LAYER**](https://msdn.microsoft.com/library/windows/desktop/bb173076) スワップ チェーン フラグを指定します。</span><span class="sxs-lookup"><span data-stu-id="a8690-135">Specify the [**DXGI\_SWAP\_CHAIN\_FLAG\_FOREGROUND\_LAYER**](https://msdn.microsoft.com/library/windows/desktop/bb173076) swap chain flag to indicate a foreground swap chain.</span></span>
    -   <span data-ttu-id="a8690-136">[**DXGI\_ALPHA\_MODE\_PREMULTIPLIED**](https://msdn.microsoft.com/library/windows/desktop/hh404496) アルファ モード フラグを使います。</span><span class="sxs-lookup"><span data-stu-id="a8690-136">Use the [**DXGI\_ALPHA\_MODE\_PREMULTIPLIED**](https://msdn.microsoft.com/library/windows/desktop/hh404496) alpha mode flag.</span></span> <span data-ttu-id="a8690-137">前景スワップ チェーンは常にプリマルチプライ済みです。</span><span class="sxs-lookup"><span data-stu-id="a8690-137">Foreground swap chains are always premultiplied.</span></span>
    -   <span data-ttu-id="a8690-138">[**DXGI\_SCALING\_NONE**](https://msdn.microsoft.com/library/windows/desktop/hh404526) フラグを設定します。</span><span class="sxs-lookup"><span data-stu-id="a8690-138">Set the [**DXGI\_SCALING\_NONE**](https://msdn.microsoft.com/library/windows/desktop/hh404526) flag.</span></span> <span data-ttu-id="a8690-139">前景スワップ チェーンは、常にネイティブの解像度で実行されます。</span><span class="sxs-lookup"><span data-stu-id="a8690-139">Foreground swap chains always run at native resolution.</span></span>

    ```cpp
     foregroundSwapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER;
     foregroundSwapChainDesc.Scaling = DXGI_SCALING_NONE;
     foregroundSwapChainDesc.AlphaMode = DXGI_ALPHA_MODE_PREMULTIPLIED; // Foreground swap chain alpha values must be premultiplied.
    ```

    > <span data-ttu-id="a8690-140">**注:** スワップ チェーンのサイズが変更されるたびに、 [**dxgi \_swap\_chain\_flag\_foreground\_layer**](https://msdn.microsoft.com/library/windows/desktop/bb173076)をもう一度設定します。</span><span class="sxs-lookup"><span data-stu-id="a8690-140">**Note** Set the [**DXGI\_SWAP\_CHAIN\_FLAG\_FOREGROUND\_LAYER**](https://msdn.microsoft.com/library/windows/desktop/bb173076) again every time the swap chain is resized.</span></span>

    ```cpp
    HRESULT hr = m_foregroundSwapChain->ResizeBuffers(
        2, // Double-buffered swap chain.
        static_cast<UINT>(m_d3dRenderTargetSize.Width),
        static_cast<UINT>(m_d3dRenderTargetSize.Height),
        DXGI_FORMAT_B8G8R8A8_UNORM,
        DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER // The FOREGROUND_LAYER flag cannot be removed with ResizeBuffers.
        );
    ```

3.  <span data-ttu-id="a8690-141">2 つのスワップ チェーンが使われている場合は、最大フレーム待機時間の値を増やして 2 に設定し、DXGI アダプターで両方のスワップ チェーンを同時に表示する時間を確保します (同じ VSync 間隔で)。</span><span class="sxs-lookup"><span data-stu-id="a8690-141">When two swap chains are being used, increase the maximum frame latency to 2 so that the DXGI adapter has time to present both swap chains simultaneously (within the same VSync interval).</span></span>

    ```cpp
    // Create a render target view of the foreground swap chain's back buffer.
    if (m_foregroundSwapChain)
    {
        ComPtr<ID3D11Texture2D> foregroundBackBuffer;
        DX::ThrowIfFailed(
            m_foregroundSwapChain->GetBuffer(0, IID_PPV_ARGS(&foregroundBackBuffer))
            );

        DX::ThrowIfFailed(
            m_d3dDevice->CreateRenderTargetView(
                foregroundBackBuffer.Get(),
                nullptr,
                &m_d3dForegroundRenderTargetView
                )
            );
    }
    ```

4.  <span data-ttu-id="a8690-142">前景スワップ チェーンでは、プリマルチプライ アルファ値が必ず使われます。</span><span class="sxs-lookup"><span data-stu-id="a8690-142">Foreground swap chains always use premultiplied alpha.</span></span> <span data-ttu-id="a8690-143">各ピクセルのカラー値は、フレームが表示される前にアルファ値が乗算されることが前提となります。</span><span class="sxs-lookup"><span data-stu-id="a8690-143">Each pixel's color values are expected to be already multiplied by the alpha value before the frame is presented.</span></span> <span data-ttu-id="a8690-144">たとえば、アルファ値 50% の場合、100% 白の BGRA ピクセルは (0.5, 0.5, 0.5, 0.5) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="a8690-144">For example, a 100% white BGRA pixel at 50% alpha is set to (0.5, 0.5, 0.5, 0.5).</span></span>

    <span data-ttu-id="a8690-145">アルファ値のプリマルチプライの手順は、アプリのブレンド状態を適用することにより、出力マージャー ステージで実行できます ([**ID3D11BlendState**](https://msdn.microsoft.com/library/windows/desktop/ff476349) をご覧ください)。それには、[**D3D11\_RENDER\_TARGET\_BLEND\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476200) 構造の **SrcBlend** フィールドを **D3D11\_SRC\_ALPHA** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a8690-145">The alpha premultiplication step can be done in the output-merger stage by applying an app blend state (see [**ID3D11BlendState**](https://msdn.microsoft.com/library/windows/desktop/ff476349)) with the [**D3D11\_RENDER\_TARGET\_BLEND\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476200) structure's **SrcBlend** field set to **D3D11\_SRC\_ALPHA**.</span></span> <span data-ttu-id="a8690-146">プリマルチプライ アルファ値を含むアセットを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="a8690-146">Assets with pre-multiplied alpha values can also be used.</span></span>

    <span data-ttu-id="a8690-147">アルファ値のプリマルチプライの手順が実行されていない場合、前景スワップ チェーンのカラーは想定よりも明るくなります。</span><span class="sxs-lookup"><span data-stu-id="a8690-147">If the alpha premultiplication step is not done, colors on the foreground swap chain will be brighter than expected.</span></span>

5.  <span data-ttu-id="a8690-148">前景スワップ チェーンが作成されたかどうかに応じて、UI 要素の Direct2D 描画サーフェスを前景スワップ チェーンに関連付けることが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="a8690-148">Depending on whether the foreground swap chain was created, the Direct2D drawing surface for UI elements might need be associated with the foreground swap chain.</span></span>

    <span data-ttu-id="a8690-149">レンダー ターゲット ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="a8690-149">Creating render target views:</span></span>

    ```cpp
    // Create a render target view of the foreground swap chain's back buffer.
    if (m_foregroundSwapChain)
    {
        ComPtr<ID3D11Texture2D> foregroundBackBuffer;
        DX::ThrowIfFailed(
            m_foregroundSwapChain->GetBuffer(0, IID_PPV_ARGS(&foregroundBackBuffer))
            );

        DX::ThrowIfFailed(
            m_d3dDevice->CreateRenderTargetView(
                foregroundBackBuffer.Get(),
                nullptr,
                &m_d3dForegroundRenderTargetView
                )
            );
    }
    ```

    <span data-ttu-id="a8690-150">Direct2D 描画サーフェスを作成します。</span><span class="sxs-lookup"><span data-stu-id="a8690-150">Creating the Direct2D drawing surface:</span></span>

    ```cpp
    if (m_foregroundSwapChain)
    {
        // Create a Direct2D target bitmap for the foreground swap chain.
        ComPtr<IDXGISurface2> dxgiForegroundSwapChainBackBuffer;
        DX::ThrowIfFailed(
            m_foregroundSwapChain->GetBuffer(0, IID_PPV_ARGS(&dxgiForegroundSwapChainBackBuffer))
            );

        DX::ThrowIfFailed(
            m_d2dContext->CreateBitmapFromDxgiSurface(
                dxgiForegroundSwapChainBackBuffer.Get(),
                &bitmapProperties,
                &m_d2dTargetBitmap
                )
            );
    }
    else
    {
        // Create a Direct2D target bitmap for the swap chain.
        ComPtr<IDXGISurface2> dxgiSwapChainBackBuffer;
        DX::ThrowIfFailed(
            m_swapChain->GetBuffer(0, IID_PPV_ARGS(&dxgiSwapChainBackBuffer))
            );

        DX::ThrowIfFailed(
            m_d2dContext->CreateBitmapFromDxgiSurface(
                dxgiSwapChainBackBuffer.Get(),
                &bitmapProperties,
                &m_d2dTargetBitmap
                )
            );
    }

    m_d2dContext->SetTarget(m_d2dTargetBitmap.Get());
    ```

    ```cpp
    // Create a render target view of the swap chain's back buffer.
    ComPtr<ID3D11Texture2D> backBuffer;
    DX::ThrowIfFailed(
        m_swapChain->GetBuffer(0, IID_PPV_ARGS(&backBuffer))
        );

    DX::ThrowIfFailed(
        m_d3dDevice->CreateRenderTargetView(
            backBuffer.Get(),
            nullptr,
            &m_d3dRenderTargetView
            )
        );
    ```

6.  <span data-ttu-id="a8690-151">前景スワップ チェーンを、リアルタイムのゲーム コンテンツに使うスケーリングされたスワップ チェーンと共に表示します。</span><span class="sxs-lookup"><span data-stu-id="a8690-151">Present the foreground swap chain together with the scaled swap chain used for real-time game content.</span></span> <span data-ttu-id="a8690-152">両方のスワップ チェーンに対してフレーム待機時間が 2 に設定されているため、DXGI は同じ VSync 間隔内で両方を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a8690-152">Since frame latency was set to 2 for both swap chains, DXGI can present them both within the same VSync interval.</span></span>

    ```cpp
    // Present the contents of the swap chain to the screen.
    void DX::DeviceResources::Present()
    {
        // The first argument instructs DXGI to block until VSync, putting the application
        // to sleep until the next VSync. This ensures that we don't waste any cycles rendering
        // frames that will never be displayed to the screen.
        HRESULT hr = m_swapChain->Present(1, 0);

        if (SUCCEEDED(hr) && m_foregroundSwapChain)
        {
            m_foregroundSwapChain->Present(1, 0);
        }

        // Discard the contents of the render targets.
        // This is a valid operation only when the existing contents will be entirely
        // overwritten. If dirty or scroll rects are used, this call should be removed.
        m_d3dContext->DiscardView(m_d3dRenderTargetView.Get());
        if (m_foregroundSwapChain)
        {
            m_d3dContext->DiscardView(m_d3dForegroundRenderTargetView.Get());
        }

        // Discard the contents of the depth stencil.
        m_d3dContext->DiscardView(m_d3dDepthStencilView.Get());

        // If the device was removed either by a disconnection or a driver upgrade, we
        // must recreate all device resources.
        if (hr == DXGI_ERROR_DEVICE_REMOVED)
        {
            HandleDeviceLost();
        }
        else
        {
            DX::ThrowIfFailed(hr);
        }
    }
    ```

 

 




