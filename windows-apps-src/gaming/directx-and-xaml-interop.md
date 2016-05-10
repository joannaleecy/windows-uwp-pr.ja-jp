---
author: mtoepke
title: DirectX and XAML interop
description: You can use Extensible Application Markup Language (XAML) and Microsoft DirectX together in your Universal Windows Platform (UWP) game.
ms.assetid: 0fb2819a-61ed-129d-6564-0b67debf5c6b
---

# DirectX and XAML interop


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

You can use Extensible Application Markup Language (XAML) and Microsoft DirectX together in your Universal Windows Platform (UWP) game. The combination of XAML and DirectX lets you build flexible user interface frameworks that interop with your DirectX-rendered content, and is particularly useful for graphics-intensive apps. This topic explains the structure of a UWP app that uses DirectX and identifies the important types to use when building your UWP app to work with DirectX.

> **Note**  DirectX APIs are not defined as Windows Runtime types, so you typically use Visual C++ component extensions (C++/CX) to develop XAMLUWP components that interop with DirectX. Also, you can create a UWP app with C# and XAML that uses DirectX, if you wrap the DirectX calls in a separate Windows Runtime metadata file.

 

## XAML and DirectX


DirectX provides two powerful libraries for 2D and 3D graphics: Direct2D and Microsoft Direct3D. Although XAML provides support for basic 2D primitives and effects, many apps, such as modeling and gaming, need more complex graphics support. For these, you can use Direct2D and Direct3D to render part or all of the graphics and use XAML for everything else.

In the XAML and DirectX interop scenario, you need to know these two concepts:

