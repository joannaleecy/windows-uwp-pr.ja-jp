---
author: msatranjr
title: Bluetooth GATT クライアント
description: この記事では、一般的な用途のサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリの Bluetooth 汎用属性プロファイル (GATT) のクライアントの概要を示します。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 345e6f82ddf97c2595dad0029ca432f075a6190b
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6851060"
---
# <a name="bluetooth-gatt-client"></a><span data-ttu-id="6d6ac-104">Bluetooth GATT クライアント</span><span class="sxs-lookup"><span data-stu-id="6d6ac-104">Bluetooth GATT Client</span></span>


**<span data-ttu-id="6d6ac-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="6d6ac-105">Important APIs</span></span>**

-   [**<span data-ttu-id="6d6ac-106">Windows.Devices.Bluetooth</span><span class="sxs-lookup"><span data-stu-id="6d6ac-106">Windows.Devices.Bluetooth</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**<span data-ttu-id="6d6ac-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="6d6ac-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

<span data-ttu-id="6d6ac-108">この記事では、一般的な GATT クライアント タスクのサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth Generic Attribute (GATT) クライアント Api の使用方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-108">This article demonstrates usage of the Bluetooth Generic Attribute (GATT) Client APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT client tasks:</span></span>
- <span data-ttu-id="6d6ac-109">近くにあるデバイスの照会</span><span class="sxs-lookup"><span data-stu-id="6d6ac-109">Query for nearby devices</span></span>
- <span data-ttu-id="6d6ac-110">デバイスへの接続します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-110">Connect to device</span></span>
- <span data-ttu-id="6d6ac-111">サポートされているサービスとデバイスの特性を列挙します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-111">Enumerate the supported services and characteristics of the device</span></span>
- <span data-ttu-id="6d6ac-112">読み取りし、書き込み特性</span><span class="sxs-lookup"><span data-stu-id="6d6ac-112">Read and write to a characteristic</span></span>
- <span data-ttu-id="6d6ac-113">通知の特性と値の変更をサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-113">Subscribe for notifications when characteristic value changes</span></span>

## <a name="overview"></a><span data-ttu-id="6d6ac-114">概要</span><span class="sxs-lookup"><span data-stu-id="6d6ac-114">Overview</span></span>
<span data-ttu-id="6d6ac-115">開発者は、Bluetooth LE デバイスにアクセスするのに[**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)名前空間の Api を使用できます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-115">Developers can use the APIs in the [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) namespace to access Bluetooth LE devices.</span></span> <span data-ttu-id="6d6ac-116">Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-116">Bluetooth LE devices expose their functionality through a collection of:</span></span>

-   <span data-ttu-id="6d6ac-117">サービス</span><span class="sxs-lookup"><span data-stu-id="6d6ac-117">Services</span></span>
-   <span data-ttu-id="6d6ac-118">特性</span><span class="sxs-lookup"><span data-stu-id="6d6ac-118">Characteristics</span></span>
-   <span data-ttu-id="6d6ac-119">記述子</span><span class="sxs-lookup"><span data-stu-id="6d6ac-119">Descriptors</span></span>

<span data-ttu-id="6d6ac-120">サービスは、LE デバイスの機能的なコントラクトを定義し、サービスを定義する特性のコレクションを含めます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-120">Services define the functional contract of the LE device and contain a collection of characteristics that define the service.</span></span> <span data-ttu-id="6d6ac-121">これらの特性はさらに、その特性を表す記述子を含みます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-121">Those characteristics, in turn, contain descriptors that describe the characteristics.</span></span> <span data-ttu-id="6d6ac-122">これら 3 つの用語は、一般的なデバイスの属性と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-122">These 3 terms are generically known as the attributes of a device.</span></span>

<span data-ttu-id="6d6ac-123">Bluetooth LE GATT Api は、生のトランスポートへのアクセスではなく、オブジェクトと関数を公開します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-123">The Bluetooth LE GATT APIs expose objects and functions, rather than access to the raw transport.</span></span> <span data-ttu-id="6d6ac-124">GATT Api には、次のタスクを実行する機能で Bluetooth LE デバイスと連携する開発者も有効にします。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-124">The GATT APIs also enable developers to work with Bluetooth LE devices with the ability to perform the following tasks:</span></span>

-   <span data-ttu-id="6d6ac-125">属性の検出を実行します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-125">Perform attribute discovery</span></span>
-   <span data-ttu-id="6d6ac-126">読み取りと書き込みの属性の値</span><span class="sxs-lookup"><span data-stu-id="6d6ac-126">Read and Write attribute values</span></span>
-   <span data-ttu-id="6d6ac-127">特性の ValueChanged イベントのコールバックを登録します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-127">Register a callback for Characteristic ValueChanged event</span></span>

<span data-ttu-id="6d6ac-128">開発者は便利な実装を作成するには、必要があります予備知識を処理し、GATT のサービスと特性を使用しようとするアプリケーションの特定の特性値は、API によって提供されるバイナリ データに変換するようユーザーに提示する前に有用なデータ。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-128">To create a useful implementation a developer must have prior knowledge of the GATT services and characteristics the application intends to consume and to process the specific characteristic values such that the binary data provided by the API is transformed into useful data before being presented to the user.</span></span> <span data-ttu-id="6d6ac-129">Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-129">The Bluetooth GATT APIs expose only the basic primitives required to communicate with a Bluetooth LE device.</span></span> <span data-ttu-id="6d6ac-130">データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-130">To interpret the data, an application profile must be defined, either by a Bluetooth SIG standard profile, or a custom profile implemented by a device vendor.</span></span> <span data-ttu-id="6d6ac-131">プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-131">A profile creates a binding contract between the application and the device, as to what the exchanged data represents and how to interpret it.</span></span>

<span data-ttu-id="6d6ac-132">Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-132">For convenience the Bluetooth SIG maintains a [list of public profiles](https://www.bluetooth.com/specifications/adopted-specifications#gattspec) available.</span></span>

## <a name="query-for-nearby-devices"></a><span data-ttu-id="6d6ac-133">近くにあるデバイスの照会</span><span class="sxs-lookup"><span data-stu-id="6d6ac-133">Query for nearby devices</span></span>
<span data-ttu-id="6d6ac-134">近くのデバイスを照会する主な方法は 2 つです。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-134">There are two main methods to query for nearby devices:</span></span>
- <span data-ttu-id="6d6ac-135">Windows.Devices.Enumeration で DeviceWatcher</span><span class="sxs-lookup"><span data-stu-id="6d6ac-135">DeviceWatcher in Windows.Devices.Enumeration</span></span>
- <span data-ttu-id="6d6ac-136">Windows.Devices.Bluetooth.Advertisement で AdvertisementWatcher</span><span class="sxs-lookup"><span data-stu-id="6d6ac-136">AdvertisementWatcher in Windows.Devices.Bluetooth.Advertisement</span></span>

<span data-ttu-id="6d6ac-137">2 番目の方法が説明されているで[アドバタイズ](ble-beacon.md)のドキュメントに、説明しませんが多くここでは、基本的な概念が特定の[アドバタイズ フィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)を満たす近くのデバイスの Bluetooth アドレスを確認します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-137">The 2nd method is discussed at length in the [Advertisement](ble-beacon.md) documentation so it won't be discussed much here but the basic idea is to find the Bluetooth address of nearby devices that satisfy the particular [Advertisement Filter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx).</span></span> <span data-ttu-id="6d6ac-138">アドレスを作成したら、デバイスへの参照を取得するのには、 [BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-138">Once you have the address, you can call [BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx) to get a reference to the device.</span></span> 

<span data-ttu-id="6d6ac-139">ここでは、DeviceWatcher メソッドに戻ります。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-139">Now, back to the DeviceWatcher method.</span></span> <span data-ttu-id="6d6ac-140">Bluetooth LE デバイスは、他のデバイスで Windows と同様、[列挙 Api](https://msdn.microsoft.com/library/windows/apps/BR225459)を使用して照会できます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-140">A Bluetooth LE device is just like any other device in Windows and can be queried using the [Enumeration APIs](https://msdn.microsoft.com/library/windows/apps/BR225459).</span></span> <span data-ttu-id="6d6ac-141">[DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher)クラスを使って、検索するデバイスを指定するクエリ文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-141">Use the [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher) class and pass a query string specifying the devices to look for:</span></span> 

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
<span data-ttu-id="6d6ac-142">DeviceWatcher を開始した後は、対象のデバイスの[追加された](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added)イベントのハンドラーで、クエリに適合するデバイスごとに[DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393)が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-142">Once you've started the DeviceWatcher, you will receive [DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393) for each device that satisfies the query in the handler for the [Added](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added) event for the devices in question.</span></span> <span data-ttu-id="6d6ac-143">DeviceWatcher の詳細については、完全な[github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)サンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-143">For a more detailed look at DeviceWatcher see the complete sample [on Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing).</span></span> 

## <a name="connecting-to-the-device"></a><span data-ttu-id="6d6ac-144">デバイスに接続します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-144">Connecting to the device</span></span>
<span data-ttu-id="6d6ac-145">目的のデバイスを検出すると、対象のデバイスの Bluetooth LE デバイス オブジェクトを取得するのに[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id)を使用します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-145">Once a desired device is discovered, use the [DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id) to get the Bluetooth LE Device object for the device in question:</span></span> 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
<span data-ttu-id="6d6ac-146">その一方で、破棄、BluetoothLEDevice に対するすべての参照デバイス オブジェクト (と、システムでは、その他のアプリに、デバイスへの参照がないかどうか) をトリガーする自動小さなタイムアウト期間後に切断されます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-146">On the other hand, disposing of all references to a BluetoothLEDevice object for a device (and if no other app on the system has a reference to the device) will trigger an automatic disconnect after a small timeout period.</span></span> 

```csharp
bluetoothLeDevice.Dispose();
```
<span data-ttu-id="6d6ac-147">アプリは、デバイスに再度アクセスする必要がある場合は、単に、デバイス オブジェクトを再作成して (次のセクションで説明します) の特性へのアクセスと再ときの接続に必要な OS がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-147">If the app needs to access the device again, simply re-creating the device object and accessing a characteristic (discussed in the next section) will trigger the OS to re-connect when necessary.</span></span> <span data-ttu-id="6d6ac-148">デバイスが近くにある場合は、それ以外のデバイスで DeviceUnreachable エラーが返されますへのアクセスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-148">If the device is nearby, you'll get access to the device otherwise it will return w/ a DeviceUnreachable error.</span></span>  

## <a name="enumerating-supported-services-and-characteristics"></a><span data-ttu-id="6d6ac-149">サポートされているサービスと特性を列挙します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-149">Enumerating supported services and characteristics</span></span>
<span data-ttu-id="6d6ac-150">BluetoothLEDevice オブジェクトがある場合は、これで、次の手順は、デバイスが公開するどのようなデータを検出するには</span><span class="sxs-lookup"><span data-stu-id="6d6ac-150">Now that you have a BluetoothLEDevice object, the next step is to discover what data the device exposes.</span></span> <span data-ttu-id="6d6ac-151">これを行うには、最初の手順が、サービスを照会します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-151">The first step to do this is to query for services:</span></span> 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
<span data-ttu-id="6d6ac-152">次の手順で、関心のあるサービスが識別されると、特性を照会します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-152">Once the service of interest has been identified, the next step is to query for characteristics.</span></span> 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
<span data-ttu-id="6d6ac-153">GattCharacteristic の読み取り専用リスト オブジェクトで操作をし実行する、OS が返されます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-153">The OS returns a ReadOnly list of GattCharacteristic objects that you can then perform operations on.</span></span>

## <a name="perform-readwrite-operations-on-a-characteristic"></a><span data-ttu-id="6d6ac-154">読み取り/書き込み特性で操作します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-154">Perform Read/Write operations on a characteristic</span></span>

<span data-ttu-id="6d6ac-155">特性は、GATT の基本単位ベースの通信です。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-155">The characteristic is the fundamental unit of GATT based communication.</span></span> <span data-ttu-id="6d6ac-156">デバイス上のデータの異なる部分を表す値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-156">It contains a value that represents a distinct piece of data on the device.</span></span> <span data-ttu-id="6d6ac-157">たとえば、バッテリ レベルの特性では、デバイスのバッテリ レベルを表す値があります。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-157">For example, the battery level characteristic has a value that represents the battery level of the device.</span></span>

<span data-ttu-id="6d6ac-158">特性のプロパティを調べて、どのような操作がサポートされているを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-158">Read the characteristic properties to determine what operations are supported:</span></span>
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

<span data-ttu-id="6d6ac-159">読み取りがサポートされている場合は、値を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-159">If read is supported, you can read the value:</span></span> 
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
<span data-ttu-id="6d6ac-160">特性への書き込みは、同様のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-160">Writing to a characteristic follows a similar pattern:</span></span> 
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
> <span data-ttu-id="6d6ac-161">**ヒント**: [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)を使ってに慣れてを取得します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-161">**Tip**: Get comfortable with using [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx) and [DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx).</span></span> <span data-ttu-id="6d6ac-162">Bluetooth Api の多くはから取得した raw バッファーを使用する場合、それらの機能は不可欠なできません。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-162">Their functionality will be indispensible when working with the raw buffers you get from many of the Bluetooth APIs.</span></span> 
## <a name="subscribing-for-notifications"></a><span data-ttu-id="6d6ac-163">通知のサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="6d6ac-163">Subscribing for notifications</span></span>

<span data-ttu-id="6d6ac-164">特性を示すまたは通知のいずれかをサポートするかどうかを確認 (チェック特性のプロパティを確認します)。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-164">Make sure the characteristic supports either Indicate or Notify (check the characteristic properties to make sure).</span></span> 

> <span data-ttu-id="6d6ac-165">**確保**: 示すと見なされる信頼性の高い値が変化したイベントごとに、クライアント デバイスからの応答と組み合わされるためです。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-165">**Aside**: Indicate is considered more reliable because each value changed event is coupled with an acknowledgement from the client device.</span></span> <span data-ttu-id="6d6ac-166">通知が GATT 取引のほとんどはではなく電力を節約ではなく非常に信頼性が高くなるためにより一般的です。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-166">Notify is more prevalent because most GATT transactions would rather conserve power rather than be extremely reliable.</span></span> <span data-ttu-id="6d6ac-167">どのような場合は、アプリは関与しないために、コント ローラー レイヤーで処理、そのすべてされます。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-167">In any case, all of that is handled at the controller layer so the app does not get involved.</span></span> <span data-ttu-id="6d6ac-168">単に"notifications"としてそれらをまとめて呼びますがわかっているようになりました。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-168">We'll collectively refer to them as simply "notifications" but now you know.</span></span> 

<span data-ttu-id="6d6ac-169">これには通知を取得する前に対処する次の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-169">There are two things to take care of before getting notifications:</span></span>
- <span data-ttu-id="6d6ac-170">クライアント特性構成記述子 (CCCD) への書き込み</span><span class="sxs-lookup"><span data-stu-id="6d6ac-170">Write to Client Characteristic Configuration Descriptor (CCCD)</span></span>
- <span data-ttu-id="6d6ac-171">Characteristic.ValueChanged イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-171">Handle the Characteristic.ValueChanged event</span></span>

<span data-ttu-id="6d6ac-172">CCCD への書き込みは、このクライアントがその特定の特性値の変更を毎回に知っておく必要があることをサーバー デバイスに指示します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-172">Writing to the CCCD tells the Server device that this client wants to know each time that particular characteristic value changes.</span></span> <span data-ttu-id="6d6ac-173">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-173">To do this:</span></span> 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
<span data-ttu-id="6d6ac-174">これで、GattCharacteristic の ValueChanged イベントを取得するたびに呼び出さ値は、リモート デバイスで変更を取得します。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-174">Now, the GattCharacteristic's ValueChanged event will get called each time the value gets changed on the remote device.</span></span> <span data-ttu-id="6d6ac-175">ハンドラーを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="6d6ac-175">All that's left is to implement the handler:</span></span> 

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


