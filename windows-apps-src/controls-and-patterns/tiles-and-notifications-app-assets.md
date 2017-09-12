---
author: mijacobs
Description: "Windows 10 オペレーティング システム全体でさまざまな形式で表示される、アプリ アイコン アセットは、ユニバーサル Windows プラットフォーム (UWP) アプリの名刺です。"
title: "タイルとアイコン アセット"
ms.assetid: D6CE21E5-2CFA-404F-8679-36AA522206C7
label: Tile and icon assets
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 54ad78d5799a96ddcec7b060704ee198e0bf8db5
ms.sourcegitcommit: 9a1310468970c8d1ade0fb200126dff56ea8c9e1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/14/2017
---
# <a name="guidelines-for-tile-and-icon-assets"></a><span data-ttu-id="f2ac9-104">タイルとアイコン アセットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f2ac9-104">Guidelines for tile and icon assets</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


<span data-ttu-id="f2ac9-105">Windows 10 オペレーティング システム全体でさまざまな形式で表示される、アプリ アイコン アセットは、ユニバーサル Windows プラットフォーム (UWP) アプリの名刺です。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-105">App icon assets, which appear in a variety of forms throughout the Windows 10 operating system, are the calling cards for your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="f2ac9-106">このガイドラインでは、システム内でアプリ アイコン アセットが表示される場所の詳細について説明し、最も洗練されたアイコンを作成する方法に関して詳細なデザインのヒントを提供します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-106">These guidelines detail where app icon assets appear in the system, and provide in-depth design tips on how to create the most polished icons.</span></span>

![Windows 10 のスタート画面とタイル](images/assetguidance01.jpg)

## <a name="adaptive-scaling"></a><span data-ttu-id="f2ac9-108">アダプティブ スケーリング</span><span class="sxs-lookup"><span data-stu-id="f2ac9-108">Adaptive scaling</span></span>


<span data-ttu-id="f2ac9-109">まず、スケーリングとアセットがどのように連携しているかを深く理解するために、アダプティブ スケーリングの概要について簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-109">First, a brief overview on adaptive scaling to better understand how scaling works with assets.</span></span> <span data-ttu-id="f2ac9-110">Windows 10 には、既存のスケーリング モデルの進化形が導入されています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-110">Windows 10 introduces an evolution of the existing scaling model.</span></span> <span data-ttu-id="f2ac9-111">表示スケール ベクター コンテンツに加えて、さまざまな画面サイズと画面の解像度で UI 要素に一貫したサイズを提供するスケール ファクターの統合されたセットがあります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-111">In addition to scaling vector content, there is a unified set of scale factors that provides a consistent size for UI elements across a variety of screen sizes and display resolutions.</span></span> <span data-ttu-id="f2ac9-112">スケール ファクターは、iOS や Android などの他のオペレーティング システムのスケール ファクターとも互換性があり、これにより、こうしたプラットフォーム間でのアセットの共有が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-112">The scale factors are also compatible with the scale factors of other operating systems such as iOS and Android, which makes it easier to share assets between these platforms.</span></span>

<span data-ttu-id="f2ac9-113">ストアでは、デバイスの DPI の一部に基づいて、ダウンロードするアセットが選ばれます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-113">The Store picks the assets to download based in part of the DPI of the device.</span></span> <span data-ttu-id="f2ac9-114">デバイスに最適なアセットのみがダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-114">Only the assets that best match the device are downloaded.</span></span>

## <a name="tile-elements"></a><span data-ttu-id="f2ac9-115">タイル要素</span><span class="sxs-lookup"><span data-stu-id="f2ac9-115">Tile elements</span></span>


<span data-ttu-id="f2ac9-116">スタート画面のタイルの基本コンポーネントは、バック プレート、アイコン、ブランド バー、余白、およびアプリのタイトルで構成されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-116">The basic components of a Start tile consist of a back plate, an icon, a branding bar, margins, and an app title:</span></span>

![タイルの要素の詳細](images/assetguidance02.png)

<span data-ttu-id="f2ac9-118">タイルの下部にあるブランド バーは、アプリ名、バッジ、カウンター (使用する場合) が表示される場所です。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-118">The branding bar at the bottom of a tile is where the app name, badging, and counter (if used) appear:</span></span>

![タイルのブランド バー](images/assetguidance03.png)

<span data-ttu-id="f2ac9-120">ブランドのバーの高さは、表示されているデバイスの倍率に基づいています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-120">The height of the branding bar is based on the scale factor of the device on which it appears:</span></span>

| <span data-ttu-id="f2ac9-121">倍率</span><span class="sxs-lookup"><span data-stu-id="f2ac9-121">Scale factor</span></span> | <span data-ttu-id="f2ac9-122">ピクセル</span><span class="sxs-lookup"><span data-stu-id="f2ac9-122">Pixels</span></span> |
|--------------|--------|
| <span data-ttu-id="f2ac9-123">100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-123">100%</span></span>         | <span data-ttu-id="f2ac9-124">32</span><span class="sxs-lookup"><span data-stu-id="f2ac9-124">32</span></span>     |
| <span data-ttu-id="f2ac9-125">125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-125">125%</span></span>         | <span data-ttu-id="f2ac9-126">40</span><span class="sxs-lookup"><span data-stu-id="f2ac9-126">40</span></span>     |
| <span data-ttu-id="f2ac9-127">150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-127">150%</span></span>         | <span data-ttu-id="f2ac9-128">48</span><span class="sxs-lookup"><span data-stu-id="f2ac9-128">48</span></span>     |
| <span data-ttu-id="f2ac9-129">200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-129">200%</span></span>         | <span data-ttu-id="f2ac9-130">64</span><span class="sxs-lookup"><span data-stu-id="f2ac9-130">64</span></span>     |
| <span data-ttu-id="f2ac9-131">400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-131">400%</span></span>         | <span data-ttu-id="f2ac9-132">128</span><span class="sxs-lookup"><span data-stu-id="f2ac9-132">128</span></span>    |

 

