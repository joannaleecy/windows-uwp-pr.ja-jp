---
xxxxx: Xxxxxx xxxxx xxxxxx xxxxxx xxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx XxxxxxYX xxxxxx xxxxxxxxx xxxxxxxxx xx xxxxxxx xxxxx xxxxxxx xxx xxxxxx xxxxxxx.
xx.xxxxxxx: YYxYYYYx-Yxxx-YYxY-YYxY-xxxxYYYYYYYY
---

# Xxxxxx xxxxx xxxxxx xxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxx xxx xx xxxxxx xxx XxxxxxYX xxxxxx xxxxxxxxx xxxxxxxxx xx xxxxxxx xxxxx xxxxxxx xxx xxxxxx xxxxxxx. Xxxx Y xx [Xxxxxxxxxxx: Xxxxxxxxx xxxxxx xxxxxxx xxxxx xxxxx xxxxxxx xx XxxxxxYX YY](implementing-depth-buffers-for-shadow-mapping.md).

## Xxxxxxxxx xxx'xx xxxx


Xxxxxxxxx x xxxxx xxx xxx xxxxxx xxxxxxx xxxxxxxx xxx xxxxxxxxx XxxxxxYX xxxxxx-xxxxxxxxx xxxxxxxxx:

-   X xxxxxxxx (xxxxxx) xxx xxx xxxxx xxx
-   X xxxxx xxxxxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx xxx xxxxxxxx
-   X xxxxxxxxxx xxxxxxx xxxxx xxxxxx
-   Xxxxxxxx xxxxxxx xxx xxxxx XXX xxxxxxxx
-   X xxxxxxxx xxx xxxxxxxxx xxx xxxxxx xxx (xxxxxxxxx x xxxxxx xxxxxxxx)
-   X xxxxxxxxx xxxxx xxxxxx xx xxxxxx xxxxx xxxx xxxxxxx
-   Xxx xxxx xxxx xxxx x xxxxxxxxx xxxxx xxxxxx xx xxxxxx xxxx xx xxxx xxxx xxxxxxx, xx xxx xxx'x xxxxxxx xxx xxx.

Xxxx xxxx xxxxxxxx xx xxxxx xxxxxxxxx xxxxx xx xx xxxxxxxx xx x xxxxxx-xxxxxxxxx xxxxxxxx xxxxxxxx xxxxxxx, xxxx xxx xxxx xxxxxxxx xxx xxxxxxxx xxxx xx (xxx xxxxxxx) x xxx xxxxxx xxxxxx xx xxxxxxxxx, xx xxx xxxx xxxxx xxxx xxx xx x xxxxxxx xxxxxxxx xx x xxxxxxxxx xxxxxxxx xxxxxxx.

## Xxxxx xxxxxxx xxxxxxx


Xxxxxx xxxxxxxx xxx xxxxx xxx, xxxx xxx [**XxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476497) xxxxxx xx xxx XxxxxxYX xxxxxx, xxxxxxx **XYXYY\_XXXXXXX\_XYXY\_XXXXXX\_XXXXXXX**, xxx xxxxxxx x [**XYXYY\_XXXXXXX\_XXXX\_XYXY\_XXXXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/jj247569) xxxxxxxxx.

```cpp
D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT isD3D9ShadowSupported;
ZeroMemory(&isD3D9ShadowSupported, sizeof(isD3D9ShadowSupported));
pD3DDevice->CheckFeatureSupport(
    D3D11_FEATURE_D3D9_SHADOW_SUPPORT,
    &isD3D9ShadowSupported,
    sizeof(D3D11_FEATURE_D3D9_SHADOW_SUPPORT)
    );

if (isD3D9ShadowSupported.SupportsDepthAsTextureWithLessEqualComparisonFilter)
{
    // Init shadow map resources

```

Xx xxxx xxxxxxx xx xxx xxxxxxxxx, xx xxx xxx xx xxxx xxxxxxx xxxxxxxx xxx xxxxxx xxxxx Y xxxxx Y\_x xxxx xxxx xxxxxx xxxxxxxxxx xxxxxxxxx. Xx xxxx xxxxx, xxxx xx xxxxxxx xxx xxxx xxxxxxx xxxxx xxxx xxx XXX xx x xxxxxx xxxxxx xxxx x xxxxxx xxxx xxx'x xxxxxxx xx xxxxxxx xx xxxxx XXXX Y.Y. Xx xxx xxxxxx xxxxxxxx xx xxxxx xxxxxxx xxxxx YY\_Y xxxx xxx xxx xxxx x xxxxxx xxxxxxxxxx xxxxxx xxxxxxxx xxx xxxxxx xxxxx Y\_Y xxxxxxx.

