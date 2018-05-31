---
author: jwmsft
pm-contact: kisai
design-contact: ksulliv
dev-contact: Shmazlou
doc-status: Published
Description: Swipe commanding is a touch accelerator for context menus.
title: スワイプ
label: Swipe
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 43150acef5c7e9ce73132cd35061d4239821f6d0
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1673549"
---
# <a name="swipe"></a>スワイプ

スワイプによるコマンド実行は、ユーザーがタッチ操作によってアプリ内の状態を変更することなく、一般的なメニュー アクションに簡単にアクセスできるようにするコンテキスト メニューのアクセラレータです。

> **重要な API**: [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol)、[SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem)、[ListView class](/uwp/api/Windows.UI.Xaml.Controls.ListView)

![実行と表示の淡色テーマ](images/LightThemeSwipe.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

スワイプによるコマンド実行によって、領域が節約されます。 これは、ユーザーが複数の項目に対して同じ操作をすばやく連続して実行できる場合に役立ちます。 ページ内で完全なポップアップや状態の変更を必要としないアイテムに対して「クイック アクション」を提供します。

潜在的に多くの項目のグループで、各項目にユーザーが定期的に実行する必要がある操作が 1 ～ 3 つある場合は、スワイプによるコマンド実行を使用してください。 これには次のような操作が含まれますが、これに限定されません。

- 削除
- マークやアーカイブ
- 保存またはダウンロード
- 返信

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SwipeControl">アプリを開き、SwipeControl の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a>概要 (ビデオ)

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev015/player]

## <a name="how-does-swipe-work"></a>スワイプの動作の仕組み

UWP のスワイプによるコマンド実行には、[表示](/uwp/api/windows.ui.xaml.controls.swipemode) と[実行](/uwp/api/windows.ui.xaml.controls.swipemode) の 2 つのモードがあります。 さらに、上、下、左、右の 4 つのスワイプの方向もサポートされています。

### <a name="reveal-mode"></a>表示モード

表示モードでは、ユーザーが項目をスワイプすると、1 つまたは複数のコマンドのメニューが開きます。ユーザーがコマンドを実行するには、コマンドを明示的にタップする必要があります。 ユーザーが項目をスワイプして、指を離すと、コマンドを選択するか、メニューを再び閉じるまで、メニューを開いたままになります。メニューが閉じられるのは、端へスワイプしたとき、別の場所をタップしたとき、または開いたスワイプ項目が画面に表示されなくなるまでスクロールしたときです。

![スワイプによる表示](images/SwipeCommand-Reveal_v2.gif)

表示モードは、より安全で、より多用途なスワイプ モードであり、ほとんどの種類のメニュー操作に使用できます。ただし、削除など、潜在的に破壊的な操作もあります。

ユーザーが表示モードの開いた安静状態で表示されているメニュー オプションの 1 つを選択すると、その項目のコマンドが呼び出され、スワイプ コントロールが閉じられます。

### <a name="execute-mode"></a>実行モード

実行モードでは、ユーザーは項目をスワイプして開き、その 1 回のスワイプで 1 つのコマンドを表示して実行します。 ユーザーがしきい値を超えるまでスワイプする前に、スワイプしている項目から指を離した場合、メニューは閉じ、コマンドは実行されません。 しきい値を超えてスワイプした後、項目から指を離すと、コマンドがすぐに実行されます。

![スワイプして実行](images/SwipeCommand_Delete_v2.gif)

しきい値に達した後もユーザーが指を離さなかった場合や、スワイプ項目をプルして再び閉じた場合は、コマンドは実行されず、その項目に対して操作は実行されません。

実行モードでは、項目をスワイプする際に、色やラベルの向きによって、より多くの視覚的フィードバックを提供します。

実行モードは、ユーザーが実行する操作が最も一般的なときに使用するのに最適です。

これは、項目を削除するなどのより破壊的な操作についても使用できます。 ただし、実行にはある方向にスワイプする操作だけですむ点に留意してください。表示する場合は、明示的にボタンをクリックする必要があるのとは対照的です。

### <a name="swipe-directions"></a>スワイプの方向

