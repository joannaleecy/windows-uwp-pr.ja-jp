---
Description: このトピックでは、回転の新しい Windows UI を説明し、UWP アプリでこの新しい相互作用のメカニズムの使用時に考慮すべきユーザー エクスペリエンス ガイドラインを示します。
title: 回転
ms.assetid: f098bc05-35b3-46b2-9e9b-9ff292d067ca
label: Rotation
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: f631f3178b4af4fe1c1d2d8b27e8ae6ac25c6ad1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617207"
---
# <a name="rotation"></a><span data-ttu-id="3d50c-104">回転</span><span class="sxs-lookup"><span data-stu-id="3d50c-104">Rotation</span></span>


<span data-ttu-id="3d50c-105">この記事では、新しい Windows UI の回転について説明し、UWP アプリでこの新しい操作のメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-105">This article describes the new Windows UI for rotation and provides user experience guidelines that should be considered when using this new interaction mechanism in your UWP app.</span></span>

> <span data-ttu-id="3d50c-106">**重要な API**:[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、 [ **Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="3d50c-106">**Important APIs**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="3d50c-107">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="3d50c-107">Dos and don'ts</span></span>

-   <span data-ttu-id="3d50c-108">ユーザーが直接 UI 要素を回転できるように回転を使います。</span><span class="sxs-lookup"><span data-stu-id="3d50c-108">Use rotation to help users directly rotate UI elements.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="3d50c-109">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="3d50c-109">Additional usage guidance</span></span>


<span data-ttu-id="3d50c-110">**回転の概要**</span><span class="sxs-lookup"><span data-stu-id="3d50c-110">**Overview of rotation**</span></span>

<span data-ttu-id="3d50c-111">回転は UWP アプリで使われるタッチ操作に最適な手法であり、ユーザーがオブジェクトを回転 (時計回りまたは反時計回り) できるようにします。</span><span class="sxs-lookup"><span data-stu-id="3d50c-111">Rotation is the touch-optimized technique used by UWP apps to enable users to turn an object in a circular direction (clockwise or counter-clockwise).</span></span>

<span data-ttu-id="3d50c-112">入力デバイスに応じて回転操作は次のように実行されます。</span><span class="sxs-lookup"><span data-stu-id="3d50c-112">Depending on the input device, the rotation interaction is performed using:</span></span>

-   <span data-ttu-id="3d50c-113">マウスまたはアクティブなペン/スタイラスを使って、選んだオブジェクトの回転グリッパーを移動する。</span><span class="sxs-lookup"><span data-stu-id="3d50c-113">A mouse or active pen/stylus to move the rotation gripper of a selected object.</span></span>
-   <span data-ttu-id="3d50c-114">タッチまたはパッシブなペン/スタイラスを使って、回転ジェスチャによって任意の方向にオブジェクトを回転させる。</span><span class="sxs-lookup"><span data-stu-id="3d50c-114">Touch or passive pen/stylus to turn the object in the desired direction using the rotate gesture.</span></span>

<span data-ttu-id="3d50c-115">**回転を使用する場合**</span><span class="sxs-lookup"><span data-stu-id="3d50c-115">**When to use rotation**</span></span>

<span data-ttu-id="3d50c-116">ユーザーが直接 UI 要素を回転できるように回転を使います。</span><span class="sxs-lookup"><span data-stu-id="3d50c-116">Use rotation to help users directly rotate UI elements.</span></span> <span data-ttu-id="3d50c-117">次の図は、サポートされる回転操作の指の配置をいくつか示しています。</span><span class="sxs-lookup"><span data-stu-id="3d50c-117">The following diagrams show some of the supported finger positions for the rotation interaction.</span></span>

![回転がサポートされる異なる指の配置を示す図](images/ux-rotate-positions.png)

<span data-ttu-id="3d50c-119">**注**  ユーザーが (たとえば、描画またはレイアウトのアプリケーション) に接続ポイントとは無関係な回転ポイントを指定しない限りは直感的とでほとんどの場合、回転ポイントは、2 つのタッチ ポイントの 1 つです。</span><span class="sxs-lookup"><span data-stu-id="3d50c-119">**Note**   Intuitively, and in most cases, the rotation point is one of the two touch points unless the user can specify a rotation point unrelated to the contact points (for example, in a drawing or layout application).</span></span> <span data-ttu-id="3d50c-120">以下の図では、回転の中心点がこのような制約を受けない場合に、どのようにユーザー エクスペリエンスが低下するかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-120">The following images demonstrate how the user experience can be degraded if the rotation point is not constrained in this way.</span></span>

<span data-ttu-id="3d50c-121">1 番目の図は、最初のタッチ ポイント (親指) と 2 番目のタッチ ポイント (人差し指) を示します。人差し指は木に、親指は丸太にタッチしています。</span><span class="sxs-lookup"><span data-stu-id="3d50c-121">This first picture shows the initial (thumb) and secondary (index finger) touch points: the index finger is touching a tree and the thumb is touching a log.</span></span>

<span data-ttu-id="3d50c-122">![イメージの回転のジェスチャの 2 つの初期のタッチ ポイントを表示します。](images/ux-rotate-points1.png)</span><span class="sxs-lookup"><span data-stu-id="3d50c-122">![image showing the two initial touch points for the rotation gesture.](images/ux-rotate-points1.png)</span></span>
<span data-ttu-id="3d50c-123">2 番目の図では、最初のタッチ ポイント (親指) の周りで回転が行われています。</span><span class="sxs-lookup"><span data-stu-id="3d50c-123">In this second picture, rotation is performed around the initial (thumb) touch point.</span></span> <span data-ttu-id="3d50c-124">回転の後で、人差し指は相変わらず木の幹にタッチし、親指は相変わらず丸太 (回転の中心点) にタッチしています。</span><span class="sxs-lookup"><span data-stu-id="3d50c-124">After the rotation, the index finger is still touching the tree trunk and the thumb is still touching the log (the rotation point).</span></span>

<span data-ttu-id="3d50c-125">![回転ポイントで回転した画像を表示するイメージは、2 つの初期のタッチ ポイントの 1 つに制限されます。](images/ux-rotate-points2.png)</span><span class="sxs-lookup"><span data-stu-id="3d50c-125">![image showing a rotated picture with the rotation point constrained to one of the two initial touch points.](images/ux-rotate-points2.png)</span></span>
<span data-ttu-id="3d50c-126">3 番目の図では、回転の中心がアプリによって絵の中心点に定義されています (またはユーザーによって設定されています)。</span><span class="sxs-lookup"><span data-stu-id="3d50c-126">In this third picture, the center of rotation has been defined by the application (or set by the user) to be the center point of the picture.</span></span> <span data-ttu-id="3d50c-127">回転の後で、絵が指の 1 つの周りで回転しなかったために、直接操作の画像が失われます (ユーザーがこの設定を選んだ場合を除きます)。</span><span class="sxs-lookup"><span data-stu-id="3d50c-127">After the rotation, because the picture did not rotate around one of the fingers, the illusion of direct manipulation is broken (unless the user has chosen this setting).</span></span>

<span data-ttu-id="3d50c-128">![回転ポイントで回転した画像を表示するイメージは、2 つの初期のタッチ ポイントのいずれかではなく、画像の中央に制限されます。](images/ux-rotate-points3.png)</span><span class="sxs-lookup"><span data-stu-id="3d50c-128">![image showing a rotated picture with the rotation point constrained to the center of the picture rather than either of the two initial touch points.](images/ux-rotate-points3.png)</span></span>
<span data-ttu-id="3d50c-129">最後の図では、回転の中心がアプリによって絵の左端の中央の点に定義されています (またはユーザーによって設定されています)。</span><span class="sxs-lookup"><span data-stu-id="3d50c-129">In this last picture, the center of rotation has been defined by the application (or set by the user) to be a point in the middle of the left edge of the picture.</span></span> <span data-ttu-id="3d50c-130">この場合も、ユーザーがこの設定を選んだ場合を除いて、直接操作の画像が失われます。</span><span class="sxs-lookup"><span data-stu-id="3d50c-130">Again, unless the user has chosen this setting, the illusion of direct manipulation is broken in this case.</span></span>

![回転の中心点が最初に 2 つタッチした点のどちらでもなく、絵の左端の中央に制約された状態で回転する絵を示す図](images/ux-rotate-points4.png)

 

<span data-ttu-id="3d50c-132">Windows 8 には、回転の 3 つの種類がサポートしています: 無料、制約、および結合します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-132">Windows 8 supports three types of rotation: free, constrained, and combined.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="3d50c-133">種類</span><span class="sxs-lookup"><span data-stu-id="3d50c-133">Type</span></span></th>
<th align="left"><span data-ttu-id="3d50c-134">説明</span><span class="sxs-lookup"><span data-stu-id="3d50c-134">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="3d50c-135">自由回転</span><span class="sxs-lookup"><span data-stu-id="3d50c-135">Free rotation</span></span></td>
<td align="left"><p><span data-ttu-id="3d50c-136">自由回転では、ユーザーはコンテンツを 360°の任意の位置に自由に回転できます。ユーザーがオブジェクトを離すと、オブジェクトは選んだ位置にとどまります。</span><span class="sxs-lookup"><span data-stu-id="3d50c-136">Free rotation enables a user to rotate content freely anywhere in a 360 degree arc. When the user releases the object, the object remains in the chosen position.</span></span> <span data-ttu-id="3d50c-137">自由回転は、Microsoft PowerPoint、Word、Visio、ペイントと Adobe Photoshop、Illustrator、Flash などの描画アプリやレイアウト アプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="3d50c-137">Free rotation is useful for drawing and layout applications such as Microsoft PowerPoint, Word, Visio, and Paint; and Adobe Photoshop, Illustrator, and Flash.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="3d50c-138">制約付き回転</span><span class="sxs-lookup"><span data-stu-id="3d50c-138">Constrained rotation</span></span></td>
<td align="left"><p><span data-ttu-id="3d50c-139">制約付き回転は、操作中は自由回転をサポートしますが、離したときに 90°単位のスナップ位置が強制されます (0、90、180、270)。</span><span class="sxs-lookup"><span data-stu-id="3d50c-139">Constrained rotation supports free rotation during the manipulation but enforces snap points at 90 degree increments (0, 90, 180, and 270) upon release.</span></span> <span data-ttu-id="3d50c-140">ユーザーがオブジェクトを離すと、オブジェクトは自動的に最も近いスナップ位置まで回転します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-140">When the user releases the object, the object automatically rotates to the nearest snap point.</span></span></p>
<p><span data-ttu-id="3d50c-141">制約付き回転は回転の最も一般的な方法で、コンテンツのスクロールと同じように機能します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-141">Constrained rotation is the most common method of rotation, and it functions in a similar way to scrolling content.</span></span> <span data-ttu-id="3d50c-142">スナップ位置があることで、ユーザーは操作が正確でなくても目標の位置に到達できます。</span><span class="sxs-lookup"><span data-stu-id="3d50c-142">Snap points let a user be imprecise and still achieve their goal.</span></span> <span data-ttu-id="3d50c-143">制約付きの回転は Web ブラウザーやフォト アルバムのようなアプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="3d50c-143">Constrained rotation is useful for applications such as web browsers and photo albums.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="3d50c-144">複合回転</span><span class="sxs-lookup"><span data-stu-id="3d50c-144">Combined rotation</span></span></td>
<td align="left"><p><span data-ttu-id="3d50c-145">複合回転は自由回転をサポートしますが、(<a href="guidelines-for-panning.md">パン</a>におけるレールのように) 90°単位のスナップ位置のゾーンでは制約付き回転によって強制されます。</span><span class="sxs-lookup"><span data-stu-id="3d50c-145">Combined rotation supports free rotation with zones (similar to rails in <a href="guidelines-for-panning.md">Guidelines for panning</a>) at each of the 90 degree snap points enforced by constrained rotation.</span></span> <span data-ttu-id="3d50c-146">ユーザーが各 90° のゾーンの外でオブジェクトを離した場合にはオブジェクトはその位置にとどまりますが、それ以外の場合にはオブジェクトは自動的にスナップ位置まで回転します。</span><span class="sxs-lookup"><span data-stu-id="3d50c-146">If the user releases the object outside of one of 90 degree zones, the object remains in that position; otherwise, the object automatically rotates to a snap point.</span></span></p>
<div class="alert"><span data-ttu-id="3d50c-147">
<strong>注</strong>  ユーザー インターフェイスのレールはターゲットの周囲がいくつかの特定の値または場所の選択に影響を与える方に移動を制限する機能です。</span><span class="sxs-lookup"><span data-stu-id="3d50c-147">
<strong>Note</strong>  A user interface rail is a feature in which an area around a target constrains movement towards some specific value or location to influence its selection.</span></span>
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

## <a name="related-topics"></a><span data-ttu-id="3d50c-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3d50c-148">Related topics</span></span>


<span data-ttu-id="3d50c-149">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="3d50c-149">**Samples**</span></span>
* [<span data-ttu-id="3d50c-150">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-150">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="3d50c-151">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-151">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="3d50c-152">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-152">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="3d50c-153">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-153">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

<span data-ttu-id="3d50c-154">**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="3d50c-154">**Archive samples**</span></span>
* [<span data-ttu-id="3d50c-155">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-155">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="3d50c-156">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-156">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="3d50c-157">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-157">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="3d50c-158">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-158">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="3d50c-159">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-159">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="3d50c-160">入力:ジェスチャと GestureRecognizer の操作</span><span class="sxs-lookup"><span data-stu-id="3d50c-160">Input: Gestures and manipulations with GestureRecognizer</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="3d50c-161">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-161">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="3d50c-162">DirectX のタッチ入力サンプル</span><span class="sxs-lookup"><span data-stu-id="3d50c-162">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




