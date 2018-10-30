---
author: Karl-Bridge-Microsoft
Description: Create Universal Windows Platform (UWP) apps with intuitive and distinctive user interaction experiences that are optimized for touchpad but are functionally consistent across input devices.
title: タッチパッド操作
ms.assetid: CEDEA30A-FE94-4553-A7FB-6C1FA44F06AB
label: Touchpad interactions
template: detail.hbs
keywords: タッチパッド, PTP, タッチ, ポインター, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1c77e7a220618273e0fb8fb75cf3de2247534f5b
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5761452"
---
# <a name="touchpad-design-guidelines"></a><span data-ttu-id="725f4-103">タッチパッドの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="725f4-103">Touchpad design guidelines</span></span>


<span data-ttu-id="725f4-104">ユーザーがタッチパッドで操作できるようにアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="725f4-104">Design your app so that users can interact with it through a touchpad.</span></span> <span data-ttu-id="725f4-105">タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="725f4-105">A touchpad combines both indirect multi-touch input with the precision input of a pointing device, such as a mouse.</span></span> <span data-ttu-id="725f4-106">この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリのより小さいターゲットにも適しています。</span><span class="sxs-lookup"><span data-stu-id="725f4-106">This combination makes the touchpad suited to both a touch-optimized UI and the smaller targets of productivity apps.</span></span>

 

![タッチパッド](images/input-patterns/input-touchpad.jpg)


<span data-ttu-id="725f4-108">タッチパッド操作には、次の 3 つが必要です。</span><span class="sxs-lookup"><span data-stu-id="725f4-108">Touchpad interactions require three things:</span></span>

-   <span data-ttu-id="725f4-109">標準のタッチパッド、または Windows 高精度タッチパッド。</span><span class="sxs-lookup"><span data-stu-id="725f4-109">A standard touchpad or a Windows Precision Touchpad.</span></span>

    <span data-ttu-id="725f4-110">高精度タッチパッドは、ユニバーサル Windows プラットフォーム (UWP) デバイス向けに最適化されています。</span><span class="sxs-lookup"><span data-stu-id="725f4-110">Precision touchpads are optimized for Universal Windows Platform (UWP) devices.</span></span> <span data-ttu-id="725f4-111">高精度タッチパッドを使用すると、システムが指の追跡や手のひら検出などの一部のタッチパッド操作をネイティブに処理でき、さまざまなデバイス全体での一貫した操作を実現しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="725f4-111">They enable the system to handle certain aspects of the touchpad experience natively, such as finger tracking and palm detection, for a more consistent experience across devices.</span></span>

-   <span data-ttu-id="725f4-112">タッチパッドへの 1 本以上の指の直接的な接触。</span><span class="sxs-lookup"><span data-stu-id="725f4-112">The direct contact of one or more fingers on the touchpad.</span></span>
-   <span data-ttu-id="725f4-113">タッチ接触の動き (または、時間のしきい値に基づく動きの欠落)。</span><span class="sxs-lookup"><span data-stu-id="725f4-113">Movement of the touch contacts (or lack thereof, based on a time threshold).</span></span>

<span data-ttu-id="725f4-114">タッチパッド センサーから提供される入力データは、次のように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="725f4-114">The input data provided by the touchpad sensor can be:</span></span>

-   <span data-ttu-id="725f4-115">1 つ以上の UI 要素に直接的な操作 (パン、回転、サイズ変更、移動など) を行う物理的なジェスチャとして解釈する。</span><span class="sxs-lookup"><span data-stu-id="725f4-115">Interpreted as a physical gesture for direct manipulation of one or more UI elements (such as panning, rotating, resizing, or moving).</span></span> <span data-ttu-id="725f4-116">プロパティ ウィンドウやその他のダイアログ ボックスを通じた要素との対話的操作は、間接的な操作と見なされます。</span><span class="sxs-lookup"><span data-stu-id="725f4-116">In contrast, interacting with an element through its properties window or other dialog box is considered indirect manipulation.</span></span>
-   <span data-ttu-id="725f4-117">マウス、ペンなどの代替の入力方式として見なす。</span><span class="sxs-lookup"><span data-stu-id="725f4-117">Recognized as an alternative input method, such as mouse or pen.</span></span>
-   <span data-ttu-id="725f4-118">他の入力方法の外観を補完するために使う (ペンで描画したインク ストロークをこするなど)。</span><span class="sxs-lookup"><span data-stu-id="725f4-118">Used to complement or modify aspects of other input methods, such as smudging an ink stroke drawn with a pen.</span></span>

