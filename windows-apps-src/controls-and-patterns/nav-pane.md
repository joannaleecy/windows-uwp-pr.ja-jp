---
Description: Provides top-level navigation while conserving screen real estate.
title: Guidelines for navigation panes
ms.assetid: 8FB52F5E-8E72-4604-9222-0B0EC6A97541
label: Nav pane
template: detail.hbs
---

Nav panes
=============================================================================================
A navigation pane (or just "nav" pane) is a pattern that allows for many top-level navigation items while conserving screen real estate. The nav pane is widely used for mobile apps, but also works well on larger screens. When used as an overlay, the pane remains collapsed and out-of-the way until the user presses the button, which is handy for smaller screens. When used in its docked mode, the pane remains open, which allows greater utility if there's enough screen real estate.

![Example of a nav pane](images/NAV_PANE_EXAMPLE.png)

<span class="sidebar_heading" style="font-weight: bold;">Important APIs</span>

-   [**SplitView class (XAML)**](https://msdn.microsoft.com/library/windows/apps/dn864360)
-   [**SplitView object (HTML)**](https://msdn.microsoft.com/library/windows/apps/dn919970)

<<<<<<< HEAD

=======

>>>>>>> origin

<span id="Is_this_the_right_pattern_"></span><span id="is_this_the_right_pattern_"></span><span id="IS_THIS_THE_RIGHT_PATTERN_"></span>Is this the right pattern?
-----------------------------------------------------------------------------------------------------------------------------------------------------------------

The nav pane works well for:

-   Apps with many top-level navigation items that are in the same class, such as a sports app with categories like Football, Baseball, Basketball, Soccer, and so on.
-   Providing a consistent navigational experience across apps, provided that only navigational elements are placed within the pane.
-   A medium-to-high number (5-10+) of top-level navigational categories.
-   Preserving screen real estate (as an overlay).
-   Navigation items that are infrequently accessed. (as an overlay).
-   Drag-and-drop scenarios (when docked).

<span id="Building_a_nav_pane"></span><span id="building_a_nav_pane"></span><span id="BUILDING_A_NAV_PANE"></span>Building a nav pane
-------------------------------------------------------------------------------------------------------------------------------------

The nav pane pattern consists of a button, a pane for navigation categories, and a content area. The easiest way to build a nav pane is with a [split view control](split-view.md), which comes with an empty pane and a content area that's always visible. The pane can either be visible or hidden, and can present itself from either the left side or right side of an app window.

If you'd like to build a nav pane without the split view control, you'll need three primary components: a button, a pane, and a content area. The button allows the user to open and close the pane. The pane is a container for navigation elements. The content area displays information from the selected navigation item. The nav pane can also exist in a docked mode, in which the pane is always shown, so a button wouldn't be necessary in that case.

### <span id="Button"></span><span id="button"></span><span id="BUTTON"></span>Button

The nav pane button is visualized, by default, as three stacked horizontal lines and is commonly referred to as the "hamburger" button. The button allows the user to open and close the pane when needed and does not move with the pane. We recommend placing the button in the upper-left corner of your app. The button does not move with the pane.

![Example of the nav pane button](images/NAVPANE_BUTTONONLY.png)

The button is usually associated with a text string. At the top level of the app, the app title can be displayed next to the button. At lower levels of the app, the text string can be associated with the page that the user is currently on.

### <span id="Pane"></span><span id="pane"></span><span id="PANE"></span>Pane

Headers for navigational categories go in the pane. Entry points to app settings and account management, if applicable, also go in the pane. Navigation headers can either be top-level, or nested top-level/second-level.

![Example of the nav pane's pane](images/NAVPANE_PANE.png)

### <span id="Content_area"></span><span id="content_area"></span><span id="CONTENT_AREA"></span>Content area

The content area is where information for the selected nav location is displayed. It can contain individual elements or other sub-level navigation.

<span id="Nav_pane_variations"></span><span id="nav_pane_variations"></span><span id="NAV_PANE_VARIATIONS"></span>Nav pane variations
-------------------------------------------------------------------------------------------------------------------------------------

The nav pane has two main variations, overlay and docked. An overlay collapses and expands as needed. A docked pane remains open by default.

### <span id="Overlay"></span><span id="overlay"></span><span id="OVERLAY"></span>Overlay

-   An overlay can be used on any screen size and in either portrait or landscape orientation. In its default (collapsed) state, the overlay takes up no real-estate, with only the button shown.
-   Provides on-demand navigation that conserves screen real estate. Ideal for apps on phones and phablets.
-   The pane is hidden by default, with only the button visible.
-   Pressing the nav pane button opens and closes the overlay.
-   The expanded state is transient and is dismissed when a selection is made, when the back button is used, or when the user taps outside of the pane.
-   The overlay draws over the top of content and does not reflow content.

### <span id="Docked"></span><span id="docked"></span><span id="DOCKED"></span>Docked

-   The navigation pane remains open. This mode is better suited for larger screens, generally tablets and above.
-   In landscape orientation, the minimum screen width that can take advantage of the docked state is 720 epx. The docked state at this size may require special attention to content scaling.
-   Supports drag-and-drop scenarios to and from the pane.
-   The nav pane button is not required for this state. If the button is used, then the content area is pushed out and the content within that area will reflow.
-   The selection should be shown on the list items to highlight where the user is in the navigation tree.
-   When the device is too narrow in portrait orientation to display the docked pane, the following behavior is recommended when a device is rotated:
    -   Landscape-to-portrait. The pane collapses to either the overlay state or minimized state.
    -   Portrait-to-landscape. The pane reappears.

<span id="related_topics"></span>Related topics
-----------------------------------------------

* [Split view control](split-view.md)
* [Master/details](master-details.md)
* [Navigation basics](https://msdn.microsoft.com/library/windows/apps/dn958438)
 

 


<!--HONumber=Mar16_HO4-->


