---
description: このトピックでは、C++ に存在する値のさまざまなカテゴリについて説明します。 Lvalues と rvalues の音が既にご承知されますが、その他の種類をすぎますがあります。
title: 値のカテゴリ、およびそれらへの参照
ms.date: 08/11/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺値、右辺値、glvalue、prvalue、xvalue
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1860f562233ceefa6d9ebb3741378b3265b4c3a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593017"
---
# <a name="value-categories-and-references-to-them"></a><span data-ttu-id="cfd53-105">値のカテゴリ、およびそれらへの参照</span><span class="sxs-lookup"><span data-stu-id="cfd53-105">Value categories, and references to them</span></span>
<span data-ttu-id="cfd53-106">このトピックでは、C++ に存在する値 (および値への参照) のさまざまなカテゴリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-106">This topic describes the various categories of values (and references to values) that exist in C++.</span></span> <span data-ttu-id="cfd53-107">音が悪くなります*左辺値*と*rvalue*、このトピックで条件のうちいない考えが。</span><span class="sxs-lookup"><span data-stu-id="cfd53-107">You will doubtless have heard of *lvalues* and *rvalues*, but you may not think of them in the terms that this topic presents.</span></span> <span data-ttu-id="cfd53-108">すぎるは、値の他の種類があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-108">And there are other kinds of values, too.</span></span>

<span data-ttu-id="cfd53-109">C++ では、すべての式では、このトピックで説明したカテゴリのいずれかに属している値を生成します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-109">Every expression in C++ yields a value that belongs to one of the categories discussed in this topic.</span></span> <span data-ttu-id="cfd53-110">C++ 言語、その facilies、およびこれらの値のカテゴリ、およびそれらへの参照の適切な理解を必要とするルールの側面があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-110">There are aspects of the C++ language, its facilies, and rules, that demand a proper understanding of these value categories, and references to them.</span></span> <span data-ttu-id="cfd53-111">たとえば、値、値をコピーする、値の移動、および別の関数に値を転送のアドレスを取得します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-111">For example, taking the address of a value, copying a value, moving a value, and forwarding a value on to another function.</span></span> <span data-ttu-id="cfd53-112">このトピックでは、すべての防御、これらの側面に移動しないが、それらの理解の基本的な情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-112">This topic doesn't go into all of those aspects in depth, but it provides foundational information for a solid understanding of them.</span></span>

<span data-ttu-id="cfd53-113">このトピックの情報は、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。</span><span class="sxs-lookup"><span data-stu-id="cfd53-113">The info in this topic is framed in terms of Stroustrup's analysis of value categories by the two independent properties of identity and movability [Stroustrup, 2013].</span></span>

## <a name="an-lvalue-has-identity"></a><span data-ttu-id="cfd53-114">左辺値は id を持っています</span><span class="sxs-lookup"><span data-stu-id="cfd53-114">An lvalue has identity</span></span>
<span data-ttu-id="cfd53-115">これはどういうの値に*identity*でしょうか。</span><span class="sxs-lookup"><span data-stu-id="cfd53-115">What does it mean for a value to have *identity*?</span></span> <span data-ttu-id="cfd53-116">値のメモリ アドレスがある (またはを実行できます) し、値がある識別し、安全に使用します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-116">If you have (or you can take) the memory address of a value and use it safely, then the value has identity.</span></span> <span data-ttu-id="cfd53-117">これにより、行うことができます比較より値の内容: 比較または id によって区別できます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-117">That way, you can do more than compare the contents of values: you can compare or distinguish them by identity.</span></span>

<span data-ttu-id="cfd53-118">*左辺値*id を持ちます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-118">An *lvalue* has identity.</span></span> <span data-ttu-id="cfd53-119">今すぐ「左辺値」の"l"は、(ように、左側の hand 側を代入式の)、"left"の省略形を履歴にのみ関心のある問題です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-119">It's now a matter of only historical interest that the "l" in "lvalue" is an abbreviation of "left" (as in, the left-hand-side of an assignment).</span></span> <span data-ttu-id="cfd53-120">C++ では、左辺値が左側に表示できる*または*を代入式の右側にします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-120">In C++, an lvalue can appear on the left *or* on the right of an assignment.</span></span> <span data-ttu-id="cfd53-121">「左辺値」の"l"し、実際に問題が解決しない理解もは何かを定義します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-121">The "l" in "lvalues", then, doesn't actually help you to comprehend nor define what they are.</span></span> <span data-ttu-id="cfd53-122">Id を持つ値が左辺値と呼ばれるものであるかを理解するだけを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-122">You need only to understand that what we call an lvalue is a value that has identity.</span></span>