<span data-ttu-id="725f4-119">タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="725f4-119">A touchpad combines indirect multi-touch input with the precision input of a pointing device, such as a mouse.</span></span> <span data-ttu-id="725f4-120">この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリとデスクトップ環境で使用される一般的に小さなターゲットにも適しています。</span><span class="sxs-lookup"><span data-stu-id="725f4-120">This combination makes the touchpad suited to both touch-optimized UI and the typically smaller targets of productivity apps and the desktop environment.</span></span> <span data-ttu-id="725f4-121">UWP アプリの設計をタッチ入力用に最適化し、既定のタッチパッドのサポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="725f4-121">Optimize your UWP app design for touch input and get touchpad support by default.</span></span>

<span data-ttu-id="725f4-122">タッチパッドでサポートされている操作エクスペリエンスは複合的なので、[**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) イベントを使って、タッチ入力の組み込みサポートの他にマウス スタイル UI コマンドも提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="725f4-122">Because of the convergence of interaction experiences supported by touchpads, we recommend using the [**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) event to provide mouse-style UI commands in addition to the built-in support for touch input.</span></span> <span data-ttu-id="725f4-123">たとえば、コンテンツをパンするだけでなく、"前へ" ボタンと "次へ" ボタンを使ってコンテンツのページをフリップできるようにします。</span><span class="sxs-lookup"><span data-stu-id="725f4-123">For example, use previous and next buttons to let users flip through pages of content as well as pan through the content.</span></span>

<span data-ttu-id="725f4-124">このトピックで説明されているジェスチャとガイドラインを利用することで、アプリはタッチパッド入力を最小限のコードでシームレスにサポートできます。</span><span class="sxs-lookup"><span data-stu-id="725f4-124">The gestures and guidelines discussed in this topic can help to ensure that your app supports touchpad input seamlessly and with minimal code.</span></span>

## <a name="the-touchpad-language"></a><span data-ttu-id="725f4-125">タッチパッド言語</span><span class="sxs-lookup"><span data-stu-id="725f4-125">The touchpad language</span></span>


<span data-ttu-id="725f4-126">システム内では一貫して、タッチパッド操作の簡単なセットが使われます。</span><span class="sxs-lookup"><span data-stu-id="725f4-126">A concise set of touchpad interactions are used consistently throughout the system.</span></span> <span data-ttu-id="725f4-127">アプリをタッチとマウス入力用に最適化すると、ユーザーが慣れている操作感がこの言語によって実現されるので、信頼感が高まり、アプリの習得や使用も簡単になります。</span><span class="sxs-lookup"><span data-stu-id="725f4-127">Optimize your app for touch and mouse input and this language makes your app feel instantly familiar for your users, increasing their confidence and making your app easier to learn and use.</span></span>

<span data-ttu-id="725f4-128">高精度タッチパッドでは、標準のタッチパッドよりはるかに多くのジェスチャや操作の動作を設定できます。</span><span class="sxs-lookup"><span data-stu-id="725f4-128">Users can set far more Precision Touchpad gestures and interaction behaviors than they can for a standard touchpad.</span></span> <span data-ttu-id="725f4-129">次の 2 つの画像は、それぞれ標準のタッチパッドと高精度タッチパッドのさまざまなタッチパッド設定ページ ([設定] &gt; [デバイス] &gt; [マウスとタッチパッド]) を示しています。</span><span class="sxs-lookup"><span data-stu-id="725f4-129">These two images show the different touchpad settings pages from Settings &gt; Devices &gt; Mouse & touchpad for a standard touchpad and a Precision Touchpad, respectively.</span></span>

![標準のタッチパッドの設定](images/mouse-touchpad-settings-standard.png)

<sup><span data-ttu-id="725f4-131">標準の\\タッチパッドの\\設定</span><span class="sxs-lookup"><span data-stu-id="725f4-131">Standard\\ touchpad\\ settings</span></span></sup>

![Windows 高精度タッチパッドの設定](images/mouse-touchpad-settings-ptp.png)

<sup><span data-ttu-id="725f4-133">Windows\\ 高精度\\タッチパッドの\\設定</span><span class="sxs-lookup"><span data-stu-id="725f4-133">Windows\\ Precision\\ Touchpad\\ settings</span></span></sup>

