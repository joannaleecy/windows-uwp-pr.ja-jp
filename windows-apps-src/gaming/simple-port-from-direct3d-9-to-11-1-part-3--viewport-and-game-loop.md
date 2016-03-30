---
xxxxx: Xxxx xxx xxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxxxxx x xxxxxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xx xxxxx xxxx xxx xxxx xxxx, xxxxxxxxx xxx xx xxxxx xx XXxxxxxxxxXxxx xx xxxxxxx x xxxx-xxxxxx XxxxXxxxxx.
xx.xxxxxxx: YYYxxYYY-xxYY-YYYY-YYxx-xYxYYYxxYYYx
---

# Xxxx xxx xxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxx**

-   [Xxxx Y: Xxxxxxxxxx XxxxxxYX YY](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   [Xxxx Y: Xxxxxxx xxx xxxxxxxxx xxxxxxxxx](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)
-   Xxxx Y: Xxxx xxx xxxx xxxx


Xxxxx xxx xx xxxxxxxxx x xxxxxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xx xxxxx xxxx xxx xxxx xxxx, xxxxxxxxx xxx xx xxxxx xx [**XXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700478) xx xxxxxxx x xxxx-xxxxxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225). Xxxx Y xx xxx [Xxxx x xxxxxx XxxxxxYX Y xxx xx XxxxxxX YY xxx XXX](walkthrough--simple-port-from-direct3d-9-to-11-1.md) xxxxxxxxxxx.

## Xxxxxx x xxxxxx


Xx xxx xx x xxxxxxx xxxxxx xxxx x XxxxxxYX Y xxxxxxxx, xx xxx xx xxxxxxxxx xxx xxxxxxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxxxxx xxxx. Xx xxx xx xxxxxx xx XXXX, xxx xxx xxxxxx xxxx, xxxxxxx x xxxxxx xxxxxxxxxx xxxxxxxx, xxxx xx xxxxxxx, xxx xx xx.

Xxx XXX xxxxxxxxxxx xxx x xxxx xxxxxxx xxxxxx. Xxxxxxx xx xxxxxxx xx x xxxxxxxxxxx xxxxxx, x Xxxxxxx Xxxxx xxxx xxxxx XxxxxxX xxxxxxxxxx [**XXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700478). Xxxx xxxxxxxxx xxxxxx xxx XxxxxxX xxxx xxx xxxxx xx xxx xxxxxxxx xx x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxx xxx xxx xxxxxxxxx.

> **Xxxx**   Xxxxxxx xxxxxxxx xxxxxxx xxxxxxxx xx xxxxxxxxx xxxx xx xxx xxxxxx xxxxxxxxxxx xxxxxx xxx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225). Xxx [**Xxxxxx xx Xxxxxx Xxxxxxxx (^)**]xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYxxYY.xxxx.

 

Xxxx "xxxx" xxxxx xxxxx xx xxxxxxx xxxx [**XXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700478) xxx xxxxxxxxx xxx xxxx **XXxxxxxxxxXxxx** xxxxxxx: [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495), [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700509), [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/hh700501), [**Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505), xxx [**Xxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700523). Xx xxxxxxxx xx xxxxxxxx xxx **XXxxxxxxxxXxxx**, xxxxx xx (xxxxxxxxxxx) xxxxx xxxx xxxx xxxx xxxxxx, xxx xxxx xx xxxxxxxxx x xxxxxxx xxxxx xxxx xxxxxxx xx xxxxxxxx xx xxxx **XXxxxxxxxxXxxx**. Xxxx xxxx xxxxx xxx xx xxxxxxxxxx xxxx x xxxxxx xxxxxx **xxxx()**, xxx xxx xxxx xxx xx xx xxx xxx xxxxxxx xx xxxxxx xxx **XXxxxxxxxxXxxx** xxxxxxxx.

Xxxx xxxxxxxx

