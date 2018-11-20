---
author: jwmsft
title: ポインター ベース アニメーション
description: ポインターの位置を使用して、動的な "カーソル追跡" エクスペリエンスを作成する方法ついて説明します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: b69899761e1c4a139fd2b15d6810440df5192487
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7294658"
---
# <a name="pointer-based-animations"></a><span data-ttu-id="3e006-104">ポインター ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="3e006-104">Pointer-based animations</span></span>

<span data-ttu-id="3e006-105">この記事では、ポインターの位置を使用して、動的な "カーソル追跡" エクスペリエンスを作成する方法ついて説明します。</span><span class="sxs-lookup"><span data-stu-id="3e006-105">This article shows how to use the position of a pointer to create dynamic "stick to the cursor" experiences.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3e006-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="3e006-106">Prerequisites</span></span>

<span data-ttu-id="3e006-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="3e006-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="3e006-108">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="3e006-108">Input-driven animations</span></span>](input-driven-animations.md)
- [<span data-ttu-id="3e006-109">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="3e006-109">Relation based animations</span></span>](relation-animations.md)

## <a name="why-create-pointer-position-driven-experiences"></a><span data-ttu-id="3e006-110">ポインターの位置で駆動するエクスペリエンスを作成する理由</span><span class="sxs-lookup"><span data-stu-id="3e006-110">Why Create Pointer Position-Driven Experiences?</span></span>

<span data-ttu-id="3e006-111">Fluent Design 言語では、UI とやり取りする方法はタッチ操作だけではありません。</span><span class="sxs-lookup"><span data-stu-id="3e006-111">In the Fluent design language, touch is not the only way to interact with UI.</span></span> <span data-ttu-id="3e006-112">UWP では複数のデバイス フォーム ファクターを対象としているため、エンド ユーザーは、マウスやペンなど、他の入力方式を使用してアプリとやり取りする場合もあります。</span><span class="sxs-lookup"><span data-stu-id="3e006-112">Because UWP spans across multiple device form factors, end users interact with apps with other input modalities such as Mouse and Pen.</span></span> <span data-ttu-id="3e006-113">こうしたその他の入力方式から取得される位置データを利用することで、アプリに対するエンド ユーザーの使用率を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="3e006-113">Using position data from these other input modalities provides an opportunity to make end users feel even more connected with your app.</span></span>

<span data-ttu-id="3e006-114">ポインターの位置で駆動するエクスペリエンスによって、ポインター入力方式での画面上の位置を活用して、アプリに対して追加のモーションや UI エクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="3e006-114">Pointer position-driven experiences let you leverage the on-screen position of a Pointer input modality to create additional motion and UI experiences for your app.</span></span> <span data-ttu-id="3e006-115">多くの場合、こうしたエクスペリエンスでは、UI の動作と構造に関する追加のコンテキストやフィードバックが、エンド ユーザーに提供されます。</span><span class="sxs-lookup"><span data-stu-id="3e006-115">These experiences often can provide additional context and feedback to end users about the behavior and structure of the UI.</span></span> <span data-ttu-id="3e006-116">現在ではエクスペリエンスは一方向のストリームではなく、双方向のストリームになりつつあります。双方向のストリームとは、エンド ユーザーが入力方式に基づいて入力を提供し、アプリの UI はその入力に応答するといったストリームです。</span><span class="sxs-lookup"><span data-stu-id="3e006-116">The experience is no longer a one-way stream, but rather starts to become a two-way stream where the end user provides input with their input modality and the app UI can respond back.</span></span>

<span data-ttu-id="3e006-117">次のような例があります。</span><span class="sxs-lookup"><span data-stu-id="3e006-117">Some examples include:</span></span>

- <span data-ttu-id="3e006-118">カーソルを追うようにスポットライトの位置をアニメーション化する</span><span class="sxs-lookup"><span data-stu-id="3e006-118">Animating the position of a Spotlight to follow the cursor</span></span>

    ![ポインター スポットライトの例](images/animation/spotlight-reveal.gif)

- <span data-ttu-id="3e006-120">ポインターの位置に基づいて画像を回転させる</span><span class="sxs-lookup"><span data-stu-id="3e006-120">Rotating an image based on the position of a pointer</span></span>

    ![ポインターに基づく回転の例](images/animation/pointer-rotate.gif)