<span data-ttu-id="725f4-134">以下に、一般的なタスクを実行するためのタッチパッドに最適化されたジェスチャの例を示します。</span><span class="sxs-lookup"><span data-stu-id="725f4-134">Here are some examples of touchpad-optimized gestures for performing common tasks.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="725f4-135">用語</span><span class="sxs-lookup"><span data-stu-id="725f4-135">Term</span></span></th>
<th align="left"><span data-ttu-id="725f4-136">説明</span><span class="sxs-lookup"><span data-stu-id="725f4-136">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="725f4-137">3 本指でのタップ</span><span class="sxs-lookup"><span data-stu-id="725f4-137">Three-finger tap</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-138"><strong>Cortana</strong> を使って検索、または<strong>アクション センター</strong>を表示するためのユーザー設定。</span><span class="sxs-lookup"><span data-stu-id="725f4-138">User preference to search with <strong>Cortana</strong> or show <strong>Action Center</strong>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="725f4-139">3 本指でのスライド</span><span class="sxs-lookup"><span data-stu-id="725f4-139">Three finger slide</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-140">仮想デスクトップのタスク ビュー開く、デスクトップを表示、または開いているアプリを切り替えるためのユーザー設定。</span><span class="sxs-lookup"><span data-stu-id="725f4-140">User preference to open the virtual desktop Task View, show Desktop, or switch between open apps.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="725f4-141">1 本指でのタップによるプライマリ操作</span><span class="sxs-lookup"><span data-stu-id="725f4-141">Single finger tap for primary action</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-142">1 本指を使って要素をタップすると、プライマリ操作 (アプリの起動、コマンドの実行など) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="725f4-142">Use a single finger to tap an element and invoke its primary action (such as launching an app or executing a command).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="725f4-143">2 本指でのタップによる右クリック</span><span class="sxs-lookup"><span data-stu-id="725f4-143">Two finger tap to right-click</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-144">要素を同時に 2 本の指でタップして、その要素を選択し、状況依存のコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="725f4-144">Tap with two fingers simultaneously on an element to select it and display contextual commands.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="725f4-145">2 本指でのスライドによるパン</span><span class="sxs-lookup"><span data-stu-id="725f4-145">Two finger slide to pan</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-146">スライドは主にパン操作に使われますが、移動、描画、筆記などの操作に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="725f4-146">Slide is used primarily for panning interactions but can also be used for moving, drawing, or writing.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="725f4-147">ピンチとストレッチによるズーム</span><span class="sxs-lookup"><span data-stu-id="725f4-147">Pinch and stretch to zoom</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-148">ピンチ ジェスチャとストレッチ ジェスチャは、通常、サイズ変更とセマンティック ズームに使われます。</span><span class="sxs-lookup"><span data-stu-id="725f4-148">The pinch and stretch gestures are commonly used for resizing and Semantic Zoom.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="725f4-149">1 本指でのプレスとスライドによる移動</span><span class="sxs-lookup"><span data-stu-id="725f4-149">Single finger press and slide to rearrange</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-150">要素をドラッグします。</span><span class="sxs-lookup"><span data-stu-id="725f4-150">Drag an element.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="725f4-151">1 本指でのプレスとスライドによるテキストの選択</span><span class="sxs-lookup"><span data-stu-id="725f4-151">Single finger press and slide to select text</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-152">選択可能なテキスト内を押してスライドし、選択します。</span><span class="sxs-lookup"><span data-stu-id="725f4-152">Press within selectable text and slide to select it.</span></span> <span data-ttu-id="725f4-153">単語を選択するには、ダブルタップします。</span><span class="sxs-lookup"><span data-stu-id="725f4-153">Double-tap to select a word.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="725f4-154">左と右のクリック ゾーン</span><span class="sxs-lookup"><span data-stu-id="725f4-154">Left and right click zone</span></span></p></td>
<td align="left"><p><span data-ttu-id="725f4-155">マウス デバイスの左ボタンと右ボタンの機能をエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="725f4-155">Emulate the left and right button functionality of a mouse device.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="hardware"></a><span data-ttu-id="725f4-156">ハードウェア</span><span class="sxs-lookup"><span data-stu-id="725f4-156">Hardware</span></span>


<span data-ttu-id="725f4-157">マウス デバイス機能 ([**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626)) を照会して、タッチパッド ハードウェアから直接アクセスできるアプリ UI の要素を識別します。</span><span class="sxs-lookup"><span data-stu-id="725f4-157">Query the mouse device capabilities ([**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626)) to identify what aspects of your app UI the touchpad hardware can access directly.</span></span> <span data-ttu-id="725f4-158">タッチ入力とマウス入力の両方の UI を用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="725f4-158">We recommend providing UI for both touch and mouse input.</span></span>

