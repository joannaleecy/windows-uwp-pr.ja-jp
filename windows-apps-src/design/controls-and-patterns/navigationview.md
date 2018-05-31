---
author: serenaz
Description: Control that provides top-level app navigation with an automatically adapting, collapsible left navigation menu
title: ナビゲーション ビュー
ms.assetid: ''
label: Navigation view
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: vasriram
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 7fc365a7dbc69819ce88a22db2490b327412c8b4
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1675369"
---
# <a name="navigation-view"></a>ナビゲーション ビュー

ナビゲーション ビュー コントロールでは、アプリ内でトップレベルのナビゲーションを行うための折りたたみ可能なナビゲーション メニューを提供します。 このコントロールは、ナビゲーション ウィンドウ (またはハンバーガー メニュー) パターンを実装し、ウィンドウの表示モードをさまざまなウィンドウ サイズに自動的に合わせます。

> **重要な API**: [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、[NavigationViewItem クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)、[NavigationViewDisplayMode 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)

![NavigationView の例](images/navview_wireframe.png)

## <a name="video-summary"></a>概要 (ビデオ)

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev010/player]

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

NavigationView は、次の場合に適しています。

-  同じような種類のさまざまなトップレベルのナビゲーション項目。 (たとえば、フットボール、野球、バスケットボール、サッカーといったカテゴリがあるスポーツ アプリなどです。)
-  トップレベルのナビゲーションのカテゴリの数が中程度から多い (5 ～ 10 個の) 場合。
-  一貫性のあるナビゲーション エクスペリエンスを提供する場合。 このウィンドウにはナビゲーション要素のみを含める必要があります。アクションは含めません。
-  小さいウィンドウの画面領域を節約します。

NavigationView は、いくつかある利用可能なナビゲーション要素の 1 つです。 他のナビゲーション パターンと要素について詳しくは、「[ナビゲーション デザインの基本](../basics/navigation-basics.md)」をご覧ください。

NavigationView コントロールには、単純なナビゲーション ウィンドウ パターンを実装する多くの組み込みの動作があります。 ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。

## <a name="examples"></a>例
<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="navigationview-sections"></a>NavigationView セクション

![NavigationView セクション](images/navview_sections.png)

### <a name="pane"></a>ウィンドウ

組み込みのナビゲーション ("ハンバーガー") ボタンを使用して、ユーザーはウィンドウを開いたり閉じたりすることができます。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。 ハンバーガーの横に表示されるテキスト ラベルは、[PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle) プロパティです。

