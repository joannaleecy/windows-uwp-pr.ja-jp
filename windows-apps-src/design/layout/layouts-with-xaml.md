---
author: muhsinking
Description: XAML gives you a flexible layout system to create a responsive UI.
title: XAML でのレスポンシブ レイアウト
ms.author: mukin
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0b45196a83edf45a69f6b79ab82542cef6817703
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3417080"
---
# <a name="responsive-layouts-with-xaml"></a><span data-ttu-id="4d45a-103">XAML でのレスポンシブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="4d45a-103">Responsive layouts with XAML</span></span>

<span data-ttu-id="4d45a-104">XAML レイアウト システムでは、応答性の高い UI を作成するために、自動サイズ変更、レイアウト パネル、表示状態、独立した UI 定義が提供されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-104">The XAML layout system provides automatic sizing, layout panels, visual states, and even separate UI definitions to create a responsive UI.</span></span> <span data-ttu-id="4d45a-105">レスポンシブ レイアウトを使用すると、サイズ、解像度、ピクセル密度、向きがさまざまに異なるアプリのウィンドウを画面で適切に表示できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-105">With a responsive layout, you can make your app look great on screens with different app window sizes, resolutions, pixel densities, and orientations.</span></span> <span data-ttu-id="4d45a-106">「[レスポンシブ デザイン テクニック](responsive-design.md)」で説明されているように、位置変更、サイズ変更、リフロー、表示/非表示、再配置、またはアプリの UI の再構築にも XAML を使用できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-106">You can also use XAML to reposition, resize, reflow, show/hide, replace, or re-architect your app's UI, as discussed in [Responsive design techniques](responsive-design.md).</span></span> <span data-ttu-id="4d45a-107">ここでは、XAML を使ったレスポンシブ レイアウトを実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-107">Here, we discuss how to implement responsive layouts with XAML.</span></span>

## <a name="fluid-layouts-with-properties-and-panels"></a><span data-ttu-id="4d45a-108">プロパティとパネルを使用した柔軟なレイアウト</span><span class="sxs-lookup"><span data-stu-id="4d45a-108">Fluid layouts with properties and panels</span></span>

<span data-ttu-id="4d45a-109">レスポンシブ レイアウトの基盤は、XAML レイアウト プロパティとパネルを適切に使用することにより、柔軟な方法でコンテンツの位置変更、サイズ変更、再配置を行うことです。</span><span class="sxs-lookup"><span data-stu-id="4d45a-109">The foundation of a responsive layout is the appropriate use of XAML layout properties and panels to reposition, resize, and reflow content in a fluid manner.</span></span> 

<span data-ttu-id="4d45a-110">XAML レイアウト システムでは、静的レイアウトと柔軟なレイアウトの両方がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-110">The XAML layout system supports both static and fluid layouts.</span></span> <span data-ttu-id="4d45a-111">静的レイアウトでは、コントロールのピクセル サイズと位置を明示的に指定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-111">In a static layout, you give controls explicit pixel sizes and positions.</span></span> <span data-ttu-id="4d45a-112">ユーザーがデバイスの解像度や向きを変えても、UI は変更されません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-112">When the user changes the resolution or orientation of their device, the UI doesn't change.</span></span> <span data-ttu-id="4d45a-113">静的レイアウトは、フォーム ファクターやディスプレイ サイズが変わると、不適切にはみ出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-113">Static layouts can become clipped across different form factors and display sizes.</span></span> <span data-ttu-id="4d45a-114">一方、柔軟なレイアウトは、デバイス上で使用できる表示領域に合わせて縮小、拡大、再配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-114">On the other hand, fluid layouts shrink, grow, and reflow to respond to the visual space available on a device.</span></span> 

<span data-ttu-id="4d45a-115">実際には、静的要素と柔軟な要素の組み合わせを使って UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-115">In practice, you use a combination of static and fluid elements to create your UI.</span></span> <span data-ttu-id="4d45a-116">場所によっては静的な要素と値を使うこともありますが、UI 全体のさまざまな解像度、画面サイズ、ビューへの応答性を高くする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-116">You still use static elements and values in some places, but make sure that the overall UI is responds to different resolutions, screen sizes, and views.</span></span>

<span data-ttu-id="4d45a-117">ここでは、XAML プロパティとレイアウト パネルを使って、柔軟なレイアウトを作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-117">Here, we discuss how to use XAML properties and layout panels to create a fluid layout.</span></span>

### <a name="layout-properties"></a><span data-ttu-id="4d45a-118">レイアウト プロパティ</span><span class="sxs-lookup"><span data-stu-id="4d45a-118">Layout properties</span></span>
<span data-ttu-id="4d45a-119">レイアウト プロパティは、要素のサイズと位置を制御します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-119">Layout properties control the size and position of an element.</span></span> <span data-ttu-id="4d45a-120">柔軟なレイアウトを作成するには、要素の自動または比例サイズ設定を使用し、必要に応じて、レイアウト パネルで子を配置できるようにします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-120">To create a fluid layout, use automatic or proportional sizing for elements, and allow layout panels position their children as needed.</span></span> 

<span data-ttu-id="4d45a-121">いくつかの一般的なレイアウト プロパティと、それらを使用して柔軟なレイアウトを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-121">Here are some common layout properties and how to use them to create fluid layouts.</span></span>

**<span data-ttu-id="4d45a-122">高さと幅</span><span class="sxs-lookup"><span data-stu-id="4d45a-122">Height and Width</span></span>**

