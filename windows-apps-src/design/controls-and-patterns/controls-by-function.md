---
Description: アプリで使うことができる一部のコントロールの機能別の一覧を示します。
title: 機能別コントロール
ms.assetid: 8DB4347B-91D6-4659-91F2-80ECF7BBB596
label: Controls by function
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a0a267385668a276fc776c5f5d495b27ae72a2b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611517"
---
# <a name="controls-by-function"></a>機能別コントロール

Windows の XAML UI フレームワークには、UI 開発をサポートする多くのコントロールのライブラリが用意されています。 これらのコントロールの一部は視覚的に表示されますが、それ以外のコントロールは他のコントロールまたはコンテンツ (画像やメディアなど) のコンテナーとして機能します。 

[XAML UI の基本のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619992)をダウンロードすると、Windows UI コントロールの多くを実際に見ることができます。

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を参照してください。</a> </p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>


アプリで使うことができる一般的な XAML コントロールの機能別の一覧を以下に示します。

## <a name="appbars-and-commands"></a>アプリ バーとコマンド

### <a name="app-bar"></a>アプリ バー
アプリ特有のコマンドを表示するツール バー。 「コマンド バー」をご覧ください。

参照 :[AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx) 

### <a name="app-bar-button"></a>アプリ バーのボタン
アプリ バー スタイルを使ってコマンドを表示するボタン。

![アプリ バーのボタン アイコン](images/controls/app-bar-buttons.png) 

参照 :[AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx)、 [BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx)、 [FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx)、 [PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx) 

設計と操作方法:[アプリ バーとコマンド バーのコントロールのガイド](app-bars.md) 

