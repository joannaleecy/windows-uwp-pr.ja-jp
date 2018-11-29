---
ms.assetid: 569E8C27-FA01-41D8-80B9-1E3E637D5B99
title: XAML マークアップの最適化
description: UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、アプリでの XAML マークアップの解析および読み込み時間や、メモリ効率の向上に役立つヒントを紹介します。
ms.date: 08/10/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ec88af01e46788ea9f24760af7f9a3b81281ba8d
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8194972"
---
# <a name="optimize-your-xaml-markup"></a>XAML マークアップの最適化


UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、XAML マークアップの解析と読み込みにかかる時間を短縮し、アプリのメモリ効率を向上させるために役立つヒントを紹介します。

アプリの起動時に読み込まれる XAML マークアップを、最初の UI に必要な分だけに制限します。 最初のページ (ページ リソースを含む) のマークアップを調べて、すぐには必要とされない余分な要素を読み込んでいないことを確認します。 このような要素は、リソース ディクショナリ、初期状態で折りたたまれている要素、別の要素の上に描画される要素など、さまざまなソースに由来する可能性があります。

すべての状況に同じ方法で対応できるとは限りません。効率を求めて XAML を最適化するには、トレードオフも必要になります。 ここでは、いくつかの一般的な問題を取り上げながら、アプリに適したトレードオフを選ぶためのガイドラインを示します。

## <a name="minimize-element-count"></a>要素数の最小化

XAML プラットフォームでは大量の要素を表示できますが、目的のビジュアルを満たすためのページ上の要素の数を減らすと、アプリ レイアウトの作成とレンダリングをより速く行うことができます。

アプリの起動時に作成される UI 要素の数は、UI コントロールがどのように配置されているかによって左右されます。 レイアウトの最適化について詳しくは、「[XAML レイアウトの最適化](optimize-your-xaml-layout.md)」をご覧ください。

データ テンプレートでは、データ項目ごとに各要素が繰り返し作成されるため、要素数が非常に重要になります。 リストやグリッドで要素数を減らす方法については、「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」の「*項目ごとの要素の削減*」をご覧ください。

ここでは、アプリの起動時に読み込む必要のある要素数を減らすための方法をいくつか見ていきます。

### <a name="defer-item-creation"></a>項目の作成を延期する

すぐには表示されない要素が XAML マークアップに含まれている場合は、それらの要素が表示されるまで読み込みを延期することができます。 たとえば、タブのような UI では、セカンダリ タブなどの非表示のコンテンツの作成を遅らせることができます。 また、データを表示するときには、既定では項目をグリッド ビューで表示し、後からリスト表示に切り替えるオプションを用意する方法があります。 これにより、必要になるまでリストの読み込みを遅らせることができます。

要素が表示されるタイミングを制御するには、[Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.Visibility) プロパティの代わりに [x:Load attribute](../xaml-platform/x-load-attribute.md) を使います。 要素の Visibility が **Collapsed** に設定されている場合、その要素はレンダリング パスではスキップされますが、オブジェクト インスタンスのメモリ使用のコストは発生します。 代わりに x:Load を使用すると、オブジェクト インスタンスは必要になるまで作成されないため、メモリ コストはさらに低くなります。 欠点は、UI が読み込まれていないときに、小さなメモリ オーバーヘッド (約 600 バイト) が発生することです。

> [!NOTE]
> 要素の遅延読み込みには、[x:Load](../xaml-platform/x-load-attribute.md) 属性または [x:DeferLoadStrategy](../xaml-platform/x-deferloadstrategy-attribute.md) 属性を使うことができます。 x:Load 属性は、Windows 10 Creators Update (Version 1703、SDK ビルド 15063) 以降で使用できます。 x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。 それより前のバージョンを対象とする場合は、x:DeferLoadStrategy を使います。

以降の例では、異なる方法を使って UI 要素を非表示にした場合の要素数とメモリ使用量の違いを示します。 ページのルート Grid に、まったく同じ項目を含む ListView と GridView が 1 つずつ配置されています。 ListView は非表示ですが、GridView は表示されています。 これらの例の XAML は、いずれも画面上に同一の UI を生成します。 要素数とメモリ使用量の確認には、Visual Studio の[プロファイリングとパフォーマンスに関するツール](tools-for-profiling-and-performance.md)を使います。

#### <a name="option-1---inefficient"></a>オプション 1 - 非効率的