スワイプはすべての基本的な方向 (上、下、左、右) で機能します。 各スワイプ方向には、独自のスワイプ項目またはコンテンツを保持できますが、1 つのスワイプ可能な要素について設定できる方向のインスタンスは一度に 1 つだけです。

たとえば、同じ SwipeControl で 2 つの [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems) を定義することはできません。

## <a name="how-to-create-a-swipe-command"></a>スワイプ コマンドを作成する方法

スワイプ コマンドでは、2 つのコンポーネントを定義する必要があります。

- コンテンツを取り囲む [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol)。 ListView などコレクションに含まれる場合は、DataTemplate 内にあります。
- スワイプ コントロールの方向コンテナー内に配置された 1 つまたは複数の [SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem) オブジェクトであるスワイプ メニュー項目: [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems)、[RightItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.RightItems)、[TopItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.TopItems)、または [BottomItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.BottomItems)

スワイプ コンテンツは、インラインで配置するか、ページまたはアプリの [リソース] セクションで定義することができます。

いくつかのテキストを囲む SwipeControl の単純な例を以下に示します。 スワイプ コマンドを作成するために必要な XAML 要素の階層構造が表示されます。

```xaml
<SwipeControl HorizontalAlignment="Center" VerticalAlignment="Center">
    <SwipeControl.LeftItems>
        <SwipeItems>
            <SwipeItem Text="Pin">
                <SwipeItem.IconSource>
                    <SymbolIconSource Symbol="Pin"/>
                </SwipeItem.IconSource>
            </SwipeItem>
        </SwipeItems>
    </SwipeControl.LeftItems>

     <!-- Swipeable content -->
    <Border Width="180" Height="44" BorderBrush="Black" BorderThickness="2">
        <TextBlock Text="Swipe to Pin" Margin="4,8,0,0"/>
    </Border>
</SwipeControl>
```

ここでは、通常、スワイプ コマンドをリスト内で使用する方法のより具体的な例について説明します。 この例では、実行モードを使用する削除コマンド、および表示モードを使用するその他のコマンドのメニューを設定します。 どちらのコマンドのセットも、ページの [リソース] セクションで定義されます。 スワイプ コマンドを ListView の項目に適用します。

最初に、コマンドを表すスワイプの項目をページ レベルのリソースとして作成します。 SwipeItem では [IconSource](/uwp/api/windows.ui.xaml.controls.iconsource) がそのアイコンとして使用されます。 リソースとしてのアイコンも作成します。

```xaml
<Page.Resources>
    <SymbolIconSource x:Key="ReplyIcon" Symbol="MailReply"/>
    <SymbolIconSource x:Key="DeleteIcon" Symbol="Delete"/>
    <SymbolIconSource x:Key="PinIcon" Symbol="Pin"/>

    <SwipeItems x:Key="RevealOptions" Mode="Reveal">
        <SwipeItem Text="Reply" IconSource="{StaticResource ReplyIcon}"/>
        <SwipeItem Text="Pin" IconSource="{StaticResource PinIcon}"/>
    </SwipeItems>

    <SwipeItems x:Key="ExecuteDelete" Mode="Execute">
        <SwipeItem Text="Delete" IconSource="{StaticResource DeleteIcon}"
                   Background="Red"/>
    </SwipeItems>
</Page.Resources>
```

スワイプ コンテンツ内のメニュー項目は、短く、簡潔なテキスト ラベルにしてください。 これらの操作は、ユーザーが短時間で複数回実行するようなプライマリ操作である必要があります。

コレクションや ListView で動作するようにスワイプ コマンドを設定する方法は、1 つのスワイプ コマンド (上の例) を定義する場合とまったく同じですが、DataTemplate で SwipeControl を定義する点が異なります。このため、これはコレクションの各項目に適用されます。

SwipeControl がその項目の DataTemplate で適用されている ListView を以下に示します。 LeftItems プロパティと RightItems プロパティは、リソースとして作成したスワイプ項目を参照します。

