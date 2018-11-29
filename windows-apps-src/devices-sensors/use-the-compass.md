---
ms.assetid: 5B30E32F-27E0-4656-A834-391A559AC8BC
title: コンパスの使用
description: コンパスを使って現在の方位を検出する方法を説明します。
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f8c1cc6e17d95f55cc97af7695c12b374edcaaa8
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8196234"
---
# <a name="use-the-compass"></a><span data-ttu-id="d229d-104">コンパスの使用</span><span class="sxs-lookup"><span data-stu-id="d229d-104">Use the compass</span></span>


**<span data-ttu-id="d229d-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="d229d-105">Important APIs</span></span>**

-   [**<span data-ttu-id="d229d-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="d229d-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="d229d-107">Compass</span><span class="sxs-lookup"><span data-stu-id="d229d-107">Compass</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225705)

**<span data-ttu-id="d229d-108">サンプル</span><span class="sxs-lookup"><span data-stu-id="d229d-108">Sample</span></span>**

-   <span data-ttu-id="d229d-109">より完全な実装については、[コンパスのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Compass)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d229d-109">For a more complete implementation, see the [compass sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Compass).</span></span>

<span data-ttu-id="d229d-110">コンパスを使って現在の方位を検出する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="d229d-110">Learn how to use the compass to determine the current heading.</span></span>

<span data-ttu-id="d229d-111">磁北または真北を基準とした現在の方位をアプリで取得できます。</span><span class="sxs-lookup"><span data-stu-id="d229d-111">An app can retrieve the current heading with respect to magnetic, or true, north.</span></span> <span data-ttu-id="d229d-112">ナビゲーション アプリでは、コンパスを使ってデバイスが向いている方位を検出し、それに応じて地図の向きを設定します。</span><span class="sxs-lookup"><span data-stu-id="d229d-112">Navigation apps use the compass to determine the direction a device is facing and then orient the map accordingly.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d229d-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="d229d-113">Prerequisites</span></span>

<span data-ttu-id="d229d-114">Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d229d-114">You should be familiar with Extensible Application Markup Language (XAML), Microsoft VisualC#, and events.</span></span>

<span data-ttu-id="d229d-115">使うデバイスやエミュレーターがコンパスをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="d229d-115">The device or emulator that you're using must support a compass.</span></span>

## <a name="create-a-simple-compass-app"></a><span data-ttu-id="d229d-116">シンプルなコンパス アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="d229d-116">Create a simple compass app</span></span>

<span data-ttu-id="d229d-117">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="d229d-117">This section is divided into two subsections.</span></span> <span data-ttu-id="d229d-118">最初のサブセクションでは、シンプルなコンパス アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="d229d-118">The first subsection will take you through the steps necessary to create a simple compass application from scratch.</span></span> <span data-ttu-id="d229d-119">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d229d-119">The following subsection explains the app you have just created.</span></span>

### <a name="instructions"></a><span data-ttu-id="d229d-120">手順</span><span class="sxs-lookup"><span data-stu-id="d229d-120">Instructions</span></span>

