---
xx.xxxxxxx: YYYYXXYX-XYYY-YYYY-YYXY-XYYYYYYXYXYX
xxxxx: Xxx xxx xxxxxxxxxxx xxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx xxxxxxxxxxx xxxxxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxxxxx.
---
# Xxx xxx xxxxxxxxxxx xxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**XxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206371)
-   [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206399)

Xxxxx xxx xx xxx xxx xxxxxxxxxxx xxxxxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxxxxx.

Xxxxx xxx xxx xxxxxxxxx xxxxx xx xxxxxxxxxxx xxxxxx XXXx xxxxxxxx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408) xxxxxxxxx: [**XxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206371) xxx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206399). Xxxxx xxxx xx xxxxx xxxxxxx xxx xxxxxxxxxxx xxxxxxx, xxxx xxxx xx xxxxxxxxxx xxx xxxx xxx xxxx xxx xxxx xxxxxxxxx xxxxxxxx. Xxxxxxx, xxxxx xxxx xxx xxxxxxxxxxx xxxxxxx, xxxx xxx xxxx xxxxxxx xx xxxx xxxxxxx.

Xxx [**XxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206371) XXX xx xxxx xxx Y-X xxxx xxx xxxxxx x xxxxxxxxxx xxx x xxxxxxxx xxxxxx. X xxxxxxxxxx xxx xx xxxx xxxxxx xxxxxxxxxx xx x xxxxxxxx xx x xxxxx \[x,x,x\] xxxxx xx xxxxxxxxx xxxx (xxxxxxxxxx xxxx x xxxxxxxx xxxxxx, xxxxx xxxxxxxxxx xxxxxxxxx xxxxxx xxxxx xxxx). Xxx xxxxxxxxxxx xxxxxx xxxxxxxxxxx xx xxxxxx xxxxxx xx xxxx xx xxxxxxxx xxx xxxxxxxxx xxxxxxxxxx xx xxxxxxx xxxxxxx xxx xxxxxxxxxxxx xxxxxxxxxx xx xxxxxxxxx xxxxxxx, xxx xxxxxxx xxxx xxxx xx xxxxxx, xxx xxxxxxxxxx xxxx XxxxxxX xxxxxxx xxxx. X xxxxxxx Y-X xxx xxx xxx xxx Xxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxx'x xxxxxxxxxxx. Xxxx xxxxxx xxxxxxxx xxxxx xxxx xxx xxxxxxxxxxxxx, xxxxxxxxx, xxx xxxxxxx.

Xxx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206399) XXX xx xxxx xx xxxxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxxxx xx xxxxx xx xxxxxxxxxxx xxxx xxxxxxxx xx, xxxxxxxx xxxx, xxxxxxxxx xxxx, xxx xxxxxxxxx xxxxx. Xx xxx xxxx xxxxxx xx x xxxxxx xx xxxx-xx xx xxxx-xxxx. Xxxxxx xxxx xxxxxxxxx xxxxxxxxxx xxxx "xxxxxxxx xx" xx "xxxxxxxxx xxxx", xxxx xxxxxx xxxxxxx x xxxxxxxx xxxxx: "Xxx xxxxxxx", "XxxxxxxYYXxxxxxxXxxxxxxxxxxxxxxx", xxx xx xx. Xxx xxxxxxxxx xxxxx xxxx xxxxxx xxxxxxxxxxx xxxxxxxxxx xx xxx xxxxxxxxxxxxx xxxxxx xxxxxxx.

| Xxxxxxxxxxx     | Xxxxxxxxxxxxx xxxxxx xxxxxxx      |
|-----------------|-----------------------------------|
| Xxxxxxxx Xx     | XxxXxxxxxx                        |
| Xxxxxxxxx Xxxx  | XxxxxxxYYXxxxxxxXxxxxxxxxxxxxxxx  |
| Xxxxxxxx Xxxx   | XxxxxxxYYYXxxxxxxXxxxxxxxxxxxxxxx |
| Xxxxxxxxx Xxxxx | XxxxxxxYYYXxxxxxxXxxxxxxxxxxxxxxx |

## Xxxxxxxxxxxxx

Xxx xxxxxx xx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX), Xxxxxxxxx Xxxxxx X#, xxx xxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx'xx xxxxx xxxx xxxxxxx x xxxxxxxxxxx xxxxxx.

