---
author: mijacobs
Description: App icon assets, which appear in a variety of forms throughout the Windows 10 operating system, are the calling cards for your Universal Windows Platform (UWP) app.
title: タイルとアイコン アセット
ms.assetid: D6CE21E5-2CFA-404F-8679-36AA522206C7
label: Tile and icon assets
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cc614f7803e7546add8ecccb7cc20dc0250d0d22
ms.sourcegitcommit: eead3c00b27d9f66f79ec08c81a97e91dc1fdb3c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/18/2018
ms.locfileid: "1522791"
---
# <a name="guidelines-for-tile-and-icon-assets"></a><span data-ttu-id="9e5c9-103">タイルとアイコン アセットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="9e5c9-103">Guidelines for tile and icon assets</span></span>

 


<span data-ttu-id="9e5c9-104">Windows 10 オペレーティング システム全体でさまざまな形式で表示される、アプリ アイコン アセットは、ユニバーサル Windows プラットフォーム (UWP) アプリの名刺です。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-104">App icon assets, which appear in a variety of forms throughout the Windows 10 operating system, are the calling cards for your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="9e5c9-105">このガイドラインでは、システム内でアプリ アイコン アセットが表示される場所の詳細について説明し、最も洗練されたアイコンを作成する方法に関して詳細なデザインのヒントを提供します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-105">These guidelines detail where app icon assets appear in the system, and provide in-depth design tips on how to create the most polished icons.</span></span>

![Windows 10 のスタート画面とタイル](images/assetguidance01.jpg)

## <a name="adaptive-scaling"></a><span data-ttu-id="9e5c9-107">アダプティブ スケーリング</span><span class="sxs-lookup"><span data-stu-id="9e5c9-107">Adaptive scaling</span></span>


<span data-ttu-id="9e5c9-108">まず、スケーリングとアセットがどのように連携しているかを深く理解するために、アダプティブ スケーリングの概要について簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-108">First, a brief overview on adaptive scaling to better understand how scaling works with assets.</span></span> <span data-ttu-id="9e5c9-109">Windows 10 には、既存のスケーリング モデルの進化形が導入されています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-109">Windows 10 introduces an evolution of the existing scaling model.</span></span> <span data-ttu-id="9e5c9-110">表示スケール ベクター コンテンツに加えて、さまざまな画面サイズと画面の解像度で UI 要素に一貫したサイズを提供するスケール ファクターの統合されたセットがあります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-110">In addition to scaling vector content, there is a unified set of scale factors that provides a consistent size for UI elements across a variety of screen sizes and display resolutions.</span></span> <span data-ttu-id="9e5c9-111">スケール ファクターは、iOS や Android などの他のオペレーティング システムのスケール ファクターとも互換性があり、これにより、こうしたプラットフォーム間でのアセットの共有が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-111">The scale factors are also compatible with the scale factors of other operating systems such as iOS and Android, which makes it easier to share assets between these platforms.</span></span>

<span data-ttu-id="9e5c9-112">Microsoft Store では、デバイスの dpi も考慮に入れて、ダウンロードするアセットが選ばれます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-112">The Store picks the assets to download based in part on the DPI of the device.</span></span> <span data-ttu-id="9e5c9-113">デバイスに最適なアセットのみがダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-113">Only the assets that best match the device are downloaded.</span></span>

## <a name="tile-elements"></a><span data-ttu-id="9e5c9-114">タイル要素</span><span class="sxs-lookup"><span data-stu-id="9e5c9-114">Tile elements</span></span>


<span data-ttu-id="9e5c9-115">スタート画面のタイルの基本コンポーネントは、バック プレート、アイコン、ブランド バー、余白、およびアプリのタイトルで構成されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-115">The basic components of a Start tile consist of a back plate, an icon, a branding bar, margins, and an app title:</span></span>

![タイルの要素の詳細](images/assetguidance02.png)

<span data-ttu-id="9e5c9-117">タイルの下部にあるブランド バーは、アプリ名、バッジ、カウンター (使用する場合) が表示される場所です。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-117">The branding bar at the bottom of a tile is where the app name, badging, and counter (if used) appear:</span></span>

![タイルのブランド バー](images/assetguidance03.png)

<span data-ttu-id="9e5c9-119">ブランドのバーの高さは、表示されているデバイスの倍率に基づいています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-119">The height of the branding bar is based on the scale factor of the device on which it appears:</span></span>

| <span data-ttu-id="9e5c9-120">倍率</span><span class="sxs-lookup"><span data-stu-id="9e5c9-120">Scale factor</span></span> | <span data-ttu-id="9e5c9-121">ピクセル</span><span class="sxs-lookup"><span data-stu-id="9e5c9-121">Pixels</span></span> |
|--------------|--------|
| <span data-ttu-id="9e5c9-122">100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-122">100%</span></span>         | <span data-ttu-id="9e5c9-123">32</span><span class="sxs-lookup"><span data-stu-id="9e5c9-123">32</span></span>     |
| <span data-ttu-id="9e5c9-124">125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-124">125%</span></span>         | <span data-ttu-id="9e5c9-125">40</span><span class="sxs-lookup"><span data-stu-id="9e5c9-125">40</span></span>     |
| <span data-ttu-id="9e5c9-126">150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-126">150%</span></span>         | <span data-ttu-id="9e5c9-127">48</span><span class="sxs-lookup"><span data-stu-id="9e5c9-127">48</span></span>     |
| <span data-ttu-id="9e5c9-128">200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-128">200%</span></span>         | <span data-ttu-id="9e5c9-129">64</span><span class="sxs-lookup"><span data-stu-id="9e5c9-129">64</span></span>     |
| <span data-ttu-id="9e5c9-130">400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-130">400%</span></span>         | <span data-ttu-id="9e5c9-131">128</span><span class="sxs-lookup"><span data-stu-id="9e5c9-131">128</span></span>    |

 

