---
author: stevewhims
description: XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。 このトピックでは、監視可能なプロパティを実装および使用する方法と、XAML コントロールをバインドする方法を示します。
title: XAML コントロール、C++/WinRT プロパティへのバインド
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, XAML, コントロール, バインド, プロパティ
ms.localizationpriority: medium
ms.openlocfilehash: 25ea4c4caf5135b13b88eeea6f43bb36bd691c11
ms.sourcegitcommit: 3500825bc2e5698394a8b1d2efece7f071f296c1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/09/2018
ms.locfileid: "1863218"
---
# <a name="xaml-controls-bind-to-a-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-property"></a>XAML コントロール、[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) プロパティへのバインド
XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。 この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。 このトピックでは、C++/WinRT で監視可能なプロパティを実装する方法と、これらに XAML コントロールをバインドする方法を示します。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="what-does-observable-mean-for-a-property"></a>プロパティの*監視可能*とはどういう意味ですか?
たとえば、**BookSku** という名前のランタイム クラスに **Title** という名前のプロパティがあるとします。 **Title** の値が変わるたびに **BookSku** が [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) イベントを発生させることを選択する場合、**Title** は監視可能なプロパティです。 そのプロパティ (あれば) のどれが監視可能かを決定するのは **BookSku** の動作 (イベントを発生させるまたは発生させない) です。

XAML テキスト要素、またはコントロールでは、更新された値を取得して、新しい値を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

## <a name="create-a-blank-app-bookstore"></a>空のアプリ (Bookstore) を作成する
まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 **Visual C++ 空のアプリ (C++/WinRT)** プロジェクトを作成し、*Bookstore* と名前を付けます。

監視可能なタイトルのプロパティを持つブックを表すための新しいクラスを作成します。 同じコンパイル ユニット内のクラスを作成および使用しています。 ただし、XAML からこのクラスへバインドできるようにしたいため、ランタイム クラスにします。 また、この作成と使用のどちらにも C++/WinRT を使用します。

新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。 これに `BookSku.idl` という名前をつけます。 `BookSku.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。

```idl
// BookSku.idl
namespace Bookstore
{
    runtimeclass BookSku : Windows.UI.Xaml.DependencyObject, Windows.UI.Xaml.Data.INotifyPropertyChanged
    {
        String Title;
    }
}
```

> [!IMPORTANT]
> アプリケーションで、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md) テストを渡して、Microsoft Store に正常に取り込まれるようにするために、*アプリケーションで宣言されている*各ランタイム クラスの最終的な基底クラスは、Windows.* 名前空間に由来する型である必要があります。

その要件を満たすには、[**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject) からビュー モデル クラスを派生します。 または、**DependencyObject** から派生したバインド可能な基底クラスを宣言し、それからビュー モデルを派生します。 データ モデルは、C++ 構造体として宣言することができます。(それらをビュー モデルからのみ使用し、それらに XAML を直接バインドしていない限り (この場合、いずれにせよ定義上それらは間違いなくビュー モデルになります)) MIDL で宣言する必要はありません。

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言した **BookSku** ランタイム クラスの実装を開始するためのスタブが含まれています。 これらのスタブは `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` と `BookSku.cpp` です。

スタブ ファイル `BookSku.h` と `BookSku.cpp` を `\Bookstore\Bookstore\Generated Files\sources\` からプロジェクト フォルダー `\Bookstore\Bookstore\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-booksku"></a>**BookSku** を実装する
ここで、`\Bookstore\Bookstore\BookSku.h` と `BookSku.cpp` を開いてとランタイム クラスを実装してみましょう。 `BookSku.h` で、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を取るコンストラクター、タイトル文字列を格納するためのプライベート メンバー、およびタイトルが変更されたときに発生させるイベントのための別のプライベート メンバーを追加します。 これらを追加すると、`BookSku.h` は次のようになります。

