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
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6995874"
---
# <a name="list-view-and-grid-view"></a>リスト ビューとグリッド ビュー

ほとんどのアプリでは、イメージ ギャラリー、メール メッセージなどのデータのセットを操作および表示します。 XAML UI フレームワークでは、アプリ内でデータを簡単に表示、操作するための ListView コントロールと GridView コントロールが用意されています。  

> **重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)、[ItemsSource プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx)、[Items プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx)

ListView と GridView はどちらも ListViewBase クラスから派生しているため、同じ機能を持ちますが、データの表示方法が異なります。 この記事では、特に指定がない限り、ListView についての説明は ListView コントロールにも GridView コントロールにも適用されます。 ListView や ListViewItem などのクラスの説明については、プレフィックスの "List" を "Grid" に置き換えることで、対応するグリッド クラス (GridView または GridViewItem) に適用できます。 

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ListView では、データを縦方向の 1 列に並べて表示します。 メールや検索結果の一覧など、順序が付けられた項目の一覧を表示するときによく使います。 

![グループ化されたデータを表示するリスト ビュー](images/simple-list-view-phone.png)

GridView は、縦方向にスクロールできる複数行と複数列で項目のコレクションを表示します。 データはまず横方向に並べられ、すべての列にデータが入ると、次の行に折り返して並べられます。 フォト ギャラリーのように、各項目の表示内容が豊富で表示領域を広く使う必要がある場合によく使います。 

![コンテンツ ライブラリの例](images/controls_list_contentlibrary.png)

使用するコントロールを選ぶための詳しい比較とガイダンスについては、「[リスト](lists.md)」をご覧ください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ListView">ListView</a> または <a href="xamlcontrolsgallery:/item/GridView">GridView</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-list-view"></a>リスト ビューの作成

