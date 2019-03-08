---
Description: アプリでの基礎は一体どの Fluent モーションをについて説明します。
title: 実践的なモーション -  UWP アプリのアニメーション
label: Motion in practice
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 6eafbfd965d2783c0f72e75c91a04e5ac1cb119f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599407"
---
# <a name="bringing-it-together"></a><span data-ttu-id="da181-104">まとめる</span><span class="sxs-lookup"><span data-stu-id="da181-104">Bringing it together</span></span>

<span data-ttu-id="da181-105">タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。</span><span class="sxs-lookup"><span data-stu-id="da181-105">Timing, easing, directionality, and gravity work together to form the foundation of Fluent motion.</span></span> <span data-ttu-id="da181-106">それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。</span><span class="sxs-lookup"><span data-stu-id="da181-106">Each has to be considered in the context of the others, and applied appropriately in the context of your app.</span></span>

<span data-ttu-id="da181-107">アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="da181-107">Here are 3 ways to apply Fluent motion fundamentals in your app.</span></span>

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

<span data-ttu-id="da181-108">**移行の例**</span><span class="sxs-lookup"><span data-stu-id="da181-108">**Transition example**</span></span>

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

<span data-ttu-id="da181-110">**オブジェクトの例**</span><span class="sxs-lookup"><span data-stu-id="da181-110">**Object example**</span></span>

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

## <a name="implicit-animations"></a><span data-ttu-id="da181-112">暗黙的なアニメーション</span><span class="sxs-lookup"><span data-stu-id="da181-112">Implicit Animations</span></span>

> <span data-ttu-id="da181-113">暗黙的なアニメーションに必要な Windows 10、バージョンは 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="da181-113">Implicit animations require Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span>


<span data-ttu-id="da181-114">暗黙的なアニメーションは、自動的にパラメーターの変更中に新旧の値の間を補間によって Fluent の動きを実現する簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="da181-114">Implicit animations are a simple way to achieve Fluent motion by automatically interpolating between the old and new values during a parameter change.</span></span>

<span data-ttu-id="da181-115">暗黙的に次のプロパティを変更をアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="da181-115">You can implicitly animate changes to the following properties:</span></span>

- [<span data-ttu-id="da181-116">UIElement</span><span class="sxs-lookup"><span data-stu-id="da181-116">UIElement</span></span>](/uwp/api/windows.ui.xaml.uielement)
  - <span data-ttu-id="da181-117">**不透明度**</span><span class="sxs-lookup"><span data-stu-id="da181-117">**Opacity**</span></span>
  - <span data-ttu-id="da181-118">**回転**</span><span class="sxs-lookup"><span data-stu-id="da181-118">**Rotation**</span></span>
  - <span data-ttu-id="da181-119">**スケール**</span><span class="sxs-lookup"><span data-stu-id="da181-119">**Scale**</span></span>
  - <span data-ttu-id="da181-120">**翻訳**</span><span class="sxs-lookup"><span data-stu-id="da181-120">**Translation**</span></span>

- <span data-ttu-id="da181-121">[境界線](/uwp/api/windows.ui.xaml.controls.border)、 [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter)、または[パネル](/uwp/api/windows.ui.xaml.controls.panel)</span><span class="sxs-lookup"><span data-stu-id="da181-121">[Border](/uwp/api/windows.ui.xaml.controls.border), [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter), or [Panel](/uwp/api/windows.ui.xaml.controls.panel)</span></span>
  - <span data-ttu-id="da181-122">**バック グラウンド**</span><span class="sxs-lookup"><span data-stu-id="da181-122">**Background**</span></span>

<span data-ttu-id="da181-123">各プロパティをアニメーション化に暗黙的に変更を持つことができますが、対応する_遷移_プロパティ。</span><span class="sxs-lookup"><span data-stu-id="da181-123">Each property that can have changes implicitly animated has a corresponding _transition_ property.</span></span> <span data-ttu-id="da181-124">プロパティをアニメーション化するが移行型を割り当て、対応する_遷移_プロパティ。</span><span class="sxs-lookup"><span data-stu-id="da181-124">To animate the property, you assign a transition type to the corresponding _transition_ property.</span></span> <span data-ttu-id="da181-125">このテーブルを示しています、_遷移_プロパティとそれぞれに使用する移行型。</span><span class="sxs-lookup"><span data-stu-id="da181-125">This table shows the _transition_ properties and the transition type to use for each one.</span></span>

