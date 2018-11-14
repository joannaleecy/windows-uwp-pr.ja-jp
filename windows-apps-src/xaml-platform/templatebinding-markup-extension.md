---
author: jwmsft
description: コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。 XAML では、TemplateBinding は ControlTemplate 定義内でのみ使用できます。
title: TemplateBinding マークアップ拡張
ms.assetid: FDE71086-9D42-4287-89ED-8FBFCDF169DC
ms.author: jimwalk
ms.date: 10/29/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d4aaca880caf30b46cb1ed26d66700bb12d76404
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6254644"
---
# <a name="templatebinding-markup-extension"></a><span data-ttu-id="5a50b-105">{TemplateBinding} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="5a50b-105">{TemplateBinding} markup extension</span></span>

<span data-ttu-id="5a50b-106">コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。</span><span class="sxs-lookup"><span data-stu-id="5a50b-106">Links the value of a property in a control template to the value of some other exposed property on the templated control.</span></span> <span data-ttu-id="5a50b-107">XAML では、**TemplateBinding** は [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義内でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-107">**TemplateBinding** can only be used within a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="5a50b-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="5a50b-108">XAML attribute usage</span></span>

``` syntax
<object propertyName="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-attribute-usage-for-setter-property-in-template-or-style"></a><span data-ttu-id="5a50b-109">XAML 属性の使用方法 (テンプレートまたはスタイルの Setter プロパティの場合)</span><span class="sxs-lookup"><span data-stu-id="5a50b-109">XAML attribute usage (for Setter property in template or style)</span></span>

``` syntax
<Setter Property="propertyName" Value="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="5a50b-110">XAML 値</span><span class="sxs-lookup"><span data-stu-id="5a50b-110">XAML values</span></span>

| <span data-ttu-id="5a50b-111">用語</span><span class="sxs-lookup"><span data-stu-id="5a50b-111">Term</span></span> | <span data-ttu-id="5a50b-112">説明</span><span class="sxs-lookup"><span data-stu-id="5a50b-112">Description</span></span> |
|------|-------------|
| <span data-ttu-id="5a50b-113">propertyName</span><span class="sxs-lookup"><span data-stu-id="5a50b-113">propertyName</span></span> | <span data-ttu-id="5a50b-114">setter 構文で設定されるプロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="5a50b-114">The name of the property being set in the setter syntax.</span></span> <span data-ttu-id="5a50b-115">これは依存関係プロパティであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="5a50b-115">This must be a dependency property.</span></span> |
| <span data-ttu-id="5a50b-116">sourceProperty</span><span class="sxs-lookup"><span data-stu-id="5a50b-116">sourceProperty</span></span> | <span data-ttu-id="5a50b-117">template 宣言された型に存在する、別の依存関係プロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="5a50b-117">The name of another dependency property that exists on the type being templated.</span></span> |

## <a name="remarks"></a><span data-ttu-id="5a50b-118">注釈</span><span class="sxs-lookup"><span data-stu-id="5a50b-118">Remarks</span></span>

<span data-ttu-id="5a50b-119">カスタム コントロールの作成者である場合でも、コントロール テンプレートを今あるコントロールに置き換える場合でも、コントロール テンプレートを定義するうえでは **TemplateBinding** を使うことが欠かせません。</span><span class="sxs-lookup"><span data-stu-id="5a50b-119">Using **TemplateBinding** is a fundamental part of how you define a control template, either if you are a custom control author or if you are replacing a control template for existing controls.</span></span> <span data-ttu-id="5a50b-120">詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a50b-120">For more info, see [Quickstart: Control templates](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374).</span></span>

<span data-ttu-id="5a50b-121">*propertyName* と *targetProperty* では同じプロパティ名を使うことが一般的です。</span><span class="sxs-lookup"><span data-stu-id="5a50b-121">It's fairly common for *propertyName* and *targetProperty* to use the same property name.</span></span> <span data-ttu-id="5a50b-122">この場合、コントロール自体でプロパティを定義し、プロパティを、そのいずれかのコンポーネントの直感的な名前を持つ既にあるプロパティに転送します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-122">In this case, a control might define a property on itself and forward the property to an existing and intuitively named property of one of its component parts.</span></span> <span data-ttu-id="5a50b-123">たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) をコントロールの合成に組み込んでコントロール自体の **Text** プロパティの表示に使う場合は、コントロール テンプレートの一部として次の XAML を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-123">For example, a control that incorporates a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) in its compositing, which is used to display the control's own **Text** property, might include this XAML as a part in the control template:</span></span> `<TextBlock Text="{TemplateBinding Text}" .... />`

<span data-ttu-id="5a50b-124">ソース プロパティとターゲット プロパティの値として使う型は一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a50b-124">The types used as the value for the source property and the target property must match.</span></span> <span data-ttu-id="5a50b-125">**TemplateBinding** を使うとコンバーターを導入する機会がありません。</span><span class="sxs-lookup"><span data-stu-id="5a50b-125">There's no opportunity to introduce a converter when you're using **TemplateBinding**.</span></span> <span data-ttu-id="5a50b-126">値が一致しないと、XAML を解析したときにエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-126">Failing to match values results in an error when parsing the XAML.</span></span> <span data-ttu-id="5a50b-127">コンバーターを必要とする場合は、次のようなテンプレート バインドの冗長な形式の構文を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-127">If you need a converter you can use the verbose syntax for a template binding such as:</span></span> `{Binding RelativeSource={RelativeSource TemplatedParent}, Converter="..." ...}`

<span data-ttu-id="5a50b-128">XAML の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義の外側で **TemplateBinding** を使うと、パーサー エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-128">Attempting to use a **TemplateBinding** outside of a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML will result in a parser error.</span></span>

<span data-ttu-id="5a50b-129">親のテンプレート値も別のバインドとして延期される場合は、**TemplateBinding** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-129">You can use **TemplateBinding** for cases where the templated parent value is also deferred as another binding.</span></span> <span data-ttu-id="5a50b-130">**TemplateBinding** の評価は、必要な実行時バインドに値が設定されるまで待機することができます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-130">The evaluation for **TemplateBinding** can wait until any required runtime bindings have values.</span></span>

<span data-ttu-id="5a50b-131">**TemplateBinding** は常に一方向バインドです。</span><span class="sxs-lookup"><span data-stu-id="5a50b-131">A **TemplateBinding** is always a one-way binding.</span></span> <span data-ttu-id="5a50b-132">関係するプロパティはどちらも依存関係プロパティである必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a50b-132">Both properties involved must be dependency properties.</span></span>

<span data-ttu-id="5a50b-133">**TemplateBinding** はマークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="5a50b-133">**TemplateBinding** is a markup extension.</span></span> <span data-ttu-id="5a50b-134">通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-134">Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties.</span></span> <span data-ttu-id="5a50b-135">XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-135">All markup extensions in XAML use the "{" and "}" characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute.</span></span>

<span data-ttu-id="5a50b-136">**注:** Windows ランタイム XAML プロセッサの実装で、 **TemplateBinding**のバッキング クラス表現はありません。</span><span class="sxs-lookup"><span data-stu-id="5a50b-136">**Note**In the Windows Runtime XAML processor implementation, there is no backing class representation for **TemplateBinding**.</span></span> <span data-ttu-id="5a50b-137">**TemplateBinding** は、XAML マークアップでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-137">**TemplateBinding** is exclusively for use in XAML markup.</span></span> <span data-ttu-id="5a50b-138">コードの動作を再現する方法には単純なものがありません。</span><span class="sxs-lookup"><span data-stu-id="5a50b-138">There isn't a straightforward way to reproduce the behavior in code.</span></span>

### <a name="xbind-in-controltemplate"></a><span data-ttu-id="5a50b-139">ControlTemplate で X:bind</span><span class="sxs-lookup"><span data-stu-id="5a50b-139">x:Bind in ControlTemplate</span></span>

> [!NOTE]
> <span data-ttu-id="5a50b-140">Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk))、ControlTemplate で X:bind を使用する必要またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="5a50b-140">Using x:Bind in a ControlTemplate requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later.</span></span> <span data-ttu-id="5a50b-141">ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a50b-141">For more info about target versions, see [Version adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

