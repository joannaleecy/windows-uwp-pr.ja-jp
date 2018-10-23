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
ms.localizationpriority: medium
ms.openlocfilehash: 8c1812adc9d5610fffd6f9d275b4e093a4fa96e6
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5410790"
---
# <a name="templatebinding-markup-extension"></a><span data-ttu-id="97522-105">{TemplateBinding} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="97522-105">{TemplateBinding} markup extension</span></span>


<span data-ttu-id="97522-106">コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。</span><span class="sxs-lookup"><span data-stu-id="97522-106">Links the value of a property in a control template to the value of some other exposed property on the templated control.</span></span> <span data-ttu-id="97522-107">XAML では、**TemplateBinding** は [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義内でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="97522-107">**TemplateBinding** can only be used within a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="97522-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="97522-108">XAML attribute usage</span></span>

``` syntax
<object propertyName="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-attribute-usage-for-setter-property-in-template-or-style"></a><span data-ttu-id="97522-109">XAML 属性の使用方法 (テンプレートまたはスタイルの Setter プロパティの場合)</span><span class="sxs-lookup"><span data-stu-id="97522-109">XAML attribute usage (for Setter property in template or style)</span></span>

``` syntax
<Setter Property="propertyName" Value="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="97522-110">XAML 値</span><span class="sxs-lookup"><span data-stu-id="97522-110">XAML values</span></span>

| <span data-ttu-id="97522-111">用語</span><span class="sxs-lookup"><span data-stu-id="97522-111">Term</span></span> | <span data-ttu-id="97522-112">説明</span><span class="sxs-lookup"><span data-stu-id="97522-112">Description</span></span> |
|------|-------------|
| <span data-ttu-id="97522-113">propertyName</span><span class="sxs-lookup"><span data-stu-id="97522-113">propertyName</span></span> | <span data-ttu-id="97522-114">setter 構文で設定されるプロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="97522-114">The name of the property being set in the setter syntax.</span></span> <span data-ttu-id="97522-115">これは依存関係プロパティであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="97522-115">This must be a dependency property.</span></span> |
| <span data-ttu-id="97522-116">sourceProperty</span><span class="sxs-lookup"><span data-stu-id="97522-116">sourceProperty</span></span> | <span data-ttu-id="97522-117">template 宣言された型に存在する、別の依存関係プロパティの名前。</span><span class="sxs-lookup"><span data-stu-id="97522-117">The name of another dependency property that exists on the type being templated.</span></span> |

## <a name="remarks"></a><span data-ttu-id="97522-118">注釈</span><span class="sxs-lookup"><span data-stu-id="97522-118">Remarks</span></span>

<span data-ttu-id="97522-119">カスタム コントロールの作成者である場合でも、コントロール テンプレートを今あるコントロールに置き換える場合でも、コントロール テンプレートを定義するうえでは **TemplateBinding** を使うことが欠かせません。</span><span class="sxs-lookup"><span data-stu-id="97522-119">Using **TemplateBinding** is a fundamental part of how you define a control template, either if you are a custom control author or if you are replacing a control template for existing controls.</span></span> <span data-ttu-id="97522-120">詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97522-120">For more info, see [Quickstart: Control templates](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374).</span></span>

<span data-ttu-id="97522-121">*propertyName* と *targetProperty* では同じプロパティ名を使うことが一般的です。</span><span class="sxs-lookup"><span data-stu-id="97522-121">It's fairly common for *propertyName* and *targetProperty* to use the same property name.</span></span> <span data-ttu-id="97522-122">この場合、コントロール自体でプロパティを定義し、プロパティを、そのいずれかのコンポーネントの直感的な名前を持つ既にあるプロパティに転送します。</span><span class="sxs-lookup"><span data-stu-id="97522-122">In this case, a control might define a property on itself and forward the property to an existing and intuitively named property of one of its component parts.</span></span> <span data-ttu-id="97522-123">たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) をコントロールの合成に組み込んでコントロール自体の **Text** プロパティの表示に使う場合は、コントロール テンプレートの一部として次の XAML を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="97522-123">For example, a control that incorporates a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) in its compositing, which is used to display the control's own **Text** property, might include this XAML as a part in the control template:</span></span> `<TextBlock Text="{TemplateBinding Text}" .... />`

<span data-ttu-id="97522-124">ソース プロパティとターゲット プロパティの値として使う型は一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97522-124">The types used as the value for the source property and the target property must match.</span></span> <span data-ttu-id="97522-125">**TemplateBinding** を使うとコンバーターを導入する機会がありません。</span><span class="sxs-lookup"><span data-stu-id="97522-125">There's no opportunity to introduce a converter when you're using **TemplateBinding**.</span></span> <span data-ttu-id="97522-126">値が一致しないと、XAML を解析したときにエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="97522-126">Failing to match values results in an error when parsing the XAML.</span></span> <span data-ttu-id="97522-127">コンバーターを必要とする場合は、次のようなテンプレート バインドの冗長な形式の構文を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="97522-127">If you need a converter you can use the verbose syntax for a template binding such as:</span></span> `{Binding RelativeSource={RelativeSource TemplatedParent}, Converter="..." ...}`

<span data-ttu-id="97522-128">XAML の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義の外側で **TemplateBinding** を使うと、パーサー エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="97522-128">Attempting to use a **TemplateBinding** outside of a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) definition in XAML will result in a parser error.</span></span>

