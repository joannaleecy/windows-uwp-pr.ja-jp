---
author: mcleblanc
ms.assetid: 089660A2-7CAE-4911-9994-F619C5D22287
title: デザイン サーフェイス上のサンプル データとプロトタイプを作るためのサンプル データ
description: アプリで Microsoft Visual Studio や Blend for Visual Studio のデザイン サーフェイスにライブ データを表示できない場合や、プライバシーやパフォーマンスなどの理由で表示するのが望ましくない場合があります。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 00a6bbf06f918c0b86bcaed7ae7891b474baefe8
ms.sourcegitcommit: 73ea31d42a9b352af38b5eb5d3c06504b50f6754
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/27/2017
ms.locfileid: "852876"
---
<a name="sample-data-on-the-design-surface-and-for-prototyping"></a><span data-ttu-id="9c5b9-104">デザイン サーフェイス上のサンプル データとプロトタイプを作るためのサンプル データ</span><span class="sxs-lookup"><span data-stu-id="9c5b9-104">Sample data on the design surface, and for prototyping</span></span>
=============================================================================================

<span data-ttu-id="9c5b9-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="9c5b9-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="9c5b9-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="9c5b9-107">**注**  サンプル データの必要性 (および有用性) は、バインドで [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)と [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)のどちらを使うかによって決まります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-107">**Note**  The degree to which you need sample data—and how much it will help you—depends on whether your bindings use the [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782) or the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783).</span></span> <span data-ttu-id="9c5b9-108">ここで説明する手法は [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) の使用に基づいているため、この手法が適しているのは **{Binding}** のみですが、</span><span class="sxs-lookup"><span data-stu-id="9c5b9-108">The techniques described in this topic are based on the use of a [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713), so they're only appropriate for **{Binding}**.</span></span> <span data-ttu-id="9c5b9-109">**{x:Bind}** を使う場合は、バインドで少なくともプレースホルダー値がデザイン サーフェイスに表示されるため (項目コントロールの場合でも)、サンプル データの必要性は比較的低くなります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-109">But if you're using **{x:Bind}** then your bindings at least show placeholder values on the design surface (even for items controls), so you don't have quite the same need for sample data.</span></span>

<span data-ttu-id="9c5b9-110">アプリで Microsoft Visual Studio や Blend for Visual Studio のデザイン サーフェイスにライブ データを表示できない場合や、プライバシーやパフォーマンスなどの理由で表示するのが望ましくない場合に、</span><span class="sxs-lookup"><span data-stu-id="9c5b9-110">It may be impossible or undesirable (perhaps for reasons of privacy or performance) for your app to display live data on the design surface in Microsoft Visual Studio or Blend for Visual Studio.</span></span> <span data-ttu-id="9c5b9-111">アプリのレイアウト、テンプレート、その他の視覚的なプロパティを操作するためにコントロールにデータを設定するには、さまざまな方法で設計時のサンプル データを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-111">In order to have your controls populated with data (so that you can work on your app's layout, templates, and other visual properties), there are various ways in which you can use design-time sample data.</span></span> <span data-ttu-id="9c5b9-112">サンプル データは、スケッチ (プロトタイプ) アプリを開発する場合にも便利で、時間の節約になります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-112">Sample data can also be really useful and time-saving if you're building a sketch (or prototype) app.</span></span> <span data-ttu-id="9c5b9-113">スケッチやプロトタイプで実行時にサンプル データを使うと、実際のライブ データに接続しなくてもアイデアを実証できます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-113">You can use sample data in your sketch or prototype at run-time to illustrate your ideas without going as far as connecting to real, live data.</span></span>

**<span data-ttu-id="9c5b9-114">{Binding} の使い方を示すサンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="9c5b9-114">Sample apps that demonstrate {Binding}</span></span>**

