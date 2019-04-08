---
Description: Pivot コントロールは、タッチ、スワイプ、少数のコンテンツ セクションの間で有効です。
title: Pivot
template: detail.hbs
ms.date: 06/19/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 56079bc51d3efa8f7ecaaee21379a6e9caf7d440
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642927"
---
# <a name="pivot"></a><span data-ttu-id="a2970-104">Pivot</span><span class="sxs-lookup"><span data-stu-id="a2970-104">Pivot</span></span>

<span data-ttu-id="a2970-105">[Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)コントロール タッチ、スワイプ、少数のコンテンツ セクションの間で有効にします。</span><span class="sxs-lookup"><span data-stu-id="a2970-105">The [Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) control enables touch-swiping between a small set of content sections.</span></span>

> <span data-ttu-id="a2970-106">**重要な API**:[クラスのピボット](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)、 [NavigationView クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span><span class="sxs-lookup"><span data-stu-id="a2970-106">**Important APIs**: [Pivot class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot), [NavigationView class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span></span>

## <a name="examples"></a><span data-ttu-id="a2970-107">例</span><span class="sxs-lookup"><span data-stu-id="a2970-107">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="a2970-108">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="a2970-108">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="a2970-109">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/Pivot">アプリを開き、操作にピボット コントロールが表示</a>します。</span><span class="sxs-lookup"><span data-stu-id="a2970-109">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Pivot">open the app and see the Pivot control in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="a2970-110"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="a2970-110"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="a2970-111"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="a2970-111"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="a2970-112">ピボット コントロールと同じように[NavigationView](navigationview.md)、選択した項目で下線を表示します。</span><span class="sxs-lookup"><span data-stu-id="a2970-112">The Pivot control, just like [NavigationView](navigationview.md), underlines the selected item.</span></span>

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="a2970-114">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="a2970-114">Is this the right control?</span></span>

<span data-ttu-id="a2970-115">一般的な上部のナビゲーションとタブのパターンを実現する使用をお勧め[NavigationView](navigationview.md)、自動的にさまざまな画面サイズに適応し、より詳細にカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="a2970-115">To achieve common top navigation and tabs patterns, we recommend using [NavigationView](navigationview.md), which automatically adapts to different screen sizes and allows for greater customization.</span></span>

<span data-ttu-id="a2970-116">ただし、タッチ、スワイプ、ナビゲーションを必要とする場合は、Pivot を使用してを勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2970-116">However, if your navigation requires touch-swiping, we recommend using Pivot.</span></span>

<span data-ttu-id="a2970-117">NavigationView やピボット コントロール間の他の主な違いは、既定のオーバーフロー動作およびナビゲーションの API には。</span><span class="sxs-lookup"><span data-stu-id="a2970-117">The other key differences between the NavigationView and Pivot controls are the default overflow behavior and the navigation API:</span></span>

- <span data-ttu-id="a2970-118">カルーセルのオーバーフロー項目、NavigationView はメニューのドロップダウンを使用してすべての項目を表示するようにのオーバーフローをピボットします。</span><span class="sxs-lookup"><span data-stu-id="a2970-118">Pivot carousels overflow items, while NavigationView uses a menu dropdown overflow so that users can see all items.</span></span>
- <span data-ttu-id="a2970-119">ピボット処理中に、NavigationView はナビゲーションの動作を細かく制御する場合、コンテンツのセクション間を移動します。</span><span class="sxs-lookup"><span data-stu-id="a2970-119">Pivot handles navigation between content sections, while NavigationView allows for more control over navigation behavior.</span></span>

## <a name="use-navigationview-instead-of-pivot"></a><span data-ttu-id="a2970-120">NavigationView を使用して、ピボットではなく</span><span class="sxs-lookup"><span data-stu-id="a2970-120">Use NavigationView instead of Pivot</span></span>

<span data-ttu-id="a2970-121">アプリの UI は、Pivot コントロールを使用している場合は、次のコードでに、NavigationView にピボットを変換できます。</span><span class="sxs-lookup"><span data-stu-id="a2970-121">If your app's UI uses the Pivot control, then you can convert Pivot to NavigationView with the code below.</span></span>

<span data-ttu-id="a2970-122">この XAML ピボットの例のように、コンテンツの 3 つのセクション、NavigationView の作成で[ピボット コントロールを作成する](#create-a-pivot-control)します。</span><span class="sxs-lookup"><span data-stu-id="a2970-122">This XAML creates a NavigationView with 3 sections of content, like the example Pivot in [Create a pivot control](#create-a-pivot-control).</span></span>

```xaml
<NavigationView x:Name="rootNavigationView" Header="Category Title"
 ItemInvoked="NavView_ItemInvoked">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Section 1" x:Name="Section1Content" />
        <NavigationViewItem Content="Section 2" x:Name="Section2Content" />
        <NavigationViewItem Content="Section 3" x:Name="Section3Content" />
    </NavigationView.MenuItems>
</NavigationView>

<Page x:Class="AppName.Section1Page">
    <TextBlock Text="Content of section 1."/>
</Page>

<Page x:Class="AppName.Section2Page">
    <TextBlock Text="Content of section 2."/>
</Page>

<Page x:Class="AppName.Section3Page">
    <TextBlock Text="Content of section 3."/>
</Page>
```

<span data-ttu-id="a2970-123">NavigationView はナビゲーションのカスタマイズをより細かく制御し、対応する分離コードが必要です。</span><span class="sxs-lookup"><span data-stu-id="a2970-123">NavigationView provides more control over navigation customization and requires corresponding code-behind.</span></span> <span data-ttu-id="a2970-124">上記の XAML に付随するには、次のコード ビハインドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a2970-124">To accompany the above XAML, use the following code-behind:</span></span>

```csharp
private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{
    FrameNavigationOptions navOptions = new FrameNavigationOptions();
    navOptions.TransitionInfoOverride = new SlideNavigationTransitionInfo() {
         SlideNavigationTransitionDirection=args.RecommendedNavigationTransitionInfo
    };

    navOptions.IsNavigationStackEnabled = False;

    switch (item.Name)
    {
        case "Section1Content":
            ContentFrame.NavigateToType(typeof(Section1Page), null, navOptions);
            break;

        case "Section2Content":
            ContentFrame.NavigateToType(typeof(Section2Page), null, navOptions);
            break;

        case "Section3Content":
            ContentFrame.NavigateToType(typeof(Section3Page), null, navOptions);
            break;
    }  
}
```

<span data-ttu-id="a2970-125">このコードは、コンテンツ セクションの間のタッチ スワイプ エクスペリエンス マイナスのピボット コントロールの組み込みのナビゲーション エクスペリエンスを模倣します。</span><span class="sxs-lookup"><span data-stu-id="a2970-125">This code mimics the Pivot control's built-in navigation experience, minus the touch-swiping experience between content sections.</span></span> <span data-ttu-id="a2970-126">ただし、ご覧のとおり、アニメーションの切り替え、ナビゲーション パラメーターでは、スタックの機能など、いくつかのポイントもカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="a2970-126">However, as you can see, you could also customize several points, including the animated transition, navigation parameters, and stack capabilities.</span></span>

## <a name="create-a-pivot-control"></a><span data-ttu-id="a2970-127">ピボット コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="a2970-127">Create a pivot control</span></span>

<span data-ttu-id="a2970-128">このコードでは、3 つのセクションのコンテンツの基本的なピボット コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="a2970-128">This code creates a basic Pivot control with 3 sections of content.</span></span>

```xaml
<Pivot x:Name="rootPivot" Title="Category Title">
    <PivotItem Header="Section 1">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 1."/>
    </PivotItem>
    <PivotItem Header="Section 2">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 2."/>
    </PivotItem>
    <PivotItem Header="Section 3">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 3."/>
    </PivotItem>
</Pivot>
```

### <a name="pivot-items"></a><span data-ttu-id="a2970-129">ピボット項目</span><span class="sxs-lookup"><span data-stu-id="a2970-129">Pivot items</span></span>

<span data-ttu-id="a2970-130">Pivot は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="a2970-130">Pivot is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="a2970-131">ピボットに追加する項目が明示的に [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。</span><span class="sxs-lookup"><span data-stu-id="a2970-131">Any item you add to the Pivot that is not explicitly a [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) is implicitly wrapped in a PivotItem.</span></span> <span data-ttu-id="a2970-132">ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="a2970-132">Because a Pivot is often used to navigate between pages of content, it's common to populate the [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) collection directly with XAML UI elements.</span></span> <span data-ttu-id="a2970-133">または、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="a2970-133">Or, you can set the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span> <span data-ttu-id="a2970-134">ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)と [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2970-134">Items bound in the ItemsSource can be of any type, but if they aren't explicitly PivotItems, you must define an [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) and [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) to specify how the items are displayed.</span></span>

<span data-ttu-id="a2970-135">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。</span><span class="sxs-lookup"><span data-stu-id="a2970-135">You can use the [SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) property to get or set the Pivot's active item.</span></span> <span data-ttu-id="a2970-136">アクティブな項目のインデックスを取得または設定するには、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="a2970-136">Use the [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) property to get or set the index of the active item.</span></span>

### <a name="pivot-headers"></a><span data-ttu-id="a2970-137">ピボット ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a2970-137">Pivot headers</span></span>

<span data-ttu-id="a2970-138">[LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="a2970-138">You can use the [LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) and [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) properties to add other controls to the Pivot header.</span></span>

<span data-ttu-id="a2970-139">たとえば、[CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) をピボットの RightHeader に追加できます。</span><span class="sxs-lookup"><span data-stu-id="a2970-139">For example, you can add a [CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) in the Pivot's RightHeader.</span></span>

```xaml
<Pivot>
    <Pivot.RightHeader>
        <CommandBar>
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

### <a name="pivot-interaction"></a><span data-ttu-id="a2970-140">ピボットの操作</span><span class="sxs-lookup"><span data-stu-id="a2970-140">Pivot interaction</span></span>

<span data-ttu-id="a2970-141">ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。</span><span class="sxs-lookup"><span data-stu-id="a2970-141">The control features these touch gesture interactions:</span></span>

- <span data-ttu-id="a2970-142">ピボット項目のヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。</span><span class="sxs-lookup"><span data-stu-id="a2970-142">Tapping on a pivot item header navigates to that header's section content.</span></span>
- <span data-ttu-id="a2970-143">ピボット項目のヘッダー上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="a2970-143">Swiping left or right on a pivot item header navigates to the adjacent section.</span></span>
- <span data-ttu-id="a2970-144">セクション コンテンツ上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="a2970-144">Swiping left or right on section content navigates to the adjacent section.</span></span>

<span data-ttu-id="a2970-145">コントロールには次の 2 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="a2970-145">The control comes in two modes:</span></span>

<span data-ttu-id="a2970-146">**静止しています。**</span><span class="sxs-lookup"><span data-stu-id="a2970-146">**Stationary**</span></span>

- <span data-ttu-id="a2970-147">許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。</span><span class="sxs-lookup"><span data-stu-id="a2970-147">Pivots are stationary when all pivot headers fit within the allowed space.</span></span>
- <span data-ttu-id="a2970-148">ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。</span><span class="sxs-lookup"><span data-stu-id="a2970-148">Tapping on a pivot label navigates to the corresponding page, though the pivot itself will not move.</span></span> <span data-ttu-id="a2970-149">アクティブなピボットは強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="a2970-149">The active pivot is highlighted.</span></span>

<span data-ttu-id="a2970-150">**カルーセル**</span><span class="sxs-lookup"><span data-stu-id="a2970-150">**Carousel**</span></span>

- <span data-ttu-id="a2970-151">許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="a2970-151">Pivots carousel when all pivot headers don't fit within the allowed space.</span></span>
- <span data-ttu-id="a2970-152">ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="a2970-152">Tapping a pivot label navigates to the corresponding page, and the active pivot label will carousel into the first position.</span></span>
- <span data-ttu-id="a2970-153">カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。</span><span class="sxs-lookup"><span data-stu-id="a2970-153">Pivot items in a carousel loop from last to first pivot section.</span></span>

> <span data-ttu-id="a2970-154">**注** ピボット ヘッダーを [10 フィート環境](../devices/designing-for-tv.md)でカルーセル表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="a2970-154">**Note** Pivot headers should not carousel in a [10ft environment](../devices/designing-for-tv.md).</span></span> <span data-ttu-id="a2970-155">Xbox 上でアプリを実行する場合は、[IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a2970-155">Set the [IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) property to **false** if your app will run on Xbox.</span></span>

## <a name="recommendations"></a><span data-ttu-id="a2970-156">推奨事項</span><span class="sxs-lookup"><span data-stu-id="a2970-156">Recommendations</span></span>

- <span data-ttu-id="a2970-157">カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a2970-157">Avoid using more than 5 headers when using carousel (round-trip) mode, as looping more than 5 can become confusing.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="a2970-158">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="a2970-158">Get the sample code</span></span>

- <span data-ttu-id="a2970-159">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="a2970-159">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="a2970-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a2970-160">Related topics</span></span>

- [<span data-ttu-id="a2970-161">Pivot クラス</span><span class="sxs-lookup"><span data-stu-id="a2970-161">Pivot class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)
- [<span data-ttu-id="a2970-162">ナビゲーションのデザインの基礎</span><span class="sxs-lookup"><span data-stu-id="a2970-162">Navigation design basics</span></span>](../basics/navigation-basics.md)