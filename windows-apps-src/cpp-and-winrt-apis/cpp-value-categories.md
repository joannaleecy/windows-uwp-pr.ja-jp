---
author: stevewhims
description: このトピックでは、C++ での値のさまざまなカテゴリについて説明します。 左辺値と rvalue の音が間違いされますが、すぎる他の種類。
title: 値のカテゴリとへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4090532"
---
# <a name="value-categories-and-references-to-them"></a><span data-ttu-id="d5941-105">値のカテゴリとへの参照</span><span class="sxs-lookup"><span data-stu-id="d5941-105">Value categories, and references to them</span></span>
<span data-ttu-id="d5941-106">このトピックでは、C++ で存在するさまざまなカテゴリの値 (および値への参照) について説明します。</span><span class="sxs-lookup"><span data-stu-id="d5941-106">This topic describes the various categories of values (and references to values) that exist in C++.</span></span> <span data-ttu-id="d5941-107">*左辺値*と*rvalue*の音が間違いされますが、このトピックでは条件でそれらのない考え。</span><span class="sxs-lookup"><span data-stu-id="d5941-107">You will doubtless have heard of *lvalues* and *rvalues*, but you may not think of them in the terms that this topic presents.</span></span> <span data-ttu-id="d5941-108">すぎるは、値の他の種類があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-108">And there are other kinds of values, too.</span></span>

<span data-ttu-id="d5941-109">C++ ですべての式では、このトピックで説明されているカテゴリのいずれかに属している値が存在します。</span><span class="sxs-lookup"><span data-stu-id="d5941-109">Every expression in C++ yields a value that belongs to one of the categories discussed in this topic.</span></span> <span data-ttu-id="d5941-110">C++ 言語、facilies、およびこれらの値のカテゴリとへの参照の適切な理解を要求する規則の側面があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-110">There are aspects of the C++ language, its facilies, and rules, that demand a proper understanding of these value categories, and references to them.</span></span> <span data-ttu-id="d5941-111">たとえば、値、値をコピー、移動、値および別の関数に値を転送のアドレスを考慮できます。</span><span class="sxs-lookup"><span data-stu-id="d5941-111">For example, taking the address of a value, copying a value, moving a value, and forwarding a value on to another function.</span></span> <span data-ttu-id="d5941-112">このトピックでは、すべての詳細、それらの側面に送られませんが、それらの単色についての基本的な情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="d5941-112">This topic doesn't go into all of those aspects in depth, but it provides foundational information for a solid understanding of them.</span></span>

<span data-ttu-id="d5941-113">このトピックの情報は、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。</span><span class="sxs-lookup"><span data-stu-id="d5941-113">The info in this topic is framed in terms of Stroustrup's analysis of value categories by the two independent properties of identity and movability [Stroustrup, 2013].</span></span>

## <a name="an-lvalue-has-identity"></a><span data-ttu-id="d5941-114">左辺が識別情報</span><span class="sxs-lookup"><span data-stu-id="d5941-114">An lvalue has identity</span></span>
<span data-ttu-id="d5941-115">*Id*の値に何を意味しますか。</span><span class="sxs-lookup"><span data-stu-id="d5941-115">What does it mean for a value to have *identity*?</span></span> <span data-ttu-id="d5941-116">(または場合かかることができます) の値のメモリ アドレスし、値がある識別し、安全に使用します。</span><span class="sxs-lookup"><span data-stu-id="d5941-116">If you have (or you can take) the memory address of a value and use it safely, then the value has identity.</span></span> <span data-ttu-id="d5941-117">これによりを行う比較を超える値の内容: 比較または id で区別することができます。</span><span class="sxs-lookup"><span data-stu-id="d5941-117">That way, you can do more than compare the contents of values: you can compare or distinguish them by identity.</span></span>

