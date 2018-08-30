---
author: stevewhims
description: このトピックでは、C++ での値のさまざまなカテゴリを説明します。 左辺値と rvalue の音が間違いがも他の種類があります。
title: 値のカテゴリとへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3119008"
---
# <a name="value-categories-and-references-to-them"></a><span data-ttu-id="af825-105">値のカテゴリとへの参照</span><span class="sxs-lookup"><span data-stu-id="af825-105">Value categories, and references to them</span></span>
<span data-ttu-id="af825-106">このトピックでは、C++ で存在する値 (と値への参照) のさまざまなカテゴリを説明します。</span><span class="sxs-lookup"><span data-stu-id="af825-106">This topic describes the various categories of values (and references to values) that exist in C++.</span></span> <span data-ttu-id="af825-107">*左辺値*と*rvalue*の音が間違いがいない、このトピックでは条件でそれらの考える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="af825-107">You will doubtless have heard of *lvalues* and *rvalues*, but you may not think of them in the terms that this topic presents.</span></span> <span data-ttu-id="af825-108">他の種類の値があります。</span><span class="sxs-lookup"><span data-stu-id="af825-108">And there are other kinds of values, too.</span></span>

<span data-ttu-id="af825-109">C++ ですべての式では、このトピックで説明されているカテゴリのいずれかに属している値が存在します。</span><span class="sxs-lookup"><span data-stu-id="af825-109">Every expression in C++ yields a value that belongs to one of the categories discussed in this topic.</span></span> <span data-ttu-id="af825-110">C++ 言語、その facilies、およびこれらの値のカテゴリとへの参照の適切な理解が要求されるルールの側面があります。</span><span class="sxs-lookup"><span data-stu-id="af825-110">There are aspects of the C++ language, its facilies, and rules, that demand a proper understanding of these value categories, and references to them.</span></span> <span data-ttu-id="af825-111">たとえば、値、値をコピー、値を移動し、もう 1 つの関数への値を転送のアドレスを実行します。</span><span class="sxs-lookup"><span data-stu-id="af825-111">For example, taking the address of a value, copying a value, moving a value, and forwarding a value on to another function.</span></span> <span data-ttu-id="af825-112">このトピックでは、すべての詳細、それらの側面に送られませんが、それらの単色の理解の基本情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="af825-112">This topic doesn't go into all of those aspects in depth, but it provides foundational information for a solid understanding of them.</span></span>

<span data-ttu-id="af825-113">このトピックでは、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。</span><span class="sxs-lookup"><span data-stu-id="af825-113">The info in this topic is framed in terms of Stroustrup's analysis of value categories by the two independent properties of identity and movability [Stroustrup, 2013].</span></span>

## <a name="an-lvalue-has-identity"></a><span data-ttu-id="af825-114">左辺が識別情報</span><span class="sxs-lookup"><span data-stu-id="af825-114">An lvalue has identity</span></span>
<span data-ttu-id="af825-115">*Id*の値に何を意味しますか。</span><span class="sxs-lookup"><span data-stu-id="af825-115">What does it mean for a value to have *identity*?</span></span> <span data-ttu-id="af825-116">値のメモリ アドレスがある (または実行できる) 場合、値がある識別し、安全に使用します。</span><span class="sxs-lookup"><span data-stu-id="af825-116">If you have (or you can take) the memory address of a value and use it safely, then the value has identity.</span></span> <span data-ttu-id="af825-117">これによりを行う比較を超える値の内容: id で区別またはと比較することができます。</span><span class="sxs-lookup"><span data-stu-id="af825-117">That way, you can do more than compare the contents of values: you can compare or distinguish them by identity.</span></span>

