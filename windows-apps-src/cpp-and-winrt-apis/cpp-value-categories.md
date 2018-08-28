---
author: stevewhims
description: このトピックでは、C で存在しない値のさまざまなカテゴリについて説明します。 Lvalue と rvalue 音がわかりは、他の種類をすぎる場合もあります。
title: 値のカテゴリ、およびへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、+ + c、cpp、winrt、投影、移動、転送、値のカテゴリ、移動の形式、最適な転送、操作が起きる、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2881715"
---
# <a name="value-categories-and-references-to-them"></a><span data-ttu-id="894d9-105">値のカテゴリ、およびへの参照</span><span class="sxs-lookup"><span data-stu-id="894d9-105">Value categories, and references to them</span></span>
<span data-ttu-id="894d9-106">このトピックでは、C で存在しているさまざまなカテゴリの値 (値への参照) について説明します。</span><span class="sxs-lookup"><span data-stu-id="894d9-106">This topic describes the various categories of values (and references to values) that exist in C++.</span></span> <span data-ttu-id="894d9-107">*Lvalue*と*rvalue*音がわかりが、このトピックで説明する条件のうちいない考えです。</span><span class="sxs-lookup"><span data-stu-id="894d9-107">You will doubtless have heard of *lvalues* and *rvalues*, but you may not think of them in the terms that this topic presents.</span></span> <span data-ttu-id="894d9-108">値の他の種類があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-108">And there are other kinds of values, too.</span></span>

<span data-ttu-id="894d9-109">C ですべての式では、このトピックで説明するカテゴリのいずれかに属している値が生成します。</span><span class="sxs-lookup"><span data-stu-id="894d9-109">Every expression in C++ yields a value that belongs to one of the categories discussed in this topic.</span></span> <span data-ttu-id="894d9-110">C 言語、facilies、およびこれらの値のカテゴリとへの参照の適切なの理解度を必要とすると、ルールの要素があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-110">There are aspects of the C++ language, its facilies, and rules, that demand a proper understanding of these value categories, and references to them.</span></span> <span data-ttu-id="894d9-111">たとえば、値、値をコピー、値を移動および転送に別の関数の値のアドレスを取得します。</span><span class="sxs-lookup"><span data-stu-id="894d9-111">For example, taking the address of a value, copying a value, moving a value, and forwarding a value on to another function.</span></span> <span data-ttu-id="894d9-112">このトピックはすべての機能についての詳細] に移動しないが、それらの基本を理解情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="894d9-112">This topic doesn't go into all of those aspects in depth, but it provides foundational information for a solid understanding of them.</span></span>

<span data-ttu-id="894d9-113">このトピックの情報は、id および movability [Stroustrup 2013] の 2 つの独立したプロパティを Stroustrup の値のカテゴリの詳細な分析で囲まれています。</span><span class="sxs-lookup"><span data-stu-id="894d9-113">The info in this topic is framed in terms of Stroustrup's analysis of value categories by the two independent properties of identity and movability [Stroustrup, 2013].</span></span>