<span data-ttu-id="d5941-118">*左辺値*では、ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="d5941-118">An *lvalue* has identity.</span></span> <span data-ttu-id="d5941-119">「左辺値」の"l"が「左」(と同様、left-hand 側の割り当て) の省略形である履歴のみ関心のある問題です。</span><span class="sxs-lookup"><span data-stu-id="d5941-119">It's now a matter of only historical interest that the "l" in "lvalue" is an abbreviation of "left" (as in, the left-hand-side of an assignment).</span></span> <span data-ttu-id="d5941-120">C++ では、左辺左上 *、または*割り当ての右側に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d5941-120">In C++, an lvalue can appear on the left *or* on the right of an assignment.</span></span> <span data-ttu-id="d5941-121">「左辺値」の"l"し、しない実際にするために役立ちます理解もは何かを定義します。</span><span class="sxs-lookup"><span data-stu-id="d5941-121">The "l" in "lvalues", then, doesn't actually help you to comprehend nor define what they are.</span></span> <span data-ttu-id="d5941-122">操作が起きると呼ばれるが id を持つ値であることを理解する場合にのみ必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-122">You need only to understand that what we call an lvalue is a value that has identity.</span></span>

<span data-ttu-id="d5941-123">左辺値の式の例: 名前付き変数または定数です。または、参照を返す関数。</span><span class="sxs-lookup"><span data-stu-id="d5941-123">Examples of expressions that are lvalues include: a named variable or constant; or a function that returns a reference.</span></span> <span data-ttu-id="d5941-124">*いない*左辺値の式の例: 一時的なです。または、値を返す関数。</span><span class="sxs-lookup"><span data-stu-id="d5941-124">Examples of expressions that are *not* lvalues include: a temporary; or a function that returns by value.</span></span>

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    std::vector<byte> vec{ 99, 98, 97 };
    std::vector<byte>* addr1{ &vec }; // ok: vec is an lvalue.
    int* addr2{ &get_by_ref() }; // ok: get_by_ref() is an lvalue.

    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is not an lvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is not an lvalue.
}
```

<span data-ttu-id="d5941-125">これで、true を指定するステートメントですが、その左辺値には、取得を行うための id が存在します。</span><span class="sxs-lookup"><span data-stu-id="d5941-125">Now, while it's a true statement that lvalues have identity, so do xvalues.</span></span> <span data-ttu-id="d5941-126">さらに詳しくどのような*xvalue フラグ*は、このトピックで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="d5941-126">We'll go more into what an *xvalue* is later in this topic.</span></span> <span data-ttu-id="d5941-127">ここでは、単に注意してください glvalue、「左辺して汎用化」と呼ばれる値のカテゴリがあることです。</span><span class="sxs-lookup"><span data-stu-id="d5941-127">For now, just be aware that there is a value category called glvalue, for "generalized lvalue".</span></span> <span data-ttu-id="d5941-128">Glvalues のスーパー セットには、左辺値 (*古代左辺値*とも呼ばれます) と取得の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d5941-128">The superset of glvalues contains both lvalues (also known as *classical lvalues*) and xvalues.</span></span> <span data-ttu-id="d5941-129">中にそのため、「左辺値は、id を持って」true の場合、次の図に示すように id を持つ作業の完全なセットは、glvalues のセットです。</span><span class="sxs-lookup"><span data-stu-id="d5941-129">So, while "an lvalue has identity" is true, the complete set of things that have identity is the set of glvalues, as shown in this illustration.</span></span>

![左辺が識別情報](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a><span data-ttu-id="d5941-131">右辺値が移動します。左辺でないです。</span><span class="sxs-lookup"><span data-stu-id="d5941-131">An rvalue is movable; an lvalue is not</span></span>
<span data-ttu-id="d5941-132">Glvalues ではない値があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-132">But there are values that are not glvalues.</span></span> <span data-ttu-id="d5941-133">したがって、これには (またはを有効にすることに依存することはできません) のメモリ アドレスを取得する*ことはできません*が、値があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-133">Consequently, there are values that you *can't* obtain a memory address for (or you can't rely on it to be valid).</span></span> <span data-ttu-id="d5941-134">上記のコード例ではこのようないくつかの値をしました。</span><span class="sxs-lookup"><span data-stu-id="d5941-134">We saw some such values in the code example above.</span></span> <span data-ttu-id="d5941-135">欠点が聞こえます。</span><span class="sxs-lookup"><span data-stu-id="d5941-135">This sounds like a disadvantage.</span></span> <span data-ttu-id="d5941-136">実際には値の利点は、つまり (これは一般に安価) そこからの*移動*ではなく (これは一般に負荷の高い) からコピーできます。</span><span class="sxs-lookup"><span data-stu-id="d5941-136">But in fact the advantage of a value like that is that you can *move* from it (which is generally cheap), rather than copy from it (which is generally expensive).</span></span> <span data-ttu-id="d5941-137">値からの移行は、それが、場所にするために使用しなくなったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="d5941-137">Moving from a value means that it's no longer in the place it used to be.</span></span> <span data-ttu-id="d5941-138">そのためにするために使用する場所にアクセスしようとする必要が回避されます。</span><span class="sxs-lookup"><span data-stu-id="d5941-138">So, trying to access it in the place it used to be is something to be avoided.</span></span> <span data-ttu-id="d5941-139">タイミングと*方法*値は、このトピックの範囲外に移動するのについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d5941-139">A discussion of when and *how* to move a value is out of scope for this topic.</span></span> <span data-ttu-id="d5941-140">このトピックのだけを移動する値が*右辺値*(または*古代右辺値*) と呼ばれることを知る必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-140">For this topic, we just need to know that a value that is movable is known as an *rvalue* (or *classical rvalue*).</span></span>

<span data-ttu-id="d5941-141">「右辺値」の"r"では、「権利」(と同様、右-hand 側の割り当て) の省略形です。</span><span class="sxs-lookup"><span data-stu-id="d5941-141">The "r" in "rvalue" is an abbreviation of "right" (as in, the right-hand-side of an assignment).</span></span> <span data-ttu-id="d5941-142">ただし、rvalue と割り当ての外部の rvalue への参照を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d5941-142">But you can use rvalues, and references to rvalues, outside of assignments.</span></span> <span data-ttu-id="d5941-143">"Rvalue"の"r"に集中することを次はありません。</span><span class="sxs-lookup"><span data-stu-id="d5941-143">The "r" in "rvalues", then, is not the thing to focus on.</span></span> <span data-ttu-id="d5941-144">右辺値と呼ばれるが移動する値であることを理解する場合にのみ必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-144">You need only to understand that what we call an rvalue is a value that is movable.</span></span>

<span data-ttu-id="d5941-145">次の図に示すように、左辺は逆に、移動はありません。</span><span class="sxs-lookup"><span data-stu-id="d5941-145">An lvalue, conversely, isn't movable, as shown in this illustration.</span></span> <span data-ttu-id="d5941-146">移動操作が起きると*左辺*での定義の対立するものし、予期しない左辺へのアクセスを続けることが合理的に非常に想定されているコードについては問題になります。</span><span class="sxs-lookup"><span data-stu-id="d5941-146">An lvalue that moved would defy the definition of *lvalue*, and it would be an unexpected problem for code that very reasonably expected to be able to continue to access the lvalue.</span></span>

![右辺値が移動します。左辺でないです。](images/is-movable.png)

<span data-ttu-id="d5941-148">左辺を移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="d5941-148">You can't move an lvalue.</span></span> <span data-ttu-id="d5941-149">あります*が*移動できる glvalue (id を使ったモ ノのセット) の種類&mdash;何をしていることがわかっている場合 (など、移動後アクセスにしないように注意してください)&mdash;、xvalue フラグです。</span><span class="sxs-lookup"><span data-stu-id="d5941-149">But there *is* a kind of glvalue (the set of things with identity) that you can move&mdash;if you know what you're doing (including being careful not to access it after the move)&mdash;and that's the xvalue.</span></span> <span data-ttu-id="d5941-150">この概念をもう一度、下の値のカテゴリの全体像を見てときします再度使用します。</span><span class="sxs-lookup"><span data-stu-id="d5941-150">We'll revisit this idea one more time below, when we look at the complete picture of value categories.</span></span>

## <a name="rvalue-references-and-reference-binding-rules"></a><span data-ttu-id="d5941-151">右辺値への参照と参照バインド規則</span><span class="sxs-lookup"><span data-stu-id="d5941-151">Rvalue references, and reference-binding rules</span></span>
<span data-ttu-id="d5941-152">このセクションでは、右辺値への参照の構文について説明します。</span><span class="sxs-lookup"><span data-stu-id="d5941-152">This section introduces the syntax for a reference to an rvalue.</span></span> <span data-ttu-id="d5941-153">別のトピックに移動し、転送の大幅な処理を待機する必要がありますが、これらは右辺値への参照によって解決の問題。</span><span class="sxs-lookup"><span data-stu-id="d5941-153">We'll have to wait for another topic to go into a substantial treatment of moving and forwarding, but those are problems that are solved by rvalue references.</span></span> <span data-ttu-id="d5941-154">右辺値への参照を見ると、前に、最初にする必要が明確になる`T&`&mdash;ことおした旧されてを呼び出すだけ「参照」です。</span><span class="sxs-lookup"><span data-stu-id="d5941-154">Before we look at rvalue references, though, we first need to be clearer about `T&`&mdash;the thing we've formerly been calling just "a reference".</span></span> <span data-ttu-id="d5941-155">実際には「左辺値 (非 const) 参照」を指定する参照のユーザーを書き込むことができます () の値を参照します。</span><span class="sxs-lookup"><span data-stu-id="d5941-155">It's really "an lvalue (non-const) reference", which refers to an value to which the user of the reference can write.</span></span>

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

<span data-ttu-id="d5941-156">左辺参照は、右辺値ではなく、左辺値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="d5941-156">An lvalue reference can bind to an lvalue, but not to an rvalue.</span></span>

<span data-ttu-id="d5941-157">左辺 const 参照し、(`T const&`)、*できない*リファレンスのユーザーが (たとえば、定数) 書き込むオブジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="d5941-157">Then there are lvalue const references (`T const&`), which refer to objects to which the user of the reference *can't* write (for example, a constant).</span></span>

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

<span data-ttu-id="d5941-158">左辺 const 参照は、左辺または右辺値にバインドします。</span><span class="sxs-lookup"><span data-stu-id="d5941-158">An lvalue const reference can bind to an lvalue or to an rvalue.</span></span>

<span data-ttu-id="d5941-159">型の右辺値への参照の構文`T`として記述`T&&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-159">The syntax for a reference to an rvalue of type `T` is written as `T&&`.</span></span> <span data-ttu-id="d5941-160">右辺値参照が移動可能な値を参照&mdash;、値の内容が (たとえば、一時) が使用した後に保持する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d5941-160">An rvalue reference refers to a movable value&mdash;an value whose contents we don't need to preserve after we've used it (for example, a temporary).</span></span> <span data-ttu-id="d5941-161">ポイント全体以降から移動する (変更できるため) 値にバインドされて、右辺値参照`const`と`volatile`右辺値への参照に修飾子 (cv 修飾子のとも呼ばれます) は適用されません。</span><span class="sxs-lookup"><span data-stu-id="d5941-161">Since the whole point is to move from (thereby modifying) the value bound to an rvalue reference, `const` and `volatile` qualifiers (also known as cv-qualifiers) don't apply to rvalue references.</span></span>

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

