---
author: stevewhims
description: C++/WinRT 機能と、多くの時間と労力を実装やコレクションに合格するときに保存する基底クラスを提供します。
title: コレクション、C++/WinRT
ms.author: stwhi
ms.date: 08/24/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: 5495649a6b7fad633e24e244aa3f6efbcc05e441
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3238794"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="3952a-104">コレクションと[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="3952a-104">Collections with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

> [!NOTE]
> **<span data-ttu-id="3952a-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3952a-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="3952a-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="3952a-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="3952a-107">内部では、Windows ランタイムのコレクションでは、多くの複雑な移動部分があります。</span><span class="sxs-lookup"><span data-stu-id="3952a-107">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="3952a-108">コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクション プロパティとコレクション型を実装する場合は、関数と c++ の基底クラス/WinRT をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3952a-108">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in C++/WinRT to support you.</span></span> <span data-ttu-id="3952a-109">これらの機能は、手の複雑さを解消し、時間と労力で、多くのオーバーヘッドを保存します。</span><span class="sxs-lookup"><span data-stu-id="3952a-109">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3952a-110">このトピックで説明されている機能には、 [Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合に利用可能な以降ができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-110">The features described in this topic are available if you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later.</span></span>

<span data-ttu-id="3952a-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、要素の任意のランダム アクセス コレクションによって実装された Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="3952a-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="3952a-112">**IVector**を自分で実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要がありますがも。</span><span class="sxs-lookup"><span data-stu-id="3952a-112">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="3952a-113">を入力する*必要がある*カスタム コレクション場合でも、多くの作業です。</span><span class="sxs-lookup"><span data-stu-id="3952a-113">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="3952a-114">たい**std::vector** (または、 **::map**、または**std::unordered_map**) 内のデータがある場合は、Windows ランタイム API に渡すを行うためのすべてが可能であれば、作業のレベルを避けるため。</span><span class="sxs-lookup"><span data-stu-id="3952a-114">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="3952a-115">回避すること*は*できる限り、ためと、C++/WinRT では、わずかな労力で効率的にし、コレクションを作成するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3952a-115">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="3952a-116">コレクションのヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="3952a-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="3952a-117">空の汎用的なコレクション</span><span class="sxs-lookup"><span data-stu-id="3952a-117">General-purpose collection, empty</span></span>

<span data-ttu-id="3952a-118">汎用のコレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-118">To retrieve a new object of a type that implements a general-purpose collection, you can call the [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector) function template.</span></span> <span data-ttu-id="3952a-119">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、として、オブジェクトが返され、返されるオブジェクトの関数とプロパティを呼び出すことによってこれインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="3952a-119">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

