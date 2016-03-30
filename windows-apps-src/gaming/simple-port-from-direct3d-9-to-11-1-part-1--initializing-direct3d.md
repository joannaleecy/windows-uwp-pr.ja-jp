---
xxxxx: Xxxxxxxxxx XxxxxxYX YY
xxxxxxxxxxx: Xxxxx xxx xx xxxxxxx XxxxxxYX Y xxxxxxxxxxxxxx xxxx xx XxxxxxYX YY, xxxxxxxxx xxx xx xxx xxxxxxx xx xxx XxxxxxYX xxxxxx xxx xxx xxxxxx xxxxxxx xxx xxx xx xxx XXXX xx xxx xx x xxxx xxxxx.
xx.xxxxxxx: YxxYxYxY-xxYx-YYYx-YxxY-YxYxYxYYxxYY
---

# Xxxxxxxxxx XxxxxxYX YY


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxx**

-   Xxxx Y: Xxxxxxxxxx XxxxxxYX YY
-   [Xxxx Y: Xxxxxxx xxx xxxxxxxxx xxxxxxxxx](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)
-   [Xxxx Y: Xxxx xxx xxxx xxxx](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)


Xxxxx xxx xx xxxxxxx XxxxxxYX Y xxxxxxxxxxxxxx xxxx xx XxxxxxYX YY, xxxxxxxxx xxx xx xxx xxxxxxx xx xxx XxxxxxYX xxxxxx xxx xxx xxxxxx xxxxxxx xxx xxx xx xxx XXXX xx xxx xx x xxxx xxxxx. Xxxx Y xx xxx [Xxxx x xxxxxx XxxxxxYX Y xxx xx XxxxxxX YY xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX)](walkthrough--simple-port-from-direct3d-9-to-11-1.md) xxxxxxxxxxx.

## Xxxxxxxxxx xxx XxxxxxYX xxxxxx


Xx XxxxxxYX Y, xx xxxxxxx x xxxxxx xx xxx XxxxxxYX xxxxxx xx xxxxxxx [**XXxxxxxYXY::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174313). Xx xxxxxxx xx xxxxxxx x xxxxxxx xx [**XXxxxxxYXY xxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174300) xxx xx xxxxxxxxx x xxxxxx xx xxxxxxxxxx xx xxxxxxx xxx xxxxxxxxxxxxx xx xxx XxxxxxYX xxxxxx xxx xxx xxxx xxxxx. Xxxxxx xxxxx xxxx xx xxxxxx [**XxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/dd144877) xx xxxx xxxx xx xxxxx'x xxxxxx xxx xxxxxx xx xx xxxxxxxxx xx xxxxxx'x xx.

XxxxxxYX Y

```cpp
UINT32 AdapterOrdinal = 0;
D3DDEVTYPE DeviceType = D3DDEVTYPE_HAL;
D3DCAPS9 caps;
m_pD3D->GetDeviceCaps(AdapterOrdinal, DeviceType, &caps); // caps bits

D3DPRESENT_PARAMETERS params;
ZeroMemory(&params, sizeof(D3DPRESENT_PARAMETERS));

// Swap chain parameters:
params.hDeviceWindow = m_hWnd;
params.AutoDepthStencilFormat = D3DFMT_D24X8;
params.BackBufferFormat = D3DFMT_X8R8G8B8;
params.MultiSampleQuality = D3DMULTISAMPLE_NONE;
params.MultiSampleType = D3DMULTISAMPLE_NONE;
params.SwapEffect = D3DSWAPEFFECT_DISCARD;
params.Windowed = true;
params.PresentationInterval = 0;
params.BackBufferCount = 2;
params.BackBufferWidth = 0;
params.BackBufferHeight = 0;
params.EnableAutoDepthStencil = true;
params.Flags = 2;

m_pD3D->CreateDevice(
    0,
    D3DDEVTYPE_HAL,
    m_hWnd,
    64,
    &params,
    &m_pd3dDevice
    );
```

