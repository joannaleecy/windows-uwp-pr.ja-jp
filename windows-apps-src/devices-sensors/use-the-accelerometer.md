---
xx.xxxxxxx: XYYYYYXY-YYYX-YYXY-XXYY-XXYXXYYXYXYY
xxxxx: Xxx xxx xxxxxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx xxxxxxxxxxxxx xx xxxxxxx xx xxxx xxxxxxxx.
---
# Xxx xxx xxxxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**Xxxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225687)

\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xxxxx xxx xx xxx xxx xxxxxxxxxxxxx xx xxxxxxx xx xxxx xxxxxxxx.

X xxxxxx xxxx xxx xxxxxx xx x xxxxxx xxxxxx, xxx xxxxxxxxxxxxx, xx xx xxxxx xxxxxx. Xxxxx xxxx xxxxxxxxx xxx xxxx xxx xx xxx xxxx xxx xxxxx; xxx xxxx xxx xxxx xxx xxx xxxxx xxxxx xx xxxxxxx xxxxx xxxxxx.

## Xxxxxxxxxxxxx

Xxx xxxxxx xx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX), Xxxxxxxxx Xxxxxx X#, xxx xxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx'xx xxxxx xxxx xxxxxxx xx xxxxxxxxxxxxx.

## Xxxxxx x xxxxxx xxxxxxxxxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx x xxxxxx xxxxxxxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

### Xxxxxxxxxxxx

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

    // Required to support the core dispatcher and the accelerometer

    using Windows.UI.Core;
    using Windows.Devices.Sensors;

    namespace App1
    {

        public sealed partial class MainPage : Page
        {
            // Sensor and dispatcher variables
            private Accelerometer _accelerometer;

            // This event handler writes the current accelerometer reading to 
            // the three acceleration text blocks on the app' s main page.

            private async void ReadingChanged(object sender, AccelerometerReadingChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    AccelerometerReading reading = e.Reading;
                    txtXAxis.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                    txtYAxis.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                    txtZAxis.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);

                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _accelerometer = Accelerometer.GetDefault();

                if (_accelerometer != null)
                {
                    // Establish the report interval
                    uint minReportInterval = _accelerometer.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _accelerometer.ReportInterval = reportInterval;

                    // Assign an event handler for the reading-changed event
                    _accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace AccelerometerCS`.

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
            <TextBlock HorizontalAlignment="Left" Height="25" Margin="8,20,0,0" TextWrapping="Wrap" Text="X-axis:" VerticalAlignment="Top" Width="62" Foreground="#FFEDE6E6"/>
            <TextBlock HorizontalAlignment="Left" Height="27" Margin="8,49,0,0" TextWrapping="Wrap" Text="Y-axis:" VerticalAlignment="Top" Width="62" Foreground="#FFF5F2F2"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="8,80,0,0" TextWrapping="Wrap" Text="Z-axis:" VerticalAlignment="Top" Width="62" Foreground="#FFF6F0F0"/>
            <TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="15" Margin="70,16,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="61" Foreground="#FFF2F2F2"/>
            <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="15" Margin="70,49,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFF2EEEE"/>
            <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="15" Margin="70,80,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFFFF8F8"/>

        </Grid>
    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="AccelerometerCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:AccelerometerCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** &xx; **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** &xx; **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

### Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxxxxxxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxxxxxx xx xxx **XxxxXxxx** xxxxxx.

```csharp
_accelerometer = Accelerometer.GetDefault();
```

Xxx xxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxx xxx **XxxxXxxx** xxxxxx. Xxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xx xx x xxxxxxxxx xxxxxxxx xx YY xxxxxxxxxxxx (xxxxx xxxxxxxxxxxx x YY-Xx xxxxxxx xxxx). Xx xxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx. Xxxxxxxxx, xx xxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

```csharp
uint minReportInterval = _accelerometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_accelerometer.ReportInterval = reportInterval;
```

Xxx xxx xxxxxxxxxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```csharp
_accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, 
AccelerometerReadingChangedEventArgs>(ReadingChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx xxx XxxxXxxxxx xxxxx xx xxx xxxxxxx'x XXXX.

```xml
<TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="15" Margin="70,16,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="61" Foreground="#FFF2F2F2"/>
 <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="15" Margin="70,49,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFF2EEEE"/>
 <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="15" Margin="70,80,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFFFF8F8"/>
```
## Xxxxxxx xxxxxx

* [Xxxxxxxxxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241377)

<!--HONumber=Mar16_HO1-->
