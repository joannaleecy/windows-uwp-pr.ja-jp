---
ms.assetid: 569E8C27-FA01-41D8-80B9-1E3E637D5B99
title: XAML マークアップの最適化
description: UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、アプリでの XAML マークアップの解析および読み込み時間や、メモリ効率の向上に役立つヒントを紹介します。
ms.date: 08/10/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ec88af01e46788ea9f24760af7f9a3b81281ba8d
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7838735"
---
# <a name="optimize-your-xaml-markup"></a><span data-ttu-id="bfda6-105">XAML マークアップの最適化</span><span class="sxs-lookup"><span data-stu-id="bfda6-105">Optimize your XAML markup</span></span>


<span data-ttu-id="bfda6-106">UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-106">Parsing XAML markup to construct objects in memory is time-consuming for a complex UI.</span></span> <span data-ttu-id="bfda6-107">以下に、XAML マークアップの解析と読み込みにかかる時間を短縮し、アプリのメモリ効率を向上させるために役立つヒントを紹介します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-107">Here are some things you can do to improve the parse and load time of your XAML markup and the memory efficiency of your app.</span></span>

<span data-ttu-id="bfda6-108">アプリの起動時に読み込まれる XAML マークアップを、最初の UI に必要な分だけに制限します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-108">At app startup, limit the XAML markup that is loaded to only what you need for your initial UI.</span></span> <span data-ttu-id="bfda6-109">最初のページ (ページ リソースを含む) のマークアップを調べて、すぐには必要とされない余分な要素を読み込んでいないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-109">Examine the markup in your initial page (including page resources) and confirm that you aren't loading extra elements that aren't needed right away.</span></span> <span data-ttu-id="bfda6-110">このような要素は、リソース ディクショナリ、初期状態で折りたたまれている要素、別の要素の上に描画される要素など、さまざまなソースに由来する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-110">These elements can come from a variety of sources, such as resource dictionaries, elements that are initially collapsed, and elements drawn over other elements.</span></span>

<span data-ttu-id="bfda6-111">すべての状況に同じ方法で対応できるとは限りません。効率を求めて XAML を最適化するには、トレードオフも必要になります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-111">Optimizing your XAML for efficiency requires making trade-offs; there's not always a single solution for every situation.</span></span> <span data-ttu-id="bfda6-112">ここでは、いくつかの一般的な問題を取り上げながら、アプリに適したトレードオフを選ぶためのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-112">Here, we look at some common issues and provide guidelines you can use to make the right trade-offs for your app.</span></span>

## <a name="minimize-element-count"></a><span data-ttu-id="bfda6-113">要素数の最小化</span><span class="sxs-lookup"><span data-stu-id="bfda6-113">Minimize element count</span></span>

<span data-ttu-id="bfda6-114">XAML プラットフォームでは大量の要素を表示できますが、目的のビジュアルを満たすためのページ上の要素の数を減らすと、アプリ レイアウトの作成とレンダリングをより速く行うことができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-114">Although the XAML platform is capable of displaying large numbers of elements, you can make your app lay out and render faster by using the fewest number of elements to achieve the visuals you want.</span></span>

<span data-ttu-id="bfda6-115">アプリの起動時に作成される UI 要素の数は、UI コントロールがどのように配置されているかによって左右されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-115">The choices you make in how you lay out your UI controls will affect the number of UI elements that are created when your app starts.</span></span> <span data-ttu-id="bfda6-116">レイアウトの最適化について詳しくは、「[XAML レイアウトの最適化](optimize-your-xaml-layout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfda6-116">For more detailed information about optimizing layout, see [Optimize your XAML layout](optimize-your-xaml-layout.md).</span></span>

<span data-ttu-id="bfda6-117">データ テンプレートでは、データ項目ごとに各要素が繰り返し作成されるため、要素数が非常に重要になります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-117">Element count is extremely important in data templates because each element is created again for each data item.</span></span> <span data-ttu-id="bfda6-118">リストやグリッドで要素数を減らす方法については、「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」の「*項目ごとの要素の削減*」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfda6-118">For info about reducing element count in a list or grid, see *Element reduction per item* in the [ListView and GridView UI optimization](optimize-gridview-and-listview.md) article.</span></span>

<span data-ttu-id="bfda6-119">ここでは、アプリの起動時に読み込む必要のある要素数を減らすための方法をいくつか見ていきます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-119">Here, we look at some other ways you can reduce the number of elements your app has to load at startup.</span></span>

### <a name="defer-item-creation"></a><span data-ttu-id="bfda6-120">項目の作成を延期する</span><span class="sxs-lookup"><span data-stu-id="bfda6-120">Defer item creation</span></span>

<span data-ttu-id="bfda6-121">すぐには表示されない要素が XAML マークアップに含まれている場合は、それらの要素が表示されるまで読み込みを延期することができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-121">If your XAML markup contains elements that you don't show right away, you can defer loading those elements until they are shown.</span></span> <span data-ttu-id="bfda6-122">たとえば、タブのような UI では、セカンダリ タブなどの非表示のコンテンツの作成を遅らせることができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-122">For example, you can delay the creation of non-visible content such as a secondary tab in a tab-like UI.</span></span> <span data-ttu-id="bfda6-123">また、データを表示するときには、既定では項目をグリッド ビューで表示し、後からリスト表示に切り替えるオプションを用意する方法があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-123">Or, you might show items in a grid view by default, but provide an option for the user to view the data in a list instead.</span></span> <span data-ttu-id="bfda6-124">これにより、必要になるまでリストの読み込みを遅らせることができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-124">You can delay loading the list until it's needed.</span></span>