この例では、ListView は読み込まれますが、Width が 0 なので表示されません。 ListView とその各子要素は、ビジュアル ツリー内に作成され、メモリに読み込まれます。

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <ListView x:Name="List1" Width="0">
        <ListViewItem>Item 1</ListViewItem>
        <ListViewItem>Item 2</ListViewItem>
        <ListViewItem>Item 3</ListViewItem>
        <ListViewItem>Item 4</ListViewItem>
        <ListViewItem>Item 5</ListViewItem>
        <ListViewItem>Item 6</ListViewItem>
        <ListViewItem>Item 7</ListViewItem>
        <ListViewItem>Item 8</ListViewItem>
        <ListViewItem>Item 9</ListViewItem>
        <ListViewItem>Item 10</ListViewItem>
    </ListView>

    <GridView x:Name="Grid1">
        <GridViewItem>Item 1</GridViewItem>
        <GridViewItem>Item 2</GridViewItem>
        <GridViewItem>Item 3</GridViewItem>
        <GridViewItem>Item 4</GridViewItem>
        <GridViewItem>Item 5</GridViewItem>
        <GridViewItem>Item 6</GridViewItem>
        <GridViewItem>Item 7</GridViewItem>
        <GridViewItem>Item 8</GridViewItem>
        <GridViewItem>Item 9</GridViewItem>
        <GridViewItem>Item 10</GridViewItem>
    </GridView>
</Grid>
```

ListView を読み込んだ場合のライブ ビジュアル ツリー。 ページの要素の総数は 89 です。

![リスト ビューのあるビジュアル ツリー](images/visual-tree-1.png)

ListView とその子がメモリに読み込まれています。

![リスト ビューのあるビジュアル ツリー](images/memory-use-1.png)

#### <a name="option-2---better"></a>オプション 2 - やや効率的

この例では、ListView の Visibility が Collapsed に設定されています (その他の XAML は元と同じです)。 ListView はビジュアル ツリーに作成されますが、その子要素は作成されません。 ただし、メモリには子要素も読み込まれるため、メモリ使用量は前の例と同じです。

```xaml
    <ListView x:Name="List1" Visibility="Collapsed">
```

ListView を Collapsed に設定した場合のライブ ビジュアル ツリー。 ページの要素の総数は 46 です。

![折りたたまれたリスト ビューのあるビジュアル ツリー](images/visual-tree-2.png)

ListView とその子がメモリに読み込まれています。

![リスト ビューのあるビジュアル ツリー](images/memory-use-1.png)

#### <a name="option-3---most-efficient"></a>オプション 3 - 最も効率的

この例では、ListView の x:Load 属性が **False** に設定されています (その他の XAML は元と同じです)。 この ListView は、起動時にはビジュアル ツリーに作成されず、メモリにも読み込まれません。

```xaml
    <ListView x:Name="List1" Visibility="Collapsed" x:Load="False">
```

ListView が読み込まれていないライブ ビジュアル ツリー。 ページの要素の総数は 45 です。

![リスト ビューが読み込まれていないビジュアル ツリー](images/visual-tree-3.png)

ListView とその子はメモリに読み込まれていません。

![リスト ビューのあるビジュアル ツリー](images/memory-use-3.png)

> [!NOTE]
> これらの例における要素数とメモリ使用量は非常に小さく、概念を紹介するためだけに示したものです。 これらの例では、x:Load を使った場合のオーバーヘッドがメモリの節約量よりも大きくなるため、実際にはアプリにとってのメリットはありません。 アプリにとって遅延読み込みが効果的かどうかを判断するには、アプリに対してプロファイリング ツールを使用する必要があります。

### <a name="use-layout-panel-properties"></a>レイアウト パネルのプロパティを使う

レイアウト パネルには [Background](https://msdn.microsoft.com/library/windows/apps/BR227512) プロパティが用意されているため、色を付ける目的でパネルの前面に [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を配置する必要はありません。

**非効率的**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Grid>
    <Rectangle Fill="Black"/>
</Grid>
```

**効率的**

```xaml
<Grid Background="Black"/>
```

レイアウト パネルには組み込みの境界線プロパティも用意されているため、レイアウト パネルの周りに [Border](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border) 要素を追加する必要はありません。 詳細と例については、「[XAML レイアウトの最適化](optimize-your-xaml-layout.md)」をご覧ください。

### <a name="use-images-in-place-of-vector-based-elements"></a>ベクター ベースの要素の代わりに画像を使う

