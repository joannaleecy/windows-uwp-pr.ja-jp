---
author: mcleblanc
ms.assetid: A9D54DEC-CD1B-4043-ADE4-32CD4977D1BF
title: データ バインディングの概要
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目のコントロールを項目のコレクションにバインドする方法を説明します。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: fd9b9b4f1c6ddd48db8801d714568ccb011ea7e5
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
ms.locfileid: "1494049"
---
<a name="data-binding-overview"></a><span data-ttu-id="16554-104">データ バインディングの概要</span><span class="sxs-lookup"><span data-stu-id="16554-104">Data binding overview</span></span>
=====================



<span data-ttu-id="16554-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="16554-105">This topic shows you how to bind a control (or other UI element) to a single item or bind an items control to a collection of items in a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="16554-106">また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。</span><span class="sxs-lookup"><span data-stu-id="16554-106">In addition, we show how to control the rendering of items, implement a details view based on a selection, and convert data for display.</span></span> <span data-ttu-id="16554-107">詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-107">For more detailed info, see [Data binding in depth](data-binding-in-depth.md).</span></span>

<a name="prerequisites"></a><span data-ttu-id="16554-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="16554-108">Prerequisites</span></span>
-------------------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-109">このトピックでは、基本的な UWP アプリを作成できることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="16554-109">This topic assumes that you know how to create a basic UWP app.</span></span> <span data-ttu-id="16554-110">初めての UWP アプリを作成する方法について、詳しくは「[Windows アプリの概要](https://developer.microsoft.com/windows/getstarted)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-110">For instructions on creating your first UWP app, see [Get started with Windows apps](https://developer.microsoft.com/windows/getstarted).</span></span>

<a name="create-the-project"></a><span data-ttu-id="16554-111">プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="16554-111">Create the project</span></span>
---------------------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-112">最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。</span><span class="sxs-lookup"><span data-stu-id="16554-112">Create a new **Blank Application (Windows Universal)** project.</span></span> <span data-ttu-id="16554-113">プロジェクトに "Quickstart" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="16554-113">Name it "Quickstart".</span></span>

<a name="binding-to-a-single-item"></a><span data-ttu-id="16554-114">単一の項目へのバインド</span><span class="sxs-lookup"><span data-stu-id="16554-114">Binding to a single item</span></span>
---------------------------------------------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-115">すべてのバインディングにはバインディング ターゲットとバインディング ソースがあります。</span><span class="sxs-lookup"><span data-stu-id="16554-115">Every binding consists of a binding target and a binding source.</span></span> <span data-ttu-id="16554-116">通常、ターゲットはコントロールまたは他の UI 要素のプロパティであり、ソースはクラス インスタンス (データ モデルやビュー モデル) のプロパティです。</span><span class="sxs-lookup"><span data-stu-id="16554-116">Typically, the target is a property of a control or other UI element, and the source is a property of a class instance (a data model, or a view model).</span></span> <span data-ttu-id="16554-117">コントロールを単一の項目にバインドする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="16554-117">This example shows how to bind a control to a single item.</span></span> <span data-ttu-id="16554-118">ターゲットは **TextBlock** の **Text** プロパティです。</span><span class="sxs-lookup"><span data-stu-id="16554-118">The target is the **Text** property of a **TextBlock**.</span></span> <span data-ttu-id="16554-119">ソースは、オーディオの録音を表す **Recording** という名前の単純なクラスのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="16554-119">The source is an instance of a simple class named **Recording** that represents an audio recording.</span></span> <span data-ttu-id="16554-120">まずクラスを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="16554-120">Let's look at the class first.</span></span>

<span data-ttu-id="16554-121">プロジェクトに新しいクラスを追加して Recording.cs (C#、または下記の C++ スニペットを使用している場合) という名前を付け、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-121">Add a new class to your project, name it Recording.cs (if you're using C#, C++ snippets provided below as well), and add this code to it.</span></span>

> [!div class="tabbedCodeSnippets"]
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
```cpp
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
            Recording^ defaultRecording;
        public:
            RecordingViewModel()
            {
                Windows::Globalization::Calendar^ releaseDateTime = ref new Windows::Globalization::Calendar();
                releaseDateTime->Month = 1;
                releaseDateTime->Day = 1;
                releaseDateTime->Year = 1761;
                this->defaultRecording = ref new Recording{ L"Wolfgang Amadeus Mozart", L"Andante in C for Piano", releaseDateTime };
            }
            property Recording^ DefaultRecording
            {
                Recording^ get() { return this->defaultRecording; };
            }
        };
    }
```

<span data-ttu-id="16554-122">次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。</span><span class="sxs-lookup"><span data-stu-id="16554-122">Next, expose the binding source class from the class that represents your page of markup.</span></span> <span data-ttu-id="16554-123">これを行うには、**RecordingViewModel** 型のプロパティを **MainPage** に追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-123">We do that by adding a property of type **RecordingViewModel** to **MainPage**.</span></span>

> [!div class="tabbedCodeSnippets"]
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
            public RecordingViewModel ViewModel { get; set; }
        }
    }
