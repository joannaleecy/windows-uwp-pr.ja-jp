---
author: QuinnRadich
Description: The Pivot control enables touch-swiping between a small set of content sections.
title: ピボット
template: detail.hbs
ms.author: quradic
ms.date: 06/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 5bb6ed36c772e5ae80a3cb801b4b6b36bb1ab18c
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4267753"
---
# <a name="pivot"></a><span data-ttu-id="491a4-103">ピボット</span><span class="sxs-lookup"><span data-stu-id="491a4-103">Pivot</span></span>

<span data-ttu-id="491a4-104">[ピボット](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)コントロールは、少数のセクションではコンテンツの間でタッチ スワイプを使用できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-104">The [Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) control enables touch-swiping between a small set of content sections.</span></span>

> <span data-ttu-id="491a4-105">**重要な Api**: [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)、 [NavigationView クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span><span class="sxs-lookup"><span data-stu-id="491a4-105">**Important APIs**: [Pivot class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot), [NavigationView class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span></span>

## <a name="examples"></a><span data-ttu-id="491a4-106">例</span><span class="sxs-lookup"><span data-stu-id="491a4-106">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="491a4-107">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="491a4-107">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="491a4-108"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合は、アプリを<a href="xamlcontrolsgallery:/item/Pivot">開き、Pivot コントロールの動作をご覧ください。</a>ここをクリックします。</span><span class="sxs-lookup"><span data-stu-id="491a4-108">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Pivot">open the app and see the Pivot control in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="491a4-109">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="491a4-109">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="491a4-110">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="491a4-110">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="491a4-111">[NavigationView](navigationview.md)と同様、Pivot コントロールでは、選択した項目に下線します。</span><span class="sxs-lookup"><span data-stu-id="491a4-111">The Pivot control, just like [NavigationView](navigationview.md), underlines the selected item.</span></span>

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="491a4-113">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="491a4-113">Is this the right control?</span></span>

<span data-ttu-id="491a4-114">一般的な上部のナビゲーションとタブ パターンを実現するためには、 [NavigationView](navigationview.md)、これは自動的にさまざまな画面サイズに合わせて変化するより詳細にカスタマイズを使用してお勧めします。</span><span class="sxs-lookup"><span data-stu-id="491a4-114">To achieve common top navigation and tabs patterns, we recommend using [NavigationView](navigationview.md), which automatically adapts to different screen sizes and allows for greater customization.</span></span>

<span data-ttu-id="491a4-115">ただし、タッチ スワイプ ナビゲーションを必要とする場合は、ピボットを使用して勧めします。</span><span class="sxs-lookup"><span data-stu-id="491a4-115">However, if your navigation requires touch-swiping, we recommend using Pivot.</span></span>

<span data-ttu-id="491a4-116">NavigationView とピボット コントロールの他の主な違いは、既定のオーバーフローの動作とナビゲーション API には。</span><span class="sxs-lookup"><span data-stu-id="491a4-116">The other key differences between the NavigationView and Pivot controls are the default overflow behavior and the navigation API:</span></span>

- <span data-ttu-id="491a4-117">ユーザーはすべての項目を表示できるように、NavigationView はメニューのドロップダウン リストの項目がオーバーフロー カルーセル オーバーフローのピボットします。</span><span class="sxs-lookup"><span data-stu-id="491a4-117">Pivot carousels overflow items, while NavigationView uses a menu dropdown overflow so that users can see all items.</span></span>
- <span data-ttu-id="491a4-118">ピボットで NavigationView ではナビゲーションの動作をより細かく制御できますが、コンテンツのセクション間のナビゲーションを処理します。</span><span class="sxs-lookup"><span data-stu-id="491a4-118">Pivot handles navigation between content sections, while NavigationView allows for more control over navigation behavior.</span></span>

## <a name="use-navigationview-instead-of-pivot"></a><span data-ttu-id="491a4-119">ピボットではなく NavigationView を使用します。</span><span class="sxs-lookup"><span data-stu-id="491a4-119">Use NavigationView instead of Pivot</span></span>

<span data-ttu-id="491a4-120">アプリの UI は、Pivot コントロールを使用している場合は、次のコードでピボットを NavigationView を変換できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-120">If your app's UI uses the Pivot control, then you can convert Pivot to NavigationView with the code below.</span></span>

<span data-ttu-id="491a4-121">この XAML は、Pivot の[pivot コントロールを作成する](#create-a-pivot-control)例のように、コンテンツの 3 つのセクションで、NavigationView を作成します。</span><span class="sxs-lookup"><span data-stu-id="491a4-121">This XAML creates a NavigationView with 3 sections of content, like the example Pivot in [Create a pivot control](#create-a-pivot-control).</span></span>

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

<span data-ttu-id="491a4-122">NavigationView は、ナビゲーションのカスタマイズをより細かく制御し、コード ビハインドで対応する必要があります。</span><span class="sxs-lookup"><span data-stu-id="491a4-122">NavigationView provides more control over navigation customization and requires corresponding code-behind.</span></span> <span data-ttu-id="491a4-123">上記の XAML を実質的には、次のコード ビハインドを使用します。</span><span class="sxs-lookup"><span data-stu-id="491a4-123">To accompany the above XAML, use the following code-behind:</span></span>

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

<span data-ttu-id="491a4-124">このコードは、コンテンツのセクション間タッチ スワイプ エクスペリエンス マイナスのピボット コントロールの組み込みのナビゲーション エクスペリエンスを模したものです。</span><span class="sxs-lookup"><span data-stu-id="491a4-124">This code mimics the Pivot control's built-in navigation experience, minus the touch-swiping experience between content sections.</span></span> <span data-ttu-id="491a4-125">ただし、ご覧のように、切り替え効果のアニメーション化された、ナビゲーション パラメーターには、スタック機能など、いくつかのポイントもカスタマイズ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="491a4-125">However, as you can see, you could also customize several points, including the animated transition, navigation parameters, and stack capabilities.</span></span>

## <a name="create-a-pivot-control"></a><span data-ttu-id="491a4-126">ピボット コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="491a4-126">Create a pivot control</span></span>

<span data-ttu-id="491a4-127">このコードは、コンテンツの 3 つのセクションの基本的なピボット コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="491a4-127">This code creates a basic Pivot control with 3 sections of content.</span></span>

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

### <a name="pivot-items"></a><span data-ttu-id="491a4-128">ピボット項目</span><span class="sxs-lookup"><span data-stu-id="491a4-128">Pivot items</span></span>

<span data-ttu-id="491a4-129">Pivot は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="491a4-129">Pivot is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="491a4-130">ピボットに追加する項目が明示的に [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。</span><span class="sxs-lookup"><span data-stu-id="491a4-130">Any item you add to the Pivot that is not explicitly a [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) is implicitly wrapped in a PivotItem.</span></span> <span data-ttu-id="491a4-131">ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="491a4-131">Because a Pivot is often used to navigate between pages of content, it's common to populate the [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) collection directly with XAML UI elements.</span></span> <span data-ttu-id="491a4-132">または、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="491a4-132">Or, you can set the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span> <span data-ttu-id="491a4-133">ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)と [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="491a4-133">Items bound in the ItemsSource can be of any type, but if they aren't explicitly PivotItems, you must define an [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) and [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) to specify how the items are displayed.</span></span>

<span data-ttu-id="491a4-134">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-134">You can use the [SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) property to get or set the Pivot's active item.</span></span> <span data-ttu-id="491a4-135">アクティブな項目のインデックスを取得または設定するには、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="491a4-135">Use the [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) property to get or set the index of the active item.</span></span>

### <a name="pivot-headers"></a><span data-ttu-id="491a4-136">ピボット ヘッダー</span><span class="sxs-lookup"><span data-stu-id="491a4-136">Pivot headers</span></span>

<span data-ttu-id="491a4-137">[LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-137">You can use the [LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) and [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) properties to add other controls to the Pivot header.</span></span>

<span data-ttu-id="491a4-138">たとえば、[CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) をピボットの RightHeader に追加できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-138">For example, you can add a [CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) in the Pivot's RightHeader.</span></span>

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

### <a name="pivot-interaction"></a><span data-ttu-id="491a4-139">ピボットの操作</span><span class="sxs-lookup"><span data-stu-id="491a4-139">Pivot interaction</span></span>

<span data-ttu-id="491a4-140">ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。</span><span class="sxs-lookup"><span data-stu-id="491a4-140">The control features these touch gesture interactions:</span></span>

- <span data-ttu-id="491a4-141">ピボット項目のヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。</span><span class="sxs-lookup"><span data-stu-id="491a4-141">Tapping on a pivot item header navigates to that header's section content.</span></span>
- <span data-ttu-id="491a4-142">ピボット項目のヘッダー上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="491a4-142">Swiping left or right on a pivot item header navigates to the adjacent section.</span></span>
- <span data-ttu-id="491a4-143">セクション コンテンツ上で左または右へスワイプすると、隣接するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="491a4-143">Swiping left or right on section content navigates to the adjacent section.</span></span>

<span data-ttu-id="491a4-144">コントロールには次の 2 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="491a4-144">The control comes in two modes:</span></span>

**<span data-ttu-id="491a4-145">固定</span><span class="sxs-lookup"><span data-stu-id="491a4-145">Stationary</span></span>**

- <span data-ttu-id="491a4-146">許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。</span><span class="sxs-lookup"><span data-stu-id="491a4-146">Pivots are stationary when all pivot headers fit within the allowed space.</span></span>
- <span data-ttu-id="491a4-147">ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。</span><span class="sxs-lookup"><span data-stu-id="491a4-147">Tapping on a pivot label navigates to the corresponding page, though the pivot itself will not move.</span></span> <span data-ttu-id="491a4-148">アクティブなピボットは強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="491a4-148">The active pivot is highlighted.</span></span>

**<span data-ttu-id="491a4-149">カルーセル</span><span class="sxs-lookup"><span data-stu-id="491a4-149">Carousel</span></span>**

- <span data-ttu-id="491a4-150">許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="491a4-150">Pivots carousel when all pivot headers don't fit within the allowed space.</span></span>
- <span data-ttu-id="491a4-151">ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。</span><span class="sxs-lookup"><span data-stu-id="491a4-151">Tapping a pivot label navigates to the corresponding page, and the active pivot label will carousel into the first position.</span></span>
- <span data-ttu-id="491a4-152">カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。</span><span class="sxs-lookup"><span data-stu-id="491a4-152">Pivot items in a carousel loop from last to first pivot section.</span></span>

> <span data-ttu-id="491a4-153">**注** ピボット ヘッダーを [10 フィート環境](../devices/designing-for-tv.md)でカルーセル表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="491a4-153">**Note** Pivot headers should not carousel in a [10ft environment](../devices/designing-for-tv.md).</span></span> <span data-ttu-id="491a4-154">Xbox 上でアプリを実行する場合は、[IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="491a4-154">Set the [IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) property to **false** if your app will run on Xbox.</span></span>

## <a name="recommendations"></a><span data-ttu-id="491a4-155">推奨事項</span><span class="sxs-lookup"><span data-stu-id="491a4-155">Recommendations</span></span>

- <span data-ttu-id="491a4-156">カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="491a4-156">Avoid using more than 5 headers when using carousel (round-trip) mode, as looping more than 5 can become confusing.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="491a4-157">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="491a4-157">Get the sample code</span></span>

- <span data-ttu-id="491a4-158">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="491a4-158">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="491a4-159">関連トピック</span><span class="sxs-lookup"><span data-stu-id="491a4-159">Related topics</span></span>

- [<span data-ttu-id="491a4-160">Pivot クラス</span><span class="sxs-lookup"><span data-stu-id="491a4-160">Pivot class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)
- [<span data-ttu-id="491a4-161">ナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="491a4-161">Navigation design basics</span></span>](../basics/navigation-basics.md)