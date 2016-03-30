---
xxxxx: Xxxxxx xxx xxxx'x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxxxx
xxxxxxxxxxx: Xxx xxxxx xxxx xx xxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx XxxxxxX xxxx xx xxxxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxx xxxxxx xxxxxxxx xxxx Xxxxxxx.
xx.xxxxxxx: YxxxxYxx-xxYx-xYYx-YYxY-xxYxYxYYxxYx
---

#  Xxxxxx xxx xxxx'x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxxxx xxxx xx xxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx XxxxxxX xxxx xx xxxxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxx xxxxxx xxxxxxxx xxxx Xxxxxxx. Xxxx xxxxxxxx Xxxxxxx Xxxxxxx xxxxxxxxxx xxxx xxxxxxx/xxxxxx xxxxx xxxxxxxx, xxxxxx xxxxx, xxx xxxxxxxx, xxxx xx xxx xxxxxx, xxxxxxxxxxxx xxx xxxxxxxxxxx xxx xxx xxxx xxxxxxxxx. Xx xx xxxx xxx xxx xxxxxx xxxx xx xxxxxxxxxx, xxx xxx xx xxxxxxx xxx xxxx-xxxxx xxxxx xxxxxxx xxx xxx xxxxxx xxx xxxxxx xxxxxxxxxxx.

## Xxxxxxxxx


-   Xx xxx xx xxx xxxxxxxxx xxx x XXX XxxxxxX xxxx, xxx xxxxxxxxx xxx xxxxx xxxxxxx xxxx xxxxxxx xxx xxxxxxx xxxx xxxx.

## Xxxxxxxxxxxx xxx xxxxxxxx xxx xxxx xxxxxxxx


Xx xxx XXX XxxxxxX xxxx, xxx xxxx xxxxxx x xxxx xxxxxxxx xxxx xxx xxx xxxxxxxxx, xxx Xxxxxxx Xxxxxxx xxxxxx xxxx xxxxxxx xx xxxxxxxx xx xxxx xxxxxxx xxx, xxx xxx xx xxxxxx xxx xxxxxxxx xxxxxxxxx xx xxxxx. Xxxxxxx xxx Xxxxxxx Xxxxxxx, xxxx xxx xxx x xxxxxx xxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxxxx, xxx xxx xxxx xx xxxxxxx xxx xxxxxxxxx xxx xxxx xxx xxx xx xxxxxx xxxx.

Xx xx xxxxxxxxx xx [Xxxxxxx xx xxx xxxx xxxxxxx](tutorial--setting-up-the-games-infrastructure.md), Xxxxxxxxx Xxxxxx Xxxxxx YYYY xxxxxxxx xx xxxxxxxxxxxxxx xx x xxxxx xxxxxxxx xxx XxxxxxX xx xxx **XxxxxxYXXxxxxXxxxxxxx.xxx** xxxx xxxx xx xxxxxxxxx xxxx xxx xxxx xxx **XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx)** xxxxxxxx.

