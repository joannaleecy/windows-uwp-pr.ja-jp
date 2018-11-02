---
author: jwmsft
title: 慣性修飾子を使用したスナップ位置の作成
description: InteractionTracker の InertiaModifier 機能を使用して、指定した位置にスナップされるモーション エクスペリエンスを作成する方法について説明します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 20c10b1cc621da834a8a7c411e75eb92b1944b5a
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5929983"
---
# <a name="create-snap-points-with-inertia-modifiers"></a>慣性修飾子を使用したスナップ位置の作成

この記事では、InteractionTracker の InertiaModifier 機能を使用して、指定した位置にスナップされるモーション エクスペリエンスを作成する方法について詳しく説明します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [入力駆動型アニメーション](input-driven-animations.md)
- [InteractionTracker を使用したカスタム操作エクスペリエンス](interaction-tracker-manipulations.md)
- [関係ベース アニメーション](relation-animations.md)

## <a name="what-are-snap-points-and-why-are-they-useful"></a>スナップ位置の説明、およびスナップ位置が便利である理由

カスタム操作エクスペリエンスを作成するとき、スクロール可能またはズーム可能なキャンバスに特殊な_位置ポイント_を作成すると役立つ場合があります。InteractionTracker は常にその位置で動作を停止するようになります。 多くの場合、このような位置ポイントは_スナップ位置_と呼ばれます。

次の例では、さまざまな画像間をスクロールしたときに、見づらい位置に UI が配置されてしまう状況を確認してください。

![スナップ位置を使用しないスクロール](images/animation/snap-points-none.gif)

スナップ位置を追加すると、画像間のスクロールを停止したとき、画像が指定した位置に "スナップ" されます。 スナップ位置を利用することで、画像をスクロールするときのエクスペリエンスがより見やすくなり、応答性も高くなります。

![1 つのスナップ位置を使用したスクロール](images/animation/snap-points-single.gif)

## <a name="interactiontracker-and-inertiamodifiers"></a>InteractionTracker と InertiaModifier

InteractionTracker を使用してカスタマイズした操作エクスペリエンスを作成するとき、InertiaModifier を利用することによって、スナップ位置のモーション エクスペリエンスを作成できます。 基本的に、InertiaModifier は、慣性状態に移行したときに InteractionTracker が移動先に到達する際の場所や方法を定義するための手法です InertiaModifier を適用すると、X 位置や Y 位置、または InteractionTracker の Scale プロパティを制御することができます。

InertiaModifier には、次の 3 種類があります。

- InteractionTrackerInertiaRestingValue – 操作やプログラムに従った速度での動作が終了した後の、最終的な静止位置を定義する方法。 定義済みのモーションでは、その位置まで InteractionTracker を移動します。
- InteractionTrackerInertiaMotion – 操作やプログラムに従った速度での動作が終了した後で InteractionTracker が実行する特定のモーションを定義する方法。 最終的な位置はこのモーションから派生します。
- InteractionTrackerInertiaNaturalMotion – 操作やプログラムに従った速度での動作が終了した後の、最終的な静止位置を定義する方法ですが、物理学ベースのアニメーションが使用されます (NaturalMotionAnimation)。

慣性状態に移行すると、InteractionTracker では、割り当てられている各 InertiaModifier を評価し、それらのいずれが適合するかを判別します。 つまり、1 つの InteractionTracker に対して複数の InertiaModifier を作成し割り当てることができます。ただし、各 InertiaModifier を定義するときは、次の手順を実行する必要があります。

1. 条件の定義 – この特定の InertiaModifier を実行するタイミングを指定する条件付きステートメントを定義する式を使用します。 多くの場合、この式では、InteractionTracker の NaturalRestingPosition (既定の慣性が指定された移動先) を参照する必要がります。
1. RestingValue/Motion/NaturalMotion の定義 – 条件が満たされたときに実行される、実際の静止値の式、モーションの式、NaturalMotionAnimation を定義します。

> [!NOTE]
> InteractionTracker が慣性状態に移行すると、InertiaModifier の条件部分のみが評価されます。 ただし InertiaMotion の場合のみ、モーションの式は、条件が true となる修飾子のフレームごとに評価されます。

