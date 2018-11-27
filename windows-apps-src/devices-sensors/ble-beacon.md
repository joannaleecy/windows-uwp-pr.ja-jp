---
title: Bluetooth アドバタイズ
description: このセクションでは、API の AdvertisementWatcher と AdvertisementPublisher を使って、ユニバーサル Windows プラットフォーム (UWP) アプリに Bluetooth 低エネルギー (LE) アドバタイズを統合する方法に関する記事を取り上げています。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: ff10bbc0-03a7-492c-b5fe-c5b9ce8ca32e
ms.localizationpriority: medium
ms.openlocfilehash: e9eafde0596ad3156f52a7a2f0a1566444a9836a
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7708482"
---
# <a name="bluetooth-le-advertisements"></a><span data-ttu-id="413af-104">Bluetooth LE アドバタイズ</span><span class="sxs-lookup"><span data-stu-id="413af-104">Bluetooth LE Advertisements</span></span>


**<span data-ttu-id="413af-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="413af-105">Important APIs</span></span>**

-   [**<span data-ttu-id="413af-106">Windows.Devices.Bluetooth.Advertisement</span><span class="sxs-lookup"><span data-stu-id="413af-106">Windows.Devices.Bluetooth.Advertisement</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.aspx)

<span data-ttu-id="413af-107">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ向けの Bluetooth 低エネルギー (LE) アドバタイズ ビーコンの概要を示します。</span><span class="sxs-lookup"><span data-stu-id="413af-107">This article provides an overview of Bluetooth Low Energy (LE) Advertisement beacons for Universal Windows Platform (UWP) apps.</span></span>  

## <a name="overview"></a><span data-ttu-id="413af-108">概要</span><span class="sxs-lookup"><span data-stu-id="413af-108">Overview</span></span>

<span data-ttu-id="413af-109">開発者が LE アドバタイズ API を使って実行できる機能には、主に次の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="413af-109">There are two main functions that a developer can perform using the LE Advertisement APIs:</span></span>

-   <span data-ttu-id="413af-110">[アドバタイズ ウォッチャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.aspx): 近くのビーコンをリッスンし、ペイロードまたは近接度に基づいてフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="413af-110">[Advertisement Watcher](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.aspx): listen for nearby beacons and filter them out based on payload or proximity.</span></span>  
-   <span data-ttu-id="413af-111">[アドバタイズ パブリッシャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher.aspx): 開発者に代わって、Windows のペイロードを定義してアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="413af-111">[Advertisement Publisher](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher.aspx): define a payload for Windows to advertise on a developers behalf.</span></span>  

