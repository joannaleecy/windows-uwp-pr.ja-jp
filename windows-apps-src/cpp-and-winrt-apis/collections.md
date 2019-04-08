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
# <a name="collections-with-cwinrt"></a>C++/WinRT でのコレクション

内部的には、Windows ランタイムのコレクションには、多くの複雑な移動パーツがあります。 Windows ランタイム関数の場合にコレクション オブジェクトを渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数やが基底クラスで[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)サポートを提供します。 これらの機能は、手の複雑さを解消し、時間と労力で大きなオーバーヘッドを保存します。

[**IVector** ](/uwp/api/windows.foundation.collections.ivector_t_)は要素の任意のランダム アクセス コレクションによって実装される Windows ランタイム インターフェイスです。 実装する場合は**IVector** 、自分で必要も実装する[ **IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [ **IVectorView** ](/uwp/api/windows.foundation.collections.ivectorview_t_)、および[ **IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)します。 場合でもする*必要*カスタム コレクション型は、多くの作業であります。 データがある場合は、 **std::vector** (または**std::map**、または**std::unordered_map**) 避けるたいとし、Windows ランタイム API に渡すがすべて実行します。可能であれば、作業のレベル。 これを回避して*は*可能であれば、ため、C +/cli WinRT には、効率的かつ最小限の労力でコレクションを作成するのに役立ちます。

参照してください[XAML コントロールの項目は、バインド C +/cli WinRT コレクション](binding-collection.md)します。

> [!NOTE]
> 10.0.17763.0 (Windows 10、バージョンは 1809) のバージョンの Windows SDK をインストールしていない場合は、後ではありません関数とこのトピックで説明されている基底クラスへのアクセス。 代わりを参照してください[以前のバージョンの Windows SDK があるかどうかは](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk)代わりに使用できる監視可能なベクター テンプレートの一覧についてはします。

## <a name="helper-functions-for-collections"></a>コレクションのヘルパー関数

### <a name="general-purpose-collection-empty"></a>空の汎用コレクション

ここでは、最初に空のコレクションを作成するシナリオそこから*後*作成します。

汎用コレクションを実装する型の新しいオブジェクトを取得するを呼び出すことができます、 [ **winrt::single_threaded_vector** ](/uwp/cpp-ref-for-winrt/single-threaded-vector)関数テンプレートです。 として、オブジェクトが返されます、 [ **IVector**](/uwp/api/windows.foundation.collections.ivector_t_)、これを使用して、返されたオブジェクトの関数とプロパティを呼び出すインターフェイスです。

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

上記のコード例に示すように、コレクションの作成後に要素を追加、繰り返し処理して、して一般に API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを処理できます。 不変のビューをコレクションに対する必要があるかどうかは、呼び出すことができます[ **IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)に示すようにします。 上記のパターン&mdash;のコレクションの作成と&mdash;API からデータを取得したりする、データを受け渡しする単純なシナリオに適してします。 渡すことができます、 **IVector**、または**IVectorView**、任意の場所、 [ **IIterable** ](/uwp/api/windows.foundation.collections.iiterable_t_)が必要です。

呼び出しを上記のコード例で**winrt::init_apartment** COM を初期化します。 既定では、マルチ スレッド アパートメント内です。

### <a name="general-purpose-collection-primed-from-data"></a>データからの先読みの汎用コレクション

このセクションでは、コレクションを作成し、同時に設定するシナリオについて説明します。

呼び出しのオーバーヘッドを回避できます**Append**上記のコード例にします。 既にソース データ、または Windows ランタイムのコレクション オブジェクトを作成する前にソース データを設定することもできます。 その方法を次に示します。

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

データを格納している一時オブジェクトを渡すことができます**winrt::single_threaded_vector**と同様`coll1`上、します。 移動したり、 **std::vector** (想定しないにアクセスする、もう一度) 関数にします。 どちらの場合も、渡そうとしている、*右辺値*関数にします。 コンパイラを効率的にし、データのコピーを回避するためにできるようにします。 詳細を知りたい場合*rvalue*を参照してください[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)します。

XAML のアイテム コントロールをコレクションにバインドする場合は、ことができます。 正しく設定する、 [ **ItemsControl.ItemsSource** ](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティ、型の値に設定する必要があります**IVector**の**IInspectable**(または、相互運用性の種類などの[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector))。 次に、バインディングの適切な型のコレクションを作成し、要素を追加するコード例を示します。

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

データから Windows ランタイムのコレクションを作成でき、何もコピーすることがなくすべての API に渡すことで、ビューを準備できます。

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

上記の例では、コレクションを作成*できます*にバインドする、XAML コントロールの項目がコレクションには、観測可能なオブジェクトがはありません。

### <a name="observable-collection"></a>監視可能なコレクション

実装する型の新しいオブジェクトを取得する、*オブザーバブル*コレクション、呼び出し、 [ **winrt::single_threaded_observable_vector** ](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)いずれかの関数テンプレート要素の型。 使用して、コレクションは observablecollection に XAML 項目コントロールにバインドに適してが**IInspectable**要素の型として。

として、オブジェクトが返されます、 [ **IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)、これを使用して (または、コントロールがバインドされている)、返されたオブジェクトの関数とプロパティを呼び出すインターフェイスです。

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

詳細については、およびコード例は、ユーザーのバインディングについてインターフェイス (UI) を制御コレクションは observablecollection を参照してください[XAML コントロールの項目は、バインド C +/cli WinRT コレクション](binding-collection.md)します。

### <a name="associative-collection-map"></a>関連コレクション (map)

きた 2 つの関数の関連コレクションのバージョンがあります。

- [ **Winrt::single_threaded_map** ](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートとして非観測可能なオブジェクトの関連コレクションを返します、 [ **IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)します。
- [ **Winrt::single_threaded_observable_map** ](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートとして監視可能な関連コレクションを返します、 [ **IObservableMap** ](/uwp/api/windows.foundation.collections.iobservablemap_k_v_).

関数に渡すことによってこれらのコレクションにデータを準備できます必要に応じて、 *rvalue*型の**std::map**または**std::unordered_map**します。

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

任意の同時実行を指定しないことを示します「シングル スレッド」これらの関数の名前に&mdash;スレッド セーフでない、つまり、します。 スレッドのメンションはこれらの関数から返されるオブジェクトはすべてのアジャイルであるため、アパートメント無関係 (を参照してください[C + でのアジャイル オブジェクト/cli WinRT](agile-objects.md))。 オブジェクトは、シングル スレッドはだけです。 アプリケーション バイナリ インターフェイス (ABI) 間でどちらか 1 つの方法でデータを渡すだけの場合、完全に適合します。

## <a name="base-classes-for-collections"></a>コレクションの基本クラス

場合は、完全な柔軟性を高めるため、独自のカスタム コレクションを実装するためが、これに苦労を回避するためにします。 たとえば、これは、ベクターのカスタム ビューはのようになります*C + の支援を受けることがなく/cli WinRT の基本クラス*します。

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

代わりに、簡単に、ユーザー定義のベクターのビューからの派生は、 [ **winrt::vector_view_base** ](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートだけを実装し、 **get_container**関数データを保持するコンテナーを公開します。

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

によって返されるコンテナー **get_container**提供する必要があります、**開始**と**エンド**インターフェイス**winrt::vector_view_base**が必要です。 上記の例で示すように**std::vector**を提供します。 ただし、独自のカスタム コンテナーを含む、同じコントラクトを満たす任意のコンテナーを返すことができます。

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

これらは、ベース クラス C +/cli WinRT がカスタム コレクションを実装するために提供します。

### <a name="winrtvectorviewbaseuwpcpp-ref-for-winrtvector-view-base"></a>[winrt::vector_view_base](/uwp/cpp-ref-for-winrt/vector-view-base)

上記のコード例を参照してください。

### <a name="winrtvectorbaseuwpcpp-ref-for-winrtvector-base"></a>[winrt::vector_base](/uwp/cpp-ref-for-winrt/vector-base)

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

### <a name="winrtobservablevectorbaseuwpcpp-ref-for-winrtobservable-vector-base"></a>[winrt::observable_vector_base](/uwp/cpp-ref-for-winrt/observable-vector-base)

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

### <a name="winrtmapviewbaseuwpcpp-ref-for-winrtmap-view-base"></a>[winrt::map_view_base](/uwp/cpp-ref-for-winrt/map-view-base)

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

### <a name="winrtmapbaseuwpcpp-ref-for-winrtmap-base"></a>[winrt::map_base](/uwp/cpp-ref-for-winrt/map-base)

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

### <a name="winrtobservablemapbaseuwpcpp-ref-for-winrtobservable-map-base"></a>[winrt::observable_map_base](/uwp/cpp-ref-for-winrt/observable-map-base)

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
* [winrt::map_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/map-base)
* [winrt::map_view_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/map-view-base)
* [winrt::observable_map_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/observable-map-base)
* [winrt::observable_vector_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/observable-vector-base)
* [winrt::single_threaded_observable_map 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)
* [winrt::single_threaded_map 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-map)
* [winrt::single_threaded_observable_vector 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)
* [winrt::single_threaded_vector 関数テンプレート](/uwp/cpp-ref-for-winrt/single-threaded-vector)
* [winrt::vector_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/vector-base)
* [winrt::vector_view_base 構造体のテンプレート](/uwp/cpp-ref-for-winrt/vector-view-base)

## <a name="related-topics"></a>関連トピック
* [値のカテゴリと、その参照](cpp-value-categories.md)
* [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md)