<span data-ttu-id="cfd53-123">左辺値である式の例に示します: 名前付きの変数または定数。または、参照を返す関数。</span><span class="sxs-lookup"><span data-stu-id="cfd53-123">Examples of expressions that are lvalues include: a named variable or constant; or a function that returns a reference.</span></span> <span data-ttu-id="cfd53-124">式の例*いない*左辺値が含まれます: 一時的な; または値を返す関数。</span><span class="sxs-lookup"><span data-stu-id="cfd53-124">Examples of expressions that are *not* lvalues include: a temporary; or a function that returns by value.</span></span>

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

<span data-ttu-id="cfd53-125">ここで、左辺値が id を持っている場合は true。 ステートメントは、xvalues はそのためです。</span><span class="sxs-lookup"><span data-stu-id="cfd53-125">Now, while it's a true statement that lvalues have identity, so do xvalues.</span></span> <span data-ttu-id="cfd53-126">他にどのようなことにしましょう、 *xvalue*はこのトピックで後述します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-126">We'll go more into what an *xvalue* is later in this topic.</span></span> <span data-ttu-id="cfd53-127">ここでは、単に「左辺値を汎用化」の glvalue と呼ばれる値のカテゴリがあることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="cfd53-127">For now, just be aware that there is a value category called glvalue, for "generalized lvalue".</span></span> <span data-ttu-id="cfd53-128">Glvalues のスーパー セットには、両方とも左辺値が含まれています (とも呼ばれます*古典左辺値*) と xvalues します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-128">The superset of glvalues contains both lvalues (also known as *classical lvalues*) and xvalues.</span></span> <span data-ttu-id="cfd53-129">そのため、while true「を左辺値は、id を持って」は、この図のように、id を持つことの完全なセットが、glvalues のセット。</span><span class="sxs-lookup"><span data-stu-id="cfd53-129">So, while "an lvalue has identity" is true, the complete set of things that have identity is the set of glvalues, as shown in this illustration.</span></span>