## <a name="an-lvalue-has-identity"></a><span data-ttu-id="894d9-114">操作が起きるの id を持ってください。</span><span class="sxs-lookup"><span data-stu-id="894d9-114">An lvalue has identity</span></span>
<span data-ttu-id="894d9-115">どういう*id*の値の意味ですか。</span><span class="sxs-lookup"><span data-stu-id="894d9-115">What does it mean for a value to have *identity*?</span></span> <span data-ttu-id="894d9-116">値のメモリ アドレスがある (または実行可能な) し、[値の id を持って安全に使用します。</span><span class="sxs-lookup"><span data-stu-id="894d9-116">If you have (or you can take) the memory address of a value and use it safely, then the value has identity.</span></span> <span data-ttu-id="894d9-117">これにより、できる比較よりも多い値の内容: 比較したり、id で区別できるようにします。</span><span class="sxs-lookup"><span data-stu-id="894d9-117">That way, you can do more than compare the contents of values: you can compare or distinguish them by identity.</span></span>

<span data-ttu-id="894d9-118">*操作が起きる*id を持っています。</span><span class="sxs-lookup"><span data-stu-id="894d9-118">An *lvalue* has identity.</span></span> <span data-ttu-id="894d9-119">「操作が起きる」の「さ」が「左」(ように、left-hand-の面に、割り当て) の省略形のみ履歴興味のある問題です。</span><span class="sxs-lookup"><span data-stu-id="894d9-119">It's now a matter of only historical interest that the "l" in "lvalue" is an abbreviation of "left" (as in, the left-hand-side of an assignment).</span></span> <span data-ttu-id="894d9-120">C では、操作が起きるは、左 *、または*割り当ての右側に表示されます。</span><span class="sxs-lookup"><span data-stu-id="894d9-120">In C++, an lvalue can appear on the left *or* on the right of an assignment.</span></span> <span data-ttu-id="894d9-121">"Lvalue"、"l"し、実際にうまくいかない理解し、は何かを定義します。</span><span class="sxs-lookup"><span data-stu-id="894d9-121">The "l" in "lvalues", then, doesn't actually help you to comprehend nor define what they are.</span></span> <span data-ttu-id="894d9-122">操作が起きると呼ばれるものは、id を持つ値であるかを理解するには、のみを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-122">You need only to understand that what we call an lvalue is a value that has identity.</span></span>

<span data-ttu-id="894d9-123">Lvalue は、式の例: 名前付き変数または定数といいます。または、参照を返す関数を選択します。</span><span class="sxs-lookup"><span data-stu-id="894d9-123">Examples of expressions that are lvalues include: a named variable or constant; or a function that returns a reference.</span></span> <span data-ttu-id="894d9-124">Lvalue では*ありません*が、式の例: 一時的なです。または、値を返す関数を選択します。</span><span class="sxs-lookup"><span data-stu-id="894d9-124">Examples of expressions that are *not* lvalues include: a temporary; or a function that returns by value.</span></span>

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

<span data-ttu-id="894d9-125">これで、条件を満たすステートメント lvalue が id を持っているは取得します。</span><span class="sxs-lookup"><span data-stu-id="894d9-125">Now, while it's a true statement that lvalues have identity, so do xvalues.</span></span> <span data-ttu-id="894d9-126">どのような*xvalue フラグ*は、このトピックの後半にしましょう。</span><span class="sxs-lookup"><span data-stu-id="894d9-126">We'll go more into what an *xvalue* is later in this topic.</span></span> <span data-ttu-id="894d9-127">ここでは、だけで、glvalue「一般的な操作が起きる」と呼ばれる値のカテゴリがあることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="894d9-127">For now, just be aware that there is a value category called glvalue, for "generalized lvalue".</span></span> <span data-ttu-id="894d9-128">Glvalues のスーパー セットには、lvalue (*クラシック lvalue*とも呼ばれます) と取得の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="894d9-128">The superset of glvalues contains both lvalues (also known as *classical lvalues*) and xvalues.</span></span> <span data-ttu-id="894d9-129">したがって、中に「操作が起きるの id を持って」条件が満たされた、一連の id を持っていることは、一連の glvalues、次の図に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="894d9-129">So, while "an lvalue has identity" is true, the complete set of things that have identity is the set of glvalues, as shown in this illustration.</span></span>

![操作が起きるの id を持ってください。](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a><span data-ttu-id="894d9-131">右辺値が移動します。操作が起きるがないです。</span><span class="sxs-lookup"><span data-stu-id="894d9-131">An rvalue is movable; an lvalue is not</span></span>
<span data-ttu-id="894d9-132">ただし、glvalues 以外の値があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-132">But there are values that are not glvalues.</span></span> <span data-ttu-id="894d9-133">したがって、値のメモリ アドレスを取得する*ことはできません*(または与えてを有効にすることはできません) があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-133">Consequently, there are values that you *can't* obtain a memory address for (or you can't rely on it to be valid).</span></span> <span data-ttu-id="894d9-134">上記の例でこのようないくつかの値をしました。</span><span class="sxs-lookup"><span data-stu-id="894d9-134">We saw some such values in the code example above.</span></span> <span data-ttu-id="894d9-135">欠点が聞こえます。</span><span class="sxs-lookup"><span data-stu-id="894d9-135">This sounds like a disadvantage.</span></span> <span data-ttu-id="894d9-136">実際の値を利用できるは通常安価) は、*移動する*にはなどのではなく (これは、一般に価) からコピーします。</span><span class="sxs-lookup"><span data-stu-id="894d9-136">But in fact the advantage of a value like that is that you can *move* from it (which is generally cheap), rather than copy from it (which is generally expensive).</span></span> <span data-ttu-id="894d9-137">値から移動すると、内にある不要になったするために使用する場所を意味します。</span><span class="sxs-lookup"><span data-stu-id="894d9-137">Moving from a value means that it's no longer in the place it used to be.</span></span> <span data-ttu-id="894d9-138">したがって、するために使用する場所にアクセスしようとしています。 を回避します。</span><span class="sxs-lookup"><span data-stu-id="894d9-138">So, trying to access it in the place it used to be is something to be avoided.</span></span> <span data-ttu-id="894d9-139">場合と*どのように*値がこのトピックの範囲外に移動するについて説明します。</span><span class="sxs-lookup"><span data-stu-id="894d9-139">A discussion of when and *how* to move a value is out of scope for this topic.</span></span> <span data-ttu-id="894d9-140">このトピックでは、すぐに移動する値が*右辺値*(または*クラシック右辺値*) と呼ばれることを知っておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-140">For this topic, we just need to know that a value that is movable is known as an *rvalue* (or *classical rvalue*).</span></span>

