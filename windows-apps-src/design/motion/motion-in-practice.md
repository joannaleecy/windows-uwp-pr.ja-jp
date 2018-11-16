---
author: jwmsft
Description: Learn how Fluent motion fundamentals come together in your app.
title: 実践的なモーション -  UWP アプリのアニメーション
label: Motion in practice
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 36081c14cfb75a1cedb103ba17eff4a05f5e4e83
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6988321"
---
# <a name="bringing-it-together"></a><span data-ttu-id="a709b-103">まとめる</span><span class="sxs-lookup"><span data-stu-id="a709b-103">Bringing it together</span></span>

<span data-ttu-id="a709b-104">タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。</span><span class="sxs-lookup"><span data-stu-id="a709b-104">Timing, easing, directionality, and gravity work together to form the foundation of Fluent motion.</span></span> <span data-ttu-id="a709b-105">それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。</span><span class="sxs-lookup"><span data-stu-id="a709b-105">Each has to be considered in the context of the others, and applied appropriately in the context of your app.</span></span>

<span data-ttu-id="a709b-106">アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a709b-106">Here are 3 ways to apply Fluent motion fundamentals in your app.</span></span>

:::row:::
    :::column:::
        **Implicit animation**

        Automatic tween and timing between values in a parameter change to achieve very simple Fluent motion using the standardized values.
    :::column-end:::
    :::column:::
        **Built-in animation**

        System components, such as common controls and shared motion, are "Fluent by default". Fundamentals have been applied in a manner consistent with their implied usage.
    :::column-end:::
    :::column:::
        **Custom animation following guidance recommendations**

        There may be times when the system does not yet provide an exact motion solution for your scenario. In those cases, use the baseline fundamental recommendations as a starting point for your experiences.
    :::column-end:::
:::row-end:::

**<span data-ttu-id="a709b-107">切り替えの例</span><span class="sxs-lookup"><span data-stu-id="a709b-107">Transition example</span></span>**

![機能的なアニメーション](images/pageRefresh.gif)

:::row:::
    :::column:::
        <b>Direction Forward Out:</b><br>
        Fade out: 150m; Easing: Default Accelerate

        <b>Direction Forward In:</b><br>
        Slide up 150px: 300ms; Easing: Default Decelerate
    :::column-end:::
    :::column:::
         <b>Direction Backward Out:</b><br>
        Slide down 150px: 150ms; Easing: Default Accelerate

        <b>Direction Backward In:</b><br>
        Fade in: 300ms; Easing: Default Decelerate
    :::column-end:::
:::row-end:::

**<span data-ttu-id="a709b-109">オブジェクトの例</span><span class="sxs-lookup"><span data-stu-id="a709b-109">Object example</span></span>**

 ![300 ミリ秒のモーション](images/control.gif)

:::row:::
    :::column:::
        <b>Direction Expand:</b><br>
        Grow: 300ms; Easing: Standard
    :::column-end:::
    :::column:::
        <b>Direction Contract:</b><br>
        Grow: 150ms; Easing: Default Accelerate
    :::column-end:::
:::row-end:::

## <a name="implicit-animations"></a><span data-ttu-id="a709b-111">暗黙的なアニメーション</span><span class="sxs-lookup"><span data-stu-id="a709b-111">Implicit Animations</span></span>

> <span data-ttu-id="a709b-112">暗黙的なアニメーションに必要な Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="a709b-112">Implicit animations require Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span>


<span data-ttu-id="a709b-113">暗黙的なアニメーションは、パラメーターの変更時に新旧の値の間で自動的に補間によって Fluent モーションを実現するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="a709b-113">Implicit animations are a simple way to achieve Fluent motion by automatically interpolating between the old and new values during a parameter change.</span></span>

<span data-ttu-id="a709b-114">暗黙的に、次のプロパティへの変更をアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="a709b-114">You can implicitly animate changes to the following properties:</span></span>

- [<span data-ttu-id="a709b-115">UIElement</span><span class="sxs-lookup"><span data-stu-id="a709b-115">UIElement</span></span>](/uwp/api/windows.ui.xaml.uielement)
  - **<span data-ttu-id="a709b-116">Opacity</span><span class="sxs-lookup"><span data-stu-id="a709b-116">Opacity</span></span>**
  - **<span data-ttu-id="a709b-117">回転</span><span class="sxs-lookup"><span data-stu-id="a709b-117">Rotation</span></span>**
  - **<span data-ttu-id="a709b-118">Scale</span><span class="sxs-lookup"><span data-stu-id="a709b-118">Scale</span></span>**
  - **<span data-ttu-id="a709b-119">Translation</span><span class="sxs-lookup"><span data-stu-id="a709b-119">Translation</span></span>**

- <span data-ttu-id="a709b-120">[境界線](/uwp/api/windows.ui.xaml.controls.border)、 [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter)、または[パネル](/uwp/api/windows.ui.xaml.controls.panel)</span><span class="sxs-lookup"><span data-stu-id="a709b-120">[Border](/uwp/api/windows.ui.xaml.controls.border), [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter), or [Panel](/uwp/api/windows.ui.xaml.controls.panel)</span></span>
  - **<span data-ttu-id="a709b-121">Background</span><span class="sxs-lookup"><span data-stu-id="a709b-121">Background</span></span>**

