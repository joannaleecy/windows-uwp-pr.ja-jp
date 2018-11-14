---
author: stevewhims
ms.assetid: 41E1B4F1-6CAF-4128-A61A-4E400B149011
title: データ バインディングの詳細
description: データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。
ms.author: stwhi
ms.date: 10/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
ms.openlocfilehash: 0d7f6667aeb2f6c7c07f8f4c2d5944f559ebe0d8
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6456305"
---
# <a name="data-binding-in-depth"></a><span data-ttu-id="1a625-104">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="1a625-104">Data binding in depth</span></span>

**<span data-ttu-id="1a625-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="1a625-105">Important APIs</span></span>**

-   [**<span data-ttu-id="1a625-106">{x:Bind} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="1a625-106">{x:Bind} markup extension</span></span>**](../xaml-platform/x-bind-markup-extension.md)
-   [**<span data-ttu-id="1a625-107">Binding クラス</span><span class="sxs-lookup"><span data-stu-id="1a625-107">Binding class</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR209820)
-   [**<span data-ttu-id="1a625-108">DataContext</span><span class="sxs-lookup"><span data-stu-id="1a625-108">DataContext</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR208713)
-   [**<span data-ttu-id="1a625-109">INotifyPropertyChanged</span><span class="sxs-lookup"><span data-stu-id="1a625-109">INotifyPropertyChanged</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR209899)

> [!NOTE]
> <span data-ttu-id="1a625-110">このトピックでは、データ バインディングの機能について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="1a625-110">This topic describes data binding features in detail.</span></span> <span data-ttu-id="1a625-111">簡潔で実用的な紹介については、「[データ バインディングの概要](data-binding-quickstart.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-111">For a short, practical introduction, see [Data binding overview](data-binding-quickstart.md).</span></span>

<span data-ttu-id="1a625-112">データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。</span><span class="sxs-lookup"><span data-stu-id="1a625-112">Data binding is a way for your app's UI to display data, and optionally to stay in sync with that data.</span></span> <span data-ttu-id="1a625-113">データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。</span><span class="sxs-lookup"><span data-stu-id="1a625-113">Data binding allows you to separate the concern of data from the concern of UI, and that results in a simpler conceptual model as well as better readability, testability, and maintainability of your app.</span></span>

<span data-ttu-id="1a625-114">データ バインディングは、UI が最初に表示されたときにデータ ソースからの値を表示するだけの場合に使うことができ、それらの値の変化に応答するために使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="1a625-114">You can use data binding to simply display values from a data source when the UI is first shown, but not to respond to changes in those values.</span></span> <span data-ttu-id="1a625-115">これは、バインドと呼ばれるモード*1 回限り*、し、実行時に変更されない値に適しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-115">This is a mode of binding called *one-time*, and it works well for a value that doesn't change during run-time.</span></span> <span data-ttu-id="1a625-116">または、値を「監視」しが変化したときに UI を更新するを選択できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-116">Alternatively, you can choose to "observe" the values and to update the UI when they change.</span></span> <span data-ttu-id="1a625-117">このモードと呼ばれる*一方向*、読み取り専用のデータに適しているとします。</span><span class="sxs-lookup"><span data-stu-id="1a625-117">This mode is called *one-way*, and it works well for read-only data.</span></span> <span data-ttu-id="1a625-118">最終的には、ユーザーが UI で値に対して行った変更が自動的にデータ ソースにプッシュバックされるように、監視と更新の両方を行うことを選択できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-118">Ultimately, you can choose to both observe and update, so that changes that the user makes to values in the UI are automatically pushed back into the data source.</span></span> <span data-ttu-id="1a625-119">このモードと呼ばれる*双方向*、および読み取り/書き込みのデータに適しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-119">This mode is called *two-way*, and it works well for read-write data.</span></span> <span data-ttu-id="1a625-120">例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="1a625-120">Here are some examples.</span></span>

-   <span data-ttu-id="1a625-121">1 回限りのモードを使用して、[**イメージ**](https://msdn.microsoft.com/library/windows/apps/BR242752)を現在のユーザーの写真にバインドする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-121">You could use the one-time mode to bind an [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) to the current user's photo.</span></span>
-   <span data-ttu-id="1a625-122">一方向モードを使用して、 [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878)を新聞のセクションでグループ化されたリアルタイムのニュース記事のコレクションにバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-122">You could use the one-way mode to bind a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to a collection of real-time news articles grouped by newspaper section.</span></span>
-   <span data-ttu-id="1a625-123">双方向モードを使用して、 [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)をフォーム内の顧客の名前にバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-123">You could use the two-way mode to bind a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) to a customer's name in a form.</span></span>

<span data-ttu-id="1a625-124">モードに関係なくは、バインドの 2 つの種類と両方通常宣言されている UI マークアップでします。</span><span class="sxs-lookup"><span data-stu-id="1a625-124">Independent of mode, there are two kinds of binding, and they're both typically declared in UI markup.</span></span> <span data-ttu-id="1a625-125">[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)と [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)のいずれを使うかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-125">You can choose to use either the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783) or the [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span> <span data-ttu-id="1a625-126">また、同じアプリや同じ UI 要素で、この 2 つを組み合わせて使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-126">And you can even use a mixture of the two in the same app—even on the same UI element.</span></span> <span data-ttu-id="1a625-127">{X:bind} は windows 10 の新機能であり、パフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="1a625-127">{x:Bind} is new for Windows10 and it has better performance.</span></span> <span data-ttu-id="1a625-128">このトピックで説明されているすべての詳細は、特に明記していない限り、両方の種類のバインディングに適用されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-128">All the details described in this topic apply to both kinds of binding unless we explicitly say otherwise.</span></span>

**<span data-ttu-id="1a625-129">{x:Bind} の使い方を示すサンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="1a625-129">Sample apps that demonstrate {x:Bind}</span></span>**

-   <span data-ttu-id="1a625-130">[{x:Bind} のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619989)。</span><span class="sxs-lookup"><span data-stu-id="1a625-130">[{x:Bind} sample](http://go.microsoft.com/fwlink/p/?linkid=619989).</span></span>
-   <span data-ttu-id="1a625-131">[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)。</span><span class="sxs-lookup"><span data-stu-id="1a625-131">[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame).</span></span>
-   <span data-ttu-id="1a625-132">[XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619992)。</span><span class="sxs-lookup"><span data-stu-id="1a625-132">[XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?linkid=619992).</span></span>

**<span data-ttu-id="1a625-133">{Binding} の使い方を示すサンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="1a625-133">Sample apps that demonstrate {Binding}</span></span>**

-   <span data-ttu-id="1a625-134">[Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="1a625-134">Download the [Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) app.</span></span>
-   <span data-ttu-id="1a625-135">[Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="1a625-135">Download the [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) app.</span></span>

## <a name="every-binding-involves-these-pieces"></a><span data-ttu-id="1a625-136">すべてのバインディングに関連する要素</span><span class="sxs-lookup"><span data-stu-id="1a625-136">Every binding involves these pieces</span></span>

-   <span data-ttu-id="1a625-137">*バインディング ソース*。</span><span class="sxs-lookup"><span data-stu-id="1a625-137">A *binding source*.</span></span> <span data-ttu-id="1a625-138">これは、バインディング用のデータのソースで、UI に表示する値を持つメンバーが含まれる、任意のクラスのインスタンスを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-138">This is the source of the data for the binding, and it can be an instance of any class that has members whose values you want to display in your UI.</span></span>
-   <span data-ttu-id="1a625-139">*バインディング ターゲット*。</span><span class="sxs-lookup"><span data-stu-id="1a625-139">A *binding target*.</span></span> <span data-ttu-id="1a625-140">これは、データを表示する UI の [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) の [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) です。</span><span class="sxs-lookup"><span data-stu-id="1a625-140">This is a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) of the [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) in your UI that displays the data.</span></span>
-   <span data-ttu-id="1a625-141">*バインディング オブジェクト*。</span><span class="sxs-lookup"><span data-stu-id="1a625-141">A *binding object*.</span></span> <span data-ttu-id="1a625-142">これは、ソースからターゲットに、および必要に応じてターゲットからソースに、データ値を転送する要素です。</span><span class="sxs-lookup"><span data-stu-id="1a625-142">This is the piece that transfers data values from the source to the target, and optionally from the target back to the source.</span></span> <span data-ttu-id="1a625-143">バインディング オブジェクトは、XAML の読み込み時に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) または [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) マークアップ拡張から作成されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-143">The binding object is created at XAML load time from your [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) or [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

<span data-ttu-id="1a625-144">次のセクションでは、バインディング ソース、バインディング ターゲット、バインド オブジェクトについて詳しく見てみます。</span><span class="sxs-lookup"><span data-stu-id="1a625-144">In the following sections, we'll take a closer look at the binding source, the binding target, and the binding object.</span></span> <span data-ttu-id="1a625-145">また、以下のセクションでは、**HostViewModel** という名前のクラスに属する **NextButtonText** という名前の文字列プロパティに、ボタンのコンテンツをバインドする例へのリンクも示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-145">And we'll link the sections together with the example of binding a button's content to a string property named **NextButtonText**, which belongs to a class named **HostViewModel**.</span></span>

### <a name="binding-source"></a><span data-ttu-id="1a625-146">バインディング ソース</span><span class="sxs-lookup"><span data-stu-id="1a625-146">Binding source</span></span>

<span data-ttu-id="1a625-147">バインディング ソースとして使用できるクラスの非常に基本的な実装を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-147">Here's a very rudimentary implementation of a class that we could use as a binding source.</span></span>

<span data-ttu-id="1a625-148">使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、という名前の c++ に示すように、プロジェクトに新しい**Midl ファイル (.idl)** 項目を追加/WinRT コードの例の一覧が以下。</span><span class="sxs-lookup"><span data-stu-id="1a625-148">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then add new **Midl File (.idl)** items to the project, named as shown in the C++/WinRT code example listing below.</span></span> <span data-ttu-id="1a625-149">これらの新しいファイルの内容を一覧に表示される[MIDL 3.0](/uwp/midl-3/intro)コードに置き換えます、生成するプロジェクトをビルド`HostViewModel.h`と`.cpp`、し、登録情報に一致するように、生成されたファイルにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="1a625-149">Replace the contents of those new files with the [MIDL 3.0](/uwp/midl-3/intro) code shown in the listing, build the project to generate `HostViewModel.h` and `.cpp`, and then add code to the generated files to match the listing.</span></span> <span data-ttu-id="1a625-150">生成されたファイルについて詳しくは、プロジェクトにコピーする方法を参照してください[XAML コントロール、バインドを C++/WinRT プロパティ](/windows/uwp/cpp-and-winrt-apis/binding-property)。</span><span class="sxs-lookup"><span data-stu-id="1a625-150">For more info about those generated files and how to copy them into your project, see [XAML controls; bind to a C++/WinRT property](/windows/uwp/cpp-and-winrt-apis/binding-property).</span></span>

```csharp
public class HostViewModel
{
    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText { get; set; }
}
```

```cppwinrt
// HostViewModel.idl
namespace DataBindingInDepth
{
    runtimeclass HostViewModel
    {
        HostViewModel();
        String NextButtonText;
    }
}

// HostViewModel.h
// Implement the constructor like this, and add this field:
...
HostViewModel() : m_nextButtonText{ L"Next" } {}
...
private:
    std::wstring m_nextButtonText;
...

// HostViewModel.cpp
// Implement like this:
...
hstring HostViewModel::NextButtonText()
{
    return hstring{ m_nextButtonText };
}

void HostViewModel::NextButtonText(hstring const& value)
{
    m_nextButtonText = value;
}
...
```

<span data-ttu-id="1a625-151">**HostViewModel** の実装とその **NextButtonText** プロパティは、1 回限りのバインディングにのみ適しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-151">That implementation of **HostViewModel**, and its property **NextButtonText**, are only appropriate for one-time binding.</span></span> <span data-ttu-id="1a625-152">ただし、一方向バインディングと双方向バインディングは非常に一般的であり、これらの種類のバインディングでは、UI はバインディング ソースのデータ値の変化に対応して自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-152">But one-way and two-way bindings are extremely common, and in those kinds of binding the UI automatically updates in response to changes in the data values of the binding source.</span></span> <span data-ttu-id="1a625-153">これらの種類のバインディングが正常に動作するには、バインディング ソースをバインディング オブジェクトから "監視可能" にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-153">In order for those kinds of binding to work correctly, you need to make your binding source "observable" to the binding object.</span></span> <span data-ttu-id="1a625-154">この例では、**NextButtonText** プロパティに対して一方向または双方向バインディングを設定する場合、実行時にこのプロパティの値に対して発生するすべての変更を、バインディング オブジェクトから監視可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-154">So in our example, if we want to one-way or two-way bind to the **NextButtonText** property, then any changes that happen at run-time to the value of that property need to be made observable to the binding object.</span></span>

<span data-ttu-id="1a625-155">そのための方法の 1 つは、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356) からバインディング ソースを表すクラスを派生させ、[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) を通じてデータ値を公開することです。</span><span class="sxs-lookup"><span data-stu-id="1a625-155">One way of doing that is to derive the class that represents your binding source from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356), and expose a data value through a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362).</span></span> <span data-ttu-id="1a625-156">これが、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) を監視可能にする方法です。</span><span class="sxs-lookup"><span data-stu-id="1a625-156">That's how a [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) becomes observable.</span></span> <span data-ttu-id="1a625-157">**FrameworkElements** は、そのまま利用できる優れたバインディング ソースです。</span><span class="sxs-lookup"><span data-stu-id="1a625-157">**FrameworkElements** are good binding sources right out of the box.</span></span>

<span data-ttu-id="1a625-158">より簡単にクラスを監視可能にする方法 (および既に基底クラスがあるクラスで必要な方法) は、[**System.ComponentModel.INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) を実装することです。</span><span class="sxs-lookup"><span data-stu-id="1a625-158">A more lightweight way of making a class observable—and a necessary one for classes that already have a base class—is to implement [**System.ComponentModel.INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx).</span></span> <span data-ttu-id="1a625-159">この方法は、**PropertyChanged** という名前の単一のイベントを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="1a625-159">This really just involves implementing a single event named **PropertyChanged**.</span></span> <span data-ttu-id="1a625-160">**HostViewModel** を使った例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-160">An example using **HostViewModel** is below.</span></span>

