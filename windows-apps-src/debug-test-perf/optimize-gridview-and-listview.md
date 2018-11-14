---
author: jwmsft
ms.assetid: 26DF15E8-2C05-4174-A714-7DF2E8273D32
title: ListView と GridView の UI の最適化
description: ListView と GridView のパフォーマンスと起動時間を、UI の仮想化や要素の削減、項目の段階的な更新を通して向上させます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 25eeea58e1e03eedfca3aaafda1cee13cac1f3c4
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6667537"
---
# <a name="listview-and-gridview-ui-optimization"></a><span data-ttu-id="0f251-104">ListView と GridView の UI の最適化</span><span class="sxs-lookup"><span data-stu-id="0f251-104">ListView and GridView UI optimization</span></span>


<span data-ttu-id="0f251-105">**注:** の詳細は、//build/ セッション[大幅に向上させるパフォーマンス大規模な大量のデータを GridView と ListView でユーザーが操作するとき](https://channel9.msdn.com/events/build/2013/3-158)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0f251-105">**Note** For more details, see the //build/ session [Dramatically Increase Performance when Users Interact with Large Amounts of Data in GridView and ListView](https://channel9.msdn.com/events/build/2013/3-158).</span></span>

<span data-ttu-id="0f251-106">[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) のパフォーマンスと起動時間を、UI の仮想化や要素の削減、項目の段階的な更新を通して向上させます。</span><span class="sxs-lookup"><span data-stu-id="0f251-106">Improve [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) performance and startup time through UI virtualization, element reduction, and progressive updating of items.</span></span> <span data-ttu-id="0f251-107">データ仮想化の手法については、[ListView と GridView のデータ仮想化](listview-and-gridview-data-optimization.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f251-107">For data virtualization techniques, see [ListView and GridView data virtualization](listview-and-gridview-data-optimization.md).</span></span>

## <a name="two-key-factors-in-collection-performance"></a><span data-ttu-id="0f251-108">コレクションのパフォーマンスの主要な 2 つの要因</span><span class="sxs-lookup"><span data-stu-id="0f251-108">Two key factors in collection performance</span></span>

<span data-ttu-id="0f251-109">コレクションの操作は、よくある状況です。</span><span class="sxs-lookup"><span data-stu-id="0f251-109">Manipulating collections is a common scenario.</span></span> <span data-ttu-id="0f251-110">フォト ビューアーには写真のコレクションが、リーダーには記事/書籍/ストーリーのコレクションが、ショッピング アプリには製品のコレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="0f251-110">A photo viewer has collections of photos, a reader has collections of articles/books/stories, and a shopping app has collections of products.</span></span> <span data-ttu-id="0f251-111">このトピックでは、アプリでコレクションの操作を効率よく行うために何ができるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0f251-111">This topic shows what you can do to make your app efficient at manipulating collections.</span></span>

<span data-ttu-id="0f251-112">コレクションのパフォーマンスに関しては、2 つの主要な要因があります。1 つは項目を作成する UI スレッドによって費やされる時間で、もう 1 つは生のデータ セットとそのデータをレンダリングするために使用される UI 要素の両方で使用されるメモリです。</span><span class="sxs-lookup"><span data-stu-id="0f251-112">There are two key factors in performance when it comes to collections: one is the time spent by the UI thread creating items; the other is the memory used by both the raw data set and the UI elements used to render that data.</span></span>

<span data-ttu-id="0f251-113">スムーズなパン/スクロールを行うには、UI スレッドで効率的かつスマートなインスタンス化、データ バインド、および項目のレイアウトを実行することが不可欠です。</span><span class="sxs-lookup"><span data-stu-id="0f251-113">For smooth panning/scrolling, it's vital that the UI thread do an efficient and smart job of instantiating, data-binding, and laying out items.</span></span>

## <a name="ui-virtualization"></a><span data-ttu-id="0f251-114">UI の仮想化</span><span class="sxs-lookup"><span data-stu-id="0f251-114">UI virtualization</span></span>

<span data-ttu-id="0f251-115">UI の仮想化は、実行できる最も重要な改善策です。</span><span class="sxs-lookup"><span data-stu-id="0f251-115">UI virtualization is the most important improvement you can make.</span></span> <span data-ttu-id="0f251-116">これは、項目を表す UI 要素がオンデマンドで作成されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="0f251-116">This means that UI elements representing the items are created on demand.</span></span> <span data-ttu-id="0f251-117">1,000 項目のコレクションにバインドされている項目コントロールでは、すべての項目の UI を同時に作成しても、同時に全部を表示することはできないため、リソースを無駄に使うことになります。</span><span class="sxs-lookup"><span data-stu-id="0f251-117">For an items control bound to a 1000-item collection, it would be a waste of resources to create the UI for all the items at the same time, because they can't all be displayed at the same time.</span></span> <span data-ttu-id="0f251-118">UI の仮想化は、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) (およびその他の [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) から派生した標準コントロール) によって実行されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-118">[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) (and other standard [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803)-derived controls) perform UI virtualization for you.</span></span> <span data-ttu-id="0f251-119">数ページ先にある項目がスクロールされて表示されそうになると、フレームワークがその項目用の UI を生成してキャッシュします。</span><span class="sxs-lookup"><span data-stu-id="0f251-119">When items are close to being scrolled into view (a few pages away), the framework generates the UI for the items and caches them.</span></span> <span data-ttu-id="0f251-120">項目がもう一度表示される可能性が低い場合、フレームワークはメモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="0f251-120">When it's unlikely that the items will be shown again, the framework re-claims the memory.</span></span>

<span data-ttu-id="0f251-121">カスタム項目パネル テンプレート ([**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) をご覧ください) を用意する場合は、[**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Dn298849) や [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/Dn298795) などの仮想パネルを必ず使用してください。</span><span class="sxs-lookup"><span data-stu-id="0f251-121">If you provide a custom items panel template (see [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx)) then make sure you use a virtualizing panel such as [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Dn298849) or [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/Dn298795).</span></span> <span data-ttu-id="0f251-122">[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/BR227651)、[**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/BR227717)、または [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) を使用した場合、仮想化は得られません。</span><span class="sxs-lookup"><span data-stu-id="0f251-122">If you use [**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/BR227651), [**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/BR227717), or [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635), then you will not get virtualization.</span></span> <span data-ttu-id="0f251-123">また、[**ChoosingGroupHeaderContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosinggroupheadercontainer)、[**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer)、[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) の各 [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) イベントは、[**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Dn298849) または [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/Dn298795) を使用したときにのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="0f251-123">Additionally, the following [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) events are raised only when using an [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Dn298849) or an [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/Dn298795): [**ChoosingGroupHeaderContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosinggroupheadercontainer), [**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer), and [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging).</span></span>

<span data-ttu-id="0f251-124">表示される可能性のある要素の作成はフレームワークが行う必要があるため、ビューポートの概念は UI の仮想化にとって非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="0f251-124">The concept of a viewport is critical to UI virtualization because the framework must create the elements that are likely to be shown.</span></span> <span data-ttu-id="0f251-125">一般的に、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) のビューポートは論理コントロールの範囲を指します。</span><span class="sxs-lookup"><span data-stu-id="0f251-125">In general, the viewport of an [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) is the extent of the logical control.</span></span> <span data-ttu-id="0f251-126">たとえば、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) のビューポートは **ListView** 要素の幅と高さです。</span><span class="sxs-lookup"><span data-stu-id="0f251-126">For example, the viewport of a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) is the width and height of the **ListView** element.</span></span> <span data-ttu-id="0f251-127">一部のパネルでは子要素に制限のない空間を与えることができます。たとえば [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/BR209527) や [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) では、行または列のサイズが自動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-127">Some panels allow child elements unlimited space, examples being [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/BR209527) and a [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704), with auto-sized rows or columns.</span></span> <span data-ttu-id="0f251-128">このようなパネルに仮想化された **ItemsControl** を配置すると、すべての項目を表示できるスペースが用意され、仮想化の意味がなくなります。</span><span class="sxs-lookup"><span data-stu-id="0f251-128">When a virtualized **ItemsControl** is placed in a panel like that, it takes enough room to display all of its items, which defeats virtualization.</span></span> <span data-ttu-id="0f251-129">仮想化を復元するには、**ItemsControl** に幅と高さを設定します。</span><span class="sxs-lookup"><span data-stu-id="0f251-129">Restore virtualization by setting a width and height on the **ItemsControl**.</span></span>

