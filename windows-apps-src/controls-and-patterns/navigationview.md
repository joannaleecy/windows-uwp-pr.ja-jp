---
author: Jwmsft
Description: "画面領域を節約しながら、トップレベルのナビゲーションをレイアウトするコントロール"
title: "ナビゲーション ビュー"
ms.assetid: 
label: Navigation view
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: tpaine
doc-status: Published
ms.openlocfilehash: 98ab8a95288e5a0225a2185f7ce037e16209d173
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="navigation-view"></a>ナビゲーション ビュー

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

ナビゲーション ビュー コントロールは、折りたたみ可能なナビゲーション メニューを利用して、よくある縦方向のレイアウトをアプリのトップレベルの領域に提供します。 このコントロールは、ナビゲーション ウィンドウ (またはハンバーガー メニュー) パターンを実装するために設計されていて、レイアウトをさまざまなウィンドウ サイズに自動的に合わせます。

> **重要な API**: [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、[NavigationViewItem クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)、[NavigationViewDisplayMode 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)

![NavigationView の例](images/navview_wireframe.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

NavigationView は、次の場合に適しています。

-  同じような種類のトップレベルのナビゲーション項目が多数あるアプリ。 たとえば、フットボール、野球、バスケットボール、サッカーといったカテゴリがあるスポーツ アプリなどです。
-  アプリ間で一貫性のあるナビゲーション エクスペリエンスを提供する場合。 このウィンドウにはナビゲーション要素のみを含める必要があります。アクションは含めません。
-  トップレベルのナビゲーションのカテゴリの数が中程度から多い (5 ～ 10 個の) 場合。
-  小さいウィンドウの画面領域を節約します。

ナビゲーション ビューは、いくつかある利用可能なナビゲーション要素の 1 つです。ナビゲーション パターンと他のナビゲーション要素について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーション デザインの基本](../layout/navigation-basics.md)」をご覧ください。

SplitView と ListView を使用してナビゲーション ウィンドウ パターンを構築する方法のコード サンプルについては、GitHub から [XAML ナビゲーション ソリューション](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/XamlNavigation)をダウンロードしてください。

## <a name="navigationview-parts"></a>NavigationView パーツ
このコントロールは大まかに 3 つのセクションに分けられます。左側のナビゲーション用ウィンドウと、右側のヘッダー領域およびコンテンツ領域です。

![NavigationView セクション](images/navview_sections.png)

### <a name="pane"></a>ウィンドウ

ナビゲーション ウィンドウには以下が含まれる可能性があります。

- 特定のページに移動するための、[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem) という形式のナビゲーション項目
- ナビゲーション項目をグループ化するための、[NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) という形式の区切り
- 項目のグループにラベルを付けるための、[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) という形式のヘッダー
- [アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)。 設定項目を非表示にするには、[IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsSettingsVisible) プロパティを使用します。
- [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。

組み込みのナビゲーション ("ハンバーガー") ボタンを使用して、ユーザーはウィンドウを開いたり閉じたりすることができます。 [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。

### <a name="header"></a>ヘッダー

ヘッダー領域は、ナビゲーション ボタンと垂直に揃えられていて、高さが固定されています。 これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。 ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。

NavigationView が最小モードの場合は、ヘッダーが表示される必要があります。 ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。 これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_AlwaysShowHeader) プロパティを **false** に設定します。

### <a name="content"></a>コンテンツ

コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。 1 つ以上の要素を含めることができ、[ピボット](tabs-pivot.md)など、サブレベル ナビゲーションを追加するのに適切な領域です。

NavigationView が最小モードの場合はコンテンツの両側に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。

## <a name="visual-style"></a>視覚スタイル

<div class="microsoft-internal-note">
このコントロールの赤線は [UNI](http://uni/DesignDepot.FrontEnd/#/ProductNav?t=Fluent%20Design%20System%7CControls%20%26%20Patterns%7CNavigationView) で提供されています。<br/><br/>
</div>

ナビゲーション項目は、選択、無効化、ホバー、押下、およびフォーカスされた表示状態に対応しています。

![NavigationView 項目の状態: 無効化、ホバー、押下、フォーカス](images/navview_item-states.png)

ハードウェアとソフトウェアの要件が満たされている場合、NavigationView によって新しい[アクリル素材](../style/acrylic.md)と[表示ハイライト](../style/reveal.md)が自動的にウィンドウで使用されます。


## <a name="navigationview-modes"></a>NavigationView モード
NavigationView ウィンドウは開いたり閉じたりすることができます。次の 3 つの表示モード オプションがあります。
-  **最小**: ハンバーガー ボタンのみが固定され、必要に応じてウィンドウが表示されたり、非表示になったりします。
-  **コンパクト**: ウィンドウは細長い小片として常に表示され、このウィンドウは幅全体まで開くことができます。
-  **展開**: ウィンドウはコンテンツと共に開いています。 ハンバーガー ボタンを使って閉じると、ウィンドウの幅が細長い小片になります。

既定では、コントロールで利用できる画面領域の大きさに基づいて、システムによって最適な表示モードが自動的に選択されます。 (この設定はオーバーライドすることができます。詳しくは、次のセクションをご覧ください)。

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
-  このモードは、タブレットや [10 フィート エクスペリエンス](../input-and-devices/designing-for-tv.md)などの普通サイズの画面に適しています。
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

## <a name="overriding-the-default-adaptive-behavior"></a>既定のアダプティブ動作のオーバーライド

ナビゲーション ビューは、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。
[!NOTE] NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。
[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_CompactModeThresholdWidth) および ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ExpandedModeThresholdWidth) プロパティを使って、ナビゲーション ビューの表示モードが変化する幅を上書きすることができます。 表示モードの動作をカスタマイズする場合を示した次のシナリオを考えてみましょう。

-  **移動が頻繁**: ユーザーがアプリ領域間を多少頻繁に移動することが予想される場合は、ウィンドウ幅を狭くしたウィンドウを表示し続けることを検討します。 曲、アルバム、およびアーティストのナビゲーション領域がある音楽アプリでは、280 ピクセルのウィンドウ幅を選び、アプリ ウィンドウの幅が 560 ピクセルよりも広い場合に展開モードを維持することができます。
```xaml
<NavigationView OpenPaneLength=”280” CompactModeThresholdWidth="560" ExpandedModeThresholdWidth=”560”/>
```
-    **移動がほとんどない** ユーザーがアプリ領域間をほとんど移動しないことが予想されるなら、ウィンドウ幅が広がってもウィンドウの非表示を維持することを検討します。 複数のレイアウトを使用する電卓アプリでは、1080p ディスプレイでアプリが最大化されている場合でも、最小モードを維持できます。
```xaml
<NavigationView CompactModeThresholdWidth=”1920” ExpandedModeThresholdWidth=”1920”/>
```
-    **アイコンの不明瞭解消** アプリのナビゲーション領域が、わかりやすいアイコンに向いていない場合は、コンパクトモードの使用を避けます。 コレクション、アルバム、およびフォルダーのナビゲーション領域のある画像表示アプリでは、幅が狭いときや中間のときは NavigationView を最小モードで表示し、幅が広いときは展開モードで表示することができます。
```xaml
<NavigationView CompactModeThresholdWidth=”1008”/>
```

## <a name="interaction"></a>操作

ウィンドウのナビゲーション カテゴリをユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ItemInvoked) イベントが発生します。 タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_SelectionChanged) イベントが発生します。 アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。 また、プログラムによってナビゲーション項目からコンテンツにフォーカスを移動することをお勧めします。 読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。

