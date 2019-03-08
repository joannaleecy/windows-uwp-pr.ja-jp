---
Description: タッチパッド向けに最適化される一方で、さまざまな入力デバイスで一貫した機能を提供する、直観的で独特なユーザー操作エクスペリエンスを備えたユニバーサル Windows プラットフォーム (UWP) アプリを作成します。
title: タッチパッド操作
ms.assetid: CEDEA30A-FE94-4553-A7FB-6C1FA44F06AB
label: Touchpad interactions
template: detail.hbs
keywords: タッチパッド, PTP, タッチ, ポインター, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 895bf1ffe4fc79a65fdf452235ee9466e91b7215
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593907"
---
# <a name="touchpad-design-guidelines"></a><span data-ttu-id="d8eca-104">タッチパッドの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="d8eca-104">Touchpad design guidelines</span></span>


<span data-ttu-id="d8eca-105">ユーザーがタッチパッドで操作できるようにアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-105">Design your app so that users can interact with it through a touchpad.</span></span> <span data-ttu-id="d8eca-106">タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="d8eca-106">A touchpad combines both indirect multi-touch input with the precision input of a pointing device, such as a mouse.</span></span> <span data-ttu-id="d8eca-107">この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリのより小さいターゲットにも適しています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-107">This combination makes the touchpad suited to both a touch-optimized UI and the smaller targets of productivity apps.</span></span>

 

![タッチパッド](images/input-patterns/input-touchpad.jpg)


<span data-ttu-id="d8eca-109">タッチパッド操作には、次の 3 つが必要です。</span><span class="sxs-lookup"><span data-stu-id="d8eca-109">Touchpad interactions require three things:</span></span>

-   <span data-ttu-id="d8eca-110">標準のタッチパッド、または Windows 高精度タッチパッド。</span><span class="sxs-lookup"><span data-stu-id="d8eca-110">A standard touchpad or a Windows Precision Touchpad.</span></span>

    <span data-ttu-id="d8eca-111">高精度タッチパッドは、ユニバーサル Windows プラットフォーム (UWP) デバイス向けに最適化されています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-111">Precision touchpads are optimized for Universal Windows Platform (UWP) devices.</span></span> <span data-ttu-id="d8eca-112">高精度タッチパッドを使用すると、システムが指の追跡や手のひら検出などの一部のタッチパッド操作をネイティブに処理でき、さまざまなデバイス全体での一貫した操作を実現しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="d8eca-112">They enable the system to handle certain aspects of the touchpad experience natively, such as finger tracking and palm detection, for a more consistent experience across devices.</span></span>

-   <span data-ttu-id="d8eca-113">タッチパッドへの 1 本以上の指の直接的な接触。</span><span class="sxs-lookup"><span data-stu-id="d8eca-113">The direct contact of one or more fingers on the touchpad.</span></span>
-   <span data-ttu-id="d8eca-114">タッチ接触の動き (または、時間のしきい値に基づく動きの欠落)。</span><span class="sxs-lookup"><span data-stu-id="d8eca-114">Movement of the touch contacts (or lack thereof, based on a time threshold).</span></span>

<span data-ttu-id="d8eca-115">タッチパッド センサーから提供される入力データは、次のように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-115">The input data provided by the touchpad sensor can be:</span></span>

-   <span data-ttu-id="d8eca-116">1 つ以上の UI 要素に直接的な操作 (パン、回転、サイズ変更、移動など) を行う物理的なジェスチャとして解釈する。</span><span class="sxs-lookup"><span data-stu-id="d8eca-116">Interpreted as a physical gesture for direct manipulation of one or more UI elements (such as panning, rotating, resizing, or moving).</span></span> <span data-ttu-id="d8eca-117">プロパティ ウィンドウやその他のダイアログ ボックスを通じた要素との対話的操作は、間接的な操作と見なされます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-117">In contrast, interacting with an element through its properties window or other dialog box is considered indirect manipulation.</span></span>
-   <span data-ttu-id="d8eca-118">マウス、ペンなどの代替の入力方式として見なす。</span><span class="sxs-lookup"><span data-stu-id="d8eca-118">Recognized as an alternative input method, such as mouse or pen.</span></span>
-   <span data-ttu-id="d8eca-119">他の入力方法の外観を補完するために使う (ペンで描画したインク ストロークをこするなど)。</span><span class="sxs-lookup"><span data-stu-id="d8eca-119">Used to complement or modify aspects of other input methods, such as smudging an ink stroke drawn with a pen.</span></span>

