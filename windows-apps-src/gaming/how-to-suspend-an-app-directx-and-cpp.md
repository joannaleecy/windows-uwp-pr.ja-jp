---
xxxxx: Xxx xx xxxxxxx xx xxx (XxxxxxX xxx X++)
xxxxxxxxxxx: Xxxx xxxxx xxxxx xxx xx xxxx xxxxxxxxx xxxxxx xxxxx xxx xxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.
xx.xxxxxxx: YxxYYYxY-xxYx-YYYY-xxxY-YxYxYYYxYYYx
---

# Xxx xx xxxxxxx xx xxx (XxxxxxX xxx X++)


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxx xxxxx xxx xx xxxx xxxxxxxxx xxxxxx xxxxx xxx xxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.

## Xxxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxx


Xxxxx, xxxxxxxx xx xxxxxx xxx [**XxxxXxxxxxxxxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br205860) xxxxx, xxxxx xx xxxxxx xxxx xxxx xxx xx xxxxx xx x xxxxxxxxx xxxxx xx x xxxx xx xxxxxx xxxxxx.

Xxx xxxx xxxx xx xxxx xxxxxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495) xxxxxx xx xxxx xxxx xxxxxxxx:

```cpp
void App::Initialize(CoreApplicationView^ applicationView)
{
  //...
  
    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

  //...
}
```

## Xxxx xxx xxx xxxx xxxxxx xxxxxxxxxx


Xxxx xxxx xxx xxxxxxx xxx [**XxxxXxxxxxxxxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br205860) xxxxx, xx xxx xxx xxxxxxxxxxx xx xxxx xxx xxxxxxxxx xxxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxx. Xxx xxx xxxxxx xxx xxx [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241622) xxxxxxx XXX xx xxxx xxxxxx xxxxxxxxxxx xxxx xxxxxxxxxxxxx. Xx xxx xxx xxxxxxxxxx x xxxx, xxxx xxx xxxxxxxx xxxx xxxxx xxxxxxxxxxx. Xxx'x xxxxxx xx xxxxxxx xxx xxxxx xxxxxxxxxx!

Xxx, xxxxxxxxx xxx xxxxxxxx. Xxxx xxx xxx xxxx xx xxxx xxxxxx.

```cpp
void App::OnSuspending(Platform::Object^ sender, SuspendingEventArgs^ args)
{
    // Save app state asynchronously after requesting a deferral. Holding a deferral
    // indicates that the application is busy performing suspending operations. Be
    // aware that a deferral may not be held indefinitely. After about five seconds,
    // the app will be forced to exit.
    SuspendingDeferral^ deferral = args->SuspendingOperation->GetDeferral();

    create_task([this, deferral]()
    {
        m_deviceResources->Trim();

        // Insert your code here.

        deferral->Complete();
    });
}
```

Xxxx xxxxxxxx xxxx xxxxxxxx xxxx Y xxxxxxx. Xxxxxx xxxx xxxxxxxx, xxx xxxx xxxxxxx x xxxxxxxx xx xxxxxxx [**XxxxxxxxxxXxxxxxxxx::XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224690), xxxxx xxxxxx xxx xxxxxxxxx. Xxxx xxxx xxx xxxxxxxxx xxx xxxx xxxxxxxxx, xxxx [**XxxxxxxxxxXxxxxxxx::Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224685) xx xxxx xxx xxxxxx xxxx xxxx xxx xx xxx xxxxx xx xx xxxxxxxxx. Xx xxx xx xxx xxxxxxx x xxxxxxxx, xx xx xxxx xxx xxxxx xxxxxx xxxx Y xxxxxxx xx xxxx xxx xxxx, xxxx xxx xx xxxxxxxxxxxxx xxxxxxxxx.

Xxxx xxxxxxxx xxxxxx xx xx xxxxx xxxxxxx xxxxxxxxx xx xxx [**XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) xxx xxx xxx'x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225). Xxxx xxxxxxxx xxxx xxx xx xxxxxxx xx xxx xx xxx xxxx [**XxxxXxxxxxxxxx::XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208215) xxxx xxxx xxx'x xxxx xxxx (xxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxx xx xxxx xxxx xxxxxxxx).

``` syntax
// This method is called after the window becomes active.
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
}
```

## Xxxx Xxxx()


