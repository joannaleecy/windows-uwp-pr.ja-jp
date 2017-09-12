---
author: Jwmsft
Description: "パンとスクロールを行うと、画面の境界外のコンテンツを拡張表示することができます。"
title: "スクロール ビューアー コントロール"
ms.assetid: 1BFF0E81-BF9C-43F7-95F6-EFC6BDD5EC31
label: Scrollbars
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
pm-contact: Abarlow, pagildea
design-contact: ksulliv
dev-contact: regisb
doc-status: Published
ms.openlocfilehash: b60842d25c54c15c7c478e1e5183ecd3317bb82c
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="scroll-viewer-controls"></a><span data-ttu-id="b9cba-104">スクロール ビューアー コントロール</span><span class="sxs-lookup"><span data-stu-id="b9cba-104">Scroll viewer controls</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="b9cba-105">1 つの領域には収まらない UI コンテンツがある場合は、スクロール ビューアー コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-105">When there is more UI content to show than you can fit in an area, use the scroll viewer control.</span></span>

> <span data-ttu-id="b9cba-106">**重要な API**: [ScrollViewer クラス](https://msdn.microsoft.com/library/windows/apps/br209527)、[ScrollBar クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="b9cba-106">**Important APIs**: [ScrollViewer class](https://msdn.microsoft.com/library/windows/apps/br209527), [ScrollBar class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span></span>

<span data-ttu-id="b9cba-107">スクロール ビューアーにより、ビューポート (表示可能な領域) の境界外のコンテンツを拡張表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b9cba-107">Scroll viewers enable content to extend beyond the bounds of the viewport (visable area).</span></span> <span data-ttu-id="b9cba-108">ユーザーはこのコンテンツを表示するために、タッチ、マウス ホイール、キーボード、ゲームパッドでスクロール ビューアーのサーフェスを操作します。またはマウスやペン カーソルでスクロール ビューアーのスクロールバーを操作します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-108">Users reach this content by manipulating the scroll viewer surface through touch, mousewheel, keyboard, or a gamepad, or by using the mouse or pen cursor to interact with the scroll viewer's scrollbar.</span></span> <span data-ttu-id="b9cba-109">以下の画像に、スクロール ビューアー コントロールの例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-109">This image shows several examples of scroll viewer controls.</span></span>

![標準的なスクロールバー コントロールを示すスクリーンショット](images/ScrollBar_Standard.jpg)

<span data-ttu-id="b9cba-111">状況によって、スクロール ビューアーのスクロールバーは 2 つの視覚化を使用します (以下の画像参照)。左がパン インジケーター、右が従来のスクロールバーです。</span><span class="sxs-lookup"><span data-stu-id="b9cba-111">Depending on the situation, the scroll viewer's scrollbar uses two different visualizations, shown in the following illustration: the panning indicator (left) and the traditional scrollbar (right).</span></span>

![標準的なスクロールバーとパン インジケーター コントロールの外観のサンプル](images/SCROLLBAR.png)

<span data-ttu-id="b9cba-113">スクロール ビューアーはユーザーの入力方式を理解して、どの視覚化を表示すればよいか判断します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-113">The scroll viewer is conscious of the user’s input method and uses it to determine which visualization to display.</span></span>

* <span data-ttu-id="b9cba-114">たとえば、スクロールバーが直接操作されずに領域がスクロールされると、パン インジケーターが表示されて現在のスクロール位置が示されます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-114">When the region is scrolled without manipulating the scrollbar directly, for example, by touch, the panning indicator appears, displaying the current scroll position.</span></span>
* <span data-ttu-id="b9cba-115">マウスかペン カーソルがパン インジケーターの上に移動すると、パン インジケーターが従来のスクロール バーに変形します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-115">When the mouse or pen cursor moves over the panning indicator, it morphs into the traditional scrollbar.</span></span>  <span data-ttu-id="b9cba-116">スクロールバーのつまみをドラッグすると、スクロール領域が操作されます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-116">Dragging the scrollbar thumb manipulates the scrolling region.</span></span>

<!--
<div class="microsoft-internal-note">
See complete redlines in [UNI]http://uni/DesignDepot.FrontEnd/#/ProductNav/3378/0/dv/?t=Windows|Controls|ScrollControls&f=RS2
</div>
-->

![スクロールバーの動作](images/conscious-scroll.gif)

> [!NOTE]
> <span data-ttu-id="b9cba-118">スクロールバーは、表示されると ScrollViewer 内のコンテンツの上部に 16 ピクセルでオーバーレイされます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-118">When the scrollbar is visible it is overlaid as 16px on top of the content inside your ScrollViewer.</span></span> <span data-ttu-id="b9cba-119">UX を適切に設計するには、このオーバーレイによってインタラクティブなコンテンツが隠れないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b9cba-119">In order to ensure good UX design you will want to ensure that no interactive content is obscured by this overlay.</span></span> <span data-ttu-id="b9cba-120">また、UX を重複させないようにするには、スクロールバーを考慮してビューポートの端のパディングを 16 ピクセル残すようにしてください。</span><span class="sxs-lookup"><span data-stu-id="b9cba-120">Additionally if you would prefer not to have UX overlap, leave 16px of padding on the edge of the viewport to allow for the scrollbar.</span></span>


## <a name="create-a-scroll-viewer"></a><span data-ttu-id="b9cba-121">スクロール ビューアーを作成する</span><span class="sxs-lookup"><span data-stu-id="b9cba-121">Create a scroll viewer</span></span>
<span data-ttu-id="b9cba-122">ページに垂直スクロールを追加するには、スクロール ビューアーでページのコンテンツをラップします。</span><span class="sxs-lookup"><span data-stu-id="b9cba-122">To add vertical scrolling to your page, wrap the page content in a scroll viewer.</span></span>

```xaml
<Page
    x:Class="App1.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App1">

    <ScrollViewer>
        <StackPanel>
            <TextBlock Text="My Page Title" Style="{StaticResource TitleTextBlockStyle}"/>
            <!-- more page content -->
        </StackPanel>
    </ScrollViewer>
</Page>
```

<span data-ttu-id="b9cba-123">次の XAML は、スクロール ビューアーに画像を配置し、ズームを有効にする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b9cba-123">This XAML shows how to place an image in a scroll viewer and enable zooming.</span></span>

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10"
              HorizontalScrollMode="Enabled" HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

## <a name="scrollviewer-in-a-control-template"></a><span data-ttu-id="b9cba-124">コントロール テンプレートにおける ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="b9cba-124">ScrollViewer in a control template</span></span>

<span data-ttu-id="b9cba-125">ScrollViewer コントロールが他のコントロールの複合パートとして存在するのは一般的です。</span><span class="sxs-lookup"><span data-stu-id="b9cba-125">It's typical for a ScrollViewer control to exist as a composite part of other controls.</span></span> <span data-ttu-id="b9cba-126">ScrollViewer パーツは、サポートのための [ScrollContentPresenter](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollcontentpresenter.aspx) クラスと共に、ホスト コントロールのレイアウト スペースが展開されたコンテンツのサイズより小さく制限されている場合にのみ、スクロールバーと、ビューポートを表示します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-126">A ScrollViewer part, along with the [ScrollContentPresenter](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollcontentpresenter.aspx) class for support, will display a viewport along with scrollbars only when the host control's layout space is being constrained smaller than the expanded content size.</span></span> <span data-ttu-id="b9cba-127">多くの場合、リストがこれに該当するため、[ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) と [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) テンプレートは常に ScrollViewer を含めます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-127">This is often the case for lists, so [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) and [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) templates always include a ScrollViewer.</span></span> <span data-ttu-id="b9cba-128">[TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) と [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) もまたテンプレートに ScrollViewer を含みます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-128">[TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) and [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) also include a ScrollViewer in their templates.</span></span>

<span data-ttu-id="b9cba-129">**ScrollViewer** パーツがコントロール内に存在するとき、ホスト コントロールには通常、特定の入力イベントとコンテンツをスクロールできるようになる操作に対するイベント処理が組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="b9cba-129">When a **ScrollViewer** part exists in a control, the host control often has built-in event handling for certain input events and manipulations that enable the content to scroll.</span></span> <span data-ttu-id="b9cba-130">たとえば、GridView がスワイプ ジェスチャを解釈すると、これにより、コンテンツは水平方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="b9cba-130">For example, a GridView interprets a swipe gesture and this causes the content to scroll horizontally.</span></span> <span data-ttu-id="b9cba-131">ホスト コントロールが受け取る入力イベントと直接操作は、コントロールで処理されると見なされ、[PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) などのより低レベルのイベントは発生せず、どの親コンテナーにもバブル ルーティングされません。</span><span class="sxs-lookup"><span data-stu-id="b9cba-131">The input events and raw manipulations that the host control receives are considered handled by the control, and lower-level events such as [PointerPressed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.pointerpressed.aspx) won't be raised and won't bubble to any parent containers either.</span></span> <span data-ttu-id="b9cba-132">コントロール クラスとイベントの **On*** 仮想メソッドをオーバーライドするか、コントロールを再テンプレート化することで、組み込みのコントロール処理の一部を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-132">You can change some of the built-in control handling by overriding a control class and the **On*** virtual methods for events, or by retemplating the control.</span></span> <span data-ttu-id="b9cba-133">ただし、いずれの場合も、元の既定の動作を再現するのは簡単ではありません。この動作では、通常、コントロールはイベントやユーザーの入力動作と入力ジェスチャに予期したとおりに対応します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-133">But in either case it's not trivial to reproduce the original default behavior, which is typically there so that the control reacts in expected ways to events and to a user's input actions and gestures.</span></span> <span data-ttu-id="b9cba-134">そのため、入力イベントの発生が本当に必要かどうかを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b9cba-134">So you should consider whether you really need that input event to fire.</span></span> <span data-ttu-id="b9cba-135">コントロールで処理されない他の入力イベントや入力ジェスチャがあるかどうかを調査して、アプリやコントロール操作の設計では、それらを使う場合があります。</span><span class="sxs-lookup"><span data-stu-id="b9cba-135">You might want to investigate whether there are other input events or gestures that are not being handled by the control, and use those in your app or control interaction design.</span></span>

<span data-ttu-id="b9cba-136">ScrollViewer を含むコントロールが ScrollViewer パーツ内の動作やプロパティの一部に影響を与えることができるように、ScrollViewer ではスタイルで設定でき、テンプレートのバインドで使用できる多数の XAML 添付プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-136">To make it possible for controls that include a ScrollViewer to influence some of the behavior and properties that are from within the ScrollViewer part, ScrollViewer defines a number of XAML attached properties that can be set in styles and used in template bindings.</span></span> <span data-ttu-id="b9cba-137">添付プロパティについて詳しくは、「[添付プロパティの概要](../xaml-platform/attached-properties-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9cba-137">For more info about attached properties, see [Attached properties overview](../xaml-platform/attached-properties-overview.md).</span></span>

**<span data-ttu-id="b9cba-138">ScrollViewer の XAML 添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="b9cba-138">ScrollViewer XAML attached properties</span></span>**

<span data-ttu-id="b9cba-139">ScrollViewer では、次の XAML 添付プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-139">ScrollViewer defines the following XAML attached properties:</span></span>

- [<span data-ttu-id="b9cba-140">ScrollViewer.BringIntoViewOnFocusChange</span><span class="sxs-lookup"><span data-stu-id="b9cba-140">ScrollViewer.BringIntoViewOnFocusChange</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.bringintoviewonfocuschange.aspx)
- [<span data-ttu-id="b9cba-141">ScrollViewer.HorizontalScrollBarVisibility</span><span class="sxs-lookup"><span data-stu-id="b9cba-141">ScrollViewer.HorizontalScrollBarVisibility</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx)
- [<span data-ttu-id="b9cba-142">ScrollViewer.HorizontalScrollMode</span><span class="sxs-lookup"><span data-stu-id="b9cba-142">ScrollViewer.HorizontalScrollMode</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx)
- [<span data-ttu-id="b9cba-143">ScrollViewer.IsDeferredScrollingEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-143">ScrollViewer.IsDeferredScrollingEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isdeferredscrollingenabled.aspx)
- [<span data-ttu-id="b9cba-144">ScrollViewer.IsHorizontalRailEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-144">ScrollViewer.IsHorizontalRailEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.ishorizontalrailenabled.aspx)
- [<span data-ttu-id="b9cba-145">ScrollViewer.IsHorizontalScrollChainingEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-145">ScrollViewer.IsHorizontalScrollChainingEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.ishorizontalscrollchainingenabled.aspx)
- [<span data-ttu-id="b9cba-146">ScrollViewer.IsScrollInertiaEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-146">ScrollViewer.IsScrollInertiaEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isscrollinertiaenabled.aspx)
- [<span data-ttu-id="b9cba-147">ScrollViewer.IsVerticalRailEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-147">ScrollViewer.IsVerticalRailEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isverticalrailenabled.aspx)
- [<span data-ttu-id="b9cba-148">ScrollViewer.IsVerticalScrollChainingEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-148">ScrollViewer.IsVerticalScrollChainingEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.isverticalscrollchainingenabled.aspx)
- [<span data-ttu-id="b9cba-149">ScrollViewer.IsZoomChainingEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-149">ScrollViewer.IsZoomChainingEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.iszoominertiaenabled.aspx)
- [<span data-ttu-id="b9cba-150">ScrollViewer.IsZoomInertiaEnabled</span><span class="sxs-lookup"><span data-stu-id="b9cba-150">ScrollViewer.IsZoomInertiaEnabled</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.iszoominertiaenabled.aspx)
- [<span data-ttu-id="b9cba-151">ScrollViewer.VerticalScrollBarVisibility</span><span class="sxs-lookup"><span data-stu-id="b9cba-151">ScrollViewer.VerticalScrollBarVisibility</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibilityproperty.aspx)
- [<span data-ttu-id="b9cba-152">ScrollViewer.VerticalScrollMode</span><span class="sxs-lookup"><span data-stu-id="b9cba-152">ScrollViewer.VerticalScrollMode</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx)
- [<span data-ttu-id="b9cba-153">ScrollViewer.ZoomMode</span><span class="sxs-lookup"><span data-stu-id="b9cba-153">ScrollViewer.ZoomMode</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.zoommode.aspx)

<span data-ttu-id="b9cba-154">これらの XAML 添付プロパティは、ListView または GridView で既定のテンプレートに ScrollViewer が存在しており、テンプレート パーツにアクセスすることなく、コントロールのスクロール動作に影響を与えられるようにするときなど、ScrollViewer が暗黙的である場合を想定したものです。</span><span class="sxs-lookup"><span data-stu-id="b9cba-154">These XAML attached properties are intended for cases where the ScrollViewer is implicit, such as when the ScrollViewer exists in the default template for a ListView or GridView, and you want to be able to influence the scrolling behavior of the control without accessing template parts.</span></span>

<span data-ttu-id="b9cba-155">たとえば、ListView の組み込みのスクロール ビューアーで垂直スクロールバーが常に表示されるようにする方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-155">For example, here's how to make the vertical scrollbars always visible for a ListView's built in scroll viewer.</span></span>

```xaml
<ListView ScrollViewer.VerticalScrollBarVisibility="Visible"/>
```

<span data-ttu-id="b9cba-156">ScrollViewer が XAML で明示的である場合、コード例に示すように、添付プロパティ構文を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b9cba-156">For cases where a ScrollViewer is explicit in your XAML, as is shown in the example code, you don't need to use attached property syntax.</span></span> <span data-ttu-id="b9cba-157">属性構文 (たとえば `<ScrollViewer VerticalScrollBarVisibility="Visible"/>`) を使うだけです。</span><span class="sxs-lookup"><span data-stu-id="b9cba-157">Just use attribute syntax, for example `<ScrollViewer VerticalScrollBarVisibility="Visible"/>`.</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="b9cba-158">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="b9cba-158">Do's and don'ts</span></span>

-   <span data-ttu-id="b9cba-159">できる限り、水平方向ではなく垂直方向のスクロールを設計してください。</span><span class="sxs-lookup"><span data-stu-id="b9cba-159">Whenever possible, design for vertical scrolling rather than horizontal.</span></span>
-   <span data-ttu-id="b9cba-160">コンテンツ領域が 1 つのビューポート境界 (垂直方向または水平方向) を超えている場合は、単一軸のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="b9cba-160">Use one-axis panning for content regions that extend beyond one viewport boundary (vertical or horizontal).</span></span> <span data-ttu-id="b9cba-161">コンテンツ領域が両方のビューポート境界 (垂直方向と水平方向) を超えている場合は、2 軸のパンを使います。</span><span class="sxs-lookup"><span data-stu-id="b9cba-161">Use two-axis panning for content regions that extend beyond both viewport boundaries (vertical and horizontal).</span></span>
-   <span data-ttu-id="b9cba-162">リスト ビュー、グリッド ビュー、コンボ ボックス、リスト ボックス、テキスト入力ボックス、およびハブ コントロールの組み込みのスクロール機能を使います。</span><span class="sxs-lookup"><span data-stu-id="b9cba-162">Use the built-in scroll functionality in the list view, grid view, combo box, list box, text input box, and hub controls.</span></span> <span data-ttu-id="b9cba-163">こうしたコントロールでは、同時に表示する項目が多すぎる場合に、ユーザーが項目のリストを水平方向、垂直方向のいずれかにスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="b9cba-163">With those controls, if there are too many items to show all at once, the user is able to scroll either horizontally or vertically over the list of items.</span></span>
-   <span data-ttu-id="b9cba-164">ユーザーがより大きな領域の周囲で両方向にパンすること、そしておそらくズームできるようにする場合、たとえばユーザーが (画面に適合するサイズに設定されたイメージではなく) フル サイズのイメージをパンおよびズームできるようにする場合には、スクロール ビューアー内にイメージを配置します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-164">If you want the user to pan in both directions around a larger area, and possibly to zoom, too, for example, if you want to allow the user to pan and zoom over a full-sized image (rather than an image sized to fit the screen) then place the image inside a scroll viewer.</span></span>
-   <span data-ttu-id="b9cba-165">ユーザーが長いテキスト パスをスクロールする場合、垂直方向にのみスクロールするようにスクロール ビューアーを構成します。</span><span class="sxs-lookup"><span data-stu-id="b9cba-165">If the user will scroll through a long passage of text, configure the scroll viewer to scroll vertically only.</span></span>
-   <span data-ttu-id="b9cba-166">1 つのオブジェクトのみを含める場合にスクロール ビューアーを使います。</span><span class="sxs-lookup"><span data-stu-id="b9cba-166">Use a scroll viewer to contain one object only.</span></span> <span data-ttu-id="b9cba-167">1 つのオブジェクトをレイアウト パネルとし、その任意の数のオブジェクトを含めることができる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="b9cba-167">Note that the one object can be a layout panel, in turn containing any number of objects of its own.</span></span>
-   <span data-ttu-id="b9cba-168">ピボットのスクロール ロジックが競合するのを避けるため、スクロール ビューアー内には[ピボット](tabs-pivot.md) コントロールを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="b9cba-168">Don't place a [Pivot](tabs-pivot.md) control inside a scroll viewer to avoid conflicts with pivot's scrolling logic.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b9cba-169">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b9cba-169">Related topics</span></span>

**<span data-ttu-id="b9cba-170">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="b9cba-170">For developers (XAML)</span></span>**

* [<span data-ttu-id="b9cba-171">ScrollViewer クラス</span><span class="sxs-lookup"><span data-stu-id="b9cba-171">ScrollViewer class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209527)
