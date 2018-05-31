---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。
title: ドラッグ アンド ドロップ
ms.assetid: A15ED2F5-1649-4601-A761-0F6C707A8B7E
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7854c0bb541c04ec3cc109ad32ce30ba1c8bd52e
ms.sourcegitcommit: 9f059b37e45099b4314c96a0b604449e966d3c3c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2018
ms.locfileid: "1704653"
---
# <a name="drag-and-drop"></a><span data-ttu-id="8b211-104">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="8b211-104">Drag and drop</span></span>



<span data-ttu-id="8b211-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8b211-105">This article explains how to add dragging and dropping in your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="8b211-106">ドラッグ アンド ドロップは、画像やファイルなどのコンテンツを操作するための従来からある自然な方法です。</span><span class="sxs-lookup"><span data-stu-id="8b211-106">Drag and drop is a classic, natural way of interacting with content such as images and files.</span></span> <span data-ttu-id="8b211-107">ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、あらゆる方向でシームレスに機能します。</span><span class="sxs-lookup"><span data-stu-id="8b211-107">Once implemented, drag and drop works seamlessly in all directions, including app-to-app, app-to-desktop, and desktop-to app.</span></span>

## <a name="set-valid-areas"></a><span data-ttu-id="8b211-108">有効な領域を設定する</span><span class="sxs-lookup"><span data-stu-id="8b211-108">Set valid areas</span></span>

<span data-ttu-id="8b211-109">[**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティと [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) プロパティを使うと、ドラッグ アンド ドロップの操作に有効なアプリ内の領域を指定できます。</span><span class="sxs-lookup"><span data-stu-id="8b211-109">Use the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) and [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) properties to designate the areas of your app valid for dragging and dropping.</span></span>

<span data-ttu-id="8b211-110">次のマークアップは、XAML で [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) を使って、アプリの特定の領域をドロップ操作に有効な領域として設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8b211-110">The following markup shows how to set a specific area of the app as valid for dropping by using the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) in XAML.</span></span> <span data-ttu-id="8b211-111">ユーザーが他の場所へのドロップを試みても、ドロップすることはできません。</span><span class="sxs-lookup"><span data-stu-id="8b211-111">If a user tries to drop somewhere else, the system won't let them.</span></span> <span data-ttu-id="8b211-112">アプリ内のすべての領域でユーザーが項目をドロップできるようにする場合は、背景全体をドロップ ターゲットとして設定します。</span><span class="sxs-lookup"><span data-stu-id="8b211-112">If you want users to be able to drop items anywhere on your app, set the entire background as a drop target.</span></span>

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]

<span data-ttu-id="8b211-113">ドラッグ操作では通常、どの項目がドラッグ可能であるか指定しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b211-113">With dragging, you'll usually want to be specific about what's draggable.</span></span> <span data-ttu-id="8b211-114">ユーザーがドラッグしようとするのは、アプリ内のすべてではなく、画像などの特定の項目です。</span><span class="sxs-lookup"><span data-stu-id="8b211-114">Users will want to drag certain items, such as pictures, not everything in your app.</span></span> <span data-ttu-id="8b211-115">XAML を使って [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) を設定する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8b211-115">Here's how to set [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) by using XAML.</span></span>

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

<span data-ttu-id="8b211-116">UI をカスタマイズする場合 (この記事の後半で説明します) を除き、他には何もしなくてもドラッグ操作を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="8b211-116">You don't need to do any other work to allow dragging, unless you want to customize the UI (which is covered later in this article).</span></span> <span data-ttu-id="8b211-117">ドロップ操作には、あといくつかの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="8b211-117">Dropping requires a few more steps.</span></span>

## <a name="handle-the-dragover-event"></a><span data-ttu-id="8b211-118">DragOver イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="8b211-118">Handle the DragOver event</span></span>

