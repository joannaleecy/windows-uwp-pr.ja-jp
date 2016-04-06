---
Description: Respond to mouse input in your apps by handling the same basic pointer events that you use for touch and pen input.
title: Mouse interactions
ms.assetid: C8A158EF-70A9-4BA2-A270-7D08125700AC
label: Mouse
template: detail.hbs
---

# Mouse interactions


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Optimize your Universal Windows Platform (UWP) app design for touch input and get basic mouse support by default.

 

![mouse](images/input-patterns/input-mouse.jpg)



Mouse input is best suited for user interactions that require precision when pointing and clicking. This inherent precision is naturally supported by the UI of Windows, which is optimized for the imprecise nature of touch.

Where mouse and touch input diverge is the ability for touch to more closely emulate the direct manipulation of UI elements through physical gestures performed directly on those objects (such as swiping, sliding, dragging, rotating, and so on). Manipulations with a mouse typically require some other UI affordance, such as the use of handles to resize or rotate an object.

This topic describes design considerations for mouse interactions.

## <span id="The_UWP_app_mouse_language"></span><span id="the_uwp_app_mouse_language"></span><span id="THE_UWP_APP_MOUSE_LANGUAGE"></span>The UWP app mouse language


A concise set of mouse interactions are used consistently throughout the system.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Term</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span id="Hover_to_learn"></span><span id="hover_to_learn"></span><span id="HOVER_TO_LEARN"></span>Hover to learn</p></td>
<td align="left"><p>Hover over an element to display more detailed info or teaching visuals (such as a tooltip) without a commitment to an action.</p></td>
</tr>
<tr class="even">
<td align="left"><p><span id="Left-click_for_primary_action"></span><span id="left-click_for_primary_action"></span><span id="LEFT-CLICK_FOR_PRIMARY_ACTION"></span>Left-click for primary action</p></td>
<td align="left"><p>Left-click an element to invoke its primary action (such as launching an app or executing a command).</p></td>
</tr>
<tr class="odd">
<td align="left"><p><span id="Scroll_to_change_view"></span><span id="scroll_to_change_view"></span><span id="SCROLL_TO_CHANGE_VIEW"></span>Scroll to change view</p></td>
<td align="left"><p>Display scroll bars to move up, down, left, and right within a content area. Users can scroll by clicking scroll bars or rotating the mouse wheel. Scroll bars can indicate the location of the current view within the content area (panning with touch displays a similar UI).</p></td>
</tr>
<tr class="even">
<td align="left"><p><span id="Right-click_to_select_and_command"></span><span id="right-click_to_select_and_command"></span><span id="RIGHT-CLICK_TO_SELECT_AND_COMMAND"></span>Right-click to select and command</p></td>
<td align="left"><p>Right-click to display the navigation bar (if available) and the app bar with global commands. Right-click an element to select it and display the app bar with contextual commands for the selected element.</p>
<div class="alert">
<strong>Note</strong>  Right-click to display a context menu if selection or app bar commands are not appropriate UI behaviors. But we strongly recommend that you use the app bar for all command behaviors.
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span id="UI_commands_to_zoom"></span><span id="ui_commands_to_zoom"></span><span id="UI_COMMANDS_TO_ZOOM"></span>UI commands to zoom</p></td>
<td align="left"><p>Display UI commands in the app bar (such as + and -), or press Ctrl and rotate mouse wheel, to emulate pinch and stretch gestures for zooming.</p></td>
</tr>
<tr class="even">
<td align="left"><p><span id="UI_commands_to_rotate"></span><span id="ui_commands_to_rotate"></span><span id="UI_COMMANDS_TO_ROTATE"></span>UI commands to rotate</p></td>
<td align="left"><p>Display UI commands in the app bar, or press Ctrl+Shift and rotate mouse wheel, to emulate the turn gesture for rotating. Rotate the device itself to rotate the entire screen.</p></td>
</tr>
<tr class="odd">
<td align="left"><p><span id="Left-click_and_drag_to_rearrange"></span><span id="left-click_and_drag_to_rearrange"></span><span id="LEFT-CLICK_AND_DRAG_TO_REARRANGE"></span>Left-click and drag to rearrange</p></td>
<td align="left"><p>Left-click and drag an element to move it.</p></td>
</tr>
<tr class="even">
<td align="left"><p><span id="Left-click_and_drag_to_select_text"></span><span id="left-click_and_drag_to_select_text"></span><span id="LEFT-CLICK_AND_DRAG_TO_SELECT_TEXT"></span>Left-click and drag to select text</p></td>
<td align="left"><p>Left-click within selectable text and drag to select it. Double-click to select a word.</p></td>
</tr>
</tbody>
</table>

