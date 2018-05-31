---
author: Karl-Bridge-Microsoft
Description: This topic describes the new Windows UI for rotation and provides user experience guidelines that should be considered when using this new interaction mechanism in your UWP app.
title: 回転
ms.assetid: f098bc05-35b3-46b2-9e9b-9ff292d067ca
label: Rotation
template: detail.hbs
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9cc30dbd9fd501d310bb037726414356354af294
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653421"
---
# <a name="rotation"></a><span data-ttu-id="89f2c-103">回転</span><span class="sxs-lookup"><span data-stu-id="89f2c-103">Rotation</span></span>


<span data-ttu-id="89f2c-104">この記事では、新しい Windows UI の回転について説明し、UWP アプリでこの新しい操作のメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="89f2c-104">This article describes the new Windows UI for rotation and provides user experience guidelines that should be considered when using this new interaction mechanism in your UWP app.</span></span>

> <span data-ttu-id="89f2c-105">**重要な API**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="89f2c-105">**Important APIs**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="89f2c-106">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="89f2c-106">Dos and don'ts</span></span>

-   <span data-ttu-id="89f2c-107">ユーザーが直接 UI 要素を回転できるように回転を使います。</span><span class="sxs-lookup"><span data-stu-id="89f2c-107">Use rotation to help users directly rotate UI elements.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="89f2c-108">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="89f2c-108">Additional usage guidance</span></span>


**<span data-ttu-id="89f2c-109">回転の概要</span><span class="sxs-lookup"><span data-stu-id="89f2c-109">Overview of rotation</span></span>**

<span data-ttu-id="89f2c-110">回転は UWP アプリで使われるタッチ操作に最適な手法であり、ユーザーがオブジェクトを回転 (時計回りまたは反時計回り) できるようにします。</span><span class="sxs-lookup"><span data-stu-id="89f2c-110">Rotation is the touch-optimized technique used by UWP apps to enable users to turn an object in a circular direction (clockwise or counter-clockwise).</span></span>

<span data-ttu-id="89f2c-111">入力デバイスに応じて回転操作は次のように実行されます。</span><span class="sxs-lookup"><span data-stu-id="89f2c-111">Depending on the input device, the rotation interaction is performed using:</span></span>

-   <span data-ttu-id="89f2c-112">マウスまたはアクティブなペン/スタイラスを使って、選んだオブジェクトの回転グリッパーを移動する。</span><span class="sxs-lookup"><span data-stu-id="89f2c-112">A mouse or active pen/stylus to move the rotation gripper of a selected object.</span></span>
-   <span data-ttu-id="89f2c-113">タッチまたはパッシブなペン/スタイラスを使って、回転ジェスチャによって任意の方向にオブジェクトを回転させる。</span><span class="sxs-lookup"><span data-stu-id="89f2c-113">Touch or passive pen/stylus to turn the object in the desired direction using the rotate gesture.</span></span>

**<span data-ttu-id="89f2c-114">回転を使う状況</span><span class="sxs-lookup"><span data-stu-id="89f2c-114">When to use rotation</span></span>**

<span data-ttu-id="89f2c-115">ユーザーが直接 UI 要素を回転できるように回転を使います。</span><span class="sxs-lookup"><span data-stu-id="89f2c-115">Use rotation to help users directly rotate UI elements.</span></span> <span data-ttu-id="89f2c-116">次の図は、サポートされる回転操作の指の配置をいくつか示しています。</span><span class="sxs-lookup"><span data-stu-id="89f2c-116">The following diagrams show some of the supported finger positions for the rotation interaction.</span></span>

![回転がサポートされる異なる指の配置を示す図](images/ux-rotate-positions.png)

**<span data-ttu-id="89f2c-118">注:</span><span class="sxs-lookup"><span data-stu-id="89f2c-118">Note</span></span>**  
<span data-ttu-id="89f2c-119">ユーザーが接触点とは無関係に回転の中心点を指定できる場合を除いて (例: 描画アプリやレイアウト アプリ)、直観に従い多くの場合、回転の中心点は 2 つのタッチした点のどちらかになります。</span><span class="sxs-lookup"><span data-stu-id="89f2c-119">Intuitively, and in most cases, the rotation point is one of the two touch points unless the user can specify a rotation point unrelated to the contact points (for example, in a drawing or layout application).</span></span> <span data-ttu-id="89f2c-120">以下の図では、回転の中心点がこのような制約を受けない場合に、どのようにユーザー エクスペリエンスが低下するかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="89f2c-120">The following images demonstrate how the user experience can be degraded if the rotation point is not constrained in this way.</span></span>