```
```cpp
    namespace Quickstart
    {
        public ref class MainPage sealed
        {
        private:
            RecordingViewModel^ viewModel;
        public:
            MainPage()
            {
                InitializeComponent();
                this->viewModel = ref new RecordingViewModel();
            }
            property RecordingViewModel^ ViewModel
            {
                RecordingViewModel^ get() { return this->viewModel; };
            }
        };
    }
```

<span data-ttu-id="16554-124">最後の部分では、**TextBlock** を **ViewModel.DefaultRecording.OneLiner** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="16554-124">The last piece is to bind a **TextBlock** to the **ViewModel.DefaultRecording.OneLiner** property.</span></span>

```xml
    <Page x:Class="Quickstart.MainPage" ... >
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <TextBlock Text="{x:Bind ViewModel.DefaultRecording.OneLineSummary}"
            HorizontalAlignment="Center"
            VerticalAlignment="Center"/>
        </Grid>
    </Page>
```

<span data-ttu-id="16554-125">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="16554-125">Here's the result.</span></span>

![テキストブロックのバインド](images/xaml-databinding0.png)

<a name="binding-to-a-collection-of-items"></a><span data-ttu-id="16554-127">項目のコレクションへのバインド</span><span class="sxs-lookup"><span data-stu-id="16554-127">Binding to a collection of items</span></span>
------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-128">一般的なシナリオでは、ビジネス オブジェクトのコレクションにバインドします。</span><span class="sxs-lookup"><span data-stu-id="16554-128">A common scenario is to bind to a collection of business objects.</span></span> <span data-ttu-id="16554-129">C# と Visual Basic では、データ バインディングのコレクションには汎用の [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) クラスが適しています。このクラスは [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) インターフェイスと [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) インターフェイスを実装するためです。</span><span class="sxs-lookup"><span data-stu-id="16554-129">In C# and Visual Basic, the generic [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) class is a good collection choice for data binding, because it implements the [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) and [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) interfaces.</span></span> <span data-ttu-id="16554-130">これらのインターフェイスは、項目が追加または変更された場合や一覧自体のプロパティが変更された場合に、バインディングに変更を通知します。</span><span class="sxs-lookup"><span data-stu-id="16554-130">These interfaces provide change notification to bindings when items are added or removed or a property of the list itself changes.</span></span> <span data-ttu-id="16554-131">コレクション内のオブジェクトのプロパティの変更をバインドされたコントロールに反映する場合は、ビジネス オブジェクトでも **INotifyPropertyChanged** を実装します。</span><span class="sxs-lookup"><span data-stu-id="16554-131">If you want your bound controls to update with changes to properties of objects in the collection, the business object should also implement **INotifyPropertyChanged**.</span></span> <span data-ttu-id="16554-132">詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-132">For more info, see [Data binding in depth](data-binding-in-depth.md).</span></span>

<span data-ttu-id="16554-133">次の例では、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を `Recording` オブジェクトのコレクションにバインドしています。</span><span class="sxs-lookup"><span data-stu-id="16554-133">This next example binds a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to a collection of `Recording` objects.</span></span> <span data-ttu-id="16554-134">最初に、ビュー モデルにコレクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-134">Let's start by adding the collection to our view model.</span></span> <span data-ttu-id="16554-135">これらの新しいメンバーを **RecordingViewModel** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-135">Just add these new members to the **RecordingViewModel** class.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
    public class RecordingViewModel
    {
        ...
        private ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
        public ObservableCollection<Recording> Recordings { get { return this.recordings; } }
        public RecordingViewModel()
        {
            this.recordings.Add(new Recording() { ArtistName = "Johann Sebastian Bach",
            CompositionName = "Mass in B minor", ReleaseDateTime = new DateTime(1748, 7, 8) });
            this.recordings.Add(new Recording() { ArtistName = "Ludwig van Beethoven",
            CompositionName = "Third Symphony", ReleaseDateTime = new DateTime(1805, 2, 11) });
            this.recordings.Add(new Recording() { ArtistName = "George Frideric Handel",
            CompositionName = "Serse", ReleaseDateTime = new DateTime(1737, 12, 3) });
        }
    }
```
```cpp
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
            releaseDateTime->Month = 7;
            releaseDateTime->Day = 8;
            releaseDateTime->Year = 1748;
            Recording^ recording = ref new Recording{ L"Johann Sebastian Bach", L"Mass in B minor", releaseDateTime };
            this->Recordings->Append(recording);
            releaseDateTime = ref new Windows::Globalization::Calendar();
            releaseDateTime->Month = 2;
            releaseDateTime->Day = 11;
            releaseDateTime->Year = 1805;
            recording = ref new Recording{ L"Ludwig van Beethoven", L"Third Symphony", releaseDateTime };
            this->Recordings->Append(recording);
            releaseDateTime = ref new Windows::Globalization::Calendar();
            releaseDateTime->Month = 12;
            releaseDateTime->Day = 3;
            releaseDateTime->Year = 1737;
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

<span data-ttu-id="16554-136">次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を **ViewModel.Recordings** プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="16554-136">And then bind a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to the **ViewModel.Recordings** property.</span></span>

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{x:Bind ViewModel.Recordings}"
        HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Page>
```

