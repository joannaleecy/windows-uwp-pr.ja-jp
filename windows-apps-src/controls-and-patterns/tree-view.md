---
author: Jwmsft
Description: "ツリー ビューのコード例を使用して、展開可能なツリーを作成します。"
title: "ツリー ビュー"
label: Tree view
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: 88e3e79b7ebdf06c200f3525095d7685f7e3e6dc

---
# <a name="hierarchical-layout-with-treeview"></a>ツリー ビューでの階層的なレイアウト
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<div class="microsoft-internal-note">
ツリー ビューの赤線を Design Depot で確認: http://designdepotweb1/DesignDepot.FrontEnd/#/Dashboard/856
</div>

ツリー ビューは、階層型のリスト パターンになっており、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができます。 入れ子になった項目は、追加のノードや標準的な一覧項目として使うことができます。 [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) を使用して、フォルダー構造や入れ子になった関係を UI で視覚的に示すツリー ビューを作成できます。

[ツリー ビューのサンプル](http://go.microsoft.com/fwlink/?LinkId=785018)は、**ListView** を使用して作成されたリファレンス実装です。 スタンドアロンのコントロールではありません。 Microsoft Edge ブラウザーの [お気に入り] ウィンドウに表示されるツリー ビューでは、このリファレンス実装を使用しています。

このサンプルでは、次をサポートします。
- N レベルの入れ子
- ノードの展開/折りたたみ
- ツリー ビュー内でのノードのドラッグ アンド ドロップ
- 組み込みのアクセシビリティ

![リファレンス サンプルでのツリー ビュー](images/tree-view-sample.png) | ![Edge ブラウザーでのツリー ビュー](images/tree-view-edge.png)
-- | --
ツリー ビューのリファレンス サンプル | Edge ブラウザーでのツリー ビュー

## <a name="is-this-the-right-pattern"></a>適切なパターンの選択

- 項目に入れ子になった一覧項目が含まれているとき、それらの項目とピアやノードとの階層関係を視覚的に示すことが重要になる場合は、ツリー ビューを使用します。

- 項目の入れ子になった関係を強調表示することが優先的な処理ではない場合は、ツリー ビューを使用しないでください。 ほとんどの演習用シナリオでは、標準的なリスト ビューが適しています

## <a name="treeview-ui-structure"></a>ツリー ビューの UI 構造

アイコンを使用して、ツリー ビュー内のノードを表すことができます。 インデントとアイコンを組み合わせて使用することで、フォルダー/親ノードとフォルダー以外の項目/子ノードとの間の入れ子になった関係を表すことができます。 その方法についてのガイダンスを説明します。

### <a name="icons"></a>アイコン

アイコンを使用して、項目がノードであることや、ノードの状態 (展開されているか、折りたたまれているか) を示すことができます。

#### <a name="chevron"></a>山形記号

一貫性を保つために、折りたたまれているノードでは右向きの山形記号を使用し、展開されているノードでは下向きの山形記号を使用します。

![ツリー ビューでの山形記号アイコンの使用](images/treeview_chevron.png)

#### <a name="folder"></a>フォルダー

フォルダー アイコンは、フォルダーをフォルダーとして表す場合にのみ使用します。

![ツリー ビューでのフォルダー アイコンの使用](images/treeview_folder.png)

#### <a name="chevron-and-folder"></a>山形記号とフォルダー

山形記号とフォルダーの組み合わせは、ツリー ビューに含まれるノード以外の一覧項目にもアイコンが指定されている場合にのみ使用します。

![ツリー ビューで山形記号のアイコンとフォルダー アイコンを組み合わせた使用](images/treeview_chevron_folder.png)

#### <a name="redlines-for-indentation-of-folders-and-non-folder-nodes"></a>フォルダーとフォルダー以外のノードのインデントを示す赤線

次のスクリーンショットでは、赤線を使用して、フォルダーとフォルダー以外のノードのインデントを示しています。

![フォルダーとフォルダー以外のノードのインデントを示す赤線](images/treeview_chevron_folder_indent_rl.png)

## <a name="building-a-treeview"></a>ツリー ビューの作成

ツリー ビューには、次の主なクラスがあります。 これらすべてのクラスは、リファレンス実装で定義されており、含まれています。

> **注**&nbsp;&nbsp;ツリー ビューは、C++ で記述された [Windows ランタイム コンポーネント](https://msdn.microsoft.com/windows/uwp/winrt-components/index)として実装されます。そのため、すべての言語の UWP アプリで参照できます。 サンプルでは、ツリー ビューのコードは *cpp/Control* フォルダーにあります。 C# では、対応する *cs/Control* フォルダーがありません。

- `TreeNode` クラスは、ツリー ビューの階層的なレイアウトを実装します。 また、項目テンプレートでツリー ビューにバインドされるデータも保持します。
- `TreeView` クラスは。ItemClick のイベント、フォルダーの展開/折りたたみのイベント、およびドラッグの開始のイベントを実装します。
- `TreeViewItem` クラスは、ドロップ操作のイベントを実装します。
- `ViewModel` クラスは、TreeViewItems のリストをフラット化します。これにより、キーボード ナビゲーションやドラッグ アンド ドロップなどの操作を ListView から継承できるようになります。

## <a name="create-a-data-template-for-your-treeviewitem"></a>TreeViewItem 用のデータ テンプレートを作成する

フォルダー項目やフォルダー以外の項目のデータ テンプレートをセットアップする XAML のセクションを次に示します。
- ListViewItem をフォルダーとして指定するには、その ListViewItem で [AllowDrop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.allowdrop.aspx) プロパティを **true** に明示的に設定する必要があります。 この XAML では、そのための 1 つの方法を示しています。
- ListViewItem をフォルダー以外の項目として指定するには、ListViewItem 自体のどのプロパティも指定する必要はありません。 ListView で AllowDrop プロパティを True に設定するだけです。
- 展開された/折りたたまれたフォルダー アイコンや、山形記号を使用して、フォルダーが展開されているか、折りたたまれているか を視覚的に示すことができます。
- この例で示すように、コンバーターを使用すると、展開されている状態と折りたたまれている状態の違いを示す場合に、異なるアイコンを選ぶことができます。

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

## <a name="set-up-the-data-in-your-treeview"></a>ツリー ビュー内のデータをセットアップする

ツリー ビューのサンプルで使われるデータをセットアップするコードを次に示します。

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

上記の手順を完了すると、N レベルの入れ子に基づいてすべてのデータが設定されたツリー ビュー/階層レイアウトが完成します。ここでは、フォルダーの展開/折りたたみ、フォルダー間のドラッグ アンド ドロップ、組み込みのアクセシビリティがサポートされています。

ユーザーがツリー ビューから項目の追加/削除を実行できるようにするには、そのためのオプションをユーザーに示すコンテキスト メニューを追加することをお勧めします。


## <a name="related-articles"></a>関連記事

- [ツリー ビューのサンプル](http://go.microsoft.com/fwlink/?LinkId=785018)
- [**ListView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [ListView と GridView](listview-and-gridview.md)



<!--HONumber=Dec16_HO2-->


