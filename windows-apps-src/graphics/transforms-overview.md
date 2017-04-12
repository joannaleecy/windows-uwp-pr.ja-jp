---
author: Jwmsft
ms.assetid: F46D5E18-10A3-4F7B-AD67-76437C77E4BC
title: "変換の概要"
description: "UI 要素の相対座標系を変更して、Windows ランタイム&\\#160;API で変換を使う方法について説明します。"
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2643606fa3dcbf1c95669bb09bef0aae49f86529
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="transforms-overview"></a>変換の概要

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]


UI 要素の相対座標系を変更して、Windows ランタイム API で変換を使う方法について説明します。 変換を使うと、スケーリング、回転、x-y 空間内での平行移動など、個々の XAML 要素の外観を調整できます。

## <a name="span-idwhatisatransformspanspan-idwhatisatransformspanspan-idwhatisatransformspanwhat-is-a-transform"></a><span id="What_is_a_transform_"></span><span id="what_is_a_transform_"></span><span id="WHAT_IS_A_TRANSFORM_"></span>変換とは

*変換*とは、座標空間の間で点をマップする、つまり、変換する方法を定義することです。 変換が UI 要素に適用された場合、その UI 要素の外観が UI の一部として画面にレンダリングされる方法が変更されます。

平行移動、回転、スケーリング、スキュー (せん断) という 4 つの種類の変換を考えてみます。 グラフィックス API を使って UI 要素の外観を変更する目的で、最も簡単なのは通常、一度に 1 つの演算のみを定義する変換を作成することです。 そのため、Windows ランタイムでは、これらの変換の種類ごとに個別のクラスが定義されています。

