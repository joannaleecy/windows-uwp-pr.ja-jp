---
author: Karl-Bridge-Microsoft
Description: This topic describes Windows zooming and resizing elements and provides user experience guidelines for using these interaction mechanisms in your apps.
title: 光学式ズームとサイズ変更のガイドライン
ms.assetid: 51a0007c-8a5d-4c44-ac9f-bbbf092b8a00
label: Optical zoom and resizing
template: detail.hbs
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b49afdd4a9fe1db28c8195bdf166d6a74e153020
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653801"
---
# <a name="optical-zoom-and-resizing"></a><span data-ttu-id="e23c2-103">光学式ズームとサイズ変更</span><span class="sxs-lookup"><span data-stu-id="e23c2-103">Optical zoom and resizing</span></span>



<span data-ttu-id="e23c2-104">この記事では、Windows のズームとサイズ変更の要素について説明し、アプリでこのような操作のメカニズムを使うためのユーザー エクスペリエンスのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-104">This article describes Windows zooming and resizing elements and provides user experience guidelines for using these interaction mechanisms in your apps.</span></span>

> <span data-ttu-id="e23c2-105">**重要な API**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Input (XAML)**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="e23c2-105">**Important APIs**: [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Input (XAML)**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>

<span data-ttu-id="e23c2-106">光学式ズームを使うと、ユーザーはコンテンツ領域内でコンテンツの表示を拡大できます (光学式ズームはコンテンツ領域自体に対して実行されます)。これに対して、サイズ変更を使うと、ユーザーはコンテンツ領域の表示を変更せずに、1 つまたは複数のオブジェクトの相対的なサイズを変更できます (サイズ変更はコンテンツ領域内のオブジェクトに対して実行されます)。</span><span class="sxs-lookup"><span data-stu-id="e23c2-106">Optical zoom lets users magnify their view of the content within a content area (it is performed on the content area itself), whereas resizing enables users to change the relative size of one or more objects without changing the view of the content area (it is performed on the objects within the content area).</span></span>

<span data-ttu-id="e23c2-107">光学式ズーム操作とセマンティック ズーム操作は両方とも、ピンチ ジェスチャとストレッチ ジェスチャ (指を広げて拡大、互いに近づけて縮小)、Ctrl キーを押しながらマウスのスクロール ホイールをスクロール、または Ctrl キーを (テンキーがない場合は Shift キーも同時に) 押しながらプラス (+) キーまたはマイナス (-) キーを押して実行します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-107">Both optical zoom and resizing interactions are performed through the pinch and stretch gestures (moving fingers farther apart zooms in and moving them closer together zooms out), or by holding the Ctrl key down while scrolling the mouse scroll wheel, or by holding the Ctrl key down (with the Shift key, if no numeric keypad is available) and pressing the plus (+) or minus (-) key.</span></span>

<span data-ttu-id="e23c2-108">次の図にサイズ変更と光学式ズームの違いを示します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-108">The following diagrams demonstrate the differences between resizing and optical zooming.</span></span>

<span data-ttu-id="e23c2-109">**光学式ズーム**: ユーザーは領域を選び、領域全体を拡大します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-109">**Optical zoom**: User selects an area, and then zooms into the entire area.</span></span>

![コンテンツ領域上で指を互いに近づけて拡大し、広げて縮小する](images/areazoom.png)

<span data-ttu-id="e23c2-111">**サイズ変更**: ユーザーは領域内のオブジェクトを選び、そのオブジェクトのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-111">**Resize**: User selects an object within an area, and resizes that object.</span></span>

![指を互いに近づけてオブジェクトを縮小し、広げて拡大する](images/objectresize.png)

**<span data-ttu-id="e23c2-113">注:</span><span class="sxs-lookup"><span data-stu-id="e23c2-113">Note</span></span>**  
<span data-ttu-id="e23c2-114">光学式ズームと[セマンティック ズーム](../controls-and-patterns/semantic-zoom.md)を混同しないように気を付けてください。</span><span class="sxs-lookup"><span data-stu-id="e23c2-114">Optical zoom shouldn't be confused with [Semantic Zoom](../controls-and-patterns/semantic-zoom.md).</span></span> <span data-ttu-id="e23c2-115">どちらの操作でも同じジェスチャが使われますが、セマンティック ズームは、単一のビュー内で整理されたコンテンツを表示したりナビゲーションしたりする場合に使われます (コンピューターのフォルダー構造、ドキュメント ライブラリ、フォト アルバムなど)。</span><span class="sxs-lookup"><span data-stu-id="e23c2-115">Although the same gestures are used for both interactions, semantic zoom refers to the presentation and navigation of content organized within a single view (such as the folder structure of a computer, a library of documents, or a photo album).</span></span>

 

## <a name="dos-and-donts"></a><span data-ttu-id="e23c2-116">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e23c2-116">Dos and don'ts</span></span>


<span data-ttu-id="e23c2-117">サイズ変更または光学式ズームをサポートするアプリでは、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="e23c2-117">Use the following guidelines for apps that support either resizing or optical zooming:</span></span>

-   <span data-ttu-id="e23c2-118">最大サイズと最小サイズの制限または範囲が定義されている場合には、視覚的なフィードバックを使って、ユーザーがこの制限に達したことや超過したことを示します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-118">If maximum and minimum size constraints or boundaries are defined, use visual feedback to demonstrate when the user reaches or exceeds those boundaries.</span></span>
-   <span data-ttu-id="e23c2-119">スナップ位置を使うと、論理的な操作停止位置を指定してズームとサイズ変更の動作を変更し、コンテンツの特定の部分がビューポートに表示されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="e23c2-119">Use snap points to influence zooming and resizing behavior by providing logical points at which to stop the manipulation and ensure a specific subset of content is displayed in the viewport.</span></span> <span data-ttu-id="e23c2-120">一般的なズーム レベルまたは論理ビューに対してスナップ位置を設定して、ユーザーがこれらのレベルを簡単に選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="e23c2-120">Provide snap points for common zoom levels or logical views to make it easier for a user to select those levels.</span></span> <span data-ttu-id="e23c2-121">たとえば、写真のアプリでは 100% の位置にサイズ変更用のスナップ位置を設定します。また、地図のアプリでスナップ位置を設定すると、市、県、国を表示する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="e23c2-121">For example, photo apps might provide a resizing snap point at 100% or, in the case of mapping apps, snap points might be useful at city, state, and country views.</span></span>

    <span data-ttu-id="e23c2-122">スナップ位置があると、ユーザーの操作が正確でなくても意図された操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="e23c2-122">Snap points enable users to be imprecise and still achieve their goals.</span></span> <span data-ttu-id="e23c2-123">XAML を使う場合は、[**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527) のスナップ位置のプロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e23c2-123">If you're using XAML, see the snap points properties of [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527).</span></span> <span data-ttu-id="e23c2-124">JavaScript と HTML の場合は、[**-ms-content-zoom-snap-points**](https://msdn.microsoft.com/library/hh771895) を使います。</span><span class="sxs-lookup"><span data-stu-id="e23c2-124">For JavaScript and HTML, use [**-ms-content-zoom-snap-points**](https://msdn.microsoft.com/library/hh771895).</span></span>

    <span data-ttu-id="e23c2-125">スナップ位置には次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="e23c2-125">There are two types of snap-points:</span></span>

    -   <span data-ttu-id="e23c2-126">近接: 指を離した後、スナップ位置の距離のしきい値の範囲内で慣性に従った動きが止まると、スナップ位置が選ばれます。</span><span class="sxs-lookup"><span data-stu-id="e23c2-126">Proximity - After the contact is lifted, a snap point is selected if inertia stops within a distance threshold of the snap point.</span></span> <span data-ttu-id="e23c2-127">近接スナップ位置の場合は、ズームとサイズ変更をスナップ位置とスナップ位置の間で止めることができます。</span><span class="sxs-lookup"><span data-stu-id="e23c2-127">Proximity snap points still allow a zoom or resize to end between snap points.</span></span>
    -   <span data-ttu-id="e23c2-128">強制: 指を離す前に通過した最後のスナップ位置の直前または直後のスナップ位置が選ばれます (ジェスチャの方向と速度によって異なります)。</span><span class="sxs-lookup"><span data-stu-id="e23c2-128">Mandatory - The snap point selected is the one that immediately precedes or succeeds the last snap point crossed before the contact was lifted (depending on the direction and velocity of the gesture).</span></span> <span data-ttu-id="e23c2-129">操作が必ず強制スナップ位置で止まるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e23c2-129">A manipulation must end on a mandatory snap point.</span></span>
-   <span data-ttu-id="e23c2-130">慣性の物理法則を使います。</span><span class="sxs-lookup"><span data-stu-id="e23c2-130">Use inertia physics.</span></span> <span data-ttu-id="e23c2-131">これには次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="e23c2-131">These include the following:</span></span>
    -   <span data-ttu-id="e23c2-132">減速: ユーザーが 2 本の指を互いに近づけたり、遠ざけたりしたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-132">Deceleration: Occurs when the user stops pinching or stretching.</span></span> <span data-ttu-id="e23c2-133">これは滑りやすい表面で滑っている状態から止まるまでの動きに似ています。</span><span class="sxs-lookup"><span data-stu-id="e23c2-133">This is similar to sliding to a stop on a slippery surface.</span></span>
    -   <span data-ttu-id="e23c2-134">バウンド: サイズの制限または範囲を超えると、わずかな跳ね返りの効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-134">Bounce: A slight bounce-back effect occurs when a size constraint or boundary is passed.</span></span>
-   <span data-ttu-id="e23c2-135">「[ターゲットの設定のガイドライン](guidelines-for-targeting.md)」に従った領域制御。</span><span class="sxs-lookup"><span data-stu-id="e23c2-135">Space controls according to the [Guidelines for targeting](guidelines-for-targeting.md).</span></span>
-   <span data-ttu-id="e23c2-136">制限付きのサイズ変更のためにスケーリング ハンドルを提供します。</span><span class="sxs-lookup"><span data-stu-id="e23c2-136">Provide scaling handles for constrained resizing.</span></span> <span data-ttu-id="e23c2-137">ハンドルが指定されない場合は、等角投影、つまり比が一定のサイズ変更が既定値です。</span><span class="sxs-lookup"><span data-stu-id="e23c2-137">Isometric, or proportional, resizing is the default if the handles are not specified.</span></span>
-   <span data-ttu-id="e23c2-138">UI の操作またはアプリ内の追加コントロールの公開用にはズームを使わず、パン領域を使います。</span><span class="sxs-lookup"><span data-stu-id="e23c2-138">Don't use zooming to navigate the UI or expose additional controls within your app, use a panning region instead.</span></span> <span data-ttu-id="e23c2-139">パンについて詳しくは、「[パンのガイドライン](guidelines-for-panning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e23c2-139">For more info on panning, see [Guidelines for panning](guidelines-for-panning.md).</span></span>
-   <span data-ttu-id="e23c2-140">サイズ変更できるコンテンツ領域内にサイズ変更できるオブジェクトを置かないようにします。</span><span class="sxs-lookup"><span data-stu-id="e23c2-140">Don't put resizable objects within a resizable content area.</span></span> <span data-ttu-id="e23c2-141">ただし、次のような例外があります。</span><span class="sxs-lookup"><span data-stu-id="e23c2-141">Exceptions to this include:</span></span>
    -   <span data-ttu-id="e23c2-142">サイズ変更できるアイテムがサイズ変更できるキャンバスまたはアート ボードに表示される描画アプリケーション。</span><span class="sxs-lookup"><span data-stu-id="e23c2-142">Drawing applications where resizable items can appear on a resizable canvas or art board.</span></span>
    -   <span data-ttu-id="e23c2-143">地図などの埋め込みオブジェクトがある Web ページ。</span><span class="sxs-lookup"><span data-stu-id="e23c2-143">Webpages with an embedded object such as a map.</span></span>

    **<span data-ttu-id="e23c2-144">注:</span><span class="sxs-lookup"><span data-stu-id="e23c2-144">Note</span></span>**  
    <span data-ttu-id="e23c2-145">どのような場合でも、すべてのタッチ ポイントがサイズ変更できるオブジェクト内にある場合以外は、コンテンツ領域のサイズが変更されます。</span><span class="sxs-lookup"><span data-stu-id="e23c2-145">In all cases, the content area is resized unless all touch points are within the resizable object.</span></span>

     

## <a name="related-articles"></a><span data-ttu-id="e23c2-146">関連記事</span><span class="sxs-lookup"><span data-stu-id="e23c2-146">Related articles</span></span>


**<span data-ttu-id="e23c2-147">サンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-147">Samples</span></span>**
* [<span data-ttu-id="e23c2-148">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-148">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="e23c2-149">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-149">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="e23c2-150">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-150">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="e23c2-151">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-151">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="e23c2-152">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="e23c2-152">Archive samples</span></span>**
* [<span data-ttu-id="e23c2-153">入力: XAML ユーザー入力イベントのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="e23c2-153">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="e23c2-154">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-154">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="e23c2-155">入力: タッチのヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-155">Input: Touch hit testing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="e23c2-156">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="e23c2-156">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="e23c2-157">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-157">Input: Simplified ink sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="e23c2-158">入力: Windows 8 のジェスチャのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="e23c2-158">Input: Windows 8 gestures sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="e23c2-159">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="e23c2-159">Input: Manipulations and gestures (C++) sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="e23c2-160">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="e23c2-160">DirectX touch input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 