## Xxxxxx xxxxx xxxxxx


Xxxxx, xxx xxxxxxxx xxx xxxxx xxx xxxx x xxxxxx-xxxxxxxxx xxxxx xxxxxx. Xxx xx xxxxxxxx xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxx. Xx xxx xxxxxxxx xxxxxxxx xxxxx, xxx xxxxxxx xxx xx xxx xxxxxx xxxxxx xx x xxxxxx xxxx xxx xxxxxxxx xxxxx'x xxxxxxx, xxx x xxxxx-xxxxxxxxx xxxxxx xxx xxxxxx xxxxxxxxxx xx xxxxx.

Xxxx xxxx xx xxxxxxxx xx xxx xxxx xxxx x xxx-xxxxxxxxx xxxxx xxxxxx, xxx xxxxxxx xxxx xxxxxxxxx xx xxxxxx-xxxxxxxxxx XxxxxxYX xxxxxxx xxxxx Y\_Y xxxxxxx.

```cpp
D3D11_TEXTURE2D_DESC shadowMapDesc;
ZeroMemory(&shadowMapDesc, sizeof(D3D11_TEXTURE2D_DESC));
shadowMapDesc.Format = DXGI_FORMAT_R24G8_TYPELESS;
shadowMapDesc.MipLevels = 1;
shadowMapDesc.ArraySize = 1;
shadowMapDesc.SampleDesc.Count = 1;
shadowMapDesc.BindFlags = D3D11_BIND_SHADER_RESOURCE | D3D11_BIND_DEPTH_STENCIL;
shadowMapDesc.Height = static_cast<UINT>(m_shadowMapDimension);
shadowMapDesc.Width = static_cast<UINT>(m_shadowMapDimension);

HRESULT hr = pD3DDevice->CreateTexture2D(
    &shadowMapDesc,
    nullptr,
    &m_shadowMap
    );
```

Xxxx xxxxxx xxx xxxxxxxx xxxxx. Xxx xxx xxx xxxxx xx xxxx xx xxx xxxxx xxxxxxx xxxx xxx xxx xxx xxxxxx xx Y xx xxx xxxxxx xxxxxxxx xxxx. Xxxx xxxx x xxxxxxx xxxxxxxxx xx XXXXXXXYX, xxx xxxx xxxx xx xxx x xxxxxxxx [**XXXX\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173059).

```cpp
D3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc;
ZeroMemory(&depthStencilViewDesc, sizeof(D3D11_DEPTH_STENCIL_VIEW_DESC));
depthStencilViewDesc.Format = DXGI_FORMAT_D24_UNORM_S8_UINT;
depthStencilViewDesc.ViewDimension = D3D11_DSV_DIMENSION_TEXTURE2D;
depthStencilViewDesc.Texture2D.MipSlice = 0;

D3D11_SHADER_RESOURCE_VIEW_DESC shaderResourceViewDesc;
ZeroMemory(&shaderResourceViewDesc, sizeof(D3D11_SHADER_RESOURCE_VIEW_DESC));
shaderResourceViewDesc.ViewDimension = D3D11_SRV_DIMENSION_TEXTURE2D;
shaderResourceViewDesc.Format = DXGI_FORMAT_R24_UNORM_X8_TYPELESS;
shaderResourceViewDesc.Texture2D.MipLevels = 1;

hr = pD3DDevice->CreateDepthStencilView(
    m_shadowMap.Get(),
    &depthStencilViewDesc,
    &m_shadowDepthView
    );

hr = pD3DDevice->CreateShaderResourceView(
    m_shadowMap.Get(),
    &shaderResourceViewDesc,
    &m_shadowResourceView
    );
```

## Xxxxxx xxxxxxxxxx xxxxx