<span data-ttu-id="f2ac9-133">タイルの余白はシステムによって設定され、変更できません。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-133">The system sets tile margins and cannot be modified.</span></span> <span data-ttu-id="f2ac9-134">次の例で示すように、コンテンツのほとんどが余白の内側に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-134">Most content appears inside the margins, as seen in this example:</span></span>

![タイルの余白](images/assetguidance04.png)

<span data-ttu-id="f2ac9-136">余白の幅は、表示されているデバイスの倍率に基づいています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-136">Margin width is based on the scale factor of the device on which it appears:</span></span>

| <span data-ttu-id="f2ac9-137">倍率</span><span class="sxs-lookup"><span data-stu-id="f2ac9-137">Scale factor</span></span> | <span data-ttu-id="f2ac9-138">ピクセル</span><span class="sxs-lookup"><span data-stu-id="f2ac9-138">Pixels</span></span> |
|--------------|--------|
| <span data-ttu-id="f2ac9-139">100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-139">100%</span></span>         | <span data-ttu-id="f2ac9-140">8</span><span class="sxs-lookup"><span data-stu-id="f2ac9-140">8</span></span>      |
| <span data-ttu-id="f2ac9-141">125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-141">125%</span></span>         | <span data-ttu-id="f2ac9-142">10</span><span class="sxs-lookup"><span data-stu-id="f2ac9-142">10</span></span>     |
| <span data-ttu-id="f2ac9-143">150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-143">150%</span></span>         | <span data-ttu-id="f2ac9-144">12</span><span class="sxs-lookup"><span data-stu-id="f2ac9-144">12</span></span>     |
| <span data-ttu-id="f2ac9-145">200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-145">200%</span></span>         | <span data-ttu-id="f2ac9-146">16</span><span class="sxs-lookup"><span data-stu-id="f2ac9-146">16</span></span>     |
| <span data-ttu-id="f2ac9-147">400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-147">400%</span></span>         | <span data-ttu-id="f2ac9-148">32</span><span class="sxs-lookup"><span data-stu-id="f2ac9-148">32</span></span>     |

 

## <a name="tile-assets"></a><span data-ttu-id="f2ac9-149">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-149">Tile assets</span></span>


<span data-ttu-id="f2ac9-150">各タイル アセットは、配置されるタイルと同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-150">Each tile asset is the same size as the tile on which it is placed.</span></span> <span data-ttu-id="f2ac9-151">アセットの 2 つの異なる表示によって、アプリのタイルをブランド化できます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-151">You can brand your app's tiles with two different representations of an asset:</span></span>

1. <span data-ttu-id="f2ac9-152">パディングによって中央に配置されたアイコンまたはロゴ。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-152">An icon or logo centered with padding.</span></span> <span data-ttu-id="f2ac9-153">この場合、バック プレートの色が透けて見えます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-153">This lets the back plate color show through:</span></span>

![タイルとバック プレート](images/assetguidance05.png)

2. <span data-ttu-id="f2ac9-155">パディングのない、フルブリードのブランド化されたタイル。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-155">A full-bleed, branded tile without padding:</span></span>

![フルブリードを表示するタイル](images/assetguidance06.png)

<span data-ttu-id="f2ac9-157">デバイス間で一貫性を確保するために、各タイル サイズ (小、普通、ワイド、大) には独自のサイズの関係があります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-157">For consistency across devices, each tile size (small, medium, wide, and large) has its own sizing relationship.</span></span> <span data-ttu-id="f2ac9-158">タイルの間で一貫したアイコンの配置を実現するために、以下のタイル サイズについて、パディングの基本的なガイドラインに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-158">In order to achieve a consistent icon placement across tiles, we recommend a few basic padding guidelines for the following tile sizes.</span></span> <span data-ttu-id="f2ac9-159">紫色の 2 つのオーバーレイが交差する領域が、アイコンの最適な面積を表しています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-159">The area where the two purple overlays intersect represents the ideal footprint for an icon.</span></span> <span data-ttu-id="f2ac9-160">アイコンがこの面積の内側に収まらない場合もありますが、アイコンの表示領域は用意されている例とほぼ同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-160">Although icons won't always fit inside the footprint, the visual volume of an icon should be roughly equivalent to the provided examples.</span></span>

<span data-ttu-id="f2ac9-161">小さいタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-161">Small tile sizing:</span></span>

![小さいタイルのサイズ調整の例](images/assetguidance07a.png)

<span data-ttu-id="f2ac9-163">普通サイズのタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-163">Medium tile sizing:</span></span>

![普通サイズのタイルのサイズ調整の例](images/assetguidance07b.png)

<span data-ttu-id="f2ac9-165">ワイド タイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-165">Wide tile sizing:</span></span>

![ワイド タイルのサイズ調整の例](images/assetguidance07c.png)

<span data-ttu-id="f2ac9-167">大きいタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-167">Large tile sizing:</span></span>

![大きいタイルのサイズ調整の例](images/assetguidance07d.png)

<span data-ttu-id="f2ac9-169">この例では、アイコンがタイルに対して大きすぎます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-169">In this example, the icon is too large for the tile:</span></span>

![タイルに対して大きすぎるアイコン](images/assetguidance08a.png)

<span data-ttu-id="f2ac9-171">この例では、アイコンがタイルに対して小さすぎます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-171">In this example, the icon is too small for the tile:</span></span>

![タイルに対して小さすぎるアイコン](images/assetguidance08b.png)

<span data-ttu-id="f2ac9-173">水平方向または垂直方向のアイコンに最適なパディングの比率は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-173">The following padding ratios are optimal for horizontally or vertically oriented icons.</span></span>