同じベクター ベースの要素を十分な回数再利用する場合は、代わりに [Image](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) 要素を使うと効率が高まります。 ベクター ベースの要素は、CPU が個々の要素をそれぞれ個別に作成する必要があるため、負荷が高くなる可能性があります。 これに対して画像ファイルは、1 回デコードするだけで済みます。

## <a name="optimize-resources-and-resource-dictionaries"></a>リソースとリソース ディクショナリの最適化

通常、アプリ内の複数の場所から参照されるリソースをある程度グローバルに格納するには、[リソース ディクショナリ](../design/controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)を使います。 このようなリソースには、スタイル、ブラシ、テンプレートなどがあります。

一般に、[ResourceDictionary](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.ResourceDictionary) は、要求されない限りリソースをインスタンス化しないように最適化されています。 ただし、リソースが不要にインスタンス化されないようにするために、避けた方がよい状況もあります。

### <a name="resources-with-xname"></a>x:Name を含むリソース

リソースを参照するときは、[x:Key 属性](../xaml-platform/x-key-attribute.md)を使います。 [x:Name 属性](../xaml-platform/x-name-attribute.md)を持つリソースは、プラットフォームの最適化のメリットが適用されず、ResourceDictionary が作成されるとすぐにインスタンス化されます。 これは、x: Name がプラットフォームに対し、アプリがこのリソースへのフィールド アクセスを必要としており、プラットフォームは参照を作成するものを何か作成する必要があると指示するからです。

### <a name="resourcedictionary-in-a-usercontrol"></a>UserControl 内の ResourceDictionary

[UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol) の内部に定義された ResourceDictionary にはペナルティが発生します。 プラットフォームは、UserControl のすべてのインスタンスに対して、このような ResourceDictionary のコピーを作成します。 よく使われる UserControl を使っている場合、UserControl から ResourceDictionary を移動し、ページ レベルに配置します。

### <a name="resource-and-resourcedictionary-scope"></a>リソースと ResourceDictionary のスコープ

ページで参照しているユーザー コントロールやリソースが別のファイルに定義されている場合は、そのファイルもフレームワークによって解析されます。

次の例では、_InitialPage.xaml_ で _ExampleResourceDictionary.xaml_ のリソースが 1 つ使われているため、起動時に _ExampleResourceDictionary.xaml_ 全体を解析する必要があります。

**InitialPage.xaml**

```xaml
<Page x:Class="ExampleNamespace.InitialPage" ...>
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ExampleResourceDictionary.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>

    <Grid>
        <TextBox Foreground="{StaticResource TextBrush}"/>
    </Grid>
</Page>
```

**ExampleResourceDictionary.xaml**

```xaml
<ResourceDictionary>
    <SolidColorBrush x:Key="TextBrush" Color="#FF3F42CC"/>

    <!--This ResourceDictionary contains many other resources that
        are used in the app, but are not needed during startup.-->
</ResourceDictionary>
```

1 つのリソースをアプリ全体の多くのページで使う場合、そのリソースを _App.xaml_ に格納することをお勧めします。これにより、重複を避けることができます。 ただし、_App.xaml_ はアプリの起動時に解析されるため、1 つのページでしか使われないリソースは、(そのページが最初のページでない限り) ページのローカル リソースに配置する必要があります。 次の例は、(最初のページ以外の) 1 つのページでしか使われないリソースを含む _App.xaml_ を示しています。 この場合、アプリの起動時間が不必要に増加します。

**App.xaml**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Application ...>
     <Application.Resources>
        <SolidColorBrush x:Key="DefaultAppTextBrush" Color="#FF3F42CC"/>
        <SolidColorBrush x:Key="InitialPageTextBrush" Color="#FF3F42CC"/>
        <SolidColorBrush x:Key="SecondPageTextBrush" Color="#FF3F42CC"/>
        <SolidColorBrush x:Key="ThirdPageTextBrush" Color="#FF3F42CC"/>
    </Application.Resources>
</Application>
```

**InitialPage.xaml**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Page x:Class="ExampleNamespace.InitialPage" ...>
    <StackPanel>
        <TextBox Foreground="{StaticResource InitialPageTextBrush}"/>
    </StackPanel>
</Page>
```

**SecondPage.xaml**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Page x:Class="ExampleNamespace.SecondPage" ...>
    <StackPanel>
        <Button Content="Submit" Foreground="{StaticResource SecondPageTextBrush}" />
    </StackPanel>
