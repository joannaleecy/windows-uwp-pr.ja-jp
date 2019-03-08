---
Description: リスト ビューの項目テンプレート
title: リスト ビューの項目テンプレート
template: detail.hbs
ms.date: 11/03/2017
ms.topic: article
keywords: Windows 10, UWP, Fluent
ms.openlocfilehash: 397c1d3a1502eaa352bf66b1bbf24e3fa39beff2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593057"
---
# <a name="item-templates-for-list-view"></a><span data-ttu-id="34749-104">リスト ビューの項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="34749-104">Item templates for list view</span></span>

<span data-ttu-id="34749-105">このセクションでは、[**ListView**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView) コントロールで使用できる項目テンプレートについて説明します。</span><span class="sxs-lookup"><span data-stu-id="34749-105">This section contains item templates that you can use with a [**ListView**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView) control.</span></span> <span data-ttu-id="34749-106">これらのテンプレートを使って、一般的な種類のアプリの外観を設定できます。</span><span class="sxs-lookup"><span data-stu-id="34749-106">Use these templates to get the look of common app types.</span></span> 

<span data-ttu-id="34749-107">データ バインディングを示すためには、これらのテンプレートがバインド**Listviewitem**から記録クラスの例に、[データ バインディングの概要](../../data-binding/data-binding-quickstart.md)します。</span><span class="sxs-lookup"><span data-stu-id="34749-107">To demonstrate data binding, these templates bind **ListViewItems** to the example Recording class from the [data binding overview](../../data-binding/data-binding-quickstart.md).</span></span>

> [!NOTE] 
<span data-ttu-id="34749-108">現在、**DataTemplate** に複数のコントロール (例: 複数の **TextBlock**) が含まれている場合、スクリーン リーダー用のアクセシビリティに対応する既定の名前は、項目の .ToString() から取得されます。</span><span class="sxs-lookup"><span data-stu-id="34749-108">Currently, when a **DataTemplate** contains multiple controls (e.g. more than a single **TextBlock**), the default accessible name for screenreaders comes from .ToString() on the item.</span></span> <span data-ttu-id="34749-109">また利便性を考慮し、**DataTemplate** のルート要素に [**AutomationProperties.Name**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.automationproperties) を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="34749-109">As a convenience you can instead set the [**AutomationProperties.Name**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.automationproperties) on the root element of the **DataTemplate**.</span></span> <span data-ttu-id="34749-110">アクセシビリティについて詳しくは、[「アクセシビリティの概要」](../accessibility/accessibility-overview.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34749-110">For more on accessibility, see [Accessibililty overview](../accessibility/accessibility-overview.md).</span></span>

## <a name="single-line-list-item"></a><span data-ttu-id="34749-111">1 行のリスト項目</span><span class="sxs-lookup"><span data-stu-id="34749-111">Single line list item</span></span>
<span data-ttu-id="34749-112">このテンプレートを使用して、画像と 1 行のテキストから成る項目のリストを表示します。</span><span class="sxs-lookup"><span data-stu-id="34749-112">Use this template to display a list of items with an image and a single line of text.</span></span>

<span data-ttu-id="34749-113">![1 行のリスト項目の例](images/listitems/singlelineexample.png)
![1 行のリスト項目](images/listitems/singlelineicon.png)</span><span class="sxs-lookup"><span data-stu-id="34749-113">![single line list item example](images/listitems/singlelineexample.png)
![single line list item](images/listitems/singlelineicon.png)</span></span>
```xaml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}">
    <ListView.ItemTemplate>
        <DataTemplate x:Name="SingleLineDataTemplate" x:DataType="local:Recording">
            <StackPanel Orientation="Horizontal" Height="44" Padding="12" AutomationProperties.Name="{x:Bind CompositionName}">
                <Image Source="Placeholder.png" Height="16" Width="16" VerticalAlignment="Center"/>
                <TextBlock Text="{x:Bind CompositionName}" VerticalAlignment="Center" Style="{ThemeResource BaseTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseHighBrush}" Margin="12,0,0,0"/>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

## <a name="double-line-list-item"></a><span data-ttu-id="34749-114">2 行のリスト項目</span><span class="sxs-lookup"><span data-stu-id="34749-114">Double line list item</span></span> 
<span data-ttu-id="34749-115">このテンプレートを使用して、画像と 2 行のテキストから成る項目のリストを表示します。</span><span class="sxs-lookup"><span data-stu-id="34749-115">Use this template to display a list of items with an image and two lines of text.</span></span>

<span data-ttu-id="34749-116">![二重線のリスト項目のアイコンの例と](images/listitems/doublelineexample.png) 
![二重線のリスト項目のアイコン](images/listitems/doublelineicon.png)</span><span class="sxs-lookup"><span data-stu-id="34749-116">![double line list item with icon example](images/listitems/doublelineexample.png) 
![double line list item with icon](images/listitems/doublelineicon.png)</span></span>

```xaml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}">
    <ListView.ItemTemplate>
        <DataTemplate x:Name="DoubleLineDataTemplate" x:DataType="local:Recording">
            <StackPanel Orientation="Horizontal" Height="64" AutomationProperties.Name="{x:Bind CompositionName}">
                <Ellipse Height="48" Width="48" VerticalAlignment="Center">
                    <Ellipse.Fill>
                        <ImageBrush ImageSource="Placeholder.png"/>
                    </Ellipse.Fill>
                </Ellipse>
                <StackPanel Orientation="Vertical" VerticalAlignment="Center" Margin="12,0,0,0">
                    <TextBlock Text="{x:Bind CompositionName}"  Style="{ThemeResource BaseTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseHighBrush}" />
                    <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource BodyTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}"/>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

