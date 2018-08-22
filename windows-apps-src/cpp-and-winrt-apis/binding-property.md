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
ms.openlocfilehash: 367bf5d5d554bd094ce3d5b726b818c8c388d398
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2787159"
---
# <a name="xaml-controls-bind-to-a-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-property"></a><span data-ttu-id="1cce8-105">XAML コントロール、[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) プロパティへのバインド</span><span class="sxs-lookup"><span data-stu-id="1cce8-105">XAML controls; bind to a [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) property</span></span>
<span data-ttu-id="1cce8-106">XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-106">A property that can be effectively bound to a XAML control is known as an *observable* property.</span></span> <span data-ttu-id="1cce8-107">この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。</span><span class="sxs-lookup"><span data-stu-id="1cce8-107">This idea is based on the software design pattern known as the *observer pattern*.</span></span> <span data-ttu-id="1cce8-108">このトピックでは、C++/WinRT で監視可能なプロパティを実装する方法と、これらに XAML コントロールをバインドする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-108">This topic shows how to implement observable properties in C++/WinRT, and how to bind XAML controls to them.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1cce8-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1cce8-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="what-does-observable-mean-for-a-property"></a><span data-ttu-id="1cce8-110">プロパティの*監視可能*とはどういう意味ですか?</span><span class="sxs-lookup"><span data-stu-id="1cce8-110">What does *observable* mean for a property?</span></span>
<span data-ttu-id="1cce8-111">たとえば、**BookSku** という名前のランタイム クラスに **Title** という名前のプロパティがあるとします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-111">Let's say that a runtime class named **BookSku** has a property named **Title**.</span></span> <span data-ttu-id="1cce8-112">**Title** の値が変わるたびに **BookSku** が [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) イベントを発生させることを選択する場合、**Title** は監視可能なプロパティです。</span><span class="sxs-lookup"><span data-stu-id="1cce8-112">If **BookSku** chooses to raise the [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) event whenever the value of **Title** changes, then **Title** is an observable property.</span></span> <span data-ttu-id="1cce8-113">そのプロパティ (あれば) のどれが監視可能かを決定するのは **BookSku** の動作 (イベントを発生させるまたは発生させない) です。</span><span class="sxs-lookup"><span data-stu-id="1cce8-113">It's the behavior of **BookSku** (raising or not raising the event) that determines which, if any, of its properties are observable.</span></span>

<span data-ttu-id="1cce8-114">XAML テキスト要素、またはコントロールでは、更新された値を取得して、新しい値を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-114">A XAML text element, or control, can bind to, and handle, these events by retrieving the updated value(s) and then updating itself to show the new value.</span></span>

> [!NOTE]
> <span data-ttu-id="1cce8-115">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1cce8-115">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="create-a-blank-app-bookstore"></a><span data-ttu-id="1cce8-116">空のアプリ (Bookstore) を作成する</span><span class="sxs-lookup"><span data-stu-id="1cce8-116">Create a Blank App (Bookstore)</span></span>
<span data-ttu-id="1cce8-117">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-117">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="1cce8-118">**Visual C++ 空のアプリ (C++/WinRT)** プロジェクトを作成し、*Bookstore* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-118">Create a **Visual C++ Blank App (C++/WinRT)** project, and name it *Bookstore*.</span></span>

<span data-ttu-id="1cce8-119">監視可能なタイトルのプロパティを持つブックを表すための新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-119">We're going to author a new class to represent a book that has an observable title property.</span></span> <span data-ttu-id="1cce8-120">同じコンパイル ユニット内のクラスを作成および使用しています。</span><span class="sxs-lookup"><span data-stu-id="1cce8-120">We're authoring and consuming the class within the same compilation unit.</span></span> <span data-ttu-id="1cce8-121">ただし、XAML からこのクラスへバインドできるようにしたいため、ランタイム クラスにします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-121">But we want to be able to bind to this class from XAML, and for that reason it's going to be a runtime class.</span></span> <span data-ttu-id="1cce8-122">また、この作成と使用のどちらにも C++/WinRT を使用します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-122">And we're going to use C++/WinRT to both author and consume it.</span></span>

