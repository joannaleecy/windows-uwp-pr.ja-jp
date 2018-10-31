---
author: jwmsft
description: リソースとして作成されて参照される、ResourceDictionary 内に存在する要素を一意に識別します。
title: xKey 属性
ms.assetid: 141FC5AF-80EE-4401-8A1B-17CB22C2277A
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8d48ccb93a411e92b57059192de38366f27353a3
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5864392"
---
# <a name="xkey-attribute"></a><span data-ttu-id="238c1-104">x:Key 属性</span><span class="sxs-lookup"><span data-stu-id="238c1-104">x:Key attribute</span></span>


<span data-ttu-id="238c1-105">リソースとして作成されて参照される、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内に存在する要素を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="238c1-105">Uniquely identifies elements that are created and referenced as resources, and which exist within a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="238c1-106">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="238c1-106">XAML attribute usage</span></span>

``` syntax
<ResourceDictionary>
  <object x:Key="stringKeyValue".../>
</ResourceDictionary>
```

## <a name="xaml-attribute-usage-implicit-resourcedictionary"></a><span data-ttu-id="238c1-107">XAML 属性の使用方法 (暗黙的な **ResourceDictionary**)</span><span class="sxs-lookup"><span data-stu-id="238c1-107">XAML attribute usage (implicit **ResourceDictionary**)</span></span>

``` syntax
<object.Resources>
  <object x:Key="stringKeyValue".../>
</object.Resources>
```

## <a name="xaml-values"></a><span data-ttu-id="238c1-108">XAML 値</span><span class="sxs-lookup"><span data-stu-id="238c1-108">XAML values</span></span>

| <span data-ttu-id="238c1-109">用語</span><span class="sxs-lookup"><span data-stu-id="238c1-109">Term</span></span> | <span data-ttu-id="238c1-110">説明</span><span class="sxs-lookup"><span data-stu-id="238c1-110">Description</span></span> |
|------|-------------|
| <span data-ttu-id="238c1-111">object</span><span class="sxs-lookup"><span data-stu-id="238c1-111">object</span></span> | <span data-ttu-id="238c1-112">共有可能な任意のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="238c1-112">Any object that is shareable.</span></span> <span data-ttu-id="238c1-113">「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="238c1-113">See [ResourceDictionary and XAML resource references](https://msdn.microsoft.com/library/windows/apps/mt187273).</span></span> |
| <span data-ttu-id="238c1-114">stringKeyValue</span><span class="sxs-lookup"><span data-stu-id="238c1-114">stringKeyValue</span></span> | <span data-ttu-id="238c1-115">_XamlName_> の文法に準拠する必要がある、キーとして使われる実際の文字列。</span><span class="sxs-lookup"><span data-stu-id="238c1-115">A true string used as a key, which must conform to the _XamlName_> grammar.</span></span> <span data-ttu-id="238c1-116">以下の「XamlName の文法」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="238c1-116">See "XamlName grammar" below.</span></span> | 

##  <a name="xamlname-grammar"></a><span data-ttu-id="238c1-117">XamlName の文法</span><span class="sxs-lookup"><span data-stu-id="238c1-117">XamlName grammar</span></span>

<span data-ttu-id="238c1-118">ユニバーサル Windows プラットフォーム (UWP) の XAML 実装でキーとして使われる文字列の規範となる文法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="238c1-118">The following is the normative grammar for a string that is used as a key in the Universal Windows Platform (UWP) XAML implementation:</span></span>

``` syntax
XamlName ::= NameStartChar (NameChar)*
NameStartChar ::= LetterCharacter | '_'
NameChar ::= NameStartChar | DecimalDigit
LetterCharacter ::= ('a'-'z') | ('A'-'Z')
DecimalDigit ::= '0'-'9'
CombiningCharacter::= none
```

-   <span data-ttu-id="238c1-119">文字は下位の ASCII の範囲 (具体的には、英文字の大文字と小文字、数字、アンダースコア (\_) 文字) に制限されています。</span><span class="sxs-lookup"><span data-stu-id="238c1-119">Characters are restricted to the lower ASCII range, and more specifically to Roman alphabet uppercase and lowercase letters, digits, and the underscore (\_) character.</span></span>
-   <span data-ttu-id="238c1-120">Unicode 文字範囲はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="238c1-120">The Unicode character range is not supported.</span></span>
-   <span data-ttu-id="238c1-121">名前の先頭を数字にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="238c1-121">A name cannot begin with a digit.</span></span>

## <a name="remarks"></a><span data-ttu-id="238c1-122">注釈</span><span class="sxs-lookup"><span data-stu-id="238c1-122">Remarks</span></span>

<span data-ttu-id="238c1-123">通常、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の子要素は、そのディクショナリ内の一意のキー値を指定する **x:Key** 属性を含みます。</span><span class="sxs-lookup"><span data-stu-id="238c1-123">Child elements of a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) generally include an **x:Key** attribute that specifies a unique key value within that dictionary.</span></span> <span data-ttu-id="238c1-124">キーは、読み込み時に XAML プロセッサによって一意であることが要求されます。</span><span class="sxs-lookup"><span data-stu-id="238c1-124">Key uniqueness is enforced at load time by the XAML processor.</span></span> <span data-ttu-id="238c1-125">**x:Key** 値が一意でない場合は、XAML の解析で例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="238c1-125">Non-unique **x:Key** values will result in XAML parse exceptions.</span></span> <span data-ttu-id="238c1-126">[{StaticResource} マークアップ拡張](staticresource-markup-extension.md)によって要求された場合、解決されていないキーも XAML の解析での例外の原因になります。</span><span class="sxs-lookup"><span data-stu-id="238c1-126">If requested by [{StaticResource} markup extension](staticresource-markup-extension.md), a non-resolved key will also result in XAML parse exceptions.</span></span>

