---
author: Karl-Bridge-Microsoft
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: 010663320b4011d853c53bc4121f86a14bfbfe0c
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="custom-keyboard-interactions"></a><span data-ttu-id="9b523-101">カスタムのキーボード操作</span><span class="sxs-lookup"><span data-stu-id="9b523-101">Custom keyboard interactions</span></span>

<span data-ttu-id="9b523-102">キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に対して、総合的で一貫性のあるキーボード エクスペリエンスを UWP アプリやカスタム コントロールで提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9b523-102">Provide comprehensive and consistent keyboard interaction experiences in your UWP apps and custom controls for both keyboard power users and those with disabilities and other accessibility requirements.</span></span>

<span data-ttu-id="9b523-103">このトピックでは、PC 上の UWP アプリのカスタム コントロールによってキーボード入力をサポートすることに主な焦点を当てます。</span><span class="sxs-lookup"><span data-stu-id="9b523-103">In this topic, our primary focus is on supporting keyboard input with custom controls for UWP apps on PCs.</span></span> <span data-ttu-id="9b523-104">ただし、適切に設計されたキーボード エクスペリエンスは、ナレーターなどのアクセシビリティ ツールをサポートしたり、タッチ キーボードやスクリーン キーボード (OSK) などのソフトウェア キーボードを使ったりするために重要です。</span><span class="sxs-lookup"><span data-stu-id="9b523-104">However, a well-designed keyboard experience is important for supporting accessibility tools such as Windows Narrator, using software keyboards such as the touch keyboard and the On-Screen Keyboard (OSK).</span></span>

## <a name="providing-2d-directional-inner-navigation-a-namexyfocuskeyboardnavigation"></a><span data-ttu-id="9b523-105">2D 方向内部ナビゲーションを提供する <a name="xyfocuskeyboardnavigation"></span><span class="sxs-lookup"><span data-stu-id="9b523-105">Providing 2D directional inner navigation <a name="xyfocuskeyboardnavigation"></span></span>

<span data-ttu-id="9b523-106">キーボード (方向キー)、Xbox ゲームパッド (方向パッドと左スティック ボタン)、Xbox リモコン (方向パッド) によって、カスタム コントロールおよびコントロール グループの 2D 方向内部ナビゲーションをサポートするには、**XYFocusKeyboardNavigation** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="9b523-106">Use the **XYFocusKeyboardNavigation** property to support 2D directional inner navigation of custom controls and control groups with keyboard (arrow keys), Xbox gamepad (D-pad and left stick buttons), and Xbox remote control (D-pad).</span></span>

<span data-ttu-id="9b523-107">**注** コントロールまたはコントロール グループの内部ナビゲーション領域のことを*方向領域*と呼びます。</span><span class="sxs-lookup"><span data-stu-id="9b523-107">**NOTE** We refer to the inner navigation region of a control or control group as the *directional area*.</span></span>

<span data-ttu-id="9b523-108">**XYFocusKeyboardNavigation** には、**XYFocusKeyboardNavigationMode** 型の値があります。指定可能な値は、**Auto** (既定)、**Enabled**、**Disabled** です。</span><span class="sxs-lookup"><span data-stu-id="9b523-108">**XYFocusKeyboardNavigation** has a value of type **XYFocusKeyboardNavigationMode** with possible values of **Auto** (default), **Enabled** or **Disabled**.</span></span>

<span data-ttu-id="9b523-109">このプロパティは、タブ ナビゲーションに影響を与えず、コントロールまたはコントロール グループ内の子要素の内部ナビゲーションにのみ影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="9b523-109">This property does not affect tab navigation, it only affects the inner navigation of child elements within your control or control group.</span></span> <span data-ttu-id="9b523-110">方向領域の子要素は、タブ ナビゲーションに含めないでください。</span><span class="sxs-lookup"><span data-stu-id="9b523-110">Child elements of a directional area should not be included in tab navigation.</span></span>

### <a name="default-behavior"></a><span data-ttu-id="9b523-111">既定の動作</span><span class="sxs-lookup"><span data-stu-id="9b523-111">Default behavior</span></span>

