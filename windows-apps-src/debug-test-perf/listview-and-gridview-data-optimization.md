---
author: jwmsft
ms.assetid: 3A477380-EAC5-44E7-8E0F-18346CC0C92F
title: ListView と GridView のデータ仮想化
description: データ仮想化によって ListView と GridView のパフォーマンスと起動時間を向上させます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: eab90ebf2bcb1912292af6503f833e3bfa334d8b
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
ms.locfileid: "894706"
---
# <a name="listview-and-gridview-data-virtualization"></a>ListView と GridView のデータ仮想化

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

**注**  詳しくは、//build/ セッション「[Dramatically Increase Performance when Users Interact with Large Amounts of Data in GridView and ListView (ユーザーが GridView と ListView で大量のデータを操作するときのパフォーマンスを大幅に向上させる)](https://channel9.msdn.com/Events/Build/2013/3-158)」をご覧ください。

データ仮想化によって [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) のパフォーマンスと起動時間を向上させます。 UI の仮想化、要素の削減、項目の段階的な更新については、「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」をご覧ください。

データ仮想化のメソッドは、大きすぎてメモリに一度に格納できないか、すべてを格納する必要がないデータ セットで必要です。 最初の部分を (ローカル ディスク、ネットワーク、またはクラウドから) メモリに読み込んで、その部分的なデータ セットに UI の仮想化を適用します。 データは、後から段階的に読み込むことも、マスター データ セット内の任意の位置からオンデマンドで読み込むこともできます (ランダム アクセス)。 データ仮想化が適しているかどうかは、多数の要因によって決まります。

-   データ セットのサイズ
-   各項目のサイズ
-   データ セットのソース (ローカル ディスク、ネットワーク、またはクラウド)
-   アプリの総合的なメモリ消費量

