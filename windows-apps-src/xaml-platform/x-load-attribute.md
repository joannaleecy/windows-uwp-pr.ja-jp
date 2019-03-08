---
title: xLoad 属性
description: xLoad を使用すると、要素および子の動的な作成とデストラクションが可能になり、スタートアップ時間とメモリ使用量を削減できます。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1fa0f12779ad56d57c92f667443644851dc3d5e5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629367"
---
# <a name="xload-attribute"></a><span data-ttu-id="ebbc1-104">x:Load 属性</span><span class="sxs-lookup"><span data-stu-id="ebbc1-104">x:Load attribute</span></span>

<span data-ttu-id="ebbc1-105">スタートアップ、ビジュアル ツリーの作成、XAML アプリのメモリ使用量を最適化するには、**x:Load** を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-105">You can use **x:Load** to optimize the startup, visual tree creation, and memory usage of your XAML app.</span></span> <span data-ttu-id="ebbc1-106">**x:Load** の使用には、**Visibility** と同様の効果があります。ただし、要素が読み込まれていない場合はメモリが解放され、内部的に小さなプレースホルダーを使ってビジュアル ツリー内の場所がマークされます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-106">Using **x:Load** has a similar visual effect to **Visibility**, except that when the element is not loaded, its memory is released and internally a small placeholder is used to mark its place in the visual tree.</span></span>

<span data-ttu-id="ebbc1-107">x:Load 属性が指定された UI 要素の読み込み/アンロードには、コードを使用することも、[x:Bind](x-bind-markup-extension.md) 式を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-107">The UI element attributed with x:Load can be loaded and unloaded via code, or using an [x:Bind](x-bind-markup-extension.md) expression.</span></span> <span data-ttu-id="ebbc1-108">これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-108">This is useful to reduce the costs of elements that are shown infrequently or conditionally.</span></span> <span data-ttu-id="ebbc1-109">Grid や StackPanel などのコンテナーに x:Load を使用した場合は、コンテナーおよびすべての子がグループとして読み込まれ、アンロードされます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-109">When you use x:Load on a container such as Grid or StackPanel, the container and all of its children are loaded or unloaded as a group.</span></span>

<span data-ttu-id="ebbc1-110">XAML フレームワークによる遅延要素の追跡では、x:Load 属性が指定された要素ごとに、プレースホルダー分として約 600 バイトがメモリ使用量に追加されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-110">The tracking of deferred elements by the XAML framework adds about 600 bytes to the memory usage for each element attributed with x:Load, to account for the placeholder.</span></span> <span data-ttu-id="ebbc1-111">したがって、この属性を過剰に使うと実際のパフォーマンスが低下する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-111">Therefore, it's possible to overuse this attribute to the extent that your performance actually decreases.</span></span> <span data-ttu-id="ebbc1-112">この属性は、非表示にする必要がある要素のみに対して使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-112">We recommend that you only use it on elements that need to be hidden.</span></span> <span data-ttu-id="ebbc1-113">コンテナーに対して x:Load を使用した場合、その効果があるのは x:Load 属性を指定した要素のみです。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-113">If you use x:Load on a container, then the overhead is paid only for the element with the x:Load attribute.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="ebbc1-114">X: 負荷属性では、Windows 10 バージョン 1703 (Creators Update) 以降を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-114">The x:Load attribute is available starting in Windows 10, version 1703 (Creators Update).</span></span> <span data-ttu-id="ebbc1-115">x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-115">The min version targeted by your Visual Studio project must be *Windows 10 Creators Update (10.0, Build 15063)* in order to use x:Load.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="ebbc1-116">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="ebbc1-116">XAML attribute usage</span></span>

``` syntax
<object x:Load="True" .../>
<object x:Load="False" .../>
<object x:Load="{x:Bind Path.to.a.boolean, Mode=OneWay}" .../>
```

## <a name="loading-elements"></a><span data-ttu-id="ebbc1-117">要素の読み込み</span><span class="sxs-lookup"><span data-stu-id="ebbc1-117">Loading Elements</span></span>

<span data-ttu-id="ebbc1-118">要素を読み込むには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-118">There are several different ways to load the elements:</span></span>

