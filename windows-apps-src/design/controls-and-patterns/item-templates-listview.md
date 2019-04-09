---
Description: リスト ビューの項目テンプレート
title: リスト ビューの項目テンプレート
template: detail.hbs
ms.date: 11/03/2017
ms.topic: article
keywords: Windows 10, UWP, Fluent
ms.openlocfilehash: 0a772c0ec6aad2c0d6a099b54eb4c6faa413cc7b
ms.sourcegitcommit: c10d7843ccacb8529cb1f53948ee0077298a886d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58913942"
---
# <a name="item-templates-for-list-view"></a>リスト ビューの項目テンプレート

このセクションでは、[**ListView**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView) コントロールで使用できる項目テンプレートについて説明します。 これらのテンプレートを使って、一般的な種類のアプリの外観を設定できます。 

データ バインディングを示すためには、これらのテンプレートがバインド**Listviewitem**から記録クラスの例に、[データ バインディングの概要](../../data-binding/data-binding-quickstart.md)します。

> [!NOTE] 
> 現在、**DataTemplate** に複数のコントロール (例: 複数の **TextBlock**) が含まれている場合、スクリーン リーダー用のアクセシビリティに対応する既定の名前は、項目の .ToString() から取得されます。 また利便性を考慮し、**DataTemplate** のルート要素に [**AutomationProperties.Name**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.automationproperties) を設定することもできます。 アクセシビリティについて詳しくは、[「アクセシビリティの概要」](../accessibility/accessibility-overview.md)をご覧ください。

## <a name="single-line-list-item"></a>1 行のリスト項目
このテンプレートを使用して、画像と 1 行のテキストから成る項目のリストを表示します。

![1 行のリスト項目の行](images/listitems/singlelineexample.png)
![1 行のリスト項目](images/listitems/singlelineicon.png)
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

## <a name="double-line-list-item"></a>2 行のリスト項目 
このテンプレートを使用して、画像と 2 行のテキストから成る項目のリストを表示します。

![アイコンが付いた 2 行のリスト項目の例](images/listitems/doublelineexample.png) 
![アイコンが付いた 2 行のリスト項目](images/listitems/doublelineicon.png)

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

## <a name="triple-line-list-item"></a>3 行のリスト項目
このテンプレートを使用して、3 行のテキストから成る項目のリストを表示します。

![3 行のリスト項目の行](images/listitems/triplelineexample.png)
![3 行のリスト項目](images/listitems/tripleline.png)

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

## <a name="table-list-item"></a>表型リスト項目
このテンプレートを使用して、定義された列にテキストを含んでいる項目のリストを表示します。

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

## <a name="related-articles"></a>関連記事
- [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.listview)
- [データ バインディングの概要](../../data-binding/data-binding-quickstart.md)
- [アクセシビリティの概要](../accessibility/accessibility-overview.md)
- [ListView と GridView のサンプル (Windows 10)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [サムネイル画像](../../files/thumbnails.md)