<span data-ttu-id="af825-118">*左辺*では、ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="af825-118">An *lvalue* has identity.</span></span> <span data-ttu-id="af825-119">これは、「左辺値」で"l"が「左」(と同様に、left-hand 側の割り当て) の省略形である履歴のみ関心のある問題ではできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="af825-119">It's now a matter of only historical interest that the "l" in "lvalue" is an abbreviation of "left" (as in, the left-hand-side of an assignment).</span></span> <span data-ttu-id="af825-120">C++ では、左辺値は、左*または*割り当ての右側に表示できます。</span><span class="sxs-lookup"><span data-stu-id="af825-120">In C++, an lvalue can appear on the left *or* on the right of an assignment.</span></span> <span data-ttu-id="af825-121">「左辺値」、"l"次に、しない実際に確認に役立つ理解し、は何かを定義します。</span><span class="sxs-lookup"><span data-stu-id="af825-121">The "l" in "lvalues", then, doesn't actually help you to comprehend nor define what they are.</span></span> <span data-ttu-id="af825-122">Id を持つ値は、操作が起きると呼ばれることを理解する場合にのみ必要があります。</span><span class="sxs-lookup"><span data-stu-id="af825-122">You need only to understand that what we call an lvalue is a value that has identity.</span></span>

<span data-ttu-id="af825-123">左辺値の式の例: 名前付き変数または定数です。または、関数の参照を返します。</span><span class="sxs-lookup"><span data-stu-id="af825-123">Examples of expressions that are lvalues include: a named variable or constant; or a function that returns a reference.</span></span> <span data-ttu-id="af825-124">左辺値では*ありません*が、数式の例: 一時的なです。または、値を返す関数。</span><span class="sxs-lookup"><span data-stu-id="af825-124">Examples of expressions that are *not* lvalues include: a temporary; or a function that returns by value.</span></span>

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

<span data-ttu-id="af825-125">次に、true を指定するステートメントですが、その左辺値は取得を行うため、id を持ちます。</span><span class="sxs-lookup"><span data-stu-id="af825-125">Now, while it's a true statement that lvalues have identity, so do xvalues.</span></span> <span data-ttu-id="af825-126">どのような*xvalue フラグ*は、このトピックで後にしましょう。</span><span class="sxs-lookup"><span data-stu-id="af825-126">We'll go more into what an *xvalue* is later in this topic.</span></span> <span data-ttu-id="af825-127">ここでは、だけにする、glvalue「左辺して汎用化」と呼ばれる値カテゴリであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="af825-127">For now, just be aware that there is a value category called glvalue, for "generalized lvalue".</span></span> <span data-ttu-id="af825-128">Glvalues のスーパー セットには、左辺値 (*古代左辺値*とも呼ばれます) と取得の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="af825-128">The superset of glvalues contains both lvalues (also known as *classical lvalues*) and xvalues.</span></span> <span data-ttu-id="af825-129">そのため、中「の id を持って左辺」true の場合、次の図に示すように、次の id の完全なセットが glvalues のセットを示します。</span><span class="sxs-lookup"><span data-stu-id="af825-129">So, while "an lvalue has identity" is true, the complete set of things that have identity is the set of glvalues, as shown in this illustration.</span></span>

