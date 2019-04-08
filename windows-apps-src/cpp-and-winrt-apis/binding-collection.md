---
description: XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 このトピックでは、監視可能なコレクションを実装および使用する方法と、それに XAML アイテム コントロールをバインドする方法を示します。
title: 'XAML アイテム コントロール: C++/WinRT コレクションへのバインド'
ms.date: 10/03/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML、コントロール、バインド、コレクション
ms.localizationpriority: medium
ms.openlocfilehash: c3551ebcc59ebfe426b0be8d5bd20f7578517a25
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649207"
---
# <a name="xaml-items-controls-bind-to-a-cwinrt-collection"></a>XAML アイテム コントロール: C++/WinRT コレクションへのバインド

XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。 このトピックでは、監視可能なコレクションを実装する方法を示します[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、および XAML をバインドする方法にコントロールの項目。

このチュートリアルでは、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」で作成したプロジェクトをビルドし、そのトピックで説明する概念に追加します。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="what-does-observable-mean-for-a-collection"></a>コレクションの*監視可能*とはどういう意味ですか?
コレクションを表すランタイム クラスが、要素が追加されるまたは削除されるたびに [**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生することを選択する場合、そのランタイム クラスは監視可能なコレクションです。 XAML アイテム コントロールでは、更新されたコレクションを取得して、現在の要素を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。

> [!NOTE]
> 詳細については、インストールと使用すると、C +/cli WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレートのサポートを提供します) を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

## <a name="add-a-bookskus-collection-to-bookstoreviewmodel"></a>**BookSkus** コレクションを **BookstoreViewModel** に追加する

「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」では、**BookSku** 型のプロパティをメイン ビュー モデルに追加しました。 この手順で使用して、 [ **winrt::single_threaded_observable_vector** ](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)の observablecollection を実装するためにファクトリ関数テンプレート**BookSku**で、同じビューのモデル。

> [!NOTE]
> Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョンは 1809) をインストールしていない後で、表示するか[以前のバージョンの Windows SDK があるかどうかは](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk)の代わりに使用できる監視可能なベクターテンプレートの一覧については**winrt::single_threaded_observable_vector**します。

`BookstoreViewModel.idl` で新しいプロパティを宣言します。

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
> 上の MIDL 3.0 一覧での種類、 **BookSkus**プロパティは[ **IObservableVector** ](/uwp/api/windows.foundation.collections.ivector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable). 項目のソース、バインドがこのトピックの次のセクションで、 [ **ListBox** ](/uwp/api/windows.ui.xaml.controls.listbox)に**BookSkus**します。 リスト ボックスは、アイテム コントロールを正しく設定して、 [ **ItemsControl.ItemsSource** ](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティ、型の値に設定する必要があります**IObservableVector** (または**IVector**) の**IInspectable**、やなどの相互運用型の[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)します。

保存してビルドします。 `Generated Files` フォルダーの `BookstoreViewModel.h` と `BookstoreViewModel.cpp` からアクセサー スタブをコピーし、それらを実装します。

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
    MainViewModel().BookSkus().Append(winrt::make<Bookstore::implementation::BookSku>(L"Moby Dick"));
}
...
```

ここでプロジェクトをビルドして実行します。 ボタンをクリックして**クリック** イベント ハンドラーを実行します。 **Append** の実装によりイベントが発生し、コレクションが変更されたことを UI が把握できるようにすることが分かります。**ListBox** はその独自の **Items** 値を更新するためにコレクションを再クエリします。 前と同様に、ブックのいずれかのタイトルが変わります。このタイトル変更は、ボタンとリスト ボックス内の両方に反映されます。

## <a name="important-apis"></a>重要な API
* [IObservableVector&lt;T&gt;:: VectorChanged](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT で API を使用する](consume-apis.md)
* [C++/WinRT で API を作成する](author-apis.md)
