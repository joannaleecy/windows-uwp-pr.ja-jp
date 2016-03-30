---
xxxxx: Xxxxxx xxxxxxx xxxx XXXX Y.Y xxxx xxxxxx
xxxxxxxxxxx: Xxx XXXX Y.Y xx xxxxxx xxx xxxxxxxxx xxxxx xxxxxxx xx xxxxxxx xxx xxx xxxx xxxxx xx xxxxxx xxx xxxxxxxxxxx xxxx xx xxxxx xxxxxxxxx x xxx xxxxx.
xx.xxxxxxx: xYYxYYxx-xYYY-YYYx-YxYY-YxxYYYYYxYxx
---

# Xxxxxx xxxxxxx xxxx XXXX Y.Y xxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx XXXX Y.Y xx xxxxxx xxx xxxxxxxxx xxxxx xxxxxxx xx xxxxxxx xxx xxx xxxx xxxxx xx xxxxxx xxx xxxxxxxxxxx xxxx xx xxxxx xxxxxxxxx x xxx xxxxx. Xxxxx xxxxxxxxx xxxx xx xxxxxxx xxx xxxxxx xxxxxx xx xxxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxxxx xxxxx xx xxxxxxxx, xx xxxx xxx xxxx xxxxxxxx xx xxxx xxxxx xx xxxxxxxx xxx xxxxxxx. Xxxx xxxxx xxxxxxxx x xxxxxxxxx xxxxxxxxx xxxxxxxx xx XxxxxxYX YY.Y xxxx xxx xxx xxx xx xxxxxxxx xxx xxxxxxxxx xxxxx xxxxxxx xx xxxx xxxx.

## Xxx xxxx xxxxxxx xx xxx xxxx xxxxxx xxxxxx xxxxxxx?


Xxxx xxx xxxx xxxxx xxxx xxxxx, xxxx xxxxxx "xxxxx" xxx xxxxxx xxxxxxxx xxxx xxxx xxxxx [**XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576). Xxxx xxx xxxxxxxxx xxxx xxxxx Xxxxxxx(), xxx xxxxxx xxxxxx xxx xxxxxx xxxxx xx xx xxxx xxxxxxxxxx x xxxxx xxxxx, xxxxxx xxxx xx xxxxx xx xxx xxx xxxxx, xxxxxx xx xxxxxxxx xxxxxxxx. Xxxx xxxxxx xxxxx xxxxxxx xxxxxxx xxx xxxx xxx xxxx xxxxx x xxxxx xxx xxx xxxx xxx xxxxxx xxxxxx xx xx xxxxxxx xxxx xxxxx. Xx xxxx xxxxx, xxx xxxxxx xxxx xxxxx x xxxxxx xxxxxxxxxxx xxxxx xxx xxxx xx xxxxxx xxxxxxx xxxxxx x xxxx xxxxx xxxxx xxxxxxx xxx xxxx xx xxxxxxx xxx xxx xxxx xx xxxxxxxx xxxx xxxxx. Xx'x xxxxxx xx xxxx xxxxx xxx xxxxxx xx xxxxx xx xxxxxx x xxx xxxxx, xxxx xxxxxx xxx xxxxx xxxxx xx xxxxxxx xxxx xxx xxxxx xxx xxxxx xxxxxxxxxxx.

Xxxxxx x xxxxxxxx xxxx xxxxx xxxx xxx [**XXXX\_XXXX\_XXXXX\_XXXX\_XXXXX\_XXXXXXX\_XXXXXXXX\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173076) xxxx. Xxxx xxxxxx xxxxxxx xxxx xxx xxx xxxxxx xxxx xxxxxxxxx xxxx xxxx xxx xxxxxx xx xxxxxxxx xxxxx xx xxxxxx x xxx xxxxx. Xxxx xxxxxx xxxx xxxx xx xxxxxx xxxxx xx xxxxxxx xxxx xxx xxxx xxx xxx xxxxxx xx xxx xxxxxxx xxxxx xxxxx xxxx.

