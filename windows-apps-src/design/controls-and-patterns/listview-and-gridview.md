---
author: muhsinking
Description: Use ListView and GridView controls to display and manipulate sets of data, such as a gallery of images or a set of email messages.
title: リスト ビューとグリッド ビュー
label: List view and grid view
template: detail.hbs
ms.author: jimwalk
ms.date: 05/20/2017
ms.topic: article
keywords: windows 10, UWP
ms.assetid: f8532ba0-5510-4686-9fcf-87fd7c643e7b
pm-contact: predavid
design-contact: kimsea
dev-contact: ranjeshj
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 1ee00a9af23be945ad27ab4b39eec127ec397894
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5830274"
---
# <a name="list-view-and-grid-view"></a><span data-ttu-id="1be9a-103">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="1be9a-103">List view and grid view</span></span>

<span data-ttu-id="1be9a-104">ほとんどのアプリでは、イメージ ギャラリー、メール メッセージなどのデータのセットを操作および表示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-104">Most applications manipulate and display sets of data, such as a gallery of images or a set of email messages.</span></span> <span data-ttu-id="1be9a-105">XAML UI フレームワークでは、アプリ内でデータを簡単に表示、操作するための ListView コントロールと GridView コントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="1be9a-105">The XAML UI framework provides ListView and GridView controls that make it easy to display and manipulate data in your app.</span></span>  

> <span data-ttu-id="1be9a-106">**重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)、[ItemsSource プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx)、[Items プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx)</span><span class="sxs-lookup"><span data-stu-id="1be9a-106">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx), [ItemsSource property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx), [Items property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx)</span></span>

<span data-ttu-id="1be9a-107">ListView と GridView はどちらも ListViewBase クラスから派生しているため、同じ機能を持ちますが、データの表示方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-107">ListView and GridView both derive from the ListViewBase class, so they have the same functionality, but display data differently.</span></span> <span data-ttu-id="1be9a-108">この記事では、特に指定がない限り、ListView についての説明は ListView コントロールにも GridView コントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-108">In this article, when we talk about ListView, the info applies to both the ListView and GridView controls unless otherwise specified.</span></span> <span data-ttu-id="1be9a-109">ListView や ListViewItem などのクラスの説明については、プレフィックスの "List" を "Grid" に置き換えることで、対応するグリッド クラス (GridView または GridViewItem) に適用できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-109">We may refer to classes like ListView or ListViewItem, but the “List” prefix can be replaced with “Grid” for the corresponding grid equivalent (GridView or GridViewItem).</span></span> 

## <a name="is-this-the-right-control"></a><span data-ttu-id="1be9a-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-110">Is this the right control?</span></span>

<span data-ttu-id="1be9a-111">ListView では、データを縦方向の 1 列に並べて表示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-111">The ListView displays data stacked vertically in a single column.</span></span> <span data-ttu-id="1be9a-112">メールや検索結果の一覧など、順序が付けられた項目の一覧を表示するときによく使います。</span><span class="sxs-lookup"><span data-stu-id="1be9a-112">It's often used to show an ordered list of items, such as a list of emails or search results.</span></span> 

![グループ化されたデータを表示するリスト ビュー](images/simple-list-view-phone.png)

<span data-ttu-id="1be9a-114">GridView は、縦方向にスクロールできる複数行と複数列で項目のコレクションを表示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-114">The GridView presents a collection of items in rows and columns that can scroll vertically.</span></span> <span data-ttu-id="1be9a-115">データはまず横方向に並べられ、すべての列にデータが入ると、次の行に折り返して並べられます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-115">Data is stacked horizontally until it fills the columns, then continues with the next row.</span></span> <span data-ttu-id="1be9a-116">フォト ギャラリーのように、各項目の表示内容が豊富で表示領域を広く使う必要がある場合によく使います。</span><span class="sxs-lookup"><span data-stu-id="1be9a-116">It's often used when you need to show a rich visualization of each item that takes more space, such as a photo gallery.</span></span> 

![コンテンツ ライブラリの例](images/controls_list_contentlibrary.png)