```csharp
...
using System.ComponentModel;
using System.Runtime.CompilerServices;
...
public class HostViewModel : INotifyPropertyChanged
{
    private string nextButtonText;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText
    {
        get { return this.nextButtonText; }
        set
        {
            this.nextButtonText = value;
            this.OnPropertyChanged();
        }
    }

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        // Raise the PropertyChanged event, passing the name of the property whose value has changed.
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

```cppwinrt
// HostViewModel.idl
namespace DataBindingInDepth
{
    runtimeclass HostViewModel : Windows.UI.Xaml.Data.INotifyPropertyChanged
    {
        HostViewModel();
        String NextButtonText;
    }
}

// HostViewModel.h
// Add this field:
...
    winrt::event_token PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler);
    void PropertyChanged(winrt::event_token const& token) noexcept;

private:
    winrt::event<Windows::UI::Xaml::Data::PropertyChangedEventHandler> m_propertyChanged;
...

// HostViewModel.cpp
// Implement like this:
...
void HostViewModel::NextButtonText(hstring const& value)
{
    if (m_nextButtonText != value)
    {
        m_nextButtonText = value;
        m_propertyChanged(*this, Windows::UI::Xaml::Data::PropertyChangedEventArgs{ L"NextButtonText" });
    }
}

winrt::event_token HostViewModel::PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler)
{
    return m_propertyChanged.add(handler);
}

void HostViewModel::PropertyChanged(winrt::event_token const& token) noexcept
{
    m_propertyChanged.remove(token);
}
...
```

<span data-ttu-id="1a625-161">これで、**NextButtonText** プロパティは監視可能です。</span><span class="sxs-lookup"><span data-stu-id="1a625-161">Now the **NextButtonText** property is observable.</span></span> <span data-ttu-id="1a625-162">そのプロパティへの一方向または双方向のバインディングを作成する場合 (方法については後述)、作成したバインディング オブジェクトは **PropertyChanged** イベントを受信登録します。</span><span class="sxs-lookup"><span data-stu-id="1a625-162">When you author a one-way or a two-way binding to that property (we'll show how later), the resulting binding object subscribes to the **PropertyChanged** event.</span></span> <span data-ttu-id="1a625-163">そのイベントが発生すると、バインディング オブジェクトのハンドラーは、変更されたプロパティの名前を含む引数を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="1a625-163">When that event is raised, the binding object's handler receives an argument containing the name of the property that has changed.</span></span> <span data-ttu-id="1a625-164">このようにして、バインディング オブジェクトはどのプロパティの値が残っており、再び読み取る必要があるかを識別します。</span><span class="sxs-lookup"><span data-stu-id="1a625-164">That's how the binding object knows which property's value to go and read again.</span></span>

<span data-ttu-id="1a625-165">実装する必要があるないように、使っている場合は、c# できますし、複数回、上記のパターンはことがわかります[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)のサンプル (Common フォルダー) で、 **BindableBase**基底クラスから派生します。</span><span class="sxs-lookup"><span data-stu-id="1a625-165">So that you don't have to implement the pattern shown above multiple times, if you're using C# then you can just derive from the **BindableBase** bass class that you'll find in the [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) sample (in the "Common" folder).</span></span> <span data-ttu-id="1a625-166">どのようになるかを示す例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-166">Here's an example of how that looks.</span></span>

```csharp
public class HostViewModel : BindableBase
{
    private string nextButtonText;

    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText
    {
        get { return this.nextButtonText; }
        set { this.SetProperty(ref this.nextButtonText, value); }
    }
}
```

```cppwinrt
// Your BindableBase base class should itself derive from Windows::UI::Xaml::DependencyObject. Then, in HostViewModel.idl, derive from BindableBase instead of implementing INotifyPropertyChanged.
```

> [!NOTE]
> <span data-ttu-id="1a625-167">C++/WinRT、基底クラスから派生したアプリケーションで宣言する任意のランタイム クラスと呼ばれる、*構成可能な*クラスです。</span><span class="sxs-lookup"><span data-stu-id="1a625-167">For C++/WinRT, any runtime class that you declare in your application that derives from a base class is known as a *composable* class.</span></span> <span data-ttu-id="1a625-168">構成可能クラスの周囲の制約があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-168">And there are constraints around composable classes.</span></span> <span data-ttu-id="1a625-169">アプリケーションで、Visual Studio によって、Microsoft Store での提出を検証するために使用する[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)のテストに合格 (したがって、アプリケーションを Microsoft Store に正常に取り込まれるようにするため)、構成可能なクラスにする必要があります最終的には、Windows の基底クラスから派生します。</span><span class="sxs-lookup"><span data-stu-id="1a625-169">For an application to pass the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) tests used by Visual Studio and by the Microsoft Store to validate submissions (and therefore for the application to be successfully ingested into the Microsoft Store), a composable class must ultimately derive from a Windows base class.</span></span> <span data-ttu-id="1a625-170">つまり継承階層の非常にルート クラスは、Windows.\* 名前空間の型である必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-170">Meaning that the class at the very root of the inheritance hierarchy must be a type originating in a Windows.\* namespace.</span></span> <span data-ttu-id="1a625-171">基底クラスからランタイム クラスを派生させる必要がある場合&mdash;例では、すべてのビュー モデルから派生させる**BindableBase**クラスを実装する&mdash;し[**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject)から派生することができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-171">If you do need to derive a runtime class from a base class&mdash;for example, to implement a **BindableBase** class for all of your view models to derive from&mdash;then you can derive from [**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject).</span></span>

<span data-ttu-id="1a625-172">[**String.Empty**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.empty.aspx) または **null** の引数を使って **PropertyChanged** イベントを発生させることは、オブジェクトのすべての非インデクサー プロパティを再び読み取る必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-172">Raising the **PropertyChanged** event with an argument of [**String.Empty**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.empty.aspx) or **null** indicates that all non-indexer properties on the object should be re-read.</span></span> <span data-ttu-id="1a625-173">特定のインデクサーの場合は "Item\[*indexer*\]" (*indexer* はインデックス値) の引数、すべてのインデクサーの場合は "Item\[\]" の値を使って、オブジェクトのインデクサー プロパティが変更されたことを示すイベントを発生させることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-173">You can raise the event to indicate that indexer properties on the object have changed by using an argument of "Item\[*indexer*\]" for specific indexers (where *indexer* is the index value), or a value of "Item\[\]" for all indexers.</span></span>

<span data-ttu-id="1a625-174">バインディング ソースは、プロパティにデータが含まれる単一のオブジェクト、またはオブジェクトのコレクションとして処理できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-174">A binding source can be treated either as a single object whose properties contain data, or as a collection of objects.</span></span> <span data-ttu-id="1a625-175">C# および Visual Basic のコードでは、実行時に変更されないコレクションを表示する[**List (Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx)を実装するオブジェクトを 1 回限りのバインドことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-175">In C# and Visual Basic code, you can one-time bind to an object that implements [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) to display a collection that doesn't change at run-time.</span></span> <span data-ttu-id="1a625-176">監視可能なコレクション (コレクションの項目の追加と削除を監視する) の場合、代わりに [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) への一方向バインディングを設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-176">For an observable collection (observing when items are added to and removed from the collection), one-way bind to [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) instead.</span></span> <span data-ttu-id="1a625-177">C++ コードでは、監視可能なコレクションと監視可能ではないコレクションの両方について、[**Vector&lt;T&gt;**](https://msdn.microsoft.com/library/dn858385.aspx) にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-177">In C++ code, you can bind to [**Vector&lt;T&gt;**](https://msdn.microsoft.com/library/dn858385.aspx) for both observable and non-observable collections.</span></span> <span data-ttu-id="1a625-178">独自のコレクション クラスにバインドするには、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-178">To bind to your own collection classes, use the guidance in the following table.</span></span>

|<span data-ttu-id="1a625-179">シナリオ</span><span class="sxs-lookup"><span data-stu-id="1a625-179">Scenario</span></span>|<span data-ttu-id="1a625-180">C# と VB (CLR)</span><span class="sxs-lookup"><span data-stu-id="1a625-180">C# and VB (CLR)</span></span>|<span data-ttu-id="1a625-181">C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="1a625-181">C++/WinRT</span></span>|<span data-ttu-id="1a625-182">C++/CX</span><span class="sxs-lookup"><span data-stu-id="1a625-182">C++/CX</span></span>|
|-|-|-|-|
|<span data-ttu-id="1a625-183">オブジェクトにバインドする。</span><span class="sxs-lookup"><span data-stu-id="1a625-183">Bind to an object.</span></span>|<span data-ttu-id="1a625-184">どのオブジェクトでもかまいません。</span><span class="sxs-lookup"><span data-stu-id="1a625-184">Can be any object.</span></span>|<span data-ttu-id="1a625-185">どのオブジェクトでもかまいません。</span><span class="sxs-lookup"><span data-stu-id="1a625-185">Can be any object.</span></span>|<span data-ttu-id="1a625-186">オブジェクトで [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) を指定するか、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-186">Object must have [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) or implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span>|
|<span data-ttu-id="1a625-187">バインドされたオブジェクトからプロパティ変更通知を取得します。</span><span class="sxs-lookup"><span data-stu-id="1a625-187">Get property change notifications from a bound object.</span></span>|<span data-ttu-id="1a625-188">オブジェクトには、 [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx)を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-188">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx).</span></span>| <span data-ttu-id="1a625-189">オブジェクトには、 [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-189">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899).</span></span>|<span data-ttu-id="1a625-190">オブジェクトには、 [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-190">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899).</span></span>|
|<span data-ttu-id="1a625-191">コレクションにバインドする。</span><span class="sxs-lookup"><span data-stu-id="1a625-191">Bind to a collection.</span></span>| [**<span data-ttu-id="1a625-192">List(Of T)</span><span class="sxs-lookup"><span data-stu-id="1a625-192">List(Of T)</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx)|<span data-ttu-id="1a625-193">[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)の[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)にします。</span><span class="sxs-lookup"><span data-stu-id="1a625-193">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span> <span data-ttu-id="1a625-194">参照してください[XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](../cpp-and-winrt-apis/binding-collection.md)と[コレクション、C++/WinRT](../cpp-and-winrt-apis/collections.md)します。</span><span class="sxs-lookup"><span data-stu-id="1a625-194">See [XAML items controls; bind to a C++/WinRT collection](../cpp-and-winrt-apis/binding-collection.md) and [Collections with C++/WinRT](../cpp-and-winrt-apis/collections.md).</span></span>| [**<span data-ttu-id="1a625-195">ベクター&lt;T&gt;</span><span class="sxs-lookup"><span data-stu-id="1a625-195">Vector&lt;T&gt;</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx)|
|<span data-ttu-id="1a625-196">コレクションにバインドされたコレクションから変更通知を取得します。</span><span class="sxs-lookup"><span data-stu-id="1a625-196">Get collection change notifications from a bound collection.</span></span>|[**<span data-ttu-id="1a625-197">ObservableCollection(Of T)</span><span class="sxs-lookup"><span data-stu-id="1a625-197">ObservableCollection(Of T)</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx)|<span data-ttu-id="1a625-198">[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)の[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)にします。</span><span class="sxs-lookup"><span data-stu-id="1a625-198">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable).</span></span>|[**<span data-ttu-id="1a625-199">IObservableVector&lt;T&gt;</span><span class="sxs-lookup"><span data-stu-id="1a625-199">IObservableVector&lt;T&gt;</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226052.aspx)|
|<span data-ttu-id="1a625-200">バインドをサポートするコレクションを実装する。</span><span class="sxs-lookup"><span data-stu-id="1a625-200">Implement a collection that supports binding.</span></span>|<span data-ttu-id="1a625-201">[**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) を拡張するか、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx)、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/5y536ey6.aspx)(Of [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx))、[**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ienumerable.aspx)、または [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/9eekhta0.aspx)(Of **Object**) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-201">Extend [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) or implement [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx), [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/5y536ey6.aspx)(Of [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)), [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ienumerable.aspx), or [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/9eekhta0.aspx)(Of **Object**).</span></span> <span data-ttu-id="1a625-202">汎用の **IList(Of T)** と **IEnumerable(Of T)** へのバインドはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="1a625-202">Binding to generic **IList(Of T)** and **IEnumerable(Of T)** is not supported.</span></span>|<span data-ttu-id="1a625-203">[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)の[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_)を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-203">Implement [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable).</span></span> <span data-ttu-id="1a625-204">参照してください[XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](../cpp-and-winrt-apis/binding-collection.md)と[コレクション、C++/WinRT](../cpp-and-winrt-apis/collections.md)します。</span><span class="sxs-lookup"><span data-stu-id="1a625-204">See [XAML items controls; bind to a C++/WinRT collection](../cpp-and-winrt-apis/binding-collection.md) and [Collections with C++/WinRT](../cpp-and-winrt-apis/collections.md).</span></span>|<span data-ttu-id="1a625-205">[**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableIterable**](https://msdn.microsoft.com/library/windows/apps/Hh701957)、[**IVector**](https://msdn.microsoft.com/library/windows/apps/BR206631)&lt;[**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)^&gt;、[**IIterable**](https://msdn.microsoft.com/library/windows/apps/BR226024)&lt;**Object**^&gt;、**IVector**&lt;[**IInspectable**](https://msdn.microsoft.com/library/BR205821)\*&gt;、または **IIterable**&lt;**IInspectable**\*&gt; を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-205">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979), [**IBindableIterable**](https://msdn.microsoft.com/library/windows/apps/Hh701957), [**IVector**](https://msdn.microsoft.com/library/windows/apps/BR206631)&lt;[**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)^&gt;, [**IIterable**](https://msdn.microsoft.com/library/windows/apps/BR226024)&lt;**Object**^&gt;, **IVector**&lt;[**IInspectable**](https://msdn.microsoft.com/library/BR205821)\*&gt;, or **IIterable**&lt;**IInspectable**\*&gt;.</span></span> <span data-ttu-id="1a625-206">汎用の **IVector&lt;T&gt;** と **IIterable&lt;T&gt;** へのバインドはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="1a625-206">Binding to generic **IVector&lt;T&gt;** and **IIterable&lt;T&gt;** is not supported.</span></span>|
| <span data-ttu-id="1a625-207">コレクション変更通知をサポートするコレクションを実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-207">Implement a collection that supports collection change notifications.</span></span> | <span data-ttu-id="1a625-208">[**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-208">Extend [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) or implement (non-generic) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx).</span></span>|<span data-ttu-id="1a625-209">[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector) [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-209">Implement [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span>|<span data-ttu-id="1a625-210">[**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979) と [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-210">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979) and [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974).</span></span>|
|<span data-ttu-id="1a625-211">段階的読み込みをサポートするコレクションを実装する。</span><span class="sxs-lookup"><span data-stu-id="1a625-211">Implement a collection that supports incremental loading.</span></span>|<span data-ttu-id="1a625-212">[**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-212">Extend [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) or implement (non-generic) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx).</span></span> <span data-ttu-id="1a625-213">さらに、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-213">Additionally, implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916).</span></span>|<span data-ttu-id="1a625-214">[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector) [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_)を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-214">Implement [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span> <span data-ttu-id="1a625-215">さらに、 [ **ISupportIncrementalLoading**を実装します。](https://msdn.microsoft.com/library/windows/apps/Hh701916)</span><span class="sxs-lookup"><span data-stu-id="1a625-215">Additionally, implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916)</span></span>|<span data-ttu-id="1a625-216">[**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974)、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-216">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979), [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974), and [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916).</span></span>|

<span data-ttu-id="1a625-217">段階的読み込みを使うと、任意の大きさのデータ ソースにリスト コントロールをバインドすると同時に、高パフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-217">You can bind list controls to arbitrarily large data sources, and still achieve high performance, by using incremental loading.</span></span> <span data-ttu-id="1a625-218">たとえば、一度にすべての結果を読む込むことなく、Bing の画像クエリ結果にリスト コントロールをバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-218">For example, you can bind list controls to Bing image query results without having to load all the results at once.</span></span> <span data-ttu-id="1a625-219">この場合、すぐに読み込むのは一部の結果だけで、他の結果は必要に応じて読み込みます。</span><span class="sxs-lookup"><span data-stu-id="1a625-219">Instead, you load only some results immediately, and load additional results as needed.</span></span> <span data-ttu-id="1a625-220">段階的読み込みをサポートするために、データ ソース コレクション変更通知をサポートしている[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916)を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-220">To support incremental loading, you must implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) on a data source that supports collection change notifications.</span></span> <span data-ttu-id="1a625-221">データ バインディング エンジンがより多くのデータを要求する場合は、UI を更新するためにデータ ソースで適切な要求を行い、結果を統合して、適切な通知を送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-221">When the data binding engine requests more data, your data source must make the appropriate requests, integrate the results, and then send the appropriate notifications in order to update the UI.</span></span>

### <a name="binding-target"></a><span data-ttu-id="1a625-222">バインディング ターゲット</span><span class="sxs-lookup"><span data-stu-id="1a625-222">Binding target</span></span>

<span data-ttu-id="1a625-223">以下 2 つの例で**Button.Content**プロパティは、バインディング ターゲットとその値は、バインディング オブジェクトを宣言するマークアップ拡張に設定されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-223">In the two examples below, the **Button.Content** property is the binding target, and its value is set to a markup extension that declares the binding object.</span></span> <span data-ttu-id="1a625-224">最初に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) を示し、次に [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-224">First [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) is shown, and then [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span> <span data-ttu-id="1a625-225">マークアップでバインディングを宣言する方法は一般的です (便利で、読みやすく、ツールで処理できます)。</span><span class="sxs-lookup"><span data-stu-id="1a625-225">Declaring bindings in markup is the common case (it's convenient, readable, and toolable).</span></span> <span data-ttu-id="1a625-226">ただし、必要な場合は、マークアップを使わずに、命令を使って (プログラムで) [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスのインスタンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-226">But you can avoid markup and imperatively (programmatically) create an instance of the [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) class instead if you need to.</span></span>

```xaml
<Button Content="{x:Bind ...}" ... />
```

```xaml
<Button Content="{Binding ...}" ... />
```

<span data-ttu-id="1a625-227">使用する場合、C++/WinRT または VisualC ではコンポーネント拡張機能 (、C++/cli CX)、 [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性を使って[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張を使用する任意のランタイム クラスに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-227">If you're using C++/WinRT or VisualC++ component extensions (C++/CX), then you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to any runtime class that you want to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension with.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1a625-228">使用している場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールした場合に利用可能なまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="1a625-228">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute is available if you've installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later.</span></span> <span data-ttu-id="1a625-229">その属性がない場合は、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用する[ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-229">Without that attribute, you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces in order to be able to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

### <a name="binding-object-declared-using-xbind"></a><span data-ttu-id="1a625-230">{x:Bind} を使って宣言されたバインディング オブジェクト</span><span class="sxs-lookup"><span data-stu-id="1a625-230">Binding object declared using {x:Bind}</span></span>

<span data-ttu-id="1a625-231">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) マークアップを作成する前に必要な手順が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="1a625-231">There's one step we need to do before we author our [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) markup.</span></span> <span data-ttu-id="1a625-232">マークアップのページを表すクラスからバインディング ソース クラスを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-232">We need to expose our binding source class from the class that represents our page of markup.</span></span> <span data-ttu-id="1a625-233">そのためには、 **MainPage**ページ クラスに (ここでは**HostViewModel**の種類) のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="1a625-233">We do that by adding a property (of type **HostViewModel** in this case) to our **MainPage** page class.</span></span>

```csharp
namespace DataBindingInDepth
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new HostViewModel();
        }
    
        public HostViewModel ViewModel { get; set; }
    }
}
```

```cppwinrt
// MainPage.idl
import "HostViewModel.idl";