<span data-ttu-id="413af-112">完全なサンプル コードについては、GitHub の [Bluetooth アドバタイズ サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619990)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="413af-112">Full sample code is found in the [Bluetooth Advertisement Sample](http://go.microsoft.com/fwlink/p/?LinkId=619990) on Github</span></span>

## <a name="basic-setup"></a><span data-ttu-id="413af-113">基本セットアップ</span><span class="sxs-lookup"><span data-stu-id="413af-113">Basic Setup</span></span>

<span data-ttu-id="413af-114">ユニバーサル Windows プラットフォーム アプリで Bluetooth LE の基本的な機能を使用するには、Package.appxmanifest で Bluetooth の機能を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="413af-114">To use basic Bluetooth LE functionality in a Universal Windows Platform app, you must check the Bluetooth capability in the Package.appxmanifest.</span></span>

1. <span data-ttu-id="413af-115">Package.appxmanifest を開きます。</span><span class="sxs-lookup"><span data-stu-id="413af-115">Open Package.appxmanifest</span></span>
2. <span data-ttu-id="413af-116">[機能] タブに移動します。</span><span class="sxs-lookup"><span data-stu-id="413af-116">Go to the Capabilities tab</span></span>
3. <span data-ttu-id="413af-117">左側の一覧で Bluetooth を見つけ、その横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="413af-117">Find Bluetooth in the list on the left and check the box next to it.</span></span>

## <a name="publishing-advertisements"></a><span data-ttu-id="413af-118">アドバタイズのパブリッシュ</span><span class="sxs-lookup"><span data-stu-id="413af-118">Publishing Advertisements</span></span>

<span data-ttu-id="413af-119">Bluetooth LE アドバタイズでは、デバイスから特定のペイロードを常時ビーコンできます。これをアドバタイズと呼びます。</span><span class="sxs-lookup"><span data-stu-id="413af-119">Bluetooth LE Advertisements allow your device to constantly beacon out a specific payload, called an advertisement.</span></span> <span data-ttu-id="413af-120">近接範囲内にあり、この特定のアドバタイズをリッスンするように設定されたすべての Bluetooth LE 対応デバイスは、このアドバタイズを認識できます。</span><span class="sxs-lookup"><span data-stu-id="413af-120">This advertisement can be seen by any nearby Bluetooth LE capable device, if they are set up to listen for this specific advertisment.</span></span>

> <span data-ttu-id="413af-121">**注**: に、アプリのユーザーのプライバシー、アドバタイズの寿命が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="413af-121">**Note**: For user privacy, the lifespan of your advertisement is tied to that of your app.</span></span> <span data-ttu-id="413af-122">BluetoothLEAdvertisementPublisher を作成し、バックグラウンド タスクで Start を呼び出して、バックグラウンドでアドバタイズを発行できます。</span><span class="sxs-lookup"><span data-stu-id="413af-122">You can create a BluetoothLEAdvertisementPublisher and call Start in a background task for advertisement in the background.</span></span> <span data-ttu-id="413af-123">バックグラウンド タスクについて詳しくは、「[起動、再開、バックグラウンド タスク](https://msdn.microsoft.com/windows/uwp/launch-resume/index)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="413af-123">For more information about background tasks, see [Launching, resuming, and background tasks](https://msdn.microsoft.com/windows/uwp/launch-resume/index).</span></span>

### <a name="basic-publishing"></a><span data-ttu-id="413af-124">基本的なパブリッシュ</span><span class="sxs-lookup"><span data-stu-id="413af-124">Basic Publishing</span></span>

<span data-ttu-id="413af-125">アドバタイズにデータを追加するには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="413af-125">There are many different ways to add data to an Advertisement.</span></span> <span data-ttu-id="413af-126">この例では、会社固有のアドバタイズを作成する一般的な方法を示します。</span><span class="sxs-lookup"><span data-stu-id="413af-126">This example shows a common way to create a company-specific advertisement.</span></span> 

<span data-ttu-id="413af-127">まず、デバイスが特定のアドバタイズをビーコンするかどうかを制御するアドバタイズ パブリッシャーを作成します。</span><span class="sxs-lookup"><span data-stu-id="413af-127">First, create the advertisement publisher that controls whether or not the device is beaconing out a specific advertisement.</span></span>

```csharp
BluetoothLEAdvertisementPublisher publisher = new BluetoothLEAdvertisementPublisher();
```

<span data-ttu-id="413af-128">次に、カスタム データ セクションを作成します。</span><span class="sxs-lookup"><span data-stu-id="413af-128">Second, create a custom data section.</span></span> <span data-ttu-id="413af-129">この例では、未割り当ての **CompanyId** 値 *0xFFFE* を使うと共に、テキスト *Hello World* をアドバタイズに追加しています。</span><span class="sxs-lookup"><span data-stu-id="413af-129">This example uses an unassigned **CompanyId** value *0xFFFE* and adds the text *Hello World* to the advertisement.</span></span> 

```csharp
// Add custom data to the advertisement
var manufacturerData = new BluetoothLEManufacturerData();
manufacturerData.CompanyId = 0xFFFE;

var writer = new DataWriter();
writer.WriteString("Hello World");

// Make sure that the buffer length can fit within an advertisement payload (~20 bytes). 
// Otherwise you will get an exception.
manufacturerData.Data = writer.DetachBuffer();

// Add the manufacturer data to the advertisement publisher:
publisher.Advertisement.ManufacturerData.Add(manufacturerData);
```

<span data-ttu-id="413af-130">これでパブリッシャーが作成され、セットアップされました。次に **Start** を呼び出してアドバタイズを開始します。</span><span class="sxs-lookup"><span data-stu-id="413af-130">Now that the publisher has been created and setup, you can call **Start** to begin advertising.</span></span>

```csharp
publisher.Start();
```

## <a name="watching-for-advertisements"></a><span data-ttu-id="413af-131">アドバタイズのウォッチ</span><span class="sxs-lookup"><span data-stu-id="413af-131">Watching for Advertisements</span></span>

### <a name="basic-watching"></a><span data-ttu-id="413af-132">基本的なウォッチ</span><span class="sxs-lookup"><span data-stu-id="413af-132">Basic Watching</span></span>

<span data-ttu-id="413af-133">次のコードは、Bluetooth LE アドバタイズ ウォッチャーを作成し、コールバックを設定して、すべての LE アドバタイズのウォッチを開始する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="413af-133">The following code demonstrates how to create a Bluetooth LE Advertisement watcher, set a callback, and start watching for all LE advertisements.</span></span>

```csharp
BluetoothLEAdvertisementWatcher watcher = new BluetoothLEAdvertisementWatcher();
watcher.Received += OnAdvertisementReceived;
watcher.Start();
``` 

```csharp
private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
{
    // Do whatever you want with the advertisement
}
```

#### <a name="active-scanning"></a><span data-ttu-id="413af-134">アクティブ スキャン</span><span class="sxs-lookup"><span data-stu-id="413af-134">Active Scanning</span></span>
<span data-ttu-id="413af-135">スキャン応答のアドバタイズを併せて受信するには、ウォッチャーを作成した後、次を設定します。</span><span class="sxs-lookup"><span data-stu-id="413af-135">To receive scan response advertisements as well, set the following after creating the watcher.</span></span> <span data-ttu-id="413af-136">この場合、電力消費量が大きくなり、またバックグラウンド モードでは使用できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="413af-136">Note that this will cause greater power drain and is not available while in background modes.</span></span>

```csharp
watcher.ScanningMode = BluetoothLEScanningMode.Active;
```

### <a name="watching-for-a-specific-advertisement-pattern"></a><span data-ttu-id="413af-137">特定のアドバタイズ パターンのウォッチ</span><span class="sxs-lookup"><span data-stu-id="413af-137">Watching for a Specific Advertisement Pattern</span></span>

<span data-ttu-id="413af-138">状況によっては、特定のアドバタイズのみをリッスンする必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="413af-138">Sometimes you want to listen for a specific advertisement.</span></span> <span data-ttu-id="413af-139">この例では、(0xFFFE として識別される) 作成企業が指定されたペイロードが含まれ、かつ文字列 *Hello World* が含まれたアドバタイズをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="413af-139">In this case, listen for an advertisement containing a payload with a made up company (identified as 0xFFFE) and containing the string *Hello World* in the advertisement.</span></span> <span data-ttu-id="413af-140">このコードは「基本的なパブリッシュ」の例に対応して、一方がアドバタイズする Windows マシン、もう片方がウォッチする Windows マシンとなります。</span><span class="sxs-lookup"><span data-stu-id="413af-140">This can be paired with the Basic Publishing example to have one Windows machine advertising and another watching.</span></span> <span data-ttu-id="413af-141">ウォッチャーを開始する前に、必ずこのアドバタイズ フィルターを設定してください。</span><span class="sxs-lookup"><span data-stu-id="413af-141">Be sure to set this advertisement filter before you start the watcher!</span></span>

```csharp
var manufacturerData = new BluetoothLEManufacturerData();
manufacturerData.CompanyId = 0xFFFE;

// Make sure that the buffer length can fit within an advertisement payload (~20 bytes). 
// Otherwise you will get an exception.
var writer = new DataWriter();
writer.WriteString("Hello World");
manufacturerData.Data = writer.DetachBuffer();

watcher.AdvertisementFilter.Advertisement.ManufacturerData.Add(manufacturerData);
```

### <a name="watching-for-a-nearby-advertisement"></a><span data-ttu-id="413af-142">近接範囲内のアドバタイズのウォッチ</span><span class="sxs-lookup"><span data-stu-id="413af-142">Watching for a Nearby Advertisement</span></span>

<span data-ttu-id="413af-143">アドバタイズしているデバイスが範囲内に入った場合のみ、ウォッチをトリガーするように設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="413af-143">Sometimes you only want to trigger your watcher when the device advertising has come in range.</span></span> <span data-ttu-id="413af-144">範囲は独自に定義できますが、値は 0 ～ -128 の間にクリップされます。</span><span class="sxs-lookup"><span data-stu-id="413af-144">You can define your own range, just note that values will be clipped to between 0 and -128.</span></span> 

```csharp
// Set the in-range threshold to -70dBm. This means advertisements with RSSI >= -70dBm 
// will start to be considered "in-range" (callbacks will start in this range).
watcher.SignalStrengthFilter.InRangeThresholdInDBm = -70;

// Set the out-of-range threshold to -75dBm (give some buffer). Used in conjunction 
// with OutOfRangeTimeout to determine when an advertisement is no longer 
// considered "in-range".
watcher.SignalStrengthFilter.OutOfRangeThresholdInDBm = -75;

// Set the out-of-range timeout to be 2 seconds. Used in conjunction with 
// OutOfRangeThresholdInDBm to determine when an advertisement is no longer 
// considered "in-range"
watcher.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromMilliseconds(2000);
```

### <a name="gauging-distance"></a><span data-ttu-id="413af-145">距離の測定</span><span class="sxs-lookup"><span data-stu-id="413af-145">Gauging Distance</span></span>

<span data-ttu-id="413af-146">Bluetooth LE ウォッチャーのコールバックがトリガーされたとき、eventArgs には受信シグナルの強さ (Bluetooth シグナルの強さ) を示す、RSSI 値が格納されています。</span><span class="sxs-lookup"><span data-stu-id="413af-146">When your Bluetooth LE Watcher's callback is triggered, the eventArgs include an RSSI value telling you the received signal strength (how strong the Bluetooth signal is).</span></span>

```csharp
private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
{
    // The received signal strength indicator (RSSI)
    Int16 rssi = eventArgs.RawSignalStrengthInDBm;
}
```

<span data-ttu-id="413af-147">シグナルの強さからおよその距離を割り出すことができますが、電波はそれぞれ異なるため、正確な距離の測定に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="413af-147">This can be roughly translated into distance, but should not be used to measure true distances as each individual radio is different.</span></span> <span data-ttu-id="413af-148">さまざまな環境因子が存在するため、距離の測定は困難です (電波の周囲の壁や覆い、さらに湿度によっても電波状態が左右されます)。</span><span class="sxs-lookup"><span data-stu-id="413af-148">Different environmental factors can make distance difficult to gauge (such as walls, cases around the radio, or even air humidity).</span></span>

<span data-ttu-id="413af-149">そこで、純粋な距離を判断する代わりに「バケット」を定義することができます。</span><span class="sxs-lookup"><span data-stu-id="413af-149">An alternative to judging pure distance is to define "buckets".</span></span> <span data-ttu-id="413af-150">電波は、発信源が非常に近い場合は 0 ～ -50 DBm、中程度の距離の場合は -50 ～ -90 DBm、遠く離れている場合は -90 DBm 未満を示す傾向があります。</span><span class="sxs-lookup"><span data-stu-id="413af-150">Radios tend to report 0 to -50 DBm when they are very close, -50 to -90 when they are a medium distance away, and below -90 when they are far away.</span></span> <span data-ttu-id="413af-151">アプリの作成にあたってこれらのバケットを判断するには、試行錯誤を繰り返すのが最良の方法です。</span><span class="sxs-lookup"><span data-stu-id="413af-151">Trial and error is best to determine what you want these buckets to be for your app.</span></span>