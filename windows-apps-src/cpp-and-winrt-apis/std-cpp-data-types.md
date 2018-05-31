---
author: stevewhims
description: C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。
title: 標準的な C++ のデータ型と C++/WinRT
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、データ、型
ms.localizationpriority: medium
ms.openlocfilehash: ccf79b1ec21688d9573e62777def8f15295c3fca
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832076"
---
# <a name="standard-c-data-types-and-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="14a18-104">標準的な C++ のデータ型と [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="14a18-104">Standard C++ data types and [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="14a18-105">C++/WinRT では、標準的な C++ データ型 (いくつかの C++ 標準ライブラリのデータ型を含む) を使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-105">With C++/WinRT, you can call Windows Runtime APIs using Standard C++ data types, including some C++ Standard Library data types.</span></span>

## <a name="standard-initializer-lists"></a><span data-ttu-id="14a18-106">標準的な初期化子リスト</span><span class="sxs-lookup"><span data-stu-id="14a18-106">Standard initializer lists</span></span>
<span data-ttu-id="14a18-107">初期化子リスト (**std::initializer_list**) は、C++ 標準ライブラリのコンストラクトです。</span><span class="sxs-lookup"><span data-stu-id="14a18-107">An initializer list (**std::initializer_list**) is a C++ Standard Library construct.</span></span> <span data-ttu-id="14a18-108">Windows ランタイムの特定のコンストラクターやメソッドを呼び出すときに初期化子リストを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-108">You can use initializer lists when you call certain Windows Runtime constructors and methods.</span></span> <span data-ttu-id="14a18-109">たとえば、[**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-109">For example, you can call [**DataWriter::WriteBytes**](/uwp/api/windows.storage.streams.datawriter.writebytes) with one.</span></span>

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

<span data-ttu-id="14a18-110">この作業には 2 つの部分が含まれています。</span><span class="sxs-lookup"><span data-stu-id="14a18-110">There are two pieces involved in making this work.</span></span> <span data-ttu-id="14a18-111">最初に、**DataWriter::WriteBytes** メソッドは型が [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) であるパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="14a18-111">First, the **DataWriter::WriteBytes** method takes a parameter of type [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view).</span></span>

```cppwinrt
void WriteBytes(array_view<uint8_t const> value) const
```

 <span data-ttu-id="14a18-112">**array_view** は C++/WinRT のカスタム型で、連続した一連の値を安全に表します (C++/WinRT 基本ライブラリ、`%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h` で定義されています)。</span><span class="sxs-lookup"><span data-stu-id="14a18-112">**array_view** is a custom C++/WinRT type that safely represents a contiguous series of values (it is defined in the C++/WinRT base library, which is `%WindowsSdkDir%Include\<WindowsTargetPlatformVersion>\cppwinrt\winrt\base.h`).</span></span>

<span data-ttu-id="14a18-113">2 番目に、**array_view** は初期化子リスト コンストラクターを持っています。</span><span class="sxs-lookup"><span data-stu-id="14a18-113">Second, **array_view** has an initializer-list constructor.</span></span>

```cppwinrt
template <typename T> array_view(std::initializer_list<T> value) noexcept
```

<span data-ttu-id="14a18-114">多くの場合、プログラミングで **array_view** を認識するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="14a18-114">In many cases, you can choose whether or not to be aware of **array_view** in your programming.</span></span> <span data-ttu-id="14a18-115">認識*しない*ことを選択する場合は、対応する型が C++ 標準ライブラリに現れる場合に変更すべきコードはありません。</span><span class="sxs-lookup"><span data-stu-id="14a18-115">If you choose *not* to be aware of it then you won't have any code to change if and when an equivalent type appears in the C++ Standard Library.</span></span>

<span data-ttu-id="14a18-116">コレクション パラメーターを予期している Windows ランタイム API に初期化子リストを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-116">You can pass an initializer list to a Windows Runtime API that expects a collection parameter.</span></span> <span data-ttu-id="14a18-117">たとえば **StorageItemContentProperties::RetrievePropertiesAsync** です。</span><span class="sxs-lookup"><span data-stu-id="14a18-117">Take **StorageItemContentProperties::RetrievePropertiesAsync** for example.</span></span>