- <span data-ttu-id="ebbc1-119">[x:Bind](x-bind-markup-extension.md) 式を使用して読み込み状態を指定します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-119">Use an [x:Bind](x-bind-markup-extension.md) expression to specify the load state.</span></span> <span data-ttu-id="ebbc1-120">この式は、要素を読み込む場合は **true**、アンロードする場合は **false** を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-120">The expression should return **true** to load and **false** to unload the element.</span></span>
- <span data-ttu-id="ebbc1-121">要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-121">Call [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) with the name that you defined on the element.</span></span>
- <span data-ttu-id="ebbc1-122">要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-122">Call [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) with the name that you defined on the element.</span></span>
- <span data-ttu-id="ebbc1-123">[  **VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) で、x:Load をターゲットに設定している [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または **Storyboard** アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-123">In a [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007), use a [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) or **Storyboard** animation that targets the x:Load element.</span></span>
- <span data-ttu-id="ebbc1-124">任意の **Storyboard** のアンロード済み要素をターゲットに設定します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-124">Target the unloaded element in any **Storyboard**.</span></span>

> <span data-ttu-id="ebbc1-125">注: 要素のインスタンス化が開始されたら、UI 途切れたりすぎる場合、一度に多く作成することになるため、UI スレッドで作成されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-125">NOTE: Once the instantiation of an element has started, it is created on the UI thread, so it could cause the UI to stutter if too much is created at once.</span></span>

<span data-ttu-id="ebbc1-126">上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-126">Once a deferred element is created in any of the ways listed previously, several things happen:</span></span>

- <span data-ttu-id="ebbc1-127">要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-127">The [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) event on the element is raised.</span></span>
- <span data-ttu-id="ebbc1-128">x:Name のフィールドが設定されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-128">The field for x:Name is set.</span></span>
- <span data-ttu-id="ebbc1-129">要素に対する任意の x:Bind バインドが評価されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-129">Any x:Bind bindings on the element are evaluated.</span></span>
- <span data-ttu-id="ebbc1-130">遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-130">If you have registered to receive property change notifications on the property containing the deferred element(s), the notification is raised.</span></span>

## <a name="unloading-elements"></a><span data-ttu-id="ebbc1-131">要素のアンロード</span><span class="sxs-lookup"><span data-stu-id="ebbc1-131">Unloading elements</span></span>

<span data-ttu-id="ebbc1-132">要素をアンロードするには:</span><span class="sxs-lookup"><span data-stu-id="ebbc1-132">To unload an element:</span></span>

- <span data-ttu-id="ebbc1-133">x:Bind 式を使用して読み込み状態を指定します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-133">Use an x:Bind expression to specify the load state.</span></span> <span data-ttu-id="ebbc1-134">この式は、要素を読み込む場合は **true**、アンロードする場合は **false** を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-134">The expression should return **true** to load and **false** to unload the element.</span></span>
- <span data-ttu-id="ebbc1-135">Page または UserControl で **UnloadObject** を呼び出し、オブジェクト参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-135">In a Page or UserControl, call **UnloadObject** and pass in the object reference</span></span>
- <span data-ttu-id="ebbc1-136">**Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject** オブジェクト参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-136">Call **Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject** and pass in the object reference</span></span>

<span data-ttu-id="ebbc1-137">オブジェクトが読み込まれると、ツリー内でプレース ホルダーに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-137">When an object is unloaded, it will be replaced in the tree with a placeholder.</span></span> <span data-ttu-id="ebbc1-138">オブジェクトのインスタンスは、すべての参照が解放されるまでメモリ内に残ります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-138">The object instance will remain in memory until all references have been released.</span></span> <span data-ttu-id="ebbc1-139">Page/UserControl に対する UnloadObject API は、codegen で確保されている参照が x:Name および x:Bind 用に解放されるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-139">The UnloadObject API on a Page/UserControl is designed to release the references held by codegen for x:Name and x:Bind.</span></span> <span data-ttu-id="ebbc1-140">アプリ コードで追加の参照を確保している場合は、これらも解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-140">If you hold additional references in app code they will also need to be released.</span></span>

<span data-ttu-id="ebbc1-141">要素が読み込まれると、要素関連の状態がすべて破棄されるため、x:Load を Visibility の最適化バージョンとして使用する場合は、すべての状態をバインド経由で適用するか、コードによって Loaded イベントの発生時に再適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-141">When an element is unloaded, all state associated with the element will be discarded, so if using x:Load as an optimized version of Visibility, then ensure all state is applied via bindings, or is re-applied by code when the Loaded event is fired.</span></span>

## <a name="restrictions"></a><span data-ttu-id="ebbc1-142">制限</span><span class="sxs-lookup"><span data-stu-id="ebbc1-142">Restrictions</span></span>

<span data-ttu-id="ebbc1-143">**x:Load** を使う際の制限事項は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-143">The restrictions for using **x:Load** are:</span></span>

- <span data-ttu-id="ebbc1-144">定義する必要があります、 [X:name](x-name-attribute.md) 要素にそこにある必要がありますを後で、要素を見つけることです。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-144">You must define an [x:Name](x-name-attribute.md) for the element, as there needs to be a way to find the element later.</span></span>
- <span data-ttu-id="ebbc1-145">x:Load は、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) または [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249) から派生した型に対してのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-145">You can only use x:Load on types that derive from [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) or [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249).</span></span>
- <span data-ttu-id="ebbc1-146">[  **Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) のルート要素に x:Load を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-146">You cannot use x:Load on root elements in a [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page), a [**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol), or a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348).</span></span>
- <span data-ttu-id="ebbc1-147">[  **ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内の要素に x:Load を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-147">You cannot use x:Load on elements in a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span>
- <span data-ttu-id="ebbc1-148">[  **XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) で読み込まれた Loose XAML に x:Load を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-148">You cannot use x:Load on loose XAML loaded with [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048).</span></span>
- <span data-ttu-id="ebbc1-149">親要素を移動すると、読み込まれていない要素はすべて消去されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-149">Moving a parent element will clear out any elements that have not been loaded.</span></span>

## <a name="remarks"></a><span data-ttu-id="ebbc1-150">注釈</span><span class="sxs-lookup"><span data-stu-id="ebbc1-150">Remarks</span></span>

<span data-ttu-id="ebbc1-151">入れ子になった要素に x:Load を使用することはできますが、最も外側の要素から実体化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-151">You can use x:Load on nested elements, however they have to be realized from the outer-most element in.</span></span> <span data-ttu-id="ebbc1-152"> 親が実体化される前に子要素を実体化しようとすると、例外が生成されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-152"> If you try to realize a child element before the parent has been realized, an exception is raised.</span></span>

<span data-ttu-id="ebbc1-153">通常は、最初のフレームに表示できないものを遅延させることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-153">Typically, we recommend that you defer elements that are not viewable in the first frame.</span></span><span data-ttu-id="ebbc1-154"> 遅延対象の候補を見つけるための指針の 1 つは、[*\*Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-154"> A good guideline for finding candidates to be deferred is to look for elements that are being created with collapsed [*\*Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992).</span></span> <span data-ttu-id="ebbc1-155">また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-155">Also, UI that is triggered by user interaction is a good place to look for elements that you can defer.</span></span>

<span data-ttu-id="ebbc1-156">[  **ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-156">Be wary of deferring elements in a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878), as it will decrease your startup time, but could also decrease your panning performance depending on what you're creating.</span></span> <span data-ttu-id="ebbc1-157">パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-157">If you are looking to increase panning performance, see the [{x:Bind} markup extension](x-bind-markup-extension.md) and [x:Phase attribute](x-phase-attribute.md) documentation.</span></span>

<span data-ttu-id="ebbc1-158">**x:Load** と同時に [x:Phase 属性](x-phase-attribute.md)を使った場合、要素または要素ツリーが実体化されると、バインディングが現在のフェーズまで (現在のフェーズを含めて) 適用されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-158">If the [x:Phase attribute](x-phase-attribute.md) is used in conjunction with **x:Load** then, when an element or an element tree is realized, the bindings are applied up to and including the current phase.</span></span> <span data-ttu-id="ebbc1-159">**x:Phase** に指定されたフェーズが、要素の読み込み状態に影響を与えたり、制御したりすることはありません。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-159">The phase specified for **x:Phase** does affect or control the loading state of the element.</span></span> <span data-ttu-id="ebbc1-160">パンの一部としてリスト項目がリサイクルされると、実現した要素は、アクティブな他の要素と同じように機能し、コンパイル済みバインド (**{x:Bind}** バインディング) は同じルール (フェージングを含む) を使って処理されます。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-160">When a list item is recycled as part of panning, realized elements will behave in the same way as other active elements, and compiled bindings (**{x:Bind}** bindings) are processed using the same rules, including phasing.</span></span>

<span data-ttu-id="ebbc1-161">一般的なガイドラインでは、必要なパフォーマンスが得られていることを確認するために、作業の前と後にアプリのパフォーマンスを測定します。</span><span class="sxs-lookup"><span data-stu-id="ebbc1-161">A general guideline is to measure the performance of your app before and after to make sure you are getting the performance that you want.</span></span>

## <a name="example"></a><span data-ttu-id="ebbc1-162">例</span><span class="sxs-lookup"><span data-stu-id="ebbc1-162">Example</span></span>

```xml
<StackPanel>
    <Grid x:Name="DeferredGrid" x:Load="False">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>

        <Rectangle Height="100" Width="100" Fill="Orange" Margin="0,0,4,4"/>
        <Rectangle Height="100" Width="100" Fill="Green" Grid.Column="1" Margin="4,0,0,4"/>
        <Rectangle Height="100" Width="100" Fill="Blue" Grid.Row="1" Margin="0,4,4,0"/>
        <Rectangle Height="100" Width="100" Fill="Gold" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0"
                   x:Name="one" x:Load="{x:Bind (x:Boolean)CheckBox1.IsChecked, Mode=OneWay}"/>
        <Rectangle Height="100" Width="100" Fill="Silver" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0"
                   x:Name="two" x:Load="{x:Bind Not(CheckBox1.IsChecked), Mode=OneWay}"/>
    </Grid>

    <Button Content="Load elements" Click="LoadElements_Click"/>
    <Button Content="Unload elements" Click="UnloadElements_Click"/>
    <CheckBox x:Name="CheckBox1" Content="Swap Elements" />
</StackPanel>
```

```csharp
// This is used by the bindings between the rectangles and check box.
private bool Not(bool? value) { return !(value==true); }

private void LoadElements_Click(object sender, RoutedEventArgs e)
{
    // This will load the deferred grid, but not the nested
    // rectangles that have x:Load attributes.
    this.FindName("DeferredGrid"); 
}

private void UnloadElements_Click(object sender, RoutedEventArgs e)
{
     // This will unload the grid and all its child elements.
     this.UnloadObject(DeferredGrid);
}
```

