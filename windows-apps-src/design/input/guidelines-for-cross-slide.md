---
Description: クロススライドは、スワイプ ジェスチャによる選択や、スライド ジェスチャによるドラッグ (移動) 操作をサポートするために使います。
title: クロススライドのガイドライン
ms.assetid: 897555e2-c567-4bbe-b600-553daeb223d5
ms.date: 10/25/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b2d402bca61fc271b6d1e2e972cca280693f9ce3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658127"
---
# <a name="guidelines-for-cross-slide"></a><span data-ttu-id="461ec-104">クロススライドのガイドライン</span><span class="sxs-lookup"><span data-stu-id="461ec-104">Guidelines for cross-slide</span></span>




<span data-ttu-id="461ec-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="461ec-105">**Important APIs**</span></span>

-   [<span data-ttu-id="461ec-106">**CrossSliding**</span><span class="sxs-lookup"><span data-stu-id="461ec-106">**CrossSliding**</span></span>](https://msdn.microsoft.com/library/windows/apps/br241942)
-   [<span data-ttu-id="461ec-107">**CrossSlideThresholds**</span><span class="sxs-lookup"><span data-stu-id="461ec-107">**CrossSlideThresholds**</span></span>](https://msdn.microsoft.com/library/windows/apps/br241941)
-   [<span data-ttu-id="461ec-108">**Windows.UI.Input**</span><span class="sxs-lookup"><span data-stu-id="461ec-108">**Windows.UI.Input**</span></span>](https://msdn.microsoft.com/library/windows/apps/br242084)

<span data-ttu-id="461ec-109">クロススライドは、スワイプ ジェスチャによる選択や、スライド ジェスチャによるドラッグ (移動) 操作をサポートするために使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-109">Use cross-slide to support selection with the swipe gesture and drag (move) interactions with the slide gesture.</span></span>

## <a name="span-iddosanddontsspanspan-iddosanddontsspanspan-iddosanddontsspandos-and-donts"></a><span data-ttu-id="461ec-110"><span id="Dos_and_don_ts"></span><span id="dos_and_don_ts"></span><span id="DOS_AND_DON_TS"></span>注意事項</span><span class="sxs-lookup"><span data-stu-id="461ec-110"><span id="Dos_and_don_ts"></span><span id="dos_and_don_ts"></span><span id="DOS_AND_DON_TS"></span>Dos and don'ts</span></span>


-   <span data-ttu-id="461ec-111">クロススライドは、単一の方向にスクロールするリストやコレクションに使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-111">Use cross-slide for lists or collections that scroll in a single direction.</span></span>
-   <span data-ttu-id="461ec-112">クロススライドは、タップ操作が別の目的で使われる場合に、項目を選ぶために使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-112">Use cross-slide for item selection when the tap interaction is used for another purpose.</span></span>
-   <span data-ttu-id="461ec-113">キューに項目を追加するためにクロススライドを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="461ec-113">Don't use cross-slide for adding items to a queue.</span></span>

## <a name="span-idadditionalusageguidancespanspan-idadditionalusageguidancespanspan-idadditionalusageguidancespanadditional-usage-guidance"></a><span data-ttu-id="461ec-114"><span id="Additional_usage_guidance"></span><span id="additional_usage_guidance"></span><span id="ADDITIONAL_USAGE_GUIDANCE"></span>追加の使用に関するガイダンス</span><span class="sxs-lookup"><span data-stu-id="461ec-114"><span id="Additional_usage_guidance"></span><span id="additional_usage_guidance"></span><span id="ADDITIONAL_USAGE_GUIDANCE"></span>Additional usage guidance</span></span>


<span data-ttu-id="461ec-115">選択とドラッグは、1 方向 (垂直または水平) にパンできるコンテンツ領域内でだけ行うことができます。</span><span class="sxs-lookup"><span data-stu-id="461ec-115">Selection and drag are possible only within a content area that is pannable in one direction (vertical or horizontal).</span></span> <span data-ttu-id="461ec-116">これらの操作が機能するには、1 つのパン方向がロックされていて、ジェスチャがパン方向に対して垂直な方向に行われる必要があります。</span><span class="sxs-lookup"><span data-stu-id="461ec-116">For either interaction to work, one panning direction must be locked and the gesture must be performed in the direction perpendicular to the panning direction.</span></span>

<span data-ttu-id="461ec-117">ここでは、クロススライドを使ってオブジェクトを選び、ドラッグする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="461ec-117">Here we demonstrate selecting and dragging an object using a cross-slide.</span></span> <span data-ttu-id="461ec-118">左の図は、スワイプ ジェスチャで距離のしきい値を超える前に指を離してオブジェクトを解放することで、項目が選択された状態を示しています。</span><span class="sxs-lookup"><span data-stu-id="461ec-118">The image on the left shows how an item is selected if a swipe gesture doesn't cross a distance threshold before the contact is lifted and the object released.</span></span> <span data-ttu-id="461ec-119">右の図は、距離のしきい値を超えてスライド ジェスチャを行うことで、オブジェクトがドラッグされた状態を示しています。</span><span class="sxs-lookup"><span data-stu-id="461ec-119">The image on the right shows a sliding gesture that crosses a distance threshold and results in the object being dragged.</span></span>

![選択とドラッグ アンド ドロップのプロセスを示す図。](images/crossslide-mechanism.png)

<span data-ttu-id="461ec-121">クロススライド操作で使われるしきい値の距離を次の図に示します。</span><span class="sxs-lookup"><span data-stu-id="461ec-121">The threshold distances used by the cross-slide interaction are shown in the following diagram.</span></span>

![選択とドラッグ アンド ドロップのプロセスを示すスクリーン ショット。](images/crossslide-threshold.png)

<span data-ttu-id="461ec-123">パンの機能を維持するために、選択操作とドラッグ操作は、2.7 mm (ターゲット解像度で約 10 ピクセル) という小さいしきい値を超えないと有効にならないしくみになっています。</span><span class="sxs-lookup"><span data-stu-id="461ec-123">To preserve panning functionality, a small threshold of 2.7mm (approximately 10 pixels at target resolution) must be crossed before either a select or drag interaction is activated.</span></span> <span data-ttu-id="461ec-124">この小さいしきい値は、クロススライドとパンの区別に使われるほか、タップ ジェスチャをクロススライドやパンと区別する目的でも使われます。</span><span class="sxs-lookup"><span data-stu-id="461ec-124">This small threshold helps the system to differentiate cross-sliding from panning, and also helps ensure that a tap gesture is distinguished from both cross-sliding and panning.</span></span>

<span data-ttu-id="461ec-125">この図は、ユーザーが UI の要素にタッチしたときに、指の位置がわずかに下に動いてしまった状態を示しています。</span><span class="sxs-lookup"><span data-stu-id="461ec-125">This image shows how a user touches an element in the UI, but moves their finger down slightly at contact.</span></span> <span data-ttu-id="461ec-126">しきい値がなければ、最初に垂直方向に移動しているため、この操作はクロススライドと解釈されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="461ec-126">With no threshold, the interaction would be interpreted as a cross-slide because of the initial vertical movement.</span></span> <span data-ttu-id="461ec-127">このしきい値があるおかげで、水平方向のパンと正しく解釈されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-127">With the threshold, the movement is interpreted correctly as horizontal panning.</span></span>

![選択かドラッグ アンド ドロップかを明確に区別するためのしきい値を示すスクリーン ショット。](images/crossslide-threshold2.png)

<span data-ttu-id="461ec-129">次に、クロススライド機能をアプリに含める際に考慮する必要がある、いくつかのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="461ec-129">Here are some guidelines to consider when including cross-slide functionality in your app.</span></span>

<span data-ttu-id="461ec-130">クロススライドは、単一の方向にスクロールするリストやコレクションに使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-130">Use cross-slide for lists or collections that scroll in a single direction.</span></span> <span data-ttu-id="461ec-131">詳しくは、「[ListView コントロールの追加](https://msdn.microsoft.com/library/windows/apps/hh465382)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461ec-131">For more information, see [Adding ListView controls](https://msdn.microsoft.com/library/windows/apps/hh465382).</span></span>

<span data-ttu-id="461ec-132">**注**  場合、コンテンツ領域をパンして、web ブラウザーや電子書籍リーダーなどの 2 つの方向に、プレス アンド ホールド時間指定の相互作用をイメージとハイパーリンクなどのオブジェクトのコンテキスト メニューの呼び出しに使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="461ec-132">**Note**  In cases where the content area can be panned in two directions, such as web browsers or e-readers, the press-and-hold timed interaction should be used to invoke the context menu for objects such as images and hyperlinks.</span></span>

 

|                                                                                         |                                                                                         |
|-----------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| ![水平方向にパンする 2 次元のリスト](images/groupedlistview1.png)                | ![垂直方向にパンする 1 次元のリスト](images/listviewlistlayout.png)                |
| <span data-ttu-id="461ec-135">水平方向にパンする 2 次元のリスト。</span><span class="sxs-lookup"><span data-stu-id="461ec-135">A horizontally panning two-dimensional list.</span></span> <span data-ttu-id="461ec-136">項目を選択または移動するには垂直方向にドラッグします。</span><span class="sxs-lookup"><span data-stu-id="461ec-136">Drag vertically to select or move an item.</span></span> | <span data-ttu-id="461ec-137">垂直方向にパンする 1 次元のリスト。</span><span class="sxs-lookup"><span data-stu-id="461ec-137">A vertically panning one-dimensional list.</span></span> <span data-ttu-id="461ec-138">項目を選択または移動するには水平方向にドラッグします。</span><span class="sxs-lookup"><span data-stu-id="461ec-138">Drag horizontally to select or move an item.</span></span> |

 

### <span id="selection"></span><span id="SELECTION"></span>

<span data-ttu-id="461ec-139">**選択します。**</span><span class="sxs-lookup"><span data-stu-id="461ec-139">**Selecting**</span></span>

<span data-ttu-id="461ec-140">選択は、1 つ以上のオブジェクトを起動またはアクティブ化せずにマークする操作です。</span><span class="sxs-lookup"><span data-stu-id="461ec-140">Selection is the marking, without launching or activating, of one or more objects.</span></span> <span data-ttu-id="461ec-141">これは、マウスを 1 回クリックする操作、または Shift キーを押しながらクリックする操作 (オブジェクトが複数の場合) に相当します。</span><span class="sxs-lookup"><span data-stu-id="461ec-141">This action is analogous to a single mouse click, or Shift key and mouse click, on one or more objects.</span></span>

<span data-ttu-id="461ec-142">クロススライド選択を行うには、要素をタッチし、少しドラッグして放します。</span><span class="sxs-lookup"><span data-stu-id="461ec-142">Cross-slide selection is achieved by touching an element and releasing it after a short dragging interaction.</span></span> <span data-ttu-id="461ec-143">この選択方法を使えば、他のタッチ インターフェイスで必要になるような、専用の選択モードや時間制限のある長押し操作は必要ありません。また、アクティブ化のためのタップ操作と競合することもありません。</span><span class="sxs-lookup"><span data-stu-id="461ec-143">This method of selection dispenses with both the dedicated selection mode and the press-and-hold timed interaction required by other touch interfaces and does not conflict with the tap interaction for activation.</span></span>

<span data-ttu-id="461ec-144">クロススライド選択には、距離のしきい値のほかにも領域のしきい値があり、次の図に示すように範囲が 90° に制限されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-144">In addition to the distance threshold, cross-slide selection is constrained to a 90° threshold area, as shown in the following diagram.</span></span> <span data-ttu-id="461ec-145">この領域の外にドラッグすると、オブジェクトは選択されません。</span><span class="sxs-lookup"><span data-stu-id="461ec-145">If the object is dragged outside of this area, it is not selected.</span></span>

![選択のしきい値の領域を示す図。](images/crossslide-selection.png)

<span data-ttu-id="461ec-147">クロススライド操作を補完する操作に、"自己説明" 操作とも呼ばれる時間制限のある長押し操作があります。</span><span class="sxs-lookup"><span data-stu-id="461ec-147">The cross-slide interaction is supplemented by a press-and-hold timed interaction, also referred to as a "self-revealing" interaction.</span></span> <span data-ttu-id="461ec-148">この補助操作でアクティブ化されるアニメーションによって、オブジェクトに対して実行できる操作が示されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-148">This supplemental interaction activates an animation that indicates what action can be performed on the object.</span></span> <span data-ttu-id="461ec-149">不明瞭解消 UI について詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="461ec-149">For more information on disambiguation UI, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>

<span data-ttu-id="461ec-150">次のスクリーン ショットは、自己説明のアニメーションの動作を示しています。</span><span class="sxs-lookup"><span data-stu-id="461ec-150">The following screen shots demonstrate how the self-revealing animation works.</span></span>

1.  <span data-ttu-id="461ec-151">長押しして、自己説明操作のアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="461ec-151">Press and hold to initiate the animation for the self-revealing interaction.</span></span> <span data-ttu-id="461ec-152">項目が選ばれているかどうかによって、アニメーションで説明される内容が変わります。選ばれていない場合はチェック マークが付き、選ばれている場合はチェック マークが付きません。</span><span class="sxs-lookup"><span data-stu-id="461ec-152">The selected state of the item affects what is revealed by the animation: a check mark if unselected and no check mark if selected.</span></span>

    ![選択されていない状態を示すスクリーン ショット。](images/crossslide-selfreveal1.png)

2.  <span data-ttu-id="461ec-154">スワイプ ジェスチャ (上または下) を使って項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="461ec-154">Select the item using the swipe gesture (up or down).</span></span>

    ![選択のアニメーションを示すスクリーン ショット。](images/crossslide-selfreveal2.png)

3.  <span data-ttu-id="461ec-156">この時点で、項目が選ばれています。</span><span class="sxs-lookup"><span data-stu-id="461ec-156">The item is now selected.</span></span> <span data-ttu-id="461ec-157">スライド ジェスチャを使って選択動作を上書きし、項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="461ec-157">Override the selection behavior using the slide gesture to move the item.</span></span>

    ![ドラッグ アンド ドロップのアニメーションを示すスクリーン ショット。](images/crossslide-selfreveal3.png)

<span data-ttu-id="461ec-159">主な操作が選択だけであるアプリケーションでは、選択にシングル タップを使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-159">Use a single tap for selection in applications where it is the only primary action.</span></span> <span data-ttu-id="461ec-160">この場合、アクティブ化やナビゲーションのための標準のタップ操作と区別するために、クロススライドの自己説明のアニメーションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-160">The cross-slide self-revealing animation is displayed to disambiguate this functionality from the standard tap interaction for activation and navigation.</span></span>

<span data-ttu-id="461ec-161">**バスケット**</span><span class="sxs-lookup"><span data-stu-id="461ec-161">**Selection basket**</span></span>

<span data-ttu-id="461ec-162">選択バスケットは、アプリの主要なリストやコレクションから選択された項目を視覚的に区別して動的に表す機能です。</span><span class="sxs-lookup"><span data-stu-id="461ec-162">The selection basket is a visually distinct and dynamic representation of items that have been selected from the primary list or collection in the application.</span></span> <span data-ttu-id="461ec-163">これは選択された項目の追跡に役立つ機能で、次のようなアプリで使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="461ec-163">This feature is useful for tracking selected items and should be used by applications where:</span></span>

-   <span data-ttu-id="461ec-164">項目を複数の場所から選択できる。</span><span class="sxs-lookup"><span data-stu-id="461ec-164">Items can be selected from multiple locations.</span></span>
-   <span data-ttu-id="461ec-165">複数の項目を選択できる。</span><span class="sxs-lookup"><span data-stu-id="461ec-165">Many items can be selected.</span></span>
-   <span data-ttu-id="461ec-166">選択リストによって操作やコマンドが異なる。</span><span class="sxs-lookup"><span data-stu-id="461ec-166">An action or command relies upon the selection list.</span></span>

<span data-ttu-id="461ec-167">選択バスケットの内容は、操作やコマンドの実行後も保持されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-167">The content of the selection basket persists across actions and commands.</span></span> <span data-ttu-id="461ec-168">たとえば、ギャラリーから一連の写真を選択して各写真に色補正を適用し、それらの写真を何らかの方法で共有した場合、それらの項目は選択されたままになります。</span><span class="sxs-lookup"><span data-stu-id="461ec-168">For example, if you select a series of photographs from a gallery, apply a color correction to each photograph, and share the photographs in some fashion, the items remain selected.</span></span>

<span data-ttu-id="461ec-169">アプリで選択バスケットを使わない場合は、操作やコマンドの実行後に現在の選択がクリアされます。</span><span class="sxs-lookup"><span data-stu-id="461ec-169">If no selection basket is used in an application, the current selection should be cleared after an action or command.</span></span> <span data-ttu-id="461ec-170">たとえば、再生リストから曲を選択して評価した後、その選択はクリアされます。</span><span class="sxs-lookup"><span data-stu-id="461ec-170">For example, if you select a song from a play list and rate it, the selection should be cleared.</span></span>

<span data-ttu-id="461ec-171">また、選択バスケットを使わない場合は、リストやコレクションで別の項目がアクティブ化されたときにも現在の選択がクリアされます。</span><span class="sxs-lookup"><span data-stu-id="461ec-171">The current selection should also be cleared when no selection basket is used and another item in the list or collection is activated.</span></span> <span data-ttu-id="461ec-172">たとえば、受信トレイのメッセージを選択すると、プレビュー ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-172">For example, if you select an inbox message, the preview pane is updated.</span></span> <span data-ttu-id="461ec-173">その後、受信トレイで別のメッセージを選択すると、前のメッセージの選択が取り消され、プレビュー ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="461ec-173">Then, if you select a second inbox message, the selection of the previous message is canceled and the preview pane is updated.</span></span>

<span data-ttu-id="461ec-174">**キュー**</span><span class="sxs-lookup"><span data-stu-id="461ec-174">**Queues**</span></span>

<span data-ttu-id="461ec-175">キューと選択バスケットのリストは異なるものであるため、混同しないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="461ec-175">A queue is not equivalent to the selection basket list and should not be treated as such.</span></span> <span data-ttu-id="461ec-176">主な違いは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="461ec-176">The primary distinctions include:</span></span>

-   <span data-ttu-id="461ec-177">選択バスケットの項目のリストは、視覚的に表すことだけを目的としたものです。キューの項目は、特定の操作を想定してまとめられたものです。</span><span class="sxs-lookup"><span data-stu-id="461ec-177">The list of items in the selection basket is only a visual representation; the items in a queue are assembled with a specific action in mind.</span></span>
-   <span data-ttu-id="461ec-178">選択バスケットでは同じ項目は 1 回しか表示できませんが、キューでは複数回表示できます。</span><span class="sxs-lookup"><span data-stu-id="461ec-178">Items can be represented only once in the selection basket but multiple times in a queue.</span></span>
-   <span data-ttu-id="461ec-179">選択バスケットの項目の順序は、選択の順序を表します。</span><span class="sxs-lookup"><span data-stu-id="461ec-179">The order of items in the selection basket represents the order of selection.</span></span> <span data-ttu-id="461ec-180">キューの項目の順序は、機能に直接関連します。</span><span class="sxs-lookup"><span data-stu-id="461ec-180">The order of items in a queue is directly related to functionality.</span></span>

<span data-ttu-id="461ec-181">これらの理由から、キューに項目を追加する目的でクロススライド選択操作を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="461ec-181">For these reasons, the cross-slide selection interaction should not be used to add items to a queue.</span></span> <span data-ttu-id="461ec-182">キューに項目を追加するときは、代わりにドラッグ操作を使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-182">Instead, items should be added to a queue through a drag action.</span></span>

### <span id="draganddrop"></span><span id="DRAGANDDROP"></span>

<span data-ttu-id="461ec-183">**ドラッグ**</span><span class="sxs-lookup"><span data-stu-id="461ec-183">**Drag**</span></span>

<span data-ttu-id="461ec-184">1 つまたは複数のオブジェクトを別の場所に移動するには、ドラッグを使います。</span><span class="sxs-lookup"><span data-stu-id="461ec-184">Use drag to move one or more objects from one location to another.</span></span>

<span data-ttu-id="461ec-185">複数のオブジェクトを移動する必要がある場合は、ユーザーが複数の項目を選択してから、すべてを同時にドラッグできるようにします。</span><span class="sxs-lookup"><span data-stu-id="461ec-185">If more than one object needs to be moved, let users select multiple items and then drag all at one time.</span></span>

## <a name="span-idrelatedtopicsspanrelated-articles"></a><span data-ttu-id="461ec-186"><span id="related_topics"></span>関連記事</span><span class="sxs-lookup"><span data-stu-id="461ec-186"><span id="related_topics"></span>Related articles</span></span>


<span data-ttu-id="461ec-187">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="461ec-187">**Samples**</span></span>
* [<span data-ttu-id="461ec-188">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-188">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="461ec-189">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-189">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="461ec-190">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-190">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* <span data-ttu-id="461ec-191">[フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)
**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="461ec-191">[Focus visuals sample](https://go.microsoft.com/fwlink/p/?LinkID=619895)
**Archive samples**</span></span>
* [<span data-ttu-id="461ec-192">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-192">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="461ec-193">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-193">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="461ec-194">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-194">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="461ec-195">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-195">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="461ec-196">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-196">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="461ec-197">入力:Windows 8 のジェスチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-197">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="461ec-198">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-198">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="461ec-199">DirectX のタッチ入力サンプル</span><span class="sxs-lookup"><span data-stu-id="461ec-199">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




