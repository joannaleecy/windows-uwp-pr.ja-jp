---
description: アジャイル オブジェクトは、いずれかのスレッドからアクセスできます。 お使いの C++/WinRT 型は既定ではアジャイルですが、オプトアウトできます。
title: C++/WinRT でのアジャイル オブジェクト
ms.date: 10/20/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、アジャイル、オブジェクト、アジリティ、IAgileObject
ms.localizationpriority: medium
ms.openlocfilehash: 2481396d9348250e14ebfc2d1f940b663b405f77
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639667"
---
# <a name="agile-objects-in-cwinrt"></a><span data-ttu-id="cccad-105">アジャイル オブジェクト c++/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="cccad-105">Agile objects in C++/WinRT</span></span>

<span data-ttu-id="cccad-106">ほとんどの場合に、Windows ランタイム クラスのインスタンスを (ほとんどの標準の C++ オブジェクトは、次のこと) と同様、どのスレッドからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="cccad-106">In the vast majority of cases, an instance of a Windows Runtime class can be accessed from any thread (just like most standard C++ objects can).</span></span> <span data-ttu-id="cccad-107">このような Windows ランタイム クラスは、*アジャイル*します。</span><span class="sxs-lookup"><span data-stu-id="cccad-107">Such a Windows Runtime class is *agile*.</span></span> <span data-ttu-id="cccad-108">Windows に付属する Windows ランタイム クラスの数が少ないは非アジャイルですがそれらを使用する場合は、スレッド モデルとマーシャ リング動作を考慮する必要がありますのみ (マーシャ リング データが渡されるアパートメントの境界を越えて)。</span><span class="sxs-lookup"><span data-stu-id="cccad-108">Only a small number of Windows Runtime classes that ship with Windows are non-agile, but when you consume them you need to take into consideration their threading model and marshaling behavior (marshaling is passing data across an apartment boundary).</span></span> <span data-ttu-id="cccad-109">俊敏性を高め、すべての Windows ランタイム オブジェクトの適切な既定値は、独自[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)型が既定でアジャイルです。</span><span class="sxs-lookup"><span data-stu-id="cccad-109">It's a good default for every Windows Runtime object to be agile, so your own [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) types are agile by default.</span></span>

<span data-ttu-id="cccad-110">ただし、オプトアウトできます。配置、たとえば、シングル スレッド アパートメントで、型のオブジェクトを必要とする特別な理由があります。</span><span class="sxs-lookup"><span data-stu-id="cccad-110">But you can opt out. You might have a compelling reason to require an object of your type to reside, for example, in a given single-threaded apartment.</span></span> <span data-ttu-id="cccad-111">これは通常、再入の要件で行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cccad-111">This typically has to do with reentrancy requirements.</span></span> <span data-ttu-id="cccad-112">それでもますます、ユーザー インターフェイス (UI) API ではアジャイル オブジェクトを提供するようになっています。</span><span class="sxs-lookup"><span data-stu-id="cccad-112">But increasingly, even user interface (UI) APIs offer agile objects.</span></span> <span data-ttu-id="cccad-113">一般に、アジリティは最も単純で最もパフォーマンスの高いオプションです。</span><span class="sxs-lookup"><span data-stu-id="cccad-113">In general, agility is the simplest and most performant option.</span></span> <span data-ttu-id="cccad-114">また、アクティベーション ファクトリを実装する際は、対応するランタイム クラスがアジャイルではない場合でもアジャイルにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cccad-114">Also, when you implement an activation factory, it must be agile even if your corresponding runtime class isn't.</span></span>

