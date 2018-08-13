---
author: jwmsft
description: 定義済みリソースへの参照を評価することで、任意の XAML 属性の値を提供します。 リソースは ResourceDictionary で定義されており、StaticResource の使用では ResourceDictionary 内のそのリソースのキーを参照します。
title: StaticResource マークアップ拡張
ms.assetid: D50349B5-4588-4EBD-9458-75F629CCC395
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 234d90382fb62e6f0be9683dfb7b01d9fa80a185
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "244545"
---
# <a name="staticresource-markup-extension"></a><span data-ttu-id="4d04c-105">{StaticResource} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="4d04c-105">{StaticResource} markup extension</span></span>

<span data-ttu-id="4d04c-106">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="4d04c-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="4d04c-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="4d04c-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="4d04c-108">定義済みリソースへの参照を評価することで、任意の XAML 属性の値を提供します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-108">Provides a value for any XAML attribute by evaluating a reference to an already defined resource.</span></span> <span data-ttu-id="4d04c-109">リソースは [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されており、**StaticResource** の使用では **ResourceDictionary** 内のそのリソースのキーを参照します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-109">Resources are defined in a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794), and a **StaticResource** usage references the key of that resource in the **ResourceDictionary**.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="4d04c-110">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="4d04c-110">XAML attribute usage</span></span>

``` syntax
<object property="{StaticResource key}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="4d04c-111">XAML 値</span><span class="sxs-lookup"><span data-stu-id="4d04c-111">XAML values</span></span>

| <span data-ttu-id="4d04c-112">用語</span><span class="sxs-lookup"><span data-stu-id="4d04c-112">Term</span></span> | <span data-ttu-id="4d04c-113">説明</span><span class="sxs-lookup"><span data-stu-id="4d04c-113">Description</span></span> |
|------|-------------|
| <span data-ttu-id="4d04c-114">key</span><span class="sxs-lookup"><span data-stu-id="4d04c-114">key</span></span> | <span data-ttu-id="4d04c-115">要求されたリソースのキー。</span><span class="sxs-lookup"><span data-stu-id="4d04c-115">The key for the requested resource.</span></span> <span data-ttu-id="4d04c-116">このキーは、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) によって最初に割当てられます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-116">This key is initially assigned by the [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span> <span data-ttu-id="4d04c-117">リソース キーとしては、XamlName の文法で定義されている任意の文字列を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-117">A resource key can be any string defined in the XamlName Grammar.</span></span> |

## <a name="remarks"></a><span data-ttu-id="4d04c-118">注釈</span><span class="sxs-lookup"><span data-stu-id="4d04c-118">Remarks</span></span>

<span data-ttu-id="4d04c-119">**StaticResource** は、XAML リソース ディクショナリ内の別の場所で定義されている XAML 属性の値を取得するための手法です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-119">**StaticResource** is a technique for obtaining values for a XAML attribute that are defined elsewhere in a XAML resource dictionary.</span></span> <span data-ttu-id="4d04c-120">値がリソース ディクショナリに格納される理由としては、複数のプロパティ値で共有されることや、XAML リソース ディクショナリが XAML パッケージングまたはファクタリング手法として使われることが挙げられます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-120">Values might be placed in a resource dictionary because they are intended to be shared by multiple property values, or because a XAML resource dictionary is used as a XAML packaging or factoring technique.</span></span> <span data-ttu-id="4d04c-121">XAML パッケージング手法の例は、コントロールのテーマ ディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="4d04c-121">An example of a XAML packaging technique is the theme dictionary for a control.</span></span> <span data-ttu-id="4d04c-122">もう 1 つの例は、リソースのフォールバックに使われるマージされたリソース ディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="4d04c-122">Another example is merged resource dictionaries used for resource fallback.</span></span>

<span data-ttu-id="4d04c-123">**StaticResource** は、要求されたリソースについてキーを指定する 1 個の引数を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="4d04c-123">**StaticResource** takes one argument, which specifies the key for the requested resource.</span></span> <span data-ttu-id="4d04c-124">リソース キーは常に、Windows ランタイム XAML の文字列です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-124">A resource key is always a string in Windows Runtime XAML.</span></span> <span data-ttu-id="4d04c-125">リソース キーを最初に指定する方法について詳しくは、「[x:Key 属性](x-key-attribute.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d04c-125">For more info on how the resource key is initially specified, see [x:Key attribute](x-key-attribute.md).</span></span>

<span data-ttu-id="4d04c-126">**StaticResource** がリソース ディクショナリの項目に解決される規則は、このトピックでは説明していません。</span><span class="sxs-lookup"><span data-stu-id="4d04c-126">The rules by which a **StaticResource** resolves to an item in a resource dictionary are not described in this topic.</span></span> <span data-ttu-id="4d04c-127">そのような規則は、参照とリソースがいずれもテンプレートに存在するかどうかや、マージされたリソース ディクショナリを使うかどうかなどによって異なります。</span><span class="sxs-lookup"><span data-stu-id="4d04c-127">That depends on whether the reference and the resource both exist in a template, whether merged resource dictionaries are used, and so on.</span></span> <span data-ttu-id="4d04c-128">リソースの定義方法と [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の適切な使用方法 (サンプル コードを含む) について詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d04c-128">For more info on how to define resources and properly use a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794), including sample code, see [ResourceDictionary and XAML resource references](https://msdn.microsoft.com/library/windows/apps/mt187273).</span></span>

**<span data-ttu-id="4d04c-129">重要</span><span class="sxs-lookup"><span data-stu-id="4d04c-129">Important</span></span>**  
<span data-ttu-id="4d04c-130">**StaticResource** は、XAML ファイルの中で辞書的に定義されているリソースへの前方参照を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="4d04c-130">A **StaticResource** must not attempt to make a forward reference to a resource that is defined lexically further within the XAML file.</span></span> <span data-ttu-id="4d04c-131">そのようなことを試みることはサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="4d04c-131">Attempting to do so is not supported.</span></span> <span data-ttu-id="4d04c-132">前方参照が失敗しなかったとしても、そのようなことを試みるだけでパフォーマンスの低下を招きます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-132">Even if the forward reference doesn't fail, trying to make one carries a performance penalty.</span></span> <span data-ttu-id="4d04c-133">最善の結果を得るには、前方参照を避けるようにリソース ディクショナリの構成を調整します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-133">For best results, adjust the composition of your resource dictionaries so that forward references are avoided.</span></span>

<span data-ttu-id="4d04c-134">解決できないキーに **StaticResource** を指定しようとすると、実行時に XAML の解析で例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-134">Attempting to specify a **StaticResource** to a key that cannot resolve throws a XAML parse exception at run time.</span></span> <span data-ttu-id="4d04c-135">デザイン ツールでも、警告やエラーが通知されることがあります。</span><span class="sxs-lookup"><span data-stu-id="4d04c-135">Design tools may also offer warnings or errors.</span></span>

<span data-ttu-id="4d04c-136">Windows ランタイム XAML プロセッサの実装では、**StaticResource** 機能のバッキング クラス表現はありません。</span><span class="sxs-lookup"><span data-stu-id="4d04c-136">In the Windows Runtime XAML processor implementation, there is no backing class representation for **StaticResource** functionality.</span></span> <span data-ttu-id="4d04c-137">**StaticResource** は、XAML マークアップでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-137">**StaticResource** is exclusively for use in XAML.</span></span> <span data-ttu-id="4d04c-138">コードで最も近いのは、[**Contains**](https://msdn.microsoft.com/library/windows/apps/jj635925) または [**TryGetValue**](https://msdn.microsoft.com/library/windows/apps/jj603139) を呼び出すなど、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) のコレクション API を使うことです。</span><span class="sxs-lookup"><span data-stu-id="4d04c-138">The closest equivalent in code is to use the collection API of a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794), for example calling [**Contains**](https://msdn.microsoft.com/library/windows/apps/jj635925) or [**TryGetValue**](https://msdn.microsoft.com/library/windows/apps/jj603139).</span></span>

<span data-ttu-id="4d04c-139">[{ThemeResource} マークアップ拡張](themeresource-markup-extension.md)は、別の場所の名前付きリソースを参照する同様のマークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-139">[{ThemeResource} markup extension](themeresource-markup-extension.md) is a similar markup extension that references named resources in another location.</span></span> <span data-ttu-id="4d04c-140">違いは、{ThemeResource} マークアップ拡張ではアクティブなシステム テーマに応じて異なるリソースを返すことができるという点です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-140">The difference is that {ThemeResource} markup extension has the ability to return different resources depending on the system theme that's active.</span></span> <span data-ttu-id="4d04c-141">詳しくは、「[{ThemeResource} マークアップ拡張](themeresource-markup-extension.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4d04c-141">For more info see [{ThemeResource} markup extension](themeresource-markup-extension.md).</span></span>

<span data-ttu-id="4d04c-142">**StaticResource** は、マークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-142">**StaticResource** is a markup extension.</span></span> <span data-ttu-id="4d04c-143">通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-143">Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties.</span></span> <span data-ttu-id="4d04c-144">XAML のすべてのマークアップ拡張では、それぞれの属性構文で "\{" と "\}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-144">All markup extensions in XAML use the "\{" and "\}" characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute.</span></span>

### <a name="an-example-staticresource-usage"></a><span data-ttu-id="4d04c-145">{StaticResource} の使用例</span><span class="sxs-lookup"><span data-stu-id="4d04c-145">An example {StaticResource} usage</span></span>

<span data-ttu-id="4d04c-146">この XAML 例は、[XAML データ バインディング サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=226854)から抜粋したものです。</span><span class="sxs-lookup"><span data-stu-id="4d04c-146">This example XAML is taken from the [XAML data binding sample](http://go.microsoft.com/fwlink/p/?linkid=226854).</span></span>

```xml
<StackPanel Margin="5">
    <!-- Add converter as a resource to reference it from a Binding. --> 
    <StackPanel.Resources>
        <local:S2Formatter x:Key="GradeConverter"/>
    </StackPanel.Resources>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Percent grade:" Margin="5" />
    <Slider x:Name="sliderValueConverter" Minimum="1" Maximum="100" Value="70" Margin="5"/>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Letter grade:" Margin="5"/>
    <TextBox x:Name="tbValueConverterDataBound"
      Text="{Binding ElementName=sliderValueConverter, Path=Value, Mode=OneWay,  
        Converter={StaticResource GradeConverter}}" Margin="5" Width="150"/> 
