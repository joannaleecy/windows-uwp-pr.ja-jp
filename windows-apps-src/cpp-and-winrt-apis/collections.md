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
ms.openlocfilehash: dacfe4135402b85bac68b63c06f99f97001fa5b9
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2889329"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>コレクション[C + +/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

内部では、Windows ランタイム コレクションには、大量の複雑な移動パーツがあります。 コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数と基本クラス C + +/WinRT をサポートします。 これらの機能は、自分の手の複雑さを解消し、時間と労力で多くの頭上を保存します。

> [!IMPORTANT]
> このトピックで説明する機能は、 [Windows 10 SDK Preview ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールした場合、利用可能な以降できます。

[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、Windows ランタイム インターフェイス要素のランダム アクセス コレクションによって実装です。 自分で**IVector**を実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装するために必要なもします。 場合でも、入力する*必要がある*ユーザー設定のコレクションには、多数の作業です。 Windows ランタイム API に渡すが目的に合ったしてすべての**std::vector** ( **std::map**では、または、 **std::unordered_map**) にデータがある場合、[はできますが可能な場合は、作業のレベルを避けるためです。 回避すること*が*可能なので、C + +/WinRT を使うと簡単かつ効率的にコレクションを作成するとします。

## <a name="helper-functions-for-collections"></a>コレクション ヘルパー関数

### <a name="general-purpose-collection-empty"></a>空の汎用コレクション

汎用のコレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数のテンプレートを呼び出すことができます。 [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、名前を付けてオブジェクトが返され、返されるオブジェクトの関数とプロパティと通話する際、インターフェイスです。

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

上記の例でわかるコレクションを作成した後要素を追加、反復して通常 API から受信した任意の Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを扱うできます。 コレクションを変更できないビューが必要な場合ように[IVector::GetView](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。 上記のパターン&mdash;のコレクションの作成と&mdash;、先に、データを渡したり、API からデータを取得する簡単なシナリオに適しています。

### <a name="general-purpose-collection-primed-from-data"></a>データから先読み汎用のコレクション

上記の例で表示できる**追加**の呼び出しの頭上も回避できます。 ソース データがあるまたは Windows ランタイム コレクション オブジェクトを作成する前に設定することができます。 その方法を示します。

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

**Winrt::single_threaded_vector**にデータを含む一時的なオブジェクトを通過すると同様に`coll1`上、します。 移動したりすることができます (されませんにアクセスする場合、もう一度を想定しています) **std::vector**関数にします。 両方のケースで、*右辺値*関数に渡します。 効率的に使用して、データをコピーしないようにするのには、コンパイラを有効にするとします。 詳細については、 *rvalue*したい場合は、[値のカテゴリ、およびへの参照](cpp-value-categories.md)を参照してください。

コレクションに XAML アイテム コントロールを連結する場合は、[することができます。 正しく[**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを設定する必要があること型**IVector** **IInspectable** (または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)などの相互運用性の種類) の値に設定するに注意してください。 バインドとして、「適切な種類のコレクションを作成して、要素を追加するコード例を示します。

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

コレクション上にある*ことができます*が、XAML アイテム コントロールにバインドします。コレクションを見る。

### <a name="observable-collection"></a>目に見えるコレクション

*見る*コレクションを実装する型の新しいオブジェクトを取得するには、するには、すべての要素の種類[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)関数のテンプレートを呼び出します。 要素の種類として**IInspectable**を使用するのには、目に見えるコレクション XAML アイテム コントロールにバインドするための適切な。

[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、名前を付けてオブジェクトが返され、インターフェイスを使用して (またはバインドされているコントロール) を呼び出す、返されるオブジェクトの関数とプロパティです。

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

その他の詳細については、およびコードの例では、ユーザーのバインドについてインターフェイス (UI) コントロール、目に見えるコレクションを参照してください[XAML アイテム; バインド C + +/WinRT コレクション](binding-collection.md)します。

### <a name="associative-collection-map"></a>結合のコレクション (表)

説明したように 2 つの関数の結合コレクションのバージョンがあります。

- [**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)名前を付けて以外を見る結合コレクションを返します。
- [**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートは、として、 [**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)観測可能な結合コレクションを返します。

データを含む、これらのコレクションを準備の種類**std::map**または**std::unordered_map**を*右辺値*を関数に渡すことができます (省略可能)。

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

### <a name="single-threaded"></a>1 つのスレッド

「シングル スレッド」これらの関数の名前の同時実行制御を提供しないことを示します&mdash;つまりとは違うスレッド セーフします。 これらの関数から返されるオブジェクトがすべてアジャイルであるために、スレッドの説明をアパートメントに関連することはありません (を参照してください[アジャイル オブジェクト C + +/WinRT](agile-objects.md))。 1 つのスレッドを対象としてがだけです。 する方が適切な方法の 1 つのデータまたはその他のアプリケーションのバイナリ インターフェイス (ABI) に通過する場合。

## <a name="base-classes-for-collections"></a>基本のクラスのコレクション

場合は、完全な柔軟性を独自のユーザー設定のコレクションを実装する、したい苦労を実行しないようにします。 たとえば、これはカスタム ベクトル ビューはどのように*C + の支援なし +/WinRT の基本クラス*します。

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

代わりに、カスタム ベクトル ビュー、 [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから取得、および実装するだけでデータを格納しているコンテナーを公開する**get_container**関数ずっと簡単です。

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

**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**位置と**終了**インターフェイスを提供する必要がありますが必要です。 上記の例のように、 **std::vector**を提供します。 独自のカスタム コンテナーなど、同じ契約を満たす任意のコンテナーに戻ることができます。

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

これらは、基本クラス C + +/WinRT は、ユーザー設定のコレクションを実装するために用意されています。

### [<a name="winrtvectorviewbase"></a>winrt::vector_view_base](/uwp/cpp-ref-for-winrt/vector-view-base)

上記の例を参照してください。

### [<a name="winrtvectorbase"></a>winrt::vector_base](/uwp/cpp-ref-for-winrt/vector-base)

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

### [<a name="winrtobservablevectorbase"></a>winrt::observable_vector_base](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### [<a name="winrtmapviewbase"></a>winrt::map_view_base](/uwp/cpp-ref-for-winrt/map-view-base)

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

### [<a name="winrtmapbase"></a>winrt::map_base](/uwp/cpp-ref-for-winrt/map-base)

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

### [<a name="winrtobservablemapbase"></a>winrt::observable_map_base](/uwp/cpp-ref-for-winrt/observable-map-base)

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

## <a name="important-apis"></a>重要な API
* [ItemsControl.ItemsSource](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [IObservableVector](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [IVector](/uwp/api/windows.foundation.collections.ivector_t_)
* [winrt::map_base](/uwp/cpp-ref-for-winrt/map-base)
* [winrt::map_view_base](/uwp/cpp-ref-for-winrt/map-view-base)
* [winrt::observable_map_base](/uwp/cpp-ref-for-winrt/observable-map-base)
* [winrt::observable_vector_base](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [winrt::single_threaded_observable_map](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [winrt::single_threaded_map](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [winrt::single_threaded_observable_vector](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [winrt::single_threaded_vector](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [winrt::vector_base](/uwp/cpp-ref-for-winrt/vector-base)
* [winrt::vector_view_base](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a>関連トピック
* [値のカテゴリ、およびへの参照](cpp-value-categories.md)
* [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md)