<span data-ttu-id="89f2c-121">1 番目の図は、最初のタッチ ポイント (親指) と 2 番目のタッチ ポイント (人差し指) を示します。人差し指は木に、親指は丸太にタッチしています。</span><span class="sxs-lookup"><span data-stu-id="89f2c-121">This first picture shows the initial (thumb) and secondary (index finger) touch points: the index finger is touching a tree and the thumb is touching a log.</span></span>

![回転ジェスチャのための最初の 2 つのタッチ ポイントを示す図](images/ux-rotate-points1.png)
<span data-ttu-id="89f2c-123">2 番目の図では、最初のタッチ ポイント (親指) の周りで回転が行われています。</span><span class="sxs-lookup"><span data-stu-id="89f2c-123">In this second picture, rotation is performed around the initial (thumb) touch point.</span></span> <span data-ttu-id="89f2c-124">回転の後で、人差し指は相変わらず木の幹にタッチし、親指は相変わらず丸太 (回転の中心点) にタッチしています。</span><span class="sxs-lookup"><span data-stu-id="89f2c-124">After the rotation, the index finger is still touching the tree trunk and the thumb is still touching the log (the rotation point).</span></span>

![回転の中心点が最初に 2 つタッチした点の 1 つに制約された状態で回転する絵を示す図](images/ux-rotate-points2.png)
<span data-ttu-id="89f2c-126">3 番目の図では、回転の中心がアプリによって絵の中心点に定義されています (またはユーザーによって設定されています)。</span><span class="sxs-lookup"><span data-stu-id="89f2c-126">In this third picture, the center of rotation has been defined by the application (or set by the user) to be the center point of the picture.</span></span> <span data-ttu-id="89f2c-127">回転の後で、絵が指の 1 つの周りで回転しなかったために、直接操作の画像が失われます (ユーザーがこの設定を選んだ場合を除きます)。</span><span class="sxs-lookup"><span data-stu-id="89f2c-127">After the rotation, because the picture did not rotate around one of the fingers, the illusion of direct manipulation is broken (unless the user has chosen this setting).</span></span>

![回転の中心点が最初に 2 つタッチした点のどちらでもなく、絵の中心に制約された状態で回転する絵を示す図](images/ux-rotate-points3.png)
<span data-ttu-id="89f2c-129">最後の図では、回転の中心がアプリによって絵の左端の中央の点に定義されています (またはユーザーによって設定されています)。</span><span class="sxs-lookup"><span data-stu-id="89f2c-129">In this last picture, the center of rotation has been defined by the application (or set by the user) to be a point in the middle of the left edge of the picture.</span></span> <span data-ttu-id="89f2c-130">この場合も、ユーザーがこの設定を選んだ場合を除いて、直接操作の画像が失われます。</span><span class="sxs-lookup"><span data-stu-id="89f2c-130">Again, unless the user has chosen this setting, the illusion of direct manipulation is broken in this case.</span></span>

![回転の中心点が最初に 2 つタッチした点のどちらでもなく、絵の左端の中央に制約された状態で回転する絵を示す図](images/ux-rotate-points4.png)

 

