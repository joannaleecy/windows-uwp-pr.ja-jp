---
author: jwmsft
description: ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。
title: RelativeSource マークアップ拡張
ms.assetid: B87DEF36-BE1F-4C16-B32E-7A896BD09272
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5bb9d241569afdbbc9df95fa11cd2261e78c077a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5562728"
---
# <a name="relativesource-markup-extension"></a><span data-ttu-id="142e5-104">{RelativeSource} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="142e5-104">{RelativeSource} markup extension</span></span>


<span data-ttu-id="142e5-105">ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="142e5-105">Provides a means to specify the source of a binding in terms of a relative relationship in the run-time object graph.</span></span>

## <a name="xaml-attribute-usage-self-mode"></a><span data-ttu-id="142e5-106">XAML 属性の使用方法 (Self モード)</span><span class="sxs-lookup"><span data-stu-id="142e5-106">XAML attribute usage (Self mode)</span></span>

``` syntax
<Binding RelativeSource="{RelativeSource Self}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource Self} ...}" .../>
```

## <a name="xaml-attribute-usage-templatedparent-mode"></a><span data-ttu-id="142e5-107">XAML 属性の使用方法 (TemplatedParent モード)</span><span class="sxs-lookup"><span data-stu-id="142e5-107">XAML attribute usage (TemplatedParent mode)</span></span>

``` syntax
<Binding RelativeSource="{RelativeSource TemplatedParent}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource TemplatedParent} ...}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="142e5-108">XAML 値</span><span class="sxs-lookup"><span data-stu-id="142e5-108">XAML values</span></span>

| <span data-ttu-id="142e5-109">用語</span><span class="sxs-lookup"><span data-stu-id="142e5-109">Term</span></span> | <span data-ttu-id="142e5-110">説明</span><span class="sxs-lookup"><span data-stu-id="142e5-110">Description</span></span> |
|------|-------------|
| <span data-ttu-id="142e5-111">{RelativeSource Self}</span><span class="sxs-lookup"><span data-stu-id="142e5-111">{RelativeSource Self}</span></span> | <span data-ttu-id="142e5-112"><strong>Self</strong> の [<strong>Mode</strong>](https://msdn.microsoft.com/library/windows/apps/br209915) 値を生成します。</span><span class="sxs-lookup"><span data-stu-id="142e5-112">Produces a [<strong>Mode</strong>](https://msdn.microsoft.com/library/windows/apps/br209915) value of <strong>Self</strong>.</span></span> <span data-ttu-id="142e5-113">ターゲット要素をこのバインドのソースとして使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="142e5-113">The target element should be used as the source for this binding.</span></span> <span data-ttu-id="142e5-114">要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="142e5-114">This is useful for binding one property of an element to another property on the same element.</span></span> |
| <span data-ttu-id="142e5-115">{RelativeSource TemplatedParent}</span><span class="sxs-lookup"><span data-stu-id="142e5-115">{RelativeSource TemplatedParent}</span></span> | <span data-ttu-id="142e5-116">このバインドのソースとして適用される [<strong>ControlTemplate</strong>](https://msdn.microsoft.com/library/windows/apps/br209391) を生成します。</span><span class="sxs-lookup"><span data-stu-id="142e5-116">Produces a [<strong>ControlTemplate</strong>](https://msdn.microsoft.com/library/windows/apps/br209391) that is applied as the source for this binding.</span></span> <span data-ttu-id="142e5-117">ランタイム情報をテンプレート レベルでバインドに適用する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="142e5-117">This is useful for applying runtime information to bindings at the template level.</span></span> | 

## <a name="remarks"></a><span data-ttu-id="142e5-118">注釈</span><span class="sxs-lookup"><span data-stu-id="142e5-118">Remarks</span></span>

<span data-ttu-id="142e5-119">[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) では、**Binding** オブジェクト要素の属性または [{Binding} マークアップ拡張](binding-markup-extension.md)内のコンポーネントとして [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) を設定できます。</span><span class="sxs-lookup"><span data-stu-id="142e5-119">A [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) can set [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) either as an attribute on a **Binding** object element or as a component within a [{Binding} markup extension](binding-markup-extension.md).</span></span> <span data-ttu-id="142e5-120">これが、2 つの異なる XAML 構文が示されている理由です。</span><span class="sxs-lookup"><span data-stu-id="142e5-120">This is why two different XAML syntaxes are shown.</span></span>

<span data-ttu-id="142e5-121">**RelativeSource** は [{Binding} マークアップ拡張](binding-markup-extension.md)に似ています。</span><span class="sxs-lookup"><span data-stu-id="142e5-121">**RelativeSource** is similar to [{Binding} markup extension](binding-markup-extension.md).</span></span>  <span data-ttu-id="142e5-122">具体的には、自分自身のインスタンスを返すことができ、基本的に引数をコンストラクターに渡す文字列ベースの構築をサポートできるマークアップ拡張機能であるという点です。</span><span class="sxs-lookup"><span data-stu-id="142e5-122">It is a markup extension that is capable of returning instances of itself, and supporting a string-based construction that essentially passes an argument to the constructor.</span></span> <span data-ttu-id="142e5-123">この場合、渡される引数は [**Mode**](https://msdn.microsoft.com/library/windows/apps/br209915) 値になります。</span><span class="sxs-lookup"><span data-stu-id="142e5-123">In this case, the argument being passed is the [**Mode**](https://msdn.microsoft.com/library/windows/apps/br209915) value.</span></span>

<span data-ttu-id="142e5-124">**Self** モードは、要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。これは、要素の名前の指定の後に自己参照を必要としない、[**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) バインドの 1 つのバリエーションです。</span><span class="sxs-lookup"><span data-stu-id="142e5-124">The **Self** mode is useful for binding one property of an element to another property on the same element, and is a variation on [**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) binding but does not require naming and then self-referencing the element.</span></span> <span data-ttu-id="142e5-125">要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合、プロパティで同じプロパティの型を使うか、またはバインドに対して [**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) を使って値を変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="142e5-125">If you bind one property of an element to another property on the same element, either the properties must use the same property type, or you must also use a [**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) on the binding to convert the values.</span></span> <span data-ttu-id="142e5-126">たとえば、[**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) は変換せずに [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) のソースとして使用できますが、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br209419) のソースとして [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209006) を使う場合には、コンバーターが必要です。</span><span class="sxs-lookup"><span data-stu-id="142e5-126">For example, you could use [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) as a source for [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) without conversion, but you'd need a converter to use [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209419) as a source for [**Visibility**](https://msdn.microsoft.com/library/windows/apps/br209006).</span></span>

<span data-ttu-id="142e5-127">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="142e5-127">Here's an example.</span></span> <span data-ttu-id="142e5-128">この [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) と [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) が常に等しく、正方形として表示されるように [{Binding} マークアップ拡張](binding-markup-extension.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="142e5-128">This [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) uses a [{Binding} markup extension](binding-markup-extension.md) so that its [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) and [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) are always equal and it renders as a square.</span></span> <span data-ttu-id="142e5-129">Height のみが固定値として設定されます。</span><span class="sxs-lookup"><span data-stu-id="142e5-129">Only the Height is set as a fixed value.</span></span> <span data-ttu-id="142e5-130">この **Rectangle** の既定の[**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) は**これ**ではなく **null** です。</span><span class="sxs-lookup"><span data-stu-id="142e5-130">For this **Rectangle** its default [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) is **null**, not **this**.</span></span> <span data-ttu-id="142e5-131">そこで、データ コンテキストのソースをオブジェクト自体にするために (そして他のプロパティにバインドできるようにするために)、{Binding} マークアップ拡張の使用時に `RelativeSource={RelativeSource Self}` 引数を使います。</span><span class="sxs-lookup"><span data-stu-id="142e5-131">So to establish the data context source to be the object itself (and enable binding to its other properties) we use the `RelativeSource={RelativeSource Self}` argument in the {Binding} markup extension usage.</span></span>

```XML
<Rectangle
  Fill="Orange" Width="200"
  Height="{Binding RelativeSource={RelativeSource Self}, Path=Width}"
