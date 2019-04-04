---
title: XAML プロパティのアニメーション
description: 合成アニメーションを XAML 要素をアニメーション化します。
ms.date: 09/13/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 81da1e769ab171e47a4f4046e8ec7e7c84ecf2d1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630357"
---
# <a name="animating-xaml-elements-with-composition-animations"></a><span data-ttu-id="7b06c-104">合成アニメーションを XAML 要素をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="7b06c-104">Animating XAML elements with composition animations</span></span>

<span data-ttu-id="7b06c-105">この記事では、合成アニメーションのパフォーマンスと XAML のプロパティの設定の容易さと XAML UIElement をアニメーション化できる新しいプロパティについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-105">This article introduces new properties that let you animate a XAML UIElement with the performance of composition animations and the ease of setting XAML properties.</span></span>

<span data-ttu-id="7b06c-106">Windows 10、バージョンは 1809、以前は、UWP アプリでのアニメーションを作成する 2 つの選択肢がありました。</span><span class="sxs-lookup"><span data-stu-id="7b06c-106">Prior to Windows 10, version 1809, you had 2 choices to build animations in your UWP apps:</span></span>

- <span data-ttu-id="7b06c-107">などの XAML の構成要素を使用して、[アニメーションを再検討](storyboarded-animations.md)、または _\* ThemeTransition_と _\* ThemeAnimation_クラス、 [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation)名前空間。</span><span class="sxs-lookup"><span data-stu-id="7b06c-107">use XAML constructs like [Storyboarded animations](storyboarded-animations.md), or the _\*ThemeTransition_ and _\*ThemeAnimation_ classes in the [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation) namespace.</span></span>
- <span data-ttu-id="7b06c-108">」の説明に従って、合成アニメーションを使用して[XAML のビジュアル層を使用して](../../composition/using-the-visual-layer-with-xaml.md)します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-108">use composition animations as described in [Using the Visual Layer with XAML](../../composition/using-the-visual-layer-with-xaml.md).</span></span>

<span data-ttu-id="7b06c-109">ビジュアル層を使用して構築します、XAML を使用してより優れたパフォーマンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-109">Using the visual layer provides better performance than using the XAML constructs.</span></span> <span data-ttu-id="7b06c-110">使用していますが[ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview)要素の取得の基になるコンポジション[Visual](/uwp/api/windows.ui.composition.visual)オブジェクト、および、合成アニメーションでビジュアルをアニメーション化し、使用するより複雑な。</span><span class="sxs-lookup"><span data-stu-id="7b06c-110">But using [ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview) to get the element's underlying composition [Visual](/uwp/api/windows.ui.composition.visual) object, and then animating the Visual with composition animations, is more complex to use.</span></span>

<span data-ttu-id="7b06c-111">Windows 10、バージョンは 1809、以降のプロパティを基になる合成ビジュアルを取得する必要がなく、合成アニメーションを使用して直接 UIElement をアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="7b06c-111">Starting in Windows 10, version 1809, you can animate properties on a UIElement directly using composition animations without the requirement to get the underlying composition Visual.</span></span>

> [!NOTE]
> <span data-ttu-id="7b06c-112">UIElement にこれらのプロパティを使用するには、UWP プロジェクトのターゲット バージョンは 1809 以降にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b06c-112">To use these properties on UIElement, your UWP project target version must be 1809 or later.</span></span> <span data-ttu-id="7b06c-113">プロジェクトのバージョンを構成する方法の詳細については、[バージョン アダプティブ アプリ](../../debug-test-perf/version-adaptive-apps.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7b06c-113">For more info about configuring your project version, see [Version adaptive apps](../../debug-test-perf/version-adaptive-apps.md).</span></span>

## <a name="new-rendering-properties-replace-old-rendering-properties"></a><span data-ttu-id="7b06c-114">新しいレンダリング プロパティは、古いレンダリング プロパティを置き換えます</span><span class="sxs-lookup"><span data-stu-id="7b06c-114">New rendering properties replace old rendering properties</span></span>

<span data-ttu-id="7b06c-115">この表でアニメーション化もできる、UIElement のレンダリングを変更に使用できるプロパティを示します、 [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation)します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-115">This table shows the properties you can use to modify the rendering of a UIElement, that can also be animated with a [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation).</span></span>

