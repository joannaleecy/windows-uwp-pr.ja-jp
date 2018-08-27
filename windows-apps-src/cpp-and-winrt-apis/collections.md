---
author: stevewhims
description: C + +/WinRT 関数と多くの実装やコレクションを通過するときに時間と労力を節約する基本クラスを提供します。
title: コレクション C + +/WinRT
ms.author: stwhi
ms.date: 08/24/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準的な c、cpp、winrt、投影、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: 54f949c41af885ec379eaa9e5b12764710532b50
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2867947"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="dcc55-104">コレクション[C + +/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="dcc55-104">Collections with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

> [!NOTE]
> **<span data-ttu-id="dcc55-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dcc55-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="dcc55-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="dcc55-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="dcc55-107">内部では、Windows ランタイム コレクションには、大量の複雑な移動パーツがあります。</span><span class="sxs-lookup"><span data-stu-id="dcc55-107">Internally, a Windows Runtime collection has a lot of complicated moving parts.</span></span> <span data-ttu-id="dcc55-108">コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数と基本クラス C + +/WinRT をサポートします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-108">But when you want to pass a collection object to a Windows Runtime function, or to implement your own collection properties and collection types, there are functions and base classes in C++/WinRT to support you.</span></span> <span data-ttu-id="dcc55-109">これらの機能は、自分の手の複雑さを解消し、時間と労力で多くの頭上を保存します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-109">These features take the complexity out of your hands, and save you a lot of overhead in time and effort.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="dcc55-110">このトピックで説明する機能は、 [Windows 10 SDK Preview ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールした場合、利用可能な以降できます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-110">The features described in this topic are available if you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later.</span></span>

