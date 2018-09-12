---
author: stevewhims
description: C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。
title: 標準的な C++ のデータ型と C++/WinRT
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、データ、型
ms.localizationpriority: medium
ms.openlocfilehash: 0b004b5dfbeaa1d123398db780582382857eec25
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931144"
---
# <a name="standard-c-data-types-and-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="bb88d-104">標準的な C++ のデータ型と [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="bb88d-104">Standard C++ data types and [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="bb88d-105">C++/WinRT では、標準的な C++ データ型 (いくつかの C++ 標準ライブラリのデータ型を含む) を使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-105">With C++/WinRT, you can call Windows Runtime APIs using Standard C++ data types, including some C++ Standard Library data types.</span></span> <span data-ttu-id="bb88d-106">Api を標準の文字列を渡すことができます (を参照してください[文字列の処理では C + + WinRT](strings.md))、渡すことができます初期化子リストと標準のコンテナーと同じ意味のコレクションを必要とする Api とします。</span><span class="sxs-lookup"><span data-stu-id="bb88d-106">You can pass standard strings to APIs (see [String handling in C++/WinRT](strings.md)), and you can pass initializer lists and standard containers to APIs that expect a semantically equivalent collection.</span></span>

## <a name="standard-initializer-lists"></a><span data-ttu-id="bb88d-107">標準的な初期化子リスト</span><span class="sxs-lookup"><span data-stu-id="bb88d-107">Standard initializer lists</span></span>
<span data-ttu-id="bb88d-108">初期化子リスト (**std::initializer_list**) は、C++ 標準ライブラリのコンストラクトです。</span><span class="sxs-lookup"><span data-stu-id="bb88d-108">An initializer list (**std::initializer_list**) is a C++ Standard Library construct.</span></span> <span data-ttu-id="bb88d-109">Windows ランタイムの特定のコンストラクターやメソッドを呼び出すときに初期化子リストを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-109">You can use initializer lists when you call certain Windows Runtime constructors and methods.</span></span> <span data-ttu-id="bb88d-110">たとえば、[**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-110">For example, you can call [**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) with one.</span></span>

```cppwinrt
#include <winrt/Windows.Storage.Streams.h>

using namespace winrt::Windows::Storage::Streams;

int main()
{
    winrt::init_apartment();

    InMemoryRandomAccessStream stream;
    DataWriter dataWriter{stream};
    dataWriter.WriteBytes({ 99, 98, 97 }); // the initializer list is converted to an array_view before being passed to WriteBytes.
}
```

<span data-ttu-id="bb88d-111">この作業には 2 つの部分が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bb88d-111">There are two pieces involved in making this work.</span></span> <span data-ttu-id="bb88d-112">最初に、**DataWriter::WriteBytes** メソッドは型が [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) であるパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bb88d-112">First, the **DataWriter::WriteBytes** method takes a parameter of type [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view).</span></span>

```cppwinrt
void WriteBytes(array_view<uint8_t const> value) const
```

 <span data-ttu-id="bb88d-113">**array_view** は C++/WinRT のカスタム型で、連続した一連の値を安全に表します (C++/WinRT 基本ライブラリ、`%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h` で定義されています)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-113">**array_view** is a custom C++/WinRT type that safely represents a contiguous series of values (it is defined in the C++/WinRT base library, which is `%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h`).</span></span>

<span data-ttu-id="bb88d-114">2 番目に、**array_view** は初期化子リスト コンストラクターを持っています。</span><span class="sxs-lookup"><span data-stu-id="bb88d-114">Second, **array_view** has an initializer-list constructor.</span></span>

```cppwinrt
template <typename T> array_view(std::initializer_list<T> value) noexcept
```

<span data-ttu-id="bb88d-115">多くの場合、プログラミングで **array_view** を認識するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-115">In many cases, you can choose whether or not to be aware of **array_view** in your programming.</span></span> <span data-ttu-id="bb88d-116">認識*しない*ことを選択する場合は、対応する型が C++ 標準ライブラリに現れる場合に変更すべきコードはありません。</span><span class="sxs-lookup"><span data-stu-id="bb88d-116">If you choose *not* to be aware of it then you won't have any code to change if and when an equivalent type appears in the C++ Standard Library.</span></span>

