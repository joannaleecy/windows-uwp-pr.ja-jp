---
author: stevewhims
description: C++/WinRT 機能と、多くの時間と労力を実装やコレクションに合格するときに保存する基底クラスを提供します。
title: C++/WinRT でのコレクション
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: e6a0cf8c2798adc59ffcf84381d6bbf64f2ce80e
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5444150"
---
# <a name="collections-with-cwinrt"></a><span data-ttu-id="c3b3d-104">C++/WinRT でのコレクション</span><span class="sxs-lookup"><span data-stu-id="c3b3d-104">Collections with C++/WinRT</span></span>

<span data-ttu-id="c3b3d-105">内部では、Windows ランタイムのコレクションには、単純な移動部分の多くがあります。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-105">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="c3b3d-106">コレクション オブジェクトを Windows ランタイム関数に渡すをしたり、独自のコレクションのプロパティとコレクション型を実装する場合に、関数とで基底クラスですが[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)をサポートします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-106">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) to support you.</span></span> <span data-ttu-id="c3b3d-107">これらの機能は、手の複雑さを解消し、時間と労力で、多くのオーバーヘッドを保存します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-107">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

<span data-ttu-id="c3b3d-108">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、要素のランダム アクセス コレクションによって実装された Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-108">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="c3b3d-109">**IVector**を実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要はもします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-109">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="c3b3d-110">入力する*必要がある*カスタム コレクション場合でも、多くの作業があります。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-110">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="c3b3d-111">**Std::vector** ( **std::map**、または**std::unordered_map**) 内のデータがあり、Windows ランタイム API に渡すことは、すべて実行する場合、必要しますが、あるが可能であれば、作業のレベルを避けるため。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-111">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="c3b3d-112">回避すること*は*できる限り、ためと、C++/WinRT では、わずかな労力で効率的にし、コレクションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-112">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

