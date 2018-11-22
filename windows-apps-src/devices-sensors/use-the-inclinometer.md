---
author: muhsinking
ms.assetid: 16AD53CA-1252-456C-8567-2263D3EC95F3
title: 傾斜計の使用
description: 傾斜計を使ってピッチ、ロール、ヨーを検出する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: dd335d56fb2a01ed1b9255f974bcaacd47f623f5
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7565096"
---
# <a name="use-the-inclinometer"></a><span data-ttu-id="24af0-104">傾斜計の使用</span><span class="sxs-lookup"><span data-stu-id="24af0-104">Use the inclinometer</span></span>


**<span data-ttu-id="24af0-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="24af0-105">Important APIs</span></span>**

-   [**<span data-ttu-id="24af0-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="24af0-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="24af0-107">Inclinometer</span><span class="sxs-lookup"><span data-stu-id="24af0-107">Inclinometer</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225766)

**<span data-ttu-id="24af0-108">サンプル</span><span class="sxs-lookup"><span data-stu-id="24af0-108">Sample</span></span>**

-   <span data-ttu-id="24af0-109">より完全な実装については、[傾斜計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Inclinometer)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24af0-109">For a more complete implementation, see the [inclinometer sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Inclinometer).</span></span>

<span data-ttu-id="24af0-110">傾斜計を使ってピッチ、ロール、ヨーを検出する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="24af0-110">Learn how to use the inclinometer to determine pitch, roll, and yaw.</span></span>

<span data-ttu-id="24af0-111">一部の 3D ゲームでは、入力デバイスとして傾斜計が必要です。</span><span class="sxs-lookup"><span data-stu-id="24af0-111">Some 3-D games require an inclinometer as an input device.</span></span> <span data-ttu-id="24af0-112">よくある例としては、フライト シミュレーターがあります。傾斜計の 3 軸 (X、Y、Z) を、航空機のエレベーター、エルロン、ラダーの入力として割り当てます。</span><span class="sxs-lookup"><span data-stu-id="24af0-112">One common example is the flight simulator, which maps the three axes of the inclinometer (X, Y, and Z) to the elevator, aileron, and rudder inputs of the aircraft.</span></span>

 ## <a name="prerequisites"></a><span data-ttu-id="24af0-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="24af0-113">Prerequisites</span></span>

<span data-ttu-id="24af0-114">Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24af0-114">You should be familiar with Extensible Application Markup Language (XAML), Microsoft VisualC#, and events.</span></span>

<span data-ttu-id="24af0-115">使うデバイスやエミュレーターが傾斜計をサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="24af0-115">The device or emulator that you're using must support a inclinometer.</span></span>

 ## <a name="create-a-simple-inclinometer-app"></a><span data-ttu-id="24af0-116">シンプルな傾斜計アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="24af0-116">Create a simple inclinometer app</span></span>

<span data-ttu-id="24af0-117">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="24af0-117">This section is divided into two subsections.</span></span> <span data-ttu-id="24af0-118">最初のサブセクションでは、シンプルな傾斜計アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="24af0-118">The first subsection will take you through the steps necessary to create a simple inclinometer application from scratch.</span></span> <span data-ttu-id="24af0-119">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="24af0-119">The following subsection explains the app you have just created.</span></span>

###  <a name="instructions"></a><span data-ttu-id="24af0-120">手順</span><span class="sxs-lookup"><span data-stu-id="24af0-120">Instructions</span></span>

-   <span data-ttu-id="24af0-121">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="24af0-121">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="24af0-122">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24af0-122">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="24af0-123">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24af0-123">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="24af0-124">たとえば、作成したプロジェクトの名前が **InclinometerCS** だとすると、`namespace App1` を `namespace InclinometerCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24af0-124">For example, if you created a project named **InclinometerCS**, you'd replace `namespace App1` with `namespace InclinometerCS`.</span></span>

-   <span data-ttu-id="24af0-125">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24af0-125">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="24af0-126">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="24af0-126">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="24af0-127">たとえば、作成したプロジェクトの名前が **InclinometerCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="InclinometerCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24af0-127">For example, if you created a project named **InclinometerCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="InclinometerCS.MainPage"`.</span></span> <span data-ttu-id="24af0-128">また、`xmlns:local="using:App1"` を `xmlns:local="using:InclinometerCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="24af0-128">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:InclinometerCS"`.</span></span>

-   <span data-ttu-id="24af0-129">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="24af0-129">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="24af0-130">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、傾斜計の値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="24af0-130">Once the app is running, you can change the inclinometer values by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="24af0-131">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="24af0-131">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

###  <a name="explanation"></a><span data-ttu-id="24af0-132">説明</span><span class="sxs-lookup"><span data-stu-id="24af0-132">Explanation</span></span>

<span data-ttu-id="24af0-133">上に示した例では、ごく短いコードを作成するだけで、傾斜計入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="24af0-133">The previous example demonstrates how little code you'll need to write in order to integrate inclinometer input in your app.</span></span>

<span data-ttu-id="24af0-134">このアプリでは、**MainPage** メソッドで、既定の傾斜計との接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="24af0-134">The app establishes a connection with the default inclinometer in the **MainPage** method.</span></span>

```csharp
_inclinometer = Inclinometer.GetDefault();
```

<span data-ttu-id="24af0-135">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="24af0-135">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="24af0-136">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="24af0-136">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="24af0-137">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="24af0-137">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="24af0-138">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="24af0-138">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _inclinometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_inclinometer.ReportInterval = reportInterval;
```

<span data-ttu-id="24af0-139">**ReadingChanged** メソッドで、新しい傾斜計のデータをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="24af0-139">The new inclinometer data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="24af0-140">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="24af0-140">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="24af0-141">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="24af0-141">The app registers this event handler on the following line.</span></span>

```csharp
_inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer,
InclinometerReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="24af0-142">プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="24af0-142">These new values are written to the TextBlocks found in the project's XAML.</span></span>

```xml
<TextBlock HorizontalAlignment="Left" Height="21" Margin="0,8,0,0" TextWrapping="Wrap" Text="Pitch: " VerticalAlignment="Top" Width="45" Foreground="#FFF9F4F4"/>
 <TextBlock x:Name="txtPitch" HorizontalAlignment="Left" Height="21" Margin="59,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="71" Foreground="#FFFDF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="23" Margin="0,29,0,0" TextWrapping="Wrap" Text="Roll:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F1F1"/>
 <TextBlock x:Name="txtRoll" HorizontalAlignment="Left" Height="23" Margin="59,29,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="50" Foreground="#FFFCF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="19" Margin="0,56,0,0" TextWrapping="Wrap" Text="Yaw:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F3F3"/>
 <TextBlock x:Name="txtYaw" HorizontalAlignment="Left" Height="19" Margin="55,56,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="54" Foreground="#FFF6F2F2"/>
```

