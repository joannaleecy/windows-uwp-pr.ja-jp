---
author: mtoepke
title: 画面の向きのサポート (DirectX と C++)
description: ここでは、windows 10 デバイスのグラフィックス ハードウェアが効率的かつ効果的に使用されるように、UWP DirectX アプリで画面の向きを処理するためのベスト プラクティスをについて説明します。
ms.assetid: f23818a6-e372-735d-912b-89cabeddb6d4
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 画面の向き, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 4ed8739f8ba7b2049af154d458ccaa831b8526a5
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7278687"
---
# <a name="supporting-screen-orientation-directx-and-c"></a><span data-ttu-id="c352e-104">画面の向きのサポート (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="c352e-104">Supporting screen orientation (DirectX and C++)</span></span>



<span data-ttu-id="c352e-105">ユニバーサル Windows プラットフォーム (UWP) アプリでは、[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントを処理するとき、複数の画面の向きをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="c352e-105">Your Universal Windows Platform (UWP) app can support multiple screen orientations when you handle the [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) event.</span></span> <span data-ttu-id="c352e-106">ここでは、windows 10 デバイスのグラフィックス ハードウェアが効率的かつ効果的に使用されるように、UWP DirectX アプリで画面の向きを処理するためのベスト プラクティスをについて説明します。</span><span class="sxs-lookup"><span data-stu-id="c352e-106">Here, we'll discuss best practices for handling screen rotation in your UWP DirectX app, so that the Windows10 device's graphics hardware are used efficiently and effectively.</span></span>

<span data-ttu-id="c352e-107">始める前に、グラフィックス ハードウェアは、デバイスの向きにかかわらず、常に同じ方法でピクセル データを出力するということを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="c352e-107">Before you start, remember that graphics hardware always outputs pixel data in the same way, regardless of the orientation of the device.</span></span> <span data-ttu-id="c352e-108">Windows 10 デバイスでは、(ある種のセンサーやソフトウェア トグル) は、現在の表示の向きを判断でき、ユーザーが表示設定を変更できるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="c352e-108">Windows10 devices can determine their current display orientation (with some sort of sensor, or with a software toggle) and allow users to change the display settings.</span></span> <span data-ttu-id="c352e-109">このため、windows 10 のため自体が「直立」デバイスの向きに基づくことを確認する画像の回転を処理します。</span><span class="sxs-lookup"><span data-stu-id="c352e-109">Because of this, Windows10 itself handles the rotation of the images to ensure they are "upright" based on the orientation of the device.</span></span> <span data-ttu-id="c352e-110">既定では、アプリは何か (たとえば、ウィンドウ サイズ) の方向が変化したという通知を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c352e-110">By default, your app receives the notification that something has changed in orientation, for example, a window size.</span></span> <span data-ttu-id="c352e-111">この場合、windows 10 は直ちに最終的な表示の画像を回転します。</span><span class="sxs-lookup"><span data-stu-id="c352e-111">When this happens, Windows10 immediately rotates the image for final display.</span></span> <span data-ttu-id="c352e-112">(後述) 4 つの特定の画面の向きの 3 つで、windows 10 は最終的な画像を表示するのに追加のグラフィックス リソースと計算を使用します。</span><span class="sxs-lookup"><span data-stu-id="c352e-112">For three of the four specific screen orientations (discussed later), Windows10 uses additional graphic resources and computation to display the final image.</span></span>

<span data-ttu-id="c352e-113">UWP DirectX アプリでは、アプリが照会できる基本的な表示の向きのデータを [**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/dn264258) オブジェクトが提供します。</span><span class="sxs-lookup"><span data-stu-id="c352e-113">For UWP DirectX apps, the [**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/dn264258) object provides basic display orientation data that your app can query.</span></span> <span data-ttu-id="c352e-114">既定の向きは*横*で、表示のピクセルの幅が高さよりも大きくなります。もう 1 つの向きは*縦*で、表示はどちらかの方向に 90° 回転され、幅は高さより小さくなります。</span><span class="sxs-lookup"><span data-stu-id="c352e-114">The default orientation is *landscape*, where the pixel width of the display is greater than the height; the alternative orientation is *portrait*, where the display is rotated 90 degrees in either direction and the width becomes less than the height.</span></span>

<span data-ttu-id="c352e-115">Windows 10 には、4 つの特定のディスプレイの向きのモードが定義されています。</span><span class="sxs-lookup"><span data-stu-id="c352e-115">Windows10 defines four specific display orientation modes:</span></span>

-   <span data-ttu-id="c352e-116">横: 既定値は、windows 10 の向きを表示し、(0 °) 回転の基準または本来の角度と見なされます。</span><span class="sxs-lookup"><span data-stu-id="c352e-116">Landscape—the default display orientation for Windows10, and is considered the base or identity angle for rotation (0 degrees).</span></span>
-   <span data-ttu-id="c352e-117">縦: 表示は時計回りに 90° (または反時計回りに 270°) 回転します。</span><span class="sxs-lookup"><span data-stu-id="c352e-117">Portrait—the display has been rotated clockwise 90 degrees (or counter-clockwise 270 degrees).</span></span>
-   <span data-ttu-id="c352e-118">横、反転: 表示は 180° 回転されます (上下が逆になります)。</span><span class="sxs-lookup"><span data-stu-id="c352e-118">Landscape, flipped—the display has been rotated 180 degrees (turned upside-down).</span></span>
-   <span data-ttu-id="c352e-119">縦、反転: 表示は時計回りに 270° (または反時計回りに 90°) 回転します。</span><span class="sxs-lookup"><span data-stu-id="c352e-119">Portrait, flipped—the display has been rotated clockwise 270 degrees (or counter-clockwise 90 degrees).</span></span>

<span data-ttu-id="c352e-120">別に 1 つの方向から表示が回転すると、windows 10 は内部的を新しい向きで描画される画像を配置するために回転操作を実行し、ユーザーが画面に、直立した画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="c352e-120">When the display rotates from one orientation to another, Windows10 internally performs a rotation operation to align the drawn image with the new orientation, and the user sees an upright image on the screen.</span></span>

<span data-ttu-id="c352e-121">また、windows 10 では、1 つの向きに変化するときにスムーズなユーザー エクスペリエンスを作成する自動切り替えアニメーションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-121">Also, Windows10 displays automatic transition animations to create a smooth user experience when shifting from one orientation to another.</span></span> <span data-ttu-id="c352e-122">表示の向きが変わる際に、ユーザーにはその変化が、表示されている画面の画像の固定拡大と回転アニメーションとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-122">As the display orientation shifts, the user sees these shifts as a fixed zoom and rotation animation of the displayed screen image.</span></span> <span data-ttu-id="c352e-123">Windows 10 によって、新しい向きでレイアウトのアプリへの時間が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c352e-123">Time is allocated by Windows10 to the app for layout in the new orientation.</span></span>

<span data-ttu-id="c352e-124">画面の向きの変更を処理する一般的なプロセスは、ほぼ次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c352e-124">Overall, this is the general process for handling changes in screen orientation:</span></span>

1.  <span data-ttu-id="c352e-125">ウィンドウの境界値と表示の向きのデータの組み合わせを使って、デバイスの本来の表示の向きに合わせたスワップ チェーンを維持します。</span><span class="sxs-lookup"><span data-stu-id="c352e-125">Use a combination of the window bounds values and the display orientation data to keep the swap chain aligned with the native display orientation of the device.</span></span>
2.  <span data-ttu-id="c352e-126">[**1::setrotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801)を使用して、スワップ チェーンの向きの windows 10 に通知します。</span><span class="sxs-lookup"><span data-stu-id="c352e-126">Notify Windows10 of the orientation of the swap chain using [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801).</span></span>
3.  <span data-ttu-id="c352e-127">レンダリング コードを変更して、デバイスのユーザーによる向きに合わせた画像を生成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-127">Change the rendering code to generate images aligned with the user orientation of the device.</span></span>

## <a name="resizing-the-swap-chain-and-pre-rotating-its-contents"></a><span data-ttu-id="c352e-128">スワップ チェーンのサイズ変更とその内容の事前回転</span><span class="sxs-lookup"><span data-stu-id="c352e-128">Resizing the swap chain and pre-rotating its contents</span></span>


<span data-ttu-id="c352e-129">UWP DirectX アプリで基本的な表示サイズ変更とその内容の事前回転を行うには、次の手順を実装します。</span><span class="sxs-lookup"><span data-stu-id="c352e-129">To perform a basic display resize and pre-rotate its contents in your UWP DirectX app , implement these steps:</span></span>

1.  <span data-ttu-id="c352e-130">[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="c352e-130">Handle the [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) event.</span></span>
2.  <span data-ttu-id="c352e-131">ウィンドウの新しいサイズにスワップ チェーンをサイズ変更します。</span><span class="sxs-lookup"><span data-stu-id="c352e-131">Resize the swap chain to the new dimensions of the window.</span></span>
3.  <span data-ttu-id="c352e-132">[**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出して、スワップ チェーンの向きを設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-132">Call [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) to set the orientation of the swap chain.</span></span>
4.  <span data-ttu-id="c352e-133">ウィンドウ サイズに依存するすべてのリソース (レンダー ターゲット、その他のピクセル データ バッファーなど) を再作成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-133">Recreate any window size dependent resources, such as your render targets and other pixel data buffers.</span></span>

<span data-ttu-id="c352e-134">それでは、これらの手順をもう少し詳しく見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c352e-134">Now's let's look at those steps in a bit more detail.</span></span>

<span data-ttu-id="c352e-135">最初の手順は、[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントのハンドラーを登録することです。</span><span class="sxs-lookup"><span data-stu-id="c352e-135">Your first step is to register a handler for the [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) event.</span></span> <span data-ttu-id="c352e-136">このイベントは、アプリで画面の向きが変更されるたびに発生します (表示が回転されたときなど)。</span><span class="sxs-lookup"><span data-stu-id="c352e-136">This event is raised in your app every time the screen orientation changes, such as when the display is rotated.</span></span>

<span data-ttu-id="c352e-137">[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントを処理するには、必須の [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509) メソッドで **DisplayInformation::OrientationChanged** のハンドラーを接続します。このメソッドは、ビュー プロバイダーが実装しなければならない [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) インターフェイスのメソッドのうちの 1 つです。</span><span class="sxs-lookup"><span data-stu-id="c352e-137">To handle the [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) event, you connect your handler for **DisplayInformation::OrientationChanged** in the required [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509) method, which is one of the methods of the [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) interface that your view provider must implement.</span></span>

<span data-ttu-id="c352e-138">このコード例では、[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) のイベント ハンドラーは、**OnOrientationChanged** というメソッドです。</span><span class="sxs-lookup"><span data-stu-id="c352e-138">In this code example, the event handler for [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) is a method called **OnOrientationChanged**.</span></span> <span data-ttu-id="c352e-139">**DisplayInformation::OrientationChanged** が発生すると、**SetCurrentOrientation** というメソッドを呼び出し、このメソッドが **CreateWindowSizeDependentResources** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c352e-139">When **DisplayInformation::OrientationChanged** is raised, it in turn calls a method called **SetCurrentOrientation** which then calls **CreateWindowSizeDependentResources**.</span></span>

```cpp
void App::SetWindow(CoreWindow^ window)
{
  // ... Other UI event handlers assigned here ...
  
    currentDisplayInformation->OrientationChanged +=
        ref new TypedEventHandler<DisplayInformation^, Object^>(this, &App::OnOrientationChanged);

  // ...
}
}
```

```cpp
void App::OnOrientationChanged(DisplayInformation^ sender, Object^ args)
{
    m_deviceResources->SetCurrentOrientation(sender->CurrentOrientation);
    m_main->CreateWindowSizeDependentResources();
}

// This method is called in the event handler for the OrientationChanged event.
void DX::DeviceResources::SetCurrentOrientation(DisplayOrientations currentOrientation)
{
    if (m_currentOrientation != currentOrientation)
    {
        m_currentOrientation = currentOrientation;
        CreateWindowSizeDependentResources();
    }
}
```

<span data-ttu-id="c352e-140">次に、スワップ チェーンを新しい画面の向きにサイズ変更し、レンダリングが行われるときにグラフィックス パイプラインの内容を回転させる準備をします。</span><span class="sxs-lookup"><span data-stu-id="c352e-140">Next, you resize the swap chain for the new screen orientation and prepare it to rotate the contents of the graphic pipeline when the rendering is performed.</span></span> <span data-ttu-id="c352e-141">この例では、**DirectXBase::CreateWindowSizeDependentResources** は、IDXGISwapChain::ResizeBuffers の呼び出し、3D および 2D 回転マトリックスの設定、SetRotation の呼び出し、リソースの再作成を処理するメソッドです。</span><span class="sxs-lookup"><span data-stu-id="c352e-141">In this example, **DirectXBase::CreateWindowSizeDependentResources** is a method that handles calling IDXGISwapChain::ResizeBuffers, setting a 3D and a 2D rotation matrix, calling SetRotation, and recreating your resources.</span></span>

```cpp
void DX::DeviceResources::CreateWindowSizeDependentResources() 
{
    // Clear the previous window size specific context.
    ID3D11RenderTargetView* nullViews[] = {nullptr};
    m_d3dContext->OMSetRenderTargets(ARRAYSIZE(nullViews), nullViews, nullptr);
    m_d3dRenderTargetView = nullptr;
    m_d2dContext->SetTarget(nullptr);
    m_d2dTargetBitmap = nullptr;
    m_d3dDepthStencilView = nullptr;
    m_d3dContext->Flush();

    // Calculate the necessary render target size in pixels.
    m_outputSize.Width = DX::ConvertDipsToPixels(m_logicalSize.Width, m_dpi);
    m_outputSize.Height = DX::ConvertDipsToPixels(m_logicalSize.Height, m_dpi);
    
    // Prevent zero size DirectX content from being created.
    m_outputSize.Width = max(m_outputSize.Width, 1);
    m_outputSize.Height = max(m_outputSize.Height, 1);

    // The width and height of the swap chain must be based on the window's
    // natively-oriented width and height. If the window is not in the native
    // orientation, the dimensions must be reversed.
    DXGI_MODE_ROTATION displayRotation = ComputeDisplayRotation();

    bool swapDimensions = displayRotation == DXGI_MODE_ROTATION_ROTATE90 || displayRotation == DXGI_MODE_ROTATION_ROTATE270;
    m_d3dRenderTargetSize.Width = swapDimensions ? m_outputSize.Height : m_outputSize.Width;
    m_d3dRenderTargetSize.Height = swapDimensions ? m_outputSize.Width : m_outputSize.Height;

    if (m_swapChain != nullptr)
    {
        // If the swap chain already exists, resize it.
        HRESULT hr = m_swapChain->ResizeBuffers(
            2, // Double-buffered swap chain.
            lround(m_d3dRenderTargetSize.Width),
            lround(m_d3dRenderTargetSize.Height),
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
    }
    else
    {
        // Otherwise, create a new one using the same adapter as the existing Direct3D device.
        DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};

        swapChainDesc.Width = lround(m_d3dRenderTargetSize.Width); // Match the size of the window.
        swapChainDesc.Height = lround(m_d3dRenderTargetSize.Height);
        swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM; // This is the most common swap chain format.
        swapChainDesc.Stereo = false;
        swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
        swapChainDesc.SampleDesc.Quality = 0;
        swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        swapChainDesc.BufferCount = 2; // Use double-buffering to minimize latency.
        swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // All UWP apps must use this SwapEffect.
        swapChainDesc.Flags = 0;    
        swapChainDesc.Scaling = DXGI_SCALING_NONE;
        swapChainDesc.AlphaMode = DXGI_ALPHA_MODE_IGNORE;

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

        DX::ThrowIfFailed(
            dxgiFactory->CreateSwapChainForCoreWindow(
                m_d3dDevice.Get(),
                reinterpret_cast<IUnknown*>(m_window.Get()),
                &swapChainDesc,
                nullptr,
                &m_swapChain
                )
            );

        // Ensure that DXGI does not queue more than one frame at a time. This both reduces latency and
        // ensures that the application will only render after each VSync, minimizing power consumption.
        DX::ThrowIfFailed(
            dxgiDevice->SetMaximumFrameLatency(1)
            );
    }

    // Set the proper orientation for the swap chain, and generate 2D and
    // 3D matrix transformations for rendering to the rotated swap chain.
    // Note the rotation angle for the 2D and 3D transforms are different.
    // This is due to the difference in coordinate spaces.  Additionally,
    // the 3D matrix is specified explicitly to avoid rounding errors.

    switch (displayRotation)
    {
    case DXGI_MODE_ROTATION_IDENTITY:
        m_orientationTransform2D = Matrix3x2F::Identity();
        m_orientationTransform3D = ScreenRotation::Rotation0;
        break;

    case DXGI_MODE_ROTATION_ROTATE90:
        m_orientationTransform2D = 
            Matrix3x2F::Rotation(90.0f) *
            Matrix3x2F::Translation(m_logicalSize.Height, 0.0f);
        m_orientationTransform3D = ScreenRotation::Rotation270;
        break;

    case DXGI_MODE_ROTATION_ROTATE180:
        m_orientationTransform2D = 
            Matrix3x2F::Rotation(180.0f) *
            Matrix3x2F::Translation(m_logicalSize.Width, m_logicalSize.Height);
        m_orientationTransform3D = ScreenRotation::Rotation180;
        break;

    case DXGI_MODE_ROTATION_ROTATE270:
        m_orientationTransform2D = 
            Matrix3x2F::Rotation(270.0f) *
            Matrix3x2F::Translation(0.0f, m_logicalSize.Width);
        m_orientationTransform3D = ScreenRotation::Rotation90;
        break;

    default:
        throw ref new FailureException();
    }


    //SDM: only instance of SetRotation
    DX::ThrowIfFailed(
        m_swapChain->SetRotation(displayRotation)
        );

    // Create a render target view of the swap chain back buffer.
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

    // Create a depth stencil view for use with 3D rendering if needed.
    CD3D11_TEXTURE2D_DESC depthStencilDesc(
        DXGI_FORMAT_D24_UNORM_S8_UINT, 
        lround(m_d3dRenderTargetSize.Width),
        lround(m_d3dRenderTargetSize.Height),
        1, // This depth stencil view has only one texture.
        1, // Use a single mipmap level.
        D3D11_BIND_DEPTH_STENCIL
        );

    ComPtr<ID3D11Texture2D> depthStencil;
    DX::ThrowIfFailed(
        m_d3dDevice->CreateTexture2D(
            &depthStencilDesc,
            nullptr,
            &depthStencil
            )
        );

    CD3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc(D3D11_DSV_DIMENSION_TEXTURE2D);
    DX::ThrowIfFailed(
        m_d3dDevice->CreateDepthStencilView(
            depthStencil.Get(),
            &depthStencilViewDesc,
            &m_d3dDepthStencilView
            )
        );
    
    // Set the 3D rendering viewport to target the entire window.
    m_screenViewport = CD3D11_VIEWPORT(
        0.0f,
        0.0f,
        m_d3dRenderTargetSize.Width,
        m_d3dRenderTargetSize.Height
        );

    m_d3dContext->RSSetViewports(1, &m_screenViewport);

    // Create a Direct2D target bitmap associated with the
    // swap chain back buffer and set it as the current target.
    D2D1_BITMAP_PROPERTIES1 bitmapProperties = 
        D2D1::BitmapProperties1(
            D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS_CANNOT_DRAW,
            D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
            m_dpi,
            m_dpi
            );

    ComPtr<IDXGISurface2> dxgiBackBuffer;
    DX::ThrowIfFailed(
        m_swapChain->GetBuffer(0, IID_PPV_ARGS(&dxgiBackBuffer))
        );

    DX::ThrowIfFailed(
        m_d2dContext->CreateBitmapFromDxgiSurface(
            dxgiBackBuffer.Get(),
            &bitmapProperties,
            &m_d2dTargetBitmap
            )
        );

    m_d2dContext->SetTarget(m_d2dTargetBitmap.Get());

    // Grayscale text anti-aliasing is recommended for all UWP apps.
    m_d2dContext->SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE);

}

```

<span data-ttu-id="c352e-142">このメソッドを次回に呼び出すときのためにウィンドウの現在の高さと幅の値を保存した後で、表示の境界の DIP (デバイスに依存しないピクセル) 値をピクセルに変換します。</span><span class="sxs-lookup"><span data-stu-id="c352e-142">After saving the current height and width values of the window for the next time this method is called, convert the device independent pixel (DIP) values for the display bounds to pixels.</span></span> <span data-ttu-id="c352e-143">例では、**ConvertDipsToPixels** を呼び出しています。これは、次のコードを実行する単純な関数です。</span><span class="sxs-lookup"><span data-stu-id="c352e-143">In the sample, you call **ConvertDipsToPixels**, which is a simple function that runs this code:</span></span>

` floor((dips * dpi / 96.0f) + 0.5f);`

<span data-ttu-id="c352e-144">0.5f を追加しているのは、最も近い整数に丸めるためです。</span><span class="sxs-lookup"><span data-stu-id="c352e-144">You add the 0.5f to ensure rounding to the nearest integer value.</span></span>

<span data-ttu-id="c352e-145">なお、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の座標は、常に DIP で定義されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-145">As an aside, [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) coordinates are always defined in DIPs.</span></span> <span data-ttu-id="c352e-146">Windows 10 と Windows の以前のバージョンでは、DIP は 1/96 インチ、および*上*の OS の定義として定義されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-146">For Windows10 and earlier versions of Windows, a DIP is defined as 1/96th of an inch, and aligned to the OS's definition of *up*.</span></span> <span data-ttu-id="c352e-147">表示の向きが縦モードに回転されると、アプリは **CoreWindow** の幅と高さを反転するので、レンダー ターゲットのサイズ (境界) もそれに応じて変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-147">When the display orientation rotates to portrait mode, the app flips the width and height of the **CoreWindow**, and the render target size (bounds) must change accordingly.</span></span> <span data-ttu-id="c352e-148">Direct3D の座標は常に物理ピクセルであるため、スワップ チェーンをセットアップするために Direct3D に渡す **CoreWindow** の DIP 値は、事前に整数ピクセル値に変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-148">Because Direct3D’s coordinates are always in physical pixels, you must convert from **CoreWindow**'s DIP values to integer pixel values before you pass these values to Direct3D to set up the swap chain.</span></span>

<span data-ttu-id="c352e-149">プロセスに関しては、単にスワップ チェーンをサイズ変更する場合よりも少し多くの作業を行っています。実際には、画像の Direct2D と Direct3D のコンポーネントを提示用に合成する前に回転させ、スワップ チェーンに結果を新しい向きでレンダリングしたことを伝えます。</span><span class="sxs-lookup"><span data-stu-id="c352e-149">Process-wise, you're doing a bit more work than you would if you simply resized the swap chain: you're actually rotating the Direct2D and Direct3D components of your image before you composite them for presentation, and you're telling the swap chain that you've rendered the results in a new orientation.</span></span> <span data-ttu-id="c352e-150">ここでは、**DX::DeviceResources::CreateWindowSizeDependentResources** のコード例で示されているように、このプロセスについてさらに詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="c352e-150">Here's a little more detail on this process, as shown in the code example for **DX::DeviceResources::CreateWindowSizeDependentResources**:</span></span>

-   <span data-ttu-id="c352e-151">表示の新しい向きを判断します。</span><span class="sxs-lookup"><span data-stu-id="c352e-151">Determine the new orientation of the display.</span></span> <span data-ttu-id="c352e-152">表示が横から縦に (またはその逆に) 反転された場合は、表示境界の高さと幅の値を交換します (当然、DIP 値をピクセルに変換します)。</span><span class="sxs-lookup"><span data-stu-id="c352e-152">If the display has flipped from landscape to portrait, or vice versa, swap the height and width values—changed from DIP values to pixels, of course—for the display bounds.</span></span>

-   <span data-ttu-id="c352e-153">次に、スワップ チェーンが作成されたかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c352e-153">Then, check to see if the swap chain has been created.</span></span> <span data-ttu-id="c352e-154">作成されていない場合は、[**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を呼び出して作成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-154">If it hasn't been created, create it by calling [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559).</span></span> <span data-ttu-id="c352e-155">または、[**IDXGISwapchain:ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) を呼び出して、既にあるスワップ チェーンのバッファーのサイズを新しい表示サイズに変更します。</span><span class="sxs-lookup"><span data-stu-id="c352e-155">Otherwise, resize the existing swap chain's buffers to the new display dimensions by calling [**IDXGISwapchain:ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577).</span></span> <span data-ttu-id="c352e-156">回転イベントのためにスワップ チェーンをサイズ変更する必要はありませんが (レンダリング パイプラインによって既に回転された内容を出力するだけであるため)、スナップ イベントやページ横幅に合わせるイベントのように、サイズ変更が必要なその他のイベントもあります。</span><span class="sxs-lookup"><span data-stu-id="c352e-156">Although you don't need to resize the swap chain for the rotation event—you're outputting the content already rotated by your rendering pipeline, after all—there are other size change events, such as snap and fill events, that require resizing.</span></span>

-   <span data-ttu-id="c352e-157">その後、グラフィックス パイプラインのピクセルまたは頂点をスワップ チェーンにレンダリングするときに適用する、適切な 2-D または 3-D マトリックス変換を設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-157">After that, set the appropriate 2-D or 3-D matrix transformation to apply to the pixels or the vertices (respectively) in the graphics pipeline when rendering them to the swap chain.</span></span> <span data-ttu-id="c352e-158">可能性のある回転マトリックスは、次の 4 つです。</span><span class="sxs-lookup"><span data-stu-id="c352e-158">We have 4 possible rotation matrices:</span></span>

    -   <span data-ttu-id="c352e-159">横 (DXGI\_MODE\_ROTATION\_IDENTITY)</span><span class="sxs-lookup"><span data-stu-id="c352e-159">landscape (DXGI\_MODE\_ROTATION\_IDENTITY)</span></span>
    -   <span data-ttu-id="c352e-160">縦 (DXGI\_MODE\_ROTATION\_ROTATE270)</span><span class="sxs-lookup"><span data-stu-id="c352e-160">portrait (DXGI\_MODE\_ROTATION\_ROTATE270)</span></span>
    -   <span data-ttu-id="c352e-161">横、反転 (DXGI\_MODE\_ROTATION\_ROTATE180)</span><span class="sxs-lookup"><span data-stu-id="c352e-161">landscape, flipped (DXGI\_MODE\_ROTATION\_ROTATE180)</span></span>
    -   <span data-ttu-id="c352e-162">縦、反転 (DXGI\_MODE\_ROTATION\_ROTATE90)</span><span class="sxs-lookup"><span data-stu-id="c352e-162">portrait, flipped (DXGI\_MODE\_ROTATION\_ROTATE90)</span></span>

    <span data-ttu-id="c352e-163">表示の向きを決定するは、( [**displayinformation::orientationchanged**](https://msdn.microsoft.com/library/windows/apps/dn264268)の結果) など、windows 10 によって提供されるデータに基づいて適切なマトリックスを選択し、各ピクセル (Direct2D) または頂点の座標で乗算されます。(Direct3D)、シーンに効果的に回転すると、画面の向きに合わせて配置されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-163">The correct matrix is selected based on the data provided by Windows10 (such as the results of [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268)) for determining display orientation, and it will be multiplied by the coordinates of each pixel (Direct2D) or vertex (Direct3D) in the scene, effectively rotating them to align to the orientation of the screen.</span></span> <span data-ttu-id="c352e-164">Direct2D では画面の原点が左上隅として定義されていますが、Direct3D では原点がウィンドウの論理的中央として定義されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c352e-164">(Note that in Direct2D, the screen origin is defined as the upper-left corner, while in Direct3D the origin is defined as the logical center of the window.)</span></span>

> <span data-ttu-id="c352e-165">**注:** 回転し、その定義方法使われる 2-d 変換について詳しくは、[画面の向き (2 D) を定義する行列](#appendix-a-applying-matrices-for-screen-rotation-2-d)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c352e-165">**Note** For more info about the 2-D transformations used for rotation and how to define them, see [Defining matrices for screen rotation (2-D)](#appendix-a-applying-matrices-for-screen-rotation-2-d).</span></span> <span data-ttu-id="c352e-166">回転で使われる 3-D 変換について詳しくは、「[画面の回転のためのマトリックスの適用 (3-D)](#appendix-b-applying-matrices-for-screen-rotation-3-d)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c352e-166">For more info about the 3-D transformations used for rotation, see [Defining matrices for screen rotation (3-D)](#appendix-b-applying-matrices-for-screen-rotation-3-d).</span></span>

 

<span data-ttu-id="c352e-167">ここからが重要な部分です。次のように、[**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出して、更新した回転マトリックスを渡します。</span><span class="sxs-lookup"><span data-stu-id="c352e-167">Now, here's the important bit: call [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) and provide it with your updated rotation matrix, like this:</span></span>

`m_swapChain->SetRotation(rotation);`

<span data-ttu-id="c352e-168">また、選択された回転マトリックスを、レンダリング メソッドが新しいプロジェクションを計算するときに取得できる場所に格納します。</span><span class="sxs-lookup"><span data-stu-id="c352e-168">You also store the selected rotation matrix where your render method can get it when it computes the new projection.</span></span> <span data-ttu-id="c352e-169">最終的な 3-D プロジェクションをレンダリングするとき、または最終的な 2-D レイアウトを合成するときに、このマトリックスを使います。</span><span class="sxs-lookup"><span data-stu-id="c352e-169">You'll use this matrix when you render your final 3-D projection or composite your final 2-D layout.</span></span> <span data-ttu-id="c352e-170">自動的に適用されることはありません。</span><span class="sxs-lookup"><span data-stu-id="c352e-170">(It doesn't automatically apply it for you.)</span></span>

<span data-ttu-id="c352e-171">その後、回転された 3-D ビューのための新しいレンダー ターゲットと、ビューのための新しい深度ステンシル バッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-171">After that, create a new render target for the rotated 3-D view, as well as a new depth stencil buffer for the view.</span></span> <span data-ttu-id="c352e-172">[**ID3D11DeviceContext:RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) を呼び出して、回転されたシーンのための 3-D レンダリング ビューポートを設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-172">Set the 3-D rendering viewport for the rotated scene by calling [**ID3D11DeviceContext:RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480).</span></span>

<span data-ttu-id="c352e-173">最後に、回転またはレイアウトする 2-D 画像がある場合は、[**ID2D1DeviceContext::CreateBitmapFromDxgiSurface**](https://msdn.microsoft.com/library/windows/desktop/hh404482) を使って、サイズ変更されたスワップ チェーンのための書き込み可能なビットマップとして 2-D レンダー ターゲットを作成し、更新された向きのための新しいレイアウトを合成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-173">Lastly, if you have 2-D images to rotate or lay out, create a 2-D render target as a writable bitmap for the resized swap chain using [**ID2D1DeviceContext::CreateBitmapFromDxgiSurface**](https://msdn.microsoft.com/library/windows/desktop/hh404482) and composite your new layout for the updated orientation.</span></span> <span data-ttu-id="c352e-174">レンダー ターゲットで、必要に応じて任意のプロパティ (コード例でのアンチエイリアシング モードなど) を設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-174">Set any properties you need to on the render target, such as the anti-aliasing mode (as seen in the code example).</span></span>

<span data-ttu-id="c352e-175">ここで、スワップ チェーンを表示します。</span><span class="sxs-lookup"><span data-stu-id="c352e-175">Now, present the swap chain.</span></span>

## <a name="reduce-the-rotation-delay-by-using-corewindowresizemanager"></a><span data-ttu-id="c352e-176">CoreWindowResizeManager の使用による回転の遅延の短縮</span><span class="sxs-lookup"><span data-stu-id="c352e-176">Reduce the rotation delay by using CoreWindowResizeManager</span></span>


<span data-ttu-id="c352e-177">既定では、windows 10 は、どのアプリには、アプリ モデルや画像の回転を完了する言語に関係なく、時間の短いながらも目立つ程度のウィンドウを提供します。</span><span class="sxs-lookup"><span data-stu-id="c352e-177">By default, Windows10 provides a short but noticeable window of time for any app, regardless of app model or language, to complete the rotation of the image.</span></span> <span data-ttu-id="c352e-178">ただし、アプリがここで説明したいずれかの方法で回転の計算を行った場合は、この時間枠が閉じる前に処理を完了できる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-178">However, chances are that when your app performs the rotation calculation using one of the techniques described here, it will be done well before this window of time has closed.</span></span> <span data-ttu-id="c352e-179">残った時間は返して、回転アニメーションを完了するために使いたいと思うでしょう。</span><span class="sxs-lookup"><span data-stu-id="c352e-179">You'd like to get that time back and complete the rotation animation, right?</span></span> <span data-ttu-id="c352e-180">ここで、[**CoreWindowResizeManager**](https://msdn.microsoft.com/library/windows/apps/jj215603) が登場します。</span><span class="sxs-lookup"><span data-stu-id="c352e-180">That's where [**CoreWindowResizeManager**](https://msdn.microsoft.com/library/windows/apps/jj215603) comes in.</span></span>

<span data-ttu-id="c352e-181">[**CoreWindowResizeManager**](https://msdn.microsoft.com/library/windows/apps/jj215603) の使い方は、次のようになります。[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントが発生したら、イベントのハンドラー内で [**CoreWindowResizeManager::GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh404170) を呼び出して、**CoreWindowResizeManager** のインスタンスを取得します。新しい向きのレイアウトが完了して提示されたら、[**NotifyLayoutCompleted**](https://msdn.microsoft.com/library/windows/apps/jj215605) を呼び出し、Windows に対して、回転アニメーションを完了してアプリ画面を表示できることを知らせます。</span><span class="sxs-lookup"><span data-stu-id="c352e-181">Here's how to use [**CoreWindowResizeManager**](https://msdn.microsoft.com/library/windows/apps/jj215603): when a [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) event is raised, call [**CoreWindowResizeManager::GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh404170) within the handler for the event to obtain an instance of **CoreWindowResizeManager** and, when the layout for the new orientation is complete and presented, call the [**NotifyLayoutCompleted**](https://msdn.microsoft.com/library/windows/apps/jj215605) to let Windows know that it can complete the rotation animation and display the app screen.</span></span>

<span data-ttu-id="c352e-182">[**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) のイベント ハンドラー内のコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c352e-182">Here's what the code in your event handler for [**DisplayInformation::OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) might look like:</span></span>

```cpp
CoreWindowResizeManager^ resizeManager = Windows::UI::Core::CoreWindowResizeManager::GetForCurrentView();

// ... build the layout for the new display orientation ...

resizeManager->NotifyLayoutCompleted();
```

<span data-ttu-id="c352e-183">ユーザーは、ディスプレイの向きを回転させると、windows 10 アニメーション、アプリの独立したフィードバックとしてユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="c352e-183">When a user rotates the orientation of the display, Windows10 shows an animation independent of your app as feedback to the user.</span></span> <span data-ttu-id="c352e-184">アニメーションは 3 つの部分から成り、次の順序で実行されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-184">There are three parts to that animation that happen in the following order:</span></span>

-   <span data-ttu-id="c352e-185">Windows 10 では、元の画像を縮小します。</span><span class="sxs-lookup"><span data-stu-id="c352e-185">Windows10 shrinks the original image.</span></span>
-   <span data-ttu-id="c352e-186">Windows 10 では、新しいレイアウトの再構築にかかる時間のイメージを保持します。</span><span class="sxs-lookup"><span data-stu-id="c352e-186">Windows10 holds the image for the time it takes to rebuild the new layout.</span></span> <span data-ttu-id="c352e-187">これが、短縮したい時間枠です。アプリはおそらく、この時間のすべては必要としません。</span><span class="sxs-lookup"><span data-stu-id="c352e-187">This is the window of time that you'd like to reduce, because your app probably doesn't need all of it.</span></span>
-   <span data-ttu-id="c352e-188">レイアウトの時間枠が終了するか、レイアウトの完了通知を受け取ると、Windows は画像を回転させ、クロスフェードが新しい向きにズームします。</span><span class="sxs-lookup"><span data-stu-id="c352e-188">When the layout window expires, or when a notification of layout completion is received, Windows rotates the image and then cross-fade zooms to new orientation.</span></span>

<span data-ttu-id="c352e-189">3 番目の項目で推奨される、として、アプリが[**NotifyLayoutCompleted**](https://msdn.microsoft.com/library/windows/apps/jj215605)を呼び出したとき windows 10 タイムアウトの時間枠を停止する、回転アニメーションを完了し、制御を返します、アプリでは、新しい表示の向きで描画ができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="c352e-189">As suggested in the third bullet, when an app calls [**NotifyLayoutCompleted**](https://msdn.microsoft.com/library/windows/apps/jj215605), Windows10 stops the timeout window, completes the rotation animation and returns control to your app, which is now drawing in the new display orientation.</span></span> <span data-ttu-id="c352e-190">全体的な効果は、アプリの動作が少し滑らかで機敏になり、効率もいくらか向上することです。</span><span class="sxs-lookup"><span data-stu-id="c352e-190">The overall effect is that your app now feels a little bit more fluid and responsive, and works a little more efficiently!</span></span>

## <a name="appendix-a-applying-matrices-for-screen-rotation-2-d"></a><span data-ttu-id="c352e-191">付録 A: 画面の向きのためのマトリックスの適用 (2-D)</span><span class="sxs-lookup"><span data-stu-id="c352e-191">Appendix A: Applying matrices for screen rotation (2-D)</span></span>


<span data-ttu-id="c352e-192">[スワップ チェーンのサイズ変更とその内容の事前回転](#resizing-the-swap-chain-and-pre-rotating-its-contents)のサンプル　コード (および [DXGI スワップ チェーンの回転のサンプル](http://go.microsoft.com/fwlink/p/?linkid=257600)) で既にお気付きかもしれませんが、回転マトリックスは Direct2D 出力用と Direct3D 出力用とに分けてきました。</span><span class="sxs-lookup"><span data-stu-id="c352e-192">In the example code in [Resizing the swap chain and pre-rotating its contents](#resizing-the-swap-chain-and-pre-rotating-its-contents) (and in the [DXGI swap chain rotation sample](http://go.microsoft.com/fwlink/p/?linkid=257600)), you might have noticed that we had separate rotation matrices for Direct2D output and Direct3D output.</span></span> <span data-ttu-id="c352e-193">まずは、2-D マトリックスを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c352e-193">Let's look at the 2-D matrices, first.</span></span>

<span data-ttu-id="c352e-194">Direct2D コンテンツと Direct3D コンテンツに同じ回転マトリックスを適用できない理由は、次の 2 つです。</span><span class="sxs-lookup"><span data-stu-id="c352e-194">There are two reasons that we can't apply the same rotation matrices to Direct2D and Direct3D content:</span></span>

-   <span data-ttu-id="c352e-195">1 つ目の理由は、異なるデカルト座標モデルが使われていることです。</span><span class="sxs-lookup"><span data-stu-id="c352e-195">One, they use different Cartesian coordinate models.</span></span> <span data-ttu-id="c352e-196">Direct2D では右手の法則が使われており、Y 座標は原点から上へ移動すると正の値が増加します。</span><span class="sxs-lookup"><span data-stu-id="c352e-196">Direct2D uses the right-handed rule, where the y-coordinate increases in positive value moving upward from the origin.</span></span> <span data-ttu-id="c352e-197">一方、Direct3D では左手の法則が使われており、Y 座標は原点から右に移動すると正の値が増加します。</span><span class="sxs-lookup"><span data-stu-id="c352e-197">However, Direct3D uses the left-handed rule, where the y-coordinate increases in positive value rightward from the origin.</span></span> <span data-ttu-id="c352e-198">そのため、Direct2D では画面座標の原点が左上にあり、Direct3D では画面 (プロジェクション平面) の原点が左下にあります。</span><span class="sxs-lookup"><span data-stu-id="c352e-198">The result is the origin for the screen coordinates is located in the upper-left for Direct2D, while the origin for the screen (the projection plane) is in the lower-left for Direct3D.</span></span> <span data-ttu-id="c352e-199">詳しくは、「[3-D 座標系](https://msdn.microsoft.com/library/windows/apps/bb324490.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c352e-199">(See [3-D coordinate systems](https://msdn.microsoft.com/library/windows/apps/bb324490.aspx) for more info.)</span></span>

    ![Direct3D 座標系。](images/direct3d-origin.png)![Direct2D 座標系。](images/direct2d-origin.png)

-   <span data-ttu-id="c352e-202">2 つ目の理由は、3-D 回転マトリックスは、丸めエラーを回避するために、明示的に指定する必要があることです。</span><span class="sxs-lookup"><span data-stu-id="c352e-202">Two, the 3-D rotation matrices must be specified explicitly to avoid rounding errors.</span></span>

<span data-ttu-id="c352e-203">スワップ チェーンは原点が左下にあると想定するため、右手による Direct2D 座標系を回転させて、スワップ チェーンで使われる左手による座標系に揃える必要があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-203">The swap chain assumes that the origin is located in the lower-left, so you must perform a rotation to align the right-handed Direct2D coordinate system with the left-handed one used by the swap chain.</span></span> <span data-ttu-id="c352e-204">具体的には、回転した座標系原点の変換マトリックスで回転マトリックスを乗算して、左手による新しい向きに画像を位置変更します。次に、画像を [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の座標空間からスワップ チェーンの座標空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="c352e-204">Specifically, you reposition the image under the new left-handed orientation by multiplying the rotation matrix with a translation matrix for the rotated coordinate system origin, and transform the image from the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)'s coordinate space to the swap chain's coordinate space.</span></span> <span data-ttu-id="c352e-205">Direct2D レンダー ターゲットがスワップ チェーンに接続されている場合は、アプリも一貫してこの変換を適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-205">Your app also must consistently apply this transform when the Direct2D render target is connected with the swap chain.</span></span> <span data-ttu-id="c352e-206">ただし、スワップ チェーンに直接関連付けられていない中間サーフェスにアプリが描画している場合は、この座標空間変換を適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="c352e-206">However, if your app is drawing to intermediate surfaces that are not associated directly with the swap chain, don't apply this coordinate space transformation.</span></span>

<span data-ttu-id="c352e-207">4 つの回転の中から適切なマトリックスを選ぶコードは、次のようになります (新しい座標系原点への変換に注意が必要です)。</span><span class="sxs-lookup"><span data-stu-id="c352e-207">Your code to select the correct matrix from the four possible rotations might look like this (be aware of the translation to the new coordinate system origin):</span></span>

```cpp
   
// Set the proper orientation for the swap chain, and generate 2D and
// 3D matrix transformations for rendering to the rotated swap chain.
// Note the rotation angle for the 2D and 3D transforms are different.
// This is due to the difference in coordinate spaces.  Additionally,
// the 3D matrix is specified explicitly to avoid rounding errors.

switch (displayRotation)
{
case DXGI_MODE_ROTATION_IDENTITY:
    m_orientationTransform2D = Matrix3x2F::Identity();
    m_orientationTransform3D = ScreenRotation::Rotation0;
    break;

case DXGI_MODE_ROTATION_ROTATE90:
    m_orientationTransform2D = 
        Matrix3x2F::Rotation(90.0f) *
        Matrix3x2F::Translation(m_logicalSize.Height, 0.0f);
    m_orientationTransform3D = ScreenRotation::Rotation270;
    break;

case DXGI_MODE_ROTATION_ROTATE180:
    m_orientationTransform2D = 
        Matrix3x2F::Rotation(180.0f) *
        Matrix3x2F::Translation(m_logicalSize.Width, m_logicalSize.Height);
    m_orientationTransform3D = ScreenRotation::Rotation180;
    break;

case DXGI_MODE_ROTATION_ROTATE270:
    m_orientationTransform2D = 
        Matrix3x2F::Rotation(270.0f) *
        Matrix3x2F::Translation(0.0f, m_logicalSize.Width);
    m_orientationTransform3D = ScreenRotation::Rotation90;
    break;

default:
    throw ref new FailureException();
}
    
```

<span data-ttu-id="c352e-208">2-D 画像の正しい変換マトリックスと原点を取得したら、[**ID2D1DeviceContext::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/dd371768) と [**ID2D1DeviceContext::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/dd371924) の呼び出しの間で、[**ID2D1DeviceContext::SetTransform**](https://msdn.microsoft.com/library/windows/desktop/dd742857) を呼び出して設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-208">After you have the correct rotation matrix and origin for the 2-D image, set it with a call to [**ID2D1DeviceContext::SetTransform**](https://msdn.microsoft.com/library/windows/desktop/dd742857) between your calls to [**ID2D1DeviceContext::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/dd371768) and [**ID2D1DeviceContext::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/dd371924).</span></span>

<span data-ttu-id="c352e-209">**警告** Direct2D 変換スタックがありません。</span><span class="sxs-lookup"><span data-stu-id="c352e-209">**Warning** Direct2D doesn't have a transformation stack.</span></span> <span data-ttu-id="c352e-210">アプリが [**ID2D1DeviceContext::SetTransform**](https://msdn.microsoft.com/library/windows/desktop/dd742857) を描画コードの一部としても使っている場合、このマトリックスは、適用した他のすべての変換で、右から乗算する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c352e-210">If your app is also using the [**ID2D1DeviceContext::SetTransform**](https://msdn.microsoft.com/library/windows/desktop/dd742857) as a part of its drawing code, this matrix needs to be post-multiplied to any other transform you have applied.</span></span>

 

```cpp
    ID2D1DeviceContext* context = m_deviceResources->GetD2DDeviceContext();
    Windows::Foundation::Size logicalSize = m_deviceResources->GetLogicalSize();

    context->SaveDrawingState(m_stateBlock.Get());
    context->BeginDraw();

    // Position on the bottom right corner.
    D2D1::Matrix3x2F screenTranslation = D2D1::Matrix3x2F::Translation(
        logicalSize.Width - m_textMetrics.layoutWidth,
        logicalSize.Height - m_textMetrics.height
        );

    context->SetTransform(screenTranslation * m_deviceResources->GetOrientationTransform2D());

    DX::ThrowIfFailed(
        m_textFormat->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_TRAILING)
        );

    context->DrawTextLayout(
        D2D1::Point2F(0.f, 0.f),
        m_textLayout.Get(),
        m_whiteBrush.Get()
        );

    // Ignore D2DERR_RECREATE_TARGET here. This error indicates that the device
    // is lost. It will be handled during the next call to Present.
    HRESULT hr = context->EndDraw();
```

<span data-ttu-id="c352e-211">次にスワップ チェーンを表示するときは、2-D 画像が新しい表示の向きに合わせて回転されています。</span><span class="sxs-lookup"><span data-stu-id="c352e-211">The next time you present the swap chain, your 2-D image will be rotated to match the new display orientation.</span></span>

## <a name="appendix-b-applying-matrices-for-screen-rotation-3-d"></a><span data-ttu-id="c352e-212">付録 B: 画面の向きのためのマトリックスの適用 (3-D)</span><span class="sxs-lookup"><span data-stu-id="c352e-212">Appendix B: Applying matrices for screen rotation (3-D)</span></span>


<span data-ttu-id="c352e-213">[スワップ チェーンのサイズ変更とその内容の事前回転](#resizing-the-swap-chain-and-pre-rotating-its-contents)のコード例 (および [DXGI スワップ チェーンの回転のサンプル](http://go.microsoft.com/fwlink/p/?linkid=257600)) では、画面の向きごとに特定の変換マトリックスを定義しました。</span><span class="sxs-lookup"><span data-stu-id="c352e-213">In the example code in [Resizing the swap chain and pre-rotating its contents](#resizing-the-swap-chain-and-pre-rotating-its-contents) (and in the [DXGI swap chain rotation sample](http://go.microsoft.com/fwlink/p/?linkid=257600)), we defined a specific transformation matrix for each possible screen orientation.</span></span> <span data-ttu-id="c352e-214">ここでは、3-D シーンを回転させるためのマトリックスを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c352e-214">Now, let's look at the matrixes for rotating 3-D scenes.</span></span> <span data-ttu-id="c352e-215">前と同じように、4 つのそれぞれの向きのために、マトリックスのセットを作成します。</span><span class="sxs-lookup"><span data-stu-id="c352e-215">As before, you create a set of matrices for each of the 4 possible orientations.</span></span> <span data-ttu-id="c352e-216">丸めエラー、つまりわずかな視覚的アーティファクトを避けるために、コード内でマトリックスを明示的に宣言します。</span><span class="sxs-lookup"><span data-stu-id="c352e-216">To prevent rounding errors and thus minor visual artifacts, declare the matrices explicitly in your code.</span></span>

<span data-ttu-id="c352e-217">これらの 3-D 回転マトリックスは、次のようにセットアップします。</span><span class="sxs-lookup"><span data-stu-id="c352e-217">You set up these 3-D rotation matrices as follows.</span></span> <span data-ttu-id="c352e-218">次のコード例で示されているマトリックスは、カメラの 3-D シーン空間内の点を定義する頂点を 0°、90°、180°、または 270° 回転させる、標準的な回転マトリックスです。</span><span class="sxs-lookup"><span data-stu-id="c352e-218">The matrices shown in the following code example are standard rotation matrices for 0, 90, 180, and 270 degree rotations of the vertices that define points in the camera's 3-D scene space.</span></span> <span data-ttu-id="c352e-219">シーン内の各頂点の \[x, y, z\] 座標値は、シーンの 2-D プロジェクションが計算されるときに、この回転マトリックスによって乗算されます。</span><span class="sxs-lookup"><span data-stu-id="c352e-219">Each vertex's \[x, y, z\] coordinate value in the scene is multiplied by this rotation matrix when the 2-D projection of the scene is computed.</span></span>

```cpp
   
// 0-degree Z-rotation
static const XMFLOAT4X4 Rotation0( 
    1.0f, 0.0f, 0.0f, 0.0f,
    0.0f, 1.0f, 0.0f, 0.0f,
    0.0f, 0.0f, 1.0f, 0.0f,
    0.0f, 0.0f, 0.0f, 1.0f
    );

// 90-degree Z-rotation
static const XMFLOAT4X4 Rotation90(
    0.0f, 1.0f, 0.0f, 0.0f,
    -1.0f, 0.0f, 0.0f, 0.0f,
    0.0f, 0.0f, 1.0f, 0.0f,
    0.0f, 0.0f, 0.0f, 1.0f
    );

// 180-degree Z-rotation
static const XMFLOAT4X4 Rotation180(
    -1.0f, 0.0f, 0.0f, 0.0f,
    0.0f, -1.0f, 0.0f, 0.0f,
    0.0f, 0.0f, 1.0f, 0.0f,
    0.0f, 0.0f, 0.0f, 1.0f
    );

// 270-degree Z-rotation
static const XMFLOAT4X4 Rotation270( 
    0.0f, -1.0f, 0.0f, 0.0f,
    1.0f, 0.0f, 0.0f, 0.0f,
    0.0f, 0.0f, 1.0f, 0.0f,
    0.0f, 0.0f, 0.0f, 1.0f
    );            
    }
```

<span data-ttu-id="c352e-220">スワップ チェーンの回転の種類は、次のように、[**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出して設定します。</span><span class="sxs-lookup"><span data-stu-id="c352e-220">You set the rotation type on the swap chain with a call to [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801), like this:</span></span>

`   m_swapChain->SetRotation(rotation);`

<span data-ttu-id="c352e-221">ここで、レンダリング メソッド内に、次のようなコードを実装します。</span><span class="sxs-lookup"><span data-stu-id="c352e-221">Now, in your render method, implement some code similar to this:</span></span>

``` syntax
struct ConstantBuffer // This struct is provided for illustration.
{
    // Other constant buffer matrices and data are defined here.

    float4x4 projection; // Current matrix for projection
} ;
ConstantBuffer  m_constantBufferData;          // Constant buffer resource data

// ...

// Rotate the projection matrix as it will be used to render to the rotated swap chain.
m_constantBufferData.projection = mul(m_constantBufferData.projection, m_rotationTransform3D);
```

<span data-ttu-id="c352e-222">これで、レンダリング メソッドを呼び出すと、現在の回転マトリックス (クラス変数 **m\_orientationTransform3D** によって指定されたもの) が現在のプロジェクション マトリックスで乗算され、この演算の結果がレンダラーの新しいプロジェクション マトリックスとして割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c352e-222">Now, when you call your render method, it multiplies the current rotation matrix (as specified by the class variable **m\_orientationTransform3D**) with the current projection matrix, and assigns the results of that operation as the new projection matrix for your renderer.</span></span> <span data-ttu-id="c352e-223">スワップ チェーンを表示すると、更新された表示の向きでシーンを見ることができます。</span><span class="sxs-lookup"><span data-stu-id="c352e-223">Present the swap chain to see the scene in the updated display orientation.</span></span>

 

 