-   <span data-ttu-id="d229d-121">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d229d-121">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="d229d-122">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d229d-122">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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
    using Windows.Devices.Sensors; // Required to access the sensor platform and the compass


    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Compass _compass; // Our app' s compass object

            // This event handler writes the current compass reading to
            // the textblocks on the app' s main page.

            private async void ReadingChanged(object sender, CompassReadingChangedEventArgs e)
            {
               await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    CompassReading reading = e.Reading;
                    txtMagnetic.Text = String.Format("{0,5:0.00}", reading.HeadingMagneticNorth);
                    if (reading.HeadingTrueNorth.HasValue)
                        txtNorth.Text = String.Format("{0,5:0.00}", reading.HeadingTrueNorth);
                    else
                        txtNorth.Text = "No reading.";
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
               _compass = Compass.GetDefault(); // Get the default compass object

                // Assign an event handler for the compass reading-changed event
                if (_compass != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _compass.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _compass.ReportInterval = reportInterval;
                    _compass.ReadingChanged += new TypedEventHandler<Compass, CompassReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }
    }
    ```

You'll need to rename the namespace in the previous snippet with the name you gave your project. For example, if you created a project named **CompassCS**, you'd replace `namespace App1` with `namespace CompassCS`.

-   Open the file MainPage.xaml and replace the original contents with the following XML.

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
            <TextBlock HorizontalAlignment="Left" Height="22" Margin="8,18,0,0" TextWrapping="Wrap" Text="Magnetic Heading:" VerticalAlignment="Top" Width="104" Foreground="#FFFBF9F9"/>
            <TextBlock HorizontalAlignment="Left" Height="18" Margin="8,58,0,0" TextWrapping="Wrap" Text="True North Heading:" VerticalAlignment="Top" Width="104" Foreground="#FFF3F3F3"/>
            <TextBlock x:Name="txtMagnetic" HorizontalAlignment="Left" Height="22" Margin="130,18,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="116" Foreground="#FFFBF6F6"/>
            <TextBlock x:Name="txtNorth" HorizontalAlignment="Left" Height="18" Margin="130,58,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="116" Foreground="#FFF5F1F1"/>

         </Grid>
    </Page>
```

<span data-ttu-id="d229d-123">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="d229d-123">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="d229d-124">たとえば、作成したプロジェクトの名前が **CompassCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="CompassCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d229d-124">For example, if you created a project named **CompassCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="CompassCS.MainPage"`.</span></span> <span data-ttu-id="d229d-125">また、`xmlns:local="using:App1"` を `xmlns:local="using:CompassCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="d229d-125">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:CompassCS"`.</span></span>

-   <span data-ttu-id="d229d-126">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="d229d-126">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="d229d-127">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、コンパスの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="d229d-127">Once the app is running, you can change the compass values by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="d229d-128">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="d229d-128">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

### <a name="explanation"></a><span data-ttu-id="d229d-129">説明</span><span class="sxs-lookup"><span data-stu-id="d229d-129">Explanation</span></span>

<span data-ttu-id="d229d-130">上に示した例では、ごく短いコードを作成するだけで、コンパス入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="d229d-130">The previous example demonstrates how little code you'll need to write in order to integrate compass input in your app.</span></span>

<span data-ttu-id="d229d-131">このアプリでは、**MainPage** メソッドで、既定のコンパスとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="d229d-131">The app establishes a connection with the default compass in the **MainPage** method.</span></span>

```csharp
_compass = Compass.GetDefault(); // Get the default compass object
```

<span data-ttu-id="d229d-132">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="d229d-132">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="d229d-133">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="d229d-133">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="d229d-134">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="d229d-134">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="d229d-135">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="d229d-135">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _compass.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_compass.ReportInterval = reportInterval;
```

<span data-ttu-id="d229d-136">**ReadingChanged** メソッドで、新しいコンパス データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="d229d-136">The new compass data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="d229d-137">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="d229d-137">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="d229d-138">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="d229d-138">The app registers this event handler on the following line.</span></span>

```csharp
_compass.ReadingChanged += new TypedEventHandler<Compass,
CompassReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="d229d-139">プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="d229d-139">These new values are written to the TextBlocks found in the project's XAML.</span></span>

```xml
 <TextBlock HorizontalAlignment="Left" Height="22" Margin="8,18,0,0" TextWrapping="Wrap" Text="Magnetic Heading:" VerticalAlignment="Top" Width="104" Foreground="#FFFBF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="18" Margin="8,58,0,0" TextWrapping="Wrap" Text="True North Heading:" VerticalAlignment="Top" Width="104" Foreground="#FFF3F3F3"/>
 <TextBlock x:Name="txtMagnetic" HorizontalAlignment="Left" Height="22" Margin="130,18,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="116" Foreground="#FFFBF6F6"/>
 <TextBlock x:Name="txtNorth" HorizontalAlignment="Left" Height="18" Margin="130,58,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="116" Foreground="#FFF5F1F1"/>
```
 

 
