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
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2865951"
---
# <a name="xaml-items-controls-bind-to-a-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-collection"></a><span data-ttu-id="b6e5f-105">XAML アイテム コントロール: [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="b6e5f-105">XAML items controls; bind to a [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) collection</span></span>
> [!NOTE]
> **<span data-ttu-id="b6e5f-106">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-106">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="b6e5f-107">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-107">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="b6e5f-108">XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-108">A collection that can be effectively bound to a XAML items control is known as an *observable* collection.</span></span> <span data-ttu-id="b6e5f-109">この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-109">This idea is based on the software design pattern known as the *observer pattern*.</span></span> <span data-ttu-id="b6e5f-110">このトピックでは、C++/WinRT で監視可能なコレクションを実装する方法と、これらに XAML アイテム コントロールをバインドする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-110">This topic shows how to implement observable collections in C++/WinRT, and how to bind XAML items controls to them.</span></span>

<span data-ttu-id="b6e5f-111">このチュートリアルでは、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」で作成したプロジェクトをビルドし、そのトピックで説明する概念に追加します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-111">This walkthrough builds on the project created in [XAML controls; bind to a C++/WinRT property](binding-property.md), and it adds to the concepts explained in that topic.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b6e5f-112">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-112">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="what-does-observable-mean-for-a-collection"></a><span data-ttu-id="b6e5f-113">コレクションの*監視可能*とはどういう意味ですか?</span><span class="sxs-lookup"><span data-stu-id="b6e5f-113">What does *observable* mean for a collection?</span></span>
<span data-ttu-id="b6e5f-114">コレクションを表すランタイム クラスが、要素が追加されるまたは削除されるたびに [**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生することを選択する場合、そのランタイム クラスは監視可能なコレクションです。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-114">If a runtime class that represents a collection chooses to raise the [**IObservableVector&lt;T&gt;::VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) event whenever an element is added to it or removed from it, then the runtime class is an observable collection.</span></span> <span data-ttu-id="b6e5f-115">XAML アイテム コントロールでは、更新されたコレクションを取得して、現在の要素を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-115">A XAML items control can bind to, and handle, these events by retrieving the updated collection and then updating itself to show the current elements.</span></span>

> [!NOTE]
> <span data-ttu-id="b6e5f-116">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-116">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="implement-singlethreadedobservablevectorlttgt"></a><span data-ttu-id="b6e5f-117">**single_threaded_observable_vector&lt;T&gt;** を実装する</span><span class="sxs-lookup"><span data-stu-id="b6e5f-117">Implement **single_threaded_observable_vector&lt;T&gt;**</span></span>
<span data-ttu-id="b6e5f-118">[**IObservableVector&lt;T&gt;**](/uwp/api/windows.foundation.collections.iobservablevector_t_) の便利で汎用的な実装として機能するように、監視可能なベクター テンプレートを持つことは役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-118">It will be good to have an observable vector template to serve as a useful, general-purpose implementation of  [**IObservableVector&lt;T&gt;**](/uwp/api/windows.foundation.collections.iobservablevector_t_).</span></span> <span data-ttu-id="b6e5f-119">次に **single_threaded_observable_vector\<T\>** と呼ばれるクラスの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-119">Below is a listing of a class called **single_threaded_observable_vector\<T\>**.</span></span>

> [!NOTE]
> <span data-ttu-id="b6e5f-120">[Windows 10 SDK Preview ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールしたまたは後で、することができます直接した関数を使用して**winrt::single_threaded_observable_vector\ < T\ >** 出荷時の下にあるコードではなく (は、紹介、正確なコード以降このトピックで)。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-120">If you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later, then you can just directly use the **winrt::single_threaded_observable_vector\<T\>** factory function instead of the code listing below (we'll show the exact code later in this topic).</span></span> <span data-ttu-id="b6e5f-121">ない場合は既に SDK のバージョンで、[ことが簡単にする場合は、 **winrt**関数にコード表示されているバージョンを使用してから、上に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-121">If you're not already on that version of the SDK, then it will be easy to switch over from using the code listing version to the **winrt** function when you are.</span></span>

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

<span data-ttu-id="b6e5f-122">**Append** 関数は、[**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生させる方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-122">The **Append** function illustrates how to raise the [**IObservableVector&lt;T&gt;::VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) event.</span></span>

```cppwinrt
m_changed(*this, make<args>(CollectionChange::ItemInserted, Size() - 1));
```

<span data-ttu-id="b6e5f-123">イベントの引数は、要素が挿入されていることと、そのインデックスが何であるか (ここでは最後の要素) を示します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-123">The event arguments indicate both that an element was inserted, and also what its index is (the last element, in this case).</span></span> <span data-ttu-id="b6e5f-124">これらの引数は、最適な方法で XAML アイテム コントロールがイベントに応答し、それ自体を更新できるようにします。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-124">These arguments enable a XAML items control to respond to the event and to refresh itself in the optimal way.</span></span>

## <a name="add-a-bookskus-collection-to-bookstoreviewmodel"></a><span data-ttu-id="b6e5f-125">**BookSkus** コレクションを **BookstoreViewModel** に追加する</span><span class="sxs-lookup"><span data-stu-id="b6e5f-125">Add a **BookSkus** collection to **BookstoreViewModel**</span></span>
<span data-ttu-id="b6e5f-126">「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」では、**BookSku** 型のプロパティをメイン ビュー モデルに追加しました。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-126">In [XAML controls; bind to a C++/WinRT property](binding-property.md), we added a property of type **BookSku** to our main view model.</span></span> <span data-ttu-id="b6e5f-127">この手順では、**single_threaded_observable_vector&lt;T&gt;** を使用して、同じビュー モデルへの **BookSku** の監視可能なコレクションの実装に役立てます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-127">In this step, we'll use **single_threaded_observable_vector&lt;T&gt;** to help us implement an observable collection of **BookSku** on the same view model.</span></span>

<span data-ttu-id="b6e5f-128">`BookstoreViewModel.idl` で新しいプロパティを宣言します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-128">Declare a new property in `BookstoreViewModel.idl`.</span></span>

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
> <span data-ttu-id="b6e5f-129">上記の MIDL 3.0 一覧で、 **BookSkus**プロパティの種類が[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821)の注意してください。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-129">In the MIDL 3.0 listing above, note that the type of the **BookSkus** property is [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821).</span></span> <span data-ttu-id="b6e5f-130">このトピックの次のセクションでは**BookSkus**に[**リスト ボックス**](/uwp/api/windows.ui.xaml.controls.listbox)のアイテムのソースはバインドするされます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-130">In the next section of this topic, we'll be binding the items source of a [**ListBox**](/uwp/api/windows.ui.xaml.controls.listbox) to **BookSkus**.</span></span> <span data-ttu-id="b6e5f-131">リスト ボックスは、アイテム コントロールであり、 [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを正しく設定するには、型**IVector** **IInspectable**、または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)などの相互運用性型の値に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-131">A list box is an items control, and to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IVector** of **IInspectable**, or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span>

<span data-ttu-id="b6e5f-132">保存してビルドします。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-132">Save and build.</span></span> <span data-ttu-id="b6e5f-133">`Generated Files` フォルダーの `BookstoreViewModel.h` と `BookstoreViewModel.cpp` からアクセサー スタブをコピーし、それらを実装します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-133">Copy the accessor stubs from `BookstoreViewModel.h` and `BookstoreViewModel.cpp` in the `Generated Files` folder, and implement them.</span></span>

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

## <a name="if-you-have-a-windows-10-sdk-preview-build"></a><span data-ttu-id="b6e5f-134">Windows 10 SDK Preview ビルドがある場合</span><span class="sxs-lookup"><span data-stu-id="b6e5f-134">If you have a Windows 10 SDK Preview Build</span></span>
<span data-ttu-id="b6e5f-135">[Windows 10 SDK Preview ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)では、インストールした場合、または後で、[コードの行を置き換える</span><span class="sxs-lookup"><span data-stu-id="b6e5f-135">If you've installed the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later, then replace this line of code</span></span>

```cppwinrt
m_bookSkus = winrt::make<single_threaded_observable_vector<Windows::Foundation::IInspectable>>();
```

<span data-ttu-id="b6e5f-136">こっちと。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-136">with this.</span></span>

```cppwinrt
m_bookSkus = winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>();
```

<span data-ttu-id="b6e5f-137">[**Winrt::make**](https://docs.microsoft.com/en-us/uwp/cpp-ref-for-winrt/make)を呼び出すとではなく、 **winrt::single_threaded_observable_vector\ < T\ >** ファクトリ関数を使用して、適切なコレクション オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-137">Instead of calling [**winrt::make**](https://docs.microsoft.com/en-us/uwp/cpp-ref-for-winrt/make), you create the appropriate collection object by calling the **winrt::single_threaded_observable_vector\<T\>** factory function.</span></span>

## <a name="bind-a-listbox-to-the-bookskus-property"></a><span data-ttu-id="b6e5f-138">**BookSkus** プロパティに ListBox をバインドします。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-138">Bind a ListBox to the **BookSkus** property</span></span>
<span data-ttu-id="b6e5f-139">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-139">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="b6e5f-140">**Button** と同じ **StackPanel** 内に次のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-140">Add the following markup inside the same **StackPanel** as the **Button**.</span></span>

```xaml
<ListBox ItemsSource="{x:Bind MainViewModel.BookSkus}">
    <ItemsControl.ItemTemplate>
        <DataTemplate x:DataType="local:BookSku">
            <TextBlock Text="{x:Bind Title, Mode=OneWay}"/>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ListBox>
```

<span data-ttu-id="b6e5f-141">`MainPage.cpp` で、**クリック** イベント ハンドラーにコードの行を追加してブックをコレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-141">In `MainPage.cpp`, add a line of code to the **Click** event handler to append a book to the collection.</span></span>

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

<span data-ttu-id="b6e5f-142">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-142">Now build and run the project.</span></span> <span data-ttu-id="b6e5f-143">ボタンをクリックして**クリック** イベント ハンドラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-143">Click the button to execute the **Click** event handler.</span></span> <span data-ttu-id="b6e5f-144">**Append** の実装によりイベントが発生し、コレクションが変更されたことを UI が把握できるようにすることが分かります。**ListBox** はその独自の **Items** 値を更新するためにコレクションを再クエリします。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-144">We saw that the implementation of **Append** raises an event to let the UI know that the collection has changed; and the **ListBox** re-queries the collection to update its own **Items** value.</span></span> <span data-ttu-id="b6e5f-145">前と同様に、ブックのいずれかのタイトルが変わります。このタイトル変更は、ボタンとリスト ボックス内の両方に反映されます。</span><span class="sxs-lookup"><span data-stu-id="b6e5f-145">Just as before, the title of one of the books changes; and that title change is reflected both on the button and in the list box.</span></span>

## <a name="important-apis"></a><span data-ttu-id="b6e5f-146">重要な API</span><span class="sxs-lookup"><span data-stu-id="b6e5f-146">Important APIs</span></span>
* [<span data-ttu-id="b6e5f-147">IObservableVector&lt;T&gt;::VectorChanged</span><span class="sxs-lookup"><span data-stu-id="b6e5f-147">IObservableVector&lt;T&gt;::VectorChanged</span></span>](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged)
* [<span data-ttu-id="b6e5f-148">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="b6e5f-148">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a><span data-ttu-id="b6e5f-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b6e5f-149">Related topics</span></span>
* [<span data-ttu-id="b6e5f-150">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="b6e5f-150">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="b6e5f-151">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="b6e5f-151">Author APIs with C++/WinRT</span></span>](author-apis.md)
