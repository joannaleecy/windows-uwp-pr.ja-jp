---
xxxxx: Xxxxxx xxxxxx xxxxxxx xxxxxxxxx xx XxxxxxYX YY
xxxxxxxxxxx: Xxxx xxxxx xxxxxxxx xxx xx xxxxxxxx xxx XxxxxxYX xxx XXXX xxxxxx xxxxxxxxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xx xxxxxxx xx xxxxxxxxxxxxx.
xx.xxxxxxx: YxYYYxxx-YYxY-xxYx-YYxY-xxxYYxxxYYYx
---

# <span id="dev_gaming.handling_device-lost_scenarios">
            </span>Xxxxxx xxxxxx xxxxxxx xxxxxxxxx xx XxxxxxYX YY


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxx xxxxxxxx xxx xx xxxxxxxx xxx XxxxxxYX xxx XXXX xxxxxx xxxxxxxxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xx xxxxxxx xx xxxxxxxxxxxxx.

Xx XxxxxxX Y, xxxxxxxxxxxx xxxxx xxxxxxxxx x "[xxxxxx xxxx](https://msdn.microsoft.com/library/windows/desktop/bb174714)" xxxxxxxxx xxxxx xxx XYX xxxxxx xxxxxx x xxx-xxxxxxxxxxx xxxxx. Xxx xxxxxxx, xxxx x xxxx-xxxxxx XxxxxxYX Y xxxxxxxxxxx xxxxx xxxxx, xxx XxxxxxYX xxxxxx xxxxxxx "xxxx;" xxx xxxxxxxx xx xxxx xxxx x xxxx xxxxxx xxxx xxxxxxxx xxxx. XxxxxxYX YY xxxx xxxxxxx xxxxxxxx xxxxxx xxxxxxxxxx, xxxxxxxx xxxxxxxx xxxxxxxx xx xxxxx xxx xxxx xxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxxx xxxx xxxx xxxxxxx xx xxx XxxxxxYX xxxxxx. Xxxxxxx, xx xx xxxxx xxxxxxxx xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xx xxxxxx. Xxx xxxxxxx:

-   Xxx xxxxxxxx xxxxxx xx xxxxxxxx.
-   Xxx xxxxxx xxxxxxx xxxx x xxxxx-xxxxxx xxxxxxxx xxxxxxx xx x xxxxxxxxxxx xxxxxxxx xxxxxxx.
-   Xxx xxxxxxxx xxxxxx xxxxx xxxxxxxxxx xxx xx xxxxx.
-   X xxxxxxxx xxxxxxx xx xxxxxxxxxx xxxxxxxx xx xxxxxxx.

Xxxx xxxx xxxxxxxxxxxxx xxxxx, XXXX xxxxxxx xx xxxxx xxxx xxxxxxxxxx xxxx xxx XxxxxxYX xxxxxx xxxx xx xxxxxxxxxxxxx xxx xxxxxx xxxxxxxxx xxxx xx xxxxxxxxx. Xxxx xxxxxxxxxxx xxxxxxxx xxx XxxxxxYX YY xxxx xxx xxxxx xxx xxxxxx xxx xxxxxxx xx xxx xxxxxxxxxxxx xxxxx xxx xxxxxxxx xxxxxxx xx xxxxx, xxxxxxx, xx xxxxxxx. Xxxx xxxxxxxx xxx xxxxxxxx xxxx xxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx xxxxxxxx xxxx Xxxxxxxxx Xxxxxx Xxxxxx YYYY.

# Xxxxxxxxxxxx

### <span>
            </span>Xxxx Y:

Xxxxxxx x xxxxx xxx xxx xxxxxx xxxxxxx xxxxx xx xxx xxxxxxxxx xxxx. Xxxxxxx xxx xxxxx xx xxxxxxx [**XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576) (xx [**XxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh446797), xxx xx xx). Xxxx, xxxxx xxxxxxx xx xxxxxxxx [**XXXX\_XXXXX\_XXXXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb509553) xx **XXXX\_XXXXX\_XXXXXX\_XXXXX**.

Xxxxx, xxx xxxxxxxx xxxxxx xxx XXXXXXX xxxxxxxx xx xxx XXXX xxxx xxxxx:

```cpp
HRESULT hr = m_swapChain->Present(1, 0);
```

Xxxxx xxxxxx xxxx xx xxx xxxxx xxxx xxx xxxxxxxxxx xxx xxxxx, xxx xxxxxxxx xxxxxx xxx xxx xxxxxx xxxxxxx xxxxx. Xx xxxxxxxxx, xx xxxxx x xxxxxx xx xxxxxx xxx xxxxxx xxxxxxx xxxxxxxxx:

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

### Xxxx Y:

Xxxx, xxxxxxx x xxxxx xxx xxx xxxxxx xxxxxxx xxxxx xxxx xxxxxxxxxx xx xxxxxx xxxx xxxxxxx. Xxxx xx x xxxx xxxxx xx xxxxx xxx [**XXXX\_XXXXX\_XXXXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb509553) xx **XXXX\_XXXXX\_XXXXXX\_XXXXX** xxx xxxxxxx xxxxxxx:

-   Xxxxxxxx xxx xxxx xxxxx xxxxxxxx x xxxx xx xxx xxxxxxxxxx XXXX xxxxxxx, xxxxx xxx xxxxxx xxx xxxxxx xxxxxxx xxxxx.
-   Xxx xxx xxxxx xxxx xxxxx xx x xxxxxxx xxxx'x xxxxxxxx xx x xxxxxxxxx xxxxxxxx xxxxxx.
-   Xxxx x xxxxxxxx xxxxxx xx xxxxxxx xx xxxxx, xxx xxxxxxx xxxxxxxxxx xxxxx xxxxxxx, xxxxxxxxx xx x xxxxxx xxxx xxxxxx.

Xxx xxxxxxxx xxxxxx xxx XXXXXXX xxxxxxxx xx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174577):

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

### Xxxx Y:

Xxx xxxx xxxx xxx xxxxxxxx xxx [**XXXX\_XXXXX\_XXXXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb509553) xxxxx, xx xxxx xxxxxxxxxxxx xxx XxxxxxYX xxxxxx xxx xxxxxxxxxxxx xxx xxxxxx-xxxxxxxxx xxxxxxxxx. Xxxxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxxxx XxxxxxYX xxxxxx; xxxxx xxxxxxxxx xxx xxx xxxxxxx, xxx xxx xxxxxxxxxx xx xxx xxxx xxxxx xxxx xx xxxxxxxx xxxxxx x xxx xxx xxx xx xxxxxxx.

Xxx XxxxxxXxxxxxXxxx xxxxxx xxxxxxxx xxx xxxx xxxxx xxx xxxxxxxx xxx xxxxxxxxxx xx xxxxxxx xxxxxx xxxxxxxxx:

```cpp
m_swapChain = nullptr;

if (m_deviceNotify != nullptr)
{
    // Notify the renderers that device resources need to be released.
    // This ensures all references to the existing swap chain are released so that a new one can be created.
    m_deviceNotify->OnDeviceLost();
}
```

Xxxx, xx xxxxxxx x xxx xxxx xxxxx xxx xxxxxxxxxxxxx xxx xxxxxx-xxxxxxxxx xxxxxxxxx xxxxxxxxxx xx xxx xxxxxx xxxxxxxxxx xxxxx:

```cpp
// Create the new device and swap chain.
CreateDeviceResources();
m_d2dContext->SetDpi(m_dpi, m_dpi);
CreateWindowSizeDependentResources();
```

Xxxxx xxx xxxxxx xxx xxxx xxxxx xxxx xxxx xx-xxxxxxxxxxx, xx xxxxxxxx xxx xxxxxxxxxx xx xxxxxxxxxxxx xxxxxx-xxxxxxxxx xxxxxxxxx:

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

Xxxx xxx XxxxxxXxxxxxXxxx xxxxxx xxxxx, xxxxxxx xxxxxxx xx xxx xxxxxxxxx xxxx, xxxxx xxxxxxxxx xx xx xxxx xxx xxxx xxxxx.

## Xxxxxxx


### Xxxxxxxxxxxxx xxx xxxxx xx xxxxxx xxxxxxx xxxxxx

Xxxxxx xxxxxx xxxx XXXX xxxxxx xxxxxxx xxxxxx xxx xxxxxxxx xxxx xxxx xxxxxxxx xxxx xx xxxxxxxx xxxxxxx xxxxxxxxxx xxxxxx x xxxxxxx xxxxxxx. Xx xxx xxxx xxxxxxxx x xxxxxxxx xxxxxxx xx x xxx xx xxx xxxxxxxx xxxxxx. Xx xxxxxxxxxxx xxx xxxxx xx xxxxxx xxxxxxx xxxxxx, xxxx [**XXYXYYXxxxxx::XxxXxxxxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476526) xxxxxx xxxxxxxxx xxx XxxxxxYX xxxxxx. Xxxx xxxxxx xxxxxxx xxx xx xxx xxxxxxxx XXXX xxxxx xxxxx xxxxxxxxxx xxx xxxxxx xxx xxx xxxxxx xxxxxxx xxxxx:

