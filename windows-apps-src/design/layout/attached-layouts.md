---
Description: ItemsRepeater コントロールなどのコンテナーで使用するために接続されているレイアウトを定義することができます。
title: AttachedLayout
label: AttachedLayout
template: detail.hbs
ms.date: 03/13/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6ff73b13acb5f5970bb79755b0bf5706fb12545a
ms.sourcegitcommit: c10d7843ccacb8529cb1f53948ee0077298a886d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58913992"
---
# <a name="attached-layouts"></a><span data-ttu-id="dfdcb-104">接続されているレイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-104">Attached Layouts</span></span>

<span data-ttu-id="dfdcb-105">別のオブジェクトには、そのレイアウト ロジックをデリゲートするコンテナー (パネルなど) は、その子要素のレイアウト動作を提供する添付レイアウト オブジェクトに依存します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-105">A container (e.g. Panel) that delegates its layout logic to another object relies on the attached layout object to provide the layout behavior for its child elements.</span></span>  <span data-ttu-id="dfdcb-106">UI (列内で整列させる表示されるテーブルの行の項目など) のさまざまな部分の間でのレイアウトの側面をより簡単に共有または、接続されているレイアウト モデルは、実行時に項目のレイアウトを変更するアプリケーションの柔軟性を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-106">An attached layout model provides flexibility for an application to alter the layout of items at runtime, or more easily share aspects of layout between different parts of the UI (e.g. items in the rows of a table that appear to be aligned within a column).</span></span>

<span data-ttu-id="dfdcb-107">このトピックで、接続されているレイアウト (仮想化と非仮想化)、概念と詳細については、必要になるクラスを作成する手順について説明し、上のトレードオフそれらの間を決定する際に考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-107">In this topic, we cover what's involved in creating an attached layout (virtualizing and non-virtualizing), the concepts and classes you'll need to understand, and the trade-offs you'll need to consider when deciding between them.</span></span>

| **<span data-ttu-id="dfdcb-108">Windows UI ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="dfdcb-108">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="dfdcb-109">このコントロールは、Windows の UI ライブラリを新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-109">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="dfdcb-110">インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-110">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

> <span data-ttu-id="dfdcb-111">**重要な API**:</span><span class="sxs-lookup"><span data-stu-id="dfdcb-111">**Important APIs**:</span></span>

> * [<span data-ttu-id="dfdcb-112">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="dfdcb-112">ScrollViewer</span></span>](/uwp/api/windows.ui.xaml.controls.scrollviewer)
> * [<span data-ttu-id="dfdcb-113">ItemsRepeater</span><span class="sxs-lookup"><span data-stu-id="dfdcb-113">ItemsRepeater</span></span>](/windows/uwp/design/controls-and-patterns/items-repeater)
> * [<span data-ttu-id="dfdcb-114">レイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-114">Layout</span></span>](/uwp/api/microsoft.ui.xaml.controls.layout)
>     * [<span data-ttu-id="dfdcb-115">NonVirtualizingLayout</span><span class="sxs-lookup"><span data-stu-id="dfdcb-115">NonVirtualizingLayout</span></span>](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout)
>     * [<span data-ttu-id="dfdcb-116">VirtualizingLayout</span><span class="sxs-lookup"><span data-stu-id="dfdcb-116">VirtualizingLayout</span></span>](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)
> * [<span data-ttu-id="dfdcb-117">LayoutContext</span><span class="sxs-lookup"><span data-stu-id="dfdcb-117">LayoutContext</span></span>](/uwp/api/microsoft.ui.xaml.controls.layoutcontext)
>     * [<span data-ttu-id="dfdcb-118">NonVirtualizingLayoutContext</span><span class="sxs-lookup"><span data-stu-id="dfdcb-118">NonVirtualizingLayoutContext</span></span>](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext)
>     * [<span data-ttu-id="dfdcb-119">VirtualizingLayoutContext</span><span class="sxs-lookup"><span data-stu-id="dfdcb-119">VirtualizingLayoutContext</span></span>](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)
> * <span data-ttu-id="dfdcb-120">[LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel) (プレビュー)</span><span class="sxs-lookup"><span data-stu-id="dfdcb-120">[LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel) (Preview)</span></span>

## <a name="key-concepts"></a><span data-ttu-id="dfdcb-121">主要概念</span><span class="sxs-lookup"><span data-stu-id="dfdcb-121">Key Concepts</span></span>

<span data-ttu-id="dfdcb-122">レイアウトを実行するには、すべての要素の 2 つの質問に応答することが必要です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-122">Performing layout requires that two questions be answered for every element:</span></span>

1. <span data-ttu-id="dfdcb-123">どのような***サイズ***この要素になりますか?</span><span class="sxs-lookup"><span data-stu-id="dfdcb-123">What ***size*** will this element be?</span></span>

2. <span data-ttu-id="dfdcb-124">どのような***位置***この要素のでしょうか。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-124">What will the ***position*** of this element be?</span></span>

<span data-ttu-id="dfdcb-125">XAML のレイアウト システムは、これらの質問の回答はのディスカッションの一部として対象について簡単に[カスタム パネル](/windows/uwp/design/layout/custom-panels-overview)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-125">XAML's layout system, which answers these questions, is briefly covered as part of the discussion of [Custom panels](/windows/uwp/design/layout/custom-panels-overview).</span></span>

### <a name="containers-and-context"></a><span data-ttu-id="dfdcb-126">コンテナーとコンテキスト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-126">Containers and Context</span></span>

<span data-ttu-id="dfdcb-127">概念的には、XAML の[パネル](/uwp/api/windows.ui.xaml.controls.panel)フレームワークで 2 つの重要な役割を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-127">Conceptually, XAML's [Panel](/uwp/api/windows.ui.xaml.controls.panel) fills two important roles in the framework:</span></span>

1. <span data-ttu-id="dfdcb-128">子要素を含めることができ、要素のツリーの分岐が導入されています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-128">It can contain child elements and introduces branching in the tree of elements.</span></span>
2. <span data-ttu-id="dfdcb-129">特定のレイアウトの戦略は、これらの子に適用されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-129">It applies a specific layout strategy to those children.</span></span>

<span data-ttu-id="dfdcb-130">このため、XAML 内のパネルが多くの場合、レイアウトが厳密に言うと同義はレイアウトだけです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-130">For this reason, a Panel in XAML has often been synonymous with layout, but technically-speaking, does more than just layout.</span></span>

<span data-ttu-id="dfdcb-131">[ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)動作と同様に、パネルが、パネルとは異なり、UIElement の子をプログラムで追加または削除できるようにする Children プロパティは公開されません。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-131">The [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater) also behaves like Panel, but, unlike Panel, it does not expose a Children property that would allow programmatically adding or removing UIElement children.</span></span>  <span data-ttu-id="dfdcb-132">代わりに、その子の有効期間はデータ項目のコレクションに対応するためにフレームワークによって自動的に管理されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-132">Instead, the lifetime of its children are automatically managed by the framework to correspond to a collection of data items.</span></span>  <span data-ttu-id="dfdcb-133">それから派生していないパネルが動作し、パネルのように、フレームワークによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-133">Although it is not derived from Panel, it behaves and is treated by the framework like a Panel.</span></span>

> [!NOTE]
> <span data-ttu-id="dfdcb-134">[LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel)パネルで、添付するには、そのロジックをデリゲートする派生コンテナー[レイアウト](/uwp/api/microsoft.ui.xaml.controls.layoutpanel.layout)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-134">The [LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel) is a container, derived from Panel, that delegates its logic to the attached [Layout](/uwp/api/microsoft.ui.xaml.controls.layoutpanel.layout) object.</span></span>  <span data-ttu-id="dfdcb-135">LayoutPanel が*プレビュー*だけでは、現在ご利用いただけます、*プレリリース*WinUI パッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-135">LayoutPanel is in *Preview* and is currently available only in the *Prerelease* drops of the WinUI package.</span></span>

#### <a name="containers"></a><span data-ttu-id="dfdcb-136">コンテナー</span><span class="sxs-lookup"><span data-stu-id="dfdcb-136">Containers</span></span>

<span data-ttu-id="dfdcb-137">概念的には、[パネル](/uwp/api/windows.ui.xaml.controls.panel)要素のコンテナーであり、ピクセルをレンダリングする機能もありますが、[バック グラウンド](/uwp/api/windows.ui.xaml.controls.panel.background)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-137">Conceptually, [Panel](/uwp/api/windows.ui.xaml.controls.panel) is a container of elements that also has the ability to render pixels for a [Background](/uwp/api/windows.ui.xaml.controls.panel.background).</span></span>  <span data-ttu-id="dfdcb-138">パネルは、使いやすいパッケージに共通のレイアウト ロジックをカプセル化する方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-138">Panels provide a way to encapsulate common layout logic in an easy to use package.</span></span>

<span data-ttu-id="dfdcb-139">概念**レイアウトがアタッチされている**コンテナーの 2 つのロールとレイアウトの明確な区別します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-139">The concept of **attached layout** makes the distinction between the two roles of container and layout more clear.</span></span>  <span data-ttu-id="dfdcb-140">コンテナーを別のオブジェクトのレイアウト ロジックを委任する場合はそのオブジェクトを呼び出す接続されているレイアウト次のスニペットに示すよう。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-140">If the container delegates its layout logic to another object we would call that object the attached layout as seen in the snippet below.</span></span> <span data-ttu-id="dfdcb-141">コンテナーから継承する[FrameworkElement](/uwp/api/windows.ui.xaml.frameworkelement)など、LayoutPanel XAML のレイアウト プロセス (高さや幅など) への入力を提供する共通のプロパティを自動的に公開します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-141">Containers that inherit from [FrameworkElement](/uwp/api/windows.ui.xaml.frameworkelement), such as the LayoutPanel, automatically expose the common properties that provide input to XAML's layout process (e.g. Height and Width).</span></span>

```xaml
<LayoutPanel>
    <LayoutPanel.Layout>
        <UniformGridLayout/>
    </LayoutPanel.Layout>
    <Button Content="1"/>
    <Button Content="2"/>
    <Button Content="3"/>
</LayoutPanel>
```

<span data-ttu-id="dfdcb-142">レイアウトの処理中に、コンテナーが関連付けられているに依存*UniformGridLayout*を測定し、その子を配置します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-142">During the layout process the container relies on the attached *UniformGridLayout* to measure and arrange its children.</span></span>

#### <a name="per-container-state"></a><span data-ttu-id="dfdcb-143">コンテナーごとの状態</span><span class="sxs-lookup"><span data-stu-id="dfdcb-143">Per-Container State</span></span>

<span data-ttu-id="dfdcb-144">添付のレイアウトでレイアウト オブジェクトの 1 つのインスタンスが関連付けられている*多く*コンテナーは、次のスニペットのようにそのため、する必要がありますいないに依存したりは、ホスト コンテナーを直接参照します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-144">With an attached layout, a single instance of the layout object may be associated with *many* containers like in the snippet below; therefore, it must not depend on or directly reference the host container.</span></span>  <span data-ttu-id="dfdcb-145">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-145">For example:</span></span>

```xaml
<!-- ... --->
<Page.Resources>
    <ExampleLayout x:Name="exampleLayout"/>
<Page.Resources>

<LayoutPanel x:Name="example1" Layout="{StaticResource exampleLayout}"/>
<LayoutPanel x:Name="example2" Layout="{StaticResource exampleLayout}"/>
<!-- ... --->
```

<span data-ttu-id="dfdcb-146">このような状況の*ExampleLayout*そのレイアウトの計算にし、その状態が格納されている、他の 1 つのパネル内の要素のレイアウトに影響を回避するために使用する状態を慎重に検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-146">For this situation *ExampleLayout* must carefully consider the state that it uses in its layout calculation and where that state is stored to avoid impacting the layout for elements in one panel with the other.</span></span>  <span data-ttu-id="dfdcb-147">MeasureOverride、ArrangeOverride ロジックは、の値によって異なります。 カスタム パネルに似ていますがなります、*静的*プロパティ。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-147">It would be analogous to a custom Panel whose MeasureOverride and ArrangeOverride logic depends on the values of its *static* properties.</span></span>

#### <a name="layoutcontext"></a><span data-ttu-id="dfdcb-148">LayoutContext</span><span class="sxs-lookup"><span data-stu-id="dfdcb-148">LayoutContext</span></span>

<span data-ttu-id="dfdcb-149">目的、 [LayoutContext](/uwp/api/microsoft.ui.xaml.controls.layoutcontext)ような課題が処理することです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-149">The purpose of the [LayoutContext](/uwp/api/microsoft.ui.xaml.controls.layoutcontext) is to deal with those challenges.</span></span>  <span data-ttu-id="dfdcb-150">2 つの間の直接の依存関係を導入することがなく、子要素を取得するなど、ホスト コンテナーとやり取りできるように、接続されているレイアウトを提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-150">It provides the attached layout the ability to interact with the host container, such as retrieving child elements, without introducing a direct dependency between the two.</span></span> <span data-ttu-id="dfdcb-151">コンテキスト、レイアウトが必要ですが、コンテナーの子要素に関連する状態を保存することもできます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-151">The context also enables the layout to store any state it requires that might be related to the container's child elements.</span></span>

<span data-ttu-id="dfdcb-152">非仮想化の単純なレイアウトは、多くの場合、問題ないように、任意の状態を維持するためには必要ありません。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-152">Simple, non-virtualizing layouts often do not need to maintain any state, making it a non-issue.</span></span> <span data-ttu-id="dfdcb-153">ただし、グリッドなどのより複雑なレイアウトは、メジャーの間で状態を維持し、値を再計算を回避するために呼び出しを配置する選択できます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-153">A more complex layout, such as Grid, however, may choose to maintain state between the measure and arrange call to avoid re-computing a value.</span></span>

<span data-ttu-id="dfdcb-154">レイアウトの仮想化*多くの場合、* メジャーの間のいくつかの状態を維持し、反復的なレイアウト パスの間にも配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-154">Virtualizing layouts *often* need to maintain some state between both the measure and arrange as well as between iterative layout passes.</span></span>

#### <a name="initializing-and-uninitializing-per-container-state"></a><span data-ttu-id="dfdcb-155">初期化と初期化解除、コンテナーごとの状態</span><span class="sxs-lookup"><span data-stu-id="dfdcb-155">Initializing and Uninitializing Per-Container State</span></span>

<span data-ttu-id="dfdcb-156">レイアウトは、コンテナーに関連付けられている場合、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)メソッドは呼び出され、状態を格納するオブジェクトを初期化する機会を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-156">When a layout is attached to a container, its [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore) method is called and provides an opportunity to initialize an object to store state.</span></span>