<span data-ttu-id="16554-137">まだ **Recording** クラスのデータ テンプレートを用意していないため、UI フレームワークで [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の各項目について [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="16554-137">We haven't yet provided a data template for the **Recording** class, so the best the UI framework can do is to call [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) for each item in the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878).</span></span> <span data-ttu-id="16554-138">**ToString** の既定の実装は、型名を返すことです。</span><span class="sxs-lookup"><span data-stu-id="16554-138">The default implementation of **ToString** is to return the type name.</span></span>

![一覧ビューのバインド](images/xaml-databinding1.png)

<span data-ttu-id="16554-140">これを修正するには、**OneLineSummary** の値を返すように [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) をオーバーライドするか、データ テンプレートを用意します。</span><span class="sxs-lookup"><span data-stu-id="16554-140">To remedy this we can either override [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) to return the value of **OneLineSummary**, or we can provide a data template.</span></span> <span data-ttu-id="16554-141">データ テンプレートを使う方法は、より一般的であり、間違いなくより柔軟です。</span><span class="sxs-lookup"><span data-stu-id="16554-141">The data template option is more common and arguably more flexible.</span></span> <span data-ttu-id="16554-142">データ テンプレートを指定するには、コンテンツ コントロールの [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) プロパティか、項目コントロールの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="16554-142">You specify a data template by using the [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) property of a content control or the [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) property of an items control.</span></span> <span data-ttu-id="16554-143">**Recording** のデータ テンプレートをデザインするための 2 つの方法と結果の図を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="16554-143">Here are two ways we could design a data template for **Recording** together with an illustration of the result.</span></span>

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

<span data-ttu-id="16554-146">XAML 構文について詳しくは、「[XAML を使った UI の作成](https://msdn.microsoft.com/library/windows/apps/Mt228349)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-146">For more information about XAML syntax, see [Create a UI with XAML](https://msdn.microsoft.com/library/windows/apps/Mt228349).</span></span> <span data-ttu-id="16554-147">コントロール レイアウトについて詳しくは、「[XAML を使ったレイアウトの定義](https://msdn.microsoft.com/library/windows/apps/Mt228350)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-147">For more information about control layout, see [Define layouts with XAML](https://msdn.microsoft.com/library/windows/apps/Mt228350).</span></span>

<a name="adding-a-details-view"></a><span data-ttu-id="16554-148">詳細ビューの追加</span><span class="sxs-lookup"><span data-stu-id="16554-148">Adding a details view</span></span>
-----------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-149">[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) 項目内の **Recording** オブジェクトの詳細をすべて表示することを選択できます。</span><span class="sxs-lookup"><span data-stu-id="16554-149">You can choose to display all the details of **Recording** objects in [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) items.</span></span> <span data-ttu-id="16554-150">ただし、多くの領域が占有されます。</span><span class="sxs-lookup"><span data-stu-id="16554-150">But that takes up a lot of space.</span></span> <span data-ttu-id="16554-151">代わりに、項目を識別するのに十分な項目内のデータのみを表示し、ユーザーが選択を行ったら、選択された項目のすべての詳細を、詳細ビューと呼ばれる独立した UI に表示できます。</span><span class="sxs-lookup"><span data-stu-id="16554-151">Instead, you can show just enough data in the item to identify it and then, when the user makes a selection, you can display all the details of the selected item in a separate piece of UI known as the details view.</span></span> <span data-ttu-id="16554-152">この配置は、マスター/詳細ビューまたはリスト/詳細ビューとも呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="16554-152">This arrangement is also known as a master/details view, or a list/details view.</span></span>

<span data-ttu-id="16554-153">これには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="16554-153">There are two ways to go about this.</span></span> <span data-ttu-id="16554-154">詳細ビューを、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) プロパティにバインドできます。</span><span class="sxs-lookup"><span data-stu-id="16554-154">You can bind the details view to the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) property of the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878).</span></span> <span data-ttu-id="16554-155">または [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) を使うこともできます。**ListView** と詳細ビューの両方を **CollectionViewSource** にバインドします (現在選択されている項目が処理されます)。</span><span class="sxs-lookup"><span data-stu-id="16554-155">Or you can use a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833): bind both the **ListView** and the details view to the **CollectionViewSource** (which will take care of the currently-selected item for you).</span></span> <span data-ttu-id="16554-156">両方の手法を以下に示します。図のように、いずれも結果は同じになります。</span><span class="sxs-lookup"><span data-stu-id="16554-156">Both techniques are shown below, and they both give the same results shown in the illustration.</span></span>

