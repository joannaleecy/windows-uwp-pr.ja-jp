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
# <a name="managing-focus-navigation"></a><span data-ttu-id="b88cc-101">フォーカス ナビゲーションの管理</span><span class="sxs-lookup"><span data-stu-id="b88cc-101">Managing focus navigation</span></span>

<span data-ttu-id="b88cc-102">多くの入力、つまりキーボードや、Windows ナレーター、ゲームパッド、リモコンなどのアクセシビリティ ツールは、アプリケーションの UI でフォーカス表示を移動するために基になる共通のメカニズムを共有しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-102">Many input namely keyboard, accessibility tools such as Windows Narrator, gamepad, and remote control share common underling mechanism to move focus visual around your applications’ UI.</span></span> <span data-ttu-id="b88cc-103">フォーカス表示とナビゲーションについて詳しくは、「[キーボード操作](keyboard-interactions.md)」と「[Xbox およびテレビ向け設計](designing-for-tv.md#xy-focus-navigation-and-interaction)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b88cc-103">Read more about focus visual and navigation at [Keyboard Interaction](keyboard-interactions.md) document as well as [Designing for Xbox and TV](designing-for-tv.md#xy-focus-navigation-and-interaction) document.</span></span>

<span data-ttu-id="b88cc-104">ここでは、アプリケーションがアプリケーションの UI でフォーカスを移動するための入力に依存しない方法について説明します。これにより、入力の種類を複数使う場合でもアプリケーションが適切に動作する単一のコードを記述できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-104">Following provide input agnostic way for application to move focus around the application’s UI which enable you to write single code that make your application work great with multiple input types.</span></span>

## <a name="navigation-strategies-properties-to-fine-tune-focus-movements"></a><span data-ttu-id="b88cc-105">フォーカスの動きを微調整するナビゲーション方法プロパティ</span><span class="sxs-lookup"><span data-stu-id="b88cc-105">Navigation Strategies properties to fine tune focus movements</span></span>

<span data-ttu-id="b88cc-106">押された方向キーに基づいてフォーカスを受け取るコントロールを指定するには、XYFocus ナビゲーション方法プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="b88cc-106">Use the XYFocus navigation strategy properties to specify which control should receive focus based on the arrow key pressed.</span></span> <span data-ttu-id="b88cc-107">次のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-107">These properties are:</span></span>

-   <span data-ttu-id="b88cc-108">XYFocusUpNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="b88cc-108">XYFocusUpNavigationStrategy</span></span>
-   <span data-ttu-id="b88cc-109">XYFocusDownNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="b88cc-109">XYFocusDownNavigationStrategy</span></span>
-   <span data-ttu-id="b88cc-110">XYFocusLeftNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="b88cc-110">XYFocusLeftNavigationStrategy</span></span>
-   <span data-ttu-id="b88cc-111">XYFocusRightNavigationStrategy</span><span class="sxs-lookup"><span data-stu-id="b88cc-111">XYFocusRightNavigationStrategy</span></span>

<span data-ttu-id="b88cc-112">これらプロパティには、**XYFocusNavigationStrategy** 型の値があります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-112">These properties have a value of type value of type **XYFocusNavigationStrategy**.</span></span> <span data-ttu-id="b88cc-113">**Auto** に設定された場合、要素の動作は要素の先祖に基づいて決まります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-113">If set to **Auto**, the behavior of the element is based on the ancestors of the element.</span></span> <span data-ttu-id="b88cc-114">すべての要素が **Auto** に設定されている場合、**Projection** が使用されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-114">If all elements are set to **Auto**, **Projection** is used.</span></span>

<span data-ttu-id="b88cc-115">これらのナビゲーション方法では、キーボード、ゲームパッド、リモコンに適用されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-115">These navigation strategies are applicable to keyboard, gamepad, and remote control.</span></span>

### <a name="projection"></a><span data-ttu-id="b88cc-116">Projection</span><span class="sxs-lookup"><span data-stu-id="b88cc-116">Projection</span></span>

<span data-ttu-id="b88cc-117">Projection 方法を使うと、現在フォーカスがある要素の端をナビゲーションの方向に投影するときに出会った最初の要素にフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-117">The Projection strategy moves focus to the first element encountered when projecting the edge of the currently focused element in the  direction of navigation.</span></span>

> [!NOTE]
> <span data-ttu-id="b88cc-118">前にフォーカスがあった要素や、ナビゲーション方向の軸までの近さなど、アルゴリズムに影響を与えるその他の要因により、結果に影響があります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-118">Other factors, such as the previously focused element and proximity to the axis of the navigation direction, can influence the result.</span></span>

![プロジェクション](images/keyboard/projection.png)

*<span data-ttu-id="b88cc-120">A の下端のプロジェクションに基づき、下ナビゲーションでフォーカスを A から D へ移動します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-120">Focus moves from A to D on down navigation based on projection of the bottom edge of A</span></span>*

### <a name="navigationdirectiondistance"></a><span data-ttu-id="b88cc-121">NavigationDirectionDistance</span><span class="sxs-lookup"><span data-stu-id="b88cc-121">NavigationDirectionDistance</span></span>

<span data-ttu-id="b88cc-122">NavigationDirectionDistance 方法では、ナビゲーション方向の軸に最も近い要素にフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-122">The NavigationDirectionDistance strategy moves focus to the element closest to the axis of the navigation direction.</span></span>

<span data-ttu-id="b88cc-123">ナビゲーション方向に対応する境界の四角形の端が拡張、プロジェクションされて、ターゲット候補を識別します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-123">The edge of the bounding rect corresponding to the navigation direction is extended and projected to identify candidate targets.</span></span> <span data-ttu-id="b88cc-124">最初に接触した要素がターゲットとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-124">The first element encountered is identified as the target.</span></span> <span data-ttu-id="b88cc-125">複数の候補がある場合は、最も近い要素がターゲットとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-125">In the case of multiple candidates, the closest element is identified as the target.</span></span> <span data-ttu-id="b88cc-126">さらに複数の候補がある場合には、最も上で最も左の要素が候補として識別されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-126">If there are still multiple candidates, the topmost/leftmost element is identified as the candidate.</span></span>

![ナビゲーション方向の距離](images/keyboard/navigation-direction-distance.png)

*<span data-ttu-id="b88cc-128">下ナビゲーションで、フォーカスが A から C に移動し、次に C から B に移動します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-128">Focus moves from A to C and then from C to B on down navigation</span></span>*


### <a name="rectilineardistance"></a><span data-ttu-id="b88cc-129">RectilinearDistance</span><span class="sxs-lookup"><span data-stu-id="b88cc-129">RectilinearDistance</span></span>

<span data-ttu-id="b88cc-130">RectilinearDistance 方法では、最も短い 2D 距離に基づいて最も近い要素にフォーカスが移動します (マンハッタン メトリック)。</span><span class="sxs-lookup"><span data-stu-id="b88cc-130">The RectilinearDistance strategy moves focus to the closest element based on the shortest 2D distance (Manhattan metric).</span></span> <span data-ttu-id="b88cc-131">この距離は、潜在的な各候補のプライマリ距離とセカンダリ距離を加算することによって計算されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-131">This distance is calculated by adding the primary distance and the secondary distance of each potential candidate.</span></span> <span data-ttu-id="b88cc-132">TIE では、方向が上または下の場合は左方向の最初の要素が選択され、方向が左または右の場合は上方向の最初の要素が選択されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-132">In a tie, the first element to the left is selected if the direction is up or down, or the first element to the top is selected if the direction is left or right.</span></span>

<span data-ttu-id="b88cc-133">次の図では、A にフォーカスがあるときにフォーカスが B に移動することが示されています。理由は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b88cc-133">In the following image, we show that when A has focus, focus is moved to B because:</span></span>

-   <span data-ttu-id="b88cc-134">距離 (A、B、下) = 10 + 0 = 10</span><span class="sxs-lookup"><span data-stu-id="b88cc-134">Distance (A, B, Down) = 10 + 0 = 10</span></span>
-   <span data-ttu-id="b88cc-135">距離 (A、C、下) = 0 + 30 = 30</span><span class="sxs-lookup"><span data-stu-id="b88cc-135">Distance (A, C, Down) = 0 + 30 = 30</span></span>
-   <span data-ttu-id="b88cc-136">距離 (A、D、下) 30 + 0 = 30</span><span class="sxs-lookup"><span data-stu-id="b88cc-136">Distance (A, D, Down) 30 + 0 = 30</span></span>

![直線距離](images/keyboard/rectilinear-distance.png)

*<span data-ttu-id="b88cc-138">A にフォーカスがある場合、RectilinearDistance 方法を使うとフォーカスは B に移動する</span><span class="sxs-lookup"><span data-stu-id="b88cc-138">When A has focus, focus is moved to B when using the RectilinearDistance strategy</span></span>*

<span data-ttu-id="b88cc-139">次の図は、ナビゲーション方法が子要素ではなくどのようにその要素自体に適用されるかを示しています (XYFocusKeyboardNavigation とは異なります)。</span><span class="sxs-lookup"><span data-stu-id="b88cc-139">The following image shows how the navigation strategy is applied to the element itself, not the child elements (unlike XYFocusKeyboardNavigation).</span></span>

<span data-ttu-id="b88cc-140">たとえば、E にフォーカスがある場合、RectilinearDistance 方法を使うと右方向キーを押したときにフォーカスは F に移動しますが、D にフォーカスがある場合、Projection 方法を使うと右方向キーを押したときにフォーカスは H に移動します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-140">For example, when E has focus, pressing right moves focus to F using the RectilinearDistance strategy, but when D has focus, pressing right moves focus to H when using the Projection strategy.</span></span>

<span data-ttu-id="b88cc-141">メイン コンテナー方法 (ナビゲーション方向距離) は適用されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b88cc-141">Notice that main container strategy (Navigation Direction Distance) is not applied.</span></span> <span data-ttu-id="b88cc-142">フォーカスが H、F、または G にフォーカスがあるときにだけ使われます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-142">It is only used when the focus is on H, F, or G.</span></span>

![さまざまなナビゲーション方法](images/keyboard/different-navigation-strategies.png)

*<span data-ttu-id="b88cc-144">ナビゲーション方法に基づいてさまざまなフォーカスの動作が適用される</span><span class="sxs-lookup"><span data-stu-id="b88cc-144">Different focus behaviors based on navigation strategy applied</span></span>*

<span data-ttu-id="b88cc-145">次の例は、Windows 10 のスタート メニューからのタイル パネルの動作をシミュレートしています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-145">The following example simulates the behavior of the Tiles panel from the Windows 10 Start menu.</span></span> <span data-ttu-id="b88cc-146">この場合、上および下方向キーを押すと NavigationDirectionDistance 方法が使われ、左および右方向キーを押すと Projection 方法が使われます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-146">In this case, pressing the up and down arrow uses the NavigationDirectionDistance strategy, and pressing the left and right arrow uses the Projection strategy.</span></span>

```XAML
<start:TileGridView
        XYFocusKeyboardNavigation ="Default"
        XYFocusUpNavigationStrategy=" NavigationDirectionDistance "
        XYFocusDownNavigationStrategy=" NavigationDirectionDistance "
        XYFocusLeftNavigationStrategy="Projection"
        XYFocusRightNavigationStrategy="Projection"
/>
```

## <a name="move-focus-programmatically"></a><span data-ttu-id="b88cc-147">フォーカスをプログラムにより移動する</span><span class="sxs-lookup"><span data-stu-id="b88cc-147">Move focus programmatically</span></span>

<span data-ttu-id="b88cc-148">フォーカスをプログラムにより移動するには、[FocusManager.TryMoveFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.TryMoveFocus) メソッドまたは [FocusManager.FindNextElement](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.FindNextFocusableElement) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="b88cc-148">Use either the [FocusManager.TryMoveFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.TryMoveFocus) method or the [FocusManager.FindNextElement](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Input.FocusManager.FindNextFocusableElement) method to programmatically move focus.</span></span>

<span data-ttu-id="b88cc-149">TryMoveFocus は、ナビゲーション キーが押された場合と同様にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-149">TryMoveFocus sets focus as if a navigation key was pressed.</span></span>
<span data-ttu-id="b88cc-150">FindNextElement は、TryMoveFocus の移動先の要素 (DependencyObject) を返します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-150">FindNextElement returns the element (a DependencyObject) that TryMoveFocus would move to.</span></span>

<span data-ttu-id="b88cc-151">**注** **FindNextFocusableElement** の代わりに **FindNextElement** メソッドを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b88cc-151">**NOTE** We recommend using the **FindNextElement** method instead of **FindNextFocusableElement**.</span></span> <span data-ttu-id="b88cc-152">FindNextFocusableElement は UIElement を返そうとしますが、フォーカス可能な次の要素がハイパーリンクである場合、ハイパーリンクは UIElement ではないため、null を返します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-152">FindNextFocusableElement tries to return a UIElement, but if the next focusable element is a Hyperlink, it returns null because a Hyperlink is not a UIElement.</span></span> <span data-ttu-id="b88cc-153">FindNextElement メソッドでは、代わりに DependencyObject を返します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-153">FindNextElement method returns a DependencyObject instead.</span></span>

### <a name="find-a-focus-candidate-in-a-scope"></a><span data-ttu-id="b88cc-154">スコープでフォーカス候補を見つける</span><span class="sxs-lookup"><span data-stu-id="b88cc-154">Find a focus candidate in a scope</span></span>

<span data-ttu-id="b88cc-155">FocusManager.FindNextElement と FocusManager.TryMoveFocus のどちらを使っても、フォーカス可能な次の要素の検出動作をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-155">FocusManager.FindNextElement and FocusManager.TryMoveFocus both let you customize the next focusable element search behavior.</span></span> <span data-ttu-id="b88cc-156">特定の UI ツリー内を探したり、特定のナビゲーション領域内の要素を除外したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-156">You can search within a specific UI tree, or exclude elements in a specific navigation area.</span></span>

<span data-ttu-id="b88cc-157">この例は、TicTacToe ゲームの実装から取られたものであり、FindNextElement メソッドと TryMoveFocus メソッドの使用方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-157">This example is taken from an implementation of a TicTacToe game and demonstrates how to use the FindNextElement and TryMoveFocus methods:</span></span>

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

<span data-ttu-id="b88cc-158">**注** FocusNavigationDirection.Left と FocusNavigationDirection.Right は、RTL シナリオをサポートする点で論理的 (近いか遠いか) です </span><span class="sxs-lookup"><span data-stu-id="b88cc-158">**NOTE** FocusNavigationDirection.Left and FocusNavigationDirection.Right are logical (near and far) to support RTL scenarios.</span></span> <span data-ttu-id="b88cc-159">(これは Xaml の残りの部分と一致します)。</span><span class="sxs-lookup"><span data-stu-id="b88cc-159">(This matches the rest of Xaml.)</span></span>

<span data-ttu-id="b88cc-160">フォーカス候補の検出は、FindNextElementOptions クラスを使って調整できます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-160">The search for focus candidates can be adjusted using the FindNextElementOptions class.</span></span> <span data-ttu-id="b88cc-161">このオブジェクトには、次のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-161">This object has the following properties:</span></span>

-   <span data-ttu-id="b88cc-162">**SearchRoot** DependencyObject: 候補の検出のスコープをこの DependencyObject の子に設定します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-162">**SearchRoot** DependencyObject: To scope the search of candidates to the children of this DependencyObject.</span></span> <span data-ttu-id="b88cc-163">Null 値は、アプリのビジュアル ツリー全体を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-163">Null value indicates the entire visual tree of the app.</span></span>
-   <span data-ttu-id="b88cc-164">**ExclusionRect** Rect: レンダリングしたときにこの四角形と 1 ピクセル以上重なる項目を検出から除外します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-164">**ExclusionRect** Rect: To exclude from the search the items that, when are rendered, overlap at least one pixel from this rectangle.</span></span>
-   <span data-ttu-id="b88cc-165">**HintRect** Rect: フォーカスのある項目を基準として使って潜在的候補が計算されます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-165">**HintRect** Rect: Potential candidates are calculated using the focused item as reference.</span></span> <span data-ttu-id="b88cc-166">この長方形を使うことで、開発者はフォーカスのある要素ではなく別の基準を指定できます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-166">This rectangle lets developers specify another reference instead of the focused element.</span></span> <span data-ttu-id="b88cc-167">四角形は、計算にのみ使用される "架空" の四角形です。</span><span class="sxs-lookup"><span data-stu-id="b88cc-167">The rectangle is a “fictitious” rectangle used only for calculations.</span></span> <span data-ttu-id="b88cc-168">実際の四角形に変換されてビジュアル ツリーに追加されることはありません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-168">It is never converted to a real rectangle and added to the visual tree.</span></span>
-   <span data-ttu-id="b88cc-169">**XYFocusNavigationStrategyOverride** XYFocusNavigationStrategyOverride: フォーカスの移動に使われるナビゲーション方法。</span><span class="sxs-lookup"><span data-stu-id="b88cc-169">**XYFocusNavigationStrategyOverride** XYFocusNavigationStrategyOverride: The navigation strategy used to move the focus.</span></span> <span data-ttu-id="b88cc-170">型は列挙型で、値は None (値が 0)、Auto、RectilinearDistance、NavigationDirectionDistance、Projection です。</span><span class="sxs-lookup"><span data-stu-id="b88cc-170">The type is an enum with the values None (which is the zero value), Auto, RectilinearDistance, NavigationDirectionDistance and Projection.</span></span>
    <span data-ttu-id="b88cc-171">**重要** **SearchRoot** は、レンダリングされる (幾何学的な) 領域の計算や、領域内の候補の取得には使われません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-171">**Important** **SearchRoot** is not used to calculate the rendered (geometric) area or to get the candidates inside the area.</span></span> <span data-ttu-id="b88cc-172">結果として、子孫の方向領域の外側に配置する DependencyObject の子孫に変換が適用される場合でも、これらの要素が候補と見なされます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-172">As a consequence, if transforms are applied to the descendants of the DependencyObject that place them outside of the directional area, these elements are still considered candidates.</span></span>

<span data-ttu-id="b88cc-173">FindNextElement のオプション オーバー ロードをタブ ナビゲーションで使うことはできません、方向ナビゲーションのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-173">The options overload of FindNextElement cannot be used with tab navigation, it only supports directional navigation.</span></span>

<span data-ttu-id="b88cc-174">次の図は、これらのオプションを示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-174">The following image illustrates these options.</span></span>

<span data-ttu-id="b88cc-175">たとえば、B にフォーカスがある場合、FindNextElement を呼び出すと (各種オプションはフォーカスが右に移動するように設定) フォーカスが I に設定されます。この理由は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b88cc-175">For example, when B has focus, calling FindNextElement (with various options set to indicate that focus moves to the right) sets focus on I. The reasons for this are:</span></span>

1.  <span data-ttu-id="b88cc-176">基準が B でない場合、HintRect のために A である</span><span class="sxs-lookup"><span data-stu-id="b88cc-176">The reference is not B, it is A due to the HintRect</span></span>
2.  <span data-ttu-id="b88cc-177">潜在的候補が MyPanel (SearchRoot) にあるため、C が除外される</span><span class="sxs-lookup"><span data-stu-id="b88cc-177">C is excluded because the potential candidate should be on MyPanel (the SearchRoot)</span></span>
3.  <span data-ttu-id="b88cc-178">除外四角形と重なるため、F が除外される</span><span class="sxs-lookup"><span data-stu-id="b88cc-178">F is excluded because it overlaps the exclusions rectangle</span></span>

![ナビゲーション ヒント](images/keyboard/navigation-hints.png)

*<span data-ttu-id="b88cc-180">ナビゲーション ヒントに基づくフォーカスの動作</span><span class="sxs-lookup"><span data-stu-id="b88cc-180">Focus behavior based on navigation hints</span></span>*

### <a name="no-focus-candidate-available"></a><span data-ttu-id="b88cc-181">利用可能なフォーカス候補がない</span><span class="sxs-lookup"><span data-stu-id="b88cc-181">No focus candidate available</span></span>

<span data-ttu-id="b88cc-182">UIElement.NoFocusCandidateFound イベントは、ユーザーが Tab キーまたは方向キーによってフォーカスを移動しようとしたが、指定された方向に考えられる候補がない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-182">The UIElement.NoFocusCandidateFound event is fired when the user attempts to move focus with tab or arrow keys, but there is no possible candidate in the specified direction.</span></span> <span data-ttu-id="b88cc-183">このイベントは、FocusManager.TryMoveFocus() に対しては発生しません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-183">This event is not fired for FocusManager.TryMoveFocus().</span></span>

<span data-ttu-id="b88cc-184">これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。</span><span class="sxs-lookup"><span data-stu-id="b88cc-184">Because this is a routed event, it bubbles from the focused element up through successive parent objects to the root of the object tree.</span></span> <span data-ttu-id="b88cc-185">このようにして、適切な場合はいつでもイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-185">In this way, you can handle the event wherever appropriate.</span></span>

<span data-ttu-id="b88cc-186"><a name="split-view-code-sample"></a>次の例は、[テレビ向けの設計ドキュメント](designing-for-tv.md#navigation-pane)で説明されているように、ユーザーがフォーカス可能な一番左のコントロールの左側にフォーカスを移動しようとしたときに分割ビューを開くグリッドを示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-186"><a name="split-view-code-sample"></a> The following example shows a Grid that opens a split view when the user attempts to move focus to the left of the left-most focusable control as described in [Designing for TV documentation](designing-for-tv.md#navigation-pane).</span></span>

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

## <a name="focus-events"></a><span data-ttu-id="b88cc-187">フォーカス イベント</span><span class="sxs-lookup"><span data-stu-id="b88cc-187">Focus events</span></span>

<span data-ttu-id="b88cc-188">[UIElement.GotFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.GotFocus)イベントと UIElement.LostFocus イベントは、それぞれコントロールがフォーカスを取得したときとフォーカスを失ったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-188">The [UIElement.GotFocus](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.GotFocus) and UIElement.LostFocus events are fired when a control gets focus or loses focus, respectively.</span></span> <span data-ttu-id="b88cc-189">このイベントは、FocusManager.TryMoveFocus() に対しては発生しません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-189">This event is not fired for FocusManager.TryMoveFocus().</span></span>

<span data-ttu-id="b88cc-190">これはルーティング イベントであるため、フォーカスのある要素から、連続する親オブジェクトを通ってオブジェクト ツリーのルートまでバブル アップします。</span><span class="sxs-lookup"><span data-stu-id="b88cc-190">Because this is a routed event, it bubbles from the focused element up through successive parent objects to the root of the object tree.</span></span> <span data-ttu-id="b88cc-191">このようにして、適切な場合はいつでもイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-191">In this way, you can handle the event wherever appropriate.</span></span>

<span data-ttu-id="b88cc-192">**UIElement.GettingFocus** イベントと **UIElement.LosingFocus** イベントもコントロールからバブルしますが、フォーカスの変更が行われる*前*です。</span><span class="sxs-lookup"><span data-stu-id="b88cc-192">The **UIElement.GettingFocus** and **UIElement.LosingFocus** events also bubble from the control, but *before* the focus change takes place.</span></span> <span data-ttu-id="b88cc-193">これにより、アプリはフォーカスの変更をリダイレクトしたりキャンセルしたりできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-193">This gives the app an opportunity to redirect or cancel the focus change.</span></span>

<span data-ttu-id="b88cc-194">GettingFocus イベントと LosingFocusイベントは同期的ですが、GotFocus イベントと LostFocus イベントは非同期的であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b88cc-194">Note that the GettingFocus and LosingFocus events are synchronous, while the GotFocus and LostFocus events are asynchronous.</span></span> <span data-ttu-id="b88cc-195">たとえば、アプリが Control.Focus() メソッドを呼び出したためにフォーカスが移動した場合、GettingFocus は呼び出し時に発生しますが、GotFocus は呼び出しの後しばらくしてから発生します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-195">For example, if focus moves because the app calls the Control.Focus() method, GettingFocus is raised during the call, but GotFocus is raised sometime after the call.</span></span>

<span data-ttu-id="b88cc-196">UIElements は、GettingFocus イベントと LosingFocus イベントにフックし、フォーカスが移動する前にターゲットを変更できます (NewFocusedElement プロパティを使用)。</span><span class="sxs-lookup"><span data-stu-id="b88cc-196">UIElements can hook onto the GettingFocus and LosingFocus events and change the target (using the NewFocusedElement property) before the focus is moved.</span></span> <span data-ttu-id="b88cc-197">ターゲットが変更されている場合でも、イベントはバブルし、別の親がターゲットを再度変更できます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-197">Even if the target has changed, the event still bubbles and another parent can change the target again.</span></span>

<span data-ttu-id="b88cc-198">再入の問題を避けるため、これらのイベントのバブル中にフォーカスを移動しようとした場合 (FocusManager.TryMoveFocus または Control.Focus を使用)、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-198">To avoid reentrancy issues, exceptions are thrown if you try to move focus (using FocusManager.TryMoveFocus or the Control.Focus) while these events are bubbling.</span></span>

<span data-ttu-id="b88cc-199">これらのイベントは、フォーカスの移動理由 (たとえば、タブ ナビゲーション、XYFocus ナビゲーション、プログラムなど) にかかわらずが発生します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-199">These events are fired regardless of the reason for the focus moving (for example, tab navigation, XYFocus navigation, programmatic).</span></span>

<span data-ttu-id="b88cc-200">次の図は、A から右に移動するとき、XYFocus が候補として LVI4 を選ぶ方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-200">The following image shows how, when moving from A to the right, the XYFocus chooses LVI4 as a candidate.</span></span> <span data-ttu-id="b88cc-201">その後、LVI4 は GettingFocus イベントを発生させ、ListView が LVI3 にフォーカスを再割り当てすることができます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-201">LVI4 then fires the GettingFocus event where the ListView has the opportunity to reassign focus to LVI3.</span></span>

![フォーカス イベント](images/keyboard/focus-events.png)

*<span data-ttu-id="b88cc-203">フォーカス イベント</span><span class="sxs-lookup"><span data-stu-id="b88cc-203">Focus events</span></span>*

<span data-ttu-id="b88cc-204">このコード例は、OnGettingFocus イベントを処理し、フォーカスが前に設定されていたに場所に基づいてフォーカスをリダイレクトする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-204">This code example shows how to handle the OnGettingFocus event and redirect focus based on where focus was previously set.</span></span>

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

<span data-ttu-id="b88cc-205">このコード例は、CommandBar オブジェクトの OnLosingFocus イベントを処理し、ドロップダウン メニューが閉じられるまでフォーカスの設定を待機する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-205">This code example shows how to handle the OnLosingFocus event for a CommandBar object and wait to set focus until the DropDown menu is closed.</span></span>

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

### <a name="losingfocus-and-gettingfocus-event-order"></a><span data-ttu-id="b88cc-206">LosingFocus イベントと GettingFocus イベントの順序</span><span class="sxs-lookup"><span data-stu-id="b88cc-206">LosingFocus and GettingFocus event order</span></span>

<span data-ttu-id="b88cc-207">LosingFocus と GettingFocus は同期イベントであるため、これらのイベントのバブル中はフォーカスが移動しません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-207">LosingFocus and GettingFocus are synchronous events, so focus won’t be moved while these events are bubbling.</span></span> <span data-ttu-id="b88cc-208">一方、LostFocus と GotFocus は非同期イベントであるため、ハンドラーが実行される前にフォーカスがもう一度移動しないことは保証されません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-208">However, because LostFocus and GotFocus are asynchronous events, there is no guarantee that focus won’t move again before the handler is executed.</span></span> <span data-ttu-id="b88cc-209">唯一保証されるのは、LostFocus ハンドラーが GotFocus ハンドラーの前に実行されることです。</span><span class="sxs-lookup"><span data-stu-id="b88cc-209">The only guarantee is that the LostFocus handler is executed before the GotFocus handler.</span></span>

<span data-ttu-id="b88cc-210">実行順序を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-210">Here is the order of execution:</span></span>

1.  <span data-ttu-id="b88cc-211">Sync LosingFocus: LosingFocus が、フォーカスを失ったか Cancel=true を設定した要素にフォーカスをリセットした場合、それ以上イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-211">Sync LosingFocus: If LosingFocus resets focus back to the element that was losing focus or setting the Cancel=true, no further events</span></span>
2.  <span data-ttu-id="b88cc-212">Sync GettingFocus: GettingFocus が、フォーカスを失ったか Cancel=true を設定した要素にフォーカスをリセットした場合、それ以上イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="b88cc-212">Sync GettingFocus: If GettingFocus resets focus back to the element that was losing focus or setting the Cancel=true, no further events</span></span>
3.  <span data-ttu-id="b88cc-213">Async LostFocus</span><span class="sxs-lookup"><span data-stu-id="b88cc-213">Async LostFocus</span></span>
4.  <span data-ttu-id="b88cc-214">Async GotFocus</span><span class="sxs-lookup"><span data-stu-id="b88cc-214">Async GotFocus</span></span>

## <a name="find-the-first-and-last-focusable-element-a-namefindfirstfocusableelement"></a><span data-ttu-id="b88cc-215">フォーカス可能な最初と最後の要素を見つける <a name="findfirstfocusableelement"></span><span class="sxs-lookup"><span data-stu-id="b88cc-215">Find the first and last focusable element <a name="findfirstfocusableelement"></span></span>

<span data-ttu-id="b88cc-216">**FocusManager.FindFirstFocusableElement** メソッドと **FocusManager.FindLastFocusableElement** メソッドを使うと、オブジェクトのスコープ内のフォーカス可能な最初または最後の要素にフォーカスを移動できます (UIElement の要素ツリーや TextElement のテキスト ツリー)。</span><span class="sxs-lookup"><span data-stu-id="b88cc-216">The **FocusManager.FindFirstFocusableElement** and the **FocusManager.FindLastFocusableElement** methods let you move focus to the first or last focusable element within the scope of an object (the element tree of a UIElement or the text tree of a TextElement).</span></span> <span data-ttu-id="b88cc-217">スコープは、これらのメソッドを呼び出すときに指定します。</span><span class="sxs-lookup"><span data-stu-id="b88cc-217">You specify the scope when you call these methods.</span></span> <span data-ttu-id="b88cc-218">引数が null の場合、スコープは現在のウィンドウになります。</span><span class="sxs-lookup"><span data-stu-id="b88cc-218">If the argument is null, the scope will be the current window.</span></span>

<span data-ttu-id="b88cc-219">**注** スコープにフォーカス可能な項目がない場合、これらのメソッドは null を返すことができます。</span><span class="sxs-lookup"><span data-stu-id="b88cc-219">**Note** These methods can return null if there are no focusable items in the scope.</span></span>

<span data-ttu-id="b88cc-220"><a name="popup-ui-code-sample"></a>次のコード例は、「[キーボード操作](keyboard-interactions.md#popup-ui)」で説明されているように、CommandBar のボタンが折り返し方向動作をするように指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b88cc-220"><a name="popup-ui-code-sample"></a> The following code example shows how to specify that the buttons of a CommandBar have a wrap-around directional behavior described in [Keyboard Interactions](keyboard-interactions.md#popup-ui) article.</span></span>

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