![左辺が識別情報](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a><span data-ttu-id="af825-131">右辺値が移動します。左辺でないです。</span><span class="sxs-lookup"><span data-stu-id="af825-131">An rvalue is movable; an lvalue is not</span></span>
<span data-ttu-id="af825-132">ただし glvalues ではない値もあります。</span><span class="sxs-lookup"><span data-stu-id="af825-132">But there are values that are not glvalues.</span></span> <span data-ttu-id="af825-133">したがって、これには値がのメモリ アドレスを取得する*ことはできません*(またはを有効にすることに依存することはできません) があります。</span><span class="sxs-lookup"><span data-stu-id="af825-133">Consequently, there are values that you *can't* obtain a memory address for (or you can't rely on it to be valid).</span></span> <span data-ttu-id="af825-134">上記のコード例ではこのようないくつかの値を確認します。</span><span class="sxs-lookup"><span data-stu-id="af825-134">We saw some such values in the code example above.</span></span> <span data-ttu-id="af825-135">欠点が聞こえます。</span><span class="sxs-lookup"><span data-stu-id="af825-135">This sounds like a disadvantage.</span></span> <span data-ttu-id="af825-136">しますが実際の値の利点は、つまり (これはコストが安く一般) ことからの*移動*ではなく (これは一般に負荷の高い) からコピーできます。</span><span class="sxs-lookup"><span data-stu-id="af825-136">But in fact the advantage of a value like that is that you can *move* from it (which is generally cheap), rather than copy from it (which is generally expensive).</span></span> <span data-ttu-id="af825-137">値から移動すると、それが以前は存在しなくなったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="af825-137">Moving from a value means that it's no longer in the place it used to be.</span></span> <span data-ttu-id="af825-138">そのため、しようとするために使用する場所にアクセスする必要ことを回避します。</span><span class="sxs-lookup"><span data-stu-id="af825-138">So, trying to access it in the place it used to be is something to be avoided.</span></span> <span data-ttu-id="af825-139">タイミングと*方法*値は、このトピックの範囲外に移動するの説明。</span><span class="sxs-lookup"><span data-stu-id="af825-139">A discussion of when and *how* to move a value is out of scope for this topic.</span></span> <span data-ttu-id="af825-140">このトピックでは、だけを移動する値が*右辺値*(または*従来の右辺値*) と呼ばれることを知る必要があります。</span><span class="sxs-lookup"><span data-stu-id="af825-140">For this topic, we just need to know that a value that is movable is known as an *rvalue* (or *classical rvalue*).</span></span>

<span data-ttu-id="af825-141">「右辺値」の"r"では、「直接」(と同様に、右-hand 側の割り当て) の省略形です。</span><span class="sxs-lookup"><span data-stu-id="af825-141">The "r" in "rvalue" is an abbreviation of "right" (as in, the right-hand-side of an assignment).</span></span> <span data-ttu-id="af825-142">ただし、rvalue と割り当ての外部の rvalue への参照を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="af825-142">But you can use rvalues, and references to rvalues, outside of assignments.</span></span> <span data-ttu-id="af825-143">"Rvalue"の"r"に集中することを次はありません。</span><span class="sxs-lookup"><span data-stu-id="af825-143">The "r" in "rvalues", then, is not the thing to focus on.</span></span> <span data-ttu-id="af825-144">右辺値と呼ばれるが移動する値であることを理解する場合にのみ必要があります。</span><span class="sxs-lookup"><span data-stu-id="af825-144">You need only to understand that what we call an rvalue is a value that is movable.</span></span>

<span data-ttu-id="af825-145">次の図に示すように、左辺は逆に、移動はありません。</span><span class="sxs-lookup"><span data-stu-id="af825-145">An lvalue, conversely, isn't movable, as shown in this illustration.</span></span> <span data-ttu-id="af825-146">移動操作が起きる場合の*左辺*定義の対立するものし、非常に合理的左辺へのアクセスを続けることが想定されているコードの予期しない問題になります。</span><span class="sxs-lookup"><span data-stu-id="af825-146">An lvalue that moved would defy the definition of *lvalue*, and it would be an unexpected problem for code that very reasonably expected to be able to continue to access the lvalue.</span></span>

![右辺値が移動します。左辺でないです。](images/is-movable.png)

<span data-ttu-id="af825-148">左辺を移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="af825-148">You can't move an lvalue.</span></span> <span data-ttu-id="af825-149">あります*が*種類の移動することができます (の id を使って点のセット) glvalue&mdash;を行っていることがわかっている場合 (などへの移動後アクセスしないように注意してください)&mdash;、xvalue フラグです。</span><span class="sxs-lookup"><span data-stu-id="af825-149">But there *is* a kind of glvalue (the set of things with identity) that you can move&mdash;if you know what you're doing (including being careful not to access it after the move)&mdash;and that's the xvalue.</span></span> <span data-ttu-id="af825-150">この概念は、もう一度以下、値のカテゴリの全体像を見てときからしますされます。</span><span class="sxs-lookup"><span data-stu-id="af825-150">We'll revisit this idea one more time below, when we look at the complete picture of value categories.</span></span>