```cppwinrt
// BookSku.h
#pragma once

#include "BookSku.g.h"

namespace winrt::Bookstore::implementation
{
    struct BookSku : BookSkuT<BookSku>
    {
        BookSku() = delete;
        BookSku(hstring const& title);

        hstring Title();
        void Title(hstring const& value);
        event_token PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& value);
        void PropertyChanged(event_token const& token);
    
    private:
        hstring title;
        event<Windows::UI::Xaml::Data::PropertyChangedEventHandler> propertyChanged;
    };
}
```

`BookSku.cpp` では、次のように関数を実装します。

```cppwinrt
// BookSku.cpp
#include "pch.h"
#include "BookSku.h"

namespace winrt::Bookstore::implementation
{
    BookSku::BookSku(hstring const& title)
    {
        Title(title);
    }

    hstring BookSku::Title()
    {
        return title;
    }

    void BookSku::Title(hstring const& value)
    {
        if (title != value)
        {
            title = value;
            propertyChanged(*this, Windows::UI::Xaml::Data::PropertyChangedEventArgs{ L"Title" });
        }
    }

    event_token BookSku::PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler)
    {
        return propertyChanged.add(handler);
    }

    void BookSku::PropertyChanged(event_token const& token)
    {
        propertyChanged.remove(token);
    }
}
```

**Title** ミューテーター関数では、別の値が設定されているかどうかをチェックし、されている場合は、タイトルを更新して、変更されたプロパティの名前に等しい引数で [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) イベントも発生させます。 これにより、ユーザー インターフェイス (UI) はどのプロパティの値を再クエリするのか分かるようになります。

## <a name="declare-and-implement-bookstoreviewmodel"></a>**BookstoreViewModel** を宣言および実装する
メイン XAML ページが、メイン ビュー モデルにバインドします。 またそのビュー モデルは、**BookSku** 型のいずれかを含む、いくつかのプロパティを持つようになります。 この手順では、メイン ビュー モデル ランタイム クラスを宣言および実装します。

`BookstoreViewModel.idl` という名前の新しい **Midl ファイル (.idl)** 項目を追加します。

```idl
// BookstoreViewModel.idl
import "BookSku.idl";

namespace Bookstore
{
    runtimeclass BookstoreViewModel : Windows.UI.Xaml.DependencyObject
    {
        BookSku BookSku{ get; };
    }
}
```

保存してビルドします。 `Generated Files` フォルダーから `BookstoreViewModel.h` と `BookstoreViewModel.cpp` をプロジェクト フォルダーにコピーし、プロジェクトに追加します。 これらのファイルを開き、次のようにランタイム クラスを実装します。

```cppwinrt
// BookstoreViewModel.h
#pragma once

#include "BookstoreViewModel.g.h"
#include "BookSku.h"

namespace winrt::Bookstore::implementation
{
    struct BookstoreViewModel : BookstoreViewModelT<BookstoreViewModel>
    {
        BookstoreViewModel();
        Bookstore::BookSku BookSku();

    private:
        Bookstore::BookSku m_bookSku{ nullptr };
    };
}
```

```cppwinrt
// BookstoreViewModel.cpp
#include "pch.h"
#include "BookstoreViewModel.h"

namespace winrt::Bookstore::implementation
{
    BookstoreViewModel::BookstoreViewModel()
    {
        m_bookSku = make<Bookstore::implementation::BookSku>(L"Atticus");
    }

    Bookstore::BookSku BookstoreViewModel::BookSku()
    {
        return m_bookSku;
    }
}
```

> [!NOTE]
> `m_bookSku` の型は投影型 (**winrt::Bookstore::BookSku**) であり、**make** で使用するテンプレート パラメーターは実装型 (**winrt::Bookstore::implementation::BookSku**) です。 この場合も、[**make**] は投影型のインスタンスを返します。