<span data-ttu-id="8b211-119">[**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) イベントは、ユーザーがアプリに項目をドラッグし、まだドロップしていないときに発生します。</span><span class="sxs-lookup"><span data-stu-id="8b211-119">The [**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) event fires when a user has dragged an item over your app, but not yet dropped it.</span></span> <span data-ttu-id="8b211-120">このハンドラーでは、[**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) プロパティを使って、アプリがサポートしている操作の種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b211-120">In this handler, you need to specify what kind of operations your app supports by using the [**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) property.</span></span> <span data-ttu-id="8b211-121">最も一般的な操作はコピーです。</span><span class="sxs-lookup"><span data-stu-id="8b211-121">Copy is the most common.</span></span>

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## <a name="process-the-drop-event"></a><span data-ttu-id="8b211-122">Drop イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="8b211-122">Process the Drop event</span></span>

<span data-ttu-id="8b211-123">[**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントは、有効なドロップ領域内でユーザーが項目を放したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="8b211-123">The [**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) event occurs when the user releases items in a valid drop area.</span></span> <span data-ttu-id="8b211-124">放した項目を処理するには [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="8b211-124">Process them by using the [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) property.</span></span>

<span data-ttu-id="8b211-125">次の例では、わかりやすくするために、ユーザーが単一の写真をドロップして直接それにアクセスしたとします。</span><span class="sxs-lookup"><span data-stu-id="8b211-125">For simplicity in the example below, we'll assume the user dropped a single photo and access it directly.</span></span> <span data-ttu-id="8b211-126">実際には、ユーザーがさまざまな形式の複数の項目を同時にドロップすることもあります。</span><span class="sxs-lookup"><span data-stu-id="8b211-126">In reality, users can drop multiple items of varying formats simultaneously.</span></span> <span data-ttu-id="8b211-127">アプリで、ドロップされたファイルの種類とファイル数を確認することでこの状況を処理し、状況に応じてそれぞれを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b211-127">Your app should handle this possibility by checking what types of files were dropped and how many there are, and process each accordingly.</span></span> <span data-ttu-id="8b211-128">また、ユーザーがアプリでサポートされていない処理を実行しようとしたときに、ユーザーに通知することを検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b211-128">You should also consider notifying the user if they're trying to do something your app doesn't support.</span></span>

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## <a name="customize-the-ui"></a><span data-ttu-id="8b211-129">UI をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="8b211-129">Customize the UI</span></span>

<span data-ttu-id="8b211-130">システムでは、ドラッグ アンド ドロップ用に既定の UI が提供されています。</span><span class="sxs-lookup"><span data-stu-id="8b211-130">The system provides a default UI for dragging and dropping.</span></span> <span data-ttu-id="8b211-131">ただし、カスタムのキャプションやグリフを設定して UI のさまざまな部分をカスタマイズすることも、UI をまったく表示しないこともできます。</span><span class="sxs-lookup"><span data-stu-id="8b211-131">However, you can also choose to customize various parts of the UI by setting custom captions and glyphs, or by opting not to show a UI at all.</span></span> <span data-ttu-id="8b211-132">UI をカスタマイズするには、[**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="8b211-132">To customize the UI, use the [**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) property.</span></span>

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

## <a name="open-a-context-menu-on-an-item-you-can-drag-with-touch"></a><span data-ttu-id="8b211-133">タッチによるドラッグが可能な項目のコンテキスト メニューを開く</span><span class="sxs-lookup"><span data-stu-id="8b211-133">Open a context menu on an item you can drag with touch</span></span>

<span data-ttu-id="8b211-134">タッチを使い、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement) をドラッグして、コンテキスト メニューを開くには、類似したタッチ ジェスチャを使用します。それぞれ長押しから始まります。</span><span class="sxs-lookup"><span data-stu-id="8b211-134">When using touch, dragging a [**UIElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement) and opening its context menu share similar touch gestures; each begins with a press and hold.</span></span> <span data-ttu-id="8b211-135">アプリの要素が 2 つのアクションをサポートしている場合に、システムがそれを区別する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8b211-135">Here's how the system disambiguates between the two actions for elements in your app that support both:</span></span> 

* <span data-ttu-id="8b211-136">ユーザーがある項目を長押しし、500 ミリ秒以内にドラッグを開始した場合、項目はドラッグされ、コンテキスト メニューは表示されません。</span><span class="sxs-lookup"><span data-stu-id="8b211-136">If a user presses and holds an item and begins dragging it within 500 milliseconds, the item is dragged and the context menu is not shown.</span></span> 
* <span data-ttu-id="8b211-137">ユーザーが長押ししてから 500 ミリ秒以内にドラッグしなかった場合には、コンテキスト メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="8b211-137">If the user presses and holds but does not drag within 500 milliseconds, the context menu is opened.</span></span> 
* <span data-ttu-id="8b211-138">コンテキスト メニューが開いた後に、ユーザーが指を離すことなく、項目をドラッグしようとすると、コンテキスト メニューは閉じられ、ドラッグが開始されます。</span><span class="sxs-lookup"><span data-stu-id="8b211-138">After the context menu is open, if the user tries to drag the item (without lifting their finger), the context menu is dismissed and the drag will start.</span></span>

## <a name="designate-an-item-in-a-listview-or-gridview-as-a-folder"></a><span data-ttu-id="8b211-139">ListView または GridView の項目をフォルダーとして指定する</span><span class="sxs-lookup"><span data-stu-id="8b211-139">Designate an item in a ListView or GridView as a folder</span></span>

<span data-ttu-id="8b211-140">[ **ListViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListViewItem) または [ **GridViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridViewItem) をフォルダーとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="8b211-140">You can specify a [**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListViewItem) or [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridViewItem) as a folder.</span></span> <span data-ttu-id="8b211-141">これは、ツリー ビューとエクスプローラーのシナリオで特に便利です。</span><span class="sxs-lookup"><span data-stu-id="8b211-141">This is particularly useful for TreeView and File Explorer scenarios.</span></span> <span data-ttu-id="8b211-142">これを行うには、その項目で [ **AllowDrop** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティを明示的に **True** に設定します。</span><span class="sxs-lookup"><span data-stu-id="8b211-142">To do so, explicitly set the [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) property to **True** on that item.</span></span> 

<span data-ttu-id="8b211-143">(非フォルダー項目にではなく) フォルダーにドロップするための、適切なアニメーションが自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="8b211-143">The system will automatically show the appropriate animations for dropping into a folder versus a non-folder item.</span></span> <span data-ttu-id="8b211-144">アプリのコードは、フォルダー項目の[**ドロップ**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントの処理 (および非フォルダー項目の処理) を継続し、データ ソースを更新して、ドロップ先のフォルダーにドロップされた項目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b211-144">Your app code must continue to handle the [**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) event on the folder item (as well as on the non-folder item) in order to update the data source and add the dropped item to the target folder.</span></span>

## <a name="see-also"></a><span data-ttu-id="8b211-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="8b211-145">See also</span></span>

* [<span data-ttu-id="8b211-146">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="8b211-146">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="8b211-147">AllowDrop</span><span class="sxs-lookup"><span data-stu-id="8b211-147">AllowDrop</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx)
* [<span data-ttu-id="8b211-148">CanDrag</span><span class="sxs-lookup"><span data-stu-id="8b211-148">CanDrag</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx)
* [<span data-ttu-id="8b211-149">DragOver</span><span class="sxs-lookup"><span data-stu-id="8b211-149">DragOver</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx)
* [<span data-ttu-id="8b211-150">AcceptedOperation</span><span class="sxs-lookup"><span data-stu-id="8b211-150">AcceptedOperation</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx)
* [<span data-ttu-id="8b211-151">DataView</span><span class="sxs-lookup"><span data-stu-id="8b211-151">DataView</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx)
* [<span data-ttu-id="8b211-152">DragUIOverride</span><span class="sxs-lookup"><span data-stu-id="8b211-152">DragUIOverride</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx)
* [<span data-ttu-id="8b211-153">Drop</span><span class="sxs-lookup"><span data-stu-id="8b211-153">Drop</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx)
* [<span data-ttu-id="8b211-154">IsDragSource</span><span class="sxs-lookup"><span data-stu-id="8b211-154">IsDragSource</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isdragsource.aspx)
