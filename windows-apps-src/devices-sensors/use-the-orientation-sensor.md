---
author: mukin
ms.assetid: 1889AC3A-A472-4294-89B8-A642668A8A6E
title: "方位センサーの使用"
description: "方位センサーを使ってデバイスの向きを判断する方法について説明します。"
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2a354d4e3f26d0a8ac3678d4f07d606c7cf88cc5
ms.sourcegitcommit: ca060f051e696da2c1e26e9dd4d2da3fa030103d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/03/2017
---
# <a name="use-the-orientation-sensor"></a><span data-ttu-id="a0959-104">方位センサーの使用</span><span class="sxs-lookup"><span data-stu-id="a0959-104">Use the orientation sensor</span></span>

<span data-ttu-id="a0959-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="a0959-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="a0959-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="a0959-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="a0959-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="a0959-107">Important APIs</span></span>**

-   [**<span data-ttu-id="a0959-108">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="a0959-108">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="a0959-109">OrientationSensor</span><span class="sxs-lookup"><span data-stu-id="a0959-109">OrientationSensor</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206371)
-   [**<span data-ttu-id="a0959-110">SimpleOrientation</span><span class="sxs-lookup"><span data-stu-id="a0959-110">SimpleOrientation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206399)

**<span data-ttu-id="a0959-111">サンプル</span><span class="sxs-lookup"><span data-stu-id="a0959-111">Samples</span></span>**

-   [<span data-ttu-id="a0959-112">方位センサーのサンプル</span><span class="sxs-lookup"><span data-stu-id="a0959-112">Orientation sensor sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/OrientationSensor)
-   [<span data-ttu-id="a0959-113">単純な方位センサーのサンプル</span><span class="sxs-lookup"><span data-stu-id="a0959-113">Simple orientation sensor sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleOrientationSensor)

<span data-ttu-id="a0959-114">方位センサーを使ってデバイスの向きを判断する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a0959-114">Learn how to use the orientation sensors to determine the device orientation.</span></span>

<span data-ttu-id="a0959-115">[**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) 名前空間には、[**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) と [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) の 2 種類の方位センサー API が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0959-115">There are two different types of orientation sensor APIs included in the [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) namespace: [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) and [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399).</span></span> <span data-ttu-id="a0959-116">これらのセンサーはいずれも方位センサーですが、この用語は多重定義されており、さまざまな目的に使用されます。</span><span class="sxs-lookup"><span data-stu-id="a0959-116">While both of these sensors are orientation sensors, that term is overloaded and they are used for very different purposes.</span></span> <span data-ttu-id="a0959-117">ただし、いずれも方位センサーであるため、ここではその両方について説明します。</span><span class="sxs-lookup"><span data-stu-id="a0959-117">However, since both are orientation sensors, they are both covered in this article.</span></span>

<span data-ttu-id="a0959-118">[**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) API は、3-D アプリで四元数と回転マトリックスを取得するために使われます。</span><span class="sxs-lookup"><span data-stu-id="a0959-118">The [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) API is used for 3-D apps two obtain a quaternion and a rotation matrix.</span></span> <span data-ttu-id="a0959-119">四元数は、任意の 1 つの軸を中心とした点 \[x,y,z\] の回転と考えるとわかりやすいでしょう (一方、回転マトリックスは 3 軸を中心とした回転を表します)。</span><span class="sxs-lookup"><span data-stu-id="a0959-119">A quaternion can be most easily understood as a rotation of a point \[x,y,z\] about an arbitrary axis (contrasted with a rotation matrix, which represents rotations around three axes).</span></span> <span data-ttu-id="a0959-120">四元数の演算には複素数の幾何学的特性と虚数の数学的特性が含まれ、非常に特殊ですが、四元数自体の扱いは簡単であり、DirectX などのフレームワークでもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="a0959-120">The mathematics behind quaternions is fairly exotic in that it involves the geometric properties of complex numbers and mathematical properties of imaginary numbers, but working with them is simple, and frameworks like DirectX support them.</span></span> <span data-ttu-id="a0959-121">複雑な 3D アプリでは、Orientation センサーを使ってユーザーの視点を調整する場合があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-121">A complex 3-D app can use the Orientation sensor to adjust the user's perspective.</span></span> <span data-ttu-id="a0959-122">このセンサーでは、加速度計、ジャイロメーター、コンパスからの入力が組み合わされます。</span><span class="sxs-lookup"><span data-stu-id="a0959-122">This sensor combines input from the accelerometer, gyrometer, and compass.</span></span>

