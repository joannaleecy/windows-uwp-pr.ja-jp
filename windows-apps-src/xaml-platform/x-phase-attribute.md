---
author: jwmsft
title: xPhase 属性
description: ListView や GridView の項目を段階的にレンダリングし、パン エクスペリエンスを向上させるには、xPhase を xBind マークアップ拡張と共に使用します。
ms.assetid: BD17780E-6A34-4A38-8D11-9703107E247E
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 17ee99553b5713acb1917ccb697abb2387d00da2
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6262976"
---
# <a name="xphase-attribute"></a><span data-ttu-id="7a725-104">x:Phase 属性</span><span class="sxs-lookup"><span data-stu-id="7a725-104">x:Phase attribute</span></span>


<span data-ttu-id="7a725-105">[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) の項目を段階的にレンダリングし、パン エクスペリエンスを向上させるには、**x:Phase** を [{x:Bind} マークアップ拡張](x-bind-markup-extension.md)と共に使用します。</span><span class="sxs-lookup"><span data-stu-id="7a725-105">Use **x:Phase** with the [{x:Bind} markup extension](x-bind-markup-extension.md) to render [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) items incrementally and improve the panning experience.</span></span> <span data-ttu-id="7a725-106">**x:Phase** では、宣言的な方法により、[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) イベントを使ってリスト項目のレンダリングを手動で制御するのと同じ結果を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="7a725-106">**x:Phase** provides a declarative way of achieving the same effect as using the [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) event to manually control the rendering of list items.</span></span> <span data-ttu-id="7a725-107">「[GridView と ListView の項目を段階的に更新する](../debug-test-perf/optimize-gridview-and-listview.md#update-items-incrementally)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a725-107">Also see [Update ListView and GridView items incrementally](../debug-test-perf/optimize-gridview-and-listview.md#update-items-incrementally).</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="7a725-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="7a725-108">XAML attribute usage</span></span>


``` syntax
<object x:Phase="PhaseValue".../>
```

## <a name="xaml-values"></a><span data-ttu-id="7a725-109">XAML 値</span><span class="sxs-lookup"><span data-stu-id="7a725-109">XAML values</span></span>


| <span data-ttu-id="7a725-110">用語</span><span class="sxs-lookup"><span data-stu-id="7a725-110">Term</span></span> | <span data-ttu-id="7a725-111">説明</span><span class="sxs-lookup"><span data-stu-id="7a725-111">Description</span></span> |
|------|-------------|
| <span data-ttu-id="7a725-112">PhaseValue</span><span class="sxs-lookup"><span data-stu-id="7a725-112">PhaseValue</span></span> | <span data-ttu-id="7a725-113">要素が処理されるフェーズを示す数値。</span><span class="sxs-lookup"><span data-stu-id="7a725-113">A number that indicates the phase in which the element will be processed.</span></span> <span data-ttu-id="7a725-114">既定値は 0 です。</span><span class="sxs-lookup"><span data-stu-id="7a725-114">The default is 0.</span></span> | 

## <a name="remarks"></a><span data-ttu-id="7a725-115">注釈</span><span class="sxs-lookup"><span data-stu-id="7a725-115">Remarks</span></span>

<span data-ttu-id="7a725-116">タッチ操作でリストをすばやくパンした場合やマウス ホイールを使用した場合、データ テンプレートの複雑さによっては、リスト項目をすばやくレンダリングできず、スクロール速度に追いつかないことがあります。</span><span class="sxs-lookup"><span data-stu-id="7a725-116">If a list is panned fast with touch, or using the mouse wheel, then depending on the complexity of the data template, the list may not be able to render items fast enough to keep up with the speed of scrolling.</span></span> <span data-ttu-id="7a725-117">これは、電話やタブレットなど、電力効率に優れた CPU を搭載したポータブル デバイスに特に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="7a725-117">This is particularly true for a portable device with a power-efficient CPU such as a phone or a tablet.</span></span>

<span data-ttu-id="7a725-118">フェージングにより、データ テンプレートを段階的にレンダリングできるので、コンテンツに優先順位を付け、最も重要な要素を最初にレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="7a725-118">Phasing enables incremental rendering of the data template so that the contents can be prioritized, and the most important elements rendered first.</span></span> <span data-ttu-id="7a725-119">これにより、すばやくパンした場合でも各項目のコンテンツの一部をリストに表示でき、時間が許す限り各テンプレートの要素がより多くレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7a725-119">This enables the list to show some content for each item if panning fast, and will render more elements of each template as time permits.</span></span>

## <a name="example"></a><span data-ttu-id="7a725-120">例</span><span class="sxs-lookup"><span data-stu-id="7a725-120">Example</span></span>

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
        <TextBlock Text="{x:Bind prettyDate}"  Grid.Column="1"  Grid.Row="1" FontSize="12" x:Phase="1"/>
        <TextBlock Text="{x:Bind prettyFileSize}"  Grid.Column="1"  Grid.Row="2" FontSize="12" x:Phase="2"/>
        <TextBlock Text="{x:Bind prettyImageSize}"  Grid.Column="1"  Grid.Row="3" FontSize="12" x:Phase="2"/>
    </Grid>
</DataTemplate>
```

<span data-ttu-id="7a725-121">データ テンプレートには、以下の 4 つのフェーズが記述されます。</span><span class="sxs-lookup"><span data-stu-id="7a725-121">The data template describes 4 phases:</span></span>

1.  <span data-ttu-id="7a725-122">DisplayName テキスト ブロックを表示する。</span><span class="sxs-lookup"><span data-stu-id="7a725-122">Presents the DisplayName text block.</span></span> <span data-ttu-id="7a725-123">フェーズが指定されていないコントロールはすべて、フェーズ 0 に含まれるものと暗黙的に見なされます。</span><span class="sxs-lookup"><span data-stu-id="7a725-123">All controls without a phase specified will be implicitly considered to be part of phase 0.</span></span>
2.  <span data-ttu-id="7a725-124">PrettyDate のテキスト ブロックを表示する。</span><span class="sxs-lookup"><span data-stu-id="7a725-124">Shows the prettyDate text block.</span></span>
3.  <span data-ttu-id="7a725-125">PrettyFileSize および prettyImageSize テキスト ブロックを表示する。</span><span class="sxs-lookup"><span data-stu-id="7a725-125">Shows the prettyFileSize and prettyImageSize text blocks.</span></span>
4.  <span data-ttu-id="7a725-126">画像を表示する。</span><span class="sxs-lookup"><span data-stu-id="7a725-126">Shows the image.</span></span>

<span data-ttu-id="7a725-127">フェージングは、[{x:Bind}](x-bind-markup-extension.md) の機能の 1 つであり、[**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879) から派生したコントロールを操作し、データ バインディングの項目テンプレートを段階的に処理します。</span><span class="sxs-lookup"><span data-stu-id="7a725-127">Phasing is a feature of [{x:Bind}](x-bind-markup-extension.md) that works with controls derived from [**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879) and that incrementally processes the item template for data binding.</span></span> <span data-ttu-id="7a725-128">リスト項目をレンダリングする場合、**ListViewBase** は、ビューのすべての項目の 1 つのフェーズをレンダリングし、それから次のフェーズに進みます。</span><span class="sxs-lookup"><span data-stu-id="7a725-128">When rendering list items, **ListViewBase** renders a single phase for all items in the view before moving onto the next phase.</span></span> <span data-ttu-id="7a725-129">レンダリング処理は、リストのスクロール時、必要な処理を再割り当てできるようにタイム スライス バッチで実行されます。表示できなくなった項目に対しては、実行されません。</span><span class="sxs-lookup"><span data-stu-id="7a725-129">The rendering work is performed in time-sliced batches so that as the list is scrolled, the work required can be re-assessed, and not performed for items that are no longer visible.</span></span>

<span data-ttu-id="7a725-130">**x:Phase** 属性は、[{x:Bind}](x-bind-markup-extension.md) を使用するデータ テンプレートのどの要素に対しても指定できます。</span><span class="sxs-lookup"><span data-stu-id="7a725-130">The **x:Phase** attribute can be specified on any element in a data template that uses [{x:Bind}](x-bind-markup-extension.md).</span></span> <span data-ttu-id="7a725-131">要素のフェーズが 0 以外の場合、その要素は、フェーズが処理され、バインディングが更新されるまで、ビューから隠されます (**Visibility** ではなく、**Opacity** により)。</span><span class="sxs-lookup"><span data-stu-id="7a725-131">When an element has a phase other than 0, the element will be hidden from view (via **Opacity**, not **Visibility**) until that phase is processed and bindings are updated.</span></span> <span data-ttu-id="7a725-132">[**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879) 派生コントロールがスクロールされると、画面に表示されなくなった項目からの項目テンプレートがリサイクルされ、新しい表示可能な項目がレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7a725-132">When a [**ListViewBase**](https://msdn.microsoft.com/library/windows/apps/br242879)-derived control is scrolled, it will recycle the item templates from items that are no longer on screen to render the newly visible items.</span></span> <span data-ttu-id="7a725-133">テンプレート内の UI 要素は、再びデータ バインドされるまで古い値を保持します。</span><span class="sxs-lookup"><span data-stu-id="7a725-133">UI elements within the template will retain their old values until they are data-bound again.</span></span> <span data-ttu-id="7a725-134">フェージングにより、そのデータ バインディング ステップは遅延されます。したがって、フェージングでは、UI 要素が古くなった場合は、その UI 要素を隠す必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a725-134">Phasing causes that data-binding step to be delayed, and therefore phasing needs to hide the UI elements in case they are stale.</span></span>

<span data-ttu-id="7a725-135">各 UI 要素に指定されているフェーズが 1 つだけの場合があります。</span><span class="sxs-lookup"><span data-stu-id="7a725-135">Each UI element may have only one phase specified.</span></span> <span data-ttu-id="7a725-136">その場合、そのフェーズは要素のすべてのバインディングに適用されます。</span><span class="sxs-lookup"><span data-stu-id="7a725-136">If so, that will apply to all bindings on the element.</span></span> <span data-ttu-id="7a725-137">フェーズが指定されていない場合は、フェーズ 0 と見なされます。</span><span class="sxs-lookup"><span data-stu-id="7a725-137">If a phase is not specified, phase 0 is assumed.</span></span>

<span data-ttu-id="7a725-138">フェーズ番号は、連続している必要はなく、[**ContainerContentChangingEventArgs.Phase**](https://msdn.microsoft.com/library/windows/apps/dn298493) の値と同じです。</span><span class="sxs-lookup"><span data-stu-id="7a725-138">Phase numbers do not need to be contiguous and are the same as the value of [**ContainerContentChangingEventArgs.Phase**](https://msdn.microsoft.com/library/windows/apps/dn298493).</span></span> <span data-ttu-id="7a725-139">[**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) イベントは、**x:Phase** バインディングが処理される前に各フェーズで生成されます。</span><span class="sxs-lookup"><span data-stu-id="7a725-139">The [**ContainerContentChanging**](https://msdn.microsoft.com/library/windows/apps/dn298914) event will be raised for each phase before the **x:Phase** bindings are processed.</span></span>

<span data-ttu-id="7a725-140">フェージングは、 [{x:Bind}](x-bind-markup-extension.md) バインディングにのみ影響し、 [{Binding}](binding-markup-extension.md) バインディングには影響しません。</span><span class="sxs-lookup"><span data-stu-id="7a725-140">Phasing only affects [{x:Bind}](x-bind-markup-extension.md) bindings, not [{Binding}](binding-markup-extension.md) bindings.</span></span>

<span data-ttu-id="7a725-141">フェージングが適用されるのは、フェージングを認識するコントロールを使用して項目テンプレートがレンダリングされるときのみです。</span><span class="sxs-lookup"><span data-stu-id="7a725-141">Phasing will only apply when the item template is rendered using a control that is aware of phasing.</span></span> <span data-ttu-id="7a725-142">Windows 10 では、 [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878)と[**GridView を**](https://msdn.microsoft.com/library/windows/apps/br242705)場合します。</span><span class="sxs-lookup"><span data-stu-id="7a725-142">For Windows10, that means [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705).</span></span> <span data-ttu-id="7a725-143">フェージングは、他の項目コントロールで使用されるデータ テンプレートには適用されません。また、[**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/br209369) または [**Hub**](https://msdn.microsoft.com/library/windows/apps/dn251843) セクション (この場合、すべての UI 要素が同時にデータ バインドされる) などの他のシナリオでも適用されません。</span><span class="sxs-lookup"><span data-stu-id="7a725-143">Phasing will not apply to data templates used in other item controls, or for other scenarios such as [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/br209369) or [**Hub**](https://msdn.microsoft.com/library/windows/apps/dn251843) sections—in those cases, all the UI elements will be data bound at once.</span></span>

