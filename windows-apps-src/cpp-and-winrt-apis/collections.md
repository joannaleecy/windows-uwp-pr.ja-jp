---
description: C++/WinRT では、コレクションを実装したり、渡すときの時間と手間を大幅に減らすことができる、関数と基本クラスが提供されます。
title: C++/WinRT でのコレクション
ms.date: 10/03/2018
ms.topic: article
keywords: windows 10、uwp、標準の c++、cpp、winrt、プロジェクション、コレクション
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: a50ab5f70faa0c8f8b73eada38444bcafd444d8b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635437"
---
# <a name="collections-with-cwinrt"></a><span data-ttu-id="f2e30-104">C++/WinRT でのコレクション</span><span class="sxs-lookup"><span data-stu-id="f2e30-104">Collections with C++/WinRT</span></span>

<span data-ttu-id="f2e30-105">内部的には、Windows ランタイムのコレクションには、多くの複雑な移動パーツがあります。</span><span class="sxs-lookup"><span data-stu-id="f2e30-105">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="f2e30-106">Windows ランタイム関数の場合にコレクション オブジェクトを渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数やが基底クラスで[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)サポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-106">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) to support you.</span></span> <span data-ttu-id="f2e30-107">これらの機能は、手の複雑さを解消し、時間と労力で大きなオーバーヘッドを保存します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-107">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

<span data-ttu-id="f2e30-108">[**IVector** ](/uwp/api/windows.foundation.collections.ivector_t_)は要素の任意のランダム アクセス コレクションによって実装される Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f2e30-108">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="f2e30-109">実装する場合は**IVector** 、自分で必要も実装する[ **IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [ **IVectorView** ](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[ **IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-109">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="f2e30-110">場合でもする*必要*カスタム コレクション型は、多くの作業であります。</span><span class="sxs-lookup"><span data-stu-id="f2e30-110">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="f2e30-111">データがある場合は、 **std::vector** (または**std::map**、または**std::unordered_map**) 避けるたいとし、Windows ランタイム API に渡すがすべて実行します。可能であれば、作業のレベル。</span><span class="sxs-lookup"><span data-stu-id="f2e30-111">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="f2e30-112">これを回避して*は*可能であれば、ため、C +/cli WinRT には、効率的かつ最小限の労力でコレクションを作成するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-112">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