<span data-ttu-id="c3b3d-113">」もご覧ください[XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-113">Also see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

> [!NOTE]
> <span data-ttu-id="c3b3d-114">Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールして、後で、必要はありませんこのトピックに記載されている基本クラスと関数へのアクセス場合。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-114">If you haven't installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later, then you won't have access to the functions and base classes that are documented in this topic.</span></span> <span data-ttu-id="c3b3d-115">代わりに、代わりに使用できる、監視可能なベクター テンプレートの一覧については[、Windows SDK の以前のバージョンがあるかどうか](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk)を表示します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-115">Instead, see [If you have an older version of the Windows SDK](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk) for a listing of an observable vector template that you can use instead.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="c3b3d-116">コレクションのヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="c3b3d-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="c3b3d-117">空の汎用的なコレクション</span><span class="sxs-lookup"><span data-stu-id="c3b3d-117">General-purpose collection, empty</span></span>

<span data-ttu-id="c3b3d-118">このセクションでは、最初に空のコレクションを作成するシナリオを説明します。*後*の作成を設定します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-118">This section covers the scenario where you wish to create a collection that's initially empty; and then populate it *after* creation.</span></span>

<span data-ttu-id="c3b3d-119">汎用のコレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-119">To retrieve a new object of a type that implements a general-purpose collection, you can call the [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector) function template.</span></span> <span data-ttu-id="c3b3d-120">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、として、オブジェクトが返され、は、インターフェイスを経由で返されるオブジェクトの関数とプロパティを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-120">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

```cppwinrt
...
#include <winrt/Windows.Foundation.Collections.h>
#include <iostream>
using namespace winrt;
...
int main()
{
    winrt::init_apartment();

    Windows::Foundation::Collections::IVector<int> coll{ winrt::single_threaded_vector<int>() };
    coll.Append(1);
    coll.Append(2);
    coll.Append(3);

    for (auto const& el : coll)
    {
        std::cout << el << std::endl;
    }

    Windows::Foundation::Collections::IVectorView<int> view{ coll.GetView() };
}
```

<span data-ttu-id="c3b3d-121">上記のコード例で示すように、コレクションを作成した後要素を追加、それらを反復処理して通常 API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを処理できます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-121">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="c3b3d-122">コレクションを固定表示が必要な場合に示す[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-122">If you need an immutable view over the collection, then you can call [**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="c3b3d-123">上記のパターン&mdash;のコレクションの作成と&mdash;が、データを渡すか、API からデータを取得する単純なシナリオに適してします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-123">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span> <span data-ttu-id="c3b3d-124">**IVector**の場合、または、 **IVectorView**に渡すことができる、任意の場所、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)に期待されます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-124">You can pass an **IVector**, or an **IVectorView**, anywhere an [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_) is expected.</span></span>

<span data-ttu-id="c3b3d-125">**Winrt::init_apartment**への呼び出しが COM を初期化する上記のコード例既定ではマルチ スレッド アパートメントでします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-125">In the code example above, the call to **winrt::init_apartment** initializes COM; by default, in a multithreaded apartment.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="c3b3d-126">データから先読み、汎用のコレクション</span><span class="sxs-lookup"><span data-stu-id="c3b3d-126">General-purpose collection, primed from data</span></span>

<span data-ttu-id="c3b3d-127">このセクションでは、コレクションを作成し、同時に設定するシナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-127">This section covers the scenario where you wish to create a collection and populate it at the same time.</span></span>

<span data-ttu-id="c3b3d-128">前のコード例では、**追加**への呼び出しのオーバーヘッドを回避することができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-128">You can avoid the overhead of the calls to **Append** in the previous code example.</span></span> <span data-ttu-id="c3b3d-129">ソースのデータが既にまたは Windows ランタイムのコレクション オブジェクトを作成する前にソース データを入力することができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-129">You may already have the source data, or you may prefer to populate the source data in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="c3b3d-130">その方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-130">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="c3b3d-131">**Winrt::single_threaded_vector**にデータを含む一時オブジェクトを渡すことと同様`coll1`上、します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-131">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="c3b3d-132">**Std::vector** (されませんにアクセスして、もう一度と仮定します) を移動するか、関数にします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-132">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="c3b3d-133">どちらの場合も、関数に、*右辺値*を渡しています。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-133">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="c3b3d-134">コンパイラを効率的にして、データのコピーを回避することができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-134">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="c3b3d-135">*Rvalue*について詳しく知りたい場合は、[値のカテゴリとへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-135">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="c3b3d-136">コレクションに XAML アイテム コントロールをバインドする場合することができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-136">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="c3b3d-137">ただし、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定する必要が**IVector** **IInspectable** (または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など、相互運用性の種類) の種類の値を設定してに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-137">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="c3b3d-138">次に、バインディングの適切な種類のコレクションを作成して要素を追加するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-138">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="c3b3d-139">データから、Windows ランタイムのコレクションを作成し、何かをコピーすることがなくすべての API に渡すことで、ビューを準備できます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-139">You can create a Windows Runtime collection from data, and get a view on it ready to pass to an API, all without copying anything.</span></span>

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

<span data-ttu-id="c3b3d-140">上記の例では、コレクションを作成*できます*にバインドする XAML アイテム コントロールです。いますが、コレクションは監視可能。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-140">In the examples above, the collection we create *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="c3b3d-141">監視可能なコレクション</span><span class="sxs-lookup"><span data-stu-id="c3b3d-141">Observable collection</span></span>

<span data-ttu-id="c3b3d-142">*監視可能な*コレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型と[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)関数テンプレートを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-142">To retrieve a new object of a type that implements an *observable* collection, call the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) function template with any element type.</span></span> <span data-ttu-id="c3b3d-143">監視可能なコレクションを XAML アイテム コントロールへのバインドに適したするには、要素の型として**IInspectable**を使用します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-143">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="c3b3d-144">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、として、オブジェクトが返され、は、インターフェイスを経由する (またはバインドされているコントロール)、返されるオブジェクトの関数とプロパティを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-144">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="c3b3d-145">複数の詳細とコード例では、ユーザーのバインディングについてインターフェイス (UI) を制御を監視可能なコレクションは、「 [XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-145">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-collection-map"></a><span data-ttu-id="c3b3d-146">連想コレクション (マップ)</span><span class="sxs-lookup"><span data-stu-id="c3b3d-146">Associative collection (map)</span></span>

<span data-ttu-id="c3b3d-147">説明した 2 つの関数のバージョンを連想コレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-147">There are associative collection versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="c3b3d-148">[**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)として監視可能な非連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-148">The [**winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map) function template returns a non-observable associative collection as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span>
- <span data-ttu-id="c3b3d-149">[**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートは、 [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として監視可能な連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-149">The [**winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map) function template returns an observable associative collection as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="c3b3d-150">型**std::map**または**std::unordered_map**の*右辺値*関数に渡すことによってこれらのコレクションにデータを必要に応じて素数ことができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-150">You can optionally prime these collections with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

```cppwinrt
auto coll1{
    winrt::single_threaded_map<winrt::hstring, int>(std::map<winrt::hstring, int>{
        { L"AliceBlue", 0xfff0f8ff }, { L"AntiqueWhite", 0xfffaebd7 }
    })
};

std::map<winrt::hstring, int> values{
    { L"AliceBlue", 0xfff0f8ff }, { L"AntiqueWhite", 0xfffaebd7 }
};
auto coll2{ winrt::single_threaded_map<winrt::hstring, int>(std::move(values)) };
```

### <a name="single-threaded"></a><span data-ttu-id="c3b3d-151">シングル スレッド</span><span class="sxs-lookup"><span data-stu-id="c3b3d-151">Single-threaded</span></span>

<span data-ttu-id="c3b3d-152">「シングル スレッド」これらの関数の名前には、すべての同時実行を用意しないことを示します&mdash;つまり、あるスレッド セーフであります。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-152">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="c3b3d-153">スレッドの説明は、これらの関数から返されたオブジェクトはすべてアジャイルであるため、アパートメントに関連するではありません (を参照してください[アジャイル オブジェクトでは、C++/WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-153">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="c3b3d-154">オブジェクトは、シングル スレッドですだけです。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-154">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="c3b3d-155">する方が適切な方法の 1 つのデータや他のアプリケーション バイナリ インターフェイス (ABI) に通過する場合。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-155">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="c3b3d-156">コレクションの基本クラス</span><span class="sxs-lookup"><span data-stu-id="c3b3d-156">Base classes for collections</span></span>

<span data-ttu-id="c3b3d-157">場合は、完全な柔軟性は、独自のカスタム コレクションを実装する、ありますハード方法は、これを行うようにするがします。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-157">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="c3b3d-158">たとえば、これは、ベクトルのカスタム ビューは次のよう *、C++ のサポートなし/WinRT の基底クラス*します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-158">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

```cppwinrt
...
using namespace winrt;
using namespace Windows::Foundation::Collections;
...
struct MyVectorView :
    implements<MyVectorView, IVectorView<float>, IIterable<float>>
{
    // IVectorView
    float GetAt(uint32_t const) { ... };
    uint32_t GetMany(uint32_t, winrt::array_view<float>) const { ... };
    bool IndexOf(float, uint32_t&) { ... };
    uint32_t Size() { ... };

    // IIterable
    IIterator<float> First() const { ... };
};
...
IVectorView<float> view{ winrt::make<MyVectorView>() };
```

<span data-ttu-id="c3b3d-159">代わりに、カスタム ベクトルのビューを[**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから派生し、データを保持するコンテナーを公開する**get_container**関数を実装するはるかに簡単です。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-159">Instead, it's much easier to derive your custom vector view from the [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base) struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

```cppwinrt
struct MyVectorView2 :
    implements<MyVectorView2, IVectorView<float>, IIterable<float>>,
    winrt::vector_view_base<MyVectorView2, float>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

private:
    std::vector<float> m_values{ 0.1f, 0.2f, 0.3f };
};
```

<span data-ttu-id="c3b3d-160">**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**と**終了**のインターフェイスを提供する必要がありますが想定されます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-160">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="c3b3d-161">上記の例のように、 **std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-161">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="c3b3d-162">ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たすすべてのコンテナーを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-162">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

```cppwinrt
struct MyVectorView3 :
    implements<MyVectorView3, IVectorView<float>, IIterable<float>>,
    winrt::vector_view_base<MyVectorView3, float>
{
    auto get_container() const noexcept
    {
        struct container
        {
            float const* const first;
            float const* const last;

            auto begin() const noexcept
            {
                return first;
            }

            auto end() const noexcept
            {
                return last;
            }
        };

        return container{ m_values.data(), m_values.data() + m_values.size() };
    }

private:
    std::array<float, 3> m_values{ 0.2f, 0.3f, 0.4f };
};
```

<span data-ttu-id="c3b3d-163">これらは、基底クラス C + + WinRT がカスタム コレクションを実装するために提供します。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-163">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

### [<a name="winrtvectorviewbase"></a><span data-ttu-id="c3b3d-164">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-164">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

<span data-ttu-id="c3b3d-165">上記のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3b3d-165">See the code examples above.</span></span>

### [<a name="winrtvectorbase"></a><span data-ttu-id="c3b3d-166">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-166">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)

```cppwinrt
struct MyVector :
    implements<MyVector, IVector<float>, IVectorView<float>, IIterable<float>>,
    winrt::vector_base<MyVector, float>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

    auto& get_container() noexcept
    {
        return m_values;
    }

private:
    std::vector<float> m_values{ 0.1f, 0.2f, 0.3f };
};
```

### [<a name="winrtobservablevectorbase"></a><span data-ttu-id="c3b3d-167">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-167">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)

```cppwinrt
struct MyObservableVector :
    implements<MyObservableVector, IObservableVector<float>, IVector<float>, IVectorView<float>, IIterable<float>>,
    winrt::observable_vector_base<MyObservableVector, float>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

    auto& get_container() noexcept
    {
        return m_values;
    }

private:
    std::vector<float> m_values{ 0.1f, 0.2f, 0.3f };
};
```

### [<a name="winrtmapviewbase"></a><span data-ttu-id="c3b3d-168">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-168">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)

```cppwinrt
struct MyMapView :
    implements<MyMapView, IMapView<winrt::hstring, int>, IIterable<IKeyValuePair<winrt::hstring, int>>>,
    winrt::map_view_base<MyMapView, winrt::hstring, int>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

private:
    std::map<winrt::hstring, int> m_values{
        { L"AliceBlue", 0xfff0f8ff }, { L"AntiqueWhite", 0xfffaebd7 }
    };
};
```

### [<a name="winrtmapbase"></a><span data-ttu-id="c3b3d-169">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-169">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)

```cppwinrt
struct MyMap :
    implements<MyMap, IMap<winrt::hstring, int>, IMapView<winrt::hstring, int>, IIterable<IKeyValuePair<winrt::hstring, int>>>,
    winrt::map_base<MyMap, winrt::hstring, int>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

    auto& get_container() noexcept
    {
        return m_values;
    }

private:
    std::map<winrt::hstring, int> m_values{
        { L"AliceBlue", 0xfff0f8ff }, { L"AntiqueWhite", 0xfffaebd7 }
    };
};
```

### [<a name="winrtobservablemapbase"></a><span data-ttu-id="c3b3d-170">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="c3b3d-170">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)

```cppwinrt
struct MyObservableMap :
    implements<MyObservableMap, IObservableMap<winrt::hstring, int>, IMap<winrt::hstring, int>, IMapView<winrt::hstring, int>, IIterable<IKeyValuePair<winrt::hstring, int>>>,
    winrt::observable_map_base<MyObservableMap, winrt::hstring, int>
{
    auto& get_container() const noexcept
    {
        return m_values;
    }

    auto& get_container() noexcept
    {
        return m_values;
    }

private:
    std::map<winrt::hstring, int> m_values{
        { L"AliceBlue", 0xfff0f8ff }, { L"AntiqueWhite", 0xfffaebd7 }
    };
};
```

## <a name="important-apis"></a><span data-ttu-id="c3b3d-171">重要な API</span><span class="sxs-lookup"><span data-stu-id="c3b3d-171">Important APIs</span></span>
* [<span data-ttu-id="c3b3d-172">ItemsControl.ItemsSource プロパティ</span><span class="sxs-lookup"><span data-stu-id="c3b3d-172">ItemsControl.ItemsSource property</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="c3b3d-173">IObservableVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="c3b3d-173">IObservableVector interface</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="c3b3d-174">IVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="c3b3d-174">IVector interface</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="c3b3d-175">winrt::map_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-175">winrt::map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-base)
* [<span data-ttu-id="c3b3d-176">winrt::map_view_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-176">winrt::map_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)
* [<span data-ttu-id="c3b3d-177">winrt::observable_map_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-177">winrt::observable_map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)
* [<span data-ttu-id="c3b3d-178">winrt::observable_vector_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-178">winrt::observable_vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [<span data-ttu-id="c3b3d-179">winrt::single_threaded_observable_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-179">winrt::single_threaded_observable_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [<span data-ttu-id="c3b3d-180">winrt::single_threaded_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-180">winrt::single_threaded_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [<span data-ttu-id="c3b3d-181">winrt::single_threaded_observable_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-181">winrt::single_threaded_observable_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [<span data-ttu-id="c3b3d-182">winrt::single_threaded_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-182">winrt::single_threaded_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [<span data-ttu-id="c3b3d-183">winrt::vector_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-183">winrt::vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-base)
* [<span data-ttu-id="c3b3d-184">winrt::vector_view_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="c3b3d-184">winrt::vector_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a><span data-ttu-id="c3b3d-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c3b3d-185">Related topics</span></span>
* [<span data-ttu-id="c3b3d-186">値のカテゴリとへの参照</span><span class="sxs-lookup"><span data-stu-id="c3b3d-186">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="c3b3d-187">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="c3b3d-187">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