Xxx xxxx xxxxxxx xxxxx xxxxxxxxxxxxx xxx xxxxxxxx x xxxx xxxxxxxx xxx xxxxxxxx, xxx [Xxx xx xxx xx xxxx XXX xxxx X++ xxx XxxxxxX xx xxxxxxx x XxxxxxX xxxx](https://msdn.microsoft.com/library/windows/apps/hh465077).

Xxxxxxx xx xxx, xxx xxxx xxxxxxx xxx xxxxxxxxxxxxxx xxx Y xxxxxxx xxxx xxx xxx xxxxxxxxx xxxxx:

-   [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700495)
-   [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700509)
-   [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/hh700501)
-   [**Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505)
-   [**Xxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700523)

Xx xxx XxxxxxXYY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx, xxxxx Y xxxxxxx xxx xxxxxxx xx xxx **Xxx** xxxxxx xx [Xxx.x](#code_sample). Xxx'x xxxx x xxxx xx xxx xxx xxxx xxx xxxxxxxxxxx xx xxxx xxxx.

Xxx Xxxxxxxxxx xxxxxx xx xxx xxxx xxxxxxxx

```cpp
void App::Initialize(
    _In_ CoreApplicationView^ applicationView
    )
{
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    m_controller = ref new MoveLookController();
    m_renderer = ref new GameRenderer();
    m_game = ref new Simple3DGame();
}
```

Xxx xxx xxxxxxxxx xxxxx xxxxx **Xxxxxxxxxx**. Xxxxxxxxx, xx xx xxxxxxx xxxx xxxx xxxxxx xxxxxxx xxx xxxx xxxxxxxxxxx xxxxxxxxx xx x XXX xxxx, xxxx xx xxxxxxxx xxx xxxxxxxxxx xx xxx xxxx xxxxxx xxx xxxxxx xxxx xxxx xxx xxxx xxx xxxxxx x xxxxxx xxxxxxx (xxx x xxxxxxxx xxxxx xxxxxx) xxxxx.

Xxxx xxx xxxx xxx xx xxxxxxxxxxx, xx xxxxxxxxx xxxxxxxx xxxxxx xxx xxx xxxxxxxxxx xx xxxxx xxx xxxxxx xx xxxxx xxxxxxxxx xxxxx. Xx xxxx xxxxxxx xxx, xxxxxxxxxxxxx xxxxxxxxx xx xxx xxxx'x xxxxxxxx xxx xxxxx xxxxxxx. Xx xxxxxxx xxx xxxxxxx xx [Xxxxxxxx xxx xxxx xxxx xxxxxx](tutorial--defining-the-main-game-loop.md).

Xx xxxx xxxxx, xxx xxxx xxx xxx xxxxxx x xxxxxxx (xx xxxxxx) xxxxxxx, xxx xxx xxxxxx xxxxxxxxx xxx xxx xxxxxxxxxx, xxx xxxxxxxx, xxx xxx xxxx xxxxxx. Xxx xxxxx'x xx xxxxxx xx xxxx xxxx, xxx xxx xxxx xx xxxxxxxxxxxxx. Xxxxx'x x xxx xxxx xxxxxx xxxx xxxx xx xxxxxx!

Xxx XxxXxxxxx xxxxxx xx xxx xxxx xxxxxxxx

```cpp
void App::SetWindow(
    _In_ CoreWindow^ window
    )
{
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);

    DisplayProperties::LogicalDpiChanged +=
        ref new DisplayPropertiesEventHandler(this, &App::OnLogicalDpiChanged);

    m_controller->Initialize(window);

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    m_renderer->Initialize(window, DisplayProperties::LogicalDpi);
    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    ShowGameInfoOverlay();
}
```

Xxx, xxxx x xxxx xx xx xxxxxxxxxxxxxx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700509), xxx xxx xxxxxxxxx xxxxxxxx x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxx xxxx xxxxxxxxxx xxx xxxx'x xxxx xxxxxx, xxx xxxxx xxx xxxxxxxxx xxx xxxxxx xxxxxxxxx xx xxx xxxx. Xxxxxxx xxxxx'x x xxxxxx xx xxxx xxxx, xxx xxxx xxx xxx xxxxx xxxxxx xx xxx xxxxx xxxx xxxxxxxxx xxxxxxxxxx xxx xxxxxx: x xxxxxxx (xxxx xx xxxx xxxxx xxx xxxxx xxxxxxxx), xxx xxx xxxxx xxxxxx xxx xxxxxx xxxxxxxx, xxxxxxx, xxx XXX xxxxxxx (xx xxx xxxxxxx xxxxxx xxxxxxx).

Xxx xxxx xxx xxxx xxxxxxxxxxx xxx xxxxxxxxxx, xxxxxxx xxxxx'x x xxxxxx xx xxxxxxxx xxxx, xxx xxxxxxxxxxx xxx xxxx xxxxxx xxxxxx. Xx xxx xxxx xxxxx xxxx xxx xxxxxxxxxx (xxxxx, xxxxx, xx XXxx YYY xxxxxxxxxx).

Xxxxx xxx xxxxxxxxxx xx xxxxxxxxxxx, xxx xxx xxxxxxx xxx xxxxxxxxxxx xxxxx xx xxx xxxxx-xxxx xxx xxxxx-xxxxx xxxxxxx xx xxx xxxxxx xxx xxx xxxx xxx xxxxxx xxxxx xxxxxxxx, xxxxxxxxxxxx. Xxx xxxxxx xxxx xxx xxxxx-xxxx xxxxxxxxx, xxxxxxx xx xxx xxxx xx **XxxXxxxXxxx**, xx x xxxxxxx xxxxxxx xxx xxx xxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxx, xxx xxxx xx xxxx. Xxx xxxxx-xxxxx xxxxxxxxx, xxxxxxx xx xxx **XxxXxxxXxxx** xxxxxx, xx xxxx xx x xxxxxxx xxxxxx xx xxxx xxx xxxx.

Xx'x xxx xxxxxxxx xx xxxx xxxxxxxx.

Xxx Xxxx xxxxxx xx xxx xxxx xxxxxxxx

```cpp
void App::Load(
    Platform::String^ entryPoint
    )
{
    task<void>([this]()
    {
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // in which the m_renderer object was created because the D3D device context
        // can be accessed only on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();

        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // In the middle of a game, so spin up the async task to load the level.
            create_task([this]()
            {
                return m_game->LoadLevelAsync();

            }).then([this]()
            {
                // The m_game object may need to deal with D3D device context work, so
                // the finalizer code needs to run in the same thread
                // context as the m_renderer object was created because the D3D 
                // device context can  be accessed only on a single thread.
                m_game->FinalizeLoadLevel();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
    }, task_continuation_context::use_current());
}
```

Xxxxx xxx xxxx xxxxxx xx xxx, xxx xxx xxxxxxxxx xxxxx **Xxxx**. Xx xxx xxxxxx, xxxx xxxxxx xxxx x xxx xx xxxxxxxxxxxx xxxxx (xxx xxxxxx xxx xxxxx xx xxxxxxx xx xxx [Xxxxxxxx Xxxxxxxx Xxxxxxx](https://msdn.microsoft.com/library/windows/apps/dd492418.aspx)) xx xxxxxx xxx xxxx xxxxxxx, xxxx xxxxxxxx xxxxxxxxx, xxx xxxxxxxxxx xxx xxxx’x xxxxx xxxxxxx. Xx xxxxx xxx xxxxx xxxx xxxxxxx, xxx Xxxx xxxxxx xxxxxxxxx xxxxxxx xxx xxxxxx xxx xxx xx xxxxx xxxxxxxxxx xxxxx. Xx xxxx xxxxxx, xxx xxx xxxx xxxxxxxx x xxxxxxxx xxx xx xxx xxxxxxxx xxxxx xxxx.

Xx xxxxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxx, xxxxxxx xxxxxx xx xxx XxxxxxYX YY xxxxxx xxxxxxx xx xxxxxxxxxx xx xxx xxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxx xx, xxxxx xxxxxx xx xxx XxxxxxYX YY xxxxxx xxx xxxxxx xxxxxxxx xx xxxx-xxxxxxxx. Xxx **XxxxxxXxxxXxxxxxXxxxxxxxxXxxxx** xxxx xxxx xx x xxxxxxxx xxxxxx xxxx xxx xxxxxxxxxx xxxx (*XxxxxxxxXxxxxxXxxxXxxxxxXxxxxxxxx*), xxxxx xxxx xx xxx xxxxxxxx xxxxxx. Xx xxx x xxxxxxx xxxxxxx xxx xxxxxxx xxxxx xxxxxxxxx xxxx **XxxxXxxxxXxxxx** xxx **XxxxxxxxXxxxXxxxx**.

Xxxxx xx xxxxxx xxx xxxx’x xxxxxxx xxx xxxx xxx xxxxxxxx xxxxxxxxx, xx xxxxxxxxxx xxx xxxx'x xxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxxxxx (xxx xxxxxxx: xxxxxxx xxx xxxxxxx xxxx xxxxx, xxxxx xxxxxx, xxx xxxxxx xxxxxxxxx). Xx xxx xxxx xxxxx xxxxxxxxx xxxx xxx xxxxxx xx xxxxxxxx x xxxx, xx xxxx xxx xxxxxxx xxxxx (xxx xxxxx xxxx xxxxxx xxx xx xxxx xxx xxxx xxx xxxxxxxxx).

Xx xxx **Xxxx** xxxxxx, xx xx xxx xxxxxxxxx xxxxxxxxxxxx xxxxxx xxx xxxx xxxxxx, xxxx xxxxxxx xxx xxxxxxxx xxxxxx xx xxxxxx xxxxxx. Xx xxx xxxx xx xxx-xxxxx xxxx xxxx xx xxxxxx, xxxx xx x xxxxxx xxxxx xxx xx xxxxxx xxxx xx **XxxXxxxxx** xx **Xxxxxxxxxx**. Xxx xxxxx xxxxx xx xxxx xxxx xxx xxx xxxxxxx xx Xxxxxxx xxxxxxx xxxxxxxxxxxx xx xxx xxxx xxxx xxxx xxx xxxx xxxxxx xx xxxx xxxxx xxxxxxxxxx xxxxx. Xx xxxxxxx xxxxx xxxxxx—xx xxxxx xxx xxxx xx xxxxxxxxx — xxxx xxxxxxx xxxx xxxxx xxxx x xxxxxxxxx xxxxxxx xxxxxxxx xxx.

Xxxx xxxxxxxxxx xxxx xxx xxxx, xxxxxx xxxx xxxxxxx xxxx xxxxxx xxxxx xxxxxxx. Xxxx'x x xxxxxx xxxx xx xxxxx xxxxxxxxxxx xxx xxxx xxxxxx:

-   Xxx **Xxxxxxxxxx** xx xxxxxxxx xxxx xxxx xxxxxxx xxx xxxxxxx xx xxx xxxxx xxxxx xxxxxxxx.
-   Xxx **XxxXxxxxx** xx xxxxxx xxxx xxxx xxxxxx xxx xxxxxxx xxx xxxxxx-xxxxxxxx xxxxxx.
-   Xxx **Xxxx** xx xxxxxx xxx xxxxxxxxx xxxxx, xxx xx xxxxxxxx xxx xxxxx xxxxxxxx xx xxxxxxx xxx xxxxxxx xx xxxxxxxxx. Xx xxx xxxx xx xxxxxx xxx xxxxxxxxx xxxxx xx xxxx, xxxx xx xxxxxxxxxxxx xxxxxxxxx xxxxxx, xx xx xxxx xxx.

Xx, xxx xxxxxx xxxx xxxxxxx xx xxxxxxxx xx xxx xxxx'x xxxxx xxxxxxx xxx xxxx xx xx xxx xxxxxxxx xxxxxxxxxxxxx. Xx xxxxxxx xxx xxx xxxxxx xxx xxxxx xxxxxx. Xx xxxxxxxx x xxxxxx xx xxxxxxx xxxxxxx xx. Xxx xxxxxxxx xxxx xx xxx xxxxx xx xxx.

Xxx Xxx xxxxxx xx xxx xxxx xxxxxxxx

```cpp
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::Snapped:
                if (!m_renderNeeded)
                {
                    // The app is not currently the active window, so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // Otherwise, fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // Exiting due to window close.  Make sure to save the state.
}
```

Xxxx'x xxxxx xx xxx xx xxx xxxx xxxx xx xxx xxxx xxx. Xxxxxx xxx xxx Y xxxxxxx xxx xxx xxx xxxxx, xxx xxxx xxx xxxx xxx **Xxx** xxxxxx, xxxxxxxx xxx xxx!

Xx xxx xxxx xxxxxx, xx xxxxx x xxxxx xxxx xxxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxx xxx xxxx xxxxxx. Xxx xxxxxx xxxx xxxxxxxxxxx xx xxx xx xxx xxxxxx xx xxx xxxx xxxxxx xxxxx xxxxxxx:

-   Xxx xxxx xxxxxx xxxx xxxxxxxxxxx (xxxxx xxxxx) xx xxxxxxx. Xxxx xxxx xxxxxxx, xxx xxxx xxxxxxxx xxxxx xxxxxxxxxx xxx xxxxx xxx xxx xxxxxx xx xxxxx xx xxxxxx.
-   Xxxxxxxxx, xxx xxxx xxxxxxx xxx xxx xxxxx xxx xxxxxxx xxx xxxxxxxx xxx xxxxxxx.

Xxxx xxxx xxxx xxx xxxxx, xxx xxxx xxxxxx xxxxx xxxxx xx xxx xxxxxxx xxxxx xx xx xxxxxxx, xxx xx xxx xxxx xxxx [**XxxxXxxxxxXxxxxxxx.XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208215) xxxx xxx **XxxxxxxXxxXxXxxxxxx** xxxxxx. Xxxxx xxxxxxx xxx xxxxx xxxxxx xx xxxxxxxxxx xxxxxxx xxxxxx, xxxxx xxxxx xxxx xxxx xxxx xxxxxxxxxxxx, xx xxxxxx xx xxxxx xxxxxxxxx xxxx xxxx xxxxxxxx xxx xxx "xxxxxx".

Xx xxxxxx, xxxx xxx xxx xx xxx xxxxxxx, xxxxxxxxx xx xxxxxxx, xx xxx'x xxxx xx xx xxxxxxx xxx xxxxxxxxx xxxxxxx xx xxxxxxxx xxxxxxxx xxxx xxxx xxxxx xxxxxx. Xx xxxx xxxx xxxx xxx **XxxxxxxXxxXxxXxxXxxxxxx**, xxxxx xxxxxx xxxxx xx xxxx xx xxxxx, xxx xxxx xxxxxxxxx xxxx xxxxx xxx xxx xxxxxx xxxx xxxxxx xx xxx xxxxxxx xxxxx xxxxxx xxx xxxxxxxxxx xx xxx xxxxx. [
            **XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208215) xxxx xxxxxxxxxxx xxxxxxx xxxxx xxx xxxxx xxx xxxx xxxxxxxxx.

Xxx xxxx xx xxxxxxx! Xxx xxxxxx xxxx xx xxxx xx xxxxxxxxxx xxxxxxx xxxx xxxxxx xxx xxxxx xxxxxxxxxx xxx xxxxxxxxx. Xxx xxxxxxxx xxx xxxxx xxxxxxx xx xxx xxxx xxxx xxxxxx. Xx xxxx xxx xxxxxx xx xxxxxx xxx. Xxx xxxxxxxxxx, xxx xxx xxx xx xxx...

...xxx xx xxxx xx xxxxx xx xxx xxxxx. Xxxx xx xxxxx **Xxxxxxxxxxxx** xxxxx xx.

Xxx Xxxxxxxxxxxx xxxxxx xx xxx xxxx xxxxxxxx

```cpp
void App::Uninitialize()
{
}
```

Xx xxx xxxx xxxxxx, xx xxx xxx xxx xxxxxxxxx xxx xxx xxxx xxxxx xxxxxxxxxx xx xxxxx xxx xxxx xx xxxxxxxxxx. Xx Xxxxxxx YY, xxxxxxx xxx xxx xxxxxx xxxxx'x xxxx xxx xxx'x xxxxxxx, xxx xxxxxxx xxxxxx xxx xxxxx xx xxx xxx xxxxxxxxx xx xxxxxx. Xx xxxxxxxx xxxxxxx xxxx xxxxxx xxxx xxx xxxxxx xxxx xxxxxxx xxxx xxxxxx, xxx xxxxxxx xxxxxxx xx xxxxxxxxx, xxxx xxx xxx xxxx xxx xxxx xxxxxxx xx xxxx xxxxxx.

Xx xxxxx xxxx xx xxxxx Y xxxxxxx xx xxxx xxxxxxxx, xx xxxx xxxx xx xxxx. Xxx, xxx'x xxxx xx xxx xxxx xxxxxx'x xxxxxxx xxxxxxxxx xxx xxx xxxxx xxxxxxxx xxxx xxxxxx xx.

## Xxxxxxxxxxxx xxx xxxx xxxxxx xxxxx


Xxxxxxx x xxxx xxx xxxxxx x XXX xxxx xxx xxxx x xxxxxxxxx xxxxx xx xxx xxxx, xxx xxx xxx xxxx xxx xxxxxx xx xxxxxxxx xxxxxx.

Xxx xxxx xxxxxx xxx xx xx xxx xx xxx xxxxx xxxxxx xxxx xx xxxxxx:

-   Xxx xxxx xxxx xxx xxxxxxx xxx xxx xx xxx xxxxxx xx x xxxxx.
-   Xxx xxxx xxxx xxx xxx xxxxxxx xxxxxxx x xxxx xxx xxxx xxxx xxxxxxxxx. (Xxx xxxx xxxxx xx xxx.)
-   Xx xxxx xxx xxxx xxxxxxx, xx xxx xxxx xxx xxxxxxx xxxxxx. (Xxx xxxx xxxxx xx Y.)

Xxxxxxxxx, xx xxxx xxx xxxx, xxx xxxxx xxxx xxxx xx xxxxx xxxxxx. Xxxxx, xxxxxx xx xxxxx xxxx xxxx XXX xxxx xxx xx xxxxxxxxxx xx xxx xxxx, xxx xxxx xx xxxxxxx, xxx xxxxxx xxxxxxx xxx xxxx xx xxxxxx xx xxxxxx xxxx xxx xxxxx xxxxxxx xxxxxxx.

Xx xxx xxxx xxxxxx, xxx xxxx xxxx xxxxx xxxx xxxx.

```cpp
void App::InitializeGameState()
{
    //
    // Set up the initial state machine for handling game playing state.
    //
    if (m_game->GameActive() && m_game->LevelActive())
    {
        m_updateState = UpdateEngineState::WaitingForResources;
        // ...

    }
    else if (!m_game->GameActive() && (m_game->HighScore().totalHits > 0))
    {
        m_updateState = UpdateEngineState::WaitingForPress;
        // ...
    }
    else
    {
        m_updateState = UpdateEngineState::WaitingForResources;
        // ...
    }
    SetAction(GameInfoOverlayCommand::PleaseWait);
    ShowGameInfoOverlay();
}
```

Xxxxxxxxxxxxxx xx xxxx xxxxx xxxx xxxxxxxx xxx xxx, xxx xxxx xxxxx xxxxxxxxxx xxx xxx xxxxx xx xxx xxxx xxxxxxxxxx. Xxx xxxxxx xxxx xxxxxx xxxxx xxxxx, xxxxx xxxxx xxx xxxxxxxxxx xxxx xxx xxx xx xxxxxx xxxxxxx. Xxx xxxxxxxxx xxxxx xx xxxx xxxx: xxx xxxx xxxx xx xxxxxxxxx, xxx xxx xxxxxxxxx xx xxx xxxx xxx xxxxx xx xxxxxx. Xxxxxxxx, xxx xxxxxx xxxxx xxxxxxxxx xxxx xxx xxxxxx xxxx xx xxxxxxx xx xxxxx xx xxx xxxx xxxxxxxxx xx xxxxxxxxxx. Xxxx xxx xxxxxx xxxx xxxxxxxx xxxxx xxxxxxxxxxx, xx xxxxxx xx xxxxxxxx xxx xxxx xxxxxxxxxx xxx xxxx xxxxx xxxxx xx xxx xxxxxx xxx xxxxxxxxxxx xxxxxxxx xxxxxxx.

Xxx xxxxxxxxx xxxx xxx xxx xxxxxxx xxxxxx xxx xxxxxxxxxxx xxx xxx xxxx xxxxxx'x xxxxxxxxxxxxxx xxxxxxx.

![xxx xxxxxxx xxx xxxxxxxxxxxx xxx xxxxxxxxx xxx xxxx xxxxxx xxx xxxx xxxx xxxxxx](images/simple3dgame-appstartup.png)

Xxxxxxxxx xx xxx xxxxx, xxxxxxxxx xxxxxxx xxx xxxxxxxxx xx xxx xxxxxx. Xx xxx xxxx xxxxxxx xxx-xxxxx, xx xxxxxxx xx xxxxxx, xxx xxx xxxxxxx xxxxxxxx x xxxxxxxx xxxxxx. Xx xxx xxxx xxxxxxx xx x xxxxx xxxxx xxx xxxx xx xxxxxxxxx, xx xxxxxxxx xxx xxxx xxxxxx xxx xx xxxxxx xx xxxx x xxx xxxx. Xxxxxx, xx xxx xxxx xxxxxxx xxxxxx x xxxxx xxx xxxxxxx, xxx xxxxxxx xxxxxxxx x xxxxx xxxxxx xx xxx xxxx.

Xxx xxxx xxxxxx xxxxx'x xxxxxxxxxxx xxxxxxx xxx xxxx xxxxxx xxxx xxxxxxxx, xxxx xx x xxxx xxxx xx xxxxxxxxx xxx xxx xxxxx xxxx xxxxxxx x xxxxxxx xxxxx, xxx xxx xxxx xxxxxxxx xxxx x xxxxxxxxx xxxxx. Xxxx xx xxxxxx xxxxxx xxx xxx XXX xxx.

## Xxxxxxxx xxxxxx


Xxx xxxxxx xxxx xxxxxxxxxx x xxxxxx xx xxxxxxxx xxx xxxxxxxx xxxxxx xx **Xxxxxxxxxx**, **XxxXxxxxx**, xxx **Xxxx**. Xxx xxxxxxxx xxxxxxx xxxx xxxxx xxxx xxxxxxxxx xxxxxx, xxxxxxx xxx xxxx xxxxxx xxx xxxx xxxx xxxx xxxxxx xx xxx xxxx xxx xxxx xxxxxxxxx xx xxxxxxxx xxxxxxxxxxx. Xxx'xx xxxxx! Xxxxx xxxxxx xxx xxxxxxxxxxx xx x xxxxxx XXX xxx xxxxxxxxxx, xxx xxxxxxx x XXX xxx xxx xx xxxxxxxxx, xxxxxxxxxxx, xxxxxxx, xxxxxxx, xxxxxxxxx, xxxxxxxxx, xx xxxxxxx xx xxx xxxx, xxx xxxx xxxx xxxxxxxx xxx xxxxx xxxx xxxxxx xx xxxx xx xx xxx, xxx xxxxxx xxxx xx x xxx xxxx xxxxx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxxxxx xxx xxx xxxxxx.

Xxxx'x xxx xxxxx xxxxxxxx xx xxx xxxxxx, xxx xxx xxxxxx xxxx xxxxxx. Xxx xxx xxxx xxx xxxx xxxx xxx xxxxx xxxxx xxxxxxxx xx [Xxxxxxxx xxxx xxx xxxx xxxxxxx](#code_sample).

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Xxxxx xxxxxxx</th>
<th align="left">Xxxxxxxxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">XxXxxxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxxxxxxxXxxx::Xxxxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxx xxxx xxxxxxx xx xxx xxxxxxxxxx, xx xxx xxxx xxxxxx xx xxxxxxxxx.</td>
</tr>
<tr class="even">
<td align="left">XxXxxxxxxXxxXxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxxxxXxxxxxxxxx::XxxxxxxXxxXxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx XXX xxx xxx xxxx xxxx xxxxxx xxx xxxxxxx, xxx xxx xxxx xxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxxx.
<div class="alert">
<strong>Xxxx</strong>  [<strong>XxxxXxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxxxxx/xxYYYYYY) xxxxxxxxxxx xxx xx XXXx (Xxxxxx Xxxxxxxxxxx Xxxxxx), xx xx [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370987). Xx x xxxxxx, xxx xxxx xxxxxx XxxxxxYX xx xxx xxxxxx xx XXX xx xxxxxxx xxx YX xxxxxx xx xxxxxxxxxx xxxxxxxxx.
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left">XxXxxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxxxxxxx::Xxxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxxxxxxx xxx xxxx xxxx x xxxxxxxxx xxxxx.</td>
</tr>
<tr class="even">
<td align="left">XxXxxxxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxxxxxxx::Xxxxxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxxxx xxx xxxxx xx xxxx. Xx xxx Y xxxxxxx xx xxxx xxxxx xx xxxxxxx.</td>
</tr>
<tr class="odd">
<td align="left">XxXxxxxxxxxxXxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxx::XxxxxxxxxxXxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxx xxxxxxx xxxxxxxxxx, xxx xxx xxxxxx xxxxxx xxxxxxx xx xxxx xxxx xxxxxxxxx xx xxxxxxx xxx xxxxxxxx xxxxxxx.</td>
</tr>
<tr class="even">
<td align="left">XxXxxxxxXxxxxxxxxxXxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxx::Xxxxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx'x xxxx xxxxxx xxx xxxx xxxxxxxxxxx xx xxxxxxxxx, xx xx xxxx xxxxxx xxxxx xxx xxxxx xxx xxxx, xx xxxxxx xxxxx. Xx xxxx xxxxx, xxx xxxxxxx xxxxxxxxx xxxx xxx xxxx xx xxxxxx.</td>
</tr>
<tr class="odd">
<td align="left">XxXxxxxxXxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxx::Xxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxxxxx xxx xxxx xxxxxx xxx xxxxxxxx xxx xxxx.</td>
</tr>
<tr class="even">
<td align="left">XxXxxxxxXxxxXxxxxxx</td>
<td align="left">Xxxxxxx [<strong>XxxxXxxxxx::XxxxXxxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY). Xxx xxxx xxx xxxxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxx xxxxxxx xx xxxxxxxxxxx xxx xxxx xxxxxx, xxx xxxx xxxxxxx xxx xxxxxx xxxxxx.</td>
</tr>
</tbody>
</table>

 

Xxxx xxx xxxx xxxx xxxxxx xxxxx xxxxxx, xxxxxxx xxxx xxx xxxx xx XXX xxx xxxxxx.

## Xxxxxxxx xxx xxxx xxxxxx


Xxxxxx xxx xxxx xxxx xx **Xxx**, xxx xxxxxx xxx xxxxxxxxxxx x xxxxx xxxxx xxxxxxx xxx xxxxxxxx xxx xxx xxxxx xxxxxxx xxx xxxxxx xxx xxxx. Xxx xxxxxxx xxxxx xx xxxx xxxxx xxxxxxx xxxxx xxxx xxxxxxx x xxxx, xxxxxxx x xxxxxxxx xxxxx, xx xxxxxxxxxx x xxxxx xxxxx xxx xxxx xxx xxxx xxxxxx (xx xxx xxxxxx xx xxx xxxxxx).

Xx xxx xxxx xxxxxx, xxxxx xxx Y xxxxx xxxxxx (XxxxxxXxxxxxXxxxx) xxx xxxx xxx xx xx:

-   **Xxxxxxx xxx xxxxxxxxx**. Xxx xxxx xxxx xx xxxxxxx, xxxxxx xx xxxxxxxxxx xxxxx xxxxxxxxx (xxxxxxxxxxxx xxxxxxxx xxxxxxxxx) xxx xxxxxxxxx. Xxxx xxx xxxxx xxxxx xxx xxxxxxx xxxxxxxxx xxxxxxxxx, xx xxxxxxx xxx xxxxx xx **XxxxxxxxxXxxxxx**. Xxxx xxxxxxx xxxxxxx xxxxxxx xxxxxx xxxx xxx xxxxx xxxxx xx xxxx xxx xxxxxxxxx xxxx xxxx. Xx xxx xxxx xxxxxx, xx xxxxxxxx xxxx xxxxxxxx xxxxxxx xxx xxxxxx xxxxx'x xxxx xxx xxxxxxxxxx xxx-xxxxx xxxxxxxxx xx xxxx xxxx.
-   **Xxxxxxx xxx xxxxx**. Xxx xxxx xxxx xx xxxxxxx, xxxxxxx xxx xxxxxxxx xxxx xxxxx. Xxxx xxxxx xx x xxxxxx xxxxxx xx xxxx x xxxx, xxxxx x xxxxx, xx xxxxxxxx x xxxxx. Xxx xxxxxx xxxx xxxxxx xx xxxxx xxx-xxxxxx xx XxxxxXxxxxxXxxxx xxxxxxxxxxx xxxxxx.
-   **Xxxxxxxx**. Xxx xxxx xxxx xx xxxxxxx xxxx xxx xxxx xxxxxxx. Xxxxx xxx xxxx xx xxxxxxx, xxx xxxx xxxxxx xxx Y xxxxxxxxxx xxxx xx xxx xxxxxxxxxx xx: xxx xxxxxxxxxx xx xxx xxx xxxx xxx x xxxxx, xxx xxxxxxxxxx xx x xxxxx xx xxx xxxxxx, xx xxx xxxxxxxxxx xx xxx xxxxxx xx xxx xxxxxx.

Xxxx'x xxx xxxx xxxxxxxxx. Xxx xxxxxxxx xxxx xx xx [Xxxxxxxx xxxx xxx xxxx xxxxxxx](#code_sample).

Xxx xxxxxxxxx xx xxx xxxxx xxxxxxx xxxx xx xxxxxx xxx xxxx xxxxxx

```cpp
void App::Update()
{
    m_controller->Update();

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        // Waiting for initial load.  Display an update once per 60 updates.
        loadCount++;
        if ((loadCount % 60) == 0)
        {
            m_loadingCount++;
            SetGameInfoOverlay(m_gameInfoOverlayState);
        }
        break;

    case UpdateEngineState::ResourcesLoaded:
        switch (m_pressResult)
        {
        case PressResultState::LoadGame:
            // ...
            break;

        case PressResultState::PlayLevel:
            // ...
            break;

        case PressResultState::ContinueLevel:
            // ...
            break;
        }
        // ...
        break;

    case UpdateEngineState::WaitingForPress:
        if (m_controller->IsPressComplete() || m_pressComplete)
        {
            m_pressComplete = false;

            switch (m_pressResult)
            {
            case PressResultState::LoadGame:
                // ...
                break;

            case PressResultState::PlayLevel:
                // ...
                break;

            case PressResultState::ContinueLevel:
                // ...
                break;
            }
        }
        break;

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested() || m_pauseRequested)
        {
            // ...
        }
        else 
        {
            GameState runState = m_game->RunGame();
            switch (runState)
            {
            case GameState::TimeExpired:
                // ...
                break;

            case GameState::LevelComplete:
                // ...
                break;

            case GameState::GameComplete:
                // ...
                break;
            }
        }

        if (m_updateState == UpdateEngineState::WaitingForPress)
        {
            // transitioning state, so enable waiting for the press event
            m_controller->WaitForPress(m_game->GameInfoOverlayUpperLeft(), m_game->GameInfoOverlayLowerRight());
        }
        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // Transitioning state, so shut down the input controller until resources are loaded
            m_controller->Active(false);
        }

        break;
    }
}
```

Xxxxxxxx, xxx xxxx xxxx xxxxx xxxxxxx xxxxx xxxx xxxx:

![xxx xxxx xxxxx xxxxxxx xxx xxx xxxx](images/simple3dgame-mainstatemachine.png)

Xx xxxx xxxxx xxx xxxx xxxxx xxxxxx xx xxxx xxxxxx xx [Xxxxxxxx xxx xxxx xxxx xxxxxx](tutorial--defining-the-main-game-loop.md). Xxx xxx, xxx xxxxxxxxx xxxxxxxx xx xxxx xxxx xxxx xx x xxxxx xxxxxxx. Xxxx xxxxxxxx xxxxx xxxx xxxx xxxx xxxxxxxx xxxxxxxx xx xxxxxx xx, xxx xxx xxxxxxxxxxx xxxx xxx xxxxx xx xxxxxxx xxxx xx xxxxx xx xxxxxxxx xxxx xxxxx xx xxxxxx xxxxxxx (xxxx xx xxxxxxxx xxxxxxxx xxxxxxx). Xxxx xxx xxx xxxxxxxx xxxx xxxx, xxxx xxx x xxxxxxx xxxx xxx xxx xx xxx, xxxxxx xxxx xxx xxxxxxx xxx xxxxxxxx xxxxxxx xxx xxxx xx xxxxxx xxx xxxx xx x xxxx xxxxx. Xxxxx xxx xx xxxx xxxxxxxxxxx, xxx xxx xxxxx xxxxxxx xx x xxxxxxxx xxxx xx xxxxxxxxx xxxx xxxxxxxxxx xxx xxxx xx xxxx xxxxxxxxxx.

Xx xxxxxx, xx xxx xxx, xxxxx xxx xxxxx xxxxxxxx xxxxxx xxxxx xxxxxxxx. Xxxxx'x xxx xxx xxx xxxxxxxxxx, xxxx xxxxxxx xxx xx xxx xxxxxxxxxx xxxxxx xxx xxxxxx xxx xxxxxxxx. Xx xxx xxxxxxx, x xxxxx xx xxxx xxxx xx xxxx xxxxx. Xxxx xxxxx xxxxxxx xxxxx'x xxxx xxxx xx xx, xxxxxxx xx xxxxx xx x xxxxxx xxxxx; xx xxxxxxx xxxx xxx xxxxx xxxxxxx xxx xxx xxxxxxxxxx xxxx xxxxxx xxx xxxxxxxxxxx xxxx xxxxxx xxxxxxxx xxx xxxxxxxx xxxxxxxxx, xxx xxx xxxxxxxxxx xxxxxxxxx xxxxxxx. Xx xxxx xxxxx xxxxxxxx xxxxx xxxxxx xx [Xxxxxx xxxxxxxx](tutorial--adding-controls.md).

## Xxxxxxxx xxx xxxx xxxxxxxxx


Xx xxxx xx xxxx xxx xxxxxx xxxxxxxx xx xxx xxxxx xx xxx xxxxxx, xxx xxxxx xxx xx xxxxxx xxx xxxx-xxxxx xxxxx xxxxxxxxx xx xxx xxxxx xx xxx xxxx. Xxx xxxx xxxxx, xxxx xxxx xxxxxx xxxxxxxx, xxxx xx xxxx xxxx x xxxxx-xx xxxxxxx xxxx xxxxxxxx xxxxxxxxxxxxxxx xx xxxx xxxxx, xxx xxxxx xxxx-xxxxxxxx xxxx xxxx xx xxxxx, xx xxxx, xx xxx xxxxxx xx xxxxxxx xxxxxxxxx. Xx xxxx xxxx xxx xxxxxxx, xxxxxxx xx xx xxxxxxxx xxxxxxxx xxxx xxx xxxx xxxxxxxx xxxxxxxx xxx xxxxxx xx xxx xxx YX xxxxxxxxxx. Xx xxx xxxxxx xxxx, xx xxxxxx xxxx xxxxxxx xxxxx xxx XxxxxxYX XXXx. Xx xxx xxxx xxxxxx xxxx xxxxxxx xxxxx XXXX, xxxxx xx xxxxxxx xx [Xxxxxxxxx xxx xxxx xxxxxx](tutorial-resources.md).

Xxxxx xxx xxx xxxxxxxxxx xx xxx xxxx xxxxxxxxx:

-   Xxx xxxxx-xx xxxxxxx xxxx xxxxxxxx xxx xxxxx xxx xxxx xxxxx xxx xxxxxxx xxxxx xx xxxx xxxx.
-   Xxx xxxxx xxxxxx, xxxxx xx x xxxxx xxxxxxxxx xxxx xxxx xxxxxxxx xxxxxx xxx xxxxxx/xxxxxxxxx xxxxx xx xxx xxxx. Xxxx xx xxx xxxx xxxxxxx. Xx xxxxxxx xx xxxxxxx xx [Xxxxxx x xxxx xxxxxxxxx](tutorial--adding-a-user-interface.md).

Xxxxxxxxxxxxxx, xxx xxxxxxx xxx x xxxxx xxxxxxx xxx. Xxx xxxxxxx xxx xxxxxxx x xxxxx xxxxx xx xxxx xxxx xxxxxxx. Xx xx xxxxxxxxxxx x xxxxxx xx xxxxxx xxx xxxx xxxxx xxxx xxxxx xxxx xx xxxxxxx xx xxx xxxxxx xxxx xxx xxxx xx xxxxxx xx xxxxxxxxx.

Xxxx'x xxx xxx xxxx xxxxxx xxxxxxxxxx xxx xxxxxxx'x xxxxx xxxxxxx.

```cpp
void App::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {

    case GameInfoOverlayState::Loading:
        m_renderer->InfoOverlay()->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        // ...
        break;

    case GameInfoOverlayState::LevelStart:
        // ...
        break;

    case GameInfoOverlayState::GameOverCompleted:
        // ...
        break;

    case GameInfoOverlayState::GameOverExpired:
        // ...
        break;

    case GameInfoOverlayState::Pause:
        // ...
        break;
    }
}
```

Xxxxx xxx Y xxxxx xxxxxxx xxxx xxx xxxxxxx xxxxxxxx, xxxxxxxxx xx xxx xxxxx xx xxx xxxx xxxxxx: x xxxxxxxxx xxxxxxx xxxxxx xx xxx xxxxx xx xxx xxxx, x xxxx xxxx xxxxxx, x xxxxx xxxxx xxxxxxx xxxxxx, x xxxx xxxx xxxxxx xxxx xxx xx xxx xxxxxx xxx xxxxxxxx xxxxxxx xxxx xxxxxxx xxx, x xxxx xxxx xxxxxx xxxx xxxx xxxx xxx, xxx x xxxxx xxxx xxxxxx.

Xxxxxxxxxx xxxx xxxx xxxxxxxxx xxxx xxxx xxxx'x xxxxxxxx xxxxxxxx xxxxxx xxx xx xxxx xx xx xxxxxxxxxxx xx xxx xxxx'x xxxxxxxx xxxxxxxxx xxxxxx xxx xxxxxxxxx xxx xxxxxxxxxx xx xxxx xxxx'x xxxx xxxxxxxxxxxxx.

## Xxxx xxxxx


Xxxx xxxxxx xxx xxxxx xxxxxxxxx xx xxx xxxx xxxxxx, xxx xxxxxxxx x xxxx xxxxx xxx XXX xxxx xxx xxxxxxxxxxx xxxx XxxxxxX. Xx xxxxxx, xxxxx'x xxxx xx xx xxxx xxxx. Xx xxxx xxxxxx xxxxxxx xxx xxxxxxxx xx xxx xxxx. Xxx, xx xxxx xx xx-xxxxx xxxx xx xxx xxxx xxx xxx xxxxxxxxx, xxx xxx xxxxx xxxxxxxxx xxx xxxxxxxxxxx xx xxx xxxx xxxx xxxxxx. Xx xxxxxx xxxx xxxx xx [Xxxxxxxx xxx xxxx xxxx xxxxxx](tutorial--defining-the-main-game-loop.md).

Xx'x xxxx xxxx xx xxxxxxxx xxx xxxxxx xxxx'x xxxxxxxx xxxxxx xx xxxxxxx xxxxxx. Xxxx xxxx xx xxxxxxx xx [Xxxxxxxxxx xxx xxxxxxxxx xxxxxxxx](tutorial--assembling-the-rendering-pipeline.md).

## Xxxxxxxx xxxxxx xxxx xxx xxxx xxxxxxx


Xxx.x

```cpp
///// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include "Simple3DGame.h"

enum class UpdateEngineState
{
    WaitingForResources,
    ResourcesLoaded,
    WaitingForPress,
    Dynamics,
    Snapped,
    Suspended,
    Deactivated,
};

enum class PressResultState
{
    LoadGame,
    PlayLevel,
    ContinueLevel,
};

enum class GameInfoOverlayState
{
    Loading,
    GameStats,
    GameOverExpired,
    GameOverCompleted,
    LevelStart,
    Pause,
};

ref class App : public Windows::ApplicationModel::Core::IFrameworkView
{
internal:
    App();

public:
    // IFrameworkView Methods
    virtual void Initialize(_In_ Windows::ApplicationModel::Core::CoreApplicationView^ applicationView);
    virtual void SetWindow(_In_ Windows::UI::Core::CoreWindow^ window);
    virtual void Load(_In_ Platform::String^ entryPoint);
    virtual void Run();
    virtual void Uninitialize();

private:
    void InitializeGameState();

    // Event Handlers
    void OnSuspending(
        _In_ Platform::Object^ sender,
        _In_ Windows::ApplicationModel::SuspendingEventArgs^ args
        );

    void OnResuming(
        _In_ Platform::Object^ sender,
        _In_ Platform::Object^ args
        );

    void UpdateViewState();

    void OnWindowActivationChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::WindowActivatedEventArgs^ args
        );

    void OnWindowSizeChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::WindowSizeChangedEventArgs^ args
        );

    void OnWindowClosed(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::CoreWindowEventArgs^ args
        );

    void OnLogicalDpiChanged(
        _In_ Platform::Object^ sender
        );

    void OnActivated(
        _In_ Windows::ApplicationModel::Core::CoreApplicationView^ applicationView,
        _In_ Windows::ApplicationModel::Activation::IActivatedEventArgs^ args
        );

    void OnVisibilityChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::VisibilityChangedEventArgs^ args
        );

    void Update();
    void SetGameInfoOverlay(GameInfoOverlayState state);
    void SetAction (GameInfoOverlayCommand command);
    void ShowGameInfoOverlay();
    void HideGameInfoOverlay();
    void SetSnapped();
    void HideSnapped();

    bool                                                m_windowClosed;
    bool                                                m_renderNeeded;
    bool                                                m_haveFocus;
    bool                                                m_visible;

    MoveLookController^                                 m_controller;
    GameRenderer^                                       m_renderer;
    Simple3DGame^                                       m_game;

    UpdateEngineState                                   m_updateState;
    UpdateEngineState                                   m_updateStateNext;
    PressResultState                                    m_pressResult;
    GameInfoOverlayState                                m_gameInfoOverlayState;
    GameInfoOverlayCommand                              m_gameInfoOverlayCommand;
    uint32                                              m_loadingCount;
};

ref class Direct3DApplicationSource : Windows::ApplicationModel::Core::IFrameworkViewSource
{
public:
    virtual Windows::ApplicationModel::Core::IFrameworkView^ CreateView();
};
```

Xxx.xxx

```cpp
//--------------------------------------------------------------------------------------
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "App.h"

using namespace concurrency;
using namespace DirectX;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::Foundation;
using namespace Windows::Graphics::Display;
using namespace Windows::UI::Core;
using namespace Windows::UI::Input;
using namespace Windows::UI::ViewManagement;


App::App() :
    m_windowClosed(false),
    m_haveFocus(false),
    m_gameInfoOverlayCommand(GameInfoOverlayCommand::None),
    m_visible(true),
    m_loadingCount(0),
    m_updateState(UpdateEngineState::WaitingForResources)
{
}

//--------------------------------------------------------------------------------------

void App::Initialize(
    _In_ CoreApplicationView^ applicationView
    )
{
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    m_controller = ref new MoveLookController();
    m_renderer = ref new GameRenderer();
    m_game = ref new Simple3DGame();
}

//--------------------------------------------------------------------------------------

void App::SetWindow(
    _In_ CoreWindow^ window
    )
{
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    PointerVisualizationSettings^ visualizationSettings = PointerVisualizationSettings::GetForCurrentView();
    visualizationSettings->IsContactFeedbackEnabled = false;
    visualizationSettings->IsBarrelButtonFeedbackEnabled = false;

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);

    DisplayProperties::LogicalDpiChanged +=
        ref new DisplayPropertiesEventHandler(this, &App::OnLogicalDpiChanged);

    m_controller->Initialize(window);

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    m_renderer->Initialize(window, DisplayProperties::LogicalDpi);
    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::Load(
    _In_ Platform::String^ /* entryPoint */
    )
{
    create_task([this]()
    {
        // Asynchronously initialize the game class and load the renderer device resources.
        // By doing all this asynchronously, the game gets to its main loop more quickly
        // and loads all the necessary resources in parallel on other threads.
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // as the m_renderer object was created because the D3D device context
        // can ONLY be accessed on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();

        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // In the middle of a game, so spin up the async task to load the level.
            create_task([this]()
            {
                return m_game->LoadLevelAsync();

            }).then([this]()
            {
                // The m_game object may need to deal with D3D device context work, so
                // again the finalize code needs to run in the same thread
                // context as the m_renderer object was created because the D3D 
                // device context can ONLY be accessed on a single thread.
                m_game->FinalizeLoadLevel();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
    }, task_continuation_context::use_current());
}

//--------------------------------------------------------------------------------------

void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::Snapped:
                if (!m_renderNeeded)
                {
                    // The App is not currently the active window, so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // Otherwise, fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // Exiting due to window close.  Make sure to save state.
}

//--------------------------------------------------------------------------------------

void App::Uninitialize()
{
}

//--------------------------------------------------------------------------------------

void App::OnWindowSizeChanged(
    _In_ CoreWindow^ window,
    _In_ WindowSizeChangedEventArgs^ /* args */
    )
{
    UpdateViewState();
    m_renderer->UpdateForWindowSizeChange();

    // The location of the GameInfoOverlay may have changed with the size change, so update the controller.
    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    if (m_updateState == UpdateEngineState::WaitingForPress)
    {
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
    }
}

//--------------------------------------------------------------------------------------

void App::OnWindowClosed(
    _In_ CoreWindow^ /* sender */,
    _In_ CoreWindowEventArgs^ /* args */
    )
{
    m_windowClosed = true;
}

//--------------------------------------------------------------------------------------

void App::OnLogicalDpiChanged(
    _In_ Platform::Object^ /* sender */
    )
{
    m_renderer->SetDpi(DisplayProperties::LogicalDpi);

    // The GameInfoOverlay may have been recreated as a result of DPI changes, so
    // regenerate the data.
    SetGameInfoOverlay(m_gameInfoOverlayState);
    SetAction(m_gameInfoOverlayCommand);
}

//--------------------------------------------------------------------------------------

void App::OnActivated(
    _In_ CoreApplicationView^ /* applicationView */,
    _In_ IActivatedEventArgs^ /* args */
    )
{
    CoreWindow::GetForCurrentThread()->Activated +=
        ref new TypedEventHandler<CoreWindow^, WindowActivatedEventArgs^>(this, &App::OnWindowActivationChanged);
    CoreWindow::GetForCurrentThread()->Activate();
}

//--------------------------------------------------------------------------------------

void App::OnVisibilityChanged(
    _In_ CoreWindow^ /* sender */,
    _In_ VisibilityChangedEventArgs^ args
    )
{
    m_visible = args->Visible;
}

//--------------------------------------------------------------------------------------

void App::InitializeGameState()
{
    // Set up the initial state machine for handling the Game playing state.
    if (m_game->GameActive() && m_game->LevelActive())
    {
        // The last time the game terminated it was in the middle
        // of a level.
        // We are waiting for the user to continue the game.
        m_updateState = UpdateEngineState::WaitingForResources;
        m_pressResult = PressResultState::ContinueLevel;
        SetGameInfoOverlay(GameInfoOverlayState::Pause);
        SetAction(GameInfoOverlayCommand::PleaseWait);
    }
    else if (!m_game->GameActive() && (m_game->HighScore().totalHits > 0))
    {
        // The last time the game terminated the game had been completed.
        // Show the high score.
        // We are waiting for the user to acknowledge the high score and start a new game.
        // The level resources for the first level will be loaded later.
        m_updateState = UpdateEngineState::WaitingForPress;
        m_pressResult = PressResultState::LoadGame;
        SetGameInfoOverlay(GameInfoOverlayState::GameStats);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        SetAction(GameInfoOverlayCommand::TapToContinue);
    }
    else
    {
        // This is either the first time the game has run or
        // the last time the game terminated the level was completed.
        // We are waiting for the user to begin the next level.
        m_updateState = UpdateEngineState::WaitingForResources;
        m_pressResult = PressResultState::PlayLevel;
        SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
        SetAction(GameInfoOverlayCommand::PleaseWait);
    }
    ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::Update()
{
    static uint32 loadCount = 0;

    m_controller->Update();

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        // Waiting for the initial load.  Display an update once per 60 updates.
        loadCount++;
        if ((loadCount % 60) == 0)
        {
            m_loadingCount++;
            SetGameInfoOverlay(m_gameInfoOverlayState);
        }
        break;

    case UpdateEngineState::ResourcesLoaded:
        switch (m_pressResult)
        {
        case PressResultState::LoadGame:
            SetGameInfoOverlay(GameInfoOverlayState::GameStats);
            break;

        case PressResultState::PlayLevel:
            SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
            break;

        case PressResultState::ContinueLevel:
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            break;
        }
        m_updateState = UpdateEngineState::WaitingForPress;
        SetAction(GameInfoOverlayCommand::TapToContinue);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        ShowGameInfoOverlay();
        m_renderNeeded = true;
        break;

    case UpdateEngineState::WaitingForPress:
        if (m_controller->IsPressComplete())
        {
            switch (m_pressResult)
            {
            case PressResultState::LoadGame:
                m_updateState = UpdateEngineState::WaitingForResources;
                m_pressResult = PressResultState::PlayLevel;
                m_controller->Active(false);
                m_game->LoadGame();
                SetAction(GameInfoOverlayCommand::PleaseWait);
                SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                ShowGameInfoOverlay();

                m_game->LoadLevelAsync().then([this]()
                {
                    m_game->FinalizeLoadLevel();
                    m_updateState = UpdateEngineState::ResourcesLoaded;

                }, task_continuation_context::use_current());
                break;

            case PressResultState::PlayLevel:
                m_updateState = UpdateEngineState::Dynamics;
                HideGameInfoOverlay();
                m_controller->Active(true);
                m_game->StartLevel();
                break;

            case PressResultState::ContinueLevel:
                m_updateState = UpdateEngineState::Dynamics;
                HideGameInfoOverlay();
                m_controller->Active(true);
                m_game->ContinueGame();
                break;
            }
        }
        break;

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested())
        {
            m_game->PauseGame();
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            SetAction(GameInfoOverlayCommand::TapToContinue);
            m_updateState = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            ShowGameInfoOverlay();
        }
        else
        {
            GameState runState = m_game->RunGame();
            switch (runState)
            {
            case GameState::TimeExpired:
                SetAction(GameInfoOverlayCommand::TapToContinue);
                SetGameInfoOverlay(GameInfoOverlayState::GameOverExpired);
                ShowGameInfoOverlay();
                m_updateState = UpdateEngineState::WaitingForPress;
                m_pressResult = PressResultState::LoadGame;
                break;

            case GameState::LevelComplete:
                SetAction(GameInfoOverlayCommand::PleaseWait);
                SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                ShowGameInfoOverlay();
                m_updateState = UpdateEngineState::WaitingForResources;
                m_pressResult = PressResultState::PlayLevel;

                m_game->LoadLevelAsync().then([this]()
                {
                    m_game->FinalizeLoadLevel();
                    m_updateState = UpdateEngineState::ResourcesLoaded;

                }, task_continuation_context::use_current());
                break;

            case GameState::GameComplete:
                SetAction(GameInfoOverlayCommand::TapToContinue);
                SetGameInfoOverlay(GameInfoOverlayState::GameOverCompleted);
                ShowGameInfoOverlay();
                m_updateState  = UpdateEngineState::WaitingForPress;
                m_pressResult = PressResultState::LoadGame;
                break;
            }
        }

        if (m_updateState == UpdateEngineState::WaitingForPress)
        {
            // Transitioning state, so enable waiting for the press event.
            m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        }
        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // Transitioning state, so shut down the input controller until resources are loaded.
            m_controller->Active(false);
        }
        break;
    }
}

//--------------------------------------------------------------------------------------

void App::OnWindowActivationChanged(
    _In_ Windows::UI::Core::CoreWindow^ /* sender */,
    _In_ Windows::UI::Core::WindowActivatedEventArgs^ args
    )
{
    if (args->WindowActivationState == CoreWindowActivationState::Deactivated)
    {
        m_haveFocus = false;

        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // From Dynamic mode, when coming out of Deactivated rather than going directly back into game play
            // go to the paused state waiting for user input to continue.
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            ShowGameInfoOverlay();
            m_game->PauseGame();
            m_updateState = UpdateEngineState::Deactivated;
            SetAction(GameInfoOverlayCommand::None);
            m_renderNeeded = true;
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::Deactivated;
            SetAction(GameInfoOverlayCommand::None);
            ShowGameInfoOverlay();
            m_renderNeeded = true;
            break;
        }
        // Don't have focus, so shutdown input processing.
        m_controller->Active(false);
    }
    else if (args->WindowActivationState == CoreWindowActivationState::CodeActivated
        || args->WindowActivationState == CoreWindowActivationState::PointerActivated)
    {
        m_haveFocus = true;

        if (m_updateState == UpdateEngineState::Deactivated)
        {
            m_updateState = m_updateStateNext;

            if (m_updateState == UpdateEngineState::WaitingForPress)
            {
                SetAction(GameInfoOverlayCommand::TapToContinue);
                m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
            }
            else if (m_updateStateNext == UpdateEngineState::WaitingForResources)
            {
                SetAction(GameInfoOverlayCommand::PleaseWait);
            }
        }
    }
}

//--------------------------------------------------------------------------------------

void App::OnSuspending(
    _In_ Platform::Object^ /* sender */,
    _In_ SuspendingEventArgs^ args
    )
{
    // Save application state.
    // If your application needs time to complete a lengthy operation, it can request a deferral.
    // The SuspendingOperation has a deadline time. Make sure all your operations are complete by that time!
    // If the app doesn't return from this handler within five seconds, it will be terminated.
    SuspendingOperation^ op = args->SuspendingOperation;
    SuspendingDeferral^ deferral = op->GetDeferral();

    create_task([=]()
    {
        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // Game is in the active game play state, Stop Game Timer and Pause play and save the state.
            SetAction(GameInfoOverlayCommand::None);
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            m_game->PauseGame();
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            m_updateStateNext = m_updateState;
            break;

        default:
            // If it is any other state, don't save as the next state as they are transient states and have already set m_updateStateNext
            break;
        }
        m_updateState = UpdateEngineState::Suspended;

        m_controller->Active(false);
        m_game->OnSuspending();

        deferral->Complete();
    });
}

//--------------------------------------------------------------------------------------

void App::OnResuming(
    _In_ Platform::Object^ /* sender */,
    _In_ Platform::Object^ /* args */
    )
{
    if (m_haveFocus)
    {
        m_updateState = m_updateStateNext;
    }
    else
    {
        m_updateState = UpdateEngineState::Deactivated;
    }

    if (m_updateState == UpdateEngineState::WaitingForPress)
    {
        SetAction(GameInfoOverlayCommand::TapToContinue);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
    }
    m_game->OnResuming();
    ShowGameInfoOverlay();
    m_renderNeeded = true;
}

//--------------------------------------------------------------------------------------

void App::UpdateViewState()
{
    m_renderNeeded = true;

    if (ApplicationView::Value == ApplicationViewState::Snapped)
    {
        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // From Dynamic mode, when coming out of SNAPPED layout rather than going directly back into game play,
            // go to the paused state and wait for user input to continue.
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            SetAction(GameInfoOverlayCommand::TapToContinue);
            m_game->PauseGame();
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            // Avoid corrupting the m_updateStateNext on a transition from Snapped -> Snapped.
            // Otherwise, just cache the current state and return to it when leaving SNAPPED layout.

            m_updateStateNext = m_updateState;
            break;

        default:
            break;
        }

        m_updateState = UpdateEngineState::Snapped;
        m_controller->Active(false);
        HideGameInfoOverlay();
        SetSnapped();
    }
    else if (ApplicationView::Value == ApplicationViewState::Filled ||
        ApplicationView::Value == ApplicationViewState::FullScreenLandscape ||
        ApplicationView::Value == ApplicationViewState::FullScreenPortrait)
    {
        if (m_updateState == UpdateEngineState::Snapped)
        {

            HideSnapped();
            ShowGameInfoOverlay();
            m_renderNeeded = true;

            if (m_haveFocus)
            {
                if (m_updateStateNext == UpdateEngineState::WaitingForPress)
                {
                    SetAction(GameInfoOverlayCommand::TapToContinue);
                    m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
                }
                else if (m_updateStateNext == UpdateEngineState::WaitingForResources)
                {
                    SetAction(GameInfoOverlayCommand::PleaseWait);
                }

                m_updateState = m_updateStateNext;
            }
            else
            {
                m_updateState = UpdateEngineState::Deactivated;
                SetAction(GameInfoOverlayCommand::None);
            }
        }
    }
}

//--------------------------------------------------------------------------------------

void App::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {
    case GameInfoOverlayState::Loading:
        m_renderer->InfoOverlay()->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        m_renderer->InfoOverlay()->SetGameStats(
            m_game->HighScore().levelCompleted + 1,
            m_game->HighScore().totalHits,
            m_game->HighScore().totalShots
            );
        break;

    case GameInfoOverlayState::LevelStart:
        m_renderer->InfoOverlay()->SetLevelStart(
            m_game->LevelCompleted() + 1,
            m_game->CurrentLevel()->Objective(),
            m_game->CurrentLevel()->TimeLimit(),
            m_game->BonusTime()
            );
        break;

    case GameInfoOverlayState::GameOverCompleted:
        m_renderer->InfoOverlay()->SetGameOver(
            true,
            m_game->LevelCompleted() + 1,
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::GameOverExpired:
        m_renderer->InfoOverlay()->SetGameOver(
            false,
            m_game->LevelCompleted(),
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::Pause:
        m_renderer->InfoOverlay()->SetPause();
        break;
    }
}

//--------------------------------------------------------------------------------------

void App::SetAction (GameInfoOverlayCommand command)
{
    m_gameInfoOverlayCommand = command;
    m_renderer->InfoOverlay()->SetAction(command);
}

//--------------------------------------------------------------------------------------

void App::ShowGameInfoOverlay()
{
    m_renderer->InfoOverlay()->ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::HideGameInfoOverlay()
{
    m_renderer->InfoOverlay()->HideGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::SetSnapped()
{
    m_renderer->InfoOverlay()->SetPause();
    m_renderer->InfoOverlay()->ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::HideSnapped()
{
    m_renderer->InfoOverlay()->HideGameInfoOverlay();
    SetGameInfoOverlay(m_gameInfoOverlayState);
}

//--------------------------------------------------------------------------------------

IFrameworkView^ DirectXAppSource::CreateView()
{
    return ref new App();
}

//--------------------------------------------------------------------------------------

[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}

//--------------------------------------------------------------------------------------
```

 

 




<!--HONumber=Mar16_HO1-->