<span data-ttu-id="9b523-112">方向ナビゲーションの動作は、要素の先祖、つまり継承階層に基づいて決まります。</span><span class="sxs-lookup"><span data-stu-id="9b523-112">Directional navigation behavior is based on the element’s ancestry, or inheritance hierarchy.</span></span> <span data-ttu-id="9b523-113">すべての先祖が既定のモードの場合、つまり **Auto** に設定されている場合、キーボードでは方向ナビゲーションの動作がサポートされません (ゲームパッドとリモコンでは、明示的に **Disabled** に設定されていない限り常に方向ナビゲーションがサポートされます)。</span><span class="sxs-lookup"><span data-stu-id="9b523-113">If all ancestors are in default mode, or set to **Auto**, directional navigation behavior is not supported for keyboard (gamepad and remote control always support directional navigation unless explicitly set to **Disabled**).</span></span>

### <a name="custom-behavior"></a><span data-ttu-id="9b523-114">カスタム動作</span><span class="sxs-lookup"><span data-stu-id="9b523-114">Custom behavior</span></span>

<span data-ttu-id="9b523-115">このプロパティを設定 **Enabled** に設定すると、コントロール内のあらゆる UIElement で 2D 内部ナビゲーションがコントロールによりサポートされます (キーボードの方向キーを使用)。</span><span class="sxs-lookup"><span data-stu-id="9b523-115">Setting this property to **Enabled** lets your control support 2D inner navigation (using the keyboard arrow keys) over every UIElement within your control.</span></span>

<span data-ttu-id="9b523-116">キーボードの方向キーを使うと、方向領域内にナビゲーションが制限されます (Tab キーを押すと、方向領域の外側のフォーカス可能な次の要素にフォーカスが設定されます)。</span><span class="sxs-lookup"><span data-stu-id="9b523-116">When using the keyboard arrow keys, navigation is constrained within the directional area (pressing the tab key sets focus to the next focusable element outside the directional area).</span></span>

<span data-ttu-id="9b523-117">**注** これは、ゲームパッドやリモコンの使用時には当てはまりません。この場合、フォーカス可能な次のコントロールまで、方向領域の外側でナビゲーションが続行されます。</span><span class="sxs-lookup"><span data-stu-id="9b523-117">**NOTE** This is not the case when using a gamepad or remote, where navigation continues outside the directional area to the next focusable control.</span></span>

<span data-ttu-id="9b523-118">このプロパティは、方向キーを使った内部ナビゲーションにのみ影響を与え、Tab キー ナビゲーションには影響を与えません。</span><span class="sxs-lookup"><span data-stu-id="9b523-118">This property affects only inner navigation with arrow keys, it does not affect tab key navigation.</span></span> <span data-ttu-id="9b523-119">すべてのコントロールでは、予想されるタブ オーダー階層が維持されます。</span><span class="sxs-lookup"><span data-stu-id="9b523-119">All controls maintain their expected tab order hierarchy.</span></span>

<span data-ttu-id="9b523-120">次の図は、方向領域内に含まれる 3 つのボタン (A、B、C) と、方向領域の外側にある 4 つ目のボタン (D) を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-120">The following image shows three buttons (A, B, and C) contained within a directional area and a fourth button (D) outside the directional area.</span></span>

![方向領域](images/keyboard/directional-area.png)

*<span data-ttu-id="9b523-122">キーボードの方向キーは、ボタン A-B-C 間でフォーカスを移動できますが、D には移動できません。</span><span class="sxs-lookup"><span data-stu-id="9b523-122">Keyboard arrow keys can move focus between the buttons A-B-C, but not D</span></span>*

<span data-ttu-id="9b523-123">次のコード例は、**XYFocusKeyboardNavigation** が有効なときにナビゲーションが受ける影響を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-123">The following code example shows how navigation is affected when **XYFocusKeyboardNavigation** is enabled.</span></span> <span data-ttu-id="9b523-124">前の画像で考えると、A が初期フォーカスを持っていて、Tab キーによりすべてのコントロールが順番に切り替わりますが (A -&gt; B -&gt; C -&gt; D、の後 A に戻る)、方向キーは方向領域に制限されます。</span><span class="sxs-lookup"><span data-stu-id="9b523-124">Using the previous image, A has initial focus and the tab key cycles through all controls (A -&gt; B -&gt; C -&gt; D and back to A) while the arrow keys are constrained to the directional area.</span></span>

```XAML
<StackPanel Orientation="Horizontal">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
            <Button Content="A" />
            <Button Content="B" />
            <Button Content="C" />
      </StackPanel>
      <Button Content="D" />
</StackPanel>
```

#### <a name="override-directional-navigation"></a><span data-ttu-id="9b523-125">方向ナビゲーションを上書きする</span><span class="sxs-lookup"><span data-stu-id="9b523-125">Override directional navigation</span></span>

