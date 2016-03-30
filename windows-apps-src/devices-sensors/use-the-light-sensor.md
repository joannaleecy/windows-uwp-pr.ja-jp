---
xx.xxxxxxx: YYXXXYYX-XXYX-YXYY-YXYX-XXYXYYYYXXXY
xxxxx: Xxx xxx xxxxx xxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx xxxxxxx xxxxx xxxxxx xx xxxxxx xxxxxxx xx xxxxxxxx.
---
# Xxx xxx xxxxx xxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225790)

Xxxxx xxx xx xxx xxx xxxxxxx xxxxx xxxxxx xx xxxxxx xxxxxxx xx xxxxxxxx.

Xx xxxxxxx xxxxx xxxxxx xx xxx xx xxx xxxxxxx xxxxx xx xxxxxxxxxxxxx xxxxxxx xxxx xxxxx xxxx xx xxxxxxx xx xxxxxxx xx xxx xxxx'x xxxxxxxxxxx.

## Xxxxxxxxxxxxx

Xxx xxxxxx xx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX), Xxxxxxxxx Xxxxxx X#, xxx xxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx'xx xxxxx xxxx xxxxxxx xx xxxxxxx xxxxx xxxxxx.

## Xxxxxx x xxxxxx xxxxx-xxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx x xxxxxx xxxxx-xxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

###  Xxxxxxxxxxxx

-   Xxxxxx x xxx xxxxxxx, xxxxxxxx x **Xxxxx Xxx (Xxxxxxxxx Xxxxxxx)** xxxx xxx **Xxxxxx X#** xxxxxxx xxxxxxxxx.

-   Xxxx xxxx xxxxxxx'x XxxxxXxxx.xxxx.xx xxxx xxx xxxxxxx xxx xxxxxxxx xxxx xxxx xxx xxxxxxxxx.

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
    using Windows.Devices.Sensors; // Required to access the sensor platform and the ALS

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?linkid=234238

    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class BlankPage : Page
        {
            private LightSensor _lightsensor; // Our app' s lightsensor object
           
            // This event handler writes the current light-sensor reading to 
            // the textbox named "txtLUX" on the app' s main page.

            private void ReadingChanged(object sender, LightSensorReadingChangedEventArgs e)
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, (s, a) =>
                {
                    LightSensorReading reading = (a.Context as LightSensorReadingChangedEventArgs).Reading;
                    txtLuxValue.Text = String.Format("{0,5:0.00}", reading.IlluminanceInLux);
                });
            }

            public BlankPage()
            {
                InitializeComponent();
                _lightsensor = LightSensor.GetDefault(); // Get the default light sensor object

                // Assign an event handler for the ALS reading-changed event
                if (_lightsensor != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _lightsensor.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _lightsensor.ReportInterval = reportInterval;

                    // Establish the even thandler
                    _lightsensor.ReadingChanged += new TypedEventHandler<LightSensor, LightSensorReadingChangedEventArgs>(ReadingChanged);
                }

            }

        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace LightingCS`.

-   Xxxx xxx xxxx XxxxXxxx.xxxx xxx xxxxxxx xxx xxxxxxxx xxxxxxxx xxxx xxx xxxxxxxxx XXX.

```xml
    <Page
        x:Class="App1.BlankPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">

        <Grid x:Name="LayoutRoot" Background="Black">
            <TextBlock HorizontalAlignment="Left" Height="44" Margin="52,38,0,0" TextWrapping="Wrap" Text="LUX Reading" VerticalAlignment="Top" Width="150"/>
            <TextBlock x:Name="txtLuxValue" HorizontalAlignment="Left" Height="44" Margin="224,38,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="217"/>


        </Grid>

    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="LightingCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:LightingCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** > **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxx xxxxxx xxxxxx xx xxxxxxxx xxx xxxxx xxxxxxxxx xx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** > **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

###  Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxx-xxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxx xx xxx **XxxxxXxxx** xxxxxx.

```csharp
_lightsensor = LightSensor.GetDefault(); // Get the default light sensor object
```

Xxx xxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxx xxx **XxxxxXxxx** xxxxxx. Xxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xx xx x xxxxxxxxx xxxxxxxx xx YY xxxxxxxxxxxx (xxxxx xxxxxxxxxxxx x YY-Xx xxxxxxx xxxx). Xx xxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx. Xxxxxxxxx, xx xxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

```csharp
uint minReportInterval = _lightsensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_lightsensor.ReportInterval = reportInterval;
```
Xxx xxx xxxxx-xxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```csharp
_lightsensor.ReadingChanged += new TypedEventHandler<LightSensor, 
LightSensorReadingChangedEventArgs>(ReadingChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx x XxxxXxxxx xxxxx xx xxx xxxxxxx'x XXXX.

```xml
<TextBlock HorizontalAlignment="Left" Height="44" Margin="52,38,0,0" TextWrapping="Wrap" Text="LUX Reading" VerticalAlignment="Top" Width="150"/>
 <TextBlock x:Name="txtLuxValue" HorizontalAlignment="Left" Height="44" Margin="224,38,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="217"/>
```

## Xxxxxxx xxxxxx

* [XxxxxXxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241381)
 

<!--HONumber=Mar16_HO1-->