</Page>
```

この例の効率を改善するには、`SecondPageTextBrush` を _SecondPage.xaml_ に移動し、`ThirdPageTextBrush` を _ThirdPage.xaml_ に移動します。 `InitialPageTextBrush`  については、どの場合でもアプリの起動時にアプリケーション リソースを解析する必要があるため、_App.xaml_ 内に残しておくことができます。

### <a name="consolidate-multiple-brushes-that-look-the-same-into-one-resource"></a>同じように見える複数のブラシを 1 つのリソースに統合する

XAML プラットフォームは、よく使われるオブジェクトをキャッシュして、何度も再利用できるようにします。 しかし、あるマークアップで宣言されているブラシが別のマークアップで宣言されているブラシと同じであるかどうかは簡単に判断できません。 ここでは、例として [SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962) を使っていますが、より多く使われる可能性があって重要なのは [GradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210068) です。 また、事前定義された色を使うブラシもチェックする必要があります。たとえば、`"Orange"` と `"#FFFFA500"` は同じ色です。

**非効率的**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Page ... >
    <StackPanel>
        <TextBlock>
            <TextBlock.Foreground>
                <SolidColorBrush Color="#FFFFA500"/>
            </TextBlock.Foreground>
        </TextBox>
        <Button Content="Submit">
            <Button.Foreground>
                <SolidColorBrush Color="#FFFFA500"/>
            </Button.Foreground>
        </Button>
    </StackPanel>
</Page>
```

重複を除去するには、ブラシをリソースとして定義します。 他のページのコントロールで同じブラシを使う場合は、ブラシを _App.xaml_ に移動します。

**効率的**

```xaml
<Page ... >
    <Page.Resources>
        <SolidColorBrush x:Key="BrandBrush" Color="#FFFFA500"/>
    </Page.Resources>

    <StackPanel>
        <TextBlock Foreground="{StaticResource BrandBrush}" />
        <Button Content="Submit" Foreground="{StaticResource BrandBrush}" />
    </StackPanel>
</Page>
```

## <a name="minimize-overdrawing"></a>過剰な描画の最小化

過剰な描画は、画面上の同じピクセルに複数のオブジェクトが描画される場合に発生します。 ただし、このガイダンスと要素数を最小限に抑えたいという要求は両立せず、トレードオフが必要になることがあります。

