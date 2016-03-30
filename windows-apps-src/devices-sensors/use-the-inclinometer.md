---
xx.xxxxxxx: YYXXYYXX-YYYY-YYYX-YYYY-YYYYXYXXYYXY
xxxxx: Xxx xxx xxxxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx xxxxxxxxxxxx xx xxxxxxxxx xxxxx, xxxx, xxx xxx.
---
# Xxx xxx xxxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**Xxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225766)

Xxxxx xxx xx xxx xxx xxxxxxxxxxxx xx xxxxxxxxx xxxxx, xxxx, xxx xxx.

Xxxx Y-X xxxxx xxxxxxx xx xxxxxxxxxxxx xx xx xxxxx xxxxxx. Xxx xxxxxx xxxxxxx xx xxx xxxxxx xxxxxxxxx, xxxxx xxxx xxx xxxxx xxxx xx xxx xxxxxxxxxxxx (X, X, xxx X) xx xxx xxxxxxxx, xxxxxxx, xxx xxxxxx xxxxxx xx xxx xxxxxxxx.

 ## Xxxxxxxxxxxxx

Xxx xxxxxx xx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX), Xxxxxxxxx Xxxxxx X#, xxx xxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx'xx xxxxx xxxx xxxxxxx x xxxxxxxxxxxx.

 ## Xxxxxx x xxxxxx xxxxxxxxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx x xxxxxx xxxxxxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

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

    using Windows.UI.Core;
    using Windows.Devices.Sensors;


    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Inclinometer _inclinometer;

            // This event handler writes the current inclinometer reading to 
            // the three text blocks on the app' s main page.

            private async void ReadingChanged(object sender, InclinometerReadingChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    InclinometerReading reading = e.Reading;
                    txtPitch.Text = String.Format("{0,5:0.00}", reading.PitchDegrees);
                    txtRoll.Text = String.Format("{0,5:0.00}", reading.RollDegrees);
                    txtYaw.Text = String.Format("{0,5:0.00}", reading.YawDegrees);
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _inclinometer = Inclinometer.GetDefault();
     

                if (_inclinometer != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _inclinometer.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _inclinometer.ReportInterval = reportInterval;

                    // Establish the event handler
                    _inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace InclinometerCS`.

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
            <TextBlock HorizontalAlignment="Left" Height="21" Margin="0,8,0,0" TextWrapping="Wrap" Text="Pitch: " VerticalAlignment="Top" Width="45" Foreground="#FFF9F4F4"/>
            <TextBlock x:Name="txtPitch" HorizontalAlignment="Left" Height="21" Margin="59,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="71" Foreground="#FFFDF9F9"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="0,29,0,0" TextWrapping="Wrap" Text="Roll:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F1F1"/>
            <TextBlock x:Name="txtRoll" HorizontalAlignment="Left" Height="23" Margin="59,29,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="50" Foreground="#FFFCF9F9"/>
            <TextBlock HorizontalAlignment="Left" Height="19" Margin="0,56,0,0" TextWrapping="Wrap" Text="Yaw:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F3F3"/>
            <TextBlock x:Name="txtYaw" HorizontalAlignment="Left" Height="19" Margin="55,56,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="54" Foreground="#FFF6F2F2"/>

        </Grid>
    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="InclinometerCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:InclinometerCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** > **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** > **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

###  Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxxxxxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxxxxx xx xxx **XxxxXxxx** xxxxxx.

```csharp
_inclinometer = Inclinometer.GetDefault();
```

Xxx xxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxx xxx **XxxxXxxx** xxxxxx. Xxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xx xx x xxxxxxxxx xxxxxxxx xx YY xxxxxxxxxxxx (xxxxx xxxxxxxxxxxx x YY-Xx xxxxxxx xxxx). Xx xxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx. Xxxxxxxxx, xx xxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

```csharp
uint minReportInterval = _inclinometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_inclinometer.ReportInterval = reportInterval;
```

Xxx xxx xxxxxxxxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```
_inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, 
InclinometerReadingChangedEventArgs>(ReadingChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx xxx XxxxXxxxxx xxxxx xx xxx xxxxxxx'x XXXX.

```xml
<TextBlock HorizontalAlignment="Left" Height="21" Margin="0,8,0,0" TextWrapping="Wrap" Text="Pitch: " VerticalAlignment="Top" Width="45" Foreground="#FFF9F4F4"/>
 <TextBlock x:Name="txtPitch" HorizontalAlignment="Left" Height="21" Margin="59,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="71" Foreground="#FFFDF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="23" Margin="0,29,0,0" TextWrapping="Wrap" Text="Roll:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F1F1"/>
 <TextBlock x:Name="txtRoll" HorizontalAlignment="Left" Height="23" Margin="59,29,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="50" Foreground="#FFFCF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="19" Margin="0,56,0,0" TextWrapping="Wrap" Text="Yaw:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F3F3"/>
 <TextBlock x:Name="txtYaw" HorizontalAlignment="Left" Height="19" Margin="55,56,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="54" Foreground="#FFF6F2F2"/>
```

 ## Xxxxxxx xxxxxx

* [Xxxxxxxxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241380)

<!--HONumber=Mar16_HO1-->
