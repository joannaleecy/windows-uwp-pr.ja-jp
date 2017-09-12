---
author: Jwmsft
Description: "ツリー ビューのコード例を使用して、展開可能なツリーを作成します。"
title: "ツリー ビュー"
label: Tree view
template: detail.hbs
ms.openlocfilehash: c7ad99d20fe30ea4b94ad62de45b3832aae3805e
ms.sourcegitcommit: b42d14c775efbf449a544ddb881abd1c65c1ee86
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/20/2017
---
# <a name="hierarchical-layout-with-treeview"></a><span data-ttu-id="7905c-103">ツリー ビューでの階層的なレイアウト</span><span class="sxs-lookup"><span data-stu-id="7905c-103">Hierarchical layout with TreeView</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="7905c-104">ツリー ビューは、階層型のリスト パターンになっており、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-104">A TreeView is a hierarchical list pattern with expanding and collapsing nodes that contain nested items.</span></span> <span data-ttu-id="7905c-105">入れ子になった項目は、追加のノードや標準的な一覧項目として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-105">Nested items can be additional nodes or regular list items.</span></span> <span data-ttu-id="7905c-106">[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) を使用して、フォルダー構造や入れ子になった関係を UI で視覚的に示すツリー ビューを作成できます。</span><span class="sxs-lookup"><span data-stu-id="7905c-106">You can use a [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) to build a tree view to illustrate a folder structure or nested relationships in your UI.</span></span>

