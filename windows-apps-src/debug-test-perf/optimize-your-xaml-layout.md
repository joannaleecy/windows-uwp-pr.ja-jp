---
ms.assetid: 79CF3927-25DE-43DD-B41A-87E6768D5C35
title: XAML レイアウトの最適化
description: レイアウトは、CPU 使用率とメモリ オーバーヘッドの両方で、XAML アプリの負荷の高い部分です。 ここでは、XAML アプリのレイアウトのパフォーマンスを向上させるための簡単な手順を示します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ab894a9ba9c51b091e593503be2db57ba3b1a913
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7973777"
---
# <a name="optimize-your-xaml-layout"></a>XAML レイアウトの最適化


**重要な API**

-   [**Panel**](https://msdn.microsoft.com/library/windows/apps/BR227511)

レイアウトは、UI の視覚的な構造を定義するプロセスです。 XAML でレイアウトを記述するための主要なメカニズムはパネルです。パネルは、UI 要素を内部に配置して整列できるコンテナー オブジェクトです。 レイアウトは、CPU 使用率とメモリ オーバーヘッドの両方で、XAML アプリの負荷の高い部分です。 ここでは、XAML アプリのレイアウトのパフォーマンスを向上させるための簡単な手順を示します。

## <a name="reduce-layout-structure"></a>レイアウトの構造を減らす

レイアウトのパフォーマンス向上の効果が最も大きいのは、UI 要素のツリーの階層構造を簡略化することです。 パネルはビジュアル ツリーに存在しますが、これらは構造型の要素であり、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) や [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) などの*ピクセル生成要素*ではありません。 通常、非ピクセル生成要素の数を減らすことによりツリーを簡略化すると、パフォーマンスの大幅な向上につながります。

多くの UI は、パネルを入れ子にすることによって実装されており、結果として、パネルと要素のツリーが深くて複雑な構造になっています。 パネルを入れ子にすると便利ですが、多くの場合は、同じ UI をより複雑な 1 つのパネルを使って実現することができます。 1 つのパネルを使用すると、パフォーマンスが向上します。

### <a name="when-to-reduce-layout-structure"></a>レイアウトの構造を減らす場合

単純な方法でレイアウトの構造を減らす (たとえば、トップレベルのページから、入れ子になったパネルを 1 つ減らす) だけでは、大きな効果は得られません。

パフォーマンスの向上が最も大きいのは、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) などの UI 内で繰り返されるレイアウト構造を減らすことです。 これらの [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) 要素は [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) を使用します。これは、何度もをインスタンス化される UI 要素のサブツリーを定義します。 同じサブツリーがアプリ内で何度も複製されている場合、そのサブツリーのパフォーマンスが少しでも向上すれば、アプリの全体的なパフォーマンスへの効果は何倍にもなります。

### <a name="examples"></a>例

次のような UI を考えてみます。

![フォーム レイアウトの例](images/layout-perf-ex1.png)

これらの例では、同じ UI を実装するための 3 つの方法を示しています。 どの実装を選択した場合も画面上のピクセル数をほぼ同じ結果になりますが、実装の詳細は大きく異なります。

オプション 1: 入れ子になった [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) 要素

これは最も簡単なモデルですが、5 つのパネル要素を使用し、大きなオーバーヘッドが生じます。

```xml
  <StackPanel>
  <TextBlock Text="Options:" />
  <StackPanel Orientation="Horizontal">
      <CheckBox Content="Power User" />
      <CheckBox Content="Admin" Margin="20,0,0,0" />
  </StackPanel>
  <TextBlock Text="Basic information:" />
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Name:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Email:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Password:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <Button Content="Save" />
</StackPanel>
```

オプション 2: 1 つの [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)

[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) は多少複雑になりますが、1 つのパネル要素のみを使用します。

```xml
  <Grid>
  <Grid.RowDefinitions>
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
      <ColumnDefinition Width="Auto" />
      <ColumnDefinition Width="Auto" />
  </Grid.ColumnDefinitions>
  <TextBlock Text="Options:" Grid.ColumnSpan="2" />
  <CheckBox Content="Power User" Grid.Row="1" Grid.ColumnSpan="2" />
  <CheckBox Content="Admin" Margin="150,0,0,0" Grid.Row="1" Grid.ColumnSpan="2" />
  <TextBlock Text="Basic information:" Grid.Row="2" Grid.ColumnSpan="2" />
  <TextBlock Text="Name:" Width="75" Grid.Row="3" />
  <TextBox Width="200" Grid.Row="3" Grid.Column="1" />
  <TextBlock Text="Email:" Width="75" Grid.Row="4" />
  <TextBox Width="200" Grid.Row="4" Grid.Column="1" />
  <TextBlock Text="Password:" Width="75" Grid.Row="5" />
  <TextBox Width="200" Grid.Row="5" Grid.Column="1" />
  <Button Content="Save" Grid.Row="6" />
</Grid>
```

オプション 3: 1 つの [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546)

この 1 つのパネルも、入れ子になったパネルを使用する場合よりも少し複雑ですが、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) よりも理解しやすく、保守が容易になる可能性があります。

