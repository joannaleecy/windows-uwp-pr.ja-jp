---
title: 関係ベース アニメーション
description: 別のオブジェクトのプロパティに基づいくモーションを作成します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: b6fdc59e8a7203a3bb8c6ad79adabd446b884639
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8352426"
---
# <a name="relation-based-animations"></a><span data-ttu-id="2a0a4-104">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="2a0a4-104">Relation based animations</span></span>

<span data-ttu-id="2a0a4-105">この記事では、Composition の ExpressionAnimation を使用して関係ベース アニメーションを作成する方法の概要ついて説明します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-105">This article provides a brief overview of how to make relation-based animations using Composition ExpressionAnimations.</span></span>

## <a name="dynamic-relation-based-experiences"></a><span data-ttu-id="2a0a4-106">動的な関係ベースのエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="2a0a4-106">Dynamic Relation-based Experiences</span></span>

<span data-ttu-id="2a0a4-107">アプリのモーション エクスペリエンスを作成するとき、モーションが時間ベースではなく、他のオブジェクトのプロパティに影響される場合があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-107">When building out motion experiences in an app, there are times when the motion is not time-based, but rather dependent on a property on another object.</span></span> <span data-ttu-id="2a0a4-108">KeyFrameAnimations では、このような種類のモーション エクスペリエンスを簡単に表現することはできません。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-108">KeyFrameAnimations are not able to express these types of motion experiences very easily.</span></span> <span data-ttu-id="2a0a4-109">こうした場合、モーションを独立したものとして作成したり、事前に定義したりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-109">In these specific instances, motion no longer needs to be discrete and pre-defined.</span></span> <span data-ttu-id="2a0a4-110">代わりに、モーションと他のオブジェクトのプロパティとの関係に基づいて、モーションを動的に対応させることができます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-110">Instead, the motion can dynamically adapt based on its relationship to other object properties.</span></span> <span data-ttu-id="2a0a4-111">たとえば、水平方向の位置に基づいてオブジェクトの不透明度をアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-111">For example, you can animate the opacity of an object based on its horizontal position.</span></span> <span data-ttu-id="2a0a4-112">他の例としては、固定ヘッダーや視差などのモーション エクスペリエンスがあります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-112">Other examples include motion experiences like Sticky Headers and Parallax.</span></span>

<span data-ttu-id="2a0a4-113">これらの種類のモーション エクスペリエンスを使用すると、単一で独立して動作する UI ではなく、関連性の強い動作を示す UI を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-113">These types of motion experiences let you create UI that feels more connected, instead of feeling singular and independent.</span></span> <span data-ttu-id="2a0a4-114">ユーザーに対しては、動的な UI エクスペリエンスの印象を与えます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-114">To the user, this gives the impression of a dynamic UI experience.</span></span>

![軌道を回る円](images/animation/orbit.gif)

![視差を利用したリスト ビュー](images/animation/parallax.gif)

## <a name="using-expressionanimations"></a><span data-ttu-id="2a0a4-117">ExpressionAnimation の使用</span><span class="sxs-lookup"><span data-stu-id="2a0a4-117">Using ExpressionAnimations</span></span>

<span data-ttu-id="2a0a4-118">関係ベースのモーション エクスペリエンスを作成するには、ExpressionAnimation という種類のアニメーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-118">To create relation-based motion experiences, you use the ExpressionAnimation type.</span></span> <span data-ttu-id="2a0a4-119">ExpressionAnimation (短く示す場合は Expression) は新しい種類のアニメーションで、数学的な関係を表すことができます。数学的な関係とは、各フレームでアニメーション化するプロパティの値を計算する際にシステムで使用される関係です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-119">ExpressionAnimations (or Expressions for short), are a new type of animation that let you express a mathematical relationship – a relationship that the system uses to calculate the value of an animating property every frame.</span></span> <span data-ttu-id="2a0a4-120">言い換えれば、Expression は、各フレームでアニメーション化するプロパティの目的の値を定義する単純な方程式です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-120">Put another way, Expressions are simply a mathematical equation that defines the desired value of an animating property per frame.</span></span> <span data-ttu-id="2a0a4-121">Expression は用途の広いコンポーネントで、次のようなさまざまなシナリオで使用できます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-121">Expressions are a very versatile component that can be used across a wide variety of scenarios, including:</span></span>

