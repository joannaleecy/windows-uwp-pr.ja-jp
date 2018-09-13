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
# <a name="collections-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>コレクションと[C + + WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

内部的には、Windows のランタイム コレクションには、多くの複雑な可動部があります。 コレクション オブジェクトを Windows ランタイム関数に渡すか、独自のコレクションのプロパティとコレクション型を実装する場合は、関数と基本クラス C + + WinRT をサポートします。 これらの機能は、自分の手の複雑さを解消し、時間と労力で多くのオーバーヘッドを保存します。

> [!IMPORTANT]
> 以降[Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールした場合は、このトピックで説明する機能です。

[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)は、ランダム アクセス コレクションの要素によって実装されている Windows ランタイム インターフェイスです。 **IVector**を自分で実装する場合は、 [**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)、 [**IVectorView**](/uwp/api/windows.foundation.collections.ivectorview_t_)、 [**IIterator**](/uwp/api/windows.foundation.collections.iiterator_t_)を実装する必要がありますがもします。 場合でも、入力する*必要がある*ユーザー設定のコレクションには、多くの作業です。 の**std::vector** (または、 **std::map**、または、 **std::unordered_map**) 内のデータがあり、実行するは Windows ランタイム API に渡す場合はできますが可能な場合はそのレベルの作業を避けるためです。 回避すること*が*可能なため、C + + WinRT では、効率的かつ簡単な作業では、コレクションを作成できます。

## <a name="helper-functions-for-collections"></a>コレクション用のヘルパー関数

### <a name="general-purpose-collection-empty"></a>汎用コレクションは、空

汎用コレクションを実装する型の新しいオブジェクトを取得するには、 [**winrt::single_threaded_vector**](/uwp/cpp-ref-for-winrt/single-threaded-vector)の関数テンプレートを呼び出すことができます。 として[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)の場合、オブジェクトが返され、返されたオブジェクトの関数およびプロパティを呼び出す際のインタ フェースです。

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

上記のコード例でわかるように、コレクションを作成した後要素を追加、それらを反復処理して一般に API から受信したすべての Windows ランタイム コレクション オブジェクトと同様に、オブジェクトを扱います。 コレクションを変更不可のビューをする必要がある場合のように[**IVector::GetView**](/uwp/api/windows.foundation.collections.ivector-1.getview)を呼び出すことができます。 上記のパターン&mdash;コレクションの作成との&mdash;は、単純なシナリオで、データを渡すか、API からのデータを取得する適切な。 **IVector**の場合、または、 **IVectorView**を渡すことができます、任意の場所に[**IIterable**](/uwp/api/windows.foundation.collections.iiterable_t_)が期待されます。

### <a name="general-purpose-collection-primed-from-data"></a>先読みのデータから、汎用のコレクション

また、上記のコード例に表示する**追加**の呼び出しのオーバーヘッドを回避できます。 ソース ・ データが既にまたは Windows ランタイムは、コレクション オブジェクトを作成する前にそれを設定することができます。 その方法をここでは。

```cppwinrt
auto coll1{ winrt::single_threaded_vector<int>({ 1,2,3 }) };

std::vector<int> values{ 1,2,3 };
auto coll2{ winrt::single_threaded_vector<int>(std::move(values)) };

for (auto const& el : coll2)
{
    std::cout << el << std::endl;
}
```

**Winrt::single_threaded_vector**データを含む一時オブジェクトを渡すことができますと同様に`coll1`、上です。 (しないにアクセスする、もう一度と仮定した場合)、 **std::vector**を移動するか、関数にします。 どちらの場合も、*右辺値*を関数に渡します。 効率的にして、データをコピーしないようにするのにはコンパイラを使用できます。 *Rvalue*の詳細を把握したい場合は、[値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)を参照してください。

XAML 項目コントロールをコレクションにバインドする場合は、しすることができます。 ですが、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定するには、する必要があります型**IVector**の**IInspectable** (または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など、相互運用性の種類) の値に設定するのには注意してください。 ここで、バインディングの適切な型のコレクションを作成し、要素を追加するコード例です。

```cppwinrt
auto bookSkus{ winrt::single_threaded_vector<Windows::Foundation::IInspectable>() };
bookSkus.Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
```

データから Windows ランタイムのコレクションを作成し、何もコピーすることがなくすべての API に渡す準備ができて上にビューを取得できます。

```cppwinrt
std::vector<float> values{ 0.1f, 0.2f, 0.3f };
IVectorView<float> view{ winrt::single_threaded_vector(std::move(values)).GetView() };
```

上記の例では、コレクションを作成*できる*コントロールに連結する、XAML 項目です。コレクションが観測可能なオブジェクトはありません。

### <a name="observable-collection"></a>観察可能なコレクション

*観測可能なオブジェクト*のコレクションを実装する型の新しいオブジェクトを取得するには、任意の要素型を持つ[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)の関数テンプレートを呼び出します。 識別可能なコレクションを XAML 項目コントロールにバインドするための適切なするためには、要素の型として**IInspectable**を使用します。

として[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)の場合、オブジェクトが返され、インタ フェースを使用して (または、コントロールがバインドされている) を呼び出して、返されたオブジェクトの関数とプロパティです。

```cppwinrt
auto bookSkus{ winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>() };
```

詳細の詳細とコード例については、のバインド、ユーザー インターフェイス (UI) を制御観察可能なコレクションには、「[アイテムの XAML; C + バインド + WinRT コレクション](binding-collection.md)です。

### <a name="associative-collection-map"></a>連想コレクション (マップ)

見てきましたので、2 つの関数のバージョンを連想のコレクションがあります。

- [**Winrt::single_threaded_map**](/uwp/cpp-ref-for-winrt/single-threaded-map)関数テンプレートでは、 [**IMap**](/uwp/api/windows.foundation.collections.imap_k_v_)と連想以外の観測可能なオブジェクト コレクションを返します。
- [**Winrt::single_threaded_observable_map**](/uwp/cpp-ref-for-winrt/single-threaded-observable-map)関数テンプレートでは、観測可能な[**IObservableMap**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_)として連想コレクションを返します。

型**std::map**または**std::unordered_map**は、*右辺値*を関数に渡すことによってこれらのコレクションにデータをオプションで準備できます。

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

しないすべての同時実行制御を提供することを示す、「単一の」これらの関数の名前を&mdash;つまり、他とは違うスレッド セーフであります。 スレッドの説明とは関係ありませんアパートメントでは、これらの関数から返されるオブジェクトがすべてのアジャイルであるため (を参照してください[アジャイル オブジェクト C + + WinRT](agile-objects.md))。 オブジェクトは、シングル スレッドがだけです。 する方が適切なアプリケーション アプリケーションバイナリインタ フェース (ABI) の間でどちらか 1 つの方法でデータを渡すだけの場合です。

## <a name="base-classes-for-collections"></a>コレクションの基本クラス

場合は、完全な柔軟性を与えるには、独自のカスタム コレクションを実装するために、したいを避けるために苦労します。 たとえば、これは、どのようなユーザー定義のベクター表示のようになります*C + のサポートなし/WinRT の基本クラス*です。

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

代わりに、 [**winrt::vector_view_base**](/uwp/cpp-ref-for-winrt/vector-view-base)構造体のテンプレートから、ユーザー定義のベクター ビューを取得し、データを保持するコンテナーを公開する**get_container**関数を実装するだけに非常に簡単です。

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

**Get_container**によって返されるコンテナー必要があります**開始**と**終了**インタ フェースが提供する**winrt::vector_view_base**が必要です。 上記の例のように、 **std::vector**を提供します。 独自のカスタムのコンテナーを含む、同じコントラクトを満たす任意のコンテナーを返すことができます。

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

これらは、基本クラス C + + のカスタム コレクションを実装するため、WinRT が用意されています。

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
* [IObservableVector インタ フェース](/uwp/api/windows.foundation.collections.iobservablevector_t_)
* [IVector のインタ フェース](/uwp/api/windows.foundation.collections.ivector_t_)
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
* [値のカテゴリ、およびそれらへの参照](cpp-value-categories.md)
* [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md)
