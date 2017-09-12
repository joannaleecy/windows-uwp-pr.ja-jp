---
author: mijacobs
title: "画面のサイズとレスポンシブ デザインのブレークポイント"
description: .
ms.assetid: BF42E810-CDC8-47D2-9C30-BAA19DCBE2DA
label: Screen sizes and break points
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b56cdeeb9a3c3d3ca89e19d8057e3d93241e6c3c
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
#  <a name="screen-sizes-and-break-points-for-responsive-design"></a><span data-ttu-id="2cb85-104">画面のサイズとレスポンシブ デザインのブレークポイント</span><span class="sxs-lookup"><span data-stu-id="2cb85-104">Screen sizes and break points for responsive design</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="2cb85-105">対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。</span><span class="sxs-lookup"><span data-stu-id="2cb85-105">The number of device targets and screen sizes across the Windows 10 ecosystem is too great to worry about optimizing your UI for each one.</span></span> <span data-ttu-id="2cb85-106">その代わり、360、640、1024、および 1366 epx という 4 種類の主要なキー幅 ("ブレークポイント" とも呼ばれます) を設計することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-106">Instead, we recommended designing for a few key widths (also called "breakpoints"): 360, 640, 1024 and 1366 epx.</span></span>

> [!TIP]
> <span data-ttu-id="2cb85-107">特定のブレークポイント向けに設計するときは、アプリ (アプリのウィンドウ) で使用できる画面領域の量向けに設計します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-107">When designing for specific breakpoints, design for the amount of screen space available to your app (the app's window).</span></span> <span data-ttu-id="2cb85-108">アプリが全画面表示で実行されているときは、アプリ ウィンドウが画面と同じサイズですが、それ以外の状況では、画面より小さいサイズです。</span><span class="sxs-lookup"><span data-stu-id="2cb85-108">When the app is running full-screen, the app window is the same size as the screen, but in other cases, it's smaller.</span></span>
 

<span data-ttu-id="2cb85-109">次の表は、さまざまなサイズ クラスを説明し、これらのサイズ クラスを調整するため一般的な推奨事項を示します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-109">This table describes the different size classes and provides general recommendations for tailoring for those size classes.</span></span>

