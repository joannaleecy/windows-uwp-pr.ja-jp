---
author: jwmsft
Description: Learn how Fluent motion fundamentals come together in your app.
title: 実践的なモーション -  UWP アプリのアニメーション
label: Motion in practice
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 6001f955b3ab6a60446eb84296dc3bc52ad3a99e
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/20/2018
ms.locfileid: "5167746"
---
# <a name="bringing-it-together"></a><span data-ttu-id="76050-103">まとめる</span><span class="sxs-lookup"><span data-stu-id="76050-103">Bringing it together</span></span>

<span data-ttu-id="76050-104">タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。</span><span class="sxs-lookup"><span data-stu-id="76050-104">Timing, easing, directionality, and gravity work together to form the foundation of Fluent motion.</span></span> <span data-ttu-id="76050-105">それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。</span><span class="sxs-lookup"><span data-stu-id="76050-105">Each has to be considered in the context of the others, and applied appropriately in the context of your app.</span></span>

<span data-ttu-id="76050-106">アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="76050-106">Here are 3 ways to apply Fluent motion fundamentals in your app.</span></span>

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

**<span data-ttu-id="76050-107">切り替えの例</span><span class="sxs-lookup"><span data-stu-id="76050-107">Transition example</span></span>**

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

**<span data-ttu-id="76050-109">オブジェクトの例</span><span class="sxs-lookup"><span data-stu-id="76050-109">Object example</span></span>**

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

## <a name="implicit-animations"></a><span data-ttu-id="76050-111">暗黙的なアニメーション</span><span class="sxs-lookup"><span data-stu-id="76050-111">Implicit Animations</span></span>

> <span data-ttu-id="76050-112">**プレビュー**: 暗黙的なアニメーション[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="76050-112">**Preview**: Implicit animation requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/).</span></span>

<span data-ttu-id="76050-113">暗黙的なアニメーションは、パラメーターの変更時に古いと新しい値の間で自動的に補間によって Fluent モーションを実現するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="76050-113">Implicit animations are a simple way to achieve Fluent motion by automatically interpolating between the old and new values during a parameter change.</span></span>

<span data-ttu-id="76050-114">暗黙的に、次のプロパティへの変更をアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="76050-114">You can implicitly animate changes to the following properties:</span></span>

- [<span data-ttu-id="76050-115">UIElement</span><span class="sxs-lookup"><span data-stu-id="76050-115">UIElement</span></span>](/uwp/api/windows.ui.xaml.uielement)
  - **<span data-ttu-id="76050-116">Opacity</span><span class="sxs-lookup"><span data-stu-id="76050-116">Opacity</span></span>**
  - **<span data-ttu-id="76050-117">回転</span><span class="sxs-lookup"><span data-stu-id="76050-117">Rotation</span></span>**
  - **<span data-ttu-id="76050-118">Scale</span><span class="sxs-lookup"><span data-stu-id="76050-118">Scale</span></span>**
  - **<span data-ttu-id="76050-119">Translation</span><span class="sxs-lookup"><span data-stu-id="76050-119">Translation</span></span>**

- <span data-ttu-id="76050-120">[境界線](/uwp/api/windows.ui.xaml.controls.border)、 [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter)、または[パネル](/uwp/api/windows.ui.xaml.controls.panel)</span><span class="sxs-lookup"><span data-stu-id="76050-120">[Border](/uwp/api/windows.ui.xaml.controls.border), [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter), or [Panel](/uwp/api/windows.ui.xaml.controls.panel)</span></span>
  - **<span data-ttu-id="76050-121">Background</span><span class="sxs-lookup"><span data-stu-id="76050-121">Background</span></span>**

<span data-ttu-id="76050-122">暗黙的なアニメーションの変更を持つことができる各プロパティには、対応する_移行_プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="76050-122">Each property that can have changes implicitly animated has a corresponding _transition_ property.</span></span> <span data-ttu-id="76050-123">プロパティをアニメーション化するには、対応する_移行_プロパティに遷移タイプを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="76050-123">To animate the property, you assign a transition type to the corresponding _transition_ property.</span></span> <span data-ttu-id="76050-124">次の表では、_切り替え効果_のプロパティとごとに使用する切り替えの種類を示します。</span><span class="sxs-lookup"><span data-stu-id="76050-124">This table shows the _transition_ properties and the transition type to use for each one.</span></span>

