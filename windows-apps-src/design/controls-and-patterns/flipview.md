---
Description: Displays images in a collection, such as photos in an album or items in a product details page, one image at a time.
title: FlipView コントロールのガイドライン
ms.assetid: A4E05D92-1A0E-4CDD-84B9-92199FF8A8A3
label: Flip view
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: predavid
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 9a7fa4b824e0472971fab61935857670fa5b49ee
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8942729"
---
# <a name="flip-view"></a><span data-ttu-id="73dd4-103">フリップ ビュー</span><span class="sxs-lookup"><span data-stu-id="73dd4-103">Flip view</span></span>

 

<span data-ttu-id="73dd4-104">コレクション内の画像やその他の項目 (アルバムの写真や製品の詳細ページの項目など) を一度に 1 つずつ表示するには、フリップ ビュー コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="73dd4-104">Use a flip view for browsing images or other items in a collection, such as photos in an album or items in a product details page, one item at a time.</span></span> <span data-ttu-id="73dd4-105">タッチ デバイスでは、項目をスワイプしてコレクション内を移動します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-105">For touch devices, swiping across an item moves through the collection.</span></span> <span data-ttu-id="73dd4-106">マウスでは、マウスをホバーするとナビゲーション ボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-106">For a mouse, navigation buttons appear on mouse hover.</span></span> <span data-ttu-id="73dd4-107">キーボードでは、方向キーを使ってコレクション内を移動します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-107">For a keyboard, arrow keys move through the collection.</span></span>

