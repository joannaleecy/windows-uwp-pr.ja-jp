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
ms.openlocfilehash: 729a3c30f84e20a89912b728db1efecc3e54ad9e
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2830391"
---
# <a name="standard-c-data-types-and-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="4e248-104">標準的な C++ のデータ型と [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="4e248-104">Standard C++ data types and [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="4e248-105">C++/WinRT では、標準的な C++ データ型 (いくつかの C++ 標準ライブラリのデータ型を含む) を使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-105">With C++/WinRT, you can call Windows Runtime APIs using Standard C++ data types, including some C++ Standard Library data types.</span></span> <span data-ttu-id="4e248-106">標準の文字列を Api に渡すことができます (を参照してください[文字列で処理 +/WinRT](strings.md))、初期化リストと標準的なコンテナーに渡すと同じ意味のコレクションを期待する Api とします。</span><span class="sxs-lookup"><span data-stu-id="4e248-106">You can pass standard strings to APIs (see [String handling in C++/WinRT](strings.md)), and you can pass initializer lists and standard containers to APIs that expect a semantically equivalent collection.</span></span>

## <a name="standard-initializer-lists"></a><span data-ttu-id="4e248-107">標準的な初期化子リスト</span><span class="sxs-lookup"><span data-stu-id="4e248-107">Standard initializer lists</span></span>
<span data-ttu-id="4e248-108">初期化子リスト (**std::initializer_list**) は、C++ 標準ライブラリのコンストラクトです。</span><span class="sxs-lookup"><span data-stu-id="4e248-108">An initializer list (**std::initializer_list**) is a C++ Standard Library construct.</span></span> <span data-ttu-id="4e248-109">Windows ランタイムの特定のコンストラクターやメソッドを呼び出すときに初期化子リストを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-109">You can use initializer lists when you call certain Windows Runtime constructors and methods.</span></span> <span data-ttu-id="4e248-110">たとえば、[**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-110">For example, you can call [**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) with one.</span></span>

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

<span data-ttu-id="4e248-111">この作業には 2 つの部分が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4e248-111">There are two pieces involved in making this work.</span></span> <span data-ttu-id="4e248-112">最初に、**DataWriter::WriteBytes** メソッドは型が [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) であるパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="4e248-112">First, the **DataWriter::WriteBytes** method takes a parameter of type [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view).</span></span>

```cppwinrt
void WriteBytes(array_view<uint8_t const> value) const
```

 <span data-ttu-id="4e248-113">**array_view** は C++/WinRT のカスタム型で、連続した一連の値を安全に表します (C++/WinRT 基本ライブラリ、`%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h` で定義されています)。</span><span class="sxs-lookup"><span data-stu-id="4e248-113">**array_view** is a custom C++/WinRT type that safely represents a contiguous series of values (it is defined in the C++/WinRT base library, which is `%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h`).</span></span>

<span data-ttu-id="4e248-114">2 番目に、**array_view** は初期化子リスト コンストラクターを持っています。</span><span class="sxs-lookup"><span data-stu-id="4e248-114">Second, **array_view** has an initializer-list constructor.</span></span>

```cppwinrt
template <typename T> array_view(std::initializer_list<T> value) noexcept
```

<span data-ttu-id="4e248-115">多くの場合、プログラミングで **array_view** を認識するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="4e248-115">In many cases, you can choose whether or not to be aware of **array_view** in your programming.</span></span> <span data-ttu-id="4e248-116">認識*しない*ことを選択する場合は、対応する型が C++ 標準ライブラリに現れる場合に変更すべきコードはありません。</span><span class="sxs-lookup"><span data-stu-id="4e248-116">If you choose *not* to be aware of it then you won't have any code to change if and when an equivalent type appears in the C++ Standard Library.</span></span>

<span data-ttu-id="4e248-117">コレクション パラメーターを予期している Windows ランタイム API に初期化子リストを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-117">You can pass an initializer list to a Windows Runtime API that expects a collection parameter.</span></span> <span data-ttu-id="4e248-118">たとえば **StorageItemContentProperties::RetrievePropertiesAsync** です。</span><span class="sxs-lookup"><span data-stu-id="4e248-118">Take **StorageItemContentProperties::RetrievePropertiesAsync** for example.</span></span>