-   <span data-ttu-id="9c5b9-115">[Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-115">Download the [Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) app.</span></span>
-   <span data-ttu-id="9c5b9-116">[Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-116">Download the [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) app.</span></span>

<a name="setting-datacontext-in-markup"></a><span data-ttu-id="9c5b9-117">マークアップでの DataContext の設定</span><span class="sxs-lookup"><span data-stu-id="9c5b9-117">Setting DataContext in markup</span></span>
-----------------------------

<span data-ttu-id="9c5b9-118">命令型コードを (分離コードで) 使ってページやユーザー コントロールの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) をビュー モデル インスタンスに設定することは、ごく一般的な開発手法です。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-118">It's a fairly common developer practice to use imperative code (in code-behind) to set a page or user control's [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) to a view model instance.</span></span>

``` csharp
public MainPage()
{
    InitializeComponent();
    this.DataContext = new BookstoreViewModel();
}
```

<span data-ttu-id="9c5b9-119">しかし、この方法を使うとページの "デザイン性" が低下します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-119">But if you do that then your page isn't as "designable" as it could be.</span></span> <span data-ttu-id="9c5b9-120">これは、XAML ページを Visual Studio や Blend for Visual Studio で開いても、**DataContext** の値を割り当てる命令型コードは実行されないからです (分離コードは一切実行されません)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-120">The reason is that when your XAML page is opened in Visual Studio or Blend for Visual Studio, the imperative code that assigns the **DataContext** value is never run (in fact, none of your code-behind is executed).</span></span> <span data-ttu-id="9c5b9-121">もちろん、XAML ツールによってマークアップが解析され、宣言されているオブジェクトがインスタンス化されますが、ページの型そのものはインスタンス化されません。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-121">The XAML tools do of course parse your markup and instantiate any objects declared in it, but they don't actually instantiate your page's type itself.</span></span> <span data-ttu-id="9c5b9-122">その結果、コントロールや **[データ バインディングの作成]** ダイアログにデータが表示されず、ページのスタイルやレイアウトの設定が困難になります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-122">The result is that you won't see any data in your controls or in the **Create Data Binding** dialog, and your page will be more challenging to style and to lay out.</span></span>

![デザイン性の乏しい UI。](images/displaying-data-in-the-designer-01.png)

<span data-ttu-id="9c5b9-124">この問題を解決するための最初の方法では、その **DataContext** の割り当てをコメント アウトして、代わりにページのマークアップで **DataContext** を設定します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-124">The first remedy to try is to comment out that **DataContext** assignment and set the **DataContext** in your page markup instead.</span></span> <span data-ttu-id="9c5b9-125">これにより、実行時だけでなく設計時にもライブ データが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-125">That way, your live data shows up at design-time as well as at run-time.</span></span> <span data-ttu-id="9c5b9-126">これを行うには、まず、XAML ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-126">To do this, first open your XAML page.</span></span> <span data-ttu-id="9c5b9-127">次に、**[ドキュメント アウトライン]** ウィンドウでルート デザイン要素 (通常は **\[Page\]** というラベルが付いています) をクリックして選択します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-127">Then, in the **Document Outline** window, click the root designable element (usually with the label **\[Page\]**) to select it.</span></span> <span data-ttu-id="9c5b9-128">**[プロパティ]** ウィンドウで **[DataContext]** プロパティを見つけて ([共通] カテゴリにあります)、**[新規]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-128">In the **Properties** window, find the **DataContext** property (inside the Common category), and then click **New**.</span></span> <span data-ttu-id="9c5b9-129">**[オブジェクトの選択]** ダイアログ ボックスで目的のビュー モデルの種類をクリックし、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-129">Click your view model type from the **Select Object** dialog box, and then click **OK**.</span></span>

![DataContext を設定するための UI。](images/displaying-data-in-the-designer-02.png)

<span data-ttu-id="9c5b9-131">結果のマークアップは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-131">Here's what the resulting markup looks like.</span></span>

``` xaml
<Page ... >
    <Page.DataContext>
        <local:BookstoreViewModel/>
    </Page.DataContext>
```

<span data-ttu-id="9c5b9-132">これでバインドが解決されるようになったため、デザイン サーフェイスが次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-132">And here’s what the design surface looks like now that your bindings can resolve.</span></span> <span data-ttu-id="9c5b9-133">**[データ バインディングの作成]** ダイアログの **[パス]** ボックスに値が設定されています。これらは、**DataContext** 型と、バインドできるプロパティに基づいています。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-133">Notice that the **Path** picker in the **Create Data Binding** dialog is now populated, based on the **DataContext** type and the properties that you can bind to.</span></span>

![デザイン性の高い UI。](images/displaying-data-in-the-designer-03.png)

<span data-ttu-id="9c5b9-135">**[データ バインディングの作成]** ダイアログに必要なのは基になる型だけですが、バインドではプロパティの値を初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-135">The **Create Data Binding** dialog only needs a type to work from, but the bindings need the properties to be initialized with values.</span></span> <span data-ttu-id="9c5b9-136">パフォーマンス、データ転送費用、プライバシーなどの問題で設計時にクラウド サービスにアクセスしたくない場合は、アプリがデザイン ツール (Visual Studio、Blend for Visual Studio など) で実行されているかを初期化コードでチェックして、実行されている場合は設計時専用のサンプル データを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-136">If you don't want to reach out to your cloud service at design-time (due to performance, paying for data transfer, privacy issues, that kind of thing) then your initialization code can check to see whether your app is running in a design tool (such as Visual Studio or Blend for Visual Studio) and in that case load sample data for use at design-time only.</span></span>

``` csharp
if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
{
    // Load design-time books.
}
else
{
    // Load books from a cloud service.
}
```

<span data-ttu-id="9c5b9-137">初期化コードにパラメーターを渡す必要がある場合は、ビュー モデル ロケーターを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-137">You could use a view model locator if you need to pass parameters to your initialization code.</span></span> <span data-ttu-id="9c5b9-138">ビュー モデル ロケーターとは、アプリ リソースに配置することができるクラスです。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-138">A view model locator is a class that you can put into app resources.</span></span> <span data-ttu-id="9c5b9-139">このクラスにはビュー モデルを公開するプロパティがあるので、そのプロパティにページの **DataContext** をバインドします。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-139">It has a property that exposes the view model, and your page's **DataContext** binds to that property.</span></span> <span data-ttu-id="9c5b9-140">ロケーターやビュー モデルで使うことができるもう 1 つのパターンは依存関係挿入です。依存関係挿入では、設計時または実行時のデータ プロバイダーを必要に応じて作成できます (それぞれ共通のインターフェイスを実装します)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-140">Another pattern that the locator or the view model can use is dependency injection, which can construct a design-time or a run-time data provider (each of which implements a common interface), as applicable.</span></span>

<a name="sample-data-from-class-and-design-time-attributes"></a><span data-ttu-id="9c5b9-141">"クラスからのサンプル データ" と設計時属性</span><span class="sxs-lookup"><span data-stu-id="9c5b9-141">"Sample data from class", and design-time attributes</span></span>
---------------------------------------------------------------------------------------

<span data-ttu-id="9c5b9-142">なんらかの理由で前のセクションのいずれの方法でも問題を解決できない場合でも、XAML ツールの機能と設計時属性を使ってさまざまな方法で設計時のデータを利用できます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-142">If for whatever reason none of the options in the previous section work for you then you still have plenty of design-time data options available via XAML tools features and design-time attributes.</span></span> <span data-ttu-id="9c5b9-143">その 1 つが、Blend for Visual Studio の **[クラスからのサンプル データの作成]** 機能です。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-143">One good option is the **Create Sample Data from Class** feature in Blend for Visual Studio.</span></span> <span data-ttu-id="9c5b9-144">このコマンドのボタンは **[データ]** パネルの上部にあります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-144">You can find that command on one of the buttons at the top of the **Data** panel.</span></span>

<span data-ttu-id="9c5b9-145">必要な作業は、このコマンドで使うクラスを指定することだけです。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-145">All you need to do is to specify a class for the command to use.</span></span> <span data-ttu-id="9c5b9-146">クラスを指定すると、重要なことが 2 つ行われます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-146">The command then does two important things for you.</span></span> <span data-ttu-id="9c5b9-147">まず、選んだクラスのインスタンスとそのすべてのメンバーを再帰的にハイドレートするために適したサンプル データを含む XAML ファイルが生成されます (このツールは、XAML ファイルでも JSON ファイルでも適切に機能します)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-147">First, it generates a XAML file that contains sample data suitable for hydrating an instance of your chosen class and all of its members, recursively (in fact, the tooling works equally well with XAML or JSON files).</span></span> <span data-ttu-id="9c5b9-148">次に、選んだクラスのスキーマが **[データ]** パネルに設定されます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-148">Second, it populates the **Data** panel with the schema of your chosen class.</span></span> <span data-ttu-id="9c5b9-149">これにより、**[データ]** パネルからデザイン サーフェイスにメンバーをドラッグしてさまざまなタスクを実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-149">You can then drag members from the **Data** panel onto the design surface to perform various tasks.</span></span> <span data-ttu-id="9c5b9-150">何をどこにドラッグするかによって、既にあるコントロールにバインドを追加することも (**{Binding}** を使用)、新しいコントロールの作成とバインドを同時に行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-150">Depending on what you drag and where you drop it, you can add bindings to existing controls (using **{Binding}**), or create new controls and bind them at the same time.</span></span> <span data-ttu-id="9c5b9-151">どちらの場合も、ページのレイアウト ルートに設計時のデータ コンテキスト (**d:DataContext**) も設定されます (まだ設定されていない場合)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-151">In either case, the operation also sets a design-time data context (**d:DataContext**) for you (if one is not already set) on the layout root of your page.</span></span> <span data-ttu-id="9c5b9-152">その設計時のデータ コンテキストが、**d:DesignData** 属性を使って、生成された XAML ファイルからサンプル データを取得します (なお、その XAML ファイルをプロジェクト内で見つけて、必要なサンプル データを含むように編集することもできます)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-152">That design-time data context uses the **d:DesignData** attribute to get its sample data from the XAML file that was generated (which, by the way, you are free to find in your project and edit so that it contains the sample data you want).</span></span>

``` xaml
<Page ...
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
    <Grid ... d:DataContext="{d:DesignData /SampleData/RecordingViewModelSampleData.xaml}"/>
        <ListView ItemsSource="{Binding Recordings}" ... />
        ...
    </Grid>
</Page>
```

<span data-ttu-id="9c5b9-153">さまざまな xmlns 宣言がありますが、これらは、**d:** プレフィックスの付いた属性は設計時にのみ解釈され、実行時には無視されることを表しています。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-153">The various xmlns declarations mean that attributes with the **d:** prefix are interpreted only at design-time and are ignored at run-time.</span></span> <span data-ttu-id="9c5b9-154">したがって、**d:DataContext** 属性が [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) プロパティの値に影響するのは設計時のみで、実行時には影響しません。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-154">So the **d:DataContext** attribute only affects the value of the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) property at design-time; it has no effect at run-time.</span></span> <span data-ttu-id="9c5b9-155">必要であれば、**d:DataContext** と **DataContext** の両方をマークアップで設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-155">You can even set both **d:DataContext** and **DataContext** in markup if you like.</span></span> <span data-ttu-id="9c5b9-156">その場合、設計時には **d:DataContext** が優先され、実行時には **DataContext** が優先されます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-156">**d:DataContext** will override at design-time, and **DataContext** will override at run-time.</span></span> <span data-ttu-id="9c5b9-157">この規則は、すべての設計時属性と実行時属性に適用されます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-157">These same override rules apply to all design-time and run-time attributes.</span></span>

