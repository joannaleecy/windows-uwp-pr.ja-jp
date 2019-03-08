---
Description: グリッド ビューの項目テンプレート
title: グリッド ビューの項目テンプレート
template: detail.hbs
ms.date: 11/03/2017
ms.topic: article
keywords: Windows 10, UWP, Fluent
ms.openlocfilehash: 1e2c8b7d9fb7bdc61595296a137c4448cadf52d3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629267"
---
# <a name="item-templates-for-grid-view"></a><span data-ttu-id="d37af-104">グリッド ビューの項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="d37af-104">Item templates for grid view</span></span>

<span data-ttu-id="d37af-105">このセクションでは、[**GridView**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.GridView) コントロールで使用できる項目テンプレートについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d37af-105">This section contains item templates that you can use with a [**GridView**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.GridView) control.</span></span> <span data-ttu-id="d37af-106">これらのテンプレートを使って、一般的な種類のアプリの外観を設定できます。</span><span class="sxs-lookup"><span data-stu-id="d37af-106">Use these templates to get the look of common app types.</span></span>

<span data-ttu-id="d37af-107">データ バインディングを示すためには、これらのテンプレートがバインド**GridViewItems**から記録クラスの例に、[データ バインディングの概要](../../data-binding/data-binding-quickstart.md)します。</span><span class="sxs-lookup"><span data-stu-id="d37af-107">To demonstrate data binding, these templates bind **GridViewItems** to the example Recording class from the [data binding overview](../../data-binding/data-binding-quickstart.md).</span></span>

> [!NOTE] 
<span data-ttu-id="d37af-108">現在、**DataTemplate** に複数のコントロール (例: 複数の **TextBlock**) が含まれている場合、スクリーン リーダー用のアクセシビリティに対応する既定の名前は、項目の .ToString() から取得されます。</span><span class="sxs-lookup"><span data-stu-id="d37af-108">Currently, when a **DataTemplate** contains multiple controls (e.g. more than a single **TextBlock**), the default accessible name for screenreaders comes from .ToString() on the item.</span></span> <span data-ttu-id="d37af-109">また利便性を考慮し、**DataTemplate** のルート要素に [**AutomationProperties.Name**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.automationproperties) を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="d37af-109">As a convenience you can instead set the [**AutomationProperties.Name**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.automationproperties) on the root element of the **DataTemplate**.</span></span> <span data-ttu-id="d37af-110">アクセシビリティについて詳しくは、[「アクセシビリティの概要」](../accessibility/accessibility-overview.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d37af-110">For more on accessibility, see [Accessibililty overview](../accessibility/accessibility-overview.md).</span></span>

## <a name="icon-and-text"></a><span data-ttu-id="d37af-111">アイコンとテキスト</span><span class="sxs-lookup"><span data-stu-id="d37af-111">Icon and text</span></span>
<span data-ttu-id="d37af-112">これらのテンプレートを使用して、アプリのコレクションをアイコンとテキストから成るグリッドに表示します。</span><span class="sxs-lookup"><span data-stu-id="d37af-112">Use these templates to display a collection of apps in a grid with an icon and text.</span></span>

![小さいアイコンとテキストを使用した GridView の例](images/listitems/icontext.png)
```xaml
<GridView ItemsSource="{x:Bind ViewModel.Recordings}">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="IconTextTemplate" x:DataType="local:Recording">
            <StackPanel Width="264" Height="48" Padding="12" Orientation="Horizontal" AutomationProperties.Name="{x:Bind CompositionName}">
                <SymbolIcon Symbol="Audio" VerticalAlignment="Top"/>
                <TextBlock Margin="12,0,0,0" Width="204" Text="{x:Bind CompositionName}"/>
            </StackPanel>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="4" Orientation="Horizontal" HorizontalAlignment="Center"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

![アイコンと 2 行のテキストを使用した GridView の例](images/listitems/icontext2.png)
```xaml
<GridView ItemsSource="{x:Bind ViewModel.Recordings}">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="IconTextTemplate2" x:DataType="local:Recording">
            <StackPanel Width="264" Height="120" Padding="12" Orientation="Horizontal" AutomationProperties.Name="{x:Bind CompositionName}">
                <FontIcon Margin="0,6,0,0" FontSize="48" FontFamily="Segoe MDL2 Assets" FontWeight="Bold" Glyph="&#xE8D6;" VerticalAlignment="Top"/>
                <StackPanel Margin="16,1,0,0">
                    <TextBlock Width="176" Margin="0,0,0,2" TextWrapping="WrapWholeWords" TextTrimming="Clip" Text="{x:Bind CompositionName}"/>
                    <TextBlock Width="176" Height="48" Style="{ThemeResource CaptionTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}" TextWrapping="WrapWholeWords" TextTrimming="Clip" Text="{x:Bind ArtistName}" />
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="4" Orientation="Horizontal" HorizontalAlignment="Center" Margin="40,0"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

## <a name="image-gallery"></a><span data-ttu-id="d37af-115">イメージ ギャラリー</span><span class="sxs-lookup"><span data-stu-id="d37af-115">Image gallery</span></span>
<span data-ttu-id="d37af-116">このテンプレートを使用して、画像のコレクションを複数選択モードのグリッドに表示します。</span><span class="sxs-lookup"><span data-stu-id="d37af-116">Use this template to display a collection of images in a grid with multi-select mode.</span></span>

![Gridview の項目レイアウト](images/listitems/gridviewitems.png)
```xaml
<GridView SelectionMode="Multiple">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="ImageGalleryDataTemplate">
            <Image Source="Placeholder.png" Height="180" Width="180" Stretch="UniformToFill"/>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="3" Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```
## <a name="image-and-text"></a><span data-ttu-id="d37af-118">画像とテキスト</span><span class="sxs-lookup"><span data-stu-id="d37af-118">Image and text</span></span>
<span data-ttu-id="d37af-119">これらのテンプレートを使用して、下にテキストが示されるメディア コレクションを表示します。</span><span class="sxs-lookup"><span data-stu-id="d37af-119">Use these templates to display a media collection with text underneath.</span></span>

![正方形の画像とテキストを使用した GridView の例](images/listitems/imageandtext.png)
```xaml
<GridView ItemsSource="{x:Bind ViewModel.Recordings}">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="ImageTextDataTemplate" x:DataType="local:Recording">
            <StackPanel Height="280" Width="180" Margin="12" AutomationProperties.Name="{x:Bind CompositionName}">
                <Image Source="Placeholder.png" Height="180" Width="180" Stretch="UniformToFill"/>
                <StackPanel Margin="0,12">
                    <TextBlock Text="{x:Bind CompositionName}"/>
                    <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource CaptionTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}"/>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="10" Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

![長方形の画像とテキストを使用した GridView の例](images/listitems/imageandtext2.png)
```xaml
<GridView ItemsSource="{x:Bind ViewModel.Recordings}">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="ImageTextDataTemplate2" x:DataType="local:Recording">
            <StackPanel Height="280" Width="320" Margin="12" AutomationProperties.Name="{x:Bind CompositionName}">
                <Image Source="Placeholder.png" Height="180" Width="320" Stretch="UniformToFill"/>
                <StackPanel Margin="0,12">
                    <TextBlock Text="{x:Bind CompositionName}"/>
                    <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource CaptionTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}"/>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="4" Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

