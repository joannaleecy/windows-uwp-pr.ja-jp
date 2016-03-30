---
xx.xxxxxxx: YYXXYYXX-YYXX-YYYX-XYXX-YYYYXYYXXYYX
xxxxx: Xxx xxxxxxx xxxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxxxxxxx xxxxxxx xxxxxxxxxxx xxxxx XXXx xx xxx Xxxxxxx.Xxxxxxx.Xxxxx xxxxxxxxx.
---
# Xxx xxxxxxx xxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895017)
-   [**XxxxxxXxxxxxxxxxx.XxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225432)

Xxxxx xxx xx xxx xxxxxxxx xxxxxxx xxxxxxxxxxx xxxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895017) xxxxxxxxx. X *xxxxxxx xxxxxx* ([**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005)) xxxxxxxxx xxx xxxxxx, xxxxxxxx, xxx xxxxxx xx x xxxxxxx xx xxxxxxxxx xx xxxxxxxxx. Xxxx xxxxx xxxxxxxxxxxx xxx xxxx xxx xxx xxx xxxxxxx xxxxxxx xxx xx xxxxxxxx xx xxxxxxx. Xxxx xxxxxxxx xxx xxxx xxx xxxxx xxxxxxx xxx xxxx'x xxxxxx xx xxx xxx xx xxxx xxxxx.

## Xxx xxxxxxxxx xxxxxxx xxxxxx


Xxxx xxxxxxx xxxx xxxx xxxx xxx xxxxxxx xxx xx'x xxx xxxxxx xxxxxxx xxx xxxx xxxxxxx xxxxxxxxxxx xx xxx xxxxxxx xxxxxx xxxxxxxx xx xxx xxxxxx. Xxxx xx xxxxx xxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895011) xxxxx xxxxx xx. Xxx *xxxxxxxxx xxxxxxx* xxxxxxxxxx xxx xxxxxxx xxxxxxxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxx xxxxxxx x xxxxxx xxxxxxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005) xxxxxx.

**Xxxx**  X [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895004) xxxxx xxxxxxxx xxxxxxxxxxx xx x xxxxxxx xxxxxxxxxx. Xxxxxxxxx xx xxx xxxxxx, xxxxxxxxx xxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxxxxxx xxxxxxx xxx xxxxxxxxx xx'x xxxxxxxx xx xxx xxxxxx xxxxxxxxx. Xxxx, xx'x xxxxxxxx xx xxxxxx x xxxxxxx xxxxxx xxxx xxxx xx xxxxxxxxx xxx xxxxxxx. Xxxxx xxxxx, xxx xxxxxxx xxxxxx xxx xx **xxxx**.

Xxxx xxx xxxx xx xxxxxxxxx xxxxxxx xxxxxx, xxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) xx xxx xxx xxxxxxxxxxxxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005).

```csharp
private void RequestAggregateBatteryReport()
{
    // Create aggregate battery object
    var aggBattery = Battery.AggregateBattery;

    // Get report
    var report = aggBattery.GetReport();

    // Update UI
    AddReportUI(BatteryReportPanel, report, aggBattery.DeviceId);
}
```

## Xxx xxxxxxxxxx xxxxxxx xxxxxxx

Xxx xxx xxxx xxxxxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005) xxxxxx xxx xxxxxxxxxx xxxxxxxxx. Xxx [**XxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.power.battery.getdeviceselector.aspx) xxxx xxx [**XxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225432) xxxxxx xx xxxxxx x xxxxxxxxxx xx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225393) xxxxxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx xx xxx xxxxxx. Xxxx, xxxxx xxx **Xx** xxxxxxxx xx xxx xxxxxxx **XxxxxxXxxxxxxxxxx** xxxxxx, xxxxxx x xxxxxxxxxxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895004) xxxx xxx [**XxxxXxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.power.battery.fromidasync.aspx) xxxxxx. Xxxxxxx, xxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) xx xxx xxx xxxxxxxxxx xxxxxxx xxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxx x xxxxxxx xxxxxx xxx xxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxx.