> [!NOTE]
> <span data-ttu-id="16554-157">このトピックでは、これまで [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)のみを使ってきましたが、以下に示す 2 つの手法ではより柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)が必要です。</span><span class="sxs-lookup"><span data-stu-id="16554-157">So far in this topic we've only used the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783), but both of the techniques we'll show below require the more flexible (but less performant) [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782).</span></span>

<span data-ttu-id="16554-158">まず、[**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) の手法を示します。</span><span class="sxs-lookup"><span data-stu-id="16554-158">First, here's the [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) technique.</span></span> <span data-ttu-id="16554-159">Visual C++ コンポーネント拡張機能 (C++/CX) を使用している場合、ここでは [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を使用するため、[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) 属性を **Recording** クラスに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="16554-159">If you're using Visual C++ component extensions (C++/CX) then, because we'll be using [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782), you'll need to add the [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) attribute to the **Recording** class.</span></span>

```cpp
    [Windows::UI::Xaml::Data::Bindable]
    public ref class Recording sealed
    {
        ...
    };
```

<span data-ttu-id="16554-160">必要なもう 1 つの変更はマークアップに対する変更のみです。</span><span class="sxs-lookup"><span data-stu-id="16554-160">The only other change necessary is to the markup.</span></span>

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

<span data-ttu-id="16554-161">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) の手法では、最初にページ リソースとして **CollectionViewSource** を追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-161">For the [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) technique, first add a **CollectionViewSource** as a page resource.</span></span>

```xml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{x:Bind ViewModel.Recordings}"/>
    </Page.Resources>
```

<span data-ttu-id="16554-162">次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) (名前を付ける必要はない) と詳細ビューで、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) を使うようにバインディングを調整します。</span><span class="sxs-lookup"><span data-stu-id="16554-162">And then adjust the bindings on the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) (which no longer needs to be named) and on the details view to use the [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833).</span></span> <span data-ttu-id="16554-163">詳細ビューを **CollectionViewSource** に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。</span><span class="sxs-lookup"><span data-stu-id="16554-163">Note that by binding the details view directly to the **CollectionViewSource**, you're implying that you want to bind to the current item in bindings where the path cannot be found on the collection itself.</span></span> <span data-ttu-id="16554-164">バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="16554-164">There's no need to specify the **CurrentItem** property as the path for the binding, although you can do that if there's any ambiguity).</span></span>

