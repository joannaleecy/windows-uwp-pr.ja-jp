---
title: ソース修飾子を使用した引っ張って更新
description: SourceModifier を使用してカスタムの引っ張って更新コントロールを作成します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 834f631cd5c4b8696e75f83f194b95f809b1cf8a
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7837752"
---
# <a name="pull-to-refresh-with-source-modifiers"></a><span data-ttu-id="89a85-104">ソース修飾子を使用した引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="89a85-104">Pull-to-refresh with source modifiers</span></span>

<span data-ttu-id="89a85-105">この記事では、InteractionTracker の SourceModifier 機能を使用する方法について詳しく説明します。また、カスタムの引っ張って更新コントロールを作成して、具体的な使用方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="89a85-105">In this article, we take a deeper dive into how to use an InteractionTracker’s SourceModifier feature and demonstrate its use by creating a custom pull-to-refresh control.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="89a85-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="89a85-106">Prerequisites</span></span>

<span data-ttu-id="89a85-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="89a85-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="89a85-108">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="89a85-108">Input-driven animations</span></span>](input-driven-animations.md)
- [<span data-ttu-id="89a85-109">InteractionTracker を使用したカスタム操作エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="89a85-109">Custom manipulation experiences with InteractionTracker</span></span>](interaction-tracker-manipulations.md)
- [<span data-ttu-id="89a85-110">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="89a85-110">Relation based animations</span></span>](relation-animations.md)

## <a name="what-is-a-sourcemodifier-and-why-are-they-useful"></a><span data-ttu-id="89a85-111">SourceModifier の説明、および SourceModifier が便利である理由</span><span class="sxs-lookup"><span data-stu-id="89a85-111">What is a SourceModifier and why are they useful?</span></span>

<span data-ttu-id="89a85-112">[InertiaModifier](inertia-modifiers.md) と同様に、SourceModifier を使用すると、InteractionTracker のモーションを微調整することができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-112">Like [InertiaModifiers](inertia-modifiers.md), SourceModifiers give you finer grain control over the motion of an InteractionTracker.</span></span> <span data-ttu-id="89a85-113">ただし、InteractionTracker が慣性状態に移行した後のモーションを定義する InertiaModifier とは異なり、SourceModifier は、InteractionTracker が対話状態になっている間のモーションを定義します。</span><span class="sxs-lookup"><span data-stu-id="89a85-113">But unlike InertiaModifiers that define the motion after InteractionTracker enters inertia, SourceModifiers define the motion while InteractionTracker is still in its interacting state.</span></span> <span data-ttu-id="89a85-114">このような場合は、従来の "指から離さない" エクスペリエンスとは異なるエクスペリエンスが必要になります。</span><span class="sxs-lookup"><span data-stu-id="89a85-114">In these cases, you want a different experience than the traditional "stick to the finger".</span></span>

<span data-ttu-id="89a85-115">この典型的な例が、引っ張って更新エクスペリエンスです。ユーザーがリストを引っ張ってコンテンツを更新し、そのリストが指と同じ速度でパンし、一定の距離を越えたときに停止すると、すばやく機械的なモーションが実現されます。</span><span class="sxs-lookup"><span data-stu-id="89a85-115">A classic example of this is the pull-to-refresh experience - when the user pulls the list to refresh the contents and the list pans at the same speed as the finger and stops after a certain distance, the motion would feel abrupt and mechanical.</span></span> <span data-ttu-id="89a85-116">より自然なエクスペリエンスを実現するには、ユーザーがリストをアクティブに操作するときに抵抗感を感じることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="89a85-116">A more natural experience would be to introduce a feel of resistance while the user actively interacts with the list.</span></span> <span data-ttu-id="89a85-117">この微妙なニュアンスを取り入れることによって、リストを操作するときのエンド ユーザー エクスペリエンス全体が、さらに動的で魅力的なものになります。</span><span class="sxs-lookup"><span data-stu-id="89a85-117">This small nuance helps make the overall end user experience of interacting with a list more dynamic and appealing.</span></span> <span data-ttu-id="89a85-118">「例」セクションでは、このエクスペリエンスを作成する方法について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="89a85-118">In the Example section, we go into more detail about how to build this.</span></span>