<span data-ttu-id="5a50b-142">Windows 10、バージョン 1809、以降では**X:bind**マークアップ拡張を使用することができます[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391)で**TemplateBinding**を使用する任意の場所。</span><span class="sxs-lookup"><span data-stu-id="5a50b-142">Starting with Windows 10, version 1809, you can use the **x:Bind** markup extension anywhere you use **TemplateBinding** in a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391).</span></span> 

<span data-ttu-id="5a50b-143">[TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype)プロパティは、(オプションではなく) が必要で[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) **X:bind**を使用する場合。</span><span class="sxs-lookup"><span data-stu-id="5a50b-143">The [TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype) property is required (not optional) on [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) when using **x:Bind**.</span></span>

<span data-ttu-id="5a50b-144">**X:bind**のサポートには、 [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)でも、双方向バインディングとして[関数バインディング](../data-binding/function-bindings.md)の両方を使用できます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-144">With **x:Bind** support, you can use both [Function bindings](../data-binding/function-bindings.md) as well as two-way bindings in a [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391).</span></span>

<span data-ttu-id="5a50b-145">この例では、 **TextBlock.Text**プロパティは、 **Button.Content.ToString**に評価されます。</span><span class="sxs-lookup"><span data-stu-id="5a50b-145">In this example, the **TextBlock.Text** property evaluates to **Button.Content.ToString**.</span></span> <span data-ttu-id="5a50b-146">ControlTemplate で TargetType では、データ ソースとして機能し、親に TemplateBinding と同じ結果を実現します。</span><span class="sxs-lookup"><span data-stu-id="5a50b-146">The TargetType on the ControlTemplate acts as the data source and accomplishes the same result as a TemplateBinding to parent.</span></span>

```xaml
<ControlTemplate TargetType="Button">
    <Grid>
        <TextBlock Text="{x:Bind Content, Mode=OneWay}"/>
    </Grid>
</ControlTemplate>
```

## <a name="related-topics"></a><span data-ttu-id="5a50b-147">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5a50b-147">Related topics</span></span>

* [<span data-ttu-id="5a50b-148">クイック スタート: コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="5a50b-148">Quickstart: Control templates</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)
* [<span data-ttu-id="5a50b-149">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="5a50b-149">Data binding in depth</span></span>](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [**<span data-ttu-id="5a50b-150">ControlTemplate</span><span class="sxs-lookup"><span data-stu-id="5a50b-150">ControlTemplate</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209391)
* [<span data-ttu-id="5a50b-151">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="5a50b-151">XAML overview</span></span>](xaml-overview.md)
* [<span data-ttu-id="5a50b-152">依存関係プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="5a50b-152">Dependency properties overview</span></span>](dependency-properties-overview.md)
 

