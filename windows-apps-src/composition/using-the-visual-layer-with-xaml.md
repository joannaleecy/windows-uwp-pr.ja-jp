---
author: jaster
ms.assetid: b7a4ac8a-d91e-461b-a060-cc6fcea8e778
title: XAML でのビジュアル レイヤーの使用
description: ビジュアル レイヤー API を既存の XAML コンテンツと組み合わせて使用し、高度なアニメーションや効果を作成する方法について説明します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1f25cda10d5fde88bbe2cff75406cc0454780a5b
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5922542"
---
# <a name="using-the-visual-layer-with-xaml"></a><span data-ttu-id="27c51-104">XAML でのビジュアル レイヤーの使用</span><span class="sxs-lookup"><span data-stu-id="27c51-104">Using the Visual Layer with XAML</span></span>

<span data-ttu-id="27c51-105">ビジュアル レイヤーの機能を利用するほとんどのアプリは、XAML を使用して、メイン UI コンテンツを定義します。</span><span class="sxs-lookup"><span data-stu-id="27c51-105">Most apps that consume Visual Layer capabilities will use XAML to define the main UI content.</span></span> <span data-ttu-id="27c51-106">Windows 10 Anniversary Update では、XAML フレームワークやビジュアル レイヤーの新しい機能を利用し、これら 2 つのテクノロジを組み合わせて、魅力的なユーザー エクスペリエンスを簡単に作成することができます。</span><span class="sxs-lookup"><span data-stu-id="27c51-106">In the Windows 10 Anniversary Update, there are new features in the XAML framework and the Visual Layer that make it easier to combine these two technologies to create stunning user experiences.</span></span>
<span data-ttu-id="27c51-107">XAML とビジュアル レイヤーの相互運用機能を使用すると、XAML API 単独では実現できない、高度なアニメーションや効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="27c51-107">XAML and Visual Layer interop functionality can be used to create advanced animations and effects not available using XAML APIs alone.</span></span> <span data-ttu-id="27c51-108">たとえば、次のようなアニメーションや効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="27c51-108">This includes:</span></span>

- <span data-ttu-id="27c51-109">ぼかしやすりガラスなどのブラシ効果</span><span class="sxs-lookup"><span data-stu-id="27c51-109">Brush effects like blur and frosted glass</span></span>
- <span data-ttu-id="27c51-110">動的な照明効果</span><span class="sxs-lookup"><span data-stu-id="27c51-110">Dynamic lighting effects</span></span>
- <span data-ttu-id="27c51-111">スクロール駆動型のアニメーションや視差効果</span><span class="sxs-lookup"><span data-stu-id="27c51-111">Scroll driven animations and parallax</span></span>
- <span data-ttu-id="27c51-112">自動レイアウトのアニメーション</span><span class="sxs-lookup"><span data-stu-id="27c51-112">Automatic layout animations</span></span>
- <span data-ttu-id="27c51-113">ピクセル パーフェクトなドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="27c51-113">Pixel-perfect drop shadows</span></span>

<span data-ttu-id="27c51-114">これらの効果やアニメーションは既存の XAML コンテンツに適用できます。このため、新しい機能を活用するために、XAML アプリを大幅に再構成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="27c51-114">These effects and animations can be applied to existing XAML content, so you don't have to dramatically restructure your XAML app to take advantage of the new functionality.</span></span>
<span data-ttu-id="27c51-115">レイアウト アニメーション、シャドウ、ぼかし効果については、以下の「レシピ」セクションで説明しています。</span><span class="sxs-lookup"><span data-stu-id="27c51-115">Layout animations, shadows, and blur effects are covered in the Recipes section below.</span></span> <span data-ttu-id="27c51-116">視差効果を実装するコード サンプルについては、[ParallaxingListItems のサンプル](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2010586/ParallaxingListItems)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-116">For a code sample implementing parallax, see the [ParallaxingListItems sample](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2010586/ParallaxingListItems).</span></span> <span data-ttu-id="27c51-117">[WindowsUIDevLabs リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs)にも、アニメーション、シャドウ、効果を実装するためのサンプルがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="27c51-117">The [WindowsUIDevLabs repository](https://github.com/Microsoft/WindowsUIDevLabs) also has several other samples for implementing animations, shadows and effects.</span></span>

## <a name="the-xamlcompositionbrushbase-class"></a><span data-ttu-id="27c51-118">XamlCompositionBrushBase クラス</span><span class="sxs-lookup"><span data-stu-id="27c51-118">The XamlCompositionBrushBase class</span></span>