サンプル コード:[コマンド実行の XAML サンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

### <a name="app-bar-separator"></a>アプリ バーの区分線
コマンド バーのコマンドのグループを視覚的に区切ります。

参照 :[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) 

サンプル コード:[コマンド実行の XAML サンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

### <a name="app-bar-toggle-button"></a>アプリ バーのトグル ボタン
コマンド バーでコマンドを切り替えるボタン。

参照 :[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx) 

サンプル コード:[コマンド実行の XAML サンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

### <a name="command-bar"></a>コマンド バー
アプリ バーのボタン要素のサイズ変更を処理する専用のアプリ バー。

![コマンド バー コントロール](images/command-bar-compact.png)

```xaml
<CommandBar>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
</CommandBar>
```
参照 :[コマンド バー](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) 

設計と操作方法:[アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)

サンプル コード:[コマンド実行の XAML サンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="buttons"></a>ボタン

### <a name="button"></a>Button
ユーザーの入力に応答して **Click** イベントを発生させるコントロール。

![標準的なボタン](images/controls/button.png)

```xaml
<Button x:Name="button1" Content="Button" 
        Click="Button_Click" />
```

参照 :[ボタン](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx) 

設計と操作方法:[ボタン コントロールのガイド](buttons.md) 

### <a name="hyperlink"></a>ハイパーリンク
「ハイパーリンク ボタン」をご覧ください。

### <a name="hyperlink-button"></a>ハイパーリンク ボタン
ブラウザーでマークアップ テキストとして表示され、指定された URI を開くボタンです。

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)

```xaml
<HyperlinkButton Content="www.microsoft.com" 
                 NavigateUri="https://www.microsoft.com"/>
```

参照 :[HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx) 

設計と操作方法:[ハイパーリンク コントロールのガイド](hyperlinks.md)

### <a name="repeat-button"></a>繰り返しボタン
押されたときから離されるまでの間、繰り返し **Click** イベントを発生させるボタン。 

![繰り返しボタン コントロール](images/controls/repeat-button.png) 

```xaml
<RepeatButton x:Name="repeatButton1" Content="Repeat Button" 
              Click="RepeatButton_Click" />
```

参照 :[RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx) 

設計と操作方法:[ボタン コントロールのガイド](buttons.md) 

## <a name="collectiondata-controls"></a>コレクション コントロールとデータ コントロール

### <a name="flip-view"></a>フリップ ビュー
ユーザーが 1 つずつめくって表示することができる項目のコレクションを表示するコントロール。

```xaml
<FlipView x:Name="flipView1" SelectionChanged="FlipView_SelectionChanged">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

参照 :[FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx) 

設計と操作方法:[フリップ ビュー コントロールのガイド](flipview.md) 

### <a name="grid-view"></a>グリッド ビュー
縦方向にスクロールできる複数行と複数列で項目のコレクションを表示するコントロール。

```xaml
<GridView x:Name="gridView1" SelectionChanged="GridView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</GridView>
```

参照 :[GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) 

設計と操作方法:[リスト](lists.md) 

サンプル コード:[ListView のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619900)

### <a name="items-control"></a>項目コントロール
データ テンプレートで指定された UI にある項目のコレクションを表示するコントロール。 

```xaml
<ItemsControl/>
```

参照 :[ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) 

### <a name="list-view"></a>リスト ビュー
縦方向にスクロールできるリストで項目のコレクションを表示するコントロール。

```xaml
<ListView x:Name="listView1" SelectionChanged="ListView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</ListView>
```

参照 :[ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) 

設計と操作方法:[リスト](lists.md) 

サンプル コード:[ListView のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619900)

## <a name="date-and-time-controls"></a>日付と時刻コントロール

### <a name="calendar-date-picker"></a>カレンダーの日付の選択コントロール
ドロップダウン カレンダー表示を使って、ユーザーが日付を選択できるコントロール。

![カレンダー ビューが開いたカレンダーの日付の選択コントロール](images/controls/calendar-date-picker-open.png)

```xaml
<CalendarDatePicker/>
```

参照 :[CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx) 

設計と操作方法:[予定表、日付、およびタイム コントロール](date-and-time.md)
 
### <a name="calendar-view"></a>カレンダー ビュー
ユーザーが 1 つまたは複数の日付を選択できる、構成可能なカレンダー表示。

```xaml
<CalendarView/>
```

参照 :[予定表ビュー](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) 

設計と操作方法:[予定表、日付、およびタイム コントロール](date-and-time.md) 

### <a name="date-picker"></a>日付の選択コントロール
ユーザーが日付を選択できるコントロール。

![日付の選択コントロール](images/controls/date-picker.png)

```xaml
<DatePicker Header="Arrival Date"/>
```

参照 :[DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx) 

設計と操作方法:[予定表、日付、およびタイム コントロール](date-and-time.md)
 
### <a name="time-picker"></a>時刻の選択コントロール
ユーザーが時間値を設定できるコントロール。

![TimePicker コントロール](images/controls/time-picker.png) 

```xaml
<TimePicker Header="Arrival Time"/>
```

参照 :[TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx) 

設計と操作方法:[予定表、日付、およびタイム コントロール](date-and-time.md)

## <a name="flyouts"></a>ポップアップ

### <a name="context-menu"></a>ショートカット メニュー
「メニュー ポップアップ」および「ポップアップ メニュー」をご覧ください。

### <a name="flyout"></a>ポップアップ
ユーザーの操作が必要であることを示すメッセージを表示します (ダイアログでは他のユーザー操作がブロックされますが、ポップアップでは別のウィンドウが作成されず、操作もブロックされません)。

![ポップアップ コントロール](images/controls/flyout.png)

```xaml
<Flyout>
    <StackPanel>
        <TextBlock Text="All items will be removed. Do you want to continue?"/>
        <Button Click="DeleteConfirmation_Click" Content="Yes, empty my cart"/>
    </StackPanel>
</Flyout>
```

参照 :[フライアウト](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx) 

設計と操作方法:[フライアウト](dialogs-and-flyouts/flyouts.md) 

### <a name="menu-flyout"></a>メニュー ポップアップ
ユーザーが現在行っている内容に関連するコマンドまたはオプションの一覧を一時的に表示します。

![メニュー ポップアップ コントロール](images/controls/menu-flyout.png) 

```xaml
<MenuFlyout>
    <MenuFlyoutItem Text="Reset" Click="Reset_Click"/>
    <MenuFlyoutSeparator/>
    <ToggleMenuFlyoutItem Text="Shuffle" 
                          IsChecked="{Binding IsShuffleEnabled, Mode=TwoWay}"/>
    <ToggleMenuFlyoutItem Text="Repeat" 
                          IsChecked="{Binding IsRepeatEnabled, Mode=TwoWay}"/>
</MenuFlyout>
```

参照 :[MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx)、 [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)、 [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)、 [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) 

設計と操作方法:[メニューおよびコンテキスト メニュー](menus.md) 

サンプル コード:[XAML のコンテキスト メニューのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620021)

### <a name="popup-menu"></a>ポップアップ メニュー
指定したコマンドを表示するためのカスタム メニュー。

参照 :[ポップアップ メニュー](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx) 

設計と操作方法:[ダイアログ ボックス](dialogs-and-flyouts/dialogs.md) 

### <a name="tooltip"></a>ヒント
要素についての情報を表示するポップアップ ウィンドウ。 
 
![ヒント コントロール](images/controls/tool-tip.png)

```xaml
<Button Content="Button" Click="Button_Click" 
        ToolTipService.ToolTip="Click to perform action" />
```

参照 :[ツールヒント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx)、 [ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx) 

設計と操作方法:ヒントのガイドライン 

## <a name="images"></a>イメージ

### <a name="image"></a>Image
画像を表示するコントロール。

```xaml
<Image Source="Assets/Logo.png" />
```

参照 :[画像](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx) 

設計と操作方法:[イメージと ImageBrush](images-imagebrushes.md) 

サンプル コード:[XAML イメージ サンプル](https://go.microsoft.com/fwlink/p/?linkid=226867)

## <a name="graphics-and-ink"></a>グラフィックスとインク

### <a name="inkcanvas"></a>InkCanvas
インク ストロークを受信し、表示するコントロール。

```xaml
<InkCanvas/>
```

参照 :[InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx) 

### <a name="shapes"></a>図形
楕円形、四角形、直線、ベジエ パスなどのように表示できる、保持モードの各種グラフィック オブジェクト。

![多角形](images/controls/shapes-polygon.png) 
![パス](images/controls/shapes-path.png) 

```xaml
<Ellipse/>
<Path/>
<Rectangle/>
```

参照 :[図形](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx) 

手順[図形の描画](../../graphics/drawing-shapes.md) 

サンプル コード:[XAML のベクトルに基づく描画サンプル](https://go.microsoft.com/fwlink/p/?linkid=226866)

## <a name="layout-controls"></a>レイアウト コントロール

### <a name="border"></a>境界線
境界線、背景、またはこの両方を他のオブジェクトの周囲に描画するコンテナー コントロール。

![2 つの四角形の周囲の境界線](images/controls/border.png) 

```xaml
<Border BorderBrush="Blue" BorderThickness="4" 
        Height="108" Width="64" 
        Padding="8" CornerRadius="4">
    <Canvas>
        <Rectangle Fill="Orange"/>
        <Rectangle Fill="Green" Margin="0,44"/>
    </Canvas>
</Border>
```

参照 :[境界線](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)

### <a name="canvas"></a>キャンバス
キャンバスの左上隅を基準とする子要素の絶対配置をサポートするレイアウト パネル。
 
![キャンバス レイアウト パネル](images/controls/canvas.png) 

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

参照 :[キャンバス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)
 
### <a name="grid"></a>グリッド
複数行と複数列での子要素の配置をサポートするレイアウト パネル。

![グリッド レイアウト パネル](images/controls/grid.png) 

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="50"/>
        <RowDefinition Height="50"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="50"/>
        <ColumnDefinition Width="50"/>
    </Grid.ColumnDefinitions>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Grid.Row="1"/>
    <Rectangle Fill="Green" Grid.Column="1"/>
    <Rectangle Fill="Orange" Grid.Row="1" Grid.Column="1"/>
</Grid>
```

参照 :[グリッド](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)
 
### <a name="panning-scroll-viewer"></a>パン スクロール ビューアー
「スクロール ビューアー」をご覧ください。

### <a name="relativepanel"></a>RelativePanel
互いまたは親パネルを基準にして、子オブジェクトの位置を決定し、調整できるパネル。

![RelativePanel レイアウト パネル](images/controls/relative-panel.png) 

```xaml
<RelativePanel>
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

参照 :[RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)

### <a name="scroll-bar"></a>スクロール バー
「スクロール ビューアー」をご覧ください  (ScrollBar は ScrollViewer の要素です。 通常、スタンドアロン コントロールとしては使用しません)。

参照 :[スクロール バー](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)
 
### <a name="scroll-viewer"></a>スクロール ビューアー
ユーザーが、コンテンツのパンとズームを実行できるようにするコンテナー コントロール。

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" 
              HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

参照 :[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)

設計と操作方法:[スクロール、パン コントロールのガイド](scroll-controls.md) 

サンプル コード:[XAML のスクロール、パンとズームのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238577)

### <a name="stack-panel"></a>スタック パネル
子要素を水平方向または垂直方向の単一行に配置するレイアウト パネル。

![スタック パネル レイアウト コントロール](images/controls/stack-panel.png) 

```xaml
<StackPanel>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue"/>
    <Rectangle Fill="Green"/>
    <Rectangle Fill="Orange"/>
</StackPanel>
```

参照 :[StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)
 
### <a name="variablesizedwrapgrid"></a>VariableSizedWrapGrid
複数行と複数列での子要素の配置をサポートするレイアウト パネル。 各子要素を、複数の行と列に配置できます。

![可変サイズ折り返しグリッド レイアウト パネル](images/controls/variable-sized-wrap-grid.png) 

```xaml
<VariableSizedWrapGrid MaximumRowsOrColumns="3" ItemHeight="44" ItemWidth="44">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Height="80" 
               VariableSizedWrapGrid.RowSpan="2"/>
    <Rectangle Fill="Green" Width="80" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
    <Rectangle Fill="Orange" Height="80" Width="80" 
               VariableSizedWrapGrid.RowSpan="2" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
</VariableSizedWrapGrid>
```

参照 :[VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)

### <a name="viewbox"></a>Viewbox
コンテンツを指定されたサイズに拡大縮小するコンテナー コントロール。

![Viewbox コントロール](images/controls/view-box.png) 

```xaml
<Viewbox MaxWidth="25" MaxHeight="25">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="75" MaxHeight="75">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="150" MaxHeight="150">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
```

参照 :[Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)
 
### <a name="zooming-scroll-viewer"></a>ズーム スクロール ビューアー
「スクロール ビューアー」をご覧ください。

## <a name="media-controls"></a>メディア コントロール

### <a name="audio"></a>オーディオ
「メディア要素」をご覧ください。

### <a name="media-element"></a>メディア要素
オーディオとビデオのコンテンツを再生するコントロール。

```xaml
<MediaElement x:Name="myMediaElement"/>
```

参照 :[MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx) 

設計と操作方法:[メディア要素のコントロールのガイド](media-playback.md)

### <a name="mediatransportcontrols"></a>MediaTransportControls
MediaElement の再生コントロールを提供するコントロール。

![トランスポート コントロールを含むメディア要素](images/controls/media-transport-controls.png) 

```xaml
<MediaTransportControls MediaElement="myMediaElement"/>
```

参照 :[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) 

設計と操作方法:[メディア要素のコントロールのガイド](media-playback.md) 

サンプル コード:[メディアのトランスポート コントロールのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620023)

### <a name="video"></a>Video
「メディア要素」をご覧ください。

## <a name="navigation"></a>ナビゲーション

### <a name="navigationview"></a>NavigationView

適応性のあるコンテナーと、左側のナビゲーション ウィンドウで、上部のナビゲーションとタブ パターンを実装する柔軟なナビゲーション モデルの場合。

参照 :[NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

設計と操作方法:[NavigationView コントロールのガイド](navigationview.md)

### <a name="splitview"></a>SplitView

2 つのビューを持つコンテナー コントロール。1 つはメイン コンテンツ用で、もう 1 つは、通常、ナビゲーション メニューに使います。

![分割ビュー コントロール](images/controls/split-view.png) 

```xaml
<SplitView>
    <SplitView.Pane>
        <!-- Menu content -->
    </SplitView.Pane>
    <SplitView.Content>
        <!-- Main content -->
    </SplitView.Content>
</SplitView>
```

参照 :[SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) 

設計と操作方法:[分割ビュー コントロールのガイド](split-view.md)

### <a name="web-view"></a>Web ビュー

Web コンテンツをホストするコンテナー コントロール。

```xaml
<WebView x:Name="webView1" Source="https://developer.microsoft.com" 
         Height="400" Width="800"/>
```

参照 :[WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) 

設計と操作方法:Web ビューのガイドライン 

サンプル コード:[XAML の WebView コントロールのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238582)

### <a name="semantic-zoom"></a>セマンティック ズーム

ユーザーが、項目のコレクションの 2 つの異なる表示の間でズームを実行できるようにするコンテナー コントロール。

```xaml
<SemanticZoom>
    <ZoomedInView>
        <GridView></GridView>
    </ZoomedInView>
    <ZoomedOutView>
        <GridView></GridView>
    </ZoomedOutView>
</SemanticZoom>
```

参照 :[SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx) 

設計と操作方法:[セマンティック ズーム コントロールのガイド](semantic-zoom.md)

サンプル コード:[XAML の GridView のグループ化と SemanticZoom サンプル](https://go.microsoft.com/fwlink/p/?linkid=226564)

## <a name="progress-controls"></a>プログレス コントロール

### <a name="progress-bar"></a>進行状況バー
バーを表示して進行状況を示すコントロール。

![進行状況バー コントロール](images/controls/progress-bar-determinate.png)

特定の値を表示する進行状況バー。

```xaml
<ProgressBar x:Name="progressBar1" Value="50" Width="100"/>
```

![進行状況不定バー コントロール](images/controls/progress-bar-indeterminate.png)

進行状況が不定であることを表す進行状況バー。

```xaml
<ProgressBar x:Name="indeterminateProgressBar1" IsIndeterminate="True" Width="100"/>
```

参照 :[ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx) 

設計と操作方法:[進行状況コントロールのガイド](progress-controls.md) 

### <a name="progress-ring"></a>進行状況リング
リングを表示して進行状況が不定であることを示すコントロール。 

![進行状況リング コントロール](images/controls/progress-ring.png) 

```xaml
<ProgressRing x:Name="progressRing1" IsActive="True"/>
```

参照 :[ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx) 

設計と操作方法:[進行状況コントロールのガイド](progress-controls.md) 

## <a name="text-controls"></a>テキスト コントロール

### <a name="auto-suggest-box"></a>自動提案ボックス
ユーザーが入力するときに、候補のテキストを表示するテキスト入力ボックスです。

![検索の自動提案ボックス](images/controls/auto-suggest-box.png) 

参照 :[AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)

設計と操作方法:[テキスト コントロール](text-controls.md)、 [Auto suggest ボックス コントロールのガイド](auto-suggest-box.md)

サンプル コード:[AutoSuggestBox 移行のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619996)

### <a name="multi-line-text-box"></a>複数行テキスト ボックス
「テキスト ボックス」をご覧ください。

### <a name="password-box"></a>パスワード ボックス
パスワードを入力するためのコントロール。

 ![パスワード ボックス](images/controls/password-box.png)

```xaml
<PasswordBox x:Name="passwordBox1" 
             PasswordChanged="PasswordBox_PasswordChanged" />
```

参照 :[PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx) 

設計と操作方法:[テキスト コントロール](text-controls.md)、[パスワード ボックス コントロールのガイド](password-box.md) 

サンプル コード:[XAML テキスト表示サンプル](https://go.microsoft.com/fwlink/p/?linkid=238579)、 [XAML テキストのサンプルの編集](https://go.microsoft.com/fwlink/p/?linkid=251417)

### <a name="rich-edit-box"></a>リッチ エディット ボックス
書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントを編集できるコントロール。

```xaml
<RichEditBox />
```

参照 :[RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) 

設計と操作方法:[テキスト コントロール](text-controls.md)、[リッチ エディット ボックス コントロールのガイド](rich-edit-box.md)

サンプル コード:[XAML テキストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238578)

### <a name="search-box"></a>検索ボックス
「自動提案ボックス」をご覧ください。

### <a name="single-line-text-box"></a>単一行テキスト ボックス
「テキスト ボックス」をご覧ください。

### <a name="static-textparagraph"></a>静的テキスト/段落
「テキスト ブロック」をご覧ください。

### <a name="text-block"></a>テキスト ブロック
テキストを表示するコントロール。

![テキスト ブロック コントロール](images/controls/text-block.png) 

```xaml
<TextBlock x:Name="textBlock1" Text="I am a TextBlock"/>
```

参照 :[TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、 [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx) 

設計と操作方法:[テキスト コントロール](text-controls.md)、[テキスト ブロック コントロール ガイド](text-block.md)、[リッチ テキスト ブロック コントロールのガイド](rich-text-block.md)

サンプル コード:[XAML テキストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238578)

### <a name="text-box"></a>テキスト ボックス
1 行または複数行のプレーンテキスト フィールド。

![テキスト ボックス コントロール](images/controls/text-box.png) 

```xaml
<TextBox x:Name="textBox1" Text="I am a TextBox" 
         TextChanged="TextBox_TextChanged"/>
```

参照 :[TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) 

設計と操作方法:[テキスト コントロール](text-controls.md)、[テキスト ボックス コントロールのガイド](text-box.md) 

サンプル コード:[XAML テキストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238578)

## <a name="selection-controls"></a>選択コントロール

### <a name="check-box"></a>チェック ボックス
ユーザーがオンまたはオフにできるコントロール。

![チェック ボックスの 3 状態](images/templates-checkbox-states-default.png)

```xaml
<CheckBox x:Name="checkbox1" Content="CheckBox" 
          Checked="CheckBox_Checked"/>
```

参照 :[チェック ボックス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) 

設計と操作方法:[チェック ボックス コントロールのガイド](checkbox.md) 

### <a name="combo-box"></a>コンボ ボックス
ユーザーが選択できる項目のドロップダウン リスト。

![開かれた状態のコンボ ボックス](images/controls/combo-box-open.png) 

```xaml
<ComboBox x:Name="comboBox1" Width="100"
          SelectionChanged="ComboBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ComboBox>
```

参照 :[ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx) 

設計と操作方法:[リスト](lists.md) 

### <a name="list-box"></a>リスト ボックス
ユーザーが選択できる項目のインライン リストを表示するコントロール。 

![リスト ボックス コントロール](images/controls/list-box.png)

```xaml
<ListBox x:Name="listBox1" Width="100"
         SelectionChanged="ListBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ListBox>
```

参照 :[ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx) 

設計と操作方法:[リスト](lists.md) 

### <a name="radio-button"></a>ラジオ ボタン
ユーザーがオプションのグループから 1 つのオプションを選択できるようにするコントロール。 グループ化されたラジオ ボタンは、それぞれ相互に排他的です。

![ラジオ ボタン コントロール](images/controls/radio-button.png)

```xaml
<RadioButton x:Name="radioButton1" Content="RadioButton 1" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
<RadioButton x:Name="radioButton2" Content="RadioButton 2" GroupName="Group1" 
             Checked="RadioButton_Checked" IsChecked="True"/>
<RadioButton x:Name="radioButton3" Content="RadioButton 3" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
```

参照 :[オプション ボタン](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx) 

設計と操作方法:[ラジオ ボタン コントロールのガイド](radio-button.md)
 
### <a name="slider"></a>スライダー
ユーザーがトラックに沿って Thumb コントロールを動かすことで値の範囲から選択できるようにするコントロール。

![スライダー コントロール](images/controls/slider.png)

```xaml
<Slider x:Name="slider1" Width="100" ValueChanged="Slider_ValueChanged" />
```

参照 :[スライダー](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) 

設計と操作方法:[スライダー コントロールのガイド](slider.md) 

### <a name="toggle-button"></a>トグル ボタン
2 つの状態を切り替えることができるボタン。

```xaml
<ToggleButton x:Name="toggleButton1" Content="Button" 
              Checked="ToggleButton_Checked"/>
```

参照 :[トグル ボタン](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)

設計と操作方法:[切り替えコントロールのガイド](toggles.md) 

### <a name="toggle-switch"></a>トグル スイッチ
2 つの状態を切り替えることができるスイッチ。

![トグル スイッチ コントロール](images/controls/toggle-switch.png) 

```xaml
<ToggleSwitch x:Name="toggleSwitch1" Header="ToggleSwitch" 
              OnContent="On" OffContent="Off" 
              Toggled="ToggleSwitch_Toggled"/>
```

参照 :[ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx) 

設計と操作方法:[切り替えコントロールのガイド](toggles.md) 