<span data-ttu-id="d5941-162">右辺値参照は、右辺値にバインドします。</span><span class="sxs-lookup"><span data-stu-id="d5941-162">An rvalue reference binds to an rvalue.</span></span> <span data-ttu-id="d5941-163">オーバー ロード解決、右辺値*を希望*右辺値への参照よりも左辺 const 参照にバインドされているという点で実際には、</span><span class="sxs-lookup"><span data-stu-id="d5941-163">In fact, in terms of overload resolution, an rvalue *prefers* to be bound to an rvalue reference than to an lvalue const reference.</span></span> <span data-ttu-id="d5941-164">ただし、前述した右辺値参照値を参照します (たとえば、移動コンス トラクターのパラメーター) を維持する必要はありませんと見なされますの内容があるために、右辺値参照が左辺値にバインドできません。</span><span class="sxs-lookup"><span data-stu-id="d5941-164">But an rvalue reference can't bind to an lvalue because, as we've said, an rvalue reference refers to a value whose contents it's assumed we don't need to preserve (say, the parameter for a move constructor).</span></span>

<span data-ttu-id="d5941-165">渡すこともできます右辺値引数の値では、予期されているところコピー コンス トラクターを介して (または、右辺値が、xvalue フラグである場合は、ムーブ構築経由で)。</span><span class="sxs-lookup"><span data-stu-id="d5941-165">You can also pass an rvalue where a by-value argument is expected, via copy construction (or via move construction, if the rvalue is an xvalue).</span></span>

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a><span data-ttu-id="d5941-166">Glvalue がの id。prvalue しません。</span><span class="sxs-lookup"><span data-stu-id="d5941-166">A glvalue has identity; a prvalue does not</span></span>
<span data-ttu-id="d5941-167">この段階では、ユーザーがどのようながわかっています。</span><span class="sxs-lookup"><span data-stu-id="d5941-167">At this stage, we know what has identity.</span></span> <span data-ttu-id="d5941-168">移動とそうでないことが確認します。</span><span class="sxs-lookup"><span data-stu-id="d5941-168">And we know what's movable and what isn't.</span></span> <span data-ttu-id="d5941-169">まだおまだ名前付きの値のセットで id を持つ*しないでください*。</span><span class="sxs-lookup"><span data-stu-id="d5941-169">But we haven't yet named the set of values that *don't* have identity.</span></span> <span data-ttu-id="d5941-170">そのセットは、 *prvalue*、または*純粋な右辺値*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d5941-170">That set is known as the *prvalue*, or *pure rvalue*.</span></span>

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺がの id。prvalue しません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a><span data-ttu-id="d5941-172">値のカテゴリの完全な画像</span><span class="sxs-lookup"><span data-stu-id="d5941-172">The complete picture of value categories</span></span>
<span data-ttu-id="d5941-173">情報と上の図に、1 つの大きな画像を組み合わせるのみは変わりません。</span><span class="sxs-lookup"><span data-stu-id="d5941-173">It only remains to combine the info and illustrations above into a single, big picture.</span></span>

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a><span data-ttu-id="d5941-175">glvalue (i)</span><span class="sxs-lookup"><span data-stu-id="d5941-175">glvalue (i)</span></span>
<span data-ttu-id="d5941-176">Glvalue (汎用左辺値) は、id を持っています。</span><span class="sxs-lookup"><span data-stu-id="d5941-176">A glvalue (generalized lvalue) has identity.</span></span>

