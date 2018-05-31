---
author: mijacobs
title: 画面のサイズとレスポンシブ デザインのブレークポイント
description: Windows 10 エコシステムの多くのデバイス用に UI を最適化するのではなく、ブレークポイントと呼ばれるいくつかの主要な幅カテゴリ用に設計することをお勧めします。
ms.author: mijacobs
ms.date: 08/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0d84530c1a7c3795c566495c1eae121691b0766a
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1688938"
---
#  <a name="screen-sizes-and-breakpoints"></a><span data-ttu-id="82c3f-104">画面のサイズとブレークポイント</span><span class="sxs-lookup"><span data-stu-id="82c3f-104">Screen sizes and breakpoints</span></span>

<span data-ttu-id="82c3f-105">UWP アプリは、Windows 10 を実行している任意のデバイスで実行できます (電話、タブレット、デスクトップ、テレビなど)。</span><span class="sxs-lookup"><span data-stu-id="82c3f-105">UWP apps can run on any device running Windows 10, which includes phones, tablets, desktops, TVs, and more.</span></span> <span data-ttu-id="82c3f-106">Windows 10 エコシステムには大量のデバイス ターゲットと画面サイズが存在するため、各デバイス用に UI を最適化するのではなく、いくつかの主要な幅カテゴリ ("ブレークポイント" とも呼ばれる) 用に設計することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="82c3f-106">With a huge number of device targets and screen sizes across the Windows 10 ecosystem, rather than optimizing your UI for each device, we recommended designing for a few key width categories (also called "breakpoints"):</span></span> 
- <span data-ttu-id="82c3f-107">小 (640 ピクセル以下)</span><span class="sxs-lookup"><span data-stu-id="82c3f-107">Small (smaller than 640px)</span></span>
- <span data-ttu-id="82c3f-108">中 (641 ピクセル ～ 1007 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="82c3f-108">Medium (641px to 1007px)</span></span>
- <span data-ttu-id="82c3f-109">大 (1008 ピクセル以上)</span><span class="sxs-lookup"><span data-stu-id="82c3f-109">Large (1008px and larger)</span></span>

> [!TIP]
> <span data-ttu-id="82c3f-110">特定のブレークポイント向けに設計するときは、画面のサイズではなく、アプリ (アプリのウィンドウ) で使用できる画面領域の量に対して設計します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-110">When designing for specific breakpoints, design for the amount of screen space available to your app (the app's window), not the screen size.</span></span> <span data-ttu-id="82c3f-111">アプリが全画面表示で実行されているときは、アプリ ウィンドウのサイズは画面と同じですが、アプリが全画面表示でないときは、ウィンドウは画面より小さくなります。</span><span class="sxs-lookup"><span data-stu-id="82c3f-111">When the app is running full-screen, the app window is the same size as the screen, but when the app is not full-screen, the window is smaller than the screen.</span></span>

## <a name="breakpoints"></a><span data-ttu-id="82c3f-112">ブレークポイント</span><span class="sxs-lookup"><span data-stu-id="82c3f-112">Breakpoints</span></span>
<span data-ttu-id="82c3f-113">次の表で、さまざまなサイズ クラスとブレークポイントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-113">This table describes the different size classes and breakpoints.</span></span>

![レスポンシブ デザインのブレークポイント](images/rsp-design/rspd-breakpoints.png)

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="82c3f-115">サイズ クラス</span><span class="sxs-lookup"><span data-stu-id="82c3f-115">Size class</span></span></th>
<th align="left"><span data-ttu-id="82c3f-116">ブレークポイント</span><span class="sxs-lookup"><span data-stu-id="82c3f-116">Breakpoints</span></span></th>
<th align="left"><span data-ttu-id="82c3f-117">画面サイズ (対角線)</span><span class="sxs-lookup"><span data-stu-id="82c3f-117">Screen size (diagonal)</span></span></th>
<th align="left"><span data-ttu-id="82c3f-118">デバイス</span><span class="sxs-lookup"><span data-stu-id="82c3f-118">Devices</span></span></th>
<th align="left"><span data-ttu-id="82c3f-119">ウィンドウ サイズ</span><span class="sxs-lookup"><span data-stu-id="82c3f-119">Window sizes</span></span></th>
</tr>
</thead>
<tbody>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="82c3f-120">小</span><span class="sxs-lookup"><span data-stu-id="82c3f-120">Small</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-121">640 ピクセル以下</span><span class="sxs-lookup"><span data-stu-id="82c3f-121">640px or less</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-122">4&quot; ～ 6&quot;</span><span class="sxs-lookup"><span data-stu-id="82c3f-122">4&quot; to 6&quot;</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-123">電話</span><span class="sxs-lookup"><span data-stu-id="82c3f-123">Phones</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-124">320 x 569、360 x 640、480 x 854</span><span class="sxs-lookup"><span data-stu-id="82c3f-124">320x569, 360x640, 480x854</span></span></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><span data-ttu-id="82c3f-125">中</span><span class="sxs-lookup"><span data-stu-id="82c3f-125">Medium</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-126">641 ピクセル～ 1007 ピクセル</span><span class="sxs-lookup"><span data-stu-id="82c3f-126">641px to 1007px</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-127">7&quot; ～ 12&quot;</span><span class="sxs-lookup"><span data-stu-id="82c3f-127">7&quot; to 12&quot;</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-128">ファブレット、タブレット、テレビ</span><span class="sxs-lookup"><span data-stu-id="82c3f-128">Phablets, tablets, TVs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-129">960 x 540</span><span class="sxs-lookup"><span data-stu-id="82c3f-129">960x540</span></span></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><span data-ttu-id="82c3f-130">大</span><span class="sxs-lookup"><span data-stu-id="82c3f-130">Large</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-131">1008 ピクセル以上</span><span class="sxs-lookup"><span data-stu-id="82c3f-131">1008px or greater</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-132">13&quot; 以上</span><span class="sxs-lookup"><span data-stu-id="82c3f-132">13&quot; and larger</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-133">PC、ノート PC、Surface Hub</span><span class="sxs-lookup"><span data-stu-id="82c3f-133">PCs, laptops, Surface Hubs</span></span></td>
<td style="vertical-align:top;"><span data-ttu-id="82c3f-134">1024 x 640、1366 x 768、1920 x 1080</span><span class="sxs-lookup"><span data-stu-id="82c3f-134">1024x640, 1366x768, 1920x1080</span></span></td>
</tr>
</tbody>
</table>

## <a name="general-recommendations"></a><span data-ttu-id="82c3f-135">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="82c3f-135">General recommendations</span></span>

### <a name="small"></a><span data-ttu-id="82c3f-136">小</span><span class="sxs-lookup"><span data-stu-id="82c3f-136">Small</span></span>
- <span data-ttu-id="82c3f-137">ウィンドウの左右の余白を 12 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-137">Set left and right window margins to 12px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="82c3f-138">手に届きやすいように[アプリ バー](../controls-and-patterns/app-bars.md)をウィンドウの下部にドッキングします。</span><span class="sxs-lookup"><span data-stu-id="82c3f-138">Dock [app bars](../controls-and-patterns/app-bars.md) to the bottom of the window for improved reachability.</span></span>
- <span data-ttu-id="82c3f-139">一度に 1 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-139">Use one column/region at a time.</span></span>
- <span data-ttu-id="82c3f-140">検索を表すアイコンを使います (検索ボックスを表示しない)。</span><span class="sxs-lookup"><span data-stu-id="82c3f-140">Use an icon to represent search (don't show a search box).</span></span>
- <span data-ttu-id="82c3f-141">[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)をオーバーレイ モードにして画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-141">Put the [navigation pane](../controls-and-patterns/navigationview.md) in overlay mode to conserve screen space.</span></span>
- <span data-ttu-id="82c3f-142">[マスター/詳細要素](../controls-and-patterns/master-details.md)を使用している場合は、上下に並べる表示モードを使用して画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-142">If you're using the [master details pattern](../controls-and-patterns/master-details.md), use the stacked presentation mode to save screen space.</span></span>

### <a name="medium"></a><span data-ttu-id="82c3f-143">中</span><span class="sxs-lookup"><span data-stu-id="82c3f-143">Medium</span></span>
- <span data-ttu-id="82c3f-144">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-144">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="82c3f-145">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-145">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span>
- <span data-ttu-id="82c3f-146">最大で 2 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-146">Use up to two columns/regions.</span></span>
- <span data-ttu-id="82c3f-147">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-147">Show the search box.</span></span>
- <span data-ttu-id="82c3f-148">アイコンの幅の狭いストリップが常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を小片モードにします。</span><span class="sxs-lookup"><span data-stu-id="82c3f-148">Put the [navigation pane](../controls-and-patterns/navigationview.md) into sliver mode so a narrow strip of icons always shows.</span></span>
- <span data-ttu-id="82c3f-149">[テレビのエクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)の調整を検討します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-149">Consider further tailoring for [TV experiences](http://go.microsoft.com/fwlink/?LinkId=760736).</span></span>

### <a name="large"></a><span data-ttu-id="82c3f-150">大</span><span class="sxs-lookup"><span data-stu-id="82c3f-150">Large</span></span>
- <span data-ttu-id="82c3f-151">ウィンドウの左右の余白を 24 ピクセルに設定して、アプリ ウィンドウの左右の端の間で視覚的な区切りを作成します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-151">Set left and right window margins to 24px to create a visual separation between the left and right edges of the app window.</span></span>
- <span data-ttu-id="82c3f-152">[アプリ バー](../controls-and-patterns/app-bars.md)などのコマンド要素をアプリ ウィンドウの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-152">Put command elements like [app bars](../controls-and-patterns/app-bars.md) at the top of the app window.</span></span>
- <span data-ttu-id="82c3f-153">最大で 3 つの列/領域を使用します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-153">Use up to three columns/regions.</span></span>
- <span data-ttu-id="82c3f-154">検索ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-154">Show the search box.</span></span>
- <span data-ttu-id="82c3f-155">常に表示されるように[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)を固定モードにします。</span><span class="sxs-lookup"><span data-stu-id="82c3f-155">Put the [navigation pane](../controls-and-patterns/navigationview.md) into docked mode so that it always shows.</span></span>

>[!TIP] 
> <span data-ttu-id="82c3f-156">[**電話用 Continuum**](http://go.microsoft.com/fwlink/p/?LinkID=699431) を利用すると、ユーザーは互換性のある Windows 10 Mobile デバイスをモニター、マウス、およびキーボードに接続して、その電話をノート PC のように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="82c3f-156">With [**Continuum for Phones**](http://go.microsoft.com/fwlink/p/?LinkID=699431), users can connect compatible Windows 10 mobile devices to a monitor, mouse and keyboard to make their phones work like laptops.</span></span> <span data-ttu-id="82c3f-157">特定のブレークポイント向けに設計するときは、この新機能に注意してください。携帯電話が常にそのサイズ クラスで維持されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="82c3f-157">Keep this new capability in mind when designing for specific breakpoints - a mobile phone will not always stay in the size class.</span></span>

## <a name="effective-pixels-and-scale-factor"></a><span data-ttu-id="82c3f-158">有効ピクセルと倍率</span><span class="sxs-lookup"><span data-stu-id="82c3f-158">Effective pixels and scale factor</span></span>

<span data-ttu-id="82c3f-159">UWP アプリは、すべての Windows 10 デバイスでアプリが判読可能であることを保証するために、UI を自動的に拡大縮小します。</span><span class="sxs-lookup"><span data-stu-id="82c3f-159">UWP apps automatically scale your UI to guarantee that your app will be legible on all Windows 10 devices.</span></span> <span data-ttu-id="82c3f-160">Windows では、ディスプレイの DPI (1 インチあたりのドット数) と、デバイスの視聴距離に基づいて各ディスプレイが自動的に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="82c3f-160">Windows automatically scales for each display based on its DPI (dots-per-inch) and the viewing distance of the device.</span></span> <span data-ttu-id="82c3f-161">ユーザーは、**[設定]** > **[ディスプレイ]** > **[拡大縮小とレイアウト]** の設定ページに移動して既定値を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="82c3f-161">Users can override the default value and by going to **Settings** > **Display** > **Scale and layout** settings page.</span></span> 
