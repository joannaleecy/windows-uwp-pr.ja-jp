---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx XX xx xxxx xxx xxxx xxxxxxx xx xxxxxx xxx xxxxx xxxxxxxx.
xxxxx: Xxxxxxx xx xxx xxxxxxxx xx xxx xxxxx xxxxxxxx
xx.xxxxxxx: YYXYYYYX-YYXY-YXYX-YYXY-YYYYYYYXXYYY
xxxxx: Xxxxxxx xx xxx xxxxxxxx xx xxx xxxxx xxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxx xx xxx xxxxxxxx xx xxx xxxxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209185)
-   [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242255)

Xxxxx xxx xx xxxxxx xxx XX xx xxxx xxx xxxx xxxxxxx xx xxxxxx xxx xxxxx xxxxxxxx.

![xxx xxxxx xxxxxxxx xx xxxxxxx xxxxxx xxxx](images/touchkeyboard-standard.png)

<sup>Xxx\\ xxxxx\\ xxxxxxxx\\ xx\\ xxxxxxx\\ xxxxxx\\ xxxx</sup>

Xxx xxxxx xxxxxxxx xxxxxxx xxxx xxxxx xxx xxxxxxx xxxx xxxxxxx xxxxx. Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxx xxxxxxxx xxxxxx xxx xxxxx xxxxxxxx xx xxxxxxx xxxx x xxxx xxxx xx xx xxxxxxxx xxxxx xxxxx. Xxx xxxxx xxxxxxxx xxxxxxxxx xxxxxxx xxxxxxx xxxxx xxx xxxx xxxxxxxxx xxxxxxx xxxxxxxx xx x xxxx, xxx xxxx xxxxxxxx xxx xxxx xxxxx xx xxx xxxxx xxxxxxx xxxxx xxxxxx xxx xxxx.

Xx xxxxxxx xxxxxxxxxxxxx xxxxx xxxxxxxx xxxxxxxx xx x xxxxxx xxxx xxxxx xxxxxxx xxxx xxxx xxx xxxxxx xxxx x xxxxxxxx xxxx xxxxx xxxxxxx, xxx xxxx xxx xxx [**XxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209185) xxxxx xx xxxxxx xxxx xxxxxxxx xx Xxxxxxxxx XX Xxxxxxxxxx xxx xxxxxxxxx xxx xxxxxxx XX Xxxxxxxxxx xxxxxxx xxxxxxxx. Xxx [Xxxxxxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt244347) xxx [Xxxxxx xxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt297667).

Xxxx xxxx xxxxxxx xxx xxxx xxxxx xx xxxx xxxxxx xxxxxxx, xxx xxx xxxxxxx xxxxxxxxxxxxx xx xxx xxxxxxxx xx xxx xxxxx xxxxxxxx.

**Xxxxxxxxxxxxx:  **

Xxxx xxxxx xxxxxx xx [Xxxxxxxx xxxxxxxxxxxx](keyboard-interactions.md).

Xxx xxxxxx xxxx x xxxxx xxxxxxxxxxxxx xx xxxxxxxx xxxxxxxx xxxxxxxxxxxx, xxxxxxxx xxxxxxxx xxxxx xxx xxxxxx, xxx XX Xxxxxxxxxx.

Xx xxx'xx xxx xx xxxxxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxx x xxxx xxxxxxx xxxxx xxxxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxx.

-   [Xxxxxx xxxx xxxxx xxx](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   Xxxxx xxxxx xxxxxx xxxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185584)

**Xxxx xxxxxxxxxx xxxxxxxxxx:  **

Xxx xxxxxxx xxxx xxxxx xxxxxxxxx x xxxxxx xxx xxxxxxxx xxx xxxxxxxxx xxx xxxxxxxx xxxxx, xxx [Xxxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh972345) .

## <span id="Touch_keyboard_and_a_custom_UI">
            </span>
            <span id="touch_keyboard_and_a_custom_ui">
            </span>
            <span id="TOUCH_KEYBOARD_AND_A_CUSTOM_UI">
            </span>Xxxxx xxxxxxxx xxx x xxxxxx XX


Xxxx xxx x xxx xxxxx xxxxxxxxxxxxxxx xxx xxxxxx xxxx xxxxx xxxxxxxx.

-   Xxxxxxx xxx xxxxx xxxxxxxx xxxxxxxxxx xxx xxxxxx xxxxxxxxxxx xxxx xxxx xxxx.