```csharp
async private void RequestIndividualBatteryReports()
{
    // Find batteries 
    var deviceInfo = await DeviceInformation.FindAllAsync(Battery.GetDeviceSelector());
    foreach(DeviceInformation device in deviceInfo)
    {
        try
        {
        // Create battery object
        var battery = await Battery.FromIdAsync(device.Id);

        // Get report
        var report = battery.GetReport();

        // Update UI
        AddReportUI(BatteryReportPanel, report, battery.DeviceId);
        }
        catch { /* Add error handling, as applicable */ }
    }
}
```

## Xxxxxx xxxxxx xxxxxxx

Xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005) xxxxxx xxxxxxxx x xxx xx xxxxxxx xxxxxxxxxxx. Xxx xxxx xxxx, xxx xxx XXX xxxxxxxxx xxx xxx xxxxxxxxxx: **Xxxxxx** (x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn818458) xxxxxxxxxxx), [**XxxxxxXxxxXxXxxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.power.batteryreport.chargerateinmilliwatts.aspx), [**XxxxxxXxxxxxxxXxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.power.batteryreport.designcapacityinmilliwatthours.aspx), [**XxxxXxxxxxXxxxxxxxXxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.power.batteryreport.fullchargecapacityinmilliwatthours.aspx), xxx [**XxxxxxxxxXxxxxxxxXxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.remainingcapacityinmilliwatthours). Xxxx xxxxxxx xxxxx xxxx xx xxx xxxxxxx xxxxxx xxxxxxxxxx xxxx xx xxx xxxxx xxxxxxx xxx, xxxx'x xxxxxxxx xxxxx xx xxxx xxxxx.

```csharp
...
TextBlock txt3 = new TextBlock { Text = "Charge rate (mW): " + report.ChargeRateInMilliwatts.ToString() };
TextBlock txt4 = new TextBlock { Text = "Design energy capacity (mWh): " + report.DesignCapacityInMilliwattHours.ToString() };
TextBlock txt5 = new TextBlock { Text = "Fully-charged energy capacity (mWh): " + report.FullChargeCapacityInMilliwattHours.ToString() };
TextBlock txt6 = new TextBlock { Text = "Remaining energy capacity (mWh): " + report.RemainingCapacityInMilliwattHours.ToString() };
...
...
```

## Xxxxxxx xxxxxx xxxxxxx

Xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895004) xxxxxx xxxxxxxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) xxxxx xxxx xxxxxx, xxxxxxxx, xx xxxxxx xx xxx xxxxxxx xxxxxxx. Xxxx xxxxxxxxx xxxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxxxxxx xxx xxx xxxxx xxxxxxx. Xxxx xxxxxxx xxxxx xxx xx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxxx.

```csharp
...
Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated;
...
```

## Xxxxxx xxxxxx xxxxxxx

Xxxx x xxxxxxx xxxxxx xxxxxx, xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) xxxxx xxxxxx xxx xxxxxxxxxxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895004) xxxxxx xx xxx xxxxx xxxxxxx xxxxxx. Xxxxxxx, xxxx xxxxx xxxxxxx xx xxx xxxxxx xxxx xxx XX xxxxxx. Xxx'xx xxxx xx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208211) xxxxxx xx xxxxxx xxx XX xxxxxxx, xx xxxxx xx xxxx xxxxxxx.

```csharp
async private void AggregateBattery_ReportUpdated(Battery sender, object args)
{
    if (reportRequested)
    {

        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            // Clear UI
            BatteryReportPanel.Children.Clear();


            if (AggregateButton.IsChecked == true)
            {
                // Request aggregate battery report
                RequestAggregateBatteryReport();
            }
            else
            {
                // Request individual battery report
                RequestIndividualBatteryReports();
            }
        });
    }
}
```

## Xxxxxxx: xxxxx xxxxxxx xxx

Xxxx xxx xxxxx XXXx xx xxxxxxxx xxx xxxxxxxxx xxxxx xxxxxxx xxx xx Xxxxxxxxx Xxxxxx Xxxxxx. Xxxx xxx Xxxxxx Xxxxxx xxxxx xxxx, xxxxx **Xxx Xxxxxxx**, xxx xxxx xxxxx xxx **Xxxxxx X# &xx; Xxxxxxx &xx; Xxxxxxxxx** xxxxxxxxx, xxxxxx x xxx xxx xxxxx xxx **Xxxxx Xxx** xxxxxxxx.

