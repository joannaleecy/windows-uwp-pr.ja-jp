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
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6029344"
---
# <a name="xaml-items-controls-bind-to-a-cwinrt-collection"></a>XAML アイテム コントロール: C++/WinRT コレクションへのバインド

XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。 このトピックで監視可能なコレクションを実装する方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、XAML にバインドする方法をコントロールの項目とします。

このチュートリアルでは、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」で作成したプロジェクトをビルドし、そのトピックで説明する概念に追加します。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="what-does-observable-mean-for-a-collection"></a>コレクションの*監視可能*とはどういう意味ですか?
コレクションを表すランタイム クラスが、要素が追加されるまたは削除されるたびに [**IObservableVector&lt;T&gt;:: VectorChanged**](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged) イベントを発生することを選択する場合、そのランタイム クラスは監視可能なコレクションです。 XAML アイテム コントロールでは、更新されたコレクションを取得して、現在の要素を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

## <a name="add-a-bookskus-collection-to-bookstoreviewmodel"></a>**BookSkus** コレクションを **BookstoreViewModel** に追加する

「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」では、**BookSku** 型のプロパティをメイン ビュー モデルに追加しました。 この手順で使います[**winrt::single_threaded_observable_vector**](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector)ファクトリ関数テンプレートを同じビュー モデルの**BookSku**の監視可能なコレクションを実装できるようにします。

> [!NOTE]
> Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールしていないかが後で、し、表示場合[Windows SDK の以前のバージョンがある場合](/uwp/cpp-ref-for-winrt/single-threaded-observable-vector#if-you-have-an-older-version-of-the-windows-sdk) **winrt::single_ の代わりに使用できる、監視可能なベクター テンプレートの一覧についてはthreaded_observable_vector**します。

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
> 上記の MIDL 3.0 一覧で [ **BookSkus**プロパティの型が[**IObservableVector**](/uwp/api/windows.foundation.collections.ivector_t_) [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)の注意してください。 このトピックの次のセクションでは**BookSkus**に[**リスト ボックス**](/uwp/api/windows.ui.xaml.controls.listbox)の項目ソースしますバインドするされます。 リスト ボックスは、項目コントロールと正しく[**ItemsControl.ItemsSource**](/uwp/api/windows.ui.xaml.controls.itemscontrol.itemssource)プロパティを設定する必要があります**IObservableVector**型の値に (または**IVector**) を設定する**IInspectable**、または[**など、相互運用性の種類のIBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)します。

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
* [IObservableVector&lt;T&gt;::VectorChanged](/uwp/api/windows.foundation.collections.iobservablevector-1.vectorchanged)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT での API の作成](author-apis.md)