| <span data-ttu-id="76050-125">アニメーション化されたプロパティ</span><span class="sxs-lookup"><span data-stu-id="76050-125">Animated property</span></span> | <span data-ttu-id="76050-126">切り替え効果のプロパティ</span><span class="sxs-lookup"><span data-stu-id="76050-126">Transition property</span></span> | <span data-ttu-id="76050-127">暗黙的な切り替えの種類</span><span class="sxs-lookup"><span data-stu-id="76050-127">Implicit transition type</span></span> |
| -- | -- | -- |
| [<span data-ttu-id="76050-128">UIElement.Opacity</span><span class="sxs-lookup"><span data-stu-id="76050-128">UIElement.Opacity</span></span>](/uwp/api/windows.ui.xaml.uielement.opacity) | [<span data-ttu-id="76050-129">OpacityTransition</span><span class="sxs-lookup"><span data-stu-id="76050-129">OpacityTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.opacitytransition) | [<span data-ttu-id="76050-130">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="76050-130">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="76050-131">UIElement.Rotation</span><span class="sxs-lookup"><span data-stu-id="76050-131">UIElement.Rotation</span></span>](/uwp/api/windows.ui.xaml.uielement.rotation) | [<span data-ttu-id="76050-132">RotationTransition</span><span class="sxs-lookup"><span data-stu-id="76050-132">RotationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.rotationtransition) | [<span data-ttu-id="76050-133">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="76050-133">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="76050-134">UIElement.Scale</span><span class="sxs-lookup"><span data-stu-id="76050-134">UIElement.Scale</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="76050-135">ScaleTransition</span><span class="sxs-lookup"><span data-stu-id="76050-135">ScaleTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.scaletransition) | [<span data-ttu-id="76050-136">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="76050-136">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.uielement.vector3transition) |
| [<span data-ttu-id="76050-137">UIElement.Translation</span><span class="sxs-lookup"><span data-stu-id="76050-137">UIElement.Translation</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="76050-138">TranslationTransition</span><span class="sxs-lookup"><span data-stu-id="76050-138">TranslationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.translationtransition) | [<span data-ttu-id="76050-139">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="76050-139">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.uielement.vector3transition) |
| [<span data-ttu-id="76050-140">Border.Background</span><span class="sxs-lookup"><span data-stu-id="76050-140">Border.Background</span></span>](/uwp/api/windows.ui.xaml.controls.border.background) | [<span data-ttu-id="76050-141">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="76050-141">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.border.backgroundtransition) | [<span data-ttu-id="76050-142">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="76050-142">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="76050-143">ContentPresenter.Background</span><span class="sxs-lookup"><span data-stu-id="76050-143">ContentPresenter.Background</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.background) | [<span data-ttu-id="76050-144">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="76050-144">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.backgroundtransition) | [<span data-ttu-id="76050-145">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="76050-145">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="76050-146">Panel.Background</span><span class="sxs-lookup"><span data-stu-id="76050-146">Panel.Background</span></span>](/uwp/api/windows.ui.xaml.controls.panel.background) | [<span data-ttu-id="76050-147">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="76050-147">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.panel.backgroundtransition)  | [<span data-ttu-id="76050-148">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="76050-148">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |

<span data-ttu-id="76050-149">この例では、ボタン コントロールを有効にするフェードイン/が無効になっているときに、Opacity プロパティと切り替え効果を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="76050-149">This example shows how to use the Opacity property and transition to make a button fade in when the control is enabled and fade out when it's disabled.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="76050-150">関連記事</span><span class="sxs-lookup"><span data-stu-id="76050-150">Related articles</span></span>

- [<span data-ttu-id="76050-151">モーションの概要</span><span class="sxs-lookup"><span data-stu-id="76050-151">Motion overview</span></span>](index.md)
- [<span data-ttu-id="76050-152">タイミングとイージング</span><span class="sxs-lookup"><span data-stu-id="76050-152">Timing and easing</span></span>](timing-and-easing.md)
- [<span data-ttu-id="76050-153">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="76050-153">Directionality and gravity</span></span>](directionality-and-gravity.md)