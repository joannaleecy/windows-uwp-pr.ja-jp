---
Description: アプリでマウス入力に応答するには、タッチ入力やペン入力で使うのと同じ基本的なポインター イベントを処理します。
title: マウス操作
ms.assetid: C8A158EF-70A9-4BA2-A270-7D08125700AC
label: Mouse
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: feef520614e1cc6076e6abc388fe419fe61d3a92
ms.sourcegitcommit: 7676d4b4c323e665302c2dfca3c763751a47afa3
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2019
ms.locfileid: "58343251"
---
# <a name="mouse-interactions"></a><span data-ttu-id="f53a8-104">マウス操作</span><span class="sxs-lookup"><span data-stu-id="f53a8-104">Mouse interactions</span></span>

<span data-ttu-id="f53a8-105">ユニバーサル Windows プラットフォーム (UWP) アプリの設計をタッチ入力用に最適化し、既定の基本的なマウスのサポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-105">Optimize your Universal Windows Platform (UWP) app design for touch input and get basic mouse support by default.</span></span> 

![マウス](images/input-patterns/input-mouse.jpg)

<span data-ttu-id="f53a8-107">マウス入力は、ポイントとクリックの正確さが求められるユーザー操作に最適です。</span><span class="sxs-lookup"><span data-stu-id="f53a8-107">Mouse input is best suited for user interactions that require precision when pointing and clicking.</span></span> <span data-ttu-id="f53a8-108">この固有の正確さは、タッチの本来の不正確さに合わせて最適化されている Windows の UI でも当然サポートされています。</span><span class="sxs-lookup"><span data-stu-id="f53a8-108">This inherent precision is naturally supported by the UI of Windows, which is optimized for the imprecise nature of touch.</span></span>

<span data-ttu-id="f53a8-109">マウス入力とタッチ入力が異なるのは、タッチでは UI 要素に対して直接実行される物理的なジェスチャ (スワイプ、スライド、ドラッグ、回転など) を通じて、それらのオブジェクトへの直接の操作をより正確にエミュレートする機能があることです。</span><span class="sxs-lookup"><span data-stu-id="f53a8-109">Where mouse and touch input diverge is the ability for touch to more closely emulate the direct manipulation of UI elements through physical gestures performed directly on those objects (such as swiping, sliding, dragging, rotating, and so on).</span></span> <span data-ttu-id="f53a8-110">マウスによる操作では、オブジェクトのサイズ変更や回転を実行するためにハンドルを使用するなど、他の UI アフォーダンスが必要になることが普通です。</span><span class="sxs-lookup"><span data-stu-id="f53a8-110">Manipulations with a mouse typically require some other UI affordance, such as the use of handles to resize or rotate an object.</span></span>

<span data-ttu-id="f53a8-111">このトピックでは、マウス操作の設計時の考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-111">This topic describes design considerations for mouse interactions.</span></span>

## <a name="the-uwp-app-mouse-language"></a><span data-ttu-id="f53a8-112">UWP アプリのマウス言語</span><span class="sxs-lookup"><span data-stu-id="f53a8-112">The UWP app mouse language</span></span>

