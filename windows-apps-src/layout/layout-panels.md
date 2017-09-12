---
author: Jwmsft
Description: "レイアウト パネルを使って、アプリの UI 要素を配置し、グループ化します。"
title: "ユニバーサル Windows プラットフォーム (UWP) アプリのレイアウト パネル"
ms.assetid: 07A7E022-EEE9-4C81-AF07-F80868665994
label: Layout panels
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 55b7c431482b171e56e670cd5d2ce0fc9148a5f9
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="layout-panels"></a><span data-ttu-id="f7d19-104">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="f7d19-104">Layout panels</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="f7d19-105">レイアウト パネルを使って、アプリの UI 要素を配置およびグループ化します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-105">You use layout panels to arrange and group UI elements in your app.</span></span> <span data-ttu-id="f7d19-106">組み込みの XAML レイアウト パネルには、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)、[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-106">The built-in XAML layout panels include [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx), [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx), [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx), [**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx), and [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx).</span></span> <span data-ttu-id="f7d19-107">ここでは、各パネルについて説明し、パネルを使って XAML UI 要素をレイアウトする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-107">Here, we describe each panel and show how to use it to layout XAML UI elements.</span></span>

<span data-ttu-id="f7d19-108">レイアウト パネルを選ぶときに考慮する事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-108">There are several things to consider when choosing a layout panel:</span></span>
- <span data-ttu-id="f7d19-109">パネルに子要素がどのように配置されるか。</span><span class="sxs-lookup"><span data-stu-id="f7d19-109">How the panel positions its child elements.</span></span>
- <span data-ttu-id="f7d19-110">パネルで子要素のサイズがどのように変更されるか。</span><span class="sxs-lookup"><span data-stu-id="f7d19-110">How the panel sizes its child elements.</span></span>
- <span data-ttu-id="f7d19-111">重複する子要素をお互いに重ねる方法 (z オーダー)。</span><span class="sxs-lookup"><span data-stu-id="f7d19-111">How overlapping child elements are layered on top of each other (z-order).</span></span>
- <span data-ttu-id="f7d19-112">目的のレイアウトの作成に必要な、入れ子になったパネル要素の数と複雑さ。</span><span class="sxs-lookup"><span data-stu-id="f7d19-112">The number and complexity of nested panel elements needed to create your desired layout.</span></span>


**<span data-ttu-id="f7d19-113">パネルの添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="f7d19-113">Panel attached properties</span></span>**

<span data-ttu-id="f7d19-114">多くの XAML レイアウト パネルでは添付プロパティを使用して、子要素がどのように UI に表示される必要があるかについて親パネルに通知できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-114">Most XAML layout panels use attached properties to let their child elements inform the parent panel about how they should be positioned in the UI.</span></span> <span data-ttu-id="f7d19-115">添付プロパティでは、*AttachedPropertyProvider.PropertyName* という構文が使用されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-115">Attached properties use the syntax *AttachedPropertyProvider.PropertyName*.</span></span> <span data-ttu-id="f7d19-116">パネルを他のパネルに入れ子にする場合、親に対するレイアウト属性を指定する UI 要素の添付プロパティは、最も近い親パネルによってのみ解釈されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-116">If you have panels that are nested inside other panels, attached properties on UI elements that specify layout characteristics to a parent are interpreted by the most immediate parent panel only.</span></span>

<span data-ttu-id="f7d19-117">XAML で Button コントロールの [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) 添付プロパティを設定する方法の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-117">Here is an example of how you can set the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) attached property on a Button control in XAML.</span></span> <span data-ttu-id="f7d19-118">これにより、親 Canvas に、Button を Canvas の左端から 50 有効ピクセルの位置に配置する必要があることを通知します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-118">This informs the parent Canvas that the Button should be positioned 50 effective pixels from the left edge of the Canvas.</span></span>

```xaml
<Canvas>
  <Button Canvas.Left="50">Hello</Button>
</Canvas>
```