## <a name="using-pointerpositionpropertyset"></a><span data-ttu-id="3e006-122">PointerPositionPropertySet の使用</span><span class="sxs-lookup"><span data-stu-id="3e006-122">Using PointerPositionPropertySet</span></span>

<span data-ttu-id="3e006-123">このようなエクスペリエンスは、PointerPositionPropertySet を使用して作成することができます。</span><span class="sxs-lookup"><span data-stu-id="3e006-123">You can create these experiences by using the PointerPositionPropertySet.</span></span> <span data-ttu-id="3e006-124">この PropertySet が作成されると、UIElement は、UIElement のヒット テストが適切に行われているときにポインターの位置を保持することができます。</span><span class="sxs-lookup"><span data-stu-id="3e006-124">This PropertySet gets created for a UIElement to maintain the position of the pointer while the UIElement is positively hit-tested.</span></span> <span data-ttu-id="3e006-125">位置の値は、UIElement の座標空間を基準とした相対的な値です (位置 <0,0> は UIElement の左上隅を表します)。</span><span class="sxs-lookup"><span data-stu-id="3e006-125">The position value is relative to the coordinate space of the UIElement (a position of <0,0> is the top left corner of the UIElement).</span></span> <span data-ttu-id="3e006-126">このエクスペリエンスが作成されると、このプロパティをアニメーションで利用して、別のプロパティのモーションを駆動することができます。</span><span class="sxs-lookup"><span data-stu-id="3e006-126">You can then leverage this property set in an Animation to drive the motion of another property.</span></span>

<span data-ttu-id="3e006-127">それぞれのポインター入力方式には、入力時の位置の変化 (ホバー、押下、押下して移動) に応じてさまざまな入力状態があります。</span><span class="sxs-lookup"><span data-stu-id="3e006-127">For each of the different Pointer Input Modalities, there are a number of input states the input could be in where the position changes: Hover, Pressed, Pressed & Moved.</span></span> <span data-ttu-id="3e006-128">PointerPositionPropertySet では、マウスやペンで "ホバー"、"押下"、"押下して移動" の状態になっているポインターの位置のみを保持します。</span><span class="sxs-lookup"><span data-stu-id="3e006-128">The PointerPositionPropertySet only maintains the position of the pointer in the Hover, Pressed and Pressed and Moved states for Moues and Pen.</span></span>

<span data-ttu-id="3e006-129">作業を始める際の一般的な手順:</span><span class="sxs-lookup"><span data-stu-id="3e006-129">General steps to get started:</span></span>

1. <span data-ttu-id="3e006-130">追跡するポインターの位置を保持する UIElement を指定します。</span><span class="sxs-lookup"><span data-stu-id="3e006-130">Identify the UIElement, you wish to have the position of the pointer tracked in.</span></span>
1. <span data-ttu-id="3e006-131">ElementCompositionPreview を使用して PointerPositionPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="3e006-131">Access the PointerPositionPropertySet via ElementCompositionPreview.</span></span>
    - <span data-ttu-id="3e006-132">UIElement を ElementCompositionPreview.GetPointerPositionPropertySet メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="3e006-132">Pass UIElement into the ElementCompositionPreview.GetPointerPositionPropertySet method.</span></span>
1. <span data-ttu-id="3e006-133">PropertySet の Position プロパティを参照する ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="3e006-133">Create an ExpressionAnimation that references the Position property in the PropertySet.</span></span>
    - <span data-ttu-id="3e006-134">参照パラメーターは必ず設定してください。</span><span class="sxs-lookup"><span data-stu-id="3e006-134">Don’t forget to set your reference parameter!</span></span>
1. <span data-ttu-id="3e006-135">ExpressionAnimation を使用して CompositionObject のプロパティをターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="3e006-135">Target a CompositionObject’s property with the ExpressionAnimation.</span></span>

> [!NOTE]
> <span data-ttu-id="3e006-136">GetPointerPositionPropertySet メソッドから返された PropertySet をクラス変数に割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3e006-136">It is recommended that you assign the PropertySet returned from the GetPointerPositionPropertySet method to a class variable.</span></span> <span data-ttu-id="3e006-137">これにより、プロパティ セットがガベージ コレクションによってクリーンアップされなくなります。そのため、参照されている ExpressionAnimation は影響を受けません。</span><span class="sxs-lookup"><span data-stu-id="3e006-137">This ensures that the property set does not get cleaned up by Garbage Collection and thus does not have any effect on the ExpressionAnimation it is referenced in.</span></span> <span data-ttu-id="3e006-138">ExpressionAnimations は、式で使用されているどのオブジェクトに対しても強参照を保持しません。</span><span class="sxs-lookup"><span data-stu-id="3e006-138">ExpressionAnimations do not maintain a strong reference to any of the objects used in the equation.</span></span>