Xxx xxxxxx xxx xxxxxxxxxx xxxxxxx xxxxx xxxxxx. Xxxxxxx xxxxx Y\_Y xxxx xxxxxxxx XYXYY\_XXXXXXXXXX\_XXXX\_XXXXX. Xxxxxxxxx xxxxxxx xxx xxxxxxxxx xxxx xx [Xxxxxxxxxx xxxxxx xxxx xx x xxxxx xx xxxxxxxx](target-a-range-of-hardware.md) - xx xxx xxx xxxx xxxx xxxxx xxxxxxxxx xxx xxxxxx xxxxxx xxxx.

Xxxx xxxx xxx xxx xxxxxxx xxx XYXYY\_XXXXXXX\_XXXXXXX\_XXXXXX xxxxxxx xxxx xxx xx xxxx xxxx xx xxxxxxx xxxxx Y\_Y xxxxxxx. Xxxx xxxxxxx xx xxxxx xxxxxxx xxxx xxx'x xxxx xxxxxxx xxx xxxxx xx xx xxx xxxxx'x xxxx xxxxxxx xxxxxx xxxxx xxx xxxxx xxxx. Xx xxxxxxxxxx Y xx Y xxx xxxx xxxxxx, xxx xxx xxxxxxx xxxxxxx xxxxxx xxxxxxx xxx xxxxx'x xxxx xxxxxxx xxxx xx xxxx xxx xxxxx xxxx, xxx xxxxxxxxx xxxxxxx xxxx xxx xxx xx xx xxxxxx.

Xx xxxxxxx xxxxx Y\_Y, xxx xxxxxxxxx xxxxxxxx xxxxxx xxxx xx xxx: **XxxXXX** xx xxx xx xxxx, **XxxXXX** xx xxx xx **XYXYY\_XXXXXYY\_XXX**, xxx **XxxXxxxxxxxxx** xx xxx xx xxxx.

```cpp
D3D11_SAMPLER_DESC comparisonSamplerDesc;
ZeroMemory(&comparisonSamplerDesc, sizeof(D3D11_SAMPLER_DESC));
comparisonSamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.BorderColor[0] = 1.0f;
comparisonSamplerDesc.BorderColor[1] = 1.0f;
comparisonSamplerDesc.BorderColor[2] = 1.0f;
comparisonSamplerDesc.BorderColor[3] = 1.0f;
comparisonSamplerDesc.MinLOD = 0.f;
comparisonSamplerDesc.MaxLOD = D3D11_FLOAT32_MAX;
comparisonSamplerDesc.MipLODBias = 0.f;
comparisonSamplerDesc.MaxAnisotropy = 0;
comparisonSamplerDesc.ComparisonFunc = D3D11_COMPARISON_LESS_EQUAL;
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT;

// Point filtered shadows can be faster, and may be a good choice when
// rendering on hardware with lower feature levels. This sample has a
// UI option to enable/disable filtering so you can see the difference
// in quality and speed.

DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_point
        )
    );
```

## Xxxxxx xxxxxx xxxxxx


Xxx xxxxxx x xxxxxx xxxxx xxx xxx xxx xx xxxxxx xxxxx xxxx xxxxxxx. Xxxx xxxx xxxxxxx xxxxx Y\_Y xxxxxxx xxxxxxx **XxxxxXxxxXxxxxx** xxx xx **xxxx**.

```cpp
D3D11_RASTERIZER_DESC drawingRenderStateDesc;
ZeroMemory(&drawingRenderStateDesc, sizeof(D3D11_RASTERIZER_DESC));
drawingRenderStateDesc.CullMode = D3D11_CULL_BACK;
drawingRenderStateDesc.FillMode = D3D11_FILL_SOLID;
drawingRenderStateDesc.DepthClipEnable = true; // Feature level 9_1 requires DepthClipEnable == true
DX::ThrowIfFailed(
    pD3DDevice->CreateRasterizerState(
        &drawingRenderStateDesc,
        &m_drawingRenderState
        )
    );
```

Xxxxxx x xxxxxx xxxxx xxx xxx xxx xx xxxxxx xxxx xxxx xxxxxxx. Xx xxxx xxxxxxxxx xxxx xxxxxxx xxxxx xx xxxx xxxx xxxxxxx, xxxx xxx xxx xxxx xxxx xxxx.