```xml
    ...

    <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}">

    ...

    <StackPanel DataContext="{Binding Source={StaticResource RecordingsCollection}}" ...>
    ...
```

<span data-ttu-id="16554-165">次のように、いずれの場合も結果は同じです。</span><span class="sxs-lookup"><span data-stu-id="16554-165">And here's the identical result in each case.</span></span>

![一覧ビューのバインド](images/xaml-databinding4.png)

<a name="formatting-or-converting-data-values-for-display"></a><span data-ttu-id="16554-167">表示のためのデータ値の書式設定と変換</span><span class="sxs-lookup"><span data-stu-id="16554-167">Formatting or converting data values for display</span></span>
--------------------------------------------------------------------------------------------------------------------------------------------

<span data-ttu-id="16554-168">前のレンダリングには、小さな問題が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="16554-168">There is one small issue with the rendering above.</span></span> <span data-ttu-id="16554-169">**ReleaseDateTime** プロパティは日付だけではなく、[**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) であるため、必要以上の精度で表示されています。</span><span class="sxs-lookup"><span data-stu-id="16554-169">The **ReleaseDateTime** property is not just a date, it's a [**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx), so it's being displayed with more precision than we need.</span></span> <span data-ttu-id="16554-170">解決策の 1 つは、`this.ReleaseDateTime.ToString("d")` を返す **Recording** クラスに文字列プロパティを追加することです。</span><span class="sxs-lookup"><span data-stu-id="16554-170">One solution is to add a string property to the **Recording** class that returns `this.ReleaseDateTime.ToString("d")`.</span></span> <span data-ttu-id="16554-171">プロパティに **ReleaseDate** という名前を付けると、日付と時刻ではなく、日付が返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="16554-171">Naming that property **ReleaseDate** would indicate that it returns a date, not a date-and-time.</span></span> <span data-ttu-id="16554-172">**ReleaseDateAsString** という名前を付けると、さらに文字列が返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="16554-172">Naming it **ReleaseDateAsString** would further indicate that it returns a string.</span></span>

<span data-ttu-id="16554-173">より柔軟な解決策は、値コンバーターと呼ばれるものを使うことです。</span><span class="sxs-lookup"><span data-stu-id="16554-173">A more flexible solution is to use something known as a value converter.</span></span> <span data-ttu-id="16554-174">独自の値コンバーターを作成する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="16554-174">Here's an example of how to author your own value converter.</span></span> <span data-ttu-id="16554-175">次のコードを Recording.cs ソース コード ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="16554-175">Add this code to your Recording.cs source code file.</span></span>

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

<span data-ttu-id="16554-176">これで、**StringFormatter** のインスタンスをページ リソースとして追加し、バインドで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="16554-176">Now we can add an instance of **StringFormatter** as a page resource and use it in our binding.</span></span> <span data-ttu-id="16554-177">最終的な書式設定の柔軟性のために、マークアップからコンバーターに書式設定文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="16554-177">We pass the format string into the converter from markup for ultimate formatting flexibility.</span></span>

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

<span data-ttu-id="16554-178">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="16554-178">Here's the result.</span></span>

![カスタム形式での日付の表示](images/xaml-databinding5.png)

> [!NOTE]
> <span data-ttu-id="16554-180">Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="16554-180">Starting in Windows 10, version 1607, the XAML framework provides a built in boolean to Visibility converter.</span></span> <span data-ttu-id="16554-181">コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="16554-181">The converter maps **true** to the **Visible** enumeration value and **false** to **Collapsed** so you can bind a Visibility property to a boolean without creating a converter.</span></span> <span data-ttu-id="16554-182">組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="16554-182">To use the built in converter, your app's minimum target SDK version must be 14393 or later.</span></span> <span data-ttu-id="16554-183">アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。</span><span class="sxs-lookup"><span data-stu-id="16554-183">You can't use it when your app targets earlier versions of Windows 10.</span></span> <span data-ttu-id="16554-184">ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16554-184">For more info about target versions, see [Version adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

## <a name="see-also"></a><span data-ttu-id="16554-185">関連項目</span><span class="sxs-lookup"><span data-stu-id="16554-185">See also</span></span>
- [<span data-ttu-id="16554-186">データ バインディング</span><span class="sxs-lookup"><span data-stu-id="16554-186">Data binding</span></span>](index.md)
