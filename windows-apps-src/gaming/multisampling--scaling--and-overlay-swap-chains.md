---
xxxxx: Xxxx xxxxx xxxxxxx xxx xxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxxxxx xxxx xxxxxx xxx xxxxxx xxxxxxxxx xx xxxxxx xxxxxxx, xxx xxx xxxxxxx xxxx xxxxxx (xxxx xxxxxxxxx) xx xxxxxxxx xxx xxxxxx xxxxxxx.
xx.xxxxxxx: YxYxYxYY-xxxY-xxxx-YYxx-xxxYxYxxYYxY
---

# Xxxx xxxxx xxxxxxx xxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxxxxx xxxxxx xxxx xxxxxx xxx xxxxxx xxxxxxxxx xx xxxxxx xxxxxxx, xxx xxx xxxxxxx xxxx xxxxxx (xxxx xxxxxxxxx) xx xxxxxxxx xxx xxxxxx xxxxxxx.

## Xxxx xxxxxx xx XxxxxxX YY.Y


XxxxxxYX YY.Y xxxxxx xxx xx xxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxx xxxx xxxxxx xxxx xxx xxxxxx xx xxxx xxx-xxxxxx (xxxxxxx) xxxxxxxxxxx, xxxxxxxx xxxxxx xxxx xxxxx. XxxxxxYX YY.Y xxxx xxxxxxxx XXXx xxx xxxxxxxxx xxxx xxxxxxxx xxxxxxxx xx xxxx xxx xxx xxxxxxx x XX xx xxxxxxx xxxx xxxxx xx xxxxxx xxxxxxxxxx. Xxxx xxxxxx xxxx xxxx xx xxxx XX xx xxxx xxxxxx xxxxxxxxxx xxxxx xxxxxxxxxxx x xxxx xxxxxxxxx, xxxxxxx xxxxxx xxx xxxx xxx xx xxxxxx xxxxxxx xxx xxxx XXX xxxxxxxx (xxxx xx YYYY xx YYYY). Xxxx xxxxxxx xxxxxxxx xxx xx xxx xxxxxxxxxxx xxxx xxxxxx.

XxxxxxYX YY.Y xxxx xxxxxxxxxx x xxx xxxxxxx xxx xxxxxxx xxxxxxx xxxx xxxx xxxxx xxxx xxxxxx. Xxx [Xxxxxx xxxxxxx xxxx XXXX Y.Y xxxx xxxxxx](reduce-latency-with-dxgi-1-3-swap-chains.md).

## Xxx xxxx xxxxx xxxxxxx


Xxxx xxxx xxxx xx xxxxxxx xx xxxxxxxxx xxxxxxxx - xx xxxxxxxx xxxxxxxxx xxx xxxxx xxxxxxx - xx xxx xx xxxxxxxxxx xx xxxxxx xxxx-xxxx xxxx xxxxxxx xx x xxxxx xxxxxxxxxx xxxx xxx xxxxxxx xx xxxxxxxx xxxxxxx xx. Xx xx xxxx, xxx xxxx xxxxx xxxx xx xxxx xxx xxxxxxxxx xxxx xxxxxxx xxxx xx xxxxxxx xxxx xxx xxxxxx xxxxxxxxxx, xx x xxxxxxxxx xx xxx xxxxxxxxx xxxx xx xxxx.

1.  Xxxxx, xxxxxx x xxxx xxxxx xx xxxx xxxxxx xxxxxxxxxx.

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
    swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // All Windows Store apps must use this SwapEffect.
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

2.  Xxxx, xxxxxx x xxxxxxxxx xx xxx xxxx xxxxx xx xxxxx xx xx xxxxxxx xxx xxxxxx xxxx xx x xxxxxxx xxxxxxxxxx.

    Xxx XX Xxxxxxxxxx Xxxx Xxxxxx xxxxxx xxxxxxxxxx x xxxxxxx xxxx xxxxx xx x xxxxxxxxxx:

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

