---
xx.xxxxxxx: XYXYYXXX-XXYX-YYYY-XXXY-YYXXYYYYXYXX
xxxxx: Xxxx xxxxxxx xxxxxxxx
xxxxxxxxxxx: Xxxx xxxxx xxxxx xxx xxx xx xxxx x xxxxxxx (xx xxxxx XX xxxxxxx) xx x xxxxxx xxxx xx xxxx xx xxxxx xxxxxxx xx x xxxxxxxxxx xx xxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
---
Xxxx xxxxxxx xxxxxxxx
=====================

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxx xxxxx xxx xxx xx xxxx x xxxxxxx (xx xxxxx XX xxxxxxx) xx x xxxxxx xxxx xx xxxx xx xxxxx xxxxxxx xx x xxxxxxxxxx xx xxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx. Xx xxxxxxxx, xx xxxx xxx xx xxxxxxx xxx xxxxxxxxx xx xxxxx, xxxxxxxxx x xxxxxxx xxxx xxxxx xx x xxxxxxxxx, xxx xxxxxxx xxxx xxx xxxxxxx. Xxx xxxx xxxxxxxx xxxx, xxx [Xxxx xxxxxxx xx xxxxx](data-binding-in-depth.md).

Xxxxxxxxxxxxx
-------------------------------------------------------------------------------------------------------------

Xxxx xxxxx xxxxxxx xxxx xxx xxxx xxx xx xxxxxx x xxxxx XXX xxx. Xxx xxxxxxxxxxxx xx xxxxxxxx xxxx xxxxx XXX xxx, xxx [Xxxxxx xxxx xxxxx XXX xxx xxxxx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/Hh974581).

Xxxxxx xxx xxxxxxx
---------------------------------------------------------------------------------------------------------------------------------

Xxxxxx x xxx **Xxxxx Xxxxxxxxxxx (Xxxxxxx Xxxxxxxxx)** xxxxxxx. Xxxx xx "Xxxxxxxxxx".

Xxxxxxx xx x xxxxxx xxxx
---------------------------------------------------------------------------------------------------------------------------------------------------------

Xxxxx xxxxxxx xxxxxxxx xx x xxxxxxx xxxxxx xxx x xxxxxxx xxxxxx. Xxxxxxxxx, xxx xxxxxx xx x xxxxxxxx xx x xxxxxxx xx xxxxx XX xxxxxxx, xxx xxx xxxxxx xx x xxxxxxxx xx x xxxxx xxxxxxxx (x xxxx xxxxx, xx x xxxx xxxxx). Xxxx xxxxxxx xxxxx xxx xx xxxx x xxxxxxx xx x xxxxxx xxxx. Xxx xxxxxx xx xxx **Xxxx** xxxxxxxx xx x **XxxxXxxxx**. Xxx xxxxxx xx xx xxxxxxxx xx x xxxxxx xxxxx xxxxx **Xxxxxxxxx** xxxx xxxxxxxxxx xx xxxxx xxxxxxxxx. Xxx'x xxxx xx xxx xxxxx xxxxx.

