---
author: muhsinking
ms.assetid: 1889AC3A-A472-4294-89B8-A642668A8A6E
title: 方位センサーの使用
description: 方位センサーを使ってデバイスの向きを判断する方法について説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d9a9270ba675b0797344d3370aec433de90d80d5
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "958887"
---
# <a name="use-the-orientation-sensor"></a><span data-ttu-id="64bce-104">方位センサーの使用</span><span class="sxs-lookup"><span data-stu-id="64bce-104">Use the orientation sensor</span></span>


**<span data-ttu-id="64bce-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="64bce-105">Important APIs</span></span>**

-   [**<span data-ttu-id="64bce-106">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="64bce-106">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="64bce-107">OrientationSensor</span><span class="sxs-lookup"><span data-stu-id="64bce-107">OrientationSensor</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206371)
-   [**<span data-ttu-id="64bce-108">SimpleOrientation</span><span class="sxs-lookup"><span data-stu-id="64bce-108">SimpleOrientation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206399)

**<span data-ttu-id="64bce-109">サンプル</span><span class="sxs-lookup"><span data-stu-id="64bce-109">Samples</span></span>**

-   [<span data-ttu-id="64bce-110">方位センサーのサンプル</span><span class="sxs-lookup"><span data-stu-id="64bce-110">Orientation sensor sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/OrientationSensor)
-   [<span data-ttu-id="64bce-111">単純な方位センサーのサンプル</span><span class="sxs-lookup"><span data-stu-id="64bce-111">Simple orientation sensor sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleOrientationSensor)

<span data-ttu-id="64bce-112">方位センサーを使ってデバイスの向きを判断する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="64bce-112">Learn how to use the orientation sensors to determine the device orientation.</span></span>

<span data-ttu-id="64bce-113">[**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) 名前空間には、[**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) と [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) の 2 種類の方位センサー API が含まれています。</span><span class="sxs-lookup"><span data-stu-id="64bce-113">There are two different types of orientation sensor APIs included in the [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) namespace: [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) and [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399).</span></span> <span data-ttu-id="64bce-114">これらのセンサーはいずれも方位センサーですが、この用語は多重定義されており、さまざまな目的に使用されます。</span><span class="sxs-lookup"><span data-stu-id="64bce-114">While both of these sensors are orientation sensors, that term is overloaded and they are used for very different purposes.</span></span> <span data-ttu-id="64bce-115">ただし、いずれも方位センサーであるため、ここではその両方について説明します。</span><span class="sxs-lookup"><span data-stu-id="64bce-115">However, since both are orientation sensors, they are both covered in this article.</span></span>

<span data-ttu-id="64bce-116">[**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) API は、3-D アプリで四元数と回転マトリックスを取得するために使われます。</span><span class="sxs-lookup"><span data-stu-id="64bce-116">The [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) API is used for 3-D apps two obtain a quaternion and a rotation matrix.</span></span> <span data-ttu-id="64bce-117">四元数は、任意の 1 つの軸を中心とした点 \[x,y,z\] の回転と考えるとわかりやすいでしょう (一方、回転マトリックスは 3 軸を中心とした回転を表します)。</span><span class="sxs-lookup"><span data-stu-id="64bce-117">A quaternion can be most easily understood as a rotation of a point \[x,y,z\] about an arbitrary axis (contrasted with a rotation matrix, which represents rotations around three axes).</span></span> <span data-ttu-id="64bce-118">四元数の演算には複素数の幾何学的特性と虚数の数学的特性が含まれ、非常に特殊ですが、四元数自体の扱いは簡単であり、DirectX などのフレームワークでもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="64bce-118">The mathematics behind quaternions is fairly exotic in that it involves the geometric properties of complex numbers and mathematical properties of imaginary numbers, but working with them is simple, and frameworks like DirectX support them.</span></span> <span data-ttu-id="64bce-119">複雑な 3D アプリでは、Orientation センサーを使ってユーザーの視点を調整する場合があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-119">A complex 3-D app can use the Orientation sensor to adjust the user's perspective.</span></span> <span data-ttu-id="64bce-120">このセンサーでは、加速度計、ジャイロメーター、コンパスからの入力が組み合わされます。</span><span class="sxs-lookup"><span data-stu-id="64bce-120">This sensor combines input from the accelerometer, gyrometer, and compass.</span></span>

