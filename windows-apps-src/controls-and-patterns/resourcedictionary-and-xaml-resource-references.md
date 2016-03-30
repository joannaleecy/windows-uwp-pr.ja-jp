---
Xxxxxxxxxxx: 'Xxxxxxxx xxx xx xxxxxx x XxxxxxxxXxxxxxxxxx xxxxxxx xxx xxxxx xxxxxxxxx, xxx xxx XXXX xxxxxxxxx xxxxxx xx xxxxx xxxxxxxxx xxxx xxx xxxxxx xx xxxx xx xxxx xxx xx xxx xxxxxxx.'
XX-XXXX: 'xxx\_xxxx\_xxxxxx\_xxx.xxxxxxxxxxxxxxxxxx\_xxx\_xxxx\_xxxxxxxx\_xxxxxxxxxx'
XXXXxxx: 'XxxxxxxxxXxx:/xxxxxxx/xxxxxxx/xxxx'
Xxxxxx.Xxxxxxx: xXXXxXxxxxxx YYXXxxx
xxxxx: XxxxxxxxXxxxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx
xx.xxxxxxx: XYXXXXYX-YXXY-YYXY-XYXY-XYXYXXYXYYXX
xxxxx: XxxxxxxxXxxxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# XxxxxxxxXxxxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxx xxxxxx xxx XX xx xxxxxxxxx xxx xxxx xxx xxxxx XXXX. Xxxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xxxx xxxxxx xxxx xxx xxxxxx xx xxx xxxx xxxx xxxx. Xx xxxxx xx x XXXX xxxxxxxx xxxxx, xxx xxxxxxx x xxx xxx x xxxxxxxx xxxx xxxx xxxx xxx xxxx. Xxx xxx xxxxxxxxx x xxxxxxxx xxxxxxxxxx xx xxx xx xxxx xxx XXXX xxxx xxxxxx xx. Xxx xxx xxxxxx xxxx xxxxxxxxx xxxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxxxx xxxx xxx Xxxxxxx Xxxxxxx XXXX. Xxxx, xxx xxx xxxxxxxxx xxxx xxxxxxxxx xx xxxxx x [XxxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/staticresource-markup-extension.md) xx [XxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/themeresource-markup-extension.md).

Xxx XXXX xxxxxxxx xxx xxxxx xxxx xx xxxxxxx xxxx xxxxx xx XXXX xxxxxxxxx xxxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208849), [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391), xxxxxxxxx xxxxxxxxxx, xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br228076) xxxxxxxxxx. Xxxx, xx xxxxxxx xxx xx xxxxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxx xxxxx xxxxxxxxx, xxx xxx XXXX xxxxxxxxx xxxxxx xx xxxxx xxxxxxxxx xxxx xxx xxxxxx xx xxxx xx xxxx xxx xx xxx xxxxxxx. Xx xxxx xxxxxxx xxxxxxxx xxxxxxxxxx xxxxxxxx xxxxxxxx xxxx xx [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xxx [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208807).

**Xxxxxxxxxxxxx**

Xx xxxxxx xxxx xxx xxxxxxxxxx XXXX xxxxxx xxx xxxx xxxx xxx [XXXX xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185595).

## Xxxxxx xxx xxx XXXX xxxxxxxxx

XXXX xxxxxxxxx xxx xxxxxxx xxxx xxx xxxxxxxxxx xxxx xxxxxx xxxx xxxx xxxx. Xxxxxxxxx xxx xxxxxxx xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxxxxxxxx xx x xxxxxxxx xxxx xx xx xxx xxx xx xxx xxxxxx xxxx, xxxx xxxx.

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
        <x:String x:Key="goodbye">Goodbye world</x:String>
    </Page.Resources>

    <TextBlock Text="{StaticResource greeting}" Foreground="Gray" VerticalAlignment="Center"/>
</Page>
```

Xx xxxx xxxxxxx:

-   `<Page.Resources>…</Page.Resources>` - Xxxxxxx xxx xxxxxxxx xxxxxxxxxx.
-   `<x:String>` - Xxxxxxx xxx xxxxxxxx xxxx xxx xxx "xxxxxxxx".
-   `{StaticResource greeting}` - Xxxxx xx xxx xxxxxxxx xxxx xxx xxx "xxxxxxxx", xxxxx xx xxxxxxxx xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br209676) xxxxxxxx xx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652).

> **Xxxx**&xxxx;&xxxx;Xxx'x xxxxxxx xxx xxxxxxxx xxxxxxx xx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxx xxx **Xxxxxxxx** xxxxx xxxxxx, xxxxxxxx (.xxxx) xxxxx, xx xxxxx "xxxxxxxxx" xxxx xxx xxxxxxxxx xx xxx xxxxxxx xx xxxxxxxxxxx xxx xxxx xxxxxxx xxxx xxxxxxxx xxxx xxx xxxxxxx.

Xxxxxxxxx xxx'x xxxx xx xx xxxxxxx; xxxx xxx xx xxx xxxxxxxxx xxxxxx, xxxx xx xxxxxx, xxxxxxxxx, xxxxxxx, xxx xxxxxx. Xxxxxxx, xxxxxxxx, xxxxxx, xxx xxxxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706)x xxx xxx xxxxxxxxx, xx xxxx xxx'x xx xxxxxxxx xx xxxxxxxx xxxxxxxxx. Xxx xxxx xxxx xxxxx xxxxxxx, xxx xxx [XXXX xxxxxxxxx xxxx xx xxxxxxxxx](#xaml_resources_must_be_sharable) xxxxxxx xxxxx xx xxxx xxxxx.

Xxxx, xxxx x xxxxx xxx x xxxxxx xxx xxxxxxxx xx xxxxxxxxx xxx xxxx xx xxxxxxxx xx x xxxx.

```XAML
<Page
    x:Class="SpiderMSDN.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <SolidColorBrush x:Key="myFavoriteColor" Color="green"/>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource myFavoriteColor}" Text="{StaticResource greeting}" VerticalAlignment="Top"/>
    <Button Foreground="{StaticResource myFavoriteColor}" Content="{StaticResource greeting}" VerticalAlignment="Center"/>
</Page>
```

Xxx xxxxxxxxx xxxx xx xxxx x xxx. Xxxxxxx xxxx xxx xx x xxxxxx xxxxxxx xxxx `x:Key=”myString”`. Xxxxxxx, xxxxx xxx x xxx xxxxx xxxx xx xxxxxxx x xxx:

-   [
            **Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208849) xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xxxxxxx x **XxxxxxXxxx**, xxx xxxx xxx xxx **XxxxxxXxxx** xx xxx xxx xx [x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787) xx xxx xxxxxxxxx. Xx xxxx xxxx, xxx xxx xx xxx xxxxxx Xxxx xxxxxx, xxx x xxxxxx. (Xxx xxxxxxxx xxxxx)
-   [
            **XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242348) xxxxxxxxx xxxx xxxx x **XxxxxxXxxx** xxxx xxx xxx **XxxxxxXxxx** xx xxx xxx xx [x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787) xx xxx xxxxxxxxx. Xx xxxx xxxx, xxx xxx xx xxx xxxxxx Xxxx xxxxxx, xxx x xxxxxx.
-   [x:Xxxx](https://msdn.microsoft.com/library/windows/apps/mt204788) xxx xx xxxx xxxxxxx xx [x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787). Xxxxxxx, x:Xxxx xxxx xxxxxxxxx x xxxx xxxxxx xxxxx xxx xxx xxxxxxxx. Xx x xxxxxx, x:Xxxx xx xxxx xxxxxxxxx xxxx x:Xxx xxxxxxx xxxx xxxxx xxxxx xx xx xxxxxxxxxxx xxxx xxx xxxx xx xxxxxx.

Xxx [XxxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/staticresource-markup-extension.md) xxx xxxxxxxx xxxxxxxxx xxxx xxxx x xxxxxx xxxx ([x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787) xx [x:Xxxx](https://msdn.microsoft.com/library/windows/apps/mt204788)). Xxxxxxx, xxx XXXX xxxxxxxxx xxxx xxxxx xxx xxxxxxxx xxxxx xxxxxxxxx (xxxxx xxxxx xxx **XxxxxxXxxx** xxxxxx xxxx x:Xxx xx x:Xxxx) xxxx xx xxxxxxx xxxxx xxxxx & xxxxxxxx xx xxx xxx x xxxxxxx xxxx xxxx'x xxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208743) xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209369) xx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242830) xxxxxxxxxx.

Xxxx, xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208849) xxx xx xxxxxxxx xxx xx **xxxxxx(Xxxxxx)**, xxx xxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209265) xx xxx xxxxxx xx xxx xxxx xxxxx'x xxxxxxx x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208743) xxxxxxxx, xx xxxxx xxx x xxxxx xxxx xxx xx **xxxxxx(Xxxxxx)**:

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <Style TargetType="Button">
              <Setter Property="Background" Value="red"/>
        </Style>
    </Page.Resources> 
       <!-- This button will have a red background. -->
       <Button Content="Button" Height="100" VerticalAlignment="Center" Width="100"/>
</Page>
```

Xxx xxxx xxxx xxxxx xxxxxxxx xxxxxx xxx xxx xxxx xxxx, xxx [Xxxxxxx xxxxxxxx](styling-controls.md) xxx [Xxxxxxx xxxxxxxxx](control-templates.md).

## Xxxx xx xxxxxxxxx xx xxxx

Xxx xxxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxxxxx xxxx xxx xxxxx xxxxxxxxxx.

> **Xxxxxxx**&xxxx;&xxxx;Xxxx xxx xxxxxxx x xxxxxxxx xxxxxx xx xxxx, xxxx xxx xxxxxxxxx xx xxx `Page.Resources` xxxxxxxxxx xxx xxxxxx xx. Xxxxxx xxx [XxxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/staticresource-markup-extension.md), xxx xxxx xxxxx'x xxxx xxxx xx xxx `Application.Resources` xxxxxxxxxx xx xxx xxxxxxxxx xxxx’x xxxxx xx xxx xxxxx xxxxxxxxxx.

 

Xxxx xxxxxxx xxxxx xxx xx xxxxxxxx xxx `redButtonStyle` xxxxxxxx xxx xx x xxxx’x xxxxxxxx xxxxxxxxxx:

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <Style TargetType="Button" x:Key="redButtonStyle">
            <Setter Property="Background" Value="red"/>
        </Style>
    </Page.Resources>
</Page>
```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Style redButtonStyle = (Style)this.Resources["redButtonStyle"];
        }
    }
```

Xx xxxx xx xxx-xxxx xxxxxxxxx xxxx xxxx, xxx **Xxxxxxxxxxx.Xxxxxxx.Xxxxxxxxx** xx xxx xxx xxx'x xxxxxxxx xxxxxxxxxx, xx xxxxx xxxx.

```XAML
<Application
    x:Class="MSDNSample.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:SpiderMSDN">
    <Application.Resources>
        <Style TargetType="Button" x:Key="appButtonStyle">
            <Setter Property="Background" Value="red"/>
        </Style>
    </Application.Resources>

</Application>
```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Style appButtonStyle = (Style)Application.Current.Resources["appButtonStyle"];
        }
    }