-   **XXXX\_XXXXX\_XXXXXX\_XXXX**: Xxx xxxxxxxx xxxxxx xxxxxxx xxxxxxxxxx xxxxxxx xx xx xxxxxxx xxxxxxxxxxx xx xxxxxxxx xxxxxxxx xxxx xx xxx xxx. Xx xxx xxx xxxx xxxxx xxxxxxxxxx, xx xx x xxxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xx xx xxxxxxxx.
-   **XXXX\_XXXXX\_XXXXXX\_XXXXXXX**: Xxx xxxxxxxx xxxxxx xxx xxxx xxxxxxxxxx xxxxxxx, xxxxxx xxx, xx x xxxxxx xxxxxxx xxx xxxxxxxx. Xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx; xxxx xxx xx xxxx xxxxxx xxxxxxxx xxxxxx xxxxxxxxx xx xxxxxxxxx xx xxxx xxxxx.
-   **XXXX\_XXXXX\_XXXXXX\_XXXXX**: Xxx xxxxxxxx xxxxxx xxxxxx xxxxxxx xx x xxxxx xxxxxx xxxxxxx. Xx xxx xxx xxxx xxxxx xxxxxxxxxx, xx xxx xxxx xxxx xxxx xxxx xx xxxxxxx xxxxxxx xxxxxxx xxxxxxxx.
-   **XXXX\_XXXXX\_XXXXXX\_XXXXXXXX\_XXXXX**: Xxx xxxxxxxx xxxxxx xxxxxxxxxxx xx xxxxx xxx xxxxx xxx xxxxxx.
-   **XXXX\_XXXXX\_XXXXXXX\_XXXX**: Xxx xxxxxxxxxxx xxxxxxxx xxxxxxx xxxxxxxxx xxxx. Xx xxx xxx xxxx xxxxx xxxx xxxx, xx xxxxx xxxx xxxx xxxx xxxxxx xxx xxxxxx xxxxxxx xxxxxxxxx xxx xxxx xx xxxxxxxx.
-   **X\_XX**: Xxxxxxxx xxxx x xxxxxxxx xxxxxx xxx xxxxxxx, xxxxxxxx, xx xxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxx. Xxx xxxxxxx, xxxx xxxxx xxxx xxx xx xxxxxxxx xx xx xxx xx xxxxx [Xxxxxxx Xxxxxxxx Xxxxxxxxxxxxx Xxxxxxxx (XXXX)](https://msdn.microsoft.com/library/windows/desktop/gg615082) xxx x xxxxxxxx xxxxxxx xxxxxxx xxxxxxxxx.

Xxx xxxxxxxxx xxxx xxxx xxxxxxxx xxx [**XXXX\_XXXXX\_XXXXXX\_XXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb509553) xxxxx xxxx xxx xxxxx xx xx xxx xxxxx xxxxxxx. Xxxxxx xxxx xxxx xx xxx xxxxxxxxx xx xxx XxxxxxXxxxxxXxxx xxxxxx:

```cpp
    HRESULT reason = m_d3dDevice->GetDeviceRemovedReason();

#if defined(_DEBUG)
    wchar_t outString[100];
    size_t size = 100;
    swprintf_s(outString, size, L"Device removed! DXGI_ERROR code: 0x%X\n", reason);
    OutputDebugStringW(outString);
#endif
```

Xxx xxxx xxxxxxx, xxx [**XxxXxxxxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476526) xxx [**XXXX\_XXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb509553).

### Xxxxxxx Xxxxxx Xxxxxxx Xxxxxxxx

Xxxxxx Xxxxxx'x Xxxxxxxxx Xxxxxxx Xxxxxx xxxxxxxx x xxxxxxx xxxx xxxx 'xxxxx' xxx XxxxxxYX xxxxx xxxxxxx xxx xxxxxxxx xxxxxxx xx xxx Xxxxxx Xxxxxx Xxxxxxxx Xxxxxxxxxxx. Xxx xxx xxx xxx xxxxxxx xxxx xxxxxx "-xxxxxxxx" xxxxx xxxx xxx xx xxxxxxx xxxxx xxxx xxxxx x XXX Xxxxxxx Xxxxxxxxx xxx Xxxxxxxx xxxxx, xxxxxxx xxxxxxxxxx XXXX\_XXXXX\_XXXXXX\_XXXXXXX xxx xxxxxxxx xxx xx xxxx xxxx xxxxx xxxxxxxx xxxx.

> **Xxxx**  XXXxx xxx xxx xxxxxxx XXXx xxx xxxxxxxxx xxxx xxxxxxYY/xxxxxxYY xx xxxx xx xxx Xxxxxxxx Xxxxx xxx Xxxxxxx YY xxxxx xxx xx xxxxxx xxxxxxxxxxx xxx xxx Xxxxxxx XXX. Xxxxxxx xxxx xxx xxxxxxxx xxx xxx Xxxxxxxx Xxxxx Xxxxxxx xx Xxxxxx xxxx xx xx xxxxxxxx XX xxxxxxxxx xxx xxxx xx xxxxxxxxx xx xxxxx xx xxxxxx xxx xxx xxx Xxxxxxxx Xxxxx xx Xxxxxxx YY. Xxxx xxxxxxxxxxx xx xxx xx Xxxxxxx xxx Xxxxxxxx Xxxxx xxx Xxxxxxx YY xxx xx xxxxx xxxx: <https://msdn.microsoft.com/library/mt125501.aspx#InstallGraphicsTools>

 

 

 




<!--HONumber=Mar16_HO1-->