## <a name="rvalue-references-and-reference-binding-rules"></a><span data-ttu-id="af825-151">右辺値への参照と参照バインディング規則</span><span class="sxs-lookup"><span data-stu-id="af825-151">Rvalue references, and reference-binding rules</span></span>
<span data-ttu-id="af825-152">このセクションでは、右辺値への参照の構文について説明します。</span><span class="sxs-lookup"><span data-stu-id="af825-152">This section introduces the syntax for a reference to an rvalue.</span></span> <span data-ttu-id="af825-153">別のトピックに移動し、転送の大幅な処理を待機する必要がありますが、これらは右辺値への参照によって解決は問題。</span><span class="sxs-lookup"><span data-stu-id="af825-153">We'll have to wait for another topic to go into a substantial treatment of moving and forwarding, but those are problems that are solved by rvalue references.</span></span> <span data-ttu-id="af825-154">右辺値への参照を見ると、前に、まず必要がありますが明確になる`T&`&mdash;ことしますした旧されたを呼び出すだけ「参照」。</span><span class="sxs-lookup"><span data-stu-id="af825-154">Before we look at rvalue references, though, we first need to be clearer about `T&`&mdash;the thing we've formerly been calling just "a reference".</span></span> <span data-ttu-id="af825-155">実際には「左辺値 (非 const) の参照をする」は、値が参照のユーザーを書き込むことができます。</span><span class="sxs-lookup"><span data-stu-id="af825-155">It's really "an lvalue (non-const) reference", which refers to an value to which the user of the reference can write.</span></span>

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

<span data-ttu-id="af825-156">左辺参照は、右辺値ではなく、左辺値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="af825-156">An lvalue reference can bind to an lvalue, but not to an rvalue.</span></span>

<span data-ttu-id="af825-157">左辺 const 参照し、(`T const&`)、(たとえば、定数)*ことはできません*リファレンスのユーザーを記述するオブジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="af825-157">Then there are lvalue const references (`T const&`), which refer to objects to which the user of the reference *can't* write (for example, a constant).</span></span>

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

<span data-ttu-id="af825-158">左辺 const の参照は、左辺や右辺値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="af825-158">An lvalue const reference can bind to an lvalue or to an rvalue.</span></span>

