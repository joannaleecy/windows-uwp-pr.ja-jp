---
description: コード ビハインドまたは一般的なコードからインスタンス化されたオブジェクトにアクセスするために、オブジェクト要素を一意に識別します。
title: xName 属性
ms.assetid: 4FF1F3ED-903A-4305-B2BD-DCD29E0C9E6D
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6ef1a6047a7c462961f40ae8913881125e2331bb
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8895236"
---
# <a name="xname-attribute"></a><span data-ttu-id="9ccfc-104">x:Name 属性</span><span class="sxs-lookup"><span data-stu-id="9ccfc-104">x:Name attribute</span></span>


<span data-ttu-id="9ccfc-105">コード ビハインドまたは一般的なコードからインスタンス化されたオブジェクトにアクセスするために、オブジェクト要素を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-105">Uniquely identifies object elements for access to the instantiated object from code-behind or general code.</span></span> <span data-ttu-id="9ccfc-106">基になるプログラミング モデルに適用後の **x:Name** は、コンストラクターによって返されるオブジェクト参照を保持する変数と等価であると見なすことができます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-106">Once applied to a backing programming model, **x:Name** can be considered equivalent to the variable holding an object reference, as returned by a constructor.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="9ccfc-107">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="9ccfc-107">XAML attribute usage</span></span>

``` syntax
<object x:Name="XAMLNameValue".../>
```

## <a name="xaml-values"></a><span data-ttu-id="9ccfc-108">XAML 値</span><span class="sxs-lookup"><span data-stu-id="9ccfc-108">XAML values</span></span>

| <span data-ttu-id="9ccfc-109">用語</span><span class="sxs-lookup"><span data-stu-id="9ccfc-109">Term</span></span> | <span data-ttu-id="9ccfc-110">説明</span><span class="sxs-lookup"><span data-stu-id="9ccfc-110">Description</span></span> |
|------|-------------|
| <span data-ttu-id="9ccfc-111">XAMLNameValue</span><span class="sxs-lookup"><span data-stu-id="9ccfc-111">XAMLNameValue</span></span> | <span data-ttu-id="9ccfc-112">XamlName の文法の制限に準拠する文字列。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-112">A string that conforms to the restrictions of the XamlName grammar.</span></span> |

##  <a name="xamlname-grammar"></a><span data-ttu-id="9ccfc-113">XamlName の文法</span><span class="sxs-lookup"><span data-stu-id="9ccfc-113">XamlName grammar</span></span>

<span data-ttu-id="9ccfc-114">XAML 実装でキーとして使われる文字列の規範となる文法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-114">The following is the normative grammar for a string that is used as a key in this XAML implementation:</span></span>

``` syntax
XamlName ::= NameStartChar (NameChar)*
NameStartChar ::= LetterCharacter | '_'
NameChar ::= NameStartChar | DecimalDigit
LetterCharacter ::= ('a'-'z') | ('A'-'Z')
DecimalDigit ::= '0'-'9'
CombiningCharacter::= none
```

-   <span data-ttu-id="9ccfc-115">文字は下位の ASCII の範囲 (具体的には、英文字の大文字と小文字、数字、アンダースコア (\_) 文字) に制限されています。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-115">Characters are restricted to the lower ASCII range, and more specifically to Roman alphabet uppercase and lowercase letters, digits, and the underscore (\_) character.</span></span>
-   <span data-ttu-id="9ccfc-116">Unicode 文字範囲はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-116">The Unicode character range is not supported.</span></span>
-   <span data-ttu-id="9ccfc-117">名前の先頭を数字にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-117">A name cannot begin with a digit.</span></span> <span data-ttu-id="9ccfc-118">一部のツールの実装では、ユーザーが数字を先頭文字として指定した場合、文字列の先頭にアンダースコア (\_) 文字が付加されます。または、ツールによって、数字が含まれる他の値に基づいて **x:Name** 値が自動生成されます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-118">Some tool implementations prepend an underscore (\_) to a string if the user supplies a digit as the initial character, or the tool autogenerates **x:Name** values based on other values that contain digits.</span></span>

## <a name="remarks"></a><span data-ttu-id="9ccfc-119">注釈</span><span class="sxs-lookup"><span data-stu-id="9ccfc-119">Remarks</span></span>