<span data-ttu-id="9b523-126">既定のナビゲーション動作を上書きするには、XYFocusRight/XYFocusLeft/XYFocusTop/XYFocusDown プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="9b523-126">Use the XYFocusRight/XYFocusLeft/XYFocusTop/XYFocusDown properties to override the default navigation behaviors.</span></span>

<span data-ttu-id="9b523-127">以下に、方向領域内に含まれている 3 つのボタン (A、B、C) と方向領域の外側にある 4 つ目のボタン (D) を示す、前の例と同じ図を示します。</span><span class="sxs-lookup"><span data-stu-id="9b523-127">Here’s the same image as the previous example showing three buttons (A, B, and C) contained within a directional area and a fourth button (D) outside the directional area.</span></span>

![方向領域](images/keyboard/directional-area.png)

*<span data-ttu-id="9b523-129">キーボードの方向キーは、A-B-C ボタンの間でフォーカスを移動し、D に出ていくことができる</span><span class="sxs-lookup"><span data-stu-id="9b523-129">Keyboard arrow keys can move focus between the buttons A-B-C, and out to D</span></span>*

<span data-ttu-id="9b523-130">このコード例は、方向領域の外側にあるコントロールに移動できるようにすることで、右方向キーの既定のナビゲーション動作を上書きする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-130">This code example demonstrates how to override the default navigation behavior for the Right arrow key by allowing it to navigate to a control outside the directional area.</span></span> <span data-ttu-id="9b523-131">左方向キーを使って方向領域に再度入ることはできない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="9b523-131">Note that the directional area cannot be re-entered using the left arrow key.</span></span>

```XAML
<StackPanel Orientation="Horizontal">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
            <Button Content="A" />
            <Button Content="B" />
            <Button Content="C" XYFocusRight="{x:Bind ButtonD}" />
      </StackPanel>
      <Button Content="D" x:Name="ButtonD"/>
</StackPanel>
```