<span data-ttu-id="af825-159">型の右辺値への参照の構文`T`として書き込まれる`T&&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-159">The syntax for a reference to an rvalue of type `T` is written as `T&&`.</span></span> <span data-ttu-id="af825-160">移動の値を右辺値の参照が参照&mdash;、値の内容をしないこと (たとえば、一時的な) を使ってきました後を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="af825-160">An rvalue reference refers to a movable value&mdash;an value whose contents we don't need to preserve after we've used it (for example, a temporary).</span></span> <span data-ttu-id="af825-161">ポイント全体以降はから移動する (変更できるため)、値にバインドされている右辺値参照では、`const`と`volatile`右辺値への参照に修飾子 (cv 修飾子のとも呼ばれます) は適用されません。</span><span class="sxs-lookup"><span data-stu-id="af825-161">Since the whole point is to move from (thereby modifying) the value bound to an rvalue reference, `const` and `volatile` qualifiers (also known as cv-qualifiers) don't apply to rvalue references.</span></span>

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

<span data-ttu-id="af825-162">右辺値の参照は、右辺値にバインドします。</span><span class="sxs-lookup"><span data-stu-id="af825-162">An rvalue reference binds to an rvalue.</span></span> <span data-ttu-id="af825-163">オーバー ロードの解像度、右辺値*方法によって*右辺値への参照よりも、左辺 const 参照にバインドされているという点で実際には。</span><span class="sxs-lookup"><span data-stu-id="af825-163">In fact, in terms of overload resolution, an rvalue *prefers* to be bound to an rvalue reference than to an lvalue const reference.</span></span> <span data-ttu-id="af825-164">右辺値の参照が左辺ように説明したように、右辺値の参照値を参照します (たとえば、移動コンス トラクターのパラメーター) を維持する必要はありませんを想定していますの内容があるためにバインドできません。</span><span class="sxs-lookup"><span data-stu-id="af825-164">But an rvalue reference can't bind to an lvalue because, as we've said, an rvalue reference refers to a value whose contents it's assumed we don't need to preserve (say, the parameter for a move constructor).</span></span>

<span data-ttu-id="af825-165">渡すことも右辺値引数の値では、予期されているところコピー コンス トラクターを介して (または、右辺値が、xvalue フラグである場合は、ムーブ構築)。</span><span class="sxs-lookup"><span data-stu-id="af825-165">You can also pass an rvalue where a by-value argument is expected, via copy construction (or via move construction, if the rvalue is an xvalue).</span></span>

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a><span data-ttu-id="af825-166">Glvalue がの id。prvalue は発生しません。</span><span class="sxs-lookup"><span data-stu-id="af825-166">A glvalue has identity; a prvalue does not</span></span>
<span data-ttu-id="af825-167">この段階では、ユーザーが何がわかっています。</span><span class="sxs-lookup"><span data-stu-id="af825-167">At this stage, we know what has identity.</span></span> <span data-ttu-id="af825-168">移動とそうでないことが確認されます。</span><span class="sxs-lookup"><span data-stu-id="af825-168">And we know what's movable and what isn't.</span></span> <span data-ttu-id="af825-169">まだおまだ id を持つ*しない*という名前の値のセット。</span><span class="sxs-lookup"><span data-stu-id="af825-169">But we haven't yet named the set of values that *don't* have identity.</span></span> <span data-ttu-id="af825-170">そのセットは、 *prvalue*、または*純粋な右辺値*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="af825-170">That set is known as the *prvalue*, or *pure rvalue*.</span></span>

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺がの id。prvalue は発生しません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a><span data-ttu-id="af825-172">値のカテゴリの完全な画像</span><span class="sxs-lookup"><span data-stu-id="af825-172">The complete picture of value categories</span></span>
<span data-ttu-id="af825-173">情報と上の図に、1 つの大きな画像を組み合わせるのみは変わりません。</span><span class="sxs-lookup"><span data-stu-id="af825-173">It only remains to combine the info and illustrations above into a single, big picture.</span></span>

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a><span data-ttu-id="af825-175">glvalue (i)</span><span class="sxs-lookup"><span data-stu-id="af825-175">glvalue (i)</span></span>
<span data-ttu-id="af825-176">Glvalue (汎用左辺) では、ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="af825-176">A glvalue (generalized lvalue) has identity.</span></span>

### <a name="lvalue-im"></a><span data-ttu-id="af825-177">左辺値 (i\ & \!m)</span><span class="sxs-lookup"><span data-stu-id="af825-177">lvalue (i\&\!m)</span></span>
<span data-ttu-id="af825-178">左辺 (glvalue の種類) では、id しますが、移動はありません。</span><span class="sxs-lookup"><span data-stu-id="af825-178">An lvalue (a kind of glvalue) has identity, but isn't movable.</span></span> <span data-ttu-id="af825-179">これらは、通常の読み取り/書き込み値を渡して周囲参照または const 参照、または値のコピーが低い場合です。</span><span class="sxs-lookup"><span data-stu-id="af825-179">These are typically read-write values that you pass around by reference or by const reference, or by value if copying is cheap.</span></span> <span data-ttu-id="af825-180">右辺値参照に左辺をバインドすることはできません。</span><span class="sxs-lookup"><span data-stu-id="af825-180">An lvalue can't be bound to an rvalue reference.</span></span>

### <a name="xvalue-im"></a><span data-ttu-id="af825-181">xvalue フラグ (i\ & m)</span><span class="sxs-lookup"><span data-stu-id="af825-181">xvalue (i\&m)</span></span>
<span data-ttu-id="af825-182">(Glvalue の一種でも、種類の右辺値)、xvalue フラグ id がありも移動します。</span><span class="sxs-lookup"><span data-stu-id="af825-182">An xvalue (a kind of glvalue, but also a kind of rvalue) has identity, and is also movable.</span></span> <span data-ttu-id="af825-183">これにコピーは、コストがかかるために、移動させるをされる操作が起きる可能性があり、後でアクセスすることをしないように注意することができます。</span><span class="sxs-lookup"><span data-stu-id="af825-183">This might be an erstwhile lvalue that you've decided to move because copying is expensive, and you'll be careful not to access it afterward.</span></span> <span data-ttu-id="af825-184">以下に、xvalue フラグに左辺を有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="af825-184">Here's how you can turn an lvalue into an xvalue.</span></span>

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

<span data-ttu-id="af825-185">上記のコード例で移動していない何もまだします。</span><span class="sxs-lookup"><span data-stu-id="af825-185">In the code example above, we haven't moved anything yet.</span></span> <span data-ttu-id="af825-186">Xvalue フラグだけをキャスト左辺、名前のない右辺値の参照を作成しました。</span><span class="sxs-lookup"><span data-stu-id="af825-186">We've just created an xvalue by casting an lvalue to an unnamed rvalue reference.</span></span> <span data-ttu-id="af825-187">まだその左辺値の名前で識別できます。として、xvalue フラグ、することが*できる*移動しています。</span><span class="sxs-lookup"><span data-stu-id="af825-187">It can still be identified by its lvalue name; but, as an xvalue, it is now *capable* of being moved.</span></span> <span data-ttu-id="af825-188">これを行うためには、上の理由から、別のトピックを待機するが、実際にはどのような移動します。</span><span class="sxs-lookup"><span data-stu-id="af825-188">The reasons for doing so, and what moving actually looks like, will have to wait for another topic.</span></span> <span data-ttu-id="af825-189">ただし、"x"「xvalue フラグ」意味「エキスパートのみ」するのに役立つ場合として考えることができます。</span><span class="sxs-lookup"><span data-stu-id="af825-189">But you can think of the "x" in "xvalue" as meaning "expert-only" if that helps.</span></span> <span data-ttu-id="af825-190">左辺をキャスト、xvalue フラグ (右辺値の種類) に、値になります右辺値参照にバインドされていること。</span><span class="sxs-lookup"><span data-stu-id="af825-190">By casting an lvalue into an xvalue (a kind of rvalue), the value then becomes capable of being bound to an rvalue reference.</span></span>

<span data-ttu-id="af825-191">ここでは、取得の他の 2 つの例&mdash;、名前のない右辺値参照を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="af825-191">Here are two other examples of xvalues&mdash;calling a function that returns an unnamed rvalue reference, and accessing a member of an xvalue.</span></span>

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a><span data-ttu-id="af825-192">prvalue (\!i\ & m)</span><span class="sxs-lookup"><span data-stu-id="af825-192">prvalue (\!i\&m)</span></span>
<span data-ttu-id="af825-193">(純粋な右辺値、右辺値の種類) の prvalue id ではありませんが、移動します。</span><span class="sxs-lookup"><span data-stu-id="af825-193">A prvalue (pure rvalue; a kind of rvalue) doesn't have identity, but is movable.</span></span> <span data-ttu-id="af825-194">これらは、一時領域では通常、関数の呼び出しの結果を返します。 値、または、glvalue でないその他の式を評価した結果によって</span><span class="sxs-lookup"><span data-stu-id="af825-194">These are typically temporaries, the result of calling a function that returns by value, or the result of evaluating any other expression that's not a glvalue,</span></span>

### <a name="rvalue-m"></a><span data-ttu-id="af825-195">右辺値 (分)</span><span class="sxs-lookup"><span data-stu-id="af825-195">rvalue (m)</span></span>
<span data-ttu-id="af825-196">右辺値が移動します。</span><span class="sxs-lookup"><span data-stu-id="af825-196">An rvalue is movable.</span></span> <span data-ttu-id="af825-197">右辺値*の参照*は、常に右辺値 (値を想定しています内容を維持する必要はありません) を参照します。</span><span class="sxs-lookup"><span data-stu-id="af825-197">An rvalue *reference* always refers to an rvalue (a value whose contents it's assumed we don't need to preserve).</span></span>

<span data-ttu-id="af825-198">ただし、右辺値は、参照です自体右辺値かどうか。</span><span class="sxs-lookup"><span data-stu-id="af825-198">But, is an rvalue reference itself an rvalue?</span></span> <span data-ttu-id="af825-199">(上記 xvalue フラグのコード例に示すもの) のような*名前のない*の右辺値の参照が、xvalue フラグはいは、その右辺値。</span><span class="sxs-lookup"><span data-stu-id="af825-199">An *unnamed* rvalue reference (like the ones shown in the xvalue code examples above) is an xvalue so, yes, it's an rvalue.</span></span> <span data-ttu-id="af825-200">移動コンス トラクターのなど、右辺値の参照関数パラメーターにバインドされていることを優先します。</span><span class="sxs-lookup"><span data-stu-id="af825-200">It prefers to be bound to an rvalue reference function parameter, such as that of a move constructor.</span></span> <span data-ttu-id="af825-201">逆に、おそらく counter-intuitively) かどうか、右辺値の参照が、名前は、その名前で構成される式左辺します。</span><span class="sxs-lookup"><span data-stu-id="af825-201">Conversely (and perhaps counter-intuitively), if an rvalue reference has a name, then the expression consisting of that name is an lvalue.</span></span> <span data-ttu-id="af825-202">したがって、右辺値の参照パラメーターにバインドする*ことはできません*。</span><span class="sxs-lookup"><span data-stu-id="af825-202">So it *can't* be bound to an rvalue reference parameter.</span></span> <span data-ttu-id="af825-203">簡単に操作を行うことが&mdash;だけもう一度キャスト右辺値の名前のない参照 (xvalue フラグ)。</span><span class="sxs-lookup"><span data-stu-id="af825-203">But it's easy to make it do so&mdash;just cast it to an unnamed rvalue reference (an xvalue) again.</span></span>

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

### <a name="im"></a><span data-ttu-id="af825-204">\!i\ & \!m</span><span class="sxs-lookup"><span data-stu-id="af825-204">\!i\&\!m</span></span>
<span data-ttu-id="af825-205">Id がないし、移動がない値の種類は、まだ説明していない 1 つの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="af825-205">The kind of value that doesn't have identity and isn't movable is the one combination that we haven't yet discussed.</span></span> <span data-ttu-id="af825-206">ただし、そのカテゴリは、C++ 言語で便利なアイデアはないため、無視します。</span><span class="sxs-lookup"><span data-stu-id="af825-206">But we can disregard it, because that category isn't a useful idea in the C++ language.</span></span>

## <a name="reference-collapsing-rules"></a><span data-ttu-id="af825-207">規則の参照を折りたたんだり</span><span class="sxs-lookup"><span data-stu-id="af825-207">Reference-collapsing rules</span></span>
<span data-ttu-id="af825-208">式 (、左辺値への参照の左辺参照するか、右辺値への参照を右辺値の参照) で複数の like 参照では、別の出力を 1 つキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="af825-208">Multiple like references in an expression (an lvalue reference to an lvalue reference, or an rvalue reference to an rvalue reference) cancel one another out.</span></span>

- `A& &` <span data-ttu-id="af825-209">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-209">collapses into `A&`.</span></span>
- `A&& &&` <span data-ttu-id="af825-210">折りたたまれます`A&&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-210">collapses into `A&&`.</span></span>

