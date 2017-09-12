---
author: Karl-Bridge-Microsoft
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: 8389d1f089d507a087693879a793b95572d7860b
ms.sourcegitcommit: 5ece992c31870df4c089360ef47501bd4ce14fa9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/22/2017
---
# <a name="managing-focus-navigation"></a>フォーカス ナビゲーションの管理

多くの入力、つまりキーボードや、Windows ナレーター、ゲームパッド、リモコンなどのアクセシビリティ ツールは、アプリケーションの UI でフォーカス表示を移動するために基になる共通のメカニズムを共有しています。 フォーカス表示とナビゲーションについて詳しくは、「[キーボード操作](keyboard-interactions.md)」と「[Xbox およびテレビ向け設計](designing-for-tv.md#xy-focus-navigation-and-interaction)」をご覧ください。

ここでは、アプリケーションがアプリケーションの UI でフォーカスを移動するための入力に依存しない方法について説明します。これにより、入力の種類を複数使う場合でもアプリケーションが適切に動作する単一のコードを記述できるようになります。

## <a name="navigation-strategies-properties-to-fine-tune-focus-movements"></a>フォーカスの動きを微調整するナビゲーション方法プロパティ

押された方向キーに基づいてフォーカスを受け取るコントロールを指定するには、XYFocus ナビゲーション方法プロパティを使います。 次のプロパティがあります。

-   XYFocusUpNavigationStrategy
-   XYFocusDownNavigationStrategy
-   XYFocusLeftNavigationStrategy
-   XYFocusRightNavigationStrategy

これらプロパティには、**XYFocusNavigationStrategy** 型の値があります。 **Auto** に設定された場合、要素の動作は要素の先祖に基づいて決まります。 すべての要素が **Auto** に設定されている場合、**Projection** が使用されます。

これらのナビゲーション方法では、キーボード、ゲームパッド、リモコンに適用されます。

### <a name="projection"></a>Projection

Projection 方法を使うと、現在フォーカスがある要素の端をナビゲーションの方向に投影するときに出会った最初の要素にフォーカスが移動します。

> [!NOTE]
> 前にフォーカスがあった要素や、ナビゲーション方向の軸までの近さなど、アルゴリズムに影響を与えるその他の要因により、結果に影響があります。

![プロジェクション](images/keyboard/projection.png)

*A の下端のプロジェクションに基づき、下ナビゲーションでフォーカスを A から D へ移動します。*

### <a name="navigationdirectiondistance"></a>NavigationDirectionDistance

NavigationDirectionDistance 方法では、ナビゲーション方向の軸に最も近い要素にフォーカスが移動します。

ナビゲーション方向に対応する境界の四角形の端が拡張、プロジェクションされて、ターゲット候補を識別します。 最初に接触した要素がターゲットとして識別されます。 複数の候補がある場合は、最も近い要素がターゲットとして識別されます。 さらに複数の候補がある場合には、最も上で最も左の要素が候補として識別されます。

![ナビゲーション方向の距離](images/keyboard/navigation-direction-distance.png)

*下ナビゲーションで、フォーカスが A から C に移動し、次に C から B に移動します。*


### <a name="rectilineardistance"></a>RectilinearDistance

RectilinearDistance 方法では、最も短い 2D 距離に基づいて最も近い要素にフォーカスが移動します (マンハッタン メトリック)。 この距離は、潜在的な各候補のプライマリ距離とセカンダリ距離を加算することによって計算されます。 TIE では、方向が上または下の場合は左方向の最初の要素が選択され、方向が左または右の場合は上方向の最初の要素が選択されます。

次の図では、A にフォーカスがあるときにフォーカスが B に移動することが示されています。理由は次のとおりです。

-   距離 (A、B、下) = 10 + 0 = 10
-   距離 (A、C、下) = 0 + 30 = 30
-   距離 (A、D、下) 30 + 0 = 30

![直線距離](images/keyboard/rectilinear-distance.png)

*A にフォーカスがある場合、RectilinearDistance 方法を使うとフォーカスは B に移動する*

次の図は、ナビゲーション方法が子要素ではなくどのようにその要素自体に適用されるかを示しています (XYFocusKeyboardNavigation とは異なります)。

たとえば、E にフォーカスがある場合、RectilinearDistance 方法を使うと右方向キーを押したときにフォーカスは F に移動しますが、D にフォーカスがある場合、Projection 方法を使うと右方向キーを押したときにフォーカスは H に移動します。

メイン コンテナー方法 (ナビゲーション方向距離) は適用されないことに注意してください。 フォーカスが H、F、または G にフォーカスがあるときにだけ使われます。

![さまざまなナビゲーション方法](images/keyboard/different-navigation-strategies.png)

*ナビゲーション方法に基づいてさまざまなフォーカスの動作が適用される*

次の例は、Windows 10 のスタート メニューからのタイル パネルの動作をシミュレートしています。 この場合、上および下方向キーを押すと NavigationDirectionDistance 方法が使われ、左および右方向キーを押すと Projection 方法が使われます。

```XAML
<start:TileGridView
        XYFocusKeyboardNavigation ="Default"
        XYFocusUpNavigationStrategy=" NavigationDirectionDistance "
        XYFocusDownNavigationStrategy=" NavigationDirectionDistance "
        XYFocusLeftNavigationStrategy="Projection"
        XYFocusRightNavigationStrategy="Projection"
/>
```

## <a name="move-focus-programmatically"></a>フォーカスをプログラムにより移動する

フォーカスをプログラムにより移動するには、[FocusManager.TryMoveFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.TryMoveFocus) メソッドまたは [FocusManager.FindNextElement](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.FindNextFocusableElement) メソッドを使います。

TryMoveFocus は、ナビゲーション キーが押された場合と同様にフォーカスを設定します。
FindNextElement は、TryMoveFocus の移動先の要素 (DependencyObject) を返します。

**注** **FindNextFocusableElement** の代わりに **FindNextElement** メソッドを使うことをお勧めします。 FindNextFocusableElement は UIElement を返そうとしますが、フォーカス可能な次の要素がハイパーリンクである場合、ハイパーリンクは UIElement ではないため、null を返します。 FindNextElement メソッドでは、代わりに DependencyObject を返します。

### <a name="find-a-focus-candidate-in-a-scope"></a>スコープでフォーカス候補を見つける

FocusManager.FindNextElement と FocusManager.TryMoveFocus のどちらを使っても、フォーカス可能な次の要素の検出動作をカスタマイズできます。 特定の UI ツリー内を探したり、特定のナビゲーション領域内の要素を除外したりすることができます。

この例は、TicTacToe ゲームの実装から取られたものであり、FindNextElement メソッドと TryMoveFocus メソッドの使用方法を示しています。

```XAML
<StackPanel Orientation="Horizontal"
                VerticalAlignment="Center"
                HorizontalAlignment="Center" >
        <Button Content="Start Game" />
        <Button Content="Undo Movement" />
        <Grid x:Name="TicTacToeGrid" KeyDown="OnKeyDown">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="50" />
                <ColumnDefinition Width="50" />
                <ColumnDefinition Width="50" />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="50" />
                <RowDefinition Height="50" />
                <RowDefinition Height="50" />
            </Grid.RowDefinitions>
            <myControls:TicTacToeCell Grid.Column="0" Grid.Row="0" x:Name="Cell00" />
            <myControls:TicTacToeCell Grid.Column="1" Grid.Row="0" x:Name="Cell10"/>
            <myControls:TicTacToeCell Grid.Column="2" Grid.Row="0" x:Name="Cell20"/>
            <myControls:TicTacToeCell Grid.Column="0" Grid.Row="1" x:Name="Cell01"/>
            <myControls:TicTacToeCell Grid.Column="1" Grid.Row="1" x:Name="Cell11"/>
            <myControls:TicTacToeCell Grid.Column="2" Grid.Row="1" x:Name="Cell21"/>
            <myControls:TicTacToeCell Grid.Column="0" Grid.Row="2" x:Name="Cell02"/>
            <myControls:TicTacToeCell Grid.Column="1" Grid.Row="2" x:Name="Cell22"/>
            <myControls:TicTacToeCell Grid.Column="2" Grid.Row="2" x:Name="Cell32"/>
        </Grid>
    </StackPanel>
```
```csharp
private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            DependencyObject candidate = null;

            var options = new FindNextElementOptions ()
            {
                SearchRoot = TicTacToeGrid,
                NavigationStrategy = NavigationStrategyMode.Heuristic
            };

            switch (e.Key)
            {
                case Windows.System.VirtualKey.Up:
                    candidate = FocusManager.FindNextElement(FocusNavigationDirection.Up, options);
                    break;
                case Windows.System.VirtualKey.Down:
                    candidate = FocusManager.FindNextElement(FocusNavigationDirection.Down, options);
                    break;
                case Windows.System.VirtualKey.Left:
                    candidate = FocusManager.FindNextElement(FocusNavigationDirection.Left, options);
                    break;
                case Windows.System.VirtualKey.Right:
                    candidate = FocusManager.FindNextElement(FocusNavigationDirection.Right, options);
                    break;
            }
         //Note you should also consider whether is a Hyperlink, WebView, or TextBlock.
            if (candidate != null && candidate is Control)
            {
                (candidate as Control).Focus(FocusState.Keyboard);
            }
        }
```

**注** FocusNavigationDirection.Left と FocusNavigationDirection.Right は、RTL シナリオをサポートする点で論理的 (近いか遠いか) です  (これは Xaml の残りの部分と一致します)。

フォーカス候補の検出は、FindNextElementOptions クラスを使って調整できます。 このオブジェクトには、次のプロパティがあります。

-   **SearchRoot** DependencyObject: 候補の検出のスコープをこの DependencyObject の子に設定します。 Null 値は、アプリのビジュアル ツリー全体を示しています。
-   **ExclusionRect** Rect: レンダリングしたときにこの四角形と 1 ピクセル以上重なる項目を検出から除外します。
-   **HintRect** Rect: フォーカスのある項目を基準として使って潜在的候補が計算されます。 この長方形を使うことで、開発者はフォーカスのある要素ではなく別の基準を指定できます。 四角形は、計算にのみ使用される "架空" の四角形です。 実際の四角形に変換されてビジュアル ツリーに追加されることはありません。
-   **XYFocusNavigationStrategyOverride** XYFocusNavigationStrategyOverride: フォーカスの移動に使われるナビゲーション方法。 型は列挙型で、値は None (値が 0)、Auto、RectilinearDistance、NavigationDirectionDistance、Projection です。
    **重要** **SearchRoot** は、レンダリングされる (幾何学的な) 領域の計算や、領域内の候補の取得には使われません。 結果として、子孫の方向領域の外側に配置する DependencyObject の子孫に変換が適用される場合でも、これらの要素が候補と見なされます。

FindNextElement のオプション オーバー ロードをタブ ナビゲーションで使うことはできません、方向ナビゲーションのみサポートされます。

次の図は、これらのオプションを示しています。

たとえば、B にフォーカスがある場合、FindNextElement を呼び出すと (各種オプションはフォーカスが右に移動するように設定) フォーカスが I に設定されます。この理由は次のとおりです。

1.  基準が B でない場合、HintRect のために A である
2.  潜在的候補が MyPanel (SearchRoot) にあるため、C が除外される
3.  除外四角形と重なるため、F が除外される

![ナビゲーション ヒント](images/keyboard/navigation-hints.png)

*ナビゲーション ヒントに基づくフォーカスの動作*

### <a name="no-focus-candidate-available"></a>利用可能なフォーカス候補がない

UIElement.NoFocusCandidateFound イベントは、ユーザーが Tab キーまたは方向キーによってフォーカスを移動しようとしたが、指定された方向に考えられる候補がない場合に発生します。 このイベントは、FocusManager.TryMoveFocus() に対しては発生しません。

これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。 このようにして、適切な場合はいつでもイベントを処理することができます。

<a name="split-view-code-sample"></a>次の例は、[テレビ向けの設計ドキュメント](designing-for-tv.md#navigation-pane)で説明されているように、ユーザーがフォーカス可能な一番左のコントロールの左側にフォーカスを移動しようとしたときに分割ビューを開くグリッドを示しています。

```XAML
<Grid NoFocusCandidateFound="OnNoFocusCandidateFound">  ...</Grid>
```

```csharp
private void OnNoFocusCandidateFound (UIElement sender, NoFocusCandidateFoundEventArgs args)
{
            if(args.NavigationDirection == FocusNavigationDirection.Left)
            {
         if(args.InputDevice == FocusInputDeviceKind.Keyboard ||
            args.InputDevice == FocusInputDeviceKind.GameController )
                {
                OpenSplitPaneView();
                }
            args.Handled = true;
            }
}
```

## <a name="focus-events"></a>フォーカス イベント

[UIElement.GotFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.GotFocus)イベントと UIElement.LostFocus イベントは、それぞれコントロールがフォーカスを取得したときとフォーカスを失ったときに発生します。 このイベントは、FocusManager.TryMoveFocus() に対しては発生しません。

これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。 このようにして、適切な場合はいつでもイベントを処理することができます。

**UIElement.GettingFocus** イベントと **UIElement.LosingFocus** イベントもコントロールからバブルしますが、フォーカスの変更が行われる*前*です。 これにより、アプリはフォーカスの変更をリダイレクトしたりキャンセルしたりできるようになります。

GettingFocus イベントと LosingFocusイベントは同期的ですが、GotFocus イベントと LostFocus イベントは非同期的であることに注意してください。 たとえば、アプリが Control.Focus() メソッドを呼び出したためにフォーカスが移動した場合、GettingFocus は呼び出し時に発生しますが、GotFocus は呼び出しの後しばらくしてから発生します。

UIElements は、GettingFocus イベントと LosingFocus イベントにフックし、フォーカスが移動する前にターゲットを変更できます (NewFocusedElement プロパティを使用)。 ターゲットが変更されている場合でも、イベントはバブルし、別の親がターゲットを再度変更できます。

再入の問題を避けるため、これらのイベントのバブル中にフォーカスを移動しようとした場合 (FocusManager.TryMoveFocus または Control.Focus を使用)、例外がスローされます。

これらのイベントは、フォーカスの移動理由 (たとえば、タブ ナビゲーション、XYFocus ナビゲーション、プログラムなど) にかかわらずが発生します。

次の図は、A から右に移動するとき、XYFocus が候補として LVI4 を選ぶ方法を示しています。 その後、LVI4 は GettingFocus イベントを発生させ、ListView が LVI3 にフォーカスを再割り当てすることができます。

![フォーカス イベント](images/keyboard/focus-events.png)

*フォーカス イベント*

このコード例は、OnGettingFocus イベントを処理し、フォーカスが前に設定されていたに場所に基づいてフォーカスをリダイレクトする方法を示しています。

```XAML
<StackPanel Orientation="Horizontal">
    <Button Content="A" />
    <ListView x:Name="MyListView" SelectedIndex="2" GettingFocus="OnGettingFocus">
        <ListViewItem>LV1</ListViewItem>
        <ListViewItem>LV2</ListViewItem>
        <ListViewItem>LV3</ListViewItem>
        <ListViewItem>LV4</ListViewItem>
        <ListViewItem>LV5</ListViewItem>
    </ListView>
</StackPanel>
```

```csharp
private void OnGettingFocus(UIElement sender, GettingFocusEventArgs args)
  {

                 //Redirect the focus only when the focus comes from outside of the ListView.
       // move the focus to the selected item
            if (MyListView.SelectedIndex != -1 && IsNotAChildOf(MyListView, args.OldFocusedElement))
            {
                var selectedContainer = MyListView.ContainerFromItem(MyListView.SelectedItem);
                if (args.FocusState == FocusState.Keyboard && args.NewFocusedElement != selectedContainer)
                {
                    args.NewFocusedElement = MyListView.ContainerFromItem(MyListView.SelectedItem);
                    args.Handled = true;
                }
            }        
  }
```

このコード例は、CommandBar オブジェクトの OnLosingFocus イベントを処理し、ドロップダウン メニューが閉じられるまでフォーカスの設定を待機する方法を示しています。

```XAML
<CommandBar x:Name="MyCommandBar" LosingFocus="OnLosingFocus">
     <AppBarButton Icon="Back" Label="Back" />
     <AppBarButton Icon="Stop" Label="Stop" />
     <AppBarButton Icon="Play" Label="Play" />
     <AppBarButton Icon="Forward" Label="Forward" />

     <CommandBar.SecondaryCommands>
         <AppBarButton Icon="Like" Label="Like" />
         <AppBarButton Icon="Share" Label="Share" />
     </CommandBar.SecondaryCommands>
 </CommandBar>
```

```csharp
private void OnLosingFocus(UIElement sender, LosingFocusEventArgs args)
{
          if (MyCommandBar.IsOpen == true && IsNotAChildOf(MyCommandBar, args.NewFocusedElement))
          {
              args.Cancel = true;
              args.Handled = true;
          }
}
```

### <a name="losingfocus-and-gettingfocus-event-order"></a>LosingFocus イベントと GettingFocus イベントの順序

LosingFocus と GettingFocus は同期イベントであるため、これらのイベントのバブル中はフォーカスが移動しません。 一方、LostFocus と GotFocus は非同期イベントであるため、ハンドラーが実行される前にフォーカスがもう一度移動しないことは保証されません。 唯一保証されるのは、LostFocus ハンドラーが GotFocus ハンドラーの前に実行されることです。

実行順序を以下に示します。

1.  Sync LosingFocus: LosingFocus が、フォーカスを失ったか Cancel=true を設定した要素にフォーカスをリセットした場合、それ以上イベントは発生しません。
2.  Sync GettingFocus: GettingFocus が、フォーカスを失ったか Cancel=true を設定した要素にフォーカスをリセットした場合、それ以上イベントは発生しません。
3.  Async LostFocus
4.  Async GotFocus

## <a name="find-the-first-and-last-focusable-element-a-namefindfirstfocusableelement"></a>フォーカス可能な最初と最後の要素を見つける <a name="findfirstfocusableelement">

**FocusManager.FindFirstFocusableElement** メソッドと **FocusManager.FindLastFocusableElement** メソッドを使うと、オブジェクトのスコープ内のフォーカス可能な最初または最後の要素にフォーカスを移動できます (UIElement の要素ツリーや TextElement のテキスト ツリー)。 スコープは、これらのメソッドを呼び出すときに指定します。 引数が null の場合、スコープは現在のウィンドウになります。

**注** スコープにフォーカス可能な項目がない場合、これらのメソッドは null を返すことができます。

<a name="popup-ui-code-sample"></a>次のコード例は、「[キーボード操作](keyboard-interactions.md#popup-ui)」で説明されているように、CommandBar のボタンが折り返し方向動作をするように指定する方法を示しています。

```XAML
<CommandBar x:Name="MyCommandBar" LosingFocus="OnLosingFocus">
            <AppBarButton Icon="Back" Label="Back" />
            <AppBarButton Icon="Stop" Label="Stop" />
            <AppBarButton Icon="Play" Label="Play" />
            <AppBarButton Icon="Forward" Label="Forward" />

            <CommandBar.SecondaryCommands>
                <AppBarButton Icon="Like" Label="Like" />
                <AppBarButton Icon="ReShare" Label="Share" />
            </CommandBar.SecondaryCommands>
</CommandBar>
```

```csharp
private void OnLosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            if (IsNotAChildOf(MyCommandBar, args.NewFocussedElement))
            {
                DependencyObject candidate = null;
                if (args.Direction == FocusNavigationDirection.Left)
                {
                    candidate = FocusManager.FindLastFocusableElement(MyCommandBar);
                }
                else if (args.Direction == FocusNavigationDirection.Right)
                {
                    candidate = FocusManager.FindFirstFocusableElement(MyCommandBar);
                }
                if (candidate != null)
                {
                    args.NewFocusedElement = candidate;
                    args.Handled = true;
                }
            }
        }
```
