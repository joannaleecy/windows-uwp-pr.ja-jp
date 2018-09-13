---
author: stevewhims
description: C + + の関数と基本クラスを実装すると、コレクションを渡すしたい場合に時間と労力の大幅な削減を WinRT が提供されます。
title: コレクションと C + + WinRT
ms.author: stwhi
ms.date: 08/24/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10 uwp、標準的な c、cpp、winrt、投影コレクション
ms.localizationpriority: medium
ms.openlocfilehash: 1ef6fbfab45197c868296186363c168a6c443247
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3964342"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="2e625-104">コレクションと[C + + WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="2e625-104">Collections with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

> [!NOTE]
> **<span data-ttu-id="2e625-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2e625-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="2e625-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="2e625-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="2e625-107">内部的には、Windows のランタイム コレクションには、多くの複雑な可動部があります。</span><span class="sxs-lookup"><span data-stu-id="2e625-107">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="2e625-108">コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数と基本クラス C + + WinRT をサポートします。</span><span class="sxs-lookup"><span data-stu-id="2e625-108">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in C++/WinRT to support you.</span></span> <span data-ttu-id="2e625-109">これらの機能は、自分の手の複雑さを解消し、時間と労力で多くのオーバーヘッドを保存します。</span><span class="sxs-lookup"><span data-stu-id="2e625-109">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2e625-110">以降[Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールした場合は、このトピックで説明する機能です。</span><span class="sxs-lookup"><span data-stu-id="2e625-110">The features described in this topic are available if you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later.</span></span>

<span data-ttu-id="2e625-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、ランダム アクセス コレクションの要素によって実装されている Windows ランタイム インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="2e625-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="2e625-112">**IVector**を自分で実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、 [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要がありますがもします。</span><span class="sxs-lookup"><span data-stu-id="2e625-112">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="2e625-113">場合でも、入力する*必要がある*ユーザー設定のコレクションには、多くの作業です。</span><span class="sxs-lookup"><span data-stu-id="2e625-113">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="2e625-114">の**std::vector** (または、 **std::map**、または、 **std::unordered_map**) 内のデータがあり、実行するは Windows ランタイム API に渡す場合はできますが可能な場合はそのレベルの作業を避けるためです。</span><span class="sxs-lookup"><span data-stu-id="2e625-114">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="2e625-115">回避すること*が*可能なため、C + + WinRT では、効率的かつ簡単な作業では、コレクションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2e625-115">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="2e625-116">コレクション用のヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="2e625-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="2e625-117">汎用コレクションは、空</span><span class="sxs-lookup"><span data-stu-id="2e625-117">General-purpose collection, empty</span></span>

<span data-ttu-id="2e625-118">汎用コレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)の関数テンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="2e625-118">To retrieve a new object of a type that implements a general-purpose collection, you can call the [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector) function template.</span></span> <span data-ttu-id="2e625-119">として[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、オブジェクトが返され、返されたオブジェクトの関数およびプロパティを呼び出す際のインタ フェースです。</span><span class="sxs-lookup"><span data-stu-id="2e625-119">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

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

<span data-ttu-id="2e625-120">上記のコード例でわかるように、コレクションを作成した後要素を追加、それらを反復処理して一般に API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを扱います。</span><span class="sxs-lookup"><span data-stu-id="2e625-120">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="2e625-121">コレクションを変更不可のビューをする必要がある場合のように[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="2e625-121">If you need an immutable view over the collection, then you can call [**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="2e625-122">上記のパターン&mdash;コレクションの作成との&mdash;は、単純なシナリオで、データを渡すか、API からのデータを取得する適切な。</span><span class="sxs-lookup"><span data-stu-id="2e625-122">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span> <span data-ttu-id="2e625-123">**IVector**の場合、または、 **IVectorView**を渡すことができます、任意の場所に[**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)が期待されます。</span><span class="sxs-lookup"><span data-stu-id="2e625-123">You can pass an **IVector**, or an **IVectorView**, anywhere an [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_) is expected.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="2e625-124">先読みのデータから、汎用のコレクション</span><span class="sxs-lookup"><span data-stu-id="2e625-124">General-purpose collection, primed from data</span></span>

<span data-ttu-id="2e625-125">また、上記のコード例に表示する**追加**の呼び出しのオーバーヘッドを回避できます。</span><span class="sxs-lookup"><span data-stu-id="2e625-125">You can also avoid the overhead of the calls to **Append** that you can see in the code example above.</span></span> <span data-ttu-id="2e625-126">ソース ・ データが既にまたは Windows ランタイムは、コレクション オブジェクトを作成する前にそれを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="2e625-126">You may already have the source data, or you may prefer to populate it in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="2e625-127">その方法をここでは。</span><span class="sxs-lookup"><span data-stu-id="2e625-127">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="2e625-128">**Winrt::single_threaded_vector**データを含む一時オブジェクトを渡すことができますと同様に`coll1`、上です。</span><span class="sxs-lookup"><span data-stu-id="2e625-128">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="2e625-129">(しないにアクセスする、もう一度と仮定した場合)、 **std::vector**を移動するか、関数にします。</span><span class="sxs-lookup"><span data-stu-id="2e625-129">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="2e625-130">どちらの場合も、*右辺値*を関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="2e625-130">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="2e625-131">効率的にして、データをコピーしないようにするのにはコンパイラを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2e625-131">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="2e625-132">*Rvalue*の詳細を把握したい場合は、[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e625-132">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="2e625-133">XAML 項目コントロールをコレクションにバインドする場合は、しすることができます。</span><span class="sxs-lookup"><span data-stu-id="2e625-133">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="2e625-134">ですが、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定するには、する必要があります型**IVector**の**IInspectable** (または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など、相互運用性の種類) の値に設定するのには注意してください。</span><span class="sxs-lookup"><span data-stu-id="2e625-134">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="2e625-135">ここで、バインディングの適切な型のコレクションを作成し、要素を追加するコード例です。</span><span class="sxs-lookup"><span data-stu-id="2e625-135">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="2e625-136">データから Windows ランタイムのコレクションを作成し、何もコピーすることがなくすべての API に渡す準備ができて上にビューを取得できます。</span><span class="sxs-lookup"><span data-stu-id="2e625-136">You can create a Windows Runtime collection from data, and get a view on it ready to pass to an API, all without copying anything.</span></span>

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

<span data-ttu-id="2e625-137">上記の例では、コレクションを作成*できる*コントロールに連結する、XAML 項目です。コレクションが観測可能なオブジェクトはありません。</span><span class="sxs-lookup"><span data-stu-id="2e625-137">In the examples above, the collection we create *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="2e625-138">観察可能なコレクション</span><span class="sxs-lookup"><span data-stu-id="2e625-138">Observable collection</span></span>

<span data-ttu-id="2e625-139">*観測可能なオブジェクト*のコレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型を持つ[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)の関数テンプレートを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2e625-139">To retrieve a new object of a type that implements an *observable* collection, call the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) function template with any element type.</span></span> <span data-ttu-id="2e625-140">識別可能なコレクションを XAML 項目コントロールにバインドするための適切なするためには、要素の型として**IInspectable**を使用します。</span><span class="sxs-lookup"><span data-stu-id="2e625-140">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="2e625-141">として[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、オブジェクトが返され、インタ フェースを使用して (または、コントロールがバインドされている) を呼び出して、返されたオブジェクトの関数とプロパティです。</span><span class="sxs-lookup"><span data-stu-id="2e625-141">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="2e625-142">詳細の詳細とコード例については、のバインド、ユーザー インターフェイス (UI) を制御観察可能なコレクションには、「[アイテムの XAML; C + バインド + WinRT コレクション](binding-collection.md)です。</span><span class="sxs-lookup"><span data-stu-id="2e625-142">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-collection-map"></a><span data-ttu-id="2e625-143">連想コレクション (マップ)</span><span class="sxs-lookup"><span data-stu-id="2e625-143">Associative collection (map)</span></span>

<span data-ttu-id="2e625-144">見てきましたので、2 つの関数のバージョンを連想のコレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="2e625-144">There are associative collection versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="2e625-145">[**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートでは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)と連想以外の観測可能なオブジェクト コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="2e625-145">The [**winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map) function template returns a non-observable associative collection as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span>
- <span data-ttu-id="2e625-146">[**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートでは、観測可能な[**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として連想コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="2e625-146">The [**winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map) function template returns an observable associative collection as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="2e625-147">型**std::map**または**std::unordered_map**は、*右辺値*を関数に渡すことによってこれらのコレクションにデータをオプションで準備できます。</span><span class="sxs-lookup"><span data-stu-id="2e625-147">You can optionally prime these collections with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

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

### <a name="single-threaded"></a><span data-ttu-id="2e625-148">シングル スレッド</span><span class="sxs-lookup"><span data-stu-id="2e625-148">Single-threaded</span></span>

<span data-ttu-id="2e625-149">しないすべての同時実行制御を提供することを示す、「単一の」これらの関数の名前を&mdash;つまり、他とは違うスレッド セーフであります。</span><span class="sxs-lookup"><span data-stu-id="2e625-149">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="2e625-150">スレッドの説明とは関係ありませんアパートメントでは、これらの関数から返されるオブジェクトがすべてのアジャイルであるため (を参照してください[アジャイル オブジェクト C + + WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="2e625-150">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="2e625-151">オブジェクトは、シングル スレッドがだけです。</span><span class="sxs-lookup"><span data-stu-id="2e625-151">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="2e625-152">する方が適切なアプリケーション アプリケーションバイナリインタ フェース (ABI) の間でどちらか 1 つの方法でデータを渡すだけの場合です。</span><span class="sxs-lookup"><span data-stu-id="2e625-152">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="2e625-153">コレクションの基本クラス</span><span class="sxs-lookup"><span data-stu-id="2e625-153">Base classes for collections</span></span>

<span data-ttu-id="2e625-154">場合は、完全な柔軟性を与えるには、独自のカスタム コレクションを実装するために、したいを避けるために苦労します。</span><span class="sxs-lookup"><span data-stu-id="2e625-154">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="2e625-155">たとえば、これは、どのようなユーザー定義のベクター表示のようになります*C + のサポートなし/WinRT の基本クラス*です。</span><span class="sxs-lookup"><span data-stu-id="2e625-155">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

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

<span data-ttu-id="2e625-156">代わりに、 [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから、ユーザー定義のベクター ビューを取得し、データを保持するコンテナーを公開する**get_container**関数を実装するだけに非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="2e625-156">Instead, it's much easier to derive your custom vector view from the [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base) struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

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

<span data-ttu-id="2e625-157">**Get_container**によって返されるコンテナー必要があります**開始**と**終了**インタ フェースが提供する**winrt::vector_view_base**が必要です。</span><span class="sxs-lookup"><span data-stu-id="2e625-157">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="2e625-158">上記の例のように、 **std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="2e625-158">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="2e625-159">独自のカスタムのコンテナーを含む、同じコントラクトを満たす任意のコンテナーを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="2e625-159">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

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

<span data-ttu-id="2e625-160">これらは、基本クラス C + + のカスタム コレクションを実装するため、WinRT が用意されています。</span><span class="sxs-lookup"><span data-stu-id="2e625-160">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

### [<a name="winrtvectorviewbase"></a><span data-ttu-id="2e625-161">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="2e625-161">winrt::vector_view_base</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

<span data-ttu-id="2e625-162">上記のコード例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e625-162">See the code examples above.</span></span>

### [<a name="winrtvectorbase"></a><span data-ttu-id="2e625-163">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="2e625-163">winrt::vector_base</span></span>](/uwp/cpp-ref-for-winrt/vector-base)

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

### [<a name="winrtobservablevectorbase"></a><span data-ttu-id="2e625-164">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="2e625-164">winrt::observable_vector_base</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### [<a name="winrtmapviewbase"></a><span data-ttu-id="2e625-165">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="2e625-165">winrt::map_view_base</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)

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

### [<a name="winrtmapbase"></a><span data-ttu-id="2e625-166">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="2e625-166">winrt::map_base</span></span>](/uwp/cpp-ref-for-winrt/map-base)

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

### [<a name="winrtobservablemapbase"></a><span data-ttu-id="2e625-167">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="2e625-167">winrt::observable_map_base</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)

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

## <a name="important-apis"></a><span data-ttu-id="2e625-168">重要な API</span><span class="sxs-lookup"><span data-stu-id="2e625-168">Important APIs</span></span>
* [<span data-ttu-id="2e625-169">ItemsControl.ItemsSource プロパティ</span><span class="sxs-lookup"><span data-stu-id="2e625-169">ItemsControl.ItemsSource property</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="2e625-170">IObservableVector インタ フェース</span><span class="sxs-lookup"><span data-stu-id="2e625-170">IObservableVector interface</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="2e625-171">IVector のインタ フェース</span><span class="sxs-lookup"><span data-stu-id="2e625-171">IVector interface</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)
* [<span data-ttu-id="2e625-172">winrt::map_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-172">winrt::map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-base)
* [<span data-ttu-id="2e625-173">winrt::map_view_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-173">winrt::map_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/map-view-base)
* [<span data-ttu-id="2e625-174">winrt::observable_map_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-174">winrt::observable_map_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-map-base)
* [<span data-ttu-id="2e625-175">winrt::observable_vector_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-175">winrt::observable_vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [<span data-ttu-id="2e625-176">winrt::single_threaded_observable_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-176">winrt::single_threaded_observable_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [<span data-ttu-id="2e625-177">winrt::single_threaded_map 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-177">winrt::single_threaded_map function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [<span data-ttu-id="2e625-178">winrt::single_threaded_observable_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-178">winrt::single_threaded_observable_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [<span data-ttu-id="2e625-179">winrt::single_threaded_vector 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-179">winrt::single_threaded_vector function template</span></span>](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [<span data-ttu-id="2e625-180">winrt::vector_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-180">winrt::vector_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-base)
* [<span data-ttu-id="2e625-181">winrt::vector_view_base 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="2e625-181">winrt::vector_view_base struct template</span></span>](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a><span data-ttu-id="2e625-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2e625-182">Related topics</span></span>
* [<span data-ttu-id="2e625-183">値のカテゴリ、およびそれらへの参照</span><span class="sxs-lookup"><span data-stu-id="2e625-183">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="2e625-184">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="2e625-184">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