<span data-ttu-id="dcc55-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、Windows ランタイム インターフェイス要素のランダム アクセス コレクションによって実装です。</span><span class="sxs-lookup"><span data-stu-id="dcc55-111">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) is the Windows Runtime interface implemented by any random-access collection of elements.</span></span> <span data-ttu-id="dcc55-112">自分で**IVector**を実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装するために必要なもします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-112">If you were to implement **IVector** yourself, you'd also need to implement [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_), [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_), and [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_).</span></span> <span data-ttu-id="dcc55-113">場合でも、入力する*必要がある*ユーザー設定のコレクションには、多数の作業です。</span><span class="sxs-lookup"><span data-stu-id="dcc55-113">Even if you *need* a custom collection type, that's a lot of work.</span></span> <span data-ttu-id="dcc55-114">Windows ランタイム API に渡すが目的に合ったしてすべての**std::vector** ( **std::map**では、または、 **std::unordered_map**) にデータがある場合、[はできますが可能な場合は、作業のレベルを避けるためです。</span><span class="sxs-lookup"><span data-stu-id="dcc55-114">But if you have data in a **std::vector** (or a **std::map**, or a **std::unordered_map**) and all you want to do is pass that to a Windows Runtime API, then you'd want to avoid doing that level of work, if possible.</span></span> <span data-ttu-id="dcc55-115">回避すること*が*可能なので、C + +/WinRT を使うと簡単かつ効率的にコレクションを作成するとします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-115">And avoiding it *is* possible, because C++/WinRT helps you to create collections efficiently and with little effort.</span></span>

## <a name="helper-functions-for-collections"></a><span data-ttu-id="dcc55-116">コレクション ヘルパー関数</span><span class="sxs-lookup"><span data-stu-id="dcc55-116">Helper functions for collections</span></span>

### <a name="general-purpose-collection-empty"></a><span data-ttu-id="dcc55-117">空の汎用コレクション</span><span class="sxs-lookup"><span data-stu-id="dcc55-117">General-purpose collection, empty</span></span>

<span data-ttu-id="dcc55-118">汎用のコレクションを実装する型の新しいオブジェクトを取得するには、 **winrt::single_threaded_vector**関数のテンプレートを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-118">To retrieve a new object of a type that implements a general-purpose collection, you can call the **winrt::single_threaded_vector** function template.</span></span> <span data-ttu-id="dcc55-119">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、名前を付けてオブジェクトが返され、返されるオブジェクトの関数とプロパティと通話する際、インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="dcc55-119">The object is returned as an [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_), and that's the interface via which you call the returned object's functions and properties.</span></span>

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

<span data-ttu-id="dcc55-120">上記の例でわかるコレクションを作成した後要素を追加、反復して通常 API から受信した任意の Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを扱うできます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-120">As you can see in the code example above, after creating the collection you can append elements, iterate over them, and generally treat the object as you would any Windows Runtime collection object that you might have received from an API.</span></span> <span data-ttu-id="dcc55-121">コレクションを表示する必要がある場合ように[IVector::GetView](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-121">If you need a view over the collection, then you can call [IVector::GetView](/uwp/api/windows.foundation.collections.ivector-1.getview), as shown.</span></span> <span data-ttu-id="dcc55-122">上記のパターン&mdash;のコレクションの作成と&mdash;、先に、データを渡したり、API からデータを取得する簡単なシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="dcc55-122">The pattern shown above&mdash;of creating and consuming a collection&mdash;is appropriate for simple scenarios where you want to pass data into, or get data out of, an API.</span></span>

### <a name="general-purpose-collection-primed-from-data"></a><span data-ttu-id="dcc55-123">データから先読み汎用のコレクション</span><span class="sxs-lookup"><span data-stu-id="dcc55-123">General-purpose collection, primed from data</span></span>

<span data-ttu-id="dcc55-124">上記の例で表示できる**追加**の呼び出しの頭上も回避できます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-124">You can also avoid the overhead of the calls to **Append** that you can see in the code example above.</span></span> <span data-ttu-id="dcc55-125">ソース データがあるまたは Windows ランタイム コレクション オブジェクトを作成する前に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-125">You may already have the source data, or you may prefer to populate it in advance of creating the Windows Runtime collection object.</span></span> <span data-ttu-id="dcc55-126">その方法を示します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-126">Here's how to do that.</span></span>

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

<span data-ttu-id="dcc55-127">**Winrt::single_threaded_vector**にデータを含む一時的なオブジェクトを通過すると同様に`coll1`上、します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-127">You can pass a temporary object containing your data to **winrt::single_threaded_vector**, as with `coll1`, above.</span></span> <span data-ttu-id="dcc55-128">移動したりすることができます (されませんにアクセスする場合、もう一度を想定しています) **std::vector**関数にします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-128">Or you can move a **std::vector** (assuming you won't be accessing it again) into the function.</span></span> <span data-ttu-id="dcc55-129">両方のケースで、*右辺値*関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-129">In both cases, you're passing an *rvalue* into the function.</span></span> <span data-ttu-id="dcc55-130">効率的に使用して、データをコピーしないようにするのには、コンパイラを有効にするとします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-130">That enables the compiler to be efficient and to avoid copying the data.</span></span> <span data-ttu-id="dcc55-131">詳細については、 *rvalue*したい場合は、[値のカテゴリ、およびへの参照](cpp-value-categories.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="dcc55-131">If you want to know more about *rvalues*, see [Value categories, and references to them](cpp-value-categories.md).</span></span>

<span data-ttu-id="dcc55-132">コレクションに XAML アイテム コントロールを連結する場合は、[することができます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-132">If you want to bind a XAML items control to your collection, then you can.</span></span> <span data-ttu-id="dcc55-133">正しく[**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを設定する必要があること型**IVector** **IInspectable** (または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)などの相互運用性の種類) の値に設定するに注意してください。</span><span class="sxs-lookup"><span data-stu-id="dcc55-133">But be aware that to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable** (or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)).</span></span> <span data-ttu-id="dcc55-134">バインドとして、「適切な種類のコレクションを作成して、要素を追加するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-134">Here's a code example that produces a collection of a type suitable for binding, and appends an element to it.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

<span data-ttu-id="dcc55-135">コレクション上にある*ことができます*が、XAML アイテム コントロールにバインドします。コレクションを見る。</span><span class="sxs-lookup"><span data-stu-id="dcc55-135">The collection above *can* be bound to a XAML items control; but the collection isn't observable.</span></span>

### <a name="observable-collection"></a><span data-ttu-id="dcc55-136">目に見えるコレクション</span><span class="sxs-lookup"><span data-stu-id="dcc55-136">Observable collection</span></span>

<span data-ttu-id="dcc55-137">*見る*コレクションを実装する型の新しいオブジェクトを取得するには、するには、すべての要素の種類**winrt::single_threaded_observable_vector**関数のテンプレートを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-137">To retrieve a new object of a type that implements an *observable* collection, call the **winrt::single_threaded_observable_vector** function template with any element type.</span></span> <span data-ttu-id="dcc55-138">要素の種類として**IInspectable**を使用するのには、目に見えるコレクション XAML アイテム コントロールにバインドするための適切な。</span><span class="sxs-lookup"><span data-stu-id="dcc55-138">But to make an observable collection suitable for binding to a XAML items control, use **IInspectable** as the element type.</span></span>

<span data-ttu-id="dcc55-139">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、名前を付けてオブジェクトが返され、インターフェイスを使用して (またはバインドされているコントロール) を呼び出す、返されるオブジェクトの関数とプロパティです。</span><span class="sxs-lookup"><span data-stu-id="dcc55-139">The object is returned as an [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_), and that's the interface via which you (or the control to which it's bound) call the returned object's functions and properties.</span></span>

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

<span data-ttu-id="dcc55-140">その他の詳細については、およびコードの例では、ユーザーのバインドについてインターフェイス (UI) コントロール、目に見えるコレクションを参照してください[XAML アイテム; バインド C + +/WinRT コレクション](binding-collection.md)します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-140">For more details, and code examples, about binding your user interface (UI) controls to an observable collection, see [XAML items controls; bind to a C++/WinRT collection](binding-collection.md).</span></span>

### <a name="associative-container-map"></a><span data-ttu-id="dcc55-141">結合のコンテナー (表)</span><span class="sxs-lookup"><span data-stu-id="dcc55-141">Associative container (map)</span></span>

<span data-ttu-id="dcc55-142">説明したように 2 つの関数の結合コンテナーのバージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="dcc55-142">There are associative container versions of the two functions that we've looked at.</span></span>

- <span data-ttu-id="dcc55-143">**Single_threaded_map**関数テンプレートは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)として結合、コンテナーを返します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-143">The **single_threaded_map** function template returns an associative container as an [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_).</span></span> <span data-ttu-id="dcc55-144">マップが目に見えるではありません。</span><span class="sxs-lookup"><span data-stu-id="dcc55-144">The map is not observable.</span></span>
- <span data-ttu-id="dcc55-145">**Single_threaded_observable_map**関数テンプレートを[**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として、目に見える結合コンテナーを返します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-145">The **single_threaded_observable_map** function template returns an observable associative container as an [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).</span></span>

<span data-ttu-id="dcc55-146">データを含む、これらのコンテナーを準備型**std::map**または**std::unordered_map**を*右辺値*を関数に渡すことができます (省略可能)。</span><span class="sxs-lookup"><span data-stu-id="dcc55-146">You can optionally prime these containers with data by passing to the function an *rvalue* of type **std::map** or **std::unordered_map**.</span></span>

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

### <a name="single-threaded"></a><span data-ttu-id="dcc55-147">1 つのスレッド</span><span class="sxs-lookup"><span data-stu-id="dcc55-147">Single-threaded</span></span>

<span data-ttu-id="dcc55-148">「シングル スレッド」これらの関数の名前の同時実行制御を提供しないことを示します&mdash;つまりとは違うスレッド セーフします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-148">The "single-threaded" in the names of these functions indicates that they don't provide any concurrency&mdash;in other words, they're not thread-safe.</span></span> <span data-ttu-id="dcc55-149">これらの関数から返されるオブジェクトがすべてアジャイルであるために、スレッドの説明をアパートメントに関連することはありません (を参照してください[アジャイル オブジェクト C + +/WinRT](agile-objects.md))。</span><span class="sxs-lookup"><span data-stu-id="dcc55-149">The mention of threads is unrelated to apartments, because the objects returned from these functions are all agile (see [Agile objects in C++/WinRT](agile-objects.md)).</span></span> <span data-ttu-id="dcc55-150">1 つのスレッドを対象としてがだけです。</span><span class="sxs-lookup"><span data-stu-id="dcc55-150">It's just that the objects are single-threaded.</span></span> <span data-ttu-id="dcc55-151">する方が適切な方法の 1 つのデータまたはその他のアプリケーションのバイナリ インターフェイス (ABI) に通過する場合。</span><span class="sxs-lookup"><span data-stu-id="dcc55-151">And that's entirely appropriate if you just want to pass data one way or the other across the application binary interface (ABI).</span></span>

## <a name="base-classes-for-collections"></a><span data-ttu-id="dcc55-152">基本のクラスのコレクション</span><span class="sxs-lookup"><span data-stu-id="dcc55-152">Base classes for collections</span></span>

<span data-ttu-id="dcc55-153">場合は、完全な柔軟性を独自のユーザー設定のコレクションを実装する、したい苦労を実行しないようにします。</span><span class="sxs-lookup"><span data-stu-id="dcc55-153">If, for complete flexibility, you want to implement your own custom collection, then you'll want to avoid doing that the hard way.</span></span> <span data-ttu-id="dcc55-154">たとえば、これはカスタム ベクトル ビューはどのように*C + の支援なし +/WinRT の基本クラス*します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-154">For example, this is what a custom vector view would look like *without the assistance of C++/WinRT's base classes*.</span></span>

```cppwinrt
...
using namespace Windows::Foundation::Collections;

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

<span data-ttu-id="dcc55-155">代わりに、カスタム ベクトル ビュー、 **winrt::vector_view_base**構造体のテンプレートから取得、および実装するだけでデータを格納しているコンテナーを公開する**get_container**関数ずっと簡単です。</span><span class="sxs-lookup"><span data-stu-id="dcc55-155">Instead, it's much easier to derive your custom vector view from the **winrt::vector_view_base** struct template, and just implement the **get_container** function to expose the container holding your data.</span></span>

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

<span data-ttu-id="dcc55-156">**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**位置と**終了**インターフェイスを提供する必要がありますが必要です。</span><span class="sxs-lookup"><span data-stu-id="dcc55-156">The container returned by **get_container** must provide the **begin** and **end** interface that **winrt::vector_view_base** expects.</span></span> <span data-ttu-id="dcc55-157">上記の例のように、 **std::vector**を提供します。</span><span class="sxs-lookup"><span data-stu-id="dcc55-157">As shown in the example above, **std::vector** provides that.</span></span> <span data-ttu-id="dcc55-158">独自のカスタム コンテナーなど、同じ契約を満たす任意のコンテナーに戻ることができます。</span><span class="sxs-lookup"><span data-stu-id="dcc55-158">But you can return any container that fulfils the same contract, including your own custom container.</span></span>

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

<span data-ttu-id="dcc55-159">これらは、基本クラス C + +/WinRT は、ユーザー設定のコレクションを実装するために用意されています。</span><span class="sxs-lookup"><span data-stu-id="dcc55-159">These are the base classes that C++/WinRT provides to help you implement custom collections.</span></span>

- **<span data-ttu-id="dcc55-160">winrt::vector_view_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-160">winrt::vector_view_base</span></span>**
- **<span data-ttu-id="dcc55-161">winrt::vector_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-161">winrt::vector_base</span></span>**
- **<span data-ttu-id="dcc55-162">winrt::observable_vector_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-162">winrt::observable_vector_base</span></span>**
- **<span data-ttu-id="dcc55-163">winrt::map_view_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-163">winrt::map_view_base</span></span>**
- **<span data-ttu-id="dcc55-164">winrt::map_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-164">winrt::map_base</span></span>**
- **<span data-ttu-id="dcc55-165">winrt::observable_map_base</span><span class="sxs-lookup"><span data-stu-id="dcc55-165">winrt::observable_map_base</span></span>**

## <a name="important-apis"></a><span data-ttu-id="dcc55-166">重要な API</span><span class="sxs-lookup"><span data-stu-id="dcc55-166">Important APIs</span></span>
* [<span data-ttu-id="dcc55-167">ItemsControl.ItemsSource</span><span class="sxs-lookup"><span data-stu-id="dcc55-167">ItemsControl.ItemsSource</span></span>](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [<span data-ttu-id="dcc55-168">IObservableVector</span><span class="sxs-lookup"><span data-stu-id="dcc55-168">IObservableVector</span></span>](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [<span data-ttu-id="dcc55-169">IVector</span><span class="sxs-lookup"><span data-stu-id="dcc55-169">IVector</span></span>](/uwp/api/windows.foundation.collections.ivector_t_)

## <a name="related-topics"></a><span data-ttu-id="dcc55-170">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dcc55-170">Related topics</span></span>
* [<span data-ttu-id="dcc55-171">値のカテゴリ、およびへの参照</span><span class="sxs-lookup"><span data-stu-id="dcc55-171">Value categories, and references to them</span></span>](cpp-value-categories.md)
* [<span data-ttu-id="dcc55-172">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="dcc55-172">XAML items controls; bind to a C++/WinRT collection</span></span>](binding-collection.md)