視覚的な診断には、[**DebugSettings.IsOverdrawHeatMapEnabled**](https://msdn.microsoft.com/library/windows/apps/Hh701823) を使います。 シーンに存在するとは思わなかったオブジェクトが描画されていることに気付く場合があります。

### <a name="transparent-or-hidden-elements"></a>透明または非表示の要素

要素が透明であるか、他の要素の背後に隠れているために表示されず、レイアウトに関与していない場合は、その要素を削除することをお勧めします。 初期の表示状態では要素が表示されないものの、他の表示状態で表示される場合は、x:Load を使ってその状態を制御するか、要素自体の [Visibility](https://msdn.microsoft.com/library/windows/apps/BR208992) を **Collapsed** に設定しておいて、該当の状態になったら値を **Visible** に変更します。 このヒューリスティックには例外があります。一般に、要素にローカルに設定する表示状態は、プロパティに設定されていることが最も多い値にするのが最良です。

### <a name="composite-elements"></a>複合要素

複数の要素を重ねて効果を作成する代わりに、複合要素を使います。 次の例では、結果は 2 色の図形になり、上半分は黒 ([Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) の背景)、下半分は灰色 (**Grid** の黒い背景の上にアルファ ブレンドされた半透明の白い [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle)) で表示されます。 この場合、結果を得るために必要なピクセルの 150% が塗りつぶされることになります。

**非効率的。**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Grid Background="Black">
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Rectangle Grid.Row="1" Fill="White" Opacity=".5"/>
</Grid>
```

**効率的**

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Rectangle Fill="Black"/>
    <Rectangle Grid.Row="1" Fill="#FF7F7F7F"/>
</Grid>
```

### <a name="layout-panels"></a>レイアウト パネル

レイアウト パネルには、領域の色指定と、子要素のレイアウトの 2 つの目的があります。 z オーダーの要素の領域が既に塗られている場合は、前面のレイアウト パネルでその領域を塗りつぶす必要はありません。代わりに、パネルではその子を重点的にレイアウトします。 次に例を示します。

**非効率的。**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<GridView Background="Blue">
    <GridView.ItemTemplate>
        <DataTemplate>
            <Grid Background="Blue"/>
        </DataTemplate>
    </GridView.ItemTemplate>
</GridView>
```

**効率的**

```xaml
<GridView Background="Blue">
    <GridView.ItemTemplate>
        <DataTemplate>
            <Grid/>
        </DataTemplate>
    </GridView.ItemTemplate>
</GridView>
```

[Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) のヒット テストを可能にするには、その背景の値を透明に設定します。

### <a name="borders"></a>境界線

オブジェクトの周りに境界線を描画するには、[Border](https://msdn.microsoft.com/library/windows/apps/BR209253) 要素を使います。 次の例では、[TextBox](https://msdn.microsoft.com/library/windows/apps/BR209683) を囲む間に合わせの境界線として [Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) を使用しています。 この方法では、中央のセル内のすべてのピクセルが複数回描画されます。

**非効率的。**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Grid Background="Blue" Width="300" Height="45">
    <Grid.RowDefinitions>
        <RowDefinition Height="5"/>
        <RowDefinition/>
        <RowDefinition Height="5"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="5"/>
        <ColumnDefinition/>
        <ColumnDefinition Width="5"/>
    </Grid.ColumnDefinitions>
    <TextBox Grid.Row="1" Grid.Column="1"></TextBox>
</Grid>
```

**効率的**

```xaml
 <Border BorderBrush="Blue" BorderThickness="5" Width="300" Height="45">
     <TextBox/>
</Border>
```

### <a name="margins"></a>余白

余白に注意してください。 負の余白が隣の要素のレンダリング境界に達すると、隣り合った 2 つの要素が (意図せずに) 重なり合い、過剰な描画を引き起こします。

### <a name="cache-static-content"></a>静的コンテンツのキャッシュ

過剰な描画の別の原因として、多数の要素を重ね合わせて作成される図形があります。 複合図形を含む [UIElement](https://msdn.microsoft.com/library/windows/apps/BR208911) で [CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084) を **BitmapCache** に設定すると、プラットフォームによって要素がいったんビットマップにレンダリングされ、何度も描画する代わりに、そのビットマップが各フレームで使われます。

**非効率的**

```xaml
<Canvas Background="White">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

![単色の 3 つの円を使ったベン図](images/solidvenn.png)

上の図がその結果ですが、過剰に描画された領域のマップは次のようになります。 赤色が濃いほど、描画回数が多いことを示しています。

![重なっている部分がわかるベン図](images/translucentvenn.png)

**効率的**

```xaml
<Canvas Background="White" CacheMode="BitmapCache">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

[CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084) を使っていることに注目してください。 サブ図形がアニメーション化されている場合は、この方法を使わないでください。その目的に反し、各フレームでビットマップ キャッシュを再生成することが必要になる可能性があるためです。

## <a name="use-xbf2"></a>XBF2 の使用

XBF2 は、実行時にすべてのテキスト解析コストを回避する XAML マークアップのバイナリ表現です。 また、読み込みとツリーの作成のためにバイナリを最適化し、VSM、ResourceDictionary、Styles などのヒープやオブジェクトの作成コストを改善するために XAML 型の "高速パス" を使用できるようにします。 これは完全にメモリ マッピングされるため、XAML ページの読み込みや読み取りにヒープは使用されません。 さらに、appx に保存している XAML ページのディスク使用量が削減されます。 XBF2 はよりコンパクトな表現であり、同等の XAML/XBF1 ファイルのディスク使用量を最大 50% 削減できます。 たとえば、組み込みのフォト アプリの場合、XBF2 への変換によって、およそ 1 MB の XBF1 アセットが 400 KB の XBF2 アセットに縮小され、約 60% の削減が実現されました。 また、CPU で 15 ～ 20%、Win32 ヒープで 10 ～ 15% のメリットをアプリにもたらします。

フレームワークが提供する XAML の組み込みのコントロールとディクショナリは、既に XBF2 に完全に対応しています。 独自のアプリでは、プロジェクト ファイルで TargetPlatformVersion 8.2 以降を宣言していることを確認します。

XBF2 があるかどうかを確認するには、バイナリ エディターでアプリを開きます。XBF2 がある場合、12 番目と 13 番目のバイトは 00 02 です。

## <a name="related-articles"></a>関連記事

- [アプリ起動時のパフォーマンスのベスト プラクティス](best-practices-for-your-app-s-startup-performance.md)
- [XAML レイアウトの最適化](optimize-your-xaml-layout.md)
- [ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)
- [プロファイリングとパフォーマンスに関するツール](tools-for-profiling-and-performance.md)
