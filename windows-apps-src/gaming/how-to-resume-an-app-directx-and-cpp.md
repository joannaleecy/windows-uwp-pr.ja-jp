---
xxxxx: Xxx xx xxxxxx xx xxx (XxxxxxX xxx X++)
xxxxxxxxxxx: Xxxx xxxxx xxxxx xxx xx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.
xx.xxxxxxx: YxYxxYYY-YYYY-xxxY-YYxx-xYYxYYYxYYYY
---

# Xxx xx xxxxxx xx xxx (XxxxxxX xxx X++)


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxx xxxxx xxx xx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxx.

## Xxxxxxxx xxx xxxxxxxx xxxxx xxxxxxx


Xxxxxxxx xx xxxxxx xxx [**XxxxXxxxxxxxxxx::Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br205859) xxxxx, xxxxx xxxxxxxxx xxxx xxx xxxx xxxxxxxx xxxx xxxx xxxx xxx xxx xxxx xxxx xx xx.

Xxx xxxx xxxx xx xxxx xxxxxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495) xxxxxx xx xxxx xxxx xxxxxxxx:

```cpp
// The first method is called when the IFrameworkView is being created.
void App::Initialize(CoreApplicationView^ applicationView)
{
  //...
  
    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);
    
  //...

}
```

## Xxxxxxx xxxxxxxxx xxxxxxx xxxxx xxxxxxxxxx


Xxxx xxxx xxx xxxxxxx xxx Xxxxxxxx xxxxx, xx xxx xxx xxxxxxxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx. Xxxxxxx xxx xxx xxx xxxx xxxxx xxxx xxxx xxxxxxx xxx [**XxxxXxxxxxxxxxx::Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br205860), xxx xxxxxxx xxxxxxxxxx. Xxxx xxxx: xx xxx'xx xxxxxxxxx xxxx xxxxx xxxxxx, xxx'x xxx xxxx xx xxxxxxx xx.

```cpp
void App::OnResuming(Platform::Object^ sender, Platform::Object^ args)
{
    // Restore any data or state that was unloaded on suspend. By default, data
    // and state are persisted when resuming from suspend. Note that this event
    // does not occur if the app was previously terminated.

    // Insert your code here.
}
```

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

## Xxxxxxx


Xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xx xx xxx xxxxxxx. Xxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xxxx xx xx. Xxxx xxx xxxxxx xxxxxxx xxxx xxx, xxx xxxxxxx xx xxxx xxxxxxxxx xxx xxxx xxxxxxxxxx xx xxx xxxx xx xx xxx xxxxxx xxx xxxxxx xxxxxxxxx xxx xxx. Xxx xxxxxx xxxxxxxx xxx xxx xxxxxxx xxxxx xx xxxx xxx, xx xxxx xx xxxxxxx xx xxx xxxx xx xx xx'x xxxx xxxxxxx xx xxx xxxxxxxxxx. Xxxxxxx, xxx xxx xxx xxxx xxxx xxxxxxxxx xxx x xxxxxxxxxxx xxxxxx xx xxxx, xx xx xxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxx xxxx xxxxxxx xxxxx xxx xxx xxx xxxxxxxxx, xxx xxxxxxx xxx xxxxxxxxx xx xxxxx xxxxxxxxxx xxxxxxx. Xx xxx'xx xxxxx xxx xxxx xxxxx xxxx xxxxxx x xxxxxxxx xxxxxxx xxxxx, xxxxxxx xx xxx.

## Xxxxxxx xxxxxx

* [Xxx xx xxxxxxx xx xxx (XxxxxxX xxx X++)](how-to-suspend-an-app-directx-and-cpp.md)
* [Xxx xx xxxxxxxx xx xxx (XxxxxxX xxx X++)](how-to-activate-an-app-directx-and-cpp.md)

 

 




<!--HONumber=Mar16_HO1-->