/>
```

<span data-ttu-id="142e5-132">オブジェクトの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) を自分自身に設定する方法として `RelativeSource={RelativeSource Self}` を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="142e5-132">Another use of `RelativeSource={RelativeSource Self}` is as a way to set an object's [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) to itself.</span></span>  <span data-ttu-id="142e5-133">たとえば、独自のデータ バインドのために準備の完了したビュー モデルを既に提供しているカスタム プロパティによって [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスが拡張されている SDK のサンプルで、この技法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="142e5-133">For example, you may see this technique in some of the SDK examples where the [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class has been extended with a custom property that's already providing a ready-to-go view model for its own data binding such as:</span></span> `<common:LayoutAwarePage ... DataContext="{Binding DefaultViewModel, RelativeSource={RelativeSource Self}}">`

<span data-ttu-id="142e5-134">**注:** **RelativeSource**の XAML の使用量が意図されている使用法のみを示しています。 バインド式の一部として XAML で[**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831)の値を設定します。</span><span class="sxs-lookup"><span data-stu-id="142e5-134">**Note**The XAML usage for **RelativeSource** shows only the usage for which it is intended: setting a value for [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) in XAML as part of a binding expression.</span></span> <span data-ttu-id="142e5-135">ただし、値が [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913) のプロパティを設定する場合は、理論的にそれ以外の使用法も可能です。</span><span class="sxs-lookup"><span data-stu-id="142e5-135">Theoretically, other usages are possible if setting a property where the value is [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913).</span></span>

## <a name="related-topics"></a><span data-ttu-id="142e5-136">関連トピック</span><span class="sxs-lookup"><span data-stu-id="142e5-136">Related topics</span></span>

* [<span data-ttu-id="142e5-137">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="142e5-137">XAML overview</span></span>](xaml-overview.md)
* [<span data-ttu-id="142e5-138">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="142e5-138">Data binding in depth</span></span>](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [<span data-ttu-id="142e5-139">{Binding} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="142e5-139">{Binding} markup extension</span></span>](binding-markup-extension.md)
* [**<span data-ttu-id="142e5-140">バインディング</span><span class="sxs-lookup"><span data-stu-id="142e5-140">Binding</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209820)
* [**<span data-ttu-id="142e5-141">RelativeSource</span><span class="sxs-lookup"><span data-stu-id="142e5-141">RelativeSource</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209913)

