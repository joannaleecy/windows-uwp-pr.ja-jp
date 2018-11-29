---
description: 広告ユニットの視認性を向上させる方法について説明します。
title: 広告ユニットの視認性の最適化
ms.date: 05/07/2018
ms.topic: article
keywords: windows 10, uwp, 広告, 宣伝, ガイドライン, 視認性
ms.localizationpriority: medium
ms.openlocfilehash: 87e21f4e98c58f79f397c369891212eccb196c18
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7972662"
---
# <a name="optimize-the-viewability-of-your-ad-units"></a><span data-ttu-id="8fa06-104">広告ユニットの視認性の最適化</span><span class="sxs-lookup"><span data-stu-id="8fa06-104">Optimize the viewability of your ad units</span></span>

<span data-ttu-id="8fa06-105">[[広告パフォーマンス] レポート](../publish/advertising-performance-report.md)には、広告ユニットの視認性のメトリックが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8fa06-105">The [Advertising performance report](../publish/advertising-performance-report.md) includes viewability metrics for your ad units.</span></span> <span data-ttu-id="8fa06-106">広告業界は配信されるインプレッションだけではなく見やすいインプレッションを重視する方向に移行しているため、視認性は重要なメトリックです。</span><span class="sxs-lookup"><span data-stu-id="8fa06-106">Viewability is an important metric because the advertising industry is moving towards valuing viewable impressions rather than just delivered impressions.</span></span> <span data-ttu-id="8fa06-107">広告主は見やすいインプレッションに入札する傾向があります。これは、見やすいインプレッションでは広告がユーザーによって表示される可能性が高いためです。</span><span class="sxs-lookup"><span data-stu-id="8fa06-107">Advertisers tend to bid for viewable impressions because they have an increased chance of their ads being seen by users.</span></span>  

<span data-ttu-id="8fa06-108">IAB の視認性のガイドラインに合わせて、バナー広告のインプレッションは、次の条件を満たしている場合に見やすいとみなされます。</span><span class="sxs-lookup"><span data-stu-id="8fa06-108">In alignment with the IAB viewability guidelines, a banner ad impression is counted as viewable if it meets the following criteria:</span></span>

* <span data-ttu-id="8fa06-109">ピクセル要件: 広告の 50% 以上のピクセルがアプリの表示可能領域にあった。</span><span class="sxs-lookup"><span data-stu-id="8fa06-109">Pixel requirement: Greater than or equal to 50% of the pixels in the advertisement were on the viewable space of the app.</span></span>
* <span data-ttu-id="8fa06-110">時間の要件: ピクセル要件を満たす時間が広告のレンダリング後、連続で 1 秒以上であった。</span><span class="sxs-lookup"><span data-stu-id="8fa06-110">Time requirement: The time the pixel requirement is met was greater than or equal to one continuous second, post ad render.</span></span>

<span data-ttu-id="8fa06-111">ビデオ広告インプレッションは、次の条件を満たしている場合は、見やすいとみなされます。</span><span class="sxs-lookup"><span data-stu-id="8fa06-111">A video ad impression is counted as viewable if it meets the following criteria:</span></span>

* <span data-ttu-id="8fa06-112">ピクセル要件: 広告の 50% 以上のピクセルがアプリの表示可能部分にあった。</span><span class="sxs-lookup"><span data-stu-id="8fa06-112">Pixel requirement: Greater than or equal to 50% of the pixels in the advertisement were on the viewable part of the app.</span></span>
* <span data-ttu-id="8fa06-113">時間の要件: ビデオがピクセル要件を満たし、広告のレンダリング後、連続で 2 秒間再生された。</span><span class="sxs-lookup"><span data-stu-id="8fa06-113">Time requirement: The video met the pixel requirement and played for two continuous seconds post ad render.</span></span>

<span data-ttu-id="8fa06-114">視認性は、次の数式を使用して計算されます。</span><span class="sxs-lookup"><span data-stu-id="8fa06-114">Viewability is calculated using the following formula:</span></span>

**<span data-ttu-id="8fa06-115">視認性 = [表示されたインプレッション数] \* 100 / [広告インプレッションの合計]</span><span class="sxs-lookup"><span data-stu-id="8fa06-115">Viewability = [Viewed impressions] \* 100 / [ Total ad impressions]</span></span>**

## <a name="guidelines-to-improve-ad-unit-viewability"></a><span data-ttu-id="8fa06-116">広告ユニットの視認性を向上させるためのガイドライン</span><span class="sxs-lookup"><span data-stu-id="8fa06-116">Guidelines to improve ad unit viewability</span></span>

<span data-ttu-id="8fa06-117">広告ユニットの見やすいインプレッションを最適化するには、次のガイドラインに従います。</span><span class="sxs-lookup"><span data-stu-id="8fa06-117">To optimize the viewable impressions for your ad units, follow these guidelines.</span></span>

