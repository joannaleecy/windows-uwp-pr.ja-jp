---
author: Jwmsft
Description: "ResourceDictionary 要素とキーを持つリソースを定義する方法と、アプリまたはアプリ パッケージの一部として定義する他のリソースと XAML リソースの関連について説明します。"
MS-HAID: dev\_ctrl\_layout\_txt.resourcedictionary\_and\_xaml\_resource\_references
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "ResourceDictionary と XAML リソースの参照"
ms.assetid: E3CBFA3D-6AF5-44E1-B9F9-C3D3EA8A25CE
label: ResourceDictionary and XAML resource references
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: f4b4e437bde7dbb7bc1320c066fc0b57cfd112cd
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="resourcedictionary-and-xaml-resource-references"></a>ResourceDictionary と XAML リソースの参照

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

XAML を使ってアプリの UI やリソースを定義できます。 リソースとは、通常、複数回使うことが予定されたオブジェクトの定義です。 後で XAML リソースを参照するために、名前のような働きをするリソースのキーを指定します。 リソースは、アプリのどこからでも参照でき、アプリ内の任意の XAML ページからも参照できます。 Windows ランタイム XAML の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素を使って、リソースを定義できます。 リソースを定義すると、[StaticResource マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)または [ThemeResource マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を使ってリソースを参照できます。

XAML リソースとして宣言することが多い XAML 要素としては、[Style](https://msdn.microsoft.com/library/windows/apps/br208849)、[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)、アニメーション コンポーネント、および [Brush](https://msdn.microsoft.com/library/windows/apps/br228076) サブクラスがあります。 ここでは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) とキーを持つリソースを定義する方法と、アプリまたはアプリ パッケージの一部として定義する他のリソースと XAML リソースの関連について説明します。 また、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) や [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) などのリソース ディクショナリの高度な機能についても説明します。

**前提条件**

XAML マークアップについて理解し、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)」を読んでいることを前提とします。

## <a name="define-and-use-xaml-resources"></a>XAML リソースを定義して使う

XAML リソースは、マークアップから 2 回以上参照されるオブジェクトです。 リソースは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されます。通常は、別個のファイルで、または次のようにマークアップ ページの上部で定義されます。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
        <x:String x:Key="goodbye">Goodbye world</x:String>
    </Page.Resources>

    <TextBlock Text="{StaticResource greeting}" Foreground="Gray" VerticalAlignment="Center"/>
</Page>
```

この例では、次の操作を行います。

-   `<Page.Resources>…</Page.Resources>` - リソース ディクショナリを定義します。
-   `<x:String>` - キー "greeting" を持つリソースを定義します。
-   `{StaticResource greeting}` - [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の [Text](https://msdn.microsoft.com/library/windows/apps/br209676)  プロパティに割り当てられた、キー "greeting" を持つリソースを検索します。

> **注**&nbsp;&nbsp; [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に関連する概念を、**リソース** ビルド アクション、リソース (.resw) ファイル、またはアプリ パッケージを生成するコード プロジェクトの構築のコンテキストで説明されるその他の "リソース" と混同しないでください。

リソースを文字列にする必要はありません。スタイル、テンプレート、ブラシ、色など、任意の共有可能なオブジェクトにすることができます。 ただし、コントロール、図形、および他の [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) は共有可能ではないため、再利用可能なリソースとして宣言することはできません。 共有について詳しくは、このトピックの後方の「[XAML リソースは共有できる必要がある](#xaml-resources-must-be-sharable)」をご覧ください。

ここでは、ブラシと文字列の両方がリソースとして宣言されており、ページでコントロールにより使用されています。

```XAML
<Page
    x:Class="SpiderMSDN.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <SolidColorBrush x:Key="myFavoriteColor" Color="green"/>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource myFavoriteColor}" Text="{StaticResource greeting}" VerticalAlignment="Top"/>
    <Button Foreground="{StaticResource myFavoriteColor}" Content="{StaticResource greeting}" VerticalAlignment="Center"/>
</Page>
```

すべてのリソースにはキーが必要です。 通常、そのキーは `x:Key=”myString”` を使って定義された文字列です。 ただし、キーを指定する方法は他にもいくつかあります。

-   [Style](https://msdn.microsoft.com/library/windows/apps/br208849) と [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) には **TargetType** が必要であり、[x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) が指定されていない場合は **TargetType** をキーとして使います。 この場合、キーは文字列ではなく実際の Type オブジェクトです  (以下の例をご覧ください)。
-   [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) が指定されていない場合、**TargetType** を持つ [DataTemplate](https://msdn.microsoft.com/library/windows/apps/br242348) リソースはキーとして **TargetType** を使います。 この場合、キーは文字列ではなく実際の Type オブジェクトです 
-   [x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788) は [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) の代わりに使うことができます。 ただし、x:Name はリソースのコード ビハインド フィールドも生成します。 この結果、ページの読み込み時にそのフィールドを初期化する必要があるため、x:Name は x:Key よりも効率が低下します。

[StaticResource マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)は、文字列名 ([x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) または [x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788)) を使ってのみリソースを取得できます。 ただし、[Style](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティと [ContentTemplate](https://msdn.microsoft.com/library/windows/apps/br209369) プロパティまたは [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/br242830) プロパティを設定していないコントロールに使うスタイルとテンプレートを決定する際に、XAML フレームワークは暗黙的なスタイル リソース (x:Key または x:Name ではなく **TargetType** を使うリソース) も探します。

ここでは、[Style](https://msdn.microsoft.com/library/windows/apps/br208849) に **typeof(Button)** の暗黙的なキーがあります。また、ページの下部にある [Button](https://msdn.microsoft.com/library/windows/apps/br209265) は [Style](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティを指定しないため、キー **typeof(Button)** を持つスタイルを探します。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <Style TargetType="Button">
              <Setter Property="Background" Value="red"/>
        </Style>
    </Page.Resources> 
       <!-- This button will have a red background. -->
       <Button Content="Button" Height="100" VerticalAlignment="Center" Width="100"/>
</Page>
```

暗黙的なスタイルとそのしくみについて詳しくは、「[コントロールのスタイル](styling-controls.md)」と「[コントロール テンプレート](control-templates.md)」をご覧ください。

## <a name="look-up-resources-in-code"></a>コード内のリソースを検索する

その他のディクショナリなどのリソース ディクショナリのメンバーにアクセスします。

> **注**&nbsp;&nbsp;コード内でこのリソース検索を実行すると、`Page.Resources` ディクショナリ内のリソースだけが検索されます。 [StaticResource マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)とは異なり、最初のディクショナリでリソースが見つからない場合に、コードは `Application.Resources` ディクショナリにフォールバックしません。

 

この例では、ページのリソース ディクショナリから `redButtonStyle` リソースを取得する方法を示します。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <Style TargetType="Button" x:Key="redButtonStyle">
            <Setter Property="Background" Value="red"/>
        </Style>
    </Page.Resources>
</Page>
```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Style redButtonStyle = (Style)this.Resources["redButtonStyle"];
        }
    }
```

コードからアプリ全体のリソースを検索するには、ここに示すように **Application.Current.Resources** を使ってアプリのリソース ディクショナリを取得します。

```XAML
<Application
    x:Class="MSDNSample.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:SpiderMSDN">
    <Application.Resources>
        <Style TargetType="Button" x:Key="appButtonStyle">
            <Setter Property="Background" Value="red"/>
        </Style>
    </Application.Resources>

</Application>
```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Style appButtonStyle = (Style)Application.Current.Resources["appButtonStyle"];
        }
    }
