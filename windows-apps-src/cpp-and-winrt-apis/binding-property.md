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
ms.openlocfilehash: 31913ae162bfe541d04f304db87b4dff962a8af4
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3227859"
---
# <a name="xaml-controls-bind-to-a-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-property"></a><span data-ttu-id="d720a-105">XAML コントロール、[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) プロパティへのバインド</span><span class="sxs-lookup"><span data-stu-id="d720a-105">XAML controls; bind to a [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) property</span></span>
<span data-ttu-id="d720a-106">XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d720a-106">A property that can be effectively bound to a XAML control is known as an *observable* property.</span></span> <span data-ttu-id="d720a-107">この概念は、*オブザーバー パターン*と呼ばれるソフトウェアの設計パターンに基づいています。</span><span class="sxs-lookup"><span data-stu-id="d720a-107">This idea is based on the software design pattern known as the *observer pattern*.</span></span> <span data-ttu-id="d720a-108">このトピックでは、C++/WinRT で監視可能なプロパティを実装する方法と、これらに XAML コントロールをバインドする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d720a-108">This topic shows how to implement observable properties in C++/WinRT, and how to bind XAML controls to them.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d720a-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d720a-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="what-does-observable-mean-for-a-property"></a><span data-ttu-id="d720a-110">プロパティの*監視可能*とはどういう意味ですか?</span><span class="sxs-lookup"><span data-stu-id="d720a-110">What does *observable* mean for a property?</span></span>
<span data-ttu-id="d720a-111">たとえば、**BookSku** という名前のランタイム クラスに **Title** という名前のプロパティがあるとします。</span><span class="sxs-lookup"><span data-stu-id="d720a-111">Let's say that a runtime class named **BookSku** has a property named **Title**.</span></span> <span data-ttu-id="d720a-112">**Title** の値が変わるたびに **BookSku** が [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) イベントを発生させることを選択する場合、**Title** は監視可能なプロパティです。</span><span class="sxs-lookup"><span data-stu-id="d720a-112">If **BookSku** chooses to raise the [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) event whenever the value of **Title** changes, then **Title** is an observable property.</span></span> <span data-ttu-id="d720a-113">そのプロパティ (あれば) のどれが監視可能かを決定するのは **BookSku** の動作 (イベントを発生させるまたは発生させない) です。</span><span class="sxs-lookup"><span data-stu-id="d720a-113">It's the behavior of **BookSku** (raising or not raising the event) that determines which, if any, of its properties are observable.</span></span>

<span data-ttu-id="d720a-114">XAML テキスト要素、またはコントロールでは、更新された値を取得して、新しい値を表示するためにそれ自体を更新することで、これらのイベントをバインドし、処理することができます。</span><span class="sxs-lookup"><span data-stu-id="d720a-114">A XAML text element, or control, can bind to, and handle, these events by retrieving the updated value(s) and then updating itself to show the new value.</span></span>

> [!NOTE]
> <span data-ttu-id="d720a-115">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d720a-115">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="create-a-blank-app-bookstore"></a><span data-ttu-id="d720a-116">空のアプリ (Bookstore) を作成する</span><span class="sxs-lookup"><span data-stu-id="d720a-116">Create a Blank App (Bookstore)</span></span>
<span data-ttu-id="d720a-117">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d720a-117">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="d720a-118">**Visual C++ 空のアプリ (C++/WinRT)** プロジェクトを作成し、*Bookstore* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="d720a-118">Create a **Visual C++ Blank App (C++/WinRT)** project, and name it *Bookstore*.</span></span>

<span data-ttu-id="d720a-119">監視可能なタイトルのプロパティを持つブックを表すための新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="d720a-119">We're going to author a new class to represent a book that has an observable title property.</span></span> <span data-ttu-id="d720a-120">同じコンパイル ユニット内のクラスを作成および使用しています。</span><span class="sxs-lookup"><span data-stu-id="d720a-120">We're authoring and consuming the class within the same compilation unit.</span></span> <span data-ttu-id="d720a-121">ただし、XAML からこのクラスへバインドできるようにしたいため、ランタイム クラスにします。</span><span class="sxs-lookup"><span data-stu-id="d720a-121">But we want to be able to bind to this class from XAML, and for that reason it's going to be a runtime class.</span></span> <span data-ttu-id="d720a-122">また、この作成と使用のどちらにも C++/WinRT を使用します。</span><span class="sxs-lookup"><span data-stu-id="d720a-122">And we're going to use C++/WinRT to both author and consume it.</span></span>