## Xxxxxx xx XxxxxxxxxxxXxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx xx xxxxxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

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

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?linkid=234238

    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private OrientationSensor _sensor;

            private async void ReadingChanged(object sender, OrientationSensorReadingChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    OrientationSensorReading reading = e.Reading;

                    // Quaternion values
                    txtQuaternionX.Text = String.Format("{0,8:0.00000}", reading.Quaternion.X);
                    txtQuaternionY.Text = String.Format("{0,8:0.00000}", reading.Quaternion.Y);
                    txtQuaternionZ.Text = String.Format("{0,8:0.00000}", reading.Quaternion.Z);
                    txtQuaternionW.Text = String.Format("{0,8:0.00000}", reading.Quaternion.W);

                    // Rotation Matrix values
                    txtM11.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M11);
                    txtM12.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M12);
                    txtM13.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M13);
                    txtM21.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M21);
                    txtM22.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M22);
                    txtM23.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M23);
                    txtM31.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M31);
                    txtM32.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M32);
                    txtM33.Text = String.Format("{0,8:0.00000}", reading.RotationMatrix.M33);
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _sensor = OrientationSensor.GetDefault();
     
                // Establish the report interval for all scenarios
                uint minReportInterval = _sensor.MinimumReportInterval;
                uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                _sensor.ReportInterval = reportInterval;

                // Establish event handler
                _sensor.ReadingChanged += new TypedEventHandler<OrientationSensor, OrientationSensorReadingChangedEventArgs>(ReadingChanged);
            }
        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxXxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace OrientationSensorCS`.

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

        <Grid x:Name="LayoutRoot" Background="Black">
            <TextBlock HorizontalAlignment="Left" Height="28" Margin="4,4,0,0" TextWrapping="Wrap" Text="M11:" VerticalAlignment="Top" Width="46"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="4,36,0,0" TextWrapping="Wrap" Text="M12:" VerticalAlignment="Top" Width="39"/>
            <TextBlock HorizontalAlignment="Left" Height="24" Margin="4,72,0,0" TextWrapping="Wrap" Text="M13:" VerticalAlignment="Top" Width="39"/>
            <TextBlock HorizontalAlignment="Left" Height="31" Margin="4,118,0,0" TextWrapping="Wrap" Text="M21:" VerticalAlignment="Top" Width="39"/>
            <TextBlock HorizontalAlignment="Left" Height="24" Margin="4,160,0,0" TextWrapping="Wrap" Text="M22:" VerticalAlignment="Top" Width="39"/>
            <TextBlock HorizontalAlignment="Left" Height="24" Margin="8,201,0,0" TextWrapping="Wrap" Text="M23:" VerticalAlignment="Top" Width="35"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="4,234,0,0" TextWrapping="Wrap" Text="M31:" VerticalAlignment="Top" Width="39"/>
            <TextBlock HorizontalAlignment="Left" Height="28" Margin="4,274,0,0" TextWrapping="Wrap" Text="M32:" VerticalAlignment="Top" Width="46"/>
            <TextBlock HorizontalAlignment="Left" Height="21" Margin="4,322,0,0" TextWrapping="Wrap" Text="M33:" VerticalAlignment="Top" Width="39"/>
            <TextBlock x:Name="txtM11" HorizontalAlignment="Left" Height="19" Margin="43,4,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM12" HorizontalAlignment="Left" Height="23" Margin="43,36,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM13" HorizontalAlignment="Left" Height="15" Margin="43,72,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM21" HorizontalAlignment="Left" Height="20" Margin="43,114,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM22" HorizontalAlignment="Left" Height="19" Margin="43,156,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM23" HorizontalAlignment="Left" Height="16" Margin="43,197,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM31" HorizontalAlignment="Left" Height="17" Margin="43,230,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM32" HorizontalAlignment="Left" Height="19" Margin="43,270,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock x:Name="txtM33" HorizontalAlignment="Left" Height="21" Margin="43,322,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53"/>
            <TextBlock HorizontalAlignment="Left" Height="15" Margin="194,8,0,0" TextWrapping="Wrap" Text="Quaternion X:" VerticalAlignment="Top" Width="81"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="194,36,0,0" TextWrapping="Wrap" Text="Quaternion Y:" VerticalAlignment="Top" Width="81"/>
            <TextBlock HorizontalAlignment="Left" Height="15" Margin="194,72,0,0" TextWrapping="Wrap" Text="Quaternion Z:" VerticalAlignment="Top" Width="81"/>
            <TextBlock x:Name="txtQuaternionX" HorizontalAlignment="Left" Height="15" Margin="279,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="104"/>
            <TextBlock x:Name="txtQuaternionY" HorizontalAlignment="Left" Height="12" Margin="275,36,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="108"/>
            <TextBlock x:Name="txtQuaternionZ" HorizontalAlignment="Left" Height="19" Margin="275,68,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="89"/>
            <TextBlock HorizontalAlignment="Left" Height="21" Margin="194,96,0,0" TextWrapping="Wrap" Text="Quaternion W:" VerticalAlignment="Top" Width="81"/>
            <TextBlock x:Name="txtQuaternionW" HorizontalAlignment="Left" Height="12" Margin="279,96,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="72"/>

        </Grid>
    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxxxxxxXxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="OrientationSensorCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:OrientationSensorCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** > **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxxxxx xx xxxxxx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** > **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

###  Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxxxxxxxx-xxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxxxx xxxxxx xx xxx **XxxxXxxx** xxxxxx.

```csharp
_sensor = OrientationSensor.GetDefault();
```

Xxx xxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxx xxx **XxxxXxxx** xxxxxx. Xxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xx xx x xxxxxxxxx xxxxxxxx xx YY xxxxxxxxxxxx (xxxxx xxxxxxxxxxxx x YY-Xx xxxxxxx xxxx). Xx xxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx. Xxxxxxxxx, xx xxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

```csharp
uint minReportInterval = _sensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_sensor.ReportInterval = reportInterval;
```

Xxx xxx xxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```csharp
_sensor.ReadingChanged += new TypedEventHandler<OrientationSensor, 
OrientationSensorReadingChangedEventArgs>(ReadingChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx xxx XxxxXxxxxx xxxxx xx xxx xxxxxxx'x XXXX.

## Xxxxxx x XxxxxxXxxxxxxxxxx xxx

Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxx xxxxxxxxx xx xxxxxx x xxxxxx xxxxxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxx xxxx xxxxxxx.

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

    using Windows.UI.Core;
    using Windows.Devices.Sensors;
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?linkid=234238

    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            // Sensor and dispatcher variables
            private SimpleOrientationSensor _simpleorientation;

            // This event handler writes the current sensor reading to 
            // a text block on the app' s main page.

            private async void OrientationChanged(object sender, SimpleOrientationSensorOrientationChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    SimpleOrientation orientation = e.Orientation;
                    switch (orientation)
                    {
                        case SimpleOrientation.NotRotated:
                            txtOrientation.Text = "Not Rotated";
                            break;
                        case SimpleOrientation.Rotated90DegreesCounterclockwise:
                            txtOrientation.Text = "Rotated 90 Degrees Counterclockwise";
                            break;
                        case SimpleOrientation.Rotated180DegreesCounterclockwise:
                            txtOrientation.Text = "Rotated 180 Degrees Counterclockwise";
                            break;
                        case SimpleOrientation.Rotated270DegreesCounterclockwise:
                            txtOrientation.Text = "Rotated 270 Degrees Counterclockwise";
                            break;
                        case SimpleOrientation.Faceup:
                            txtOrientation.Text = "Faceup";
                            break;
                        case SimpleOrientation.Facedown:
                            txtOrientation.Text = "Facedown";
                            break;
                        default:
                            txtOrientation.Text = "Unknown orientation";
                            break;
                    }
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _simpleorientation = SimpleOrientationSensor.GetDefault();

                // Assign an event handler for the sensor orientation-changed event
                if (_simpleorientation != null)
                {
                    _simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
                }
            }
        }
    }
