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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304784"
---
# <a name="swap-chain-scaling-and-overlays"></a>スワップ チェーンのスケーリングとオーバーレイ



モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーン (使用できる場合) を使って画質を高める方法について説明します。

## <a name="swap-chains-in-directx-112"></a>DirectX 11.2 でのスワップ チェーン


Direct3D 11.2 では、ネイティブでない (より低い) 解像度から拡大されたスワップ チェーンを使ったユニバーサル Windows プラットフォーム (UWP) アプリを作成でき、フィル レートを高速化できます。 また、Direct3D 11.2 には、別のスワップ チェーンでネイティブの解像度で UI を表示できる、ハードウェア オーバーレイを使ったレンダリング用の API も含まれています。 これにより、ゲームで高いフレームレートを維持しながらネイティブのフル解像度で UI を描画できるため、モバイル デバイスと高 DPI ディスプレイ (3840 x 2160 など) の性能を最大限引き出すことができます。 この記事では、オーバーラップ スワップ チェーンを使う方法について説明します。

Direct3D 11.2 には、フリップ モデルのスワップ チェーンで待機時間を短縮するための新しい機能も含まれています。 「[DXGI 1.3 スワップ チェーンによる遅延の減少](reduce-latency-with-dxgi-1-3-swap-chains.md)」をご覧ください。

## <a name="use-swap-chain-scaling"></a>スワップ チェーンのスケーリングの使用


下位のハードウェアまたは電力消費を抑えるために最適化されたハードウェアでゲームを実行するときに、ディスプレイのネイティブの機能よりも低い解像度を使って、リアルタイムのゲーム コンテンツをレンダリングする方法が有効である場合があります。 そのためには、ゲーム コンテンツをレンダリングするために使うスワップ チェーンをネイティブの解像度よりも小さくするか、スワップ チェーンのサブ領域を使う必要があります。

1.  最初に、ネイティブのフル解像度でスワップ チェーンを作成します。

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

2.  次に、ソース サイズを低い解像度に設定して拡大するスワップ チェーンのサブ領域を選びます。

    DX 前景スワップ チェーンのサンプルでは、小さくした解像度をパーセントで計算しています。

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

3.  スワップ チェーンのサブ領域に合わせてビューポートを作成します。

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

4.  Direct2D が使われている場合は、ソース領域に合わせて回転の変換を調整する必要があります。

## <a name="create-a-hardware-overlay-swap-chain-for-ui-elements"></a>UI 要素のためのハードウェア オーバーレイ スワップ チェーンの作成


スワップ チェーンのスケーリングを使った場合、この手法に固有の短所として、UI も縮小され、ぼやけて使いづらくなる可能性があります。 オーバーレイ スナップ チェーンがハードウェア サポートされているデバイスでは、この問題を解決するために、リアルタイムのゲーム コンテンツとは別のスワップ チェーンを使ってネイティブの解像度で UI をレンダリングします。 この手法は [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) スワップ チェーンにのみ適用される点に注意してください。XAML との相互運用には使用できません。

ハードウェア オーバーレイ機能を使う前景スワップ チェーンを作成するには、次の手順を実行します。 この手順は、前に述べたように最初にリアルタイムのゲーム コンテンツ用のスワップ チェーンを作成した後で実行されます。