<span data-ttu-id="89f2c-132">Windows8 では、自由、制約付き、複合の 3 種類の回転をサポートします。</span><span class="sxs-lookup"><span data-stu-id="89f2c-132">Windows 8 supports three types of rotation: free, constrained, and combined.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="89f2c-133">タイプ</span><span class="sxs-lookup"><span data-stu-id="89f2c-133">Type</span></span></th>
<th align="left"><span data-ttu-id="89f2c-134">説明</span><span class="sxs-lookup"><span data-stu-id="89f2c-134">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="89f2c-135">自由回転</span><span class="sxs-lookup"><span data-stu-id="89f2c-135">Free rotation</span></span></td>
<td align="left"><p><span data-ttu-id="89f2c-136">自由回転では、ユーザーはコンテンツを 360°の任意の位置に自由に回転できます。ユーザーがオブジェクトを離すと、オブジェクトは選んだ位置にとどまります。</span><span class="sxs-lookup"><span data-stu-id="89f2c-136">Free rotation enables a user to rotate content freely anywhere in a 360 degree arc. When the user releases the object, the object remains in the chosen position.</span></span> <span data-ttu-id="89f2c-137">自由回転は、Microsoft PowerPoint、Word、Visio、ペイントと Adobe Photoshop、Illustrator、Flash などの描画アプリやレイアウト アプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="89f2c-137">Free rotation is useful for drawing and layout applications such as Microsoft PowerPoint, Word, Visio, and Paint; and Adobe Photoshop, Illustrator, and Flash.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="89f2c-138">制約付き回転</span><span class="sxs-lookup"><span data-stu-id="89f2c-138">Constrained rotation</span></span></td>
<td align="left"><p><span data-ttu-id="89f2c-139">制約付き回転は、操作中は自由回転をサポートしますが、離したときに 90°単位のスナップ位置が強制されます (0、90、180、270)。</span><span class="sxs-lookup"><span data-stu-id="89f2c-139">Constrained rotation supports free rotation during the manipulation but enforces snap points at 90 degree increments (0, 90, 180, and 270) upon release.</span></span> <span data-ttu-id="89f2c-140">ユーザーがオブジェクトを離すと、オブジェクトは自動的に最も近いスナップ位置まで回転します。</span><span class="sxs-lookup"><span data-stu-id="89f2c-140">When the user releases the object, the object automatically rotates to the nearest snap point.</span></span></p>
<p><span data-ttu-id="89f2c-141">制約付き回転は回転の最も一般的な方法で、コンテンツのスクロールと同じように機能します。</span><span class="sxs-lookup"><span data-stu-id="89f2c-141">Constrained rotation is the most common method of rotation, and it functions in a similar way to scrolling content.</span></span> <span data-ttu-id="89f2c-142">スナップ位置があることで、ユーザーは操作が正確でなくても目標の位置に到達できます。</span><span class="sxs-lookup"><span data-stu-id="89f2c-142">Snap points let a user be imprecise and still achieve their goal.</span></span> <span data-ttu-id="89f2c-143">制約付きの回転は Web ブラウザーやフォト アルバムのようなアプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="89f2c-143">Constrained rotation is useful for applications such as web browsers and photo albums.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="89f2c-144">複合回転</span><span class="sxs-lookup"><span data-stu-id="89f2c-144">Combined rotation</span></span></td>
<td align="left"><p><span data-ttu-id="89f2c-145">複合回転は自由回転をサポートしますが、(<a href="guidelines-for-panning.md">パン</a>におけるレールのように) 90°単位のスナップ位置のゾーンでは制約付き回転によって強制されます。</span><span class="sxs-lookup"><span data-stu-id="89f2c-145">Combined rotation supports free rotation with zones (similar to rails in <a href="guidelines-for-panning.md">Guidelines for panning</a>) at each of the 90 degree snap points enforced by constrained rotation.</span></span> <span data-ttu-id="89f2c-146">ユーザーが各 90° のゾーンの外でオブジェクトを離した場合にはオブジェクトはその位置にとどまりますが、それ以外の場合にはオブジェクトは自動的にスナップ位置まで回転します。</span><span class="sxs-lookup"><span data-stu-id="89f2c-146">If the user releases the object outside of one of 90 degree zones, the object remains in that position; otherwise, the object automatically rotates to a snap point.</span></span></p>
<div class="alert"><span data-ttu-id="89f2c-147">
<strong>注:</strong>  ユーザー インターフェイスのレールは、ターゲットの周辺の領域において、特定の値または位置に向けて動きが制約され選択に影響を与える機能です。</span><span class="sxs-lookup"><span data-stu-id="89f2c-147">
<strong>Note</strong>  A user interface rail is a feature in which an area around a target constrains movement towards some specific value or location to influence its selection.</span></span>
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

## <a name="related-topics"></a><span data-ttu-id="89f2c-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="89f2c-148">Related topics</span></span>


**<span data-ttu-id="89f2c-149">サンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-149">Samples</span></span>**
* [<span data-ttu-id="89f2c-150">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-150">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="89f2c-151">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-151">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="89f2c-152">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-152">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="89f2c-153">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-153">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="89f2c-154">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="89f2c-154">Archive samples</span></span>**
* [<span data-ttu-id="89f2c-155">入力: XAML ユーザー入力イベントのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="89f2c-155">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="89f2c-156">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-156">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="89f2c-157">入力: タッチのヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-157">Input: Touch hit testing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="89f2c-158">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="89f2c-158">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="89f2c-159">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-159">Input: Simplified ink sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="89f2c-160">入力: GestureRecognizer によるジェスチャと操作</span><span class="sxs-lookup"><span data-stu-id="89f2c-160">Input: Gestures and manipulations with GestureRecognizer</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="89f2c-161">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="89f2c-161">Input: Manipulations and gestures (C++) sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="89f2c-162">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="89f2c-162">DirectX touch input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