<span data-ttu-id="a0959-123">[**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) API は、デバイスの現在の向き (上下が正しい縦向き、上下が逆の縦向き、左側を下にした横向き、右側を下にした横向き) を検出するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="a0959-123">The [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) API is used to determine the current device orientation in terms of definitions like portrait up, portrait down, landscape left, and landscape right.</span></span> <span data-ttu-id="a0959-124">デバイスの表向き、裏向きも検出できます。</span><span class="sxs-lookup"><span data-stu-id="a0959-124">It can also detect if a device is face-up or face-down.</span></span> <span data-ttu-id="a0959-125">このセンサーは、"上下が正しい縦向き" や "左側を下にした横向き" などのプロパティを返すのではなく、"NotRotated" や "Rotated90DegreesCounterclockwise" などの回転値を返します。</span><span class="sxs-lookup"><span data-stu-id="a0959-125">Rather than returning properties like "portrait up" or "landscape left", this sensor returns a rotation value: "Not rotated", "Rotated90DegreesCounterclockwise", and so on.</span></span> <span data-ttu-id="a0959-126">次の表に、一般的な向きのプロパティとセンサーの読み取り値との関係を示します。</span><span class="sxs-lookup"><span data-stu-id="a0959-126">The following table maps common orientation properties to the corresponding sensor reading.</span></span>

| <span data-ttu-id="a0959-127">向き</span><span class="sxs-lookup"><span data-stu-id="a0959-127">Orientation</span></span>     | <span data-ttu-id="a0959-128">対応するセンサーの読み取り値</span><span class="sxs-lookup"><span data-stu-id="a0959-128">Corresponding sensor reading</span></span>      |
|-----------------|-----------------------------------|
| <span data-ttu-id="a0959-129">上下が正しい縦向き</span><span class="sxs-lookup"><span data-stu-id="a0959-129">Portrait Up</span></span>     | <span data-ttu-id="a0959-130">NotRotated</span><span class="sxs-lookup"><span data-stu-id="a0959-130">NotRotated</span></span>                        |
| <span data-ttu-id="a0959-131">左側を下にした横向き</span><span class="sxs-lookup"><span data-stu-id="a0959-131">Landscape Left</span></span>  | <span data-ttu-id="a0959-132">Rotated90DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="a0959-132">Rotated90DegreesCounterclockwise</span></span>  |
| <span data-ttu-id="a0959-133">上下が逆の縦向き</span><span class="sxs-lookup"><span data-stu-id="a0959-133">Portrait Down</span></span>   | <span data-ttu-id="a0959-134">Rotated180DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="a0959-134">Rotated180DegreesCounterclockwise</span></span> |
| <span data-ttu-id="a0959-135">右側を下にした横向き</span><span class="sxs-lookup"><span data-stu-id="a0959-135">Landscape Right</span></span> | <span data-ttu-id="a0959-136">Rotated270DegreesCounterclockwise</span><span class="sxs-lookup"><span data-stu-id="a0959-136">Rotated270DegreesCounterclockwise</span></span> |

## <a name="prerequisites"></a><span data-ttu-id="a0959-137">前提条件</span><span class="sxs-lookup"><span data-stu-id="a0959-137">Prerequisites</span></span>

<span data-ttu-id="a0959-138">Extensible Application Markup Language (XAML)、Microsoft Visual C#、イベントについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-138">You should be familiar with Extensible Application Markup Language (XAML), Microsoft Visual C#, and events.</span></span>

<span data-ttu-id="a0959-139">使うデバイスやエミュレーターが方位センサーをサポートしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-139">The device or emulator that you're using must support a orientation sensor.</span></span>

## <a name="create-an-orientationsensor-app"></a><span data-ttu-id="a0959-140">OrientationSensor アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="a0959-140">Create an OrientationSensor app</span></span>

<span data-ttu-id="a0959-141">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="a0959-141">This section is divided into two subsections.</span></span> <span data-ttu-id="a0959-142">最初のサブセクションでは、方位センサー アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="a0959-142">The first subsection will take you through the steps necessary to create an orientation application from scratch.</span></span> <span data-ttu-id="a0959-143">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a0959-143">The following subsection explains the app you have just created.</span></span>

###  <a name="instructions"></a><span data-ttu-id="a0959-144">手順</span><span class="sxs-lookup"><span data-stu-id="a0959-144">Instructions</span></span>

