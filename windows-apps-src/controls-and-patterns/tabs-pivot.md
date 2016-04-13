---
Description: タブとピボットを使うと、アクセス頻度の高いコンテンツ間を移動できます。
title: タブとピボット
ms.assetid: 556BC70D-CF5D-4295-A655-D58163CC1824
label: タブとピボット
template: detail.hbs
---
# タブとピボット

タブとピボットは、アクセス頻度の高い個別のコンテンツ カテゴリ間を移動するために使います。 タブ/ピボット パターンは、対応するカテゴリ ヘッダーがある 2 つ以上のコンテンツ ウィンドウで構成されます。 ヘッダーは常に画面上に表示され、選択状態が明確に示されるので、ユーザーは現在使っているカテゴリを常に意識するようになります。
![タブの例](images/HIGSecOne_Tabs.png)

タブとピボットは実質的には同じパターンであり、どちらも [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールを使って構築されます。 Pivot コントロールの基本機能については、この記事で後述します。

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**Pivot クラス**](https://msdn.microsoft.com/library/windows/apps/dn608241)

## タブ/ピボット パターン

タブ/ピボット パターンを使ってアプリを構築する場合は、パターンの構成可能な機能セットに基づいて考慮すべきいくつかの重要なデザインの変数があります。

- **ヘッダーの配置。**   ヘッダーは、画面の一番上または一番下に配置できます。
    
    **注**&nbsp;&nbsp;ヘッダーを画面の下部に配置するには、Pivot コントロールを再テンプレート化する必要があります。
- **ヘッダー ラベル。**  ヘッダーは、テキスト付きのアイコン、テキストのみ、またはアイコンのみで示すことができます。
- **ヘッダーの整列。**  ヘッダーは、左揃えまたは中央揃えにすることができます。
- **トップレベルまたはサブレベルのナビゲーション。**  タブ/ピボットは、どちらかのレベルのナビゲーションに使うことができ、トップレベル/サブレベル パターンで並べて表示できます。 タブ/ピボットのレベルが 2 つある場合は、トップレベルとサブレベルのヘッダーを視覚的に差別化して、ユーザーがその 2 つを明確に区別できるようにする必要があります。
- **タッチ ジェスチャのサポート。**  タッチ ジェスチャをサポートするデバイスでは、次に示す 2 つの操作セットのどちらかを使ってコンテンツ カテゴリ間を移動できます。
    1. タブ/ピボット ヘッダーをタップして、そのカテゴリに移動するか、またはコンテンツ領域上でスワイプして隣接するカテゴリに移動します。
    2. タブ/ピボット ヘッダーをタップして、そのカテゴリに移動します (スワイプ操作なし)。

### パターン構成

タブ/ピボット パターンの最適な配置は、操作のシナリオとアプリが表示されるデバイスによって異なります。 次の表に、いくつかの使用頻度の高いシナリオとパターン構成の概要を示します。

操作のシナリオ|推奨される構成
--------------------|-------------------------
携帯電話またはファブレットで 2 ～ 5 個のトップレベルの一覧またはグリッド ビューのコンテンツ カテゴリ間を横方向に移動する|タブ/ピボット: 画面の一番上に配置 (中央揃え)
|ヘッダー ラベル: アイコンとテキスト
|コンテンツ領域でのスワイプ: 有効
携帯電話またはファブレットでコンテンツ カテゴリの範囲内を移動する (ナビゲーション用としては実用的でないコンテンツ領域上でスワイプする)|タブ/ピボット: 画面の一番下に配置 (中央揃え)
|ヘッダー ラベル: アイコンとテキスト
|コンテンツ領域でのスワイプ: 無効
マウスとキーボードを使ったトップレベルのナビゲーション|タブ/ピボット: 画面の一番上に配置 (左揃え)
 *または*|ヘッダー ラベル: テキストのみ
 タッチ デバイスでのページ レベルのナビゲーション|コンテンツ領域でのスワイプ: 無効

## 例

このフード トラック アプリのデザインは、タブ/ピボット ヘッダーを画面の一番上または一番下に配置するとどのようになるかを示しています。 モバイル デバイスでは、一番下に配置すると手に届きやすくなります。

![モバイル デバイスでのタブの例](images/uap_foodtruck_phone_320_tabsboth.png)

ノート PC/デスクトップ PC のフード トラック アプリのデザインではテキストのみのヘッダーを使います。 テキスト付きのアイコンをヘッダーに使うと、タッチ補正には役立ちますが、マウスとキーボードを使う場合はテキストのみのヘッダーが適しています。

![デスクトップ PC でのタブの例](images/uap_foodtruck_desktop_home_700.png)

## ピボット コントロールの作成

タブ/ピボット ナビゲーション パターンは [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールを使って構築します。 このコントロールには、このセクションで説明する基本的な機能が付属しています。

この XAML では、コンテンツの 3 つのセクションで、基本的なピボット コントロールを作成します。

```xaml
<Pivot x:Name="rootPivot" Title="PIVOT TITLE">
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

**ピボット項目**

Pivot は [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目をコレクションを含めることができます。 ピボットに追加する項目が明示的に [ **PivotItem** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。 ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [**Items**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。 または、[**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。 ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) と [**HeaderTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。

[
            **SelectedItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。 アクティブな項目のインデックスを取得または設定するには、[**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。 

**ピボット ヘッダー**

[
            **LeftHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [**RightHeader**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。 

### ピボットの操作

ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。

-   ヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。
-   ヘッダー上で左または右にスワイプすると、隣接するヘッダー/セクションに移動します。
-   セクション コンテンツ上で左または右にスワイプすると、隣接するヘッダー/セクションに移動します。

コントロールには次の 2 つのモードがあります。

**固定**

-   許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。
-   ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。 アクティブなピボットは強調表示されます。

**カルーセル**

-   許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。
-   ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。

このコントロールには、ヘッダーの数とラベルの文字列の長さに基づく組み込みのブレークポイント機能があります。

## 推奨事項

-   タブ/ピボット ヘッダーの配置は画面サイズに基づいて行います。 画面幅が 720 epx 未満の場合、通常は中央揃えが適しています。720 epx 以上の画面幅では、ほとんどの場合、左揃えをお勧めします。
-   ウィンドウの拡大/縮小時に、タブ/ピボット ヘッダーの数が利用可能な領域を超えると、ヘッダーをオーバーフロー領域に表示する処理を開始します。
-   タブ/ピボットは横向きまたは縦向きの画面で使うことができますが、どちらの向きでもヘッダー (表示と非表示) の総数が同じになるようにしてください。
-   カルーセル (ラウンド トリップ) モードを使う場合は、6 つ以上のヘッダーを使わないようにしてください。6 つ以上のヘッダーを使うと、ユーザーが画面の向きを認識できなくなる可能性があります。
-   モバイル デバイスでは、UI の別の部分でスワイプを使う場合や、UI が上部に集中しすぎないようにするために、タブ/ピボットを一番下に配置すると手に届きやすくなります。
-   スクリーン キーボードが表示されている場合は、ヘッダーを画面外に移動して領域を確保できます。

\[この記事には、ユニバーサル Windows プラットフォーム (UWP) アプリと Windows 10 に固有の情報が含まれています。 Windows 8.1 のガイダンスについては、[Windows 8.1 ガイドラインの PDF](https://go.microsoft.com/fwlink/p/?linkid=258743) ファイルをダウンロードしてください。\]

## 関連トピック

[ナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)


<!--HONumber=Mar16_HO1-->