<span data-ttu-id="1cce8-123">新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-123">The first step in authoring a new runtime class is to add a new **Midl File (.idl)** item to the project.</span></span> <span data-ttu-id="1cce8-124">これに `BookSku.idl` という名前をつけます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-124">Name it `BookSku.idl`.</span></span> <span data-ttu-id="1cce8-125">`BookSku.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-125">Delete the default contents of `BookSku.idl`, and paste in this runtime class declaration.</span></span>

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
> <span data-ttu-id="1cce8-126">アプリケーションが[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を通過するための送信を検証するため、テストが、Microsoft ストアで使用され、そのために、Microsoft ストアに正常に取り込み、各ランタイム クラス*の最終的な基本クラスで宣言されている、アプリケーション*Windows.\* 名前空間の元の型である必要があります。</span><span class="sxs-lookup"><span data-stu-id="1cce8-126">For an application to pass the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) tests used by the Microsoft Store to validate submissions, and therefore to be successfully ingested into the Microsoft Store, the ultimate base class of each runtime class *declared in the application* must be a type originating in a Windows.\* namespace.</span></span>

<span data-ttu-id="1cce8-127">その要件を満たすには、[**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject) からビュー モデル クラスを派生します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-127">To fulfil that requirement, derive your view model classes from [**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject).</span></span> <span data-ttu-id="1cce8-128">または、**DependencyObject** から派生したバインド可能な基底クラスを宣言し、それからビュー モデルを派生します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-128">Alternatively, declare a bindable base class derived from **DependencyObject**, and derive your view models from that.</span></span> <span data-ttu-id="1cce8-129">データ モデルは、C++ 構造体として宣言することができます。(それらをビュー モデルからのみ使用し、それらに XAML を直接バインドしていない限り (この場合、いずれにせよ定義上それらは間違いなくビュー モデルになります)) MIDL で宣言する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1cce8-129">You can declare your data models as C++ structs; they don't need to be declared in MIDL (as long as you're consuming them only from your view models and not binding XAML directly to them; in which case they'd arguably be view models by definition, anyway).</span></span>

<span data-ttu-id="1cce8-130">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-130">Save the file and build the project.</span></span> <span data-ttu-id="1cce8-131">ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-131">During the build process, the `midl.exe` tool is run to create a Windows Runtime metadata file (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) describing the runtime class.</span></span> <span data-ttu-id="1cce8-132">次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-132">Then, the `cppwinrt.exe` tool is run to generate source code files to support you in authoring and consuming your runtime class.</span></span> <span data-ttu-id="1cce8-133">これらのファイルには、IDL で宣言した **BookSku** ランタイム クラスの実装を開始するためのスタブが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1cce8-133">These files include stubs to get you started implementing the **BookSku** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="1cce8-134">これらのスタブは `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` と `BookSku.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="1cce8-134">Those stubs are `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` and `BookSku.cpp`.</span></span>

<span data-ttu-id="1cce8-135">スタブ ファイル `BookSku.h` と `BookSku.cpp` を `\Bookstore\Bookstore\Generated Files\sources\` からプロジェクト フォルダー `\Bookstore\Bookstore\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-135">Copy the stub files `BookSku.h` and `BookSku.cpp` from `\Bookstore\Bookstore\Generated Files\sources\` into the project folder, which is `\Bookstore\Bookstore\`.</span></span> <span data-ttu-id="1cce8-136">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-136">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="1cce8-137">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-137">Right-click the stub files that you copied, and click **Include In Project**.</span></span>

## <a name="implement-booksku"></a><span data-ttu-id="1cce8-138">**BookSku** を実装する</span><span class="sxs-lookup"><span data-stu-id="1cce8-138">Implement **BookSku**</span></span>
<span data-ttu-id="1cce8-139">ここで、`\Bookstore\Bookstore\BookSku.h` と `BookSku.cpp` を開いてとランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="1cce8-139">Now, let's open `\Bookstore\Bookstore\BookSku.h` and `BookSku.cpp` and implement our runtime class.</span></span> <span data-ttu-id="1cce8-140">`BookSku.h` で、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を取るコンストラクター、タイトル文字列を格納するためのプライベート メンバー、およびタイトルが変更されたときに発生させるイベントのための別のプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-140">In `BookSku.h`, add a constructor that takes a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring), a private member to store the title string, and another for the event that we'll raise when the title changes.</span></span> <span data-ttu-id="1cce8-141">これらを追加すると、`BookSku.h` は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1cce8-141">After adding those, your `BookSku.h` will look like this.</span></span>

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

        hstring Title();
        void Title(winrt::hstring const& value);
        event_token PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& value);
        void PropertyChanged(winrt::event_token const& token);
    
    private:
        hstring m_title;
        event<Windows::UI::Xaml::Data::PropertyChangedEventHandler> m_propertyChanged;
    };
}
```

<span data-ttu-id="1cce8-142">`BookSku.cpp` では、次のように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-142">In `BookSku.cpp`, implement the functions like this.</span></span>

```cppwinrt
// BookSku.cpp
#include "pch.h"
#include "BookSku.h"