<span data-ttu-id="f2e30-113">参照してください[XAML コントロールの項目は、バインド C +/cli WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-113">Also see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

> [!NOTE]
> <span data-ttu-id="f2e30-114">10.0.17763.0 (Windows 10、バージョンは 1809) のバージョンの Windows SDK をインストールしていない場合は、後ではありません関数とこのトピックで説明されている基底クラスへのアクセス。</span><span class="sxs-lookup"><span data-stu-id="f2e30-114">If you haven't installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later, then you won't have access to the functions and base classes that are documented in this topic.</span></span> <span data-ttu-id="f2e30-115">代わりを参照してください[以前のバージョンの Windows SDK があるかどうかは](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk)代わりに使用できる監視可能なベクター テンプレートの一覧についてはします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-115">Instead, see [If you have an older version of the Windows SDK](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk) for a listing of an observable vector template that you can use instead.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="f2e30-116">コレクションのヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="f2e30-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="f2e30-117">空の汎用コレクション</span><span class="sxs-lookup"><span data-stu-id="f2e30-117">General-purpose collection, empty</span></span>

<span data-ttu-id="f2e30-118">ここでは、最初に空のコレクションを作成するシナリオそこから*後*作成します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-118">This section covers the scenario where you wish to create a collection that's initially empty; and then populate it *after* creation.</span></span>

<span data-ttu-id="f2e30-119">汎用コレクションを実装する型の新しいオブジェクトを取得するを呼び出すことができます、 [ **winrt::single_threaded_vector** ](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="f2e30-119">To retrieve a new object of a type that implements a general-purpose collection, you can call the [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector) function template.</span></span> <span data-ttu-id="f2e30-120">として、オブジェクトが返されます、 [ **IVector**](/uwp/api/windows.foundation.collections.ivector_t_)、これを使用して、返されたオブジェクトの関数とプロパティを呼び出すインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f2e30-120">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

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

<span data-ttu-id="f2e30-121">上記のコード例に示すように、コレクションの作成後に要素を追加、繰り返し処理して、して一般に API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを処理できます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-121">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="f2e30-122">不変のビューをコレクションに対する必要があるかどうかは、呼び出すことができます[ **IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-122">If you need an immutable view over the collection, then you can call [**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="f2e30-123">上記のパターン&mdash;のコレクションの作成と&mdash;API からデータを取得したりする、データを受け渡しする単純なシナリオに適してします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-123">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span> <span data-ttu-id="f2e30-124">渡すことができます、 **IVector**、または**IVectorView**、任意の場所、 [ **IIterable** ](/uwp/api/windows.foundation.collections.iiterable_t_)が必要です。</span><span class="sxs-lookup"><span data-stu-id="f2e30-124">You can pass an **IVector**, or an **IVectorView**, anywhere an [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_) is expected.</span></span>

<span data-ttu-id="f2e30-125">呼び出しを上記のコード例で**winrt::init_apartment** COM を初期化します。 既定では、マルチ スレッド アパートメント内です。</span><span class="sxs-lookup"><span data-stu-id="f2e30-125">In the code example above, the call to **winrt::init_apartment** initializes COM; by default, in a multithreaded apartment.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="f2e30-126">データからの先読みの汎用コレクション</span><span class="sxs-lookup"><span data-stu-id="f2e30-126">General-purpose collection, primed from data</span></span>

<span data-ttu-id="f2e30-127">このセクションでは、コレクションを作成し、同時に設定するシナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-127">This section covers the scenario where you wish to create a collection and populate it at the same time.</span></span>

<span data-ttu-id="f2e30-128">呼び出しのオーバーヘッドを回避できます**Append**上記のコード例にします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-128">You can avoid the overhead of the calls to **Append** in the previous code example.</span></span> <span data-ttu-id="f2e30-129">既にソース データ、または Windows ランタイムのコレクション オブジェクトを作成する前にソース データを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-129">You may already have the source data, or you may prefer to populate the source data in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="f2e30-130">その方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-130">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="f2e30-131">データを格納している一時オブジェクトを渡すことができます**winrt::single_threaded_vector**と同様`coll1`上、します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-131">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="f2e30-132">移動したり、 **std::vector** (想定しないにアクセスする、もう一度) 関数にします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-132">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="f2e30-133">どちらの場合も、渡そうとしている、*右辺値*関数にします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-133">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="f2e30-134">コンパイラを効率的にし、データのコピーを回避するためにできるようにします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-134">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="f2e30-135">詳細を知りたい場合*rvalue*を参照してください[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-135">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="f2e30-136">XAML のアイテム コントロールをコレクションにバインドする場合は、ことができます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-136">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="f2e30-137">正しく設定する、 [ **ItemsControl.ItemsSource** ](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティ、型の値に設定する必要があります**IVector**の**IInspectable**(または、相互運用性の種類などの[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector))。</span><span class="sxs-lookup"><span data-stu-id="f2e30-137">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="f2e30-138">次に、バインディングの適切な型のコレクションを作成し、要素を追加するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-138">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="f2e30-139">データから Windows ランタイムのコレクションを作成でき、何もコピーすることがなくすべての API に渡すことで、ビューを準備できます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-139">You can create a Windows Runtime collection from data, and get a view on it ready to pass to an API, all without copying anything.</span></span>

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

<span data-ttu-id="f2e30-140">上記の例では、コレクションを作成*できます*にバインドする、XAML コントロールの項目がコレクションには、観測可能なオブジェクトがはありません。</span><span class="sxs-lookup"><span data-stu-id="f2e30-140">In the examples above, the collection we create *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="f2e30-141">監視可能なコレクション</span><span class="sxs-lookup"><span data-stu-id="f2e30-141">Observable collection</span></span>

<span data-ttu-id="f2e30-142">実装する型の新しいオブジェクトを取得する、*オブザーバブル*コレクション、呼び出し、 [ **winrt::single_threaded_observable_vector** ](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)いずれかの関数テンプレート要素の型。</span><span class="sxs-lookup"><span data-stu-id="f2e30-142">To retrieve a new object of a type that implements an *observable* collection, call the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) function template with any element type.</span></span> <span data-ttu-id="f2e30-143">使用して、コレクションは observablecollection に XAML 項目コントロールにバインドに適してが**IInspectable**要素の型として。</span><span class="sxs-lookup"><span data-stu-id="f2e30-143">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="f2e30-144">として、オブジェクトが返されます、 [ **IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)、これを使用して (または、コントロールがバインドされている)、返されたオブジェクトの関数とプロパティを呼び出すインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f2e30-144">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="f2e30-145">詳細については、およびコード例は、ユーザーのバインディングについてインターフェイス (UI) を制御コレクションは observablecollection を参照してください[XAML コントロールの項目は、バインド C +/cli WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-145">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-collection-map"></a><span data-ttu-id="f2e30-146">関連コレクション (map)</span><span class="sxs-lookup"><span data-stu-id="f2e30-146">Associative collection (map)</span></span>

<span data-ttu-id="f2e30-147">きた 2 つの関数の関連コレクションのバージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="f2e30-147">There are associative collection versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="f2e30-148">[ **Winrt::single_threaded_map** ](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートとして非観測可能なオブジェクトの関連コレクションを返します、 [ **IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-148">The [**winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map) function template returns a non-observable associative collection as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span>
- <span data-ttu-id="f2e30-149">[ **Winrt::single_threaded_observable_map** ](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートとして監視可能な関連コレクションを返します、 [ **IObservableMap** ](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span><span class="sxs-lookup"><span data-stu-id="f2e30-149">The [**winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map) function template returns an observable associative collection as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="f2e30-150">関数に渡すことによってこれらのコレクションにデータを準備できます必要に応じて、 *rvalue*型の**std::map**または**std::unordered_map**します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-150">You can optionally prime these collections with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

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

### <a name="single-threaded"></a><span data-ttu-id="f2e30-151">シングル スレッド</span><span class="sxs-lookup"><span data-stu-id="f2e30-151">Single-threaded</span></span>

<span data-ttu-id="f2e30-152">任意の同時実行を指定しないことを示します「シングル スレッド」これらの関数の名前に&mdash;スレッド セーフでない、つまり、します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-152">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="f2e30-153">スレッドのメンションはこれらの関数から返されるオブジェクトはすべてのアジャイルであるため、アパートメント無関係 (を参照してください[C + でのアジャイル オブジェクト/cli WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="f2e30-153">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="f2e30-154">オブジェクトは、シングル スレッドはだけです。</span><span class="sxs-lookup"><span data-stu-id="f2e30-154">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="f2e30-155">アプリケーション バイナリ インターフェイス (ABI) 間でどちらか 1 つの方法でデータを渡すだけの場合、完全に適合します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-155">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="f2e30-156">コレクションの基本クラス</span><span class="sxs-lookup"><span data-stu-id="f2e30-156">Base classes for collections</span></span>

<span data-ttu-id="f2e30-157">場合は、完全な柔軟性を高めるため、独自のカスタム コレクションを実装するためが、これに苦労を回避するためにします。</span><span class="sxs-lookup"><span data-stu-id="f2e30-157">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="f2e30-158">たとえば、これは、ベクターのカスタム ビューはのようになります*C + の支援を受けることがなく/cli WinRT の基本クラス*します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-158">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

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

<span data-ttu-id="f2e30-159">代わりに、簡単に、ユーザー定義のベクターのビューからの派生は、 [ **winrt::vector_view_base** ](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートだけを実装し、 **get_container**関数データを保持するコンテナーを公開します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-159">Instead, it's much easier to derive your custom vector view from the [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base) struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

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

<span data-ttu-id="f2e30-160">によって返されるコンテナー **get_container**提供する必要があります、**開始**と**エンド**インターフェイス**winrt::vector_view_base**が必要です。</span><span class="sxs-lookup"><span data-stu-id="f2e30-160">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="f2e30-161">上記の例で示すように**std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-161">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="f2e30-162">ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たす任意のコンテナーを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="f2e30-162">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

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

<span data-ttu-id="f2e30-163">これらは、ベース クラス C +/cli WinRT がカスタム コレクションを実装するために提供します。</span><span class="sxs-lookup"><span data-stu-id="f2e30-163">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

### <a name="winrtvectorviewbaseuwpcpp-ref-for-winrtvector-view-base"></a>[<span data-ttu-id="f2e30-164">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-164">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

<span data-ttu-id="f2e30-165">上記のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f2e30-165">See the code examples above.</span></span>

### <a name="winrtvectorbaseuwpcpp-ref-for-winrtvector-base"></a>[<span data-ttu-id="f2e30-166">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-166">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)

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

### <a name="winrtobservablevectorbaseuwpcpp-ref-for-winrtobservable-vector-base"></a>[<span data-ttu-id="f2e30-167">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-167">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### <a name="winrtmapviewbaseuwpcpp-ref-for-winrtmap-view-base"></a>[<span data-ttu-id="f2e30-168">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-168">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)

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

### <a name="winrtmapbaseuwpcpp-ref-for-winrtmap-base"></a>[<span data-ttu-id="f2e30-169">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-169">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)

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

### <a name="winrtobservablemapbaseuwpcpp-ref-for-winrtobservable-map-base"></a>[<span data-ttu-id="f2e30-170">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="f2e30-170">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)

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

## <a name="important-apis"></a><span data-ttu-id="f2e30-171">重要な API</span><span class="sxs-lookup"><span data-stu-id="f2e30-171">Important APIs</span></span>
* [<span data-ttu-id="f2e30-172">ItemsControl.ItemsSource プロパティ</span><span class="sxs-lookup"><span data-stu-id="f2e30-172">ItemsControl.ItemsSource property</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="f2e30-173">IObservableVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="f2e30-173">IObservableVector interface</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="f2e30-174">IVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="f2e30-174">IVector interface</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="f2e30-175">winrt::map_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-175">winrt::map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-base)
* [<span data-ttu-id="f2e30-176">winrt::map_view_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-176">winrt::map_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)
* [<span data-ttu-id="f2e30-177">winrt::observable_map_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-177">winrt::observable_map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)
* [<span data-ttu-id="f2e30-178">winrt::observable_vector_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-178">winrt::observable_vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [<span data-ttu-id="f2e30-179">winrt::single_threaded_observable_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-179">winrt::single_threaded_observable_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [<span data-ttu-id="f2e30-180">winrt::single_threaded_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-180">winrt::single_threaded_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [<span data-ttu-id="f2e30-181">winrt::single_threaded_observable_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-181">winrt::single_threaded_observable_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [<span data-ttu-id="f2e30-182">winrt::single_threaded_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-182">winrt::single_threaded_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [<span data-ttu-id="f2e30-183">winrt::vector_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-183">winrt::vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-base)
* [<span data-ttu-id="f2e30-184">winrt::vector_view_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="f2e30-184">winrt::vector_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a><span data-ttu-id="f2e30-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f2e30-185">Related topics</span></span>
* [<span data-ttu-id="f2e30-186">値のカテゴリと、その参照</span><span class="sxs-lookup"><span data-stu-id="f2e30-186">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="f2e30-187">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="f2e30-187">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
