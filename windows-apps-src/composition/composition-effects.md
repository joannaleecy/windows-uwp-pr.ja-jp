---
ms.assetid: 6e9b9ff2-234b-6f63-0975-1afb2d86ba1a
title: コンポジション効果
description: 効果 API を使用すると、開発者は UI のレンダリング方法をカスタマイズできます。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 75af433d80364485b0c12a9540c0d7bb471c4e28
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8208765"
---
# <a name="composition-effects"></a><span data-ttu-id="6aaa1-104">コンポジション効果</span><span class="sxs-lookup"><span data-stu-id="6aaa1-104">Composition effects</span></span>

<span data-ttu-id="6aaa1-105">[**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) API により、アニメーション化可能な効果プロパティを持つ画像と UI にリアルタイムの効果を適用できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-105">The [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) APIs allows real-time effects to be applied to images and UI with animatable effect properties.</span></span> <span data-ttu-id="6aaa1-106">この概要では、コンポジションのビジュアルに効果を適用するために使用できる機能に目を通します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-106">In this overview, we’ll run through the functionality available that allows effects to be applied to a composition visual.</span></span>

<span data-ttu-id="6aaa1-107">アプリケーションの効果を記述する開発者に対して [ユニバーサル Windows プラットフォーム (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) との整合性をサポートするには、コンポジション効果で Win2D の IGraphicsEffect インターフェイスを活用し、[Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.htm) 名前空間を介して効果記述子を使用します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-107">To support [Universal Windows Platform (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) consistency for developers describing effects in their applications, composition effects leverage Win2D’s IGraphicsEffect interface to use effect descriptions via the [Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.htm) Namespace.</span></span>

<span data-ttu-id="6aaa1-108">ブラシ効果は、一連の既存画像に効果を適用することでアプリケーションの領域をペイントするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-108">Brush effects are used to paint areas of an application by applying effects to a set of existing images.</span></span> <span data-ttu-id="6aaa1-109">Windows 10 のコンポジション効果 API ではスプライト ビジュアルが重視されます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-109">Windows 10 composition effect APIs are focused on Sprite Visuals.</span></span> <span data-ttu-id="6aaa1-110">SpriteVisual を使うと、色、画像、効果の作成で柔軟性と関係性を得られます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-110">The SpriteVisual allows for flexibility and interplay in color, image and effect creation.</span></span> <span data-ttu-id="6aaa1-111">SpriteVisual は、2D の四角形をブラシで埋めることができるコンポジション ビジュアル タイプです。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-111">The SpriteVisual is a composition visual type that can fill a 2D rectangle with a brush.</span></span> <span data-ttu-id="6aaa1-112">ビジュアルは四角形の境界を定義し、ブラシは四角形のペイントに使用されるピクセルを定義します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-112">The visual defines the bounds of the rectangle and the brush defines the pixels used to paint the rectangle.</span></span>

<span data-ttu-id="6aaa1-113">効果ブラシは、コンテンツが効果グラフの出力に基づくコンポジション ツリー ビジュアルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-113">Effect brushes are used on composition tree visuals whose content comes from the output of an effect graph.</span></span> <span data-ttu-id="6aaa1-114">効果は既存のサーフェスとテクスチャを参照できますが、他のコンポジション ツリーの出力は参照できません。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-114">Effects can reference existing surfaces/textures, but not the output of other composition trees.</span></span>

<span data-ttu-id="6aaa1-115">[**XamlCompositionBrushBase**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase) で効果ブラシを使って、XAML UIElement に効果を適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-115">Effects can also be applied to XAML UIElements using an effect brush with [**XamlCompositionBrushBase**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

## <a name="effect-features"></a><span data-ttu-id="6aaa1-116">効果機能</span><span class="sxs-lookup"><span data-stu-id="6aaa1-116">Effect Features</span></span>

- [<span data-ttu-id="6aaa1-117">効果ライブラリ</span><span class="sxs-lookup"><span data-stu-id="6aaa1-117">Effect Library</span></span>](./composition-effects.md#effect-library)
- [<span data-ttu-id="6aaa1-118">チェーン効果</span><span class="sxs-lookup"><span data-stu-id="6aaa1-118">Chaining Effects</span></span>](./composition-effects.md#chaining-effects)
- [<span data-ttu-id="6aaa1-119">アニメーションのサポート</span><span class="sxs-lookup"><span data-stu-id="6aaa1-119">Animation Support</span></span>](./composition-effects.md#animation-support)
- [<span data-ttu-id="6aaa1-120">効果プロパティ: 固定とアニメーション化</span><span class="sxs-lookup"><span data-stu-id="6aaa1-120">Constant vs. Animated Effect Properties</span></span>](./composition-effects.md#constant-vs-animated-effect-properties)
- [<span data-ttu-id="6aaa1-121">独立したプロパティを持つ複数の効果インスタンス</span><span class="sxs-lookup"><span data-stu-id="6aaa1-121">Multiple Effect Instances with Independent Properties</span></span>](./composition-effects.md#multiple-effect-instances-with-independent-properties)

### <a name="effect-library"></a><span data-ttu-id="6aaa1-122">効果ライブラリ</span><span class="sxs-lookup"><span data-stu-id="6aaa1-122">Effect Library</span></span>

<span data-ttu-id="6aaa1-123">現在、コンポジションでは次の効果がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-123">Currently composition supports the following effects:</span></span>

| <span data-ttu-id="6aaa1-124">効果</span><span class="sxs-lookup"><span data-stu-id="6aaa1-124">Effect</span></span>               | <span data-ttu-id="6aaa1-125">説明</span><span class="sxs-lookup"><span data-stu-id="6aaa1-125">Description</span></span>                                                                                                                                                                                                                |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6aaa1-126">2D アフィン変換</span><span class="sxs-lookup"><span data-stu-id="6aaa1-126">2D affine transform</span></span>  | <span data-ttu-id="6aaa1-127">画像に 2D アフィン変換マトリックスを適用します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-127">Applies a 2D affine transform matrix to an image.</span></span> <span data-ttu-id="6aaa1-128">効果の [サンプル](http://go.microsoft.com/fwlink/?LinkId=785341) では、アルファ マスクのアニメーション化にこの効果が使われています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-128">We used this effect to animate alpha mask in our effect [samples](http://go.microsoft.com/fwlink/?LinkId=785341).</span></span>       |
| <span data-ttu-id="6aaa1-129">算術コンポジット</span><span class="sxs-lookup"><span data-stu-id="6aaa1-129">Arithmetic composite</span></span> | <span data-ttu-id="6aaa1-130">柔軟な方程式を使って 2 つの画像を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-130">Combines two images using a flexible equation.</span></span> <span data-ttu-id="6aaa1-131">[サンプル](http://go.microsoft.com/fwlink/?LinkId=785341) では、クロスフェード効果の作成に算術コンポジットが使われています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-131">We used arithmetic composite to create a crossfade effect in our [samples](http://go.microsoft.com/fwlink/?LinkId=785341).</span></span> |
| <span data-ttu-id="6aaa1-132">ブレンド効果</span><span class="sxs-lookup"><span data-stu-id="6aaa1-132">Blend effect</span></span>         | <span data-ttu-id="6aaa1-133">2 つの画像を組み合わせるブレンド効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-133">Creates a blend effect that combines two images.</span></span> <span data-ttu-id="6aaa1-134">コンポジションでは、Win2D でサポートされている 26 個の [ブレンド モード](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_Effects_BlendEffectMode.htm) のうち 21 個が用意されています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-134">Composition provides 21 of the 26 [blend modes](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_Effects_BlendEffectMode.htm) supported in Win2D.</span></span>        |
| <span data-ttu-id="6aaa1-135">カラー ソース</span><span class="sxs-lookup"><span data-stu-id="6aaa1-135">Color source</span></span>         | <span data-ttu-id="6aaa1-136">単色が含まれている画像を生成します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-136">Generates an image containing a solid color.</span></span>                                                                                                                                                                               |
| <span data-ttu-id="6aaa1-137">コンポジット</span><span class="sxs-lookup"><span data-stu-id="6aaa1-137">Composite</span></span>            | <span data-ttu-id="6aaa1-138">2 つの画像を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-138">Combines two images.</span></span> <span data-ttu-id="6aaa1-139">コンポジションでは、Win2D でサポートされている 13 個の [コンポジット モード](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_CanvasComposite.htm) がすべて用意されています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-139">Composition provides all 13 [composite modes](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_CanvasComposite.htm) supported in Win2D.</span></span>                                              |
| <span data-ttu-id="6aaa1-140">コントラスト</span><span class="sxs-lookup"><span data-stu-id="6aaa1-140">Contrast</span></span>             | <span data-ttu-id="6aaa1-141">画像のコントラストを増減します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-141">Increases or decreases the contrast of an image.</span></span>                                                                                                                                                                           |
| <span data-ttu-id="6aaa1-142">露出</span><span class="sxs-lookup"><span data-stu-id="6aaa1-142">Exposure</span></span>             | <span data-ttu-id="6aaa1-143">画像の露出を増減します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-143">Increases or decreases the exposure of an image.</span></span>                                                                                                                                                                           |
| <span data-ttu-id="6aaa1-144">グレースケール</span><span class="sxs-lookup"><span data-stu-id="6aaa1-144">Grayscale</span></span>            | <span data-ttu-id="6aaa1-145">画像を灰色のモノクロ画像に変換します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-145">Converts an image to monochromatic gray.</span></span>                                                                                                                                                                                   |
| <span data-ttu-id="6aaa1-146">ガンマ伝達</span><span class="sxs-lookup"><span data-stu-id="6aaa1-146">Gamma transfer</span></span>       | <span data-ttu-id="6aaa1-147">チャネルあたりのガンマ伝達関数を適用することで、画像の色を変更します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-147">Alters the colors of an image by applying a per-channel gamma transfer function.</span></span>                                                                                                                                           |
| <span data-ttu-id="6aaa1-148">色相回転</span><span class="sxs-lookup"><span data-stu-id="6aaa1-148">Hue rotate</span></span>           | <span data-ttu-id="6aaa1-149">色相値を回転することで、画像の色を変更します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-149">Alters the color of an image by rotating its hue values.</span></span>                                                                                                                                                                   |
| <span data-ttu-id="6aaa1-150">反転</span><span class="sxs-lookup"><span data-stu-id="6aaa1-150">Invert</span></span>               | <span data-ttu-id="6aaa1-151">画像の色を反転します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-151">Inverts the colors of an image.</span></span>                                                                                                                                                                                            |
| <span data-ttu-id="6aaa1-152">彩度</span><span class="sxs-lookup"><span data-stu-id="6aaa1-152">Saturate</span></span>             | <span data-ttu-id="6aaa1-153">画像の彩度を変更します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-153">Alters the saturation of an image.</span></span>                                                                                                                                                                                         |
| <span data-ttu-id="6aaa1-154">セピア</span><span class="sxs-lookup"><span data-stu-id="6aaa1-154">Sepia</span></span>                | <span data-ttu-id="6aaa1-155">画像をセピア調に変換します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-155">Converts an image to sepia tones.</span></span>                                                                                                                                                                                          |
| <span data-ttu-id="6aaa1-156">色温度と濃淡</span><span class="sxs-lookup"><span data-stu-id="6aaa1-156">Temperature and tint</span></span> | <span data-ttu-id="6aaa1-157">画像の色温度および濃淡を調整します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-157">Adjusts the temperature and/or tint of an image.</span></span>                                                                                                                                                                           |

<span data-ttu-id="6aaa1-158">詳しくは、Win2D の [Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.htm) 名前空間をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-158">See Win2D’s [Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.htm) Namespace for more detailed information.</span></span> <span data-ttu-id="6aaa1-159">コンポジションでサポートされていない効果は \[NoComposition\] として示されています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-159">Effects not supported in composition are noted as \[NoComposition\].</span></span>

### <a name="chaining-effects"></a><span data-ttu-id="6aaa1-160">チェーン効果</span><span class="sxs-lookup"><span data-stu-id="6aaa1-160">Chaining Effects</span></span>

<span data-ttu-id="6aaa1-161">効果をチェーンして、アプリケーションの画像で複数の効果を同時に使用できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-161">Effects can be chained, allowing an application to simultaneously use multiple effects on an image.</span></span> <span data-ttu-id="6aaa1-162">効果グラフは、相互に参照できる複数の効果をサポートできます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-162">Effect graphs can support multiple effects that can refer to one and other.</span></span> <span data-ttu-id="6aaa1-163">効果を記述するときは、効果に対する入力として効果を追加します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-163">When describing your effect, simply add an effect as input to your effect.</span></span>

```cs
IGraphicsEffect graphicsEffect =
new Microsoft.Graphics.Canvas.Effects.ArithmeticCompositeEffect
{
  Source1 = new CompositionEffectSourceParameter("source1"),
  Source2 = new SaturationEffect
  {
    Saturation = 0,
    Source = new CompositionEffectSourceParameter("source2")
  },
  MultiplyAmount = 0,
  Source1Amount = 0.5f,
  Source2Amount = 0.5f,
  Offset = 0
}
```

<span data-ttu-id="6aaa1-164">先ほどの例では、2 つの入力を受け取る算術コンポジット効果について説明しています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-164">The example above describes an arithmetic composite effect which has two inputs.</span></span> <span data-ttu-id="6aaa1-165">2 番目の入力の彩度効果では、彩度プロパティを 0.5 に設定しています。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-165">The second input has a saturation effect with a .5 saturation property.</span></span>

### <a name="animation-support"></a><span data-ttu-id="6aaa1-166">アニメーションのサポート</span><span class="sxs-lookup"><span data-stu-id="6aaa1-166">Animation Support</span></span>

<span data-ttu-id="6aaa1-167">効果プロパティはアニメーション化をサポートしています。効果のコンパイル時に、効果プロパティをアニメーション化するか、定数として固定するかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-167">Effect properties support animation, during effect compilation you can specify effect properties can be animated and which can be "baked in" as constants.</span></span> <span data-ttu-id="6aaa1-168">アニメーション化可能なプロパティは、「効果名.プロパティ名」という形式の文字列で指定されます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-168">The animatable properties are specified through strings of the form “effect name.property name”.</span></span> <span data-ttu-id="6aaa1-169">これらのプロパティは、効果の複数のインスタンスで個別にアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-169">These properties can be animated independently over multiple instantiations of the effect.</span></span>

### <a name="constant-vs-animated-effect-properties"></a><span data-ttu-id="6aaa1-170">効果プロパティ: 固定とアニメーション化</span><span class="sxs-lookup"><span data-stu-id="6aaa1-170">Constant vs Animated Effect Properties</span></span>

<span data-ttu-id="6aaa1-171">効果のコンパイル時に、効果プロパティを動的に設定されるようにするか、定数として固定されるようにするかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-171">During effect compilation you can specify effect properties as dynamic or as properties that are "baked in" as constants.</span></span> <span data-ttu-id="6aaa1-172">動的プロパティは「<effect name>.<property name>」という形式の文字列で指定します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-172">The dynamic properties are specified through strings of the form “<effect name>.<property name>”.</span></span> <span data-ttu-id="6aaa1-173">動的プロパティを特定の値に設定するか、コンポジションのアニメーション システムを使ってアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-173">The dynamic properties can be set to a specific value or can be animated using the composition animation system.</span></span>

<span data-ttu-id="6aaa1-174">先ほどの効果のコンパイル時、彩度を 0.5 に固定するか、動的に設定される (アニメーション化される) ようにするか、柔軟に選べます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-174">When compiling the effect description above, you have the flexibility of either baking in saturation to be equal to 0.5 or making it dynamic and setting it dynamically or animating it.</span></span>

<span data-ttu-id="6aaa1-175">固定の彩度で効果をコンパイル:</span><span class="sxs-lookup"><span data-stu-id="6aaa1-175">Compiling an effect with saturation baked in:</span></span>

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);
```

<span data-ttu-id="6aaa1-176">動的な彩度で効果をコンパイル:</span><span class="sxs-lookup"><span data-stu-id="6aaa1-176">Compiling an effect with dynamic saturation:</span></span>

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect, new[]{"SaturationEffect.Saturation"});
_catEffect = effectFactory.CreateBrush();
_catEffect.SetSourceParameter("mySource", surfaceBrush);
_catEffect.Properties.InsertScalar("saturationEffect.Saturation", 0f);
```

<span data-ttu-id="6aaa1-177">その後、先ほどの効果の彩度プロパティを静的な値に設定するか、式または ScalarKeyFrame アニメーションのいずれかを使ってアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-177">The saturation property of the effect above can then be either set to a static value or animated using either Expression or ScalarKeyFrame animations.</span></span>

<span data-ttu-id="6aaa1-178">次のように、効果の彩度プロパティのアニメーション化に使われる ScalarKeyFrame を作成できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-178">You can create a ScalarKeyFrame that will be used to animate the Saturation property of an effect like this:</span></span>

```cs
ScalarKeyFrameAnimation effectAnimation = _compositor.CreateScalarKeyFrameAnimation();
            effectAnimation.InsertKeyFrame(0f, 0f);
            effectAnimation.InsertKeyFrame(0.50f, 1f);
            effectAnimation.InsertKeyFrame(1.0f, 0f);
            effectAnimation.Duration = TimeSpan.FromMilliseconds(2500);
            effectAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
```

<span data-ttu-id="6aaa1-179">次のように、効果の彩度プロパティのアニメーション化を始めます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-179">Start the animation on the Saturation property of the effect like this:</span></span>

```cs
catEffect.Properties.StartAnimation("saturationEffect.Saturation", effectAnimation);
```

<span data-ttu-id="6aaa1-180">キー フレームを使った効果プロパティのアニメーション化については、[彩度を下げるアニメーション サンプル](http://go.microsoft.com/fwlink/?LinkId=785342) を、効果や式の使用については、[AlphaMask サンプル](http://go.microsoft.com/fwlink/?LinkId=785343) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-180">See the [Desaturation - Animation sample](http://go.microsoft.com/fwlink/?LinkId=785342) for effect properties animated with key frames and the [AlphaMask sample](http://go.microsoft.com/fwlink/?LinkId=785343) for use of effects and expressions.</span></span>

### <a name="multiple-effect-instances-with-independent-properties"></a><span data-ttu-id="6aaa1-181">独立したプロパティを持つ複数の効果インスタンス</span><span class="sxs-lookup"><span data-stu-id="6aaa1-181">Multiple Effect Instances with Independent Properties</span></span>

<span data-ttu-id="6aaa1-182">効果のコンパイル時にパラメーターが動的であることを指定することにより、パラメーターを効果インスタンスごとに変更できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-182">By specifying that a parameter should be dynamic during effect compilation, the parameter can then be changed on a per-effect instance basis.</span></span> <span data-ttu-id="6aaa1-183">これにより、2 つのビジュアルに同じ効果を使用しても、異なる効果プロパティを使って表示できます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-183">This allows two Visuals to use the same effect but be rendered with different effect properties.</span></span> <span data-ttu-id="6aaa1-184">詳しくは、ColorSource と Blend の [サンプル](http://go.microsoft.com/fwlink/?LinkId=785344) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-184">See the ColorSource and Blend [sample](http://go.microsoft.com/fwlink/?LinkId=785344) for more information.</span></span>

## <a name="getting-started-with-composition-effects"></a><span data-ttu-id="6aaa1-185">コンポジション効果の概要</span><span class="sxs-lookup"><span data-stu-id="6aaa1-185">Getting Started with Composition Effects</span></span>

<span data-ttu-id="6aaa1-186">このクイック スタート チュートリアルでは、効果のいくつかの基本機能の使用方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-186">This quick start tutorial shows you how to make use of some of the basic capabilities of effects.</span></span>

- [<span data-ttu-id="6aaa1-187">Visual Studio のインストール</span><span class="sxs-lookup"><span data-stu-id="6aaa1-187">Installing Visual Studio</span></span>](./composition-effects.md#installing-visual-studio)
- [<span data-ttu-id="6aaa1-188">新しいプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="6aaa1-188">Creating a new project</span></span>](./composition-effects.md#creating-a-new-project)
- [<span data-ttu-id="6aaa1-189">Win2D のインストール</span><span class="sxs-lookup"><span data-stu-id="6aaa1-189">Installing Win2D</span></span>](./composition-effects.md#installing-win2d)
- [<span data-ttu-id="6aaa1-190">コンポジション設定の基本</span><span class="sxs-lookup"><span data-stu-id="6aaa1-190">Setting your Composition Basics</span></span>](./composition-effects.md#setting-your-composition-basics)
- [<span data-ttu-id="6aaa1-191">CompositionSurface ブラシの作成</span><span class="sxs-lookup"><span data-stu-id="6aaa1-191">Creating a CompositionSurface Brush</span></span>](./composition-effects.md#creating-a-compositionsurface-brush)
- [<span data-ttu-id="6aaa1-192">効果の作成、コンパイル、および適用</span><span class="sxs-lookup"><span data-stu-id="6aaa1-192">Creating, Compiling and Applying Effects</span></span>](./composition-effects.md#creating-compiling-and-applying-effects)

### <a name="installing-visual-studio"></a><span data-ttu-id="6aaa1-193">Visual Studio のインストール</span><span class="sxs-lookup"><span data-stu-id="6aaa1-193">Installing Visual Studio</span></span>

- <span data-ttu-id="6aaa1-194">サポートされている Visual Studio バージョンがインストールされていない場合は、「[Visual Studio ダウンロード](https://www.visualstudio.com/downloads/download-visual-studio-vs.aspx)」ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-194">If you don't have a supported version of Visual Studio installed, go to the Visual Studio Downloads page [here](https://www.visualstudio.com/downloads/download-visual-studio-vs.aspx).</span></span>

### <a name="creating-a-new-project"></a><span data-ttu-id="6aaa1-195">新しいプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="6aaa1-195">Creating a new project</span></span>

- <span data-ttu-id="6aaa1-196">[ファイル]、[新規]、[プロジェクト] の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-196">Go to File->New->Project...</span></span>
- <span data-ttu-id="6aaa1-197">[Visual C#] を選択します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-197">Select 'Visual C#'</span></span>
- <span data-ttu-id="6aaa1-198">「空のアプリ (Windows ユニバーサル)」を作成します (Visual Studio 2015)。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-198">Create a 'Blank App (Windows Universal)' (Visual Studio 2015)</span></span>
- <span data-ttu-id="6aaa1-199">選択したプロジェクト名を入力します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-199">Enter a project name of your choosing</span></span>
- <span data-ttu-id="6aaa1-200">[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-200">Click 'OK'</span></span>

### <a name="installing-win2d"></a><span data-ttu-id="6aaa1-201">Win2D のインストール</span><span class="sxs-lookup"><span data-stu-id="6aaa1-201">Installing Win2D</span></span>

<span data-ttu-id="6aaa1-202">Win2D は Nuget.org パッケージとしてリリースされており、効果を使用する前にインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-202">Win2D is released as a Nuget.org package and needs to be installed before you can use effects.</span></span>

<span data-ttu-id="6aaa1-203">Windows 10 用と Windows 8.1 用の 2 つのパッケージ バージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-203">There are two package versions, one for Windows 10 and one for Windows 8.1.</span></span> <span data-ttu-id="6aaa1-204">コンポジション効果の場合、Windows 10 バージョンを使います。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-204">For Composition effects you’ll use the Windows 10 version.</span></span>

- <span data-ttu-id="6aaa1-205">[ツール]、[NuGet パッケージ マネージャー]、[ソリューションの NuGet パッケージの管理] の順にクリックして、NuGet パッケージ マネージャーを起動します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-205">Launch the NuGet Package Manager by going to Tools → NuGet Package Manager → Manage NuGet Packages for Solution.</span></span>
- <span data-ttu-id="6aaa1-206">「Win2D」を検索し、Windows のターゲット バージョンに適したパッケージを選択します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-206">Search for "Win2D" and select the appropriate package for your target version of Windows.</span></span> <span data-ttu-id="6aaa1-207">Windows.UI.Composition は</span><span class="sxs-lookup"><span data-stu-id="6aaa1-207">Because Windows.UI.</span></span> <span data-ttu-id="6aaa1-208">Windows 10 (8.1 ではない) をサポートするため、Win2D.uwp を選択します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-208">Composition supports Windows 10 (not 8.1), select Win2D.uwp.</span></span>
- <span data-ttu-id="6aaa1-209">使用許諾契約書に同意します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-209">Accept the license agreement</span></span>
- <span data-ttu-id="6aaa1-210">[閉じる] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-210">Click 'Close'</span></span>

<span data-ttu-id="6aaa1-211">次のいくつかの手順では、コンポジション API を使って、すべての彩度を除去する彩度効果をこの猫の画像に適用します。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-211">In the next few steps we will use composition API’s to apply a saturation effect to this cat image which will remove all saturation.</span></span> <span data-ttu-id="6aaa1-212">このモデルでは効果が作成され、画像に適用されます。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-212">In this model the effect is created and then applied to an image.</span></span>

![ソース画像](images/composition-cat-source.png)
### <a name="setting-your-composition-basics"></a><span data-ttu-id="6aaa1-214">コンポジション設定の基本</span><span class="sxs-lookup"><span data-stu-id="6aaa1-214">Setting your Composition Basics</span></span>

<span data-ttu-id="6aaa1-215">Windows.UI.Composition コンポジターとルート ContainerVisual の設定方法、およびコア ウィンドウとの関連付け方法の例については、GitHub で [コンポジション ビジュアル ツリーのサンプル](http://go.microsoft.com/fwlink/?LinkId=785345) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-215">See the [Composition Visual Tree Sample](http://go.microsoft.com/fwlink/?LinkId=785345) on our GitHub for an example of how to set up Windows.UI.Composition Compositor, root ContainerVisual, and associate with the Core Window.</span></span>

```cs
_compositor = new Compositor();
_root = _compositor.CreateContainerVisual();
_target = _compositor.CreateTargetForCurrentView();
_target.Root = _root;
_imageFactory = new CompositionImageFactory(_compositor)
Desaturate();
```

### <a name="creating-a-compositionsurface-brush"></a><span data-ttu-id="6aaa1-216">CompositionSurface ブラシの作成</span><span class="sxs-lookup"><span data-stu-id="6aaa1-216">Creating a CompositionSurface Brush</span></span>

```cs
CompositionSurfaceBrush surfaceBrush = _compositor.CreateSurfaceBrush();
LoadImage(surfaceBrush);
```

### <a name="creating-compiling-and-applying-effects"></a><span data-ttu-id="6aaa1-217">効果の作成、コンパイル、および適用</span><span class="sxs-lookup"><span data-stu-id="6aaa1-217">Creating, Compiling and Applying Effects</span></span>

1. <span data-ttu-id="6aaa1-218">グラフィックス効果を作成する</span><span class="sxs-lookup"><span data-stu-id="6aaa1-218">Create the graphics effect</span></span>

    ```cs
    var graphicsEffect = new SaturationEffect
    {
      Saturation = 0.0f,
      Source = new CompositionEffectSourceParameter("mySource")
    };
    ```

1. <span data-ttu-id="6aaa1-219">効果をコンパイルし、効果ブラシを作成する</span><span class="sxs-lookup"><span data-stu-id="6aaa1-219">Compile the effect and create effect brush</span></span>

    ```cs
    var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);

    var catEffect = effectFactory.CreateBrush();
    catEffect.SetSourceParameter("mySource", surfaceBrush);
    ```

1. <span data-ttu-id="6aaa1-220">コンポジション ツリーに SpriteVisual を作成し、効果を適用する</span><span class="sxs-lookup"><span data-stu-id="6aaa1-220">Create a SpriteVisual in the composition tree and apply the effect</span></span>

    ```cs
    var catVisual = _compositor.CreateSpriteVisual();
      catVisual.Brush = catEffect;
      catVisual.Size = new Vector2(219, 300);
      _root.Children.InsertAtBottom(catVisual);
    }
    ```

1. <span data-ttu-id="6aaa1-221">読み込む画像ソースを作成する。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-221">Create your image source to load.</span></span>

    ```cs
    CompositionImage imageSource = _imageFactory.CreateImageFromUri(new Uri("ms-appx:///Assets/cat.png"));
    CompositionImageLoadResult result = await imageSource.CompleteLoadAsync();
    if (result.Status == CompositionImageLoadStatus.Success)
    ```

1. <span data-ttu-id="6aaa1-222">SpriteVisual のサーフェスのサイズとブラシ</span><span class="sxs-lookup"><span data-stu-id="6aaa1-222">Size and brush the surface on the SpriteVisual</span></span>

    ```cs
    brush.Surface = imageSource.Surface;
    ```

1. <span data-ttu-id="6aaa1-223">アプリを実行する – 結果は彩度を下げた猫になるはずです。</span><span class="sxs-lookup"><span data-stu-id="6aaa1-223">Run your app – your results should be a desaturated cat:</span></span>

![彩度を下げた画像](images/composition-cat-desaturated.png)

## <a name="more-information"></a><span data-ttu-id="6aaa1-225">詳細情報</span><span class="sxs-lookup"><span data-stu-id="6aaa1-225">More Information</span></span>

- [<span data-ttu-id="6aaa1-226">Microsoft - コンポジション GitHub</span><span class="sxs-lookup"><span data-stu-id="6aaa1-226">Microsoft – Composition GitHub</span></span>](https://github.com/Microsoft/composition)
- [**<span data-ttu-id="6aaa1-227">Windows.UI.Composition</span><span class="sxs-lookup"><span data-stu-id="6aaa1-227">Windows.UI.Composition</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn706878)
- [<span data-ttu-id="6aaa1-228">Twitter の Windows Composition チーム</span><span class="sxs-lookup"><span data-stu-id="6aaa1-228">Windows Composition team on Twitter</span></span>](https://twitter.com/wincomposition)
- [<span data-ttu-id="6aaa1-229">コンポジションの概要</span><span class="sxs-lookup"><span data-stu-id="6aaa1-229">Composition Overview</span></span>](https://blogs.windows.com/buildingapps/2015/12/08/awaken-your-creativity-with-the-new-windows-ui-composition/)
- [<span data-ttu-id="6aaa1-230">ビジュアル ツリーの基本</span><span class="sxs-lookup"><span data-stu-id="6aaa1-230">Visual Tree Basics</span></span>](composition-visual-tree.md)
- [<span data-ttu-id="6aaa1-231">コンポジションのブラシ</span><span class="sxs-lookup"><span data-stu-id="6aaa1-231">Composition Brushes</span></span>](composition-brushes.md)
- [<span data-ttu-id="6aaa1-232">XamlCompositionBrushBase</span><span class="sxs-lookup"><span data-stu-id="6aaa1-232">XamlCompositionBrushBase</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)
- [<span data-ttu-id="6aaa1-233">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="6aaa1-233">Animation Overview</span></span>](composition-animation.md)
- [<span data-ttu-id="6aaa1-234">BeginDraw と EndDraw によるコンポジションでの DirectX と Direct2D のネイティブ相互運用</span><span class="sxs-lookup"><span data-stu-id="6aaa1-234">Composition native DirectX and Direct2D interoperation with BeginDraw and EndDraw</span></span>](composition-native-interop.md)