## <a name="example"></a><span data-ttu-id="3e006-139">例</span><span class="sxs-lookup"><span data-stu-id="3e006-139">Example</span></span>

<span data-ttu-id="3e006-140">マウスとペンの入力方式におけるホバーの位置を利用して、画像を動的に回転させる例を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="3e006-140">Let’s take a look at an example where we leverage the Hover position of a Mouse and Pen input modality to dynamically rotate an image.</span></span>

![ポインターに基づく回転の例](images/animation/pointer-rotate.gif)

<span data-ttu-id="3e006-142">画像は UIElement です。最初に、PointerPositionPropertySet への参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="3e006-142">The image is a UIElement, so let’s first get a reference to the PointerPositionPropertySet</span></span>

```csharp
_pointerPositionPropSet = ElementCompositionPreview.GetPointerPositionPropertySet(UIElement element);
```

<span data-ttu-id="3e006-143">この例では、2 つの式を使用します。</span><span class="sxs-lookup"><span data-stu-id="3e006-143">In this sample, you have two Expressions at play:</span></span>

- <span data-ttu-id="3e006-144">画像の中心から離れた位置にあるポインターに基づいて画像を回転させる式。</span><span class="sxs-lookup"><span data-stu-id="3e006-144">An Expression where the image rotates based on far the pointer is from the center of the image.</span></span> <span data-ttu-id="3e006-145">中心から離れるに従って、回転が大きくなります。</span><span class="sxs-lookup"><span data-stu-id="3e006-145">The further away, the more rotation.</span></span>
- <span data-ttu-id="3e006-146">ポインターの位置に基づいて回転軸を変化させる式。</span><span class="sxs-lookup"><span data-stu-id="3e006-146">An Expression where the rotation axis changes based on the position of the pointer.</span></span> <span data-ttu-id="3e006-147">位置のベクトル対して垂直となる回転軸が必要です。</span><span class="sxs-lookup"><span data-stu-id="3e006-147">You want the rotation axis to be perpendicular to the vector of the position.</span></span>

<span data-ttu-id="3e006-148">2 つの式を定義してみましょう。1 つは RotationAngle プロパティをターゲットにし、もう 1 つは RotationAxis プロパティをターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="3e006-148">Let’s define the two Expressions, one that targets the RotationAngle property and the other the RotationAxis property.</span></span> <span data-ttu-id="3e006-149">他の PropertySet と同様に、PointerPositionPropertySet を参照します。</span><span class="sxs-lookup"><span data-stu-id="3e006-149">You reference the PointerPositionPropertySet like any other PropertySet.</span></span>

<span data-ttu-id="3e006-150">この例では、ExpressionBuilder クラスを使用して式を作成します。</span><span class="sxs-lookup"><span data-stu-id="3e006-150">In this example, you are building Expressions using the ExpressionBuilder classes.</span></span>

```csharp
// || DEFINE THE EXPRESSION FOR THE ROTATION ANGLE ||
var hoverPosition = _pointerPositionPropSet.GetSpecializedReference
<PointerPositionPropertySetReferenceNode>().Position;
var angleExpressionNode =
EF.Conditional(
 hoverPosition == new Vector3(0, 0, 0),
 ExpressionValues.CurrentValue.CreateScalarCurrentValue(),
 35 * ((EF.Clamp(EF.Distance(center, hoverPosition), 0, distanceToCenter) % distanceToCenter) / distanceToCenter));
_tiltVisual.StartAnimation("RotationAngleInDegrees", angleExpressionNode);

// || DEFINE THE EXPRESSION FOR THE ROTATION AXIS ||
var axisAngleExpressionNode = EF.Vector3(
-(hoverPosition.Y - center.Y) * EF.Conditional(hoverPosition.Y == center.Y, 0, 1),
 (hoverPosition.X - center.X) * EF.Conditional(hoverPosition.X == center.X, 0, 1),
 0);
_tiltVisual.StartAnimation("RotationAxis", axisAngleExpressionNode);
```