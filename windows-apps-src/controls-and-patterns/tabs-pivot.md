---
Description: Tabs and pivots are enable users to navigate between frequently accessed content.
title: Tabs and pivots
ms.assetid: 556BC70D-CF5D-4295-A655-D58163CC1824
label: Tabs and pivots
template: detail.hbs
---
# Tabs and pivots

Tabs and pivots are used for navigating frequently accessed, distinct content categories. The tab/pivot pattern is made of two or more content panes that have corresponding category headers. The headers persist on-screen and have a selection state that's clearly shown, so users are always aware of which category they're in.
![An examples of tabs](images/HIGSecOne_Tabs.png)

Tabs and pivots are effectively the same pattern, and both are built using the [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) control. The basic functionality of the Pivot control is described later in this article.

<span class="sidebar_heading" style="font-weight: bold;">Important APIs</span>

-   [**Pivot class**](https://msdn.microsoft.com/library/windows/apps/dn608241)

## The tab/pivot pattern

When building an app with the tab/pivot pattern, there are a few key design variables to consider based on the pattern's configurable feature set.

- **Header placement.**   Headers can be placed at the top or the bottom of the screen.
    
    **Note**&nbsp;&nbsp;Placing headers at the bottom of the screen requires re-templating the Pivot control.
- **Header labels.**  Headers can have an icon with text, text only, or icon only.
- **Header alignment.**  Headers can be left-justified or centered.
- **Top-level or sub-level navigation.**  Tabs/pivots can be used for either level of navigation, and can be stacked in a top-level/sub-level pattern. When there are two levels of tabs/pivots, the top-level and sub-level headers should have enough visual differentiation so that users can clearly separate the two.
- **Touch gesture support.**  For devices that support touch gestures, you can use one of two interaction sets to navigate between content categories:
    1. Tap on a tab/pivot header to navigate to that category, or swipe on the content area to navigate to the adjacent category.
    2. Tap on a tab/pivot header to navigate to that category (no swipe).

### Pattern configurations

The optimal arrangement of the tab/pivot pattern depends on the interaction scenario and the device(s) on which your app will appear. This table outlines some of the top scenarios and pattern configurations.

Interaction scenario|Recommended configuration
--------------------|-------------------------
Moving laterally between 2 to 5 top-level list or grid view content categories on a phone or phablet|Tab/pivots: Placed at the top of the screen, centered
|Header labels: Icons + text
|Swipe on content area: Enabled
Moving between a range of content categories on a phone or phablet in which swiping on a content area isn't practical for navigation|Tab/pivots: Placed at the bottom of the screen, centered
|Header labels: Icons + text
|Swipe on content area: Disabled
Top-level navigation with a mouse and keyboard|Tab/pivots: Placed at the top of the screen, left-aligned
 *or*|Header labels: Text-only
 Page-level navigation on a touch device|Swipe on content area: Disabled

## Examples

This design of a food truck app shows what placing tab/pivot headers on the top or bottom can look like. On mobile devices, placing them at the bottom works well for reachability.

![An example of tabs on a mobile device](images/uap_foodtruck_phone_320_tabsboth.png)

The food truck app design on laptop/desktop features text-only headers. Using icons with text for headers helps with touch targeting, but for mouse and keyboard, text-only headers work well.

![Example of tabs on desktop](images/uap_foodtruck_desktop_home_700.png)

## Create a pivot control

The tab/pivot navigation pattern is built using the [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) control. The control comes with the basic functionality described in this section.

This XAML creates a basic pivot control with 3 sections of content.

```xaml
<Pivot x:Name="rootPivot" Title="PIVOT TITLE">
    <PivotItem Header="Pivot Item 1">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 1."/>
    </PivotItem>
    <PivotItem Header="Pivot Item 2">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 2."/>
    </PivotItem>
    <PivotItem Header="Pivot Item 3">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 3."/>
    </PivotItem>
</Pivot>
```

**Pivot items**

Pivot is an [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type. Any item you add to the Pivot that is not explicitly a [**PivotItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) is implicitly wrapped in a PivotItem. Because a Pivot is often used to navigate between pages of content, it's common to populate the [**Items**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) collection directly with XAML UI elements. Or, you can set the [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source. Items bound in the ItemsSource can be of any type, but if they aren't explicitly PivotItems, you must define an [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) and [**HeaderTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) to specify how the items are displayed.

You can use the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) property to get or set the Pivot's active item. Use the [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) property to get or set the index of the active item. 

**Pivot headers**

You can use the [**LeftHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) and [**RightHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) properties to add other controls to the Pivot header. 

### Pivot interaction

The control features these touch gesture interactions:

-   Tapping on a header navigates to that header's section content.
-   Swiping left or right on a header navigates to the adjacent header/section.
-   Swiping left or right on section content navigates to the adjacent header/section.

The control comes in two modes:

**Stationary**

-   Pivots are stationary when all pivot headers fit within the allowed space.
-   Tapping on a pivot label navigates to the corresponding page, though the pivot itself will not move. The active pivot is highlighted.

**Carousel**

-   Pivots carousel when all pivot headers don't fit within the allowed space.
-   Tapping a pivot label navigates to the corresponding page, and the active pivot label will carousel into the first position.

The control has built-in breakpoint functionality, which is based on the number of headers and the string length of the labels.

## Recommendations

-   Base the alignment of tab/pivot headers on screen size. For screen widths below 720 epx, center-aligning usually works better, while left-aligning for screen widths above 720 epx is recommended in most cases.
-   When scaling a window, once the number of tabs/pivot headers exceeds available real estate, start pushing headers into the overflow area.
-   Tabs/pivots can be used in either screen orientation, but be sure to maintain the same total number of headers (visible and hidden) in both landscape and portrait orientations.
-   Avoid using more than 5 headers when using carousel (round-trip) mode, as having more than 5 can cause the user to lose orientation.
-   On mobile devices, placing tabs/pivots at the bottom works well for reachability, if swiping is used in another part of the UI, and to avoid top-heavy UI.
-   When the on-screen keyboard is deployed, headers can move off-screen to preserve space.

\[This article contains information that is specific to Universal Windows Platform (UWP) apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Related topics

[Navigation design basics](https://msdn.microsoft.com/library/windows/apps/dn958438)


<!--HONumber=Mar16_HO1-->


