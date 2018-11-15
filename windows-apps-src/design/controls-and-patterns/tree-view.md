---
author: Jwmsft
description: 展開可能なツリー ビューを作成するには、階層データ ソースを ItemsSource をバインドまたは作成し、TreeViewNode オブジェクトを管理することができます。
title: ツリー ビュー
label: Tree view
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.localizationpriority: medium
pm-contact: predavid
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
dev_langs:
- csharp
- vb
ms.openlocfilehash: 73f6d8f9c42a632383d52194c83a4fe68261f9a7
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6667482"
---
# <a name="treeview"></a><span data-ttu-id="b080f-103">TreeView</span><span class="sxs-lookup"><span data-stu-id="b080f-103">TreeView</span></span>

<span data-ttu-id="b080f-104">XAML TreeView コントロールを使用すると、階層リストが有効になり、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="b080f-104">The XAML TreeView control enables a hierarchical list with expanding and collapsing nodes that contain nested items.</span></span> <span data-ttu-id="b080f-105">フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。</span><span class="sxs-lookup"><span data-stu-id="b080f-105">It can be used to illustrate a folder structure or nested relationships in your UI.</span></span>

<span data-ttu-id="b080f-106">TreeView API は、以下の機能をサポートします。</span><span class="sxs-lookup"><span data-stu-id="b080f-106">The TreeView APIs support the following features:</span></span>

- <span data-ttu-id="b080f-107">N レベルの入れ子</span><span class="sxs-lookup"><span data-stu-id="b080f-107">N-level nesting</span></span>
- <span data-ttu-id="b080f-108">1 つまたは複数のノードの選択</span><span class="sxs-lookup"><span data-stu-id="b080f-108">Selection of single or multiple nodes</span></span>
- <span data-ttu-id="b080f-109">(プレビュー)ツリー ビューと TreeViewItem ItemsSource プロパティをデータ バインディング</span><span class="sxs-lookup"><span data-stu-id="b080f-109">(Preview) Data binding to the ItemsSource property on TreeView and TreeViewItem</span></span>
- <span data-ttu-id="b080f-110">(プレビュー)ツリー ビュー項目テンプレートのルートとして TreeViewItem</span><span class="sxs-lookup"><span data-stu-id="b080f-110">(Preview) TreeViewItem as the root of the TreeView item template</span></span>
- <span data-ttu-id="b080f-111">(プレビュー)任意の種類のコンテンツで、TreeViewItem</span><span class="sxs-lookup"><span data-stu-id="b080f-111">(Preview) Arbitrary types of content in a TreeViewItem</span></span>
- <span data-ttu-id="b080f-112">(プレビュー)ドラッグ アンド ドロップ ツリー ビューの間で</span><span class="sxs-lookup"><span data-stu-id="b080f-112">(Preview) Drag and drop between tree views</span></span>

| **<span data-ttu-id="b080f-113">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="b080f-113">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="b080f-114">このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="b080f-114">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="b080f-115">詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b080f-115">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="b080f-116">プラットフォーム Api</span><span class="sxs-lookup"><span data-stu-id="b080f-116">Platform APIs</span></span>** | **<span data-ttu-id="b080f-117">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="b080f-117">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="b080f-118">[TreeView クラス](/uwp/api/windows.ui.xaml.controls.treeview)、 [TreeViewNode クラス](/uwp/api/windows.ui.xaml.controls.treeviewnode)、 [TreeView.ItemsSource プロパティ](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)</span><span class="sxs-lookup"><span data-stu-id="b080f-118">[TreeView class](/uwp/api/windows.ui.xaml.controls.treeview), [TreeViewNode class](/uwp/api/windows.ui.xaml.controls.treeviewnode), [TreeView.ItemsSource property](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)</span></span> | <span data-ttu-id="b080f-119">[TreeView クラス](/uwp/api/microsoft.ui.xaml.controls.treeview)、 [TreeViewNode クラス](/uwp/api/microsoft.ui.xaml.controls.treeviewnode)、 [TreeView.ItemsSource プロパティ](/uwp/api/microsoft.ui.xaml.controls.treeview.itemssource)</span><span class="sxs-lookup"><span data-stu-id="b080f-119">[TreeView class](/uwp/api/microsoft.ui.xaml.controls.treeview), [TreeViewNode class](/uwp/api/microsoft.ui.xaml.controls.treeviewnode), [TreeView.ItemsSource property](/uwp/api/microsoft.ui.xaml.controls.treeview.itemssource)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="b080f-120">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="b080f-120">Is this the right control?</span></span>

- <span data-ttu-id="b080f-121">項目に入れ子になった一覧項目が含まれているとき、それらの項目とピアやノードとの階層関係を視覚的に示すことが重要になる場合は、ツリー ビューを使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-121">Use a TreeView when items have nested list items, and if it is important to illustrate the hierarchical relationship of items to their peers and nodes.</span></span>

- <span data-ttu-id="b080f-122">項目の入れ子になった関係を強調表示することが優先的な処理ではない場合は、ツリー ビューを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="b080f-122">Avoid using TreeView if highlighting the nested relationship of an item is not a priority.</span></span> <span data-ttu-id="b080f-123">ほとんどの演習用シナリオでは、標準的なリスト ビューが適しています</span><span class="sxs-lookup"><span data-stu-id="b080f-123">For most drill-in scenarios, a regular list view is appropriate</span></span>

## <a name="examples"></a><span data-ttu-id="b080f-124">例</span><span class="sxs-lookup"><span data-stu-id="b080f-124">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="b080f-125">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="b080f-125">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="b080f-126"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合<a href="xamlcontrolsgallery:/item/TreeView">、アプリを開き操作でのツリー ビューを表示</a>するここをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b080f-126">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/TreeView">open the app and see the TreeView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="b080f-127">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="b080f-127">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="b080f-128">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="b080f-128">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="treeview-ui"></a><span data-ttu-id="b080f-129">TreeView UI</span><span class="sxs-lookup"><span data-stu-id="b080f-129">TreeView UI</span></span>

<span data-ttu-id="b080f-130">ツリー ビューはインデントとアイコンを組み合わせて使用することで、フォルダー/親ノードとフォルダー以外の項目/子ノードとの間の入れ子になった関係を表します。</span><span class="sxs-lookup"><span data-stu-id="b080f-130">The tree view uses a combination of indentation and icons to represent the nested relationship between folder/parent nodes and non-folder/child nodes.</span></span> <span data-ttu-id="b080f-131">折りたたまれているノードでは右向きの山形記号を使用し、展開されているノードでは下向きの山形記号を使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-131">Collapsed nodes use a chevron pointing to the right, and expanded nodes use a chevron pointing down.</span></span>

![TreeView での山形記号アイコン](images/treeview-simple.png)

<span data-ttu-id="b080f-133">ツリー ビュー項目データ テンプレートにアイコンを含めてノードを表すことができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-133">You can include an icon in the tree view item data template to represent nodes.</span></span> <span data-ttu-id="b080f-134">この場合、ディスク上のフォルダー構造などのリテラル フォルダーを表すノードに対してのみ、フォルダー アイコンのみを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-134">If you do this, you should use a folder icon only for nodes that represent literal folders, such as the folder structure on a disk.</span></span>

![TreeView で山形記号のアイコンとフォルダー アイコンの組み合わせ](images/treeview-icons.png)

## <a name="create-a-tree-view"></a><span data-ttu-id="b080f-136">ツリー ビューの作成</span><span class="sxs-lookup"><span data-stu-id="b080f-136">Create a tree view</span></span>

<span data-ttu-id="b080f-137">ツリー ビューを作成するには、階層データ ソースに[ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)をバインドすることによってまたは作成し、TreeViewNode オブジェクトを管理することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-137">You can create a tree view by binding the [ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource) to a hierarchical data source, or you can create and manage TreeViewNode objects yourself.</span></span>

<span data-ttu-id="b080f-138">ツリー ビューを作成するには、[TreeView](/uwp/api/windows.ui.xaml.controls.treeview) コントロールと [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) オブジェクトの階層を使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-138">To create a tree view, you use a [TreeView](/uwp/api/windows.ui.xaml.controls.treeview) control and a hierarchy of [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) objects.</span></span> <span data-ttu-id="b080f-139">ノード階層を作成するには、TreeView コントロールの[RootNodes](/uwp/api/windows.ui.xaml.controls.treeview.rootnodes)コレクションに 1 つまたは複数のルート ノードを追加します。</span><span class="sxs-lookup"><span data-stu-id="b080f-139">You create the node hierarchy by adding one or more root nodes to the TreeView control’s [RootNodes](/uwp/api/windows.ui.xaml.controls.treeview.rootnodes) collection.</span></span> <span data-ttu-id="b080f-140">各 TreeViewNode では、より多くのノードをその Children コレクションに追加することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-140">Each TreeViewNode can then have more nodes added to its Children collection.</span></span> <span data-ttu-id="b080f-141">ツリー ビュー ノードは、必要な任意の深さまで入れ子にすることができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-141">You can nest tree view nodes to whatever depth you require.</span></span>