<span data-ttu-id="dfdcb-157">同様に、ときに、レイアウトから削除される、コンテナー、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-157">Similarly, when the layout is being removed from a container, the [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore) method will be called.</span></span>  <span data-ttu-id="dfdcb-158">これにより、そのコンテナーに関連付けられている必要があるが、状態をクリーンアップする機会がレイアウト。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-158">This gives the layout an opportunity to clean up any state it had associated with that container.</span></span>

<span data-ttu-id="dfdcb-159">レイアウトの状態のオブジェクトをと共に格納されているし、でコンテナーから取得できる、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-159">The layout's state object can be stored with and retrieved from the container with the [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate) property on the context.</span></span>

### <a name="ui-virtualization"></a><span data-ttu-id="dfdcb-160">UI の仮想化</span><span class="sxs-lookup"><span data-stu-id="dfdcb-160">UI Virtualization</span></span>

<span data-ttu-id="dfdcb-161">UI の仮想化まで UI オブジェクトの作成を遅らせることを意味する_必要な場合_します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-161">UI virtualization means delaying the creation of a UI object until _when it's needed_.</span></span>  <span data-ttu-id="dfdcb-162">パフォーマンスを最適化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-162">It's a performance optimization.</span></span>  <span data-ttu-id="dfdcb-163">スクロールしないシナリオを決定する_必要なときに_アプリ固有の項目の任意の数に基づく可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-163">For non-scrolling scenarios determining _when needed_ may be based on any number of things that are app-specific.</span></span>  <span data-ttu-id="dfdcb-164">アプリのような場合、使用を検討する必要があります、 [x: 負荷](../../xaml-platform/x-load-attribute.md)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-164">In those cases, apps should consider using the [x:Load](../../xaml-platform/x-load-attribute.md).</span></span> <span data-ttu-id="dfdcb-165">レイアウトでは、特別な処理は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-165">It does not require any special handling in your layout.</span></span>

<span data-ttu-id="dfdcb-166">リストなどのスクロール ベースのシナリオで決定する_必要なときに_「でしょう、ユーザーに表示される」レイアウト プロセス中に配置された場所に大きく依存され、特別な考慮事項を必要とする多くの場合、に基づいて。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-166">In scrolling-based scenarios such as a list, determining _when needed_ is often based on "will it be visible to a user" which depends heavily on where it was placed during the layout process and requires special considerations.</span></span>  <span data-ttu-id="dfdcb-167">このシナリオでは、このドキュメントの焦点です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-167">This scenario is a focus for this document.</span></span>

> [!NOTE]
> <span data-ttu-id="dfdcb-168">このドキュメントでカバーされていません、スクロールしないシナリオで UI の仮想化シナリオのスクロールを有効にするのと同じ機能を適用できます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-168">Although not covered in this document, the same capabilities that enable UI virtualization in scrolling scenarios could be applied in non-scrolling scenarios.</span></span>  <span data-ttu-id="dfdcb-169">たとえば、データ ドリブン ツール バー コントロールが示さ、リサイクル/表示領域をオーバーフロー メニューと要素の移動で使用可能な領域の変更に応答コマンドの有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-169">For example, a data-driven ToolBar control that manages the lifetime of the commands it presents and responds to changes in available space by recycling / moving elements between a visible area and an overflow menu.</span></span>

## <a name="getting-started"></a><span data-ttu-id="dfdcb-170">作業の開始</span><span class="sxs-lookup"><span data-stu-id="dfdcb-170">Getting Started</span></span>

<span data-ttu-id="dfdcb-171">最初に、レイアウトを作成する必要がありますが、UI の仮想化をサポートする必要があるかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-171">First, decide whether the layout you need to create should support UI virtualization.</span></span>

**<span data-ttu-id="dfdcb-172">点に留意してください.</span><span class="sxs-lookup"><span data-stu-id="dfdcb-172">A few things to keep in mind…</span></span>**

1. <span data-ttu-id="dfdcb-173">非仮想化のレイアウトは、作成者に簡単です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-173">Non-virtualizing layouts are easier to author.</span></span> <span data-ttu-id="dfdcb-174">項目の数を小さくする場合は、非仮想化のレイアウトを作成し、ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-174">If the number of items will always be small then authoring a non-virtualizing layout is recommended.</span></span>
2. <span data-ttu-id="dfdcb-175">プラットフォームで動作する添付のレイアウトのセットを提供する、 [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater#change-the-layout-of-items)と[LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel)一般的なニーズをカバーします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-175">The platform provides a set of attached layouts that work with the [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater#change-the-layout-of-items) and [LayoutPanel](/uwp/api/microsoft.ui.xaml.controls.layoutpanel) to cover common needs.</span></span>  <span data-ttu-id="dfdcb-176">これらを理解して、カスタム レイアウトを定義する必要があるかを決定する前にします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-176">Familiarize yourself with those before deciding you need to define a custom layout.</span></span>
3. <span data-ttu-id="dfdcb-177">仮想化のレイアウトは、常に、いくつか追加の CPU とメモリ コスト/複雑さ/オーバーヘッド非仮想化のレイアウトと比較があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-177">Virtualizing layouts always have some additional CPU and memory cost/complexity/overhead compared to a non-virtualizing layout.</span></span>  <span data-ttu-id="dfdcb-178">3 倍のビューポートのサイズを一般に、子レイアウトが管理する必要がある場合は領域に合わせて可能性があります、向上率化レイアウトから表示できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-178">As a general rule of thumb if the children the layout will need to manage will likely fit in an area that is 3x the size of the viewport, then there may not be much gain from a virtualizing layout.</span></span> <span data-ttu-id="dfdcb-179">3 倍のサイズで、このドキュメントの後半で詳しく説明は、非同期の性質により、Windows と仮想化への影響のスクロールします、です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-179">The 3x size is discussed in greater detail later in this doc, but is due to the asynchronous nature of scrolling on Windows and its impact on virtualization.</span></span>

> [!TIP]
> <span data-ttu-id="dfdcb-180">既定の設定の参照のポイントとして、 [ListView](/uwp/api/windows.ui.xaml.controls.listview) (と[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)) がリサイクル先頭がないことまで、項目の数は、3 倍の現在のビューポートのサイズを入力するだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-180">As a point of reference, the default settings for the [ListView](/uwp/api/windows.ui.xaml.controls.listview) (and [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)) are that recycling doesn't begin until the number of items are enough to fill up 3x the size of the current viewport.</span></span>

**<span data-ttu-id="dfdcb-181">基本の種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-181">Choose your base type</span></span>**

![接続されているレイアウト階層](images/xaml-attached-layout-hierarchy.png)

<span data-ttu-id="dfdcb-183">基本[レイアウト](/uwp/api/microsoft.ui.xaml.controls.layout)型添付のレイアウトを作成するための開始点として機能する 2 つの派生型には。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-183">The base [Layout](/uwp/api/microsoft.ui.xaml.controls.layout) type has two derived types that serve as the start point for authoring an attached layout:</span></span>

1. [<span data-ttu-id="dfdcb-184">NonVirtualizingLayout</span><span class="sxs-lookup"><span data-stu-id="dfdcb-184">NonVirtualizingLayout</span></span>](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout)
2. [<span data-ttu-id="dfdcb-185">VirtualizingLayout</span><span class="sxs-lookup"><span data-stu-id="dfdcb-185">VirtualizingLayout</span></span>](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)

## <a name="non-virtualizing-layout"></a><span data-ttu-id="dfdcb-186">非仮想化のレイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-186">Non-Virtualizing Layout</span></span>

<span data-ttu-id="dfdcb-187">非仮想化のレイアウトを作成するためのアプローチは、ユーザーが作成するには理解、[カスタム パネル](/windows/uwp/design/layout/custom-panels-overview)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-187">The approach for creating a non-virtualizing layout should feel familiar to anyone that has created a [Custom Panel](/windows/uwp/design/layout/custom-panels-overview).</span></span>  <span data-ttu-id="dfdcb-188">同じ概念が適用されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-188">The same concepts apply.</span></span>  <span data-ttu-id="dfdcb-189">主な違いは、 [NonVirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext)使用へのアクセスを[子](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext.children)コレクション、およびレイアウトの選択状態を保存することがあります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-189">The primary difference is that a [NonVirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext) is used to access the [Children](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayoutcontext.children) collection, and layout may choose to store state.</span></span>

1. <span data-ttu-id="dfdcb-190">基本型から派生[NonVirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout) (パネル) の代わりにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-190">Derive from the base type [NonVirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout) (instead of Panel).</span></span>
2. <span data-ttu-id="dfdcb-191">*(省略可能)* 依存関係プロパティを定義する場合の変更は、レイアウトが無効にします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-191">*(Optional)* Define dependency properties that when changed will invalidate the layout.</span></span>
3. <span data-ttu-id="dfdcb-192">_(**新規**/省略可能)_ の一部として、レイアウトに必要な任意の状態オブジェクトの初期化、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-192">_(**New**/Optional)_ Initialize any state object required by the layout as part of the [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore).</span></span> <span data-ttu-id="dfdcb-193">使用して、ホスト コンテナーを格納すること、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストを提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-193">Stash it with the host container by using the [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate) provided with the context.</span></span>
4. <span data-ttu-id="dfdcb-194">オーバーライド、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.measureoverride)を呼び出すと、[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)メソッドのすべての子にします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-194">Override the [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.measureoverride) and call the [Measure](/uwp/api/windows.ui.xaml.uielement.measure) method on all the children.</span></span>
5. <span data-ttu-id="dfdcb-195">オーバーライド、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.arrangeoverride)を呼び出すと、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)メソッドのすべての子にします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-195">Override the [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.nonvirtualizinglayout.arrangeoverride) and call the [Arrange](/uwp/api/windows.ui.xaml.uielement.arrange) method on all the children.</span></span>
6. <span data-ttu-id="dfdcb-196">*(**新規**/省略可能)* の一部として保存された状態をクリーンアップ、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-196">*(**New**/Optional)* Clean up any saved state as part of the [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore).</span></span>