```xaml
<ListView x:Name="sampleList" Width="300">
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
        </Style>
    </ListView.ItemContainerStyle>
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="x:String">
            <SwipeControl x:Name="ListViewSwipeContainer"
                          LeftItems="{StaticResource RevealOptions}"
                          RightItems="{StaticResource ExecuteDelete}"
                          Height="60">
                <StackPanel Orientation="Vertical" Margin="5">
                    <TextBlock Text="{x:Bind}" FontSize="18"/>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit..." FontSize="12"/>
                    </StackPanel>
                </StackPanel>
            </SwipeControl>
        </DataTemplate>
    </ListView.ItemTemplate>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```

## <a name="handle-an-invoked-swipe-command"></a>呼び出されたスワイプ コマンドの処理

スワイプ コマンドを処理するには、その [Invoked](/uwp/api/windows.ui.xaml.controls.swipeitem.Invoked) イベントを処理します。 (ユーザーがコマンドを呼び出す方法の詳細については、この記事の前半にある「_スワイプの動作の仕組み_」セクションをご覧ください。) 通常、スワイプ コマンドは、ListView または一覧のようなシナリオで使用されます。 その場合は、コマンドが呼び出されるた場合、そのスワイプされた項目で操作を実行する必要があります。

以前に作成した_削除_スワイプ項目で Invoked イベントを処理する方法を以下に示します。

```xaml
<SwipeItems x:Key="ExecuteDelete" Mode="Execute">
    <SwipeItem Text="Delete" IconSource="{StaticResource DeleteIcon}"
               Background="Red" Invoked="Delete_Invoked"/>
</SwipeItems>
```

データ項目は、SwipeControl の DataContext です。 コードで、スワイプされた項目にアクセスするには、以下に示すようにイベント引数から SwipeControl.DataContext プロパティを取得します。

```csharp
 private void Delete_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
 {
     sampleList.Items.Remove(args.SwipeControl.DataContext);
 }
```

> [!NOTE]
> ここでは、わかりやすくするために項目は ListView.Items コレクションに直接追加されており、同じ方法で削除も実行されます。 代わりに、より一般的な方法として ListView.ItemsSource をコレクションに設定した場合は、ソース コレクションから項目を削除する必要があります。

この特定のインスタンスで、リストから項目が削除されてりうため、最終的な表示状態は重要ではありません。 ただし、操作を実行し、スワイプを再び折りたたむことのみが必要である場合は、[BehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipeitem.BehaviorOnInvoked) プロパティを [SwipeBehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipebehavioroninvoked) 列挙値のいずれかに設定できます。

- **Auto**
  - 実行モードでは、開いたスワイプ項目は呼び出されても開いたままになります。
  - 表示モードでは、開いたスワイプ項目は呼び出されると折りたたまれます。
- **Close**
  - 項目が呼び出されると、スワイプ コントロールは常に折りたたまれ、モードに関係なく通常に戻ります。
- **RemainOpen**
  - 項目が呼び出されると、スワイプ コントロールはモードに関係なく常に開いたままになります。

ここでは、_返信_スワイプ項目は呼び出された後に閉じるように設定されます。

```xaml
<SwipeItem Text="Reply" IconSource="{StaticResource ReplyIcon}"
           Invoked="Reply_Invoked"
           BehaviorOnInvoked = "Close"/>
```

## <a name="dos-and-donts"></a>推奨と非推奨

- FlipView、ハブ、ピボットではスワイプを使用しないでください。 組み合わせによっては、スワイプの方向が競合するために、ユーザーの混乱を招く可能性があります。
- 水平方向ナビゲーションと水平方向のスワイプ、または垂直方向ナビゲーションと垂直方向のスワイプを組み合わせないでください。
- ユーザーがスワイプしている対象が同じアクションであり、スワイプできるすべての関連する項目で一貫していることを確認します。
- ユーザーが実行する主なアクションではスワイプを使用します。
- 同じアクションが何度も繰り返される項目ではスワイプを使用します。
- 幅の広い項目では水平方向のスワイプを使用し、高さのある項目では垂直方向のスワイプを使用します。
- 短く、簡潔なテキスト ラベルを使用します。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [リスト ビューとグリッド ビュー](listview-and-gridview.md)
- [項目コンテナーやテンプレート](item-containers-templates.md)
- [引っ張って更新](pull-to-refresh.md)