```

Xxx xxx xxxx xxx xx xxxxxxxxxxx xxxxxxxx xx xxxx.

Xxxxx xxx xxx xxxxxx xx xxxx xx xxxx xxxx xxxxx xxxx.

-   Xxxxx, xxx xxxx xx xxx xxx xxxxxxxxx xxxxxx xxx xxxx xxxxx xx xxx xxx xxxxxxxx.
-   Xxxxxx, xxx xxx’x xxx xxxxxxxxx xx xxx Xxx’x xxxxxxxxxxx.

Xxx xxx xxxxx xxxx xxxxxxxx xx xxx xxx xxx xxxxxxxx xx xxx [**Xxxxxxxxxxx.XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxxxx, xxxx xxxx.

```CSharp
// App.xaml.cs
    
sealed partial class App : Application
{
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            SolidColorBrush brush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0)); // green
            this.Resources["brush"] = brush;
            // … Other code that VS generates for you …
        }
    }
}
```

## Xxxxx XxxxxxxxxXxxxxxx xxx xxxx x XxxxxxxxXxxxxxxxxx

[
            **XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706) xx x xxxx xxxxx xxxx xxxxxxxx xxxxxxx xxxx, xxx xx xxx x [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740) xxxxxxxx. Xx, xxx xxx xxx x xxxxx xxxxxxxx xxxxxxxxxx xx xxx **XxxxxxxxxXxxxxxx**.

Xxxx, x xxxxxxxx xxxxxxxxxx xx xxxxx xx x xxxx xxxxxxx.

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <Border>
        <Border.Resources>
            <x:String x:Key="greeting">Hola mundo</x:String>
        </Border.Resources>
        <TextBlock Text="{StaticResource greeting}" Foreground="Gray" VerticalAlignment="Center"/>
    </Border>
</Page>

```

Xxxx, xxxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br227503) xxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209250) xxxx xxxxxxxx xxxxxxxxxxxx, xxx xxxx xxxx xxxx x xxxxxxxx xxxxxx "xxxxxxxx". Xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xx xxxxxx xxx **Xxxxxx**, xx xxx xxxxxxxx xxxxxx xxxxx xxxxx xx xxx **Xxxxxx**’x xxxxxxxxx, xxxx xxx **Xxxx**’x xxxxxxxxx, xxx xxxx xxx [**Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242324) xxxxxxxxx. Xxx **XxxxXxxxx** xxxx xxxx "Xxxx xxxxx".

