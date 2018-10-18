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
ms.openlocfilehash: a4685a891facab39cb984f0b2d5f697e22477233
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4967612"
---
# <a name="drag-and-drop"></a>ドラッグ アンド ドロップ

ドラッグ アンド ドロップは、Windows デスクトップでアプリケーション内またはアプリケーション間でデータを転送するための直感的な方法です。 ドラッグ アンド ドロップを利用すると、ユーザーは、標準ジェスチャ (指で押したままパン、またはマウスやスタイラスでボタンを押したままパン) 使ってアプリケーション間やアプリケーション内でデータを転送できます。

> **重要な API**: [CanDrag プロパティ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag)、[AllowDrop プロパティ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) 

ドラッグ ソース (ドラッグ ジェスチャがトリガーされたアプリケーションや領域) は、標準的なデータ形式 (テキスト、RTF、HTML、ビットマップ、ストレージ項目) やカスタム データ形式を含むことができるデータ パッケージ オブジェクトに入力することによって、転送されるデータを提供します。 ソースは、ソースがサポートする操作の種類 (コピー、移動、リンク) も示します。 ポインターが離されたときにドロップが発生します。 ドロップ ターゲット (ポインターの下にあるアプリケーションや領域) は、データ パッケージを処理し、実行される操作の種類を返します。

ドラッグ アンド ドロップを行っているとき、ドラッグ UI によって、実行されているドラッグ アンド ドロップ操作の種類が視覚的に示されます。 この視覚的なフィードバックは、ソースによって最初に提供されますが、ポインターがターゲットの上に移動したときに、ターゲットによって変更することができます。

最新のドラッグ アンド ドロップは、UWP をサポートするすべてのデバイスで利用できます。 このドラッグ アンド ドロップでは、すべての種類のアプリケーション間やアプリケーション内でデータを転送できます。こうしたアプリケーションには従来の Windows アプリも含まれますが、この記事では、最新のドラッグ アンド ドロップについては XAML API に焦点を当てています。 ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、すべて方向でシームレスに機能します。

アプリでドラッグ アンド ドロップを有効にする場合に必要となることの概要を次に示します。

1. 要素に対してドラッグを有効にするには、要素の **CanDrag** プロパティを true に設定します。  
2. データ パッケージを作成します。 システムでは画像とテキストが自動的に処理されますが、他のコンテンツについては、**DragStarted** イベントと **DragCompleted** イベントを手動で処理し、これらを使って独自のデータ パッケージを作成する必要があります。 
3. ドロップされるコンテンツを受け取ることができるすべての要素に対して、**AllowDrop** プロパティを **true** に設定することで、ドロップを有効にします。 
4. **DragOver** イベントを処理して、要素が受け取ることができるドラッグ操作の種類をシステムに通知します。 
5. **Drop** イベントを処理して、ドロップされるコンテンツを受け取ります。 



## <a name="enable-dragging"></a>ドラッグを有効にする

要素に対してドラッグを有効にするには、要素の [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) プロパティを **true** に設定します。 これにより、要素 (およびその要素を含む要素 (ListView などのコレクションの場合)) をドラッグ可能にします。

どの要素をドラッグ可能にするかを、明確にしておいてください。 ユーザーは、アプリ内にあるすべての項目をドラッグできるようにするのではなく、画像やテキストなどの特定の項目のみをドラッグすることを必要としています。 

[**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) の設定方法を次に示します。

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

UI をカスタマイズする場合 (この記事の後半で説明します) を除き、他には何もしなくてもドラッグ操作を有効にできます。 ドロップ操作には、あといくつかの手順が必要です。

## <a name="construct-a-data-package"></a>データ パッケージを作成する 

ほとんどの場合、システムによってデータ パッケージが自動的に作成されます。 システムでは、次のコンテンツが自動的に処理されます。
* 画像
* テキスト 

他のコンテンツについては、**DragStarted** イベントと **DragCompleted** イベントを手動で処理し、これらを使って独自の [DataPackage](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datapackage) を作成する必要があります。

## <a name="enable-dropping"></a>ドロップを有効にする

次のマークアップは、XAML で [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) を使って、アプリの特定の領域をドロップ操作に有効な領域として設定する方法を示しています。 ユーザーが他の場所へのドロップを試みても、ドロップすることはできません。 アプリ内のすべての領域でユーザーが項目をドロップできるようにする場合は、背景全体をドロップ先として設定します。

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]


