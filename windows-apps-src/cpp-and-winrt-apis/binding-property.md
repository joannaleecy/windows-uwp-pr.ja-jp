---
author: stevewhims
description: XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。 このトピックでは、監視可能なプロパティを実装および使用する方法と、XAML コントロールをバインドする方法を示します。
title: XAML コントロール、C++/WinRT プロパティへのバインド
ms.author: stwhi
ms.date: 08/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, XAML, コントロール, バインド, プロパティ
ms.localizationpriority: medium
ms.openlocfilehash: bdf4d3ff17dcdf51dba2e37929228560e2e58fb5
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4155463"
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
まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 **Visual C**を作成 > **Windows ユニバーサル** > **空白のアプリ (、C++/WinRT)** プロジェクト、および*Bookstore*名前を付けます。

監視可能なタイトルのプロパティを持つブックを表すための新しいクラスを作成します。 同じコンパイル ユニット内のクラスを作成および使用しています。 ただし、XAML からこのクラスへバインドできるようにしたいため、ランタイム クラスにします。 また、この作成と使用のどちらにも C++/WinRT を使用します。

新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。 これに `BookSku.idl` という名前をつけます。 `BookSku.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。

```idl
// BookSku.idl
namespace Bookstore
{
    runtimeclass BookSku : Windows.UI.Xaml.Data.INotifyPropertyChanged
    {
        String Title;
    }
}
```

> [!NOTE]
> ビュー モデル クラスでは、&mdash;実際には、アプリケーションで宣言する任意のランタイム クラスで&mdash;基底クラスから派生する必要があります。 上で宣言した**BookSku**クラスは、その例です。 インターフェイスを実装して、任意の基本クラスから派生しないこと。
>
> アプリケーションで宣言する任意のランタイム クラス*は*そのベースから派生クラスと呼ばれる、*構成可能な*クラスです。 構成可能なクラスを中心に制約があります。 アプリケーションと Visual Studio により、Microsoft Store の提出を検証するために使用する[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)のテストに合格する (したがって、アプリケーションを Microsoft Store に正常に取り込まれるようにするため)、構成可能なクラスにする必要があります最終的には、Windows の基底クラスから派生します。 つまり継承階層の非常にルート クラスは、Windows.* 名前空間の型である必要があります。 基底クラスからランタイム クラスを派生させる必要がある場合&mdash;例では、すべてのビュー モデルから派生させる**BindableBase**クラスを実装する&mdash;し[**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject)から派生させることができます。
>
> ビュー モデルは、ビューの抽象化とビュー (XAML マークアップ) に直接バインドされているためです。 データ モデルは、データのアブストラクションとを持ち、ビュー モデルからのみ使用され、XAML に直接バインドされません。 そのため、ランタイム クラスは、としてではなく C++ 構造体またはクラスとして、データ モデルを宣言できます。 MIDL で宣言する必要のないし、自由にするなどの任意の継承階層を使用しています。

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言した **BookSku** ランタイム クラスの実装を開始するためのスタブが含まれています。 これらのスタブは `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` と `BookSku.cpp` です。

スタブ ファイル `BookSku.h` と `BookSku.cpp` を `\Bookstore\Bookstore\Generated Files\sources\` からプロジェクト フォルダー `\Bookstore\Bookstore\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-booksku"></a>**BookSku** を実装する
ここで、`\Bookstore\Bookstore\BookSku.h` と `BookSku.cpp` を開いてとランタイム クラスを実装してみましょう。 `BookSku.h` で、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を取るコンストラクター、タイトル文字列を格納するためのプライベート メンバー、およびタイトルが変更されたときに発生させるイベントのための別のプライベート メンバーを追加します。 これらの変更を行った後、`BookSku.h`のようになります。

