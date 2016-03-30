---
xxxxx: Xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxx xxxx XxxxxxYX.
xx.xxxxxxx: YxxYYYxY-YYxx-YxxY-YxYY-YYxxYYxYYYYY
---

# <span id="dev_gaming.multisampling__multi-sample_anti_aliasing__in_windows_store_apps">
            </span> Xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxx xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxx xxxx XxxxxxYX. Xxxxxxxxxxxxx, xxxx xxxxx xx xxxxx-xxxxxx xxxxxxxxxxxx, xx x xxxxxxxx xxxxxxxxx xxxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxxx xxxxx. Xx xxxxx xx xxxxxxx xxxx xxxxxx xxxx xxx xxxxxxxx xx xxx xxxxx xxxxxx xxxxxx, xxxx xxxxxxxxx xxxxxx xx xxxxxxxx xxx xxxxxxxxxx xx x "xxxxxxx" xxxx xx xxxxxxx xxxxxx. Xxx x xxxxxxxx xxxxxxxxxxx xx xxx xxxxxxxxxxxxx xxxxxxxx xxxxx xx XxxxxxYX, xxx [Xxxxxxxxxxx Xxxx-Xxxxxxxx Xxxxxxxxxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/desktop/cc627092#Multisample).

## Xxxxxxxxxxxxx xxx xxx xxxx xxxxx xxxx xxxxx


XXX xxxx xxxx xxx XxxxxxX xxxx xxx xxxx xxxxx xxxx xxxxxx. Xxxx xxxxx xxxx xxxxxx xxx'x xxxxxxx xxxxxxxxxxxxx xxxxxxxx, xxx xxxxxxxxxxxxx xxx xxxxx xx xxxxxxx xx x xxxxxxxxx xxx xx xxxxxxxxx xxx xxxxx xx x xxxxxxxxxxxx xxxxxx xxxxxx xxxx, xxx xxxx xxxxxxxxx xxx xxxxxxxxxxxx xxxxxx xxxxxx xx xxx xxxx xxxxxx xxxxxx xxxxxxxxxx. Xxxx xxxxxxx xxxxxxxx xxx xxxxx xxxxxxxx xx xxx xxxxxxxxxxxxx xx xxxx XXX xxx.

### Xxx xx xxx xxxxxxxxxxxxx

XxxxxxYX xxxxxxx xxxxxx xxxxxxxxx xxxxxxx xxx xxxxxxxx, xxxxxxx xxxxxx xxxxx xxxxxxxxxxxx, xxx xxxxxxxxx xxxxxxx xxxxxx xxxxxxx xxxx xx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxxx. Xxxxxxxx xxxxxxx xxxxx xxxxxxx x xxxxx xxxxx xx xxxxxxx xxx xxxxxx xxxxxx xxxx xxx xxxxxxx xxxxxxxx. Xxxxxxxxxxxxx xxxxxxx xxx xx xxxxxxxxxx xx xxx-xxxx xx xxxxxxxx xxxxxxx xxxxxxx xxx xxxxxxxxxxxxx xxxx xxxxxxxx XXXX xxxxxxx, xxx xxxx xxxxxxxx xxx xxxxxx xxxxxx xxx xxx xxx xxxx xxxx xxxxxxxxx xxxxxx.

1.  Xxxx [**XXYXYYXxxxxx::XxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476497) xx xxxx xxx xxxxx XXXX xxxxxxx xxx xx xxxx xxxx xxxxxxxxxxxxx. Xxxxxx xxx xxxxxx xxxxxx xxxxxxx xxxx xxxx xxx xxx. Xxxx xxx xxxxxx xxxxxx xxx xxxxxxx xxxxxx xxxx xxx xxx xxxx xxxxxx, xx xxxxx xxx xxxx [**XYXYY\_XXXXXX\_XXXXXXX\_XXXXXXXXXXX\_XXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476134) xxx **XYXYY\_XXXXXX\_XXXXXXX\_XXXXXXXXXXX\_XXXXXXX**.

    **Xxxxxxx xxxxx Y:  ** Xxxxxxxx xxxxxxx xxxxx Y xxxxxxx [xxxxxxxxx xxxxxxx xxx xxxxxxxxxxxx xxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ff471324#MultiSample_RenderTarget), xxxxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxxxx xxxxxxx xxxxxxx. Xx xxxx xxxxx xx xxxxxxxxx xxxxxx xxxxxx xx xxx xxx xxxxxxxxxxxxx xxxxxxxxx xxxxxxxxx xx xxxx xxxxx.

    Xxx xxxxxxxxx xxxx xxxxxx xxxxxxxxxxxxx xxxxxxx xxx xxx xxx XXXX\_XXXXXX xxxxxx:

    ```cpp
    // Determine the format support for multisampling.
    for (UINT i = 1; i < DXGI_FORMAT_MAX; i++)
    {
        DXGI_FORMAT inFormat = safe_cast<DXGI_FORMAT>(i);
        UINT formatSupport = 0;
        HRESULT hr = m_d3dDevice->CheckFormatSupport(inFormat, &formatSupport);

        if ((formatSupport & D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE) &&
            (formatSupport & D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET)
            )
        {
            m_supportInfo->SetFormatSupport(i, true);
        }
        else
        {
            m_supportInfo->SetFormatSupport(i, false);
        }
    }
    ```

2.  Xxx xxxx xxxxxxxxx xxxxxx, xxxxx xxx xxxxxx xxxxx xxxxxxx xx xxxxxxx [**XXYXYYXxxxxx::XxxxxXxxxxxxxxxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476499).

    Xxx xxxxxxxxx xxxx xxxxxx xxxxxx xxxx xxxxxxx xxx xxxxxxxxx XXXX xxxxxxx:

    ```cpp
    // Find available sample sizes for each supported format.
    for (unsigned int i = 0; i < DXGI_FORMAT_MAX; i++)
    {
        for (unsigned int j = 1; j < MAX_SAMPLES_CHECK; j++)
        {
            UINT numQualityFlags;

            HRESULT test = m_d3dDevice->CheckMultisampleQualityLevels(
                (DXGI_FORMAT) i,
                j,
                &numQualityFlags
                );

            if (SUCCEEDED(test) && (numQualityFlags > 0))
            {
                m_supportInfo->SetSampleSize(i, j, 1);
                m_supportInfo->SetQualityFlagsAt(i, j, numQualityFlags);
            }
        }
    }
    ```

    > **Xxxx**   Xxx [**XXYXYYXxxxxxY::XxxxxXxxxxxxxxxxXxxxxxxXxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/dn280494) xxxxxxx xx xxx xxxx xx xxxxx xxxxxxxxxxx xxxxxxx xxx xxxxx xxxxxxxx xxxxxxx.

     

3.  Xxxxxx x xxxxxx xxx xxxxxx xxxxxx xxxx xxxx xxx xxxxxxx xxxxxx xxxxx. Xxx xxx xxxx XXXX\_XXXXXX, xxxxx, xxx xxxxxx xx xxx xxxx xxxxx, xxx xxxxxxx x xxxxxx xxxxx xxxxxxx xxxx Y xxx xxx x xxxxxxxxxxxx xxxxxxx xxxxxxxxx (**XYXYY\_XXX\_XXXXXXXXX\_XXXXXXXYXXX** xxx xxxxxxx). Xx xxxxxxxxx, xxx xxx xx-xxxxxx xxx xxxx xxxxx xxxx xxx xxxxxxxx xxxx xxx xxxxxxx xxx xxxxxxxxxxxxx.

    Xxx xxxxxxxxx xxxx xxxxxxx x xxxxxxxxxxxx xxxxxx xxxxxx:

    ```cpp
    float widthMulti = m_d3dRenderTargetSize.Width;
    float heightMulti = m_d3dRenderTargetSize.Height;

    D3D11_TEXTURE2D_DESC offScreenSurfaceDesc;
    ZeroMemory(&offScreenSurfaceDesc, sizeof(D3D11_TEXTURE2D_DESC));

    offScreenSurfaceDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
    offScreenSurfaceDesc.Width = static_cast<UINT>(widthMulti);
    offScreenSurfaceDesc.Height = static_cast<UINT>(heightMulti);
    offScreenSurfaceDesc.BindFlags = D3D11_BIND_RENDER_TARGET;
    offScreenSurfaceDesc.MipLevels = 1;
    offScreenSurfaceDesc.ArraySize = 1;
    offScreenSurfaceDesc.SampleDesc.Count = m_sampleSize;
    offScreenSurfaceDesc.SampleDesc.Quality = m_qualityFlags;

    // Create a surface that's multisampled.
    DX::ThrowIfFailed(
        m_d3dDevice->CreateTexture2D(
        &offScreenSurfaceDesc,
        nullptr,
        &m_offScreenSurface)
        );

    // Create a render target view. 
    CD3D11_RENDER_TARGET_VIEW_DESC renderTargetViewDesc(D3D11_RTV_DIMENSION_TEXTURE2DMS);
    DX::ThrowIfFailed(
        m_d3dDevice->CreateRenderTargetView(
        m_offScreenSurface.Get(),
        &renderTargetViewDesc,
        &m_d3dRenderTargetView
        )
        );
    ```

4.  Xxx xxxxx xxxxxx xxxx xxxx xxx xxxx xxxxx, xxxxxx, xxxxxx xxxxx, xxx xxxxxxx xxxxxxxxx xx xxxxx xxx xxxxxxxxxxxx xxxxxx xxxxxx.

    Xxx xxxxxxxxx xxxx xxxxxxx x xxxxxxxxxxxx xxxxx xxxxxx:

    ```cpp
    // Create a depth stencil view for use with 3D rendering if needed.
    CD3D11_TEXTURE2D_DESC depthStencilDesc(
        DXGI_FORMAT_D24_UNORM_S8_UINT,
        static_cast<UINT>(widthMulti),
        static_cast<UINT>(heightMulti),
        1, // This depth stencil view has only one texture.
        1, // Use a single mipmap level.
        D3D11_BIND_DEPTH_STENCIL,
        D3D11_USAGE_DEFAULT,
        0,
        m_sampleSize,
        m_qualityFlags
        );

    ComPtr<ID3D11Texture2D> depthStencil;
    DX::ThrowIfFailed(
        m_d3dDevice->CreateTexture2D(
        &depthStencilDesc,
        nullptr,
        &depthStencil
        )
        );

    CD3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc(D3D11_DSV_DIMENSION_TEXTURE2DMS);
    DX::ThrowIfFailed(
        m_d3dDevice->CreateDepthStencilView(
        depthStencil.Get(),
        &depthStencilViewDesc,
        &m_d3dDepthStencilView
        )
        );
    ```

5.  Xxx xx x xxxx xxxx xx xxxxxx xxx xxxxxxxx, xxxxxxx xxx xxxxxxxx xxxxx xxx xxxxxx xxxx xxxx xxxxx xxx xxxxxx xxxxxx.

    Xxx xxxxxxxxx xxxx xxxxxxx x xxxxxxxx:

    ```cpp
    // Set the 3D rendering viewport to target the entire window.
    m_screenViewport = CD3D11_VIEWPORT(
        0.0f,
        0.0f,
        widthMulti / m_scalingFactor,
        heightMulti / m_scalingFactor
        );

    m_d3dContext->RSSetViewports(1, &m_screenViewport);
    ```

6.  Xxxxxx xxxx xxxxx xx xxx xxxxxxxxxxxx xxxxxx xxxxxx. Xxxx xxxxxxxxx xx xxxxxxxx, xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476474) xxxxxx xxxxxxxxxx xxx xxxxx. Xxxx xxxxxxxxx XxxxxxYX xx xxxxxx xxx xxxxxxxxxxxxx xxxxxxxxx, xxxxxxxxx xxx xxxxx xx xxxx xxxxx xxx xxxxxxx xxx xxxxxxx xxx xxxxxx xx xxx xxxx xxxxxx. Xxx xxxx xxxxxx xxxx xxxxxxxx xxx xxxxx xxxx-xxxxxxx xxxxx xxx xxx xx xxxxxxxxx.

    Xxx xxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxx xxxxxxxxxx xxx xxxxx:

    ```cpp
    if (m_sampleSize > 1)
    {
        unsigned int sub = D3D11CalcSubresource(0, 0, 1);

        m_d3dContext->ResolveSubresource(
            m_backBuffer.Get(),
            sub,
            m_offScreenSurface.Get(),
            sub,
            DXGI_FORMAT_B8G8R8A8_UNORM
            );
    }

    // The first argument instructs DXGI to block until VSync, putting the application
    // to sleep until the next VSync. This ensures that we don't waste any cycles rendering
    // frames that will never be displayed to the screen.
    hr = m_swapChain->Present(1, 0);
    ```

 

 




<!--HONumber=Mar16_HO1-->
