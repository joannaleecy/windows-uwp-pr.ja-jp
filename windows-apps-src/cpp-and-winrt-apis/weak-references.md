---
author: stevewhims
description: C++/WinRT の弱参照サポートは利用に応じた料金制度であるため、オブジェクトが IWeakReferenceSource を照会しない限り、料金はかかりません。
title: C++/WinRT の弱参照
ms.author: stwhi
ms.date: 04/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、弱、参照
ms.localizationpriority: medium
ms.openlocfilehash: 63ffad19c0ae8a52737ae13a54e5657df875d0b5
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832606"
---
# <a name="weak-references-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="55ca5-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) の弱参照</span><span class="sxs-lookup"><span data-stu-id="55ca5-104">Weak references in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="55ca5-105">循環参照や弱参照が必要とならないように独自の C++/WinRT API を設計することはできるはずですし、まったく行わないことはないはずです。</span><span class="sxs-lookup"><span data-stu-id="55ca5-105">You should be able, more often than not, to design your own C++/WinRT APIs in such a way as to avoid the need for cyclic references and weak references.</span></span> <span data-ttu-id="55ca5-106">ただし、XAML ベースの UI フレームワークのネイティブ実装を考えると、フレームワークの歴史的設計が理由で、C++/WinRT の弱参照メカニズムは循環参照を処理するために必要になります。</span><span class="sxs-lookup"><span data-stu-id="55ca5-106">However, when it comes to the native implementation of the XAML-based UI frameworkL&mdash;because of the historic design of the framework&mdash;the weak reference mechanism in C++/WinRT is necessary to handle cyclic references.</span></span> <span data-ttu-id="55ca5-107">XAML 以外では、弱参照を使用する必要性は考えにくいようです (ただし、理論上は弱参照に関して XAML に特有なことは存在しません)。</span><span class="sxs-lookup"><span data-stu-id="55ca5-107">Outside of XAML, it's unlikely you'll need to use weak references (although, there’s nothing XAML-specific about them in theory).</span></span>

<span data-ttu-id="55ca5-108">宣言するすべての型について、いつどこで弱参照が必要になるかが C++/WinRT に対してすぐに明白になるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="55ca5-108">For any given type that you declare, it's not immediately obvious to C++/WinRT whether or when weak references are needed.</span></span> <span data-ttu-id="55ca5-109">したがって、C++/WinRT は構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) で弱参照サポートを自動的に提供し、そこから直接的または間接的に独自の C++/WinRT の型を派生します。</span><span class="sxs-lookup"><span data-stu-id="55ca5-109">So, C++/WinRT provides weak reference support automatically on the struct template [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements), from which your own C++/WinRT types directly or indirectly derive.</span></span> <span data-ttu-id="55ca5-110">利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](https://msdn.microsoft.com/library/br224609) で実際に照会されない限り料金はかかりません。</span><span class="sxs-lookup"><span data-stu-id="55ca5-110">It's pay-for-play, in that it doesn't cost you anything unless your object is actually queried for [**IWeakReferenceSource**](https://msdn.microsoft.com/library/br224609).</span></span> <span data-ttu-id="55ca5-111">また、[そのサポートを除外する](#opting-out-of-weak-reference-support)ことを明示的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-111">And you can choose explicitly to [opt out of that support](#opting-out-of-weak-reference-support).</span></span>

## <a name="code-examples"></a><span data-ttu-id="55ca5-112">コード例</span><span class="sxs-lookup"><span data-stu-id="55ca5-112">Code examples</span></span>
<span data-ttu-id="55ca5-113">[**winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) 構造体テンプレートは、クラス インスタンスへの弱参照を取得するための 1 つのオプションです。</span><span class="sxs-lookup"><span data-stu-id="55ca5-113">The [**winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) struct template is one option for getting a weak reference to a class instance.</span></span>

```cppwinrt
Class c;
winrt::weak_ref<Class> weak{ c };
```
<span data-ttu-id="55ca5-114">または、[**winrt::make_weak**](/uwp/cpp-ref-for-winrt/make-weak) ヘルパー関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-114">Or, you can use the use the [**winrt::make_weak**](/uwp/cpp-ref-for-winrt/make-weak) helper function.</span></span>

```cppwinrt
Class c;
auto weak = winrt::make_weak(c);
```

<span data-ttu-id="55ca5-115">弱参照を作成してもオブジェクト自体の参照カウントには影響しません。制御ブロックが割り当てられるだけです。</span><span class="sxs-lookup"><span data-stu-id="55ca5-115">Creating a weak reference doesn't affect the reference count on the object itself; it just causes a control block to be allocated.</span></span> <span data-ttu-id="55ca5-116">その制御ブロックが弱参照セマンティクスの実装を処理します。</span><span class="sxs-lookup"><span data-stu-id="55ca5-116">That control block takes care of implementing the weak reference semantics.</span></span> <span data-ttu-id="55ca5-117">その後、弱参照から強参照への昇格を試みて、成功した場合は使用することができます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-117">You can then try to promote the weak reference to a strong reference and, if successful, use it.</span></span>