```

コードにアプリケーション リソースを追加することもできます。

この操作を実行する際に留意すべき点が 2 つあります。

-   まず、ページがリソースを使おうとする前にリソースを追加する必要があります。
-   次に、アプリのコンストラクターにリソースを追加することはできません。

これと同様に、[Application.OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドにリソースを追加した場合、両方の問題を回避することができます。

```CSharp
// App.xaml.cs
    
sealed partial class App : Application
{
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            SolidColorBrush brush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0)); // green
            this.Resources["brush"] = brush;
            // … Other code that VS generates for you …
        }
    }
}
```

## <a name="every-frameworkelement-can-have-a-resourcedictionary"></a>各 FrameworkElement に ResourceDictionary を追加できる

[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) は、コントロールの継承元の基底クラスであり、[Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティがあります。 そのため、任意の **FrameworkElement** にローカル リソース ディクショナリを追加できます。

ここでは、リソース ディクショナリがページ要素に追加されます。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <Border>
        <Border.Resources>
            <x:String x:Key="greeting">Hola mundo</x:String>
        </Border.Resources>
        <TextBlock Text="{StaticResource greeting}" Foreground="Gray" VerticalAlignment="Center"/>
    </Border>
</Page>

```

ここでは、[Page](https://msdn.microsoft.com/library/windows/apps/br227503) と [Border](https://msdn.microsoft.com/library/windows/apps/br209250) の両方にリソース ディクショナリがあり、どちらにも "greeting" というリソースがあります。 [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) は **Border** 内にあるため、そのリソース検索はまず **Border** のリソースを検索した後、**Page** のリソース、[Application](https://msdn.microsoft.com/library/windows/apps/br242324) のリソースの順に検索します。 **TextBlock** には、"Hola mundo" と表示されます。

コードからその要素のリソースにアクセスするには、その要素の [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティを使います。 XAML ではなくコード内の [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) のリソースにアクセスすると、親要素のディクショナリではなくそのディクショナリのみ検索されます。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <Border x:Name="border">
        <Border.Resources>
            <x:String x:Key="greeting">Hola mundo</x:String>
        </Border.Resources>
    </Border>
</Page>

```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            string str = (string)border.Resources["greeting"];
        }
    }
```

## <a name="merged-resource-dictionaries"></a>結合されたリソース ディクショナリ

*結合されたリソース ディクショナリ*は、あるリソース ディクショナリを別のディクショナリ (通常は別のファイルのディクショナリ) に結合します。

> **ヒント**&nbsp;&nbsp;Microsoft Visual Studio でリソース ディクショナリ ファイルを作成するには、**[プロジェクト]** メニューの **[追加] &gt; [新しい項目] &gt; [リソース ディクショナリ] オプション** を使います。

ここでは、Dictionary1.xaml という別の XAML ファイルでリソース ディクショナリを定義します。

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

```

そのディクショナリを使うには、ページのディクショナリと結合します。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
            </ResourceDictionary.MergedDictionaries>

            <x:String x:Key="greeting">Hello world</x:String>

        </ResourceDictionary>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource brush}" Text="{StaticResource greeting}" VerticalAlignment="Center"/>
</Page>
```

この例の動作を次に示します。 `<Page.Resources>` で、`<ResourceDictionary>` を宣言します。 リソースを `<Page.Resources>` に追加すると、XAML フレームワークによりリソース ディクショナリが暗黙的に自動作成されますが、この場合に必要なのは通常のリソース ディクショナリではなく、結合されたディクショナリを含むリソース ディクショナリです。

そのため、`<ResourceDictionary>` を宣言し、`<ResourceDictionary.MergedDictionaries>` コレクションに内容を追加します。 これらの各エントリは、`<ResourceDictionary Source="Dictionary1.xaml"/>` の形式を使います。 複数のディクショナリを追加するには、最初のエントリの後に `<ResourceDictionary Source="Dictionary2.xaml"/>` エントリを追加するだけです。

`<ResourceDictionary.MergedDictionaries>…</ResourceDictionary.MergedDictionaries>` の後、オプションで追加のリソースをメイン ディクショナリに配置できます。 結合されたディクショナリのリソースは、通常のディクショナリと同様に使います。 上の例では、`{StaticResource brush}` は子ディクショナリと結合されたディクショナリ (Dictionary1.xaml) でリソースを検索しますが、`{StaticResource greeting}` はメイン ページ ディクショナリでそのリソースを参照します。

リソース検索シーケンスでは、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ディクショナリはその [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のキーを持つその他すべてのリソースがチェックされた後にのみチェックされます。 そのレベルが検索され、結合されたディクショナリに到達すると、**MergedDictionaries** 内の各項目がチェックされます。 結合されたディクショナリが複数存在する場合、これらのディクショナリは **MergedDictionaries** プロパティで宣言された順序と反対の順序で確認されます。 次の例では、Dictionary2.xaml と Dictionary1.xaml の両方が同じキーを宣言した場合、Dictionary2.xaml のキーが最初に使われます。これが **MergedDictionaries** セット内の最後のキーであるためです。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
                <ResourceDictionary Source="Dictionary2.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource brush}" Text="greetings!" VerticalAlignment="Center"/>
</Page>
```

いずれかの [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のスコープ内で、ディクショナリのキーの一意性がチェックされます。 ただし、そのスコープは異なる [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ファイル内の異なる項目間に拡張されません。

検索シーケンスと、一意のキーが結合されたディクショナリ スコープを越えては適用されないことを組み合わせて使って、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) リソースのフォールバック値の順序を作成できます。 たとえば、アプリの状態とユーザー設定データに同期されるリソース ディクショナリを使って、シーケンス内で最後に結合されたリソース ディクショナリに特定のブラシ色のユーザー設定を保存できます。 ただし、ユーザー設定がまだ存在しない場合は、最初の [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ファイルで **ResourceDictionary** リソースに同じキー文字列を定義し、それをフォールバック値として使うことができます。 プライマリ リソース ディクショナリで提供する値は、常に結合されたディクショナリがチェックされる前にチェックされるため、フォールバック手法を使う場合は、プライマリ リソース ディクショナリにそのリソースを定義しないでください。

## <a name="theme-resources-and-theme-dictionaries"></a>テーマ リソースとテーマ ディクショナリ

[ThemeResource](../xaml-platform/themeresource-markup-extension.md) は [StaticResource](../xaml-platform/staticresource-markup-extension.md) と似ていますが、テーマが変更されるとリソース検索が再評価されます。

この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の前景色を現在のテーマの値に設定します。

```XAML
<TextBlock Text="hello world" Foreground="{ThemeResource FocusVisualWhiteStrokeThemeBrush}" VerticalAlignment="Center"/>
```

テーマ ディクショナリは、ユーザーが自分のデバイスで現在使っているテーマに合わせて変化するリソースを保持する、特殊な種類の結合されたディクショナリです。 たとえば、"light" テーマでは白いブラシが使われ、"dark" テーマでは暗い色のブラシが使われることがあります。 ブラシによって解決先のリソースが変わりますが、ブラシをリソースとして使うコントロールの構成を同じにすることができます。 独自のテンプレートとスタイルでテーマの切り替え動作を再現するには、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) をプロパティとして使って項目をメイン ディクショナリに結合する代わりに、[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) プロパティを使います。

ここで、[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内の各 [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素には [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) 値が必要です。 その値は、関連するテーマに名前を付ける文字列 (たとえば、"Default"、"Light"、"HighContrast") です。 通常、`Dictionary1` と `Dictionary2` は名前が同じだが値が異なるリソースを定義します。

ここでは、淡色テーマに赤色のテキストを使い、濃色テーマに青色のテキストを使います。

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

<!—Dictionary2.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="blue"/>

</ResourceDictionary>
```

この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の前景色を現在のテーマの値に設定します。

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.ThemeDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml" x:Key="Light"/>
                <ResourceDictionary Source="Dictionary2.xaml" x:Key="Dark"/>
            </ResourceDictionary.ThemeDictionaries>
        </ResourceDictionary>
    </Page.Resources>
    <TextBlock Foreground="{StaticResource brush}" Text="hello world" VerticalAlignment="Center"/>
</Page>
```

テーマ ディクショナリの場合、[ThemeResource マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)が参照のために使われ、システムによってテーマの変更が検出されるたびに、リソース検索に使われるアクティブなディクショナリは動的に変更されます。 システムによって実行される検索の動作は、アクティブなテーマから特定のテーマ ディクショナリの [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) へのマッピングに基づきます。

既定の XAML デザイン リソースでテーマ ディクショナリが構築される方法を調べることが役立つ場合があります。これは、Windows ランタイムでそのコントロール用に既定で使われるテンプレートと似ています。 テキスト エディターか IDE を使用して、\\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic の XAML ファイルを開きます。 テーマ ディクショナリが generic.xaml に最初に定義される方法と、各テーマ ディクショナリが同じキーを定義する方法に注意してください。 このような各キーは、テーマ ディクショナリの外部にあり後で XAML で定義されるさまざまなキー付き要素の構成要素によって参照されます。 デザイン用に別の themeresources.xaml というファイルもあり、これには既定のコントロール テンプレートではなく、テーマ リソースと追加のテンプレートだけが含まれています。 このテーマ領域は、generic.xaml に記載されているものの複製です。

XAML デザイン ツールを使ってスタイルとテンプレートのコピーを編集する際、デザイン ツールは、XAML デザイン リソース ディクショナリからセクションを抽出し、アプリとプロジェクトの一部である XAML ディクショナリ要素のローカル コピーとして配置します。

詳しい情報や、アプリで利用できるテーマ固有のリソースとシステム リソースの一覧については、「[XAML テーマ リソース](xaml-theme-resources.md)」をご覧ください。

## <a name="lookup-behavior-for-xaml-resource-references"></a>XAML リソース参照の検索の動作

*検索の動作*とは、XAML リソース システムが XAML リソースを見つける方法を指します。 検索は、キーがアプリの XAML 内のどこかから XAML リソースの参照として参照されるときに行われます。 最初に、リソース システムがスコープに基づいてリソースの存在をチェックする動作は予測可能です。 リソースが最初のスコープで見つからない場合は、スコープが広がります。 検索の動作は、XAML リソースがアプリまたはシステムで定義されている可能性のある場所とスコープで続けられます。 すべての可能なリソース検索の試みが失敗すると、多くの場合、エラーが発生します。 これらのエラーは通常、開発プロセス中に解消できます。

XAML リソース参照の検索の動作は、実際に使用が適用されるオブジェクトとその固有の [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティから開始します。 [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) が存在する場合は、その **ResourceDictionary** で、要求されたキーを持つ項目が確認されます。 通常はリソースを同じオブジェクトで定義して参照することはないため、最初のレベルの検索に意味があることはめったにありません。 実際に、通常、**Resources** プロパティはここに存在しません。 XAML リソース参照は、XAML 内のほぼ任意の位置から作成できます。[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) サブクラスのプロパティには限定されません。

検索シーケンスでは、続いてアプリのランタイム オブジェクト ツリーで次の親オブジェクトが確認されます。 [FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740) が存在し、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を保持する場合、指定したキー文字列を持つディクショナリ項目が要求されます。 リソースが見つかった場合は、検索シーケンスが停止し、参照された位置にオブジェクトが提供されます。 それ以外の場合、検索動作はオブジェクト ツリーのルートに向かって次の親レベルに進みます。 検索は、XAML のルート要素に到達し、可能性のある即時リソースの場所がすべて検索されるまで、上方向へ再帰的に継続されます。

> **注**&nbsp;&nbsp;このリソース検索動作と共に XAML マークアップ スタイルの規則も利用するために、すべての即時リソースをページのルート レベルに定義するのは一般的なやり方です。

 

要求されたリソースが即時リソースに見つからない場合、次の検索手順では [Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) プロパティが確認されます。 **Application.Resources** は、アプリのナビゲーション構造で複数のページによって参照されるアプリ固有のリソースを挿入するのに最適な場所です。

制御テンプレートは、参照の検索に別の場所 (テーマ ディクショナリ) を使うこともできます。 テーマ ディクショナリは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素をルートとして持つ単一の XAML ファイルです。 テーマ ディクショナリは、[Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) からの結合されたディクショナリである場合があります。 テーマ ディクショナリは、テンプレート化されたカスタム コントロールのコントロール固有のテーマ ディクショナリの場合もあります。

最後に、プラットフォーム リソースに対するリソース検索があります。 プラットフォーム リソースには、システム UI テーマごとに定義されたコントロール テンプレートが含まれ、これは Windows ランタイム アプリで UI に使うすべてのコントロールの既定の外観を定義します。 また、プラットフォーム リソースには、システム全体の外観とテーマに関連する名前付きリソースのセットも含まれます。 これらのリソースは技術的には [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) 項目であるため、アプリの読み込み後に XAML またはコードからの検索で使うことができます。 たとえば、システム テーマ リソースには、アプリのテキストの色とシステム ウィンドウのテキストの色 (この色はオペレーティング システムとユーザー設定に基づく) を一致させるための [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) 定義を提供する "SystemColorWindowTextColor" というリソースが含まれています。 このスタイルはアプリの他の XAML スタイルで参照することができます。また、コードでリソース検索値を取得する (そしてこの例では **Color** にキャストする) こともできます。

詳しい情報や、XAML を使う Windows ストア アプリで利用できるテーマ固有のリソースとシステム リソースの一覧については、「[XAML テーマ リソース](xaml-theme-resources.md)」をご覧ください。

要求されたキーがこれらのいずれの場所にも見つからない場合は、XAML 解析エラーまたは例外が発生します。 状況によっては、XAML 解析例外は、XAML マークアップ コンパイル動作または XAML デザイン環境では検出されないランタイム例外の場合があります。

各リソースが異なるレベルで定義されている限り、リソース ディクショナリの多層検索動作により、それぞれがキーと同じ文字列値を持つ複数のリソース項目を意図的に定義できます。 つまり、キーは特定の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 内で一意である必要がありますが、一意性の要件は検索の動作シーケンス全体には拡張されません。 検索中は、最初に正常に取得されたこのオブジェクトのみが XAML リソースの参照に使われ、検索が停止します。 アプリの XAML のさまざまな場所で同じ XAML リソースをキーを使って要求するためにこの動作を利用できますが、返されるリソースは XAML リソースの参照元のスコープと、その特定の検索がどのように動作するかによって異なります。

##  <a name="forward-references-within-a-resourcedictionary"></a>ResourceDictionary 内での前方参照


特定のリソース ディクショナリ内の XAML リソース参照では、キーで既に定義されたリソースを参照する必要があり、そのリソースは辞書的にソース参照より前に出現する必要があります。 前方参照は、XAML リソース参照によって解決できません。 そのため、XAML リソース参照を別のリソースから使う場合は、他のリソースで使われるリソースがリソース ディクショナリの先頭で定義されるように、リソース ディクショナリ構造をデザインする必要があります。

アプリ レベルで定義されたリソースは、即時リソースを参照できません。 アプリ リソースは実際には最初に (アプリが最初に起動し、ナビゲーション ページ コンテンツが読み込まれる前に) 処理されるため、これは前方参照の試行と同等です。 ただし、任意の即時リソースでアプリ リソースを参照でき、この手法が前方参照の状況の回避に役立つ場合があります。

## <a name="xaml-resources-must-be-shareable"></a>XAML リソースは共有できる必要がある


オブジェクトが [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に存在するためには、そのオブジェクトが*共有可能*である必要があります。

共有できることが必要な理由は、アプリのオブジェクト ツリーが実行時に構築されて使われるときに、オブジェクトはツリー内の複数の位置に存在できないためです。 内部では、各 XAML リソースが要求されたときに、アプリのオブジェクト グラフで使うリソース値のコピーをリソース システムが作成します。

一般に、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) と Windows ランタイム XAML では、共有の目的で次のオブジェクトがサポートされます。

-   スタイルとテンプレート ([FrameworkTemplate](https://msdn.microsoft.com/library/windows/apps/br208753) から派生したクラスと [Style](https://msdn.microsoft.com/library/windows/apps/br208849))
-   ブラシと色 ([Brush](https://msdn.microsoft.com/library/windows/apps/br228076) から派生したクラスと、[Color](https://msdn.microsoft.com/library/windows/apps/hh673723) の値)
-   [Storyboard](https://msdn.microsoft.com/library/windows/apps/br210490) などのアニメーション型
-   変換 ([GeneralTransform](https://msdn.microsoft.com/library/windows/apps/br210034) から派生したクラス)
-   [Matrix](https://msdn.microsoft.com/library/windows/apps/br210127) および [Matrix3D](https://msdn.microsoft.com/library/windows/apps/br243266)
-   [Point](https://msdn.microsoft.com/library/windows/apps/br225870) 値
-   [Thickness](https://msdn.microsoft.com/library/windows/apps/br208864) や [CornerRadius](https://msdn.microsoft.com/library/windows/apps/br242343) など、その他の特定の UI 関連構造。
-   [XAML 固有のデータ型](https://msdn.microsoft.com/library/windows/apps/mt186448)

所定の実装パターンに従えば、カスタム型を共有可能なリソースとして使うこともできます。 こうしたクラスは、バッキング コード (または含めるランタイム コンポーネント) で定義し、XAML でリソースとしてインスタンス化します。 たとえば、オブジェクト データ ソースや、データ バインディングの [IValueConverter](https://msdn.microsoft.com/library/windows/apps/br209903) 実装などです。

カスタム型には既定のコンストラクターが必要です。XAML パーサーは、そのコンストラクターを使ってクラスをインスタンス化するからです。 リソースとして使われるカスタム型は、継承により [UIElement](https://msdn.microsoft.com/library/windows/apps/br208911) クラスを持つことはできません。**UIElement** は共有できないためです (ランタイム アプリのオブジェクト グラフの特定の場所に存在する 1 つの UI 要素を表すためにのみ使われます)。

## <a name="usercontrol-usage-scope"></a>UserControl の使用のスコープ


[UserControl](https://msdn.microsoft.com/library/windows/apps/br227647) 要素には、定義のスコープと使用のスコープという固有の概念があるため、リソース検索動作について特殊な状況があります。 定義のスコープから XAML リソースを参照する **UserControl** は、固有の定義スコープ検索シーケンス内でそのリソースの検索をサポートできる必要があります。つまり、アプリ リソースにはアクセスできません。 **UserControl** の使用のスコープからは、リソース参照は (読み込まれたオブジェクト ツリー内のオブジェクトから行われる他のリソース参照と同様に) その使用ページのルートに向かう検索シーケンス内にあるものとして扱われ、アプリ リソースにアクセスできます。

## <a name="resourcedictionary-and-xamlreaderload"></a>ResourceDictionary と XamlReader.Load

[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) は、ルートとして、または [XamlReader.Load](https://msdn.microsoft.com/library/windows/apps/br228048) メソッドの XAML 入力の一部として使うことができます。 そのようなすべての参照が、読み込むために送信された XAML 内で完全に自己完結している場合、その XAML に XAML リソース参照を含めることもできます。 **XamlReader.Load** は、他の **ResourceDictionary** オブジェクトを ([Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) さえも) 認識しないコンテキストで XAML を解析します。 また、**XamlReader.Load** に送信された XAML 内から `{ThemeResource}` を使わないでください。

## <a name="using-a-resourcedictionary-from-code"></a>コードからの ResourceDictionary の使用

[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のシナリオのほとんどが、XAML のみで処理されます。 UI 定義ファイルの XAML ノード セットまたは XAML ファイルとして **ResourceDictionary** コンテナーとリソースを宣言します。 次に、XAML リソース参照を使って、XAML の他の部分からリソースを要求します。 それでも、アプリの実行中にコードを実行して **ResourceDictionary** の内容を調整するというシナリオ、または、少なくとも **ResourceDictionary** の内容を照会して、リソースが定義済みかどうか確認するというシナリオもあります。 これらのコードは **ResourceDictionary** インスタンスで呼び出されるため、最初に [FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740) を取得することでオブジェクト ツリー内のどこかにある即時 **ResourceDictionary** を取得するか、`Application.Current.Resources` を取得する必要があります。

C\# または Microsoft Visual Basic コードでは、インデクサー ([Item](https://msdn.microsoft.com/library/windows/apps/jj603134)) を使って所定の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 内のリソースを参照できます。 **ResourceDictionary** は、文字列キーを持つディクショナリであるため、インデクサーは整数インデックスではなく文字列キーを使います。 Visual C++ コンポーネント拡張機能 (C++/CX) コードでは、[Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) を使います。

コードを使って [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を調査または変更するときは、[Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) や [Item](https://msdn.microsoft.com/library/windows/apps/jj603134) などの API の動作で、即時リソースからアプリ リソースまで走査することはありません。XAML ページを読み込むときにのみ実行される XAML パーサーの動作とは異なります。 実行時、キーのスコープはその時点で使っている **ResourceDictionary** インスタンスに対して自己完結しています。 ただし、そのスコープは [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) まで広がりません。

また、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に存在しないキーを要求した場合、エラーにならないことがあります。単純に戻り値に **null** が返されます。 ただし、返された **null** を値として使おうとすると、エラーになることがあります。 エラーの原因として考えられるのは、**ResourceDictionary** の呼び出しではなく、プロパティの setter です。 エラーにならないのは、プロパティが有効な値として **null** を受け取る場合だけです。 この動作は、XAML 解析時の XAML 検索の動作とは対照的です。解析時に XAML から渡されたキーを解決できない場合、プロパティが **null** を受け付ける場合でも XAML 解析エラーが発生します。

結合されたリソース ディクショナリは、実行時に結合されたディクショナリを参照するプライマリ リソース ディクショナリのインデックス スコープに含まれます。 つまり、プライマリ ディクショナリの **Item** または [Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) を使って、結合されたディクショナリに実際に定義されているオブジェクトを検索できます。 この場合、検索の動作は解析時の XAML 検索の動作に似ています。結合されたディクショナリに同じキーを持つオブジェクトが複数ある場合は、最後に追加されたディクショナリのオブジェクトが返されます。

**Add** (C\# または Visual Basic) または [Insert](https://msdn.microsoft.com/library/windows/apps/br208799) (C++/CX) を呼び出すことで、既にある [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に項目を追加できます。 即時リソースまたはアプリ リソースに項目を追加できます。 これらの API 呼び出しはどちらもキーを必要とします。これにより、**ResourceDictionary** の各項目にキーが必要という要件が満たされます。 ただし、実行時に **ResourceDictionary** に追加した項目は、XAML リソース参照に関係しません。 XAML リソース参照に必要な検索は、アプリの読み込み時にその XAML が最初に解析されるとき (またはテーマの変更が検出されたとき) に実行されます。 実行時にコレクションに追加されるリソースはその時点では使用できず、**ResourceDictionary** を変更しても、そこから取得済みのリソースは無効にはなりません。そのリソースの値を変更した場合でも同じです。

実行時に [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) から項目を削除したり、一部またはすべての項目のコピーを作るなどの操作も実行できます。 **ResourceDictionary** に対して一覧表示されるメンバーは、利用できる API を示します。 **ResourceDictionary** には基になるコレクション インターフェイスをサポートするプロジェクションされた API があるため、API オプションは、C\# または Visual Basic と C++/CX のどちらを使っているかによって異なります。

## <a name="resourcedictionary-and-localization"></a>ResourceDictionary とローカライズ


最初に XAML [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) には、ローカライズが必要な文字列が含まれていることがあります。 その場合は、これらの文字列を **ResourceDictionary** にではなくプロジェクト リソースとして保存します。 XAML から文字列を取り出し、所有する要素に [x:Uid ディレクティブ](https://msdn.microsoft.com/library/windows/apps/mt204791)値を与えます。 次に、リソース ファイルにリソースを定義します。 *XUIDValue*.*PropertyName* の形式のリソース名と、ローカライズが必要な文字列のリソース値を提供します。

## <a name="custom-resource-lookup"></a>カスタム リソース検索

高度なシナリオとして、このトピックで説明した XAML リソース参照の検索の動作とは異なる動作を持つクラスを実装できます。 そのためには、[CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327) クラスを実装します。すると、[StaticResource](../xaml-platform/staticresource-markup-extension.md) または [ThemeResource](../xaml-platform/themeresource-markup-extension.md) を使う代わりにリソース参照に [CustomResource markup extension](https://msdn.microsoft.com/library/windows/apps/mt185580) を使って、この動作にアクセスできるようになります。 ほとんどのアプリにこれを必要とするシナリオはありません。 詳しくは、「[CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327)」をご覧ください。

 
## <a name="related-topics"></a>関連トピック

* [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794)
* [XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)
* [StaticResource マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)
* [ThemeResource マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)
* [XAML テーマ リソース](xaml-theme-resources.md)
* [コントロールのスタイル](styling-controls.md)
* [x:Key 属性](https://msdn.microsoft.com/library/windows/apps/mt204787)

 

 



