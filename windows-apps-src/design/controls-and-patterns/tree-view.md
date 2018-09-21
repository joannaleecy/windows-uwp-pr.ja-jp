---
author: Jwmsft
description: ItemsSource を階層データ ソースにバインドすることによって展開可能なツリー ビューを作成するかを作成し、TreeViewNode オブジェクトを管理することができます。
title: ツリー ビュー
label: Tree view
template: detail.hbs
ms.author: jimwalk
ms.localizationpriority: medium
pm-contact: predavid
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
dev_langs:
- csharp
- vb
ms.openlocfilehash: 20de58d13c4ace6b71ec952dc88cd59d1ab6114f
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4119182"
---
# <a name="treeview"></a>TreeView

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。 プレビュー機能[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。

XAML TreeView コントロールを使用すると、階層リストが有効になり、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。

TreeView API は、以下の機能をサポートします。

- N レベルの入れ子
- 1 つまたは複数のノードの選択
- (プレビュー)ツリー ビューと TreeViewItem ItemsSource プロパティをデータ バインディング
- (プレビュー)ツリー ビュー項目テンプレートのルートとして TreeViewItem
- (プレビュー)TreeViewItem 内のコンテンツの任意の型
- (プレビュー)ドラッグ アンド ドロップ ツリー ビューの間で

| **Windows UI のライブラリを入手します。** |
| - |
| このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。 詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。 |

| **プラットフォーム Api** | **Windows UI ライブラリ Api** |
| - | - |
| [TreeView クラス](/uwp/api/windows.ui.xaml.controls.treeview)、 [TreeViewNode クラス](/uwp/api/windows.ui.xaml.controls.treeviewnode)、 [TreeView.ItemsSource プロパティ](/uwp/api/windows.ui.xaml.controls.treeview.itemssource) | [TreeView クラス](/uwp/api/microsoft.ui.xaml.controls.treeview)、 [TreeViewNode クラス](/uwp/api/microsoft.ui.xaml.controls.treeviewnode)、 [TreeView.ItemsSource プロパティ](/uwp/api/microsoft.ui.xaml.controls.treeview.itemssource) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

- 項目に入れ子になった一覧項目が含まれているとき、それらの項目とピアやノードとの階層関係を視覚的に示すことが重要になる場合は、ツリー ビューを使用します。

- 項目の入れ子になった関係を強調表示することが優先的な処理ではない場合は、ツリー ビューを使用しないでください。 ほとんどの演習用シナリオでは、標準的なリスト ビューが適しています

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/TreeView">アプリを開き、操作でのツリー ビューを参照してください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="treeview-ui"></a>TreeView UI

ツリー ビューはインデントとアイコンを組み合わせて使用することで、フォルダー/親ノードとフォルダー以外の項目/子ノードとの間の入れ子になった関係を表します。 折りたたまれているノードでは右向きの山形記号を使用し、展開されているノードでは下向きの山形記号を使用します。

![TreeView での山形記号アイコン](images/treeview-simple.png)

ツリー ビュー項目データ テンプレートにアイコンを含めてノードを表すことができます。 この場合、ディスク上のフォルダー構造などのリテラル フォルダーを表すノードに対してのみ、フォルダー アイコンのみを使用する必要があります。

![TreeView で山形記号のアイコンとフォルダー アイコンの組み合わせ](images/treeview-icons.png)

## <a name="create-a-tree-view"></a>ツリー ビューの作成

ツリー ビューを作成するには、階層データ ソースに[ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)をバインドすることによってまたは作成し、TreeViewNode オブジェクトを管理することができます。

ツリー ビューを作成するには、[TreeView](/uwp/api/windows.ui.xaml.controls.treeview) コントロールと [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) オブジェクトの階層を使用します。 ノード階層を作成するには、TreeView コントロールの[RootNodes](/uwp/api/windows.ui.xaml.controls.treeview.rootnodes)コレクションに 1 つまたは複数のルート ノードを追加します。 各 TreeViewNode では、より多くのノードをその Children コレクションに追加することができます。 ツリー ビュー ノードは、必要な任意の深さまで入れ子にすることができます。

以降、Windows Insider Preview では、バインドできます階層データ ソース ツリー ビューのコンテンツを提供する[ItemsSource](/uwp/api/windows.ui.xaml.controls.treeview.itemssource)プロパティをするリスト ビューの ItemsSource と同様です。 同様に、項目を表示する DataTemplate を提供する[ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate) (およびオプションの[ItemTemplateSelector](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate)) を使用します。

> [!IMPORTANT]
> ItemsSource は、TreeView.RootNodes に TreeView コントロールにコンテンツを格納するための代替のメカニズムです。 同時に ItemsSource と RootNodes の両方を設定することはできません。 ItemsSource を使用して、ノードが作成された TreeView.RootNodes プロパティからアクセスすることができます。

XAML で宣言された単純なツリー ビューの例を以下に示します。 通常は、コードにノードを追加しますが、ノードの階層を作成する方法を視覚化するうえで役立つため、XAML の階層をここに示します。

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

ほとんどの場合、ツリー ビューでは、通常、ルート TreeView コントロールを XAML で宣言しますが、TreeViewNode オブジェクトを追加コードやデータ バインディングを使うために、データ ソースからデータが表示されます。

### <a name="bind-to-a-hierarchical-data-source"></a>階層データ ソースにバインドします。

データ バインディングを使用して、ツリー ビューを作成するには、TreeView.ItemsSource プロパティに階層コレクションを設定します。 ItemTemplate で子項目のコレクション プロパティに設定 TreeViewItem.ItemsSource します。

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

_ツリー ビューのデータ バインディングを使用して_完全なコード例」セクションを参照してください。

#### <a name="items-and-item-containers"></a>項目と項目コンテナー

これらの Api は、コンテナーからノードまたはデータ項目を取得できる TreeView.ItemsSource を使用する場合と逆も同様です。

| **[TreeViewItem](/uwp/api/windows.ui.xaml.controls.treeviewitem)** | |
| - | - |
| [TreeView.ItemFromContainer](/uwp/api/windows.ui.xaml.controls.treeview.itemfromcontainer) | 指定した TreeViewItem コンテナーのデータ項目を取得します。 |
| [TreeView.ContainerFromItem](/uwp/api/windows.ui.xaml.controls.treeview.containerfromitem) | 指定されたデータ項目の TreeViewItem コンテナーを取得します。 |

| **[TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode)** | |
| - | - |
| [TreeView.NodeFromContainer](/uwp/api/windows.ui.xaml.controls.treeview.nodefromcontainer) | 指定した TreeViewItem コンテナーの TreeViewNode を取得します。 |
| [TreeView.ContainerFromNode](/uwp/api/windows.ui.xaml.controls.treeview.containerfromnode) | 指定した TreeViewNode の TreeViewItem コンテナーを取得します。 |

### <a name="manage-tree-view-nodes"></a>ツリー ビュー ノードを管理します。

このツリー ビューは、XAML で作成されたものと同じですが、ノードはコードで作成されています。

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

これらの API は、ツリー ビューのデータの階層の管理に使用できます。

| **[TreeView](/uwp/api/windows.ui.xaml.controls.treeview)** | |
| - | - |
| [RootNodes](/uwp/api/windows.ui.xaml.controls.treeview.rootnodes) | ツリー ビューは、1 つまたは複数のルート ノードの場合があります。 TreeViewNode オブジェクトを RootNodes コレクションに追加し、ルート ノードを作成します。 ルート ノードの **Parent** は常に **null** です。 ルート ノードの**奥行き**は0です。 |

| **[TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode)** | |
| - | - |
| [Children](/uwp/api/windows.ui.xaml.controls.treeviewnode.children) | TreeViewNode オブジェクトを親ノードの Children コレクションに追加し、ノード階層を作成します。 ノードは、その **Children** コレクションのすべてのノードの **Parent** です。 |
| [HasChildren](/uwp/api/windows.ui.xaml.controls.treeviewnode.haschildren) | ノードが子を実体化した場合は **true**。 **false** は空のフォルダーまたは項目を示します。 |
| [HasUnrealizedChildren](/uwp/api/windows.ui.xaml.controls.treeviewnode.hasunrealizedchildren) | ノードが展開されているときにノードに入力している場合は、このプロパティを使用します。 この記事の後半にある「_展開時にノードを入力する_」をご覧ください。 |
| [奥行き](/uwp/api/windows.ui.xaml.controls.treeviewnode.depth) | 子ノードとルート ノードの距離を示します。 |
| [Parent](/uwp/api/windows.ui.xaml.controls.treeviewnode.parent) | このノードが含まれている **Children** コレクションを所有する TreeViewNode を取得します。 |

ツリー ビューは、**HasChildren** プロパティと **HasUnrealizedChildren** プロパティを使用して、開く/閉じるアイコンを表示するかどうかを確認します。 いずれかのプロパティが **true** である場合、アイコンが表示されます。それ以外の場合は表示されません。

## <a name="tree-view-node-content"></a>ツリー ビュー ノード コンテンツ

ツリー ビュー ノードが [Content](/uwp/api/windows.ui.xaml.controls.treeviewnode.content) プロパティで表すデータ項目を保存することができます。

前の例では、コンテンツは単純な文字列値でした。 ここでは、ツリー ビュー ノードはユーザーのピクチャ フォルダーを表すため、ピクチャ ライブラリ [StorageFolder](/uwp/api/windows.storage.storagefolder) はノードの Content プロパティに割り当てられます。

```csharp
StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
TreeViewNode pictureNode = new TreeViewNode();
pictureNode.Content = picturesFolder;
```

```vb
Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
Dim pictureNode As New TreeViewNode With {.Content = picturesFolder}
```

[DataTemplate](/uwp/api/windows.ui.xaml.datatemplate) を指定して、ツリー ビューでのデータ項目の表示方法を指定することができます。

> [!NOTE]
> Windows 10 バージョン 1803 では、コンテンツが文字列ではない場合は、TreeView コントロールを再テンプレート化し、カスタム ItemTemplate を指定する必要があります。 詳細については、この記事の終わりにある完全な例を参照してください。 それ以降のバージョンでは、 [TreeView.ItemTemplate](/uwp/api/windows.ui.xaml.controls.treeview.itemtemplate)プロパティを設定します。

### <a name="item-container-style"></a>項目コンテナーのスタイル

ItemsSource または RootNodes、– 各ノードを表示するために使用する実際の要素を使用するかどうか、「コンテナー」と呼ばれる – は[TreeViewItem](/uwp/api/windows.ui.xaml.controls.treeviewitem)オブジェクトです。 ツリー ビューを使用してコンテナーにスタイルを設定する ItemContainerStyle または ItemContainerStyleSelector プロパティ。

### <a name="item-template-selectors"></a>項目テンプレート セレクター

項目の種類に基づいてツリー ビューの項目のさまざまな DataTemplate を設定することができます。 たとえば、ファイル エクスプ ローラー アプリには、そのフォルダー、およびファイル用に別の 1 つのデータ テンプレートを使用します。

![フォルダーとファイルの異なるデータ テンプレートを使用します。](images/treeview-icons.png)

作成して、項目テンプレート セレクターを使用する方法の例を示します。

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

## <a name="interacting-with-a-tree-view"></a>ツリー ビューの操作

ユーザーが操作できるようにツリー ビューを構成する方法はいくつかあります。

- ノードの展開と折りたたみ
- 項目の単一選択または複数選択
- クリックして項目を呼び出す

### <a name="expandcollapse"></a>展開/折りたたみ

子を持つ任意のツリー ビュー ノードは常に、展開/折りたたみグリフをクリックして展開または折りたたむことができます。 ノードをプログラムにより展開するか折りたたみ、ノードの状態が変化したときに対応することもできます。

#### <a name="expandcollapse-a-node-programmatically"></a>ノードをプログラムにより展開/折りたたみ

コードでツリー ビュー ノードを展開したり、折りたたんだりする 2 つの方法があります。

- [TreeView](/uwp/api/windows.ui.xaml.controls.treeview) クラスには [Collapse](/uwp/api/windows.ui.xaml.controls.treeview.collapse) メソッドと [Expand](/uwp/api/windows.ui.xaml.controls.treeview.expand) メソッドが含まれています。 これらのメソッドを呼び出すと、展開または折りたたむ TreeViewNode を渡します。

- 各 [TreeViewNode](/uwp/api/windows.ui.xaml.controls.treeviewnode) には [IsExpanded](/uwp/api/windows.ui.xaml.controls.treeviewnode.isexpanded) プロパティが含まれています。 このプロパティを使用して、ノードの状態を確認したり、状態を変更するように設定したりできます。 このプロパティを XAML で設定し、ノードの初期状態に設定することもできます。

### <a name="fill-a-node-when-its-expanding"></a>展開時にノードを入力する

ツリー ビューで多数のノードを表示しなければならない場合があります。または含まれるノードの数が前もってわからない場合があります。 TreeView コントロールは仮想化されていないため、リソースを管理するには、展開時に各ノードを入力し、折りたたみ時に子ノードを削除します。

[展開](/uwp/api/windows.ui.xaml.controls.treeview.expand) イベントを処理し、[HasUnrealizedChildren](/uwp/api/windows.ui.xaml.controls.treeviewnode.hasunrealizedchildren) プロパティを使用して展開時に子をノードに追加します。 HasUnrealizedChildren プロパティは、ノードを入力する必要があるか、その Children コレクションが既に設定されているかどうかを示します。 TreeViewNode はこの値を設定しないことに留意することは重要です。この値はアプリ コードで管理する必要があります。

次の例は、使用中のこれらの API を示しています。 'FillTreeNode' の実装を含むコンテキストについては、この記事の最後の完全なコード例をご覧ください。

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

これは必須ではありませんが、[Collapsed](/uwp/api/windows.ui.xaml.controls.treeview.collapsed) イベントを処理して、親ノードが閉じられたときに子ノードを削除することもできます。 これは、ツリー ビューに多くのノードがある場合、またはノード データが大量のリソースを使用している場合に重要です。 ノードを開くたびに入力することと、子をクローズド ノードにしたままにすることのパフォーマンスへの影響を考慮する必要があります。 最適な選択肢は、アプリによって異なります。

この例では Collapsed イベントに対応するハンドラーを示します。

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

### <a name="invoking-an-item"></a>項目の呼び出し

ユーザーは、項目を選択する代わりに操作 (ボタンのように項目を扱う) を呼び出すことができます。 [ItemInvoked](/uwp/api/windows.ui.xaml.controls.treeview.iteminvoked) イベントを処理してこのユーザー操作に対応します。

> [!NOTE]
> [IsItemClickEnabled](/uwp/api/windows.ui.xaml.controls.listviewbase.isitemclickenabled) プロパティが含まれる ListView とは異なり、アイテムの呼び出しとはツリー ビューで常に有効になっています。 イベントを処理するかどうか選択することができます。

**[TreeViewItemInvokedEventArgs](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs) クラス**

ItemInvoked イベント引数により、呼び出された項目にアクセスできます。 [InvokedItem](/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs.invokeditem) プロパティには呼び出されたノードが含まれています。 これを TreeViewNode にキャストし、データ項目を TreeViewNode.Content プロパティから取得できます。

ItemInvoked イベント ハンドラーの例を次に示します。 データ項目は [IStorageItem](/uwp/api/windows.storage.istorageitem) です。この例では、ファイルおよびツリーについての情報だけが表示されます。 また、ノードがフォルダー ノードの場合は、ノードを同時に展開または折りたたみます。 それ以外の場合、ノードは山形マークをクリックした場合にのみ展開または折りたたまれます。

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

### <a name="item-selection"></a>項目の選択

TreeView コントロールでは、単一選択と複数選択の両方がサポートされています。 既定では、ノードの選択はオフになっていますが、[TreeView.SelectionMode](/uwp/api/windows.ui.xaml.controls.treeview.selectionmode) プロパティを設定してノードの選択を許可することができます。 [TreeViewSelectionMode](/uwp/api/windows.ui.xaml.controls.treeviewselectionmode) 値は **None**、**Single**、および **Multiple** です。

選択を有効にすると、各ツリー ビュー ノードの横にあるチェック ボックスが表示され、選択した項目が強調表示されます。 ユーザーは、チェック ボックスを使用して項目を選択または選択解除できます。項目は引き続きクリックして呼び出すことができます。

選択、または親ノードを選択解除がオンまたはそのノードの下のすべての子の選択を解除します。 全部ではない場合は、いくつかが選択されている親ノードの下の子、親ノードのチェック ボックスが表示される、不確定 (黒のボックスに入力されます)。

![ツリー ビューでの複数選択](images/treeview-selection.png)

選択したノードは、ツリー ビューの [SelectedNodes](/uwp/api/windows.ui.xaml.controls.treeview.selectednodes) コレクションに追加されます。 [SelectAll](/uwp/api/windows.ui.xaml.controls.treeview.selectall) メソッドを呼び出して、ツリー ビューですべてのノードを選択できます。

> [!NOTE]
> **SelectAll** を呼び出した場合、SelectionMode にかかわらず、実体化されたすべてのノードが選択されます。 一貫したユーザー エクスペリエンスを提供するため、SelectionMode が **Multiple** である場合にのみ SelectAll を呼び出す必要があります。

#### <a name="selection-and-realizedunrealized-nodes"></a>選択と実体化された/実体化されていないノード

ツリー ビューに実体化されていないノードが含まれる場合、それらは選択肢として考慮されません。 実体化されていないノードを選択する際に留意すべき点がいくつかあります。

- ユーザーが親ノードを選択すると、その親の下で実体化されたすべての子も選択されます。 同様に、すべての子ノードが選択されている場合、親ノードも選択されます。
- SelectAll メソッドは、実体化されたノードのみを SelectedNodes コレクションに追加します。
- 実体化されていない子を含む親ノードが選択された場合、子は実体化されたときに選択されます。

## <a name="code-examples"></a>コード例

### <a name="tree-view-using-xaml"></a>XAML を使用して、ツリー ビュー

次の例は、XAML で 1 つのツリー ビュー構造を作成する方法を示しています。 ツリー ビューは、カテゴリに配置されており、ユーザーが選択できるアイスクリームのフレーバーとトッピングを示しています。 複数選択が有効になっており、ユーザーがボタンをクリックすると、SelectedItems がメイン アプリ UI に表示されます。

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

### <a name="tree-view-using-data-binding"></a>データ バインディングを使用して、ツリー ビュー

この例では、前の例と同じツリー ビューを作成する方法を示します。 ただし、XAML でのデータの階層を作成するのではなくデータはコードで作成され、ツリー ビューの ItemsSource プロパティにバインドされています。 (前の例に示すように、ボタンのイベント ハンドラーに次の例も適用されます。)

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

### <a name="pictures-and-music-library-tree-view"></a>画像やミュージック ライブラリのツリー ビュー

この例では、ユーザーの画像やミュージック ライブラリのコンテンツや構造を表示するツリー ビューを作成する方法を示します。 項目の数は事前に知ることができないため、各ノードは展開時に入力され、折りたたまれたときに空になります。

カスタム項目テンプレートは、型が [IStorageItem](/uwp/api/windows.storage.istorageitem) であるデータ項目を表示するために使用されます。

> [!IMPORTANT]
> この例のコードでは、picturesLibrary 機能と musicLibrary 機能が必要です。 ファイル アクセスの詳細については、[ファイル アクセス許可](../../files/file-access-permissions.md)、[ファイルとフォルダーの列挙と照会](../../files/quickstart-listing-files-and-folders.md)、および[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](../../files/quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md) をご覧ください。

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

## <a name="related-articles"></a>関連記事

- [TreeView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)
- [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [ListViewと GridView](listview-and-gridview.md)