<span data-ttu-id="f53a8-113">システム内では一貫して、マウス操作の簡単なセットが使われます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-113">A concise set of mouse interactions are used consistently throughout the system.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f53a8-114">用語</span><span class="sxs-lookup"><span data-stu-id="f53a8-114">Term</span></span></th>
<th align="left"><span data-ttu-id="f53a8-115">説明</span><span class="sxs-lookup"><span data-stu-id="f53a8-115">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f53a8-116">ホバーによる説明の表示</span><span class="sxs-lookup"><span data-stu-id="f53a8-116">Hover to learn</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-117">要素にホバーすると、詳しい情報や説明を伝える視覚効果 (ヒントなど) が表示されます。操作はコミットされません。</span><span class="sxs-lookup"><span data-stu-id="f53a8-117">Hover over an element to display more detailed info or teaching visuals (such as a tooltip) without a commitment to an action.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f53a8-118">左クリックによるプライマリ操作</span><span class="sxs-lookup"><span data-stu-id="f53a8-118">Left-click for primary action</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-119">要素の左クリックにより、プライマリ操作 (アプリの起動、コマンドの実行など) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-119">Left-click an element to invoke its primary action (such as launching an app or executing a command).</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f53a8-120">スクロールによるビューの変更</span><span class="sxs-lookup"><span data-stu-id="f53a8-120">Scroll to change view</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-121">スクロール バーを表示し、コンテンツ領域内で上下左右に移動します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-121">Display scroll bars to move up, down, left, and right within a content area.</span></span> <span data-ttu-id="f53a8-122">スクロール バーのクリック、またはマウス ホイールの回転により、スクロールできます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-122">Users can scroll by clicking scroll bars or rotating the mouse wheel.</span></span> <span data-ttu-id="f53a8-123">スクロール バーは、コンテンツ領域内の現在のビューの位置を示します (タッチによるパンでも同様の UI が表示されます)。</span><span class="sxs-lookup"><span data-stu-id="f53a8-123">Scroll bars can indicate the location of the current view within the content area (panning with touch displays a similar UI).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f53a8-124">右クリックによる選択とコマンド</span><span class="sxs-lookup"><span data-stu-id="f53a8-124">Right-click to select and command</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-125">右クリックして、ナビゲーション バー (使用できる場合) と、グローバル コマンドを含むアプリ バーを表示します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-125">Right-click to display the navigation bar (if available) and the app bar with global commands.</span></span> <span data-ttu-id="f53a8-126">要素を右クリックして選択し、その要素に対応する状況依存のコマンドを備えたアプリ バーを表示します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-126">Right-click an element to select it and display the app bar with contextual commands for the selected element.</span></span></p>
<div class="alert"><span data-ttu-id="f53a8-127">
<strong>注</strong>  選択またはアプリ バーのコマンドが適切な UI の動作ではない場合は、コンテキスト メニューを表示するを右クリックします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-127">
<strong>Note</strong>  Right-click to display a context menu if selection or app bar commands are not appropriate UI behaviors.</span></span> <span data-ttu-id="f53a8-128">ただし、すべてのコマンド動作にアプリ バーを使うことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-128">But we strongly recommend that you use the app bar for all command behaviors.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f53a8-129">ズームの UI コマンド</span><span class="sxs-lookup"><span data-stu-id="f53a8-129">UI commands to zoom</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-130">アプリ バーに UI コマンドを表示するか (+、- など)、Ctrl キーを押しながらマウス ホイールを回転させて、ズームのためのピンチ ジェスチャとストレッチ ジェスチャをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-130">Display UI commands in the app bar (such as + and -), or press Ctrl and rotate mouse wheel, to emulate pinch and stretch gestures for zooming.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f53a8-131">回転の UI コマンド</span><span class="sxs-lookup"><span data-stu-id="f53a8-131">UI commands to rotate</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-132">アプリ バーに UI コマンドを表示するか、Ctrl キーと Shift キーを押しながらマウス ホイールを回転させて、回転のための回転ジェスチャをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-132">Display UI commands in the app bar, or press Ctrl+Shift and rotate mouse wheel, to emulate the turn gesture for rotating.</span></span> <span data-ttu-id="f53a8-133">画面全体を回転させるには、デバイスを回転させます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-133">Rotate the device itself to rotate the entire screen.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f53a8-134">左クリックとドラッグによる移動</span><span class="sxs-lookup"><span data-stu-id="f53a8-134">Left-click and drag to rearrange</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-135">要素を左クリックしてドラッグし、移動します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-135">Left-click and drag an element to move it.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f53a8-136">左クリックとドラッグによるテキストの選択</span><span class="sxs-lookup"><span data-stu-id="f53a8-136">Left-click and drag to select text</span></span></p></td>
<td align="left"><p><span data-ttu-id="f53a8-137">選択可能なテキスト内を左クリックしてドラッグし、選択します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-137">Left-click within selectable text and drag to select it.</span></span> <span data-ttu-id="f53a8-138">単語を選択するには、ダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-138">Double-click to select a word.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="mouse-input-events"></a><span data-ttu-id="f53a8-139">マウス入力イベント</span><span class="sxs-lookup"><span data-stu-id="f53a8-139">Mouse input events</span></span>

