---
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。"
title: "ドラッグ アンド ドロップ"
ms.assetid: A15ED2F5-1649-4601-A761-0F6C707A8B7E
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b3efc0a30c3407fbc05d0fa800df8596af548931
ms.sourcegitcommit: 23cda44f10059bcaef38ae73fd1d7c8b8330c95e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/19/2017
---
# <a name="drag-and-drop"></a><span data-ttu-id="7cfdd-104">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="7cfdd-104">Drag and drop</span></span>

<span data-ttu-id="7cfdd-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="7cfdd-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="7cfdd-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="7cfdd-107">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-107">This article explains how to add dragging and dropping in your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="7cfdd-108">ドラッグ アンド ドロップは、画像やファイルなどのコンテンツを操作するための従来からある自然な方法です。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-108">Drag and drop is a classic, natural way of interacting with content such as images and files.</span></span> <span data-ttu-id="7cfdd-109">ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、あらゆる方向でシームレスに機能します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-109">Once implemented, drag and drop works seamlessly in all directions, including app-to-app, app-to-desktop, and desktop-to app.</span></span>

## <a name="set-valid-areas"></a><span data-ttu-id="7cfdd-110">有効な領域を設定する</span><span class="sxs-lookup"><span data-stu-id="7cfdd-110">Set valid areas</span></span>

