---
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。"
title: "ドラッグ アンド ドロップ"
ms.assetid: A15ED2F5-1649-4601-A761-0F6C707A8B7E
author: awkoren
ms.sourcegitcommit: 03f3f86ed1310e6e3ac5f53cc5e81ebef708a1a2
ms.openlocfilehash: ffa2f0f368a61ef4f3003c1fa03e143b26c6859b

---
# ドラッグ アンド ドロップ

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。 ドラッグ アンド ドロップは、画像やファイルなどのコンテンツを操作するための従来からある自然な方法です。 ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、あらゆる方向でシームレスに機能します。

## 有効な領域を設定する

[**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) プロパティと [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) プロパティを使うと、ドラッグ アンド ドロップの操作に有効なアプリ内の領域を指定できます。

次のマークアップは、XAML で [**AllowDrop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.AllowDrop) を使って、アプリの特定の領域をドロップ操作に有効な領域として設定する方法を示しています。 ユーザーが他の場所へのドロップを試みても、ドロップすることはできません。 アプリ内のすべての領域でユーザーが項目をドロップできるようにする場合は、背景全体をドロップ先として設定します。

[!code-xml[メイン](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]

ドラッグ操作では通常、どの項目がドラッグ可能であるか指定しておく必要があります。 ユーザーがドラッグしようとするのは、アプリ内のすべてではなく、画像などの特定の項目です。 XAML を使って [**CanDrag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.CanDrag) を設定する方法を次に示します。

[!code-xml[メイン](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

UI をカスタマイズする場合 (この記事の後半で説明します) を除き、他には何もしなくてもドラッグ操作を有効にできます。 ドロップ操作には、あといくつかの手順が必要です。

## DragOver イベントを処理する

[**DragOver**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DragOver) イベントは、ユーザーがアプリに項目をドラッグし、まだドロップしていないときに発生します。 このハンドラーでは、[**AcceptedOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.AcceptedOperation) プロパティを使って、アプリがサポートしている操作の種類を指定する必要があります。 最も一般的な操作はコピーです。

[!code-cs[メイン](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## Drop イベントを処理する

[**Drop**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.Drop) イベントは、有効なドロップ領域内でユーザーが項目を放したときに発生します。 放した項目を処理するには [**DataView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DataView) プロパティを使います。

次の例では、わかりやすくするために、ユーザーが単一の写真をドロップしたとします。 実際には、ユーザーがさまざまな形式の複数の項目を同時にドロップすることもあります。 アプリでは、このような可能性にも対応できるようにしておく必要があります。そのためには、ドロップされたファイルの種類を確認し、種類に応じた処理を実行します。また、アプリでサポートしていない動作が行われた場合は、それをユーザーに通知します。

[!code-cs[メイン](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## UI をカスタマイズする

システムでは、ドラッグ アンド ドロップ用に既定の UI が提供されています。 ただし、カスタムのキャプションやグリフを設定して UI のさまざまな部分をカスタマイズすることも、UI をまったく表示しないこともできます。 UI をカスタマイズするには、[**DragEventArgs.DragUIOverride**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.DragEventArgs.DragUIOverride) プロパティを使います。

[!code-cs[メイン](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

## 参照

* [AllowDrop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx)
* [CanDrag](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx)
* [DragOver](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx)
* [AcceptedOperation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx)
* [DataView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx)
* [DragUiOverride](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx)
* [Drop](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx)


<!--HONumber=Jun16_HO5-->


