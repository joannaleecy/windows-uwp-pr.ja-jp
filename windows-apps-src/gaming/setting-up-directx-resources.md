---
author: mtoepke
title: DirectX リソースの設定と画像の表示
description: ここでは、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示する方法について説明します。
ms.assetid: d54d96fe-3522-4acb-35f4-bb11c3a5b064
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、DirectX、リソース、画像
ms.localizationpriority: medium
ms.openlocfilehash: 24fd038bdd447491da43e5d5803445d00147ba2d
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7564488"
---
# <a name="set-up-directx-resources-and-display-an-image"></a><span data-ttu-id="5a735-104">DirectX リソースの設定と画像の表示</span><span class="sxs-lookup"><span data-stu-id="5a735-104">Set up DirectX resources and display an image</span></span>



<span data-ttu-id="5a735-105">ここでは、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a735-105">Here, we show you how to create a Direct3D device, swap chain, and render-target view, and how to present the rendered image to the display.</span></span>

<span data-ttu-id="5a735-106">**目的:** C++ ユニバーサル Windows プラットフォーム (UWP) アプリで DirectX リソースを設定し、単色を表示する。</span><span class="sxs-lookup"><span data-stu-id="5a735-106">**Objective:** To set up DirectX resources in a C++ Universal Windows Platform (UWP) app and to display a solid color.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="5a735-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="5a735-107">Prerequisites</span></span>


<span data-ttu-id="5a735-108">C++ に習熟していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="5a735-108">We assume that you are familiar with C++.</span></span> <span data-ttu-id="5a735-109">また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。</span><span class="sxs-lookup"><span data-stu-id="5a735-109">You also need basic experience with graphics programming concepts.</span></span>

<span data-ttu-id="5a735-110">**完了までの時間:** 20 分。</span><span class="sxs-lookup"><span data-stu-id="5a735-110">**Time to complete:** 20 minutes.</span></span>

## <a name="instructions"></a><span data-ttu-id="5a735-111">手順</span><span class="sxs-lookup"><span data-stu-id="5a735-111">Instructions</span></span>

### <a name="1-declaring-direct3d-interface-variables-with-comptr"></a><span data-ttu-id="5a735-112">1. ComPtr を使った Direct3D インターフェイス変数の宣言</span><span class="sxs-lookup"><span data-stu-id="5a735-112">1. Declaring Direct3D interface variables with ComPtr</span></span>

