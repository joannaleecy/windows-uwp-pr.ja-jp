---
author: jwmsft
title: ばねアニメーション
description: 自然な動作のばねアニメーションを使用する方法について説明します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10、UWP、アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 2b28653fc7746075c57f862b0c885beac6d4934f
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7563316"
---
# <a name="spring-animations"></a>ばねアニメーション

この記事では、ばねの NaturalMotionAnimations を使用する方法について説明します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [自然な動作のアニメーション](natural-animations.md)

## <a name="why-springs"></a>ばねの動きを使用する理由

ばねの動きは、生活の中で人々が経験したことがある一般的なモーション エクスペリエンスです。おもちゃのスリンキーから、ばねでつながれたブロックを使った物理の授業までさまざまなものがあります。 ばねによる振動のモーションは、その動きを見ている人から楽しい感情や愉快な感情の反応を引き起こすことがあります。 このため、ばねのモーションは、躍動感のあるモーション エクスペリエンスの作成を考えているユーザー向けのアプリケーション UI に利用することが適しています。このようなモーション エクスペリエンスは、従来の 3 次ベジエよりもエンド ユーザーに "強い印象" を与えます。 このような場合、ばねのモーションは、躍動感のあるモーション エクスペリエンスを作成するだけでなく、アニメーション化された新しいコンテンツや現在のコンテンツに興味を惹き付ける際にも役立ちます。 アプリケーションのブランド化やモーションの言語によっては、振動をより目立たせ、はっきりと表現する場合がありますが、あまり目立たない表現が必要になることもあります。

![ばねアニメーションを使用したモーション](images/animation/offset-spring.gif)
![3 次ベジエを使用したモーション](images/animation/offset-cubic-bezier.gif)

## <a name="using-springs-in-your-ui"></a>UI でばねの動きを使用する

既に説明したように、ばねは便利なモーションです。アプリに統合することで、使いやすく楽しい UI エクスペリエンスを導入することができます。 UI でばねを使用する一般的な方法を次に示します。

| ばねの使用に関する説明 | 表示例 |
| ------------------------ | -------------- |
| モーション エクスペリエンスに "飛び出す" ような効果と躍動感を与える  (スケールのアニメーション化) | ![ばねアニメーションを使用した拡大/縮小モーション](images/animation/scale-spring.gif) |
| モーション エクスペリエンスで動きをさりげなく感じさせる (オフセットのアニメーション化) | ![ばねアニメーションをオフセット モーション](images/animation/offset-spring.gif) |

これらどちらの場合でも、ばねのモーションは、新しい値まで "ばねを伸ばし" その値を中心に振動すること、または現在の値を中心にして初期速度に基づいて振動することによってトリガーできます。

![ばねアニメーションによる振動](images/animation/spring-animation-diagram.png)

## <a name="defining-your-spring-motion"></a>ばねのモーションを定義する

ばねのエクスペリエンスを作成するには、NaturalMotionAnimation API を使用します。 具体的には、コンポジターから Create* メソッドを使用して、SpringNaturalMotionAnimation を作成します。 その後で、モーションの以下のプロパティを定義することができます。

- DampingRatio – アニメーションで使用されるばねのモーションに関する減衰のレベルを表します。

| 減衰比の値 | 説明 |
| ------------------- | ----------- |
| DampingRatio = 0 | 非減衰 – ばねが長時間にわたって振動します。 |
| 0 < DampingRatio < 1 | 不足減衰 – ばねの振動が小さいものから大きいものへと変化します。 |
| DampingRatio = 1 | 臨界減衰 – ばねは振動を実行しません。 |
| DampingRation > 1 | 過減衰 – ばねは急激に減速して、直ちにその移動先に到達します。振動はありません。 |

- Period – ばねが単一の振動を実行する際にかかる時間です。
- Final/Starting の値 – ばねのモーションの開始位置と終了位置を定義します (定義しない場合、開始または終了 (あるいはその両方) の値は現在の値になります)。
- 初期速度 – プログラムに従ったモーションの初期速度です。

KeyFrameAnimation と同じ、モーションの一連のプロパティを定義することもできます。

- DelayTime/DelayBehavior
- StopBehavior

オフセットのアニメーション化、および拡大/縮小やサイズのアニメーション化を行う場合、Windows のデザイン チームでは、ばねの種類に応じて、DampingRatio や Period には一般的に以下の値を使用するよう推奨しています。

| プロパティ | 通常のばね | 減衰するばね | 減衰が小さいばね |
| -------- | ------------- | --------------- | -------------------- |
| Offset | DampingRatio = 0.8 <br/> Period = 50 ms | DampingRatio = 0.85 <br/> Period = 50 ms | DampingRatio = 0.65 <br/> Period = 60 ms |
| Scale/Size | DampingRatio = 0.7 <br/> Period = 50 ms | DampingRatio = 0.8 <br/> Period = 50 ms | DampingRatio = 0.6 <br/> Period = 60 ms |