<span data-ttu-id="9e5c9-132">タイルの余白はシステムによって設定され、変更できません。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-132">The system sets tile margins and cannot be modified.</span></span> <span data-ttu-id="9e5c9-133">次の例で示すように、コンテンツのほとんどが余白の内側に表示されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-133">Most content appears inside the margins, as seen in this example:</span></span>

![タイルの余白](images/assetguidance04.png)

<span data-ttu-id="9e5c9-135">余白の幅は、表示されているデバイスの倍率に基づいています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-135">Margin width is based on the scale factor of the device on which it appears:</span></span>

| <span data-ttu-id="9e5c9-136">倍率</span><span class="sxs-lookup"><span data-stu-id="9e5c9-136">Scale factor</span></span> | <span data-ttu-id="9e5c9-137">ピクセル</span><span class="sxs-lookup"><span data-stu-id="9e5c9-137">Pixels</span></span> |
|--------------|--------|
| <span data-ttu-id="9e5c9-138">100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-138">100%</span></span>         | <span data-ttu-id="9e5c9-139">8</span><span class="sxs-lookup"><span data-stu-id="9e5c9-139">8</span></span>      |
| <span data-ttu-id="9e5c9-140">125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-140">125%</span></span>         | <span data-ttu-id="9e5c9-141">10</span><span class="sxs-lookup"><span data-stu-id="9e5c9-141">10</span></span>     |
| <span data-ttu-id="9e5c9-142">150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-142">150%</span></span>         | <span data-ttu-id="9e5c9-143">12</span><span class="sxs-lookup"><span data-stu-id="9e5c9-143">12</span></span>     |
| <span data-ttu-id="9e5c9-144">200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-144">200%</span></span>         | <span data-ttu-id="9e5c9-145">16</span><span class="sxs-lookup"><span data-stu-id="9e5c9-145">16</span></span>     |
| <span data-ttu-id="9e5c9-146">400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-146">400%</span></span>         | <span data-ttu-id="9e5c9-147">32</span><span class="sxs-lookup"><span data-stu-id="9e5c9-147">32</span></span>     |

 

## <a name="tile-assets"></a><span data-ttu-id="9e5c9-148">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-148">Tile assets</span></span>


<span data-ttu-id="9e5c9-149">各タイル アセットは、配置されるタイルと同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-149">Each tile asset is the same size as the tile on which it is placed.</span></span> <span data-ttu-id="9e5c9-150">アセットの 2 つの異なる表示によって、アプリのタイルをブランド化できます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-150">You can brand your app's tiles with two different representations of an asset:</span></span>

1. <span data-ttu-id="9e5c9-151">パディングによって中央に配置されたアイコンまたはロゴ。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-151">An icon or logo centered with padding.</span></span> <span data-ttu-id="9e5c9-152">この場合、バック プレートの色が透けて見えます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-152">This lets the back plate color show through:</span></span>

![タイルとバック プレート](images/assetguidance05.png)

2. <span data-ttu-id="9e5c9-154">パディングのない、フルブリードのブランド化されたタイル。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-154">A full-bleed, branded tile without padding:</span></span>

![フルブリードを表示するタイル](images/assetguidance06.png)

<span data-ttu-id="9e5c9-156">デバイス間で一貫性を確保するために、各タイル サイズ (小、普通、ワイド、大) には独自のサイズの関係があります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-156">For consistency across devices, each tile size (small, medium, wide, and large) has its own sizing relationship.</span></span> <span data-ttu-id="9e5c9-157">タイルの間で一貫したアイコンの配置を実現するために、以下のタイル サイズについて、パディングの基本的なガイドラインに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-157">In order to achieve a consistent icon placement across tiles, we recommend a few basic padding guidelines for the following tile sizes.</span></span> <span data-ttu-id="9e5c9-158">紫色の 2 つのオーバーレイが交差する領域が、アイコンの最適な面積を表しています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-158">The area where the two purple overlays intersect represents the ideal footprint for an icon.</span></span> <span data-ttu-id="9e5c9-159">アイコンがこの面積の内側に収まらない場合もありますが、アイコンの表示領域は用意されている例とほぼ同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-159">Although icons won't always fit inside the footprint, the visual volume of an icon should be roughly equivalent to the provided examples.</span></span>

<span data-ttu-id="9e5c9-160">小さいタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-160">Small tile sizing:</span></span>

![小さいタイルのサイズ調整の例](images/assetguidance07a.png)

<span data-ttu-id="9e5c9-162">普通サイズのタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-162">Medium tile sizing:</span></span>

![普通サイズのタイルのサイズ調整の例](images/assetguidance07b.png)

<span data-ttu-id="9e5c9-164">ワイド タイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-164">Wide tile sizing:</span></span>

![ワイド タイルのサイズ調整の例](images/assetguidance07c.png)

<span data-ttu-id="9e5c9-166">大きいタイルのサイズ調整:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-166">Large tile sizing:</span></span>

![大きいタイルのサイズ調整の例](images/assetguidance07d.png)

<span data-ttu-id="9e5c9-168">この例では、アイコンがタイルに対して大きすぎます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-168">In this example, the icon is too large for the tile:</span></span>

![タイルに対して大きすぎるアイコン](images/assetguidance08a.png)

<span data-ttu-id="9e5c9-170">この例では、アイコンがタイルに対して小さすぎます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-170">In this example, the icon is too small for the tile:</span></span>

![タイルに対して小さすぎるアイコン](images/assetguidance08b.png)

<span data-ttu-id="9e5c9-172">水平方向または垂直方向のアイコンに最適なパディングの比率は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-172">The following padding ratios are optimal for horizontally or vertically oriented icons.</span></span>

<span data-ttu-id="9e5c9-173">小さいタイルでは、アイコンの幅と高さをタイル サイズの 66% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-173">For small tiles, limit the icon width and height to 66% of the tile size:</span></span>

