---
author: Karl-Bridge-Microsoft
Description: Learn how to programmatically manage focus navigation with keyboard, gamepad, and accessibility tools in a UWP app.
title: キーボード、ゲームパッド、アクセシビリティ ツールでのプログラムによるフォーカス ナビゲーション
label: Programmatic focus navigation
keywords: キーボード, ゲーム コントローラー, リモコン, ナビゲーション, ナビゲーション方法, 入力, ユーザーの操作, アクセシビリティ, 操作性
ms.author: kbridge
ms.date: 03/19/2018
ms.topic: article
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: d2317b419a2679d13e846690bbaca0eb212a245e
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5983079"
---
# <a name="programmatic-focus-navigation"></a>プログラムによるフォーカス ナビゲーション

![キーボード、リモート、および方向パッド](images/dpad-remote/dpad-remote-keyboard.png)

UWP アプリケーションでフォーカスをプログラムによって移動するには、[FocusManager.TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドまたは [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドのどちらかを使用します。

[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) は、フォーカスを持つ要素から、指定された方向にあるフォーカス可能な次の要素にフォーカスを移動します。[FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) は、指定されたナビゲーションの方向に基づいてフォーカスを受け取る要素 ([DependencyObject](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dependencyobject)) を取得します (方向ナビゲーションのみ、タブ ナビゲーションのエミュレートには使用できません)。

> [!NOTE]
> [FindNextFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextFocusableElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) ではなく、[FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドの使用をお勧めします。FindNextFocusableElement は UIElement を取得し、この UIElement はフォーカス可能な次の要素が UIElement ではない場合 (Hyperlink オブジェクトなどの場合) に null を返すためです。 

## <a name="find-a-focus-candidate-within-a-scope"></a>スコープ内でフォーカス候補を見つける

[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) と [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) のどちらについても、フォーカス ナビゲーションの動作をカスタマイズできます。たとえば、特定の UI ツリー内にある次のフォーカス候補を検索したり、特定の要素を対象から除外したりすることができます。

次の例では、三目並べゲームを使用して、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドと [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドの使用例を示します。

```xaml
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
        <myControls:TicTacToeCell 
            Grid.Column="0" Grid.Row="0" 
            x:Name="Cell00" />
        <myControls:TicTacToeCell 
            Grid.Column="1" Grid.Row="0" 
            x:Name="Cell10"/>
        <myControls:TicTacToeCell 
            Grid.Column="2" Grid.Row="0" 
            x:Name="Cell20"/>
        <myControls:TicTacToeCell 
            Grid.Column="0" Grid.Row="1" 
            x:Name="Cell01"/>
        <myControls:TicTacToeCell 
            Grid.Column="1" Grid.Row="1" 
            x:Name="Cell11"/>
        <myControls:TicTacToeCell 
            Grid.Column="2" Grid.Row="1" 
            x:Name="Cell21"/>
        <myControls:TicTacToeCell 
            Grid.Column="0" Grid.Row="2" 
            x:Name="Cell02"/>
        <myControls:TicTacToeCell 
            Grid.Column="1" Grid.Row="2" 
            x:Name="Cell22"/>
        <myControls:TicTacToeCell 
            Grid.Column="2" Grid.Row="2" 
            x:Name="Cell32"/>
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
            candidate = 
                FocusManager.FindNextElement(
                    FocusNavigationDirection.Up, options);
            break;
        case Windows.System.VirtualKey.Down:
            candidate = 
                FocusManager.FindNextElement(
                    FocusNavigationDirection.Down, options);
            break;
        case Windows.System.VirtualKey.Left:
            candidate = FocusManager.FindNextElement(
                FocusNavigationDirection.Left, options);
            break;
        case Windows.System.VirtualKey.Right:
            candidate = 
                FocusManager.FindNextElement(
                    FocusNavigationDirection.Right, options);
            break;
    }
    // Also consider whether candidate is a Hyperlink, WebView, or TextBlock.
    if (candidate != null && candidate is Control)
    {
        (candidate as Control).Focus(FocusState.Keyboard);
    }
}
```

[FindNextElementOptions](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.findnextelementoptions) を使用して、フォーカス候補の識別方法をさらにカスタマイズします。 このオブジェクトは、次のプロパティを提供します。

- [SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot) - フォーカス ナビゲーションの候補を検索するスコープを、この DependencyObject の子に設定します。 Null は、ビジュアル ツリーのルートから検索を開始することを示します。

> [!Important] 
> **SearchRoot** の子孫に 1 つ以上の変換が適用され、子孫が方向領域の外側に配置される場合でも、これらの要素 (子孫) が候補と見なされます。

- [ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) - フォーカス ナビゲーションの候補は、"架空の" 四角形領域を使用して識別されます。この四角形領域では、領域に重なるすべてのオブジェクトがフォーカスのナビゲーションから除外されます。 この四角形領域は、計算にのみ使用され、ビジュアル ツリーには追加されません。
- [HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) - フォーカス ナビゲーションの候補は、"架空の" 四角形領域を使用して識別されます。この四角形領域では、フォーカスを受け取る可能性が最も高い要素が特定されます。 この四角形領域は、計算にのみ使用され、ビジュアル ツリーには追加されません。
- [XYFocusNavigationStrategyOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_XYFocusNavigationStrategyOverride) - フォーカスを受け取る最も適切な候補となる要素を識別するために使用されるナビゲーション方法です。

次の図は、これらの概念の一部を示しています。 

要素 B にフォーカスがある場合、右に移動すると、FindNextElement によって I がフォーカス候補として識別されます。 その理由は以下のとおりです。
- A に対する [HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) によって、参照の開始が A となり、B ではないため
- MyPanel が [SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot) として指定されているため、C は候補にはならない
- [ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) が F に重なっているため、F は候補にはならない

![ナビゲーション ヒントを使用したカスタム フォーカス ナビゲーションの動作](images/keyboard/navigation-hints.png)

*ナビゲーション ヒントを使用したカスタム フォーカス ナビゲーションの動作*

## <a name="navigation-focus-events"></a>フォーカスのナビゲーションに関するイベント

### <a name="nofocuscandidatefound-event"></a>NoFocusCandidateFound イベント

[UIElement.NoFocusCandidateFound](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_NoFocusCandidateFound) イベントは、ユーザーが Tab キーまたは方向キーを押したが、指定された方向にフォーカス候補がない場合に発生します。 このイベントは、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) に対しては発生しません。

これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。 これにより、適切な場合はいつでもイベントを処理することができます。

<a name="split-view-code-sample"></a>

ユーザーがフォーカス可能な一番左のコントロールの左側にフォーカスを移動しようとしたときに、Grid がどのようにして [SplitView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview) を開くかを次に示します ([「Xbox およびテレビ向け設計」](../devices/designing-for-tv.md#navigation-pane)をご覧ください)。

```xaml
<Grid NoFocusCandidateFound="OnNoFocusCandidateFound">
...
</Grid>
```

```csharp
private void OnNoFocusCandidateFound (
    UIElement sender, NoFocusCandidateFoundEventArgs args)
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

### <a name="gotfocus-and-lostfocus-events"></a>GotFocus イベントと LostFocus events イベント
[UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) イベントと [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) イベントは、それぞれ要素がフォーカスを取得したとき、およびフォーカスを失ったときに発生します。 このイベントは、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) に対しては発生しません。

これらのイベントはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。 これにより、適切な場合はいつでもイベントを処理することができます。

### <a name="gettingfocus-and-losingfocus-events"></a>GettingFocus イベントと LosingFocus イベント

[UIElement.GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントと [UIElement.LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントは、それぞれに対応する [UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) や [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) の前に発生します。 

これらのイベントはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。 これはフォーカスの移動前に行われるため、フォーカスの移動をリダイレクトしたり、キャンセルしたりすることができます。

[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) と [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) は同期イベントであるため、これらのイベントのバブル中はフォーカスが移動しません。 ただし、[GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) と [LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) は非同期イベントであるため、ハンドラーが実行される前にフォーカスがもう一度移動しないことは保証されません。

[Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_) の呼び出しを経由してフォーカスが移動した場合、その呼び出し時に [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) が発生しますが、[GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) は、その呼び出しの後に発生します。

[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントや [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントが発生しているとき (フォーカスが移動する前) に、[GettingFocusEventArgs.NewFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_NewFocusedElement) プロパティを使用することで、フォーカス ナビゲーションのターゲットを変更できます。 ターゲットが変更されている場合でも、イベントはバブルし、ターゲットをもう一度変更できます。

再入の問題を回避するために、これらのイベントのバブル中にフォーカスを移動しようとした場合 ([TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) または [Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_) を使用)、例外がスローされます。

これらのイベントは、フォーカスの移動理由 (たとえば、タブ ナビゲーション、方向ナビゲーション、プログラムによるナビゲーションなど) に関係なく発生します。

フォーカス イベントの実行順序を以下に示します。

1.  [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus): フォーカスを失った要素にフォーカスがリセットされるか、[TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs#Windows_UI_Xaml_Input_LosingFocusEventArgs_TryCancel) が成功した場合、それ以上イベントは発生しません。
2.  [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus): フォーカスを失った要素にフォーカスがリセットされるか、[TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_TryCancel) が成功した場合、それ以上イベントは発生しません。
3.  [LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus)
4.  [GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus)

次の図は、A から右に移動するとき、XYFocus では B4 がどのようにして候補として選択されるかを示しています。 候補として選択された後、B4 によって GettingFocus イベントが発生し、ListView が B3 にフォーカスを再割り当てすることができます。

![GettingFocus イベントでフォーカス ナビゲーションのターゲットを変更する](images/keyboard/focus-events.png)

*GettingFocus イベントでフォーカス ナビゲーションのターゲットを変更する*

[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントを処理し、フォーカスをリダイレクトする方法を次に示します。

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
    if (MyListView.SelectedIndex != -1 && 
        IsNotAChildOf(MyListView, args.OldFocusedElement))
    {
        var selectedContainer = 
            MyListView.ContainerFromItem(MyListView.SelectedItem);
        if (args.FocusState == 
            FocusState.Keyboard && 
            args.NewFocusedElement != selectedContainer)
        {
            args.TryRedirect(
                MyListView.ContainerFromItem(MyListView.SelectedItem));
            args.Handled = true;
        }
    }
}
```

[CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) の [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントを処理し、メニューが閉じたときにフォーカスを設定する方法を次に示します。

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
    if (MyCommandBar.IsOpen == true && 
        IsNotAChildOf(MyCommandBar, args.NewFocusedElement))
    {
        if (args.TryCancel())
        {
            args.Handled = true;
        }
    }
}
```

## <a name="find-the-first-and-last-focusable-element"></a>フォーカス可能な最初と最後の要素を見つける

[FocusManager.FindFirstFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindFirstFocusableElement_Windows_UI_Xaml_DependencyObject_) メソッドと [FocusManager.FindLastFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindLastFocusableElement_Windows_UI_Xaml_DependencyObject_) メソッドでは、オブジェクトのスコープ内にあるフォーカス可能な最初または最後の要素にフォーカスが移動されます ([UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) の要素ツリーや [TextElement](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.documents.textelement) のテキスト ツリー)。 スコープは呼び出しで指定されます (引数が null の場合、スコープは現在のウィンドウになります)。

スコープ内でフォーカス候補を識別できない場合、null が返されます。

CommandBar のボタンが折り返し方向動作をするように指定する方法を次に示します (「[キーボード操作](keyboard-interactions.md#popup-ui)」をご覧ください)。

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

## <a name="related-articles"></a>関連記事

- [キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション](focus-navigation.md)
- [キーボード操作](keyboard-interactions.md)
- [キーボードのアクセシビリティ](../accessibility/keyboard-accessibility.md)