<span data-ttu-id="894d9-141">「右辺値」の"r"は、「右」(ように、右-hand-の面に、割り当て) の省略形です。</span><span class="sxs-lookup"><span data-stu-id="894d9-141">The "r" in "rvalue" is an abbreviation of "right" (as in, the right-hand-side of an assignment).</span></span> <span data-ttu-id="894d9-142">Rvalue および割り当ての外部で rvalue への参照を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="894d9-142">But you can use rvalues, and references to rvalues, outside of assignments.</span></span> <span data-ttu-id="894d9-143">"Rvalue"、"r"のオブジェクトに焦点を次はできません。</span><span class="sxs-lookup"><span data-stu-id="894d9-143">The "r" in "rvalues", then, is not the thing to focus on.</span></span> <span data-ttu-id="894d9-144">移動する値が右辺値と呼ばれるものであるかを理解のみにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-144">You need only to understand that what we call an rvalue is a value that is movable.</span></span>

<span data-ttu-id="894d9-145">逆に、次の図に示すように、操作が起きるは、移動です。</span><span class="sxs-lookup"><span data-stu-id="894d9-145">An lvalue, conversely, isn't movable, as shown in this illustration.</span></span> <span data-ttu-id="894d9-146">移動操作が起きるは*操作が起きる*の定義を入れては非常に適度に動作すると、引き続き値にアクセスすることができるコードの予期しないエラーになります。</span><span class="sxs-lookup"><span data-stu-id="894d9-146">An lvalue that moved would defy the definition of *lvalue*, and it would be an unexpected problem for code that very reasonably expected to be able to continue to access the lvalue.</span></span>

![右辺値が移動します。操作が起きるがないです。](images/is-movable.png)

<span data-ttu-id="894d9-148">操作が起きるを移動することはできません。</span><span class="sxs-lookup"><span data-stu-id="894d9-148">You can't move an lvalue.</span></span> <span data-ttu-id="894d9-149">しかし*が*移動できる glvalue (ユーザー機能のセット) の一種&mdash;何をしていることがわかっている場合 (など、移動後にアクセスしないように注意してください)&mdash;、xvalue フラグがします。</span><span class="sxs-lookup"><span data-stu-id="894d9-149">But there *is* a kind of glvalue (the set of things with identity) that you can move&mdash;if you know what you're doing (including being careful not to access it after the move)&mdash;and that's the xvalue.</span></span> <span data-ttu-id="894d9-150">このアイデアをもう一度、次の値の項目の全体像を見るとお見直しされます。</span><span class="sxs-lookup"><span data-stu-id="894d9-150">We'll revisit this idea one more time below, when we look at the complete picture of value categories.</span></span>