## <a name="element-reduction-per-item"></a><span data-ttu-id="0f251-130">項目ごとの要素の削減</span><span class="sxs-lookup"><span data-stu-id="0f251-130">Element reduction per item</span></span>

<span data-ttu-id="0f251-131">項目をレンダリングするために使う UI 要素の数を、妥当と思われる最小限の数に抑えます。</span><span class="sxs-lookup"><span data-stu-id="0f251-131">Keep the number of UI elements used to render your items to a reasonable minimum.</span></span>

<span data-ttu-id="0f251-132">項目コントロールが初めて表示されるとき、すべての項目を含むビューポートをレンダリングするために必要なすべての要素が作成されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-132">When an items control is first shown, all the elements needed to render a viewport full of items are created.</span></span> <span data-ttu-id="0f251-133">さらに、項目がビューポートに近づくにつれて、キャッシュされている項目テンプレート内の UI 要素が、フレームワークによって、バインドされたデータ オブジェクトで更新されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-133">Also, as items approach the viewport, the framework updates the UI elements in cached item templates with the bound data objects.</span></span> <span data-ttu-id="0f251-134">テンプレート内のマークアップの複雑さを最小限に抑えると、メモリと UI スレッドで費やされる時間の減少という効果が生まれ、特にパン/スクロール中の応答性が向上します。</span><span class="sxs-lookup"><span data-stu-id="0f251-134">Minimizing the complexity of the markup inside templates pays off in memory and in time spent on the UI thread, improving responsiveness especially while panning/scrolling.</span></span> <span data-ttu-id="0f251-135">問題のテンプレートは、項目テンプレート ([**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) をご覧ください) と、[**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) または [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridviewitem.aspx) のコントロール テンプレート (項目コントロール テンプレート、つまり [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle)) です。</span><span class="sxs-lookup"><span data-stu-id="0f251-135">The templates in question are the item template (see [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)) and the control template of a [**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) or a [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridviewitem.aspx) (the item control template, or [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle)).</span></span> <span data-ttu-id="0f251-136">要素の数を少し減らすだけでも、その効果は、表示される項目の数と比例して大きくなります。</span><span class="sxs-lookup"><span data-stu-id="0f251-136">The benefit of even a small reduction in element count is multiplied by the number of items displayed.</span></span>

