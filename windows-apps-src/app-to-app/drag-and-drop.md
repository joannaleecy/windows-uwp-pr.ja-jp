---
description: This article explains how to add dragging and dropping in your Universal Windows Platform (UWP) app.
title: Drag and drop
ms.assetid: A15ED2F5-1649-4601-A761-0F6C707A8B7E
author: awkoren
---
# Drag and drop

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


This article explains how to add dragging and dropping in your Universal Windows Platform (UWP) app. Drag and drop is a classic, natural way of interacting with content such as images and files. Once implemented, drag and drop works seamlessly in all directions, including app-to-app, app-to-desktop, and desktop-to app.

## Set valid areas

Use the [**AllowDrop**][AllowDrop] and [**CanDrag**][CanDrag] properties to designate the areas of your app valid for dragging and dropping.

The markup below shows how to set a specific area of the app as a valid for dropping using the [**AllowDrop**][AllowDrop] in XAML. If a user tries to drop somewhere else, the system won't let them. If you want users to be able to drop items anywhere on your app, set the entire background as a drop target.

[!code-xml[[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]

With dragging, you'll usually want to be specific about what's draggable. Users will want to drag certain items, like pictures, not everything in your app. Here's how to set [**CanDrag**][CanDrag] using XAML.

[!code-xml[[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

You don't need to do any other work to allow dragging, unless you want to customize the UI (which is covered later in this article). Dropping requires a few more steps.

## Handle the DragOver event

The [**DragOver**][DragOver] event fires when a user has dragged an item over your app, but not yet dropped it. In this handler, you need to specify what kind of operations your app supports using the [**DragEventArgs.AcceptedOperation**][AcceptedOperation] property. Copy is the most common.

[!code-cs[[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## Process the Drop event

The [**Drop**][Drop] event occurs when the user releases items in a valid drop area. Process them using the [**DragEventArgs.DataView**][DataView] property.

For simplicity in the example below, we'll assume the user dropped a single photo and access. In reality, users can drop multiple items of varying formats simultaneously. Your app should handle this possibility by checking what types of files were dropped and processing them accordingly, and notifying the user if they're trying to do something your app don't support.

[!code-cs[[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## Customize the UI

The system provides a default UI for dragging and dropping. However, you can also choose to customize various parts of the UI by setting custom captions and glyphs, or by opting not to show a UI at all. To customize the UI, use the [**DragUIOverride**][DragUiOverride] property in the [**DragOver**][DragOver] event handler.

[!code-cs[[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

 <!-- LINKS -->
[AllowDrop]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx
[CanDrag]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx
[DragOver]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx
[AcceptedOperation]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx
[DataView]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx
[DragUiOverride]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx
[Drop]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx 



<!--HONumber=May16_HO2-->


