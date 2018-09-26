---
author: QuinnRadich
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: quradic
ms.date: 06/25/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 6c75169f118e2c8ef575fa251a7badc8cfe44247
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4205650"
---
# <a name="navigation-view-preview-version"></a>ナビゲーション ビュー (プレビュー版)

> **これは、プレビュー版**: この記事ではまだ開発段階には、NavigationView コントロールの新しいバージョンをについて説明します。 それを使用するには、これで、必要な[最新の Windows Insider ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

NavigationView コントロールでは、アプリのトップレベルのナビゲーションを提供します。 適応するように、さまざまな画面サイズをサポートする複数のナビゲーションのスタイル。

> **Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)

> **プラットフォーム Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

## <a name="get-the-windows-ui-library"></a>Windows UI のライブラリを入手します。

このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。 詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。 

## <a name="navigation-styles"></a>ナビゲーションのスタイル

NavigationView がサポートしています。

**左側のナビゲーション ウィンドウやメニュー**

![ナビゲーション ウィンドウの展開](images/displaymode-left.png)

**上部のナビゲーション ウィンドウやメニュー**

![上部のナビゲーション](images/displaymode-top.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

NavigationView は、適しているアダプティブ ナビゲーション コントロールです。

- アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。
- 幅が狭いウィンドウには、画面領域を保持します。
- 多くのナビゲーション カテゴリへのアクセスを編成します。

他のナビゲーション コントロールは、[ナビゲーション デザインの基本](../basics/navigation-basics.md)を参照してください。

ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。

:::row:::
    :::column:::
        ![一部の画像](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    :::column span =「2」::: **XAML コントロール ギャラリー**<br>
        XAML コントロール ギャラリー アプリをインストールした場合は、クリックして<a href="xamlcontrolsgallery:/item/NavigationView">ここで</a>アプリを開き、NavigationView の操作を参照してください。

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="display-modes"></a>表示モード

NavigationView は、経由で、さまざまな表示モードを設定できる、`PaneDisplayMode`プロパティ。

:::row:::
    :::column:::
    ### Left
    Displays an expanded left positioned pane.
    :::column-end:::
    :::column span="2":::
    ![left nav pane expanded](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

左側のナビゲーションをお勧めする場合。

- 同様に重要なトップレベルのナビゲーション カテゴリの中程度の数 (5 ~ 10) があります。
- 他のアプリのコンテンツの領域を節約を非常に目立つナビゲーションのカテゴリがしたいです。

:::row:::
    :::column:::
    ### Top
    Displays a top positioned pane.
    :::column-end:::
    :::column span="2":::
    ![top navigation](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

上部のナビゲーションをお勧めする場合。

- 5 均等に重要なトップレベルのナビゲーションのカテゴリを小さくできるよう、ドロップダウン リストで最終的にすべての追加のトップレベルのナビゲーション カテゴリのオーバーフロー メニューと見なされます重要度の低いか。
- 画面上のすべてのナビゲーション オプションを表示する必要があります。
- アプリのコンテンツの多くのスペースをしたいです。
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

![gif 左のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)

普通サイズの画面と大画面の左上の小さな画面で LeftMinimal、LeftCompact 間適応します。 詳細については、[アダプティブ動作](#adaptive-behavior)を参照してください。

## <a name="anatomy"></a>構造

<b>左側のナビゲーション</b><br>

![左側のナビゲーション ビューのセクション](images/leftnav-anatomy.png)

<b>上部のナビゲーション</b><br>

![上部のナビゲーション ビューのセクション](images/topnav-anatomy.png)

## <a name="pane"></a>ウィンドウ

ウィンドウで、上部または左のいずれか経由で配置する、`PanePosition`プロパティ。

ウィンドウの左と上の位置の詳細ウィンドウの構造を次に示します。

<b>左側のナビゲーション</b><br>

![NavigationView の構造](images/navview-pane-anatomy-vertical.png)

1. メニュー ボタン
1. ナビゲーション項目
1. 区切り文字
1. ヘッダー
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定] ボタン

<b>上部のナビゲーション</b><br>

![NavigationView の構造](images/navview-pane-anatomy-horizontal.png)

1. ヘッダー
1. ナビゲーション項目
1. 区切り文字
1. AutoSuggestBox (省略可能)
1. (省略可能) の設定] ボタン

"戻る"ボタン、ウィンドウの左上隅に表示されますが、NavigationView でコンテンツが自動的にバック スタックに追加できません。 表示を有効にする前に戻るナビゲーション、[前に戻るナビゲーション](#backwards-navigation)セクションします。

NavigationView ウィンドウも含めることができます。

1. 特定のページに移動するための[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)フォーム内のナビゲーション項目
2. 区切り文字、 [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)の形式でナビゲーション項目をグループ化します。 レンダリング領域としての区切り記号を 0 に[Opacity](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)プロパティを設定します。
3. 項目のグループにラベルを付けるための[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)フォーム内のヘッダー
4. アプリ レベルの検索を許可するオプション[AutoSuggestBox](auto-suggest-box.md)します。
5. [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション) 設定項目を非表示にするには、 [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを使用します。

左側のウィンドウが含まれています。

6. メニュー ボタンのウィンドウを開くと閉じるを切り替えます。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

### <a name="pane-footer"></a>ウィンドウのフッター

[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![ウィンドウのフッターに目的の左側のナビゲーション](images/navview-freeform-footer-left.png)<br>
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-header"></a>ウィンドウのヘッダー

[PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティに追加すると、ウィンドウのヘッダーで自由形式のコンテンツ

:::row:::
    :::column:::
    <b>左側のナビゲーション</b><br>
    ![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-content"></a>ウィンドウのコンテンツ

フリー フォーム[PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティに追加すると、ウィンドウのコンテンツ

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

ハードウェアおよびソフトウェア要件が満たされている場合、NavigationView は、そのウィンドウで、[アクリル素材](../style/acrylic.md)とのみで、左側のウィンドウの[表示ハイライト](../style/reveal.md)に自動的に使用します。

## <a name="header"></a>ヘッダー

![ヘッダー領域の汎用的な画像を navview](images/nav-header.png)

ヘッダー領域は、左側のウィンドウの位置でナビゲーション ボタンと垂直に揃えし、は、ウィンドウの上部のウィンドウの位置で下に配置します。 固定高さが 52 ピクセルです。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

NavigationView が最小限に抑えながら表示モードの場合、ヘッダーが表示される必要があります。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。

## <a name="content"></a>コンテンツ

![コンテンツ領域の汎用的な画像を navview](images/nav-content.png)

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。

NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。

## <a name="adaptive-behavior"></a>アダプティブ動作

NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。 ただし、アダプティブ表示モードの動作をカスタマイズする場合があります。

### <a name="default"></a>既定値

NavigationView の既定のアダプティブ動作小さいウィンドウの幅を大きなウィンドウの幅で展開された左側のウィンドウ、普通サイズのウィンドウの幅でアイコン専用の左側のナビゲーション ウィンドウとハンバーガー メニュー ボタンを表示することです。 アダプティブ動作のためのウィンドウ サイズについて詳しくは、[画面サイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。

![gif 左のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)

```xaml
<NavigationView />
```

### <a name="minimal"></a>最小

大きなウィンドウの幅と両方大小の普通サイズのウィンドウの幅をハンバーガー メニューで展開された左側のウィンドウを使用する 2 つ目の一般的なアダプティブ パターンです。

![gif 左のナビゲーションのアダプティブ動作 2](images/adaptive-behavior-minimal.png)

```xaml
<NavigationView CompactModeThresholdWidth="1008" ExpandedModeThresholdWidth="1007" />
```

このときをお勧めします。

- 小さいウィンドウの幅をアプリのコンテンツを追加する領域がしたいです。
- アイコンを含む、ナビゲーションのカテゴリを明確に表示できません。

### <a name="compact"></a>コンパクト

3 番目の一般的なアダプティブ パターンでは、大きなウィンドウの幅と両方大小の普通サイズのウィンドウの幅をアイコン専用の左側のナビゲーション ウィンドウで展開された左側のウィンドウを使用します。 これの良い例では、メール アプリです。

![gif 左のナビゲーションのアダプティブ動作 3](images/adaptive-behavior-compact.png)

```xaml
<NavigationView CompactModeThresholdWidth="0" ExpandedModeThresholdWidth="1007" />
```

このときをお勧めします。

- 常に画面上のすべてのナビゲーション オプションを表示するのには重要です。
- ナビゲーションのカテゴリは、アイコンを含む明確に表すことができます。

### <a name="no-adaptive-behavior"></a>アダプティブ動作がないです。

場合がありますすべてのすべてのアダプティブ動作をしない出す可能性があります。 展開、常にコンパクトまたは最小限常に常にウィンドウを設定することができます。

![gif 左のナビゲーションのアダプティブ動作 4](images/adaptive-behavior-none.png)

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

### <a name="top-to-left-navigation"></a>左側のナビゲーションを上

大きなウィンドウのサイズと小さなの左側のナビゲーションでの上部のナビゲーションの使用をお勧めします。 ウィンドウのサイズを場合。

- 、一緒に表示される均等に重要なトップレベルのナビゲーション カテゴリのセットがある場合に重要度が同じ左側のナビゲーションを折りたたむこのセットの 1 つのカテゴリが画面に収まらない場合、などを設定します。
- 小さいウィンドウ サイズにできるだけ領域がかなりコンテンツを維持したいです。

以下に例を示します。

![gif 上または左側のナビゲーションのアダプティブ動作 1](images/navigation-top-to-left.png)

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

場合によってアプリは、上部のウィンドウの左側のウィンドウを別のデータをバインドする必要があります。 多くの場合、左側のウィンドウより多くのナビゲーション要素が含まれています。

以下に例を示します。

![gif 上または左側のナビゲーションのアダプティブ動作 2](images/navigation-top-to-left2.png)

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

タブのモデルでは、選択とフォーカスが関連付けられます。 通常フォーカスが選択範囲を変えてはも動作を確認します。 次の例では、適切なポイントは選択インジケーターからへの移行ディスプレイ拡大鏡します。 [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus)プロパティを有効に設定して、これを実現することができます。

![テキストのみの最上位 navview のスクリーン ショット](images/nav-tabs.png)

ここでは XAML の例は、その。

```xaml
<NavigationView PanePosition="Top" SelectionFollowsFocus="Enabled" >
   <NavigationView.MenuItems>
        <NavigationViewItem Content="Display" />
        <NavigationViewItem Content="Magnifier"  />
        <NavigationViewItem Content="Keyboard" />
    </NavigationView.MenuItems>
</NavigationView>

```

タブの選択を変更する場合は、コンテンツを入れ替える、フレームの[NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType)メソッドを使ってを False に設定した FrameNavigationOptions.IsNavigationStackEnabled と NavigateOptions.TransitionInfoOverride が適切な側面を側に設定スライドのアニメーションです。 例については、次の[コード例](#code-example)を参照してください。

既定のスタイルを変更する場合は、NavigationView の[MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle)プロパティを上書きすることができます。 さまざまなデータ テンプレートを指定する、[それに続く](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate)プロパティを設定することもできます。

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
    ![NavigationView の"戻る"ボタンを左のナビゲーション](images/leftnav-back.png)
    :::column-end:::
    :::column:::
     <b>上部のナビゲーション</b><br>
    ![上部のナビゲーションで NavigationView の戻るボタン](images/topnav-back.png)
    :::column-end:::
:::row-end:::

## <a name="code-example"></a>コードの例

> [!NOTE]
> NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。
その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。

大規模なウィンドウ サイズの上部のナビゲーション ウィンドウと小さなウィンドウ サイズの左側のナビゲーション ウィンドウの両方で NavigationView を組み込む方法のエンド ツー エンドの例を次に示します。

このサンプルで頻繁に新しいナビゲーションのカテゴリを選択するエンドユーザーと考えてためします。

- 有効に[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを設定します。
- ナビゲーション履歴に追加しないでフレームのナビゲーションを使用します。
- ゲームパッドの左/右バンパーがあるかどうか、アプリのトップレベルのナビゲーションのカテゴリをナビゲートを示すために使用される[ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを既定値を保持します。 既定では"WhenSelectionFollowsFocus です"。 可能なその他の値は、「しない」と「常に」します。

また、前に戻る NavigationView の [戻る] ボタンによるナビゲーションを実装する方法についても説明します。

サンプルの内容のレコーディングを以下に示します。

![NavigationView エンド ツー エンドのサンプル](images/nav-code-example.gif)

サンプル コードを次に示します。

> [!NOTE]
> [Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`xmlns:controls="using:Microsoft.UI.Xaml.Controls"`します。

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
> [Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`using MUXC = Microsoft.UI.Xaml.Controls;`します。

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

NavigationView が上を最小限に抑えながら、またはコンパクト モードの場合、ウィンドウの背景はアプリ内アクリルを示します。 この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。

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

## <a name="scroll-content-under-top-pane"></a>上部のウィンドウの下にスクロール コンテンツ

シームレスな外観と操作感、ScrollViewer を使用するページは、アプリがいて、ナビゲーション ウィンドウは、上部に配置すると、お勧め上部のナビゲーション ウィンドウの下にあるコンテンツのスクロールします。

これを行うには、 [CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds)プロパティを true に関連する ScrollViewer を設定します。

![navview スクロールのナビゲーション ウィンドウ](images/nav-scroll-content.png)

非常に長いスクロールするコンテンツは、アプリがある、場合は、上部のナビゲーション ウィンドウにアタッチし、スムーズなサーフェスを形成する固定ヘッダーを組み込むことを検討してください。 

![navview スクロール固定ヘッダー](images/nav-scroll-stickyheader.png)

これを実現するには NavigationView を[ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを設定します。 

場合によっては、ユーザーは、下へスクロール場合、NavigationView で[IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを false に設定して、ナビゲーション ウィンドウを非表示にします。

![navview スクロールの非表示のナビゲーション](images/nav-scroll-hidepane.png)

## <a name="related-topics"></a>関連トピック

- [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [マスター/詳細](master-details.md)
- [ピボット コントロール](tabs-pivot.md)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [UWP 用 Fluent Design の概要](../fluent-design-system/index.md)