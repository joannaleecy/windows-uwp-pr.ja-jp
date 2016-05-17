---
author: mcleblanc
ms.assetid: 569E8C27-FA01-41D8-80B9-1E3E637D5B99
title: XAML マークアップの最適化
description: UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、アプリでの XAML マークアップの解析および読み込み時間や、メモリ効率の向上に役立つヒントを紹介します。
---
# XAML マークアップの最適化

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、アプリでの XAML マークアップの解析および読み込み時間や、メモリ効率の向上に役立つヒントを紹介します。

アプリの起動時に、読み込む XAML マークアップを最初の UI に必要な分だけに制限します。 最初のページ内のマークアップを調べ、不要なものが含まれていないことを確認します。 ページで、別のファイル内に定義したユーザー コントロールやリソースを参照している場合は、そのファイルもフレームワークによって解析されます。

この例では、InitialPage.xaml で ExampleResourceDictionary.xaml の 1 つのリソースが使用されるため、起動時に ExampleResourceDictionary.xaml 全体を解析する必要があります。

**InitialPage.xaml**

```xml
<Page x:Class="ExampleNamespace.InitialPage" ...> 
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ExampleResourceDictionary.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>

    <Grid>
        <TextBox Foreground="{StaticResource TextBrush}"/>
    </Grid>
</Page>
```

**ExampleResourceDictionary.xaml**

```xml
<ResourceDictionary>
    <SolidColorBrush x:Key="TextBrush" Color="#FF3F42CC"/>

    <!--This ResourceDictionary contains many other resources that
    used in the app, but not during startup.-->
</ResourceDictionary>
```

1 つのリソースをアプリ全体の多くのページで使う場合、そのリソースを App.xaml に格納することをお勧めします。これにより、重複を避けられます。 ただし、App.xaml はアプリの起動時に解析されるため、1 つのページのみで使用されるリソース (ページが最初のページでない限り) をページのローカル リソースに配置する必要があります。 この反例は、(最初のページではない) 1 つのページのみによって使用されるリソースを含む App.xaml を示しています。 ここでは、アプリの起動時間が不必要に増加します。

**InitialPage.xaml**

```xml
<Page ...>  <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->   
    <StackPanel>  
        <TextBox Foreground="{StaticResource InitialPageTextBrush}"/> 
    </StackPanel> 
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**SecondPage.xaml**

```xml
<Page ...>  <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <StackPanel> 
        <Button Content="Submit" Foreground="{StaticResource SecondPageTextBrush}" /> 
    </StackPanel> 
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**App.xaml**

```xml
<Application ...> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
     <Application.Resources>  
        <SolidColorBrush x:Key="DefaultAppTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="InitialPageTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="SecondPageTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="ThirdPageTextBrush" Color="#FF3F42CC"/> 
    </Application.Resources> 
</Application> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

上の反例の効率を高めるには、`SecondPageTextBrush` を SecondPage.xaml に、`ThirdPageTextBrush` を ThirdPage.xaml に移動します。 `InitialPageTextBrush` は、どの場合でもアプリケーション リソースをアプリの起動時に解析する必要があるため、App.xaml 内に残しておくことができます。

## 要素数の最少化

XAML プラットフォームでは大量の要素を表示できますが、目的のビジュアルを満たすためのページ上の要素の数を減らすと、アプリ レイアウトの作成とレンダリングをより速く行うことができます。

-   レイアウト パネルには [**Background**](https://msdn.microsoft.com/library/windows/apps/BR227512) プロパティが用意されているため、色を指定するためにパネルの前に [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371) を配置する必要はありません。

**非効率的。**

```xml
<Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
        <Rectangle Fill="Black"/> 
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**効率的。**

```xml
<Grid Background="Black"/>
```