<span data-ttu-id="b080f-142">以降、Windows Insider Preview では、バインドできます階層データ ソース ツリー ビューのコンテンツを提供する[ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)プロパティをするリスト ビューの ItemsSource と同様です。</span><span class="sxs-lookup"><span data-stu-id="b080f-142">Starting in the Windows Insider Preview, you can bind a hierarchical data source to the [ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource) property to provide the tree view content, just as you would with ListView's ItemsSource.</span></span> <span data-ttu-id="b080f-143">同様に、項目を表示する DataTemplate を提供する[ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate) (およびオプションの[ItemTemplateSelector](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate)) を使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-143">Similarly, use [ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate) (and the optional [ItemTemplateSelector](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate)) to provide a DataTemplate that renders the item.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b080f-144">ItemsSource は、TreeView.RootNodes を TreeView コントロールにコンテンツを格納するための代替のメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="b080f-144">ItemsSource is an alternative mechanism to TreeView.RootNodes for putting content into the TreeView control.</span></span> <span data-ttu-id="b080f-145">同時に ItemsSource と RootNodes の両方を設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="b080f-145">You cannot set both ItemsSource and RootNodes at the same time.</span></span> <span data-ttu-id="b080f-146">ItemsSource を使用して、ノードが作成された TreeView.RootNodes プロパティからアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-146">When you use ItemsSource, nodes created for you, and you can access them from TreeView.RootNodes property.</span></span>

<span data-ttu-id="b080f-147">XAML で宣言された単純なツリー ビューの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-147">Here's an example of a simple tree view declared in XAML.</span></span> <span data-ttu-id="b080f-148">通常は、コードにノードを追加しますが、ノードの階層を作成する方法を視覚化するうえで役立つため、XAML の階層をここに示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-148">You typically add the nodes in code, but we show the XAML hierarchy here because it can be helpful for visualizing how the hierarchy of nodes is created.</span></span>

```xaml
<TreeView>
    <TreeView.RootNodes>
        <TreeViewNode Content="Flavors" IsExpanded="True">
            <TreeViewNode.Children>
                <TreeViewNode Content="Vanilla"/>
                <TreeViewNode Content="Strawberry"/>
                <TreeViewNode Content="Chocolate"/>
            </TreeViewNode.Children>
        </TreeViewNode>
    </TreeView.RootNodes>
</TreeView>
```

<span data-ttu-id="b080f-149">ほとんどの場合、ツリー ビューでは、通常、ルート TreeView コントロールを XAML で宣言しますが、TreeViewNode オブジェクトを追加コードやデータ バインディングを使うために、データ ソースからのデータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-149">In most cases, your tree view displays data from a data source, so you typically declare the root TreeView control in XAML, but add the TreeViewNode objects in code or using data binding.</span></span>

### <a name="bind-to-a-hierarchical-data-source"></a><span data-ttu-id="b080f-150">階層データ ソースにバインドします。</span><span class="sxs-lookup"><span data-stu-id="b080f-150">Bind to a hierarchical data source</span></span>

<span data-ttu-id="b080f-151">データ バインディングを使用して、ツリー ビューを作成するには、TreeView.ItemsSource プロパティに階層のコレクションを設定します。</span><span class="sxs-lookup"><span data-stu-id="b080f-151">To create a tree view using data binding, set a hierarchical collection to the TreeView.ItemsSource property.</span></span> <span data-ttu-id="b080f-152">ItemTemplate で子項目のコレクションに設定 TreeViewItem.ItemsSource プロパティ。</span><span class="sxs-lookup"><span data-stu-id="b080f-152">Then in the ItemTemplate, set the child items collection to the TreeViewItem.ItemsSource property.</span></span>

```xaml
<TreeView ItemsSource="{x:Bind DataSource}">
    <TreeView.ItemTemplate>
        <DataTemplate x:DataType="local:Item">
            <TreeViewItem ItemsSource="{x:Bind Children}"
                          Content="{x:Bind Name}"/>
        </DataTemplate>
    </TreeView.ItemTemplate>
</TreeView>
```

<span data-ttu-id="b080f-153">_ツリー ビューのデータ バインディングを使用して_完全なコードの例」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b080f-153">See _Tree view using data binding_ the Examples section for the full code.</span></span>

#### <a name="items-and-item-containers"></a><span data-ttu-id="b080f-154">項目と項目コンテナー</span><span class="sxs-lookup"><span data-stu-id="b080f-154">Items and item containers</span></span>

<span data-ttu-id="b080f-155">これらの Api は、コンテナーからノードまたはデータ項目を取得できる TreeView.ItemsSource を使用する場合と逆も同様です。</span><span class="sxs-lookup"><span data-stu-id="b080f-155">If you use TreeView.ItemsSource, these APIs are available to get the node or data item from the container, and vice versa.</span></span>

| **[<span data-ttu-id="b080f-156">TreeViewItem</span><span class="sxs-lookup"><span data-stu-id="b080f-156">TreeViewItem</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewitem)** | |
| - | - |
| [<span data-ttu-id="b080f-157">TreeView.ItemFromContainer</span><span class="sxs-lookup"><span data-stu-id="b080f-157">TreeView.ItemFromContainer</span></span>](/uwp/api/windows.ui.xaml.controls.treeview.itemfromcontainer) | <span data-ttu-id="b080f-158">指定された TreeViewItem コンテナーのデータ項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="b080f-158">Gets the data item for the specified TreeViewItem container.</span></span> |
| [<span data-ttu-id="b080f-159">TreeView.ContainerFromItem</span><span class="sxs-lookup"><span data-stu-id="b080f-159">TreeView.ContainerFromItem</span></span>](/uwp/api/windows.ui.xaml.controls.treeview.containerfromitem) | <span data-ttu-id="b080f-160">指定されたデータ項目の TreeViewItem コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="b080f-160">Gets the TreeViewItem container for the specified data item.</span></span> |

| **[<span data-ttu-id="b080f-161">TreeViewNode</span><span class="sxs-lookup"><span data-stu-id="b080f-161">TreeViewNode</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode)** | |
| - | - |
| [<span data-ttu-id="b080f-162">TreeView.NodeFromContainer</span><span class="sxs-lookup"><span data-stu-id="b080f-162">TreeView.NodeFromContainer</span></span>](/uwp/api/windows.ui.xaml.controls.treeview.nodefromcontainer) | <span data-ttu-id="b080f-163">指定された TreeViewItem コンテナーの TreeViewNode を取得します。</span><span class="sxs-lookup"><span data-stu-id="b080f-163">Gets the TreeViewNode for the specified TreeViewItem container.</span></span> |
| [<span data-ttu-id="b080f-164">TreeView.ContainerFromNode</span><span class="sxs-lookup"><span data-stu-id="b080f-164">TreeView.ContainerFromNode</span></span>](/uwp/api/windows.ui.xaml.controls.treeview.containerfromnode) | <span data-ttu-id="b080f-165">指定された TreeViewNode TreeViewItem コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="b080f-165">Gets the TreeViewItem container for the specified TreeViewNode.</span></span> |

### <a name="manage-tree-view-nodes"></a><span data-ttu-id="b080f-166">ツリー ビュー ノードを管理します。</span><span class="sxs-lookup"><span data-stu-id="b080f-166">Manage tree view nodes</span></span>

<span data-ttu-id="b080f-167">このツリー ビューは、XAML で作成されたものと同じですが、ノードはコードで作成されています。</span><span class="sxs-lookup"><span data-stu-id="b080f-167">This tree view is the same as the one created previously in XAML, but the nodes are created in code instead.</span></span>

```xaml
<TreeView x:Name="sampleTreeView"/>
```

```csharp
private void InitializeTreeView()
{
    TreeViewNode rootNode = new TreeViewNode() { Content = "Flavors" };
    rootNode.IsExpanded = true;
    rootNode.Children.Add(new TreeViewNode() { Content = "Vanilla" });
    rootNode.Children.Add(new TreeViewNode() { Content = "Strawberry" });
    rootNode.Children.Add(new TreeViewNode() { Content = "Chocolate" });

    sampleTreeView.RootNodes.Add(rootNode);
}
```

