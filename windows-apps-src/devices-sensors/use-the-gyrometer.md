---
author: muhsinking
ms.assetid: 454953E1-DD8F-44B7-A614-7BAD8C683536
title: ジャイロメーターの使用
description: ジャイロメーターを使ってユーザーの動きの変化を検出する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 25be2cfab15378f14aed61dcaae1e7e85159f36e
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5445629"
---
# <a name="use-the-gyrometer"></a><span data-ttu-id="73455-104">ジャイロメーターの使用</span><span class="sxs-lookup"><span data-stu-id="73455-104">Use the gyrometer</span></span>


**<span data-ttu-id="73455-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="73455-105">Important APIs</span></span>**

-   [**<span data-ttu-id="73455-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="73455-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="73455-107">Gyrometer</span><span class="sxs-lookup"><span data-stu-id="73455-107">Gyrometer</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225718)

**<span data-ttu-id="73455-108">サンプル</span><span class="sxs-lookup"><span data-stu-id="73455-108">Sample</span></span>**

-   <span data-ttu-id="73455-109">より完全な実装については、[ジャイロメーターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/gyrometer)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73455-109">For a more complete implementation, see the [gyrometer sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/gyrometer).</span></span>

<span data-ttu-id="73455-110">ジャイロメーターを使ってユーザーの動きの変化を検出する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="73455-110">Learn how to use the gyrometer to detect changes in user movement.</span></span>

<span data-ttu-id="73455-111">ゲーム コントローラーとして使う場合、ジャイロメーターは加速度計の機能を補完します。</span><span class="sxs-lookup"><span data-stu-id="73455-111">Gyrometers compliment accelerometers as game controllers.</span></span> <span data-ttu-id="73455-112">加速度計で直線的な動きを計測し、ジャイロメーターで角速度、つまり回転の動きを計測します。</span><span class="sxs-lookup"><span data-stu-id="73455-112">The accelerometer can measure linear motion while the gyrometer measures angular velocity or rotational motion.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="73455-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="73455-113">Prerequisites</span></span>

<span data-ttu-id="73455-114">Extensible Application Markup Language (XAML)、Microsoft Visual C#、イベントについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="73455-114">You should be familiar with Extensible Application Markup Language (XAML), Microsoft Visual C#, and events.</span></span>

<span data-ttu-id="73455-115">使うデバイスやエミュレーターがジャイロメーターをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="73455-115">The device or emulator that you're using must support a gyrometer.</span></span>

## <a name="create-a-simple-gyrometer-app"></a><span data-ttu-id="73455-116">シンプルなジャイロメーター アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="73455-116">Create a simple gyrometer app</span></span>

<span data-ttu-id="73455-117">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="73455-117">This section is divided into two subsections.</span></span> <span data-ttu-id="73455-118">最初のサブセクションでは、シンプルなジャイロメーター アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="73455-118">The first subsection will take you through the steps necessary to create a simple gyrometer application from scratch.</span></span> <span data-ttu-id="73455-119">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="73455-119">The following subsection explains the app you have just created.</span></span>

###  <a name="instructions"></a><span data-ttu-id="73455-120">手順</span><span class="sxs-lookup"><span data-stu-id="73455-120">Instructions</span></span>

-   <span data-ttu-id="73455-121">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="73455-121">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="73455-122">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="73455-122">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="73455-123">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73455-123">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="73455-124">たとえば、作成したプロジェクトの名前が **GyrometerCS** だとすると、`namespace App1` を `namespace GyrometerCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="73455-124">For example, if you created a project named **GyrometerCS**, you'd replace `namespace App1` with `namespace GyrometerCS`.</span></span>

-   <span data-ttu-id="73455-125">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="73455-125">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="73455-126">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="73455-126">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="73455-127">たとえば、作成したプロジェクトの名前が **GyrometerCS** である場合は、`x:Class="App1.MainPage"` を `x:Class="GyrometerCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="73455-127">For example, if you created a project named **GyrometerCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="GyrometerCS.MainPage"`.</span></span> <span data-ttu-id="73455-128">また、`xmlns:local="using:App1"` を `xmlns:local="using:GyrometerCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="73455-128">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:GyrometerCS"`.</span></span>

-   <span data-ttu-id="73455-129">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="73455-129">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="73455-130">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、ジャイロメーターの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="73455-130">Once the app is running, you can change the gyrometer values by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="73455-131">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="73455-131">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

###  <a name="explanation"></a><span data-ttu-id="73455-132">説明</span><span class="sxs-lookup"><span data-stu-id="73455-132">Explanation</span></span>

<span data-ttu-id="73455-133">上に示した例では、ごく短いコードを作成するだけで、ジャイロメーター入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="73455-133">The previous example demonstrates how little code you'll need to write in order to integrate gyrometer input in your app.</span></span>

<span data-ttu-id="73455-134">このアプリでは、**MainPage** メソッドで、既定のジャイロメーターとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="73455-134">The app establishes a connection with the default gyrometer in the **MainPage** method.</span></span>

```csharp
_gyrometer = Gyrometer.GetDefault(); // Get the default gyrometer sensor object
```

<span data-ttu-id="73455-135">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="73455-135">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="73455-136">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="73455-136">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="73455-137">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="73455-137">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="73455-138">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="73455-138">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _gyrometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_gyrometer.ReportInterval = reportInterval;
```

<span data-ttu-id="73455-139">**ReadingChanged** メソッドで、新しいジャイロメーター データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="73455-139">The new gyrometer data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="73455-140">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="73455-140">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="73455-141">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="73455-141">The app registers this event handler on the following line.</span></span>

```csharp
_gyrometer.ReadingChanged += new TypedEventHandler<Gyrometer,
GyrometerReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="73455-142">プロジェクトの XAML 内にある TextBlock に、以下の新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="73455-142">These new values are written to the TextBlocks found in the project's XAML.</span></span>

```xml
        <TextBlock HorizontalAlignment="Left" Height="23" Margin="8,8,0,0" TextWrapping="Wrap" Text="X-Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFDFDFD"/>
        <TextBlock x:Name="txtXAxis" HorizontalAlignment="Left" Height="23" Margin="67,8,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="88" Foreground="#FFFDFAFA"/>
        <TextBlock HorizontalAlignment="Left" Height="20" Margin="8,52,0,0" TextWrapping="Wrap" Text="Y Axis:" VerticalAlignment="Top" Width="46" Foreground="White"/>
        <TextBlock x:Name="txtYAxis" HorizontalAlignment="Left" Height="24" Margin="54,48,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="80" Foreground="#FFFBFBFB"/>
        <TextBlock HorizontalAlignment="Left" Height="21" Margin="8,93,0,0" TextWrapping="Wrap" Text="Z Axis:" VerticalAlignment="Top" Width="46" Foreground="#FFFEFBFB"/>
        <TextBlock x:Name="txtZAxis" HorizontalAlignment="Left" Height="21" Margin="54,93,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="63" Foreground="#FFF8F3F3"/>
```

 ## <a name="related-topics"></a><span data-ttu-id="73455-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="73455-143">Related topics</span></span>

* [<span data-ttu-id="73455-144">ジャイロメーター センサーのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="73455-144">Gyrometer Sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=241379)