namespace DataBindingInDepth
{
    runtimeclass MainPage : Windows.UI.Xaml.Controls.Page
    {
        MainPage();
        HostViewModel ViewModel{ get; };
    }
}

// MainPage.h
// Include a header, and add this field:
...
#include "HostViewModel.h"
...
    DataBindingInDepth::HostViewModel ViewModel();

private:
    DataBindingInDepth::HostViewModel m_viewModel{ nullptr };
...

// MainPage.cpp
// Implement like this:
...
MainPage::MainPage()
{
    InitializeComponent();

}

DataBindingInDepth::HostViewModel MainPage::ViewModel()
{
    return m_viewModel;
}
...
```

<span data-ttu-id="1a625-234">これが完了したら、バインディング オブジェクトを宣言するマークアップを詳しく見ていくことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-234">That done, we can now take a closer look at the markup that declares the binding object.</span></span> <span data-ttu-id="1a625-235">次の例では、前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使って、**HostViewModel.NextButtonText** プロパティにバインドされたバインディング ターゲットを示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-235">The example below uses the same **Button.Content** binding target we used in the "Binding target" section earlier, and shows it being bound to the **HostViewModel.NextButtonText** property.</span></span>

```xaml
<!-- MainPage.xaml -->
<Page x:Class="DataBindingInDepth.Mainpage" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

<span data-ttu-id="1a625-236">**Path** として指定している値に注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-236">Notice the value that we specify for **Path**.</span></span> <span data-ttu-id="1a625-237">この値はページ自体のコンテキストで解釈パスは、ここでは、 **MainPage**ページに追加した**ViewModel**プロパティを参照しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-237">This value is interpreted in the context of the page itself, and in this case the path begins by referencing the **ViewModel** property that we just added to the **MainPage** page.</span></span> <span data-ttu-id="1a625-238">このプロパティは **HostViewModel** インスタンスを返すため、そのオブジェクトにドットを付けて **HostViewModel.NextButtonText** プロパティにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-238">That property returns a **HostViewModel** instance, and so we can dot into that object to access the **HostViewModel.NextButtonText** property.</span></span> <span data-ttu-id="1a625-239">さらに、**Mode** を指定して、[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) の既定値である 1 回限りのバインディングをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-239">And we specify **Mode**, to override the [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) default of one-time.</span></span>