<span data-ttu-id="f2ac9-174">小さいタイルでは、アイコンの幅と高さをタイル サイズの 66% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-174">For small tiles, limit the icon width and height to 66% of the tile size:</span></span>

![小さいタイルのサイズの比率](images/assetguidance09.png)

<span data-ttu-id="f2ac9-176">普通サイズのタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-176">For medium tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="f2ac9-177">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-177">This prevents overlapping of elements in the branding bar:</span></span>

![普通サイズのタイルのサイズの比率](images/assetguidance10.png)

<span data-ttu-id="f2ac9-179">ワイド タイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-179">For wide tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="f2ac9-180">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-180">This prevents overlapping of elements in the branding bar:</span></span>

![ワイド タイルのサイズの比率](images/assetguidance11.png)

<span data-ttu-id="f2ac9-182">大きいタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-182">For large tiles, limit the icon width to 66% and height to 50% of tile size:</span></span>

![大きいタイルのサイズの比率](images/assetguidance12.png)

<span data-ttu-id="f2ac9-184">水平方向または垂直方向にデザインされたアイコンがある一方で、ターゲット サイズの正方形に収まらない、より複雑な形状のアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-184">Some icons are designed to be horizontally or vertically oriented, while others have more complex shapes that prevent them from fitting squarely within the target dimensions.</span></span> <span data-ttu-id="f2ac9-185">中央に配置されるアイコンの一方の辺に重みを付けることができます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-185">Icons that appear to be centered can be weighted to one side.</span></span> <span data-ttu-id="f2ac9-186">この場合、アイコンの視覚的な重みが正方形に収まるアイコンと同じであれば、アイコンの一部が推奨される面積の外側にはみ出していてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-186">In this case, parts of an icon may hang outside the recommended footprint, provided it occupies the same visual weight as a squarely fitted icon:</span></span>

![中央に配置された 3 つのアイコン](images/assetguidance13.png)

<span data-ttu-id="f2ac9-188">フルブリード アセットでは、要素が余白およびタイルの端の内側に接するように考慮します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-188">With full-bleed assets, take into account elements that interact within the margins and edges of the tiles.</span></span> <span data-ttu-id="f2ac9-189">タイルの高さまたは幅の 16% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-189">Maintain margins of at least 16% of the height or width of the tile.</span></span> <span data-ttu-id="f2ac9-190">この割合は、最小タイル サイズでの余白の幅の 2 倍を表しています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-190">This percentage represents double the width of the margins at the smallest tile sizes:</span></span>

![余白のあるフルブリード タイル](images/assetguidance14.png)

<span data-ttu-id="f2ac9-192">次の例では、余白が狭すぎます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-192">In this example, margins are too tight:</span></span>

![余白が小さすぎるフルブリード タイル](images/assetguidance15.png)

## <a name="tile-assets-in-list-views"></a><span data-ttu-id="f2ac9-194">リスト ビューでのタイル アセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-194">Tile assets in list views</span></span>


<span data-ttu-id="f2ac9-195">タイルはリスト ビューにも表示されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-195">Tiles can also appear in a list view.</span></span> <span data-ttu-id="f2ac9-196">リスト ビューに表示されるタイル アセットのサイズ調整に関するガイドラインは、先ほど説明したタイル アセットとは少し異なります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-196">Sizing guidelines for tile assets that appear in list views are a bit different than tile assets previously outlined.</span></span> <span data-ttu-id="f2ac9-197">このセクションでは、これらのサイズ調整の詳細について説明します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-197">This section details those sizing specifics.</span></span>

![リスト ビューでのタイル アセット](images/assetguidance16.png)

<span data-ttu-id="f2ac9-199">アイコンの幅と高さをタイル サイズの 75% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-199">Limit icon width and height to 75% of the tile size:</span></span>

![リスト ビュー タイルのアイコンのサイズ調整](images/assetguidance17.png)

<span data-ttu-id="f2ac9-201">垂直方向および水平方向のアイコンでは、幅と高さをタイル サイズの 75% に制限します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-201">For vertical and horizontal icon formats, limit width and height to 75% of the tile size:</span></span>

![リスト ビュー タイルのアイコンのサイズ調整](images/assetguidance18.png)

<span data-ttu-id="f2ac9-203">重要なブランド要素のフルブリード アートワークの場合、12.5% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-203">For full bleed artwork of important brand elements, maintain margins of at least 12.5%:</span></span>

![リスト ビュー タイルでのフルブリード アートワーク](images/assetguidance19.png)

<span data-ttu-id="f2ac9-205">次の例では、アイコンがタイル内で大きすぎます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-205">In this example, the icon is too big inside its tile:</span></span>

![タイルに対して大きすぎるアイコン](images/assetguidance20a.png)

<span data-ttu-id="f2ac9-207">次の例では、アイコンがタイル内で小さすぎます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-207">In this example, the icon is too small inside its tile:</span></span>

![タイルに対して小さすぎるアイコン](images/assetguidance20b.png)

## <a name="target-based-assets"></a><span data-ttu-id="f2ac9-209">ターゲット ベースのアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-209">Target-based assets</span></span>


<span data-ttu-id="f2ac9-210">ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-210">Target-based assets are for icons and tiles that appear on the Windows taskbar, task view, ALT+TAB, snap-assist, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="f2ac9-211">これらのアセットにパディングを追加する必要はありません。パディングは、必要に応じて Windows によって追加されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-211">You don't have to add padding to these assets; Windows adds padding if needed.</span></span> <span data-ttu-id="f2ac9-212">これらのアセットは、16 ピクセルの最小面積を占めている必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-212">These assets should account for a minimum footprint of 16 pixels.</span></span> <span data-ttu-id="f2ac9-213">Windows タスク バーのアイコンに表示される、このようなアセットの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-213">Here's an example of these assets as they appear in icons on the Windows taskbar:</span></span>

