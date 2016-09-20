---
author: jwmsft
title: "xPhase 属性"
description: "ListView 項目と GridView 項目を段階的にレンダリングし、パン エクスペリエンスを向上させるには、xPhase を xBind マークアップ拡張と共に使います。"
ms.assetid: BD17780E-6A34-4A38-8D11-9703107E247E
ms.sourcegitcommit: 98b9bca2528c041d2fdfc6a0adead321737932b4
ms.openlocfilehash: dfa12909d19a44ed38939c612712c8fe90f3f584

---

# x:Phase 属性

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) 項目と [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) 項目を段階的にレンダリングし、パン エクスペリエンスを向上させるには、**x:Phase** を [{x:Bind} マークアップ拡張](x-bind-markup-extension.md)と共に使用します。 
            **x:Phase** では、宣言的な方法により、[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) イベントを使ってリスト項目のレンダリングを手動で制御するのと同じ結果を得ることができます。 「[GridView と ListView の項目を段階的に更新する](../debug-test-perf/optimize-gridview-and-listview.md#update-items-incrementally)」もご覧ください。

## XAML 属性の使用方法


``` syntax
<object x:Phase="PhaseValue".../>
```

## XAML 値


| 用語 | 説明 |
|------|-------------|
| PhaseValue | 要素が処理されるフェーズを示す数値。 既定値は 0 です。 | 

## 注釈

タッチ操作でリストをすばやくパンした場合やマウス ホイールを使用した場合、データ テンプレートの複雑さによっては、リスト項目をすばやくレンダリングできず、スクロール速度に追いつかないことがあります。 これは、電話やタブレットなど、電力効率に優れた CPU を搭載したポータブル デバイスに特に当てはまります。

フェージングにより、データ テンプレートを段階的にレンダリングできるので、コンテンツに優先順位を付け、最も重要な要素を最初にレンダリングできます。 これにより、すばやくパンした場合でも各項目のコンテンツの一部をリストに表示でき、時間が許す限り各テンプレートの要素がより多くレンダリングされます。

## 例

```xml
<DataTemplate x:Key="PhasedFileTemplate" x:DataType="model:FileItem">
    <Grid Width="200" Height="80">
        <Grid.ColumnDefinitions>
           <ColumnDefinition Width="75" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Image Grid.RowSpan="4" Source="{x:Bind ImageData}" MaxWidth="70" MaxHeight="70" x:Phase="3"/>
        <TextBlock Text="{x:Bind DisplayName}" Grid.Column="1" FontSize="12"/>
        <TextBlock Text="{x:Bind prettyDate}"  Grid.Column="1"  Grid.Row="1" FontSize="12" x:Phase="1"/>
        <TextBlock Text="{x:Bind prettyFileSize}"  Grid.Column="1"  Grid.Row="2" FontSize="12" x:Phase="2"/>
        <TextBlock Text="{x:Bind prettyImageSize}"  Grid.Column="1"  Grid.Row="3" FontSize="12" x:Phase="2"/>
    </Grid>
</DataTemplate>
```

データ テンプレートには、以下の 4 つのフェーズが記述されます。

1.  DisplayName テキスト ブロックを表示する。 フェーズが指定されていないコントロールはすべて、フェーズ 0 に含まれるものと暗黙的に見なされます。
2.  PrettyDate のテキスト ブロックを表示する。
3.  PrettyFileSize および prettyImageSize テキスト ブロックを表示する。
4.  画像を表示する。

フェージングは、[{x:Bind}](x-bind-markup-extension.md) の機能の 1 つであり、[**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879) から派生したコントロールを操作し、データ バインディングの項目テンプレートを段階的に処理します。 リスト項目をレンダリングする場合、**ListViewBase** は、ビューのすべての項目の 1 つのフェーズをレンダリングし、それから次のフェーズに進みます。 レンダリング処理は、リストのスクロール時、必要な処理を再割り当てできるようにタイム スライス バッチで実行されます。表示できなくなった項目に対しては、実行されません。

**x:Phase** 属性は、[{x:Bind}](x-bind-markup-extension.md) を使用するデータ テンプレートのどの要素に対しても指定できます。 要素のフェーズが 0 以外の場合、その要素は、フェーズが処理され、バインディングが更新されるまで、ビューから隠されます (**Visibility** ではなく、**Opacity** により)。 [**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879) 派生コントロールがスクロールされると、画面に表示されなくなった項目からの項目テンプレートがリサイクルされ、新しい表示可能な項目がレンダリングされます。 テンプレート内の UI 要素は、再びデータ バインドされるまで古い値を保持します。 フェージングにより、そのデータ バインディング ステップは遅延されます。したがって、フェージングでは、UI 要素が古くなった場合は、その UI 要素を隠す必要があります。

各 UI 要素に指定されているフェーズが 1 つだけの場合があります。 その場合、そのフェーズは要素のすべてのバインディングに適用されます。 フェーズが指定されていない場合は、フェーズ 0 と見なされます。

フェーズ番号は、連続している必要はなく、[**ContainerContentChangingEventArgs.Phase**](https://msdn.microsoft.com/library/windows/apps/dn298493) の値と同じです。 [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) イベントは、**x:Phase** バインディングが処理される前に各フェーズで生成されます。

フェージングは、 [{x:Bind}](x-bind-markup-extension.md) バインディングにのみ影響し、 [{Binding}](binding-markup-extension.md) バインディングには影響しません。

フェージングが適用されるのは、フェージングを認識するコントロールを使用して項目テンプレートがレンダリングされるときのみです。 Windows 10 の場合は、[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) です。 フェージングは、他の項目コントロールで使用されるデータ テンプレートには適用されません。また、[**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/br209369) または [**Hub**](https://msdn.microsoft.com/library/windows/apps/dn251843) セクション (この場合、すべての UI 要素が同時にデータ バインドされる) などの他のシナリオでも適用されません。




<!--HONumber=Jun16_HO4-->