```cppwinrt
...
#include <winrt/Windows.Foundation.Collections.h>
#include <iostream>
using namespace winrt;
...
int main()
{
    init_apartment();

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

<span data-ttu-id="3952a-120">上記のコード例で示すように、コレクションを作成した後要素を追加、それらを反復処理して通常 API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを処理できます。</span><span class="sxs-lookup"><span data-stu-id="3952a-120">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="3952a-121">コレクションを固定のビューを必要がある場合に示すように[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-121">If you need an immutable view over the collection, then you can call [**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="3952a-122">前に示したパターン&mdash;のコレクションの作成と&mdash;が、データを渡すか、API からデータを取得する単純なシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="3952a-122">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="3952a-123">データから先読み、汎用的なコレクション</span><span class="sxs-lookup"><span data-stu-id="3952a-123">General-purpose collection, primed from data</span></span>

<span data-ttu-id="3952a-124">また、上記のコード例で表示される**追加**の呼び出しのオーバーヘッドを回避できます。</span><span class="sxs-lookup"><span data-stu-id="3952a-124">You can also avoid the overhead of the calls to **Append** that you can see in the code example above.</span></span> <span data-ttu-id="3952a-125">ソース データが既にまたは Windows ランタイムのコレクション オブジェクトを作成する前にデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-125">You may already have the source data, or you may prefer to populate it in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="3952a-126">その方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="3952a-126">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="3952a-127">**Winrt::single_threaded_vector**にデータを含む、一時的なオブジェクトを渡すことができますと同様に`coll1`額。</span><span class="sxs-lookup"><span data-stu-id="3952a-127">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="3952a-128">(されませんにアクセスして、もう一度していれば) **std::vector**を移動するか、関数にします。</span><span class="sxs-lookup"><span data-stu-id="3952a-128">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="3952a-129">どちらの場合も、関数に、*右辺値*を渡しています。</span><span class="sxs-lookup"><span data-stu-id="3952a-129">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="3952a-130">これにより、コンパイラ効率的にし、データのコピーを回避することができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-130">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="3952a-131">を*rvalue*について詳しく知りたい場合は、[値のカテゴリとへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3952a-131">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="3952a-132">XAML アイテム コントロールをコレクションにバインドする場合することができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-132">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="3952a-133">ただし、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定する必要が**IVector** **IInspectable** (または、相互運用性の種類[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など) の種類の値に設定することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3952a-133">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="3952a-134">以下に、バインディングの適切な種類のコレクションを作成し、それを要素に追加のコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="3952a-134">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="3952a-135">XAML アイテム コントロール; にバインド*できる*上のコレクションコレクションが監視可能なはありません。</span><span class="sxs-lookup"><span data-stu-id="3952a-135">The collection above *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="3952a-136">監視可能なコレクション</span><span class="sxs-lookup"><span data-stu-id="3952a-136">Observable collection</span></span>

<span data-ttu-id="3952a-137">*監視可能な*コレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型を[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)関数テンプレートを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3952a-137">To retrieve a new object of a type that implements an *observable* collection, call the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) function template with any element type.</span></span> <span data-ttu-id="3952a-138">監視可能なコレクションを XAML アイテム コントロールをバインドに適したさせるには、要素の種類として**IInspectable**を使用します。</span><span class="sxs-lookup"><span data-stu-id="3952a-138">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="3952a-139">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、として、オブジェクトが返され、インターフェイスを経由する (またはバインドされているコントロール) を呼び出して、返されるオブジェクトの関数とプロパティです。</span><span class="sxs-lookup"><span data-stu-id="3952a-139">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="3952a-140">詳細についてとコード例は、ユーザーのバインディングについてインターフェイス (UI) コントロールを監視可能なコレクションは、「 [c++ へのバインド XAML アイテム コントロール/WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="3952a-140">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-collection-map"></a><span data-ttu-id="3952a-141">また、関連のコレクション (マップ)</span><span class="sxs-lookup"><span data-stu-id="3952a-141">Associative collection (map)</span></span>

<span data-ttu-id="3952a-142">説明した 2 つの関数のバージョンを連想コレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="3952a-142">There are associative collection versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="3952a-143">[**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートでは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)として連想監視可能ではないコレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="3952a-143">The [**winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map) function template returns a non-observable associative collection as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span>
- <span data-ttu-id="3952a-144">[**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートでは、監視可能な[**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="3952a-144">The [**winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map) function template returns an observable associative collection as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="3952a-145">種類 **::map**または**std::unordered_map**の*右辺値*関数に渡すことによってこれらのコレクションにデータを必要に応じて素数ことができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-145">You can optionally prime these collections with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

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

### <a name="single-threaded"></a><span data-ttu-id="3952a-146">シングル スレッド</span><span class="sxs-lookup"><span data-stu-id="3952a-146">Single-threaded</span></span>

<span data-ttu-id="3952a-147">すべての同時実行を用意しないことを示す、「シングル スレッド」これらの関数の名前に&mdash;スレッド セーフが不明、つまり、します。</span><span class="sxs-lookup"><span data-stu-id="3952a-147">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="3952a-148">スレッドの説明はこれらの関数から返されたオブジェクトはすべてアジャイルであるため、アパートメント無関係 (を参照してください[アジャイル オブジェクトの c++/WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="3952a-148">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="3952a-149">オブジェクトは、シングル スレッドですだけです。</span><span class="sxs-lookup"><span data-stu-id="3952a-149">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="3952a-150">する方が適切な方法の 1 つのデータまたはその他のアプリケーション バイナリ インターフェイス (ABI) に通過する場合。</span><span class="sxs-lookup"><span data-stu-id="3952a-150">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="3952a-151">コレクションの基底クラス</span><span class="sxs-lookup"><span data-stu-id="3952a-151">Base classes for collections</span></span>

<span data-ttu-id="3952a-152">、完全な柔軟性を、独自のカスタム コレクションを実装する場合、するされる場合は、ハード方法は、これを行うようにします。</span><span class="sxs-lookup"><span data-stu-id="3952a-152">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="3952a-153">たとえば、これは、ベクトルのカスタム ビューは次のよう *、C++ のサポートなし/WinRT の基底クラス*します。</span><span class="sxs-lookup"><span data-stu-id="3952a-153">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

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

<span data-ttu-id="3952a-154">代わりに、大幅に容易[**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから、ベクトルのカスタム ビューを派生し、データを保持するコンテナーを公開する**get_container**関数を実装するのにです。</span><span class="sxs-lookup"><span data-stu-id="3952a-154">Instead, it's much easier to derive your custom vector view from the [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base) struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

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

<span data-ttu-id="3952a-155">**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**と**終了**のインターフェイスを提供する必要がありますが想定されます。</span><span class="sxs-lookup"><span data-stu-id="3952a-155">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="3952a-156">上記の例のようにを**std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="3952a-156">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="3952a-157">ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たすすべてのコンテナーを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="3952a-157">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

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

<span data-ttu-id="3952a-158">これらは、基本クラス C + + WinRT を提供して、カスタムのコレクションを実装できます。</span><span class="sxs-lookup"><span data-stu-id="3952a-158">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

### [<a name="winrtvectorviewbase"></a><span data-ttu-id="3952a-159">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="3952a-159">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

<span data-ttu-id="3952a-160">上記のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3952a-160">See the code examples above.</span></span>

### [<a name="winrtvectorbase"></a><span data-ttu-id="3952a-161">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="3952a-161">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)

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

### [<a name="winrtobservablevectorbase"></a><span data-ttu-id="3952a-162">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="3952a-162">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### [<a name="winrtmapviewbase"></a><span data-ttu-id="3952a-163">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="3952a-163">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)

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

### [<a name="winrtmapbase"></a><span data-ttu-id="3952a-164">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="3952a-164">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)

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

### [<a name="winrtobservablemapbase"></a><span data-ttu-id="3952a-165">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="3952a-165">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)

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

## <a name="important-apis"></a><span data-ttu-id="3952a-166">重要な API</span><span class="sxs-lookup"><span data-stu-id="3952a-166">Important APIs</span></span>
* [<span data-ttu-id="3952a-167">ItemsControl.ItemsSource</span><span class="sxs-lookup"><span data-stu-id="3952a-167">ItemsControl.ItemsSource</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="3952a-168">IObservableVector</span><span class="sxs-lookup"><span data-stu-id="3952a-168">IObservableVector</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="3952a-169">IVector</span><span class="sxs-lookup"><span data-stu-id="3952a-169">IVector</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="3952a-170">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="3952a-170">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)
* [<span data-ttu-id="3952a-171">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="3952a-171">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)
* [<span data-ttu-id="3952a-172">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="3952a-172">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)
* [<span data-ttu-id="3952a-173">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="3952a-173">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [<span data-ttu-id="3952a-174">winrt::single_threaded_observable_map</span><span class="sxs-lookup"><span data-stu-id="3952a-174">winrt::single_threaded_observable_map</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [<span data-ttu-id="3952a-175">winrt::single_threaded_map</span><span class="sxs-lookup"><span data-stu-id="3952a-175">winrt::single_threaded_map</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [<span data-ttu-id="3952a-176">winrt::single_threaded_observable_vector</span><span class="sxs-lookup"><span data-stu-id="3952a-176">winrt::single_threaded_observable_vector</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [<span data-ttu-id="3952a-177">winrt::single_threaded_vector</span><span class="sxs-lookup"><span data-stu-id="3952a-177">winrt::single_threaded_vector</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [<span data-ttu-id="3952a-178">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="3952a-178">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)
* [<span data-ttu-id="3952a-179">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="3952a-179">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a><span data-ttu-id="3952a-180">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3952a-180">Related topics</span></span>
* [<span data-ttu-id="3952a-181">値のカテゴリとへの参照</span><span class="sxs-lookup"><span data-stu-id="3952a-181">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="3952a-182">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="3952a-182">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
