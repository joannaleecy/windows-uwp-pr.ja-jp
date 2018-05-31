---
author: serenaz
Description: Tabs and pivots enable users to navigate between frequently accessed content.
title: タブとピボット
ms.assetid: 556BC70D-CF5D-4295-A655-D58163CC1824
label: Tabs and pivots
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 09e88fd070f7e7517e55d6f57563dd7608696770
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1675479"
---
# <a name="pivot-and-tabs"></a><span data-ttu-id="928a6-103">ピボットとタブ</span><span class="sxs-lookup"><span data-stu-id="928a6-103">Pivot and tabs</span></span>



<span data-ttu-id="928a6-104">Pivot コントロールと関連タブは、アクセス頻度の高い個別のコンテンツ カテゴリ間を移動するために使います。</span><span class="sxs-lookup"><span data-stu-id="928a6-104">The Pivot control and related tabs pattern are used for navigating frequently accessed, distinct content categories.</span></span> <span data-ttu-id="928a6-105">ピボットを使うと、2 つ以上のコンテンツ ウィンドウ間を移動できるようになり、テキスト ヘッダーを使ってコンテンツのさまざまなセクションにラベル付けできます。</span><span class="sxs-lookup"><span data-stu-id="928a6-105">Pivots allow for navigation between two or more content panes and rely on text headers to label the different sections of content.</span></span>

> <span data-ttu-id="928a6-106">**重要な API**: [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)</span><span class="sxs-lookup"><span data-stu-id="928a6-106">**Important APIs**: [Pivot class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)</span></span>

![ピボット コントロールの例](images/pivot_Hero_main.png)

<span data-ttu-id="928a6-108">タブは、アイコンとテキストの組み合わせ、またはアイコンのみを使ってコンテンツのセクションを明確化するピボットの視覚的な変化形です。</span><span class="sxs-lookup"><span data-stu-id="928a6-108">Tabs are a visual variant of Pivot that use a combination of icons and text or just icons to articulate section content.</span></span> <span data-ttu-id="928a6-109">タブは、[Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) コントロールを使って構築されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-109">Tabs are built using the [Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) control.</span></span> <span data-ttu-id="928a6-110">[Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903)は、Pivot コントロールをタブ パターンへとカスタマイズする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="928a6-110">The [Pivot sample](http://go.microsoft.com/fwlink/p/?LinkId=619903) shows how to customize the Pivot control into the tabs pattern.</span></span>

![タブ パターンの例](images/tabs.png) 

## <a name="the-pivot-control"></a><span data-ttu-id="928a6-112">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="928a6-112">The pivot control</span></span>

<span data-ttu-id="928a6-113">ピボットを使ってアプリを構築する場合は、考慮すべきいくつかの重要なデザインの変数があります。</span><span class="sxs-lookup"><span data-stu-id="928a6-113">When building an app with pivot, there are a few key design variables to consider.</span></span>