## <a name="how-to-use-navigationview"></a>NavigationView の使用方法

NavigationView をアプリに組み込む方法の簡単な例を次に示します。

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
                    Loaded="NavView_Loaded">
    <!-- Load NavigationViewItems in NavView_Loaded. -->

        <NavigationView.HeaderTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Style="{StaticResource TitleTextBlockStyle}"
                           FontSize="28"
                           VerticalAlignment="Center"
                           Margin="12,0"
                           Text="Welcome"/>
                    <CommandBar Grid.Column="1"
                            HorizontalAlignment="Right"
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

        <Frame x:Name="ContentFrame">
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
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Apps", Icon = new SymbolIcon(Symbol.AllApps), Tag = "apps" });
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Games", Icon = new SymbolIcon(Symbol.Video), Tag = "games" });
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Music", Icon = new SymbolIcon(Symbol.Audio), Tag = "music" });
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

    foreach (NavigationViewItem item in NavView.MenuItems)
    {
        if (item.Tag.ToString() == "play")
        {
            NavView.SelectedItem = item;
            break;
        }
    }
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{
    if (args.IsSettingsInvoked == true)
    {
        ContentFrame.Navigate(typeof(SettingsPage));
    }
    else
    {
        switch ((args.InvokedItem as NavigationViewItem).Tag)
        {
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
}
```

## <a name="navigation"></a>ナビゲーション

NavigationView によって自動的にアプリのタイトル バーに戻るボタンが表示されたり、バック スタックにコンテンツが追加されたりすることはありません。 ソフトウェアまたはハードウェアの戻るボタンが押されたときに、このコントロールが自動的に応答することもありません。 このトピックと、ナビゲーションのサポートをアプリに追加する方法について詳しくは、「[履歴と前に戻る移動](../layout/navigation-history-and-backwards-navigation.md)」セクションをご覧ください。


## <a name="related-topics"></a>関連トピック

* [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
* [マスター/詳細](master-details.md)
* [ピボット コントロール](tabs-pivot.md)
* [ナビゲーションの基本](../layout/navigation-basics.md)
 

 