<span data-ttu-id="0f251-137">要素の削減の例については、「[XAML マークアップの最適化](optimize-xaml-loading.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f251-137">For examples of element reduction, see [Optimize your XAML markup](optimize-xaml-loading.md).</span></span>

<span data-ttu-id="0f251-138">[**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) と [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridviewitem.aspx) 用の既定のコントロール テンプレートには、[**ListViewItemPresenter**](https://msdn.microsoft.com/library/windows/apps/Dn298500) 要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0f251-138">The default control templates for [**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) and [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridviewitem.aspx) contain a [**ListViewItemPresenter**](https://msdn.microsoft.com/library/windows/apps/Dn298500) element.</span></span> <span data-ttu-id="0f251-139">このプレゼンターは、フォーカス状態や選択状態などの複雑な視覚効果を表示する、1 つの最適化された要素です。</span><span class="sxs-lookup"><span data-stu-id="0f251-139">This presenter is a single optimized element that displays complex visuals for focus, selection, and other visual states.</span></span> <span data-ttu-id="0f251-140">カスタム項目コントロール テンプレート ([**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle)) が既に存在する場合、または今後項目コントロール テンプレートのコピーを編集する場合は、**ListViewItemPresenter** を使うことをお勧めします。この要素を使うと、ほとんどの場合、パフォーマンスとカスタム可能性の最適バランスを得ることができます。</span><span class="sxs-lookup"><span data-stu-id="0f251-140">If you already have custom item control templates ([**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle)), or if in future you edit a copy of an item control template, then we recommend you use a **ListViewItemPresenter** because that element will give you optimum balance between performance and customizability in the majority of cases.</span></span> <span data-ttu-id="0f251-141">このプレゼンターは、プロパティを設定することによってカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="0f251-141">You customize the presenter by setting properties on it.</span></span> <span data-ttu-id="0f251-142">例として、項目が選ばれたときに既定で表示されるチェック マークを削除し、選ばれた項目の背景色をオレンジ色に変更するマークアップを次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f251-142">For example, here's markup that removes the check mark that appears by default when an item is selected, and changes the background color of the selected item to orange.</span></span>

```xml
...
<ListView>
 ...
 <ListView.ItemContainerStyle>
 <Style TargetType="ListViewItem">
 <Setter Property="Template">
 <Setter.Value>
 <ControlTemplate TargetType="ListViewItem">
 <ListViewItemPresenter SelectionCheckMarkVisualEnabled="False" SelectedBackground="Orange"/>
 </ControlTemplate>
 </Setter.Value>
 </Setter>
 </Style>
 </ListView.ItemContainerStyle>
</ListView>
<!-- ... -->
```

<span data-ttu-id="0f251-143">[**SelectionCheckMarkVisualEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectioncheckmarkvisualenabled.aspx) と [**SelectedBackground**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectedbackground.aspx) に似た 25 個のわかりやすい名前のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="0f251-143">There are about 25 properties with self-describing names similar to [**SelectionCheckMarkVisualEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectioncheckmarkvisualenabled.aspx) and [**SelectedBackground**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectedbackground.aspx).</span></span> <span data-ttu-id="0f251-144">これらのプレゼンターを使用目的に合うように十分にカスタマイズできないことがわかった場合は、`ListViewItemExpanded` または `GridViewItemExpanded` コントロール テンプレートのコピーを代わりに編集できます。</span><span class="sxs-lookup"><span data-stu-id="0f251-144">Should the presenter types prove not to be customizable enough for your use case, you can edit a copy of the `ListViewItemExpanded` or `GridViewItemExpanded` control template instead.</span></span> <span data-ttu-id="0f251-145">これらは、`\Program Files (x86)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\<version>\Generic\generic.xaml` の中にあります。</span><span class="sxs-lookup"><span data-stu-id="0f251-145">These can be found in `\Program Files (x86)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\<version>\Generic\generic.xaml`.</span></span> <span data-ttu-id="0f251-146">ただし、これらのテンプレートの使用は、パフォーマンスを多少低下させる代償としてカスタマイズの可能性を大きくする意味があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0f251-146">Be aware that using these templates means trading some performance for the increase in customization.</span></span>

<span id="update-items-incrementally"/>

## <a name="update-listview-and-gridview-items-progressively"></a><span data-ttu-id="0f251-147">GridView と ListView の項目を段階的に更新する</span><span class="sxs-lookup"><span data-stu-id="0f251-147">Update ListView and GridView items progressively</span></span>

<span data-ttu-id="0f251-148">データ仮想化を使う場合は、項目の読み込み中に一時的な UI 要素をレンダリングするようにコントロールを構成することで、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) の高い応答性を維持できます。</span><span class="sxs-lookup"><span data-stu-id="0f251-148">If you're using data virtualization then you can keep [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) responsiveness high by configuring the control to render temporary UI elements for the items still being (down)loaded.</span></span> <span data-ttu-id="0f251-149">一時的な要素は、データが読み込まれるときに実際の UI と段階的に置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="0f251-149">The temporary elements are then progressively replaced with actual UI as data loads.</span></span>

<span data-ttu-id="0f251-150">また、データの読み込み元 (ローカル ディスク、ネットワーク、またはクラウド) に関係なく、ユーザーは、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) または [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) をすばやくパン/スクロールできます。この間、スピードが速すぎて完全な忠実度で各項目をレンダリングすることはできませんが、スムーズなパン/スクロールは維持されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-150">Also—no matter where you're loading data from (local disk, network, or cloud)—a user can pan/scroll a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) or [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) so rapidly that it's not possible to render each item with full fidelity while preserving smooth panning/scrolling.</span></span> <span data-ttu-id="0f251-151">スムーズなパン/スクロールを維持するために、プレース ホルダーを使うだけでなく、項目を複数のフェーズでレンダリングすることを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="0f251-151">To preserve smooth panning/scrolling you can choose to render an item in multiple phases in addition to using placeholders.</span></span>