![小さいタイルのサイズの比率](images/assetguidance09.png)

<span data-ttu-id="9e5c9-175">普通サイズのタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-175">For medium tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="9e5c9-176">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-176">This prevents overlapping of elements in the branding bar:</span></span>

![普通サイズのタイルのサイズの比率](images/assetguidance10.png)

<span data-ttu-id="9e5c9-178">ワイド タイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-178">For wide tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="9e5c9-179">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-179">This prevents overlapping of elements in the branding bar:</span></span>

![ワイド タイルのサイズの比率](images/assetguidance11.png)

<span data-ttu-id="9e5c9-181">大きいタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-181">For large tiles, limit the icon width to 66% and height to 50% of tile size:</span></span>

![大きいタイルのサイズの比率](images/assetguidance12.png)

<span data-ttu-id="9e5c9-183">水平方向または垂直方向にデザインされたアイコンがある一方で、ターゲット サイズの正方形に収まらない、より複雑な形状のアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-183">Some icons are designed to be horizontally or vertically oriented, while others have more complex shapes that prevent them from fitting squarely within the target dimensions.</span></span> <span data-ttu-id="9e5c9-184">中央に配置されるアイコンの一方の辺に重みを付けることができます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-184">Icons that appear to be centered can be weighted to one side.</span></span> <span data-ttu-id="9e5c9-185">この場合、アイコンの視覚的な重みが正方形に収まるアイコンと同じであれば、アイコンの一部が推奨される面積の外側にはみ出していてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-185">In this case, parts of an icon may hang outside the recommended footprint, provided it occupies the same visual weight as a squarely fitted icon:</span></span>

![中央に配置された 3 つのアイコン](images/assetguidance13.png)

<span data-ttu-id="9e5c9-187">フルブリード アセットでは、要素が余白およびタイルの端の内側に接するように考慮します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-187">With full-bleed assets, take into account elements that interact within the margins and edges of the tiles.</span></span> <span data-ttu-id="9e5c9-188">タイルの高さまたは幅の 16% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-188">Maintain margins of at least 16% of the height or width of the tile.</span></span> <span data-ttu-id="9e5c9-189">この割合は、最小タイル サイズでの余白の幅の 2 倍を表しています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-189">This percentage represents double the width of the margins at the smallest tile sizes:</span></span>

![余白のあるフルブリード タイル](images/assetguidance14.png)

<span data-ttu-id="9e5c9-191">次の例では、余白が狭すぎます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-191">In this example, margins are too tight:</span></span>

![余白が小さすぎるフルブリード タイル](images/assetguidance15.png)

## <a name="tile-assets-in-list-views"></a><span data-ttu-id="9e5c9-193">リスト ビューでのタイル アセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-193">Tile assets in list views</span></span>


<span data-ttu-id="9e5c9-194">タイルはリスト ビューにも表示されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-194">Tiles can also appear in a list view.</span></span> <span data-ttu-id="9e5c9-195">リスト ビューに表示されるタイル アセットのサイズ調整に関するガイドラインは、先ほど説明したタイル アセットとは少し異なります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-195">Sizing guidelines for tile assets that appear in list views are a bit different than tile assets previously outlined.</span></span> <span data-ttu-id="9e5c9-196">このセクションでは、これらのサイズ調整の詳細について説明します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-196">This section details those sizing specifics.</span></span>

![リスト ビューでのタイル アセット](images/assetguidance16.png)

<span data-ttu-id="9e5c9-198">アイコンの幅と高さをタイル サイズの 75% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-198">Limit icon width and height to 75% of the tile size:</span></span>

![リスト ビュー タイルのアイコンのサイズ調整](images/assetguidance17.png)

<span data-ttu-id="9e5c9-200">垂直方向および水平方向のアイコンでは、幅と高さをタイル サイズの 75% に制限します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-200">For vertical and horizontal icon formats, limit width and height to 75% of the tile size:</span></span>

![リスト ビュー タイルのアイコンのサイズ調整](images/assetguidance18.png)

<span data-ttu-id="9e5c9-202">重要なブランド要素のフルブリード アートワークの場合、12.5% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-202">For full bleed artwork of important brand elements, maintain margins of at least 12.5%:</span></span>

![リスト ビュー タイルでのフルブリード アートワーク](images/assetguidance19.png)

<span data-ttu-id="9e5c9-204">次の例では、アイコンがタイル内で大きすぎます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-204">In this example, the icon is too big inside its tile:</span></span>

![タイルに対して大きすぎるアイコン](images/assetguidance20a.png)

<span data-ttu-id="9e5c9-206">次の例では、アイコンがタイル内で小さすぎます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-206">In this example, the icon is too small inside its tile:</span></span>

![タイルに対して小さすぎるアイコン](images/assetguidance20b.png)

## <a name="target-based-assets"></a><span data-ttu-id="9e5c9-208">ターゲット ベースのアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-208">Target-based assets</span></span>


<span data-ttu-id="9e5c9-209">ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-209">Target-based assets are for icons and tiles that appear on the Windows taskbar, task view, ALT+TAB, snap-assist, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="9e5c9-210">これらのアセットにパディングを追加する必要はありません。パディングは、必要に応じて Windows によって追加されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-210">You don't have to add padding to these assets; Windows adds padding if needed.</span></span> <span data-ttu-id="9e5c9-211">これらのアセットは、16 ピクセルの最小面積を占めている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-211">These assets should account for a minimum footprint of 16 pixels.</span></span> <span data-ttu-id="9e5c9-212">Windows タスク バーのアイコンに表示される、このようなアセットの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-212">Here's an example of these assets as they appear in icons on the Windows taskbar:</span></span>

![Windows タスク バーのアセット](images/assetguidance21.png)

