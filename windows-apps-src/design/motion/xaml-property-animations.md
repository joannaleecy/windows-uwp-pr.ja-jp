---
author: Jwmsft
title: XAML プロパティのアニメーション
description: コンポジション アニメーションでの XAML 要素をアニメーション化します。
ms.author: jimwalk
ms.date: 09/13/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: jeffarn
ms.localizationpriority: medium
ms.openlocfilehash: 9372ba818805446948a444632e809ec06691c5e5
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5997312"
---
# <a name="animating-xaml-elements-with-composition-animations"></a><span data-ttu-id="d89bd-104">コンポジション アニメーションでの XAML 要素をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="d89bd-104">Animating XAML elements with composition animations</span></span>

<span data-ttu-id="d89bd-105">この記事では、コンポジション アニメーションのパフォーマンスと XAML プロパティを設定するの簡単で XAML UIElement をアニメーション化できるようにする新しいプロパティが導入されています。</span><span class="sxs-lookup"><span data-stu-id="d89bd-105">This article introduces new properties that let you animate a XAML UIElement with the performance of composition animations and the ease of setting XAML properties.</span></span>

<span data-ttu-id="d89bd-106">Windows 10 version 1809、前に、UWP アプリでのアニメーションを構築する 2 つの選択肢がありました。</span><span class="sxs-lookup"><span data-stu-id="d89bd-106">Prior to Windows 10, version 1809, you had 2 choices to build animations in your UWP apps:</span></span>

- <span data-ttu-id="d89bd-107">[Storyboarded アニメーション](storyboarded-animations.md)と同様に、XAML 構造を使用して、または _\* themetransition という単語_と _\* themeanimation という単語_ [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation)名前空間のクラスです。</span><span class="sxs-lookup"><span data-stu-id="d89bd-107">use XAML constructs like [Storyboarded animations](storyboarded-animations.md), or the _\*ThemeTransition_ and _\*ThemeAnimation_ classes in the [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation) namespace.</span></span>
- <span data-ttu-id="d89bd-108">[XAML とビジュアル レイヤーの使用](../../composition/using-the-visual-layer-with-xaml.md)で説明したように、コンポジションのアニメーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-108">use composition animations as described in [Using the Visual Layer with XAML](../../composition/using-the-visual-layer-with-xaml.md).</span></span>

<span data-ttu-id="d89bd-109">ビジュアル レイヤーの使用、XAML を使って構築します。 より優れたパフォーマンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-109">Using the visual layer provides better performance than using the XAML constructs.</span></span> <span data-ttu-id="d89bd-110">[ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview)を使用して、要素の基になるコンポジション、[ビジュアル](/uwp/api/windows.ui.composition.visual)オブジェクトを取得して、コンポジションのアニメーションでは、ビジュアルをアニメーション化し、使用するより複雑です。</span><span class="sxs-lookup"><span data-stu-id="d89bd-110">But using [ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview) to get the element's underlying composition [Visual](/uwp/api/windows.ui.composition.visual) object, and then animating the Visual with composition animations, is more complex to use.</span></span>

<span data-ttu-id="d89bd-111">Windows 10、バージョン 1809、以降では、基になるコンポジション Visual を取得する必要はありませんコンポジション アニメーションを使用して直接 UIElement のプロパティをアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="d89bd-111">Starting in Windows 10, version 1809, you can animate properties on a UIElement directly using composition animations without the requirement to get the underlying composition Visual.</span></span>

> [!NOTE]
> <span data-ttu-id="d89bd-112">UIElement でこれらのプロパティを使用するには、UWP プロジェクトのターゲット バージョン 1809 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d89bd-112">To use these properties on UIElement, your UWP project target version must be 1809 or later.</span></span> <span data-ttu-id="d89bd-113">プロジェクトのバージョンの構成について詳しくは、[バージョン アダプティブ アプリ](../../debug-test-perf/version-adaptive-apps.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d89bd-113">For more info about configuring your project version, see [Version adaptive apps](../../debug-test-perf/version-adaptive-apps.md).</span></span>

## <a name="new-rendering-properties-replace-old-rendering-properties"></a><span data-ttu-id="d89bd-114">レンダリングの新しいプロパティが古いレンダリング プロパティを置き換えます</span><span class="sxs-lookup"><span data-stu-id="d89bd-114">New rendering properties replace old rendering properties</span></span>

<span data-ttu-id="d89bd-115">次の表では、 [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation)とアニメーション化もできる、UIElement のレンダリングを変更するに使用できるプロパティを示します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-115">This table shows the properties you can use to modify the rendering of a UIElement, that can also be animated with a [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation).</span></span>

