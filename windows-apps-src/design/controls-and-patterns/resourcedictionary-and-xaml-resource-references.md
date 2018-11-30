---
Description: Explains how to define a ResourceDictionary element and keyed resources, and how XAML resources relate to other resources that you define as part of your app or app package.
MS-HAID: dev\_ctrl\_layout\_txt.resourcedictionary\_and\_xaml\_resource\_references
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: ResourceDictionary と XAML リソースの参照
ms.assetid: E3CBFA3D-6AF5-44E1-B9F9-C3D3EA8A25CE
label: ResourceDictionary and XAML resource references
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 51461df47fe92c296fee198a6f2ed1c34e833cd7
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8210997"
---
# <a name="resourcedictionary-and-xaml-resource-references"></a><span data-ttu-id="91b4c-103">ResourceDictionary と XAML リソースの参照</span><span class="sxs-lookup"><span data-stu-id="91b4c-103">ResourceDictionary and XAML resource references</span></span>

 

<span data-ttu-id="91b4c-104">XAML を使ってアプリの UI やリソースを定義できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-104">You can define the UI or resources for your app using XAML.</span></span> <span data-ttu-id="91b4c-105">リソースとは、通常、複数回使うことが予定されたオブジェクトの定義です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-105">Resources are typically definitions of some object that you expect to use more than once.</span></span> <span data-ttu-id="91b4c-106">後で XAML リソースを参照するために、名前のような働きをするリソースのキーを指定します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-106">To refer to a XAML resource later, you specify a key for a resource that acts like its name.</span></span> <span data-ttu-id="91b4c-107">リソースは、アプリのどこからでも参照でき、アプリ内の任意の XAML ページからも参照できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-107">You can reference a resource throughout an app or from any XAML page within it.</span></span> <span data-ttu-id="91b4c-108">Windows ランタイム XAML の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素を使って、リソースを定義できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-108">You can define your resources using a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) element from the Windows Runtime XAML.</span></span> <span data-ttu-id="91b4c-109">リソースを定義すると、[StaticResource マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)または [ThemeResource マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使ってリソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-109">Then, you can reference your resources by using a [StaticResource markup extension](../../xaml-platform/staticresource-markup-extension.md) or [ThemeResource markup extension](../../xaml-platform/themeresource-markup-extension.md).</span></span>

<span data-ttu-id="91b4c-110">XAML リソースとして宣言することが多い XAML 要素としては、[Style](https://msdn.microsoft.com/library/windows/apps/br208849)、[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)、アニメーション コンポーネント、および [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) サブクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-110">The XAML elements you might want to declare most often as XAML resources include [Style](https://msdn.microsoft.com/library/windows/apps/br208849), [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391), animation components, and [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) subclasses.</span></span> <span data-ttu-id="91b4c-111">ここでは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) とキーを持つリソースを定義する方法と、アプリまたはアプリ パッケージの一部として定義する他のリソースと XAML リソースの関連について説明します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-111">Here, we explain how to define a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) and keyed resources, and how XAML resources relate to other resources that you define as part of your app or app package.</span></span> <span data-ttu-id="91b4c-112">また、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) や [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) などのリソース ディクショナリの高度な機能についても説明します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-112">We also explain resource dictionary advanced features such as [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) and [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span>

**<span data-ttu-id="91b4c-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="91b4c-113">Prerequisites</span></span>**

<span data-ttu-id="91b4c-114">XAML マークアップについて理解し、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)」を読んでいることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="91b4c-114">We assume that you understand XAML markup and have read the [XAML overview](https://msdn.microsoft.com/library/windows/apps/mt185595).</span></span>

## <a name="define-and-use-xaml-resources"></a><span data-ttu-id="91b4c-115">XAML リソースを定義して使う</span><span class="sxs-lookup"><span data-stu-id="91b4c-115">Define and use XAML resources</span></span>

<span data-ttu-id="91b4c-116">XAML リソースは、マークアップから 2 回以上参照されるオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-116">XAML resources are objects that are referenced from markup more than once.</span></span> <span data-ttu-id="91b4c-117">リソースは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されます。通常は、別個のファイルで、または次のようにマークアップ ページの上部で定義されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-117">Resources are defined in a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), typically in a separate file or at the top of the markup page, like this.</span></span>

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

<span data-ttu-id="91b4c-118">この例では、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-118">In this example:</span></span>