-   <span data-ttu-id="a0959-145">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a0959-145">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="a0959-146">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-146">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="a0959-147">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-147">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="a0959-148">たとえば、作成したプロジェクトの名前が **OrientationSensorCS** だとすると、`namespace App1` を `namespace OrientationSensorCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-148">For example, if you created a project named **OrientationSensorCS**, you'd replace `namespace App1` with `namespace OrientationSensorCS`.</span></span>

-   <span data-ttu-id="a0959-149">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-149">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="a0959-150">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-150">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="a0959-151">たとえば、作成したプロジェクトの名前が **OrientationSensorCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="OrientationSensorCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-151">For example, if you created a project named **OrientationSensorCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="OrientationSensorCS.MainPage"`.</span></span> <span data-ttu-id="a0959-152">また、`xmlns:local="using:App1"` を `xmlns:local="using:OrientationSensorCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-152">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:OrientationSensorCS"`.</span></span>

-   <span data-ttu-id="a0959-153">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0959-153">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="a0959-154">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、方位センサーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="a0959-154">Once the app is running, you can change the orientation by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="a0959-155">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0959-155">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

###  <a name="explanation"></a><span data-ttu-id="a0959-156">説明</span><span class="sxs-lookup"><span data-stu-id="a0959-156">Explanation</span></span>

<span data-ttu-id="a0959-157">上に示した例では、ごく短いコードを作成するだけで、方位センサー入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="a0959-157">The previous example demonstrates how little code you'll need to write in order to integrate orientation-sensor input in your app.</span></span>

<span data-ttu-id="a0959-158">このアプリでは、**MainPage** メソッドで、既定の方位センサーとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="a0959-158">The app establishes a connection with the default orientation sensor in the **MainPage** method.</span></span>

```csharp
_sensor = OrientationSensor.GetDefault();
```

<span data-ttu-id="a0959-159">このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。</span><span class="sxs-lookup"><span data-stu-id="a0959-159">The app establishes the report interval within the **MainPage** method.</span></span> <span data-ttu-id="a0959-160">次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。</span><span class="sxs-lookup"><span data-stu-id="a0959-160">This code retrieves the minimum interval supported by the device and compares it to a requested interval of 16 milliseconds (which approximates a 60-Hz refresh rate).</span></span> <span data-ttu-id="a0959-161">サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。</span><span class="sxs-lookup"><span data-stu-id="a0959-161">If the minimum supported interval is greater than the requested interval, the code sets the value to the minimum.</span></span> <span data-ttu-id="a0959-162">それ以外の場合は、値を要求される間隔に設定します。</span><span class="sxs-lookup"><span data-stu-id="a0959-162">Otherwise, it sets the value to the requested interval.</span></span>

```csharp
uint minReportInterval = _sensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_sensor.ReportInterval = reportInterval;
```

<span data-ttu-id="a0959-163">**ReadingChanged** メソッドで、新しいセンサー データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="a0959-163">The new sensor data is captured in the **ReadingChanged** method.</span></span> <span data-ttu-id="a0959-164">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="a0959-164">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="a0959-165">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="a0959-165">The app registers this event handler on the following line.</span></span>

```csharp
_sensor.ReadingChanged += new TypedEventHandler<OrientationSensor,
OrientationSensorReadingChangedEventArgs>(ReadingChanged);
```

<span data-ttu-id="a0959-166">プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="a0959-166">These new values are written to the TextBlocks found in the project's XAML.</span></span>

## <a name="create-a-simpleorientation-app"></a><span data-ttu-id="a0959-167">SimpleOrientation アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="a0959-167">Create a SimpleOrientation app</span></span>

<span data-ttu-id="a0959-168">このセクションは、次の 2 つのサブセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="a0959-168">This section is divided into two subsections.</span></span> <span data-ttu-id="a0959-169">最初のサブセクションでは、シンプルな方位センサー アプリケーションを最初から作成するために必要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="a0959-169">The first subsection will take you through the steps necessary to create a simple orientation application from scratch.</span></span> <span data-ttu-id="a0959-170">次のサブセクションでは、作成したアプリについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a0959-170">The following subsection explains the app you have just created.</span></span>

### <a name="instructions"></a><span data-ttu-id="a0959-171">手順</span><span class="sxs-lookup"><span data-stu-id="a0959-171">Instructions</span></span>