<span data-ttu-id="9c5b9-158">**d:DataContext** 属性およびその他のすべての設計時属性について詳しくは、[設計時の属性に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=272504)をご覧ください。このページは、ユニバーサル Windows プラットフォーム (UWP) アプリに対しても有効です。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-158">The **d:DataContext** attribute, and all other design-time attributes, are documented in the [Design-Time Attributes](http://go.microsoft.com/fwlink/p/?LinkId=272504) topic, which is still valid for Universal Windows Platform (UWP) apps.</span></span>

<span data-ttu-id="9c5b9-159">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) には **DataContext** プロパティはありませんが、**Source** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-159">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) doesn't have a **DataContext** property, but it does have a **Source** property.</span></span> <span data-ttu-id="9c5b9-160">そのため、**CollectionViewSource** に設計時専用のサンプル データを設定するために使うことができる **d:Source** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-160">Consequently, there's a **d:Source** property that you can use to set design-time-only sample data on a **CollectionViewSource**.</span></span>

``` xaml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
            d:Source="{d:DesignData /SampleData/RecordingsSampleData.xaml}"/>
    </Page.Resources>

    ...

        <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}" ... />
    ...
```

<span data-ttu-id="9c5b9-161">このコードが機能するためには、`Recordings : ObservableCollection<Recording>` というクラスが必要です。また、サンプル データの XAML ファイルを編集して、**Recordings** オブジェクト (**Recording** オブジェクトを含む) のみが含まれるようにする必要があります。次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-161">For this to work, you would have a class named `Recordings : ObservableCollection<Recording>`, and you would edit the sample data XAML file so that it contains only a **Recordings** object (with **Recording** objects inside that), as shown here.</span></span>

