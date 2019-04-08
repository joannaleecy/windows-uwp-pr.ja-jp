---
Description: レイアウト パネルを使って、アプリの UI 要素を配置し、グループ化します。
title: ユニバーサル Windows プラットフォーム (UWP) アプリのレイアウト パネル
ms.date: 04/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 01fed50a00c26ca53b6ee703451f424811ba0e03
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650647"
---
# <a name="layout-panels"></a><span data-ttu-id="1c0a6-104">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="1c0a6-104">Layout panels</span></span>

<span data-ttu-id="1c0a6-105">レイアウト パネルは、アプリの UI 要素を配置およびグループ化するためのコンテナーです。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-105">Layout panels are containers that allow you to arrange and group UI elements in your app.</span></span> <span data-ttu-id="1c0a6-106">組み込みの XAML レイアウト パネルには、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)、[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-106">The built-in XAML layout panels include [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx), [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx), [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx), [**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx), and [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx).</span></span> <span data-ttu-id="1c0a6-107">ここでは、各パネルについて説明し、パネルを使って XAML UI 要素をレイアウトする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-107">Here, we describe each panel and show how to use it to layout XAML UI elements.</span></span>

<span data-ttu-id="1c0a6-108">レイアウト パネルを選ぶときに考慮する事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-108">There are several things to consider when choosing a layout panel:</span></span>
- <span data-ttu-id="1c0a6-109">パネルに子要素がどのように配置されるか。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-109">How the panel positions its child elements.</span></span>
- <span data-ttu-id="1c0a6-110">パネルで子要素のサイズがどのように変更されるか。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-110">How the panel sizes its child elements.</span></span>
- <span data-ttu-id="1c0a6-111">重複する子要素をお互いに重ねる方法 (z オーダー)。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-111">How overlapping child elements are layered on top of each other (z-order).</span></span>
- <span data-ttu-id="1c0a6-112">目的のレイアウトの作成に必要な、入れ子になったパネル要素の数と複雑さ。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-112">The number and complexity of nested panel elements needed to create your desired layout.</span></span>

## <a name="panel-properties"></a><span data-ttu-id="1c0a6-113">パネル プロパティ</span><span class="sxs-lookup"><span data-stu-id="1c0a6-113">Panel properties</span></span>

<span data-ttu-id="1c0a6-114">個々のパネルについて説明する前に、すべてのパネルにあるいくつかの一般的なプロパティを見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-114">Before we discuss individual panels, let's go over some common properties that all panels have.</span></span> 

### <a name="panel-attached-properties"></a><span data-ttu-id="1c0a6-115">パネルの添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="1c0a6-115">Panel attached properties</span></span>

<span data-ttu-id="1c0a6-116">多くの XAML レイアウト パネルでは添付プロパティを使用して、子要素がどのように UI に表示される必要があるかについて親パネルに通知できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-116">Most XAML layout panels use attached properties to let their child elements inform the parent panel about how they should be positioned in the UI.</span></span> <span data-ttu-id="1c0a6-117">添付プロパティでは、*AttachedPropertyProvider.PropertyName* という構文が使用されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-117">Attached properties use the syntax *AttachedPropertyProvider.PropertyName*.</span></span> <span data-ttu-id="1c0a6-118">パネルを他のパネルに入れ子にする場合、親に対するレイアウト属性を指定する UI 要素の添付プロパティは、最も近い親パネルによってのみ解釈されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-118">If you have panels that are nested inside other panels, attached properties on UI elements that specify layout characteristics to a parent are interpreted by the most immediate parent panel only.</span></span>

<span data-ttu-id="1c0a6-119">XAML で Button コントロールの [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) 添付プロパティを設定する方法の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-119">Here is an example of how you can set the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) attached property on a Button control in XAML.</span></span> <span data-ttu-id="1c0a6-120">これにより、親 Canvas に、Button を Canvas の左端から 50 有効ピクセルの位置に配置する必要があることを通知します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-120">This informs the parent Canvas that the Button should be positioned 50 effective pixels from the left edge of the Canvas.</span></span>

