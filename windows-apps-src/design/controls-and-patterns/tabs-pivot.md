---
author: serenaz
Description: Tabs and pivots enable users to navigate between frequently accessed content.
title: タブとピボット
ms.assetid: 556BC70D-CF5D-4295-A655-D58163CC1824
label: Tabs and pivots
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 09e88fd070f7e7517e55d6f57563dd7608696770
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1675479"
---
# <a name="pivot-and-tabs"></a>ピボットとタブ



Pivot コントロールと関連タブは、アクセス頻度の高い個別のコンテンツ カテゴリ間を移動するために使います。 ピボットを使うと、2 つ以上のコンテンツ ウィンドウ間を移動できるようになり、テキスト ヘッダーを使ってコンテンツのさまざまなセクションにラベル付けできます。

> **重要な API**: [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)

![ピボット コントロールの例](images/pivot_Hero_main.png)

タブは、アイコンとテキストの組み合わせ、またはアイコンのみを使ってコンテンツのセクションを明確化するピボットの視覚的な変化形です。 タブは、[Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールを使って構築されます。 [Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903)は、Pivot コントロールをタブ パターンへとカスタマイズする方法を示しています。

![タブ パターンの例](images/tabs.png) 

## <a name="the-pivot-control"></a>ピボット コントロール

ピボットを使ってアプリを構築する場合は、考慮すべきいくつかの重要なデザインの変数があります。

- **ヘッダー ラベル。**  ヘッダーは、テキスト付きのアイコン、アイコンのみ、またはテキストのみで示すことができます。
- **ヘッダーの整列。**  ヘッダーは、左揃えまたは中央揃えにすることができます。
- **トップレベルまたはサブレベルのナビゲーション。**  ピボットは、いずれかのレベルのナビゲーションで使うことができます。 必要に応じて、[ナビゲーション ビュー](navigationview.md)をプライマリ レベルで提供し、ピボットをセカンダリとして提供できます。
- **タッチ ジェスチャのサポート。**  タッチ ジェスチャをサポートするデバイスでは、次に示す 2 つの操作セットのどちらかを使ってコンテンツ カテゴリ間を移動できます。
    1. タブ/ピボット ヘッダーをタップして、そのカテゴリに移動します。
    2. コンテンツ領域上で左または右へスワイプして隣接するカテゴリに移動します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Pivot">アプリを開き、Pivot の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

電話での Pivot コントロール。

![ピボットの例](images/pivot_example.png)

アラーム & クロック アプリのタブ パターン。

![アラーム & クロック内のタブ パターンの例](images/tabs_alarms-and-clock.png)

## <a name="create-a-pivot-control"></a>ピボット コントロールの作成

[Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) コントロールには、このセクションで説明する基本的な機能が付属しています。

この XAML では、コンテンツの 3 つのセクションで、基本的なピボット コントロールを作成します。

```xaml
<Pivot x:Name="rootPivot" Title="Pivot Title">
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

### <a name="pivot-items"></a>ピボット項目

Pivot は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。 ピボットに追加する項目が明示的に [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。 ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。 または、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。 ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)と [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。

[SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。 アクティブな項目のインデックスを取得または設定するには、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。

### <a name="pivot-headers"></a>ピボット ヘッダー

[LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。

たとえば、[CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) をピボットの RightHeader に追加できます。

![ピボット コントロールの右側のヘッダーにあるコマンド バーの例](images/PivotHeader.png)

```xaml
<Pivot>
    <Pivot.RightHeader>
        <CommandBar OverflowButtonVisibility="Collapsed" Background="Transparent">
                <AppBarButton Icon="Add"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Edit"/>
                <AppBarButton Icon="Delete"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Save"/>
        </CommandBar>
    </Pivot.RightHeader>
</Pivot>
```

### <a name="pivot-interaction"></a>ピボットの操作

ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。

-   ピボット項目のヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。
-   ピボット項目のヘッダー上で左または右へスワイプすると、隣接するセクションに移動します。
-   セクション コンテンツ上で左または右へスワイプすると、隣接するセクションに移動します。

![セクション コンテンツ上で左にスワイプする例](images/pivot_w_hand.png)

コントロールには次の 2 つのモードがあります。

**固定**

-   許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。
-   ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。 アクティブなピボットは強調表示されます。

**カルーセル**

-   許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。
-   ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。
-   カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。

> **注** ピボット ヘッダーを [10 フィート環境](../devices/designing-for-tv.md)でカルーセル表示しないでください。 Xbox 上でアプリを実行する場合は、[IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) プロパティを **false** に設定します。

### <a name="pivot-focus"></a>ピボット フォーカス

既定では、ピボット ヘッダー上のキーボード フォーカスは下線付きで表示されます。

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

ピボットをカスタマイズし、ヘッダーの選択ビジュアルに下線を組み込んだアプリでは、[HeaderFocusVisualPlacement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.HeaderFocusVisualPlacement) プロパティを使って既定の設定を変更できます。 `HeaderFocusVisualPlacement="ItemHeaders"` を指定した場合、フォーカスはヘッダー パネル全体を取り囲むように描画されます。

![ItemsHeader オプションはピボット ヘッダー全体を取り囲むフォーカス用の四角形を描画する](images/pivot_focus_headers.png)

## <a name="recommendations"></a>推奨事項

- タブ/ピボット ヘッダーの配置は画面サイズに基づいて行います。 画面幅が 720 epx 未満の場合、通常は中央揃えが適しています。720 epx 以上の画面幅では、ほとんどの場合、左揃えをお勧めします。
- カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。
- ピボット項目が個別のアイコンを持つ場合にのみ、タブ パターンを使います。
- ピボット項目ヘッダーに、ピボットの各セクションの意味を理解できるようなテキストを含めます。 アイコンは、必ずしもすべてのユーザーが容易に判別できるとは限りません。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903) - Pivot コントロールをタブ パターンへとカスタマイズする方法を示しています。
- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-topics"></a>関連トピック

- [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)
- [ナビゲーション デザインの基本](../basics/navigation-basics.md)