![左辺値は id を持っています](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a><span data-ttu-id="cfd53-131">右辺値は移動可能です。左辺値はありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-131">An rvalue is movable; an lvalue is not</span></span>
<span data-ttu-id="cfd53-132">Glvalues ではない値があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-132">But there are values that are not glvalues.</span></span> <span data-ttu-id="cfd53-133">したがって、ある値を*できません*のメモリ アドレスを取得する (またはそれを有効にするのに依存することはできません)。</span><span class="sxs-lookup"><span data-stu-id="cfd53-133">Consequently, there are values that you *can't* obtain a memory address for (or you can't rely on it to be valid).</span></span> <span data-ttu-id="cfd53-134">上記のコード例ではこのようないくつかの値を見ました。</span><span class="sxs-lookup"><span data-stu-id="cfd53-134">We saw some such values in the code example above.</span></span> <span data-ttu-id="cfd53-135">欠点が聞こえます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-135">This sounds like a disadvantage.</span></span> <span data-ttu-id="cfd53-136">実際値の利点などができますが、*移動*から (これは一般的に安価な) ことではなく (これは通常高価な) からコピーします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-136">But in fact the advantage of a value like that is that you can *move* from it (which is generally cheap), rather than copy from it (which is generally expensive).</span></span> <span data-ttu-id="cfd53-137">値からの移行は場所に配置するために使用されなくを意味します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-137">Moving from a value means that it's no longer in the place it used to be.</span></span> <span data-ttu-id="cfd53-138">そのため、使用場所にアクセスしようとしています。 は回避されます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-138">So, trying to access it in the place it used to be is something to be avoided.</span></span> <span data-ttu-id="cfd53-139">タイミングの詳細については、*方法*値は、このトピックではスコープ外に移動します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-139">A discussion of when and *how* to move a value is out of scope for this topic.</span></span> <span data-ttu-id="cfd53-140">このトピックでは、だけが移動可能な値と呼ばれることを知って、*右辺値*(または*古典 rvalue*)。</span><span class="sxs-lookup"><span data-stu-id="cfd53-140">For this topic, we just need to know that a value that is movable is known as an *rvalue* (or *classical rvalue*).</span></span>

<span data-ttu-id="cfd53-141">「右辺値」で"r"は、(ように、右、hand 側を代入式の)、"right"の省略形です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-141">The "r" in "rvalue" is an abbreviation of "right" (as in, the right-hand-side of an assignment).</span></span> <span data-ttu-id="cfd53-142">ただし、右辺値、および割り当ての外部で、右辺値への参照を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-142">But you can use rvalues, and references to rvalues, outside of assignments.</span></span> <span data-ttu-id="cfd53-143">「右辺値」で"r"に注目することはありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-143">The "r" in "rvalues", then, is not the thing to focus on.</span></span> <span data-ttu-id="cfd53-144">右辺値と呼ばれるものが移動可能である値であることを理解するだけを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-144">You need only to understand that what we call an rvalue is a value that is movable.</span></span>

<span data-ttu-id="cfd53-145">この図のように、左辺値には逆に、移動可能なはありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-145">An lvalue, conversely, isn't movable, as shown in this illustration.</span></span> <span data-ttu-id="cfd53-146">移動を左辺値の定義を無視は*左辺値*、引き続き、左辺値にアクセスすることができる非常に期待されるコードの予期しない問題があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-146">An lvalue that moved would defy the definition of *lvalue*, and it would be an unexpected problem for code that very reasonably expected to be able to continue to access the lvalue.</span></span>

![右辺値は移動可能です。左辺値はありません。](images/is-movable.png)

<span data-ttu-id="cfd53-148">左辺の値を移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-148">You can't move an lvalue.</span></span> <span data-ttu-id="cfd53-149">あります*は*移動できる glvalue (一連の id を持つもの) の一種&mdash;何をしていることがわかっている場合 (移動後にアクセスしないように注意するを含む)&mdash;xvalue です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-149">But there *is* a kind of glvalue (the set of things with identity) that you can move&mdash;if you know what you're doing (including being careful not to access it after the move)&mdash;and that's the xvalue.</span></span> <span data-ttu-id="cfd53-150">このアイデアをもう 1 回、下の値のカテゴリの全体像に注目すると再度使用します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-150">We'll revisit this idea one more time below, when we look at the complete picture of value categories.</span></span>

## <a name="rvalue-references-and-reference-binding-rules"></a><span data-ttu-id="cfd53-151">右辺値参照、および参照バインディング規則</span><span class="sxs-lookup"><span data-stu-id="cfd53-151">Rvalue references, and reference-binding rules</span></span>
<span data-ttu-id="cfd53-152">このセクションでは、rvalue への参照の構文について説明します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-152">This section introduces the syntax for a reference to an rvalue.</span></span> <span data-ttu-id="cfd53-153">私たちは別のトピックに移動し、転送の大幅な処理を待機する必要がありますは右辺値参照を解決できる問題。</span><span class="sxs-lookup"><span data-stu-id="cfd53-153">We'll have to wait for another topic to go into a substantial treatment of moving and forwarding, but those are problems that are solved by rvalue references.</span></span> <span data-ttu-id="cfd53-154">右辺値参照を見ると、前に、まず必要があります明確になる`T&`&mdash;ことした以前されて呼び出しだけ「参照」。</span><span class="sxs-lookup"><span data-stu-id="cfd53-154">Before we look at rvalue references, though, we first need to be clearer about `T&`&mdash;the thing we've formerly been calling just "a reference".</span></span> <span data-ttu-id="cfd53-155">本当に"を (非定数) を左辺値参照されて"、これは、値を参照のユーザーが書き込むことができます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-155">It's really "an lvalue (non-const) reference", which refers to an value to which the user of the reference can write.</span></span>

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

<span data-ttu-id="cfd53-156">左辺値参照は、右辺値ではなくに左辺値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-156">An lvalue reference can bind to an lvalue, but not to an rvalue.</span></span>

<span data-ttu-id="cfd53-157">左辺値の const 参照が存在し、(`T const&`)、参照先オブジェクトに参照のユーザー*ことはできません*書き込み (たとえば、定数)。</span><span class="sxs-lookup"><span data-stu-id="cfd53-157">Then there are lvalue const references (`T const&`), which refer to objects to which the user of the reference *can't* write (for example, a constant).</span></span>

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

<span data-ttu-id="cfd53-158">Const の左辺値参照には、左辺値または右辺値をバインドできます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-158">An lvalue const reference can bind to an lvalue or to an rvalue.</span></span>

<span data-ttu-id="cfd53-159">型の rvalue への参照の構文は、`T`として書き込まれる`T&&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-159">The syntax for a reference to an rvalue of type `T` is written as `T&&`.</span></span> <span data-ttu-id="cfd53-160">移動可能な値を右辺値参照が参照&mdash;値を内容を後に使用した (たとえば、一時的な) を保持する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-160">An rvalue reference refers to a movable value&mdash;an value whose contents we don't need to preserve after we've used it (for example, a temporary).</span></span> <span data-ttu-id="cfd53-161">全体のポイント以降から移動する (これにより変更)、値にバインドされて、右辺値参照`const`と`volatile`修飾子 (cv 修飾子のとも呼ばれます) は、右辺値参照に適用されません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-161">Since the whole point is to move from (thereby modifying) the value bound to an rvalue reference, `const` and `volatile` qualifiers (also known as cv-qualifiers) don't apply to rvalue references.</span></span>

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

<span data-ttu-id="cfd53-162">右辺値参照は、右辺値にバインドします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-162">An rvalue reference binds to an rvalue.</span></span> <span data-ttu-id="cfd53-163">オーバー ロードの解決、右辺値の観点から実際には、*希望*より const の左辺値参照への右辺値参照にバインドします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-163">In fact, in terms of overload resolution, an rvalue *prefers* to be bound to an rvalue reference than to an lvalue const reference.</span></span> <span data-ttu-id="cfd53-164">参照しているため、ように、右辺値参照の値には (たとえば、移動コンス トラクターのパラメーター) を保持するために不要と見なされますの内容が、右辺値参照が左辺値にバインドできません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-164">But an rvalue reference can't bind to an lvalue because, as we've said, an rvalue reference refers to a value whose contents it's assumed we don't need to preserve (say, the parameter for a move constructor).</span></span>

<span data-ttu-id="cfd53-165">渡すこともできます右辺値渡しで引数が必要な場合、コピー コンス トラクターを使用して (または移動の構築、右辺値が、xvalue 場合)。</span><span class="sxs-lookup"><span data-stu-id="cfd53-165">You can also pass an rvalue where a by-value argument is expected, via copy construction (or via move construction, if the rvalue is an xvalue).</span></span>

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a><span data-ttu-id="cfd53-166">Glvalue が identity です。prvalue はありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-166">A glvalue has identity; a prvalue does not</span></span>
<span data-ttu-id="cfd53-167">この段階では、id を持って何がわかっています。</span><span class="sxs-lookup"><span data-stu-id="cfd53-167">At this stage, we know what has identity.</span></span> <span data-ttu-id="cfd53-168">移動可能な新機能とサポートされない内容がわかります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-168">And we know what's movable and what isn't.</span></span> <span data-ttu-id="cfd53-169">いないまだという名前の値のセットですが、*しない*id が存在します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-169">But we haven't yet named the set of values that *don't* have identity.</span></span> <span data-ttu-id="cfd53-170">セットと呼ばれること、 *prvalue*、または*純粋な右辺値*します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-170">That set is known as the *prvalue*, or *pure rvalue*.</span></span>

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺が identity です。prvalue はありません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a><span data-ttu-id="cfd53-172">値のカテゴリの全体像</span><span class="sxs-lookup"><span data-stu-id="cfd53-172">The complete picture of value categories</span></span>
<span data-ttu-id="cfd53-173">情報と、1 つの大きな画像に上記の図を結合するだけのままです。</span><span class="sxs-lookup"><span data-stu-id="cfd53-173">It only remains to combine the info and illustrations above into a single, big picture.</span></span>

![値のカテゴリの全体像](images/value-categories.png)

### <a name="glvalue-i"></a><span data-ttu-id="cfd53-175">glvalue (i)</span><span class="sxs-lookup"><span data-stu-id="cfd53-175">glvalue (i)</span></span>
<span data-ttu-id="cfd53-176">Glvalue (一般的な左辺値) は、id を持ちます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-176">A glvalue (generalized lvalue) has identity.</span></span>

### <a name="lvalue-im"></a><span data-ttu-id="cfd53-177">左辺値 (は\&\!m)</span><span class="sxs-lookup"><span data-stu-id="cfd53-177">lvalue (i\&\!m)</span></span>
<span data-ttu-id="cfd53-178">左辺値 (glvalue の種類) は id を持つが、移動することはありません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-178">An lvalue (a kind of glvalue) has identity, but isn't movable.</span></span> <span data-ttu-id="cfd53-179">これらは、通常の読み取り/書き込み値を渡して周囲参照または定数の参照または値のコピーは安価な場合です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-179">These are typically read-write values that you pass around by reference or by const reference, or by value if copying is cheap.</span></span> <span data-ttu-id="cfd53-180">左辺値は、右辺値参照にバインドできません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-180">An lvalue can't be bound to an rvalue reference.</span></span>

### <a name="xvalue-im"></a><span data-ttu-id="cfd53-181">xvalue (は\&m)</span><span class="sxs-lookup"><span data-stu-id="cfd53-181">xvalue (i\&m)</span></span>
<span data-ttu-id="cfd53-182">(ある種の glvalue、ただしも、ある種の右辺値)、xvalue は id を持つ、移動することもできます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-182">An xvalue (a kind of glvalue, but also a kind of rvalue) has identity, and is also movable.</span></span> <span data-ttu-id="cfd53-183">転がって左辺値をコピーすることは高価であるために移動することが考えられますされ、その後アクセスしないように注意ができます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-183">This might be an erstwhile lvalue that you've decided to move because copying is expensive, and you'll be careful not to access it afterward.</span></span> <span data-ttu-id="cfd53-184">次に、xvalue に左辺を有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-184">Here's how you can turn an lvalue into an xvalue.</span></span>

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

<span data-ttu-id="cfd53-185">上記のコード例で移動していない何もまだします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-185">In the code example above, we haven't moved anything yet.</span></span> <span data-ttu-id="cfd53-186">名前のない右辺値参照に左辺をキャストすることによって、xvalue 先ほど作成しました。</span><span class="sxs-lookup"><span data-stu-id="cfd53-186">We've just created an xvalue by casting an lvalue to an unnamed rvalue reference.</span></span> <span data-ttu-id="cfd53-187">左辺値名によってまだ識別できます。の xvalue に今すぐ*対応*移動されるのです。</span><span class="sxs-lookup"><span data-stu-id="cfd53-187">It can still be identified by its lvalue name; but, as an xvalue, it is now *capable* of being moved.</span></span> <span data-ttu-id="cfd53-188">そのため、上の理由から、次のように、実際にどのような移動の別のトピックを待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-188">The reasons for doing so, and what moving actually looks like, will have to wait for another topic.</span></span> <span data-ttu-id="cfd53-189">"X"で"xvalue"意味「エキスパート専用」に役立つ場合として考えることができます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-189">But you can think of the "x" in "xvalue" as meaning "expert-only" if that helps.</span></span> <span data-ttu-id="cfd53-190">(右辺値の種類)、xvalue に左辺をキャストすることによって、値は、右辺値参照にバインドされていることになります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-190">By casting an lvalue into an xvalue (a kind of rvalue), the value then becomes capable of being bound to an rvalue reference.</span></span>

<span data-ttu-id="cfd53-191">Xvalues の他の 2 つの例をここでは&mdash;名前のない右辺値参照を返す関数を呼び出すと、xvalue のメンバーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-191">Here are two other examples of xvalues&mdash;calling a function that returns an unnamed rvalue reference, and accessing a member of an xvalue.</span></span>

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a><span data-ttu-id="cfd53-192">prvalue (\!は\&m)</span><span class="sxs-lookup"><span data-stu-id="cfd53-192">prvalue (\!i\&m)</span></span>
<span data-ttu-id="cfd53-193">(純粋な右辺値はある種の右辺値) の prvalue では、id はありませんが、移動します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-193">A prvalue (pure rvalue; a kind of rvalue) doesn't have identity, but is movable.</span></span> <span data-ttu-id="cfd53-194">これらの一時要素は通常、値、または、glvalue ではないその他の式の評価の結果によって関数の呼び出しの結果が返されます</span><span class="sxs-lookup"><span data-stu-id="cfd53-194">These are typically temporaries, the result of calling a function that returns by value, or the result of evaluating any other expression that's not a glvalue,</span></span>

### <a name="rvalue-m"></a><span data-ttu-id="cfd53-195">右辺値 (m)</span><span class="sxs-lookup"><span data-stu-id="cfd53-195">rvalue (m)</span></span>
<span data-ttu-id="cfd53-196">右辺値は、移動可能です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-196">An rvalue is movable.</span></span> <span data-ttu-id="cfd53-197">右辺*参照*常に右辺値 (値を保持する必要がありますしない内容と見なされます) を参照します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-197">An rvalue *reference* always refers to an rvalue (a value whose contents it's assumed we don't need to preserve).</span></span>

<span data-ttu-id="cfd53-198">右辺値参照自体を右辺値では。</span><span class="sxs-lookup"><span data-stu-id="cfd53-198">But, is an rvalue reference itself an rvalue?</span></span> <span data-ttu-id="cfd53-199">*名前のない*(上記の xvalue コード例に示すもの) のような右辺値参照は、xvalue、はい、これは、右辺値です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-199">An *unnamed* rvalue reference (like the ones shown in the xvalue code examples above) is an xvalue so, yes, it's an rvalue.</span></span> <span data-ttu-id="cfd53-200">移動コンス トラクターなど、右辺値参照を関数パラメーターにバインドするが優先されます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-200">It prefers to be bound to an rvalue reference function parameter, such as that of a move constructor.</span></span> <span data-ttu-id="cfd53-201">逆に、おそらく counter-intuitively)、右辺値参照は、名前を持つかどうかは、その名前で構成される式は左辺値です。</span><span class="sxs-lookup"><span data-stu-id="cfd53-201">Conversely (and perhaps counter-intuitively), if an rvalue reference has a name, then the expression consisting of that name is an lvalue.</span></span> <span data-ttu-id="cfd53-202">したがって、*ことはできません*右辺値参照パラメーターにバインドします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-202">So it *can't* be bound to an rvalue reference parameter.</span></span> <span data-ttu-id="cfd53-203">それは簡単に行うことが&mdash;だけ再キャスト (xvalue、) の名前のない右辺値参照にします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-203">But it's easy to make it do so&mdash;just cast it to an unnamed rvalue reference (an xvalue) again.</span></span>

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

### <a name="im"></a><span data-ttu-id="cfd53-204">\!\&\!m</span><span class="sxs-lookup"><span data-stu-id="cfd53-204">\!i\&\!m</span></span>
<span data-ttu-id="cfd53-205">Id がないし、サポートされない移動可能な値の種類は、まだ説明していない 1 つの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="cfd53-205">The kind of value that doesn't have identity and isn't movable is the one combination that we haven't yet discussed.</span></span> <span data-ttu-id="cfd53-206">そのカテゴリには、C++ 言語で便利な考え方がないため、無視しました。</span><span class="sxs-lookup"><span data-stu-id="cfd53-206">But we can disregard it, because that category isn't a useful idea in the C++ language.</span></span>

## <a name="reference-collapsing-rules"></a><span data-ttu-id="cfd53-207">参照縮小規則</span><span class="sxs-lookup"><span data-stu-id="cfd53-207">Reference-collapsing rules</span></span>
<span data-ttu-id="cfd53-208">(左辺値参照は左辺値参照または右辺値参照を右辺値参照) の式に複数の like 参照は 1 つ別の出力をキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-208">Multiple like references in an expression (an lvalue reference to an lvalue reference, or an rvalue reference to an rvalue reference) cancel one another out.</span></span>

- <span data-ttu-id="cfd53-209">`A& &` 折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-209">`A& &` collapses into `A&`.</span></span>
- <span data-ttu-id="cfd53-210">`A&& &&` 折りたたまれます`A&&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-210">`A&& &&` collapses into `A&&`.</span></span>

<span data-ttu-id="cfd53-211">左辺値参照を式内の参照とは異なり、複数を折りたたみます。</span><span class="sxs-lookup"><span data-stu-id="cfd53-211">Multiple unlike references in an expression collapse to an lvalue reference.</span></span>

- <span data-ttu-id="cfd53-212">`A& &&` 折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-212">`A& &&` collapses into `A&`.</span></span>
- <span data-ttu-id="cfd53-213">`A&& &` 折りたたまれます`A&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-213">`A&& &` collapses into `A&`.</span></span>

## <a name="forwarding-references"></a><span data-ttu-id="cfd53-214">転送の参照</span><span class="sxs-lookup"><span data-stu-id="cfd53-214">Forwarding references</span></span>
<span data-ttu-id="cfd53-215">この最後のセクションでは、右辺値参照は、既に説明したようにのさまざまな概念と対照的です。 を*転送参照*します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-215">This final section contrasts rvalue references, which we've already discussed, with the different concept of a *forwarding reference*.</span></span>

```cppwinrt
void foo(A&& a) { ... }
```

- <span data-ttu-id="cfd53-216">`A&&` 前述したように、右辺値参照は、します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-216">`A&&` is an rvalue reference, as we've seen.</span></span> <span data-ttu-id="cfd53-217">Const と揮発性は、右辺値参照に適用されません。</span><span class="sxs-lookup"><span data-stu-id="cfd53-217">Const and volatile don't apply to rvalue references.</span></span>
- <span data-ttu-id="cfd53-218">`foo` 型の右辺値のみを受け入れる**A**します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-218">`foo` accepts only rvalues of type **A**.</span></span>
- <span data-ttu-id="cfd53-219">理由の右辺値参照 (など`A&&`) 存在が渡される、一時的な (またはその他の右辺値) のケース用に最適化されたオーバー ロードを作成するようにします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-219">The reason rvalue references (such as `A&&`) exist is so that you can author an overload that's optimized for the case of a temporary (or other rvalue) being passed.</span></span>

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- <span data-ttu-id="cfd53-220">`_Ty&&` *転送参照*します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-220">`_Ty&&` is a *forwarding reference*.</span></span> <span data-ttu-id="cfd53-221">渡すに応じて`bar`、型 **_Ty** const/非 const volatile/非 volatile とは無関係に可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cfd53-221">Depending what you pass to `bar`, type **_Ty** could be const/non-const independently of volatile/non-volatile.</span></span>
- <span data-ttu-id="cfd53-222">`bar` 任意の左辺値または右辺値の型を受け入れる **_Ty**します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-222">`bar` accepts any lvalue or rvalue of type **_Ty**.</span></span>
- <span data-ttu-id="cfd53-223">なる転送先の参照を左辺値を渡すと`_Ty& &&`、左辺値参照を解除する`_Ty&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-223">Passing an lvalue causes the forwarding reference to become `_Ty& &&`, which collapses to the lvalue reference `_Ty&`.</span></span>
- <span data-ttu-id="cfd53-224">なる転送先の参照を右辺値を渡すと`_Ty&& &&`、右辺値参照を解除する`_Ty&&`します。</span><span class="sxs-lookup"><span data-stu-id="cfd53-224">Passing an rvalue causes the forwarding reference to become `_Ty&& &&`, which collapses to the rvalue reference `_Ty&&`.</span></span>
- <span data-ttu-id="cfd53-225">参照を転送する理由 (など`_Ty&&`) 存在が*いない*最適化が何を渡すを実行して透過的かつ効率的に転送するようにします。</span><span class="sxs-lookup"><span data-stu-id="cfd53-225">The reason forwarding references (such as `_Ty&&`) exist is *not* for optimization, but to take what you pass to them and to forward it on transparently and efficiently.</span></span> <span data-ttu-id="cfd53-226">書き込み、または密接に調査) ライブラリのコードの場合にのみ転送の参照が発生する可能性が高いしたら&mdash;コンス トラクター引数では転送、factory 関数などです。</span><span class="sxs-lookup"><span data-stu-id="cfd53-226">You're likely to encounter a forwarding reference only if you write (or closely study) library code&mdash;for example, a factory function that forwards on constructor arguments.</span></span>

## <a name="sources"></a><span data-ttu-id="cfd53-227">Sources</span><span class="sxs-lookup"><span data-stu-id="cfd53-227">Sources</span></span>
* <span data-ttu-id="cfd53-228">\[Stroustrup、2013\] B. Stroustrup:C++ プログラミング言語で、Fourth Edition。</span><span class="sxs-lookup"><span data-stu-id="cfd53-228">\[Stroustrup, 2013\] B. Stroustrup: The C++ Programming Language, Fourth Edition.</span></span> <span data-ttu-id="cfd53-229">Addison-Wesley.</span><span class="sxs-lookup"><span data-stu-id="cfd53-229">Addison-Wesley.</span></span> <span data-ttu-id="cfd53-230">2013.</span><span class="sxs-lookup"><span data-stu-id="cfd53-230">2013.</span></span>