<span data-ttu-id="bb88d-117">コレクション パラメーターを予期している Windows ランタイム API に初期化子リストを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-117">You can pass an initializer list to a Windows Runtime API that expects a collection parameter.</span></span> <span data-ttu-id="bb88d-118">たとえば **StorageItemContentProperties::RetrievePropertiesAsync** です。</span><span class="sxs-lookup"><span data-stu-id="bb88d-118">Take **StorageItemContentProperties::RetrievePropertiesAsync** for example.</span></span>

```cppwinrt
IAsyncOperation<IMap<winrt::hstring, IInspectable>> StorageItemContentProperties::RetrievePropertiesAsync(IIterable<winrt::hstring> propertiesToRetrieve) const;
```

<span data-ttu-id="bb88d-119">次のような初期化子リストを使用してその API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-119">You can call that API with an initializer list like this.</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync({ L"System.ItemUrl" }) };
}
```

<span data-ttu-id="bb88d-120">ここでは、2 つの要因が作用しています。</span><span class="sxs-lookup"><span data-stu-id="bb88d-120">Two factors are at work here.</span></span> <span data-ttu-id="bb88d-121">最初に、呼び出し先が初期化子リストから **std::vector** を作成します (この呼び出し先は非同期であるため、そのオブジェクトを所有することができます。これは必須です)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-121">First, the callee constructs a **std::vector** from the initializer list (this callee is async, so it's able to own that object, which it must).</span></span> <span data-ttu-id="bb88d-122">2 番目に、C++/WinRT は、**std::vector** を Windows ランタイムのコレクション パラメーターとして透過的に (およびコピーを導入せずに) バインドします。</span><span class="sxs-lookup"><span data-stu-id="bb88d-122">Second, C++/WinRT transparently (and without introducing copies) binds **std::vector** as a Windows Runtime collection parameter.</span></span>

## <a name="standard-arrays-and-vectors"></a><span data-ttu-id="bb88d-123">標準的な配列とベクトル</span><span class="sxs-lookup"><span data-stu-id="bb88d-123">Standard arrays and vectors</span></span>
<span data-ttu-id="bb88d-124">**array_view** は、**std::vector** および **std::array** からの変換コンストラクターも持っています。</span><span class="sxs-lookup"><span data-stu-id="bb88d-124">**array_view** also has conversion constructors from **std::vector** and **std::array**.</span></span>

```cppwinrt
template <typename C, size_type N> array_view(std::array<C, N>& value) noexcept
template <typename C> array_view(std::vector<C>& vectorValue) noexcept
```

<span data-ttu-id="bb88d-125">したがって、代わりに **std::vector** を使用して **DataWriter::WriteBytes** を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-125">So, you could instead call **DataWriter::WriteBytes** with a **std::vector**.</span></span>

```cppwinrt
std::vector<byte> theVector{ 99, 98, 97 };
dataWriter.WriteBytes(theVector); // theVector is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="bb88d-126">または、**std::array** を使用します。</span><span class="sxs-lookup"><span data-stu-id="bb88d-126">Or with a **std::array**.</span></span>