<span data-ttu-id="d720a-123">新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-123">The first step in authoring a new runtime class is to add a new **Midl File (.idl)** item to the project.</span></span> <span data-ttu-id="d720a-124">これに `BookSku.idl` という名前をつけます。</span><span class="sxs-lookup"><span data-stu-id="d720a-124">Name it `BookSku.idl`.</span></span> <span data-ttu-id="d720a-125">`BookSku.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d720a-125">Delete the default contents of `BookSku.idl`, and paste in this runtime class declaration.</span></span>

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
> <span data-ttu-id="d720a-126">ビュー モデル クラス&mdash;実際には、アプリケーションで宣言する任意のランタイム クラスで&mdash;基底クラスから派生しません。 必要があります。</span><span class="sxs-lookup"><span data-stu-id="d720a-126">Your view model classes&mdash;in fact, any runtime class that you declare in your application&mdash;need not derive from a base class.</span></span> <span data-ttu-id="d720a-127">上で宣言した**BookSku**クラスは、その例を示します。</span><span class="sxs-lookup"><span data-stu-id="d720a-127">The **BookSku** class declared above is an example of that.</span></span> <span data-ttu-id="d720a-128">、インターフェイスを実装することがそれは、基底クラスから派生したものです。</span><span class="sxs-lookup"><span data-stu-id="d720a-128">It implements an interface, but it doesn't derive from any base class.</span></span>
>
> <span data-ttu-id="d720a-129">ベースから、アプリケーションで宣言する任意のランタイム クラスを派生*は*そのクラスと呼ばれる、*構成可能な*クラスです。</span><span class="sxs-lookup"><span data-stu-id="d720a-129">Any runtime class that you declare in the application that *does* derive from a base class is known as a *composable* class.</span></span> <span data-ttu-id="d720a-130">構成可能なクラスを中心に制約があります。</span><span class="sxs-lookup"><span data-stu-id="d720a-130">And there are constraints around composable classes.</span></span> <span data-ttu-id="d720a-131">Visual Studio によって、Microsoft Store での提出を検証するために使用する[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)のテストに合格するアプリケーションの (とそのため、アプリケーションを Microsoft Store に正常に取り込まれるように)、構成可能なクラスにする必要があります最終的には、Windows の基底クラスから派生します。</span><span class="sxs-lookup"><span data-stu-id="d720a-131">For an application to pass the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) tests used by Visual Studio and by the Microsoft Store to validate submissions (and therefore for the application to be successfully ingested into the Microsoft Store), a composable class must ultimately derive from a Windows base class.</span></span> <span data-ttu-id="d720a-132">つまり継承階層の非常にルート クラスは、Windows.\* 名前空間から型である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d720a-132">Meaning that the class at the very root of the inheritance hierarchy must be a type originating in a Windows.\* namespace.</span></span> <span data-ttu-id="d720a-133">基底クラスからランタイム クラスを派生させる必要がある場合&mdash;から派生するビュー モデルのすべての**BindableBase**クラスを実装する場合など&mdash;し[**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject)から派生することができます。</span><span class="sxs-lookup"><span data-stu-id="d720a-133">If you do need to derive a runtime class from a base class&mdash;for example, to implement a **BindableBase** class for all of your view models to derive from&mdash;then you can derive from [**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject).</span></span>
>
> <span data-ttu-id="d720a-134">ビュー モデルは、ビューのアブストラクションとビュー (XAML マークアップ) に直接バインドされているためです。</span><span class="sxs-lookup"><span data-stu-id="d720a-134">A view model is an abstraction of a view, and so it's bound directly to the view (the XAML markup).</span></span> <span data-ttu-id="d720a-135">データ モデルは、データのアブストラクションとされたが、ビュー モデルでのみ使用して XAML に直接バインドされません。</span><span class="sxs-lookup"><span data-stu-id="d720a-135">A data model is an abstraction of data, and it's consumed only from your view models, and not bound directly to XAML.</span></span> <span data-ttu-id="d720a-136">そのため、ランタイム クラスは、としてではなく C++ 構造体またはクラスとして、データ モデルを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="d720a-136">So, you can declare your data models not as runtime classes, but as C++ structs or classes.</span></span> <span data-ttu-id="d720a-137">MIDL で宣言する必要のないし、する任意の継承階層を使って自由にことができます。</span><span class="sxs-lookup"><span data-stu-id="d720a-137">They don't need to be declared in MIDL, and you're free to use whatever inheritance hierarchy you like.</span></span>