<span data-ttu-id="9e5c9-214">これらの UI では、既定で色付きバック プレート上でターゲット ベースのアセットが使用されますが、ターゲット ベースのプレートなしのアセットを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-214">Although these UI will use a target-based asset on top of a colored backplate by default, you may use a target-based unplated asset as well.</span></span> <span data-ttu-id="9e5c9-215">プレートなしのアセットは、さまざまな背景色で表示される可能性があることを考慮して作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-215">Unplated assets should be created with the possibility that they may appear on various background colors:</span></span>

![プレートなしのアセットとプレート付きのアセット](images/assetguidance22.png)

<span data-ttu-id="9e5c9-217">100% の倍率でのターゲット ベースのアセットのサイズに関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-217">These are size recommendations for target-based assets, at 100% scale:</span></span>

![100% の倍率でのターゲット ベースのアセットのサイズ調整](images/assetguidance23.png)

## <a name="splash-screen-assets"></a><span data-ttu-id="9e5c9-219">スプラッシュ画面のアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-219">Splash screen assets</span></span>


<span data-ttu-id="9e5c9-220">スプラッシュ画面の画像は、画像ファイルへの直接パスまたはリソースとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-220">The splash screen image can be given either as a direct path to an image file or as a resource.</span></span> <span data-ttu-id="9e5c9-221">リソース参照を使用すると、Windows がデバイスと画面の解像度に最適なサイズを選択できるように、さまざまなスケールの画像を提供できます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-221">By using a resource reference, you can supply images of different scales so that Windows can choose the best size for the device and screen resolution.</span></span> <span data-ttu-id="9e5c9-222">アクセシビリティのためのハイ コントラスト画像や、さまざまな UI 言語に対応するローカライズされた画像を提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-222">You can also supply high contrast images for accessibility and localized images to match different UI languages.</span></span>

<span data-ttu-id="9e5c9-223">テキスト エディターで "Package.appxmanifest" を開くと、[**VisualElements**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) 要素の子として [**SplashScreen**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-splashscreen) 要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-223">If you open "Package.appxmanifest" in a text editor, the [**SplashScreen**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-splashscreen) element appears as a child of the [**VisualElements**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) element.</span></span> <span data-ttu-id="9e5c9-224">マニフェスト ファイル内の既定のスプラッシュ画面のマークアップはテキスト エディターで次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-224">The default splash screen markup in the manifest file looks like this in a text editor:</span></span>

```XML
<uap:SplashScreen Image="Assets\SplashScreen.png" /></code></pre></td>
</tr>
</tbody>
</table>
```

<span data-ttu-id="9e5c9-225">スプラッシュ画面のアセットは、表示されるすべてのデバイスで中央に配置されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-225">The splash screen asset is centered by whichever device it appears on:</span></span>

![スプラッシュ画面のアセットのサイズ調整](images/assetguidance27.png)

## <a name="high-contrast-assets"></a><span data-ttu-id="9e5c9-227">ハイ コントラストのアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-227">High-contrast assets</span></span>


<span data-ttu-id="9e5c9-228">ハイ コントラスト モードでは、別のハイ コントラスト白 (白の背景に黒のテキスト) とハイ コントラスト黒 (黒の背景に白のテキスト) のアセットを使用します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-228">High-contrast mode makes use of separate sets of assets for high-contrast white (white background with black text) and high-contrast black (black background with white text).</span></span> <span data-ttu-id="9e5c9-229">アプリでハイ コントラストのアセットが提供されない場合、標準アセットが使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-229">If you don't provide high-contrast assets for your app, standard assets will be used.</span></span>

<span data-ttu-id="9e5c9-230">アプリの標準アセットをモノクロの背景にレンダリングしたときに許容できる表示エクスペリエンスが提供される場合、アプリはハイ コントラスト モードでも最低限満足できる表示になります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-230">If your app's standard assets provide an acceptable viewing experience when rendered on a black-and-white background, then your app should look at least satisfactory in high-contrast mode.</span></span> <span data-ttu-id="9e5c9-231">標準アセットをモノクロの背景にレンダリングしたときに、許容できる表示エクスペリエンスが得られない場合は、明確にハイ コントラストのアセットを含めることを検討します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-231">If your standard assets don't afford an acceptable viewing experience when rendered on a black-and-white background, consider specifically including high-contrast assets.</span></span> <span data-ttu-id="9e5c9-232">以下の例は、2 種類のハイ コントラストのアセットを示しています。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-232">These examples illustrate the two types of high-contrast assets:</span></span>

![ハイ コントラスト比のアセットの例](images/assetguidance28.png)

<span data-ttu-id="9e5c9-234">ハイ コントラストのアセットを用意する場合は、黒地に白と白地に黒の両方のセットを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-234">If you decide to provide high-contrast assets, you need to include both sets—both white-on-black and black-on-white.</span></span> <span data-ttu-id="9e5c9-235">これらのアセットをパッケージに含める場合は、黒地に白のアセット用に "contrast-black" フォルダーを、白地に黒のアセット用に "contrast-white" フォルダーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-235">When including these assets in your package, you could create a "contrast-black" folder for white-on-black assets, and a "contrast-white" folder for black-on-white assets.</span></span>

## <a name="asset-size-tables"></a><span data-ttu-id="9e5c9-236">アセット サイズの一覧表</span><span class="sxs-lookup"><span data-stu-id="9e5c9-236">Asset size tables</span></span>