## <a name="image-with-text-overlay"></a><span data-ttu-id="d37af-122">テキスト オーバーレイを使用した画像</span><span class="sxs-lookup"><span data-stu-id="d37af-122">Image with text overlay</span></span>
<span data-ttu-id="d37af-123">このテンプレートを使用して、テキスト オーバーレイを利用したメディア コレクションを表示します。</span><span class="sxs-lookup"><span data-stu-id="d37af-123">Use this template to display a media collection with text overlay.</span></span>

![画像とテキスト オーバーレイを使用した GridView の例](images/listitems/imageoverlay.png)
```xaml
<GridView ItemsSource="{x:Bind ViewModel.Recordings}">
    <GridView.ItemTemplate>
        <DataTemplate x:Name="ImageOverlayDataTemplate" x:DataType="local:Recording">
            <Grid Height="180" Width="320" AutomationProperties.Name="{x:Bind CompositionName}">
                <Image Source="Placeholder.png" Stretch="UniformToFill"/>
                <StackPanel Orientation="Vertical" Height="60" VerticalAlignment="Bottom" Background="{ThemeResource SystemBaseLowColor}" Padding="12">
                    <TextBlock Text="{x:Bind CompositionName}"/>
                    <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource CaptionTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}"/>
                </StackPanel>
            </Grid>
        </DataTemplate>
    </GridView.ItemTemplate>
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid MaximumRowsOrColumns="4" Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

## <a name="related-articles"></a><span data-ttu-id="d37af-125">関連記事</span><span class="sxs-lookup"><span data-stu-id="d37af-125">Related articles</span></span>
- [<span data-ttu-id="d37af-126">GridView クラス</span><span class="sxs-lookup"><span data-stu-id="d37af-126">GridView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.GridView)
- [<span data-ttu-id="d37af-127">データ バインディングの概要</span><span class="sxs-lookup"><span data-stu-id="d37af-127">Data binding overview</span></span>](../../data-binding/data-binding-quickstart.md)
- [<span data-ttu-id="d37af-128">Accessibililty の概要</span><span class="sxs-lookup"><span data-stu-id="d37af-128">Accessibililty overview</span></span>](../accessibility/accessibility-overview.md)
- [<span data-ttu-id="d37af-129">ListView と GridView サンプル (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="d37af-129">ListView and GridView sample (Windows 10)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [<span data-ttu-id="d37af-130">縮小表示イメージ</span><span class="sxs-lookup"><span data-stu-id="d37af-130">Thumbnail images</span></span>](../../files/thumbnails.md)