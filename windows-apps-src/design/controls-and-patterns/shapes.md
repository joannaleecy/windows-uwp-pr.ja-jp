---
ms.assetid: 54CC0BD4-1961-44D7-AB40-6E8B58E42D65
title: 図形の描画
description: 楕円形、長方形、多角形、パスなどの図形を描画する方法について説明します。 Path クラスは、きわめて複雑なベクター ベースの画像記述言語を XAML UI で視覚化するための手段です。たとえば、ベジエ曲線を描画することができます。
ms.date: 11/16/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a576add7a080874fb0f042748bef7472e04ac817
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610677"
---
# <a name="draw-shapes"></a><span data-ttu-id="0cc62-105">図形の描画</span><span class="sxs-lookup"><span data-stu-id="0cc62-105">Draw shapes</span></span>

<span data-ttu-id="0cc62-106">楕円形、長方形、多角形、パスなどの図形を描画する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-106">Learn how to draw shapes, such as ellipses, rectangles, polygons, and paths.</span></span> <span data-ttu-id="0cc62-107">[  **Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) クラスは、きわめて複雑なベクター ベースの画像記述言語を XAML UI で視覚化するための手段です。たとえば、ベジエ曲線を描画することができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-107">The [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) class is the way to visualize a fairly complex vector-based drawing language in a XAML UI; for example, you can draw Bezier curves.</span></span>

> <span data-ttu-id="0cc62-108">**重要な Api**:[Path クラス](/uwp/api/Windows.UI.Xaml.Shapes.Path)、 [Windows.UI.Xaml.Shapes 名前空間](/uwp/api/Windows.UI.Xaml.Shapes)、 [Windows.UI.Xaml.Media 名前空間](/uwp/api/Windows.UI.Xaml.Media)</span><span class="sxs-lookup"><span data-stu-id="0cc62-108">**Important APIs**: [Path class](/uwp/api/Windows.UI.Xaml.Shapes.Path), [Windows.UI.Xaml.Shapes namespace](/uwp/api/Windows.UI.Xaml.Shapes), [Windows.UI.Xaml.Media namespace](/uwp/api/Windows.UI.Xaml.Media)</span></span>


<span data-ttu-id="0cc62-109">2 つのクラスは、XAML UI の領域の領域を定義します。[**図形**](/uwp/api/Windows.UI.Xaml.Shapes.Shape)クラスと[ **Geometry** ](/uwp/api/Windows.UI.Xaml.Media.Geometry)クラス。</span><span class="sxs-lookup"><span data-stu-id="0cc62-109">Two sets of classes define a region of space in XAML UI: [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) classes and [**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) classes.</span></span> <span data-ttu-id="0cc62-110">これらのクラス間の主な違いは、**Shape** にはブラシが関連付けられ、画面にレンダリングできますが、**Geometry** は単に空間領域を定義するだけで、レンダリングはされない (ただし、別の UI プロパティに情報を提供する働きはある) という点です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-110">The main difference between these classes is that a **Shape** has a brush associated with it and can be rendered to the screen, and a **Geometry** simply defines a region of space and is not rendered unless it helps contribute information to another UI property.</span></span> <span data-ttu-id="0cc62-111">**Shape** は、**Geometry** で境界線が定義される [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) と考えることができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-111">You can think of a **Shape** as a [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) with its boundary defined by a **Geometry**.</span></span> <span data-ttu-id="0cc62-112">このトピックでは、主に **Shape** クラスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-112">This topic covers mainly the **Shape** classes.</span></span>

<span data-ttu-id="0cc62-113">[  **Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) クラスには、[**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line)、[**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse)、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle)、[**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon)、[**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline)、[**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) があります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-113">The [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) classes are [**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line), [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse), [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle), [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon), [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline), and [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path).</span></span> <span data-ttu-id="0cc62-114">中でも **Path** は、任意のジオメトリを定義できる興味深いクラスです。また、[**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) クラスは **Path** の構成要素を定義する方法の 1 つであるため、ここに関与します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-114">**Path** is interesting because it can define an arbitrary geometry, and the [**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) class is involved here because that's one way to define the parts of a **Path**.</span></span>

## <a name="fill-and-stroke-for-shapes"></a><span data-ttu-id="0cc62-115">図形の Fill と Stroke</span><span class="sxs-lookup"><span data-stu-id="0cc62-115">Fill and Stroke for shapes</span></span>

