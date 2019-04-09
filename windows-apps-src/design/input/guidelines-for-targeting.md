---
Description: このトピックでは、タッチ補正のための接触形状の使用について説明し、Windows ランタイム アプリでのターゲット設定のベスト プラクティスを紹介します。
title: ターゲット設定
ms.assetid: 93ad2232-97f3-42f5-9e45-3fc2143ac4d2
label: Targeting
template: detail.hbs
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 5c05b6686d31606a9510b1433339dc8829a52893
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59247180"
---
# <a name="guidelines-for-touch-targets"></a><span data-ttu-id="64686-104">タッチの対象とするためのガイドライン</span><span class="sxs-lookup"><span data-stu-id="64686-104">Guidelines for touch targets</span></span>

<span data-ttu-id="64686-105">ユニバーサル Windows プラットフォーム (UWP) アプリケーション内のすべての対話型 UI 要素を正確にアクセスして、デバイスの種類や入力方法に関係なく、使用するユーザーに十分な大きさにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="64686-105">All interactive UI elements in your Universal Windows Platform (UWP) application must be large enough for users to accurately access and use, regardless of device type or input method.</span></span>

<span data-ttu-id="64686-106">タッチ デジタイザーによって報告される入力データの大規模でより複雑なセットが決定に使用されるため、ターゲットのサイズとコントロールのレイアウトに関するさらに最適化を必要とタッチ入力 (およびタッチの連絡先情報 領域の比較的不正確な性質) をサポートしている、ユーザーの目的 (または最も可能性の高い) のターゲット。</span><span class="sxs-lookup"><span data-stu-id="64686-106">Supporting touch input (and the relatively imprecise nature of the touch contact area) requires further optimization with respect to target size and control layout as the larger, more complex set of input data reported by the touch digitizer is used to determine the user's intended (or most likely) target.</span></span>

<span data-ttu-id="64686-107">UWP コントロールのすべてでは、タッチの既定のターゲット サイズとは、快適な使いやすく、視覚的にバランスの取れたで魅力的なもののアプリを構築するためのレイアウトを設計し、信頼してもらいます。</span><span class="sxs-lookup"><span data-stu-id="64686-107">All UWP controls have been designed with default touch target sizes and layouts that enable you to build visually balanced and appealing apps that are comfortable, easy to use, and inspire confidence.</span></span>

<span data-ttu-id="64686-108">このトピックでプラットフォーム コントロールとカスタム コントロールの両方を使用して (必要があります、アプリに) 最大の使いやすさのアプリを設計するためにこれらの既定の動作を説明します。</span><span class="sxs-lookup"><span data-stu-id="64686-108">In this topic, we describe these default behaviors so you can design your app for maximum usability using both platform controls and custom controls (should your app require them).</span></span>