<span data-ttu-id="d8eca-120">タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="d8eca-120">A touchpad combines indirect multi-touch input with the precision input of a pointing device, such as a mouse.</span></span> <span data-ttu-id="d8eca-121">この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリとデスクトップ環境で使用される一般的に小さなターゲットにも適しています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-121">This combination makes the touchpad suited to both touch-optimized UI and the typically smaller targets of productivity apps and the desktop environment.</span></span> <span data-ttu-id="d8eca-122">UWP アプリの設計をタッチ入力用に最適化し、既定のタッチパッドのサポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-122">Optimize your UWP app design for touch input and get touchpad support by default.</span></span>

<span data-ttu-id="d8eca-123">タッチパッドでサポートされている操作エクスペリエンスは複合的なので、[**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) イベントを使って、タッチ入力の組み込みサポートの他にマウス スタイル UI コマンドも提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-123">Because of the convergence of interaction experiences supported by touchpads, we recommend using the [**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) event to provide mouse-style UI commands in addition to the built-in support for touch input.</span></span> <span data-ttu-id="d8eca-124">たとえば、コンテンツをパンするだけでなく、"前へ" ボタンと "次へ" ボタンを使ってコンテンツのページをフリップできるようにします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-124">For example, use previous and next buttons to let users flip through pages of content as well as pan through the content.</span></span>

<span data-ttu-id="d8eca-125">このトピックで説明されているジェスチャとガイドラインを利用することで、アプリはタッチパッド入力を最小限のコードでシームレスにサポートできます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-125">The gestures and guidelines discussed in this topic can help to ensure that your app supports touchpad input seamlessly and with minimal code.</span></span>

## <a name="the-touchpad-language"></a><span data-ttu-id="d8eca-126">タッチパッド言語</span><span class="sxs-lookup"><span data-stu-id="d8eca-126">The touchpad language</span></span>


<span data-ttu-id="d8eca-127">システム内では一貫して、タッチパッド操作の簡単なセットが使われます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-127">A concise set of touchpad interactions are used consistently throughout the system.</span></span> <span data-ttu-id="d8eca-128">アプリをタッチとマウス入力用に最適化すると、ユーザーが慣れている操作感がこの言語によって実現されるので、信頼感が高まり、アプリの習得や使用も簡単になります。</span><span class="sxs-lookup"><span data-stu-id="d8eca-128">Optimize your app for touch and mouse input and this language makes your app feel instantly familiar for your users, increasing their confidence and making your app easier to learn and use.</span></span>

<span data-ttu-id="d8eca-129">高精度タッチパッドでは、標準のタッチパッドよりはるかに多くのジェスチャや操作の動作を設定できます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-129">Users can set far more Precision Touchpad gestures and interaction behaviors than they can for a standard touchpad.</span></span> <span data-ttu-id="d8eca-130">次の 2 つの画像は、それぞれ標準のタッチパッドと高精度タッチパッドのさまざまなタッチパッド設定ページ ([設定] &gt; [デバイス] &gt; [マウスとタッチパッド]) を示しています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-130">These two images show the different touchpad settings pages from Settings &gt; Devices &gt; Mouse & touchpad for a standard touchpad and a Precision Touchpad, respectively.</span></span>

![標準のタッチパッドの設定](images/mouse-touchpad-settings-standard.png)

<span data-ttu-id="d8eca-132"><sup>標準\\タッチパッド\\設定</sup></span><span class="sxs-lookup"><span data-stu-id="d8eca-132"><sup>Standard\\ touchpad\\ settings</sup></span></span>

![Windows 高精度タッチパッドの設定](images/mouse-touchpad-settings-ptp.png)

<span data-ttu-id="d8eca-134"><sup>Windows\\精度\\タッチパッド\\設定</sup></span><span class="sxs-lookup"><span data-stu-id="d8eca-134"><sup>Windows\\ Precision\\ Touchpad\\ settings</sup></span></span>