<span data-ttu-id="0f251-152">これらの手法の使用例は、写真表示アプリでよく見られます。画像のすべてが読み込まれて表示されていない場合でも、ユーザーはコレクションをパン/スクロールして操作できます。</span><span class="sxs-lookup"><span data-stu-id="0f251-152">An example of these techniques is often seen in photo-viewing apps: even though not all of the images have been loaded and displayed, the user can still pan/scroll and interact with the collection.</span></span> <span data-ttu-id="0f251-153">または、「映画」の項目の場合は、第 1 のフェーズでタイトルを表示し、第 2 のフェーズでその評価を表示し、第 3 のフェーズでポスターの画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="0f251-153">Or, for a "movie" item, you could show the title in the first phase, the rating in the second phase, and an image of the poster in the third phase.</span></span> <span data-ttu-id="0f251-154">ユーザーは各項目について最も重要なデータをできるだけ早く見ることができ、それはユーザーがすぐに行動を起こせることを意味します。</span><span class="sxs-lookup"><span data-stu-id="0f251-154">The user sees the most important data about each item as early as possible, and that means they're able to take action at once.</span></span> <span data-ttu-id="0f251-155">その後、時間の許す限り、重要度の低い情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="0f251-155">Then the less important info is filled-in as time allows.</span></span> <span data-ttu-id="0f251-156">これらの手法を実装するために使うことができるプラットフォームの機能を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f251-156">Here are the platform features you can use to implement these techniques.</span></span>

### <a name="placeholders"></a><span data-ttu-id="0f251-157">プレースホルダー</span><span class="sxs-lookup"><span data-stu-id="0f251-157">Placeholders</span></span>

<span data-ttu-id="0f251-158">一時的なプレースホルダーの視覚効果機能は、既定でオンになっています。それは [**ShowsScrollingPlaceholders**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.showsscrollingplaceholders) プロパティによって制御されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-158">The temporary placeholder visuals feature is on by default, and it's controlled with the [**ShowsScrollingPlaceholders**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.showsscrollingplaceholders) property.</span></span> <span data-ttu-id="0f251-159">高速なパン/スクロールが行われている間、この機能は、滑らかな動きを維持したまま、完全に表示されていない項目が存在することを示す視覚的なヒントをユーザーに与えます。</span><span class="sxs-lookup"><span data-stu-id="0f251-159">During fast panning/scrolling, this feature gives the user a visual hint that there are more items yet to fully display while also preserving smoothness.</span></span> <span data-ttu-id="0f251-160">次のいずれかの手法を使う場合は、必要に応じて **ShowsScrollingPlaceholders** を false に設定して、プレースホルダーが表示されないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="0f251-160">If you use one of the techniques below then you can set **ShowsScrollingPlaceholders** to false if you prefer not to have the system render placeholders.</span></span>

**<span data-ttu-id="0f251-161">x:Phase を使った段階的なデータ テンプレートの更新</span><span class="sxs-lookup"><span data-stu-id="0f251-161">Progressive data template updates using x:Phase</span></span>**

<span data-ttu-id="0f251-162">[x:Phase 属性](https://msdn.microsoft.com/library/windows/apps/Mt204790)と [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) バインドを使って段階的なデータ テンプレートの更新を実装する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f251-162">Here's how to use the [x:Phase attribute](https://msdn.microsoft.com/library/windows/apps/Mt204790) with [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) bindings to implement progressive data template updates.</span></span>

1.  <span data-ttu-id="0f251-163">これは、バインディング ソースがどのようになるかを示しています (これは、バインド先のデータ ソースです)。</span><span class="sxs-lookup"><span data-stu-id="0f251-163">Here's what the binding source looks like (this is the data source that we'll bind to).</span></span>

    ```csharp
    namespace LotsOfItems
    {
        public class ExampleItem
        {
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string Description { get; set; }
        }

        public class ExampleItemViewModel
        {
            private ObservableCollection<ExampleItem> exampleItems = new ObservableCollection<ExampleItem>();
            public ObservableCollection<ExampleItem> ExampleItems { get { return this.exampleItems; } }

            public ExampleItemViewModel()
            {
                for (int i = 1; i < 150000; i++)
                {
                    this.exampleItems.Add(new ExampleItem(){
                        Title = "Title: " + i.ToString(),
                        Subtitle = "Sub: " + i.ToString(),
                        Description = "Desc: " + i.ToString()
                    });
                }
            }
        }
    }
    ```