```cppwinrt
// BookSku.h
#pragma once

#include "BookSku.g.h"

namespace winrt::Bookstore::implementation
{
    struct BookSku : BookSkuT<BookSku>
    {
        BookSku() = delete;
        BookSku(winrt::hstring const& title);

        winrt::hstring Title();
        void Title(winrt::hstring const& value);
        winrt::event_token PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& value);
        void PropertyChanged(winrt::event_token const& token);
    
    private:
        winrt::hstring m_title;
        winrt::event<Windows::UI::Xaml::Data::PropertyChangedEventHandler> m_propertyChanged;
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
    BookSku::BookSku(winrt::hstring const& title) : m_title{ title }
    {
    }

    winrt::hstring BookSku::Title()
    {
        return m_title;
    }

    void BookSku::Title(winrt::hstring const& value)
    {
        if (m_title != value)
        {
            m_title = value;
            m_propertyChanged(*this, Windows::UI::Xaml::Data::PropertyChangedEventArgs{ L"Title" });
        }
    }

    winrt::event_token BookSku::PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler)
    {
        return m_propertyChanged.add(handler);
    }

    void BookSku::PropertyChanged(winrt::event_token const& token)
    {
        m_propertyChanged.remove(token);
    }
}
```

**タイトル**ミューテーター関数であるかどうか、値が設定されて現在の値とは異なるを確認します。 その場合は、タイトルを更新も変更されたプロパティの名前に等しい引数で[**inotifypropertychanged::propertychanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)イベントを発生させます。 これにより、ユーザー インターフェイス (UI) はどのプロパティの値を再クエリするのか分かるようになります。

## <a name="declare-and-implement-bookstoreviewmodel"></a>**BookstoreViewModel** を宣言および実装する
メイン XAML ページが、メイン ビュー モデルにバインドします。 またそのビュー モデルは、**BookSku** 型のいずれかを含む、いくつかのプロパティを持つようになります。 この手順では、メイン ビュー モデル ランタイム クラスを宣言および実装します。

`BookstoreViewModel.idl` という名前の新しい **Midl ファイル (.idl)** 項目を追加します。

```idl
// BookstoreViewModel.idl
import "BookSku.idl";

namespace Bookstore
{
    runtimeclass BookstoreViewModel
    {
        BookSku BookSku{ get; };
    }
}
```

保存してビルドします。 `Generated Files` フォルダーから `BookstoreViewModel.h` と `BookstoreViewModel.cpp` をプロジェクト フォルダーにコピーし、プロジェクトに追加します。 それらのファイルを開き、次に示すように、ランタイム クラスを実装します。 注: 方法では、 `BookstoreViewModel.h`、ここに含まれている`BookSku.h`、実装型 (**winrt::Bookstore::implementation::BookSku**) を宣言しています。 削除して既定のコンス トラクターを復元しますいる`= delete`します。

```cppwinrt
// BookstoreViewModel.h
#pragma once

#include "BookstoreViewModel.g.h"
#include "BookSku.h"

namespace winrt::Bookstore::implementation
{
    struct BookstoreViewModel final : BookstoreViewModelT<BookstoreViewModel>
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
`MainPage.idl` を開きます。ここでメインの UI ページを表すランタイム クラスを宣言しています。 インポート ステートメントを追加して `BookstoreViewModel.idl` をインポートし、**BookstoreViewModel** 型の MainViewModel という名前の読み取り専用プロパティを追加します。 また、**今度**プロパティを削除します。 また、`import`ディレクティブ以下のリストにします。

```idl
// MainPage.idl
import "BookstoreViewModel.idl";

namespace Bookstore
{
    runtimeclass MainPage : Windows.UI.Xaml.Controls.Page
    {
        MainPage();
        BookstoreViewModel MainViewModel{ get; };
    }
}
```

ファイルを保存します。 現時点で完了するまで、プロジェクトのビルドはありませんが、 **MainPage**ランタイム クラスを実装するソース コード ファイルを再生するために有用なことは、構築できるようになりました (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`)。 したがってならないし、構築できるようになりました。 この段階で確認するビルド エラーが **'MainViewModel': 'winrt::Bookstore::implementation::MainPage' のメンバーでない**します。

インクルードを省略すると`BookstoreViewModel.idl`(の登録情報を表示`MainPage.idl`上)、エラーを表示し、**べき \ <"MainViewModel"の近く**します。 別のヒントが同じ名前空間のすべての種類のままにするかどうかを確認するには: コードの登録情報に表示される名前空間です。