1.  まず、DXGI アダプターでオーバーレイがサポートされているかどうかを調べます。 スワップ チェーンから DXGI 出力アダプターを取得します。

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

    DXGI アダプターでは、出力アダプターが [**SupportsOverlays**](https://msdn.microsoft.com/library/windows/desktop/dn280411) に対して True を返す場合はオーバーレイがサポートされます。

    ```cpp
    m_overlaySupportExists = dxgiOutput2->SupportsOverlays() ? true : false;
    ```
    
    > **注:**  、DXGI アダプターでは、オーバーレイをサポートする場合、次の手順に進みます。 デバイスがオーバーレイをサポートしない場合は、複数のスワップ チェーンを使ったレンダリングは効率的ではありません。 代わりに、リアルタイムのゲーム コンテンツと同じスワップ チェーンで解像度を下げて UI をレンダリングします。

     

2.  [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を使って前景スワップ チェーンを作成します。 次のオプションを [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定し、*pDesc* パラメーターに提供する必要があります。

    -   前景スワップ チェーンを示す [**DXGI\_SWAP\_CHAIN\_FLAG\_FOREGROUND\_LAYER**](https://msdn.microsoft.com/library/windows/desktop/bb173076) スワップ チェーン フラグを指定します。
    -   [**DXGI\_ALPHA\_MODE\_PREMULTIPLIED**](https://msdn.microsoft.com/library/windows/desktop/hh404496) アルファ モード フラグを使います。 前景スワップ チェーンは常にプリマルチプライ済みです。
    -   [**DXGI\_SCALING\_NONE**](https://msdn.microsoft.com/library/windows/desktop/hh404526) フラグを設定します。 前景スワップ チェーンは、常にネイティブの解像度で実行されます。

    ```cpp
     foregroundSwapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER;
     foregroundSwapChainDesc.Scaling = DXGI_SCALING_NONE;
     foregroundSwapChainDesc.AlphaMode = DXGI_ALPHA_MODE_PREMULTIPLIED; // Foreground swap chain alpha values must be premultiplied.
    ```

    > **注:** スワップ チェーンのサイズが変更されるたびに、 [**dxgi \_swap\_chain\_flag\_foreground\_layer**](https://msdn.microsoft.com/library/windows/desktop/bb173076)をもう一度設定します。

    ```cpp
    HRESULT hr = m_foregroundSwapChain->ResizeBuffers(
        2, // Double-buffered swap chain.
        static_cast<UINT>(m_d3dRenderTargetSize.Width),
        static_cast<UINT>(m_d3dRenderTargetSize.Height),
        DXGI_FORMAT_B8G8R8A8_UNORM,
        DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER // The FOREGROUND_LAYER flag cannot be removed with ResizeBuffers.
        );
    ```

3.  2 つのスワップ チェーンが使われている場合は、最大フレーム待機時間の値を増やして 2 に設定し、DXGI アダプターで両方のスワップ チェーンを同時に表示する時間を確保します (同じ VSync 間隔で)。

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

4.  前景スワップ チェーンでは、プリマルチプライ アルファ値が必ず使われます。 各ピクセルのカラー値は、フレームが表示される前にアルファ値が乗算されることが前提となります。 たとえば、アルファ値 50% の場合、100% 白の BGRA ピクセルは (0.5, 0.5, 0.5, 0.5) に設定されます。

    アルファ値のプリマルチプライの手順は、アプリのブレンド状態を適用することにより、出力マージャー ステージで実行できます ([**ID3D11BlendState**](https://msdn.microsoft.com/library/windows/desktop/ff476349) をご覧ください)。それには、[**D3D11\_RENDER\_TARGET\_BLEND\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476200) 構造の **SrcBlend** フィールドを **D3D11\_SRC\_ALPHA** に設定します。 プリマルチプライ アルファ値を含むアセットを使うこともできます。

    アルファ値のプリマルチプライの手順が実行されていない場合、前景スワップ チェーンのカラーは想定よりも明るくなります。

5.  前景スワップ チェーンが作成されたかどうかに応じて、UI 要素の Direct2D 描画サーフェスを前景スワップ チェーンに関連付けることが必要になる場合があります。

    レンダー ターゲット ビューを作成します。

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

    Direct2D 描画サーフェスを作成します。

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

6.  前景スワップ チェーンを、リアルタイムのゲーム コンテンツに使うスケーリングされたスワップ チェーンと共に表示します。 両方のスワップ チェーンに対してフレーム待機時間が 2 に設定されているため、DXGI は同じ VSync 間隔内で両方を表示できます。

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

 

 