<span data-ttu-id="4d45a-123">[**Height**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティと [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) プロパティは要素のサイズを指定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-123">The [**Height**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) and [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) properties specify the size of an element.</span></span> <span data-ttu-id="4d45a-124">有効ピクセル単位で測定された固定値を使うことも、自動サイズ変更または比例サイズ変更を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-124">You can use fixed values measured in effective pixels, or you can use auto or proportional sizing.</span></span> 

<span data-ttu-id="4d45a-125">自動サイズ変更は、UI 要素をコンテンツや親コンテナーに合わせてサイズ変更します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-125">Auto sizing resizes UI elements to fit their content or parent container.</span></span> <span data-ttu-id="4d45a-126">グリッドの行と列を使って、自動サイズ変更を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-126">You can also use auto sizing with the rows and columns of a grid.</span></span> <span data-ttu-id="4d45a-127">自動サイズ変更を使うには、UI 要素の Height や Width を **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-127">To use auto sizing, set the Height and/or Width of UI elements to **Auto**.</span></span>

> [!NOTE]
> <span data-ttu-id="4d45a-128">コンテンツやコンテナーに合わせて要素のサイズが変更されるかどうかは、親コンテナーで子のサイズ変更を処理する方法によって決まります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-128">Whether an element resizes to its content or its container depends on how the parent container handles sizing of its children.</span></span> <span data-ttu-id="4d45a-129">詳しくは、この記事の「[レイアウト パネル](#layout-panels)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-129">For more info, see [Layout panels](#layout-panels) later in this article.</span></span>

<span data-ttu-id="4d45a-130">比例サイズ変更 (*スター サイズ指定*とも呼ばれる) を使うと、使用可能なスペースが加重比率によりグリッドの行と列の間で分散されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-130">Proportional sizing, also called *star sizing*, distributes available space among the rows and columns of a grid by weighted proportions.</span></span> <span data-ttu-id="4d45a-131">XAML では、スター値は \* (重み付きのスター サイズ指定の場合は *n*\*) として表されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-131">In XAML, star values are expressed as \* (or *n*\* for weighted star sizing).</span></span> <span data-ttu-id="4d45a-132">たとえば、2 段組レイアウトで 1 つの列と、幅が 5 倍の列とを指定するには、[**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) 要素の [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) プロパティで "5\*" と "\*" を使います。</span><span class="sxs-lookup"><span data-stu-id="4d45a-132">For example, to specify that one column is 5 times wider than the second column in a 2-column layout, use "5\*" and "\*" for the [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) properties in the [**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) elements.</span></span>

<span data-ttu-id="4d45a-133">次の例では、4 つの列を含む [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) で、固定、自動、比例サイズ指定を組み合わせています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-133">This example combines fixed, auto, and proportional sizing in a [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) with 4 columns.</span></span>

&nbsp;|&nbsp;|&nbsp;
------|------|------
<span data-ttu-id="4d45a-134">Column_1</span><span class="sxs-lookup"><span data-stu-id="4d45a-134">Column_1</span></span> | **<span data-ttu-id="4d45a-135">Auto</span><span class="sxs-lookup"><span data-stu-id="4d45a-135">Auto</span></span>** | <span data-ttu-id="4d45a-136">列は、コンテンツが収まるようにサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-136">The column will size to fit its content.</span></span>
<span data-ttu-id="4d45a-137">Column_2</span><span class="sxs-lookup"><span data-stu-id="4d45a-137">Column_2</span></span> | * | <span data-ttu-id="4d45a-138">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-138">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="4d45a-139">Column_2 の幅は Column_4 の半分になります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-139">Column_2 will be one-half as wide as Column_4.</span></span>
<span data-ttu-id="4d45a-140">Column_3</span><span class="sxs-lookup"><span data-stu-id="4d45a-140">Column_3</span></span> | **<span data-ttu-id="4d45a-141">44</span><span class="sxs-lookup"><span data-stu-id="4d45a-141">44</span></span>** | <span data-ttu-id="4d45a-142">列の幅は 44 ピクセルに設定されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-142">The column will be 44 pixels wide.</span></span>
<span data-ttu-id="4d45a-143">Column_4</span><span class="sxs-lookup"><span data-stu-id="4d45a-143">Column_4</span></span> | <span data-ttu-id="4d45a-144">**2**\*</span><span class="sxs-lookup"><span data-stu-id="4d45a-144">**2**\*</span></span> | <span data-ttu-id="4d45a-145">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-145">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="4d45a-146">Column_4 の幅は Column_2 の 2 倍になります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-146">Column_4 will be twice as wide as Column_2.</span></span>

<span data-ttu-id="4d45a-147">既定の列の幅は "\*" であるため、2 つ目の列については、この値を明示的に設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-147">The default column width is "\*", so you don't need to explicitly set this value for the second column.</span></span>

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

<span data-ttu-id="4d45a-148">Visual Studio の XAML デザイナーでは、結果は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-148">In the Visual Studio XAML designer, the result looks like this.</span></span>

![Visual Studio デザイナーでの 4 列のグリッド](images/xaml-layout-grid-in-designer.png)

<span data-ttu-id="4d45a-150">実行時に要素のサイズを取得するには、Height と Width の代わりに、読み取り専用の [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualheight.aspx) プロパティと [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualwidth.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="4d45a-150">To get the size of an element at runtime, use the read-only [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualheight.aspx) and [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualwidth.aspx) properties instead of Height and Width.</span></span>

**<span data-ttu-id="4d45a-151">サイズの制約</span><span class="sxs-lookup"><span data-stu-id="4d45a-151">Size constraints</span></span>**

<span data-ttu-id="4d45a-152">UI で自動サイズ変更を使用する場合でも、要素のサイズに制約を設けることが必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-152">When you use auto sizing in your UI, you might still need to place constraints on the size of an element.</span></span> <span data-ttu-id="4d45a-153">[**MinWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minwidth.aspx)/[**MaxWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxwidth.aspx) と [**MinHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minheight.aspx)/[**MaxHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) の各プロパティを設定することによって、柔軟なサイズ変更を許可しながら、要素のサイズを制約する値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-153">You can set the [**MinWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minwidth.aspx)/[**MaxWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxwidth.aspx) and [**MinHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minheight.aspx)/[**MaxHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) properties to specify values that constrain the size of an element while allowing fluid resizing.</span></span>

<span data-ttu-id="4d45a-154">また、Grid では、MinWidth/MaxWidth を列定義と共に使用でき、MinHeight/MaxHeight を行定義と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-154">In a Grid, MinWidth/MaxWidth can also be used with column definitions, and MinHeight/MaxHeight can be used with row definitions.</span></span>

**<span data-ttu-id="4d45a-155">配置</span><span class="sxs-lookup"><span data-stu-id="4d45a-155">Alignment</span></span>**

<span data-ttu-id="4d45a-156">親コンテナー内の要素の配置方法を指定するには、[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) プロパティと [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="4d45a-156">Use the [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) properties to specify how an element should be positioned within its parent container.</span></span>
- <span data-ttu-id="4d45a-157">**HorizontalAlignment** の値は、**Left**、**Center**、**Right**、**Stretch** です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-157">The values for **HorizontalAlignment** are **Left**, **Center**, **Right**, and **Stretch**.</span></span>
- <span data-ttu-id="4d45a-158">**VerticalAlignment** の値は、**Top**、**Center**、**Bottom**、**Stretch** です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-158">The values for **VerticalAlignment** are **Top**, **Center**, **Bottom**, and **Stretch**.</span></span>

<span data-ttu-id="4d45a-159">**Stretch** 配置にすると、要素は、親コンテナーで提供されたスペース全体に配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-159">With the **Stretch** alignment, elements fill all the space they're provided in the parent container.</span></span> <span data-ttu-id="4d45a-160">Stretch は、両方の配置プロパティの既定値です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-160">Stretch is the default for both alignment properties.</span></span> <span data-ttu-id="4d45a-161">ただし、[**Button**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx) などの一部のコントロールでは、その既定のスタイルでこの値がオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-161">However, some controls, like [**Button**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx), override this value in their default style.</span></span>
<span data-ttu-id="4d45a-162">子要素を持つことができるすべての要素で、HorizontalAlignment プロパティと VerticalAlignment プロパティの Stretch 値を一意に処理することができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-162">Any element that can have child elements can treat the Stretch value for HorizontalAlignment and VerticalAlignment properties uniquely.</span></span> <span data-ttu-id="4d45a-163">たとえば、既定の Stretch 値を使用する要素が Grid に配置された場合、要素はその要素を含むセルいっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-163">For example, an element using the default Stretch values placed in a Grid stretches to fill the cell that contains it.</span></span> <span data-ttu-id="4d45a-164">同じ要素が Canvas に配置された場合は、そのコンテンツに合わせてサイズが変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-164">The same element placed in a Canvas sizes to its content.</span></span> <span data-ttu-id="4d45a-165">各パネルでの Stretch 値の処理方法について詳しくは、「[レイアウト パネル](layout-panels.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-165">For more info about how each panel handles the Stretch value, see the [Layout panels](layout-panels.md) article.</span></span>

<span data-ttu-id="4d45a-166">詳しくは、「[配置、余白、およびパディング](alignment-margin-padding.md)」や、[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) と [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-166">For more info, see the [Alignment, margin, and padding](alignment-margin-padding.md) article, and the [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) reference pages.</span></span>

**<span data-ttu-id="4d45a-167">表示</span><span class="sxs-lookup"><span data-stu-id="4d45a-167">Visibility</span></span>**

<span data-ttu-id="4d45a-168">[**Visibility**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.visibility.aspx) プロパティを [**Visibility** 列挙値](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visibility.aspx)のいずれか (**Visible** または **Collapsed**) に設定することによって、要素の表示と非表示を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-168">You can reveal or hide an element by setting its [**Visibility**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.visibility.aspx) property to one of the [**Visibility** enumeration](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visibility.aspx) values: **Visible** or **Collapsed**.</span></span> <span data-ttu-id="4d45a-169">要素が Collapsed である場合、UI レイアウト内の領域は使用されません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-169">When an element is Collapsed, it doesn't take up any space in the UI layout.</span></span>

<span data-ttu-id="4d45a-170">コードまたは表示状態で、要素の Visibility プロパティを変更できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-170">You can change an element's Visibility property in code or in a visual state.</span></span> <span data-ttu-id="4d45a-171">要素の Visibility が変更されると、そのすべての子要素も変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-171">When the Visibility of an element is changed, all of its child elements are also changed.</span></span> <span data-ttu-id="4d45a-172">1 つのパネルを表示して別のパネルを折りたたむことによって、UI のセクションを置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-172">You can replace sections of your UI by revealing one panel while collapsing another.</span></span>

> [!Tip]
> <span data-ttu-id="4d45a-173">既定では**Collapsed**である、ui 要素がある場合は、オブジェクトは作成、起動時にいなくて表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-173">When you have elements in your UI that are **Collapsed** by default, the objects are still created at startup, even though they aren't visible.</span></span> <span data-ttu-id="4d45a-174">これらの要素の読み込みを表示されたときまで遅延するには、**x:DeferLoadStrategy 属性**を "Lazy" に設定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-174">You can defer loading these elements until they are shown by setting the **x:DeferLoadStrategy attribute** to "Lazy".</span></span> <span data-ttu-id="4d45a-175">これにより起動時のパフォーマンスが向上することがあります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-175">This can improve startup performance.</span></span> <span data-ttu-id="4d45a-176">詳しくは、「[x:DeferLoadStrategy 属性](../../xaml-platform/x-deferloadstrategy-attribute.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-176">For more info, see [x:DeferLoadStrategy attribute](../../xaml-platform/x-deferloadstrategy-attribute.md).</span></span>

### <a name="style-resources"></a><span data-ttu-id="4d45a-177">スタイル リソース</span><span class="sxs-lookup"><span data-stu-id="4d45a-177">Style resources</span></span>

<span data-ttu-id="4d45a-178">コントロールに対して各プロパティ値を個別に設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-178">You don't have to set each property value individually on a control.</span></span> <span data-ttu-id="4d45a-179">通常、プロパティ値を [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) リソースとしてグループ化し、Style をコントロールに適用する方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-179">It's typically more efficient to group property values into a [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) resource and apply the Style to a control.</span></span> <span data-ttu-id="4d45a-180">これは、特に、同じプロパティ値を多くのコントロールに適用する必要がある場合に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-180">This is especially true when you need to apply the same property values to many controls.</span></span> <span data-ttu-id="4d45a-181">スタイルの使用について詳しくは、「[コントロールのスタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-181">For more info about using styles, see [Styling controls](../controls-and-patterns/xaml-styles.md).</span></span>

### <a name="layout-panels"></a><span data-ttu-id="4d45a-182">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="4d45a-182">Layout panels</span></span>

<span data-ttu-id="4d45a-183">ビジュアル オブジェクトを配置するには、パネルなどのコンテナー オブジェクトにビジュアル オブジェクトを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-183">To position visual objects, you must put them in a panel or other container object.</span></span> <span data-ttu-id="4d45a-184">XAML フレームワークには、UI 要素を内部に配置できるコンテナーとしての役割を持つさまざまなパネル クラス ([**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) など) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-184">The XAML framework provides various panel classes, such as [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx), [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx), [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) and [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx), which serve as containers and enable you to position and arrange the UI elements within them.</span></span>

<span data-ttu-id="4d45a-185">レイアウト パネルを選ぶ際に主に考慮が必要なのは、パネルでの子要素の配置とサイズです。</span><span class="sxs-lookup"><span data-stu-id="4d45a-185">The main thing to consider when choosing a layout panel is how the panel positions and sizes its child elements.</span></span> <span data-ttu-id="4d45a-186">重複する子要素をお互いに重ねる方法を検討する必要があることもあります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-186">You might also need to consider how overlapping child elements are layered on top of each other.</span></span>

<span data-ttu-id="4d45a-187">XAML フレームワークで提供されるパネル コントロールの主な機能の比較を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-187">Here's a comparison of the main features of the panel controls provided in the XAML framework.</span></span>

<span data-ttu-id="4d45a-188">パネル コントロール</span><span class="sxs-lookup"><span data-stu-id="4d45a-188">Panel Control</span></span> | <span data-ttu-id="4d45a-189">説明</span><span class="sxs-lookup"><span data-stu-id="4d45a-189">Description</span></span>
--------------|------------
[**<span data-ttu-id="4d45a-190">Canvas</span><span class="sxs-lookup"><span data-stu-id="4d45a-190">Canvas</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) | <span data-ttu-id="4d45a-191">**Canvas** は柔軟な UI をサポートしていません。子要素の配置とサイズに関するすべての側面を制御します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-191">**Canvas** doesn’t support fluid UI; you control all aspects of positioning and sizing child elements.</span></span> <span data-ttu-id="4d45a-192">通常、グラフィックスの作成などの特殊な場合や、大規模なアダプティブ UI の小さな静的領域を定義するために使用します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-192">You typically use it for special cases like creating graphics or to define small static areas of a larger adaptive UI.</span></span> <span data-ttu-id="4d45a-193">コードまたは表示状態を使って、実行時に要素の位置を変更できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-193">You can use code or visual states to reposition elements at runtime.</span></span><li><span data-ttu-id="4d45a-194">Canvas.Top 添付プロパティと Canvas.Left 添付プロパティを使って、要素を絶対的に配置します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-194">Elements are positioned absolutely using Canvas.Top and Canvas.Left attached properties.</span></span></li><li><span data-ttu-id="4d45a-195">Canvas.ZIndex 添付プロパティを使って、重なりを明示的に指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-195">Layering can be explicitly specified using the Canvas.ZIndex attached property.</span></span></li><li><span data-ttu-id="4d45a-196">HorizontalAlignment/VerticalAlignment の Stretch の値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-196">Stretch values for HorizontalAlignment/VerticalAlignment are ignored.</span></span> <span data-ttu-id="4d45a-197">要素のサイズが明示的に設定されていない場合は、そのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-197">If an element's size is not set explicitly, it sizes to its content.</span></span></li><li><span data-ttu-id="4d45a-198">パネルより大きい場合、子のコンテンツは視覚上クリップされません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-198">Child content is not visually clipped if larger than the panel.</span></span> </li><li><span data-ttu-id="4d45a-199">子のコンテンツはパネルの境界によって制約されません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-199">Child content is not constrained by the bounds of the panel.</span></span></li>
[**<span data-ttu-id="4d45a-200">Grid</span><span class="sxs-lookup"><span data-stu-id="4d45a-200">Grid</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) | <span data-ttu-id="4d45a-201">**Grid** は、子要素の柔軟なサイズ変更をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-201">**Grid** supports fluid resizing of child elements.</span></span> <span data-ttu-id="4d45a-202">コードまたは表示状態を使って、要素の位置の変更や再配置を実行できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-202">You can use code or visual states to reposition and reflow elements.</span></span><li><span data-ttu-id="4d45a-203">Grid.Row 添付プロパティと Grid.Column 添付プロパティを使って、要素は行と列に配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-203">Elements are arranged in rows and columns using Grid.Row and Grid.Column attached properties.</span></span></li><li><span data-ttu-id="4d45a-204">行や列をまたいで要素を表示するには、Grid.RowSpan 添付プロパティと Grid.ColumnSpan 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="4d45a-204">Elements can span multiple rows and columns using Grid.RowSpan and Grid.ColumnSpan attached properties.</span></span></li><li><span data-ttu-id="4d45a-205">HorizontalAlignment/VerticalAlignment の Stretch の値は考慮されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-205">Stretch values for HorizontalAlignment/VerticalAlignment are respected.</span></span> <span data-ttu-id="4d45a-206">要素のサイズを明示的に設定しないと、グリッド セルの利用可能な領域いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-206">If an element's size is not set explicitly, it stretches to fill the available space in the grid cell.</span></span></li><li><span data-ttu-id="4d45a-207">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-207">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="4d45a-208">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-208">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>
[**<span data-ttu-id="4d45a-209">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="4d45a-209">RelativePanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) | <li><span data-ttu-id="4d45a-210">要素は、パネルの端または中央を基準として、および互いを基準として配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-210">Elements are arranged in relation to the edge or center of the panel, and in relation to each other.</span></span></li><li><span data-ttu-id="4d45a-211">要素は、パネルの配置、兄弟の配置、兄弟の位置を制御するさまざまな添付プロパティを使用して配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-211">Elements are positioned using a variety of attached properties that control panel alignment, sibling alignment, and sibling position.</span></span> </li><li><span data-ttu-id="4d45a-212">HorizontalAlignment/VerticalAlignment の Stretch 値は、配置の RelativePanel 添付プロパティが拡大の原因である場合 (要素がパネルの右端と左端の両方に整列される場合など) を除き、無視されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-212">Stretch values for HorizontalAlignment/VerticalAlignment are ignored unless RelativePanel attached properties for alignment cause stretching (for example, an element is aligned to both the right and left edges of the panel).</span></span> <span data-ttu-id="4d45a-213">要素のサイズが明示的に設定されておらず、要素が拡大されていない場合、要素はそのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-213">If an element's size is not set explicitly and it's not stretched, it sizes to its content.</span></span></li><li><span data-ttu-id="4d45a-214">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-214">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="4d45a-215">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-215">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>
[**<span data-ttu-id="4d45a-216">StackPanel</span><span class="sxs-lookup"><span data-stu-id="4d45a-216">StackPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) |<li><span data-ttu-id="4d45a-217">要素は、水平方向または垂直方向に 1 列に並べて表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-217">Elements are stacked in a single line either vertically or horizontally.</span></span></li><li><span data-ttu-id="4d45a-218">HorizontalAlignment/VerticalAlignment の Stretch 値は、Orientation プロパティとは逆の方向で考慮されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-218">Stretch values for HorizontalAlignment/VerticalAlignment are respected in the direction opposite the Orientation property.</span></span> <span data-ttu-id="4d45a-219">要素のサイズが明示的に設定されていない場合、利用可能な幅 (Orientation が Horizontal の場合は高さ) いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-219">If an element's size is not set explicitly, it stretches to fill the available width (or height if the Orientation is Horizontal).</span></span> <span data-ttu-id="4d45a-220">要素は、Orientation プロパティで指定された方向に、そのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-220">In the direction specified by the Orientation property, an element sizes to its content.</span></span></li><li><span data-ttu-id="4d45a-221">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-221">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="4d45a-222">コンテンツのサイズは、Orientation プロパティで指定された方向では、パネルの境界によって制約されないため、スクロール可能なコンテンツはパネルの境界を越えて拡大され、スクロール バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-222">Content size is not constrained by the bounds of the panel in the direction specified by the Orientation property, so scrollable content stretches beyond the panel bounds and doesn't show scrollbars.</span></span> <span data-ttu-id="4d45a-223">スクロール バーを表示するには、子のコンテンツの高さ (または幅) を明示的に制約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-223">You must explicitly constrain the height (or width) of the child content to make its scrollbars show.</span></span></li>
[**<span data-ttu-id="4d45a-224">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="4d45a-224">VariableSizedWrapGrid</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) |<li><span data-ttu-id="4d45a-225">要素は、複数行、複数列に配置され、MaximumRowsOrColumns 値に達すると新しい行または列に自動的に折り返して配置されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-225">Elements are arranged in rows or columns that automatically wrap to a new row or column when the MaximumRowsOrColumns value is reached.</span></span></li><li><span data-ttu-id="4d45a-226">要素を行と列のどちらの形式で配置するかは、Orientation プロパティで指定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-226">Whether elements are arranged in rows or columns is specified by the Orientation property.</span></span></li><li><span data-ttu-id="4d45a-227">行や列をまたいで要素を表示するには、VariableSizedWrapGrid.RowSpan 添付プロパティと VariableSizedWrapGrid.ColumnSpan 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="4d45a-227">Elements can span multiple rows and columns using VariableSizedWrapGrid.RowSpan and VariableSizedWrapGrid.ColumnSpan attached properties.</span></span></li><li><span data-ttu-id="4d45a-228">HorizontalAlignment/VerticalAlignment の Stretch の値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-228">Stretch values for HorizontalAlignment/VerticalAlignment are ignored.</span></span> <span data-ttu-id="4d45a-229">ItemHeight プロパティと ItemWidth プロパティを指定すると、要素のサイズが変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-229">Elements are sized as specified by the ItemHeight and ItemWidth properties.</span></span> <span data-ttu-id="4d45a-230">これらのプロパティが設定されていない場合、最初のセルの項目はそのコンテンツに合わせてサイズ変更され、その他のすべてのセルはこのサイズを継承します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-230">If these properties are not set, the item in the first cell sizes to its content, and all other cells inherit this size.</span></span></li><li><span data-ttu-id="4d45a-231">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-231">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="4d45a-232">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-232">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>

<span data-ttu-id="4d45a-233">これらのパネルの例および詳細情報については、「[レイアウト パネル](layout-panels.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-233">For detailed information and examples of these panels, see [Layout panels](layout-panels.md).</span></span> <span data-ttu-id="4d45a-234">[レスポンシブな手法のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620024)に関するページもご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-234">Also, see the [Responsive techniques sample](http://go.microsoft.com/fwlink/p/?LinkId=620024).</span></span>

<span data-ttu-id="4d45a-235">レイアウト パネルでは、コントロールの論理グループに UI を整理することができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-235">Layout panels let you organize your UI into logical groups of controls.</span></span> <span data-ttu-id="4d45a-236">適切なプロパティの設定で使用する場合、UI 要素の自動サイズ変更、位置変更、再配置などのサポートを取得します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-236">When you use them with appropriate property settings, you get some support for automatic resizing, repositioning, and reflowing of UI elements.</span></span> <span data-ttu-id="4d45a-237">ただし、ほとんどの UI レイアウトでは、ウィンドウのサイズに大幅な変更がある場合、さらに変更が必要です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-237">However, most UI layouts need further modification when there are significant changes to the window size.</span></span> <span data-ttu-id="4d45a-238">これには、表示状態を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-238">For this, you can use visual states.</span></span>

## <a name="adaptive-layouts-with-visual-states-and-state-triggers"></a><span data-ttu-id="4d45a-239">表示状態と状態トリガーを使ったアダプティブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="4d45a-239">Adaptive layouts with visual states and state triggers</span></span>
<span data-ttu-id="4d45a-240">ウィンドウのサイズまたはその他の変更に基づいて、UI に大幅な変更を行うには、表示状態を使用します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-240">Use visual states to make significant alterations to your UI based on window size or other changes.</span></span>

<span data-ttu-id="4d45a-241">アプリ ウィンドウを一定量を超えて拡大/縮小するときに、レイアウト プロパティを変更して、UI のセクションの位置変更、サイズ変更、再配置、表示、置換を行うことが必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-241">When your app window grows or shrinks beyond a certain amount, you might want to alter layout properties to reposition, resize, reflow, reveal, or replace sections of your UI.</span></span> <span data-ttu-id="4d45a-242">UI のさまざまな表示状態を定義し、ウィンドウの幅や高さが指定したしきい値を超えたときに適用できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-242">You can define different visual states for your UI, and apply them when the window width or window height crosses a specified threshold.</span></span> 

<span data-ttu-id="4d45a-243">[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) を使うと、状態を適用するしきい値 ("ブレークポイント" とも呼ばれます) を簡単に設定できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-243">An [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) provides an easy way to set the threshold (also called 'breakpoint') where a state is applied.</span></span> <span data-ttu-id="4d45a-244">[**VisualState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstate.aspx) は、要素が特定の状態にあるときに、要素に適用されるプロパティ値を定義します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-244">A [**VisualState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstate.aspx) defines property values that are applied to an element when it’s in a particular state.</span></span> <span data-ttu-id="4d45a-245">指定された条件が満たされたときに適切な VisualState を適用する [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) で表示状態をグループ化します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-245">You group visual states in a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) that applies the appropriate VisualState when the specified conditions are met.</span></span>

### <a name="set-visual-states-in-code"></a><span data-ttu-id="4d45a-246">コードでの表示状態の設定</span><span class="sxs-lookup"><span data-stu-id="4d45a-246">Set visual states in code</span></span>

<span data-ttu-id="4d45a-247">コードで表示状態を適用するには、[**VisualStateManager.GoToState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.gotostate.aspx) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-247">To apply a visual state from code, you call the [**VisualStateManager.GoToState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.gotostate.aspx) method.</span></span> <span data-ttu-id="4d45a-248">たとえば、アプリ ウィンドウが特定のサイズであるときに状態を適用するには、[**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.window.sizechanged.aspx) イベントを処理し、**GoToState** を呼び出して適切な状態を適用します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-248">For example, to apply a state when the app window is a particular size, handle the [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.window.sizechanged.aspx) event and call **GoToState** to apply the appropriate state.</span></span>

<span data-ttu-id="4d45a-249">ここでは、[**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstategroup.aspx) に 2 つの VisualState の定義が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-249">Here, a [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstategroup.aspx) contains two VisualState definitions.</span></span> <span data-ttu-id="4d45a-250">最初の `DefaultState` は空です。</span><span class="sxs-lookup"><span data-stu-id="4d45a-250">The first, `DefaultState`, is empty.</span></span> <span data-ttu-id="4d45a-251">これが適用される場合、XAML ページで定義されている値が適用されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-251">When it's applied, the values defined in the XAML page are applied.</span></span> <span data-ttu-id="4d45a-252">2 番目の `WideState` は、[**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) の [**DisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.displaymode.aspx) プロパティを **Inline** に変更し、ウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-252">The second, `WideState`, changes the [**DisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.displaymode.aspx) property of the [**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) to **Inline** and opens the pane.</span></span> <span data-ttu-id="4d45a-253">この状態は、ウィンドウの幅が 640 有効ピクセルより大きい場合に、SizeChanged イベント ハンドラーで適用されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-253">This state is applied in the SizeChanged event handler if the window width is greater than 640 effective pixels.</span></span>

> [!NOTE]
> <span data-ttu-id="4d45a-254">先に進む前に知っておくべきですが、アプリが実行されている特定のデバイスをアプリが検出する手段は、Windows では提供されていません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-254">Windows doesn't provide a way for your app to detect the specific device your app is running on.</span></span> <span data-ttu-id="4d45a-255">アプリが実行されているデバイス ファミリー (モバイル、デスクトップなど)、効果的な解像度、およびアプリが利用できる画面領域の量 (アプリのウィンドウのサイズ) は伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-255">It can tell you the device family (mobile, desktop, etc) the app is running on, the effective resolution, and the amount of screen space available to the app (the size of the app's window).</span></span> <span data-ttu-id="4d45a-256">[画面のサイズとブレークポイント](screen-sizes-and-breakpoints-for-responsive-design.md)の表示状態を定義することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-256">We recommend defining visual states for [screen sizes and break points](screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>


```xaml
<Page ...>
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState x:Name="DefaultState">
                        <Storyboard>
                        </Storyboard>
                    </VisualState>

                <VisualState x:Name="WideState">
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames
                            Storyboard.TargetProperty="SplitView.DisplayMode"
                            Storyboard.TargetName="mySplitView">
                            <DiscreteObjectKeyFrame KeyTime="0">
                                <DiscreteObjectKeyFrame.Value>
                                    <SplitViewDisplayMode>Inline</SplitViewDisplayMode>
                                </DiscreteObjectKeyFrame.Value>
                            </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames
                            Storyboard.TargetProperty="SplitView.IsPaneOpen"
                            Storyboard.TargetName="mySplitView">
                            <DiscreteObjectKeyFrame KeyTime="0" Value="True"/>
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <SplitView x:Name="mySplitView" DisplayMode="CompactInline"
                   IsPaneOpen="False" CompactPaneLength="20">
            <!-- SplitView content -->

            <SplitView.Pane>
                <!-- Pane content -->
            </SplitView.Pane>
        </SplitView>
    </Grid>
</Page>
```

```csharp
private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
{
    if (e.Size.Width > 640)
        VisualStateManager.GoToState(this, "WideState", false);
    else
        VisualStateManager.GoToState(this, "DefaultState", false);
}
```

### <a name="set-visual-states-in-xaml-markup"></a><span data-ttu-id="4d45a-257">XAML マークアップでの表示状態の設定</span><span class="sxs-lookup"><span data-stu-id="4d45a-257">Set visual states in XAML markup</span></span>

<span data-ttu-id="4d45a-258">Windows 10 より前のバージョンでは、VisualState の定義にプロパティ変更のための [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.storyboard.aspx) オブジェクトが必要であり、コードで **GoToState** を呼び出して状態を適用する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="4d45a-258">Prior to Windows 10, VisualState definitions required [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.storyboard.aspx) objects for property changes, and you had to call **GoToState** in code to apply the state.</span></span> <span data-ttu-id="4d45a-259">これは前の例に示されています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-259">This is shown in the previous example.</span></span> <span data-ttu-id="4d45a-260">この構文はまだ多くの例で使用されており、この構文を使用する既存のコードがある可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-260">You will still see many examples that use this syntax, or you might have existing code that uses it.</span></span>

<span data-ttu-id="4d45a-261">Windows 10 以降では、ここで示す簡素化された [**Setter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.setter.aspx) 構文を使うことができ、XAML マークアップで [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) を使って状態を適用できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-261">Starting in Windows 10, you can use the simplified [**Setter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.setter.aspx) syntax shown here, and you can use a [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) in your XAML markup to apply the state.</span></span> <span data-ttu-id="4d45a-262">状態トリガーを使って、アプリのイベントに応答して自動的に表示状態の変更をトリガーする単純な規則を作成します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-262">You use state triggers to create simple rules that automatically trigger visual state changes in response to an app event.</span></span>

<span data-ttu-id="4d45a-263">この例は前の例と同じですが、プロパティの変更を定義する Storyboard の代わりに、簡素化された **Setter** 構文を使用しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-263">This example does the same thing as the previous example, but uses the simplified **Setter** syntax instead of a Storyboard to define property changes.</span></span> <span data-ttu-id="4d45a-264">また、GoToState を呼び出す代わりに、組み込みの [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) 状態トリガーを使って状態を適用しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-264">And instead of calling GoToState, it uses the built in [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) state trigger to apply the state.</span></span> <span data-ttu-id="4d45a-265">状態トリガーを使う場合、空の `DefaultState` を定義する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-265">When you use state triggers, you don't need to define an empty `DefaultState`.</span></span> <span data-ttu-id="4d45a-266">状態トリガーの条件が満たされなくなったときには、既定の設定が自動的に再適用されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-266">The default settings are reapplied automatically when the conditions of the state trigger are no longer met.</span></span>

```xaml
<Page ...>
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <!-- VisualState to be triggered when the
                             window width is >=720 effective pixels. -->
                        <AdaptiveTrigger MinWindowWidth="640" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="mySplitView.DisplayMode" Value="Inline"/>
                        <Setter Target="mySplitView.IsPaneOpen" Value="True"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <SplitView x:Name="mySplitView" DisplayMode="CompactInline"
                   IsPaneOpen="False" CompactPaneLength="20">
            <!-- SplitView content -->

            <SplitView.Pane>
                <!-- Pane content -->
            </SplitView.Pane>
        </SplitView>
    </Grid>
</Page>
```

> [!Important]
> <span data-ttu-id="4d45a-267">前の例では、VisualStateManager.VisualStateGroups 添付プロパティは、 **Grid**要素で設定されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-267">In the previous example, the VisualStateManager.VisualStateGroups attached property is set on the **Grid** element.</span></span> <span data-ttu-id="4d45a-268">StateTriggers を使う場合は、トリガーを自動的に有効にするために、常にルートの最初の子に VisualStateGroups が添付されていることを確認します </span><span class="sxs-lookup"><span data-stu-id="4d45a-268">When you use StateTriggers, always ensure that VisualStateGroups is attached to the first child of the root in order for the triggers to take effect automatically.</span></span> <span data-ttu-id="4d45a-269">(ここでは、**Grid** がルートの **Page** 要素の最初の子です)。</span><span class="sxs-lookup"><span data-stu-id="4d45a-269">(Here, **Grid** is the first child of the root **Page** element.)</span></span>

### <a name="attached-property-syntax"></a><span data-ttu-id="4d45a-270">添付プロパティの構文</span><span class="sxs-lookup"><span data-stu-id="4d45a-270">Attached property syntax</span></span>

<span data-ttu-id="4d45a-271">VisualState では、通常、コントロールのプロパティの値、つまりコントロールを含むパネルのいずれかの添付プロパティの値を設定します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-271">In a VisualState, you typically set a value for a control property, or for one of the attached properties of the panel that contains the control.</span></span> <span data-ttu-id="4d45a-272">添付プロパティを設定するときは、添付プロパティ名をかっこで囲みます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-272">When you set an attached property, use parentheses around the attached property name.</span></span>

<span data-ttu-id="4d45a-273">この例では、`myTextBox` という名前の TextBox に対して、[**RelativePanel.AlignHorizontalCenterWithPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) 添付プロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-273">This example shows how to set the [**RelativePanel.AlignHorizontalCenterWithPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) attached property on a TextBox named `myTextBox`.</span></span> <span data-ttu-id="4d45a-274">最初の XAML では [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.objectanimationusingkeyframes.aspx) 構文を使用し、2 つ目の XAML では **Setter** 構文を使用しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-274">The first XAML uses [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.objectanimationusingkeyframes.aspx) syntax and the second uses **Setter** syntax.</span></span>

```xaml
<!-- Set an attached property using ObjectAnimationUsingKeyFrames. -->
<ObjectAnimationUsingKeyFrames
    Storyboard.TargetProperty="(RelativePanel.AlignHorizontalCenterWithPanel)"
    Storyboard.TargetName="myTextBox">
    <DiscreteObjectKeyFrame KeyTime="0" Value="True"/>
</ObjectAnimationUsingKeyFrames>

<!-- Set an attached property using Setter. -->
<Setter Target="myTextBox.(RelativePanel.AlignHorizontalCenterWithPanel)" Value="True"/>
```

### <a name="custom-state-triggers"></a><span data-ttu-id="4d45a-275">カスタム状態トリガー</span><span class="sxs-lookup"><span data-stu-id="4d45a-275">Custom state triggers</span></span>

<span data-ttu-id="4d45a-276">[**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) クラスを拡張して、さまざまなシナリオに対するカスタム トリガーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-276">You can extend the [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) class to create custom triggers for a wide range of scenarios.</span></span> <span data-ttu-id="4d45a-277">たとえば、入力の種類に基づいてさまざまな状態をトリガーする StateTrigger を作成して、入力の種類がタッチである場合はコントロールの周囲の余白を増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-277">For example, you can create a StateTrigger to trigger different states based on input type, then increase the margins around a control when the input type is touch.</span></span> <span data-ttu-id="4d45a-278">また、アプリが実行されるデバイス ファミリに基づいてさまざまな状態を適用する StateTrigger を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-278">Or create a StateTrigger to apply different states based on the device family the app is run on.</span></span> <span data-ttu-id="4d45a-279">カスタム トリガーを作成し、それらを使用して単一の XAML ビュー内から最適化された UI エクスペリエンスを作成する方法の例については、[状態トリガーのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620025)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-279">For examples of how to build custom triggers and use them to create optimized UI experiences from within a single XAML view, see the [State triggers sample](http://go.microsoft.com/fwlink/p/?LinkId=620025).</span></span>

### <a name="visual-states-and-styles"></a><span data-ttu-id="4d45a-280">表示状態とスタイル</span><span class="sxs-lookup"><span data-stu-id="4d45a-280">Visual states and styles</span></span>

<span data-ttu-id="4d45a-281">表示状態で Style リソースを使って、一連のプロパティの変更を複数のコントロールに適用できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-281">You can use Style resources in visual states to apply a set of property changes to multiple controls.</span></span> <span data-ttu-id="4d45a-282">スタイルの使用について詳しくは、「[コントロールのスタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-282">For more info about using styles, see [Styling controls](../controls-and-patterns/xaml-styles.md).</span></span>

<span data-ttu-id="4d45a-283">状態トリガーのサンプルに関するページから引用したこの簡略化された XAML では、Style リソースを Button に適用して、マウスまたはタッチ入力の場合にサイズと余白を調整しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-283">In this simplified XAML from the State triggers sample, a Style resource is applied to a Button to adjust the size and margins for mouse or touch input.</span></span> <span data-ttu-id="4d45a-284">このカスタム状態トリガーの完全なコードおよび定義については、[状態トリガーのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620025)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-284">For the complete code and the definition of the custom state trigger, see the [State triggers sample](http://go.microsoft.com/fwlink/p/?LinkId=620025).</span></span>

```xaml
<Page ... >
    <Page.Resources>
        <!-- Styles to be used for mouse vs. touch/pen hit targets -->
        <Style x:Key="MouseStyle" TargetType="Rectangle">
            <Setter Property="Margin" Value="5" />
            <Setter Property="Height" Value="20" />
            <Setter Property="Width" Value="20" />
        </Style>
        <Style x:Key="TouchPenStyle" TargetType="Rectangle">
            <Setter Property="Margin" Value="15" />
            <Setter Property="Height" Value="40" />
            <Setter Property="Width" Value="40" />
        </Style>
    </Page.Resources>

    <RelativePanel>
        <!-- ... -->
        <Button Content="Color Palette Button" x:Name="MenuButton">
            <Button.Flyout>
                <Flyout Placement="Bottom">
                    <RelativePanel>
                        <Rectangle Name="BlueRect" Fill="Blue"/>
                        <Rectangle Name="GreenRect" Fill="Green" RelativePanel.RightOf="BlueRect" />
                        <!-- ... -->
                    </RelativePanel>
                </Flyout>
            </Button.Flyout>
        </Button>
        <!-- ... -->
    </RelativePanel>
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="InputTypeStates">
            <!-- Second set of VisualStates for building responsive UI optimized for input type.
                 Take a look at InputTypeTrigger.cs class in CustomTriggers folder to see how this is implemented. -->
            <VisualState>
                <VisualState.StateTriggers>
                    <!-- This trigger indicates that this VisualState is to be applied when MenuButton is invoked using a mouse. -->
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Mouse" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="BlueRect.Style" Value="{StaticResource MouseStyle}" />
                    <Setter Target="GreenRect.Style" Value="{StaticResource MouseStyle}" />
                    <!-- ... -->
                </VisualState.Setters>
            </VisualState>
            <VisualState>
                <VisualState.StateTriggers>
                    <!-- Multiple trigger statements can be declared in the following way to imply OR usage.
                         For example, the following statements indicate that this VisualState is to be applied when MenuButton is invoked using Touch OR Pen.-->
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Touch" />
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Pen" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="BlueRect.Style" Value="{StaticResource TouchPenStyle}" />
                    <Setter Target="GreenRect.Style" Value="{StaticResource TouchPenStyle}" />
                    <!-- ... -->
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Page>
```

## <a name="tailored-layouts"></a><span data-ttu-id="4d45a-285">カスタマイズされたレイアウト</span><span class="sxs-lookup"><span data-stu-id="4d45a-285">Tailored layouts</span></span>

<span data-ttu-id="4d45a-286">さまざまなデバイスで UI のレイアウトに大幅な変更を加えるときは、1 つの UI を適合させるのではなく、デバイスに合わせてカスタマイズされたレイアウトを含む個別の UI ファイルを定義すると便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-286">When you make significant changes to your UI layout on different devices, you might find it more convenient to define a separate UI file with a layout tailored to the device, rather than adapting a single UI.</span></span> <span data-ttu-id="4d45a-287">複数のデバイス間で機能が同じである場合は、同じコード ファイルを共有する個別の XAML ビューを定義できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-287">If the functionality is the same across devices, you can define separate XAML views that share the same code file.</span></span> <span data-ttu-id="4d45a-288">ビューと機能の両方がデバイス間で大幅に異なる場合は、個別の Page を定義し、アプリの読み込み時に移動する Page を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-288">If both the view and the functionality differ significantly across devices, you can define separate Pages, and choose which Page to navigate to when the app is loaded.</span></span>

### <a name="separate-xaml-views-per-device-family"></a><span data-ttu-id="4d45a-289">デバイス ファミリごとの個別の XAML ビュー</span><span class="sxs-lookup"><span data-stu-id="4d45a-289">Separate XAML views per device family</span></span>

<span data-ttu-id="4d45a-290">同じ分離コードを共有する複数の UI 定義を作成するには、XAML ビューを使用します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-290">Use XAML views to create different UI definitions that share the same code-behind.</span></span> <span data-ttu-id="4d45a-291">デバイス ファミリごとに固有の UI 定義を提供できます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-291">You can provide a unique UI definition for each device family.</span></span> <span data-ttu-id="4d45a-292">次の手順に従って、アプリに XAML ビューを追加します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-292">Follow these steps to add a XAML view to your app.</span></span>

**<span data-ttu-id="4d45a-293">アプリに XAML ビューを追加するには</span><span class="sxs-lookup"><span data-stu-id="4d45a-293">To add a XAML view to an app</span></span>**
1. <span data-ttu-id="4d45a-294">[プロジェクト] の [新しい項目の追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-294">Select Project > Add New Item.</span></span> <span data-ttu-id="4d45a-295">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-295">The Add New Item dialog box opens.</span></span>
    > <span data-ttu-id="4d45a-296">**ヒント**&nbsp;&nbsp;ソリューション エクスプローラーで、ソリューションではなく、フォルダーまたはプロジェクトが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-296">**Tip**&nbsp;&nbsp;Make sure a folder or the project, and not the solution, is selected in Solution Explorer.</span></span>
2. <span data-ttu-id="4d45a-297">左側のウィンドウの [Visual C#] または [Visual Basic] の下で、テンプレートの種類として [XAML] を選びます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-297">Under Visual C# or Visual Basic in the left pane, pick the XAML template type.</span></span>
3. <span data-ttu-id="4d45a-298">中央のウィンドウで、[XAML ビュー] を選びます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-298">In the center pane, pick XAML View.</span></span>
4. <span data-ttu-id="4d45a-299">ビューの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-299">Enter the name for the view.</span></span> <span data-ttu-id="4d45a-300">ビューには、正しく名前を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-300">The view must be named correctly.</span></span> <span data-ttu-id="4d45a-301">命名方法について詳しくは、このセクションの後半をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-301">For more info on naming, see the remainder of this section.</span></span>
5. <span data-ttu-id="4d45a-302">[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-302">Click Add.</span></span> <span data-ttu-id="4d45a-303">ファイルがプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-303">The file is added to the project.</span></span>

<span data-ttu-id="4d45a-304">前の手順では、XAML ファイルのみを作成し、関連付けられた分離コード ファイルは作成していません。</span><span class="sxs-lookup"><span data-stu-id="4d45a-304">The previous steps create only a XAML file, but not an associated code-behind file.</span></span> <span data-ttu-id="4d45a-305">代わりに、ファイル名やフォルダー名の一部である "DeviceName" 修飾子を使って、XAML ビューが既存の分離コード ファイルに関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-305">Instead, the XAML view is associated with an existing code-behind file using a "DeviceName" qualifier that's part of the file or folder name.</span></span> <span data-ttu-id="4d45a-306">この修飾子名は、アプリが現在実行されているデバイスのデバイス ファミリを表す文字列値 ("Desktop"、"Tablet"、およびその他のデバイス ファミリの名前) にマップすることができます (「[**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcecontext.qualifiervalues.aspx)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="4d45a-306">This qualifier name can be mapped to a string value that represents the device family of the device that your app is currently running on, such as, "Desktop", "Tablet", and the names of the other device families (see [**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcecontext.qualifiervalues.aspx)).</span></span>

<span data-ttu-id="4d45a-307">ファイル名に修飾子を追加することや、修飾子名を持つフォルダーにファイルを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-307">You can add the qualifier to the file name, or add the file to a folder that has the qualifier name.</span></span>

**<span data-ttu-id="4d45a-308">ファイル名の使用</span><span class="sxs-lookup"><span data-stu-id="4d45a-308">Use file name</span></span>**

<span data-ttu-id="4d45a-309">ファイルに修飾子名を使用するには、*[pageName]*.DeviceFamily-*[qualifierString]*.xaml という形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-309">To use the qualifier name with the file, use this format: *[pageName]*.DeviceFamily-*[qualifierString]*.xaml.</span></span>

<span data-ttu-id="4d45a-310">MainPage.xaml という名前のファイルの例を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="4d45a-310">Let's look at an example for a file named MainPage.xaml.</span></span> <span data-ttu-id="4d45a-311">タブレット デバイス用のビューを作成するには、XAML ビューに MainPage.DeviceFamily-Tablet.xaml という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-311">To create a view for tablet devices, name the XAML view MainPage.DeviceFamily-Tablet.xaml.</span></span> <span data-ttu-id="4d45a-312">PC デバイス用のビューを作成するには、ビューに MainPage.DeviceFamily-Desktop.xaml という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-312">To create a view for PC devices, name the view MainPage.DeviceFamily-Desktop.xaml.</span></span> <span data-ttu-id="4d45a-313">Microsoft Visual Studio で、ソリューションがどのように表示されるかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-313">Here's what the solution looks like in Microsoft Visual Studio.</span></span>

![修飾ファイル名を持つ XAML ビュー](images/xaml-layout-view-ex-1.png)

**<span data-ttu-id="4d45a-315">フォルダー名の使用</span><span class="sxs-lookup"><span data-stu-id="4d45a-315">Use folder name</span></span>**

<span data-ttu-id="4d45a-316">フォルダーを使用して Visual Studio プロジェクト内のビューを整理するには、フォルダーで修飾子名を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-316">To organize the views in your Visual Studio project using folders, you can use the qualifier name with the folder.</span></span> <span data-ttu-id="4d45a-317">そのためには、フォルダーに DeviceFamily-*[qualifierString]* のように名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-317">To do so, name your folder like this: DeviceFamily-*[qualifierString]*.</span></span> <span data-ttu-id="4d45a-318">この場合は、各 XAML ファイルの名前は同じになります。</span><span class="sxs-lookup"><span data-stu-id="4d45a-318">In this case, each XAML view file has the same name.</span></span> <span data-ttu-id="4d45a-319">ファイル名に修飾子を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="4d45a-319">Don't include the qualifier in the file name.</span></span>

<span data-ttu-id="4d45a-320">MainPage.xaml という名前のファイルの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-320">Here's an example, again for a file named MainPage.xaml.</span></span> <span data-ttu-id="4d45a-321">タブレット デバイス用のビューを作成するには、"DeviceFamily-Tablet" という名前のフォルダーを作成し、このフォルダーに MainPage.xaml という名前の XAML ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-321">To create a view for tablet devices, create a folder named "DeviceFamily-Tablet", and place a XAML view named MainPage.xaml into it.</span></span> <span data-ttu-id="4d45a-322">PC デバイス用のビューを作成するには、"DeviceFamily-Desktop" という名前のフォルダーを作成し、このフォルダーに MainPage.xaml という名前の別の XAML ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-322">To create a view for PC devices, create a folder named "DeviceFamily-Desktop", and place another XAML view named MainPage.xaml into it.</span></span> <span data-ttu-id="4d45a-323">Visual Studio で、ソリューションがどのように表示されるかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-323">Here's what the solution looks like in Visual Studio.</span></span>

![フォルダー内の XAML ビュー](images/xaml-layout-view-ex-2.png)

<span data-ttu-id="4d45a-325">どちらの場合も、タブレット デバイスと PC デバイス用に固有のビューが使用されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-325">In both cases, a unique view is used for tablet and PC devices.</span></span> <span data-ttu-id="4d45a-326">既定の MainPage.xaml ファイルは、実行されているデバイスがデバイス ファミリ固有のビューのいずれにも一致しない場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-326">The default MainPage.xaml file is used if the device it's running on doesn't match any of the device family specific views.</span></span>

### <a name="separate-xaml-pages-per-device-family"></a><span data-ttu-id="4d45a-327">デバイス ファミリごとの個別の XAML ページ</span><span class="sxs-lookup"><span data-stu-id="4d45a-327">Separate XAML pages per device family</span></span>

<span data-ttu-id="4d45a-328">固有のビューと機能を提供するために、個別の Page ファイル (XAML とコード) を作成し、ページが必要になったときに適切なページに移動することができます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-328">To provide unique views and functionality, you can create separate Page files (XAML and code), and then navigate to the appropriate page when the page is needed.</span></span>

**<span data-ttu-id="4d45a-329">アプリに XAML ページを追加するには</span><span class="sxs-lookup"><span data-stu-id="4d45a-329">To add a XAML page to an app</span></span>**
1. <span data-ttu-id="4d45a-330">[プロジェクト] の [新しい項目の追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-330">Select Project > Add New Item.</span></span> <span data-ttu-id="4d45a-331">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-331">The Add New Item dialog box opens.</span></span>
    > <span data-ttu-id="4d45a-332">**ヒント**&nbsp;&nbsp;ソリューション エクスプローラーで、ソリューションではなく、プロジェクトが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-332">**Tip**&nbsp;&nbsp;Make sure the project, and not the solution, is selected in Solution Explorer.</span></span>
2. <span data-ttu-id="4d45a-333">左側のウィンドウの [Visual C#] または [Visual Basic] の下で、テンプレートの種類として [XAML] を選びます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-333">Under Visual C# or Visual Basic in the left pane, pick the XAML template type.</span></span>
3. <span data-ttu-id="4d45a-334">中央のウィンドウで、[空白のページ] を選びます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-334">In the center pane, pick Blank page.</span></span>
4. <span data-ttu-id="4d45a-335">ページの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-335">Enter the name for the page.</span></span> <span data-ttu-id="4d45a-336">たとえば、"MainPage_Tablet" と入力します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-336">For example, "MainPage_Tablet".</span></span> <span data-ttu-id="4d45a-337">MainPage_Tablet.xaml と MainPage_Tablet.xaml.cs/vb/cpp コード ファイルの両方が作成されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-337">Both a MainPage_Tablet.xaml and MainPage_Tablet.xaml.cs/vb/cpp code file are created.</span></span>
5. <span data-ttu-id="4d45a-338">[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d45a-338">Click Add.</span></span> <span data-ttu-id="4d45a-339">ファイルがプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-339">The file is added to the project.</span></span>

<span data-ttu-id="4d45a-340">実行時に、アプリが実行されているデバイス ファミリを確認し、次のように適切なページに移動します。</span><span class="sxs-lookup"><span data-stu-id="4d45a-340">At runtime, check the device family that the app is running on, and navigate to the correct page like this.</span></span>

```csharp
if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Tablet")
{
    rootFrame.Navigate(typeof(MainPage_Tablet), e.Arguments);
}
else
{
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
}
```

<span data-ttu-id="4d45a-341">さまざまな条件に従って移動先のページを決定することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d45a-341">You can also use different criteria to determine which page to navigate to.</span></span> <span data-ttu-id="4d45a-342">他の例については、[カスタマイズされた複数のビューのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620636)に関するページをご覧ください。このサンプルでは、[**GetIntegratedDisplaySize**](https://msdn.microsoft.com/library/windows/apps/xaml/dn904185.aspx) 関数を使って、統合ディスプレイの物理サイズを確認しています。</span><span class="sxs-lookup"><span data-stu-id="4d45a-342">For more examples, see the [Tailored multiple views sample](http://go.microsoft.com/fwlink/p/?LinkId=620636), which uses the [**GetIntegratedDisplaySize**](https://msdn.microsoft.com/library/windows/apps/xaml/dn904185.aspx) function to check the physical size of an integrated display.</span></span>

## <a name="related-topics"></a><span data-ttu-id="4d45a-343">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4d45a-343">Related topics</span></span>
- [<span data-ttu-id="4d45a-344">チュートリアル: アダプティブ レイアウトの作成</span><span class="sxs-lookup"><span data-stu-id="4d45a-344">Tutorial: Create adaptive layouts</span></span>](../basics/xaml-basics-adaptive-layout.md)
- [<span data-ttu-id="4d45a-345">レスポンシブ手法のサンプル (GitHub)</span><span class="sxs-lookup"><span data-stu-id="4d45a-345">Responsiveness techniques sample (GitHub)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlResponsiveTechniques)
- [<span data-ttu-id="4d45a-346">状態トリガーのサンプル (GitHub)</span><span class="sxs-lookup"><span data-stu-id="4d45a-346">State triggers sample (GitHub)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlStateTriggers)
- [<span data-ttu-id="4d45a-347">調整した複数のビューのサンプル (GitHub) </span><span class="sxs-lookup"><span data-stu-id="4d45a-347">Tailored multiple views sample (GitHub)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlTailoredMultipleViews)
