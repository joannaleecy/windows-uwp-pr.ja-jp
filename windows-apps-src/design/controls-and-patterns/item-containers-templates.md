---
Description: ListView、GridView コントロール内の項目の外観を変更するのにには、テンプレートを使用します。
title: 項目コンテナーやテンプレート
label: Item containers and templates
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: d8eb818d-b62e-4314-a612-f29142dbd93f
pm-contact: predavid
design-contact: kimsea
dev-contact: ranjeshj
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 5b628c4d473c2a74eb63a17c12b17ade43c11964
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244418"
---
# <a name="item-containers-and-templates"></a><span data-ttu-id="0b1bf-104">項目コンテナーやテンプレート</span><span class="sxs-lookup"><span data-stu-id="0b1bf-104">Item containers and templates</span></span>

 

<span data-ttu-id="0b1bf-105">**ListView** コントロールと **GridView** コントロールでは、項目の配置方法 (水平、垂直、折り返しなど) や、ユーザーが項目を操作する方法を管理しますが、画面に個別の項目を表示する方法については管理しません。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-105">**ListView** and **GridView** controls manage how their items are arranged (horizontal, vertical, wrapping, etc…) and how a user interacts with the items, but not how the individual items are shown on the screen.</span></span> <span data-ttu-id="0b1bf-106">項目の視覚エフェクトは、項目コンテナーによって管理されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-106">Item visualization is managed by item containers.</span></span> <span data-ttu-id="0b1bf-107">リスト ビューに項目を追加すると、追加した項目はコンテナーに自動的に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-107">When you add items to a list view they are automatically placed in a container.</span></span> <span data-ttu-id="0b1bf-108">ListView の既定の項目コンテナーは [ListViewItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listviewitem.aspx) であり、GridView の既定の項目コンテナーは [GridViewItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridviewitem.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-108">The default item container for ListView is [ListViewItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listviewitem.aspx); for GridView, it’s [GridViewItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridviewitem.aspx).</span></span>

