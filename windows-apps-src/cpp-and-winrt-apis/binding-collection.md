---
author: stevewhims
description: XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 このトピックでは、監視可能なコレクションを実装および使用する方法と、それに XAML アイテム コントロールをバインドする方法を示します。
title: 'XAML アイテム コントロール: C++/WinRT コレクションへのバインド'
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML、コントロール、バインド、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: f9d9d6a2aafe1b81ff331bac92662b111eb48956
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5743530"
---
# <a name="xaml-items-controls-bind-to-a-cwinrt-collection"></a><span data-ttu-id="03a29-105">XAML アイテム コントロール: C++/WinRT コレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="03a29-105">XAML items controls; bind to a C++/WinRT collection</span></span>

<span data-ttu-id="03a29-106">XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="03a29-106">A collection that can be effectively bound to a XAML items control is known as an *observable* collection.</span></span> <span data-ttu-id="03a29-107">この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。</span><span class="sxs-lookup"><span data-stu-id="03a29-107">This idea is based on the software design pattern known as the *observer pattern*.</span></span> <span data-ttu-id="03a29-108">このトピックで監視可能なコレクションを実装する方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、XAML にバインドする方法をコントロールの項目とします。</span><span class="sxs-lookup"><span data-stu-id="03a29-108">This topic shows how to implement observable collections in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), and how to bind XAML items controls to them.</span></span>