```xml
<RelativePanel>
  <TextBlock Text="Options:" x:Name="Options" />
  <CheckBox Content="Power User" x:Name="PowerUser" RelativePanel.Below="Options" />
  <CheckBox Content="Admin" Margin="20,0,0,0" 
            RelativePanel.RightOf="PowerUser" RelativePanel.Below="Options" />
  <TextBlock Text="Basic information:" x:Name="BasicInformation"
           RelativePanel.Below="PowerUser" />
  <TextBlock Text="Name:" RelativePanel.AlignVerticalCenterWith="NameBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="NameBox"               
           RelativePanel.Below="BasicInformation" />
  <TextBlock Text="Email:"  RelativePanel.AlignVerticalCenterWith="EmailBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="EmailBox"
           RelativePanel.Below="NameBox" />
  <TextBlock Text="Password:" RelativePanel.AlignVerticalCenterWith="PasswordBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="PasswordBox"
           RelativePanel.Below="EmailBox" />
  <Button Content="Save" RelativePanel.Below="PasswordBox" />
</RelativePanel>
```

これらの例が示すように、同じ UI を実現するにはさまざまな方法があります。 パフォーマンス、読みやすさ、保守容易性を含む、すべてのトレードオフを慎重に検討して選択する必要があります。

## <a name="use-single-cell-grids-for-overlapping-ui"></a>重なり合った UI としての単一セルのグリッドの使用

一般的な UI 要件として、要素が互いに重なり合ったレイアウトがあります。 通常、この方法で要素を配置するために、パディング、余白、整列、変換が使用されます。 XAML [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) コントロールは、重なり合った要素のレイアウトのパフォーマンスを向上させるために最適化されています。

**重要な**改善を参照するには、単一セルの[**グリッド**](https://msdn.microsoft.com/library/windows/apps/BR242704)を使用します。 [**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.rowdefinitions) や [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.columndefinitions) は定義しないでください。

### <a name="examples"></a>例

```xml
<Grid>
    <Ellipse Fill="Red" Width="200" Height="200" />
    <TextBlock Text="Test" 
               HorizontalAlignment="Center" 
               VerticalAlignment="Center" />
</Grid>
```

![円の上にオーバーレイされたテキスト](images/layout-perf-ex2.png)

```xml
<Grid Width="200" BorderBrush="Black" BorderThickness="1">
    <TextBlock Text="Test1" HorizontalAlignment="Left" />
    <TextBlock Text="Test2" HorizontalAlignment="Right" />
</Grid>
```

![グリッド内の 2 つのテキスト ブロック](images/layout-perf-ex3.png)

## <a name="use-a-panels-built-in-border-properties"></a>パネルの組み込みの境界線プロパティを使う

[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546)、[**ContentPresenter**](https://msdn.microsoft.com/library/windows/apps/BR209378) の各コントロールには組み込みの境界線プロパティがあり、XAML に [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) 要素を追加せずに周囲に境界線を描画できます。 組み込みの境界線をサポートする新しいプロパティは、**BorderBrush**、**BorderThickness**、**CornerRadius**、**Padding** です。 これらはそれぞれ [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) であり、バインディングやアニメーションで使用することができます。 これらは、個別の **Border** 要素を完全に置き換えるように設計されています。

UI でこれらのパネルの周囲に [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) 要素を使っている場合は、代わりに組み込みの境界線を使うことによって、アプリのレイアウト構造内で余分な要素を削減できます。 既に説明したように、特に繰り返される UI の場合は、大幅に要素を削減できます。

### <a name="examples"></a>例

```xml
<RelativePanel BorderBrush="Red" BorderThickness="2" CornerRadius="10" Padding="12">
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

## <a name="use-sizechanged-events-to-respond-to-layout-changes"></a>**SizeChanged** イベントを使ってレイアウトの変更に応答する

[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) クラスは、レイアウト変更に応答するための 2 つの類似したイベント [**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) と [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged) を公開します。 レイアウト時に、要素のサイズが変更された場合、これらのイベントのいずれかを使用して通知を受信していることがあります。 2 つのイベントのセマンティクスは異なり、どちらを選択するかは、パフォーマンスに関する重要な考慮事項です。

パフォーマンスを向上させるには、ほとんどの場合 [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged) が適切な選択肢です。 **SizeChanged** のセマンティクスは直感的です。 このイベントは、レイアウト中に [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) のサイズが更新されたときに発生します。

[**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) もレイアウト時に発生しますが、そのセマンティクスはグローバルです。任意の要素が更新されるたびにすべての要素について発生します。 イベント ハンドラーではローカルな処理のみを行うことが一般的であり、この場合、コードは必要以上に頻繁に実行されます。 **LayoutUpdated** は、サイズを変更せずに要素が再配置されたことを知る必要がある場合 (一般的ではありません) にのみ使用します。

## <a name="choosing-between-panels"></a>パネルの選択

通常、パフォーマンスは、個々のパネルを選択するときの検討事項ではありません。 パネルの選択は、実装しようとする UI に最も近いレイアウトの動作を実現するパネルを検討することによって行われます。 たとえば、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546) のいずれかを選択する場合、実装の概念的モデルに最も近いマッピングを提供するパネルを選択する必要があります。

どの XAML パネルもパフォーマンスが高くなるように最適化されており、同様の UI ではどのパネルのパフォーマンスも同様です。