<span data-ttu-id="89a85-119">ソース修飾子には、次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="89a85-119">There are 2 types of Source Modifiers:</span></span>

- <span data-ttu-id="89a85-120">DeltaPosition – タッチによるパン操作を行っているときの、指を置いている現在のフレーム位置と前のフレーム位置の間におけるデルタです。</span><span class="sxs-lookup"><span data-stu-id="89a85-120">DeltaPosition – is the delta between the current frame position and the previous frame position of the finger during the touch pan interaction.</span></span> <span data-ttu-id="89a85-121">このソース修飾子を使用すると、次の処理のためにデルタ位置を送信する前に、操作のデルタ位置を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-121">This source modifier allows you to modify the delta position of the interaction before sending it for further processing.</span></span> <span data-ttu-id="89a85-122">これは Vector3 型のパラメーターで、開発者は、パラメーターを InteractionTracker に渡す前に、位置の X、Y、Z 属性を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-122">This is a Vector3 type parameter and the developer can choose to modify any of the X or Y or Z attributes of the position before passing it to the InteractionTracker.</span></span>
- <span data-ttu-id="89a85-123">DeltaScale - 現在のフレーム スケールと、タッチによるズーム操作を行っているときに適用された前のフレーム スケールの間におけるデルタです。</span><span class="sxs-lookup"><span data-stu-id="89a85-123">DeltaScale - is the delta between the current frame scale and the previous frame scale that was applied during the touch zoom interaction.</span></span> <span data-ttu-id="89a85-124">このソース修飾子を使用すると、操作のズーム レベルを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-124">This source modifier allows you to modify the zooming level of the interaction.</span></span> <span data-ttu-id="89a85-125">これは浮動小数点型の属性で、開発者は、この属性を InteractionTracker に渡す前に変更することができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-125">This is a float type attribute that the developer can modify before passing it to the InteractionTracker.</span></span>

<span data-ttu-id="89a85-126">InteractionTracker が対話状態になっているとき、InteractionTracker では、割り当てられている各ソース修飾子を評価し、それらのいずれが適合するかを判別します。</span><span class="sxs-lookup"><span data-stu-id="89a85-126">When InteractionTracker is in its Interacting state, it evaluates each of the Source Modifiers assigned to it and determines if any of them apply.</span></span> <span data-ttu-id="89a85-127">つまり、1 つの InteractionTracker に対して複数のソース修飾子を作成し割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-127">This means you can create and assign multiple Source Modifiers to an InteractionTracker.</span></span> <span data-ttu-id="89a85-128">ただし、各ソース修飾子を定義するときは、次の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="89a85-128">But, when defining each, you need to do the following:</span></span>

1. <span data-ttu-id="89a85-129">条件の定義 – この特定のソース修飾子を適用するタイミングを指定する条件付きステートメントを定義する式を使用します。</span><span class="sxs-lookup"><span data-stu-id="89a85-129">Define the Condition – an Expression that defines the conditional statement when this specific Source Modifier should be applied.</span></span>
1. <span data-ttu-id="89a85-130">DeltaPosition/DeltaScale の定義 – 上で定義した条件を満足したときに DeltaPosition または DeltaScale を変更するソース修飾子の式を使用します。</span><span class="sxs-lookup"><span data-stu-id="89a85-130">Define the DeltaPosition/DeltaScale – The source modifier expression that alters the DeltaPosition or DeltaScale when the above defined condition is met.</span></span>

## <a name="example"></a><span data-ttu-id="89a85-131">例</span><span class="sxs-lookup"><span data-stu-id="89a85-131">Example</span></span>

<span data-ttu-id="89a85-132">次に、ソース修飾子を使用して、XAML の ListView コントロールを使ったカスタムの引っ張って更新エクスペリエンスを作成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="89a85-132">Now let’s look at how you can use Source Modifiers to create a custom pull-to-refresh experience with an existing XAML ListView Control.</span></span> <span data-ttu-id="89a85-133">ここではキャンバスを "更新パネル" として使用します。この更新パネルは XAML ListView 上に積み重なり、このエクスペリエンスを構築します。</span><span class="sxs-lookup"><span data-stu-id="89a85-133">We will be using a Canvas as the “Refresh Panel” that will be stacked on top of a XAML ListView to build this experience.</span></span>