2.  <span data-ttu-id="0f251-164">これは、`DeferMainPage.xaml` に含まれるマークアップです。</span><span class="sxs-lookup"><span data-stu-id="0f251-164">Here's the markup that `DeferMainPage.xaml` contains.</span></span> <span data-ttu-id="0f251-165">グリッド ビューには、**MyItem** クラスの **Title** プロパティ、**Subtitle** プロパティ、**Description** プロパティにバインドされた項目テンプレートが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f251-165">The grid view contains an item template with elements bound to the **Title**, **Subtitle**, and **Description** properties of the **MyItem** class.</span></span> <span data-ttu-id="0f251-166">**x:Phase** の既定値は 0 であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0f251-166">Note that **x:Phase** defaults to 0.</span></span> <span data-ttu-id="0f251-167">ここでは、項目は、そのタイトルだけが最初にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0f251-167">Here, items will be initially rendered with just the title visible.</span></span> <span data-ttu-id="0f251-168">次に、サブタイトル要素がバインドされたデータになり、すべての項目に表示され、以下、同じようにすべてのフェーズが処理されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-168">Then the subtitle element will be data bound and made visible for all the items and so on until all the phases have been processed.</span></span>
    ```xml
    <Page
        x:Class="LotsOfItems.DeferMainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:lotsOfItems="using:LotsOfItems"
        mc:Ignorable="d">

        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <GridView ItemsSource="{x:Bind ViewModel.ExampleItems}">
                <GridView.ItemTemplate>
                    <DataTemplate x:DataType="lotsOfItems:ExampleItem">
                        <StackPanel Height="100" Width="100" Background="OrangeRed">
                            <TextBlock Text="{x:Bind Title}"/>
                            <TextBlock Text="{x:Bind Subtitle}" x:Phase="1"/>
                            <TextBlock Text="{x:Bind Description}" x:Phase="2"/>
                        </StackPanel>
                    </DataTemplate>
                </GridView.ItemTemplate>
            </GridView>
        </Grid>
    </Page>
    ```

3.  <span data-ttu-id="0f251-169">今すぐアプリを実行し、グリッド ビューですばやくパン/スクロールすると、新しい項目が画面に表示されるとき、項目は最初は濃い灰色の四角形としてレンダリングされ ([**ShowsScrollingPlaceholders**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.showsscrollingplaceholders) プロパティが既定で **true** に設定されているためです)、次にタイトルが表示され、その後にサブタイトルと説明が表示されることがわかります。</span><span class="sxs-lookup"><span data-stu-id="0f251-169">If you run the app now and pan/scroll quickly through the grid view then you'll notice that as each new item appears on the screen, at first it is rendered as a dark gray rectangle (thanks to the [**ShowsScrollingPlaceholders**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.showsscrollingplaceholders) property defaulting to **true**), then the title appears, followed by subtitle, followed by description.</span></span>

**<span data-ttu-id="0f251-170">ContainerContentChanging を使った段階的なデータ テンプレートの更新</span><span class="sxs-lookup"><span data-stu-id="0f251-170">Progressive data template updates using ContainerContentChanging</span></span>**

<span data-ttu-id="0f251-171">[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) の一般的な戦略は、**Opacity** を使ってすぐに表示する必要がない要素を非表示にすることです。</span><span class="sxs-lookup"><span data-stu-id="0f251-171">The general strategy for the [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) event is to use **Opacity** to hide elements that don’t need to be immediately visible.</span></span> <span data-ttu-id="0f251-172">要素をリサイクルすると以前の値が保持されるため、新しいデータ項目の値で更新するまで、要素を非表示にします。</span><span class="sxs-lookup"><span data-stu-id="0f251-172">When elements are recycled, they will retain their old values so we want to hide those elements until we've updated those values from the new data item.</span></span> <span data-ttu-id="0f251-173">イベント引数で **Phase** プロパティを使って、どの要素を更新して表示するかを決めます。</span><span class="sxs-lookup"><span data-stu-id="0f251-173">We use the **Phase** property on the event arguments to determine which elements to update and show.</span></span> <span data-ttu-id="0f251-174">追加のフェーズが必要な場合は、コールバックを登録します。</span><span class="sxs-lookup"><span data-stu-id="0f251-174">If additional phases are needed, we register a callback.</span></span>

1.  <span data-ttu-id="0f251-175">**x:Phase** と同じバインド ソースを使用します。</span><span class="sxs-lookup"><span data-stu-id="0f251-175">We'll use the same binding source as for **x:Phase**.</span></span>