Xxxx, xxxx xxx xxxx **XxxxXxxx.xxxx** xxx xxxx xxx xxxxxxxxx XXX xxxx xxxx xxxx (xxxxxxxxx xxx xxxxxxxx xxxxxxxx).

```xml
<Page
    x:Class="App1.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App1"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <StackPanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" >
        <StackPanel VerticalAlignment="Center" Margin="15,30,0,0" >
            <RadioButton x:Name="AggregateButton" Content="Aggregate results" GroupName="Type" IsChecked="True" />
            <RadioButton x:Name="IndividualButton" Content="Individual results" GroupName="Type" IsChecked="False" />
        </StackPanel>
        <StackPanel Orientation="Horizontal">
        <Button x:Name="GetBatteryReportButton" 
                Content="Get battery report" 
                Margin="15,15,0,0" 
                Click="GetBatteryReport"/>
        </StackPanel>
        <StackPanel x:Name="BatteryReportPanel" Margin="15,15,0,0"/>
    </StackPanel>
</Page>
```

Xx xxxx xxx xxx'x xxxxx **XxxY**, xxx'xx xxxx xx xxxxxxx xxx xxxxx xxxx xx xxx xxxxx xxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxXxxxxxxXxx**, xxx'x xxxxxxx `x:Class="App1.MainPage"` xxxx `x:Class="BasicBatteryApp.MainPage"`. Xxx xxxxxx xxxx xxxxxxx `xmlns:local="using:App1"` xxxx `xmlns:local="using:BasicBatteryApp"`.

Xxxx, xxxx xxxx xxxxxxx'x **XxxxXxxx.xxxx.xx** xxxx xxx xxxxxxx xxx xxxxxxxx xxxx xxxx xxx xxxxxxxxx.