Xx xxxxxx xxxx xxxxxxx’x xxxxxxxxx xxxx xxxx, xxx xxxx xxxxxxx’x [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740) xxxxxxxx. Xxxxxxxxx x [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706)’x xxxxxxxxx xx xxxx, xxxxxx xxxx XXXX, xxxx xxxx xxxx xx xxxx xxxxxxxxxx, xxx xx xxxxxx xxxxxxx’x xxxxxxxxxxxx.

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Page.Resources>
        <x:String x:Key="greeting">Hello world</x:String>
    </Page.Resources>

    <Border x:Name="border">
        <Border.Resources>
            <x:String x:Key="greeting">Hola mundo</x:String>
        </Border.Resources>
    </Border>
</Page>

```

```CSharp
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            string str = (string)border.Resources["greeting"];
        }
    }
```

## Xxxxxx xxxxxxxx xxxxxxxxxxxx

X *xxxxxx xxxxxxxx xxxxxxxxxx* xxxxxxxx xxx xxxxxxxx xxxxxxxxxx xxxx xxxxxxx, xxxxxxx xx xxxxxxx xxxx.

> **Xxx**&xxxx;&xxxx;Xxx xxx xxxxxx x xxxxxxxx xxxxxxxxxx xxxx xx Xxxxxxxxx Xxxxxx Xxxxxx xx xxxxx xxx **Xxx &xx; Xxx Xxxx… &xx; Xxxxxxxx Xxxxxxxxxx** xxxxxx xxxx xxx **Xxxxxxx** xxxx.

Xxxx, xxx xxxxxx x xxxxxxxx xxxxxxxxxx xx x xxxxxxxx XXXX xxxx xxxxxx XxxxxxxxxxY.xxxx.

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

```

Xx xxx xxxx xxxxxxxxxx, xxx xxxxx xx xxxx xxxx xxxx’x xxxxxxxxxx:

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
            </ResourceDictionary.MergedDictionaries>

            <x:String x:Key="greeting">Hello world</x:String>

        </ResourceDictionary>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource brush}" Text="{StaticResource greeting}" VerticalAlignment="Center"/>
</Page>
```

Xxxx'x xxxx xxxxxxx xx xxxx xxxxxxx. Xx `<Page.Resources>`, xxx xxxxxxx `<ResourceDictionary>`. Xxx XXXX xxxxxxxxx xxxxxxxxxx xxxxxxx x xxxxxxxx xxxxxxxxxx xxx xxx xxxx xxx xxx xxxxxxxxx xx `<Page.Resources>`; xxxxxxx, xx xxxx xxxx, xxx xxx’x xxxx xxxx xxx xxxxxxxx xxxxxxxxxx, xxx xxxx xxx xxxx xxxxxxxx xxxxxx xxxxxxxxxxxx.

Xx xxx xxxxxxx `<ResourceDictionary>`, xxxx xxx xxxxxx xx xxx `<ResourceDictionary.MergedDictionaries>` xxxxxxxxxx. Xxxx xx xxxxx xxxxxxx xxxxx xxx xxxx `<ResourceDictionary Source="Dictionary1.xaml"/>`. Xx xxx xxxx xxxx xxx xxxxxxxxxx, xxxx xxx x `<ResourceDictionary Source="Dictionary2.xaml"/>` xxxxx xxxxx xxx xxxxx xxxxx.

Xxxxx `<ResourceDictionary.MergedDictionaries>…</ResourceDictionary.MergedDictionaries>`, xxx xxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx xx xxxx xxxx xxxxxxxxxx. Xxx xxx xxxxxxxxx xxxx x xxxxxx xx xxxxxxxxxx xxxx xxxx x xxxxxxx xxxxxxxxxx. Xx xxx xxxxxxx xxxxx, `{StaticResource brush}` xxxxx xxx xxxxxxxx xx xxx xxxxx/xxxxxx xxxxxxxxxx (XxxxxxxxxxY.xxxx), xxxxx `{StaticResource greeting}` xxxxx xxx xxxxxxxx xx xxx xxxx xxxx xxxxxxxxxx.

Xx xxx xxxxxxxx-xxxxxx xxxxxxxx, x [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xxxxxxxxxx xx xxxxxxx xxxx xxxxx x xxxxx xx xxx xxx xxxxx xxxxx xxxxxxxxx xx xxxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794). Xxxxx xxxxxxxxx xxxx xxxxx, xxx xxxxxx xxxxxxx xxx xxxxxx xxxxxxxxxxxx, xxx xxxx xxxx xx **XxxxxxXxxxxxxxxxxx** xx xxxxxxx. Xx xxxxxxxx xxxxxx xxxxxxxxxxxx xxxxx, xxxxx xxxxxxxxxxxx xxx xxxxxxx xx xxx xxxxxxx xx xxx xxxxx xx xxxxx xxxx xxx xxxxxxxx xx xxx **XxxxxxXxxxxxxxxxxx** xxxxxxxx. Xx xxx xxxxxxxxx xxxxxxx, xx xxxx XxxxxxxxxxY.xxxx xxx XxxxxxxxxxY.xxxx xxxxxxxx xxx xxxx xxx, xxx xxx xxxx XxxxxxxxxxY.xxxx xx xxxx xxxxx xxxxxxx xx'x xxxx xx xxx **XxxxxxXxxxxxxxxxxx** xxx.

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
                <ResourceDictionary Source="Dictionary2.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>

    <TextBlock Foreground="{StaticResource brush}" Text="greetings!" VerticalAlignment="Center"/>
</Page>
```

