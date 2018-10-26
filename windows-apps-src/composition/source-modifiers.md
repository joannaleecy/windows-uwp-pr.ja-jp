---
author: jwmsft
title: ソース修飾子を使用した引っ張って更新
description: SourceModifier を使用してカスタムの引っ張って更新コントロールを作成します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 997082d2ed7375d99a7be1543901d1dd854be1a0
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5559156"
---
# <a name="pull-to-refresh-with-source-modifiers"></a>ソース修飾子を使用した引っ張って更新

この記事では、InteractionTracker の SourceModifier 機能を使用する方法について詳しく説明します。また、カスタムの引っ張って更新コントロールを作成して、具体的な使用方法を紹介します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [入力駆動型アニメーション](input-driven-animations.md)
- [InteractionTracker を使用したカスタム操作エクスペリエンス](interaction-tracker-manipulations.md)
- [関係ベース アニメーション](relation-animations.md)

## <a name="what-is-a-sourcemodifier-and-why-are-they-useful"></a>SourceModifier の説明、および SourceModifier が便利である理由

[InertiaModifier](inertia-modifiers.md) と同様に、SourceModifier を使用すると、InteractionTracker のモーションを微調整することができます。 ただし、InteractionTracker が慣性状態に移行した後のモーションを定義する InertiaModifier とは異なり、SourceModifier は、InteractionTracker が対話状態になっている間のモーションを定義します。 このような場合は、従来の "指から離さない" エクスペリエンスとは異なるエクスペリエンスが必要になります。

この典型的な例が、引っ張って更新エクスペリエンスです。ユーザーがリストを引っ張ってコンテンツを更新し、そのリストが指と同じ速度でパンし、一定の距離を越えたときに停止すると、すばやく機械的なモーションが実現されます。 より自然なエクスペリエンスを実現するには、ユーザーがリストをアクティブに操作するときに抵抗感を感じることができるようにします。 この微妙なニュアンスを取り入れることによって、リストを操作するときのエンド ユーザー エクスペリエンス全体が、さらに動的で魅力的なものになります。 「例」セクションでは、このエクスペリエンスを作成する方法について詳しく説明します。

ソース修飾子には、次の 2 種類があります。

- DeltaPosition – タッチによるパン操作を行っているときの、指を置いている現在のフレーム位置と前のフレーム位置の間におけるデルタです。 このソース修飾子を使用すると、次の処理のためにデルタ位置を送信する前に、操作のデルタ位置を変更することができます。 これは Vector3 型のパラメーターで、開発者は、パラメーターを InteractionTracker に渡す前に、位置の X、Y、Z 属性を変更することができます。
- DeltaScale - 現在のフレーム スケールと、タッチによるズーム操作を行っているときに適用された前のフレーム スケールの間におけるデルタです。 このソース修飾子を使用すると、操作のズーム レベルを変更することができます。 これは浮動小数点型の属性で、開発者は、この属性を InteractionTracker に渡す前に変更することができます。

InteractionTracker が対話状態になっているとき、InteractionTracker では、割り当てられている各ソース修飾子を評価し、それらのいずれが適合するかを判別します。 つまり、1 つの InteractionTracker に対して複数のソース修飾子を作成し割り当てることができます。 ただし、各ソース修飾子を定義するときは、次の手順を実行する必要があります。

1. 条件の定義 – この特定のソース修飾子を適用するタイミングを指定する条件付きステートメントを定義する式を使用します。
1. DeltaPosition/DeltaScale の定義 – 上で定義した条件を満足したときに DeltaPosition または DeltaScale を変更するソース修飾子の式を使用します。

## <a name="example"></a>例

次に、ソース修飾子を使用して、XAML の ListView コントロールを使ったカスタムの引っ張って更新エクスペリエンスを作成する方法を見てみましょう。 ここではキャンバスを "更新パネル" として使用します。この更新パネルは XAML ListView 上に積み重なり、このエクスペリエンスを構築します。

エンド ユーザー エクスペリエンスのために、"抵抗" の効果を作成します。この効果は、ユーザーが (タッチ操作で) アクティブにリストをパンし、パンの位置が特定のポイントを越えた後でパンを停止する場合に適用されます。

![引っ張って更新を使用するリスト](images/animation/city-list.gif)

このエクスペリエンスで動作するコードについては、「[Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs)」(GitHub の Windows UI 開発ラボ リポジトリ) をご覧ください。 このエクスペリエンスを作成するためのステップ バイ ステップのチュートリアルを次に示します。
XAML マークアップ コードを、次のように構成します。

```xaml
<StackPanel Height="500" MaxHeight="500" x:Name="ContentPanel" HorizontalAlignment="Left" VerticalAlignment="Top" >
 <Canvas Width="400" Height="100" x:Name="RefreshPanel" >
<Image x:Name="FirstGear" Source="ms-appx:///Assets/Loading.png" Width="20" Height="20" Canvas.Left="200" Canvas.Top="70"/>
 </Canvas>
 <ListView x:Name="ThumbnailList"
 MaxWidth="400"
 Height="500"
ScrollViewer.VerticalScrollMode="Enabled" ScrollViewer.IsScrollInertiaEnabled="False" ScrollViewer.IsVerticalScrollChainingEnabled="True" >
 <ListView.ItemTemplate>
 ……
 </ListView.ItemTemplate>
 </ListView>
</StackPanel>
```

ListView (`ThumbnailList`) は既にスクロールされる XAML コントロールであるため、一番上の項目に到達し、それ以上スクロールできなくなったときに親の (`ContentPanel`) までチェーンされるスクロールが必要になります  (ContentPanel でソース修飾子を適用します)。そのためには、ListView マークアップで ScrollViewer.IsVerticalScrollChainingEnabled を **true** に設定する必要があります。 また、VisualInteractionSource のチェーン モードを **Always** に設定する必要もあります。