<span data-ttu-id="89a85-134">エンド ユーザー エクスペリエンスのために、"抵抗" の効果を作成します。この効果は、ユーザーが (タッチ操作で) アクティブにリストをパンし、パンの位置が特定のポイントを越えた後でパンを停止する場合に適用されます。</span><span class="sxs-lookup"><span data-stu-id="89a85-134">For the end user experience, we want to create the effect of "resistance" as the user is actively panning the list (with touch) and stop panning after the position goes beyond a certain point.</span></span>

![引っ張って更新を使用するリスト](images/animation/city-list.gif)

<span data-ttu-id="89a85-136">このエクスペリエンスで動作するコードについては、「[Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs)」(GitHub の Windows UI 開発ラボ リポジトリ) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="89a85-136">The working code for this experience can be found in the [Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs).</span></span> <span data-ttu-id="89a85-137">このエクスペリエンスを作成するためのステップ バイ ステップのチュートリアルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="89a85-137">Here is the step-by-step walk through of building that experience.</span></span>
<span data-ttu-id="89a85-138">XAML マークアップ コードを、次のように構成します。</span><span class="sxs-lookup"><span data-stu-id="89a85-138">In your XAML markup code, you have the following:</span></span>

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

<span data-ttu-id="89a85-139">ListView (`ThumbnailList`) は既にスクロールされる XAML コントロールであるため、一番上の項目に到達し、それ以上スクロールできなくなったときに親の (`ContentPanel`) までチェーンされるスクロールが必要になります </span><span class="sxs-lookup"><span data-stu-id="89a85-139">Because the ListView (`ThumbnailList`) is a XAML control that already scrolls, you need the scrolling to be chained up to its parent (`ContentPanel`) when it reaches the topmost item and can’t scroll anymore.</span></span> <span data-ttu-id="89a85-140">(ContentPanel でソース修飾子を適用します)。そのためには、ListView マークアップで ScrollViewer.IsVerticalScrollChainingEnabled を **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="89a85-140">(ContentPanel is where you will apply the Source Modifiers.) For this to happen you need to set ScrollViewer.IsVerticalScrollChainingEnabled to **true** in the ListView markup.</span></span> <span data-ttu-id="89a85-141">また、VisualInteractionSource のチェーン モードを **Always** に設定する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="89a85-141">You will also need to set the chaining mode on the VisualInteractionSource to **Always**.</span></span>

<span data-ttu-id="89a85-142">_handledEventsToo_ パラメーターを使用して、PointerPressedEvent ハンドラーを **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="89a85-142">You need to set PointerPressedEvent handler with the _handledEventsToo_ parameter as **true**.</span></span> <span data-ttu-id="89a85-143">このオプションを使用しないと、PointerPressedEvent は ListView コントロールとして ContentPanel にチェーンされず、これらのイベントは処理済みとしてマークされ、これらのイベントはビジュアル チェーンに送信されなくなります。</span><span class="sxs-lookup"><span data-stu-id="89a85-143">Without this option, the PointerPressedEvent will not be chained to the ContentPanel as the ListView control will mark those events as handled and they will not be sent up the visual chain.</span></span>

```csharp
//The PointerPressed handler needs to be added using AddHandler method with the //handledEventsToo boolean set to "true"
//instead of the XAML element's "PointerPressed=Window_PointerPressed",
//because the list view needs to chain PointerPressed handled events as well.
ContentPanel.AddHandler(PointerPressedEvent, new PointerEventHandler( Window_PointerPressed), true);
```

<span data-ttu-id="89a85-144">これで、InteractionTracker に関連付ける準備ができました。</span><span class="sxs-lookup"><span data-stu-id="89a85-144">Now, you're ready to tie this with InteractionTracker.</span></span> <span data-ttu-id="89a85-145">まず、InteractionTracker、VisualInteractionSource、および InteractionTracker の位置を活用する式をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="89a85-145">Start by setting up InteractionTracker, the VisualInteractionSource and the Expression that will leverage the position of InteractionTracker.</span></span>

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