## <a name="handle-the-dragover-event"></a>DragOver イベントを処理する

[**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) イベントは、ユーザーがアプリに項目をドラッグし、まだドロップしていないときに発生します。 このハンドラーでは、[**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) プロパティを使って、アプリがサポートしている操作の種類を指定する必要があります。 最も一般的な操作はコピーです。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## <a name="process-the-drop-event"></a>Drop イベントを処理する

[**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントは、有効なドロップ領域内でユーザーが項目を放したときに発生します。 放した項目を処理するには [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) プロパティを使います。

次の例では、わかりやすくするために、ユーザーが 1 枚の写真をドロップし、その写真に直接アクセスすることを前提としています。 実際には、ユーザーがさまざまな形式の複数の項目を同時にドロップすることもあります。 アプリでは、このような可能性にも対応できるようにしておく必要があります。そのためには、ドロップされたファイルの種類とその数を確認し、これらに応じた処理を実行します。 また、アプリでサポートしていない動作が行われた場合は、それをユーザーに通知することも考慮してください。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## <a name="customize-the-ui"></a>UI をカスタマイズする

システムでは、ドラッグ アンド ドロップ用に既定の UI が提供されています。 ただし、カスタムのキャプションやグリフを設定して UI のさまざまな部分をカスタマイズすることも、UI をまったく表示しないこともできます。 UI をカスタマイズするには、[**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) プロパティを使います。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

## <a name="open-a-context-menu-on-an-item-you-can-drag-with-touch"></a>タッチによるドラッグが可能な項目のコンテキスト メニューを開く

タッチを使い、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement) をドラッグして、コンテキスト メニューを開くには、類似したタッチ ジェスチャを使用します。それぞれ長押しから始まります。 アプリの要素が 2 つのアクションをサポートしている場合に、システムがそれを区別する方法を次に示します。 

* ユーザーがある項目を長押しし、500 ミリ秒以内にドラッグを開始した場合、項目はドラッグされ、コンテキスト メニューは表示されません。 
* ユーザーが長押ししてから 500 ミリ秒以内にドラッグしなかった場合には、コンテキスト メニューが開きます。 
* コンテキスト メニューが開いた後に、ユーザーが指を離すことなく、項目をドラッグしようとすると、コンテキスト メニューは閉じられ、ドラッグが開始されます。

## <a name="designate-an-item-in-a-listview-or-gridview-as-a-folder"></a>ListView または GridView の項目をフォルダーとして指定する

[ **ListViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListViewItem) または [ **GridViewItem** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridViewItem) をフォルダーとして指定できます。 これは、ツリー ビューとエクスプローラーのシナリオで特に便利です。 これを行うには、その項目で [ **AllowDrop** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティを明示的に **True** に設定します。 

(非フォルダー項目にではなく) フォルダーにドロップするための、適切なアニメーションが自動的に表示されます。 アプリのコードは、フォルダー項目の[**ドロップ**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントの処理 (および非フォルダー項目の処理) を継続し、データ ソースを更新して、ドロップ先のフォルダーにドロップされた項目を追加する必要があります。

## <a name="implementing-custom-drag-and-drop"></a>カスタムのドラッグ アンド ドロップを実装する

[UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) クラスは、ドラッグ アンド ドロップを実装するためのほとんどの処理を自動的に実行します。 する場合は、 [Windows.ApplicationModel.DataTransfer.DragDrop.Core 名前空間](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.datatransfer.dragdrop.core)の Api を使用して、独自のバージョンを実装することができます。

| 機能 | WinRT API |
| --- | --- |
|  ドラッグを有効にする | [CoreDragOperation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.dragdrop.core.coredragoperation)  |
|  データ パッケージを作成する | [DataPackage](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datapackage)  |
| ドラッグをシェルに渡す  | [CoreDragOperation.StartAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.dragdrop.core.coredragoperation)  |
| シェルからドロップを受け取る  | [CoreDragDropManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.dragdrop.core.coredragdropmanager)<br/>[ICoreDropOperationTarget](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.dragdrop.core.icoredropoperationtarget)    |



## <a name="see-also"></a>関連項目

* [アプリ間通信](index.md)
* [AllowDrop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx)
* [CanDrag](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx)
* [DragOver](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx)
* [AcceptedOperation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx)
* [DataView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx)
* [DragUIOverride](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx)
* [Drop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx)
* [IsDragSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isdragsource.aspx)