3.  Xxxxxx x xxxxxxxx xx xxxxx xxx xxxxxxxxx xx xxx xxxx xxxxx.

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

4.  Xx XxxxxxYX xx xxxxx xxxx, xxx xxxxxxxx xxxxxxxxx xxxxx xx xx xxxxxxxx xx xxxxxxxxxx xxx xxx xxxxxx xxxxxx.

## Xxxxxx x xxxxxxxx xxxxxxx xxxx xxxxx xxx XX xxxxxxxx


Xxxx xxxxx xxxx xxxxx xxxxxxx, xxxxx xx xx xxxxxxxx xxxxxxxxxxxx xx xxxx xxx XX xx xxxx xxxxxx xxxx, xxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxx xx xxx. Xx xxxxxxx xxxx xxxxxxxx xxxxxxx xxx xxxxxxx xxxx xxxxxx, xxxx xxxxxxx xx xxxxxxxxxx xxxxxxxx xx xxxxxxxxx xxx XX xx xxxxxx xxxxxxxxxx xx x xxxx xxxxx xxxx'x xxxxxxxx xxxx xxx xxxx-xxxx xxxx xxxxxxx. Xxxx xxxx xxxx xxxxxxxxx xxxxxxx xxxx xx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxx xxxxxx - xx xxxxxx xx xxxx xxxx XXXX xxxxxxx.

Xxx xxx xxxxxxxxx xxxxx xx xxxxxx x xxxxxxxxxx xxxx xxxxx xxxx xxxx xxxxxxxx xxxxxxx xxxxxxxxxx. Xxxxx xxxxx xxx xxxxxxxxx xxxxx xxxxx xxxxxxxx x xxxx xxxxx xxx xxxx-xxxx xxxx xxxxxxx xx xxxxxxxxx xxxxx.

1.  Xxxxx, xxxxxxxxx xxxxxxx xxx XXXX xxxxxxx xxxxxxxx xxxxxxxx. Xxx xxx XXXX xxxxxx xxxxxxx xxxx xxx xxxx xxxxx:

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

    Xxx XXXX xxxxxxx xxxxxxxx xxxxxxxx xx xxx xxxxxx xxxxxxx xxxxxxx Xxxx xxx [**XxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dn280411).

    ```cpp
    m_overlaySupportExists = dxgiOutput2->SupportsOverlays() ? true : false;
    ```
    
    > **Xxxx**   Xx xxx XXXX xxxxxxx xxxxxxxx xxxxxxxx, xxxxxxxx xx xxx xxxx xxxx. Xx xxx xxxxxx xxxx xxx xxxxxxx xxxxxxxx, xxxxxxxxx xxxx xxxxxxxx xxxx xxxxxx xxxx xxx xx xxxxxxxxx. Xxxxxxx, xxxxxx xxx XX xx xxxxxxx xxxxxxxxxx xx xxx xxxx xxxx xxxxx xx xxxx-xxxx xxxx xxxxxxx.

     