### <a name="lvalue-im"></a><span data-ttu-id="d5941-177">左辺値 (i\ & \!m)</span><span class="sxs-lookup"><span data-stu-id="d5941-177">lvalue (i\&\!m)</span></span>
<span data-ttu-id="d5941-178">左辺 (glvalue の種類) では、id しますが、移動はありません。</span><span class="sxs-lookup"><span data-stu-id="d5941-178">An lvalue (a kind of glvalue) has identity, but isn't movable.</span></span> <span data-ttu-id="d5941-179">これらは、通常の読み取り/書き込み値を渡して周囲参照または const 参照、または値のコピーが低い場合です。</span><span class="sxs-lookup"><span data-stu-id="d5941-179">These are typically read-write values that you pass around by reference or by const reference, or by value if copying is cheap.</span></span> <span data-ttu-id="d5941-180">左辺値にバインド右辺値参照することはできません。</span><span class="sxs-lookup"><span data-stu-id="d5941-180">An lvalue can't be bound to an rvalue reference.</span></span>

### <a name="xvalue-im"></a><span data-ttu-id="d5941-181">xvalue フラグ (i\ & m)</span><span class="sxs-lookup"><span data-stu-id="d5941-181">xvalue (i\&m)</span></span>
<span data-ttu-id="d5941-182">(Glvalue の種類も右辺値の種類)、xvalue フラグ id がありも移動します。</span><span class="sxs-lookup"><span data-stu-id="d5941-182">An xvalue (a kind of glvalue, but also a kind of rvalue) has identity, and is also movable.</span></span> <span data-ttu-id="d5941-183">これのコピーは、コストがかかるために、移動しようとしたされる操作が起きる可能性があり、後にアクセスしないように注意することができます。</span><span class="sxs-lookup"><span data-stu-id="d5941-183">This might be an erstwhile lvalue that you've decided to move because copying is expensive, and you'll be careful not to access it afterward.</span></span> <span data-ttu-id="d5941-184">以下に、xvalue フラグに左辺を有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d5941-184">Here's how you can turn an lvalue into an xvalue.</span></span>

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