```cppwinrt
IAsyncOperation<IMap<winrt::hstring, IInspectable>> StorageItemContentProperties::RetrievePropertiesAsync(IIterable<winrt::hstring> propertiesToRetrieve) const;
```

<span data-ttu-id="4e248-119">次のような初期化子リストを使用してその API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-119">You can call that API with an initializer list like this.</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync({ L"System.ItemUrl" }) };
}
```

<span data-ttu-id="4e248-120">ここでは、2 つの要因が作用しています。</span><span class="sxs-lookup"><span data-stu-id="4e248-120">Two factors are at work here.</span></span> <span data-ttu-id="4e248-121">最初に、呼び出し先が初期化子リストから **std::vector** を作成します (この呼び出し先は非同期であるため、そのオブジェクトを所有することができます。これは必須です)。</span><span class="sxs-lookup"><span data-stu-id="4e248-121">First, the callee constructs a **std::vector** from the initializer list (this callee is async, so it's able to own that object, which it must).</span></span> <span data-ttu-id="4e248-122">2 番目に、C++/WinRT は、**std::vector** を Windows ランタイムのコレクション パラメーターとして透過的に (およびコピーを導入せずに) バインドします。</span><span class="sxs-lookup"><span data-stu-id="4e248-122">Second, C++/WinRT transparently (and without introducing copies) binds **std::vector** as a Windows Runtime collection parameter.</span></span>

## <a name="standard-arrays-and-vectors"></a><span data-ttu-id="4e248-123">標準的な配列とベクトル</span><span class="sxs-lookup"><span data-stu-id="4e248-123">Standard arrays and vectors</span></span>
<span data-ttu-id="4e248-124">**array_view** は、**std::vector** および **std::array** からの変換コンストラクターも持っています。</span><span class="sxs-lookup"><span data-stu-id="4e248-124">**array_view** also has conversion constructors from **std::vector** and **std::array**.</span></span>

```cppwinrt
template <typename C, size_type N> array_view(std::array<C, N>& value) noexcept
template <typename C> array_view(std::vector<C>& vectorValue) noexcept
```

<span data-ttu-id="4e248-125">したがって、代わりに **std::vector** を使用して **DataWriter::WriteBytes** を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-125">So, you could instead call **DataWriter::WriteBytes** with a **std::vector**.</span></span>

```cppwinrt
std::vector<byte> theVector{ 99, 98, 97 };
dataWriter.WriteBytes(theVector); // theVector is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="4e248-126">または、**std::array** を使用します。</span><span class="sxs-lookup"><span data-stu-id="4e248-126">Or with a **std::array**.</span></span>

```cppwinrt
std::array<byte, 3> theArray{ 99, 98, 97 };
dataWriter.WriteBytes(theArray); // theArray is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="4e248-127">C++/WinRT は、Windows ランタイムのコレクション パラメーターとして **std::vector** をバインドします。</span><span class="sxs-lookup"><span data-stu-id="4e248-127">C++/WinRT binds **std::vector** as a Windows Runtime collection parameter.</span></span> <span data-ttu-id="4e248-128">したがって、**std::vector&lt;winrt::hstring&gt;** を渡すと、Windows ランタイムの適切な **winrt::hstring** のコレクションに変換されます。</span><span class="sxs-lookup"><span data-stu-id="4e248-128">So, you can pass a **std::vector&lt;winrt::hstring&gt;**, and it will be converted to the appropriate Windows Runtime collection of **winrt::hstring**.</span></span> <span data-ttu-id="4e248-129">これは、追加の詳細を呼び出し、非同期場合に注意してください。</span><span class="sxs-lookup"><span data-stu-id="4e248-129">There's an extra detail to bear in mind if the callee is asynchronous.</span></span> <span data-ttu-id="4e248-130">そのケースの実装の詳細が原因では、ベクトルの移動やコピーを提供する必要がありますので、右辺値を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e248-130">Due to the implementation details of that case, you'll need to provide an rvalue, so you must provide a copy or a move of the vector.</span></span> <span data-ttu-id="4e248-131">次のコードの例では、ベクトルの所有権の対象に移動非同期呼び出し先で許可されるパラメーターの種類の (アクセスしないように注意していて [`vecH`移行した後、もう一度)。</span><span class="sxs-lookup"><span data-stu-id="4e248-131">In the code example below, we move ownership of the vector to the object of the parameter type accepted by the async callee (and then we're careful not to access `vecH` again after moving it).</span></span> <span data-ttu-id="4e248-132">詳細については、rvalue したい場合は、[値のカテゴリ、およびへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4e248-132">If you want to know more about rvalues, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const storageFile, std::vector<winrt::hstring> vecH)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecH)) };
}
```

