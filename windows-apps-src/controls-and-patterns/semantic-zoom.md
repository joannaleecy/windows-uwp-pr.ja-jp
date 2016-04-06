---
Description: A semantic zoom control allows the user to zoom between two different semantic views of the same data set.
title: Semantic zoom
ms.assetid: B5C21FE7-BA83-4940-9CC1-96F6A2DC28C7
label: Semantic zoom
template: detail.hbs
---

# Semantic zoom

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

The semantic zoom control enables the user to zoom between two different views of the same content so that they can quickly navigate through a large data set. The zoomed-in view is the main view of the content. You show the complete data set in this view. The zoomed-out view is a higher-level view of the same content. You typically show the group headers for a grouped data set in this view. For example, when viewing an address book, the user could zoom in on a letter and see the names associated with that letter. 

**Important APIs**

-   [**SemanticZoom class**](https://msdn.microsoft.com/library/windows/apps/hh702601)

**Features**:

-   The size of the zoomed-out view is constrained by the bounds of the semantic zoom control.
-   Tapping on a group header toggles views. Pinching as a way to toggle between views can be enabled.
-   Active headers switch between views.

## Examples

A semantic zoom used in the Photos app.

![A semantic zoom used in the Photos app](images/control-examples/semantic-zoom-photos.png)

An address book is one example of a data set that can be much easier to navigate using a semantic zoom control. In one view is the complete, alphanumerical overview of people in the address book (left image), while the zoomed-in view displays the data in order and with greater detail (right image).

![example of semantic zoom used in a contacts list](images/semanticzoom-win10.png)

## Recommendations

-   When using semantic zoom in your app, be sure that the item layout and panning direction don't change based on the zoom level. Layouts and panning interactions should be consistent and predictable across zoom levels.
-   Semantic zoom enables the user to jump quickly to content, so limit the number of pages/screens to three in the zoomed-out mode. Too much panning diminishes the practicality of semantic zoom.
-   Avoid using semantic zoom to change the scope of the content. For example, a photo album shouldn't switch to a folder view in File Explorer.
-   Use a structure and semantics that are essential to the view.
-   Use group names for items in a grouped collection.
-   Use sort ordering for a collection that is ungrouped but sorted, such as chronological for dates or alphabetical for a list of names.

\[This article contains information that is specific to Universal Windows Platform (UWP) apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Related articles

* [Guidelines for common user interactions](https://dev.windows.com/design/inputs-devices)


**Samples (XAML)**
* [Input: XAML user input events sample](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [XAML scrolling, panning, and zooming sample](http://go.microsoft.com/fwlink/p/?linkid=251717)

**Samples (DirectX)**
* [DirectX touch input sample](http://go.microsoft.com/fwlink/p/?LinkID=231627)
* [Input: Manipulations and gestures (C++) sample](http://go.microsoft.com/fwlink/p/?linkid=231605)
 

 






<!--HONumber=Mar16_HO1-->


