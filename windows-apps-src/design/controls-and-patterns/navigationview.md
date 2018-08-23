---
author: serenaz
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: sezhen
ms.date: 08/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4c0857005d584b1fde0eb52a6ab0ef5ec29eaf44
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2810912"
---
# <a name="navigation-view-preview-version"></a>ナビゲーション ビュー (プレビュー版)

> **これは、プレビューのバージョン**: NavigationView コントロールを開発中の新しいバージョンについて説明します。 それを使用するには、] が必要になった[最新の Windows 内部ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)です。

NavigationView コントロールでは、アプリの最上位レベルのナビゲーションを提供します。 適応するようにさまざまな画面サイズのサポートに複数のナビゲーションのスタイル。

> **Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)

> **Platform Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

## <a name="get-the-windows-ui-library"></a>Windows の UI ライブラリを取得します。

このコントロールは、Windows UI ライブラリで、新しいコントロールと UWP アプリの UI の機能を含む NuGet パッケージの一部として含める。 インストール方法など、さらに詳しい情報は、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)を参照してください。 

## <a name="navigation-styles"></a>ナビゲーションのスタイル

NavigationView がサポートしています。

**左側のナビゲーション ウィンドウまたは [メニュー**

![ナビゲーション ウィンドウの展開](images/displaymode-left.png)

**上部のナビゲーション ウィンドウまたは [メニュー**

![上部のナビゲーション](images/displaymode-top.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

適している適応ナビゲーション コントロールを NavigationView には。

- アプリ全体で一貫したナビゲーション エクスペリエンスを提供します。
- 小さい windows で画面を保持します。
- 多くのナビゲーション カテゴリへのアクセスを整理します。

他のナビゲーション コントロール[ナビゲーション設計の基本」](../basics/navigation-basics.md)を参照してください。

ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。

:::row:::
    :::column:::
        ![一部の画像](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    ::: 列 =「2」::: **XAML コントロール] ギャラリー**<br>
        をクリックして、XAML コントロール ギャラリー アプリがインストールされている場合は、<a href="xamlcontrolsgallery:/item/NavigationView">次のとおり</a>にアプリを開き、アクションの NavigationView を参照してください。

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="display-modes"></a>表示モード

さまざまな表示モードに設定できます NavigationView、`PaneDisplayMode`プロパティ。

:::row:::
    :::column:::
    ### Left
    Displays an expanded left positioned pane.
    :::column-end:::
    :::column span="2":::
    ![left nav pane expanded](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

左側のナビゲーションをお勧め場合。

- 中程度が高く番号 (5 ~ 10) 同等の最上位のカテゴリの情報があります。
- 必要に応じて、非常に目立つナビゲーションの他のアプリのコンテンツの領域が少なくカテゴリに分類します。

:::row:::
    :::column:::
    ### Top
    Displays a top positioned pane.
    :::column-end:::
    :::column span="2":::
    ![top navigation](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

上部のナビゲーションをお勧め場合。

- 5 があるまたは同等の最上位ナビゲーション カテゴリでは、以下を最上位レベルの追加のナビゲーション項目のドロップダウン リストでのオーバーフロー] メニューの [重要度の低い。
- 画面上のすべてのナビゲーション オプションを表示する必要があります。
- 多くの領域を希望するには、アプリのコンテンツにします。
- アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。

:::row:::
    :::column:::
    ### LeftCompact
    Displays a thin sliver with icons on the left.
    :::column-end:::
    :::column span="2":::
    ![nav pane compact](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### LeftMinimal
    Displays only the menu button.
    :::column-end:::
    :::column span="2":::
    ![nav pane minimal](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a>自動

![gif 左のナビゲーションの既定の適応動作](images/displaymode-auto.png)

小さな画面に LeftMinimal、LeftCompact (m)、および大きい画面で、左上に適合します。 詳細については、[適応動作](#adaptive-behavior)」を参照してください。

## <a name="anatomy"></a>構造

<b>左側のナビゲーション</b><br>

![左側の NavigationView セクション](images/leftnav-anatomy.png)

<b>上部のナビゲーション</b><br>

![トップ NavigationView セクション](images/topnav-anatomy.png)

## <a name="pane"></a>ウィンドウ

ウィンドウの上部または左側に経由で配置する、`PanePosition`プロパティ。

ウィンドウの左端と上端の位置の詳細ウィンドウの構造を示します。

<b>左側のナビゲーション</b><br>

![NavigationView 構造](images/navview-pane-anatomy-vertical.png)

1. メニュー ボタン
1. ナビゲーション アイテム
1. 区切り文字
1. ヘッダー
1. (オプション) AutoSuggestBox
1. (オプション) [設定] ボタン

<b>上部のナビゲーション</b><br>

![NavigationView 構造](images/navview-pane-anatomy-horizontal.png)

1. ヘッダー
1. ナビゲーション アイテム
1. 区切り文字
1. (オプション) AutoSuggestBox
1. (オプション) [設定] ボタン

ウィンドウの左上隅の [戻る] ボタンが表示されますが、NavigationView でコンテンツが自動的に戻るスタックに追加されません。 下位のナビゲーションを有効にする] を参照してください、[下位ナビゲーション](#backwards-navigation)] セクション。

NavigationView ウィンドウを含めることもできます。

1. ナビゲーション アイテム、特定のページに移動するための[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)フォームにします。
2. 区切り記号、 [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)を表すナビゲーション アイテムをグループ化します。 0 領域としての区切り記号を表示するには、[透明度](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)のプロパティを設定します。
3. ヘッダー、アイテムのグループに付けるラベルの[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)を表す。
4. 省略可能な[AutoSuggestBox](auto-suggest-box.md)のアプリ レベルの検索を許可します。
5. [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション) 設定項目を非表示にするには、 [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを使用します。

左側のウィンドウが含まれています。

6. ウィンドウを開く/閉じるを切り替えます] メニューをクリックします。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

### <a name="pane-footer"></a>ウィンドウのフッター

[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![フッターの左側のナビゲーションをウィンドウ](images/navview-freeform-footer-left.png)<br>
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![ウィンドウ ヘッダーの上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-header"></a>ウィンドウのヘッダー

[PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティを追加すると、ウィンドウのヘッダーのコンテンツをフリー フォーム

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![ウィンドウ ヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![ウィンドウ ヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-content"></a>ウィンドウのコンテンツ

[PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティを追加すると、ウィンドウの自由形式の内容

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![ウィンドウのカスタム contentleft ナビゲーション](images/navview-freeform-pane-left.png)<br>
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![ウィンドウ カスタム コンテンツ上部のナビゲーション](images/navview-freeform-pane-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="visual-style"></a>視覚スタイル

ハードウェアおよびソフトウェア要件が満たされる NavigationView 自動的にでは、 [Acrylic 数量単価型](../style/acrylic.md)のウィンドウと、左側のウィンドウでのみに[蛍光ペンを表示](../style/reveal.md)します。

## <a name="header"></a>ヘッダー

![ヘッダー領域の navview 標準の画像](images/nav-header.png)

ヘッダー領域は、左側のウィンドウの位置] の [ナビゲーション] ボタンと垂直方向に配置し、上のウィンドウの位置に、ウィンドウの下にあます。 52 の固定の高さがピクセルします。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

ヘッダーは、NavigationView が最低限の表示モード表示されている必要があります。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。

## <a name="content"></a>コンテンツ

![コンテンツ領域の navview 標準の画像](images/nav-content.png)

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。

NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。

## <a name="adaptive-behavior"></a>アダプティブ動作

NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。 ただし、適応表示モードの動作をカスタマイズすることがあります。

### <a name="default"></a>既定値

NavigationView 適応既定では、小さなウィンドウ幅に大きなウィンドウの幅で展開された、左側のウィンドウ、中程度のウィンドウの幅を [アイコンのみの左側のナビゲーション ウィンドウとハンバーガー メニュー ボタンを表示します。 適応動作のウィンドウのサイズの詳細については、[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。

![gif 左のナビゲーションの既定の適応動作](images/displaymode-auto.png)

```xaml
<NavigationView />
```

### <a name="minimal"></a>最小

2 番目の一般的な適応パターンでは、大きなウィンドウの幅、および両方中小ウィンドウの幅でハンバーガー メニューを展開した左側のウィンドウを使用します。

![gif の左のナビゲーション適応動作 2](images/adaptive-behavior-minimal.png)

```xaml
<NavigationView CompactModeThresholdWidth="1008" ExpandedModeThresholdWidth="1007" />
```

このときに行うことをお勧めします。

- 必要に応じて、小さなウィンドウの幅のアプリのコンテンツ領域を広くします。
- アイコンを含む、ナビゲーション カテゴリを明確に表示できません。

### <a name="compact"></a>コンパクト

3 番目の一般的な適応パターンでは、大きなウィンドウの幅、および両方中小ウィンドウの幅でアイコンのみの左側のナビゲーション ウィンドウの展開の左側のウィンドウを使用します。 この例では、メール アプリです。

![gif の左のナビゲーション適応動作 3](images/adaptive-behavior-compact.png)

```xaml
<NavigationView CompactModeThresholdWidth="0" ExpandedModeThresholdWidth="1007" />
```

このときに行うことをお勧めします。

- 常に画面上のすべてのナビゲーション オプションを表示するのには重要です。
- ナビゲーション カテゴリのアイコンを含む明確に表すことができます。

### <a name="no-adaptive-behavior"></a>適応動作なし

ありますまったく適応、動作をいない望む可能性があります。 常に展開された、常にコンパクト、または常に最低限のウィンドウを設定することができます。

![gif の左のナビゲーション適応動作 4](images/adaptive-behavior-none.png)

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

### <a name="top-to-left-navigation"></a>左側のナビゲーションの先頭へ

大きなウィンドウのサイズと小規模の左側のナビゲーションのトップ ナビゲーションを使用することをお勧め] ウィンドウのサイズを場合。

- 非表示に等しい重要度を指定したり、左側のナビゲーションにこのセット内の 1 つのカテゴリを画面に収まらない場合は、次のような一緒に表示されるにはカテゴリを均等に重要な最上位レベルのナビゲーションのセットがあります。
- 小さなウィンドウ サイズにできるだけスペースを大幅にコンテンツを保持したいです。

以下に例を示します。

![gif の上部または左側のナビゲーション適応動作 1](images/navigation-top-to-left.png)

```xaml
<Grid >
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                </VisualState.StateTriggers>

                <VisualState.Setters>
                    <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>

    <NavigationView x:Name="NavigationViewControl" >
        <NavigationView.MenuItems>
            <NavigationViewItem Content="A" x:Name="A" />
            <NavigationViewItem Content="B" x:Name="B" />
            <NavigationViewItem Content="C" x:Name="C" />
        </NavigationView.MenuItems>
    </NavigationView>
</Grid>

```

アプリは、上のウィンドウと左側のウィンドウに別のデータにバインドする必要があります。 左側のウィンドウにはナビゲーションの他の要素が含まれています。

以下に例を示します。

![gif の上部または左側のナビゲーション適応動作 2](images/navigation-top-to-left2.png)

```xaml
<Page >
    <Page.Resources>
        <DataTemplate x:name="navItem_top_temp" x:DataType="models:Item">
            <NavigationViewItem Background= Icon={x:Bind TopIcon}, Content={x:Bind TopContent}, Visibility={x:Bind TopVisibility} />
        </DataTemplate>

        <DataTemplate x:name="navItem_temp" x:DataType="models:Item">
            <NavigationViewItem Icon={x:Bind Icon}, Content={x:Bind Content}, Visibility={x:Bind Visibility} />
        </DataTemplate>
        
        <services:NavViewDataTemplateSelector x:Key="navview_selector" 
              NavItemTemplate="{StaticResource navItem_temp}" 
              NavItemTopTemplate="{StaticResource navItem_top_temp}" 
              NavPaneDisplayMode="{x:Bind NavigationViewControl.PaneDisplayMode}">
        </services:NavViewDataTemplateSelector>
    </Page.Resources>

    <Grid >
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <NavView x:Name='NavigationViewControl' MenuItemsSource={x:Bind items}   
                 PanePosition = "Top" MenuItemTemplateSelector="navview_selector" />
    </Grid>
</Page>

```

```csharp
ObservableCollection<Item> items = new ObservableCollection<Item>();
items.Add(new Item() {
    Content = "Aa",
    TopContent ="A",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});
items.Add(new Item() {
    Content = "Bb",
    TopContent = "B",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});
items.Add(new Item() {
    Content = "Cc",
    TopContent = "C",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});

public class NavViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NavItemTemplate { get; set; }

        public DataTemplate NavItemTopTemplate { get; set; }    

     public NavigationViewPaneDisplayMode NavPaneDisplayMode { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            Item currItem = item as Item;
            if (NavPaneDisplayMode == NavigationViewPanePosition.Top)
                return NavItemTopTemplate;
            else 
                return NavItemTemplate;
        }   

    }

```

## <a name="interaction"></a>操作

ウィンドウのナビゲーション項目をユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) イベントが発生します。 タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) イベントが発生します。

アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。 また、プログラムによってナビゲーション項目からコンテンツに[フォーカス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.FocusState) を移動することをお勧めします。 読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。

### <a name="tabs"></a>タブ

モデルでは、タブ、オブジェクトの選択とフォーカスが関連付けられています。 通常の方法でフォーカスを移動が選択範囲を移動するも動作します。 例では、下にある右ポイントはインジケーターを移動選択表示拡大します。 [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus)プロパティを有効に設定して、これを実現できます。

![テキストのみの最上位 navview のスクリーン ショット](images/nav-tabs.png)

ここ XAML の例ではその。

```xaml
<NavigationView PanePosition="Top" SelectionFollowsFocus="Enabled" >
   <NavigationView.MenuItems>
        <NavigationViewItem Content="Display" />
        <NavigationViewItem Content="Magnifier"  />
        <NavigationViewItem Content="Keyboard" />
    </NavigationView.MenuItems>
</NavigationView>

```

False に設定された FrameNavigationOptions.IsNavigationStackEnabled フレームの[NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType)メソッドを使用する] タブの [選択範囲を変更するときに、コンテンツを入れ替える] と、該当する情報をスナップする NavigateOptions.TransitionInfoOverride を設定します。アニメーションにスライドします。 例については、次の[例](#code-example)を参照してください。

既定のスタイルを変更する場合は、NavigationView の[MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle)プロパティを無視することができます。 別のデータのテンプレートを指定するのには、[それに続く](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate)プロパティを設定することもできます。

## <a name="backwards-navigation"></a>逆方向のナビゲーション

NavigationView には組み込みの [戻る] ボタンがあります。これは、次のプロパティで有効にすることができます。

- [**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) は既定で NavigationViewBackButtonVisible 列挙と「自動」になっています。 [戻る] ボタンの表示/非表示を切り替えるために使用します。 ボタンが表示されていない場合は、[戻る] ボタンを描画するための領域は折りたたまれます。
- [**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) は既定では false に設定されており、[戻る] ボタンの状態を切り替えるために使用できます。
- [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) はユーザーが [戻る] ボタンをクリックした場合に発生します。
    - 最小/コンパクト モードで NavigationView.Pane がポップアップとして開いているときに [戻る] ボタンをクリックすると、ウィンドウが閉じ、代わりに **PaneClosing** イベントが発生します。
    - IsBackEnabled が false の場合は発生しません。

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![[戻る] ボタンを NavigationView 左のナビゲーション](images/leftnav-back.png)
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![上部のナビゲーションで [戻る] ボタンを NavigationView](images/topnav-back.png)
    :::column-end:::
:::row-end:::

## <a name="code-example"></a>コードの例

> [!NOTE]
> NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。
その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。

次に、サイズの大きなウィンドウの上部のナビゲーション ウィンドウと、小さなウィンドウ サイズに左側のナビゲーション ウィンドウの両方を含む NavigationView を組み込む方法のエンドの例を示します。

エンドユーザー頻繁に新しいナビゲーション カテゴリを選択するには、この例では、予想などは。

- 有効に[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを設定します。
- ナビゲーション スタックに追加しないフレーム ナビゲーションを使用します。
- 既定値を示す、ゲーム パッドで左/右エンジンがアプリのナビゲーションのトップレベル カテゴリを移動するかどうかに使用される[ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティは、オンのままにします。 既定では"WhenSelectionFollowsFocus です"。 しない] と、他の値は「常に」です。

下位の NavigationView の [戻る] ボタンとナビゲーションを実装する方法を説明します。

サンプルの内容の記録を示します。

![NavigationView-エンドツー エンドのサンプル](images/nav-code-example.gif)

サンプル コードを示します。

> [!NOTE]
> [Windows ユーザー インターフェイスのライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`xmlns:controls="using:Microsoft.UI.Xaml.Controls"`します。

```xaml
<Page
    x:Class="NavigationViewSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:NavigationViewSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="{x:Bind NavView.CompactModeThresholdWidth}" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="NavView.PaneDisplayMode" Value="Top"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <NavigationView x:Name="NavView"
                    SelectionFollowsFocus="Enabled"
                    ItemInvoked="NavView_ItemInvoked"
                    IsSettingsVisible="True"
                    Loaded="NavView_Loaded"
                    BackRequested="NavView_BackRequested"
                    Header="Welcome">

            <NavigationView.MenuItems>
                <NavigationViewItem Content="Home" x:Name="home" Tag="home">
                    <NavigationViewItem.Icon>
                        <FontIcon Glyph="&#xE10F;"/>
                    </NavigationViewItem.Icon>
                </NavigationViewItem>
                <NavigationViewItemSeparator/>
                <NavigationViewItemHeader Content="Main pages"/>
                <NavigationViewItem Icon="AllApps" Content="Apps" x:Name="apps" Tag="apps"/>
                <NavigationViewItem Icon="Video" Content="Games" x:Name="games" Tag="games"/>
                <NavigationViewItem Icon="Audio" Content="Music" x:Name="music" Tag="music"/>
            </NavigationView.MenuItems>

            <NavigationView.AutoSuggestBox>
                <AutoSuggestBox x:Name="ASB" QueryIcon="Find"/>
            </NavigationView.AutoSuggestBox>

            <NavigationView.HeaderTemplate>
                <DataTemplate>
                    <Grid Margin="24,10,0,0">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <TextBlock Style="{StaticResource TitleTextBlockStyle}"
                           FontSize="28"
                           VerticalAlignment="Center"
                           Text="Welcome"/>
                        <CommandBar Grid.Column="1"
                            HorizontalAlignment="Right"
                            VerticalAlignment="Top"
                            DefaultLabelPosition="Right"
                            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
                            <AppBarButton Label="Refresh" Icon="Refresh"/>
                            <AppBarButton Label="Import" Icon="Import"/>
                        </CommandBar>
                    </Grid>
                </DataTemplate>
            </NavigationView.HeaderTemplate>

            <Frame x:Name="ContentFrame" Margin="24"/>

        </NavigationView>
    </Grid>
</Page>
```

> [!NOTE]
> [Windows ユーザー インターフェイスのライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`using MUXC = Microsoft.UI.Xaml.Controls;`します。

```csharp
// List of ValueTuple holding the Navigation Tag and the relative Navigation Page 
private readonly IList<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("home", typeof(HomePage)),
    ("apps", typeof(AppsPage)),
    ("games", typeof(GamesPage)),
    ("music", typeof(MusicPage)),
};

private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    // You can also add items in code behind
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem
    {
        Content = "My content",
        Icon = new SymbolIcon(Symbol.Folder),
        Tag = "content"
    });
    _pages.Add(("content", typeof(MyContentPage)));

    ContentFrame.Navigated += On_Navigated;

    // NavView doesn't load any page by default: you need to specify it
    NavView_Navigate("home");

    // Add keyboard accelerators for backwards navigation
    var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
    goBack.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(goBack);

    // ALT routes here
    var altLeft = new KeyboardAccelerator
    {
        Key = VirtualKey.Left,
        Modifiers = VirtualKeyModifiers.Menu
    };
    altLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(altLeft);
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{

    if (args.IsSettingsInvoked)
        ContentFrame.Navigate(typeof(SettingsPage));
    else
    {
        // Getting the Tag from Content (args.InvokedItem is the content of NavigationViewItem)
        var navItemTag = NavView.MenuItems
            .OfType<NavigationViewItem>()
            .First(i => args.InvokedItem.Equals(i.Content))
            .Tag.ToString();

        NavView_Navigate(navItemTag);
    }
}

private void NavView_Navigate(string navItemTag)
{
    var item = _pages.First(p => p.Tag.Equals(navItemTag));
    ContentFrame.Navigate(item.Page);
}

private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
{
    On_BackRequested();
}

private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
    On_BackRequested();
    args.Handled = true;
}

private bool On_BackRequested()
{
    if (!ContentFrame.CanGoBack)
        return false;

    // Don't go back if the nav pane is overlayed
    if (NavView.IsPaneOpen &&
        (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
        NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
        return false;

    ContentFrame.GoBack();
    return true;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag
        NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
    }
    else
    {
        var item = _pages.First(p => p.Page == e.SourcePageType);

        NavView.SelectedItem = NavView.MenuItems
            .OfType<NavigationViewItem>()
            .First(n => n.Tag.Equals(item.Tag));
    }
}
```

## <a name="customizing-backgrounds"></a>背景をカスタマイズ

NavigationView のメイン領域の背景を変更するには、その `Background` プロパティを目的のブラシに設定します。

ウィンドウの背景は、上、最低限、またはコンパクト モードでは、NavigationView した場合に、アプリで acrylic を示します。 この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。

```xaml
<Application.Resources>
    <ResourceDictionary>
        <AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewTopPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewExpandedPaneBackground"
        BackgroundSource="HostBackdrop" TintColor="Orange" TintOpacity=".8"/>
    </ResourceDictionary>
</Application.Resources>
```

## <a name="scroll-content-under-top-pane"></a>上のウィンドウの下にスクロール コンテンツ

シームレスな外観 + 外観の場合は、アプリを ScrollViewer を使用するページがあり、ナビゲーション ウィンドウが上に配置すると、お勧めが生じるコンテンツの上部のナビゲーション ウィンドウの下にスクロールします。

これを true に関連する ScrollViewer で[CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds)プロパティを設定して実現できます。

![navview スクロールのナビゲーション ウィンドウ](images/nav-scroll-content.png)

アプリが非常に長いコンテンツをスクロールに場合は、固定のヘッダーを上部のナビゲーション ウィンドウに添付して、フォームの面が滑らかに組み込むことを検討することができます。 

![navview スクロールの上部に固定されたヘッダー](images/nav-scroll-stickyheader.png)

これを行う NavigationView で[ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを設定します。 

場合によっては、ユーザーは、下へスクロール場合は NavigationView で[IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを false に設定して、ナビゲーション ウィンドウを非表示にすることがあります。

![navview スクロールの非表示のナビゲーション](images/nav-scroll-hidepane.png)

## <a name="related-topics"></a>関連トピック

- [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [マスター/詳細](master-details.md)
- [ピボット コントロール](tabs-pivot.md)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [UWP 用 Fluent Design の概要](../fluent-design-system/index.md)