2.  Xxxxxx xxx xxxxxxxxxx xxxx xxxxx xxxx [**XXXXXXxxxxxxY::XxxxxxXxxxXxxxxXxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh404559). Xxx xxxxxxxxx xxxxxxx xxxx xx xxx xx xxx [**XXXX\_XXXX\_XXXXX\_XXXXY**](https://msdn.microsoft.com/library/windows/desktop/hh404528) xxxxxxxx xx xxx *xXxxx* xxxxxxxxx:

    -   Xxxxxxx xxx [**XXXX\_XXXX\_XXXXX\_XXXX\_XXXXXXXXXX\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173076) xxxx xxxxx xxxx xx xxxxxxxx x xxxxxxxxxx xxxx xxxxx.
    -   Xxx xxx [**XXXX\_XXXXX\_XXXX\_XXXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/hh404496) xxxxx xxxx xxxx. Xxxxxxxxxx xxxx xxxxxx xxx xxxxxx xxxxxxxxxxxxx.
    -   Xxx xxx [**XXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/hh404526) xxxx. Xxxxxxxxxx xxxx xxxxxx xxxxxx xxx xx xxxxxx xxxxxxxxxx.

    ```cpp
     foregroundSwapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER;
     foregroundSwapChainDesc.Scaling = DXGI_SCALING_NONE;
     foregroundSwapChainDesc.AlphaMode = DXGI_ALPHA_MODE_PREMULTIPLIED; // Foreground swap chain alpha values must be premultiplied.
    ```

    > **Xxxx**   Xxx xxx [**XXXX\_XXXX\_XXXXX\_XXXX\_XXXXXXXXXX\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173076) xxxxx xxxxx xxxx xxx xxxx xxxxx xx xxxxxxx.

     ```cpp
    HRESULT hr = m_foregroundSwapChain->ResizeBuffers(
        2, // Double-buffered swap chain.
        static_cast<UINT>(m_d3dRenderTargetSize.Width),
        static_cast<UINT>(m_d3dRenderTargetSize.Height),
        DXGI_FORMAT_B8G8R8A8_UNORM,
        DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER // The FOREGROUND_LAYER flag cannot be removed with ResizeBuffers.
        );
    ```

3.  Xxxx xxx xxxx xxxxxx xxx xxxxx xxxx, xxxxxxxx xxx xxxxxxx xxxxx xxxxxxx xx Y xx xxxx xxx XXXX xxxxxxx xxx xxxx xx xxxxxxx xxxx xxxx xxxxxx xxxxxxxxxxxxxx (xxxxxx xxx xxxx XXxxx xxxxxxxx).

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

4.  Xxxxxxxxxx xxxx xxxxxx xxxxxx xxx xxxxxxxxxxxxx xxxxx. Xxxx xxxxx'x xxxxx xxxxxx xxx xxxxxxxx xx xx xxxxxxx xxxxxxxxxx xx xxx xxxxx xxxxx xxxxxx xxx xxxxx xx xxxxxxxxx. Xxx xxxxxxx, x YYY% xxxxx XXXX xxxxx xx YY% xxxxx xx xxx xx (Y.Y, Y.Y, Y.Y, Y.Y).

    Xxx xxxxx xxxxxxxxxxxxxxxxx xxxx xxx xx xxxx xx xxx xxxxxx-xxxxxx xxxxx xx xxxxxxxx xx xxx xxxxx xxxxx (xxx [**XXYXYYXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476349)) xxxx xxx [**XYXYY\_XXXXXX\_XXXXXX\_XXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476200) xxxxxxxxx'x **XxxXxxxx** xxxxx xxx xx **XYXYY\_XXX\_XXXXX**. Xxxxxx xxxx xxx-xxxxxxxxxx xxxxx xxxxxx xxx xxxx xx xxxx.

    Xx xxx xxxxx xxxxxxxxxxxxxxxxx xxxx xx xxx xxxx, xxxxxx xx xxx xxxxxxxxxx xxxx xxxxx xxxx xx xxxxxxxx xxxx xxxxxxxx.

5.  Xxxxxxxxx xx xxxxxxx xxx xxxxxxxxxx xxxx xxxxx xxx xxxxxxx, xxx XxxxxxYX xxxxxxx xxxxxxx xxx XX xxxxxxxx xxxxx xxxx xx xxxxxxxxxx xxxx xxx xxxxxxxxxx xxxx xxxxx.

    Xxxxxxxx xxxxxx xxxxxx xxxxx:

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

    Xxxxxxxx xxx XxxxxxYX xxxxxxx xxxxxxx:

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

6.  Xxxxxxx xxx xxxxxxxxxx xxxx xxxxx xxxxxxxx xxxx xxx xxxxxx xxxx xxxxx xxxx xxx xxxx-xxxx xxxx xxxxxxx. Xxxxx xxxxx xxxxxxx xxx xxx xx Y xxx xxxx xxxx xxxxxx, XXXX xxx xxxxxxx xxxx xxxx xxxxxx xxx xxxx XXxxx xxxxxxxx.

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

 

 




<!--HONumber=Mar16_HO1-->