```cpp
D3D11_RASTERIZER_DESC shadowRenderStateDesc;
ZeroMemory(&shadowRenderStateDesc, sizeof(D3D11_RASTERIZER_DESC));
shadowRenderStateDesc.CullMode = D3D11_CULL_FRONT;
shadowRenderStateDesc.FillMode = D3D11_FILL_SOLID;
shadowRenderStateDesc.DepthClipEnable = true;

DX::ThrowIfFailed(
    pD3DDevice->CreateRasterizerState(
        &shadowRenderStateDesc,
        &m_shadowRenderState
        )
    );
```

## Xxxxxx xxxxxxxx xxxxxxx


Xxx'x xxxxxx xx xxxxxx x xxxxxxxx xxxxxx xxx xxxxxxxxx xxxx xxx xxxxx'x xxxxx xx xxxx. Xxx xxx xxxx xxx xxxx xxxxxxxx xxxxxx xx xxxxxxx xxx xxxxx xxxxxxxx xx xxx xxxxxx. Xxx x xxxxxxxxxxx xxxxxx xxx xxxxx xxxxxx, xxx xxx xx xxxxxxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxx (xxxx xx xxxxxxxx).

```cpp
DX::ThrowIfFailed(
    m_deviceResources->GetD3DDevice()->CreateBuffer(
        &viewProjectionConstantBufferDesc,
        nullptr,
        &m_lightViewProjectionBuffer
        )
    );
```

Xxxx xxx xxxxxxxx xxxxxx xxxx. Xxxxxx xxx xxxxxxxx xxxxxxx xxxx xxxxxx xxxxxxxxxxxxxx, xxx xxxxx xx xxx xxxxx xxxxxx xxxx xxxxxxx xxxxx xxx xxxxxxxx xxxxx.

```cpp
{
    XMMATRIX lightPerspectiveMatrix = XMMatrixPerspectiveFovRH(
        XM_PIDIV2,
        1.0f,
        12.f,
        50.f
        );

    XMStoreFloat4x4(
        &m_lightViewProjectionBufferData.projection,
        XMMatrixTranspose(lightPerspectiveMatrix)
        );

    // Point light at (20, 15, 20), pointed at the origin. POV up-vector is along the y-axis.
    static const XMVECTORF32 eye = { 20.0f, 15.0f, 20.0f, 0.0f };
    static const XMVECTORF32 at = { 0.0f, 0.0f, 0.0f, 0.0f };
    static const XMVECTORF32 up = { 0.0f, 1.0f, 0.0f, 0.0f };

    XMStoreFloat4x4(
        &m_lightViewProjectionBufferData.view,
        XMMatrixTranspose(XMMatrixLookAtRH(eye, at, up))
        );

    // Store the light position to help calculate the shadow offset.
    XMStoreFloat4(&m_lightViewProjectionBufferData.pos, eye);
}
```

```cpp
context->UpdateSubresource(
    m_lightViewProjectionBuffer.Get(),
    0,
    NULL,
    &m_lightViewProjectionBufferData,
    0,
    0
    );
```

## Xxxxxx x xxxxxxxx


Xxx xxxx x xxxxxxxx xxxxxxxx xx xxxxxx xx xxx xxxxxx xxx. Xxx xxxxxxxx xxx'x x xxxxxx-xxxxx xxxxxxxx; xxx'xx xxxx xx xxxxxx xx xxxxxxxxx xx xxxx xxxx. Xxxxxxxx xxx xxxxxxxx xxxxx xxxx xxx xxxxxx xxx xxx xxxx xxxx xx xxxx xxxxxxxxxx xx xxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxxxx xxxx xxx xxxxxx xxx xxxxxxxxx.

```cpp
// Init viewport for shadow rendering
ZeroMemory(&m_shadowViewport, sizeof(D3D11_VIEWPORT));
m_shadowViewport.Height = m_shadowMapDimension;
m_shadowViewport.Width = m_shadowMapDimension;
m_shadowViewport.MinDepth = 0.f;
m_shadowViewport.MaxDepth = 1.f;
```

Xx xxx xxxx xxxx xx xxxx xxxxxxxxxxx, xxxxx xxx xx xxxxxx xxx xxxxxx xxx xx [xxxxxxxxx xx xxx xxxxx xxxxxx](render-the-shadow-map-to-the-depth-buffer.md).

 

 




<!--HONumber=Mar16_HO1-->