表示を行う必要がエラーを解決するには、今すぐ必要があります生成されたファイルから**MainViewModel**プロパティのアクセサー スタブをコピーする (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`) に`\Bookstore\Bookstore\MainPage.h`と`MainPage.cpp`します。

`\Bookstore\Bookstore\MainPage.h`、含める`BookstoreViewModel.h`、実装型 (**winrt::Bookstore::implementation::BookstoreViewModel**) を宣言しています。 ビュー モデルを格納するプライベート メンバーを追加します。 プロパティ アクセサー関数 (およびメンバー m_mainViewModel) は、投影型である **Bookstore::BookstoreViewModel** に関して実装されていることに注意してください。 コンス トラクターのオーバー ロードによって m_mainViewModel を作成するため、アプリケーションとして同じプロジェクト (コンパイル ユニット) 実装型は`nullptr_t`します。 また、**今度**プロパティを削除します。

```cppwinrt
// MainPage.h
...
#include "BookstoreViewModel.h"
...
namespace winrt::Bookstore::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        MainPage();

        Bookstore::BookstoreViewModel MainViewModel();

        void ClickHandler(Windows::Foundation::IInspectable const&, Windows::UI::Xaml::RoutedEventArgs const&);

    private:
        Bookstore::BookstoreViewModel m_mainViewModel{ nullptr };
    };
}
...
```

`\Bookstore\Bookstore\MainPage.cpp`、投影された型の新しいインスタンスを m_mainViewModel に割り当てます (実装型) と[**winrt::make**](/uwp/cpp-ref-for-winrt/make)を呼び出します。 ブックのタイトルの初期値を割り当てます。 MainViewModel プロパティのアクセサーを実装します。 最後に、ボタンのイベント ハンドラーでブックのタイトルを更新します。 また、**今度**プロパティを削除します。

```cppwinrt
// MainPage.cpp
#include "pch.h"
#include "MainPage.h"

using namespace winrt;
using namespace Windows::UI::Xaml;

namespace winrt::Bookstore::implementation
{
    MainPage::MainPage()
    {
        m_mainViewModel = make<Bookstore::implementation::BookstoreViewModel>();
        InitializeComponent();
    }

    void MainPage::ClickHandler(Windows::Foundation::IInspectable const& /* sender */, Windows::UI::Xaml::RoutedEventArgs const& /* args */)
    {
        MainViewModel().BookSku().Title(L"To Kill a Mockingbird");
    }

    Bookstore::BookstoreViewModel MainPage::MainViewModel()
    {
        return m_mainViewModel;
    }
}
```

## <a name="bind-the-button-to-the-title-property"></a>**Title** プロパティにボタンをバインドする
メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 登録情報の下に示すように、ボタンから名前を削除し、その**コンテンツ**プロパティの値をリテラルからバインド式に変更します。 バインド式の `Mode=OneWay` プロパティをメモします (ビュー モデルから UI へ一方向)。 そのプロパティが無いと、UI はプロパティの変更イベントに応答しません。

```xaml
<Button Click="ClickHandler" Content="{x:Bind MainViewModel.BookSku.Title, Mode=OneWay}"/>
```

ここでプロジェクトをビルドして実行します。 ボタンをクリックして**クリック** イベント ハンドラーを実行します。 そのハンドラーがブックのタイトル ミューテーター関数を呼び出します。そのミューテーターがイベントを発生させるので、UI は **Title** プロパティが変更されたことがわかります。ボタンはそのプロパティの値を再クエリして、そのボタンの **Content** 値を更新します。

## <a name="using-the-binding-markup-extension-with-cwinrt"></a>{Binding} マークアップ拡張を使用して、C++/WinRT
現在リリースされているバージョンの C + + [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります {Binding} マークアップ拡張機能を使用できるようにするために、WinRT します。

## <a name="important-apis"></a>重要な API
* [INotifyPropertyChanged::PropertyChanged](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT での API の作成](author-apis.md)
