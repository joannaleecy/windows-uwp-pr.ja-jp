---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。
title: ドラッグ アンド ドロップ
ms.assetid: A15ED2F5-1649-4601-A761-0F6C707A8B7E
author: awkoren
---
# ドラッグ アンド ドロップ

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにドラッグ アンド ドロップを追加する方法について説明します。 ドラッグ アンド ドロップは、画像やファイルなどのコンテンツを操作するための従来からある自然な方法です。 ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、あらゆる方向でシームレスに機能します。

## 有効な領域を設定する

[
            **AllowDrop**][AllowDrop] プロパティと [**CanDrag**][CanDrag] プロパティを使うと、ドラッグ アンド ドロップの操作に有効なアプリ内の領域を指定できます。

次のマークアップは、XAML で [**AllowDrop**][AllowDrop] を使って、アプリの特定の領域をドロップ操作に有効な領域として設定する方法を示しています。 ユーザーが他の場所へのドロップを試みても、ドロップすることはできません。 アプリ内のすべての領域でユーザーが項目をドロップできるようにする場合は、背景全体をドロップ先として設定します。

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDropArea)]

ドラッグ操作では通常、どの項目がドラッグ可能であるか指定しておく必要があります。 ユーザーがドラッグしようとするのは、アプリ内のすべてではなく、画像などの特定の項目です。 XAML を使って [**CanDrag**][CanDrag] を設定する方法を次に示します。

[!code-xml[Main](./code/drag_drop/cs/MainPage.xaml#SnippetDragArea)]

UI のカスタマイズを行う場合 (この記事で後述) を除き、他には何もしなくてもドラッグ操作を有効にできます。 ドロップ操作には、あといくつかの手順が必要です。

## DragOver イベントを処理する

[
            **DragOver**][DragOver] イベントは、ユーザーがアプリに項目をドラッグし、まだドロップしていないときに発生します。 このハンドラーでは、[**DragEventArgs.AcceptedOperation**][AcceptedOperation] プロパティを使って、アプリがサポートしている操作の種類を指定する必要があります。 最も一般的な操作はコピーです。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOver)]

## Drop イベントを処理する

[
            **Drop**][Drop] イベントは、有効なドロップ領域内でユーザーが項目を解放したときに発生します。 これらの処理には [**DragEventArgs.DataView**][DataView] プロパティを使います。

次の例では、わかりやすくするために、ユーザーが単一の写真をドロップしたとします。 実際には、ユーザーがさまざまな形式の複数の項目を同時にドロップすることもあります。 アプリでは、このような可能性にも対応できるようにしておく必要があります。そのためには、ドロップされたファイルの種類をチェックし、種類に応じた処理を実行します。また、サポートしていない動作が行われた場合は、それをユーザーに通知します。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_Drop)]

## UI をカスタマイズする

システムでは、ドラッグ アンド ドロップ用に既定の UI が提供されています。 ただし、カスタムのキャプションやグリフを設定して UI のさまざまな部分をカスタマイズすることも、UI をまったく表示しないこともできます。 UI をカスタマイズするには、[**DragOver**][DragOver] イベント ハンドラーの [**DragUIOverride**][DragUiOverride] プロパティを使います。

[!code-cs[Main](./code/drag_drop/cs/MainPage.xaml.cs#SnippetGrid_DragOverCustom)]

 <!-- LINKS -->
[AllowDrop]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.allowdrop.aspx
[CanDrag]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.candrag.aspx
[DragOver]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.dragover.aspx
[AcceptedOperation]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.acceptedoperation.aspx
[DataView]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.dataview.aspx
[DragUiOverride]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.drageventargs.draguioverride.aspx
[Drop]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.uielement.drop.aspx 



<!--HONumber=Mar16_HO5-->