<span data-ttu-id="725f4-159">デバイス機能の照会について詳しくは、「[入力デバイスの識別](identify-input-devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="725f4-159">For more info about querying device capabilities, see [Identify input devices](identify-input-devices.md).</span></span>

## <a name="visual-feedback"></a><span data-ttu-id="725f4-160">視覚的なフィードバック</span><span class="sxs-lookup"><span data-stu-id="725f4-160">Visual feedback</span></span>


-   <span data-ttu-id="725f4-161">移動イベントまたはホバー イベントを通じてタッチパッド カーソルが検出されたら、マウス固有の UI を表示して、要素によって公開されている機能を示します。</span><span class="sxs-lookup"><span data-stu-id="725f4-161">When a touchpad cursor is detected (through move or hover events), show mouse-specific UI to indicate functionality exposed by the element.</span></span> <span data-ttu-id="725f4-162">タッチパッド カーソルが一定の期間動かされなかった場合や、ユーザーがタッチ操作を始めた場合は、タッチパッド UI を徐々に非表示にします。</span><span class="sxs-lookup"><span data-stu-id="725f4-162">If the touchpad cursor doesn't move for a certain amount of time, or if the user initiates a touch interaction, make the touchpad UI gradually fade away.</span></span> <span data-ttu-id="725f4-163">これにより、UI の簡潔さが保たれます。</span><span class="sxs-lookup"><span data-stu-id="725f4-163">This keeps the UI clean and uncluttered.</span></span>
-   <span data-ttu-id="725f4-164">ホバーのフィードバックにカーソルを使わないでください。要素によるフィードバックで十分です (以下の「カーソル」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="725f4-164">Don't use the cursor for hover feedback, the feedback provided by the element is sufficient (see the Cursors section below).</span></span>
-   <span data-ttu-id="725f4-165">静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。</span><span class="sxs-lookup"><span data-stu-id="725f4-165">Don't display visual feedback if an element doesn't support interaction (such as static text).</span></span>
-   <span data-ttu-id="725f4-166">タッチパッド操作ではフォーカス用の四角形を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="725f4-166">Don't use focus rectangles with touchpad interactions.</span></span> <span data-ttu-id="725f4-167">これはキーボード操作専用です。</span><span class="sxs-lookup"><span data-stu-id="725f4-167">Reserve these for keyboard interactions.</span></span>
-   <span data-ttu-id="725f4-168">同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示します。</span><span class="sxs-lookup"><span data-stu-id="725f4-168">Display visual feedback concurrently for all elements that represent the same input target.</span></span>

<span data-ttu-id="725f4-169">視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="725f4-169">For more general guidance about visual feedback, see [Guidelines for visual feedback](https://msdn.microsoft.com/library/windows/apps/hh465342).</span></span>

## <a name="cursors"></a><span data-ttu-id="725f4-170">カーソル</span><span class="sxs-lookup"><span data-stu-id="725f4-170">Cursors</span></span>


<span data-ttu-id="725f4-171">タッチパッド ポインターとして利用できる標準のカーソル セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="725f4-171">A set of standard cursors is available for a touchpad pointer.</span></span> <span data-ttu-id="725f4-172">これらが要素のプライマリ操作を示すために使われます。</span><span class="sxs-lookup"><span data-stu-id="725f4-172">These are used to indicate the primary action of an element.</span></span>

<span data-ttu-id="725f4-173">標準のカーソルには、それぞれ対応する既定の画像が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="725f4-173">Each standard cursor has a corresponding default image associated with it.</span></span> <span data-ttu-id="725f4-174">ユーザーまたはアプリは、標準のカーソルに関連付けられている既定の画像をいつでも変更できます。</span><span class="sxs-lookup"><span data-stu-id="725f4-174">The user or an app can replace the default image associated with any standard cursor at any time.</span></span> <span data-ttu-id="725f4-175">UWP アプリでは、[**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) 関数を使用して、カーソル画像を指定します。</span><span class="sxs-lookup"><span data-stu-id="725f4-175">UWP apps specify a cursor image through the [**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) function.</span></span>

<span data-ttu-id="725f4-176">マウス カーソルをカスタマイズする必要がある場合は、以下のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="725f4-176">If you need to customize the mouse cursor:</span></span>

-   <span data-ttu-id="725f4-177">クリック可能な要素には常に矢印カーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-177">Always use the arrow cursor (</span></span>![矢印カーソル](images/cursor-arrow.png)<span data-ttu-id="725f4-179">) を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-179">) for clickable elements.</span></span> <span data-ttu-id="725f4-180">リンクなどのインタラクティブな要素には手の形のポインティング カーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-180">don't use the pointing hand cursor (</span></span>![手の形のポインティング カーソル](images/cursor-pointinghand.png)<span data-ttu-id="725f4-182">) を使いません。</span><span class="sxs-lookup"><span data-stu-id="725f4-182">) for links or other interactive elements.</span></span> <span data-ttu-id="725f4-183">代わりに、前に説明したホバー効果を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-183">Instead, use hover effects (described earlier).</span></span>
-   <span data-ttu-id="725f4-184">選択可能なテキストにはテキスト カーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-184">Use the text cursor (</span></span>![テキスト カーソル](images/cursor-text.png)<span data-ttu-id="725f4-186">) を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-186">) for selectable text.</span></span>
-   <span data-ttu-id="725f4-187">ドラッグやトリミングなど、移動がメインの操作である場合は、移動カーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-187">Use the move cursor (</span></span>![移動カーソル](images/cursor-move.png)<span data-ttu-id="725f4-189">) を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-189">) when moving is the primary action (such as dragging or cropping).</span></span> <span data-ttu-id="725f4-190">スタート画面のタイルなどでのナビゲーションがメインの操作である場合は、要素に対して移動カーソルを使いません。</span><span class="sxs-lookup"><span data-stu-id="725f4-190">Don't use the move cursor for elements where the primary action is navigation (such as Start tiles).</span></span>
-   <span data-ttu-id="725f4-191">サイズ変更ができるオブジェクトに対しては、横、縦、対角線のサイズ変更カーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-191">Use the horizontal, vertical and diagonal resize cursors (</span></span>![縦のサイズ変更カーソル](images/cursor-vertical.png)<span data-ttu-id="725f4-193">,</span><span class="sxs-lookup"><span data-stu-id="725f4-193">,</span></span> ![横のサイズ変更カーソル](images/cursor-horizontal.png)<span data-ttu-id="725f4-195">,</span><span class="sxs-lookup"><span data-stu-id="725f4-195">,</span></span> ![対角線のサイズ変更カーソル (左下、右上)](images/cursor-diagonal2.png)<span data-ttu-id="725f4-197">,</span><span class="sxs-lookup"><span data-stu-id="725f4-197">,</span></span> ![対角線のサイズ変更カーソル (左上、右下)](images/cursor-diagonal1.png)<span data-ttu-id="725f4-199">) を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-199">), when an object is resizable.</span></span>
-   <span data-ttu-id="725f4-200">地図など、固定キャンバス内のコンテンツのパンを行うときは、手でつかむ形のカーソル (</span><span class="sxs-lookup"><span data-stu-id="725f4-200">Use the grasping hand cursors (</span></span>![手でつかむ形のカーソル (開いた状態)](images/cursor-pan1.png)<span data-ttu-id="725f4-202">,</span><span class="sxs-lookup"><span data-stu-id="725f4-202">,</span></span> ![手でつかむ形のカーソル (つかんだ状態)](images/cursor-pan2.png)<span data-ttu-id="725f4-204">) を使います。</span><span class="sxs-lookup"><span data-stu-id="725f4-204">) when panning content within a fixed canvas (such as a map).</span></span>

## <a name="related-articles"></a><span data-ttu-id="725f4-205">関連記事</span><span class="sxs-lookup"><span data-stu-id="725f4-205">Related articles</span></span>


* [<span data-ttu-id="725f4-206">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="725f4-206">Handle pointer input</span></span>](handle-pointer-input.md)
* <span data-ttu-id="725f4-207">[入力デバイスの識別](identify-input-devices.md)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="725f4-207">[Identify input devices](identify-input-devices.md)
**Samples**</span></span>
* [<span data-ttu-id="725f4-208">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-208">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="725f4-209">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-209">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="725f4-210">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-210">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* <span data-ttu-id="725f4-211">[フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)
**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="725f4-211">[Focus visuals sample](http://go.microsoft.com/fwlink/p/?LinkID=619895)
**Archive Samples**</span></span>
* [<span data-ttu-id="725f4-212">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-212">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="725f4-213">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-213">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="725f4-214">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="725f4-214">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="725f4-215">入力: GestureRecognizer によるジェスチャと操作</span><span class="sxs-lookup"><span data-stu-id="725f4-215">Input: Gestures and manipulations with GestureRecognizer</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231605)
 



