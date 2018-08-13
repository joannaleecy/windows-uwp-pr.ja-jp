---
author: jwmsft
description: コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。 XAML では、TemplateBinding は ControlTemplate 定義内でのみ使用できます。
title: TemplateBinding マークアップ拡張
ms.assetid: FDE71086-9D42-4287-89ED-8FBFCDF169DC
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ca551ff53a0a91b5bc60263b6e282b95c32bf976
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "246484"
---
# <a name="templatebinding-markup-extension"></a><span data-ttu-id="af6ea-105">{TemplateBinding} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="af6ea-105">{TemplateBinding} markup extension</span></span>

<span data-ttu-id="af6ea-106">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="af6ea-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="af6ea-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="af6ea-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="af6ea-108">コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。</span><span class="sxs-lookup"><span data-stu-id="af6ea-108">Links the value of a property in a control template to the value of some other exposed property on the templated control.</span></span> <span data-ttu-id="af6ea-109">XAML では、**TemplateBinding** は [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義内でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-109">**TemplateBinding** can only be used within a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="af6ea-110">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="af6ea-110">XAML attribute usage</span></span>

``` syntax
<object propertyName="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-attribute-usage-for-setter-property-in-template-or-style"></a><span data-ttu-id="af6ea-111">XAML 属性の使用方法 (テンプレートまたはスタイルの Setter プロパティの場合)</span><span class="sxs-lookup"><span data-stu-id="af6ea-111">XAML attribute usage (for Setter property in template or style)</span></span>

``` syntax
<Setter Property="propertyName" Value="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="af6ea-112">XAML 値</span><span class="sxs-lookup"><span data-stu-id="af6ea-112">XAML values</span></span>

| <span data-ttu-id="af6ea-113">用語</span><span class="sxs-lookup"><span data-stu-id="af6ea-113">Term</span></span> | <span data-ttu-id="af6ea-114">説明</span><span class="sxs-lookup"><span data-stu-id="af6ea-114">Description</span></span> |
|------|-------------|
| <span data-ttu-id="af6ea-115">propertyName</span><span class="sxs-lookup"><span data-stu-id="af6ea-115">propertyName</span></span> | <span data-ttu-id="af6ea-116">setter 構文で設定されるプロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="af6ea-116">The name of the property being set in the setter syntax.</span></span> <span data-ttu-id="af6ea-117">これは依存関係プロパティであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="af6ea-117">This must be a dependency property.</span></span> |
| <span data-ttu-id="af6ea-118">sourceProperty</span><span class="sxs-lookup"><span data-stu-id="af6ea-118">sourceProperty</span></span> | <span data-ttu-id="af6ea-119">template 宣言された型に存在する、別の依存関係プロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="af6ea-119">The name of another dependency property that exists on the type being templated.</span></span> |

## <a name="remarks"></a><span data-ttu-id="af6ea-120">注釈</span><span class="sxs-lookup"><span data-stu-id="af6ea-120">Remarks</span></span>

<span data-ttu-id="af6ea-121">カスタム コントロールの作成者である場合でも、コントロール テンプレートを今あるコントロールに置き換える場合でも、コントロール テンプレートを定義するうえでは **TemplateBinding** を使うことが欠かせません。</span><span class="sxs-lookup"><span data-stu-id="af6ea-121">Using **TemplateBinding** is a fundamental part of how you define a control template, either if you are a custom control author or if you are replacing a control template for existing controls.</span></span> <span data-ttu-id="af6ea-122">詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="af6ea-122">For more info, see [Quickstart: Control templates](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374).</span></span>

<span data-ttu-id="af6ea-123">*propertyName* と *targetProperty* では同じプロパティ名を使うことが一般的です。</span><span class="sxs-lookup"><span data-stu-id="af6ea-123">It's fairly common for *propertyName* and *targetProperty* to use the same property name.</span></span> <span data-ttu-id="af6ea-124">この場合、コントロール自体でプロパティを定義し、プロパティを、そのいずれかのコンポーネントの直感的な名前を持つ既にあるプロパティに転送します。</span><span class="sxs-lookup"><span data-stu-id="af6ea-124">In this case, a control might define a property on itself and forward the property to an existing and intuitively named property of one of its component parts.</span></span> <span data-ttu-id="af6ea-125">たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) をコントロールの合成に組み込んでコントロール自体の **Text** プロパティの表示に使う場合は、コントロール テンプレートの一部として次の XAML を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-125">For example, a control that incorporates a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) in its compositing, which is used to display the control's own **Text** property, might include this XAML as a part in the control template:</span></span> `<TextBlock Text="{TemplateBinding Text}" .... />`