<span data-ttu-id="9ccfc-120">指定した **x:Name** は、XAML が処理されるときに基になるコードで生成されるフィールドの名前となり、そのフィールドにオブジェクトへの参照が保持されます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-120">The specified **x:Name** becomes the name of a field that is created in the underlying code when XAML is processed, and that field holds a reference to the object.</span></span> <span data-ttu-id="9ccfc-121">このフィールドの作成は、MSBuild ターゲットの手順で実行されます。この手順で、XAML ファイルの部分クラスとそのコード ビハインドも加えられます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-121">The process of creating this field is performed by the MSBuild target steps, which also are responsible for joining the partial classes for a XAML file and its code-behind.</span></span> <span data-ttu-id="9ccfc-122">この動作は、必ずしも XAML 言語で指定されているわけではなく、XAML のユニバーサル Windows プラットフォーム (UWP) のプログラミング モデルやアプリケーション モデルで **x:Name** を使うために適用されている特別な実装です。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-122">This behavior is not necessarily XAML-language specified; it is the particular implementation that Universal Windows Platform (UWP) programming for XAML applies to use **x:Name** in its programming and application models.</span></span>

<span data-ttu-id="9ccfc-123">定義されている各 **x:Name** は、XAML 名前スコープ内で一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-123">Each defined **x:Name** must be unique within a XAML namescope.</span></span> <span data-ttu-id="9ccfc-124">XAML 名前スコープは一般に、読み込まれたページのルート要素レベルで定義され、1 つの XAML ページ内のルート要素の下にすべての要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-124">Generally, a XAML namescope is defined at the root element level of a loaded page and contains all elements under that element in a single XAML page.</span></span> <span data-ttu-id="9ccfc-125">それ以外の XAML 名前スコープは、そのページで定義されているコントロール テンプレートやデータ テンプレートで定義されます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-125">Additional XAML namescopes are defined by any control template or data template that is defined on that page.</span></span> <span data-ttu-id="9ccfc-126">実行時には、適用されたコントロール テンプレートから作成されるオブジェクト ツリーのルートにまた別の XAML 名前スコープが作成されます。この XAML 名前空間はほかにも、[**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) の呼び出しで作成されるオブジェクト ツリーによっても作成されます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-126">At run time, another XAML namescope is created for the root of the object tree that is created from an applied control template, and also by object trees created from a call to [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048).</span></span> <span data-ttu-id="9ccfc-127">詳しくは、「[XAML 名前スコープ](xaml-namescopes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-127">For more info, see [XAML namescopes](xaml-namescopes.md).</span></span>

<span data-ttu-id="9ccfc-128">デザイン ツールでは、要素をデザイン サーフェイスに取り込むと要素の **x:Name** の値が自動生成されることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-128">Design tools often autogenerate **x:Name** values for elements when they are introduced to the design surface.</span></span> <span data-ttu-id="9ccfc-129">自動生成方式は使っているデザイナーによって異なりますが、一般的な方式では、要素をサポートするクラス名で始まり、その後に増加していく整数が続く文字列が生成されます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-129">The autogeneration scheme varies depending on which designer you are using, but a typical scheme is to generate a string that starts with the class name that backs the element, followed by an advancing integer.</span></span> <span data-ttu-id="9ccfc-130">たとえば、最初の [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) 要素をデザイナーに取り込むと、XAML ではこの要素の **x:Name** 属性の値が Button1 になります。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-130">For example, if you introduce the first [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) element to the designer, you might see that in the XAML this element has the **x:Name** attribute value of "Button1".</span></span>

<span data-ttu-id="9ccfc-131">**x:Name** は、XAML プロパティ要素構文で設定することも、[**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を使うコードで設定することもできません。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-131">**x:Name** cannot be set in XAML property element syntax, or in code using [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361).</span></span> <span data-ttu-id="9ccfc-132">**x:Name** は、要素の XAML 属性構文を使うことでのみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-132">**x:Name** can only be set using XAML attribute syntax on elements.</span></span>

<span data-ttu-id="9ccfc-133">**注:** 専用に C + +/CX アプリの場合、 **x: Name**参照のバッキング フィールドが、XAML ファイルまたはページのルート要素に対して作成されません。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-133">**Note**Specifically for C++/CX apps, a backing field for an **x:Name** reference is not created for the root element of a XAML file or page.</span></span> <span data-ttu-id="9ccfc-134">C++ のコード ビハインドからルート オブジェクトを参照する必要がある場合は、他の API またはツリー走査を使ってください。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-134">If you need to reference the root object from C++ code-behind, use other APIs or tree traversal.</span></span> <span data-ttu-id="9ccfc-135">たとえば、既知の名前付き子要素に対して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出した後、[**Parent**](https://msdn.microsoft.com/library/windows/apps/br208739) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-135">For example you can call [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) for a known named child element and then call [**Parent**](https://msdn.microsoft.com/library/windows/apps/br208739).</span></span>

### <a name="xname-and-other-name-properties"></a><span data-ttu-id="9ccfc-136">x:Name などの Name プロパティ</span><span class="sxs-lookup"><span data-stu-id="9ccfc-136">x:Name and other Name properties</span></span>

<span data-ttu-id="9ccfc-137">UWP XAML で使われる一部の型にも、**Name** という名前のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-137">Some types used in UWP XAML also have a property named **Name**.</span></span> <span data-ttu-id="9ccfc-138">[**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735)、[**TextElement.Name**](https://msdn.microsoft.com/library/windows/apps/hh702125) などです。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-138">For example, [**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735) and [**TextElement.Name**](https://msdn.microsoft.com/library/windows/apps/hh702125).</span></span>

<span data-ttu-id="9ccfc-139">要素で設定可能なプロパティとして **Name** が使用できる場合、XAML では **Name** と **x:Name** のどちらも使うことができますが、両方の属性を同じ要素で指定するとエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-139">If **Name** is available as a settable property on an element, **Name** and **x:Name** can be used interchangeably in XAML, but an error results if both attributes are specified on the same element.</span></span> <span data-ttu-id="9ccfc-140">また、**Name** プロパティがあるものの、読み取り専用であるという場合もあります ([**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031) など)。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-140">There are also cases where there's a **Name** property but it's read-only (like [**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031)).</span></span> <span data-ttu-id="9ccfc-141">そのような場合には、XAML 内の要素に名前を付けるときには常に **x:Name** を使います。読み取り専用の **Name** は、それほど一般的ではないコードのシナリオのために存在します。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-141">If that's the case you always use **x:Name** to name that element in the XAML and the read-only **Name** exists for some less-common code scenario.</span></span>

<span data-ttu-id="9ccfc-142">**注:**[**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735)は一般には、一般的な規則の例外となるいくつかのシナリオがありますが、 **x: Name**で設定された値を変更する方法として使用されません。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-142">**Note**[**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735) generally should not be used as a way to change values originally set by **x:Name**, although there are some scenarios that are exceptions to that general rule.</span></span> <span data-ttu-id="9ccfc-143">一般的なシナリオでは、XAML 名前スコープの作成と定義は XAML プロセッサの操作です。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-143">In typical scenarios, the creation and definition of XAML namescopes is a XAML processor operation.</span></span> <span data-ttu-id="9ccfc-144">**FrameworkElement.Name** を実行時に変更すると、XAML 名前スコープとプライベート フィールドの名前付けの調整の整合性が損なわれ、コード ビハインドで追跡するのが難しくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-144">Modifying **FrameworkElement.Name** at run time can result in an inconsistent XAML namescope / private field naming alignment, which is hard to keep track of in your code-behind.</span></span>

### <a name="xname-and-xkey"></a><span data-ttu-id="9ccfc-145">x:Name と x:Key</span><span class="sxs-lookup"><span data-stu-id="9ccfc-145">x:Name and x:Key</span></span>

<span data-ttu-id="9ccfc-146">[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内の要素に属性として **x:Name** を適用すると、[x:Key 属性](x-key-attribute.md)の代わりとしての役割を果たします</span><span class="sxs-lookup"><span data-stu-id="9ccfc-146">**x:Name** can be applied as an attribute to elements within a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) to act as a substitute for the [x:Key attribute](x-key-attribute.md).</span></span> <span data-ttu-id="9ccfc-147">(**ResourceDictionary** 内のどの要素にも x:Key または x:Name 属性があるというのが規則です)。これは、[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)によく見られます。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-147">(It's a rule that all elements in a **ResourceDictionary** must have an x:Key or x:Name attribute.) This is common for [Storyboarded animations](https://msdn.microsoft.com/library/windows/apps/mt187354).</span></span> <span data-ttu-id="9ccfc-148">詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」の各セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9ccfc-148">For more info, see section of [ResourceDictionary and XAML resource references](https://msdn.microsoft.com/library/windows/apps/mt187273).</span></span>

