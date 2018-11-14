---
author: stevewhims
ms.assetid: A9D54DEC-CD1B-4043-ADE4-32CD4977D1BF
title: データ バインディングの概要
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目のコントロールを項目のコレクションにバインドする方法を説明します。
ms.author: stwhi
ms.date: 10/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cppcx
ms.openlocfilehash: 581c2bc4204a7eab002ef2680e335a4109716d74
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6183615"
---
# <a name="data-binding-overview"></a>データ バインディングの概要

このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。 また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。 詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このトピックでは、基本的な UWP アプリを作成できることを前提としています。 初めての UWP アプリを作成する方法について、詳しくは「[Windows アプリの概要](https://developer.microsoft.com/windows/getstarted)」をご覧ください。

## <a name="create-the-project"></a>プロジェクトの作成

最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。 プロジェクトに "Quickstart" という名前を付けます。

## <a name="binding-to-a-single-item"></a>単一の項目へのバインド

すべてのバインディングにはバインディング ターゲットとバインディング ソースがあります。 通常、ターゲットはコントロールまたは他の UI 要素のプロパティであり、ソースはクラス インスタンス (データ モデルやビュー モデル) のプロパティです。 コントロールを単一の項目にバインドする例を次に示します。 ターゲットは **TextBlock** の **Text** プロパティです。 ソースは、オーディオの録音を表す **Recording** という名前の単純なクラスのインスタンスです。 まずクラスを見てみましょう。

C# または C++ を使っている場合 +/CX し、プロジェクトに新しいクラスを追加するクラス**レコーディング**の名前します。

使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、という名前の c++ に示すように、プロジェクトに新しい**Midl ファイル (.idl)** 項目を追加/WinRT コードの例の一覧が以下。 これらの新しいファイルの内容を一覧に表示される[MIDL 3.0](/uwp/midl-3/intro)コードに置き換えます、生成するプロジェクトをビルド`Recording.h`と`.cpp`と`RecordingViewModel.h`と`.cpp`、し、登録情報に一致するように、生成されたファイルにコードを追加します。 生成されたファイルについて詳しくは、プロジェクトにコピーする方法を参照してください[XAML コントロール、バインドを C++/WinRT プロパティ](/windows/uwp/cpp-and-winrt-apis/binding-property)。

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
    runtimeclass Recording
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
    runtimeclass RecordingViewModel
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

```cppcx
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

次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。 これを行うには、**RecordingViewModel** 型のプロパティを **MainPage** に追加します。

使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、最初の更新し、 `MainPage.idl`。 再生成するプロジェクトをビルド`MainPage.h`と`.cpp`、それらの生成されたファイルの変更をプロジェクトにあるものにマージします。

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

```cppcx
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

最後の部分では、**TextBlock** を **ViewModel.DefaultRecording.OneLiner** プロパティにバインドします。

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock Text="{x:Bind ViewModel.DefaultRecording.OneLineSummary}"
    HorizontalAlignment="Center"
    VerticalAlignment="Center"/>
    </Grid>
</Page>
```

使用する場合は[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、プロジェクトをビルドするための順序で**mainpage::clickhandler**関数を削除する必要があります。

結果は次のようになります。

![テキストブロックのバインド](images/xaml-databinding0.png)

## <a name="binding-to-a-collection-of-items"></a>項目のコレクションへのバインド

一般的なシナリオでは、ビジネス オブジェクトのコレクションにバインドします。 C# と Visual Basic では、データ バインディングのコレクションには汎用の [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) クラスが適しています。このクラスは [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) インターフェイスと [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) インターフェイスを実装するためです。 これらのインターフェイスは、項目が追加または変更された場合や一覧自体のプロパティが変更された場合に、バインディングに変更を通知します。 コレクション内のオブジェクトのプロパティの変更をバインドされたコントロールに反映する場合は、ビジネス オブジェクトでも **INotifyPropertyChanged** を実装します。 詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。

使っている場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、監視可能なコレクションにバインドする方法の詳細については、その[XAML アイテム コントロール: c++ へのバインド/WinRT コレクション](/windows/uwp/cpp-and-winrt-apis/binding-collection)します。 かどうかするトピックを読むと、最初に、し、c++ の意図/WinRT コードの一覧を次にはより明確になります。

次の例では、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を `Recording` オブジェクトのコレクションにバインドしています。 最初に、ビュー モデルにコレクションを追加します。 これらの新しいメンバーを **RecordingViewModel** クラスに追加します。

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

```cppcx
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

次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を **ViewModel.Recordings** プロパティにバインドします。

```xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{x:Bind ViewModel.Recordings}"
        HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Page>
```

まだ **Recording** クラスのデータ テンプレートを用意していないため、UI フレームワークで [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の各項目について [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。 **ToString** の既定の実装は、型名を返すことです。

![一覧ビューのバインド](images/xaml-databinding1.png)

この問題を解決するには、 **OneLineSummary**の値を返す[**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx)を無効にできますか、またはデータ テンプレートを提供します。 データ テンプレートのオプションより通常のソリューションと柔軟性の向上の 1 つです。 データ テンプレートを指定するには、コンテンツ コントロールの [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) プロパティか、項目コントロールの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) プロパティを使います。 **Recording** のデータ テンプレートをデザインするための 2 つの方法と結果の図を以下に示します。

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

XAML 構文について詳しくは、「[XAML を使った UI の作成](https://msdn.microsoft.com/library/windows/apps/Mt228349)」をご覧ください。 コントロール レイアウトについて詳しくは、「[XAML を使ったレイアウトの定義](https://msdn.microsoft.com/library/windows/apps/Mt228350)」をご覧ください。

## <a name="adding-a-details-view"></a>詳細ビューの追加

[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) 項目内の **Recording** オブジェクトの詳細をすべて表示することを選択できます。 ただし、多くの領域が占有されます。 代わりに、項目を識別するのに十分な項目内のデータのみを表示し、ユーザーが選択を行ったら、選択された項目のすべての詳細を、詳細ビューと呼ばれる独立した UI に表示できます。 この配置は、マスター/詳細ビューまたはリスト/詳細ビューとも呼ばれます。

これには 2 つの方法があります。 詳細ビューを、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) プロパティにバインドできます。 または、(の現在選択されている項目のためは、注意を行う) **CollectionViewSource**を**ListView**と詳細ビューの両方をバインドする場合、 [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833)を使うことができます。 両方の手法が次に示すし、(図に示すように) 同じ結果が提供されます。

> [!NOTE]
> このトピックでは、これまで [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)のみを使ってきましたが、以下に示す 2 つの手法ではより柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)が必要です。

使用する場合、C++/WinRT または VisualC ではコンポーネント拡張機能 (、C++/cli CX) し、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用する必要がありますにバインドする任意のランタイム クラスを[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性を追加します。 [{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用するには、その属性を必要はありません。

> [!IMPORTANT]
> 使用している場合[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、 [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性は、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールした場合に利用可能なまたはそれ以降。 その属性がない場合は、 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)マークアップ拡張機能を使用する[ICustomPropertyProvider](/uwp/api/windows.ui.xaml.data.icustompropertyprovider)と[ICustomProperty](/uwp/api/windows.ui.xaml.data.icustomproperty)インターフェイスを実装する必要があります。

まず、[**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) の手法を示します。

```csharp
// No code changes necessary for C#.
```

```cppwinrt
// Recording.idl
// Add this attribute:
...
[Windows.UI.Xaml.Data.Bindable]
runtimeclass Recording
...
```

```cppcx
[Windows::UI::Xaml::Data::Bindable]
public ref class Recording sealed
{
    ...
};
```

必要なもう 1 つの変更はマークアップに対する変更のみです。

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

[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) の手法では、最初にページ リソースとして **CollectionViewSource** を追加します。

```xml
<Page.Resources>
    <CollectionViewSource x:Name="RecordingsCollection" Source="{x:Bind ViewModel.Recordings}"/>
</Page.Resources>
```

次に、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) (名前を付ける必要はない) と詳細ビューで、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) を使うようにバインディングを調整します。 詳細ビューを **CollectionViewSource** に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。 バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。

```xml
...
<ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}">
...
<StackPanel DataContext="{Binding Source={StaticResource RecordingsCollection}}" ...>
...
```

次のように、いずれの場合も結果は同じです。

> [!NOTE]
> C++ を使用している場合、UI を検索しません次の図とまったく同じ: **ReleaseDateTime**プロパティのレンダリングは異なります。 詳細については、次のセクションを参照してください。

![一覧ビューのバインド](images/xaml-databinding4.png)

## <a name="formatting-or-converting-data-values-for-display"></a>表示のためのデータ値の書式設定と変換

前のレンダリングに問題があります。 **ReleaseDateTime**プロパティは、日付だけではなく、 [**DateTime**](/uwp/api/windows.foundation.datetime) ([**カレンダー**](/uwp/api/windows.globalization.calendar)は、C++ を使用している) 場合。 そのため、c# でそれが表示されているの必要な精度でします。 C++ でレンダリングされる型名としてします。 1 つのソリューションと同等の結果を返す**レコーディング**クラスに文字列プロパティを追加するには`this.ReleaseDateTime.ToString("d")`します。 **ReleaseDate**そのプロパティの名前を付けると、日付、およびしない、日付と時間が返されることを示します。 **ReleaseDateAsString** という名前を付けると、さらに文字列が返されることを示します。

より柔軟な解決策は、値コンバーターと呼ばれるものを使うことです。 独自の値コンバーターを作成する方法の例を示します。 次のコードを Recording.cs ソース コード ファイルに追加します。

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

```cppcx
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

これで、**StringFormatter** のインスタンスをページ リソースとして追加し、バインドで使うことができます。

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

上記わかるように、柔軟性を書式設定のマークアップを使ってコンバーター パラメーターを使用してコンバーターに書式文字列を渡します。 によってのみ、c# 値コンバーターは、このトピックに示すようにコードの例では、そのパラメーターの使用します。 簡単に C++ スタイル形式の文字列をコンバーター パラメーターとして渡すし、 **wprintf**や**swprintf**などの書式設定の関数を使って、値コンバーターを使用する可能性があります。

結果は次のようになります。

![カスタム形式での日付の表示](images/xaml-databinding5.png)

> [!NOTE]
> Windows 10、バージョン 1607 では、以降では、XAML フレームワークは、組み込みの表示のブール値コンバーターを提供します。 コンバーターにマップ**true** **Visibility.Visible**列挙値と**false** **Visibility.Collapsed**を Visibility プロパティをブール値にバインドするには、コンバーターを作成することがなくようにします。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)を参照してください。

## <a name="see-also"></a>関連項目
* [データ バインディング](index.md)
