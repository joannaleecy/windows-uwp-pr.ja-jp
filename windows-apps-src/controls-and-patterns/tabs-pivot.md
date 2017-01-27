---
author: Jwmsft
Description: "タブとピボットを使うと、アクセス頻度の高いコンテンツ間を移動できます。"
title: "タブとピボット"
ms.assetid: 556BC70D-CF5D-4295-A655-D58163CC1824
label: Tabs and pivots
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a652189d0595bb6dffbc5228a91a68261eb7e5ef
ms.openlocfilehash: 865969a7c965a502acd9fe24df28128399efd380

---
# <a name="pivot-and-tabs"></a>ピボットとタブ

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

Pivot コントロールと関連タブは、アクセス頻度の高い個別のコンテンツ カテゴリ間を移動するために使います。 ピボットを使うと、2 つ以上のコンテンツ ウィンドウ間を移動できるようになり、テキスト ヘッダーを使ってコンテンツのさまざまなセクションを明確化できます。

![タブの例](images/pivot_Hero_main.png)

タブは、アイコンとテキストの組み合わせ、またはアイコンのみを使ってコンテンツのセクションを明確化するピボットの視覚的な変化形です。 タブは、[**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールを使って構築されます。 [**Pivot のサンプル**](http://go.microsoft.com/fwlink/p/?LinkId=619903)は、Pivot コントロールをタブ パターンへとカスタマイズする方法を示しています。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Pivot クラス**](https://msdn.microsoft.com/library/windows/apps/dn608241)</li>
</ul>
</div>


## <a name="the-pivot-pattern"></a>ピボット パターン

ピボットを使ってアプリを構築する場合は、考慮すべきいくつかの重要なデザインの変数があります。

- **ヘッダー ラベル。**  ヘッダーは、テキスト付きのアイコン、アイコンのみ、またはテキストのみで示すことができます。
- **ヘッダーの整列。**  ヘッダーは、左揃えまたは中央揃えにすることができます。
- **トップレベルまたはサブレベルのナビゲーション。**  ピボットは、いずれかのレベルのナビゲーションで使うことができます。 必要に応じて、[ナビゲーション ウィンドウ](nav-pane.md)をプライマリ レベルで提供し、ピボットをセカンダリとして提供できます。
- **タッチ ジェスチャのサポート。**  タッチ ジェスチャをサポートするデバイスでは、次に示す 2 つの操作セットのどちらかを使ってコンテンツ カテゴリ間を移動できます。
    1. タブ/ピボット ヘッダーをタップして、そのカテゴリに移動します。
    2. コンテンツ領域上で左または右へスワイプして隣接するカテゴリに移動します。

## <a name="examples"></a>例

電話での Pivot コントロール。

![ピボットの例](images/pivot_example.png)

アラーム & クロック アプリのタブ パターン。

![アラーム & クロック内のタブ パターンの例](images/tabs_alarms-and-clock.png)

## <a name="create-a-pivot-control"></a>ピボット コントロールの作成

[**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールには、このセクションで説明する基本的な機能が付属しています。

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

Pivot は [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目をコレクションを含めることができます。 ピボットに追加する項目が明示的に [ **PivotItem** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。 ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [**Items**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。 または、[**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。 ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) と [**HeaderTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。

[**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。 アクティブな項目のインデックスを取得または設定するには、[**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。

### <a name="pivot-headers"></a>ピボット ヘッダー

[**LeftHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [**RightHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。

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

<div class="microsoft-internal-note">
10 フィート環境では、項目が回転しないようにすることを特にお勧めします。 Xbox 上でアプリを実行する場合は、新しい `IsHeaderItemsCarouselEnabled` プロパティを False に設定します。
</div>

**カルーセル**

-   許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。
-   ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。
-   カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。

<div class="microsoft-internal-note">
### ピボット フォーカス

既定では、ピボット ヘッダー上のキーボード フォーカスは下線付きで表示されます。

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

ピボットをカスタマイズし、ヘッダーの選択ビジュアルに下線を組み込んだアプリでは、新しい `HeaderFocusVisualPlacement` プロパティを使って既定の設定を変更できます。 `HeaderFocusVisualPlacement=\"ItemHeaders\"` を指定した場合、フォーカスはヘッダー パネル全体を取り囲むように描画されます。

![ItemsHeader オプションはピボット ヘッダー全体を取り囲むフォーカス用の四角形を描画する](images/pivot_focus_headers.png)
</div>

## <a name="recommendations"></a>推奨事項

-   タブ/ピボット ヘッダーの配置は画面サイズに基づいて行います。 画面幅が 720 epx 未満の場合、通常は中央揃えが適しています。720 epx 以上の画面幅では、ほとんどの場合、左揃えをお勧めします。
-   カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。
-   ピボット項目が個別のアイコンを持つ場合にのみ、タブ パターンを使います。
-   ピボット項目ヘッダーに、ピボットの各セクションの意味を理解できるようなテキストを含めます。 アイコンは、必ずしもすべてのユーザーが容易に判別できるとは限りません。

## <a name="get-the-sample-code"></a>サンプル コードを入手する
- [ピボットのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903)<br/>
    ピボット コントロールをタブ パターンへとカスタマイズする方法を示します。
- [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-topics"></a>関連トピック
- [ナビゲーション デザインの基本](../layout/navigation-basics.md)
- [**ピボットのサンプル**](http://go.microsoft.com/fwlink/p/?LinkId=619903)



<!--HONumber=Dec16_HO1-->