<span data-ttu-id="4e248-133">ただし、Windows ランタイムのコレクションが予期されているところに **std::vector&lt;std::wstring&gt;** を渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="4e248-133">But you can't pass a **std::vector&lt;std::wstring&gt;** where a Windows Runtime collection is expected.</span></span> <span data-ttu-id="4e248-134">これは、Windows ランタイムの適切な **std::wstring** のコレクションに変換されたため、C++ 言語がそのコレクションの型パラメーターを強制的に変換しないことが原因です。</span><span class="sxs-lookup"><span data-stu-id="4e248-134">This is because, having converted to the appropriate Windows Runtime collection of **std::wstring**, the C++ language won't then coerce that collection's type parameter(s).</span></span> <span data-ttu-id="4e248-135">したがって、次の例はコンパイルされません (ソリューションを渡すには、 **std::vector&lt;winrt::hstring&gt;** 代わりに、上記のように) します。</span><span class="sxs-lookup"><span data-stu-id="4e248-135">Consequently, the following code example won't compile (and the solution is to pass a **std::vector&lt;winrt::hstring&gt;** instead, as shown above).</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<std::wstring> const& vecW)
{
    auto properties{ co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecW)) }; // error! Can't convert from vector of wstring to async_iterable of hstring.
}
```

## <a name="raw-arrays-and-pointer-ranges"></a><span data-ttu-id="4e248-136">未処理配列、およびポインターの範囲</span><span class="sxs-lookup"><span data-stu-id="4e248-136">Raw arrays, and pointer ranges</span></span>
<span data-ttu-id="4e248-137">将来の C++ 標準ライブラリで対応する型が存在する可能性があることに注意して、選択する場合、または必要に応じて、**array_view** を直接操作することもできます。</span><span class="sxs-lookup"><span data-stu-id="4e248-137">Bearing in mind the caveat that an equivalent type may exist in the future in the C++ Standard Library, you can also work directly with **array_view** if you choose to, or need to.</span></span>

<span data-ttu-id="4e248-138">**array_view**が変換コンス生配列の場合は、および範囲から**T&ast; ** (要素の種類にポインター)。</span><span class="sxs-lookup"><span data-stu-id="4e248-138">**array_view** has conversion constructors from a raw array, and from a range of **T&ast;** (pointers to the element type).</span></span>

```cppwinrt
using namespace winrt;
...
byte theRawArray[]{ 99, 98, 97 };
array_view<byte const> fromRawArray{ theRawArray };
dataWriter.WriteBytes(fromRawArray); // the array_view is passed to WriteBytes.

