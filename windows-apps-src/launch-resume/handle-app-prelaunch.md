---
xxxxx: Xxxxxx xxx xxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxxxxx xx xxxxxxxxxx xxx XxXxxxxxxx xxxxxx.
xx.xxxxxxx: XYYYYXXY-YYXY-YYXX-YXXY-XYXYYYXYYXYY
---

# Xxxxxx xxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335)

Xxxxx xxx xx xxxxxx xxx xxxxxxxxx xx xxxxxxxxxx xxx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxxxx.

## Xxxxxxxxxxxx


Xxxx xxxxxxxxx xxxxxx xxxxxxxxx xxxxx, xxx xxxxxxx xxxxxxxxxxx xx Xxxxxxx Xxxxx xxxx xx xxxxxxxx xx xxxxxxxxxxx xxxxxxxxx xxx xxxx’x xxxx xxxxxxxxxx xxxx xxxx xx xxx xxxxxxxxxx. X xxxxxxxxxxx xxx xx xxx xxxx xxx xxxxxxxxx xxxxx xxxxxxx xxxxx xx xx xxxxxxxx. Xxxx xxx xxxx xxxxxxx xxx xxx, xxx xxx xx xxxxxxx xx xxxxxxxx xx xxxx xxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxx--xxxxx xx xxxxxx xxxx xxxxxxxxx xxx xxx xxxx.

Xxxxx xx Xxxxxxx YY, xxxx xxx xxx xxxxxxxxxxxxx xxxx xxxxxxxxx xx xxxxxxxxx. Xxxxxxxx xx Xxxxxxx YY, xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxxxxxxxxxx xxxx xxxxxxxxx xx xxxxxxxxx.

Xxxx xxxx xxxxxx xxxx xxxx xxxxxxxxx xxxxxxx xxx xxxxxx. Xxxxxxx, xxxx xxxxx xx xxxx xxx xxxx xx xxxxxx xxxxx xxxxxxx xxxxxxxx xx xxxx xxxx xxxx xxxxxxxxx. Xxx xxxxxxx, x xxxxxxxxx xxx xxxx xxxxxxx xxx xxxxx'x xxxxxx xxxxxxxxxx xxxxxx xxxxxxx, xx x xxxx xxxxx xxxxxxx xxx xxxx xx xxxxxxx xxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xxx xxx xxxxxx xx.

## Xxxxxxxxx xxx xxx xxxxxxxxx


Xxxx xx xxx xx xxxxxxxxxxx, xx xxxx xxxxxx xxx xxxxxxxxx xxxxx. (xxx [Xxxxxx xxx xxxxxxx](suspend-an-app.md)).

## Xxxxxx xxx xxxxxx xxxxxxxxx


Xxxx xxxxxxx xxx [**XxxxxxXxxxxxxxxXxxxxXxxx.XxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263740) xxxx xxxxxx xxxxxxxxxx. Xxx xxxx xxxx xx xxxxxxxxx xxxxxxx xx xxxxxxx xxxxxxxxxx xxxx xxxxxx xxxx xx xxxxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxxxxx xxx xxx xx xxxxx xx xxx xxxxxxxxx xxxxxxx xxxx[**Xxxxxxxxxxx.XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335).

```cs
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content - rather just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }

        if (!e.PrelaunchActivated)
        {
            // TODO: This is not a prelaunch activation. Perform operations which
            // assume that the user explicitly launched the app such as updating
            // the online presence of the user on a social network, updating a 
            // what&#39;s new feed, etc.
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }

    if (rootFrame.Content == null)
    {
        // When the navigation stack isn&#39;t restored navigate to the first page,
        // configuring the new page by passing required information as a navigation parameter
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
    }
    // Ensure the current window is active
    Window.Current.Activate();
}
```

**Xxx**  Xx xxx xxxx xx xxx-xxx xx xxxxxxxxx, xxxxx xxx [**XxxxxxXxxxxxxxxXxxxxXxxx.XxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263740) xxxx. Xx xx xx xxx, xxxxxx xxxx XxXxxxxxxx() xxxxxx xxxxx xxx xxxx xx xxxxxx x xxxxx xx xxxxxxxx xxx xxxxxx.

 

## Xxx xxx XxxxxxxxxxXxxxxxx xxxxx


Xxxx xxxxxxxxx xx xxxxxxxxx xxx xxx xxxxxxx xx xxx xxxx. Xxxx xxxxxx xxxxxxx xxxx xxx xxxx xxxxxxxx xx xxxx. Xxx xxx xxxx xx xxxxx xxxxxxx xxxxxxxxxx xxxxx xxxx xxx'x xxxx xxxxxx xxxxxxx xxxxxxx. Xxx xxxxxxx, xx xxxx xxx xxxxxxxx x xxxx xx xxxx'x xxx xxxxx xxxx x xxxx, xxx xxxxx xxxxxx xxx xxxx xxxxxx xxx [**XxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702458) xxxxx xxxxxx xxxx xxxx xx x xxxx xxxx xxx xxxxx xxxx xxx xxx xxx xxxxxxxxxxx xxxx xxx xx xxxxx xx xxx xxxx xxx xxxx xxxxxxxxx xxx xxx. Xxx xxxxxxxxx xxxx xxxxxxx xxx **XxxxxxxxxxXxxxxxx** xxxxx xxx **XxxxXxxx**:

```cs
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        Window.Current.VisibilityChanged += WindowVisibilityChangedEventHandler;
    }

    void WindowVisibilityChangedEventHandler(System.Object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
    {
        // Perform operations that should take place when the application becomes visible rather than 
        // when it is prelaunched, such as building a what&#39;s new feed 
    }
}
```

## Xxxxxxxx


-   Xxxx xxxxxx xxx xxxxxxx xxxx xxxxxxx xxxxxxxxxx xxxxxx xxxxxxxxx xxxxxxx xxx xxx xxxx xxxxxxxxx xx xx xxx'x xx xxxxxxxxx xxxxxxx.
-   Xxxx xxxxxx xxx xxxxxxxx xxxxx xxxxxxxx xxxx [**Xxxxxxxxxxx.XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxx xxx xxx xx xxxxxxxxxxx xxxxxxx xxx xxx xxx'x xx xxxxxxx xxx xx xxx'x xx xxxxxxxx xxx xxxxx xx xxxxx xxxxxxx.
-   Xxxx xxxxxx xxx xxxxxxx xxx xxxxxxxxxx xxxxxx xxxxxx xxxxx xxxxxx xxxx xxx xxx xx xxxxxxx xx xxx xxxx, xx xxxxxx xxxx xxx xxx xxx xxxxxxxxxx xxxxxxxx xx xxx xxxx. Xxxxxxx xx xxx xxx xxx xx xxxxxxxx xx xxx xxxxxxxxxx xxxxxxx xxxxxxxx xxxx xxxxxx, xxxxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxx, xxxx xxxxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxxx.
    -   Xx xxxxxxx xxxxxxx xxxxxxxxxxxxx xx xxxx x xxxxxx xxx xxxxxx xxxxxx xxx xxxx xxxxx xx xxxxxx. Xx xxxxxx xxxx xxxxx xxx xxxx xxxxxxxx xx xxx xxx xxxxxxx xx xxxxxxxx xxx xxxxxx xxxx xxx xxx xx xxxxxxxxxxx.
    -   Xx xxxxxxx xxxx xxxxxxxxxx xxxxxxxxxxxxx xx xxxx xx xxx xxxx xx xxx, xxxx xx x xxxx, xxxx xxxxxxxx xx xxxxxxxxxxxx xxxxxxxx xxxx xx xx xxxxxxxx, xxx xxxxx xxxxx xxx xxxxxxxxxxxx xxxxxxxx xxxxx xxx xxxx xxxxxxxx xx xxx xxx.
    -   Xx xxxxxxx xxxxxxxxxxx xxxxxxxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxx xxxx xxxxxxxx xx xxx xxx xx xxxxxxxx xxx xxxxxxx xxxxxxx xxxxxxxxxxx xxxxxxx xx xxxxxxx xx xxxx xxx xxx xx xxxxxxxxxxx xxx xxxx xxxx xx xxxx xx xxxxx xxxx xxx xxx xxxxxxx xxxxxxx xx xxxxxx xxxx xxx xxxxxxxxxxx xx xxxxxxx.
-   Xx xxxx xxx xxxxxx xxx Xxxx Xxxx xxxx xxxxxxxx, xxxxx xxxx xxxxx xxx xxxxxxxxxx xxxxxxx xxxxx.
-   Xxxxxxxxx xxx xxxx xxx xxxxxx xxxxxxxxxxx xxxxxxx xxxxxx xxxx xxxxxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xxxx xxx xxx xxxxxxxx xxx xxxxxxxx xxxxx xxxxxxxx xxxxx.
-   Xx xxx xxxx Xxxxxxxxx Xxxxxx Xxxxxx YYYY Xxxxxx Y xxx Xxxxxxx YY, Xxxxxxx YYYY, xxx xxx xxxxxxxx xxxxxxxxx xxx Xxx xxxx xxx xx Xxxxxx Xxxxxx YYYY xx xxxxxxxx **Xxxxx** &xx; **Xxxxx Xxxxx Xxxxxxx** &xx; **Xxxxx Xxxxxxx Xxxxxxxxx Xxx XxxXxxxxx**.

## Xxxxxxx xxxxxx

* [Xxx xxxxxxxxx](app-lifecycle.md)

 

 



<!--HONumber=Mar16_HO1-->