## Mouse events

Respond to mouse input in your apps by handling the same basic pointer events that you use for touch and pen input.

Use [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) events to implement basic input functionality without having to write code for each pointer input device. However, you can still take advantage of the special capabilities of each device (such as mouse wheel events) using the pointer, gesture, and manipulation events of this object.

**Samples:  **See this functionality in action in our [app samples](http://go.microsoft.com/fwlink/p/?LinkID=264996).


- [Input: Device capabilities sample](http://go.microsoft.com/fwlink/p/?linkid=231530)

- [Input sample](http://go.microsoft.com/fwlink/p/?linkid=226855)

- [Input: Gestures and manipulations with GestureRecognizer](http://go.microsoft.com/fwlink/p/?LinkID=231605)

## <span id="Guidelines_for_visual_feedback"></span><span id="guidelines_for_visual_feedback"></span><span id="GUIDELINES_FOR_VISUAL_FEEDBACK"></span>Guidelines for visual feedback


-   When a mouse is detected (through move or hover events), show mouse-specific UI to indicate functionality exposed by the element. If the mouse doesn't move for a certain amount of time, or if the user initiates a touch interaction, make the mouse UI gradually fade away. This keeps the UI clean and uncluttered.
-   Don't use the cursor for hover feedback, the feedback provided by the element is sufficient (see Cursors below).
-   Don't display visual feedback if an element doesn't support interaction (such as static text).
-   Don't use focus rectangles with mouse interactions. Reserve these for keyboard interactions.
-   Display visual feedback concurrently for all elements that represent the same input target.
-   Provide buttons (such as + and -) for emulating touch-based manipulations such as panning, rotating, zooming, and so on.

For more general guidance on visual feedback, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).


## <span id="Cursors"></span><span id="cursors"></span><span id="CURSORS"></span>Cursors


A set of standard cursors is available for a mouse pointer. These are used to indicate the primary action of an element.

Each standard cursor has a corresponding default image associated with it. The user or an app can replace the default image associated with any standard cursor at any time. Specify a cursor image through the [**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) function.

If you need to customize the mouse cursor:

-   Always use the arrow cursor (![arrow cursor](images/cursor-arrow.png)) for clickable elements. don't use the pointing hand cursor (![pointing hand cursor](images/cursor-pointinghand.png)) for links or other interactive elements. Instead, use hover effects (described earlier).
-   Use the text cursor (![text cursor](images/cursor-text.png)) for selectable text.
-   Use the move cursor (![move cursor](images/cursor-move.png)) when moving is the primary action (such as dragging or cropping). Don't use the move cursor for elements where the primary action is navigation (such as Start tiles).
-   Use the horizontal, vertical and diagonal resize cursors (![vertical resize cursor](images/cursor-vertical.png), ![horizontal resize cursor](images/cursor-horizontal.png), ![diagonal resize cursor (lower left, upper right)](images/cursor-diagonal2.png), ![diagonal resize cursor (upper left, lower right)](images/cursor-diagonal1.png)), when an object is resizable.
-   Use the grasping hand cursors (![grasping hand cursor (open)](images/cursor-pan1.png), ![grasping hand cursor (closed)](images/cursor-pan2.png)) when panning content within a fixed canvas (such as a map).

## <span id="related_topics"></span>Related articles

* [Handle pointer input](handle-pointer-input.md)
* [Identify input devices](identify-input-devices.md)

**Samples**
* [Basic input sample](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [Low latency input sample](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [User interaction mode sample](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [Focus visuals sample](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**Archive Samples**
* [Input: Device capabilities sample](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [Input: XAML user input events sample](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [XAML scrolling, panning, and zooming sample](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [Input: Gestures and manipulations with GestureRecognizer](http://go.microsoft.com/fwlink/p/?LinkID=231605)
 
 

 






<!--HONumber=Mar16_HO1-->