array_view<byte const> fromRange{ theArray.data(), theArray.data() + 2 }; // just the first two elements.
dataWriter.WriteBytes(fromRange); // the array_view is passed to WriteBytes.
```

## <a name="winrtarrayview-functions-and-operators"></a><span data-ttu-id="4e248-139">winrt::array_view の関数と演算子</span><span class="sxs-lookup"><span data-stu-id="4e248-139">winrt::array_view functions and operators</span></span>
<span data-ttu-id="4e248-140">コンストラクター、演算子、関数、および反復子のホストが **array_view** に対して実装されています。</span><span class="sxs-lookup"><span data-stu-id="4e248-140">A host of constructors, operators, functions, and iterators are implemented for **array_view**.</span></span> <span data-ttu-id="4e248-141">**array_view** は範囲であるため、範囲ベースの `for`、または **std::for_each** で使用できます。</span><span class="sxs-lookup"><span data-stu-id="4e248-141">An **array_view** is a range, so you can use it with range-based `for`, or with **std::for_each**.</span></span>

<span data-ttu-id="4e248-142">その他の例や詳細については、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4e248-142">For more examples and info, see the [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API reference topic.</span></span>

## <a name="ivectorlttgt-and-standard-iteration-constructs"></a><span data-ttu-id="4e248-143">**IVector&lt;T&gt;** と標準的な繰り返し構造</span><span class="sxs-lookup"><span data-stu-id="4e248-143">**IVector&lt;T&gt;** and standard iteration constructs</span></span>
<span data-ttu-id="4e248-144">型のコレクションを返す Windows ランタイム API の例は、 [**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) [**IVector&lt;T&gt; **](/uwp/api/windows.foundation.collections.ivector_t_) (C + に投影 +/として WinRT **winrt::Windows::Foundation::Collections::IVector&lt;T&gt; **).</span><span class="sxs-lookup"><span data-stu-id="4e248-144">[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) is an example of a Windows Runtime API that returns a collection of type [**IVector&lt;T&gt;**](/uwp/api/windows.foundation.collections.ivector_t_) (projected into C++/WinRT as **winrt::Windows::Foundation::Collections::IVector&lt;T&gt;**).</span></span> <span data-ttu-id="4e248-145">次のような種類を標準的な繰り返しの構成要素で使用できる範囲に基づく`for`します。</span><span class="sxs-lookup"><span data-stu-id="4e248-145">You can use this type with standard iteration constructs, such as range-based `for`.</span></span>

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

## <a name="c-coroutines-with-asynchronous-windows-runtime-apis"></a><span data-ttu-id="4e248-146">非同期の Windows ランタイム api C++ コルーチン</span><span class="sxs-lookup"><span data-stu-id="4e248-146">C++ coroutines with asynchronous Windows Runtime APIs</span></span>
<span data-ttu-id="4e248-147">非同期の Windows ランタイム Api を呼び出すと[並列パターン ライブラリ (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl)を使用する続行することができます。</span><span class="sxs-lookup"><span data-stu-id="4e248-147">You can continue to use the [Parallel Patterns Library (PPL)](/cpp/parallel/concrt/parallel-patterns-library-ppl) when calling asynchronous Windows Runtime APIs.</span></span> <span data-ttu-id="4e248-148">ただし、多くの場合、C++ コルーチン、効率性とより簡単にコーディングの用法に提供非同期のオブジェクトを操作します。</span><span class="sxs-lookup"><span data-stu-id="4e248-148">However, in many cases, C++ coroutines provide an efficient and more easily-coded idiom for interacting with asynchronous objects.</span></span> <span data-ttu-id="4e248-149">その他の情報、およびコードの例では、次を参照してください。[同時実行および非同期の操作と C + +/WinRT](concurrency.md)します。</span><span class="sxs-lookup"><span data-stu-id="4e248-149">For more info, and code examples, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

## <a name="important-apis"></a><span data-ttu-id="4e248-150">重要な API</span><span class="sxs-lookup"><span data-stu-id="4e248-150">Important APIs</span></span>
* [<span data-ttu-id="4e248-151">IVector&lt;T&gt;</span><span class="sxs-lookup"><span data-stu-id="4e248-151">IVector&lt;T&gt;</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="4e248-152">winrt::array_view 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="4e248-152">winrt::array_view struct template</span></span>](/uwp/cpp-ref-for-winrt/array-view)

## <a name="related-topics"></a><span data-ttu-id="4e248-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4e248-153">Related topics</span></span>
* [<span data-ttu-id="4e248-154">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="4e248-154">String handling in C++/WinRT</span></span>](strings.md)