```cpp
//-----------------------------------------------------------------------------
// Required method for a DirectX-only app.
// The main function is only used to initialize the app's IFrameworkView class.
//-----------------------------------------------------------------------------
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

XXxxxxxxxxXxxx xxxxxxx

```cpp
//-----------------------------------------------------------------------------
// This class creates our IFrameworkView.
//-----------------------------------------------------------------------------
ref class Direct3DApplicationSource sealed : 
    Windows::ApplicationModel::Core::IFrameworkViewSource
{
public:
    virtual Windows::ApplicationModel::Core::IFrameworkView^ CreateView()
    {
        return ref new Cube11();
    };
};
```

## Xxxx xxx xxxx xxxx


Xxx'x xxxx xx xxx xxxx xxxx xxxx xxx XxxxxxYX Y xxxxxxxxxxxxxx. Xxxx xxxx xxxxxx xx xxx xxx'x xxxx xxxxxxxx. Xxxx xxxxxxxxx xx xxxx xxxx xxxxxxxxx x xxxxxx xxxxxxx xx xxxxxxx x xxxxx.

Xxxx xxxx xx XxxxxxYX Y xxxxxxx xxxx

```cpp
while(WM_QUIT != msg.message)
{
    // Process window events.
    // Use PeekMessage() so we can use idle time to render the scene. 
    bGotMsg = (PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE) != 0);

    if(bGotMsg)
    {
        // Translate and dispatch the message
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    else
    {
        // Render a new frame.
        // Render frames during idle time (when no messages are waiting).
        RenderFrame();
    }
}
```

Xxx xxxx xxxx xx xxxxxxx - xxx xxxxxx - xx xxx XXX xxxxxxx xx xxx xxxx:

Xxx xxxx xxxx xxxx xx xxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxx (xxxxxxx xx **xxxx()**) xxxxxxx xxx xxxx xxxxxxxxx xxxxxx xxx [**XXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700478) xxxxx.

Xxxxxxx xx xxxxxxxxxxxx x xxxxxxx xxxxxxxx xxxxxxxxx xxx xxxxxxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms644943), xx xxx xxxx xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208215) xxxxxx xxxxx xx xx xxx xxx xxxxxx'x [**XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211). Xxxxx'x xx xxxx xxx xxx xxxx xxxx xx xxxxxx xxx xxxxxx xxxxxxxx - xxxx xxxx **XxxxxxxXxxxxx** xxx xxxxxxx.

Xxxx xxxx xx XxxxxxYX YY Xxxxxxx Xxxxx xxxx

```cpp
// Windows Store apps should not exit. Use app lifecycle events instead.
while (true)
{
    // Process window events.
    auto dispatcher = CoreWindow::GetForCurrentThread()->Dispatcher;
    dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

    // Render a new frame.
    RenderFrame();
}
```

Xxx xx xxxx x XXX xxx xxxx xxxx xx xxx xxxx xxxxx xxxxxxxx xxxxxxxxxxxxxx, xxx xxxxxxx xxx xxxx xxxxxxxx xxxx, xx xxx XxxxxxX Y xxxxxxx.

## Xxxxx xx X xx xxxx xxxx?


Xxxxxxxx xxx [XxxxxxX YY xxxxxxx XXX](directx-porting-faq.md).

Xxx XxxxxxX XXX xxxxxxxxx xxxxxxx x xxxxxx XxxxxxYX xxxxxx xxxxxxxxxxxxxx xxxx'x xxxxx xxx xxx xxxx xxxx xxxx. Xxx [Xxxxxx x XxxxxxX xxxx xxxxxxx xxxx x xxxxxxxx](user-interface.md) xxx xxxxxxxx xx xxxxxxx xxx xxxxx xxxxxxxx.

Xxxxx xxx xxxxxxxxx xx-xxxxx Xxxxxxx Xxxxx xxxx xxxx xxxxxxxxxxx xxxxxxxx:

-   [Xxxxxxxxxxx: x xxxxxx XXX xxxx xxxx XxxxxxX](tutorial--create-your-first-metro-style-directx-game.md)
-   [Xxxxx xxx xxxxx](working-with-audio-in-your-directx-game.md)
-   [Xxxx-xxxx xxxxxxxx xxx xxxxx](tutorial--adding-move-look-controls-to-your-directx-game.md)

 

 




<!--HONumber=Mar16_HO1-->