<span data-ttu-id="d720a-138">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="d720a-138">Save the file and build the project.</span></span> <span data-ttu-id="d720a-139">ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="d720a-139">During the build process, the `midl.exe` tool is run to create a Windows Runtime metadata file (`\Bookstore\Debug\Bookstore\Unmerged\BookSku.winmd`) describing the runtime class.</span></span> <span data-ttu-id="d720a-140">次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="d720a-140">Then, the `cppwinrt.exe` tool is run to generate source code files to support you in authoring and consuming your runtime class.</span></span> <span data-ttu-id="d720a-141">これらのファイルには、IDL で宣言した **BookSku** ランタイム クラスの実装を開始するためのスタブが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d720a-141">These files include stubs to get you started implementing the **BookSku** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="d720a-142">これらのスタブは `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` と `BookSku.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="d720a-142">Those stubs are `\Bookstore\Bookstore\Generated Files\sources\BookSku.h` and `BookSku.cpp`.</span></span>

<span data-ttu-id="d720a-143">スタブ ファイル `BookSku.h` と `BookSku.cpp` を `\Bookstore\Bookstore\Generated Files\sources\` からプロジェクト フォルダー `\Bookstore\Bookstore\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="d720a-143">Copy the stub files `BookSku.h` and `BookSku.cpp` from `\Bookstore\Bookstore\Generated Files\sources\` into the project folder, which is `\Bookstore\Bookstore\`.</span></span> <span data-ttu-id="d720a-144">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d720a-144">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="d720a-145">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d720a-145">Right-click the stub files that you copied, and click **Include In Project**.</span></span>

## <a name="implement-booksku"></a><span data-ttu-id="d720a-146">**BookSku** を実装する</span><span class="sxs-lookup"><span data-stu-id="d720a-146">Implement **BookSku**</span></span>
<span data-ttu-id="d720a-147">ここで、`\Bookstore\Bookstore\BookSku.h` と `BookSku.cpp` を開いてとランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="d720a-147">Now, let's open `\Bookstore\Bookstore\BookSku.h` and `BookSku.cpp` and implement our runtime class.</span></span> <span data-ttu-id="d720a-148">`BookSku.h` で、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を取るコンストラクター、タイトル文字列を格納するためのプライベート メンバー、およびタイトルが変更されたときに発生させるイベントのための別のプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-148">In `BookSku.h`, add a constructor that takes a [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring), a private member to store the title string, and another for the event that we'll raise when the title changes.</span></span> <span data-ttu-id="d720a-149">これらの変更を行った後、`BookSku.h`次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d720a-149">After making these changes, your `BookSku.h` will look like this.</span></span>

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

<span data-ttu-id="d720a-150">`BookSku.cpp` では、次のように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="d720a-150">In `BookSku.cpp`, implement the functions like this.</span></span>

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

<span data-ttu-id="d720a-151">**タイトル**ミューテーター関数であるかどうか、値が設定されて現在の値とは異なるを確認します。</span><span class="sxs-lookup"><span data-stu-id="d720a-151">In the **Title** mutator function, we check whether a value is being set that's different from the current value.</span></span> <span data-ttu-id="d720a-152">その場合は、タイトルを更新も変更されたプロパティの名前に等しい引数で[**inotifypropertychanged::propertychanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="d720a-152">And, if so, we update the title and also raise the [**INotifyPropertyChanged::PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) event with an argument equal to the name of the property that has changed.</span></span> <span data-ttu-id="d720a-153">これにより、ユーザー インターフェイス (UI) はどのプロパティの値を再クエリするのか分かるようになります。</span><span class="sxs-lookup"><span data-stu-id="d720a-153">This is so that the user-interface (UI) will know which property's value to re-query.</span></span>

## <a name="declare-and-implement-bookstoreviewmodel"></a><span data-ttu-id="d720a-154">**BookstoreViewModel** を宣言および実装する</span><span class="sxs-lookup"><span data-stu-id="d720a-154">Declare and implement **BookstoreViewModel**</span></span>
<span data-ttu-id="d720a-155">メイン XAML ページが、メイン ビュー モデルにバインドします。</span><span class="sxs-lookup"><span data-stu-id="d720a-155">Our main XAML page is going to bind to a main view model.</span></span> <span data-ttu-id="d720a-156">またそのビュー モデルは、**BookSku** 型のいずれかを含む、いくつかのプロパティを持つようになります。</span><span class="sxs-lookup"><span data-stu-id="d720a-156">And that view model is going to have several properties, including one of type **BookSku**.</span></span> <span data-ttu-id="d720a-157">この手順では、メイン ビュー モデル ランタイム クラスを宣言および実装します。</span><span class="sxs-lookup"><span data-stu-id="d720a-157">In this step, we'll declare and implement our main view model runtime class.</span></span>

<span data-ttu-id="d720a-158">`BookstoreViewModel.idl` という名前の新しい **Midl ファイル (.idl)** 項目を追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-158">Add a new **Midl File (.idl)** item named `BookstoreViewModel.idl`.</span></span>

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

<span data-ttu-id="d720a-159">保存してビルドします。</span><span class="sxs-lookup"><span data-stu-id="d720a-159">Save and build.</span></span> <span data-ttu-id="d720a-160">`Generated Files` フォルダーから `BookstoreViewModel.h` と `BookstoreViewModel.cpp` をプロジェクト フォルダーにコピーし、プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-160">Copy `BookstoreViewModel.h` and `BookstoreViewModel.cpp` from the `Generated Files` folder into the project folder, and include them in the project.</span></span> <span data-ttu-id="d720a-161">それらのファイルを開き、以下に示すように、ランタイム クラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="d720a-161">Open those files and implement the runtime class as shown below.</span></span> <span data-ttu-id="d720a-162">注: 方法で、 `BookstoreViewModel.h`、ここに含まれている`BookSku.h`、実装型 (**::implementation::booksku**) を宣言しています。</span><span class="sxs-lookup"><span data-stu-id="d720a-162">Note how, in `BookstoreViewModel.h`, we're including `BookSku.h`, which declares the implementation type (**winrt::Bookstore::implementation::BookSku**).</span></span> <span data-ttu-id="d720a-163">削除することで、既定のコンス トラクターを復元しますいる`= delete`します。</span><span class="sxs-lookup"><span data-stu-id="d720a-163">And we're restoring the default constructor by removing `= delete`.</span></span>

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
> <span data-ttu-id="d720a-164">`m_bookSku` の型は投影型 (**winrt::Bookstore::BookSku**) であり、**make** で使用するテンプレート パラメーターは実装型 (**winrt::Bookstore::implementation::BookSku**) です。</span><span class="sxs-lookup"><span data-stu-id="d720a-164">The type of `m_bookSku` is the projected type (**winrt::Bookstore::BookSku**), and the template parameter that you use with **make** is the implementation type (**winrt::Bookstore::implementation::BookSku**).</span></span> <span data-ttu-id="d720a-165">この場合も、[**make**] は投影型のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="d720a-165">Even so, **make** returns an instance of the projected type.</span></span>

## <a name="add-a-property-of-type-bookstoreviewmodel-to-mainpage"></a><span data-ttu-id="d720a-166">**BookstoreViewModel** 型のプロパティを **MainPage** に追加する</span><span class="sxs-lookup"><span data-stu-id="d720a-166">Add a property of type **BookstoreViewModel** to **MainPage**</span></span>
<span data-ttu-id="d720a-167">`MainPage.idl` を開きます。ここでメインの UI ページを表すランタイム クラスを宣言しています。</span><span class="sxs-lookup"><span data-stu-id="d720a-167">Open `MainPage.idl`, which declares the runtime class that represents our main UI page.</span></span> <span data-ttu-id="d720a-168">インポート ステートメントを追加して `BookstoreViewModel.idl` をインポートし、**BookstoreViewModel** 型の MainViewModel という名前の読み取り専用プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-168">Add an import statement to import `BookstoreViewModel.idl`, and add a read-only property named MainViewModel of type **BookstoreViewModel**.</span></span> <span data-ttu-id="d720a-169">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="d720a-169">Also remove the **MyProperty** property.</span></span> <span data-ttu-id="d720a-170">また、`import`ディレクティブの一覧を以下にします。</span><span class="sxs-lookup"><span data-stu-id="d720a-170">Also note the `import` directive in the listing below.</span></span>

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

<span data-ttu-id="d720a-171">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="d720a-171">Save the file.</span></span> <span data-ttu-id="d720a-172">現時点で完了するまで、プロジェクトのビルドはありませんが、 **MainPage**ランタイム クラスを実装するソース コード ファイルを再生成されるために有用なことは、構築できるようになりました (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`)。</span><span class="sxs-lookup"><span data-stu-id="d720a-172">The project won't build to completion at the moment, but building now is a useful thing to do because it regenerates the source code files in which the **MainPage** runtime class is implemented (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h` and `MainPage.cpp`).</span></span> <span data-ttu-id="d720a-173">したがってならないし、構築できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="d720a-173">So go ahead and build now.</span></span> <span data-ttu-id="d720a-174">この段階で確認することが予想されることができますビルド エラーが **'MainViewModel': 'winrt::Bookstore::implementation::MainPage' のメンバーでない**します。</span><span class="sxs-lookup"><span data-stu-id="d720a-174">The build error you can expect to see at this stage is **'MainViewModel': is not a member of 'winrt::Bookstore::implementation::MainPage'**.</span></span>