2.  <span data-ttu-id="0f251-176">これは、`MainPage.xaml` に含まれるマークアップです。</span><span class="sxs-lookup"><span data-stu-id="0f251-176">Here's the markup that `MainPage.xaml` contains.</span></span> <span data-ttu-id="0f251-177">グリッド ビューは、その [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) イベントに対してハンドラーを宣言します。その中には、**MyItem** クラスの **Title** プロパティ、**Subtitle** プロパティ、**Description** プロパティを表示するために使われる要素を持つ項目テンプレートが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f251-177">The grid view declares a handler to its [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) event, and it contains an item template with elements used to display the **Title**, **Subtitle**, and **Description** properties of the **MyItem** class.</span></span> <span data-ttu-id="0f251-178">**ContainerContentChanging** を使ったパフォーマンス上の最大のメリットを得るため、マークアップではバインドを使わず、代わりに値をプログラムを使って割り当てます。</span><span class="sxs-lookup"><span data-stu-id="0f251-178">To get the maximum performance benefits of using **ContainerContentChanging**, we don't use bindings in the markup but we instead assign values programmatically.</span></span> <span data-ttu-id="0f251-179">ここでの例外は、フェーズ 0 とみなしているタイトルを表示する要素です。</span><span class="sxs-lookup"><span data-stu-id="0f251-179">The exception here is the element displaying the title, which we consider to be in phase 0.</span></span>
    ```xml
    <Page
        x:Class="LotsOfItems.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:lotsOfItems="using:LotsOfItems"
        mc:Ignorable="d">

        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <GridView ItemsSource="{x:Bind ViewModel.ExampleItems}" ContainerContentChanging="GridView_ContainerContentChanging">
                <GridView.ItemTemplate>
                    <DataTemplate x:DataType="lotsOfItems:ExampleItem">
                        <StackPanel Height="100" Width="100" Background="OrangeRed">
                            <TextBlock Text="{x:Bind Title}"/>
                            <TextBlock Opacity="0"/>
                            <TextBlock Opacity="0"/>
                        </StackPanel>
                    </DataTemplate>
                </GridView.ItemTemplate>
            </GridView>
        </Grid>
    </Page>
    ```
3.  <span data-ttu-id="0f251-180">最後に、[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) イベント ハンドラーの実装を示します。</span><span class="sxs-lookup"><span data-stu-id="0f251-180">Lastly, here's the implementation of the [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.containercontentchanging) event handler.</span></span> <span data-ttu-id="0f251-181">このコードは、**RecordingViewModel** 型のプロパティを **MainPage** に追加して、マークアップのページを表すクラスからバインディング ソース クラスを公開する方法も示しています。</span><span class="sxs-lookup"><span data-stu-id="0f251-181">This code also shows how we add a property of type **RecordingViewModel** to **MainPage** to expose the binding source class from the class that represents our page of markup.</span></span> <span data-ttu-id="0f251-182">データ テンプレート内に [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) バインドが含まれていない限り、イベント引数オブジェクトをハンドラーの最初のフェーズで処理するようにマークして、データ コンテキストを設定する必要はないことを項目に通知します。</span><span class="sxs-lookup"><span data-stu-id="0f251-182">As long as you don't have any [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) bindings in your data template, then mark the event arguments object as handled in the first phase of the handler to hint to the item that it needn't set a data context.</span></span>
    ```csharp
    namespace LotsOfItems
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                this.ViewModel = new ExampleItemViewModel();
            }

            public ExampleItemViewModel ViewModel { get; set; }

            // Display each item incrementally to improve performance.
            private void GridView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
            {
                if (args.Phase != 0)
                {
                    throw new System.Exception("We should be in phase 0, but we are not.");
                }

                // It's phase 0, so this item's title will already be bound and displayed.

                args.RegisterUpdateCallback(this.ShowSubtitle);

                args.Handled = true;
            }

            private void ShowSubtitle(ListViewBase sender, ContainerContentChangingEventArgs args)
            {
                if (args.Phase != 1)
                {
                    throw new System.Exception("We should be in phase 1, but we are not.");
                }

                // It's phase 1, so show this item's subtitle.
                var templateRoot = args.ItemContainer.ContentTemplateRoot as StackPanel;
                var textBlock = templateRoot.Children[1] as TextBlock;
                textBlock.Text = (args.Item as ExampleItem).Subtitle;
                textBlock.Opacity = 1;

                args.RegisterUpdateCallback(this.ShowDescription);
            }

            private void ShowDescription(ListViewBase sender, ContainerContentChangingEventArgs args)
            {
                if (args.Phase != 2)
                {
                    throw new System.Exception("We should be in phase 2, but we are not.");
                }

                // It's phase 2, so show this item's description.
                var templateRoot = args.ItemContainer.ContentTemplateRoot as StackPanel;
                var textBlock = templateRoot.Children[2] as TextBlock;
                textBlock.Text = (args.Item as ExampleItem).Description;
                textBlock.Opacity = 1;
            }
        }
    }
    ```

4.  <span data-ttu-id="0f251-183">今すぐアプリを実行し、グリッド ビューですばやくパン/スクロールすると、**x:Phase** と同じ動作が起こることがわかります。</span><span class="sxs-lookup"><span data-stu-id="0f251-183">If you run the app now and pan/scroll quickly through the grid view then you'll see the same behavior as for as for **x:Phase**.</span></span>

## <a name="container-recycling-with-heterogeneous-collections"></a><span data-ttu-id="0f251-184">異種コレクションでのコンテナー リサイクル</span><span class="sxs-lookup"><span data-stu-id="0f251-184">Container-recycling with heterogeneous collections</span></span>