``` xml
<Quickstart:Recordings xmlns:Quickstart="using:Quickstart">
    <Quickstart:Recording ArtistName="Mollis massa" CompositionName="Cubilia metus"
        OneLineSummary="Morbi adipiscing sed" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Vulputate nunc" CompositionName="Parturient vestibulum"
        OneLineSummary="Dapibus praesent netus amet vestibulum" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Phasellus accumsan" CompositionName="Sit bibendum"
        OneLineSummary="Vestibulum egestas montes dictumst" ReleaseDateTime="01/01/1800 15:53:17"/>
</Quickstart:Recordings>
```

<span data-ttu-id="9c5b9-162">XAML ではなく JSON のサンプル データ ファイルを使う場合は、**Type** プロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-162">If you use a JSON sample data file instead of XAML, you must set the **Type** property.</span></span>

``` xaml
    d:Source="{d:DesignData /SampleData/RecordingsSampleData.json, Type=local:Recordings}"
```

<span data-ttu-id="9c5b9-163">これまでは、**d:DesignData** を使って設計時のサンプル データを XAML ファイルや JSON ファイルから読み込む方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-163">So far, we've been using **d:DesignData** to load design-time sample data from a XAML or JSON file.</span></span> <span data-ttu-id="9c5b9-164">そのほかに、**d:DesignInstance** マークアップ拡張を使う方法もあります。このマークアップ拡張は、設計時ソースが **Type** プロパティによって指定されるクラスに基づくことを示します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-164">An alternative to that is the **d:DesignInstance** markup extension, which indicates that the design-time source is based on the class specified by the **Type** property.</span></span> <span data-ttu-id="9c5b9-165">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-165">Here's an example.</span></span>