```cppwinrt
std::array<byte, 3> theArray{ 99, 98, 97 };
dataWriter.WriteBytes(theArray); // theArray is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="bb88d-127">C++/WinRT は、Windows ランタイムのコレクション パラメーターとして **std::vector** をバインドします。</span><span class="sxs-lookup"><span data-stu-id="bb88d-127">C++/WinRT binds **std::vector** as a Windows Runtime collection parameter.</span></span> <span data-ttu-id="bb88d-128">したがって、**std::vector&lt;winrt::hstring&gt;** を渡すと、Windows ランタイムの適切な **winrt::hstring** のコレクションに変換されます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-128">So, you can pass a **std::vector&lt;winrt::hstring&gt;**, and it will be converted to the appropriate Windows Runtime collection of **winrt::hstring**.</span></span> <span data-ttu-id="bb88d-129">呼び出しが非同期の場合を念頭に、追加の詳細があります。</span><span class="sxs-lookup"><span data-stu-id="bb88d-129">There's an extra detail to bear in mind if the callee is asynchronous.</span></span> <span data-ttu-id="bb88d-130">そのケースの実装の詳細のためのベクトルの移動やコピーを提供する必要がありますので、右辺値を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb88d-130">Due to the implementation details of that case, you'll need to provide an rvalue, so you must provide a copy or a move of the vector.</span></span> <span data-ttu-id="bb88d-131">次のコード例で移動ベクトルの所有権、非同期呼び出しで許可されるパラメーターの型のオブジェクト (し、私たちはアクセスしないように注意してください`vecH`移行した後にもう一度)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-131">In the code example below, we move ownership of the vector to the object of the parameter type accepted by the async callee (and then we're careful not to access `vecH` again after moving it).</span></span> <span data-ttu-id="bb88d-132">Rvalue の詳細を把握したい場合は、[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bb88d-132">If you want to know more about rvalues, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const storageFile, std::vector<winrt::hstring> vecH)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecH)) };
}
```

<span data-ttu-id="bb88d-133">ただし、Windows ランタイムのコレクションが予期されているところに **std::vector&lt;std::wstring&gt;** を渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="bb88d-133">But you can't pass a **std::vector&lt;std::wstring&gt;** where a Windows Runtime collection is expected.</span></span> <span data-ttu-id="bb88d-134">これは、Windows ランタイムの適切な **std::wstring** のコレクションに変換されたため、C++ 言語がそのコレクションの型パラメーターを強制的に変換しないことが原因です。</span><span class="sxs-lookup"><span data-stu-id="bb88d-134">This is because, having converted to the appropriate Windows Runtime collection of **std::wstring**, the C++ language won't then coerce that collection's type parameter(s).</span></span> <span data-ttu-id="bb88d-135">その結果、次のコード例はコンパイルされません (ソリューションは、渡すことと、 **std::vector&lt;winrt::hstring&gt;** 代わりに、上記のように)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-135">Consequently, the following code example won't compile (and the solution is to pass a **std::vector&lt;winrt::hstring&gt;** instead, as shown above).</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<std::wstring> const& vecW)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecW)) }; // error! Can't convert from vector of wstring to async_iterable of hstring.
}
```

## <a name="raw-arrays-and-pointer-ranges"></a><span data-ttu-id="bb88d-136">未処理配列、およびポインターの範囲</span><span class="sxs-lookup"><span data-stu-id="bb88d-136">Raw arrays, and pointer ranges</span></span>
<span data-ttu-id="bb88d-137">将来の C++ 標準ライブラリで対応する型が存在する可能性があることに注意して、選択する場合、または必要に応じて、**array_view** を直接操作することもできます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-137">Bearing in mind the caveat that an equivalent type may exist in the future in the C++ Standard Library, you can also work directly with **array_view** if you choose to, or need to.</span></span>

<span data-ttu-id="bb88d-138">**array_view**の範囲と、生の配列からの変換のコンス トラクターには\*\*T&ast; \*\* (要素の型へのポインター)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-138">**array_view** has conversion constructors from a raw array, and from a range of **T&ast;** (pointers to the element type).</span></span>

```cppwinrt
using namespace winrt;
...
byte theRawArray[]{ 99, 98, 97 };
array_view<byte const> fromRawArray{ theRawArray };
dataWriter.WriteBytes(fromRawArray); // the array_view is passed to WriteBytes.

