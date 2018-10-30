---
author: muhsinking
ms.assetid: B4A550E7-1639-4C9A-A229-31E22B1415E7
title: センサーの向き
description: Accelerometer、Gyrometer、Compass、Inclinometer、および OrientationSensor の各クラスのセンサー データは、基準軸によって定義されます。 これらの軸はデバイスの横長の向きで定義され、ユーザーがデバイスの向きを変えると、デバイスと共に回転します。
ms.author: mukin
ms.date: 05/24/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f3205bfa2da1b83fe2c341b1c810f155e796b804
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5758238"
---
# <a name="sensor-orientation"></a><span data-ttu-id="524b9-105">センサーの向き</span><span class="sxs-lookup"><span data-stu-id="524b9-105">Sensor orientation</span></span>


**<span data-ttu-id="524b9-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="524b9-106">Important APIs</span></span>**

-   [**<span data-ttu-id="524b9-107">Windows.Devices.Sensors</span><span class="sxs-lookup"><span data-stu-id="524b9-107">Windows.Devices.Sensors</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**<span data-ttu-id="524b9-108">Windows.Devices.Sensors.Custom</span><span class="sxs-lookup"><span data-stu-id="524b9-108">Windows.Devices.Sensors.Custom</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn895032)

<span data-ttu-id="524b9-109">[**Accelerometer**](https://msdn.microsoft.com/library/windows/apps/BR225687)、[**Gyrometer**](https://msdn.microsoft.com/library/windows/apps/BR225718)、[**Compass**](https://msdn.microsoft.com/library/windows/apps/BR225705)、[**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/BR225766)、および [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) の各クラスのセンサー データは、基準軸によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="524b9-109">Sensor data from the [**Accelerometer**](https://msdn.microsoft.com/library/windows/apps/BR225687), [**Gyrometer**](https://msdn.microsoft.com/library/windows/apps/BR225718), [**Compass**](https://msdn.microsoft.com/library/windows/apps/BR225705), [**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/BR225766), and [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) classes is defined by their reference axes.</span></span> <span data-ttu-id="524b9-110">これらの軸はデバイスの参照フレームで定義され、ユーザーがデバイスの向きを変えると、デバイスと共に回転します。</span><span class="sxs-lookup"><span data-stu-id="524b9-110">These axes are defined by the device's reference frame and rotate with the device as the user turns it.</span></span> <span data-ttu-id="524b9-111">アプリが自動回転をサポートしており、ユーザーがデバイスを回転させたときに連動して向きが変わる場合、センサー データを使う前に回転に合わせて調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="524b9-111">If your app supports automatic rotation and reorients itself to accommodate the device as the user rotates it, you must adjust your sensor data for the rotation before using it.</span></span>

## <a name="display-orientation-vs-device-orientation"></a><span data-ttu-id="524b9-112">表示の向きとデバイスの向き</span><span class="sxs-lookup"><span data-stu-id="524b9-112">Display orientation vs device orientation</span></span>

<span data-ttu-id="524b9-113">センサーの基準軸について理解するために、画面の向きとデバイスの向きを区別する必要があります。</span><span class="sxs-lookup"><span data-stu-id="524b9-113">In order to understand the reference axes for sensors, you need to distinguish display orientation from device orientation.</span></span> <span data-ttu-id="524b9-114">画面の向きはテキストの向きであり、画面上に画像が表示されます。それに対してデバイスの向きは、デバイスの実際の配置です。</span><span class="sxs-lookup"><span data-stu-id="524b9-114">Display orientation is the direction text and images are displayed on the screen whereas device orientation is the physical positioning of the device.</span></span> <span data-ttu-id="524b9-115">次の図では、デバイスとディスプレイの向きは共に**横向き**です (示されているセンサー軸は、横向き優先デバイスにのみ適用されることに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="524b9-115">In the following picture, both the device and display orientation are in **Landscape** (note that the sensor axes shown are only applicable to landscape-first devices).</span></span>

![画面とデバイスの向きが横向き](images/sensor-orientation-a.PNG)

<span data-ttu-id="524b9-117">次の図では、画面とデバイスの向きが共に **LandscapeFlipped** です。</span><span class="sxs-lookup"><span data-stu-id="524b9-117">The following picture shows both the display and device orientation in **LandscapeFlipped**.</span></span>

![画面とデバイスの向きが LandscapeFlipped](images/sensor-orientation-b.PNG)

<span data-ttu-id="524b9-119">次の図では、画面の向きが Landscape、デバイスの向きが LandscapeFlipped です。</span><span class="sxs-lookup"><span data-stu-id="524b9-119">The next picture shows the display orientation in Landscape while the device orientation is LandscapeFlipped.</span></span>

![画面の向きが Landscape、デバイスの向きが LandscapeFlipped です。](images/sensor-orientation-c.PNG)

<span data-ttu-id="524b9-121">向きの値は、[**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/Dn264258) クラスの [**GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.getforcurrentview.aspx) メソッドと [**CurrentOrientation**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.currentorientation.aspx) プロパティを使って照会することができます。</span><span class="sxs-lookup"><span data-stu-id="524b9-121">You can query the orientation values through the [**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/Dn264258) class by using the [**GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.getforcurrentview.aspx) method with the [**CurrentOrientation**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.currentorientation.aspx) property.</span></span> <span data-ttu-id="524b9-122">次に、[**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/BR226142) 列挙値と比較することによってロジックを作成できます。</span><span class="sxs-lookup"><span data-stu-id="524b9-122">Then you can create logic by comparing against the [**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/BR226142) enumeration.</span></span> <span data-ttu-id="524b9-123">サポートするすべての向きについて、その向きへの基準軸の変換をサポートする必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="524b9-123">Remember that for every orientation you support, you have to support a conversion of the reference axes to that orientation.</span></span>

## <a name="landscape-first-vs-portrait-first-devices"></a><span data-ttu-id="524b9-124">横向き優先デバイスと縦向き優先デバイス</span><span class="sxs-lookup"><span data-stu-id="524b9-124">Landscape-first vs portrait-first devices</span></span>

<span data-ttu-id="524b9-125">製造元は、横向き優先および縦向き優先のいずれのデバイスも製造します。</span><span class="sxs-lookup"><span data-stu-id="524b9-125">Manufacturers produce both landscape-first and portrait-first devices.</span></span> <span data-ttu-id="524b9-126">参照フレームは、横向き優先デバイス (デスクトップやノート PC など) と縦向き優先デバイス (電話や一部のタブレットなど) によって異なります。</span><span class="sxs-lookup"><span data-stu-id="524b9-126">The reference frame varies between landscape-first devices (like desktops and laptops) and portrait-first devices (like phones and some tablets).</span></span> <span data-ttu-id="524b9-127">次の表は、横向き優先デバイスと縦向き優先デバイスの両方のセンサー軸を示しています。</span><span class="sxs-lookup"><span data-stu-id="524b9-127">The following table shows the sensor axes for both landscape-first and portrait-first devices.</span></span>

| <span data-ttu-id="524b9-128">方向</span><span class="sxs-lookup"><span data-stu-id="524b9-128">Orientation</span></span> | <span data-ttu-id="524b9-129">横向き優先</span><span class="sxs-lookup"><span data-stu-id="524b9-129">Landscape-first</span></span> | <span data-ttu-id="524b9-130">縦向き優先</span><span class="sxs-lookup"><span data-stu-id="524b9-130">Portrait-first</span></span> |
|-------------|-----------------|----------------|
| **<span data-ttu-id="524b9-131">横向き</span><span class="sxs-lookup"><span data-stu-id="524b9-131">Landscape</span></span>** | ![Landscape の向きの横向き優先デバイス](images/sensor-orientation-0.PNG) | ![Landscape の向きの縦向き優先デバイス](images/sensor-orientation-1.PNG) |
| **<span data-ttu-id="524b9-134">縦向き</span><span class="sxs-lookup"><span data-stu-id="524b9-134">Portrait</span></span>** | ![Portrait の向きの横向き優先デバイス](images/sensor-orientation-2.PNG) | ![Portrait の向きの縦向き優先デバイス](images/sensor-orientation-3.PNG) |
| **<span data-ttu-id="524b9-137">LandscapeFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-137">LandscapeFlipped</span></span>** | ![LandscapeFlipped の向きの横向き優先デバイス](images/sensor-orientation-4.PNG) | ![LandscapeFlipped の向きの縦向き優先デバイス](images/sensor-orientation-5.PNG) | 
| **<span data-ttu-id="524b9-140">PortraitFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-140">PortraitFlipped</span></span>** | ![PortraitFlipped の向きの横向き優先デバイス](images/sensor-orientation-6.PNG)| ![PortraitFlipped の向きの縦向き優先デバイス](images/sensor-orientation-7.PNG) |

## <a name="devices-broadcasting-display-and-headless-devices"></a><span data-ttu-id="524b9-143">ディスプレイをブロードキャストするデバイスとヘッドレス デバイス</span><span class="sxs-lookup"><span data-stu-id="524b9-143">Devices broadcasting display and headless devices</span></span>

<span data-ttu-id="524b9-144">一部のデバイスは、別のデバイスにディスプレイをブロードキャストする機能を備えています。</span><span class="sxs-lookup"><span data-stu-id="524b9-144">Some devices have the ability to broadcast the display to another device.</span></span> <span data-ttu-id="524b9-145">たとえば、タブレットで、プロジェクターにディスプレイを横方向にブロードキャストできます。</span><span class="sxs-lookup"><span data-stu-id="524b9-145">For example, you could take a tablet and broadcast the display to a projector that will be in landscape orientation.</span></span> <span data-ttu-id="524b9-146">このシナリオでは、デバイスの向きが、ディスプレイを表示しているものではなく、元のデバイスに基づいていることに留意することが重要です。</span><span class="sxs-lookup"><span data-stu-id="524b9-146">In this scenario, it is important to keep in mind that the device orientation is based on the original device, not the one presenting the display.</span></span> <span data-ttu-id="524b9-147">したがって、加速度計は、タブレットのデータを報告します。</span><span class="sxs-lookup"><span data-stu-id="524b9-147">So an accelerometer would report data for the tablet.</span></span>

<span data-ttu-id="524b9-148">さらに、一部のデバイスにはディスプレイがありません。</span><span class="sxs-lookup"><span data-stu-id="524b9-148">Furthermore, some devices do not have a display.</span></span> <span data-ttu-id="524b9-149">これらのデバイスでは、デバイスの既定の向きは縦です。</span><span class="sxs-lookup"><span data-stu-id="524b9-149">With these devices, the default orientation for these devices is portrait.</span></span>

## <a name="display-orientation-and-compass-heading"></a><span data-ttu-id="524b9-150">表示と向きとコンパスの方位</span><span class="sxs-lookup"><span data-stu-id="524b9-150">Display orientation and compass heading</span></span>


<span data-ttu-id="524b9-151">コンパスの方位は基準軸に依存するため、デバイスの向きと共に変化します。</span><span class="sxs-lookup"><span data-stu-id="524b9-151">Compass heading depends upon the reference axes and so it changes with the device orientation.</span></span> <span data-ttu-id="524b9-152">次の表に基づいて補正します (ユーザーが北を向いていると仮定します)。</span><span class="sxs-lookup"><span data-stu-id="524b9-152">You compensate based on the this table (assume the user is facing north).</span></span>

| <span data-ttu-id="524b9-153">表示の向き</span><span class="sxs-lookup"><span data-stu-id="524b9-153">Display orientation</span></span> | <span data-ttu-id="524b9-154">コンパスの方位の基準軸</span><span class="sxs-lookup"><span data-stu-id="524b9-154">Reference axis for compass heading</span></span> | <span data-ttu-id="524b9-155">北を向いている場合の API によるコンパスの方位 (横向き優先)</span><span class="sxs-lookup"><span data-stu-id="524b9-155">API compass heading when facing north (landscape-first)</span></span> | <span data-ttu-id="524b9-156">北を向いている場合の API によるコンパスの方位 (縦向き優先)</span><span class="sxs-lookup"><span data-stu-id="524b9-156">API compass heading when facing north (portrait-first)</span></span> |<span data-ttu-id="524b9-157">コンパスの方位の補正 (横向き優先)</span><span class="sxs-lookup"><span data-stu-id="524b9-157">Compass heading compensation (landscape-first)</span></span> | <span data-ttu-id="524b9-158">コンパスの方位の補正 (縦向き優先)</span><span class="sxs-lookup"><span data-stu-id="524b9-158">Compass heading compensation (portrait-first)</span></span> |
|---------------------|------------------------------------|---------------------------------------------------------|--------------------------------------------------------|------------------------------------------------|-----------------------------------------------|
| <span data-ttu-id="524b9-159">横向き</span><span class="sxs-lookup"><span data-stu-id="524b9-159">Landscape</span></span>           | <span data-ttu-id="524b9-160">-Z</span><span class="sxs-lookup"><span data-stu-id="524b9-160">-Z</span></span> | <span data-ttu-id="524b9-161">0</span><span class="sxs-lookup"><span data-stu-id="524b9-161">0</span></span>   | <span data-ttu-id="524b9-162">270</span><span class="sxs-lookup"><span data-stu-id="524b9-162">270</span></span> | <span data-ttu-id="524b9-163">見出し</span><span class="sxs-lookup"><span data-stu-id="524b9-163">Heading</span></span>               | <span data-ttu-id="524b9-164">(方位 + 90) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-164">(Heading + 90) % 360</span></span>  |
| <span data-ttu-id="524b9-165">縦向き</span><span class="sxs-lookup"><span data-stu-id="524b9-165">Portrait</span></span>            |  <span data-ttu-id="524b9-166">Y</span><span class="sxs-lookup"><span data-stu-id="524b9-166">Y</span></span> | <span data-ttu-id="524b9-167">90</span><span class="sxs-lookup"><span data-stu-id="524b9-167">90</span></span>  | <span data-ttu-id="524b9-168">0</span><span class="sxs-lookup"><span data-stu-id="524b9-168">0</span></span>   | <span data-ttu-id="524b9-169">(方位 + 270) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-169">(Heading + 270) % 360</span></span> |  <span data-ttu-id="524b9-170">見出し</span><span class="sxs-lookup"><span data-stu-id="524b9-170">Heading</span></span>              |
| <span data-ttu-id="524b9-171">LandscapeFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-171">LandscapeFlipped</span></span>    |  <span data-ttu-id="524b9-172">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-172">Z</span></span> | <span data-ttu-id="524b9-173">180</span><span class="sxs-lookup"><span data-stu-id="524b9-173">180</span></span> | <span data-ttu-id="524b9-174">90</span><span class="sxs-lookup"><span data-stu-id="524b9-174">90</span></span>  | <span data-ttu-id="524b9-175">(方位 + 180) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-175">(Heading + 180) % 360</span></span> | <span data-ttu-id="524b9-176">(方位 + 270) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-176">(Heading + 270) % 360</span></span> |
| <span data-ttu-id="524b9-177">PortraitFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-177">PortraitFlipped</span></span>     |  <span data-ttu-id="524b9-178">Y</span><span class="sxs-lookup"><span data-stu-id="524b9-178">Y</span></span> | <span data-ttu-id="524b9-179">270</span><span class="sxs-lookup"><span data-stu-id="524b9-179">270</span></span> | <span data-ttu-id="524b9-180">180</span><span class="sxs-lookup"><span data-stu-id="524b9-180">180</span></span> | <span data-ttu-id="524b9-181">(方位 + 90) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-181">(Heading + 90) % 360</span></span>  | <span data-ttu-id="524b9-182">(方位 + 180) % 360</span><span class="sxs-lookup"><span data-stu-id="524b9-182">(Heading + 180) % 360</span></span> |

<span data-ttu-id="524b9-183">正確に方位を表示するために、表に示されているようにコンパスの方位を修正します。</span><span class="sxs-lookup"><span data-stu-id="524b9-183">Modify the compass heading as shown in the table in order to correctly display the heading.</span></span> <span data-ttu-id="524b9-184">次のコード スニペットは、この方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="524b9-184">The following code snippet demonstrates how to do this.</span></span>

```csharp
private void ReadingChanged(object sender, CompassReadingChangedEventArgs e)
{
    double heading = e.Reading.HeadingMagneticNorth;        
    double displayOffset;
    
    // Calculate the compass heading offset based on
    // the current display orientation.
    DisplayInformation displayInfo = DisplayInformation.GetForCurrentView();
    
    switch (displayInfo.CurrentOrientation) 
    { 
        case DisplayOrientations.Landscape: 
            displayOffset = 0; 
            break;
        case DisplayOrientations.Portrait: 
            displayOffset = 270; 
            break; 
        case DisplayOrientations.LandscapeFlipped: 
            displayOffset = 180; 
            break; 
        case DisplayOrientations.PortraitFlipped: 
            displayOffset = 90; 
            break; 
     } 
    

    double displayCompensatedHeading = (heading + displayOffset) % 360;
    
    // Update the UI...
}
```

## <a name="display-orientation-with-the-accelerometer-and-gyrometer"></a><span data-ttu-id="524b9-185">加速度計とジャイロメーターでの表示の向き</span><span class="sxs-lookup"><span data-stu-id="524b9-185">Display orientation with the accelerometer and gyrometer</span></span>

<span data-ttu-id="524b9-186">表示の向きに合わせた加速度計とジャイロメーターのデータの変換を、次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="524b9-186">This table converts accelerometer and gyrometer data for display orientation.</span></span>

| <span data-ttu-id="524b9-187">基準軸</span><span class="sxs-lookup"><span data-stu-id="524b9-187">Reference axes</span></span>        |  <span data-ttu-id="524b9-188">X</span><span class="sxs-lookup"><span data-stu-id="524b9-188">X</span></span> |  <span data-ttu-id="524b9-189">Y</span><span class="sxs-lookup"><span data-stu-id="524b9-189">Y</span></span> | <span data-ttu-id="524b9-190">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-190">Z</span></span> |
|-----------------------|----|----|---|
| **<span data-ttu-id="524b9-191">横向き</span><span class="sxs-lookup"><span data-stu-id="524b9-191">Landscape</span></span>**         |  <span data-ttu-id="524b9-192">X</span><span class="sxs-lookup"><span data-stu-id="524b9-192">X</span></span> |  <span data-ttu-id="524b9-193">Y</span><span class="sxs-lookup"><span data-stu-id="524b9-193">Y</span></span> | <span data-ttu-id="524b9-194">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-194">Z</span></span> |
| **<span data-ttu-id="524b9-195">縦向き</span><span class="sxs-lookup"><span data-stu-id="524b9-195">Portrait</span></span>**          |  <span data-ttu-id="524b9-196">Y</span><span class="sxs-lookup"><span data-stu-id="524b9-196">Y</span></span> | <span data-ttu-id="524b9-197">-X</span><span class="sxs-lookup"><span data-stu-id="524b9-197">-X</span></span> | <span data-ttu-id="524b9-198">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-198">Z</span></span> |
| **<span data-ttu-id="524b9-199">LandscapeFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-199">LandscapeFlipped</span></span>**  | <span data-ttu-id="524b9-200">-X</span><span class="sxs-lookup"><span data-stu-id="524b9-200">-X</span></span> | <span data-ttu-id="524b9-201">-Y</span><span class="sxs-lookup"><span data-stu-id="524b9-201">-Y</span></span> | <span data-ttu-id="524b9-202">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-202">Z</span></span> |
| **<span data-ttu-id="524b9-203">PortraitFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-203">PortraitFlipped</span></span>**   | <span data-ttu-id="524b9-204">-Y</span><span class="sxs-lookup"><span data-stu-id="524b9-204">-Y</span></span> |  <span data-ttu-id="524b9-205">X</span><span class="sxs-lookup"><span data-stu-id="524b9-205">X</span></span> | <span data-ttu-id="524b9-206">Z</span><span class="sxs-lookup"><span data-stu-id="524b9-206">Z</span></span> |

<span data-ttu-id="524b9-207">ジャイロメーターにこれらの変換を適用するコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="524b9-207">The following code example applies these conversions to the gyrometer.</span></span>

```csharp
private void ReadingChanged(object sender, GyrometerReadingChangedEventArgs e)
{
    double x_Axis;
    double y_Axis;
    double z_Axis;

    GyrometerReading reading = e.Reading;  
    
    // Calculate the gyrometer axes based on
    // the current display orientation.
    DisplayInformation displayInfo = DisplayInformation.GetForCurrentView();
    switch (displayInfo.CurrentOrientation) 
    { 
        case DisplayOrientations.Landscape: 
            x_Axis = reading.AngularVelocityX;
            y_Axis = reading.AngularVelocityY;
            z_Axis = reading.AngularVelocityZ;
            break;
        case DisplayOrientations.Portrait: 
            x_Axis = reading.AngularVelocityY;
            y_Axis = -1 * reading.AngularVelocityX;
            z_Axis = reading.AngularVelocityZ;
            break; 
        case DisplayOrientations.LandscapeFlipped: 
            x_Axis = -1 * reading.AngularVelocityX;
            y_Axis = -1 * reading.AngularVelocityY;
            z_Axis = reading.AngularVelocityZ;
            break; 
        case DisplayOrientations.PortraitFlipped: 
            x_Axis = -1 * reading.AngularVelocityY;
            y_Axis = reading.AngularVelocityX;
            z_Axis = reading.AngularVelocityZ;
            break; 
     } 
    
    
    // Update the UI...
}
```

## <a name="display-orientation-and-device-orientation"></a><span data-ttu-id="524b9-208">表示の向きとデバイスの向き</span><span class="sxs-lookup"><span data-stu-id="524b9-208">Display orientation and device orientation</span></span>

<span data-ttu-id="524b9-209">[**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) データは別の方法で変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="524b9-209">The [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) data must be changed in a different way.</span></span> <span data-ttu-id="524b9-210">複数の向きとして Z 軸に対する反時計回りの回転を考えてみます。この場合、ユーザーの向きを元に戻すには、回転を逆にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="524b9-210">Think of these different orientations as rotations counterclockwise to the Z axis, so we need to reverse the rotation to get back the user’s orientation.</span></span> <span data-ttu-id="524b9-211">四元数データの場合、オイラーの公式を使って、基準四元数により回転を定義できます。また、基準回転マトリックスを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="524b9-211">For quaternion data, we can use Euler’s formula to define a rotation with a reference quaternion, and we can also use a reference rotation matrix.</span></span>

![オイラーの公式](images/eulers-formula.png)

<span data-ttu-id="524b9-213">必要な相対的な向きを得るには、基準オブジェクトと絶対オブジェクトを乗算します。</span><span class="sxs-lookup"><span data-stu-id="524b9-213">To get the relative orientation you want, multiply the reference object against the absolute object.</span></span> <span data-ttu-id="524b9-214">この演算は非可換であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="524b9-214">Note that this math is not commutative.</span></span>

![基準オブジェクトと絶対オブジェクトの乗算](images/orientation-formula.png)

<span data-ttu-id="524b9-216">前の式では、センサー データによって絶対オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="524b9-216">In the preceding expression, the absolute object is returned by the sensor data.</span></span>


| <span data-ttu-id="524b9-217">表示の向き</span><span class="sxs-lookup"><span data-stu-id="524b9-217">Display orientation</span></span>  | <span data-ttu-id="524b9-218">Z 軸を中心とする反時計回りの回転</span><span class="sxs-lookup"><span data-stu-id="524b9-218">Counterclockwise rotation around Z</span></span> | <span data-ttu-id="524b9-219">基準四元数 (逆回転)</span><span class="sxs-lookup"><span data-stu-id="524b9-219">Reference quaternion (reverse rotation)</span></span> | <span data-ttu-id="524b9-220">基準回転マトリックス (逆回転)</span><span class="sxs-lookup"><span data-stu-id="524b9-220">Reference rotation matrix (reverse rotation)</span></span> | 
|----------------------|------------------------------------|-----------------------------------------|----------------------------------------------|
| **<span data-ttu-id="524b9-221">横向き</span><span class="sxs-lookup"><span data-stu-id="524b9-221">Landscape</span></span>**        | <span data-ttu-id="524b9-222">0</span><span class="sxs-lookup"><span data-stu-id="524b9-222">0</span></span>                                  | <span data-ttu-id="524b9-223">1 + 0i + 0j + 0k</span><span class="sxs-lookup"><span data-stu-id="524b9-223">1 + 0i + 0j + 0k</span></span>                        | <span data-ttu-id="524b9-224">\[1 0 0</span><span class="sxs-lookup"><span data-stu-id="524b9-224">\[1 0 0</span></span><br/> <span data-ttu-id="524b9-225">0 1 0</span><span class="sxs-lookup"><span data-stu-id="524b9-225">0 1 0</span></span><br/> <span data-ttu-id="524b9-226">0 0 1\]</span><span class="sxs-lookup"><span data-stu-id="524b9-226">0 0 1\]</span></span>               |
| **<span data-ttu-id="524b9-227">縦向き</span><span class="sxs-lookup"><span data-stu-id="524b9-227">Portrait</span></span>**         | <span data-ttu-id="524b9-228">90</span><span class="sxs-lookup"><span data-stu-id="524b9-228">90</span></span>                                 | <span data-ttu-id="524b9-229">cos(-45⁰) + (i + j + k)\*sin(-45⁰)</span><span class="sxs-lookup"><span data-stu-id="524b9-229">cos(-45⁰) + (i + j + k)\*sin(-45⁰)</span></span>       | <span data-ttu-id="524b9-230">\[0 1 0</span><span class="sxs-lookup"><span data-stu-id="524b9-230">\[0 1 0</span></span><br/><span data-ttu-id="524b9-231">-1 0 0</span><span class="sxs-lookup"><span data-stu-id="524b9-231">-1 0 0</span></span><br/><span data-ttu-id="524b9-232">0 0 1]</span><span class="sxs-lookup"><span data-stu-id="524b9-232">0 0 1]</span></span>              |
| **<span data-ttu-id="524b9-233">LandscapeFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-233">LandscapeFlipped</span></span>** | <span data-ttu-id="524b9-234">180</span><span class="sxs-lookup"><span data-stu-id="524b9-234">180</span></span>                                | <span data-ttu-id="524b9-235">0 - i - j - k</span><span class="sxs-lookup"><span data-stu-id="524b9-235">0 - i - j - k</span></span>                           | <span data-ttu-id="524b9-236">\[1 0 0</span><span class="sxs-lookup"><span data-stu-id="524b9-236">\[1 0 0</span></span><br/> <span data-ttu-id="524b9-237">0 1 0</span><span class="sxs-lookup"><span data-stu-id="524b9-237">0 1 0</span></span><br/> <span data-ttu-id="524b9-238">0 0 1]</span><span class="sxs-lookup"><span data-stu-id="524b9-238">0 0 1]</span></span>               |
| **<span data-ttu-id="524b9-239">PortraitFlipped</span><span class="sxs-lookup"><span data-stu-id="524b9-239">PortraitFlipped</span></span>**  | <span data-ttu-id="524b9-240">270</span><span class="sxs-lookup"><span data-stu-id="524b9-240">270</span></span>                                | <span data-ttu-id="524b9-241">cos(-135⁰) + (i + j + k)\*sin(-135⁰)</span><span class="sxs-lookup"><span data-stu-id="524b9-241">cos(-135⁰) + (i + j + k)\*sin(-135⁰)</span></span>     | <span data-ttu-id="524b9-242">\[0 -1 0</span><span class="sxs-lookup"><span data-stu-id="524b9-242">\[0 -1 0</span></span><br/> <span data-ttu-id="524b9-243">1  0 0</span><span class="sxs-lookup"><span data-stu-id="524b9-243">1  0 0</span></span><br/> <span data-ttu-id="524b9-244">0  0 1]</span><span class="sxs-lookup"><span data-stu-id="524b9-244">0  0 1]</span></span>             |

