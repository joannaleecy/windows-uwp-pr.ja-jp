---
author: Jwmsft
Description: "テンプレートを使って、リスト ビュー コントロールまたはグリッド ビュー コントロールの項目の外観を変更します。"
title: "リスト ビュー項目テンプレート"
label: List view item templates
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: d8eb818d-b62e-4314-a612-f29142dbd93f
ms.openlocfilehash: b63b3a67db3b07cbfef6a89bdffb436605ab91ed
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="item-containers-and-templates"></a>項目コンテナーやテンプレート

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

**ListView** コントロールと **GridView** コントロールでは、項目の配置方法 (水平、垂直、折り返しなど) や、ユーザーが項目を操作する方法を管理しますが、画面に個別の項目を表示する方法については管理しません。 項目の視覚エフェクトは、項目コンテナーによって管理されます。 リスト ビューに項目を追加すると、追加した項目はコンテナーに自動的に設定されます。 ListView の既定の項目コンテナーは [**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listviewitem.aspx) であり、GridView の既定の項目コンテナーは [**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridviewitem.aspx) です。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**ListView クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)</li>
<li>[**GridView クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)</li>
<li>[**ItemTemplate プロパティ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)</li>
<li>[**ItemContainerStyle プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx)</li>
</ul>
</div>


> ListView と GridView はどちらも [**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) クラスから派生しているため、同じ機能を持ちますが、データの表示方法が異なります。 この記事では、特に指定がない限り、リスト ビューについての説明は ListView コントロールにも GridView コントロールにも適用されます。 ListView や ListViewItem などのクラスの説明については、プレフィックスの "List"** を "Grid"** に置き換えることで、対応するグリッド クラス (GridView または GridViewItem) に適用できます。 

これらのコンテナー コントロールは、"データ テンプレート"** と "コントロール テンプレート"** という 2 つの重要な部分から構成されており、これらを組み合わせることによって 1 つの項目で表示する最終的な外観が形成されます。

- **データ テンプレート** - [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) をリスト ビューの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てて、個別のデータ項目の表示方法を指定します。
- **コントロール テンプレート** - コントロール テンプレートは、表示状態など、フレームワークが担当する項目の視覚エフェクトの一部を提供します。 [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) プロパティを使って、コントロール テンプレートを変更できます。 通常では、ブランドに合うようにリスト ビューの色を変更したり、選択した項目の表示方法を変更する目的で、コントロール テンプレートを変更します。

次の画像は、コントロール テンプレートとデータ テンプレートを合わせて 1 つの項目で表示する最終的な外観を形成する方法を示しています。

![リスト ビュー コントロールやデータ テンプレート](images/listview-visual-parts.png)

この項目を作成する XAML を次に示します。 テンプレートについては、後で説明します。

```xaml
<ListView Width="220" SelectionMode="Multiple">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="x:String">
            <Grid Background="Yellow">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="54"/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Image Source="Assets/placeholder.png" Width="44" Height="44" 
                       HorizontalAlignment="Left"/>
                <TextBlock Text="{x:Bind}" Foreground="Blue" 
                           FontSize="36" Grid.Column="1"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="Background" Value="Green"/>
        </Style>
    </ListView.ItemContainerStyle>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```
 
## <a name="prerequisites"></a>前提条件

- リスト ビュー コントロールを使用できることを前提としています。 詳しくは、「[ListView と GridView](listview-and-gridview.md)」の記事をご覧ください。
- また、スタイルをインラインで使用する方法や、リソースとして使用する方法を含む、コントロールのスタイルやテンプレートについて理解していることも前提としています。 詳しくは、「[コントロールのスタイル](styling-controls.md)」と「[コントロールのテンプレート](control-templates.md)」をご覧ください。

## <a name="the-data"></a>データ

リスト ビューでデータ項目を表示する方法について詳しく説明する前に、表示するデータについて理解する必要があります。 この例では、`NamedColor` と呼ばれるデータ型を作成します。 `NamedColor` では、`Name`、`Color`、`Brush` という 3 つのプロパティとして公開されている、色の名前、色の値、色の **SolidColorBrush** を組み合わせます。
 