プロパティを定義すると、ばねの NaturalMotionAnimation を CompositionObject の StartAnimation メソッド、または InteractionTracker の InertiaModifier が持つ Motion プロパティに渡すことができます。

## <a name="example"></a>例

この例では、ナビゲーションとキャンバスの UI エクスペリエンスを作成します。このエクスペリエンスでは、ユーザーが展開ボタンをクリックすると、ナビゲーション ウィンドウが、ばねのような振動のモーションを使ってアニメーション化され表示されます。

![クリックしたときのばねアニメーション](images/animation/spring-animation-on-click.gif)

まず、ナビゲーション ウィンドウが表示されるタイミングに対応したクリック イベント内に、ばねアニメーションを定義します。 次に、FinalValue を定義する式を利用するための InitialValueExpression 機能を使って、アニメーションのプロパティを定義します。 また、ウィンドウが開かれているかどうかを追跡し、準備ができたら、アニメーションを開始します。

```csharp
private void Button_Clicked(object sender, RoutedEventArgs e)
{
 _springAnimation = _compositor.CreateSpringScalarAnimation();
 _springAnimation.DampingRatio = 0.75f;
 _springAnimation.Period = TimeSpan.FromSeconds(0.5);

 if (!_expanded)
 {
 _expanded = true;
 _propSet.InsertBoolean("expanded", true);
 _springAnimation.InitialValueExpression[“FinalValue”] = “this.StartingValue + 250”;
 } else
 {
 _expanded = false;
 _propSet.InsertBoolean("expanded", false);
_springAnimation.InitialValueExpression[“FinalValue”] = “this.StartingValue - 250”;
 }
 _naviPane.StartAnimation("Offset.X", _springAnimation);
}
```

では、このモーションを入力に関連付ける場合はどうすればよいでしょうか。 その場合、エンド ユーザーがスワイプしたときに、ウィンドウはばねのモーションで表示するのでしょうか? さらに重要なのは、ユーザーが勢いよくまたはすばやくスワイプした場合、エンド ユーザーの速度に基づいてモーションが適合されるという点です。

![スワイプしたときのばねアニメーション](images/animation/spring-animation-on-swipe.gif)

これを行うには、上記と同じばねアニメーションを使用し、そのアニメーションを InteractionTracker を使って InertiaModifier に渡すことができます。 InputAnimations と InteractionTracker について詳しくは、「[InteractionTracker を使用したカスタム操作エクスペリエンス](interaction-tracker-manipulations.md)」をご覧ください。 次のコード例では、InteractionTracker と VisualInteractionSource を既にセットアップしていることを前提としています。 このばねの例では、NaturalMotionAnimation を受け入れる InertiaModifier の作成が重要となります。

```csharp
// InteractionTracker and the VisualInteractionSource previously setup
// The open and close ScalarSpringAnimations defined earlier
private void SetupInput()
{
 // Define the InertiaModifier to manage the open motion
 var openMotionModifer = InteractionTrackerInertiaNaturalMotion.Create(compositor);

 // Condition defines to use open animation if panes in non-expanded view
 // Property set value to track if open or closed is managed in other part of code
 openMotionModifer.Condition = _compositor.CreateExpressionAnimation(
"propset.expanded == false");
 openMotionModifer.Condition.SetReferenceParameter("propSet", _propSet);
 openMotionModifer.NaturalMotion = _openSpringAnimation;

 // Define the InertiaModifer to manage the close motion
 var closeMotionModifier = InteractionTrackerInertiaNaturalMotion.Create(_compositor);

 // Condition defines to use close animation if panes in expanded view
 // Property set value to track if open or closed is managed in other part of code
 closeMotionModifier.Condition = 
_compositor.CreateExpressionAnimation("propSet.expanded == true");
 closeMotionModifier.Condition.SetReferenceParameter("propSet", _propSet);
 closeMotionModifier.NaturalMotion = _closeSpringAnimation;

 _tracker.ConfigurePositionXInertiaModifiers(new 
InteractionTrackerInertiaNaturalMotion[] { openMotionModifer, closeMotionModifier});

 // Take output of InteractionTracker and assign to the pane
 var exp = _compositor.CreateExpressionAnimation("-tracker.Position.X");
 exp.SetReferenceParameter("tracker", _tracker);
 ElementCompositionPreview.GetElementVisual(pageNavigation).
StartAnimation("Translation.X", exp);
}
```

これで、プログラムに基づくばねアニメーションと入力駆動型のばねアニメーションの両方を UI で使用できるようになりました。

以上をまとめると、ばねアニメーションをアプリで使用する手順は次のようになります。

1. コンポジターから SpringAnimation を作成します。
1. 既定値以外が必要な場合は、SpringAnimation のプロパティを定義します。
    - DampingRatio
    - Period
    - Final の値
    - Initial の値
    - 初期速度
1. ターゲットに割り当てます。
    - CompositionObject プロパティをアニメーション化する場合は、SpringAnimation をパラメーターとして StartAnimation に渡します。
    - アニメーションを入力で使用する場合は、InertiaModifier の NaturalMotion プロパティを SpringAnimation に設定します。