```csharp
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Devices.Enumeration;
using Windows.Devices.Power;
using Windows.UI.Core;

namespace App1
{
    public sealed partial class MainPage : Page
    {
        bool reportRequested = false;
        public MainPage()
        {
            this.InitializeComponent();
            Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated;
        }


        private void GetBatteryReport(object sender, RoutedEventArgs e)
        {
            // Clear UI
            BatteryReportPanel.Children.Clear();


            if (AggregateButton.IsChecked == true)
            {
                // Request aggregate battery report
                RequestAggregateBatteryReport();
            }
            else
            {
                // Request individual battery report
                RequestIndividualBatteryReports();
            }

            // Note request
            reportRequested = true;
        }

        private void RequestAggregateBatteryReport()
        {
            // Create aggregate battery object
            var aggBattery = Battery.AggregateBattery;

            // Get report
            var report = aggBattery.GetReport();

            // Update UI
            AddReportUI(BatteryReportPanel, report, aggBattery.DeviceId);
        }

        async private void RequestIndividualBatteryReports()
        {
            // Find batteries 
            var deviceInfo = await DeviceInformation.FindAllAsync(Battery.GetDeviceSelector());
            foreach(DeviceInformation device in deviceInfo)
            {
                try
                {
                // Create battery object
                var battery = await Battery.FromIdAsync(device.Id);

                // Get report
                var report = battery.GetReport();

                // Update UI
                AddReportUI(BatteryReportPanel, report, battery.DeviceId);
                }
                catch { /* Add error handling, as applicable */ }
            }
        }


        private void AddReportUI(StackPanel sp, BatteryReport report, string DeviceID)
        {
            // Create battery report UI
            TextBlock txt1 = new TextBlock { Text = "Device ID: " + DeviceID };
            txt1.FontSize = 15;
            txt1.Margin = new Thickness(0, 15, 0, 0);
            txt1.TextWrapping = TextWrapping.WrapWholeWords;

            TextBlock txt2 = new TextBlock { Text = "Battery status: " + report.Status.ToString() };
            txt2.FontStyle = Windows.UI.Text.FontStyle.Italic;
            txt2.Margin = new Thickness(0, 0, 0, 15);

            TextBlock txt3 = new TextBlock { Text = "Charge rate (mW): " + report.ChargeRateInMilliwatts.ToString() };
            TextBlock txt4 = new TextBlock { Text = "Design energy capacity (mWh): " + report.DesignCapacityInMilliwattHours.ToString() };
            TextBlock txt5 = new TextBlock { Text = "Fully-charged energy capacity (mWh): " + report.FullChargeCapacityInMilliwattHours.ToString() };
            TextBlock txt6 = new TextBlock { Text = "Remaining energy capacity (mWh): " + report.RemainingCapacityInMilliwattHours.ToString() };

            // Create energy capacity progress bar &amp; labels
            TextBlock pbLabel = new TextBlock { Text = "Percent remaining energy capacity" };
            pbLabel.Margin = new Thickness(0,10, 0, 5);
            pbLabel.FontFamily = new FontFamily("Segoe UI");
            pbLabel.FontSize = 11;

            ProgressBar pb = new ProgressBar();
            pb.Margin = new Thickness(0, 5, 0, 0);
            pb.Width = 200;
            pb.Height = 10;
            pb.IsIndeterminate = false;
            pb.HorizontalAlignment = HorizontalAlignment.Left;

            TextBlock pbPercent = new TextBlock();
            pbPercent.Margin = new Thickness(0, 5, 0, 10);
            pbPercent.FontFamily = new FontFamily("Segoe UI");
            pbLabel.FontSize = 11;

            // Disable progress bar if values are null
            if ((report.FullChargeCapacityInMilliwattHours == null)||
                (report.RemainingCapacityInMilliwattHours == null))
            {
                pb.IsEnabled = false;
                pbPercent.Text = "N/A";
            }
            else
            {
                pb.IsEnabled = true;
                pb.Maximum = Convert.ToDouble(report.FullChargeCapacityInMilliwattHours);
                pb.Value = Convert.ToDouble(report.RemainingCapacityInMilliwattHours);
                pbPercent.Text = ((pb.Value / pb.Maximum) * 100).ToString("F2") + "%";
            }

            // Add controls to stackpanel
            sp.Children.Add(txt1);
            sp.Children.Add(txt2);
            sp.Children.Add(txt3);
            sp.Children.Add(txt4);
            sp.Children.Add(txt5);
            sp.Children.Add(txt6);
            sp.Children.Add(pbLabel);
            sp.Children.Add(pb);
            sp.Children.Add(pbPercent);
        }

        async private void AggregateBattery_ReportUpdated(Battery sender, object args)
        {
            if (reportRequested)
            {

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    // Clear UI
                    BatteryReportPanel.Children.Clear();


                    if (AggregateButton.IsChecked == true)
                    {
                        // Request aggregate battery report
                        RequestAggregateBatteryReport();
                    }
                    else
                    {
                        // Request individual battery report
                        RequestIndividualBatteryReports();
                    }
                });
            }
        }
    }
}
```

Xx xxxx xxx xxx'x xxxxx **XxxY**, xxx'xx xxxx xx xxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx x xxxxxxx xxxxx **XxxxxXxxxxxxXxx**, xxx'x xxxxxxx xxxxxxxxx `App1` xxxx xxxxxxxxx `BasicBatteryApp`.

Xxxxxxx, xx xxx xxxx xxxxx xxxxxxx xxx: xx xxx **Xxxxx** xxxx, xxxxx **Xxxxx Xxxxxxxxx** xx xxxx xxx xxxxxxxx.

**Xxx**  Xx xxxxxxx xxxxxxx xxxxxx xxxx xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn895005) xxxxxx, xxxxx xxxx xxx xx xxx **Xxxxx Xxxxxxx** xx xx xxxxxxxx **Xxxxxx** (xxxx xx x Xxxxxxx Xxxxx). Xxxx xxxxxxxxx xx x xxxxxx xxxxxxxx, xxx **XxxxxxxXxxxxx** xxxxxx xxxxxxx **xxxx** xx xxx xxxxxxxx xxx xxxx xxxxxxxxxx.

 

<!--HONumber=Mar16_HO1-->