| <span data-ttu-id="da181-126">アニメーション化されたプロパティ</span><span class="sxs-lookup"><span data-stu-id="da181-126">Animated property</span></span> | <span data-ttu-id="da181-127">遷移プロパティ</span><span class="sxs-lookup"><span data-stu-id="da181-127">Transition property</span></span> | <span data-ttu-id="da181-128">暗黙的な移行の種類</span><span class="sxs-lookup"><span data-stu-id="da181-128">Implicit transition type</span></span> |
| -- | -- | -- |
| [<span data-ttu-id="da181-129">UIElement.Opacity</span><span class="sxs-lookup"><span data-stu-id="da181-129">UIElement.Opacity</span></span>](/uwp/api/windows.ui.xaml.uielement.opacity) | [<span data-ttu-id="da181-130">OpacityTransition</span><span class="sxs-lookup"><span data-stu-id="da181-130">OpacityTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.opacitytransition) | [<span data-ttu-id="da181-131">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="da181-131">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="da181-132">UIElement.Rotation</span><span class="sxs-lookup"><span data-stu-id="da181-132">UIElement.Rotation</span></span>](/uwp/api/windows.ui.xaml.uielement.rotation) | [<span data-ttu-id="da181-133">RotationTransition</span><span class="sxs-lookup"><span data-stu-id="da181-133">RotationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.rotationtransition) | [<span data-ttu-id="da181-134">ScalarTransition</span><span class="sxs-lookup"><span data-stu-id="da181-134">ScalarTransition</span></span>](/uwp/api/windows.ui.xaml.scalartransition) |
| [<span data-ttu-id="da181-135">UIElement.Scale</span><span class="sxs-lookup"><span data-stu-id="da181-135">UIElement.Scale</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="da181-136">ScaleTransition</span><span class="sxs-lookup"><span data-stu-id="da181-136">ScaleTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.scaletransition) | [<span data-ttu-id="da181-137">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="da181-137">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.vector3transition) |
| [<span data-ttu-id="da181-138">UIElement.Translation</span><span class="sxs-lookup"><span data-stu-id="da181-138">UIElement.Translation</span></span>](/uwp/api/windows.ui.xaml.uielement.scale) | [<span data-ttu-id="da181-139">TranslationTransition</span><span class="sxs-lookup"><span data-stu-id="da181-139">TranslationTransition</span></span>](/uwp/api/windows.ui.xaml.uielement.translationtransition) | [<span data-ttu-id="da181-140">Vector3Transition</span><span class="sxs-lookup"><span data-stu-id="da181-140">Vector3Transition</span></span>](/uwp/api/windows.ui.xaml.vector3transition) |
| [<span data-ttu-id="da181-141">Border.Background</span><span class="sxs-lookup"><span data-stu-id="da181-141">Border.Background</span></span>](/uwp/api/windows.ui.xaml.controls.border.background) | [<span data-ttu-id="da181-142">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="da181-142">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.border.backgroundtransition) | [<span data-ttu-id="da181-143">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="da181-143">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="da181-144">ContentPresenter.Background</span><span class="sxs-lookup"><span data-stu-id="da181-144">ContentPresenter.Background</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.background) | [<span data-ttu-id="da181-145">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="da181-145">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.contentpresenter.backgroundtransition) | [<span data-ttu-id="da181-146">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="da181-146">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [<span data-ttu-id="da181-147">Panel.Background</span><span class="sxs-lookup"><span data-stu-id="da181-147">Panel.Background</span></span>](/uwp/api/windows.ui.xaml.controls.panel.background) | [<span data-ttu-id="da181-148">BackgroundTransition</span><span class="sxs-lookup"><span data-stu-id="da181-148">BackgroundTransition</span></span>](/uwp/api/windows.ui.xaml.controls.panel.backgroundtransition)  | [<span data-ttu-id="da181-149">BrushTransition</span><span class="sxs-lookup"><span data-stu-id="da181-149">BrushTransition</span></span>](//uwp/api/windows.ui.xaml.uielement.brushtransition) |

<span data-ttu-id="da181-150">この例では、ボタン コントロールが有効にすると、フェードインし、フェードアウトを無効にすることに、Opacity プロパティと遷移を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="da181-150">This example shows how to use the Opacity property and transition to make a button fade in when the control is enabled and fade out when it's disabled.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="da181-151">関連記事</span><span class="sxs-lookup"><span data-stu-id="da181-151">Related articles</span></span>

- [<span data-ttu-id="da181-152">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="da181-152">Motion overview</span></span>](index.md)
- [<span data-ttu-id="da181-153">タイミングと、簡略化</span><span class="sxs-lookup"><span data-stu-id="da181-153">Timing and easing</span></span>](timing-and-easing.md)
- [<span data-ttu-id="da181-154">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="da181-154">Directionality and gravity</span></span>](directionality-and-gravity.md)