<span data-ttu-id="0f251-185">一部のアプリケーションでは、コレクション内のさまざまな種類の項目に合わせて異なる UI を用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f251-185">In some applications, you need to have different UI for different types of item within a collection.</span></span> <span data-ttu-id="0f251-186">これにより、仮想化されるパネルで、項目を表示するために使用される視覚要素を再利用またはリサイクルすることができない状況が発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="0f251-186">This can create a situation where it is impossible for virtualizing panels to reuse/recycle the visual elements used to display the items.</span></span> <span data-ttu-id="0f251-187">パンした時に項目の視覚要素を再作成すると、仮想化によって得られた多くのパフォーマンスのメリットが取り消されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-187">Recreating the visual elements for an item during panning undoes many of the performance wins provided by virtualization.</span></span> <span data-ttu-id="0f251-188">ただし、少し計画することで、仮想化されるパネルで要素を再利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="0f251-188">However, a little planning can allow virtualizing panels to reuse the elements.</span></span> <span data-ttu-id="0f251-189">開発者には、シナリオに応じて、[**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) イベントまたは項目テンプレート セレクターの 2 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="0f251-189">Developers have a couple of options depending on their scenario: the [**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) event, or an item template selector.</span></span> <span data-ttu-id="0f251-190">**ChoosingItemContainer** アプローチでは、パフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="0f251-190">The **ChoosingItemContainer** approach has better performance.</span></span>

**<span data-ttu-id="0f251-191">ChoosingItemContainer イベント</span><span class="sxs-lookup"><span data-stu-id="0f251-191">The ChoosingItemContainer event</span></span>**

<span data-ttu-id="0f251-192">[**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) イベントは、起動時やリサイクル時に新しい項目が必要になったときに、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878)/[**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) に項目 (**ListViewItem**/**GridViewItem**) を提供できるようにするイベントです。</span><span class="sxs-lookup"><span data-stu-id="0f251-192">[**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) is an event that allows you to provide an item (**ListViewItem**/**GridViewItem**) to the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878)/[**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) whenever a new item is needed during start-up or recycling.</span></span> <span data-ttu-id="0f251-193">コンテナーが表示するデータ項目の種類に基づいてコンテナーを作成できます (次の例で示します)。</span><span class="sxs-lookup"><span data-stu-id="0f251-193">You can create a container based on the type of data item the container will display (shown in the example below).</span></span> <span data-ttu-id="0f251-194">**ChoosingItemContainer** は、より効率よく、異なる項目に異なるデータ テンプレートを使用するための方法です。</span><span class="sxs-lookup"><span data-stu-id="0f251-194">**ChoosingItemContainer** is the higher-performing way to use different data templates for different items.</span></span> <span data-ttu-id="0f251-195">**ChoosingItemContainer** を使って実現できるものとして、コンテナーのキャッシュがあります。</span><span class="sxs-lookup"><span data-stu-id="0f251-195">Container caching is something that can be achieved using **ChoosingItemContainer**.</span></span> <span data-ttu-id="0f251-196">たとえば、5 種類のテンプレートがあり、そのうちの 1 つのテンプレートが、他と比べて 1 桁多く発生している場合、ChoosingItemContainer を使うと、必要な比率で項目を作成できるだけでなく、キャッシュされた要素とリサイクルに利用できる要素も適切な数に維持されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-196">For example, if you have five different templates, with one template occurring an order of magnitude more often than the others, then ChoosingItemContainer allows you not only to create items at the ratios needed but also to keep an appropriate number of elements cached and available for recycling.</span></span> <span data-ttu-id="0f251-197">[**ChoosingGroupHeaderContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosinggroupheadercontainer) は、グループ ヘッダーと同じ機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="0f251-197">[**ChoosingGroupHeaderContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosinggroupheadercontainer) provides the same functionality for group headers.</span></span>

```csharp
// Example shows how to use ChoosingItemContainer to return the correct
// DataTemplate when one is available. This example shows how to return different 
// data templates based on the type of FileItem. Available ListViewItems are kept
// in two separate lists based on the type of DataTemplate needed.
private void ListView_ChoosingItemContainer
    (ListViewBase sender, ChoosingItemContainerEventArgs args)
{
    // Determines type of FileItem from the item passed in.
    bool special = args.Item is DifferentFileItem;

    // Uses the Tag property to keep track of whether a particular ListViewItem's 
    // datatemplate should be a simple or a special one.
    string tag = special ? "specialFiles" : "simpleFiles";

    // Based on the type of datatemplate needed return the correct list of 
    // ListViewItems, this could have also been handled with a hash table. These 
    // two lists are being used to keep track of ItemContainers that can be reused.
    List<UIElement> relevantStorage = special ? specialFileItemTrees : simpleFileItemTrees;

    // args.ItemContainer is used to indicate whether the ListView is proposing an 
    // ItemContainer (ListViewItem) to use. If args.Itemcontainer, then there was a 
    // recycled ItemContainer available to be reused.
    if (args.ItemContainer != null)
    {
        // The Tag is being used to determine whether this is a special file or 
        // a simple file.
        if (args.ItemContainer.Tag.Equals(tag))
        {
            // Great: the system suggested a container that is actually going to 
            // work well.
        }
        else
        {
            // the ItemContainer's datatemplate does not match the needed 
            // datatemplate.
            args.ItemContainer = null;
        }
    }

    if (args.ItemContainer == null)
    {
        // see if we can fetch from the correct list.
        if (relevantStorage.Count > 0)
        {
            args.ItemContainer = relevantStorage[0] as SelectorItem;
        }
        else
        {
            // there aren't any (recycled) ItemContainers available. So a new one 
            // needs to be created.
            ListViewItem item = new ListViewItem();
            item.ContentTemplate = this.Resources[tag] as DataTemplate;
            item.Tag = tag;
            args.ItemContainer = item;
        }
    }
}
```

