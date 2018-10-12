---
author: QuinnRadich
title: 分割ビュー
ms.assetid: E9E4537F-1160-4183-9A83-26602FCFDC9A
description: 分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。
label: Split view
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: tpaine
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: cde4b5d95a0c978faa647fcc108d74874ff52c40
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4536366"
---
# <a name="split-view-control"></a><span data-ttu-id="9a7e1-104">分割ビュー コントロール</span><span class="sxs-lookup"><span data-stu-id="9a7e1-104">Split view control</span></span>

<span data-ttu-id="9a7e1-105">分割ビュー コントロールには、展開/折りたたみ可能なウィンドウとコンテンツ領域があります。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-105">A split view control has an expandable/collapsible pane and a content area.</span></span>

> <span data-ttu-id="9a7e1-106">**重要な API**: [SplitView クラス](https://msdn.microsoft.com/library/windows/apps/dn864360)</span><span class="sxs-lookup"><span data-stu-id="9a7e1-106">**Important APIs**: [SplitView class](https://msdn.microsoft.com/library/windows/apps/dn864360)</span></span>

<span data-ttu-id="9a7e1-107">SplitView を使ってハブを表示する Microsoft Edge アプリの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-107">Here is an example of the Microsoft Edge app using SplitView to show its Hub.</span></span>

![Microsoft Edge の分割ビューの例](images/split_view_Edge.png)


 <span data-ttu-id="9a7e1-109">分割ビューのコンテンツ領域は常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-109">A split view's content area is always visible.</span></span> <span data-ttu-id="9a7e1-110">ウィンドウは展開/折りたたみを行うことも、開いた状態のままにすることもでき、アプリ ウィンドウの右側または左側から表示できます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-110">The pane can expand and collapse or remain in an open state, and can present itself from either the left side or right side of an app window.</span></span> <span data-ttu-id="9a7e1-111">このウィンドウには 4 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-111">The pane has four modes:</span></span>

-   **<span data-ttu-id="9a7e1-112">オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="9a7e1-112">Overlay</span></span>**

    <span data-ttu-id="9a7e1-113">ウィンドウは開くまで表示されません。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-113">The pane is hidden until opened.</span></span> <span data-ttu-id="9a7e1-114">開くと、ウィンドウはコンテンツ領域をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-114">When open, the pane overlays the content area.</span></span>

-   **<span data-ttu-id="9a7e1-115">インライン</span><span class="sxs-lookup"><span data-stu-id="9a7e1-115">Inline</span></span>**

    <span data-ttu-id="9a7e1-116">ウィンドウは常に表示され、コンテンツ領域をオーバーレイしません。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-116">The pane is always visible and doesn't overlay the content area.</span></span> <span data-ttu-id="9a7e1-117">画面領域はウィンドウとコンテンツ領域に分割されます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-117">The pane and content areas divide the available screen real estate.</span></span>

-   **<span data-ttu-id="9a7e1-118">CompactOverlay</span><span class="sxs-lookup"><span data-stu-id="9a7e1-118">CompactOverlay</span></span>**

    <span data-ttu-id="9a7e1-119">このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-119">A narrow portion of the pane is always visible in this mode, which is just wide enough to show icons.</span></span> <span data-ttu-id="9a7e1-120">閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-120">The default closed pane width is 48px, which can be modified with `CompactPaneLength`.</span></span> <span data-ttu-id="9a7e1-121">ウィンドウを開くと、ウィンドウはコンテンツ領域をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-121">If the pane is opened, it will overlay the content area.</span></span>

-   **<span data-ttu-id="9a7e1-122">CompactInline</span><span class="sxs-lookup"><span data-stu-id="9a7e1-122">CompactInline</span></span>**

    <span data-ttu-id="9a7e1-123">このモードでは、ウィンドウの狭い部分が常にアイコンを表示できるだけの大きさで表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-123">A narrow portion of the pane is always visible in this mode, which is just wide enough to show icons.</span></span> <span data-ttu-id="9a7e1-124">閉じたウィンドウの既定の幅は 48 ピクセルで、この値は `CompactPaneLength` で変更できます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-124">The default closed pane width is 48px, which can be modified with `CompactPaneLength`.</span></span> <span data-ttu-id="9a7e1-125">ウィンドウを開くと、コンテンツを押しのけるようにして、コンテンツの利用可能な領域が小さくなります。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-125">If the pane is opened, it will reduce the space available for content, pushing the content out of its way.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="9a7e1-126">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="9a7e1-126">Is this the right control?</span></span>

<span data-ttu-id="9a7e1-127">分割ビュー コントロールを使って、ユーザーが補足的なウィンドウを開いたり閉じたりできる "引き出し" エクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-127">The split view control can be used to create any "drawer" experience where users can open and close the supplemental pane.</span></span> <span data-ttu-id="9a7e1-128">たとえば、SplitView を使用して[マスター/詳細](master-details.md)パターンを構築できます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-128">For example, you can use SplitView to build the [master/details](master-details.md) pattern.</span></span>

<span data-ttu-id="9a7e1-129">展開/折りたたみボタンとナビゲーション項目のリストを含むナビゲーション メニューを構築する場合は、[NavigationView](navigationview.md) コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-129">If you'd like to build a navigation menu with an expand/collapse button and a list of navigation items, then use the [NavigationView](navigationview.md) control.</span></span>

## <a name="examples"></a><span data-ttu-id="9a7e1-130">例</span><span class="sxs-lookup"><span data-stu-id="9a7e1-130">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="9a7e1-131">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="9a7e1-131">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="9a7e1-132"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SplitView">アプリを開き、SplitView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-132">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/SplitView">open the app and see the SplitView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="9a7e1-133">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="9a7e1-133">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="9a7e1-134">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="9a7e1-134">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-split-view"></a><span data-ttu-id="9a7e1-135">分割ビューの作成</span><span class="sxs-lookup"><span data-stu-id="9a7e1-135">Create a split view</span></span>

<span data-ttu-id="9a7e1-136">以下は、Content の横にインラインでオープン状態の Pane を表示する SplitView コントロールのコードです。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-136">Here's a SplitView control with an open Pane appearing inline next to the Content.</span></span>
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

## <a name="get-the-sample-code"></a><span data-ttu-id="9a7e1-137">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="9a7e1-137">Get the sample code</span></span>

- <span data-ttu-id="9a7e1-138">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="9a7e1-138">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9a7e1-139">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9a7e1-139">Related topics</span></span>
- [<span data-ttu-id="9a7e1-140">ナビゲーション ウィンドウ パターン</span><span class="sxs-lookup"><span data-stu-id="9a7e1-140">Nav pane pattern</span></span>](navigationview.md)
- [<span data-ttu-id="9a7e1-141">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="9a7e1-141">List view</span></span>](lists.md)
- [<span data-ttu-id="9a7e1-142">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="9a7e1-142">Master/details</span></span>](master-details.md)