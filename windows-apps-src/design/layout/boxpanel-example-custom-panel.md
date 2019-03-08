---
Description: カスタム Panel クラスのコードの記述、ArrangeOverride メソッドと MeasureOverride メソッドの実装、Children プロパティの使用について説明します。
MS-HAID: dev\_ctrl\_layout\_txt.boxpanel\_example\_custom\_panel
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: BoxPanel、カスタム パネルの例 (Windows アプリ)
ms.assetid: 981999DB-81B1-4B9C-A786-3025B62B74D6
label: BoxPanel, an example custom panel
template: detail.hbs
op-migration-status: ready
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 42b62e46c8adea771a1b7719d24e99f77f765039
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620127"
---
# <a name="boxpanel-an-example-custom-panel"></a><span data-ttu-id="892b1-104">BoxPanel、カスタム パネルの例</span><span class="sxs-lookup"><span data-stu-id="892b1-104">BoxPanel, an example custom panel</span></span>

 

<span data-ttu-id="892b1-105">カスタム [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) クラスのコードの記述、[**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) メソッドと [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) メソッドの実装、[**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) プロパティの使用について説明します。</span><span class="sxs-lookup"><span data-stu-id="892b1-105">Learn to write code for a custom [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) class, implementing [**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) and [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) methods, and using the [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) property.</span></span> 