<span data-ttu-id="f53a8-140">ほとんどのマウス入力がすべてでサポートされている共通のルーティングの入力イベントを処理できる[ **UIElement** ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f53a8-140">Most mouse input can be handled through the common routed input events supported by all [**UIElement**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) objects.</span></span> <span data-ttu-id="f53a8-141">次のようなクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="f53a8-141">These include:</span></span>

- [<span data-ttu-id="f53a8-142">**BringIntoViewRequested**</span><span class="sxs-lookup"><span data-stu-id="f53a8-142">**BringIntoViewRequested**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.bringintoviewrequested)
- [<span data-ttu-id="f53a8-143">**CharacterReceived**</span><span class="sxs-lookup"><span data-stu-id="f53a8-143">**CharacterReceived**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.characterreceived)
- [<span data-ttu-id="f53a8-144">**ContextCanceled**</span><span class="sxs-lookup"><span data-stu-id="f53a8-144">**ContextCanceled**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextcanceled)
- [<span data-ttu-id="f53a8-145">**ContextRequested**</span><span class="sxs-lookup"><span data-stu-id="f53a8-145">**ContextRequested**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextrequested)
- [<span data-ttu-id="f53a8-146">**DoubleTapped**</span><span class="sxs-lookup"><span data-stu-id="f53a8-146">**DoubleTapped**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.doubletapped)
- [<span data-ttu-id="f53a8-147">**DragEnter**</span><span class="sxs-lookup"><span data-stu-id="f53a8-147">**DragEnter**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.dragenter)
- [<span data-ttu-id="f53a8-148">**DragLeave**</span><span class="sxs-lookup"><span data-stu-id="f53a8-148">**DragLeave**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.dragleave)
- [<span data-ttu-id="f53a8-149">**DragOver**</span><span class="sxs-lookup"><span data-stu-id="f53a8-149">**DragOver**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.dragover)
- [<span data-ttu-id="f53a8-150">**DragStarting**</span><span class="sxs-lookup"><span data-stu-id="f53a8-150">**DragStarting**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.dragstarting)
- [<span data-ttu-id="f53a8-151">**ドロップ**</span><span class="sxs-lookup"><span data-stu-id="f53a8-151">**Drop**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.drop)
- [<span data-ttu-id="f53a8-152">**DropCompleted**</span><span class="sxs-lookup"><span data-stu-id="f53a8-152">**DropCompleted**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.dropcompleted)
- [<span data-ttu-id="f53a8-153">**GettingFocus**</span><span class="sxs-lookup"><span data-stu-id="f53a8-153">**GettingFocus**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.gettingfocus)
- [<span data-ttu-id="f53a8-154">**GotFocus**</span><span class="sxs-lookup"><span data-stu-id="f53a8-154">**GotFocus**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.gotfocus)
- [<span data-ttu-id="f53a8-155">**保持します。**</span><span class="sxs-lookup"><span data-stu-id="f53a8-155">**Holding**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.holding)
- [<span data-ttu-id="f53a8-156">**KeyDown**</span><span class="sxs-lookup"><span data-stu-id="f53a8-156">**KeyDown**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keydown)
- [<span data-ttu-id="f53a8-157">**KeyUp**</span><span class="sxs-lookup"><span data-stu-id="f53a8-157">**KeyUp**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keyup)
- [<span data-ttu-id="f53a8-158">**LosingFocus**</span><span class="sxs-lookup"><span data-stu-id="f53a8-158">**LosingFocus**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.losingfocus)
- [<span data-ttu-id="f53a8-159">**LostFocus**</span><span class="sxs-lookup"><span data-stu-id="f53a8-159">**LostFocus**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.lostfocus)
- [<span data-ttu-id="f53a8-160">**ManipulationCompleted**</span><span class="sxs-lookup"><span data-stu-id="f53a8-160">**ManipulationCompleted**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.manipulationcompleted)
- [<span data-ttu-id="f53a8-161">**ManipulationDelta**</span><span class="sxs-lookup"><span data-stu-id="f53a8-161">**ManipulationDelta**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.manipulationdelta)
- [<span data-ttu-id="f53a8-162">**ManipulationInertiaStarting**</span><span class="sxs-lookup"><span data-stu-id="f53a8-162">**ManipulationInertiaStarting**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.manipulationinertiastarting)
- [<span data-ttu-id="f53a8-163">**ManipulationStarted**</span><span class="sxs-lookup"><span data-stu-id="f53a8-163">**ManipulationStarted**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.manipulationstarted)
- [<span data-ttu-id="f53a8-164">**ManipulationStarting**</span><span class="sxs-lookup"><span data-stu-id="f53a8-164">**ManipulationStarting**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.manipulationstarting)
- [<span data-ttu-id="f53a8-165">**NoFocusCandidateFound**</span><span class="sxs-lookup"><span data-stu-id="f53a8-165">**NoFocusCandidateFound**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.nofocuscandidatefound)
- [<span data-ttu-id="f53a8-166">**PointerCanceled**</span><span class="sxs-lookup"><span data-stu-id="f53a8-166">**PointerCanceled**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointercanceled)
- [<span data-ttu-id="f53a8-167">**PointerCaptureLost**</span><span class="sxs-lookup"><span data-stu-id="f53a8-167">**PointerCaptureLost**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointercapturelost)
- [<span data-ttu-id="f53a8-168">**PointerEntered**</span><span class="sxs-lookup"><span data-stu-id="f53a8-168">**PointerEntered**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered)
- [<span data-ttu-id="f53a8-169">**PointerExited**</span><span class="sxs-lookup"><span data-stu-id="f53a8-169">**PointerExited**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited)
- [<span data-ttu-id="f53a8-170">**PointerMoved**</span><span class="sxs-lookup"><span data-stu-id="f53a8-170">**PointerMoved**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointermoved)
- [<span data-ttu-id="f53a8-171">**PointerPressed**</span><span class="sxs-lookup"><span data-stu-id="f53a8-171">**PointerPressed**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerpressed)
- [<span data-ttu-id="f53a8-172">**PointerReleased**</span><span class="sxs-lookup"><span data-stu-id="f53a8-172">**PointerReleased**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerreleased)
- [<span data-ttu-id="f53a8-173">**PointerWheelChanged**</span><span class="sxs-lookup"><span data-stu-id="f53a8-173">**PointerWheelChanged**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerwheelchanged)
- [<span data-ttu-id="f53a8-174">**PreviewKeyDown**</span><span class="sxs-lookup"><span data-stu-id="f53a8-174">**PreviewKeyDown**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.previewkeydown)
- [<span data-ttu-id="f53a8-175">**PreviewKeyUp**</span><span class="sxs-lookup"><span data-stu-id="f53a8-175">**PreviewKeyUp**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.previewkeyup)
- [<span data-ttu-id="f53a8-176">**PointerWheelChanged**</span><span class="sxs-lookup"><span data-stu-id="f53a8-176">**PointerWheelChanged**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerwheelchanged)
- [<span data-ttu-id="f53a8-177">**RightTapped**</span><span class="sxs-lookup"><span data-stu-id="f53a8-177">**RightTapped**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.righttapped)
- [<span data-ttu-id="f53a8-178">**タップ**</span><span class="sxs-lookup"><span data-stu-id="f53a8-178">**Tapped**</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.tapped)

<span data-ttu-id="f53a8-179">ただし、ポインター、ジェスチャ、および操作のイベントを使用して (マウス ホイール イベント) などの各デバイスの特定の機能を活用を行う[Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input)します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-179">However, you can take advantage of the specific capabilities of each device (such as mouse wheel events) using the pointer, gesture, and manipulation events in [Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input).</span></span>

<span data-ttu-id="f53a8-180">**サンプル:** 参照してください、 [BasicInput サンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)の。</span><span class="sxs-lookup"><span data-stu-id="f53a8-180">**Samples:** See our [BasicInput sample](https://go.microsoft.com/fwlink/p/?LinkID=620302), for .</span></span>

## <a name="guidelines-for-visual-feedback"></a><span data-ttu-id="f53a8-181">視覚的なフィードバックのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f53a8-181">Guidelines for visual feedback</span></span>

- <span data-ttu-id="f53a8-182">移動イベントまたはホバー イベントを通じてマウスが検出されたら、マウス固有の UI を表示して、要素によって公開されている機能を示します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-182">When a mouse is detected (through move or hover events), show mouse-specific UI to indicate functionality exposed by the element.</span></span> <span data-ttu-id="f53a8-183">マウスが一定の期間動かされなかった場合や、ユーザーがタッチ操作を始めた場合は、マウス UI を徐々に非表示にします。</span><span class="sxs-lookup"><span data-stu-id="f53a8-183">If the mouse doesn't move for a certain amount of time, or if the user initiates a touch interaction, make the mouse UI gradually fade away.</span></span> <span data-ttu-id="f53a8-184">これにより、UI の簡潔さが保たれます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-184">This keeps the UI clean and uncluttered.</span></span>
- <span data-ttu-id="f53a8-185">ホバーのフィードバックにカーソルを使わないでください。要素によるフィードバックで十分です (以下の「カーソル」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f53a8-185">Don't use the cursor for hover feedback, the feedback provided by the element is sufficient (see Cursors below).</span></span>
- <span data-ttu-id="f53a8-186">静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。</span><span class="sxs-lookup"><span data-stu-id="f53a8-186">Don't display visual feedback if an element doesn't support interaction (such as static text).</span></span>
- <span data-ttu-id="f53a8-187">マウス操作ではフォーカス用の四角形を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="f53a8-187">Don't use focus rectangles with mouse interactions.</span></span> <span data-ttu-id="f53a8-188">これはキーボード操作専用です。</span><span class="sxs-lookup"><span data-stu-id="f53a8-188">Reserve these for keyboard interactions.</span></span>
- <span data-ttu-id="f53a8-189">同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-189">Display visual feedback concurrently for all elements that represent the same input target.</span></span>
- <span data-ttu-id="f53a8-190">パン、回転、ズームなど、タッチ ベースの操作をエミュレートするためのボタンを提供します (+、- など)。</span><span class="sxs-lookup"><span data-stu-id="f53a8-190">Provide buttons (such as + and -) for emulating touch-based manipulations such as panning, rotating, zooming, and so on.</span></span>

<span data-ttu-id="f53a8-191">視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f53a8-191">For more general guidance on visual feedback, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>

## <a name="cursors"></a><span data-ttu-id="f53a8-192">カーソル</span><span class="sxs-lookup"><span data-stu-id="f53a8-192">Cursors</span></span>

<span data-ttu-id="f53a8-193">マウス ポインターとして利用できる標準のカーソル セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="f53a8-193">A set of standard cursors is available for a mouse pointer.</span></span> <span data-ttu-id="f53a8-194">これらが要素のプライマリ操作を示すために使われます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-194">These are used to indicate the primary action of an element.</span></span>

<span data-ttu-id="f53a8-195">標準のカーソルには、それぞれ対応する既定の画像が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="f53a8-195">Each standard cursor has a corresponding default image associated with it.</span></span> <span data-ttu-id="f53a8-196">ユーザーまたはアプリは、標準のカーソルに関連付けられている既定の画像をいつでも変更できます。</span><span class="sxs-lookup"><span data-stu-id="f53a8-196">The user or an app can replace the default image associated with any standard cursor at any time.</span></span> <span data-ttu-id="f53a8-197">カーソル画像は、[**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) 関数を使って指定します。</span><span class="sxs-lookup"><span data-stu-id="f53a8-197">Specify a cursor image through the [**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) function.</span></span>

<span data-ttu-id="f53a8-198">マウス カーソルをカスタマイズする必要がある場合は、以下のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="f53a8-198">If you need to customize the mouse cursor:</span></span>

- <span data-ttu-id="f53a8-199">クリック可能な要素には常に矢印カーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-199">Always use the arrow cursor (</span></span>![矢印カーソル](images/cursor-arrow.png)<span data-ttu-id="f53a8-201">) を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-201">) for clickable elements.</span></span> <span data-ttu-id="f53a8-202">リンクなどのインタラクティブな要素には手の形のポインティング カーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-202">don't use the pointing hand cursor (</span></span>![手の形のポインティング カーソル](images/cursor-pointinghand.png)<span data-ttu-id="f53a8-204">) を使いません。</span><span class="sxs-lookup"><span data-stu-id="f53a8-204">) for links or other interactive elements.</span></span> <span data-ttu-id="f53a8-205">代わりに、前に説明したホバー効果を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-205">Instead, use hover effects (described earlier).</span></span>
- <span data-ttu-id="f53a8-206">選択可能なテキストにはテキスト カーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-206">Use the text cursor (</span></span>![テキスト カーソル](images/cursor-text.png)<span data-ttu-id="f53a8-208">) を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-208">) for selectable text.</span></span>
- <span data-ttu-id="f53a8-209">ドラッグやトリミングなど、移動がメインの操作である場合は、移動カーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-209">Use the move cursor (</span></span>![移動カーソル](images/cursor-move.png)<span data-ttu-id="f53a8-211">) を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-211">) when moving is the primary action (such as dragging or cropping).</span></span> <span data-ttu-id="f53a8-212">スタート画面のタイルなどでのナビゲーションがメインの操作である場合は、要素に対して移動カーソルを使いません。</span><span class="sxs-lookup"><span data-stu-id="f53a8-212">Don't use the move cursor for elements where the primary action is navigation (such as Start tiles).</span></span>
- <span data-ttu-id="f53a8-213">サイズ変更ができるオブジェクトに対しては、横、縦、対角線のサイズ変更カーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-213">Use the horizontal, vertical and diagonal resize cursors (</span></span>![縦のサイズ変更カーソル](images/cursor-vertical.png)<span data-ttu-id="f53a8-215">、</span><span class="sxs-lookup"><span data-stu-id="f53a8-215">,</span></span> ![横のサイズ変更カーソル](images/cursor-horizontal.png)<span data-ttu-id="f53a8-217">、</span><span class="sxs-lookup"><span data-stu-id="f53a8-217">,</span></span> ![対角線のサイズ変更カーソル (左下、右上)](images/cursor-diagonal2.png)<span data-ttu-id="f53a8-219">、</span><span class="sxs-lookup"><span data-stu-id="f53a8-219">,</span></span> ![対角線のサイズ変更カーソル (左上、右下)](images/cursor-diagonal1.png)<span data-ttu-id="f53a8-221">) を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-221">), when an object is resizable.</span></span>
- <span data-ttu-id="f53a8-222">地図など、固定キャンバス内のコンテンツのパンを行うときは、手でつかむ形のカーソル (</span><span class="sxs-lookup"><span data-stu-id="f53a8-222">Use the grasping hand cursors (</span></span>![手でつかむ形のカーソル (開いた状態)](images/cursor-pan1.png)<span data-ttu-id="f53a8-224">、</span><span class="sxs-lookup"><span data-stu-id="f53a8-224">,</span></span> ![手でつかむ形のカーソル (つかんだ状態)](images/cursor-pan2.png)<span data-ttu-id="f53a8-226">) を使います。</span><span class="sxs-lookup"><span data-stu-id="f53a8-226">) when panning content within a fixed canvas (such as a map).</span></span>

## <a name="related-articles"></a><span data-ttu-id="f53a8-227">関連記事</span><span class="sxs-lookup"><span data-stu-id="f53a8-227">Related articles</span></span>

- [<span data-ttu-id="f53a8-228">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="f53a8-228">Handle pointer input</span></span>](handle-pointer-input.md)
- [<span data-ttu-id="f53a8-229">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="f53a8-229">Identify input devices</span></span>](identify-input-devices.md)
- [<span data-ttu-id="f53a8-230">イベントとルーティング イベントの概要</span><span class="sxs-lookup"><span data-stu-id="f53a8-230">Events and routed events overview</span></span>](https://docs.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)

### <a name="samples"></a><span data-ttu-id="f53a8-231">サンプル</span><span class="sxs-lookup"><span data-stu-id="f53a8-231">Samples</span></span>

- [<span data-ttu-id="f53a8-232">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="f53a8-232">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
- [<span data-ttu-id="f53a8-233">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="f53a8-233">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
- [<span data-ttu-id="f53a8-234">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="f53a8-234">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
- [<span data-ttu-id="f53a8-235">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="f53a8-235">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)