- **<span data-ttu-id="928a6-114">ヘッダー ラベル。</span><span class="sxs-lookup"><span data-stu-id="928a6-114">Header labels.</span></span>**  <span data-ttu-id="928a6-115">ヘッダーは、テキスト付きのアイコン、アイコンのみ、またはテキストのみで示すことができます。</span><span class="sxs-lookup"><span data-stu-id="928a6-115">Headers can have an icon with text, icon only, or text only.</span></span>
- **<span data-ttu-id="928a6-116">ヘッダーの整列。</span><span class="sxs-lookup"><span data-stu-id="928a6-116">Header alignment.</span></span>**  <span data-ttu-id="928a6-117">ヘッダーは、左揃えまたは中央揃えにすることができます。</span><span class="sxs-lookup"><span data-stu-id="928a6-117">Headers can be left-justified or centered.</span></span>
- **<span data-ttu-id="928a6-118">トップレベルまたはサブレベルのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="928a6-118">Top-level or sub-level navigation.</span></span>**  <span data-ttu-id="928a6-119">ピボットは、いずれかのレベルのナビゲーションで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="928a6-119">Pivots can be used for either level of navigation.</span></span> <span data-ttu-id="928a6-120">必要に応じて、[ナビゲーション ビュー](navigationview.md)をプライマリ レベルで提供し、ピボットをセカンダリとして提供できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-120">Optionally, [navigation view](navigationview.md) can serve as the primary level with pivot acting as secondary.</span></span>
- **<span data-ttu-id="928a6-121">タッチ ジェスチャのサポート。</span><span class="sxs-lookup"><span data-stu-id="928a6-121">Touch gesture support.</span></span>**  <span data-ttu-id="928a6-122">タッチ ジェスチャをサポートするデバイスでは、次に示す 2 つの操作セットのどちらかを使ってコンテンツ カテゴリ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-122">For devices that support touch gestures, you can use one of two interaction sets to navigate between content categories:</span></span>
    1. <span data-ttu-id="928a6-123">タブ/ピボット ヘッダーをタップして、そのカテゴリに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-123">Tap on a tab/pivot header to navigate to that category.</span></span>
    2. <span data-ttu-id="928a6-124">コンテンツ領域上で左または右へスワイプして隣接するカテゴリに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-124">Swipe left or right on the content area to navigate to the adjacent category.</span></span>

## <a name="examples"></a><span data-ttu-id="928a6-125">例</span><span class="sxs-lookup"><span data-stu-id="928a6-125">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="928a6-126">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="928a6-126">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="928a6-127"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Pivot">アプリを開き、Pivot の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="928a6-127">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Pivot">open the app and see the Pivot in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="928a6-128">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="928a6-128">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="928a6-129">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="928a6-129">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="928a6-130">電話での Pivot コントロール。</span><span class="sxs-lookup"><span data-stu-id="928a6-130">Pivot control on phone.</span></span>

![ピボットの例](images/pivot_example.png)

<span data-ttu-id="928a6-132">アラーム & クロック アプリのタブ パターン。</span><span class="sxs-lookup"><span data-stu-id="928a6-132">Tabs pattern in the Alarms & Clock app.</span></span>

![アラーム & クロック内のタブ パターンの例](images/tabs_alarms-and-clock.png)

## <a name="create-a-pivot-control"></a><span data-ttu-id="928a6-134">ピボット コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="928a6-134">Create a pivot control</span></span>

<span data-ttu-id="928a6-135">[Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) コントロールには、このセクションで説明する基本的な機能が付属しています。</span><span class="sxs-lookup"><span data-stu-id="928a6-135">The [Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) control comes with the basic functionality described in this section.</span></span>

<span data-ttu-id="928a6-136">この XAML では、コンテンツの 3 つのセクションで、基本的なピボット コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="928a6-136">This XAML creates a basic pivot control with 3 sections of content.</span></span>

```xaml
<Pivot x:Name="rootPivot" Title="Pivot Title">
    <PivotItem Header="Pivot Item 1">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 1."/>
    </PivotItem>
    <PivotItem Header="Pivot Item 2">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 2."/>
    </PivotItem>
    <PivotItem Header="Pivot Item 3">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of pivot item 3."/>
    </PivotItem>
</Pivot>
```

### <a name="pivot-items"></a><span data-ttu-id="928a6-137">ピボット項目</span><span class="sxs-lookup"><span data-stu-id="928a6-137">Pivot items</span></span>

