---
author: Jwmsft
title: "分割ビュー"
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: "分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。"
label: Split view
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: tpaine
doc-status: Published
ms.openlocfilehash: 126fab3db9a0728626289788757f576648a43856
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="split-view-control"></a><span data-ttu-id="76884-104">分割ビュー コントロール</span><span class="sxs-lookup"><span data-stu-id="76884-104">Split view control</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="76884-105">分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。</span><span class="sxs-lookup"><span data-stu-id="76884-105">A split view control has an expandable/collapsible pane and a content area.</span></span>

> <span data-ttu-id="76884-106">**重要な API**: [SplitView クラス](https://msdn.microsoft.com/library/windows/apps/dn864360)</span><span class="sxs-lookup"><span data-stu-id="76884-106">**Important APIs**: [SplitView class](https://msdn.microsoft.com/library/windows/apps/dn864360)</span></span>

<span data-ttu-id="76884-107">SplitView を使ってハブを表示する Microsoft Edge アプリの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="76884-107">Here is an example of the Microsoft Edge app using SplitView to show its Hub.</span></span>

![Microsoft Edge の分割ビューの例](images/split_view_Edge.png)


 <span data-ttu-id="76884-109">分割ビューのコンテンツ領域は常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="76884-109">A split view's content area is always visible.</span></span> <span data-ttu-id="76884-110">ウィンドウは展開/折りたたみを行うことも、開いた状態のままにすることもでき、アプリ ウィンドウの右側または左側から表示できます。</span><span class="sxs-lookup"><span data-stu-id="76884-110">The pane can expand and collapse or remain in an open state, and can present itself from either the left side or right side of an app window.</span></span> <span data-ttu-id="76884-111">このウィンドウには 4 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="76884-111">The pane has four modes:</span></span>

-   **<span data-ttu-id="76884-112">オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="76884-112">Overlay</span></span>**

    <span data-ttu-id="76884-113">ウィンドウは開くまで表示されません。</span><span class="sxs-lookup"><span data-stu-id="76884-113">The pane is hidden until opened.</span></span> <span data-ttu-id="76884-114">開くと、ウィンドウはコンテンツ領域をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="76884-114">When open, the pane overlays the content area.</span></span>

-   **<span data-ttu-id="76884-115">インライン</span><span class="sxs-lookup"><span data-stu-id="76884-115">Inline</span></span>**

    <span data-ttu-id="76884-116">ウィンドウは常に表示され、コンテンツ領域をオーバーレイしません。</span><span class="sxs-lookup"><span data-stu-id="76884-116">The pane is always visible and doesn't overlay the content area.</span></span> <span data-ttu-id="76884-117">画面領域はウィンドウとコンテンツ領域に分割されます。</span><span class="sxs-lookup"><span data-stu-id="76884-117">The pane and content areas divide the available screen real estate.</span></span>

-   **<span data-ttu-id="76884-118">CompactOverlay</span><span class="sxs-lookup"><span data-stu-id="76884-118">CompactOverlay</span></span>**

    <span data-ttu-id="76884-119">このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="76884-119">A narrow portion of the pane is always visible in this mode, which is just wide enough to show icons.</span></span> <span data-ttu-id="76884-120">閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。</span><span class="sxs-lookup"><span data-stu-id="76884-120">The default closed pane width is 48px, which can be modified with `CompactPaneLength`.</span></span> <span data-ttu-id="76884-121">ウィンドウを開くと、ウィンドウはコンテンツ領域をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="76884-121">If the pane is opened, it will overlay the content area.</span></span>

-   **<span data-ttu-id="76884-122">CompactInline</span><span class="sxs-lookup"><span data-stu-id="76884-122">CompactInline</span></span>**

    <span data-ttu-id="76884-123">このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="76884-123">A narrow portion of the pane is always visible in this mode, which is just wide enough to show icons.</span></span> <span data-ttu-id="76884-124">閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。</span><span class="sxs-lookup"><span data-stu-id="76884-124">The default closed pane width is 48px, which can be modified with `CompactPaneLength`.</span></span> <span data-ttu-id="76884-125">ウィンドウを開くと、コンテンツを押しのけるようにして、コンテンツの利用可能な領域が小さくなります。</span><span class="sxs-lookup"><span data-stu-id="76884-125">If the pane is opened, it will reduce the space available for content, pushing the content out of its way.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="76884-126">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="76884-126">Is this the right control?</span></span>

<span data-ttu-id="76884-127">分割ビュー コントロールは、[ナビゲーション ウィンドウ](navigationview.md)の作成に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="76884-127">The split view control can be used to make a [navigation pane](navigationview.md).</span></span> <span data-ttu-id="76884-128">このパターンを構築するには、展開/折りたたみボタン ("ハンバーガー" ボタン) とナビゲーション項目を表すリスト ビューを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76884-128">To build this pattern, add an expand/collapse button (the "hamburger" button) and a list view representing the nav items.</span></span>

<span data-ttu-id="76884-129">分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="76884-129">The split view control can also be used to create any "drawer" experience where users can open and close the supplemental pane.</span></span>

## <a name="create-a-split-view"></a><span data-ttu-id="76884-130">分割ビューの作成</span><span class="sxs-lookup"><span data-stu-id="76884-130">Create a split view</span></span>

<span data-ttu-id="76884-131">以下は、Content の横にインラインでオープン状態の Pane を表示する SplitView コントロールのコードです。</span><span class="sxs-lookup"><span data-stu-id="76884-131">Here's a SplitView control with an open Pane appearing inline next to the Content.</span></span>
```xaml
<SplitView IsPaneOpen="True"
           DisplayMode="Inline"
           OpenPaneLength="296">
    <SplitView.Pane>
        <TextBlock Text="Pane"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </SplitView.Pane>

    <Grid>
        <TextBlock Text="Content"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </Grid>
</SplitView>
```



## <a name="related-topics"></a><span data-ttu-id="76884-132">関連トピック</span><span class="sxs-lookup"><span data-stu-id="76884-132">Related topics</span></span>
* [<span data-ttu-id="76884-133">ナビゲーション ウィンドウ パターン</span><span class="sxs-lookup"><span data-stu-id="76884-133">Nav pane pattern</span></span>](navigationview.md)
* [<span data-ttu-id="76884-134">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="76884-134">List view</span></span>](lists.md)
 

 