> <span data-ttu-id="73dd4-108">**重要な API**: [FlipView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)、[ItemsSource プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx)、[ItemTemplate プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)</span><span class="sxs-lookup"><span data-stu-id="73dd4-108">**Important APIs**: [FlipView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx), [ItemsSource property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx), [ItemTemplate property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="73dd4-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="73dd4-109">Is this the right control?</span></span>

<span data-ttu-id="73dd4-110">フリップ ビューは、小規模から中規模のコレクション (最大で 25 個程度の項目を含むコレクション) の画像を参照する場合に最適です。</span><span class="sxs-lookup"><span data-stu-id="73dd4-110">Flip view is best for perusing images in small to medium collections (up to 25 or so items).</span></span> <span data-ttu-id="73dd4-111">このようなコレクションの例として、製品の詳細ページ内の項目やフォト アルバム内の写真などがあります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-111">Examples of such collections include items in a product details page or photos in a photo album.</span></span> <span data-ttu-id="73dd4-112">多くの場合、大規模なコレクションで FlipView を使うことはお勧めしませんが、このコントロールは、フォト アルバム内の個々の画像を表示するためによく使われます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-112">Although we don't recommend flip view for most large collections, the control is common for viewing individual images in a photo album.</span></span>

## <a name="examples"></a><span data-ttu-id="73dd4-113">例</span><span class="sxs-lookup"><span data-stu-id="73dd4-113">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="73dd4-114">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="73dd4-114">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="73dd4-115"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/FlipView">アプリを開き、FlipView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="73dd4-115">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/FlipView">open the app and see the FlipView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="73dd4-116">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="73dd4-116">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="73dd4-117">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="73dd4-117">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="73dd4-118">水平方向の閲覧、左端の項目から開始し、右にフリップするのが、FlipView の一般的なレイアウトです。</span><span class="sxs-lookup"><span data-stu-id="73dd4-118">Horizontal browsing, starting at the left-most item and flipping right, is the typical layout for a flip view.</span></span> <span data-ttu-id="73dd4-119">このレイアウトは、すべてのデバイス上で縦方向でも横方向でも正常に動作します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-119">This layout works well in either portrait or landscape orientation on all devices:</span></span>

![水平方向の FlipView のレイアウトに関する例](images/controls_flipview_horizonal.jpg)

<span data-ttu-id="73dd4-121">フリップ ビューは、垂直方向にも閲覧できます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-121">A flip view can also be browsed vertically:</span></span>

![垂直方向のフリップ ビューに関する例](images/controls_flipview_vertical.jpg)

## <a name="create-a-flip-view"></a><span data-ttu-id="73dd4-123">フリップ ビューを作成する</span><span class="sxs-lookup"><span data-stu-id="73dd4-123">Create a flip view</span></span>

<span data-ttu-id="73dd4-124">FlipView は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目をコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-124">FlipView is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="73dd4-125">ビューのデータを設定するには、項目を [**Items**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに追加するか、[**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-125">To populate the view, add items to the [**Items**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection, or set the [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span>

<span data-ttu-id="73dd4-126">既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてフリップ ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-126">By default, a data item is displayed in the flip view as the string representation of the data object it's bound to.</span></span> <span data-ttu-id="73dd4-127">フリップ ビューでの項目の表示方法を正確に指定するには、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.datatemplate.aspx) を作成して、個々の項目を表示するために使うコントロールのレイアウトを定義します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-127">To specify exactly how items in the flip view are displayed, you create a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.datatemplate.aspx) to define the layout of controls used to display an individual item.</span></span> <span data-ttu-id="73dd4-128">レイアウト内のコントロールは、データ オブジェクトのプロパティにバインドすることも、インラインでコンテンツを定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-128">The controls in the layout can be bound to properties of a data object, or have content defined inline.</span></span> <span data-ttu-id="73dd4-129">DataTemplate は、FlipView の [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-129">You assign the DataTemplate to the [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the FlipView.</span></span>

### <a name="add-items-to-the-items-collection"></a><span data-ttu-id="73dd4-130">項目コレクションへの項目の追加</span><span class="sxs-lookup"><span data-stu-id="73dd4-130">Add items to the Items collection</span></span>

<span data-ttu-id="73dd4-131">[**Items**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加するには、XAML かコードを使います。</span><span class="sxs-lookup"><span data-stu-id="73dd4-131">You can add items to the [**Items**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection using XAML or code.</span></span> <span data-ttu-id="73dd4-132">通常、項目が少数で、その項目が変わらず、XAML で簡単に定義できる場合や、実行時にコードで項目を生成する場合は、この方法で項目を追加します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-132">You typically add items this way if you have a small number of items that don't change and are easily defined in XAML, or if you generate the items in code at run time.</span></span> <span data-ttu-id="73dd4-133">項目をインラインで定義したフリップ ビューを次に示します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-133">Here's a flip view with items defined inline.</span></span>

```xaml
<FlipView x:Name="flipView1">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

```csharp
// Create a new flip view, add content, 
// and add a SelectionChanged event handler.
FlipView flipView1 = new FlipView();
flipView1.Items.Add("Item 1");
flipView1.Items.Add("Item 2");

// Add the flip view to a parent container in the visual tree.
stackPanel1.Children.Add(flipView1);
```

<span data-ttu-id="73dd4-134">フリップ ビューに項目を追加すると、追加した項目は [**FlipViewItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipviewitem.aspx) コンテナーに自動的に設定されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-134">When you add items to a flip view they are automatically placed in a [**FlipViewItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipviewitem.aspx) container.</span></span> <span data-ttu-id="73dd4-135">項目の表示方法を変更するには、[**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) プロパティを設定して、項目コンテナーにスタイルを適用します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-135">To change how an item is displayed you can apply a style to the item container by setting the [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) property.</span></span> 

<span data-ttu-id="73dd4-136">XAML で項目を定義すると、定義した項目は Items コレクションに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-136">When you define the items in XAML, they are automatically added to the Items collection.</span></span>

### <a name="set-the-items-source"></a><span data-ttu-id="73dd4-137">項目ソースの設定</span><span class="sxs-lookup"><span data-stu-id="73dd4-137">Set the items source</span></span>

<span data-ttu-id="73dd4-138">通常、フリップ ビューを使って、データベースやインターネットなどのソースからデータを表示します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-138">You typically use a flip view to display data from a source such as a database or the Internet.</span></span> <span data-ttu-id="73dd4-139">データ ソースからフリップ ビューのデータを設定するには、[**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ項目のコレクションに設定します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-139">To populate a flip view from a data source, you set its [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a collection of data items.</span></span>

<span data-ttu-id="73dd4-140">以下の例では、コードでコレクションのインスタンスに直接フリップ ビューの ItemsSource を設定しています。</span><span class="sxs-lookup"><span data-stu-id="73dd4-140">Here, the flip view's ItemsSource is set in code directly to an instance of a collection.</span></span>

```csharp
// Data source.
List<String> itemsList = new List<string>();
itemsList.Add("Item 1");
itemsList.Add("Item 2");

// Create a new flip view, add content, 
// and add a SelectionChanged event handler.
FlipView flipView1 = new FlipView();
flipView1.ItemsSource = itemsList;
flipView1.SelectionChanged += FlipView_SelectionChanged;

// Add the flip view to a parent container in the visual tree.
stackPanel1.Children.Add(flipView1);
```

<span data-ttu-id="73dd4-141">ItemsSource プロパティを、XAML でコレクションにバインドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-141">You can also bind the ItemsSource property to a collection in XAML.</span></span> <span data-ttu-id="73dd4-142">詳しくは、「[XAML を使ったデータ バインディング](../../data-binding/data-binding-quickstart.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73dd4-142">For more info, see [Data binding with XAML](../../data-binding/data-binding-quickstart.md).</span></span>

<span data-ttu-id="73dd4-143">ItemsSource が `itemsViewSource` という名前の [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) にバインドされている例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-143">Here, the ItemsSource is bound to a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) named `itemsViewSource`.</span></span> 

```xaml
<Page.Resources>
    <!-- Collection of items displayed by this page -->
    <CollectionViewSource x:Name="itemsViewSource" Source="{Binding Items}"/>
</Page.Resources>

...

<FlipView x:Name="itemFlipView" 
          ItemsSource="{Binding Source={StaticResource itemsViewSource}}"/>
```

><span data-ttu-id="73dd4-144">**注**&nbsp;&nbsp;フリップ ビューのデータを設定するには、その Items コレクションに項目を追加するか ItemsSource プロパティを設定しますが、同時に両方の方法で設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="73dd4-144">**Note**&nbsp;&nbsp;You can populate a flip view either by adding items to its Items collection, or by setting its ItemsSource property, but you can't use both ways at the same time.</span></span> <span data-ttu-id="73dd4-145">ItemsSource プロパティを設定して XAML で項目を追加した場合、追加された項目は無視されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-145">If you set the ItemsSource property and you add an item in XAML, the added item is ignored.</span></span> <span data-ttu-id="73dd4-146">ItemsSource プロパティを設定してコードで Items コレクションに項目を追加した場合、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-146">If you set the ItemsSource property and you add an item to the Items collection in code, an exception is thrown.</span></span>

### <a name="specify-the-look-of-the-items"></a><span data-ttu-id="73dd4-147">項目の表示方法の指定</span><span class="sxs-lookup"><span data-stu-id="73dd4-147">Specify the look of the items</span></span>

<span data-ttu-id="73dd4-148">既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてフリップ ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-148">By default, a data item is displayed in the flip view as the string representation of the data object it's bound to.</span></span> <span data-ttu-id="73dd4-149">通常は、リッチな表現でデータを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-149">You typically want to show a more rich presentation of your data.</span></span> <span data-ttu-id="73dd4-150">フリップ ビューでの項目の表示方法を正確に指定するには、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-150">To specify exactly how items in the flip view are displayed, you create a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx).</span></span> <span data-ttu-id="73dd4-151">DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-151">The XAML in the DataTemplate defines the layout and appearance of controls used to display an individual item.</span></span> <span data-ttu-id="73dd4-152">レイアウト内のコントロールは、データ オブジェクトのプロパティにバインドすることも、インラインでコンテンツを定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-152">The controls in the layout can be bound to properties of a data object, or have content defined inline.</span></span> <span data-ttu-id="73dd4-153">DataTemplate は、FlipView の [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-153">The DataTemplate is assigned to the [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the FlipView control.</span></span>

<span data-ttu-id="73dd4-154">この例では、FlipView の ItemTemplate がインラインで定義されています。</span><span class="sxs-lookup"><span data-stu-id="73dd4-154">In this example, the ItemTemplate of a FlipView is defined inline.</span></span> <span data-ttu-id="73dd4-155">画像名を表示するためにオーバーレイが画像に追加されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-155">An overlay is added to the image to display the image name.</span></span> 

```XAML
<FlipView x:Name="flipView1" Width="480" Height="270" 
          BorderBrush="Black" BorderThickness="1">
    <FlipView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Image Width="480" Height="270" Stretch="UniformToFill"
                       Source="{Binding Image}"/>
                <Border Background="#A5000000" Height="80" VerticalAlignment="Bottom">
                    <TextBlock Text="{Binding Name}" 
                               FontFamily="Segoe UI" FontSize="26.667" 
                               Foreground="#CCFFFFFF" Padding="15,20"/>
                </Border>
            </Grid>
        </DataTemplate>
    </FlipView.ItemTemplate>
</FlipView>
```

<span data-ttu-id="73dd4-156">このデータ テンプレートで定義されたレイアウトは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-156">Here's what the layout defined by the data template looks like.</span></span>

<span data-ttu-id="73dd4-157">フリップ ビュー データ テンプレート。</span><span class="sxs-lookup"><span data-stu-id="73dd4-157">Flip view data template.</span></span>

### <a name="set-the-orientation-of-the-flip-view"></a><span data-ttu-id="73dd4-158">フリップ ビューの向きの設定</span><span class="sxs-lookup"><span data-stu-id="73dd4-158">Set the orientation of the flip view</span></span>

<span data-ttu-id="73dd4-159">既定では、フリップ ビューは横方向にめくれます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-159">By default, the flip view flips horizontally.</span></span> <span data-ttu-id="73dd4-160">縦方向にめくれるようにするには、フリップ ビューの [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) として縦方向のスタック パネルを使います。</span><span class="sxs-lookup"><span data-stu-id="73dd4-160">To make the it flip vertically, use a stack panel with a vertical orientation as the flip view's [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx).</span></span>

<span data-ttu-id="73dd4-161">次の例は、FlipView の ItemsPanel として縦方向のスタック パネルを使う方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="73dd4-161">This example shows how to use a stack panel with a vertical orientation as the ItemsPanel of a FlipView.</span></span>

```XAML
<FlipView x:Name="flipViewVertical" Width="480" Height="270" 
          BorderBrush="Black" BorderThickness="1">
    
    <!-- Use a vertical stack panel for vertical flipping. -->
    <FlipView.ItemsPanel>
        <ItemsPanelTemplate>
            <VirtualizingStackPanel Orientation="Vertical"/>
        </ItemsPanelTemplate>
    </FlipView.ItemsPanel>
    
    <FlipView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Image Width="480" Height="270" Stretch="UniformToFill"
                       Source="{Binding Image}"/>
                <Border Background="#A5000000" Height="80" VerticalAlignment="Bottom">
                    <TextBlock Text="{Binding Name}" 
                               FontFamily="Segoe UI" FontSize="26.667" 
                               Foreground="#CCFFFFFF" Padding="15,20"/>
                </Border>
            </Grid>
        </DataTemplate>
    </FlipView.ItemTemplate>
</FlipView>
```

<span data-ttu-id="73dd4-162">縦方向のフリップ ビューは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-162">Here's what the flip view looks like with a vertical orientation.</span></span>

![垂直方向のフリップ ビューに関する例](images/controls_flipview_vertical.jpg)

## <a name="adding-a-context-indicator"></a><span data-ttu-id="73dd4-164">コンテキスト インジケーターの追加</span><span class="sxs-lookup"><span data-stu-id="73dd4-164">Adding a context indicator</span></span>

<span data-ttu-id="73dd4-165">フリップ ビュー内のコンテキスト インジケーターによって、便利な基準点を設けることができます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-165">A context indicator in a flip view provides a useful point of reference.</span></span> <span data-ttu-id="73dd4-166">標準的なコンテキスト インジケーターに含まれるドットは、対話型です。</span><span class="sxs-lookup"><span data-stu-id="73dd4-166">The dots in a standard context indicator aren't interactive.</span></span> <span data-ttu-id="73dd4-167">次の例に示されているように、最適な配置は、通常はギャラリーの下中央です。</span><span class="sxs-lookup"><span data-stu-id="73dd4-167">As seen in this example, the best placement is usually centered and below the gallery:</span></span>

![ページ インジケーターの例](images/controls_pageindicator.png)

<span data-ttu-id="73dd4-169">比較的大きなコレクション (10 ～ 25 個の項目) の場合、より多くのコンテキストを提供するインジケーター (縮小表示のフィルム ストリップなど) を使用することを検討します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-169">For larger collections (10-25 items), consider using an indicator that provides more context, such as a film strip of thumbnails.</span></span> <span data-ttu-id="73dd4-170">単純なドットを使用するコンテキスト インジケーターとは異なり、フィルム ストリップ内の各サムネイルは対応する画像の小さいバージョンであり、選択可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-170">Unlike a context indicator that uses simple dots, each thumbnail in the film strip shows a small version of the corresponding image and should be selectable:</span></span>

![コンテキスト インジケーターの例](images/controls_contextindicator.jpg)

<span data-ttu-id="73dd4-172">コンテキスト インジケーターを FlipView に追加する方法を示すサンプル コードについては、[XAML FlipView のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkID=311760)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73dd4-172">For example code that shows how to add a context indicator to a FlipView, see [XAML FlipView sample](http://go.microsoft.com/fwlink/p/?LinkID=311760).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="73dd4-173">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="73dd4-173">Do's and don'ts</span></span>

-   <span data-ttu-id="73dd4-174">FlipView は最大 25 個程度の項目のコレクションに最適です。</span><span class="sxs-lookup"><span data-stu-id="73dd4-174">Flip views work best for collections of up to 25 or so items.</span></span>
-   <span data-ttu-id="73dd4-175">大規模なコレクションでは FlipView コントロールを使わないでください。これは、項目ごとにフリップ操作を繰り返す必要があり、ユーザーの負担になるためです。</span><span class="sxs-lookup"><span data-stu-id="73dd4-175">Avoid using a flip view control for larger collections, as the repetitive motion of flipping through each item can be tedious.</span></span> <span data-ttu-id="73dd4-176">フォト アルバムは例外です。フォト アルバムには数百または数千の画像が含まれている場合があります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-176">An exception would be for photo albums, which often have hundreds or thousands of images.</span></span> <span data-ttu-id="73dd4-177">ほとんどの場合、フォト アルバムでは、グリッド ビューのレイアウトで写真を選ぶと、フリップ ビューに切り替わります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-177">Photo albums almost always switch to a flip view once a photo has been selected in the grid view layout.</span></span> <span data-ttu-id="73dd4-178">他の大きいコレクションについては、[リスト ビューまたはグリッド ビュー](lists.md)を検討してください。</span><span class="sxs-lookup"><span data-stu-id="73dd4-178">For other large collections, consider a [List view or grid view](lists.md).</span></span>
-   <span data-ttu-id="73dd4-179">コンテキスト インジケーターの場合:</span><span class="sxs-lookup"><span data-stu-id="73dd4-179">For context indicators:</span></span>
    -   <span data-ttu-id="73dd4-180">ドット (または選択した任意の視覚的マーカー) の順序は、中央に配置され、水平方向にパンするギャラリーの下にあるときに最適に動作します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-180">The order of dots (or whichever visual marker you choose) works best when centered and below a horizontally-panning gallery.</span></span>
    -   <span data-ttu-id="73dd4-181">垂直方向にパンするギャラリーでコンテキスト インジケーターを使う場合は、中央に配置され、画像の右側にあるときに最適な動作になります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-181">If you want a context indicator in a vertically-panning gallery, it works best centered and to the right of the images.</span></span>
    -   <span data-ttu-id="73dd4-182">強調表示されているドットは現在の項目を示します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-182">The highlighted dot indicates the current item.</span></span> <span data-ttu-id="73dd4-183">通常、強調表示されているドットは白で、その他のドットは灰色で表されます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-183">Usually the highlighted dot is white and the other dots are gray.</span></span>
    -   <span data-ttu-id="73dd4-184">ドットの数は変更できますが、多すぎるとユーザーは現在の場所を把握することが難しくなります。通常、表示するドットの最大数は 10 個です。</span><span class="sxs-lookup"><span data-stu-id="73dd4-184">The number of dots can vary, but don't have so many that the user might struggle to find his or her place - 10 dots is usually the maximum number to show.</span></span>

## <a name="globalization-and-localization-checklist"></a><span data-ttu-id="73dd4-185">グローバリゼーションとローカライズのチェックリスト</span><span class="sxs-lookup"><span data-stu-id="73dd4-185">Globalization and localization checklist</span></span>

<table>
<tr>
<th><span data-ttu-id="73dd4-186">双方向対応に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="73dd4-186">Bi-directional considerations</span></span></th><td><span data-ttu-id="73dd4-187">RTL 言語には標準の左右反転を使用します。</span><span class="sxs-lookup"><span data-stu-id="73dd4-187">Use standard mirroring for RTL languages.</span></span> <span data-ttu-id="73dd4-188">"戻る" と "進む" のコントロールは言語の方向に基づく必要があります。RTL 言語では、右ボタンが "戻る" で、左ボタンが "進む" となります。</span><span class="sxs-lookup"><span data-stu-id="73dd4-188">The back and forward controls should be based on the language's direction, so for RTL languages, the right button should navigate backwards and the left button should navigate forward.</span></span></td>
</tr>

</table>

## <a name="get-the-sample-code"></a><span data-ttu-id="73dd4-189">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="73dd4-189">Get the sample code</span></span>

- <span data-ttu-id="73dd4-190">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="73dd4-190">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="73dd4-191">関連記事</span><span class="sxs-lookup"><span data-stu-id="73dd4-191">Related articles</span></span>

- [<span data-ttu-id="73dd4-192">リストのガイドライン</span><span class="sxs-lookup"><span data-stu-id="73dd4-192">Guidelines for lists</span></span>](lists.md)
- [**<span data-ttu-id="73dd4-193">FlipView クラス</span><span class="sxs-lookup"><span data-stu-id="73dd4-193">FlipView class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242678)