-   Shared surfaces are sized regions of the display, defined by XAML, that you can use DirectX to draw into indirectly, using [**Windows::UI::Xaml::Media::Brush**](https://msdn.microsoft.com/library/windows/apps/br228076) types. For shared surfaces, you don't control the calls to present the swap chain(s). The updates to the shared surface are synced to the XAML framework's updates.
-   The swap chain itself. This provides the back buffer of the DirectX rendering pipeline, the area of memory that is presented for display after the render target is complete.

Consider what you are using DirectX for. Will it be used to composite or animate a single control that fits within the dimensions of the display window? Can the composited surface be occluded by other surfaces, or the edges of the screen? Will it contain output that needs to be rendered and controlled in real-time, as in a game?

Once you've determined how you intend to use DirectX, you use one of these Windows Runtime types to incorporate DirectX rendering into your Windows Store app:

-   If you want to compose a static image, or draw a complex image on event-driven intervals, draw to a shared surface with [**Windows::UI::Xaml::Media::Imaging::SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041). This type handles a sized DirectX drawing surface. Typically, you use this type when composing an image or texture as a bitmap for display in a document or UI element. It doesn't work well for real-time interactivity, such as a high-performance game. That's because updates to a **SurfaceImageSource** object are synced to XAML user interface updates, and that can introduce latency into the visual feedback you provide to the user, like a fluctuating frame rate or a perceived poor response to real-time input. Updates are still quick enough for dynamic controls or data simulations, though!

    [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) graphics objects can be composited with other XAML UI elements. You can transform or project them , and the XAML framework respects any opacity or z-index values.

-   If the image is larger than the provided screen real estate, and can be panned or zoomed by the user, use [**Windows::UI::Xaml::Media::Imaging::VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050). This type handles a sized DirectX drawing surface that is larger than the screen. Like [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041), you use this when composing a complex image or control dynamically. And, also like **SurfaceImageSource**, it doesn't work well for high-performance games. Some examples of XAML elements that could use a **VirtualSurfaceImageSource** are map controls, or a large, image-dense document viewer.

-   If you are using DirectX to present graphics updated in real-time, or in a situation where the updates must come on regular low-latency intervals, use the [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) class, so you can refresh the graphics without syncing to the XAML framework refresh timer. This type enables you to access the graphics device's swap chain ([**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)) directly and layer XAML atop the render target. This type works great for games and other full-screen DirectX apps that require a XAML-based user interface. You must know DirectX well to use this approach, including the Microsoft DirectX Graphics Infrastructure (DXGI), Direct2D, and Direct3D technologies. For more info, see [Programming Guide for Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476345).

## SurfaceImageSource


[**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) provides DirectX shared surfaces to draw into and then composes the bits into app content.

Here is the basic process for creating and updating a [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) object in the code behind:

1.  Define the size of the shared surface by passing the height and width to the [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) constructor. You can also indicate whether the surface needs alpha (opacity) support.

    For example:

    `SurfaceImageSource^ surfaceImageSource = ref new SurfaceImageSource(400, 300);`

2.  Get a pointer to [**ISurfaceImageSourceNative**](https://msdn.microsoft.com/library/windows/desktop/hh848322). Cast the [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) object as [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) (or **IUnknown**), and call **QueryInterface** on it to get the underlying **ISurfaceImageSourceNative** implementation. You use the methods defined on this implementation to set the device and run the draw operations.

    ```cpp
    Microsoft::WRL::ComPtr<ISurfaceImageSourceNative> m_sisNative;
    // ...
    IInspectable* sisInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(surfaceImageSource);
    sisInspectable->QueryInterface(__uuidof(ISurfaceImageSourceNative), (void **)&m_sisNative);
    ```

3.  Set the DXGI device by first calling [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) and then passing the device and context to [**ISurfaceImageSourceNative::SetDevice**](https://msdn.microsoft.com/library/windows/desktop/hh848325). For example:

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device>              m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext>           m_d3dContext;
    // ...
    D3D11CreateDevice(
            NULL,
            D3D_DRIVER_TYPE_HARDWARE,
            NULL,
            flags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            &m_d3dDevice,
            NULL,
            &m_d3dContext
            )
        );  
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);
    // ...
    m_sisNative->SetDevice(dxgiDevice.Get());
    ```

4.  Provide a pointer to [**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) object to [**ISurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323), and draw into that surface using DirectX. Only the area specified for update in the *updateRect* parameter is drawn.

    > **Note**   You can only have one outstanding [**BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) operation active at a time per [**IDXGIDevice**](https://msdn.microsoft.com/library/windows/desktop/bb174527).

     

    This method returns the point (x,y) offset of the updated target rectangle in the *offset* parameter. You use this offset to determine where to draw into inside the [**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565).

    ```cpp
    ComPtr<IDXGISurface> surface;

    HRESULT beginDrawHR = m_sisNative->BeginDraw(updateRect, &surface, &offset);
    if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET)
    {
              // Device changed
    }
    else
    {
        // Draw to IDXGISurface (the surface paramater)
    }
    ```

5.  Call [**ISurfaceImageSourceNative::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848324) to complete the bitmap. Pass this bitmap to an [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101).

    ```cpp
    m_sisNative->EndDraw();
    // ...
    // The SurfaceImageSource object's underlying ISurfaceImageSourceNative object contains the completed bitmap.
    ImageBrush^ brush = ref new ImageBrush();
    brush->ImageSource = surfaceImageSource;
    ```

6.  Use the [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101) to draw the bitmap.

> **Note**   Calling [**SurfaceImageSource::SetSource**](https://msdn.microsoft.com/library/windows/apps/br243255) (inherited from **IBitmapSource::SetSource**) currently throws an exception. Do not call it from your [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) object.

 

## VirtualSurfaceImageSource


[**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) extends [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) when the content is potentially larger than what can fit on screen and so the content must be virtualized to render optimally.

[**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) differs from [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) in that it uses a callback, [**IVirtualSurfaceImageSourceCallbacksNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848337), that you implement to update regions of the surface as they become visible on the screen. You do not need to clear regions that are hidden, as the XAML framework takes care of that for you.

Here is basic process for creating and updating a [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) object in the codebehind:

1.  Create an instance of [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) with the size you want. For example:

    `VirtualSurfaceImageSource^ virtualSIS = ref new VirtualSurfaceImageSource(2000, 2000);`

2.  Get a pointer to [**IVirtualSurfaceImageSourceNative**](https://msdn.microsoft.com/library/windows/desktop/hh848328). Cast the [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) object as [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) or [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509), and call [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) on it to get the underlying **IVirtualSurfaceImageSourceNative** implementation. You use the methods defined on this implementation to set the device and run the draw operations.

    ```cpp
    Microsoft::WRL::ComPtr<IVirtualSurfaceImageSourceNative>  m_vsisNative;
    // ...
    IInspectable* vsisInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(virtualSIS);
    vsisInspectable->QueryInterface(__uuidof(IVirtualSurfaceImageSourceNative), (void **)&m_vsisNative);
    ```

3.  Set the DXGI device by calling [**IVirtualSurfaceImageSourceNative::SetDevice**](https://msdn.microsoft.com/library/windows/desktop/hh848325). For example:

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device>              m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext>           m_d3dContext;
    // ...
    D3D11CreateDevice(
            NULL,
            D3D_DRIVER_TYPE_HARDWARE,
            NULL,
            flags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            &m_d3dDevice,
            NULL,
            &m_d3dContext
            )
        );  
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);
    // ...
    m_vsisNative->SetDevice(dxgiDevice.Get());
    ```