1. <span data-ttu-id="8fa06-118">**パフォーマンス測定**&nbsp;&nbsp;[[広告パフォーマンス] レポート](../publish/advertising-performance-report.md)を使用して各広告ユニットの表示可能なメトリックを確認します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-118">**Measure performance**&nbsp;&nbsp;Use the [Advertising performance report](../publish/advertising-performance-report.md) to review the viewability metrics of each of your ad units.</span></span>
2.  <span data-ttu-id="8fa06-119">**広告コントロールを適切に配置**&nbsp;&nbsp;一般に、広告の最も見やすい位置は 1 面トップです (つまり、ユーザーがスクロールしないで見ることができるページの可視部分の下部です)。</span><span class="sxs-lookup"><span data-stu-id="8fa06-119">**Position your ad control appropriately**&nbsp;&nbsp;In general, the most viewable position for an ad is just above the fold (that is, at the bottom of the visible portion of the page that users can see without having to scroll).</span></span> <span data-ttu-id="8fa06-120">ページの上部に表示される広告は、あまり見やすくありません。</span><span class="sxs-lookup"><span data-stu-id="8fa06-120">Ads that are displayed at top of the page are not as viewable.</span></span> <span data-ttu-id="8fa06-121">ページの各要素を検証しアプリで表示可能領域を最適化できる方法を確認することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="8fa06-121">Consider inspecting each element of your page to see how you can optimize the viewable space in your app.</span></span> <span data-ttu-id="8fa06-122">アプリのバック グラウンドに広告コントロールが配置されていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-122">Make sure your ad controls aren't placed in the app background.</span></span>
3.  <span data-ttu-id="8fa06-123">**ページの長さの管理**&nbsp;&nbsp;短いページ コンテンツは、より見やすくなります。</span><span class="sxs-lookup"><span data-stu-id="8fa06-123">**Manage page length**&nbsp;&nbsp;Shorter page content results in higher viewability.</span></span> <span data-ttu-id="8fa06-124">アプリのページを長くする必要がある場合は、無限スクロールを実装してください。</span><span class="sxs-lookup"><span data-stu-id="8fa06-124">Implement infinite scrolling if your app pages need to be longer.</span></span>
4.  <span data-ttu-id="8fa06-125">**広告の位置の修正**&nbsp;&nbsp;ユーザーがスクロールしても広告が固定位置にとどまるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="8fa06-125">**Fix the ad position**&nbsp;&nbsp;Make sure your ads stay at a fixed position even as the user scrolls.</span></span> <span data-ttu-id="8fa06-126">これにより、表示回数が増え、ビューアビリティ レートが向上します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-126">This will help you get a higher view time and increase your viewability rate.</span></span>
5.  <span data-ttu-id="8fa06-127">**不透明度の設定**&nbsp;&nbsp;広告コントロールを含むコンテナーの不透明度が 100% に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-127">**Set opacity**&nbsp;&nbsp;Ensure the opacity of the container that contains the ad control is 100%.</span></span>
6.  <span data-ttu-id="8fa06-128">**遅延読み込みの実装**&nbsp;&nbsp;ユーザーが広告コントロールを含むビュー内までスクロールするまで広告を読み込まないでください。</span><span class="sxs-lookup"><span data-stu-id="8fa06-128">**Implement lazy loading**&nbsp;&nbsp;Don't load your ads until the users scroll into the view that contains the ad control.</span></span> <span data-ttu-id="8fa06-129">これにより、ユーザーが表示する広告の表示時間が長くなります。</span><span class="sxs-lookup"><span data-stu-id="8fa06-129">This will ensure the ad displays longer for the user to view.</span></span>
7.  <span data-ttu-id="8fa06-130">**さまざまな広告サイズのテスト**&nbsp;&nbsp;いくつかの広告サイズを選択し、[[広告パフォーマンス] レポート](../publish/advertising-performance-report.md)を使用して、それぞれの広告の視認性を測定します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-130">**Experiment with various ad sizes**&nbsp;&nbsp;Select a few ad sizes and measure viewability for each of them using the [Advertising performance report](../publish/advertising-performance-report.md).</span></span> <span data-ttu-id="8fa06-131">最適に機能する広告サイズを選択します。</span><span class="sxs-lookup"><span data-stu-id="8fa06-131">Pick the one that works best for you.</span></span>
8.  <span data-ttu-id="8fa06-132">**アプリの設計の再確認**&nbsp;&nbsp;アプリ ページ設計を強化し、ページの読み込み時間を短縮してください。</span><span class="sxs-lookup"><span data-stu-id="8fa06-132">**Revisit app design**&nbsp;&nbsp;Make improvements to your app page design to reduce page load time.</span></span> <span data-ttu-id="8fa06-133">ユーザーは、迅速に読み込まれるページにより長くとどまる傾向があります。</span><span class="sxs-lookup"><span data-stu-id="8fa06-133">Users tend to stay longer on pages that load quicker.</span></span>
