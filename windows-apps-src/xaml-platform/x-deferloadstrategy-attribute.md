---
title: xDeferLoadStrategy 属性
description: xDeferLoadStrategy は、要素とその子の作成を遅延させます。起動時間は短くなりますが、メモリ使用量は若干増加します。 影響を受けるそれぞれの要素によって、メモリ使用量が約 600 バイト増加します。
ms.assetid: E763898E-13FF-4412-B502-B54DBFE2D4E4
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 4432362db74f830774a2c4f74401c472c128a120
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659987"
---
# <a name="xdeferloadstrategy-attribute"></a><span data-ttu-id="e6bea-105">x:DeferLoadStrategy 属性</span><span class="sxs-lookup"><span data-stu-id="e6bea-105">x:DeferLoadStrategy attribute</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e6bea-106">Windows 10 Version 1703 (Creators Update) 以降、**x:DeferLoadStrategy** は [**x:Load attribute**](x-load-attribute.md) に置き換わります。</span><span class="sxs-lookup"><span data-stu-id="e6bea-106">Starting in Windows 10, version 1703 (Creators Update), **x:DeferLoadStrategy** is superseded by the [**x:Load attribute**](x-load-attribute.md).</span></span> <span data-ttu-id="e6bea-107">`x:Load="False"` を使うと、`x:DeferLoadStrategy="Lazy"` と同じ効果がありますが、さらに必要に応じて UI のアンロードも可能です。</span><span class="sxs-lookup"><span data-stu-id="e6bea-107">Using `x:Load="False"` is equivalent to `x:DeferLoadStrategy="Lazy"`, but provides the ability to unload the UI if required.</span></span> <span data-ttu-id="e6bea-108">詳しくは、「[x:Load 属性](x-load-attribute.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6bea-108">See the [x:Load attribute](x-load-attribute.md) for more info.</span></span>

<span data-ttu-id="e6bea-109">**x:DeferLoadStrategy="Lazy"** を使うと、XAML アプリの起動やツリー作成パフォーマンスを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-109">You can use **x:DeferLoadStrategy="Lazy"** to optimize the startup or tree creation performance of your XAML app.</span></span> <span data-ttu-id="e6bea-110">**x:DeferLoadStrategy="Lazy"** を使うと、要素とその子の作成が遅延されるため、起動時間とメモリ コストが縮小されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-110">When you use **x:DeferLoadStrategy="Lazy"**, creation of an element and its children is delayed, which decreases startup time and memory costs.</span></span> <span data-ttu-id="e6bea-111">これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-111">This is useful to reduce the costs of elements that are shown infrequently or conditionally.</span></span> <span data-ttu-id="e6bea-112">要素は、コードまたは VisualStateManager から参照された時点で実体化されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-112">The element will be realized when it's referred to from code or VisualStateManager.</span></span>

<span data-ttu-id="e6bea-113">ただし、XAML フレームワークによる遅延要素の追跡で、影響を受ける各要素のメモリ使用量に約 600 バイトが追加されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-113">However, the tracking of deferred elements by the XAML framework adds about 600 bytes to the memory usage for each element affected.</span></span> <span data-ttu-id="e6bea-114">遅延させる要素ツリーが大きいほど、起動時間がより節約されます。ただし、メモリ使用量のコストは増加します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-114">The larger the element tree you defer, the more startup time you'll save, but at the cost of a greater memory footprint.</span></span> <span data-ttu-id="e6bea-115">したがって、この属性を過剰に使うとパフォーマンスが低下する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e6bea-115">Therefore, it's possible to overuse this attribute to the extent that your performance decreases.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="e6bea-116">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="e6bea-116">XAML attribute usage</span></span>

``` syntax
<object x:DeferLoadStrategy="Lazy" .../>
```

## <a name="remarks"></a><span data-ttu-id="e6bea-117">注釈</span><span class="sxs-lookup"><span data-stu-id="e6bea-117">Remarks</span></span>

