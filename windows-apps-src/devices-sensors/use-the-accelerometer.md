---
author: muhsinking
ms.assetid: F90686F5-641A-42D9-BC44-EC6CA11B8A42
title: 加速度計の使用
description: 加速度計を使ってユーザーの動きに応答する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 482092e43acd6999361640e598a44391ac3f11a5
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6986812"
---
# <a name="use-the-accelerometer"></a><span data-ttu-id="7de89-104">加速度計の使用</span><span class="sxs-lookup"><span data-stu-id="7de89-104">Use the accelerometer</span></span>


**<span data-ttu-id="7de89-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="7de89-105">Important APIs</span></span>**

-   [**<span data-ttu-id="7de89-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="7de89-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="7de89-107">Accelerometer</span><span class="sxs-lookup"><span data-stu-id="7de89-107">Accelerometer</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225687)

**<span data-ttu-id="7de89-108">サンプル</span><span class="sxs-lookup"><span data-stu-id="7de89-108">Sample</span></span>**

-   <span data-ttu-id="7de89-109">より完全な実装については、[加速度計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Accelerometer)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7de89-109">For a more complete implementation, see the [accelerometer sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Accelerometer).</span></span>

<span data-ttu-id="7de89-110">加速度計を使ってユーザーの動きに応答する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="7de89-110">Learn how to use the accelerometer to respond to user movement.</span></span>

<span data-ttu-id="7de89-111">シンプルなゲーム アプリでは、加速度計などの単一のセンサーを入力デバイスとして使います。</span><span class="sxs-lookup"><span data-stu-id="7de89-111">A simple game app relies on a single sensor, the accelerometer, as an input device.</span></span> <span data-ttu-id="7de89-112">このようなアプリでは、一般的に、入力として 1 軸または 2 軸のみを使いますが、もう 1 つの入力ソースとしてシェイク イベントを使う場合もあります。</span><span class="sxs-lookup"><span data-stu-id="7de89-112">These apps typically use only one or two axes for input; but they may also use the shake event as another input source.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7de89-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="7de89-113">Prerequisites</span></span>

<span data-ttu-id="7de89-114">Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7de89-114">You should be familiar with Extensible Application Markup Language (XAML), Microsoft VisualC#, and events.</span></span>

<span data-ttu-id="7de89-115">使うデバイスやエミュレーターが加速度計をサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7de89-115">The device or emulator that you're using must support an accelerometer.</span></span>

## <a name="create-a-simple-accelerometer-app"></a><span data-ttu-id="7de89-116">シンプルな加速度計アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="7de89-116">Create a simple accelerometer app</span></span>

<span data-ttu-id="7de89-117">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="7de89-117">This section is divided into two subsections.</span></span> <span data-ttu-id="7de89-118">最初のサブセクションでは、シンプルな加速度計アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="7de89-118">The first subsection will take you through the steps necessary to create a simple accelerometer application from scratch.</span></span> <span data-ttu-id="7de89-119">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7de89-119">The following subsection explains the app you have just created.</span></span>

### <a name="instructions"></a><span data-ttu-id="7de89-120">手順</span><span class="sxs-lookup"><span data-stu-id="7de89-120">Instructions</span></span>

-   <span data-ttu-id="7de89-121">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7de89-121">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="7de89-122">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7de89-122">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="7de89-123">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7de89-123">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="7de89-124">たとえば、作成したプロジェクトの名前が **AccelerometerCS** だとすると、`namespace App1` を `namespace AccelerometerCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7de89-124">For example, if you created a project named **AccelerometerCS**, you'd replace `namespace App1` with `namespace AccelerometerCS`.</span></span>

-   <span data-ttu-id="7de89-125">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7de89-125">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="7de89-126">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="7de89-126">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="7de89-127">たとえば、作成したプロジェクトの名前が **AccelerometerCS** である場合、`x:Class="App1.MainPage"` を `x:Class="AccelerometerCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7de89-127">For example, if you created a project named **AccelerometerCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="AccelerometerCS.MainPage"`.</span></span> <span data-ttu-id="7de89-128">また、`xmlns:local="using:App1"` を `xmlns:local="using:AccelerometerCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="7de89-128">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:AccelerometerCS"`.</span></span>

-   <span data-ttu-id="7de89-129">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]** &gt; **[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="7de89-129">Press F5 or select **Debug** &gt; **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="7de89-130">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、加速度計の値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="7de89-130">Once the app is running, you can change the accelerometer values by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="7de89-131">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]** &gt; **[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="7de89-131">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** &gt; **Stop Debugging** to stop the app.</span></span>

### <a name="explanation"></a><span data-ttu-id="7de89-132">説明</span><span class="sxs-lookup"><span data-stu-id="7de89-132">Explanation</span></span>

<span data-ttu-id="7de89-133">上に示した例では、ごく短いコードを作成するだけで、加速度計の入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="7de89-133">The previous example demonstrates how little code you'll need to write in order to integrate accelerometer input in your app.</span></span>

<span data-ttu-id="7de89-134">このアプリでは、**MainPage** メソッドで、既定の加速度計との接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="7de89-134">The app establishes a connection with the default accelerometer in the **MainPage** method.</span></span>

```csharp
_accelerometer = Accelerometer.GetDefault();
```

<span data-ttu-id="7de89-135">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="7de89-135">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="7de89-136">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="7de89-136">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="7de89-137">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="7de89-137">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="7de89-138">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="7de89-138">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _accelerometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_accelerometer.ReportInterval = reportInterval;
```

<span data-ttu-id="7de89-139">**ReadingChanged** メソッドで、新しい加速度計データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="7de89-139">The new accelerometer data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="7de89-140">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="7de89-140">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="7de89-141">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="7de89-141">The app registers this event handler on the following line.</span></span>

```csharp
_accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer,
AccelerometerReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="7de89-142">プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="7de89-142">These new values are written to the TextBlocks found in the project's XAML.</span></span>

```xml
<TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="15" Margin="70,16,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="61" Foreground="#FFF2F2F2"/>
 <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="15" Margin="70,49,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFF2EEEE"/>
 <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="15" Margin="70,80,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="53" Foreground="#FFFFF8F8"/>
```