-   <span data-ttu-id="a0959-172">**[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a0959-172">Create a new project, choosing a **Blank App (Universal Windows)** from the **Visual C#** project templates.</span></span>

-   <span data-ttu-id="a0959-173">プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-173">Open your project's MainPage.xaml.cs file and replace the existing code with the following.</span></span>

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

<span data-ttu-id="a0959-174">元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-174">You'll need to rename the namespace in the previous snippet with the name you gave your project.</span></span> <span data-ttu-id="a0959-175">たとえば、作成したプロジェクトの名前が **SimpleOrientationCS** だとすると、`namespace App1` を `namespace SimpleOrientationCS` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-175">For example, if you created a project named **SimpleOrientationCS**, you'd replace `namespace App1` with `namespace SimpleOrientationCS`.</span></span>

-   <span data-ttu-id="a0959-176">MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-176">Open the file MainPage.xaml and replace the original contents with the following XML.</span></span>

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

<span data-ttu-id="a0959-177">元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-177">You'll need to replace the first part of the class name in the previous snippet with the namespace of your app.</span></span> <span data-ttu-id="a0959-178">たとえば、作成したプロジェクトの名前が **SimpleOrientationCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="SimpleOrientationCS.MainPage"` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a0959-178">For example, if you created a project named **SimpleOrientationCS**, you'd replace `x:Class="App1.MainPage"` with `x:Class="SimpleOrientationCS.MainPage"`.</span></span> <span data-ttu-id="a0959-179">また、`xmlns:local="using:App1"` を `xmlns:local="using:SimpleOrientationCS"` に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0959-179">You should also replace `xmlns:local="using:App1"` with `xmlns:local="using:SimpleOrientationCS"`.</span></span>

-   <span data-ttu-id="a0959-180">アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0959-180">Press F5 or select **Debug** > **Start Debugging** to build, deploy, and run the app.</span></span>

<span data-ttu-id="a0959-181">アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、方位センサーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="a0959-181">Once the app is running, you can change the orientation by moving the device or using the emulator tools.</span></span>

-   <span data-ttu-id="a0959-182">アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0959-182">Stop the app by returning to Visual Studio and pressing Shift+F5 or select **Debug** > **Stop Debugging** to stop the app.</span></span>

### <a name="explanation"></a><span data-ttu-id="a0959-183">説明</span><span class="sxs-lookup"><span data-stu-id="a0959-183">Explanation</span></span>

<span data-ttu-id="a0959-184">上に示した例では、ごく短いコードを作成するだけで、SimpleOrientation センサー入力をアプリに組み込むことができることがわかります。</span><span class="sxs-lookup"><span data-stu-id="a0959-184">The previous example demonstrates how little code you'll need to write in order to integrate simple-orientation sensor input in your app.</span></span>

<span data-ttu-id="a0959-185">このアプリでは、**MainPage** メソッドで、既定のセンサーとの接続を確立しています。</span><span class="sxs-lookup"><span data-stu-id="a0959-185">The app establishes a connection with the default sensor in the **MainPage** method.</span></span>

```csharp
_simpleorientation = SimpleOrientationSensor.GetDefault();
```

<span data-ttu-id="a0959-186">**OrientationChanged** メソッドで、新しいセンサー データをキャプチャしています。</span><span class="sxs-lookup"><span data-stu-id="a0959-186">The new sensor data is captured in the **OrientationChanged** method.</span></span> <span data-ttu-id="a0959-187">センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。</span><span class="sxs-lookup"><span data-stu-id="a0959-187">Each time the sensor driver receives new data from the sensor, it passes the values to your app using this event handler.</span></span> <span data-ttu-id="a0959-188">このアプリの場合、このイベント ハンドラーが次の行で登録されています。</span><span class="sxs-lookup"><span data-stu-id="a0959-188">The app registers this event handler on the following line.</span></span>

```csharp
_simpleorientation.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor,
SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
```

<span data-ttu-id="a0959-189">プロジェクトの XAML 内にある TextBlock に、以下の新しい値が書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="a0959-189">These new values are written to a TextBlock found in the project's XAML.</span></span>

```csharp
<TextBlock HorizontalAlignment="Left" Height="24" Margin="8,8,0,0" TextWrapping="Wrap" Text="Current Orientation:" VerticalAlignment="Top" Width="101" Foreground="#FFF8F7F7"/>
 <TextBlock x:Name="txtOrientation" HorizontalAlignment="Left" Height="24" Margin="118,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="175" Foreground="#FFFEFAFA"/>
```