Xxxxxx xxx xxxxx xx xxx xxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx xxxxxxxxxx xx xxxxxxx xxx xxx xxxxxxxxxx. Xxxxxxx, xxxx xxxxx xxxx xxx xxxxxx xxxxxx xxxxxxxxx xxxxx xx xxxxxxxxx [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xxxxx.

Xxx xxx xxx xxx xxxxxxxxxxx xx xxx xxxxxx xxxxxxxx xxx xxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxx xxxxxx-xxxxxxxxxx xxxxxx xx xxxxxx x xxxxxxxx xxxxx xxxxxxxx xx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxxxxxx. Xxx xxxxxxx, xxx xxxxx xxxxx xxxx xxxxxxxxxxx xxx x xxxxxxxxxx xxxxx xxxxx xx xxx xxxx xxxxxx xxxxxxxx xxxxxxxxxx xx xxx xxxxxxxx, xxxxx x xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xx xxxx xxx'x xxxxx xxx xxxx xxxxxxxxxx xxxx. Xxxxxxx, xx xx xxxx xxxxxxxxxxx xxxxx xxx, xxx xxx xxxxxx xxxx xxxx xxx xxxxxx xxx x **XxxxxxxxXxxxxxxxxx** xxxxxxxx xx xxx xxxxxxx [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xxxx, xxx xx xxx xxxxx xx xxx xxxxxxxx xxxxx. Xxxxxxxx xxxx xxx xxxxx xxx xxxxxxx xx x xxxxxxx xxxxxxxx xxxxxxxxxx xx xxxxxx xxxxxxx xxxxxx xxx xxxxxx xxxxxxxxxxxx xxx xxxxxxx, xx xx xxx xxxx xx xxx xxx xxxxxxxx xxxxxxxxx, xxx'x xxxxxx xxxx xxxxxxxx xx x xxxxxxx xxxxxxxx xxxxxxxxxx.

## Xxxxx xxxxxxxxx xxx xxxxx xxxxxxxxxxxx

X [XxxxxXxxxxxxx](../xaml-platform/themeresource-markup-extension.md) xx xxxxxxx xx x [XxxxxxXxxxxxxx](../xaml-platform/staticresource-markup-extension.md), xxx xxx xxxxxxxx xxxxxx xx xxxxxxxxxxx xxxx xxx xxxxx xxxxxxx.

Xx xxxx xxxxxxx, xxx xxx xxx xxxxxxxxxx xx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xx x xxxxx xxxx xxx xxxxxxx xxxxx.

```XAML
<TextBlock Text="hello world" Foreground="{ThemeResource FocusVisualWhiteStrokeThemeBrush}" VerticalAlignment="Center"/>
```

X xxxxx xxxxxxxxxx xx x xxxxxxx xxxx xx xxxxxx xxxxxxxxxx xxxx xxxxx xxx xxxxxxxxx xxxx xxxx xxxx xxx xxxxx x xxxx xx xxxxxxxxx xxxxx xx xxx xx xxx xxxxxx. Xxx xxxxxxx, xxx "xxxxx" xxxxx xxxxx xxx x xxxxx xxxxx xxxxx xxxxxxx xxx "xxxx" xxxxx xxxxx xxx x xxxx xxxxx xxxxx. Xxx xxxxx xxxxxxx xxx xxxxxxxx xxxx xx xxxxxxxx xx, xxx xxxxxxxxx xxx xxxxxxxxxxx xx x xxxxxxx xxxx xxxx xxx xxxxx xx x xxxxxxxx xxxxx xx xxx xxxx. Xx xxxxxxxxx xxx xxxxx-xxxxxxxxx xxxxxxxx xx xxxx xxx xxxxxxxxx xxx xxxxxx, xxxxxxx xx xxxxx [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xx xxx xxxxxxxx xx xxxxx xxxxx xxxx xxx xxxx xxxxxxxxxxxx, xxx xxx [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208807) xxxxxxxx.

Xxxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxxxx xxxxxx [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208807) xxxx xxxx xx [x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787) xxxxx. Xxx xxxxx xx x xxxxxx xxxx xxxxx xxx xxxxxxxx xxxxx—xxx xxxxxxx, "Xxxxxxx", "Xxxx", "Xxxxx", xx "XxxxXxxxxxxx". Xxxxxxxxx, `Dictionary1` xxx `Dictionary2` xxxx xxxxxx xxxxxxxxx xxxx xxxx xxx xxxx xxxxx xxx xxxxxxxxx xxxxxx.

Xxxx, xxx xxx xxx xxxx xxx xxx xxxxx xxxxx xxx xxxx xxxx xxx xxx xxxx xxxxx.

```XAML
<!-- Dictionary1.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="Red"/>

</ResourceDictionary>

<!—Dictionary2.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MSDNSample">

    <SolidColorBrush x:Key="brush" Color="blue"/>

</ResourceDictionary>
```

Xx xxxx xxxxxxx, xxx xxx xxx xxxxxxxxxx xx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xx x xxxxx xxxx xxx xxxxxxx xxxxx.

```XAML
<Page
    x:Class="MSDNSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.ThemeDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml" x:Key="Light"/>
                <ResourceDictionary Source="Dictionary2.xaml" x:Key="Dark"/>
            </ResourceDictionary.ThemeDictionaries>
        </ResourceDictionary>
    </Page.Resources>
    <TextBlock Foreground="{StaticResource brush}" Text="hello world" VerticalAlignment="Center"/>
</Page>
```

Xxx xxxxx xxxxxxxxxxxx, xxx xxxxxx xxxxxxxxxx xx xx xxxx xxx xxxxxxxx xxxxxx xxxxxxx xxxxxxxxxxx, xxxxxxxx [XxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/themeresource-markup-extension.md) xx xxxx xx xxxx xxx xxxxxxxxx xxx xxx xxxxxx xxxxxxx x xxxxx xxxxxx. Xxx xxxxxx xxxxxxxx xxxx xx xxxx xx xxx xxxxxx xx xxxxx xx xxxxxxx xxx xxxxxx xxxxx xx xxx [x:Xxx](https://msdn.microsoft.com/library/windows/apps/mt204787) xx x xxxxxxxx xxxxx xxxxxxxxxx.

Xx xxx xx xxxxxx xx xxxxxxx xxx xxx xxxx xxx xxxxx xxxxxxxxxxxx xxx xxxxxxxxxx xx xxx xxxxxxx XXXX xxxxxx xxxxxxxxx, xxxxx xxxxxxxx xxx xxxxxxxxx xxxx xxx Xxxxxxx Xxxxxxx xxxx xx xxxxxxx xxx xxx xxxxxxxx. Xxxx xxx XXXX xxxxx xx \\(Xxxxxxx Xxxxx)\\Xxxxxxx Xxxx\\YY\\XxxxxxXxxx\\XxxxxxXxxxxxxxxxxxx\\Xxxxxxx\\XXX\\&xx;XXX xxxxxxx&xx;\\Xxxxxxx xxxxx x xxxx xxxxxx xx xxxx XXX. Xxxx xxx xxx xxxxx xxxxxxxxxxxx xxx xxxxxxx xxxxx xx xxxxxxx.xxxx, xxx xxx xxxx xxxxx xxxxxxxxxx xxxxxxx xxx xxxx xxxx. Xxxx xxxx xxx xx xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxxxxxxx xx xxx xxxxxxx xxxxx xxxxxxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxxxxx xxx xxxxxxx xxxxx xx xxx XXXX. Xxxxx'x xxxx x xxxxxxxx xxxxxxxxxxxxxx.xxxx xxxx xxx xxxxxx xxxx xxxxxxxx xxxx xxx xxxxx xxxxxxxxx xxx xxxxx xxxxxxxxx, xxx xxx xxxxxxx xxxxxxx xxxxxxxxx. Xxx xxxxx xxxxx xxx xxxxxxxxxx xx xxxx xxx'x xxx xx xxxxxxx.xxxx.

Xxxx xxx xxx XXXX xxxxxx xxxxx xx xxxx xxxxxx xx xxxxxx xxx xxxxxxxxx, xxx xxxxxx xxxxx xxxxxxx xxxxxxxx xxxx xxx XXXX xxxxxx xxxxxxxx xxxxxxxxxxxx xxx xxxxx xxxx xx xxxxx xxxxxx xx XXXX xxxxxxxxxx xxxxxxxx xxxx xxx xxxx xx xxxx xxx xxx xxxxxxx.

Xxx xxxx xxxx xxx xxx x xxxx xx xxx xxxxx-xxxxxxxx xxx xxxxxx xxxxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx, xxx [XXXX xxxxx xxxxxxxxx](xaml-theme-resources.md).

## Xxxxxx xxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx

*Xxxxxx xxxxxxxx* xx xxx xxxx xxxx xxxxxxxxx xxx xxx XXXX xxxxxxxxx xxxxxx xxxxx xx xxxx x XXXX xxxxxxxx. Xxx xxxxxx xxxxxx xxxx x xxx xx xxxxxxxxxx xx x XXXX xxxxxxxx xxxxxxxxx xxxx xxxxxxxxx xx xxx xxx'x XXXX. Xxxxx, xxx xxxxxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxxxx xxx xxxxx xx xxxx xxxxx xxx xxx xxxxxxxxx xx x xxxxxxxx xxxxx xx xxxxx. Xx x xxxxxxxx xxx'x xxxxx xx xxx xxxxxxx xxxxx, xxx xxxxx xxxxxxx. Xxx xxxxxx xxxxxxxx xxxxxxxxx xx xxxxxxxxxx xxx xxxxxxxxx xxx xxxxxx xxxx x XXXX xxxxxxxx xxxxx xxxxxxxx xx xxxxxxx xx xx xxx xx xx xxx xxxxxx. Xx xxx xxxxxxxx xxxxxxxx xxxxxx xxxxxxxx xxxx, xx xxxxx xxxxx xxxxxxx. Xx'x xxxxxxx xxxxxxxx xx xxxxxxxxx xxxxx xxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxxx.

Xxx xxxxxx xxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx xxxxxx xxxx xxx xxxxxx xxxxx xxx xxxxxx xxxxx xx xxxxxxx xxx xxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740) xxxxxxxx. Xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxxx xxxxx, xxxx **XxxxxxxxXxxxxxxxxx** xx xxxxxxx xxx xx xxxx xxxx xxx xxx xxxxxxxxx xxx. Xxxx xxxxx xxxxx xx xxxxxx xx xxxxxx xxxxxxxx xxxxxxx xxx xxxxxxx xx xxx xxxxxx xxx xxxx xxxxxxxxx x xxxxxxxx xx xxx xxxx xxxxxx. Xx xxxx, x **Xxxxxxxxx** xxxxxxxx xxxxx xxxxx'x xxxxx xxxx. Xxx xxx xxxx XXXX xxxxxxxx xxxxxxxxxx xxxx xxxxxx xxxxxxxx xx XXXX; xxx xxxx'x xxxxxxx xx xxxxxxxxxx xx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706) xxxxxxxxxx.

Xxx xxxxxx xxxxxxxx xxxx xxxxxx xxx xxxx xxxxxx xxxxxx xx xxx xxxxxxx xxxxxx xxxx xx xxx xxx. Xx x [**XxxxxxxxxXxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740) xxxxxx xxx xxxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx xxxxxxxxxx xxxx xxxx xxx xxxxxxxxx xxx xxxxxx xx xxxxxxxxx. Xx xxx xxxxxxxx xx xxxxx, xxx xxxxxx xxxxxxxx xxxxx xxx xxx xxxxxx xx xxxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxxxx xxx xxxx. Xxxxxxxxx, xxx xxxxxx xxxxxxxx xxxxxxxx xx xxx xxxx xxxxxx xxxxx xxxxxxx xxx xxxxxx xxxx xxxx. Xxx xxxxxx xxxxxxxxx xxxxxxxxxxx xxxxxxx xxxxx xxx xxxx xxxxxxx xx xxx XXXX xx xxxxxxx, xxxxxxxxxx xxx xxxxxx xx xxx xxxxxxxx xxxxxxxxx xxxxxxxx xxxxxxxxx.

> **Xxxx**&xxxx;&xxxx;Xx xx x xxxxxx xxxxxxxx xx xxxxxx xxx xxx xxxxxxxxx xxxxxxxxx xx xxx xxxx xxxxx xx x xxxx, xxxx xx xxxx xxxxxxxxx xx xxxx xxxxxxxx-xxxxxx xxxxxxxx xxx xxxx xx x xxxxxxxxxx xx XXXX xxxxxx xxxxx.

 

Xx xxx xxxxxxxxx xxxxxxxx xx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxxx, xxx xxxx xxxxxx xxxx xx xx xxxxx xxx [**Xxxxxxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242338) xxxxxxxx. **Xxxxxxxxxxx.Xxxxxxxxx** xx xxx xxxx xxxxx xx xxx xxx xxx-xxxxxxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxx xx xxxx xxx'x xxxxxxxxxx xxxxxxxxx.

Xxxxxxx xxxxxxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxx xx xxx xxxxxxxxx xxxxxx: xxxxx xxxxxxxxxxxx. X xxxxx xxxxxxxxxx xx x xxxxxx XXXX xxxx xxxx xxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxxxx xx xxx xxxx. Xxx xxxxx xxxxxxxxxx xxxxx xx x xxxxxx xxxxxxxxxx xxxx [**Xxxxxxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242338). Xxx xxxxx xxxxxxxxxx xxxxx xxxx xx xxx xxxxxxx-xxxxxxxx xxxxx xxxxxxxxxx xxx x xxxxxxxxx xxxxxx xxxxxxx.

Xxxxxxx, xxxxx xx x xxxxxxxx xxxxxx xxxxxxx xxxxxxxx xxxxxxxxx. Xxxxxxxx xxxxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxx xxxx xxx xxxxxxx xxx xxxx xx xxx xxxxxx XX xxxxxx, xxx xxxxx xxxxxx xxx xxxxxxx xxxxxxxxxx xx xxx xxx xxxxxxxx xxxx xxx xxx xxx XX xx x Xxxxxxx Xxxxxxx xxx. Xxxxxxxx xxxxxxxxx xxxx xxxxxxx x xxx xx xxxxx xxxxxxxxx xxxx xxxxxx xx xxxxxx-xxxx xxxxxxxxxx xxx xxxxxx. Xxxxx xxxxxxxxx xxx xxxxxxxxxxx x [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801) xxxx, xxx xxxx xxx xxxxxxxxx xxx xxxxxx xxxx XXXX xx xxxx xxxx xxx xxx xxx xxxxxx. Xxx xxxxxxx, xxx xxxxxx xxxxx xxxxxxxxx xxxxxxx x xxxxxxxx xxxxx "XxxxxxXxxxxXxxxxxXxxxXxxxx" xxxx xxxxxxxx x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/hh673723) xxxxxxxxxx xx xxxxx xxx xxxx xxxxx xx x xxxxxx xxxxxx'x xxxx xxxxx xxxx xxxxx xxxx xxx xxxxxxxxx xxxxxx xxx xxxx xxxxxxxxxxx. Xxxxx XXXX xxxxxx xxx xxxx xxx xxx xxxxx xx xxxx xxxxx, xx xxxx xxxx xxx xxx x xxxxxxxx xxxxxx xxxxx (xxx xxxx xx xx **Xxxxx** xx xxx xxxxxxx xxxx).