<span data-ttu-id="d5941-185">上記のコード例では移動していない何もまだします。</span><span class="sxs-lookup"><span data-stu-id="d5941-185">In the code example above, we haven't moved anything yet.</span></span> <span data-ttu-id="d5941-186">Xvalue フラグだけをキャスト左辺右辺値の名前のない参照を作成しました。</span><span class="sxs-lookup"><span data-stu-id="d5941-186">We've just created an xvalue by casting an lvalue to an unnamed rvalue reference.</span></span> <span data-ttu-id="d5941-187">左辺名によっても識別できます。として、xvalue フラグ、ことが*できる*移動中のします。</span><span class="sxs-lookup"><span data-stu-id="d5941-187">It can still be identified by its lvalue name; but, as an xvalue, it is now *capable* of being moved.</span></span> <span data-ttu-id="d5941-188">これを行うためには、上の理由から、次のように、実際にどのような移動別のトピックを待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-188">The reasons for doing so, and what moving actually looks like, will have to wait for another topic.</span></span> <span data-ttu-id="d5941-189">ただし、意味"エキスパート専用として"するのに役立つ場合は、「xvalue フラグ」の"x"を考えることができます。</span><span class="sxs-lookup"><span data-stu-id="d5941-189">But you can think of the "x" in "xvalue" as meaning "expert-only" if that helps.</span></span> <span data-ttu-id="d5941-190">左辺をキャスト、xvalue フラグ (右辺値の種類) に、値は、右辺値参照にバインドされていることになります。</span><span class="sxs-lookup"><span data-stu-id="d5941-190">By casting an lvalue into an xvalue (a kind of rvalue), the value then becomes capable of being bound to an rvalue reference.</span></span>

