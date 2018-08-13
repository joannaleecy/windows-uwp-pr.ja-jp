---
author: jwmsft
title: xLoad 属性
description: 要素とその子、スタートアップ時間とメモリ使用量を減らすの動的な作成と破棄 xLoad を有効にします。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8f34ea43b981de65c81e9cce2b8a896c3577e595
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "610785"
---
# <a name="xload-attribute"></a><span data-ttu-id="bc968-104">x:Load 属性</span><span class="sxs-lookup"><span data-stu-id="bc968-104">x:Load attribute</span></span>

<span data-ttu-id="bc968-105">**X: 読み込み**スタートアップ、視覚的なツリーを作成、および XAML アプリのメモリ使用量を最適化するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="bc968-105">You can use **x:Load** to optimize the startup, visual tree creation, and memory usage of your XAML app.</span></span> <span data-ttu-id="bc968-106">**X: 負荷**を使用すると、ことを除き、要素が読み込まれず、メモリを解放され、ビジュアル ツリー内の場所をマークする小さいプレース ホルダーを使用する内部で、**表示**するような視覚効果があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-106">Using **x:Load** has a similar visual effect to **Visibility**, except that when the element is not loaded, its memory is released and internally a small placeholder is used to mark its place in the visual tree.</span></span>

<span data-ttu-id="bc968-107">X: 負荷の属性の UI 要素は読み込まれ、経由でアンロード コード、または[x: バインド](x-bind-markup-extension.md)式を使用できます。</span><span class="sxs-lookup"><span data-stu-id="bc968-107">The UI element attributed with x:Load can be loaded and unloaded via code, or using an [x:Bind](x-bind-markup-extension.md) expression.</span></span> <span data-ttu-id="bc968-108">これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="bc968-108">This is useful to reduce the costs of elements that are shown infrequently or conditionally.</span></span> <span data-ttu-id="bc968-109">グリッドまたは StackPanel などのコンテナーの x: 負荷を使用すると、コンテナーとそのすべての子が読み込まれているか、グループとしてアンロードします。</span><span class="sxs-lookup"><span data-stu-id="bc968-109">When you use x:Load on a container such as Grid or StackPanel, the container and all of its children are loaded or unloaded as a group.</span></span>

<span data-ttu-id="bc968-110">XAML フレームワークが遅延の要素の追跡、x: 負荷で属性がプレース ホルダーを考慮する各要素のメモリ使用量を約 600 バイトを追加します。</span><span class="sxs-lookup"><span data-stu-id="bc968-110">The tracking of deferred elements by the XAML framework adds about 600 bytes to the memory usage for each element attributed with x:Load, to account for the placeholder.</span></span> <span data-ttu-id="bc968-111">したがって、この属性に、パフォーマンスが低下することができます。</span><span class="sxs-lookup"><span data-stu-id="bc968-111">Therefore, it's possible to overuse this attribute to the extent that your performance actually decreases.</span></span> <span data-ttu-id="bc968-112">のみを使用することで要素を非表示にする必要があることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bc968-112">We recommend that you only use it on elements that need to be hidden.</span></span> <span data-ttu-id="bc968-113">コンテナーの x: 負荷を使用している場合は、x: 読み込み属性と要素に対してのみ、頭上が支払額</span><span class="sxs-lookup"><span data-stu-id="bc968-113">If you use x:Load on a container, then the overhead is paid only for the element with the x:Load attribute.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="bc968-114">X: 読み込み属性は、Windows 10、バージョン 1703 (作成者の更新プログラム) で始まる使用できます。</span><span class="sxs-lookup"><span data-stu-id="bc968-114">The x:Load attribute is available starting in Windows 10, version 1703 (Creators Update).</span></span> <span data-ttu-id="bc968-115">x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-115">The min version targeted by your Visual Studio project must be *Windows 10 Creators Update (10.0, Build 15063)* in order to use x:Load.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="bc968-116">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="bc968-116">XAML attribute usage</span></span>

``` syntax
<object x:Load="True" .../>
<object x:Load="False" .../>
<object x:Load="{x:Bind Path.to.a.boolean, Mode=OneWay}" .../>
```

## <a name="loading-elements"></a><span data-ttu-id="bc968-117">要素の読み込み</span><span class="sxs-lookup"><span data-stu-id="bc968-117">Loading Elements</span></span>

<span data-ttu-id="bc968-118">要素を読み込むにはいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-118">There are several different ways to load the elements:</span></span>