<span data-ttu-id="928a6-138">Pivot は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="928a6-138">Pivot is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="928a6-139">ピボットに追加する項目が明示的に [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。</span><span class="sxs-lookup"><span data-stu-id="928a6-139">Any item you add to the Pivot that is not explicitly a [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) is implicitly wrapped in a PivotItem.</span></span> <span data-ttu-id="928a6-140">ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="928a6-140">Because a Pivot is often used to navigate between pages of content, it's common to populate the [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) collection directly with XAML UI elements.</span></span> <span data-ttu-id="928a6-141">または、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="928a6-141">Or, you can set the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span> <span data-ttu-id="928a6-142">ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)と [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="928a6-142">Items bound in the ItemsSource can be of any type, but if they aren't explicitly PivotItems, you must define an [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) and [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) to specify how the items are displayed.</span></span>

<span data-ttu-id="928a6-143">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-143">You can use the [SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) property to get or set the Pivot's active item.</span></span> <span data-ttu-id="928a6-144">アクティブな項目のインデックスを取得または設定するには、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="928a6-144">Use the [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) property to get or set the index of the active item.</span></span>

### <a name="pivot-headers"></a><span data-ttu-id="928a6-145">ピボット ヘッダー</span><span class="sxs-lookup"><span data-stu-id="928a6-145">Pivot headers</span></span>

<span data-ttu-id="928a6-146">[LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-146">You can use the [LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) and [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) properties to add other controls to the Pivot header.</span></span>

<span data-ttu-id="928a6-147">たとえば、[CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) をピボットの RightHeader に追加できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-147">For example, you can add a [CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) in the Pivot's RightHeader.</span></span>

![ピボット コントロールの右側のヘッダーにあるコマンド バーの例](images/PivotHeader.png)

```xaml
<Pivot>
    <Pivot.RightHeader>
        <CommandBar OverflowButtonVisibility="Collapsed" Background="Transparent">
                <AppBarButton Icon="Add"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Edit"/>
                <AppBarButton Icon="Delete"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Save"/>
        </CommandBar>
    </Pivot.RightHeader>
</Pivot>
```

### <a name="pivot-interaction"></a><span data-ttu-id="928a6-149">ピボットの操作</span><span class="sxs-lookup"><span data-stu-id="928a6-149">Pivot interaction</span></span>

<span data-ttu-id="928a6-150">ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。</span><span class="sxs-lookup"><span data-stu-id="928a6-150">The control features these touch gesture interactions:</span></span>

-   <span data-ttu-id="928a6-151">ピボット項目のヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-151">Tapping on a pivot item header navigates to that header's section content.</span></span>
-   <span data-ttu-id="928a6-152">ピボット項目のヘッダー上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-152">Swiping left or right on a pivot item header navigates to the adjacent section.</span></span>
-   <span data-ttu-id="928a6-153">セクション コンテンツ上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-153">Swiping left or right on section content navigates to the adjacent section.</span></span>

![セクション コンテンツ上で左にスワイプする例](images/pivot_w_hand.png)

<span data-ttu-id="928a6-155">コントロールには次の 2 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="928a6-155">The control comes in two modes:</span></span>

**<span data-ttu-id="928a6-156">固定</span><span class="sxs-lookup"><span data-stu-id="928a6-156">Stationary</span></span>**

-   <span data-ttu-id="928a6-157">許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-157">Pivots are stationary when all pivot headers fit within the allowed space.</span></span>
-   <span data-ttu-id="928a6-158">ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。</span><span class="sxs-lookup"><span data-stu-id="928a6-158">Tapping on a pivot label navigates to the corresponding page, though the pivot itself will not move.</span></span> <span data-ttu-id="928a6-159">アクティブなピボットは強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-159">The active pivot is highlighted.</span></span>

**<span data-ttu-id="928a6-160">カルーセル</span><span class="sxs-lookup"><span data-stu-id="928a6-160">Carousel</span></span>**

-   <span data-ttu-id="928a6-161">許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-161">Pivots carousel when all pivot headers don't fit within the allowed space.</span></span>
-   <span data-ttu-id="928a6-162">ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-162">Tapping a pivot label navigates to the corresponding page, and the active pivot label will carousel into the first position.</span></span>
-   <span data-ttu-id="928a6-163">カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。</span><span class="sxs-lookup"><span data-stu-id="928a6-163">Pivot items in a carousel loop from last to first pivot section.</span></span>

> <span data-ttu-id="928a6-164">**注** ピボット ヘッダーを [10 フィート環境](../devices/designing-for-tv.md)でカルーセル表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="928a6-164">**Note** Pivot headers should not carousel in a [10ft environment](../devices/designing-for-tv.md).</span></span> <span data-ttu-id="928a6-165">Xbox 上でアプリを実行する場合は、[IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="928a6-165">Set the [IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) property to **false** if your app will run on Xbox.</span></span>

### <a name="pivot-focus"></a><span data-ttu-id="928a6-166">ピボット フォーカス</span><span class="sxs-lookup"><span data-stu-id="928a6-166">Pivot focus</span></span>

<span data-ttu-id="928a6-167">既定では、ピボット ヘッダー上のキーボード フォーカスは下線付きで表示されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-167">By default, keyboard focus on a pivot header is represented with an underline.</span></span>

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

<span data-ttu-id="928a6-169">ピボットをカスタマイズし、ヘッダーの選択ビジュアルに下線を組み込んだアプリでは、[HeaderFocusVisualPlacement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.HeaderFocusVisualPlacement) プロパティを使って既定の設定を変更できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-169">Apps that have customized Pivot and incorporate the underline into header selection visuals can use the [HeaderFocusVisualPlacement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.HeaderFocusVisualPlacement) property to change the default.</span></span> <span data-ttu-id="928a6-170">`HeaderFocusVisualPlacement="ItemHeaders"` を指定した場合、フォーカスはヘッダー パネル全体を取り囲むように描画されます。</span><span class="sxs-lookup"><span data-stu-id="928a6-170">When `HeaderFocusVisualPlacement="ItemHeaders"`, focus will be drawn around the entire header panel.</span></span>

![ItemsHeader オプションはピボット ヘッダー全体を取り囲むフォーカス用の四角形を描画する](images/pivot_focus_headers.png)

## <a name="recommendations"></a><span data-ttu-id="928a6-172">推奨事項</span><span class="sxs-lookup"><span data-stu-id="928a6-172">Recommendations</span></span>

- <span data-ttu-id="928a6-173">タブ/ピボット ヘッダーの配置は画面サイズに基づいて行います。</span><span class="sxs-lookup"><span data-stu-id="928a6-173">Base the alignment of tab/pivot headers on screen size.</span></span> <span data-ttu-id="928a6-174">画面幅が 720 epx 未満の場合、通常は中央揃えが適しています。720 epx 以上の画面幅では、ほとんどの場合、左揃えをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="928a6-174">For screen widths below 720 epx, center-aligning usually works better, while left-aligning for screen widths above 720 epx is recommended in most cases.</span></span>
- <span data-ttu-id="928a6-175">カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="928a6-175">Avoid using more than 5 headers when using carousel (round-trip) mode, as looping more than 5 can become confusing.</span></span>
- <span data-ttu-id="928a6-176">ピボット項目が個別のアイコンを持つ場合にのみ、タブ パターンを使います。</span><span class="sxs-lookup"><span data-stu-id="928a6-176">Use the tabs pattern only if your pivot items have distinct icons.</span></span>
- <span data-ttu-id="928a6-177">ピボット項目ヘッダーに、ピボットの各セクションの意味を理解できるようなテキストを含めます。</span><span class="sxs-lookup"><span data-stu-id="928a6-177">Include text in pivot item headers to help users understand the meaning of each pivot section.</span></span> <span data-ttu-id="928a6-178">アイコンは、必ずしもすべてのユーザーが容易に判別できるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="928a6-178">Icons are not necessarily self-explanatory to all users.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="928a6-179">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="928a6-179">Get the sample code</span></span>

- <span data-ttu-id="928a6-180">[Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903) - Pivot コントロールをタブ パターンへとカスタマイズする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="928a6-180">[Pivot sample](http://go.microsoft.com/fwlink/p/?LinkId=619903) - Demonstrates how to customize the Pivot control into the tabs pattern.</span></span>
- <span data-ttu-id="928a6-181">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="928a6-181">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="928a6-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="928a6-182">Related topics</span></span>

- [<span data-ttu-id="928a6-183">Pivot クラス</span><span class="sxs-lookup"><span data-stu-id="928a6-183">Pivot class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)
- [<span data-ttu-id="928a6-184">ナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="928a6-184">Navigation design basics</span></span>](../basics/navigation-basics.md)
