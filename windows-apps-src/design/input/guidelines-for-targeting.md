---
Description: このトピックでは、タッチ補正のための接触形状の使用について説明し、Windows ランタイム アプリでのターゲット設定のベスト プラクティスを紹介します。
title: ターゲット設定
ms.assetid: 93ad2232-97f3-42f5-9e45-3fc2143ac4d2
label: Targeting
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6e8425232512650d5c80bf6fee9745b261aee8d9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646057"
---
# <a name="guidelines-for-targeting"></a><span data-ttu-id="f986e-104">ターゲットの設定のガイドライン</span><span class="sxs-lookup"><span data-stu-id="f986e-104">Guidelines for targeting</span></span>


<span data-ttu-id="f986e-105">Windows のタッチ補正では、タッチ デジタイザーで検出されるそれぞれの指が接触する領域全体を使います。</span><span class="sxs-lookup"><span data-stu-id="f986e-105">Touch targeting in Windows uses the full contact area of each finger that is detected by a touch digitizer.</span></span> <span data-ttu-id="f986e-106">デジタイザーから伝えられる、より広く複雑なこの入力データのセットを使うと、ユーザーが意図した (または意図した可能性が高い) ターゲットをより正確に特定できます。</span><span class="sxs-lookup"><span data-stu-id="f986e-106">The larger, more complex set of input data reported by the digitizer is used to increase precision when determining the user's intended (or most likely) target.</span></span>