> [!NOTE]
> <span data-ttu-id="cccad-115">Windows ランタイムは COM に基づいています。</span><span class="sxs-lookup"><span data-stu-id="cccad-115">The Windows Runtime is based on COM.</span></span> <span data-ttu-id="cccad-116">COM の用語では、アジャイル クラスは `ThreadingModel` = *両方*に登録されています。</span><span class="sxs-lookup"><span data-stu-id="cccad-116">In COM terms, an agile class is registered with `ThreadingModel` = *Both*.</span></span> <span data-ttu-id="cccad-117">COM スレッド モデル、およびアパートメントの詳細については、次を参照してください。 [COM スレッド モデルを使用すると理解](https://msdn.microsoft.com/library/ms809971)します。</span><span class="sxs-lookup"><span data-stu-id="cccad-117">For more info about COM threading models, and apartments, see [Understanding and Using COM Threading Models](https://msdn.microsoft.com/library/ms809971).</span></span>

## <a name="code-examples"></a><span data-ttu-id="cccad-118">コード例</span><span class="sxs-lookup"><span data-stu-id="cccad-118">Code examples</span></span>

<span data-ttu-id="cccad-119">説明するためにランタイム クラスの実装例を使用してみましょうか C +/cli WinRT 機敏性をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="cccad-119">Let's use an example implementation of a runtime class to illustrate how C++/WinRT supports agility.</span></span>

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

struct MyType : winrt::implements<MyType, IStringable>
{
    winrt::hstring ToString(){ ... }
};
```

<span data-ttu-id="cccad-120">オプトアウトしていないため、この実装はアジャイルです。</span><span class="sxs-lookup"><span data-stu-id="cccad-120">Because we haven't opted out, this implementation is agile.</span></span> <span data-ttu-id="cccad-121">[  **Winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体は [**IAgileObject**](https://msdn.microsoft.com/library/windows/desktop/hh802476) と [**IMarshal**](/windows/desktop/api/objidl/nn-objidl-imarshal) を実装します。</span><span class="sxs-lookup"><span data-stu-id="cccad-121">The [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct implements [**IAgileObject**](https://msdn.microsoft.com/library/windows/desktop/hh802476) and [**IMarshal**](/windows/desktop/api/objidl/nn-objidl-imarshal).</span></span> <span data-ttu-id="cccad-122">**IMarshal** 実装は、**IAgileObject** について知らないレガシー コードで適切な処理を行うために **CoCreateFreeThreadedMarshaler** を使用します。</span><span class="sxs-lookup"><span data-stu-id="cccad-122">The **IMarshal** implementation uses **CoCreateFreeThreadedMarshaler** to do the right thing for legacy code that doesn't know about **IAgileObject**.</span></span>

<span data-ttu-id="cccad-123">このコードでは、オブジェクトのアジリティを確認します。</span><span class="sxs-lookup"><span data-stu-id="cccad-123">This code checks an object for agility.</span></span> <span data-ttu-id="cccad-124">`myimpl` がアジャイルではない場合に [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) の呼び出しで例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="cccad-124">The call to [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) throws an exception if `myimpl` is not agile.</span></span>

```cppwinrt
winrt::com_ptr<MyType> myimpl{ winrt::make_self<MyType>() };
winrt::com_ptr<IAgileObject> iagileobject{ myimpl.as<IAgileObject>() };
```

<span data-ttu-id="cccad-125">例外を処理する代わりに、[**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="cccad-125">Rather than handle an exception, you can call [**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) instead.</span></span>

```cppwinrt
winrt::com_ptr<IAgileObject> iagileobject{ myimpl.try_as<IAgileObject>() };
if (iagileobject) { /* myimpl is agile. */ }
```

<span data-ttu-id="cccad-126">**IAgileObject** には独自のメソッドがないため、これを使用してできることは多くありません。</span><span class="sxs-lookup"><span data-stu-id="cccad-126">**IAgileObject** has no methods of its own, so you can't do much with it.</span></span> <span data-ttu-id="cccad-127">この次のバリアントはより一般的です。</span><span class="sxs-lookup"><span data-stu-id="cccad-127">This next variant, then, is more typical.</span></span>

```cppwinrt
if (myimpl.try_as<IAgileObject>()) { /* myimpl is agile. */ }
```

<span data-ttu-id="cccad-128">**IAgileObject** は、*マーカー インターフェイス*です。</span><span class="sxs-lookup"><span data-stu-id="cccad-128">**IAgileObject** is a *marker interface*.</span></span> <span data-ttu-id="cccad-129">**IAgileObject** へのクエリの単なる成功または失敗が、それから得られる情報とユーティリティの範囲です。</span><span class="sxs-lookup"><span data-stu-id="cccad-129">The mere success or failure of querying for **IAgileObject** is the extent of the information and utility you get from it.</span></span>

## <a name="opting-out-of-agile-object-support"></a><span data-ttu-id="cccad-130">アジャイル オブジェクトのサポートのオプトアウト</span><span class="sxs-lookup"><span data-stu-id="cccad-130">Opting out of agile object support</span></span>

<span data-ttu-id="cccad-131">[  **winrt::non_agile**](/uwp/cpp-ref-for-winrt/non-agile) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、アジャイル オブジェクトのサポートを明示的にオプトアウトすることを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="cccad-131">You can choose explicitly to opt out of agile object support by passing the [**winrt::non_agile**](/uwp/cpp-ref-for-winrt/non-agile) marker struct as a template argument to your base class.</span></span>

<span data-ttu-id="cccad-132">**winrt::implements** から直接派生する場合。</span><span class="sxs-lookup"><span data-stu-id="cccad-132">If you derive directly from **winrt::implements**.</span></span>

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, winrt::non_agile>
{
    ...
}
```

<span data-ttu-id="cccad-133">ランタイム クラスを作成している場合。</span><span class="sxs-lookup"><span data-stu-id="cccad-133">If you're authoring a runtime class.</span></span>

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, winrt::non_agile>
{
    ...
}
```

<span data-ttu-id="cccad-134">可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。</span><span class="sxs-lookup"><span data-stu-id="cccad-134">It doesn't matter where in the variadic parameter pack the marker struct appears.</span></span>

<span data-ttu-id="cccad-135">機敏性をオプトアウトするかどうかを実装できます**IMarshal**自分でします。</span><span class="sxs-lookup"><span data-stu-id="cccad-135">Whether or not you opt out of agility, you can implement **IMarshal** yourself.</span></span> <span data-ttu-id="cccad-136">たとえば、使用することができます、 **winrt::non_agile**を既定の機敏性の実装を回避し、実装のマーカー **IMarshal**自分で&mdash;値渡しのマーシャ リング セマンティクスをサポートする場合。</span><span class="sxs-lookup"><span data-stu-id="cccad-136">For example, you can use the **winrt::non_agile** marker to avoid the default agility implementation, and implement **IMarshal** yourself&mdash;perhaps to support marshal-by-value semantics.</span></span>

## <a name="agile-references-winrtagileref"></a><span data-ttu-id="cccad-137">アジャイル リファレンス (winrt::agile_ref)</span><span class="sxs-lookup"><span data-stu-id="cccad-137">Agile references (winrt::agile_ref)</span></span>

<span data-ttu-id="cccad-138">アジャイルではないオブジェクトを使用していて、ただしいくつかの可能性のあるアジャイルのコンテキストでそれを渡す必要がある場合、1 つのオプションは、[**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref) 構造体のテンプレートを使用して、非アジャイル型のインスタンス、または非アジャイル オブジェクトのインターフェイスへのアジャイルのリファレンスを取得することです。</span><span class="sxs-lookup"><span data-stu-id="cccad-138">If you're consuming an object that isn't agile, but you need to pass it around in some potentially agile context, then one option is to use the [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref) struct template to get an agile reference to an instance of a non-agile type, or to an interface of a non-agile object.</span></span>

```cppwinrt
NonAgileType nonagile_obj;
winrt::agile_ref<NonAgileType> agile{ nonagile_obj };
```

<span data-ttu-id="cccad-139">または、[**winrt::make_agile**](/uwp/cpp-ref-for-winrt/make-agile) ヘルパー関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cccad-139">Or, you can use the use the [**winrt::make_agile**](/uwp/cpp-ref-for-winrt/make-agile) helper function.</span></span>

```cppwinrt
NonAgileType nonagile_obj;
auto agile{ winrt::make_agile(nonagile_obj) };
```

<span data-ttu-id="cccad-140">どちらの場合でも、`agile` を異なるアパートメント内のスレッドに自由に渡して、そこで使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="cccad-140">In either case, `agile` may now be freely passed to a thread in a different apartment, and used there.</span></span>

```cppwinrt
co_await resume_background();
NonAgileType nonagile_obj_again{ agile.get() };
winrt::hstring message{ nonagile_obj_again.Message() };
```

<span data-ttu-id="cccad-141">[  **Agile_ref::get**](/uwp/cpp-ref-for-winrt/agile-ref#agilerefget-function) の呼び出しでは、**get** が呼びだされたスレッド コンテキスト内で安全に使用できるプロキシを返します。</span><span class="sxs-lookup"><span data-stu-id="cccad-141">The [**agile_ref::get**](/uwp/cpp-ref-for-winrt/agile-ref#agilerefget-function) call returns a proxy that may safely be used within the thread context in which **get** is called.</span></span>

## <a name="important-apis"></a><span data-ttu-id="cccad-142">重要な API</span><span class="sxs-lookup"><span data-stu-id="cccad-142">Important APIs</span></span>

* [<span data-ttu-id="cccad-143">IAgileObject インターフェイス</span><span class="sxs-lookup"><span data-stu-id="cccad-143">IAgileObject interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh802476)
* [<span data-ttu-id="cccad-144">IMarshal インターフェイス</span><span class="sxs-lookup"><span data-stu-id="cccad-144">IMarshal interface</span></span>](https://docs.microsoft.com/previous-versions/windows/embedded/ms887993)
* [<span data-ttu-id="cccad-145">winrt::agile_ref 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="cccad-145">winrt::agile_ref struct template</span></span>](/uwp/cpp-ref-for-winrt/agile-ref)
* [<span data-ttu-id="cccad-146">winrt::implements 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="cccad-146">winrt::implements struct template</span></span>](/uwp/cpp-ref-for-winrt/implements)
* [<span data-ttu-id="cccad-147">winrt::make_agile 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="cccad-147">winrt::make_agile function template</span></span>](/uwp/cpp-ref-for-winrt/make-agile)
* [<span data-ttu-id="cccad-148">winrt::non_agile マーカー構造体</span><span class="sxs-lookup"><span data-stu-id="cccad-148">winrt::non_agile marker struct</span></span>](/uwp/cpp-ref-for-winrt/non-agile)
* [<span data-ttu-id="cccad-149">winrt::Windows::Foundation::IUnknown:: 関数として</span><span class="sxs-lookup"><span data-stu-id="cccad-149">winrt::Windows::Foundation::IUnknown::as function</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [<span data-ttu-id="cccad-150">winrt::Windows::Foundation::IUnknown::try_as 関数</span><span class="sxs-lookup"><span data-stu-id="cccad-150">winrt::Windows::Foundation::IUnknown::try_as function</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)

## <a name="related-topics"></a><span data-ttu-id="cccad-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cccad-151">Related topics</span></span>

* [<span data-ttu-id="cccad-152">理解し、COM スレッド モデルの使用</span><span class="sxs-lookup"><span data-stu-id="cccad-152">Understanding and Using COM Threading Models</span></span>](https://msdn.microsoft.com/library/ms809971)