| <span data-ttu-id="d89bd-116">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d89bd-116">Property</span></span> | <span data-ttu-id="d89bd-117">型</span><span class="sxs-lookup"><span data-stu-id="d89bd-117">Type</span></span> | <span data-ttu-id="d89bd-118">説明</span><span class="sxs-lookup"><span data-stu-id="d89bd-118">Description</span></span> |
| -- | -- | -- |
| [<span data-ttu-id="d89bd-119">Opacity</span><span class="sxs-lookup"><span data-stu-id="d89bd-119">Opacity</span></span>](/uwp/api/windows.ui.xaml.uielement.opacity) | <span data-ttu-id="d89bd-120">Double</span><span class="sxs-lookup"><span data-stu-id="d89bd-120">Double</span></span> | <span data-ttu-id="d89bd-121">オブジェクトの不透明度</span><span class="sxs-lookup"><span data-stu-id="d89bd-121">The degree of the object's opacity</span></span> |
| [<span data-ttu-id="d89bd-122">Translation</span><span class="sxs-lookup"><span data-stu-id="d89bd-122">Translation</span></span>](/uwp/api/windows.ui.xaml.uielement.translation) | <span data-ttu-id="d89bd-123">Vector3</span><span class="sxs-lookup"><span data-stu-id="d89bd-123">Vector3</span></span> | <span data-ttu-id="d89bd-124">要素の Z/X と Y 位置に変えていくこと</span><span class="sxs-lookup"><span data-stu-id="d89bd-124">Shift the X/Y/Z position of the element</span></span> |
| [<span data-ttu-id="d89bd-125">Transformmatrix などがあります。</span><span class="sxs-lookup"><span data-stu-id="d89bd-125">TransformMatrix</span></span>](/uwp/api/windows.ui.xaml.uielement.transformmatrix) | <span data-ttu-id="d89bd-126">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="d89bd-126">Matrix4x4</span></span> | <span data-ttu-id="d89bd-127">要素に適用するための変換行列</span><span class="sxs-lookup"><span data-stu-id="d89bd-127">The transform matrix to apply to the element</span></span> |
| [<span data-ttu-id="d89bd-128">Scale</span><span class="sxs-lookup"><span data-stu-id="d89bd-128">Scale</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | <span data-ttu-id="d89bd-129">Vector3</span><span class="sxs-lookup"><span data-stu-id="d89bd-129">Vector3</span></span> | <span data-ttu-id="d89bd-130">中心点を中心と、要素をスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="d89bd-130">Scale the element, centered on the CenterPoint</span></span> |
| [<span data-ttu-id="d89bd-131">回転</span><span class="sxs-lookup"><span data-stu-id="d89bd-131">Rotation</span></span>](/uwp/api/windows.ui.xaml.uielement.rotation) | <span data-ttu-id="d89bd-132">Float</span><span class="sxs-lookup"><span data-stu-id="d89bd-132">Float</span></span> | <span data-ttu-id="d89bd-133">要素、RotationAxis と中心点の周りを回転します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-133">Rotate the element around the RotationAxis and CenterPoint</span></span> |
| [<span data-ttu-id="d89bd-134">RotationAxis</span><span class="sxs-lookup"><span data-stu-id="d89bd-134">RotationAxis</span></span>](/uwp/api/windows.ui.xaml.uielement.rotationaxis) | <span data-ttu-id="d89bd-135">Vector3</span><span class="sxs-lookup"><span data-stu-id="d89bd-135">Vector3</span></span> | <span data-ttu-id="d89bd-136">回転の軸</span><span class="sxs-lookup"><span data-stu-id="d89bd-136">The axis of rotation</span></span> |
| [<span data-ttu-id="d89bd-137">CenterPoint</span><span class="sxs-lookup"><span data-stu-id="d89bd-137">CenterPoint</span></span>](/uwp/api/windows.ui.xaml.uielement.centerpoint) | <span data-ttu-id="d89bd-138">Vector3</span><span class="sxs-lookup"><span data-stu-id="d89bd-138">Vector3</span></span> | <span data-ttu-id="d89bd-139">スケール、回転の中心点</span><span class="sxs-lookup"><span data-stu-id="d89bd-139">The center point of scale and rotation</span></span> |

<span data-ttu-id="d89bd-140">Transformmatrix などがありますプロパティの値が次の順序でスケーリング、回転、および平行移動のプロパティと組み合わせることにより: transformmatrix などがあります、スケール、回転、平行移動します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-140">The TransformMatrix property value is combined with the Scale, Rotation, and Translation properties in the following order:  TransformMatrix, Scale, Rotation, Translation.</span></span>

<span data-ttu-id="d89bd-141">これらのプロパティは、要素のレイアウトに影響しないと、ためこれらのプロパティを変更すると、新しい[測定](/uwp/api/windows.ui.xaml.uielement.measure)が発生しない/[配置](/uwp/api/windows.ui.xaml.uielement.arrange)パス。</span><span class="sxs-lookup"><span data-stu-id="d89bd-141">These properties don't affect the element's layout, so modifying these properties does not cause a new [Measure](/uwp/api/windows.ui.xaml.uielement.measure)/[Arrange](/uwp/api/windows.ui.xaml.uielement.arrange) pass.</span></span>

<span data-ttu-id="d89bd-142">これらのプロパティとしてという名前のようなプロパティは、コンポジション (Translation Visual に表示されていない) を除く[Visual](/uwp/api/windows.ui.composition.visual)クラスで、目的と動作が同じであります。</span><span class="sxs-lookup"><span data-stu-id="d89bd-142">These properties have the same purpose and behavior as the like-named properties on the composition [Visual](/uwp/api/windows.ui.composition.visual) class (except for Translation, which isn't on Visual).</span></span>

### <a name="example-setting-the-scale-property"></a><span data-ttu-id="d89bd-143">例: Scale プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-143">Example: Setting the Scale property</span></span>

<span data-ttu-id="d89bd-144">この例では、ボタンに Scale プロパティを設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-144">This example shows how to set the Scale property on a Button.</span></span>

```xaml
<Button Scale="2,2,1" Content="I am a large button" />
```

```csharp
var button = new Button();
button.Content = "I am a large button";
button.Scale = new Vector3(2.0f,2.0f,1.0f);
```

### <a name="mutual-exclusivity-between-new-and-old-properties"></a><span data-ttu-id="d89bd-145">新規および既存のプロパティの間の相互の排他状態</span><span class="sxs-lookup"><span data-stu-id="d89bd-145">Mutual exclusivity between new and old properties</span></span>

> [!NOTE]
> <span data-ttu-id="d89bd-146">**不透明度**のプロパティは、このセクションで説明されている相互排他状態を強制しません。</span><span class="sxs-lookup"><span data-stu-id="d89bd-146">The **Opacity** property does not enforce the mutual exclusivity described in this section.</span></span> <span data-ttu-id="d89bd-147">XAML またはコンポジションのアニメーションを使用するかどうかは、同じの Opacity プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-147">You use the same Opacity property whether you use XAML or composition animations.</span></span>

<span data-ttu-id="d89bd-148">Compositionanimation と関連付けてでアニメーション化できるプロパティには、いくつかの既存の UIElement プロパティ用の代替機能があります。</span><span class="sxs-lookup"><span data-stu-id="d89bd-148">The properties that can be animated with a CompositionAnimation are replacements for several existing UIElement properties:</span></span>

- [<span data-ttu-id="d89bd-149">RenderTransform</span><span class="sxs-lookup"><span data-stu-id="d89bd-149">RenderTransform</span></span>](/uwp/api/windows.ui.xaml.uielement.rendertransform)
- [<span data-ttu-id="d89bd-150">RenderTransformOrigin</span><span class="sxs-lookup"><span data-stu-id="d89bd-150">RenderTransformOrigin</span></span>](/uwp/api/windows.ui.xaml.uielement.rendertransformorigin)
- [<span data-ttu-id="d89bd-151">Projection</span><span class="sxs-lookup"><span data-stu-id="d89bd-151">Projection</span></span>](/uwp/api/windows.ui.xaml.uielement.projection)
- [<span data-ttu-id="d89bd-152">Transform3D</span><span class="sxs-lookup"><span data-stu-id="d89bd-152">Transform3D</span></span>](/uwp/api/windows.ui.xaml.uielement.transform3d)

<span data-ttu-id="d89bd-153">設定 (アニメーション化) のすべての新しいプロパティか、または以前のプロパティを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d89bd-153">When you set (or animate) any of the new properties, you cannot use the old properties.</span></span> <span data-ttu-id="d89bd-154">逆に、ユーザー設定 (またはアニメーション化) のすべての古いプロパティ場合、は、新しいプロパティを使用できません。</span><span class="sxs-lookup"><span data-stu-id="d89bd-154">Conversely, if you set (or animate) any of the old properties, you cannot use the new properties.</span></span>

<span data-ttu-id="d89bd-155">使用することもできません新しいプロパティを取得し、ビジュアルを自分でこれらのメソッドを使用して管理 ElementCompositionPreview を使用する場合。</span><span class="sxs-lookup"><span data-stu-id="d89bd-155">You also cannot use the new properties if you use ElementCompositionPreview to get and manage the Visual yourself using these methods:</span></span>

- [<span data-ttu-id="d89bd-156">ElementCompositionPreview.GetElementVisual</span><span class="sxs-lookup"><span data-stu-id="d89bd-156">ElementCompositionPreview.GetElementVisual</span></span>](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual)
- [<span data-ttu-id="d89bd-157">ElementCompositionPreview.SetIsTranslationEnabled</span><span class="sxs-lookup"><span data-stu-id="d89bd-157">ElementCompositionPreview.SetIsTranslationEnabled</span></span>](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.setistranslationenabled)

> [!IMPORTANT]
> <span data-ttu-id="d89bd-158">2 セットのプロパティの使用を混在させるしようとすると、API 呼び出しは失敗し、エラー メッセージが表示が発生します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-158">Attempting to mix the use of the two sets of properties will cause the API call to fail and produce an error message.</span></span>

<span data-ttu-id="d89bd-159">わかりやすくするためにはお勧めしませんが、それらをオフにしてプロパティの 1 つのセットから切り替えを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d89bd-159">It’s possible to switch from one set of properties by clearing them, though for simplicity it's not recommended.</span></span> <span data-ttu-id="d89bd-160">DependencyProperty によって、プロパティがサポートされる場合 (たとえば、UIElement.Projection は、対応 UIElement.ProjectionProperty)、「未使用」の状態を復元する ClearValue を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-160">If the property is backed by a DependencyProperty (for example, UIElement.Projection is backed by UIElement.ProjectionProperty), then call ClearValue to restore it to its "unused" state.</span></span> <span data-ttu-id="d89bd-161">(たとえば、Scale プロパティ)、それ以外の場合は、既定値にプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-161">Otherwise (for example, the Scale property), set the property to its default value.</span></span>

## <a name="animating-uielement-properties-with-compositionanimation"></a><span data-ttu-id="d89bd-162">CompositionAnimation UIElement プロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="d89bd-162">Animating UIElement properties with CompositionAnimation</span></span>

<span data-ttu-id="d89bd-163">Compositionanimation と関連付けての表に示されてレンダリング プロパティをアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="d89bd-163">You can animate the rendering properties listed in the table with a CompositionAnimation.</span></span> <span data-ttu-id="d89bd-164">[Expressionanimation を使用](/uwp/api/windows.ui.composition.expressionanimation)して、これらのプロパティを参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="d89bd-164">These properties can also be referenced by an [ExpressionAnimation](/uwp/api/windows.ui.composition.expressionanimation).</span></span>

<span data-ttu-id="d89bd-165">UIElement のプロパティをアニメーション化する UIElement で[StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation)と[StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation)メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d89bd-165">Use the [StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation) and [StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation) methods on UIElement to animate the UIElement properties.</span></span>

### <a name="example-animating-the-scale-property-with-a-vector3keyframeanimation"></a><span data-ttu-id="d89bd-166">例: Vector3KeyFrameAnimation を Scale プロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="d89bd-166">Example: Animating the Scale property with a Vector3KeyFrameAnimation</span></span>

<span data-ttu-id="d89bd-167">この例では、ボタンのスケールをアニメーション化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d89bd-167">This example shows how to animate the scale of a Button.</span></span>

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateVector3KeyFrameAnimation();

animation.InsertKeyFrame(1.0f, new Vector3(2.0f,2.0f,1.0f));
animation.Duration = TimeSpan.FromSeconds(1);
animation.Target = "Scale";

button.StartAnimation(animation);
```

### <a name="example-animating-the-scale-property-with-an-expressionanimation"></a><span data-ttu-id="d89bd-168">例: expressionanimation を使用して Scale プロパティをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="d89bd-168">Example: Animating the Scale property with an ExpressionAnimation</span></span>

<span data-ttu-id="d89bd-169">ページには、2 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="d89bd-169">A page has two buttons.</span></span> <span data-ttu-id="d89bd-170">2 番目のボタンを 2 回 (スケール) 経由で同じ大きさにアニメーション化の最初のボタンとしてします。</span><span class="sxs-lookup"><span data-stu-id="d89bd-170">The second button animates to be twice as large (via scale) as the first button.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="d89bd-171">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d89bd-171">Related topics</span></span>

- [<span data-ttu-id="d89bd-172">ストーリーボードに設定されたアニメーション</span><span class="sxs-lookup"><span data-stu-id="d89bd-172">Storyboarded animations</span></span>](storyboarded-animations.md)
- [<span data-ttu-id="d89bd-173">XAML でのビジュアル レイヤーの使用</span><span class="sxs-lookup"><span data-stu-id="d89bd-173">Using the Visual Layer with XAML</span></span>](../../composition/using-the-visual-layer-with-xaml.md)
- [<span data-ttu-id="d89bd-174">変換の概要</span><span class="sxs-lookup"><span data-stu-id="d89bd-174">Transforms overview</span></span>](../layout/transforms.md)