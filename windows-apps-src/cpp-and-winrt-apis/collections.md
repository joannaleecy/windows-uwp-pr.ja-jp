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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3850606"
---
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>コレクションと[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

内部では、Windows ランタイムのコレクションでは、多くの複雑な移動部分があります。 コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクション プロパティとコレクション型を実装する場合は、関数と c++ の基底クラス/WinRT をサポートします。 これらの機能は、手の複雑さを解消し、時間と労力で、多くのオーバーヘッドを保存します。

> [!IMPORTANT]
> このトピックで説明されている機能には、 [Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合に利用可能な以降ができます。

[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、要素の任意のランダム アクセス コレクションによって実装された Windows ランタイム インターフェイスです。 **IVector**を自分で実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要がありますがも。 を入力する*必要がある*カスタム コレクション場合でも、多くの作業です。 たい**std::vector** (または、 **::map**、または**std::unordered_map**) 内のデータがある場合は、Windows ランタイム API に渡すを行うためのすべてが可能であれば、作業のレベルを避けるため。 回避すること*は*できる限り、ためと、C++/WinRT では、わずかな労力で効率的にし、コレクションを作成するのに役立ちます。

## <a name="helper-functions-for-collections"></a>コレクションのヘルパー関数

### <a name="general-purpose-collection-empty"></a>空の汎用的なコレクション

汎用のコレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートを呼び出すことができます。 [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、として、オブジェクトが返され、返されるオブジェクトの関数とプロパティを呼び出すことによってこれインターフェイスです。

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

上記のコード例で示すように、コレクションを作成した後要素を追加、それらを反復処理して通常 API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを処理できます。 コレクションを固定のビューを必要がある場合に示すように[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。 前に示したパターン&mdash;のコレクションの作成と&mdash;が、データを渡すか、API からデータを取得する単純なシナリオに適しています。 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)が予想される任意の場所は、 **IVector**の場合、または、 **IVectorView**に渡すことができます。

### <a name="general-purpose-collection-primed-from-data"></a>データから先読み、汎用的なコレクション

また、上記のコード例で表示される**追加**の呼び出しのオーバーヘッドを回避できます。 ソース データが既にまたは Windows ランタイムのコレクション オブジェクトを作成する前にデータを設定することができます。 その方法を以下に示します。

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

**Winrt::single_threaded_vector**にデータを含む、一時的なオブジェクトを渡すことができますと同様に`coll1`額。 (されませんにアクセスして、もう一度していれば) **std::vector**を移動するか、関数にします。 どちらの場合も、関数に、*右辺値*を渡しています。 これにより、コンパイラ効率的にし、データのコピーを回避することができます。 を*rvalue*について詳しく知りたい場合は、[値のカテゴリとへの参照](cpp-value-categories.md)を参照してください。

XAML アイテム コントロールをコレクションにバインドする場合することができます。 ただし、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定する必要が**IVector** **IInspectable** (または、相互運用性の種類[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など) の種類の値に設定することに注意してください。 以下に、バインディングの適切な種類のコレクションを作成し、それを要素に追加のコード例を示します。

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

データから、Windows ランタイムのコレクションを作成し、何かをコピーすることがなくすべての API に渡すことで、ビューを準備できます。

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

上記の例では、コレクション*を*作成しますが XAML アイテム コントロールにバインドします。コレクションが監視可能なはありません。

### <a name="observable-collection"></a>監視可能なコレクション

*監視可能な*コレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型を[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)関数テンプレートを呼び出します。 監視可能なコレクションを XAML アイテム コントロールをバインドに適したさせるには、要素の種類として**IInspectable**を使用します。

[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、として、オブジェクトが返され、インターフェイスを経由する (またはバインドされているコントロール) を呼び出して、返されるオブジェクトの関数とプロパティです。

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

詳細についてとコード例は、ユーザーのバインディングについてインターフェイス (UI) コントロールを監視可能なコレクションは、「 [c++ へのバインド XAML アイテム コントロール/WinRT コレクション](binding-collection.md)します。

### <a name="associative-collection-map"></a>また、関連のコレクション (マップ)

説明した 2 つの関数のバージョンを連想コレクションがあります。

- [**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートでは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)として連想監視可能ではないコレクションを返します。
- [**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートでは、監視可能な[**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として連想コレクションを返します。

種類 **::map**または**std::unordered_map**の*右辺値*関数に渡すことによってこれらのコレクションにデータを必要に応じて素数ことができます。

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

### <a name="single-threaded"></a>シングル スレッド

すべての同時実行を用意しないことを示す、「シングル スレッド」これらの関数の名前に&mdash;スレッド セーフが不明、つまり、します。 スレッドの説明はこれらの関数から返されたオブジェクトはすべてアジャイルであるため、アパートメント無関係 (を参照してください[アジャイル オブジェクトの c++/WinRT](agile-objects.md))。 オブジェクトは、シングル スレッドですだけです。 する方が適切な方法の 1 つのデータまたはその他のアプリケーション バイナリ インターフェイス (ABI) に通過する場合。

## <a name="base-classes-for-collections"></a>コレクションの基底クラス

、完全な柔軟性を、独自のカスタム コレクションを実装する場合、するされる場合は、ハード方法は、これを行うようにします。 たとえば、これは、ベクトルのカスタム ビューは次のよう *、C++ のサポートなし/WinRT の基底クラス*します。

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

代わりに、大幅に容易[**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから、ベクトルのカスタム ビューを派生し、データを保持するコンテナーを公開する**get_container**関数を実装するのにです。

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

**Get_container**によって返されるコンテナーするその**winrt::vector_view_base** **開始**と**終了**のインターフェイスを提供する必要がありますが想定されます。 上記の例のようにを**std::vector**を提供します。 ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たすすべてのコンテナーを返すことができます。

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

これらは、基本クラス C + + WinRT を提供して、カスタムのコレクションを実装できます。

### [<a name="winrtvectorviewbase"></a>winrt::vector_view_base](/uwp/cpp-ref-for-winrt/vector-view-base)

上記のコード例を参照してください。

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
* [ItemsControl.ItemsSource プロパティ](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)
* [IObservableVector インターフェイス](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [IVector インターフェイス](/uwp/api/windows.foundation.collections.ivector_t_)
* [winrt::map_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/map-base)
* [winrt::map_view_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/map-view-base)
* [winrt::observable_map_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/observable-map-base)
* [winrt::observable_vector_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [winrt::single_threaded_observable_map 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [winrt::single_threaded_map 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [winrt::single_threaded_observable_vector 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [winrt::single_threaded_vector 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [winrt::vector_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/vector-base)
* [winrt::vector_view_base 構造体テンプレート](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a>関連トピック
* [値のカテゴリとへの参照](cpp-value-categories.md)
* [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md)