<span data-ttu-id="d5941-191">ここでは、取得およびその他の 2 つの例&mdash;参照を指定する名前のない右辺値を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d5941-191">Here are two other examples of xvalues&mdash;calling a function that returns an unnamed rvalue reference, and accessing a member of an xvalue.</span></span>

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a><span data-ttu-id="d5941-192">prvalue (\!i\ & m)</span><span class="sxs-lookup"><span data-stu-id="d5941-192">prvalue (\!i\&m)</span></span>
<span data-ttu-id="d5941-193">(純粋な右辺値、右辺値の種類) の prvalue id ではありませんが、移動します。</span><span class="sxs-lookup"><span data-stu-id="d5941-193">A prvalue (pure rvalue; a kind of rvalue) doesn't have identity, but is movable.</span></span> <span data-ttu-id="d5941-194">これらは、一時領域では通常、関数の呼び出しの結果を返します。 値、または、glvalue でないその他の式を評価した結果によって</span><span class="sxs-lookup"><span data-stu-id="d5941-194">These are typically temporaries, the result of calling a function that returns by value, or the result of evaluating any other expression that's not a glvalue,</span></span>

### <a name="rvalue-m"></a><span data-ttu-id="d5941-195">右辺値 (分)</span><span class="sxs-lookup"><span data-stu-id="d5941-195">rvalue (m)</span></span>
<span data-ttu-id="d5941-196">右辺値が移動します。</span><span class="sxs-lookup"><span data-stu-id="d5941-196">An rvalue is movable.</span></span> <span data-ttu-id="d5941-197">右辺値*の参照*は、常に右辺値 (値と見なされます内容を維持する必要はありません) を参照します。</span><span class="sxs-lookup"><span data-stu-id="d5941-197">An rvalue *reference* always refers to an rvalue (a value whose contents it's assumed we don't need to preserve).</span></span>