Xxxxxxxx xx Xxxxxxx Y.Y, xxx XxxxxxX Xxxxxxx Xxxxx xxxx xxxx xxxx [**XXXXXXxxxxxY::Xxxx**](https://msdn.microsoft.com/library/windows/desktop/dn280346) xxxx xxxxxxxxxx. Xxxx xxxx xxxxx xxx xxxxxxxx xxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx xxxxxxxxx xxx xxx xxx, xxxxx xxxxxxx xxx xxxxxx xxxx xxx xxx xxxx xx xxxxxxxxxx xx xxxxxxx xxxxxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxx. Xxxx xx x xxxxxxxxxxxxx xxxxxxxxxxx xxx Xxxxxxx Y.Y.

```cpp
void App::OnSuspending(Platform::Object^ sender, SuspendingEventArgs^ args)
{
    // Save app state asynchronously after requesting a deferral. Holding a deferral
    // indicates that the application is busy performing suspending operations. Be
    // aware that a deferral may not be held indefinitely. After about five seconds,
    // the app will be forced to exit.
    SuspendingDeferral^ deferral = args->SuspendingOperation->GetDeferral();

    create_task([this, deferral]()
    {
        m_deviceResources->Trim();

        // Insert your code here.

        deferral->Complete();
    });
}

// Call this method when the app suspends. It provides a hint to the driver that the app 
// is entering an idle state and that temporary buffers can be reclaimed for use by other apps.
void DX::DeviceResources::Trim()
{
    ComPtr<IDXGIDevice3> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);

    dxgiDevice->Trim();
}
```

## Xxxxxxx xxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx


Xxxx xxxx xxx xxxxxxx xxx [**XxxxXxxxxxxxxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br205860) xxxxx, xx xxxx xxx xxx xxxxxxxxxxx xx xxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx. Xxxxxxxxxx xxxxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx xxxxx xx xxxxxx xxxx xxxxx xxxx xxx xxxxxx xxxx xxxxx xxxx xxx xxx'x xxxxx xxxx. Xxxx xxx xxx xx xxxxxxxxx xxxxx xxxxxxxxxxx, xx xxxxxx xxxx xxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx.

## Xxxxxxx


Xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xx xx xxx xxxxxxx. Xxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xxxx xx xx. Xxxx xxx xxxxxx xxxxxxx xxxx xxx, xxx xxxxxxx xx xxxx xxxxxxxxx xxx xxxx xxxxxxxxxx xx xxx xxxx xx xx xxx xxxxxx xxx xxxxxx xxxxxxxxx xxx xxx. Xxx xxxxxx xxxxxxxx xxx xxx xxxxxxx xxxxx xx xxxx xxx, xx xxxx xx xxxxxxx xx xxx xxxx xx xx xx'x xxxx xxxxxxx xx xxx xxxxxxxxxx.

Xxx xxxxxx xxxxxxxx xx xxxx xxxx xxx xxx xxx xxxx xx xxxxxx xxxxx xx'x xxxxxxxxx. Xxxxxxx, xx xxx xxxxxx xxxx xxx xxxx xxx xxxxxxxxx xx xxxx xxxx xxx xx xxxxxx, xxx xxxxxx xxxx xxxxxxxxx xxxx xxx. Xxxx xxx xxxx xxxxxxxx xxxx xx x xxxxxxxxx xxx xxxx xxx xxxx xxxxxxxxxx, xxx xxxxxx xxxxx xx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225018) xxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxxxxx xxxx xx xxx xxxxxxx xxx xxx **XxxxXxxxxxxxxxxXxxx::Xxxxxxxxx** xxxxx.

Xxx xxxxxx xxxxx'x xxxxxx xx xxx xxxx xx'x xxxxxxxxxx, xx xxxx xxx xxxx xxxx xxx xxxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx xxxx xx'x xxxxxxxxx, xxx xxxxxxx xxxx xxxx xxx xxx xx xxxxxxxxx xxxxx xxxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxx xx xxxxxx xx xxx (XxxxxxX xxx X++)](how-to-resume-an-app-directx-and-cpp.md)
* [Xxx xx xxxxxxxx xx xxx (XxxxxxX xxx X++)](how-to-activate-an-app-directx-and-cpp.md)

 

 




<!--HONumber=Mar16_HO1-->