Xxx x xxx xxxxx xx xxxx xxxxxxx, xxxx xx Xxxxxxxxx.xx (xx xxx'xx xxxxx X#), xxx xxx xxxx xxxx xx xx.

``` csharp
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

``` cpp
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

Xxxx, xxxxxx xxx xxxxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxx xxxxxxxxxx xxxx xxxx xx xxxxxx. Xx xx xxxx xx xxxxxx x xxxxxxxx xx xxxx **XxxxxxxxxXxxxXxxxx** xx **XxxxXxxx**.

``` csharp
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

``` cpp
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

Xxx xxxx xxxxx xx xx xxxx x **XxxxXxxxx** xx xxx **XxxxXxxxx.XxxxxxxXxxxxxxxx.XxxXxxxx** xxxxxxxx.

``` xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock Text="{x:Bind ViewModel.DefaultRecording.OneLineSummary}"
        HorizontalAlignment="Center"
        VerticalAlignment="Center"/>
    </Grid>
</Page>
```

Xxxx'x xxx xxxxxx.

![Xxxxxxx x xxxxxxxxx](images/xaml-databinding0.png)

Xxxxxxx xx x xxxxxxxxxx xx xxxxx
------------------------------------------------------------------------------------------------------------------

X xxxxxx xxxxxxxx xx xx xxxx xx x xxxxxxxxxx xx xxxxxxxx xxxxxxx. Xx X# xxx Xxxxxx Xxxxx, xxx xxxxxxx [**XxxxxxxxxxXxxxxxxxxx&xx;X&xx;**](T:System.Collections.ObjectModel.ObservableCollection%601) xxxxx xx x xxxx xxxxxxxxxx xxxxxx xxx xxxx xxxxxxx, xxxxxxx xx xxxxxxxxxx xxx [**XXxxxxxXxxxxxxxXxxxxxx**](T:System.ComponentModel.INotifyPropertyChanged) xxx [**XXxxxxxXxxxxxxxxxXxxxxxx**](T:System.Collections.Specialized.INotifyCollectionChanged) xxxxxxxxxx. Xxxxx xxxxxxxxxx xxxxxxx xxxxxx xxxxxxxxxxxx xx xxxxxxxx xxxx xxxxx xxx xxxxx xx xxxxxxx xx x xxxxxxxx xx xxx xxxx xxxxxx xxxxxxx. Xx xxx xxxx xxxx xxxxx xxxxxxxx xx xxxxxx xxxx xxxxxxx xx xxxxxxxxxx xx xxxxxxx xx xxx xxxxxxxxxx, xxx xxxxxxxx xxxxxx xxxxxx xxxx xxxxxxxxx **XXxxxxxXxxxxxxxXxxxxxx**. Xxx xxxx xxxx, xxx [Xxxx xxxxxxx xx xxxxx](data-binding-in-depth.md).

Xxxx xxxx xxxxxxx xxxxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878) xx x xxxxxxxxxx xx `Recording` xxxxxxx. Xxx'x xxxxx xx xxxxxx xxx xxxxxxxxxx xx xxx xxxx xxxxx. Xxxx xxx xxxxx xxx xxxxxxx xx xxx **XxxxxxxxxXxxxXxxxx** xxxxx.

``` csharp
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

``` cpp
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

And then bind a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) to the **ViewModel.Recordings** property.

``` xml
<Page x:Class="Quickstart.MainPage" ... >
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{x:Bind ViewModel.Recordings}"
        HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Page>
```

Xx xxxxx'x xxx xxxxxxxx x xxxx xxxxxxxx xxx xxx **Xxxxxxxxx** xxxxx, xx xxx xxxx xxx XX xxxxxxxxx xxx xx xx xx xxxx [**XxXxxxxx**](M:System.Object.ToString) xxx xxxx xxxx xx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878). Xxx xxxxxxx xxxxxxxxxxxxxx xx **XxXxxxxx** xx xx xxxxxx xxx xxxx xxxx.

![Xxxxxxx x xxxx xxxx](images/xaml-databinding1.png)

Xx xxxxxx xxxx xx xxx xxxxxx xxxxxxxx [**XxXxxxxx**](M:System.Object.ToString) xx xxxxxx xxx xxxxx xx **XxxXxxxXxxxxxx**, xx xx xxx xxxxxxx x xxxx xxxxxxxx. Xxx xxxx xxxxxxxx xxxxxx xx xxxx xxxxxx xxx xxxxxxxx xxxx xxxxxxxx. Xxx xxxxxxx x xxxx xxxxxxxx xx xxxxx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209369) xxxxxxxx xx x xxxxxxx xxxxxxx xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242830) xxxxxxxx xx xx xxxxx xxxxxxx. Xxxx xxx xxx xxxx xx xxxxx xxxxxx x xxxx xxxxxxxx xxx **Xxxxxxxxx** xxxxxxxx xxxx xx xxxxxxxxxxxx xx xxx xxxxxx.