<span data-ttu-id="1a625-240">[**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1a625-240">The [**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) property supports a variety of syntax options for binding to nested properties, attached properties, and integer and string indexers.</span></span> <span data-ttu-id="1a625-241">詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-241">For more info, see [Property-path syntax](https://msdn.microsoft.com/library/windows/apps/Mt185586).</span></span> <span data-ttu-id="1a625-242">文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。</span><span class="sxs-lookup"><span data-stu-id="1a625-242">Binding to string indexers gives you the effect of binding to dynamic properties without having to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span> <span data-ttu-id="1a625-243">その他の設定については、「[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-243">For other settings, see [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783).</span></span>

<span data-ttu-id="1a625-244">**HostViewModel.NextButtonText**プロパティが実際に監視可能なことを示すためには、ボタン**クリックして**イベント ハンドラーを追加し、 **HostViewModel.NextButtonText**の値を更新します。</span><span class="sxs-lookup"><span data-stu-id="1a625-244">To illustrate that the **HostViewModel.NextButtonText** property is indeed observable, add a **Click** event handler to the button, and update the value of **HostViewModel.NextButtonText**.</span></span> <span data-ttu-id="1a625-245">ビルド、実行、および更新ボタンの**コンテンツ**の値を表示するボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="1a625-245">Build, run, and click the button to see the value of the button's **Content** update.</span></span>

```csharp
// MainPage.xaml.cs
private void Button_Click(object sender, RoutedEventArgs e)
{
    this.ViewModel.NextButtonText = "Updated Next button text";
}
```

```cppwinrt
// MainPage.cpp
void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
{
    ViewModel().NextButtonText(L"Updated Next button text");
}
```

> [!NOTE]
> <span data-ttu-id="1a625-246">[**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)への変更は、双方向のバインド ソース[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)は、フォーカスを失ったときに、およびユーザーのキーストロークのたびに送信されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-246">Changes to [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text) are sent to a two-way bound source when the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) loses focus, and not after every user keystroke.</span></span>

**<span data-ttu-id="1a625-247">DataTemplate と x:DataType</span><span class="sxs-lookup"><span data-stu-id="1a625-247">DataTemplate and x:DataType</span></span>**

<span data-ttu-id="1a625-248">[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内で (項目テンプレート、コンテンツ テンプレート、ヘッダー テンプレートのいずれとして使用される場合でも)、**Path** の値はページのコンテキストではなく、テンプレート化されたデータ オブジェクトのコンテキストで解釈されています。</span><span class="sxs-lookup"><span data-stu-id="1a625-248">Inside a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) (whether used as an item template, a content template, or a header template), the value of **Path** is not interpreted in the context of the page, but in the context of the data object being templated.</span></span> <span data-ttu-id="1a625-249">{x:Bind} をデータ テンプレートで使用する場合、コンパイル時にバインディングを検証できるように (バインディング用に効率的なコードを生成できるように) するために、**DataTemplate** では、**x:DataType** を使って、データ オブジェクトの型を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-249">When using {x:Bind} in a data template, so that its bindings can be validated (and efficient code generated for them) at compile-time, the **DataTemplate** needs to declare the type of its data object using **x:DataType**.</span></span> <span data-ttu-id="1a625-250">次に示す例は、**SampleDataGroup** オブジェクトのコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-250">The example given below could be used as the **ItemTemplate** of an items control bound to a collection of **SampleDataGroup** objects.</span></span>

```xaml
<DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```

**<span data-ttu-id="1a625-251">Path 内の厳密に型指定されていないオブジェクト</span><span class="sxs-lookup"><span data-stu-id="1a625-251">Weakly-typed objects in your Path</span></span>**

<span data-ttu-id="1a625-252">たとえば、SampleDataGroup という名前の型があり、Title という名前の文字列プロパティを実装しているとします。</span><span class="sxs-lookup"><span data-stu-id="1a625-252">Consider for example that you have a type named SampleDataGroup, which implements a string property named Title.</span></span> <span data-ttu-id="1a625-253">使用して、MainPage.SampleDataGroupAsObject プロパティ プロパティの型のオブジェクトは実際には SampleDataGroup のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="1a625-253">And you have a property MainPage.SampleDataGroupAsObject, which is of type object, but which actually returns an instance of SampleDataGroup.</span></span> <span data-ttu-id="1a625-254">バインディング `<TextBlock Text="{x:Bind SampleDataGroupAsObject.Title}"/>` は、型オブジェクトで Title プロパティが見つからないため、コンパイル エラーとなります。</span><span class="sxs-lookup"><span data-stu-id="1a625-254">The binding `<TextBlock Text="{x:Bind SampleDataGroupAsObject.Title}"/>` will result in a compile error because the Title property is not found on the type object.</span></span> <span data-ttu-id="1a625-255">これを解決するには、Path 構文に `<TextBlock Text="{x:Bind ((data:SampleDataGroup)SampleDataGroupAsObject).Title}"/>` などのキャストを追加します。</span><span class="sxs-lookup"><span data-stu-id="1a625-255">The remedy for this is to add a cast to your Path syntax like this: `<TextBlock Text="{x:Bind ((data:SampleDataGroup)SampleDataGroupAsObject).Title}"/>`.</span></span> <span data-ttu-id="1a625-256">Element がオブジェクトとして宣言されているが、実際には TextBlock である、`<TextBlock Text="{x:Bind Element.Text}"/>` という例を考えてみます。</span><span class="sxs-lookup"><span data-stu-id="1a625-256">Here's another example where Element is declared as object but is actually a TextBlock: `<TextBlock Text="{x:Bind Element.Text}"/>`.</span></span> <span data-ttu-id="1a625-257">この場合も、`<TextBlock Text="{x:Bind ((TextBlock)Element).Text}"/>` のようにキャストによって問題が解決されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-257">And a cast remedies the issue: `<TextBlock Text="{x:Bind ((TextBlock)Element).Text}"/>`.</span></span>

**<span data-ttu-id="1a625-258">データを非同期的に読み込む場合</span><span class="sxs-lookup"><span data-stu-id="1a625-258">If your data loads asynchronously</span></span>**

<span data-ttu-id="1a625-259">ページの部分クラスに、**{x:Bind}** をサポートするコードがコンパイル時に生成されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-259">Code to support **{x:Bind}** is generated at compile-time in the partial classes for your pages.</span></span> <span data-ttu-id="1a625-260">これらのファイルは `obj` フォルダー内にあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="1a625-260">These files can be found in your `obj` folder, with names like (for C#) `<view name>.g.cs`.</span></span> <span data-ttu-id="1a625-261">生成されたコードには、ページの [**Loading**](https://msdn.microsoft.com/library/windows/apps/BR208706) イベントのハンドラーが含まれており、このハンドラーが、ページのバインディングを表す生成されたクラスで **Initialize** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1a625-261">The generated code includes a handler for your page's [**Loading**](https://msdn.microsoft.com/library/windows/apps/BR208706) event, and that handler calls the **Initialize** method on a generated class that represent's your page's bindings.</span></span> <span data-ttu-id="1a625-262">次に、**Initialize** が **Update** を呼び出して、バインディング ソースとターゲットの間のデータの移動を開始します。</span><span class="sxs-lookup"><span data-stu-id="1a625-262">**Initialize** in turn calls **Update** to begin moving data between the binding source and the target.</span></span> <span data-ttu-id="1a625-263">**Loading** は、ページまたはユーザー コントロールの最初の測定パスの直前に発生します。</span><span class="sxs-lookup"><span data-stu-id="1a625-263">**Loading** is raised just before the first measure pass of the page or user control.</span></span> <span data-ttu-id="1a625-264">したがって、データが非同期的に読み込まれる場合、**Initialize** が呼び出された時点で準備ができていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-264">So if your data is loaded asynchronously it may not be ready by the time **Initialize** is called.</span></span> <span data-ttu-id="1a625-265">そのため、データを読み込んだ後、`this.Bindings.Update();` を呼び出すことによって、1 回限りのバインディングを強制的に実行できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-265">So, after you've loaded data, you can force one-time bindings to be initialized by calling `this.Bindings.Update();`.</span></span> <span data-ttu-id="1a625-266">非同期的に読み込まれたデータに 1 回限りのバインディングがのみ必要な場合は、初期化にこの方法は、一方向のバインドがあると、変更をリッスンするよりもはるかにコストも抑えられます。</span><span class="sxs-lookup"><span data-stu-id="1a625-266">If you only need one-time bindings for asynchronously-loaded data then it's much cheaper to initialize them this way than it is to have one-way bindings and to listen for changes.</span></span> <span data-ttu-id="1a625-267">データがきめ細かく変更されない場合や、特定のアクションの一部として更新される可能性が高い場合は、バインディングを 1 回限りにし、いつでも **Update** を呼び出すことによって、強制的に手動更新を実行できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-267">If your data does not undergo fine-grained changes, and if it's likely to be updated as part of a specific action, then you can make your bindings one-time, and force a manual update at any time with a call to **Update**.</span></span>

> [!NOTE]
> <span data-ttu-id="1a625-268">**{X:bind}** は、JSON オブジェクトの場合でもあるダック タイピングのディクショナリ構造の移動などの遅延バインディングのシナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-268">**{x:Bind}** is not suited to late-bound scenarios, such as navigating the dictionary structure of a JSON object, nor duck typing.</span></span> <span data-ttu-id="1a625-269">「あるダック タイピング」は脆弱な形式の構文の一致にプロパティ名に基づく入力 (、「場合走査、泳ぎ、および、鳴くようはアヒル」)。</span><span class="sxs-lookup"><span data-stu-id="1a625-269">"Duck typing" is a weak form of typing based on lexical matches on property names (a in, "if it walks, swims, and quacks like a duck, then it's a duck").</span></span> <span data-ttu-id="1a625-270">ダック タイピング、 **Age**プロパティへのバインドを**ユーザー**に均等に満足はまたは**ワイン**オブジェクト (できたことをそれらの型は各には、 **Age**プロパティが必要がある)。</span><span class="sxs-lookup"><span data-stu-id="1a625-270">With duck typing, a binding to the **Age** property would be equally satisfied with a **Person** or a **Wine** object (assuming that those types each had an **Age** property).</span></span> <span data-ttu-id="1a625-271">これらのシナリオでは、 **{Binding}** マークアップ拡張機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="1a625-271">For these scenarios, use the **{Binding}** markup extension.</span></span>

### <a name="binding-object-declared-using-binding"></a><span data-ttu-id="1a625-272">{Binding} を使って宣言されたバインディング オブジェクト</span><span class="sxs-lookup"><span data-stu-id="1a625-272">Binding object declared using {Binding}</span></span>

<span data-ttu-id="1a625-273">使用する場合、C++/WinRT または VisualC ではコンポーネント拡張機能 (、C++/cli CX) し、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用する必要がありますにバインドする任意のランタイム クラスを[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="1a625-273">If you're using C++/WinRT or VisualC++ component extensions (C++/CX) then, to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension, you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to any runtime class that you want to bind to.</span></span> <span data-ttu-id="1a625-274">[{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用するには、その属性を必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-274">To use [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783), you don't need that attribute.</span></span>

```cppwinrt
// HostViewModel.idl
// Add this attribute:
[Windows.UI.Xaml.Data.Bindable]
runtimeclass HostViewModel : Windows.UI.Xaml.Data.INotifyPropertyChanged
...
```

> [!IMPORTANT]
> <span data-ttu-id="1a625-275">使用している場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールした場合に利用可能なまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="1a625-275">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute is available if you've installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later.</span></span> <span data-ttu-id="1a625-276">その属性がない場合は、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用する[ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-276">Without that attribute, you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces in order to be able to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

<span data-ttu-id="1a625-277">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) は、既定で、マークアップ ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) にバインドしていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="1a625-277">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) assumes, by default, that you're binding to the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) of your markup page.</span></span> <span data-ttu-id="1a625-278">したがって、ページの **DataContext** を、バインディング ソース クラス (ここでは **HostViewModel** 型) のインスタンスに設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-278">So we'll set the **DataContext** of our page to be an instance of our binding source class (of type **HostViewModel** in this case).</span></span> <span data-ttu-id="1a625-279">次の例は、バインディング オブジェクトを宣言するマークアップを示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-279">The example below shows the markup that declares the binding object.</span></span> <span data-ttu-id="1a625-280">前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使っており、**HostViewModel.NextButtonText** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-280">We use the same **Button.Content** binding target we used in the "Binding target" section earlier, and we bind to the **HostViewModel.NextButtonText** property.</span></span>

```xaml
<Page xmlns:viewmodel="using:DataBindingInDepth" ... >
    <Page.DataContext>
        <viewmodel:HostViewModel x:Name="viewModelInDataContext"/>
    </Page.DataContext>
    ...
    <Button Content="{Binding Path=NextButtonText}" ... />
</Page>
```

```csharp
// MainPage.xaml.cs
private void Button_Click(object sender, RoutedEventArgs e)
{
    this.viewModelInDataContext.NextButtonText = "Updated Next button text";
}
```

```cppwinrt
// MainPage.cpp
void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
{
    viewModelInDataContext().NextButtonText(L"Updated Next button text");
}
```

<span data-ttu-id="1a625-281">**Path** として指定している値に注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-281">Notice the value that we specify for **Path**.</span></span> <span data-ttu-id="1a625-282">この値は、ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) で解釈されます。この例では、**HostViewModel** のインスタンスに設定されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-282">This value is interpreted in the context of the page's [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713), which in this example is set to an instance of **HostViewModel**.</span></span> <span data-ttu-id="1a625-283">パスは **HostViewModel.NextButtonText** プロパティを参照します。</span><span class="sxs-lookup"><span data-stu-id="1a625-283">The path references the **HostViewModel.NextButtonText** property.</span></span> <span data-ttu-id="1a625-284">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) の既定値である一方向のバインディングが適切であるため、**Mode** は省略できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-284">We can omit **Mode**, because the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) default of one-way works here.</span></span>

<span data-ttu-id="1a625-285">UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) の既定値は、その親から継承された値です。</span><span class="sxs-lookup"><span data-stu-id="1a625-285">The default value of [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) for a UI element is the inherited value of its parent.</span></span> <span data-ttu-id="1a625-286">もちろん **DataContext** を明示的に設定することによってこの既定値 (さらに既定で子に継承される) をオーバーライドすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-286">You can of course override that default by setting **DataContext** explicitly, which is in turn inherited by children by default.</span></span> <span data-ttu-id="1a625-287">要素で明示的に **DataContext** を設定することは、同じソースを使う複数のバインディングが必要な場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="1a625-287">Setting **DataContext** explicitly on an element is useful when you want to have multiple bindings that use the same source.</span></span>

