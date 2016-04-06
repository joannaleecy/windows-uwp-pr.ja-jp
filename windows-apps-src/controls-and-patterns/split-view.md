---
title: Split view
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: A split view control has an expandable/collapsible pane and a content area.
label: Split view
template: detail.hbs
---

# Guidelines for the split view control


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**SplitView class (XAML)**](https://msdn.microsoft.com/library/windows/apps/dn864360)
-   [**SplitView object (HTML)**](https://msdn.microsoft.com/library/windows/apps/dn919970)

A split view control has an expandable/collapsible pane and a content area. The content area is always visible. The pane can expand and collapse or remain in an open state, and can present itself from either the left side or right side of an app window. The pane has three modes:

-   **Overlay**

    The pane is hidden until opened. When open, the pane overlays the content area.

-   **Inline**

    The pane is always visible and doesn't overlay the content area. The pane and content areas divide the available screen real estate.

-   **Compact**

    The pane is always visible in this mode, which is just wide enough to show icons (usually 48 epx wide). The pane and the content area divide the available screen real estate. Although the standard compact mode doesn't overlay the content area, it can transform to a wider pane to show more content which will overlay the content area.

## <span id="Is_this_the_right_control_"></span><span id="is_this_the_right_control_"></span><span id="IS_THIS_THE_RIGHT_CONTROL_"></span>Is this the right control?


The split view control can be used to make a [nav pane pattern](nav-pane.md). To build this pattern, add an expand/collapse button (the "hamburger" button) and a list view need to the split view control.

## <span id="Examples"></span><span id="examples"></span><span id="EXAMPLES"></span>Examples


The split view control in its default form is a basic container. With a button and a list view added, the split view control is ready as a navigation menu. Here are examples of the split view as a navigation menu, in expanded and compact modes.

![an example of a split view menu in overlay mode and compact mode](images/controls-splitview-menu01.png)
## <span id="Recommendations"></span><span id="recommendations"></span><span id="RECOMMENDATIONS"></span>Recommendations


-   When using split view for a navigation menu, we recommend placing in the pane navigation controls that allow access to other areas of the app. Using the pane for navigation provides a consistent user experience. In addition, this menu implementation can help familiarize users to all parts of an app, provide quick access to the app's home page, and can encourage users to explore more areas of the app.

\[This article contains information that is specific to Universal Windows Platform (UWP) apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## <span id="related_topics"></span>Related topics


* [Nav pane pattern](nav-pane.md)
* [List view](lists.md)
 

 






<!--HONumber=Mar16_HO1-->