<span data-ttu-id="af825-211">数式で参照とは異なり、複数の左辺参照に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="af825-211">Multiple unlike references in an expression collapse to an lvalue reference.</span></span>

- `A& &&` <span data-ttu-id="af825-212">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-212">collapses into `A&`.</span></span>
- `A&& &` <span data-ttu-id="af825-213">折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-213">collapses into `A&`.</span></span>

## <a name="forwarding-references"></a><span data-ttu-id="af825-214">転送への参照</span><span class="sxs-lookup"><span data-stu-id="af825-214">Forwarding references</span></span>
<span data-ttu-id="af825-215">この最後のセクションでは、右辺値の参照は、既に述べた、*参照を転送*のさまざまな概念と対照的です。</span><span class="sxs-lookup"><span data-stu-id="af825-215">This final section contrasts rvalue references, which we've already discussed, with the different concept of a *forwarding reference*.</span></span>

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` <span data-ttu-id="af825-216">説明した、右辺値参照です。</span><span class="sxs-lookup"><span data-stu-id="af825-216">is an rvalue reference, as we've seen.</span></span> <span data-ttu-id="af825-217">Const と揮発性は、右辺値への参照には適用されません。</span><span class="sxs-lookup"><span data-stu-id="af825-217">Const and volatile don't apply to rvalue references.</span></span>
- `foo` <span data-ttu-id="af825-218">**A**の種類の rvalue のみを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="af825-218">accepts only rvalues of type **A**.</span></span>
- <span data-ttu-id="af825-219">理由右辺値の参照 (よう`A&&`) が存在はオーバー ロードが渡される一時的な (またはその他の右辺値) の大文字と小文字が最適化を作成するためです。</span><span class="sxs-lookup"><span data-stu-id="af825-219">The reason rvalue references (such as `A&&`) exist is so that you can author an overload that's optimized for the case of a temporary (or other rvalue) being passed.</span></span>

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` <span data-ttu-id="af825-220">*転送リファレンス*です。</span><span class="sxs-lookup"><span data-stu-id="af825-220">is a *forwarding reference*.</span></span> <span data-ttu-id="af825-221">渡すことによって`bar`、種類 **_Ty**が const/非 const 揮発性/非揮発性とは別にすることができます。</span><span class="sxs-lookup"><span data-stu-id="af825-221">Depending what you pass to `bar`, type **_Ty** could be const/non-const independently of volatile/non-volatile.</span></span>
- `bar` <span data-ttu-id="af825-222">任意の左辺値または型 **_Ty**の右辺の値を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="af825-222">accepts any lvalue or rvalue of type **_Ty**.</span></span>
- <span data-ttu-id="af825-223">転送の参照になる左辺に渡すと、 `_Ty& &&`、左辺値のリファレンスを縮小する`_Ty&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-223">Passing an lvalue causes the forwarding reference to become `_Ty& &&`, which collapses to the lvalue reference `_Ty&`.</span></span>
- <span data-ttu-id="af825-224">転送の参照になる右辺値に渡すと、 `_Ty&& &&`、右辺値のリファレンスを縮小する`_Ty&&`します。</span><span class="sxs-lookup"><span data-stu-id="af825-224">Passing an rvalue causes the forwarding reference to become `_Ty&& &&`, which collapses to the rvalue reference `_Ty&&`.</span></span>
- <span data-ttu-id="af825-225">参照を転送する理由 (よう`_Ty&&`) が存在が*ない*の最適化が何を渡すには、それらを実行して効率的かつ透過的に転送します。</span><span class="sxs-lookup"><span data-stu-id="af825-225">The reason forwarding references (such as `_Ty&&`) exist is *not* for optimization, but to take what you pass to them and to forward it on transparently and efficiently.</span></span> <span data-ttu-id="af825-226">転送の参照を書き込み、または調査と見つかる) ライブラリのコードである場合にのみ発生する可能性が高い&mdash;など、コンス トラクターの引数を転送するファクトリ関数。</span><span class="sxs-lookup"><span data-stu-id="af825-226">You're likely to encounter a forwarding reference only if you write (or closely study) library code&mdash;for example, a factory function that forwards on constructor arguments.</span></span>

## <a name="sources"></a><span data-ttu-id="af825-227">Sources</span><span class="sxs-lookup"><span data-stu-id="af825-227">Sources</span></span>
* <span data-ttu-id="af825-228">\[Stroustrup, 2013\] ある Stroustrup: C++ プログラミング言語、4 番目のエディション。</span><span class="sxs-lookup"><span data-stu-id="af825-228">\[Stroustrup, 2013\] B. Stroustrup: The C++ Programming Language, Fourth Edition.</span></span> <span data-ttu-id="af825-229">◆ センター。</span><span class="sxs-lookup"><span data-stu-id="af825-229">Addison-Wesley.</span></span> <span data-ttu-id="af825-230">2013 します。</span><span class="sxs-lookup"><span data-stu-id="af825-230">2013.</span></span>
