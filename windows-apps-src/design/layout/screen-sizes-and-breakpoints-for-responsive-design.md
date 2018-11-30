---
title: 画面のサイズとレスポンシブ デザインのブレークポイント
description: Windows 10 エコシステムの多くのデバイス用に UI を最適化するのではなく、ブレークポイントと呼ばれるいくつかの主要な幅カテゴリ用に設計することをお勧めします。
ms.date: 08/30/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0959c9bc09782538cdb15a68c46b0797d4b7d230
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8214000"
---
#  <a name="screen-sizes-and-breakpoints"></a><span data-ttu-id="1a4ab-104">画面のサイズとブレークポイント</span><span class="sxs-lookup"><span data-stu-id="1a4ab-104">Screen sizes and breakpoints</span></span>

<span data-ttu-id="1a4ab-105">UWP アプリは、Windows 10 を実行している任意のデバイスで実行できます (電話、タブレット、デスクトップ、テレビなど)。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-105">UWP apps can run on any device running Windows 10, which includes phones, tablets, desktops, TVs, and more.</span></span> <span data-ttu-id="1a4ab-106">膨大な数の対象デバイスとデバイスごとに、UI を最適化するのではなく、windows 10 エコシステム全体での画面サイズ、ことお勧めします (「ブレークポイント」とも呼ばれます)、いくつかの主要な幅カテゴリ用に設計します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-106">With a huge number of device targets and screen sizes across the Windows10 ecosystem, rather than optimizing your UI for each device, we recommended designing for a few key width categories (also called "breakpoints"):</span></span> 
- <span data-ttu-id="1a4ab-107">小 (640 ピクセル以下)</span><span class="sxs-lookup"><span data-stu-id="1a4ab-107">Small (smaller than 640px)</span></span>
- <span data-ttu-id="1a4ab-108">中 (641 ピクセル ～ 1007 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="1a4ab-108">Medium (641px to 1007px)</span></span>
- <span data-ttu-id="1a4ab-109">大 (1008 ピクセル以上)</span><span class="sxs-lookup"><span data-stu-id="1a4ab-109">Large (1008px and larger)</span></span>

> [!TIP]
> <span data-ttu-id="1a4ab-110">特定のブレークポイント向けに設計するときは、画面のサイズではなく、アプリ (アプリのウィンドウ) で使用できる画面領域の量に対して設計します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-110">When designing for specific breakpoints, design for the amount of screen space available to your app (the app's window), not the screen size.</span></span> <span data-ttu-id="1a4ab-111">アプリが全画面表示で実行されているときは、アプリ ウィンドウのサイズは画面と同じですが、アプリが全画面表示でないときは、ウィンドウは画面より小さくなります。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-111">When the app is running full-screen, the app window is the same size as the screen, but when the app is not full-screen, the window is smaller than the screen.</span></span>

## <a name="breakpoints"></a><span data-ttu-id="1a4ab-112">ブレークポイント</span><span class="sxs-lookup"><span data-stu-id="1a4ab-112">Breakpoints</span></span>
<span data-ttu-id="1a4ab-113">次の表で、さまざまなサイズ クラスとブレークポイントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-113">This table describes the different size classes and breakpoints.</span></span>

![レスポンシブ デザインのブレークポイント](images/breakpoints/size-classes.svg)

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1a4ab-115">サイズ クラス</span><span class="sxs-lookup"><span data-stu-id="1a4ab-115">Size class</span></span></th>
<th align="left"><span data-ttu-id="1a4ab-116">ブレークポイント</span><span class="sxs-lookup"><span data-stu-id="1a4ab-116">Breakpoints</span></span></th>
<th align="left"><span data-ttu-id="1a4ab-117">一般的な画面サイズ (対角線)</span><span class="sxs-lookup"><span data-stu-id="1a4ab-117">Typical screen size (diagonal)</span></span></th>
<th align="left"><span data-ttu-id="1a4ab-118">デバイス</span><span class="sxs-lookup"><span data-stu-id="1a4ab-118">Devices</span></span></th>
<th align="left"><span data-ttu-id="1a4ab-119">ウィンドウ サイズ</span><span class="sxs-lookup"><span data-stu-id="1a4ab-119">Window sizes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-120">小</span><span class="sxs-lookup"><span data-stu-id="1a4ab-120">Small</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-121">640 ピクセル以下</span><span class="sxs-lookup"><span data-stu-id="1a4ab-121">640px or less</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-122">4&quot; ～ 6&quot;; 20&quot; ～ 65&quot;</span><span class="sxs-lookup"><span data-stu-id="1a4ab-122">4&quot; to 6&quot;; 20&quot; to 65&quot;</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-123">電話、テレビ</span><span class="sxs-lookup"><span data-stu-id="1a4ab-123">Phones, TVs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-124">320 x 569、360 x 640、480 x 854</span><span class="sxs-lookup"><span data-stu-id="1a4ab-124">320x569, 360x640, 480x854</span></span></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-125">中</span><span class="sxs-lookup"><span data-stu-id="1a4ab-125">Medium</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-126">641 ピクセル～ 1007 ピクセル</span><span class="sxs-lookup"><span data-stu-id="1a4ab-126">641px to 1007px</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-127">7&quot; ～ 12&quot;</span><span class="sxs-lookup"><span data-stu-id="1a4ab-127">7&quot; to 12&quot;</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-128">ファブレット、タブレット</span><span class="sxs-lookup"><span data-stu-id="1a4ab-128">Phablets, tablets</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-129">960 x 540</span><span class="sxs-lookup"><span data-stu-id="1a4ab-129">960x540</span></span></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-130">大</span><span class="sxs-lookup"><span data-stu-id="1a4ab-130">Large</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-131">1008 ピクセル以上</span><span class="sxs-lookup"><span data-stu-id="1a4ab-131">1008px or greater</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-132">13&quot; 以上</span><span class="sxs-lookup"><span data-stu-id="1a4ab-132">13&quot; and larger</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-133">PC、ノート PC、Surface Hub</span><span class="sxs-lookup"><span data-stu-id="1a4ab-133">PCs, laptops, Surface Hubs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="1a4ab-134">1024 x 640、1366 x 768、1920 x 1080</span><span class="sxs-lookup"><span data-stu-id="1a4ab-134">1024x640, 1366x768, 1920x1080</span></span></td>
</tr>
</tbody>
</table>

## <a name="why-are-tvs-considered-small"></a><span data-ttu-id="1a4ab-135">なぜテレビは「小さい」と見なされるのですか。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-135">Why are TVs considered "small"?</span></span> 

<span data-ttu-id="1a4ab-136">ほとんどのテレビは物理的に非常に大きく (40 から 65 インチが一般的)、高解像度 (HD または 4K) ですが、10 フィート (約 3 m) 離れた場所から表示する 1080P のテレビの設計は、机上の 1 フィート (約 30 cm) 離れた場所に置かれる 1080p のモニターの設計とは異なります。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-136">While most TVs are physically quite large (40 to 65 inches is common) and have high resolutions (HD or 4k), designing for a 1080P TV that you view from 10 feet away is different from designing for a 1080p monitor sitting a foot away on your desk.</span></span> <span data-ttu-id="1a4ab-137">距離を考慮するときに、テレビの 1080 ピクセルは 540 ピクセルのモニターにより近くなります。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-137">When you account for distance, the TV's 1080 pixels are more like a 540-pixel monitor that's much closer.</span></span>

<span data-ttu-id="1a4ab-138">UWP の有効ピクセルのシステムでは、視聴距離を自動的に考慮します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-138">UWP's effective pixel system automatically takes viewing distance in account for you.</span></span> <span data-ttu-id="1a4ab-139">コントロールまたはブレークポイントの範囲のサイズを指定するときは、実際には "有効" ピクセルを使用しています。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-139">When you specify a size for a control or a breakpoint range, you're actually using "effective" pixels.</span></span> <span data-ttu-id="1a4ab-140">たとえば、1080 ピクセル以上に対応するコードを作成する場合は、1080 モニターでそのコードを使用しますが、1080p のテレビでは使用しません。これは、1080p のテレビの物理ピクセルは 1080 ですが、有効ピクセルは 540 しかないためです。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-140">For example, if you create responsive code for 1080 pixels and higher, a 1080 monitor will use that code, but a 1080p TV will not--because although a 1080p TV has 1080 physical pixels, it only has 540 effective pixels.</span></span> <span data-ttu-id="1a4ab-141">このため、テレビの設計は、携帯電話の設計に似ています。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-141">Which makes designing for a TV similar to designing for a phone.</span></span>

## <a name="effective-pixels-and-scale-factor"></a><span data-ttu-id="1a4ab-142">有効ピクセルと倍率</span><span class="sxs-lookup"><span data-stu-id="1a4ab-142">Effective pixels and scale factor</span></span>

<span data-ttu-id="1a4ab-143">UWP アプリは、すべての Windows 10 デバイスでアプリが判読可能であることを保証するために、UI を自動的に拡大縮小します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-143">UWP apps automatically scale your UI to guarantee that your app will be legible on all Windows 10 devices.</span></span> <span data-ttu-id="1a4ab-144">Windows では、ディスプレイの DPI (1 インチあたりのドット数) と、デバイスの視聴距離に基づいて各ディスプレイが自動的に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-144">Windows automatically scales for each display based on its DPI (dots-per-inch) and the viewing distance of the device.</span></span> <span data-ttu-id="1a4ab-145">ユーザーは、**[設定]** > **[ディスプレイ]** > **[拡大縮小とレイアウト]** の設定ページに移動して既定値を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-145">Users can override the default value and by going to **Settings** > **Display** > **Scale and layout** settings page.</span></span> 


## <a name="general-recommendations"></a><span data-ttu-id="1a4ab-146">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="1a4ab-146">General recommendations</span></span>

### <a name="small"></a><span data-ttu-id="1a4ab-147">小</span><span class="sxs-lookup"><span data-stu-id="1a4ab-147">Small</span></span>
- <span data-ttu-id="1a4ab-148">ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-148">Set left and right window margins to 12px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="1a4ab-149">手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-149">Dock [app bars](../controls-and-patterns/app-bars.md) to the bottom of the window for improved reachability.</span></span>
- <span data-ttu-id="1a4ab-150">一度に 1 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-150">Use one column/region at a time.</span></span>
- <span data-ttu-id="1a4ab-151">検索を表すアイコンを使います (検索ボックスを表示しない)。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-151">Use an icon to represent search (don't show a search box).</span></span>
- <span data-ttu-id="1a4ab-152">[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)をオーバーレイ モードにして画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-152">Put the [navigation pane](../controls-and-patterns/navigationview.md) in overlay mode to conserve screen space.</span></span>
- <span data-ttu-id="1a4ab-153">[マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-153">If you're using the [master details pattern](../controls-and-patterns/master-details.md), use the stacked presentation mode to save screen space.</span></span>

### <a name="medium"></a><span data-ttu-id="1a4ab-154">中</span><span class="sxs-lookup"><span data-stu-id="1a4ab-154">Medium</span></span>
- <span data-ttu-id="1a4ab-155">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-155">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="1a4ab-156">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-156">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span>
- <span data-ttu-id="1a4ab-157">最大で 2 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-157">Use up to two columns/regions.</span></span>
- <span data-ttu-id="1a4ab-158">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-158">Show the search box.</span></span>
- <span data-ttu-id="1a4ab-159">アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を小片モードにします。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-159">Put the [navigation pane](../controls-and-patterns/navigationview.md) into sliver mode so a narrow strip of icons always shows.</span></span>
- <span data-ttu-id="1a4ab-160">[テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-160">Consider further tailoring for [TV experiences](http://go.microsoft.com/fwlink/?LinkId=760736).</span></span>

### <a name="large"></a><span data-ttu-id="1a4ab-161">大</span><span class="sxs-lookup"><span data-stu-id="1a4ab-161">Large</span></span>
- <span data-ttu-id="1a4ab-162">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-162">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="1a4ab-163">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-163">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span>
- <span data-ttu-id="1a4ab-164">最大で 3 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-164">Use up to three columns/regions.</span></span>
- <span data-ttu-id="1a4ab-165">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-165">Show the search box.</span></span>
- <span data-ttu-id="1a4ab-166">常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を固定モードにします。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-166">Put the [navigation pane](../controls-and-patterns/navigationview.md) into docked mode so that it always shows.</span></span>

>[!TIP] 
> <span data-ttu-id="1a4ab-167">[**ある電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431)ユーザーはその電話をノートのように機能するモニター、マウス、キーボードに互換性のある windows 10 のモバイル デバイスを接続できます。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-167">With [**Continuum for Phones**](http://go.microsoft.com/fwlink/p/?LinkID=699431), users can connect compatible Windows10 mobile devices to a monitor, mouse and keyboard to make their phones work like laptops.</span></span> <span data-ttu-id="1a4ab-168">特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常にそのサイズ クラスで維持されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="1a4ab-168">Keep this new capability in mind when designing for specific breakpoints - a mobile phone will not always stay in the size class.</span></span>