<span data-ttu-id="27c51-119">**XamlCompositionBrush** は、**CompositionBrush** で領域をペイントする XAML ブラシの基底クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="27c51-119">**XamlCompositionBrush** provides a base class for XAML brushes that paint an area with a **CompositionBrush**.</span></span> <span data-ttu-id="27c51-120">これを使用することで、XAML UI 要素に、ぼかしやすりガラスなどのコンポジション効果を簡単に適用できます。</span><span class="sxs-lookup"><span data-stu-id="27c51-120">This can be used to easily apply composition effects like blur or frosted glass to XAML UI elements.</span></span>

<span data-ttu-id="27c51-121">XAML UI でのブラシの使い方について詳しくは、「[**ブラシ**](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-121">See the [**Brushes**](/windows/uwp/design/style/brushes#xamlcompositionbrushbase) section for more info on using brushes with XAML UI.</span></span>

<span data-ttu-id="27c51-122">コードの例については、[**XamlCompositionBrushBase**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-122">For code examples, see the reference page for [**XamlCompositionBrushBase**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

## <a name="the-xamllight-class"></a><span data-ttu-id="27c51-123">XamlLight クラス</span><span class="sxs-lookup"><span data-stu-id="27c51-123">The XamlLight class</span></span>

<span data-ttu-id="27c51-124">**XamlLight** は、**CompositionLight** で領域を動的に照らす XAML 照明効果の基底クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="27c51-124">**XamlLight** provides a base class for XAML lighting effects that dynamically light an area with a **CompositionLight**.</span></span>

<span data-ttu-id="27c51-125">XAML UI 要素の照明など、ライトの使い方について詳しくは、「[**照明**](xaml-lighting.md)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-125">See the [**Lighting**](xaml-lighting.md) section for more info on using lights, including lighting XAML UI elements.</span></span>

<span data-ttu-id="27c51-126">コードの例については、[**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-126">For code examples, see the reference page for [**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight).</span></span>

## <a name="the-elementcompositionpreview-class"></a><span data-ttu-id="27c51-127">ElementCompositionPreview クラス</span><span class="sxs-lookup"><span data-stu-id="27c51-127">The ElementCompositionPreview class</span></span>

<span data-ttu-id="27c51-128">[**ElementCompositionPreview**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.aspx) は静的クラスであり、XAML とビジュアル レイヤーの相互運用機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="27c51-128">[**ElementCompositionPreview**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.aspx) is a static class that provides XAML and Visual Layer interop functionality.</span></span> <span data-ttu-id="27c51-129">ビジュアル レイヤーとその機能の概要については、「[ビジュアル レイヤー](https://msdn.microsoft.com/windows/uwp/graphics/visual-layer)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-129">For an overview of the Visual Layer and its functionality, see [Visual Layer](https://msdn.microsoft.com/windows/uwp/graphics/visual-layer).</span></span> <span data-ttu-id="27c51-130">**ElementCompositionPreview** クラスには、次のメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="27c51-130">The **ElementCompositionPreview** class provides the following methods:</span></span>

-   <span data-ttu-id="27c51-131">[**GetElementVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx) この要素のレンダリングで使用される "ハンドアウト" Visual を取得します。</span><span class="sxs-lookup"><span data-stu-id="27c51-131">[**GetElementVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx): Get a "handout" Visual that is used to render this element</span></span>
-   <span data-ttu-id="27c51-132">[**SetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.setelementchildvisual.aspx): "ハンドイン" Visual を、この要素のビジュアル ツリーの最後の子として設定します。</span><span class="sxs-lookup"><span data-stu-id="27c51-132">[**SetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.setelementchildvisual.aspx): Sets a "handin" Visual as the last child of this element’s visual tree.</span></span> <span data-ttu-id="27c51-133">この Visual は、他の要素の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="27c51-133">This Visual will draw on top of the rest of the element.</span></span> 
-   <span data-ttu-id="27c51-134">[**GetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx): **SetElementChildVisual** を使用して設定された Visual を取得します。</span><span class="sxs-lookup"><span data-stu-id="27c51-134">[**GetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx): Retrieve the Visual set using **SetElementChildVisual**</span></span>
-   <span data-ttu-id="27c51-135">[**GetScrollViewerManipulationPropertySet**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx): **ScrollViewer** のスクロール オフセットに基づいて 60 fps のアニメーションを作成する際に使用できるオブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="27c51-135">[**GetScrollViewerManipulationPropertySet**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual.aspx): Get an object that can be used to create 60fps animations based on scroll offset in a **ScrollViewer**</span></span>

## <a name="remarks-on-elementcompositionpreviewgetelementvisual"></a><span data-ttu-id="27c51-136">ElementCompositionPreview.GetElementVisual の解説</span><span class="sxs-lookup"><span data-stu-id="27c51-136">Remarks on ElementCompositionPreview.GetElementVisual</span></span>

<span data-ttu-id="27c51-137">**ElementCompositionPreview.GetElementVisual** は、指定の **UIElement** をレンダリングするために使用される "ハンドアウト" Visual を返します。</span><span class="sxs-lookup"><span data-stu-id="27c51-137">**ElementCompositionPreview.GetElementVisual** returns a “handout” Visual that is used to render the given **UIElement**.</span></span> <span data-ttu-id="27c51-138">**Visual.Opacity**、**Visual.Offset**、**Visual.Size** などのプロパティは、UIElement の状態に基づいて、XAML フレームワークによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="27c51-138">Properties such as **Visual.Opacity**, **Visual.Offset**, and **Visual.Size** are set by the XAML framework based on the state of the UIElement.</span></span> <span data-ttu-id="27c51-139">これにより、暗黙的な位置変更アニメーションなどの手法が利用可能になります (「*Recipes*」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="27c51-139">This enables techniques such as implicit reposition animations (see *Recipes*).</span></span>

<span data-ttu-id="27c51-140">**Offset** や **Size** は XAML フレームワーク レイアウトの結果として設定されるため、開発者は、これらのプロパティの変更やアニメーション化を慎重に行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="27c51-140">Note that since **Offset** and **Size** are set as the result of XAML framework layout, developers should be careful when modifying or animating these properties.</span></span> <span data-ttu-id="27c51-141">レイアウト内で要素の左上隅の位置がその要素の親の左上隅と同じ位置になる場合、開発者は、Offset の変更またはアニメーション化のみを行ってください。</span><span class="sxs-lookup"><span data-stu-id="27c51-141">Developers should only modify or animate Offset when the element’s top-left corner has the same position as that of its parent in layout.</span></span> <span data-ttu-id="27c51-142">通常、Size は変更しませんが、そのプロパティへアクセスすると便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="27c51-142">Size should generally not be modified, but accessing the property may be useful.</span></span> <span data-ttu-id="27c51-143">たとえば、以下に示すドロップ シャドウやすりガラスのサンプルでは、ハンドアウト Visual の Size をアニメーションへの入力として使用します。</span><span class="sxs-lookup"><span data-stu-id="27c51-143">For example, the Drop Shadow and Frosted Glass samples below use Size of a handout Visual as input to an animation.</span></span>

<span data-ttu-id="27c51-144">その他の注意事項として、ハンドアウト Visual の更新されたプロパティは、対応する UIElement には反映されません。</span><span class="sxs-lookup"><span data-stu-id="27c51-144">As an additional caveat, updated properties of the handout Visual will not be reflected in the corresponding UIElement.</span></span> <span data-ttu-id="27c51-145">たとえば、**UIElement.Opacity** を 0.5 に設定すると、対応するハンドアウト Visual の Opacity も 0.5 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="27c51-145">So for example, setting **UIElement.Opacity** to 0.5 will set the corresponding handout Visual’s Opacity to 0.5.</span></span> <span data-ttu-id="27c51-146">ただし、ハンドアウト Visual の **Opacity** を 0.5 に設定した場合、コンテンツが 50% の不透明度で表示されますが、対応する UIElement の Opacity プロパティの値は変更されません。</span><span class="sxs-lookup"><span data-stu-id="27c51-146">However, setting the handout Visual’s **Opacity** to 0.5 will cause the content to appear at 50% opacity, but will not change the value of the corresponding UIElement’s Opacity property.</span></span>

### <a name="example-of-offset-animation"></a><span data-ttu-id="27c51-147">**オフセット** アニメーションの例</span><span class="sxs-lookup"><span data-stu-id="27c51-147">Example of **Offset** animation</span></span>

#### <a name="incorrect"></a><span data-ttu-id="27c51-148">誤った例</span><span class="sxs-lookup"><span data-stu-id="27c51-148">Incorrect</span></span>

```xaml
<Border>
      <Image x:Name="MyImage" Margin="5" />
</Border>
```

```csharp
// Doesn’t work because Image has a margin!
ElementCompositionPreview.GetElementVisual(MyImage).StartAnimation("Offset", parallaxAnimation);
```

#### <a name="correct"></a><span data-ttu-id="27c51-149">正しい例</span><span class="sxs-lookup"><span data-stu-id="27c51-149">Correct</span></span>

```xaml
<Border>
    <Canvas Margin="5">
        <Image x:Name="MyImage" />
    </Canvas>
</Border>
```

```csharp
// This works because the Canvas parent doesn’t generate a layout offset.
ElementCompositionPreview.GetElementVisual(MyImage).StartAnimation("Offset", parallaxAnimation);
```

## <a name="the-elementcompositionpreviewsetelementchildvisual-method"></a><span data-ttu-id="27c51-150">**ElementCompositionPreview.SetElementChildVisual** メソッド</span><span class="sxs-lookup"><span data-stu-id="27c51-150">The **ElementCompositionPreview.SetElementChildVisual** method</span></span>

<span data-ttu-id="27c51-151">**ElementCompositionPreview.SetElementChildVisual** を使用すると、開発者は、要素のビジュアル ツリーの一部として表示される "ハンドイン" Visual を提供できます。</span><span class="sxs-lookup"><span data-stu-id="27c51-151">**ElementCompositionPreview.SetElementChildVisual** allows the developer to supply a “handin” Visual that will appear as part of an element’s Visual Tree.</span></span> <span data-ttu-id="27c51-152">これにより、開発者は、Visual ベースのコンテンツを XAML UI 内部に表示できる、"コンポジション アイランド" を作成できます。</span><span class="sxs-lookup"><span data-stu-id="27c51-152">This allows developers to create a “Composition Island” where Visual-based content can appear inside a XAML UI.</span></span> <span data-ttu-id="27c51-153">開発者はこの手法の使用については慎重に考慮する必要があります。それは、Visual ベースのコンテンツを使用した場合、XAML コンテンツでは同等のアクセシビリティとユーザー エクスペリエンスの保証が確保されないためです。</span><span class="sxs-lookup"><span data-stu-id="27c51-153">Developers should be conservative about using this technique because Visual-based content will not have the same accessibility and user experience guarantees of XAML content.</span></span> <span data-ttu-id="27c51-154">そのため、通常この手法は、以下の「レシピ」セクションに記載されているようなカスタム効果の実装で必要となる場合にのみ使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="27c51-154">Therefore, it is generally recommended that this technique only be used when necessary to implement custom effects such as those found in the Recipes section below.</span></span>

## <a name="getalphamask-methods"></a><span data-ttu-id="27c51-155">**GetAlphaMask** メソッド</span><span class="sxs-lookup"><span data-stu-id="27c51-155">**GetAlphaMask** methods</span></span>

<span data-ttu-id="27c51-156">[**Image**](https://msdn.microsoft.com/library/windows/apps/br242752)、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652)、[**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) は、それぞれ、**GetAlphaMask** と呼ばれるメソッドを実装します。このメソッドは、要素の形状を使用したグレースケール画像を表す **CompositionBrush** を返します。</span><span class="sxs-lookup"><span data-stu-id="27c51-156">[**Image**](https://msdn.microsoft.com/library/windows/apps/br242752), [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652), and [**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) each implement a method called **GetAlphaMask** that returns a **CompositionBrush** representing a grayscale image with the shape of the element.</span></span> <span data-ttu-id="27c51-157">この **CompositionBrush** は、コンポジション **DropShadow** の入力として使用できます。そのため、シャドウでは、四角形ではなく要素の形状を反映することができます。</span><span class="sxs-lookup"><span data-stu-id="27c51-157">This **CompositionBrush** can serve as an input for a Composition **DropShadow**, so the shadow can reflect the shape of the element instead of a rectangle.</span></span> <span data-ttu-id="27c51-158">これにより、テキスト、アルファを含む画像、図形に対して、ピクセル パーフェクトで輪郭ベースのシャドウを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="27c51-158">This enables pixel perfect, contour-based shadows for text, images with alpha, and shapes.</span></span> <span data-ttu-id="27c51-159">この API の例については、以下の「*ドロップ シャドウ*」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-159">See *Drop Shadow* below for an example of this API.</span></span>

## <a name="recipes"></a><span data-ttu-id="27c51-160">レシピ</span><span class="sxs-lookup"><span data-stu-id="27c51-160">Recipes</span></span>

### <a name="reposition-animation"></a><span data-ttu-id="27c51-161">位置変更アニメーション</span><span class="sxs-lookup"><span data-stu-id="27c51-161">Reposition animation</span></span>

<span data-ttu-id="27c51-162">コンポジションの暗黙的なアニメーションを使用すると、開発者は、要素の親の位置を基準とした、要素のレイアウトにおける変更を自動的にアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="27c51-162">Using Composition Implicit Animations, a developer can automatically animate changes in an element’s layout relative to its parent.</span></span> <span data-ttu-id="27c51-163">たとえば、以下に示すボタンの **Margin** を変更した場合に、その新しいレイアウト位置に対して自動的にアニメーション化が行われます。</span><span class="sxs-lookup"><span data-stu-id="27c51-163">For example, if you change the **Margin** of the button below, it will automatically animate to its new layout position.</span></span>

#### <a name="implementation-overview"></a><span data-ttu-id="27c51-164">実装の概要</span><span class="sxs-lookup"><span data-stu-id="27c51-164">Implementation overview</span></span>

1. <span data-ttu-id="27c51-165">ターゲット要素のハンドアウト **Visual** を取得します</span><span class="sxs-lookup"><span data-stu-id="27c51-165">Get the handout **Visual** for the target element</span></span>
1. <span data-ttu-id="27c51-166">**Offset** プロパティの変更を自動的にアニメーション化する **ImplicitAnimationCollection** を作成します</span><span class="sxs-lookup"><span data-stu-id="27c51-166">Create an **ImplicitAnimationCollection** that automatically animates changes in the **Offset** property</span></span>
1. <span data-ttu-id="27c51-167">**ImplicitAnimationCollection** をバッキング Visual に関連付けます</span><span class="sxs-lookup"><span data-stu-id="27c51-167">Associate the **ImplicitAnimationCollection** with the backing Visual</span></span>

```xaml
<Button x:Name="RepositionTarget" Content="Click Me" />
```

```csharp
public MainPage()
{
    InitializeComponent();
    InitializeRepositionAnimation(RepositionTarget);
}

private void InitializeRepositionAnimation(UIElement repositionTarget)
{
    var targetVisual = ElementCompositionPreview.GetElementVisual(repositionTarget);
    Compositor compositor = targetVisual.Compositor;

    // Create an animation to animate targetVisual's Offset property to its final value
    var repositionAnimation = compositor.CreateVector3KeyFrameAnimation();
    repositionAnimation.Duration = TimeSpan.FromSeconds(0.66);
    repositionAnimation.Target = "Offset";
    repositionAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");

    // Run this animation when the Offset Property is changed
    var repositionAnimations = compositor.CreateImplicitAnimationCollection();
    repositionAnimations["Offset"] = repositionAnimation;

    targetVisual.ImplicitAnimations = repositionAnimations;
}
```

### <a name="drop-shadow"></a><span data-ttu-id="27c51-168">ドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="27c51-168">Drop shadow</span></span>

<span data-ttu-id="27c51-169">ピクセル パーフェクトなドロップ シャドウを **UIElement** (たとえば、画像を含んでいる**楕円**) に適用します。</span><span class="sxs-lookup"><span data-stu-id="27c51-169">Apply a pixel-perfect drop shadow to a **UIElement**, for example an **Ellipse** containing a picture.</span></span> <span data-ttu-id="27c51-170">シャドウでは、アプリで作成される **SpriteVisual** が必要となるため、**ElementCompositionPreview.SetElementChildVisual** を使用して、**SpriteVisual** が含まれる “ホスト” 要素を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="27c51-170">Since the shadow requires a **SpriteVisual** created by the app, we need to create a “host” element which will contain the **SpriteVisual** using **ElementCompositionPreview.SetElementChildVisual**.</span></span>

#### <a name="implementation-overview"></a><span data-ttu-id="27c51-171">実装の概要</span><span class="sxs-lookup"><span data-stu-id="27c51-171">Implementation overview</span></span>

1. <span data-ttu-id="27c51-172">ホスト要素のハンドアウト **Visual** を取得します</span><span class="sxs-lookup"><span data-stu-id="27c51-172">Get the handout **Visual** for the host element</span></span>
2. <span data-ttu-id="27c51-173">Windows.UI.Composition の **DropShadow** を作成します</span><span class="sxs-lookup"><span data-stu-id="27c51-173">Create a Windows.UI.Composition **DropShadow**</span></span>
3. <span data-ttu-id="27c51-174">マスクを使用してターゲット要素から図形を取得するように、**DropShadow** を構成します</span><span class="sxs-lookup"><span data-stu-id="27c51-174">Configure the **DropShadow** to get its shape from the target element via a mask</span></span>
    - <span data-ttu-id="27c51-175">
              既定では、\*\*DropShadow\*\* は四角形になります。つまり、ターゲットが四角形である場合は、この構成は必要ありません</span><span class="sxs-lookup"><span data-stu-id="27c51-175">**DropShadow** is rectangular by default, so this is not necessary if the target is rectangular</span></span>
4. <span data-ttu-id="27c51-176">シャドウを新しい **SpriteVisual** にアタッチし、**SpriteVisual** をホスト要素の子として設定します</span><span class="sxs-lookup"><span data-stu-id="27c51-176">Attach shadow to a new **SpriteVisual**, and set the **SpriteVisual** as the child of the host element</span></span>
5. <span data-ttu-id="27c51-177">**ExpressionAnimation** を使用して、**SpriteVisual** のサイズをホストのサイズにバインドします</span><span class="sxs-lookup"><span data-stu-id="27c51-177">Bind size of the **SpriteVisual** to the size of the host using an **ExpressionAnimation**</span></span>

```xaml
<Grid Width="200" Height="200">
    <Canvas x:Name="ShadowHost" />
    <Ellipse x:Name="CircleImage">
        <Ellipse.Fill>
            <ImageBrush ImageSource="Assets/Images/2.jpg" Stretch="UniformToFill" />
        </Ellipse.Fill>
    </Ellipse>
</Grid>
```

```csharp
public MainPage()
{
    InitializeComponent();
    InitializeDropShadow(ShadowHost, CircleImage);
}

private void InitializeDropShadow(UIElement shadowHost, Shape shadowTarget)
{
    Visual hostVisual = ElementCompositionPreview.GetElementVisual(shadowHost);
    Compositor compositor = hostVisual.Compositor;

    // Create a drop shadow
    var dropShadow = compositor.CreateDropShadow();
    dropShadow.Color = Color.FromArgb(255, 75, 75, 80);
    dropShadow.BlurRadius = 15.0f;
    dropShadow.Offset = new Vector3(2.5f, 2.5f, 0.0f);
    // Associate the shape of the shadow with the shape of the target element
    dropShadow.Mask = shadowTarget.GetAlphaMask();

    // Create a Visual to hold the shadow
    var shadowVisual = compositor.CreateSpriteVisual();
    shadowVisual.Shadow = dropShadow;

    // Add the shadow as a child of the host in the visual tree
   ElementCompositionPreview.SetElementChildVisual(shadowHost, shadowVisual);

    // Make sure size of shadow host and shadow visual always stay in sync
    var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
    bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);

    shadowVisual.StartAnimation("Size", bindSizeAnimation);
}
```

<span data-ttu-id="27c51-178">次の 2 つの一覧では、同じ XAML 構造を使用する、以前の C&#35; コードと同等の [C++/WinRT](https://aka.ms/cppwinrt) および [C++/CX](https://docs.microsoft.com/cpp/cppcx/visual-c-language-reference-c-cx) を示しています。</span><span class="sxs-lookup"><span data-stu-id="27c51-178">The following two listings show the [C++/WinRT](https://aka.ms/cppwinrt) and [C++/CX](https://docs.microsoft.com/cpp/cppcx/visual-c-language-reference-c-cx) equivalents of the previous C&#35; code using the same XAML structure.</span></span>

```cppwinrt
#include <winrt/Windows.UI.Composition.h>
#include <winrt/Windows.UI.Xaml.h>
#include <winrt/Windows.UI.Xaml.Hosting.h>
#include <winrt/Windows.UI.Xaml.Shapes.h>
...
MainPage()
{
    InitializeComponent();
    InitializeDropShadow(ShadowHost(), CircleImage());
}

int32_t MyProperty();
void MyProperty(int32_t value);

void InitializeDropShadow(Windows::UI::Xaml::UIElement const& shadowHost, Windows::UI::Xaml::Shapes::Shape const& shadowTarget)
{
    auto hostVisual{ Windows::UI::Xaml::Hosting::ElementCompositionPreview::GetElementVisual(shadowHost) };
    auto compositor{ hostVisual.Compositor() };

    // Create a drop shadow
    auto dropShadow{ compositor.CreateDropShadow() };
    dropShadow.Color(Windows::UI::ColorHelper::FromArgb(255, 75, 75, 80));
    dropShadow.BlurRadius(15.0f);
    dropShadow.Offset(Windows::Foundation::Numerics::float3{ 2.5f, 2.5f, 0.0f });
    // Associate the shape of the shadow with the shape of the target element
    dropShadow.Mask(shadowTarget.GetAlphaMask());

    // Create a Visual to hold the shadow
    auto shadowVisual = compositor.CreateSpriteVisual();
    shadowVisual.Shadow(dropShadow);

    // Add the shadow as a child of the host in the visual tree
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(shadowHost, shadowVisual);

    // Make sure size of shadow host and shadow visual always stay in sync
    auto bindSizeAnimation{ compositor.CreateExpressionAnimation(L"hostVisual.Size") };
    bindSizeAnimation.SetReferenceParameter(L"hostVisual", hostVisual);

    shadowVisual.StartAnimation(L"Size", bindSizeAnimation);
}
```

```cpp
#include "WindowsNumerics.h"

MainPage::MainPage()
{
    InitializeComponent();
    InitializeDropShadow(ShadowHost, CircleImage);
}

void MainPage::InitializeDropShadow(Windows::UI::Xaml::UIElement^ shadowHost, Windows::UI::Xaml::Shapes::Shape^ shadowTarget)
{
    auto hostVisual = Windows::UI::Xaml::Hosting::ElementCompositionPreview::GetElementVisual(shadowHost);
    auto compositor = hostVisual->Compositor;

    // Create a drop shadow
    auto dropShadow = compositor->CreateDropShadow();
    dropShadow->Color = Windows::UI::ColorHelper::FromArgb(255, 75, 75, 80);
    dropShadow->BlurRadius = 15.0f;
    dropShadow->Offset = Windows::Foundation::Numerics::float3(2.5f, 2.5f, 0.0f);
    // Associate the shape of the shadow with the shape of the target element
    dropShadow->Mask = shadowTarget->GetAlphaMask();

    // Create a Visual to hold the shadow
    auto shadowVisual = compositor->CreateSpriteVisual();
    shadowVisual->Shadow = dropShadow;

    // Add the shadow as a child of the host in the visual tree
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(shadowHost, shadowVisual);

    // Make sure size of shadow host and shadow visual always stay in sync
    auto bindSizeAnimation = compositor->CreateExpressionAnimation("hostVisual.Size");
    bindSizeAnimation->SetReferenceParameter("hostVisual", hostVisual);

    shadowVisual->StartAnimation("Size", bindSizeAnimation);
}
```

### <a name="frosted-glass"></a><span data-ttu-id="27c51-179">すりガラス</span><span class="sxs-lookup"><span data-stu-id="27c51-179">Frosted glass</span></span>

<span data-ttu-id="27c51-180">背景コンテンツをぼかしたり、濃淡を付けたりする効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="27c51-180">Create an effect that blurs and tints background content.</span></span> <span data-ttu-id="27c51-181">開発者は、効果を使用するために Win2D NuGet パッケージをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="27c51-181">Note that developers need to install the Win2D NuGet package to use effects.</span></span> <span data-ttu-id="27c51-182">インストール手順については、[Win2D のホームページ](http://microsoft.github.io/Win2D/html/Introduction.htm) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27c51-182">See the [Win2D homepage](http://microsoft.github.io/Win2D/html/Introduction.htm) for installation instructions.</span></span>

#### <a name="implementation-overview"></a><span data-ttu-id="27c51-183">実装の概要</span><span class="sxs-lookup"><span data-stu-id="27c51-183">Implementation overview</span></span>

1.  <span data-ttu-id="27c51-184">ホスト要素のハンドアウト **Visual** を取得します</span><span class="sxs-lookup"><span data-stu-id="27c51-184">Get handout **Visual** for the host element</span></span>
2.  <span data-ttu-id="27c51-185">Win2D と **CompositionEffectSourceParameter** を使用して、ぼかし効果ツリーを作成します</span><span class="sxs-lookup"><span data-stu-id="27c51-185">Create a blur effect tree using Win2D and **CompositionEffectSourceParameter**</span></span>
3.  <span data-ttu-id="27c51-186">効果ツリーに基づいて **CompositionEffectBrush** を作成します</span><span class="sxs-lookup"><span data-stu-id="27c51-186">Create a **CompositionEffectBrush** based on the effect tree</span></span>
4.  <span data-ttu-id="27c51-187">**CompositionEffectBrush** の入力を **CompositionBackdropBrush** に設定します。これにより、効果が **SpriteVisual** の背景にあるコンテンツに適用されます</span><span class="sxs-lookup"><span data-stu-id="27c51-187">Set input of the **CompositionEffectBrush** to a **CompositionBackdropBrush**, which allows an effect to be applied to the content behind a **SpriteVisual**</span></span>
5.  <span data-ttu-id="27c51-188">**CompositionEffectBrush** を新しい **SpriteVisual** のコンテンツとして設定し、**SpriteVisual** をホスト要素の子として設定します。</span><span class="sxs-lookup"><span data-stu-id="27c51-188">Set the **CompositionEffectBrush** as the content of a new **SpriteVisual**, and set the **SpriteVisual** as the child of the host element.</span></span> <span data-ttu-id="27c51-189">代わりに XamlCompositionBrushBase を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="27c51-189">You could alternative use a XamlCompositionBrushBase.</span></span>
6.  <span data-ttu-id="27c51-190">**ExpressionAnimation** を使用して、**SpriteVisual** のサイズをホストのサイズにバインドします</span><span class="sxs-lookup"><span data-stu-id="27c51-190">Bind size of the **SpriteVisual** to the size of the host using an **ExpressionAnimation**</span></span>

```xaml
<Grid Width="300" Height="300" Grid.Column="1">
    <Image
        Source="Assets/Images/2.jpg"
        Width="200"
        Height="200" />
    <Canvas
        x:Name="GlassHost"
        Width="150"
        Height="300"
        HorizontalAlignment="Right" />
</Grid>
```

```csharp
public MainPage()
{
    InitializeComponent();
    InitializeFrostedGlass(GlassHost);
}

private void InitializeFrostedGlass(UIElement glassHost)
{
    Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
    Compositor compositor = hostVisual.Compositor;

    // Create a glass effect, requires Win2D NuGet package
    var glassEffect = new GaussianBlurEffect
    { 
        BlurAmount = 15.0f,
        BorderMode = EffectBorderMode.Hard,
        Source = new ArithmeticCompositeEffect
        {
            MultiplyAmount = 0,
            Source1Amount = 0.5f,
            Source2Amount = 0.5f,
            Source1 = new CompositionEffectSourceParameter("backdropBrush"),
            Source2 = new ColorSourceEffect
            {
                Color = Color.FromArgb(255, 245, 245, 245)
            }
        }
    };

    //  Create an instance of the effect and set its source to a CompositionBackdropBrush
    var effectFactory = compositor.CreateEffectFactory(glassEffect);
    var backdropBrush = compositor.CreateBackdropBrush();
    var effectBrush = effectFactory.CreateBrush();

    effectBrush.SetSourceParameter("backdropBrush", backdropBrush);

    // Create a Visual to contain the frosted glass effect
    var glassVisual = compositor.CreateSpriteVisual();
    glassVisual.Brush = effectBrush;

    // Add the blur as a child of the host in the visual tree
    ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);

    // Make sure size of glass host and glass visual always stay in sync
    var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
    bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);

    glassVisual.StartAnimation("Size", bindSizeAnimation);
}
```

## <a name="additional-resources"></a><span data-ttu-id="27c51-191">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="27c51-191">Additional Resources</span></span>

- [<span data-ttu-id="27c51-192">ビジュアル レイヤーの概要</span><span class="sxs-lookup"><span data-stu-id="27c51-192">Visual Layer overview</span></span>](https://msdn.microsoft.com/windows/uwp/composition/visual-layer)
- [<span data-ttu-id="27c51-193">**ElementCompositionPreview** クラス</span><span class="sxs-lookup"><span data-stu-id="27c51-193">**ElementCompositionPreview** class</span></span>](https://msdn.microsoft.com/library/windows/apps/mt608976)
- <span data-ttu-id="27c51-194">[WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs) にある高度な UI とコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="27c51-194">Advanced UI and Composition samples in the [WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs)</span></span>
- [<span data-ttu-id="27c51-195">BasicXamlInterop のサンプル</span><span class="sxs-lookup"><span data-stu-id="27c51-195">BasicXamlInterop sample</span></span>](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2010586/BasicXamlInterop)
- [<span data-ttu-id="27c51-196">ParallaxingListItems のサンプル</span><span class="sxs-lookup"><span data-stu-id="27c51-196">ParallaxingListItems sample</span></span>](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2010586/ParallaxingListItems)