``` xml
    <ListView ItemsSource="{x:Bind ViewModel.Recordings}"
        HorizontalAlignment="Center" VerticalAlignment="Center">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="local:Recording">
                <TextBlock Text="{x:Bind OneLineSummary}"/>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    ```

![Binding a list view](images/xaml-databinding2.png)

``` xml
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

![Xxxxxxx x xxxx xxxx](images/xaml-databinding3.png)

Xxx xxxx xxxxxxxxxxx xxxxx XXXX xxxxxx, xxx [Xxxxxx x XX xxxx XXXX](https://msdn.microsoft.com/library/windows/apps/Mt228349). Xxx xxxx xxxxxxxxxxx xxxxx xxxxxxx xxxxxx, xxx [Xxxxxx xxxxxxx xxxx XXXX](https://msdn.microsoft.com/library/windows/apps/Mt228350).

Xxxxxx x xxxxxxx xxxx
-----------------------------------------------------------------------------------------------------

Xxx xxx xxxxxx xx xxxxxxx xxx xxx xxxxxxx xx **Xxxxxxxxx** xxxxxxx xx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878) xxxxx. Xxx xxxx xxxxx xx x xxx xx xxxxx. Xxxxxxx, xxx xxx xxxx xxxx xxxxxx xxxx xx xxx xxxx xx xxxxxxxx xx xxx xxxx, xxxx xxx xxxx xxxxx x xxxxxxxxx, xxx xxx xxxxxxx xxx xxx xxxxxxx xx xxx xxxxxxxx xxxx xx x xxxxxxxx xxxxx xx XX xxxxx xx xxx xxxxxxx xxxx. Xxxx xxxxxxxxxxx xx xxxx xxxxx xx x xxxxxx/xxxxxxx xxxx, xx x xxxx/xxxxxxx xxxx.

Xxxxx xxx xxx xxxx xx xx xxxxx xxxx. Xxx xxx xxxx xxx xxxxxxx xxxx xx xxx [**XxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR209770) xxxxxxxx xx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878). Xx xxx xxx xxx x [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833): xxxx xxxx xxx **XxxxXxxx** xxx xxx xxxxxxx xxxx xx xxx **XxxxxxxxxxXxxxXxxxxx** (xxxxx xxxx xxxx xxxx xx xxx xxxxxxxxx-xxxxxxxx xxxx xxx xxx). Xxxx xxxxxxxxxx xxx xxxxx xxxxx, xxx xxxx xxxx xxxx xxx xxxx xxxxxxx xxxxx xx xxx xxxxxxxxxxxx.

**Xxxx**  Xx xxx xx xxxx xxxxx xx'xx xxxx xxxx xxx [{x:Xxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204783), xxx xxxx xx xxx xxxxxxxxxx xx'xx xxxx xxxxx xxxxxxx xxx xxxx xxxxxxxx (xxx xxxx xxxxxxxxxx) [{Xxxxxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204782).

Xxxxx, xxxx'x xxx [**XxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR209770) xxxxxxxxx. Xx xxx'xx xxxxx Xxxxxx X++ xxxxxxxxx xxxxxxxxxx (X++/XX) xxxx, xxxxxxx xx'xx xx xxxxx [{Xxxxxxx}](https://msdn.microsoft.com/library/windows/apps/Mt204782), xxx'xx xxxx xx xxx xxx [**XxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701872) xxxxxxxxx xx xxx **Xxxxxxxxx** xxxxx.

``` cpp
    [Windows::UI::Xaml::Data::Bindable]
    public ref class Recording sealed
    {
        ...
    };
```

Xxx xxxx xxxxx xxxxxx xxxxxxxxx xx xx xxx xxxxxx.

``` xml
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

Xxx xxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833) xxxxxxxxx, xxxxx xxx x **XxxxxxxxxxXxxxXxxxxx** xx x xxxx xxxxxxxx.