<span data-ttu-id="a709b-122">暗黙的なアニメーションの変更を持つことができる各プロパティには、対応する_切り替え_プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="a709b-122">Each property that can have changes implicitly animated has a corresponding _transition_ property.</span></span> <span data-ttu-id="a709b-123">プロパティをアニメーション化するには、対応する_切り替え_プロパティに切り替えの種類を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="a709b-123">To animate the property, you assign a transition type to the corresponding _transition_ property.</span></span> <span data-ttu-id="a709b-124">次の表では、_切り替え効果_のプロパティとごとに使用する切り替えの種類を示します。</span><span class="sxs-lookup"><span data-stu-id="a709b-124">This table shows the _transition_ properties and the transition type to use for each one.</span></span>

| <span data-ttu-id="a709b-125">アニメーション化されたプロパティ</span><span class="sxs-lookup"><span data-stu-id="a709b-125">Animated property</span></span> | <span data-ttu-id="a709b-126">切り替え効果のプロパティ</span><span class="sxs-lookup"><span data-stu-id="a709b-126">Transition property</span></span> | <span data-ttu-id="a709b-127">暗黙的な切り替えの種類</span><span class="sxs-lookup"><span data-stu-id="a709b-127">Implicit transition type</span></span> |
| -- | -- | -- |
| [<span data-ttu-id="a709b-128">UIElement.Opacity</span><span class="sxs-lookup"><span data-stu-id="a709b-128">UIElement.Opacity</span></span>](/uwp/api/windows.ui.xaml.uielement.opacity) | [<span data-ttu-id="a709b-129">OpacityTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-129">OpacityTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.opacitytransition) | [<span data-ttu-id="a709b-130">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-130">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="a709b-131">UIElement.Rotation</span><span class="sxs-lookup"><span data-stu-id="a709b-131">UIElement.Rotation</span></span>](/uwp/api/windows.ui.xaml.uielement.rotation) | [<span data-ttu-id="a709b-132">RotationTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-132">RotationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.rotationtransition) | [<span data-ttu-id="a709b-133">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-133">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="a709b-134">UIElement.Scale</span><span class="sxs-lookup"><span data-stu-id="a709b-134">UIElement.Scale</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="a709b-135">ScaleTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-135">ScaleTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.scaletransition) | [<span data-ttu-id="a709b-136">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="a709b-136">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.uielement.vector3transition) |
| [<span data-ttu-id="a709b-137">UIElement.Translation</span><span class="sxs-lookup"><span data-stu-id="a709b-137">UIElement.Translation</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="a709b-138">TranslationTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-138">TranslationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.translationtransition) | [<span data-ttu-id="a709b-139">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="a709b-139">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.uielement.vector3transition) |
| [<span data-ttu-id="a709b-140">Border.Background</span><span class="sxs-lookup"><span data-stu-id="a709b-140">Border.Background</span></span>](/uwp/api/windows.ui.xaml.controls.border.background) | [<span data-ttu-id="a709b-141">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-141">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.border.backgroundtransition) | [<span data-ttu-id="a709b-142">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-142">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="a709b-143">ContentPresenter.Background</span><span class="sxs-lookup"><span data-stu-id="a709b-143">ContentPresenter.Background</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.background) | [<span data-ttu-id="a709b-144">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-144">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.backgroundtransition) | [<span data-ttu-id="a709b-145">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-145">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="a709b-146">Panel.Background</span><span class="sxs-lookup"><span data-stu-id="a709b-146">Panel.Background</span></span>](/uwp/api/windows.ui.xaml.controls.panel.background) | [<span data-ttu-id="a709b-147">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-147">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.panel.backgroundtransition)  | [<span data-ttu-id="a709b-148">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="a709b-148">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |

<span data-ttu-id="a709b-149">この例では、ボタン コントロールを有効にするフェードイン/が無効化するときに、Opacity プロパティと切り替え効果を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a709b-149">This example shows how to use the Opacity property and transition to make a button fade in when the control is enabled and fade out when it's disabled.</span></span>

```xaml
<Button x:Name="SubmitButton"
        Content="Submit"
        Opacity="{x:Bind OpaqueIfEnabled(SubmitButton.IsEnabled), Mode=OneWay}">
    <Button.OpacityTransition>
        <ScalarTransition />
    </Button.OpacityTransition>
</Button>
```

```csharp
public double OpaqueIfEnabled(bool IsEnabled)
{
    return IsEnabled ? 1.0 : 0.2;
}
```

## <a name="related-articles"></a><span data-ttu-id="a709b-150">関連記事</span><span class="sxs-lookup"><span data-stu-id="a709b-150">Related articles</span></span>

- [<span data-ttu-id="a709b-151">モーションの概要</span><span class="sxs-lookup"><span data-stu-id="a709b-151">Motion overview</span></span>](index.md)
- [<span data-ttu-id="a709b-152">タイミングとイージング</span><span class="sxs-lookup"><span data-stu-id="a709b-152">Timing and easing</span></span>](timing-and-easing.md)
- [<span data-ttu-id="a709b-153">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="a709b-153">Directionality and gravity</span></span>](directionality-and-gravity.md)