<span data-ttu-id="7905c-107">[ツリー ビューのサンプル](http://go.microsoft.com/fwlink/?LinkId=785018)は、**ListView** を使用して作成されたリファレンス実装です。</span><span class="sxs-lookup"><span data-stu-id="7905c-107">The [TreeView sample](http://go.microsoft.com/fwlink/?LinkId=785018) is a reference implementation built using **ListView**.</span></span> <span data-ttu-id="7905c-108">スタンドアロンのコントロールではありません。</span><span class="sxs-lookup"><span data-stu-id="7905c-108">It is not a standalone control.</span></span> <span data-ttu-id="7905c-109">Microsoft Edge ブラウザーの [お気に入り] ウィンドウに表示されるツリー ビューでは、このリファレンス実装を使用しています。</span><span class="sxs-lookup"><span data-stu-id="7905c-109">The TreeView seen in the Favorites Pane in the Microsoft Edge browser uses this reference implementation.</span></span>

<span data-ttu-id="7905c-110">このサンプルでは、次をサポートします。</span><span class="sxs-lookup"><span data-stu-id="7905c-110">The sample supports:</span></span>
- <span data-ttu-id="7905c-111">N レベルの入れ子</span><span class="sxs-lookup"><span data-stu-id="7905c-111">N-level nesting</span></span>
- <span data-ttu-id="7905c-112">ノードの展開/折りたたみ</span><span class="sxs-lookup"><span data-stu-id="7905c-112">Expanding/collapsing of nodes</span></span>
- <span data-ttu-id="7905c-113">ツリー ビュー内でのノードのドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="7905c-113">Dragging and dropping of nodes within the TreeView</span></span>
- <span data-ttu-id="7905c-114">組み込みのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="7905c-114">Built-in accessibility</span></span>

![リファレンス サンプルでのツリー ビュー](images/tree-view-sample.png) | ![Edge ブラウザーでのツリー ビュー](images/tree-view-edge.png)
-- | --
<span data-ttu-id="7905c-117">ツリー ビューのリファレンス サンプル</span><span class="sxs-lookup"><span data-stu-id="7905c-117">TreeView reference sample</span></span> | <span data-ttu-id="7905c-118">Edge ブラウザーでのツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="7905c-118">TreeView in Edge browser</span></span>

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="7905c-119">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="7905c-119">Is this the right pattern?</span></span>

- <span data-ttu-id="7905c-120">項目に入れ子になった一覧項目が含まれているとき、それらの項目とピアやノードとの階層関係を視覚的に示すことが重要になる場合は、ツリー ビューを使用します。</span><span class="sxs-lookup"><span data-stu-id="7905c-120">Use a TreeView when items have nested list items, and if it is important to illustrate the hierarchical relationship of items to their peers and nodes.</span></span>

- <span data-ttu-id="7905c-121">項目の入れ子になった関係を強調表示することが優先的な処理ではない場合は、ツリー ビューを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="7905c-121">Avoid using TreeView if highlighting the nested relationship of an item is not a priority.</span></span> <span data-ttu-id="7905c-122">ほとんどの演習用シナリオでは、標準的なリスト ビューが適しています</span><span class="sxs-lookup"><span data-stu-id="7905c-122">For most drill-in scenarios, a regular list view is appropriate</span></span>

## <a name="treeview-ui-structure"></a><span data-ttu-id="7905c-123">ツリー ビューの UI 構造</span><span class="sxs-lookup"><span data-stu-id="7905c-123">TreeView UI structure</span></span>

<span data-ttu-id="7905c-124">アイコンを使用して、ツリー ビュー内のノードを表すことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-124">You can use icons to represent nodes in a TreeView.</span></span> <span data-ttu-id="7905c-125">インデントとアイコンを組み合わせて使用することで、フォルダー/親ノードとフォルダー以外の項目/子ノードとの間の入れ子になった関係を表すことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-125">A combination of indentation and icons can be used to represent the nested relationship between folder/parent nodes and non-folder/child nodes.</span></span> <span data-ttu-id="7905c-126">その方法についてのガイダンスを説明します。</span><span class="sxs-lookup"><span data-stu-id="7905c-126">Here is guidance on how to do so.</span></span>

### <a name="icons"></a><span data-ttu-id="7905c-127">アイコン</span><span class="sxs-lookup"><span data-stu-id="7905c-127">Icons</span></span>

<span data-ttu-id="7905c-128">アイコンを使用して、項目がノードであることや、ノードの状態 (展開されているか、折りたたまれているか) を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-128">Use icons to indicate that an item is a node, as well as what state the node is in (expanded or collapsed).</span></span>

#### <a name="chevron"></a><span data-ttu-id="7905c-129">山形記号</span><span class="sxs-lookup"><span data-stu-id="7905c-129">Chevron</span></span>

<span data-ttu-id="7905c-130">一貫性を保つために、折りたたまれているノードでは右向きの山形記号を使用し、展開されているノードでは下向きの山形記号を使用します。</span><span class="sxs-lookup"><span data-stu-id="7905c-130">For consistency, collapsed nodes should use a chevron pointing to the right, and expanded nodes should use a chevron pointing down.</span></span>

![ツリー ビューでの山形記号アイコンの使用](images/treeview_chevron.png)

#### <a name="folder"></a><span data-ttu-id="7905c-132">フォルダー</span><span class="sxs-lookup"><span data-stu-id="7905c-132">Folder</span></span>

<span data-ttu-id="7905c-133">フォルダー アイコンは、フォルダーをフォルダーとして表す場合にのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="7905c-133">Use a folder icon only for literal representations of folders.</span></span>

![ツリー ビューでのフォルダー アイコンの使用](images/treeview_folder.png)

#### <a name="chevron-and-folder"></a><span data-ttu-id="7905c-135">山形記号とフォルダー</span><span class="sxs-lookup"><span data-stu-id="7905c-135">Chevron and Folder</span></span>

<span data-ttu-id="7905c-136">山形記号とフォルダーの組み合わせは、ツリー ビューに含まれるノード以外の一覧項目にもアイコンが指定されている場合にのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="7905c-136">A combination of a chevron and a folder should be used only if non-node list items in the TreeView also have icons.</span></span>

![ツリー ビューで山形記号のアイコンとフォルダー アイコンを組み合わせた使用](images/treeview_chevron_folder.png)

#### <a name="redlines-for-indentation-of-folders-and-non-folder-nodes"></a><span data-ttu-id="7905c-138">フォルダーとフォルダー以外のノードのインデントを示す赤線</span><span class="sxs-lookup"><span data-stu-id="7905c-138">Redlines for indentation of folders and non-folder nodes</span></span>

<span data-ttu-id="7905c-139">次のスクリーンショットでは、赤線を使用して、フォルダーとフォルダー以外のノードのインデントを示しています。</span><span class="sxs-lookup"><span data-stu-id="7905c-139">Use the redlines in the screenshot below for indentation of folder and non-folder nodes.</span></span>

![フォルダーとフォルダー以外のノードのインデントを示す赤線](images/treeview_chevron_folder_indent_rl.png)

## <a name="building-a-treeview"></a><span data-ttu-id="7905c-141">ツリー ビューの作成</span><span class="sxs-lookup"><span data-stu-id="7905c-141">Building a TreeView</span></span>

<span data-ttu-id="7905c-142">ツリー ビューには、次の主なクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="7905c-142">TreeView has the following main classes.</span></span> <span data-ttu-id="7905c-143">これらすべてのクラスは、リファレンス実装で定義されており、含まれています。</span><span class="sxs-lookup"><span data-stu-id="7905c-143">All of these are defined and included in the reference implementation.</span></span>

> <span data-ttu-id="7905c-144">**注**&nbsp;&nbsp;ツリー ビューは、C++ で記述された [Windows ランタイム コンポーネント](https://msdn.microsoft.com/windows/uwp/winrt-components/index)として実装されます。そのため、すべての言語の UWP アプリで参照できます。</span><span class="sxs-lookup"><span data-stu-id="7905c-144">**Note**&nbsp;&nbsp;TreeView is implemented as a [Windows Runtime component](https://msdn.microsoft.com/windows/uwp/winrt-components/index) written in C++, so it can be referenced by a UWP app in any language.</span></span> <span data-ttu-id="7905c-145">サンプルでは、ツリー ビューのコードは *cpp/Control* フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="7905c-145">In the sample, the TreeView code is located in the *cpp/Control* folder.</span></span> <span data-ttu-id="7905c-146">C# では、対応する *cs/Control* フォルダーがありません。</span><span class="sxs-lookup"><span data-stu-id="7905c-146">There is no corresponding *cs/Control* folder for C#.</span></span>

- <span data-ttu-id="7905c-147">`TreeNode` クラスは、ツリー ビューの階層的なレイアウトを実装します。</span><span class="sxs-lookup"><span data-stu-id="7905c-147">The `TreeNode` class implements the hierarchical layout for the TreeView.</span></span> <span data-ttu-id="7905c-148">また、項目テンプレートでツリー ビューにバインドされるデータも保持します。</span><span class="sxs-lookup"><span data-stu-id="7905c-148">It also holds the data that will be bound to it in the items template.</span></span>
- <span data-ttu-id="7905c-149">`TreeView` クラスは。ItemClick のイベント、フォルダーの展開/折りたたみのイベント、およびドラッグの開始のイベントを実装します。</span><span class="sxs-lookup"><span data-stu-id="7905c-149">The `TreeView` class implements events for ItemClick, expand/collapse of folders, and drag initiation.</span></span>
- <span data-ttu-id="7905c-150">`TreeViewItem` クラスは、ドロップ操作のイベントを実装します。</span><span class="sxs-lookup"><span data-stu-id="7905c-150">The `TreeViewItem` class implements the events for the drop operation.</span></span>
- <span data-ttu-id="7905c-151">`ViewModel` クラスは、TreeViewItems のリストをフラット化します。これにより、キーボード ナビゲーションやドラッグ アンド ドロップなどの操作を ListView から継承できるようになります。</span><span class="sxs-lookup"><span data-stu-id="7905c-151">The `ViewModel` class flattens the list of TreeViewItems so that operations such as keyboard navigation, and drag-and-drop can be inherited from ListView.</span></span>

## <a name="create-a-data-template-for-your-treeviewitem"></a><span data-ttu-id="7905c-152">TreeViewItem 用のデータ テンプレートを作成する</span><span class="sxs-lookup"><span data-stu-id="7905c-152">Create a data template for your TreeViewItem</span></span>

<span data-ttu-id="7905c-153">フォルダー項目やフォルダー以外の項目のデータ テンプレートをセットアップする XAML のセクションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="7905c-153">Here is the section of the XAML that sets up the data template for folder and non-folder type items.</span></span>
- <span data-ttu-id="7905c-154">ListViewItem をフォルダーとして指定するには、その ListViewItem で [AllowDrop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.allowdrop.aspx) プロパティを **true** に明示的に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7905c-154">To specify a ListViewItem as a folder, you will need to explicitly set the [AllowDrop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.allowdrop.aspx) property to **true** on that ListViewItem.</span></span> <span data-ttu-id="7905c-155">この XAML では、そのための 1 つの方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7905c-155">This XAML shows you one way to do so.</span></span>
- <span data-ttu-id="7905c-156">ListViewItem をフォルダー以外の項目として指定するには、ListViewItem 自体のどのプロパティも指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7905c-156">To specify a ListViewItem as a non-folder, you do not need to specify any property on the ListViewItem itself.</span></span> <span data-ttu-id="7905c-157">ListView で AllowDrop プロパティを True に設定するだけです。</span><span class="sxs-lookup"><span data-stu-id="7905c-157">Just set the AllowDrop property to True on the ListView.</span></span>
- <span data-ttu-id="7905c-158">展開された/折りたたまれたフォルダー アイコンや、山形記号を使用して、フォルダーが展開されているか、折りたたまれているか を視覚的に示すことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-158">You can use expanded/collapsed folder icons or chevrons to visually indicate if a folder is expanded or collapsed.</span></span>
- <span data-ttu-id="7905c-159">この例で示すように、コンバーターを使用すると、展開されている状態と折りたたまれている状態の違いを示す場合に、異なるアイコンを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="7905c-159">You can use converters to choose the different icons needed for the expanded versus the collapsed state as seen in this example.</span></span>

```xaml
<!-- MainPage.xaml -->
<DataTemplate x:Key="TreeViewItemDataTemplate">
    <StackPanel Orientation="Horizontal" Height="40" Margin="{Binding Depth, Converter={StaticResource IntToIndConverter}}" AllowDrop="{Binding Data.IsFolder}">
        <FontIcon x:Name="expandCollapseChevron"
                  Glyph="{Binding IsExpanded, Converter={StaticResource expandCollapseGlyphConverter}}"
                  Visibility="{Binding Data.IsFolder, Converter={StaticResource booleanToVisibilityConverter}}"                           
                  FontSize="12"
                  Margin="12,8,12,8"
                  FontFamily="Segoe MDL2 Assets"                          
                  />
        <Grid>
            <FontIcon x:Name ="expandCollapseFolder"
                      Glyph="{Binding IsExpanded, Converter={StaticResource folderGlyphConverter}}"
                      Foreground="#FFFFE793"
                      FontSize="16"
                      Margin="0,8,12,8"
                      FontFamily="Segoe MDL2 Assets"
                      Visibility="{Binding Data.IsFolder, Converter={StaticResource booleanToVisibilityConverter}}"
                      />

            <FontIcon x:Name ="nonFolderIcon"
                      Glyph="&#xE160;"
                      Foreground="{ThemeResource SystemControlForegroundBaseLowBrush}"
                      FontSize="12"
                      Margin="20,8,12,8"
                      FontFamily="Segoe MDL2 Assets"
                      Visibility="{Binding Data.IsFolder, Converter={StaticResource inverseBooleanToVisibilityConverter}}"
                      />

            <FontIcon x:Name ="expandCollapseFolderOutline"
                      Glyph="{Binding IsExpanded, Converter={StaticResource folderOutlineGlyphConverter}}"
                      Foreground="#FFECC849"
                      FontSize="16"
                      Margin="0,8,12,8"
                      FontFamily="Segoe MDL2 Assets"
                      Visibility="{Binding Data.IsFolder, Converter={StaticResource booleanToVisibilityConverter}}"/>
        </Grid>

        <TextBlock Text="{Binding Data.Name}"
                   HorizontalAlignment="Stretch"
                   VerticalAlignment="Center"  
                   FontWeight="Medium"
                   FontFamily="Segoe MDL2 Assests"                           
                   Style="{ThemeResource BodyTextBlockStyle}"/>
    </StackPanel>
</DataTemplate>
```

## <a name="set-up-the-data-in-your-treeview"></a><span data-ttu-id="7905c-160">ツリー ビュー内のデータをセットアップする</span><span class="sxs-lookup"><span data-stu-id="7905c-160">Set up the data in your TreeView</span></span>

<span data-ttu-id="7905c-161">ツリー ビューのサンプルで使われるデータをセットアップするコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="7905c-161">Here is the code that sets up the data in the TreeView sample.</span></span>

```csharp
 public MainPage()
 {
     this.InitializeComponent();

     TreeNode workFolder = CreateFolderNode("Work Documents");
     workFolder.Add(CreateFileNode("Feature Functional Spec"));
     workFolder.Add(CreateFileNode("Feature Schedule"));
     workFolder.Add(CreateFileNode("Overall Project Plan"));
     workFolder.Add(CreateFileNode("Feature Resource allocation"));
     sampleTreeView.RootNode.Add(workFolder);

     TreeNode remodelFolder = CreateFolderNode("Home Remodel");
     remodelFolder.IsExpanded = true;
     remodelFolder.Add(CreateFileNode("Contactor Contact Information"));
     remodelFolder.Add(CreateFileNode("Paint Color Scheme"));
     remodelFolder.Add(CreateFileNode("Flooring woodgrain types"));
     remodelFolder.Add(CreateFileNode("Kitchen cabinet styles"));

     TreeNode personalFolder = CreateFolderNode("Personal Documents");
     personalFolder.IsExpanded = true;
     personalFolder.Add(remodelFolder);

     sampleTreeView.RootNode.Add(personalFolder);
 }

 private static TreeNode CreateFileNode(string name)
 {
     return new TreeNode() { Data = new FileSystemData(name) };
 }

 private static TreeNode CreateFolderNode(string name)
 {
     return new TreeNode() { Data = new FileSystemData(name) { IsFolder = true } };
 }
```

<span data-ttu-id="7905c-162">上記の手順を完了すると、N レベルの入れ子に基づいてすべてのデータが設定されたツリー ビュー/階層レイアウトが完成します。ここでは、フォルダーの展開/折りたたみ、フォルダー間のドラッグ アンド ドロップ、組み込みのアクセシビリティがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="7905c-162">Once you’re done with the above steps, you will have a fully populated TreeView/Hierarchical layout with n-level nesting, support for expand/collapse of folders, dragging and dropping between folders, and accessibility built in.</span></span>

<span data-ttu-id="7905c-163">ユーザーがツリー ビューから項目の追加/削除を実行できるようにするには、そのためのオプションをユーザーに示すコンテキスト メニューを追加することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7905c-163">To provide the user the ability to add/remove items from the TreeView, we recommend you add a context menu to expose those options to the user.</span></span>


## <a name="related-articles"></a><span data-ttu-id="7905c-164">関連記事</span><span class="sxs-lookup"><span data-stu-id="7905c-164">Related articles</span></span>

- [<span data-ttu-id="7905c-165">ツリー ビューのサンプル</span><span class="sxs-lookup"><span data-stu-id="7905c-165">TreeView sample</span></span>](http://go.microsoft.com/fwlink/?LinkId=785018)
- [**<span data-ttu-id="7905c-166">ListView</span><span class="sxs-lookup"><span data-stu-id="7905c-166">ListView</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [<span data-ttu-id="7905c-167">ListView と GridView</span><span class="sxs-lookup"><span data-stu-id="7905c-167">ListView and GridView</span></span>](listview-and-gridview.md)