```cppwinrt
IAsyncOperation<IMap<winrt::hstring, IInspectable>> StorageItemContentProperties::RetrievePropertiesAsync(IIterable<winrt::hstring> propertiesToRetrieve) const;
```

<span data-ttu-id="14a18-118">次のような初期化子リストを使用してその API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-118">You can call that API with an initializer list like this.</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile)
{
    auto properties = co_await storageFile.Properties().RetrievePropertiesAsync({ L"System.ItemUrl" });
}
```

<span data-ttu-id="14a18-119">ここでは、2 つの要因が作用しています。</span><span class="sxs-lookup"><span data-stu-id="14a18-119">Two factors are at work here.</span></span> <span data-ttu-id="14a18-120">最初に、呼び出し先が初期化子リストから **std::vector** を作成します (この呼び出し先は非同期であるため、そのオブジェクトを所有することができます。これは必須です)。</span><span class="sxs-lookup"><span data-stu-id="14a18-120">First, the callee constructs a **std::vector** from the initializer list (this callee is async, so it's able to own that object, which it must).</span></span> <span data-ttu-id="14a18-121">2 番目に、C++/WinRT は、**std::vector** を Windows ランタイムのコレクション パラメーターとして透過的に (およびコピーを導入せずに) バインドします。</span><span class="sxs-lookup"><span data-stu-id="14a18-121">Second, C++/WinRT transparently (and without introducing copies) binds **std::vector** as a Windows Runtime collection parameter.</span></span>

## <a name="standard-arrays-and-vectors"></a><span data-ttu-id="14a18-122">標準的な配列とベクトル</span><span class="sxs-lookup"><span data-stu-id="14a18-122">Standard arrays and vectors</span></span>
<span data-ttu-id="14a18-123">**array_view** は、**std::vector** および **std::array** からの変換コンストラクターも持っています。</span><span class="sxs-lookup"><span data-stu-id="14a18-123">**array_view** also has conversion constructors from **std::vector** and **std::array**.</span></span>

```cppwinrt
template <typename C, size_type N> array_view(std::array<C, N>& value) noexcept
template <typename C> array_view(std::vector<C>& vectorValue) noexcept
```

<span data-ttu-id="14a18-124">したがって、代わりに **std::vector** を使用して **DataWriter::WriteBytes** を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="14a18-124">So, you could instead call **DataWriter::WriteBytes** with a **std::vector**.</span></span>

```cppwinrt
std::vector<byte> theVector{ 99, 98, 97 };
dataWriter.WriteBytes(theVector); // theVector is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="14a18-125">または、**std::array** を使用します。</span><span class="sxs-lookup"><span data-stu-id="14a18-125">Or with a **std::array**.</span></span>

```cppwinrt
std::array<byte, 3> theArray{ 99, 98, 97 };
dataWriter.WriteBytes(theArray); // theArray is converted to an array_view before being passed to WriteBytes.
```