-   同じベクターベースの要素を十分な回数再利用する場合は、代わりに [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素を使うと効率がさらに高まります。 ベクターベース要素は、CPU が個々の要素をそれぞれ個別に作成する必要があるため、負荷が高くなる可能性があります。 画像ファイルは 1 回デコードするだけ済みます。

## 同じように見える複数のブラシを 1 つのリソースに統合する

XAML プラットフォームは、よく使われるオブジェクトをキャッシュして、何度も再利用できるようにします。 しかし、あるマークアップで宣言されているブラシが別のマークアップで宣言されているブラシと同じであるかどうかは簡単に判断できません。 ここでは、例として [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を用いますが、[**GradientBrush**](https://msdn.microsoft.com/library/windows/apps/BR210068) のほうが使う可能性が高く、より重要です。

**非効率的。**

```xml
<Page ... > <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
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
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

また、事前定義された色を使うブラシもチェックしてください (`"Orange"` と `"#FFFFA500"` は同じ色です)。 重複を除去するには、ブラシをリソースとして定義します。 他のページのコントロールで同じブラシを使う場合は、ブラシを App.xaml に移動します。

**効率的。**

```xml
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

## 過剰な描画の最小化

過剰な描画とは、同じスクリーン ピクセル単位で複数のオブジェクトが描画されることを指します。 ただし、このガイダンスと要素数を最小限に抑えたいという要求は両立しません。

-   要素が透明であったり、他の要素の背後に隠れている場合は、レイアウトに影響を及ぼさないため削除してください。 要素が初期表示状態で表示されないものの、他の表示状態で表示される場合は、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) を要素自体の **Collapsed** に設定し、該当の状態で値を **Visible** に変更します。 このヒューリスティックには例外があります。一般に、ほとんどの表示状態でプロパティに設定された値は、要素上でのローカルの最良の設定になります。
-   効果を作成する場合は、複数の要素を重ねる代わりに、コンポジット要素を使います。 この例では、結果は、上半分は黒 ([**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) の背景)、下半分は灰色 (**Grid** の黒い背景の上にアルファ ブレンドされた半透明の白い [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371)) の 2 色の図形になります。 ここでは、結果を達成するのに必要な 150% のピクセルが塗りつぶされます。

**非効率的。**
    
```xml
    <Grid Background="Black"> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
        <Grid.RowDefinitions> 
            <RowDefinition Height="*"/> 
            <RowDefinition Height="*"/> 
        </Grid.RowDefinitions> 
        <Rectangle Grid.Row="1" Fill="White" Opacity=".5"/> 
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**効率的。**

```xml
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Rectangle Fill="Black"/>
        <Rectangle Grid.Row="1" Fill="#FF7F7F7F"/>
    </Grid>
```

-   レイアウト パネルには、領域の色指定と、子要素のレイアウトの 2 つの目的があります。 z オーダーの要素の領域が既に塗られている場合は、前面のレイアウト パネルでその領域を塗りつぶす必要はありません。代わりに、パネルではその子を重点的にレイアウトします。 次に例を示します。

**非効率的。**

```xml
    <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <GridView Background="Blue">  
        <GridView.ItemTemplate> 
            <DataTemplate> 
                <Grid Background="Blue"/> 
            </DataTemplate> 
        </GridView.ItemTemplate> 
    </GridView> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**効率的。**

```xml
    <GridView Background="Blue">  
        <GridView.ItemTemplate> 
            <DataTemplate> 
                <Grid/> 
            </DataTemplate>
        </GridView.ItemTemplate>
    </GridView> 
```

[
            **Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) のヒット テストを可能にするには、これに対して透明の背景の値を設定します。

-   [
            **Border**](https://msdn.microsoft.com/library/windows/apps/BR209253) 要素を使ってオブジェクトの周りに境界線を描画します。 この例では、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) を [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) を囲む間に合わせの境界線として使用します。 ただし、中央のセル内のピクセルすべてが複数回描画されます。

**非効率的。**

```xml
    <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
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
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**効率的。**

```xml
    <Border BorderBrush="Blue" BorderThickness="5" Width="300" Height="45">
        <TextBox/>
    </Border>
```

-   余白に注意してください。 2 つの隣り合う要素の負の余白が他方のレンダリング境界に達し、過剰な描画が発生すると、これらの要素は (意図せずに) 重なります。

[
            **DebugSettings.IsOverdrawHeatMapEnabled**](https://msdn.microsoft.com/library/windows/apps/Hh701823) を視覚的な診断として使います。 以前はなかったオブジェクトが描画され、シーン内に表示されていることがわかります。

## 静的コンテンツのキャッシュ

過剰な描画の別の原因として、多数の重複する要素から作成される図形があります。 コンポジット図形を含む [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) で [**CacheMode**](https://msdn.microsoft.com/library/windows/apps/BR228084) を **BitmapCache** に設定した場合、プラットフォームで要素が一度ビットマップでレンダリングされ、過剰な描画の代わりにそのビットマップの各フレームが使われます。

**非効率的。**

```xml
<Canvas Background="White">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

![単色の 3 つの円を使ったベン図](images/solidvenn.png)

上の図がその結果ですが、過剰に描画された領域のマップは次のようになります。 赤色が濃いほど、描画回数が多いことを示しています。

![重なっている部分がわかるベン図](images/translucentvenn.png)

**効率的。**

```xml
<Canvas Background="White" CacheMode="BitmapCache">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

[
            **CacheMode**](https://msdn.microsoft.com/library/windows/apps/BR228084) を使っていることに注目してください。 サブ図形がアニメーション化されている場合は、この方法を使わないでください。その目的に反し、各フレームでビットマップ キャッシュを再生成することが必要になる可能性があるためです。

## ResourceDictionaries

ResourceDictionaries は通常、ある程度グローバル レベルでリソースを格納する場合に使用されます。 アプリの複数の場所で参照する必要があるリソースです。 たとえば、スタイル、ブラシ、テンプレートです。 一般的に、要求されない限りリソースがインスタンス化されないようにするために ResourceDictionaries を最適化します。 少し注意を払う必要がある場合がいくつかあります。

**x:Name を含むリソース**。 x:Name を持つリソースでは、プラットフォームの最適化のメリットはなく、代わりに、ResourceDictionary が作成されるとすぐにインスタンス化されます。 これは、x: Name がプラットフォームに対して、アプリがこのリソースへのフィールド アクセスを必要としており、プラットフォームが参照を作成するものを作成する必要があることを指示するために発生します。

**UserControl 内の ResourceDictionaries**。 UserControl 内で定義された ResourceDictionaries ではパフォーマンスが低下します。 プラットフォームは、UserControl のすべてのインスタンスに対して、このような ResourceDictionary のコピーを作成します。 よく使われる UserControl を使っている場合、UserControl から ResourceDictionary を移動し、ページ レベルに配置します。

## XBF2 の使用

XBF2 は、実行時にすべてのテキスト解析コストを回避する XAML マークアップのバイナリ表現です。 また、読み込みとツリーの作成のためにバイナリを最適化し、VSM、ResourceDictionary、Styles などのヒープやオブジェクトの作成コストを改善するために XAML 型の "高速パス" を使用できるようにします。 これは完全にメモリ マッピングされるため、XAML ページの読み込みや読み取りにヒープは使用されません。 さらに、appx に保存している XAML ページのディスク使用量が削減されます。 XBF2 はよりコンパクトな表現であり、同等の XAML/XBF1 ファイルのディスク使用量を最大 50% 削減できます。 たとえば、組み込みのフォト アプリの場合、XBF2 への変換によって、およそ 1 MB の XBF1 アセットが 400 KB の XBF2 アセットに縮小され、約 60% の削減が実現されました。 また、CPU で 15 ～ 20%、Win32 ヒープで 10 ～ 15% のメリットをアプリにもたらします。

フレームワークが提供する XAML の組み込みのコントロールとディクショナリは、既に XBF2 に完全に対応しています。 独自のアプリでは、プロジェクト ファイルで TargetPlatformVersion 8.2 以降を宣言していることを確認します。

XBF2 があるかどうかを確認するには、バイナリ エディターでアプリを開きます。XBF2 がある場合、12 番目と 13 番目のバイトは 00 02 です。



<!--HONumber=May16_HO2-->