```vb
Private Sub InitializeTreeView()
    Dim rootNode As New TreeViewNode With {.Content = "Flavors", .IsExpanded = True}
    With rootNode.Children
        .Add(New TreeViewNode With {.Content = "Vanilla"})
        .Add(New TreeViewNode With {.Content = "Strawberry"})
        .Add(New TreeViewNode With {.Content = "Chocolate"})
    End With
    sampleTreeView.RootNodes.Add(rootNode)
End Sub
```

<span data-ttu-id="b080f-168">これらの API は、ツリー ビューのデータの階層の管理に使用できます。</span><span class="sxs-lookup"><span data-stu-id="b080f-168">These APIs are available for managing the data hierarchy of your tree view.</span></span>

| **[<span data-ttu-id="b080f-169">TreeView</span><span class="sxs-lookup"><span data-stu-id="b080f-169">TreeView</span></span>](/uwp/api/windows.ui.xaml.controls.treeview)** | |
| - | - |
| [<span data-ttu-id="b080f-170">RootNodes</span><span class="sxs-lookup"><span data-stu-id="b080f-170">RootNodes</span></span>](/uwp/api/windows.ui.xaml.controls.treeview.rootnodes) | <span data-ttu-id="b080f-171">ツリー ビューは、1 つまたは複数のルート ノードの場合があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-171">A tree view can have one or more root nodes.</span></span> <span data-ttu-id="b080f-172">TreeViewNode オブジェクトを RootNodes コレクションに追加し、ルート ノードを作成します。</span><span class="sxs-lookup"><span data-stu-id="b080f-172">Add a TreeViewNode object to the RootNodes collection to create a root node.</span></span> <span data-ttu-id="b080f-173">ルート ノードの **Parent** は常に **null** です。</span><span class="sxs-lookup"><span data-stu-id="b080f-173">The **Parent** of a root node is always **null**.</span></span> <span data-ttu-id="b080f-174">ルート ノードの**奥行き**は0です。</span><span class="sxs-lookup"><span data-stu-id="b080f-174">The **Depth** of a root node is 0.</span></span> |

| **[<span data-ttu-id="b080f-175">TreeViewNode</span><span class="sxs-lookup"><span data-stu-id="b080f-175">TreeViewNode</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode)** | |
| - | - |
| [<span data-ttu-id="b080f-176">Children</span><span class="sxs-lookup"><span data-stu-id="b080f-176">Children</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode.children) | <span data-ttu-id="b080f-177">TreeViewNode オブジェクトを親ノードの Children コレクションに追加し、ノード階層を作成します。</span><span class="sxs-lookup"><span data-stu-id="b080f-177">Add TreeViewNode objects to the Children collection of a parent node to create your node hierarchy.</span></span> <span data-ttu-id="b080f-178">ノードは、その **Children** コレクションのすべてのノードの **Parent** です。</span><span class="sxs-lookup"><span data-stu-id="b080f-178">A node is the **Parent** of all nodes in its **Children** collection.</span></span> |
| [<span data-ttu-id="b080f-179">HasChildren</span><span class="sxs-lookup"><span data-stu-id="b080f-179">HasChildren</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode.haschildren) | <span data-ttu-id="b080f-180">ノードが子を実体化した場合は **true**。</span><span class="sxs-lookup"><span data-stu-id="b080f-180">**true** if the node has realized children.</span></span> <span data-ttu-id="b080f-181">**false** は空のフォルダーまたは項目を示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-181">**false** indicates an empty folder or an item.</span></span> |
| [<span data-ttu-id="b080f-182">HasUnrealizedChildren</span><span class="sxs-lookup"><span data-stu-id="b080f-182">HasUnrealizedChildren</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode.hasunrealizedchildren) | <span data-ttu-id="b080f-183">ノードが展開されているときにノードに入力している場合は、このプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-183">Use this property if you're filling nodes as they're expanded.</span></span> <span data-ttu-id="b080f-184">この記事の後半にある「_展開時にノードを入力する_」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b080f-184">See _Fill a node when it's expanding_ later in this article.</span></span> |
| [<span data-ttu-id="b080f-185">奥行き</span><span class="sxs-lookup"><span data-stu-id="b080f-185">Depth</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode.depth) | <span data-ttu-id="b080f-186">子ノードとルート ノードの距離を示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-186">Indicates how far from the root node a child node is.</span></span> |
| [<span data-ttu-id="b080f-187">Parent</span><span class="sxs-lookup"><span data-stu-id="b080f-187">Parent</span></span>](/uwp/api/windows.ui.xaml.controls.treeviewnode.parent) | <span data-ttu-id="b080f-188">このノードが含まれている **Children** コレクションを所有する TreeViewNode を取得します。</span><span class="sxs-lookup"><span data-stu-id="b080f-188">Gets the TreeViewNode that owns the **Children** collection that this node is part of.</span></span> |

<span data-ttu-id="b080f-189">ツリー ビューは、**HasChildren** プロパティと **HasUnrealizedChildren** プロパティを使用して、開く/閉じるアイコンを表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="b080f-189">The tree view uses the **HasChildren** and **HasUnrealizedChildren** properties to determine whether the expand/collapse icon is shown.</span></span> <span data-ttu-id="b080f-190">いずれかのプロパティが **true** である場合、アイコンが表示されます。それ以外の場合は表示されません。</span><span class="sxs-lookup"><span data-stu-id="b080f-190">If either property is **true**, the icon is shown; otherwise, it's not shown.</span></span>

## <a name="tree-view-node-content"></a><span data-ttu-id="b080f-191">ツリー ビュー ノード コンテンツ</span><span class="sxs-lookup"><span data-stu-id="b080f-191">Tree view node content</span></span>

<span data-ttu-id="b080f-192">ツリー ビュー ノードが [Content](/uwp/api/windows.ui.xaml.controls.treeviewnode.content) プロパティで表すデータ項目を保存することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-192">You can store the data item that a tree view node represents in its [Content](/uwp/api/windows.ui.xaml.controls.treeviewnode.content) property.</span></span>

<span data-ttu-id="b080f-193">前の例では、コンテンツは単純な文字列値でした。</span><span class="sxs-lookup"><span data-stu-id="b080f-193">In the previous examples, the content was a simple string value.</span></span> <span data-ttu-id="b080f-194">ここでは、ツリー ビュー ノードはユーザーのピクチャ フォルダーを表すため、ピクチャ ライブラリ [StorageFolder](/uwp/api/windows.storage.storagefolder) はノードの Content プロパティに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="b080f-194">Here, a tree view node represents the user's Pictures folder, so the pictures library [StorageFolder](/uwp/api/windows.storage.storagefolder) is assigned to the node's Content property.</span></span>

```csharp
StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
TreeViewNode pictureNode = new TreeViewNode();
pictureNode.Content = picturesFolder;
```

```vb
Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
Dim pictureNode As New TreeViewNode With {.Content = picturesFolder}
```

<span data-ttu-id="b080f-195">[DataTemplate](/uwp/api/windows.ui.xaml.datatemplate) を指定して、ツリー ビューでのデータ項目の表示方法を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-195">You can provide a [DataTemplate](/uwp/api/windows.ui.xaml.datatemplate) to specify how the data item is displayed in the tree view.</span></span>

