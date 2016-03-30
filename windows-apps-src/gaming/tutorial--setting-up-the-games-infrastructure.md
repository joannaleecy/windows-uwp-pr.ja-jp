---
xxxxx: Xxx xx xxx xxxx xxxxxxx
xxxxxxxxxxx: Xxx xxxxx xxxx xx xxxxxxxxxx xxxx xxxx xx xx xxx xx x xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx xx xxxx x xxx xxxx xxx xxxxxxxx xxx xxxxxx xx xxxx xxxxxxxxxxxxxx xxxx xxx xxxx xx xx.
xx.xxxxxxx: YxxxYYxY-xxYY-xxxY-YYxY-xYYxxYYYYYxY
---

# Xxx xx xxx xxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxxxx xxxx xx xxxxxxxxxx xxxx xxxx xx xx xxx xx x xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx xx xxxx x xxx xxxx xxx xxxxxxxx xxx xxxxxx xx xxxx xxxxxxxxxxxxxx xxxx xxx xxxx xx xx. Xxx xxx xxxx xxxxxxxx x xxx xx xxxx xxx xxxxxx xx xxxxx xxx xxxxx xxxxxxxx xxx xxxxxxxxxxx xxx xxxxxxx xxxxxxxxxxxx xxx xxxx xxxxxxxxxxx. Xx xxxx xxx xxxxxxx xxx xxxxx xxx xxxxxxxxxxxxx xx x xxxxxx xxxx xxxxxxx.

## Xxxxxxxxx


-   Xx xxxxx xxx xx xxx xx x XxxxxxYX xxxx xxxxxxx xx Xxxxxx Xxxxxx.

## Xxxxxxx xx xxx xxxx xxxxxxx


Xxx xxx xxxxx x xxxx xxxx xxxxxxx, xxxx xxxx x xxxxx xxxx xxxxxx, x xxx xxxxxxx, xxx x xxx xxxx xx xxx xxxxxxxxxx. Xxx xxxx xxxxxxxx xxx'x xxx xxxx xxxxxxxxx xxx xx xxxx xxxx. Xx xxx'xx xxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxxxxx, xxx xxx xxx Xxxxxx Xxxxxx xxxxxxxx xxxx xx xxx xxxxxx? Xxxx'x xxxx xx xx xx xxx xxxx xxxxxxx xxx xx x xxxxxxx xxxxx.

## Y. Xxxx xxx xxxxx xxxxxxxx


X Xxxxxx Xxxxxx xxxxxxxx xx x xxxxxxxxxx xx xxxxxxxx xxx xxxx xxxxx xxxx xxxxxx x xxxxxxxx xxxx xx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxxxxx. Xx Xxxxxxxxx Xxxxxx Xxxxxx YYYY, xxx'xx xxxx x xxxxxx xx xxxxxxxxx xxxx xxx xxxxxxxxxxxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxxxxxx. Xx xxx xxx'x xxx x xxxxxxxx, xxx xxxx xxxxxxx xxxx xx xxx xxxxx xxxxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxx xxxxxxxx, xxxxx xxx xx x xxx xx x xxxxx xx x xxx xxxx xxxxxxxxx.

Xxx xxxxx xxxxxxxx xxx xxxx xxxxxxxx, xx xxx xxx xxxxxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx). Xx Xxxxxx Xxxxxx YYYY, xxxxx **Xxxx...** &xx; **Xxx Xxxxxxx**, xxx xxxx:

1.  Xxxx **Xxxxxxxxx**, xxxxxx **Xxxxxx X++**, **Xxxxxxx**, **Xxxxxxxxx**.
2.  Xx xxx xxxxxx xxxx, xxxxxx **XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx)**.
3.  Xxxx xxxx xxxx xxxxxxx x xxxx, xxx xxxxx **XX**.

![xxxxxxxxx xxx xxxxxxYx xxxxxxxxxxx xxxxxxxx](images/simple-dx-game-vs-new-proj.png)

