---
author: muhsinking
ms.assetid: 15BAB25C-DA8C-4F13-9B8F-EA9E4270BCE9
title: 光センサーの使用
description: 環境光センサーを使って環境光の変化を検出する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e6f7f838e5640f873593ac2e08c6a9b30f5258e5
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5870748"
---
# <a name="use-the-light-sensor"></a><span data-ttu-id="8a851-104">光センサーの使用</span><span class="sxs-lookup"><span data-stu-id="8a851-104">Use the light sensor</span></span>


**<span data-ttu-id="8a851-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="8a851-105">Important APIs</span></span>**

-   [**<span data-ttu-id="8a851-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="8a851-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="8a851-107">LightSensor</span><span class="sxs-lookup"><span data-stu-id="8a851-107">LightSensor</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225790)

**<span data-ttu-id="8a851-108">サンプル</span><span class="sxs-lookup"><span data-stu-id="8a851-108">Sample</span></span>**

-   <span data-ttu-id="8a851-109">より完全な実装については、[光センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LightSensor)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8a851-109">For a more complete implementation, see the [light sensor sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LightSensor).</span></span>

<span data-ttu-id="8a851-110">環境光センサーを使って環境光の変化を検出する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="8a851-110">Learn how to use the ambient light sensor to detect changes in lighting.</span></span>

<span data-ttu-id="8a851-111">ユーザーの環境の変化に反応するアプリを作成するための環境センサーは各種存在しますが、環境光センサーはその中の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="8a851-111">An ambient light sensor is one of the several types of environmental sensors that allow apps to respond to changes in the user's environment.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8a851-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="8a851-112">Prerequisites</span></span>

<span data-ttu-id="8a851-113">Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a851-113">You should be familiar with Extensible Application Markup Language (XAML), Microsoft VisualC#, and events.</span></span>

<span data-ttu-id="8a851-114">使うデバイスやエミュレーターが環境光センサーをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a851-114">The device or emulator that you're using must support an ambient light sensor.</span></span>

## <a name="create-a-simple-light-sensor-app"></a><span data-ttu-id="8a851-115">シンプルな光センサー アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="8a851-115">Create a simple light-sensor app</span></span>

<span data-ttu-id="8a851-116">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="8a851-116">This section is divided into two subsections.</span></span> <span data-ttu-id="8a851-117">最初のサブセクションでは、シンプルな光センサー アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="8a851-117">The first subsection will take you through the steps necessary to create a simple light-sensor application from scratch.</span></span> <span data-ttu-id="8a851-118">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8a851-118">The following subsection explains the app you have just created.</span></span>

###  <a name="instructions"></a><span data-ttu-id="8a851-119">手順</span><span class="sxs-lookup"><span data-stu-id="8a851-119">Instructions</span></span>

-   <span data-ttu-id="8a851-120">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="8a851-120">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="8a851-121">プロジェクトの BlankPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8a851-121">Open your project's BlankPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="8a851-122">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a851-122">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="8a851-123">たとえば、作成したプロジェクトの名前が **LightingCS** だとすると、`namespace App1` を `namespace LightingCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8a851-123">For example, if you created a project named **LightingCS**, you'd replace `namespace App1` with `namespace LightingCS`.</span></span>

-   <span data-ttu-id="8a851-124">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8a851-124">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="8a851-125">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a851-125">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="8a851-126">たとえば、作成したプロジェクトの名前が **LightingCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="LightingCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8a851-126">For example, if you created a project named **LightingCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="LightingCS.MainPage"`.</span></span> <span data-ttu-id="8a851-127">また、`xmlns:local="using:App1"` を `xmlns:local="using:LightingCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a851-127">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:LightingCS"`.</span></span>

-   <span data-ttu-id="8a851-128">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="8a851-128">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="8a851-129">アプリを実行した後、センサーに当てる光を変更するか、エミュレーター ツールを使うことによって、光センサーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="8a851-129">Once the app is running, you can change the light sensor values by altering the light available to the sensor or using the emulator tools.</span></span>

-   <span data-ttu-id="8a851-130">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="8a851-130">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

###  <a name="explanation"></a><span data-ttu-id="8a851-131">説明</span><span class="sxs-lookup"><span data-stu-id="8a851-131">Explanation</span></span>

<span data-ttu-id="8a851-132">上に示した例では、ごく短いコードを作成するだけで、光センサー入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="8a851-132">The previous example demonstrates how little code you'll need to write in order to integrate light-sensor input in your app.</span></span>

<span data-ttu-id="8a851-133">このアプリでは、**BlankPage** メソッドで、既定のセンサーとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="8a851-133">The app establishes a connection with the default sensor in the **BlankPage** method.</span></span>

```csharp
_lightsensor = LightSensor.GetDefault(); // Get the default light sensor object
```

<span data-ttu-id="8a851-134">このアプリでは、**BlankPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="8a851-134">The app establishes the report interval within the **BlankPage** method.</span></span> <span data-ttu-id="8a851-135">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="8a851-135">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="8a851-136">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="8a851-136">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="8a851-137">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="8a851-137">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _lightsensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_lightsensor.ReportInterval = reportInterval;
```
<span data-ttu-id="8a851-138">**ReadingChanged** メソッドで、新しい光センサー データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="8a851-138">The new light-sensor data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="8a851-139">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="8a851-139">Each time the sensor driver receives new data from the sensor, it passes the value to your app using this event handler.</span></span> <span data-ttu-id="8a851-140">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="8a851-140">The app registers this event handler on the following line.</span></span>

```csharp
_lightsensor.ReadingChanged += new TypedEventHandler<LightSensor,
LightSensorReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="8a851-141">プロジェクトの XAML 内にある TextBlock に、以下の新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="8a851-141">These new values are written to a TextBlock found in the project's XAML.</span></span>

```xml
<TextBlock HorizontalAlignment="Left" Height="44" Margin="52,38,0,0" TextWrapping="Wrap" Text="LUX Reading" VerticalAlignment="Top" Width="150"/>
 <TextBlock x:Name="txtLuxValue" HorizontalAlignment="Left" Height="44" Margin="224,38,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="217"/>
```