array_view<byte const> fromRange{ theArray.data(), theArray.data() + 2 }; // just the first two elements.
dataWriter.WriteBytes(fromRange); // the array_view is passed to WriteBytes.
```

## <a name="winrtarrayview-functions-and-operators"></a><span data-ttu-id="bb88d-139">winrt::array_view の関数と演算子</span><span class="sxs-lookup"><span data-stu-id="bb88d-139">winrt::array_view functions and operators</span></span>
<span data-ttu-id="bb88d-140">コンストラクター、演算子、関数、および反復子のホストが **array_view** に対して実装されています。</span><span class="sxs-lookup"><span data-stu-id="bb88d-140">A host of constructors, operators, functions, and iterators are implemented for **array_view**.</span></span> <span data-ttu-id="bb88d-141">**array_view** は範囲であるため、範囲ベースの `for`、または **std::for_each** で使用できます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-141">An **array_view** is a range, so you can use it with range-based `for`, or with **std::for_each**.</span></span>

<span data-ttu-id="bb88d-142">その他の例や詳細については、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bb88d-142">For more examples and info, see the [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API reference topic.</span></span>

## <a name="ivectorlttgt-and-standard-iteration-constructs"></a><span data-ttu-id="bb88d-143">**IVector&lt;T&gt;** と標準的な繰り返し構造</span><span class="sxs-lookup"><span data-stu-id="bb88d-143">**IVector&lt;T&gt;** and standard iteration constructs</span></span>
<span data-ttu-id="bb88d-144">型のコレクションを取得する Windows ランタイム API の例では[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) [\*\*IVector&lt;T&gt; \*\*](/uwp/api/windows.foundation.collections.ivector_t_) (C + に投影/WinRT と\*\*winrt::Windows::Foundation::Collections::IVector&lt;T&gt; \*\*).</span><span class="sxs-lookup"><span data-stu-id="bb88d-144">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) is an example of a Windows Runtime API that returns a collection of type [**IVector&lt;T&gt;**](/uwp/api/windows.foundation.collections.ivector_t_) (projected into C++/WinRT as **winrt::Windows::Foundation::Collections::IVector&lt;T&gt;**).</span></span> <span data-ttu-id="bb88d-145">標準の繰り返しの構造を持つなど、このタイプを使用できる範囲に基づく`for`。</span><span class="sxs-lookup"><span data-stu-id="bb88d-145">You can use this type with standard iteration constructs, such as range-based `for`.</span></span>

```cppwinrt
// main.cpp
#include "pch.h"
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed const& syndicationFeed)
{
    for (SyndicationItem const& syndicationItem : syndicationFeed.Items())
    {
        std::wcout << syndicationItem.Title().Text().c_str() << std::endl;
    }
}
```

## <a name="c-coroutines-with-asynchronous-windows-runtime-apis"></a><span data-ttu-id="bb88d-146">非同期 Windows ランタイム Api と C++ のコルーチン</span><span class="sxs-lookup"><span data-stu-id="bb88d-146">C++ coroutines with asynchronous Windows Runtime APIs</span></span>
<span data-ttu-id="bb88d-147">非同期 Windows ランタイム Api を呼び出す場合は、[並列パターン ライブラリ (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl)を使用して続行することができます。</span><span class="sxs-lookup"><span data-stu-id="bb88d-147">You can continue to use the [Parallel Patterns Library (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl) when calling asynchronous Windows Runtime APIs.</span></span> <span data-ttu-id="bb88d-148">ただし、多くの場合、C++ コルーチンを提供、効率的でより簡単にコーディング手法非同期オブジェクトと対話するためです。</span><span class="sxs-lookup"><span data-stu-id="bb88d-148">However, in many cases, C++ coroutines provide an efficient and more easily-coded idiom for interacting with asynchronous objects.</span></span> <span data-ttu-id="bb88d-149">詳細な情報、およびコード例についてを参照してください[同時実行性と C + を使用して非同期の操作/WinRT](concurrency.md)。</span><span class="sxs-lookup"><span data-stu-id="bb88d-149">For more info, and code examples, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

## <a name="important-apis"></a><span data-ttu-id="bb88d-150">重要な API</span><span class="sxs-lookup"><span data-stu-id="bb88d-150">Important APIs</span></span>
* [<span data-ttu-id="bb88d-151">IVector&lt;T&gt;インタ フェース</span><span class="sxs-lookup"><span data-stu-id="bb88d-151">IVector&lt;T&gt; interface</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="bb88d-152">winrt::array_view 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="bb88d-152">winrt::array_view struct template</span></span>](/uwp/cpp-ref-for-winrt/array-view)

## <a name="related-topics"></a><span data-ttu-id="bb88d-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bb88d-153">Related topics</span></span>
* [<span data-ttu-id="bb88d-154">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="bb88d-154">String handling in C++/WinRT</span></span>](strings.md)