> [!NOTE]
> <span data-ttu-id="b080f-196">Windows 10 バージョン 1803 では、コンテンツが文字列ではない場合は、TreeView コントロールを再テンプレート化し、カスタム ItemTemplate を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-196">In Windows 10, version 1803, you have to retemplate the TreeView control and specify a custom ItemTemplate if your content is not a string.</span></span> <span data-ttu-id="b080f-197">詳細については、この記事の終わりにある完全な例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b080f-197">For more info, see the full example at the end of this article.</span></span> <span data-ttu-id="b080f-198">以降のバージョンでは、 [TreeView.ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="b080f-198">In later versions, set the [TreeView.ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate) property.</span></span>

### <a name="item-container-style"></a><span data-ttu-id="b080f-199">項目コンテナーのスタイル</span><span class="sxs-lookup"><span data-stu-id="b080f-199">Item container style</span></span>

<span data-ttu-id="b080f-200">ItemsSource または RootNodes、– 各ノードを表示するために使用する実際の要素を使用するかどうか、「コンテナー」と呼ばれる – は[TreeViewItem](/uwp/api/windows.ui.xaml.controls.treeviewitem)オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b080f-200">Whether you use ItemsSource or RootNodes, the actual elements used to display each node – called the "container" – is a [TreeViewItem](/uwp/api/windows.ui.xaml.controls.treeviewitem) object.</span></span> <span data-ttu-id="b080f-201">ツリー ビューを使用してコンテナーにスタイルを設定する ItemContainerStyle または ItemContainerStyleSelector プロパティ。</span><span class="sxs-lookup"><span data-stu-id="b080f-201">You can style the container using the TreeView's ItemContainerStyle or ItemContainerStyleSelector properties.</span></span>

### <a name="item-template-selectors"></a><span data-ttu-id="b080f-202">項目テンプレート セレクター</span><span class="sxs-lookup"><span data-stu-id="b080f-202">Item template selectors</span></span>

<span data-ttu-id="b080f-203">項目の種類に基づいてツリー ビューの項目の異なる DataTemplate を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-203">You can choose to set a different DataTemplate for the tree view items based on the type of item.</span></span> <span data-ttu-id="b080f-204">たとえば、アプリでは、ファイル エクスプ ローラーには、そのフォルダー、およびファイル用に別の 1 つのデータ テンプレートを使用します。</span><span class="sxs-lookup"><span data-stu-id="b080f-204">For example, in a file explorer app, you could use one data template for folders, and another for files.</span></span>

![フォルダーとファイルの異なるデータ テンプレートを使用します。](images/treeview-icons.png)

<span data-ttu-id="b080f-206">作成して、項目テンプレート セレクターを使用する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-206">Here is an example of how to create and use an item template selector.</span></span>

```xaml
<Page.Resources>
    <DataTemplate x:Key="FolderTemplate" x:DataType="local:ExplorerItem">
        <TreeViewItem ItemsSource="{x:Bind Children}">
            <StackPanel Orientation="Horizontal">
                <Image Width="20" Source="Assets/folder.png"/>
                <TextBlock Text="{x:Bind Name}" />
            </StackPanel>
        </TreeViewItem>
    </DataTemplate>

    <DataTemplate x:Key="FileTemplate" x:DataType="local:ExplorerItem">
        <TreeViewItem>
            <StackPanel Orientation="Horizontal">
                <Image Width="20" Source="Assets/file.png"/>
                <TextBlock Text="{Binding Name}"/>
            </StackPanel>
        </TreeViewItem>
    </DataTemplate>

    <local:ExplorerItemTemplateSelector
            x:Key="ExplorerItemTemplateSelector"
            FolderTemplate="{StaticResource FolderTemplate}"
            FileTemplate="{StaticResource FileTemplate}" />
</Page.Resources>

<Grid>
    <TreeView ItemsSource="{x:Bind DataSource}"
              ItemTemplateSelector="{StaticResource ExplorerItemTemplateSelector}"/>
</Grid>
```

```csharp
public class ExplorerItemTemplateSelector : DataTemplateSelector
{
    public DataTemplate FolderTemplate { get; set; }
    public DataTemplate FileTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item)
    {
        var explorerItem = (ExplorerItem)item;
        if (explorerItem.Type == ExplorerItem.ExplorerItemType.Folder) return FolderTemplate;

        return FileTemplate;
    }
}
```

## <a name="interacting-with-a-tree-view"></a><span data-ttu-id="b080f-207">ツリー ビューの操作</span><span class="sxs-lookup"><span data-stu-id="b080f-207">Interacting with a tree view</span></span>

<span data-ttu-id="b080f-208">ユーザーが操作できるようにツリー ビューを構成する方法はいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="b080f-208">You can configure a tree view to let a user interact with it in several different ways:</span></span>

- <span data-ttu-id="b080f-209">ノードの展開と折りたたみ</span><span class="sxs-lookup"><span data-stu-id="b080f-209">expand or collapse nodes</span></span>
- <span data-ttu-id="b080f-210">項目の単一選択または複数選択</span><span class="sxs-lookup"><span data-stu-id="b080f-210">single- or multi-select items</span></span>
- <span data-ttu-id="b080f-211">クリックして項目を呼び出す</span><span class="sxs-lookup"><span data-stu-id="b080f-211">click to invoke an item</span></span>

### <a name="expandcollapse"></a><span data-ttu-id="b080f-212">展開/折りたたみ</span><span class="sxs-lookup"><span data-stu-id="b080f-212">Expand/collapse</span></span>

<span data-ttu-id="b080f-213">子を持つ任意のツリー ビュー ノードは常に、展開/折りたたみグリフをクリックして展開または折りたたむことができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-213">Any tree view node that has children can always be expanded or collapsed by clicking the expand/collapse glyph.</span></span> <span data-ttu-id="b080f-214">ノードをプログラムにより展開するか折りたたみ、ノードの状態が変化したときに対応することもできます。</span><span class="sxs-lookup"><span data-stu-id="b080f-214">You can also expand or collapse a node programmatically, and respond when a node changes state.</span></span>

#### <a name="expandcollapse-a-node-programmatically"></a><span data-ttu-id="b080f-215">ノードをプログラムにより展開/折りたたみ</span><span class="sxs-lookup"><span data-stu-id="b080f-215">Expand/collapse a node programmatically</span></span>

<span data-ttu-id="b080f-216">コードでツリー ビュー ノードを展開したり、折りたたんだりする 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-216">There are 2 ways you can expand or collapse a tree view node in your code.</span></span>

- <span data-ttu-id="b080f-217">[TreeView](/uwp/api/windows.ui.xaml.controls.treeview) クラスには [Collapse](/uwp/api/windows.ui.xaml.controls.treeview.collapse) メソッドと [Expand](/uwp/api/windows.ui.xaml.controls.treeview.expand) メソッドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b080f-217">The [TreeView](/uwp/api/windows.ui.xaml.controls.treeview) class has the [Collapse](/uwp/api/windows.ui.xaml.controls.treeview.collapse) and [Expand](/uwp/api/windows.ui.xaml.controls.treeview.expand) methods.</span></span> <span data-ttu-id="b080f-218">これらのメソッドを呼び出すと、展開または折りたたむ TreeViewNode を渡します。</span><span class="sxs-lookup"><span data-stu-id="b080f-218">When you call these methods, you pass in the TreeViewNode that you want to expand or collapse.</span></span>

- <span data-ttu-id="b080f-219">各 [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) には [IsExpanded](/uwp/api/windows.ui.xaml.controls.treeviewnode.isexpanded) プロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b080f-219">Each [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) has the [IsExpanded](/uwp/api/windows.ui.xaml.controls.treeviewnode.isexpanded) property.</span></span> <span data-ttu-id="b080f-220">このプロパティを使用して、ノードの状態を確認したり、状態を変更するように設定したりできます。</span><span class="sxs-lookup"><span data-stu-id="b080f-220">You can use this property to check the state of a node, or set it to change the state.</span></span> <span data-ttu-id="b080f-221">このプロパティを XAML で設定し、ノードの初期状態に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="b080f-221">You can also set this property in XAML to set the initial state of a node.</span></span>

### <a name="fill-a-node-when-its-expanding"></a><span data-ttu-id="b080f-222">展開時にノードを入力する</span><span class="sxs-lookup"><span data-stu-id="b080f-222">Fill a node when it's expanding</span></span>

<span data-ttu-id="b080f-223">ツリー ビューで多数のノードを表示しなければならない場合があります。または含まれるノードの数が前もってわからない場合があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-223">You might need to show a large number of nodes in your tree view, or you might not know ahead of time how many nodes it will have.</span></span> <span data-ttu-id="b080f-224">TreeView コントロールは仮想化されていないため、リソースを管理するには、展開時に各ノードを入力し、折りたたみ時に子ノードを削除します。</span><span class="sxs-lookup"><span data-stu-id="b080f-224">The TreeView control is not virtualized, so you can manage resources by filling each node as it's expanded, and removing the child nodes when it's collapsed.</span></span>

<span data-ttu-id="b080f-225">[展開](/uwp/api/windows.ui.xaml.controls.treeview.expand) イベントを処理し、[HasUnrealizedChildren](/uwp/api/windows.ui.xaml.controls.treeviewnode.hasunrealizedchildren) プロパティを使用して展開時に子をノードに追加します。</span><span class="sxs-lookup"><span data-stu-id="b080f-225">Handle the [Expanding](/uwp/api/windows.ui.xaml.controls.treeview.expand) event and use the [HasUnrealizedChildren](/uwp/api/windows.ui.xaml.controls.treeviewnode.hasunrealizedchildren) property to add children to a node when it's being expanded.</span></span> <span data-ttu-id="b080f-226">HasUnrealizedChildren プロパティは、ノードを入力する必要があるか、その Children コレクションが既に設定されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-226">The HasUnrealizedChildren property indicates whether the node needs to be filled, or if its Children collection has already been populated.</span></span> <span data-ttu-id="b080f-227">ことが重要 TreeViewNode はこの値を設定しない、アプリのコードで管理する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b080f-227">It's important to remember that the TreeViewNode doesn't set this value, you need to manage it in your app code.</span></span>

<span data-ttu-id="b080f-228">次の例は、使用中のこれらの API を示しています。</span><span class="sxs-lookup"><span data-stu-id="b080f-228">Here's an example of these APIs in use.</span></span> <span data-ttu-id="b080f-229">'FillTreeNode' の実装を含むコンテキストについては、この記事の最後の完全なコード例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b080f-229">See the complete example code at the end of this article for context, including the implemetation of 'FillTreeNode'.</span></span>

```csharp
private void SampleTreeView_Expanding(TreeView sender, TreeViewExpandingEventArgs args)
{
    if (args.Node.HasUnrealizedChildren)
    {
        FillTreeNode(args.Node);
    }
}
```

```vb
Private Sub SampleTreeView_Expanding(sender As TreeView, args As TreeViewExpandingEventArgs)
    If args.Node.HasUnrealizedChildren Then
        FillTreeNode(args.Node)
    End If
End Sub
```

<span data-ttu-id="b080f-230">これは必須ではありませんが、[Collapsed](/uwp/api/windows.ui.xaml.controls.treeview.collapsed) イベントを処理して、親ノードが閉じられたときに子ノードを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="b080f-230">It's not required, but you might want to also handle the [Collapsed](/uwp/api/windows.ui.xaml.controls.treeview.collapsed) event and remove the child nodes when the parent node is closed.</span></span> <span data-ttu-id="b080f-231">これは、ツリー ビューに多くのノードがある場合、またはノード データが大量のリソースを使用している場合に重要です。</span><span class="sxs-lookup"><span data-stu-id="b080f-231">This can be important if your tree view has many nodes, or if the node data uses a lot of resources.</span></span> <span data-ttu-id="b080f-232">ノードを開くたびに入力することと、子をクローズド ノードにしたままにすることのパフォーマンスへの影響を考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-232">You should consider the performance impact of filling a node each time it's opened versus leaving the children on a closed node.</span></span> <span data-ttu-id="b080f-233">最適な選択肢は、アプリによって異なります。</span><span class="sxs-lookup"><span data-stu-id="b080f-233">The best option will depend on your app.</span></span>

<span data-ttu-id="b080f-234">この例では Collapsed イベントに対応するハンドラーを示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-234">Here's an example of a handler for the Collapsed event.</span></span>

```csharp
private void SampleTreeView_Collapsed(TreeView sender, TreeViewCollapsedEventArgs args)
{
    args.Node.Children.Clear();
    args.Node.HasUnrealizedChildren = true;
}
```

```vb
Private Sub SampleTreeView_Collapsed(sender As TreeView, args As TreeViewCollapsedEventArgs)
    args.Node.Children.Clear()
    args.Node.HasUnrealizedChildren = True
End Sub
```

### <a name="invoking-an-item"></a><span data-ttu-id="b080f-235">項目の呼び出し</span><span class="sxs-lookup"><span data-stu-id="b080f-235">Invoking an item</span></span>

<span data-ttu-id="b080f-236">ユーザーは、項目を選択する代わりに操作 (ボタンのように項目を扱う) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-236">A user can invoke an action (treating the item like a button) instead of selecting the item.</span></span> <span data-ttu-id="b080f-237">[ItemInvoked](/uwp/api/windows.ui.xaml.controls.treeview.iteminvoked) イベントを処理してこのユーザー操作に対応します。</span><span class="sxs-lookup"><span data-stu-id="b080f-237">You handle the [ItemInvoked](/uwp/api/windows.ui.xaml.controls.treeview.iteminvoked) event to respond to this user interaction.</span></span>

> [!NOTE]
> <span data-ttu-id="b080f-238">[IsItemClickEnabled](/uwp/api/windows.ui.xaml.controls.listviewbase.isitemclickenabled) プロパティが含まれる ListView とは異なり、アイテムの呼び出しとはツリー ビューで常に有効になっています。</span><span class="sxs-lookup"><span data-stu-id="b080f-238">Unlike ListView, which has the [IsItemClickEnabled](/uwp/api/windows.ui.xaml.controls.listviewbase.isitemclickenabled) property, invoking an item is always enabled on the tree view.</span></span> <span data-ttu-id="b080f-239">イベントを処理するかどうか選択することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-239">You can still choose whether to handle the event or not.</span></span>

**<span data-ttu-id="b080f-240">[TreeViewItemInvokedEventArgs](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs) クラス</span><span class="sxs-lookup"><span data-stu-id="b080f-240">[TreeViewItemInvokedEventArgs](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs) class</span></span>**

<span data-ttu-id="b080f-241">ItemInvoked イベント引数は、呼び出された項目にアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="b080f-241">The ItemInvoked event args give you access to the invoked item.</span></span> <span data-ttu-id="b080f-242">[InvokedItem](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs.invokeditem) プロパティには呼び出されたノードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b080f-242">The [InvokedItem](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs.invokeditem) property has the node that was invoked.</span></span> <span data-ttu-id="b080f-243">これを TreeViewNode にキャストし、データ項目を TreeViewNode.Content プロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="b080f-243">You can cast it to TreeViewNode and get the data item from the TreeViewNode.Content property.</span></span>

<span data-ttu-id="b080f-244">ItemInvoked イベント ハンドラーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-244">Here's an example of an ItemInvoked event handler.</span></span> <span data-ttu-id="b080f-245">データ項目は [IStorageItem](/uwp/api/windows.storage.istorageitem) です。この例では、ファイルおよびツリーについての情報だけが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-245">The data item is an [IStorageItem](/uwp/api/windows.storage.istorageitem), and this example just displays some info about the file and tree.</span></span> <span data-ttu-id="b080f-246">ノードがフォルダー ノードの場合、展開またはノードを同時に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="b080f-246">Also, if the node is a folder node, it expands or collapses the node at the same time.</span></span> <span data-ttu-id="b080f-247">それ以外の場合、ノードは山形マークをクリックした場合にのみ展開または折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="b080f-247">Otherwise, the node expands or collapses only when the chevron is clicked.</span></span>

```csharp
private void SampleTreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
{
    var node = args.InvokedItem as TreeViewNode;
    if (node.Content is IStorageItem item)
    {
        FileNameTextBlock.Text = item.Name;
        FilePathTextBlock.Text = item.Path;
        TreeDepthTextBlock.Text = node.Depth.ToString();

        if (node.Content is StorageFolder)
        {
            node.IsExpanded = !node.IsExpanded;
        }
    }
}
```

```vb
Private Sub SampleTreeView_ItemInvoked(sender As TreeView, args As TreeViewItemInvokedEventArgs)
    Dim node = TryCast(args.InvokedItem, TreeViewNode)
    Dim item = TryCast(node.Content, IStorageItem)
    If item IsNot Nothing Then
        FileNameTextBlock.Text = item.Name
        FilePathTextBlock.Text = item.Path
        TreeDepthTextBlock.Text = node.Depth.ToString()
        If TypeOf node.Content Is StorageFolder Then
            node.IsExpanded = Not node.IsExpanded
        End If
    End If
End Sub
```

### <a name="item-selection"></a><span data-ttu-id="b080f-248">項目の選択</span><span class="sxs-lookup"><span data-stu-id="b080f-248">Item selection</span></span>

<span data-ttu-id="b080f-249">TreeView コントロールでは、単一選択と複数選択の両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="b080f-249">The TreeView control supports both single-selection and multi-selection.</span></span> <span data-ttu-id="b080f-250">既定では、ノードの選択はオフになっていますが、[TreeView.SelectionMode](/uwp/api/windows.ui.xaml.controls.treeview.selectionmode) プロパティを設定してノードの選択を許可することができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-250">By default, selection of nodes is turned off, but you can set the [TreeView.SelectionMode](/uwp/api/windows.ui.xaml.controls.treeview.selectionmode) property to allow selection of nodes.</span></span> <span data-ttu-id="b080f-251">[TreeViewSelectionMode](/uwp/api/windows.ui.xaml.controls.treeviewselectionmode) 値は **None**、**Single**、および **Multiple** です。</span><span class="sxs-lookup"><span data-stu-id="b080f-251">The [TreeViewSelectionMode](/uwp/api/windows.ui.xaml.controls.treeviewselectionmode) values are **None**, **Single**, and **Multiple**.</span></span>

#### <a name="multiple-selection"></a><span data-ttu-id="b080f-252">複数選択</span><span class="sxs-lookup"><span data-stu-id="b080f-252">Multiple selection</span></span>

<span data-ttu-id="b080f-253">複数選択を有効にすると、各ツリー ビュー ノードの横にあるチェック ボックスを表示し、選択した項目が強調表示されました。</span><span class="sxs-lookup"><span data-stu-id="b080f-253">When multiple selection is enabled, a checkbox is shown next to each tree view node, and selected items are highlighted.</span></span> <span data-ttu-id="b080f-254">ユーザーは、チェック ボックスを使用して項目を選択または選択解除できます。項目は引き続きクリックして呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b080f-254">A user can select or de-select an item by using the checkbox; clicking the item still causes it to be invoked.</span></span>

<span data-ttu-id="b080f-255">選択、または親ノードを選択解除がオンまたはそのノードの下のすべての子の選択を解除します。</span><span class="sxs-lookup"><span data-stu-id="b080f-255">Selecting or de-selecting a parent node will select or de-select all children under that node.</span></span> <span data-ttu-id="b080f-256">場合は、いくつかが、すべての親ノードの下の子が選択されて、親ノードのチェック ボックスが表示される、不確定 (黒のボックスに入力されます)。</span><span class="sxs-lookup"><span data-stu-id="b080f-256">If some, but not all, of the children under a parent node are selected, the checkbox for the parent node is shown as indeterminate (filled with a black box).</span></span>

![ツリー ビューでの複数の選択](images/treeview-selection.png)

<span data-ttu-id="b080f-258">選択、または親ノードを選択解除がオンまたはそのノードの下のすべての子の選択を解除します。</span><span class="sxs-lookup"><span data-stu-id="b080f-258">Selecting or de-selecting a parent node will select or de-select all children under that node.</span></span> <span data-ttu-id="b080f-259">場合は、いくつかが、すべての親ノードの下の子が選択されて、親ノードのチェック ボックスが表示される、不確定 (黒のボックスに入力されます)。</span><span class="sxs-lookup"><span data-stu-id="b080f-259">If some, but not all, of the children under a parent node are selected, the checkbox for the parent node is shown as indeterminate (filled with a black box).</span></span>

![ツリー ビューでの複数の選択](images/treeview-selection.png)

<span data-ttu-id="b080f-261">選択したノードは、ツリー ビューの [SelectedNodes](/uwp/api/windows.ui.xaml.controls.treeview.selectednodes) コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-261">Selected nodes are added to the tree view's [SelectedNodes](/uwp/api/windows.ui.xaml.controls.treeview.selectednodes) collection.</span></span> <span data-ttu-id="b080f-262">[SelectAll](/uwp/api/windows.ui.xaml.controls.treeview.selectall) メソッドを呼び出して、ツリー ビューですべてのノードを選択できます。</span><span class="sxs-lookup"><span data-stu-id="b080f-262">You can call the [SelectAll](/uwp/api/windows.ui.xaml.controls.treeview.selectall) method to select all the nodes in a tree view.</span></span>

> [!NOTE]
> <span data-ttu-id="b080f-263">**SelectAll** を呼び出した場合、SelectionMode にかかわらず、実体化されたすべてのノードが選択されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-263">If you call **SelectAll**, all realized nodes are selected, regardless of the SelectionMode.</span></span> <span data-ttu-id="b080f-264">一貫したユーザー エクスペリエンスを提供するため、SelectionMode が **Multiple** である場合にのみ SelectAll を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="b080f-264">To provide a consistent user experience, you should only call SelectAll if SelectionMode is **Multiple**.</span></span>

#### <a name="selection-and-realizedunrealized-nodes"></a><span data-ttu-id="b080f-265">選択と実体化された/実体化されていないノード</span><span class="sxs-lookup"><span data-stu-id="b080f-265">Selection and realized/unrealized nodes</span></span>

<span data-ttu-id="b080f-266">ツリー ビューに実体化されていないノードが含まれる場合、それらは選択肢として考慮されません。</span><span class="sxs-lookup"><span data-stu-id="b080f-266">If your tree view has unrealized nodes, they are not taken into account for selection.</span></span> <span data-ttu-id="b080f-267">実体化されていないノードを選択する際に留意すべき点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="b080f-267">Here are some things you need to keep in mind regarding selection with unrealized nodes.</span></span>

- <span data-ttu-id="b080f-268">ユーザーが親ノードを選択すると、その親の下で実体化されたすべての子も選択されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-268">If a user selects a parent node, all the realized children under that parent are also selected.</span></span> <span data-ttu-id="b080f-269">同様に、すべての子ノードが選択されている場合、親ノードも選択されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-269">Similarly, if all the child nodes are selected, the parent node also becomes selected.</span></span>
- <span data-ttu-id="b080f-270">SelectAll メソッドは、実体化されたノードのみを SelectedNodes コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b080f-270">The SelectAll method only adds realized nodes to the SelectedNodes collection.</span></span>
- <span data-ttu-id="b080f-271">実体化されていない子を含む親ノードが選択された場合、子は実体化されたときに選択されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-271">If a parent node with unrealized children is selected, the children will be selected as they are realized.</span></span>

## <a name="code-examples"></a><span data-ttu-id="b080f-272">コード例</span><span class="sxs-lookup"><span data-stu-id="b080f-272">Code examples</span></span>

### <a name="tree-view-using-xaml"></a><span data-ttu-id="b080f-273">XAML を使って、ツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="b080f-273">Tree view using XAML</span></span>

<span data-ttu-id="b080f-274">次の例は、XAML で 1 つのツリー ビュー構造を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b080f-274">This example shows how to create a simple tree view structure in XAML.</span></span> <span data-ttu-id="b080f-275">ツリー ビューは、カテゴリに配置されており、ユーザーが選択できるアイスクリームのフレーバーとトッピングを示しています。</span><span class="sxs-lookup"><span data-stu-id="b080f-275">The tree view shows ice cream flavors and toppings that the user can choose from, arranged in categories.</span></span> <span data-ttu-id="b080f-276">複数選択が有効になっており、ユーザーがボタンをクリックすると、SelectedItems がメイン アプリ UI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-276">Multi-selection is enabled, and when the user clicks a button, the SelectedItems are displayed in the main app UI.</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" Padding="100">
    <SplitView IsPaneOpen="True"
               DisplayMode="Inline"
               OpenPaneLength="296">
        <SplitView.Pane>
            <TreeView x:Name="DessertTree" SelectionMode="Multiple">
                <TreeView.RootNodes>
                    <TreeViewNode Content="Flavors" IsExpanded="True">
                        <TreeViewNode.Children>
                            <TreeViewNode Content="Vanilla"/>
                            <TreeViewNode Content="Strawberry"/>
                            <TreeViewNode Content="Chocolate"/>
                        </TreeViewNode.Children>
                    </TreeViewNode>

                    <TreeViewNode Content="Toppings">
                        <TreeViewNode.Children>
                            <TreeViewNode Content="Candy">
                                <TreeViewNode.Children>
                                    <TreeViewNode Content="Chocolate"/>
                                    <TreeViewNode Content="Mint"/>
                                    <TreeViewNode Content="Sprinkles"/>
                                </TreeViewNode.Children>
                            </TreeViewNode>
                            <TreeViewNode Content="Fruits">
                                <TreeViewNode.Children>
                                    <TreeViewNode Content="Mango"/>
                                    <TreeViewNode Content="Peach"/>
                                    <TreeViewNode Content="Kiwi"/>
                                </TreeViewNode.Children>
                            </TreeViewNode>
                            <TreeViewNode Content="Berries">
                                <TreeViewNode.Children>
                                    <TreeViewNode Content="Strawberry"/>
                                    <TreeViewNode Content="Blueberry"/>
                                    <TreeViewNode Content="Blackberry"/>
                                </TreeViewNode.Children>
                            </TreeViewNode>
                        </TreeViewNode.Children>
                    </TreeViewNode>
                </TreeView.RootNodes>
            </TreeView>
        </SplitView.Pane>

        <StackPanel Grid.Column="1" Margin="12,0">
            <Button Content="Select all" Click="SelectAllButton_Click"/>
            <Button Content="Create order" Click="OrderButton_Click" Margin="0,12"/>
            <TextBlock Text="Your flavor selections:" Style="{StaticResource CaptionTextBlockStyle}"/>
            <TextBlock x:Name="FlavorList" Margin="0,0,0,12"/>
            <TextBlock Text="Your topping selections:" Style="{StaticResource CaptionTextBlockStyle}"/>
            <TextBlock x:Name="ToppingList"/>
        </StackPanel>
    </SplitView>
</Grid>
```

```csharp
private void OrderButton_Click(object sender, RoutedEventArgs e)
{
    FlavorList.Text = string.Empty;
    ToppingList.Text = string.Empty;

    foreach (TreeViewNode node in DessertTree.SelectedNodes)
    {
        if (node.Parent.Content?.ToString() == "Flavors")
        {
            FlavorList.Text += node.Content + "; ";
        }
        else if (node.HasChildren == false)
        {
            ToppingList.Text += node.Content + "; ";
        }
    }
}

private void SelectAllButton_Click(object sender, RoutedEventArgs e)
{
    if (DessertTree.SelectionMode == TreeViewSelectionMode.Multiple)
    {
        DessertTree.SelectAll();
    }
}
```

```vb
Private Sub OrderButton_Click(sender As Object, e As RoutedEventArgs)
    FlavorList.Text = String.Empty
    ToppingList.Text = String.Empty
    For Each node As TreeViewNode In DessertTree.SelectedNodes
        If node.Parent.Content?.ToString() = "Flavors" Then
            FlavorList.Text += node.Content & "; "
        ElseIf node.HasChildren = False Then
            ToppingList.Text += node.Content & "; "
        End If
    Next
End Sub

Private Sub SelectAllButton_Click(sender As Object, e As RoutedEventArgs)
    If DessertTree.SelectionMode = TreeViewSelectionMode.Multiple Then
        DessertTree.SelectAll()
    End If
End Sub
```

### <a name="tree-view-using-data-binding"></a><span data-ttu-id="b080f-277">データ バインディングを使用して、ツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="b080f-277">Tree view using data binding</span></span>

<span data-ttu-id="b080f-278">この例では、前の例と同じツリー ビューを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-278">This example shows how to create the same tree view as the previous example.</span></span> <span data-ttu-id="b080f-279">ただし、XAML でのデータの階層を作成するのではなく、データはコードで作成され、ツリー ビューの ItemsSource プロパティにバインドされています。</span><span class="sxs-lookup"><span data-stu-id="b080f-279">However, instead of creating the data hierarchy in XAML, the data is created in code and bound to the tree view's ItemsSource property.</span></span> <span data-ttu-id="b080f-280">(前の例に示すように、ボタンのイベント ハンドラーに次の例も適用されます。)</span><span class="sxs-lookup"><span data-stu-id="b080f-280">(The button event handlers shown in the previous example apply to this example also.)</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" Padding="100">
    <SplitView IsPaneOpen="True"
               DisplayMode="Inline"
               OpenPaneLength="296">
        <SplitView.Pane>
            <TreeView Name="DessertTree"
                      SelectionMode="Multiple"
                      ItemsSource="{x:Bind DataSource}">
                <TreeView.ItemTemplate>
                    <DataTemplate x:DataType="local:Item">
                        <TreeViewItem ItemsSource="{x:Bind Children}"
                                      Content="{x:Bind Name}"/>
                    </DataTemplate>
                </TreeView.ItemTemplate>
            </TreeView>
        </SplitView.Pane>

        <StackPanel Grid.Column="1" Margin="12,0">
            <Button Content="Select all" Click="SelectAllButton_Click"/>
            <Button Content="Create order" Click="OrderButton_Click" Margin="0,12"/>
            <TextBlock Text="Your flavor selections:" Style="{StaticResource CaptionTextBlockStyle}"/>
            <TextBlock x:Name="FlavorList" Margin="0,0,0,12"/>
            <TextBlock Text="Your topping selections:" Style="{StaticResource CaptionTextBlockStyle}"/>
            <TextBlock x:Name="ToppingList"/>
        </StackPanel>
    </SplitView>
</Grid>
```

```csharp
public sealed partial class MainPage : Page
{
    private ObservableCollection<Item> DataSource = new ObservableCollection<Item>();

    public MainPage()
    {
        this.InitializeComponent();
        DataSource = GetDessertData();
    }

    private ObservableCollection<Item> GetDessertData()
    {
        var list = new ObservableCollection<Item>();
        Item flavorsCategory = new Item()
        {
            Name = "Flavors",
            Children =
            {
                new Item() { Name = "Vanilla" },
                new Item() { Name = "Strawberry" },
                new Item() { Name = "Chocolate" }
            }
        };
        Item toppingsCategory = new Item()
        {
            Name = "Toppings",
            Children =
            {
                new Item()
                {
                    Name = "Candy",
                    Children =
                    {
                        new Item() { Name = "Chocolate" },
                        new Item() { Name = "Mint" },
                        new Item() { Name = "Sprinkles" }
                    }
                },
                new Item()
                {
                    Name = "Fruits",
                    Children =
                    {
                        new Item() { Name = "Mango" },
                        new Item() { Name = "Peach" },
                        new Item() { Name = "Kiwi" }
                    }
                },
                new Item()
                {
                    Name = "Berries",
                    Children =
                    {
                        new Item() { Name = "Strawberry" },
                        new Item() { Name = "Blueberry" },
                        new Item() { Name = "Blackberry" }
                    }
                }
            }
        };

        list.Add(flavorsCategory);
        list.Add(toppingsCategory);
        return list;
    }

    // Button event handlers...
}

public class Item
{
    public string Name { get; set; }
    public ObservableCollection<Item> Children { get; set; } = new ObservableCollection<Item>();

    public override string ToString()
    {
        return Name;
    }
}
```

### <a name="pictures-and-music-library-tree-view"></a><span data-ttu-id="b080f-281">画像やミュージック ライブラリのツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="b080f-281">Pictures and Music Library tree view</span></span>

<span data-ttu-id="b080f-282">この例では、ユーザーの画像やミュージック ライブラリのコンテンツや構造を表示するツリー ビューを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b080f-282">This example shows how to create a tree view that shows the contents and structure of the users Pictures and Music libraries.</span></span> <span data-ttu-id="b080f-283">項目の数は事前に知ることができないため、各ノードは展開時に入力され、折りたたまれたときに空になります。</span><span class="sxs-lookup"><span data-stu-id="b080f-283">The number of items can't be known ahead of time, so each node is filled when it's expanded, and emptied when it's collapsed.</span></span>

<span data-ttu-id="b080f-284">カスタム項目テンプレートは、型が [IStorageItem](/uwp/api/windows.storage.istorageitem) であるデータ項目を表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="b080f-284">A custom item template is used to display the data items, which are of type [IStorageItem](/uwp/api/windows.storage.istorageitem).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b080f-285">この例のコードでは、picturesLibrary 機能と musicLibrary 機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="b080f-285">The code in this example requires the picturesLibrary and musicLibrary capabilities.</span></span> <span data-ttu-id="b080f-286">ファイル アクセスの詳細については、[ファイル アクセス許可](../../files/file-access-permissions.md)、[ファイルとフォルダーの列挙と照会](../../files/quickstart-listing-files-and-folders.md)、および[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](../../files/quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b080f-286">For more info about file access, see [File access permissions](../../files/file-access-permissions.md), [Enumerate and query files and folders](../../files/quickstart-listing-files-and-folders.md), and [Files and folders in the Music, Pictures, and Videos libraries](../../files/quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md).</span></span>

```xaml
<Page
    x:Class="TreeViewApp1.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:TreeViewApp1"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
    <Page.Resources>
        <DataTemplate x:Key="TreeViewItemDataTemplate">
            <Grid Height="44">
                <TextBlock
                    Text="{Binding Content.DisplayName}"
                    HorizontalAlignment="Left"
                    VerticalAlignment="Center"
                    Style="{ThemeResource BodyTextBlockStyle}"/>
            </Grid>
        </DataTemplate>

        <Style TargetType="TreeView">
            <Setter Property="IsTabStop" Value="False" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TreeView">
                        <TreeViewList x:Name="ListControl"
                                      ItemTemplate="{StaticResource TreeViewItemDataTemplate}"
                                      ItemContainerStyle="{StaticResource TreeViewItemStyle}"
                                      CanDragItems="True"
                                      AllowDrop="True"
                                      CanReorderItems="True">
                            <TreeViewList.ItemContainerTransitions>
                                <TransitionCollection>
                                    <ContentThemeTransition />
                                    <ReorderThemeTransition />
                                    <EntranceThemeTransition IsStaggeringEnabled="False" />
                                </TransitionCollection>
                            </TreeViewList.ItemContainerTransitions>
                        </TreeViewList>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Page.Resources>

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <SplitView IsPaneOpen="True"
                   DisplayMode="Inline"
                   OpenPaneLength="296">
            <SplitView.Pane>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Button Content="Refresh tree" Click="RefreshButton_Click" Margin="24,12"/>
                    <TreeView x:Name="sampleTreeView" Grid.Row="1" SelectionMode="Single"
                              Expanding="SampleTreeView_Expanding"
                              Collapsed="SampleTreeView_Collapsed"
                              ItemInvoked="SampleTreeView_ItemInvoked"/>
                </Grid>
            </SplitView.Pane>

            <StackPanel Grid.Column="1" Margin="12,72">
                <TextBlock Text="File name:" Style="{StaticResource CaptionTextBlockStyle}"/>
                <TextBlock x:Name="FileNameTextBlock" Margin="0,0,0,12"/>

                <TextBlock Text="File path:" Style="{StaticResource CaptionTextBlockStyle}"/>
                <TextBlock x:Name="FilePathTextBlock" Margin="0,0,0,12"/>

                <TextBlock Text="Tree depth:" Style="{StaticResource CaptionTextBlockStyle}"/>
                <TextBlock x:Name="TreeDepthTextBlock" Margin="0,0,0,12"/>
            </StackPanel>
        </SplitView>
    </Grid>
</Page>
```

```csharp
public MainPage()
{
    this.InitializeComponent();
    InitializeTreeView();
}

private void InitializeTreeView()
{
    // A TreeView can have more than 1 root node. The Pictures library
    // and the Music library will each be a root node in the tree.
    // Get Pictures library.
    StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
    TreeViewNode pictureNode = new TreeViewNode();
    pictureNode.Content = picturesFolder;
    pictureNode.IsExpanded = true;
    pictureNode.HasUnrealizedChildren = true;
    sampleTreeView.RootNodes.Add(pictureNode);
    FillTreeNode(pictureNode);

    // Get Music library.
    StorageFolder musicFolder = KnownFolders.MusicLibrary;
    TreeViewNode musicNode = new TreeViewNode();
    musicNode.Content = musicFolder;
    musicNode.IsExpanded = true;
    musicNode.HasUnrealizedChildren = true;
    sampleTreeView.RootNodes.Add(musicNode);
    FillTreeNode(musicNode);
}

private async void FillTreeNode(TreeViewNode node)
{
    // Get the contents of the folder represented by the current tree node.
    // Add each item as a new child node of the node that's being expanded.

    // Only process the node if it's a folder and has unrealized children.
    StorageFolder folder = null;
    if (node.Content is StorageFolder && node.HasUnrealizedChildren == true)
    {
        folder = node.Content as StorageFolder;
    }
    else
    {
        // The node isn't a folder, or it's already been filled.
        return;
    }

    IReadOnlyList<IStorageItem> itemsList = await folder.GetItemsAsync();

    if (itemsList.Count == 0)
    {
        // The item is a folder, but it's empty. Leave HasUnrealizedChildren = true so
        // that the chevron appears, but don't try to process children that aren't there.
        return;
    }

    foreach (var item in itemsList)
    {
        var newNode = new TreeViewNode();
        newNode.Content = item;

        if (item is StorageFolder)
        {
            // If the item is a folder, set HasUnrealizedChildren to true. 
            // This makes the collapsed chevron show up.
            newNode.HasUnrealizedChildren = true;
        }
        else
        {
            // Item is StorageFile. No processing needed for this scenario.
        }
        node.Children.Add(newNode);
    }
    // Children were just added to this node, so set HasUnrealizedChildren to false.
    node.HasUnrealizedChildren = false;
}

private void SampleTreeView_Expanding(TreeView sender, TreeViewExpandingEventArgs args)
{
    if (args.Node.HasUnrealizedChildren)
    {
        FillTreeNode(args.Node);
    }
}

private void SampleTreeView_Collapsed(TreeView sender, TreeViewCollapsedEventArgs args)
{
    args.Node.Children.Clear();
    args.Node.HasUnrealizedChildren = true;
}

private void SampleTreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
{
    var node = args.InvokedItem as TreeViewNode;
    if (node.Content is IStorageItem item)
    {
        FileNameTextBlock.Text = item.Name;
        FilePathTextBlock.Text = item.Path;
        TreeDepthTextBlock.Text = node.Depth.ToString();

        if (node.Content is StorageFolder)
        {
            node.IsExpanded = !node.IsExpanded;
        }
    }
}

private void RefreshButton_Click(object sender, RoutedEventArgs e)
{
    sampleTreeView.RootNodes.Clear();
    InitializeTreeView();
}
```

```vb
Public Sub New()
    InitializeComponent()
    InitializeTreeView()
End Sub

Private Sub InitializeTreeView()
    ' A TreeView can have more than 1 root node. The Pictures library
    ' and the Music library will each be a root node in the tree.
    ' Get Pictures library.
    Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
    Dim pictureNode As New TreeViewNode With {
        .Content = picturesFolder,
        .IsExpanded = True,
        .HasUnrealizedChildren = True
    }
    sampleTreeView.RootNodes.Add(pictureNode)
    FillTreeNode(pictureNode)

    ' Get Music library.
    Dim musicFolder As StorageFolder = KnownFolders.MusicLibrary
    Dim musicNode As New TreeViewNode With {
        .Content = musicFolder,
        .IsExpanded = True,
        .HasUnrealizedChildren = True
    }
    sampleTreeView.RootNodes.Add(musicNode)
    FillTreeNode(musicNode)
End Sub

Private Async Sub FillTreeNode(node As TreeViewNode)
    ' Get the contents of the folder represented by the current tree node.
    ' Add each item as a new child node of the node that's being expanded.

    ' Only process the node if it's a folder and has unrealized children.
    Dim folder As StorageFolder = Nothing
    If TypeOf node.Content Is StorageFolder AndAlso node.HasUnrealizedChildren Then
        folder = TryCast(node.Content, StorageFolder)
    Else
        ' The node isn't a folder, or it's already been filled.
        Return
    End If

    Dim itemsList As IReadOnlyList(Of IStorageItem) = Await folder.GetItemsAsync()
    If itemsList.Count = 0 Then
        ' The item is a folder, but it's empty. Leave HasUnrealizedChildren = true so
        ' that the chevron appears, but don't try to process children that aren't there.
        Return
    End If

    For Each item In itemsList
        Dim newNode As New TreeViewNode With {
            .Content = item
        }
        If TypeOf item Is StorageFolder Then
            ' If the item is a folder, set HasUnrealizedChildren to True.
            ' This makes the collapsed chevron show up.
            newNode.HasUnrealizedChildren = True
        Else
            ' Item is StorageFile. No processing needed for this scenario.
        End If
        node.Children.Add(newNode)
    Next

    ' Children were just added to this node, so set HasUnrealizedChildren to False.
    node.HasUnrealizedChildren = False
End Sub

Private Sub SampleTreeView_Expanding(sender As TreeView, args As TreeViewExpandingEventArgs)
    If args.Node.HasUnrealizedChildren Then
        FillTreeNode(args.Node)
    End If
End Sub

Private Sub SampleTreeView_Collapsed(sender As TreeView, args As TreeViewCollapsedEventArgs)
    args.Node.Children.Clear()
    args.Node.HasUnrealizedChildren = True
End Sub

Private Sub SampleTreeView_ItemInvoked(sender As TreeView, args As TreeViewItemInvokedEventArgs)
    Dim node = TryCast(args.InvokedItem, TreeViewNode)
    Dim item = TryCast(node.Content, IStorageItem)
    If item IsNot Nothing Then
        FileNameTextBlock.Text = item.Name
        FilePathTextBlock.Text = item.Path
        TreeDepthTextBlock.Text = node.Depth.ToString()
        If TypeOf node.Content Is StorageFolder Then
            node.IsExpanded = Not node.IsExpanded
        End If
    End If
End Sub

Private Sub RefreshButton_Click(sender As Object, e As RoutedEventArgs)
    sampleTreeView.RootNodes.Clear()
    InitializeTreeView()
End Sub
```

## <a name="related-articles"></a><span data-ttu-id="b080f-287">関連記事</span><span class="sxs-lookup"><span data-stu-id="b080f-287">Related articles</span></span>

- [<span data-ttu-id="b080f-288">TreeView クラス</span><span class="sxs-lookup"><span data-stu-id="b080f-288">TreeView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)
- [<span data-ttu-id="b080f-289">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="b080f-289">ListView class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [<span data-ttu-id="b080f-290">ListViewと GridView</span><span class="sxs-lookup"><span data-stu-id="b080f-290">ListView and GridView</span></span>](listview-and-gridview.md)