``` xml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{x:Bind ViewModel.Recordings}"/>
    </Page.Resources>
```

Xxx xxxx xxxxxx xxx xxxxxxxx xx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878) (xxxxx xx xxxxxx xxxxx xx xx xxxxx) xxx xx xxx xxxxxxx xxxx xx xxx xxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833). Xxxx xxxx xx xxxxxxx xxx xxxxxxx xxxx xxxxxxxx xx xxx **XxxxxxxxxxXxxxXxxxxx**, xxx'xx xxxxxxxx xxxx xxx xxxx xx xxxx xx xxx xxxxxxx xxxx xx xxxxxxxx xxxxx xxx xxxx xxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxx. Xxxxx'x xx xxxx xx xxxxxxx xxx **XxxxxxxXxxx** xxxxxxxx xx xxx xxxx xxx xxx xxxxxxx, xxxxxxxx xxx xxx xx xxxx xx xxxxx'x xxx xxxxxxxxx).

``` xml
    ...

    <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}">

    ...

    <StackPanel DataContext="{Binding Source={StaticResource RecordingsCollection}}" ...>
    ...
```

Xxx xxxx'x xxx xxxxxxxxx xxxxxx xx xxxx xxxx.

![Xxxxxxx x xxxx xxxx](images/xaml-databinding4.png)

Xxxxxxxxxx xx xxxxxxxxxx xxxx xxxxxx xxx xxxxxxx
--------------------------------------------------------------------------------------------------------------------------------------------

Xxxxx xx xxx xxxxx xxxxx xxxx xxx xxxxxxxxx xxxxx. Xxx **XxxxxxxXxxxXxxx** xxxxxxxx xx xxx xxxx x xxxx, xx'x x [**XxxxXxxx**](T:System.DateTime), xx xx'x xxxxx xxxxxxxxx xxxx xxxx xxxxxxxxx xxxx xx xxxx. Xxx xxxxxxxx xx xx xxx x xxxxxx xxxxxxxx xx xxx **Xxxxxxxxx** xxxxx xxxx xxxxxxx `this.ReleaseDateTime.ToString("d")`. Xxxxxx xxxx xxxxxxxx **XxxxxxxXxxx** xxxxx xxxxxxxx xxxx xx xxxxxxx x xxxx, xxx x xxxx-xxx-xxxx. Xxxxxx xx **XxxxxxxXxxxXxXxxxxx** xxxxx xxxxxxx xxxxxxxx xxxx xx xxxxxxx x xxxxxx.

X xxxx xxxxxxxx xxxxxxxx xx xx xxx xxxxxxxxx xxxxx xx x xxxxx xxxxxxxxx. Xxxx'x xx xxxxxxx xx xxx xx xxxxxx xxxx xxx xxxxx xxxxxxxxx. Xxx xxxx xxxx xx xxxx Xxxxxxxxx.xx xxxxxx xxxx xxxx.

``` csharp
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

Xxx xx xxx xxx xx xxxxxxxx xx **XxxxxxXxxxxxxxx** xx x xxxx xxxxxxxx xxx xxx xx xx xxx xxxxxxx. Xx xxxx xxx xxxxxx xxxxxx xxxx xxx xxxxxxxxx xxxx xxxxxx xxx xxxxxxxx xxxxxxxxxx xxxxxxxxxxx.

``` xml
    <Page.Resources>
        <local:StringFormatter x:Key="StringFormatterValueConverter"/>
    </Page.Resources>
    ...

    <TextBlock Text="{Binding ReleaseDateTime,
        Converter={StaticResource StringFormatterValueConverter}
        ConverterParameter=Released: \{0:d\}}"/>

    ...
```

Xxxx'x xxx xxxxxx.

![xxxxxxxxxx x xxxx xxxx xxxxxx xxxxxxxxxx](images/xaml-databinding5.png)


<!--HONumber=Mar16_HO1-->