## Xxxx Y: Xxxxxx x xxxxxxxx xxxx xxxxx


Xxxxxxx xxx [**XXXX\_XXXX\_XXXXX\_XXXX\_XXXXX\_XXXXXXX\_XXXXXXXX\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173076) xxxx xxxx xxx xxxx [**XxxxxxXxxxXxxxxXxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh404559).

```cpp
swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT; // Enable GetFrameLatencyWaitableObject().
```

> **Xxxx**   Xx xxxxxxxx xx xxxx xxxxx, xxxx xxxx xxx'x xx xxxxx xx xxxxxxx xxxxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174577). XXXX xxxxxxx xx xxxxx xxxx xx xxxx xxxx xx xxx xxxxxxxxxxx xxxx xxxx xxx xxxx xxxxx xxx xxxxxxx.

 

```cpp
// If the swap chain already exists, resize it.
HRESULT hr = m_swapChain->ResizeBuffers(
    2, // Double-buffered swap chain.
    static_cast<UINT>(m_d3dRenderTargetSize.Width),
    static_cast<UINT>(m_d3dRenderTargetSize.Height),
    DXGI_FORMAT_B8G8R8A8_UNORM,
    DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT // Enable GetFrameLatencyWaitableObject().
    );
```

## Xxxx Y: Xxx xxx xxxxx xxxxxxx


Xxx xxx xxxxx xxxxxxx xxxx xxx [**XXXXXXxxxXxxxxY::XxxXxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dn268313) XXX, xxxxxxx xx xxxxxxx [**XXXXXXxxxxxY::XxxXxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff471334).

Xx xxxxxxx, xxx xxxxx xxxxxxx xxx xxxxxxxx xxxx xxxxxx xx xxx xx Y, xxxxx xxxxxxx xx xxx xxxxx xxxxxxxx xxxxxxx xxx xxxx xxxxxxx XXX-XXX xxxxxxxxxxx. Xx xxx xxxx xxxxxxxxx XXX-XXX xxxxxxxxxxx xx xxxxxxx YY XXX - xxxx xx, xx xxx XXX xxx XXX xxxx xxxxx xxxx xxxx YY.Y xx x xxxxx xxxxxxxxxx xxxxxxxxx xxxx, xxx xxxxx xxxxxxxx xxx xx xxxxxxx xxxx YY.Y xx — xxx xxx xxxxx xxxxxxx xx Y. Xxxx xxxxxx xxx XXX xx xxxxxxx xxxx xxxxxx xx xx xxx XXX xxxxxx xxx xxxxxxxx xxxxx, xxxxx xx xxx xxxx xxxx xxxxxxxx xxx XXX xx xxxxxx xxxxxxxxx xxxxxxxx xxx xxx xxxxxxx xxxxx xxxxxxxxxxxxx.

```cpp
// Swapchains created with the DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT flag use their
// own per-swapchain latency setting instead of the one associated with the DXGI device. The
// default per-swapchain latency is 1, which ensures that DXGI does not queue more than one frame
// at a time. This both reduces latency and ensures that the application will only render after
// each VSync, minimizing power consumption.
//DX::ThrowIfFailed(
//    swapChain2->SetMaximumFrameLatency(1)
//    );
```

## Xxxx Y: Xxx xxx xxxxxxxx xxxxxx xxxx xxx xxxx xxxxx


Xxxx [**XXXXXXxxxXxxxxY::XxxXxxxxXxxxxxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dn268309) xx xxxxxxxx xxx xxxx xxxxxx. Xxx xxxx xxxxxx xx x xxxxxxx xx xxx xxxxxxxx xxxxxx. Xxxxx xxxx xxxxxx xxx xxx xx xxxx xxxxxxxxx xxxx.

```cpp
// Get the frame latency waitable object, which is used by the WaitOnSwapChain method. This
// requires that swap chain be created with the DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT
// flag.
m_frameLatencyWaitableObject = swapChain2->GetFrameLatencyWaitableObject();
```

## Xxxx Y: Xxxx xxxxxx xxxxxxxxx xxxx xxxxx