```

Xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxXxxxxxxxxxxXX**, xxx'x xxxxxxx `namespace App1` xxxx `namespace SimpleOrientationCS`.

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
            <TextBlock HorizontalAlignment="Left" Height="24" Margin="8,8,0,0" TextWrapping="Wrap" Text="Current Orientation:" VerticalAlignment="Top" Width="101" Foreground="#FFF8F7F7"/>
            <TextBlock x:Name="txtOrientation" HorizontalAlignment="Left" Height="24" Margin="118,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="175" Foreground="#FFFEFAFA"/>

        </Grid>
    </Page>
```

Xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxxXxxxxxxxxxxXX**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="SimpleOrientationCS.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:SimpleOrientationCS"`.

-   Xxxxx XY xx xxxxxx **Xxxxx** > **Xxxxx Xxxxxxxxx** xx xxxxx, xxxxxx, xxx xxx xxx xxx.

Xxxx xxx xxx xx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxxxxx xx xxxxxx xxx xxxxxx xx xxxxx xxx xxxxxxxx xxxxx.

-   Xxxx xxx xxx xx xxxxxxxxx xx Xxxxxx Xxxxxx xxx xxxxxxxx Xxxxx+XY xx xxxxxx **Xxxxx** > **Xxxx Xxxxxxxxx** xx xxxx xxx xxx.

### Xxxxxxxxxxx

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xxxxxx xxxx xxx'xx xxxx xx xxxxx xx xxxxx xx xxxxxxxxx xxxxxx-xxxxxxxxxxx xxxxxx xxxxx xx xxxx xxx.

Xxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxxxxx xxxxxx xx xxx **XxxxXxxx** xxxxxx.

```csharp
_simpleorientation = SimpleOrientationSensor.GetDefault();
```

Xxx xxx xxxxxx xxxx xx xxxxxxxx xx xxx **XxxxxxxxxxxXxxxxxx** xxxxxx. Xxxx xxxx xxx xxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx, xx xxxxxx xxx xxxxxx xx xxxx xxx xxxxx xxxx xxxxx xxxxxxx. Xxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxx xxxx.

```csharp
_simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor, 
SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
```

Xxxxx xxx xxxxxx xxx xxxxxxx xx x XxxxXxxxx xxxxx xx xxx xxxxxxx'x XXXX.

```csharp
<TextBlock HorizontalAlignment="Left" Height="24" Margin="8,8,0,0" TextWrapping="Wrap" Text="Current Orientation:" VerticalAlignment="Top" Width="101" Foreground="#FFF8F7F7"/>
 <TextBlock x:Name="txtOrientation" HorizontalAlignment="Left" Height="24" Margin="118,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="175" Foreground="#FFFEFAFA"/>
```

## Xxxxxxx xxxxxx

* [XxxxxxxxxxxXxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241382)
* [XxxxxxXxxxxxxxxxx Xxxxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241383)
 

<!--HONumber=Mar16_HO1-->