## <a name="rvalue-references-and-reference-binding-rules"></a><span data-ttu-id="894d9-151">右辺値の参照、およびリファレンス バインド規則</span><span class="sxs-lookup"><span data-stu-id="894d9-151">Rvalue references, and reference-binding rules</span></span>
<span data-ttu-id="894d9-152">ここでは、右辺値への参照の構文を紹介します。</span><span class="sxs-lookup"><span data-stu-id="894d9-152">This section introduces the syntax for a reference to an rvalue.</span></span> <span data-ttu-id="894d9-153">も大幅に移動し、[転送] の処理に移行する別のトピックを待つ必要はありますが、右辺値の参照が解決した問題です。</span><span class="sxs-lookup"><span data-stu-id="894d9-153">We'll have to wait for another topic to go into a substantial treatment of moving and forwarding, but those are problems that are solved by rvalue references.</span></span> <span data-ttu-id="894d9-154">右辺値の参照を見ると、前に、最初が必要はわかりやすくなること`T&`&mdash;こと聞か以前れたり、通話だけ「参照」します。</span><span class="sxs-lookup"><span data-stu-id="894d9-154">Before we look at rvalue references, though, we first need to be clearer about `T&`&mdash;the thing we've formerly been calling just "a reference".</span></span> <span data-ttu-id="894d9-155">「、操作が起きる (定数ではない) 参照」参照のユーザーを作成できます () の値を参照するは実際にできます。</span><span class="sxs-lookup"><span data-stu-id="894d9-155">It's really "an lvalue (non-const) reference", which refers to an value to which the user of the reference can write.</span></span>

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

<span data-ttu-id="894d9-156">右辺値ではなく、操作が起きる] に、操作が起きる参照にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="894d9-156">An lvalue reference can bind to an lvalue, but not to an rvalue.</span></span>

<span data-ttu-id="894d9-157">操作が起きる定数参照し、(`T const&`)、するには、オブジェクトを*できない*参照のユーザーの作成 (たとえば、"定数") を参照してください。</span><span class="sxs-lookup"><span data-stu-id="894d9-157">Then there are lvalue const references (`T const&`), which refer to objects to which the user of the reference *can't* write (for example, a constant).</span></span>

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

<span data-ttu-id="894d9-158">操作が起きる定数の参照は、操作が起きるまたは右辺値にバインドします。</span><span class="sxs-lookup"><span data-stu-id="894d9-158">An lvalue const reference can bind to an lvalue or to an rvalue.</span></span>

