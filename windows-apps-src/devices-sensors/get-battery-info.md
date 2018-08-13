---
author: muhsinking
ms.assetid: 90BB59FC-90FE-453E-A8DE-9315E29EB98C
title: バッテリー情報の取得
description: Windows.Devices.Power 名前空間で、API を使って詳細なバッテリー情報を取得する方法について説明します。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c191a9f2da29f0ad10d0ba61507873b4fd652ddc
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "959077"
---
# <a name="get-battery-information"></a>バッテリー情報の取得


** 重要な API **

-   [**Windows.Devices.Power**](https://msdn.microsoft.com/library/windows/apps/Dn895017)
-   [**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/BR225432)

[**Windows.Devices.Power**](https://msdn.microsoft.com/library/windows/apps/Dn895017) 名前空間で、API を使って詳細なバッテリー情報を取得する方法について説明します。 *バッテリー レポート* ([**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005)) は、バッテリーの充電量、容量、状態や、バッテリーの集計を示します。 このトピックでは、アプリでバッテリー レポートを取得したり、変更に関する通知を受け取ったりする方法を紹介します。 コード例は基本的なバッテリー アプリからの抜粋で、このトピックの末尾の一覧で確認できます。

## <a name="get-aggregate-battery-report"></a>バッテリー集計レポートの取得


一部のデバイスにはバッテリーが複数あり、各バッテリーがデバイスの消費エネルギー全体にどのように関与しているのか明確でない場合があります。 [**AggregateBattery**](https://msdn.microsoft.com/library/windows/apps/Dn895011) クラスはまさにそのような用途に使います。 *バッテリー集計*レポートはデバイスに接続されたすべてのバッテリー コントローラーを表し、1 つの全体的な [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトを提供できます。

**注:** [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) クラスは、実際にはバッテリー コントローラーに対応します。 デバイスに応じて、コントローラーは物理的なバッテリーに接続されることもあれば、デバイス エンクロージャに接続されることもあります。 そのため、バッテリーがなくても、バッテリ オブジェクトを作ることができます。 また、バッテリ オブジェクトは **null** にすることもできます。

集計バッテリー オブジェクトを指定したら、[**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) を呼び出して、対応する [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) を取得します。

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

## <a name="get-individual-battery-reports"></a>個々のバッテリー レポートを取得する

個々のバッテリーに対する [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトを作ることもできます。 [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getdeviceselector.aspx) を [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/BR225432) メソッドと共に使って、デバイスに接続されているバッテリー コントローラーがあるかどうかを表す [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトのコレクションを取得します。 次に、必要な **DeviceInformation** オブジェクトの **Id** プロパティを使って、[**FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.fromidasync.aspx) メソッドを使い、対応する [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) を作ります。 最後に、[**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) を呼び出して、各バッテリー レポートを取得します。

次の例は、デバイスに接続されているすべてのバッテリーのバッテリー レポートを作る方法を示しています。

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

## <a name="access-report-details"></a>レポートの詳細にアクセスする

[**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトは、多くのバッテリー情報を提供します。 詳しくは、次のプロパティの API リファレンスをご覧ください。**Status** ([**BatteryStatus**](https://msdn.microsoft.com/library/windows/apps/Dn818458) 列挙体)、[**ChargeRateInMilliwatts**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.chargerateinmilliwatts.aspx)、[**DesignCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.designcapacityinmilliwatthours.aspx)、[**FullChargeCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.fullchargecapacityinmilliwatthours.aspx)、および [**RemainingCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.remainingcapacityinmilliwatthours)。 次の例は、基本的なバッテリー アプリで使用される一部のバッテリー レポート プロパティを示しています。このプロパティについては、このトピックで後ほど説明します。

```csharp
...
TextBlock txt3 = new TextBlock { Text = "Charge rate (mW): " + report.ChargeRateInMilliwatts.ToString() };
TextBlock txt4 = new TextBlock { Text = "Design energy capacity (mWh): " + report.DesignCapacityInMilliwattHours.ToString() };
TextBlock txt5 = new TextBlock { Text = "Fully-charged energy capacity (mWh): " + report.FullChargeCapacityInMilliwattHours.ToString() };
TextBlock txt6 = new TextBlock { Text = "Remaining energy capacity (mWh): " + report.RemainingCapacityInMilliwattHours.ToString() };
...
...
```

## <a name="request-report-updates"></a>レポートの更新を要求する

[**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) オブジェクトは、バッテリーの充電量、容量、状態が変わると [**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) イベントをトリガーします。 通常、これは、ステータスの変更についてはすぐに、その他のすべての変更については定期的に発生します。 次の例は、バッテリー レポートの更新に登録する方法を示しています。

```csharp
...
Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated;
...
```

## <a name="handle-report-updates"></a>レポートの更新を処理する

バッテリーの更新が発生すると、[**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) イベントは対応する [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) オブジェクトをイベント ハンドラー メソッドに渡します。 ただし、このイベント ハンドラーは、UI スレッドから呼び出されません。 次の例で示すように、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) オブジェクトを使って任意の UI の変更を呼び出す必要があります。

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

## <a name="example-basic-battery-app"></a>例: 基本的なバッテリー アプリ

Microsoft Visual Studio で次の基本的なバッテリー アプリをビルドすることによって、これらの API をテストします。 Visual Studio のスタート ページで **[新しいプロジェクト]** をクリックし、**[Visual C#] &gt; [Windows] &gt; [ユニバーサル]** テンプレートで **[空のアプリケーション]** テンプレートを使って新しいアプリを作ります。

次に、**MainPage.xaml** ファイルを開き、次の XML をこのファイルにコピーします (元の内容を置き換えます)。

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

自分のアプリの名前が **App1** ではない場合、元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。 たとえば、作成したプロジェクトの名前が **BasicBatteryApp** だとすると、`x:Class="App1.MainPage"` を `x:Class="BasicBatteryApp.MainPage"` に置き換えます。 また、`xmlns:local="using:App1"` を `xmlns:local="using:BasicBatteryApp"` に置き換える必要があります。

次に、プロジェクトの **MainPage.xaml.cs** ファイルを開き、記載されているコードを次のコードで置き換えます。

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

            // Create energy capacity progress bar & labels
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

自分のアプリの名前が **App1** ではない場合、元のサンプルの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。 たとえば、作成したプロジェクトの名前が **BasicBatteryApp** だとすると、`App1` 名前空間を `BasicBatteryApp` 名前空間に置き換えます。

最後に、この基本的なバッテリー アプリを実行します: **[デバッグ]** メニューで **[デバッグの開始]** をクリックしてソリューションをテストします。

**ヒント:** [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトから数値を受け取るには、**ローカル コンピューター**または (Windows Phone などの) 外部**デバイス**上のアプリをデバッグします。 デバイス エミュレーターでデバッグした場合、**BatteryReport** オブジェクトは容量や消費率のプロパティに **null** を返します。

 