Xxx xxxx xxxx xxx xxx x xxxx xx xxx xxxxx-xxxxxxxx xxx xxxxxx xxxxxxxxx xxxx xxx xxxxxxxxx xx x Xxxxxxx Xxxxx xxx xxxx xxxx XXXX, xxx [XXXX xxxxx xxxxxxxxx](xaml-theme-resources.md).

Xx xxx xxxxxxxxx xxx xx xxxxx xxx xxxxx xx xxx xx xxxxx xxxxxxxxx, x XXXX xxxxxxx xxxxx/xxxxxxxxx xxxxxx. Xx xxxxxxx xxxxxxxxxxxxx, xxx XXXX xxxxx xxxxxxxxx xxx xx x xxx-xxxx xxxxxxxxx xxxx xx xxx xxxxxxxx xxxxxx xx x XXXX xxxxxx xxxxxxx xxxxxx, xx xx x XXXX xxxxxx xxxxxxxxxxx.

Xxxxxxx xx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxxxxxx xxxxxxxxxxxx, xxx xxx xxxxxxxxxxxx xxxxxx xxxxxxxx xxxxxxxx xxxxx xxxx xxxx xxxx xxx xxxx xxxxxx xxxxx xx xxx xxx, xx xxxx xx xxxx xxxxxxxx xx xxxxxxx xx x xxxxxxxxx xxxxx. Xx xxxxx xxxxx, xxxxxxxx xxxx xxxx xx xxxxxx xxxxxx xxx xxxxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxx xx xxx xxxxxx xxxxxxxx xxxxxxxx xx x xxxxx. Xxxxxx xxxxxx, xxxx xxx xxxxx xxxx xxxxxx xxxx'x xxxxxxxxxxxx xxxxxxxxx xx xxxx xxx xxx XXXX xxxxxxxx xxxxxxxxx, xxx xxxx xxx xxxxxx xxxxx. Xxx xxxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xxxx XXXX xxxxxxxx xx xxx xx xxxxxxx xxxxxxxxx xxxxxx xxxx xxx'x XXXX xxx xxx xxxxxxxxx xxxxxxxxx xxxx, xxxxxxxxx xx xxx xxxxx xxxx xxxxx xxx XXXX xxxxxxxx xxxxxxxxx xxx xxxx xxx xxx xxxx xxxxxxxxxx xxxxxx xxxxxxx.

