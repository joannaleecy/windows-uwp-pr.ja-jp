---
xx.xxxxxxx: YYYYYYXY-XXYX-YYXY-XYYY-YXXXYXYYYYYY
xxxxx: Xxx xxx xxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx xxxxxxxxx xx xxxxxx xxxxxxx xx xxxx xxxxxxxx.
---
# Xxx xxx xxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225718)

\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xxxxx xxx xx xxx xxx xxxxxxxxx xx xxxxxx xxxxxxx xx xxxx xxxxxxxx.

Xxxxxxxxxx xxxxxxxxxx xxxxxxxxxxxxxx xx xxxx xxxxxxxxxxx. Xxx xxxxxxxxxxxxx xxx xxxxxxx xxxxxx xxxxxx xxxxx xxx xxxxxxxxx xxxxxxxx xxxxxxx xxxxxxxx xx xxxxxxxxxx xxxxxx.

## Xxxxxxxxxxxxx

Xxx xxxxxx xx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX), Xxxxxxxxx Xxxxxx X#, xxx xxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx'xx xxxxx xxxx xxxxxxx x xxxxxxxxx.

## Xxxxxx x xxxxxx xxxxxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx x xxxxxx xxxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

###  Xxxxxxxxxxxx

-   Xxxxxx x xxx xxxxxxx, xxxxxxxx x **Xxxxx Xxx (Xxxxxxxxx Xxxxxxx)** xxxx xxx **Xxxxxx X#** xxxxxxx xxxxxxxxx.

-   Xxxx xxxx xxxxxxx'x XxxxXxxx.xxxx.xx xxxx xxx xxxxxxx xxx xxxxxxxx xxxx xxxx xxx xxxxxxxxx.

```csharp
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    using Windows.UI.Core; // Required to access the core dispatcher object
    using Windows.Devices.Sensors; // Required to access the sensor platform and the gyrometer


    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Gyrometer _gyrometer; // Our app' s gyrometer object
     
            // This event handler writes the current gyrometer reading to 
            // the three textblocks on the app' s main page.

            private async void ReadingChanged(object sender, GyrometerReadingChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    GyrometerReading reading = e.Reading;
                    txtXAxis.Text = String.Format("{0,5:0.00}", reading.AngularVelocityX);
                    txtYAxis.Text = String.Format("{0,5:0.00}", reading.AngularVelocityY);
                    txtZAxis.Text = String.Format("{0,5:0.00}", reading.AngularVelocityZ);
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _gyrometer = Gyrometer.GetDefault(); // Get the default gyrometer sensor object
                
                if (_gyrometer != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _gyrometer.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _gyrometer.ReportInterval = reportInterval;

                    // Assign an event handler for the gyrometer reading-changed event
                    _gyrometer.ReadingChanged += new TypedEventHandler<Gyrometer, GyrometerReadingChangedEventArgs>(ReadingChanged);
                }

            }
        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace GyrometerCS`.

-   Xxxx xxx xxxx XxxxXxxx.xxxx xxx xxxxxxx xxx xxxxxxxx xxxxxxxx xxxx xxx xxxxxxxxx XXX.

```xml 
        <Page
        x:Class="App1.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">

        <Grid x:Name="LayoutRoot" Background="#FF0C0C0C">
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="8,8,0,0" TextWrapping="Wrap" Text="X-Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFDFDFD"/>
            <TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="23" Margin="67,8,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="88" Foreground="#FFFDFAFA"/>
            <TextBlock HorizontalAlignment="Left" Height="20" Margin="8,52,0,0" TextWrapping="Wrap" Text="Y Axis:" VerticalAlignment="Top" Width="46" Foreground="White"/>
            <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="24" Margin="54,48,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="80" Foreground="#FFFBFBFB"/>
            <TextBlock HorizontalAlignment="Left" Height="21" Margin="8,93,0,0" TextWrapping="Wrap" Text="Z Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFEFBFB"/>
            <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="21" Margin="54,93,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="63" Foreground="#FFF8F3F3"/>

        </Grid>
    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="GyrometerCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:GyrometerCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** > **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** > **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

###  Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xx xxx **XxxxXxxx** xxxxxx.

```csharp
_gyrometer = Gyrometer.GetDefault(); // Get the default gyrometer sensor object
```

Xxx xxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxx xxx **XxxxXxxx** xxxxxx. Xxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xx xx x xxxxxxxxx xxxxxxxx xx YY xxxxxxxxxxxx (xxxxx xxxxxxxxxxxx x YY-Xx xxxxxxx xxxx). Xx xxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx. Xxxxxxxxx, xx xxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

```csharp
uint minReportInterval = _gyrometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_gyrometer.ReportInterval = reportInterval;
```

Xxx xxx xxxxxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```csharp
_gyrometer.ReadingChanged += new TypedEventHandler<Gyrometer, 
GyrometerReadingChangedEventArgs>(ReadingChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx xxx XxxxXxxxxx xxxxx xx xxx xxxxxxx'x XXXX.

```xml
        <TextBlock HorizontalAlignment="Left" Height="23" Margin="8,8,0,0" TextWrapping="Wrap" Text="X-Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFDFDFD"/>
        <TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="23" Margin="67,8,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="88" Foreground="#FFFDFAFA"/>
        <TextBlock HorizontalAlignment="Left" Height="20" Margin="8,52,0,0" TextWrapping="Wrap" Text="Y Axis:" VerticalAlignment="Top" Width="46" Foreground="White"/>
        <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="24" Margin="54,48,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="80" Foreground="#FFFBFBFB"/>
        <TextBlock HorizontalAlignment="Left" Height="21" Margin="8,93,0,0" TextWrapping="Wrap" Text="Z Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFEFBFB"/>
        <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="21" Margin="54,93,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="63" Foreground="#FFF8F3F3"/></code></pre></td>
```

 ## Xxxxxxx xxxxxx

* [Xxxxxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241379)

<!--HONumber=Mar16_HO1-->