<span data-ttu-id="64bce-121">[**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) API は、デバイスの現在の向き (上下が正しい縦向き、上下が逆の縦向き、左側を下にした横向き、右側を下にした横向き) を検出するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="64bce-121">The [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) API is used to determine the current device orientation in terms of definitions like portrait up, portrait down, landscape left, and landscape right.</span></span> <span data-ttu-id="64bce-122">デバイスの表向き、裏向きも検出できます。</span><span class="sxs-lookup"><span data-stu-id="64bce-122">It can also detect if a device is face-up or face-down.</span></span> <span data-ttu-id="64bce-123">このセンサーは、"上下が正しい縦向き" や "左側を下にした横向き" などのプロパティを返すのではなく、"NotRotated" や "Rotated90DegreesCounterclockwise" などの回転値を返します。</span><span class="sxs-lookup"><span data-stu-id="64bce-123">Rather than returning properties like "portrait up" or "landscape left", this sensor returns a rotation value: "Not rotated", "Rotated90DegreesCounterclockwise", and so on.</span></span> <span data-ttu-id="64bce-124">次の表に、一般的な向きのプロパティとセンサーの読み取り値との関係を示します。</span><span class="sxs-lookup"><span data-stu-id="64bce-124">The following table maps common orientation properties to the corresponding sensor reading.</span></span>

| <span data-ttu-id="64bce-125">向き</span><span class="sxs-lookup"><span data-stu-id="64bce-125">Orientation</span></span>     | <span data-ttu-id="64bce-126">対応するセンサーの読み取り値</span><span class="sxs-lookup"><span data-stu-id="64bce-126">Corresponding sensor reading</span></span>      |
|-----------------|-----------------------------------|
| <span data-ttu-id="64bce-127">上下が正しい縦向き</span><span class="sxs-lookup"><span data-stu-id="64bce-127">Portrait Up</span></span>     | <span data-ttu-id="64bce-128">NotRotated</span><span class="sxs-lookup"><span data-stu-id="64bce-128">NotRotated</span></span>                        |
| <span data-ttu-id="64bce-129">左側を下にした横向き</span><span class="sxs-lookup"><span data-stu-id="64bce-129">Landscape Left</span></span>  | <span data-ttu-id="64bce-130">Rotated90DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="64bce-130">Rotated90DegreesCounterclockwise</span></span>  |
| <span data-ttu-id="64bce-131">上下が逆の縦向き</span><span class="sxs-lookup"><span data-stu-id="64bce-131">Portrait Down</span></span>   | <span data-ttu-id="64bce-132">Rotated180DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="64bce-132">Rotated180DegreesCounterclockwise</span></span> |
| <span data-ttu-id="64bce-133">右側を下にした横向き</span><span class="sxs-lookup"><span data-stu-id="64bce-133">Landscape Right</span></span> | <span data-ttu-id="64bce-134">Rotated270DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="64bce-134">Rotated270DegreesCounterclockwise</span></span> |

## <a name="prerequisites"></a><span data-ttu-id="64bce-135">前提条件</span><span class="sxs-lookup"><span data-stu-id="64bce-135">Prerequisites</span></span>

<span data-ttu-id="64bce-136">Extensible Application Markup Language (XAML)、Microsoft Visual C#、イベントについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-136">You should be familiar with Extensible Application Markup Language (XAML), Microsoft Visual C#, and events.</span></span>

<span data-ttu-id="64bce-137">使うデバイスやエミュレーターが方位センサーをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-137">The device or emulator that you're using must support a orientation sensor.</span></span>

## <a name="create-an-orientationsensor-app"></a><span data-ttu-id="64bce-138">OrientationSensor アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="64bce-138">Create an OrientationSensor app</span></span>

<span data-ttu-id="64bce-139">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="64bce-139">This section is divided into two subsections.</span></span> <span data-ttu-id="64bce-140">最初のサブセクションでは、方位センサー アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="64bce-140">The first subsection will take you through the steps necessary to create an orientation application from scratch.</span></span> <span data-ttu-id="64bce-141">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="64bce-141">The following subsection explains the app you have just created.</span></span>

###  <a name="instructions"></a><span data-ttu-id="64bce-142">手順</span><span class="sxs-lookup"><span data-stu-id="64bce-142">Instructions</span></span>

-   <span data-ttu-id="64bce-143">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="64bce-143">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="64bce-144">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-144">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="64bce-145">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-145">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="64bce-146">たとえば、作成したプロジェクトの名前が **OrientationSensorCS** だとすると、`namespace App1` を `namespace OrientationSensorCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-146">For example, if you created a project named **OrientationSensorCS**, you'd replace `namespace App1` with `namespace OrientationSensorCS`.</span></span>

-   <span data-ttu-id="64bce-147">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-147">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="64bce-148">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-148">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="64bce-149">たとえば、作成したプロジェクトの名前が **OrientationSensorCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="OrientationSensorCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-149">For example, if you created a project named **OrientationSensorCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="OrientationSensorCS.MainPage"`.</span></span> <span data-ttu-id="64bce-150">また、`xmlns:local="using:App1"` を `xmlns:local="using:OrientationSensorCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-150">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:OrientationSensorCS"`.</span></span>

-   <span data-ttu-id="64bce-151">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="64bce-151">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="64bce-152">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、方位センサーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="64bce-152">Once the app is running, you can change the orientation by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="64bce-153">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="64bce-153">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

###  <a name="explanation"></a><span data-ttu-id="64bce-154">説明</span><span class="sxs-lookup"><span data-stu-id="64bce-154">Explanation</span></span>