##  Xxxxxxx xxxxxxxxxx xxxxxx x XxxxxxxxXxxxxxxxxx


XXXX xxxxxxxx xxxxxxxxxx xxxxxx x xxxxxxxxxx xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxx x xxxxxxxx xxxx xxx xxxxxxx xxxx xxxxxxx xxxx x xxx, xxx xxxx xxxxxxxx xxxx xxxxxx xxxxxxxxx xxxxxx xxx xxxxxxxx xxxxxxxxx. Xxxxxxx xxxxxxxxxx xxxxxx xx xxxxxxxx xx x XXXX xxxxxxxx xxxxxxxxx. Xxx xxxx xxxxxx, xx xxx xxx XXXX xxxxxxxx xxxxxxxxxx xxxx xxxxxx xxxxxxx xxxxxxxx, xxx xxxx xxxxxx xxxx xxxxxxxx xxxxxxxxxx xxxxxxxxx xx xxxx xxx xxxxxxxxx xxxx xxx xxxx xx xxxxx xxxxxxxxx xxx xxxxxxx xxxxx xx x xxxxxxxx xxxxxxxxxx.

Xxxxxxxxx xxxxxxx xx xxx xxx xxxxx xxxxxx xxxx xxxxxxxxxx xx xxxxxxxxx xxxxxxxxx. Xxxx xx xxxxxxxxxx xx xxxxxxxxxx x xxxxxxx xxxxxxxxx, xxxxxxx xxx xxx xxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxxxx (xxxx xxx xxx xxxxx xxxxxx, xxx xxxxxx xxx xxxxxxxxxx-xxxx xxxxxxx xx xxxxxx). Xxxxxxx, xxx xxxxxxxxx xxxxxxxx xxx xxxx x xxxxxxxxx xx xx xxx xxxxxxxx, xxx xxxx xxx xx x xxxxxx xxxxxxxxx xxx xxxxxxxx xxxxxxx-xxxxxxxxx xxxxxxxxxx.

## XXXX xxxxxxxxx xxxx xx xxxxxxxxx


Xxx xx xxxxxx xx xxxxx xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxxx xxxxxx xxxx xx *xxxxxxxxx*.

Xxxxx xxxxxxxxx xx xxxxxxxx xxxxxxx, xxxx xxx xxxxxx xxxx xx xx xxx xx xxxxxxxxxxx xxx xxxx xx xxx xxxx, xxxxxxx xxxxxx xxxxx xx xxxxxxxx xxxxxxxxx xx xxx xxxx. Xxxxxxxxxx, xxx xxxxxxxx xxxxxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxx xx xxx xx xxx xxxxxx xxxxx xx xxxx xxx xxxx xxxx XXXX xxxxxxxx xx xxxxxxxxx.

X [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxx Xxxxxxx Xxxxxxx XXXX xx xxxxxxx xxxxxxxx xxxxx xxxxxxx xxx xxxxxxxxx xxxxx:

-   Xxxxxx xxx xxxxxxxxx ([**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208849) xxx xxxxxxx xxxxxxx xxxx [**XxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208753))
-   Xxxxxxx xxx xxxxxx (xxxxxxx xxxxxxx xxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br228076), xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/hh673723) xxxxxx)
-   Xxxxxxxxx xxxxx xxxxxxxxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210490)
-   Xxxxxxxxxx (xxxxxxx xxxxxxx xxxx [**XxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210034))
-   [
            **Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210127) xxx [**XxxxxxYX**](https://msdn.microsoft.com/library/windows/apps/br243266)
-   [
            **Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225870) xxxxxx
-   Xxxxxxx xxxxx XX-xxxxxxx xxxxxxxxxx xxxx xx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208864) xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242343)
-   [XXXX xxxxxxxxx xxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt186448)

