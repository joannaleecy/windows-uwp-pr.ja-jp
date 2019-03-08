---
Description: ListView と GridView コントロールを使用して、表示イメージのギャラリーや一連の電子メール メッセージなどのデータのセットを操作します。
title: リスト ビューとグリッド ビュー
label: List view and grid view
template: detail.hbs
ms.date: 05/20/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: f8532ba0-5510-4686-9fcf-87fd7c643e7b
pm-contact: predavid
design-contact: kimsea
dev-contact: ranjeshj
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4efbdaef0fbcbe076133be1c491f7ed173c01257
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653577"
---
# <a name="list-view-and-grid-view"></a><span data-ttu-id="194f7-104">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="194f7-104">List view and grid view</span></span>

<span data-ttu-id="194f7-105">ほとんどのアプリでは、イメージ ギャラリー、メール メッセージなどのデータのセットを操作および表示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-105">Most applications manipulate and display sets of data, such as a gallery of images or a set of email messages.</span></span> <span data-ttu-id="194f7-106">XAML UI フレームワークでは、アプリ内でデータを簡単に表示、操作するための ListView コントロールと GridView コントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="194f7-106">The XAML UI framework provides ListView and GridView controls that make it easy to display and manipulate data in your app.</span></span>  

> <span data-ttu-id="194f7-107">**重要な Api**:[ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、 [GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)、 [ItemsSource プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx)、[項目のプロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx)</span><span class="sxs-lookup"><span data-stu-id="194f7-107">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx), [ItemsSource property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx), [Items property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx)</span></span>

<span data-ttu-id="194f7-108">ListView と GridView はどちらも ListViewBase クラスから派生しているため、同じ機能を持ちますが、データの表示方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="194f7-108">ListView and GridView both derive from the ListViewBase class, so they have the same functionality, but display data differently.</span></span> <span data-ttu-id="194f7-109">この記事では、特に指定がない限り、ListView についての説明は ListView コントロールにも GridView コントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-109">In this article, when we talk about ListView, the info applies to both the ListView and GridView controls unless otherwise specified.</span></span> <span data-ttu-id="194f7-110">ListView や ListViewItem などのクラスの説明については、プレフィックスの "List" を "Grid" に置き換えることで、対応するグリッド クラス (GridView または GridViewItem) に適用できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-110">We may refer to classes like ListView or ListViewItem, but the “List” prefix can be replaced with “Grid” for the corresponding grid equivalent (GridView or GridViewItem).</span></span> 

## <a name="is-this-the-right-control"></a><span data-ttu-id="194f7-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="194f7-111">Is this the right control?</span></span>

<span data-ttu-id="194f7-112">ListView では、データを縦方向の 1 列に並べて表示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-112">The ListView displays data stacked vertically in a single column.</span></span> <span data-ttu-id="194f7-113">メールや検索結果の一覧など、順序が付けられた項目の一覧を表示するときによく使います。</span><span class="sxs-lookup"><span data-stu-id="194f7-113">It's often used to show an ordered list of items, such as a list of emails or search results.</span></span> 

![グループ化されたデータを表示するリスト ビュー](images/simple-list-view-phone.png)

<span data-ttu-id="194f7-115">GridView は、縦方向にスクロールできる複数行と複数列で項目のコレクションを表示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-115">The GridView presents a collection of items in rows and columns that can scroll vertically.</span></span> <span data-ttu-id="194f7-116">データはまず横方向に並べられ、すべての列にデータが入ると、次の行に折り返して並べられます。</span><span class="sxs-lookup"><span data-stu-id="194f7-116">Data is stacked horizontally until it fills the columns, then continues with the next row.</span></span> <span data-ttu-id="194f7-117">フォト ギャラリーのように、各項目の表示内容が豊富で表示領域を広く使う必要がある場合によく使います。</span><span class="sxs-lookup"><span data-stu-id="194f7-117">It's often used when you need to show a rich visualization of each item that takes more space, such as a photo gallery.</span></span> 

![コンテンツ ライブラリの例](images/controls_list_contentlibrary.png)