``` xaml
    <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
        d:Source="{d:DesignInstance Type=local:Recordings, IsDesignTimeCreatable=True}"/>
```

<span data-ttu-id="9c5b9-166">**IsDesignTimeCreatable** プロパティは、デザイン ツールがこのクラスのインタンスを実際に作成する必要があることを示します。したがって、このクラスにはパブリックの既定のコンストラクターがあり、そのコンストラクターにデータ (実際のデータかサンプル データ) が設定されることがわかります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-166">The **IsDesignTimeCreatable** property indicates that the design tool should actually create an instance of the class, which implies that the class has a public default constructor, and that it populates itself with data (either real or sample).</span></span> <span data-ttu-id="9c5b9-167">**IsDesignTimeCreatable** を設定しない場合 (または **False** に設定した場合) は、デザイン サーフェイスに表示されるサンプル データは取得されません。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-167">If you don't set **IsDesignTimeCreatable** (or if you set it to **False**) then you won't get sample data displayed on the design surface.</span></span> <span data-ttu-id="9c5b9-168">その場合、デザイン ツールは、クラスを解析してバインド可能なプロパティを特定し、それらを **[データ]** パネルと **[データ バインディングの作成]** ダイアログに表示するだけです。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-168">All the design tool does in that case is to parse the class for its bindable properties and display these in the the **Data** panel and in the **Create Data Binding** dialog.</span></span>

<a name="sample-data-for-prototyping"></a><span data-ttu-id="9c5b9-169">プロトタイプを作るためのサンプル データ</span><span class="sxs-lookup"><span data-stu-id="9c5b9-169">Sample data for prototyping</span></span>
--------------------------------------------------------

<span data-ttu-id="9c5b9-170">プロトタイプを作るには、設計時と実行時の両方でサンプル データが必要です。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-170">For prototyping, you want sample data at both design-time and at run-time.</span></span> <span data-ttu-id="9c5b9-171">そのような場合のために、Blend for Visual Studio には **[新しいサンプル データ]** 機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-171">For that use case, Blend for Visual Studio has the **New Sample Data** feature.</span></span> <span data-ttu-id="9c5b9-172">このコマンドのボタンは **[データ]** パネルの上部にあります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-172">You can find that command on one of the buttons at the top of the **Data** panel.</span></span>

<span data-ttu-id="9c5b9-173">クラスを指定する代わりに、**[データ]** パネルで直接サンプル データ ソースのスキーマを設計できます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-173">Instead of specifying a class, you can actually design the schema of your sample data source right in the **Data** panel.</span></span> <span data-ttu-id="9c5b9-174">**[データ]** パネルでサンプル データの値を編集することもできます。ファイルを開いて編集する必要はありません (必要であればそうすることもできます)。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-174">You can also edit sample data values in the **Data** panel: there's no need to open and edit a file (although, you can still do that if you prefer).</span></span>

<span data-ttu-id="9c5b9-175">**[新しいサンプル データ]** 機能は、**d:DataContext** ではなく [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) を使うため、スケッチやプロトタイプの設計時だけでなく実行時にもサンプル データを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-175">The **New Sample Data** feature uses [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713), and not **d:DataContext**, so that the sample data is available when you run your sketch or prototype as well as while you're designing it.</span></span> <span data-ttu-id="9c5b9-176">また、**[データ]** パネルにより、設計とバインドの作業が大幅に高速化されます。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-176">And the **Data** panel really speeds up your designing and binding tasks.</span></span> <span data-ttu-id="9c5b9-177">たとえば、コレクション プロパティを **[データ]** パネルからデザイン サーフェイスにドラッグするだけで、データがバインドされた項目コントロールと必要なテンプレートが生成されて、すぐにビルドして実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9c5b9-177">For example, simply dragging a collection property from the **Data** panel onto the design surface generates a data-bound items control and the necessary templates, all ready to build and run.</span></span>

![プロトタイプを作るためのサンプル データ。](images/displaying-data-in-the-designer-04.png)