<span data-ttu-id="03a29-109">このチュートリアルでは、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」で作成したプロジェクトをビルドし、そのトピックで説明する概念に追加します。</span><span class="sxs-lookup"><span data-stu-id="03a29-109">This walkthrough builds on the project created in [XAML controls; bind to a C++/WinRT property](binding-property.md), and it adds to the concepts explained in that topic.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="03a29-110">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="03a29-110">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="what-does-observable-mean-for-a-collection"></a><span data-ttu-id="03a29-111">コレクションの*監視可能*とはどういう意味ですか?</span><span class="sxs-lookup"><span data-stu-id="03a29-111">What does *observable* mean for a collection?</span></span>
<span data-ttu-id="03a29-112">コレクションを表すランタイム クラスが、要素が追加されるまたは削除されるたびに [**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生することを選択する場合、そのランタイム クラスは監視可能なコレクションです。</span><span class="sxs-lookup"><span data-stu-id="03a29-112">If a runtime class that represents a collection chooses to raise the [**IObservableVector&lt;T&gt;::VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) event whenever an element is added to it or removed from it, then the runtime class is an observable collection.</span></span> <span data-ttu-id="03a29-113">XAML アイテム コントロールでは、更新されたコレクションを取得して、現在の要素を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。</span><span class="sxs-lookup"><span data-stu-id="03a29-113">A XAML items control can bind to, and handle, these events by retrieving the updated collection and then updating itself to show the current elements.</span></span>

> [!NOTE]
> <span data-ttu-id="03a29-114">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="03a29-114">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="add-a-bookskus-collection-to-bookstoreviewmodel"></a><span data-ttu-id="03a29-115">**BookSkus** コレクションを **BookstoreViewModel** に追加する</span><span class="sxs-lookup"><span data-stu-id="03a29-115">Add a **BookSkus** collection to **BookstoreViewModel**</span></span>

<span data-ttu-id="03a29-116">「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」では、**BookSku** 型のプロパティをメイン ビュー モデルに追加しました。</span><span class="sxs-lookup"><span data-stu-id="03a29-116">In [XAML controls; bind to a C++/WinRT property](binding-property.md), we added a property of type **BookSku** to our main view model.</span></span> <span data-ttu-id="03a29-117">この手順で使います[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)ファクトリ関数テンプレートを同じビュー モデルの**BookSku**の監視可能なコレクションを実装できるようにします。</span><span class="sxs-lookup"><span data-stu-id="03a29-117">In this step, we'll use the [**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector) factory function template to help us implement an observable collection of **BookSku** on the same view model.</span></span>

> [!NOTE]
> <span data-ttu-id="03a29-118">Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールしていないかが後で、し、表示場合[Windows SDK の以前のバージョンがある場合](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk) **winrt::single_ の代わりに使用できる、監視可能なベクター テンプレートの一覧についてはthreaded_observable_vector**します。</span><span class="sxs-lookup"><span data-stu-id="03a29-118">If you haven't installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later, then see [If you have an older version of the Windows SDK](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk) for a listing of an observable vector template that you can use instead of **winrt::single_threaded_observable_vector**.</span></span>

<span data-ttu-id="03a29-119">`BookstoreViewModel.idl` で新しいプロパティを宣言します。</span><span class="sxs-lookup"><span data-stu-id="03a29-119">Declare a new property in `BookstoreViewModel.idl`.</span></span>

```idl
// BookstoreViewModel.idl
...
runtimeclass BookstoreViewModel
{
    BookSku BookSku{ get; };
    Windows.Foundation.Collections.IObservableVector<IInspectable> BookSkus{ get; };
}
...
```

> [!IMPORTANT]
> <span data-ttu-id="03a29-120">上記の MIDL 3.0 一覧で [ **BookSkus**プロパティの型が[**IObservableVector**](/uwp/api/windows.foundation.collections.ivector_t_) [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)の注意してください。</span><span class="sxs-lookup"><span data-stu-id="03a29-120">In the MIDL 3.0 listing above, note that the type of the **BookSkus** property is [**IObservableVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable).</span></span> <span data-ttu-id="03a29-121">このトピックの次のセクションでは**BookSkus**に[**リスト ボックス**](/uwp/api/windows.ui.xaml.controls.listbox)の項目ソースしますバインドするされます。</span><span class="sxs-lookup"><span data-stu-id="03a29-121">In the next section of this topic, we'll be binding the items source of a [**ListBox**](/uwp/api/windows.ui.xaml.controls.listbox) to **BookSkus**.</span></span> <span data-ttu-id="03a29-122">リスト ボックスは、項目コントロールと正しく[**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを設定する必要があります**IObservableVector**型の値に (または**IVector**) を設定する**IInspectable**、または[**など、相互運用性の種類のIBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)します。</span><span class="sxs-lookup"><span data-stu-id="03a29-122">A list box is an items control, and to correctly set the [**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource) property, you need to set it to a value of type **IObservableVector** (or **IVector**) of **IInspectable**, or of an interoperability type such as [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span>

<span data-ttu-id="03a29-123">保存してビルドします。</span><span class="sxs-lookup"><span data-stu-id="03a29-123">Save and build.</span></span> <span data-ttu-id="03a29-124">`Generated Files` フォルダーの `BookstoreViewModel.h` と `BookstoreViewModel.cpp` からアクセサー スタブをコピーし、それらを実装します。</span><span class="sxs-lookup"><span data-stu-id="03a29-124">Copy the accessor stubs from `BookstoreViewModel.h` and `BookstoreViewModel.cpp` in the `Generated Files` folder, and implement them.</span></span>

```cppwinrt
// BookstoreViewModel.h
...
struct BookstoreViewModel : BookstoreViewModelT<BookstoreViewModel>
{
    BookstoreViewModel();

    Bookstore::BookSku BookSku();

    Windows::Foundation::Collections::IObservableVector<Windows::Foundation::IInspectable> BookSkus();

private:
    Bookstore::BookSku m_bookSku{ nullptr };
    Windows::Foundation::Collections::IObservableVector<Windows::Foundation::IInspectable> m_bookSkus;
};
...
```

```cppwinrt
// BookstoreViewModel.cpp
...
BookstoreViewModel::BookstoreViewModel()
{
    m_bookSku = winrt::make<Bookstore::implementation::BookSku>(L"Atticus");
    m_bookSkus = winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>();
    m_bookSkus.Append(m_bookSku);
}

Bookstore::BookSku BookstoreViewModel::BookSku()
{
    return m_bookSku;
}

Windows::Foundation::Collections::IObservableVector<Windows::Foundation::IInspectable> BookstoreViewModel::BookSkus()
{
    return m_bookSkus;
}
...
```

## <a name="bind-a-listbox-to-the-bookskus-property"></a><span data-ttu-id="03a29-125">**BookSkus** プロパティに ListBox をバインドします。</span><span class="sxs-lookup"><span data-stu-id="03a29-125">Bind a ListBox to the **BookSkus** property</span></span>
<span data-ttu-id="03a29-126">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="03a29-126">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="03a29-127">**Button** と同じ **StackPanel** 内に次のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="03a29-127">Add the following markup inside the same **StackPanel** as the **Button**.</span></span>

```xaml
<ListBox ItemsSource="{x:Bind MainViewModel.BookSkus}">
    <ItemsControl.ItemTemplate>
        <DataTemplate x:DataType="local:BookSku">
            <TextBlock Text="{x:Bind Title, Mode=OneWay}"/>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ListBox>
```

<span data-ttu-id="03a29-128">`MainPage.cpp` で、**クリック** イベント ハンドラーにコードの行を追加してブックをコレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="03a29-128">In `MainPage.cpp`, add a line of code to the **Click** event handler to append a book to the collection.</span></span>

```cppwinrt
// MainPage.cpp
...
void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
{
    MainViewModel().BookSku().Title(L"To Kill a Mockingbird");
    MainViewModel().BookSkus().Append(winrt::make<Bookstore::implementation::BookSku>(L"Moby Dick"));
}
...
```

<span data-ttu-id="03a29-129">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="03a29-129">Now build and run the project.</span></span> <span data-ttu-id="03a29-130">ボタンをクリックして**クリック** イベント ハンドラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="03a29-130">Click the button to execute the **Click** event handler.</span></span> <span data-ttu-id="03a29-131">**Append** の実装によりイベントが発生し、コレクションが変更されたことを UI が把握できるようにすることが分かります。**ListBox** はその独自の **Items** 値を更新するためにコレクションを再クエリします。</span><span class="sxs-lookup"><span data-stu-id="03a29-131">We saw that the implementation of **Append** raises an event to let the UI know that the collection has changed; and the **ListBox** re-queries the collection to update its own **Items** value.</span></span> <span data-ttu-id="03a29-132">前と同様に、ブックのいずれかのタイトルが変わります。このタイトル変更は、ボタンとリスト ボックス内の両方に反映されます。</span><span class="sxs-lookup"><span data-stu-id="03a29-132">Just as before, the title of one of the books changes; and that title change is reflected both on the button and in the list box.</span></span>

## <a name="important-apis"></a><span data-ttu-id="03a29-133">重要な API</span><span class="sxs-lookup"><span data-stu-id="03a29-133">Important APIs</span></span>
* [<span data-ttu-id="03a29-134">IObservableVector&lt;T&gt;::VectorChanged</span><span class="sxs-lookup"><span data-stu-id="03a29-134">IObservableVector&lt;T&gt;::VectorChanged</span></span>](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged)
* [<span data-ttu-id="03a29-135">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="03a29-135">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a><span data-ttu-id="03a29-136">関連トピック</span><span class="sxs-lookup"><span data-stu-id="03a29-136">Related topics</span></span>
* [<span data-ttu-id="03a29-137">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="03a29-137">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="03a29-138">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="03a29-138">Author APIs with C++/WinRT</span></span>](author-apis.md)