<span data-ttu-id="d8eca-135">以下に、一般的なタスクを実行するためのタッチパッドに最適化されたジェスチャの例を示します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-135">Here are some examples of touchpad-optimized gestures for performing common tasks.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d8eca-136">用語</span><span class="sxs-lookup"><span data-stu-id="d8eca-136">Term</span></span></th>
<th align="left"><span data-ttu-id="d8eca-137">説明</span><span class="sxs-lookup"><span data-stu-id="d8eca-137">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="d8eca-138">3 本指でのタップ</span><span class="sxs-lookup"><span data-stu-id="d8eca-138">Three-finger tap</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-139"><strong>Cortana</strong> を使って検索、または<strong>アクション センター</strong>を表示するためのユーザー設定。</span><span class="sxs-lookup"><span data-stu-id="d8eca-139">User preference to search with <strong>Cortana</strong> or show <strong>Action Center</strong>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="d8eca-140">3 本指でのスライド</span><span class="sxs-lookup"><span data-stu-id="d8eca-140">Three finger slide</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-141">仮想デスクトップのタスク ビュー開く、デスクトップを表示、または開いているアプリを切り替えるためのユーザー設定。</span><span class="sxs-lookup"><span data-stu-id="d8eca-141">User preference to open the virtual desktop Task View, show Desktop, or switch between open apps.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="d8eca-142">1 本指でのタップによるプライマリ操作</span><span class="sxs-lookup"><span data-stu-id="d8eca-142">Single finger tap for primary action</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-143">1 本指を使って要素をタップすると、プライマリ操作 (アプリの起動、コマンドの実行など) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-143">Use a single finger to tap an element and invoke its primary action (such as launching an app or executing a command).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="d8eca-144">2 本指でのタップによる右クリック</span><span class="sxs-lookup"><span data-stu-id="d8eca-144">Two finger tap to right-click</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-145">要素を同時に 2 本の指でタップして、その要素を選択し、状況依存のコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-145">Tap with two fingers simultaneously on an element to select it and display contextual commands.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="d8eca-146">2 本指でのスライドによるパン</span><span class="sxs-lookup"><span data-stu-id="d8eca-146">Two finger slide to pan</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-147">スライドは主にパン操作に使われますが、移動、描画、筆記などの操作に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-147">Slide is used primarily for panning interactions but can also be used for moving, drawing, or writing.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="d8eca-148">ピンチとストレッチによるズーム</span><span class="sxs-lookup"><span data-stu-id="d8eca-148">Pinch and stretch to zoom</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-149">ピンチ ジェスチャとストレッチ ジェスチャは、通常、サイズ変更とセマンティック ズームに使われます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-149">The pinch and stretch gestures are commonly used for resizing and Semantic Zoom.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="d8eca-150">1 本指でのプレスとスライドによる移動</span><span class="sxs-lookup"><span data-stu-id="d8eca-150">Single finger press and slide to rearrange</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-151">要素をドラッグします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-151">Drag an element.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="d8eca-152">1 本指でのプレスとスライドによるテキストの選択</span><span class="sxs-lookup"><span data-stu-id="d8eca-152">Single finger press and slide to select text</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-153">選択可能なテキスト内を押してスライドし、選択します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-153">Press within selectable text and slide to select it.</span></span> <span data-ttu-id="d8eca-154">単語を選択するには、ダブルタップします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-154">Double-tap to select a word.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="d8eca-155">左と右のクリック ゾーン</span><span class="sxs-lookup"><span data-stu-id="d8eca-155">Left and right click zone</span></span></p></td>
<td align="left"><p><span data-ttu-id="d8eca-156">マウス デバイスの左ボタンと右ボタンの機能をエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-156">Emulate the left and right button functionality of a mouse device.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="hardware"></a><span data-ttu-id="d8eca-157">ハードウェア</span><span class="sxs-lookup"><span data-stu-id="d8eca-157">Hardware</span></span>


<span data-ttu-id="d8eca-158">マウス デバイス機能 ([**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626)) を照会して、タッチパッド ハードウェアから直接アクセスできるアプリ UI の要素を識別します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-158">Query the mouse device capabilities ([**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626)) to identify what aspects of your app UI the touchpad hardware can access directly.</span></span> <span data-ttu-id="d8eca-159">タッチ入力とマウス入力の両方の UI を用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-159">We recommend providing UI for both touch and mouse input.</span></span>

