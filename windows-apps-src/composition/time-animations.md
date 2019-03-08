---
title: 時間ベース アニメーション
description: KeyFrameAnimation クラスを使用すると、時間の経過と共に UI を変更できます。
ms.date: 12/12/2018
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 838a8c3a6dfe89de49fddefd28c53cea563408cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593167"
---
# <a name="time-based-animations"></a>時間ベース アニメーション

コンポーネントが使用中である場合や、ユーザー エクスペリエンス全体が変更される場合、こうした状況はエンド ユーザーに対して 2 つの方法で提示されることがあります。1 つは時間の経過と共に提示する方法、もう一つは即座に提示する方法です。 Windows プラットフォームで、前者は優先、後者を瞬時に変更する多くの場合、ユーザー エクスペリエンスと混同しての変更点を理解することはないために、エンドユーザーを驚くような。 このような場合、エンド ユーザーはエクスペリエンスを不快でありと不自然なものとして認識します。

ユーザー エクスペリエンスを即座に変更するのではなく、時間の経過と共に UI を変更してエンド ユーザーをガイドしたり、エクスペリエンスの変更をエンド ユーザーに通知したりすることができます。 Windows プラットフォームでは、これを時間ベース アニメーション (KeyFrameAnimation とも呼ばれます) を使用して行います。 KeyFrameAnimation を使用すると、時間の経過と共に UI を変更し、アニメーションの各側面 (アニメーションの開始方法や開始のタイミング、アニメーションがどのようにして終了状態になるかなど) を制御することができます。 たとえば、オブジェクトが新しい位置に 300 ミリ秒かけて移動するアニメーションは、即座にその位置に "テレポート" する方法よりも快適なエクスペリエンスとなります。 即座に変更するのではなく、アニメーションを使用すると、最終的にはより快適で魅力的なエクスペリエンスが実現されます。

## <a name="types-of-time-based-animations"></a>時間ベース アニメーションの種類

Windows で優れたユーザー エクスペリエンスを作成する際に使用できる時間ベース アニメーションには、2 つのカテゴリがあります。

**明示的なアニメーション** – その名前が示すように、アニメーションを明示的に開始して更新を実行します。
**暗黙的なアニメーション** – これらのアニメーションは、条件が満たされたときにシステムが自動的に開始します。

この記事では、KeyFrameAnimation を使って_明示的な_時間ベース アニメーションを作成し使用する方法について説明します。

明示的な時間ベース アニメーションおよび暗黙的な時間ベース アニメーションのどちらについても、アニメーション化できる CompositionObject のさまざまなプロパティに対応した多様な種類のアニメーションがあります。

- ColorKeyFrameAnimation
- QuaternionKeyFrameAnimation
- ScalarKeyFrameAnimation
- Vector2KeyFrameAnimation
- Vector3KeyFrameAnimation
- Vector4KeyFrameAnimation

## <a name="create-time-based-animations-with-keyframeanimations"></a>KeyFrameAnimation を使用して時間ベース アニメーションを作成する

KeyFrameAnimation を使用した明示的な時間ベース アニメーションの作成方法を説明する前に、概念についていくつか説明します。

- KeyFrame – KeyFrame とは、アニメーション化によってアニメーションが動作するための独立した "スナップショット" です。
  - キーと値のペアとして定義されます。 キーは 0 ~ 1 の値で進行状況を表します。つまり、この "スナップショット" が実行されるアニメーションの有効期間を表します。 他のパラメーターは、現時点におけるプロパティ値を表します。
- KeyFrameAnimation プロパティ – UI の要件を満たすために適用できるカスタマイズ オプションです。
  - DelayTime – StartAnimation が呼び出されてからアニメーションが開始されるまでの時間。
  - Duration: アニメーションの継続時間。
  - IterationBehavior: アニメーションの繰り返し動作の回数または無制限。
  - IterationCount – キー フレーム アニメーションが繰り返される有限の回数。
  - KeyFrame Count – 特定のキー フレーム アニメーションのキー フレームの数。
  - StopBehavior: StopAnimation が呼び出されたときのアニメーションのプロパティ値の動作を指定します。
  - Direction: アニメーションの再生方向を指定する。
- アニメーション グループ – 同時に複数のアニメーションを開始します。
  - 多くの場合、複数のプロパティを同時にアニメーション化するときに使用します。

詳しくは、「[CompositionAnimationGroup](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimationgroup)」をご覧ください。

以上の概念を踏まえて、KeyFrameAnimation を構築するための一般的な式を説明します。

1. CompositionObject とアニメーション化する必要がある各プロパティを特定します。
1. アニメーション化するプロパティの型と一致するコンポジターの KeyFrameAnimation タイプ テンプレートを作成します。
1. アニメーション テンプレートを使用して、KeyFrame の追加とアニメーションのプロパティの定義を開始します。
    - 1 つ以上の KeyFrame が必要です (100% または 1f KeyFrame)。
    - また、継続時間を定義することもお勧めします。
1. 1 回のアニメーション化するプロパティを対象とする、CompositionObject StartAnimation(...) を呼び出してこのアニメーションを実行する準備が整ったらします。 具体的には、次のとおりです。
    - `visual.StartAnimation("targetProperty", CompositionAnimation animation);`
    - `visual.StartAnimationGroup(AnimationGroup animationGroup);`
1. 実行中のアニメーションがあり、アニメーションまたはアニメーションのグループを停止する場合は、これらの Api を使用できます。
    - `visual.StopAnimation("targetProperty");`
    - `visual.StopAnimationGroup(AnimationGroup AnimationGroup);`

式の実際の動作例を見てみましょう。

## <a name="example"></a>例

1 秒 < 200,0,0 > を < 0,0,0 > からビジュアルのオフセットをアニメーション化するこの例では、します。 また、ビジュアルがこれらの位置の間を 10 回アニメーション化されるようにします。

![キーフレーム アニメーション](images/animation/animated-rectangle.gif)

最初に、CompositionObject とアニメーション化するプロパティを特定します。 この場合、赤色の正方形は、`redVisual` という Composition の Visual で表されています。 このオブジェクトからアニメーションを開始します。

次に、Offset プロパティをアニメーション化するため、Vector3KeyFrameAnimation を作成する必要があります (Offset の種類は Vector3)。 また、対応する KeyFrameAnimation の KeyFrame も定義します。

```csharp
    Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
    animation.InsertKeyFrame(1f, new Vector3(200f, 0f, 0f));
```

2 つの位置 (現在および < 200,0,0 >) の 10 倍の間をアニメーション化する動作と期間を記述する KeyFrameAnimation のプロパティを定義します。

```csharp
    animation.Duration = TimeSpan.FromSeconds(2);
    animation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
    // Run animation for 10 times
    animation.IterationCount = 10;
```

最後に、アニメーションを実行するために、CompositionObject のプロパティでアニメーションを開始する必要があります。

```csharp
redVisual.StartAnimation("Offset", animation);
```

完全なコードは次のようになります。

```csharp
private void AnimateSquare(Compositor compositor, SpriteVisual redVisual)
{ 
    Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
    animation.InsertKeyFrame(1f, new Vector3(200f, 0f, 0f));
    animation.Duration = TimeSpan.FromSeconds(2);
    animation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
    // Run animation for 10 times
    animation.IterationCount = 10;
    redVisual.StartAnimation("Offset", animation);
} 
```