</StackPanel> 
```

<span data-ttu-id="4d04c-147">この例では、カスタム クラスによってサポートされるオブジェクトを、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) のリソースとして作成しています。</span><span class="sxs-lookup"><span data-stu-id="4d04c-147">This particular example creates an object that's backed by a custom class, and creates it as a resource in a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span> <span data-ttu-id="4d04c-148">有効なリソースにするには、ほかにも、この `local:S2Formatter` 要素に **x:Key** 属性値が必要です。</span><span class="sxs-lookup"><span data-stu-id="4d04c-148">To be a valid resource, this `local:S2Formatter` element must also have an **x:Key** attribute value.</span></span> <span data-ttu-id="4d04c-149">属性値は "GradeConverter" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-149">The value of the attribute is set to "GradeConverter".</span></span>

<span data-ttu-id="4d04c-150">XAML でもう少し先に進むと、リソースが要求されています。`{StaticResource GradeConverter}` というところです。</span><span class="sxs-lookup"><span data-stu-id="4d04c-150">The resource is then requested just a bit further into the XAML, where you see `{StaticResource GradeConverter}`.</span></span>

<span data-ttu-id="4d04c-151">{StaticResource} マークアップ拡張を使って、別のマークアップ拡張 [{Binding} マークアップ拡張](binding-markup-extension.md)のプロパティを設定していることに注意してください。つまり、ここではマークアップ拡張が 2 つ、入れ子構造で使われています。</span><span class="sxs-lookup"><span data-stu-id="4d04c-151">Note how the {StaticResource} markup extension usage is setting a property of another markup extension [{Binding} markup extension](binding-markup-extension.md), so there's two nested markup extension usages here.</span></span> <span data-ttu-id="4d04c-152">内側のものが最初に評価されます。このため、リソースが取得された後、値として使われます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-152">The inner one is evaluated first, so that the resource is obtained first and can be used as a value.</span></span> <span data-ttu-id="4d04c-153">これと同じ例は、「{Binding} マークアップ拡張」にも記載してあります。</span><span class="sxs-lookup"><span data-stu-id="4d04c-153">This same example is also shown in {Binding} markup extension.</span></span>

## <a name="design-time-tools-support-for-the-staticresource-markup-extension"></a><span data-ttu-id="4d04c-154">設計時ツールの **{StaticResource}** マークアップ拡張のサポート</span><span class="sxs-lookup"><span data-stu-id="4d04c-154">Design-time tools support for the **{StaticResource}** markup extension</span></span>

<span data-ttu-id="4d04c-155">MicrosoftVisualStudio2013 では、XAML ページで **{StaticResource}** マークアップ拡張を使うときに Microsoft IntelliSense のドロップダウンに可能なキー値を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-155">Microsoft Visual Studio 2013 can include possible key values in the Microsoft IntelliSense dropdowns when you use the **{StaticResource}** markup extension in a XAML page.</span></span> <span data-ttu-id="4d04c-156">たとえば、"{StaticResource" と入力するとすぐに、現在の検索範囲のリソース キーが IntelliSense のドロップダウンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-156">For example, as soon as you type "{StaticResource", any of the resource keys from the current lookup scope are displayed in the IntelliSense dropdowns.</span></span> <span data-ttu-id="4d04c-157">ページ レベル ([**FrameworkElement.Resources**](https://msdn.microsoft.com/library/windows/apps/br208740)) とアプリ レベル ([**Application.Resources**](https://msdn.microsoft.com/library/windows/apps/br242338)) で持つ一般的なリソースに加えて、[XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)と、プロジェクトで使っている拡張機能のリソースも表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-157">In addition to the typical resources you'd have at page level ([**FrameworkElement.Resources**](https://msdn.microsoft.com/library/windows/apps/br208740)) and app level ([**Application.Resources**](https://msdn.microsoft.com/library/windows/apps/br242338)), you also see [XAML theme resources](https://msdn.microsoft.com/library/windows/apps/mt187274), and resources from any extensions your project is using.</span></span>

<span data-ttu-id="4d04c-158">**{StaticResource}** の一部としてリソース キーが存在すると、**[定義へ移動]** (F12 キー) 機能でそのリソースを解決して、リソースが定義されているディクショナリを表示できます。</span><span class="sxs-lookup"><span data-stu-id="4d04c-158">Once a resource key exists as part of any **{StaticResource}** usage, the **Go To Definition** (F12) feature can resolve that resource and show you the dictionary where it's defined.</span></span> <span data-ttu-id="4d04c-159">テーマ リソースの場合は、設計時の generic.xaml に移動します。</span><span class="sxs-lookup"><span data-stu-id="4d04c-159">For the theme resources, this goes to generic.xaml for design time.</span></span>

## <a name="related-topics"></a><span data-ttu-id="4d04c-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4d04c-160">Related topics</span></span>

* [<span data-ttu-id="4d04c-161">ResourceDictionary と XAML リソースの参照</span><span class="sxs-lookup"><span data-stu-id="4d04c-161">ResourceDictionary and XAML resource references</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [**<span data-ttu-id="4d04c-162">ResourceDictionary</span><span class="sxs-lookup"><span data-stu-id="4d04c-162">ResourceDictionary</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208794)
* [<span data-ttu-id="4d04c-163">x:Key 属性</span><span class="sxs-lookup"><span data-stu-id="4d04c-163">x:Key attribute</span></span>](x-key-attribute.md)
* [<span data-ttu-id="4d04c-164">{ThemeResource} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="4d04c-164">{ThemeResource} markup extension</span></span>](themeresource-markup-extension.md)