<span data-ttu-id="894d9-159">型の右辺値への参照の構文`T`として書き込まれます`T&&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-159">The syntax for a reference to an rvalue of type `T` is written as `T&&`.</span></span> <span data-ttu-id="894d9-160">移動の値を右辺値の参照が参照&mdash;の値の内容は (たとえば、一時的な) を使用して後に維持する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="894d9-160">An rvalue reference refers to a movable value&mdash;an value whose contents we don't need to preserve after we've used it (for example, a temporary).</span></span> <span data-ttu-id="894d9-161">全体のポイントからから移動する (変更されないように) の値にバインド右辺値参照では、`const`と`volatile`右辺値の参照を区切り記号 (とも呼ばれる cv の区切り記号) を適用しません。</span><span class="sxs-lookup"><span data-stu-id="894d9-161">Since the whole point is to move from (thereby modifying) the value bound to an rvalue reference, `const` and `volatile` qualifiers (also known as cv-qualifiers) don't apply to rvalue references.</span></span>

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

<span data-ttu-id="894d9-162">右辺値にバインド右辺値を参照します。</span><span class="sxs-lookup"><span data-stu-id="894d9-162">An rvalue reference binds to an rvalue.</span></span> <span data-ttu-id="894d9-163">オーバー ロードの解像度を右辺値が*希望*よりも操作が起きる定数参照への右辺値参照にバインドするは実際には。</span><span class="sxs-lookup"><span data-stu-id="894d9-163">In fact, in terms of overload resolution, an rvalue *prefers* to be bound to an rvalue reference than to an lvalue const reference.</span></span> <span data-ttu-id="894d9-164">前述したを右辺値を参照する値 (たとえば、移動コンスのパラメーター) を保存する必要はありませんしたと見なされますの内容があるため、右辺値の参照に操作が起きるバインドことはできません。</span><span class="sxs-lookup"><span data-stu-id="894d9-164">But an rvalue reference can't bind to an lvalue because, as we've said, an rvalue reference refers to a value whose contents it's assumed we don't need to preserve (say, the parameter for a move constructor).</span></span>

<span data-ttu-id="894d9-165">渡すことも右辺値引数の値では、必要な場所でコピーの作成 (または右辺値が、xvalue フラグの場合は、移動構築機能を使って)。</span><span class="sxs-lookup"><span data-stu-id="894d9-165">You can also pass an rvalue where a by-value argument is expected, via copy construction (or via move construction, if the rvalue is an xvalue).</span></span>

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a><span data-ttu-id="894d9-166">Glvalue が識別します。prvalue していません。</span><span class="sxs-lookup"><span data-stu-id="894d9-166">A glvalue has identity; a prvalue does not</span></span>
<span data-ttu-id="894d9-167">この時点での id を持ってとわかっています。</span><span class="sxs-lookup"><span data-stu-id="894d9-167">At this stage, we know what has identity.</span></span> <span data-ttu-id="894d9-168">移動できる機能し、そうでないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="894d9-168">And we know what's movable and what isn't.</span></span> <span data-ttu-id="894d9-169">まだおまだ id を持って*いない*名前付きの値のセットです。</span><span class="sxs-lookup"><span data-stu-id="894d9-169">But we haven't yet named the set of values that *don't* have identity.</span></span> <span data-ttu-id="894d9-170">そのセットは*prvalue*、または*単純右辺値*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="894d9-170">That set is known as the *prvalue*, or *pure rvalue*.</span></span>

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![操作が起きるが識別します。prvalue していません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a><span data-ttu-id="894d9-172">値のカテゴリの完全な画像</span><span class="sxs-lookup"><span data-stu-id="894d9-172">The complete picture of value categories</span></span>
<span data-ttu-id="894d9-173">情報と、1 つの大きな画像の上にある図を結合するだけのままです。</span><span class="sxs-lookup"><span data-stu-id="894d9-173">It only remains to combine the info and illustrations above into a single, big picture.</span></span>

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a><span data-ttu-id="894d9-175">glvalue (i)</span><span class="sxs-lookup"><span data-stu-id="894d9-175">glvalue (i)</span></span>
<span data-ttu-id="894d9-176">Id を持って、glvalue (一般的な操作が起きる)。</span><span class="sxs-lookup"><span data-stu-id="894d9-176">A glvalue (generalized lvalue) has identity.</span></span>

### <a name="lvalue-im"></a><span data-ttu-id="894d9-177">操作が起きる (i\ & \!m)</span><span class="sxs-lookup"><span data-stu-id="894d9-177">lvalue (i\&\!m)</span></span>
<span data-ttu-id="894d9-178">操作が起きる (glvalue の種類) の id が、移動されていません。</span><span class="sxs-lookup"><span data-stu-id="894d9-178">An lvalue (a kind of glvalue) has identity, but isn't movable.</span></span> <span data-ttu-id="894d9-179">通過するを参照または定数の参照、または値をコピーすることが低い場合は、通常の読み取り/書き込み値です。</span><span class="sxs-lookup"><span data-stu-id="894d9-179">These are typically read-write values that you pass around by reference or by const reference, or by value if copying is cheap.</span></span> <span data-ttu-id="894d9-180">操作が起きる右辺値参照にバインドできません。</span><span class="sxs-lookup"><span data-stu-id="894d9-180">An lvalue can't be bound to an rvalue reference.</span></span>

### <a name="xvalue-im"></a><span data-ttu-id="894d9-181">xvalue フラグ (i\ & m)</span><span class="sxs-lookup"><span data-stu-id="894d9-181">xvalue (i\&m)</span></span>
<span data-ttu-id="894d9-182">(Glvalue、の種類もの右辺値の種類)、xvalue フラグ id がありも移動します。</span><span class="sxs-lookup"><span data-stu-id="894d9-182">An xvalue (a kind of glvalue, but also a kind of rvalue) has identity, and is also movable.</span></span> <span data-ttu-id="894d9-183">される操作が起きるされるため、コストがコピー、移動する可能性があり、後で、アクセスしないように注意ができます。</span><span class="sxs-lookup"><span data-stu-id="894d9-183">This might be an erstwhile lvalue that you've decided to move because copying is expensive, and you'll be careful not to access it afterward.</span></span> <span data-ttu-id="894d9-184">Xvalue フラグに操作が起きるを有効にする方法をご紹介します。</span><span class="sxs-lookup"><span data-stu-id="894d9-184">Here's how you can turn an lvalue into an xvalue.</span></span>

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

<span data-ttu-id="894d9-185">上記のコードの例では移動していない何もまだします。</span><span class="sxs-lookup"><span data-stu-id="894d9-185">In the code example above, we haven't moved anything yet.</span></span> <span data-ttu-id="894d9-186">操作が起きる右辺値の名前のない参照にキャストを xvalue フラグ作成しました。</span><span class="sxs-lookup"><span data-stu-id="894d9-186">We've just created an xvalue by casting an lvalue to an unnamed rvalue reference.</span></span> <span data-ttu-id="894d9-187">操作が起きる名で識別されることもできます。しますが、として、xvalue フラグ、今すぐ*利用できる*を移動します。</span><span class="sxs-lookup"><span data-stu-id="894d9-187">It can still be identified by its lvalue name; but, as an xvalue, it is now *capable* of being moved.</span></span> <span data-ttu-id="894d9-188">理由と、別のトピックを待つ必要はどのような移動など、実際が表示されます。</span><span class="sxs-lookup"><span data-stu-id="894d9-188">The reasons for doing so, and what moving actually looks like, will have to wait for another topic.</span></span> <span data-ttu-id="894d9-189">意味"エキスパート取り専用で"できる場合は、「xvalue フラグ」の"x"の考えることができます。</span><span class="sxs-lookup"><span data-stu-id="894d9-189">But you can think of the "x" in "xvalue" as meaning "expert-only" if that helps.</span></span> <span data-ttu-id="894d9-190">操作が起きるをキャストを xvalue フラグ (右辺値の種類) に、値になります右辺値参照にバインドされていること。</span><span class="sxs-lookup"><span data-stu-id="894d9-190">By casting an lvalue into an xvalue (a kind of rvalue), the value then becomes capable of being bound to an rvalue reference.</span></span>

<span data-ttu-id="894d9-191">取得およびその他の 2 つの例を紹介&mdash;、名称未設定の右辺値の参照を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="894d9-191">Here are two other examples of xvalues&mdash;calling a function that returns an unnamed rvalue reference, and accessing a member of an xvalue.</span></span>

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a><span data-ttu-id="894d9-192">prvalue (\!i\ & m)</span><span class="sxs-lookup"><span data-stu-id="894d9-192">prvalue (\!i\&m)</span></span>
<span data-ttu-id="894d9-193">(単純右辺値。 右辺値の一種) の prvalue id がありません。 しかし移動します。</span><span class="sxs-lookup"><span data-stu-id="894d9-193">A prvalue (pure rvalue; a kind of rvalue) doesn't have identity, but is movable.</span></span> <span data-ttu-id="894d9-194">関数を呼び出すの結果は一時これらは通常、値、または、glvalue] ではないその他の式を評価した結果を返します。</span><span class="sxs-lookup"><span data-stu-id="894d9-194">These are typically temporaries, the result of calling a function that returns by value, or the result of evaluating any other expression that's not a glvalue,</span></span>

### <a name="rvalue-m"></a><span data-ttu-id="894d9-195">右辺値 (m)</span><span class="sxs-lookup"><span data-stu-id="894d9-195">rvalue (m)</span></span>
<span data-ttu-id="894d9-196">右辺値が移動します。</span><span class="sxs-lookup"><span data-stu-id="894d9-196">An rvalue is movable.</span></span> <span data-ttu-id="894d9-197">右辺値の*参照*は、常に右辺値 (値と見なされます内容を保存する必要はありません) を参照します。</span><span class="sxs-lookup"><span data-stu-id="894d9-197">An rvalue *reference* always refers to an rvalue (a value whose contents it's assumed we don't need to preserve).</span></span>

<span data-ttu-id="894d9-198">右辺値参照自体を右辺値ですか。</span><span class="sxs-lookup"><span data-stu-id="894d9-198">But, is an rvalue reference itself an rvalue?</span></span> <span data-ttu-id="894d9-199">(上記の xvalue フラグ コード例に示すもの) のような*名前*の右辺値の参照が、xvalue フラグはいは、その右辺値。</span><span class="sxs-lookup"><span data-stu-id="894d9-199">An *unnamed* rvalue reference (like the ones shown in the xvalue code examples above) is an xvalue so, yes, it's an rvalue.</span></span> <span data-ttu-id="894d9-200">優先的に移動コンスのなど、右辺値の参照関数パラメーターにバインドします。</span><span class="sxs-lookup"><span data-stu-id="894d9-200">It prefers to be bound to an rvalue reference function parameter, such as that of a move constructor.</span></span> <span data-ttu-id="894d9-201">逆に、counter-intuitively など)、右辺値の参照が名前を持つかどうかは、その名前で構成されている式は、操作が起きるします。</span><span class="sxs-lookup"><span data-stu-id="894d9-201">Conversely (and perhaps counter-intuitively), if an rvalue reference has a name, then the expression consisting of that name is an lvalue.</span></span> <span data-ttu-id="894d9-202">したがって、右辺値参照パラメーターにバインドする*ことはできません*。</span><span class="sxs-lookup"><span data-stu-id="894d9-202">So it *can't* be bound to an rvalue reference parameter.</span></span> <span data-ttu-id="894d9-203">簡単に実行することができますが、&mdash;だけもう一度キャスト右辺値の名前の参照 (xvalue フラグ) にします。</span><span class="sxs-lookup"><span data-stu-id="894d9-203">But it's easy to make it do so&mdash;just cast it to an unnamed rvalue reference (an xvalue) again.</span></span>

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

### <a name="im"></a><span data-ttu-id="894d9-204">\!i\ と \!m</span><span class="sxs-lookup"><span data-stu-id="894d9-204">\!i\&\!m</span></span>
<span data-ttu-id="894d9-205">ユーザーがない理由と移動されていない値の種類は、まだ説明していない 1 つの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="894d9-205">The kind of value that doesn't have identity and isn't movable is the one combination that we haven't yet discussed.</span></span> <span data-ttu-id="894d9-206">そのカテゴリが C 言語で便利なを理解するため、無視することができます。</span><span class="sxs-lookup"><span data-stu-id="894d9-206">But we can disregard it, because that category isn't a useful idea in the C++ language.</span></span>

## <a name="reference-collapsing-rules"></a><span data-ttu-id="894d9-207">[ルールのリファレンス折りたたみ</span><span class="sxs-lookup"><span data-stu-id="894d9-207">Reference-collapsing rules</span></span>
<span data-ttu-id="894d9-208">(操作が起きる参照では、操作が起きるを参照または右辺値参照への右辺値参照) の式に複数の like 参照はいずれかの別のものをキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="894d9-208">Multiple like references in an expression (an lvalue reference to an lvalue reference, or an rvalue reference to an rvalue reference) cancel one another out.</span></span>

- `A& &` <span data-ttu-id="894d9-209">`A&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-209">collapses into `A&`.</span></span>
- `A&& &&` <span data-ttu-id="894d9-210">`A&&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-210">collapses into `A&&`.</span></span>

<span data-ttu-id="894d9-211">式内の参照とは異なり、複数非表示、操作が起きる参照にします。</span><span class="sxs-lookup"><span data-stu-id="894d9-211">Multiple unlike references in an expression collapse to an lvalue reference.</span></span>

- `A& &&` <span data-ttu-id="894d9-212">`A&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-212">collapses into `A&`.</span></span>
- `A&& &` <span data-ttu-id="894d9-213">`A&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-213">collapses into `A&`.</span></span>

## <a name="forwarding-references"></a><span data-ttu-id="894d9-214">参照の転送</span><span class="sxs-lookup"><span data-stu-id="894d9-214">Forwarding references</span></span>
<span data-ttu-id="894d9-215">最後のセクションでは、右辺値の参照は、既にで説明した、*参照の転送*のさまざまな概念とを比較します。</span><span class="sxs-lookup"><span data-stu-id="894d9-215">This final section contrasts rvalue references, which we've already discussed, with the different concept of a *forwarding reference*.</span></span>

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` <span data-ttu-id="894d9-216">右辺値、参照はきたようです。</span><span class="sxs-lookup"><span data-stu-id="894d9-216">is an rvalue reference, as we've seen.</span></span> <span data-ttu-id="894d9-217">定数と揮発性はしない右辺値の参照を適用します。</span><span class="sxs-lookup"><span data-stu-id="894d9-217">Const and volatile don't apply to rvalue references.</span></span>
- `foo` <span data-ttu-id="894d9-218">**入力**の rvalue のみを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="894d9-218">accepts only rvalues of type **A**.</span></span>
- <span data-ttu-id="894d9-219">理由右辺値を参照 (次のような`A&&`) が存在する渡される一時的な (またはその他の右辺値) の場合に最適なオーバー ロードを作成するようにします。</span><span class="sxs-lookup"><span data-stu-id="894d9-219">The reason rvalue references (such as `A&&`) exist is so that you can author an overload that's optimized for the case of a temporary (or other rvalue) being passed.</span></span>

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` <span data-ttu-id="894d9-220">*参照を転送*します。</span><span class="sxs-lookup"><span data-stu-id="894d9-220">is a *forwarding reference*.</span></span> <span data-ttu-id="894d9-221">内容を通過する`bar`、種類 **_Ty**は定数/非定数揮発性/非揮発性とは独立させてである可能性があります。</span><span class="sxs-lookup"><span data-stu-id="894d9-221">Depending what you pass to `bar`, type **_Ty** could be const/non-const independently of volatile/non-volatile.</span></span>
- `bar` <span data-ttu-id="894d9-222">任意の操作が起きるまたは型 **_Ty**の右辺値を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="894d9-222">accepts any lvalue or rvalue of type **_Ty**.</span></span>
- <span data-ttu-id="894d9-223">転送参照操作が起きるを渡すと`_Ty& &&`、操作が起きるの参照を解除する`_Ty&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-223">Passing an lvalue causes the forwarding reference to become `_Ty& &&`, which collapses to the lvalue reference `_Ty&`.</span></span>
- <span data-ttu-id="894d9-224">転送の参照が右辺値を渡すと`_Ty&& &&`、右辺値の参照を解除する`_Ty&&`します。</span><span class="sxs-lookup"><span data-stu-id="894d9-224">Passing an rvalue causes the forwarding reference to become `_Ty&& &&`, which collapses to the rvalue reference `_Ty&&`.</span></span>
- <span data-ttu-id="894d9-225">参照を転送する理由 (次のような`_Ty&&`) が存在が*ない*の最適化] を何を通過するにはし透過的かつ効率的には、転送します。</span><span class="sxs-lookup"><span data-stu-id="894d9-225">The reason forwarding references (such as `_Ty&&`) exist is *not* for optimization, but to take what you pass to them and to forward it on transparently and efficiently.</span></span> <span data-ttu-id="894d9-226">書き込み、または密接に研究) ライブラリ コード場合にのみ転送の参照が発生する可能性がある&mdash;コンス引数に転送するファクトリ関数などです。</span><span class="sxs-lookup"><span data-stu-id="894d9-226">You're likely to encounter a forwarding reference only if you write (or closely study) library code&mdash;for example, a factory function that forwards on constructor arguments.</span></span>

## <a name="sources"></a><span data-ttu-id="894d9-227">Sources</span><span class="sxs-lookup"><span data-stu-id="894d9-227">Sources</span></span>
* <span data-ttu-id="894d9-228">\[Stroustrup 2013\] B. Stroustrup: C プログラミング言語、4 番目の Edition します。</span><span class="sxs-lookup"><span data-stu-id="894d9-228">\[Stroustrup, 2013\] B. Stroustrup: The C++ Programming Language, Fourth Edition.</span></span> <span data-ttu-id="894d9-229">◆ センターします。</span><span class="sxs-lookup"><span data-stu-id="894d9-229">Addison-Wesley.</span></span> <span data-ttu-id="894d9-230">2013 します。</span><span class="sxs-lookup"><span data-stu-id="894d9-230">2013.</span></span>