Xx XxxxxxYX YY, xxx xxxxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxxxxxx xx xxxxxxxxxx xxxxxxxx xxxx xxx xxxxxx xxxxxx. Xxxxxxxxxxxxxx xx xxxxxxx xxxx xxxxxxxx xxxxx.

Xxxxx xx xxxxxx xxx xxxxxx. Xx xxx x xxxx xx xxx xxxxxxx xxxxxx xxx xxxxxx xxxxxxxx - xxxx xxxxxxx xxxx xx xxxx xx xxxx xx xxxx xxxxx xxx XXX. Xxxx, xx xxx'x xxxx xx xxxxxx xx xxxxxxxxx xxxx xx xxxxxx XxxxxxYX. Xxxxxxx xx xxx xxx [**XYXYYXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476082) xxxx XXX. Xxxx xxxxx xx x xxxxxx xx xxx xxxxxx xxx xxx xxxxxx'x xxxxxxxxx xxxxxxx. Xxx xxxxxx xxxxxxx xx xxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxxx xxxxxxxxx xxxxxxxx.

Xxxxx xxxxxxxx xxx XxxxxxYX YY xxxxxx xxx xxxxxxx, xx xxx xxxx xxxxxxxxx xx XXX xxxxxxx xxxxxxxxxxxxx xx xxx xxx xxxx xxxxxx xxxxxxx xx xxx xxxxxxxxxx, xxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxx xxx xxx xxxxxx xxxxxxxxxxx.

> **Xxxx**   XYX\_XXXXXXX\_XXXXX\_Y\_Y (xxxxx xxxxxxxxxxx xx xxxxxx xxxxx Y.Y) xx xxx xxxxxxx xxxxx xxxx Xxxxxxx Xxxxx xxxx xx xxxxxxxx xx xxxxxxx. (Xxxx xxxx'x XXX xxxxxxxx xxxx xxxx xxxxxxxxxxxxx xx xxx xxx'x xxxxxxx Y\_Y.) Xx xxxx xxxx xxxx xxxxxxxx x xxxxxxxxx xxxx xxx xxxxxx xxxxx Y xxxxxxxx, xxxx xxx xxxxxx xxxxxxx XYX\_XXXXXXX\_XXXXX\_Y\_Y xx xxx xxxxx.

 

XxxxxxYX YY

```cpp
// This flag adds support for surfaces with a different color channel 
// ordering than the API default. It is required for compatibility with
// Direct2D.
UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)
// If the project is in a debug build, enable debugging via SDK Layers.
creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

// This example only uses feature level 9.1.
D3D_FEATURE_LEVEL featureLevels[] = 
{
    D3D_FEATURE_LEVEL_9_1
};

// Create the Direct3D 11 API device object and a corresponding context.
ComPtr<ID3D11Device> device;
ComPtr<ID3D11DeviceContext> context;
D3D11CreateDevice(
    nullptr, // Specify nullptr to use the default adapter.
    D3D_DRIVER_TYPE_HARDWARE,
    nullptr,
    creationFlags,
    featureLevels,
    ARRAYSIZE(featureLevels),
    D3D11_SDK_VERSION, // Windows Store apps must set this to D3D11_SDK_VERSION.
    &device, // Returns the Direct3D device created.
    nullptr,
    &context // Returns the device immediate context.
    );

// Store pointers to the Direct3D 11.2 API device and immediate context.
device.As(&m_d3dDevice);

context.As(&m_d3dContext);
```

## Xxxxxx x xxxx xxxxx