![Windows タスク バーのアセット](images/assetguidance21.png)

<span data-ttu-id="f2ac9-215">これらの UI では、既定で色付きバック プレート上でターゲット ベースのアセットが使用されますが、ターゲット ベースのプレートなしのアセットを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-215">Although these UI will use a target-based asset on top of a colored backplate by default, you may use a target-based unplated asset as well.</span></span> <span data-ttu-id="f2ac9-216">プレートなしのアセットは、さまざまな背景色で表示される可能性があることを考慮して作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-216">Unplated assets should be created with the possibility that they may appear on various background colors:</span></span>

![プレートなしのアセットとプレート付きのアセット](images/assetguidance22.png)

<span data-ttu-id="f2ac9-218">100% の倍率でのターゲット ベースのアセットのサイズに関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-218">These are size recommendations for target-based assets, at 100% scale:</span></span>

![100% の倍率でのターゲット ベースのアセットのサイズ調整](images/assetguidance23.png)

## <a name="splash-screen-assets"></a><span data-ttu-id="f2ac9-220">スプラッシュ画面のアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-220">Splash screen assets</span></span>


<span data-ttu-id="f2ac9-221">スプラッシュ画面の画像は、画像ファイルへの直接パスまたはリソースとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-221">The splash screen image can be given either as a direct path to an image file or as a resource.</span></span> <span data-ttu-id="f2ac9-222">リソース参照を使用すると、Windows がデバイスと画面の解像度に最適なサイズを選択できるように、さまざまなスケールの画像を提供できます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-222">By using a resource reference, you can supply images of different scales so that Windows can choose the best size for the device and screen resolution.</span></span> <span data-ttu-id="f2ac9-223">アクセシビリティのためのハイ コントラスト画像や、さまざまな UI 言語に対応するローカライズされた画像を提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-223">You can also supply high contrast images for accessibility and localized images to match different UI languages.</span></span>