リスト ビューは [ItemsControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。 リスト ビューを使って項目を表示するには、[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加しておく必要があります。 ビューのデータを設定するには、項目を直接 [Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに追加するか、データ ソースに [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティを設定します。 

**重要**&nbsp;&nbsp;リストにデータを設定するときには Items または ItemsSource を使用しますが、同時に両方を使用することはできません。 ItemsSource プロパティを設定して XAML で項目を追加した場合、追加された項目は無視されます。 ItemsSource プロパティを設定してコードで Items コレクションに項目を追加した場合、例外がスローされます。

> **注**&nbsp;&nbsp;この記事の例の多くでは、説明を簡単にするために **Items** コレクションを直接設定しています。 ただし、リストの項目は、オンライン データベースの書籍一覧など、動的なソースから取得される方が一般的です。 このようなケースでは、**ItemsSource** プロパティを使用します。 

### <a name="add-items-to-the-items-collection"></a>Items コレクションへの項目の追加

[Items](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションに項目を追加するには、XAML かコードを使います。 通常、項目が少数で、その項目が変わらず、XAML で簡単に定義できる場合や、実行時にコードで項目を生成する場合は、この方法で項目を追加します。 

XAML で項目をインラインで定義したリスト ビューを次に示します。 XAML で項目を定義すると、定義した項目は Items コレクションに自動的に追加されます。

**XAML**
```xaml
<ListView x:Name="listView1"> 
   <x:String>Item 1</x:String> 
   <x:String>Item 2</x:String> 
   <x:String>Item 3</x:String> 
   <x:String>Item 4</x:String> 
   <x:String>Item 5</x:String> 
</ListView>  
```

作成したリスト ビューのコードを次に示します。 生成されるリストは、以前に XAML で作ったものと同じです。

**C#**
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

ListView は次のようになります。

![単純なリスト ビュー](images/listview-simple.png)

### <a name="set-the-items-source"></a>項目ソースの設定

通常、リスト ビューを使って、データベースやインターネットなどのソースからデータを表示します。 データ ソースからリスト ビューのデータを設定するには、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ項目のコレクションに設定します。

以下の例では、コードでコレクションのインスタンスに直接リスト ビューの ItemsSource を設定しています。

**C#**
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

ItemsSource プロパティを、XAML でコレクションにバインドすることもできます。 データ バインディングについて詳しくは、「[データ バインディングの概要](https://msdn.microsoft.com/windows/uwp/data-binding/data-binding-quickstart)」をご覧ください。

ここでは、ページのプライベート データ コレクションを公開する `Items` という名前のパブリック プロパティに ItemsSource をバインドします。

**XAML**
```xaml
<ListView x:Name="itemListView" ItemsSource="{x:Bind Items}"/>
```

**C#**
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

リスト ビューにグループ化されたデータを表示する必要がある場合、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) にバインドする必要があります。 CollectionViewSource は XAML のコレクション クラスのプロキシとして機能し、グループ化サポートを有効にします。 詳しくは、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) をご覧ください。

## <a name="data-template"></a>データ テンプレート

項目のデータ テンプレートによって、データの表示方法を定義します。 既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてリスト ビューに表示されます。 データ項目の特定のプロパティに [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) を設定すると、そのプロパティの文字列表現を表示できます。

しかし、通常はもっとリッチな表現でデータを表示する必要があります。 リスト ビューでの項目の表示方法を正確に指定するには、[DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。 DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。 レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。 DataTemplate は、リスト コントロールの [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。

この例では、データ項目は単純な文字列です。 DataTemplate を使って、文字列の左側に画像を追加し、文字列を青緑で表示します。

> **注**&nbsp;&nbsp;DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使用する場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。

**XAML**
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

このデータ テンプレートを使ってデータ項目を表示すると、次のようになります。

![データ テンプレートを使ったリスト ビュー項目](images/listview-itemstemplate.png)

データ テンプレートは、リスト ビューの外観を定義する主要な方法です。 リストに多数の項目を表示した場合、パフォーマンスが大幅に低下することもあります。 この記事では、ほとんどの例で単純な文字列データを使用しており、データ テンプレートを指定していません。 データ テンプレートと項目コンテナーを使用してリストまたはグリッドの項目の外観を定義する詳しい方法とその例については、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。 

## <a name="change-the-layout-of-items"></a>項目のレイアウト変更

リスト ビューまたはグリッド ビューに項目を追加すると、項目コンテナー内で各項目が自動的に折り返され、すべての項目コンテナーがレイアウトされます。 この項目コンテナーのレイアウト方法は、コントロールの [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) によって決まります。  
- **ListView** では既定で [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) が使用され、次のような縦 1 列のリストが生成されます。

![単純なリスト ビュー](images/listview-simple.png)

- **GridView** では [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) が使用されます。次のように、項目が水平方向に追加され、折り返されて縦方向にスクロールします。

![単純なグリッド ビュー](images/gridview-simple.png)

項目のレイアウトを変更するには、項目パネルのプロパティを調整するか、既定のパネルを別のパネルに置き換えます。

> 注&nbsp;&nbsp;ItemsPanel を変更する場合、仮想化を無効にしないように注意してください。 **ItemsStackPanel** と **ItemsWrapGrid** はどちらも仮想化をサポートしており、安全に使用できます。 他のパネルを使用すると、仮想化が無効になり、リスト ビューのパフォーマンスが低下する場合があります。 詳しくは、「[Performance (パフォーマンス)](https://msdn.microsoft.com/windows/uwp/debug-test-perf/performance-and-xaml-ui)」のリスト ビューに関する記事をご覧ください。 

この例では、**ItemsStackPanel** の [Orientation](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.orientation.aspx) プロパティを変更することで、**ListView** に項目コンテナーを横 1 列にレイアウトする方法を示しています。
リスト ビューは既定で縦方向にスクロールするため、横方向にスクロールさせるには、リスト ビュー内部の [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) のプロパティもいくつか調整する必要があります。
- [ScrollViewer.HorizontalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollmode.aspx) を **Enabled** または **Auto** に設定
- [ScrollViewer.HorizontalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.horizontalscrollbarvisibility.aspx) を **Auto** に設定 
- [ScrollViewer.VerticalScrollMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollmode.aspx) を **Disabled** に設定 
- [ScrollViewer.VerticalScrollBarVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.verticalscrollbarvisibility.aspx) を **Hidden** に設定 

> **注**&nbsp;&nbsp;ここに示す例ではリスト ビューの幅が規定されていないため、水平スクロール バーは表示されません。 このコードを実行する場合、ListView に `Width="180"` を設定してスクロール バーを表示することができます。

**XAML**
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

このリストは次のように表示されます。

![横長のリスト ビュー](images/listview-horizontal.png)

 次の例の **ListView** では、**ItemsStackPanel** ではなく **ItemsWrapGrid** を使用して、縦方向に折り返すリストで項目をレイアウトします。 
 
> **注**&nbsp;&nbsp;コントロールでコンテナーを折り返すには、リスト ビューの高さを規定する必要があります。

**XAML**
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

このリストは次のように表示されます。

![グリッド レイアウトを使ったリスト ビュー](images/listview-itemswrapgrid.png)

グループ化したデータをリスト ビューに表示する場合、ItemsPanel によって指定されるのは個々の項目のレイアウト方法ではなく、項目グループのレイアウト方法です。たとえば、前に示した横方向の ItemsStackPanel を使用して、グループ化されたデータを表示する場合、次に示すようにグループは横方向に配置されますが、各グループの項目は縦に重ねて表示されます。

![グループ化された横方向のリスト ビュー](images/listview-horizontal-groups.png)

## <a name="item-selection-and-interaction"></a>項目の選択と操作

ユーザーがリスト ビューを操作する方法は、いくつか選ぶことができます。 既定では、ユーザーは 1 つの項目を選択できます。 [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) プロパティを変更することで、複数選択を有効にしたり、選択を無効にしたりできます。 [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) プロパティを設定することで、ユーザーが項目をクリックしたときに項目を選択するのではなく、ボタンと同じように操作を呼び出すことができます。

> **注**&nbsp;&nbsp; ListView と GridView のどちらも、SelectionMode プロパティについては [ListViewSelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewselectionmode.aspx) 列挙値を使用します。 IsItemClickEnabled は既定で **False** であるため、設定する必要があるのはクリック モードを有効にする場合のみです。

次の表に、ユーザーがリスト ビューを操作する方法と、その操作に対する応答方法を示します。

有効にする操作: | 使用する設定: | 処理するイベント: | 選択された項目の取得に使うプロパティ:
----------------------------|---------------------|--------------------|--------------------------------------------
操作なし | [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) = **None**、[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) = **False** | 該当なし | 該当なし 
単一選択 | SelectionMode = **Single**、IsItemClickEnabled = **False** | [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx)、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx)  
複数選択 | SelectionMode = **Multiple**、IsItemClickEnabled = **False** | [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
拡張選択 | SelectionMode = **Extended**、IsItemClickEnabled = **False** | [SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) | [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx)  
クリック | SelectionMode = **None**、IsItemClickEnabled = **True** | [ItemClick](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.itemclick.aspx) | 該当なし 

> **注**&nbsp;&nbsp;Windows 10 以降では、IsItemClickEnabled を有効にして ItemClick イベントを発生させる場合でも、SelectionMode を Single、Multiple、Extended のいずれにも設定できます。 その場合、ItemClick イベントが最初に発生し、次に SelectionChanged イベントが発生します。 ただし ItemClick イベント ハンドラーで別のページに移動するような場合では、SelectionChanged イベントが発生せず、項目が選択されません。

次に示すように、このプロパティを XAML またはコードで設定することができます。

**XAML**
```xaml
<ListView x:Name="myListView" SelectionMode="Multiple"/>

<GridView x:Name="myGridView" SelectionMode="None" IsItemClickEnabled="True"/> 
```

**C#**
```csharp
myListView.SelectionMode = ListViewSelectionMode.Multiple; 

myGridView.SelectionMode = ListViewSelectionMode.None;
myGridView.IsItemClickEnabled = true;
```

### <a name="read-only"></a>読み取り専用

SelectionMode プロパティを **ListViewSelectionMode.None** に設定することで、項目の選択を無効にすることができます。 これによりコントロールが読み取り専用モードになり、ユーザーの操作には使われず、データの表示のみに使われます。 コントロール自体は無効にならず、項目の選択のみが無効になります。

### <a name="single-selection"></a>単一選択

次の表では、SelectionMode が **Single** の場合のキーボード操作、マウス操作、タッチ操作について説明します。

修飾キー | 操作
-------------|------------
なし | <li>ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目を選択できます。</li>
Ctrl | <li>ユーザーはスペース バー、マウスのクリック、タッチ操作のタップを使って 1 つの項目の選択を解除できます。</li><li>方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</li>

SelectionMode が **Single** の場合、[SelectedItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selecteditem.aspx) プロパティから選択したデータ項目を取得できます。 [SelectedIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectedindex.aspx) プロパティを使って、選択した項目のコレクション内のインデックスを取得できます。 項目が選択されていない場合、SelectedItem は **null** になり、SelectedIndex は -1 になります。 
 
**Items** コレクションに含まれない項目を **SelectedItem** として設定しようとすると、その操作は無視され、SelectedItem が **null** になります。 ただし、リスト内の **Items** の範囲外のインデックスを **SelectedIndex** に設定しようとすると、**System.ArgumentException** 例外が発生します。 

### <a name="multiple-selection"></a>複数選択

次の表では、SelectionMode が **Multiple** の場合のキーボード操作、マウス操作、タッチ操作について説明します。

修飾キー | 操作
-------------|------------
なし | <li>ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</li><li>方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</li>
Shift | <li>ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</li><li>方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</li>

### <a name="extended-selection"></a>拡張選択

次の表では、SelectionMode が **Extended** の場合のキーボード操作、マウス操作、タッチ操作について説明します。

修飾キー | 操作
-------------|------------
なし | <li>**Single** の選択と同じです。</li>
Ctrl | <li>ユーザーは、スペース バー、マウスのクリック、タッチ操作のタップを使って、フォーカスのある項目の選択状態を切り替えることで、複数の項目を選択できます。</li><li>方向キーを使うと、選択した項目とは関係なくフォーカスを移動できます。</li>
Shift | <li>ユーザーは、選択する最初の項目をクリックまたはタップした後、選択する最後の項目をクリックまたはタップすることで、複数の項目を連続的に選択できます。</li><li>方向キーを使用すると、Shift キーが押されたときに選択された項目を起点として連続的に選択することができます。</li>

SelectionMode が **Multiple** または **Extended** の場合、選択したデータ項目を [SelectedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selecteditems.aspx) プロパティから取得できます。 

**SelectedIndex**、**SelectedItem**、**SelectedItems** の各プロパティは同期されます。 たとえば、SelectedIndex を -1 に設定すると、SelectedItem は **null** に設定され、SelectedItems が空になります。SelectedItem を **null** に設定すると、SelectedIndex が -1 に設定され、SelectedItems が空になります。

複数選択モードの場合、**SelectedItem** には最初に選択された項目が含まれ、**Selectedindex** には最初に選択した項目のインデックスが含まれます。 

### <a name="respond-to-selection-changes"></a>選択範囲の変更への対応

リスト ビューにおける選択内容の変更に対応するには、[SelectionChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.selectionchanged.aspx) イベントを処理します。 イベント ハンドラーのコードでは、[SelectionChangedEventArgs.AddedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.addeditems.aspx) プロパティから選ばれた項目の一覧を取得できます。 選択が解除された項目は、[SelectionChangedEventArgs.RemovedItems](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.selectionchangedeventargs.removeditems.aspx) プロパティから取得できます。 ユーザーが Shift キーを押しながら一連の項目を選択しない限り、AddedItems コレクションと RemovedItems コレクションに含まれる項目の数は 1 個までになります。

次の例では、**SelectionChanged** イベントを処理してさまざまな項目コレクションにアクセスする方法を示します。

**XAML**
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

**C#**
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

### <a name="click-mode"></a>クリック モード

項目を選択するのではなく、ボタンのように項目をクリックできるように、リスト ビューを変更することができます。 この方法は、たとえば、リストまたはグリッド内の項目をユーザーがクリックしたときに新しいページに移動するアプリで便利です。 この動作を有効にするには、次のように設定します。
- **SelectionMode** を **None** に設定します。
- **IsItemClickEnabled** を **true** に設定します。
- ユーザーが項目をクリックしたときに処理を実行する **ItemClick** イベントを設定します。

クリックできる項目を持つリスト ビューの例を次に示します。 ItemClick イベント ハンドラーのコードによって、新しいページに移動します。

**XAML**
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

**C#**
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

### <a name="select-a-range-of-items-programmatically"></a>プログラムを使った一定範囲の項目の選択

場合によっては、プログラムからリスト ビューの項目の選択を操作する必要があります。 たとえば、ユーザーがリスト内のすべての項目を選択できるように、**[すべて選択]** ボタンを用意する場合があります。 この場合、SelectedItems コレクションの項目を 1 つずつ追加したり削除したりすることは、一般的に効率的とは言えません。 各項目を変更するたびに SelectionChanged イベントが発生し、インデックス値を操作するのではなく項目を直接操作すると、項目の仮想化が解除されます。

[SelectAll](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectall.aspx)、[SelectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectrange.aspx)、[DeselectRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.deselectrange.aspx) の各メソッドを使用すると、SelectedItems プロパティを使用する場合よりも効率的に選択内容を変更できます。 このメソッドでは、項目インデックスの範囲を使って選択と選択解除を行います。 インデックスのみを使うため、仮想化された項目は仮想化の状態を維持します。 元の選択状態に関係なく、指定範囲のすべての項目が選択 (または選択解除) されます。 SelectionChanged イベントは、このメソッドを 1 回呼び出すたびに 1 回のみ発生します。

> **重要**&nbsp;&nbsp;このメソッドは、SelectionMode プロパティが Multiple または Extended に設定されているときにのみ呼び出してください。 SelectionMode が Single または None のときに SelectRange を呼び出すと、例外がスローされます。

インデックスの範囲を使って項目を選択する場合、[SelectedRanges](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectedranges.aspx) プロパティを使って、リスト内の選択範囲をすべて取得します。

ItemsSource に [IItemsRangeInfo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.iitemsrangeinfo.aspx) を実装し、このようなメソッドを使って選択内容を変更する場合、SelectionChangedEventArgs には **AddedItems** プロパティと **RemovedItems** プロパティが設定されません。 このプロパティを設定するには、項目オブジェクトの仮想化を解除する必要があります。 代わりに **SelectedRanges** プロパティを使って項目を取得します。

SelectAll メソッドを呼び出すと、コレクション内のすべての項目を選択できます。 ただし、すべての項目の選択を解除するメソッドはありません。 すべての項目の選択を解除するには、DeselectRange を呼び出して [ItemIndexRange](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.aspx) を渡します。このとき、[FirstIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.firstindex.aspx) 値を 0 とし、[Length](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.itemindexrange.length.aspx) 値をコレクション内の項目数と同じ値にします。 

**XAML**
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

**C#**
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

選択した項目の外観を変更する方法について詳しくは、「[項目コンテナーやテンプレート](item-containers-templates.md)」をご覧ください。

### <a name="drag-and-drop"></a>ドラッグ アンド ドロップ

ListView コントロールと GridView コントロールは、項目内、項目間、および他の ListView コントロールと GridView コントロール間での項目のドラッグ アンド ドロップをサポートします。 ドラッグ アンド ドロップのパターンの実装について詳しくは、「[ドラッグ アンド ドロップ](https://msdn.microsoft.com/windows/uwp/design/input/drag-and-drop)」をご覧ください。 

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML ListView と GridView のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)- ListView と GridView コントロールを示しています。
- [XAML ドラッグ アンド ドロップのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlDragAndDrop) - ListView コントロールを使用したドラッグ アンド ドロップを示します。
- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-articles"></a>関連記事

- [リスト](lists.md)
- [項目コンテナーやテンプレート](item-containers-templates.md)
- [ドラッグ アンド ドロップ](https://msdn.microsoft.com/windows/uwp/app-to-app/drag-and-drop)