<span data-ttu-id="d720a-175">インクルードを省略すると`BookstoreViewModel.idl`(の登録情報を表示`MainPage.idl`上)、エラーを表示し、**想定 \ <"MainViewModel"の近く**します。</span><span class="sxs-lookup"><span data-stu-id="d720a-175">If you omit the include of `BookstoreViewModel.idl` (see the listing of `MainPage.idl` above), then you'll see the error **expecting \< near "MainViewModel"**.</span></span> <span data-ttu-id="d720a-176">別のヒントは、同じ名前空間のすべての種類のままにするかどうかを確認する: コードの登録情報に表示される名前空間です。</span><span class="sxs-lookup"><span data-stu-id="d720a-176">Another tip is to make sure that you leave all types in the same namespace: the namespace that's shown in the code listings.</span></span>

<span data-ttu-id="d720a-177">表示を行う必要がエラーを解決するには、今すぐ必要がありますに生成されたファイルから**MainViewModel**プロパティのアクセサー スタブをコピー (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h`と`MainPage.cpp`) に`\Bookstore\Bookstore\MainPage.h`と`MainPage.cpp`します。</span><span class="sxs-lookup"><span data-stu-id="d720a-177">To resolve the error that we expect to see, you'll now need to copy the accessor stubs for the **MainViewModel** property out of the generated files (`\Bookstore\Bookstore\Generated Files\sources\MainPage.h` and `MainPage.cpp`) and into `\Bookstore\Bookstore\MainPage.h` and `MainPage.cpp`.</span></span>

<span data-ttu-id="d720a-178">`\Bookstore\Bookstore\MainPage.h`、含める`BookstoreViewModel.h`、実装型 (**winrt::Bookstore::implementation::BookstoreViewModel**) を宣言しています。</span><span class="sxs-lookup"><span data-stu-id="d720a-178">In `\Bookstore\Bookstore\MainPage.h`, include `BookstoreViewModel.h`, which declares the implementation type (**winrt::Bookstore::implementation::BookstoreViewModel**).</span></span> <span data-ttu-id="d720a-179">ビュー モデルを格納するプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="d720a-179">Add a private member to store the view model.</span></span> <span data-ttu-id="d720a-180">プロパティ アクセサー関数 (およびメンバー m_mainViewModel) は、投影型である **Bookstore::BookstoreViewModel** に関して実装されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d720a-180">Note that the property accessor function (and the member m_mainViewModel) is implemented in terms of **Bookstore::BookstoreViewModel**, which is the projected type.</span></span> <span data-ttu-id="d720a-181">コンス トラクターのオーバー ロードによって m_mainViewModel を作成しますので、アプリケーションと同じプロジェクト (コンパイル ユニット) に実装型は`nullptr_t`します。</span><span class="sxs-lookup"><span data-stu-id="d720a-181">The implementation type is in the same project (compilation unit) as the application, so we construct m_mainViewModel via the constructor overload that takes `nullptr_t`.</span></span> <span data-ttu-id="d720a-182">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="d720a-182">Also remove the **MyProperty** property.</span></span>

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

<span data-ttu-id="d720a-183">`\Bookstore\Bookstore\MainPage.cpp`、 [**Winrt::make**](/uwp/cpp-ref-for-winrt/make)呼び出し (実装型) の投影型の新しいインスタンスを m_mainViewModel に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="d720a-183">In `\Bookstore\Bookstore\MainPage.cpp`, call [**winrt::make**](/uwp/cpp-ref-for-winrt/make) (with the implementation type) to assign a new instance of the projected type to m_mainViewModel.</span></span> <span data-ttu-id="d720a-184">ブックのタイトルの初期値を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="d720a-184">Assign an initial value for the book's title.</span></span> <span data-ttu-id="d720a-185">MainViewModel プロパティのアクセサーを実装します。</span><span class="sxs-lookup"><span data-stu-id="d720a-185">Implement the accessor for the MainViewModel property.</span></span> <span data-ttu-id="d720a-186">最後に、ボタンのイベント ハンドラーでブックのタイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="d720a-186">And finally, update the book's title in the button's event handler.</span></span> <span data-ttu-id="d720a-187">また、**今度**プロパティを削除します。</span><span class="sxs-lookup"><span data-stu-id="d720a-187">Also remove the **MyProperty** property.</span></span>

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

## <a name="bind-the-button-to-the-title-property"></a><span data-ttu-id="d720a-188">**Title** プロパティにボタンをバインドする</span><span class="sxs-lookup"><span data-stu-id="d720a-188">Bind the button to the **Title** property</span></span>
<span data-ttu-id="d720a-189">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="d720a-189">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="d720a-190">登録情報を以下に示すように、ボタンから名前を削除し、その**コンテンツ**プロパティの値をリテラルからバインド式に変更します。</span><span class="sxs-lookup"><span data-stu-id="d720a-190">As shown in the listing below, remove the name from the button, and change its **Content** property value from a literal to a binding expression.</span></span> <span data-ttu-id="d720a-191">バインド式の `Mode=OneWay` プロパティをメモします (ビュー モデルから UI へ一方向)。</span><span class="sxs-lookup"><span data-stu-id="d720a-191">Note the `Mode=OneWay` property on the binding expression (one-way from the view model to the UI).</span></span> <span data-ttu-id="d720a-192">そのプロパティが無いと、UI はプロパティの変更イベントに応答しません。</span><span class="sxs-lookup"><span data-stu-id="d720a-192">Without that property, the UI will not respond to property changed events.</span></span>

```xaml
<Button Click="ClickHandler" Content="{x:Bind MainViewModel.BookSku.Title, Mode=OneWay}"/>
```

<span data-ttu-id="d720a-193">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="d720a-193">Now build and run the project.</span></span> <span data-ttu-id="d720a-194">ボタンをクリックして**クリック** イベント ハンドラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="d720a-194">Click the button to execute the **Click** event handler.</span></span> <span data-ttu-id="d720a-195">そのハンドラーがブックのタイトル ミューテーター関数を呼び出します。そのミューテーターがイベントを発生させるので、UI は **Title** プロパティが変更されたことがわかります。ボタンはそのプロパティの値を再クエリして、そのボタンの **Content** 値を更新します。</span><span class="sxs-lookup"><span data-stu-id="d720a-195">That handler calls the book's title mutator function; that mutator raises an event to let the UI know that the **Title** property has changed; and the button re-queries that property's value to update its own **Content** value.</span></span>

## <a name="using-the-binding-markup-extension-with-cwinrt"></a><span data-ttu-id="d720a-196">{Binding} マークアップ拡張機能を使用して、C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="d720a-196">Using the {Binding} markup extension with C++/WinRT</span></span>
<span data-ttu-id="d720a-197">現在リリースされているバージョンの C + + を[ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります、{binding} マークアップ拡張を使用するために、WinRT します。</span><span class="sxs-lookup"><span data-stu-id="d720a-197">For the currently released version of C++/WinRT, in order to be able to use the {Binding} markup extension you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces.</span></span>

## <a name="important-apis"></a><span data-ttu-id="d720a-198">重要な API</span><span class="sxs-lookup"><span data-stu-id="d720a-198">Important APIs</span></span>
* [<span data-ttu-id="d720a-199">INotifyPropertyChanged::PropertyChanged</span><span class="sxs-lookup"><span data-stu-id="d720a-199">INotifyPropertyChanged::PropertyChanged</span></span>](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged)
* [<span data-ttu-id="d720a-200">winrt::make 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="d720a-200">winrt::make function template</span></span>](/uwp/cpp-ref-for-winrt/make)

## <a name="related-topics"></a><span data-ttu-id="d720a-201">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d720a-201">Related topics</span></span>
* [<span data-ttu-id="d720a-202">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="d720a-202">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="d720a-203">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="d720a-203">Author APIs with C++/WinRT</span></span>](author-apis.md)