```xaml
<Canvas>
  <Button Canvas.Left="50">Hello</Button>
</Canvas>
```

<span data-ttu-id="1c0a6-121">添付プロパティについて詳しくは、「[添付プロパティの概要](../../xaml-platform/attached-properties-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-121">For more info about attached properties, see [Attached properties overview](../../xaml-platform/attached-properties-overview.md).</span></span>

### <a name="panel-borders"></a><span data-ttu-id="1c0a6-122">パネルの境界線</span><span class="sxs-lookup"><span data-stu-id="1c0a6-122">Panel borders</span></span>

<span data-ttu-id="1c0a6-123">RelativePanel、StackPanel、Grid の各パネルには境界線プロパティが定義されており、別の Border 要素でラップすることなく、パネルの周囲に境界線を描画できます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-123">The RelativePanel, StackPanel, and Grid panels define border properties that let you draw a border around the panel without wrapping them in an additional Border element.</span></span> <span data-ttu-id="1c0a6-124">境界線プロパティには、**BorderBrush**、**BorderThickness**、**CornerRadius**、**Padding** があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-124">The border properties are **BorderBrush**, **BorderThickness**, **CornerRadius**, and **Padding**.</span></span>

<span data-ttu-id="1c0a6-125">Grid で境界線プロパティを設定する例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-125">Here’s an example of how to set border properties on a Grid.</span></span>

```xaml
<Grid BorderBrush="Blue" BorderThickness="12" CornerRadius="12" Padding="12">
    <TextBlock Text="Hello World!"/>
</Grid>
```

![境界線を持つグリッド](images/layout-panel-grid-border.png)

<span data-ttu-id="1c0a6-127">組み込みの境界線のプロパティを使うことによって、XAML 要素の数を減らし、アプリの UI のパフォーマンスを向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-127">Using the built-in border properties reduces the XAML element count, which can improve the UI performance of your app.</span></span> <span data-ttu-id="1c0a6-128">レイアウト パネルと UI のパフォーマンスについて詳しくは、「[XAML レイアウトの最適化](https://msdn.microsoft.com/en-us/library/windows/apps/mt404609.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-128">For more info about layout panels and UI performance, see [Optimize your XAML layout](https://msdn.microsoft.com/en-us/library/windows/apps/mt404609.aspx).</span></span>

## <a name="relativepanel"></a><span data-ttu-id="1c0a6-129">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="1c0a6-129">RelativePanel</span></span>

<span data-ttu-id="1c0a6-130">[**RelativePanel** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)がどこで関連するその他の要素と、パネルとの関連を指定することでレイアウトの UI 要素を使用します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-130">[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) lets you layout UI elements by specifying where they go in relation to other elements and in relation to the panel.</span></span> <span data-ttu-id="1c0a6-131">既定では、要素はパネルの左上隅に配置されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-131">By default, an element is positioned in the upper left corner of the panel.</span></span> <span data-ttu-id="1c0a6-132">RelativePanel を、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) や [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) と共に使用して、さまざまなウィンドウ サイズに合わせて UI を配置し直すことができます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-132">You can use RelativePanel with [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) and [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) to rearrange your UI for different window sizes.</span></span>

<span data-ttu-id="1c0a6-133">次の表に、パネルまたは他の要素を基準として要素を揃えて配置するために使用できる添付プロパティを示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-133">This table shows the attached properties you can use to align an element in relation to the panel or other elements.</span></span>

<span data-ttu-id="1c0a6-134">パネルの配置</span><span class="sxs-lookup"><span data-stu-id="1c0a6-134">Panel alignment</span></span> | <span data-ttu-id="1c0a6-135">兄弟の配置</span><span class="sxs-lookup"><span data-stu-id="1c0a6-135">Sibling alignment</span></span> | <span data-ttu-id="1c0a6-136">兄弟の位置</span><span class="sxs-lookup"><span data-stu-id="1c0a6-136">Sibling position</span></span>
----------------|-------------------|-----------------
[<span data-ttu-id="1c0a6-137">**AlignTopWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-137">**AlignTopWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aligntopwithpanel.aspx) | [<span data-ttu-id="1c0a6-138">**AlignTopWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-138">**AlignTopWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aligntopwith.aspx) | [<span data-ttu-id="1c0a6-139">**上**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-139">**Above**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.above.aspx)  
[<span data-ttu-id="1c0a6-140">**AlignBottomWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-140">**AlignBottomWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignbottomwithpanel.aspx) | [<span data-ttu-id="1c0a6-141">**AlignBottomWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-141">**AlignBottomWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignbottomwith.aspx) | [<span data-ttu-id="1c0a6-142">**以下に**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-142">**Below**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.below.aspx)  
[<span data-ttu-id="1c0a6-143">**AlignLeftWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-143">**AlignLeftWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignleftwithpanel.aspx) | [<span data-ttu-id="1c0a6-144">**AlignLeftWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-144">**AlignLeftWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignleftwith.aspx) | [<span data-ttu-id="1c0a6-145">**取り去る**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-145">**LeftOf**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.leftof.aspx)  
[<span data-ttu-id="1c0a6-146">**AlignRightWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-146">**AlignRightWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignrightwithpanel.aspx) | [<span data-ttu-id="1c0a6-147">**AlignRightWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-147">**AlignRightWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignrightwith.aspx) | [<span data-ttu-id="1c0a6-148">**座標値**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-148">**RightOf**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.rightof.aspx)  
[<span data-ttu-id="1c0a6-149">**AlignHorizontalCenterWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-149">**AlignHorizontalCenterWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) | [<span data-ttu-id="1c0a6-150">**AlignHorizontalCenterWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-150">**AlignHorizontalCenterWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwith.aspx) | &nbsp;   
[<span data-ttu-id="1c0a6-151">**AlignVerticalCenterWithPanel**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-151">**AlignVerticalCenterWithPanel**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignverticalcenterwithpanel.aspx) | [<span data-ttu-id="1c0a6-152">**AlignVerticalCenterWith**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-152">**AlignVerticalCenterWith**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignverticalcenterwith.aspx) | &nbsp;   

 
<span data-ttu-id="1c0a6-153">次の XAML は、RelativePanel で要素を配置する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-153">This XAML shows how to arrange elements in a RelativePanel.</span></span>

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

<span data-ttu-id="1c0a6-154">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-154">The result looks like this.</span></span> 

![RelativePanel](images/layout-panel-relative-panel.png)

<span data-ttu-id="1c0a6-156">長方形のサイズについて、注意が必要な点をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-156">Here are a few things to note about the sizing of the rectangles:</span></span>
- <span data-ttu-id="1c0a6-157">赤色の長方形には、明示的なサイズとして 44 x 44 が指定されています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-157">The red rectangle is given an explicit size of 44x44.</span></span> <span data-ttu-id="1c0a6-158">この要素はパネルの左上隅に配置されます。これは既定の位置です。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-158">It's placed in the upper left corner of the panel, which is the default position.</span></span>
- <span data-ttu-id="1c0a6-159">緑色の四角形には、明示的な高さとして 44 が指定されています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-159">The green rectangle is given an explicit height of 44.</span></span> <span data-ttu-id="1c0a6-160">この長方形の左端は赤色の長方形に揃えられ、その右端は青色の長方形と揃えられています。これにより、この長方形の幅が決まります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-160">Its left side is aligned with the red rectangle, and its right side is aligned with the blue rectangle, which determines its width.</span></span>
- <span data-ttu-id="1c0a6-161">オレンジ色の長方形には、明示的なサイズは指定されていません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-161">The orange rectangle isn't given an explicit size.</span></span> <span data-ttu-id="1c0a6-162">この長方形の左端は青色の長方形に揃えられます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-162">Its left side is aligned with the blue rectangle.</span></span> <span data-ttu-id="1c0a6-163">右端と下端はパネルの端に揃えられます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-163">Its right and bottom edges are aligned with the edge of the panel.</span></span> <span data-ttu-id="1c0a6-164">この長方形のサイズはこれらの配置によって決まり、パネルのサイズが変更されると、長方形のサイズも変更されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-164">Its size is determined by these alignments and it will resize as the panel resizes.</span></span>

## <a name="stackpanel"></a><span data-ttu-id="1c0a6-165">StackPanel</span><span class="sxs-lookup"><span data-stu-id="1c0a6-165">StackPanel</span></span>

<span data-ttu-id="1c0a6-166">[**StackPanel** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)その子要素を水平方向または垂直方向に配置することができますの単一行に配置します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-166">[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) arranges its child elements into a single line that can be oriented horizontally or vertically.</span></span> <span data-ttu-id="1c0a6-167">StackPanel は通常、ページ上に UI の小さいサブセクションを配置するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-167">StackPanel is typically used to arrange a small subsection of the UI on a page.</span></span>

<span data-ttu-id="1c0a6-168">子要素を並べる向きを指定するには、[**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.orientation.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-168">You can use the [**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.orientation.aspx) property to specify the direction of the child elements.</span></span> <span data-ttu-id="1c0a6-169">既定の向きは [**Vertical**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.orientation.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-169">The default orientation is [**Vertical**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.orientation.aspx).</span></span>

<span data-ttu-id="1c0a6-170">次の XAML は、項目の垂直方向の StackPanel を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-170">The following XAML shows how to create a vertical StackPanel of items.</span></span>

```xaml
<StackPanel>
    <Rectangle Fill="Red" Height="44"/>
    <Rectangle Fill="Blue" Height="44"/>
    <Rectangle Fill="Green" Height="44"/>
    <Rectangle Fill="Orange" Height="44"/>
</StackPanel>
```


<span data-ttu-id="1c0a6-171">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-171">The result looks like this.</span></span>

![スタック パネル](images/layout-panel-stack-panel.png)

<span data-ttu-id="1c0a6-173">StackPanel では、子要素のサイズを明示的に設定しない場合、利用可能な幅 (Orientation が **Horizontal** の場合は高さ) いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-173">In a StackPanel, if a child element's size is not set explicitly, it stretches to fill the available width (or height if the Orientation is **Horizontal**).</span></span> <span data-ttu-id="1c0a6-174">この例では、長方形の幅は設定されていません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-174">In this example, the width of the rectangles is not set.</span></span> <span data-ttu-id="1c0a6-175">長方形は、StackPanel の幅いっぱいに拡張されています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-175">The rectangles expand to fill the entire width of the StackPanel.</span></span>

## <a name="grid"></a><span data-ttu-id="1c0a6-176">グリッド</span><span class="sxs-lookup"><span data-stu-id="1c0a6-176">Grid</span></span>

<span data-ttu-id="1c0a6-177">[  **Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) パネルは、柔軟なレイアウトをサポートし、複数行および段組レイアウトでのコントロールの配置を可能にします。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-177">The [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) panel supports fluid layouts and allows you to arrange controls in multi-row and multi-column layouts.</span></span> <span data-ttu-id="1c0a6-178">[  **RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowdefinitions.aspx) プロパティと [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columndefinitions.aspx) プロパティを使うことによって、グリッドの行と列を指定します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-178">You specify a Grid's rows and columns by using the [**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowdefinitions.aspx) and [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columndefinitions.aspx) properties.</span></span>

<span data-ttu-id="1c0a6-179">オブジェクトをグリッドの特定のセルに配置するには、[**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.column.aspx) 添付プロパティと [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.row.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-179">To position objects in specific cells of the Grid, use the [**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.column.aspx) and [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.row.aspx) attached properties.</span></span>

<span data-ttu-id="1c0a6-180">複数の行や列をまたいでコンテンツを表示するには、[**Grid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowspan.aspx) 添付プロパティと [**Grid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columnspan.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-180">To make content span across multiple rows and columns, use the [**Grid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.rowspan.aspx) and [**Grid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.columnspan.aspx) attached properties.</span></span>

<span data-ttu-id="1c0a6-181">次の XAML の例では、2 つの行と 2 つの列を持つ Grid を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-181">This XAML example shows how to create a Grid with two rows and two columns.</span></span>

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


<span data-ttu-id="1c0a6-182">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-182">The result looks like this.</span></span>

![グリッド](images/layout-panel-grid.png)

<span data-ttu-id="1c0a6-184">この例では、サイズ設定は次のように行われます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-184">In this example, the sizing works like this:</span></span> 
- <span data-ttu-id="1c0a6-185">2 番目の行には、明示的に 44 有効ピクセルの高さが指定されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-185">The second row has an explicit height of 44 effective pixels.</span></span> <span data-ttu-id="1c0a6-186">既定では、最初の行の高さは、残っているスペースいっぱいになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-186">By default, the height of the first row fills whatever space is left over.</span></span>
- <span data-ttu-id="1c0a6-187">最初の列の幅は **Auto** に設定されているため、その子に必要な幅になります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-187">The width of the first column is set to **Auto**, so it's as wide as needed for its children.</span></span> <span data-ttu-id="1c0a6-188">この例では、赤色の長方形の幅に対応するために、その幅は 44 有効ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-188">In this case, it's 44 effective pixels wide to accommodate the width of the red rectangle.</span></span>
- <span data-ttu-id="1c0a6-189">長方形に対してその他のサイズの制約はないため、各長方形は配置されているグリッドのセルいっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-189">There are no other size constraints on the rectangles, so each one stretches to fill the grid cell it's in.</span></span>

<span data-ttu-id="1c0a6-190">**Auto** サイズ変更またはスター サイズ指定を使うと、列または行内でスペースを分散できます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-190">You can distribute space within a column or a row by using **Auto** or star sizing.</span></span> <span data-ttu-id="1c0a6-191">UI 要素がコンテンツや親コンテナーに合わせてサイズ変更できるようにするには、自動サイズ変更を使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-191">You use auto sizing to let UI elements resize to fit their content or parent container.</span></span> <span data-ttu-id="1c0a6-192">グリッドの行と列を使って、自動サイズ変更を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-192">You can also use auto sizing with the rows and columns of a grid.</span></span> <span data-ttu-id="1c0a6-193">自動サイズ変更を使うには、UI 要素の Height や Width を **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-193">To use auto sizing, set the Height and/or Width of UI elements to **Auto**.</span></span>

<span data-ttu-id="1c0a6-194">比例サイズ変更 (*スター サイズ指定*とも呼ばれる) を使うと、使用可能なスペースが加重比率によりグリッドの行と列の間で分散されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-194">You use proportional sizing, also called *star sizing*, to distribute available space among the rows and columns of a grid by weighted proportions.</span></span> <span data-ttu-id="1c0a6-195">XAML、星型の値として表されます\*(または*n* \*スターのサイズ変更の加重計算される)。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-195">In XAML, star values are expressed as \* (or *n*\* for weighted star sizing).</span></span> <span data-ttu-id="1c0a6-196">たとえば、2 段組レイアウトで 1 つの列と、幅が 5 倍の列とを指定するには、[**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) 要素の [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) プロパティで "5\*" と "\*" を使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-196">For example, to specify that one column is 5 times wider than the second column in a 2-column layout, use "5\*" and "\*" for the [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) properties in the [**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) elements.</span></span>

<span data-ttu-id="1c0a6-197">次の例では、4 つの列を含む [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) で、固定、自動、比例サイズ指定を組み合わせています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-197">This example combines fixed, auto, and proportional sizing in a [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) with 4 columns.</span></span>

&nbsp;|&nbsp;|&nbsp;
------|------|------
<span data-ttu-id="1c0a6-198">Column_1</span><span class="sxs-lookup"><span data-stu-id="1c0a6-198">Column_1</span></span> | <span data-ttu-id="1c0a6-199">**自動**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-199">**Auto**</span></span> | <span data-ttu-id="1c0a6-200">列は、コンテンツが収まるようにサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-200">The column will size to fit its content.</span></span>
<span data-ttu-id="1c0a6-201">Column_2</span><span class="sxs-lookup"><span data-stu-id="1c0a6-201">Column_2</span></span> | * | <span data-ttu-id="1c0a6-202">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-202">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="1c0a6-203">Column_2 の幅は Column_4 の半分になります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-203">Column_2 will be one-half as wide as Column_4.</span></span>
<span data-ttu-id="1c0a6-204">Column_3</span><span class="sxs-lookup"><span data-stu-id="1c0a6-204">Column_3</span></span> | <span data-ttu-id="1c0a6-205">**44**</span><span class="sxs-lookup"><span data-stu-id="1c0a6-205">**44**</span></span> | <span data-ttu-id="1c0a6-206">列の幅は 44 ピクセルに設定されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-206">The column will be 44 pixels wide.</span></span>
<span data-ttu-id="1c0a6-207">Column_4</span><span class="sxs-lookup"><span data-stu-id="1c0a6-207">Column_4</span></span> | <span data-ttu-id="1c0a6-208">**2**\*</span><span class="sxs-lookup"><span data-stu-id="1c0a6-208">**2**\*</span></span> | <span data-ttu-id="1c0a6-209">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-209">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="1c0a6-210">Column_4 の幅は Column_2 の 2 倍になります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-210">Column_4 will be twice as wide as Column_2.</span></span>

<span data-ttu-id="1c0a6-211">既定の列の幅は "\*" であるため、2 つ目の列については、この値を明示的に設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-211">The default column width is "\*", so you don't need to explicitly set this value for the second column.</span></span>

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition/>
        <ColumnDefinition Width="44"/>
        <ColumnDefinition Width="2*"/>
    </Grid.ColumnDefinitions>
    <TextBlock Text="Column 1 sizes to its conent." FontSize="24"/>
</Grid>
```

<span data-ttu-id="1c0a6-212">Visual Studio の XAML デザイナーでは、結果は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-212">In the Visual Studio XAML designer, the result looks like this.</span></span>

![Visual Studio デザイナーでの 4 列のグリッド](images/xaml-layout-grid-in-designer.png)

## <a name="variablesizedwrapgrid"></a><span data-ttu-id="1c0a6-214">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="1c0a6-214">VariableSizedWrapGrid</span></span>

<span data-ttu-id="1c0a6-215">[**VariableSizedWrapGrid** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) 、新しい行または列に自動的に折り返さ行または列グリッド スタイルのレイアウト パネルは、ときに、 [ **MaximumRowsOrColumns** ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.maximumrowsorcolumns.aspx)値に達した.</span><span class="sxs-lookup"><span data-stu-id="1c0a6-215">[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) is a Grid-style layout panel where rows or columns automatically wrap to a new row or column when the [**MaximumRowsOrColumns**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.maximumrowsorcolumns.aspx) value is reached.</span></span> 

<span data-ttu-id="1c0a6-216">[  **Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.orientation.aspx) プロパティは、折り返す前にグリッドの行と列のどちらの向きに項目を追加するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-216">The [**Orientation**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.orientation.aspx) property specifies whether the grid adds its items in rows or columns before wrapping.</span></span> <span data-ttu-id="1c0a6-217">既定の向きは **Vertical** で、グリッドの項目は上から下へ列がいっぱいになるまで追加された後、新しい列に折り返されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-217">The default orientation is **Vertical**, which means the grid adds items from top to bottom until a column is full, then wraps to a new column.</span></span> <span data-ttu-id="1c0a6-218">この値が **Horizontal** の場合は、グリッドの項目は左から右に追加され、新しい行に折り返されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-218">When the value is **Horizontal**, the grid adds items from left to right, then wraps to a new row.</span></span>

<span data-ttu-id="1c0a6-219">セルのサイズは、[**ItemHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemheight.aspx) と [**ItemWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemwidth.aspx) で指定します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-219">Cell dimensions are specified by the [**ItemHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemheight.aspx) and [**ItemWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.itemwidth.aspx).</span></span> <span data-ttu-id="1c0a6-220">各セルは同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-220">Each cell is the same size.</span></span> <span data-ttu-id="1c0a6-221">ItemHeight または ItemWidth が指定されていない場合、最初のセルのサイズがそのコンテンツに合わせて変更され、その他の各セルは最初のセルのサイズになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-221">If ItemHeight or ItemWidth is not specified, then the first cell sizes to fit its content, and every other cell is the size of the first cell.</span></span>

<span data-ttu-id="1c0a6-222">子要素が配置される隣接セルの数を指定するには、[**VariableSizedWrapGrid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.columnspan.aspx) 添付プロパティと [**VariableSizedWrapGrid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.rowspan.aspx) 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-222">You can use the [**VariableSizedWrapGrid.ColumnSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.columnspan.aspx) and [**VariableSizedWrapGrid.RowSpan**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.rowspan.aspx) attached properties to specify how many adjacent cells a child element should fill.</span></span>

<span data-ttu-id="1c0a6-223">XAML での VariableSizedWrapGrid の使い方を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-223">Here's how to use a VariableSizedWrapGrid in XAML.</span></span>

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


<span data-ttu-id="1c0a6-224">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-224">The result looks like this.</span></span>

![VariableSizedWrapGrid](images/layout-panel-variable-size-wrap-grid.png)

<span data-ttu-id="1c0a6-226">この例では、各列の行の最大数は 3 です。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-226">In this example, the maximum number of rows in each column is 3.</span></span> <span data-ttu-id="1c0a6-227">青色の長方形は 2 行にまたがるため、最初の列には項目が 2 つだけ (赤色と青色の四角形) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-227">The first column contains only 2 items (the red and blue rectangles) because the blue rectangle spans 2 rows.</span></span> <span data-ttu-id="1c0a6-228">緑色の四角形は、次の列の先頭に折り返されています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-228">The green rectangle then wraps to the top of the next column.</span></span>

## <a name="canvas"></a><span data-ttu-id="1c0a6-229">キャンバス</span><span class="sxs-lookup"><span data-stu-id="1c0a6-229">Canvas</span></span>

<span data-ttu-id="1c0a6-230">[  **Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) パネルでは、その子要素が固定座標点を使って配置されます。柔軟なレイアウトはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-230">The [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) panel positions its child elements using fixed coordinate points and does not support fluid layouts.</span></span> <span data-ttu-id="1c0a6-231">個々の子要素の位置を指定するには、要素ごとに [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) 添付プロパティと [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.top.aspx) 添付プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-231">You specify the points on individual child elements by setting the [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.left.aspx) and [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.top.aspx) attached properties on each element.</span></span> <span data-ttu-id="1c0a6-232">親 Canvas は、レイアウトの [Arrange](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.arrange.aspx) パス時に子のこれらの添付プロパティ値を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-232">The parent Canvas reads these attached property values from its children during the [Arrange](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.arrange.aspx) pass of layout.</span></span>

<span data-ttu-id="1c0a6-233">Canvas 内のオブジェクトは重ね合わせることができます。この場合、1 つのオブジェクトが別のオブジェクトの上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-233">Objects in a Canvas can overlap, where one object is drawn on top of another object.</span></span> <span data-ttu-id="1c0a6-234">既定では、Canvas は、宣言されている順序で子要素をレンダリングするため、最後の子が一番上に表示されます (各要素の既定の z-index は 0 です)。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-234">By default, the Canvas renders child objects in the order in which they’re declared, so the last child is rendered on top (each element has a default z-index of 0).</span></span> <span data-ttu-id="1c0a6-235">これは他の組み込みパネルでも同じです。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-235">This is the same as other built-in panels.</span></span> <span data-ttu-id="1c0a6-236">ただし、Canvas では、子要素にそれぞれ設定できる [**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.zindex.aspx) 添付プロパティもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-236">However, Canvas also supports the [**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.zindex.aspx) attached property that you can set on each of the child elements.</span></span> <span data-ttu-id="1c0a6-237">コードでこのプロパティを設定することにより。実行時に要素の描画順序を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-237">You can set this property in code to change the draw order of elements during run time.</span></span> <span data-ttu-id="1c0a6-238">Canvas.ZIndex 値が最大である要素は最後に描画されるため、同じ領域を共有するか、重なり合っている他の要素の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-238">The element with the highest Canvas.ZIndex value draws last and therefore draws over any other elements that share the same space or overlap in any way.</span></span> <span data-ttu-id="1c0a6-239">アルファ値 (透明度) が優先されるため、要素が重なる場合でも、一番上の要素のアルファ値が最大でないと、重なる領域に表示されるコンテンツがブレンドされることがあります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-239">Note that alpha value (transparency) is respected, so even if elements overlap, the contents shown in overlap areas might be blended if the top one has a non-maximum alpha value.</span></span>

<span data-ttu-id="1c0a6-240">Canvas では、子のサイズ変更は行われません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-240">The Canvas does not do any sizing of its children.</span></span> <span data-ttu-id="1c0a6-241">各要素でそのサイズを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-241">Each element must specify its size.</span></span>

<span data-ttu-id="1c0a6-242">XAML での Canvas の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-242">Here's an example of a Canvas in XAML.</span></span>

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red" Height="44" Width="44"/>
    <Rectangle Fill="Blue" Height="44" Width="44" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Height="44" Width="44" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Height="44" Width="44" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

<span data-ttu-id="1c0a6-243">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-243">The result looks like this.</span></span>

![キャンバス](images/layout-panel-canvas.png)

<span data-ttu-id="1c0a6-245">Canvas パネルは慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-245">Use the Canvas panel with discretion.</span></span> <span data-ttu-id="1c0a6-246">UI 要素の位置を正確に制御できるのは便利ですが、シナリオによっては、固定配置されるレイアウト パネルにより UI の領域がアプリ全体のウィンドウ サイズの変更に適応しなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-246">While it's convenient to be able to precisely control positions of elements in UI for some scenarios, a fixed positioned layout panel causes that area of your UI to be less adaptive to overall app window size changes.</span></span> <span data-ttu-id="1c0a6-247">アプリのウィンドウのサイズ変更は、デバイスの向きの変更、アプリのウィンドウの分割、モニターの変更を始めとする多くのユーザー シナリオによって発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-247">App window resize might come from device orientation changes, split app windows, changing monitors, and a number of other user scenarios.</span></span>

## <a name="panels-for-itemscontrol"></a><span data-ttu-id="1c0a6-248">ItemsControl 用のパネル</span><span class="sxs-lookup"><span data-stu-id="1c0a6-248">Panels for ItemsControl</span></span>

<span data-ttu-id="1c0a6-249">[  **ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) に項目を表示するための [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) としてのみ使用できる特殊な用途のパネルがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-249">There are several special-purpose panels that can be used only as an [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) to display items in an [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx).</span></span> <span data-ttu-id="1c0a6-250">このようなパネルには、[**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemsstackpanel.aspx)、[**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemswrapgrid.aspx)、[**VirtualizingStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.virtualizingstackpanel.aspx)、[**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.wrapgrid.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-250">These are [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemsstackpanel.aspx), [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemswrapgrid.aspx), [**VirtualizingStackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.virtualizingstackpanel.aspx), and [**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.wrapgrid.aspx).</span></span> <span data-ttu-id="1c0a6-251">一般的な UI のレイアウトに、これらのパネルを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="1c0a6-251">You can't use these panels for general UI layout.</span></span>