**<span data-ttu-id="0f251-198">項目テンプレート セレクター</span><span class="sxs-lookup"><span data-stu-id="0f251-198">Item template selector</span></span>**

<span data-ttu-id="0f251-199">項目テンプレート セレクター ([**DataTemplateSelector**](https://msdn.microsoft.com/library/windows/apps/BR209469)) により、アプリで、表示されるデータ項目の種類に基づいて、実行時に異なる項目テンプレートを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="0f251-199">An item template selector ([**DataTemplateSelector**](https://msdn.microsoft.com/library/windows/apps/BR209469)) allows an app to return a different item template at runtime based on the type of the data item that will be displayed.</span></span> <span data-ttu-id="0f251-200">これにより、開発の生産性は向上しますが、すべてのデータ項目について、すべての項目テンプレートを再利用できるわけではないため、UI の仮想化はより難しくなります。</span><span class="sxs-lookup"><span data-stu-id="0f251-200">This makes development more productive, but it makes UI virtualization more difficult because not every item template can be reused for every data item.</span></span>

<span data-ttu-id="0f251-201">項目 (**ListViewItem**/**GridViewItem**) をリサイクルする場合、リサイクル キュー (リサイクル キューは現在データを表示するために使用されていない項目のキャッシュです) で使用できる項目の項目テンプレートが、現在のデータ項目で求められるテンプレートと一致するかどうかを、フレームワークが判断する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f251-201">When recycling an item (**ListViewItem**/**GridViewItem**), the framework must decide whether the items that are available for use in the recycle queue (the recycle queue is a cache of items that are not currently being used to display data) have an item template that will match the one desired by the current data item.</span></span> <span data-ttu-id="0f251-202">リサイクル キューに適切な項目テンプレートを持つ項目がない場合、新しい項目が作成され、適切な項目テンプレートがインスタンス化されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-202">If there are no items in the recycle queue with the appropriate item template then a new item is created, and the appropriate item template is instantiated for it.</span></span> <span data-ttu-id="0f251-203">一方、リサイクル キューに、適切な項目テンプレートを持つ項目が含まれている場合、その項目はリサイクル キューから削除され、現在のデータ項目のために使用されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-203">If, on other hand, the recycle queue contains an item with the appropriate item template then that item is removed from the recycle queue and is used for the current data item.</span></span> <span data-ttu-id="0f251-204">項目テンプレート セレクターは、使用されている項目テンプレートの数が少なく、異なる項目テンプレートを使用する項目のコレクション全体にわたって項目がフラットに分布しているような状況に適しています。</span><span class="sxs-lookup"><span data-stu-id="0f251-204">An item template selector works in situations where only a small number of item templates are used and there is a flat distribution throughout the collection of items that use different item templates.</span></span>

<span data-ttu-id="0f251-205">異なる項目テンプレートを使う項目が均一に分布していない場合、パン中に新しい項目テンプレートを作成することが必要になる可能性が高く、仮想化によって提供される利点の多くが打ち消されます。</span><span class="sxs-lookup"><span data-stu-id="0f251-205">When there is an uneven distribution of items that use different item templates then new item templates will likely need to be created during panning, and this negates many of the gains provided by virtualization.</span></span> <span data-ttu-id="0f251-206">さらに、項目テンプレート セレクターでは、特定のコンテナーが現在のデータ項目用に再利用できるかどうかを評価する際に、対象として検討される候補は 5 つだけです。</span><span class="sxs-lookup"><span data-stu-id="0f251-206">Additionally, an item template selector only considers five possible candidates when evaluating whether a particular container can be reused for the current data item.</span></span> <span data-ttu-id="0f251-207">このため、アプリで項目テンプレート セレクターを使用する前に、データが項目テンプレート セレクターでの使用に適しているかどうかを慎重に検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f251-207">So you should carefully consider whether your data is appropriate for use with an item template selector before using one in your app.</span></span> <span data-ttu-id="0f251-208">コレクションがほぼ同種の項目で構成される場合、セレクターはほとんど毎回 (状況によっては常に) 同じ種類を返すことになります。</span><span class="sxs-lookup"><span data-stu-id="0f251-208">If your collection is mostly homogeneous then the selector is returning the same type most (possibly all) of the time.</span></span> <span data-ttu-id="0f251-209">ほぼ同種の中のまれな例外を処理するためにかかるコストに注意し、[**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) (または 2 つの項目コントロール) の使用が妥当であるかどうかを検討します。</span><span class="sxs-lookup"><span data-stu-id="0f251-209">Just be aware of the price you're paying for the rare exceptions to that homegeneity, and consider whether using [**ChoosingItemContainer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.choosingitemcontainer) (or two items controls) is preferable.</span></span>

 