- <span data-ttu-id="bc968-119">[X: バインド](x-bind-markup-extension.md)式を使用して、負荷の状態を指定します。</span><span class="sxs-lookup"><span data-stu-id="bc968-119">Use an [x:Bind](x-bind-markup-extension.md) expression to specify the load state.</span></span> <span data-ttu-id="bc968-120">**True**を読み込むと**false**の要素を読み込み解除する式を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-120">The expression should return **true** to load and **false** to unload the element.</span></span>
- <span data-ttu-id="bc968-121">要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bc968-121">Call [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) with the name that you defined on the element.</span></span>
- <span data-ttu-id="bc968-122">要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bc968-122">Call [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) with the name that you defined on the element.</span></span>
- <span data-ttu-id="bc968-123">[**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007)では、[x: 読み込み要素を対象とする[**設定**](https://msdn.microsoft.com/library/windows/apps/br208817)または**ストーリー ボード**アニメーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="bc968-123">In a [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007), use a [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) or **Storyboard** animation that targets the x:Load element.</span></span>
- <span data-ttu-id="bc968-124">ターゲット内の任意の**ストーリー ボード**アンロード要素。</span><span class="sxs-lookup"><span data-stu-id="bc968-124">Target the unloaded element in any **Storyboard**.</span></span>

> <span data-ttu-id="bc968-125">注: 要素のインスタンス化が開始されると、インスタンスは UI スレッド上で作成されます。そのため、一度に作成されるインスタンスが多すぎると、UI で引っかかりが起きることがあります。</span><span class="sxs-lookup"><span data-stu-id="bc968-125">NOTE: Once the instantiation of an element has started, it is created on the UI thread, so it could cause the UI to stutter if too much is created at once.</span></span>

<span data-ttu-id="bc968-126">上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="bc968-126">Once a deferred element is created in any of the ways listed previously, several things happen:</span></span>

- <span data-ttu-id="bc968-127">要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-127">The [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) event on the element is raised.</span></span>
- <span data-ttu-id="bc968-128">[名前] フィールドが設定されています。</span><span class="sxs-lookup"><span data-stu-id="bc968-128">The field for x:Name is set.</span></span>
- <span data-ttu-id="bc968-129">要素の任意の x: バインド バインドに評価されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-129">Any x:Bind bindings on the element are evaluated.</span></span>
- <span data-ttu-id="bc968-130">遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-130">If you have registered to receive property change notifications on the property containing the deferred element(s), the notification is raised.</span></span>

## <a name="unloading-elements"></a><span data-ttu-id="bc968-131">アンロード要素</span><span class="sxs-lookup"><span data-stu-id="bc968-131">Unloading elements</span></span>

<span data-ttu-id="bc968-132">要素を読み込み解除します。</span><span class="sxs-lookup"><span data-stu-id="bc968-132">To unload an element:</span></span>

- <span data-ttu-id="bc968-133">X: バインド式を使用して、負荷の状態を指定します。</span><span class="sxs-lookup"><span data-stu-id="bc968-133">Use an x:Bind expression to specify the load state.</span></span> <span data-ttu-id="bc968-134">**True**を読み込むと**false**の要素を読み込み解除する式を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-134">The expression should return **true** to load and **false** to unload the element.</span></span>
- <span data-ttu-id="bc968-135">ページまたはコントロールの場合は、電話**UnloadObject**をオブジェクト参照で渡す</span><span class="sxs-lookup"><span data-stu-id="bc968-135">In a Page or UserControl, call **UnloadObject** and pass in the object reference</span></span>
- <span data-ttu-id="bc968-136">着信の**Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject**とオブジェクト参照で渡す</span><span class="sxs-lookup"><span data-stu-id="bc968-136">Call **Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject** and pass in the object reference</span></span>

<span data-ttu-id="bc968-137">オブジェクトが読み込まれている場合は、それが置き換えられますツリーのプレース ホルダーします。</span><span class="sxs-lookup"><span data-stu-id="bc968-137">When an object is unloaded, it will be replaced in the tree with a placeholder.</span></span> <span data-ttu-id="bc968-138">すべての参照がリリースされるまでメモリ内でオブジェクトのインスタンスが残ります。</span><span class="sxs-lookup"><span data-stu-id="bc968-138">The object instance will remain in memory until all references have been released.</span></span> <span data-ttu-id="bc968-139">ページ/コントロールの UnloadObject API は、名前、x: バインド codegen によって保持されている参照を解放する設計されています。</span><span class="sxs-lookup"><span data-stu-id="bc968-139">The UnloadObject API on a Page/UserControl is designed to release the references held by codegen for x:Name and x:Bind.</span></span> <span data-ttu-id="bc968-140">アプリ コードでその他の参照を保持するも場合はリリースされる予定です。</span><span class="sxs-lookup"><span data-stu-id="bc968-140">If you hold additional references in app code they will also need to be released.</span></span>

<span data-ttu-id="bc968-141">要素が読み込まれている場合は、要素に関連付けられたすべての状態は破棄され、ように最適化されたバージョンの表示設定として x: 負荷を使用する場合、[バインド経由で適用されるすべての状態を確認または読み込まれたイベントが発生したときにコードを再適用します。</span><span class="sxs-lookup"><span data-stu-id="bc968-141">When an element is unloaded, all state associated with the element will be discarded, so if using x:Load as an optimized version of Visibility, then ensure all state is applied via bindings, or is re-applied by code when the Loaded event is fired.</span></span>

## <a name="restrictions"></a><span data-ttu-id="bc968-142">制限</span><span class="sxs-lookup"><span data-stu-id="bc968-142">Restrictions</span></span>

<span data-ttu-id="bc968-143">**X: 負荷**を使う場合の制限事項は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bc968-143">The restrictions for using **x:Load** are:</span></span>

- <span data-ttu-id="bc968-144">要素を後で検索する手段として、要素の [x:Name](x-name-attribute.md) を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc968-144">You must define an [x:Name](x-name-attribute.md) for the element, as there needs to be a way to find the element later.</span></span>
- <span data-ttu-id="bc968-145">X: 読み込みは[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911)または[**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249)から派生する型でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="bc968-145">You can only use x:Load on types that derive from [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) or [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249).</span></span>
- <span data-ttu-id="bc968-146">[**ページ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**コントロール**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または[**データ テンプレート**](https://msdn.microsoft.com/library/windows/apps/br242348)のルート要素に x: 負荷を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bc968-146">You cannot use x:Load on root elements in a [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page), a [**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol), or a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348).</span></span>
- <span data-ttu-id="bc968-147">の[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794)の要素の x: 負荷を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bc968-147">You cannot use x:Load on elements in a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span>
- <span data-ttu-id="bc968-148">[**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048)で読み込ましっかり XAML に x: 負荷を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bc968-148">You cannot use x:Load on loose XAML loaded with [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048).</span></span>
- <span data-ttu-id="bc968-149">親要素の移動が読み込まれているすべての要素が消去されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-149">Moving a parent element will clear out any elements that have not been loaded.</span></span>

## <a name="remarks"></a><span data-ttu-id="bc968-150">注釈</span><span class="sxs-lookup"><span data-stu-id="bc968-150">Remarks</span></span>

<span data-ttu-id="bc968-151">持っての最も外側の要素を実現するのには、入れ子になった要素は、[x: 負荷を使用できます。</span><span class="sxs-lookup"><span data-stu-id="bc968-151">You can use x:Load on nested elements, however they have to be realized from the outer-most element in.</span></span>  <span data-ttu-id="bc968-152">親が実体化される前に子要素を実体化しようとすると、例外が生成されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-152">If you try to realize a child element before the parent has been realized, an exception is raised.</span></span>

<span data-ttu-id="bc968-153">通常は、最初のフレームに表示できないものを遅延させることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bc968-153">Typically, we recommend that you defer elements that are not viewable in the first frame.</span></span> <span data-ttu-id="bc968-154">遅延対象の候補を見つけるための指針の 1 つは、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。</span><span class="sxs-lookup"><span data-stu-id="bc968-154">A good guideline for finding candidates to be deferred is to look for elements that are being created with collapsed [**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992).</span></span> <span data-ttu-id="bc968-155">また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。</span><span class="sxs-lookup"><span data-stu-id="bc968-155">Also, UI that is triggered by user interaction is a good place to look for elements that you can defer.</span></span>

<span data-ttu-id="bc968-156">[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。</span><span class="sxs-lookup"><span data-stu-id="bc968-156">Be wary of deferring elements in a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878), as it will decrease your startup time, but could also decrease your panning performance depending on what you're creating.</span></span> <span data-ttu-id="bc968-157">パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bc968-157">If you are looking to increase panning performance, see the [{x:Bind} markup extension](x-bind-markup-extension.md) and [x:Phase attribute](x-phase-attribute.md) documentation.</span></span>

<span data-ttu-id="bc968-158">[X: フェーズ属性](x-phase-attribute.md)と組み合わせて使用**x: 読み込み**要素または要素のツリーを基準にしている場合、現在のフェーズを含むバインドが適用されます。</span><span class="sxs-lookup"><span data-stu-id="bc968-158">If the [x:Phase attribute](x-phase-attribute.md) is used in conjunction with **x:Load** then, when an element or an element tree is realized, the bindings are applied up to and including the current phase.</span></span> <span data-ttu-id="bc968-159">**X: フェーズ**の指定されたフェーズに影響はまたは要素の読み込み中の状態を制御します。</span><span class="sxs-lookup"><span data-stu-id="bc968-159">The phase specified for **x:Phase** does affect or control the loading state of the element.</span></span> <span data-ttu-id="bc968-160">リスト アイテムがパンの一部としてごみ箱に入れ、要素の他のアクティブな要素に同じように動作し、フェードアウトなど、同じ規則を使用してコンパイル済みバインド (**{x: バインド}** ) の処理を実現します。</span><span class="sxs-lookup"><span data-stu-id="bc968-160">When a list item is recycled as part of panning, realized elements will behave in the same way as other active elements, and compiled bindings (**{x:Bind}** bindings) are processed using the same rules, including phasing.</span></span>

<span data-ttu-id="bc968-161">一般的なガイドラインでは、必要なパフォーマンスが得られていることを確認するために、作業の前と後にアプリのパフォーマンスを測定します。</span><span class="sxs-lookup"><span data-stu-id="bc968-161">A general guideline is to measure the performance of your app before and after to make sure you are getting the performance that you want.</span></span>

## <a name="example"></a><span data-ttu-id="bc968-162">例</span><span class="sxs-lookup"><span data-stu-id="bc968-162">Example</span></span>

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

