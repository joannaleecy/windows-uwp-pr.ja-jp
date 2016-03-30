---
xxxxx: Xxx xx xxxxxxxx xx xxx (XxxxxxX xxx X++)
xxxxxxxxxxx: Xxxx xxxxx xxxxx xxx xx xxxxxx xxx xxxxxxxxxx xxxxxxxxxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.
xx.xxxxxxx: xYYxYxxY-YxYx-YxYY-YxYY-YYYYxxYYYxYY
---

# Xxx xx xxxxxxxx xx xxx (XxxxxxX xxx X++)


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxx xxxxx xxx xx xxxxxx xxx xxxxxxxxxx xxxxxxxxxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.

## Xxxxxxxx xxx xxx xxxxxxxxxx xxxxx xxxxxxx


Xxxxx, xxxxxxxx xx xxxxxx xxx [**XxxxXxxxxxxxxxxXxxx::Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225018) xxxxx, xxxxx xx xxxxxx xxxx xxxx xxx xx xxxxxxx xxx xxxxxxxxxxx xx xxx xxxxxxxxx xxxxxx.

Xxx xxxx xxxx xx xxxx xxxxxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495) xxxxxx xx xxxx xxxx xxxxxxxx (xxxxx **XxXxxxXxxxxxxx** xx xxx xxxxxxx):

```cpp
void App::Initialize(CoreApplicationView^ applicationView)
{
    // Register event handlers for the app lifecycle. This example includes Activated, so that we
    // can make the CoreWindow active and start rendering on the window.
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);
  
  //...

}
```

## Xxxxxxxx xxx XxxxXxxxxx xxxxxxxx xxx xxx xxx


Xxxx xxxx xxx xxxxxx, xxx xxxx xxxxxx x xxxxxxxxx xx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxx xxxx xxx. **XxxxXxxxxx** xxxxxxxx xxx xxxxxx xxxxx xxxxxxx xxxxxxxxxx xxxx xxxx xxx xxxx xx xxxxxxx xxxxxx xxxxxx. Xxxxxx xxxx xxxxxxxxx xx xxxx xxxxxxxx xxx xxx xxx xxxxxxxxxx xxxxx xx xxxxxxx [**XxxxXxxxxx::XxxXxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701589). Xxxx xxx xxxx xxxxxxxx xxxx xxxxxxxxx, xxxxxxxx xxx xxxx xxx xxxxxx xx xxxxxxx [**XxxxXxxxxx::Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208254).

```cpp
void App::OnActivated(CoreApplicationView^ applicationView, IActivatedEventArgs^ args)
{
    // Run() won't start until the CoreWindow is activated.
    CoreWindow::GetForCurrentThread()->Activate();
}
```

## Xxxxx xxxxxxxxxx xxxxx xxxxxxx xxx xxx xxxx xxx xxxxxx


Xxxx xxxxxxxxx xxxxx xx xxxxx xxxxxxxx xxx xxxxxxxxx xx xxx [**XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) xxx xxx xxx'x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225). Xxxx xxxxxxxx xxxx xxx xx xxxxxxx xx xxx xx xxx xxxx [**XxxxXxxxxxxxxx::XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208215) xxxx xxxx xxx'x xxxx xxxx (xxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxx xx xxxx xxxx xxxxxxxx).

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

## Xxxxxxx xxxxxx


* [Xxx xx xxxxxxx xx xxx (XxxxxxX xxx X++)](how-to-suspend-an-app-directx-and-cpp.md)
* [Xxx xx xxxxxx xx xxx (XxxxxxX xxx X++)](how-to-resume-an-app-directx-and-cpp.md)

 

 




<!--HONumber=Mar16_HO1-->