## <a name="triple-line-list-item"></a><span data-ttu-id="34749-117">3 行のリスト項目</span><span class="sxs-lookup"><span data-stu-id="34749-117">Triple line list item</span></span>
<span data-ttu-id="34749-118">このテンプレートを使用して、3 行のテキストから成る項目のリストを表示します。</span><span class="sxs-lookup"><span data-stu-id="34749-118">Use this template to display a list of items with three lines of text.</span></span>

<span data-ttu-id="34749-119">![リスト項目の例の 3 倍になる行](images/listitems/triplelineexample.png)
![3 倍になる行のリスト項目](images/listitems/tripleline.png)</span><span class="sxs-lookup"><span data-stu-id="34749-119">![triple line list item example](images/listitems/triplelineexample.png)
![triple line list item](images/listitems/tripleline.png)</span></span>

```xaml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}">
    <ListView.ItemTemplate>
        <DataTemplate x:Name="TripleLineDataTemplate" x:DataType="local:Recording">
            <StackPanel Height="84" Padding="20" AutomationProperties.Name="{x:Bind CompositionName}">
                <TextBlock Text="{x:Bind CompositionName}"  Style="{ThemeResource BaseTextBlockStyle}" Margin="0,4,0,0"/>
                <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource CaptionTextBlockStyle}" Opacity=".8" Margin="0,4,0,0"/>
                <TextBlock Text="{x:Bind ReleaseDateTime}" Style="{ThemeResource CaptionTextBlockStyle}" Opacity=".6" Margin="0,4,0,0"/>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

## <a name="table-list-item"></a><span data-ttu-id="34749-120">表型リスト項目</span><span class="sxs-lookup"><span data-stu-id="34749-120">Table list item</span></span>
<span data-ttu-id="34749-121">このテンプレートを使用して、定義された列にテキストを含んでいる項目のリストを表示します。</span><span class="sxs-lookup"><span data-stu-id="34749-121">Use this template to display a list of items with text in defined columns.</span></span>

![表型リスト項目の例](images/listitems/tablelist.png)
```xaml
<ListView  ItemsSource="{x:Bind ViewModel.Recordings}">
    <ListView.HeaderTemplate>
        <DataTemplate>
            <Grid Padding="12" Background="{ThemeResource SystemBaseLowColor}">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="408"/>
                    <ColumnDefinition Width="360"/>
                    <ColumnDefinition Width="360"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="Composition" Style="{ThemeResource CaptionTextBlockStyle}"/>
                <TextBlock Grid.Column="1" Text="Artist" Style="{ThemeResource CaptionTextBlockStyle}"/>
                <TextBlock Grid.Column="2" Text="Release Date" Style="{ThemeResource CaptionTextBlockStyle}"/>
            </Grid>
        </DataTemplate>
    </ListView.HeaderTemplate>
    <ListView.ItemTemplate>
        <DataTemplate x:Name="TableDataTemplate" x:DataType="local:Recording">
            <Grid Height="48" AutomationProperties.Name="{x:Bind CompositionName}">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="48"/>
                    <ColumnDefinition Width="360"/>
                    <ColumnDefinition Width="360"/>
                    <ColumnDefinition Width="360"/>
                </Grid.ColumnDefinitions>
                <Ellipse Height="32" Width="32" VerticalAlignment="Center">
                    <Ellipse.Fill>
                        <ImageBrush ImageSource="Placeholder.png"/>
                    </Ellipse.Fill>
                </Ellipse>
                <TextBlock Grid.Column="1" VerticalAlignment="Center" Style="{ThemeResource BaseTextBlockStyle}" Text="{x:Bind CompositionName}" />
                <TextBlock Grid.Column="2" VerticalAlignment="Center" Text="{x:Bind ArtistName}"/>
                <TextBlock Grid.Column="3" VerticalAlignment="Center" Text="{x:Bind ReleaseDateTime}"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

## <a name="related-articles"></a><span data-ttu-id="34749-123">関連記事</span><span class="sxs-lookup"><span data-stu-id="34749-123">Related articles</span></span>
- [<span data-ttu-id="34749-124">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="34749-124">ListView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.listview)
- [<span data-ttu-id="34749-125">データ バインディングの概要</span><span class="sxs-lookup"><span data-stu-id="34749-125">Data binding overview</span></span>](../../data-binding/data-binding-quickstart.md)
- [<span data-ttu-id="34749-126">Accessibililty の概要</span><span class="sxs-lookup"><span data-stu-id="34749-126">Accessibililty overview</span></span>](../accessibility/accessibility-overview.md)
- [<span data-ttu-id="34749-127">ListView と GridView サンプル (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="34749-127">ListView and GridView sample (Windows 10)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [<span data-ttu-id="34749-128">縮小表示イメージ</span><span class="sxs-lookup"><span data-stu-id="34749-128">Thumbnail images</span></span>](../../files/thumbnails.md)