Xxxx xxxxxxxx xxxxxxxx xxx xxxx xxx xxxxx xxxxxxxxx xxx x XXX xxx xxxxx XxxxxxX xxxx X++. Xx xx, xxxxx xxx xxx xx xxxx XY! Xxxxx xxx xxxx xxxxxx xxxx xxxxxx. Xxxx x xxxxxx xxx xxxxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxxx. Xxxx xxxxxxxx xxxxxxx xxxxxxxx xxxx xxxxx xxxxxxxxxx xxx xxxxx xxxxxxxxxxxxx xxx x XXX xxx xxxxx XxxxxxX xxxx X++. Xx xxxx xxxx xxxxx xxx xxxxx xxxx xxxxx xx [xxxx Y](#3-review-the-included-libraries-and-headers). Xxxxx xxx, xxx'x xxxxxxx xxxxxxx **Xxx.x**.

```cpp
    ref class App sealed : public Windows::ApplicationModel::Core::IFrameworkView
    {
    public:
        App();

        // IFrameworkView Methods.
        virtual void Initialize(Windows::ApplicationModel::Core::CoreApplicationView^ applicationView);
        virtual void SetWindow(Windows::UI::Core::CoreWindow^ window);
        virtual void Load(Platform::String^ entryPoint);
        virtual void Run();
        virtual void Uninitialize();

    protected:
        // Application lifecycle event handlers.
        void OnActivated(Windows::ApplicationModel::Core::CoreApplicationView^ applicationView, Windows::ApplicationModel::Activation::IActivatedEventArgs^ args);
        void OnSuspending(Platform::Object^ sender, Windows::ApplicationModel::SuspendingEventArgs^ args);
        void OnResuming(Platform::Object^ sender, Platform::Object^ args);

        // Window event handlers.
        void OnWindowSizeChanged(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::WindowSizeChangedEventArgs^ args);
        void OnVisibilityChanged(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::VisibilityChangedEventArgs^ args);
        void OnWindowClosed(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::CoreWindowEventArgs^ args);

        // DisplayInformation event handlers.
        void OnDpiChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
        void OnOrientationChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
        void OnDisplayContentsInvalidated(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);

    private:
        std::shared_ptr<DX::DeviceResources> m_deviceResources;
        std::unique_ptr<MyAwesomeGameMain> m_main;
        bool m_windowClosed;
        bool m_windowVisible;
    };
```

Xxx xxxxxx xxxxx Y xxxxxxx, [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495), [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700509), [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/hh700501), [**Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505), xxx [**Xxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700523), xxxx xxxxxxxxxxxx xxx [**XXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700469) xxxxxxxxx xxxx xxxxxxx x xxxx xxxxxxxx. Xxxxx xxxxxxx xxx xxx xx xxx xxx xxxxxxxxx xxxx xx xxxxxxx xxxx xxxx xxxx xx xxxxxxxx, xxx xxxx xxx xxxx xxx'x xxxxxxxxx xx xxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxx.

Xxxx **xxxx** xxxxxx xx xx xxx **Xxx.xxx** xxxxxx xxxx. Xx xxxxx xxxx xxxx:

```cpp
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

Xxxxx xxx, xx xxxxxxx xx xxxxxxxx xx xxx XxxxxxYX xxxx xxxxxxxx xxxx xxx xxxx xxxxxxxx xxxxxxx (**XxxxxxYXXxxxxxxxxxxXxxxxx**, xxxxxxx xx **Xxx.x**), xxx xxxxxx xx xx xxx xxx xxxxxxxxx xx xxx ([**XxxxXxxxxxxxxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700469)). Xxxx xxxxx xxxx xxx xxxxxxxx xxxxx xxx xxxx xxxx xxxxx xx xxx xxxx xx xxx xxxxxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxx, xx xxxx xxxx, **Xxx::Xxx**. Xxxx'x xxx xxxx:

```cpp
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

Xx xxx xxxxxx xxx xxxx xxxx xxx'x xxxxxx, xxxx xxxxxxxxxx xxx xxxxxx, xxxxxxx xxx xxxxx, xxx xxxxxxx xxx xxxxxxxx xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxx. Xx xxxx xxxxx xxxx xx xxxxxxx xxxxxx xx [Xxxxxxxx xxx xxxx'x XXX xxxxxxxxx](tutorial--building-the-games-metro-style-app-framework.md) xxx [Xxxxxxxxxx xxx xxxxxxxxx xxxxxxxx](tutorial--assembling-the-rendering-pipeline.md). Xx xxxx xxxxx, xxx xxxxxx xxxx x xxxxx xx xxx xxxxx xxxx xxxxxxxxx xx x XXX XxxxxxX xxxx.

## Y. Xxxxxx xxx xxxxxx xxx xxxxxxx.xxxxxxxxxxxx xxxx


Xxx xxxx xxxxx xxxx'x xxx xxxxx xx xx xxx xxxxxxxx. Xxx **xxxxxxx.xxxxxxxxxxxx** xxxx xxxxxxxx xxxxxxxx xxxxx xxxx xxxxxxx xxxx xxx xxxx xxx xxxxxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxx xxxxxxxxxx xx xxx Xxxxxxx Xxxxx. Xx xxxx xxxxxxxx xxxxxxxxx xxxx xxx xxxxxx'x xxxxxx xxxx xx xxxxxxx xxxxxx xx xxx xxxxxx xxxxxxxxx xxx xxxx xxxxx xx xxx.

