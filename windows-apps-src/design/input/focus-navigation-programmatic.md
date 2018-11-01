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
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5876875"
---
# <a name="programmatic-focus-navigation"></a><span data-ttu-id="da864-103">プログラムによるフォーカス ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="da864-103">Programmatic focus navigation</span></span>

![キーボード、リモート、および方向パッド](images/dpad-remote/dpad-remote-keyboard.png)

<span data-ttu-id="da864-105">UWP アプリケーションでフォーカスをプログラムによって移動するには、[FocusManager.TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドまたは [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドのどちらかを使用します。</span><span class="sxs-lookup"><span data-stu-id="da864-105">To move focus programmatically in your UWP application, you can use either the [FocusManager.TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) method or the [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) method.</span></span>

<span data-ttu-id="da864-106">[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) は、フォーカスを持つ要素から、指定された方向にあるフォーカス可能な次の要素にフォーカスを移動します。[FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) は、指定されたナビゲーションの方向に基づいてフォーカスを受け取る要素 ([DependencyObject](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dependencyobject)) を取得します (方向ナビゲーションのみ、タブ ナビゲーションのエミュレートには使用できません)。</span><span class="sxs-lookup"><span data-stu-id="da864-106">[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) attempts to change focus from the element with focus to the next focusable element in the specified direction, while [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) retrieves the element (as a [DependencyObject](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dependencyobject)) that will receive focus based on the specified navigation direction (directional navigation only, cannot be used to emulate tab navigation).</span></span>

> [!NOTE]
> <span data-ttu-id="da864-107">[FindNextFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextFocusableElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) ではなく、[FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドの使用をお勧めします。FindNextFocusableElement は UIElement を取得し、この UIElement はフォーカス可能な次の要素が UIElement ではない場合 (Hyperlink オブジェクトなどの場合) に null を返すためです。</span><span class="sxs-lookup"><span data-stu-id="da864-107">We recommend using the [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) method instead of [FindNextFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextFocusableElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) because FindNextFocusableElement retrieves a UIElement, which returns null if the next focusable element is not a UIElement (such as a Hyperlink object).</span></span> 

## <a name="find-a-focus-candidate-within-a-scope"></a><span data-ttu-id="da864-108">スコープ内でフォーカス候補を見つける</span><span class="sxs-lookup"><span data-stu-id="da864-108">Find a focus candidate within a scope</span></span>

<span data-ttu-id="da864-109">[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) と [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) のどちらについても、フォーカス ナビゲーションの動作をカスタマイズできます。たとえば、特定の UI ツリー内にある次のフォーカス候補を検索したり、特定の要素を対象から除外したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="da864-109">You can customize the focus navigation behavior for both [TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) and [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_), including searching for the next focus candidate within a specific UI tree or excluding specific elements from consideration.</span></span>

<span data-ttu-id="da864-110">次の例では、三目並べゲームを使用して、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドと [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) メソッドの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="da864-110">This example uses a TicTacToe game to demonstrate the [TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) and [FindNextElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindNextElement_Windows_UI_Xaml_Input_FocusNavigationDirection_) methods.</span></span>

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

<span data-ttu-id="da864-111">[FindNextElementOptions](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.findnextelementoptions) を使用して、フォーカス候補の識別方法をさらにカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="da864-111">Use [FindNextElementOptions](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.findnextelementoptions) to further customize how focus candidates are identified.</span></span> <span data-ttu-id="da864-112">このオブジェクトは、次のプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="da864-112">This object provides the following properties:</span></span>

- <span data-ttu-id="da864-113">[SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot) - フォーカス ナビゲーションの候補を検索するスコープを、この DependencyObject の子に設定します。</span><span class="sxs-lookup"><span data-stu-id="da864-113">[SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot) - Scope the search for focus navigation candidates to the children of this DependencyObject.</span></span> <span data-ttu-id="da864-114">Null は、ビジュアル ツリーのルートから検索を開始することを示します。</span><span class="sxs-lookup"><span data-stu-id="da864-114">Null indicates to start the search from the root of the visual tree.</span></span>

> [!Important] 
> <span data-ttu-id="da864-115">**SearchRoot** の子孫に 1 つ以上の変換が適用され、子孫が方向領域の外側に配置される場合でも、これらの要素 (子孫) が候補と見なされます。</span><span class="sxs-lookup"><span data-stu-id="da864-115">If one or more transforms are applied to the descendants of **SearchRoot** that place them outside of the directional area, these elements are still considered candidates.</span></span>

- <span data-ttu-id="da864-116">[ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) - フォーカス ナビゲーションの候補は、"架空の" 四角形領域を使用して識別されます。この四角形領域では、領域に重なるすべてのオブジェクトがフォーカスのナビゲーションから除外されます。</span><span class="sxs-lookup"><span data-stu-id="da864-116">[ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) - Focus navigation candidates are identified using a "fictitious" bounding rectangle where all overlapping objects are excluded from navigation focus.</span></span> <span data-ttu-id="da864-117">この四角形領域は、計算にのみ使用され、ビジュアル ツリーには追加されません。</span><span class="sxs-lookup"><span data-stu-id="da864-117">This rectangle is used only for calculations and is never added to the visual tree.</span></span>
- <span data-ttu-id="da864-118">[HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) - フォーカス ナビゲーションの候補は、"架空の" 四角形領域を使用して識別されます。この四角形領域では、フォーカスを受け取る可能性が最も高い要素が特定されます。</span><span class="sxs-lookup"><span data-stu-id="da864-118">[HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) - Focus navigation candidates are identified using a "fictitious" bounding rectangle that identifies the elements most likely to receive focus.</span></span> <span data-ttu-id="da864-119">この四角形領域は、計算にのみ使用され、ビジュアル ツリーには追加されません。</span><span class="sxs-lookup"><span data-stu-id="da864-119">This rectangle is used only for calculations and is never added to the visual tree.</span></span>
- <span data-ttu-id="da864-120">[XYFocusNavigationStrategyOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_XYFocusNavigationStrategyOverride) - フォーカスを受け取る最も適切な候補となる要素を識別するために使用されるナビゲーション方法です。</span><span class="sxs-lookup"><span data-stu-id="da864-120">[XYFocusNavigationStrategyOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_XYFocusNavigationStrategyOverride) - The focus navigation strategy used to identify the best candidate element to receive focus.</span></span>

<span data-ttu-id="da864-121">次の図は、これらの概念の一部を示しています。</span><span class="sxs-lookup"><span data-stu-id="da864-121">The following image illustrates some of these concepts.</span></span> 

<span data-ttu-id="da864-122">要素 B にフォーカスがある場合、右に移動すると、FindNextElement によって I がフォーカス候補として識別されます。</span><span class="sxs-lookup"><span data-stu-id="da864-122">When element B has focus, FindNextElement identifies I as the focus candidate when navigating to the right.</span></span> <span data-ttu-id="da864-123">その理由は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da864-123">The reasons for this are:</span></span>
- <span data-ttu-id="da864-124">A に対する [HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) によって、参照の開始が A となり、B ではないため</span><span class="sxs-lookup"><span data-stu-id="da864-124">Because of the [HintRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_HintRect) on A, the starting reference is A, not B</span></span>
- <span data-ttu-id="da864-125">MyPanel が [SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot) として指定されているため、C は候補にはならない</span><span class="sxs-lookup"><span data-stu-id="da864-125">C is not a candidate because MyPanel has been specified as the [SearchRoot](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_SearchRoot)</span></span>
- <span data-ttu-id="da864-126">[ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) が F に重なっているため、F は候補にはならない</span><span class="sxs-lookup"><span data-stu-id="da864-126">F is not a candidate because the [ExclusionRect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.findnextelementoptions#Windows_UI_Xaml_Input_FindNextElementOptions_ExclusionRect) overlaps it</span></span>

![ナビゲーション ヒントを使用したカスタム フォーカス ナビゲーションの動作](images/keyboard/navigation-hints.png)

*<span data-ttu-id="da864-128">ナビゲーション ヒントを使用したカスタム フォーカス ナビゲーションの動作</span><span class="sxs-lookup"><span data-stu-id="da864-128">Custom focus navigation behavior using navigation hints</span></span>*

## <a name="navigation-focus-events"></a><span data-ttu-id="da864-129">フォーカスのナビゲーションに関するイベント</span><span class="sxs-lookup"><span data-stu-id="da864-129">Navigation focus events</span></span>

### <a name="nofocuscandidatefound-event"></a><span data-ttu-id="da864-130">NoFocusCandidateFound イベント</span><span class="sxs-lookup"><span data-stu-id="da864-130">NoFocusCandidateFound event</span></span>

<span data-ttu-id="da864-131">[UIElement.NoFocusCandidateFound](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_NoFocusCandidateFound) イベントは、ユーザーが Tab キーまたは方向キーを押したが、指定された方向にフォーカス候補がない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="da864-131">The [UIElement.NoFocusCandidateFound](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_NoFocusCandidateFound) event is fired when the tab or arrow keys are pressed and there is no focus candidate in the specified direction.</span></span> <span data-ttu-id="da864-132">このイベントは、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) に対しては発生しません。</span><span class="sxs-lookup"><span data-stu-id="da864-132">This event is not fired for [TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_).</span></span>

<span data-ttu-id="da864-133">これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。</span><span class="sxs-lookup"><span data-stu-id="da864-133">Because this is a routed event, it bubbles from the focused element up through successive parent objects to the root of the object tree.</span></span> <span data-ttu-id="da864-134">これにより、適切な場合はいつでもイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="da864-134">This lets you handle the event wherever appropriate.</span></span>

<a name="split-view-code-sample"></a>

<span data-ttu-id="da864-135">ユーザーがフォーカス可能な一番左のコントロールの左側にフォーカスを移動しようとしたときに、Grid がどのようにして [SplitView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview) を開くかを次に示します ([「Xbox およびテレビ向け設計」](../devices/designing-for-tv.md#navigation-pane)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="da864-135">Here, we show how a Grid opens a [SplitView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview) when the user attempts to move focus to the left of the left-most focusable control (see [Designing for Xbox and TV](../devices/designing-for-tv.md#navigation-pane)).</span></span>

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

### <a name="gotfocus-and-lostfocus-events"></a><span data-ttu-id="da864-136">GotFocus イベントと LostFocus events イベント</span><span class="sxs-lookup"><span data-stu-id="da864-136">GotFocus and LostFocus events</span></span>
<span data-ttu-id="da864-137">[UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) イベントと [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) イベントは、それぞれ要素がフォーカスを取得したとき、およびフォーカスを失ったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="da864-137">The [UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) and [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) events are fired when an element gets focus or loses focus, respectively.</span></span> <span data-ttu-id="da864-138">このイベントは、[TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) に対しては発生しません。</span><span class="sxs-lookup"><span data-stu-id="da864-138">This event is not fired for [TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_).</span></span>

<span data-ttu-id="da864-139">これらのイベントはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。</span><span class="sxs-lookup"><span data-stu-id="da864-139">Because these are routed events, they bubble from the focused element up through successive parent objects to the root of the object tree.</span></span> <span data-ttu-id="da864-140">これにより、適切な場合はいつでもイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="da864-140">This lets you handle the event wherever appropriate.</span></span>

### <a name="gettingfocus-and-losingfocus-events"></a><span data-ttu-id="da864-141">GettingFocus イベントと LosingFocus イベント</span><span class="sxs-lookup"><span data-stu-id="da864-141">GettingFocus and LosingFocus events</span></span>

<span data-ttu-id="da864-142">[UIElement.GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントと [UIElement.LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントは、それぞれに対応する [UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) や [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) の前に発生します。</span><span class="sxs-lookup"><span data-stu-id="da864-142">The [UIElement.GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) and [UIElement.LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) events fire before the respective [UIElement.GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) and [UIElement.LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) events.</span></span> 

<span data-ttu-id="da864-143">これらのイベントはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。</span><span class="sxs-lookup"><span data-stu-id="da864-143">Because these are routed events, they bubble from the focused element up through successive parent objects to the root of the object tree.</span></span> <span data-ttu-id="da864-144">これはフォーカスの移動前に行われるため、フォーカスの移動をリダイレクトしたり、キャンセルしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="da864-144">As this happens before a focus change takes place, you can redirect or cancel the focus change.</span></span>

<span data-ttu-id="da864-145">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) と [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) は同期イベントであるため、これらのイベントのバブル中はフォーカスが移動しません。</span><span class="sxs-lookup"><span data-stu-id="da864-145">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) and [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) are synchronous events so focus won’t be moved while these events are bubbling.</span></span> <span data-ttu-id="da864-146">ただし、[GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) と [LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) は非同期イベントであるため、ハンドラーが実行される前にフォーカスがもう一度移動しないことは保証されません。</span><span class="sxs-lookup"><span data-stu-id="da864-146">However, [GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) and [LostFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus) are asynchronous events, which means there is no guarantee that focus won’t move again before the handler is executed.</span></span>

<span data-ttu-id="da864-147">[Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_) の呼び出しを経由してフォーカスが移動した場合、その呼び出し時に [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) が発生しますが、[GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) は、その呼び出しの後に発生します。</span><span class="sxs-lookup"><span data-stu-id="da864-147">If focus moves through a call to [Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_), [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) is raised during the call, while [GotFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus) is raised after the call.</span></span>

<span data-ttu-id="da864-148">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントや [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントが発生しているとき (フォーカスが移動する前) に、[GettingFocusEventArgs.NewFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_NewFocusedElement) プロパティを使用することで、フォーカス ナビゲーションのターゲットを変更できます。</span><span class="sxs-lookup"><span data-stu-id="da864-148">The focus navigation target can be changed during the [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) and [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) events (before focus moves) through the [GettingFocusEventArgs.NewFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_NewFocusedElement) property.</span></span> <span data-ttu-id="da864-149">ターゲットが変更されている場合でも、イベントはバブルし、ターゲットをもう一度変更できます。</span><span class="sxs-lookup"><span data-stu-id="da864-149">Even if the target is changed, the event still bubbles and the target can be changed again.</span></span>

<span data-ttu-id="da864-150">再入の問題を回避するために、これらのイベントのバブル中にフォーカスを移動しようとした場合 ([TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) または [Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_) を使用)、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="da864-150">To avoid reentrancy issues, an exception is thrown if you try to move focus (using [TryMoveFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_TryMoveFocus_Windows_UI_Xaml_Input_FocusNavigationDirection_) or [Control.Focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_Focus_Windows_UI_Xaml_FocusState_)) while these events are bubbling.</span></span>

<span data-ttu-id="da864-151">これらのイベントは、フォーカスの移動理由 (たとえば、タブ ナビゲーション、方向ナビゲーション、プログラムによるナビゲーションなど) に関係なく発生します。</span><span class="sxs-lookup"><span data-stu-id="da864-151">These events are fired regardless of the reason for the focus moving (including tab navigation, directional navigation, and programmatic navigation).</span></span>

<span data-ttu-id="da864-152">フォーカス イベントの実行順序を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="da864-152">Here is the order of execution for the focus events:</span></span>

1.  <span data-ttu-id="da864-153">[LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus): フォーカスを失った要素にフォーカスがリセットされるか、[TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs#Windows_UI_Xaml_Input_LosingFocusEventArgs_TryCancel) が成功した場合、それ以上イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="da864-153">[LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) If focus is reset back to the losing focus element or [TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs#Windows_UI_Xaml_Input_LosingFocusEventArgs_TryCancel) is successful, no further events are fired.</span></span>
2.  <span data-ttu-id="da864-154">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus): フォーカスを失った要素にフォーカスがリセットされるか、[TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_TryCancel) が成功した場合、それ以上イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="da864-154">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) If focus is reset back to the losing focus element or [TryCancel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs#Windows_UI_Xaml_Input_GettingFocusEventArgs_TryCancel) is successful, no further events are fired.</span></span>
3.  [<span data-ttu-id="da864-155">LostFocus</span><span class="sxs-lookup"><span data-stu-id="da864-155">LostFocus</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LostFocus)
4.  [<span data-ttu-id="da864-156">GotFocus</span><span class="sxs-lookup"><span data-stu-id="da864-156">GotFocus</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GotFocus)

<span data-ttu-id="da864-157">次の図は、A から右に移動するとき、XYFocus では B4 がどのようにして候補として選択されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="da864-157">The following image shows how, when moving to the right from A, the XYFocus chooses B4 as a candidate.</span></span> <span data-ttu-id="da864-158">候補として選択された後、B4 によって GettingFocus イベントが発生し、ListView が B3 にフォーカスを再割り当てすることができます。</span><span class="sxs-lookup"><span data-stu-id="da864-158">B4 then fires the GettingFocus event where the ListView has the opportunity to reassign focus to B3.</span></span>

![GettingFocus イベントでフォーカス ナビゲーションのターゲットを変更する](images/keyboard/focus-events.png)

*<span data-ttu-id="da864-160">GettingFocus イベントでフォーカス ナビゲーションのターゲットを変更する</span><span class="sxs-lookup"><span data-stu-id="da864-160">Changing focus navigation target on GettingFocus event</span></span>*

<span data-ttu-id="da864-161">[GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) イベントを処理し、フォーカスをリダイレクトする方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="da864-161">Here, we show how to handle the [GettingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_GettingFocus) event and redirect focus.</span></span>

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

<span data-ttu-id="da864-162">[CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) の [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) イベントを処理し、メニューが閉じたときにフォーカスを設定する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="da864-162">Here, we show how to handle the [LosingFocus](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_LosingFocus) event for a [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) and set focus when the menu is closed.</span></span>

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

## <a name="find-the-first-and-last-focusable-element"></a><span data-ttu-id="da864-163">フォーカス可能な最初と最後の要素を見つける</span><span class="sxs-lookup"><span data-stu-id="da864-163">Find the first and last focusable element</span></span>

<span data-ttu-id="da864-164">[FocusManager.FindFirstFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindFirstFocusableElement_Windows_UI_Xaml_DependencyObject_) メソッドと [FocusManager.FindLastFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindLastFocusableElement_Windows_UI_Xaml_DependencyObject_) メソッドでは、オブジェクトのスコープ内にあるフォーカス可能な最初または最後の要素にフォーカスが移動されます ([UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) の要素ツリーや [TextElement](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.documents.textelement) のテキスト ツリー)。</span><span class="sxs-lookup"><span data-stu-id="da864-164">The [FocusManager.FindFirstFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindFirstFocusableElement_Windows_UI_Xaml_DependencyObject_) and [FocusManager.FindLastFocusableElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager#Windows_UI_Xaml_Input_FocusManager_FindLastFocusableElement_Windows_UI_Xaml_DependencyObject_) methods move focus to the first or last focusable element within the scope of an object (the element tree of a [UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) or the text tree of a [TextElement](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.documents.textelement)).</span></span> <span data-ttu-id="da864-165">スコープは呼び出しで指定されます (引数が null の場合、スコープは現在のウィンドウになります)。</span><span class="sxs-lookup"><span data-stu-id="da864-165">The scope is specified in the call (if the argument is null, the scope is the current window).</span></span>

<span data-ttu-id="da864-166">スコープ内でフォーカス候補を識別できない場合、null が返されます。</span><span class="sxs-lookup"><span data-stu-id="da864-166">If no focus candidates can be identified in the scope, null is returned.</span></span>

<span data-ttu-id="da864-167">CommandBar のボタンが折り返し方向動作をするように指定する方法を次に示します (「[キーボード操作](keyboard-interactions.md#popup-ui)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="da864-167">Here, we show how to specify that the buttons of a CommandBar have a wrap-around directional behavior (see [Keyboard Interactions](keyboard-interactions.md#popup-ui)).</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="da864-168">関連記事</span><span class="sxs-lookup"><span data-stu-id="da864-168">Related articles</span></span>

- [<span data-ttu-id="da864-169">キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="da864-169">Focus navigation for keyboard, gamepad, remote control, and accessibility tools</span></span>](focus-navigation.md)
- [<span data-ttu-id="da864-170">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="da864-170">Keyboard interactions</span></span>](keyboard-interactions.md)
- [<span data-ttu-id="da864-171">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="da864-171">Keyboard accessibility</span></span>](../accessibility/keyboard-accessibility.md)