> <span data-ttu-id="892b1-106">**重要な Api**:[**パネル**](https://msdn.microsoft.com/library/windows/apps/br227511)、 [ **ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711)、[**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730)</span><span class="sxs-lookup"><span data-stu-id="892b1-106">**Important APIs**: [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511), [**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711),[**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730)</span></span> 

<span data-ttu-id="892b1-107">コード例ではカスタム パネルの実装を示しますが、さまざまなレイアウト シナリオのパネルのカスタマイズ方法に影響を与えるレイアウトの概念については、詳しく説明していません。</span><span class="sxs-lookup"><span data-stu-id="892b1-107">The example code shows a custom panel implementation, but we don't devote a lot of time explaining the layout concepts that influence how you can customize a panel for different layout scenarios.</span></span> <span data-ttu-id="892b1-108">このようなレイアウトの概念や、自分の特定のレイアウト シナリオへの適用方法に関する詳細情報が必要な場合は、「[XAML カスタム パネルの概要](custom-panels-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="892b1-108">If you want more info about these layout concepts and how they might apply to your particular layout scenario, see [XAML custom panels overview](custom-panels-overview.md).</span></span>

<span data-ttu-id="892b1-109">*パネル*は、XAML レイアウト システムが実行されて、アプリの UI が表示されるときに、含まれている子要素のレイアウト動作を提供するオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="892b1-109">A *panel* is an object that provides a layout behavior for child elements it contains, when the XAML layout system runs and your app UI is rendered.</span></span> <span data-ttu-id="892b1-110">[  **Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) クラスからカスタム クラスを派生させて、XAML レイアウトのカスタム パネルを定義できます。</span><span class="sxs-lookup"><span data-stu-id="892b1-110">You can define custom panels for XAML layout by deriving a custom class from the [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) class.</span></span> <span data-ttu-id="892b1-111">パネルの動作は、[**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) メソッドと [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) メソッドをオーバーライドすることで子要素を評価して配置するロジックを提供して実行します。</span><span class="sxs-lookup"><span data-stu-id="892b1-111">You provide behavior for your panel by overriding the [**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) and [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) methods, supplying logic that measures and arranges the child elements.</span></span> <span data-ttu-id="892b1-112">この例は、**Panel** から派生しています。</span><span class="sxs-lookup"><span data-stu-id="892b1-112">This example derives from **Panel**.</span></span> <span data-ttu-id="892b1-113">**Panel** から開始した場合、**ArrangeOverride** メソッドと **MeasureOverride** メソッドには起動動作がありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-113">When you start from **Panel**, **ArrangeOverride** and **MeasureOverride** methods don't have a starting behavior.</span></span> <span data-ttu-id="892b1-114">コードが提供するゲートウェイによって、子要素が XAML レイアウト システムに認識され、UI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-114">Your code is providing the gateway by which child elements become known to the XAML layout system and get rendered in the UI.</span></span> <span data-ttu-id="892b1-115">したがって、コードがすべての子要素について説明し、レイアウト システムが想定しているパターンに従うことが実際に重要です。</span><span class="sxs-lookup"><span data-stu-id="892b1-115">So, it's really important that your code accounts for all child elements and follows the patterns the layout system expects.</span></span>

## <a name="your-layout-scenario"></a><span data-ttu-id="892b1-116">レイアウト シナリオ</span><span class="sxs-lookup"><span data-stu-id="892b1-116">Your layout scenario</span></span>

<span data-ttu-id="892b1-117">カスタム パネルを定義することは、レイアウト シナリオを定義することです。</span><span class="sxs-lookup"><span data-stu-id="892b1-117">When you define a custom panel, you're defining a layout scenario.</span></span>

<span data-ttu-id="892b1-118">レイアウト シナリオは、次によって表現されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-118">A layout scenario is expressed through:</span></span>

-   <span data-ttu-id="892b1-119">子要素が作成されたときのパネルの動作</span><span class="sxs-lookup"><span data-stu-id="892b1-119">What the panel will do when it has child elements</span></span>
-   <span data-ttu-id="892b1-120">パネル自体のスペースが制約されるタイミング</span><span class="sxs-lookup"><span data-stu-id="892b1-120">When the panel has constraints on its own space</span></span>
-   <span data-ttu-id="892b1-121">最終的に子要素の UI レイアウトとして描画される測定値、配置、サイズのすべてを、パネルのロジックが決定する方法</span><span class="sxs-lookup"><span data-stu-id="892b1-121">How the logic of the panel determines all the measurements, placement, positions, and sizings that eventually result in a rendered UI layout of children</span></span>

<span data-ttu-id="892b1-122">この点を考慮して、特定のシナリオが使用する `BoxPanel` を次に示します。</span><span class="sxs-lookup"><span data-stu-id="892b1-122">With that in mind, the `BoxPanel` shown here is for a particular scenario.</span></span> <span data-ttu-id="892b1-123">この例でコードを最優先するために、ここではシナリオを詳しくは説明しません。その代わり、必要な手順とコーディング パターンについて重点的に説明します。</span><span class="sxs-lookup"><span data-stu-id="892b1-123">In the interest of keeping the code foremost in this example, we won't explain the scenario in detail yet, and instead concentrate on the steps needed and the coding patterns.</span></span> <span data-ttu-id="892b1-124">最初にシナリオについて詳しく知りたい場合は、この後にある「[`BoxPanel` のシナリオ](#the-scenario-for-boxpanel)」を参照した後、コードの説明に戻ってください。</span><span class="sxs-lookup"><span data-stu-id="892b1-124">If you want to know more about the scenario first, skip ahead to ["The scenario for `BoxPanel`"](#the-scenario-for-boxpanel), and then come back to the code.</span></span>

## <a name="start-by-deriving-from-panel"></a><span data-ttu-id="892b1-125">**Panel** からの派生で開始する</span><span class="sxs-lookup"><span data-stu-id="892b1-125">Start by deriving from **Panel**</span></span>

<span data-ttu-id="892b1-126">まず、[**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) からカスタム クラスを派生させます。</span><span class="sxs-lookup"><span data-stu-id="892b1-126">Start by deriving a custom class from [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511).</span></span> <span data-ttu-id="892b1-127">このために最も簡単と思われる方法は、このクラスのための別のコード ファイルを定義することです。これには、Microsoft Visual Studio の**ソリューション エクスプローラー**でプロジェクトに対してコンテキスト メニューの **[追加]** | **[新しい項目]** | **[クラス]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="892b1-127">Probably the easiest way to do this is to define a separate code file for this class, using the **Add** | **New Item** | **Class** context menu options for a project from the **Solution Explorer** in Microsoft Visual Studio.</span></span> <span data-ttu-id="892b1-128">このクラス (とファイル) に、`BoxPanel` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="892b1-128">Name the class (and file) `BoxPanel`.</span></span>

<span data-ttu-id="892b1-129">クラスのテンプレート ファイルが、多くの **using** ステートメントで始まることはありません。このステートメントは、特にユニバーサル Windows プラットフォーム (UWP) アプリ用ではないためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-129">The template file for a class doesn't start with many **using** statements because it's not specifically for Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="892b1-130">まず、**using** ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="892b1-130">So first, add **using** statements.</span></span> <span data-ttu-id="892b1-131">また、テンプレート ファイルはいくつかの **using** ステートメントで始まっていますが、おそらく不要と思われるため、削除することができます。</span><span class="sxs-lookup"><span data-stu-id="892b1-131">The template file also starts with a few **using** statements that you probably don't need, and can be deleted.</span></span> <span data-ttu-id="892b1-132">次に示すのは、一般的なカスタム パネル コードに必要となる型を解決できる **using** ステートメントの候補の一覧です。</span><span class="sxs-lookup"><span data-stu-id="892b1-132">Here's a suggested list of **using** statements that can resolve types you'll need for typical custom panel code:</span></span>

```CSharp
using System;
using System.Collections.Generic; // if you need to cast IEnumerable for iteration, or define your own collection properties
using Windows.Foundation; // Point, Size, and Rect
using Windows.UI.Xaml; // DependencyObject, UIElement, and FrameworkElement
using Windows.UI.Xaml.Controls; // Panel
using Windows.UI.Xaml.Media; // if you need Brushes or other utilities
```

<span data-ttu-id="892b1-133">これで [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511) を解決できるので、これを `BoxPanel` の基底クラスにします。</span><span class="sxs-lookup"><span data-stu-id="892b1-133">Now that you can resolve [**Panel**](https://msdn.microsoft.com/library/windows/apps/br227511), make it the base class of `BoxPanel`.</span></span> <span data-ttu-id="892b1-134">また、`BoxPanel` を公開します。</span><span class="sxs-lookup"><span data-stu-id="892b1-134">Also, make `BoxPanel` public:</span></span>

```CSharp
public class BoxPanel : Panel
{
}
```

<span data-ttu-id="892b1-135">クラス レベルでは、複数の論理関数で共有される **int** 値と **double** 値をいくつか定義しますが、これらは、パブリック API として公開する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-135">At the class level, define some **int** and **double** values that will be shared by several of your logic functions, but which won't need to be exposed as public API.</span></span> <span data-ttu-id="892b1-136">例では、これらの名前は `maxrc`、`rowcount`、`colcount`、`cellwidth`、`cellheight`、`maxcellheight`、`aspectratio` です。</span><span class="sxs-lookup"><span data-stu-id="892b1-136">In the example, these are named: `maxrc`, `rowcount`, `colcount`, `cellwidth`, `cellheight`, `maxcellheight`, `aspectratio`.</span></span>

<span data-ttu-id="892b1-137">これを行った後、コード ファイル全体は次のようになります (ここにある理由はわかっているので、**using** のコメントは削除します)。</span><span class="sxs-lookup"><span data-stu-id="892b1-137">After you've done this, the complete code file looks like this (removing comments on **using**, now that you know why we have them):</span></span>

```CSharp
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class BoxPanel : Panel 
{
    int maxrc, rowcount, colcount;
    double cellwidth, cellheight, maxcellheight, aspectratio;
}
```

<span data-ttu-id="892b1-138">これ以降は、メソッドのオーバーライド、依存関係プロパティなどのサポートするものなどのメンバー定義を 1 つずつ示します。</span><span class="sxs-lookup"><span data-stu-id="892b1-138">From here on out, we'll be showing you one member definition at a time, be that a method override or something supporting such as a dependency property.</span></span> <span data-ttu-id="892b1-139">これらは、上に示したスケルトンに任意の順序で追加できます。最終的なコードを示すまで、スニペットでは、**using** ステートメントとクラス スコープの定義のいずれも再び示すことはありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-139">You can add these to the skeleton above in any order, and we won't be showing the **using** statements or the definition of the class scope again in the snippets until we show the final code.</span></span>

## <a name="measureoverride"></a><span data-ttu-id="892b1-140">**MeasureOverride**</span><span class="sxs-lookup"><span data-stu-id="892b1-140">**MeasureOverride**</span></span>


```CSharp
protected override Size MeasureOverride(Size availableSize)
{
    Size returnSize;
    // Determine the square that can contain this number of items.
    maxrc = (int)Math.Ceiling(Math.Sqrt(Children.Count));
    // Get an aspect ratio from availableSize, decides whether to trim row or column.
    aspectratio = availableSize.Width / availableSize.Height;

    // Now trim this square down to a rect, many times an entire row or column can be omitted.
    if (aspectratio > 1)
    {
        rowcount = maxrc;
        colcount = (maxrc > 2 && Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
    } 
    else 
    {
        rowcount = (maxrc > 2 && Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
        colcount = maxrc;
    }

    // Now that we have a column count, divide available horizontal, that's our cell width.
    cellwidth = (int)Math.Floor(availableSize.Width / colcount);
    // Next get a cell height, same logic of dividing available vertical by rowcount.
    cellheight = Double.IsInfinity(availableSize.Height) ? Double.PositiveInfinity : availableSize.Height / rowcount;
           
    foreach (UIElement child in Children)
    {
        child.Measure(new Size(cellwidth, cellheight));
        maxcellheight = (child.DesiredSize.Height > maxcellheight) ? child.DesiredSize.Height : maxcellheight;
    }
    return LimitUnboundedSize(availableSize);
}
```

<span data-ttu-id="892b1-141">[  **MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) の実装に必要なパターンは、[**Panel.Children**](https://msdn.microsoft.com/library/windows/apps/br227514) の各要素のループ処理です。</span><span class="sxs-lookup"><span data-stu-id="892b1-141">The necessary pattern of a [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) implementation is the loop through each element in [**Panel.Children**](https://msdn.microsoft.com/library/windows/apps/br227514).</span></span> <span data-ttu-id="892b1-142">これらの要素のそれぞれで、[**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) メソッドを必ず呼び出します。</span><span class="sxs-lookup"><span data-stu-id="892b1-142">Always call the [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) method on each of these elements.</span></span> <span data-ttu-id="892b1-143">**Measure** には、型 [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="892b1-143">**Measure** has a parameter of type [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995).</span></span> <span data-ttu-id="892b1-144">ここで渡しているのは、この特定の子要素が表示できるようにパネルがコミットしているサイズです。</span><span class="sxs-lookup"><span data-stu-id="892b1-144">What you're passing here is the size that your panel is committing to have available for that particular child element.</span></span> <span data-ttu-id="892b1-145">したがって、ループ処理を行い、**Measure** の呼び出しを開始する前に、各セルが使用可能なスペースの量を知る必要があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-145">So, before you can do the loop and start calling **Measure**, you need to know how much space each cell can devote.</span></span> <span data-ttu-id="892b1-146">**MeasureOverride** メソッド自体には、*availableSize* 値があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-146">From the **MeasureOverride** method itself, you have the *availableSize* value.</span></span> <span data-ttu-id="892b1-147">これは、最初に呼び出されたこの **MeasureOverride** のトリガーであった **Measure** を呼び出したときにパネルの親が使用したサイズです。</span><span class="sxs-lookup"><span data-stu-id="892b1-147">That is the size that the panel's parent used when it called **Measure**, which was the trigger for this **MeasureOverride** being called in the first place.</span></span> <span data-ttu-id="892b1-148">そのため、一般的なロジックは、各子要素がパネルの *availableSize* 全体のスペースを分割するためのスキームを作成することです。</span><span class="sxs-lookup"><span data-stu-id="892b1-148">So a typical logic is to devise a scheme whereby each child element divides the space of the panel's overall *availableSize*.</span></span> <span data-ttu-id="892b1-149">そして、サイズの各部分を各子要素の **Measure** に渡します。</span><span class="sxs-lookup"><span data-stu-id="892b1-149">You then pass each division of size to **Measure** of each child element.</span></span>

<span data-ttu-id="892b1-150">`BoxPanel` でのサイズの分割方法は、非常に簡単です。多数のボックスにスペースを分割しますが、これは、主に項目の数で制御されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-150">How `BoxPanel` divides size is fairly simple: it divides its space into a number of boxes that's largely controlled by the number of items.</span></span> <span data-ttu-id="892b1-151">ボックスのサイズは、行と列の数、および使用可能なサイズに基づいて設定されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-151">Boxes are sized based on row and column count and the available size.</span></span> <span data-ttu-id="892b1-152">正方形の 1 行または 1 列は不要な場合があるため、破棄され、行と列の割合から見ると、パネルは正方形ではなく四角形になります。</span><span class="sxs-lookup"><span data-stu-id="892b1-152">Sometimes one row or column from a square isn't needed, so it's dropped and the panel becomes a rectangle rather than square in terms of its row : column ratio.</span></span> <span data-ttu-id="892b1-153">このロジックに到達する過程の詳細については、この後の[「BoxPanel のシナリオ」](#the-scenario-for-boxpanel)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="892b1-153">For more info about how this logic was arrived at, skip ahead to ["The scenario for BoxPanel"](#the-scenario-for-boxpanel).</span></span>

<span data-ttu-id="892b1-154">それでは、測定パスでは何が行われるのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="892b1-154">So what does the measure pass do?</span></span> <span data-ttu-id="892b1-155">ここでは、[**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) が呼び出された各要素に読み取り専用の [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) プロパティの値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-155">It sets a value for the read-only [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) property on each element where [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) was called.</span></span> <span data-ttu-id="892b1-156">**DesiredSize** 値があることは、配置パスに到達した後に重要になる可能性があります。なぜなら、**DesiredSize** によって、配置の際や最終的な描画で可能または必要なサイズが伝えられるためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-156">Having a **DesiredSize** value is possibly important once you get to the arrange pass, because the **DesiredSize** communicates what the size can or should be when arranging and in the final rendering.</span></span> <span data-ttu-id="892b1-157">自分のロジックで **DesiredSize** を使用しない場合でも、システムでは必要になります。</span><span class="sxs-lookup"><span data-stu-id="892b1-157">Even if you don't use **DesiredSize** in your own logic, the system still needs it.</span></span>

<span data-ttu-id="892b1-158">このパネルが、*availableSize* の高さコンポーネントが無限である場合に使われる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-158">It's possible for this panel to be used when the height component of *availableSize* is unbounded.</span></span> <span data-ttu-id="892b1-159">これに該当する場合、パネルには、分割するための既知の高さがありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-159">If that's true, the panel doesn't have a known height to divide.</span></span> <span data-ttu-id="892b1-160">この場合、測定パスのロジックは、有限の高さがまだないことを各子要素に知らせます。</span><span class="sxs-lookup"><span data-stu-id="892b1-160">In this case, the logic for the measure pass informs each child that it doesn't have a bounded height, yet.</span></span> <span data-ttu-id="892b1-161">知らせるには、[**Size.Height**](https://msdn.microsoft.com/library/windows/apps/hh763910) が無限である子の [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) 呼び出しに [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) を渡します。</span><span class="sxs-lookup"><span data-stu-id="892b1-161">It does so by passing a [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) to the [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) call for children where [**Size.Height**](https://msdn.microsoft.com/library/windows/apps/hh763910) is infinite.</span></span> <span data-ttu-id="892b1-162">これは適正な動作です。</span><span class="sxs-lookup"><span data-stu-id="892b1-162">That's legal.</span></span> <span data-ttu-id="892b1-163">**Measure** が呼び出されるときのロジックは、[**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) が、**Measure** に渡されたものの最小値、または、明示的に設定された [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) と [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) などの要因からのその要素の自然なサイズの最小値として設定されていることです。</span><span class="sxs-lookup"><span data-stu-id="892b1-163">When **Measure** is called, the logic is that the [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) is set as the minimum of these: what was passed to **Measure**, or that element's natural size from factors such as explicitly-set [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) and [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width).</span></span>

> [!NOTE]
> <span data-ttu-id="892b1-164">内部ロジック[ **StackPanel** ](https://msdn.microsoft.com/library/windows/apps/br209635)この動作があります。**StackPanel**に無限のディメンション値が渡された[**メジャー** ](https://msdn.microsoft.com/library/windows/apps/br208952)向きディメンション内の子に制約がないことを示す子にします。</span><span class="sxs-lookup"><span data-stu-id="892b1-164">The internal logic of [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) also has this behavior: **StackPanel** passes an infinite dimension value to [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) on children, indicating that there is no constraint on children in the orientation dimension.</span></span> <span data-ttu-id="892b1-165">**StackPanel** は、通常、動的にサイズ設定され、そのサイズ内で拡大されるスタックにすべての子が配置されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-165">**StackPanel** typically sizes itself dynamically, to accommodate all children in a stack that grows in that dimension.</span></span>

<span data-ttu-id="892b1-166">ただし、パネル自体は、[**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) から、無限値を持つ [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) を返すことができません。返すと、レイアウト時に例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="892b1-166">However, the panel itself can't return a [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) with an infinite value from [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730); that throws an exception during layout.</span></span> <span data-ttu-id="892b1-167">したがって、ロジックの一部は、子が要求する最大の高さを調べ、それが既にパネル自体のサイズ制約によるものでない場合は、その高さをセルの高さとして使うことです。</span><span class="sxs-lookup"><span data-stu-id="892b1-167">So, part of the logic is to find out the maximum height that any child requests, and use that height as the cell height in case that isn't coming from the panel's own size constraints already.</span></span> <span data-ttu-id="892b1-168">次に示すのは、前のコードで参照されるヘルパー関数 `LimitUnboundedSize` です。これは、このセルの最大の高さを受け取り、これを使って、返すことができる有限の高さをパネルに与えます。また、配置パスの開始前に `cellheight` が有限数であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="892b1-168">Here's the helper function `LimitUnboundedSize` that was referenced in previous code, which then takes that maximum cell height and uses it to give the panel a finite height to return, as well as assuring that `cellheight` is a finite number before the arrange pass is initiated:</span></span>

```CSharp
// This method is called only if one of the availableSize dimensions of measure is infinite.
// That can happen to height if the panel is close to the root of main app window.
// In this case, base the height of a cell on the max height from desired size
// and base the height of the panel on that number times the #rows.

Size LimitUnboundedSize(Size input)
{
    if (Double.IsInfinity(input.Height))
    {
        input.Height = maxcellheight * colcount;
        cellheight = maxcellheight;
    }
    return input;
}
```

## <a name="arrangeoverride"></a><span data-ttu-id="892b1-169">**ArrangeOverride**</span><span class="sxs-lookup"><span data-stu-id="892b1-169">**ArrangeOverride**</span></span>

```CSharp
protected override Size ArrangeOverride(Size finalSize)
{
     int count = 1
     double x, y;
     foreach (UIElement child in Children)
     {
          x = (count - 1) % colcount * cellwidth;
          y = ((int)(count - 1) / colcount) * cellheight;
          Point anchorPoint = new Point(x, y);
          child.Arrange(new Rect(anchorPoint, child.DesiredSize));
          count++;
     }
     return finalSize;
}
```

<span data-ttu-id="892b1-170">[  **ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) の実装に必要なパターンは、[**Panel.Children**](https://msdn.microsoft.com/library/windows/apps/br227514) の各要素のループ処理です。</span><span class="sxs-lookup"><span data-stu-id="892b1-170">The necessary pattern of an [**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) implementation is the loop through each element in [**Panel.Children**](https://msdn.microsoft.com/library/windows/apps/br227514).</span></span> <span data-ttu-id="892b1-171">これらの要素のそれぞれで、[**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) メソッドを必ず呼び出します。</span><span class="sxs-lookup"><span data-stu-id="892b1-171">Always call the [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) method on each of these elements.</span></span>

<span data-ttu-id="892b1-172">[  **MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730) の場合ほど、計算が多くないことに注意してください。これが一般的です。</span><span class="sxs-lookup"><span data-stu-id="892b1-172">Note how there aren't as many calculations as in [**MeasureOverride**](https://msdn.microsoft.com/library/windows/apps/br208730); that's typical.</span></span> <span data-ttu-id="892b1-173">子のサイズは、パネル自体の **MeasureOverride** ロジックから、または測定パスで設定された各子要素の [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) 値から既にわかっています。</span><span class="sxs-lookup"><span data-stu-id="892b1-173">The size of children is already known from the panel's own **MeasureOverride** logic, or from the [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) value of each child set during the measure pass.</span></span> <span data-ttu-id="892b1-174">ただし、各子要素が表示されるパネル内の場所を決定する必要がまだあります。</span><span class="sxs-lookup"><span data-stu-id="892b1-174">However, we still need to decide the location within the panel where each child will appear.</span></span> <span data-ttu-id="892b1-175">一般的なパネルでは、各子要素が別の場所に描画されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-175">In a typical panel, each child should render at a different position.</span></span> <span data-ttu-id="892b1-176">要素の重なりを作成するパネルは、一般的なシナリオとして好ましくありません (ただし、実際に意図したシナリオである場合は、意図的な重なりがあるパネルを作成することは問題外ではありません)。</span><span class="sxs-lookup"><span data-stu-id="892b1-176">A panel that creates overlapping elements isn't desirable for typical scenarios (although it's not out of the question to create panels that have purposeful overlaps, if that's really your intended scenario).</span></span>

<span data-ttu-id="892b1-177">このパネルは、行と列の概念で配置されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-177">This panel arranges by the concept of rows and columns.</span></span> <span data-ttu-id="892b1-178">行と列の数は既に計算されています (測定値に必要であったため)。</span><span class="sxs-lookup"><span data-stu-id="892b1-178">The number of rows and columns was already calculated (it was necessary for measurement).</span></span> <span data-ttu-id="892b1-179">したがって、行と列の図形、および各セルの既知のサイズが、このパネルに含まれる各要素の描画位置 (`anchorPoint`) の定義のロジックに使用されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-179">So now the shape of the rows and columns plus the known sizes of each cell contribute to the logic of defining a rendering position (the `anchorPoint`) for each element that this panel contains.</span></span> <span data-ttu-id="892b1-180">[  **Point**](https://msdn.microsoft.com/library/windows/apps/br225870) は、測定により既にわかっている [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) と共に、[**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994) を作成する 2 つのコンポーネントとして使われます。</span><span class="sxs-lookup"><span data-stu-id="892b1-180">That [**Point**](https://msdn.microsoft.com/library/windows/apps/br225870), along with the [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) already known from measure, are used as the two components that construct a [**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994).</span></span> <span data-ttu-id="892b1-181">**Rect** は [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) の入力タイプです。</span><span class="sxs-lookup"><span data-stu-id="892b1-181">**Rect** is the input type for [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914).</span></span>

<span data-ttu-id="892b1-182">パネルでは、そのコンテンツのクリップが必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-182">Panels sometimes need to clip their content.</span></span> <span data-ttu-id="892b1-183">クリップが必要な場合、クリップされたサイズは、[**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) にあるサイズです。これは、[**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) ロジックがこのサイズを、**Measure** に渡された最小値、またはその他の自然なサイズの要因として設定するためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-183">If they do, the clipped size is the size that's present in [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921), because the [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) logic sets it as the minimum of what was passed to **Measure**, or other natural size factors.</span></span> <span data-ttu-id="892b1-184">したがって、[**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) では、特にクリップを確認する必要はありません。クリップは、各 **Arrange** 呼び出しを介して **DesiredSize** を渡すことに基づいて発生するだけです。</span><span class="sxs-lookup"><span data-stu-id="892b1-184">So you don't typically need to specifically check for clipping during [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914); the clipping just happens based on passing the **DesiredSize** through to each **Arrange** call.</span></span>

<span data-ttu-id="892b1-185">描画位置を定義するために必要なすべての情報が他の方法でわかっている場合は、ループ処理中に常に数を数える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-185">You don't always need a count while going through the loop if all the info you need for defining the rendering position is known by other means.</span></span> <span data-ttu-id="892b1-186">たとえば、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) レイアウト ロジックで、[**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) コレクションでの位置は重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-186">For example, in [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) layout logic, the position in the [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) collection doesn't matter.</span></span> <span data-ttu-id="892b1-187">**Canvas** の各要素の位置を決定するために必要なすべての情報は、配置ロジックの一部として子の [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) 値と [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) 値を読み取ることで得られるためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-187">All the info needed to position each element in a **Canvas** is known by reading [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) and [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) values of children as part of the arrange logic.</span></span> <span data-ttu-id="892b1-188">ただし、`BoxPanel` のロジックでは、新しい行の開始と、*y* 値のオフセットのタイミングを知るために、数を数えて *colcount* と比較する必要があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-188">The `BoxPanel` logic happens to need a count to compare to the *colcount* so it's known when to begin a new row and offset the *y* value.</span></span>

<span data-ttu-id="892b1-189">入力 *finalSize* と、[**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) の実装から返す [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) が同じであることは一般的です。</span><span class="sxs-lookup"><span data-stu-id="892b1-189">It's typical that the input *finalSize* and the [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) you return from a [**ArrangeOverride**](https://msdn.microsoft.com/library/windows/apps/br208711) implementation are the same.</span></span> <span data-ttu-id="892b1-190">その理由について詳しくは、「[XAML カスタム パネルの概要](custom-panels-overview.md)」の「**ArrangeOverride**」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="892b1-190">For more info about why, see "**ArrangeOverride**" section of [XAML custom panels overview](custom-panels-overview.md).</span></span>

## <a name="a-refinement-controlling-the-row-vs-column-count"></a><span data-ttu-id="892b1-191">改良: 行と列の数の制御</span><span class="sxs-lookup"><span data-stu-id="892b1-191">A refinement: controlling the row vs. column count</span></span>

<span data-ttu-id="892b1-192">このパネルは、コンパイルして、そのまま使用できます。</span><span class="sxs-lookup"><span data-stu-id="892b1-192">You could compile and use this panel just as it is now.</span></span> <span data-ttu-id="892b1-193">ただし、もう 1 つ改良を加えます。</span><span class="sxs-lookup"><span data-stu-id="892b1-193">However, we'll add one more refinement.</span></span> <span data-ttu-id="892b1-194">ここで示したコードで、ロジックは、縦横比で最も長い側に、追加の行または列を設定しています。</span><span class="sxs-lookup"><span data-stu-id="892b1-194">In the code just shown, the logic puts the extra row or column on the side that's longest in aspect ratio.</span></span> <span data-ttu-id="892b1-195">ただし、セルの形状をさらに制御するには、パネル自体の縦横比が "縦長" であっても、3×4 ではなく、4×3 のセル セットを選択する方が適切である場合があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-195">But for greater control over the shapes of cells, it might be desirable to choose a 4x3 set of cells instead of 3x4 even if the panel's own aspect ratio is "portrait."</span></span> <span data-ttu-id="892b1-196">そのため、その動作を制御するためにパネルのユーザーが設定できる、オプションの依存関係プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="892b1-196">So we'll add an optional dependency property that the panel consumer can set to control that behavior.</span></span> <span data-ttu-id="892b1-197">この依存関係プロパティ定義は、次に示すように、非常に基本的です。</span><span class="sxs-lookup"><span data-stu-id="892b1-197">Here's the dependency property definition, which is very basic:</span></span>

```CSharp
public static readonly DependencyProperty UseOppositeRCRatioProperty =
   DependencyProperty.Register("UseOppositeRCRatio", typeof(bool), typeof(BoxPanel), null);

public bool UseSquareCells
{
    get { return (bool)GetValue(UseOppositeRCRatioProperty); }
    set { SetValue(UseOppositeRCRatioProperty, value); }
}
```

<span data-ttu-id="892b1-198">次に、`UseOppositeRCRatio` の使用が測定ロジックに与える影響を説明します。</span><span class="sxs-lookup"><span data-stu-id="892b1-198">And here's how using `UseOppositeRCRatio` impacts the measure logic.</span></span> <span data-ttu-id="892b1-199">実際に行われていることは、`rowcount` と `colcount` が、`maxrc` と実際の縦横比から派生しているしくみの変更だけです。このために、対応するサイズの違いが各セルにあります。</span><span class="sxs-lookup"><span data-stu-id="892b1-199">Really all it's doing is changing how `rowcount` and `colcount` are derived from `maxrc` and the true aspect ratio, and there are corresponding size differences for each cell because of that.</span></span> <span data-ttu-id="892b1-200">`UseOppositeRCRatio` が **true** である場合は、行と列を数えるために使う前に実際の縦横比の値が逆になります。</span><span class="sxs-lookup"><span data-stu-id="892b1-200">When `UseOppositeRCRatio` is **true**, it inverts the value of the true aspect ratio before using it for row and column counts.</span></span>

```CSharp
if (UseOppositeRCRatio) { aspectratio = 1 / aspectratio;}
```

## <a name="the-scenario-for-boxpanel"></a><span data-ttu-id="892b1-201">BoxPanel のシナリオ</span><span class="sxs-lookup"><span data-stu-id="892b1-201">The scenario for BoxPanel</span></span>

<span data-ttu-id="892b1-202">`BoxPanel` の特定のシナリオは、子項目の数がわかっており、パネルで使用できるとわかっているスペースを分割することが、スペースの分割方法の主な決定要因の 1 つであるパネルです。</span><span class="sxs-lookup"><span data-stu-id="892b1-202">The particular scenario for `BoxPanel` is that it's a panel where one of the main determinants of how to divide space is by knowing the number of child items, and dividing the known available space for the panel.</span></span> <span data-ttu-id="892b1-203">パネルの形状は本質的に四角形です。</span><span class="sxs-lookup"><span data-stu-id="892b1-203">Panels are innately rectangle shapes.</span></span> <span data-ttu-id="892b1-204">多くのパネルは、その四角形のスペースをさらに四角形に分割して動作します。これは、セルに対する [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の動作です。</span><span class="sxs-lookup"><span data-stu-id="892b1-204">Many panels operate by dividing that rectangle space into further rectangles; that's what [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) does for its cells.</span></span> <span data-ttu-id="892b1-205">**Grid** の場合は、セルのサイズが [**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/br209324) と [**RowDefinition**](https://msdn.microsoft.com/library/windows/apps/br227606) の値によって設定され、これらの値が使用される正確なセルが要素によって、[**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/hh759795) 添付プロパティと [**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/hh759774) 添付プロパティで宣言されます。</span><span class="sxs-lookup"><span data-stu-id="892b1-205">In **Grid**'s case, the size of the cells is set by [**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/br209324) and [**RowDefinition**](https://msdn.microsoft.com/library/windows/apps/br227606) values, and elements declare the exact cell they go into with [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/hh759795) and [**Grid.Column**](https://msdn.microsoft.com/library/windows/apps/hh759774) attached properties.</span></span> <span data-ttu-id="892b1-206">**Grid** から適切なレイアウトを取得するには、通常、子要素の数を事前に知っている必要があります。これは、セルの数が十分であり、各子要素がそのセル サイズに収まるように自身の添付プロパティを設定する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-206">Getting good layout from a **Grid** usually requires knowing the number of child elements beforehand, so that there are enough cells and each child element sets its attached properties to fit into its own cell.</span></span>

<span data-ttu-id="892b1-207">では、子の数が動的な場合はどうでしょうか。</span><span class="sxs-lookup"><span data-stu-id="892b1-207">But what if the number of children is dynamic?</span></span> <span data-ttu-id="892b1-208">これは、確実にあり得ます。アプリ コードは、UI を更新する価値があるだけ重要であると考えられる動的ランタイム状態に対応して、コレクションに項目を追加できます。</span><span class="sxs-lookup"><span data-stu-id="892b1-208">That's certainly possible; your app code can add items to collections, in response to any dynamic run-time condition you consider to be important enough to be worth updating your UI.</span></span> <span data-ttu-id="892b1-209">コレクション/ビジネス オブジェクトのバッキングにデータ バインドを使っている場合は、このような更新プログラムの取得と UI の更新が自動的に処理されます。これは、多くの場合、優先して使われる手法です (「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="892b1-209">If you're using data binding to backing collections/business objects, getting such updates and updating the UI is handled automatically, so that's often the preferred technique (see [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946)).</span></span>

<span data-ttu-id="892b1-210">ただし、アプリのすべてのシナリオがデータ バインディングに対応しているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="892b1-210">But not all app scenarios lend themselves to data binding.</span></span> <span data-ttu-id="892b1-211">場合によっては、新しい UI 要素を実行時に作成し、表示されるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="892b1-211">Sometimes, you need to create new UI elements at runtime and make them visible.</span></span> <span data-ttu-id="892b1-212">`BoxPanel` は、このようなシナリオで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="892b1-212">`BoxPanel` is for this scenario.</span></span> <span data-ttu-id="892b1-213">子項目の数が変わることは、`BoxPanel` では問題になりません。子の数を使って計算し、既存と新規の両方の子要素がすべて、新しいレイアウトに収まるように調整するためです。</span><span class="sxs-lookup"><span data-stu-id="892b1-213">A changing number of child items is no problem for `BoxPanel` because it's using the child count in calculations, and adjusts both the existing and new child elements into a new layout so they all fit.</span></span>

<span data-ttu-id="892b1-214">`BoxPanel` をさらに拡張する高度なシナリオ (ここでは示されていません) では、動的な子に対応すると同時に、より強力な要因として子の [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) を使って個々のセルのサイズを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="892b1-214">An advanced scenario for extending `BoxPanel` further (not shown here) could both accommodate dynamic children and use a child's [**DesiredSize**](https://msdn.microsoft.com/library/windows/apps/br208921) as a stronger factor for the sizing of individual cells.</span></span> <span data-ttu-id="892b1-215">そして、可変サイズの行または列、または非グリッド形状を使って、「無駄な」スペースを減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="892b1-215">This scenario might use varying row or column sizes or non-grid shapes so that there's less "wasted" space.</span></span> <span data-ttu-id="892b1-216">これには、黄金比と最小サイズの両方の場合に、さまざまなサイズと縦横比の複数の四角形をすべて、それらを含む四角形に収めるための方法が必要です。</span><span class="sxs-lookup"><span data-stu-id="892b1-216">This requires a strategy for how multiple rectangles of various sizes and aspect ratios can all fit into a containing rectangle both for aesthetics and smallest size.</span></span> <span data-ttu-id="892b1-217">`BoxPanel` では、このような方法ではなく、スペースを分割するための単純な手法を使用しています。</span><span class="sxs-lookup"><span data-stu-id="892b1-217">`BoxPanel` doesn't do that; it's using a simpler technique for dividing space.</span></span> <span data-ttu-id="892b1-218">`BoxPanel` の手法は、子の数より多い、最小の正方形を決定することです。</span><span class="sxs-lookup"><span data-stu-id="892b1-218">`BoxPanel`'s technique is to determine the least square number that's greater than the child count.</span></span> <span data-ttu-id="892b1-219">たとえば、9 個の項目は、3×3 の正方形に収まります。</span><span class="sxs-lookup"><span data-stu-id="892b1-219">For example, 9 items would fit in a 3x3 square.</span></span> <span data-ttu-id="892b1-220">10 個の項目には、4×4 の正方形が必要です。</span><span class="sxs-lookup"><span data-stu-id="892b1-220">10 items require a 4x4 square.</span></span> <span data-ttu-id="892b1-221">ただし、多くの場合、項目を収めると同時に、最初の正方形の 1 行または 1 列を削除して、スペースを節約できます。</span><span class="sxs-lookup"><span data-stu-id="892b1-221">However, you can often fit items while still removing one row or column of the starting square, to save space.</span></span> <span data-ttu-id="892b1-222">10 個の項目の例では、4×3 または 3×4 の長方形に収まります。</span><span class="sxs-lookup"><span data-stu-id="892b1-222">In the count=10 example, that fits in a 4x3 or 3x4 rectangle.</span></span>

<span data-ttu-id="892b1-223">10 項目の場合にパネルが、ちょうど収まる 5×2 を選択しないのは不思議に思われます。</span><span class="sxs-lookup"><span data-stu-id="892b1-223">You might wonder why the panel wouldn't instead choose 5x2 for 10 items, because that fits the item number neatly.</span></span> <span data-ttu-id="892b1-224">ただし、実際には、向きがはっきりした縦横比の四角形としてパネルがサイズ設定されることは稀です。</span><span class="sxs-lookup"><span data-stu-id="892b1-224">However, in practice, panels are sized as rectangles that seldom have a strongly oriented aspect ratio.</span></span> <span data-ttu-id="892b1-225">最小正方形の手法は、サイズ設定ロジックを偏らせて、一般的なレイアウトの図形を適切に処理し、セルの形状が極端な縦横比になるサイズ設定を防ぐための 1 つの方法です。</span><span class="sxs-lookup"><span data-stu-id="892b1-225">The least-squares technique is a way to bias the sizing logic to work well with typical layout shapes and not encourage sizing where the cell shapes get odd aspect ratios.</span></span>

## <a name="related-topics"></a><span data-ttu-id="892b1-226">関連トピック</span><span class="sxs-lookup"><span data-stu-id="892b1-226">Related topics</span></span>

<span data-ttu-id="892b1-227">**リファレンス**</span><span class="sxs-lookup"><span data-stu-id="892b1-227">**Reference**</span></span>

* [<span data-ttu-id="892b1-228">**FrameworkElement.ArrangeOverride**</span><span class="sxs-lookup"><span data-stu-id="892b1-228">**FrameworkElement.ArrangeOverride**</span></span>](https://msdn.microsoft.com/library/windows/apps/br208711)
* [<span data-ttu-id="892b1-229">**FrameworkElement.MeasureOverride**</span><span class="sxs-lookup"><span data-stu-id="892b1-229">**FrameworkElement.MeasureOverride**</span></span>](https://msdn.microsoft.com/library/windows/apps/br208730)
* [<span data-ttu-id="892b1-230">**パネル**</span><span class="sxs-lookup"><span data-stu-id="892b1-230">**Panel**</span></span>](https://msdn.microsoft.com/library/windows/apps/br227511)

<span data-ttu-id="892b1-231">**概念**</span><span class="sxs-lookup"><span data-stu-id="892b1-231">**Concepts**</span></span>

* [<span data-ttu-id="892b1-232">配置、余白、および余白</span><span class="sxs-lookup"><span data-stu-id="892b1-232">Alignment, margin, and padding</span></span>](alignment-margin-padding.md)