XxxxxxYX YY xxxxxxxx x xxxxxx XXX xxxxxx XxxxxxX xxxxxxxx xxxxxxxxxxxxxx (XXXX). Xxx XXXX xxxxxxxxx xxxxxx xx xx (xxx xxxxxxx) xxxxxxx xxx xxx xxxx xxxxx xx xxxxxxxxxx xxx xxx xx xxxxxx xxxxxxx. Xx xxxx xxxx xx xxxxxxxxxxxx XxxxxxYX, xx'xx xxxxx xx xxx XXXX xx xxxxxx x xxxx xxxxx. Xxxxx xx xxxxxxx xxx xxxxxx, xx xxx xxxxxx xx xxxxxxxxx xxxxx xxxx xx xxx XXXX xxxxxxx.

Xxx XxxxxxYX xxxxxx xxxxxxxxxx x XXX xxxxxxxxx xxx XXXX. Xxxxx xx xxxx xx xxx xxxx xxxxxxxxx xxx xxx xx xx xxxxxxx xxx XXXX xxxxxxx xxxxxxx xxx xxxxxx. Xxxx xx xxx xxx XXXX xxxxxxx xx xxxxxx x XXXX xxxxxxx.

> **Xxxx**   Xxxxx xxx XXX xxxxxxxxxx xx xxxx xxxxx xxxxxxxx xxxxx xx xx xxx [**XxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms682521). Xxx xxxxxx xxx [**Xxxxxxxxx::XXX::XxxXxx**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) xxxxx xxxxxxxx xxxxxxx. Xxxx xxxx xxxx xxx [**Xx()**](https://msdn.microsoft.com/library/windows/apps/br230426.aspx) xxxxxx, xxxxxxxxx xx xxxxx XXX xxxxxxx xx xxx xxxxxxx xxxxxxxxx xxxx.

 

**XxxxxxYX YY**

```cpp
ComPtr<IDXGIDevice2> dxgiDevice;
m_d3dDevice.As(&dxgiDevice);

// Then, the adapter hosting the device;
ComPtr<IDXGIAdapter> dxgiAdapter;
dxgiDevice->GetAdapter(&dxgiAdapter);

// Then, the factory that created the adapter interface:
ComPtr<IDXGIFactory2> dxgiFactory;
dxgiAdapter->GetParent(
    __uuidof(IDXGIFactory2),
    &dxgiFactory
    );
```

Xxx xxxx xx xxxx xxx XXXX xxxxxxx, xx xxx xxx xx xx xxxxxx xxx xxxx xxxxx. Xxx'x xxxxxx xxx xxxx xxxxx xxxxxxxxxx. Xx xxxx xx xxxxxxx xxx xxxxxxx xxxxxx; xx'xx xxxxxx [**XXXX\_XXXXXX\_XYXYXYXY\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173059) xxxxxxx xx'x xxxxxxxxxx xxxx XxxxxxYX. Xx'xx xxxx xxx xxxxxxx xxxxxxx, xxxxxxxxxxxxx, xxx xxxxxx xxxxxxxxx xxxxxxx xxxx xxxx'x xxxx xx xxxx xxxxxxx. Xxxxx xx xxx xxxxxxx xxxxxxxx xx x XxxxXxxxxx xx xxx xxxxx xxx xxxxx xxx xxxxxx xxx xx Y xxx xxx xxxx-xxxxxx xxxxxx xxxxxxxxxxxxx.

> **Xxxx**   Xxxxxx xxx xxx *XXXXxxxxxx* xxxxxxxxx xx XYXYY\_XXX\_XXXXXXX xxx XXX xxxx.

 

**XxxxxxYX YY**

```cpp
ComPtr<IDXGISwapChain1> swapChain;
dxgiFactory->CreateSwapChainForCoreWindow(
    m_d3dDevice.Get(),
    reinterpret_cast<IUnknown*>(window),
    &swapChainDesc,
    nullptr,
    &swapChain
    );
swapChain.As(&m_swapChain);
```

Xx xxxxxx xx xxxx'x xxxxxxxxx xxxx xxxxx xxxx xxx xxxxxx xxx xxxxxxxx xxxxxxx, xx xxx xxxxx xxxxxxx xx Y xxx xxx [**XXXX\_XXXX\_XXXXXX\_XXXX\_XXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173077). Xxxx xxxxx xxxxx xxx xx x xxxxx xxxxxxxxxxxxx xxxxxxxxxxx; xx'xx xxxxx xxxx xxxxx xxxxxxxxxx xx xxx xxxxxx xx xxxx Y xx xxxx xxxxxxxxxxx.

> **Xxxx**   Xxx xxx xxx xxxxxxxxxxxxxx (xxx xxxxxxx, [**XxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br229642) xxxx xxxxx) xx xxxxxxxx xxxxx xxxx xxxxx xxx xxxxxxxxx xxxxxx xx xxxxxxx.

 

**XxxxxxYX YY**

```cpp
dxgiDevice->SetMaximumFrameLatency(1);
```

Xxx xx xxx xxx xx xxx xxxx xxxxxx xxx xxxxxxxxx.

## Xxxxxxxxx xxx xxxx xxxxxx xx x xxxxxx xxxxxx


Xxxxx xx xxxx xx xxx x xxxxxx xx xxx xxxx xxxxxx. (Xxxx xxxx xxx xxxx xxxxxx xx xxxxx xx xxx XXXX xxxx xxxxx, xxxxxxx xx XxxxxxX Y xx xxx xxxxx xx xxx XxxxxxYX xxxxxx.) Xxxx xx xxxx xxx XxxxxxYX xxxxxx xx xxx xx xx xxx xxxxxx xxxxxx xx xxxxxxxx x xxxxxx xxxxxx *xxxx* xxxxx xxx xxxx xxxxxx.

**XxxxxxYX YY**

```cpp
ComPtr<ID3D11Texture2D> backBuffer;
m_swapChain->GetBuffer(
    0,
    __uuidof(ID3D11Texture2D),
    &backBuffer
    );

// Create a render target view on the back buffer.
m_d3dDevice->CreateRenderTargetView(
    backBuffer.Get(),
    nullptr,
    &m_renderTargetView
    );
```

Xxx xxx xxxxxx xxxxxxx xxxxx xxxx xxxx. Xx xxxx XxxxxxYX xx xxx xxx xxxxx-xxxxxxx xxxxxx xxxxxx xxxx xx xxxxx xxx xxxxxx xxxxxxx xxxxxxxxx. Xx'xx xxxxxxxx xxx xxxxx xxx xxxxxx xx xxx xxxx xxxxxx xx xxxx xx xxx xxxxxx xxx xxxxx xxxxxx xx xxx xxxxxxxx. Xxxx xxxx xxx xxxx xxxxxx xx xxxxxxxx xx xxx xxxx xxxxx, xx xx xxx xxxxxx xxxx xxxxxxx (xxx xxxxxxx, xxx xxxx xxxxx xxx xxxx xxxxxx xx xxxxxxx xxxxxxx) xxx xxxx xxxxxx xxxx xxxx xx xx xxxxxxx xxx xxxx xxxxx xxxx xxxx xx xx xxxxxx.

**XxxxxxYX YY**

```cpp
D3D11_TEXTURE2D_DESC backBufferDesc = {0};
backBuffer->GetDesc(&backBufferDesc);

CD3D11_VIEWPORT viewport(
    0.0f,
    0.0f,
    static_cast<float>(backBufferDesc.Width),
    static_cast<float>(backBufferDesc.Height)
    );

m_d3dContext->RSSetViewports(1, &viewport);
```

Xxx xxxx xx xxxx x xxxxxx xxxxxx xxx x xxxx-xxxxxx xxxxxx xxxxxx, xx xxx xxxxx xx xxxx xxx xxxx xxxxxxxx. Xxxxxxxx xx [Xxxx Y: Xxxxxxxxx](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md).

 

 




<!--HONumber=Mar16_HO1-->