> <span data-ttu-id="f986e-107">**重要な API**:[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)、 [ **Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、 [ **Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="f986e-107">**Important APIs**: [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>

<span data-ttu-id="f986e-108">このトピックでは、タッチ補正のための接触形状の使用について説明し、UWP アプリでのターゲット設定のベスト プラクティスを紹介します。</span><span class="sxs-lookup"><span data-stu-id="f986e-108">This topic describes the use of contact geometry for touch targeting and provides best practices for targeting in UWP apps.</span></span>

## <a name="measurements-and-scaling"></a><span data-ttu-id="f986e-109">サイズと表示スケール</span><span class="sxs-lookup"><span data-stu-id="f986e-109">Measurements and scaling</span></span>


<span data-ttu-id="f986e-110">画面サイズとピクセル密度が変わっても一貫性が維持されるように、ターゲット サイズはすべて物理単位 (ミリメートル) で表されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-110">To remain consistent across different screen sizes and pixel densities, all target sizes are represented in physical units (millimeters).</span></span> <span data-ttu-id="f986e-111">物理単位は、次の式でピクセルに変換できます。</span><span class="sxs-lookup"><span data-stu-id="f986e-111">Physical units can be converted to pixels by using the following equation:</span></span>

<span data-ttu-id="f986e-112">ピクセル数 = ピクセル密度 × サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-112">Pixels = Pixel Density × Measurement</span></span>

<span data-ttu-id="f986e-113">次の例ではこの式を使って、135 ppi (pixel per inch) のディスプレイと 1x の表示スケール プラトーでの 9 mm ターゲットのピクセル サイズを計算します。</span><span class="sxs-lookup"><span data-stu-id="f986e-113">The following example uses this formula to calculate the pixel size of a 9 mm target on a 135 pixel per inch (PPI) display at a 1x scaling plateau:</span></span>

<span data-ttu-id="f986e-114">ピクセル数 = 135 ppi × 9 mm</span><span class="sxs-lookup"><span data-stu-id="f986e-114">Pixels = 135 PPI × 9 mm</span></span>

<span data-ttu-id="f986e-115">ピクセル数 = 135 ppi × (0.03937 インチ/mm × 9 mm)</span><span class="sxs-lookup"><span data-stu-id="f986e-115">Pixels = 135 PPI × (0.03937 inches per mm × 9 mm)</span></span>

<span data-ttu-id="f986e-116">ピクセル数 = 135 ppi × 0.35433 インチ</span><span class="sxs-lookup"><span data-stu-id="f986e-116">Pixels = 135 PPI × 0.35433 inches</span></span>

<span data-ttu-id="f986e-117">ピクセル数 = 48 ピクセル</span><span class="sxs-lookup"><span data-stu-id="f986e-117">Pixels = 48 pixels</span></span>

<span data-ttu-id="f986e-118">この結果は、システムで定義されている各表示スケール プラトーに従って調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f986e-118">This result must be adjusted according to each scaling plateau defined by the system.</span></span>

## <a name="thresholds"></a><span data-ttu-id="f986e-119">しきい値</span><span class="sxs-lookup"><span data-stu-id="f986e-119">Thresholds</span></span>


<span data-ttu-id="f986e-120">操作の結果を判断するために距離と時間のしきい値を使うことがあります。</span><span class="sxs-lookup"><span data-stu-id="f986e-120">Distance and time thresholds may be used to determine the outcome of an interaction.</span></span>

<span data-ttu-id="f986e-121">たとえば、タッチ ダウンが検出されたとき、オブジェクトがタッチ ダウン ポイントから 2.7 mm 未満の範囲でドラッグされて、タッチ ダウンから 0.1 秒以内に指が上げられた場合は、タップが登録されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-121">For example, when a touch-down is detected, a tap is registered if the object is dragged less than 2.7 mm from the touch-down point and the touch is lifted within 0.1 second or less of the touch-down.</span></span> <span data-ttu-id="f986e-122">この 2.7 mm のしきい値を超えて指を動かすと、オブジェクトはドラッグされ、選択または移動されます (詳しくは、「[クロススライドのガイドライン](guidelines-for-cross-slide.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f986e-122">Moving the finger beyond this 2.7 mm threshold results in the object being dragged and either selected or moved (for more information, see [Guidelines for cross-slide](guidelines-for-cross-slide.md)).</span></span> <span data-ttu-id="f986e-123">アプリによっては、0.1 秒より長く押し続けると自己説明操作が実行されることもあります (詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f986e-123">Depending on your app, holding the finger down for longer than 0.1 second may cause the system to perform a self-revealing interaction (for more information, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md)).</span></span>

## <a name="target-sizes"></a><span data-ttu-id="f986e-124">ターゲット サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-124">Target sizes</span></span>


<span data-ttu-id="f986e-125">一般に、タッチ ターゲットのサイズを一辺 9 mm 以上の正方形に設定します (1.0x のスケール プラトーで 135 ppi のディスプレイで 48x48 ピクセル)。</span><span class="sxs-lookup"><span data-stu-id="f986e-125">In general, set your touch target size to 9 mm square or greater (48x48 pixels on a 135 PPI display at a 1.0x scaling plateau).</span></span> <span data-ttu-id="f986e-126">一辺 7 mm 未満の正方形であるタッチ ターゲットを使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="f986e-126">Avoid using touch targets that are less than 7 mm square.</span></span>

<span data-ttu-id="f986e-127">次の図は、ターゲット サイズが一般には外観上のターゲット、実際のターゲット サイズ、実際のターゲットと他の指定可能なターゲットの間の余白の組み合わせで決まることを示しています。</span><span class="sxs-lookup"><span data-stu-id="f986e-127">The following diagram shows how target size is typically a combination of a visual target, actual target size, and any padding between the actual target and other potential targets.</span></span>

![外観上のターゲット、実際のターゲット、余白の推奨サイズを示す図。](images/targeting-size.png)

<span data-ttu-id="f986e-129">タッチ ターゲットのコンポーネントの最小サイズと推奨サイズを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="f986e-129">The following table lists the minimum and recommended sizes for the components of a touch target.</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f986e-130">ターゲット コンポーネント</span><span class="sxs-lookup"><span data-stu-id="f986e-130">Target component</span></span></th>
<th align="left"><span data-ttu-id="f986e-131">最小サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-131">Minimum size</span></span></th>
<th align="left"><span data-ttu-id="f986e-132">推奨サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-132">Recommended size</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="f986e-133">余白</span><span class="sxs-lookup"><span data-stu-id="f986e-133">Padding</span></span></td>
<td align="left"><span data-ttu-id="f986e-134">2 mm</span><span class="sxs-lookup"><span data-stu-id="f986e-134">2 mm</span></span></td>
<td align="left"><span data-ttu-id="f986e-135">適用できません。</span><span class="sxs-lookup"><span data-stu-id="f986e-135">Not applicable.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="f986e-136">外観上のターゲット サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-136">Visual target size</span></span></td>
<td align="left"><span data-ttu-id="f986e-137">&lt;実際のサイズの 60%</span><span class="sxs-lookup"><span data-stu-id="f986e-137">&lt; 60% of actual size</span></span></td>
<td align="left"><span data-ttu-id="f986e-138">実際のサイズの 90 ～ 100%</span><span class="sxs-lookup"><span data-stu-id="f986e-138">90-100% of actual size</span></span>
<p><span data-ttu-id="f986e-139">ほとんどのユーザーは一辺 4.2 mm の正方形 (7 mm の推奨の最小ターゲットのサイズの 60%) よりも小さい場合、外観上のターゲットがタッチ可能であると実感しません。</span><span class="sxs-lookup"><span data-stu-id="f986e-139">Most users won't realize a visual target is touchable if it's less than 4.2 mm square (60% of the recommended minimum target size of 7 mm).</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="f986e-140">実際のターゲット サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-140">Actual target size</span></span></td>
<td align="left"><span data-ttu-id="f986e-141">7 mm の正方形</span><span class="sxs-lookup"><span data-stu-id="f986e-141">7 mm square</span></span></td>
<td align="left"><span data-ttu-id="f986e-142">一辺 9 mm 以上の正方形 (48 x 48 ピクセル @ 1x)</span><span class="sxs-lookup"><span data-stu-id="f986e-142">Greater than or equal to 9 mm square (48 x 48 px @ 1x)</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="f986e-143">全体的なターゲット サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-143">Total target size</span></span></td>
<td align="left"><span data-ttu-id="f986e-144">11 x 11 mm (約 60 ピクセル: 3 個の 20 ピクセル グリッド @ 1x)</span><span class="sxs-lookup"><span data-stu-id="f986e-144">11 x 11 mm (approximately 60 px: three 20-px grid units @ 1x)</span></span></td>
<td align="left"><span data-ttu-id="f986e-145">13.5 x 13.5 mm (72 x 72 ピクセル @ 1x)</span><span class="sxs-lookup"><span data-stu-id="f986e-145">13.5 x 13.5 mm (72 x 72 px @ 1x)</span></span>
<p><span data-ttu-id="f986e-146">これは、実際のターゲットと余白を組み合わせたサイズをそれぞれの最小サイズより大きくする必要があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="f986e-146">This implies that the size of the actual target and padding combined should be larger than their respective minimums.</span></span></p></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="f986e-147">表に示したターゲット サイズの推奨サイズは、個々のシナリオの必要に応じて調整できます。</span><span class="sxs-lookup"><span data-stu-id="f986e-147">These target size recommendations can be adjusted as required by your particular scenario.</span></span> <span data-ttu-id="f986e-148">この推奨サイズの設定では、次の点が考慮されています。</span><span class="sxs-lookup"><span data-stu-id="f986e-148">Some of the considerations that went into these recommendations include:</span></span>

-   <span data-ttu-id="f986e-149">仕上げの頻度:繰り返しまたはよく押されている最小のサイズを超えるターゲットを検討してください。</span><span class="sxs-lookup"><span data-stu-id="f986e-149">Frequency of Touches: Consider making targets that are repeatedly or frequently pressed larger than the minimum size.</span></span>
-   <span data-ttu-id="f986e-150">エラー結果:エラーの場合は、重大な影響を及ぼすターゲットで大きい余白、コンテンツ エリアの端からかけ離れたものに配置します。</span><span class="sxs-lookup"><span data-stu-id="f986e-150">Error Consequence: Targets that have severe consequences if touched in error should have greater padding and be placed further from the edge of the content area.</span></span> <span data-ttu-id="f986e-151">特に当てはまるのは頻繁にタッチされるターゲットです。</span><span class="sxs-lookup"><span data-stu-id="f986e-151">This is especially true for targets that are touched frequently.</span></span>
-   <span data-ttu-id="f986e-152">コンテンツ領域での位置</span><span class="sxs-lookup"><span data-stu-id="f986e-152">Position in the content area</span></span>
-   <span data-ttu-id="f986e-153">フォーム ファクターと画面サイズ</span><span class="sxs-lookup"><span data-stu-id="f986e-153">Form factor and screen size</span></span>
-   <span data-ttu-id="f986e-154">指の位置</span><span class="sxs-lookup"><span data-stu-id="f986e-154">Finger posture</span></span>
-   <span data-ttu-id="f986e-155">タッチの視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="f986e-155">Touch visualizations</span></span>
-   <span data-ttu-id="f986e-156">ハードウェアとタッチ デジタイザー</span><span class="sxs-lookup"><span data-stu-id="f986e-156">Hardware and touch digitizers</span></span>

## <a name="targeting-assistance"></a><span data-ttu-id="f986e-157">ターゲット設定支援</span><span class="sxs-lookup"><span data-stu-id="f986e-157">Targeting assistance</span></span>


<span data-ttu-id="f986e-158">Windows では、ここで示した最小サイズや推奨する余白サイズを適用できない状況に対応するためのターゲット設定支援機能を提供しています。対象となるのは、Web ページ上のハイパーリンク、カレンダー コントロール、ドロップダウン リストとコンボ ボックス、テキスト選択などです。</span><span class="sxs-lookup"><span data-stu-id="f986e-158">Windows provides targeting assistance to support scenarios where the minimum size or padding recommendations presented here are not applicable; for example, hyperlinks on a webpage, calendar controls, drop down lists and combo boxes, or text selection.</span></span>

<span data-ttu-id="f986e-159">このようにターゲット設定プラットフォームを強化し、ユーザー インターフェイスの動作を視覚的なフィードバック (不明瞭解消 UI) と連携させることで、ユーザーがより正確に、また安心して操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="f986e-159">These targeting platform improvements and user interface behaviors work together with visual feedback (disambiguation UI) to improve user accuracy and confidence.</span></span> <span data-ttu-id="f986e-160">詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f986e-160">For more information, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>

<span data-ttu-id="f986e-161">タッチ可能な要素を推奨の最小ターゲット サイズより小さくする必要がある場合は、次のテクニックを使ってターゲット設定で発生する問題を最小化できます。</span><span class="sxs-lookup"><span data-stu-id="f986e-161">If a touchable element must be smaller than the recommended minimum target size, the following techniques can be used to minimize the targeting issues that result.</span></span>

## <a name="tethering"></a><span data-ttu-id="f986e-162">テザー</span><span class="sxs-lookup"><span data-stu-id="f986e-162">Tethering</span></span>


<span data-ttu-id="f986e-163">テザーとは、入力接点がオブジェクトに直接触れていなくても、ユーザーがそのオブジェクトにつながっているか操作していることをユーザーに示すために使われる視覚的な合図 (接点からオブジェクトの境界の四角形までを結ぶコネクタ) です。</span><span class="sxs-lookup"><span data-stu-id="f986e-163">Tethering is a visual cue (a connector from a contact point to the bounding rectangle of an object) used to indicate to a user that they are connected to, and interacting with, an object even though the input contact isn't directly in contact with the object.</span></span> <span data-ttu-id="f986e-164">テザーは次の場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="f986e-164">This can occur when:</span></span>

-   <span data-ttu-id="f986e-165">タッチによる接触がオブジェクトまでの近接しきい値の範囲内で最初に検出され、そのオブジェクトがそのタッチのターゲットとして最も可能性が高いと特定された場合。</span><span class="sxs-lookup"><span data-stu-id="f986e-165">A touch contact was first detected within some proximity threshold to an object and this object was identified as the most likely target of the contact.</span></span>
-   <span data-ttu-id="f986e-166">タッチによる接触がオブジェクトから離れたが、その接触が近接しきい値内にとどまっている場合。</span><span class="sxs-lookup"><span data-stu-id="f986e-166">A touch contact was moved off an object but the contact is still within a proximity threshold.</span></span>

<span data-ttu-id="f986e-167">この機能は、JavaScript を使った UWP アプリの開発者には公開されていません。</span><span class="sxs-lookup"><span data-stu-id="f986e-167">This feature is not exposed to UWP app using JavaScript developers.</span></span>

## <a name="scrubbing"></a><span data-ttu-id="f986e-168">スクラブ</span><span class="sxs-lookup"><span data-stu-id="f986e-168">Scrubbing</span></span>


<span data-ttu-id="f986e-169">スクラブとは、ターゲットのフィールド内をタッチし、そのまま指を持ち上げずに目的のターゲットまでスライドさせてそのターゲットを選ぶことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f986e-169">Scrubbing means to touch anywhere within a field of targets and slide to select the desired target without lifting the finger until it is over the desired target.</span></span> <span data-ttu-id="f986e-170">この操作は "指を離すことによるアクティブ化" とも呼ばれます。この場合、アクティブ化されるオブジェクトは、指が画面から離れたときに最後にタッチされたオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f986e-170">This is also referred to as "take-off activation", where the object that is activated is the one that was last touched when the finger was lifted from the screen.</span></span>

<span data-ttu-id="f986e-171">スクラブ操作を設計するときは、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="f986e-171">Use the following guidelines when you design scrubbing interactions:</span></span>

-   <span data-ttu-id="f986e-172">スクラブは、不明瞭解消 UI と併用します。</span><span class="sxs-lookup"><span data-stu-id="f986e-172">Scrubbing is used in conjunction with disambiguation UI.</span></span> <span data-ttu-id="f986e-173">詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f986e-173">For more information, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>
-   <span data-ttu-id="f986e-174">スクラブ対象のタッチ ターゲットの推奨最小サイズは、20 ピクセル (3.75 mm @ 1x サイズ) です。</span><span class="sxs-lookup"><span data-stu-id="f986e-174">The recommended minimum size for a scrubbing touch target is 20 px (3.75 mm @ 1x size).</span></span>
-   <span data-ttu-id="f986e-175">スクラブは、Web ページなどのパン対応サーフェイスで実行されたときに優先されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-175">Scrubbing takes precedence when performed on a pannable surface, such as a webpage.</span></span>
-   <span data-ttu-id="f986e-176">スクラブ対象ターゲットは互いに近づける必要があります。</span><span class="sxs-lookup"><span data-stu-id="f986e-176">Scrubbing targets should be close together.</span></span>
-   <span data-ttu-id="f986e-177">ユーザーがドラッグによってスクラブ対象ターゲットから指を離すと、操作は取り消されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-177">An action is canceled when the user drags a finger off a scrubbing target.</span></span>
-   <span data-ttu-id="f986e-178">ターゲットによって実行される操作が破棄的でなければ (カレンダーでの日付の切り替えなど)、スクラブ対象ターゲットに対してテザーが指定されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-178">Tethering to a scrubbing target is specified if the actions performed by the target are non-destructive, such as switching between dates on a calendar.</span></span>
-   <span data-ttu-id="f986e-179">テザーは、水平、垂直のいずれかの方向で指定されます。</span><span class="sxs-lookup"><span data-stu-id="f986e-179">Tethering is specified in a single direction, horizontally or vertically.</span></span>

## <a name="related-articles"></a><span data-ttu-id="f986e-180">関連記事</span><span class="sxs-lookup"><span data-stu-id="f986e-180">Related articles</span></span>


<span data-ttu-id="f986e-181">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="f986e-181">**Samples**</span></span>
* [<span data-ttu-id="f986e-182">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-182">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="f986e-183">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-183">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="f986e-184">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-184">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="f986e-185">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-185">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

<span data-ttu-id="f986e-186">**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="f986e-186">**Archive samples**</span></span>
* [<span data-ttu-id="f986e-187">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-187">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="f986e-188">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-188">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="f986e-189">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-189">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="f986e-190">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-190">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="f986e-191">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-191">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="f986e-192">入力:Windows 8 のジェスチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-192">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="f986e-193">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-193">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="f986e-194">DirectX のタッチ入力サンプル</span><span class="sxs-lookup"><span data-stu-id="f986e-194">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