### <a name="example-a-simple-stack-layout-varying-sized-items"></a><span data-ttu-id="dfdcb-197">以下に例を示します。単純なスタック レイアウト (さまざまなサイズの項目)</span><span class="sxs-lookup"><span data-stu-id="dfdcb-197">Example: A Simple Stack Layout (Varying-Sized Items)</span></span>

![MyStackLayout](images/xaml-attached-layout-mystacklayout.png)

<span data-ttu-id="dfdcb-199">さまざまなサイズの項目の非常に基本的な非仮想化スタック レイアウトを次に示します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-199">Here is a very basic non-virtualizing stack layout of varying sized items.</span></span> <span data-ttu-id="dfdcb-200">レイアウトの動作を調整するすべてのプロパティが不足しています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-200">It lacks any properties to adjust the layout’s behavior.</span></span> <span data-ttu-id="dfdcb-201">次の実装では、レイアウトはコンテナーによって提供されるコンテキスト オブジェクトに依存する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-201">The implementation below illustrates how the layout relies on the context object provided by the container to:</span></span>

1. <span data-ttu-id="dfdcb-202">子の数を取得し、</span><span class="sxs-lookup"><span data-stu-id="dfdcb-202">Get the count of children, and</span></span>
2. <span data-ttu-id="dfdcb-203">各子要素のインデックスを使用してアクセスします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-203">Access each child element by index.</span></span>

```csharp
public class MyStackLayout : NonVirtualizingLayout
{
    protected override Size MeasureOverride(NonVirtualizingLayoutContext context, Size availableSize)
    {
        double extentHeight = 0.0;
        foreach (var element in context.Children)
        {
            element.Measure(availableSize);
            extentHeight += element.DesiredSize.Height;
        }

        return new Size(availableSize.Width, extentHeight);
    }

    protected override Size ArrangeOverride(NonVirtualizingLayoutContext context, Size finalSize)
    {
        double offset = 0.0;
        foreach (var element in context.Children)
        {
            element.Arrange(
                new Rect(0, offset, finalSize.Width, element.DesiredSize.Height));
            offset += element.DesiredSize.Height;
        }

        return finalSize;
    }
}
```

```xaml
 <LayoutPanel MaxWidth="196">
    <LayoutPanel.Layout>
        <local:MyStackLayout/>
    </LayoutPanel.Layout>

    <Button HorizontalAlignment="Stretch">1</Button>
    <Button HorizontalAlignment="Right">2</Button>
    <Button HorizontalAlignment="Center">3</Button>
    <Button>4</Button>

</LayoutPanel>
```

## <a name="virtualizing-layouts"></a><span data-ttu-id="dfdcb-204">レイアウトの仮想化</span><span class="sxs-lookup"><span data-stu-id="dfdcb-204">Virtualizing Layouts</span></span>

<span data-ttu-id="dfdcb-205">非仮想化のレイアウトと同様に、仮想化のレイアウトの大まかな手順は、同じです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-205">Similar to a non-virtualizing layout, the high-level steps for a virtualizing layout are the same.</span></span>  <span data-ttu-id="dfdcb-206">複雑さの多くは要素で、ビューポート内を通知し、実現する必要がありますを決定します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-206">The complexity is largely in determining what elements will fall within the viewport and should be realized.</span></span>

1. <span data-ttu-id="dfdcb-207">基本型から派生[VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-207">Derive from the base type [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout).</span></span>
2. <span data-ttu-id="dfdcb-208">(省略可能)依存関係プロパティの定義時に変更がレイアウトが無効にします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-208">(Optional) Define your dependency properties that when changed will invalidate the layout.</span></span>
3. <span data-ttu-id="dfdcb-209">一部として、レイアウトで必要な任意の状態オブジェクトの初期化、 [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-209">Initialize any state object that will be required by the layout as part of the [InitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.initializeforcontextcore).</span></span> <span data-ttu-id="dfdcb-210">使用して、ホスト コンテナーを格納すること、 [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate)コンテキストを提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-210">Stash it with the host container by using the [LayoutState](/uwp/api/microsoft.ui.xaml.controls.layoutcontext.layoutstate) provided with the context.</span></span>
4. <span data-ttu-id="dfdcb-211">上書き、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)を呼び出すと、[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)メソッドを実現する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-211">Override the [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride) and call the [Measure](/uwp/api/windows.ui.xaml.uielement.measure) method for each child that should be realized.</span></span>
   1. <span data-ttu-id="dfdcb-212">[GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) (例: 適用されるデータ バインド)、フレームワークによって準備された UIElement を取得するメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-212">The [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) method is used to retrieve a UIElement that has been prepared by the framework (e.g. data bindings applied).</span></span>
5. <span data-ttu-id="dfdcb-213">上書き、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)を呼び出すと、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)実現された各子のメソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-213">Override the [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride) and call the [Arrange](/uwp/api/windows.ui.xaml.uielement.arrange) method for each realized child.</span></span>
6. <span data-ttu-id="dfdcb-214">(省略可能)いずれかをクリーンアップするには、一部として状態を保存、 [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-214">(Optional) Clean up any saved state as part of the [UninitializeForContextCore](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.uninitializeforcontextcore).</span></span>

> [!TIP]
> <span data-ttu-id="dfdcb-215">によって返される値、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)仮想化されたコンテンツのサイズとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-215">The value returned by the [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout) is used as the size of the virtualized content.</span></span>

<span data-ttu-id="dfdcb-216">仮想化のレイアウトを作成するときに考慮すべき 2 つの一般的な方法はあります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-216">There are two general approaches to consider when authoring a virtualizing layout.</span></span>  <span data-ttu-id="dfdcb-217">ほとんどのどちらかを選択するかどうかは、「方法はサイズを決定する要素の」に依存します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-217">Whether to choose one or the other largely depends on "how will you determine the size of an element".</span></span>  <span data-ttu-id="dfdcb-218">最終的なサイズを決定十分のデータ セットまたはデータ自体内の項目のインデックスを把握するかどうかは、考えてみましょう。 その**データ依存型**します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-218">If its enough to know the index of an item in the data set or the data itself dictates its eventual size, then we'd consider it **data-dependent**.</span></span>  <span data-ttu-id="dfdcb-219">これらより簡単に作成します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-219">These are more straightforward to create.</span></span>  <span data-ttu-id="dfdcb-220">ただし、項目は作成したことを言うと、UI の測定のサイズを決定する唯一の方法は場合は、**コンテンツに依存する**します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-220">If, however, the only way to determine the size for an item is to create and measure the UI then we'd say it is **content-dependent**.</span></span>  <span data-ttu-id="dfdcb-221">これらは複雑です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-221">These are more complex.</span></span>

### <a name="the-layout-process"></a><span data-ttu-id="dfdcb-222">レイアウトの処理</span><span class="sxs-lookup"><span data-stu-id="dfdcb-222">The Layout Process</span></span>

<span data-ttu-id="dfdcb-223">データまたはコンテンツに依存するレイアウトを作成するかどうかは、レイアウト プロセスと Windows の非同期のスクロールの影響を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-223">Whether you're creating a data or content-dependent layout, it's important to understand the layout process and the impact of Windows' asynchronous scrolling.</span></span>

<span data-ttu-id="dfdcb-224">(上) スタートアップから画面に UI を表示するためにフレームワークによって実行される手順の簡略化されたビューです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-224">An (over)simplified view of the steps performed by the framework from start-up to displaying UI on screen is that:</span></span>

1. <span data-ttu-id="dfdcb-225">マークアップを解析します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-225">It parses the markup.</span></span>

2. <span data-ttu-id="dfdcb-226">要素のツリーを生成します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-226">Generates a tree of elements.</span></span>

3. <span data-ttu-id="dfdcb-227">レイアウト パスを実行します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-227">Performs a layout pass.</span></span>

4. <span data-ttu-id="dfdcb-228">レンダリング パスを実行します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-228">Performs a render pass.</span></span>

<span data-ttu-id="dfdcb-229">UI の仮想化、手順 2. で通常行う必要がある要素を作成する遅延または 1 回早期終了その決定されてそのための十分なコンテンツが作成された、ビューポートを入力します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-229">With UI virtualization, creating the elements that would normally be done in step 2 is delayed or ended early once its been determined that sufficient content has been created to fill the viewport.</span></span> <span data-ttu-id="dfdcb-230">仮想コンテナー (例: ItemsRepeater) は、このプロセスをドライブに接続されているレイアウトに従います。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-230">A virtualizing container (e.g. ItemsRepeater) defers to its attached layout to drive this process.</span></span> <span data-ttu-id="dfdcb-231">接続されているレイアウトを提供します、 [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)化レイアウトが必要な追加情報を明らかになります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-231">It provides the attached layout with a [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext) that surfaces the additional information that a virtualizing layout needs.</span></span>

**<span data-ttu-id="dfdcb-232">RealizationRect (つまりビューポート)</span><span class="sxs-lookup"><span data-stu-id="dfdcb-232">The RealizationRect (i.e. Viewport)</span></span>**

<span data-ttu-id="dfdcb-233">Windows 上のスクロールは、UI スレッドに非同期発生します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-233">Scrolling on Windows happens asynchronous to the UI thread.</span></span> <span data-ttu-id="dfdcb-234">フレームワークのレイアウトでは管理されません。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-234">It is not controlled by the framework's layout.</span></span>  <span data-ttu-id="dfdcb-235">代わりに、相互作用と移動は、システムのコンポジターで発生します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-235">Rather, the interaction and movement occurs in the system's compositor.</span></span> <span data-ttu-id="dfdcb-236">このアプローチの利点は、60 fps で、コンテンツをパンできる常に行われます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-236">The advantage of this approach is that panning content can always be done at 60fps.</span></span>  <span data-ttu-id="dfdcb-237">ただしの課題は、""、ビューポート、レイアウトから見たが実際に画面に表示がどのような基準とした若干古い可能性があることです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-237">The challenge, however, is that the "viewport", as seen by the layout, might be slightly out-of-date relative to what is actually visible on screen.</span></span> <span data-ttu-id="dfdcb-238">ユーザーが迅速にスクロールする場合の新しいコンテンツおよび「を黒にパン」を生成する UI スレッドの速度が値を上回る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-238">If a user scrolls quickly, they may outpace the speed of the UI thread to generate new content and “pan to black”.</span></span> <span data-ttu-id="dfdcb-239">このためは、仮想化レイアウトのビューポートを超える領域を埋めるに十分な準備済みの要素の追加のバッファーを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-239">For this reason, it’s often necessary for a virtualizing layout to generate an additional buffer of prepared elements sufficient to fill an area larger than the viewport.</span></span> <span data-ttu-id="dfdcb-240">提供する際、ユーザーがスクロール中にさらに高い負荷がまだコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-240">When under heavier load during scrolling the user is still presented with content.</span></span>