![レスポンシブ デザインのブレークポイント](images/rsp-design/rspd-breakpoints.png)

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="2cb85-111">サイズ クラス</span><span class="sxs-lookup"><span data-stu-id="2cb85-111">Size class</span></span></th>
<th align="left"><span data-ttu-id="2cb85-112">小</span><span class="sxs-lookup"><span data-stu-id="2cb85-112">small</span></span></th>
<th align="left"><span data-ttu-id="2cb85-113">中</span><span class="sxs-lookup"><span data-stu-id="2cb85-113">medium</span></span></th>
<th align="left"><span data-ttu-id="2cb85-114">大</span><span class="sxs-lookup"><span data-stu-id="2cb85-114">large</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="2cb85-115">一般的な画面サイズ (対角線)</span><span class="sxs-lookup"><span data-stu-id="2cb85-115">Typical screen size (diagonal)</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-116">4&quot; ～ 6"</span><span class="sxs-lookup"><span data-stu-id="2cb85-116">4&quot; to 6</span></span>&quot;</td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-117">7&quot; ～ 12&quot;、またはテレビ</span><span class="sxs-lookup"><span data-stu-id="2cb85-117">7&quot; to 12&quot;, or TVs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-118">13&quot; 以上</span><span class="sxs-lookup"><span data-stu-id="2cb85-118">13&quot; and larger</span></span></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="2cb85-119">一般的なデバイス</span><span class="sxs-lookup"><span data-stu-id="2cb85-119">Typical devices</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-120">電話</span><span class="sxs-lookup"><span data-stu-id="2cb85-120">Phones</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-121">ファブレット、タブレット、テレビ</span><span class="sxs-lookup"><span data-stu-id="2cb85-121">Phablets, tablets, TVs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-122">PC、ノート PC、Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2cb85-122">PCs, laptops, Surface Hubs</span></span></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="2cb85-123">有効なピクセル単位の一般的なウィンドウ サイズ</span><span class="sxs-lookup"><span data-stu-id="2cb85-123">Common window sizes in effective pixels</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-124">320 x 569、360 x 640、480 x 854</span><span class="sxs-lookup"><span data-stu-id="2cb85-124">320x569, 360x640, 480x854</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-125">960 x 540、1024 x 640</span><span class="sxs-lookup"><span data-stu-id="2cb85-125">960x540, 1024x640</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-126">1366 x 768、1920 x 1080</span><span class="sxs-lookup"><span data-stu-id="2cb85-126">1366x768, 1920x1080</span></span></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="2cb85-127">有効ピクセル単位でのウィンドウの幅のブレークポイント</span><span class="sxs-lookup"><span data-stu-id="2cb85-127">Window width breakpoints in effective pixels</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-128">640 ピクセル以下</span><span class="sxs-lookup"><span data-stu-id="2cb85-128">640px or less</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-129">641 ピクセル～ 1007 ピクセル</span><span class="sxs-lookup"><span data-stu-id="2cb85-129">641px to 1007px</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="2cb85-130">1008 ピクセル以上</span><span class="sxs-lookup"><span data-stu-id="2cb85-130">1008px or greater</span></span></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="2cb85-131">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="2cb85-131">General recommendations</span></span></td>
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="2cb85-132">タブ要素を中央に配置します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-132">Center tab elements.</span></span></li>
<li><span data-ttu-id="2cb85-133">ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-133">Set left and right window margins to 12px to create a visual separation between the left and right edges of the app window.</span></span></li>
<li><span data-ttu-id="2cb85-134">手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-134">Dock [app bars](../controls-and-patterns/app-bars.md) to the bottom of the window for improved reachability</span></span></li>
<li><span data-ttu-id="2cb85-135">一度に 1 列/地域を使います。</span><span class="sxs-lookup"><span data-stu-id="2cb85-135">Use one column/region at a time</span></span></li>
<li><span data-ttu-id="2cb85-136">検索を表すアイコンを使います (検索ボックスを表示しない)。</span><span class="sxs-lookup"><span data-stu-id="2cb85-136">Use an icon to represent search (don't show a search box).</span></span></li>
<li><span data-ttu-id="2cb85-137">[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)をオーバーレイ モードにして画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-137">Put the [navigation pane](../controls-and-patterns/navigationview.md) in overlay mode to conserve screen space.</span></span></li>
<li><span data-ttu-id="2cb85-138">[マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-138">If you're using the [master details pattern](../controls-and-patterns/master-details.md), use the stacked presentation mode to save screen space.</span></span></li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="2cb85-139">タブ要素を左揃えにします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-139">Make tab elements left-aligned.</span></span></li>
<li><span data-ttu-id="2cb85-140">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-140">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span></li>
<li><span data-ttu-id="2cb85-141">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-141">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span></li>
<li><span data-ttu-id="2cb85-142">最大 2 列/領域</span><span class="sxs-lookup"><span data-stu-id="2cb85-142">Up to two columns/regions</span></span></li>
<li><span data-ttu-id="2cb85-143">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-143">Show the search box.</span></span></li>
<li><span data-ttu-id="2cb85-144">アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を小片モードにします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-144">Put the [navigation pane](../controls-and-patterns/navigationview.md) into sliver mode so a narrow strip of icons always shows.</span></span></li>
<li><span data-ttu-id="2cb85-145">[テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-145">Consider further tailoring for [TV experiences](http://go.microsoft.com/fwlink/?LinkId=760736).</span></span></li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="2cb85-146">タブ要素を左揃えにします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-146">Make tab elements left-aligned.</span></span></li>
<li><span data-ttu-id="2cb85-147">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-147">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span></li>
<li><span data-ttu-id="2cb85-148">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-148">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span></li>
<li><span data-ttu-id="2cb85-149">最大 3 列/領域</span><span class="sxs-lookup"><span data-stu-id="2cb85-149">Up to three columns/regions</span></span></li>
<li><span data-ttu-id="2cb85-150">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="2cb85-150">Show the search box.</span></span></li>
<li><span data-ttu-id="2cb85-151">常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を固定モードにします。</span><span class="sxs-lookup"><span data-stu-id="2cb85-151">Put the [navigation pane](../controls-and-patterns/navigationview.md) into docked mode so that it always shows.</span></span></li>
</ul></td>
</tr>
</tbody>
</table>

<span data-ttu-id="2cb85-152">互換性のある Windows 10 Mobile デバイスの新しいエクスペリエンスである[**電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431) を利用すると、ユーザーは電話をモニター、マウス、およびキーボードに接続して、その電話をノート PC のように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="2cb85-152">With [**Continuum for Phones**](http://go.microsoft.com/fwlink/p/?LinkID=699431), a new experience for compatible Windows 10 mobile devices, users can connect their phones to a monitor, mouse and keyboard to make their phones work like laptops.</span></span> <span data-ttu-id="2cb85-153">特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常に小さいサイズのクラスで維持されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="2cb85-153">Keep this new capability in mind when designing for specific breakpoints - a mobile phone will not always stay in the small size class.</span></span>
 
