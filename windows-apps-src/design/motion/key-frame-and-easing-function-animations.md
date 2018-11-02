---
author: Jwmsft
title: キー フレーム アニメーションとイージング関数のアニメーション
ms.assetid: D8AF24CD-F4C2-4562-AFD7-25010955D677
description: 線形キー フレーム アニメーション、KeySpline 値を設定したキー フレーム アニメーション、イージング関数は、ほとんど同じシナリオを実現できる 3 種類の手法です。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2076866cc31f50bd7ccfc6730bca5be96ffdc7c3
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5991443"
---
# <a name="key-frame-animations-and-easing-function-animations"></a>キー フレーム アニメーションとイージング関数のアニメーション



線形キー フレーム アニメーション、**KeySpline** 値を設定したキー フレーム アニメーション、イージング関数は、ほとんど同じシナリオを実現できる 3 種類の手法です。そのシナリオとは、開始状態から終了状態までの間に非線形のアニメーション動作を使う、やや複雑なストーリーボードに設定されたアニメーションの作成です。

## <a name="prerequisites"></a>前提条件

トピック「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」を読んでいること。 このトピックは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」で説明したアニメーションの概念を基に作成されています。その内容はここでは触れません。 具体的には、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」では、アニメーションのターゲットを設定する方法、リソースとしてのストーリーボード、[**Duration**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.duration) や [**FillBehavior**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.fillbehavior) などの [**Timeline**](https://msdn.microsoft.com/library/windows/apps/BR210517) プロパティ値について紹介しています。

## <a name="animating-using-key-frame-animations"></a>キー フレーム アニメーションを使ったアニメーション化

キー フレーム アニメーションでは、アニメーション タイムラインに沿ってポイントに到達する複数のターゲット値を使うことができます。 つまり、キー フレームごとに異なる中間値も指定でき、到達した最後のキー フレームが最終的なアニメーション値になります。 複数の値を指定してアニメーション化を行うことで、より複雑なアニメーションを実現できます。 キー フレーム アニメーションでは、アニメーションの種類ごとに異なる **KeyFrame** サブクラスとして実装される、異なる補間ロジックを使うこともできます。 具体的には、各種類のキー フレーム アニメーションには、キー フレームを指定するための **KeyFrame** クラスのバリエーションが 4 つ (**Discrete**、**Linear**、**Spline**、**Easing**) あります。 たとえば、[**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) をターゲットとし、キー フレームを使うアニメーションを指定するには、[**DiscreteDoubleKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR243130)、[**LinearDoubleKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR210316)、[**SplineDoubleKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR210446)、[**EasingDoubleKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR210269) でキー フレームを宣言できます。 単一の **KeyFrames** コレクションに含まれるこれらすべての種類を使って、新しいキー フレームに到達するたびに補間を変更できます。

補間の動作のために、各キー フレームはその **KeyTime** の時間に達するまで補間を制御します。 その時点で、その **Value** にも達します。 それ以上のキー フレームがある場合は、値はシーケンス内の次のキー フレームの開始値になります。

アニメーションの開始時に、**KeyTime** が "0:0:0" のキー フレームがない場合、開始値はプロパティのアニメーション化されていない値になります。 これは、**From** がない場合の **From**/**To**/**By** アニメーションの動作方法と似ています。

キー フレーム アニメーションの継続時間は、いずれかのキー フレームに設定されている最も大きい **KeyTime** 値と暗黙的に等しくなります。 必要に応じて [**Duration**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.duration) を明示的に設定することもできますが、独自のキー フレームの **KeyTime** よりも短くならないように注意してください。アニメーションが途中で途切れることになります。

[**Duration**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.duration) 以外にも、**From**/**To**/**By** アニメーションの場合と同様に、[**Timeline**](https://msdn.microsoft.com/library/windows/apps/BR210517) ベースのすべてのプロパティをキー フレーム アニメーションに設定できます。キー フレーム アニメーション クラスも **Timeline** から派生しているためです。 それらを次に示します。

-   [**AutoReverse**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.autoreverse): 最後のキー フレームに達すると、フレームは最後から逆に繰り返されます。 アニメーションの明確な継続時間が 2 倍になります。
-   [**BeginTime**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.begintime): アニメーションの開始を遅らせます。 **BeginTime** に達するまで、フレーム内にある **KeyTime** 値のタイムラインはカウントを開始しないため、フレームがカットされる心配はありません。
-   [**FillBehavior**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.fillbehavior): 最後のキー フレームに達したときの処理を制御します。 **FillBehavior** はどの中間キー フレームにも影響しません。
-   [**RepeatBehavior**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.repeatbehaviorproperty):
    -   **Forever** に設定した場合、キー フレームとそのタイムラインが無限に繰り返されます。
    -   反復回数に設定した場合、タイムラインはその回数だけ繰り返されます。
    -   [**Duration**](https://msdn.microsoft.com/library/windows/apps/BR242377) に設定した場合、その時間に達するまでタイムラインが繰り返されます。 このとき、キー フレーム シーケンスの途中でアニメーションが途切れる可能性があります (タイムラインの暗黙的な継続時間の整数ファクターではない場合)。
-   [**SpeedRatio**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.speedratioproperty) (通常は使いません)

### <a name="linear-key-frames"></a>線形キー フレーム

線形キー フレームの場合は、フレームの **KeyTime** に達するまで、値の単純な線形補間が行われます。 この補間の動作は、トピック「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」で説明されている単純な **From**/**To**/**By** アニメーションに非常に類似しています。

キー フレーム アニメーションで線形キー フレームを使って四角形の描画の高さをスケーリングする方法を以下に示します。 この例で実行するアニメーションでは、四角形の高さが最初の 4 秒間は線形にやや増加し、その後、四角形が当初の高さの 2 倍になるまで急速に拡大します。

```xml
<StackPanel>
    <StackPanel.Resources>
        <Storyboard x:Name="myStoryboard">
            <DoubleAnimationUsingKeyFrames
              Storyboard.TargetName="myRectangle"
              Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <LinearDoubleKeyFrame Value="1" KeyTime="0:0:0"/>
                <LinearDoubleKeyFrame Value="1.2" KeyTime="0:0:4"/>
                <LinearDoubleKeyFrame Value="2" KeyTime="0:0:5"/>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </StackPanel.Resources>
</StackPanel>
```

### <a name="discrete-key-frames"></a>離散キー フレーム

離散キー フレームでは、補間を一切使いません。 **KeyTime** に達すると、新しい **Value** が単純に適用されます。 アニメーション化される UI プロパティに応じて、"ジャンプ" するように見えるアニメーションになることがよくあります。 これが、望みどおりのきれいな動作であることを確認してください。 宣言するキー フレームの数を増やすことで明確なジャンプを最小限に抑えることができますが、スムーズなアニメーションが必要な場合は、線形キー フレームかスプライン キー フレームを使うことをお勧めします。

> [!NOTE]
> 離散キー フレームは、[**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx)、[**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870)、[**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) 型ではない値を [**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR243132) でアニメーション化するための唯一の手段です。 その詳しい内容については、このトピックの後半で説明します。

### <a name="spline-key-frames"></a>スプライン キー フレーム

スプライン キー フレームでは、値から値までの可変的な遷移を **KeySpline** プロパティの値に基づいて作成します。 このプロパティは、ベジエ曲線の 1 つ目と 2 つ目の制御点を指定し、アニメーションの加速度を表します。 基本的には、[**KeySpline**](https://msdn.microsoft.com/library/windows/apps/BR210307) は、時間に基づく関数の関係 (関数の時間グラフがそのベジエ曲線の図形となる) を定義するものです。 通常は、スペースまたはコンマで区切った 4 つの [**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) 値を持つ XAML の短縮形の属性文字列で **KeySpline** 値を指定します。 これらの値は、ベジエ曲線の 2 つの制御点に対応する "X,Y" のペアです。 "X" は時間、"Y" は値に対する関数修飾子です。 各値は、必ず 0 と 1 の間 (両端を含む) である必要があります。 **KeySpline** に対する制御点を変更しない場合、0,0 から 1,1 までの直線は、線形補間の時間に基づく関数を表したものです。 制御点によってその曲線の図形が変化するため、スプライン アニメーションの時間に基づく関数の動作も変化します。 これはグラフで視覚的に確かめることをお勧めします。 ブラウザーで [Silverlight キー スプライン ビジュアライザーのサンプル](http://samples.msdn.microsoft.com/Silverlight/SampleBrowser/index.htm#/?sref=KeySplineExample)を実行すると、制御点によって曲線がどのように変化するかや、制御点を **KeySpline** 値として使ったときのサンプル アニメーションの動作を調べることができます。

次の例は、アニメーションに適用される 3 種類のキー フレームを示しています。最後のキー フレームは、[**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) 値のキー スプライン アニメーションです ([**SplineDoubleKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR210446))。 文字列 "0.6,0.0 0.9,0.00" が **KeySpline** に対して適用されていることに注目してください。 これにより、アニメーションが最初はゆっくり動作するものの、**KeyTime** に達する直前で急速に速度を増す曲線となります。

```xml
<Storyboard x:Name="myStoryboard">
    <!-- Animate the TranslateTransform's X property
        from 0 to 350, then 50,
        then 200 over 10 seconds. -->
    <DoubleAnimationUsingKeyFrames
        Storyboard.TargetName="MyAnimatedTranslateTransform"
        Storyboard.TargetProperty="X"
        Duration="0:0:10" EnableDependentAnimation="True">

        <!-- Using a LinearDoubleKeyFrame, the rectangle moves 
            steadily from its starting position to 500 over 
            the first 3 seconds.  -->
        <LinearDoubleKeyFrame Value="500" KeyTime="0:0:3"/>

        <!-- Using a DiscreteDoubleKeyFrame, the rectangle suddenly 
            appears at 400 after the fourth second of the animation. -->
        <DiscreteDoubleKeyFrame Value="400" KeyTime="0:0:4"/>

        <!-- Using a SplineDoubleKeyFrame, the rectangle moves 
            back to its starting point. The
            animation starts out slowly at first and then speeds up. 
            This KeyFrame ends after the 6th second. -->
        <SplineDoubleKeyFrame KeySpline="0.6,0.0 0.9,0.00" Value="0" KeyTime="0:0:6"/>
    </DoubleAnimationUsingKeyFrames>
</Storyboard>
```

### <a name="easing-key-frames"></a>イージング キー フレーム

イージング キー フレームは、補間が適用され、補間の時間に基づく関数が複数の定義済みの数式によって制御されるキー フレームです。 スプライン キー フレームでは、一部の種類のイージング関数とほぼ同じ結果を得ることができるものの、スプラインでは再現できない [**BackEase**](https://msdn.microsoft.com/library/windows/apps/BR243049) などのイージング関数もあります。

イージング関数をイージング キー フレームに適用するには、**EasingFunction** プロパティをそのキー フレームの XAML でプロパティ要素として設定します。 値として、いずれかの種類のイージング関数のオブジェクト要素を指定します。

この例では、[**DoubleAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243136) に対して [**CubicEase**](https://msdn.microsoft.com/library/windows/apps/BR243126) を適用し、さらに [**BounceEase**](https://msdn.microsoft.com/library/windows/apps/BR243057) を連続するキー フレームとして適用して、跳ね返りの効果を作成します。

```xml
<Storyboard x:Name="myStoryboard">
    <DoubleAnimationUsingKeyFrames Duration="0:0:10"
        Storyboard.TargetProperty="Height"
        Storyboard.TargetName="myEllipse">

        <!-- This keyframe animates the ellipse up to the crest 
            where it slows down and stops. -->
        <EasingDoubleKeyFrame Value="-300" KeyTime="00:00:02">
            <EasingDoubleKeyFrame.EasingFunction>
                <CubicEase/>
            </EasingDoubleKeyFrame.EasingFunction>
        </EasingDoubleKeyFrame>

        <!-- This keyframe animates the ellipse back down and makes
            it bounce. -->
        <EasingDoubleKeyFrame Value="0" KeyTime="00:00:06">
            <EasingDoubleKeyFrame.EasingFunction>
                <BounceEase Bounces="5"/>
            </EasingDoubleKeyFrame.EasingFunction>
        </EasingDoubleKeyFrame>
    </DoubleAnimationUsingKeyFrames>
</Storyboard>
```

これはイージング関数の一例に過ぎません。 詳しくは、次のセクションをご覧ください。

## <a name="easing-functions"></a>イージング関数

イージング関数を使うと、独自の数式をアニメーションに適用することができます。 数学演算は、2-D の座標系で実際の物理法則をシミュレートするアニメーションを作るうえで役立ちます。 たとえば、物体の跳ね返りや、ばねの動きを表現することができます。 キー フレームや **From**/**To**/**By** アニメーションを使って、類似した効果を表現することもできますが、膨大な作業が必要となり、完成したアニメーションも、数式を使った場合と比べると正確さに欠ける可能性があります。

イージング関数は 3 とおりの方法でアニメーションに適用できます。

-   前のセクションで説明したように、キー フレーム アニメーションでイージング キー フレームを使う方法。 [**EasingColorKeyFrame.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR210267)、[**EasingDoubleKeyFrame.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.easingdoublekeyframe.easingfunction.aspx)、または [**EasingPointKeyFrame.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR210279) を使います。
-   **From**/**To**/**By** のいずれかの種類のアニメーションで **EasingFunction** プロパティを設定する方法。 [**ColorAnimation.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR243075)、[**DoubleAnimation.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.doubleanimation.easingfunction.aspx)、または [**PointAnimation.EasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR210354) を使います。
-   [**VisualTransition**](https://msdn.microsoft.com/library/windows/apps/BR209034) の一部として [**GeneratedEasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR209037) を設定する方法。 これは、コントロールの表示状態を定義する場合の固有の方法です。詳しくは、「[**GeneratedEasingFunction**](https://msdn.microsoft.com/library/windows/apps/BR209037)」または「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808)」をご覧ください。

一連のイージング関数を以下にまとめます。

-   [**BackEase**](https://msdn.microsoft.com/library/windows/apps/BR243049): 指定されたパスのアニメーションを開始する直前に、逆の動きを与えます。
-   [**BounceEase**](https://msdn.microsoft.com/library/windows/apps/BR243057): 跳ね返りの効果を作成します。
-   [**CircleEase**](https://msdn.microsoft.com/library/windows/apps/BR243063): 円関数を使って加速と減速のアニメーションを作成します。
-   [**CubicEase**](https://msdn.microsoft.com/library/windows/apps/BR243126): 数式 f(t) = t3 を使って加速と減速のアニメーションを作成します。
-   [**ElasticEase**](https://msdn.microsoft.com/library/windows/apps/BR210282): 伸び縮みを繰り返して静止する、ばねに似たアニメーションを作成します。
-   [**ExponentialEase**](https://msdn.microsoft.com/library/windows/apps/BR210294): 指数関数の数式を使って加速と減速のアニメーションを作成します。
-   [**PowerEase**](https://msdn.microsoft.com/library/windows/apps/BR210399): 数式 f(t) = tp を使って加速と減速のアニメーションを作成します (p = [**Power**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.powerease.power) プロパティ)。
-   [**QuadraticEase**](https://msdn.microsoft.com/library/windows/apps/BR210403): 数式 f(t) = t2 を使って加速と減速のアニメーションを作成します。
-   [**QuarticEase**](https://msdn.microsoft.com/library/windows/apps/BR210405): 数式 f(t) = t4 を使って加速と減速のアニメーションを作成します。
-   [**QuinticEase**](https://msdn.microsoft.com/library/windows/apps/BR210407): 数式 f(t) = t5 を使って加速と減速のアニメーションを作成します。
-   [**SineEase**](https://msdn.microsoft.com/library/windows/apps/BR210439): 正弦公式を使って加速と減速のアニメーションを作成します。

一部のイージング関数には固有のプロパティがあります。 たとえば、[**BounceEase**](https://msdn.microsoft.com/library/windows/apps/BR243057) には [**Bounces**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.bounceease.bounces.aspx) と [**Bounciness**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.bounceease.bounciness.aspx) という 2 つのプロパティがあります。これらは、その特定の **BounceEase** の時間に基づく関数の動作を変更します。 [**CubicEase**](https://msdn.microsoft.com/library/windows/apps/BR243126) など、その他のイージング関数は、すべてのイージング関数に共通の [**EasingMode**](https://msdn.microsoft.com/library/windows/apps/BR210275) プロパティ以外にプロパティはなく、生成される時間に基づく関数の動作は常に同じです。

これらのイージング関数の一部は、プロパティを持つイージング関数でのプロパティの設定方法に応じて、重複する場合があります。 たとえば、[**QuadraticEase**](https://msdn.microsoft.com/library/windows/apps/BR210403) は、[**Power**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.powerease.power) が 2 の [**PowerEase**](https://msdn.microsoft.com/library/windows/apps/BR210399) と完全に同じです。 [**CircleEase**](https://msdn.microsoft.com/library/windows/apps/BR243063) は、基本的には既定値の [**ExponentialEase**](https://msdn.microsoft.com/library/windows/apps/BR210294) です。

[**BackEase**](https://msdn.microsoft.com/library/windows/apps/BR243049) イージング関数は、キー フレームの **From**/**To** または値によって設定される通常の範囲外の値を変更できるため、特別な関数です。 通常の **From**/**To** 動作とは逆の方向に値を変更することでアニメーションを開始し、**From** に戻るか、値をもう一度開始してから、アニメーションを通常どおり実行します。

前の例で、キー フレーム アニメーションのイージング関数を宣言する方法を紹介しました。 次の例では、イージング関数を **From**/**To**/**By** アニメーションに適用します。

```xml
<StackPanel x:Name="LayoutRoot" Background="White">
    <StackPanel.Resources>
        <Storyboard x:Name="myStoryboard">
            <DoubleAnimation From="30" To="200" Duration="00:00:3" 
                Storyboard.TargetName="myRectangle" 
                Storyboard.TargetProperty="(UIElement.RenderTransform).(ScaleTransform.ScaleY)">
                <DoubleAnimation.EasingFunction>
                    <BounceEase Bounces="2" EasingMode="EaseOut" 
                                Bounciness="2"/>
                </DoubleAnimation.EasingFunction>
            </DoubleAnimation>
        </Storyboard>
    </StackPanel.Resources>
    <Rectangle x:Name="myRectangle" Fill="Blue" Width="200" Height="30"/>
</StackPanel>
```

イージング関数が **From**/**To**/**By** アニメーションに適用されると、時間に基づく関数の特性 (アニメーションの [**Duration**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.timeline.duration) に基づいて値が **From** 値と **To** 値の間で補完されるしくみ) が変化します。 イージング関数を使わない場合は、線形補間になります。

## <a name="span-iddiscreteobjectvalueanimationsspanspan-iddiscreteobjectvalueanimationsspanspan-iddiscreteobjectvalueanimationsspandiscrete-object-value-animations"></a><span id="Discrete_object_value_animations"></span><span id="discrete_object_value_animations"></span><span id="DISCRETE_OBJECT_VALUE_ANIMATIONS"></span>離散オブジェクト値のアニメーション

[**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx)、[**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870)、または [**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) 型ではないプロパティにアニメーション化された値を適用する唯一の方法として、ある種類のアニメーションについて以下に説明します。 それは、キー フレーム アニメーション [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/BR210320) です。 [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx) 値を使ったアニメーション化は、フレーム間で値が補間される可能性がないため、これとは異なります。 フレームの [**KeyTime**](https://msdn.microsoft.com/library/windows/apps/BR210342) に達すると、アニメーション化された値はキー フレームの **Value** に指定された値にすぐに設定されます。 補間がないため、**ObjectAnimationUsingKeyFrames** キー フレーム コレクションで使うキー フレームは [**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR243132) だけです。

プロパティ要素構文を使って [**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR243132) の [**Value**](https://msdn.microsoft.com/library/windows/apps/BR210344) が設定されることはよくあります。これは、設定を試みるオブジェクト値が、属性構文の **Value** を設定するための文字列として表現できない場合があるためです。 [StaticResource](https://msdn.microsoft.com/library/windows/apps/Mt185588) などの参照を使う場合は、属性構文を利用できます。

既定のテンプレートで [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/BR210320) が使われる状況として、テンプレート プロパティが [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) リソースを参照する場合が挙げられます。 このようなリソースは単なる [**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) 値ではなく [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) オブジェクトであり、システム テーマとして定義されているリソース ([**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/BR208807)) を使います。 これらのリソースは、[**TextBlock.Foreground**](https://msdn.microsoft.com/library/windows/apps/BR209665) などの **Brush** 型の値に直接割り当てることができ、間接的なターゲット設定を使う必要はありません。 ただし、**SolidColorBrush** は [**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx)、[**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870)、または **Color** ではないため、リソースを使うには **ObjectAnimationUsingKeyFrames** を利用する必要があります。

```xml
<Style x:Key="TextButtonStyle" TargetType="Button">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="Button">
                <Grid Background="Transparent">
                    <TextBlock x:Name="Text"
                        Text="{TemplateBinding Content}"/>
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal"/>
                            <VisualState x:Name="PointerOver">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Text" Storyboard.TargetProperty="Foreground">
                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource ApplicationPointerOverForegroundThemeBrush}"/>
                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Pressed">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Text" Storyboard.TargetProperty="Foreground">
                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource ApplicationPressedForegroundThemeBrush}"/>
                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
...
                       </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

列挙値を使うプロパティをアニメーション化するために、[**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/BR210320) を使うこともできます。 次に、Windows ランタイムの既定のテンプレートに含まれている名前付きスタイルの別の例を示します。 [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR209006) 列挙定数を列挙定数受け取る [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) プロパティの設定方法に注目してください。 この場合は、属性構文を使って値を設定できます。 必要なのは、プロパティに "Collapsed" などの列挙値を設定するための列挙値からの非修飾定数名だけです。

```xml
<Style x:Key="BackButtonStyle" TargetType="Button">
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="Button">
          <Grid x:Name="RootGrid">
            <VisualStateManager.VisualStateGroups>
              <VisualStateGroup x:Name="CommonStates">
              <VisualState x:Name="Normal"/>
...           <VisualState x:Name="Disabled">
                <Storyboard>
                  <ObjectAnimationUsingKeyFrames Storyboard.TargetName="RootGrid" Storyboard.TargetProperty="Visibility">
                    <DiscreteObjectKeyFrame Value="Collapsed" KeyTime="0"/>
                  </ObjectAnimationUsingKeyFrames>
                </Storyboard>
              </VisualState>
            </VisualStateGroup>
...
          </VisualStateManager.VisualStateGroups>
        </Grid>
      </ControlTemplate>
    </Setter.Value>
  </Setter>
</Style>
```

[**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/BR210320) フレーム セットに対して、複数の [**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/BR243132) を使うことができます。 この方法は、複数のオブジェクト値が役立つサンプル シナリオで、[**Image.Source**](https://msdn.microsoft.com/library/windows/apps/BR242760) の値をアニメーション化して "スライド ショー" アニメーションを作成する際に検討することをお勧めします。

 ## <a name="related-topics"></a>関連トピック

* [プロパティ パス構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)
* [依存関係プロパティの概要](https://msdn.microsoft.com/library/windows/apps/Mt185583)
* [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490)
* [**Storyboard.TargetProperty**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.targetpropertyproperty)