<span data-ttu-id="d5941-198">ただし、右辺値を右辺値参照自体にはかどうか。</span><span class="sxs-lookup"><span data-stu-id="d5941-198">But, is an rvalue reference itself an rvalue?</span></span> <span data-ttu-id="d5941-199">(上記 xvalue フラグのコード例に示されている) のような*名前のない*の右辺値の参照が、xvalue フラグはいは、その右辺値。</span><span class="sxs-lookup"><span data-stu-id="d5941-199">An *unnamed* rvalue reference (like the ones shown in the xvalue code examples above) is an xvalue so, yes, it's an rvalue.</span></span> <span data-ttu-id="d5941-200">移動コンス トラクターのなど、右辺値の参照を関数パラメーターにバインドされていることを優先します。</span><span class="sxs-lookup"><span data-stu-id="d5941-200">It prefers to be bound to an rvalue reference function parameter, such as that of a move constructor.</span></span> <span data-ttu-id="d5941-201">逆に、おそらく counter-intuitively) 右辺値参照が、名前を持つ場合は、その名前で構成される式左辺します。</span><span class="sxs-lookup"><span data-stu-id="d5941-201">Conversely (and perhaps counter-intuitively), if an rvalue reference has a name, then the expression consisting of that name is an lvalue.</span></span> <span data-ttu-id="d5941-202">したがって、右辺値参照パラメーターにバインド*できません*。</span><span class="sxs-lookup"><span data-stu-id="d5941-202">So it *can't* be bound to an rvalue reference parameter.</span></span> <span data-ttu-id="d5941-203">簡単に行うことが&mdash;だけにキャスト右辺値の名前のないリファレンス (xvalue フラグ) もう一度します。</span><span class="sxs-lookup"><span data-stu-id="d5941-203">But it's easy to make it do so&mdash;just cast it to an unnamed rvalue reference (an xvalue) again.</span></span>

```cppwinrt
void foo(A&) { ... }
void foo(A&&) { ... }
void bar(A&& a) // a is a named rvalue reference; it's an lvalue.
{
    foo(a); // Calls foo(A&).
    foo(static_cast<A&&>(a)); // Calls foo(A&&).
}
A&& get_by_rvalue_ref() { ... } // This unnamed rvalue reference is an xvalue.
```

### <a name="im"></a><span data-ttu-id="d5941-204">\!i\ & \!m</span><span class="sxs-lookup"><span data-stu-id="d5941-204">\!i\&\!m</span></span>
<span data-ttu-id="d5941-205">識別していないし、移動がない値の種類には、まだ説明していない 1 つの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="d5941-205">The kind of value that doesn't have identity and isn't movable is the one combination that we haven't yet discussed.</span></span> <span data-ttu-id="d5941-206">ただし、そのカテゴリの C++ 言語で便利なアイデアがないため、無視します。</span><span class="sxs-lookup"><span data-stu-id="d5941-206">But we can disregard it, because that category isn't a useful idea in the C++ language.</span></span>

## <a name="reference-collapsing-rules"></a><span data-ttu-id="d5941-207">規則の参照を折りたたんだり</span><span class="sxs-lookup"><span data-stu-id="d5941-207">Reference-collapsing rules</span></span>
<span data-ttu-id="d5941-208">式 (参照を指定する左辺値への参照を左辺または右辺値リファレンスへの参照を右辺値) に複数の like 参照は 1 つ別アウトをキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="d5941-208">Multiple like references in an expression (an lvalue reference to an lvalue reference, or an rvalue reference to an rvalue reference) cancel one another out.</span></span>