Xxx xxx xxxx xxx xxxxxx xxxxx xx x xxxxxxxxx xxxxxxxx xx xxx xxxxxx xxx xxxxxxxxx xxxxxxxxxxxxxx xxxxxxxx. Xxx xxxxxx xxxx xxxxxxx xx xxxx xxxxxxx xxxx (xx xx xxxxxxx xxxxxxxxxx xxxx xxx xxxxxxx) xxx xxxx xxxxxxxxxxx xxxxx xxxxxxx xx XXXX xx x xxxxxxxx. Xxxxxxxx xxx xxxxxx xxxx xxxxxxx xxx [**XXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209903) xxxxxxxxxxxxxxx xxx xxxx xxxxxxx.

Xxxxxx xxxxx xxxx xxxx x xxxxxxx xxxxxxxxxxx, xxxxxxx xxxx'x xxxx x XXXX xxxxxx xxxx xx xxxxxxxxxxx x xxxxx. Xxxxxx xxxxx xxxx xx xxxxxxxxx xxx'x xxxx xxx [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208911) xxxxx xx xxxxx xxxxxxxxxxx, xxxxxxx x **XXXxxxxxx** xxx xxxxx xx xxxxxxxxx (xx'x xxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxx xxx XX xxxxxxx xxxx xxxxxx xx xxx xxxxxxxx xx xxx xxxxxx xxxxx xx xxxx xxxxxxx xxx).

## XxxxXxxxxxx xxxxx xxxxx


X [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227647) xxxxxxx xxx x xxxxxxx xxxxxxxxx xxx xxxxxxxx-xxxxxx xxxxxxxx xxxxxxx xx xxx xxx xxxxxxxx xxxxxxxx xx x xxxxxxxxxx xxxxx xxx x xxxxx xxxxx. X **XxxxXxxxxxx** xxxx xxxxx x XXXX xxxxxxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xxxxx xxxx xx xxxx xx xxxxxxx xxx xxxxxx xx xxxx xxxxxxxx xxxxxx xxx xxx xxxxxxxxxx-xxxxx xxxxxx xxxxxxxx—xxxx xx, xx xxxxxx xxxxxx xxx xxxxxxxxx. Xxxx x **XxxxXxxxxxx** xxxxx xxxxx, x xxxxxxxx xxxxxxxxx xx xxxxxxx xx xxxxx xxxxxx xxx xxxxxx xxxxxxxx xxxxxxx xxx xxxxx xxxx xxxx (xxxx xxxx xxx xxxxx xxxxxxxx xxxxxxxxx xxxx xxxx xx xxxxxx xx x xxxxxx xxxxxx xxxx) xxx xxx xxxxxx xxx xxxxxxxxx.

## XxxxxxxxXxxxxxxxxx xxx XxxxXxxxxx.Xxxx

Xxx xxx xxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xx xxxxxx xxx xxxx xx x xxxx xx xxx XXXX xxxxx xxx xxx [**XxxxXxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br228048) xxxxxx. Xxx xxx xxxx xxxxxxx XXXX xxxxxxxx xxxxxxxxxx xx xxxx XXXX xx xxx xxxx xxxxxxxxxx xxx xxxxxxxxxx xxxx-xxxxxxxxx xx xxx XXXX xxxxxxxxx xxx xxxxxxx. **XxxxXxxxxx.Xxxx** xxxxxx xxx XXXX xx x xxxxxxx xxxx xx xxx xxxxx xx xxx xxxxx **XxxxxxxxXxxxxxxxxx** xxxxxxx, xxx xxxx [**Xxxxxxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242338). Xxxx, xxx'x xxx `{ThemeResource}` xxxx xxxxxx XXXX xxxxxxxxx xx **XxxxXxxxxx.Xxxx**.

## Xxxxx x XxxxxxxxXxxxxxxxxx xxxx xxxx

Xxxx xx xxx xxxxxxxxx xxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxx xxxxxxx xxxxxxxxxxx xx XXXX. Xxx xxxxxxx xxx **XxxxxxxxXxxxxxxxxx** xxxxxxxxx xxx xxx xxxxxxxxx xxxxxx xx x XXXX xxxx xx xxx xx XXXX xxxxx xx x XX xxxxxxxxxx xxxx. Xxx xxxx xxx xxx XXXX xxxxxxxx xxxxxxxxxx xx xxxxxxx xxxxx xxxxxxxxx xxxx xxxxx xxxxx xx XXXX. Xxxxx, xxxxx xxx xxxxxxx xxxxxxxxx xxxxx xxxx xxx xxxxx xxxx xx xxxxxx xxx xxxxxxxx xx x **XxxxxxxxXxxxxxxxxx** xxxxx xxxx xxxx xxxxxxxx xxxxx xxx xxx xx xxxxxxx, xx xx xxxxx xx xxxxx xxx xxxxxxxx xx x **XxxxxxxxXxxxxxxxxx** xx xxx xx x xxxxxxxx xx xxxxxxx xxxxxxx. Xxxxx xxxx xxxxx xxx xxxx xx x **XxxxxxxxXxxxxxxxxx** xxxxxxxx, xx xxx xxxx xxxxx xxxxxxxx xxx—xxxxxx xx xxxxxxxxx **XxxxxxxxXxxxxxxxxx** xxxxxxxxx xx xxx xxxxxx xxxx xx xxxxxxx [**XxxxxxxxxXxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740), xx `Application.Current.Resources`.

Xx X\# xx Xxxxxxxxx Xxxxxx Xxxxx xxxx, xxx xxx xxxxxxxxx x xxxxxxxx xx x xxxxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xx xxxxx xxx xxxxxxx ([**Xxxx**](https://msdn.microsoft.com/library/windows/apps/jj603134)). X **XxxxxxxxXxxxxxxxxx** xx x xxxxxx-xxxxx xxxxxxxxxx, xx xxx xxxxxxx xxxx xxx xxxxxx xxx xxxxxxx xx xx xxxxxxx xxxxx. Xx Xxxxxx X++ xxxxxxxxx xxxxxxxxxx (X++/XX) xxxx, xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208800).

Xxxx xxxxx xxxx xx xxxxxxx xx xxxxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx xxxxxxxx xxx XXXx xxxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208800) xx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/jj603134) xxxx xxx xxxxxxxx xxxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxxxxx; xxxx'x x XXXX xxxxxx xxxxxxxx xxxx xxxx xxxxxxx xx XXXX xxxxx xxx xxxxxx. Xx xxx xxxx, xxxxx xxx xxxx xx xxxx-xxxxxxxxx xx xxx **XxxxxxxxXxxxxxxxxx** xxxxxxxx xxxx xxx xxx xxxxx xx xxx xxxx. Xxxxxxx, xxxx xxxxx xxxx xxxxxx xxxx [**XxxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208801).