<span data-ttu-id="194f7-119">使用するコントロールを選ぶための詳しい比較とガイダンスについては、「[リスト](lists.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-119">For a more detailed comparison and guidance on which control to use, see [Lists](lists.md).</span></span>

## <a name="examples"></a><span data-ttu-id="194f7-120">例</span><span class="sxs-lookup"><span data-stu-id="194f7-120">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="194f7-121">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="194f7-121">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="194f7-122"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ListView">ListView</a> または <a href="xamlcontrolsgallery:/item/GridView">GridView</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="194f7-122">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ListView">ListView</a> or <a href="xamlcontrolsgallery:/item/GridView">GridView</a> in action.</span></span></p>
    <ul>
    <li><span data-ttu-id="194f7-123"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="194f7-123"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="194f7-124"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="194f7-124"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-list-view"></a><span data-ttu-id="194f7-125">リスト ビューの作成</span><span class="sxs-lookup"><span data-stu-id="194f7-125">Create a list view</span></span>

<span data-ttu-id="194f7-126">リスト ビューは [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-126">List view is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="194f7-127">リスト ビューを使って項目を表示するには、[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-127">It must have items in its [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection before it can show anything on the screen.</span></span> <span data-ttu-id="194f7-128">ビューのデータを設定するには、項目を直接 [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに追加するか、データ ソースに [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-128">To populate the view, you can add items directly to the [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection, or set the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span> 

<span data-ttu-id="194f7-129">**重要**&nbsp;&nbsp;リストにデータを設定するときには Items または ItemsSource を使用しますが、同時に両方を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="194f7-129">**Important**&nbsp;&nbsp;You can use either Items or ItemsSource to populate the list, but you can't use both at the same time.</span></span> <span data-ttu-id="194f7-130">ItemsSource プロパティを設定して XAML で項目を追加した場合、追加された項目は無視されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-130">If you set the ItemsSource property and you add an item in XAML, the added item is ignored.</span></span> <span data-ttu-id="194f7-131">ItemsSource プロパティを設定してコードで Items コレクションに項目を追加した場合、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="194f7-131">If you set the ItemsSource property and you add an item to the Items collection in code, an exception is thrown.</span></span>

> <span data-ttu-id="194f7-132">**注**&nbsp;&nbsp;この記事の例の多くでは、説明を簡単にするために **Items** コレクションを直接設定しています。</span><span class="sxs-lookup"><span data-stu-id="194f7-132">**Note**&nbsp;&nbsp;Many of the examples in this article populate the **Items** collection directly for the sake of simplicity.</span></span> <span data-ttu-id="194f7-133">ただし、リストの項目は、オンライン データベースの書籍一覧など、動的なソースから取得される方が一般的です。</span><span class="sxs-lookup"><span data-stu-id="194f7-133">However, it's more common for the items in a list to come from a dynamic source, like a list of books from an online database.</span></span> <span data-ttu-id="194f7-134">このようなケースでは、**ItemsSource** プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="194f7-134">You use the **ItemsSource** property for this purpose.</span></span> 

### <a name="add-items-to-the-items-collection"></a><span data-ttu-id="194f7-135">Items コレクションへの項目の追加</span><span class="sxs-lookup"><span data-stu-id="194f7-135">Add items to the Items collection</span></span>

<span data-ttu-id="194f7-136">[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加するには、XAML かコードを使います。</span><span class="sxs-lookup"><span data-stu-id="194f7-136">You can add items to the [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection using XAML or code.</span></span> <span data-ttu-id="194f7-137">通常、項目が少数で、その項目が変わらず、XAML で簡単に定義できる場合や、実行時にコードで項目を生成する場合は、この方法で項目を追加します。</span><span class="sxs-lookup"><span data-stu-id="194f7-137">You typically add items this way if you have a small number of items that don't change and are easily defined in XAML, or if you generate the items in code at run time.</span></span> 

<span data-ttu-id="194f7-138">XAML で項目をインラインで定義したリスト ビューを次に示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-138">Here's a list view with items defined inline in XAML.</span></span> <span data-ttu-id="194f7-139">XAML で項目を定義すると、定義した項目は Items コレクションに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-139">When you define the items in XAML, they are automatically added to the Items collection.</span></span>

<span data-ttu-id="194f7-140">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-140">**XAML**</span></span>
```xaml
<ListView x:Name="listView1"> 
   <x:String>Item 1</x:String> 
   <x:String>Item 2</x:String> 
   <x:String>Item 3</x:String> 
   <x:String>Item 4</x:String> 
   <x:String>Item 5</x:String> 
</ListView>  
```

<span data-ttu-id="194f7-141">作成したリスト ビューのコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-141">Here's the list view created in code.</span></span> <span data-ttu-id="194f7-142">生成されるリストは、XAML で作ったものと同じです。</span><span class="sxs-lookup"><span data-stu-id="194f7-142">The resulting list is the same as the one created previously in XAML.</span></span>

<span data-ttu-id="194f7-143">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-143">**C#**</span></span>
```csharp
// Create a new ListView and add content. 
ListView listView1 = new ListView(); 
listView1.Items.Add("Item 1"); 
listView1.Items.Add("Item 2"); 
listView1.Items.Add("Item 3"); 
listView1.Items.Add("Item 4"); 
listView1.Items.Add("Item 5");
 
// Add the ListView to a parent container in the visual tree. 
stackPanel1.Children.Add(listView1); 
```

<span data-ttu-id="194f7-144">ListView は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="194f7-144">The ListView looks like this.</span></span>

![単純なリスト ビュー](images/listview-simple.png)

### <a name="set-the-items-source"></a><span data-ttu-id="194f7-146">項目ソースの設定</span><span class="sxs-lookup"><span data-stu-id="194f7-146">Set the items source</span></span>

<span data-ttu-id="194f7-147">通常、リスト ビューを使って、データベースやインターネットなどのソースからデータを表示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-147">You typically use a list view to display data from a source such as a database or the Internet.</span></span> <span data-ttu-id="194f7-148">データ ソースからリスト ビューのデータを設定するには、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ項目のコレクションに設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-148">To populate a list view from a data source, you set its [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a collection of data items.</span></span>

<span data-ttu-id="194f7-149">以下の例では、コードでコレクションのインスタンスに直接リスト ビューの ItemsSource を設定しています。</span><span class="sxs-lookup"><span data-stu-id="194f7-149">Here, the list view's ItemsSource is set in code directly to an instance of a collection.</span></span>

<span data-ttu-id="194f7-150">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-150">**C#**</span></span>
```csharp 
// Instead of hard coded items, the data could be pulled 
// asynchronously from a database or the internet.
ObservableCollection<string> listItems = new ObservableCollection<string>();
listItems.Add("Item 1");
listItems.Add("Item 2");
listItems.Add("Item 3");
listItems.Add("Item 4");
listItems.Add("Item 5");

// Create a new list view, add content, 
ListView itemListView = new ListView();
itemListView.ItemsSource = listItems;

// Add the list view to a parent container in the visual tree.
stackPanel1.Children.Add(itemListView);
```

<span data-ttu-id="194f7-151">ItemsSource プロパティを、XAML でコレクションにバインドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="194f7-151">You can also bind the ItemsSource property to a collection in XAML.</span></span> <span data-ttu-id="194f7-152">データ バインディングについて詳しくは、「[データ バインディングの概要](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-152">For more info about data binding, see [Data binding overview](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart).</span></span>

<span data-ttu-id="194f7-153">ここでは、ページのプライベート データ コレクションを公開する `Items` という名前のパブリック プロパティに ItemsSource をバインドします。</span><span class="sxs-lookup"><span data-stu-id="194f7-153">Here, the ItemsSource is bound to a public property named `Items` that exposes the Page's private data collection.</span></span>

<span data-ttu-id="194f7-154">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-154">**XAML**</span></span>
```xaml
<ListView x:Name="itemListView" ItemsSource="{x:Bind Items}"/>
```

<span data-ttu-id="194f7-155">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-155">**C#**</span></span>
```csharp
private ObservableCollection<string> _items = new ObservableCollection<string>();

public ObservableCollection<string> Items
{
    get { return this._items; }
}

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    // Instead of hard coded items, the data could be pulled 
    // asynchronously from a database or the internet.
    Items.Add("Item 1");
    Items.Add("Item 2");
    Items.Add("Item 3");
    Items.Add("Item 4");
    Items.Add("Item 5");
}
```

<span data-ttu-id="194f7-156">リスト ビューにグループ化されたデータを表示する必要がある場合、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) にバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-156">If you need to show grouped data in your list view, you must bind to a [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span> <span data-ttu-id="194f7-157">CollectionViewSource は XAML のコレクション クラスのプロキシとして機能し、グループ化サポートを有効にします。</span><span class="sxs-lookup"><span data-stu-id="194f7-157">The CollectionViewSource acts as a proxy for the collection class in XAML and enables grouping support.</span></span> <span data-ttu-id="194f7-158">詳しくは、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-158">For more info, see [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span>

## <a name="data-template"></a><span data-ttu-id="194f7-159">データ テンプレート</span><span class="sxs-lookup"><span data-stu-id="194f7-159">Data template</span></span>

<span data-ttu-id="194f7-160">項目のデータ テンプレートによって、データの表示方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="194f7-160">An item’s data template defines how the data is visualized.</span></span> <span data-ttu-id="194f7-161">既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてリスト ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-161">By default, a data item is displayed in the list view as the string representation of the data object it's bound to.</span></span> <span data-ttu-id="194f7-162">データ項目の特定のプロパティに [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) を設定すると、そのプロパティの文字列表現を表示できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-162">You can show the string representation of a particular property of the data item by setting the [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) to that property.</span></span>

<span data-ttu-id="194f7-163">しかし、通常はもっとリッチな表現でデータを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-163">However, you typically want to show a more rich presentation of your data.</span></span> <span data-ttu-id="194f7-164">リスト ビューでの項目の表示方法を正確に指定するには、[DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="194f7-164">To specify exactly how items in the list view are displayed, you create a [DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx).</span></span> <span data-ttu-id="194f7-165">DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="194f7-165">The XAML in the DataTemplate defines the layout and appearance of controls used to display an individual item.</span></span> <span data-ttu-id="194f7-166">レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="194f7-166">The controls in the layout can be bound to properties of a data object, or have static content defined inline.</span></span> <span data-ttu-id="194f7-167">DataTemplate は、リスト コントロールの [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="194f7-167">You assign the DataTemplate to the [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the list control.</span></span>

<span data-ttu-id="194f7-168">この例では、データ項目は単純な文字列です。</span><span class="sxs-lookup"><span data-stu-id="194f7-168">In this example, the data item is a simple string.</span></span> <span data-ttu-id="194f7-169">DataTemplate を使って、文字列の左側に画像を追加し、文字列を青緑で表示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-169">You use a DataTemplate to add an image to the left of the string, and show the string in teal.</span></span>

> <span data-ttu-id="194f7-170">**注**&nbsp;&nbsp;DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使用する場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-170">**Note**&nbsp;&nbsp;When you use the [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) in a DataTemplate, you have to specify the DataType (`x:DataType`) on the DataTemplate.</span></span>

<span data-ttu-id="194f7-171">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-171">**XAML**</span></span>
```XAML
<ListView x:Name="listView1">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="x:String">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="47"/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Image Source="Assets/placeholder.png" Width="32" Height="32" 
                       HorizontalAlignment="Left"/>
                <TextBlock Text="{x:Bind}" Foreground="Teal" 
                           FontSize="15" Grid.Column="1"/>
            </Grid> 
        </DataTemplate>
    </ListView.ItemTemplate>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```

<span data-ttu-id="194f7-172">このデータ テンプレートを使ってデータ項目を表示すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="194f7-172">Here's what the data items look like when displayed with this data template.</span></span>

![データ テンプレートを使ったリスト ビュー項目](images/listview-itemstemplate.png)

<span data-ttu-id="194f7-174">データ テンプレートは、リスト ビューの外観を定義する主要な方法です。</span><span class="sxs-lookup"><span data-stu-id="194f7-174">Data templates are the primary way you define the look of your list view.</span></span> <span data-ttu-id="194f7-175">リストに多数の項目を表示した場合、パフォーマンスが大幅に低下することもあります。</span><span class="sxs-lookup"><span data-stu-id="194f7-175">They can also have a significant impact on performance if your list displays a large number of items.</span></span> <span data-ttu-id="194f7-176">この記事では、ほとんどの例で単純な文字列データを使用しており、データ テンプレートを指定していません。</span><span class="sxs-lookup"><span data-stu-id="194f7-176">In this article, we use simple string data for most of the examples, and don't specify a data template.</span></span> <span data-ttu-id="194f7-177">データ テンプレートと項目コンテナーを使用してリストまたはグリッドの項目の外観を定義する詳しい方法とその例については、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-177">For more info and examples of how to use data templates and item containers to define the look of items in your list or grid, see [Item containers and templates](item-containers-templates.md).</span></span> 

## <a name="change-the-layout-of-items"></a><span data-ttu-id="194f7-178">項目のレイアウト変更</span><span class="sxs-lookup"><span data-stu-id="194f7-178">Change the layout of items</span></span>

<span data-ttu-id="194f7-179">リスト ビューまたはグリッド ビューに項目を追加すると、項目コンテナー内で各項目が自動的に折り返され、すべての項目コンテナーがレイアウトされます。</span><span class="sxs-lookup"><span data-stu-id="194f7-179">When you add items to a list view or grid view, the control automatically wraps each item in an item container and then lays out all of the item containers.</span></span> <span data-ttu-id="194f7-180">この項目コンテナーのレイアウト方法は、コントロールの [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) によって決まります。</span><span class="sxs-lookup"><span data-stu-id="194f7-180">How these item containers are laid out depends on the [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) of the control.</span></span>  
- <span data-ttu-id="194f7-181">**ListView** では既定で [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) が使用され、次のような縦 1 列のリストが生成されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-181">By default, **ListView** uses an [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx), which produces a vertical list, like this.</span></span>

![単純なリスト ビュー](images/listview-simple.png)

- <span data-ttu-id="194f7-183">**GridView** では [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) が使用されます。次のように、項目が水平方向に追加され、折り返されて縦方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="194f7-183">**GridView** uses an [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx), which adds items horizontally, and wraps and scrolls vertically, like this.</span></span>

![単純なグリッド ビュー](images/gridview-simple.png)

<span data-ttu-id="194f7-185">項目のレイアウトを変更するには、項目パネルのプロパティを調整するか、既定のパネルを別のパネルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="194f7-185">You can modify the layout of items by adjusting properties on the items panel, or you can replace the default panel with another panel.</span></span>

> <span data-ttu-id="194f7-186">注&nbsp;&nbsp;ItemsPanel を変更する場合、仮想化を無効にしないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="194f7-186">Note&nbsp;&nbsp;Be careful to not disable virtualization if you change the ItemsPanel.</span></span> <span data-ttu-id="194f7-187">**ItemsStackPanel** と **ItemsWrapGrid** はどちらも仮想化をサポートしており、安全に使用できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-187">Both **ItemsStackPanel** and **ItemsWrapGrid** support virtualization, so these are safe to use.</span></span> <span data-ttu-id="194f7-188">他のパネルを使用すると、仮想化が無効になり、リスト ビューのパフォーマンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-188">If you use any other panel, you might disable virtualization and slow the performance of the list view.</span></span> <span data-ttu-id="194f7-189">詳しくは、「[Performance (パフォーマンス)](https://msdn.microsoft.com/windows/uwp/debug-test-perf/performance-and-xaml-ui)」のリスト ビューに関する記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-189">For more info, see the list view articles under [Performance](https://msdn.microsoft.com/windows/uwp/debug-test-perf/performance-and-xaml-ui).</span></span> 

<span data-ttu-id="194f7-190">この例では、**ItemsStackPanel** の [Orientation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.orientation.aspx) プロパティを変更することで、**ListView** に項目コンテナーを横 1 列にレイアウトする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="194f7-190">This example shows how to make a **ListView** lay out its item containers in a horizontal list by changing the [Orientation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.orientation.aspx) property of the **ItemsStackPanel**.</span></span>
<span data-ttu-id="194f7-191">リスト ビューは既定で縦方向にスクロールするため、横方向にスクロールさせるには、リスト ビュー内部の [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) のプロパティもいくつか調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-191">Because the list view scrolls vertically by default, you also need to adjust some properties on the list view’s internal [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) to make it scroll horizontally.</span></span>
- <span data-ttu-id="194f7-192">[ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx) を **Enabled** または **Auto** に設定</span><span class="sxs-lookup"><span data-stu-id="194f7-192">[ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx) to **Enabled** or **Auto**</span></span>
- <span data-ttu-id="194f7-193">[ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx) を **Auto** に設定</span><span class="sxs-lookup"><span data-stu-id="194f7-193">[ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx) to **Auto**</span></span> 
- <span data-ttu-id="194f7-194">[ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx) を **Disabled** に設定</span><span class="sxs-lookup"><span data-stu-id="194f7-194">[ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx) to **Disabled**</span></span> 
- <span data-ttu-id="194f7-195">[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) を **Hidden** に設定</span><span class="sxs-lookup"><span data-stu-id="194f7-195">[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) to **Hidden**</span></span> 

> <span data-ttu-id="194f7-196">**注**&nbsp;&nbsp;ここに示す例ではリスト ビューの幅が規定されていないため、水平スクロール バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="194f7-196">**Note**&nbsp;&nbsp;These examples are shown with the list view width unconstrained, so the horizontal scrollbars are not shown.</span></span> <span data-ttu-id="194f7-197">このコードを実行する場合、ListView に `Width="180"` を設定してスクロール バーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-197">If you run this code, you can set `Width="180"` on the ListView to make the scrollbars show.</span></span>

<span data-ttu-id="194f7-198">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-198">**XAML**</span></span>
```xaml
<ListView Height="60" 
          ScrollViewer.HorizontalScrollMode="Enabled" 
          ScrollViewer.HorizontalScrollBarVisibility="Auto"
          ScrollViewer.VerticalScrollMode="Disabled"
          ScrollViewer.VerticalScrollBarVisibility="Hidden">
    <ListView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsStackPanel Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </ListView.ItemsPanel>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```

<span data-ttu-id="194f7-199">このリストは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-199">The resulting list looks like this.</span></span>

![横長のリスト ビュー](images/listview-horizontal.png)

 <span data-ttu-id="194f7-201">次の例の **ListView** では、**ItemsStackPanel** ではなく **ItemsWrapGrid** を使用して、縦方向に折り返すリストで項目をレイアウトします。</span><span class="sxs-lookup"><span data-stu-id="194f7-201">In the next example, the **ListView** lays out items in a vertical wrapping list by using an **ItemsWrapGrid** instead of an **ItemsStackPanel**.</span></span> 
 
> <span data-ttu-id="194f7-202">**注**&nbsp;&nbsp;コントロールでコンテナーを折り返すには、リスト ビューの高さを規定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-202">**Note**&nbsp;&nbsp;The height of the list view must be constrained to force the control to wrap the containers.</span></span>

<span data-ttu-id="194f7-203">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-203">**XAML**</span></span>
```xaml
<ListView Height="100"
          ScrollViewer.HorizontalScrollMode="Enabled" 
          ScrollViewer.HorizontalScrollBarVisibility="Auto"
          ScrollViewer.VerticalScrollMode="Disabled"
          ScrollViewer.VerticalScrollBarVisibility="Hidden">
    <ListView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid/>
        </ItemsPanelTemplate>
    </ListView.ItemsPanel>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```

<span data-ttu-id="194f7-204">このリストは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-204">The resulting list looks like this.</span></span>

![グリッド レイアウトを使ったリスト ビュー](images/listview-itemswrapgrid.png)

<span data-ttu-id="194f7-206">グループ化したデータをリスト ビューに表示する場合、ItemsPanel によって指定されるのは個々の項目のレイアウト方法ではなく、項目グループのレイアウト方法です。たとえば、前に示した横方向の ItemsStackPanel を使用して、グループ化されたデータを表示する場合、次に示すようにグループは横方向に配置されますが、各グループの項目は縦に重ねて表示されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-206">If you show grouped data in your list view, the ItemsPanel determines how the item groups are layed out, not how the individual items are layed out. For example, if the horizontal ItemsStackPanel shown previously is used to show grouped data, the groups are arranged horizontally, but the items in each group are still stacked vertically, as shown here.</span></span>

![グループ化された横方向のリスト ビュー](images/listview-horizontal-groups.png)

## <a name="item-selection-and-interaction"></a><span data-ttu-id="194f7-208">項目の選択と操作</span><span class="sxs-lookup"><span data-stu-id="194f7-208">Item selection and interaction</span></span>

<span data-ttu-id="194f7-209">ユーザーがリスト ビューを操作する方法は、いくつか選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-209">You can choose from various ways to let a user interact with a list view.</span></span> <span data-ttu-id="194f7-210">既定では、ユーザーは 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-210">By default, a user can select a single item.</span></span> <span data-ttu-id="194f7-211">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) プロパティを変更することで、複数選択を有効にしたり、選択を無効にしたりできます。</span><span class="sxs-lookup"><span data-stu-id="194f7-211">You can change the [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) property to enable multi-selection or to disable selection.</span></span> <span data-ttu-id="194f7-212">[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) プロパティを設定することで、ユーザーが項目をクリックしたときに項目を選択するのではなく、ボタンと同じように操作を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-212">You can set the [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) property so that a user clicks an item to invoke an action (like a button) instead of selecting the item.</span></span>

> <span data-ttu-id="194f7-213">**注**&nbsp;&nbsp; ListView と GridView のどちらも、SelectionMode プロパティについては [ListViewSelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewselectionmode.aspx) 列挙値を使用します。</span><span class="sxs-lookup"><span data-stu-id="194f7-213">**Note**&nbsp;&nbsp;Both ListView and GridView use the [ListViewSelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewselectionmode.aspx) enumeration for their SelectionMode properties.</span></span> <span data-ttu-id="194f7-214">IsItemClickEnabled は既定で **False** であるため、設定する必要があるのはクリック モードを有効にする場合のみです。</span><span class="sxs-lookup"><span data-stu-id="194f7-214">IsItemClickEnabled is **False** by default, so you need to set it only to enable click mode.</span></span>

<span data-ttu-id="194f7-215">次の表に、ユーザーがリスト ビューを操作する方法と、その操作に対する応答方法を示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-215">This table shows the ways a user can interact with a list view, and how you can respond to the interaction.</span></span>

<span data-ttu-id="194f7-216">有効にする操作:</span><span class="sxs-lookup"><span data-stu-id="194f7-216">To enable this interaction:</span></span> | <span data-ttu-id="194f7-217">使用する設定:</span><span class="sxs-lookup"><span data-stu-id="194f7-217">Use these settings:</span></span> | <span data-ttu-id="194f7-218">処理するイベント:</span><span class="sxs-lookup"><span data-stu-id="194f7-218">Handle this event:</span></span> | <span data-ttu-id="194f7-219">選択された項目の取得に使うプロパティ:</span><span class="sxs-lookup"><span data-stu-id="194f7-219">Use this property to get the selected item:</span></span>
----------------------------|---------------------|--------------------|--------------------------------------------
<span data-ttu-id="194f7-220">操作なし</span><span class="sxs-lookup"><span data-stu-id="194f7-220">No interaction</span></span> | <span data-ttu-id="194f7-221">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) = **None**、[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) = **False**</span><span class="sxs-lookup"><span data-stu-id="194f7-221">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) = **None**, [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) = **False**</span></span> | <span data-ttu-id="194f7-222">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-222">N/A</span></span> | <span data-ttu-id="194f7-223">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-223">N/A</span></span> 
<span data-ttu-id="194f7-224">単一選択</span><span class="sxs-lookup"><span data-stu-id="194f7-224">Single selection</span></span> | <span data-ttu-id="194f7-225">SelectionMode = **Single**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="194f7-225">SelectionMode = **Single**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="194f7-226">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="194f7-226">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | <span data-ttu-id="194f7-227">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx)、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx)</span><span class="sxs-lookup"><span data-stu-id="194f7-227">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx), [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx)</span></span>  
<span data-ttu-id="194f7-228">複数選択</span><span class="sxs-lookup"><span data-stu-id="194f7-228">Multiple selection</span></span> | <span data-ttu-id="194f7-229">SelectionMode = **Multiple**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="194f7-229">SelectionMode = **Multiple**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="194f7-230">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="194f7-230">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [<span data-ttu-id="194f7-231">SelectedItems</span><span class="sxs-lookup"><span data-stu-id="194f7-231">SelectedItems</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
<span data-ttu-id="194f7-232">拡張選択</span><span class="sxs-lookup"><span data-stu-id="194f7-232">Extended selection</span></span> | <span data-ttu-id="194f7-233">SelectionMode = **Extended**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="194f7-233">SelectionMode = **Extended**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="194f7-234">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="194f7-234">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [<span data-ttu-id="194f7-235">SelectedItems</span><span class="sxs-lookup"><span data-stu-id="194f7-235">SelectedItems</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
<span data-ttu-id="194f7-236">Click</span><span class="sxs-lookup"><span data-stu-id="194f7-236">Click</span></span> | <span data-ttu-id="194f7-237">SelectionMode = **None**、IsItemClickEnabled = **True**</span><span class="sxs-lookup"><span data-stu-id="194f7-237">SelectionMode = **None**, IsItemClickEnabled = **True**</span></span> | [<span data-ttu-id="194f7-238">ItemClick</span><span class="sxs-lookup"><span data-stu-id="194f7-238">ItemClick</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.itemclick.aspx) | <span data-ttu-id="194f7-239">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-239">N/A</span></span> 

> <span data-ttu-id="194f7-240">**注**&nbsp;&nbsp;Windows 10 以降では、IsItemClickEnabled を有効にして ItemClick イベントを発生させる場合でも、SelectionMode を Single、Multiple、Extended のいずれにも設定できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-240">**Note**&nbsp;&nbsp;Starting in Windows 10, you can enable IsItemClickEnabled to raise an ItemClick event while SelectionMode is also set to Single, Multiple, or Extended.</span></span> <span data-ttu-id="194f7-241">その場合、ItemClick イベントが最初に発生し、次に SelectionChanged イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="194f7-241">If you do this, the ItemClick event is raised first, and then the SelectionChanged event is raised.</span></span> <span data-ttu-id="194f7-242">ただし ItemClick イベント ハンドラーで別のページに移動するような場合では、SelectionChanged イベントが発生せず、項目が選択されません。</span><span class="sxs-lookup"><span data-stu-id="194f7-242">In some cases, like if you navigate to another page in the ItemClick event handler, the SelectionChanged event is not raised and the item is not selected.</span></span>

<span data-ttu-id="194f7-243">次に示すように、このプロパティを XAML またはコードで設定することができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-243">You can set these properties in XAML or in code, as shown here.</span></span>

<span data-ttu-id="194f7-244">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-244">**XAML**</span></span>
```xaml
<ListView x:Name="myListView" SelectionMode="Multiple"/>

<GridView x:Name="myGridView" SelectionMode="None" IsItemClickEnabled="True"/> 
```

<span data-ttu-id="194f7-245">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-245">**C#**</span></span>
```csharp
myListView.SelectionMode = ListViewSelectionMode.Multiple; 

myGridView.SelectionMode = ListViewSelectionMode.None;
myGridView.IsItemClickEnabled = true;
```

### <a name="read-only"></a><span data-ttu-id="194f7-246">読み取り専用かどうか</span><span class="sxs-lookup"><span data-stu-id="194f7-246">Read-only</span></span>

<span data-ttu-id="194f7-247">SelectionMode プロパティを **ListViewSelectionMode.None** に設定することで、項目の選択を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-247">You can set the SelectionMode property to **ListViewSelectionMode.None** to disable item selection.</span></span> <span data-ttu-id="194f7-248">これによりコントロールが読み取り専用モードになり、ユーザーの操作には使われず、データの表示のみに使われます。</span><span class="sxs-lookup"><span data-stu-id="194f7-248">This puts the control in read only mode, to be used for displaying data, but not for interacting with it.</span></span> <span data-ttu-id="194f7-249">コントロール自体は無効にならず、項目の選択のみが無効になります。</span><span class="sxs-lookup"><span data-stu-id="194f7-249">The control itself is not disabled, only item selection is disabled.</span></span>

### <a name="single-selection"></a><span data-ttu-id="194f7-250">単一選択</span><span class="sxs-lookup"><span data-stu-id="194f7-250">Single selection</span></span>

<span data-ttu-id="194f7-251">次の表では、SelectionMode が **Single** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="194f7-251">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Single**.</span></span>

<span data-ttu-id="194f7-252">修飾キー</span><span class="sxs-lookup"><span data-stu-id="194f7-252">Modifier key</span></span> | <span data-ttu-id="194f7-253">操作</span><span class="sxs-lookup"><span data-stu-id="194f7-253">Interaction</span></span>
-------------|------------
<span data-ttu-id="194f7-254">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-254">None</span></span> | <li><span data-ttu-id="194f7-255">ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-255">A user can select a single item using the space bar, mouse click, or touch tap.</span></span></li>
<span data-ttu-id="194f7-256">Ctrl</span><span class="sxs-lookup"><span data-stu-id="194f7-256">Ctrl</span></span> | <li><span data-ttu-id="194f7-257">ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目の選択を解除できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-257">A user can deselect a single item using the space bar, mouse click, or touch tap.</span></span></li><li><span data-ttu-id="194f7-258">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-258">Using the arrow keys, a user can move focus independently of selection.</span></span></li>

<span data-ttu-id="194f7-259">SelectionMode が **Single** の場合、[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx) プロパティから選択したデータ項目を取得できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-259">When SelectionMode is **Single**, you can get the selected data item from the [SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx) property.</span></span> <span data-ttu-id="194f7-260">[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx) プロパティを使って、選択した項目のコレクション内のインデックスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-260">You can get the index in the collection of the selected item using the [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx) property.</span></span> <span data-ttu-id="194f7-261">項目が選択されていない場合、SelectedItem は **null** になり、SelectedIndex は -1 になります。</span><span class="sxs-lookup"><span data-stu-id="194f7-261">If no item is selected, SelectedItem is **null**, and SelectedIndex is -1.</span></span> 
 
<span data-ttu-id="194f7-262">**Items** コレクションに含まれない項目を **SelectedItem** として設定しようとすると、その操作は無視され、SelectedItem が **null** になります。</span><span class="sxs-lookup"><span data-stu-id="194f7-262">If you try to set an item that is not in the **Items** collection as the **SelectedItem**, the operation is ignored and SelectedItem is**null**.</span></span> <span data-ttu-id="194f7-263">ただし、リスト内の **Items** の範囲外のインデックスを **SelectedIndex** に設定しようとすると、**System.ArgumentException** 例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="194f7-263">However, if you try to set the **SelectedIndex** to an index that's out of the range of the **Items** in the list, a **System.ArgumentException** exception occurs.</span></span> 

### <a name="multiple-selection"></a><span data-ttu-id="194f7-264">複数選択</span><span class="sxs-lookup"><span data-stu-id="194f7-264">Multiple selection</span></span>

<span data-ttu-id="194f7-265">次の表では、SelectionMode が **Multiple** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="194f7-265">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Multiple**.</span></span>

<span data-ttu-id="194f7-266">修飾キー</span><span class="sxs-lookup"><span data-stu-id="194f7-266">Modifier key</span></span> | <span data-ttu-id="194f7-267">操作</span><span class="sxs-lookup"><span data-stu-id="194f7-267">Interaction</span></span>
-------------|------------
<span data-ttu-id="194f7-268">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-268">None</span></span> | <li><span data-ttu-id="194f7-269">ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-269">A user can select multiple items using the space bar, mouse click, or touch tap to toggle selection on the focused item.</span></span></li><li><span data-ttu-id="194f7-270">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-270">Using the arrow keys, a user can move focus independently of selection.</span></span></li>
<span data-ttu-id="194f7-271">Shift</span><span class="sxs-lookup"><span data-stu-id="194f7-271">Shift</span></span> | <li><span data-ttu-id="194f7-272">ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-272">A user can select multiple contiguous items by clicking or tapping the first item in the selection and then the last item in the selection.</span></span></li><li><span data-ttu-id="194f7-273">方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-273">Using the arrow keys, a user can create a contiguous selection starting with the item selected when Shift is pressed.</span></span></li>

### <a name="extended-selection"></a><span data-ttu-id="194f7-274">拡張選択</span><span class="sxs-lookup"><span data-stu-id="194f7-274">Extended selection</span></span>

<span data-ttu-id="194f7-275">次の表では、SelectionMode が **Extended** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="194f7-275">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Extended**.</span></span>

<span data-ttu-id="194f7-276">修飾キー</span><span class="sxs-lookup"><span data-stu-id="194f7-276">Modifier key</span></span> | <span data-ttu-id="194f7-277">操作</span><span class="sxs-lookup"><span data-stu-id="194f7-277">Interaction</span></span>
-------------|------------
<span data-ttu-id="194f7-278">なし</span><span class="sxs-lookup"><span data-stu-id="194f7-278">None</span></span> | <li><span data-ttu-id="194f7-279">**Single** の選択と同じです。</span><span class="sxs-lookup"><span data-stu-id="194f7-279">The behavior is the same as **Single** selection.</span></span></li>
<span data-ttu-id="194f7-280">Ctrl</span><span class="sxs-lookup"><span data-stu-id="194f7-280">Ctrl</span></span> | <li><span data-ttu-id="194f7-281">ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-281">A user can select multiple items using the space bar, mouse click, or touch tap to toggle selection on the focused item.</span></span></li><li><span data-ttu-id="194f7-282">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-282">Using the arrow keys, a user can move focus independently of selection.</span></span></li>
<span data-ttu-id="194f7-283">Shift</span><span class="sxs-lookup"><span data-stu-id="194f7-283">Shift</span></span> | <li><span data-ttu-id="194f7-284">ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-284">A user can select multiple contiguous items by clicking or tapping the first item in the selection and then the last item in the selection.</span></span></li><li><span data-ttu-id="194f7-285">方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-285">Using the arrow keys, a user can create a contiguous selection starting with the item selected when Shift is pressed.</span></span></li>

<span data-ttu-id="194f7-286">SelectionMode が **Multiple** または **Extended** の場合、選択したデータ項目を [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx) プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-286">When SelectionMode is **Multiple** or **Extended**, you can get the selected data items from the [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx) property.</span></span> 

<span data-ttu-id="194f7-287">**SelectedIndex**、**SelectedItem**、**SelectedItems** の各プロパティは同期されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-287">The **SelectedIndex**, **SelectedItem**, and **SelectedItems** properties are synchronized.</span></span> <span data-ttu-id="194f7-288">たとえば、SelectedIndex を -1 に設定すると、SelectedItem は **null** に設定され、SelectedItems が空になります。SelectedItem を **null** に設定すると、SelectedIndex が -1 に設定され、SelectedItems が空になります。</span><span class="sxs-lookup"><span data-stu-id="194f7-288">For example, if you set SelectedIndex to -1, SelectedItem is set to **null** and SelectedItems is empty; if you set SelectedItem to **null**, SelectedIndex is set to -1 and SelectedItems is empty.</span></span>

<span data-ttu-id="194f7-289">複数選択モードの場合、**SelectedItem** には最初に選択された項目が含まれ、**Selectedindex** には最初に選択した項目のインデックスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="194f7-289">In multi-select mode, **SelectedItem** contains the item that was selected first, and **Selectedindex** contains the index of the item that was selected first.</span></span> 

### <a name="respond-to-selection-changes"></a><span data-ttu-id="194f7-290">選択範囲の変更への対応</span><span class="sxs-lookup"><span data-stu-id="194f7-290">Respond to selection changes</span></span>

<span data-ttu-id="194f7-291">リスト ビューにおける選択内容の変更に対応するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="194f7-291">To respond to selection changes in a list view, handle the [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) event.</span></span> <span data-ttu-id="194f7-292">イベント ハンドラーのコードでは、[SelectionChangedEventArgs.AddedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.addeditems.aspx) プロパティから選ばれた項目の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-292">In the event handler code, you can get the list of selected items from the [SelectionChangedEventArgs.AddedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.addeditems.aspx) property.</span></span> <span data-ttu-id="194f7-293">選択が解除された項目は、[SelectionChangedEventArgs.RemovedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.removeditems.aspx) プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-293">You can get any items that were deselected from the [SelectionChangedEventArgs.RemovedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.removeditems.aspx) property.</span></span> <span data-ttu-id="194f7-294">ユーザーが Shift キーを押しながら一連の項目を選択しない限り、AddedItems コレクションと RemovedItems コレクションに含まれる項目の数は 1 個までになります。</span><span class="sxs-lookup"><span data-stu-id="194f7-294">The AddedItems and RemovedItems collections contain at most 1 item unless the user selects a range of items by holding down the Shift key.</span></span>

<span data-ttu-id="194f7-295">次の例では、**SelectionChanged** イベントを処理してさまざまな項目コレクションにアクセスする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-295">This example shows how to handle the **SelectionChanged** event and access the various items collections.</span></span>

<span data-ttu-id="194f7-296">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-296">**XAML**</span></span>
```xaml
<StackPanel HorizontalAlignment="Right">
    <ListView x:Name="listView1" SelectionMode="Multiple" 
              SelectionChanged="ListView1_SelectionChanged">
        <x:String>Item 1</x:String>
        <x:String>Item 2</x:String>
        <x:String>Item 3</x:String>
        <x:String>Item 4</x:String>
        <x:String>Item 5</x:String>
    </ListView>
    <TextBlock x:Name="selectedItem"/>
    <TextBlock x:Name="selectedIndex"/>
    <TextBlock x:Name="selectedItemCount"/>
    <TextBlock x:Name="addedItems"/>
    <TextBlock x:Name="removedItems"/>
</StackPanel> 
```

<span data-ttu-id="194f7-297">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-297">**C#**</span></span>
```csharp
private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (listView1.SelectedItem != null)
    {
        selectedItem.Text = 
            "Selected item: " + listView1.SelectedItem.ToString();
    }
    else
    {
        selectedItem.Text = 
            "Selected item: null";
    }
    selectedIndex.Text = 
        "Selected index: " + listView1.SelectedIndex.ToString();
    selectedItemCount.Text = 
        "Items selected: " + listView1.SelectedItems.Count.ToString();
    addedItems.Text = 
        "Added: " + e.AddedItems.Count.ToString();
    removedItems.Text = 
        "Removed: " + e.RemovedItems.Count.ToString();
}
```

### <a name="click-mode"></a><span data-ttu-id="194f7-298">クリック モード</span><span class="sxs-lookup"><span data-stu-id="194f7-298">Click mode</span></span>

<span data-ttu-id="194f7-299">項目を選択するのではなく、ボタンのように項目をクリックできるように、リスト ビューを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="194f7-299">You can change a list view so that a user clicks items like buttons instead of selecting them.</span></span> <span data-ttu-id="194f7-300">この方法は、たとえば、リストまたはグリッド内の項目をユーザーがクリックしたときに新しいページに移動するアプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="194f7-300">For example, this is useful when your app navigates to a new page when your user clicks an item in a list or grid.</span></span> <span data-ttu-id="194f7-301">この動作を有効にするには、次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-301">To enable this behavior:</span></span>
- <span data-ttu-id="194f7-302">**SelectionMode** を **None** に設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-302">Set **SelectionMode** to **None**.</span></span>
- <span data-ttu-id="194f7-303">**IsItemClickEnabled** を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-303">Set **IsItemClickEnabled** to **true**.</span></span>
- <span data-ttu-id="194f7-304">ユーザーが項目をクリックしたときに処理を実行する **ItemClick** イベントを設定します。</span><span class="sxs-lookup"><span data-stu-id="194f7-304">Handle the **ItemClick** event to do something when your user clicks an item.</span></span>

<span data-ttu-id="194f7-305">クリックできる項目を持つリスト ビューの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-305">Here's a list view with clickable items.</span></span> <span data-ttu-id="194f7-306">ItemClick イベント ハンドラーのコードによって、新しいページに移動します。</span><span class="sxs-lookup"><span data-stu-id="194f7-306">The code in the ItemClick event handler navigates to a new page.</span></span>

<span data-ttu-id="194f7-307">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-307">**XAML**</span></span>
```xaml
<ListView SelectionMode="None"
          IsItemClickEnabled="True" 
          ItemClick="ListView1_ItemClick">
    <x:String>Page 1</x:String>
    <x:String>Page 2</x:String>
    <x:String>Page 3</x:String>
    <x:String>Page 4</x:String>
    <x:String>Page 5</x:String>
</ListView>
```

<span data-ttu-id="194f7-308">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-308">**C#**</span></span>
```csharp
private void ListView1_ItemClick(object sender, ItemClickEventArgs e)
{
    switch (e.ClickedItem.ToString())
    {
        case "Page 1":
            this.Frame.Navigate(typeof(Page1));
            break;

        case "Page 2":
            this.Frame.Navigate(typeof(Page2));
            break;

        case "Page 3":
            this.Frame.Navigate(typeof(Page3));
            break;

        case "Page 4":
            this.Frame.Navigate(typeof(Page4));
            break;

        case "Page 5":
            this.Frame.Navigate(typeof(Page5));
            break;

        default:
            break;
    }
}
```

### <a name="select-a-range-of-items-programmatically"></a><span data-ttu-id="194f7-309">プログラムを使った一定範囲の項目の選択</span><span class="sxs-lookup"><span data-stu-id="194f7-309">Select a range of items programmatically</span></span>

<span data-ttu-id="194f7-310">場合によっては、プログラムからリスト ビューの項目の選択を操作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-310">Sometimes, you need to manipulate a list view’s item selection programmatically.</span></span> <span data-ttu-id="194f7-311">たとえば、ユーザーがリスト内のすべての項目を選択できるように、**[すべて選択]** ボタンを用意する場合があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-311">For example, you might have a **Select all** button to let a user select all items in a list.</span></span> <span data-ttu-id="194f7-312">この場合、SelectedItems コレクションの項目を 1 つずつ追加したり削除したりすることは、一般的に効率的とは言えません。</span><span class="sxs-lookup"><span data-stu-id="194f7-312">In this case, it’s usually not very efficient to add and remove items from the SelectedItems collection one by one.</span></span> <span data-ttu-id="194f7-313">各項目を変更するたびに SelectionChanged イベントが発生し、インデックス値を操作するのではなく項目を直接操作すると、項目の仮想化が解除されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-313">Each item change causes a SelectionChanged event to occur, and when you work with the items directly instead of working with index values, the item is de-virtualized.</span></span>

<span data-ttu-id="194f7-314">[SelectAll](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectall.aspx)、[SelectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectrange.aspx)、[DeselectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.deselectrange.aspx) の各メソッドを使用すると、SelectedItems プロパティを使用する場合よりも効率的に選択内容を変更できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-314">The [SelectAll](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectall.aspx), [SelectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectrange.aspx), and [DeselectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.deselectrange.aspx) methods provide a more efficient way to modify the selection than using the SelectedItems property.</span></span> <span data-ttu-id="194f7-315">このメソッドでは、項目インデックスの範囲を使って選択と選択解除を行います。</span><span class="sxs-lookup"><span data-stu-id="194f7-315">These methods select or deselect using ranges of item indexes.</span></span> <span data-ttu-id="194f7-316">インデックスのみを使うため、仮想化された項目は仮想化の状態を維持します。</span><span class="sxs-lookup"><span data-stu-id="194f7-316">Items that are virtualized remain virtualized, because only the index is used.</span></span> <span data-ttu-id="194f7-317">元の選択状態に関係なく、指定範囲のすべての項目が選択 (または選択解除) されます。</span><span class="sxs-lookup"><span data-stu-id="194f7-317">All items in the specified range are selected (or deselected), regardless of their original selection state.</span></span> <span data-ttu-id="194f7-318">SelectionChanged イベントは、このメソッドを 1 回呼び出すたびに 1 回のみ発生します。</span><span class="sxs-lookup"><span data-stu-id="194f7-318">The SelectionChanged event occurs only once for each call to these methods.</span></span>

> <span data-ttu-id="194f7-319">**重要**&nbsp;&nbsp;このメソッドは、SelectionMode プロパティが Multiple または Extended に設定されているときにのみ呼び出してください。</span><span class="sxs-lookup"><span data-stu-id="194f7-319">**Important**&nbsp;&nbsp;You should call these methods only when the SelectionMode property is set to Multiple or Extended.</span></span> <span data-ttu-id="194f7-320">SelectionMode が Single または None のときに SelectRange を呼び出すと、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="194f7-320">If you call SelectRange when the SelectionMode is Single or None, an exception is thrown.</span></span>

<span data-ttu-id="194f7-321">インデックスの範囲を使って項目を選択する場合、[SelectedRanges](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectedranges.aspx) プロパティを使って、リスト内の選択範囲をすべて取得します。</span><span class="sxs-lookup"><span data-stu-id="194f7-321">When you select items using index ranges, use the [SelectedRanges](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectedranges.aspx) property to get all selected ranges in the list.</span></span>

<span data-ttu-id="194f7-322">ItemsSource に [IItemsRangeInfo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.iitemsrangeinfo.aspx) を実装し、このようなメソッドを使って選択内容を変更する場合、SelectionChangedEventArgs には **AddedItems** プロパティと **RemovedItems** プロパティが設定されません。</span><span class="sxs-lookup"><span data-stu-id="194f7-322">If the ItemsSource implements [IItemsRangeInfo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.iitemsrangeinfo.aspx), and you use these methods to modify the selection, the **AddedItems** and **RemovedItems** properties are not set in the SelectionChangedEventArgs.</span></span> <span data-ttu-id="194f7-323">このプロパティを設定するには、項目オブジェクトの仮想化を解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="194f7-323">Setting these properties requires de-virtualizing the item object.</span></span> <span data-ttu-id="194f7-324">代わりに **SelectedRanges** プロパティを使って項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="194f7-324">Use the **SelectedRanges** property to get the items instead.</span></span>

<span data-ttu-id="194f7-325">SelectAll メソッドを呼び出すと、コレクション内のすべての項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-325">You can select all items in a collection by calling the SelectAll method.</span></span> <span data-ttu-id="194f7-326">ただし、すべての項目の選択を解除するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="194f7-326">However, there is no corresponding method to deselect all items.</span></span> <span data-ttu-id="194f7-327">すべての項目の選択を解除するには、DeselectRange を呼び出して [ItemIndexRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.aspx) を渡します。このとき、[FirstIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.firstindex.aspx) 値を 0 とし、[Length](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.length.aspx) 値をコレクション内の項目数と同じ値にします。</span><span class="sxs-lookup"><span data-stu-id="194f7-327">You can deselect all items by calling DeselectRange and passing an [ItemIndexRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.aspx) with a [FirstIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.firstindex.aspx) value of 0 and a [Length](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.length.aspx) value equal to the number of items in the collection.</span></span> 

<span data-ttu-id="194f7-328">**XAML**</span><span class="sxs-lookup"><span data-stu-id="194f7-328">**XAML**</span></span>
```xaml
<StackPanel Width="160">
    <Button Content="Select all" Click="SelectAllButton_Click"/>
    <Button Content="Deselect all" Click="DeselectAllButton_Click"/>
    <ListView x:Name="listView1" SelectionMode="Multiple">
        <x:String>Item 1</x:String>
        <x:String>Item 2</x:String>
        <x:String>Item 3</x:String>
        <x:String>Item 4</x:String>
        <x:String>Item 5</x:String>
    </ListView>
</StackPanel>
```

<span data-ttu-id="194f7-329">**C#**</span><span class="sxs-lookup"><span data-stu-id="194f7-329">**C#**</span></span>
```csharp
private void SelectAllButton_Click(object sender, RoutedEventArgs e)
{
    if (listView1.SelectionMode == ListViewSelectionMode.Multiple ||
        listView1.SelectionMode == ListViewSelectionMode.Extended)
    {
        listView1.SelectAll();
    }
}

private void DeselectAllButton_Click(object sender, RoutedEventArgs e)
{
    if (listView1.SelectionMode == ListViewSelectionMode.Multiple ||
        listView1.SelectionMode == ListViewSelectionMode.Extended)
    {
        listView1.DeselectRange(new ItemIndexRange(0, (uint)listView1.Items.Count));
    }
}
```

<span data-ttu-id="194f7-330">選択した項目の外観を変更する方法について詳しくは、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-330">For info about how to change the look of selected items, see [Item containers and templates](item-containers-templates.md).</span></span>

### <a name="drag-and-drop"></a><span data-ttu-id="194f7-331">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="194f7-331">Drag and drop</span></span>

<span data-ttu-id="194f7-332">ListView コントロールと GridView コントロールは、項目内、項目間、および他の ListView コントロールと GridView コントロール間での項目のドラッグ アンド ドロップをサポートします。</span><span class="sxs-lookup"><span data-stu-id="194f7-332">ListView and GridView controls support drag and drop of items within themselves, and between themselves and other ListView and GridView controls.</span></span> <span data-ttu-id="194f7-333">ドラッグ アンド ドロップのパターンの実装について詳しくは、「[ドラッグ アンド ドロップ](https://msdn.microsoft.com/windows/uwp/design/input/drag-and-drop)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="194f7-333">For more info about implementing the drag and drop pattern, see [Drag and drop](https://msdn.microsoft.com/windows/uwp/design/input/drag-and-drop).</span></span> 

## <a name="get-the-sample-code"></a><span data-ttu-id="194f7-334">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="194f7-334">Get the sample code</span></span>

- <span data-ttu-id="194f7-335">[XAML ListView と GridView のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)- ListView と GridView コントロールを示しています。</span><span class="sxs-lookup"><span data-stu-id="194f7-335">[XAML ListView and GridView sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView) - Demonstrates the ListView and GridView controls.</span></span>
- <span data-ttu-id="194f7-336">[XAML ドラッグ アンド ドロップのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlDragAndDrop) - ListView コントロールを使用したドラッグ アンド ドロップを示します。</span><span class="sxs-lookup"><span data-stu-id="194f7-336">[XAML Drag and drop sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlDragAndDrop) - Demonstrates drag and drop with the ListView control.</span></span>
- <span data-ttu-id="194f7-337">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="194f7-337">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="194f7-338">関連記事</span><span class="sxs-lookup"><span data-stu-id="194f7-338">Related articles</span></span>

- [<span data-ttu-id="194f7-339">リスト</span><span class="sxs-lookup"><span data-stu-id="194f7-339">Lists</span></span>](lists.md)
- [<span data-ttu-id="194f7-340">項目コンテナーとテンプレート</span><span class="sxs-lookup"><span data-stu-id="194f7-340">Item containers and templates</span></span>](item-containers-templates.md)
- [<span data-ttu-id="194f7-341">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="194f7-341">Drag and drop</span></span>](https://msdn.microsoft.com/windows/uwp/app-to-app/drag-and-drop)