<span data-ttu-id="1be9a-118">使用するコントロールを選ぶための詳しい比較とガイダンスについては、「[リスト](lists.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-118">For a more detailed comparison and guidance on which control to use, see [Lists](lists.md).</span></span>

## <a name="examples"></a><span data-ttu-id="1be9a-119">例</span><span class="sxs-lookup"><span data-stu-id="1be9a-119">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="1be9a-120">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="1be9a-120">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="1be9a-121"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ListView">ListView</a> または <a href="xamlcontrolsgallery:/item/GridView">GridView</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-121">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ListView">ListView</a> or <a href="xamlcontrolsgallery:/item/GridView">GridView</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="1be9a-122">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="1be9a-122">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="1be9a-123">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="1be9a-123">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-list-view"></a><span data-ttu-id="1be9a-124">リスト ビューの作成</span><span class="sxs-lookup"><span data-stu-id="1be9a-124">Create a list view</span></span>

<span data-ttu-id="1be9a-125">リスト ビューは [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-125">List view is an [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx), so it can contain a collection of items of any type.</span></span> <span data-ttu-id="1be9a-126">リスト ビューを使って項目を表示するには、[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-126">It must have items in its [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection before it can show anything on the screen.</span></span> <span data-ttu-id="1be9a-127">ビューのデータを設定するには、項目を直接 [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに追加するか、データ ソースに [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-127">To populate the view, you can add items directly to the [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection, or set the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a data source.</span></span> 

<span data-ttu-id="1be9a-128">**重要**&nbsp;&nbsp;リストにデータを設定するときには Items または ItemsSource を使用しますが、同時に両方を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-128">**Important**&nbsp;&nbsp;You can use either Items or ItemsSource to populate the list, but you can't use both at the same time.</span></span> <span data-ttu-id="1be9a-129">ItemsSource プロパティを設定して XAML で項目を追加した場合、追加された項目は無視されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-129">If you set the ItemsSource property and you add an item in XAML, the added item is ignored.</span></span> <span data-ttu-id="1be9a-130">ItemsSource プロパティを設定してコードで Items コレクションに項目を追加した場合、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-130">If you set the ItemsSource property and you add an item to the Items collection in code, an exception is thrown.</span></span>

> <span data-ttu-id="1be9a-131">**注**&nbsp;&nbsp;この記事の例の多くでは、説明を簡単にするために **Items** コレクションを直接設定しています。</span><span class="sxs-lookup"><span data-stu-id="1be9a-131">**Note**&nbsp;&nbsp;Many of the examples in this article populate the **Items** collection directly for the sake of simplicity.</span></span> <span data-ttu-id="1be9a-132">ただし、リストの項目は、オンライン データベースの書籍一覧など、動的なソースから取得される方が一般的です。</span><span class="sxs-lookup"><span data-stu-id="1be9a-132">However, it's more common for the items in a list to come from a dynamic source, like a list of books from an online database.</span></span> <span data-ttu-id="1be9a-133">このようなケースでは、**ItemsSource** プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-133">You use the **ItemsSource** property for this purpose.</span></span> 

### <a name="add-items-to-the-items-collection"></a><span data-ttu-id="1be9a-134">Items コレクションへの項目の追加</span><span class="sxs-lookup"><span data-stu-id="1be9a-134">Add items to the Items collection</span></span>

<span data-ttu-id="1be9a-135">[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加するには、XAML かコードを使います。</span><span class="sxs-lookup"><span data-stu-id="1be9a-135">You can add items to the [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) collection using XAML or code.</span></span> <span data-ttu-id="1be9a-136">通常、項目が少数で、その項目が変わらず、XAML で簡単に定義できる場合や、実行時にコードで項目を生成する場合は、この方法で項目を追加します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-136">You typically add items this way if you have a small number of items that don't change and are easily defined in XAML, or if you generate the items in code at run time.</span></span> 

<span data-ttu-id="1be9a-137">XAML で項目をインラインで定義したリスト ビューを次に示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-137">Here's a list view with items defined inline in XAML.</span></span> <span data-ttu-id="1be9a-138">XAML で項目を定義すると、定義した項目は Items コレクションに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-138">When you define the items in XAML, they are automatically added to the Items collection.</span></span>

**<span data-ttu-id="1be9a-139">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-139">XAML</span></span>**
```xaml
<ListView x:Name="listView1"> 
   <x:String>Item 1</x:String> 
   <x:String>Item 2</x:String> 
   <x:String>Item 3</x:String> 
   <x:String>Item 4</x:String> 
   <x:String>Item 5</x:String> 
</ListView>  
```

<span data-ttu-id="1be9a-140">作成したリスト ビューのコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-140">Here's the list view created in code.</span></span> <span data-ttu-id="1be9a-141">生成されるリストは、以前に XAML で作ったものと同じです。</span><span class="sxs-lookup"><span data-stu-id="1be9a-141">The resulting list is the same as the one created previously in XAML.</span></span>

**<span data-ttu-id="1be9a-142">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-142">C#</span></span>**
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

<span data-ttu-id="1be9a-143">ListView は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-143">The ListView looks like this.</span></span>

![単純なリスト ビュー](images/listview-simple.png)

### <a name="set-the-items-source"></a><span data-ttu-id="1be9a-145">項目ソースの設定</span><span class="sxs-lookup"><span data-stu-id="1be9a-145">Set the items source</span></span>

<span data-ttu-id="1be9a-146">通常、リスト ビューを使って、データベースやインターネットなどのソースからデータを表示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-146">You typically use a list view to display data from a source such as a database or the Internet.</span></span> <span data-ttu-id="1be9a-147">データ ソースからリスト ビューのデータを設定するには、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ項目のコレクションに設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-147">To populate a list view from a data source, you set its [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) property to a collection of data items.</span></span>

<span data-ttu-id="1be9a-148">以下の例では、コードでコレクションのインスタンスに直接リスト ビューの ItemsSource を設定しています。</span><span class="sxs-lookup"><span data-stu-id="1be9a-148">Here, the list view's ItemsSource is set in code directly to an instance of a collection.</span></span>

**<span data-ttu-id="1be9a-149">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-149">C#</span></span>**
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

<span data-ttu-id="1be9a-150">ItemsSource プロパティを、XAML でコレクションにバインドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-150">You can also bind the ItemsSource property to a collection in XAML.</span></span> <span data-ttu-id="1be9a-151">データ バインディングについて詳しくは、「[データ バインディングの概要](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-151">For more info about data binding, see [Data binding overview](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart).</span></span>

<span data-ttu-id="1be9a-152">ここでは、ページのプライベート データ コレクションを公開する `Items` という名前のパブリック プロパティに ItemsSource をバインドします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-152">Here, the ItemsSource is bound to a public property named `Items` that exposes the Page's private data collection.</span></span>

**<span data-ttu-id="1be9a-153">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-153">XAML</span></span>**
```xaml
<ListView x:Name="itemListView" ItemsSource="{x:Bind Items}"/>
```

**<span data-ttu-id="1be9a-154">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-154">C#</span></span>**
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

<span data-ttu-id="1be9a-155">リスト ビューにグループ化されたデータを表示する必要がある場合、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) にバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-155">If you need to show grouped data in your list view, you must bind to a [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span> <span data-ttu-id="1be9a-156">CollectionViewSource は XAML のコレクション クラスのプロキシとして機能し、グループ化サポートを有効にします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-156">The CollectionViewSource acts as a proxy for the collection class in XAML and enables grouping support.</span></span> <span data-ttu-id="1be9a-157">詳しくは、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-157">For more info, see [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span>

## <a name="data-template"></a><span data-ttu-id="1be9a-158">データ テンプレート</span><span class="sxs-lookup"><span data-stu-id="1be9a-158">Data template</span></span>

<span data-ttu-id="1be9a-159">項目のデータ テンプレートによって、データの表示方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-159">An item’s data template defines how the data is visualized.</span></span> <span data-ttu-id="1be9a-160">既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてリスト ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-160">By default, a data item is displayed in the list view as the string representation of the data object it's bound to.</span></span> <span data-ttu-id="1be9a-161">データ項目の特定のプロパティに [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) を設定すると、そのプロパティの文字列表現を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-161">You can show the string representation of a particular property of the data item by setting the [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) to that property.</span></span>

<span data-ttu-id="1be9a-162">しかし、通常はもっとリッチな表現でデータを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-162">However, you typically want to show a more rich presentation of your data.</span></span> <span data-ttu-id="1be9a-163">リスト ビューでの項目の表示方法を正確に指定するには、[DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-163">To specify exactly how items in the list view are displayed, you create a [DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx).</span></span> <span data-ttu-id="1be9a-164">DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-164">The XAML in the DataTemplate defines the layout and appearance of controls used to display an individual item.</span></span> <span data-ttu-id="1be9a-165">レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-165">The controls in the layout can be bound to properties of a data object, or have static content defined inline.</span></span> <span data-ttu-id="1be9a-166">DataTemplate は、リスト コントロールの [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-166">You assign the DataTemplate to the [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the list control.</span></span>

<span data-ttu-id="1be9a-167">この例では、データ項目は単純な文字列です。</span><span class="sxs-lookup"><span data-stu-id="1be9a-167">In this example, the data item is a simple string.</span></span> <span data-ttu-id="1be9a-168">DataTemplate を使って、文字列の左側に画像を追加し、文字列を青緑で表示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-168">You use a DataTemplate to add an image to the left of the string, and show the string in teal.</span></span>

> <span data-ttu-id="1be9a-169">**注**&nbsp;&nbsp;DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使用する場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-169">**Note**&nbsp;&nbsp;When you use the [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) in a DataTemplate, you have to specify the DataType (`x:DataType`) on the DataTemplate.</span></span>

**<span data-ttu-id="1be9a-170">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-170">XAML</span></span>**
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

<span data-ttu-id="1be9a-171">このデータ テンプレートを使ってデータ項目を表示すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-171">Here's what the data items look like when displayed with this data template.</span></span>

![データ テンプレートを使ったリスト ビュー項目](images/listview-itemstemplate.png)

<span data-ttu-id="1be9a-173">データ テンプレートは、リスト ビューの外観を定義する主要な方法です。</span><span class="sxs-lookup"><span data-stu-id="1be9a-173">Data templates are the primary way you define the look of your list view.</span></span> <span data-ttu-id="1be9a-174">リストに多数の項目を表示した場合、パフォーマンスが大幅に低下することもあります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-174">They can also have a significant impact on performance if your list displays a large number of items.</span></span> <span data-ttu-id="1be9a-175">この記事では、ほとんどの例で単純な文字列データを使用しており、データ テンプレートを指定していません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-175">In this article, we use simple string data for most of the examples, and don't specify a data template.</span></span> <span data-ttu-id="1be9a-176">データ テンプレートと項目コンテナーを使用してリストまたはグリッドの項目の外観を定義する詳しい方法とその例については、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-176">For more info and examples of how to use data templates and item containers to define the look of items in your list or grid, see [Item containers and templates](item-containers-templates.md).</span></span> 

## <a name="change-the-layout-of-items"></a><span data-ttu-id="1be9a-177">項目のレイアウト変更</span><span class="sxs-lookup"><span data-stu-id="1be9a-177">Change the layout of items</span></span>

<span data-ttu-id="1be9a-178">リスト ビューまたはグリッド ビューに項目を追加すると、項目コンテナー内で各項目が自動的に折り返され、すべての項目コンテナーがレイアウトされます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-178">When you add items to a list view or grid view, the control automatically wraps each item in an item container and then lays out all of the item containers.</span></span> <span data-ttu-id="1be9a-179">この項目コンテナーのレイアウト方法は、コントロールの [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) によって決まります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-179">How these item containers are laid out depends on the [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) of the control.</span></span>  
- <span data-ttu-id="1be9a-180">**ListView** では既定で [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) が使用され、次のような縦 1 列のリストが生成されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-180">By default, **ListView** uses an [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx), which produces a vertical list, like this.</span></span>

![単純なリスト ビュー](images/listview-simple.png)

- <span data-ttu-id="1be9a-182">**GridView** では [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) が使用されます。次のように、項目が水平方向に追加され、折り返されて縦方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-182">**GridView** uses an [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx), which adds items horizontally, and wraps and scrolls vertically, like this.</span></span>

![単純なグリッド ビュー](images/gridview-simple.png)

<span data-ttu-id="1be9a-184">項目のレイアウトを変更するには、項目パネルのプロパティを調整するか、既定のパネルを別のパネルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-184">You can modify the layout of items by adjusting properties on the items panel, or you can replace the default panel with another panel.</span></span>

> <span data-ttu-id="1be9a-185">注&nbsp;&nbsp;ItemsPanel を変更する場合、仮想化を無効にしないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-185">Note&nbsp;&nbsp;Be careful to not disable virtualization if you change the ItemsPanel.</span></span> <span data-ttu-id="1be9a-186">**ItemsStackPanel** と **ItemsWrapGrid** はどちらも仮想化をサポートしており、安全に使用できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-186">Both **ItemsStackPanel** and **ItemsWrapGrid** support virtualization, so these are safe to use.</span></span> <span data-ttu-id="1be9a-187">他のパネルを使用すると、仮想化が無効になり、リスト ビューのパフォーマンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-187">If you use any other panel, you might disable virtualization and slow the performance of the list view.</span></span> <span data-ttu-id="1be9a-188">詳しくは、「[Performance (パフォーマンス)](https://msdn.microsoft.com/windows/uwp/debug-test-perf/performance-and-xaml-ui)」のリスト ビューに関する記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-188">For more info, see the list view articles under [Performance](https://msdn.microsoft.com/windows/uwp/debug-test-perf/performance-and-xaml-ui).</span></span> 

<span data-ttu-id="1be9a-189">この例では、**ItemsStackPanel** の [Orientation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.orientation.aspx) プロパティを変更することで、**ListView** に項目コンテナーを横 1 列にレイアウトする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1be9a-189">This example shows how to make a **ListView** lay out its item containers in a horizontal list by changing the [Orientation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.orientation.aspx) property of the **ItemsStackPanel**.</span></span>
<span data-ttu-id="1be9a-190">リスト ビューは既定で縦方向にスクロールするため、横方向にスクロールさせるには、リスト ビュー内部の [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) のプロパティもいくつか調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-190">Because the list view scrolls vertically by default, you also need to adjust some properties on the list view’s internal [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) to make it scroll horizontally.</span></span>
- <span data-ttu-id="1be9a-191">[ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx) を **Enabled** または **Auto** に設定</span><span class="sxs-lookup"><span data-stu-id="1be9a-191">[ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx) to **Enabled** or **Auto**</span></span>
- <span data-ttu-id="1be9a-192">[ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx) を **Auto** に設定</span><span class="sxs-lookup"><span data-stu-id="1be9a-192">[ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx) to **Auto**</span></span> 
- <span data-ttu-id="1be9a-193">[ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx) を **Disabled** に設定</span><span class="sxs-lookup"><span data-stu-id="1be9a-193">[ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx) to **Disabled**</span></span> 
- <span data-ttu-id="1be9a-194">[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) を **Hidden** に設定</span><span class="sxs-lookup"><span data-stu-id="1be9a-194">[ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) to **Hidden**</span></span> 

> <span data-ttu-id="1be9a-195">**注**&nbsp;&nbsp;ここに示す例ではリスト ビューの幅が規定されていないため、水平スクロール バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-195">**Note**&nbsp;&nbsp;These examples are shown with the list view width unconstrained, so the horizontal scrollbars are not shown.</span></span> <span data-ttu-id="1be9a-196">このコードを実行する場合、ListView に `Width="180"` を設定してスクロール バーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-196">If you run this code, you can set `Width="180"` on the ListView to make the scrollbars show.</span></span>

**<span data-ttu-id="1be9a-197">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-197">XAML</span></span>**
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

<span data-ttu-id="1be9a-198">このリストは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-198">The resulting list looks like this.</span></span>

![横長のリスト ビュー](images/listview-horizontal.png)

 <span data-ttu-id="1be9a-200">次の例の **ListView** では、**ItemsStackPanel** ではなく **ItemsWrapGrid** を使用して、縦方向に折り返すリストで項目をレイアウトします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-200">In the next example, the **ListView** lays out items in a vertical wrapping list by using an **ItemsWrapGrid** instead of an **ItemsStackPanel**.</span></span> 
 
> <span data-ttu-id="1be9a-201">**注**&nbsp;&nbsp;コントロールでコンテナーを折り返すには、リスト ビューの高さを規定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-201">**Note**&nbsp;&nbsp;The height of the list view must be constrained to force the control to wrap the containers.</span></span>

**<span data-ttu-id="1be9a-202">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-202">XAML</span></span>**
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

<span data-ttu-id="1be9a-203">このリストは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-203">The resulting list looks like this.</span></span>

![グリッド レイアウトを使ったリスト ビュー](images/listview-itemswrapgrid.png)

<span data-ttu-id="1be9a-205">グループ化したデータをリスト ビューに表示する場合、ItemsPanel によって指定されるのは個々の項目のレイアウト方法ではなく、項目グループのレイアウト方法です。たとえば、前に示した横方向の ItemsStackPanel を使用して、グループ化されたデータを表示する場合、次に示すようにグループは横方向に配置されますが、各グループの項目は縦に重ねて表示されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-205">If you show grouped data in your list view, the ItemsPanel determines how the item groups are layed out, not how the individual items are layed out. For example, if the horizontal ItemsStackPanel shown previously is used to show grouped data, the groups are arranged horizontally, but the items in each group are still stacked vertically, as shown here.</span></span>

![グループ化された横方向のリスト ビュー](images/listview-horizontal-groups.png)

## <a name="item-selection-and-interaction"></a><span data-ttu-id="1be9a-207">項目の選択と操作</span><span class="sxs-lookup"><span data-stu-id="1be9a-207">Item selection and interaction</span></span>

<span data-ttu-id="1be9a-208">ユーザーがリスト ビューを操作する方法は、いくつか選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-208">You can choose from various ways to let a user interact with a list view.</span></span> <span data-ttu-id="1be9a-209">既定では、ユーザーは 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-209">By default, a user can select a single item.</span></span> <span data-ttu-id="1be9a-210">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) プロパティを変更することで、複数選択を有効にしたり、選択を無効にしたりできます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-210">You can change the [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) property to enable multi-selection or to disable selection.</span></span> <span data-ttu-id="1be9a-211">[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) プロパティを設定することで、ユーザーが項目をクリックしたときに項目を選択するのではなく、ボタンと同じように操作を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-211">You can set the [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) property so that a user clicks an item to invoke an action (like a button) instead of selecting the item.</span></span>

> <span data-ttu-id="1be9a-212">**注**&nbsp;&nbsp; ListView と GridView のどちらも、SelectionMode プロパティについては [ListViewSelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewselectionmode.aspx) 列挙値を使用します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-212">**Note**&nbsp;&nbsp;Both ListView and GridView use the [ListViewSelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewselectionmode.aspx) enumeration for their SelectionMode properties.</span></span> <span data-ttu-id="1be9a-213">IsItemClickEnabled は既定で **False** であるため、設定する必要があるのはクリック モードを有効にする場合のみです。</span><span class="sxs-lookup"><span data-stu-id="1be9a-213">IsItemClickEnabled is **False** by default, so you need to set it only to enable click mode.</span></span>

<span data-ttu-id="1be9a-214">次の表に、ユーザーがリスト ビューを操作する方法と、その操作に対する応答方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-214">This table shows the ways a user can interact with a list view, and how you can respond to the interaction.</span></span>

<span data-ttu-id="1be9a-215">有効にする操作:</span><span class="sxs-lookup"><span data-stu-id="1be9a-215">To enable this interaction:</span></span> | <span data-ttu-id="1be9a-216">使用する設定:</span><span class="sxs-lookup"><span data-stu-id="1be9a-216">Use these settings:</span></span> | <span data-ttu-id="1be9a-217">処理するイベント:</span><span class="sxs-lookup"><span data-stu-id="1be9a-217">Handle this event:</span></span> | <span data-ttu-id="1be9a-218">選択された項目の取得に使うプロパティ:</span><span class="sxs-lookup"><span data-stu-id="1be9a-218">Use this property to get the selected item:</span></span>
----------------------------|---------------------|--------------------|--------------------------------------------
<span data-ttu-id="1be9a-219">操作なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-219">No interaction</span></span> | <span data-ttu-id="1be9a-220">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) = **None**、[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) = **False**</span><span class="sxs-lookup"><span data-stu-id="1be9a-220">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) = **None**, [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) = **False**</span></span> | <span data-ttu-id="1be9a-221">該当なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-221">N/A</span></span> | <span data-ttu-id="1be9a-222">該当なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-222">N/A</span></span> 
<span data-ttu-id="1be9a-223">単一選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-223">Single selection</span></span> | <span data-ttu-id="1be9a-224">SelectionMode = **Single**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="1be9a-224">SelectionMode = **Single**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="1be9a-225">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="1be9a-225">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | <span data-ttu-id="1be9a-226">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx)、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx)</span><span class="sxs-lookup"><span data-stu-id="1be9a-226">[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx), [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx)</span></span>  
<span data-ttu-id="1be9a-227">複数選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-227">Multiple selection</span></span> | <span data-ttu-id="1be9a-228">SelectionMode = **Multiple**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="1be9a-228">SelectionMode = **Multiple**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="1be9a-229">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="1be9a-229">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [<span data-ttu-id="1be9a-230">SelectedItems</span><span class="sxs-lookup"><span data-stu-id="1be9a-230">SelectedItems</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
<span data-ttu-id="1be9a-231">拡張選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-231">Extended selection</span></span> | <span data-ttu-id="1be9a-232">SelectionMode = **Extended**、IsItemClickEnabled = **False**</span><span class="sxs-lookup"><span data-stu-id="1be9a-232">SelectionMode = **Extended**, IsItemClickEnabled = **False**</span></span> | [<span data-ttu-id="1be9a-233">SelectionChanged</span><span class="sxs-lookup"><span data-stu-id="1be9a-233">SelectionChanged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [<span data-ttu-id="1be9a-234">SelectedItems</span><span class="sxs-lookup"><span data-stu-id="1be9a-234">SelectedItems</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
<span data-ttu-id="1be9a-235">クリック</span><span class="sxs-lookup"><span data-stu-id="1be9a-235">Click</span></span> | <span data-ttu-id="1be9a-236">SelectionMode = **None**、IsItemClickEnabled = **True**</span><span class="sxs-lookup"><span data-stu-id="1be9a-236">SelectionMode = **None**, IsItemClickEnabled = **True**</span></span> | [<span data-ttu-id="1be9a-237">ItemClick</span><span class="sxs-lookup"><span data-stu-id="1be9a-237">ItemClick</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.itemclick.aspx) | <span data-ttu-id="1be9a-238">該当なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-238">N/A</span></span> 

> <span data-ttu-id="1be9a-239">**注**&nbsp;&nbsp;Windows 10 以降では、IsItemClickEnabled を有効にして ItemClick イベントを発生させる場合でも、SelectionMode を Single、Multiple、Extended のいずれにも設定できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-239">**Note**&nbsp;&nbsp;Starting in Windows 10, you can enable IsItemClickEnabled to raise an ItemClick event while SelectionMode is also set to Single, Multiple, or Extended.</span></span> <span data-ttu-id="1be9a-240">その場合、ItemClick イベントが最初に発生し、次に SelectionChanged イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-240">If you do this, the ItemClick event is raised first, and then the SelectionChanged event is raised.</span></span> <span data-ttu-id="1be9a-241">ただし ItemClick イベント ハンドラーで別のページに移動するような場合では、SelectionChanged イベントが発生せず、項目が選択されません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-241">In some cases, like if you navigate to another page in the ItemClick event handler, the SelectionChanged event is not raised and the item is not selected.</span></span>

<span data-ttu-id="1be9a-242">次に示すように、このプロパティを XAML またはコードで設定することができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-242">You can set these properties in XAML or in code, as shown here.</span></span>

**<span data-ttu-id="1be9a-243">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-243">XAML</span></span>**
```xaml
<ListView x:Name="myListView" SelectionMode="Multiple"/>

<GridView x:Name="myGridView" SelectionMode="None" IsItemClickEnabled="True"/> 
```

**<span data-ttu-id="1be9a-244">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-244">C#</span></span>**
```csharp
myListView.SelectionMode = ListViewSelectionMode.Multiple; 

myGridView.SelectionMode = ListViewSelectionMode.None;
myGridView.IsItemClickEnabled = true;
```

### <a name="read-only"></a><span data-ttu-id="1be9a-245">読み取り専用</span><span class="sxs-lookup"><span data-stu-id="1be9a-245">Read-only</span></span>

<span data-ttu-id="1be9a-246">SelectionMode プロパティを **ListViewSelectionMode.None** に設定することで、項目の選択を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-246">You can set the SelectionMode property to **ListViewSelectionMode.None** to disable item selection.</span></span> <span data-ttu-id="1be9a-247">これによりコントロールが読み取り専用モードになり、ユーザーの操作には使われず、データの表示のみに使われます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-247">This puts the control in read only mode, to be used for displaying data, but not for interacting with it.</span></span> <span data-ttu-id="1be9a-248">コントロール自体は無効にならず、項目の選択のみが無効になります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-248">The control itself is not disabled, only item selection is disabled.</span></span>

### <a name="single-selection"></a><span data-ttu-id="1be9a-249">単一選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-249">Single selection</span></span>

<span data-ttu-id="1be9a-250">次の表では、SelectionMode が **Single** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-250">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Single**.</span></span>

<span data-ttu-id="1be9a-251">修飾キー</span><span class="sxs-lookup"><span data-stu-id="1be9a-251">Modifier key</span></span> | <span data-ttu-id="1be9a-252">操作</span><span class="sxs-lookup"><span data-stu-id="1be9a-252">Interaction</span></span>
-------------|------------
<span data-ttu-id="1be9a-253">なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-253">None</span></span> | <li><span data-ttu-id="1be9a-254">ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-254">A user can select a single item using the space bar, mouse click, or touch tap.</span></span></li>
<span data-ttu-id="1be9a-255">Ctrl</span><span class="sxs-lookup"><span data-stu-id="1be9a-255">Ctrl</span></span> | <li><span data-ttu-id="1be9a-256">ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目の選択を解除できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-256">A user can deselect a single item using the space bar, mouse click, or touch tap.</span></span></li><li><span data-ttu-id="1be9a-257">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-257">Using the arrow keys, a user can move focus independently of selection.</span></span></li>

<span data-ttu-id="1be9a-258">SelectionMode が **Single** の場合、[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx) プロパティから選択したデータ項目を取得できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-258">When SelectionMode is **Single**, you can get the selected data item from the [SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx) property.</span></span> <span data-ttu-id="1be9a-259">[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx) プロパティを使って、選択した項目のコレクション内のインデックスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-259">You can get the index in the collection of the selected item using the [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx) property.</span></span> <span data-ttu-id="1be9a-260">項目が選択されていない場合、SelectedItem は **null** になり、SelectedIndex は -1 になります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-260">If no item is selected, SelectedItem is **null**, and SelectedIndex is -1.</span></span> 
 
<span data-ttu-id="1be9a-261">**Items** コレクションに含まれない項目を **SelectedItem** として設定しようとすると、その操作は無視され、SelectedItem が **null** になります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-261">If you try to set an item that is not in the **Items** collection as the **SelectedItem**, the operation is ignored and SelectedItem is**null**.</span></span> <span data-ttu-id="1be9a-262">ただし、リスト内の **Items** の範囲外のインデックスを **SelectedIndex** に設定しようとすると、**System.ArgumentException** 例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-262">However, if you try to set the **SelectedIndex** to an index that's out of the range of the **Items** in the list, a **System.ArgumentException** exception occurs.</span></span> 

### <a name="multiple-selection"></a><span data-ttu-id="1be9a-263">複数選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-263">Multiple selection</span></span>

<span data-ttu-id="1be9a-264">次の表では、SelectionMode が **Multiple** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-264">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Multiple**.</span></span>

<span data-ttu-id="1be9a-265">修飾キー</span><span class="sxs-lookup"><span data-stu-id="1be9a-265">Modifier key</span></span> | <span data-ttu-id="1be9a-266">操作</span><span class="sxs-lookup"><span data-stu-id="1be9a-266">Interaction</span></span>
-------------|------------
<span data-ttu-id="1be9a-267">なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-267">None</span></span> | <li><span data-ttu-id="1be9a-268">ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-268">A user can select multiple items using the space bar, mouse click, or touch tap to toggle selection on the focused item.</span></span></li><li><span data-ttu-id="1be9a-269">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-269">Using the arrow keys, a user can move focus independently of selection.</span></span></li>
<span data-ttu-id="1be9a-270">Shift</span><span class="sxs-lookup"><span data-stu-id="1be9a-270">Shift</span></span> | <li><span data-ttu-id="1be9a-271">ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-271">A user can select multiple contiguous items by clicking or tapping the first item in the selection and then the last item in the selection.</span></span></li><li><span data-ttu-id="1be9a-272">方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-272">Using the arrow keys, a user can create a contiguous selection starting with the item selected when Shift is pressed.</span></span></li>

### <a name="extended-selection"></a><span data-ttu-id="1be9a-273">拡張選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-273">Extended selection</span></span>

<span data-ttu-id="1be9a-274">次の表では、SelectionMode が **Extended** の場合のキーボード操作、マウス操作、タッチ操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-274">This table describes the keyboard, mouse, and touch interactions when SelectionMode is **Extended**.</span></span>

<span data-ttu-id="1be9a-275">修飾キー</span><span class="sxs-lookup"><span data-stu-id="1be9a-275">Modifier key</span></span> | <span data-ttu-id="1be9a-276">操作</span><span class="sxs-lookup"><span data-stu-id="1be9a-276">Interaction</span></span>
-------------|------------
<span data-ttu-id="1be9a-277">なし</span><span class="sxs-lookup"><span data-stu-id="1be9a-277">None</span></span> | <li><span data-ttu-id="1be9a-278">**Single** の選択と同じです。</span><span class="sxs-lookup"><span data-stu-id="1be9a-278">The behavior is the same as **Single** selection.</span></span></li>
<span data-ttu-id="1be9a-279">Ctrl</span><span class="sxs-lookup"><span data-stu-id="1be9a-279">Ctrl</span></span> | <li><span data-ttu-id="1be9a-280">ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-280">A user can select multiple items using the space bar, mouse click, or touch tap to toggle selection on the focused item.</span></span></li><li><span data-ttu-id="1be9a-281">方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-281">Using the arrow keys, a user can move focus independently of selection.</span></span></li>
<span data-ttu-id="1be9a-282">Shift</span><span class="sxs-lookup"><span data-stu-id="1be9a-282">Shift</span></span> | <li><span data-ttu-id="1be9a-283">ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-283">A user can select multiple contiguous items by clicking or tapping the first item in the selection and then the last item in the selection.</span></span></li><li><span data-ttu-id="1be9a-284">方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-284">Using the arrow keys, a user can create a contiguous selection starting with the item selected when Shift is pressed.</span></span></li>

<span data-ttu-id="1be9a-285">SelectionMode が **Multiple** または **Extended** の場合、選択したデータ項目を [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx) プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-285">When SelectionMode is **Multiple** or **Extended**, you can get the selected data items from the [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx) property.</span></span> 

<span data-ttu-id="1be9a-286">**SelectedIndex**、**SelectedItem**、**SelectedItems** の各プロパティは同期されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-286">The **SelectedIndex**, **SelectedItem**, and **SelectedItems** properties are synchronized.</span></span> <span data-ttu-id="1be9a-287">たとえば、SelectedIndex を -1 に設定すると、SelectedItem は **null** に設定され、SelectedItems が空になります。SelectedItem を **null** に設定すると、SelectedIndex が -1 に設定され、SelectedItems が空になります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-287">For example, if you set SelectedIndex to -1, SelectedItem is set to **null** and SelectedItems is empty; if you set SelectedItem to **null**, SelectedIndex is set to -1 and SelectedItems is empty.</span></span>

<span data-ttu-id="1be9a-288">複数選択モードの場合、**SelectedItem** には最初に選択された項目が含まれ、**Selectedindex** には最初に選択した項目のインデックスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-288">In multi-select mode, **SelectedItem** contains the item that was selected first, and **Selectedindex** contains the index of the item that was selected first.</span></span> 

### <a name="respond-to-selection-changes"></a><span data-ttu-id="1be9a-289">選択範囲の変更への対応</span><span class="sxs-lookup"><span data-stu-id="1be9a-289">Respond to selection changes</span></span>

<span data-ttu-id="1be9a-290">リスト ビューにおける選択内容の変更に対応するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-290">To respond to selection changes in a list view, handle the [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) event.</span></span> <span data-ttu-id="1be9a-291">イベント ハンドラーのコードでは、[SelectionChangedEventArgs.AddedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.addeditems.aspx) プロパティから選ばれた項目の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-291">In the event handler code, you can get the list of selected items from the [SelectionChangedEventArgs.AddedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.addeditems.aspx) property.</span></span> <span data-ttu-id="1be9a-292">選択が解除された項目は、[SelectionChangedEventArgs.RemovedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.removeditems.aspx) プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-292">You can get any items that were deselected from the [SelectionChangedEventArgs.RemovedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.removeditems.aspx) property.</span></span> <span data-ttu-id="1be9a-293">ユーザーが Shift キーを押しながら一連の項目を選択しない限り、AddedItems コレクションと RemovedItems コレクションに含まれる項目の数は 1 個までになります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-293">The AddedItems and RemovedItems collections contain at most 1 item unless the user selects a range of items by holding down the Shift key.</span></span>

<span data-ttu-id="1be9a-294">次の例では、**SelectionChanged** イベントを処理してさまざまな項目コレクションにアクセスする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-294">This example shows how to handle the **SelectionChanged** event and access the various items collections.</span></span>

**<span data-ttu-id="1be9a-295">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-295">XAML</span></span>**
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

**<span data-ttu-id="1be9a-296">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-296">C#</span></span>**
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

### <a name="click-mode"></a><span data-ttu-id="1be9a-297">クリック モード</span><span class="sxs-lookup"><span data-stu-id="1be9a-297">Click mode</span></span>

<span data-ttu-id="1be9a-298">項目を選択するのではなく、ボタンのように項目をクリックできるように、リスト ビューを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-298">You can change a list view so that a user clicks items like buttons instead of selecting them.</span></span> <span data-ttu-id="1be9a-299">この方法は、たとえば、リストまたはグリッド内の項目をユーザーがクリックしたときに新しいページに移動するアプリで便利です。</span><span class="sxs-lookup"><span data-stu-id="1be9a-299">For example, this is useful when your app navigates to a new page when your user clicks an item in a list or grid.</span></span> <span data-ttu-id="1be9a-300">この動作を有効にするには、次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-300">To enable this behavior:</span></span>
- <span data-ttu-id="1be9a-301">**SelectionMode** を **None** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-301">Set **SelectionMode** to **None**.</span></span>
- <span data-ttu-id="1be9a-302">**IsItemClickEnabled** を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-302">Set **IsItemClickEnabled** to **true**.</span></span>
- <span data-ttu-id="1be9a-303">ユーザーが項目をクリックしたときに処理を実行する **ItemClick** イベントを設定します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-303">Handle the **ItemClick** event to do something when your user clicks an item.</span></span>

<span data-ttu-id="1be9a-304">クリックできる項目を持つリスト ビューの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-304">Here's a list view with clickable items.</span></span> <span data-ttu-id="1be9a-305">ItemClick イベント ハンドラーのコードによって、新しいページに移動します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-305">The code in the ItemClick event handler navigates to a new page.</span></span>

**<span data-ttu-id="1be9a-306">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-306">XAML</span></span>**
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

**<span data-ttu-id="1be9a-307">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-307">C#</span></span>**
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

### <a name="select-a-range-of-items-programmatically"></a><span data-ttu-id="1be9a-308">プログラムを使った一定範囲の項目の選択</span><span class="sxs-lookup"><span data-stu-id="1be9a-308">Select a range of items programmatically</span></span>

<span data-ttu-id="1be9a-309">場合によっては、プログラムからリスト ビューの項目の選択を操作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-309">Sometimes, you need to manipulate a list view’s item selection programmatically.</span></span> <span data-ttu-id="1be9a-310">たとえば、ユーザーがリスト内のすべての項目を選択できるように、**[すべて選択]** ボタンを用意する場合があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-310">For example, you might have a **Select all** button to let a user select all items in a list.</span></span> <span data-ttu-id="1be9a-311">この場合、SelectedItems コレクションの項目を 1 つずつ追加したり削除したりすることは、一般的に効率的とは言えません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-311">In this case, it’s usually not very efficient to add and remove items from the SelectedItems collection one by one.</span></span> <span data-ttu-id="1be9a-312">各項目を変更するたびに SelectionChanged イベントが発生し、インデックス値を操作するのではなく項目を直接操作すると、項目の仮想化が解除されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-312">Each item change causes a SelectionChanged event to occur, and when you work with the items directly instead of working with index values, the item is de-virtualized.</span></span>

<span data-ttu-id="1be9a-313">[SelectAll](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectall.aspx)、[SelectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectrange.aspx)、[DeselectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.deselectrange.aspx) の各メソッドを使用すると、SelectedItems プロパティを使用する場合よりも効率的に選択内容を変更できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-313">The [SelectAll](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectall.aspx), [SelectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectrange.aspx), and [DeselectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.deselectrange.aspx) methods provide a more efficient way to modify the selection than using the SelectedItems property.</span></span> <span data-ttu-id="1be9a-314">このメソッドでは、項目インデックスの範囲を使って選択と選択解除を行います。</span><span class="sxs-lookup"><span data-stu-id="1be9a-314">These methods select or deselect using ranges of item indexes.</span></span> <span data-ttu-id="1be9a-315">インデックスのみを使うため、仮想化された項目は仮想化の状態を維持します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-315">Items that are virtualized remain virtualized, because only the index is used.</span></span> <span data-ttu-id="1be9a-316">元の選択状態に関係なく、指定範囲のすべての項目が選択 (または選択解除) されます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-316">All items in the specified range are selected (or deselected), regardless of their original selection state.</span></span> <span data-ttu-id="1be9a-317">SelectionChanged イベントは、このメソッドを 1 回呼び出すたびに 1 回のみ発生します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-317">The SelectionChanged event occurs only once for each call to these methods.</span></span>

> <span data-ttu-id="1be9a-318">**重要**&nbsp;&nbsp;このメソッドは、SelectionMode プロパティが Multiple または Extended に設定されているときにのみ呼び出してください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-318">**Important**&nbsp;&nbsp;You should call these methods only when the SelectionMode property is set to Multiple or Extended.</span></span> <span data-ttu-id="1be9a-319">SelectionMode が Single または None のときに SelectRange を呼び出すと、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-319">If you call SelectRange when the SelectionMode is Single or None, an exception is thrown.</span></span>

<span data-ttu-id="1be9a-320">インデックスの範囲を使って項目を選択する場合、[SelectedRanges](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectedranges.aspx) プロパティを使って、リスト内の選択範囲をすべて取得します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-320">When you select items using index ranges, use the [SelectedRanges](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectedranges.aspx) property to get all selected ranges in the list.</span></span>

<span data-ttu-id="1be9a-321">ItemsSource に [IItemsRangeInfo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.iitemsrangeinfo.aspx) を実装し、このようなメソッドを使って選択内容を変更する場合、SelectionChangedEventArgs には **AddedItems** プロパティと **RemovedItems** プロパティが設定されません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-321">If the ItemsSource implements [IItemsRangeInfo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.iitemsrangeinfo.aspx), and you use these methods to modify the selection, the **AddedItems** and **RemovedItems** properties are not set in the SelectionChangedEventArgs.</span></span> <span data-ttu-id="1be9a-322">このプロパティを設定するには、項目オブジェクトの仮想化を解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be9a-322">Setting these properties requires de-virtualizing the item object.</span></span> <span data-ttu-id="1be9a-323">代わりに **SelectedRanges** プロパティを使って項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-323">Use the **SelectedRanges** property to get the items instead.</span></span>

<span data-ttu-id="1be9a-324">SelectAll メソッドを呼び出すと、コレクション内のすべての項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-324">You can select all items in a collection by calling the SelectAll method.</span></span> <span data-ttu-id="1be9a-325">ただし、すべての項目の選択を解除するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="1be9a-325">However, there is no corresponding method to deselect all items.</span></span> <span data-ttu-id="1be9a-326">すべての項目の選択を解除するには、DeselectRange を呼び出して [ItemIndexRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.aspx) を渡します。このとき、[FirstIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.firstindex.aspx) 値を 0 とし、[Length](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.length.aspx) 値をコレクション内の項目数と同じ値にします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-326">You can deselect all items by calling DeselectRange and passing an [ItemIndexRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.aspx) with a [FirstIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.firstindex.aspx) value of 0 and a [Length](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.length.aspx) value equal to the number of items in the collection.</span></span> 

**<span data-ttu-id="1be9a-327">XAML</span><span class="sxs-lookup"><span data-stu-id="1be9a-327">XAML</span></span>**
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

**<span data-ttu-id="1be9a-328">C#</span><span class="sxs-lookup"><span data-stu-id="1be9a-328">C#</span></span>**
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

<span data-ttu-id="1be9a-329">選択した項目の外観を変更する方法について詳しくは、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-329">For info about how to change the look of selected items, see [Item containers and templates](item-containers-templates.md).</span></span>

### <a name="drag-and-drop"></a><span data-ttu-id="1be9a-330">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="1be9a-330">Drag and drop</span></span>

<span data-ttu-id="1be9a-331">ListView コントロールと GridView コントロールは、項目内、項目間、および他の ListView コントロールと GridView コントロール間での項目のドラッグ アンド ドロップをサポートします。</span><span class="sxs-lookup"><span data-stu-id="1be9a-331">ListView and GridView controls support drag and drop of items within themselves, and between themselves and other ListView and GridView controls.</span></span> <span data-ttu-id="1be9a-332">ドラッグ アンド ドロップのパターンの実装について詳しくは、「[ドラッグ アンド ドロップ](https://msdn.microsoft.com/windows/uwp/design/input/drag-and-drop)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1be9a-332">For more info about implementing the drag and drop pattern, see [Drag and drop](https://msdn.microsoft.com/windows/uwp/design/input/drag-and-drop).</span></span> 

## <a name="get-the-sample-code"></a><span data-ttu-id="1be9a-333">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="1be9a-333">Get the sample code</span></span>

- <span data-ttu-id="1be9a-334">[XAML ListView と GridView のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)- ListView と GridView コントロールを示しています。</span><span class="sxs-lookup"><span data-stu-id="1be9a-334">[XAML ListView and GridView sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView) - Demonstrates the ListView and GridView controls.</span></span>
- <span data-ttu-id="1be9a-335">[XAML ドラッグ アンド ドロップのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlDragAndDrop) - ListView コントロールを使用したドラッグ アンド ドロップを示します。</span><span class="sxs-lookup"><span data-stu-id="1be9a-335">[XAML Drag and drop sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlDragAndDrop) - Demonstrates drag and drop with the ListView control.</span></span>
- <span data-ttu-id="1be9a-336">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="1be9a-336">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="1be9a-337">関連記事</span><span class="sxs-lookup"><span data-stu-id="1be9a-337">Related articles</span></span>

- [<span data-ttu-id="1be9a-338">リスト</span><span class="sxs-lookup"><span data-stu-id="1be9a-338">Lists</span></span>](lists.md)
- [<span data-ttu-id="1be9a-339">項目コンテナーやテンプレート</span><span class="sxs-lookup"><span data-stu-id="1be9a-339">Item containers and templates</span></span>](item-containers-templates.md)
- [<span data-ttu-id="1be9a-340">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="1be9a-340">Drag and drop</span></span>](https://msdn.microsoft.com/windows/uwp/app-to-app/drag-and-drop)