## <a name="add-a-property-of-type-bookstoreviewmodel-to-mainpage"></a>**BookstoreViewModel** 型のプロパティを **MainPage** に追加する
`MainPage.idl` を開きます。ここでメインの UI ページを表すランタイム クラスを宣言しています。 インポート ステートメントを追加して `BookstoreViewModel.idl` をインポートし、**BookstoreViewModel** 型の MainViewModel という名前の読み取り専用プロパティを追加します。

```idl
// MainPage.idl
import "BookstoreViewModel.idl";

namespace BookstoreCPPWinRT
{
    runtimeclass MainPage : Windows.UI.Xaml.Controls.Page
    {
        MainPage();
        BookstoreViewModel MainViewModel{ get; };
    }
}
```

プロジェクトを再ビルドして **MainPage** ランタイム クラスが実装されているソース コード ファイル (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`) を再生成します。 生成されたファイルから ViewModel プロパティのアクセサー スタブを `\Bookstore\Bookstore\MainPage.h` と `MainPage.cpp` へコピーします。

`\Bookstore\Bookstore\MainPage.h` にビュー モデルを格納するプライベート メンバーを追加します。 プロパティ アクセサー関数 (およびメンバー m_mainViewModel) は、投影型である **Bookstore::BookstoreViewModel** に関して実装されていることに注意してください。 実装型は同じプロジェクト (コンパイル ユニット) にあるため、`nullptr_t` を使うコンストラクターのオーバーロードによって m_mainViewModel を作成します。

```cppwinrt
// MainPage.h
...
namespace winrt::Bookstore::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        MainPage();

        Bookstore::BookstoreViewModel MainViewModel();

    private:
        void ClickHandler(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);

        Bookstore::BookstoreViewModel m_mainViewModel{ nullptr };

        friend class MainPageT<MainPage>;
    };
}
...
```

`\Bookstore\Bookstore\MainPage.cpp` に、実装型を宣言している `BookstoreViewModel.h` を含めます。 [**winrt::make**](/uwp/cpp-ref-for-winrt/make) を (実装型で) 呼び出し、投影型の新しいインスタンスを m_mainViewModel に割り当てます。 ブックのタイトルの初期値を割り当てます。 MainViewModel プロパティのアクセサーを実装します。 最後に、ボタンのイベント ハンドラーでブックのタイトルを更新します。

```cppwinrt
// MainPage.cpp
#include "pch.h"
#include "MainPage.h"
#include "BookstoreViewModel.h"

using namespace winrt;
using namespace Windows::UI::Xaml;

namespace winrt::Bookstore::implementation
{
    MainPage::MainPage()
    {
        m_mainViewModel = make<Bookstore::implementation::BookstoreViewModel>();
        InitializeComponent();
    }

    Bookstore::BookstoreViewModel MainPage::MainViewModel()
    {
        return m_mainViewModel;
    }

    void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
    {
        MainViewModel().BookSku().Title(L"To Kill a Mockingbird");
    }
}
```

## <a name="bind-the-button-to-the-title-property"></a>**Title** プロパティにボタンをバインドする
メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 ボタンから名前を削除し、その **Content** プロパティ値を文字式からバインド式に変更します。 バインド式の `Mode=OneWay` プロパティをメモします (ビュー モデルから UI へ一方向)。 そのプロパティが無いと、UI はプロパティの変更イベントに応答しません。

```xaml
<Button Click="ClickHandler" Content="{x:Bind MainViewModel.BookSku.Title, Mode=OneWay}"/>
```

ここでプロジェクトをビルドして実行します。 ボタンをクリックして**クリック** イベント ハンドラーを実行します。 そのハンドラーがブックのタイトル ミューテーター関数を呼び出します。そのミューテーターがイベントを発生させるので、UI は **Title** プロパティが変更されたことがわかります。ボタンはそのプロパティの値を再クエリして、そのボタンの **Content** 値を更新します。

## <a name="important-apis"></a>重要な API
* [INotifyPropertyChanged::PropertyChanged](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT での API の作成](author-apis.md)
