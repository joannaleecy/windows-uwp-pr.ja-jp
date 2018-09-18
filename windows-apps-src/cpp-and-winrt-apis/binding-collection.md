---
author: stevewhims
description: XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 このトピックでは、監視可能なコレクションを実装および使用する方法と、それに XAML アイテム コントロールをバインドする方法を示します。
title: 'XAML アイテム コントロール: C++/WinRT コレクションへのバインド'
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML、コントロール、バインド、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: 9ba935b1a5316c2d7af9c7681705595efea7ca08
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4020530"
---
# <a name="xaml-items-controls-bind-to-a-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-collection"></a>XAML アイテム コントロール: [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) コレクションへのバインド
> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。 このトピックでは、C++/WinRT で監視可能なコレクションを実装する方法と、これらに XAML アイテム コントロールをバインドする方法を示します。

このチュートリアルでは、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」で作成したプロジェクトをビルドし、そのトピックで説明する概念に追加します。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="what-does-observable-mean-for-a-collection"></a>コレクションの*監視可能*とはどういう意味ですか?
コレクションを表すランタイム クラスが、要素が追加されるまたは削除されるたびに [**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生することを選択する場合、そのランタイム クラスは監視可能なコレクションです。 XAML アイテム コントロールでは、更新されたコレクションを取得して、現在の要素を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

## <a name="implement-singlethreadedobservablevectorlttgt"></a>**single_threaded_observable_vector&lt;T&gt;** を実装する
[**IObservableVector&lt;T&gt;**](/uwp/api/windows.foundation.collections.iobservablevector_t_) の便利で汎用的な実装として機能するように、監視可能なベクター テンプレートを持つことは役に立ちます。 次に **single_threaded_observable_vector\<T\>** と呼ばれるクラスの一覧を示します。

> [!NOTE]
> [Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合、後で、できるだけ直接使用する**winrt::single_threaded_observable_vector \ < t \ >** ファクトリ関数以下に示すコードではなく (については、正確なコード後述このトピックで)。 場合に接続していない既にそのバージョンの SDK をし、ことがへの切り替えが**winrt**関数をコードの登録情報のバージョンを使用して簡単です。

```cppwinrt
// single_threaded_observable_vector.h
#pragma once

namespace winrt::Bookstore::implementation
{
    using namespace Windows::Foundation::Collections;

    template <typename T>
    struct single_threaded_observable_vector : implements<single_threaded_observable_vector<T>,
        IObservableVector<T>,
        IVector<T>,
        IVectorView<T>,
        IIterable<T>>
    {
        event_token VectorChanged(VectorChangedEventHandler<T> const& handler)
        {
            return m_changed.add(handler);
        }

        void VectorChanged(event_token const cookie)
        {
            m_changed.remove(cookie);
        }

        T GetAt(uint32_t const index) const
        {
            if (index >= m_values.size())
            {
                throw hresult_out_of_bounds();
            }

            return m_values[index];
        }

        uint32_t Size() const noexcept
        {
            return static_cast<uint32_t>(m_values.size());
        }

        IVectorView<T> GetView()
        {
            return *this;
        }

        bool IndexOf(T const& value, uint32_t& index) const noexcept
        {
            index = static_cast<uint32_t>(std::find(m_values.begin(), m_values.end(), value) - m_values.begin());
            return index < m_values.size();
        }

        void SetAt(uint32_t const index, T const& value)
        {
            if (index >= m_values.size())
            {
                throw hresult_out_of_bounds();
            }

            ++m_version;
            m_values[index] = value;
            m_changed(*this, make<args>(CollectionChange::ItemChanged, index));
        }

        void InsertAt(uint32_t const index, T const& value)
        {
            if (index > m_values.size())
            {
                throw hresult_out_of_bounds();
            }

            ++m_version;
            m_values.insert(m_values.begin() + index, value);
            m_changed(*this, make<args>(CollectionChange::ItemInserted, index));
        }

        void RemoveAt(uint32_t const index)
        {
            if (index >= m_values.size())
            {
                throw hresult_out_of_bounds();
            }

            ++m_version;
            m_values.erase(m_values.begin() + index);
            m_changed(*this, make<args>(CollectionChange::ItemRemoved, index));
        }

        void Append(T const& value)
        {
            ++m_version;
            m_values.push_back(value);
            m_changed(*this, make<args>(CollectionChange::ItemInserted, Size() - 1));
        }

        void RemoveAtEnd()
        {
            if (m_values.empty())
            {
                throw hresult_out_of_bounds();
            }

            ++m_version;
            m_values.pop_back();
            m_changed(*this, make<args>(CollectionChange::ItemRemoved, Size()));
        }

        void Clear() noexcept
        {
            ++m_version;
            m_values.clear();
            m_changed(*this, make<args>(CollectionChange::Reset, 0));
        }

        uint32_t GetMany(uint32_t const startIndex, array_view<T> values) const
        {
            if (startIndex >= m_values.size())
            {
                return 0;
            }

            uint32_t actual = static_cast<uint32_t>(m_values.size() - startIndex);

            if (actual > values.size())
            {
                actual = values.size();
            }

            std::copy_n(m_values.begin() + startIndex, actual, values.begin());
            return actual;
        }

        void ReplaceAll(array_view<T const> value)
        {
            ++m_version;
            m_values.assign(value.begin(), value.end());
            m_changed(*this, make<args>(CollectionChange::Reset, 0));
        }

        IIterator<T> First()
        {
            return make<iterator>(this);
        }

    private:

        std::vector<T> m_values;
        event<VectorChangedEventHandler<T>> m_changed;
        uint32_t m_version{};

        struct args : implements<args, IVectorChangedEventArgs>
        {
            args(CollectionChange const change, uint32_t const index) :
                m_change(change),
                m_index(index)
            {
            }

            CollectionChange CollectionChange() const
            {
                return m_change;
            }

            uint32_t Index() const
            {
                return m_index;
            }

        private:

            Windows::Foundation::Collections::CollectionChange const m_change{};
            uint32_t const m_index{};
        };

        struct iterator : implements<iterator, IIterator<T>>
        {
            explicit iterator(single_threaded_observable_vector<T>* owner) noexcept :
            m_version(owner->m_version),
                m_current(owner->m_values.begin()),
                m_end(owner->m_values.end())
            {
                m_owner.copy_from(owner);
            }

            void abi_enter() const
            {
                if (m_version != m_owner->m_version)
                {
                    throw hresult_changed_state();
                }
            }

            T Current() const
            {
                if (m_current == m_end)
                {
                    throw hresult_out_of_bounds();
                }

                return*m_current;
            }

            bool HasCurrent() const noexcept
            {
                return m_current != m_end;
            }

            bool MoveNext() noexcept
            {
                if (m_current != m_end)
                {
                    ++m_current;
                }

                return HasCurrent();
            }

            uint32_t GetMany(array_view<T> values)
            {
                uint32_t actual = static_cast<uint32_t>(std::distance(m_current, m_end));

                if (actual > values.size())
                {
                    actual = values.size();
                }

                std::copy_n(m_current, actual, values.begin());
                std::advance(m_current, actual);
                return actual;
            }

        private:

            com_ptr<single_threaded_observable_vector<T>> m_owner;
            uint32_t const m_version;
            typename std::vector<T>::const_iterator m_current;
            typename std::vector<T>::const_iterator const m_end;
        };
    };
}
```

**Append** 関数は、[**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生させる方法を示しています。

```cppwinrt
m_changed(*this, make<args>(CollectionChange::ItemInserted, Size() - 1));
```

イベントの引数は、要素が挿入されていることと、そのインデックスが何であるか (ここでは最後の要素) を示します。 これらの引数は、最適な方法で XAML アイテム コントロールがイベントに応答し、それ自体を更新できるようにします。

## <a name="add-a-bookskus-collection-to-bookstoreviewmodel"></a>**BookSkus** コレクションを **BookstoreViewModel** に追加する
「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」では、**BookSku** 型のプロパティをメイン ビュー モデルに追加しました。 この手順では、**single_threaded_observable_vector&lt;T&gt;** を使用して、同じビュー モデルへの **BookSku** の監視可能なコレクションの実装に役立てます。

`BookstoreViewModel.idl` で新しいプロパティを宣言します。

```idl
// BookstoreViewModel.idl
...
runtimeclass BookstoreViewModel
{
    BookSku BookSku{ get; };
    Windows.Foundation.Collections.IVector<IInspectable> BookSkus{ get; };
}
...
```

> [!IMPORTANT]
> 上記の MIDL 3.0 一覧で**BookSkus**プロパティの型が[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821)の注意してください。 このトピックの次のセクションでは**BookSkus**に[**リスト ボックス**](/uwp/api/windows.ui.xaml.controls.listbox)の項目ソースおバインドするがあります。 リスト ボックスは、項目コントロールと[**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定するには、型の**IVector** **IInspectable**、または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)など、相互運用性の種類の値に設定する必要があります。

保存してビルドします。 `Generated Files` フォルダーの `BookstoreViewModel.h` と `BookstoreViewModel.cpp` からアクセサー スタブをコピーし、それらを実装します。

```cppwinrt
// BookstoreViewModel.h
...
#include "single_threaded_observable_vector.h"
...
struct BookstoreViewModel : BookstoreViewModelT<BookstoreViewModel>
{
    BookstoreViewModel();

    Bookstore::BookSku BookSku();

    Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> BookSkus();

private:
    Bookstore::BookSku m_bookSku{ nullptr };
    Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> m_bookSkus;
};
...
```

```cppwinrt
// BookstoreViewModel.cpp
...
BookstoreViewModel::BookstoreViewModel()
{
    m_bookSku = make<Bookstore::implementation::BookSku>(L"Atticus");
    m_bookSkus = winrt::make<single_threaded_observable_vector<Windows::Foundation::IInspectable>>();
    m_bookSkus.Append(m_bookSku);
}

Bookstore::BookSku BookstoreViewModel::BookSku()
{
    return m_bookSku;
}

Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> BookstoreViewModel::BookSkus()
{
    return m_bookSkus;
}
...
```

## <a name="if-you-have-a-windows-10-sdk-preview-build"></a>Windows 10 SDK プレビュー ビルドがある場合
[Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした場合や、後で、し、次のコード行を置き換えます

```cppwinrt
m_bookSkus = winrt::make<single_threaded_observable_vector<Windows::Foundation::IInspectable>>();
```

こっちと。

```cppwinrt
m_bookSkus = winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>();
```

[**Winrt::make**](https://docs.microsoft.com/en-us/uwp/cpp-ref-for-winrt/make)を呼び出すことではなく、 **winrt::single_threaded_observable_vector \ < t \ >** ファクトリ関数を呼び出すことによって、適切なコレクション オブジェクトを作成します。

## <a name="bind-a-listbox-to-the-bookskus-property"></a>**BookSkus** プロパティに ListBox をバインドします。
メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 **Button** と同じ **StackPanel** 内に次のマークアップを追加します。

```xaml
<ListBox ItemsSource="{x:Bind MainViewModel.BookSkus}">
    <ItemsControl.ItemTemplate>
        <DataTemplate x:DataType="local:BookSku">
            <TextBlock Text="{x:Bind Title, Mode=OneWay}"/>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ListBox>
```

`MainPage.cpp` で、**クリック** イベント ハンドラーにコードの行を追加してブックをコレクションに追加します。

```cppwinrt
// MainPage.cpp
...
void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
{
    MainViewModel().BookSku().Title(L"To Kill a Mockingbird");
    MainViewModel().BookSkus().Append(make<Bookstore::implementation::BookSku>(L"Moby Dick"));
}
...
```

ここでプロジェクトをビルドして実行します。 ボタンをクリックして**クリック** イベント ハンドラーを実行します。 **Append** の実装によりイベントが発生し、コレクションが変更されたことを UI が把握できるようにすることが分かります。**ListBox** はその独自の **Items** 値を更新するためにコレクションを再クエリします。 前と同様に、ブックのいずれかのタイトルが変わります。このタイトル変更は、ボタンとリスト ボックス内の両方に反映されます。

## <a name="important-apis"></a>重要な API
* [IObservableVector&lt;T&gt;::VectorChanged](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT での API の作成](author-apis.md)