<span data-ttu-id="7cfdd-111">[**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティと [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) プロパティを使うと、ドラッグ アンド ドロップの操作に有効なアプリ内の領域を指定できます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-111">Use the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) and [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) properties to designate the areas of your app valid for dragging and dropping.</span></span>

<span data-ttu-id="7cfdd-112">次のマークアップは、XAML で [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) を使って、アプリの特定の領域をドロップ操作に有効な領域として設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-112">The following markup shows how to set a specific area of the app as valid for dropping by using the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) in XAML.</span></span> <span data-ttu-id="7cfdd-113">ユーザーが他の場所へのドロップを試みても、ドロップすることはできません。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-113">If a user tries to drop somewhere else, the system won't let them.</span></span> <span data-ttu-id="7cfdd-114">アプリ内のすべての領域でユーザーが項目をドロップできるようにする場合は、背景全体をドロップ先として設定します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-114">If you want users to be able to drop items anywhere on your app, set the entire background as a drop target.</span></span>

[!code-xml[<span data-ttu-id="7cfdd-115">メイン</span><span class="sxs-lookup"><span data-stu-id="7cfdd-115">Main</span></span>](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]

<span data-ttu-id="7cfdd-116">ドラッグ操作では通常、どの項目がドラッグ可能であるか指定しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-116">With dragging, you'll usually want to be specific about what's draggable.</span></span> <span data-ttu-id="7cfdd-117">ユーザーがドラッグしようとするのは、アプリ内のすべてではなく、画像などの特定の項目です。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-117">Users will want to drag certain items, such as pictures, not everything in your app.</span></span> <span data-ttu-id="7cfdd-118">XAML を使って [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) を設定する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-118">Here's how to set [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) by using XAML.</span></span>

[!code-xml[<span data-ttu-id="7cfdd-119">メイン</span><span class="sxs-lookup"><span data-stu-id="7cfdd-119">Main</span></span>](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

<span data-ttu-id="7cfdd-120">UI をカスタマイズする場合 (この記事の後半で説明します) を除き、他には何もしなくてもドラッグ操作を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-120">You don't need to do any other work to allow dragging, unless you want to customize the UI (which is covered later in this article).</span></span> <span data-ttu-id="7cfdd-121">ドロップ操作には、あといくつかの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-121">Dropping requires a few more steps.</span></span>

## <a name="handle-the-dragover-event"></a><span data-ttu-id="7cfdd-122">DragOver イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="7cfdd-122">Handle the DragOver event</span></span>

<span data-ttu-id="7cfdd-123">[**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) イベントは、ユーザーがアプリに項目をドラッグし、まだドロップしていないときに発生します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-123">The [**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) event fires when a user has dragged an item over your app, but not yet dropped it.</span></span> <span data-ttu-id="7cfdd-124">このハンドラーでは、[**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) プロパティを使って、アプリがサポートしている操作の種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-124">In this handler, you need to specify what kind of operations your app supports by using the [**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) property.</span></span> <span data-ttu-id="7cfdd-125">最も一般的な操作はコピーです。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-125">Copy is the most common.</span></span>

[!code-cs[<span data-ttu-id="7cfdd-126">メイン</span><span class="sxs-lookup"><span data-stu-id="7cfdd-126">Main</span></span>](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## <a name="process-the-drop-event"></a><span data-ttu-id="7cfdd-127">Drop イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="7cfdd-127">Process the Drop event</span></span>

<span data-ttu-id="7cfdd-128">[**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントは、有効なドロップ領域内でユーザーが項目を放したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-128">The [**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) event occurs when the user releases items in a valid drop area.</span></span> <span data-ttu-id="7cfdd-129">放した項目を処理するには [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-129">Process them by using the [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) property.</span></span>

<span data-ttu-id="7cfdd-130">次の例では、わかりやすくするために、ユーザーが単一の写真をドロップしたとします。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-130">For simplicity in the example below, we'll assume the user dropped a single photo and access.</span></span> <span data-ttu-id="7cfdd-131">実際には、ユーザーがさまざまな形式の複数の項目を同時にドロップすることもあります。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-131">In reality, users can drop multiple items of varying formats simultaneously.</span></span> <span data-ttu-id="7cfdd-132">アプリでは、このような可能性にも対応できるようにしておく必要があります。そのためには、ドロップされたファイルの種類を確認し、種類に応じた処理を実行します。また、アプリでサポートしていない動作が行われた場合は、それをユーザーに通知します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-132">Your app should handle this possibility by checking what types of files were dropped and processing them accordingly, and notifying the user if they're trying to do something your app doesn't support.</span></span>

[!code-cs[<span data-ttu-id="7cfdd-133">メイン</span><span class="sxs-lookup"><span data-stu-id="7cfdd-133">Main</span></span>](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## <a name="customize-the-ui"></a><span data-ttu-id="7cfdd-134">UI をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="7cfdd-134">Customize the UI</span></span>

<span data-ttu-id="7cfdd-135">システムでは、ドラッグ アンド ドロップ用に既定の UI が提供されています。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-135">The system provides a default UI for dragging and dropping.</span></span> <span data-ttu-id="7cfdd-136">ただし、カスタムのキャプションやグリフを設定して UI のさまざまな部分をカスタマイズすることも、UI をまったく表示しないこともできます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-136">However, you can also choose to customize various parts of the UI by setting custom captions and glyphs, or by opting not to show a UI at all.</span></span> <span data-ttu-id="7cfdd-137">UI をカスタマイズするには、[**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-137">To customize the UI, use the [**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) property.</span></span>

[!code-cs[<span data-ttu-id="7cfdd-138">メイン</span><span class="sxs-lookup"><span data-stu-id="7cfdd-138">Main</span></span>](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

## <a name="open-a-context-menu-on-an-item-you-can-drag-with-touch"></a><span data-ttu-id="7cfdd-139">タッチによるドラッグが可能な項目のコンテキスト メニューを開く</span><span class="sxs-lookup"><span data-stu-id="7cfdd-139">Open a context menu on an item you can drag with touch</span></span>

<span data-ttu-id="7cfdd-140">タッチを使い、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement) をドラッグして、コンテキスト メニューを開くには、類似したタッチ ジェスチャを使用します。それぞれ長押しから始まります。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-140">When using touch, dragging a [**UIElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement) and opening its context menu share similar touch gestures; each begins with a press and hold.</span></span> <span data-ttu-id="7cfdd-141">アプリの要素が 2 つのアクションをサポートしている場合に、システムがそれを区別する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-141">Here's how the system disambiguates between the two actions for elements in your app that support both:</span></span> 

* <span data-ttu-id="7cfdd-142">ユーザーがある項目を長押しし、500 ミリ秒以内にドラッグを開始した場合、項目はドラッグされ、コンテキスト メニューは表示されません。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-142">If a user presses and holds an item and begins dragging it within 500 milliseconds, the item is dragged and the context menu is not shown.</span></span> 
* <span data-ttu-id="7cfdd-143">ユーザーが長押ししてから 500 ミリ秒以内にドラッグしなかった場合には、コンテキスト メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-143">If the user presses and holds but does not drag within 500 milliseconds, the context menu is opened.</span></span> 
* <span data-ttu-id="7cfdd-144">コンテキスト メニューが開いた後に、ユーザーが指を離すことなく、項目をドラッグしようとすると、コンテキスト メニューは閉じられ、ドラッグが開始されます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-144">After the context menu is open, if the user tries to drag the item (without lifting their finger), the context menu is dismissed and the drag will start.</span></span>

## <a name="designate-an-item-in-a-listview-or-gridview-as-a-folder"></a><span data-ttu-id="7cfdd-145">ListView または GridView の項目をフォルダーとして指定する</span><span class="sxs-lookup"><span data-stu-id="7cfdd-145">Designate an item in a ListView or GridView as a folder</span></span>

<span data-ttu-id="7cfdd-146">[ **ListViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListViewItem) または [ **GridViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridViewItem) をフォルダーとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-146">You can specify a [**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListViewItem) or [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridViewItem) as a folder.</span></span> <span data-ttu-id="7cfdd-147">これは、ツリー ビューとエクスプローラーのシナリオで特に便利です。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-147">This is particularly useful for TreeView and File Explorer scenarios.</span></span> <span data-ttu-id="7cfdd-148">これを行うには、その項目で [ **AllowDrop** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティを明示的に **True** に設定します。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-148">To do so, explicitly set the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) property to **True** on that item.</span></span> 

<span data-ttu-id="7cfdd-149">(非フォルダー項目にではなく) フォルダーにドロップするための、適切なアニメーションが自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-149">The system will automatically show the appropriate animations for dropping into a folder versus a non-folder item.</span></span> <span data-ttu-id="7cfdd-150">アプリのコードは、フォルダー項目の[**ドロップ**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントの処理 (および非フォルダー項目の処理) を継続し、データ ソースを更新して、ドロップ先のフォルダーにドロップされた項目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7cfdd-150">Your app code must continue to handle the [**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) event on the folder item (as well as on the non-folder item) in order to update the data source and add the dropped item to the target folder.</span></span>

## <a name="see-also"></a><span data-ttu-id="7cfdd-151">関連項目</span><span class="sxs-lookup"><span data-stu-id="7cfdd-151">See also</span></span>

* [<span data-ttu-id="7cfdd-152">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="7cfdd-152">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="7cfdd-153">AllowDrop</span><span class="sxs-lookup"><span data-stu-id="7cfdd-153">AllowDrop</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx)
* [<span data-ttu-id="7cfdd-154">CanDrag</span><span class="sxs-lookup"><span data-stu-id="7cfdd-154">CanDrag</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx)
* [<span data-ttu-id="7cfdd-155">DragOver</span><span class="sxs-lookup"><span data-stu-id="7cfdd-155">DragOver</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx)
* [<span data-ttu-id="7cfdd-156">AcceptedOperation</span><span class="sxs-lookup"><span data-stu-id="7cfdd-156">AcceptedOperation</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx)
* [<span data-ttu-id="7cfdd-157">DataView</span><span class="sxs-lookup"><span data-stu-id="7cfdd-157">DataView</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx)
* [<span data-ttu-id="7cfdd-158">DragUIOverride</span><span class="sxs-lookup"><span data-stu-id="7cfdd-158">DragUIOverride</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx)
* [<span data-ttu-id="7cfdd-159">Drop</span><span class="sxs-lookup"><span data-stu-id="7cfdd-159">Drop</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx)
* [<span data-ttu-id="7cfdd-160">IsDragSource</span><span class="sxs-lookup"><span data-stu-id="7cfdd-160">IsDragSource</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isdragsource.aspx)