## <a name="example"></a>例

次に、InertiaModifier を使用して、スナップ位置のエクスペリエンスをいくつか作成し、画像のスクロール キャンバスを再作成する方法を見てみましょう。 この例では、各操作を行うと 1 つの画像上を移動することが前提となっています。こうした動作は "Single Mandatory Snap Points" (シングル必須スナップ位置) と呼ばれることがあります。

まず、InteractionTracker、VisualInteractionSource、および InteractionTracker の位置を活用する式をセットアップします。

```csharp
private void SetupInput()
{
    _tracker = InteractionTracker.Create(_compositor);
    _tracker.MinPosition = new Vector3(0f);
    _tracker.MaxPosition = new Vector3(3000f);

    _source = VisualInteractionSource.Create(_root);
    _source.ManipulationRedirectionMode =
        VisualInteractionSourceRedirectionMode.CapableTouchpadOnly;
    _source.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;
    _tracker.InteractionSources.Add(_source);

    var scrollExp = _compositor.CreateExpressionAnimation("-tracker.Position.Y");
    scrollExp.SetReferenceParameter("tracker", _tracker);
    ElementCompositionPreview.GetElementVisual(scrollPanel).StartAnimation("Offset.Y", scrollExp);
}
```

Single Mandatory Snap Point の動作によってコンテンツが上または下へ移動するため、次に、2 つの異なる慣性修飾子が必要になります。1 つはスクロール可能なコンテンツを上へ移動し、もう 1 つは下へ移動します。

```csharp
// Snap-Point to move the content up
var snapUpModifier = InteractionTrackerInertiaRestingValue.Create(_compositor);
// Snap-Point to move the content down
var snapDownModifier = InteractionTrackerInertiaRestingValue.Create(_compositor);
```

スナップの方向が上であるか下であるかは、InteractionTracker がスナップの距離 (スナップ位置間の距離) の範囲内で自然に停止した相対的な位置に基づいて決定されます。 中間点を越えた場合は下方向のスナップ、それ以外の場合は上方向のスナップです  (この例では、スナップの距離は PropertySet に保存されます)。

```csharp
// Is NaturalRestingPosition less than the halfway point between Snap Points?
snapUpModifier.Condition = _compositor.CreateExpressionAnimation(
"this.Target.NaturalRestingPosition.y < (this.StartingValue – ” + “mod(this.StartingValue, prop.snapDistance) + prop.snapDistance / 2)");
snapUpModifier.Condition.SetReferenceParameter("prop", _propSet);
// Is NaturalRestingPosition greater than the halfway point between Snap Points?
snapDownModifier.Condition = _compositor.CreateExpressionAnimation(
"this.Target.NaturalRestingPosition.y >= (this.StartingValue – ” + “mod(this.StartingValue, prop.snapDistance) + prop.snapDistance / 2)");
snapDownModifier.Condition.SetReferenceParameter("prop", _propSet);
```

次の図は、実施されるロジックを説明したものです。

![慣性修飾子の図](images/animation/inertia-modifier-diagram.png)

ここで、各 InertiaModifier の静止値を定義する必要があります。InteractionTracker の位置を前のスナップ位置に移動するか、次のスナップ位置に移動するかを指定します。

```csharp
snapUpModifier.RestingValue = _compositor.CreateExpressionAnimation(
"this.StartingValue - mod(this.StartingValue, prop.snapDistance)");
snapUpModifier.RestingValue.SetReferenceParameter("prop", _propSet);
snapForwardModifier.RestingValue = _compositor.CreateExpressionAnimation(
"this.StartingValue + prop.snapDistance - mod(this.StartingValue, ” + “prop.snapDistance)");
snapForwardModifier.RestingValue.SetReferenceParameter("prop", _propSet);
```

最後に、InertiaModifier を InteractionTracker に追加します。 以上で、InteractionTracker が InertiaState に移行すると、InertiaModifier の条件が評価され、位置を変更する必要があるかどうかが判断されます。

```csharp
var modifiers = new InteractionTrackerInertiaRestingValue[] { 
snapUpModifier, snapDownModifier };
_tracker.ConfigurePositionYInertiaModifiers(modifiers);
```