> <span data-ttu-id="64686-109">**重要な API**:[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)、 [ **Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、 [ **Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span><span class="sxs-lookup"><span data-stu-id="64686-109">**Important APIs**: [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)</span></span>

## <a name="fluent-standard-sizing"></a><span data-ttu-id="64686-110">標準の Fluent のサイズ変更</span><span class="sxs-lookup"><span data-stu-id="64686-110">Fluent Standard sizing</span></span>

<span data-ttu-id="64686-111">*標準のサイズ変更の Fluent*情報密度とユーザーの快適性のバランスを提供するが作成されました。</span><span class="sxs-lookup"><span data-stu-id="64686-111">*Fluent Standard sizing* was created to provide a balance between information density and user comfort.</span></span> <span data-ttu-id="64686-112">実際には、画面上のすべての項目は、UI 要素をグリッドに合わせるし、適切にスケーリングできますが、システム レベルのスケールに基づいて、40 x 40 有効ピクセル (epx) のターゲットに揃えます。</span><span class="sxs-lookup"><span data-stu-id="64686-112">Effectively, all items on the screen align to a 40x40 effective pixels (epx) target, which lets UI elements align to a grid and scale appropriately based on system level scaling.</span></span>

> [!NOTE]
><span data-ttu-id="64686-113">有効ピクセルとスケーリングの詳細については、次を参照してください[UWP アプリのデザインの概要。](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)</span><span class="sxs-lookup"><span data-stu-id="64686-113">For more info on effective pixels and scaling, see [Introduction to UWP app design](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)</span></span>
>
> <span data-ttu-id="64686-114">システム レベルのスケーリングの詳細については、次を参照してください。[配置、余白、パディング](../layout/alignment-margin-padding.md)します。</span><span class="sxs-lookup"><span data-stu-id="64686-114">For more info on system level scaling, see [Alignment, margin, padding](../layout/alignment-margin-padding.md).</span></span>

## <a name="fluent-compact-sizing"></a><span data-ttu-id="64686-115">Fluent のコンパクト サイズ変更</span><span class="sxs-lookup"><span data-stu-id="64686-115">Fluent Compact sizing</span></span>

<span data-ttu-id="64686-116">アプリケーションの情報密度の高いレベルを表示できる*Fluent コンパクト サイズ変更*します。</span><span class="sxs-lookup"><span data-stu-id="64686-116">Applications can display a higher level of information density with *Fluent Compact sizing*.</span></span> <span data-ttu-id="64686-117">Compact のサイズ変更は、厳密なグリッド システム レベルのスケールに基づいて、適切なスケールを整列する UI 要素を 32 x 32 epx ターゲットへの UI 要素を配置します。</span><span class="sxs-lookup"><span data-stu-id="64686-117">Compact sizing aligns UI elements to a 32x32 epx target, which lets UI elements to align to a tighter grid and scale appropriately based on system level scaling.</span></span>

### <a name="examples"></a><span data-ttu-id="64686-118">例</span><span class="sxs-lookup"><span data-stu-id="64686-118">Examples</span></span>

<span data-ttu-id="64686-119">Compact のサイズ変更は、ページまたはグリッド レベルで適用できます。</span><span class="sxs-lookup"><span data-stu-id="64686-119">Compact sizing can be applied at the page or grid level.</span></span>

### <a name="page-level"></a><span data-ttu-id="64686-120">ページレベルのロック</span><span class="sxs-lookup"><span data-stu-id="64686-120">Page level</span></span>

```xaml
<Page.Resources>
    <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
</Page.Resources>
```

### <a name="grid-level"></a><span data-ttu-id="64686-121">グリッド レベル</span><span class="sxs-lookup"><span data-stu-id="64686-121">Grid level</span></span>

```xaml
<Grid>
    <Grid.Resources>
        <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
    </Grid.Resources>
</Grid>
```

## <a name="target-size"></a><span data-ttu-id="64686-122">ターゲット サイズ</span><span class="sxs-lookup"><span data-stu-id="64686-122">Target size</span></span>

<span data-ttu-id="64686-123">一般に、タッチ、ターゲットのサイズを 7.5 mm 正方形の範囲 (x 頭打ちのスケーリングの 1.0 135 PPI ディスプレイで 40 x 40 ピクセル) に設定します。</span><span class="sxs-lookup"><span data-stu-id="64686-123">In general, set your touch target size to 7.5mm square range (40x40 pixels on a 135 PPI display at a 1.0x scaling plateau).</span></span> <span data-ttu-id="64686-124">通常、UWP コントロールの連携 7.5 mm タッチのターゲット (特定のコントロールと、一般的な使用パターンに基づいてこの異なることができます)。</span><span class="sxs-lookup"><span data-stu-id="64686-124">Typically, UWP controls align with 7.5mm touch target (this can vary based on the specific control and any common usage patterns).</span></span> <span data-ttu-id="64686-125">参照してください[サイズおよび密度の制御](../style/spacing.md)詳細。</span><span class="sxs-lookup"><span data-stu-id="64686-125">See [Control size and density](../style/spacing.md) for more detail.</span></span>

<span data-ttu-id="64686-126">表に示したターゲット サイズの推奨サイズは、個々のシナリオの必要に応じて調整できます。</span><span class="sxs-lookup"><span data-stu-id="64686-126">These target size recommendations can be adjusted as required by your particular scenario.</span></span> <span data-ttu-id="64686-127">考慮事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="64686-127">Here are some things to consider:</span></span>

- <span data-ttu-id="64686-128">繰り返しまたはよく押されている最小のサイズを超えるターゲット仕上げ - の頻度を検討しています。</span><span class="sxs-lookup"><span data-stu-id="64686-128">Frequency of Touches - consider making targets that are repeatedly or frequently pressed larger than the minimum size.</span></span>
- <span data-ttu-id="64686-129">エラー結果 - エラーの場合、重大な影響を及ぼすターゲットで大きい余白、コンテンツ エリアの端からかけ離れたものに配置します。</span><span class="sxs-lookup"><span data-stu-id="64686-129">Error Consequence - targets that have severe consequences if touched in error should have greater padding and be placed further from the edge of the content area.</span></span> <span data-ttu-id="64686-130">特に当てはまるのは頻繁にタッチされるターゲットです。</span><span class="sxs-lookup"><span data-stu-id="64686-130">This is especially true for targets that are touched frequently.</span></span>
- <span data-ttu-id="64686-131">コンテンツ領域内の位置。</span><span class="sxs-lookup"><span data-stu-id="64686-131">Position in the content area.</span></span>
- <span data-ttu-id="64686-132">要素や画面サイズを形成します。</span><span class="sxs-lookup"><span data-stu-id="64686-132">Form factor and screen size.</span></span>
- <span data-ttu-id="64686-133">本の指の状態。</span><span class="sxs-lookup"><span data-stu-id="64686-133">Finger posture.</span></span>
- <span data-ttu-id="64686-134">視覚エフェクトをタッチします。</span><span class="sxs-lookup"><span data-stu-id="64686-134">Touch visualizations.</span></span>

## <a name="related-articles"></a><span data-ttu-id="64686-135">関連記事</span><span class="sxs-lookup"><span data-stu-id="64686-135">Related articles</span></span>

- [<span data-ttu-id="64686-136">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="64686-136">Introduction to UWP app design</span></span>](../basics/design-and-ui-intro.md)
- [<span data-ttu-id="64686-137">コントロールのサイズおよび密度</span><span class="sxs-lookup"><span data-stu-id="64686-137">Control size and density</span></span>](../style/spacing.md)
- [<span data-ttu-id="64686-138">配置、余白、パディング</span><span class="sxs-lookup"><span data-stu-id="64686-138">Alignment, margin, padding</span></span>](../layout/alignment-margin-padding.md)

### <a name="samples"></a><span data-ttu-id="64686-139">サンプル</span><span class="sxs-lookup"><span data-stu-id="64686-139">Samples</span></span>

- [<span data-ttu-id="64686-140">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-140">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
- [<span data-ttu-id="64686-141">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-141">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
- [<span data-ttu-id="64686-142">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-142">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
- [<span data-ttu-id="64686-143">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-143">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

### <a name="archive-samples"></a><span data-ttu-id="64686-144">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="64686-144">Archive samples</span></span>

- [<span data-ttu-id="64686-145">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-145">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
- [<span data-ttu-id="64686-146">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-146">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
- [<span data-ttu-id="64686-147">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-147">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
- [<span data-ttu-id="64686-148">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="64686-148">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
- [<span data-ttu-id="64686-149">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-149">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
- [<span data-ttu-id="64686-150">入力:Windows 8 のジェスチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-150">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
- [<span data-ttu-id="64686-151">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-151">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
- [<span data-ttu-id="64686-152">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="64686-152">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