-   `<Page.Resources>…</Page.Resources>` <span data-ttu-id="91b4c-119">- リソース ディクショナリを定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-119">- Defines the resource dictionary.</span></span>
-   `<x:String>` <span data-ttu-id="91b4c-120">- キー "greeting" を持つリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-120">- Defines the resource with the key "greeting".</span></span>
-   `{StaticResource greeting}` <span data-ttu-id="91b4c-121">- [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の [Text](https://msdn.microsoft.com/library/windows/apps/br209676)  プロパティに割り当てられた、キー "greeting" を持つリソースを検索します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-121">- Looks up the resource with the key "greeting", which is assigned to the [Text](https://msdn.microsoft.com/library/windows/apps/br209676) property of the [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652).</span></span>

> <span data-ttu-id="91b4c-122">**注**&nbsp;&nbsp; [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に関連する概念を、**リソース** ビルド アクション、リソース (.resw) ファイル、またはアプリ パッケージを生成するコード プロジェクトの構築のコンテキストで説明されるその他の "リソース" と混同しないでください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-122">**Note**&nbsp;&nbsp;Don't confuse the concepts related to [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) with the **Resource** build action, resource (.resw) files, or other "resources" that are discussed in the context of structuring the code project that produces your app package.</span></span>

<span data-ttu-id="91b4c-123">リソースを文字列にする必要はありません。スタイル、テンプレート、ブラシ、色など、任意の共有可能なオブジェクトにすることができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-123">Resources don't have to be strings; they can be any shareable object, such as styles, templates, brushes, and colors.</span></span> <span data-ttu-id="91b4c-124">ただし、コントロール、図形、および他の [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) は共有可能ではないため、再利用可能なリソースとして宣言することはできません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-124">However, controls, shapes, and other [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706)s are not shareable, so they can't be declared as reusable resources.</span></span> <span data-ttu-id="91b4c-125">共有について詳しくは、このトピックの後方の「[XAML リソースは共有できる必要がある](#xaml-resources-must-be-shareable)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-125">For more info about sharing, see the [XAML resources must be shareable](#xaml-resources-must-be-shareable) section later in this topic.</span></span>

<span data-ttu-id="91b4c-126">ここでは、ブラシと文字列の両方がリソースとして宣言されており、ページでコントロールにより使用されています。</span><span class="sxs-lookup"><span data-stu-id="91b4c-126">Here, both a brush and a string are declared as resources and used by controls in a page.</span></span>

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

<span data-ttu-id="91b4c-127">すべてのリソースにはキーが必要です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-127">All resources need to have a key.</span></span> <span data-ttu-id="91b4c-128">通常、そのキーは `x:Key=”myString”` を使って定義された文字列です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-128">Usually that key is a string defined with `x:Key=”myString”`.</span></span> <span data-ttu-id="91b4c-129">ただし、キーを指定する方法は他にもいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-129">However, there are a few other ways to specify a key:</span></span>

-   <span data-ttu-id="91b4c-130">[Style](https://msdn.microsoft.com/library/windows/apps/br208849) と [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) には **TargetType** が必要であり、[x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) が指定されていない場合は **TargetType** をキーとして使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-130">[Style](https://msdn.microsoft.com/library/windows/apps/br208849) and [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) require a **TargetType**, and will use the **TargetType** as the key if [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) is not specified.</span></span> <span data-ttu-id="91b4c-131">この場合、キーは文字列ではなく実際の Type オブジェクトです </span><span class="sxs-lookup"><span data-stu-id="91b4c-131">In this case, the key is the actual Type object, not a string.</span></span> <span data-ttu-id="91b4c-132">(以下の例をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="91b4c-132">(See examples below)</span></span>
-   <span data-ttu-id="91b4c-133">[x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) が指定されていない場合、**TargetType** を持つ [DataTemplate](https://msdn.microsoft.com/library/windows/apps/br242348) リソースはキーとして **TargetType** を使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-133">[DataTemplate](https://msdn.microsoft.com/library/windows/apps/br242348) resources that have a **TargetType** will use the **TargetType** as the key if [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) is not specified.</span></span> <span data-ttu-id="91b4c-134">この場合、キーは文字列ではなく実際の Type オブジェクトです </span><span class="sxs-lookup"><span data-stu-id="91b4c-134">In this case, the key is the actual Type object, not a string.</span></span>
-   <span data-ttu-id="91b4c-135">[x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788) は [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) の代わりに使うことができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-135">[x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788) can be used instead of [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787).</span></span> <span data-ttu-id="91b4c-136">ただし、x:Name はリソースのコード ビハインド フィールドも生成します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-136">However, x:Name also generates a code behind field for the resource.</span></span> <span data-ttu-id="91b4c-137">この結果、ページの読み込み時にそのフィールドを初期化する必要があるため、x:Name は x:Key よりも効率が低下します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-137">As a result, x:Name is less efficient than x:Key because that field needs to be initialized when the page is loaded.</span></span>

<span data-ttu-id="91b4c-138">[StaticResource マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)は、文字列名 ([x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) または [x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788)) を使ってのみリソースを取得できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-138">The [StaticResource markup extension](../../xaml-platform/staticresource-markup-extension.md) can retrieve resources only with a string name ([x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) or [x:Name](https://msdn.microsoft.com/library/windows/apps/mt204788)).</span></span> <span data-ttu-id="91b4c-139">ただし、[Style](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティと [ContentTemplate](https://msdn.microsoft.com/library/windows/apps/br209369) プロパティまたは [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/br242830) プロパティを設定していないコントロールに使うスタイルとテンプレートを決定する際に、XAML フレームワークは暗黙的なスタイル リソース (x:Key または x:Name ではなく **TargetType** を使うリソース) も探します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-139">However, the XAML framework also looks for implicit style resources (those which use **TargetType** rather than x:Key or x:Name) when it decides which style & template to use for a control that hasn't set the [Style](https://msdn.microsoft.com/library/windows/apps/br208743) and [ContentTemplate](https://msdn.microsoft.com/library/windows/apps/br209369) or [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/br242830) properties.</span></span>

<span data-ttu-id="91b4c-140">ここでは、[Style](https://msdn.microsoft.com/library/windows/apps/br208849) に **typeof(Button)** の暗黙的なキーがあります。また、ページの下部にある [Button](https://msdn.microsoft.com/library/windows/apps/br209265) は [Style](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティを指定しないため、キー **typeof(Button)** を持つスタイルを探します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-140">Here, the [Style](https://msdn.microsoft.com/library/windows/apps/br208849) has an implicit key of **typeof(Button)**, and since the [Button](https://msdn.microsoft.com/library/windows/apps/br209265) at the bottom of the page doesn't specify a [Style](https://msdn.microsoft.com/library/windows/apps/br208743) property, it looks for a style with key of **typeof(Button)**:</span></span>

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <Style TargetType="Button">
            <Setter Property="Background" Value="Red"/>
        </Style>
    </Page.Resources>
    <Grid>
       <!-- This button will have a red background. -->
       <Button Content="Button" Height="100" VerticalAlignment="Center" Width="100"/>
    </Grid>
</Page>
```

<span data-ttu-id="91b4c-141">暗黙的なスタイルとそのしくみについて詳しくは、「[コントロールのスタイル](xaml-styles.md)」と「[コントロール テンプレート](control-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-141">For more info about implicit styles and how they work, see [Styling controls](xaml-styles.md) and [Control templates](control-templates.md).</span></span>

## <a name="look-up-resources-in-code"></a><span data-ttu-id="91b4c-142">コード内のリソースを検索する</span><span class="sxs-lookup"><span data-stu-id="91b4c-142">Look up resources in code</span></span>

<span data-ttu-id="91b4c-143">その他のディクショナリなどのリソース ディクショナリのメンバーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="91b4c-143">You access members of the resource dictionary like any other dictionary.</span></span>

> [!WARNING]
> <span data-ttu-id="91b4c-144">コード内のリソースだけでリソース検索を実行すると、`Page.Resources`のディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-144">When you perform a resource lookup in code, only the resources in the `Page.Resources` dictionary are looked at.</span></span> <span data-ttu-id="91b4c-145">[StaticResource マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)とは異なり、最初のディクショナリでリソースが見つからない場合に、コードは `Application.Resources` ディクショナリにフォールバックしません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-145">Unlike the [StaticResource markup extension](../../xaml-platform/staticresource-markup-extension.md), the code doesn't fall back to the `Application.Resources` dictionary if the resources aren’t found in the first dictionary.</span></span>

 

<span data-ttu-id="91b4c-146">この例では、ページのリソース ディクショナリから `redButtonStyle` リソースを取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-146">This example shows how to retrieve the `redButtonStyle` resource out of a page’s resource dictionary:</span></span>

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

<span data-ttu-id="91b4c-147">コードからアプリ全体のリソースを検索するには、ここに示すように **Application.Current.Resources** を使ってアプリのリソース ディクショナリを取得します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-147">To look up app-wide resources from code, use **Application.Current.Resources** to get the app's resource dictionary, as shown here.</span></span>

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

<span data-ttu-id="91b4c-148">コードにアプリケーション リソースを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-148">You can also add an application resource in code.</span></span>

<span data-ttu-id="91b4c-149">この操作を実行する際に留意すべき点が 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-149">There are two things to keep in mind when doing this.</span></span>

-   <span data-ttu-id="91b4c-150">まず、ページがリソースを使おうとする前にリソースを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-150">First, you need to add the resources before any page tries to use the resource.</span></span>
-   <span data-ttu-id="91b4c-151">次に、アプリのコンストラクターにリソースを追加することはできません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-151">Second, you can’t add resources in the App’s constructor.</span></span>

<span data-ttu-id="91b4c-152">これと同様に、[Application.OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドにリソースを追加した場合、両方の問題を回避することができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-152">You can avoid both problems if you add the resource in the [Application.OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335) method, like this.</span></span>

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

## <a name="every-frameworkelement-can-have-a-resourcedictionary"></a><span data-ttu-id="91b4c-153">各 FrameworkElement に ResourceDictionary を追加できる</span><span class="sxs-lookup"><span data-stu-id="91b4c-153">Every FrameworkElement can have a ResourceDictionary</span></span>

<span data-ttu-id="91b4c-154">[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) は、コントロールの継承元の基底クラスであり、[Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-154">[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) is a base class that controls inherit from, and it has a [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) property.</span></span> <span data-ttu-id="91b4c-155">そのため、任意の **FrameworkElement** にローカル リソース ディクショナリを追加できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-155">So, you can add a local resource dictionary to any **FrameworkElement**.</span></span>

<span data-ttu-id="91b4c-156">ここでは、[Page](https://msdn.microsoft.com/library/windows/apps/br227503) と [Border](https://msdn.microsoft.com/library/windows/apps/br209250) の両方にリソース ディクショナリがあり、どちらにも "greeting" というリソースがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-156">Here, both the [Page](https://msdn.microsoft.com/library/windows/apps/br227503) and the [Border](https://msdn.microsoft.com/library/windows/apps/br209250) have resource dictionaries, and they both have a resource called "greeting".</span></span> <span data-ttu-id="91b4c-157">'TextBlock2' という名前の[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)は、**境界線**内でそのリソース検索はまず、**境界線**のリソースし、**ページ**のリソース、および[アプリケーション](https://msdn.microsoft.com/library/windows/apps/br242324)リソース。</span><span class="sxs-lookup"><span data-stu-id="91b4c-157">The [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) named 'textBlock2' is inside the **Border**, so its resource lookup looks first to the **Border**’s resources, then the **Page**’s resources, and then the [Application](https://msdn.microsoft.com/library/windows/apps/br242324) resources.</span></span> <span data-ttu-id="91b4c-158">**TextBlock** には、"Hola mundo" と表示されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-158">The **TextBlock** will read "Hola mundo".</span></span>

<span data-ttu-id="91b4c-159">コードからその要素のリソースにアクセスするには、その要素の [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-159">To access that element’s resources from code, use that element’s [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) property.</span></span> <span data-ttu-id="91b4c-160">XAML ではなくコード内の [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) のリソースにアクセスすると、親要素のディクショナリではなくそのディクショナリのみ検索されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-160">Accessing a [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706)’s resources in code, rather than XAML, will look only in that dictionary, not in parent element’s dictionaries.</span></span>

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>
    
    <StackPanel>
        <!-- Displays "Hello world" -->
        <TextBlock x:Name="textBlock1" Text="{StaticResource greeting}"/>

        <Border x:Name="border">
            <Border.Resources>
                <x:String x:Key="greeting">Hola mundo</x:String>
            </Border.Resources>
            <!-- Displays "Hola mundo" -->
            <TextBlock x:Name="textBlock2" Text="{StaticResource greeting}"/>
        </Border>

        <!-- Displays "Hola mundo", set in code. -->
        <TextBlock x:Name="textBlock3"/>
    </StackPanel>
</Page>

```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            textBlock3.Text = (string)border.Resources["greeting"];
        }
    }
```

## <a name="merged-resource-dictionaries"></a><span data-ttu-id="91b4c-161">結合されたリソース ディクショナリ</span><span class="sxs-lookup"><span data-stu-id="91b4c-161">Merged resource dictionaries</span></span>

<span data-ttu-id="91b4c-162">*結合されたリソース ディクショナリ*は、あるリソース ディクショナリを別のディクショナリ (通常は別のファイルのディクショナリ) に結合します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-162">A *merged resource dictionary* combines one resource dictionary into another, usually in another file.</span></span>

> <span data-ttu-id="91b4c-163">**ヒント**&nbsp;&nbsp;Microsoft Visual Studio でリソース ディクショナリ ファイルを作成するには、**[プロジェクト]** メニューの **[追加] &gt; [新しい項目] &gt; [リソース ディクショナリ] オプション** を使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-163">**Tip**&nbsp;&nbsp;You can create a resource dictionary file in Microsoft Visual Studio by using the **Add &gt; New Item… &gt; Resource Dictionary** option from the **Project** menu.</span></span>

<span data-ttu-id="91b4c-164">ここでは、Dictionary1.xaml という別の XAML ファイルでリソース ディクショナリを定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-164">Here, you define a resource dictionary in a separate XAML file called Dictionary1.xaml.</span></span>

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

```

<span data-ttu-id="91b4c-165">そのディクショナリを使うには、ページのディクショナリと結合します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-165">To use that dictionary, you merge it with your page’s dictionary:</span></span>

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

<span data-ttu-id="91b4c-166">この例の動作を次に示します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-166">Here's what happens in this example.</span></span> <span data-ttu-id="91b4c-167">`<Page.Resources>` で、`<ResourceDictionary>` を宣言します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-167">In `<Page.Resources>`, you declare `<ResourceDictionary>`.</span></span> <span data-ttu-id="91b4c-168">リソースを `<Page.Resources>` に追加すると、XAML フレームワークによりリソース ディクショナリが暗黙的に自動作成されますが、この場合に必要なのは通常のリソース ディクショナリではなく、結合されたディクショナリを含むリソース ディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-168">The XAML framework implicitly creates a resource dictionary for you when you add resources to `<Page.Resources>`; however, in this case, you don’t want just any resource dictionary, you want one that contains merged dictionaries.</span></span>

<span data-ttu-id="91b4c-169">そのため、`<ResourceDictionary>` を宣言し、`<ResourceDictionary.MergedDictionaries>` コレクションに内容を追加します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-169">So you declare `<ResourceDictionary>`, then add things to its `<ResourceDictionary.MergedDictionaries>` collection.</span></span> <span data-ttu-id="91b4c-170">これらの各エントリは、`<ResourceDictionary Source="Dictionary1.xaml"/>` の形式を使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-170">Each of those entries takes the form `<ResourceDictionary Source="Dictionary1.xaml"/>`.</span></span> <span data-ttu-id="91b4c-171">複数のディクショナリを追加するには、最初のエントリの後に `<ResourceDictionary Source="Dictionary2.xaml"/>` エントリを追加するだけです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-171">To add more than one dictionary, just add a `<ResourceDictionary Source="Dictionary2.xaml"/>` entry after the first entry.</span></span>

<span data-ttu-id="91b4c-172">`<ResourceDictionary.MergedDictionaries>…</ResourceDictionary.MergedDictionaries>` の後、オプションで追加のリソースをメイン ディクショナリに配置できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-172">After `<ResourceDictionary.MergedDictionaries>…</ResourceDictionary.MergedDictionaries>`, you can optionally put additional resources in your main dictionary.</span></span> <span data-ttu-id="91b4c-173">結合されたディクショナリのリソースは、通常のディクショナリと同様に使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-173">You use resources from a merged to dictionary just like a regular dictionary.</span></span> <span data-ttu-id="91b4c-174">上の例では、`{StaticResource brush}` は子ディクショナリと結合されたディクショナリ (Dictionary1.xaml) でリソースを検索しますが、`{StaticResource greeting}` はメイン ページ ディクショナリでそのリソースを参照します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-174">In the example above, `{StaticResource brush}` finds the resource in the child/merged dictionary (Dictionary1.xaml), while `{StaticResource greeting}` finds its resource in the main page dictionary.</span></span>

<span data-ttu-id="91b4c-175">リソース検索シーケンスでは、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ディクショナリはその [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のキーを持つその他すべてのリソースがチェックされた後にのみチェックされます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-175">In the resource-lookup sequence, a [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) dictionary is checked only after a check of all the other keyed resources of that [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span> <span data-ttu-id="91b4c-176">そのレベルが検索され、結合されたディクショナリに到達すると、**MergedDictionaries** 内の各項目がチェックされます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-176">After searching that level, the lookup reaches the merged dictionaries, and each item in **MergedDictionaries** is checked.</span></span> <span data-ttu-id="91b4c-177">結合されたディクショナリが複数存在する場合、これらのディクショナリは **MergedDictionaries** プロパティで宣言された順序と反対の順序で確認されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-177">If multiple merged dictionaries exist, these dictionaries are checked in the inverse of the order in which they are declared in the **MergedDictionaries** property.</span></span> <span data-ttu-id="91b4c-178">次の例では、Dictionary2.xaml と Dictionary1.xaml の両方が同じキーを宣言した場合、Dictionary2.xaml のキーが最初に使われます。これが **MergedDictionaries** セット内の最後のキーであるためです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-178">In the following example, if both Dictionary2.xaml and Dictionary1.xaml declared the same key, the key from Dictionary2.xaml is used first because it's last in the **MergedDictionaries** set.</span></span>

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

<span data-ttu-id="91b4c-179">いずれかの [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のスコープ内で、ディクショナリのキーの一意性がチェックされます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-179">Within the scope of any one [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), the dictionary is checked for key uniqueness.</span></span> <span data-ttu-id="91b4c-180">ただし、そのスコープは異なる [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ファイル内の異なる項目間に拡張されません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-180">However, that scope does not extend across different items in different [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) files.</span></span>

<span data-ttu-id="91b4c-181">検索シーケンスと、一意のキーが結合されたディクショナリ スコープを越えては適用されないことを組み合わせて使って、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) リソースのフォールバック値の順序を作成できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-181">You can use the combination of the lookup sequence and lack of unique key enforcement across merged-dictionary scopes to create a fallback value sequence of [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) resources.</span></span> <span data-ttu-id="91b4c-182">たとえば、アプリの状態とユーザー設定データに同期されるリソース ディクショナリを使って、シーケンス内で最後に結合されたリソース ディクショナリに特定のブラシ色のユーザー設定を保存できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-182">For example, you might store user preferences for a particular brush color in the last merged resource dictionary in the sequence, using a resource dictionary that synchronizes to your app's state and user preference data.</span></span> <span data-ttu-id="91b4c-183">ただし、ユーザー設定がまだ存在しない場合は、最初の [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) ファイルで **ResourceDictionary** リソースに同じキー文字列を定義し、それをフォールバック値として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-183">However, if no user preferences exist yet, you can define that same key string for a **ResourceDictionary** resource in the initial [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) file, and it can serve as the fallback value.</span></span> <span data-ttu-id="91b4c-184">プライマリ リソース ディクショナリで提供する値は、常に結合されたディクショナリがチェックされる前にチェックされるため、フォールバック手法を使う場合は、プライマリ リソース ディクショナリにそのリソースを定義しないでください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-184">Remember that any value you provide in a primary resource dictionary is always checked before the merged dictionaries are checked, so if you want to use the fallback technique, don't define that resource in a primary resource dictionary.</span></span>

## <a name="theme-resources-and-theme-dictionaries"></a><span data-ttu-id="91b4c-185">テーマ リソースとテーマ ディクショナリ</span><span class="sxs-lookup"><span data-stu-id="91b4c-185">Theme resources and theme dictionaries</span></span>

<span data-ttu-id="91b4c-186">[ThemeResource](../../xaml-platform/themeresource-markup-extension.md) は [StaticResource](../../xaml-platform/staticresource-markup-extension.md) と似ていますが、テーマが変更されるとリソース検索が再評価されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-186">A [ThemeResource](../../xaml-platform/themeresource-markup-extension.md) is similar to a [StaticResource](../../xaml-platform/staticresource-markup-extension.md), but the resource lookup is reevaluated when the theme changes.</span></span>

<span data-ttu-id="91b4c-187">この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の前景色を現在のテーマの値に設定します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-187">In this example, you set the foreground of a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) to a value from the current theme.</span></span>

```XAML
<TextBlock Text="hello world" Foreground="{ThemeResource FocusVisualWhiteStrokeThemeBrush}" VerticalAlignment="Center"/>
```

<span data-ttu-id="91b4c-188">テーマ ディクショナリは、ユーザーが自分のデバイスで現在使っているテーマに合わせて変化するリソースを保持する、特殊な種類の結合されたディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-188">A theme dictionary is a special type of merged dictionary that holds the resources that vary with the theme a user is currently using on his or her device.</span></span> <span data-ttu-id="91b4c-189">たとえば、"light" テーマでは白いブラシが使われ、"dark" テーマでは暗い色のブラシが使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-189">For example, the "light" theme might use a white color brush whereas the "dark" theme might use a dark color brush.</span></span> <span data-ttu-id="91b4c-190">ブラシによって解決先のリソースが変わりますが、ブラシをリソースとして使うコントロールの構成を同じにすることができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-190">The brush changes the resource that it resolves to, but otherwise the composition of a control that uses the brush as a resource could be the same.</span></span> <span data-ttu-id="91b4c-191">独自のテンプレートとスタイルでテーマの切り替え動作を再現するには、[MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) をプロパティとして使って項目をメイン ディクショナリに結合する代わりに、[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-191">To reproduce the theme-switching behavior in your own templates and styles, instead of using [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) as the property to merge items into the main dictionaries, use the [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) property.</span></span>

<span data-ttu-id="91b4c-192">ここで、[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内の各 [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素には [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) 値が必要です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-192">Each [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) element within [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) must have an [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) value.</span></span> <span data-ttu-id="91b4c-193">その値は、関連するテーマに名前を付ける文字列 (たとえば、"Default"、"Light"、"HighContrast") です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-193">The value is a string that names the relevant theme—for example, "Default", "Dark", "Light", or "HighContrast".</span></span> <span data-ttu-id="91b4c-194">通常、`Dictionary1` と `Dictionary2` は名前が同じだが値が異なるリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-194">Typically, `Dictionary1` and `Dictionary2` will define resources that have the same names but different values.</span></span>

<span data-ttu-id="91b4c-195">ここでは、淡色テーマに赤色のテキストを使い、濃色テーマに青色のテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-195">Here, you use red text for the light theme and blue text for the dark theme.</span></span>

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

<!-- Dictionary2.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="blue"/>

</ResourceDictionary>
```

<span data-ttu-id="91b4c-196">この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) の前景色を現在のテーマの値に設定します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-196">In this example, you set the foreground of a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) to a value from the current theme.</span></span>

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

<span data-ttu-id="91b4c-197">テーマ ディクショナリの場合、[ThemeResource マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)が参照のために使われ、システムによってテーマの変更が検出されるたびに、リソース検索に使われるアクティブなディクショナリは動的に変更されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-197">For theme dictionaries, the active dictionary to be used for resource lookup changes dynamically, whenever [ThemeResource markup extension](../../xaml-platform/themeresource-markup-extension.md) is used to make the reference and the system detects a theme change.</span></span> <span data-ttu-id="91b4c-198">システムによって実行される検索の動作は、アクティブなテーマから特定のテーマ ディクショナリの [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) へのマッピングに基づきます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-198">The lookup behavior that is done by the system is based on mapping the active theme to the [x:Key](https://msdn.microsoft.com/library/windows/apps/mt204787) of a specific theme dictionary.</span></span>

<span data-ttu-id="91b4c-199">既定の XAML デザイン リソースでテーマ ディクショナリが構築される方法を調べることが役立つ場合があります。これは、Windows ランタイムでそのコントロール用に既定で使われるテンプレートと似ています。</span><span class="sxs-lookup"><span data-stu-id="91b4c-199">It can be useful to examine the way that the theme dictionaries are structured in the default XAML design resources, which parallel the templates that the Windows Runtime uses by default for its controls.</span></span> <span data-ttu-id="91b4c-200">テキスト エディターか IDE を使用して、\\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic の XAML ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-200">Open the XAML files in \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic using a text editor or your IDE.</span></span> <span data-ttu-id="91b4c-201">テーマ ディクショナリが generic.xaml に最初に定義される方法と、各テーマ ディクショナリが同じキーを定義する方法に注意してください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-201">Note how the theme dictionaries are defined first in generic.xaml, and how each theme dictionary defines the same keys.</span></span> <span data-ttu-id="91b4c-202">このような各キーは、テーマ ディクショナリの外部にあり後で XAML で定義されるさまざまなキー付き要素の構成要素によって参照されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-202">Each such key is then referenced by elements of composition in the various keyed elements that are outside the theme dictionaries and defined later in the XAML.</span></span> <span data-ttu-id="91b4c-203">デザイン用に別の themeresources.xaml というファイルもあり、これには既定のコントロール テンプレートではなく、テーマ リソースと追加のテンプレートだけが含まれています。</span><span class="sxs-lookup"><span data-stu-id="91b4c-203">There's also a separate themeresources.xaml file for design that contains only the theme resources and extra templates, not the default control templates.</span></span> <span data-ttu-id="91b4c-204">このテーマ領域は、generic.xaml に記載されているものの複製です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-204">The theme areas are duplicates of what you'd see in generic.xaml.</span></span>

<span data-ttu-id="91b4c-205">XAML デザイン ツールを使ってスタイルとテンプレートのコピーを編集する際、デザイン ツールは、XAML デザイン リソース ディクショナリからセクションを抽出し、アプリとプロジェクトの一部である XAML ディクショナリ要素のローカル コピーとして配置します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-205">When you use XAML design tools to edit copies of styles and templates, the design tools extract sections from the XAML design resource dictionaries and place them as local copies of XAML dictionary elements that are part of your app and project.</span></span>

<span data-ttu-id="91b4c-206">詳しい情報や、アプリで利用できるテーマ固有のリソースとシステム リソースの一覧については、「[XAML テーマ リソース](xaml-theme-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-206">For more info and for a list of the theme-specific and system resources that are available to your app, see [XAML theme resources](xaml-theme-resources.md).</span></span>

## <a name="lookup-behavior-for-xaml-resource-references"></a><span data-ttu-id="91b4c-207">XAML リソース参照の検索の動作</span><span class="sxs-lookup"><span data-stu-id="91b4c-207">Lookup behavior for XAML resource references</span></span>

<span data-ttu-id="91b4c-208">*検索の動作*とは、XAML リソース システムが XAML リソースを見つける方法を指します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-208">*Lookup behavior* is the term that describes how the XAML resources system tries to find a XAML resource.</span></span> <span data-ttu-id="91b4c-209">検索は、キーがアプリの XAML 内のどこかから XAML リソースの参照として参照されるときに行われます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-209">The lookup occurs when a key is referenced as a XAML resource reference from somewhere in the app's XAML.</span></span> <span data-ttu-id="91b4c-210">最初に、リソース システムがスコープに基づいてリソースの存在をチェックする動作は予測可能です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-210">First, the resources system has predictable behavior for where it will check for the existence of a resource based on scope.</span></span> <span data-ttu-id="91b4c-211">リソースが最初のスコープで見つからない場合は、スコープが広がります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-211">If a resource isn't found in the initial scope, the scope expands.</span></span> <span data-ttu-id="91b4c-212">検索の動作は、XAML リソースがアプリまたはシステムで定義されている可能性のある場所とスコープで続けられます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-212">The lookup behavior continues on throughout the locations and scopes that a XAML resource could possibly be defined by an app or by the system.</span></span> <span data-ttu-id="91b4c-213">すべての可能なリソース検索の試みが失敗すると、多くの場合、エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-213">If all possible resource lookup attempts fail, an error often results.</span></span> <span data-ttu-id="91b4c-214">これらのエラーは通常、開発プロセス中に解消できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-214">It's usually possible to eliminate these errors during the development process.</span></span>

<span data-ttu-id="91b4c-215">XAML リソース参照の検索の動作は、実際に使用が適用されるオブジェクトとその固有の [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) プロパティから開始します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-215">The lookup behavior for XAML resource references starts with the object where the actual usage is applied and its own [Resources](https://msdn.microsoft.com/library/windows/apps/br208740) property.</span></span> <span data-ttu-id="91b4c-216">[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) が存在する場合は、その **ResourceDictionary** で、要求されたキーを持つ項目が確認されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-216">If a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) exists there, that **ResourceDictionary** is checked for an item that has the requested key.</span></span> <span data-ttu-id="91b4c-217">通常はリソースを同じオブジェクトで定義して参照することはないため、最初のレベルの検索に意味があることはめったにありません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-217">This first level of lookup is rarely relevant because you usually do not define and then reference a resource on the same object.</span></span> <span data-ttu-id="91b4c-218">実際に、通常、**Resources** プロパティはここに存在しません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-218">In fact, a **Resources** property often doesn't exist here.</span></span> <span data-ttu-id="91b4c-219">XAML リソース参照は、XAML 内のほぼ任意の位置から作成できます。[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) サブクラスのプロパティには限定されません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-219">You can make XAML resource references from nearly anywhere in XAML; you aren't limited to properties of [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/br208706) subclasses.</span></span>

<span data-ttu-id="91b4c-220">検索シーケンスでは、続いてアプリのランタイム オブジェクト ツリーで次の親オブジェクトが確認されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-220">The lookup sequence then checks the next parent object in the runtime object tree of the app.</span></span> <span data-ttu-id="91b4c-221">[FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740) が存在し、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を保持する場合、指定したキー文字列を持つディクショナリ項目が要求されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-221">If a [FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740) exists and holds a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), the dictionary item with the specified key string is requested.</span></span> <span data-ttu-id="91b4c-222">リソースが見つかった場合は、検索シーケンスが停止し、参照された位置にオブジェクトが提供されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-222">If the resource is found, the lookup sequence stops and the object is provided to the location where the reference was made.</span></span> <span data-ttu-id="91b4c-223">それ以外の場合、検索動作はオブジェクト ツリーのルートに向かって次の親レベルに進みます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-223">Otherwise, the lookup behavior advances to the next parent level towards the object tree root.</span></span> <span data-ttu-id="91b4c-224">検索は、XAML のルート要素に到達し、可能性のある即時リソースの場所がすべて検索されるまで、上方向へ再帰的に継続されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-224">The search continues recursively upwards until the root element of the XAML is reached, exhausting the search of all possible immediate resource locations.</span></span>

> <span data-ttu-id="91b4c-225">**注**&nbsp;&nbsp;このリソース検索動作と共に XAML マークアップ スタイルの規則も利用するために、すべての即時リソースをページのルート レベルに定義するのは一般的なやり方です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-225">**Note**&nbsp;&nbsp;It is a common practice to define all the immediate resources at the root level of a page, both to take advantage of this resource-lookup behavior and also as a convention of XAML markup style.</span></span>

 

<span data-ttu-id="91b4c-226">要求されたリソースが即時リソースに見つからない場合、次の検索手順では [Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) プロパティが確認されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-226">If the requested resource is not found in the immediate resources, the next lookup step is to check the [Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) property.</span></span> <span data-ttu-id="91b4c-227">**Application.Resources** は、アプリのナビゲーション構造で複数のページによって参照されるアプリ固有のリソースを挿入するのに最適な場所です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-227">**Application.Resources** is the best place to put any app-specific resources that are referenced by multiple pages in your app's navigation structure.</span></span>

<span data-ttu-id="91b4c-228">制御テンプレートは、参照の検索に別の場所 (テーマ ディクショナリ) を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-228">Control templates have another possible location in the reference lookup: theme dictionaries.</span></span> <span data-ttu-id="91b4c-229">テーマ ディクショナリは、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 要素をルートとして持つ単一の XAML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-229">A theme dictionary is a single XAML file that has a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) element as its root.</span></span> <span data-ttu-id="91b4c-230">テーマ ディクショナリは、[Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) からの結合されたディクショナリである場合があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-230">The theme dictionary might be a merged dictionary from [Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338).</span></span> <span data-ttu-id="91b4c-231">テーマ ディクショナリは、テンプレート化されたカスタム コントロールのコントロール固有のテーマ ディクショナリの場合もあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-231">The theme dictionary might also be the control-specific theme dictionary for a templated custom control.</span></span>

<span data-ttu-id="91b4c-232">最後に、プラットフォーム リソースに対するリソース検索があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-232">Finally, there is a resource lookup against platform resources.</span></span> <span data-ttu-id="91b4c-233">プラットフォーム リソースには、システム UI テーマごとに定義されたコントロール テンプレートが含まれ、これは Windows ランタイム アプリで UI に使うすべてのコントロールの既定の外観を定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-233">Platform resources include the control templates that are defined for each of the system UI themes, and which define the default appearance of all the controls that you use for UI in a Windows Runtime app.</span></span> <span data-ttu-id="91b4c-234">また、プラットフォーム リソースには、システム全体の外観とテーマに関連する名前付きリソースのセットも含まれます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-234">Platform resources also include a set of named resources that relate to system-wide appearance and themes.</span></span> <span data-ttu-id="91b4c-235">これらのリソースは技術的には [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) 項目であるため、アプリの読み込み後に XAML またはコードからの検索で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-235">These resources are technically a [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) item, and thus are available for lookup from XAML or code once the app has loaded.</span></span> <span data-ttu-id="91b4c-236">たとえば、システム テーマ リソースには、アプリのテキストの色とシステム ウィンドウのテキストの色 (この色はオペレーティング システムとユーザー設定に基づく) を一致させるための [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) 定義を提供する "SystemColorWindowTextColor" というリソースが含まれています。</span><span class="sxs-lookup"><span data-stu-id="91b4c-236">For example, the system theme resources include a resource named "SystemColorWindowTextColor" that provides a [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) definition to match app text color to a system window's text color that comes from the operating system and user preferences.</span></span> <span data-ttu-id="91b4c-237">このスタイルはアプリの他の XAML スタイルで参照することができます。また、コードでリソース検索値を取得する (そしてこの例では **Color** にキャストする) こともできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-237">Other XAML styles for your app can refer to this style, or your code can get a resource lookup value (and cast it to **Color** in the example case).</span></span>

<span data-ttu-id="91b4c-238">詳しい情報や、XAML を使う UWP アプリで利用できるテーマ固有のリソースとシステム リソースの一覧については、「[XAML テーマ リソース](xaml-theme-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-238">For more info and for a list of the theme-specific and system resources that are available to a UWP app that uses XAML, see [XAML theme resources](xaml-theme-resources.md).</span></span>

<span data-ttu-id="91b4c-239">要求されたキーがこれらのいずれの場所にも見つからない場合は、XAML 解析エラーまたは例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-239">If the requested key is still not found in any of these locations, a XAML parsing error/exception occurs.</span></span> <span data-ttu-id="91b4c-240">状況によっては、XAML 解析例外は、XAML マークアップ コンパイル動作または XAML デザイン環境では検出されないランタイム例外の場合があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-240">In certain circumstances, the XAML parse exception may be a run-time exception that is not detected either by a XAML markup compile action, or by a XAML design environment.</span></span>

<span data-ttu-id="91b4c-241">各リソースが異なるレベルで定義されている限り、リソース ディクショナリの多層検索動作により、それぞれがキーと同じ文字列値を持つ複数のリソース項目を意図的に定義できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-241">Because of the tiered lookup behavior for resource dictionaries, you can deliberately define multiple resource items that each have the same string value as the key, as long as each resource is defined at a different level.</span></span> <span data-ttu-id="91b4c-242">つまり、キーは特定の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 内で一意である必要がありますが、一意性の要件は検索の動作シーケンス全体には拡張されません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-242">In other words, although keys must be unique within any given [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), the uniqueness requirement does not extend to the lookup behavior sequence as a whole.</span></span> <span data-ttu-id="91b4c-243">検索中は、最初に正常に取得されたこのオブジェクトのみが XAML リソースの参照に使われ、検索が停止します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-243">During lookup, only the first such object that's successfully retrieved is used for the XAML resource reference, and then the lookup stops.</span></span> <span data-ttu-id="91b4c-244">アプリの XAML のさまざまな場所で同じ XAML リソースをキーを使って要求するためにこの動作を利用できますが、返されるリソースは XAML リソースの参照元のスコープと、その特定の検索がどのように動作するかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-244">You could use this behavior to request the same XAML resource by key at various positions within your app's XAML but get different resources back, depending on the scope from which the XAML resource reference was made and how that particular lookup behaves.</span></span>

##  <a name="forward-references-within-a-resourcedictionary"></a><span data-ttu-id="91b4c-245">ResourceDictionary 内での前方参照</span><span class="sxs-lookup"><span data-stu-id="91b4c-245">Forward references within a ResourceDictionary</span></span>


<span data-ttu-id="91b4c-246">特定のリソース ディクショナリ内の XAML リソース参照では、キーで既に定義されたリソースを参照する必要があり、そのリソースは辞書的にソース参照より前に出現する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-246">XAML resource references within a particular resource dictionary must reference a resource that has already been defined with a key, and that resource must appear lexically before the resource reference.</span></span> <span data-ttu-id="91b4c-247">前方参照は、XAML リソース参照によって解決できません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-247">Forward references cannot be resolved by a XAML resource reference.</span></span> <span data-ttu-id="91b4c-248">そのため、XAML リソース参照を別のリソースから使う場合は、他のリソースで使われるリソースがリソース ディクショナリの先頭で定義されるように、リソース ディクショナリ構造をデザインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-248">For this reason, if you use XAML resource references from within another resource, you must design your resource dictionary structure so that the resources that are used by other resources are defined first in a resource dictionary.</span></span>

<span data-ttu-id="91b4c-249">アプリ レベルで定義されたリソースは、即時リソースを参照できません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-249">Resources defined at the app level cannot make references to immediate resources.</span></span> <span data-ttu-id="91b4c-250">アプリ リソースは実際には最初に (アプリが最初に起動し、ナビゲーション ページ コンテンツが読み込まれる前に) 処理されるため、これは前方参照の試行と同等です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-250">This is equivalent to attempting a forward reference, because the app resources are actually processed first (when the app first starts, and before any navigation-page content is loaded).</span></span> <span data-ttu-id="91b4c-251">ただし、任意の即時リソースでアプリ リソースを参照でき、この手法が前方参照の状況の回避に役立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-251">However, any immediate resource can make a reference to an app resource, and this can be a useful technique for avoiding forward-reference situations.</span></span>

## <a name="xaml-resources-must-be-shareable"></a><span data-ttu-id="91b4c-252">XAML リソースは共有できる必要がある</span><span class="sxs-lookup"><span data-stu-id="91b4c-252">XAML resources must be shareable</span></span>


<span data-ttu-id="91b4c-253">オブジェクトが [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に存在するためには、そのオブジェクトが*共有可能*である必要があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-253">For an object to exist in a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), that object must be *shareable*.</span></span>

<span data-ttu-id="91b4c-254">共有できることが必要な理由は、アプリのオブジェクト ツリーが実行時に構築されて使われるときに、オブジェクトはツリー内の複数の位置に存在できないためです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-254">Being shareable is required because, when the object tree of an app is constructed and used at run time, objects cannot exist at multiple locations in the tree.</span></span> <span data-ttu-id="91b4c-255">内部では、各 XAML リソースが要求されたときに、アプリのオブジェクト グラフで使うリソース値のコピーをリソース システムが作成します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-255">Internally, the resource system creates copies of resource values to use in the object graph of your app when each XAML resource is requested.</span></span>

<span data-ttu-id="91b4c-256">一般に、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) と Windows ランタイム XAML では、共有の目的で次のオブジェクトがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-256">A [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) and Windows Runtime XAML in general supports these objects for shareable usage:</span></span>

-   <span data-ttu-id="91b4c-257">スタイルとテンプレート ([FrameworkTemplate](https://msdn.microsoft.com/library/windows/apps/br208753) から派生したクラスと [Style](https://msdn.microsoft.com/library/windows/apps/br208849))</span><span class="sxs-lookup"><span data-stu-id="91b4c-257">Styles and templates ([Style](https://msdn.microsoft.com/library/windows/apps/br208849) and classes derived from [FrameworkTemplate](https://msdn.microsoft.com/library/windows/apps/br208753))</span></span>
-   <span data-ttu-id="91b4c-258">ブラシと色 ([Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) から派生したクラスと、[Color](https://msdn.microsoft.com/library/windows/apps/hh673723) の値)</span><span class="sxs-lookup"><span data-stu-id="91b4c-258">Brushes and colors (classes derived from [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush), and [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) values)</span></span>
-   <span data-ttu-id="91b4c-259">[Storyboard](https://msdn.microsoft.com/library/windows/apps/br210490) などのアニメーション型</span><span class="sxs-lookup"><span data-stu-id="91b4c-259">Animation types including [Storyboard](https://msdn.microsoft.com/library/windows/apps/br210490)</span></span>
-   <span data-ttu-id="91b4c-260">変換 ([GeneralTransform](https://msdn.microsoft.com/library/windows/apps/br210034) から派生したクラス)</span><span class="sxs-lookup"><span data-stu-id="91b4c-260">Transforms (classes derived from [GeneralTransform](https://msdn.microsoft.com/library/windows/apps/br210034))</span></span>
-   <span data-ttu-id="91b4c-261">[Matrix](https://msdn.microsoft.com/library/windows/apps/br210127) および [Matrix3D](https://msdn.microsoft.com/library/windows/apps/br243266)</span><span class="sxs-lookup"><span data-stu-id="91b4c-261">[Matrix](https://msdn.microsoft.com/library/windows/apps/br210127) and [Matrix3D](https://msdn.microsoft.com/library/windows/apps/br243266)</span></span>
-   <span data-ttu-id="91b4c-262">[Point](https://msdn.microsoft.com/library/windows/apps/br225870) 値</span><span class="sxs-lookup"><span data-stu-id="91b4c-262">[Point](https://msdn.microsoft.com/library/windows/apps/br225870) values</span></span>
-   <span data-ttu-id="91b4c-263">[Thickness](https://msdn.microsoft.com/library/windows/apps/br208864) や [CornerRadius](https://msdn.microsoft.com/library/windows/apps/br242343) など、その他の特定の UI 関連構造。</span><span class="sxs-lookup"><span data-stu-id="91b4c-263">Certain other UI-related structures such as [Thickness](https://msdn.microsoft.com/library/windows/apps/br208864) and [CornerRadius](https://msdn.microsoft.com/library/windows/apps/br242343)</span></span>
-   [<span data-ttu-id="91b4c-264">XAML 固有のデータ型</span><span class="sxs-lookup"><span data-stu-id="91b4c-264">XAML intrinsic data types</span></span>](https://msdn.microsoft.com/library/windows/apps/mt186448)

<span data-ttu-id="91b4c-265">所定の実装パターンに従えば、カスタム型を共有可能なリソースとして使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-265">You can also use custom types as a shareable resource if you follow the necessary implementation patterns.</span></span> <span data-ttu-id="91b4c-266">こうしたクラスは、バッキング コード (または含めるランタイム コンポーネント) で定義し、XAML でリソースとしてインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-266">You define such classes in your backing code (or in runtime components that you include) and then instantiate those classes in XAML as a resource.</span></span> <span data-ttu-id="91b4c-267">たとえば、オブジェクト データ ソースや、データ バインディングの [IValueConverter](https://msdn.microsoft.com/library/windows/apps/br209903) 実装などです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-267">Examples are object data sources and [IValueConverter](https://msdn.microsoft.com/library/windows/apps/br209903) implementations for data binding.</span></span>

<span data-ttu-id="91b4c-268">カスタム型には既定のコンストラクターが必要です。XAML パーサーは、そのコンストラクターを使ってクラスをインスタンス化するからです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-268">Custom types must have a default constructor, because that's what a XAML parser uses to instantiate a class.</span></span> <span data-ttu-id="91b4c-269">リソースとして使われるカスタム型は、継承により [UIElement](https://msdn.microsoft.com/library/windows/apps/br208911) クラスを持つことはできません。**UIElement** は共有できないためです (ランタイム アプリのオブジェクト グラフの特定の場所に存在する 1 つの UI 要素を表すためにのみ使われます)。</span><span class="sxs-lookup"><span data-stu-id="91b4c-269">Custom types used as resources can't have the [UIElement](https://msdn.microsoft.com/library/windows/apps/br208911) class in their inheritance, because a **UIElement** can never be shareable (it's always intended to represent exactly one UI element that exists at one position in the object graph of your runtime app).</span></span>

## <a name="usercontrol-usage-scope"></a><span data-ttu-id="91b4c-270">UserControl の使用のスコープ</span><span class="sxs-lookup"><span data-stu-id="91b4c-270">UserControl usage scope</span></span>


<span data-ttu-id="91b4c-271">[UserControl](https://msdn.microsoft.com/library/windows/apps/br227647) 要素には、定義のスコープと使用のスコープという固有の概念があるため、リソース検索動作について特殊な状況があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-271">A [UserControl](https://msdn.microsoft.com/library/windows/apps/br227647) element has a special situation for resource-lookup behavior because it has the inherent concepts of a definition scope and a usage scope.</span></span> <span data-ttu-id="91b4c-272">定義のスコープから XAML リソースを参照する **UserControl** は、固有の定義スコープ検索シーケンス内でそのリソースの検索をサポートできる必要があります。つまり、アプリ リソースにはアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-272">A **UserControl** that makes a XAML resource reference from its definition scope must be able to support the lookup of that resource within its own definition-scope lookup sequence—that is, it cannot access app resources.</span></span> <span data-ttu-id="91b4c-273">**UserControl** の使用のスコープからは、リソース参照は (読み込まれたオブジェクト ツリー内のオブジェクトから行われる他のリソース参照と同様に) その使用ページのルートに向かう検索シーケンス内にあるものとして扱われ、アプリ リソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-273">From a **UserControl** usage scope, a resource reference is treated as being within the lookup sequence towards its usage page root (just like any other resource reference made from an object in a loaded object tree) and can access app resources.</span></span>

## <a name="resourcedictionary-and-xamlreaderload"></a><span data-ttu-id="91b4c-274">ResourceDictionary と XamlReader.Load</span><span class="sxs-lookup"><span data-stu-id="91b4c-274">ResourceDictionary and XamlReader.Load</span></span>

<span data-ttu-id="91b4c-275">[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) は、ルートとして、または [XamlReader.Load](https://msdn.microsoft.com/library/windows/apps/br228048) メソッドの XAML 入力の一部として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-275">You can use a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) as either the root or a part of the XAML input for the [XamlReader.Load](https://msdn.microsoft.com/library/windows/apps/br228048) method.</span></span> <span data-ttu-id="91b4c-276">そのようなすべての参照が、読み込むために送信された XAML 内で完全に自己完結している場合、その XAML に XAML リソース参照を含めることもできます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-276">You can also include XAML resource references in that XAML if all such references are completely self-contained in the XAML submitted for loading.</span></span> <span data-ttu-id="91b4c-277">**XamlReader.Load** は、他の **ResourceDictionary** オブジェクトを ([Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338) さえも) 認識しないコンテキストで XAML を解析します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-277">**XamlReader.Load** parses the XAML in a context that is not aware of any other **ResourceDictionary** objects, not even [Application.Resources](https://msdn.microsoft.com/library/windows/apps/br242338).</span></span> <span data-ttu-id="91b4c-278">また、**XamlReader.Load** に送信された XAML 内から `{ThemeResource}` を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-278">Also, don't use `{ThemeResource}` from within XAML submitted to **XamlReader.Load**.</span></span>

## <a name="using-a-resourcedictionary-from-code"></a><span data-ttu-id="91b4c-279">コードからの ResourceDictionary の使用</span><span class="sxs-lookup"><span data-stu-id="91b4c-279">Using a ResourceDictionary from code</span></span>

<span data-ttu-id="91b4c-280">[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) のシナリオのほとんどが、XAML のみで処理されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-280">Most of the scenarios for a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) are handled exclusively in XAML.</span></span> <span data-ttu-id="91b4c-281">UI 定義ファイルの XAML ノード セットまたは XAML ファイルとして **ResourceDictionary** コンテナーとリソースを宣言します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-281">You declare the **ResourceDictionary** container and the resources within as a XAML file or set of XAML nodes in a UI definition file.</span></span> <span data-ttu-id="91b4c-282">次に、XAML リソース参照を使って、XAML の他の部分からリソースを要求します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-282">And then you use XAML resource references to request those resources from other parts of XAML.</span></span> <span data-ttu-id="91b4c-283">それでも、アプリの実行中にコードを実行して **ResourceDictionary** の内容を調整するというシナリオ、または、少なくとも **ResourceDictionary** の内容を照会して、リソースが定義済みかどうか確認するというシナリオもあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-283">Still, there are certain scenarios where your app might want to adjust the contents of a **ResourceDictionary** using code that executes while the app is running, or at least to query the contents of a **ResourceDictionary** to see if a resource is already defined.</span></span> <span data-ttu-id="91b4c-284">これらのコードは **ResourceDictionary** インスタンスで呼び出されるため、最初に [FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740) を取得することでオブジェクト ツリー内のどこかにある即時 **ResourceDictionary** を取得するか、`Application.Current.Resources` を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-284">These code calls are made on a **ResourceDictionary** instance, so you must first retrieve one—either an immediate **ResourceDictionary** somewhere in the object tree by getting [FrameworkElement.Resources](https://msdn.microsoft.com/library/windows/apps/br208740), or `Application.Current.Resources`.</span></span>

<span data-ttu-id="91b4c-285">C\# または Microsoft Visual Basic コードでは、インデクサー ([Item](https://msdn.microsoft.com/library/windows/apps/jj603134)) を使って所定の [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) 内のリソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-285">In C\# or Microsoft Visual Basic code, you can reference a resource in a given [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) by using the indexer ([Item](https://msdn.microsoft.com/library/windows/apps/jj603134)).</span></span> <span data-ttu-id="91b4c-286">**ResourceDictionary** は、文字列キーを持つディクショナリであるため、インデクサーは整数インデックスではなく文字列キーを使います。</span><span class="sxs-lookup"><span data-stu-id="91b4c-286">A **ResourceDictionary** is a string-keyed dictionary, so the indexer uses the string key instead of an integer index.</span></span> <span data-ttu-id="91b4c-287">VisualC ではコンポーネント拡張機能 (、C++/cli CX) コードでは、[参照](https://msdn.microsoft.com/library/windows/apps/br208800)を使用します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-287">In VisualC++ component extensions (C++/CX) code, use [Lookup](https://msdn.microsoft.com/library/windows/apps/br208800).</span></span>

<span data-ttu-id="91b4c-288">コードを使って [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を調査または変更するときは、[Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) や [Item](https://msdn.microsoft.com/library/windows/apps/jj603134) などの API の動作で、即時リソースからアプリ リソースまで走査することはありません。XAML ページを読み込むときにのみ実行される XAML パーサーの動作とは異なります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-288">When using code to examine or change a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), the behavior for APIs like [Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) or [Item](https://msdn.microsoft.com/library/windows/apps/jj603134) does not traverse from immediate resources to app resources; that's a XAML parser behavior that only happens as XAML pages are loaded.</span></span> <span data-ttu-id="91b4c-289">実行時、キーのスコープはその時点で使っている **ResourceDictionary** インスタンスに対して自己完結しています。</span><span class="sxs-lookup"><span data-stu-id="91b4c-289">At run time, scope for keys is self-contained to the **ResourceDictionary** instance that you are using at the time.</span></span> <span data-ttu-id="91b4c-290">ただし、そのスコープは [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801) まで広がりません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-290">However, that scope does extend into [MergedDictionaries](https://msdn.microsoft.com/library/windows/apps/br208801).</span></span>

<span data-ttu-id="91b4c-291">また、[ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に存在しないキーを要求した場合、エラーにならないことがあります。単純に戻り値に **null** が返されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-291">Also, if you request a key that does not exist in the [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794), there may not be an error; the return value may simply be provided as **null**.</span></span> <span data-ttu-id="91b4c-292">ただし、返された **null** を値として使おうとすると、エラーになることがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-292">You may still get an error, though, if you try to use the returned **null** as a value.</span></span> <span data-ttu-id="91b4c-293">エラーの原因として考えられるのは、**ResourceDictionary** の呼び出しではなく、プロパティの setter です。</span><span class="sxs-lookup"><span data-stu-id="91b4c-293">The error would come from the property's setter, not your **ResourceDictionary** call.</span></span> <span data-ttu-id="91b4c-294">エラーにならないのは、プロパティが有効な値として **null** を受け取る場合だけです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-294">The only way you'd avoid an error is if the property accepted **null** as a valid value.</span></span> <span data-ttu-id="91b4c-295">この動作は、XAML 解析時の XAML 検索の動作とは対照的です。解析時に XAML から渡されたキーを解決できない場合、プロパティが **null** を受け付ける場合でも XAML 解析エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-295">Note how this behavior contrasts with XAML lookup behavior at XAML parse time; a failure to resolve the provided key from XAML at parse time results in a XAML parse error, even in cases where the property could have accepted **null**.</span></span>

<span data-ttu-id="91b4c-296">結合されたリソース ディクショナリは、実行時に結合されたディクショナリを参照するプライマリ リソース ディクショナリのインデックス スコープに含まれます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-296">Merged resource dictionaries are included into the index scope of the primary resource dictionary that references the merged dictionary at run time.</span></span> <span data-ttu-id="91b4c-297">つまり、プライマリ ディクショナリの **Item** または [Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) を使って、結合されたディクショナリに実際に定義されているオブジェクトを検索できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-297">In other words, you can use **Item** or [Lookup](https://msdn.microsoft.com/library/windows/apps/br208800) of the primary dictionary to find any objects that were actually defined in the merged dictionary.</span></span> <span data-ttu-id="91b4c-298">この場合、検索の動作は解析時の XAML 検索の動作に似ています。結合されたディクショナリに同じキーを持つオブジェクトが複数ある場合は、最後に追加されたディクショナリのオブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-298">In this case, the lookup behavior does resemble the parse-time XAML lookup behavior: if there are multiple objects in merged dictionaries that each have the same key, the object from the last-added dictionary is returned.</span></span>

<span data-ttu-id="91b4c-299">**Add** (C\# または Visual Basic) または [Insert](https://msdn.microsoft.com/library/windows/apps/br208799) (C++/CX) を呼び出すことで、既にある [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) に項目を追加できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-299">You are permitted to add items to an existing [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) by calling **Add** (C\# or Visual Basic) or [Insert](https://msdn.microsoft.com/library/windows/apps/br208799) (C++/CX).</span></span> <span data-ttu-id="91b4c-300">即時リソースまたはアプリ リソースに項目を追加できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-300">You could add the items to either immediate resources or app resources.</span></span> <span data-ttu-id="91b4c-301">これらの API 呼び出しはどちらもキーを必要とします。これにより、**ResourceDictionary** の各項目にキーが必要という要件が満たされます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-301">Either of these API calls requires a key, which satisfies the requirement that each item in a **ResourceDictionary** must have a key.</span></span> <span data-ttu-id="91b4c-302">ただし、実行時に **ResourceDictionary** に追加した項目は、XAML リソース参照に関係しません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-302">However, items that you add to a **ResourceDictionary** at run time are not relevant to XAML resource references.</span></span> <span data-ttu-id="91b4c-303">XAML リソース参照に必要な検索は、アプリの読み込み時にその XAML が最初に解析されるとき (またはテーマの変更が検出されたとき) に実行されます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-303">The necessary lookup for XAML resource references happens when that XAML is first parsed as the app is loaded (or a theme change is detected).</span></span> <span data-ttu-id="91b4c-304">実行時にコレクションに追加されるリソースはその時点では使用できず、**ResourceDictionary** を変更しても、そこから取得済みのリソースは無効にはなりません。そのリソースの値を変更した場合でも同じです。</span><span class="sxs-lookup"><span data-stu-id="91b4c-304">Resources added to collections at run time weren't available then, and altering the **ResourceDictionary** doesn't invalidate an already retrieved resource from it even if you change the value of that resource.</span></span>

<span data-ttu-id="91b4c-305">実行時に [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) から項目を削除したり、一部またはすべての項目のコピーを作るなどの操作も実行できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-305">You also can remove items from a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) at run time, make copies of some or all items, or other operations.</span></span> <span data-ttu-id="91b4c-306">**ResourceDictionary** に対して一覧表示されるメンバーは、利用できる API を示します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-306">The members listing for **ResourceDictionary** indicates which APIs are available.</span></span> <span data-ttu-id="91b4c-307">**ResourceDictionary** には基になるコレクション インターフェイスをサポートするプロジェクションされた API があるため、API オプションは、C\# または Visual Basic と C++/CX のどちらを使っているかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-307">Note that because **ResourceDictionary** has a projected API to support its underlying collection interfaces, your API options differ depending on whether you are using C\# or Visual Basic versus C++/CX.</span></span>

## <a name="resourcedictionary-and-localization"></a><span data-ttu-id="91b4c-308">ResourceDictionary とローカライズ</span><span class="sxs-lookup"><span data-stu-id="91b4c-308">ResourceDictionary and localization</span></span>


<span data-ttu-id="91b4c-309">最初に XAML [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) には、ローカライズが必要な文字列が含まれていることがあります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-309">A XAML [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) might initially contain strings that are to be localized.</span></span> <span data-ttu-id="91b4c-310">その場合は、これらの文字列を **ResourceDictionary** にではなくプロジェクト リソースとして保存します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-310">If so, store these strings as project resources instead of in a **ResourceDictionary**.</span></span> <span data-ttu-id="91b4c-311">XAML から文字列を取り出し、所有する要素に [x:Uid ディレクティブ](https://msdn.microsoft.com/library/windows/apps/mt204791)値を与えます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-311">Take the strings out of the XAML, and instead give the owning element an [x:Uid directive](https://msdn.microsoft.com/library/windows/apps/mt204791) value.</span></span> <span data-ttu-id="91b4c-312">次に、リソース ファイルにリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-312">Then, define a resource in a resources file.</span></span> <span data-ttu-id="91b4c-313">*XUIDValue*.*PropertyName* の形式のリソース名と、ローカライズが必要な文字列のリソース値を提供します。</span><span class="sxs-lookup"><span data-stu-id="91b4c-313">Provide a resource name in the form *XUIDValue*.*PropertyName* and a resource value of the string that should be localized.</span></span>

## <a name="custom-resource-lookup"></a><span data-ttu-id="91b4c-314">カスタム リソース検索</span><span class="sxs-lookup"><span data-stu-id="91b4c-314">Custom resource lookup</span></span>

<span data-ttu-id="91b4c-315">高度なシナリオとして、このトピックで説明した XAML リソース参照の検索の動作とは異なる動作を持つクラスを実装できます。</span><span class="sxs-lookup"><span data-stu-id="91b4c-315">For advanced scenarios, you can implement a class that can have different behavior than the XAML resource reference lookup behavior described in this topic.</span></span> <span data-ttu-id="91b4c-316">そのためには、[CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327) クラスを実装します。すると、[StaticResource](../../xaml-platform/staticresource-markup-extension.md) または [ThemeResource](../../xaml-platform/themeresource-markup-extension.md) を使う代わりにリソース参照に [CustomResource markup extension](https://msdn.microsoft.com/library/windows/apps/mt185580) を使って、この動作にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="91b4c-316">To do this, you implement the class [CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327), and then you can access that behavior by using the [CustomResource markup extension](https://msdn.microsoft.com/library/windows/apps/mt185580) for resource references rather than using [StaticResource](../../xaml-platform/staticresource-markup-extension.md) or [ThemeResource](../../xaml-platform/themeresource-markup-extension.md).</span></span> <span data-ttu-id="91b4c-317">ほとんどのアプリにこれを必要とするシナリオはありません。</span><span class="sxs-lookup"><span data-stu-id="91b4c-317">Most apps won't have scenarios that require this.</span></span> <span data-ttu-id="91b4c-318">詳しくは、「[CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91b4c-318">For more info, see [CustomXamlResourceLoader](https://msdn.microsoft.com/library/windows/apps/br243327).</span></span>

 
## <a name="related-topics"></a><span data-ttu-id="91b4c-319">関連トピック</span><span class="sxs-lookup"><span data-stu-id="91b4c-319">Related topics</span></span>

* [<span data-ttu-id="91b4c-320">ResourceDictionary</span><span class="sxs-lookup"><span data-stu-id="91b4c-320">ResourceDictionary</span></span>](https://msdn.microsoft.com/library/windows/apps/br208794)
* [<span data-ttu-id="91b4c-321">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="91b4c-321">XAML overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185595)
* [<span data-ttu-id="91b4c-322">StaticResource マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="91b4c-322">StaticResource markup extension</span></span>](../../xaml-platform/staticresource-markup-extension.md)
* [<span data-ttu-id="91b4c-323">ThemeResource マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="91b4c-323">ThemeResource markup extension</span></span>](../../xaml-platform/themeresource-markup-extension.md)
* [<span data-ttu-id="91b4c-324">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="91b4c-324">XAML theme resources</span></span>](xaml-theme-resources.md)
* [<span data-ttu-id="91b4c-325">コントロールのスタイル</span><span class="sxs-lookup"><span data-stu-id="91b4c-325">Styling controls</span></span>](xaml-styles.md)
* [<span data-ttu-id="91b4c-326">x:Key 属性</span><span class="sxs-lookup"><span data-stu-id="91b4c-326">x:Key attribute</span></span>](https://msdn.microsoft.com/library/windows/apps/mt204787)

 

 