<span data-ttu-id="f7d19-119">添付プロパティについて詳しくは、「[添付プロパティの概要](../xaml-platform/attached-properties-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f7d19-119">For more info about attached properties, see [Attached properties overview](../xaml-platform/attached-properties-overview.md).</span></span>

> <span data-ttu-id="f7d19-120">**注**&nbsp;&nbsp;添付プロパティは、コードから取得または設定するための特別な構文を必要とする XAML の概念です。</span><span class="sxs-lookup"><span data-stu-id="f7d19-120">**Note**&nbsp;&nbsp;An attached property is a XAML concept that requires special syntax to get or set from code.</span></span> <span data-ttu-id="f7d19-121">コードで添付プロパティを使用するには、「*添付プロパティの概要*」の「*コードでの添付プロパティ*」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f7d19-121">To use attached properties in code, see the *Attached properties in code* section of the *Attached properties overview* article.</span></span>

**<span data-ttu-id="f7d19-122">パネルの境界線</span><span class="sxs-lookup"><span data-stu-id="f7d19-122">Panel borders</span></span>**

<span data-ttu-id="f7d19-123">RelativePanel、StackPanel、Grid の各パネルには境界線プロパティが定義されており、別の Border 要素でラップすることなく、パネルの周囲に境界線を描画できます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-123">The RelativePanel, StackPanel, and Grid panels define border properties that let you draw a border around the panel without wrapping them in an additional Border element.</span></span> <span data-ttu-id="f7d19-124">境界線プロパティには、**BorderBrush**、**BorderThickness**、**CornerRadius**、**Padding** があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-124">The border properties are **BorderBrush**, **BorderThickness**, **CornerRadius**, and **Padding**.</span></span>

<span data-ttu-id="f7d19-125">Grid で境界線プロパティを設定する例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-125">Here’s an example of how to set border properties on a Grid.</span></span>

```xaml
<Grid BorderBrush="Blue" BorderThickness="12" CornerRadius="12" Padding="12">
    <TextBlock Text="Hello World!"/>
</Grid>
```

![境界線を持つグリッド](images/layout-panel-grid-border.png)

<span data-ttu-id="f7d19-127">組み込みの境界線のプロパティを使うことによって、XAML 要素の数を減らし、アプリの UI のパフォーマンスを向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-127">Using the built-in border properties reduces the XAML element count, which can improve the UI performance of your app.</span></span> <span data-ttu-id="f7d19-128">レイアウト パネルと UI のパフォーマンスについて詳しくは、「[XAML レイアウトの最適化](https://msdn.microsoft.com/en-us/library/windows/apps/mt404609.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f7d19-128">For more info about layout panels and UI performance, see [Optimize your XAML layout](https://msdn.microsoft.com/en-us/library/windows/apps/mt404609.aspx).</span></span>

## <a name="relativepanel"></a><span data-ttu-id="f7d19-129">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-129">RelativePanel</span></span>

<span data-ttu-id="f7d19-130">[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) では、他の要素やパネルを基準として UI 要素を配置する場所を指定することにより、UI 要素をレイアウトすることができます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-130">[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) lets you layout UI elements by specifying where they go in relation to other elements and in relation to the panel.</span></span> <span data-ttu-id="f7d19-131">既定では、要素はパネルの左上隅に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-131">By default, an element is positioned in the upper left corner of the panel.</span></span> <span data-ttu-id="f7d19-132">RelativePanel を、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) や [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) と共に使用して、さまざまなウィンドウ サイズに合わせて UI を配置し直すことができます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-132">You can use RelativePanel with a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) and [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx)s to rearrange your UI for different window sizes.</span></span>

<span data-ttu-id="f7d19-133">次の表に、要素をパネルの端や中央に揃えたり、他の要素を基準として要素を揃えて配置したりするために使用できる添付プロパティを示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-133">This table shows the attached properties you can use to align an element with the edge or center of the panel, and align and position it in relation to other elements.</span></span>

<span data-ttu-id="f7d19-134">パネルの配置</span><span class="sxs-lookup"><span data-stu-id="f7d19-134">Panel alignment</span></span> | <span data-ttu-id="f7d19-135">兄弟の配置</span><span class="sxs-lookup"><span data-stu-id="f7d19-135">Sibling alignment</span></span> | <span data-ttu-id="f7d19-136">兄弟の位置</span><span class="sxs-lookup"><span data-stu-id="f7d19-136">Sibling position</span></span>
----------------|-------------------|-----------------
[**<span data-ttu-id="f7d19-137">AlignTopWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-137">AlignTopWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aligntopwithpanel.aspx) | [**<span data-ttu-id="f7d19-138">AlignTopWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-138">AlignTopWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aligntopwith.aspx) | [**<span data-ttu-id="f7d19-139">Above</span><span class="sxs-lookup"><span data-stu-id="f7d19-139">Above</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.above.aspx)  
[**<span data-ttu-id="f7d19-140">AlignBottomWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-140">AlignBottomWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignbottomwithpanel.aspx) | [**<span data-ttu-id="f7d19-141">AlignBottomWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-141">AlignBottomWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignbottomwith.aspx) | [**<span data-ttu-id="f7d19-142">Below</span><span class="sxs-lookup"><span data-stu-id="f7d19-142">Below</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.below.aspx)  
[**<span data-ttu-id="f7d19-143">AlignLeftWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-143">AlignLeftWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignleftwithpanel.aspx) | [**<span data-ttu-id="f7d19-144">AlignLeftWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-144">AlignLeftWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignleftwith.aspx) | [**<span data-ttu-id="f7d19-145">LeftOf</span><span class="sxs-lookup"><span data-stu-id="f7d19-145">LeftOf</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.leftof.aspx)  
[**<span data-ttu-id="f7d19-146">AlignRightWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-146">AlignRightWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignrightwithpanel.aspx) | [**<span data-ttu-id="f7d19-147">AlignRightWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-147">AlignRightWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignrightwith.aspx) | [**<span data-ttu-id="f7d19-148">RightOf</span><span class="sxs-lookup"><span data-stu-id="f7d19-148">RightOf</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.rightof.aspx)  
[**<span data-ttu-id="f7d19-149">AlignHorizontalCenterWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-149">AlignHorizontalCenterWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) | [**<span data-ttu-id="f7d19-150">AlignHorizontalCenterWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-150">AlignHorizontalCenterWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwith.aspx) | &nbsp;   
[**<span data-ttu-id="f7d19-151">AlignVerticalCenterWithPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-151">AlignVerticalCenterWithPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignverticalcenterwithpanel.aspx) | [**<span data-ttu-id="f7d19-152">AlignVerticalCenterWith</span><span class="sxs-lookup"><span data-stu-id="f7d19-152">AlignVerticalCenterWith</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignverticalcenterwith.aspx) | &nbsp;   

 
<span data-ttu-id="f7d19-153">次の XAML は、RelativePanel で要素を配置する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-153">This XAML shows how to arrange elements in a RelativePanel.</span></span>

```xaml
<RelativePanel BorderBrush="Gray" BorderThickness="1">
    <Rectangle x:Name="RedRect" Fill="Red" Height="44" Width="44"/>
    <Rectangle x:Name="BlueRect" Fill="Blue"
               Height="44" Width="88"
               RelativePanel.RightOf="RedRect" />

    <Rectangle x:Name="GreenRect" Fill="Green" 
               Height="44"
               RelativePanel.Below="RedRect" 
               RelativePanel.AlignLeftWith="RedRect" 
               RelativePanel.AlignRightWith="BlueRect"/>
    <Rectangle Fill="Orange"
               RelativePanel.Below="GreenRect" 
               RelativePanel.AlignLeftWith="BlueRect" 
               RelativePanel.AlignRightWithPanel="True"
               RelativePanel.AlignBottomWithPanel="True"/>
</RelativePanel>
```

<span data-ttu-id="f7d19-154">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-154">The result looks like this.</span></span> 

![RelativePanel](images/layout-panel-relative-panel.png)

<span data-ttu-id="f7d19-156">長方形のサイズについて、注意が必要な点をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-156">Here are a few thing to note about the sizing of the rectangles.</span></span>
- <span data-ttu-id="f7d19-157">赤色の長方形には、明示的なサイズとして 44 x 44 が指定されています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-157">The red rectangle is given an explicit size of 44x44.</span></span> <span data-ttu-id="f7d19-158">この要素はパネルの左上隅に配置されます。これは既定の位置です。</span><span class="sxs-lookup"><span data-stu-id="f7d19-158">It's placed in the upper left corner of the panel, which is the default position.</span></span>
- <span data-ttu-id="f7d19-159">緑色の四角形には、明示的な高さとして 44 が指定されています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-159">The green rectangle is given an explicit height of 44.</span></span> <span data-ttu-id="f7d19-160">この長方形の左端は赤色の長方形に揃えられ、その右端は青色の長方形と揃えられています。これにより、この長方形の幅が決まります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-160">Its left side is aligned with the red rectangle, and its right side is aligned with the blue rectangle, which determines its width.</span></span>
- <span data-ttu-id="f7d19-161">オレンジ色の長方形には、明示的なサイズは指定されていません。</span><span class="sxs-lookup"><span data-stu-id="f7d19-161">The orange rectangle isn't given an explicit size.</span></span> <span data-ttu-id="f7d19-162">この長方形の左端は青色の長方形に揃えられます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-162">Its left side is aligned with the blue rectangle.</span></span> <span data-ttu-id="f7d19-163">右端と下端はパネルの端に揃えられます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-163">Its right and bottom edges are aligned with the edge of the panel.</span></span> <span data-ttu-id="f7d19-164">この長方形のサイズはこれらの配置によって決まり、パネルのサイズが変更されると、長方形のサイズも変更されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-164">Its size is determined by these alignments and it will resize as the panel resizes.</span></span>

## <a name="stackpanel"></a><span data-ttu-id="f7d19-165">StackPanel</span><span class="sxs-lookup"><span data-stu-id="f7d19-165">StackPanel</span></span>

<span data-ttu-id="f7d19-166">[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) は、子要素が単一の行に水平方向または垂直方向に配置される単純なレイアウト パネルです。</span><span class="sxs-lookup"><span data-stu-id="f7d19-166">[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) is a simple layout panel that arranges its child elements into a single line that can be oriented horizontally or vertically.</span></span> <span data-ttu-id="f7d19-167">StackPanel は通常、ページ上に UI の小さなサブセクションを配置する場合に使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-167">StackPanel controls are typically used in scenarios where you want to arrange a small subsection of the UI on your page.</span></span>

<span data-ttu-id="f7d19-168">子要素を並べる向きを指定するには、[**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.orientation.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-168">You can use the [**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.orientation.aspx) property to specify the direction of the child elements.</span></span> <span data-ttu-id="f7d19-169">既定の向きは [**Vertical**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.orientation.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="f7d19-169">The default orientation is [**Vertical**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.orientation.aspx).</span></span>

<span data-ttu-id="f7d19-170">次の XAML は、項目の垂直方向の StackPanel を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-170">The following XAML shows how to create a vertical StackPanel of items.</span></span>

```xaml
<StackPanel>
    <Rectangle Fill="Red" Height="44"/>
    <Rectangle Fill="Blue" Height="44"/>
    <Rectangle Fill="Green" Height="44"/>
    <Rectangle Fill="Orange" Height="44"/>
</StackPanel>
```


<span data-ttu-id="f7d19-171">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-171">The result looks like this.</span></span>

![StackPanel](images/layout-panel-stack-panel.png)

<span data-ttu-id="f7d19-173">StackPanel では、子要素のサイズを明示的に設定しない場合、利用可能な幅 (Orientation が **Horizontal** の場合は高さ) いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-173">In a StackPanel, if a child element's size is not set explicitly, it stretches to fill the available width (or height if the Orientation is **Horizontal**).</span></span> <span data-ttu-id="f7d19-174">この例では、長方形の幅は設定されていません。</span><span class="sxs-lookup"><span data-stu-id="f7d19-174">In this example, the width of the rectangles is not set.</span></span> <span data-ttu-id="f7d19-175">長方形は、StackPanel の幅いっぱいに拡張されています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-175">The rectangles expand to fill the entire width of the StackPanel.</span></span>

## <a name="grid"></a><span data-ttu-id="f7d19-176">Grid</span><span class="sxs-lookup"><span data-stu-id="f7d19-176">Grid</span></span>

<span data-ttu-id="f7d19-177">[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) パネルは、複数行および段組レイアウトでのコントロールの配置をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-177">The [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) panel supports arranging controls in multi-row and multi-column layouts.</span></span> <span data-ttu-id="f7d19-178">[**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowdefinitions.aspx) プロパティと [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columndefinitions.aspx) プロパティを使うことによって、Grid パネルの行と列を指定できます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-178">You can specify a Grid panel's rows and columns by using the [**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowdefinitions.aspx) and [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columndefinitions.aspx) properties.</span></span> <span data-ttu-id="f7d19-179">XAML では、プロパティ要素構文を使用して、Grid 要素内の行と列を宣言します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-179">In XAML, use property element syntax to declare the rows and columns within the Grid element.</span></span> <span data-ttu-id="f7d19-180">**Auto** サイズ変更またはスター サイズ指定を使うと、列または行内でスペースを分散できます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-180">You can distribute space within a column or a row by using **Auto** or star sizing.</span></span>

<span data-ttu-id="f7d19-181">オブジェクトを Grid の特定のセルに配置するには、[**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.column.aspx) 添付プロパティと [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.row.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-181">You position objects in specific cells of the Grid by using the [**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.column.aspx) and [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.row.aspx) attached properties.</span></span>

<span data-ttu-id="f7d19-182">複数の行や列をまたいでコンテンツを表示するには、[**Grid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowspan.aspx) 添付プロパティと [**Grid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columnspan.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-182">You can make content span across multiple rows and columns by using the [**Grid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowspan.aspx) and [**Grid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columnspan.aspx) attached properties.</span></span>

<span data-ttu-id="f7d19-183">次の XAML の例では、2 つの行と 2 つの列を持つ Grid を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-183">This XAML example shows how to create a Grid with two rows and two columns.</span></span>

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition Height="44"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Rectangle Fill="Red" Width="44"/>
    <Rectangle Fill="Blue" Grid.Row="1"/>
    <Rectangle Fill="Green" Grid.Column="1"/>
    <Rectangle Fill="Orange" Grid.Row="1" Grid.Column="1"/>
</Grid>
```


<span data-ttu-id="f7d19-184">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-184">The result looks like this.</span></span>

![Grid](images/layout-panel-grid.png)

<span data-ttu-id="f7d19-186">この例では、サイズ設定は次のように行われます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-186">In this example, the sizing works like this:</span></span> 
- <span data-ttu-id="f7d19-187">2 番目の行には、明示的に 44 有効ピクセルの高さが指定されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-187">The second row has an explicit height of 44 effective pixels.</span></span> <span data-ttu-id="f7d19-188">既定では、最初の行の高さは、残っているスペースいっぱいになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-188">By default, the height of the first row fills whatever space is left over.</span></span>
- <span data-ttu-id="f7d19-189">最初の列の幅は **Auto** に設定されているため、その子に必要な幅になります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-189">The width of the first column is set to **Auto**, so it's as wide as needed for its children.</span></span> <span data-ttu-id="f7d19-190">この例では、赤色の長方形の幅に対応するために、その幅は 44 有効ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-190">In this case, it's 44 effective pixels wide to accommodate the width of the red rectangle.</span></span>
- <span data-ttu-id="f7d19-191">長方形に対してその他のサイズの制約はないため、各長方形は配置されているグリッドのセルいっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-191">There are no other size constraints on the rectangles, so each one stretches to fill the grid cell it's in.</span></span>

## <a name="variablesizedwrapgrid"></a><span data-ttu-id="f7d19-192">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="f7d19-192">VariableSizedWrapGrid</span></span>

<span data-ttu-id="f7d19-193">[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) は、要素が複数行、複数列に配置されるグリッド スタイルのレイアウト パネルです。このパネルでは、[**MaximumRowsOrColumns**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.maximumrowsorcolumns.aspx) 値に達すると新しい行または列に自動的に折り返して配置されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-193">[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) provides a grid-style layout panel where elements are arranged in rows or columns that automatically wrap to a new row or column when the [**MaximumRowsOrColumns**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.maximumrowsorcolumns.aspx) value is reached.</span></span> 

<span data-ttu-id="f7d19-194">[**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.orientation.aspx) プロパティは、折り返す前にグリッドの行と列のどちらの向きに項目を追加するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-194">The [**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.orientation.aspx) property specifies whether the grid adds its items in rows or columns before wrapping.</span></span> <span data-ttu-id="f7d19-195">既定の向きは **Vertical** で、グリッドの項目は上から下へ列がいっぱいになるまで追加された後、新しい列に折り返されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-195">The default orientation is **Vertical**, which means the grid adds items from top to bottom until a column is full, then wraps to a new column.</span></span> <span data-ttu-id="f7d19-196">この値が **Horizontal** の場合は、グリッドの項目は左から右に追加され、新しい行に折り返されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-196">When the value is **Horizontal**, the grid adds items from left to right, then wraps to a new row.</span></span>

<span data-ttu-id="f7d19-197">セルのサイズは、[**ItemHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemheight.aspx) と [**ItemWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemwidth.aspx) で指定します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-197">Cell dimensions are specified by the [**ItemHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemheight.aspx) and [**ItemWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemwidth.aspx).</span></span> <span data-ttu-id="f7d19-198">各セルは同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="f7d19-198">Each cell is the same size.</span></span> <span data-ttu-id="f7d19-199">ItemHeight または ItemWidth が指定されていない場合、最初のセルのサイズがそのコンテンツに合わせて変更され、その他の各セルは最初のセルのサイズになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-199">If ItemHeight or ItemWidth is not specified, then the first cell sizes to fit its content, and every other cell is the size of the first cell.</span></span>

<span data-ttu-id="f7d19-200">子要素が配置される隣接セルの数を指定するには、[**VariableSizedWrapGrid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.columnspan.aspx) 添付プロパティと [**VariableSizedWrapGrid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.rowspan.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-200">You can use the [**VariableSizedWrapGrid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.columnspan.aspx) and [**VariableSizedWrapGrid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.rowspan.aspx) attached properties to specify how many adjacent cells a child element should fill.</span></span>

<span data-ttu-id="f7d19-201">XAML での VariableSizedWrapGrid の使い方を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-201">Here's how to use a VariableSizedWrapGrid in XAML.</span></span>

```xaml
<VariableSizedWrapGrid MaximumRowsOrColumns="3" ItemHeight="44" ItemWidth="44">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" 
               VariableSizedWrapGrid.RowSpan="2"/>
    <Rectangle Fill="Green" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
    <Rectangle Fill="Orange" 
               VariableSizedWrapGrid.RowSpan="2" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
</VariableSizedWrapGrid>
```


<span data-ttu-id="f7d19-202">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-202">The result looks like this.</span></span>

![VariableSizedWrapGrid](images/layout-panel-variable-size-wrap-grid.png)

<span data-ttu-id="f7d19-204">この例では、各列の行の最大数は 3 です。</span><span class="sxs-lookup"><span data-stu-id="f7d19-204">In this example, the maximum number of rows in each column is 3.</span></span> <span data-ttu-id="f7d19-205">青色の長方形は 2 行にまたがるため、最初の列には項目が 2 つだけ (赤色と青色の四角形) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-205">The first column contains only 2 items (the red and blue rectangles) because the blue rectangle spans 2 rows.</span></span> <span data-ttu-id="f7d19-206">緑色の四角形は、次の列の先頭に折り返されています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-206">The green rectangle then wraps to the top of the next column.</span></span>

## <a name="canvas"></a><span data-ttu-id="f7d19-207">Canvas</span><span class="sxs-lookup"><span data-stu-id="f7d19-207">Canvas</span></span>

<span data-ttu-id="f7d19-208">[**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) パネルでは、その子要素が固定座標点を使って配置されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-208">The [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) panel positions its child elements using fixed coordinate points.</span></span> <span data-ttu-id="f7d19-209">個々の子要素の位置を指定するには、要素ごとに [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) 添付プロパティと [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.top.aspx) 添付プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-209">You specify the points on individual child elements by setting the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) and [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.top.aspx) attached properties on each element.</span></span> <span data-ttu-id="f7d19-210">レイアウト時に、親 Canvas は、子要素のこれらの添付プロパティ値を読み取り、レイアウトの [Arrange](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.arrange.aspx) パス時にこれらの値を使います。</span><span class="sxs-lookup"><span data-stu-id="f7d19-210">During layout, the parent Canvas reads these attached property values from its children and uses these values during the [Arrange](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.arrange.aspx) pass of layout.</span></span>

<span data-ttu-id="f7d19-211">Canvas 内のオブジェクトは重ね合わせることができます。この場合、1 つのオブジェクトが別のオブジェクトの上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-211">Objects in a Canvas can overlap, where one object is drawn on top of another object.</span></span> <span data-ttu-id="f7d19-212">既定では、Canvas は、宣言されている順序で子要素をレンダリングするため、最後の子が一番上に表示されます (各要素の既定の z-index は 0 です)。</span><span class="sxs-lookup"><span data-stu-id="f7d19-212">By default, the Canvas renders child objects in the order in which they’re declared, so the last child is rendered on top (each element has a default z-index of 0).</span></span> <span data-ttu-id="f7d19-213">これは他の組み込みパネルでも同じです。</span><span class="sxs-lookup"><span data-stu-id="f7d19-213">This is the same as other built-in panels.</span></span> <span data-ttu-id="f7d19-214">ただし、Canvas では、子要素にそれぞれ設定できる [**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.zindex.aspx) 添付プロパティもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="f7d19-214">However, Canvas also supports the [**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.zindex.aspx) attached property that you can set on each of the child elements.</span></span> <span data-ttu-id="f7d19-215">コードでこのプロパティを設定することにより。実行時に要素の描画順序を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-215">You can set this property in code to change the draw order of elements during run time.</span></span> <span data-ttu-id="f7d19-216">Canvas.ZIndex 値が最大である要素は最後に描画されるため、同じ領域を共有するか、重なり合っている他の要素の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="f7d19-216">The element with the highest Canvas.ZIndex value draws last and therefore draws over any other elements that share the same space or overlap in any way.</span></span> <span data-ttu-id="f7d19-217">アルファ値 (透明度) が優先されるため、要素が重なる場合でも、一番上の要素のアルファ値が最大でないと、重なる領域に表示されるコンテンツがブレンドされることがあります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-217">Note that alpha value (transparency) is respected, so even if elements overlap, the contents shown in overlap areas might be blended if the top one has a non-maximum alpha value.</span></span>

<span data-ttu-id="f7d19-218">Canvas では、子のサイズ変更は行われません。</span><span class="sxs-lookup"><span data-stu-id="f7d19-218">The Canvas does not do any sizing of its children.</span></span> <span data-ttu-id="f7d19-219">各要素でそのサイズを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-219">Each element must specify its size.</span></span>

<span data-ttu-id="f7d19-220">XAML での Canvas の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f7d19-220">Here's an example of a Canvas in XAML.</span></span>

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red" Height="44" Width="44"/>
    <Rectangle Fill="Blue" Height="44" Width="44" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Height="44" Width="44" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Height="44" Width="44" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```


<span data-ttu-id="f7d19-221">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-221">The result looks like this.</span></span>

![Canvas](images/layout-panel-canvas.png)

<span data-ttu-id="f7d19-223">Canvas パネルは慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-223">Use the Canvas panel with discretion.</span></span> <span data-ttu-id="f7d19-224">UI 要素の位置を正確に制御できるのは便利ですが、シナリオによっては、固定配置されるレイアウト パネルにより UI の領域がアプリ全体のウィンドウ サイズの変更に適応しなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-224">While it's convenient to be able to precisely control positions of elements in UI for some scenarios, a fixed positioned layout panel causes that area of your UI to be less adaptive to overall app window size changes.</span></span> <span data-ttu-id="f7d19-225">アプリのウィンドウのサイズ変更は、デバイスの向きの変更、アプリのウィンドウの分割、モニターの変更を始めとする多くのユーザー シナリオによって発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-225">App window resize might come from device orientation changes, split app windows, changing monitors, and a number of other user scenarios.</span></span>

## <a name="panels-for-itemscontrol"></a><span data-ttu-id="f7d19-226">ItemsControl 用のパネル</span><span class="sxs-lookup"><span data-stu-id="f7d19-226">Panels for ItemsControl</span></span>

<span data-ttu-id="f7d19-227">[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) に項目を表示するための [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) としてのみ使用できる特殊な用途のパネルがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-227">There are several special-purpose panels that can be used only as an [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) to display items in an [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx).</span></span> <span data-ttu-id="f7d19-228">このようなパネルには、[**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemsstackpanel.aspx)、[**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemswrapgrid.aspx)、[**VirtualizingStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.virtualizingstackpanel.aspx)、[**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.wrapgrid.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="f7d19-228">These are [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemsstackpanel.aspx), [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemswrapgrid.aspx), [**VirtualizingStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.virtualizingstackpanel.aspx), and [**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.wrapgrid.aspx).</span></span> <span data-ttu-id="f7d19-229">一般的な UI のレイアウトに、これらのパネルを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="f7d19-229">You can't use these panels for general UI layout.</span></span>
