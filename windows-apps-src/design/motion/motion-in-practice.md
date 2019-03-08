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
# <a name="bringing-it-together"></a>まとめる

タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。 それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。

アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。

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

**移行の例**

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

**オブジェクトの例**

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

## <a name="implicit-animations"></a>暗黙的なアニメーション

> 暗黙的なアニメーションに必要な Windows 10、バージョンは 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。


暗黙的なアニメーションは、自動的にパラメーターの変更中に新旧の値の間を補間によって Fluent の動きを実現する簡単な方法です。

暗黙的に次のプロパティを変更をアニメーション化できます。

- [UIElement](/uwp/api/windows.ui.xaml.uielement)
  - **不透明度**
  - **回転**
  - **スケール**
  - **翻訳**

- [境界線](/uwp/api/windows.ui.xaml.controls.border)、 [ContentPresenter](/uwp/api/windows.ui.xaml.controls.contentpresenter)、または[パネル](/uwp/api/windows.ui.xaml.controls.panel)
  - **バック グラウンド**

各プロパティをアニメーション化に暗黙的に変更を持つことができますが、対応する_遷移_プロパティ。 プロパティをアニメーション化するが移行型を割り当て、対応する_遷移_プロパティ。 このテーブルを示しています、_遷移_プロパティとそれぞれに使用する移行型。

| アニメーション化されたプロパティ | 遷移プロパティ | 暗黙的な移行の種類 |
| -- | -- | -- |
| [UIElement.Opacity](/uwp/api/windows.ui.xaml.uielement.opacity) | [OpacityTransition](/uwp/api/windows.ui.xaml.uielement.opacitytransition) | [ScalarTransition](/uwp/api/windows.ui.xaml.scalartransition) |
| [UIElement.Rotation](/uwp/api/windows.ui.xaml.uielement.rotation) | [RotationTransition](/uwp/api/windows.ui.xaml.uielement.rotationtransition) | [ScalarTransition](/uwp/api/windows.ui.xaml.scalartransition) |
| [UIElement.Scale](/uwp/api/windows.ui.xaml.uielement.scale) | [ScaleTransition](/uwp/api/windows.ui.xaml.uielement.scaletransition) | [Vector3Transition](/uwp/api/windows.ui.xaml.vector3transition) |
| [UIElement.Translation](/uwp/api/windows.ui.xaml.uielement.scale) | [TranslationTransition](/uwp/api/windows.ui.xaml.uielement.translationtransition) | [Vector3Transition](/uwp/api/windows.ui.xaml.vector3transition) |
| [Border.Background](/uwp/api/windows.ui.xaml.controls.border.background) | [BackgroundTransition](/uwp/api/windows.ui.xaml.controls.border.backgroundtransition) | [BrushTransition](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [ContentPresenter.Background](/uwp/api/windows.ui.xaml.controls.contentpresenter.background) | [BackgroundTransition](/uwp/api/windows.ui.xaml.controls.contentpresenter.backgroundtransition) | [BrushTransition](//uwp/api/windows.ui.xaml.uielement.brushtransition) |
| [Panel.Background](/uwp/api/windows.ui.xaml.controls.panel.background) | [BackgroundTransition](/uwp/api/windows.ui.xaml.controls.panel.backgroundtransition)  | [BrushTransition](//uwp/api/windows.ui.xaml.uielement.brushtransition) |

この例では、ボタン コントロールが有効にすると、フェードインし、フェードアウトを無効にすることに、Opacity プロパティと遷移を使用する方法を示します。

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

## <a name="related-articles"></a>関連記事

- [アニメーションの概要](index.md)
- [タイミングと、簡略化](timing-and-easing.md)
- [方向性と重力](directionality-and-gravity.md)