_handledEventsToo_ パラメーターを使用して、PointerPressedEvent ハンドラーを **true** に設定する必要があります。 このオプションを使用しないと、PointerPressedEvent は ListView コントロールとして ContentPanel にチェーンされず、これらのイベントは処理済みとしてマークされ、これらのイベントはビジュアル チェーンに送信されなくなります。

```csharp
//The PointerPressed handler needs to be added using AddHandler method with the //handledEventsToo boolean set to "true"
//instead of the XAML element's "PointerPressed=Window_PointerPressed",
//because the list view needs to chain PointerPressed handled events as well.
ContentPanel.AddHandler(PointerPressedEvent, new PointerEventHandler( Window_PointerPressed), true);
```

これで、InteractionTracker に関連付ける準備ができました。 まず、InteractionTracker、VisualInteractionSource、および InteractionTracker の位置を活用する式をセットアップします。

```csharp
// InteractionTracker and VisualInteractionSource setup.
_root = ElementCompositionPreview.GetElementVisual(Root);
_compositor = _root.Compositor;
_tracker = InteractionTracker.Create(_compositor);
_interactionSource = VisualInteractionSource.Create(_root);
_interactionSource.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;
_interactionSource.PositionYChainingMode = InteractionChainingMode.Always;
_tracker.InteractionSources.Add(_interactionSource);
float refreshPanelHeight = (float)RefreshPanel.ActualHeight;
_tracker.MaxPosition = new Vector3((float)Root.ActualWidth, 0, 0);
_tracker.MinPosition = new Vector3(-(float)Root.ActualWidth, -refreshPanelHeight, 0);

// Use the Tacker's Position (negated) to apply to the Offset of the Image.
// The -{refreshPanelHeight} is to hide the refresh panel
m_positionExpression = _compositor.CreateExpressionAnimation($"-tracker.Position.Y - {refreshPanelHeight} ");
m_positionExpression.SetReferenceParameter("tracker", _tracker);
_contentPanelVisual.StartAnimation("Offset.Y", m_positionExpression);
```

このセットアップでは、更新パネルはビューポートに収まっておらず、開始位置にあります。またユーザーに表示されるのは ListView です。パンが ContentPanel に到達すると、PointerPressed イベントが発生し、InteractionTracker を使用して操作エクスペリエンスを実行するようにシステムに要求します。

```csharp
private void Window_PointerPressed(object sender, PointerRoutedEventArgs e)
{
if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch) {
 // Tell the system to use the gestures from this pointer point (if it can).
 _interactionSource.TryRedirectForManipulation(e.GetCurrentPoint(null));
 }
}
```

> [!NOTE]
> Handled イベントのチェーンが必要でない場合は、PointerPressedEvent ハンドラーの追加を、XAML マークアップで属性 (`PointerPressed="Window_PointerPressed"`) を使用することで直接実行できます。

次の手順では、ソース修飾子をセットアップします。 このエクスペリエンスの動作を実現するために、2 つのソース修飾子 _Resistance_ と _Stop_ を使用します。

- Resistance – DeltaPosition.Y を、RefreshPanel の高さに達するまで、半分の速度で移動します。

```csharp
CompositionConditionalValue resistanceModifier = CompositionConditionalValue.Create (_compositor);
ExpressionAnimation resistanceCondition = _compositor.CreateExpressionAnimation(
 $"-tracker.Position.Y < {pullToRefreshDistance}");
resistanceCondition.SetReferenceParameter("tracker", _tracker);
ExpressionAnimation resistanceAlternateValue = _compositor.CreateExpressionAnimation(
 "source.DeltaPosition.Y / 3");
resistanceAlternateValue.SetReferenceParameter("source", _interactionSource);
resistanceModifier.Condition = resistanceCondition;
resistanceModifier.Value = resistanceAlternateValue;
```

- Stop – RefreshPanel 全体が画面に表示されたら、動作を停止します。

```csharp
CompositionConditionalValue stoppingModifier = CompositionConditionalValue.Create (_compositor);
ExpressionAnimation stoppingCondition = _compositor.CreateExpressionAnimation(
 $"-tracker.Position.Y >= {pullToRefreshDistance}");
stoppingCondition.SetReferenceParameter("tracker", _tracker);
ExpressionAnimation stoppingAlternateValue = _compositor.CreateExpressionAnimation("0");
stoppingModifier.Condition = stoppingCondition;
stoppingModifier.Value = stoppingAlternateValue;
Now add the 2 source modifiers to the InteractionTracker.
List<CompositionConditionalValue> modifierList = new List<CompositionConditionalValue>()
{ resistanceModifier, stoppingModifier };
_interactionSource.ConfigureDeltaPositionYModifiers(modifierList);
```

次の図は、SourceModifier のセットアップを説明したものです。

![パンの図](images/animation/source-modifiers-diagram.png)

以上で、SourceModifier を使用して、ListView を下にパンしたときに一番上の項目に到達したことを認識できるようになります。更新パネルは、RefreshPanel の高さに到達するまでパンの半分の速度で引き下げられ、その後で動作が停止します。

完全なサンプルでは、KeyFrame アニメーションを使用して、RefreshPanel キャンバスで操作を行っているときにアイコンを回転させています。 アニメーションを動作させる部分では任意のコンテンツを使用できます。また、InteractionTracker の位置を利用して、このアニメーションを個別に動作させることができます。