<span data-ttu-id="64bce-155">上に示した例では、ごく短いコードを作成するだけで、方位センサー入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="64bce-155">The previous example demonstrates how little code you'll need to write in order to integrate orientation-sensor input in your app.</span></span>

<span data-ttu-id="64bce-156">このアプリでは、**MainPage** メソッドで、既定の方位センサーとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="64bce-156">The app establishes a connection with the default orientation sensor in the **MainPage** method.</span></span>

```csharp
_sensor = OrientationSensor.GetDefault();
```

<span data-ttu-id="64bce-157">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="64bce-157">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="64bce-158">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="64bce-158">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="64bce-159">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="64bce-159">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="64bce-160">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="64bce-160">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _sensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_sensor.ReportInterval = reportInterval;
```

<span data-ttu-id="64bce-161">**ReadingChanged** メソッドで、新しいセンサー データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="64bce-161">The new sensor data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="64bce-162">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="64bce-162">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="64bce-163">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="64bce-163">The app registers this event handler on the following line.</span></span>

```csharp
_sensor.ReadingChanged += new TypedEventHandler<OrientationSensor,
OrientationSensorReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="64bce-164">プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="64bce-164">These new values are written to the TextBlocks found in the project's XAML.</span></span>

## <a name="create-a-simpleorientation-app"></a><span data-ttu-id="64bce-165">SimpleOrientation アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="64bce-165">Create a SimpleOrientation app</span></span>

<span data-ttu-id="64bce-166">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="64bce-166">This section is divided into two subsections.</span></span> <span data-ttu-id="64bce-167">最初のサブセクションでは、シンプルな方位センサー アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="64bce-167">The first subsection will take you through the steps necessary to create a simple orientation application from scratch.</span></span> <span data-ttu-id="64bce-168">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="64bce-168">The following subsection explains the app you have just created.</span></span>

### <a name="instructions"></a><span data-ttu-id="64bce-169">手順</span><span class="sxs-lookup"><span data-stu-id="64bce-169">Instructions</span></span>

-   <span data-ttu-id="64bce-170">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="64bce-170">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="64bce-171">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-171">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="64bce-172">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-172">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="64bce-173">たとえば、作成したプロジェクトの名前が **SimpleOrientationCS** だとすると、`namespace App1` を `namespace SimpleOrientationCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-173">For example, if you created a project named **SimpleOrientationCS**, you'd replace `namespace App1` with `namespace SimpleOrientationCS`.</span></span>

-   <span data-ttu-id="64bce-174">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-174">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="64bce-175">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-175">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="64bce-176">たとえば、作成したプロジェクトの名前が **SimpleOrientationCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="SimpleOrientationCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="64bce-176">For example, if you created a project named **SimpleOrientationCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="SimpleOrientationCS.MainPage"`.</span></span> <span data-ttu-id="64bce-177">また、`xmlns:local="using:App1"` を `xmlns:local="using:SimpleOrientationCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="64bce-177">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:SimpleOrientationCS"`.</span></span>

-   <span data-ttu-id="64bce-178">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="64bce-178">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="64bce-179">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、方位センサーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="64bce-179">Once the app is running, you can change the orientation by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="64bce-180">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="64bce-180">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

### <a name="explanation"></a><span data-ttu-id="64bce-181">説明</span><span class="sxs-lookup"><span data-stu-id="64bce-181">Explanation</span></span>

<span data-ttu-id="64bce-182">上に示した例では、ごく短いコードを作成するだけで、SimpleOrientation センサー入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="64bce-182">The previous example demonstrates how little code you'll need to write in order to integrate simple-orientation sensor input in your app.</span></span>

<span data-ttu-id="64bce-183">このアプリでは、**MainPage** メソッドで、既定のセンサーとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="64bce-183">The app establishes a connection with the default sensor in the **MainPage** method.</span></span>

```csharp
_simpleorientation = SimpleOrientationSensor.GetDefault();
```

<span data-ttu-id="64bce-184">**OrientationChanged** メソッドで、新しいセンサー データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="64bce-184">The new sensor data is captured in the **OrientationChanged** method.</span></span> <span data-ttu-id="64bce-185">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="64bce-185">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="64bce-186">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="64bce-186">The app registers this event handler on the following line.</span></span>

```csharp
_simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor,
SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
```

<span data-ttu-id="64bce-187">プロジェクトの XAML 内にある TextBlock に、以下の新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="64bce-187">These new values are written to a TextBlock found in the project's XAML.</span></span>

```csharp
<TextBlock HorizontalAlignment="Left" Height="24" Margin="8,8,0,0" TextWrapping="Wrap" Text="Current Orientation:" VerticalAlignment="Top" Width="101" Foreground="#FFF8F7F7"/>
 <TextBlock x:Name="txtOrientation" HorizontalAlignment="Left" Height="24" Margin="118,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="175" Foreground="#FFFEFAFA"/>
```