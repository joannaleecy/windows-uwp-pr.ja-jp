---
author: Karl-Bridge-Microsoft
Description: Respond to mouse input in your apps by handling the same basic pointer events that you use for touch and pen input.
title: マウス操作
ms.assetid: C8A158EF-70A9-4BA2-A270-7D08125700AC
label: Mouse
template: detail.hbs
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b79edc5499343498801081dd00554128c3b57eae
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5546244"
---
# <a name="mouse-interactions"></a><span data-ttu-id="3f7f0-103">マウス操作</span><span class="sxs-lookup"><span data-stu-id="3f7f0-103">Mouse interactions</span></span>


<span data-ttu-id="3f7f0-104">ユニバーサル Windows プラットフォーム (UWP) アプリの設計をタッチ入力用に最適化し、既定の基本的なマウスのサポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-104">Optimize your Universal Windows Platform (UWP) app design for touch input and get basic mouse support by default.</span></span>

 

![マウス](images/input-patterns/input-mouse.jpg)



<span data-ttu-id="3f7f0-106">マウス入力は、ポイントとクリックの正確さが求められるユーザー操作に最適です。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-106">Mouse input is best suited for user interactions that require precision when pointing and clicking.</span></span> <span data-ttu-id="3f7f0-107">この固有の正確さは、タッチの本来の不正確さに合わせて最適化されている Windows の UI でも当然サポートされています。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-107">This inherent precision is naturally supported by the UI of Windows, which is optimized for the imprecise nature of touch.</span></span>

<span data-ttu-id="3f7f0-108">マウス入力とタッチ入力が異なるのは、タッチでは UI 要素に対して直接実行される物理的なジェスチャ (スワイプ、スライド、ドラッグ、回転など) を通じて、それらのオブジェクトへの直接の操作をより正確にエミュレートする機能があることです。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-108">Where mouse and touch input diverge is the ability for touch to more closely emulate the direct manipulation of UI elements through physical gestures performed directly on those objects (such as swiping, sliding, dragging, rotating, and so on).</span></span> <span data-ttu-id="3f7f0-109">マウスによる操作では、オブジェクトのサイズ変更や回転を実行するためにハンドルを使用するなど、他の UI アフォーダンスが必要になることが普通です。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-109">Manipulations with a mouse typically require some other UI affordance, such as the use of handles to resize or rotate an object.</span></span>

<span data-ttu-id="3f7f0-110">このトピックでは、マウス操作の設計時の考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-110">This topic describes design considerations for mouse interactions.</span></span>

## <a name="the-uwp-app-mouse-language"></a><span data-ttu-id="3f7f0-111">UWP アプリのマウス言語</span><span class="sxs-lookup"><span data-stu-id="3f7f0-111">The UWP app mouse language</span></span>