Xxxx xxxxxxxxx xxxx xxxxxx xxxx xxx xxx xxxx xxxxx xx xxxxxx xxx xxx xxxxxxxx xxxxxx xxxxxx xx xxxxxx xxxxxxxxx xxxxx xxxxx. Xxxx xxxxxxxx xxx xxxxx xxxxx xxxxxxxx xxxx xxx xxxx xxxxx. Xxx [**XxxxXxxXxxxxxXxxxxxXx**](https://msdn.microsoft.com/library/windows/desktop/ms687036), xxxxxxxxx xxx xxxx xxxxxx xxxxxxxxx xx Xxxx Y, xx xxxxxx xxx xxxxx xx xxxx xxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxx xxx xxxxxx xxxx xxxx xxx XxxxxxXXxxxxxx xxxxxx:

```cpp
while (!m_windowClosed)
{
    if (m_windowVisible)
    {
        // Block this thread until the swap chain is finished presenting. Note that it is
        // important to call this before the first Present in order to minimize the latency
        // of the swap chain.
        m_deviceResources->WaitOnSwapChain();

        // Process any UI events in the queue.
        CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

        // Update app state in response to any UI events that occurred.
        m_main->Update();

        // Render the scene.
        m_main->Render();

        // Present the scene.
        m_deviceResources->Present();
    }
    else
    {
        // The window is hidden. Block until a UI event occurs.
        CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
    }
}
```

Xxx xxxxxxxxx xxxxxxx xxxxx xxx XxxxXxxXxxxxxXxxxxxXx xxxx xxxx xxx XxxxxxXXxxxxxx xxxxxx:

```cpp
// Block the current thread until the swap chain has finished presenting.
void DX::DeviceResources::WaitOnSwapChain()
{
    DWORD result = WaitForSingleObjectEx(
        m_frameLatencyWaitableObject,
        1000, // 1 second timeout (shouldn't ever occur)
        true
        );
}
```

## Xxxx xxxxxx xx xxxx xx xxxxx xx xxxxx xxx xxx xxxx xxxxx xx xxxxxxx?


Xx xxxx xxxx xxxxx’x xxxx xxx xxxxx xxxx xxxxx xx xxx xxxxxx xxxx, xxxxxxx xx xxxx xxx xxx xxxx xxxxx xx xxxxxxx xxx xx xxxxxxxxxxxx xxxxxxx xx xxxxx xxxxx, xxxxx xx xxxxxxxxxx xxxxxxxxx xx xxxxxx xxxxxxx. Xxxxxxxxx, xxx xxx xxx xxxxxxxxxxxxxx xx xxxxxxxxxx xxxx xxxxx xxxx xxxx xx xxxxxxx xxx xxx xxxx xxxxx xx xxxxxxx. Xxxx xxx xxxx x xxx xxxxx xxxx xxxx xxxx xxx xxxxxxxx:

-   Xxxxxxx xxxxxxx xxxxxx
-   Xxxxxx xxx XX
-   XXX-xxxxx xxxxxxx
-   Xxxxxxxx-xxxxxxx xxxxxxxxx (xx xxxxxxxxx xxxxxxx)
-   Xxxxx xxxxxxx

Xxx xxxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx xxxxxxxxxxx xx Xxxxxxx, xxx xxx xxxxxxxxx xxxxxxx xxxxxx.

## Xxxxxxx xxxxxx


* [XxxxxxXXxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=317361)
* [**XXXXXXxxxXxxxxY::XxxXxxxxXxxxxxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dn268309)
* [**XxxxXxxXxxxxxXxxxxxXx**](https://msdn.microsoft.com/library/windows/desktop/ms687036)
* [**Xxxxxxx.Xxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br229642)
* [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334)
* [Xxxxxxxxx xxx Xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms684841)
* [Xxxxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms686353)
* [Xxxxx Xxxxx Xxxxxxx (Xxxxxxx)](https://msdn.microsoft.com/library/windows/desktop/ms686915)

 

 




<!--HONumber=Mar16_HO1-->
