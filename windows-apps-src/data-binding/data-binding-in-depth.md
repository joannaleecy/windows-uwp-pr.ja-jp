---
ms.assetid: 41E1B4F1-6CAF-4128-A61A-4E400B149011
title: データ バインディングの詳細
description: データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。
ms.date: 10/05/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
ms.openlocfilehash: cd6620e8bfb2bba58a2bdc28d61e4855a75dd203
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63798170"
---
# <a name="data-binding-in-depth"></a><span data-ttu-id="e4cb9-104">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="e4cb9-104">Data binding in depth</span></span>

<span data-ttu-id="e4cb9-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-105">**Important APIs**</span></span>

-   [<span data-ttu-id="e4cb9-106">**{X:bind} マークアップ拡張機能**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-106">**{x:Bind} markup extension**</span></span>](../xaml-platform/x-bind-markup-extension.md)
-   [<span data-ttu-id="e4cb9-107">**バインディング クラス**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-107">**Binding class**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR209820)
-   [<span data-ttu-id="e4cb9-108">**DataContext**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-108">**DataContext**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR208713)
-   [<span data-ttu-id="e4cb9-109">**INotifyPropertyChanged**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-109">**INotifyPropertyChanged**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR209899)

> [!NOTE]
> <span data-ttu-id="e4cb9-110">このトピックでは、データ バインディングの機能について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-110">This topic describes data binding features in detail.</span></span> <span data-ttu-id="e4cb9-111">簡潔で実用的な紹介については、「[データ バインディングの概要](data-binding-quickstart.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-111">For a short, practical introduction, see [Data binding overview](data-binding-quickstart.md).</span></span>

<span data-ttu-id="e4cb9-112">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでのデータ バインディングについて。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-112">This topic is about data binding in Universal Windows Platform (UWP) applications.</span></span> <span data-ttu-id="e4cb9-113">ここで説明した Api に存在、 [ **Windows.UI.Xaml.Data**名前空間](/uwp/api/windows.ui.xaml.data)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-113">The APIs discussed here reside in the [**Windows.UI.Xaml.Data** namespace](/uwp/api/windows.ui.xaml.data).</span></span>

<span data-ttu-id="e4cb9-114">データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-114">Data binding is a way for your app's UI to display data, and optionally to stay in sync with that data.</span></span> <span data-ttu-id="e4cb9-115">データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-115">Data binding allows you to separate the concern of data from the concern of UI, and that results in a simpler conceptual model as well as better readability, testability, and maintainability of your app.</span></span>

<span data-ttu-id="e4cb9-116">データ バインディングは、UI が最初に表示されたときにデータ ソースからの値を表示するだけの場合に使うことができ、それらの値の変化に応答するために使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-116">You can use data binding to simply display values from a data source when the UI is first shown, but not to respond to changes in those values.</span></span> <span data-ttu-id="e4cb9-117">これは、モードというバインドの*1 回限り*、し、実行時に変更されない値に対して適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-117">This is a mode of binding called *one-time*, and it works well for a value that doesn't change during run-time.</span></span> <span data-ttu-id="e4cb9-118">または、値を「確認」を変更するときに UI を更新するを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-118">Alternatively, you can choose to "observe" the values and to update the UI when they change.</span></span> <span data-ttu-id="e4cb9-119">このモードと呼ばれる*一方向*、および読み取り専用データに対して適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-119">This mode is called *one-way*, and it works well for read-only data.</span></span> <span data-ttu-id="e4cb9-120">最終的には、ユーザーが UI で値に対して行った変更が自動的にデータ ソースにプッシュバックされるように、監視と更新の両方を行うことを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-120">Ultimately, you can choose to both observe and update, so that changes that the user makes to values in the UI are automatically pushed back into the data source.</span></span> <span data-ttu-id="e4cb9-121">このモードと呼ばれる*双方向*、および読み取り/書き込みデータに対して適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-121">This mode is called *two-way*, and it works well for read-write data.</span></span> <span data-ttu-id="e4cb9-122">例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-122">Here are some examples.</span></span>

-   <span data-ttu-id="e4cb9-123">1 回限りのモードを使用してバインドすることが、 [**イメージ**](https://msdn.microsoft.com/library/windows/apps/BR242752)現在のユーザーの写真にします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-123">You could use the one-time mode to bind an [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) to the current user's photo.</span></span>
-   <span data-ttu-id="e4cb9-124">一方向のモードを使用してバインドすることが、 [ **ListView** ](https://msdn.microsoft.com/library/windows/apps/BR242878)新聞のセクションでグループ化されたリアルタイムのニュース記事のコレクションにします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-124">You could use the one-way mode to bind a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to a collection of real-time news articles grouped by newspaper section.</span></span>
-   <span data-ttu-id="e4cb9-125">双方向のモードを使用してバインドすることが、 [ **TextBox** ](https://msdn.microsoft.com/library/windows/apps/BR209683)フォームで顧客の名前にします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-125">You could use the two-way mode to bind a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) to a customer's name in a form.</span></span>

<span data-ttu-id="e4cb9-126">モードに依存しない、バインディングの 2 種類がありますし、どちらも通常宣言される UI のマークアップでします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-126">Independent of mode, there are two kinds of binding, and they're both typically declared in UI markup.</span></span> <span data-ttu-id="e4cb9-127">[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)と [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)のいずれを使うかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-127">You can choose to use either the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783) or the [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span> <span data-ttu-id="e4cb9-128">また、同じアプリや同じ UI 要素で、この 2 つを組み合わせて使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-128">And you can even use a mixture of the two in the same app—even on the same UI element.</span></span> <span data-ttu-id="e4cb9-129">{x:Bind} は Windows 10 の新機能で、パフォーマンスが向上しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-129">{x:Bind} is new for Windows 10 and it has better performance.</span></span> <span data-ttu-id="e4cb9-130">このトピックで説明されているすべての詳細は、特に明記していない限り、両方の種類のバインディングに適用されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-130">All the details described in this topic apply to both kinds of binding unless we explicitly say otherwise.</span></span>

<span data-ttu-id="e4cb9-131">**{X:bind} を示すサンプル アプリ**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-131">**Sample apps that demonstrate {x:Bind}**</span></span>

-   <span data-ttu-id="e4cb9-132">[{x:Bind} のサンプル](https://go.microsoft.com/fwlink/p/?linkid=619989)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-132">[{x:Bind} sample](https://go.microsoft.com/fwlink/p/?linkid=619989).</span></span>
-   <span data-ttu-id="e4cb9-133">[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-133">[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame).</span></span>
-   <span data-ttu-id="e4cb9-134">[XAML UI の基本のサンプル](https://go.microsoft.com/fwlink/p/?linkid=619992)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-134">[XAML UI Basics sample](https://go.microsoft.com/fwlink/p/?linkid=619992).</span></span>

<span data-ttu-id="e4cb9-135">**{バインディング} を示すサンプル アプリ**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-135">**Sample apps that demonstrate {Binding}**</span></span>

-   <span data-ttu-id="e4cb9-136">[Bookstore1](https://go.microsoft.com/fwlink/?linkid=532950) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-136">Download the [Bookstore1](https://go.microsoft.com/fwlink/?linkid=532950) app.</span></span>
-   <span data-ttu-id="e4cb9-137">[Bookstore2](https://go.microsoft.com/fwlink/?linkid=532952) アプリのダウンロード。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-137">Download the [Bookstore2](https://go.microsoft.com/fwlink/?linkid=532952) app.</span></span>

## <a name="every-binding-involves-these-pieces"></a><span data-ttu-id="e4cb9-138">すべてのバインディングに関連する要素</span><span class="sxs-lookup"><span data-stu-id="e4cb9-138">Every binding involves these pieces</span></span>

-   <span data-ttu-id="e4cb9-139">*バインディング ソース*。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-139">A *binding source*.</span></span> <span data-ttu-id="e4cb9-140">これは、バインディング用のデータのソースで、UI に表示する値を持つメンバーが含まれる、任意のクラスのインスタンスを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-140">This is the source of the data for the binding, and it can be an instance of any class that has members whose values you want to display in your UI.</span></span>
-   <span data-ttu-id="e4cb9-141">*バインディング ターゲット*。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-141">A *binding target*.</span></span> <span data-ttu-id="e4cb9-142">これは、データを表示する UI の [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) の [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-142">This is a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) of the [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) in your UI that displays the data.</span></span>
-   <span data-ttu-id="e4cb9-143">*バインディング オブジェクト*。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-143">A *binding object*.</span></span> <span data-ttu-id="e4cb9-144">これは、ソースからターゲットに、および必要に応じてターゲットからソースに、データ値を転送する要素です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-144">This is the piece that transfers data values from the source to the target, and optionally from the target back to the source.</span></span> <span data-ttu-id="e4cb9-145">バインディング オブジェクトは、XAML の読み込み時に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) または [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) マークアップ拡張から作成されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-145">The binding object is created at XAML load time from your [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) or [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

<span data-ttu-id="e4cb9-146">次のセクションでは、バインディング ソース、バインディング ターゲット、バインド オブジェクトについて詳しく見てみます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-146">In the following sections, we'll take a closer look at the binding source, the binding target, and the binding object.</span></span> <span data-ttu-id="e4cb9-147">また、以下のセクションでは、**HostViewModel** という名前のクラスに属する **NextButtonText** という名前の文字列プロパティに、ボタンのコンテンツをバインドする例へのリンクも示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-147">And we'll link the sections together with the example of binding a button's content to a string property named **NextButtonText**, which belongs to a class named **HostViewModel**.</span></span>

### <a name="binding-source"></a><span data-ttu-id="e4cb9-148">バインディング ソース</span><span class="sxs-lookup"><span data-stu-id="e4cb9-148">Binding source</span></span>

<span data-ttu-id="e4cb9-149">バインディング ソースとして使用できるクラスの非常に基本的な実装を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-149">Here's a very rudimentary implementation of a class that we could use as a binding source.</span></span>

<span data-ttu-id="e4cb9-150">使用している場合[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、新規に追加し、 **Midl ファイル (.idl)** という名前の c++ で示すように、プロジェクトに項目/cli WinRT コードの例の一覧が下です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-150">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then add new **Midl File (.idl)** items to the project, named as shown in the C++/WinRT code example listing below.</span></span> <span data-ttu-id="e4cb9-151">それらの新しいファイルの内容を置き換えます、 [MIDL 3.0](/uwp/midl-3/intro)の一覧で示すようにコードを生成するプロジェクトをビルド`HostViewModel.h`と`.cpp`、し、一覧に一致するように、生成されたファイルにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-151">Replace the contents of those new files with the [MIDL 3.0](/uwp/midl-3/intro) code shown in the listing, build the project to generate `HostViewModel.h` and `.cpp`, and then add code to the generated files to match the listing.</span></span> <span data-ttu-id="e4cb9-152">生成されたファイルに関する詳細情報と、プロジェクトにコピーする方法は、次を参照してください。 [XAML 制御; バインド c++/cli WinRT プロパティ](/windows/uwp/cpp-and-winrt-apis/binding-property)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-152">For more info about those generated files and how to copy them into your project, see [XAML controls; bind to a C++/WinRT property](/windows/uwp/cpp-and-winrt-apis/binding-property).</span></span>

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

<span data-ttu-id="e4cb9-153">**HostViewModel** の実装とその **NextButtonText** プロパティは、1 回限りのバインディングにのみ適しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-153">That implementation of **HostViewModel**, and its property **NextButtonText**, are only appropriate for one-time binding.</span></span> <span data-ttu-id="e4cb9-154">ただし、一方向バインディングと双方向バインディングは非常に一般的であり、これらの種類のバインディングでは、UI はバインディング ソースのデータ値の変化に対応して自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-154">But one-way and two-way bindings are extremely common, and in those kinds of binding the UI automatically updates in response to changes in the data values of the binding source.</span></span> <span data-ttu-id="e4cb9-155">これらの種類のバインディングが正常に動作するには、バインディング ソースをバインディング オブジェクトから "監視可能" にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-155">In order for those kinds of binding to work correctly, you need to make your binding source "observable" to the binding object.</span></span> <span data-ttu-id="e4cb9-156">この例では、**NextButtonText** プロパティに対して一方向または双方向バインディングを設定する場合、実行時にこのプロパティの値に対して発生するすべての変更を、バインディング オブジェクトから監視可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-156">So in our example, if we want to one-way or two-way bind to the **NextButtonText** property, then any changes that happen at run-time to the value of that property need to be made observable to the binding object.</span></span>

<span data-ttu-id="e4cb9-157">そのための方法の 1 つは、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356) からバインディング ソースを表すクラスを派生させ、[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) を通じてデータ値を公開することです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-157">One way of doing that is to derive the class that represents your binding source from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356), and expose a data value through a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362).</span></span> <span data-ttu-id="e4cb9-158">これが、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) を監視可能にする方法です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-158">That's how a [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) becomes observable.</span></span> <span data-ttu-id="e4cb9-159">**FrameworkElements** は、そのまま利用できる優れたバインディング ソースです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-159">**FrameworkElements** are good binding sources right out of the box.</span></span>

<span data-ttu-id="e4cb9-160">より簡単にクラスを監視可能にする方法 (および既に基底クラスがあるクラスで必要な方法) は、[**System.ComponentModel.INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) を実装することです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-160">A more lightweight way of making a class observable—and a necessary one for classes that already have a base class—is to implement [**System.ComponentModel.INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx).</span></span> <span data-ttu-id="e4cb9-161">この方法は、**PropertyChanged** という名前の単一のイベントを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-161">This really just involves implementing a single event named **PropertyChanged**.</span></span> <span data-ttu-id="e4cb9-162">**HostViewModel** を使った例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-162">An example using **HostViewModel** is below.</span></span>

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

<span data-ttu-id="e4cb9-163">これで、**NextButtonText** プロパティは監視可能です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-163">Now the **NextButtonText** property is observable.</span></span> <span data-ttu-id="e4cb9-164">そのプロパティへの一方向または双方向のバインディングを作成する場合 (方法については後述)、作成したバインディング オブジェクトは **PropertyChanged** イベントを受信登録します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-164">When you author a one-way or a two-way binding to that property (we'll show how later), the resulting binding object subscribes to the **PropertyChanged** event.</span></span> <span data-ttu-id="e4cb9-165">そのイベントが発生すると、バインディング オブジェクトのハンドラーは、変更されたプロパティの名前を含む引数を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-165">When that event is raised, the binding object's handler receives an argument containing the name of the property that has changed.</span></span> <span data-ttu-id="e4cb9-166">このようにして、バインディング オブジェクトはどのプロパティの値が残っており、再び読み取る必要があるかを識別します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-166">That's how the binding object knows which property's value to go and read again.</span></span>

<span data-ttu-id="e4cb9-167">使用している場合は、複数回、上記のパターンを実装する必要があるないようにC#だけから派生することができ、 **BindableBase**で低音のクラス、 [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) (サンプル"Common"フォルダー)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-167">So that you don't have to implement the pattern shown above multiple times, if you're using C# then you can just derive from the **BindableBase** bass class that you'll find in the [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) sample (in the "Common" folder).</span></span> <span data-ttu-id="e4cb9-168">どのようになるかを示す例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-168">Here's an example of how that looks.</span></span>

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
> <span data-ttu-id="e4cb9-169">C++/cli WinRT、基底クラスから派生した、アプリケーションで宣言された任意のランタイム クラスと呼ばれる、*コンポーザブル*クラス。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-169">For C++/WinRT, any runtime class that you declare in your application that derives from a base class is known as a *composable* class.</span></span> <span data-ttu-id="e4cb9-170">構成可能なクラスに関する制約があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-170">And there are constraints around composable classes.</span></span> <span data-ttu-id="e4cb9-171">アプリケーションに渡す、 [Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)Visual Studio では、Microsoft Store での送信を検証するために使用するテスト (ため Microsoft Store に正常に取り込まれるアプリケーションの)、コンポーザブル クラスは、Windows の基本クラスから最終的に派生する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-171">For an application to pass the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) tests used by Visual Studio and by the Microsoft Store to validate submissions (and therefore for the application to be successfully ingested into the Microsoft Store), a composable class must ultimately derive from a Windows base class.</span></span> <span data-ttu-id="e4cb9-172">つまり、継承階層の非常にルートにあるクラスは、Windows.\* 名前空間で生成された型である必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-172">Meaning that the class at the very root of the inheritance hierarchy must be a type originating in a Windows.\* namespace.</span></span> <span data-ttu-id="e4cb9-173">ランタイム クラスを基底クラスから派生する必要は場合&mdash;を実装する例を**BindableBase**クラスから派生するは、ビュー モデルのすべての&mdash;から派生できます[ **Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-173">If you do need to derive a runtime class from a base class&mdash;for example, to implement a **BindableBase** class for all of your view models to derive from&mdash;then you can derive from [**Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject).</span></span>

<span data-ttu-id="e4cb9-174">[  **String.Empty**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.empty.aspx) または **null** の引数を使って **PropertyChanged** イベントを発生させることは、オブジェクトのすべての非インデクサー プロパティを再び読み取る必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-174">Raising the **PropertyChanged** event with an argument of [**String.Empty**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.empty.aspx) or **null** indicates that all non-indexer properties on the object should be re-read.</span></span> <span data-ttu-id="e4cb9-175">引数を使用してオブジェクトのインデクサー プロパティを変更したことを示すイベントを発生させることができます"項目\[*インデクサー*\]"特定のインデクサー (場所*インデクサー*はインデックス値にある) かの値を"項目\[\]"のすべてのインデクサー。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-175">You can raise the event to indicate that indexer properties on the object have changed by using an argument of "Item\[*indexer*\]" for specific indexers (where *indexer* is the index value), or a value of "Item\[\]" for all indexers.</span></span>

<span data-ttu-id="e4cb9-176">バインディング ソースは、プロパティにデータが含まれる単一のオブジェクト、またはオブジェクトのコレクションとして処理できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-176">A binding source can be treated either as a single object whose properties contain data, or as a collection of objects.</span></span> <span data-ttu-id="e4cb9-177">C# Visual Basic のコードを実装するオブジェクトを 1 回限りのバインドをできますと[ **List (Of T)** ](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx)実行時に変更することはコレクションを表示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-177">In C# and Visual Basic code, you can one-time bind to an object that implements [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) to display a collection that doesn't change at run-time.</span></span> <span data-ttu-id="e4cb9-178">監視可能なコレクション (コレクションの項目の追加と削除を監視する) の場合、代わりに [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) への一方向バインディングを設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-178">For an observable collection (observing when items are added to and removed from the collection), one-way bind to [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) instead.</span></span> <span data-ttu-id="e4cb9-179">C++ コードでは、監視可能なコレクションと監視可能ではないコレクションの両方について、[**Vector&lt;T&gt;**](https://msdn.microsoft.com/library/dn858385.aspx) にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-179">In C++ code, you can bind to [**Vector&lt;T&gt;**](https://msdn.microsoft.com/library/dn858385.aspx) for both observable and non-observable collections.</span></span> <span data-ttu-id="e4cb9-180">独自のコレクション クラスにバインドするには、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-180">To bind to your own collection classes, use the guidance in the following table.</span></span>

|<span data-ttu-id="e4cb9-181">シナリオ</span><span class="sxs-lookup"><span data-stu-id="e4cb9-181">Scenario</span></span>|<span data-ttu-id="e4cb9-182">C# と VB (CLR)</span><span class="sxs-lookup"><span data-stu-id="e4cb9-182">C# and VB (CLR)</span></span>|<span data-ttu-id="e4cb9-183">C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="e4cb9-183">C++/WinRT</span></span>|<span data-ttu-id="e4cb9-184">C++/CX</span><span class="sxs-lookup"><span data-stu-id="e4cb9-184">C++/CX</span></span>|
|-|-|-|-|
|<span data-ttu-id="e4cb9-185">オブジェクトにバインドする。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-185">Bind to an object.</span></span>|<span data-ttu-id="e4cb9-186">どのオブジェクトでもかまいません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-186">Can be any object.</span></span>|<span data-ttu-id="e4cb9-187">どのオブジェクトでもかまいません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-187">Can be any object.</span></span>|<span data-ttu-id="e4cb9-188">オブジェクトで [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) を指定するか、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-188">Object must have [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) or implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span>|
|<span data-ttu-id="e4cb9-189">バインドされたオブジェクトからプロパティの変更通知を取得します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-189">Get property change notifications from a bound object.</span></span>|<span data-ttu-id="e4cb9-190">オブジェクトを実装する必要があります[ **INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-190">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx).</span></span>| <span data-ttu-id="e4cb9-191">オブジェクトを実装する必要があります[ **INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-191">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899).</span></span>|<span data-ttu-id="e4cb9-192">オブジェクトを実装する必要があります[ **INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-192">Object must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899).</span></span>|
|<span data-ttu-id="e4cb9-193">コレクションにバインドする。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-193">Bind to a collection.</span></span>| [<span data-ttu-id="e4cb9-194">**List(Of T)**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-194">**List(Of T)**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx)|<span data-ttu-id="e4cb9-195">[**IVector** ](/uwp/api/windows.foundation.collections.ivector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-195">[**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span> <span data-ttu-id="e4cb9-196">参照してください[XAML コントロールの項目。 c++ にバインド/cli WinRT コレクション](../cpp-and-winrt-apis/binding-collection.md)と[コレクション c++/cli WinRT](../cpp-and-winrt-apis/collections.md)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-196">See [XAML items controls; bind to a C++/WinRT collection](../cpp-and-winrt-apis/binding-collection.md) and [Collections with C++/WinRT](../cpp-and-winrt-apis/collections.md).</span></span>| [<span data-ttu-id="e4cb9-197">**ベクター&lt;T&gt;**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-197">**Vector&lt;T&gt;**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx)|
|<span data-ttu-id="e4cb9-198">バインドのコレクションからコレクションの変更通知を取得します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-198">Get collection change notifications from a bound collection.</span></span>|[<span data-ttu-id="e4cb9-199">**ObservableCollection (Of T)**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-199">**ObservableCollection(Of T)**</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx)|<span data-ttu-id="e4cb9-200">[**IObservableVector** ](/uwp/api/windows.foundation.collections.iobservablevector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-200">[**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable).</span></span>|[<span data-ttu-id="e4cb9-201">**IObservableVector&lt;T&gt;**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-201">**IObservableVector&lt;T&gt;**</span></span>](https://msdn.microsoft.com/library/windows/apps/br226052.aspx)|
|<span data-ttu-id="e4cb9-202">バインドをサポートするコレクションを実装する。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-202">Implement a collection that supports binding.</span></span>|<span data-ttu-id="e4cb9-203">[  **List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) を拡張するか、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx)、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/5y536ey6.aspx)(Of [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx))、[**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ienumerable.aspx)、または [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/9eekhta0.aspx)(Of **Object**) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-203">Extend [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) or implement [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx), [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/5y536ey6.aspx)(Of [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)), [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ienumerable.aspx), or [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/9eekhta0.aspx)(Of **Object**).</span></span> <span data-ttu-id="e4cb9-204">汎用の **IList(Of T)** と **IEnumerable(Of T)** へのバインドはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-204">Binding to generic **IList(Of T)** and **IEnumerable(Of T)** is not supported.</span></span>|<span data-ttu-id="e4cb9-205">実装[ **IVector** ](/uwp/api/windows.foundation.collections.ivector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-205">Implement [**IVector**](/uwp/api/windows.foundation.collections.ivector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable).</span></span> <span data-ttu-id="e4cb9-206">参照してください[XAML コントロールの項目。 c++ にバインド/cli WinRT コレクション](../cpp-and-winrt-apis/binding-collection.md)と[コレクション c++/cli WinRT](../cpp-and-winrt-apis/collections.md)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-206">See [XAML items controls; bind to a C++/WinRT collection](../cpp-and-winrt-apis/binding-collection.md) and [Collections with C++/WinRT](../cpp-and-winrt-apis/collections.md).</span></span>|<span data-ttu-id="e4cb9-207">[  **IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableIterable**](https://msdn.microsoft.com/library/windows/apps/Hh701957)、[**IVector**](https://msdn.microsoft.com/library/windows/apps/BR206631)&lt;[**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)^&gt;、[**IIterable**](https://msdn.microsoft.com/library/windows/apps/BR226024)&lt;**Object**^&gt;、**IVector**&lt;[**IInspectable**](https://msdn.microsoft.com/library/BR205821)\*&gt;、または **IIterable**&lt;**IInspectable**\*&gt; を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-207">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979), [**IBindableIterable**](https://msdn.microsoft.com/library/windows/apps/Hh701957), [**IVector**](https://msdn.microsoft.com/library/windows/apps/BR206631)&lt;[**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)^&gt;, [**IIterable**](https://msdn.microsoft.com/library/windows/apps/BR226024)&lt;**Object**^&gt;, **IVector**&lt;[**IInspectable**](https://msdn.microsoft.com/library/BR205821)\*&gt;, or **IIterable**&lt;**IInspectable**\*&gt;.</span></span> <span data-ttu-id="e4cb9-208">汎用の **IVector&lt;T&gt;** と **IIterable&lt;T&gt;** へのバインドはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-208">Binding to generic **IVector&lt;T&gt;** and **IIterable&lt;T&gt;** is not supported.</span></span>|
| <span data-ttu-id="e4cb9-209">コレクションの変更通知をサポートするコレクションを実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-209">Implement a collection that supports collection change notifications.</span></span> | <span data-ttu-id="e4cb9-210">[  **ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-210">Extend [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) or implement (non-generic) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx).</span></span>|<span data-ttu-id="e4cb9-211">実装[ **IObservableVector** ](/uwp/api/windows.foundation.collections.iobservablevector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span><span class="sxs-lookup"><span data-stu-id="e4cb9-211">Implement [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span>|<span data-ttu-id="e4cb9-212">[  **IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979) と [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-212">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979) and [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974).</span></span>|
|<span data-ttu-id="e4cb9-213">段階的読み込みをサポートするコレクションを実装する。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-213">Implement a collection that supports incremental loading.</span></span>|<span data-ttu-id="e4cb9-214">[  **ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-214">Extend [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) or implement (non-generic) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx).</span></span> <span data-ttu-id="e4cb9-215">さらに、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-215">Additionally, implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916).</span></span>|<span data-ttu-id="e4cb9-216">実装[ **IObservableVector** ](/uwp/api/windows.foundation.collections.iobservablevector_t_)の[ **IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)、または[ **IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span><span class="sxs-lookup"><span data-stu-id="e4cb9-216">Implement [**IObservableVector**](/uwp/api/windows.foundation.collections.iobservablevector_t_) of [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable), or [**IBindableObservableVector**](/uwp/api/windows.ui.xaml.interop.ibindableobservablevector).</span></span> <span data-ttu-id="e4cb9-217">さらに、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します</span><span class="sxs-lookup"><span data-stu-id="e4cb9-217">Additionally, implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916)</span></span>|<span data-ttu-id="e4cb9-218">[  **IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974)、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-218">Implement [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979), [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974), and [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916).</span></span>|

<span data-ttu-id="e4cb9-219">段階的読み込みを使うと、任意の大きさのデータ ソースにリスト コントロールをバインドすると同時に、高パフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-219">You can bind list controls to arbitrarily large data sources, and still achieve high performance, by using incremental loading.</span></span> <span data-ttu-id="e4cb9-220">たとえば、一度にすべての結果を読む込むことなく、Bing の画像クエリ結果にリスト コントロールをバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-220">For example, you can bind list controls to Bing image query results without having to load all the results at once.</span></span> <span data-ttu-id="e4cb9-221">この場合、すぐに読み込むのは一部の結果だけで、他の結果は必要に応じて読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-221">Instead, you load only some results immediately, and load additional results as needed.</span></span> <span data-ttu-id="e4cb9-222">増分読み込みをサポートするために実装する必要があります[ **ISupportIncrementalLoading** ](https://msdn.microsoft.com/library/windows/apps/Hh701916)コレクションをサポートするデータ ソースに通知を変更します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-222">To support incremental loading, you must implement [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) on a data source that supports collection change notifications.</span></span> <span data-ttu-id="e4cb9-223">データ バインディング エンジンがより多くのデータを要求する場合は、UI を更新するためにデータ ソースで適切な要求を行い、結果を統合して、適切な通知を送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-223">When the data binding engine requests more data, your data source must make the appropriate requests, integrate the results, and then send the appropriate notifications in order to update the UI.</span></span>

### <a name="binding-target"></a><span data-ttu-id="e4cb9-224">バインディング ターゲット</span><span class="sxs-lookup"><span data-stu-id="e4cb9-224">Binding target</span></span>

<span data-ttu-id="e4cb9-225">以下の 2 つの例で、 **Button.Content**プロパティはバインディング ターゲット、およびバインディング オブジェクトを宣言するマークアップ拡張機能にその値を設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-225">In the two examples below, the **Button.Content** property is the binding target, and its value is set to a markup extension that declares the binding object.</span></span> <span data-ttu-id="e4cb9-226">最初に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) を示し、次に [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-226">First [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) is shown, and then [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span> <span data-ttu-id="e4cb9-227">マークアップでバインディングを宣言する方法は一般的です (便利で、読みやすく、ツールで処理できます)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-227">Declaring bindings in markup is the common case (it's convenient, readable, and toolable).</span></span> <span data-ttu-id="e4cb9-228">ただし、必要な場合は、マークアップを使わずに、命令を使って (プログラムで) [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスのインスタンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-228">But you can avoid markup and imperatively (programmatically) create an instance of the [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) class instead if you need to.</span></span>

```xaml
<Button Content="{x:Bind ...}" ... />
```

```xaml
<Button Content="{Binding ...}" ... />
```

<span data-ttu-id="e4cb9-229">C + を使用している場合/cli WinRT または Visual C コンポーネント拡張 (C +/cli CX) を追加する必要があります、 [ **BindableAttribute** ](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性を使用する任意のランタイム クラス、 [{binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)でマークアップ拡張機能。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-229">If you're using C++/WinRT or Visual C++ component extensions (C++/CX), then you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to any runtime class that you want to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension with.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e4cb9-230">使用している場合[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 [ **BindableAttribute** ](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン (Windows 10、バージョンは 1809 10.0.17763.0 をインストールした場合に使用)、またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-230">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute is available if you've installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later.</span></span> <span data-ttu-id="e4cb9-231">その属性がない場合は、実装する必要があります、 [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを使用するには、 [{binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-231">Without that attribute, you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces in order to be able to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

### <a name="binding-object-declared-using-xbind"></a><span data-ttu-id="e4cb9-232">{x:Bind} を使って宣言されたバインディング オブジェクト</span><span class="sxs-lookup"><span data-stu-id="e4cb9-232">Binding object declared using {x:Bind}</span></span>

<span data-ttu-id="e4cb9-233">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) マークアップを作成する前に必要な手順が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-233">There's one step we need to do before we author our [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) markup.</span></span> <span data-ttu-id="e4cb9-234">マークアップのページを表すクラスからバインディング ソース クラスを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-234">We need to expose our binding source class from the class that represents our page of markup.</span></span> <span data-ttu-id="e4cb9-235">プロパティを追加することで行っている (型の**HostViewModel**ここでは) を**MainPage**クラスのページします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-235">We do that by adding a property (of type **HostViewModel** in this case) to our **MainPage** page class.</span></span>

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

<span data-ttu-id="e4cb9-236">これが完了したら、バインディング オブジェクトを宣言するマークアップを詳しく見ていくことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-236">That done, we can now take a closer look at the markup that declares the binding object.</span></span> <span data-ttu-id="e4cb9-237">次の例では、前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使って、**HostViewModel.NextButtonText** プロパティにバインドされたバインディング ターゲットを示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-237">The example below uses the same **Button.Content** binding target we used in the "Binding target" section earlier, and shows it being bound to the **HostViewModel.NextButtonText** property.</span></span>

```xaml
<!-- MainPage.xaml -->
<Page x:Class="DataBindingInDepth.Mainpage" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

<span data-ttu-id="e4cb9-238">**Path** として指定している値に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-238">Notice the value that we specify for **Path**.</span></span> <span data-ttu-id="e4cb9-239">この値は、ページ自体のコンテキストで解釈されるパスは、ここを参照して、 **ViewModel**だけに追加したプロパティ、 **MainPage**ページ。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-239">This value is interpreted in the context of the page itself, and in this case the path begins by referencing the **ViewModel** property that we just added to the **MainPage** page.</span></span> <span data-ttu-id="e4cb9-240">このプロパティは **HostViewModel** インスタンスを返すため、そのオブジェクトにドットを付けて **HostViewModel.NextButtonText** プロパティにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-240">That property returns a **HostViewModel** instance, and so we can dot into that object to access the **HostViewModel.NextButtonText** property.</span></span> <span data-ttu-id="e4cb9-241">さらに、**Mode** を指定して、[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) の既定値である 1 回限りのバインディングをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-241">And we specify **Mode**, to override the [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) default of one-time.</span></span>

<span data-ttu-id="e4cb9-242">[  **Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-242">The [**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) property supports a variety of syntax options for binding to nested properties, attached properties, and integer and string indexers.</span></span> <span data-ttu-id="e4cb9-243">詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-243">For more info, see [Property-path syntax](https://msdn.microsoft.com/library/windows/apps/Mt185586).</span></span> <span data-ttu-id="e4cb9-244">文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-244">Binding to string indexers gives you the effect of binding to dynamic properties without having to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span> <span data-ttu-id="e4cb9-245">その他の設定については、「[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-245">For other settings, see [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783).</span></span>

<span data-ttu-id="e4cb9-246">説明するため、 **HostViewModel.NextButtonText**プロパティが実際に監視可能な場合、追加、**クリックして**、ボタンのイベント ハンドラーの値を更新**HostViewModel.NextButtonText**.</span><span class="sxs-lookup"><span data-stu-id="e4cb9-246">To illustrate that the **HostViewModel.NextButtonText** property is indeed observable, add a **Click** event handler to the button, and update the value of **HostViewModel.NextButtonText**.</span></span> <span data-ttu-id="e4cb9-247">ビルド、実行、およびボタンの値を表示するボタンをクリックします。**コンテンツ**を更新します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-247">Build, run, and click the button to see the value of the button's **Content** update.</span></span>

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
> <span data-ttu-id="e4cb9-248">変更[ **TextBox.Text** ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)双方向のバインドに送信されるソース、 [ **TextBox** ](https://msdn.microsoft.com/library/windows/apps/BR209683)がフォーカスを失うとすべてのユーザーのキー入力の後。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-248">Changes to [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text) are sent to a two-way bound source when the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) loses focus, and not after every user keystroke.</span></span>

<span data-ttu-id="e4cb9-249">**DataTemplate および x: データ型**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-249">**DataTemplate and x:DataType**</span></span>

<span data-ttu-id="e4cb9-250">[  **DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内で (項目テンプレート、コンテンツ テンプレート、ヘッダー テンプレートのいずれとして使用される場合でも)、**Path** の値はページのコンテキストではなく、テンプレート化されたデータ オブジェクトのコンテキストで解釈されています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-250">Inside a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) (whether used as an item template, a content template, or a header template), the value of **Path** is not interpreted in the context of the page, but in the context of the data object being templated.</span></span> <span data-ttu-id="e4cb9-251">{x:Bind} をデータ テンプレートで使用する場合、コンパイル時にバインディングを検証できるように (バインディング用に効率的なコードを生成できるように) するために、**DataTemplate** では、**x:DataType** を使って、データ オブジェクトの型を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-251">When using {x:Bind} in a data template, so that its bindings can be validated (and efficient code generated for them) at compile-time, the **DataTemplate** needs to declare the type of its data object using **x:DataType**.</span></span> <span data-ttu-id="e4cb9-252">次に示す例は、**SampleDataGroup** オブジェクトのコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-252">The example given below could be used as the **ItemTemplate** of an items control bound to a collection of **SampleDataGroup** objects.</span></span>

```xaml
<DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```

<span data-ttu-id="e4cb9-253">**パス内のオブジェクトの弱い型指定**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-253">**Weakly-typed objects in your Path**</span></span>

<span data-ttu-id="e4cb9-254">たとえば、SampleDataGroup という名前の型があり、Title という名前の文字列プロパティを実装しているとします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-254">Consider for example that you have a type named SampleDataGroup, which implements a string property named Title.</span></span> <span data-ttu-id="e4cb9-255">使用してプロパティ MainPage.SampleDataGroupAsObject、オブジェクトの型ですが、実際に SampleDataGroup のインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-255">And you have a property MainPage.SampleDataGroupAsObject, which is of type object, but which actually returns an instance of SampleDataGroup.</span></span> <span data-ttu-id="e4cb9-256">バインディング `<TextBlock Text="{x:Bind SampleDataGroupAsObject.Title}"/>` は、型オブジェクトで Title プロパティが見つからないため、コンパイル エラーとなります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-256">The binding `<TextBlock Text="{x:Bind SampleDataGroupAsObject.Title}"/>` will result in a compile error because the Title property is not found on the type object.</span></span> <span data-ttu-id="e4cb9-257">これを解決するには、Path 構文に `<TextBlock Text="{x:Bind ((data:SampleDataGroup)SampleDataGroupAsObject).Title}"/>` などのキャストを追加します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-257">The remedy for this is to add a cast to your Path syntax like this: `<TextBlock Text="{x:Bind ((data:SampleDataGroup)SampleDataGroupAsObject).Title}"/>`.</span></span> <span data-ttu-id="e4cb9-258">Element がオブジェクトとして宣言されているが、実際には TextBlock である、`<TextBlock Text="{x:Bind Element.Text}"/>` という例を考えてみます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-258">Here's another example where Element is declared as object but is actually a TextBlock: `<TextBlock Text="{x:Bind Element.Text}"/>`.</span></span> <span data-ttu-id="e4cb9-259">この場合も、`<TextBlock Text="{x:Bind ((TextBlock)Element).Text}"/>` のようにキャストによって問題が解決されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-259">And a cast remedies the issue: `<TextBlock Text="{x:Bind ((TextBlock)Element).Text}"/>`.</span></span>

<span data-ttu-id="e4cb9-260">**場合は、データが非同期的に読み込みます**</span><span class="sxs-lookup"><span data-stu-id="e4cb9-260">**If your data loads asynchronously**</span></span>

<span data-ttu-id="e4cb9-261">ページの部分クラスに、**{x:Bind}** をサポートするコードがコンパイル時に生成されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-261">Code to support **{x:Bind}** is generated at compile-time in the partial classes for your pages.</span></span> <span data-ttu-id="e4cb9-262">これらのファイルは `obj` フォルダー内にあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-262">These files can be found in your `obj` folder, with names like (for C#) `<view name>.g.cs`.</span></span> <span data-ttu-id="e4cb9-263">生成されたコードには、ページの [**Loading**](https://msdn.microsoft.com/library/windows/apps/BR208706) イベントのハンドラーが含まれており、このハンドラーが、ページのバインディングを表す生成されたクラスで **Initialize** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-263">The generated code includes a handler for your page's [**Loading**](https://msdn.microsoft.com/library/windows/apps/BR208706) event, and that handler calls the **Initialize** method on a generated class that represent's your page's bindings.</span></span> <span data-ttu-id="e4cb9-264">次に、**Initialize** が **Update** を呼び出して、バインディング ソースとターゲットの間のデータの移動を開始します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-264">**Initialize** in turn calls **Update** to begin moving data between the binding source and the target.</span></span> <span data-ttu-id="e4cb9-265">**Loading** は、ページまたはユーザー コントロールの最初の測定パスの直前に発生します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-265">**Loading** is raised just before the first measure pass of the page or user control.</span></span> <span data-ttu-id="e4cb9-266">したがって、データが非同期的に読み込まれる場合、**Initialize** が呼び出された時点で準備ができていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-266">So if your data is loaded asynchronously it may not be ready by the time **Initialize** is called.</span></span> <span data-ttu-id="e4cb9-267">そのため、データを読み込んだ後、`this.Bindings.Update();` を呼び出すことによって、1 回限りのバインディングを強制的に実行できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-267">So, after you've loaded data, you can force one-time bindings to be initialized by calling `this.Bindings.Update();`.</span></span> <span data-ttu-id="e4cb9-268">非同期的に読み込まれたデータのバインドを 1 回限りのみ必要な場合は、一方向のバインドがあると、変更をリッスンするよりも、それらがこのように初期化するためにかなり安価です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-268">If you only need one-time bindings for asynchronously-loaded data then it's much cheaper to initialize them this way than it is to have one-way bindings and to listen for changes.</span></span> <span data-ttu-id="e4cb9-269">データがきめ細かく変更されない場合や、特定のアクションの一部として更新される可能性が高い場合は、バインディングを 1 回限りにし、いつでも **Update** を呼び出すことによって、強制的に手動更新を実行できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-269">If your data does not undergo fine-grained changes, and if it's likely to be updated as part of a specific action, then you can make your bindings one-time, and force a manual update at any time with a call to **Update**.</span></span>

> [!NOTE]
> <span data-ttu-id="e4cb9-270">**{0} バインド: x}** 各部への JSON オブジェクトもアヒル型定義のディクショナリなど、遅延バインディング シナリオには適していません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-270">**{x:Bind}** is not suited to late-bound scenarios, such as navigating the dictionary structure of a JSON object, nor duck typing.</span></span> <span data-ttu-id="e4cb9-271">「ダック タイピング」脆弱な形式でプロパティ名の構文の一致に基づく入力するは、(、「場合について説明します、水中、アヒルのように鳴いたらはアヒル」)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-271">"Duck typing" is a weak form of typing based on lexical matches on property names (a in, "if it walks, swims, and quacks like a duck, then it's a duck").</span></span> <span data-ttu-id="e4cb9-272">アヒルへのバインドと、**年齢**プロパティで均等に満たされるように、**人**または**ワイン**オブジェクト (各型があることを前提、**年齢**プロパティ)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-272">With duck typing, a binding to the **Age** property would be equally satisfied with a **Person** or a **Wine** object (assuming that those types each had an **Age** property).</span></span> <span data-ttu-id="e4cb9-273">これらのシナリオを使用して、 **{binding}** マークアップ拡張機能。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-273">For these scenarios, use the **{Binding}** markup extension.</span></span>

### <a name="binding-object-declared-using-binding"></a><span data-ttu-id="e4cb9-274">{Binding} を使って宣言されたバインディング オブジェクト</span><span class="sxs-lookup"><span data-stu-id="e4cb9-274">Binding object declared using {Binding}</span></span>

<span data-ttu-id="e4cb9-275">C + を使用している場合/cli WinRT または Visual C コンポーネント拡張 (C +/cli CX) し、使用する、 [{binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を追加する必要があります、 [ **BindableAttribute** ](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性にバインドする任意のランタイム クラスをします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-275">If you're using C++/WinRT or Visual C++ component extensions (C++/CX) then, to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension, you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to any runtime class that you want to bind to.</span></span> <span data-ttu-id="e4cb9-276">使用する[{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)、その属性は必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-276">To use [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783), you don't need that attribute.</span></span>

```cppwinrt
// HostViewModel.idl
// Add this attribute:
[Windows.UI.Xaml.Data.Bindable]
runtimeclass HostViewModel : Windows.UI.Xaml.Data.INotifyPropertyChanged
...
```

> [!IMPORTANT]
> <span data-ttu-id="e4cb9-277">使用している場合[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 [ **BindableAttribute** ](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン (Windows 10、バージョンは 1809 10.0.17763.0 をインストールした場合に使用)、またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-277">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute is available if you've installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later.</span></span> <span data-ttu-id="e4cb9-278">その属性がない場合は、実装する必要があります、 [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを使用するには、 [{binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-278">Without that attribute, you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces in order to be able to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

<span data-ttu-id="e4cb9-279">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) は、既定で、マークアップ ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) にバインドしていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-279">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) assumes, by default, that you're binding to the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) of your markup page.</span></span> <span data-ttu-id="e4cb9-280">したがって、ページの **DataContext** を、バインディング ソース クラス (ここでは **HostViewModel** 型) のインスタンスに設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-280">So we'll set the **DataContext** of our page to be an instance of our binding source class (of type **HostViewModel** in this case).</span></span> <span data-ttu-id="e4cb9-281">次の例は、バインディング オブジェクトを宣言するマークアップを示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-281">The example below shows the markup that declares the binding object.</span></span> <span data-ttu-id="e4cb9-282">前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使っており、**HostViewModel.NextButtonText** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-282">We use the same **Button.Content** binding target we used in the "Binding target" section earlier, and we bind to the **HostViewModel.NextButtonText** property.</span></span>

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

<span data-ttu-id="e4cb9-283">**Path** として指定している値に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-283">Notice the value that we specify for **Path**.</span></span> <span data-ttu-id="e4cb9-284">この値は、ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) で解釈されます。この例では、**HostViewModel** のインスタンスに設定されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-284">This value is interpreted in the context of the page's [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713), which in this example is set to an instance of **HostViewModel**.</span></span> <span data-ttu-id="e4cb9-285">パスは **HostViewModel.NextButtonText** プロパティを参照します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-285">The path references the **HostViewModel.NextButtonText** property.</span></span> <span data-ttu-id="e4cb9-286">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) の既定値である一方向のバインディングが適切であるため、**Mode** は省略できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-286">We can omit **Mode**, because the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) default of one-way works here.</span></span>

<span data-ttu-id="e4cb9-287">UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) の既定値は、その親から継承された値です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-287">The default value of [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) for a UI element is the inherited value of its parent.</span></span> <span data-ttu-id="e4cb9-288">もちろん **DataContext** を明示的に設定することによってこの既定値 (さらに既定で子に継承される) をオーバーライドすることができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-288">You can of course override that default by setting **DataContext** explicitly, which is in turn inherited by children by default.</span></span> <span data-ttu-id="e4cb9-289">要素で明示的に **DataContext** を設定することは、同じソースを使う複数のバインディングが必要な場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-289">Setting **DataContext** explicitly on an element is useful when you want to have multiple bindings that use the same source.</span></span>

<span data-ttu-id="e4cb9-290">バインディング オブジェクトには **Source** プロパティがあり、その既定値はバインディングが宣言されている UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-290">A binding object has a **Source** property, which defaults to the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) of the UI element on which the binding is declared.</span></span> <span data-ttu-id="e4cb9-291">この既定値をオーバーライドするには、バインディングで **Source**、**RelativeSource**、または **ElementName** を明示的に設定します (詳しくは、「[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-291">You can override this default by setting **Source**, **RelativeSource**, or **ElementName** explicitly on the binding (see [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) for details).</span></span>

<span data-ttu-id="e4cb9-292">内で、 [ **DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348)、 [ **DataContext** ](https://msdn.microsoft.com/library/windows/apps/BR208713)テンプレート化されているデータ オブジェクトが自動的に設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-292">Inside a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348), the [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) is automatically set to the data object being templated.</span></span> <span data-ttu-id="e4cb9-293">次の例は、**Title** と **Description** という名前の文字列プロパティを持つ任意の型のコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます</span><span class="sxs-lookup"><span data-stu-id="e4cb9-293">The example given below could be used as the **ItemTemplate** of an items control bound to a collection of any type that has string properties named **Title** and **Description**.</span></span>

```xaml
<DataTemplate x:Key="SimpleItemTemplate">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{Binding Title}"/>
      <TextBlock Text="{Binding Description"/>
    </StackPanel>
  </DataTemplate>
```

> [!NOTE]
> <span data-ttu-id="e4cb9-294">既定では、変更[ **TextBox.Text** ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)双方向のバインドに送信されるときにソース、 [**テキスト ボックス**](https://msdn.microsoft.com/library/windows/apps/BR209683)がフォーカスを失った。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-294">By default, changes to [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text) are sent to a two-way bound source when the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) loses focus.</span></span> <span data-ttu-id="e4cb9-295">変更をユーザーの各キーストロークの後に送信するには、マークアップのバインディングで **UpdateSourceTrigger** を **PropertyChanged** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-295">To cause changes to be sent after every user keystroke, set **UpdateSourceTrigger** to **PropertyChanged** on the binding in markup.</span></span> <span data-ttu-id="e4cb9-296">**UpdateSourceTrigger** を **Explicit** に設定することによって、変更が送信されるタイミングを完全に制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-296">You can also completely take control of when changes are sent to the source by setting **UpdateSourceTrigger** to **Explicit**.</span></span> <span data-ttu-id="e4cb9-297">次に、テキスト ボックスでのイベント (通常 [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/BR209683)) を処理し、ターゲットで [**GetBindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.getbindingexpression) を呼び出して [**BindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.aspx) オブジェクトを取得します。最後に、[**BindingExpression.UpdateSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.updatesource.aspx) を呼び出して、データ ソースをプログラムで更新します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-297">You then handle events on the text box (typically [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/BR209683)), call [**GetBindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.getbindingexpression) on the target to get a [**BindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.aspx) object, and finally call [**BindingExpression.UpdateSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.updatesource.aspx) to programmatically update the data source.</span></span>

<span data-ttu-id="e4cb9-298">[  **Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-298">The [**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) property supports a variety of syntax options for binding to nested properties, attached properties, and integer and string indexers.</span></span> <span data-ttu-id="e4cb9-299">詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-299">For more info, see [Property-path syntax](https://msdn.microsoft.com/library/windows/apps/Mt185586).</span></span> <span data-ttu-id="e4cb9-300">文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-300">Binding to string indexers gives you the effect of binding to dynamic properties without having to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878).</span></span> <span data-ttu-id="e4cb9-301">[  **ElementName**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.elementname) プロパティは要素間のバインディングに便利です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-301">The [**ElementName**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.elementname) property is useful for element-to-element binding.</span></span> <span data-ttu-id="e4cb9-302">[  **RelativeSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.relativesource) プロパティにはいくつかの用途があり、そのうちの 1 つが、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209391) 内でバインディングをテンプレート化するためのより強力な方法としての用途です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-302">The [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.relativesource) property has several uses, one of which is as a more powerful alternative to template binding inside a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209391).</span></span> <span data-ttu-id="e4cb9-303">その他の設定については、「[{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)」と [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスの説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-303">For other settings, see [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782) and the [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) class.</span></span>

## <a name="what-if-the-source-and-the-target-are-not-the-same-type"></a><span data-ttu-id="e4cb9-304">ソースとターゲットが同じ型ではない場合</span><span class="sxs-lookup"><span data-stu-id="e4cb9-304">What if the source and the target are not the same type?</span></span>

<span data-ttu-id="e4cb9-305">ブール型プロパティの値に基づいて UI 要素の表示を制御する場合、数値の範囲や傾向に応じた色で UI 要素をレンダリングする場合、または文字列を想定している UI 要素のプロパティに日付や時刻の値を表示する場合は、値の型を別の型に変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-305">If you want to control the visibility of a UI element based on the value of a boolean property, or if you want to render a UI element with a color that's a function of a numeric value's range or trend, or if you want to display a date and/or time value in a UI element property that expects a string, then you'll need to convert values from one type to another.</span></span> <span data-ttu-id="e4cb9-306">バインディング ソース クラスから適切な型の別のプロパティを公開し、変換ロジックをカプセル化し、その中でテストできるようにしておくことが、適切なソリューションである場合があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-306">There will be cases where the right solution is to expose another property of the right type from your binding source class, and keep the conversion logic encapsulated and testable there.</span></span> <span data-ttu-id="e4cb9-307">ただし、この方法はソースとターゲットのプロパティの数が多くなり、組み合わせが多くなると、柔軟性も拡張性もありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-307">But that isn't flexible nor scalable when you have large numbers, or large combinations, of source and target properties.</span></span> <span data-ttu-id="e4cb9-308">その場合は、いくつかのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-308">In that case you have a couple of options:</span></span>

* <span data-ttu-id="e4cb9-309">{X:Bind} を使用している場合、関数に直接バインドして変換を行うことができます</span><span class="sxs-lookup"><span data-stu-id="e4cb9-309">If using {x:Bind} then you can bind directly to a function to do that conversion</span></span>
* <span data-ttu-id="e4cb9-310">または、変換を実行するためのオブジェクトである、値コンバーターを指定することができます</span><span class="sxs-lookup"><span data-stu-id="e4cb9-310">Or you can specify a value converter which is an object designed to perform the conversion</span></span> 

## <a name="value-converters"></a><span data-ttu-id="e4cb9-311">値コンバーター</span><span class="sxs-lookup"><span data-stu-id="e4cb9-311">Value Converters</span></span>

<span data-ttu-id="e4cb9-312">[  **DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) 値を月を含む文字列値に変換する、1 回限りまたは一方向のバインディングに適した値コンバーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-312">Here's a value converter, suitable for a one-time or a one-way binding, that converts a [**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) value to a string value containing the month.</span></span> <span data-ttu-id="e4cb9-313">このクラスは、[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903) を実装します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-313">The class implements [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903).</span></span>

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

<span data-ttu-id="e4cb9-314">次に、バインディング オブジェクトのマークアップでその値コンバーターを利用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-314">And here's how you consume that value converter in your binding object markup.</span></span>

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

<span data-ttu-id="e4cb9-315">バインドの [**Converter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converter) パラメーターを定義した場合、[**Convert**](https://msdn.microsoft.com/library/windows/apps/hh701934) メソッドと [**ConvertBack**](https://msdn.microsoft.com/library/windows/apps/hh701938) メソッドがバインド エンジンによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-315">The binding engine calls the [**Convert**](https://msdn.microsoft.com/library/windows/apps/hh701934) and [**ConvertBack**](https://msdn.microsoft.com/library/windows/apps/hh701938) methods if the [**Converter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converter) parameter is defined for the binding.</span></span> <span data-ttu-id="e4cb9-316">ソースからデータが渡されると、バインド エンジンは、**Convert** を呼び出し、返すデータをターゲットに渡します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-316">When data is passed from the source, the binding engine calls **Convert** and passes the returned data to the target.</span></span> <span data-ttu-id="e4cb9-317">ターゲットからデータが渡されると (双方向バインディングの場合)、バインド エンジンは、**ConvertBack** を呼び出し、返すデータをソースに渡します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-317">When data is passed from the target (for a two-way binding), the binding engine calls **ConvertBack** and passes the returned data to the source.</span></span>

<span data-ttu-id="e4cb9-318">コンバーターは、省略可能なパラメーターもあります。[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterlanguage)、変換処理で使用する言語を指定することができますと[ **ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterparameter)パラメーターを渡すことができますが、変換ロジック。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-318">The converter also has optional parameters: [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterlanguage), which allows specifying the language to be used in the conversion, and [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterparameter), which allows passing a parameter for the conversion logic.</span></span> <span data-ttu-id="e4cb9-319">コンバーター パラメーターの使用例については、「[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-319">For an example that uses a converter parameter, see [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903).</span></span>

> [!NOTE]
> <span data-ttu-id="e4cb9-320">変換でエラーがある場合は、例外をスローしません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-320">If there is an error in the conversion, do not throw an exception.</span></span> <span data-ttu-id="e4cb9-321">代わりに [**DependencyProperty.UnsetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyproperty.unsetvalue) を返します。これにより、データ転送が中止されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-321">Instead, return [**DependencyProperty.UnsetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyproperty.unsetvalue), which will stop the data transfer.</span></span>

<span data-ttu-id="e4cb9-322">バインディング ソースを解決できない場合に使用する既定値を表示するには、マークアップのバインディング オブジェクトで **FallbackValue** プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-322">To display a default value to use whenever the binding source cannot be resolved, set the **FallbackValue** property on the binding object in markup.</span></span> <span data-ttu-id="e4cb9-323">これは、変換エラーや書式エラーを処理する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-323">This is useful to handle conversion and formatting errors.</span></span> <span data-ttu-id="e4cb9-324">また、バインド時にソースのプロパティが、型が混在するバインド先のコレクションのどのオブジェクトにも見つからないときにも便利です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-324">It is also useful to bind to source properties that might not exist on all objects in a bound collection of heterogeneous types.</span></span>

<span data-ttu-id="e4cb9-325">テキスト コントロールを文字列でない値にバインドした場合、データ バインディング エンジンは値を文字列に変換します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-325">If you bind a text control to a value that is not a string, the data binding engine will convert the value to a string.</span></span> <span data-ttu-id="e4cb9-326">値が参照型である場合、データ バインディング エンジンは [**ICustomPropertyProvider.GetStringRepresentation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.icustompropertyprovider.getstringrepresentation) または [**IStringable.ToString**](https://msdn.microsoft.com/library/Dn302136) を呼び出すことで文字列の値を取得します。取得できない場合は、[**Object.ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-326">If the value is a reference type, the data binding engine will retrieve the string value by calling [**ICustomPropertyProvider.GetStringRepresentation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.icustompropertyprovider.getstringrepresentation) or [**IStringable.ToString**](https://msdn.microsoft.com/library/Dn302136) if available, and will otherwise call [**Object.ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx).</span></span> <span data-ttu-id="e4cb9-327">ただし、データ バインディング エンジンは基底クラスの実装を隠ぺいする **ToString** の実装を無視することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-327">Note, however, that the binding engine will ignore any **ToString** implementation that hides the base-class implementation.</span></span> <span data-ttu-id="e4cb9-328">代わりに、サブクラスの実装で基底クラスの **ToString** メソッドをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-328">Subclass implementations should override the base class **ToString** method instead.</span></span> <span data-ttu-id="e4cb9-329">同様に、ネイティブ言語では、すべてのマネージ オブジェクトが [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) と [**IStringable**](https://msdn.microsoft.com/library/Dn302135) を実装しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-329">Similarly, in native languages, all managed objects appear to implement [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) and [**IStringable**](https://msdn.microsoft.com/library/Dn302135).</span></span> <span data-ttu-id="e4cb9-330">ただし、**GetStringRepresentation** と **IStringable.ToString** のすべての呼び出しは、**Object.ToString** またはそのオーバーライドされたメソッドに割り振られます。基底クラスの実装を隠ぺいする新しい **ToString** メソッドの実装に割り振られることはありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-330">However, all calls to **GetStringRepresentation** and **IStringable.ToString** are routed to **Object.ToString** or an override of that method, and never to a new **ToString** implementation that hides the base-class implementation.</span></span>

> [!NOTE]
> <span data-ttu-id="e4cb9-331">Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-331">Starting in Windows 10, version 1607, the XAML framework provides a built in boolean to Visibility converter.</span></span> <span data-ttu-id="e4cb9-332">コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-332">The converter maps **true** to the **Visible** enumeration value and **false** to **Collapsed** so you can bind a Visibility property to a boolean without creating a converter.</span></span> <span data-ttu-id="e4cb9-333">組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-333">To use the built in converter, your app's minimum target SDK version must be 14393 or later.</span></span> <span data-ttu-id="e4cb9-334">アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-334">You can't use it when your app targets earlier versions of Windows 10.</span></span> <span data-ttu-id="e4cb9-335">ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-335">For more info about target versions, see [Version adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

## <a name="function-binding-in-xbind"></a><span data-ttu-id="e4cb9-336">{X:Bind} の関数バインド</span><span class="sxs-lookup"><span data-stu-id="e4cb9-336">Function binding in {x:Bind}</span></span>

<span data-ttu-id="e4cb9-337">{x:Bind} は関数となるバインディング パスの最終ステップを有効化します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-337">{x:Bind} enables the final step in a binding path to be a function.</span></span> <span data-ttu-id="e4cb9-338">これを使って変換を実行できます。また 1 つ以上のプロパティに依存するバインディングを実行できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-338">This can be used to perform conversions, and to perform bindings that depend on more than one property.</span></span> <span data-ttu-id="e4cb9-339">参照してください[ **X:bind 関数**](function-bindings.md)</span><span class="sxs-lookup"><span data-stu-id="e4cb9-339">See [**Functions in x:Bind**](function-bindings.md)</span></span>

<span id="resource-dictionaries-with-x-bind"/>

## <a name="resource-dictionaries-with-xbind"></a><span data-ttu-id="e4cb9-340">リソース ディクショナリと {x:Bind}</span><span class="sxs-lookup"><span data-stu-id="e4cb9-340">Resource dictionaries with {x:Bind}</span></span>

<span data-ttu-id="e4cb9-341">[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)はコードの生成に依存するため、**InitializeComponent** (生成されたコードを初期化する) を呼び出すコンストラクターを含むコード ビハインド ファイルが必要です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-341">The [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783) depends on code generation, so it needs a code-behind file containing a constructor that calls **InitializeComponent** (to initialize the generated code).</span></span> <span data-ttu-id="e4cb9-342">ファイル名を参照する代わりに、その型をインスタンス化する (**InitializeComponent** が呼び出される) ことによって、リソース ファイルを再利用します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-342">You re-use the resource dictionary by instantiating its type (so that **InitializeComponent** is called) instead of referencing its filename.</span></span> <span data-ttu-id="e4cb9-343">次の例では、既存のリソース ディクショナリがあり、その中で {x:Bind} を使う場合の対処方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-343">Here's an example of what to do if you have an existing resource dictionary and you want to use {x:Bind} in it.</span></span>

<span data-ttu-id="e4cb9-344">TemplatesResourceDictionary.xaml</span><span class="sxs-lookup"><span data-stu-id="e4cb9-344">TemplatesResourceDictionary.xaml</span></span>

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

<span data-ttu-id="e4cb9-345">TemplatesResourceDictionary.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="e4cb9-345">TemplatesResourceDictionary.xaml.cs</span></span>

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

<span data-ttu-id="e4cb9-346">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="e4cb9-346">MainPage.xaml</span></span>

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

## <a name="event-binding-and-icommand"></a><span data-ttu-id="e4cb9-347">イベント バインディングと ICommand</span><span class="sxs-lookup"><span data-stu-id="e4cb9-347">Event binding and ICommand</span></span>

<span data-ttu-id="e4cb9-348">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) はイベント バインディングと呼ばれる機能をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-348">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) supports a feature called event binding.</span></span> <span data-ttu-id="e4cb9-349">この機能によって、バインディングを使用するイベントのハンドラーを指定できます。これは、コード ビハインド ファイルのメソッドによるイベント処理に対する追加のオプションです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-349">With this feature, you can specify the handler for an event using a binding, which is an additional option on top of handling events with a method on the code-behind file.</span></span> <span data-ttu-id="e4cb9-350">たとえば、**MainPage** クラスに **RootFrame** プロパティがあるとします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-350">Let's say you have a **RootFrame** property on your **MainPage** class.</span></span>

```csharp
public sealed partial class MainPage : Page
{
    ...
    public Frame RootFrame { get { return Window.Current.Content as Frame; } }
}
```

<span data-ttu-id="e4cb9-351">次のように、**RootFrame** プロパティによって返される **Frame** オブジェクトのメソッドに、ボタンの **Click** イベントをバインドできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-351">You can then bind a button's **Click** event to a method on the **Frame** object returned by the **RootFrame** property like this.</span></span> <span data-ttu-id="e4cb9-352">また、ボタンの **IsEnabled** プロパティを、同じ **Frame** の別のメンバーにもバインドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-352">Note that we also bind the button's **IsEnabled** property to another member of the same **Frame**.</span></span>

```xaml
<AppBarButton Icon="Forward" IsCompact="True"
IsEnabled="{x:Bind RootFrame.CanGoForward, Mode=OneWay}"
Click="{x:Bind RootFrame.GoForward}"/>
```

<span data-ttu-id="e4cb9-353">この方法では、オーバーロードされたメソッドを使ってイベントを処理することはできません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-353">Overloaded methods cannot be used to handle an event with this technique.</span></span> <span data-ttu-id="e4cb9-354">また、イベントを処理するメソッドにパラメーターがある場合、すべてのパラメーターがそれぞれ、イベントのすべての型から代入できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-354">Also, if the method that handles the event has parameters then they must all be assignable from the types of all of the event's parameters, respectively.</span></span> <span data-ttu-id="e4cb9-355">この場合、[**Frame.GoForward**](https://msdn.microsoft.com/library/windows/apps/BR242693) はオーバーロードされておらず、パラメーターはありません (ただし、2 つの **object** パラメーターを取る場合でも有効です)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-355">In this case, [**Frame.GoForward**](https://msdn.microsoft.com/library/windows/apps/BR242693) is not overloaded and it has no parameters (but it would still be valid even if it took two **object** parameters).</span></span> <span data-ttu-id="e4cb9-356">[**Frame.GoBack** ](https://msdn.microsoft.com/library/windows/apps/Dn996568)がオーバー ロードされて、そのメソッドを使用してこの方法ではできないようにします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-356">[**Frame.GoBack**](https://msdn.microsoft.com/library/windows/apps/Dn996568) is overloaded, though, so we can't use that method with this technique.</span></span>

<span data-ttu-id="e4cb9-357">イベント バインディングの手法は、コマンドの実装と使用に似ています (コマンドは [**ICommand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.icommand.aspx) インターフェイスを実装するオブジェクトを返すプロパティです)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-357">The event binding technique is similar to implementing and consuming commands (a command is a property that returns an object that implements the [**ICommand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.icommand.aspx) interface).</span></span> <span data-ttu-id="e4cb9-358">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) はいずれもコマンドで動作します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-358">Both [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) and [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) work with commands.</span></span> <span data-ttu-id="e4cb9-359">コマンド パターンを何度も実装する必要はありません。[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) サンプル (Common フォルダー) に含まれている **DelegateCommand** ヘルパー クラスを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-359">So that you don't have to implement the command pattern multiple times, you can use the **DelegateCommand** helper class that you'll find in the [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) sample (in the "Common" folder).</span></span>

## <a name="binding-to-a-collection-of-folders-or-files"></a><span data-ttu-id="e4cb9-360">フォルダーやファイルのコレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="e4cb9-360">Binding to a collection of folders or files</span></span>

<span data-ttu-id="e4cb9-361">[  **Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って、フォルダーとファイルのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-361">You can use the APIs in the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) namespace to retrieve folder and file data.</span></span> <span data-ttu-id="e4cb9-362">ただし、**GetFilesAsync** メソッド、**GetFoldersAsync** メソッド、**GetItemsAsync** メソッドは、リスト コントロールへのバインドに適した値を返さないことがあります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-362">However, the various **GetFilesAsync**, **GetFoldersAsync**, and **GetItemsAsync** methods do not return values that are suitable for binding to list controls.</span></span> <span data-ttu-id="e4cb9-363">代わりに、[**FileInformationFactory**](https://msdn.microsoft.com/library/windows/apps/BR207501) クラスの [**GetVirtualizedFilesVector**](https://msdn.microsoft.com/library/windows/apps/Hh701422) メソッド、[**GetVirtualizedFoldersVector**](https://msdn.microsoft.com/library/windows/apps/Hh701428) メソッド、[**GetVirtualizedItemsVector**](https://msdn.microsoft.com/library/windows/apps/Hh701430) メソッドの戻り値にバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-363">Instead, you must bind to the return values of the [**GetVirtualizedFilesVector**](https://msdn.microsoft.com/library/windows/apps/Hh701422), [**GetVirtualizedFoldersVector**](https://msdn.microsoft.com/library/windows/apps/Hh701428), and [**GetVirtualizedItemsVector**](https://msdn.microsoft.com/library/windows/apps/Hh701430) methods of the [**FileInformationFactory**](https://msdn.microsoft.com/library/windows/apps/BR207501) class.</span></span> <span data-ttu-id="e4cb9-364">[StorageDataSource と GetVirtualizedFilesVector のサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=228621)から抜粋した次のコード例は、一般的な使用パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-364">The following code example from the [StorageDataSource and GetVirtualizedFilesVector sample](https://go.microsoft.com/fwlink/p/?linkid=228621) shows the typical usage pattern.</span></span> <span data-ttu-id="e4cb9-365">アプリ パッケージ マニフェストで **picturesLibrary** 機能を宣言し、ピクチャ ライブラリ フォルダーにピクチャがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-365">Remember to declare the **picturesLibrary** capability in your app package manifest, and confirm that there are pictures in your Pictures library folder.</span></span>

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

<span data-ttu-id="e4cb9-366">通常はこの方法で、ファイルとフォルダーの情報の読み取り専用ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-366">You will typically use this approach to create a read-only view of file and folder info.</span></span> <span data-ttu-id="e4cb9-367">たとえば、ユーザーが音楽ビューで曲を評価できるように、ファイルとフォルダーのプロパティへの双方向のバインドを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-367">You can create two-way bindings to the file and folder properties, for example to let users rate a song in a music view.</span></span> <span data-ttu-id="e4cb9-368">ただし、適切な **SavePropertiesAsync** メソッド ([**MusicProperties.SavePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/BR207760) など) を呼び出すまで、変更は永続化されません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-368">However, any changes are not persisted until you call the appropriate **SavePropertiesAsync** method (for example, [**MusicProperties.SavePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/BR207760)).</span></span> <span data-ttu-id="e4cb9-369">項目からフォーカスが移動したときに選択のリセットがトリガーされるため、変更をコミットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-369">You should commit changes when the item loses focus because this triggers a selection reset.</span></span>

<span data-ttu-id="e4cb9-370">この方法による双方向のバインドは、ミュージックなど、インデックス化された場所でのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-370">Note that two-way binding using this technique works only with indexed locations, such as Music.</span></span> <span data-ttu-id="e4cb9-371">ある場所がインデックス化されているかどうかを確認するには、[**FolderInformation.GetIndexedStateAsync**](https://msdn.microsoft.com/library/windows/apps/BR207627) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-371">You can determine whether a location is indexed by calling the [**FolderInformation.GetIndexedStateAsync**](https://msdn.microsoft.com/library/windows/apps/BR207627) method.</span></span>

<span data-ttu-id="e4cb9-372">仮想化されたベクターは、一部の項目に対して、値の設定の前に **null** を返す場合があることにも注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-372">Note also that a virtualized vector can return **null** for some items before it populates their value.</span></span> <span data-ttu-id="e4cb9-373">たとえば、仮想化されたベクターにバインドされたリスト コントロールの [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) 値を使う前に、**null** をチェックする必要があります。または、代わりに [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/BR209768) を使います。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-373">For example, you should check for **null** before you use the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) value of a list control bound to a virtualized vector, or use [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/BR209768) instead.</span></span>

## <a name="binding-to-data-grouped-by-a-key"></a><span data-ttu-id="e4cb9-374">キーでグループ化されたデータへのバインド</span><span class="sxs-lookup"><span data-stu-id="e4cb9-374">Binding to data grouped by a key</span></span>

<span data-ttu-id="e4cb9-375">項目のフラット コレクションを作成した場合 (によって表されますたとえば、ブック、 **BookSku**クラス) をキーとして共通のプロパティを使用して、項目をグループ化すると (、 **BookSku.AuthorName**プロパティなど)、。結果をグループ化されたデータと呼びます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-375">If you take a flat collection of items (books, for example, represented by a **BookSku** class) and you group the items by using a common property as a key (the **BookSku.AuthorName** property, for example) then the result is called grouped data.</span></span> <span data-ttu-id="e4cb9-376">データをグループ化すると、フラットなコレクションではなくなります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-376">When you group data, it is no longer a flat collection.</span></span> <span data-ttu-id="e4cb9-377">グループ化されたデータは、各グループ オブジェクトが、グループ オブジェクトのコレクション</span><span class="sxs-lookup"><span data-stu-id="e4cb9-377">Grouped data is a collection of group objects, where each group object has</span></span>

- <span data-ttu-id="e4cb9-378">キーと</span><span class="sxs-lookup"><span data-stu-id="e4cb9-378">a key, and</span></span>
- <span data-ttu-id="e4cb9-379">プロパティがそのキーに一致する項目のコレクション。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-379">a collection of items whose property matches that key.</span></span>

<span data-ttu-id="e4cb9-380">結果、作成者の名前で、ブックをグループ化の結果の各グループには、作成者名グループのコレクションでブックの「例をもう一度実行するには</span><span class="sxs-lookup"><span data-stu-id="e4cb9-380">To take the books example again, the result of grouping the books by author name results in a collection of author name groups where each group has</span></span>

- <span data-ttu-id="e4cb9-381">である作成者の名前、キーと</span><span class="sxs-lookup"><span data-stu-id="e4cb9-381">a key, which is an author name, and</span></span>
- <span data-ttu-id="e4cb9-382">コレクション、 **BookSku**s が**AuthorName**プロパティ グループのキーに一致します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-382">a collection of the **BookSku**s whose **AuthorName** property matches the group's key.</span></span>

<span data-ttu-id="e4cb9-383">一般的に、コレクションを表示するには、項目コントロール [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/BR242828) ([**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) など) を、コレクションを返すプロパティに直接バインドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-383">In general, to display a collection, you bind the [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/BR242828) of an items control (such as [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) or [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705)) directly to a property that returns a collection.</span></span> <span data-ttu-id="e4cb9-384">項目のフラットなコレクションの場合は、何も特別なことをする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-384">If that's a flat collection of items then you don't need to do anything special.</span></span> <span data-ttu-id="e4cb9-385">一方、グループ オブジェクトのコレクションの場合 (グループ化されたデータにバインドしている場合など) は、項目コントロールとバインディング ソースの間に存在する、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) と呼ばれる中間オブジェクトのサービスが必要です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-385">But if it's a collection of group objects (as it is when binding to grouped data) then you need the services of an intermediary object called a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) which sits between the items control and the binding source.</span></span> <span data-ttu-id="e4cb9-386">グループ化されたデータを返すプロパティに **CollectionViewSource** をバインドし、項目コントロールを **CollectionViewSource** にバンドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-386">You bind the **CollectionViewSource** to the property that returns grouped data, and you bind the items control to the **CollectionViewSource**.</span></span> <span data-ttu-id="e4cb9-387">**CollectionViewSource** の追加の付加価値として現在の項目を追跡できるため、複数の項目コントロールをすべて同じ **CollectionViewSource** にバインドすることによって同期させることができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-387">An extra value-add of a **CollectionViewSource** is that it keeps track of the current item, so you can keep more than one items control in sync by binding them all to the same **CollectionViewSource**.</span></span> <span data-ttu-id="e4cb9-388">[  **CollectionViewSource.View**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.view) プロパティによって返されるオブジェクトの [**ICollectionView.CurrentItem**](https://msdn.microsoft.com/library/windows/apps/BR209857) プロパティによって、現在の項目にプログラムでアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-388">You can also access the current item programmatically through the [**ICollectionView.CurrentItem**](https://msdn.microsoft.com/library/windows/apps/BR209857) property of the object returned by the [**CollectionViewSource.View**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.view) property.</span></span>

<span data-ttu-id="e4cb9-389">[  **CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) のグループ化機能をアクティブにするには、[**IsSourceGrouped**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.issourcegrouped) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-389">To activate the grouping facility of a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833), set [**IsSourceGrouped**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.issourcegrouped) to **true**.</span></span> <span data-ttu-id="e4cb9-390">[  **ItemsPath**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.itemspath) プロパティも設定する必要があるかどうかは、グループ オブジェクトを作成する方法に依存します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-390">Whether you also need to set the [**ItemsPath**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.itemspath) property depends on exactly how you author your group objects.</span></span> <span data-ttu-id="e4cb9-391">グループ オブジェクトを作成するには、"グループである" パターンと "グループを保持する" パターンの 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-391">There are two ways to author a group object: the "is-a-group" pattern, and the "has-a-group" pattern.</span></span> <span data-ttu-id="e4cb9-392">"グループである" パターンでは、グループ オブジェクトはコレクション型から派生 (たとえば、**List&lt;T&gt;**) から派生するため、グループ オブジェクトは実際にそれ自体が項目のグループです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-392">In the "is-a-group" pattern, the group object derives from a collection type (for example, **List&lt;T&gt;**), so the group object actually is itself the group of items.</span></span> <span data-ttu-id="e4cb9-393">このパターンでは、**ItemsPath** を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-393">With this pattern you do not need to set **ItemsPath**.</span></span> <span data-ttu-id="e4cb9-394">"グループを保持する" パターンでは、グループ オブジェクトはコレクション型 (**List&lt;T&gt;** など) の 1 つまたは複数のプロパティを持つため、グループは、プロパティの形式で項目のグループ (または複数のプロパティの形式で項目の複数のグループ) を "保持" します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-394">In the "has-a-group" pattern, the group object has one or more properties of a collection type (such as **List&lt;T&gt;**), so the group "has a" group of items in the form of a property (or several groups of items in the form of several properties).</span></span> <span data-ttu-id="e4cb9-395">このパターンでは、**ItemsPath** を、項目のグループを含むプロパティの名前に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-395">With this pattern you need to set **ItemsPath** to the name of the property that contains the group of items.</span></span>

<span data-ttu-id="e4cb9-396">次の例は、"グループを保持する" パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-396">The example below illustrates the "has-a-group" pattern.</span></span> <span data-ttu-id="e4cb9-397">ページ クラスには [**ViewModel**](https://msdn.microsoft.com/library/windows/apps/BR208713) という名前のプロパティがあります。このプロパティはビュー モデルのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-397">The page class has a property named [**ViewModel**](https://msdn.microsoft.com/library/windows/apps/BR208713), which returns an instance of our view model.</span></span> <span data-ttu-id="e4cb9-398">[  **CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) はビュー モデルの **Authors** プロパティにバインドされ (**Authors** はグループ オブジェクトのコレクション)、それがグループ化された項目を格納する **Author.BookSkus** プロパティであることも指定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-398">The [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) binds to the **Authors** property of the view model (**Authors** is the collection of group objects) and also specifies that it's the **Author.BookSkus** property that contains the grouped items.</span></span> <span data-ttu-id="e4cb9-399">最後に、[**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) は **CollectionViewSource** にバインドされ、グループ内の項目をレンダリングできるようにグループのスタイルが定義されています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-399">Finally, the [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) is bound to the **CollectionViewSource**, and has its group style defined so that it can render the items in groups.</span></span>

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

<span data-ttu-id="e4cb9-400">"グループである" パターンは、2 つの方法のいずれかで実装できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-400">You can implement the "is-a-group" pattern in one of two ways.</span></span> <span data-ttu-id="e4cb9-401">1 つは、独自のグループ クラスを作成する方法です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-401">One way is to author your own group class.</span></span> <span data-ttu-id="e4cb9-402">**List&lt;T&gt;** からクラスを派生させます (ここで *T* は項目の型です)。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-402">Derive the class from **List&lt;T&gt;** (where *T* is the type of the items).</span></span> <span data-ttu-id="e4cb9-403">たとえば、`public class Author : List<BookSku>` と記述します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-403">For example, `public class Author : List<BookSku>`.</span></span> <span data-ttu-id="e4cb9-404">もう 1 つは、**BookSku** 項目の同様のプロパティ値から、動的にグループ オブジェクト (とグループ クラス) を動的に作成する [LINQ](https://msdn.microsoft.com/library/bb397926.aspx) 式を使う方法です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-404">The second way is to use a [LINQ](https://msdn.microsoft.com/library/bb397926.aspx) expression to dynamically create group objects (and a group class) from like property values of the **BookSku** items.</span></span> <span data-ttu-id="e4cb9-405">このアプローチ (項目のフラットな一覧のみを保持し、必要に応じてグループ化する) は、クラウド サービスのデータにアクセスするアプリで一般的です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-405">This approach—maintaining only a flat list of items and grouping them together on the fly—is typical of an app that accesses data from a cloud service.</span></span> <span data-ttu-id="e4cb9-406">著者やジャンルなどに基づいて書籍を柔軟にグループ化することができます。**Author** や **Genre** などの特別なグループ クラスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-406">You get the flexibility to group books by author or by genre (for example) without needing special group classes such as **Author** and **Genre**.</span></span>

<span data-ttu-id="e4cb9-407">次の例は、[LINQ](https://msdn.microsoft.com/library/bb397926.aspx) を使用した "グループである" パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-407">The example below illustrates the "is-a-group" pattern using [LINQ](https://msdn.microsoft.com/library/bb397926.aspx).</span></span> <span data-ttu-id="e4cb9-408">今回は、書籍をジャンルでグループ化し、グループ ヘッダーにジャンル名と共に表示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-408">This time we group books by genre, displayed with the genre name in the group headers.</span></span> <span data-ttu-id="e4cb9-409">これは、グループの [**Key**](https://msdn.microsoft.com/library/windows/apps/bb343251.aspx) の値に関連する "Key" プロパティ パスによって示されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-409">This is indicated by the "Key" property path in reference to the group [**Key**](https://msdn.microsoft.com/library/windows/apps/bb343251.aspx) value.</span></span>

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

<span data-ttu-id="e4cb9-410">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) をデータ テンプレートと共に使う場合、**x:DataType** 値を設定することによって、バインド先の型を指定する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-410">Remember that when using [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) with data templates we need to indicate the type being bound to by setting an **x:DataType** value.</span></span> <span data-ttu-id="e4cb9-411">型がジェネリックである場合、マークアップでは表現できないため、グループ スタイル ヘッダー テンプレート内で代わりに [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-411">If the type is generic then we can't express that in markup so we need to use [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) instead in the group style header template.</span></span>

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

<span data-ttu-id="e4cb9-412">[  **SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/Hh702601) コントロールは、ユーザーがグループ化されたデータを表示したり、データ間を移動したりするための優れた方法です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-412">A [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/Hh702601) control is a great way for your users to view and navigate grouped data.</span></span> <span data-ttu-id="e4cb9-413">[Bookstore2](https://go.microsoft.com/fwlink/?linkid=532952) サンプル アプリは、**SemanticZoom** の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-413">The [Bookstore2](https://go.microsoft.com/fwlink/?linkid=532952) sample app illustrates how to use the **SemanticZoom**.</span></span> <span data-ttu-id="e4cb9-414">このアプリでは、著者別にグループ化された書籍の一覧を表示する (拡大表示ビュー) ことも、縮小して著者のジャンプ リストを表示する (縮小表示ビュー) こともできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-414">In that app, you can view a list of books grouped by author (the zoomed-in view) or you can zoom out to see a jump list of authors (the zoomed-out view).</span></span> <span data-ttu-id="e4cb9-415">ジャンプ リストを使うと、書籍の一覧をスクロールするよりもすばやく移動することができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-415">The jump list affords much quicker navigation than scrolling through the list of books.</span></span> <span data-ttu-id="e4cb9-416">拡大表示ビューと縮小表示ビューは、実際には、同じ **CollectionViewSource** にバインドされた **ListView** または **GridView** コントロールです。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-416">The zoomed-in and zoomed-out views are actually **ListView** or **GridView** controls bound to the same **CollectionViewSource**.</span></span>

![SemanticZoom の図](images/sezo.png)

<span data-ttu-id="e4cb9-418">階層データ (カテゴリ内のサブカテゴリなど) にバインドする場合、一連の項目コントロールを使って、UI に階層レベルを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-418">When you bind to hierarchical data—such as subcategories within categories—you can choose to display the hierarchical levels in your UI with a series of items controls.</span></span> <span data-ttu-id="e4cb9-419">1 つの項目コントロールで項目を選ぶと、後続する項目コントロールの内容に反映されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-419">A selection in one items control determines the contents of subsequent items controls.</span></span> <span data-ttu-id="e4cb9-420">各リストをそれぞれの [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスにバインドし、**CollectionViewSource** インスタンスをチェーン形式でバインドすることで、これらのリストの同期を保つことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-420">You can keep the lists synchronized by binding each list to its own [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) and binding the **CollectionViewSource** instances together in a chain.</span></span> <span data-ttu-id="e4cb9-421">これは、マスター/詳細 (またはリスト/詳細) ビューと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-421">This is called a master/details (or list/details) view.</span></span> <span data-ttu-id="e4cb9-422">詳しくは、「[階層データにバインドし、マスター/詳細ビューを作る方法](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-422">For more info, see [How to bind to hierarchical data and create a master/details view](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md).</span></span>

<span id="debugging"/>

## <a name="diagnosing-and-debugging-data-binding-problems"></a><span data-ttu-id="e4cb9-423">データ バインディングに関する問題の診断とデバッグ</span><span class="sxs-lookup"><span data-stu-id="e4cb9-423">Diagnosing and debugging data binding problems</span></span>

<span data-ttu-id="e4cb9-424">バインド マークアップには、プロパティ (と、C# では場合によってフィールドとメソッド) の名前が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-424">Your binding markup contains the names of properties (and, for C#, sometimes fields and methods).</span></span> <span data-ttu-id="e4cb9-425">したがって、プロパティの名前を変更するときに、それを参照するすべてのバインディングを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-425">So when you rename a property, you'll also need to change any binding that references it.</span></span> <span data-ttu-id="e4cb9-426">この処理を忘れることは、データ バインディングのバグの一般的な例であり、アプリは正しくコンパイルまたは実行されません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-426">Forgetting to do that leads to a typical example of a data binding bug, and your app either won't compile or won't run correctly.</span></span>

<span data-ttu-id="e4cb9-427">[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) によって作成されたバインディング オブジェクトは、ほとんど機能的に同等です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-427">The binding objects created by [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) and [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) are largely functionally equivalent.</span></span> <span data-ttu-id="e4cb9-428">ただし、{x:Bind} にはバインディング ソースの型情報が含まれ、コンパイル時にソース コードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-428">But {x:Bind} has type information for the binding source, and it generates source code at compile-time.</span></span> <span data-ttu-id="e4cb9-429">{x:Bind} を使うと、コードの残りの部分で取得できるものと同じ種類の問題の検出を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-429">With {x:Bind} you get the same kind of problem detection that you get with the rest of your code.</span></span> <span data-ttu-id="e4cb9-430">これには、コンパイル時のバインド式の検証や、ページの部分クラスとして生成されたソース コード内でのブレークポイント設定によるデバッグが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-430">That includes compile-time validation of your binding expressions, and debugging by setting breakpoints in the source code generated as the partial class for your page.</span></span> <span data-ttu-id="e4cb9-431">これらのクラスは `obj` フォルダー内のファイルにあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-431">These classes can be found in the files in your `obj` folder, with names like (for C#) `<view name>.g.cs`).</span></span> <span data-ttu-id="e4cb9-432">バインディングに問題がある場合は、Microsoft Visual Studio デバッガーで、**[処理されない例外で中断]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-432">If you have a problem with a binding then turn on **Break On Unhandled Exceptions** in the Microsoft Visual Studio debugger.</span></span> <span data-ttu-id="e4cb9-433">デバッガーはその時点での実行を中断し、問題のある点をデバッグすることができます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-433">The debugger will break execution at that point, and you can then debug what has gone wrong.</span></span> <span data-ttu-id="e4cb9-434">{x:Bind} によって生成されたコードは、バインディング ソース ノードのグラフの各部分で同じパターンに従うため、この情報を **[コール スタック]** ウィンドウで使って、問題の原因となった呼び出しのシーケンスを特定できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-434">The code generated by {x:Bind} follows the same pattern for each part of the graph of binding source nodes, and you can use the info in the **Call Stack** window to help determine the sequence of calls that led up to the problem.</span></span>

<span data-ttu-id="e4cb9-435">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) には、バインディング ソースの型情報はありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-435">[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) does not have type information for the binding source.</span></span> <span data-ttu-id="e4cb9-436">ただし、デバッガーがアタッチされたアプリを実行すると、バインド エラーがある場合は Visual Studio の **[出力]** ウィンドウにそのエラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-436">But when you run your app with the debugger attached, any binding errors appear in the **Output** window in Visual Studio.</span></span>

## <a name="creating-bindings-in-code"></a><span data-ttu-id="e4cb9-437">コードでのバインドの作成</span><span class="sxs-lookup"><span data-stu-id="e4cb9-437">Creating bindings in code</span></span>

<span data-ttu-id="e4cb9-438">**注**  このセクションにのみ該当[{binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)作成できないため、 [{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)コードでバインドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-438">**Note**  This section only applies to [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782), because you can't create [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) bindings in code.</span></span> <span data-ttu-id="e4cb9-439">ただし、{x:Bind} と同じメリットを、[**DependencyObject.RegisterPropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx) によって実現できます。これにより、すべての依存関係プロパティについての変更通知を登録できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-439">However, some of the same benefits of {x:Bind} can be achieved with [**DependencyObject.RegisterPropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx), which enables you to register for change notifications on any dependency property.</span></span>

<span data-ttu-id="e4cb9-440">XAML の代わりに手続き型コードを使っても UI 要素をデータに接続できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-440">You can also connect UI elements to data using procedural code instead of XAML.</span></span> <span data-ttu-id="e4cb9-441">そのためには、新しい [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) オブジェクトを作成し、適切なプロパティを設定してから、[**FrameworkElement.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257.aspx) または [**BindingOperations.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244376.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-441">To do this, create a new [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) object, set the appropriate properties, then call [**FrameworkElement.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257.aspx) or [**BindingOperations.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244376.aspx).</span></span> <span data-ttu-id="e4cb9-442">バインドをプログラムで作成すると、Binding プロパティの値を実行時に選択する場合や、複数のコントロール間で 1 つのバインドを共有する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-442">Creating bindings programmatically is useful when you want to choose the binding property values at run-time or share a single binding among multiple controls.</span></span> <span data-ttu-id="e4cb9-443">ただし、**SetBinding** の呼び出し後は Binding プロパティの値を変更できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-443">Note, however, that you cannot change the binding property values after you call **SetBinding**.</span></span>

<span data-ttu-id="e4cb9-444">次の例では、バインドをコードで実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-444">The following example shows how to implement a binding in code.</span></span>

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

## <a name="xbind-and-binding-feature-comparison"></a><span data-ttu-id="e4cb9-445">{x:Bind} と {Binding} の機能の比較</span><span class="sxs-lookup"><span data-stu-id="e4cb9-445">{x:Bind} and {Binding} feature comparison</span></span>

| <span data-ttu-id="e4cb9-446">機能</span><span class="sxs-lookup"><span data-stu-id="e4cb9-446">Feature</span></span> | <span data-ttu-id="e4cb9-447">{x:Bind}</span><span class="sxs-lookup"><span data-stu-id="e4cb9-447">{x:Bind}</span></span> | <span data-ttu-id="e4cb9-448">{Binding}</span><span class="sxs-lookup"><span data-stu-id="e4cb9-448">{Binding}</span></span> | <span data-ttu-id="e4cb9-449">メモ</span><span class="sxs-lookup"><span data-stu-id="e4cb9-449">Notes</span></span> |
|---------|----------|-----------|-------|
| <span data-ttu-id="e4cb9-450">Path が既定のプロパティである</span><span class="sxs-lookup"><span data-stu-id="e4cb9-450">Path is the default property</span></span> | `{x:Bind a.b.c}` | `{Binding a.b.c}` | | 
| <span data-ttu-id="e4cb9-451">Path プロパティ</span><span class="sxs-lookup"><span data-stu-id="e4cb9-451">Path property</span></span> | `{x:Bind Path=a.b.c}` | `{Binding Path=a.b.c}` | <span data-ttu-id="e4cb9-452">x:Bind では、Path は既定で DataContext ではなく、Page をルートにします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-452">In x:Bind, Path is rooted at the Page by default, not the DataContext.</span></span> | 
| <span data-ttu-id="e4cb9-453">Indexer</span><span class="sxs-lookup"><span data-stu-id="e4cb9-453">Indexer</span></span> | `{x:Bind Groups[2].Title}` | `{Binding Groups[2].Title}` | <span data-ttu-id="e4cb9-454">コレクション内で指定した項目にバインドします。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-454">Binds to the specified item in the collection.</span></span> <span data-ttu-id="e4cb9-455">整数ベースのインデックスのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-455">Only integer-based indexes are supported.</span></span> | 
| <span data-ttu-id="e4cb9-456">添付プロパティ</span><span class="sxs-lookup"><span data-stu-id="e4cb9-456">Attached properties</span></span> | `{x:Bind Button22.(Grid.Row)}` | `{Binding Button22.(Grid.Row)}` | <span data-ttu-id="e4cb9-457">添付プロパティは、かっこを使って指定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-457">Attached properties are specified using parentheses.</span></span> <span data-ttu-id="e4cb9-458">プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-458">If the property is not declared in a XAML namespace, then prefix it with an xml namespace, which should be mapped to a code namespace at the head of the document.</span></span> | 
| <span data-ttu-id="e4cb9-459">キャスト</span><span class="sxs-lookup"><span data-stu-id="e4cb9-459">Casting</span></span> | `{x:Bind groups[0].(data:SampleDataGroup.Title)}` | <span data-ttu-id="e4cb9-460">必要ありません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-460">Not needed.</span></span> | <span data-ttu-id="e4cb9-461">キャストはかっこを使って指定します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-461">Casts are specified using parentheses.</span></span> <span data-ttu-id="e4cb9-462">プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-462">If the property is not declared in a XAML namespace, then prefix it with an xml namespace, which should be mapped to a code namespace at the head of the document.</span></span> | 
| <span data-ttu-id="e4cb9-463">Converter</span><span class="sxs-lookup"><span data-stu-id="e4cb9-463">Converter</span></span> | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}}` | <span data-ttu-id="e4cb9-464">コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-464">Converters must be declared at the root of the Page/ResourceDictionary, or in App.xaml.</span></span> | 
| <span data-ttu-id="e4cb9-465">ConverterParameter、ConverterLanguage</span><span class="sxs-lookup"><span data-stu-id="e4cb9-465">ConverterParameter, ConverterLanguage</span></span> | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | <span data-ttu-id="e4cb9-466">コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-466">Converters must be declared at the root of the Page/ResourceDictionary, or in App.xaml.</span></span> | 
| <span data-ttu-id="e4cb9-467">TargetNullValue</span><span class="sxs-lookup"><span data-stu-id="e4cb9-467">TargetNullValue</span></span> | `{x:Bind Name, TargetNullValue=0}` | `{Binding Name, TargetNullValue=0}` | <span data-ttu-id="e4cb9-468">バインド式のリーフが null の場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-468">Used when the leaf of the binding expression is null.</span></span> <span data-ttu-id="e4cb9-469">文字列値の場合は単一引用符を使用します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-469">Use single quotes for a string value.</span></span> | 
| <span data-ttu-id="e4cb9-470">FallbackValue</span><span class="sxs-lookup"><span data-stu-id="e4cb9-470">FallbackValue</span></span> | `{x:Bind Name, FallbackValue='empty'}` | `{Binding Name, FallbackValue='empty'}` | <span data-ttu-id="e4cb9-471">バインディングのパスの一部 (リーフを除く) が null の場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-471">Used when any part of the path for the binding (except for the leaf) is null.</span></span> | 
| <span data-ttu-id="e4cb9-472">ElementName</span><span class="sxs-lookup"><span data-stu-id="e4cb9-472">ElementName</span></span> | `{x:Bind slider1.Value}` | `{Binding Value, ElementName=slider1}` | <span data-ttu-id="e4cb9-473">{x:Bind} によって、フィールドにバインドしています。Path は既定で Page をルートとするため、名前付きの要素はそのフィールドを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-473">With {x:Bind} you're binding to a field; Path is rooted at the Page by default, so any named element can be accessed via its field.</span></span> | 
| <span data-ttu-id="e4cb9-474">RelativeSource:Self (自己)</span><span class="sxs-lookup"><span data-stu-id="e4cb9-474">RelativeSource: Self</span></span> | `<Rectangle x:Name="rect1" Width="200" Height="{x:Bind rect1.Width}" ... />` | `<Rectangle Width="200" Height="{Binding Width, RelativeSource={RelativeSource Self}}" ... />` | <span data-ttu-id="e4cb9-475">{x:Bind} では、要素に名前を付けて、Path でその名前を使います。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-475">With {x:Bind}, name the element and use its name in Path.</span></span> | 
| <span data-ttu-id="e4cb9-476">RelativeSource:TemplatedParent</span><span class="sxs-lookup"><span data-stu-id="e4cb9-476">RelativeSource: TemplatedParent</span></span> | <span data-ttu-id="e4cb9-477">不要</span><span class="sxs-lookup"><span data-stu-id="e4cb9-477">Not needed</span></span> | `{Binding <path>, RelativeSource={RelativeSource TemplatedParent}}` | <span data-ttu-id="e4cb9-478">{X:bind} TargetType ControlTemplate にした場合は、親テンプレートにバインドすることを示します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-478">With {x:Bind} TargetType on ControlTemplate indicates binding to template parent.</span></span> <span data-ttu-id="e4cb9-479">{バインド} たいていの通常のテンプレート バインディング コントロール テンプレートで使用できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-479">For {Binding} Regular template binding can be used in control templates for most uses.</span></span> <span data-ttu-id="e4cb9-480">ただし、コンバーターまたは双方向バインディングを使用する必要がある場合は TemplatedParent を使います。<</span><span class="sxs-lookup"><span data-stu-id="e4cb9-480">But use TemplatedParent where you need to use a converter, or a two-way binding.<</span></span> | 
| <span data-ttu-id="e4cb9-481">Source</span><span class="sxs-lookup"><span data-stu-id="e4cb9-481">Source</span></span> | <span data-ttu-id="e4cb9-482">不要</span><span class="sxs-lookup"><span data-stu-id="e4cb9-482">Not needed</span></span> | `<ListView ItemsSource="{Binding Orders, Source={StaticResource MyData}}"/>` | <span data-ttu-id="e4cb9-483">{X:bind} の名前付きの要素を直接に使用できる、プロパティまたは静的のパスを使用します。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-483">For {x:Bind} you can directly use the named element, use a property or a static path.</span></span> | 
| <span data-ttu-id="e4cb9-484">Mode</span><span class="sxs-lookup"><span data-stu-id="e4cb9-484">Mode</span></span> | `{x:Bind Name, Mode=OneWay}` | `{Binding Name, Mode=TwoWay}` | <span data-ttu-id="e4cb9-485">Mode には、OneTime、OneWay、TwoWay を指定できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-485">Mode can be OneTime, OneWay, or TwoWay.</span></span> <span data-ttu-id="e4cb9-486">{x:Bind} の既定値は OneTime で、{Binding} の既定値は OneWay です。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-486">{x:Bind} defaults to OneTime; {Binding} defaults to OneWay.</span></span> | 
| <span data-ttu-id="e4cb9-487">UpdateSourceTrigger</span><span class="sxs-lookup"><span data-stu-id="e4cb9-487">UpdateSourceTrigger</span></span> | `{x:Bind Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}` | `{Binding UpdateSourceTrigger=PropertyChanged}` | <span data-ttu-id="e4cb9-488">UpdateSourceTrigger には、Default、LostFocus、PropertyChanged を指定できます。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-488">UpdateSourceTrigger can be Default, LostFocus, or PropertyChanged.</span></span> <span data-ttu-id="e4cb9-489">{x:Bind} では、UpdateSourceTrigger=Explicit はサポートされません。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-489">{x:Bind} does not support UpdateSourceTrigger=Explicit.</span></span> <span data-ttu-id="e4cb9-490">{x:Bind} では、TextBox.Text を除くすべての場合に PropertyChanged 動作を使います。TextBox.Text の場合は LostFocus 動作を使います。</span><span class="sxs-lookup"><span data-stu-id="e4cb9-490">{x:Bind} uses PropertyChanged behavior for all cases except TextBox.Text, where it uses LostFocus behavior.</span></span> | 