<span data-ttu-id="14a18-126">C++/WinRT は、Windows ランタイムのコレクション パラメーターとして **std::vector** をバインドします。</span><span class="sxs-lookup"><span data-stu-id="14a18-126">C++/WinRT binds **std::vector** as a Windows Runtime collection parameter.</span></span> <span data-ttu-id="14a18-127">したがって、**std::vector&lt;winrt::hstring&gt;** を渡すと、Windows ランタイムの適切な **winrt::hstring** のコレクションに変換されます。</span><span class="sxs-lookup"><span data-stu-id="14a18-127">So, you can pass a **std::vector&lt;winrt::hstring&gt;**, and it will be converted to the appropriate Windows Runtime collection of **winrt::hstring**.</span></span> <span data-ttu-id="14a18-128">呼び出し先が非同期である場合は、ベクトルをコピーまたは移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14a18-128">If the callee is async then you must either copy or move the vector.</span></span> <span data-ttu-id="14a18-129">次のコード例では、ベクトルの所有権を非同期呼び出し先に移行します。</span><span class="sxs-lookup"><span data-stu-id="14a18-129">In the code example below, we move ownership of the vector to the async callee.</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<winrt::hstring> const& vecH)
{
    auto properties = co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecH));
}
```

<span data-ttu-id="14a18-130">ただし、Windows ランタイムのコレクションが予期されているところに **std::vector&lt;std::wstring&gt;** を渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="14a18-130">But you can't pass a **std::vector&lt;std::wstring&gt;** where a Windows Runtime collection is expected.</span></span> <span data-ttu-id="14a18-131">これは、Windows ランタイムの適切な **std::wstring** のコレクションに変換されたため、C++ 言語がそのコレクションの型パラメーターを強制的に変換しないことが原因です。</span><span class="sxs-lookup"><span data-stu-id="14a18-131">This is because, having converted to the appropriate Windows Runtime collection of **std::wstring**, the C++ language won't then coerce that collection's type parameter(s).</span></span> <span data-ttu-id="14a18-132">したがって、次のコード例はコンパイルされません。</span><span class="sxs-lookup"><span data-stu-id="14a18-132">Consequently, the following code example won't compile.</span></span>

```cppwinrt
IAsyncAction retrieve_properties_async(StorageFile const& storageFile, std::vector<std::wstring> const& vecW)
{
    auto properties = co_await storageFile.Properties().RetrievePropertiesAsync(std::move(vecW)); // error! Can't convert from vector of wstring to async_iterable of hstring.
}
```

## <a name="raw-arrays-and-pointer-ranges"></a><span data-ttu-id="14a18-133">未処理配列、およびポインターの範囲</span><span class="sxs-lookup"><span data-stu-id="14a18-133">Raw arrays, and pointer ranges</span></span>
<span data-ttu-id="14a18-134">将来の C++ 標準ライブラリで対応する型が存在する可能性があることに注意して、選択する場合、または必要に応じて、**array_view** を直接操作することもできます。</span><span class="sxs-lookup"><span data-stu-id="14a18-134">Bearing in mind the caveat that an equivalent type may exist in the future in the C++ Standard Library, you can also work directly with **array_view** if you choose to, or need to.</span></span>

<span data-ttu-id="14a18-135">**array_view** は、未加工配列およびさまざまな **T**\* (要素型へのポインター) からの変換コンストラクターを持っています。</span><span class="sxs-lookup"><span data-stu-id="14a18-135">**array_view** has conversion constructors from a raw array, and from a range of **T**\* (pointers to the element type).</span></span>

```cppwinrt
using namespace winrt;
...
byte theRawArray[]{ 99, 98, 97 };
array_view<byte const> fromRawArray{ theRawArray };
dataWriter.WriteBytes(fromRawArray); // the array_view is passed to WriteBytes.

array_view<byte const> fromRange{ theArray.data(), theArray.data() + 2 }; // just the first two elements.
dataWriter.WriteBytes(fromRange); // the array_view is passed to WriteBytes.
```

## <a name="winrtarrayview-functions-and-operators"></a><span data-ttu-id="14a18-136">winrt::array_view の関数と演算子</span><span class="sxs-lookup"><span data-stu-id="14a18-136">winrt::array_view functions and operators</span></span>
<span data-ttu-id="14a18-137">コンストラクター、演算子、関数、および反復子のホストが **array_view** に対して実装されています。</span><span class="sxs-lookup"><span data-stu-id="14a18-137">A host of constructors, operators, functions, and iterators are implemented for **array_view**.</span></span> <span data-ttu-id="14a18-138">**array_view** は範囲であるため、範囲ベースの `for`、または **std::for_each** で使用できます。</span><span class="sxs-lookup"><span data-stu-id="14a18-138">An **array_view** is a range, so you can use it with range-based `for`, or with **std::for_each**.</span></span>

<span data-ttu-id="14a18-139">その他の例や詳細については、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="14a18-139">For more examples and info, see the [**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) API reference topic.</span></span>

## <a name="important-apis"></a><span data-ttu-id="14a18-140">重要な API</span><span class="sxs-lookup"><span data-stu-id="14a18-140">Important APIs</span></span>
* [<span data-ttu-id="14a18-141">winrt::array_view 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="14a18-141">winrt::array_view struct template</span></span>](/uwp/cpp-ref-for-winrt/array-view)
