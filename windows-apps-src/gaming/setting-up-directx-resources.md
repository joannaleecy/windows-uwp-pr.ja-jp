---
xxxxx: Xxx xx XxxxxxX xxxxxxxxx xxx xxxxxxx xx xxxxx
xxxxxxxxxxx: Xxxx, xx xxxx xxx xxx xx xxxxxx x XxxxxxYX xxxxxx, xxxx xxxxx, xxx xxxxxx-xxxxxx xxxx, xxx xxx xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxxx.
xx.xxxxxxx: xYYxYYxx-YYYY-Yxxx-YYxY-xxYYxYxYxYYY
---

# Xxx xx XxxxxxX xxxxxxxxx xxx xxxxxxx xx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx, xx xxxx xxx xxx xx xxxxxx x XxxxxxYX xxxxxx, xxxx xxxxx, xxx xxxxxx-xxxxxx xxxx, xxx xxx xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxxx.

**Xxxxxxxxx:** Xx xxx xx XxxxxxX xxxxxxxxx xx x X++ Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxx xx xxxxxxx x xxxxx xxxxx.

## Xxxxxxxxxxxxx


Xx xxxxxx xxxx xxx xxx xxxxxxxx xxxx X++. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxxxxx.

**Xxxx xx xxxxxxxx:** YY xxxxxxx.

## Xxxxxxxxxxxx

### Y. Xxxxxxxxx XxxxxxYX xxxxxxxxx xxxxxxxxx xxxx XxxXxx

Xx xxxxxxx XxxxxxYX xxxxxxxxx xxxxxxxxx xxxx xxx XxxXxx [xxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh279674.aspx) xxxxxxxx xxxx xxx Xxxxxxx Xxxxxxx X++ Xxxxxxxx Xxxxxxx (XXX), xx xx xxx xxxxxx xxx xxxxxxxx xx xxxxx xxxxxxxxx xx xx xxxxxxxxx xxxx xxxxxx. Xx xxx xxxx xxx xxxxx xxxxxxxxx xx xxxxxx xxx [**XxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) xxx xxx xxxxxxx. Xxx xxxxxxx:

```cpp
    ComPtr<ID3D11RenderTargetView> m_renderTargetView;
    m_d3dDeviceContext->OMSetRenderTargets(
        1,
        m_renderTargetView.GetAddressOf(),
        nullptr // Use no depth stencil.
        );
```

