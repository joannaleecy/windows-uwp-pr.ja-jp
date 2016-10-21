---
author: mcleblanc
ms.assetid: A9D54DEC-CD1B-4043-ADE4-32CD4977D1BF
title: "データ バインディングの概要"
description: "このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。"
translationtype: Human Translation
ms.sourcegitcommit: e89580ef62d5d6ae095aa27628181181aaac9666
ms.openlocfilehash: d452751fd4ab0cc422c3eae94507923440ec45df

---
データ バインディングの概要
=====================

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。 また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。 詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。

前提条件
-------------------------------------------------------------------------------------------------------------

このトピックでは、基本的な UWP アプリを作成できることを前提としています。 初めての UWP アプリを作成する方法について、詳しくは「[Windows アプリの概要](https://developer.microsoft.com/en-us/windows/getstarted)」をご覧ください。

プロジェクトの作成
---------------------------------------------------------------------------------------------------------------------------------

最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。 プロジェクトに "Quickstart" という名前を付けます。

単一の項目へのバインド
---------------------------------------------------------------------------------------------------------------------------------------------------------

すべてのバインディングにはバインディング ターゲットとバインディング ソースがあります。 通常、ターゲットはコントロールまたは他の UI 要素のプロパティであり、ソースはクラス インスタンス (データ モデルやビュー モデル) のプロパティです。 コントロールを単一の項目にバインドする例を次に示します。 ターゲットは **TextBlock** の **Text** プロパティです。 ソースは、オーディオの録音を表す **Recording** という名前の単純なクラスのインスタンスです。 まずクラスを見てみましょう。

プロジェクトに新しいクラスを追加して Recording.cs (C#、または下記の C++ スニペットを使用している場合) という名前を付け、次のコードを追加します。

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
                    return ref new Platform::String(wstringstream.str().c-str());
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

次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。 これを行うには、**RecordingViewModel** 型のプロパティを **MainPage** に追加します。

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

結果は次のようになります。

![テキストブロックのバインド](images/xaml-databinding0.png)

項目のコレクションへのバインド
------------------------------------------------------------------------------------------------------------------

一般的なシナリオでは、ビジネス オブジェクトのコレクションにバインドします。 C# と Visual Basic では、データ バインディングのコレクションには汎用の [**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) クラスが適しています。このクラスは [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) インターフェイスと [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) インターフェイスを実装するためです。 これらのインターフェイスは、項目が追加または変更された場合や一覧自体のプロパティが変更された場合に、バインディングに変更を通知します。 コレクション内のオブジェクトのプロパティの変更をバインドされたコントロールに反映する場合は、ビジネス オブジェクトでも **INotifyPropertyChanged** を実装します。 詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。

次の例では、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を `Recording` オブジェクトのコレクションにバインドしています。 最初に、ビュー モデルにコレクションを追加します。 これらの新しいメンバーを **RecordingViewModel** クラスに追加します。

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

これを修正するには、**OneLineSummary** の値を返すように [**ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) をオーバーライドするか、データ テンプレートを用意します。 データ テンプレートを使う方法は、より一般的であり、間違いなくより柔軟です。 データ テンプレートを指定するには、コンテンツ コントロールの [**ContentTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209369) プロパティか、項目コントロールの [**ItemTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242830) プロパティを使います。 **Recording** のデータ テンプレートをデザインするための 2 つの方法と結果の図を以下に示します。

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

詳細ビューの追加
-----------------------------------------------------------------------------------------------------

[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) 項目内の **Recording** オブジェクトの詳細をすべて表示することを選択できます。 ただし、多くの領域が占有されます。 代わりに、項目を識別するのに十分な項目内のデータのみを表示し、ユーザーが選択を行ったら、選択された項目のすべての詳細を、詳細ビューと呼ばれる独立した UI に表示できます。 この配置は、マスター/詳細ビューまたはリスト/詳細ビューとも呼ばれます。

これには 2 つの方法があります。 詳細ビューを、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) の [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) プロパティにバインドできます。 または [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) を使うこともできます。**ListView** と詳細ビューの両方を **CollectionViewSource** にバインドします (現在選択されている項目が処理されます)。 両方の手法を以下に示します。図のように、いずれも結果は同じになります。

> [!NOTE]
> このトピックでは、これまで [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)のみを使ってきましたが、以下に示す 2 つの手法ではより柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)が必要です。

まず、[**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) の手法を示します。 Visual C++ コンポーネント拡張機能 (C++/CX) を使用している場合、ここでは [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を使用するため、[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) 属性を **Recording** クラスに追加する必要があります。

```cpp
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

![一覧ビューのバインド](images/xaml-databinding4.png)

表示のためのデータ値の書式設定と変換
--------------------------------------------------------------------------------------------------------------------------------------------

前のレンダリングには、小さな問題が 1 つあります。 **ReleaseDateTime** プロパティは日付だけではなく、[**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) であるため、必要以上の精度で表示されています。 解決策の 1 つは、`this.ReleaseDateTime.ToString("d")` を返す **Recording** クラスに文字列プロパティを追加することです。 プロパティに **ReleaseDate** という名前を付けると、日付と時刻ではなく、日付が返されることを示します。 **ReleaseDateAsString** という名前を付けると、さらに文字列が返されることを示します。

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

これで、**StringFormatter** のインスタンスをページ リソースとして追加し、バインドで使うことができます。 最終的な書式設定の柔軟性のために、マークアップからコンバーターに書式設定文字列を渡します。

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

結果は次のようになります。

![カスタム形式での日付の表示](images/xaml-databinding5.png)

> [!NOTE]
> Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。 コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

## 関連項目
- [データ バインディング](index.md)



<!--HONumber=Sep16_HO1-->