<span data-ttu-id="f2ac9-224">テキスト エディターで "Package.appxmanifest" を開くと、[**VisualElements**](https://msdn.microsoft.com/library/windows/apps/br211471) 要素の子として [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br211467) 要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-224">If you open "Package.appxmanifest" in a text editor, the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br211467) element appears as a child of the [**VisualElements**](https://msdn.microsoft.com/library/windows/apps/br211471) element.</span></span> <span data-ttu-id="f2ac9-225">マニフェスト ファイル内の既定のスプラッシュ画面のマークアップはテキスト エディターで次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-225">The default splash screen markup in the manifest file looks like this in a text editor:</span></span>

```XML
<uap:SplashScreen Image="Assets\SplashScreen.png" /></code></pre></td>
</tr>
</tbody>
</table>
```

<span data-ttu-id="f2ac9-226">スプラッシュ画面のアセットは、表示されるすべてのデバイスで中央に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-226">The splash screen asset is centered by whichever device it appears on:</span></span>

![スプラッシュ画面のアセットのサイズ調整](images/assetguidance27.png)

## <a name="high-contrast-assets"></a><span data-ttu-id="f2ac9-228">ハイ コントラストのアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-228">High-contrast assets</span></span>


<span data-ttu-id="f2ac9-229">ハイ コントラスト モードでは、別のハイ コントラスト白 (白の背景に黒のテキスト) とハイ コントラスト黒 (黒の背景に白のテキスト) のアセットを使用します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-229">High-contrast mode makes use of separate sets of assets for high-contrast white (white background with black text) and high-contrast black (black background with white text).</span></span> <span data-ttu-id="f2ac9-230">アプリでハイ コントラストのアセットが提供されない場合、標準アセットが使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-230">If you don't provide high-contrast assets for your app, standard assets will be used.</span></span>

<span data-ttu-id="f2ac9-231">アプリの標準アセットをモノクロの背景にレンダリングしたときに許容できる表示エクスペリエンスが提供される場合、アプリはハイ コントラスト モードでも最低限満足できる表示になります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-231">If your app's standard assets provide an acceptable viewing experience when rendered on a black-and-white background, then your app should look at least satisfactory in high-contrast mode.</span></span> <span data-ttu-id="f2ac9-232">標準アセットをモノクロの背景にレンダリングしたときに、許容できる表示エクスペリエンスが得られない場合は、明確にハイ コントラストのアセットを含めることを検討します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-232">If your standard assets don't afford an acceptable viewing experience when rendered on a black-and-white background, consider specifically including high-contrast assets.</span></span> <span data-ttu-id="f2ac9-233">以下の例は、2 種類のハイ コントラストのアセットを示しています。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-233">These examples illustrate the two types of high-contrast assets:</span></span>

![ハイ コントラスト比のアセットの例](images/assetguidance28.png)

<span data-ttu-id="f2ac9-235">ハイ コントラストのアセットを用意する場合は、黒地に白と白地に黒の両方のセットを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-235">If you decide to provide high-contrast assets, you need to include both sets—both white-on-black and black-on-white.</span></span> <span data-ttu-id="f2ac9-236">これらのアセットをパッケージに含める場合は、黒地に白のアセット用に "contrast-black" フォルダーを、白地に黒のアセット用に "contrast-white" フォルダーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-236">When including these assets in your package, you could create a "contrast-black" folder for white-on-black assets, and a "contrast-white" folder for black-on-white assets.</span></span>

## <a name="asset-size-tables"></a><span data-ttu-id="f2ac9-237">アセット サイズの一覧表</span><span class="sxs-lookup"><span data-stu-id="f2ac9-237">Asset size tables</span></span>


<span data-ttu-id="f2ac9-238">少なくとも、100、200、400 の倍率のアセットを提供することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-238">At a bare minimum, we strongly recommend that you provide assets for the 100, 200, and 400 scale factors.</span></span> <span data-ttu-id="f2ac9-239">すべての倍率のアセットを提供することによって、最適なユーザー エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-239">Providing assets for all scale factors will provide the optimal user experience.</span></span>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-240">小さいタイル (Square71x71Logo)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-240">Small tile (Square71x71Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-241">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-241">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-242">71 x 71</span><span class="sxs-lookup"><span data-stu-id="f2ac9-242">71x71</span></span></td>
    <td><span data-ttu-id="f2ac9-243">Square71x71Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-243">Square71x71Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-244">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-244">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-245">89 x 89</span><span class="sxs-lookup"><span data-stu-id="f2ac9-245">89x89</span></span></td>
    <td><span data-ttu-id="f2ac9-246">Square71x71Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-246">Square71x71Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-247">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-247">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-248">107 x 107</span><span class="sxs-lookup"><span data-stu-id="f2ac9-248">107x107</span></span></td>
    <td><span data-ttu-id="f2ac9-249">Square71x71Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-249">Square71x71Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-250">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-250">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-251">142 x 142</span><span class="sxs-lookup"><span data-stu-id="f2ac9-251">142x142</span></span></td>
    <td><span data-ttu-id="f2ac9-252">Square71x71Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-252">Square71x71Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-253">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-253">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-254">284 x 284</span><span class="sxs-lookup"><span data-stu-id="f2ac9-254">284x284</span></span></td>
    <td><span data-ttu-id="f2ac9-255">Square71x71Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-255">Square71x71Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-256">普通サイズのタイル (Square150x150Logo)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-256">Medium tile (Square150x150Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-257">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-257">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-258">150 x 150</span><span class="sxs-lookup"><span data-stu-id="f2ac9-258">150x150</span></span></td>
    <td><span data-ttu-id="f2ac9-259">Square150x150Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-259">Square150x150Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-260">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-260">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-261">188 x 188</span><span class="sxs-lookup"><span data-stu-id="f2ac9-261">188x188</span></span></td>
    <td><span data-ttu-id="f2ac9-262">Square150x150Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-262">Square150x150Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-263">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-263">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-264">225 x 225</span><span class="sxs-lookup"><span data-stu-id="f2ac9-264">225x225</span></span></td>
    <td><span data-ttu-id="f2ac9-265">Square150x150Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-265">Square150x150Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-266">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-266">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-267">300 x 300</span><span class="sxs-lookup"><span data-stu-id="f2ac9-267">300x300</span></span></td>
    <td><span data-ttu-id="f2ac9-268">Square150x150Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-268">Square150x150Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-269">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-269">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-270">600 x 600</span><span class="sxs-lookup"><span data-stu-id="f2ac9-270">600x600</span></span></td>
    <td><span data-ttu-id="f2ac9-271">Square150x150Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-271">Square150x150Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-272">ワイド タイル (Wide310x150Logo)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-272">Wide tile (Wide310x150Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-273">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-273">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-274">310 x 150</span><span class="sxs-lookup"><span data-stu-id="f2ac9-274">310x150</span></span></td>
    <td><span data-ttu-id="f2ac9-275">Wide310x150Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-275">Wide310x150Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-276">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-276">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-277">388 x 188</span><span class="sxs-lookup"><span data-stu-id="f2ac9-277">388x188</span></span></td>
    <td><span data-ttu-id="f2ac9-278">Wide310x150Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-278">Wide310x150Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-279">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-279">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-280">465 x 225</span><span class="sxs-lookup"><span data-stu-id="f2ac9-280">465x225</span></span></td>
    <td><span data-ttu-id="f2ac9-281">Wide310x150Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-281">Wide310x150Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-282">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-282">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-283">620 x 300</span><span class="sxs-lookup"><span data-stu-id="f2ac9-283">620x300</span></span></td>
    <td><span data-ttu-id="f2ac9-284">Wide310x150Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-284">Wide310x150Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-285">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-285">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-286">1240 x 600</span><span class="sxs-lookup"><span data-stu-id="f2ac9-286">1240x600</span></span></td>
    <td><span data-ttu-id="f2ac9-287">Wide310x150Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-287">Wide310x150Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-288">大きいタイル (Square310x310Logo)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-288">Large tile (Square310x310Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-289">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-289">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-290">310 x 310</span><span class="sxs-lookup"><span data-stu-id="f2ac9-290">310x310</span></span></td>
    <td><span data-ttu-id="f2ac9-291">Square310x310Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-291">Square310x310Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-292">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-292">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-293">388 x 388</span><span class="sxs-lookup"><span data-stu-id="f2ac9-293">388x388</span></span></td>
    <td><span data-ttu-id="f2ac9-294">Square310x310Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-294">Square310x310Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-295">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-295">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-296">465 x 465</span><span class="sxs-lookup"><span data-stu-id="f2ac9-296">465x465</span></span></td>
    <td><span data-ttu-id="f2ac9-297">Square310x310Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-297">Square310x310Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-298">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-298">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-299">620 x 620</span><span class="sxs-lookup"><span data-stu-id="f2ac9-299">620x620</span></span></td>
    <td><span data-ttu-id="f2ac9-300">Square310x310Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-300">Square310x310Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-301">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-301">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-302">1240 x 1240</span><span class="sxs-lookup"><span data-stu-id="f2ac9-302">1240x1240</span></span></td>
    <td><span data-ttu-id="f2ac9-303">Square310x310Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-303">Square310x310Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-304">アプリの一覧のアイコン (Square44x44Logo)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-304">App list icon (Square44x44Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-305">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-305">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-306">44 x 44</span><span class="sxs-lookup"><span data-stu-id="f2ac9-306">44x44</span></span></td>
    <td><span data-ttu-id="f2ac9-307">Square44x44Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-307">Square44x44Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-308">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-308">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-309">55 x 55</span><span class="sxs-lookup"><span data-stu-id="f2ac9-309">55x55</span></span></td>
    <td><span data-ttu-id="f2ac9-310">Square44x44Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-310">Square44x44Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-311">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-311">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-312">66 x 66</span><span class="sxs-lookup"><span data-stu-id="f2ac9-312">66x66</span></span></td>
    <td><span data-ttu-id="f2ac9-313">Square44x44Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-313">Square44x44Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-314">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-314">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-315">88 x 88</span><span class="sxs-lookup"><span data-stu-id="f2ac9-315">88x88</span></span></td>
    <td><span data-ttu-id="f2ac9-316">Square44x44Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-316">Square44x44Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-317">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-317">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-318">176 x 176</span><span class="sxs-lookup"><span data-stu-id="f2ac9-318">176x176</span></span></td>
    <td><span data-ttu-id="f2ac9-319">Square44x44Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-319">Square44x44Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="f2ac9-320">スプラッシュ画面 (SplashScreen)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-320">Splash screen (SplashScreen)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="f2ac9-321">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-321">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="f2ac9-322">620 x 300</span><span class="sxs-lookup"><span data-stu-id="f2ac9-322">620x300</span></span></td>
    <td><span data-ttu-id="f2ac9-323">SplashScreen.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-323">SplashScreen.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-324">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-324">125% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-325">775 x 375</span><span class="sxs-lookup"><span data-stu-id="f2ac9-325">775x375</span></span></td>
    <td><span data-ttu-id="f2ac9-326">SplashScreen.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-326">SplashScreen.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-327">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-327">150% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-328">930 x 450</span><span class="sxs-lookup"><span data-stu-id="f2ac9-328">930x450</span></span></td>
    <td><span data-ttu-id="f2ac9-329">SplashScreen.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-329">SplashScreen.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-330">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-330">200% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-331">1240 x 600</span><span class="sxs-lookup"><span data-stu-id="f2ac9-331">1240x600</span></span></td>
    <td><span data-ttu-id="f2ac9-332">SplashScreen.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-332">SplashScreen.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="f2ac9-333">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="f2ac9-333">400% scale</span></span></td>
    <td><span data-ttu-id="f2ac9-334">2480 x 1200</span><span class="sxs-lookup"><span data-stu-id="f2ac9-334">2480x1200</span></span></td>
    <td><span data-ttu-id="f2ac9-335">SplashScreen.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-335">SplashScreen.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>
 

**<span data-ttu-id="f2ac9-336">ターゲット ベースのアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-336">Target-based assets</span></span>**

<span data-ttu-id="f2ac9-337">ターゲット ベースのアセットは、複数の倍率で使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-337">Target-based assets are used across multiple scale factors.</span></span> <span data-ttu-id="f2ac9-338">ターゲット ベースのアセットの要素名は **Square44x44Logo** です。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-338">The element name for target-based assets is **Square44x44Logo**.</span></span> <span data-ttu-id="f2ac9-339">最低でも以下のアセットを提出することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-339">We strongly recommend submitting the following assets as a bare minimum:</span></span>

<span data-ttu-id="f2ac9-340">16 x 16、24 x 24、32 x 32、48 x 48、256 x 256</span><span class="sxs-lookup"><span data-stu-id="f2ac9-340">16x16, 24x24, 32x32, 48x48, 256x256</span></span>

<span data-ttu-id="f2ac9-341">次の表は、すべてのターゲット ベースのアセットのサイズと対応するファイル名の例を示します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-341">The following table lists all target-based asset sizes and corresponding file name examples:</span></span>

| <span data-ttu-id="f2ac9-342">アセットのサイズ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-342">Asset size</span></span> | <span data-ttu-id="f2ac9-343">ファイル名の例</span><span class="sxs-lookup"><span data-stu-id="f2ac9-343">File name example</span></span>                  |
|------------|------------------------------------|
| <span data-ttu-id="f2ac9-344">16 x 16\*</span><span class="sxs-lookup"><span data-stu-id="f2ac9-344">16x16\*</span></span>    | <span data-ttu-id="f2ac9-345">Square44x44Logo.targetsize-16.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-345">Square44x44Logo.targetsize-16.png</span></span>  |
| <span data-ttu-id="f2ac9-346">24 x 24\*</span><span class="sxs-lookup"><span data-stu-id="f2ac9-346">24x24\*</span></span>    | <span data-ttu-id="f2ac9-347">Square44x44Logo.targetsize-24.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-347">Square44x44Logo.targetsize-24.png</span></span>  |
| <span data-ttu-id="f2ac9-348">32 x 32\*</span><span class="sxs-lookup"><span data-stu-id="f2ac9-348">32x32\*</span></span>    | <span data-ttu-id="f2ac9-349">Square44x44Logo.targetsize-32.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-349">Square44x44Logo.targetsize-32.png</span></span>  |
| <span data-ttu-id="f2ac9-350">48 x 48\*</span><span class="sxs-lookup"><span data-stu-id="f2ac9-350">48x48\*</span></span>    | <span data-ttu-id="f2ac9-351">Square44x44Logo.targetsize-48.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-351">Square44x44Logo.targetsize-48.png</span></span>  |
| <span data-ttu-id="f2ac9-352">256 x 256\*</span><span class="sxs-lookup"><span data-stu-id="f2ac9-352">256x256\*</span></span>  | <span data-ttu-id="f2ac9-353">Square44x44Logo.targetsize-256.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-353">Square44x44Logo.targetsize-256.png</span></span> |
| <span data-ttu-id="f2ac9-354">20 x 20</span><span class="sxs-lookup"><span data-stu-id="f2ac9-354">20x20</span></span>      | <span data-ttu-id="f2ac9-355">Square44x44Logo.targetsize-20.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-355">Square44x44Logo.targetsize-20.png</span></span>  |
| <span data-ttu-id="f2ac9-356">30 x 30</span><span class="sxs-lookup"><span data-stu-id="f2ac9-356">30x30</span></span>      | <span data-ttu-id="f2ac9-357">Square44x44Logo.targetsize-30.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-357">Square44x44Logo.targetsize-30.png</span></span>  |
| <span data-ttu-id="f2ac9-358">36 x 36</span><span class="sxs-lookup"><span data-stu-id="f2ac9-358">36x36</span></span>      | <span data-ttu-id="f2ac9-359">Square44x44Logo.targetsize-36.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-359">Square44x44Logo.targetsize-36.png</span></span>  |
| <span data-ttu-id="f2ac9-360">40 x 40</span><span class="sxs-lookup"><span data-stu-id="f2ac9-360">40x40</span></span>      | <span data-ttu-id="f2ac9-361">Square44x44Logo.targetsize-40.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-361">Square44x44Logo.targetsize-40.png</span></span>  |
| <span data-ttu-id="f2ac9-362">60 x 60</span><span class="sxs-lookup"><span data-stu-id="f2ac9-362">60x60</span></span>      | <span data-ttu-id="f2ac9-363">Square44x44Logo.targetsize-60.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-363">Square44x44Logo.targetsize-60.png</span></span>  |
| <span data-ttu-id="f2ac9-364">64 x 64</span><span class="sxs-lookup"><span data-stu-id="f2ac9-364">64x64</span></span>      | <span data-ttu-id="f2ac9-365">Square44x44Logo.targetsize-64.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-365">Square44x44Logo.targetsize-64.png</span></span>  |
| <span data-ttu-id="f2ac9-366">72 x 72</span><span class="sxs-lookup"><span data-stu-id="f2ac9-366">72x72</span></span>      | <span data-ttu-id="f2ac9-367">Square44x44Logo.targetsize-72.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-367">Square44x44Logo.targetsize-72.png</span></span>  |
| <span data-ttu-id="f2ac9-368">80 x 80</span><span class="sxs-lookup"><span data-stu-id="f2ac9-368">80x80</span></span>      | <span data-ttu-id="f2ac9-369">Square44x44Logo.targetsize-80.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-369">Square44x44Logo.targetsize-80.png</span></span>  |
| <span data-ttu-id="f2ac9-370">96 x 96</span><span class="sxs-lookup"><span data-stu-id="f2ac9-370">96x96</span></span>      | <span data-ttu-id="f2ac9-371">Square44x44Logo.targetsize-96.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-371">Square44x44Logo.targetsize-96.png</span></span>  |

 

<span data-ttu-id="f2ac9-372">\* ベースラインとしてこれらのサイズのアセットを提出します</span><span class="sxs-lookup"><span data-stu-id="f2ac9-372">\* Submit these asset sizes as a baseline</span></span>

## <a name="asset-types"></a><span data-ttu-id="f2ac9-373">アセットの種類</span><span class="sxs-lookup"><span data-stu-id="f2ac9-373">Asset types</span></span>


<span data-ttu-id="f2ac9-374">ここでは、すべてのアセットの種類、その用途、推奨されるファイル名の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-374">Listed here are all asset types, their uses, and recommended file names.</span></span>

**<span data-ttu-id="f2ac9-375">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-375">Tile assets</span></span>**

-   <span data-ttu-id="f2ac9-376">中央に配置されるアセットは、通常、スタート画面にアプリを表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-376">Centered assets are generally used on the Start to showcase your app.</span></span>
-   <span data-ttu-id="f2ac9-377">ファイル名の形式: [Square\Wide]\*x\*Logo.scale-\*.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-377">File name format: [Square\Wide]\*x\*Logo.scale-\*.png</span></span>
-   <span data-ttu-id="f2ac9-378">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-378">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="f2ac9-379">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-379">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-380">既定のスタート画面のタイル (デスクトップとモバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-380">Default Start tiles (desktop and mobile)</span></span>
    -   <span data-ttu-id="f2ac9-381">アクション センター (デスクトップとモバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-381">Action center (desktop and mobile)</span></span>
    -   <span data-ttu-id="f2ac9-382">タスク スイッチャー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-382">Task switcher (mobile)</span></span>
    -   <span data-ttu-id="f2ac9-383">共有ピッカー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-383">Share picker (mobile)</span></span>
    -   <span data-ttu-id="f2ac9-384">ピッカー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-384">Picker (mobile)</span></span>
    -   <span data-ttu-id="f2ac9-385">ストア</span><span class="sxs-lookup"><span data-stu-id="f2ac9-385">Store</span></span>

**<span data-ttu-id="f2ac9-386">プレート付きのスケーラブルな一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-386">Scalable list assets with plate</span></span>**

-   <span data-ttu-id="f2ac9-387">これらのアセットは拡大縮小が必要なサーフェスで使われます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-387">These assets are used on surfaces that request scale factors.</span></span> <span data-ttu-id="f2ac9-388">アセットのバック プレートはシステムによって提供されるか、アプリに含まれている場合は独自の背景色のプレートが使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-388">Assets either get plated by the system or come with their own background color if the app includes that.</span></span>
-   <span data-ttu-id="f2ac9-389">ファイル名の形式: Square44x44Logo.scale-\*.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-389">File name format: Square44x44Logo.scale-\*.png</span></span>
-   <span data-ttu-id="f2ac9-390">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-390">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="f2ac9-391">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-391">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-392">スタート画面のすべてのアプリの一覧 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-392">Start all apps list (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-393">スタート画面のよく使うアプリの一覧 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-393">Start most-frequently used list (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-394">タスク マネージャー (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-394">Task manager (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-395">Cortana の検索結果</span><span class="sxs-lookup"><span data-stu-id="f2ac9-395">Cortana search results</span></span>
    -   <span data-ttu-id="f2ac9-396">スタート画面のすべてのアプリの一覧 (モバイル)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-396">Start all apps list (mobile)</span></span>
    -   <span data-ttu-id="f2ac9-397">設定</span><span class="sxs-lookup"><span data-stu-id="f2ac9-397">Settings</span></span>

**<span data-ttu-id="f2ac9-398">プレート付きのターゲット サイズの一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-398">Target-size list assets with plate</span></span>**

-   <span data-ttu-id="f2ac9-399">これらはプレート付きで、拡大縮小されない固定サイズのアセットです。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-399">These are fixed asset sizes that don't scale with plateaus.</span></span> <span data-ttu-id="f2ac9-400">ほとんどの場合、従来のエクスペリエンスに使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-400">Mostly used for legacy experiences.</span></span> <span data-ttu-id="f2ac9-401">アセットはシステムによって確認されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-401">Assets are checked by the system.</span></span>
-   <span data-ttu-id="f2ac9-402">ファイル名の形式: Square44x44Logo.targetsize-\*.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-402">File name format: Square44x44Logo.targetsize-\*.png</span></span>
-   <span data-ttu-id="f2ac9-403">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-403">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="f2ac9-404">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-404">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-405">スタート画面のジャンプ リスト (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-405">Start jump list (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-406">スタート画面のタイルの下隅 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-406">Start lower corner of tile (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-407">ショートカット (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-407">Shortcuts (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-408">コントロール パネル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-408">Control Panel (desktop)</span></span>

**<span data-ttu-id="f2ac9-409">プレートなしのターゲット サイズの一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-409">Target-size list assets without plate</span></span>**

-   <span data-ttu-id="f2ac9-410">これらは、システムによってプレートの追加や拡大縮小が行われないアセットです。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-410">These are assets that don't get plated or scaled by the system.</span></span>
-   <span data-ttu-id="f2ac9-411">ファイル名の形式: Square44x44Logo.targetsize-\*\_altform-unplated.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-411">File name format: Square44x44Logo.targetsize-\*\_altform-unplated.png</span></span>
-   <span data-ttu-id="f2ac9-412">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-412">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="f2ac9-413">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-413">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-414">タスク バーとタスク バー サムネイル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-414">Taskbar and taskbar thumbnail (desktop)</span></span>
    -   <span data-ttu-id="f2ac9-415">タスク バーのジャンプ リスト</span><span class="sxs-lookup"><span data-stu-id="f2ac9-415">Taskbar jumplist</span></span>
    -   <span data-ttu-id="f2ac9-416">タスク ビュー</span><span class="sxs-lookup"><span data-stu-id="f2ac9-416">Task view</span></span>
    -   <span data-ttu-id="f2ac9-417">Alt + Tab キー</span><span class="sxs-lookup"><span data-stu-id="f2ac9-417">ALT+TAB</span></span>

**<span data-ttu-id="f2ac9-418">ファイル拡張子アセット</span><span class="sxs-lookup"><span data-stu-id="f2ac9-418">File extension assets</span></span>**

-   <span data-ttu-id="f2ac9-419">これらはファイル拡張子に固有のアセットです。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-419">These are assets specific to file extensions.</span></span> <span data-ttu-id="f2ac9-420">エクスプ ローラーで Win32 スタイルのファイルの関連付けアイコンの横に表示され、テーマに依存しません。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-420">They appear next to Win32-style file association icons in File Explorer and must be theme-agnostic.</span></span> <span data-ttu-id="f2ac9-421">サイズ調整は、デスクトップ プラットフォームとモバイル プラットフォームで異なります。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-421">Sizing is different on desktop and mobile platforms.</span></span>
-   <span data-ttu-id="f2ac9-422">ファイル名の形式: \*LogoExtensions.targetsize-\*.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-422">File name format: \*LogoExtensions.targetsize-\*.png</span></span>
-   <span data-ttu-id="f2ac9-423">影響を受けるアプリ: ミュージック、ビデオ、フォト、Microsoft Edge、Microsoft Office</span><span class="sxs-lookup"><span data-stu-id="f2ac9-423">Impacted apps: Music, Video, Photos, Microsoft Edge, Microsoft Office</span></span>
-   <span data-ttu-id="f2ac9-424">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-424">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-425">エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="f2ac9-425">File Explorer</span></span>
    -   <span data-ttu-id="f2ac9-426">Cortana</span><span class="sxs-lookup"><span data-stu-id="f2ac9-426">Cortana</span></span>
    -   <span data-ttu-id="f2ac9-427">さまざまな UI サーフェス (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="f2ac9-427">Various UI surfaces (desktop)</span></span>

**<span data-ttu-id="f2ac9-428">スプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="f2ac9-428">Splash screen</span></span>**

-   <span data-ttu-id="f2ac9-429">アプリのスプラッシュ画面に表示されるアセット。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-429">The asset that appears on your app's splash screen.</span></span> <span data-ttu-id="f2ac9-430">デスクトップとモバイルの両方のプラットフォームで自動的に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="f2ac9-430">Automatically scales on both desktop and mobile platforms.</span></span>
-   <span data-ttu-id="f2ac9-431">ファイル名の形式: SplashScreen.scale-*.png</span><span class="sxs-lookup"><span data-stu-id="f2ac9-431">File name format: SplashScreen.scale-*.png</span></span>
-   <span data-ttu-id="f2ac9-432">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="f2ac9-432">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="f2ac9-433">用途:</span><span class="sxs-lookup"><span data-stu-id="f2ac9-433">Uses:</span></span>
    -   <span data-ttu-id="f2ac9-434">アプリのスプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="f2ac9-434">App's splash screen</span></span>