-   Xxxxxx xxxx xxxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxxxxx XX Xxxxxxxxxx [**XxxxxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209182) xxx xxx xxxxxxxx xx xxxxxxx xxxx xxxxx xxxxx xxxx x xxxx xxxxx xxxxx xxxxx xx xxx xxxxxxx xx xxxx xxxxx. Xxx xxxxxxx, xx xxx xxxx x xxxx xxxx'x xxxxxx xx xxx xxxxxx xx x xxxx-xxxxx xxxxxxxx, xxx xxx xxxx xxx xxxxxxxx xx xxxxxxx, xxx xxxx xxxx xxxx xxx **XxxxxxxxxxXxxxxxxXxxx** xx Xxxx.

-   Xxx'x xxxxxxxxxx XX Xxxxxxxxxx xxxxxxxxxx xx xxxxxxx xxx xxxxx xxxxxxxx. Xxxxx xxxxxxxxxxxxx xxxxx xxxx xx xxx xxxxxxxx xx XX Xxxxxxxxxx xxxxxxxxxx.

-   Xxxxxx xxxx xxxxx xxx xxxxxx xxx xxx xxxxx xxxxx xxxx xxxx'xx xxxxxxxxxxx xxxx.

    Xxxxxxx xxx xxxxx xxxxxxxx xxxxxxxx x xxxxx xxxxxxx xx xxx xxxxxx, xxx XXX xxxxxxx xxxx xxx xxxxx xxxxx xxxx xxxxx xxxxxxx xxxx xxxx xx x xxxx xxxxxxxxx xxxxxxx xxx xxxxxxxx xx xxx xxxx, xxxxxxxxx xxxxxxxx xxxx xxx xxx xxxxxxxxx xx xxxx.

    Xxxx xxxxxxxxxxx xxxx XX, xxxxxxx xxxxxxx xxxxxxxx xx xxx xxxxxxxxxx xx xxx xxxxx xxxxxxxx xx xxxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242262) xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242260) xxxxxx xxxxxxx xx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242255) xxxxxx.

    ![x xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxx xxxxxxx](images/touch-keyboard-pan1.png)

    Xx xxxx xxxxx, xxxxx xxx XX xxxxxxxx xxxx xxxxxx xxxx xx xxx xxxxxx xxx xxxxxx xxxx. Xxxxxx xxx XX xx xxxx xxx xxxx xxxxxxxx xxx xxxxxxxxx xx x xxxxxxx xxxxxx xxx xxx xxxxxxxxx XX xxxxxxxx xxx xxxxxx. Xxx xxxxxxx:

    ![x xxxx xxxx xxxxxxxx xxxxx xxxx xxxxxx xxxxxx xxxx xx xxxx](images/touch-keyboard-pan2.png)

## <span id="handling_events">
            </span>
            <span id="HANDLING_EVENTS">
            </span>Xxxxxxxx xxx Xxxxxxx xxx Xxxxxx xxxxxx


Xxxx'x xx xxxxxxx xx xxxxxxxxx xxxxx xxxxxxxx xxx xxx [**xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242262) xxx [**xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242260) xxxxxx xx xxx xxxxx xxxxxxxx.

```CSharp
public class MyApplication
{
    public MyApplication()
    {
        // Grab the input pane for the main application window and attach
        // touch keyboard event handlers.
        Windows.Foundation.Application.InputPane.GetForCurrentView().Showing  
            += new EventHandler(_OnInputPaneShowing);
        Windows.Foundation.Application.InputPane.GetForCurrentView().Hiding 
            += new EventHandler(_OnInputPaneHiding);
    }

    private void _OnInputPaneShowing(object sender, IInputPaneVisibilityEventArgs eventArgs)
    {
        // If the size of this window is going to be too small, the app uses 
        // the Showing event to begin some element removal animations.
        if (eventArgs.OccludedRect.Top < 400)
        {
            _StartElementRemovalAnimations();

            // Don&#39;t use framework scroll- or visibility-related 
            // animations that might conflict with the app&#39;s logic.
            eventArgs.EnsuredFocusedElementInView = true; 
        }
    }

    private void _OnInputPaneHiding(object sender, IInputPaneVisibilityEventArgs eventArgs)
    {
        if (_ResetToDefaultElements())
        {
            eventArgs.EnsuredFocusedElementInView = true; 
        }
    }

    private void _StartElementRemovalAnimations()
    {
        // This function starts the process of removing elements 
        // and starting the animation.
    }

    private void _ResetToDefaultElements()
    {
        // This function resets the window&#39;s elements to their default state.
    }
}
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx



* [Xxxxxxxx xxxxxxxxxxxx](keyboard-interactions.md)
* [Xxxxxxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt244347)
* [Xxxxxx xxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt297667)


**Xxxxxxx xxxxxxx**
* [Xxxxx: Xxxxx xxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=246019)
* [Xxxxxxxxxx xx xxx xxxxxxxxxx xx xxx xx-xxxxxx xxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231633)
* [XXXX xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=251417)
* [XXXX xxxxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238570)
 

 




<!--HONumber=Mar16_HO1-->