| <span data-ttu-id="7b06c-116">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7b06c-116">Property</span></span> | <span data-ttu-id="7b06c-117">種類</span><span class="sxs-lookup"><span data-stu-id="7b06c-117">Type</span></span> | <span data-ttu-id="7b06c-118">説明</span><span class="sxs-lookup"><span data-stu-id="7b06c-118">Description</span></span> |
| -- | -- | -- |
| [<span data-ttu-id="7b06c-119">不透明度</span><span class="sxs-lookup"><span data-stu-id="7b06c-119">Opacity</span></span>](/uwp/api/windows.ui.xaml.uielement.opacity) | <span data-ttu-id="7b06c-120">Double</span><span class="sxs-lookup"><span data-stu-id="7b06c-120">Double</span></span> | <span data-ttu-id="7b06c-121">オブジェクトの不透明度</span><span class="sxs-lookup"><span data-stu-id="7b06c-121">The degree of the object's opacity</span></span> |
| [<span data-ttu-id="7b06c-122">翻訳</span><span class="sxs-lookup"><span data-stu-id="7b06c-122">Translation</span></span>](/uwp/api/windows.ui.xaml.uielement.translation) | <span data-ttu-id="7b06c-123">Vector3</span><span class="sxs-lookup"><span data-stu-id="7b06c-123">Vector3</span></span> | <span data-ttu-id="7b06c-124">要素の X、Y、/Z 位置をシフトします。</span><span class="sxs-lookup"><span data-stu-id="7b06c-124">Shift the X/Y/Z position of the element</span></span> |
| [<span data-ttu-id="7b06c-125">TransformMatrix</span><span class="sxs-lookup"><span data-stu-id="7b06c-125">TransformMatrix</span></span>](/uwp/api/windows.ui.xaml.uielement.transformmatrix) | <span data-ttu-id="7b06c-126">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="7b06c-126">Matrix4x4</span></span> | <span data-ttu-id="7b06c-127">要素に適用する変換行列</span><span class="sxs-lookup"><span data-stu-id="7b06c-127">The transform matrix to apply to the element</span></span> |
| [<span data-ttu-id="7b06c-128">スケール</span><span class="sxs-lookup"><span data-stu-id="7b06c-128">Scale</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | <span data-ttu-id="7b06c-129">Vector3</span><span class="sxs-lookup"><span data-stu-id="7b06c-129">Vector3</span></span> | <span data-ttu-id="7b06c-130">スケール、要素中心点の中央に配置</span><span class="sxs-lookup"><span data-stu-id="7b06c-130">Scale the element, centered on the CenterPoint</span></span> |
| [<span data-ttu-id="7b06c-131">回転</span><span class="sxs-lookup"><span data-stu-id="7b06c-131">Rotation</span></span>](/uwp/api/windows.ui.xaml.uielement.rotation) | <span data-ttu-id="7b06c-132">Float</span><span class="sxs-lookup"><span data-stu-id="7b06c-132">Float</span></span> | <span data-ttu-id="7b06c-133">RotationAxis および中心点を中心、要素を回転させる</span><span class="sxs-lookup"><span data-stu-id="7b06c-133">Rotate the element around the RotationAxis and CenterPoint</span></span> |
| [<span data-ttu-id="7b06c-134">RotationAxis</span><span class="sxs-lookup"><span data-stu-id="7b06c-134">RotationAxis</span></span>](/uwp/api/windows.ui.xaml.uielement.rotationaxis) | <span data-ttu-id="7b06c-135">Vector3</span><span class="sxs-lookup"><span data-stu-id="7b06c-135">Vector3</span></span> | <span data-ttu-id="7b06c-136">回転の軸</span><span class="sxs-lookup"><span data-stu-id="7b06c-136">The axis of rotation</span></span> |
| [<span data-ttu-id="7b06c-137">CenterPoint</span><span class="sxs-lookup"><span data-stu-id="7b06c-137">CenterPoint</span></span>](/uwp/api/windows.ui.xaml.uielement.centerpoint) | <span data-ttu-id="7b06c-138">Vector3</span><span class="sxs-lookup"><span data-stu-id="7b06c-138">Vector3</span></span> | <span data-ttu-id="7b06c-139">拡大縮小や回転の中心点</span><span class="sxs-lookup"><span data-stu-id="7b06c-139">The center point of scale and rotation</span></span> |

<span data-ttu-id="7b06c-140">TransformMatrix プロパティの値は、次の順序でスケール、回転、および変換のプロパティと組み合わせます。Scale、Rotation、Translation と平行移動します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-140">The TransformMatrix property value is combined with the Scale, Rotation, and Translation properties in the following order:  TransformMatrix, Scale, Rotation, Translation.</span></span>

<span data-ttu-id="7b06c-141">これらのプロパティは、要素のレイアウトに影響はありません、ためこれらのプロパティを変更するは発生しません新しい[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)/[配置](/uwp/api/windows.ui.xaml.uielement.arrange)渡します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-141">These properties don't affect the element's layout, so modifying these properties does not cause a new [Measure](/uwp/api/windows.ui.xaml.uielement.measure)/[Arrange](/uwp/api/windows.ui.xaml.uielement.arrange) pass.</span></span>

<span data-ttu-id="7b06c-142">これらのプロパティとしてコンポジションに似た名前の付いたプロパティの目的と動作が同じである[Visual](/uwp/api/windows.ui.composition.visual)クラス (を除く翻訳は、ビジュアルではありません)。</span><span class="sxs-lookup"><span data-stu-id="7b06c-142">These properties have the same purpose and behavior as the like-named properties on the composition [Visual](/uwp/api/windows.ui.composition.visual) class (except for Translation, which isn't on Visual).</span></span>

### <a name="example-setting-the-scale-property"></a><span data-ttu-id="7b06c-143">以下に例を示します。スケールのプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="7b06c-143">Example: Setting the Scale property</span></span>

<span data-ttu-id="7b06c-144">この例では、ボタンのスケールのプロパティを設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-144">This example shows how to set the Scale property on a Button.</span></span>

```xaml
<Button Scale="2,2,1" Content="I am a large button" />
```

```csharp
var button = new Button();
button.Content = "I am a large button";
button.Scale = new Vector3(2.0f,2.0f,1.0f);
```

### <a name="mutual-exclusivity-between-new-and-old-properties"></a><span data-ttu-id="7b06c-145">新規および既存のプロパティの間で相互に排他的</span><span class="sxs-lookup"><span data-stu-id="7b06c-145">Mutual exclusivity between new and old properties</span></span>

> [!NOTE]
> <span data-ttu-id="7b06c-146">**不透明度**プロパティでは、このセクションで説明されている相互に排他的は強制されません。</span><span class="sxs-lookup"><span data-stu-id="7b06c-146">The **Opacity** property does not enforce the mutual exclusivity described in this section.</span></span> <span data-ttu-id="7b06c-147">XAML または合成アニメーションを使用するかどうかは、同じ不透明度プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-147">You use the same Opacity property whether you use XAML or composition animations.</span></span>

<span data-ttu-id="7b06c-148">CompositionAnimation をアニメーション化できるプロパティは、いくつかの既存の UIElement プロパティの置き換えです。</span><span class="sxs-lookup"><span data-stu-id="7b06c-148">The properties that can be animated with a CompositionAnimation are replacements for several existing UIElement properties:</span></span>

- [<span data-ttu-id="7b06c-149">RenderTransform</span><span class="sxs-lookup"><span data-stu-id="7b06c-149">RenderTransform</span></span>](/uwp/api/windows.ui.xaml.uielement.rendertransform)
- [<span data-ttu-id="7b06c-150">RenderTransformOrigin</span><span class="sxs-lookup"><span data-stu-id="7b06c-150">RenderTransformOrigin</span></span>](/uwp/api/windows.ui.xaml.uielement.rendertransformorigin)
- [<span data-ttu-id="7b06c-151">射影</span><span class="sxs-lookup"><span data-stu-id="7b06c-151">Projection</span></span>](/uwp/api/windows.ui.xaml.uielement.projection)
- [<span data-ttu-id="7b06c-152">Transform3D</span><span class="sxs-lookup"><span data-stu-id="7b06c-152">Transform3D</span></span>](/uwp/api/windows.ui.xaml.uielement.transform3d)

<span data-ttu-id="7b06c-153">または設定すると (アニメーション化する)、新しいプロパティのいずれか、古いプロパティを使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="7b06c-153">When you set (or animate) any of the new properties, you cannot use the old properties.</span></span> <span data-ttu-id="7b06c-154">逆に、設定 (またはアニメーション化する) 場合、古いプロパティのいずれかは、新しいプロパティを使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="7b06c-154">Conversely, if you set (or animate) any of the old properties, you cannot use the new properties.</span></span>

<span data-ttu-id="7b06c-155">使用することもできない新しいプロパティを取得し、これらのメソッドを使用して自分でビジュアルを管理する ElementCompositionPreview を使用する場合。</span><span class="sxs-lookup"><span data-stu-id="7b06c-155">You also cannot use the new properties if you use ElementCompositionPreview to get and manage the Visual yourself using these methods:</span></span>

- [<span data-ttu-id="7b06c-156">ElementCompositionPreview.GetElementVisual</span><span class="sxs-lookup"><span data-stu-id="7b06c-156">ElementCompositionPreview.GetElementVisual</span></span>](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual)
- [<span data-ttu-id="7b06c-157">ElementCompositionPreview.SetIsTranslationEnabled</span><span class="sxs-lookup"><span data-stu-id="7b06c-157">ElementCompositionPreview.SetIsTranslationEnabled</span></span>](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.setistranslationenabled)

> [!IMPORTANT]
> <span data-ttu-id="7b06c-158">2 つのプロパティのセットを併用しようとして失敗し、エラー メッセージを生成するには、API 呼び出しになります。</span><span class="sxs-lookup"><span data-stu-id="7b06c-158">Attempting to mix the use of the two sets of properties will cause the API call to fail and produce an error message.</span></span>

<span data-ttu-id="7b06c-159">わかりやすくするためにはお勧めしませんが、オフにすると、プロパティの 1 つのセットから切り替えるになります。</span><span class="sxs-lookup"><span data-stu-id="7b06c-159">It’s possible to switch from one set of properties by clearing them, though for simplicity it's not recommended.</span></span> <span data-ttu-id="7b06c-160">プロパティは、DependencyProperty でバックアップされている場合 (たとえば、UIElement.Projection 支え UIElement.ProjectionProperty)、「未使用」の状態に復元する ClearValue を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-160">If the property is backed by a DependencyProperty (for example, UIElement.Projection is backed by UIElement.ProjectionProperty), then call ClearValue to restore it to its "unused" state.</span></span> <span data-ttu-id="7b06c-161">(たとえば、スケールのプロパティ)、それ以外の場合は、既定値に、プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-161">Otherwise (for example, the Scale property), set the property to its default value.</span></span>

## <a name="animating-uielement-properties-with-compositionanimation"></a><span data-ttu-id="7b06c-162">CompositionAnimation の UIElement のプロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="7b06c-162">Animating UIElement properties with CompositionAnimation</span></span>

<span data-ttu-id="7b06c-163">CompositionAnimation での表に表示プロパティをアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="7b06c-163">You can animate the rendering properties listed in the table with a CompositionAnimation.</span></span> <span data-ttu-id="7b06c-164">これらのプロパティを参照することも、 [ExpressionAnimation](/uwp/api/windows.ui.composition.expressionanimation)します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-164">These properties can also be referenced by an [ExpressionAnimation](/uwp/api/windows.ui.composition.expressionanimation).</span></span>

<span data-ttu-id="7b06c-165">使用して、 [StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation)と[StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation) UIElement UIElement プロパティをアニメーション化するメソッド。</span><span class="sxs-lookup"><span data-stu-id="7b06c-165">Use the [StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation) and [StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation) methods on UIElement to animate the UIElement properties.</span></span>

### <a name="example-animating-the-scale-property-with-a-vector3keyframeanimation"></a><span data-ttu-id="7b06c-166">以下に例を示します。Vector3KeyFrameAnimation とスケールのプロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="7b06c-166">Example: Animating the Scale property with a Vector3KeyFrameAnimation</span></span>

<span data-ttu-id="7b06c-167">この例では、ボタンの小数点以下桁数をアニメーション化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7b06c-167">This example shows how to animate the scale of a Button.</span></span>

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateVector3KeyFrameAnimation();

animation.InsertKeyFrame(1.0f, new Vector3(2.0f,2.0f,1.0f));
animation.Duration = TimeSpan.FromSeconds(1);
animation.Target = "Scale";

button.StartAnimation(animation);
```

### <a name="example-animating-the-scale-property-with-an-expressionanimation"></a><span data-ttu-id="7b06c-168">以下に例を示します。ExpressionAnimation とスケールのプロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="7b06c-168">Example: Animating the Scale property with an ExpressionAnimation</span></span>

<span data-ttu-id="7b06c-169">ページには、2 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="7b06c-169">A page has two buttons.</span></span> <span data-ttu-id="7b06c-170">2 番目のボタンを 2 倍に (スケール) を使用してアニメーションの最初のボタンとして。</span><span class="sxs-lookup"><span data-stu-id="7b06c-170">The second button animates to be twice as large (via scale) as the first button.</span></span>

```xaml
<Button x:Name="sourceButton" Content="Source"/>
<Button x:Name="destinationButton" Content="Destination"/>
```

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateExpressionAnimation("sourceButton.Scale*2");
animation.SetExpressionReferenceParameter("sourceButton", sourceButton);
animation.Target = "Scale";
destinationButton.StartAnimation(animation);
```

## <a name="related-topics"></a><span data-ttu-id="7b06c-171">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7b06c-171">Related topics</span></span>

- [<span data-ttu-id="7b06c-172">アニメーションの再検討</span><span class="sxs-lookup"><span data-stu-id="7b06c-172">Storyboarded animations</span></span>](storyboarded-animations.md)
- [<span data-ttu-id="7b06c-173">XAML でビジュアル層の使用</span><span class="sxs-lookup"><span data-stu-id="7b06c-173">Using the Visual Layer with XAML</span></span>](../../composition/using-the-visual-layer-with-xaml.md)
- [<span data-ttu-id="7b06c-174">変換の概要</span><span class="sxs-lookup"><span data-stu-id="7b06c-174">Transforms overview</span></span>](../layout/transforms.md)