**注**  ListView と GridView では、ユーザーがパンやスクロールの操作をすばやく行った場合に一時的なプレースホルダーの視覚効果を表示する機能が既定で有効になることに注意してください。 これらのプレース ホルダーの視覚効果は、データが読み込まれると項目テンプレートに置き換えられます。 この機能は、[**ListViewBase.ShowsScrollingPlaceholders**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.showsscrollingplaceholders) を false に設定することによって無効にできますが、その場合は、x:Phase 属性を使って項目テンプレートの要素を段階的にレンダリングすることをお勧めします。 詳しくは、「[GridView と ListView の項目を段階的に更新する](optimize-gridview-and-listview.md#update-items-incrementally)」をご覧ください。

以降では、段階的なデータ仮想化とランダム アクセスのデータ仮想化の手法について詳しく説明します。

## <a name="incremental-data-virtualization"></a>段階的なデータ仮想化

段階的なデータ仮想化では、データを連続的にダウンロードします。 段階的なデータ仮想化を実行する [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を使って、数百万の項目のコレクションを表示できますが、最初は 50 個の項目だけが読み込まれます。 ユーザーがパン/スクロールすると、次の 50 個の項目が読み込まれます。 項目が読み込まれると、スクロール バーのサムはサイズが小さくなります。 この種のデータ仮想化では、次のインターフェイスを実装するデータ ソース クラスを記述します。

-   [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx)
-   [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) (C#/VB) または [**IObservableVector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/BR226052) (C++/CX)
-   [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916)

このようなデータ ソースは、継続的に拡張できるメモリ内リストです。 項目コントロールは、標準的な [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) インデクサーとカウント プロパティを使って項目を要求します。 カウントは、データセットの実際のサイズではなく、ローカルでの項目の数を表す必要があります。

項目コントロールは、既存のデータの終わりに近づいたときに [**ISupportIncrementalLoading.HasMoreItems**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.isupportincrementalloading.hasmoreitems) を呼び出します。 **true** が返された場合は、アドバタイズされた読み込む項目数を渡す [**ISupportIncrementalLoading.LoadMoreItemsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.isupportincrementalloading.loadmoreitemsasync) を呼び出します。 データの読み込み元 (ローカル ディスク、ネットワーク、またはクラウド) に応じて、アドバタイズされた項目数とは異なる数の項目を読み込むことができます。 たとえば、サービスは 50 項目のバッチをサポートしているが、項目コントロールは 10 項目のみを要求している場合、50 項目を読み込むことができます。 バックエンドからデータを読み込んでリストに追加した後、[**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) または [**IObservableVector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/BR226052) 経由で変更通知を発行して、項目コントロールが新しい項目を認識できるようにします。 さらに、実際に読み込んだ項目の数を返します。 アドバタイズされた数よりも少ない項目を読み込むか、項目コントロールが途中でさらにパン/スクロールされた場合は、データ ソースをもう一度呼び出して、さらに項目を読み込むサイクルが続けられます。 詳しくは、Windows 8.1 の [XAML データ バインディングのサンプル](https://code.msdn.microsoft.com/windowsapps/Data-Binding-7b1d67b5)をダウンロードしてご覧ください。また、Windows 10 アプリでソース コードを再利用することもできます。

## <a name="random-access-data-virtualization"></a>ランダム アクセスのデータ仮想化

ランダム アクセスのデータ仮想化を使うと、データ セット内の任意の位置からデータを読み込むことができます。 ランダム アクセスのデータ仮想化を実行する [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を、100 万の項目があるコレクションを表示するために使うと、100,000 番目から 100,050 番目の項目を読み込むことができます。 ユーザーが一覧の先頭に移動すると、コントロールは 1 番目から 50 番目の項目を読み込みます。 スクロール バーのサムは、常に **ListView** に 100 万の項目が含まれていることを示します。 スクロール バーのサムの位置は、表示されている項目がコレクションのデータ セット全体で相対的にどこに位置しているかを示します。 この種のデータ仮想化は、必要なメモリを大幅に減らし、コレクションの読み込み時間を大きく短縮します。 これを有効にするには、データをオンデマンドで取得し、ローカル キャッシュを管理し、次のインターフェイスを実装するデータ ソース クラスを記述する必要があります。

-   [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx)
-   [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) (C#/VB) または [**IObservableVector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/BR226052) (C++/CX)
-   (必要に応じて) [**IItemsRangeInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877070)
-   (必要に応じて) [**ISelectionInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877074)

[**IItemsRangeInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877070) は、コントロールが実際に使っている項目の情報を提供します。 項目コントロールはビューが変更されるたびにこのメソッドを呼び出し、その中には 次の 2 つの範囲のセットが含まれます。

-   ビューポート内の項目のセット。
-   項目コントロールが使う項目で、ビューポートに表示されない可能性がある、仮想化されていない項目のセット。
    -   タッチ パンをスムーズに行えるようにするために項目コントロールが保持している、ビューポートの周囲の項目のバッファー。
    -   フォーカスが置かれている項目。
    -   先頭の項目。

[**IItemsRangeInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877070) を実装することで、データ ソースは、どの項目をフェッチしてキャッシュする必要があり、不要になったキャッシュ データをいつ除去するかがわかります。 **IItemsRangeInfo** は、[**ItemIndexRange**](https://msdn.microsoft.com/library/windows/apps/Dn877081) オブジェクトを使って、コレクション内のインデックスに基づいてオブジェクトのセットを記述します。 これは、正しくないか安定していない可能性がある項目ポインターを使わないようにするためです。 **IItemsRangeInfo** は、項目コントロールの状態情報に頼っているため、項目コントロールの 1 つのインスタンスでのみ使われるように設計されています。 複数の項目コントロールが同じデータにアクセスする必要がある場合は、それぞれに対してデータ ソースの個別のインスタンスが必要です。 それらは共通のキャッシュを共有できますが、キャッシュから消去するためのロジックはもっと複雑です。

ランダム アクセスのデータ仮想化データ ソースのための基本的な戦略を次に示します。

-   項目を要求されたとき
    -   メモリ内の項目を利用できる場合はその項目を返します。
    -   利用できない場合は、null またはプレースホルダー項目を返します。
    -   項目に対する要求 (または [**IItemsRangeInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877070) からの範囲要求) を使って、どの項目が必要であるかを調べ、バックエンドから項目のデータを非同期的に取得します。 データを取得した後、[**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) または [**IObservableVector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/BR226052) 経由で変更通知を発行して、項目コントロールが新しい項目を認識できるようにします。
-   (必要に応じて) 項目コントロールのビューポートが変更されるときに、[**IItemsRangeInfo**](https://msdn.microsoft.com/library/windows/apps/Dn877070) の実装を利用して、データ ソースのどの項目が必要であるかを特定します。

その他のいつデータ項目を読み込むか、いくつ読み込むか、そしてどの項目をメモリに保持するかは、アプリケーションにまかされます。 いくつかの一般的な考慮事項を次に示します。

-   データは非同期に要求します。UI スレッドをブロックしないでください。
-   項目を取得するバッチのサイズのスイート スポットを探します。 ブロックで処理するようにします。 小さな要求を何度も繰り返すほど小さくなく、取得するまで時間がかかりすぎるほど大きくないサイズにします。
-   同時に保留中にする要求の数を検討します。 簡単なのは一度に 1 つずつ実行することですが、完了までの時間がかかる場合は遅くなりすぎる可能性があります。
-   データの要求を取り消すことができるかどうか。
-   ホストされるサービスを使っている場合は、トランザクションごとにコストが発生するかどうか。
-   クエリの結果が変更されるときにサービスによって提供される通知の種類は何か。 項目がンデックス 33 に挿入されたことがわかるか。 サービスがキーとオフセットに基づくクエリをサポートする場合は、インデックスだけを使うよりも適している可能性があります。
-   項目のプリフェッチをいかにスマートに実行するか。 必要な項目を予測するためにスクロールの方向と速度を追跡する予定ですか。
-   キャッシュの消去をどの程度積極的に行うか。 これはメモリとエクスペリエンスのトレードオフです。




