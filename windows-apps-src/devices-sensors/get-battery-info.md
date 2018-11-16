---
author: muhsinking
ms.assetid: 90BB59FC-90FE-453E-A8DE-9315E29EB98C
title: バッテリー情報の取得
description: Windows.Devices.Power 名前空間で、API を使って詳細なバッテリー情報を取得する方法について説明します。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c745b99104495b4d0b3c60202c378285dbfdd7b6
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6978021"
---
# <a name="get-battery-information"></a><span data-ttu-id="46159-104">バッテリー情報の取得</span><span class="sxs-lookup"><span data-stu-id="46159-104">Get battery information</span></span>


<span data-ttu-id="46159-105">\*\* 重要な API \*\*</span><span class="sxs-lookup"><span data-stu-id="46159-105">\*\* Important APIs \*\*</span></span>

-   [**<span data-ttu-id="46159-106">Windows.Devices.Power</span><span class="sxs-lookup"><span data-stu-id="46159-106">Windows.Devices.Power</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn895017)
-   [**<span data-ttu-id="46159-107">DeviceInformation.FindAllAsync</span><span class="sxs-lookup"><span data-stu-id="46159-107">DeviceInformation.FindAllAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225432)

<span data-ttu-id="46159-108">[**Windows.Devices.Power**](https://msdn.microsoft.com/library/windows/apps/Dn895017) 名前空間で、API を使って詳細なバッテリー情報を取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="46159-108">Learn how to get detailed battery information using APIs in the [**Windows.Devices.Power**](https://msdn.microsoft.com/library/windows/apps/Dn895017) namespace.</span></span> <span data-ttu-id="46159-109">*バッテリー レポート* ([**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005)) は、バッテリーの充電量、容量、状態や、バッテリーの集計を示します。</span><span class="sxs-lookup"><span data-stu-id="46159-109">A *battery report* ([**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005)) describes the charge, capacity, and status of a battery or aggregate of batteries.</span></span> <span data-ttu-id="46159-110">このトピックでは、アプリでバッテリー レポートを取得したり、変更に関する通知を受け取ったりする方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="46159-110">This topic demonstrates how your app can get battery reports and be notified of changes.</span></span> <span data-ttu-id="46159-111">コード例は基本的なバッテリー アプリからの抜粋で、このトピックの末尾の一覧で確認できます。</span><span class="sxs-lookup"><span data-stu-id="46159-111">Code examples are from the basic battery app that's listed at the end of this topic.</span></span>

## <a name="get-aggregate-battery-report"></a><span data-ttu-id="46159-112">バッテリー集計レポートの取得</span><span class="sxs-lookup"><span data-stu-id="46159-112">Get aggregate battery report</span></span>


<span data-ttu-id="46159-113">一部のデバイスにはバッテリーが複数あり、各バッテリーがデバイスの消費エネルギー全体にどのように関与しているのか明確でない場合があります。</span><span class="sxs-lookup"><span data-stu-id="46159-113">Some devices have more than one battery and it's not always obvious how each battery contributes to the overall energy capacity of the device.</span></span> <span data-ttu-id="46159-114">[**AggregateBattery**](https://msdn.microsoft.com/library/windows/apps/Dn895011) クラスはまさにそのような用途に使います。</span><span class="sxs-lookup"><span data-stu-id="46159-114">This is where the [**AggregateBattery**](https://msdn.microsoft.com/library/windows/apps/Dn895011) class comes in.</span></span> <span data-ttu-id="46159-115">*バッテリー集計*レポートはデバイスに接続されたすべてのバッテリー コントローラーを表し、1 つの全体的な [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトを提供できます。</span><span class="sxs-lookup"><span data-stu-id="46159-115">The *aggregate battery* represents all battery controllers connected to the device and can provide a single overall [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) object.</span></span>

<span data-ttu-id="46159-116">**注:**[**バッテリ**](https://msdn.microsoft.com/library/windows/apps/Dn895004)クラスは、実際にはバッテリー コント ローラーに対応します。</span><span class="sxs-lookup"><span data-stu-id="46159-116">**Note**A [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) class actually corresponds to a battery controller.</span></span> <span data-ttu-id="46159-117">デバイスに応じて、コントローラーは物理的なバッテリーに接続されることもあれば、デバイス エンクロージャに接続されることもあります。</span><span class="sxs-lookup"><span data-stu-id="46159-117">Depending on the device, sometimes the controller is attached to the physical battery and sometimes it's attached to the device enclosure.</span></span> <span data-ttu-id="46159-118">そのため、バッテリーがなくても、バッテリ オブジェクトを作ることができます。</span><span class="sxs-lookup"><span data-stu-id="46159-118">Thus, it's possible to create a battery object even when no batteries are present.</span></span> <span data-ttu-id="46159-119">また、バッテリ オブジェクトは **null** にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="46159-119">Other times, the battery object may be **null**.</span></span>

<span data-ttu-id="46159-120">集計バッテリー オブジェクトを指定したら、[**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) を呼び出して、対応する [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) を取得します。</span><span class="sxs-lookup"><span data-stu-id="46159-120">Once you have an aggregate battery object, call [**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) to get the corresponding [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005).</span></span>

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

## <a name="get-individual-battery-reports"></a><span data-ttu-id="46159-121">個々のバッテリー レポートを取得する</span><span class="sxs-lookup"><span data-stu-id="46159-121">Get individual battery reports</span></span>

<span data-ttu-id="46159-122">個々のバッテリーに対する [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトを作ることもできます。</span><span class="sxs-lookup"><span data-stu-id="46159-122">You can also create a [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) object for individual batteries.</span></span> <span data-ttu-id="46159-123">[**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getdeviceselector.aspx) を [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/BR225432) メソッドと共に使って、デバイスに接続されているバッテリー コントローラーがあるかどうかを表す [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="46159-123">Use [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getdeviceselector.aspx) with the [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/BR225432) method to obtain a collection of [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) objects that represent any battery controllers that are connected to the device.</span></span> <span data-ttu-id="46159-124">次に、必要な **DeviceInformation** オブジェクトの **Id** プロパティを使って、[**FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.fromidasync.aspx) メソッドを使い、対応する [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) を作ります。</span><span class="sxs-lookup"><span data-stu-id="46159-124">Then, using the **Id** property of the desired **DeviceInformation** object, create a corresponding [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) with the [**FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.fromidasync.aspx) method.</span></span> <span data-ttu-id="46159-125">最後に、[**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) を呼び出して、各バッテリー レポートを取得します。</span><span class="sxs-lookup"><span data-stu-id="46159-125">Finally, call [**GetReport**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.getreport) to get the individual battery report.</span></span>

<span data-ttu-id="46159-126">次の例は、デバイスに接続されているすべてのバッテリーのバッテリー レポートを作る方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="46159-126">This example shows how to create a battery report for all batteries connected to the device.</span></span>

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

## <a name="access-report-details"></a><span data-ttu-id="46159-127">レポートの詳細にアクセスする</span><span class="sxs-lookup"><span data-stu-id="46159-127">Access report details</span></span>

<span data-ttu-id="46159-128">[**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) オブジェクトは、多くのバッテリー情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="46159-128">The [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) object provides a lot of battery information.</span></span> <span data-ttu-id="46159-129">詳しくは、次のプロパティの API リファレンスをご覧ください。**Status** ([**BatteryStatus**](https://msdn.microsoft.com/library/windows/apps/Dn818458) 列挙体)、[**ChargeRateInMilliwatts**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.chargerateinmilliwatts.aspx)、[**DesignCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.designcapacityinmilliwatthours.aspx)、[**FullChargeCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.fullchargecapacityinmilliwatthours.aspx)、および [**RemainingCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.remainingcapacityinmilliwatthours)。</span><span class="sxs-lookup"><span data-stu-id="46159-129">For more info, see the API reference for its properties: **Status** (a [**BatteryStatus**](https://msdn.microsoft.com/library/windows/apps/Dn818458) enumeration), [**ChargeRateInMilliwatts**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.chargerateinmilliwatts.aspx), [**DesignCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.designcapacityinmilliwatthours.aspx), [**FullChargeCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.fullchargecapacityinmilliwatthours.aspx), and [**RemainingCapacityInMilliwattHours**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.batteryreport.remainingcapacityinmilliwatthours).</span></span> <span data-ttu-id="46159-130">次の例は、基本的なバッテリー アプリで使用される一部のバッテリー レポート プロパティを示しています。このプロパティについては、このトピックで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="46159-130">This example shows some of the battery report properties used by the basic battery app, that's provided later in this topic.</span></span>

```csharp
...
TextBlock txt3 = new TextBlock { Text = "Charge rate (mW): " + report.ChargeRateInMilliwatts.ToString() };
TextBlock txt4 = new TextBlock { Text = "Design energy capacity (mWh): " + report.DesignCapacityInMilliwattHours.ToString() };
TextBlock txt5 = new TextBlock { Text = "Fully-charged energy capacity (mWh): " + report.FullChargeCapacityInMilliwattHours.ToString() };
TextBlock txt6 = new TextBlock { Text = "Remaining energy capacity (mWh): " + report.RemainingCapacityInMilliwattHours.ToString() };
...
...
```

## <a name="request-report-updates"></a><span data-ttu-id="46159-131">レポートの更新を要求する</span><span class="sxs-lookup"><span data-stu-id="46159-131">Request report updates</span></span>

<span data-ttu-id="46159-132">[**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) オブジェクトは、バッテリーの充電量、容量、状態が変わると [**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) イベントをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="46159-132">The [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) object triggers the [**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) event when charge, capacity, or status of the battery changes.</span></span> <span data-ttu-id="46159-133">通常、これは、ステータスの変更についてはすぐに、その他のすべての変更については定期的に発生します。</span><span class="sxs-lookup"><span data-stu-id="46159-133">This typically happens immediately for status changes and periodically for all other changes.</span></span> <span data-ttu-id="46159-134">次の例は、バッテリー レポートの更新に登録する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="46159-134">This example shows how to register for battery report updates.</span></span>

```csharp
...
Battery.AggregateBattery.ReportUpdated += AggregateBattery_ReportUpdated;
...
```

## <a name="handle-report-updates"></a><span data-ttu-id="46159-135">レポートの更新を処理する</span><span class="sxs-lookup"><span data-stu-id="46159-135">Handle report updates</span></span>

<span data-ttu-id="46159-136">バッテリーの更新が発生すると、[**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) イベントは対応する [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) オブジェクトをイベント ハンドラー メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="46159-136">When a battery update occurs, the [**ReportUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.devices.power.battery.reportupdated) event passes the corresponding [**Battery**](https://msdn.microsoft.com/library/windows/apps/Dn895004) object to the event handler method.</span></span> <span data-ttu-id="46159-137">ただし、このイベント ハンドラーは、UI スレッドから呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="46159-137">However, this event handler is not called from the UI thread.</span></span> <span data-ttu-id="46159-138">次の例で示すように、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) オブジェクトを使って任意の UI の変更を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="46159-138">You'll need to use the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) object to invoke any UI changes, as shown in this example.</span></span>

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

## <a name="example-basic-battery-app"></a><span data-ttu-id="46159-139">例: 基本的なバッテリー アプリ</span><span class="sxs-lookup"><span data-stu-id="46159-139">Example: basic battery app</span></span>

<span data-ttu-id="46159-140">Microsoft Visual Studio で次の基本的なバッテリー アプリをビルドすることによって、これらの API をテストします。</span><span class="sxs-lookup"><span data-stu-id="46159-140">Test out these APIs by building the following basic battery app in Microsoft Visual Studio.</span></span> <span data-ttu-id="46159-141">Visual Studio のスタート ページで **[新しいプロジェクト]** をクリックし、**[Visual C#] &gt; [Windows] &gt; [ユニバーサル]** テンプレートで **[空のアプリケーション]** テンプレートを使って新しいアプリを作ります。</span><span class="sxs-lookup"><span data-stu-id="46159-141">From the Visual Studio start page, click **New Project**, and then under the **Visual C# &gt; Windows &gt; Universal** templates, create a new app using the **Blank App** template.</span></span>

<span data-ttu-id="46159-142">次に、**MainPage.xaml** ファイルを開き、次の XML をこのファイルにコピーします (元の内容を置き換えます)。</span><span class="sxs-lookup"><span data-stu-id="46159-142">Next, open the file **MainPage.xaml** and copy the following XML into this file (replacing its original contents).</span></span>

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

<span data-ttu-id="46159-143">自分のアプリの名前が **App1** ではない場合、元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="46159-143">If your app isn't named **App1**, you'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="46159-144">たとえば、作成したプロジェクトの名前が **BasicBatteryApp** だとすると、`x:Class="App1.MainPage"` を `x:Class="BasicBatteryApp.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="46159-144">For example, if you created a project named **BasicBatteryApp**, you'd replace `x:Class="App1.MainPage"` with `x:Class="BasicBatteryApp.MainPage"`.</span></span> <span data-ttu-id="46159-145">また、`xmlns:local="using:App1"` を `xmlns:local="using:BasicBatteryApp"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="46159-145">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:BasicBatteryApp"`.</span></span>

<span data-ttu-id="46159-146">次に、プロジェクトの **MainPage.xaml.cs** ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="46159-146">Next, open your project's **MainPage.xaml.cs** file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="46159-147">自分のアプリの名前が **App1** ではない場合、元のサンプルの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46159-147">If your app isn't named **App1**, you'll need to rename the namespace in the previous example with the name you gave your project.</span></span> <span data-ttu-id="46159-148">たとえば、作成したプロジェクトの名前が **BasicBatteryApp** だとすると、`App1` 名前空間を `BasicBatteryApp` 名前空間に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="46159-148">For example, if you created a project named **BasicBatteryApp**, you'd replace namespace `App1` with namespace `BasicBatteryApp`.</span></span>

<span data-ttu-id="46159-149">最後に、この基本的なバッテリー アプリを実行します: **[デバッグ]** メニューで **[デバッグの開始]** をクリックしてソリューションをテストします。</span><span class="sxs-lookup"><span data-stu-id="46159-149">Finally, to run this basic battery app: on the **Debug** menu, click **Start Debugging** to test the solution.</span></span>

<span data-ttu-id="46159-150">**ヒント:** [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005)オブジェクトから数値を受信するには、**ローカル コンピューター**または外部**デバイス**(Windows Phone) などのアプリをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="46159-150">**Tip**To receive numeric values from the [**BatteryReport**](https://msdn.microsoft.com/library/windows/apps/Dn895005) object, debug your app on the **Local Machine** or an external **Device** (such as a Windows Phone).</span></span> <span data-ttu-id="46159-151">デバイス エミュレーターでデバッグした場合、**BatteryReport** オブジェクトは容量や消費率のプロパティに **null** を返します。</span><span class="sxs-lookup"><span data-stu-id="46159-151">When debugging on a device emulator, the **BatteryReport** object returns **null** to the capacity and rate properties.</span></span>

 