namespace winrt::Bookstore::implementation
{
    hstring BookSku::Title()
    {
        return m_title;
    }

    BookSku::BookSku(winrt::hstring const& title)
    {
        Title(title);
    }

    void BookSku::Title(winrt::hstring const& value)
    {
        if (m_title != value)
        {
            m_title = value;
            m_propertyChanged(*this, Windows::UI::Xaml::Data::PropertyChangedEventArgs{ L"Title" });
        }
    }

    event_token BookSku::PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler)
    {
        return m_propertyChanged.add(handler);
    }

    void BookSku::PropertyChanged(winrt::event_token const& token)
    {
        m_propertyChanged.remove(token);
    }
}
```

<span data-ttu-id="1cce8-143">**Title** ミューテーター関数では、別の値が設定されているかどうかをチェックし、されている場合は、タイトルを更新して、変更されたプロパティの名前に等しい引数で [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) イベントも発生させます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-143">In the **Title** mutator function, we check whether a different value is being set and, if so, we update the title and also raise the [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) event with an argument equal to the name of the property that has changed.</span></span> <span data-ttu-id="1cce8-144">これにより、ユーザー インターフェイス (UI) はどのプロパティの値を再クエリするのか分かるようになります。</span><span class="sxs-lookup"><span data-stu-id="1cce8-144">This is so that the user-interface (UI) will know which property's value to re-query.</span></span>

## <a name="declare-and-implement-bookstoreviewmodel"></a><span data-ttu-id="1cce8-145">**BookstoreViewModel** を宣言および実装する</span><span class="sxs-lookup"><span data-stu-id="1cce8-145">Declare and implement **BookstoreViewModel**</span></span>
<span data-ttu-id="1cce8-146">メイン XAML ページが、メイン ビュー モデルにバインドします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-146">Our main XAML page is going to bind to a main view model.</span></span> <span data-ttu-id="1cce8-147">またそのビュー モデルは、**BookSku** 型のいずれかを含む、いくつかのプロパティを持つようになります。</span><span class="sxs-lookup"><span data-stu-id="1cce8-147">And that view model is going to have several properties, including one of type **BookSku**.</span></span> <span data-ttu-id="1cce8-148">この手順では、メイン ビュー モデル ランタイム クラスを宣言および実装します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-148">In this step, we'll declare and implement our main view model runtime class.</span></span>

<span data-ttu-id="1cce8-149">`BookstoreViewModel.idl` という名前の新しい **Midl ファイル (.idl)** 項目を追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-149">Add a new **Midl File (.idl)** item named `BookstoreViewModel.idl`.</span></span>

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

<span data-ttu-id="1cce8-150">保存してビルドします。</span><span class="sxs-lookup"><span data-stu-id="1cce8-150">Save and build.</span></span> <span data-ttu-id="1cce8-151">`Generated Files` フォルダーから `BookstoreViewModel.h` と `BookstoreViewModel.cpp` をプロジェクト フォルダーにコピーし、プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-151">Copy `BookstoreViewModel.h` and `BookstoreViewModel.cpp` from the `Generated Files` folder into the project folder, and include them in the project.</span></span> <span data-ttu-id="1cce8-152">これらのファイルを開き、次のようにランタイム クラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-152">Open those files and implement the runtime class like this.</span></span>

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
> <span data-ttu-id="1cce8-153">`m_bookSku` の型は投影型 (**winrt::Bookstore::BookSku**) であり、**make** で使用するテンプレート パラメーターは実装型 (**winrt::Bookstore::implementation::BookSku**) です。</span><span class="sxs-lookup"><span data-stu-id="1cce8-153">The type of `m_bookSku` is the projected type (**winrt::Bookstore::BookSku**), and the template parameter that you use with **make** is the implementation type (**winrt::Bookstore::implementation::BookSku**).</span></span> <span data-ttu-id="1cce8-154">この場合も、[**make**] は投影型のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-154">Even so, **make** returns an instance of the projected type.</span></span>

## <a name="add-a-property-of-type-bookstoreviewmodel-to-mainpage"></a><span data-ttu-id="1cce8-155">**BookstoreViewModel** 型のプロパティを **MainPage** に追加する</span><span class="sxs-lookup"><span data-stu-id="1cce8-155">Add a property of type **BookstoreViewModel** to **MainPage**</span></span>
<span data-ttu-id="1cce8-156">`MainPage.idl` を開きます。ここでメインの UI ページを表すランタイム クラスを宣言しています。</span><span class="sxs-lookup"><span data-stu-id="1cce8-156">Open `MainPage.idl`, which declares the runtime class that represents our main UI page.</span></span> <span data-ttu-id="1cce8-157">インポート ステートメントを追加して `BookstoreViewModel.idl` をインポートし、**BookstoreViewModel** 型の MainViewModel という名前の読み取り専用プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-157">Add an import statement to import `BookstoreViewModel.idl`, and add a read-only property named MainViewModel of type **BookstoreViewModel**.</span></span> <span data-ttu-id="1cce8-158">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-158">Also remove the **MyProperty** property.</span></span> <span data-ttu-id="1cce8-159">また、下の一覧**をインポートする**ディレクティブを確認します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-159">Also note the **import** directive in the listing below.</span></span>

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

<span data-ttu-id="1cce8-160">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-160">Save the file.</span></span> <span data-ttu-id="1cce8-161">現時点で完了するプロジェクトを作成できませんが、今すぐ建てる**MainPage**ランタイム クラスを実装するソース コード ファイルを再生成するための便利なこと (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`)。</span><span class="sxs-lookup"><span data-stu-id="1cce8-161">The project won't build to completion at the moment, but building now is a useful thing to do because it regenerates the source code files in which the **MainPage** runtime class is implemented (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h` and `MainPage.cpp`).</span></span> <span data-ttu-id="1cce8-162">ようにさあ、作成するようになりました。</span><span class="sxs-lookup"><span data-stu-id="1cce8-162">So go ahead and build now.</span></span> <span data-ttu-id="1cce8-163">この段階で表示するビルド エラー **'MainViewModel': 'winrt::Bookstore::implementation::MainPage' のメンバーではない**します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-163">The build error you can expect to see at this stage is **'MainViewModel': is not a member of 'winrt::Bookstore::implementation::MainPage'**.</span></span>