<span data-ttu-id="1a625-288">バインディング オブジェクトには **Source** プロパティがあり、その既定値はバインディングが宣言されている UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) です。</span><span class="sxs-lookup"><span data-stu-id="1a625-288">A binding object has a **Source** property, which defaults to the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) of the UI element on which the binding is declared.</span></span> <span data-ttu-id="1a625-289">この既定値をオーバーライドするには、バインディングで **Source**、**RelativeSource**、または **ElementName** を明示的に設定します (詳しくは、「[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="1a625-289">You can override this default by setting **Source**, **RelativeSource**, or **ElementName** explicitly on the binding (see [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) for details).</span></span>

<span data-ttu-id="1a625-290">[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348)内で[**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713)は template 宣言されたデータ オブジェクトに自動的に設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-290">Inside a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348), the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) is automatically set to the data object being templated.</span></span> <span data-ttu-id="1a625-291">次の例は、**Title** と **Description** という名前の文字列プロパティを持つ任意の型のコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます</span><span class="sxs-lookup"><span data-stu-id="1a625-291">The example given below could be used as the **ItemTemplate** of an items control bound to a collection of any type that has string properties named **Title** and **Description**.</span></span>

```xaml
<DataTemplate x:Key="SimpleItemTemplate">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{Binding Title}"/>
      <TextBlock Text="{Binding Description"/>
    </StackPanel>
  </DataTemplate>
```

> [!NOTE]
> <span data-ttu-id="1a625-292">既定では、 [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)への変更は、 [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)がフォーカスを失ったとき双方向のバインド ソースに送信されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-292">By default, changes to [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text) are sent to a two-way bound source when the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) loses focus.</span></span> <span data-ttu-id="1a625-293">変更をユーザーの各キーストロークの後に送信するには、マークアップのバインディングで **UpdateSourceTrigger** を **PropertyChanged** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-293">To cause changes to be sent after every user keystroke, set **UpdateSourceTrigger** to **PropertyChanged** on the binding in markup.</span></span> <span data-ttu-id="1a625-294">**UpdateSourceTrigger** を **Explicit** に設定することによって、変更が送信されるタイミングを完全に制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-294">You can also completely take control of when changes are sent to the source by setting **UpdateSourceTrigger** to **Explicit**.</span></span> <span data-ttu-id="1a625-295">次に、テキスト ボックスでのイベント (通常 [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/BR209683)) を処理し、ターゲットで [**GetBindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.getbindingexpression) を呼び出して [**BindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.aspx) オブジェクトを取得します。最後に、[**BindingExpression.UpdateSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.updatesource.aspx) を呼び出して、データ ソースをプログラムで更新します。</span><span class="sxs-lookup"><span data-stu-id="1a625-295">You then handle events on the text box (typically [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/BR209683)), call [**GetBindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.getbindingexpression) on the target to get a [**BindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.aspx) object, and finally call [**BindingExpression.UpdateSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.updatesource.aspx) to programmatically update the data source.</span></span>

<span data-ttu-id="1a625-296">[**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1a625-296">The [**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) property supports a variety of syntax options for binding to nested properties, attached properties, and integer and string indexers.</span></span> <span data-ttu-id="1a625-297">詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-297">For more info, see [Property-path syntax](https://msdn.microsoft.com/library/windows/apps/Mt185586).</span></span> <span data-ttu-id="1a625-298">文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。</span><span class="sxs-lookup"><span data-stu-id="1a625-298">Binding to string indexers gives you the effect of binding to dynamic properties without having to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span> <span data-ttu-id="1a625-299">[**ElementName**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.elementname) プロパティは要素間のバインディングに便利です。</span><span class="sxs-lookup"><span data-stu-id="1a625-299">The [**ElementName**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.elementname) property is useful for element-to-element binding.</span></span> <span data-ttu-id="1a625-300">[**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.relativesource) プロパティにはいくつかの用途があり、そのうちの 1 つが、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209391) 内でバインディングをテンプレート化するためのより強力な方法としての用途です。</span><span class="sxs-lookup"><span data-stu-id="1a625-300">The [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.relativesource) property has several uses, one of which is as a more powerful alternative to template binding inside a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209391).</span></span> <span data-ttu-id="1a625-301">その他の設定については、「[{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)」と [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスの説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-301">For other settings, see [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782) and the [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) class.</span></span>

## <a name="what-if-the-source-and-the-target-are-not-the-same-type"></a><span data-ttu-id="1a625-302">ソースとターゲットが同じ型ではない場合</span><span class="sxs-lookup"><span data-stu-id="1a625-302">What if the source and the target are not the same type?</span></span>

<span data-ttu-id="1a625-303">ブール型プロパティの値に基づいて UI 要素の表示を制御する場合、数値の範囲や傾向に応じた色で UI 要素をレンダリングする場合、または文字列を想定している UI 要素のプロパティに日付や時刻の値を表示する場合は、値の型を別の型に変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-303">If you want to control the visibility of a UI element based on the value of a boolean property, or if you want to render a UI element with a color that's a function of a numeric value's range or trend, or if you want to display a date and/or time value in a UI element property that expects a string, then you'll need to convert values from one type to another.</span></span> <span data-ttu-id="1a625-304">バインディング ソース クラスから適切な型の別のプロパティを公開し、変換ロジックをカプセル化し、その中でテストできるようにしておくことが、適切なソリューションである場合があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-304">There will be cases where the right solution is to expose another property of the right type from your binding source class, and keep the conversion logic encapsulated and testable there.</span></span> <span data-ttu-id="1a625-305">ただし、この方法はソースとターゲットのプロパティの数が多くなり、組み合わせが多くなると、柔軟性も拡張性もありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-305">But that isn't flexible nor scalable when you have large numbers, or large combinations, of source and target properties.</span></span> <span data-ttu-id="1a625-306">その場合は、いくつかのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1a625-306">In that case you have a couple of options:</span></span>

* <span data-ttu-id="1a625-307">{X:Bind} を使用している場合、関数に直接バインドして変換を行うことができます</span><span class="sxs-lookup"><span data-stu-id="1a625-307">If using {x:Bind} then you can bind directly to a function to do that conversion</span></span>
* <span data-ttu-id="1a625-308">または、変換を実行するためのオブジェクトである、値コンバーターを指定することができます</span><span class="sxs-lookup"><span data-stu-id="1a625-308">Or you can specify a value converter which is an object designed to perform the conversion</span></span> 

## <a name="value-converters"></a><span data-ttu-id="1a625-309">値コンバーター</span><span class="sxs-lookup"><span data-stu-id="1a625-309">Value Converters</span></span>

<span data-ttu-id="1a625-310">[**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) 値を月を含む文字列値に変換する、1 回限りまたは一方向のバインディングに適した値コンバーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-310">Here's a value converter, suitable for a one-time or a one-way binding, that converts a [**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) value to a string value containing the month.</span></span> <span data-ttu-id="1a625-311">このクラスは、[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903) を実装します。</span><span class="sxs-lookup"><span data-stu-id="1a625-311">The class implements [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903).</span></span>

```csharp
public class DateToStringConverter : IValueConverter
{
    // Define the Convert method to convert a DateTime value to 
    // a month string.
    public object Convert(object value, Type targetType, 
        object parameter, string language)
    {
        // value is the data from the source object.
        DateTime thisdate = (DateTime)value;
        int monthnum = thisdate.Month;
        string month;
        switch (monthnum)
        {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            default:
                month = "Month not found";
                break;
        }
        // Return the value to pass to the target.
        return month;
    }

    // ConvertBack is not implemented for a OneWay binding.
    public object ConvertBack(object value, Type targetType, 
        object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
```

```cppwinrt
// See the "Formatting or converting data values for display" section in the "Data binding overview" topic.
```

<span data-ttu-id="1a625-312">次に、バインディング オブジェクトのマークアップでその値コンバーターを利用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-312">And here's how you consume that value converter in your binding object markup.</span></span>

```xaml
<UserControl.Resources>
  <local:DateToStringConverter x:Key="Converter1"/>
</UserControl.Resources>
...
<TextBlock Grid.Column="0" 
  Text="{x:Bind ViewModel.Month, Converter={StaticResource Converter1}}"/>
<TextBlock Grid.Column="0" 
  Text="{Binding Month, Converter={StaticResource Converter1}}"/>
```

<span data-ttu-id="1a625-313">バインドの [**Converter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converter) パラメーターを定義した場合、[**Convert**](https://msdn.microsoft.com/library/windows/apps/hh701934) メソッドと [**ConvertBack**](https://msdn.microsoft.com/library/windows/apps/hh701938) メソッドがバインド エンジンによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-313">The binding engine calls the [**Convert**](https://msdn.microsoft.com/library/windows/apps/hh701934) and [**ConvertBack**](https://msdn.microsoft.com/library/windows/apps/hh701938) methods if the [**Converter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converter) parameter is defined for the binding.</span></span> <span data-ttu-id="1a625-314">ソースからデータが渡されると、バインド エンジンは、**Convert** を呼び出し、返すデータをターゲットに渡します。</span><span class="sxs-lookup"><span data-stu-id="1a625-314">When data is passed from the source, the binding engine calls **Convert** and passes the returned data to the target.</span></span> <span data-ttu-id="1a625-315">ターゲットからデータが渡されると (双方向バインディングの場合)、バインド エンジンは、**ConvertBack** を呼び出し、返すデータをソースに渡します。</span><span class="sxs-lookup"><span data-stu-id="1a625-315">When data is passed from the target (for a two-way binding), the binding engine calls **ConvertBack** and passes the returned data to the source.</span></span>

<span data-ttu-id="1a625-316">コンバーターには省略可能なパラメーターもあります。変換で使う言語を指定できる [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterlanguage)、および変換ロジックに渡すパラメーターを指定できる [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterparameter) です。</span><span class="sxs-lookup"><span data-stu-id="1a625-316">The converter also has optional parameters: [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterlanguage), which allows specifying the language to be used in the conversion, and [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterparameter), which allows passing a parameter for the conversion logic.</span></span> <span data-ttu-id="1a625-317">コンバーター パラメーターの使用例については、「[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-317">For an example that uses a converter parameter, see [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903).</span></span>

> [!NOTE]
> <span data-ttu-id="1a625-318">変換でエラーがある場合は、例外をスローしません。</span><span class="sxs-lookup"><span data-stu-id="1a625-318">If there is an error in the conversion, do not throw an exception.</span></span> <span data-ttu-id="1a625-319">代わりに [**DependencyProperty.UnsetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyproperty.unsetvalue) を返します。これにより、データ転送が中止されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-319">Instead, return [**DependencyProperty.UnsetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyproperty.unsetvalue), which will stop the data transfer.</span></span>

<span data-ttu-id="1a625-320">バインディング ソースを解決できない場合に使用する既定値を表示するには、マークアップのバインディング オブジェクトで **FallbackValue** プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-320">To display a default value to use whenever the binding source cannot be resolved, set the **FallbackValue** property on the binding object in markup.</span></span> <span data-ttu-id="1a625-321">これは、変換エラーや書式エラーを処理する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="1a625-321">This is useful to handle conversion and formatting errors.</span></span> <span data-ttu-id="1a625-322">また、バインド時にソースのプロパティが、型が混在するバインド先のコレクションのどのオブジェクトにも見つからないときにも便利です。</span><span class="sxs-lookup"><span data-stu-id="1a625-322">It is also useful to bind to source properties that might not exist on all objects in a bound collection of heterogeneous types.</span></span>

<span data-ttu-id="1a625-323">テキスト コントロールを文字列でない値にバインドした場合、データ バインディング エンジンは値を文字列に変換します。</span><span class="sxs-lookup"><span data-stu-id="1a625-323">If you bind a text control to a value that is not a string, the data binding engine will convert the value to a string.</span></span> <span data-ttu-id="1a625-324">値が参照型である場合、データ バインディング エンジンは [**ICustomPropertyProvider.GetStringRepresentation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.icustompropertyprovider.getstringrepresentation) または [**IStringable.ToString**](https://msdn.microsoft.com/library/Dn302136) を呼び出すことで文字列の値を取得します。取得できない場合は、[**Object.ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1a625-324">If the value is a reference type, the data binding engine will retrieve the string value by calling [**ICustomPropertyProvider.GetStringRepresentation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.icustompropertyprovider.getstringrepresentation) or [**IStringable.ToString**](https://msdn.microsoft.com/library/Dn302136) if available, and will otherwise call [**Object.ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx).</span></span> <span data-ttu-id="1a625-325">ただし、データ バインディング エンジンは基底クラスの実装を隠ぺいする **ToString** の実装を無視することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-325">Note, however, that the binding engine will ignore any **ToString** implementation that hides the base-class implementation.</span></span> <span data-ttu-id="1a625-326">代わりに、サブクラスの実装で基底クラスの **ToString** メソッドをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-326">Subclass implementations should override the base class **ToString** method instead.</span></span> <span data-ttu-id="1a625-327">同様に、ネイティブ言語では、すべてのマネージ オブジェクトが [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) と [**IStringable**](https://msdn.microsoft.com/library/Dn302135) を実装しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="1a625-327">Similarly, in native languages, all managed objects appear to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) and [**IStringable**](https://msdn.microsoft.com/library/Dn302135).</span></span> <span data-ttu-id="1a625-328">ただし、**GetStringRepresentation** と **IStringable.ToString** のすべての呼び出しは、**Object.ToString** またはそのオーバーライドされたメソッドに割り振られます。基底クラスの実装を隠ぺいする新しい **ToString** メソッドの実装に割り振られることはありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-328">However, all calls to **GetStringRepresentation** and **IStringable.ToString** are routed to **Object.ToString** or an override of that method, and never to a new **ToString** implementation that hides the base-class implementation.</span></span>

> [!NOTE]
> <span data-ttu-id="1a625-329">Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="1a625-329">Starting in Windows 10, version 1607, the XAML framework provides a built in boolean to Visibility converter.</span></span> <span data-ttu-id="1a625-330">コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-330">The converter maps **true** to the **Visible** enumeration value and **false** to **Collapsed** so you can bind a Visibility property to a boolean without creating a converter.</span></span> <span data-ttu-id="1a625-331">組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-331">To use the built in converter, your app's minimum target SDK version must be 14393 or later.</span></span> <span data-ttu-id="1a625-332">アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。</span><span class="sxs-lookup"><span data-stu-id="1a625-332">You can't use it when your app targets earlier versions of Windows 10.</span></span> <span data-ttu-id="1a625-333">ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-333">For more info about target versions, see [Version adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

## <a name="function-binding-in-xbind"></a><span data-ttu-id="1a625-334">{X:Bind} の関数バインド</span><span class="sxs-lookup"><span data-stu-id="1a625-334">Function binding in {x:Bind}</span></span>

<span data-ttu-id="1a625-335">{x:Bind} は関数となるバインディング パスの最終ステップを有効化します。</span><span class="sxs-lookup"><span data-stu-id="1a625-335">{x:Bind} enables the final step in a binding path to be a function.</span></span> <span data-ttu-id="1a625-336">これを使って変換を実行できます。また 1 つ以上のプロパティに依存するバインディングを実行できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-336">This can be used to perform conversions, and to perform bindings that depend on more than one property.</span></span> <span data-ttu-id="1a625-337">[ **X:bind で関数**を参照してください。](function-bindings.md)</span><span class="sxs-lookup"><span data-stu-id="1a625-337">See [**Functions in x:Bind**](function-bindings.md)</span></span>

<span id="resource-dictionaries-with-x-bind"/>

## <a name="resource-dictionaries-with-xbind"></a><span data-ttu-id="1a625-338">リソース ディクショナリと {x:Bind}</span><span class="sxs-lookup"><span data-stu-id="1a625-338">Resource dictionaries with {x:Bind}</span></span>

<span data-ttu-id="1a625-339">[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)はコードの生成に依存するため、**InitializeComponent** (生成されたコードを初期化する) を呼び出すコンストラクターを含むコード ビハインド ファイルが必要です。</span><span class="sxs-lookup"><span data-stu-id="1a625-339">The [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783) depends on code generation, so it needs a code-behind file containing a constructor that calls **InitializeComponent** (to initialize the generated code).</span></span> <span data-ttu-id="1a625-340">ファイル名を参照する代わりに、その型をインスタンス化する (**InitializeComponent** が呼び出される) ことによって、リソース ファイルを再利用します。</span><span class="sxs-lookup"><span data-stu-id="1a625-340">You re-use the resource dictionary by instantiating its type (so that **InitializeComponent** is called) instead of referencing its filename.</span></span> <span data-ttu-id="1a625-341">次の例では、既存のリソース ディクショナリがあり、その中で {x:Bind} を使う場合の対処方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-341">Here's an example of what to do if you have an existing resource dictionary and you want to use {x:Bind} in it.</span></span>

<span data-ttu-id="1a625-342">TemplatesResourceDictionary.xaml</span><span class="sxs-lookup"><span data-stu-id="1a625-342">TemplatesResourceDictionary.xaml</span></span>

```xaml
<ResourceDictionary
    x:Class="ExampleNamespace.TemplatesResourceDictionary"
    .....
    xmlns:examplenamespace="using:ExampleNamespace">
    
    <DataTemplate x:Key="EmployeeTemplate" x:DataType="examplenamespace:IEmployee">
        <Grid>
            <TextBlock Text="{x:Bind Name}"/>
        </Grid>
    </DataTemplate>
</ResourceDictionary>
```

<span data-ttu-id="1a625-343">TemplatesResourceDictionary.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="1a625-343">TemplatesResourceDictionary.xaml.cs</span></span>

```csharp
using Windows.UI.Xaml.Data;
 
namespace ExampleNamespace
{
    public partial class TemplatesResourceDictionary
    {
        public TemplatesResourceDictionary()
        {
            InitializeComponent();
        }
    }
}
```

<span data-ttu-id="1a625-344">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="1a625-344">MainPage.xaml</span></span>

```xaml
<Page x:Class="ExampleNamespace.MainPage"
    ....
    xmlns:examplenamespace="using:ExampleNamespace">

    <Page.Resources>
        <ResourceDictionary>
            .... 
            <ResourceDictionary.MergedDictionaries>
                <examplenamespace:TemplatesResourceDictionary/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>
</Page>
```

## <a name="event-binding-and-icommand"></a><span data-ttu-id="1a625-345">イベント バインディングと ICommand</span><span class="sxs-lookup"><span data-stu-id="1a625-345">Event binding and ICommand</span></span>

<span data-ttu-id="1a625-346">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) はイベント バインディングと呼ばれる機能をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1a625-346">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) supports a feature called event binding.</span></span> <span data-ttu-id="1a625-347">この機能によって、バインディングを使用するイベントのハンドラーを指定できます。これは、コード ビハインド ファイルのメソッドによるイベント処理に対する追加のオプションです。</span><span class="sxs-lookup"><span data-stu-id="1a625-347">With this feature, you can specify the handler for an event using a binding, which is an additional option on top of handling events with a method on the code-behind file.</span></span> <span data-ttu-id="1a625-348">たとえば、**MainPage** クラスに **RootFrame** プロパティがあるとします。</span><span class="sxs-lookup"><span data-stu-id="1a625-348">Let's say you have a **RootFrame** property on your **MainPage** class.</span></span>

```csharp
public sealed partial class MainPage : Page
{
    ...
    public Frame RootFrame { get { return Window.Current.Content as Frame; } }
}
```

<span data-ttu-id="1a625-349">次のように、**RootFrame** プロパティによって返される **Frame** オブジェクトのメソッドに、ボタンの **Click** イベントをバインドできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-349">You can then bind a button's **Click** event to a method on the **Frame** object returned by the **RootFrame** property like this.</span></span> <span data-ttu-id="1a625-350">また、ボタンの **IsEnabled** プロパティを、同じ **Frame** の別のメンバーにもバインドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-350">Note that we also bind the button's **IsEnabled** property to another member of the same **Frame**.</span></span>

```xaml
<AppBarButton Icon="Forward" IsCompact="True"
IsEnabled="{x:Bind RootFrame.CanGoForward, Mode=OneWay}"
Click="{x:Bind RootFrame.GoForward}"/>
```

<span data-ttu-id="1a625-351">この方法では、オーバーロードされたメソッドを使ってイベントを処理することはできません。</span><span class="sxs-lookup"><span data-stu-id="1a625-351">Overloaded methods cannot be used to handle an event with this technique.</span></span> <span data-ttu-id="1a625-352">また、イベントを処理するメソッドにパラメーターがある場合、すべてのパラメーターがそれぞれ、イベントのすべての型から代入できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-352">Also, if the method that handles the event has parameters then they must all be assignable from the types of all of the event's parameters, respectively.</span></span> <span data-ttu-id="1a625-353">この場合、[**Frame.GoForward**](https://msdn.microsoft.com/library/windows/apps/BR242693) はオーバーロードされておらず、パラメーターはありません (ただし、2 つの **object** パラメーターを取る場合でも有効です)。</span><span class="sxs-lookup"><span data-stu-id="1a625-353">In this case, [**Frame.GoForward**](https://msdn.microsoft.com/library/windows/apps/BR242693) is not overloaded and it has no parameters (but it would still be valid even if it took two **object** parameters).</span></span> <span data-ttu-id="1a625-354">一方、[**Frame.GoBack**](https://msdn.microsoft.com/library/windows/apps/Dn996568) はオーバーロードされているため、この手法でそのメソッドを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="1a625-354">[**Frame.GoBack**](https://msdn.microsoft.com/library/windows/apps/Dn996568) is overloaded, though, so we can't use that method with this technique.</span></span>

<span data-ttu-id="1a625-355">イベント バインディングの手法は、コマンドの実装と使用に似ています (コマンドは [**ICommand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.icommand.aspx) インターフェイスを実装するオブジェクトを返すプロパティです)。</span><span class="sxs-lookup"><span data-stu-id="1a625-355">The event binding technique is similar to implementing and consuming commands (a command is a property that returns an object that implements the [**ICommand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.icommand.aspx) interface).</span></span> <span data-ttu-id="1a625-356">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) はいずれもコマンドで動作します。</span><span class="sxs-lookup"><span data-stu-id="1a625-356">Both [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) and [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) work with commands.</span></span> <span data-ttu-id="1a625-357">コマンド パターンを何度も実装する必要はありません。[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) サンプル (Common フォルダー) に含まれている **DelegateCommand** ヘルパー クラスを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-357">So that you don't have to implement the command pattern multiple times, you can use the **DelegateCommand** helper class that you'll find in the [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) sample (in the "Common" folder).</span></span>

## <a name="binding-to-a-collection-of-folders-or-files"></a><span data-ttu-id="1a625-358">フォルダーやファイルのコレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="1a625-358">Binding to a collection of folders or files</span></span>

<span data-ttu-id="1a625-359">[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って、フォルダーとファイルのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-359">You can use the APIs in the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) namespace to retrieve folder and file data.</span></span> <span data-ttu-id="1a625-360">ただし、**GetFilesAsync** メソッド、**GetFoldersAsync** メソッド、**GetItemsAsync** メソッドは、リスト コントロールへのバインドに適した値を返さないことがあります。</span><span class="sxs-lookup"><span data-stu-id="1a625-360">However, the various **GetFilesAsync**, **GetFoldersAsync**, and **GetItemsAsync** methods do not return values that are suitable for binding to list controls.</span></span> <span data-ttu-id="1a625-361">代わりに、[**FileInformationFactory**](https://msdn.microsoft.com/library/windows/apps/BR207501) クラスの [**GetVirtualizedFilesVector**](https://msdn.microsoft.com/library/windows/apps/Hh701422) メソッド、[**GetVirtualizedFoldersVector**](https://msdn.microsoft.com/library/windows/apps/Hh701428) メソッド、[**GetVirtualizedItemsVector**](https://msdn.microsoft.com/library/windows/apps/Hh701430) メソッドの戻り値にバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-361">Instead, you must bind to the return values of the [**GetVirtualizedFilesVector**](https://msdn.microsoft.com/library/windows/apps/Hh701422), [**GetVirtualizedFoldersVector**](https://msdn.microsoft.com/library/windows/apps/Hh701428), and [**GetVirtualizedItemsVector**](https://msdn.microsoft.com/library/windows/apps/Hh701430) methods of the [**FileInformationFactory**](https://msdn.microsoft.com/library/windows/apps/BR207501) class.</span></span> <span data-ttu-id="1a625-362">[StorageDataSource と GetVirtualizedFilesVector のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=228621)から抜粋した次のコード例は、一般的な使用パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-362">The following code example from the [StorageDataSource and GetVirtualizedFilesVector sample](http://go.microsoft.com/fwlink/p/?linkid=228621) shows the typical usage pattern.</span></span> <span data-ttu-id="1a625-363">アプリ パッケージ マニフェストで **picturesLibrary** 機能を宣言し、ピクチャ ライブラリ フォルダーにピクチャがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="1a625-363">Remember to declare the **picturesLibrary** capability in your app package manifest, and confirm that there are pictures in your Pictures library folder.</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    var library = Windows.Storage.KnownFolders.PicturesLibrary;
    var queryOptions = new Windows.Storage.Search.QueryOptions();
    queryOptions.FolderDepth = Windows.Storage.Search.FolderDepth.Deep;
    queryOptions.IndexerOption = Windows.Storage.Search.IndexerOption.UseIndexerWhenAvailable;

    var fileQuery = library.CreateFileQueryWithOptions(queryOptions);

    var fif = new Windows.Storage.BulkAccess.FileInformationFactory(
        fileQuery,
        Windows.Storage.FileProperties.ThumbnailMode.PicturesView,
        190,
        Windows.Storage.FileProperties.ThumbnailOptions.UseCurrentScale,
        false
        );

    var dataSource = fif.GetVirtualizedFilesVector();
    this.PicturesListView.ItemsSource = dataSource;
}
```

<span data-ttu-id="1a625-364">通常はこの方法で、ファイルとフォルダーの情報の読み取り専用ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="1a625-364">You will typically use this approach to create a read-only view of file and folder info.</span></span> <span data-ttu-id="1a625-365">たとえば、ユーザーが音楽ビューで曲を評価できるように、ファイルとフォルダーのプロパティへの双方向のバインドを作成できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-365">You can create two-way bindings to the file and folder properties, for example to let users rate a song in a music view.</span></span> <span data-ttu-id="1a625-366">ただし、適切な **SavePropertiesAsync** メソッド ([**MusicProperties.SavePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/BR207760) など) を呼び出すまで、変更は永続化されません。</span><span class="sxs-lookup"><span data-stu-id="1a625-366">However, any changes are not persisted until you call the appropriate **SavePropertiesAsync** method (for example, [**MusicProperties.SavePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/BR207760)).</span></span> <span data-ttu-id="1a625-367">項目からフォーカスが移動したときに選択のリセットがトリガーされるため、変更をコミットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-367">You should commit changes when the item loses focus because this triggers a selection reset.</span></span>

<span data-ttu-id="1a625-368">この方法による双方向のバインドは、ミュージックなど、インデックス化された場所でのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="1a625-368">Note that two-way binding using this technique works only with indexed locations, such as Music.</span></span> <span data-ttu-id="1a625-369">ある場所がインデックス化されているかどうかを確認するには、[**FolderInformation.GetIndexedStateAsync**](https://msdn.microsoft.com/library/windows/apps/BR207627) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1a625-369">You can determine whether a location is indexed by calling the [**FolderInformation.GetIndexedStateAsync**](https://msdn.microsoft.com/library/windows/apps/BR207627) method.</span></span>

<span data-ttu-id="1a625-370">仮想化されたベクターは、一部の項目に対して、値の設定の前に **null** を返す場合があることにも注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-370">Note also that a virtualized vector can return **null** for some items before it populates their value.</span></span> <span data-ttu-id="1a625-371">たとえば、仮想化されたベクターにバインドされたリスト コントロールの [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) 値を使う前に、**null** をチェックする必要があります。または、代わりに [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/BR209768) を使います。</span><span class="sxs-lookup"><span data-stu-id="1a625-371">For example, you should check for **null** before you use the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) value of a list control bound to a virtualized vector, or use [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/BR209768) instead.</span></span>

## <a name="binding-to-data-grouped-by-a-key"></a><span data-ttu-id="1a625-372">キーでグループ化されたデータへのバインド</span><span class="sxs-lookup"><span data-stu-id="1a625-372">Binding to data grouped by a key</span></span>

<span data-ttu-id="1a625-373">(書籍、たとえば、 **BookSku**クラスで表されます) の項目のフラットなコレクションを実行すると、結果はグループ化されたデータと呼ばれる、キー ( **BookSku.AuthorName**プロパティ、たとえば) として一般的なプロパティを使用して、項目をグループ化します。</span><span class="sxs-lookup"><span data-stu-id="1a625-373">If you take a flat collection of items (books, for example, represented by a **BookSku** class) and you group the items by using a common property as a key (the **BookSku.AuthorName** property, for example) then the result is called grouped data.</span></span> <span data-ttu-id="1a625-374">データをグループ化すると、フラットなコレクションではなくなります。</span><span class="sxs-lookup"><span data-stu-id="1a625-374">When you group data, it is no longer a flat collection.</span></span> <span data-ttu-id="1a625-375">グループ化されたデータは、各グループ オブジェクトには、グループ オブジェクトのコレクション</span><span class="sxs-lookup"><span data-stu-id="1a625-375">Grouped data is a collection of group objects, where each group object has</span></span>

- <span data-ttu-id="1a625-376">キーと</span><span class="sxs-lookup"><span data-stu-id="1a625-376">a key, and</span></span>
- <span data-ttu-id="1a625-377">プロパティがそのキーに一致する項目のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="1a625-377">a collection of items whose property matches that key.</span></span>

<span data-ttu-id="1a625-378">書籍の例をもう一度実行するには、書籍を著者名でグループ化の結果は各グループには、著者名グループのコレクション</span><span class="sxs-lookup"><span data-stu-id="1a625-378">To take the books example again, the result of grouping the books by author name results in a collection of author name groups where each group has</span></span>

- <span data-ttu-id="1a625-379">としての著者名である、キーと</span><span class="sxs-lookup"><span data-stu-id="1a625-379">a key, which is an author name, and</span></span>
- <span data-ttu-id="1a625-380">**"作成者"** プロパティを持つグループのキーに一致**BookSku**s のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="1a625-380">a collection of the **BookSku**s whose **AuthorName** property matches the group's key.</span></span>

<span data-ttu-id="1a625-381">一般的に、コレクションを表示するには、項目コントロール [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/BR242828) ([**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) など) を、コレクションを返すプロパティに直接バインドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-381">In general, to display a collection, you bind the [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/BR242828) of an items control (such as [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) or [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705)) directly to a property that returns a collection.</span></span> <span data-ttu-id="1a625-382">項目のフラットなコレクションの場合は、何も特別なことをする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-382">If that's a flat collection of items then you don't need to do anything special.</span></span> <span data-ttu-id="1a625-383">一方、グループ オブジェクトのコレクションの場合 (グループ化されたデータにバインドしている場合など) は、項目コントロールとバインディング ソースの間に存在する、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) と呼ばれる中間オブジェクトのサービスが必要です。</span><span class="sxs-lookup"><span data-stu-id="1a625-383">But if it's a collection of group objects (as it is when binding to grouped data) then you need the services of an intermediary object called a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) which sits between the items control and the binding source.</span></span> <span data-ttu-id="1a625-384">グループ化されたデータを返すプロパティに **CollectionViewSource** をバインドし、項目コントロールを **CollectionViewSource** にバンドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-384">You bind the **CollectionViewSource** to the property that returns grouped data, and you bind the items control to the **CollectionViewSource**.</span></span> <span data-ttu-id="1a625-385">**CollectionViewSource** の追加の付加価値として現在の項目を追跡できるため、複数の項目コントロールをすべて同じ **CollectionViewSource** にバインドすることによって同期させることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-385">An extra value-add of a **CollectionViewSource** is that it keeps track of the current item, so you can keep more than one items control in sync by binding them all to the same **CollectionViewSource**.</span></span> <span data-ttu-id="1a625-386">[**CollectionViewSource.View**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.view) プロパティによって返されるオブジェクトの [**ICollectionView.CurrentItem**](https://msdn.microsoft.com/library/windows/apps/BR209857) プロパティによって、現在の項目にプログラムでアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-386">You can also access the current item programmatically through the [**ICollectionView.CurrentItem**](https://msdn.microsoft.com/library/windows/apps/BR209857) property of the object returned by the [**CollectionViewSource.View**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.view) property.</span></span>

<span data-ttu-id="1a625-387">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) のグループ化機能をアクティブにするには、[**IsSourceGrouped**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.issourcegrouped) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-387">To activate the grouping facility of a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833), set [**IsSourceGrouped**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.issourcegrouped) to **true**.</span></span> <span data-ttu-id="1a625-388">[**ItemsPath**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.itemspath) プロパティも設定する必要があるかどうかは、グループ オブジェクトを作成する方法に依存します。</span><span class="sxs-lookup"><span data-stu-id="1a625-388">Whether you also need to set the [**ItemsPath**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.itemspath) property depends on exactly how you author your group objects.</span></span> <span data-ttu-id="1a625-389">グループ オブジェクトを作成するには、"グループである" パターンと "グループを保持する" パターンの 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-389">There are two ways to author a group object: the "is-a-group" pattern, and the "has-a-group" pattern.</span></span> <span data-ttu-id="1a625-390">"グループである" パターンでは、グループ オブジェクトはコレクション型から派生 (たとえば、**List&lt;T&gt;**) から派生するため、グループ オブジェクトは実際にそれ自体が項目のグループです。</span><span class="sxs-lookup"><span data-stu-id="1a625-390">In the "is-a-group" pattern, the group object derives from a collection type (for example, **List&lt;T&gt;**), so the group object actually is itself the group of items.</span></span> <span data-ttu-id="1a625-391">このパターンでは、**ItemsPath** を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-391">With this pattern you do not need to set **ItemsPath**.</span></span> <span data-ttu-id="1a625-392">"グループを保持する" パターンでは、グループ オブジェクトはコレクション型 (**List&lt;T&gt;** など) の 1 つまたは複数のプロパティを持つため、グループは、プロパティの形式で項目のグループ (または複数のプロパティの形式で項目の複数のグループ) を "保持" します。</span><span class="sxs-lookup"><span data-stu-id="1a625-392">In the "has-a-group" pattern, the group object has one or more properties of a collection type (such as **List&lt;T&gt;**), so the group "has a" group of items in the form of a property (or several groups of items in the form of several properties).</span></span> <span data-ttu-id="1a625-393">このパターンでは、**ItemsPath** を、項目のグループを含むプロパティの名前に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-393">With this pattern you need to set **ItemsPath** to the name of the property that contains the group of items.</span></span>

<span data-ttu-id="1a625-394">次の例は、"グループを保持する" パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-394">The example below illustrates the "has-a-group" pattern.</span></span> <span data-ttu-id="1a625-395">ページ クラスには [**ViewModel**](https://msdn.microsoft.com/library/windows/apps/BR208713) という名前のプロパティがあります。このプロパティはビュー モデルのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="1a625-395">The page class has a property named [**ViewModel**](https://msdn.microsoft.com/library/windows/apps/BR208713), which returns an instance of our view model.</span></span> <span data-ttu-id="1a625-396">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) はビュー モデルの **Authors** プロパティにバインドされ (**Authors** はグループ オブジェクトのコレクション)、それがグループ化された項目を格納する **Author.BookSkus** プロパティであることも指定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-396">The [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) binds to the **Authors** property of the view model (**Authors** is the collection of group objects) and also specifies that it's the **Author.BookSkus** property that contains the grouped items.</span></span> <span data-ttu-id="1a625-397">最後に、[**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) は **CollectionViewSource** にバインドされ、グループ内の項目をレンダリングできるようにグループのスタイルが定義されています。</span><span class="sxs-lookup"><span data-stu-id="1a625-397">Finally, the [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) is bound to the **CollectionViewSource**, and has its group style defined so that it can render the items in groups.</span></span>

```csharp
<Page.Resources>
    <CollectionViewSource
    x:Name="AuthorHasACollectionOfBookSku"
    Source="{x:Bind ViewModel.Authors}"
    IsSourceGrouped="true"
    ItemsPath="BookSkus"/>
</Page.Resources>
...
<GridView
ItemsSource="{x:Bind AuthorHasACollectionOfBookSku}" ...>
    <GridView.GroupStyle>
        <GroupStyle
            HeaderTemplate="{StaticResource AuthorGroupHeaderTemplateWide}" ... />
    </GridView.GroupStyle>
</GridView>
```

<span data-ttu-id="1a625-398">"グループである" パターンは、2 つの方法のいずれかで実装できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-398">You can implement the "is-a-group" pattern in one of two ways.</span></span> <span data-ttu-id="1a625-399">1 つは、独自のグループ クラスを作成する方法です。</span><span class="sxs-lookup"><span data-stu-id="1a625-399">One way is to author your own group class.</span></span> <span data-ttu-id="1a625-400">**List&lt;T&gt;** からクラスを派生させます (ここで *T* は項目の型です)。</span><span class="sxs-lookup"><span data-stu-id="1a625-400">Derive the class from **List&lt;T&gt;** (where *T* is the type of the items).</span></span> <span data-ttu-id="1a625-401">たとえば、`public class Author : List<BookSku>` と記述します。</span><span class="sxs-lookup"><span data-stu-id="1a625-401">For example, `public class Author : List<BookSku>`.</span></span> <span data-ttu-id="1a625-402">もう 1 つは、**BookSku** 項目の同様のプロパティ値から、動的にグループ オブジェクト (とグループ クラス) を動的に作成する [LINQ](http://msdn.microsoft.com/library/bb397926.aspx) 式を使う方法です。</span><span class="sxs-lookup"><span data-stu-id="1a625-402">The second way is to use a [LINQ](http://msdn.microsoft.com/library/bb397926.aspx) expression to dynamically create group objects (and a group class) from like property values of the **BookSku** items.</span></span> <span data-ttu-id="1a625-403">このアプローチ (項目のフラットな一覧のみを保持し、必要に応じてグループ化する) は、クラウド サービスのデータにアクセスするアプリで一般的です。</span><span class="sxs-lookup"><span data-stu-id="1a625-403">This approach—maintaining only a flat list of items and grouping them together on the fly—is typical of an app that accesses data from a cloud service.</span></span> <span data-ttu-id="1a625-404">著者やジャンルなどに基づいて書籍を柔軟にグループ化することができます。**Author** や **Genre** などの特別なグループ クラスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-404">You get the flexibility to group books by author or by genre (for example) without needing special group classes such as **Author** and **Genre**.</span></span>

<span data-ttu-id="1a625-405">次の例は、[LINQ](http://msdn.microsoft.com/library/bb397926.aspx) を使用した "グループである" パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-405">The example below illustrates the "is-a-group" pattern using [LINQ](http://msdn.microsoft.com/library/bb397926.aspx).</span></span> <span data-ttu-id="1a625-406">今回は、書籍をジャンルでグループ化し、グループ ヘッダーにジャンル名と共に表示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-406">This time we group books by genre, displayed with the genre name in the group headers.</span></span> <span data-ttu-id="1a625-407">これは、グループの [**Key**](https://msdn.microsoft.com/library/windows/apps/bb343251.aspx) の値に関連する "Key" プロパティ パスによって示されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-407">This is indicated by the "Key" property path in reference to the group [**Key**](https://msdn.microsoft.com/library/windows/apps/bb343251.aspx) value.</span></span>

```csharp
using System.Linq;
...
private IOrderedEnumerable<IGrouping<string, BookSku>> genres;

public IOrderedEnumerable<IGrouping<string, BookSku>> Genres
{
    get
    {
        if (this.genres == null)
        {
            this.genres = from book in this.bookSkus
                          group book by book.genre into grp
                          orderby grp.Key
                          select grp;
        }
        return this.genres;
    }
}
```

<span data-ttu-id="1a625-408">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) をデータ テンプレートと共に使う場合、**x:DataType** 値を設定することによって、バインド先の型を指定する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-408">Remember that when using [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) with data templates we need to indicate the type being bound to by setting an **x:DataType** value.</span></span> <span data-ttu-id="1a625-409">型がジェネリックである場合、マークアップでは表現できないため、グループ スタイル ヘッダー テンプレート内で代わりに [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-409">If the type is generic then we can't express that in markup so we need to use [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) instead in the group style header template.</span></span>

```xaml
    <Grid.Resources>
        <CollectionViewSource x:Name="GenreIsACollectionOfBookSku"
        Source="{x:Bind Genres}"
        IsSourceGrouped="true"/>
    </Grid.Resources>
    <GridView ItemsSource="{x:Bind GenreIsACollectionOfBookSku}">
        <GridView.ItemTemplate x:DataType="local:BookTemplate">
            <DataTemplate>
                <TextBlock Text="{x:Bind Title}"/>
            </DataTemplate>
        </GridView.ItemTemplate>
        <GridView.GroupStyle>
            <GroupStyle>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Key}"/>
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </GridView.GroupStyle>
    </GridView>
```

<span data-ttu-id="1a625-410">[**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/Hh702601) コントロールは、ユーザーがグループ化されたデータを表示したり、データ間を移動したりするための優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="1a625-410">A [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/Hh702601) control is a great way for your users to view and navigate grouped data.</span></span> <span data-ttu-id="1a625-411">[Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) サンプル アプリは、**SemanticZoom** の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-411">The [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) sample app illustrates how to use the **SemanticZoom**.</span></span> <span data-ttu-id="1a625-412">このアプリでは、著者別にグループ化された書籍の一覧を表示する (拡大表示ビュー) ことも、縮小して著者のジャンプ リストを表示する (縮小表示ビュー) こともできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-412">In that app, you can view a list of books grouped by author (the zoomed-in view) or you can zoom out to see a jump list of authors (the zoomed-out view).</span></span> <span data-ttu-id="1a625-413">ジャンプ リストを使うと、書籍の一覧をスクロールするよりもすばやく移動することができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-413">The jump list affords much quicker navigation than scrolling through the list of books.</span></span> <span data-ttu-id="1a625-414">拡大表示ビューと縮小表示ビューは、実際には、同じ **CollectionViewSource** にバインドされた **ListView** または **GridView** コントロールです。</span><span class="sxs-lookup"><span data-stu-id="1a625-414">The zoomed-in and zoomed-out views are actually **ListView** or **GridView** controls bound to the same **CollectionViewSource**.</span></span>

![SemanticZoom の図](images/sezo.png)

<span data-ttu-id="1a625-416">階層データ (カテゴリ内のサブカテゴリなど) にバインドする場合、一連の項目コントロールを使って、UI に階層レベルを表示できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-416">When you bind to hierarchical data—such as subcategories within categories—you can choose to display the hierarchical levels in your UI with a series of items controls.</span></span> <span data-ttu-id="1a625-417">1 つの項目コントロールで項目を選ぶと、後続する項目コントロールの内容に反映されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-417">A selection in one items control determines the contents of subsequent items controls.</span></span> <span data-ttu-id="1a625-418">各リストをそれぞれの [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスにバインドし、**CollectionViewSource** インスタンスをチェーン形式でバインドすることで、これらのリストの同期を保つことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-418">You can keep the lists synchronized by binding each list to its own [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) and binding the **CollectionViewSource** instances together in a chain.</span></span> <span data-ttu-id="1a625-419">これは、マスター/詳細 (またはリスト/詳細) ビューと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="1a625-419">This is called a master/details (or list/details) view.</span></span> <span data-ttu-id="1a625-420">詳しくは、「[階層データにバインドし、マスター/詳細ビューを作る方法](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1a625-420">For more info, see [How to bind to hierarchical data and create a master/details view](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md).</span></span>

<span id="debugging"/>

## <a name="diagnosing-and-debugging-data-binding-problems"></a><span data-ttu-id="1a625-421">データ バインディングに関する問題の診断とデバッグ</span><span class="sxs-lookup"><span data-stu-id="1a625-421">Diagnosing and debugging data binding problems</span></span>

<span data-ttu-id="1a625-422">バインド マークアップには、プロパティ (と、C# では場合によってフィールドとメソッド) の名前が含まれています。</span><span class="sxs-lookup"><span data-stu-id="1a625-422">Your binding markup contains the names of properties (and, for C#, sometimes fields and methods).</span></span> <span data-ttu-id="1a625-423">したがって、プロパティの名前を変更するときに、それを参照するすべてのバインディングを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-423">So when you rename a property, you'll also need to change any binding that references it.</span></span> <span data-ttu-id="1a625-424">この処理を忘れることは、データ バインディングのバグの一般的な例であり、アプリは正しくコンパイルまたは実行されません。</span><span class="sxs-lookup"><span data-stu-id="1a625-424">Forgetting to do that leads to a typical example of a data binding bug, and your app either won't compile or won't run correctly.</span></span>

<span data-ttu-id="1a625-425">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) によって作成されたバインディング オブジェクトは、ほとんど機能的に同等です。</span><span class="sxs-lookup"><span data-stu-id="1a625-425">The binding objects created by [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) and [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) are largely functionally equivalent.</span></span> <span data-ttu-id="1a625-426">ただし、{x:Bind} にはバインディング ソースの型情報が含まれ、コンパイル時にソース コードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-426">But {x:Bind} has type information for the binding source, and it generates source code at compile-time.</span></span> <span data-ttu-id="1a625-427">{x:Bind} を使うと、コードの残りの部分で取得できるものと同じ種類の問題の検出を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-427">With {x:Bind} you get the same kind of problem detection that you get with the rest of your code.</span></span> <span data-ttu-id="1a625-428">これには、コンパイル時のバインド式の検証や、ページの部分クラスとして生成されたソース コード内でのブレークポイント設定によるデバッグが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1a625-428">That includes compile-time validation of your binding expressions, and debugging by setting breakpoints in the source code generated as the partial class for your page.</span></span> <span data-ttu-id="1a625-429">これらのクラスは `obj` フォルダー内のファイルにあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="1a625-429">These classes can be found in the files in your `obj` folder, with names like (for C#) `<view name>.g.cs`).</span></span> <span data-ttu-id="1a625-430">バインディングに問題がある場合は、Microsoft Visual Studio デバッガーで、**[処理されない例外で中断]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="1a625-430">If you have a problem with a binding then turn on **Break On Unhandled Exceptions** in the Microsoft Visual Studio debugger.</span></span> <span data-ttu-id="1a625-431">デバッガーはその時点での実行を中断し、問題のある点をデバッグすることができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-431">The debugger will break execution at that point, and you can then debug what has gone wrong.</span></span> <span data-ttu-id="1a625-432">{x:Bind} によって生成されたコードは、バインディング ソース ノードのグラフの各部分で同じパターンに従うため、この情報を **[コール スタック]** ウィンドウで使って、問題の原因となった呼び出しのシーケンスを特定できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-432">The code generated by {x:Bind} follows the same pattern for each part of the graph of binding source nodes, and you can use the info in the **Call Stack** window to help determine the sequence of calls that led up to the problem.</span></span>

<span data-ttu-id="1a625-433">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) には、バインディング ソースの型情報はありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-433">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) does not have type information for the binding source.</span></span> <span data-ttu-id="1a625-434">ただし、デバッガーがアタッチされたアプリを実行すると、バインド エラーがある場合は Visual Studio の **[出力]** ウィンドウにそのエラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-434">But when you run your app with the debugger attached, any binding errors appear in the **Output** window in Visual Studio.</span></span>

## <a name="creating-bindings-in-code"></a><span data-ttu-id="1a625-435">コードでのバインドの作成</span><span class="sxs-lookup"><span data-stu-id="1a625-435">Creating bindings in code</span></span>

<span data-ttu-id="1a625-436">**注:** このセクションにのみ適用されます[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)、コードで[{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)バインディングを作成できないためです。</span><span class="sxs-lookup"><span data-stu-id="1a625-436">**Note**This section only applies to [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782), because you can't create [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) bindings in code.</span></span> <span data-ttu-id="1a625-437">ただし、{x:Bind} と同じメリットを、[**DependencyObject.RegisterPropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx) によって実現できます。これにより、すべての依存関係プロパティについての変更通知を登録できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-437">However, some of the same benefits of {x:Bind} can be achieved with [**DependencyObject.RegisterPropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx), which enables you to register for change notifications on any dependency property.</span></span>

<span data-ttu-id="1a625-438">XAML の代わりに手続き型コードを使っても UI 要素をデータに接続できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-438">You can also connect UI elements to data using procedural code instead of XAML.</span></span> <span data-ttu-id="1a625-439">そのためには、新しい [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) オブジェクトを作成し、適切なプロパティを設定してから、[**FrameworkElement.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257.aspx) または [**BindingOperations.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244376.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1a625-439">To do this, create a new [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) object, set the appropriate properties, then call [**FrameworkElement.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257.aspx) or [**BindingOperations.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244376.aspx).</span></span> <span data-ttu-id="1a625-440">バインドをプログラムで作成すると、Binding プロパティの値を実行時に選択する場合や、複数のコントロール間で 1 つのバインドを共有する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="1a625-440">Creating bindings programmatically is useful when you want to choose the binding property values at run-time or share a single binding among multiple controls.</span></span> <span data-ttu-id="1a625-441">ただし、**SetBinding** の呼び出し後は Binding プロパティの値を変更できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1a625-441">Note, however, that you cannot change the binding property values after you call **SetBinding**.</span></span>

<span data-ttu-id="1a625-442">次の例では、バインドをコードで実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1a625-442">The following example shows how to implement a binding in code.</span></span>

```xaml
<TextBox x:Name="MyTextBox" Text="Text"/>
```

```csharp
// Create an instance of the MyColors class 
// that implements INotifyPropertyChanged.
MyColors textcolor = new MyColors();

// Brush1 is set to be a SolidColorBrush with the value Red.
textcolor.Brush1 = new SolidColorBrush(Colors.Red);

// Set the DataContext of the TextBox MyTextBox.
MyTextBox.DataContext = textcolor;

// Create the binding and associate it with the text box.
Binding binding = new Binding() { Path = new PropertyPath("Brush1") };
MyTextBox.SetBinding(TextBox.ForegroundProperty, binding);
```

```vbnet
' Create an instance of the MyColors class 
' that implements INotifyPropertyChanged. 
Dim textcolor As New MyColors()

' Brush1 is set to be a SolidColorBrush with the value Red. 
textcolor.Brush1 = New SolidColorBrush(Colors.Red)

' Set the DataContext of the TextBox MyTextBox. 
MyTextBox.DataContext = textcolor

' Create the binding and associate it with the text box.
Dim binding As New Binding() With {.Path = New PropertyPath("Brush1")}
MyTextBox.SetBinding(TextBox.ForegroundProperty, binding)
```

## <a name="xbind-and-binding-feature-comparison"></a><span data-ttu-id="1a625-443">{x:Bind} と {Binding} の機能の比較</span><span class="sxs-lookup"><span data-stu-id="1a625-443">{x:Bind} and {Binding} feature comparison</span></span>

| <span data-ttu-id="1a625-444">機能</span><span class="sxs-lookup"><span data-stu-id="1a625-444">Feature</span></span> | <span data-ttu-id="1a625-445">{x:Bind}</span><span class="sxs-lookup"><span data-stu-id="1a625-445">{x:Bind}</span></span> | <span data-ttu-id="1a625-446">{Binding}</span><span class="sxs-lookup"><span data-stu-id="1a625-446">{Binding}</span></span> | <span data-ttu-id="1a625-447">コメント</span><span class="sxs-lookup"><span data-stu-id="1a625-447">Notes</span></span> |
|---------|----------|-----------|-------|
| <span data-ttu-id="1a625-448">Path が既定のプロパティである</span><span class="sxs-lookup"><span data-stu-id="1a625-448">Path is the default property</span></span> | `{x:Bind a.b.c}` | `{Binding a.b.c}` | | 
| <span data-ttu-id="1a625-449">Path プロパティ</span><span class="sxs-lookup"><span data-stu-id="1a625-449">Path property</span></span> | `{x:Bind Path=a.b.c}` | `{Binding Path=a.b.c}` | <span data-ttu-id="1a625-450">x:Bind では、Path は既定で DataContext ではなく、Page をルートにします。</span><span class="sxs-lookup"><span data-stu-id="1a625-450">In x:Bind, Path is rooted at the Page by default, not the DataContext.</span></span> | 
| <span data-ttu-id="1a625-451">インデクサー</span><span class="sxs-lookup"><span data-stu-id="1a625-451">Indexer</span></span> | `{x:Bind Groups[2].Title}` | `{Binding Groups[2].Title}` | <span data-ttu-id="1a625-452">コレクション内で指定した項目にバインドします。</span><span class="sxs-lookup"><span data-stu-id="1a625-452">Binds to the specified item in the collection.</span></span> <span data-ttu-id="1a625-453">整数ベースのインデックスのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="1a625-453">Only integer-based indexes are supported.</span></span> | 
| <span data-ttu-id="1a625-454">添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="1a625-454">Attached properties</span></span> | `{x:Bind Button22.(Grid.Row)}` | `{Binding Button22.(Grid.Row)}` | <span data-ttu-id="1a625-455">添付プロパティは、かっこを使って指定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-455">Attached properties are specified using parentheses.</span></span> <span data-ttu-id="1a625-456">プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-456">If the property is not declared in a XAML namespace, then prefix it with an xml namespace, which should be mapped to a code namespace at the head of the document.</span></span> | 
| <span data-ttu-id="1a625-457">キャスト</span><span class="sxs-lookup"><span data-stu-id="1a625-457">Casting</span></span> | `{x:Bind groups[0].(data:SampleDataGroup.Title)}` | <span data-ttu-id="1a625-458">必要ありません。</span><span class="sxs-lookup"><span data-stu-id="1a625-458">Not needed.</span></span> | <span data-ttu-id="1a625-459">キャストはかっこを使って指定します。</span><span class="sxs-lookup"><span data-stu-id="1a625-459">Casts are specified using parentheses.</span></span> <span data-ttu-id="1a625-460">プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-460">If the property is not declared in a XAML namespace, then prefix it with an xml namespace, which should be mapped to a code namespace at the head of the document.</span></span> | 
| <span data-ttu-id="1a625-461">Converter</span><span class="sxs-lookup"><span data-stu-id="1a625-461">Converter</span></span> | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}}` | <span data-ttu-id="1a625-462">コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-462">Converters must be declared at the root of the Page/ResourceDictionary, or in App.xaml.</span></span> | 
| <span data-ttu-id="1a625-463">ConverterParameter、ConverterLanguage</span><span class="sxs-lookup"><span data-stu-id="1a625-463">ConverterParameter, ConverterLanguage</span></span> | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | <span data-ttu-id="1a625-464">コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a625-464">Converters must be declared at the root of the Page/ResourceDictionary, or in App.xaml.</span></span> | 
| <span data-ttu-id="1a625-465">TargetNullValue</span><span class="sxs-lookup"><span data-stu-id="1a625-465">TargetNullValue</span></span> | `{x:Bind Name, TargetNullValue=0}` | `{Binding Name, TargetNullValue=0}` | <span data-ttu-id="1a625-466">バインド式のリーフが null の場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-466">Used when the leaf of the binding expression is null.</span></span> <span data-ttu-id="1a625-467">文字列値の場合は単一引用符を使用します。</span><span class="sxs-lookup"><span data-stu-id="1a625-467">Use single quotes for a string value.</span></span> | 
| <span data-ttu-id="1a625-468">FallbackValue</span><span class="sxs-lookup"><span data-stu-id="1a625-468">FallbackValue</span></span> | `{x:Bind Name, FallbackValue='empty'}` | `{Binding Name, FallbackValue='empty'}` | <span data-ttu-id="1a625-469">バインディングのパスの一部 (リーフを除く) が null の場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="1a625-469">Used when any part of the path for the binding (except for the leaf) is null.</span></span> | 
| <span data-ttu-id="1a625-470">ElementName</span><span class="sxs-lookup"><span data-stu-id="1a625-470">ElementName</span></span> | `{x:Bind slider1.Value}` | `{Binding Value, ElementName=slider1}` | <span data-ttu-id="1a625-471">{x:Bind} によって、フィールドにバインドしています。Path は既定で Page をルートとするため、名前付きの要素はそのフィールドを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1a625-471">With {x:Bind} you're binding to a field; Path is rooted at the Page by default, so any named element can be accessed via its field.</span></span> | 
| <span data-ttu-id="1a625-472">RelativeSource: Self</span><span class="sxs-lookup"><span data-stu-id="1a625-472">RelativeSource: Self</span></span> | `<Rectangle x:Name="rect1" Width="200" Height="{x:Bind rect1.Width}" ... />` | `<Rectangle Width="200" Height="{Binding Width, RelativeSource={RelativeSource Self}}" ... />` | <span data-ttu-id="1a625-473">{x:Bind} では、要素に名前を付けて、Path でその名前を使います。</span><span class="sxs-lookup"><span data-stu-id="1a625-473">With {x:Bind}, name the element and use its name in Path.</span></span> | 
| <span data-ttu-id="1a625-474">RelativeSource: TemplatedParent</span><span class="sxs-lookup"><span data-stu-id="1a625-474">RelativeSource: TemplatedParent</span></span> | <span data-ttu-id="1a625-475">不要</span><span class="sxs-lookup"><span data-stu-id="1a625-475">Not needed</span></span> | `{Binding <path>, RelativeSource={RelativeSource TemplatedParent}}` | <span data-ttu-id="1a625-476">{X:bind} は、TargetType ControlTemplate では、親のテンプレート バインディングを示します。</span><span class="sxs-lookup"><span data-stu-id="1a625-476">With {x:Bind} TargetType on ControlTemplate indicates binding to template parent.</span></span> <span data-ttu-id="1a625-477">{Binding} には、標準のテンプレート バインディングをほとんどのユーザーのコントロール テンプレートで使用することができます。</span><span class="sxs-lookup"><span data-stu-id="1a625-477">For {Binding} Regular template binding can be used in control templates for most uses.</span></span> <span data-ttu-id="1a625-478">ただし、コンバーターまたは双方向バインディングを使用する必要がある場合は TemplatedParent を使います。<</span><span class="sxs-lookup"><span data-stu-id="1a625-478">But use TemplatedParent where you need to use a converter, or a two-way binding.<</span></span> | 
| <span data-ttu-id="1a625-479">Source</span><span class="sxs-lookup"><span data-stu-id="1a625-479">Source</span></span> | <span data-ttu-id="1a625-480">不要</span><span class="sxs-lookup"><span data-stu-id="1a625-480">Not needed</span></span> | `<ListView ItemsSource="{Binding Orders, Source={StaticResource MyData}}"/>` | <span data-ttu-id="1a625-481">{X:bind} の名前付きの要素を直接に使用できるプロパティまたは静的パスを使います。</span><span class="sxs-lookup"><span data-stu-id="1a625-481">For {x:Bind} you can directly use the named element, use a property or a static path.</span></span> | 
| <span data-ttu-id="1a625-482">Mode</span><span class="sxs-lookup"><span data-stu-id="1a625-482">Mode</span></span> | `{x:Bind Name, Mode=OneWay}` | `{Binding Name, Mode=TwoWay}` | <span data-ttu-id="1a625-483">Mode には、OneTime、OneWay、TwoWay を指定できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-483">Mode can be OneTime, OneWay, or TwoWay.</span></span> <span data-ttu-id="1a625-484">{x:Bind} の既定値は OneTime で、{Binding} の既定値は OneWay です。</span><span class="sxs-lookup"><span data-stu-id="1a625-484">{x:Bind} defaults to OneTime; {Binding} defaults to OneWay.</span></span> | 
| <span data-ttu-id="1a625-485">UpdateSourceTrigger</span><span class="sxs-lookup"><span data-stu-id="1a625-485">UpdateSourceTrigger</span></span> | `{x:Bind Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}` | `{Binding UpdateSourceTrigger=PropertyChanged}` | <span data-ttu-id="1a625-486">UpdateSourceTrigger には、Default、LostFocus、PropertyChanged を指定できます。</span><span class="sxs-lookup"><span data-stu-id="1a625-486">UpdateSourceTrigger can be Default, LostFocus, or PropertyChanged.</span></span> <span data-ttu-id="1a625-487">{x:Bind} では、UpdateSourceTrigger=Explicit はサポートされません。</span><span class="sxs-lookup"><span data-stu-id="1a625-487">{x:Bind} does not support UpdateSourceTrigger=Explicit.</span></span> <span data-ttu-id="1a625-488">{x:Bind} では、TextBox.Text を除くすべての場合に PropertyChanged 動作を使います。TextBox.Text の場合は LostFocus 動作を使います。</span><span class="sxs-lookup"><span data-stu-id="1a625-488">{x:Bind} uses PropertyChanged behavior for all cases except TextBox.Text, where it uses LostFocus behavior.</span></span> | 