<span data-ttu-id="3f7f0-112">システム内では一貫して、マウス操作の簡単なセットが使われます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-112">A concise set of mouse interactions are used consistently throughout the system.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="3f7f0-113">用語</span><span class="sxs-lookup"><span data-stu-id="3f7f0-113">Term</span></span></th>
<th align="left"><span data-ttu-id="3f7f0-114">説明</span><span class="sxs-lookup"><span data-stu-id="3f7f0-114">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3f7f0-115">ホバーによる説明の表示</span><span class="sxs-lookup"><span data-stu-id="3f7f0-115">Hover to learn</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-116">要素にホバーすると、詳しい情報や説明を伝える視覚効果 (ヒントなど) が表示されます。操作はコミットされません。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-116">Hover over an element to display more detailed info or teaching visuals (such as a tooltip) without a commitment to an action.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3f7f0-117">左クリックによるプライマリ操作</span><span class="sxs-lookup"><span data-stu-id="3f7f0-117">Left-click for primary action</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-118">要素の左クリックにより、プライマリ操作 (アプリの起動、コマンドの実行など) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-118">Left-click an element to invoke its primary action (such as launching an app or executing a command).</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3f7f0-119">スクロールによるビューの変更</span><span class="sxs-lookup"><span data-stu-id="3f7f0-119">Scroll to change view</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-120">スクロール バーを表示し、コンテンツ領域内で上下左右に移動します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-120">Display scroll bars to move up, down, left, and right within a content area.</span></span> <span data-ttu-id="3f7f0-121">スクロール バーのクリック、またはマウス ホイールの回転により、スクロールできます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-121">Users can scroll by clicking scroll bars or rotating the mouse wheel.</span></span> <span data-ttu-id="3f7f0-122">スクロール バーは、コンテンツ領域内の現在のビューの位置を示します (タッチによるパンでも同様の UI が表示されます)。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-122">Scroll bars can indicate the location of the current view within the content area (panning with touch displays a similar UI).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3f7f0-123">右クリックによる選択とコマンド</span><span class="sxs-lookup"><span data-stu-id="3f7f0-123">Right-click to select and command</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-124">右クリックして、ナビゲーション バー (使用できる場合) と、グローバル コマンドを含むアプリ バーを表示します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-124">Right-click to display the navigation bar (if available) and the app bar with global commands.</span></span> <span data-ttu-id="3f7f0-125">要素を右クリックして選択し、その要素に対応する状況依存のコマンドを備えたアプリ バーを表示します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-125">Right-click an element to select it and display the app bar with contextual commands for the selected element.</span></span></p>
<div class="alert"><span data-ttu-id="3f7f0-126">
<strong>注:</strong>選択コマンドやアプリ バー コマンドが適切な UI 動作ではない場合は、コンテキスト メニューを表示するを右クリックします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-126">
<strong>Note</strong>Right-click to display a context menu if selection or app bar commands are not appropriate UI behaviors.</span></span> <span data-ttu-id="3f7f0-127">ただし、すべてのコマンド動作にアプリ バーを使うことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-127">But we strongly recommend that you use the app bar for all command behaviors.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3f7f0-128">ズームの UI コマンド</span><span class="sxs-lookup"><span data-stu-id="3f7f0-128">UI commands to zoom</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-129">アプリ バーに UI コマンドを表示するか (+、- など)、Ctrl キーを押しながらマウス ホイールを回転させて、ズームのためのピンチ ジェスチャとストレッチ ジェスチャをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-129">Display UI commands in the app bar (such as + and -), or press Ctrl and rotate mouse wheel, to emulate pinch and stretch gestures for zooming.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3f7f0-130">回転の UI コマンド</span><span class="sxs-lookup"><span data-stu-id="3f7f0-130">UI commands to rotate</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-131">アプリ バーに UI コマンドを表示するか、Ctrl キーと Shift キーを押しながらマウス ホイールを回転させて、回転のための回転ジェスチャをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-131">Display UI commands in the app bar, or press Ctrl+Shift and rotate mouse wheel, to emulate the turn gesture for rotating.</span></span> <span data-ttu-id="3f7f0-132">画面全体を回転させるには、デバイスを回転させます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-132">Rotate the device itself to rotate the entire screen.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3f7f0-133">左クリックとドラッグによる移動</span><span class="sxs-lookup"><span data-stu-id="3f7f0-133">Left-click and drag to rearrange</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-134">要素を左クリックしてドラッグし、移動します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-134">Left-click and drag an element to move it.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3f7f0-135">左クリックとドラッグによるテキストの選択</span><span class="sxs-lookup"><span data-stu-id="3f7f0-135">Left-click and drag to select text</span></span></p></td>
<td align="left"><p><span data-ttu-id="3f7f0-136">選択可能なテキスト内を左クリックしてドラッグし、選択します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-136">Left-click within selectable text and drag to select it.</span></span> <span data-ttu-id="3f7f0-137">単語を選択するには、ダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-137">Double-click to select a word.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="mouse-events"></a><span data-ttu-id="3f7f0-138">マウス イベント</span><span class="sxs-lookup"><span data-stu-id="3f7f0-138">Mouse events</span></span>

<span data-ttu-id="3f7f0-139">アプリでマウス入力に応答するには、タッチ入力やペン入力で使うのと同じ基本的なポインター イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-139">Respond to mouse input in your apps by handling the same basic pointer events that you use for touch and pen input.</span></span>

<span data-ttu-id="3f7f0-140">[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) イベントを使うと、ポインター入力デバイスごとに別々のコードを記述しなくても、基本的な入力機能を実装できます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-140">Use [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) events to implement basic input functionality without having to write code for each pointer input device.</span></span> <span data-ttu-id="3f7f0-141">ただし、このオブジェクトのポインター イベント、ジェスチャ イベント、操作イベントを使って、各デバイスの特別な機能 (マウス ホイール イベントなど) を利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-141">However, you can still take advantage of the special capabilities of each device (such as mouse wheel events) using the pointer, gesture, and manipulation events of this object.</span></span>