<span data-ttu-id="1cce8-164">含めるを省略すると`BookstoreViewModel.idl`(の一覧を参照してください`MainPage.idl`上にある)、エラーが表示される [**予期 \ < 付近に"MainViewModel"** します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-164">If you omit the include of `BookstoreViewModel.idl` (see the listing of `MainPage.idl` above), then you'll see the error **expecting \< near "MainViewModel"**.</span></span> <span data-ttu-id="1cce8-165">同じ名前空間のすべての種類のままにすることを確認するのには、別のヒント: [コードの一覧に表示される名前空間します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-165">Another tip is to make sure that you leave all types in the same namespace: the namespace that's shown in the code listings.</span></span>

<span data-ttu-id="1cce8-166">あることにエラーを解決するには、今すぐする必要がありますアクセサー スタブ**MainViewModel**プロパティから生成されたファイルのコピー`\Bookstore\Bookstore\MainPage.h`と`MainPage.cpp`します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-166">To resolve the error that we expect to see, you'll now need to copy the accessor stubs for the **MainViewModel** property out of the generated files and into `\Bookstore\Bookstore\MainPage.h` and `MainPage.cpp`.</span></span>

<span data-ttu-id="1cce8-167">`\Bookstore\Bookstore\MainPage.h` にビュー モデルを格納するプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-167">To `\Bookstore\Bookstore\MainPage.h`, add a private member to store the view model.</span></span> <span data-ttu-id="1cce8-168">プロパティ アクセサー関数 (およびメンバー m_mainViewModel) は、投影型である **Bookstore::BookstoreViewModel** に関して実装されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1cce8-168">Note that the property accessor function (and the member m_mainViewModel) is implemented in terms of **Bookstore::BookstoreViewModel**, which is the projected type.</span></span> <span data-ttu-id="1cce8-169">実装型は同じプロジェクト (コンパイル ユニット) にあるため、`nullptr_t` を使うコンストラクターのオーバーロードによって m_mainViewModel を作成します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-169">The implementation type is in the same project (compilation unit), so we construct m_mainViewModel via the constructor overload that takes `nullptr_t`.</span></span> <span data-ttu-id="1cce8-170">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-170">Also remove the **MyProperty** property.</span></span>

```cppwinrt
// MainPage.h
...
namespace winrt::Bookstore::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        MainPage();

        Bookstore::BookstoreViewModel MainViewModel();

        void ClickHandler(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);

    private:
        Bookstore::BookstoreViewModel m_mainViewModel{ nullptr };
    };
}
...
```

<span data-ttu-id="1cce8-171">`\Bookstore\Bookstore\MainPage.cpp` に、実装型を宣言している `BookstoreViewModel.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-171">In `\Bookstore\Bookstore\MainPage.cpp`, include `BookstoreViewModel.h`, which declares the implementation type.</span></span> <span data-ttu-id="1cce8-172">[**winrt::make**](/uwp/cpp-ref-for-winrt/make) を (実装型で) 呼び出し、投影型の新しいインスタンスを m_mainViewModel に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-172">Call [**winrt::make**](/uwp/cpp-ref-for-winrt/make) (with the implementation type) to assign a new instance of the projected type to m_mainViewModel.</span></span> <span data-ttu-id="1cce8-173">ブックのタイトルの初期値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-173">Assign an initial value for the book's title.</span></span> <span data-ttu-id="1cce8-174">MainViewModel プロパティのアクセサーを実装します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-174">Implement the accessor for the MainViewModel property.</span></span> <span data-ttu-id="1cce8-175">最後に、ボタンのイベント ハンドラーでブックのタイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-175">And finally, update the book's title in the button's event handler.</span></span> <span data-ttu-id="1cce8-176">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-176">Also remove the **MyProperty** property.</span></span>

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

    void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
    {
        MainViewModel().BookSku().Title(L"To Kill a Mockingbird");
    }

    Bookstore::BookstoreViewModel MainPage::MainViewModel()
    {
        return m_mainViewModel;
    }
}
```

## <a name="bind-the-button-to-the-title-property"></a><span data-ttu-id="1cce8-177">**Title** プロパティにボタンをバインドする</span><span class="sxs-lookup"><span data-stu-id="1cce8-177">Bind the button to the **Title** property</span></span>
<span data-ttu-id="1cce8-178">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="1cce8-178">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="1cce8-179">ボタンから名前を削除し、その **Content** プロパティ値を文字式からバインド式に変更します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-179">Remove the name from the button, and change its **Content** property value from a literal to a binding expression.</span></span> <span data-ttu-id="1cce8-180">バインド式の `Mode=OneWay` プロパティをメモします (ビュー モデルから UI へ一方向)。</span><span class="sxs-lookup"><span data-stu-id="1cce8-180">Note the `Mode=OneWay` property on the binding expression (one-way from the view model to the UI).</span></span> <span data-ttu-id="1cce8-181">そのプロパティが無いと、UI はプロパティの変更イベントに応答しません。</span><span class="sxs-lookup"><span data-stu-id="1cce8-181">Without that property, the UI will not respond to property changed events.</span></span>

```xaml
<Button Click="ClickHandler" Content="{x:Bind MainViewModel.BookSku.Title, Mode=OneWay}"/>
```

<span data-ttu-id="1cce8-182">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-182">Now build and run the project.</span></span> <span data-ttu-id="1cce8-183">ボタンをクリックして**クリック** イベント ハンドラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-183">Click the button to execute the **Click** event handler.</span></span> <span data-ttu-id="1cce8-184">そのハンドラーがブックのタイトル ミューテーター関数を呼び出します。そのミューテーターがイベントを発生させるので、UI は **Title** プロパティが変更されたことがわかります。ボタンはそのプロパティの値を再クエリして、そのボタンの **Content** 値を更新します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-184">That handler calls the book's title mutator function; that mutator raises an event to let the UI know that the **Title** property has changed; and the button re-queries that property's value to update its own **Content** value.</span></span>

## <a name="using-the-binding-markup-extension-with-cwinrt"></a><span data-ttu-id="1cce8-185">{バインド} マークアップ拡張子を使用して、C + +/WinRT</span><span class="sxs-lookup"><span data-stu-id="1cce8-185">Using the {Binding} markup extension with C++/WinRT</span></span>
<span data-ttu-id="1cce8-186">C + の現在のリリース版の +/ [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります {バインド} 変更履歴とコメントの拡張機能を使用できるようにするために、WinRT します。</span><span class="sxs-lookup"><span data-stu-id="1cce8-186">For the currently released version of C++/WinRT, in order to be able to use the {Binding} markup extension you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces.</span></span>

## <a name="important-apis"></a><span data-ttu-id="1cce8-187">重要な API</span><span class="sxs-lookup"><span data-stu-id="1cce8-187">Important APIs</span></span>
* [<span data-ttu-id="1cce8-188">INotifyPropertyChanged::PropertyChanged</span><span class="sxs-lookup"><span data-stu-id="1cce8-188">INotifyPropertyChanged::PropertyChanged</span></span>](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)
* [<span data-ttu-id="1cce8-189">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="1cce8-189">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a><span data-ttu-id="1cce8-190">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1cce8-190">Related topics</span></span>
* [<span data-ttu-id="1cce8-191">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="1cce8-191">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="1cce8-192">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="1cce8-192">Author APIs with C++/WinRT</span></span>](author-apis.md)