<span data-ttu-id="97522-129">親のテンプレート値も別のバインドとして延期される場合は、**TemplateBinding** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="97522-129">You can use **TemplateBinding** for cases where the templated parent value is also deferred as another binding.</span></span> <span data-ttu-id="97522-130">**TemplateBinding** の評価は、必要な実行時バインドに値が設定されるまで待機することができます。</span><span class="sxs-lookup"><span data-stu-id="97522-130">The evaluation for **TemplateBinding** can wait until any required runtime bindings have values.</span></span>

<span data-ttu-id="97522-131">**TemplateBinding** は常に一方向バインドです。</span><span class="sxs-lookup"><span data-stu-id="97522-131">A **TemplateBinding** is always a one-way binding.</span></span> <span data-ttu-id="97522-132">関係するプロパティはどちらも依存関係プロパティである必要があります。</span><span class="sxs-lookup"><span data-stu-id="97522-132">Both properties involved must be dependency properties.</span></span>

<span data-ttu-id="97522-133">**TemplateBinding** はマークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="97522-133">**TemplateBinding** is a markup extension.</span></span> <span data-ttu-id="97522-134">通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。</span><span class="sxs-lookup"><span data-stu-id="97522-134">Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties.</span></span> <span data-ttu-id="97522-135">XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。</span><span class="sxs-lookup"><span data-stu-id="97522-135">All markup extensions in XAML use the "{" and "}" characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute.</span></span>

<span data-ttu-id="97522-136">**注**  Windows ランタイム XAML プロセッサの実装では、**TemplateBinding** のバッキング クラス表現はありません。</span><span class="sxs-lookup"><span data-stu-id="97522-136">**Note**  In the Windows Runtime XAML processor implementation, there is no backing class representation for **TemplateBinding**.</span></span> <span data-ttu-id="97522-137">**TemplateBinding** は、XAML マークアップでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="97522-137">**TemplateBinding** is exclusively for use in XAML markup.</span></span> <span data-ttu-id="97522-138">コードの動作を再現する方法には単純なものがありません。</span><span class="sxs-lookup"><span data-stu-id="97522-138">There isn't a straightforward way to reproduce the behavior in code.</span></span>

### <a name="xbind-in-controltemplate"></a><span data-ttu-id="97522-139">ControlTemplate で X:bind</span><span class="sxs-lookup"><span data-stu-id="97522-139">x:Bind in ControlTemplate</span></span>

<span data-ttu-id="97522-140">次回のメジャー アップデートを Windows 10 以降、 **X:bind**マークアップ拡張を使用することができます[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391)で**TemplateBinding**を使用した任意の場所。</span><span class="sxs-lookup"><span data-stu-id="97522-140">Starting with the next major update to Windows 10, you can use **x:Bind** markup extension anywhere you used **TemplateBinding** in [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391).</span></span> 

<span data-ttu-id="97522-141">[TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype#Windows_UI_Xaml_Controls_ControlTemplate_TargetType)プロパティが必要です (オプションではなく) [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) **X:bind**を使用する場合にします。</span><span class="sxs-lookup"><span data-stu-id="97522-141">The [TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype#Windows_UI_Xaml_Controls_ControlTemplate_TargetType) property will be required (not optional) on [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) when using **x:Bind**.</span></span>

<span data-ttu-id="97522-142">**X:bind**のサポートできるようになりましたとして使用できますどちらの[関数バインド](../data-binding/function-bindings.md) [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)でも、双方向のバインド</span><span class="sxs-lookup"><span data-stu-id="97522-142">With **x:Bind** support, you can now use both [Function bindings](../data-binding/function-bindings.md) as well as two-way bindings in [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)</span></span>

<span data-ttu-id="97522-143">次の例では、TextBlock.Text Button.Content.ToString() と評価されます。</span><span class="sxs-lookup"><span data-stu-id="97522-143">In the following example, the TextBlock.Text evaluates to Button.Content.ToString().</span></span> <span data-ttu-id="97522-144">ControlTemplate で TargetType では、データ ソースとして機能し、親に TemplateBinding と同じ結果を実現します。</span><span class="sxs-lookup"><span data-stu-id="97522-144">The TargetType on the ControlTemplate acts as the data source and accomplishes the same result as a TemplateBinding to parent.</span></span>

```xaml
<ControlTemplate TargetType="Button">
    <Grid>
        <TextBlock Text="{x:Bind Content}" />
    </Grid>
</ControlTemplate>
```

## <a name="related-topics"></a><span data-ttu-id="97522-145">関連トピック</span><span class="sxs-lookup"><span data-stu-id="97522-145">Related topics</span></span>

* [<span data-ttu-id="97522-146">クイック スタート: コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="97522-146">Quickstart: Control templates</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)
* [<span data-ttu-id="97522-147">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="97522-147">Data binding in depth</span></span>](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [**<span data-ttu-id="97522-148">ControlTemplate</span><span class="sxs-lookup"><span data-stu-id="97522-148">ControlTemplate</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209391)
* [<span data-ttu-id="97522-149">XAML の概要</span><span class="sxs-lookup"><span data-stu-id="97522-149">XAML overview</span></span>](xaml-overview.md)
* [<span data-ttu-id="97522-150">依存関係プロパティの概要</span><span class="sxs-lookup"><span data-stu-id="97522-150">Dependency properties overview</span></span>](dependency-properties-overview.md)
 