-   [**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027): [**X**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.translatetransform.x.aspx) と [**Y**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.translatetransform.y) の値を設定することで、x-y 空間内で要素を平行移動します。
-   [**ScaleTransform**](https://msdn.microsoft.com/library/windows/apps/BR242940): [**CenterX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.scaletransform.centerx.aspx)、[**CenterY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.scaletransform.centery.aspx)、[**ScaleX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.scaletransform.scalex.aspx)、および [**ScaleY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.scaletransform.scaleyproperty) の値を設定することで、中心点に基づいて変換をスケーリングします。
-   [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932): [**Angle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.angle.aspx)、[**CenterX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.centerx.aspx)、および [**CenterY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.rotatetransform.centery) の値を設定することで、x-y 空間内で回転させます。
-   [**SkewTransform**](https://msdn.microsoft.com/library/windows/apps/BR242950): [**AngleX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.skewtransform.anglex.aspx)、[**AngleY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.skewtransform.angley.aspx)、[**CenterX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.skewtransform.centerx.aspx)、および [**CenterY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.scaletransform.centeryproperty) の値を設定することで、x-y 空間内でせん断します。

これらのうちで、UI のシナリオとして最もよく使うと思われるのは、[**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) と [**ScaleTransform**](https://msdn.microsoft.com/library/windows/apps/BR242940) です。

変換は組み合わせることができ、その組み合わせをサポートする 2 つの Windows ランタイム クラスとして、[**CompositeTransform**](https://msdn.microsoft.com/library/windows/apps/BR228105) と [**TransformGroup**](https://msdn.microsoft.com/library/windows/apps/BR243022) があります。 **CompositeTransform** では、変換が、回転、スキュー、回転、平行移動の順に適用されます。 変換を別の順序で適用する場合は、**CompositeTransform** ではなく、**TransformGroup** を使用します。 詳しくは、「[**CompositeTransform**](https://msdn.microsoft.com/library/windows/apps/BR228105)」をご覧ください。

## <a name="span-idtransformsandlayoutspanspan-idtransformsandlayoutspanspan-idtransformsandlayoutspantransforms-and-layout"></a><span id="Transforms_and_layout"></span><span id="transforms_and_layout"></span><span id="TRANSFORMS_AND_LAYOUT"></span>変換とレイアウト

XAML レイアウトでは、変換はレイアウト パスの完了後に適用されます。使用できるスペースの計算やその他のレイアウトは、変換が適用される前に決定されています。 レイアウトが最優先されるため、レイアウト時にスペースを割り当てる、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) セルなどのレイアウト コンテナー内にある要素を変換した場合に、予期しない結果になる可能性があります。 変換された要素は、途中で切れたり隠されたりことがあります。親コンテナー内のスペースを分割するとき、変換後のサイズを計算していなかったスペースに描画されるためです。 変換結果を試し、いくつかの設定の調整が必要になる場合があります。 たとえば、アダプティブ レイアウトやスター サイズ指定に頼るのではなく、**Center** プロパティを変更したり、レイアウト スペースの固定ピクセル値を宣言したりすることで、親が十分なスペースを確実に割り当てるようにすることが必要になる場合があります。

**移行のメモ:**  Windows Presentation Foundation (WPF) には、レイアウト パスの前に変換を適用する **LayoutTransform** プロパティがありました。 ただし、Windows ランタイム XAML では **LayoutTransform** のプロパティがサポートされていません。 (Microsoft Silverlight にも、このプロパティはありませんでした。)

## <a name="span-idapplyingatransformtoauielementspanspan-idapplyingatransformtoauielementspanspan-idapplyingatransformtoauielementspanapplying-a-transform-to-a-ui-element"></a><span id="Applying_a_transform_to_a_UI_element"></span><span id="applying_a_transform_to_a_ui_element"></span><span id="APPLYING_A_TRANSFORM_TO_A_UI_ELEMENT"></span>UI 要素への変換の適用

変換をオブジェクトに適用するときは、通常、適用して [**UIElement.RenderTransform**](https://msdn.microsoft.com/library/windows/apps/BR208980) プロパティを設定します。 このプロパティを設定すると、オブジェクトは、文字どおりのピクセル単位では変更されません。 このプロパティにより、そのオブジェクトが存在するローカル座標空間内で変換が適用されます。 その後、レンダリング ロジックとレイアウト後処理により、結合された座標空間がレンダリングされます。これにより、オブジェクトの外観が変わり、そのレイアウト位置も変わる可能性があります ([**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) が適用された場合)。

既定では、レンダリングされる各変換の中心点はターゲット オブジェクトのローカル座標系の原点 (0,0) になります。 その唯一の例外は、中心点を設定するプロパティのない [**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) です。平行移動の結果は、どこを中心点としても同じであるためです。 しかしその他の各変換には、**CenterX** と **CenterY** の値を設定するプロパティがあります。

変換を [**UIElement.RenderTransform**](https://msdn.microsoft.com/library/windows/apps/BR208980) と共に使うときは常に、変換動作に影響を与える別のプロパティが [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) にあることを覚えておいてください。それは、[**RenderTransformOrigin**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.rendertransformorigin.aspx) です。 **RenderTransformOrigin** で宣言するのは、変換全体を要素の既定点 (0,0) に適用するか、その要素の相対座標空間内のその他の原点に適用するかです。 一般的な要素の場合、(0,0) では変換が左上隅に適用されます。 求める効果によっては、変換の **CenterX** と **CenterY** の値を調整するのではなく、**RenderTransformOrigin** を変更することを選ぶこともできます。 **RenderTransformOrigin** と **CenterX** / **CenterY** の値の両方を適用する場合、まったく予期しない結果になる可能性があることに注意してください。特に、いずれかの値をアニメーション化している場合です。

ヒット テストの目的で、変換が適用されたオブジェクトは、x-y スペースでのその外観と一貫した、予期された方法で入力に応答し続けます。 たとえば、[**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) を使って、UI で [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371) を横方向に 400 ピクセル移動した場合は、**Rectangle** が視覚的に表示される位置をユーザーが押すと、その [**Rectangle** が **PointerPressed**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) イベントに応答します。 平行移動前に **Rectangle** があった位置をユーザーが押した場合、false イベントが発生することはありません。 ヒット テストに影響を与える z インデックスについて考えた場合、変換の適用による違いはありません。x-y スペース内のある位置の入力イベントをどの要素が処理するかを制御する z インデックスは、コンテナー内での子の宣言順に従って評価されます。 その順序は、通常、XAML で要素を宣言する順序と同じです。ただし、[**Canvas**](https://msdn.microsoft.com/library/windows/apps/BR209267) オブジェクトの子要素については、[**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.zindex.aspx) 添付プロパティを子要素に適用して、順序を調整できます。

## <a name="span-idothertransformpropertiesspanspan-idothertransformpropertiesspanspan-idothertransformpropertiesspanother-transform-properties"></a><span id="Other_transform_properties"></span><span id="other_transform_properties"></span><span id="OTHER_TRANSFORM_PROPERTIES"></span>変換のその他のプロパティ

-   [**Brush.Transform**](https://msdn.microsoft.com/library/windows/apps/BR228082)、[**Brush.RelativeTransform**](https://msdn.microsoft.com/library/windows/apps/BR228080): これらのプロパティは、**Brush** を適用して前景や背景などの視覚的なプロパティを設定する領域内で、[**Brush**](https://msdn.microsoft.com/library/windows/apps/BR228076) による座標空間の使い方に影響を与えます。 これらの変換は、ほとんどの一般的なブラシ (通常は [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) で単色を設定する) には関連していませんが、[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) または [**LinearGradientBrush**](https://msdn.microsoft.com/library/windows/apps/BR210108) で領域に描画するときには有用な場合があります。
-   [**Geometry.Transform**](https://msdn.microsoft.com/library/windows/apps/BR210066): このプロパティを使って、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/BR243356) プロパティ値にジオメトリを使う前に、そのジオメトリに変換を適用できます。

## <a name="span-idanimatingatransformspanspan-idanimatingatransformspanspan-idanimatingatransformspananimating-a-transform"></a><span id="Animating_a_transform"></span><span id="animating_a_transform"></span><span id="ANIMATING_A_TRANSFORM"></span>変換のアニメーション化

[**Transform**](https://msdn.microsoft.com/library/windows/apps/BR243006) オブジェクトはアニメーション化できます。 **Transform** をアニメーション化するには、アニメーション化するプロパティに互換性のある種類のアニメーションを適用します。 これは、通常、[**DoubleAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243136) オブジェクトまたは [**DoubleAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.doubleanimationusingkeyframes) オブジェクトを使ってアニメーションを定義していることを意味します。なぜなら、すべての変換プロパティは、型 [**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx) であるためです。 [**UIElement.RenderTransform**](https://msdn.microsoft.com/library/windows/apps/BR208980) 値に使われる変換に影響を与えるアニメーションは、再生時間が 0 以外であっても、依存型アニメーションとは見なされません。 依存型アニメーションについて詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。

プロパティをアニメーション化して、最終的な外観という点で同様の効果を生み出す場合、たとえば、[**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027) を適用する代わりに、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) の [**Width**](https://msdn.microsoft.com/library/windows/apps/BR208751) と [**Height**](https://msdn.microsoft.com/library/windows/apps/BR208718) をアニメーション化する場合、このようなアニメーションは、ほとんど常に依存型アニメーションとして扱われます。 アニメーションを有効にする必要があるため、パフォーマンスに大きな問題が発生する可能性があります。特に、ユーザーの操作をサポートしながら、そのオブジェクトをアニメーション化する場合です。 そのため、望ましいのは、変換を使ってアニメーション化することです。この場合は、他のどのプロパティもアニメーション化されず、アニメーションが依存型アニメーションとして扱われることはありません。

変換をターゲット設定するには、既にある [**Transform**](https://msdn.microsoft.com/library/windows/apps/BR243006) を [**RenderTransform**](https://msdn.microsoft.com/library/windows/apps/BR208980) の値にする必要があります。 通常は、適切な種類の変換の要素を、場合によってはその変換にプロパティを設定せずに、最初の XAML に配置します。

通常は、間接的なターゲット設定の手法を使って変換のプロパティにアニメーションを適用します。 間接的なターゲット設定の構文について詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」と「[プロパティ パス構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。

コントロールの既定のスタイルで、表示状態の動作の一部として変換のアニメーションを定義する場合があります。 たとえば、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/BR227538) の表示状態で、アニメーション化した [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932) 値を使って、リングのドットを "回転" させます。

ここでは、変換をアニメーション化する方法の簡単な例を示します。 この例では、[**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932) の [**Angle**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.rotatetransform.angle.aspx) をアニメーション化して、その視覚的な中心点の周りで [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371) を回転させます。 また、この例では、**RotateTransform** に名前を付けません。間接的なアニメーションのターゲット設定には不要なためです。しかしその代わりに、変換には名前を付けませんが、変換が適用される要素に名前を付けることで、`(UIElement.RenderTransform).(RotateTransform.Angle)` などの間接的なターゲット設定を使うことができます。

```xml
<StackPanel Margin="15">
  <StackPanel.Resources>
    <Storyboard x:Name="myStoryboard">
      <DoubleAnimation
       Storyboard.TargetName="myTransform"
       Storyboard.TargetProperty="Angle"
       From="0" To="360" Duration="0:0:5" 
       RepeatBehavior="Forever" />
    </Storyboard>
  </StackPanel.Resources>
  <Rectangle Width="50" Height="50" Fill="RoyalBlue"
   PointerPressed="StartAnimation">
    <Rectangle.RenderTransform>
      <RotateTransform x:Name="myTransform" Angle="45" CenterX="25" CenterY="25" />
    </Rectangle.RenderTransform>
  </Rectangle>
</StackPanel>
```

```xml
void StartAnimation (object sender, RoutedEventArgs e) {
    myStoryboard.Begin();
}
```

## <a name="span-idaccountingforcoordinateframesofreferenceatruntimespanspan-idaccountingforcoordinateframesofreferenceatruntimespanspan-idaccountingforcoordinateframesofreferenceatruntimespanaccounting-for-coordinate-frames-of-reference-at-run-time"></a><span id="Accounting_for_coordinate_frames_of_reference_at_run_time"></span><span id="accounting_for_coordinate_frames_of_reference_at_run_time"></span><span id="ACCOUNTING_FOR_COORDINATE_FRAMES_OF_REFERENCE_AT_RUN_TIME"></span>実行時の参照座標系の説明

[**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) には、[**TransformToVisual**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.transformtovisual.aspx) という名前のメソッドがあります。このメソッドは、2 つの UI 要素の参照座標系を対応付ける [**Transform**](https://msdn.microsoft.com/library/windows/apps/BR243006) を生成できます。 このメソッドを使って要素をアプリの既定の参照座標系に比較できます。この場合は最初のパラメーターとしてルート ビジュアルを渡します。 この方法が役立つことがあるのは、別の要素から入力イベントをキャプチャする場合や、実際にレイアウト パスを要求せずにレイアウト動作を予測しようとする場合です。

ポインター イベントから取得したイベント データを使うと、[**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/BR212141) メソッドにアクセスできます。このメソッドで、参照座標系をアプリの既定のものではなく特定の要素のものに変更するように、*relativeTo* パラメーターを指定できます。 これにより、平行移動変換が内部で適用され、戻り値となる [**PointerPoint**](https://msdn.microsoft.com/library/windows/apps/BR242038) オブジェクトの作成時に x-y 座標データが変換されます。

## <a name="span-iddescribingatransformmathematicallyspanspan-iddescribingatransformmathematicallyspanspan-iddescribingatransformmathematicallyspandescribing-a-transform-mathematically"></a><span id="Describing_a_transform_mathematically"></span><span id="describing_a_transform_mathematically"></span><span id="DESCRIBING_A_TRANSFORM_MATHEMATICALLY"></span>変換の数学的な記述

変換は、変換マトリックスの観点から説明できます。 3×3 マトリックスは、2 次元の x-y 平面での変換を記述するために使われます。 アフィン変換マトリックスでは、平行移動前の任意の数の線形変換 (回転やスキュー (せん断) など) を 1 つのマトリックスの乗算にまとめることができます。 アフィン変換マトリックスの最後の列は (0, 0, 1) に等しいため、最初の 2 列のメンバーのみを数学的記述で指定する必要があります。

変換の数学的記述が役立つことがあるのは、数学的な背景知識がある場合や、やはりマトリックスを使って座標空間の変換を記述するグラフィックス プログラミング手法に精通している場合です。 [**Transform**](https://msdn.microsoft.com/library/windows/apps/BR243006) の派生クラスとして [**MatrixTransform**](https://msdn.microsoft.com/library/windows/apps/BR210137) があり、その 3×3 マトリックスで直接、変換を表すことができます。 **MatrixTransform** には [**Matrix**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.matrixtransform.matrix.aspx) プロパティがあり、[**M11**](https://msdn.microsoft.com/library/windows/apps/Hh673847)、[**M12**](https://msdn.microsoft.com/library/windows/apps/Hh673853)、[**M21**](https://msdn.microsoft.com/library/windows/apps/Hh673851)、[**M22**](https://msdn.microsoft.com/library/windows/apps/Hh673849)、[**OffsetX**](https://msdn.microsoft.com/library/windows/apps/Hh673810)、[**OffsetY**](https://msdn.microsoft.com/library/windows/apps/Hh673816) という 6 つのプロパティから成る構造体が格納されます。 [**Matrix**](https://msdn.microsoft.com/library/windows/apps/BR210127) プロパティには **Double** 値が使われ、各プロパティはアフィン変換マトリックスの 6 つの該当する値 (列 1 および 2) に対応します。

|                                             |                                             |     |
|---------------------------------------------|---------------------------------------------|-----|
| [**M11**](https://msdn.microsoft.com/library/windows/apps/Hh673847)         | [**M21**](https://msdn.microsoft.com/library/windows/apps/Hh673851)         | 0   |
| [**M12**](https://msdn.microsoft.com/library/windows/apps/Hh673853)         | [**M22**](https://msdn.microsoft.com/library/windows/apps/Hh673849)         | 0   |
| [**OffsetX**](https://msdn.microsoft.com/library/windows/apps/Hh673810) | [**OffsetY**](https://msdn.microsoft.com/library/windows/apps/Hh673816) | 1   |

 

[**TranslateTransform**](https://msdn.microsoft.com/library/windows/apps/BR243027)、[**ScaleTransform**](https://msdn.microsoft.com/library/windows/apps/BR242940)、[**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932)、または [**SkewTransform**](https://msdn.microsoft.com/library/windows/apps/BR242950) の各オブジェクトで記述できる変換は、[**MatrixTransform**](https://msdn.microsoft.com/library/windows/apps/BR210137) と [**Matrix**](https://msdn.microsoft.com/library/windows/apps/BR210127) 値で同様に記述できます。 ただし、一般的に使われるのは、**TranslateTransform** などです。それらの変換クラスのプロパティは、**Matrix** でベクター成分を設定するよりも、概念化が簡単なためです。 また、変換の個別のプロパティをアニメーション化することも簡単です。**Matrix** は実際には構造体であり、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356) ではありません。したがって、アニメーション化された個々の値をサポートすることはできません。

変換演算の適用を可能にする XAML 設計ツールには、結果を [**MatrixTransform**](https://msdn.microsoft.com/library/windows/apps/BR210137) としてシリアル化するものもあります。 この場合に最善と思われる方法は、[**Matrix**](https://msdn.microsoft.com/library/windows/apps/BR210127) の値を XAML で直接操作しようとすることではなく、もう一度同じ設計ツールを使って変換結果を変更し、もう一度 XAML でシリアル化することです。

## <a name="span-id3-dtransformsspanspan-id3-dtransformsspanspan-id3-dtransformsspan3-d-transforms"></a><span id="3-D_transforms"></span><span id="3-d_transforms"></span><span id="3-D_TRANSFORMS"></span>3-D 変換

Windows 10 では、XAML に新しいプロパティである [**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.transform3d.aspx) が導入されました。このプロパティを使用すると、UI で使用する 3D 効果を作成できます。 そのためには、[**PerspectiveTransform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.media3d.perspectivetransform3d.aspx) を使用して共有 3D 視点、つまり "カメラ" をシーンに追加し、[**CompositeTransform**](https://msdn.microsoft.com/library/windows/apps/BR228105) を使用する場合のように、[**CompositeTransform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.media3d.compositetransform3d.aspx) を使用して 3D 空間の要素を変換します。 3D 変換を実装する方法の説明については、[**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.transform3d.aspx) のページをご覧ください。

 1 つのオブジェクトにのみ適用されるもっと簡単な 3D 効果については、[**UIElement.Projection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.projection) プロパティを使用できます。 このプロパティの値として [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/br210192) を使用することは、固定された視点の変換と 1 つ以上の 3D 変換を要素に適用することに相当します。 この種類の変換については、「[XAML UI 用の 3-D 遠近効果](3-d-perspective-effects.md)」でより詳しく説明しています。

## <a name="span-idrelatedtopicsspanrelated-topics"></a><span id="related_topics"></span>関連トピック

* [図形の描画](drawing-shapes.md)
* [**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.transform3d.aspx)
* [XAML UI 用の 3-D 遠近効果](3-d-perspective-effects.md)
* [**Transform**](https://msdn.microsoft.com/library/windows/apps/BR243006)
 

 