- `A& &` <span data-ttu-id="d5941-209">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-209">collapses into `A&`.</span></span>
- `A&& &&` <span data-ttu-id="d5941-210">折りたたまれます`A&&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-210">collapses into `A&&`.</span></span>

<span data-ttu-id="d5941-211">数式で参照とは異なり、複数左辺参照に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="d5941-211">Multiple unlike references in an expression collapse to an lvalue reference.</span></span>

- `A& &&` <span data-ttu-id="d5941-212">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-212">collapses into `A&`.</span></span>
- `A&& &` <span data-ttu-id="d5941-213">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-213">collapses into `A&`.</span></span>

## <a name="forwarding-references"></a><span data-ttu-id="d5941-214">転送への参照</span><span class="sxs-lookup"><span data-stu-id="d5941-214">Forwarding references</span></span>
<span data-ttu-id="d5941-215">この最後のセクションでは、右辺値の参照は、既に述べた、*転送リファレンス*のさまざまな概念と対照的です。</span><span class="sxs-lookup"><span data-stu-id="d5941-215">This final section contrasts rvalue references, which we've already discussed, with the different concept of a *forwarding reference*.</span></span>

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` <span data-ttu-id="d5941-216">説明したように、参照を指定する右辺値です。</span><span class="sxs-lookup"><span data-stu-id="d5941-216">is an rvalue reference, as we've seen.</span></span> <span data-ttu-id="d5941-217">Const と揮発性は、右辺値への参照には適用されません。</span><span class="sxs-lookup"><span data-stu-id="d5941-217">Const and volatile don't apply to rvalue references.</span></span>
- `foo` <span data-ttu-id="d5941-218">type **A**の rvalue のみを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d5941-218">accepts only rvalues of type **A**.</span></span>
- <span data-ttu-id="d5941-219">理由右辺値の参照 (次のように`A&&`) が存在渡される一時的な (またはその他の右辺値) の場合に最適なオーバー ロードを作成するためです。</span><span class="sxs-lookup"><span data-stu-id="d5941-219">The reason rvalue references (such as `A&&`) exist is so that you can author an overload that's optimized for the case of a temporary (or other rvalue) being passed.</span></span>

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` <span data-ttu-id="d5941-220">*参照を転送*です。</span><span class="sxs-lookup"><span data-stu-id="d5941-220">is a *forwarding reference*.</span></span> <span data-ttu-id="d5941-221">渡すことによって`bar`、種類 **_Ty**は const/非 const 揮発性/非揮発性とは別である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d5941-221">Depending what you pass to `bar`, type **_Ty** could be const/non-const independently of volatile/non-volatile.</span></span>
- `bar` <span data-ttu-id="d5941-222">任意の左辺値または型 **_Ty**の右辺値を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="d5941-222">accepts any lvalue or rvalue of type **_Ty**.</span></span>
- <span data-ttu-id="d5941-223">転送参照になる左辺値を渡すと、 `_Ty& &&`、左辺値の参照を解除する`_Ty&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-223">Passing an lvalue causes the forwarding reference to become `_Ty& &&`, which collapses to the lvalue reference `_Ty&`.</span></span>
- <span data-ttu-id="d5941-224">転送参照になる右辺値を渡すと、 `_Ty&& &&`、右辺値の参照を解除する`_Ty&&`します。</span><span class="sxs-lookup"><span data-stu-id="d5941-224">Passing an rvalue causes the forwarding reference to become `_Ty&& &&`, which collapses to the rvalue reference `_Ty&&`.</span></span>
- <span data-ttu-id="d5941-225">参照を転送する理由 (次のように`_Ty&&`) が存在が*ない*の最適化が何を渡すには、それらと効率的かつ透過的に転送します。</span><span class="sxs-lookup"><span data-stu-id="d5941-225">The reason forwarding references (such as `_Ty&&`) exist is *not* for optimization, but to take what you pass to them and to forward it on transparently and efficiently.</span></span> <span data-ttu-id="d5941-226">転送の参照に書き込み、または調査と見つかる) ライブラリのコードである場合にのみ発生する可能性が高い&mdash;たとえば、コンス トラクターの引数を転送ファクトリ関数です。</span><span class="sxs-lookup"><span data-stu-id="d5941-226">You're likely to encounter a forwarding reference only if you write (or closely study) library code&mdash;for example, a factory function that forwards on constructor arguments.</span></span>

## <a name="sources"></a><span data-ttu-id="d5941-227">Sources</span><span class="sxs-lookup"><span data-stu-id="d5941-227">Sources</span></span>
* <span data-ttu-id="d5941-228">\[Stroustrup, 2013\] ある Stroustrup: C++ プログラミング言語、4 番目のエディション。</span><span class="sxs-lookup"><span data-stu-id="d5941-228">\[Stroustrup, 2013\] B. Stroustrup: The C++ Programming Language, Fourth Edition.</span></span> <span data-ttu-id="d5941-229">◆ センター。</span><span class="sxs-lookup"><span data-stu-id="d5941-229">Addison-Wesley.</span></span> <span data-ttu-id="d5941-230">2013 します。</span><span class="sxs-lookup"><span data-stu-id="d5941-230">2013.</span></span>