<span data-ttu-id="e6bea-118">**x:DeferLoadStrategy** を使う際の制約を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-118">The restrictions for using **x:DeferLoadStrategy** are:</span></span>

- <span data-ttu-id="e6bea-119">定義する必要があります、 [X:name](x-name-attribute.md) 要素にそこにある必要がありますを後で、要素を見つけることです。</span><span class="sxs-lookup"><span data-stu-id="e6bea-119">You must define an [x:Name](x-name-attribute.md) for the element, as there needs to be a way to find the element later.</span></span>
- <span data-ttu-id="e6bea-120">遅延できるのは、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) または [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249) から派生した型のみです。</span><span class="sxs-lookup"><span data-stu-id="e6bea-120">You can only defer types that derive from [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) or [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249).</span></span>
- <span data-ttu-id="e6bea-121">[  **Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) のルート要素は遅延できません。</span><span class="sxs-lookup"><span data-stu-id="e6bea-121">You cannot defer root elements in a [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page), a [**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol), or a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348).</span></span>
- <span data-ttu-id="e6bea-122">[  **ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の要素は遅延できません。</span><span class="sxs-lookup"><span data-stu-id="e6bea-122">You cannot defer elements in a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span>
- <span data-ttu-id="e6bea-123">[  **XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) で読み込まれた Loose XAML は遅延できません。</span><span class="sxs-lookup"><span data-stu-id="e6bea-123">You cannot defer loose XAML loaded with [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048).</span></span>
- <span data-ttu-id="e6bea-124">親要素を移動すると、実現されていない要素はすべて消去されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-124">Moving a parent element will clear out any elements that have not been realized.</span></span>

<span data-ttu-id="e6bea-125">遅延要素を実現するには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="e6bea-125">There are several different ways to realize the deferred elements:</span></span>

- <span data-ttu-id="e6bea-126">要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-126">Call [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) with the name that you defined on the element.</span></span>
- <span data-ttu-id="e6bea-127">要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-127">Call [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) with the name that you defined on the element.</span></span>
- <span data-ttu-id="e6bea-128">[  **VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) で、遅延要素をターゲットに設定している [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または **Storyboard** アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="e6bea-128">In a [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007), use a [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) or **Storyboard** animation that targets the deferred element.</span></span>
- <span data-ttu-id="e6bea-129">任意の **Storyboard** で遅延要素をターゲットに設定します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-129">Target the deferred element in any **Storyboard**.</span></span>
- <span data-ttu-id="e6bea-130">遅延要素をターゲットに設定しているバインドを使います。</span><span class="sxs-lookup"><span data-stu-id="e6bea-130">Use a binding that targets the deferred element.</span></span>

> <span data-ttu-id="e6bea-131">注: 要素のインスタンス化が開始されたら、UI 途切れたりすぎる場合、一度に多く作成することになるため、UI スレッドで作成されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-131">NOTE: Once the instantiation of an element has started, it is created on the UI thread, so it could cause the UI to stutter if too much is created at once.</span></span>

<span data-ttu-id="e6bea-132">上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-132">Once a deferred element is created in any of the ways listed previously, several things happen:</span></span>

- <span data-ttu-id="e6bea-133">要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-133">The [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) event on the element is raised.</span></span>
- <span data-ttu-id="e6bea-134">要素のバインドが評価されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-134">Any bindings on the element are evaluated.</span></span>
- <span data-ttu-id="e6bea-135">遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-135">If you have registered to receive property change notifications on the property containing the deferred element(s), the notification is raised.</span></span>

<span data-ttu-id="e6bea-136">遅延要素は入れ子にできますが、最も外側の要素から実体化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e6bea-136">You can nest deferred elements, however they have to be realized from the outer-most element in.</span></span> <span data-ttu-id="e6bea-137"> 親が実体化される前に子要素を実体化しようとすると、例外が生成されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-137"> If you try to realize a child element before the parent has been realized, an exception is raised.</span></span>

<span data-ttu-id="e6bea-138">通常は、最初のフレームに表示できないものを遅延させることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e6bea-138">Typically, we recommend that you defer elements that are not viewable in the first frame.</span></span><span data-ttu-id="e6bea-139"> 遅延対象の候補を見つけるための指針の 1 つは、[*\*Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。</span><span class="sxs-lookup"><span data-stu-id="e6bea-139"> A good guideline for finding candidates to be deferred is to look for elements that are being created with collapsed [*\*Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992).</span></span> <span data-ttu-id="e6bea-140">また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。</span><span class="sxs-lookup"><span data-stu-id="e6bea-140">Also, UI that is triggered by user interaction is a good place to look for elements that you can defer.</span></span>

<span data-ttu-id="e6bea-141">[  **ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。</span><span class="sxs-lookup"><span data-stu-id="e6bea-141">Be wary of deferring elements in a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878), as it will decrease your startup time, but could also decrease your panning performance depending on what you're creating.</span></span> <span data-ttu-id="e6bea-142">パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6bea-142">If you are looking to increase panning performance, see the [{x:Bind} markup extension](x-bind-markup-extension.md) and [x:Phase attribute](x-phase-attribute.md) documentation.</span></span>

<span data-ttu-id="e6bea-143">**x:DeferLoadStrategy** と同時に [x:Phase 属性](x-phase-attribute.md)を使った場合、要素または要素ツリーが実体化されると、バインディングが現在のフェーズまで (現在のフェーズを含めて) 適用されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-143">If the [x:Phase attribute](x-phase-attribute.md) is used in conjunction with **x:DeferLoadStrategy** then, when an element or an element tree is realized, the bindings are applied up to and including the current phase.</span></span> <span data-ttu-id="e6bea-144">**x:Phase** に指定されたフェーズによって、要素の遅延が影響または制御されることはありません。</span><span class="sxs-lookup"><span data-stu-id="e6bea-144">The phase specified for **x:Phase** does not affect or control the deferral of the element.</span></span> <span data-ttu-id="e6bea-145">パンの一部としてリスト項目がリサイクルされると、実体化された要素は、アクティブな他の要素と同じように機能し、コンパイル済みバインド (**{x:Bind}** バインディング) は同じルール (フェージングを含む) を使って処理されます。</span><span class="sxs-lookup"><span data-stu-id="e6bea-145">When a list item is recycled as part of panning, realized elements behave in the same way as other active elements, and compiled bindings (**{x:Bind}** bindings) are processed using the same rules, including phasing.</span></span>

<span data-ttu-id="e6bea-146">一般的なガイドラインでは、必要なパフォーマンスが得られていることを確認するために、作業の前と後にアプリのパフォーマンスを測定します。</span><span class="sxs-lookup"><span data-stu-id="e6bea-146">A general guideline is to measure the performance of your app before and after to make sure you are getting the performance that you want.</span></span>

## <a name="example"></a><span data-ttu-id="e6bea-147">例</span><span class="sxs-lookup"><span data-stu-id="e6bea-147">Example</span></span>

```xml
<Grid x:Name="DeferredGrid" x:DeferLoadStrategy="Lazy">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="Auto" />
    </Grid.ColumnDefinitions>

    <Rectangle Height="100" Width="100" Fill="#F65314" Margin="0,0,4,4" />
    <Rectangle Height="100" Width="100" Fill="#7CBB00" Grid.Column="1" Margin="4,0,0,4" />
    <Rectangle Height="100" Width="100" Fill="#00A1F1" Grid.Row="1" Margin="0,4,4,0" />
    <Rectangle Height="100" Width="100" Fill="#FFBB00" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0" />
</Grid>
<Button x:Name="RealizeElements" Content="Realize Elements" Click="RealizeElements_Click"/>
```

```csharp
private void RealizeElements_Click(object sender, RoutedEventArgs e)
{
    // This will realize the deferred grid.
    this.FindName("DeferredGrid");
}
```