![四角形の実現](images/xaml-attached-layout-realizationrect.png)

<span data-ttu-id="dfdcb-242">要素の作成は高コストであるために、コンテナーを仮想化 (例: [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)) で接続されているレイアウトは、最初に、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポートに一致します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-242">Since element creation is costly, virtualizing containers (e.g. [ItemsRepeater](/windows/uwp/design/controls-and-patterns/items-repeater)) will initially provide the attached layout with a [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect) that matches the viewport.</span></span> <span data-ttu-id="dfdcb-243">アイドル時、コンテナーは、ますます大きく実現可変噴出口を使用して、レイアウトを繰り返し呼び出すことで準備済みのコンテンツのバッファーを拡張可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-243">On idle time the container may grow the buffer of prepared content by making repeated calls to the layout using an increasingly larger realization rect.</span></span> <span data-ttu-id="dfdcb-244">この動作は、パフォーマンスを最適化する高速スタートアップ時間と良好なパンのエクスペリエンス間のバランスを取るように試みます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-244">This behavior is a performance optimization that attempts to strike a balance between fast startup time and a good panning experience.</span></span> <span data-ttu-id="dfdcb-245">ItemsRepeater により生成される最大バッファー サイズはによって制御されます。 その[VerticalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength)と[HorizontalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-245">The maximum buffer size that the ItemsRepeater will generate is controlled by its [VerticalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength) and [HorizontalCacheLength](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.verticalcachelength) properties.</span></span>

**<span data-ttu-id="dfdcb-246">(リサイクル) 要素を再利用</span><span class="sxs-lookup"><span data-stu-id="dfdcb-246">Re-using Elements (Recycling)</span></span>**

<span data-ttu-id="dfdcb-247">サイズし、位置を埋める要素をレイアウトが必要です、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)たびに実行します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-247">The layout is expected to size and position the elements to fill the [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect) each time it is run.</span></span> <span data-ttu-id="dfdcb-248">既定では、 [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout)各レイアウト パスの最後に、未使用の要素をリサイクルします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-248">By default the [VirtualizingLayout](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout) will recycle any unused elements at the end of each layout pass.</span></span>

<span data-ttu-id="dfdcb-249">[VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)の一部として、レイアウトに渡される、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)と[ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)追加情報を提供します。仮想化のレイアウトが必要です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-249">The [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext) that is passed to the layout as part of the [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride) and [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride) provides the additional information a virtualizing layout needs.</span></span> <span data-ttu-id="dfdcb-250">最もよく使用されるものを提供しますが、機能です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-250">Some of the most commonly used things it provides are the ability to:</span></span>