```cppwinrt
if (Class strong = weak.get())
{
    // use strong, for example strong.DoWork();
}
```

<span data-ttu-id="55ca5-118">他の強参照が存在する場合、[**weak_ref::get**](/uwp/cpp-ref-for-winrt/weak-ref#weakrefget-function) の呼び出しにより参照カウントが増分され、呼び出し元に強参照が返されます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-118">Provided that some other strong reference still exists, the [**weak_ref::get**](/uwp/cpp-ref-for-winrt/weak-ref#weakrefget-function) call increments the reference count and returns the strong reference to the caller.</span></span>

## <a name="a-weak-reference-to-the-this-pointer"></a><span data-ttu-id="55ca5-119">*this* ポインターへの弱参照</span><span class="sxs-lookup"><span data-stu-id="55ca5-119">A weak reference to the *this* pointer</span></span>
<span data-ttu-id="55ca5-120">C++/WinRT オブジェクトは、構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) から直接的または間接的に派生します。</span><span class="sxs-lookup"><span data-stu-id="55ca5-120">A C++/WinRT object directly or indirectly derives from the struct template [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements).</span></span> <span data-ttu-id="55ca5-121">保護されたメンバー関数 [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) は、C++/WinRT オブジェクトの *this* ポインターへの弱参照を返します。</span><span class="sxs-lookup"><span data-stu-id="55ca5-121">The [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) protected member function returns a weak reference to a C++/WinRT object's *this* pointer.</span></span> <span data-ttu-id="55ca5-122">[**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) は、強参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="55ca5-122">[**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) gets a strong reference.</span></span>

## <a name="opting-out-of-weak-reference-support"></a><span data-ttu-id="55ca5-123">弱参照サポートの除外</span><span class="sxs-lookup"><span data-stu-id="55ca5-123">Opting out of weak reference support</span></span>
<span data-ttu-id="55ca5-124">弱参照サポートは自動です。</span><span class="sxs-lookup"><span data-stu-id="55ca5-124">Weak reference support is automatic.</span></span> <span data-ttu-id="55ca5-125">ただし、[**winrt::no_weak_ref**](/uwp/cpp-ref-for-winrt/no-weak-ref) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、そのサポートを明示的に除外することを選択できます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-125">But you can choose explicitly to opt out of that support by passing the [**winrt::no_weak_ref**](/uwp/cpp-ref-for-winrt/no-weak-ref) marker struct as a template argument to your base class.</span></span>

<span data-ttu-id="55ca5-126">**winrt::implements** から直接派生する場合。</span><span class="sxs-lookup"><span data-stu-id="55ca5-126">If you derive directly from **winrt::implements**.</span></span>

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, no_weak_ref>
{
    ...
}
```

<span data-ttu-id="55ca5-127">ランタイム クラスを作成している場合。</span><span class="sxs-lookup"><span data-stu-id="55ca5-127">If you're authoring a runtime class.</span></span>

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, no_weak_ref>
{
    ...
}
```

<span data-ttu-id="55ca5-128">可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。</span><span class="sxs-lookup"><span data-stu-id="55ca5-128">It doesn't matter where in the variadic parameter pack the marker struct appears.</span></span> <span data-ttu-id="55ca5-129">除外された型に対して弱参照を要求すると、コンパイラーは "*これは弱参照サポート専用です*" というメッセージで知らせます。</span><span class="sxs-lookup"><span data-stu-id="55ca5-129">If you request a weak reference for an opted-out type, then the compiler will help you out with "*This is only for weak ref support*".</span></span>

## <a name="important-apis"></a><span data-ttu-id="55ca5-130">重要な API</span><span class="sxs-lookup"><span data-stu-id="55ca5-130">Important APIs</span></span>
* [<span data-ttu-id="55ca5-131">implements::get_weak 関数</span><span class="sxs-lookup"><span data-stu-id="55ca5-131">implements::get_weak function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [<span data-ttu-id="55ca5-132">winrt::make_weak 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="55ca5-132">winrt::make_weak function template</span></span>](/uwp/cpp-ref-for-winrt/make-weak)
* [<span data-ttu-id="55ca5-133">winrt::no_weak_ref マーカー構造体</span><span class="sxs-lookup"><span data-stu-id="55ca5-133">winrt::no_weak_ref marker struct</span></span>](/uwp/cpp-ref-for-winrt/no-weak-ref)
* [<span data-ttu-id="55ca5-134">winrt::weak_ref 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="55ca5-134">winrt::weak_ref struct template</span></span>](/uwp/cpp-ref-for-winrt/weak-ref)