<span data-ttu-id="d8eca-160">デバイス機能の照会について詳しくは、「[入力デバイスの識別](identify-input-devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8eca-160">For more info about querying device capabilities, see [Identify input devices](identify-input-devices.md).</span></span>

## <a name="visual-feedback"></a><span data-ttu-id="d8eca-161">視覚的なフィードバック</span><span class="sxs-lookup"><span data-stu-id="d8eca-161">Visual feedback</span></span>


-   <span data-ttu-id="d8eca-162">移動イベントまたはホバー イベントを通じてタッチパッド カーソルが検出されたら、マウス固有の UI を表示して、要素によって公開されている機能を示します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-162">When a touchpad cursor is detected (through move or hover events), show mouse-specific UI to indicate functionality exposed by the element.</span></span> <span data-ttu-id="d8eca-163">タッチパッド カーソルが一定の期間動かされなかった場合や、ユーザーがタッチ操作を始めた場合は、タッチパッド UI を徐々に非表示にします。</span><span class="sxs-lookup"><span data-stu-id="d8eca-163">If the touchpad cursor doesn't move for a certain amount of time, or if the user initiates a touch interaction, make the touchpad UI gradually fade away.</span></span> <span data-ttu-id="d8eca-164">これにより、UI の簡潔さが保たれます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-164">This keeps the UI clean and uncluttered.</span></span>
-   <span data-ttu-id="d8eca-165">ホバーのフィードバックにカーソルを使わないでください。要素によるフィードバックで十分です (以下の「カーソル」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d8eca-165">Don't use the cursor for hover feedback, the feedback provided by the element is sufficient (see the Cursors section below).</span></span>
-   <span data-ttu-id="d8eca-166">静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。</span><span class="sxs-lookup"><span data-stu-id="d8eca-166">Don't display visual feedback if an element doesn't support interaction (such as static text).</span></span>
-   <span data-ttu-id="d8eca-167">タッチパッド操作ではフォーカス用の四角形を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="d8eca-167">Don't use focus rectangles with touchpad interactions.</span></span> <span data-ttu-id="d8eca-168">これはキーボード操作専用です。</span><span class="sxs-lookup"><span data-stu-id="d8eca-168">Reserve these for keyboard interactions.</span></span>
-   <span data-ttu-id="d8eca-169">同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-169">Display visual feedback concurrently for all elements that represent the same input target.</span></span>

<span data-ttu-id="d8eca-170">視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8eca-170">For more general guidance about visual feedback, see [Guidelines for visual feedback](https://msdn.microsoft.com/library/windows/apps/hh465342).</span></span>

## <a name="cursors"></a><span data-ttu-id="d8eca-171">カーソル</span><span class="sxs-lookup"><span data-stu-id="d8eca-171">Cursors</span></span>


<span data-ttu-id="d8eca-172">タッチパッド ポインターとして利用できる標準のカーソル セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-172">A set of standard cursors is available for a touchpad pointer.</span></span> <span data-ttu-id="d8eca-173">これらが要素のプライマリ操作を示すために使われます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-173">These are used to indicate the primary action of an element.</span></span>

<span data-ttu-id="d8eca-174">標準のカーソルには、それぞれ対応する既定の画像が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="d8eca-174">Each standard cursor has a corresponding default image associated with it.</span></span> <span data-ttu-id="d8eca-175">ユーザーまたはアプリは、標準のカーソルに関連付けられている既定の画像をいつでも変更できます。</span><span class="sxs-lookup"><span data-stu-id="d8eca-175">The user or an app can replace the default image associated with any standard cursor at any time.</span></span> <span data-ttu-id="d8eca-176">UWP アプリでは、[**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) 関数を使用して、カーソル画像を指定します。</span><span class="sxs-lookup"><span data-stu-id="d8eca-176">UWP apps specify a cursor image through the [**PointerCursor**](https://msdn.microsoft.com/library/windows/apps/br208273) function.</span></span>

<span data-ttu-id="d8eca-177">マウス カーソルをカスタマイズする必要がある場合は、以下のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="d8eca-177">If you need to customize the mouse cursor:</span></span>

-   <span data-ttu-id="d8eca-178">クリック可能な要素には常に矢印カーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-178">Always use the arrow cursor (</span></span>![矢印カーソル](images/cursor-arrow.png)<span data-ttu-id="d8eca-180">) を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-180">) for clickable elements.</span></span> <span data-ttu-id="d8eca-181">リンクなどのインタラクティブな要素には手の形のポインティング カーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-181">don't use the pointing hand cursor (</span></span>![手の形のポインティング カーソル](images/cursor-pointinghand.png)<span data-ttu-id="d8eca-183">) を使いません。</span><span class="sxs-lookup"><span data-stu-id="d8eca-183">) for links or other interactive elements.</span></span> <span data-ttu-id="d8eca-184">代わりに、前に説明したホバー効果を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-184">Instead, use hover effects (described earlier).</span></span>
-   <span data-ttu-id="d8eca-185">選択可能なテキストにはテキスト カーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-185">Use the text cursor (</span></span>![テキスト カーソル](images/cursor-text.png)<span data-ttu-id="d8eca-187">) を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-187">) for selectable text.</span></span>
-   <span data-ttu-id="d8eca-188">ドラッグやトリミングなど、移動がメインの操作である場合は、移動カーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-188">Use the move cursor (</span></span>![移動カーソル](images/cursor-move.png)<span data-ttu-id="d8eca-190">) を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-190">) when moving is the primary action (such as dragging or cropping).</span></span> <span data-ttu-id="d8eca-191">スタート画面のタイルなどでのナビゲーションがメインの操作である場合は、要素に対して移動カーソルを使いません。</span><span class="sxs-lookup"><span data-stu-id="d8eca-191">Don't use the move cursor for elements where the primary action is navigation (such as Start tiles).</span></span>
-   <span data-ttu-id="d8eca-192">サイズ変更ができるオブジェクトに対しては、横、縦、対角線のサイズ変更カーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-192">Use the horizontal, vertical and diagonal resize cursors (</span></span>![縦のサイズ変更カーソル](images/cursor-vertical.png)<span data-ttu-id="d8eca-194">,</span><span class="sxs-lookup"><span data-stu-id="d8eca-194">,</span></span> ![横のサイズ変更カーソル](images/cursor-horizontal.png)<span data-ttu-id="d8eca-196">,</span><span class="sxs-lookup"><span data-stu-id="d8eca-196">,</span></span> ![対角線のサイズ変更カーソル (左下、右上)](images/cursor-diagonal2.png)<span data-ttu-id="d8eca-198">,</span><span class="sxs-lookup"><span data-stu-id="d8eca-198">,</span></span> ![対角線のサイズ変更カーソル (左上、右下)](images/cursor-diagonal1.png)<span data-ttu-id="d8eca-200">) を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-200">), when an object is resizable.</span></span>
-   <span data-ttu-id="d8eca-201">地図など、固定キャンバス内のコンテンツのパンを行うときは、手でつかむ形のカーソル (</span><span class="sxs-lookup"><span data-stu-id="d8eca-201">Use the grasping hand cursors (</span></span>![手でつかむ形のカーソル (開いた状態)](images/cursor-pan1.png)<span data-ttu-id="d8eca-203">,</span><span class="sxs-lookup"><span data-stu-id="d8eca-203">,</span></span> ![手でつかむ形のカーソル (つかんだ状態)](images/cursor-pan2.png)<span data-ttu-id="d8eca-205">) を使います。</span><span class="sxs-lookup"><span data-stu-id="d8eca-205">) when panning content within a fixed canvas (such as a map).</span></span>

## <a name="related-articles"></a><span data-ttu-id="d8eca-206">関連記事</span><span class="sxs-lookup"><span data-stu-id="d8eca-206">Related articles</span></span>


* [<span data-ttu-id="d8eca-207">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="d8eca-207">Handle pointer input</span></span>](handle-pointer-input.md)
* <span data-ttu-id="d8eca-208">[入力デバイスの識別](identify-input-devices.md)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="d8eca-208">[Identify input devices](identify-input-devices.md)
**Samples**</span></span>
* [<span data-ttu-id="d8eca-209">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-209">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="d8eca-210">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-210">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="d8eca-211">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-211">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* <span data-ttu-id="d8eca-212">[フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)
**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="d8eca-212">[Focus visuals sample](https://go.microsoft.com/fwlink/p/?LinkID=619895)
**Archive Samples**</span></span>
* [<span data-ttu-id="d8eca-213">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-213">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="d8eca-214">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-214">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="d8eca-215">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="d8eca-215">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="d8eca-216">入力:ジェスチャと GestureRecognizer の操作</span><span class="sxs-lookup"><span data-stu-id="d8eca-216">Input: Gestures and manipulations with GestureRecognizer</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231605)
 



