---
author: mcleblanc
ms.assetid: A9D54DEC-CD1B-4043-ADE4-32CD4977D1BF
title: データ バインディングの概要
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目のコントロールを項目のコレクションにバインドする方法を説明します。
ms.author: markl
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: c088aa6a2a8b1922eb93ec758dcda8c9a5ec8965
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4357664"
---
# <a name="data-binding-overview"></a><span data-ttu-id="d1c35-104">データ バインディングの概要</span><span class="sxs-lookup"><span data-stu-id="d1c35-104">Data binding overview</span></span>

<span data-ttu-id="d1c35-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-105">This topic shows you how to bind a control (or other UI element) to a single item or bind an items control to a collection of items in a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="d1c35-106">また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-106">In addition, we show how to control the rendering of items, implement a details view based on a selection, and convert data for display.</span></span> <span data-ttu-id="d1c35-107">詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-107">For more detailed info, see [Data binding in depth](data-binding-in-depth.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d1c35-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="d1c35-108">Prerequisites</span></span>

<span data-ttu-id="d1c35-109">このトピックでは、基本的な UWP アプリを作成できることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d1c35-109">This topic assumes that you know how to create a basic UWP app.</span></span> <span data-ttu-id="d1c35-110">初めての UWP アプリを作成する方法について、詳しくは「[Windows アプリの概要](https://developer.microsoft.com/windows/getstarted)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-110">For instructions on creating your first UWP app, see [Get started with Windows apps](https://developer.microsoft.com/windows/getstarted).</span></span>

## <a name="create-the-project"></a><span data-ttu-id="d1c35-111">プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="d1c35-111">Create the project</span></span>

<span data-ttu-id="d1c35-112">最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-112">Create a new **Blank Application (Windows Universal)** project.</span></span> <span data-ttu-id="d1c35-113">プロジェクトに "Quickstart" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-113">Name it "Quickstart".</span></span>

## <a name="binding-to-a-single-item"></a><span data-ttu-id="d1c35-114">単一の項目へのバインド</span><span class="sxs-lookup"><span data-stu-id="d1c35-114">Binding to a single item</span></span>

<span data-ttu-id="d1c35-115">すべてのバインディングにはバインディング ターゲットとバインディング ソースがあります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-115">Every binding consists of a binding target and a binding source.</span></span> <span data-ttu-id="d1c35-116">通常、ターゲットはコントロールまたは他の UI 要素のプロパティであり、ソースはクラス インスタンス (データ モデルやビュー モデル) のプロパティです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-116">Typically, the target is a property of a control or other UI element, and the source is a property of a class instance (a data model, or a view model).</span></span> <span data-ttu-id="d1c35-117">コントロールを単一の項目にバインドする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-117">This example shows how to bind a control to a single item.</span></span> <span data-ttu-id="d1c35-118">ターゲットは **TextBlock** の **Text** プロパティです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-118">The target is the **Text** property of a **TextBlock**.</span></span> <span data-ttu-id="d1c35-119">ソースは、オーディオの録音を表す **Recording** という名前の単純なクラスのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-119">The source is an instance of a simple class named **Recording** that represents an audio recording.</span></span> <span data-ttu-id="d1c35-120">まずクラスを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="d1c35-120">Let's look at the class first.</span></span>

<span data-ttu-id="d1c35-121">C# または C++ を使っている場合 +/CX し、プロジェクトに新しいクラスを追加するクラス**レコーディング**の名前します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-121">If you're using C# or C++/CX, then add a new class to your project, and name the class **Recording**.</span></span>

<span data-ttu-id="d1c35-122">使用している場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、という名前の c++ に示すように、プロジェクトに新しい**Midl ファイル (.idl)** 項目を追加/以下の WinRT のコード例をリストします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-122">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then add new **Midl File (.idl)** items to the project, named as shown in the C++/WinRT code example listing below.</span></span> <span data-ttu-id="d1c35-123">これらの新しいファイルの内容を一覧に表示される[MIDL 3.0](/uwp/midl-3/intro)コードに置き換えます、生成するプロジェクトをビルド`Recording.h`と`.cpp`と`RecordingViewModel.h`と`.cpp`、し、登録情報に一致するように、生成されたファイルにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-123">Replace the contents of those new files with the [MIDL 3.0](/uwp/midl-3/intro) code shown in the listing, build the project to generate `Recording.h` and `.cpp` and `RecordingViewModel.h` and `.cpp`, and then add code to the generated files to match the listing.</span></span> <span data-ttu-id="d1c35-124">それらの生成されたファイルについて詳しくは、プロジェクトにコピーする方法を参照してください[XAML コントロール、バインドを C++/WinRT プロパティ](/windows/uwp/cpp-and-winrt-apis/binding-property)します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-124">For more info about those generated files and how to copy them into your project, see [XAML controls; bind to a C++/WinRT property](/windows/uwp/cpp-and-winrt-apis/binding-property).</span></span>

```csharp
namespace Quickstart
{
    public class Recording
    {
        public string ArtistName { get; set; }
        public string CompositionName { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public Recording()
        {
            this.ArtistName = "Wolfgang Amadeus Mozart";
            this.CompositionName = "Andante in C for Piano";
            this.ReleaseDateTime = new DateTime(1761, 1, 1);
        }
        public string OneLineSummary
        {
            get
            {
                return $"{this.CompositionName} by {this.ArtistName}, released: "
                    + this.ReleaseDateTime.ToString("d");
            }
        }
    }
    public class RecordingViewModel
    {
        private Recording defaultRecording = new Recording();
        public Recording DefaultRecording { get { return this.defaultRecording; } }
    }
}
```

```cppwinrt
// Recording.idl
namespace Quickstart
{
    runtimeclass Recording : Windows.UI.Xaml.DependencyObject
    {
        Recording(String artistName, String compositionName, Windows.Globalization.Calendar releaseDateTime);
        String ArtistName{ get; };
        String CompositionName{ get; };
        Windows.Globalization.Calendar ReleaseDateTime{ get; };
        String OneLineSummary{ get; };
    }
}

// RecordingViewModel.idl
import "Recording.idl";

namespace Quickstart
{
    runtimeclass RecordingViewModel : Windows.UI.Xaml.DependencyObject
    {
        RecordingViewModel();
        Quickstart.Recording DefaultRecording{ get; };
    }
}

// Recording.h
// Add these fields:
...
#include <sstream>
...
private:
    std::wstring m_artistName;
    std::wstring m_compositionName;
    Windows::Globalization::Calendar m_releaseDateTime;
...

// Recording.cpp
// Implement like this:
...
Recording::Recording(hstring const& artistName, hstring const& compositionName, Windows::Globalization::Calendar const& releaseDateTime) :
    m_artistName{ artistName.c_str() },
    m_compositionName{ compositionName.c_str() },
    m_releaseDateTime{ releaseDateTime } {}

hstring Recording::ArtistName(){ return hstring{ m_artistName }; }
hstring Recording::CompositionName(){ return hstring{ m_compositionName }; }
Windows::Globalization::Calendar Recording::ReleaseDateTime(){ return m_releaseDateTime; }

hstring Recording::OneLineSummary()
{
    std::wstringstream wstringstream;
    wstringstream << m_compositionName.c_str();
    wstringstream << L" by " << m_artistName.c_str();
    wstringstream << L", released: " << m_releaseDateTime.MonthAsNumericString().c_str();
    wstringstream << L"/" << m_releaseDateTime.DayAsString().c_str();
    wstringstream << L"/" << m_releaseDateTime.YearAsString().c_str();
    return hstring{ wstringstream.str().c_str() };
}
...

// RecordingViewModel.h
// Add this field:
...
#include "Recording.h"
...
private:
    Quickstart::Recording m_defaultRecording{ nullptr };
...

// RecordingViewModel.cpp
// Implement like this:
...
Quickstart::Recording RecordingViewModel::DefaultRecording()
{
    Windows::Globalization::Calendar releaseDateTime;
    releaseDateTime.Year(1761);
    releaseDateTime.Month(1);
    releaseDateTime.Day(1);
    m_defaultRecording = winrt::make<Recording>(L"Wolfgang Amadeus Mozart", L"Andante in C for Piano", releaseDateTime);
    return m_defaultRecording;
}
...
```

```cpp
// Recording.h
#include <sstream>
namespace Quickstart
{
    public ref class Recording sealed
    {
    private:
        Platform::String^ artistName;
        Platform::String^ compositionName;
        Windows::Globalization::Calendar^ releaseDateTime;
    public:
        Recording(Platform::String^ artistName, Platform::String^ compositionName,
            Windows::Globalization::Calendar^ releaseDateTime) :
            artistName{ artistName },
            compositionName{ compositionName },
            releaseDateTime{ releaseDateTime } {}
        property Platform::String^ ArtistName
        {
            Platform::String^ get() { return this->artistName; }
        }
        property Platform::String^ CompositionName
        {
            Platform::String^ get() { return this->compositionName; }
        }
        property Windows::Globalization::Calendar^ ReleaseDateTime
        {
            Windows::Globalization::Calendar^ get() { return this->releaseDateTime; }
        }
        property Platform::String^ OneLineSummary
        {
            Platform::String^ get()
            {
                std::wstringstream wstringstream;
                wstringstream << this->CompositionName->Data();
                wstringstream << L" by " << this->ArtistName->Data();
                wstringstream << L", released: " << this->ReleaseDateTime->MonthAsNumericString()->Data();
                wstringstream << L"/" << this->ReleaseDateTime->DayAsString()->Data();
                wstringstream << L"/" << this->ReleaseDateTime->YearAsString()->Data();
                return ref new Platform::String(wstringstream.str().c_str());
            }
        }
    };
    public ref class RecordingViewModel sealed
    {
    private:
        Recording ^ defaultRecording;
    public:
        RecordingViewModel()
        {
            Windows::Globalization::Calendar^ releaseDateTime = ref new Windows::Globalization::Calendar();
            releaseDateTime->Year = 1761;
            releaseDateTime->Month = 1;
            releaseDateTime->Day = 1;
            this->defaultRecording = ref new Recording{ L"Wolfgang Amadeus Mozart", L"Andante in C for Piano", releaseDateTime };
        }
        property Recording^ DefaultRecording
        {
            Recording^ get() { return this->defaultRecording; };
        }
    };
}

// Recording.cpp
#include "pch.h"
#include "Recording.h"
```

<span data-ttu-id="d1c35-125">次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-125">Next, expose the binding source class from the class that represents your page of markup.</span></span> <span data-ttu-id="d1c35-126">これを行うには、**RecordingViewModel** 型のプロパティを **MainPage** に追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-126">We do that by adding a property of type **RecordingViewModel** to **MainPage**.</span></span>

<span data-ttu-id="d1c35-127">使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、最初の更新し、 `MainPage.idl`。</span><span class="sxs-lookup"><span data-stu-id="d1c35-127">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then first update `MainPage.idl`.</span></span> <span data-ttu-id="d1c35-128">プロジェクトをビルドを再生成して`MainPage.h`と`.cpp`、それらの生成されたファイルの変更をプロジェクトにあるものにマージします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-128">Build the project to regenerate `MainPage.h` and `.cpp`, and merge the changes in those generated files into the ones in your project.</span></span>

```csharp
namespace Quickstart
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RecordingViewModel();
        }
        public RecordingViewModel ViewModel{ get; set; }
    }
}
```

```cppwinrt
// MainPage.idl
// Add this property:
import "RecordingViewModel.idl";
...
RecordingViewModel ViewModel{ get; };
...

// MainPage.h
// Add this property and this field:
...
#include "RecordingViewModel.h"
...
    Quickstart::RecordingViewModel ViewModel();

private:
    Quickstart::RecordingViewModel m_viewModel{ nullptr };
...

// MainPage.cpp
// Implement like this:
...
MainPage::MainPage()
{
    InitializeComponent();
    m_viewModel = winrt::make<RecordingViewModel>();
}
Quickstart::RecordingViewModel MainPage::ViewModel()
{
    return m_viewModel;
}
...
```

```cpp
// MainPage.h
...
#include "Recording.h"

namespace Quickstart
{
    public ref class MainPage sealed
    {
    private:
        RecordingViewModel ^ viewModel;
    public:
        MainPage();

        property RecordingViewModel^ ViewModel
        {
            RecordingViewModel^ get() { return this->viewModel; };
        }
    };
}

// MainPage.cpp
...
MainPage::MainPage()
{
    InitializeComponent();
    this->viewModel = ref new RecordingViewModel();
}
```

<span data-ttu-id="d1c35-129">最後の部分では、**TextBlock** を **ViewModel.DefaultRecording.OneLiner** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-129">The last piece is to bind a **TextBlock** to the **ViewModel.DefaultRecording.OneLiner** property.</span></span>

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock Text="{x:Bind ViewModel.DefaultRecording.OneLineSummary}"
    HorizontalAlignment="Center"
    VerticalAlignment="Center"/>
    </Grid>
</Page>
```

<span data-ttu-id="d1c35-130">使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、プロジェクトをビルドするための順序で**mainpage::clickhandler**関数を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-130">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then you'll need to remove the **MainPage::ClickHandler** function in order for the project to build.</span></span>

<span data-ttu-id="d1c35-131">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-131">Here's the result.</span></span>

![テキストブロックのバインド](images/xaml-databinding0.png)

## <a name="binding-to-a-collection-of-items"></a><span data-ttu-id="d1c35-133">項目のコレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="d1c35-133">Binding to a collection of items</span></span>

<span data-ttu-id="d1c35-134">一般的なシナリオでは、ビジネス オブジェクトのコレクションにバインドします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-134">A common scenario is to bind to a collection of business objects.</span></span> <span data-ttu-id="d1c35-135">C# と Visual Basic では、データ バインディングのコレクションには汎用の [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) クラスが適しています。このクラスは [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) インターフェイスと [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) インターフェイスを実装するためです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-135">In C# and Visual Basic, the generic [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) class is a good collection choice for data binding, because it implements the [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) interfaces.</span></span> <span data-ttu-id="d1c35-136">これらのインターフェイスは、項目が追加または変更された場合や一覧自体のプロパティが変更された場合に、バインディングに変更を通知します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-136">These interfaces provide change notification to bindings when items are added or removed or a property of the list itself changes.</span></span> <span data-ttu-id="d1c35-137">コレクション内のオブジェクトのプロパティの変更をバインドされたコントロールに反映する場合は、ビジネス オブジェクトでも **INotifyPropertyChanged** を実装します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-137">If you want your bound controls to update with changes to properties of objects in the collection, the business object should also implement **INotifyPropertyChanged**.</span></span> <span data-ttu-id="d1c35-138">詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-138">For more info, see [Data binding in depth](data-binding-in-depth.md).</span></span>

<span data-ttu-id="d1c35-139">使っている場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、監視可能なコレクションにバインドする方法の詳細については、その[XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](/windows/uwp/cpp-and-winrt-apis/binding-collection)します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-139">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then you can learn more about binding to an observable collection in [XAML items controls; bind to a C++/WinRT collection](/windows/uwp/cpp-and-winrt-apis/binding-collection).</span></span> <span data-ttu-id="d1c35-140">かどうかするトピックを読むと、最初に、し、c++ の意図/WinRT コードの一覧を次にはより明確になります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-140">If you read that topic first, then the intent of the C++/WinRT code listing shown below will be clearer.</span></span>

<span data-ttu-id="d1c35-141">次の例では、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を `Recording` オブジェクトのコレクションにバインドしています。</span><span class="sxs-lookup"><span data-stu-id="d1c35-141">This next example binds a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to a collection of `Recording` objects.</span></span> <span data-ttu-id="d1c35-142">最初に、ビュー モデルにコレクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-142">Let's start by adding the collection to our view model.</span></span> <span data-ttu-id="d1c35-143">これらの新しいメンバーを **RecordingViewModel** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-143">Just add these new members to the **RecordingViewModel** class.</span></span>

```csharp
public class RecordingViewModel
{
    ...
    private ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
    public ObservableCollection<Recording> Recordings{ get{ return this.recordings; } }
    public RecordingViewModel()
    {
        this.recordings.Add(new Recording(){ ArtistName = "Johann Sebastian Bach",
            CompositionName = "Mass in B minor", ReleaseDateTime = new DateTime(1748, 7, 8) });
        this.recordings.Add(new Recording(){ ArtistName = "Ludwig van Beethoven",
            CompositionName = "Third Symphony", ReleaseDateTime = new DateTime(1805, 2, 11) });
        this.recordings.Add(new Recording(){ ArtistName = "George Frideric Handel",
            CompositionName = "Serse", ReleaseDateTime = new DateTime(1737, 12, 3) });
    }
}
```

```cppwinrt
// RecordingViewModel.idl
// Add this property:
...
Windows.Foundation.Collections.IVector<IInspectable> Recordings{ get; };
...

// RecordingViewModel.h
// Change the constructor declaration, and add this property and this field:
...
    RecordingViewModel();
    Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> Recordings();

private:
    Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> m_recordings;
...

// RecordingViewModel.cpp
// Implement like this:
...
RecordingViewModel::RecordingViewModel()
{
    std::vector<Windows::Foundation::IInspectable> recordings;

    Windows::Globalization::Calendar releaseDateTime;
    releaseDateTime.Month(7); releaseDateTime.Day(8); releaseDateTime.Year(1748);
    recordings.push_back(winrt::make<Recording>(L"Johann Sebastian Bach", L"Mass in B minor", releaseDateTime));

    releaseDateTime = Windows::Globalization::Calendar{};
    releaseDateTime.Month(11); releaseDateTime.Day(2); releaseDateTime.Year(1805);
    recordings.push_back(winrt::make<Recording>(L"Ludwig van Beethoven", L"Third Symphony", releaseDateTime));

    releaseDateTime = Windows::Globalization::Calendar{};
    releaseDateTime.Month(3); releaseDateTime.Day(12); releaseDateTime.Year(1737);
    recordings.push_back(winrt::make<Recording>(L"George Frideric Handel", L"Serse", releaseDateTime));

    m_recordings = winrt::single_threaded_observable_vector<Windows::Foundation::IInspectable>(std::move(recordings));
}

Windows::Foundation::Collections::IVector<Windows::Foundation::IInspectable> RecordingViewModel::Recordings() { return m_recordings; }
...
```

```cpp
// Recording.h
...
public ref class RecordingViewModel sealed
{
private:
    ...
    Windows::Foundation::Collections::IVector<Recording^>^ recordings;
public:
    RecordingViewModel()
    {
        ...
        releaseDateTime = ref new Windows::Globalization::Calendar();
        releaseDateTime->Year = 1748;
        releaseDateTime->Month = 7;
        releaseDateTime->Day = 8;
        Recording^ recording = ref new Recording{ L"Johann Sebastian Bach", L"Mass in B minor", releaseDateTime };
        this->Recordings->Append(recording);
        releaseDateTime = ref new Windows::Globalization::Calendar();
        releaseDateTime->Year = 1805;
        releaseDateTime->Month = 2;
        releaseDateTime->Day = 11;
        recording = ref new Recording{ L"Ludwig van Beethoven", L"Third Symphony", releaseDateTime };
        this->Recordings->Append(recording);
        releaseDateTime = ref new Windows::Globalization::Calendar();
        releaseDateTime->Year = 1737;
        releaseDateTime->Month = 12;
        releaseDateTime->Day = 3;
        recording = ref new Recording{ L"George Frideric Handel", L"Serse", releaseDateTime };
        this->Recordings->Append(recording);
    }
    ...
    property Windows::Foundation::Collections::IVector<Recording^>^ Recordings
    {
        Windows::Foundation::Collections::IVector<Recording^>^ get()
        {
            if (this->recordings == nullptr)
            {
                this->recordings = ref new Platform::Collections::Vector<Recording^>();
            }
            return this->recordings;
        };
    }
};
```

<span data-ttu-id="d1c35-144">次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を **ViewModel.Recordings** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-144">And then bind a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to the **ViewModel.Recordings** property.</span></span>

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{x:Bind ViewModel.Recordings}"
        HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Page>
```

<span data-ttu-id="d1c35-145">まだ **Recording** クラスのデータ テンプレートを用意していないため、UI フレームワークで [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の各項目について [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-145">We haven't yet provided a data template for the **Recording** class, so the best the UI framework can do is to call [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) for each item in the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878).</span></span> <span data-ttu-id="d1c35-146">**ToString** の既定の実装は、型名を返すことです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-146">The default implementation of **ToString** is to return the type name.</span></span>

![一覧ビューのバインド](images/xaml-databinding1.png)

<span data-ttu-id="d1c35-148">これを修正するには、 **OneLineSummary**の値を返す[**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx)を無効にできますか、またはデータ テンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-148">To remedy this, we can either override [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) to return the value of **OneLineSummary**, or we can provide a data template.</span></span> <span data-ttu-id="d1c35-149">一般的なソリューションでは、されより柔軟なデータ テンプレートのオプションとなります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-149">The data template option is a more usual solution, and a more flexible one.</span></span> <span data-ttu-id="d1c35-150">データ テンプレートを指定するには、コンテンツ コントロールの [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) プロパティか、項目コントロールの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="d1c35-150">You specify a data template by using the [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) property of a content control or the [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) property of an items control.</span></span> <span data-ttu-id="d1c35-151">**Recording** のデータ テンプレートをデザインするための 2 つの方法と結果の図を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-151">Here are two ways we could design a data template for **Recording** together with an illustration of the result.</span></span>

```xml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}"
HorizontalAlignment="Center" VerticalAlignment="Center">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:Recording">
            <TextBlock Text="{x:Bind OneLineSummary}"/>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

![一覧ビューのバインド](images/xaml-databinding2.png)

```xml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}"
HorizontalAlignment="Center" VerticalAlignment="Center">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:Recording">
            <StackPanel Orientation="Horizontal" Margin="6">
                <SymbolIcon Symbol="Audio" Margin="0,0,12,0"/>
                <StackPanel>
                    <TextBlock Text="{x:Bind ArtistName}" FontWeight="Bold"/>
                    <TextBlock Text="{x:Bind CompositionName}"/>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

![一覧ビューのバインド](images/xaml-databinding3.png)

<span data-ttu-id="d1c35-154">XAML 構文について詳しくは、「[XAML を使った UI の作成](https://msdn.microsoft.com/library/windows/apps/Mt228349)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-154">For more information about XAML syntax, see [Create a UI with XAML](https://msdn.microsoft.com/library/windows/apps/Mt228349).</span></span> <span data-ttu-id="d1c35-155">コントロール レイアウトについて詳しくは、「[XAML を使ったレイアウトの定義](https://msdn.microsoft.com/library/windows/apps/Mt228350)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-155">For more information about control layout, see [Define layouts with XAML](https://msdn.microsoft.com/library/windows/apps/Mt228350).</span></span>

## <a name="adding-a-details-view"></a><span data-ttu-id="d1c35-156">詳細ビューの追加</span><span class="sxs-lookup"><span data-stu-id="d1c35-156">Adding a details view</span></span>

<span data-ttu-id="d1c35-157">[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) 項目内の **Recording** オブジェクトの詳細をすべて表示することを選択できます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-157">You can choose to display all the details of **Recording** objects in [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) items.</span></span> <span data-ttu-id="d1c35-158">ただし、多くの領域が占有されます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-158">But that takes up a lot of space.</span></span> <span data-ttu-id="d1c35-159">代わりに、項目を識別するのに十分な項目内のデータのみを表示し、ユーザーが選択を行ったら、選択された項目のすべての詳細を、詳細ビューと呼ばれる独立した UI に表示できます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-159">Instead, you can show just enough data in the item to identify it and then, when the user makes a selection, you can display all the details of the selected item in a separate piece of UI known as the details view.</span></span> <span data-ttu-id="d1c35-160">この配置は、マスター/詳細ビューまたはリスト/詳細ビューとも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-160">This arrangement is also known as a master/details view, or a list/details view.</span></span>

<span data-ttu-id="d1c35-161">これには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-161">There are two ways to go about this.</span></span> <span data-ttu-id="d1c35-162">詳細ビューを、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) プロパティにバインドできます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-162">You can bind the details view to the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) property of the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878).</span></span> <span data-ttu-id="d1c35-163">または、(の現在選択されている項目のためは、注意を行う) **CollectionViewSource**を**ListView**と詳細ビューの両方をバインドする場合、 [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-163">Or you can use a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833), in which case you bind both the **ListView** and the details view to the **CollectionViewSource** (doing so takes care of the currently-selected item for you).</span></span> <span data-ttu-id="d1c35-164">両方の手法が次に示すし、(図に示すように) 同じ結果が提供されます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-164">Both techniques are shown below, and they both give the same results (shown in the illustration).</span></span>

> [!NOTE]
> <span data-ttu-id="d1c35-165">このトピックでは、これまで [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)のみを使ってきましたが、以下に示す 2 つの手法ではより柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)が必要です。</span><span class="sxs-lookup"><span data-stu-id="d1c35-165">So far in this topic we've only used the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783), but both of the techniques we'll show below require the more flexible (but less performant) [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d1c35-166">使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、(後述) [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールした場合に使用し、またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="d1c35-166">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute (mentioned below) is available if you've installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later.</span></span> <span data-ttu-id="d1c35-167">その属性がない[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用できるようにするために[ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-167">Without that attribute, you'll need to implement the [ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider) and [ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty) interfaces in order to be able to use the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension.</span></span>

<span data-ttu-id="d1c35-168">使用する場合、C++/WinRT または Visual C コンポーネント拡張機能 (、C++/CX) し、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用してありますが、ために必要があります**記録**クラスを[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-168">If you're using C++/WinRT or Visual C++ component extensions (C++/CX) then, because we'll be using the [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) markup extension, you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to the **Recording** class.</span></span>

<span data-ttu-id="d1c35-169">まず、[**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) の手法を示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-169">First, here's the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) technique.</span></span>

```csharp
// No code changes necessary for C#.
```

```cppwinrt
// Recording.idl
// Add this attribute:
...
[Windows.UI.Xaml.Data.Bindable]
runtimeclass Recording : Windows.UI.Xaml.DependencyObject
...
```

```cpp
[Windows::UI::Xaml::Data::Bindable]
public ref class Recording sealed
{
    ...
};
```

<span data-ttu-id="d1c35-170">必要なもう 1 つの変更はマークアップに対する変更のみです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-170">The only other change necessary is to the markup.</span></span>

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
            <ListView x:Name="recordingsListView" ItemsSource="{x:Bind ViewModel.Recordings}">
                <ListView.ItemTemplate>
                    <DataTemplate x:DataType="local:Recording">
                        <StackPanel Orientation="Horizontal" Margin="6">
                            <SymbolIcon Symbol="Audio" Margin="0,0,12,0"/>
                            <StackPanel>
                                <TextBlock Text="{x:Bind CompositionName}"/>
                            </StackPanel>
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
            <StackPanel DataContext="{Binding SelectedItem, ElementName=recordingsListView}"
            Margin="0,24,0,0">
                <TextBlock Text="{Binding ArtistName}"/>
                <TextBlock Text="{Binding CompositionName}"/>
                <TextBlock Text="{Binding ReleaseDateTime}"/>
            </StackPanel>
        </StackPanel>
    </Grid>
</Page>
```

<span data-ttu-id="d1c35-171">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) の手法では、最初にページ リソースとして **CollectionViewSource** を追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-171">For the [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) technique, first add a **CollectionViewSource** as a page resource.</span></span>

```xml
<Page.Resources>
    <CollectionViewSource x:Name="RecordingsCollection" Source="{x:Bind ViewModel.Recordings}"/>
</Page.Resources>
```

<span data-ttu-id="d1c35-172">次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) (名前を付ける必要はない) と詳細ビューで、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) を使うようにバインディングを調整します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-172">And then adjust the bindings on the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) (which no longer needs to be named) and on the details view to use the [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833).</span></span> <span data-ttu-id="d1c35-173">詳細ビューを **CollectionViewSource** に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-173">Note that by binding the details view directly to the **CollectionViewSource**, you're implying that you want to bind to the current item in bindings where the path cannot be found on the collection itself.</span></span> <span data-ttu-id="d1c35-174">バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-174">There's no need to specify the **CurrentItem** property as the path for the binding, although you can do that if there's any ambiguity).</span></span>

```xml
...
<ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}">
...
<StackPanel DataContext="{Binding Source={StaticResource RecordingsCollection}}" ...>
...
```

<span data-ttu-id="d1c35-175">次のように、いずれの場合も結果は同じです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-175">And here's the identical result in each case.</span></span>

> [!NOTE]
> <span data-ttu-id="d1c35-176">C++ を使用している場合、UI を検索しません次の図とまったく同じ: **ReleaseDateTime**プロパティのレンダリングは異なります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-176">If you're using C++, then your UI won't look exactly like the illustration below: the rendering of the **ReleaseDateTime** property is different.</span></span> <span data-ttu-id="d1c35-177">詳細については、次のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-177">See the following section for more discussion of this.</span></span>

![一覧ビューのバインド](images/xaml-databinding4.png)

## <a name="formatting-or-converting-data-values-for-display"></a><span data-ttu-id="d1c35-179">表示のためのデータ値の書式設定と変換</span><span class="sxs-lookup"><span data-stu-id="d1c35-179">Formatting or converting data values for display</span></span>

<span data-ttu-id="d1c35-180">前のレンダリングに問題があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-180">There is an issue with the rendering above.</span></span> <span data-ttu-id="d1c35-181">**ReleaseDateTime**プロパティは、日付だけではなく、そのが[**DateTime**](/uwp/api/windows.foundation.datetime) ([**カレンダー**](/uwp/api/windows.globalization.calendar)は、C++ を使用している) 場合。</span><span class="sxs-lookup"><span data-stu-id="d1c35-181">The **ReleaseDateTime** property is not just a date, it's a [**DateTime**](/uwp/api/windows.foundation.datetime) (if you're using C++, then it's a [**Calendar**](/uwp/api/windows.globalization.calendar)).</span></span> <span data-ttu-id="d1c35-182">そのため、c# でそれが表示されているの必要な精度でします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-182">So, in C#, it's being displayed with more precision than we need.</span></span> <span data-ttu-id="d1c35-183">C++ でレンダリングされる型名としてします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-183">And in C++ it's being rendered as a type name.</span></span> <span data-ttu-id="d1c35-184">1 つのソリューションと同等の結果を返す**レコーディング**クラスに文字列プロパティを追加するには`this.ReleaseDateTime.ToString("d")`します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-184">One solution is to add a string property to the **Recording** class that returns the equivalent of `this.ReleaseDateTime.ToString("d")`.</span></span> <span data-ttu-id="d1c35-185">**ReleaseDate**そのプロパティの名前を付けると、日付、およびしない、日付と時間が返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-185">Naming that property **ReleaseDate** would indicate that it returns a date, and not a date-and-time.</span></span> <span data-ttu-id="d1c35-186">**ReleaseDateAsString** という名前を付けると、さらに文字列が返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-186">Naming it **ReleaseDateAsString** would further indicate that it returns a string.</span></span>

<span data-ttu-id="d1c35-187">より柔軟な解決策は、値コンバーターと呼ばれるものを使うことです。</span><span class="sxs-lookup"><span data-stu-id="d1c35-187">A more flexible solution is to use something known as a value converter.</span></span> <span data-ttu-id="d1c35-188">独自の値コンバーターを作成する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-188">Here's an example of how to author your own value converter.</span></span> <span data-ttu-id="d1c35-189">次のコードを Recording.cs ソース コード ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-189">Add this code to your Recording.cs source code file.</span></span>

```csharp
public class StringFormatter : Windows.UI.Xaml.Data.IValueConverter
{
    // This converts the value object to the string to display.
    // This will work with most simple types.
    public object Convert(object value, Type targetType,
        object parameter, string language)
    {
        // Retrieve the format string and use it to format the value.
        string formatString = parameter as string;
        if (!string.IsNullOrEmpty(formatString))
        {
            return string.Format(formatString, value);
        }

        // If the format string is null or empty, simply
        // call ToString() on the value.
        return value.ToString();
    }

    // No need to implement converting back on a one-way binding
    public object ConvertBack(object value, Type targetType,
        object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
```

```cppwinrt
// StringFormatter.idl
namespace Quickstart
{
    runtimeclass StringFormatter : Windows.UI.Xaml.Data.IValueConverter
    {
        StringFormatter();
    }
}

// StringFormatter.h
#pragma once

#include "StringFormatter.g.h"
#include <sstream>

namespace winrt::Quickstart::implementation
{
    struct StringFormatter : StringFormatterT<StringFormatter>
    {
        StringFormatter() = default;

        Windows::Foundation::IInspectable Convert(Windows::Foundation::IInspectable const& value, Windows::UI::Xaml::Interop::TypeName const& targetType, Windows::Foundation::IInspectable const& parameter, hstring const& language);
        Windows::Foundation::IInspectable ConvertBack(Windows::Foundation::IInspectable const& value, Windows::UI::Xaml::Interop::TypeName const& targetType, Windows::Foundation::IInspectable const& parameter, hstring const& language);
    };
}

namespace winrt::Quickstart::factory_implementation
{
    struct StringFormatter : StringFormatterT<StringFormatter, implementation::StringFormatter>
    {
    };
}

// StringFormatter.cpp
#include "pch.h"
#include "StringFormatter.h"

namespace winrt::Quickstart::implementation
{
    Windows::Foundation::IInspectable StringFormatter::Convert(Windows::Foundation::IInspectable const& value, Windows::UI::Xaml::Interop::TypeName const& /* targetType */, Windows::Foundation::IInspectable const& /* parameter */, hstring const& /* language */)
    {
        // Retrieve the value as a Calendar.
        Windows::Globalization::Calendar valueAsCalendar{ value.as<Windows::Globalization::Calendar>() };

        std::wstringstream wstringstream;
        wstringstream << L"Released: ";
        wstringstream << valueAsCalendar.MonthAsNumericString().c_str();
        wstringstream << L"/" << valueAsCalendar.DayAsString().c_str();
        wstringstream << L"/" << valueAsCalendar.YearAsString().c_str();
        return winrt::box_value(hstring{ wstringstream.str().c_str() });
    }

    Windows::Foundation::IInspectable StringFormatter::ConvertBack(Windows::Foundation::IInspectable const& /* value */, Windows::UI::Xaml::Interop::TypeName const& /* targetType */, Windows::Foundation::IInspectable const& /* parameter */, hstring const& /* language */)
    {
        throw hresult_not_implemented();
    }
}
```

```cpp
...
public ref class StringFormatter sealed : Windows::UI::Xaml::Data::IValueConverter
{
public:
    virtual Platform::Object^ Convert(Platform::Object^ value, TypeName targetType, Platform::Object^ parameter, Platform::String^ language)
    {
        // Retrieve the value as a Calendar.
        Windows::Globalization::Calendar^ valueAsCalendar = dynamic_cast<Windows::Globalization::Calendar^>(value);

        std::wstringstream wstringstream;
        wstringstream << L"Released: ";
        wstringstream << valueAsCalendar->MonthAsNumericString()->Data();
        wstringstream << L"/" << valueAsCalendar->DayAsString()->Data();
        wstringstream << L"/" << valueAsCalendar->YearAsString()->Data();
        return ref new Platform::String(wstringstream.str().c_str());
    }

    // No need to implement converting back on a one-way binding
    virtual Platform::Object^ ConvertBack(Platform::Object^ value, TypeName targetType, Platform::Object^ parameter, Platform::String^ language)
    {
        throw ref new Platform::NotImplementedException();
    }
};
...
```

<span data-ttu-id="d1c35-190">これで、**StringFormatter** のインスタンスをページ リソースとして追加し、バインドで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d1c35-190">Now we can add an instance of **StringFormatter** as a page resource and use it in our binding.</span></span>

```xml
<Page.Resources>
    <local:StringFormatter x:Key="StringFormatterValueConverter"/>
</Page.Resources>
...
<TextBlock Text="{Binding ReleaseDateTime,
    Converter={StaticResource StringFormatterValueConverter},
    ConverterParameter=Released: \{0:d\}}"/>
...
```

<span data-ttu-id="d1c35-191">上記わかるように、柔軟性を書式設定のマークアップを使ってコンバーター パラメーターを使用してコンバーターに書式文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-191">As you can see above, for formatting flexibility we use the markup to pass a format string into the converter by way of the converter parameter.</span></span> <span data-ttu-id="d1c35-192">のみ、c# 値コンバーターは、このトピックに示すようにコード例では、そのパラメーターの使用します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-192">In the code examples shown in this topic, only the C# value converter makes use of that parameter.</span></span> <span data-ttu-id="d1c35-193">簡単に C++ スタイル形式の文字列をコンバーター パラメーターとして渡すし、 **wprintf**や**swprintf**などの書式設定の関数を使って、値コンバーターを使用する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-193">But you could easily pass a C++-style format string as the converter parameter, and use that in your value converter with a formatting function such as **wprintf** or **swprintf**.</span></span>

<span data-ttu-id="d1c35-194">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-194">Here's the result.</span></span>

![カスタム形式での日付の表示](images/xaml-databinding5.png)

> [!NOTE]
> <span data-ttu-id="d1c35-196">Windows 10、バージョン 1607 では、以降では、XAML フレームワークは、組み込みの表示のブール値コンバーターを提供します。</span><span class="sxs-lookup"><span data-stu-id="d1c35-196">Starting in Windows 10, version 1607, the XAML framework provides a built-in Boolean-to-Visibility converter.</span></span> <span data-ttu-id="d1c35-197">コンバーターにマップ**true** **Visibility.Visible**列挙値と**false** **Visibility.Collapsed**をコンバーターを作成することがなく、Visibility プロパティをブール値にバインドできるようにします。</span><span class="sxs-lookup"><span data-stu-id="d1c35-197">The converter maps **true** to the **Visibility.Visible** enumeration value and **false** to **Visibility.Collapsed** so you can bind a Visibility property to a Boolean without creating a converter.</span></span> <span data-ttu-id="d1c35-198">組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1c35-198">To use the built in converter, your app's minimum target SDK version must be 14393 or later.</span></span> <span data-ttu-id="d1c35-199">アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。</span><span class="sxs-lookup"><span data-stu-id="d1c35-199">You can't use it when your app targets earlier versions of Windows 10.</span></span> <span data-ttu-id="d1c35-200">ターゲット バージョンについて詳しくは、[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d1c35-200">For more info about target versions, see [Version-adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

## <a name="see-also"></a><span data-ttu-id="d1c35-201">関連項目</span><span class="sxs-lookup"><span data-stu-id="d1c35-201">See also</span></span>
* [<span data-ttu-id="d1c35-202">データ バインディング</span><span class="sxs-lookup"><span data-stu-id="d1c35-202">Data binding</span></span>](index.md)