<span data-ttu-id="9b523-132">詳しくは、このトピックの方向の「[XYFocus ナビゲーション方法](#set-the-tab-navigation-behavior)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9b523-132">For more detail, see [XYFocus Navigation Strategies](#set-the-tab-navigation-behavior) later in this topic.</span></span>

#### <a name="restrict-navigation-with-disabled"></a><span data-ttu-id="9b523-133">Disabled によってナビゲーションを制限する</span><span class="sxs-lookup"><span data-stu-id="9b523-133">Restrict navigation with Disabled</span></span>

<span data-ttu-id="9b523-134">方向キー ナビゲーションを方向領域内に制限するには、**XYFocusKeyboardNavigation** を **Disabled** に設定します。</span><span class="sxs-lookup"><span data-stu-id="9b523-134">Set **XYFocusKeyboardNavigation** to **Disabled** to restrict arrow key navigation within a directional area.</span></span>

<span data-ttu-id="9b523-135">**注** このプロパティを設定しても、コントロールへのキーボード ナビゲーション自体には影響を与えず、コントロールの子要素だけに影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="9b523-135">**NOTE** Setting this property to does affect keyboard navigation to the control itself, just the control’s child elements.</span></span>

<span data-ttu-id="9b523-136">次のコード例では、親 StackPanel の **XYFocusKeyboardNavigation** が **Enabled** に設定され、子要素 C の **XYFocusKeyboardNavigation** が **Disabled** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="9b523-136">In the following code example, the parent StackPanel has **XYFocusKeyboardNavigation** set to **Enabled** and the child element, C, has **XYFocusKeyboardNavigation** set to **Disabled**.</span></span> <span data-ttu-id="9b523-137">C の子要素でのみ方向キー ナビゲーションが無効になっています。</span><span class="sxs-lookup"><span data-stu-id="9b523-137">Only the child elements of C have arrow key navigation disabled.</span></span>

```XAML
<StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
        <Button Content="A" />
        <Button Content="B" />
        <Button Content="C" XYFocusKeyboardNavigation="Disabled" >
            ...
        </Button>
</StackPanel>
```

#### <a name="use-nested-directional-areas"></a><span data-ttu-id="9b523-138">入れ子になった方向領域を使う</span><span class="sxs-lookup"><span data-stu-id="9b523-138">Use nested directional areas</span></span>

<span data-ttu-id="9b523-139">入れ子になった方向領域を複数レベル設定することができます。</span><span class="sxs-lookup"><span data-stu-id="9b523-139">You can have multiple levels of nested directional areas.</span></span> <span data-ttu-id="9b523-140">すべての親要素の **XYFocusKeyboardNavigation** が **Enabled** に設定されている場合、領域の境界は方向キー ナビゲーションによって無視されます。</span><span class="sxs-lookup"><span data-stu-id="9b523-140">If all parent elements have **XYFocusKeyboardNavigation** set to **Enabled**, region boundaries are ignored by arrow key navigation.</span></span>

<span data-ttu-id="9b523-141">次の図は、入れ子になっている方向領域内に含まれる 3 つのボタン (A、B、C) と、方向領域の外側にある 4 つ目のボタン (D) を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-141">Here’s an image showing three buttons (A, B, and C) contained within a nested directional area and a fourth button (D) outside the directional area.</span></span>

![入れ子になった方向領域](images/keyboard/nested-directional-area.png)

*<span data-ttu-id="9b523-143">キーボードの方向キーは、ボタン A-B-C 間でフォーカスを移動できますが、D には移動できません。</span><span class="sxs-lookup"><span data-stu-id="9b523-143">Keyboard arrow keys can move focus between the buttons A-B-C, but not D</span></span>*

<span data-ttu-id="9b523-144">このコード例は、入れ子になった方向領域が領域の境界を越えた方向キー ナビゲーションをサポートするように指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-144">This code example demonstrates how to specify that nested directional areas support arrow key navigation across region boundaries.</span></span>

```XAML
<StackPanel Orientation="Horizontal">
        <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
            <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
                <Button Content="A" />
                <Button Content="B" />
            </StackPanel>
            <Button Content="C" />
        </StackPanel>
        <Button Content="D" />
 </StackPanel>
```

<span data-ttu-id="9b523-145">次の図は、A と B が入れ子になった方向領域に含まれていて、C と D が別の領域に含まれている 4 つのボタン (A、B、C、D) を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-145">Here’s an image showing four buttons (A, B, C, and D) where A and B are contained within a nested directional area, and C and D are contained within a different area.</span></span> <span data-ttu-id="9b523-146">親要素の **XYFocusKeyboardNavigation** が **Disabled** に設定されているため、方向キーを使って入れ子になった各領域の境界を超えることはできません。</span><span class="sxs-lookup"><span data-stu-id="9b523-146">As the parent element has **XYFocusKeyboardNavigation** set to **Disabled**, the boundary of each nested area cannot be crossed using the arrow keys.</span></span>

![非方向領域](images/keyboard/non-directional-area.png)

*<span data-ttu-id="9b523-148">キーボードの方向キーでは、A ボタンと B ボタンの間および C ボタンと D ボタンの間はフォーカスを移動できますが、領域間は移動できません。</span><span class="sxs-lookup"><span data-stu-id="9b523-148">Keyboard arrow keys can move focus between buttons A-B and between buttons C-D, but not between regions</span></span>*

<span data-ttu-id="9b523-149">このコード例は、入れ子になった方向領域が領域の境界を越えた方向キー ナビゲーションをサポートしないように指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-149">This code example demonstrates how to specify nested directional areas that do not support arrow key navigation across region boundaries.</span></span>

```XAML
<StackPanel Orientation="Horizontal">
  <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
    <Button Content="A" />
    <Button Content="B" />
  </StackPanel>
  <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
    <Button Content="C" />
    <Button Content="D" />
  </StackPanel>
</StackPanel>
```

<span data-ttu-id="9b523-150">入れ子になった方向領域のより複雑な例は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9b523-150">Here’s a more complex example of nested directional areas where:</span></span>

-   <span data-ttu-id="9b523-151">A にフォーカスがある場合、方向キーによって B、C、D に移動できない非方向領域の境界が存在するため、E にのみ移動できる (その逆も同様)</span><span class="sxs-lookup"><span data-stu-id="9b523-151">if A has focus, only E can be navigated to (and vice versa) because there is a non-directional area boundary that makes B, C, and D unreachable with the arrow keys</span></span>
-   <span data-ttu-id="9b523-152">B にフォーカスがある場合、D は方向領域の外側にあり、非方向領域の境界によって A と E へのアクセスがブロックされるため、C にのみ移動できる (その逆も同様)</span><span class="sxs-lookup"><span data-stu-id="9b523-152">If B has focus, only C can be navigated to (and vice versa) because D is outside the directional area and the non-directional area boundary blocks access to A and E</span></span>
-   <span data-ttu-id="9b523-153">D にフォーカスがある場合、方向キー ナビゲーションが不可能なため、コントロール間を移動するには Tab キーを使う必要がある</span><span class="sxs-lookup"><span data-stu-id="9b523-153">If D has focus, the Tab key must be used to navigate between controls as arrow key navigation is not possible</span></span>

![入れ子になった非方向領域](images/keyboard/nested-non-directional-area.png)

*<span data-ttu-id="9b523-155">キーボードの方向キーでは、A ボタンと E ボタンの間および B ボタンと C ボタンの間はフォーカスを移動できますが、他の領域間は移動できません。</span><span class="sxs-lookup"><span data-stu-id="9b523-155">Keyboard arrow keys can move focus between buttons A-E and between buttons B-C, but not between other regions</span></span>*

<span data-ttu-id="9b523-156">このコード例は、入れ子になった方向領域が領域の境界を越えた複雑な方向キー ナビゲーションをサポートするように指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-156">This code example demonstrates how to specify nested directional areas that support complex arrow key navigation across region boundaries.</span></span>

```XAML
<StackPanel  Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
  <Button Content="A" />
    <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Disabled">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
        <Button Content="B" />
        <Button Content="C" />
      </StackPanel>
        <Button Content="D" />
    </StackPanel>
  <Button Content="E" />
</StackPanel>
```

## <a name="set-the-tab-navigation-behavior-a-nametab-navigation"></a><span data-ttu-id="9b523-157">タブ ナビゲーションの動作を設定する <a name="tab-navigation"></span><span class="sxs-lookup"><span data-stu-id="9b523-157">Set the tab navigation behavior <a name="tab-navigation"></span></span>

<span data-ttu-id="9b523-158">UIElement.[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) プロパティは、そのオブジェクト ツリー全体 (または方向領域) のタブ ナビゲーションの動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="9b523-158">The UIElement.[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) property specifies the tab navigation behavior for its entire object tree (or directional area).</span></span>

<span data-ttu-id="9b523-159">[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) には、**TabFocusNavigationMode** 型の値があります。指定可能な値は、**Once**、**Cycle**、**Local** (既定) です。</span><span class="sxs-lookup"><span data-stu-id="9b523-159">[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) has a value of type **TabFocusNavigationMode** with possible values of **Once**, **Cycle,** **or Local** (default).</span></span>

<span data-ttu-id="9b523-160">次の図では、方向領域のタブ ナビゲーションに応じて次の順序でフォーカスが移動します。</span><span class="sxs-lookup"><span data-stu-id="9b523-160">In the following image, depending on the tab navigation of the directional area, focus is moved in the following ways:</span></span>

-   <span data-ttu-id="9b523-161">Once: A、B1、C、A</span><span class="sxs-lookup"><span data-stu-id="9b523-161">Once: A, B1, C, A</span></span>
-   <span data-ttu-id="9b523-162">Local: A、B1、B2、B3、B4、B5、C、A</span><span class="sxs-lookup"><span data-stu-id="9b523-162">Local: A, B1, B2, B3, B4, B5, C, A</span></span>
-   <span data-ttu-id="9b523-163">Cycle: A、B1、B2、B3、B4、B5、B1、B2、B3、B4、B5、(B を順番に切り替え)</span><span class="sxs-lookup"><span data-stu-id="9b523-163">Cycle: A, B1, B2, B3, B4, B5, B1, B2, B3, B4, B5, (cycling on B’s)</span></span>

![タブ ナビゲーション](images/keyboard/tab-navigation.png)

*<span data-ttu-id="9b523-165">タブ ナビゲーション モードに基づくフォーカスの動作</span><span class="sxs-lookup"><span data-stu-id="9b523-165">Focus behavior based on tab navigation mode</span></span>*

<span data-ttu-id="9b523-166">次のコード例は、Once モードでの TabFocusNavigation の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="9b523-166">The following code example demonstrates using TabFocusNavigation with a mode of Once.</span></span>

```XAML
<Button Content="X" Click="OnAClick"/>
<StackPanel Orientation="Horizontal" XYFocusNavigation ="Local"
   TabFocusNavigation ="Local">
   <Button Content="A" Click="OnAClick"/>
   <StackPanel Orientation="Horizontal" TabFocusNavigation ="Once">
        <Button Content="B" Click="OnBClick"/>
        <Button Content="C" Click="OnCClick"/>
        <Button Content="D" Click="OnDClick"/>
   </StackPanel>
   <Button Content="E" Click="OnBClick"/>
</StackPanel>
```

*<span data-ttu-id="9b523-167">フォーカスが X にある場合のタブ ナビゲーションは A、B、E、X</span><span class="sxs-lookup"><span data-stu-id="9b523-167">The Tab Navigation when focus is on X is: A,B,E,X</span></span>*

#### <a name="about-tabfocusnavigation-and-tabindex"></a><span data-ttu-id="9b523-168">TabFocusNavigation と TabIndex について</span><span class="sxs-lookup"><span data-stu-id="9b523-168">About TabFocusNavigation and TabIndex</span></span>

<span data-ttu-id="9b523-169">UIElement.TabFocusNavigation プロパティは、TabIndex の処理を含め、Control.TabNavigation プロパティと同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="9b523-169">The UIElement.TabFocusNavigation property has the same behavior as the Control.TabNavigation property, including how it works with TabIndex.</span></span>

<span data-ttu-id="9b523-170">コントロールで TabIndex が指定されていない場合、フレームワークは現在の最大インデックス値 (および優先順位が最も低い) よりも大きいインデックス値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="9b523-170">When a control has no TabIndex specified, the framework assigns it a higher index value than the current highest index value (and the lowest priority).</span></span> <span data-ttu-id="9b523-171">ビジュアル ツリーの最初の要素を選ぶことによりあいまいさが解決されます。</span><span class="sxs-lookup"><span data-stu-id="9b523-171">It resolves the ambiguate by choosing the first element on the visual tree.</span></span> <span data-ttu-id="9b523-172">フレームワークは、スコープごとにタブ インデックスを解決します。</span><span class="sxs-lookup"><span data-stu-id="9b523-172">The framework resolves Tab indexes per scope.</span></span> <span data-ttu-id="9b523-173">コントロールの子はスコープと見なされ、そのいずれかの子に子がある場合、別のスコープの一部と見なされます。</span><span class="sxs-lookup"><span data-stu-id="9b523-173">The children of a control are considered a scope, and if one of this child has children, those are part of another scope.</span></span>

<span data-ttu-id="9b523-174">次の図では、方向領域のタブ ナビゲーションと要素のタブ インデックスに応じて、フォーカスが次の順序で移動します。</span><span class="sxs-lookup"><span data-stu-id="9b523-174">In the following image, depending on the tab navigation of the directional area and the tab index of the elements, focus is moved in the following ways:</span></span>

-   <span data-ttu-id="9b523-175">Once: A、B3、C、A</span><span class="sxs-lookup"><span data-stu-id="9b523-175">Once: A, B3, C, A.</span></span>
-   <span data-ttu-id="9b523-176">Local: A、B3、B4、B5、B1、B2、C、A</span><span class="sxs-lookup"><span data-stu-id="9b523-176">Local: A, B3, B4, B5, B1, B2, C, A.</span></span>
-   <span data-ttu-id="9b523-177">Cycle: A、B3、B4、B5、B1、B2、B3、B4、B5、B1、B2、(B を順番に切り替え)</span><span class="sxs-lookup"><span data-stu-id="9b523-177">Cycle: A, B3, B4, B5, B1, B2, B3, B4, B5, B1, B2, (cycling on B’s)</span></span>

![タブ インデックス](images/keyboard/tab-index.png)

*<span data-ttu-id="9b523-179">タブ ナビゲーション モードとタブ インデックスに基づくフォーカスの動作</span><span class="sxs-lookup"><span data-stu-id="9b523-179">Focus behavior based on tab navigation mode and tab indexes</span></span>*

<span data-ttu-id="9b523-180">方向領域がどのようにスコープと見なされ、優先度が最も高いコントロール (B3) にフォーカス ナビゲーションがどのように移動するかに注目してください。</span><span class="sxs-lookup"><span data-stu-id="9b523-180">Notice how the directional area is considered a scope and how focus navigation moves to the control with the highest priority first: B3.</span></span> <span data-ttu-id="9b523-181">実際には、A、方向領域、C のスコープと、方向領域のスコープの 2 つのスコープがあります。</span><span class="sxs-lookup"><span data-stu-id="9b523-181">In fact, there are two scopes: One for A, Directional Area, and C. And another for the Directional area.</span></span> <span data-ttu-id="9b523-182">方向の領域は TabStop ではないため、フレームワークはスコープを切り替えて最適な候補を探し、子要素を再帰的に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="9b523-182">Because the directional area is not a TabStop, the framework switches the scope to look for the best candidate, and then recursively through any child elements.</span></span>