<span data-ttu-id="3f7f0-142">**サンプル:** この機能では、[アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=264996)の動作を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-142">**Samples:** See this functionality in action in our [app samples](http://go.microsoft.com/fwlink/p/?LinkID=264996).</span></span>


- [<span data-ttu-id="3f7f0-143">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-143">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)

- [<span data-ttu-id="3f7f0-144">入力サンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-144">Input sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)

- [<span data-ttu-id="3f7f0-145">入力: GestureRecognizer によるジェスチャと操作</span><span class="sxs-lookup"><span data-stu-id="3f7f0-145">Input: Gestures and manipulations with GestureRecognizer</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231605)

## <a name="guidelines-for-visual-feedback"></a><span data-ttu-id="3f7f0-146">視覚的なフィードバックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="3f7f0-146">Guidelines for visual feedback</span></span>


-   <span data-ttu-id="3f7f0-147">移動イベントまたはホバー イベントを通じてマウスが検出されたら、マウス固有の UI を表示して、要素によって公開されている機能を示します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-147">When a mouse is detected (through move or hover events), show mouse-specific UI to indicate functionality exposed by the element.</span></span> <span data-ttu-id="3f7f0-148">マウスが一定の期間動かされなかった場合や、ユーザーがタッチ操作を始めた場合は、マウス UI を徐々に非表示にします。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-148">If the mouse doesn't move for a certain amount of time, or if the user initiates a touch interaction, make the mouse UI gradually fade away.</span></span> <span data-ttu-id="3f7f0-149">これにより、UI の簡潔さが保たれます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-149">This keeps the UI clean and uncluttered.</span></span>
-   <span data-ttu-id="3f7f0-150">ホバーのフィードバックにカーソルを使わないでください。要素によるフィードバックで十分です (以下の「カーソル」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-150">Don't use the cursor for hover feedback, the feedback provided by the element is sufficient (see Cursors below).</span></span>
-   <span data-ttu-id="3f7f0-151">静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-151">Don't display visual feedback if an element doesn't support interaction (such as static text).</span></span>
-   <span data-ttu-id="3f7f0-152">マウス操作ではフォーカス用の四角形を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-152">Don't use focus rectangles with mouse interactions.</span></span> <span data-ttu-id="3f7f0-153">これはキーボード操作専用です。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-153">Reserve these for keyboard interactions.</span></span>
-   <span data-ttu-id="3f7f0-154">同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-154">Display visual feedback concurrently for all elements that represent the same input target.</span></span>
-   <span data-ttu-id="3f7f0-155">パン、回転、ズームなど、タッチ ベースの操作をエミュレートするためのボタンを提供します (+、- など)。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-155">Provide buttons (such as + and -) for emulating touch-based manipulations such as panning, rotating, zooming, and so on.</span></span>

<span data-ttu-id="3f7f0-156">視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-156">For more general guidance on visual feedback, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>


## <a name="cursors"></a><span data-ttu-id="3f7f0-157">カーソル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-157">Cursors</span></span>


<span data-ttu-id="3f7f0-158">マウス ポインターとして利用できる標準のカーソル セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-158">A set of standard cursors is available for a mouse pointer.</span></span> <span data-ttu-id="3f7f0-159">これらが要素のプライマリ操作を示すために使われます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-159">These are used to indicate the primary action of an element.</span></span>

<span data-ttu-id="3f7f0-160">標準のカーソルには、それぞれ対応する既定の画像が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-160">Each standard cursor has a corresponding default image associated with it.</span></span> <span data-ttu-id="3f7f0-161">ユーザーまたはアプリは、標準のカーソルに関連付けられている既定の画像をいつでも変更できます。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-161">The user or an app can replace the default image associated with any standard cursor at any time.</span></span> <span data-ttu-id="3f7f0-162">カーソル画像は、[**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) 関数を使って指定します。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-162">Specify a cursor image through the [**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) function.</span></span>

<span data-ttu-id="3f7f0-163">マウス カーソルをカスタマイズする必要がある場合は、以下のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-163">If you need to customize the mouse cursor:</span></span>

-   <span data-ttu-id="3f7f0-164">クリック可能な要素には常に矢印カーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-164">Always use the arrow cursor (</span></span>![矢印カーソル](images/cursor-arrow.png)<span data-ttu-id="3f7f0-166">) を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-166">) for clickable elements.</span></span> <span data-ttu-id="3f7f0-167">リンクなどのインタラクティブな要素には手の形のポインティング カーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-167">don't use the pointing hand cursor (</span></span>![手の形のポインティング カーソル](images/cursor-pointinghand.png)<span data-ttu-id="3f7f0-169">) を使いません。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-169">) for links or other interactive elements.</span></span> <span data-ttu-id="3f7f0-170">代わりに、前に説明したホバー効果を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-170">Instead, use hover effects (described earlier).</span></span>
-   <span data-ttu-id="3f7f0-171">選択可能なテキストにはテキスト カーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-171">Use the text cursor (</span></span>![テキスト カーソル](images/cursor-text.png)<span data-ttu-id="3f7f0-173">) を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-173">) for selectable text.</span></span>
-   <span data-ttu-id="3f7f0-174">ドラッグやトリミングなど、移動がメインの操作である場合は、移動カーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-174">Use the move cursor (</span></span>![移動カーソル](images/cursor-move.png)<span data-ttu-id="3f7f0-176">) を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-176">) when moving is the primary action (such as dragging or cropping).</span></span> <span data-ttu-id="3f7f0-177">スタート画面のタイルなどでのナビゲーションがメインの操作である場合は、要素に対して移動カーソルを使いません。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-177">Don't use the move cursor for elements where the primary action is navigation (such as Start tiles).</span></span>
-   <span data-ttu-id="3f7f0-178">サイズ変更ができるオブジェクトに対しては、横、縦、対角線のサイズ変更カーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-178">Use the horizontal, vertical and diagonal resize cursors (</span></span>![縦のサイズ変更カーソル](images/cursor-vertical.png)<span data-ttu-id="3f7f0-180">,</span><span class="sxs-lookup"><span data-stu-id="3f7f0-180">,</span></span> ![横のサイズ変更カーソル](images/cursor-horizontal.png)<span data-ttu-id="3f7f0-182">,</span><span class="sxs-lookup"><span data-stu-id="3f7f0-182">,</span></span> ![対角線のサイズ変更カーソル (左下、右上)](images/cursor-diagonal2.png)<span data-ttu-id="3f7f0-184">,</span><span class="sxs-lookup"><span data-stu-id="3f7f0-184">,</span></span> ![対角線のサイズ変更カーソル (左上、右下)](images/cursor-diagonal1.png)<span data-ttu-id="3f7f0-186">) を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-186">), when an object is resizable.</span></span>
-   <span data-ttu-id="3f7f0-187">地図など、固定キャンバス内のコンテンツのパンを行うときは、手でつかむ形のカーソル (</span><span class="sxs-lookup"><span data-stu-id="3f7f0-187">Use the grasping hand cursors (</span></span>![手でつかむ形のカーソル (開いた状態)](images/cursor-pan1.png)<span data-ttu-id="3f7f0-189">,</span><span class="sxs-lookup"><span data-stu-id="3f7f0-189">,</span></span> ![手でつかむ形のカーソル (つかんだ状態)](images/cursor-pan2.png)<span data-ttu-id="3f7f0-191">) を使います。</span><span class="sxs-lookup"><span data-stu-id="3f7f0-191">) when panning content within a fixed canvas (such as a map).</span></span>

## <a name="related-articles"></a><span data-ttu-id="3f7f0-192">関連記事</span><span class="sxs-lookup"><span data-stu-id="3f7f0-192">Related articles</span></span>

* [<span data-ttu-id="3f7f0-193">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="3f7f0-193">Handle pointer input</span></span>](handle-pointer-input.md)
* [<span data-ttu-id="3f7f0-194">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="3f7f0-194">Identify input devices</span></span>](identify-input-devices.md)

**<span data-ttu-id="3f7f0-195">サンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-195">Samples</span></span>**
* [<span data-ttu-id="3f7f0-196">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-196">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="3f7f0-197">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-197">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="3f7f0-198">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-198">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="3f7f0-199">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-199">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="3f7f0-200">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="3f7f0-200">Archive Samples</span></span>**
* [<span data-ttu-id="3f7f0-201">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-201">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="3f7f0-202">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-202">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="3f7f0-203">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="3f7f0-203">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="3f7f0-204">入力: GestureRecognizer によるジェスチャと操作</span><span class="sxs-lookup"><span data-stu-id="3f7f0-204">Input: Gestures and manipulations with GestureRecognizer</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231605)
 
 

 