- <span data-ttu-id="2a0a4-122">相対サイズ、オフセット アニメーション。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-122">Relative Size, Offset animations.</span></span>
- <span data-ttu-id="2a0a4-123">ScrollViewer を使用した固定ヘッダーや視差 </span><span class="sxs-lookup"><span data-stu-id="2a0a4-123">Sticky Headers, Parallax with ScrollViewer.</span></span> <span data-ttu-id="2a0a4-124">(「[既存の ScrollViewer エクスペリエンスを強化する](scroll-input-animations.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-124">(See [Enhance existing ScrollViewer experiences](scroll-input-animations.md).)</span></span>
- <span data-ttu-id="2a0a4-125">InertiaModifier と InteractionTracker を使用したスナップ位置 </span><span class="sxs-lookup"><span data-stu-id="2a0a4-125">Snap Points with InertiaModifiers and InteractionTracker.</span></span> <span data-ttu-id="2a0a4-126">(「[慣性修飾子を使用したスナップ位置の作成](inertia-modifiers.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-126">(See [Create snap points with inertia modifiers](inertia-modifiers.md).)</span></span>

<span data-ttu-id="2a0a4-127">ExpressionAnimation を使用するときは、以下の点について留意してください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-127">When working with ExpressionAnimations, there are a couple of things worth mentioning up front:</span></span>

- <span data-ttu-id="2a0a4-128">終了しない – KeyFrameAnimation とは異なり、Expression には限定された継続時間はありません。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-128">Never Ending – unlike its KeyFrameAnimation sibling, Expressions don’t have a finite duration.</span></span> <span data-ttu-id="2a0a4-129">Expression は数学的な関係であるため、継続して "実行されている" アニメーションとなります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-129">Because Expressions are mathematical relationships, they are animations that are constantly "running".</span></span> <span data-ttu-id="2a0a4-130">必要な場合は、こうしたアニメーションを停止するオプションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-130">You have the option to stop these animations if you choose.</span></span>
- <span data-ttu-id="2a0a4-131">継続して実行されているが、常に評価されるわけではない – パフォーマンスは、継続して実行されているアニメーションと常に関連する懸念事項です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-131">Running, but not always evaluating – performance is always a concern with animations that are constantly running.</span></span> <span data-ttu-id="2a0a4-132">ただし、心配する必要はありません。Expression はいずれかの入力またはパラメーターが変更された場合にのみ再評価されるということを、システムでは自動的に把握するためです。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-132">No need to worry though, the system is smart enough that the Expression will only re-evaluate if any of its inputs or parameters have changed.</span></span>
- <span data-ttu-id="2a0a4-133">適切なオブジェクトの種類への解決 – Expression は数学的な関係であるため、Expression ではアニメーションのターゲットとなるプロパティと同じ種類のプロパティへの解決が行われることを式で定義することが重要となります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-133">Resolving to the right object type – Because Expressions are mathematical relationships, it is important to make sure that the equation that defines the Expression resolves to the same type of the property being targeted by the animation.</span></span> <span data-ttu-id="2a0a4-134">たとえば、オフセットをアニメーション化する場合、Expression では Vector3 の種類に解決する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-134">For example, if animating Offset, your Expression should resolve to a Vector3 type.</span></span>

### <a name="components-of-an-expression"></a><span data-ttu-id="2a0a4-135">Expression のコンポーネント</span><span class="sxs-lookup"><span data-stu-id="2a0a4-135">Components of an Expression</span></span>

<span data-ttu-id="2a0a4-136">Expression の数学的な関係を構築する際に利用できる主なコンポーネントには、以下のものがあります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-136">When building the mathematical relationship of an Expression, there are several core components:</span></span>

- <span data-ttu-id="2a0a4-137">パラメーター – 定数値または他のコンポジション オブジェクトへの参照を表す値です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-137">Parameters – values representing constant values or references to other Composition objects.</span></span>
- <span data-ttu-id="2a0a4-138">数学演算子 – 式を構成するためにパラメーターを結合する一般的な数学演算子 (加算 (+)、減算 (-)、乗算 (\*)、除算 (/)) です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-138">Mathematical Operators – the typical mathematical operators plus(+), minus(-), multiply(\*), divide(/) that join together parameters to form an equation.</span></span> <span data-ttu-id="2a0a4-139">条件演算子 (より大きい (>)、等しい (==) など) や、三項演算子 (condition ? </span><span class="sxs-lookup"><span data-stu-id="2a0a4-139">Also included are conditional operators such as greater than(>), equal(==), ternary operator (condition ?</span></span> <span data-ttu-id="2a0a4-140">ifTrue : ifFalse) なども含まれます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-140">ifTrue : ifFalse), etc.</span></span>
- <span data-ttu-id="2a0a4-141">数学関数 – System.Numerics に基づく数学関数/数学ショートカットです。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-141">Mathematical Functions – mathematical functions/shortcuts based on System.Numerics.</span></span> <span data-ttu-id="2a0a4-142">サポートされる関数の完全な一覧については、「[ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-142">For a full list of supported functions, see [ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation).</span></span>

<span data-ttu-id="2a0a4-143">Expression では一連のキーワードもサポートされています。キーワードとは、ExpressionAnimation システム内でのみ使われる独自の意味を持つ特別な語句です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-143">Expressions also support a set of keywords – special phrases that have distinct meaning only within the ExpressionAnimation system.</span></span> <span data-ttu-id="2a0a4-144">これらのキーワードの一覧 (および数学関数の完全な一覧) については、「[ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation)」の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-144">These are listed (along with the full list of math functions) in the [ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation) documentation.</span></span>

### <a name="creating-expressions-with-expressionbuilder"></a><span data-ttu-id="2a0a4-145">ExpressionBuilder を使用して Expression を作成する</span><span class="sxs-lookup"><span data-stu-id="2a0a4-145">Creating Expressions with ExpressionBuilder</span></span>

<span data-ttu-id="2a0a4-146">UWP アプリで Expression を作成するには、2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-146">There are two options for building Expressions in their UWP app:</span></span>

1. <span data-ttu-id="2a0a4-147">公式のパブリック API を使用し、文字列として式を作成する。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-147">Building the equation as a string via the official, public API.</span></span>
1. <span data-ttu-id="2a0a4-148">オープンソースの ExpressionBuilder ツールを使用し、タイプ セーフなオブジェクト モデルで式を作成する。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-148">Building the equation in a type-safe object model via the open source ExpressionBuilder tool.</span></span> <span data-ttu-id="2a0a4-149">[Github のソースとドキュメント](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/ExpressionBuilder)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-149">See the [Github source and documentation](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/ExpressionBuilder).</span></span>

<span data-ttu-id="2a0a4-150">このドキュメントのために、ここでは ExpressionBuilder を使用して Expression を定義します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-150">For the sake of this document, we will define our Expressions using ExpressionBuilder.</span></span>

### <a name="parameters"></a><span data-ttu-id="2a0a4-151">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2a0a4-151">Parameters</span></span>

<span data-ttu-id="2a0a4-152">パラメーターは、Expression の重要な部分を構成します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-152">Parameters make up the core of an Expression.</span></span> <span data-ttu-id="2a0a4-153">パラメーターには次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-153">There are two types of parameters:</span></span>

- <span data-ttu-id="2a0a4-154">定数: 型指定された System.Numeric 変数を表すパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-154">Constants: these are parameters representing typed System.Numeric variables.</span></span> <span data-ttu-id="2a0a4-155">これらのパラメーターは、アニメーションが開始されたときに割り当てられる値を取得します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-155">These parameters get their values assigned once when the animation is started.</span></span>
- <span data-ttu-id="2a0a4-156">参照: CompositionObject への参照を表すパラメーターです。これらのパラメーターは、アニメーションが開始された後で更新された値を継続的に取得します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-156">References: these are parameters representing references to CompositionObjects – these parameters continuously get their values updated after an animation is started.</span></span>

<span data-ttu-id="2a0a4-157">一般的に参照は、Expression の出力が動的に変更される方法に関連する主要な側面となります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-157">In general, References are the main aspect for how an Expression’s output can dynamically change.</span></span> <span data-ttu-id="2a0a4-158">参照が変更されると、その結果に伴って Expression の出力も変更されます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-158">As these references change, the output of the Expression changes as a result.</span></span> <span data-ttu-id="2a0a4-159">String を使用して Expression を作成する場合、またはテンプレートのシナリオで String を使用する場合 (複数の CompositionObject をターゲットとする Expression を使用)、パラメーターの名前を指定し、その値を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-159">If you create your Expression with Strings or use them in a templating scenario (using your Expression to target multiple CompositionObjects), you will need to name and set the values of your parameters.</span></span> <span data-ttu-id="2a0a4-160">詳しくは、「例」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-160">See the Example section for more info.</span></span>

### <a name="working-with-keyframeanimations"></a><span data-ttu-id="2a0a4-161">KeyFrameAnimation の操作</span><span class="sxs-lookup"><span data-stu-id="2a0a4-161">Working with KeyFrameAnimations</span></span>

<span data-ttu-id="2a0a4-162">Expression は、KeyFrameAnimation と共にも使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-162">Expressions can also be used with KeyFrameAnimations.</span></span> <span data-ttu-id="2a0a4-163">このような場合、ある時点での KeyFrame の値を定義する Expression を使用する必要があります。このような種類の KeyFrame は、ExpressionKeyFrame と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-163">In these instances, you want to use an Expression to define the value of a KeyFrame at a time spot – these types KeyFrames are called ExpressionKeyFrames.</span></span>

```csharp
KeyFrameAnimation.InsertExpressionKeyFrame(Single, String)
KeyFrameAnimation.InsertExpressionKeyFrame(Single, ExpressionNode)
```

<span data-ttu-id="2a0a4-164">ただし ExpressionAnimation とは異なり、ExpressionKeyFrame は KeyFrameAnimation の起動時に 1 回だけ評価されます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-164">However, unlike ExpressionAnimations, ExpressionKeyFrames are evaluated only once when the KeyFrameAnimation is started.</span></span> <span data-ttu-id="2a0a4-165">ExpressionAnimation を KeyFrame の値として渡すのではなく、文字列 (または ExpressionBuilder を使用している場合は ExpressionNode) として渡すという点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-165">Keep in mind, you do not pass in an ExpressionAnimation as the value of the KeyFrame, rather a string (or an ExpressionNode, if you're using ExpressionBuilder).</span></span>

## <a name="example"></a><span data-ttu-id="2a0a4-166">例</span><span class="sxs-lookup"><span data-stu-id="2a0a4-166">Example</span></span>

<span data-ttu-id="2a0a4-167">Expression を使用した例を確認してみましょう。具体的には、Windows UI サンプル ギャラリーの PropertySet の例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-167">Let's now walk through an example of using Expressions, specifically the PropertySet sample from the Windows UI Sample Gallery.</span></span> <span data-ttu-id="2a0a4-168">ここでは、軌道を回る青い円のモーションの動作を管理する Expression について説明します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-168">We'll look at the Expression managing the orbit motion behavior of the blue ball.</span></span>

![軌道を回る円](images/animation/orbit.gif)

<span data-ttu-id="2a0a4-170">エクスペリエンス全体では、3 つのコンポーネントが使用されています。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-170">There are three components at play for the total experience:</span></span>

1. <span data-ttu-id="2a0a4-171">KeyFrameAnimation。赤い円の Y オフセットをアニメーション化しています。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-171">A KeyFrameAnimation, animating the Y Offset of the red ball.</span></span>
1. <span data-ttu-id="2a0a4-172">軌道の周回を駆動する際に利用される **Rotation** プロパティを含んでいる PropertySet。他の KeyFrameAnimation によってアニメーション化されます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-172">A PropertySet with a **Rotation** property that helps drives the orbit, animated by another KeyFrameAnimation.</span></span>
1. <span data-ttu-id="2a0a4-173">青い円のオフセットを駆動する ExpressionAnimation。赤い円のオフセットと Rotation プロパティを参照して、完全な軌道の周回を維持します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-173">An ExpressionAnimation that drives the Offset of the blue ball referencing the Red Ball Offset and the Rotation property to maintain a perfect orbit.</span></span>

<span data-ttu-id="2a0a4-174">3. で定義されている ExpressionAnimation に注目します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-174">We’ll be focusing on the ExpressionAnimation defined in #3.</span></span> <span data-ttu-id="2a0a4-175">また、ExpressionBuilder クラスも使用した、この Expression の作成も行います。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-175">We will also be using the ExpressionBuilder classes to construct this Expression.</span></span> <span data-ttu-id="2a0a4-176">String を使用してこのエクスペリエンスを作成するためのコードのコピーが、最後に記載されています。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-176">A copy of the code used to build this experience via Strings is listed at the end.</span></span>

<span data-ttu-id="2a0a4-177">この式では、PropertySet から参照する必要がある 2 つのプロパティが使用されています。1 つは中心点のオフセット、もう 1 つは回転です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-177">In this equation, there are two properties you need to reference from the PropertySet; one is a centerpoint offset and the other is the rotation.</span></span>

```
var propSetCenterPoint =
_propertySet.GetReference().GetVector3Property("CenterPointOffset");

// This rotation value will animate via KFA from 0 -> 360 degrees
var propSetRotation = _propertySet.GetReference().GetScalarProperty("Rotation");
```

<span data-ttu-id="2a0a4-178">次に、実際の起動の周回を構成する Vector3 コンポーネントを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-178">Next, you need to define the Vector3 component that accounts for the actual orbiting rotation.</span></span>

```
var orbitRotation = EF.Vector3(
    EF.Cos(EF.ToRadians(propSetRotation)) * 150,
    EF.Sin(EF.ToRadians(propSetRotation)) * 75, 0);
```

> [!NOTE]
> `EF` <span data-ttu-id="2a0a4-179">は、ExpressionBuilder.ExpressionFunctions を定義する “using” 表記の短縮形です。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-179">is a shorthand “using” notation to define ExpressionBuilder.ExpressionFunctions.</span></span>

<span data-ttu-id="2a0a4-180">最後に、これらのコンポーネントを一緒に組み合わせ、赤い円の位置を参照して、数学的な関係を定義します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-180">Finally, combine these components together and reference the position of the Red Ball to define the mathematical relationship.</span></span>

```
var orbitExpression = redSprite.GetReference().Offset + propSetCenterPoint + orbitRotation;
blueSprite.StartAnimation("Offset", orbitExpression);
```

<span data-ttu-id="2a0a4-181">これと同じ Expression を使用するが、2 つの他の Visual (軌道を回る円の 2 つのセット) を使うと仮定した場合は、どうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-181">In a hypothetical situation, what if you wanted to use this same Expression but with two other Visuals, meaning 2 sets of orbiting circles.</span></span> <span data-ttu-id="2a0a4-182">CompositionAnimation を使用すると、アニメーションを再利用し、複数の CompositionObject をターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-182">With CompositionAnimations, you can re-use the animation and target multiple CompositionObjects.</span></span> <span data-ttu-id="2a0a4-183">この Expression を使用して軌道周回のケースを追加する場合、変更する必要があるのは、Visual への参照だけです。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-183">The only thing you need to change when you use this Expression for the additional orbit case is the reference to the Visual.</span></span> <span data-ttu-id="2a0a4-184">これをテンプレート化と呼びます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-184">We call this templating.</span></span>

<span data-ttu-id="2a0a4-185">この場合、前に作成した Expression を変更します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-185">In this case, you modify the Expression you built earlier.</span></span> <span data-ttu-id="2a0a4-186">CompositionObject への参照を "取得" するのではなく、名前を指定して参照を作成し、異なる値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-186">Rather than "getting" a reference to the CompositionObject, you create a reference with a name and then assign different values:</span></span>

```
var orbitExpression = ExpressionValues.Reference.CreateVisualReference("orbitRoundVisual");
orbitExpression.SetReferenceParameter("orbitRoundVisual", redSprite);
blueSprite.StartAnimation("Offset", orbitExpression);
// Later on … use same Expression to assign to another orbiting Visual
orbitExpression.SetReferenceParameter("orbitRoundVisual", yellowSprite);
greenSprite.StartAnimation("Offset", orbitExpression);
```

<span data-ttu-id="2a0a4-187">パブリック API 経由で String を使用して Expression を定義する場合のコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="2a0a4-187">Here is the code if you defined your Expression with Strings via the public API.</span></span>

```
ExpressionAnimation expressionAnimation =
compositor.CreateExpressionAnimation("visual.Offset + " +
"propertySet.CenterPointOffset + " +
"Vector3(cos(ToRadians(propertySet.Rotation)) * 150," + "sin(ToRadians(propertySet.Rotation)) * 75, 0)");
 var propSetCenterPoint = _propertySet.GetReference().GetVector3Property("CenterPointOffset");
 var propSetRotation = _propertySet.GetReference().GetScalarProperty("Rotation");
expressionAnimation.SetReferenceParameter("propertySet", _propertySet);
expressionAnimation.SetReferenceParameter("visual", redSprite);
```
