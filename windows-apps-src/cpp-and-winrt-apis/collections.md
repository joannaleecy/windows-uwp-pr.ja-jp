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
ms.openlocfilehash: 1ef6fbfab45197c868296186363c168a6c443247
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4126347"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="69c93-104">コレクションと[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="69c93-104">Collections with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

> [!NOTE]
> **<span data-ttu-id="69c93-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="69c93-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="69c93-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="69c93-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="69c93-107">内部では、Windows ランタイムのコレクションでは、単純な移動部分の多くがあります。</span><span class="sxs-lookup"><span data-stu-id="69c93-107">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="69c93-108">コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数と基底クラスでは、C++/WinRT をサポートします。</span><span class="sxs-lookup"><span data-stu-id="69c93-108">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in C++/WinRT to support you.</span></span> <span data-ttu-id="69c93-109">これらの機能は、手の複雑さを解消し、時間と労力で、多くのオーバーヘッドを保存します。</span><span class="sxs-lookup"><span data-stu-id="69c93-109">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="69c93-110">このトピックで説明されている機能は、 [Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合に利用可能な以降できます。</span><span class="sxs-lookup"><span data-stu-id="69c93-110">The features described in this topic are available if you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later.</span></span>

<span data-ttu-id="69c93-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、要素の任意のランダム アクセス コレクションによって実装された Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="69c93-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="69c93-112">**IVector**を実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、 [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要がありますがも。</span><span class="sxs-lookup"><span data-stu-id="69c93-112">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="69c93-113">入力する*必要がある*カスタム コレクション場合でも、多くの作業です。</span><span class="sxs-lookup"><span data-stu-id="69c93-113">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="69c93-114">**Std::vector** ( **std::map**、または**std::unordered_map**) 内のデータがあり、Windows ランタイム API に渡すことがすべて実行する場合、必要しますが、あるが可能であれば、作業のレベルを避けるため。</span><span class="sxs-lookup"><span data-stu-id="69c93-114">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="69c93-115">回避すること*は*できる限り、ためと、C++/WinRT では、わずかな労力で効率的にし、コレクションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="69c93-115">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="69c93-116">コレクションのヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="69c93-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="69c93-117">空の汎用的なコレクション</span><span class="sxs-lookup"><span data-stu-id="69c93-117">General-purpose collection, empty</span></span>

<span data-ttu-id="69c93-118">汎用的なコレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-118">To retrieve a new object of a type that implements a general-purpose collection, you can call the [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector) function template.</span></span> <span data-ttu-id="69c93-119">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、としてオブジェクトが返され、これによって、返されるオブジェクトの関数とプロパティを呼び出すインターフェイスが。</span><span class="sxs-lookup"><span data-stu-id="69c93-119">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

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

<span data-ttu-id="69c93-120">上記のコード例で示すように、コレクションを作成した後の要素を追加、反復処理し、して一般 API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを扱うできます。</span><span class="sxs-lookup"><span data-stu-id="69c93-120">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="69c93-121">コレクションを固定表示が必要な場合に示す[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-121">If you need an immutable view over the collection, then you can call [**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="69c93-122">前に示したパターン&mdash;のコレクションの作成と&mdash;が、データを渡すか、API からデータを取得する単純なシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="69c93-122">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span> <span data-ttu-id="69c93-123">**IVector**の場合、または、 **IVectorView**に渡すことができます、任意の場所、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)に期待されます。</span><span class="sxs-lookup"><span data-stu-id="69c93-123">You can pass an **IVector**, or an **IVectorView**, anywhere an [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_) is expected.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="69c93-124">データから先読み汎用のコレクション</span><span class="sxs-lookup"><span data-stu-id="69c93-124">General-purpose collection, primed from data</span></span>

<span data-ttu-id="69c93-125">また上記のコード例で表示される**追加**の呼び出しのオーバーヘッドを回避できます。</span><span class="sxs-lookup"><span data-stu-id="69c93-125">You can also avoid the overhead of the calls to **Append** that you can see in the code example above.</span></span> <span data-ttu-id="69c93-126">ソースのデータが既にまたは Windows ランタイムのコレクション オブジェクトを作成する前に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-126">You may already have the source data, or you may prefer to populate it in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="69c93-127">その方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="69c93-127">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="69c93-128">**Winrt::single_threaded_vector**にデータを含む一時オブジェクトを渡すことができますと同様に`coll1`額。</span><span class="sxs-lookup"><span data-stu-id="69c93-128">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="69c93-129">**Std::vector** (されませんにアクセスして、もう一度と仮定します) を移動するか、関数にします。</span><span class="sxs-lookup"><span data-stu-id="69c93-129">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="69c93-130">どちらの場合も、関数に、*右辺値*を渡しています。</span><span class="sxs-lookup"><span data-stu-id="69c93-130">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="69c93-131">これにより、効率的にして、データのコピーを回避するために、コンパイラができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-131">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="69c93-132">*Rvalue*について詳しく知りたい場合は、[値のカテゴリとへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="69c93-132">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="69c93-133">XAML アイテム コントロールをコレクションにバインドする場合は、そのできます。</span><span class="sxs-lookup"><span data-stu-id="69c93-133">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="69c93-134">ただし、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定する必要が型の**IVector** **IInspectable** (または、相互運用性の種類[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など) の値に設定に注意してください。</span><span class="sxs-lookup"><span data-stu-id="69c93-134">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="69c93-135">バインディング用の適切な種類のコレクションを作成して要素を追加するコード例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="69c93-135">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="69c93-136">データから、Windows ランタイムのコレクションを作成し、何かをコピーすることがなくすべての API に渡すことでビューを準備できます。</span><span class="sxs-lookup"><span data-stu-id="69c93-136">You can create a Windows Runtime collection from data, and get a view on it ready to pass to an API, all without copying anything.</span></span>

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

<span data-ttu-id="69c93-137">上記の例では、コレクションを作成*できます*にバインドする XAML アイテム コントロールです。コレクションが監視可能なはありません。</span><span class="sxs-lookup"><span data-stu-id="69c93-137">In the examples above, the collection we create *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="69c93-138">監視可能なコレクション</span><span class="sxs-lookup"><span data-stu-id="69c93-138">Observable collection</span></span>

<span data-ttu-id="69c93-139">*監視可能な*コレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型と[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)関数テンプレートを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="69c93-139">To retrieve a new object of a type that implements an *observable* collection, call the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) function template with any element type.</span></span> <span data-ttu-id="69c93-140">監視可能なコレクションを XAML アイテム コントロールへのバインドに適したするには、要素の型として**IInspectable**を使用します。</span><span class="sxs-lookup"><span data-stu-id="69c93-140">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="69c93-141">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、として、オブジェクトが返され、はインターフェイスを経由する (またはバインドされているコントロール)、返されるオブジェクトの関数とプロパティを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="69c93-141">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="69c93-142">詳細の詳細とコード例では、ユーザーのバインディングに関するインターフェイス (UI) を制御監視可能なコレクションには、「 [XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="69c93-142">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-collection-map"></a><span data-ttu-id="69c93-143">連想コレクション (マップ)</span><span class="sxs-lookup"><span data-stu-id="69c93-143">Associative collection (map)</span></span>

<span data-ttu-id="69c93-144">説明した 2 つの関数のバージョンを連想コレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="69c93-144">There are associative collection versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="69c93-145">[**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)として監視可能な非連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="69c93-145">The [**winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map) function template returns a non-observable associative collection as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span>
- <span data-ttu-id="69c93-146">[**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートは、 [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として監視可能な連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="69c93-146">The [**winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map) function template returns an observable associative collection as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="69c93-147">型**std::map**または**std::unordered_map**の*右辺値*関数に渡すことによってこれらのコレクションにデータを必要に応じて素数ことができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-147">You can optionally prime these collections with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

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

### <a name="single-threaded"></a><span data-ttu-id="69c93-148">シングル スレッド</span><span class="sxs-lookup"><span data-stu-id="69c93-148">Single-threaded</span></span>

<span data-ttu-id="69c93-149">「シングル スレッド」これらの関数の名前には、すべての同時実行を提供しないことを示します&mdash;スレッド セーフが不明、つまり、します。</span><span class="sxs-lookup"><span data-stu-id="69c93-149">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="69c93-150">スレッドの言及は、これらの関数から返されたオブジェクトはすべてアジャイルであるために、アパートメントに関連する (を参照してください[アジャイル オブジェクトでは、C++/WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="69c93-150">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="69c93-151">オブジェクトは、シングル スレッドですだけです。</span><span class="sxs-lookup"><span data-stu-id="69c93-151">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="69c93-152">する方が適切な方法の 1 つのデータや他のアプリケーション バイナリ インターフェイス (ABI) に通過する場合。</span><span class="sxs-lookup"><span data-stu-id="69c93-152">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="69c93-153">コレクションの基本クラス</span><span class="sxs-lookup"><span data-stu-id="69c93-153">Base classes for collections</span></span>

<span data-ttu-id="69c93-154">場合は、完全な柔軟性は、独自のカスタム コレクションを実装する、ありますハード方法は、これを回避するために必要があります。</span><span class="sxs-lookup"><span data-stu-id="69c93-154">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="69c93-155">たとえば、これは、ベクトルのカスタム ビューがどのように *、C++ のサポートなし/WinRT の基底クラス*します。</span><span class="sxs-lookup"><span data-stu-id="69c93-155">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

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

<span data-ttu-id="69c93-156">代わりに、カスタム ベクトルのビューを[**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから派生し、データを保持するコンテナーを公開する**get_container**関数を実装するはるかに簡単です。</span><span class="sxs-lookup"><span data-stu-id="69c93-156">Instead, it's much easier to derive your custom vector view from the [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base) struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

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

<span data-ttu-id="69c93-157">**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**と**終了**のインターフェイスを提供する必要がありますが想定されます。</span><span class="sxs-lookup"><span data-stu-id="69c93-157">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="69c93-158">上記の例のように、 **std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="69c93-158">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="69c93-159">ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たすすべてのコンテナーを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="69c93-159">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

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

<span data-ttu-id="69c93-160">これらは、基底クラス C + + WinRT がカスタム コレクションを実装するために提供します。</span><span class="sxs-lookup"><span data-stu-id="69c93-160">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

### [<a name="winrtvectorviewbase"></a><span data-ttu-id="69c93-161">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="69c93-161">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

<span data-ttu-id="69c93-162">上記のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="69c93-162">See the code examples above.</span></span>

### [<a name="winrtvectorbase"></a><span data-ttu-id="69c93-163">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="69c93-163">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)

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

### [<a name="winrtobservablevectorbase"></a><span data-ttu-id="69c93-164">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="69c93-164">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### [<a name="winrtmapviewbase"></a><span data-ttu-id="69c93-165">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="69c93-165">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)

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

### [<a name="winrtmapbase"></a><span data-ttu-id="69c93-166">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="69c93-166">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)

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

### [<a name="winrtobservablemapbase"></a><span data-ttu-id="69c93-167">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="69c93-167">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)

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

## <a name="important-apis"></a><span data-ttu-id="69c93-168">重要な API</span><span class="sxs-lookup"><span data-stu-id="69c93-168">Important APIs</span></span>
* [<span data-ttu-id="69c93-169">ItemsControl.ItemsSource プロパティ</span><span class="sxs-lookup"><span data-stu-id="69c93-169">ItemsControl.ItemsSource property</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="69c93-170">IObservableVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="69c93-170">IObservableVector interface</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="69c93-171">IVector インターフェイス</span><span class="sxs-lookup"><span data-stu-id="69c93-171">IVector interface</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="69c93-172">winrt::map_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-172">winrt::map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-base)
* [<span data-ttu-id="69c93-173">winrt::map_view_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-173">winrt::map_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)
* [<span data-ttu-id="69c93-174">winrt::observable_map_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-174">winrt::observable_map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)
* [<span data-ttu-id="69c93-175">winrt::observable_vector_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-175">winrt::observable_vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [<span data-ttu-id="69c93-176">winrt::single_threaded_observable_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-176">winrt::single_threaded_observable_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [<span data-ttu-id="69c93-177">winrt::single_threaded_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-177">winrt::single_threaded_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [<span data-ttu-id="69c93-178">winrt::single_threaded_observable_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-178">winrt::single_threaded_observable_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [<span data-ttu-id="69c93-179">winrt::single_threaded_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-179">winrt::single_threaded_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [<span data-ttu-id="69c93-180">winrt::vector_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-180">winrt::vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-base)
* [<span data-ttu-id="69c93-181">winrt::vector_view_base 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c93-181">winrt::vector_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a><span data-ttu-id="69c93-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="69c93-182">Related topics</span></span>
* [<span data-ttu-id="69c93-183">値のカテゴリとへの参照</span><span class="sxs-lookup"><span data-stu-id="69c93-183">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="69c93-184">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="69c93-184">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