1. <span data-ttu-id="dfdcb-251">データ内の項目の数を照会 ([ItemCount](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.itemcount))。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-251">Query the number of items in the data ([ItemCount](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.itemcount)).</span></span>
2. <span data-ttu-id="dfdcb-252">項目を使用して、特定の取得、 [GetItemAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getitemat)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-252">Retrieve a specific item using the [GetItemAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getitemat) method.</span></span>
3. <span data-ttu-id="dfdcb-253">取得、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポートを表すし、レイアウトの塗りつぶしのバッファーが要素を実現します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-253">Retrieve a [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect) that represents the viewport and buffer that the layout should fill with realized elements.</span></span>
4. <span data-ttu-id="dfdcb-254">要求で特定の品目の UIElement、 [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-254">Request the UIElement for a specific item with the [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) method.</span></span>

<span data-ttu-id="dfdcb-255">指定されたインデックスの要素を要求すると、そのパス レイアウトの「使用中」としてマークするには、その要素が発生します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-255">Requesting an element for a given index will cause that element to be marked as "in use" for that pass of the layout.</span></span> <span data-ttu-id="dfdcb-256">要素が存在しない場合は実現され、自動的に (例: 増やして UI ツリーを任意のデータ バインディングなどの処理、DataTemplate に定義します。) 使用できるように準備します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-256">If the element does not already exist, then it will be realized and automatically prepared for use (e.g. inflating the UI tree defined in a DataTemplate, processing any data binding, etc.).</span></span>  <span data-ttu-id="dfdcb-257">それ以外の場合、既存のインスタンスのプールから取得されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-257">Otherwise, it will be retrieved from a pool of existing instances.</span></span>

<span data-ttu-id="dfdcb-258">各測定パスの末尾には、任意の既存実現「使用中」としてマークされていない要素が再利用できると見なされるに自動的にしない限り、オプションを[SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions)要素を使用して取得したときに使用された、[GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-258">At the end of each measure pass, any existing, realized element that was not marked "in use" is automatically considered available for re-use unless the option to [SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions) was used when the element was retrieved via the [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) method.</span></span> <span data-ttu-id="dfdcb-259">フレームワークは自動的にリサイクル プールに移動され、使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-259">The framework automatically moves it to a recycle pool and makes it available.</span></span> <span data-ttu-id="dfdcb-260">これは、可能性があります、その後によってプルされる使用するための別のコンテナー。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-260">It may subsequently be pulled for use by a different container.</span></span> <span data-ttu-id="dfdcb-261">フレームワークは、この問題を回避可能な場合は親の再指定要素に関連付けられているいくつかのコストを試みます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-261">The framework tries to avoid this when possible as there is some cost associated with re-parenting an element.</span></span>

<span data-ttu-id="dfdcb-262">先頭の要素が実現四角形内には不要になった各メジャーの仮想化のレイアウトを知っている場合、ことができます最適化の再利用します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-262">If a virtualizing layout knows at the beginning of each measure which elements will no longer fall within the realization rect then it can optimize its re-use.</span></span> <span data-ttu-id="dfdcb-263">フレームワークの既定の動作に頼るにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-263">Rather than relying on the framework's default behavior.</span></span> <span data-ttu-id="dfdcb-264">レイアウトを使用してプールのリサイクルに要素を事前移動できます、 [RecycleElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recycleelement)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-264">The layout can preemptively move elements to the recycle pool by using the [RecycleElement](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recycleelement) method.</span></span>  <span data-ttu-id="dfdcb-265">レイアウトを後で発行するときに、既存の要素を新しい要素を要求する前にこのメソッドを呼び出すことにより、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)要素に関連付けられていない既にインデックスの要求。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-265">Calling this method before requesting new elements causes those existing elements to be available when the layout later issues a [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) request for an index that isn't already associated with an element.</span></span>

<span data-ttu-id="dfdcb-266">VirtualizingLayoutContext レイアウトの作成者がコンテンツに依存するレイアウトの作成用に設計された 2 つの追加のプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-266">The VirtualizingLayoutContext provides two additional properties designed for layout authors creating a content-dependent layout.</span></span> <span data-ttu-id="dfdcb-267">後で詳しく説明するは。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-267">They are discussed in more detail later.</span></span>

1. <span data-ttu-id="dfdcb-268">A [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)オプションを提供する_入力_レイアウトにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-268">A [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex) that provides an optional _input_ to layout.</span></span>
2. <span data-ttu-id="dfdcb-269">A [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin)は省略可能な_出力_のレイアウト。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-269">A [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin) that is an optional _output_ of the layout.</span></span>

## <a name="data-dependent-virtualizing-layouts"></a><span data-ttu-id="dfdcb-270">データ依存の仮想化のレイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-270">Data-dependent Virtualizing Layouts</span></span>

<span data-ttu-id="dfdcb-271">仮想化のレイアウトは、表示するコンテンツを測定することがなくすべての項目のサイズはわかっている場合は簡単です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-271">A virtualizing layout is easier if you know what the size of every item should be without needing to measure the content to show.</span></span>  <span data-ttu-id="dfdcb-272">このドキュメントを参照としてレイアウトを仮想化するには、このカテゴリに**データ レイアウト**通常必要になるため、データを検査します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-272">In this doc we'll simply refer to this category of virtualizing layouts as **data layouts** since they usually involve inspecting the data.</span></span>  <span data-ttu-id="dfdcb-273">アプリが選択既知のサイズ - 視覚的に表現おそらくため、データに基づくデータの一部で、デザインによって決定された以前またはします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-273">Based on the data an app may pick a visual representation with a known size - perhaps because its part of the data or was previously determined by design.</span></span>

<span data-ttu-id="dfdcb-274">一般的な方法は、レイアウトには。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-274">The general approach is for the layout to:</span></span>

1. <span data-ttu-id="dfdcb-275">サイズとすべての項目の位置を計算します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-275">Calculate a size and position of every item.</span></span>
2. <span data-ttu-id="dfdcb-276">一部として、 [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride):</span><span class="sxs-lookup"><span data-stu-id="dfdcb-276">As part of the [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride):</span></span>
   1. <span data-ttu-id="dfdcb-277">使用して、 [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)ビューポート内の項目の順序を決定します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-277">Use the [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect) to determine which items should appear within the viewport.</span></span>
   2. <span data-ttu-id="dfdcb-278">持つ項目を表す UIElement の取得、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-278">Retrieve the UIElement that should represent the item with the [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) method.</span></span>
   3. <span data-ttu-id="dfdcb-279">[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)事前に計算されたサイズの UIElement です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-279">[Measure](/uwp/api/windows.ui.xaml.uielement.measure) the UIElement with the pre-calculated size.</span></span>
3. <span data-ttu-id="dfdcb-280">一部として、 [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride)、[配置](/uwp/api/windows.ui.xaml.uielement.arrange)各こと、また UIElement は、事前計算済みの位置で実現します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-280">As part of the [ArrangeOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.arrangeoverride), [Arrange](/uwp/api/windows.ui.xaml.uielement.arrange) each realized UIElement with the precalculated position.</span></span>

> [!NOTE]
> <span data-ttu-id="dfdcb-281">データのレイアウト方法は、多くの場合と互換性のある_データ仮想化_します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-281">A data layout approach is often incompatible with _data virtualization_.</span></span>  <span data-ttu-id="dfdcb-282">具体的には、唯一のデータがメモリに読み込まれるはそのデータには、ユーザーに表示される内容を入力する必要です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-282">Specifically, where the only data loaded into memory is that data required to fill what's visible to the user.</span></span>  <span data-ttu-id="dfdcb-283">データ仮想化はされていないユーザーがそのデータが常駐をスクロールすると、データの遅延または増分読み込みを参照します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-283">Data virtualization isn't referring to lazy or incremental loading of data as a user scrolls down where that data remains resident.</span></span>  <span data-ttu-id="dfdcb-284">代わりに、ようにビューからスクロールされたときに、項目がメモリから解放されるときを参照しています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-284">Rather, it's referring to when items are released from memory as they're scrolled out of view.</span></span>  <span data-ttu-id="dfdcb-285">データのレイアウトの一部は、期待どおりの作業用のデータ仮想化にできなくなると、すべてのデータ項目を調査するデータのレイアウトを持ちます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-285">Having a data layout that inspects every data item as part of a data layout would prevent data virtualization from working as expected.</span></span>  <span data-ttu-id="dfdcb-286">すべての要素が同じサイズであることを前提としている UniformGridLayout などのレイアウトは例外です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-286">An exception is a layout like the UniformGridLayout which assumes that everything has the same size.</span></span>

> [!TIP]
> <span data-ttu-id="dfdcb-287">さまざまな状況で他のユーザーによって使用されるコントロール ライブラリのカスタム コントロールを作成する場合は、するオプションが可能性がありますいないデータ レイアウトにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-287">If you're creating a custom control for a control library that will be used by others in a wide variety of situations then a data layout may not be an option for you.</span></span>

### <a name="example-xbox-activity-feed-layout"></a><span data-ttu-id="dfdcb-288">以下に例を示します。レイアウトの Xbox アクティビティ フィード</span><span class="sxs-lookup"><span data-stu-id="dfdcb-288">Example: Xbox Activity Feed layout</span></span>

<span data-ttu-id="dfdcb-289">Xbox アクティビティ フィードの UI では、各行が後続の行では、反転 2 つの幅が狭いタイルの後に、ワイド タイルには、繰り返しパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-289">The UI for the Xbox Activity Feed uses a repeating pattern where each line has a wide tile, followed by two narrow tiles that is inverted on the subsequent line.</span></span> <span data-ttu-id="dfdcb-290">このレイアウトでは、すべての項目のサイズは、アイテムの位置で、データ セットと、タイルの既知のサイズ (ワイド vs を絞り込む) の関数です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-290">In this layout, the size for every item is a function of the item’s position in the data set and the known size for the tiles (wide vs narrow).</span></span>

![Xbox アクティビティ フィード](images/xaml-attached-layout-activityfeedscreenshot.png)

<span data-ttu-id="dfdcb-292">どのようなカスタムの仮想化を示すために、アクティビティ フィード用の UI があります。 一般的なアプローチを使用していきます次のコードがかかる場合があります、**データ レイアウト**します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-292">The code below walks through what a custom virtualizing UI for the activity feed might be to illustrate the general approach you might take for a **data layout**.</span></span>

<table>
<td>
    <p><span data-ttu-id="dfdcb-293">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして、アプリを開きを参照してください、 <a href="xamlcontrolsgallery:/item/ItemsRepeater">ItemsRepeater</a>のこのサンプル レイアウトで動作します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-293">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ItemsRepeater">ItemsRepeater</a> in action with this sample layout.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="dfdcb-294">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="dfdcb-294">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="dfdcb-295">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="dfdcb-295">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

#### <a name="implementation"></a><span data-ttu-id="dfdcb-296">実装</span><span class="sxs-lookup"><span data-stu-id="dfdcb-296">Implementation</span></span>

```csharp
/// <summary>
///  This is a custom layout that displays elements in two different sizes
///  wide (w) and narrow (n). There are two types of rows 
///  odd rows - narrow narrow wide
///  even rows - wide narrow narrow
///  This pattern repeats.
/// </summary>

public class ActivityFeedLayout : VirtualizingLayout // STEP #1 Inherit from base attached layout
{
    // STEP #2 - Parameterize the layout
    #region Layout parameters

    // We'll cache copies of the dependency properties to avoid calling GetValue during layout since that
    // can be quite expensive due to the number of times we'd end up calling these.
    private double _rowSpacing;
    private double _colSpacing;
    private Size _minItemSize = Size.Empty;

    /// <summary>
    /// Gets or sets the size of the whitespace gutter to include between rows
    /// </summary>
    public double RowSpacing
    {
        get { return _rowSpacing; }
        set { SetValue(RowSpacingProperty, value); }
    }

    /// <summary>
    /// Gets or sets the size of the whitespace gutter to include between items on the same row
    /// </summary>
    public double ColumnSpacing
    {
        get { return _colSpacing; }
        set { SetValue(ColumnSpacingProperty, value); }
    }

    public Size MinItemSize
    {
        get { return _minItemSize; }
        set { SetValue(MinItemSizeProperty, value); }
    }

    public static readonly DependencyProperty RowSpacingProperty =
        DependencyProperty.Register(
            nameof(RowSpacing),
            typeof(double),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(0, OnPropertyChanged));

    public static readonly DependencyProperty ColumnSpacingProperty =
        DependencyProperty.Register(
            nameof(ColumnSpacing),
            typeof(double),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(0, OnPropertyChanged));

    public static readonly DependencyProperty MinItemSizeProperty =
        DependencyProperty.Register(
            nameof(MinItemSize),
            typeof(Size),
            typeof(ActivityFeedLayout),
            new PropertyMetadata(Size.Empty, OnPropertyChanged));

    private static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        var layout = obj as ActivityFeedLayout;
        if (args.Property == RowSpacingProperty)
        {
            layout._rowSpacing = (double)args.NewValue;
        }
        else if (args.Property == ColumnSpacingProperty)
        {
            layout._colSpacing = (double)args.NewValue;
        }
        else if (args.Property == MinItemSizeProperty)
        {
            layout._minItemSize = (Size)args.NewValue;
        }
        else
        {
            throw new InvalidOperationException("Don't know what you are talking about!");
        }

        layout.InvalidateMeasure();
    }

    #endregion

    #region Setup / teardown // STEP #3: Initialize state

    protected override void InitializeForContextCore(VirtualizingLayoutContext context)
    {
        base.InitializeForContextCore(context);

        var state = context.LayoutState as ActivityFeedLayoutState;
        if (state == null)
        {
            // Store any state we might need since (in theory) the layout could be in use by multiple
            // elements simultaneously
            // In reality for the Xbox Activity Feed there's probably only a single instance.
            context.LayoutState = new ActivityFeedLayoutState();
        }
    }

    protected override void UninitializeForContextCore(VirtualizingLayoutContext context)
    {
        base.UninitializeForContextCore(context);

        // clear any state
        context.LayoutState = null;
    }

    #endregion

    #region Layout // STEP #4,5 - Measure and Arrange

    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        if (this.MinItemSize == Size.Empty)
        {
            var firstElement = context.GetOrCreateElementAt(0);
            firstElement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            // setting the member value directly to skip invalidating layout
            this._minItemSize = firstElement.DesiredSize;
        }

        // Determine which rows need to be realized.  We know every row will have the same height and
        // only contain 3 items.  Use that to determine the index for the first and last item that
        // will be within that realization rect.
        var firstRowIndex = Math.Max(
            (int)(context.RealizationRect.Y / (this.MinItemSize.Height + this.RowSpacing)) - 1,
            0);
        var lastRowIndex = Math.Min(
            (int)(context.RealizationRect.Bottom / (this.MinItemSize.Height + this.RowSpacing)) + 1,
            (int)(context.ItemCount / 3));

        // Determine which items will appear on those rows and what the rect will be for each item
        var state = context.LayoutState as ActivityFeedLayoutState;
        state.LayoutRects.Clear();

        // Save the index of the first realized item.  We'll use it as a starting point during arrange.
        state.FirstRealizedIndex = firstRowIndex * 3;

        // ideal item width that will expand/shrink to fill available space
        double desiredItemWidth = Math.Max(this.MinItemSize.Width, (availableSize.Width - this.ColumnSpacing * 3) / 4);

        // Foreach item between the first and last index,
        //     Call GetElementOrCreateElementAt which causes an element to either be realized or retrieved
        //       from a recycle pool
        //     Measure the element using an appropriate size
        //
        // Any element that was previously realized which we don't retrieve in this pass (via a call to
        // GetElementOrCreateAt) will be automatically cleared and set aside for later re-use.
        // Note: While this work fine, it does mean that more elements than are required may be
        // created because it isn't until after our MeasureOverride completes that the unused elements
        // will be recycled and available to use.  We could avoid this by choosing to track the first/last
        // index from the previous layout pass.  The diff between the previous range and current range
        // would represent the elements that we can pre-emptively make available for re-use by calling
        // context.RecycleElement(element).
        for (int rowIndex = firstRowIndex; rowIndex < lastRowIndex; rowIndex++)
        {
            int firstItemIndex = rowIndex * 3;
            var boundsForCurrentRow = CalculateLayoutBoundsForRow(rowIndex, desiredItemWidth);

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                var index = firstItemIndex + columnIndex;
                var rect = boundsForCurrentRow[index % 3];
                var container = context.GetOrCreateElementAt(index);

                container.Measure(
                    new Size(boundsForCurrentRow[columnIndex].Width, boundsForCurrentRow[columnIndex].Height));

                state.LayoutRects.Add(boundsForCurrentRow[columnIndex]);
            }
        }

        // Calculate and return the size of all the content (realized or not) by figuring out
        // what the bottom/right position of the last item would be.
        var extentHeight = ((int)(context.ItemCount / 3) - 1) * (this.MinItemSize.Height + this.RowSpacing) + this.MinItemSize.Height;

        // Report this as the desired size for the layout
        return new Size(desiredItemWidth * 4 + this.ColumnSpacing * 2, extentHeight);
    }

    protected override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
    {
        // walk through the cache of containers and arrange
        var state = context.LayoutState as ActivityFeedLayoutState;
        var virtualContext = context as VirtualizingLayoutContext;
        int currentIndex = state.FirstRealizedIndex;

        foreach (var arrangeRect in state.LayoutRects)
        {
            var container = virtualContext.GetOrCreateElementAt(currentIndex);
            container.Arrange(arrangeRect);
            currentIndex++;
        }

        return finalSize;
    }

    #endregion
    #region Helper methods

    private Rect[] CalculateLayoutBoundsForRow(int rowIndex, double desiredItemWidth)
    {
        var boundsForRow = new Rect[3];

        var yoffset = rowIndex * (this.MinItemSize.Height + this.RowSpacing);
        boundsForRow[0].Y = boundsForRow[1].Y = boundsForRow[2].Y = yoffset;
        boundsForRow[0].Height = boundsForRow[1].Height = boundsForRow[2].Height = this.MinItemSize.Height;

        if (rowIndex % 2 == 0)
        {
            // Left tile (narrow)
            boundsForRow[0].X = 0;
            boundsForRow[0].Width = desiredItemWidth;
            // Middle tile (narrow)
            boundsForRow[1].X = boundsForRow[0].Right + this.ColumnSpacing;
            boundsForRow[1].Width = desiredItemWidth;
            // Right tile (wide)
            boundsForRow[2].X = boundsForRow[1].Right + this.ColumnSpacing;
            boundsForRow[2].Width = desiredItemWidth * 2 + this.ColumnSpacing;
        }
        else
        {
            // Left tile (wide)
            boundsForRow[0].X = 0;
            boundsForRow[0].Width = (desiredItemWidth * 2 + this.ColumnSpacing);
            // Middle tile (narrow)
            boundsForRow[1].X = boundsForRow[0].Right + this.ColumnSpacing;
            boundsForRow[1].Width = desiredItemWidth;
            // Right tile (narrow)
            boundsForRow[2].X = boundsForRow[1].Right + this.ColumnSpacing;
            boundsForRow[2].Width = desiredItemWidth;
        }

        return boundsForRow;
    }

    #endregion
}

internal class ActivityFeedLayoutState
{
    public int FirstRealizedIndex { get; set; }

    /// <summary>
    /// List of layout bounds for items starting with the
    /// FirstRealizedIndex.
    /// </summary>
    public List<Rect> LayoutRects
    {
        get
        {
            if (_layoutRects == null)
            {
                _layoutRects = new List<Rect>();
            }

            return _layoutRects;
        }
    }

    private List<Rect> _layoutRects;
}
```

### <a name="optional-managing-the-item-to-uielement-mapping"></a><span data-ttu-id="dfdcb-297">(省略可能)UIElement のマッピングに項目を管理します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-297">(Optional) Managing the Item to UIElement Mapping</span></span>

<span data-ttu-id="dfdcb-298">既定で、 [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext)実現された要素となるデータ ソース内のインデックス間のマッピングを保持します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-298">By default, the [VirtualizingLayoutContext](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext) maintains a mapping between the realized elements and the index in the data source they represent.</span></span>  <span data-ttu-id="dfdcb-299">このマッピング自体をするためのオプションを常に要求を管理するレイアウトを選択できます[SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions)経由の要素を取得するときに、 [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat)メソッドの既定値を実行できなくなります。自動リサイクル動作します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-299">A layout can choose to manage this mapping itself by always requesting the option to [SuppressAutoRecycle](/uwp/api/microsoft.ui.xaml.controls.elementrealizationoptions) when retrieving an element via the [GetOrCreateElementAt](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.getorcreateelementat) method which prevents the default auto-recycling behavior.</span></span>  <span data-ttu-id="dfdcb-300">1 つの方向に制限は、スクロールと見なされる場合、項目が (つまり知る最初と最後の要素のインデックスは市外をする必要があるすべての要素を把握するのに十分な連続したは常には使用のみ場合に、たとえば、レイアウトを選択できます。lized)。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-300">A layout may choose to do this, for example, if it will only be used when scrolling is restricted to one direction and the items it considers will always be contiguous (i.e. knowing the index of the first and last element is enough to know all the elements that should be realized).</span></span>

#### <a name="example-xbox-activity-feed-measure"></a><span data-ttu-id="dfdcb-301">以下に例を示します。メジャーの Xbox アクティビティ フィード</span><span class="sxs-lookup"><span data-stu-id="dfdcb-301">Example: Xbox Activity Feed measure</span></span>

<span data-ttu-id="dfdcb-302">次のスニペットは、マッピングを管理する前の例で MeasureOverride に追加できる追加のロジックを示しています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-302">The snippet below shows the additional logic that could be added to the MeasureOverride in the previous sample to manage the mapping.</span></span>

```csharp
    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        //...

        // Determine which items will appear on those rows and what the rect will be for each item
        var state = context.LayoutState as ActivityFeedLayoutState;
        state.LayoutRects.Clear();

         // Recycle previously realized elements that we know we won't need so that they can be used to
        // fill in gaps without requiring us to realize additional elements.
        var newFirstRealizedIndex = firstRowIndex * 3;
        var newLastRealizedIndex = lastRowIndex * 3 + 3;
        for (int i = state.FirstRealizedIndex; i < newFirstRealizedIndex; i++)
        {
            context.RecycleElement(state.IndexToElementMap.Get(i));
            state.IndexToElementMap.Clear(i);
        }

        for (int i = state.LastRealizedIndex; i < newLastRealizedIndex; i++)
        {
            context.RecycleElement(context.IndexElementMap.Get(i));
            state.IndexToElementMap.Clear(i);
        }

        // ...

        // Foreach item between the first and last index,
        //     Call GetElementOrCreateElementAt which causes an element to either be realized or retrieved
        //       from a recycle pool
        //     Measure the element using an appropriate size
        //
        for (int rowIndex = firstRowIndex; rowIndex < lastRowIndex; rowIndex++)
        {
            int firstItemIndex = rowIndex * 3;
            var boundsForCurrentRow = CalculateLayoutBoundsForRow(rowIndex, desiredItemWidth);

            for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                var index = firstItemIndex + columnIndex;
                var rect = boundsForCurrentRow[index % 3];
                UIElement container = null;
                if (state.IndexToElementMap.Contains(index))
                {
                    container = state.IndexToElementMap.Get(index);
                }
                else
                {
                    container = context = context.GetOrCreateElementAt(index, ElementRealizationOptions.ForceCreate | ElementRealizationOptions.SuppressAutoRecycle);
                    state.IndexToElementMap.Add(index, container);
                }

                container.Measure(
                    new Size(boundsForCurrentRow[columnIndex].Width, boundsForCurrentRow[columnIndex].Height));

                state.LayoutRects.Add(boundsForCurrentRow[columnIndex]);
            }
        }

        // ...
   }

internal class ActivityFeedLayoutState
{
    // ...
    Dictionary<int, UIElement> IndexToElementMap { get; set; }
    // ...
}
```

## <a name="content-dependent-virtualizing-layouts"></a><span data-ttu-id="dfdcb-303">コンテンツに依存する仮想化のレイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-303">Content-dependent Virtualizing Layouts</span></span>

<span data-ttu-id="dfdcb-304">実際のサイズを確認する項目用の UI コンテンツを測定する必要がありますまず場合は、**コンテンツに依存するレイアウト**します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-304">If you must first measure the UI content for an item to figure out its exact size then it is a **content-dependent layout**.</span></span>  <span data-ttu-id="dfdcb-305">項目のサイズを示すレイアウトではなく、各項目のサイズする必要がありますレイアウトとしては、そのも考えることができます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-305">You can also think of it as a layout where each item must size itself rather than the layout telling the item its size.</span></span> <span data-ttu-id="dfdcb-306">このカテゴリに分類される仮想化のレイアウトは複雑です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-306">Virtualizing layouts that fall into this category are more involved.</span></span>

> [!NOTE]
> <span data-ttu-id="dfdcb-307">レイアウトのコンテンツに依存しないデータの仮想化を解除 (しないでください)。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-307">Content-dependent layouts don't (shouldn't) break data virtualization.</span></span>

### <a name="estimations"></a><span data-ttu-id="dfdcb-308">見積もり</span><span class="sxs-lookup"><span data-stu-id="dfdcb-308">Estimations</span></span>

<span data-ttu-id="dfdcb-309">コンテンツに依存するレイアウトは、実現されていないコンテンツのサイズと実際のコンテンツの位置の両方を推測する推定に依存します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-309">Content-dependent layouts rely on estimation to guess both the size of unrealized content and the position of the realized content.</span></span> <span data-ttu-id="dfdcb-310">これらの推定が変わると、スクロール可能な領域内の位置を定期的にシフトする実際のコンテンツが発生します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-310">As those estimates change it will cause the realized content to regularly shift positions within the scrollable area.</span></span> <span data-ttu-id="dfdcb-311">これは、ユーザー エクスペリエンスは非常に面倒で少し目障りな感じ可能性がない場合は軽減。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-311">This can lead to a very frustrating and jarring user experience if not mitigated.</span></span> <span data-ttu-id="dfdcb-312">潜在的な問題と軽減策がここで説明します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-312">The potential issues and mitigations are discussed here.</span></span>

> [!NOTE]
> <span data-ttu-id="dfdcb-313">すべての項目を考慮し、またはそうでないことに気付きました、すべてのアイテムとその位置の正確なサイズを把握しているデータ レイアウトでは、すべてこれらの問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-313">Data layouts that consider every item and know the exact size of all items, realized or not, and their positions can avoid these issues entirely.</span></span>

**<span data-ttu-id="dfdcb-314">アンカーのスクロール</span><span class="sxs-lookup"><span data-stu-id="dfdcb-314">Scroll Anchoring</span></span>**

<span data-ttu-id="dfdcb-315">XAML コントロールのサポートをスクロールすることで急激なビューポート シフトを軽減するためのメカニズムを提供する[アンカーのスクロール](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)実装することによって、 [IScrollAnchorPovider](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)インターフェイス。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-315">XAML provides a mechanism to mitigate sudden viewport shifts by having scrolling controls support [scroll anchoring](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider) by implementing the [IScrollAnchorPovider](/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider) interface.</span></span> <span data-ttu-id="dfdcb-316">ユーザーがコンテンツを操作すると、スクロール コントロールは継続的に追跡にオプトインされた候補のセットから要素を選択します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-316">As the user manipulates the content, the scrolling control continually selects an element from the set of candidates that were opted-in to be tracked.</span></span> <span data-ttu-id="dfdcb-317">レイアウト中にアンカー要素の位置を移動する場合、スクロール コントロールは、ビューポートを維持するために、ビューポートを自動的に移動します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-317">If the position of the anchor element shifts during the layout then the scroll control automatically shifts its viewport to maintain the viewport.</span></span>

<span data-ttu-id="dfdcb-318">値、 [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)に提供されるレイアウトは、その現在選択されているアンカー要素のスクロール コントロールが選択を反映可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-318">The value of the [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex) provided to the layout may reflect that currently selected anchor element chosen by the scrolling control.</span></span> <span data-ttu-id="dfdcb-319">また、開発者が明示的に使用して、インデックスの要素を実現することを要求した場合、 [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.getorcreateelement)メソッドを[ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)、として、そのインデックスが指定し、 [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)次のレイアウト パスにします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-319">Alternatively, if a developer explicitly requests that an element be realized for an index with the [GetOrCreateElement](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater.getorcreateelement) method on the [ItemsRepeater](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater), then that index is given as the [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex) on the next layout pass.</span></span> <span data-ttu-id="dfdcb-320">これにより、開発者は、要素のことを認識し、後で要求を使用して表示にする起動される可能性が高いシナリオに備えるレイアウト、 [StartBringIntoView](/uwp/api/windows.ui.xaml.uielement.startbringintoview)メソッド。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-320">This enables the layout to be prepared for the likely scenario that a developer realizes an element and subsequently requests that it be brought into view via the [StartBringIntoView](/uwp/api/windows.ui.xaml.uielement.startbringintoview) method.</span></span>

<span data-ttu-id="dfdcb-321">[RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex)はコンテンツに依存するレイアウトはその項目の位置を推定するときに最初に位置する必要がありますデータ ソース内の項目のインデックスです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-321">The [RecommendedAnchorIndex](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.recommendedanchorindex) is the index for the item in the data source that a content-dependent layout should position first when estimating the position of its items.</span></span> <span data-ttu-id="dfdcb-322">他の実現された項目の配置の開始点としてサービスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-322">It should serve as the starting point for positioning other realized items.</span></span>

**<span data-ttu-id="dfdcb-323">スクロール バーへの影響</span><span class="sxs-lookup"><span data-stu-id="dfdcb-323">Impact on ScrollBars</span></span>**

<span data-ttu-id="dfdcb-324">スクロールがアンカーを使用してもレイアウトの見積もりがでさまざまなバリエーションにより、おそらく異なる場合、コンテンツのサイズ、スクロール バーのつまみの位置に見えますがやや大きく変化します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-324">Even with scroll anchoring, if the layout's estimates vary a lot, perhaps due to significant variations in the size of content, then the position of the thumb for the ScrollBar may appear to jump around.</span></span>  <span data-ttu-id="dfdcb-325">Thumb をドラッグしているときに、マウス ポインターの位置を追跡するために表示されない場合は、ユーザーに不快にできます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-325">This can be jarring for a user if the thumb doesn't appear to track the position of their mouse pointer when they're dragging it.</span></span>

<span data-ttu-id="dfdcb-326">より正確なレイアウトにできる、ツールは、見積もり、ほど、ユーザーがジャンプ スクロールバーのつまみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-326">The more accurate the layout can be in its estimations then the less likely a user will see the ScrollBar's thumb jumping.</span></span>

### <a name="layout-corrections"></a><span data-ttu-id="dfdcb-327">レイアウトの修正</span><span class="sxs-lookup"><span data-stu-id="dfdcb-327">Layout Corrections</span></span>

<span data-ttu-id="dfdcb-328">現実の見積もりを合理化するには、コンテンツに依存するレイアウトを準備する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-328">A content-dependent layout should be prepared to rationalize its estimate with reality.</span></span>  <span data-ttu-id="dfdcb-329">例: にスクロールすると、コンテンツとレイアウトの上部には、最初の要素が認識しています、起動元の要素に対する要素の予想される位置は原因は原点 (x: 0 以外のどこかに表示することがあります。、y:0)。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-329">For example, as the user scrolls to the top of the content and the layout realizes the very first element, it may find that the element's anticipated position relative to the element from which it started would cause it to appear somewhere other than the origin of (x:0, y:0).</span></span> <span data-ttu-id="dfdcb-330">この場合、レイアウトが使用できる、 [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin)新しいレイアウトの配信元として、計算される位置を設定するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-330">When this occurs, the layout can use the [LayoutOrigin](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.layoutorigin) property to set the position it calculated as the new layout origin.</span></span>  <span data-ttu-id="dfdcb-331">最終的な結果は、スクロールをスクロール コントロールのビューポート自動的に調整されたコンテンツの位置のアカウントにレイアウトによって報告されたアンカーに似ています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-331">The net result is similar to scroll anchoring in which the scrolling control's viewport is automatically adjusted to account for the content's position as reported by the layout.</span></span>

![LayoutOrigin を修正します。](images/xaml-attached-layout-origincorrection.png)

### <a name="disconnected-viewports"></a><span data-ttu-id="dfdcb-333">切断されたビューポート</span><span class="sxs-lookup"><span data-stu-id="dfdcb-333">Disconnected Viewports</span></span>

<span data-ttu-id="dfdcb-334">サイズがレイアウトから返された[MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride)メソッドは、連続する各レイアウトの変更の可能性あり、コンテンツのサイズで最善の推測を表します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-334">The size returned from the layout's [MeasureOverride](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayout.measureoverride) method represents the best guess at the size of the content which may change with each successive layout.</span></span>  <span data-ttu-id="dfdcb-335">レイアウトが、更新された継続的に再評価するユーザーがスクロール[RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect)します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-335">As a user scrolls the layout will be continually re-evaluated with an updated [RealizationRect](/uwp/api/microsoft.ui.xaml.controls.virtualizinglayoutcontext.realizationrect).</span></span>

<span data-ttu-id="dfdcb-336">ユーザーが非常に迅速に thumb をドラッグし、可能な限り大きなように表示するレイアウトの観点から、ビューポートにジャンプ前の位置が、これで現在の位置を重複しないです。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-336">If a user drags the thumb very quickly then  its possible for the viewport, from the perspective of the layout, to appear to make large jumps where the prior position doesn't overlap the now current position.</span></span>  <span data-ttu-id="dfdcb-337">これは、非同期の性質により、スクロールします。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-337">This is due to the asynchronous nature of scrolling.</span></span> <span data-ttu-id="dfdcb-338">要素に状態が現在実現されていないと、レイアウトによって追跡される現在の範囲外のレイアウトの推定は項目の表示になることを要求するレイアウトを利用しているアプリのこともできます。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-338">It's also possible for an app that is consuming the layout to request that an element be brought into view for an item that is not currently realized and is estimated to lay outside the current range tracked by the layout.</span></span>

<span data-ttu-id="dfdcb-339">レイアウトを検出されると、その推定値が正しくないや予期しないビューポートの shift キーを表示、開始位置の方向を変更が必要です。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-339">When the layout discovers its guess is incorrect and/or sees an unexpected viewport shift, it needs to reorient its starting position.</span></span>  <span data-ttu-id="dfdcb-340">XAML コントロールの一部として出荷される仮想化のレイアウトより少ない制限に表示されるコンテンツの性質上に配置すると、コンテンツに依存するレイアウトとして開発されています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-340">The virtualizing layouts that ship as part of the XAML controls are developed as content-dependent layouts as they place fewer restrictions on the nature of the content that will be shown.</span></span>


### <a name="example-simple-virtualizing-stack-layout-for-variable-sized-items"></a><span data-ttu-id="dfdcb-341">以下に例を示します。可変サイズの項目の単純な仮想化スタック レイアウト</span><span class="sxs-lookup"><span data-stu-id="dfdcb-341">Example: Simple Virtualizing Stack Layout for Variable-Sized Items</span></span>

<span data-ttu-id="dfdcb-342">次の例では項目を可変サイズの単純なスタック レイアウトを示しています。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-342">The sample below demonstrates a simple stack layout for variable-sized items that:</span></span>

* <span data-ttu-id="dfdcb-343">UI の仮想化をサポートしています</span><span class="sxs-lookup"><span data-stu-id="dfdcb-343">supports UI virtualization,</span></span>
* <span data-ttu-id="dfdcb-344">ツールは、見積もりを使用して実現されていない項目のサイズを推測するには</span><span class="sxs-lookup"><span data-stu-id="dfdcb-344">uses estimations to guess the size of unrealized items,</span></span>
* <span data-ttu-id="dfdcb-345">不連続のビューポート シフトする可能性がある場合を認識し、</span><span class="sxs-lookup"><span data-stu-id="dfdcb-345">is aware of potential discontinuous viewport shifts, and</span></span>
* <span data-ttu-id="dfdcb-346">これらのシフトに対応するレイアウトの修正を適用します。</span><span class="sxs-lookup"><span data-stu-id="dfdcb-346">applies layout corrections to account for those shifts.</span></span>

**<span data-ttu-id="dfdcb-347">使い方:マークアップ</span><span class="sxs-lookup"><span data-stu-id="dfdcb-347">Usage: Markup</span></span>**

```xaml
<ScrollViewer>

  <ItemsRepeater x:Name="repeater" >
    <ItemsRepeater.Layout>

      <local:VirtualizingStackLayout />

    </ItemsRepeater.Layout>
    <ItemsRepeater.ItemTemplate>
      <DataTemplate x:Key="item">
        <UserControl IsTabStop="True" UseSystemFocusVisuals="True" Margin="5">
          <StackPanel BorderThickness="1" Background="LightGray" Margin="5">
            <Image x:Name="recipeImage" Source="{Binding ImageUri}"  Width="100" Height="100"/>
              <TextBlock x:Name="recipeDescription"
                         Text="{Binding Description}"
                         TextWrapping="Wrap"
                         Margin="10" />
          </StackPanel>
        </UserControl>
      </DataTemplate>
    </ItemsRepeater.ItemTemplate>
  </ItemsRepeater>

</ScrollViewer>
```

**<span data-ttu-id="dfdcb-348">分離コード:Main.cs</span><span class="sxs-lookup"><span data-stu-id="dfdcb-348">Codebehind: Main.cs</span></span>**

```csharp
string _lorem = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam laoreet erat vel massa rutrum, eget mollis massa vulputate. Vivamus semper augue leo, eget faucibus nulla mattis nec. Donec scelerisque lacus at dui ultricies, eget auctor ipsum placerat. Integer aliquet libero sed nisi eleifend, nec rutrum arcu lacinia. Sed a sem et ante gravida congue sit amet ut augue. Donec quis pellentesque urna, non finibus metus. Proin sed ornare tellus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam laoreet erat vel massa rutrum, eget mollis massa vulputate. Vivamus semper augue leo, eget faucibus nulla mattis nec. Donec scelerisque lacus at dui ultricies, eget auctor ipsum placerat. Integer aliquet libero sed nisi eleifend, nec rutrum arcu lacinia. Sed a sem et ante gravida congue sit amet ut augue. Donec quis pellentesque urna, non finibus metus. Proin sed ornare tellus.";

var rnd = new Random();
var data = new ObservableCollection<Recipe>(Enumerable.Range(0, 300).Select(k =>
               new Recipe
               {
                   ImageUri = new Uri(string.Format("ms-appx:///Images/recipe{0}.png", k % 8 + 1)),
                   Description = k + " - " + _lorem.Substring(0, rnd.Next(50, 350))
               }));

repeater.ItemsSource = data;
```

**<span data-ttu-id="dfdcb-349">コード:VirtualizingStackLayout.cs</span><span class="sxs-lookup"><span data-stu-id="dfdcb-349">Code: VirtualizingStackLayout.cs</span></span>**

```csharp
// This is a sample layout that stacks elements one after
// the other where each item can be of variable height. This is
// also a virtualizing layout - we measure and arrange only elements
// that are in the viewport. Not measuring/arranging all elements means
// that we do not have the complete picture and need to estimate sometimes.
// For example the size of the layout (extent) is an estimation based on the
// average heights we have seen so far. Also, if you drag the mouse thumb
// and yank it quickly, then we estimate what goes in the new viewport.

// The layout caches the bounds of everything that are in the current viewport.
// During measure, we might get a suggested anchor (or start index), we use that
// index to start and layout the rest of the items in the viewport relative to that
// index. Note that since we are estimating, we can end up with negative origin when
// the viewport is somewhere in the middle of the extent. This is achieved by setting the
// LayoutOrigin property on the context. Once this is set, future viewport will account
// for the origin.
public class VirtualizingStackLayout : VirtualizingLayout
{
    // Estimation state
    List<double> m_estimationBuffer = Enumerable.Repeat(0d, 100).ToList();
    int m_numItemsUsedForEstimation = 0;
    double m_totalHeightForEstimation = 0;

    // State to keep track of realized bounds
    int m_firstRealizedDataIndex = 0;
    List<Rect> m_realizedElementBounds = new List<Rect>();

    Rect m_lastExtent = new Rect();

    protected override Size MeasureOverride(VirtualizingLayoutContext context, Size availableSize)
    {
        var viewport = context.RealizationRect;
        DebugTrace("MeasureOverride: Viewport " + viewport);

        // Remove bounds for elements that are now outside the viewport.
        // Proactive recycling elements means we can reuse it during this measure pass again.
        RemoveCachedBoundsOutsideViewport(viewport);

        // Find the index of the element to start laying out from - the anchor
        int startIndex = GetStartIndex(context, availableSize);

        // Measure and layout elements starting from the start index, forward and backward.
        Generate(context, availableSize, startIndex, forward:true);
        Generate(context, availableSize, startIndex, forward:false);

        // Estimate the extent size. Note that this can have a non 0 origin.
        m_lastExtent = EstimateExtent(context, availableSize);
        context.LayoutOrigin = new Point(m_lastExtent.X, m_lastExtent.Y);
        return new Size(m_lastExtent.Width, m_lastExtent.Height);
    }

    protected override Size ArrangeOverride(VirtualizingLayoutContext context, Size finalSize)
    {
        DebugTrace("ArrangeOverride: Viewport" + context.RealizationRect);
        for (int realizationIndex = 0; realizationIndex < m_realizedElementBounds.Count; realizationIndex++)
        {
            int currentDataIndex = m_firstRealizedDataIndex + realizationIndex;
            DebugTrace("Arranging " + currentDataIndex);

            // Arrange the child. If any alignment needs to be done, it
            // can be done here.
            var child = context.GetOrCreateElementAt(currentDataIndex);
            var arrangeBounds = m_realizedElementBounds[realizationIndex];
            arrangeBounds.X -= m_lastExtent.X;
            arrangeBounds.Y -= m_lastExtent.Y;
            child.Arrange(arrangeBounds);
        }

        return finalSize;
    }

    // The data collection has changed, since we are maintaining the bounds of elements
    // in the viewport, we will update the list to account for the collection change.
    protected override void OnItemsChangedCore(VirtualizingLayoutContext context, object source, NotifyCollectionChangedEventArgs args)
    {
        InvalidateMeasure();
        if (m_realizedElementBounds.Count > 0)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnItemsAdded(args.NewStartingIndex, args.NewItems.Count);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    OnItemsRemoved(args.OldStartingIndex, args.OldItems.Count);
                    OnItemsAdded(args.NewStartingIndex, args.NewItems.Count);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnItemsRemoved(args.OldStartingIndex, args.OldItems.Count);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    m_realizedElementBounds.Clear();
                    m_firstRealizedDataIndex = 0;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    // Figure out which index to use as the anchor and start laying out around it.
    private int GetStartIndex(VirtualizingLayoutContext context, Size availableSize)
    {
        int startDataIndex = -1;
        var recommendedAnchorIndex = context.RecommendedAnchorIndex;
        bool isSuggestedAnchorValid = recommendedAnchorIndex != -1;

        if (isSuggestedAnchorValid)
        {
            if (IsRealized(recommendedAnchorIndex))
            {
                startDataIndex = recommendedAnchorIndex;
            }
            else
            {
                ClearRealizedRange();
                startDataIndex = recommendedAnchorIndex;
            }
        }
        else
        {
            // Find the first realized element that is visible in the viewport.
            startDataIndex = GetFirstRealizedDataIndexInViewport(context.RealizationRect);
            if (startDataIndex < 0)
            {
                startDataIndex = EstimateIndexForViewport(context.RealizationRect, context.ItemCount);
                ClearRealizedRange();
            }
        }

        // We have an anchorIndex, realize and measure it and
        // figure out its bounds.
        if (startDataIndex != -1 & context.ItemCount > 0)
        {
            if (m_realizedElementBounds.Count == 0)
            {
                m_firstRealizedDataIndex = startDataIndex;
            }

            var newAnchor = EnsureRealized(startDataIndex);
            DebugTrace("Measuring start index " + startDataIndex);
            var desiredSize = MeasureElement(context, startDataIndex, availableSize);

            var bounds = new Rect(
                0,
                newAnchor ?
                    (m_totalHeightForEstimation / m_numItemsUsedForEstimation) * startDataIndex : GetCachedBoundsForDataIndex(startDataIndex).Y,
                availableSize.Width,
                desiredSize.Height);
            SetCachedBoundsForDataIndex(startDataIndex, bounds);
        }

        return startDataIndex;
    }


    private void Generate(VirtualizingLayoutContext context, Size availableSize, int anchorDataIndex, bool forward)
    {
        // Generate forward or backward from anchorIndex until we hit the end of the viewport
        int step = forward ? 1 : -1;
        int previousDataIndex = anchorDataIndex;
        int currentDataIndex = previousDataIndex + step;
        var viewport = context.RealizationRect;
        while (IsDataIndexValid(currentDataIndex, context.ItemCount) &&
            ShouldContinueFillingUpSpace(previousDataIndex, forward, viewport))
        {
            EnsureRealized(currentDataIndex);
            DebugTrace("Measuring " + currentDataIndex);
            var desiredSize = MeasureElement(context, currentDataIndex, availableSize);
            var previousBounds = GetCachedBoundsForDataIndex(previousDataIndex);
            Rect currentBounds = new Rect(0,
                                          forward ? previousBounds.Y + previousBounds.Height : previousBounds.Y - desiredSize.Height,
                                          availableSize.Width,
                                          desiredSize.Height);
            SetCachedBoundsForDataIndex(currentDataIndex, currentBounds);
            previousDataIndex = currentDataIndex;
            currentDataIndex += step;
        }
    }

    // Remove bounds that are outside the viewport, leaving one extra since our
    // generate stops after generating one extra to know that we are outside the
    // viewport.
    private void RemoveCachedBoundsOutsideViewport(Rect viewport)
    {
        int firstRealizedIndexInViewport = 0;
        while (firstRealizedIndexInViewport < m_realizedElementBounds.Count &&
               !Intersects(m_realizedElementBounds[firstRealizedIndexInViewport], viewport))
        {
            firstRealizedIndexInViewport++;
        }

        int lastRealizedIndexInViewport = m_realizedElementBounds.Count - 1;
        while (lastRealizedIndexInViewport >= 0 &&
            !Intersects(m_realizedElementBounds[lastRealizedIndexInViewport], viewport))
        {
            lastRealizedIndexInViewport--;
        }

        if (firstRealizedIndexInViewport > 0)
        {
            m_firstRealizedDataIndex += firstRealizedIndexInViewport;
            m_realizedElementBounds.RemoveRange(0, firstRealizedIndexInViewport);
        }

        if (lastRealizedIndexInViewport >= 0 && lastRealizedIndexInViewport < m_realizedElementBounds.Count - 2)
        {
            m_realizedElementBounds.RemoveRange(lastRealizedIndexInViewport + 2, m_realizedElementBounds.Count - lastRealizedIndexInViewport - 3);
        }
    }

    private bool Intersects(Rect bounds, Rect viewport)
    {
        return !(bounds.Bottom < viewport.Top ||
            bounds.Top > viewport.Bottom);
    }

    private bool ShouldContinueFillingUpSpace(int dataIndex, bool forward, Rect viewport)
    {
        var bounds = GetCachedBoundsForDataIndex(dataIndex);
        return forward ?
            bounds.Y < viewport.Bottom :
            bounds.Y > viewport.Top;
    }

    private bool IsDataIndexValid(int currentDataIndex, int itemCount)
    {
        return currentDataIndex >= 0 && currentDataIndex < itemCount;
    }

    private int EstimateIndexForViewport(Rect viewport, int dataCount)
    {
        double averageHeight = m_totalHeightForEstimation / m_numItemsUsedForEstimation;
        int estimatedIndex = (int)(viewport.Top / averageHeight);
        // clamp to an index within the collection
        estimatedIndex = Math.Max(0, Math.Min(estimatedIndex, dataCount));
        return estimatedIndex;
    }

    private int GetFirstRealizedDataIndexInViewport(Rect viewport)
    {
        int index = -1;
        if (m_realizedElementBounds.Count > 0)
        {
            for (int i = 0; i < m_realizedElementBounds.Count; i++)
            {
                if (m_realizedElementBounds[i].Y < viewport.Bottom &&
                   m_realizedElementBounds[i].Bottom > viewport.Top)
                {
                    index = m_firstRealizedDataIndex + i;
                    break;
                }
            }
        }

        return index;
    }

    private Size MeasureElement(VirtualizingLayoutContext context, int index, Size availableSize)
    {
        var child = context.GetOrCreateElementAt(index);
        child.Measure(availableSize);

        int estimationBufferIndex = index % m_estimationBuffer.Count;
        bool alreadyMeasured = m_estimationBuffer[estimationBufferIndex] != 0;
        if (!alreadyMeasured)
        {
            m_numItemsUsedForEstimation++;
        }

        m_totalHeightForEstimation -= m_estimationBuffer[estimationBufferIndex];
        m_totalHeightForEstimation += child.DesiredSize.Height;
        m_estimationBuffer[estimationBufferIndex] = child.DesiredSize.Height;

        return child.DesiredSize;
    }

    private bool EnsureRealized(int dataIndex)
    {
        if (!IsRealized(dataIndex))
        {
            int realizationIndex = RealizationIndex(dataIndex);
            Debug.Assert(dataIndex == m_firstRealizedDataIndex - 1 ||
                dataIndex == m_firstRealizedDataIndex + m_realizedElementBounds.Count ||
                m_realizedElementBounds.Count == 0);

            if (realizationIndex == -1)
            {
                m_realizedElementBounds.Insert(0, new Rect());
            }
            else
            {
                m_realizedElementBounds.Add(new Rect());
            }

            if (m_firstRealizedDataIndex > dataIndex)
            {
                m_firstRealizedDataIndex = dataIndex;
            }

            return true;
        }

        return false;
    }

    // Figure out the extent of the layout by getting the number of items remaining
    // above and below the realized elements and getting an estimation based on
    // average item heights seen so far.
    private Rect EstimateExtent(VirtualizingLayoutContext context, Size availableSize)
    {
        double averageHeight = m_totalHeightForEstimation / m_numItemsUsedForEstimation;

        Rect extent = new Rect(0, 0, availableSize.Width, context.ItemCount * averageHeight);

        if (context.ItemCount > 0 && m_realizedElementBounds.Count > 0)
        {
            extent.Y = m_firstRealizedDataIndex == 0 ?
                            m_realizedElementBounds[0].Y :
                            m_realizedElementBounds[0].Y - (m_firstRealizedDataIndex - 1) * averageHeight;

            int lastRealizedIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count;
            if (lastRealizedIndex == context.ItemCount - 1)
            {
                var lastBounds = m_realizedElementBounds[m_realizedElementBounds.Count - 1];
                extent.Y = lastBounds.Bottom;
            }
            else
            {
                var lastBounds = m_realizedElementBounds[m_realizedElementBounds.Count - 1];
                int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count;
                int numItemsAfterLastRealizedIndex = context.ItemCount - lastRealizedDataIndex;
                extent.Height = lastBounds.Bottom + numItemsAfterLastRealizedIndex * averageHeight - extent.Y;
            }
        }

        DebugTrace("Extent " + extent + " with average height " + averageHeight);
        return extent;
    }

    private bool IsRealized(int dataIndex)
    {
        int realizationIndex = dataIndex - m_firstRealizedDataIndex;
        return realizationIndex >= 0 && realizationIndex < m_realizedElementBounds.Count;
    }

    // Index in the m_realizedElementBounds collection
    private int RealizationIndex(int dataIndex)
    {
        return dataIndex - m_firstRealizedDataIndex;
    }

    private void OnItemsAdded(int index, int count)
    {
        // Using the old indexes here (before it was updated by the collection change)
        // if the insert data index is between the first and last realized data index, we need
        // to insert items.
        int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count - 1;
        int newStartingIndex = index;
        if (newStartingIndex > m_firstRealizedDataIndex &&
            newStartingIndex <= lastRealizedDataIndex)
        {
            // Inserted within the realized range
            int insertRangeStartIndex = newStartingIndex - m_firstRealizedDataIndex;
            for (int i = 0; i < count; i++)
            {
                // Insert null (sentinel) here instead of an element, that way we do not
                // end up creating a lot of elements only to be thrown out in the next layout.
                int insertRangeIndex = insertRangeStartIndex + i;
                int dataIndex = newStartingIndex + i;
                // This is to keep the contiguousness of the mapping
                m_realizedElementBounds.Insert(insertRangeIndex, new Rect());
            }
        }
        else if (index <= m_firstRealizedDataIndex)
        {
            // Items were inserted before the realized range.
            // We need to update m_firstRealizedDataIndex;
            m_firstRealizedDataIndex += count;
        }
    }

    private void OnItemsRemoved(int index, int count)
    {
        int lastRealizedDataIndex = m_firstRealizedDataIndex + m_realizedElementBounds.Count - 1;
        int startIndex = Math.Max(m_firstRealizedDataIndex, index);
        int endIndex = Math.Min(lastRealizedDataIndex, index + count - 1);
        bool removeAffectsFirstRealizedDataIndex = (index <= m_firstRealizedDataIndex);

        if (endIndex >= startIndex)
        {
            ClearRealizedRange(RealizationIndex(startIndex), endIndex - startIndex + 1);
        }

        if (removeAffectsFirstRealizedDataIndex &&
            m_firstRealizedDataIndex != -1)
        {
            m_firstRealizedDataIndex -= count;
        }
    }

    private void ClearRealizedRange(int startRealizedIndex, int count)
    {
        m_realizedElementBounds.RemoveRange(startRealizedIndex, count);
        if (startRealizedIndex == 0)
        {
            m_firstRealizedDataIndex = m_realizedElementBounds.Count == 0 ? 0 : m_firstRealizedDataIndex + count;
        }
    }

    private void ClearRealizedRange()
    {
        m_realizedElementBounds.Clear();
        m_firstRealizedDataIndex = 0;
    }

    private Rect GetCachedBoundsForDataIndex(int dataIndex)
    {
        return m_realizedElementBounds[RealizationIndex(dataIndex)];
    }

    private void SetCachedBoundsForDataIndex(int dataIndex, Rect bounds)
    {
        m_realizedElementBounds[RealizationIndex(dataIndex)] = bounds;
    }

    private Rect GetCachedBoundsForRealizationIndex(int relativeIndex)
    {
        return m_realizedElementBounds[relativeIndex];
    }

    void DebugTrace(string message, params object[] args)
    {
        Debug.WriteLine(message, args);
    }
}
```

## <a name="related-articles"></a><span data-ttu-id="dfdcb-350">関連記事</span><span class="sxs-lookup"><span data-stu-id="dfdcb-350">Related articles</span></span>

- [<span data-ttu-id="dfdcb-351">ItemsRepeater</span><span class="sxs-lookup"><span data-stu-id="dfdcb-351">ItemsRepeater</span></span>](/uwp/api/microsoft.ui.xaml.controls.itemsrepeater)
- [<span data-ttu-id="dfdcb-352">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="dfdcb-352">ScrollViewer</span></span>](/uwp/api/windows.ui.xaml.controls.scrollviewer)