<span data-ttu-id="89a85-146">このセットアップでは、更新パネルはビューポートに収まっておらず、開始位置にあります。またユーザーに表示されるのは ListView です。パンが ContentPanel に到達すると、PointerPressed イベントが発生し、InteractionTracker を使用して操作エクスペリエンスを実行するようにシステムに要求します。</span><span class="sxs-lookup"><span data-stu-id="89a85-146">With this set up, the refresh panel is out of the viewport in its starting position and all the user sees is the listView When the panning reaches the ContentPanel, the PointerPressed event will be fired, where you ask the System to use InteractionTracker to drive the manipulation experience.</span></span>

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
> <span data-ttu-id="89a85-147">Handled イベントのチェーンが必要でない場合は、PointerPressedEvent ハンドラーの追加を、XAML マークアップで属性 (`PointerPressed="Window_PointerPressed"`) を使用することで直接実行できます。</span><span class="sxs-lookup"><span data-stu-id="89a85-147">If chaining Handled events is not needed, adding PointerPressedEvent handler can be done directly through XAML markup using the attribute (`PointerPressed="Window_PointerPressed"`).</span></span>

<span data-ttu-id="89a85-148">次の手順では、ソース修飾子をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="89a85-148">The next step is to set up the source modifiers.</span></span> <span data-ttu-id="89a85-149">このエクスペリエンスの動作を実現するために、2 つのソース修飾子 _Resistance_ と _Stop_ を使用します。</span><span class="sxs-lookup"><span data-stu-id="89a85-149">You will be using 2 source modifiers to get this behavior; _Resistance_ and _Stop_.</span></span>

- <span data-ttu-id="89a85-150">Resistance – DeltaPosition.Y を、RefreshPanel の高さに達するまで、半分の速度で移動します。</span><span class="sxs-lookup"><span data-stu-id="89a85-150">Resistance – Move the DeltaPosition.Y at half the speed until it reaches the height of the RefreshPanel.</span></span>

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

- <span data-ttu-id="89a85-151">Stop – RefreshPanel 全体が画面に表示されたら、動作を停止します。</span><span class="sxs-lookup"><span data-stu-id="89a85-151">Stop – Stop moving after the entire RefreshPanel is on the screen.</span></span>

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

<span data-ttu-id="89a85-152">次の図は、SourceModifier のセットアップを説明したものです。</span><span class="sxs-lookup"><span data-stu-id="89a85-152">This diagram gives a visualization of the SourceModifiers setup.</span></span>

![パンの図](images/animation/source-modifiers-diagram.png)

<span data-ttu-id="89a85-154">以上で、SourceModifier を使用して、ListView を下にパンしたときに一番上の項目に到達したことを認識できるようになります。更新パネルは、RefreshPanel の高さに到達するまでパンの半分の速度で引き下げられ、その後で動作が停止します。</span><span class="sxs-lookup"><span data-stu-id="89a85-154">Now with the SourceModifiers, you will notice when panning the ListView down and reach the topmost item, the refresh panel is pulled down at half the pace of the pan until it reaches the RefreshPanel height and then stops moving.</span></span>

<span data-ttu-id="89a85-155">完全なサンプルでは、KeyFrame アニメーションを使用して、RefreshPanel キャンバスで操作を行っているときにアイコンを回転させています。</span><span class="sxs-lookup"><span data-stu-id="89a85-155">In the full sample, a keyframe animation is used to spin an icon during interaction in the RefreshPanel canvas.</span></span> <span data-ttu-id="89a85-156">アニメーションを動作させる部分では任意のコンテンツを使用できます。また、InteractionTracker の位置を利用して、このアニメーションを個別に動作させることができます。</span><span class="sxs-lookup"><span data-stu-id="89a85-156">Any content can be used in its place or utilize InteractionTracker’s position to drive that animation separately.</span></span>