次に、[**Colors**](https://msdn.microsoft.com/library/windows/apps/windows.ui.colors.aspx) クラスの各名前付きの色の `NamedColor` オブジェクトを使って、**List** を設定します。 このリストは、リスト ビューの [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) として設定します。

クラスを定義したり、`NamedColors` リストを設定するためのコードを次に示します。

**C#**
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ColorsListApp
{
    public sealed partial class MainPage : Page
    {
        // The list of colors won't change after it's populated, so we use List<T>. 
        // If the data can change, we should use an ObservableCollection<T> intead.
        List<NamedColor> NamedColors = new List<NamedColor>();

        public MainPage()
        {
            this.InitializeComponent();

            // Use reflection to get all the properties of the Colors class.
            IEnumerable<PropertyInfo> propertyInfos = typeof(Colors).GetRuntimeProperties();

            // For each property, create a NamedColor with the property name (color name),
            // and property value (color value). Add it the NamedColors list.
            for (int i = 0; i < propertyInfos.Count(); i++)
            {
                NamedColors.Add(new NamedColor(propertyInfos.ElementAt(i).Name,
                                    (Color)propertyInfos.ElementAt(i).GetValue(null)));
            }

            colorsListView.ItemsSource = NamedColors;
        }
    }

    class NamedColor
    {
        public NamedColor(string colorName, Color colorValue)
        {
            Name = colorName;
            Color = colorValue;
        }

        public string Name { get; set; }

        public Color Color { get; set; }

        public SolidColorBrush Brush
        {
            get { return new SolidColorBrush(Color); }
        }
    }
}
```

## <a name="data-template"></a>データ テンプレート

データ テンプレートを指定して、リスト ビューにデータ項目の表示方法を伝えます。 

既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてリスト ビューに表示されます。 リスト ビューに 'NamedColors' データの表示方法を伝えることなく、リスト ビューでこのデータを表示する場合、次のように、単に **ToString** メソッドが返すものを表示します。

**XAML**
```xaml
<ListView x:Name="colorsListView"/>
```

![項目の文字列表現を示すリスト ビュー](images/listview-no-template.png)

データ項目の特定のプロパティに [**DisplayMemberPath**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) を設定すると、そのプロパティの文字列表現を表示できます。 ここでは、`NamedColor` 項目の `Name` プロパティに DisplayMemberPath を設定します。

**XAML**
```xaml
<ListView x:Name="colorsListView" DisplayMemberPath="Name" />
```

リスト ビューで、次のように名前で項目が表示されるようになりました。 より便利になりましたが、あまり興味を引くものではなく、多くの情報が隠されたままです。

![項目プロパティの文字列表現を示すリスト ビュー](images/listview-display-member-path.png)

通常は、リッチな表現でデータを表示する必要があります。 リスト ビューでの項目の表示方法を正確に指定するには、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。 DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。 レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。 DataTemplate は、リスト コントロールの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。

> [!IMPORTANT]
> **ItemTemplate** と **DisplayMemberPath** を同時に使うことはできません。 両方のプロパティが設定されていると、例外が発生します。

ここでは、色の名前や RGB 値が設定された項目の色で[**四角形**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.aspx)を表示する DataTemplate を定義します。 

> [!NOTE]
> DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使う場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。

**XAML**
```XAML
<ListView x:Name="colorsListView">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:NamedColor">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition MinWidth="54"/>
                    <ColumnDefinition Width="32"/>
                    <ColumnDefinition Width="32"/>
                    <ColumnDefinition Width="32"/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition/>
                    <RowDefinition/>
                </Grid.RowDefinitions>
                <Rectangle Width="44" Height="44" Fill="{x:Bind Brush}" Grid.RowSpan="2"/>
                <TextBlock Text="{x:Bind Name}" Grid.Column="1" Grid.ColumnSpan="4"/>
                <TextBlock Text="{x:Bind Color.R}" Grid.Column="1" Grid.Row="1" Foreground="Red"/>
                <TextBlock Text="{x:Bind Color.G}" Grid.Column="2" Grid.Row="1" Foreground="Green"/>
                <TextBlock Text="{x:Bind Color.B}" Grid.Column="3" Grid.Row="1" Foreground="Blue"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

このデータ テンプレートを使ってデータ項目を表示すると、次のようになります。

![データ テンプレートを使ったリスト ビュー項目](images/listview-data-template-0.png)

GridView でデータを表示することが必要になる場合もあります。 グリッド レイアウトにより適した方法でデータを表示する、その他のデータ テンプレートを次に示します。 今回は、GridView 用に XAML 内ではなく、リソースとしてデータ テンプレートを定義します。


**XAML**
```xaml
<Page.Resources>
    <DataTemplate x:Key="namedColorItemGridTemplate" x:DataType="local:NamedColor">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="32"/>
                <ColumnDefinition Width="32"/>
                <ColumnDefinition Width="32"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="96"/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
    
            <Rectangle Width="96" Height="96" Fill="{x:Bind Brush}" Grid.ColumnSpan="3" />
            <!-- Name -->
            <Border Background="#AAFFFFFF" Grid.ColumnSpan="3" Height="40" VerticalAlignment="Top">
                <TextBlock Text="{x:Bind Name}" TextWrapping="Wrap" Margin="4,0,0,0"/>
            </Border>
            <!-- RGB -->
            <Border Background="Gainsboro" Grid.Row="1" Grid.ColumnSpan="3"/>
            <TextBlock Text="{x:Bind Color.R}" Foreground="Red"
                   Grid.Column="0" Grid.Row="1" HorizontalAlignment="Center"/>
            <TextBlock Text="{x:Bind Color.G}" Foreground="Green"
                   Grid.Column="1" Grid.Row="1" HorizontalAlignment="Center"/>
            <TextBlock Text="{x:Bind Color.B}" Foreground="Blue" 
                   Grid.Column="2" Grid.Row="1" HorizontalAlignment="Center"/>
            <!-- HEX -->
            <Border Background="Gray" Grid.Row="2" Grid.ColumnSpan="3">
                <TextBlock Text="{x:Bind Color}" Foreground="White" Margin="4,0,0,0"/>
            </Border>
        </Grid>
    </DataTemplate>
</Page.Resources>

...

<GridView x:Name="colorsGridView" 
          ItemTemplate="{StaticResource namedColorItemGridTemplate}"/>
```

このデータ テンプレートを使ってグリッドにデータを表示すると、次のようになります。

![データ テンプレートを使ったグリッド ビュー項目](images/gridview-data-template.png)

### <a name="performance-considerations"></a>パフォーマンスに関する考慮事項

データ テンプレートは、リスト ビューの外観を定義する主要な方法です。 リストに多数の項目を表示した場合、パフォーマンスが大幅に低下することもあります。 

データ テンプレートのすべての XAML 要素のインスタンスが、リスト ビューの各項目用に作成されます。 たとえば、前の例のグリッド テンプレートには、10 個の XAML 要素 (1 つの Grid、1 つの Rectangle、3 つの Border、5 つの Textblock) が含まれています。 このデータ テンプレートを使って 20 個の項目を表示する GridView は、少なくとも 200 個 (20*10=200) の要素を作成します。 データ テンプレートの要素数を減らすと、リスト ビューで作成する要素の総数が大幅に減少します。 詳しくは、「[ListView と GridView の UI の最適化: 項目ごとの要素の削減](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview#element-reduction-per-item)」をご覧ください。

 このセクションのグリッド データ テンプレートについて考えてみます。 要素数を減らすための手法を確認しましょう。

**XAML**
```xaml
<!-- RGB -->
<Border Background="Gainsboro" Grid.Row="1" Grid.ColumnSpan="3"/>
<TextBlock Text="{x:Bind Color.R}" Foreground="Red"
           Grid.Column="0" Grid.Row="1" HorizontalAlignment="Center"/>
<TextBlock Text="{x:Bind Color.G}" Foreground="Green"
           Grid.Column="1" Grid.Row="1" HorizontalAlignment="Center"/>
<TextBlock Text="{x:Bind Color.B}" Foreground="Blue" 
           Grid.Column="2" Grid.Row="1" HorizontalAlignment="Center"/>
```

 - まず、このレイアウトは 1 つのグリッドを使用します。 1 列の Grid を用意して、StackPanel にこれら 3 つの TextBlock を配置できますが、何度も作成するデータ テンプレートでは、レイアウト パネルを他のレイアウト パネル内に埋め込まないようにする方法を探す必要があります。
 - 次に、Border コントロールを使って、Border 要素内に実際に項目を配置することなく背景をレンダリングできます。 Border 要素には子要素を 1 つしか配置できないため、他のレイアウト パネルを追加して、XAML の Border 要素内で 3 つの TextBlock 要素をホストする必要があります。 TextBlock を Border 要素の子要素にしないようにすれば、パネルで TextBlock を保持する必要がなくなります。
 - 最後に、StackPanel 内に TextBlock を配置して、明示的な Border 要素を使用する代わりに、StackPanel で border プロパティを設定できます。 ただし、Border 要素は StackPanel よりも軽量なコントロールであるため、何度もレンダリングするときのパフォーマンスの影響は少なくなります。

## <a name="control-template"></a>コントロール テンプレート
項目のコントロール テンプレートには、選択、ホバー、フォーカスなどの状態を表示する視覚効果が含まれています。 これらの視覚効果は、データ テンプレートの上または下にレンダリングされます。 ListView コントロール テンプレートによって描画される一般的な既定の視覚効果を次に示します。

- ホバー – 薄い灰色の四角形がデータ テンプレートの下に描画されます。  
- 選択 – 薄い青色の四角形がデータ テンプレートの下に描画されます。 
- キーボード フォーカス – 黒色と白色の点線で表された境界線が項目テンプレートの上に描画されます。 

![リスト ビューの状態の視覚効果](images/listview-state-visuals.png)

リスト ビューでは、データ テンプレートの要素とコントロール テンプレートの要素を組み合わせて、画面にレンダリングする最終的な視覚効果を作成します。 以下では、状態の視覚効果がリスト ビューのコンテキスト内で表示されています。

![異なる状態の項目を示すリスト ビュー](images/listview-states.png)

### <a name="listviewitempresenter"></a>ListViewItemPresenter

データ テンプレートについて上で説明したとおり、各項目で作成する XAML 要素の数は、リスト ビューのパフォーマンスに大きな影響を与えます。 データ テンプレートとコントロール テンプレートを組み合わせて各項目を表示するため、項目を表示するために必要な実際の要素数には、両方のテンプレートの要素数が含まれます。

ListView コントロールと GridView コントロールを最適化して、項目ごとに作成する XAML 要素の数を減らします。 **ListViewItem** の視覚効果は [**ListViewItemPresenter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.aspx) によって作成されます。ListViewItemPresenter は、多数の UIElement によるオーバーヘッドなしで、フォーカス、選択などの表示状態で複雑な視覚効果を表示する特別な XAML 要素です。
 
> [!NOTE]
> Windows 10 の UWP アプリでは、**ListViewItem** と **GridViewItem** の両方で **ListViewItemPresenter** を使います。GridViewItemPresenter は非推奨であるため、使わないでください。 ListViewItem と GridViewItem は、ListViewItemPresenter に異なるプロパティ値を設定して、異なる既定の外観を作成します)。

項目コンテナーの外観を変更するには、[**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) プロパティを使い、[**TargetType**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.targettype.aspx) に **ListViewItem** または **GridViewItem** を設定した [**Style**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) を提供します。

この例では、ListViewItem にパディングを追加して、リストの項目の間に余白を入れます。

```xaml
<ListView x:Name="colorsListView">
    <ListView.ItemTemplate>
        <!-- DataTemplate XAML shown in previous ListView example -->
    </ListView.ItemTemplate>

    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="Padding" Value="0,4"/>
        </Style>
    </ListView.ItemContainerStyle>
</ListView>
```

これで、項目の間に余白が入ったリスト ビューが次のように表示されます。

![パディングを適用したリスト ビューの項目](images/listview-data-template-1.png)

ListViewItem の既定のスタイルの場合、ListViewItemPresenter の **ContentMargin** プロパティには、ListViewItem の **Padding** プロパティにバインドする [**TemplateBinding**](https://msdn.microsoft.com/windows/uwp/xaml-platform/templatebinding-markup-extension) があります (`<ListViewItemPresenter ContentMargin="{TemplateBinding Padding}"/>`)。 Padding プロパティを設定すると、この値は実際に ListViewItemPresenter の ContentMargin プロパティに渡されます。

ListViewItems プロパティにテンプレート バインドされていないその他の ListViewItemPresenter プロパティを変更するには、プロパティを変更できる新しい ListViewItemPresenter を使って ListViewItem を再テンプレート化する必要があります。 

> [!NOTE]
> ListViewItem と GridViewItem の既定のスタイルには、ListViewItemPresenter の多くのプロパティが設定されています。 常に既定のスタイルのコピーを作成し、必要なプロパティのみ変更することをお勧めします。 そうしなければ、一部のプロパティを正しく設定していないことが原因で、視覚効果が期待どおりに表示されない可能性があります。

**Visual Studio で既定のテンプレートのコピーを作成するには**
 
1. [ドキュメント アウトライン] ウィンドウを開きます (**[表示] > [その他のウィンドウ] > [ドキュメント アウトライン]**)。
2. 変更するリストまたはグリッドの要素を選びます。 この例では、`colorsGridView` 要素を変更します。
3. `colorsGridView` を右クリックし、**[追加テンプレートの編集]、[生成されたアイテム コンテナーの編集 (ItemContainerStyle)]、[コピーして編集]** の順に選びます。
    ![Visual Studio のエディター](images/listview-itemcontainerstyle-vs.png)
4. [Style リソースの作成] ダイアログ ボックスで、スタイルの名前を入力します。 この例では、`colorsGridViewItemStyle` を使います。
    ![Visual Studio の [Style リソースの作成] ダイアログ (images/listview-style-resource-vs.png)

次の XAML で示すように、既定のスタイルのコピーをリソースとしてアプリに追加し、**GridView.ItemContainerStyle** プロパティをそのリソースに設定します。 

```xaml
<Style x:Key="colorsGridViewItemStyle" TargetType="GridViewItem">
    <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
    <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
    <Setter Property="Background" Value="Transparent"/>
    <Setter Property="Foreground" Value="{ThemeResource SystemControlForegroundBaseHighBrush}"/>
    <Setter Property="TabNavigation" Value="Local"/>
    <Setter Property="IsHoldingEnabled" Value="True"/>
    <Setter Property="HorizontalContentAlignment" Value="Center"/>
    <Setter Property="VerticalContentAlignment" Value="Center"/>
    <Setter Property="Margin" Value="0,0,4,4"/>
    <Setter Property="MinWidth" Value="{ThemeResource GridViewItemMinWidth}"/>
    <Setter Property="MinHeight" Value="{ThemeResource GridViewItemMinHeight}"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="GridViewItem">
                <ListViewItemPresenter 
                    CheckBrush="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" 
                    ContentMargin="{TemplateBinding Padding}" 
                    CheckMode="Overlay" 
                    ContentTransitions="{TemplateBinding ContentTransitions}" 
                    CheckBoxBrush="{ThemeResource SystemControlBackgroundChromeMediumBrush}" 
                    DragForeground="{ThemeResource ListViewItemDragForegroundThemeBrush}" 
                    DragOpacity="{ThemeResource ListViewItemDragThemeOpacity}" 
                    DragBackground="{ThemeResource ListViewItemDragBackgroundThemeBrush}" 
                    DisabledOpacity="{ThemeResource ListViewItemDisabledThemeOpacity}" 
                    FocusBorderBrush="{ThemeResource SystemControlForegroundAltHighBrush}" 
                    FocusSecondaryBorderBrush="{ThemeResource SystemControlForegroundBaseHighBrush}" 
                    HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" 
                    PointerOverForeground="{ThemeResource SystemControlForegroundBaseHighBrush}" 
                    PressedBackground="{ThemeResource SystemControlHighlightListMediumBrush}" 
                    PlaceholderBackground="{ThemeResource ListViewItemPlaceholderBackgroundThemeBrush}" 
                    PointerOverBackground="{ThemeResource SystemControlHighlightListLowBrush}" 
                    ReorderHintOffset="{ThemeResource GridViewItemReorderHintThemeOffset}" 
                    SelectedPressedBackground="{ThemeResource SystemControlHighlightListAccentHighBrush}" 
                    SelectionCheckMarkVisualEnabled="True" 
                    SelectedForeground="{ThemeResource SystemControlForegroundBaseHighBrush}" 
                    SelectedPointerOverBackground="{ThemeResource SystemControlHighlightListAccentMediumBrush}" 
                    SelectedBackground="{ThemeResource SystemControlHighlightAccentBrush}" 
                    VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"/>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>

...

<GridView x:Name="colorsGridView" ItemContainerStyle="{StaticResource colorsGridViewItemStyle}"/>
```

これで、ListViewItemPresenter のプロパティを変更して、選択チェック ボックス、項目の配置、ブラシの色の表示状態を制御できるようになりました。 

#### <a name="inline-and-overlay-selection-visuals"></a>インラインとオーバーレイの選択ビジュアル

ListView と GridView では、コントロールや [ **SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) に応じて、選択されている項目をさまざまな方法で示します。 リスト ビューについて詳しくは、「[ListView と GridView](listview-and-gridview.md)」をご覧ください。 

**SelectionMode** を **Multiple** に設定すると、選択チェック ボックスは項目のコントロール テンプレートの一部として表示されます。 [**SelectionCheckMarkVisualEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectioncheckmarkvisualenabled.aspx) プロパティを使って、Multiple 選択モードの選択チェック ボックスをオフにできます。 ただし、このプロパティは他の選択モードでは無視されるため、Extended または Single 選択モードのチェック ボックスをオンにすることはできません。

[**CheckMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.checkmode.aspx) プロパティを設定して、インライン スタイルまたはオーバーレイ スタイルのどちらを使ってチェック ボックスを表示するかを指定できます。

- **Inline**: このスタイルは、コンテンツの左側にチェック ボックスを表示し、項目コンテナーの背景を色付けすることで、選択された状態を示します。 これは、ListView の既定のスタイルです。
- **Overlay**: このスタイルは、コンテンツの上部にチェック ボックスを表示し、項目コンテナーの境界線のみを色付けすることで、選択された状態を示します。 これは、GridView の既定のスタイルです。

次の表は、選択された状態を示すために使用する既定の視覚効果を示しています。

SelectionMode: &nbsp;&nbsp; | Single/Extended | Multiple
---------------|-----------------|---------
Inline | ![Inline かつ Single/Extended の選択](images/listview-single-selection.png) | ![Inline かつ Multiple の選択](images/listview-multi-selection.png)
Overlay | ![Overlay かつ Single/Extended の選択](images/gridview-single-selection.png) | ![Overlay かつ Multiple の選択](images/gridview-multi-selection.png)

> [!NOTE]
> この例と次の例では、コントロール テンプレートによって提供されている視覚効果に焦点を当てるために、データ テンプレートなしでシンプルな文字列データ項目を表示しています。

また、チェック ボックスの色を変更するためのブラシ プロパティも複数用意されています。 詳しくは、以下で他のブラシ プロパティと共に説明します。

#### <a name="brushes"></a>ブラシ 

多くのプロパティでは、異なる表示状態で使用するブラシを指定します。 ブランドに合わせてブラシを変更することが必要になる場合もあります。 

次の表は、ListViewItem の一般的な表示状態と選択された表示状態、および各状態のレンダリングで使用するブラシを示しています。 画像は、インラインとオーバーレイの両方の選択視覚スタイルにおける、ブラシの効果を示しています。

> [!NOTE]
> この表の場合、ブラシで変更する色値はハードコードされた名前付きの色です。テンプレートのどこに適用されるかをはっきりと理解できるように、名前付きの色を選択しています。 これらは、表示状態の既定の色ではありません。 アプリの既定の色を変更する場合は、既定のテンプレートで設定されているように、ブラシのリソースを使って色値を変更する必要があります。

状態/ブラシの名前 | インライン スタイル | オーバーレイ スタイル
------------|--------------|--------------
<b>Normal</b><ul><li><b>CheckBoxBrush="Red"</b></li></ul> | ![インラインの項目の選択 (通常)](images/listview-item-normal.png) | ![オーバーレイの項目の選択 (通常)](images/gridview-item-normal.png)
<b>PointerOver</b><ul><li><b>PointerOverForeground="DarkOrange"</b></li><li><b>PointerOverBackground="MistyRose"</b></li><li>CheckBoxBrush="Red"</li></ul> | ![インラインの項目の選択 (ホバー)](images/listview-item-pointerover.png) | ![オーバーレイの項目の選択 (ホバー)](images/gridview-item-pointerover.png)
<b>Pressed</b><ul><li><b>PressedBackground="LightCyan"</b></li><li>PointerOverForeground="DarkOrange"</li><li>CheckBoxBrush="Red"</li></ul> | ![インラインの項目の選択 (押す)](images/listview-item-pressed.png) | ![オーバーレイの項目の選択 (押す)](images/gridview-item-pressed.png)
<b>Selected</b><ul><li><b>SelectedForeground="Navy"</b></li><li><b>SelectedBackground="Khaki"</b></li><li><b>CheckBrush="Green"</b></li><li>CheckBoxBrush="Red" (インラインのみ)</li></ul> | ![インラインの項目の選択 (選択)](images/listview-item-selected.png) | ![オーバーレイの項目の選択 (選択)](images/gridview-item-selected.png)
<b>PointerOverSelected</b><ul><li><b>SelectedPointerOverBackground="Lavender"</b></li><li>SelectedForeground="Navy"</li><li>SelectedBackground="Khaki" (オーバーレイのみ)</li><li>CheckBrush="Green"</li><li>CheckBoxBrush="Red" (インラインのみ)</li></ul> | ![インラインの項目の選択 (ホバー、選択)](images/listview-item-pointeroverselected.png) | ![オーバーレイの項目の選択 (ホバー、選択)](images/gridview-item-pointeroverselected.png)
<b>PressedSelected</b><ul><li><b>SelectedPressedBackground="MediumTurquoise"</b></li></li><li>SelectedForeground="Navy"</li><li>SelectedBackground="Khaki" (オーバーレイのみ)</li><li>CheckBrush="Green"</li><li>CheckBoxBrush="Red" (インラインのみ)</li></ul> | ![インラインの項目の選択 (押す、選択)](images/listview-item-pressedselected.png) | ![オーバーレイの項目の選択 (押す、選択)](images/gridview-item-pressedselected.png)
<b>Focused</b><ul><li><b>FocusBorderBrush="Crimson"</b></li><li><b>FocusSecondaryBorderBrush="Gold"</b></li><li>CheckBoxBrush="Red"</li></ul> | ![インラインの項目の選択 (フォーカス)](images/listview-item-focused.png) | ![オーバーレイの項目の選択 (フォーカス)](images/gridview-item-focused.png)

ListViewItemPresenter には、データのプレース ホルダーやドラッグ状態用のブラシ プロパティが他にもあります。 リスト ビューで段階的読み込みやドラッグ アンド ドロップを使用する場合は、このような追加のブラシ プロパティを変更する必要があるかについても検討することをお勧めします。 変更できるプロパティの完全な一覧については、ListViewItemPresenter クラスをご覧ください。 

### <a name="expanded-xaml-item-templates"></a>展開時の XAML 項目テンプレート

たとえば、**ListViewItemPresenter** プロパティで許可されていない変更を行う必要がある場合や、チェック ボックスの位置を変更する必要がある場合は、*ListViewItemExpanded* テンプレートまたは *GridViewItemExpanded* テンプレートを使用できます。 これらのテンプレートは、generic.xaml の既定のスタイルに含まれています。 これらは、個別の UIElement からすべての視覚効果をビルドする標準の XAML パターンに従います。

既に説明したように、項目テンプレート内の UIElement の数は、リスト ビューのパフォーマンスに大きな影響を与えます。 ListViewItemPresenter を展開時の XAML テンプレートに置き換えると、要素の数が大幅に増大するため、リスト ビューで多数の項目を表示する場合や、パフォーマンスを懸念する場合は推奨しません。

> [!NOTE]
> **ListViewItemPresenter** は、リスト ビューの [**ItemsPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) が [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) または [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) である場合にのみサポートされます。 [**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)、[**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.wrapgrid.aspx)、または [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.aspx) を使うように ItemsPanel を変更すると、項目テンプレートは展開時の XAML テンプレートに自動的に切り替わります。 詳しくは、「[ListView と GridView の UI の最適化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview)」をご覧ください。

展開時の XAML テンプレートをカスタマイズするには、アプリでコピーを作成し、コピーに **ItemContainerStyle** プロパティを設定します。

**展開時のテンプレートをコピーするには**
1. 次に示すように、ListView または GridView に ItemContainerStyle プロパティを設定します。
    ```xaml
    <ListView ItemContainerStyle="{StaticResource ListViewItemExpanded}"/>
    <GridView ItemContainerStyle="{StaticResource GridViewItemExpanded}"/>
    ```
2. Visual Studio の [プロパティ] ウィンドウで、[その他] セクションを展開し、ItemContainerStyle プロパティを探します。 (ListView または GridView が選択されていることを確認します)。
3. ItemContainerStyle プロパティのプロパティ マーカーをクリックします。 (TextBox の横にある小さなボックスです。 StaticResource に設定されていることを示すために緑色で表示されています)。プロパティ メニューが開きます。
4. プロパティ メニューで、**[新しいリソースに変換]** をクリックします。 
    
    ![Visual Studio のプロパティ メニュー](images/listview-convert-resource-vs.png)
5. [Style リソースの作成] ダイアログ ボックスで、リソースの名前を入力し、[OK] をクリックします。

generic.xaml の展開時のテンプレートのコピーがアプリで作成され、必要に応じて変更できるようになります。


## <a name="related-articles"></a>関連記事

- [リスト](lists.md)
- [ListView と GridView](listview-and-gridview.md)