4.  Call [**IVirtualSurfaceImageSourceNative::RegisterForUpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848334), passing in a reference to your implementation of [**IVirtualSurfaceUpdatesCallbackNative**](https://msdn.microsoft.com/library/windows/desktop/hh848336).

    ```cpp
    class MyContentImageSource : public IVirtualSurfaceUpdatesCallbackNative
    {
    // ...
      private:
         virtual HRESULT STDMETHODCALLTYPE UpdatesNeeded() override;
    }

    // ...

    HRESULT STDMETHODCALLTYPE MyContentImageSource::UpdatesNeeded()
    {
      // .. Perform drawing here ...
    }
    void MyContentImageSource::Initialize()
    {
      // ...
      m_vsisNative->RegisterForUpdatesNeeded(this);
      // ...
    }
    ```

    The framework calls your implementation of [**IVirtualSurfaceUpdatesCallbackNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848334) when a region of the [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) needs to be updated.

    This can happen either when the framework determines the region needs to be drawn (such as when the user pans or zooms the view of the surface), or after the app has called [**IVirtualSurfaceImageSourceNative::Invalidate**](https://msdn.microsoft.com/library/windows/desktop/hh848332) on that region.

5.  In [**IVirtualSurfaceImageSourceNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848337), use the [**IVirtualSurfaceImageSourceNative::GetUpdateRectCount**](https://msdn.microsoft.com/library/windows/desktop/hh848329) and [**IVirtualSurfaceImageSourceNative::GetUpdateRects**](https://msdn.microsoft.com/library/windows/desktop/hh848330) methods to determine which region(s) of the surface must be drawn.

    ```cpp
    HRESULT STDMETHODCALLTYPE MyContentImageSource::UpdatesNeeded()
    {
        HRESULT hr = S_OK;

        try
        {
            ULONG drawingBoundsCount = 0;  

                  m_vsisNative->GetUpdateRectCount(&drawingBoundsCount);
            std::unique_ptr<RECT[]> drawingBounds(new RECT[drawingBoundsCount]);
            m_vsisNative->GetUpdateRects(drawingBounds.get(), drawingBoundsCount);
            
            for (ULONG i = 0; i < drawingBoundsCount; ++i)
            {
                // Drawing code here ...
            }
        }
        catch (Platform::Exception^ exception)
        {
            hr = exception->HResult;
        }

        return hr;
    }
    ```

6.  Lastly, for each region that must be updated:

    1.  Provide a pointer to the [**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) object to [**IVirtualSurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323), and draw into that surface using DirectX. Only the area specified for update in the *updateRect* parameter will be drawn.

        As with [**IlSurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323), this method returns the point (x,y) offset of the updated target rectangle in the *offset* parameter. You use this offset to determine where to draw into inside the [**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565).

        > **Note**   You can only have one outstanding [**BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) operation active at a time per [**IDXGIDevice**](https://msdn.microsoft.com/library/windows/desktop/bb174527).

         

        ```cpp
        ComPtr<IDXGISurface> bigSurface;

        HRESULT beginDrawHR = m_vsisNative->BeginDraw(updateRect, &bigSurface, &offset);
        if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET)
        {
                  // Device changed
        }
        else
        {
            // Draw to IDXGISurface
        }
        ```

    2.  Draw the specific content to that region, but constrain your drawing to the bounded regions for better performance.

    3.  Call [**IVirtualSurfaceImageSourceNative::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848324). The result is a bitmap.

## SwapChainPanel and gaming


[**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) is the Windows Runtime type designed to support high-performance graphics and gaming, where you manage the swap chain directly. In this case, you create your own DirectX swap chain and manage the presentation of your rendered content. You can then add XAML elements to the **SwapChainPanel** object, such as menus, heads-up displays, and other UI overlays.

To ensure good performance, there are certain limitations to the [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) type:

-   There are no more than 4 [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) instances per app.
-   The **Opacity**, **RenderTransform**, **Projection**, and **Clip** properties inherited by [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) are not supported.
-   You should set the DirectX swap chain's height and width (in [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to the current dimensions of the app window. If you don't, the display content will be scaled (using **DXGI\_SCALING\_STRETCH**) to fit.
-   You must set the DirectX swap chain's scaling mode (in [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to **DXGI\_SCALING\_STRETCH**.
-   You can't set the DirectX swap chain's alpha mode (in [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to **DXGI\_ALPHA\_MODE\_PREMULTIPLIED**.
-   You must create the DirectX swap chain by calling [**IDXGIFactory2::CreateSwapChainForComposition**](https://msdn.microsoft.com/library/windows/desktop/hh404558).

You update the [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) based on the needs of your app, and not the updates of the XAML framework. If you need to synchronize the updates of **SwapChainPanel** to those of the XAML framework, register for the [**Windows::UI::Xaml::Media::CompositionTarget::Rendering**](https://msdn.microsoft.com/library/windows/apps/br228127) event. Otherwise, you must consider any cross-thread issues if you try to update the XAML elements from a different thread than the one updating the **SwapChainPanel**.

There are also a few general best practices to follow designing your app to use [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834).

-   [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) inherits from [**Windows::UI::Xaml::Controls::Grid**](https://msdn.microsoft.com/library/windows/apps/br242704), and supports similar layout behavior. Familiarize yourself with the **Grid** type and its properties.

-   After a DirectX swap chain has been set, all input events that are fired for [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) work the same as they do for any other XAML element. You don't set a background brush for **SwapChainPanel**, and you don't need to handle input events from the app's [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object directly as you do in DirectX apps that don't use **SwapChainPanel**.

-   • All content of the visual XAML element tree under a direct child of a [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) is clipped to the layout size of the **SwapChainPanel** object’s immediate child. Any content that is transformed outside these layout bounds won't be rendered. Therefore, place any XAML content that you animate with a XAML[**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) in the visual tree under an element whose layout bounds are large enough to contain the full range of the animation.

-   Limit the number of immediate visual XAML elements under a [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834). If possible, group elements that are in close proximity under a common parent. But there is a performance tradeoff between the number of immediate visual children and the size of the children: too many or unnecessarily large XAML elements can impact overall performance. Likewise, don't create a single full-screen child XAML element for your app's **SwapChainPanel** because this increases overdraw in the app and decreases performance. As a rule, create no more than 8 immediate XAML visual children for your app's **SwapChainPanel**, and each element must have a layout size only as large as necessary to contain the element's visual content. However, you can make the visual tree of elements under a child element of the **SwapChainPanel** sufficiently complex without decreasing performance too badly.

> **Note**   In general, your DirectX apps should create swap chains in landscape orientation, and equal to the display window size (which is usually the native screen resolution in most Windows Store games). This ensures that your app uses the optimal swap chain implementation when it doesn't have any visible XAML overlay. If the app is rotated to portrait mode, your app should call [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) on the existing swap chain, apply a transform to the content if needed, and then call [**SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) again on the same swap chain. Similarly, your app should call **SetSwapChain** again on the same swap chain whenever the swap chain is resized by calling [**IDXGISwapChain::ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577).

 

Here is basic process for creating and updating a [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) object in the code behind:

1.  Get an instance of a swap chain panel for your app. The instances are indicated in your XAML with the `<SwapChainPanel>` tag.

    `Windows::UI::Xaml::Controls::SwapChainPanel^ swapChainPanel;`

    Here is an example `<SwapChainPanel>` tag.

    ```xml
    <SwapChainPanel x:Name="swapChainPanel">
        <SwapChainPanel.ColumnDefinitions>
            <ColumnDefinition Width="300*"/>
            <ColumnDefinition Width="1069*"/>
        </SwapChainPanel.ColumnDefinitions>
    …
    ```

2.  Get a pointer to [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143). Cast the [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) object as [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) (or **IUnknown**), and call **QueryInterface** on it to get the underlying **ISwapChainPanelNative** implementation.

    ```cpp
    Microsoft::WRL::ComPtr<ISwapChainPanelNative> m_swapChainNative;
    // ...
    IInspectable* panelInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(swapChainPanel);
    panelInspectable->QueryInterface(__uuidof(ISwapChainPanelNative), (void **)&m_swapChainNative);
    ```

3.  Create the DXGI device and the swap chain, and set the swap chain to [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143) by passing it to [**SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144).

    ```cpp
    Microsoft::WRL::ComPtr<IDXGISwapChain1>               m_swapChain;    
    // ...
    DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};
            swapChainDesc.Width = m_bounds.Width;
            swapChainDesc.Height = m_bounds.Height;
            swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;           // This is the most common swapchain format.
            swapChainDesc.Stereo = false; 
            swapChainDesc.SampleDesc.Count = 1;                          // Don't use multi-sampling.
            swapChainDesc.SampleDesc.Quality = 0;
            swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.BufferCount = 2;
            swapChainDesc.Scaling = DXGI_SCALING_STRETCH;
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // We recommend using this swap effect for all. applications
            swapChainDesc.Flags = 0;
                    
    // QI for DXGI device
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);

    // Get the DXGI adapter.
    Microsoft::WRL::ComPtr<IDXGIAdapter> dxgiAdapter;
    dxgiDevice->GetAdapter(&dxgiAdapter);

    // Get the DXGI factory.
    Microsoft::WRL::ComPtr<IDXGIFactory2> dxgiFactory;
    dxgiAdapter->GetParent(__uuidof(IDXGIFactory2), &dxgiFactory);
    // Create a swap chain by calling CreateSwapChainForComposition.
    dxgiFactory->CreateSwapChainForComposition(
                m_d3dDevice.Get(),
                &swapChainDesc,
                nullptr,        // Allow on any display. 
                &m_swapChain
                );
            
    m_swapChainNative->SetSwapChain(m_swapChain.Get());
    ```

4.  Draw to the DirectX swap chain, and present it to display the contents.

    ```cpp
    HRESULT hr = m_swapChain->Present(1, 0);
    ```

    The XAML elements are refreshed when the Windows Runtime layout/render logic signals an update.

## Related topics


* [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041)
* [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050)
* [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834)
* [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143)
* [Programming Guide for Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476345)

 

 