<span data-ttu-id="5a735-113">Windows ランタイム C++ テンプレート ライブラリ (WRL) の ComPtr [スマート ポインター](https://msdn.microsoft.com/library/windows/apps/hh279674.aspx) テンプレートを使って Direct3D インターフェイス変数を宣言して、これらの変数の有効期間を例外安全な方法で管理できるようにします。</span><span class="sxs-lookup"><span data-stu-id="5a735-113">We declare Direct3D interface variables with the ComPtr [smart pointer](https://msdn.microsoft.com/library/windows/apps/hh279674.aspx) template from the Windows Runtime C++ Template Library (WRL), so we can manage the lifetime of those variables in an exception safe manner.</span></span> <span data-ttu-id="5a735-114">これらの変数を使って [**ComPtr クラス**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) とそのメンバーにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="5a735-114">We can then use those variables to access the [**ComPtr class**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) and its members.</span></span> <span data-ttu-id="5a735-115">例:</span><span class="sxs-lookup"><span data-stu-id="5a735-115">For example:</span></span>

```cpp
    ComPtr<ID3D11RenderTargetView> m_renderTargetView;
    m_d3dDeviceContext->OMSetRenderTargets(
        1,
        m_renderTargetView.GetAddressOf(),
        nullptr // Use no depth stencil.
        );
```

<span data-ttu-id="5a735-116">ComPtr を使って [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) を宣言すると、ComPtr の **GetAddressOf** メソッドを使って **ID3D11RenderTargetView** (\*\*ID3D11RenderTargetView) へのポインターのアドレスを取得し、[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="5a735-116">If you declare [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) with ComPtr, you can then use ComPtr’s **GetAddressOf** method to get the address of the pointer to **ID3D11RenderTargetView** (\*\*ID3D11RenderTargetView) to pass to [**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464).</span></span> <span data-ttu-id="5a735-117">**OMSetRenderTargets** は、レンダー ターゲットを [output-merger stage](https://msdn.microsoft.com/library/windows/desktop/bb205120) にバインドして、レンダー ターゲットを出力ターゲットとして指定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-117">**OMSetRenderTargets** binds the render target to the [output-merger stage](https://msdn.microsoft.com/library/windows/desktop/bb205120) to specify the render target as the output target.</span></span>

<span data-ttu-id="5a735-118">サンプル アプリを起動すると、初期化と読み込みが行われ、実行準備が整います。</span><span class="sxs-lookup"><span data-stu-id="5a735-118">After the sample app is started, it initializes and loads, and is then ready to run.</span></span>

### <a name="2-creating-the-direct3d-device"></a><span data-ttu-id="5a735-119">2. Direct3D デバイスの作成</span><span class="sxs-lookup"><span data-stu-id="5a735-119">2. Creating the Direct3D device</span></span>

<span data-ttu-id="5a735-120">Direct3D API を使ってシーンをレンダリングするには、先にディスプレイ アダプターを表す Direct3D デバイスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a735-120">To use the Direct3D API to render a scene, we must first create a Direct3D device that represents the display adapter.</span></span> <span data-ttu-id="5a735-121">Direct3D デバイスを作成するために、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a735-121">To create the Direct3D device, we call the [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) function.</span></span> <span data-ttu-id="5a735-122">[**D3D\_FEATURE\_LEVEL**](https://msdn.microsoft.com/library/windows/desktop/ff476329) 値の配列でレベル 9.1 から 11.1 を指定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-122">We specify levels 9.1 through 11.1 in the array of [**D3D\_FEATURE\_LEVEL**](https://msdn.microsoft.com/library/windows/desktop/ff476329) values.</span></span> <span data-ttu-id="5a735-123">Direct3D はこの配列を順に見ていき、サポートされる最高の機能レベルを返します。</span><span class="sxs-lookup"><span data-stu-id="5a735-123">Direct3D walks the array in order and returns the highest supported feature level.</span></span> <span data-ttu-id="5a735-124">そのため、利用可能な最高レベルの機能レベルを取得するため、**D3D\_FEATURE\_LEVEL** 配列エントリを最高レベルから最低レベルまで一覧にします。</span><span class="sxs-lookup"><span data-stu-id="5a735-124">So, to get the highest feature level available, we list the **D3D\_FEATURE\_LEVEL** array entries from highest to lowest.</span></span> <span data-ttu-id="5a735-125">[**D3D11\_CREATE\_DEVICE\_BGRA\_SUPPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_BGRA_SUPPORT) フラグを *Flags* パラメーターに渡して、Direct3D リソースが Direct2D と相互運用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="5a735-125">We pass the [**D3D11\_CREATE\_DEVICE\_BGRA\_SUPPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_BGRA_SUPPORT) flag to the *Flags* parameter to make Direct3D resources interoperate with Direct2D.</span></span> <span data-ttu-id="5a735-126">デバッグ ビルドを使う場合、[**D3D11\_CREATE\_DEVICE\_DEBUG**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_DEBUG) フラグも渡します。</span><span class="sxs-lookup"><span data-stu-id="5a735-126">If we use the debug build, we also pass the [**D3D11\_CREATE\_DEVICE\_DEBUG**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_DEBUG) flag.</span></span> <span data-ttu-id="5a735-127">アプリのデバッグについて詳しくは、「[デバッグ レイヤーを使ったアプリのデバッグ](https://msdn.microsoft.com/library/windows/desktop/jj200584)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a735-127">For more info about debugging apps, see [Using the debug layer to debug apps](https://msdn.microsoft.com/library/windows/desktop/jj200584).</span></span>

<span data-ttu-id="5a735-128">[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) から返される Direct3D 11 デバイスとデバイス コンテキストを照会して、Direct3D 11.1 デバイス ([**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575)) とデバイス コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) を取得します。</span><span class="sxs-lookup"><span data-stu-id="5a735-128">We obtain the Direct3D 11.1 device ([**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575)) and device context ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) by querying the Direct3D 11 device and device context that are returned from [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082).</span></span>

```cpp
        // First, create the Direct3D device.

        // This flag is required in order to enable compatibility with Direct2D.
        UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)
        // If the project is in a debug build, enable debugging via SDK Layers with this flag.
        creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

        // This array defines the ordering of feature levels that D3D should attempt to create.
        D3D_FEATURE_LEVEL featureLevels[] =
        {
            D3D_FEATURE_LEVEL_11_1,
            D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL_10_0,
            D3D_FEATURE_LEVEL_9_3,
            D3D_FEATURE_LEVEL_9_1
        };

        ComPtr<ID3D11Device> d3dDevice;
        ComPtr<ID3D11DeviceContext> d3dDeviceContext;
        DX::ThrowIfFailed(
            D3D11CreateDevice(
                nullptr,                    // Specify nullptr to use the default adapter.
                D3D_DRIVER_TYPE_HARDWARE,
                nullptr,                    // leave as nullptr if hardware is used
                creationFlags,              // optionally set debug and Direct2D compatibility flags
                featureLevels,
                ARRAYSIZE(featureLevels),
                D3D11_SDK_VERSION,          // always set this to D3D11_SDK_VERSION
                &d3dDevice,
                nullptr,
                &d3dDeviceContext
                )
            );

        // Retrieve the Direct3D 11.1 interfaces.
        DX::ThrowIfFailed(
            d3dDevice.As(&m_d3dDevice)
            );

        DX::ThrowIfFailed(
            d3dDeviceContext.As(&m_d3dDeviceContext)
            );
```

### <a name="3-creating-the-swap-chain"></a><span data-ttu-id="5a735-129">3. スワップ チェーンの作成</span><span class="sxs-lookup"><span data-stu-id="5a735-129">3. Creating the swap chain</span></span>

<span data-ttu-id="5a735-130">次に、デバイスがレンダリングと表示に使うスワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="5a735-130">Next, we create a swap chain that the device uses for rendering and display.</span></span> <span data-ttu-id="5a735-131">[**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) 構造体を宣言して初期化し、スワップ チェーンを記述します。</span><span class="sxs-lookup"><span data-stu-id="5a735-131">We declare and initialize a [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) structure to describe the swap chain.</span></span> <span data-ttu-id="5a735-132">次に、スワップ チェーンをフリップモデル (つまり [**DXGI\_SWAP\_EFFECT\_FLIP\_SEQUENTIAL**](https://msdn.microsoft.com/library/windows/desktop/bb173077#DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL) 値が **SwapEffect** メンバーに設定されているスワップ チェーン) として設定し、**Format** メンバーを [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM) に設定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-132">Then, we set up the swap chain as flip-model (that is, a swap chain that has the [**DXGI\_SWAP\_EFFECT\_FLIP\_SEQUENTIAL**](https://msdn.microsoft.com/library/windows/desktop/bb173077#DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL) value set in the **SwapEffect** member) and set the **Format** member to [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM).</span></span> <span data-ttu-id="5a735-133">**SampleDesc** メンバーが指定する [**DXGI\_SAMPLE\_DESC**](https://msdn.microsoft.com/library/windows/desktop/bb173072) 構造体の **Count** メンバーを 1 に設定し、**DXGI\_SAMPLE\_DESC** の **Quality** メンバーを 0 に設定します。これは、フリップモデルでは複数サンプルのアンチエイリアシング (MSAA) をサポートしていないためです。</span><span class="sxs-lookup"><span data-stu-id="5a735-133">We set the **Count** member of the [**DXGI\_SAMPLE\_DESC**](https://msdn.microsoft.com/library/windows/desktop/bb173072) structure that the **SampleDesc** member specifies to 1 and the **Quality** member of **DXGI\_SAMPLE\_DESC** to zero because flip-model doesn’t support multiple sample antialiasing (MSAA).</span></span> <span data-ttu-id="5a735-134">**BufferCount** メンバーを 2 に設定して、スワップ チェーンがディスプレイ デバイスを表すフロント バッファーと、レンダー ターゲットとして機能するバック バッファーを使えるようにします。</span><span class="sxs-lookup"><span data-stu-id="5a735-134">We set the **BufferCount** member to 2 so the swap chain can use a front buffer to present to the display device and a back buffer that serves as the render target.</span></span>

<span data-ttu-id="5a735-135">Direct3D 11.1 デバイスを照会して、ベースとなる DXGI デバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="5a735-135">We obtain the underlying DXGI device by querying the Direct3D 11.1 device.</span></span> <span data-ttu-id="5a735-136">電力消費を抑えることは、ノート PC やタブレットなどのバッテリー駆動デバイスでは重要です。そのため、DXGI がキューに入れることができるバック バッファー フレームの最大数として 1 を指定して、[**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a735-136">To minimize power consumption, which is important to do on battery-powered devices such as laptops and tablets, we call the [**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334) method with 1 as the maximum number of back buffer frames that DXGI can queue.</span></span> <span data-ttu-id="5a735-137">これにより、アプリは垂直ブランクの後でのみレンダリングされるようになります。</span><span class="sxs-lookup"><span data-stu-id="5a735-137">This ensures that the app is rendered only after the vertical blank.</span></span>

<span data-ttu-id="5a735-138">最終的にスワップ チェーンを作成するには、DXGI デバイスから親ファクトリを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a735-138">To finally create the swap chain, we need to get the parent factory from the DXGI device.</span></span> <span data-ttu-id="5a735-139">[**IDXGIDevice::GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出してデバイスのアダプターを取得し、次にアダプターで [**IDXGIObject::GetParent**](https://msdn.microsoft.com/library/windows/desktop/bb174542) を呼び出して親ファクトリ ([**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556)) を取得します。</span><span class="sxs-lookup"><span data-stu-id="5a735-139">We call [**IDXGIDevice::GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) to get the adapter for the device, and then call [**IDXGIObject::GetParent**](https://msdn.microsoft.com/library/windows/desktop/bb174542) on the adapter to get the parent factory ([**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556)).</span></span> <span data-ttu-id="5a735-140">スワップ チェーンを作成するため、スワップ チェーン記述子とアプリのコア ウィンドウを指定して [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a735-140">To create the swap chain, we call [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) with the swap-chain descriptor and the app’s core window.</span></span>

```cpp
            // If the swap chain does not exist, create it.
            DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};

            swapChainDesc.Stereo = false;
            swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.Scaling = DXGI_SCALING_NONE;
            swapChainDesc.Flags = 0;

            // Use automatic sizing.
            swapChainDesc.Width = 0;
            swapChainDesc.Height = 0;

            // This is the most common swap chain format.
            swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;

            // Don't use multi-sampling.
            swapChainDesc.SampleDesc.Count = 1;
            swapChainDesc.SampleDesc.Quality = 0;

            // Use two buffers to enable the flip effect.
            swapChainDesc.BufferCount = 2;

            // We recommend using this swap effect for all applications.
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;


            // Once the swap chain description is configured, it must be
            // created on the same adapter as the existing D3D Device.

            // First, retrieve the underlying DXGI Device from the D3D Device.
            ComPtr<IDXGIDevice2> dxgiDevice;
            DX::ThrowIfFailed(
                m_d3dDevice.As(&dxgiDevice)
                );

            // Ensure that DXGI does not queue more than one frame at a time. This both reduces
            // latency and ensures that the application will only render after each VSync, minimizing
            // power consumption.
            DX::ThrowIfFailed(
                dxgiDevice->SetMaximumFrameLatency(1)
                );

            // Next, get the parent factory from the DXGI Device.
            ComPtr<IDXGIAdapter> dxgiAdapter;
            DX::ThrowIfFailed(
                dxgiDevice->GetAdapter(&dxgiAdapter)
                );

            ComPtr<IDXGIFactory2> dxgiFactory;
            DX::ThrowIfFailed(
                dxgiAdapter->GetParent(IID_PPV_ARGS(&dxgiFactory))
                );

            // Finally, create the swap chain.
            CoreWindow^ window = m_window.Get();
            DX::ThrowIfFailed(
                dxgiFactory->CreateSwapChainForCoreWindow(
                    m_d3dDevice.Get(),
                    reinterpret_cast<IUnknown*>(window),
                    &swapChainDesc,
                    nullptr, // Allow on all displays.
                    &m_swapChain
                    )
                );
```

### <a name="4-creating-the-render-target-view"></a><span data-ttu-id="5a735-141">4. レンダー ターゲット ビューの作成</span><span class="sxs-lookup"><span data-stu-id="5a735-141">4. Creating the render-target view</span></span>

<span data-ttu-id="5a735-142">グラフィックスをウィンドウにレンダリングするには、レンダー ターゲット ビューを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a735-142">To render graphics to the window, we need to create a render-target view.</span></span> <span data-ttu-id="5a735-143">レンダー ターゲット ビューを作成するときには、[**IDXGISwapChain::GetBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb174570) を呼び出してスワップ チェーンのバック バッファーを取得して使います。</span><span class="sxs-lookup"><span data-stu-id="5a735-143">We call [**IDXGISwapChain::GetBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb174570) to get the swap chain’s back buffer to use when we create the render-target view.</span></span> <span data-ttu-id="5a735-144">バック バッファーを 2D テクスチャ ([**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)) として指定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-144">We specify the back buffer as a 2D texture ([**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)).</span></span> <span data-ttu-id="5a735-145">レンダー ターゲット ビューを作成するため、スワップ チェーンのバック バッファーを指定して [**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a735-145">To create the render-target view, we call [**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) with the swap chain’s back buffer.</span></span> <span data-ttu-id="5a735-146">コア ウィンドウ全体に描画するように指定する必要があります。そのために、ビュー ポート ([**D3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476260)) をフル サイズのスワップ チェーンのバック バッファーとして指定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-146">We must specify to draw to the entire core window by specifying the view port ([**D3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476260)) as the full size of the swap chain's back buffer.</span></span> <span data-ttu-id="5a735-147">次に、このビュー ポートを [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) への呼び出しで使い、ビュー ポートをパイプラインの[ラスタライザー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205125)にバインドします。</span><span class="sxs-lookup"><span data-stu-id="5a735-147">We use the view port in a call to [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) to bind the view port to the [rasterizer stage](https://msdn.microsoft.com/library/windows/desktop/bb205125) of the pipeline.</span></span> <span data-ttu-id="5a735-148">ラスタライザー ステージは、ベクター情報をラスター画像に変換します。</span><span class="sxs-lookup"><span data-stu-id="5a735-148">The rasterizer stage converts vector information into a raster image.</span></span> <span data-ttu-id="5a735-149">この場合は単色を表示するだけなので、変換は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="5a735-149">In this case, we don't require a conversion because we are just displaying a solid color.</span></span>

```cpp
        // Once the swap chain is created, create a render target view.  This will
        // allow Direct3D to render graphics to the window.

        ComPtr<ID3D11Texture2D> backBuffer;
        DX::ThrowIfFailed(
            m_swapChain->GetBuffer(0, IID_PPV_ARGS(&backBuffer))
            );

        DX::ThrowIfFailed(
            m_d3dDevice->CreateRenderTargetView(
                backBuffer.Get(),
                nullptr,
                &m_renderTargetView
                )
            );


        // After the render target view is created, specify that the viewport,
        // which describes what portion of the window to draw to, should cover
        // the entire window.

        D3D11_TEXTURE2D_DESC backBufferDesc = {0};
        backBuffer->GetDesc(&backBufferDesc);

        D3D11_VIEWPORT viewport;
        viewport.TopLeftX = 0.0f;
        viewport.TopLeftY = 0.0f;
        viewport.Width = static_cast<float>(backBufferDesc.Width);
        viewport.Height = static_cast<float>(backBufferDesc.Height);
        viewport.MinDepth = D3D11_MIN_DEPTH;
        viewport.MaxDepth = D3D11_MAX_DEPTH;

        m_d3dDeviceContext->RSSetViewports(1, &viewport);
```

### <a name="5-presenting-the-rendered-image"></a><span data-ttu-id="5a735-150">5. レンダリングされた画像の表示</span><span class="sxs-lookup"><span data-stu-id="5a735-150">5. Presenting the rendered image</span></span>

<span data-ttu-id="5a735-151">シーンをレンダリングして表示し続けるために、無限ループを使います。</span><span class="sxs-lookup"><span data-stu-id="5a735-151">We enter an endless loop to continually render and display the scene.</span></span>

<span data-ttu-id="5a735-152">このループでは、次の呼び出しを実行します。</span><span class="sxs-lookup"><span data-stu-id="5a735-152">In this loop, we call:</span></span>

1.  <span data-ttu-id="5a735-153">[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464)レンダー ターゲットを出力ターゲットに指定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-153">[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) to specify the render target as the output target.</span></span>
2.  <span data-ttu-id="5a735-154">[**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) レンダー ターゲットを単色にクリアします。</span><span class="sxs-lookup"><span data-stu-id="5a735-154">[**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) to clear the render target to a solid color.</span></span>
3.  <span data-ttu-id="5a735-155">[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576)レンダリングされた画像をウィンドウに表示します。</span><span class="sxs-lookup"><span data-stu-id="5a735-155">[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) to present the rendered image to the window.</span></span>

<span data-ttu-id="5a735-156">この呼び出しでは前に最大フレーム待機時間を 1 に設定しているため、Windows は一般にレンダー ループの速度を画面のリフレッシュ レート (通常は約 60 Hz) まで下げます。</span><span class="sxs-lookup"><span data-stu-id="5a735-156">Because we previously set the maximum frame latency to 1, Windows generally slows down the render loop to the screen refresh rate, typically around 60 Hz.</span></span> <span data-ttu-id="5a735-157">レンダー ループの速度を下げるために、アプリが [**Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出したときにアプリをスリープ状態にします。</span><span class="sxs-lookup"><span data-stu-id="5a735-157">Windows slows down the render loop by making the app sleep when the app calls [**Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576).</span></span> <span data-ttu-id="5a735-158">画面が更新されるまでアプリをスリープ状態にします。</span><span class="sxs-lookup"><span data-stu-id="5a735-158">Windows makes the app sleep until the screen is refreshed.</span></span>

```cpp
        // Enter the render loop.  Note that UWP apps should never exit.
        while (true)
        {
            // Process events incoming to the window.
            m_window->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            // Specify the render target we created as the output target.
            m_d3dDeviceContext->OMSetRenderTargets(
                1,
                m_renderTargetView.GetAddressOf(),
                nullptr // Use no depth stencil.
                );

            // Clear the render target to a solid color.
            const float clearColor[4] = { 0.071f, 0.04f, 0.561f, 1.0f };
            m_d3dDeviceContext->ClearRenderTargetView(
                m_renderTargetView.Get(),
                clearColor
                );

            // Present the rendered image to the window.  Because the maximum frame latency is set to 1,
            // the render loop will generally be throttled to the screen refresh rate, typically around
            // 60 Hz, by sleeping the application on Present until the screen is refreshed.
            DX::ThrowIfFailed(
                m_swapChain->Present(1, 0)
                );
        }
```

### <a name="6-resizing-the-app-window-and-the-swap-chains-buffer"></a><span data-ttu-id="5a735-159">6. アプリのウィンドウとスワップ チェーンのバッファーのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="5a735-159">6. Resizing the app window and the swap chain’s buffer</span></span>

<span data-ttu-id="5a735-160">アプリ ウィンドウのサイズが変化すると、アプリはスワップ チェーンのバッファーのサイズを変更して、レンダー ターゲット ビューを再作成し、サイズが変更されたレンダリング済み画像を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a735-160">If the size of the app window changes, the app must resize the swap chain’s buffers, recreate the render-target view, and then present the resized rendered image.</span></span> <span data-ttu-id="5a735-161">スワップ チェーンのバッファーのサイズを変更するために、[**IDXGISwapChain::ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a735-161">To resize the swap chain’s buffers, we call [**IDXGISwapChain::ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577).</span></span> <span data-ttu-id="5a735-162">この呼び出しでは、バッファーの数やバッファーの形式を変更しません (*BufferCount* パラメーターは 2、*NewFormat* パラメーターは [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM))。</span><span class="sxs-lookup"><span data-stu-id="5a735-162">In this call, we leave the number of buffers and the format of the buffers unchanged (the *BufferCount* parameter to two and the *NewFormat* parameter to [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM)).</span></span> <span data-ttu-id="5a735-163">スワップ チェーンのバック バッファーのサイズは、サイズ変更されたウィンドウと同じサイズに設定します。</span><span class="sxs-lookup"><span data-stu-id="5a735-163">We make the size of the swap chain’s back buffer the same size as the resized window.</span></span> <span data-ttu-id="5a735-164">スワップ チェーンのバッファーのサイズを変更した後、新しいレンダー ターゲットを作成し、新しくレンダリングされた画像をアプリの初期化時と同様に表示します。</span><span class="sxs-lookup"><span data-stu-id="5a735-164">After we resize the swap chain’s buffers, we create the new render target and present the new rendered image similarly to when we initialized the app.</span></span>

```cpp
            // If the swap chain already exists, resize it.
            DX::ThrowIfFailed(
                m_swapChain->ResizeBuffers(
                    2,
                    0,
                    0,
                    DXGI_FORMAT_B8G8R8A8_UNORM,
                    0
                    )
                );
```

## <a name="summary-and-next-steps"></a><span data-ttu-id="5a735-165">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="5a735-165">Summary and next steps</span></span>


<span data-ttu-id="5a735-166">Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像がディスプレイに表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="5a735-166">We created a Direct3D device, swap chain, and render-target view, and presented the rendered image to the display.</span></span>

<span data-ttu-id="5a735-167">次は、ディスプレイに三角形を描画します。</span><span class="sxs-lookup"><span data-stu-id="5a735-167">Next, we also draw a triangle on the display.</span></span>

[<span data-ttu-id="5a735-168">シェーダーの作成とプリミティブの描画</span><span class="sxs-lookup"><span data-stu-id="5a735-168">Creating shaders and drawing primitives</span></span>](creating-shaders-and-drawing-primitives.md)

 

 