Xxxxxx xxx **Xxxxxxxx Xxxxxxxx** xx xxxxxx-xxxxxxxx xxx **xxxxxxx.xxxxxxxxxxxx** xxxx xx **Xxxxxxxx Xxxxxxxx**. Xxx xxx xxxx xxxx:

![xxx xxxxxxx.xxxx xxxxxxxx xxxxxx.](images/simple-dx-game-vs-app-manifest.png)

Xxx xxxx xxxx xxxxx xxx **xxxxxxx.xxxxxxxxxxxx** xxxx xxx xxxxxxxxx, xxx [Xxxxxxxx Xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230259.aspx). Xxx xxx, xxxx x xxxx xx xxx **Xxxxxxxxxxxx** xxx xxx xxxx xx xxx xxxxxxx xxxxxxxx.

![xxx xxxxxxx xxxxxxxxxxxx xx x xxxxxxYx xxx.](images/simple-dx-game-vs-capabilities.png)

Xx xxx xxx'x xxxxxx xxx xxxxxxxxxxxx xxxx xxxx xxxx xxxx, xxxx xx xxxxxx xx xxx **Xxxxxxxx** xxx xxxxxx xxxx xxxxx xxxxx, xxx xxx'x xx xxxx xx xxxxxx xxx xxxxxxxxxxxxx xxxxxxxxx xx xxxxxxxx. Xxxx xxx xxxxxx x xxx xxxx, xxxx xxxx xxxx xxx xxxxxx xxx xxxxxxxxxxxx xxxx xxxx xxxx xxxxx xx xxx!

Xxx, xxx'x xxxx xx xxx xxxx xx xxx xxxxx xxxx xxxx xxxx xxx **XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx)** xxxxxxxx.

## Y. Xxxxxx xxx xxxxxxxx xxxxxxxxx xxx xxxxxxx


Xxxxx xxx x xxx xxxxx xx xxxxx'x xxxxxx xx xxx. Xxxxx xxxxx xxxxxxx xxxxxxxxxx xxxxx xxx xxxxxxx xxxxxx xx XxxxxxYX xxxx xxxxxxxxxxx xxxxxxxxx.

| Xxxxxxxx Xxxxxx Xxxx         | Xxxxxxxxxxx                                                                                                                                                                                                            |
|------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| XxxxXxxxx.x                  | Xxxxxxx x xxxx-xxxxxxxxxx xxxxx xxxxxx xxx xxxxxx xx xxxxxxxxxxx xxxxxxxxx xxxx.                                                                                                                                       |
| XxxxxxYXXxxxxXxxxxxxx.x/.xxx | Xxxxxxx x xxxxx xxxxxxxx xxxxxxxxxxxxxx xxxx xxxxxxxx x XxxxxxYX xxxx xxxxx xxx xxxxxxxx xxxxxxx xx xxxx XXX xxxxx XxxxxxX.                                                                                            |
| XxxxxxXXxxxxx.x              | Xxxxxxxxxx x xxxxxx xxxxxx, **XX::XxxxxXxXxxxxx**, xxxx xxxxxxxx xxx xxxxx XXXXXXX xxxxxx xxxxxxxx xx XxxxxxX XXXx xxxx Xxxxxxx Xxxxxxx xxxxxxxxxx. Xxx xxxx xxxxxx xx xxx x xxxxx xxxxx xxx xxxxxxxxx XxxxxxX xxxxxx. |
| xxx.x/.xxx                   | Xxxxxxxx xxx xxx Xxxxxxx xxxxxx xxxxxxxx xxx xxx XXXx xxxx xx x XxxxxxYX xxx, xxxxxxxxx xxx XxxxxxX YY XXXx.                                                                                                           |
| XxxxxxXxxxxXxxxxx.xxxx       | Xxxxxxxx xxx xxxx-xxxxx xxxxxx xxxxxxxx (XXXX) xxxx xxx x xxxx xxxxx xxxxx xxxxxx.                                                                                                                                     |
| XxxxxxXxxxxxXxxxxx.xxxx      | Xxxxxxxx xxx xxxx-xxxxx xxxxxx xxxxxxxx (XXXX) xxxx xxx x xxxx xxxxx xxxxxx xxxxxx.                                                                                                                                    |

 

### Xxxx xxxxx

Xx xxxx xxxxx, xxx xxx xxxxxx x XXX xxxx XxxxxxX xxxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxx xxxxxxxx xx xxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx.

Xx xxx xxxx xxxxxxxx, [Xxxxxxxx xxx xxxx'x XXX xxxxxxxxx](tutorial--building-the-games-metro-style-app-framework.md), xx xxxx xxxx x xxxxxxxxx xxxx xxx xxxxxxx xxx xx xxxx xxx xxxxxxx xxxx xx xxx xxxxxxxx xxx xxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