> <span data-ttu-id="0b1bf-109">**重要な API**:[ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、 [GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)、 [ItemTemplate プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)、 [ItemContainerStyle プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-109">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx), [ItemTemplate property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx), [ItemContainerStyle property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx)</span></span>


> [!NOTE]
> <span data-ttu-id="0b1bf-110">ListView と GridView はどちらも [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) クラスから派生しているため、同じ機能を持ちますが、データの表示方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-110">ListView and GridView both derive from the [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) class, so they have the same functionality, but display data differently.</span></span> <span data-ttu-id="0b1bf-111">この記事では、特に指定がない限り、リスト ビューについての説明は ListView コントロールにも GridView コントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-111">In this article, when we talk about list view, the info applies to both the ListView and GridView controls unless otherwise specified.</span></span> <span data-ttu-id="0b1bf-112">ListView や ListViewItem などのクラスの説明については、プレフィックスの *"List"* を *"Grid"* に置き換えることで、対応するグリッド クラス (GridView または GridViewItem) に適用できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-112">We may refer to classes like ListView or ListViewItem, but the *List* prefix can be replaced with *Grid* for the corresponding grid equivalent (GridView or GridViewItem).</span></span> 

<span data-ttu-id="0b1bf-113">これらのコンテナー コントロールは、"データ テンプレート" *と* "コントロール テンプレート" *という* 2 つの重要な部分から構成されており、これらを組み合わせることによって 1 つの項目で表示する最終的な外観が形成されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-113">These container controls consist of two important parts that combine to create the final visuals shown for an item: the *data template* and the *control template*.</span></span>

- <span data-ttu-id="0b1bf-114">**データ テンプレート** - [DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) をリスト ビューの [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てて、個別のデータ項目の表示方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-114">**Data template** - You assign a [DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) to the [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the list view to specify how individual data items are shown.</span></span>
- <span data-ttu-id="0b1bf-115">**コントロール テンプレート** - コントロール テンプレートは、表示状態など、フレームワークが担当する項目の視覚エフェクトの一部を提供します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-115">**Control template** - The control template provides the part of the item visualization that the framework is responsible for, like visual states.</span></span> <span data-ttu-id="0b1bf-116">[ItemContainerStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) プロパティを使って、コントロール テンプレートを変更できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-116">You can use the [ItemContainerStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) property to modify the control template.</span></span> <span data-ttu-id="0b1bf-117">通常では、ブランドに合うようにリスト ビューの色を変更したり、選択した項目の表示方法を変更する目的で、コントロール テンプレートを変更します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-117">Typically, you do this to modify the list view colors to match your branding, or change how selected items are shown.</span></span>

<span data-ttu-id="0b1bf-118">次の画像は、コントロール テンプレートとデータ テンプレートを合わせて 1 つの項目で表示する最終的な外観を形成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-118">This image shows how the control template and the data template combine to create the final visual for an item.</span></span>

![リスト ビュー コントロールやデータ テンプレート](images/listview-visual-parts.png)

<span data-ttu-id="0b1bf-120">この項目を作成する XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-120">Here's the XAML that creates this item.</span></span> <span data-ttu-id="0b1bf-121">テンプレートについては、後で説明します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-121">We explain the templates later.</span></span>

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
                <TextBlock Text="{x:Bind}" Foreground="Black"
                           FontSize="14" Grid.Column="1"
                           VerticalAlignment="Center"
                           Padding="0,0,54,0"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="Background" Value="LightGreen"/>
        </Style>
    </ListView.ItemContainerStyle>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```
 
## <a name="prerequisites"></a><span data-ttu-id="0b1bf-122">前提条件</span><span class="sxs-lookup"><span data-stu-id="0b1bf-122">Prerequisites</span></span>

- <span data-ttu-id="0b1bf-123">リスト ビュー コントロールを使用できることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-123">We assume that you know how to use a list view control.</span></span> <span data-ttu-id="0b1bf-124">詳しくは、「[ListView と GridView](listview-and-gridview.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-124">For more info, see the [ListView and GridView](listview-and-gridview.md) article.</span></span>
- <span data-ttu-id="0b1bf-125">また、スタイルをインラインで使用する方法や、リソースとして使用する方法を含む、コントロールのスタイルやテンプレートについて理解していることも前提としています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-125">We also assume that you understand control styles and templates, including how to use a style inline or as a resource.</span></span> <span data-ttu-id="0b1bf-126">詳しくは、「[コントロールのスタイル](xaml-styles.md)」と「[コントロールのテンプレート](control-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-126">For more info, see [Styling controls](xaml-styles.md) and [Control templates](control-templates.md).</span></span>

## <a name="the-data"></a><span data-ttu-id="0b1bf-127">データ</span><span class="sxs-lookup"><span data-stu-id="0b1bf-127">The data</span></span>

<span data-ttu-id="0b1bf-128">リスト ビューでデータ項目を表示する方法について詳しく説明する前に、表示するデータについて理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-128">Before we look deeper into how to show data items in a list view, we need to understand the data to be shown.</span></span> <span data-ttu-id="0b1bf-129">この例では、`NamedColor` と呼ばれるデータ型を作成します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-129">In this example, we create a data type called `NamedColor`.</span></span> <span data-ttu-id="0b1bf-130">`NamedColor` では、`Name`、`Color`、`Brush` という 3 つのプロパティとして公開されている、色の名前、色の値、色の **SolidColorBrush** を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-130">It combines a color name, color value, and a **SolidColorBrush** for the color, which are exposed as 3 properties: `Name`, `Color`, and `Brush`.</span></span>
 
<span data-ttu-id="0b1bf-131">次に、[Colors](https://msdn.microsoft.com/library/windows/apps/windows.ui.colors.aspx) クラスの各名前付きの色の `NamedColor` オブジェクトを使って、**List** を設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-131">We then populate a **List** with a `NamedColor` object for each named color in the [Colors](https://msdn.microsoft.com/library/windows/apps/windows.ui.colors.aspx) class.</span></span> <span data-ttu-id="0b1bf-132">このリストは、リスト ビューの [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) として設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-132">The list is set as the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) for the list view.</span></span>

<span data-ttu-id="0b1bf-133">クラスを定義したり、`NamedColors` リストを設定するためのコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-133">Here’s the code to define the class and populate the `NamedColors` list.</span></span>

**<span data-ttu-id="0b1bf-134">C#</span><span class="sxs-lookup"><span data-stu-id="0b1bf-134">C#</span></span>**
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

## <a name="data-template"></a><span data-ttu-id="0b1bf-135">データ テンプレート</span><span class="sxs-lookup"><span data-stu-id="0b1bf-135">Data template</span></span>

<span data-ttu-id="0b1bf-136">データ テンプレートを指定して、リスト ビューにデータ項目の表示方法を伝えます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-136">You specify a data template to tell the list view how your data item should be shown.</span></span> 

<span data-ttu-id="0b1bf-137">既定では、データ項目は、バインドされているデータ オブジェクトの文字列表現としてリスト ビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-137">By default, a data item is displayed in the list view as the string representation of the data object it's bound to.</span></span> <span data-ttu-id="0b1bf-138">リスト ビューに 'NamedColors' データの表示方法を伝えることなく、リスト ビューでこのデータを表示する場合、次のように、単に **ToString** メソッドが返すものを表示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-138">If you show the 'NamedColors' data in a list view without telling the list view how it should look, it just shows whatever the **ToString** method returns, like this.</span></span>

**<span data-ttu-id="0b1bf-139">XAML</span><span class="sxs-lookup"><span data-stu-id="0b1bf-139">XAML</span></span>**
```xaml
<ListView x:Name="colorsListView"/>
```

![項目の文字列表現を示すリスト ビュー](images/listview-no-template.png)

<span data-ttu-id="0b1bf-141">データ項目の特定のプロパティに [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) を設定すると、そのプロパティの文字列表現を表示できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-141">You can show the string representation of a particular property of the data item by setting the [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) to that property.</span></span> <span data-ttu-id="0b1bf-142">ここでは、`NamedColor` 項目の `Name` プロパティに DisplayMemberPath を設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-142">Here, you set DisplayMemberPath to the `Name` property of the `NamedColor` item.</span></span>

**<span data-ttu-id="0b1bf-143">XAML</span><span class="sxs-lookup"><span data-stu-id="0b1bf-143">XAML</span></span>**
```xaml
<ListView x:Name="colorsListView" DisplayMemberPath="Name" />
```

<span data-ttu-id="0b1bf-144">リスト ビューで、次のように名前で項目が表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-144">The list view now displays items by name, as shown here.</span></span> <span data-ttu-id="0b1bf-145">より便利になりましたが、あまり興味を引くものではなく、多くの情報が隠されたままです。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-145">It’s more useful, but it’s not very interesting and leaves a lot of information hidden.</span></span>

![項目プロパティの文字列表現を示すリスト ビュー](images/listview-display-member-path.png)

<span data-ttu-id="0b1bf-147">通常は、リッチな表現でデータを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-147">You typically want to show a more rich presentation of your data.</span></span> <span data-ttu-id="0b1bf-148">リスト ビューでの項目の表示方法を正確に指定するには、[DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-148">To specify exactly how items in the list view are displayed, you create a [DataTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx).</span></span> <span data-ttu-id="0b1bf-149">DataTemplate の XAML では、個々の項目を表示するために使うコントロールのレイアウトと外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-149">The XAML in the DataTemplate defines the layout and appearance of controls used to display an individual item.</span></span> <span data-ttu-id="0b1bf-150">レイアウト内のコントロールでは、データ オブジェクトのプロパティにバインドすることも、静的コンテンツをインラインで定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-150">The controls in the layout can be bound to properties of a data object, or have static content defined inline.</span></span> <span data-ttu-id="0b1bf-151">DataTemplate は、リスト コントロールの [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-151">You assign the DataTemplate to the [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) property of the list control.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0b1bf-152">**ItemTemplate** と **DisplayMemberPath** を同時に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-152">You can’t use a **ItemTemplate** and **DisplayMemberPath** at the same time.</span></span> <span data-ttu-id="0b1bf-153">両方のプロパティが設定されていると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-153">If both properties are set, an exception occurs.</span></span>

<span data-ttu-id="0b1bf-154">ここでは、色の名前や RGB 値が設定された項目の色で[四角形](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.aspx)を表示する DataTemplate を定義します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-154">Here, you define a DataTemplate that shows a [Rectangle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.shapes.rectangle.aspx) in the color of the item, along with the color name and RGB values.</span></span> 

> [!NOTE]
> <span data-ttu-id="0b1bf-155">DataTemplate で [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を使う場合、DataTemplate に DataType (`x:DataType`) を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-155">When you use the [x:Bind markup extension](https://msdn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) in a DataTemplate, you have to specify the DataType (`x:DataType`) on the DataTemplate.</span></span>

**<span data-ttu-id="0b1bf-156">XAML</span><span class="sxs-lookup"><span data-stu-id="0b1bf-156">XAML</span></span>**
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

<span data-ttu-id="0b1bf-157">このデータ テンプレートを使ってデータ項目を表示すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-157">Here's what the data items look like when they're displayed with this data template.</span></span>

![データ テンプレートを使ったリスト ビュー項目](images/listview-data-template-0.png)

<span data-ttu-id="0b1bf-159">GridView でデータを表示することが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-159">You might want to show the data in a GridView.</span></span> <span data-ttu-id="0b1bf-160">グリッド レイアウトにより適した方法でデータを表示する、その他のデータ テンプレートを次に示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-160">Here's another data template that displays the data in a way that's more appropriate for a grid layout.</span></span> <span data-ttu-id="0b1bf-161">今回は、GridView 用に XAML 内ではなく、リソースとしてデータ テンプレートを定義します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-161">This time, the data template is defined as a resource rather than inline with the XAML for the GridView.</span></span>


**<span data-ttu-id="0b1bf-162">XAML</span><span class="sxs-lookup"><span data-stu-id="0b1bf-162">XAML</span></span>**
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

<span data-ttu-id="0b1bf-163">このデータ テンプレートを使ってグリッドにデータを表示すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-163">When the data is shown in a grid using this data template, it looks like this.</span></span>

![データ テンプレートを使ったグリッド ビュー項目](images/gridview-data-template.png)

### <a name="performance-considerations"></a><span data-ttu-id="0b1bf-165">パフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="0b1bf-165">Performance considerations</span></span>

<span data-ttu-id="0b1bf-166">データ テンプレートは、リスト ビューの外観を定義する主要な方法です。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-166">Data templates are the primary way you define the look of your list view.</span></span> <span data-ttu-id="0b1bf-167">リストに多数の項目を表示した場合、パフォーマンスが大幅に低下することもあります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-167">They can also have a significant impact on performance if your list displays a large number of items.</span></span> 

<span data-ttu-id="0b1bf-168">データ テンプレートのすべての XAML 要素のインスタンスが、リスト ビューの各項目用に作成されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-168">An instance of every XAML element in a data template is created for each item in the list view.</span></span> <span data-ttu-id="0b1bf-169">たとえば、前の例のグリッド テンプレートには、10 個の XAML 要素 (1 つの Grid、1 つの Rectangle、3 つの Border、5 つの Textblock) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-169">For example, the grid template in the previous example has 10 XAML elements (1 Grid, 1 Rectangle, 3 Borders, 5 TextBlocks).</span></span> <span data-ttu-id="0b1bf-170">このデータ テンプレートを使って 20 個の項目を表示する GridView は、少なくとも 200 個 (20\*10=200) の要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-170">A GridView that shows 20 items on screen using this data template creates at least 200 elements (20\*10=200).</span></span> <span data-ttu-id="0b1bf-171">データ テンプレートの要素数を減らすと、リスト ビューで作成する要素の総数が大幅に減少します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-171">Reducing the number of elements in a data template can greatly reduce the total number of elements created for your list view.</span></span> <span data-ttu-id="0b1bf-172">詳細については、次を参照してください。 [ListView および GridView の UI の最適化。項目ごとの要素数の削減](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview#element-reduction-per-item)します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-172">For more info, see [ListView and GridView UI optimization: Element count reduction per item](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview#element-reduction-per-item).</span></span>

 <span data-ttu-id="0b1bf-173">このセクションのグリッド データ テンプレートについて考えてみます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-173">Consider this section  of the grid data template.</span></span> <span data-ttu-id="0b1bf-174">要素数を減らすための手法を確認しましょう。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-174">Let's look at a few things that reduce the element count.</span></span>

**<span data-ttu-id="0b1bf-175">XAML</span><span class="sxs-lookup"><span data-stu-id="0b1bf-175">XAML</span></span>**
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

 - <span data-ttu-id="0b1bf-176">まず、このレイアウトは 1 つのグリッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-176">First, the layout uses a single Grid.</span></span> <span data-ttu-id="0b1bf-177">1 列の Grid を用意して、StackPanel にこれら 3 つの TextBlock を配置できますが、何度も作成するデータ テンプレートでは、レイアウト パネルを他のレイアウト パネル内に埋め込まないようにする方法を探す必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-177">You could have a single-column Grid and place these 3 TextBlocks in a StackPanel, but in a data template that gets created many times, you should look for ways to avoid embedding layout panels within other layout panels.</span></span>
 - <span data-ttu-id="0b1bf-178">次に、Border コントロールを使って、Border 要素内に実際に項目を配置することなく背景をレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-178">Second, you can use a Border control to render a background without actually placing items within the Border element.</span></span> <span data-ttu-id="0b1bf-179">Border 要素には子要素を 1 つしか配置できないため、他のレイアウト パネルを追加して、XAML の Border 要素内で 3 つの TextBlock 要素をホストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-179">A Border element can have only one child element, so you would need to add an additional layout panel to host the 3 TextBlock elements within the Border element in XAML.</span></span> <span data-ttu-id="0b1bf-180">TextBlock を Border 要素の子要素にしないようにすれば、パネルで TextBlock を保持する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-180">By not making the TextBlocks children of the Border, you eliminate the need for a panel to hold the TextBlocks.</span></span>
 - <span data-ttu-id="0b1bf-181">最後に、StackPanel 内に TextBlock を配置して、明示的な Border 要素を使用する代わりに、StackPanel で border プロパティを設定できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-181">Finally, you could place the TextBlocks inside a StackPanel, and set the border properties on the StackPanel rather than using an explicit Border element.</span></span> <span data-ttu-id="0b1bf-182">ただし、Border 要素は StackPanel よりも軽量なコントロールであるため、何度もレンダリングするときのパフォーマンスの影響は少なくなります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-182">However, the Border element is a more lightweight control than a StackPanel, so it has less of an impact on performance when rendered many times over.</span></span>

## <a name="control-template"></a><span data-ttu-id="0b1bf-183">コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="0b1bf-183">Control template</span></span>
<span data-ttu-id="0b1bf-184">項目のコントロール テンプレートには、選択、ホバー、フォーカスなどの状態を表示する視覚効果が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-184">An item’s control template contains the visuals that display state, like selection, pointer over, and focus.</span></span> <span data-ttu-id="0b1bf-185">これらの視覚効果は、データ テンプレートの上または下にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-185">These visuals are rendered either on top of or below the data template.</span></span> <span data-ttu-id="0b1bf-186">ListView コントロール テンプレートによって描画される一般的な既定の視覚効果を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-186">Some of the common default visuals drawn by the ListView control template are shown here.</span></span>

- <span data-ttu-id="0b1bf-187">ホバー – 薄い灰色の四角形がデータ テンプレートの下に描画されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-187">Hover – A light gray rectangle drawn below the data template.</span></span>  
- <span data-ttu-id="0b1bf-188">選択 – 薄い青色の四角形がデータ テンプレートの下に描画されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-188">Selection – A light blue rectangle drawn below the data template.</span></span> 
- <span data-ttu-id="0b1bf-189">キーボード フォーカス – 黒色と白色の点線で表された境界線が項目テンプレートの上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-189">Keyboard focus– A black and white dotted border drown on top of the item template.</span></span> 

![リスト ビューの状態の視覚効果](images/listview-state-visuals.png)

<span data-ttu-id="0b1bf-191">リスト ビューでは、データ テンプレートの要素とコントロール テンプレートの要素を組み合わせて、画面にレンダリングする最終的な視覚効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-191">The list view combines the elements from the data template and control template to create the final visuals rendered on the screen.</span></span> <span data-ttu-id="0b1bf-192">以下では、状態の視覚効果がリスト ビューのコンテキスト内で表示されています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-192">Here, the state visuals are shown in the context of a list view.</span></span>

![異なる状態の項目を示すリスト ビュー](images/listview-states.png)

### <a name="listviewitempresenter"></a><span data-ttu-id="0b1bf-194">ListViewItemPresenter</span><span class="sxs-lookup"><span data-stu-id="0b1bf-194">ListViewItemPresenter</span></span>

<span data-ttu-id="0b1bf-195">データ テンプレートについて上で説明したとおり、各項目で作成する XAML 要素の数は、リスト ビューのパフォーマンスに大きな影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-195">As we noted previously about data templates, the number of XAML elements created for each item can have a significant impact on the performance of a list view.</span></span> <span data-ttu-id="0b1bf-196">データ テンプレートとコントロール テンプレートを組み合わせて各項目を表示するため、項目を表示するために必要な実際の要素数には、両方のテンプレートの要素数が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-196">Because the data template and control template are combined to display each item, the actual number of elements needed to display an item includes the elements in both templates.</span></span>

<span data-ttu-id="0b1bf-197">ListView コントロールと GridView コントロールを最適化して、項目ごとに作成する XAML 要素の数を減らします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-197">The ListView and GridView controls are optimized to reduce the number of XAML elements created per item.</span></span> <span data-ttu-id="0b1bf-198">**ListViewItem** の視覚効果は [ListViewItemPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.aspx) によって作成されます。ListViewItemPresenter は、多数の UIElement によるオーバーヘッドなしで、フォーカス、選択などの表示状態で複雑な視覚効果を表示する特別な XAML 要素です。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-198">The **ListViewItem** visuals are created by the [ListViewItemPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.aspx), which is a special XAML element that displays complex visuals for focus, selection, and other visual states, without the overhead of numerous UIElements.</span></span>
 
> [!NOTE]
> <span data-ttu-id="0b1bf-199">Windows 10 の UWP アプリでは、**ListViewItem** と **GridViewItem** の両方で **ListViewItemPresenter** を使います。GridViewItemPresenter は非推奨であるため、使わないでください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-199">In UWP apps for Windows 10, both **ListViewItem** and **GridViewItem** use **ListViewItemPresenter**; the GridViewItemPresenter is deprecated and you should not use it.</span></span> <span data-ttu-id="0b1bf-200">ListViewItem と GridViewItem は、ListViewItemPresenter に異なるプロパティ値を設定して、異なる既定の外観を作成します)。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-200">ListViewItem and GridViewItem set different property values on ListViewItemPresenter to achieve different default looks.)</span></span>

<span data-ttu-id="0b1bf-201">項目コンテナーの外観を変更するには、[ItemContainerStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) プロパティを使い、[TargetType](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.targettype.aspx) に **ListViewItem** または **GridViewItem** を設定した [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) を提供します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-201">To modify the look of the item container, use the [ItemContainerStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) property and provide a [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) with its [TargetType](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.targettype.aspx) set to **ListViewItem** or **GridViewItem**.</span></span>

<span data-ttu-id="0b1bf-202">この例では、ListViewItem にパディングを追加して、リストの項目の間に余白を入れます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-202">In this example, you add padding to the ListViewItem to create some space between the items in the list.</span></span>

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

<span data-ttu-id="0b1bf-203">これで、項目の間に余白が入ったリスト ビューが次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-203">Now the list view looks like this with space between the items.</span></span>

![パディングを適用したリスト ビューの項目](images/listview-data-template-1.png)

<span data-ttu-id="0b1bf-205">ListViewItem の既定のスタイルの場合、ListViewItemPresenter の **ContentMargin** プロパティには、ListViewItem の **Padding** プロパティにバインドする[TemplateBinding](https://msdn.microsoft.com/windows/uwp/xaml-platform/templatebinding-markup-extension) があります (`<ListViewItemPresenter ContentMargin="{TemplateBinding Padding}"/>`)。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-205">In the ListViewItem default style, the ListViewItemPresenter **ContentMargin** property has a [TemplateBinding](https://msdn.microsoft.com/windows/uwp/xaml-platform/templatebinding-markup-extension) to the ListViewItem **Padding** property (`<ListViewItemPresenter ContentMargin="{TemplateBinding Padding}"/>`).</span></span> <span data-ttu-id="0b1bf-206">Padding プロパティを設定すると、この値は実際に ListViewItemPresenter の ContentMargin プロパティに渡されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-206">When we set the Padding property, that value is really being passed to the ListViewItemPresenter ContentMargin property.</span></span>

<span data-ttu-id="0b1bf-207">ListViewItems プロパティにテンプレート バインドされていないその他の ListViewItemPresenter プロパティを変更するには、プロパティを変更できる新しい ListViewItemPresenter を使って ListViewItem を再テンプレート化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-207">To modify other ListViewItemPresenter properties that aren't template bound to ListViewItems properties, you need to retemplate the ListViewItem with a new ListViewItemPresenter that you can modify properties on.</span></span> 

> [!NOTE]
> <span data-ttu-id="0b1bf-208">ListViewItem と GridViewItem の既定のスタイルには、ListViewItemPresenter の多くのプロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-208">ListViewItem and GridViewItem default styles set a lot of properties on ListViewItemPresenter.</span></span> <span data-ttu-id="0b1bf-209">常に既定のスタイルのコピーを作成し、必要なプロパティのみ変更することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-209">You should always start with a copy of the default style and modify only the properties you need too.</span></span> <span data-ttu-id="0b1bf-210">そうしなければ、一部のプロパティを正しく設定していないことが原因で、視覚効果が期待どおりに表示されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-210">Otherwise, the visuals will probably not show up the way you expect because some properties won't be set correctly.</span></span>

**<span data-ttu-id="0b1bf-211">Visual Studio で既定のテンプレートのコピーを作成するには</span><span class="sxs-lookup"><span data-stu-id="0b1bf-211">To make a copy of the default template in Visual Studio</span></span>**
 
1. <span data-ttu-id="0b1bf-212">[ドキュメント アウトライン] ウィンドウを開きます (**[表示] > [その他のウィンドウ] > [ドキュメント アウトライン]**)。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-212">Open the Document Outline pane (**View > Other Windows > Document Outline**).</span></span>
2. <span data-ttu-id="0b1bf-213">変更するリストまたはグリッドの要素を選びます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-213">Select the list or grid element to modify.</span></span> <span data-ttu-id="0b1bf-214">この例では、`colorsGridView` 要素を変更します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-214">In this example, you modify the `colorsGridView` element.</span></span>
3. <span data-ttu-id="0b1bf-215">`colorsGridView` を右クリックし、**[追加テンプレートの編集]、[生成されたアイテム コンテナーの編集 (ItemContainerStyle)]、[コピーして編集]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-215">Right-click and select **Edit Additional Templates > Edit Generated Item Container (ItemContainerStyle) > Edit a Copy**.</span></span>
    ![Visual Studio のエディター](images/listview-itemcontainerstyle-vs.png)
4. <span data-ttu-id="0b1bf-217">Style リソースの作成 ダイアログ ボックスで、スタイルの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-217">In the Create Style Resource dialog, enter a name for the style.</span></span> <span data-ttu-id="0b1bf-218">この例では、`colorsGridViewItemStyle` を使います。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-218">In this example, you use `colorsGridViewItemStyle`.</span></span>
    <span data-ttu-id="0b1bf-219">![Visual Studio Create Style Resource dialog(images/listview-style-resource-vs.png)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-219">![Visual Studio Create Style Resource dialog(images/listview-style-resource-vs.png)</span></span>

<span data-ttu-id="0b1bf-220">次の XAML で示すように、既定のスタイルのコピーをリソースとしてアプリに追加し、**GridView.ItemContainerStyle** プロパティをそのリソースに設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-220">A copy of the default style is added to your app as a resource, and the **GridView.ItemContainerStyle** property is set to that resource, as shown in this XAML.</span></span> 

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

<span data-ttu-id="0b1bf-221">これで、ListViewItemPresenter のプロパティを変更して、選択チェック ボックス、項目の配置、ブラシの色の表示状態を制御できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-221">You can now modify properties on the ListViewItemPresenter to control the selection check box, item positioning, and brush colors for visual states.</span></span> 

#### <a name="inline-and-overlay-selection-visuals"></a><span data-ttu-id="0b1bf-222">インラインとオーバーレイの選択ビジュアル</span><span class="sxs-lookup"><span data-stu-id="0b1bf-222">Inline and Overlay selection visuals</span></span>

<span data-ttu-id="0b1bf-223">ListView と GridView では、コントロールや [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) に応じて、選択されている項目をさまざまな方法で示します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-223">ListView and GridView indicate selected items in different ways depending on the control and the [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx).</span></span> <span data-ttu-id="0b1bf-224">リスト ビューについて詳しくは、「[ListView と GridView](listview-and-gridview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-224">For more info about list view selection, see [ListView and GridView](listview-and-gridview.md).</span></span> 

<span data-ttu-id="0b1bf-225">**SelectionMode** を **Multiple** に設定すると、選択チェック ボックスは項目のコントロール テンプレートの一部として表示されます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-225">When **SelectionMode** is set to **Multiple**, a selection check box is shown as part of the item's control template.</span></span> <span data-ttu-id="0b1bf-226">[SelectionCheckMarkVisualEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectioncheckmarkvisualenabled.aspx) プロパティを使って、Multiple 選択モードの選択チェック ボックスをオフにできます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-226">You can use the [SelectionCheckMarkVisualEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.selectioncheckmarkvisualenabled.aspx) property to turn off the selection check box in Multiple selection mode.</span></span> <span data-ttu-id="0b1bf-227">ただし、このプロパティは他の選択モードでは無視されるため、Extended または Single 選択モードのチェック ボックスをオンにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-227">However, this property is ignored in other selection modes, so you can't turn on the check box in Extended or Single selection mode.</span></span>

<span data-ttu-id="0b1bf-228">[CheckMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.checkmode.aspx) プロパティを設定して、インライン スタイルまたはオーバーレイ スタイルのどちらを使ってチェック ボックスを表示するかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-228">You can set the [CheckMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.checkmode.aspx) property to specify whether the check box is shown using the inline style or overlay style.</span></span>

- <span data-ttu-id="0b1bf-229">**インライン**:このスタイルは、コンテンツの左側にチェック ボックスを表示し、選択を示すため、項目コンテナーの背景の色します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-229">**Inline**: This style shows the check box to the left of the content, and colors the background of the item container to indicate selection.</span></span> <span data-ttu-id="0b1bf-230">これは、ListView の既定のスタイルです。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-230">This is the default style for ListView.</span></span>
- <span data-ttu-id="0b1bf-231">**オーバーレイ**:このスタイルを使用して、コンテンツ上に、チェック ボックスを示しています、のみを選択範囲を示すために、項目コンテナーの境界線の色します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-231">**Overlay**: This style shows the check box on top of the content, and colors only the border of the item container to indicate selection.</span></span> <span data-ttu-id="0b1bf-232">これは、GridView の既定のスタイルです。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-232">This is the default style for GridView.</span></span>

<span data-ttu-id="0b1bf-233">次の表は、選択された状態を示すために使用する既定の視覚効果を示しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-233">This table shows the default visuals used to indicate selection.</span></span>

<span data-ttu-id="0b1bf-234">SelectionMode: &nbsp;&nbsp;</span><span class="sxs-lookup"><span data-stu-id="0b1bf-234">SelectionMode:&nbsp;&nbsp;</span></span> | <span data-ttu-id="0b1bf-235">Single/Extended</span><span class="sxs-lookup"><span data-stu-id="0b1bf-235">Single/Extended</span></span> | <span data-ttu-id="0b1bf-236">Multiple</span><span class="sxs-lookup"><span data-stu-id="0b1bf-236">Multiple</span></span>
---------------|-----------------|---------
<span data-ttu-id="0b1bf-237">インライン</span><span class="sxs-lookup"><span data-stu-id="0b1bf-237">Inline</span></span> | ![Inline かつ Single/Extended の選択](images/listview-single-selection.png) | ![Inline かつ Multiple の選択](images/listview-multi-selection.png)
<span data-ttu-id="0b1bf-240">オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="0b1bf-240">Overlay</span></span> | ![Overlay かつ Single/Extended の選択](images/gridview-single-selection.png) | ![Overlay かつ Multiple の選択](images/gridview-multi-selection.png)

> [!NOTE]
> <span data-ttu-id="0b1bf-243">この例と次の例では、コントロール テンプレートによって提供されている視覚効果に焦点を当てるために、データ テンプレートなしでシンプルな文字列データ項目を表示しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-243">In this and the following examples, simple string data items are shown without data templates to emphasize the visuals provided by the control template.</span></span>

<span data-ttu-id="0b1bf-244">また、チェック ボックスの色を変更するためのブラシ プロパティも複数用意されています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-244">There are also several brush properties to change the colors of the check box.</span></span> <span data-ttu-id="0b1bf-245">詳しくは、以下で他のブラシ プロパティと共に説明します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-245">We'll look at these next along with other brush properties.</span></span>

#### <a name="brushes"></a><span data-ttu-id="0b1bf-246">ブラシ</span><span class="sxs-lookup"><span data-stu-id="0b1bf-246">Brushes</span></span> 

<span data-ttu-id="0b1bf-247">多くのプロパティでは、異なる表示状態で使用するブラシを指定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-247">Many of the properties specify the brushes used for different visual states.</span></span> <span data-ttu-id="0b1bf-248">ブランドに合わせてブラシを変更することが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-248">You might want to modify these to match the color of your brand.</span></span> 

<span data-ttu-id="0b1bf-249">次の表は、ListViewItem の一般的な表示状態と選択された表示状態、および各状態のレンダリングで使用するブラシを示しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-249">This table shows the Common and Selection visual states for ListViewItem, and the brushes used to render the visuals for each state.</span></span> <span data-ttu-id="0b1bf-250">画像は、インラインとオーバーレイの両方の選択視覚スタイルにおける、ブラシの効果を示しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-250">The images show the effects of the brushes on both the inline and overlay selection visual styles.</span></span>

> [!NOTE]
> <span data-ttu-id="0b1bf-251">この表の場合、ブラシで変更する色値はハードコードされた名前付きの色です。テンプレートのどこに適用されるかをはっきりと理解できるように、名前付きの色を選択しています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-251">In this table, the modified color values for the brushes are hardcoded named colors and the colors are selected to make it more apparent where they are applied in the template.</span></span> <span data-ttu-id="0b1bf-252">これらは、表示状態の既定の色ではありません。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-252">These are not the default colors for the visual states.</span></span> <span data-ttu-id="0b1bf-253">アプリの既定の色を変更する場合は、既定のテンプレートで設定されているように、ブラシのリソースを使って色値を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-253">If you modify the default colors in your app, you should use brush resources to modify the color values as done in the default template.</span></span>

<span data-ttu-id="0b1bf-254">状態/ブラシの名前</span><span class="sxs-lookup"><span data-stu-id="0b1bf-254">State/Brush name</span></span> | <span data-ttu-id="0b1bf-255">インライン スタイル</span><span class="sxs-lookup"><span data-stu-id="0b1bf-255">Inline style</span></span> | <span data-ttu-id="0b1bf-256">オーバーレイ スタイル</span><span class="sxs-lookup"><span data-stu-id="0b1bf-256">Overlay style</span></span>
------------|--------------|--------------
<b><span data-ttu-id="0b1bf-257">標準</span><span class="sxs-lookup"><span data-stu-id="0b1bf-257">Normal</span></span></b><ul><li><b><span data-ttu-id="0b1bf-258">CheckBoxBrush="Red"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-258">CheckBoxBrush="Red"</span></span></b></li></ul> | ![インラインの項目の選択 (通常)](images/listview-item-normal.png) | ![オーバーレイの項目の選択 (通常)](images/gridview-item-normal.png)
<b><span data-ttu-id="0b1bf-261">PointerOver</span><span class="sxs-lookup"><span data-stu-id="0b1bf-261">PointerOver</span></span></b><ul><li><b><span data-ttu-id="0b1bf-262">PointerOverForeground="DarkOrange"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-262">PointerOverForeground="DarkOrange"</span></span></b></li><li><b><span data-ttu-id="0b1bf-263">PointerOverBackground="MistyRose"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-263">PointerOverBackground="MistyRose"</span></span></b></li><li><span data-ttu-id="0b1bf-264">CheckBoxBrush="Red"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-264">CheckBoxBrush="Red"</span></span></li></ul> | ![インラインの項目の選択 (ホバー)](images/listview-item-pointerover.png) | ![オーバーレイの項目の選択 (ホバー)](images/gridview-item-pointerover.png)
<b><span data-ttu-id="0b1bf-267">Pressed</span><span class="sxs-lookup"><span data-stu-id="0b1bf-267">Pressed</span></span></b><ul><li><b><span data-ttu-id="0b1bf-268">PressedBackground="LightCyan"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-268">PressedBackground="LightCyan"</span></span></b></li><li><span data-ttu-id="0b1bf-269">PointerOverForeground="DarkOrange"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-269">PointerOverForeground="DarkOrange"</span></span></li><li><span data-ttu-id="0b1bf-270">CheckBoxBrush="Red"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-270">CheckBoxBrush="Red"</span></span></li></ul> | ![インラインの項目の選択 (押す)](images/listview-item-pressed.png) | ![オーバーレイの項目の選択 (押す)](images/gridview-item-pressed.png)
<b><span data-ttu-id="0b1bf-273">Selected</span><span class="sxs-lookup"><span data-stu-id="0b1bf-273">Selected</span></span></b><ul><li><b><span data-ttu-id="0b1bf-274">SelectedForeground="Navy"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-274">SelectedForeground="Navy"</span></span></b></li><li><b><span data-ttu-id="0b1bf-275">SelectedBackground="Khaki"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-275">SelectedBackground="Khaki"</span></span></b></li><li><b><span data-ttu-id="0b1bf-276">CheckBrush="Green"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-276">CheckBrush="Green"</span></span></b></li><li><span data-ttu-id="0b1bf-277">CheckBoxBrush="Red" (インラインのみ)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-277">CheckBoxBrush="Red" (inline only)</span></span></li></ul> | ![インラインの項目の選択 (選択)](images/listview-item-selected.png) | ![オーバーレイの項目の選択 (選択)](images/gridview-item-selected.png)
<b><span data-ttu-id="0b1bf-280">PointerOverSelected</span><span class="sxs-lookup"><span data-stu-id="0b1bf-280">PointerOverSelected</span></span></b><ul><li><b><span data-ttu-id="0b1bf-281">SelectedPointerOverBackground="Lavender"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-281">SelectedPointerOverBackground="Lavender"</span></span></b></li><li><span data-ttu-id="0b1bf-282">SelectedForeground="Navy"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-282">SelectedForeground="Navy"</span></span></li><li><span data-ttu-id="0b1bf-283">SelectedBackground="Khaki" (オーバーレイのみ)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-283">SelectedBackground="Khaki" (overlay only)</span></span></li><li><span data-ttu-id="0b1bf-284">CheckBrush="Green"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-284">CheckBrush="Green"</span></span></li><li><span data-ttu-id="0b1bf-285">CheckBoxBrush="Red" (インラインのみ)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-285">CheckBoxBrush="Red" (inline only)</span></span></li></ul> | ![インラインの項目の選択 (ホバー、選択)](images/listview-item-pointeroverselected.png) | ![オーバーレイの項目の選択 (ホバー、選択)](images/gridview-item-pointeroverselected.png)
<b><span data-ttu-id="0b1bf-288">PressedSelected</span><span class="sxs-lookup"><span data-stu-id="0b1bf-288">PressedSelected</span></span></b><ul><li><b><span data-ttu-id="0b1bf-289">SelectedPressedBackground="MediumTurquoise"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-289">SelectedPressedBackground="MediumTurquoise"</span></span></b></li></li><li><span data-ttu-id="0b1bf-290">SelectedForeground="Navy"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-290">SelectedForeground="Navy"</span></span></li><li><span data-ttu-id="0b1bf-291">SelectedBackground="Khaki" (オーバーレイのみ)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-291">SelectedBackground="Khaki" (overlay only)</span></span></li><li><span data-ttu-id="0b1bf-292">CheckBrush="Green"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-292">CheckBrush="Green"</span></span></li><li><span data-ttu-id="0b1bf-293">CheckBoxBrush="Red" (インラインのみ)</span><span class="sxs-lookup"><span data-stu-id="0b1bf-293">CheckBoxBrush="Red" (inline only)</span></span></li></ul> | ![インラインの項目の選択 (押す、選択)](images/listview-item-pressedselected.png) | ![オーバーレイの項目の選択 (押す、選択)](images/gridview-item-pressedselected.png)
<b><span data-ttu-id="0b1bf-296">Focused</span><span class="sxs-lookup"><span data-stu-id="0b1bf-296">Focused</span></span></b><ul><li><b><span data-ttu-id="0b1bf-297">FocusBorderBrush="Crimson"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-297">FocusBorderBrush="Crimson"</span></span></b></li><li><b><span data-ttu-id="0b1bf-298">FocusSecondaryBorderBrush="Gold"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-298">FocusSecondaryBorderBrush="Gold"</span></span></b></li><li><span data-ttu-id="0b1bf-299">CheckBoxBrush="Red"</span><span class="sxs-lookup"><span data-stu-id="0b1bf-299">CheckBoxBrush="Red"</span></span></li></ul> | ![インラインの項目の選択 (フォーカス)](images/listview-item-focused.png) | ![オーバーレイの項目の選択 (フォーカス)](images/gridview-item-focused.png)

<span data-ttu-id="0b1bf-302">ListViewItemPresenter には、データのプレース ホルダーやドラッグ状態用のブラシ プロパティが他にもあります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-302">ListViewItemPresenter has other brush properties for data placeholders and drag states.</span></span> <span data-ttu-id="0b1bf-303">リスト ビューで段階的読み込みやドラッグ アンド ドロップを使用する場合は、このような追加のブラシ プロパティを変更する必要があるかについても検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-303">If you use incremental loading or drag and drop in your list view, you should consider whether you need to also modify these additional brush properties.</span></span> <span data-ttu-id="0b1bf-304">変更できるプロパティの完全な一覧については、ListViewItemPresenter クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-304">See the ListViewItemPresenter class for the complete list of properties you can modify.</span></span> 

### <a name="expanded-xaml-item-templates"></a><span data-ttu-id="0b1bf-305">展開時の XAML 項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="0b1bf-305">Expanded XAML item templates</span></span>

<span data-ttu-id="0b1bf-306">たとえば、**ListViewItemPresenter** プロパティで許可されていない変更を行う必要がある場合や、チェック ボックスの位置を変更する必要がある場合は、*ListViewItemExpanded* テンプレートまたは *GridViewItemExpanded* テンプレートを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-306">If you need to make more modifications than what is allowed by the **ListViewItemPresenter** properties - if you need to change the position of the check box, for example - you can use the *ListViewItemExpanded* or *GridViewItemExpanded* templates.</span></span> <span data-ttu-id="0b1bf-307">これらのテンプレートは、generic.xaml の既定のスタイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-307">These templates are included with the default styles in generic.xaml.</span></span> <span data-ttu-id="0b1bf-308">これらは、個別の UIElement からすべての視覚効果をビルドする標準の XAML パターンに従います。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-308">They follow the standard XAML pattern of building all the visuals from individual UIElements.</span></span>

<span data-ttu-id="0b1bf-309">既に説明したように、項目テンプレート内の UIElement の数は、リスト ビューのパフォーマンスに大きな影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-309">As mentioned previously, the number of UIElements in an item template has a significant impact on the performance of your list view.</span></span> <span data-ttu-id="0b1bf-310">ListViewItemPresenter を展開時の XAML テンプレートに置き換えると、要素の数が大幅に増大するため、リスト ビューで多数の項目を表示する場合や、パフォーマンスを懸念する場合は推奨しません。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-310">Replacing ListViewItemPresenter with the expanded XAML templates greatly increases the element count, and is not recommended when your list view will show a large number of items or when performance is a concern.</span></span>

> [!NOTE]
> <span data-ttu-id="0b1bf-311">**ListViewItemPresenter** は、リスト ビューの [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) が [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) または [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) である場合にのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-311">**ListViewItemPresenter** is supported only when the list view’s [ItemsPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx) is an [ItemsWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemswrapgrid.aspx) or [ItemsStackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx).</span></span> <span data-ttu-id="0b1bf-312">[VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)、[WrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.wrapgrid.aspx)、または [StackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.aspx) を使うように ItemsPanel を変更すると、項目テンプレートは展開時の XAML テンプレートに自動的に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-312">If you change the ItemsPanel to use [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.variablesizedwrapgrid.aspx), [WrapGrid](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.wrapgrid.aspx), or [StackPanel](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.aspx), then the item template is automatically switched to the expanded XAML template.</span></span> <span data-ttu-id="0b1bf-313">詳しくは、「[ListView と GridView の UI の最適化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-313">For more info, see [ListView and GridView UI optimization](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview).</span></span>

<span data-ttu-id="0b1bf-314">展開時の XAML テンプレートをカスタマイズするには、アプリでコピーを作成し、コピーに **ItemContainerStyle** プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-314">To customize an expanded XAML template, you need to make a copy of it in your app, and set the **ItemContainerStyle** property to your copy.</span></span>

**<span data-ttu-id="0b1bf-315">展開時のテンプレートをコピーするには</span><span class="sxs-lookup"><span data-stu-id="0b1bf-315">To copy the expanded template</span></span>**
1. <span data-ttu-id="0b1bf-316">次に示すように、ListView または GridView に ItemContainerStyle プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-316">Set the ItemContainerStyle property as shown here for your ListView or GridView.</span></span>
    ```xaml
    <ListView ItemContainerStyle="{StaticResource ListViewItemExpanded}"/>
    <GridView ItemContainerStyle="{StaticResource GridViewItemExpanded}"/>
    ```
2. <span data-ttu-id="0b1bf-317">Visual Studio の [プロパティ] ウィンドウで、[その他] セクションを展開し、ItemContainerStyle プロパティを探します。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-317">In the Visual Studio Properties pane, expand the Miscellaneous section and find the ItemContainerStyle property.</span></span> <span data-ttu-id="0b1bf-318">(ListView または GridView が選択されていることを確認します)。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-318">(Make sure the ListView or GridView is selected.)</span></span>
3. <span data-ttu-id="0b1bf-319">ItemContainerStyle プロパティのプロパティ マーカーをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-319">Click the property marker for the ItemContainerStyle property.</span></span> <span data-ttu-id="0b1bf-320">(TextBox の横にある小さなボックスです。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-320">(It’s the small box next to the TextBox.</span></span> <span data-ttu-id="0b1bf-321">Coloreed 緑、StaticResource に設定されていることを説明します。)プロパティ メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-321">It’s coloreed green to show that it’s set to a StaticResource.) The property menu opens.</span></span>
4. <span data-ttu-id="0b1bf-322">プロパティ メニューで、**[新しいリソースに変換]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-322">In the property menu, click **Convert to New Resource**.</span></span> 
    
    ![Visual Studio のプロパティ メニュー](images/listview-convert-resource-vs.png)
5. <span data-ttu-id="0b1bf-324">[Style リソースの作成] ダイアログ ボックスで、リソースの名前を入力し、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-324">In the Create Style Resource dialog, enter a name for the resource and click OK.</span></span>

<span data-ttu-id="0b1bf-325">generic.xaml の展開時のテンプレートのコピーがアプリで作成され、必要に応じて変更できるようになります。</span><span class="sxs-lookup"><span data-stu-id="0b1bf-325">A copy of the expanded template from generic.xaml is created in your app, which you can modify as needed.</span></span>


## <a name="related-articles"></a><span data-ttu-id="0b1bf-326">関連記事</span><span class="sxs-lookup"><span data-stu-id="0b1bf-326">Related articles</span></span>

- [<span data-ttu-id="0b1bf-327">リスト</span><span class="sxs-lookup"><span data-stu-id="0b1bf-327">Lists</span></span>](lists.md)
- [<span data-ttu-id="0b1bf-328">ListViewと GridView</span><span class="sxs-lookup"><span data-stu-id="0b1bf-328">ListView and GridView</span></span>](listview-and-gridview.md)

