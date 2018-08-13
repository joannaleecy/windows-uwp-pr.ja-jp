---
author: msatranjr
title: Bluetooth GATT クライアント
description: この記事では、一般的な用途のサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性プロファイル (GATT) クライアントの概要を示します。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 555fec6d534c07898acd911f9cd84a11ac66dcd8
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608821"
---
# <a name="bluetooth-gatt-client"></a><span data-ttu-id="e2c22-104">Bluetooth GATT クライアント</span><span class="sxs-lookup"><span data-stu-id="e2c22-104">Bluetooth GATT Client</span></span>


**<span data-ttu-id="e2c22-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="e2c22-105">Important APIs</span></span>**

-   [**<span data-ttu-id="e2c22-106">Windows.Devices.Bluetooth</span><span class="sxs-lookup"><span data-stu-id="e2c22-106">Windows.Devices.Bluetooth</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**<span data-ttu-id="e2c22-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="e2c22-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

<span data-ttu-id="e2c22-108">この記事では、GATT クライアントの一般的なタスクのサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性 (GATT) クライアント Api の使用を示します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-108">This article demonstrates usage of the Bluetooth Generic Attribute (GATT) Client APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT client tasks:</span></span>
- <span data-ttu-id="e2c22-109">クエリの近くにあるデバイス</span><span class="sxs-lookup"><span data-stu-id="e2c22-109">Query for nearby devices</span></span>
- <span data-ttu-id="e2c22-110">デバイスに接続します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-110">Connect to device</span></span>
- <span data-ttu-id="e2c22-111">サポートされているサービスおよびデバイスの特性を列挙します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-111">Enumerate the supported services and characteristics of the device</span></span>
- <span data-ttu-id="e2c22-112">読み取りし、書き込み特性</span><span class="sxs-lookup"><span data-stu-id="e2c22-112">Read and write to a characteristic</span></span>
- <span data-ttu-id="e2c22-113">購読特性ときの通知の値の変更</span><span class="sxs-lookup"><span data-stu-id="e2c22-113">Subscribe for notifications when characteristic value changes</span></span>

## <a name="overview"></a><span data-ttu-id="e2c22-114">概要</span><span class="sxs-lookup"><span data-stu-id="e2c22-114">Overview</span></span>
<span data-ttu-id="e2c22-115">開発者は、 [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)名前空間の Api を使用して Bluetooth LE デバイスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e2c22-115">Developers can use the APIs in the [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) namespace to access Bluetooth LE devices.</span></span> <span data-ttu-id="e2c22-116">Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e2c22-116">Bluetooth LE devices expose their functionality through a collection of:</span></span>

-   <span data-ttu-id="e2c22-117">サービス</span><span class="sxs-lookup"><span data-stu-id="e2c22-117">Services</span></span>
-   <span data-ttu-id="e2c22-118">特性</span><span class="sxs-lookup"><span data-stu-id="e2c22-118">Characteristics</span></span>
-   <span data-ttu-id="e2c22-119">記述子</span><span class="sxs-lookup"><span data-stu-id="e2c22-119">Descriptors</span></span>

<span data-ttu-id="e2c22-120">サービスを LE デバイスの機能の契約を定義し、サービスの特性のコレクションを含みます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-120">Services define the functional contract of the LE device and contain a collection of characteristics that define the service.</span></span> <span data-ttu-id="e2c22-121">これらの特性はさらに、その特性を表す記述子を含みます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-121">Those characteristics, in turn, contain descriptors that describe the characteristics.</span></span> <span data-ttu-id="e2c22-122">これら 3 つの条件は、一般的なデバイスの属性という名称でした。</span><span class="sxs-lookup"><span data-stu-id="e2c22-122">These 3 terms are generically known as the attributes of a device.</span></span>

<span data-ttu-id="e2c22-123">Bluetooth LE GATT Api は、生トランスポートへのアクセスではなく、および関数のオブジェクトを公開します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-123">The Bluetooth LE GATT APIs expose objects and functions, rather than access to the raw transport.</span></span> <span data-ttu-id="e2c22-124">GATT Api には、次のタスクを実行する権限を持つ Bluetooth LE デバイスを操作する開発者も有効にします。</span><span class="sxs-lookup"><span data-stu-id="e2c22-124">The GATT APIs also enable developers to work with Bluetooth LE devices with the ability to perform the following tasks:</span></span>

-   <span data-ttu-id="e2c22-125">属性の検出を実行します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-125">Perform attribute discovery</span></span>
-   <span data-ttu-id="e2c22-126">読み取りおよび書き込み属性の値</span><span class="sxs-lookup"><span data-stu-id="e2c22-126">Read and Write attribute values</span></span>
-   <span data-ttu-id="e2c22-127">特徴 ValueChanged イベントのコールバックを登録します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-127">Register a callback for Characteristic ValueChanged event</span></span>

<span data-ttu-id="e2c22-128">開発者の便利な環境を構築するには、必要があります知識 GATT サービスおよび特性を使用しようとしているアプリケーションとプロセスに固有の特性の値を API によって提供されるバイナリ データを変換します。ユーザーに表示される前にデータに便利です。</span><span class="sxs-lookup"><span data-stu-id="e2c22-128">To create a useful implementation a developer must have prior knowledge of the GATT services and characteristics the application intends to consume and to process the specific characteristic values such that the binary data provided by the API is transformed into useful data before being presented to the user.</span></span> <span data-ttu-id="e2c22-129">Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。</span><span class="sxs-lookup"><span data-stu-id="e2c22-129">The Bluetooth GATT APIs expose only the basic primitives required to communicate with a Bluetooth LE device.</span></span> <span data-ttu-id="e2c22-130">データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2c22-130">To interpret the data, an application profile must be defined, either by a Bluetooth SIG standard profile, or a custom profile implemented by a device vendor.</span></span> <span data-ttu-id="e2c22-131">プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-131">A profile creates a binding contract between the application and the device, as to what the exchanged data represents and how to interpret it.</span></span>

<span data-ttu-id="e2c22-132">Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。</span><span class="sxs-lookup"><span data-stu-id="e2c22-132">For convenience the Bluetooth SIG maintains a [list of public profiles](https://www.bluetooth.com/specifications/adopted-specifications#gattspec) available.</span></span>

## <a name="query-for-nearby-devices"></a><span data-ttu-id="e2c22-133">クエリの近くにあるデバイス</span><span class="sxs-lookup"><span data-stu-id="e2c22-133">Query for nearby devices</span></span>
<span data-ttu-id="e2c22-134">近くにあるデバイスに対するクエリを 2 つの主な方法があります。</span><span class="sxs-lookup"><span data-stu-id="e2c22-134">There are two main methods to query for nearby devices:</span></span>
- <span data-ttu-id="e2c22-135">Windows.Devices.Enumeration で DeviceWatcher</span><span class="sxs-lookup"><span data-stu-id="e2c22-135">DeviceWatcher in Windows.Devices.Enumeration</span></span>
- <span data-ttu-id="e2c22-136">Windows.Devices.Bluetooth.Advertisement で AdvertisementWatcher</span><span class="sxs-lookup"><span data-stu-id="e2c22-136">AdvertisementWatcher in Windows.Devices.Bluetooth.Advertisement</span></span>

<span data-ttu-id="e2c22-137">第 2 の方法を説明したで[広告](ble-beacon.md)のドキュメントでは説明しません量ここでは基本的な考え方は特定の[広告のフィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)を満たす近くにあるデバイスの Bluetooth アドレスを検索します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-137">The 2nd method is discussed at length in the [Advertisement](ble-beacon.md) documentation so it won't be discussed much here but the basic idea is to find the Bluetooth address of nearby devices that satisfy the particular [Advertisement Filter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx).</span></span> <span data-ttu-id="e2c22-138">アドレスを作成したら、デバイスへの参照を取得する[BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-138">Once you have the address, you can call [BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx) to get a reference to the device.</span></span> 

<span data-ttu-id="e2c22-139">ここでは、DeviceWatcher メソッドに戻る。</span><span class="sxs-lookup"><span data-stu-id="e2c22-139">Now, back to the DeviceWatcher method.</span></span> <span data-ttu-id="e2c22-140">Bluetooth LE デバイスは Windows の他のデバイスと同じように、[列挙 Api](https://msdn.microsoft.com/library/windows/apps/BR225459)を使用して問い合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-140">A Bluetooth LE device is just like any other device in Windows and can be queried using the [Enumeration APIs](https://msdn.microsoft.com/library/windows/apps/BR225459).</span></span> <span data-ttu-id="e2c22-141">[DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher)クラスを使用して、検索するデバイスを指定するクエリ文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-141">Use the [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher) class and pass a query string specifying the devices to look for:</span></span> 

```csharp
// Query for extra properties you want returned
string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

DeviceWatcher deviceWatcher =
            DeviceInformation.CreateWatcher(
                    BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                    requestedProperties,
                    DeviceInformationKind.AssociationEndpoint);

// Register event handlers before starting the watcher.
// Added, Updated and Removed are required to get all nearby devices
deviceWatcher.Added += DeviceWatcher_Added;
deviceWatcher.Updated += DeviceWatcher_Updated;
deviceWatcher.Removed += DeviceWatcher_Removed;

// EnumerationCompleted and Stopped are optional to implement.
deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
deviceWatcher.Stopped += DeviceWatcher_Stopped;

// Start the watcher.
deviceWatcher.Start();
```
<span data-ttu-id="e2c22-142">[DeviceWatcher を開始すると、該当のデバイスに[追加された](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added)イベント ハンドラーでクエリを満たしているデバイスごとに[DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393)が提供されます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-142">Once you've started the DeviceWatcher, you will receive [DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393) for each device that satisfies the query in the handler for the [Added](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added) event for the devices in question.</span></span> <span data-ttu-id="e2c22-143">DeviceWatcher で詳細を確認する、完全な[Github 上](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)の例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e2c22-143">For a more detailed look at DeviceWatcher see the complete sample [on Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing).</span></span> 

## <a name="connecting-to-the-device"></a><span data-ttu-id="e2c22-144">デバイスに接続します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-144">Connecting to the device</span></span>
<span data-ttu-id="e2c22-145">目的のデバイスを検出すると、該当のデバイスの Bluetooth LE デバイス オブジェクトを取得するのに[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id)を使用します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-145">Once a desired device is discovered, use the [DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id) to get the Bluetooth LE Device object for the device in question:</span></span> 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
<span data-ttu-id="e2c22-146">その一方で、すべての参照を BluetoothLEDevice の破棄のデバイスのオブジェクト (と、システムの他のアプリにデバイスへの参照がないかどうか) をトリガー自動 small タイムアウトから切断します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-146">On the other hand, disposing of all references to a BluetoothLEDevice object for a device (and if no other app on the system has a reference to the device) will trigger an automatic disconnect after a small timeout period.</span></span> 

```csharp
bluetoothLeDevice.Dispose();
```
<span data-ttu-id="e2c22-147">アプリもう一度デバイスにアクセスする場合は、デバイス オブジェクトを再作成して、特性 (次のセクションで説明する) にアクセスするだけでトリガー OS に必要な場合をもう一度接続します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-147">If the app needs to access the device again, simply re-creating the device object and accessing a characteristic (discussed in the next section) will trigger the OS to re-connect when necessary.</span></span> <span data-ttu-id="e2c22-148">デバイスの近くにある場合、それ以外のデバイスと DeviceUnreachable のエラーが返されますへのアクセスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-148">If the device is nearby, you'll get access to the device otherwise it will return w/ a DeviceUnreachable error.</span></span>  

## <a name="enumerating-supported-services-and-characteristics"></a><span data-ttu-id="e2c22-149">サポートされているサービスとの特性を列挙します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-149">Enumerating supported services and characteristics</span></span>
<span data-ttu-id="e2c22-150">BluetoothLEDevice のオブジェクトがある場合は、これで、次の手順では、デバイスを公開データを検出します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-150">Now that you have a BluetoothLEDevice object, the next step is to discover what data the device exposes.</span></span> <span data-ttu-id="e2c22-151">これを行うには、まずサービスのクエリを実行します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-151">The first step to do this is to query for services:</span></span> 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
<span data-ttu-id="e2c22-152">次の手順で、興味のあるサービスが識別されると、特性のクエリを実行します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-152">Once the service of interest has been identified, the next step is to query for characteristics.</span></span> 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
<span data-ttu-id="e2c22-153">OS の操作を実行できますし、オブジェクトを GattCharacteristic の読み取り専用リストを返します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-153">The OS returns a ReadOnly list of GattCharacteristic objects that you can then perform operations on.</span></span>

## <a name="perform-readwrite-operations-on-a-characteristic"></a><span data-ttu-id="e2c22-154">読み取り/書き込みの特徴に操作します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-154">Perform Read/Write operations on a characteristic</span></span>

<span data-ttu-id="e2c22-155">特性が GATT の基本単位通信います。</span><span class="sxs-lookup"><span data-stu-id="e2c22-155">The characteristic is the fundamental unit of GATT based communication.</span></span> <span data-ttu-id="e2c22-156">デバイス上のデータの重複しない値の部分を表す値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e2c22-156">It contains a value that represents a distinct piece of data on the device.</span></span> <span data-ttu-id="e2c22-157">たとえば、バッテリ レベルの特徴では、デバイスのバッテリ レベルを表す値があります。</span><span class="sxs-lookup"><span data-stu-id="e2c22-157">For example, the battery level characteristic has a value that represents the battery level of the device.</span></span>

<span data-ttu-id="e2c22-158">どのような操作がサポートされるかを決定する特性のプロパティを参照してください。</span><span class="sxs-lookup"><span data-stu-id="e2c22-158">Read the characteristic properties to determine what operations are supported:</span></span>
```csharp
GattCharacteristicProperties properties = characteristic.CharacteristicProperties

if(properties.HasFlag(GattCharacteristicProperties.Read))
{
    // This characteristic supports reading from it.
}
if(properties.HasFlag(GattCharacteristicProperties.Write))
{
    // This characteristic supports writing to it.
}
if(properties.HasFlag(GattCharacteristicProperties.Notify))
{
    // This characteristic supports subscribing to notifications.
}
```

<span data-ttu-id="e2c22-159">読み取りがサポートされる場合は、値を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-159">If read is supported, you can read the value:</span></span> 
```csharp
GattReadResult result = await selectedCharacteristic.ReadValueAsync();
if (result.Status == GattCommunicationStatus.Success)
{
    var reader = DataReader.FromBuffer(result.Value);
    byte[] input = new byte[reader.UnconsumedBufferLength];
    reader.ReadBytes(input);
    // Utilize the data as needed
}
```
<span data-ttu-id="e2c22-160">特性への書き込みは次のようなパターンです。</span><span class="sxs-lookup"><span data-stu-id="e2c22-160">Writing to a characteristic follows a similar pattern:</span></span> 
```csharp
var writer = new DataWriter();
// WriteByte used for simplicity. Other commmon functions - WriteInt16 and WriteSingle
writer.WriteByte(0x01);

GattReadResult result = await selectedCharacteristic.WriteValueAsync(writer.DetachBuffer());
if (result.Status == GattCommunicationStatus.Success)
{
    // Successfully wrote to device
}
```
> <span data-ttu-id="e2c22-161">**ヒント**: [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)の使用に慣れます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-161">**Tip**: Get comfortable with using [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx) and [DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx).</span></span> <span data-ttu-id="e2c22-162">さまざまな Bluetooth Api から取得した生のバッファーを操作するときに、それぞれの機能は不可欠なできません。</span><span class="sxs-lookup"><span data-stu-id="e2c22-162">Their functionality will be indispensible when working with the raw buffers you get from many of the Bluetooth APIs.</span></span> 
## <a name="subscribing-for-notifications"></a><span data-ttu-id="e2c22-163">通知の購読</span><span class="sxs-lookup"><span data-stu-id="e2c22-163">Subscribing for notifications</span></span>

<span data-ttu-id="e2c22-164">特性を示すか、通知をサポートしているかどうかを確認 (ことを確認する特性のプロパティを確認する)。</span><span class="sxs-lookup"><span data-stu-id="e2c22-164">Make sure the characteristic supports either Indicate or Notify (check the characteristic properties to make sure).</span></span> 

> <span data-ttu-id="e2c22-165">**確保し、**: を示すと見なされる信頼性の高い各値が変更されましたイベントがクライアント デバイスからの応答を結合します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-165">**Aside**: Indicate is considered more reliable because each value changed event is coupled with an acknowledgement from the client device.</span></span> <span data-ttu-id="e2c22-166">通知多いは、ほとんどの GATT トランザクションとではなく電源を節約することがなく信頼性の高いためです。</span><span class="sxs-lookup"><span data-stu-id="e2c22-166">Notify is more prevalent because most GATT transactions would rather conserve power rather than be extremely reliable.</span></span> <span data-ttu-id="e2c22-167">どのような場合は、アプリが関与しないように、コント ローラー レイヤーで処理をされます。</span><span class="sxs-lookup"><span data-stu-id="e2c22-167">In any case, all of that is handled at the controller layer so the app does not get involved.</span></span> <span data-ttu-id="e2c22-168">それらを単に"通知] と呼びますがまとめてがわかるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e2c22-168">We'll collectively refer to them as simply "notifications" but now you know.</span></span> 

<span data-ttu-id="e2c22-169">通知を開始する前に対処する次の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="e2c22-169">There are two things to take care of before getting notifications:</span></span>
- <span data-ttu-id="e2c22-170">クライアントの特性の構成表して (CCCD) に書き込む</span><span class="sxs-lookup"><span data-stu-id="e2c22-170">Write to Client Characteristic Configuration Descriptor (CCCD)</span></span>
- <span data-ttu-id="e2c22-171">Characteristic.ValueChanged イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-171">Handle the Characteristic.ValueChanged event</span></span>

<span data-ttu-id="e2c22-172">CCCD への書き込みをこのを知りたいたびにその特性の特定の値の変更をサーバーのデバイスに説明します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-172">Writing to the CCCD tells the Server device that this client wants to know each time that particular characteristic value changes.</span></span> <span data-ttu-id="e2c22-173">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e2c22-173">To do this:</span></span> 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
<span data-ttu-id="e2c22-174">これで、GattCharacteristic の ValueChanged イベントが呼び出されるリモート デバイス上の値を変更するたびにします。</span><span class="sxs-lookup"><span data-stu-id="e2c22-174">Now, the GattCharacteristic's ValueChanged event will get called each time the value gets changed on the remote device.</span></span> <span data-ttu-id="e2c22-175">残りのハンドラーを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="e2c22-175">All that's left is to implement the handler:</span></span> 

```csharp
characteristic.ValueChanged += Characteristic_ValueChanged;
// ... 

void Characteristic_ValueChanged(GattCharacteristic sender, 
                                    GattValueChangedEventArgs args)
{
    // An Indicate or Notify reported that the value has changed.
    var reader = DataReader.FromBuffer(args.CharacteristicValue)
    // Parse the data however required.
}
```