Xxxx, xx xxx xxxxxxx x xxx xxxx xxxx xxx xxxxx xx xxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxxxx xxx xxx xx xx xxxxx; xxx xxxxxx xxxxx xxx xxxxxx xx xxxxxxxx xx **xxxx**. Xxx xxx xxxxx xxx xx xxxxx, xxxxxx, xx xxx xxx xx xxx xxx xxxxxxxx **xxxx** xx x xxxxx. Xxx xxxxx xxxxx xxxx xxxx xxx xxxxxxxx'x xxxxxx, xxx xxxx **XxxxxxxxXxxxxxxxxx** xxxx. Xxx xxxx xxx xxx'x xxxxx xx xxxxx xx xx xxx xxxxxxxx xxxxxxxx **xxxx** xx x xxxxx xxxxx. Xxxx xxx xxxx xxxxxxxx xxxxxxxxx xxxx XXXX xxxxxx xxxxxxxx xx XXXX xxxxx xxxx; x xxxxxxx xx xxxxxxx xxx xxxxxxxx xxx xxxx XXXX xx xxxxx xxxx xxxxxxx xx x XXXX xxxxx xxxxx, xxxx xx xxxxx xxxxx xxx xxxxxxxx xxxxx xxxx xxxxxxxx **xxxx**.

Xxxxxx xxxxxxxx xxxxxxxxxxxx xxx xxxxxxxx xxxx xxx xxxxx xxxxx xx xxx xxxxxxx xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxx xxx xxxxxx xxxxxxxxxx xx xxx xxxx. Xx xxxxx xxxxx, xxx xxx xxx **Xxxx** xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208800) xx xxx xxxxxxx xxxxxxxxxx xx xxxx xxx xxxxxxx xxxx xxxx xxxxxxxx xxxxxxx xx xxx xxxxxx xxxxxxxxxx. Xx xxxx xxxx, xxx xxxxxx xxxxxxxx xxxx xxxxxxxx xxx xxxxx-xxxx XXXX xxxxxx xxxxxxxx: xx xxxxx xxx xxxxxxxx xxxxxxx xx xxxxxx xxxxxxxxxxxx xxxx xxxx xxxx xxx xxxx xxx, xxx xxxxxx xxxx xxx xxxx-xxxxx xxxxxxxxxx xx xxxxxxxx.

Xxx xxx xxxxxxxxx xx xxx xxxxx xx xx xxxxxxxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xx xxxxxxx **Xxx** (X\# xx Xxxxxx Xxxxx) xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208799) (X++/XX). Xxx xxxxx xxx xxx xxxxx xx xxxxxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxxxxx. Xxxxxx xx xxxxx XXX xxxxx xxxxxxxx x xxx, xxxxx xxxxxxxxx xxx xxxxxxxxxxx xxxx xxxx xxxx xx x **XxxxxxxxXxxxxxxxxx** xxxx xxxx x xxx. Xxxxxxx, xxxxx xxxx xxx xxx xx x **XxxxxxxxXxxxxxxxxx** xx xxx xxxx xxx xxx xxxxxxxx xx XXXX xxxxxxxx xxxxxxxxxx. Xxx xxxxxxxxx xxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx xxxxxxx xxxx xxxx XXXX xx xxxxx xxxxxx xx xxx xxx xx xxxxxx (xx x xxxxx xxxxxx xx xxxxxxxx). Xxxxxxxxx xxxxx xx xxxxxxxxxxx xx xxx xxxx xxxxx'x xxxxxxxxx xxxx, xxx xxxxxxxx xxx **XxxxxxxxXxxxxxxxxx** xxxxx'x xxxxxxxxxx xx xxxxxxx xxxxxxxxx xxxxxxxx xxxx xx xxxx xx xxx xxxxxx xxx xxxxx xx xxxx xxxxxxxx.

Xxx xxxx xxx xxxxxx xxxxx xxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xx xxx xxxx, xxxx xxxxxx xx xxxx xx xxx xxxxx, xx xxxxx xxxxxxxxxx. Xxx xxxxxxx xxxxxxx xxx **XxxxxxxxXxxxxxxxxx** xxxxxxxxx xxxxx XXXx xxx xxxxxxxxx. Xxxx xxxx xxxxxxx **XxxxxxxxXxxxxxxxxx** xxx x xxxxxxxxx XXX xx xxxxxxx xxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxx, xxxx XXX xxxxxxx xxxxxx xxxxxxxxx xx xxxxxxx xxx xxx xxxxx X\# xx Xxxxxx Xxxxx xxxxxx X++/XX.

## XxxxxxxxXxxxxxxxxx xxx xxxxxxxxxxxx


X XXXX [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794) xxxxx xxxxxxxxx xxxxxxx xxxxxxx xxxx xxx xx xx xxxxxxxxx. Xx xx, xxxxx xxxxx xxxxxxx xx xxxxxxx xxxxxxxxx xxxxxxx xx xx x **XxxxxxxxXxxxxxxxxx**. Xxxx xxx xxxxxxx xxx xx xxx XXXX, xxx xxxxxxx xxxx xxx xxxxxx xxxxxxx xx [x:Xxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt204791) xxxxx. Xxxx, xxxxxx x xxxxxxxx xx x xxxxxxxxx xxxx. Xxxxxxx x xxxxxxxx xxxx xx xxx xxxx *XXXXXxxxx*.*XxxxxxxxXxxx* xxx x xxxxxxxx xxxxx xx xxx xxxxxx xxxx xxxxxx xx xxxxxxxxx.

## Xxxxxx xxxxxxxx xxxxxx

Xxx xxxxxxxx xxxxxxxxx, xxx xxx xxxxxxxxx x xxxxx xxxx xxx xxxx xxxxxxxxx xxxxxxxx xxxx xxx XXXX xxxxxxxx xxxxxxxxx xxxxxx xxxxxxxx xxxxxxxxx xx xxxx xxxxx. Xx xx xxxx, xxx xxxxxxxxx xxx xxxxx [**XxxxxxXxxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243327), xxx xxxx xxx xxx xxxxxx xxxx xxxxxxxx xx xxxxx xxx [XxxxxxXxxxxxxx xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185580) xxx xxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxxx [XxxxxxXxxxxxxx](../xaml-platform/staticresource-markup-extension.md) xx [XxxxxXxxxxxxx](../xaml-platform/themeresource-markup-extension.md). Xxxx xxxx xxx'x xxxx xxxxxxxxx xxxx xxxxxxx xxxx. Xxx xxxx xxxx, xxx [**XxxxxxXxxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243327).

**Xxxx**  
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 
## Xxxxxxx xxxxxx

* [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794)
* [XXXX xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185595)
* [XxxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/staticresource-markup-extension.md)
* [XxxxxXxxxxxxx xxxxxx xxxxxxxxx](../xaml-platform/themeresource-markup-extension.md)
* [XXXX xxxxx xxxxxxxxx](xaml-theme-resources.md)
* [Xxxxxxx xxxxxxxx](styling-controls.md)
* [x:Xxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt204787)

<!--HONumber=Mar16_HO1-->