<span data-ttu-id="af6ea-126">ソース プロパティとターゲット プロパティの値として使う型は一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="af6ea-126">The types used as the value for the source property and the target property must match.</span></span> <span data-ttu-id="af6ea-127">**TemplateBinding** を使うとコンバーターを導入する機会がありません。</span><span class="sxs-lookup"><span data-stu-id="af6ea-127">There's no opportunity to introduce a converter when you're using **TemplateBinding**.</span></span> <span data-ttu-id="af6ea-128">値が一致しないと、XAML を解析したときにエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="af6ea-128">Failing to match values results in an error when parsing the XAML.</span></span> <span data-ttu-id="af6ea-129">コンバーターを必要とする場合は、次のようなテンプレート バインドの冗長な形式の構文を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-129">If you need a converter you can use the verbose syntax for a template binding such as:</span></span> `{Binding RelativeSource={RelativeSource TemplatedParent}, Converter="..." ...}`

<span data-ttu-id="af6ea-130">XAML の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義の外側で **TemplateBinding** を使うと、パーサー エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="af6ea-130">Attempting to use a **TemplateBinding** outside of a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML will result in a parser error.</span></span>

<span data-ttu-id="af6ea-131">親のテンプレート値も別のバインドとして延期される場合は、**TemplateBinding** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-131">You can use **TemplateBinding** for cases where the templated parent value is also deferred as another binding.</span></span> <span data-ttu-id="af6ea-132">**TemplateBinding** の評価は、必要な実行時バインドに値が設定されるまで待機することができます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-132">The evaluation for **TemplateBinding** can wait until any required runtime bindings have values.</span></span>

<span data-ttu-id="af6ea-133">**TemplateBinding** は常に一方向バインドです。</span><span class="sxs-lookup"><span data-stu-id="af6ea-133">A **TemplateBinding** is always a one-way binding.</span></span> <span data-ttu-id="af6ea-134">関係するプロパティはどちらも依存関係プロパティである必要があります。</span><span class="sxs-lookup"><span data-stu-id="af6ea-134">Both properties involved must be dependency properties.</span></span>

<span data-ttu-id="af6ea-135">**TemplateBinding** はマークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="af6ea-135">**TemplateBinding** is a markup extension.</span></span> <span data-ttu-id="af6ea-136">通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。</span><span class="sxs-lookup"><span data-stu-id="af6ea-136">Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties.</span></span> <span data-ttu-id="af6ea-137">XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。</span><span class="sxs-lookup"><span data-stu-id="af6ea-137">All markup extensions in XAML use the "{" and "}" characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute.</span></span>

<span data-ttu-id="af6ea-138">**注**  Windows ランタイム XAML プロセッサの実装では、**TemplateBinding** のバッキング クラス表現はありません。</span><span class="sxs-lookup"><span data-stu-id="af6ea-138">**Note**  In the Windows Runtime XAML processor implementation, there is no backing class representation for **TemplateBinding**.</span></span> <span data-ttu-id="af6ea-139">**TemplateBinding** は、XAML マークアップでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="af6ea-139">**TemplateBinding** is exclusively for use in XAML markup.</span></span> <span data-ttu-id="af6ea-140">コードの動作を再現する方法には単純なものがありません。</span><span class="sxs-lookup"><span data-stu-id="af6ea-140">There isn't a straightforward way to reproduce the behavior in code.</span></span>

## <a name="related-topics"></a><span data-ttu-id="af6ea-141">関連トピック</span><span class="sxs-lookup"><span data-stu-id="af6ea-141">Related topics</span></span>

* [<span data-ttu-id="af6ea-142">クイック スタート: コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="af6ea-142">Quickstart: Control templates</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)
* [<span data-ttu-id="af6ea-143">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="af6ea-143">Data binding in depth</span></span>](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [**<span data-ttu-id="af6ea-144">ControlTemplate</span><span class="sxs-lookup"><span data-stu-id="af6ea-144">ControlTemplate</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209391)
* [<span data-ttu-id="af6ea-145">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="af6ea-145">XAML overview</span></span>](xaml-overview.md)
* [<span data-ttu-id="af6ea-146">依存関係プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="af6ea-146">Dependency properties overview</span></span>](dependency-properties-overview.md)
 