<span data-ttu-id="bfda6-125">要素が表示されるタイミングを制御するには、[Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.Visibility) プロパティの代わりに [x:Load attribute](../xaml-platform/x-load-attribute.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-125">Use the [x:Load attribute](../xaml-platform/x-load-attribute.md) instead of the [Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.Visibility) property to control when an element is shown.</span></span> <span data-ttu-id="bfda6-126">要素の Visibility が **Collapsed** に設定されている場合、その要素はレンダリング パスではスキップされますが、オブジェクト インスタンスのメモリ使用のコストは発生します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-126">When an element's visibility is set to **Collapsed**, then it is skipped during the render pass, but you still pay the object instance costs in memory.</span></span> <span data-ttu-id="bfda6-127">代わりに x:Load を使用すると、オブジェクト インスタンスは必要になるまで作成されないため、メモリ コストはさらに低くなります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-127">When you use x:Load instead, the framework does not create the object instance until it is needed, so the memory costs are even lower.</span></span> <span data-ttu-id="bfda6-128">欠点は、UI が読み込まれていないときに、小さなメモリ オーバーヘッド (約 600 バイト) が発生することです。</span><span class="sxs-lookup"><span data-stu-id="bfda6-128">The drawback is you pay a small memory overhead (approx 600 bytes) when the UI is not loaded.</span></span>

> [!NOTE]
> <span data-ttu-id="bfda6-129">要素の遅延読み込みには、[x:Load](../xaml-platform/x-load-attribute.md) 属性または [x:DeferLoadStrategy](../xaml-platform/x-deferloadstrategy-attribute.md) 属性を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-129">You can delay loading elements using the [x:Load](../xaml-platform/x-load-attribute.md) or [x:DeferLoadStrategy](../xaml-platform/x-deferloadstrategy-attribute.md) attribute.</span></span> <span data-ttu-id="bfda6-130">x:Load 属性は、Windows 10 Creators Update (Version 1703、SDK ビルド 15063) 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-130">The x:Load attribute is available starting in Windows 10 Creators Update (version 1703, SDK build 15063).</span></span> <span data-ttu-id="bfda6-131">x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-131">The min version targeted by your Visual Studio project must be *Windows 10 Creators Update (10.0, Build 15063)* in order to use x:Load.</span></span> <span data-ttu-id="bfda6-132">それより前のバージョンを対象とする場合は、x:DeferLoadStrategy を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-132">To target earlier versions, use x:DeferLoadStrategy.</span></span>

<span data-ttu-id="bfda6-133">以降の例では、異なる方法を使って UI 要素を非表示にした場合の要素数とメモリ使用量の違いを示します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-133">The following examples show the difference in element count and memory use when different techniques are used to hide UI elements.</span></span> <span data-ttu-id="bfda6-134">ページのルート Grid に、まったく同じ項目を含む ListView と GridView が 1 つずつ配置されています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-134">A ListView and a GridView containing identical items are placed in a page's root Grid.</span></span> <span data-ttu-id="bfda6-135">ListView は非表示ですが、GridView は表示されています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-135">The ListView is not visible, but the GridView is shown.</span></span> <span data-ttu-id="bfda6-136">これらの例の XAML は、いずれも画面上に同一の UI を生成します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-136">The XAML in each of these examples produces the same UI on the screen.</span></span> <span data-ttu-id="bfda6-137">要素数とメモリ使用量の確認には、Visual Studio の[プロファイリングとパフォーマンスに関するツール](tools-for-profiling-and-performance.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-137">We use Visual Studio's [tools for profiling and performance](tools-for-profiling-and-performance.md) to check the element count and memory use.</span></span>

#### <a name="option-1---inefficient"></a><span data-ttu-id="bfda6-138">オプション 1 - 非効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-138">Option 1 - Inefficient</span></span>

<span data-ttu-id="bfda6-139">この例では、ListView は読み込まれますが、Width が 0 なので表示されません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-139">Here, the ListView is loaded, but is not visible because it's Width is 0.</span></span> <span data-ttu-id="bfda6-140">ListView とその各子要素は、ビジュアル ツリー内に作成され、メモリに読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-140">The ListView and each of its child elements is created in the visual tree and loaded into memory.</span></span>

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

<span data-ttu-id="bfda6-141">ListView を読み込んだ場合のライブ ビジュアル ツリー。</span><span class="sxs-lookup"><span data-stu-id="bfda6-141">Live visual tree with the ListView loaded.</span></span> <span data-ttu-id="bfda6-142">ページの要素の総数は 89 です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-142">Total element count for the page is 89.</span></span>

![リスト ビューのあるビジュアル ツリー](images/visual-tree-1.png)

<span data-ttu-id="bfda6-144">ListView とその子がメモリに読み込まれています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-144">ListView and its children are loaded into memory.</span></span>

![リスト ビューのあるビジュアル ツリー](images/memory-use-1.png)

#### <a name="option-2---better"></a><span data-ttu-id="bfda6-146">オプション 2 - やや効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-146">Option 2 - Better</span></span>

<span data-ttu-id="bfda6-147">この例では、ListView の Visibility が Collapsed に設定されています (その他の XAML は元と同じです)。</span><span class="sxs-lookup"><span data-stu-id="bfda6-147">Here, the ListView's Visibility is set to collapsed (the other XAML is identical to the original).</span></span> <span data-ttu-id="bfda6-148">ListView はビジュアル ツリーに作成されますが、その子要素は作成されません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-148">The ListView is created in the visual tree, but its child elements are not.</span></span> <span data-ttu-id="bfda6-149">ただし、メモリには子要素も読み込まれるため、メモリ使用量は前の例と同じです。</span><span class="sxs-lookup"><span data-stu-id="bfda6-149">However, they are loaded into memory, so memory use is identical to the previous example.</span></span>

```xaml
    <ListView x:Name="List1" Visibility="Collapsed">
```

<span data-ttu-id="bfda6-150">ListView を Collapsed に設定した場合のライブ ビジュアル ツリー。</span><span class="sxs-lookup"><span data-stu-id="bfda6-150">Live visual tree with the ListView collapsed.</span></span> <span data-ttu-id="bfda6-151">ページの要素の総数は 46 です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-151">Total element count for the page is 46.</span></span>

![折りたたまれたリスト ビューのあるビジュアル ツリー](images/visual-tree-2.png)

<span data-ttu-id="bfda6-153">ListView とその子がメモリに読み込まれています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-153">ListView and its children are loaded into memory.</span></span>

![リスト ビューのあるビジュアル ツリー](images/memory-use-1.png)

#### <a name="option-3---most-efficient"></a><span data-ttu-id="bfda6-155">オプション 3 - 最も効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-155">Option 3 - Most Efficient</span></span>

<span data-ttu-id="bfda6-156">この例では、ListView の x:Load 属性が **False** に設定されています (その他の XAML は元と同じです)。</span><span class="sxs-lookup"><span data-stu-id="bfda6-156">Here, the ListView has the x:Load attribute set to **False** (the other XAML is identical to the original).</span></span> <span data-ttu-id="bfda6-157">この ListView は、起動時にはビジュアル ツリーに作成されず、メモリにも読み込まれません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-157">The ListView is not created in the visual tree or loaded into memory at start up.</span></span>

```xaml
    <ListView x:Name="List1" Visibility="Collapsed" x:Load="False">
```

<span data-ttu-id="bfda6-158">ListView が読み込まれていないライブ ビジュアル ツリー。</span><span class="sxs-lookup"><span data-stu-id="bfda6-158">Live visual tree with the ListView not loaded.</span></span> <span data-ttu-id="bfda6-159">ページの要素の総数は 45 です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-159">Total element count for the page is 45.</span></span>

![リスト ビューが読み込まれていないビジュアル ツリー](images/visual-tree-3.png)

<span data-ttu-id="bfda6-161">ListView とその子はメモリに読み込まれていません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-161">ListView and its children are not loaded into memory.</span></span>

![リスト ビューのあるビジュアル ツリー](images/memory-use-3.png)

> [!NOTE]
> <span data-ttu-id="bfda6-163">これらの例における要素数とメモリ使用量は非常に小さく、概念を紹介するためだけに示したものです。</span><span class="sxs-lookup"><span data-stu-id="bfda6-163">The element counts and memory use in these examples are very small and are shown only to demonstrate the concept.</span></span> <span data-ttu-id="bfda6-164">これらの例では、x:Load を使った場合のオーバーヘッドがメモリの節約量よりも大きくなるため、実際にはアプリにとってのメリットはありません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-164">In these examples, the overhead of using x:Load is greater than the memory savings, so the app would not benefit.</span></span> <span data-ttu-id="bfda6-165">アプリにとって遅延読み込みが効果的かどうかを判断するには、アプリに対してプロファイリング ツールを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-165">You should use the profiling tools on your app to determine whether or not your app will benefit from deferred loading.</span></span>

### <a name="use-layout-panel-properties"></a><span data-ttu-id="bfda6-166">レイアウト パネルのプロパティを使う</span><span class="sxs-lookup"><span data-stu-id="bfda6-166">Use layout panel properties</span></span>

<span data-ttu-id="bfda6-167">レイアウト パネルには [Background](https://msdn.microsoft.com/library/windows/apps/BR227512) プロパティが用意されているため、色を付ける目的でパネルの前面に [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を配置する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-167">Layout panels have a [Background](https://msdn.microsoft.com/library/windows/apps/BR227512) property so there's no need to put a [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) in front of a Panel just to color it.</span></span>

**<span data-ttu-id="bfda6-168">非効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-168">Inefficient</span></span>**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Grid>
    <Rectangle Fill="Black"/>
</Grid>
```

**<span data-ttu-id="bfda6-169">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-169">Efficient</span></span>**

```xaml
<Grid Background="Black"/>
```

<span data-ttu-id="bfda6-170">レイアウト パネルには組み込みの境界線プロパティも用意されているため、レイアウト パネルの周りに [Border](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border) 要素を追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-170">Layout panels also have built-in border properties, so you don't need to put a [Border](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border) element around a layout panel.</span></span> <span data-ttu-id="bfda6-171">詳細と例については、「[XAML レイアウトの最適化](optimize-your-xaml-layout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfda6-171">See [Optimize your XAML layout](optimize-your-xaml-layout.md) for more info and examples.</span></span>

### <a name="use-images-in-place-of-vector-based-elements"></a><span data-ttu-id="bfda6-172">ベクター ベースの要素の代わりに画像を使う</span><span class="sxs-lookup"><span data-stu-id="bfda6-172">Use images in place of vector-based elements</span></span>

<span data-ttu-id="bfda6-173">同じベクター ベースの要素を十分な回数再利用する場合は、代わりに [Image](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) 要素を使うと効率が高まります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-173">If you reuse the same vector-based element enough times, it becomes more efficient to use an [Image](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) element instead.</span></span> <span data-ttu-id="bfda6-174">ベクター ベースの要素は、CPU が個々の要素をそれぞれ個別に作成する必要があるため、負荷が高くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-174">Vector-based elements can be more expensive because the CPU must create each individual element separately.</span></span> <span data-ttu-id="bfda6-175">これに対して画像ファイルは、1 回デコードするだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-175">The image file needs to be decoded only once.</span></span>

## <a name="optimize-resources-and-resource-dictionaries"></a><span data-ttu-id="bfda6-176">リソースとリソース ディクショナリの最適化</span><span class="sxs-lookup"><span data-stu-id="bfda6-176">Optimize resources and resource dictionaries</span></span>

<span data-ttu-id="bfda6-177">通常、アプリ内の複数の場所から参照されるリソースをある程度グローバルに格納するには、[リソース ディクショナリ](../design/controls-and-patterns/resourcedictionary-and-xaml-resource-references.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-177">You typically use [resource dictionaries](../design/controls-and-patterns/resourcedictionary-and-xaml-resource-references.md) to store, at a somewhat global level, resources that you want to reference in multiple places in your app.</span></span> <span data-ttu-id="bfda6-178">このようなリソースには、スタイル、ブラシ、テンプレートなどがあります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-178">For example, styles, brushes, templates, and so on.</span></span>

<span data-ttu-id="bfda6-179">一般に、[ResourceDictionary](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.ResourceDictionary) は、要求されない限りリソースをインスタンス化しないように最適化されています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-179">In general, we have optimized [ResourceDictionary](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.ResourceDictionary) to not instantiate resources unless they're asked for.</span></span> <span data-ttu-id="bfda6-180">ただし、リソースが不要にインスタンス化されないようにするために、避けた方がよい状況もあります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-180">But there are situations you should avoid so that resources aren’t instantiated unnecessarily.</span></span>

### <a name="resources-with-xname"></a><span data-ttu-id="bfda6-181">x:Name を含むリソース</span><span class="sxs-lookup"><span data-stu-id="bfda6-181">Resources with x:Name</span></span>

<span data-ttu-id="bfda6-182">リソースを参照するときは、[x:Key 属性](../xaml-platform/x-key-attribute.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-182">Use the [x:Key attribute](../xaml-platform/x-key-attribute.md) to reference your resources.</span></span> <span data-ttu-id="bfda6-183">[x:Name 属性](../xaml-platform/x-name-attribute.md)を持つリソースは、プラットフォームの最適化のメリットが適用されず、ResourceDictionary が作成されるとすぐにインスタンス化されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-183">Any resource with the [x:Name attribute](../xaml-platform/x-name-attribute.md) will not benefit from the platform optimization; instead, it is instantiated as soon as the ResourceDictionary is created.</span></span> <span data-ttu-id="bfda6-184">これは、x: Name がプラットフォームに対し、アプリがこのリソースへのフィールド アクセスを必要としており、プラットフォームは参照を作成するものを何か作成する必要があると指示するからです。</span><span class="sxs-lookup"><span data-stu-id="bfda6-184">This happens because x:Name tells the platform that your app needs field access to this resource, so the platform needs to create something to create a reference to.</span></span>

### <a name="resourcedictionary-in-a-usercontrol"></a><span data-ttu-id="bfda6-185">UserControl 内の ResourceDictionary</span><span class="sxs-lookup"><span data-stu-id="bfda6-185">ResourceDictionary in a UserControl</span></span>

<span data-ttu-id="bfda6-186">[UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol) の内部に定義された ResourceDictionary にはペナルティが発生します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-186">A ResourceDictionary defined inside of a [UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol) carries a penalty.</span></span> <span data-ttu-id="bfda6-187">プラットフォームは、UserControl のすべてのインスタンスに対して、このような ResourceDictionary のコピーを作成します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-187">The platform creates a copy of such a ResourceDictionary for every instance of the UserControl.</span></span> <span data-ttu-id="bfda6-188">よく使われる UserControl を使っている場合、UserControl から ResourceDictionary を移動し、ページ レベルに配置します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-188">If you have a UserControl that is used a lot, then move the ResourceDictionary out of the UserControl and put it the page level.</span></span>

### <a name="resource-and-resourcedictionary-scope"></a><span data-ttu-id="bfda6-189">リソースと ResourceDictionary のスコープ</span><span class="sxs-lookup"><span data-stu-id="bfda6-189">Resource and ResourceDictionary scope</span></span>

<span data-ttu-id="bfda6-190">ページで参照しているユーザー コントロールやリソースが別のファイルに定義されている場合は、そのファイルもフレームワークによって解析されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-190">If a page references a user control or a resource defined in a different file, then the framework parses that file, too.</span></span>

<span data-ttu-id="bfda6-191">次の例では、_InitialPage.xaml_ で _ExampleResourceDictionary.xaml_ のリソースが 1 つ使われているため、起動時に _ExampleResourceDictionary.xaml_ 全体を解析する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-191">Here, because _InitialPage.xaml_ uses one resource from _ExampleResourceDictionary.xaml_, the whole of _ExampleResourceDictionary.xaml_ must be parsed at startup.</span></span>

**<span data-ttu-id="bfda6-192">InitialPage.xaml</span><span class="sxs-lookup"><span data-stu-id="bfda6-192">InitialPage.xaml.</span></span>**

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

**<span data-ttu-id="bfda6-193">ExampleResourceDictionary.xaml</span><span class="sxs-lookup"><span data-stu-id="bfda6-193">ExampleResourceDictionary.xaml.</span></span>**

```xaml
<ResourceDictionary>
    <SolidColorBrush x:Key="TextBrush" Color="#FF3F42CC"/>

    <!--This ResourceDictionary contains many other resources that
        are used in the app, but are not needed during startup.-->
</ResourceDictionary>
```

<span data-ttu-id="bfda6-194">1 つのリソースをアプリ全体の多くのページで使う場合、そのリソースを _App.xaml_ に格納することをお勧めします。これにより、重複を避けることができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-194">If you use a resource on many pages throughout your app, then storing it in _App.xaml_ is a good practice, and avoids duplication.</span></span> <span data-ttu-id="bfda6-195">ただし、_App.xaml_ はアプリの起動時に解析されるため、1 つのページでしか使われないリソースは、(そのページが最初のページでない限り) ページのローカル リソースに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-195">But _App.xaml_ is parsed at app startup so any resource that is used in only one page (unless that page is the initial page) should be put into the page's local resources.</span></span> <span data-ttu-id="bfda6-196">次の例は、(最初のページ以外の) 1 つのページでしか使われないリソースを含む _App.xaml_ を示しています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-196">This example shows _App.xaml_ containing resources that are used by only one page (that's not the initial page).</span></span> <span data-ttu-id="bfda6-197">この場合、アプリの起動時間が不必要に増加します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-197">This needlessly increases app startup time.</span></span>

**<span data-ttu-id="bfda6-198">App.xaml</span><span class="sxs-lookup"><span data-stu-id="bfda6-198">App.xaml</span></span>**

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

**<span data-ttu-id="bfda6-199">InitialPage.xaml</span><span class="sxs-lookup"><span data-stu-id="bfda6-199">InitialPage.xaml.</span></span>**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Page x:Class="ExampleNamespace.InitialPage" ...>
    <StackPanel>
        <TextBox Foreground="{StaticResource InitialPageTextBrush}"/>
    </StackPanel>
</Page>
```

**<span data-ttu-id="bfda6-200">SecondPage.xaml</span><span class="sxs-lookup"><span data-stu-id="bfda6-200">SecondPage.xaml.</span></span>**

```xaml
<!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE. -->
<Page x:Class="ExampleNamespace.SecondPage" ...>
    <StackPanel>
        <Button Content="Submit" Foreground="{StaticResource SecondPageTextBrush}" />
    </StackPanel>
</Page>
```

<span data-ttu-id="bfda6-201">この例の効率を改善するには、`SecondPageTextBrush` を _SecondPage.xaml_ に移動し、`ThirdPageTextBrush` を _ThirdPage.xaml_ に移動します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-201">To make this example more efficient, move `SecondPageTextBrush` into _SecondPage.xaml_ and move `ThirdPageTextBrush` into _ThirdPage.xaml_.</span></span> `InitialPageTextBrush` <span data-ttu-id="bfda6-202"> については、どの場合でもアプリの起動時にアプリケーション リソースを解析する必要があるため、_App.xaml_ 内に残しておくことができます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-202">can remain in _App.xaml_ because application resources must be parsed at app startup in any case.</span></span>

### <a name="consolidate-multiple-brushes-that-look-the-same-into-one-resource"></a><span data-ttu-id="bfda6-203">同じように見える複数のブラシを 1 つのリソースに統合する</span><span class="sxs-lookup"><span data-stu-id="bfda6-203">Consolidate multiple brushes that look the same into one resource</span></span>

<span data-ttu-id="bfda6-204">XAML プラットフォームは、よく使われるオブジェクトをキャッシュして、何度も再利用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-204">The XAML platform tries to cache commonly-used objects so that they can be reused as often as possible.</span></span> <span data-ttu-id="bfda6-205">しかし、あるマークアップで宣言されているブラシが別のマークアップで宣言されているブラシと同じであるかどうかは簡単に判断できません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-205">But XAML cannot easily tell if a brush declared in one piece of markup is the same as a brush declared in another.</span></span> <span data-ttu-id="bfda6-206">ここでは、例として [SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962) を使っていますが、より多く使われる可能性があって重要なのは [GradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210068) です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-206">The example here uses [SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962) to demonstrate, but the case is more likely and more important with [GradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210068).</span></span> <span data-ttu-id="bfda6-207">また、事前定義された色を使うブラシもチェックする必要があります。たとえば、`"Orange"` と `"#FFFFA500"` は同じ色です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-207">Also check for brushes that use predefined colors; for example, `"Orange"` and `"#FFFFA500"` are the same color.</span></span>

**<span data-ttu-id="bfda6-208">非効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-208">Inefficient.</span></span>**

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

<span data-ttu-id="bfda6-209">重複を除去するには、ブラシをリソースとして定義します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-209">To fix the duplication, define the brush as a resource.</span></span> <span data-ttu-id="bfda6-210">他のページのコントロールで同じブラシを使う場合は、ブラシを _App.xaml_ に移動します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-210">If controls in other pages use the same brush, move it to _App.xaml_.</span></span>

**<span data-ttu-id="bfda6-211">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-211">Efficient.</span></span>**

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

## <a name="minimize-overdrawing"></a><span data-ttu-id="bfda6-212">過剰な描画の最小化</span><span class="sxs-lookup"><span data-stu-id="bfda6-212">Minimize overdrawing</span></span>

<span data-ttu-id="bfda6-213">過剰な描画は、画面上の同じピクセルに複数のオブジェクトが描画される場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-213">Overdrawing occurs where more than one object is drawn in the same screen pixels.</span></span> <span data-ttu-id="bfda6-214">ただし、このガイダンスと要素数を最小限に抑えたいという要求は両立せず、トレードオフが必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-214">Note that there is sometimes a trade-off between this guidance and the desire to minimize element count.</span></span>

<span data-ttu-id="bfda6-215">視覚的な診断には、[**DebugSettings.IsOverdrawHeatMapEnabled**](https://msdn.microsoft.com/library/windows/apps/Hh701823) を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-215">Use [**DebugSettings.IsOverdrawHeatMapEnabled**](https://msdn.microsoft.com/library/windows/apps/Hh701823) as a visual diagnostic.</span></span> <span data-ttu-id="bfda6-216">シーンに存在するとは思わなかったオブジェクトが描画されていることに気付く場合があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-216">You might find objects being drawn that you didn't know were in the scene.</span></span>

### <a name="transparent-or-hidden-elements"></a><span data-ttu-id="bfda6-217">透明または非表示の要素</span><span class="sxs-lookup"><span data-stu-id="bfda6-217">Transparent or hidden elements</span></span>

<span data-ttu-id="bfda6-218">要素が透明であるか、他の要素の背後に隠れているために表示されず、レイアウトに関与していない場合は、その要素を削除することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-218">If an element isn't visible because it's transparent or hidden behind other elements, and it's not contributing to layout, then delete it.</span></span> <span data-ttu-id="bfda6-219">初期の表示状態では要素が表示されないものの、他の表示状態で表示される場合は、x:Load を使ってその状態を制御するか、要素自体の [Visibility](https://msdn.microsoft.com/library/windows/apps/BR208992) を **Collapsed** に設定しておいて、該当の状態になったら値を **Visible** に変更します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-219">If the element is not visible in the initial visual state but it is visible in other visual states, then use x:Load to control its state or set [Visibility](https://msdn.microsoft.com/library/windows/apps/BR208992) to **Collapsed** on the element itself and change the value to **Visible** in the appropriate states.</span></span> <span data-ttu-id="bfda6-220">このヒューリスティックには例外があります。一般に、要素にローカルに設定する表示状態は、プロパティに設定されていることが最も多い値にするのが最良です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-220">There will be exceptions to this heuristic: in general, the value a property has in the majority of visual states is best set locally on the element.</span></span>

### <a name="composite-elements"></a><span data-ttu-id="bfda6-221">複合要素</span><span class="sxs-lookup"><span data-stu-id="bfda6-221">Composite elements</span></span>

<span data-ttu-id="bfda6-222">複数の要素を重ねて効果を作成する代わりに、複合要素を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-222">Use a composite element instead of layering multiple elements to create an effect.</span></span> <span data-ttu-id="bfda6-223">次の例では、結果は 2 色の図形になり、上半分は黒 ([Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) の背景)、下半分は灰色 (**Grid** の黒い背景の上にアルファ ブレンドされた半透明の白い [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle)) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-223">In this example, the result is a two-toned shape where the top half is black (from the background of the [Grid](https://msdn.microsoft.com/library/windows/apps/BR242704)) and the bottom half is gray (from the semi-transparent white [Rectangle](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) alpha-blended over the black background of the **Grid**).</span></span> <span data-ttu-id="bfda6-224">この場合、結果を得るために必要なピクセルの 150% が塗りつぶされることになります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-224">Here, 150% of the pixels necessary to achieve the result are being filled.</span></span>

**<span data-ttu-id="bfda6-225">非効率的。</span><span class="sxs-lookup"><span data-stu-id="bfda6-225">Inefficient.</span></span>**

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

**<span data-ttu-id="bfda6-226">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-226">Efficient.</span></span>**

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

### <a name="layout-panels"></a><span data-ttu-id="bfda6-227">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="bfda6-227">Layout panels</span></span>

<span data-ttu-id="bfda6-228">レイアウト パネルには、領域の色指定と、子要素のレイアウトの 2 つの目的があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-228">A layout panel can have two purposes: to color an area, and to lay out child elements.</span></span> <span data-ttu-id="bfda6-229">z オーダーの要素の領域が既に塗られている場合は、前面のレイアウト パネルでその領域を塗りつぶす必要はありません。代わりに、パネルではその子を重点的にレイアウトします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-229">If an element further back in z-order is already coloring an area then a layout panel in front does not need to paint that area: instead it can just focus on laying out its children.</span></span> <span data-ttu-id="bfda6-230">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-230">Here's an example.</span></span>

**<span data-ttu-id="bfda6-231">非効率的。</span><span class="sxs-lookup"><span data-stu-id="bfda6-231">Inefficient.</span></span>**

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

**<span data-ttu-id="bfda6-232">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-232">Efficient.</span></span>**

```xaml
<GridView Background="Blue">
    <GridView.ItemTemplate>
        <DataTemplate>
            <Grid/>
        </DataTemplate>
    </GridView.ItemTemplate>
</GridView>
```

<span data-ttu-id="bfda6-233">[Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) のヒット テストを可能にするには、その背景の値を透明に設定します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-233">If the [Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) has to be hit-testable then set a background value of transparent on it.</span></span>

### <a name="borders"></a><span data-ttu-id="bfda6-234">境界線</span><span class="sxs-lookup"><span data-stu-id="bfda6-234">Borders</span></span>

<span data-ttu-id="bfda6-235">オブジェクトの周りに境界線を描画するには、[Border](https://msdn.microsoft.com/library/windows/apps/BR209253) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="bfda6-235">Use a [Border](https://msdn.microsoft.com/library/windows/apps/BR209253) element to draw a border around an object.</span></span> <span data-ttu-id="bfda6-236">次の例では、[TextBox](https://msdn.microsoft.com/library/windows/apps/BR209683) を囲む間に合わせの境界線として [Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) を使用しています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-236">In this example, a [Grid](https://msdn.microsoft.com/library/windows/apps/BR242704) is used as a makeshift border around a [TextBox](https://msdn.microsoft.com/library/windows/apps/BR209683).</span></span> <span data-ttu-id="bfda6-237">この方法では、中央のセル内のすべてのピクセルが複数回描画されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-237">But all the pixels in the center cell are overdrawn.</span></span>

**<span data-ttu-id="bfda6-238">非効率的。</span><span class="sxs-lookup"><span data-stu-id="bfda6-238">Inefficient.</span></span>**

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

**<span data-ttu-id="bfda6-239">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-239">Efficient.</span></span>**

```xaml
 <Border BorderBrush="Blue" BorderThickness="5" Width="300" Height="45">
     <TextBox/>
</Border>
```

### <a name="margins"></a><span data-ttu-id="bfda6-240">余白</span><span class="sxs-lookup"><span data-stu-id="bfda6-240">Margins</span></span>

<span data-ttu-id="bfda6-241">余白に注意してください。</span><span class="sxs-lookup"><span data-stu-id="bfda6-241">Be aware of margins.</span></span> <span data-ttu-id="bfda6-242">負の余白が隣の要素のレンダリング境界に達すると、隣り合った 2 つの要素が (意図せずに) 重なり合い、過剰な描画を引き起こします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-242">Two neighboring elements will overlap (possibly accidentally) if negative margins extend into another’s render bounds and cause overdrawing.</span></span>

### <a name="cache-static-content"></a><span data-ttu-id="bfda6-243">静的コンテンツのキャッシュ</span><span class="sxs-lookup"><span data-stu-id="bfda6-243">Cache static content</span></span>

<span data-ttu-id="bfda6-244">過剰な描画の別の原因として、多数の要素を重ね合わせて作成される図形があります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-244">Another source of overdrawing is a shape made from many overlapping elements.</span></span> <span data-ttu-id="bfda6-245">複合図形を含む [UIElement](https://msdn.microsoft.com/library/windows/apps/BR208911) で [CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084) を **BitmapCache** に設定すると、プラットフォームによって要素がいったんビットマップにレンダリングされ、何度も描画する代わりに、そのビットマップが各フレームで使われます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-245">If you set [CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084) to **BitmapCache** on the [UIElement](https://msdn.microsoft.com/library/windows/apps/BR208911) that contains the composite shape then the platform renders the element to a bitmap once and then uses that bitmap each frame instead of overdrawing.</span></span>

**<span data-ttu-id="bfda6-246">非効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-246">Inefficient.</span></span>**

```xaml
<Canvas Background="White">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

![単色の 3 つの円を使ったベン図](images/solidvenn.png)

<span data-ttu-id="bfda6-248">上の図がその結果ですが、過剰に描画された領域のマップは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="bfda6-248">The image above is the result, but here's a map of the overdrawn regions.</span></span> <span data-ttu-id="bfda6-249">赤色が濃いほど、描画回数が多いことを示しています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-249">Darker red indicates higher amounts of overdraw.</span></span>

![重なっている部分がわかるベン図](images/translucentvenn.png)

**<span data-ttu-id="bfda6-251">効率的</span><span class="sxs-lookup"><span data-stu-id="bfda6-251">Efficient.</span></span>**

```xaml
<Canvas Background="White" CacheMode="BitmapCache">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

<span data-ttu-id="bfda6-252">[CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084) を使っていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="bfda6-252">Note the use of [CacheMode](https://msdn.microsoft.com/library/windows/apps/BR228084).</span></span> <span data-ttu-id="bfda6-253">サブ図形がアニメーション化されている場合は、この方法を使わないでください。その目的に反し、各フレームでビットマップ キャッシュを再生成することが必要になる可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="bfda6-253">Don't use this technique if any of the sub-shapes animate because the bitmap cache will likely need to be regenerated every frame, defeating the purpose.</span></span>

## <a name="use-xbf2"></a><span data-ttu-id="bfda6-254">XBF2 の使用</span><span class="sxs-lookup"><span data-stu-id="bfda6-254">Use XBF2</span></span>

<span data-ttu-id="bfda6-255">XBF2 は、実行時にすべてのテキスト解析コストを回避する XAML マークアップのバイナリ表現です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-255">XBF2 is a binary representation of XAML markup that avoids all text-parsing costs at runtime.</span></span> <span data-ttu-id="bfda6-256">また、読み込みとツリーの作成のためにバイナリを最適化し、VSM、ResourceDictionary、Styles などのヒープやオブジェクトの作成コストを改善するために XAML 型の "高速パス" を使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-256">It also optimizes your binary for load and tree creation, and allows "fast-path" for XAML types to improve heap and object creation costs, for example VSM, ResourceDictionary, Styles, and so on.</span></span> <span data-ttu-id="bfda6-257">これは完全にメモリ マッピングされるため、XAML ページの読み込みや読み取りにヒープは使用されません。</span><span class="sxs-lookup"><span data-stu-id="bfda6-257">It is completely memory-mapped so there is no heap footprint for loading and reading a XAML Page.</span></span> <span data-ttu-id="bfda6-258">さらに、appx に保存している XAML ページのディスク使用量が削減されます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-258">In addition, it reduces the disk footprint of stored XAML pages in an appx.</span></span> <span data-ttu-id="bfda6-259">XBF2 はよりコンパクトな表現であり、同等の XAML/XBF1 ファイルのディスク使用量を最大 50% 削減できます。</span><span class="sxs-lookup"><span data-stu-id="bfda6-259">XBF2 is a more compact representation and it can reduce disk footprint of comparative XAML/XBF1 files by up to 50%.</span></span> <span data-ttu-id="bfda6-260">たとえば、組み込みのフォト アプリの場合、XBF2 への変換によって、およそ 1 MB の XBF1 アセットが 400 KB の XBF2 アセットに縮小され、約 60% の削減が実現されました。</span><span class="sxs-lookup"><span data-stu-id="bfda6-260">For example, the built-in Photos app saw around a 60% reduction after conversion to XBF2 dropping from around ~1mb of XBF1 assets to ~400kb of XBF2 assets.</span></span> <span data-ttu-id="bfda6-261">また、CPU で 15 ～ 20%、Win32 ヒープで 10 ～ 15% のメリットをアプリにもたらします。</span><span class="sxs-lookup"><span data-stu-id="bfda6-261">We have also seen apps benefit anywhere from 15 to 20% in CPU and 10 to 15% in Win32 heap.</span></span>

<span data-ttu-id="bfda6-262">フレームワークが提供する XAML の組み込みのコントロールとディクショナリは、既に XBF2 に完全に対応しています。</span><span class="sxs-lookup"><span data-stu-id="bfda6-262">XAML built-in controls and dictionaries that the framework provides are already fully XBF2-enabled.</span></span> <span data-ttu-id="bfda6-263">独自のアプリでは、プロジェクト ファイルで TargetPlatformVersion 8.2 以降を宣言していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bfda6-263">For your own app, ensure that your project file declares TargetPlatformVersion 8.2 or later.</span></span>

<span data-ttu-id="bfda6-264">XBF2 があるかどうかを確認するには、バイナリ エディターでアプリを開きます。XBF2 がある場合、12 番目と 13 番目のバイトは 00 02 です。</span><span class="sxs-lookup"><span data-stu-id="bfda6-264">To check whether you have XBF2, open your app in a binary editor; the 12th and 13th bytes are 00 02 if you have XBF2.</span></span>

## <a name="related-articles"></a><span data-ttu-id="bfda6-265">関連記事</span><span class="sxs-lookup"><span data-stu-id="bfda6-265">Related articles</span></span>

- [<span data-ttu-id="bfda6-266">アプリ起動時のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="bfda6-266">Best practices for your app's startup performance</span></span>](best-practices-for-your-app-s-startup-performance.md)
- [<span data-ttu-id="bfda6-267">XAML レイアウトの最適化</span><span class="sxs-lookup"><span data-stu-id="bfda6-267">Optimize your XAML layout</span></span>](optimize-your-xaml-layout.md)
- [<span data-ttu-id="bfda6-268">ListView と GridView の UI の最適化</span><span class="sxs-lookup"><span data-stu-id="bfda6-268">ListView and GridView UI optimization</span></span>](optimize-gridview-and-listview.md)
- [<span data-ttu-id="bfda6-269">プロファイリングとパフォーマンスに関するツール</span><span class="sxs-lookup"><span data-stu-id="bfda6-269">Tools for profiling and performance</span></span>](tools-for-profiling-and-performance.md)
