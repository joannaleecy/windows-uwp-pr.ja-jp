---
xx.xxxxxxx: YYYYYYXY-YXXX-YYYY-YYYY-XYYYXYXYYYYY
xxxxx: Xxxxxx xxxx xx xxx xxxxxx xxxxxxx, xxx xxx xxxxxxxxxxx
xxxxxxxxxxx: Xx xxx xx xxxxxxxxxx xx xxxxxxxxxxx (xxxxxxx xxx xxxxxxx xx xxxxxxx xx xxxxxxxxxxx) xxx xxxx xxx xx xxxxxxx xxxx xxxx xx xxx xxxxxx xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx.
---
Xxxxxx xxxx xx xxx xxxxxx xxxxxxx, xxx xxx xxxxxxxxxxx
=============================================================================================

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxx**  Xxx xxxxxx xx xxxxx xxx xxxx xxxxxx xxxx—xxx xxx xxxx xx xxxx xxxx xxx—xxxxxxx xx xxxxxxx xxxx xxxxxxxx xxx xxx [{Xxxxxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204782) xx xxx [{x:Xxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204783). Xxx xxxxxxxxxx xxxxxxxxx xx xxxx xxxxx xxx xxxxx xx xxx xxx xx x [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208713), xx xxxx'xx xxxx xxxxxxxxxxx xxx **{Xxxxxxx}**. Xxx xx xxx'xx xxxxx **{x:Xxxx}** xxxx xxxx xxxxxxxx xx xxxxx xxxx xxxxxxxxxxx xxxxxx xx xxx xxxxxx xxxxxxx (xxxx xxx xxxxx xxxxxxxx), xx xxx xxx'x xxxx xxxxx xxx xxxx xxxx xxx xxxxxx xxxx.

Xx xxx xx xxxxxxxxxx xx xxxxxxxxxxx (xxxxxxx xxx xxxxxxx xx xxxxxxx xx xxxxxxxxxxx) xxx xxxx xxx xx xxxxxxx xxxx xxxx xx xxx xxxxxx xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx. Xx xxxxx xx xxxx xxxx xxxxxxxx xxxxxxxxx xxxx xxxx (xx xxxx xxx xxx xxxx xx xxxx xxx'x xxxxxx, xxxxxxxxx, xxx xxxxx xxxxxx xxxxxxxxxx), xxxxx xxx xxxxxxx xxxx xx xxxxx xxx xxx xxx xxxxxx-xxxx xxxxxx xxxx. Xxxxxx xxxx xxx xxxx xx xxxxxx xxxxxx xxx xxxx-xxxxxx xx xxx'xx xxxxxxxx x xxxxxx (xx xxxxxxxxx) xxx. Xxx xxx xxx xxxxxx xxxx xx xxxx xxxxxx xx xxxxxxxxx xx xxx-xxxx xx xxxxxxxxxx xxxx xxxxx xxxxxxx xxxxx xx xxx xx xxxxxxxxxx xx xxxx, xxxx xxxx.

Xxxxxxx XxxxXxxxxxx xx xxxxxx
-----------------------------

Xx'x x xxxxxx xxxxxx xxxxxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxx (xx xxxx-xxxxxx) xx xxx x xxxx xx xxxx xxxxxxx'x [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208713) xx x xxxx xxxxx xxxxxxxx.

``` csharp
public MainPage()
{
    InitializeComponent();
    this.DataContext = new BookstoreViewModel();
}
```

Xxx xx xxx xx xxxx xxxx xxxx xxxx xxx'x xx "xxxxxxxxxx" xx xx xxxxx xx. Xxx xxxxxx xx xxxx xxxx xxxx XXXX xxxx xx xxxxxx xx Xxxxxx Xxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx, xxx xxxxxxxxxx xxxx xxxx xxxxxxx xxx **XxxxXxxxxxx** xxxxx xx xxxxx xxx (xx xxxx, xxxx xx xxxx xxxx-xxxxxx xx xxxxxxxx). Xxx XXXX xxxxx xx xx xxxxxx xxxxx xxxx xxxxxx xxx xxxxxxxxxxx xxx xxxxxxx xxxxxxxx xx xx, xxx xxxx xxx'x xxxxxxxx xxxxxxxxxxx xxxx xxxx'x xxxx xxxxxx. Xxx xxxxxx xx xxxx xxx xxx'x xxx xxx xxxx xx xxxx xxxxxxxx xx xx xxx **Xxxxxx Xxxx Xxxxxxx** xxxxxx, xxx xxxx xxxx xxxx xx xxxx xxxxxxxxxxx xx xxxxx xxx xx xxx xxx.

![Xxxxxx xxxxxx XX.](images/displaying-data-in-the-designer-01.png)

Xxx xxxxx xxxxxx xx xxx xx xx xxxxxxx xxx xxxx **XxxxXxxxxxx** xxxxxxxxxx xxx xxx xxx **XxxxXxxxxxx** xx xxxx xxxx xxxxxx xxxxxxx. Xxxx xxx, xxxx xxxx xxxx xxxxx xx xx xxxxxx-xxxx xx xxxx xx xx xxx-xxxx. Xx xx xxxx, xxxxx xxxx xxxx XXXX xxxx. Xxxx, xx xxx **Xxxxxxxx Xxxxxxx** xxxxxx, xxxxx xxx xxxx xxxxxxxxxx xxxxxxx (xxxxxxx xxxx xxx xxxxx **\[Xxxx\]**) xx xxxxxx xx. Xx xxx **Xxxxxxxxxx** xxxxxx, xxxx xxx **XxxxXxxxxxx** xxxxxxxx (xxxxxx xxx Xxxxxx xxxxxxxx), xxx xxxx xxxxx **Xxx**. Xxxxx xxxx xxxx xxxxx xxxx xxxx xxx **Xxxxxx Xxxxxx** xxxxxx xxx, xxx xxxx xxxxx **XX**.

![XX xxx xxxxxxx XxxxXxxxxxx.](images/displaying-data-in-the-designer-02.png)

Xxxx'x xxxx xxx xxxxxxxxx xxxxxx xxxxx xxxx.

``` xml
<Page ... >
    <Page.DataContext>
        <local:BookstoreViewModel/>
    </Page.DataContext>
```

Xxx xxxx’x xxxx xxx xxxxxx xxxxxxx xxxxx xxxx xxx xxxx xxxx xxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxx **Xxxx** xxxxxx xx xxx **Xxxxxx Xxxx Xxxxxxx** xxxxxx xx xxx xxxxxxxxx, xxxxx xx xxx **XxxxXxxxxxx** xxxx xxx xxx xxxxxxxxxx xxxx xxx xxx xxxx xx.

![Xxxxxxxxxx XX.](images/displaying-data-in-the-designer-03.png)

Xxx **Xxxxxx Xxxx Xxxxxxx** xxxxxx xxxx xxxxx x xxxx xx xxxx xxxx, xxx xxx xxxxxxxx xxxx xxx xxxxxxxxxx xx xx xxxxxxxxxxx xxxx xxxxxx. Xx xxx xxx'x xxxx xx xxxxx xxx xx xxxx xxxxx xxxxxxx xx xxxxxx-xxxx (xxx xx xxxxxxxxxxx, xxxxxx xxx xxxx xxxxxxxx, xxxxxxx xxxxxx, xxxx xxxx xx xxxxx) xxxx xxxx xxxxxxxxxxxxxx xxxx xxx xxxxx xx xxx xxxxxxx xxxx xxx xx xxxxxxx xx x xxxxxx xxxx (xxxx xx Xxxxxx Xxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx) xxx xx xxxx xxxx xxxx xxxxxx xxxx xxx xxx xx xxxxxx-xxxx xxxx.

``` csharp
if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
{
    // Load design-time books.
}
else
{
    // Load books from a cloud service.
}
```

Xxx xxxxx xxx x xxxx xxxxx xxxxxxx xx xxx xxxx xx xxxx xxxxxxxxxx xx xxxx xxxxxxxxxxxxxx xxxx. X xxxx xxxxx xxxxxxx xx x xxxxx xxxx xxx xxx xxx xxxx xxx xxxxxxxxx. Xx xxx x xxxxxxxx xxxx xxxxxxx xxx xxxx xxxxx, xxx xxxx xxxx'x **XxxxXxxxxxx** xxxxx xx xxxx xxxxxxxx. Xxxxxxx xxxxxxx xxxx xxx xxxxxxx xx xxx xxxx xxxxx xxx xxx xx xxxxxxxxxx xxxxxxxxx, xxxxx xxx xxxxxxxxx x xxxxxx-xxxx xx x xxx-xxxx xxxx xxxxxxxx (xxxx xx xxxxx xxxxxxxxxx x xxxxxx xxxxxxxxx), xx xxxxxxxxxx.

"Xxxxxx xxxx xxxx xxxxx", xxx xxxxxx-xxxx xxxxxxxxxx
---------------------------------------------------------------------------------------

Xx xxx xxxxxxxx xxxxxx xxxx xx xxx xxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxx xxxx xxx xxxxx xxxx xxxxxx xx xxxxxx-xxxx xxxx xxxxxxx xxxxxxxxx xxx XXXX xxxxx xxxxxxxx xxx xxxxxx-xxxx xxxxxxxxxx. Xxx xxxx xxxxxx xx xxx **Xxxxxx Xxxxxx Xxxx xxxx Xxxxx** xxxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx. Xxx xxx xxxx xxxx xxxxxxx xx xxx xx xxx xxxxxxx xx xxx xxx xx xxx **Xxxx** xxxxx.

Xxx xxx xxxx xx xx xx xx xxxxxxx x xxxxx xxx xxx xxxxxxx xx xxx. Xxx xxxxxxx xxxx xxxx xxx xxxxxxxxx xxxxxx xxx xxx. Xxxxx, xx xxxxxxxxx x XXXX xxxx xxxx xxxxxxxx xxxxxx xxxx xxxxxxxx xxx xxxxxxxxx xx xxxxxxxx xx xxxx xxxxxx xxxxx xxx xxx xx xxx xxxxxxx, xxxxxxxxxxx (xx xxxx, xxx xxxxxxx xxxxx xxxxxxx xxxx xxxx XXXX xx XXXX xxxxx). Xxxxxx, xx xxxxxxxxx xxx **Xxxx** xxxxx xxxx xxx xxxxxx xx xxxx xxxxxx xxxxx. Xxx xxx xxxx xxxx xxxxxxx xxxx xxx **Xxxx** xxxxx xxxx xxx xxxxxx xxxxxxx xx xxxxxxx xxxxxxx xxxxx. Xxxxxxxxx xx xxxx xxx xxxx xxx xxxxx xxx xxxx xx, xxx xxx xxx xxxxxxxx xx xxxxxxxx xxxxxxxx (xxxxx **{Xxxxxxx}**), xx xxxxxx xxx xxxxxxxx xxx xxxx xxxx xx xxx xxxx xxxx. Xx xxxxxx xxxx, xxx xxxxxxxxx xxxx xxxx x xxxxxx-xxxx xxxx xxxxxxx (**x:XxxxXxxxxxx**) xxx xxx (xx xxx xx xxx xxxxxxx xxx) xx xxx xxxxxx xxxx xx xxxx xxxx. Xxxx xxxxxx-xxxx xxxx xxxxxxx xxxx xxx **x:XxxxxxXxxx** xxxxxxxxx xx xxx xxx xxxxxx xxxx xxxx xxx XXXX xxxx xxxx xxx xxxxxxxxx (xxxxx, xx xxx xxx, xxx xxx xxxx xx xxxx xx xxxx xxxxxxx xxx xxxx xx xxxx xx xxxxxxxx xxx xxxxxx xxxx xxx xxxx).

``` xml
<Page ...
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
    <Grid ... d:DataContext="{d:DesignData /SampleData/RecordingViewModelSampleData.xaml}"/>
        <ListView ItemsSource="{Binding Recordings}" ... />
        ...
    </Grid>
</Page>
```

Xxx xxxxxxx xxxxx xxxxxxxxxxxx xxxx xxxx xxxxxxxxxx xxxx xxx **x:** xxxxxx xxx xxxxxxxxxxx xxxx xx xxxxxx-xxxx xxx xxx xxxxxxx xx xxx-xxxx. Xx xxx **x:XxxxXxxxxxx** xxxxxxxxx xxxx xxxxxxx xxx xxxxx xx xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208713) xxxxxxxx xx xxxxxx-xxxx; xx xxx xx xxxxxx xx xxx-xxxx. Xxx xxx xxxx xxx xxxx **x:XxxxXxxxxxx** xxx **XxxxXxxxxxx** xx xxxxxx xx xxx xxxx. **x:XxxxXxxxxxx** xxxx xxxxxxxx xx xxxxxx-xxxx, xxx **XxxxXxxxxxx** xxxx xxxxxxxx xx xxx-xxxx. Xxxxx xxxx xxxxxxxx xxxxx xxxxx xx xxx xxxxxx-xxxx xxx xxx-xxxx xxxxxxxxxx.

Xxx **x:XxxxXxxxxxx** xxxxxxxxx, xxx xxx xxxxx xxxxxx-xxxx xxxxxxxxxx, xxx xxxxxxxxxx xx xxx [Xxxxxx-Xxxx Xxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=272504) xxxxx, xxxxx xx xxxxx xxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.

[
            **XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833) xxxxx'x xxxx x **XxxxXxxxxxx** xxxxxxxx, xxx xx xxxx xxxx x **Xxxxxx** xxxxxxxx. Xxxxxxxxxxxx, xxxxx'x x **x:Xxxxxx** xxxxxxxx xxxx xxx xxx xxx xx xxx xxxxxx-xxxx-xxxx xxxxxx xxxx xx x **XxxxxxxxxxXxxxXxxxxx**.

``` xml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
            d:Source="{d:DesignData /SampleData/RecordingsSampleData.xaml}"/>
    </Page.Resources>

    ...

        <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}" ... />
    ...
```

Xxx xxxx xx xxxx, xxx xxxxx xxxx x xxxxx xxxxx `Recordings : ObservableCollection<Recording>`, xxx xxx xxxxx xxxx xxx xxxxxx xxxx XXXX xxxx xx xxxx xx xxxxxxxx xxxx x **Xxxxxxxxxx** xxxxxx (xxxx **Xxxxxxxxx** xxxxxxx xxxxxx xxxx), xx xxxxx xxxx.

``` xml
<Quickstart:Recordings xmlns:Quickstart="using:Quickstart">
    <Quickstart:Recording ArtistName="Mollis massa" CompositionName="Cubilia metus"
        OneLineSummary="Morbi adipiscing sed" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Vulputate nunc" CompositionName="Parturient vestibulum"
        OneLineSummary="Dapibus praesent netus amet vestibulum" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Phasellus accumsan" CompositionName="Sit bibendum"
        OneLineSummary="Vestibulum egestas montes dictumst" ReleaseDateTime="01/01/1800 15:53:17"/>
</Quickstart:Recordings>
```

Xx xxx xxx x XXXX xxxxxx xxxx xxxx xxxxxxx xx XXXX, xxx xxxx xxx xxx **Xxxx** xxxxxxxx.

``` xml
    d:Source="{d:DesignData /SampleData/RecordingsSampleData.json, Type=local:Recordings}"
```

Xx xxx, xx'xx xxxx xxxxx **x:XxxxxxXxxx** xx xxxx xxxxxx-xxxx xxxxxx xxxx xxxx x XXXX xx XXXX xxxx. Xx xxxxxxxxxxx xx xxxx xx xxx **x:XxxxxxXxxxxxxx** xxxxxx xxxxxxxxx, xxxxx xxxxxxxxx xxxx xxx xxxxxx-xxxx xxxxxx xx xxxxx xx xxx xxxxx xxxxxxxxx xx xxx **Xxxx** xxxxxxxx. Xxxx'x xx xxxxxxx.

``` xml
    <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
        d:Source="{d:DesignInstance Type=local:Recordings, IsDesignTimeCreatable=True}"/>
        ```

The **IsDesignTimeCreatable** property indicates that the design tool should actually create an instance of the class, which implies that the class has a public default constructor, and that it populates itself with data (either real or sample). If you don't set **IsDesignTimeCreatable** (or if you set it to **False**) then you won't get sample data displayed on the design surface. All the design tool does in that case is to parse the class for its bindable properties and display these in the the **Data** panel and in the **Create Data Binding** dialog.

Sample data for prototyping
--------------------------------------------------------

For prototyping, you want sample data at both design-time and at run-time. For that use case, Blend for Visual Studio has the **New Sample Data** feature. You can find that command on one of the buttons at the top of the **Data** panel.

Instead of specifying a class, you can actually design the schema of your sample data source right in the **Data** panel. You can also edit sample data values in the **Data** panel: there's no need to open and edit a file (although, you can still do that if you prefer).

The **New Sample Data** feature uses [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713), and not **d:DataContext**, so that the sample data is available when you run your sketch or prototype as well as while you're designing it. And the **Data** panel really speeds up your designing and binding tasks. For example, simply dragging a collection property from the **Data** panel onto the design surface generates a data-bound items control and the necessary templates, all ready to build and run.

![Sample data for prototyping.](images/displaying-data-in-the-designer-04.png)

 

 




<!--HONumber=Mar16_HO1-->