Xx xxx xxxxxxx [**XXYXYYXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476582) xxxx XxxXxx, xxx xxx xxxx xxx XxxXxx’x **XxxXxxxxxxXx** xxxxxx xx xxx xxx xxxxxxx xx xxx xxxxxxx xx **XXYXYYXxxxxxXxxxxxXxxx** (\*\*XXYXYYXxxxxxXxxxxxXxxx) xx xxxx xx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476464). **XXXxxXxxxxxXxxxxxx** xxxxx xxx xxxxxx xxxxxx xx xxx [xxxxxx-xxxxxx xxxxx](https://msdn.microsoft.com/library/windows/desktop/bb205120) xx xxxxxxx xxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxx.

Xxxxx xxx xxxxxx xxx xx xxxxxxx, xx xxxxxxxxxxx xxx xxxxx, xxx xx xxxx xxxxx xx xxx.

### Y. Xxxxxxxx xxx XxxxxxYX xxxxxx

Xx xxx xxx XxxxxxYX XXX xx xxxxxx x xxxxx, xx xxxx xxxxx xxxxxx x XxxxxxYX xxxxxx xxxx xxxxxxxxxx xxx xxxxxxx xxxxxxx. Xx xxxxxx xxx XxxxxxYX xxxxxx, xx xxxx xxx [**XYXYYXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476082) xxxxxxxx. Xx xxxxxxx xxxxxx Y.Y xxxxxxx YY.Y xx xxx xxxxx xx [**XYX\_XXXXXXX\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476329) xxxxxx. XxxxxxYX xxxxx xxx xxxxx xx xxxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxx xxxxxxx xxxxx. Xx, xx xxx xxx xxxxxxx xxxxxxx xxxxx xxxxxxxxx, xx xxxx xxx **XYX\_XXXXXXX\_XXXXX** xxxxx xxxxxxx xxxx xxxxxxx xx xxxxxx. Xx xxxx xxx [**XYXYY\_XXXXXX\_XXXXXX\_XXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_BGRA_SUPPORT) xxxx xx xxx *Xxxxx* xxxxxxxxx xx xxxx XxxxxxYX xxxxxxxxx xxxxxxxxxxxx xxxx XxxxxxYX. Xx xx xxx xxx xxxxx xxxxx, xx xxxx xxxx xxx [**XYXYY\_XXXXXX\_XXXXXX\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_DEBUG) xxxx. Xxx xxxx xxxx xxxxx xxxxxxxxx xxxx, xxx [Xxxxx xxx xxxxx xxxxx xx xxxxx xxxx](https://msdn.microsoft.com/library/windows/desktop/jj200584).

Xx xxxxxx xxx XxxxxxYX YY.Y xxxxxx ([**XXYXYYXxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404575)) xxx xxxxxx xxxxxxx ([**XXYXYYXxxxxxXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) xx xxxxxxxx xxx XxxxxxYX YY xxxxxx xxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxxx [**XYXYYXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476082).

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

### Y. Xxxxxxxx xxx xxxx xxxxx

Xxxx, xx xxxxxx x xxxx xxxxx xxxx xxx xxxxxx xxxx xxx xxxxxxxxx xxx xxxxxxx. Xx xxxxxxx xxx xxxxxxxxxx x [**XXXX\_XXXX\_XXXXX\_XXXXY**](https://msdn.microsoft.com/library/windows/desktop/hh404528) xxxxxxxxx xx xxxxxxxx xxx xxxx xxxxx. Xxxx, xx xxx xx xxx xxxx xxxxx xx xxxx-xxxxx (xxxx xx, x xxxx xxxxx xxxx xxx xxx [**XXXX\_XXXX\_XXXXXX\_XXXX\_XXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173077#DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL) xxxxx xxx xx xxx **XxxxXxxxxx** xxxxxx) xxx xxx xxx **Xxxxxx** xxxxxx xx [**XXXX\_XXXXXX\_XYXYXYXY\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM). Xx xxx xxx **Xxxxx** xxxxxx xx xxx [**XXXX\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173072) xxxxxxxxx xxxx xxx **XxxxxxXxxx** xxxxxx xxxxxxxxx xx Y xxx xxx **Xxxxxxx** xxxxxx xx **XXXX\_XXXXXX\_XXXX** xx xxxx xxxxxxx xxxx-xxxxx xxxxx’x xxxxxxx xxxxxxxx xxxxxx xxxxxxxxxxxx (XXXX). Xx xxx xxx **XxxxxxXxxxx** xxxxxx xx Y xx xxx xxxx xxxxx xxx xxx x xxxxx xxxxxx xx xxxxxxx xx xxx xxxxxxx xxxxxx xxx x xxxx xxxxxx xxxx xxxxxx xx xxx xxxxxx xxxxxx.

Xx xxxxxx xxx xxxxxxxxxx XXXX xxxxxx xx xxxxxxxx xxx XxxxxxYX YY.Y xxxxxx. Xx xxxxxxxx xxxxx xxxxxxxxxxx, xxxxx xx xxxxxxxxx xx xx xx xxxxxxx-xxxxxxx xxxxxxx xxxx xx xxxxxxx xxx xxxxxxx, xx xxxx xxx [**XXXXXXxxxxxY::XxxXxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff471334) xxxxxx xxxx Y xx xxx xxxxxxx xxxxxx xx xxxx xxxxxx xxxxxx xxxx XXXX xxx xxxxx. Xxxx xxxxxxx xxxx xxx xxx xx xxxxxxxx xxxx xxxxx xxx xxxxxxxx xxxxx.

Xx xxxxxxx xxxxxx xxx xxxx xxxxx, xx xxxx xx xxx xxx xxxxxx xxxxxxx xxxx xxx XXXX xxxxxx. Xx xxxx [**XXXXXXxxxxx::XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174531) xx xxx xxx xxxxxxx xxx xxx xxxxxx, xxx xxxx xxxx [**XXXXXXxxxxx::XxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174542) xx xxx xxxxxxx xx xxx xxx xxxxxx xxxxxxx ([**XXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404556)). Xx xxxxxx xxx xxxx xxxxx, xx xxxx [**XXXXXXxxxxxxY::XxxxxxXxxxXxxxxXxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh404559) xxxx xxx xxxx-xxxxx xxxxxxxxxx xxx xxx xxx’x xxxx xxxxxx.

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

### Y. Xxxxxxxx xxx xxxxxx-xxxxxx xxxx

Xx xxxxxx xxxxxxxx xx xxx xxxxxx, xx xxxx xx xxxxxx x xxxxxx-xxxxxx xxxx. Xx xxxx [**XXXXXXxxxXxxxx::XxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174570) xx xxx xxx xxxx xxxxx’x xxxx xxxxxx xx xxx xxxx xx xxxxxx xxx xxxxxx-xxxxxx xxxx. Xx xxxxxxx xxx xxxx xxxxxx xx x YX xxxxxxx ([**XXYXYYXxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635)). Xx xxxxxx xxx xxxxxx-xxxxxx xxxx, xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476517) xxxx xxx xxxx xxxxx’x xxxx xxxxxx. Xx xxxx xxxxxxx xx xxxx xx xxx xxxxxx xxxx xxxxxx xx xxxxxxxxxx xxx xxxx xxxx ([**XYXYY\_XXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476260)) xx xxx xxxx xxxx xx xxx xxxx xxxxx'x xxxx xxxxxx. Xx xxx xxx xxxx xxxx xx x xxxx xx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476480) xx xxxx xxx xxxx xxxx xx xxx [xxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/desktop/bb205125) xx xxx xxxxxxxx. Xxx xxxxxxxxxx xxxxx xxxxxxxx xxxxxx xxxxxxxxxxx xxxx x xxxxxx xxxxx. Xx xxxx xxxx, xx xxx'x xxxxxxx x xxxxxxxxxx xxxxxxx xx xxx xxxx xxxxxxxxxx x xxxxx xxxxx.

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

### Y. Xxxxxxxxxx xxx xxxxxxxx xxxxx

Xx xxxxx xx xxxxxxx xxxx xx xxxxxxxxxxx xxxxxx xxx xxxxxxx xxx xxxxx.

Xx xxxx xxxx, xx xxxx:

1.  [
            **XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476464) xx xxxxxxx xxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxx.
2.  [
            **XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476388) xx xxxxx xxx xxxxxx xxxxxx xx x xxxxx xxxxx.
3.  [
            **XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576) xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxx.

Xxxxxxx xx xxxxxxxxxx xxx xxx xxxxxxx xxxxx xxxxxxx xx Y, Xxxxxxx xxxxxxxxx xxxxx xxxx xxx xxxxxx xxxx xx xxx xxxxxx xxxxxxx xxxx, xxxxxxxxx xxxxxx YY Xx. Xxxxxxx xxxxx xxxx xxx xxxxxx xxxx xx xxxxxx xxx xxx xxxxx xxxx xxx xxx xxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576). Xxxxxxx xxxxx xxx xxx xxxxx xxxxx xxx xxxxxx xx xxxxxxxxx.

```cpp
        // Enter the render loop.  Note that Windows Store apps should never exit.
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

### Y. Xxxxxxxx xxx xxx xxxxxx xxx xxx xxxx xxxxx’x xxxxxx

Xx xxx xxxx xx xxx xxx xxxxxx xxxxxxx, xxx xxx xxxx xxxxxx xxx xxxx xxxxx’x xxxxxxx, xxxxxxxx xxx xxxxxx-xxxxxx xxxx, xxx xxxx xxxxxxx xxx xxxxxxx xxxxxxxx xxxxx. Xx xxxxxx xxx xxxx xxxxx’x xxxxxxx, xx xxxx [**XXXXXXxxxXxxxx::XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174577). Xx xxxx xxxx, xx xxxxx xxx xxxxxx xx xxxxxxx xxx xxx xxxxxx xx xxx xxxxxxx xxxxxxxxx (xxx *XxxxxxXxxxx* xxxxxxxxx xx xxx xxx xxx *XxxXxxxxx* xxxxxxxxx xx [**XXXX\_XXXXXX\_XYXYXYXY\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM)). Xx xxxx xxx xxxx xx xxx xxxx xxxxx’x xxxx xxxxxx xxx xxxx xxxx xx xxx xxxxxxx xxxxxx. Xxxxx xx xxxxxx xxx xxxx xxxxx’x xxxxxxx, xx xxxxxx xxx xxx xxxxxx xxxxxx xxx xxxxxxx xxx xxx xxxxxxxx xxxxx xxxxxxxxx xx xxxx xx xxxxxxxxxxx xxx xxx.

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

## Xxxxxxx xxx xxxx xxxxx


Xx xxxxxxx x XxxxxxYX xxxxxx, xxxx xxxxx, xxx xxxxxx-xxxxxx xxxx, xxx xxxxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxxx.

Xxxx, xx xxxx xxxx x xxxxxxxx xx xxx xxxxxxx.

[Xxxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx](creating-shaders-and-drawing-primitives.md)

 

 




<!--HONumber=Mar16_HO1-->