組み込みの戻るボタンは、ウィンドウの左上隅に表示されます。 NavigationView コントロールによって自動的にバック スタックにコンテンツが追加されたりすることはありませんが、前に戻る移動を有効にするには、[前に戻る移動](#backwards-navigation) セクションをご覧ください。

NavigationView ウィンドウには以下が含まれる可能性もあります。

- 特定のページに移動するための、[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem) という形式のナビゲーション項目
- ナビゲーション項目をグループ化するための、[NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) という形式の区切り
- 項目のグループにラベルを付けるための、[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) という形式のヘッダー
- アプリ レベルの検索を可能にする [AutoSuggestBox](auto-suggest-box.md) (オプション)
- [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション) 設定項目を非表示にするには、[IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) プロパティを使用します。
- [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。

#### <a name="visual-style"></a>視覚スタイル

NavigationView 項目は、選択、無効化、ホバー、押下、およびフォーカスされた表示状態に対応しています。

![NavigationView 項目の状態: 無効化、ホバー、押下、フォーカス](images/navview_item-states.png)

ハードウェアとソフトウェアの要件が満たされている場合、NavigationView によって新しい[アクリル素材](../style/acrylic.md)と[表示ハイライト](../style/reveal.md)が自動的にウィンドウで使用されます。

### <a name="header"></a>ヘッダー

ヘッダー領域は、ナビゲーション ボタンと垂直に揃えられていて、高さが 52 ピクセルに固定されています。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

NavigationView が最小モードの場合は、ヘッダーが表示される必要があります。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。

### <a name="content"></a>コンテンツ

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。 

NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。

## <a name="navigationview-display-modes"></a>NavigationView 表示モード
NavigationView ウィンドウは開いたり閉じたりすることができます。次の 3 つの表示モード オプションがあります。
-  **最小**: ハンバーガー ボタンのみが固定され、必要に応じてウィンドウが表示されたり、非表示になったりします。
-  **コンパクト**: ウィンドウは細長い小片として常に表示され、このウィンドウは幅全体まで開くことができます。
-  **展開**: ウィンドウはコンテンツと共に開いています。 ハンバーガー ボタンを使って閉じると、ウィンドウの幅が細長い小片になります。

既定では、コントロールで利用できる画面領域の大きさに基づいて、システムによって最適な表示モードが自動的に選択されます。 (この設定を[無効](#overriding-the-default-adaptive-behavior) にすることができます。)

### <a name="minimal"></a>最小

![閉じたウィンドウと開いたウィンドウを表示している、最小モードの NavigationView](images/navview_minimal.png)

-  閉じている場合、既定ではウィンドウが非表示になり、ナビゲーション ボタンのみが表示されます。
-  画面領域を節約するオンデマンドのナビゲーションを提供します。 携帯電話やファブレット上のアプリに最適です。
-  ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。 コンテンツは再配置されません。
-  開いている場合、ウィンドウの表示は一時的なもので、選択したり、戻るボタンを押したり、ウィンドウの外側をタップしたりするなど、簡易非表示ジェスチャで閉じることができます。
-  ウィンドウのオーバーレイが開いている場合は、選択した項目が表示されます。
-  要件が満たされていると、開いているウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。
-  既定では、全体の幅が 640 ピクセル以下の場合、NavigationView は最小モードになります。

### <a name="compact"></a>コンパクト

![閉じたウィンドウと開いたウィンドウを表示している、コンパクト モードの NavigationView](images/navview_compact.png)

-  閉じている場合、アイコンとナビゲーション ボタンだけを表示した垂直方向のウィンドウの小片が表示されます。
-  わずかな画面領域を使用して、選択された場所を示します。
-  このモードは、タブレットや [10 フィート エクスペリエンス](../devices/designing-for-tv.md)などの普通サイズの画面に適しています。
-  ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。 コンテンツは再配置されません。
-  ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。
-  選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。
-  要件が満たされていると、ウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。
-  既定では、全体の幅が 641 ～ 1007 ピクセルの場合、NavigationView はコンパクト モードになります。

### <a name="expanded"></a>展開

![開いているウィンドウを表示している、展開モードの NavigationView](images/navview_expanded.png)

-  既定では、ウィンドウは開いたままです。 このモードは、大きな画面に適しています。
-  ウィンドウと、ヘッダーおよびコンテンツが左右に並べて描画され、利用可能な領域内でコンテンツが再配置されます。
-  ナビゲーション ボタンを使用してウィンドウを閉じると、ウィンドウはヘッダーとコンテンツと並んで細長い小片として表示されます。
-  ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。
-  選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。
-  要件が満たされている場合は、ウィンドウの背景が[背景アクリル](../style/acrylic.md#acrylic-blend-types)を使って描画されます。
-  既定では、全体の幅が 1007 ピクセルを超える場合、NavigationView は展開モードになります。

### <a name="overriding-the-default-adaptive-behavior"></a>既定のアダプティブ動作のオーバーライド

NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。

> [!NOTE] 
NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。
その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。 

表示モードの動作をカスタマイズする場合を示した次のシナリオを考えてみましょう。

- **移動が頻繁**: ユーザーがアプリ領域間を多少頻繁に移動することが予想される場合は、ウィンドウ幅を狭くしたウィンドウを表示し続けることを検討します。 曲、アルバム、およびアーティストのナビゲーション領域がある音楽アプリでは、280 ピクセルのウィンドウ幅を選び、アプリ ウィンドウの幅が 560 ピクセルよりも広い場合に展開モードを維持することができます。
```xaml
<NavigationView OpenPaneLength="280" CompactModeThresholdWidth="560" ExpandedModeThresholdWidth="560"/>
```

- **移動がほとんどない** ユーザーがアプリ領域間をほとんど移動しないことが予想されるなら、ウィンドウ幅が広がってもウィンドウの非表示を維持することを検討します。 複数のレイアウトを使用する電卓アプリでは、1080p ディスプレイでアプリが最大化されている場合でも、最小モードを維持できます。
```xaml
<NavigationView CompactModeThresholdWidth="1920" ExpandedModeThresholdWidth="1920"/>
```

- **アイコンの不明瞭解消** アプリのナビゲーション領域が、わかりやすいアイコンに向いていない場合は、コンパクトモードの使用を避けます。 コレクション、アルバム、およびフォルダーのナビゲーション領域のある画像表示アプリでは、幅が狭いときや中間のときは NavigationView を最小モードで表示し、幅が広いときは展開モードで表示することができます。
```xaml
<NavigationView CompactModeThresholdWidth="1008"/>
```

## <a name="interaction"></a>操作

ウィンドウのナビゲーション項目をユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) イベントが発生します。 タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) イベントが発生します。 

アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。 また、プログラムによってナビゲーション項目からコンテンツに[フォーカス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.FocusState) を移動することをお勧めします。 読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。

## <a name="backwards-navigation"></a>逆方向のナビゲーション
NavigationView には組み込みの [戻る] ボタンがあります。これは、次のプロパティで有効にすることができます。
- [**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) は既定で NavigationViewBackButtonVisible 列挙と「自動」になっています。 [戻る] ボタンの表示/非表示を切り替えるために使用します。 ボタンが表示されていない場合は、[戻る] ボタンを描画するための領域は折りたたまれます。
- [**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) は既定では false に設定されており、[戻る] ボタンの状態を切り替えるために使用できます。
- [**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) はユーザーが [戻る] ボタンをクリックした場合に発生します。
    - 最小/コンパクト モードで NavigationView.Pane がポップアップとして開いているときに [戻る] ボタンをクリックすると、ウィンドウが閉じ、代わりに **PaneClosing** イベントが発生します。
    - IsBackEnabled が false の場合は発生しません。

![NavigationView の [戻る] ボタン](../basics/images/back-nav/NavView.png)

## <a name="code-example"></a>コードの例

NavigationView をアプリに組み込む方法の簡単な例を次に示します。 

NavigationView の [戻る] ボタンを使用して前に戻る移動を実装する方法を示します。 NavigationView の "戻る" ナビゲーション プロパティを使用するには、[Windows 10 Insider Preview (導入された v10.0.17110.0)](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) が必要です。

`x:Uid` を使用してナビゲーション項目コンテンツ文字列のローカライズについても説明します。 ローカライズの使用について詳しくは、[UI 内の文字列のローカライズ](../../app-resources/localize-strings-ui-manifest.md)に関するページをご覧ください。

```xaml
<Page
    x:Class="NavigationViewSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:NavigationViewSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <NavigationView x:Name="NavView"
                    ItemInvoked="NavView_ItemInvoked"
                    Loaded="NavView_Loaded"
                    BackRequested="NavView_BackRequested">

        <NavigationView.MenuItems>
            <NavigationViewItem x:Uid="HomeNavItem" Content="Home" Tag="home">
                <NavigationViewItem.Icon>
                    <FontIcon Glyph="&#xE10F;"/>
                </NavigationViewItem.Icon>
            </NavigationViewItem>
            <NavigationViewItemSeparator/>
            <NavigationViewItemHeader Content="Main pages"/>
            <NavigationViewItem x:Uid="AppsNavItem" Icon="AllApps" Content="Apps" Tag="apps"/>
            <NavigationViewItem x:Uid="GamesNavItem" Icon="Video" Content="Games" Tag="games"/>
            <NavigationViewItem x:Uid="MusicNavItem" Icon="Audio" Content="Music" Tag="music"/>
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

        <NavigationView.PaneFooter>
            <HyperlinkButton x:Name="MoreInfoBtn"
                             Content="More info"
                             Click="More_Click"
                             Margin="12,0"/>
        </NavigationView.PaneFooter>

        <Frame x:Name="ContentFrame" Margin="24">
            <Frame.ContentTransitions>
                <TransitionCollection>
                    <NavigationThemeTransition/>
                </TransitionCollection>
            </Frame.ContentTransitions>
        </Frame>

    </NavigationView>
</Page>
```

```csharp
private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    // you can also add items in code behind
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem()
    { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

    // set the initial SelectedItem 
    foreach (NavigationViewItemBase item in NavView.MenuItems)
    {
        if (item is NavigationViewItem && item.Tag.ToString() == "home")
        {
            NavView.SelectedItem = item;
            break;
        }
    }
            
    ContentFrame.Navigated += On_Navigated;

    // add keyboard accelerators for backwards navigation
    KeyboardAccelerator GoBack = new KeyboardAccelerator();
    GoBack.Key = VirtualKey.GoBack;
    GoBack.Invoked += BackInvoked;
    KeyboardAccelerator AltLeft = new KeyboardAccelerator();
    AltLeft.Key = VirtualKey.Left;
    AltLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(GoBack);
    this.KeyboardAccelerators.Add(AltLeft);
    // ALT routes here
    AltLeft.Modifiers = VirtualKeyModifiers.Menu;
    
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{  
    if (args.IsSettingsInvoked)
    {
        ContentFrame.Navigate(typeof(SettingsPage));
    }
    else
    {
        // find NavigationViewItem with Content that equals InvokedItem
        var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
        NavView_Navigate(item as NavigationViewItem);
    }
}

private void NavView_Navigate(NavigationViewItem item)
{
    switch (item.Tag)
    {
        case "home":
            ContentFrame.Navigate(typeof(HomePage));
            break;

        case "apps":
            ContentFrame.Navigate(typeof(AppsPage));
            break;

        case "games":
            ContentFrame.Navigate(typeof(GamesPage));
            break;

        case "music":
            ContentFrame.Navigate(typeof(MusicPage));
            break;

        case "content":
            ContentFrame.Navigate(typeof(MyContentPage));
            break;
    }           
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
    bool navigated = false;

    // don't go back if the nav pane is overlayed
    if (NavView.IsPaneOpen && (NavView.DisplayMode == NavigationViewDisplayMode.Compact || NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
    {
        return false;
    }
    else
    {
        if (ContentFrame.CanGoBack)
        {
            ContentFrame.GoBack();
            navigated = true;
        }
    }
    return navigated;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        NavView.SelectedItem = NavView.SettingsItem as NavigationViewItem;
    }
    else 
    {
        Dictionary<Type, string> lookup = new Dictionary<Type, string>()
        {
            {typeof(HomePage), "home"},
            {typeof(AppsPage), "apps"},
            {typeof(GamesPage), "games"},
            {typeof(MusicPage), "music"},
            {typeof(MyContentPage), "content"}    
        };

        String stringTag = lookup[ContentFrame.SourcePageType];

        // set the new SelectedItem  
        foreach (NavigationViewItemBase item in NavView.MenuItems)
        {
            if (item is NavigationViewItem && item.Tag.Equals(stringTag))
            {
                item.IsSelected = true;
                break;
            }
        }        
    }
}
```

## <a name="customizing-backgrounds"></a>背景をカスタマイズ

NavigationView のメイン領域の背景を変更するには、その `Background` プロパティを目的のブラシに設定します。

NavigationView が最小モードまたはコンパクト モードである場合、ウィンドウの背景にはアプリ内アクリルが表示され、展開モードのときには背景アクリルが表示されます。 この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。

```xaml
<Application.Resources>
    <ResourceDictionary>
        <AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewExpandedPaneBackground"
        BackgroundSource="HostBackdrop" TintColor="Orange" TintOpacity=".8"/>
    </ResourceDictionary>
</Application.Resources>
```

## <a name="extending-your-app-into-the-title-bar"></a>アプリをタイトル バーに拡張する

アプリのウィンドウ内でシームレスで滑らかな表示を実現するには、NavigationView とそのアクリル ウィンドウをアプリのタイトル バー領域に拡張することをお勧めします。 これにより、タイトル バー、単色の NavigationView コンテンツ、および NavigationView ウィンドウのアクリルで作成した図形が、視覚的に見栄えが悪くならないようにすることができます。

そのためには、次のコードを App.xaml.cs に追加します。

```csharp
//draw into the title bar
var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
coreTitleBar.ExtendViewIntoTitleBar = true;

//remove the solid-colored backgrounds behind the caption controls and system back button
var viewTitleBar = ApplicationView.GetForCurrentView().TitleBar;
viewTitleBar.ButtonBackgroundColor = Colors.Transparent;
viewTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
viewTitleBar.ButtonForegroundColor = (Color)Resources["SystemBaseHighColor"];
```

タイトル バーへの描画には、アプリのタイトルを非表示にすることによる副作用です。 ユーザーのため、独自の TextBlock を追加することでタイトルを復元します。 NavigationView が含まれているルート ページに次のマークアップを追加します。

```xaml
<Grid>

    <TextBlock x:Name="AppTitle" 
        xmlns:appmodel="using:Windows.ApplicationModel"
        Text="{x:Bind appmodel:Package.Current.DisplayName}" 
        Style="{StaticResource CaptionTextBlockStyle}" 
        IsHitTestVisible="False" 
        Canvas.ZIndex="1"/>

    <NavigationView Canvas.ZIndex="0" ... />

</Grid>
```

また、[戻る] ボタンの可視性によっては AppTitle の余白を調整する必要もあります。 さらに、アプリが FullScreenMode になっている場合、TitleBar が領域を確保している場合でも、戻る矢印の間隔を削除する必要があります。

```csharp
void UpdateAppTitle()
{
    var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
    var left = 12 + (full ? 0 : CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
    AppTitle.Margin = new Thickness(left, 8, 0, 0);
}

Window.Current.CoreWindow.SizeChanged += (s, e) => UpdateAppTitle();
coreTitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle();
```

タイトル バーのカスタマイズの詳細については、[タイトル バーのカスタマイズ](../shell/title-bar.md) をご覧ください。

## <a name="related-topics"></a>関連トピック

- [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [マスター/詳細](master-details.md)
- [ピボット コントロール](tabs-pivot.md)
- [ナビゲーションの基本](../basics/navigation-basics.md)
- [UWP 用 Fluent Design の概要](../fluent-design-system/index.md)