<span data-ttu-id="0cc62-116">[  **Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) をアプリのキャンバスにレンダリングするには、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) を関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-116">For a [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) to render to the app canvas, you must associate a [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) with it.</span></span> <span data-ttu-id="0cc62-117">**Shape** の [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) プロパティを目的の **Brush** に設定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-117">Set the [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) property of the **Shape** to the **Brush** you want.</span></span> <span data-ttu-id="0cc62-118">ブラシについて詳しくは、「[ブラシの使用](../style/brushes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0cc62-118">For more info about brushes, see [Using brushes](../style/brushes.md).</span></span>

<span data-ttu-id="0cc62-119">[  **Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) には、[**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) という、図形の周囲に描画される境界線を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-119">A [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) can also have a [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke), which is a line that is drawn around the shape's perimeter.</span></span> <span data-ttu-id="0cc62-120">**Stroke** にも、その外観を定義する [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) が必要です。また、[**StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness) が 0 以外の値に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-120">A **Stroke** also requires a [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) that defines its appearance, and should have a non-zero value for [**StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness).</span></span> <span data-ttu-id="0cc62-121">**StrokeThickness** は、図形の境界線の太さを定義するプロパティです。</span><span class="sxs-lookup"><span data-stu-id="0cc62-121">**StrokeThickness** is a property that defines the perimeter's thickness around the shape edge.</span></span> <span data-ttu-id="0cc62-122">**Stroke** に対して **Brush** 値を指定しなかった場合、または **StrokeThickness** を 0 に設定した場合、図形の周囲に境界線が描画されません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-122">If you don't specify a **Brush** value for **Stroke**, or if you set **StrokeThickness** to 0, then the border around the shape is not drawn.</span></span>

## <a name="ellipse"></a><span data-ttu-id="0cc62-123">楕円形</span><span class="sxs-lookup"><span data-stu-id="0cc62-123">Ellipse</span></span>

<span data-ttu-id="0cc62-124">[  **Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) は、曲線の境界を持つ図形です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-124">An [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) is a shape with a curved perimeter.</span></span> <span data-ttu-id="0cc62-125">基本的な **Ellipse** を作成するには、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) と [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height)、および [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) に対する [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-125">To create a basic **Ellipse**, specify a [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width), [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height), and a [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) for the [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill).</span></span>

<span data-ttu-id="0cc62-126">次の例では、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) を 200、[**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) を 200 に設定し、色が [**SteelBlue**](https://msdn.microsoft.com/library/windows/apps/Hh748056) の [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) に指定して、[**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-126">The next example creates an [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) with a [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) of 200 and a [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) of 200, and uses a [**SteelBlue**](https://msdn.microsoft.com/library/windows/apps/Hh748056) colored [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) as its [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill).</span></span>

```xaml
<Ellipse Fill="SteelBlue" Height="200" Width="200" />
```

```csharp
var ellipse1 = new Ellipse();
ellipse1.Fill = new SolidColorBrush(Windows.UI.Colors.SteelBlue);
ellipse1.Width = 200;
ellipse1.Height = 200;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(ellipse1);
```

<span data-ttu-id="0cc62-127">この [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) をレンダリングすると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-127">Here's the rendered [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse).</span></span>

![レンダリングされた Ellipse。](images/shapes-ellipse.jpg)

<span data-ttu-id="0cc62-129">この [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) は、ほとんどの人が円と考える形状になっていますが、XAML ではまさにこのようにして円形を宣言します。つまり、**Ellipse** の [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) と [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) を等しい値に設定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-129">In this case the [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) is what most people would consider a circle, but that's how you declare a circle shape in XAML: use an **Ellipse** with equal [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) and [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height).</span></span>

<span data-ttu-id="0cc62-130">[  **Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) を UI レイアウトに配置すると、そのサイズは、対応する [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) と [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) を持つ四角形と同じであると見なされます。境界の外側の領域は、レンダリングは適用されませんが、レイアウト スロットのサイズの一部として扱われます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-130">When an [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) is positioned in a UI layout, its size is assumed to be the same as a rectangle with that [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) and [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height); the area outside the perimeter does not have rendering but still is part of its layout slot size.</span></span>

<span data-ttu-id="0cc62-131">一連の 6 つの [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) 要素は [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/BR227538) コントロールのコントロール テンプレートの一部であり、2 つの同心の **Ellipse** 要素は [**RadioButton**](https://msdn.microsoft.com/library/windows/apps/BR227544) の一部です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-131">A set of 6 [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) elements are part of the control template for the [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/BR227538) control, and 2 concentric **Ellipse** elements are part of a [**RadioButton**](https://msdn.microsoft.com/library/windows/apps/BR227544).</span></span>

## <a name="span-idrectanglespanspan-idrectanglespanspan-idrectanglespanrectangle"></a><span data-ttu-id="0cc62-132"><span id="Rectangle"></span><span id="rectangle"></span><span id="RECTANGLE"></span>四角形</span><span class="sxs-lookup"><span data-stu-id="0cc62-132"><span id="Rectangle"></span><span id="rectangle"></span><span id="RECTANGLE"></span>Rectangle</span></span>

<span data-ttu-id="0cc62-133">[  **Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は、向かい合った辺の長さがそれぞれ等しい四辺形です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-133">A [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) is a four-sided shape with its opposite sides being equal.</span></span> <span data-ttu-id="0cc62-134">基本的な **Rectangle** を作成するには、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width)、[**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height)、[**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-134">To create a basic **Rectangle**, specify a [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width), a [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height), and a [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill).</span></span>

<span data-ttu-id="0cc62-135">[  **Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は、コーナーを角丸にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-135">You can round the corners of a [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle).</span></span> <span data-ttu-id="0cc62-136">角丸コーナーを作成するには、[**RadiusX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusx.aspx) および [**RadiusY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusy) プロパティの値を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-136">To create rounded corners, specify a value for the [**RadiusX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusx.aspx) and [**RadiusY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusy) properties.</span></span> <span data-ttu-id="0cc62-137">これらのプロパティは、コーナーの曲線を定義する楕円形の X 軸と Y 軸を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-137">These properties specify the x-axis and y-axis of an ellipse that defines the curve of the corners.</span></span> <span data-ttu-id="0cc62-138">**RadiusX** の最大値は [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) の 1/2 であり、**RadiusY** の最大値は [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) の 1/2 です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-138">The maximum allowed value of **RadiusX** is the [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) divided by two and the maximum allowed value of **RadiusY** is the [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) divided by two.</span></span>

<span data-ttu-id="0cc62-139">次の例では、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) が 200 で [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) が 100 の [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-139">The next example creates a [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) with a [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) of 200 and a [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) of 100.</span></span> <span data-ttu-id="0cc62-140">[  **Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) には値が [**Blue**](https://msdn.microsoft.com/library/windows/apps/Hh747837) の [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を使い、[**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) には値が [**Black**](https://msdn.microsoft.com/library/windows/apps/Hh747833) の **SolidColorBrush** を使っています。</span><span class="sxs-lookup"><span data-stu-id="0cc62-140">It uses a [**Blue**](https://msdn.microsoft.com/library/windows/apps/Hh747837) value of [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) for its [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) and a [**Black**](https://msdn.microsoft.com/library/windows/apps/Hh747833) value of **SolidColorBrush** for its [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke).</span></span> <span data-ttu-id="0cc62-141">[  **StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness) は 3 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-141">We set the [**StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness) to 3.</span></span> <span data-ttu-id="0cc62-142">[  **RadiusX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusx.aspx) プロパティを 50、[**RadiusY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusy) プロパティを 10 に設定することで、**Rectangle** を角丸コーナーにしています。</span><span class="sxs-lookup"><span data-stu-id="0cc62-142">We set the [**RadiusX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusx.aspx) property to 50 and the [**RadiusY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.radiusy) property to 10, which gives the **Rectangle** rounded corners.</span></span>

```xaml
<Rectangle Fill="Blue"
           Width="200"
           Height="100"
           Stroke="Black"
           StrokeThickness="3"
           RadiusX="50"
           RadiusY="10" />
```

```csharp
var rectangle1 = new Rectangle();
rectangle1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
rectangle1.Width = 200;
rectangle1.Height = 100;
rectangle1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
rectangle1.StrokeThickness = 3;
rectangle1.RadiusX = 50;
rectangle1.RadiusY = 10;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(rectangle1);
```

<span data-ttu-id="0cc62-143">この [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) をレンダリングすると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-143">Here's the rendered [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle).</span></span>

![レンダリングされた Rectangle。](images/shapes-rectangle.jpg)

<span data-ttu-id="0cc62-145">**ヒント:**  UI 定義の一部のシナリオがあるのではなくを使用して、 [**四角形**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle)、 [**境界線**](https://msdn.microsoft.com/library/windows/apps/BR209250)より適切な場合があります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-145">**Tip**  There are some scenarios for UI definitions where instead of using a [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle), a [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) might be more appropriate.</span></span> <span data-ttu-id="0cc62-146">一般に、コンテンツの周囲に四角形の図形を作成することが目的であるときは、**Border** の方が適しています。子のコンテンツを設定できるほか、高さと幅によってサイズが固定されている **Rectangle** とは異なり、コンテンツに合わせてサイズが自動的に調整されるためです。</span><span class="sxs-lookup"><span data-stu-id="0cc62-146">If your intention is to create a rectangle shape around other content, it might be better to use **Border** because it can have child content and will automatically size around that content, rather than using the fixed dimensions for height and width like **Rectangle** does.</span></span> <span data-ttu-id="0cc62-147">**Border** は、[**CornerRadius**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.border.cornerradius) プロパティを設定することによって、角に丸みを持たせることもできます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-147">A **Border** also has the option of having rounded corners if you set the [**CornerRadius**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.border.cornerradius) property.</span></span>

<span data-ttu-id="0cc62-148">また、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は、コントロールの合成に適したオプションであると考えられます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-148">On the other hand, a [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) is probably a better choice for control composition.</span></span> <span data-ttu-id="0cc62-149">**Rectangle** の図形は多くのコントロール テンプレートで使われます。これは、フォーカス対応コントロールの "FocusVisual" 部分としてこの図形が使われるためです。</span><span class="sxs-lookup"><span data-stu-id="0cc62-149">A **Rectangle** shape is seen in many control templates because it's used as a "FocusVisual" part for focusable controls.</span></span> <span data-ttu-id="0cc62-150">コントロールが "Focused" の表示状態にある場合は常に、この四角形が表示されます。その他の状態にある場合は非表示です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-150">Whenever the control is in a "Focused" visual state, this rectangle is made visible, in other states it's hidden.</span></span>

## <a name="polygon"></a><span data-ttu-id="0cc62-151">多角形</span><span class="sxs-lookup"><span data-stu-id="0cc62-151">Polygon</span></span>

<span data-ttu-id="0cc62-152">[  **Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) は、任意の数の点によって境界線を定義した図形です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-152">A [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) is a shape with a boundary defined by an arbitrary number of points.</span></span> <span data-ttu-id="0cc62-153">1 つの点から次の点まで直線でつなぎ、最後の点を最初の点につなぐことで、境界線を作成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-153">The boundary is created by connecting a line from one point to the next, with the last point connected to the first point.</span></span> <span data-ttu-id="0cc62-154">[  **Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polygon.points.aspx) プロパティによって、境界線を構成する点のコレクションが定義されます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-154">The [**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polygon.points.aspx) property defines the collection of points that make up the boundary.</span></span> <span data-ttu-id="0cc62-155">XAML では、これらの点をコンマ区切り一覧で定義します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-155">In XAML, you define the points with a comma-separated list.</span></span> <span data-ttu-id="0cc62-156">分離コードでは、[**PointCollection**](https://msdn.microsoft.com/library/windows/apps/BR210220) を使って点のコレクションを定義し、それぞれの点を [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 値としてコレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-156">In code-behind you use a [**PointCollection**](https://msdn.microsoft.com/library/windows/apps/BR210220) to define the points and you add each individual point as a [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) value to the collection.</span></span>

<span data-ttu-id="0cc62-157">始点と終点が同じ [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 値となるような点を明示的に宣言する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-157">You don't need to explicitly declare the points such that the start point and end point are both specified as the same [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) value.</span></span> <span data-ttu-id="0cc62-158">[  **Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) のレンダリング ロジックが、閉じた図形を想定して暗黙的に終点を始点に接続します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-158">The rendering logic for a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) assumes that you are defining a closed shape and will connect the end point to the start point implicitly.</span></span>

<span data-ttu-id="0cc62-159">次の例では、4 つの点を `(10,200)`、`(60,140)`、`(130,140)`、`(180,200)` に設定した [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-159">The next example creates a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) with 4 points set to `(10,200)`, `(60,140)`, `(130,140)`, and `(180,200)`.</span></span> <span data-ttu-id="0cc62-160">[  **Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) には、[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) の [**LightBlue**](https://msdn.microsoft.com/library/windows/apps/Hh747960) 値を使います。[**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) には値を割り当てていないので、境界の輪郭は描画されません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-160">It uses a [**LightBlue**](https://msdn.microsoft.com/library/windows/apps/Hh747960) value of [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) for its [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill), and has no value for [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) so it has no perimeter outline.</span></span>

```xaml
<Polygon Fill="LightBlue"
         Points="10,200,60,140,130,140,180,200" />
```

```csharp
var polygon1 = new Polygon();
polygon1.Fill = new SolidColorBrush(Windows.UI.Colors.LightBlue);

var points = new PointCollection();
points.Add(new Windows.Foundation.Point(10, 200));
points.Add(new Windows.Foundation.Point(60, 140));
points.Add(new Windows.Foundation.Point(130, 140));
points.Add(new Windows.Foundation.Point(180, 200));
polygon1.Points = points;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(polygon1);
```

<span data-ttu-id="0cc62-161">この [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) をレンダリングすると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-161">Here's the rendered [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon).</span></span>

![レンダリングされた Polygon。](images/shapes-polygon.jpg)

<span data-ttu-id="0cc62-163">**ヒント:**  A [**ポイント**](https://msdn.microsoft.com/library/windows/apps/BR225870)図形の頂点を宣言する以外のシナリオの値がよく使用 XAML 内の型として。</span><span class="sxs-lookup"><span data-stu-id="0cc62-163">**Tip**  A [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) value is often used as a type in XAML for scenarios other than declaring the vertices of shapes.</span></span> <span data-ttu-id="0cc62-164">たとえば、**Point** はタッチ イベントのイベント データの一部であるため、座標空間におけるタッチ操作が発生した位置を正確に認識することができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-164">For example, a **Point** is part of the event data for touch events, so you can know exactly where in a coordinate space the touch action occurred.</span></span> <span data-ttu-id="0cc62-165">**Point** の詳しい情報と、それを XAML やコードで使う方法については、API リファレンスの [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0cc62-165">For more info about **Point** and how to use it in XAML or code, see the API reference topic for [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870).</span></span>

## <a name="line"></a><span data-ttu-id="0cc62-166">直線</span><span class="sxs-lookup"><span data-stu-id="0cc62-166">Line</span></span>

<span data-ttu-id="0cc62-167">[  **Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) は、座標空間において 2 点間に描画される単純な直線です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-167">A [**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) is simply a line drawn between two points in coordinate space.</span></span> <span data-ttu-id="0cc62-168">**Line** は内部領域を持たないため、[**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) に何か値を指定してもすべて無視されます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-168">A **Line** ignores any value provided for [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill), because it has no interior space.</span></span> <span data-ttu-id="0cc62-169">**Line** には、[**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) プロパティと [**StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness) プロパティの値を必ず指定してください。指定しないと、**Line** はレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-169">For a **Line**, make sure to specify values for the [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) and [**StrokeThickness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.strokethickness) properties, because otherwise the **Line** won't render.</span></span>

<span data-ttu-id="0cc62-170">[  **Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) 図形を指定する際、[**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 値は使いません。[**X1**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.x1.aspx)、[**Y1**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.y1.aspx)、[**X2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.x2.aspx)、[**Y2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.y2.aspx) のそれぞれに対して個別に [**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-170">You don't use [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) values to specify a [**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) shape, instead you use discrete [**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) values for [**X1**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.x1.aspx), [**Y1**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.y1.aspx), [**X2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.x2.aspx) and [**Y2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.line.y2.aspx).</span></span> <span data-ttu-id="0cc62-171">これで、水平方向または垂直方向の直線に対する最低限のマークアップは完成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-171">This enables minimal markup for horizontal or vertical lines.</span></span> <span data-ttu-id="0cc62-172">たとえば、長さ 400 ピクセルの水平方向の直線を定義するには、`<Line Stroke="Red" X2="400"/>` とします。</span><span class="sxs-lookup"><span data-stu-id="0cc62-172">For example, `<Line Stroke="Red" X2="400"/>` defines a horizontal line that is 400 pixels long.</span></span> <span data-ttu-id="0cc62-173">その他の X,Y プロパティは既定で 0 に設定されるため、点で見た場合、この XAML は `(0,0)` から `(400,0)` に直線を描画していることになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-173">The other X,Y properties are 0 by default, so in terms of points this XAML would draw a line from `(0,0)` to `(400,0)`.</span></span> <span data-ttu-id="0cc62-174">(0,0) 以外の点から開始する必要がある場合は、[**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) を使って **Line** 全体を移動することができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-174">You could then use a [**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) to move the entire **Line**, if you wanted it to start at a point other than (0,0).</span></span>

```xaml
<Line Stroke="Red" X2="400"/>
```

```csharp
var line1 = new Line();
line1.Stroke = new SolidColorBrush(Windows.UI.Colors.Red);
line1.X2 = 400;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(line1);
```

## <a name="span-idpolylinespanspan-idpolylinespanspan-idpolylinespan-polyline"></a><span data-ttu-id="0cc62-175"><span id="_Polyline"></span><span id="_polyline"></span><span id="_POLYLINE"></span> ポリライン</span><span class="sxs-lookup"><span data-stu-id="0cc62-175"><span id="_Polyline"></span><span id="_polyline"></span><span id="_POLYLINE"></span> Polyline</span></span>

<span data-ttu-id="0cc62-176">[  **Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) は、[**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) と同様に、図形の境界線を点のセットによって定義しますが、**Polyline** では最後の点が最初の点に接続されません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-176">A [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) is similar to a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) in that the boundary of the shape is defined by a set of points, except the last point in a **Polyline** is not connected to the first point.</span></span>

<span data-ttu-id="0cc62-177">**注**   、同一の開始点と終点で明示的にあるでした、 [**ポイント**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx)の設定、 [**ポリライン**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline)が、その場合はおそらくを使用しても、 [**多角形**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon)代わりにします。</span><span class="sxs-lookup"><span data-stu-id="0cc62-177">**Note**   You could explicitly have an identical start point and end point in the [**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx) set for the [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline), but in that case you probably could have used a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) instead.</span></span>

<span data-ttu-id="0cc62-178">[  **Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) の [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) を指定した場合、**Polyline** に対して設定された [**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx) の始点と終点が交わらなくても、図形の内部領域が **Fill** によって塗りつぶされます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-178">If you specify a [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) of a [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline), the **Fill** paints the interior space of the shape, even if the start point and end point of the [**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx) set for the **Polyline** do not intersect.</span></span> <span data-ttu-id="0cc62-179">**Polyline** で **Fill** を指定しなかった場合のレンダリングは、複数の [**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) 要素を個別に指定し、前の直線の終点が次の直線の始点と交わるようにした場合と同様の結果となります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-179">If you do not specify a **Fill**, then the **Polyline** is similar to what would have rendered if you had specified several individual [**Line**](/uwp/api/Windows.UI.Xaml.Shapes.Line) elements where the start points and end points of consecutive lines intersected.</span></span>

<span data-ttu-id="0cc62-180">[  **Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) の場合と同様に、[**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx) プロパティによって境界線を構成する点のコレクションが定義されます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-180">As with a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon), the [**Points**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.polyline.points.aspx) property defines the collection of points that make up the boundary.</span></span> <span data-ttu-id="0cc62-181">XAML では、これらの点をコンマ区切り一覧で定義します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-181">In XAML, you define the points with a comma-separated list.</span></span> <span data-ttu-id="0cc62-182">コード ビハインドでは、[**PointCollection**](https://msdn.microsoft.com/library/windows/apps/BR210220) を使って点のコレクションを定義し、それぞれの点を [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 構造体としてコレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-182">In code-behind, you use a [**PointCollection**](https://msdn.microsoft.com/library/windows/apps/BR210220) to define the points and you add each individual point as a [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) structure to the collection.</span></span>

<span data-ttu-id="0cc62-183">次の例では、4 つの点を `(10,200)`、`(60,140)`、`(130,140)`、`(180,200)` に設定した [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-183">This example creates a [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) with four points set to `(10,200)`, `(60,140)`, `(130,140)`, and `(180,200)`.</span></span> <span data-ttu-id="0cc62-184">[  **Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) は定義されていますが、[**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill) は定義されていません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-184">A [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) is defined but not a [**Fill**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.fill).</span></span>

```xaml
<Polyline Stroke="Black"
        StrokeThickness="4"
        Points="10,200,60,140,130,140,180,200" />
```

```csharp
var polyline1 = new Polyline();
polyline1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
polyline1.StrokeThickness = 4;

var points = new PointCollection();
points.Add(new Windows.Foundation.Point(10, 200));
points.Add(new Windows.Foundation.Point(60, 140));
points.Add(new Windows.Foundation.Point(130, 140));
points.Add(new Windows.Foundation.Point(180, 200));
polyline1.Points = points;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(polyline1);
```

この [**Polyline**](/uwp/api/Windows.UI.Xaml.Shapes.Polyline) をレンダリングすると、次のようになります。 <span data-ttu-id="0cc62-186">[  **Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon) とは異なり、[**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) の最初と最後の点が接続されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0cc62-186">Notice that the first and last points are not connected by the [**Stroke**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.shape.stroke) outline as they are in a [**Polygon**](/uwp/api/Windows.UI.Xaml.Shapes.Polygon).</span></span>

![レンダリングされた Polyline。](images/shapes-polyline.jpg)

## <a name="path"></a><span data-ttu-id="0cc62-188">パス</span><span class="sxs-lookup"><span data-stu-id="0cc62-188">Path</span></span>

<span data-ttu-id="0cc62-189">[  **Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) は、任意の形状を定義するために使える、最も用途が広い [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-189">A [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) is the most versatile [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) because you can use it to define an arbitrary geometry.</span></span> <span data-ttu-id="0cc62-190">ただし、用途が広い反面、複雑さも伴います。</span><span class="sxs-lookup"><span data-stu-id="0cc62-190">But with this versatility comes complexity.</span></span> <span data-ttu-id="0cc62-191">次に、XAML で基本的な **Path** を作成する方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-191">Let's now look at how to create a basic **Path** in XAML.</span></span>

<span data-ttu-id="0cc62-192">パスの形状は、[**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) プロパティで定義します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-192">You define the geometry of a path with the [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) property.</span></span> <span data-ttu-id="0cc62-193">**Data** の設定には次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-193">There are two techniques for setting **Data**:</span></span>

- <span data-ttu-id="0cc62-194">[  **Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) には、XAML で文字列値を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-194">You can set a string value for [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) in XAML.</span></span> <span data-ttu-id="0cc62-195">この場合、**Path.Data** の値には、グラフィックスのシリアル化形式が使われます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-195">In this form, the **Path.Data** value is consuming a serialization format for graphics.</span></span> <span data-ttu-id="0cc62-196">一般に、いったん構築されたこの値をテキストとして (文字列形式として) 編集することはしません。</span><span class="sxs-lookup"><span data-stu-id="0cc62-196">You typically don't text-edit this value in string form after it is first established.</span></span> <span data-ttu-id="0cc62-197">サーフェス上のデザインや図面のメタファーを扱うことのできるデザイン ツールを使います。</span><span class="sxs-lookup"><span data-stu-id="0cc62-197">Instead, you use design tools that enable you to work in a design or drawing metaphor on a surface.</span></span> <span data-ttu-id="0cc62-198">その出力結果を保存 (またはエクスポート) すると、**Path.Data** 情報を含んだ XAML ファイルまたは XAML 文字列フラグメントが得られます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-198">Then you save or export the output, and this gives you a XAML file or XAML string fragment with **Path.Data** information.</span></span>
- <span data-ttu-id="0cc62-199">[  **Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) プロパティは、単一の [**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) オブジェクトに設定できます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-199">You can set the [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) property to a single [**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) object.</span></span> <span data-ttu-id="0cc62-200">この設定は、コードまたは XAML で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-200">This can be done in code or in XAML.</span></span> <span data-ttu-id="0cc62-201">この単一の **Geometry** は通常、[**GeometryGroup**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.geometrygroup) です。オブジェクト モデルの趣旨に沿って、複数のジオメトリ定義を 1 つのオブジェクトに合成できるコンテナーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-201">That single **Geometry** is typically a [**GeometryGroup**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.geometrygroup), which acts as a container that can composite multiple geometry definitions into a single object for purposes of the object model.</span></span> <span data-ttu-id="0cc62-202">これは主に、[**PathFigure**](https://msdn.microsoft.com/library/windows/apps/BR210143) の [**Segments**](https://msdn.microsoft.com/library/windows/apps/BR210164) 値として定義される曲線と複雑な図形を、場合によっては複数組み合わせて使う必要があるとき ([**BezierSegment**](https://msdn.microsoft.com/library/windows/apps/BR228068) など) に用いる方法です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-202">The most common reason for doing this is because you want to use one or more of the curves and complex shapes that can be defined as [**Segments**](https://msdn.microsoft.com/library/windows/apps/BR210164) values for a [**PathFigure**](https://msdn.microsoft.com/library/windows/apps/BR210143), for example [**BezierSegment**](https://msdn.microsoft.com/library/windows/apps/BR228068).</span></span>

<span data-ttu-id="0cc62-203">この例に示す [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) は、Blend for Visual Studio を使っていくつかのベクター図形を生成し、その結果を XAML として保存したものです。</span><span class="sxs-lookup"><span data-stu-id="0cc62-203">This example shows a [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) that might have resulted from using Blend for Visual Studio to produce just a few vector shapes and then saving the result as XAML.</span></span> <span data-ttu-id="0cc62-204">**Path** 全体は、ベジエ曲線セグメントと直線セグメントから成ります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-204">The total **Path** consists of a Bezier curve segment and a line segment.</span></span> <span data-ttu-id="0cc62-205">この例の目的は、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) のシリアル化形式にどのような要素が存在し、各数値が何を表しているかをわかりやすく紹介することです。</span><span class="sxs-lookup"><span data-stu-id="0cc62-205">The example is mainly intended to give you some examples of what elements exist in the [**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) serialization format and what the numbers represent.</span></span>

<span data-ttu-id="0cc62-206">この [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) は、"M" で示される移動コマンドによって開始され、これによってパスの絶対開始点が設定されます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-206">This [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) begins with the move command, indicated by "M", which establishes an absolute start point for the path.</span></span>

<span data-ttu-id="0cc62-207">最初のセグメントは、`(100,200)` から始まり `(400,175)` で終わる三次ベジエ曲線であり、2 つの制御点 `(100,25)` および `(400,350)` を使って描かれます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-207">The first segment is a cubic Bezier curve that begins at `(100,200)` and ends at `(400,175)`, which is drawn by using the two control points `(100,25)` and `(400,350)`.</span></span> <span data-ttu-id="0cc62-208">このセグメントは、[**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) 属性文字列の "C" コマンドによって示されます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-208">This segment is indicated by the "C" command in the [**Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) attribute string.</span></span>

<span data-ttu-id="0cc62-209">2 番目のセグメントは、絶対水平直線コマンド "H" によって開始されます。これは、前のサブパスの終点 `(400,175)` から新しい終点 `(280,175)` まで描かれる直線を指定します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-209">The second segment begins with an absolute horizontal line command "H", which specifies a line drawn from the preceding subpath endpoint `(400,175)` to a new endpoint `(280,175)`.</span></span> <span data-ttu-id="0cc62-210">これは水平直線コマンドであるため、指定される値は X 座標です。</span><span class="sxs-lookup"><span data-stu-id="0cc62-210">Because it's a horizontal line command, the value specified is an x-coordinate.</span></span>

```xaml
<Path Stroke="DarkGoldenRod" 
      StrokeThickness="3"
      Data="M 100,200 C 100,25 400,350 400,175 H 280" />
```

<span data-ttu-id="0cc62-211">この [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) をレンダリングすると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-211">Here's the rendered [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path).</span></span>

![レンダリングされた Path。](images/shapes-path.jpg)

<span data-ttu-id="0cc62-213">次の例は、説明済みの手法である [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/BR210168) を使った [**GeometryGroup**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.geometrygroup) の使用方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0cc62-213">The next example shows a usage of the other technique we discussed: a [**GeometryGroup**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.geometrygroup) with a [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/BR210168).</span></span> <span data-ttu-id="0cc62-214">この例の実行の一部として使用できる関係している geometry 型の一部を**PathGeometry**:[**PathFigure** ](https://msdn.microsoft.com/library/windows/apps/BR210143)内のセグメントを使用可能なさまざまな要素と[ **PathFigure.Segments**](https://msdn.microsoft.com/library/windows/apps/BR210164)します。</span><span class="sxs-lookup"><span data-stu-id="0cc62-214">This example exercises some of the contributing geometry types that can be used as part of a **PathGeometry**: [**PathFigure**](https://msdn.microsoft.com/library/windows/apps/BR210143) and the various elements that can be a segment in [**PathFigure.Segments**](https://msdn.microsoft.com/library/windows/apps/BR210164).</span></span>

```xaml
<Path Stroke="Black" StrokeThickness="1" Fill="#CCCCFF">
    <Path.Data>
        <GeometryGroup>
            <RectangleGeometry Rect="50,5 100,10" />
            <RectangleGeometry Rect="5,5 95,180" />
            <EllipseGeometry Center="100, 100" RadiusX="20" RadiusY="30"/>
            <RectangleGeometry Rect="50,175 100,10" />
            <PathGeometry>
                <PathGeometry.Figures>
                    <PathFigureCollection>
                        <PathFigure IsClosed="true" StartPoint="50,50">
                            <PathFigure.Segments>
                                <PathSegmentCollection>
                                    <BezierSegment Point1="75,300" Point2="125,100" Point3="150,50"/>
                                    <BezierSegment Point1="125,300" Point2="75,100"  Point3="50,50"/>
                                </PathSegmentCollection>
                            </PathFigure.Segments>
                        </PathFigure>
                    </PathFigureCollection>
                </PathGeometry.Figures>
            </PathGeometry>
        </GeometryGroup>
    </Path.Data>
</Path>
```

```csharp
var path1 = new Windows.UI.Xaml.Shapes.Path();
path1.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 255));
path1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
path1.StrokeThickness = 1;

var geometryGroup1 = new GeometryGroup();
var rectangleGeometry1 = new RectangleGeometry();
rectangleGeometry1.Rect = new Rect(50, 5, 100, 10);
var rectangleGeometry2 = new RectangleGeometry();
rectangleGeometry2.Rect = new Rect(5, 5, 95, 180);
geometryGroup1.Children.Add(rectangleGeometry1);
geometryGroup1.Children.Add(rectangleGeometry2);

var ellipseGeometry1 = new EllipseGeometry();
ellipseGeometry1.Center = new Point(100, 100);
ellipseGeometry1.RadiusX = 20;
ellipseGeometry1.RadiusY = 30;
geometryGroup1.Children.Add(ellipseGeometry1);

var pathGeometry1 = new PathGeometry();
var pathFigureCollection1 = new PathFigureCollection();
var pathFigure1 = new PathFigure();
pathFigure1.IsClosed = true;
pathFigure1.StartPoint = new Windows.Foundation.Point(50, 50);
pathFigureCollection1.Add(pathFigure1);
pathGeometry1.Figures = pathFigureCollection1;

var pathSegmentCollection1 = new PathSegmentCollection();
var pathSegment1 = new BezierSegment();
pathSegment1.Point1 = new Point(75, 300);
pathSegment1.Point2 = new Point(125, 100);
pathSegment1.Point3 = new Point(150, 50);
pathSegmentCollection1.Add(pathSegment1);

var pathSegment2 = new BezierSegment();
pathSegment2.Point1 = new Point(125, 300);
pathSegment2.Point2 = new Point(75, 100);
pathSegment2.Point3 = new Point(50, 50);
pathSegmentCollection1.Add(pathSegment2);
pathFigure1.Segments = pathSegmentCollection1;

geometryGroup1.Children.Add(pathGeometry1);
path1.Data = geometryGroup1;

// When you create a XAML element in code, you have to add
// it to the XAML visual tree. This example assumes you have
// a panel named 'layoutRoot' in your XAML file, like this:
// <Grid x:Name="layoutRoot>
layoutRoot.Children.Add(path1);
```

<span data-ttu-id="0cc62-215">この [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) をレンダリングすると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-215">Here's the rendered [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path).</span></span>

![レンダリングされた Path。](images/shapes-path-2.png)

<span data-ttu-id="0cc62-217">[  **PathGeometry**](https://msdn.microsoft.com/library/windows/apps/BR210168) を使うと、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) 文字列を設定した場合よりも読みやすくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="0cc62-217">Using [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/BR210168) may be more readable than populating a [**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) string.</span></span> <span data-ttu-id="0cc62-218">また、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) では、スケーラブル ベクター グラフィックス (SVG) の画像パスの定義と互換性のある構文が使われます。これにより、SVG からグラフィックスを移植したり、Blend などのツールからの出力として移植したりする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0cc62-218">On the other hand, [**Path.Data**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.path.data) uses a syntax compatible with Scalable Vector Graphics (SVG) image path definitions so it may be useful for porting graphics from SVG, or as output from a tool like Blend.</span></span>