<span data-ttu-id="238c1-127">**x:Key** と [x:Name](x-name-attribute.md) は同じ概念ではありません。</span><span class="sxs-lookup"><span data-stu-id="238c1-127">**x:Key** and [x:Name](x-name-attribute.md) are not identical concepts.</span></span> <span data-ttu-id="238c1-128">**x:Key** はリソース ディクショナリだけで使われます。</span><span class="sxs-lookup"><span data-stu-id="238c1-128">**x:Key** is used exclusively in resource dictionaries.</span></span> <span data-ttu-id="238c1-129">x:Name は、すべての XAML 領域で使われます。</span><span class="sxs-lookup"><span data-stu-id="238c1-129">x:Name is used for all areas of XAML.</span></span> <span data-ttu-id="238c1-130">キー値を使って [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出した場合、キーを持つリソースは取得されません。</span><span class="sxs-lookup"><span data-stu-id="238c1-130">A [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) call using a key value will not retrieve a keyed resource.</span></span> <span data-ttu-id="238c1-131">リソース ディクショナリで定義されているオブジェクトは、**x:Key** と **x:Name** のどちらか一方または両方を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="238c1-131">Objects defined in a resource dictionary may have an **x:Key**, an **x:Name** or both.</span></span> <span data-ttu-id="238c1-132">キーと名前が一致する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="238c1-132">The key and name are not required to match.</span></span>

<span data-ttu-id="238c1-133">ここに示す暗黙的な構文において、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) オブジェクトは XAML プロセッサが [**Resources**](https://msdn.microsoft.com/library/windows/apps/br208740) コレクションを取得するための新しいオブジェクトを生成する方法を暗黙的に決定することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="238c1-133">Note that in the implicit syntax shown, the [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) object is implicit in how the XAML processor produces a new object to populate a [**Resources**](https://msdn.microsoft.com/library/windows/apps/br208740) collection.</span></span>

<span data-ttu-id="238c1-134">**x:Key** の指定に相当するコードは、基になる [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) でキーを使う任意の操作です。</span><span class="sxs-lookup"><span data-stu-id="238c1-134">The code equivalent of specifying **x:Key** is any operation that uses a key with the underlying [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794).</span></span> <span data-ttu-id="238c1-135">たとえば、あるリソースのマークアップで適用される **x:Key** は、リソースを **ResourceDictionary** に追加するときの **Insert** の *key* パラメーターの値と同じです。</span><span class="sxs-lookup"><span data-stu-id="238c1-135">For example, an **x:Key** applied in markup for a resource is equivalent to the value of the *key* parameter of **Insert** when you add the resource to a **ResourceDictionary**.</span></span>

<span data-ttu-id="238c1-136">リソース ディクショナリ内の項目は、ターゲットとなる [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) または [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) である場合、**x:Key** の値を省略できます。どちらの場合も、リソース項目の暗黙的なキーは、文字列として解釈される **TargetType** 値です。</span><span class="sxs-lookup"><span data-stu-id="238c1-136">An item in a resource dictionary can omit a value for **x:Key** if it is a targeted [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) or [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391); in each of these cases the implicit key of the resource item is the **TargetType** value interpreted as a string.</span></span> <span data-ttu-id="238c1-137">詳しくは、「[クイック スタート: コントロールのスタイル (JavaScript と HTML を使った Windows ストア アプリ)](https://msdn.microsoft.com/library/windows/apps/hh465498)」と「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="238c1-137">For more info, see [Quickstart: styling controls](https://msdn.microsoft.com/library/windows/apps/hh465498) and [ResourceDictionary and XAML resource references](https://msdn.microsoft.com/library/windows/apps/mt187273).</span></span>