<span data-ttu-id="9e5c9-237">少なくとも、100、200、400 の倍率のアセットを提供することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-237">At a bare minimum, we strongly recommend that you provide assets for the 100, 200, and 400 scale factors.</span></span> <span data-ttu-id="9e5c9-238">すべての倍率のアセットを提供することによって、最適なユーザー エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-238">Providing assets for all scale factors will provide the optimal user experience.</span></span>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-239">小さいタイル (Square71x71Logo)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-239">Small tile (Square71x71Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-240">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-240">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-241">71 x 71</span><span class="sxs-lookup"><span data-stu-id="9e5c9-241">71x71</span></span></td>
    <td><span data-ttu-id="9e5c9-242">Square71x71Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-242">Square71x71Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-243">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-243">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-244">89 x 89</span><span class="sxs-lookup"><span data-stu-id="9e5c9-244">89x89</span></span></td>
    <td><span data-ttu-id="9e5c9-245">Square71x71Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-245">Square71x71Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-246">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-246">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-247">107 x 107</span><span class="sxs-lookup"><span data-stu-id="9e5c9-247">107x107</span></span></td>
    <td><span data-ttu-id="9e5c9-248">Square71x71Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-248">Square71x71Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-249">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-249">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-250">142 x 142</span><span class="sxs-lookup"><span data-stu-id="9e5c9-250">142x142</span></span></td>
    <td><span data-ttu-id="9e5c9-251">Square71x71Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-251">Square71x71Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-252">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-252">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-253">284 x 284</span><span class="sxs-lookup"><span data-stu-id="9e5c9-253">284x284</span></span></td>
    <td><span data-ttu-id="9e5c9-254">Square71x71Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-254">Square71x71Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-255">普通サイズのタイル (Square150x150Logo)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-255">Medium tile (Square150x150Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-256">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-256">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-257">150 x 150</span><span class="sxs-lookup"><span data-stu-id="9e5c9-257">150x150</span></span></td>
    <td><span data-ttu-id="9e5c9-258">Square150x150Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-258">Square150x150Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-259">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-259">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-260">188 x 188</span><span class="sxs-lookup"><span data-stu-id="9e5c9-260">188x188</span></span></td>
    <td><span data-ttu-id="9e5c9-261">Square150x150Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-261">Square150x150Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-262">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-262">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-263">225 x 225</span><span class="sxs-lookup"><span data-stu-id="9e5c9-263">225x225</span></span></td>
    <td><span data-ttu-id="9e5c9-264">Square150x150Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-264">Square150x150Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-265">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-265">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-266">300 x 300</span><span class="sxs-lookup"><span data-stu-id="9e5c9-266">300x300</span></span></td>
    <td><span data-ttu-id="9e5c9-267">Square150x150Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-267">Square150x150Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-268">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-268">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-269">600 x 600</span><span class="sxs-lookup"><span data-stu-id="9e5c9-269">600x600</span></span></td>
    <td><span data-ttu-id="9e5c9-270">Square150x150Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-270">Square150x150Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-271">ワイド タイル (Wide310x150Logo)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-271">Wide tile (Wide310x150Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-272">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-272">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-273">310 x 150</span><span class="sxs-lookup"><span data-stu-id="9e5c9-273">310x150</span></span></td>
    <td><span data-ttu-id="9e5c9-274">Wide310x150Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-274">Wide310x150Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-275">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-275">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-276">388 x 188</span><span class="sxs-lookup"><span data-stu-id="9e5c9-276">388x188</span></span></td>
    <td><span data-ttu-id="9e5c9-277">Wide310x150Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-277">Wide310x150Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-278">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-278">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-279">465 x 225</span><span class="sxs-lookup"><span data-stu-id="9e5c9-279">465x225</span></span></td>
    <td><span data-ttu-id="9e5c9-280">Wide310x150Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-280">Wide310x150Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-281">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-281">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-282">620 x 300</span><span class="sxs-lookup"><span data-stu-id="9e5c9-282">620x300</span></span></td>
    <td><span data-ttu-id="9e5c9-283">Wide310x150Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-283">Wide310x150Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-284">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-284">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-285">1240 x 600</span><span class="sxs-lookup"><span data-stu-id="9e5c9-285">1240x600</span></span></td>
    <td><span data-ttu-id="9e5c9-286">Wide310x150Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-286">Wide310x150Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-287">大きいタイル (Square310x310Logo)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-287">Large tile (Square310x310Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-288">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-288">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-289">310 x 310</span><span class="sxs-lookup"><span data-stu-id="9e5c9-289">310x310</span></span></td>
    <td><span data-ttu-id="9e5c9-290">Square310x310Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-290">Square310x310Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-291">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-291">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-292">388 x 388</span><span class="sxs-lookup"><span data-stu-id="9e5c9-292">388x388</span></span></td>
    <td><span data-ttu-id="9e5c9-293">Square310x310Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-293">Square310x310Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-294">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-294">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-295">465 x 465</span><span class="sxs-lookup"><span data-stu-id="9e5c9-295">465x465</span></span></td>
    <td><span data-ttu-id="9e5c9-296">Square310x310Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-296">Square310x310Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-297">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-297">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-298">620 x 620</span><span class="sxs-lookup"><span data-stu-id="9e5c9-298">620x620</span></span></td>
    <td><span data-ttu-id="9e5c9-299">Square310x310Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-299">Square310x310Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-300">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-300">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-301">1240 x 1240</span><span class="sxs-lookup"><span data-stu-id="9e5c9-301">1240x1240</span></span></td>
    <td><span data-ttu-id="9e5c9-302">Square310x310Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-302">Square310x310Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-303">アプリの一覧のアイコン (Square44x44Logo)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-303">App list icon (Square44x44Logo)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-304">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-304">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-305">44 x 44</span><span class="sxs-lookup"><span data-stu-id="9e5c9-305">44x44</span></span></td>
    <td><span data-ttu-id="9e5c9-306">Square44x44Logo.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-306">Square44x44Logo.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-307">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-307">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-308">55 x 55</span><span class="sxs-lookup"><span data-stu-id="9e5c9-308">55x55</span></span></td>
    <td><span data-ttu-id="9e5c9-309">Square44x44Logo.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-309">Square44x44Logo.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-310">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-310">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-311">66 x 66</span><span class="sxs-lookup"><span data-stu-id="9e5c9-311">66x66</span></span></td>
    <td><span data-ttu-id="9e5c9-312">Square44x44Logo.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-312">Square44x44Logo.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-313">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-313">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-314">88 x 88</span><span class="sxs-lookup"><span data-stu-id="9e5c9-314">88x88</span></span></td>
    <td><span data-ttu-id="9e5c9-315">Square44x44Logo.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-315">Square44x44Logo.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-316">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-316">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-317">176 x 176</span><span class="sxs-lookup"><span data-stu-id="9e5c9-317">176x176</span></span></td>
    <td><span data-ttu-id="9e5c9-318">Square44x44Logo.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-318">Square44x44Logo.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>

<table>
<thead>
<tr><th colspan="3"><span data-ttu-id="9e5c9-319">スプラッシュ画面 (SplashScreen)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-319">Splash screen (SplashScreen)</span></span></th></tr>
</thead>
<tbody>
<tr>
    <td width="20%"><span data-ttu-id="9e5c9-320">倍率 100%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-320">100% scale</span></span></td>
    <td width="20%"><span data-ttu-id="9e5c9-321">620 x 300</span><span class="sxs-lookup"><span data-stu-id="9e5c9-321">620x300</span></span></td>
    <td><span data-ttu-id="9e5c9-322">SplashScreen.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-322">SplashScreen.scale-100.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-323">倍率 125%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-323">125% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-324">775 x 375</span><span class="sxs-lookup"><span data-stu-id="9e5c9-324">775x375</span></span></td>
    <td><span data-ttu-id="9e5c9-325">SplashScreen.scale-125.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-325">SplashScreen.scale-125.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-326">倍率 150%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-326">150% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-327">930 x 450</span><span class="sxs-lookup"><span data-stu-id="9e5c9-327">930x450</span></span></td>
    <td><span data-ttu-id="9e5c9-328">SplashScreen.scale-150.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-328">SplashScreen.scale-150.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-329">倍率 200%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-329">200% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-330">1240 x 600</span><span class="sxs-lookup"><span data-stu-id="9e5c9-330">1240x600</span></span></td>
    <td><span data-ttu-id="9e5c9-331">SplashScreen.scale-200.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-331">SplashScreen.scale-200.png</span></span></td>
</tr>
<tr>
    <td><span data-ttu-id="9e5c9-332">倍率 400%</span><span class="sxs-lookup"><span data-stu-id="9e5c9-332">400% scale</span></span></td>
    <td><span data-ttu-id="9e5c9-333">2480 x 1200</span><span class="sxs-lookup"><span data-stu-id="9e5c9-333">2480x1200</span></span></td>
    <td><span data-ttu-id="9e5c9-334">SplashScreen.scale-400.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-334">SplashScreen.scale-400.png</span></span></td>
</tr>
</tbody>
</table>

<br/>
 

**<span data-ttu-id="9e5c9-335">ターゲット ベースのアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-335">Target-based assets</span></span>**

<span data-ttu-id="9e5c9-336">ターゲット ベースのアセットは、複数の倍率で使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-336">Target-based assets are used across multiple scale factors.</span></span> <span data-ttu-id="9e5c9-337">ターゲット ベースのアセットの要素名は **Square44x44Logo** です。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-337">The element name for target-based assets is **Square44x44Logo**.</span></span> <span data-ttu-id="9e5c9-338">最低でも以下のアセットを提出することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-338">We strongly recommend submitting the following assets as a bare minimum:</span></span>

<span data-ttu-id="9e5c9-339">16 x 16、24 x 24、32 x 32、48 x 48、256 x 256</span><span class="sxs-lookup"><span data-stu-id="9e5c9-339">16x16, 24x24, 32x32, 48x48, 256x256</span></span>

<span data-ttu-id="9e5c9-340">次の表は、すべてのターゲット ベースのアセットのサイズと対応するファイル名の例を示します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-340">The following table lists all target-based asset sizes and corresponding file name examples:</span></span>

| <span data-ttu-id="9e5c9-341">アセットのサイズ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-341">Asset size</span></span> | <span data-ttu-id="9e5c9-342">ファイル名の例</span><span class="sxs-lookup"><span data-stu-id="9e5c9-342">File name example</span></span>                  |
|------------|------------------------------------|
| <span data-ttu-id="9e5c9-343">16 x 16\*</span><span class="sxs-lookup"><span data-stu-id="9e5c9-343">16x16\*</span></span>    | <span data-ttu-id="9e5c9-344">Square44x44Logo.targetsize-16.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-344">Square44x44Logo.targetsize-16.png</span></span>  |
| <span data-ttu-id="9e5c9-345">24 x 24\*</span><span class="sxs-lookup"><span data-stu-id="9e5c9-345">24x24\*</span></span>    | <span data-ttu-id="9e5c9-346">Square44x44Logo.targetsize-24.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-346">Square44x44Logo.targetsize-24.png</span></span>  |
| <span data-ttu-id="9e5c9-347">32 x 32\*</span><span class="sxs-lookup"><span data-stu-id="9e5c9-347">32x32\*</span></span>    | <span data-ttu-id="9e5c9-348">Square44x44Logo.targetsize-32.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-348">Square44x44Logo.targetsize-32.png</span></span>  |
| <span data-ttu-id="9e5c9-349">48 x 48\*</span><span class="sxs-lookup"><span data-stu-id="9e5c9-349">48x48\*</span></span>    | <span data-ttu-id="9e5c9-350">Square44x44Logo.targetsize-48.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-350">Square44x44Logo.targetsize-48.png</span></span>  |
| <span data-ttu-id="9e5c9-351">256 x 256\*</span><span class="sxs-lookup"><span data-stu-id="9e5c9-351">256x256\*</span></span>  | <span data-ttu-id="9e5c9-352">Square44x44Logo.targetsize-256.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-352">Square44x44Logo.targetsize-256.png</span></span> |
| <span data-ttu-id="9e5c9-353">20 x 20</span><span class="sxs-lookup"><span data-stu-id="9e5c9-353">20x20</span></span>      | <span data-ttu-id="9e5c9-354">Square44x44Logo.targetsize-20.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-354">Square44x44Logo.targetsize-20.png</span></span>  |
| <span data-ttu-id="9e5c9-355">30 x 30</span><span class="sxs-lookup"><span data-stu-id="9e5c9-355">30x30</span></span>      | <span data-ttu-id="9e5c9-356">Square44x44Logo.targetsize-30.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-356">Square44x44Logo.targetsize-30.png</span></span>  |
| <span data-ttu-id="9e5c9-357">36 x 36</span><span class="sxs-lookup"><span data-stu-id="9e5c9-357">36x36</span></span>      | <span data-ttu-id="9e5c9-358">Square44x44Logo.targetsize-36.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-358">Square44x44Logo.targetsize-36.png</span></span>  |
| <span data-ttu-id="9e5c9-359">40 x 40</span><span class="sxs-lookup"><span data-stu-id="9e5c9-359">40x40</span></span>      | <span data-ttu-id="9e5c9-360">Square44x44Logo.targetsize-40.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-360">Square44x44Logo.targetsize-40.png</span></span>  |
| <span data-ttu-id="9e5c9-361">60 x 60</span><span class="sxs-lookup"><span data-stu-id="9e5c9-361">60x60</span></span>      | <span data-ttu-id="9e5c9-362">Square44x44Logo.targetsize-60.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-362">Square44x44Logo.targetsize-60.png</span></span>  |
| <span data-ttu-id="9e5c9-363">64 x 64</span><span class="sxs-lookup"><span data-stu-id="9e5c9-363">64x64</span></span>      | <span data-ttu-id="9e5c9-364">Square44x44Logo.targetsize-64.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-364">Square44x44Logo.targetsize-64.png</span></span>  |
| <span data-ttu-id="9e5c9-365">72 x 72</span><span class="sxs-lookup"><span data-stu-id="9e5c9-365">72x72</span></span>      | <span data-ttu-id="9e5c9-366">Square44x44Logo.targetsize-72.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-366">Square44x44Logo.targetsize-72.png</span></span>  |
| <span data-ttu-id="9e5c9-367">80 x 80</span><span class="sxs-lookup"><span data-stu-id="9e5c9-367">80x80</span></span>      | <span data-ttu-id="9e5c9-368">Square44x44Logo.targetsize-80.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-368">Square44x44Logo.targetsize-80.png</span></span>  |
| <span data-ttu-id="9e5c9-369">96 x 96</span><span class="sxs-lookup"><span data-stu-id="9e5c9-369">96x96</span></span>      | <span data-ttu-id="9e5c9-370">Square44x44Logo.targetsize-96.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-370">Square44x44Logo.targetsize-96.png</span></span>  |

 

<span data-ttu-id="9e5c9-371">\* ベースラインとしてこれらのサイズのアセットを提出します</span><span class="sxs-lookup"><span data-stu-id="9e5c9-371">\* Submit these asset sizes as a baseline</span></span>

## <a name="asset-types"></a><span data-ttu-id="9e5c9-372">アセットの種類</span><span class="sxs-lookup"><span data-stu-id="9e5c9-372">Asset types</span></span>


<span data-ttu-id="9e5c9-373">ここでは、すべてのアセットの種類、その用途、推奨されるファイル名の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-373">Listed here are all asset types, their uses, and recommended file names.</span></span>

**<span data-ttu-id="9e5c9-374">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-374">Tile assets</span></span>**

-   <span data-ttu-id="9e5c9-375">中央に配置されるアセットは、通常、スタート画面にアプリを表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-375">Centered assets are generally used on the Start to showcase your app.</span></span>
-   <span data-ttu-id="9e5c9-376">ファイル名の形式: [Square\Wide]\*x\*Logo.scale-\*.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-376">File name format: [Square\Wide]\*x\*Logo.scale-\*.png</span></span>
-   <span data-ttu-id="9e5c9-377">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-377">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="9e5c9-378">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-378">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-379">既定のスタート画面のタイル (デスクトップとモバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-379">Default Start tiles (desktop and mobile)</span></span>
    -   <span data-ttu-id="9e5c9-380">アクション センター (デスクトップとモバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-380">Action center (desktop and mobile)</span></span>
    -   <span data-ttu-id="9e5c9-381">タスク スイッチャー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-381">Task switcher (mobile)</span></span>
    -   <span data-ttu-id="9e5c9-382">共有ピッカー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-382">Share picker (mobile)</span></span>
    -   <span data-ttu-id="9e5c9-383">ピッカー (モバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-383">Picker (mobile)</span></span>
    -   <span data-ttu-id="9e5c9-384">ストア</span><span class="sxs-lookup"><span data-stu-id="9e5c9-384">Store</span></span>

**<span data-ttu-id="9e5c9-385">プレート付きのスケーラブルな一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-385">Scalable list assets with plate</span></span>**

-   <span data-ttu-id="9e5c9-386">これらのアセットは拡大縮小が必要なサーフェスで使われます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-386">These assets are used on surfaces that request scale factors.</span></span> <span data-ttu-id="9e5c9-387">アセットのバック プレートはシステムによって提供されるか、アプリに含まれている場合は独自の背景色のプレートが使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-387">Assets either get plated by the system or come with their own background color if the app includes that.</span></span>
-   <span data-ttu-id="9e5c9-388">ファイル名の形式: Square44x44Logo.scale-\*.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-388">File name format: Square44x44Logo.scale-\*.png</span></span>
-   <span data-ttu-id="9e5c9-389">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-389">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="9e5c9-390">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-390">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-391">スタート画面のすべてのアプリの一覧 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-391">Start all apps list (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-392">スタート画面のよく使うアプリの一覧 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-392">Start most-frequently used list (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-393">タスク マネージャー (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-393">Task manager (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-394">Cortana の検索結果</span><span class="sxs-lookup"><span data-stu-id="9e5c9-394">Cortana search results</span></span>
    -   <span data-ttu-id="9e5c9-395">スタート画面のすべてのアプリの一覧 (モバイル)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-395">Start all apps list (mobile)</span></span>
    -   <span data-ttu-id="9e5c9-396">設定</span><span class="sxs-lookup"><span data-stu-id="9e5c9-396">Settings</span></span>

**<span data-ttu-id="9e5c9-397">プレート付きのターゲット サイズの一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-397">Target-size list assets with plate</span></span>**

-   <span data-ttu-id="9e5c9-398">これらはプレート付きで、拡大縮小されない固定サイズのアセットです。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-398">These are fixed asset sizes that don't scale with plateaus.</span></span> <span data-ttu-id="9e5c9-399">ほとんどの場合、従来のエクスペリエンスに使用されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-399">Mostly used for legacy experiences.</span></span> <span data-ttu-id="9e5c9-400">アセットはシステムによって確認されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-400">Assets are checked by the system.</span></span>
-   <span data-ttu-id="9e5c9-401">ファイル名の形式: Square44x44Logo.targetsize-\*.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-401">File name format: Square44x44Logo.targetsize-\*.png</span></span>
-   <span data-ttu-id="9e5c9-402">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-402">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="9e5c9-403">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-403">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-404">スタート画面のジャンプ リスト (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-404">Start jump list (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-405">スタート画面のタイルの下隅 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-405">Start lower corner of tile (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-406">ショートカット (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-406">Shortcuts (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-407">コントロール パネル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-407">Control Panel (desktop)</span></span>

**<span data-ttu-id="9e5c9-408">プレートなしのターゲット サイズの一覧のアセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-408">Target-size list assets without plate</span></span>**

-   <span data-ttu-id="9e5c9-409">これらは、システムによってプレートの追加や拡大縮小が行われないアセットです。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-409">These are assets that don't get plated or scaled by the system.</span></span>
-   <span data-ttu-id="9e5c9-410">ファイル名の形式: Square44x44Logo.targetsize-\*\_altform-unplated.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-410">File name format: Square44x44Logo.targetsize-\*\_altform-unplated.png</span></span>
-   <span data-ttu-id="9e5c9-411">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-411">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="9e5c9-412">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-412">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-413">タスク バーとタスク バー サムネイル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-413">Taskbar and taskbar thumbnail (desktop)</span></span>
    -   <span data-ttu-id="9e5c9-414">タスク バーのジャンプ リスト</span><span class="sxs-lookup"><span data-stu-id="9e5c9-414">Taskbar jumplist</span></span>
    -   <span data-ttu-id="9e5c9-415">タスク ビュー</span><span class="sxs-lookup"><span data-stu-id="9e5c9-415">Task view</span></span>
    -   <span data-ttu-id="9e5c9-416">Alt + Tab キー</span><span class="sxs-lookup"><span data-stu-id="9e5c9-416">ALT+TAB</span></span>

**<span data-ttu-id="9e5c9-417">ファイル拡張子アセット</span><span class="sxs-lookup"><span data-stu-id="9e5c9-417">File extension assets</span></span>**

-   <span data-ttu-id="9e5c9-418">これらはファイル拡張子に固有のアセットです。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-418">These are assets specific to file extensions.</span></span> <span data-ttu-id="9e5c9-419">エクスプ ローラーで Win32 スタイルのファイルの関連付けアイコンの横に表示され、テーマに依存しません。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-419">They appear next to Win32-style file association icons in File Explorer and must be theme-agnostic.</span></span> <span data-ttu-id="9e5c9-420">サイズ調整は、デスクトップ プラットフォームとモバイル プラットフォームで異なります。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-420">Sizing is different on desktop and mobile platforms.</span></span>
-   <span data-ttu-id="9e5c9-421">ファイル名の形式: \*LogoExtensions.targetsize-\*.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-421">File name format: \*LogoExtensions.targetsize-\*.png</span></span>
-   <span data-ttu-id="9e5c9-422">影響を受けるアプリ: ミュージック、ビデオ、フォト、Microsoft Edge、Microsoft Office</span><span class="sxs-lookup"><span data-stu-id="9e5c9-422">Impacted apps: Music, Video, Photos, Microsoft Edge, Microsoft Office</span></span>
-   <span data-ttu-id="9e5c9-423">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-423">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-424">エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="9e5c9-424">File Explorer</span></span>
    -   <span data-ttu-id="9e5c9-425">Cortana</span><span class="sxs-lookup"><span data-stu-id="9e5c9-425">Cortana</span></span>
    -   <span data-ttu-id="9e5c9-426">さまざまな UI サーフェス (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="9e5c9-426">Various UI surfaces (desktop)</span></span>

**<span data-ttu-id="9e5c9-427">スプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="9e5c9-427">Splash screen</span></span>**

-   <span data-ttu-id="9e5c9-428">アプリのスプラッシュ画面に表示されるアセット。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-428">The asset that appears on your app's splash screen.</span></span> <span data-ttu-id="9e5c9-429">デスクトップとモバイルの両方のプラットフォームで自動的に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="9e5c9-429">Automatically scales on both desktop and mobile platforms.</span></span>
-   <span data-ttu-id="9e5c9-430">ファイル名の形式: SplashScreen.scale-\*.png</span><span class="sxs-lookup"><span data-stu-id="9e5c9-430">File name format: SplashScreen.scale-\*.png</span></span>
-   <span data-ttu-id="9e5c9-431">影響を受けるアプリ: すべての UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="9e5c9-431">Impacted apps: Every UWP app</span></span>
-   <span data-ttu-id="9e5c9-432">用途:</span><span class="sxs-lookup"><span data-stu-id="9e5c9-432">Uses:</span></span>
    -   <span data-ttu-id="9e5c9-433">アプリのスプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="9e5c9-433">App's splash screen</span></span>