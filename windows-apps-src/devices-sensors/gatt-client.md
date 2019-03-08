---
title: Bluetooth GATT クライアント
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性プロファイル (GATT) クライアントの概要と、一般的な使用事例のサンプル コードについて説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3ae656b473a4dd5999588057b0ec970645703eec
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635087"
---
# <a name="bluetooth-gatt-client"></a><span data-ttu-id="3709c-104">Bluetooth GATT クライアント</span><span class="sxs-lookup"><span data-stu-id="3709c-104">Bluetooth GATT Client</span></span>


<span data-ttu-id="3709c-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="3709c-105">**Important APIs**</span></span>

-   [<span data-ttu-id="3709c-106">**Windows.Devices.Bluetooth**</span><span class="sxs-lookup"><span data-stu-id="3709c-106">**Windows.Devices.Bluetooth**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [<span data-ttu-id="3709c-107">**Windows.Devices.Bluetooth.GenericAttributeProfile**</span><span class="sxs-lookup"><span data-stu-id="3709c-107">**Windows.Devices.Bluetooth.GenericAttributeProfile**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn297685)

<span data-ttu-id="3709c-108">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性 (GATT) クライアント API の使用方法を、一般的な GATT クライアント タスクのサンプル コードを使って示します。</span><span class="sxs-lookup"><span data-stu-id="3709c-108">This article demonstrates usage of the Bluetooth Generic Attribute (GATT) Client APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT client tasks:</span></span>
- <span data-ttu-id="3709c-109">近くのデバイスの照会</span><span class="sxs-lookup"><span data-stu-id="3709c-109">Query for nearby devices</span></span>
- <span data-ttu-id="3709c-110">デバイスへの接続</span><span class="sxs-lookup"><span data-stu-id="3709c-110">Connect to device</span></span>
- <span data-ttu-id="3709c-111">デバイスでサポートされているサービスやデバイスの特性の列挙</span><span class="sxs-lookup"><span data-stu-id="3709c-111">Enumerate the supported services and characteristics of the device</span></span>
- <span data-ttu-id="3709c-112">特性の読み取りと書き込み</span><span class="sxs-lookup"><span data-stu-id="3709c-112">Read and write to a characteristic</span></span>
- <span data-ttu-id="3709c-113">特性値が変化したときの通知の受信登録</span><span class="sxs-lookup"><span data-stu-id="3709c-113">Subscribe for notifications when characteristic value changes</span></span>

## <a name="overview"></a><span data-ttu-id="3709c-114">概要</span><span class="sxs-lookup"><span data-stu-id="3709c-114">Overview</span></span>
<span data-ttu-id="3709c-115">開発者は、[**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) 名前空間の API を使って Bluetooth LE デバイスにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="3709c-115">Developers can use the APIs in the [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) namespace to access Bluetooth LE devices.</span></span> <span data-ttu-id="3709c-116">Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3709c-116">Bluetooth LE devices expose their functionality through a collection of:</span></span>

-   <span data-ttu-id="3709c-117">サービス</span><span class="sxs-lookup"><span data-stu-id="3709c-117">Services</span></span>
-   <span data-ttu-id="3709c-118">特性</span><span class="sxs-lookup"><span data-stu-id="3709c-118">Characteristics</span></span>
-   <span data-ttu-id="3709c-119">記述子</span><span class="sxs-lookup"><span data-stu-id="3709c-119">Descriptors</span></span>

<span data-ttu-id="3709c-120">サービスは、LE デバイスの機能的なコントラクトを定義するもので、サービスを定義する特性のコレクションを含みます。</span><span class="sxs-lookup"><span data-stu-id="3709c-120">Services define the functional contract of the LE device and contain a collection of characteristics that define the service.</span></span> <span data-ttu-id="3709c-121">これらの特性はさらに、その特性を表す記述子を含みます。</span><span class="sxs-lookup"><span data-stu-id="3709c-121">Those characteristics, in turn, contain descriptors that describe the characteristics.</span></span> <span data-ttu-id="3709c-122">これら 3 つの用語は、一般的に、デバイスの属性と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="3709c-122">These 3 terms are generically known as the attributes of a device.</span></span>

<span data-ttu-id="3709c-123">Bluetooth LE GATT API は、生のトランスポートにアクセスするのではなく、オブジェクトと関数を公開します。</span><span class="sxs-lookup"><span data-stu-id="3709c-123">The Bluetooth LE GATT APIs expose objects and functions, rather than access to the raw transport.</span></span> <span data-ttu-id="3709c-124">また、GATT API で Bluetooth LE デバイスと連携することによって、次のことが可能となります。</span><span class="sxs-lookup"><span data-stu-id="3709c-124">The GATT APIs also enable developers to work with Bluetooth LE devices with the ability to perform the following tasks:</span></span>

-   <span data-ttu-id="3709c-125">属性の検出の実行</span><span class="sxs-lookup"><span data-stu-id="3709c-125">Perform attribute discovery</span></span>
-   <span data-ttu-id="3709c-126">属性値の読み取りと書き込み</span><span class="sxs-lookup"><span data-stu-id="3709c-126">Read and Write attribute values</span></span>
-   <span data-ttu-id="3709c-127">特性の ValueChanged イベントで呼び出されるコールバックの登録</span><span class="sxs-lookup"><span data-stu-id="3709c-127">Register a callback for Characteristic ValueChanged event</span></span>

<span data-ttu-id="3709c-128">実用的なアプリケーションを作成するためには、利用する GATT のサービスと特性についての予備知識が開発者に求められます。実際に必要な特性値を処理し、API から提供されるバイナリ データを実用的なデータに変換したうえで、ユーザーに提示しなければなりません。</span><span class="sxs-lookup"><span data-stu-id="3709c-128">To create a useful implementation a developer must have prior knowledge of the GATT services and characteristics the application intends to consume and to process the specific characteristic values such that the binary data provided by the API is transformed into useful data before being presented to the user.</span></span> <span data-ttu-id="3709c-129">Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。</span><span class="sxs-lookup"><span data-stu-id="3709c-129">The Bluetooth GATT APIs expose only the basic primitives required to communicate with a Bluetooth LE device.</span></span> <span data-ttu-id="3709c-130">データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3709c-130">To interpret the data, an application profile must be defined, either by a Bluetooth SIG standard profile, or a custom profile implemented by a device vendor.</span></span> <span data-ttu-id="3709c-131">プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。</span><span class="sxs-lookup"><span data-stu-id="3709c-131">A profile creates a binding contract between the application and the device, as to what the exchanged data represents and how to interpret it.</span></span>

<span data-ttu-id="3709c-132">Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。</span><span class="sxs-lookup"><span data-stu-id="3709c-132">For convenience the Bluetooth SIG maintains a [list of public profiles](https://www.bluetooth.com/specifications/adopted-specifications#gattspec) available.</span></span>

## <a name="query-for-nearby-devices"></a><span data-ttu-id="3709c-133">近くのデバイスの照会</span><span class="sxs-lookup"><span data-stu-id="3709c-133">Query for nearby devices</span></span>
<span data-ttu-id="3709c-134">近くのデバイスを照会するための主なメソッドは 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="3709c-134">There are two main methods to query for nearby devices:</span></span>
- <span data-ttu-id="3709c-135">Windows.Devices.Enumeration の DeviceWatcher</span><span class="sxs-lookup"><span data-stu-id="3709c-135">DeviceWatcher in Windows.Devices.Enumeration</span></span>
- <span data-ttu-id="3709c-136">Windows.Devices.Bluetooth.Advertisement の AdvertisementWatcher</span><span class="sxs-lookup"><span data-stu-id="3709c-136">AdvertisementWatcher in Windows.Devices.Bluetooth.Advertisement</span></span>

<span data-ttu-id="3709c-137">2 つ目のメソッドについては、[アドバタイズ](ble-beacon.md)に関するドキュメントで詳しく説明されているため、ここでは簡単に説明します。基本的な考え方は、特定の[アドバタイズ フィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)の条件を満たす、近くにあるデバイスの Bluetooth アドレスを検出するということです。</span><span class="sxs-lookup"><span data-stu-id="3709c-137">The 2nd method is discussed at length in the [Advertisement](ble-beacon.md) documentation so it won't be discussed much here but the basic idea is to find the Bluetooth address of nearby devices that satisfy the particular [Advertisement Filter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx).</span></span> <span data-ttu-id="3709c-138">アドレスを検出したら、[BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx) を呼び出して、デバイスへの参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="3709c-138">Once you have the address, you can call [BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx) to get a reference to the device.</span></span> 

<span data-ttu-id="3709c-139">DeviceWatcher メソッドの説明に戻ります。</span><span class="sxs-lookup"><span data-stu-id="3709c-139">Now, back to the DeviceWatcher method.</span></span> <span data-ttu-id="3709c-140">Bluetooth LE デバイスは、Windows の他のデバイスと同じように[列挙 API](https://msdn.microsoft.com/library/windows/apps/BR225459) を使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="3709c-140">A Bluetooth LE device is just like any other device in Windows and can be queried using the [Enumeration APIs](https://msdn.microsoft.com/library/windows/apps/BR225459).</span></span> <span data-ttu-id="3709c-141">[DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher) クラスを使用して、検索するデバイスを指定するクエリ文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="3709c-141">Use the [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher) class and pass a query string specifying the devices to look for:</span></span> 

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
<span data-ttu-id="3709c-142">DeviceWatcher を開始すると、対象のデバイスの [Added](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added) イベントのハンドラーで、クエリを満たすデバイスごとに [DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393) を受信します。</span><span class="sxs-lookup"><span data-stu-id="3709c-142">Once you've started the DeviceWatcher, you will receive [DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393) for each device that satisfies the query in the handler for the [Added](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added) event for the devices in question.</span></span> <span data-ttu-id="3709c-143">DeviceWatcher について詳しくは、[Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing) にある完全なサンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3709c-143">For a more detailed look at DeviceWatcher see the complete sample [on Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing).</span></span> 

## <a name="connecting-to-the-device"></a><span data-ttu-id="3709c-144">デバイスへの接続</span><span class="sxs-lookup"><span data-stu-id="3709c-144">Connecting to the device</span></span>
<span data-ttu-id="3709c-145">目的のデバイスが検出されたら、[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id) を使用して、対象のデバイスの Bluetooth LE デバイス オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="3709c-145">Once a desired device is discovered, use the [DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id) to get the Bluetooth LE Device object for the device in question:</span></span> 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
<span data-ttu-id="3709c-146">一方、デバイスの BluetoothLEDevice オブジェクトへのすべての参照を破棄すると (システム上の他のアプリがそのデバイスを参照していない場合)、短いタイムアウト期間後に自動切断がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="3709c-146">On the other hand, disposing of all references to a BluetoothLEDevice object for a device (and if no other app on the system has a reference to the device) will trigger an automatic disconnect after a small timeout period.</span></span> 

```csharp
bluetoothLeDevice.Dispose();
```
<span data-ttu-id="3709c-147">アプリが再びデバイスにアクセスする必要がある場合は、単にデバイス オブジェクトを再作成して特性にアクセスする (次のセクションで説明します) と、必要に応じて、OS による再接続がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="3709c-147">If the app needs to access the device again, simply re-creating the device object and accessing a characteristic (discussed in the next section) will trigger the OS to re-connect when necessary.</span></span> <span data-ttu-id="3709c-148">デバイスが近くにある場合は、デバイスへのアクセスが取得されます。近くにない場合は、DeviceUnreachable エラーと共に制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="3709c-148">If the device is nearby, you'll get access to the device otherwise it will return w/ a DeviceUnreachable error.</span></span>  

## <a name="enumerating-supported-services-and-characteristics"></a><span data-ttu-id="3709c-149">サポートされているサービスと特性の列挙</span><span class="sxs-lookup"><span data-stu-id="3709c-149">Enumerating supported services and characteristics</span></span>
<span data-ttu-id="3709c-150">BluetoothLEDevice オブジェクトが取得されたので、次の手順はデバイスが公開するデータを検出することです。</span><span class="sxs-lookup"><span data-stu-id="3709c-150">Now that you have a BluetoothLEDevice object, the next step is to discover what data the device exposes.</span></span> <span data-ttu-id="3709c-151">これを行うための最初の手順は、サービスの照会です。</span><span class="sxs-lookup"><span data-stu-id="3709c-151">The first step to do this is to query for services:</span></span> 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
<span data-ttu-id="3709c-152">対象のサービスが識別されたら、次の手順は特性の照会です。</span><span class="sxs-lookup"><span data-stu-id="3709c-152">Once the service of interest has been identified, the next step is to query for characteristics.</span></span> 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
<span data-ttu-id="3709c-153">OS は、操作を実行できる対象の GattCharacteristic オブジェクトの読み取り専用のリストを返します。</span><span class="sxs-lookup"><span data-stu-id="3709c-153">The OS returns a ReadOnly list of GattCharacteristic objects that you can then perform operations on.</span></span>

## <a name="perform-readwrite-operations-on-a-characteristic"></a><span data-ttu-id="3709c-154">特性の読み取り/書き込み操作の実行</span><span class="sxs-lookup"><span data-stu-id="3709c-154">Perform Read/Write operations on a characteristic</span></span>

<span data-ttu-id="3709c-155">特性は、GATT ベースの通信の基本単位です。</span><span class="sxs-lookup"><span data-stu-id="3709c-155">The characteristic is the fundamental unit of GATT based communication.</span></span> <span data-ttu-id="3709c-156">これには、デバイス上の各種データを表す値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3709c-156">It contains a value that represents a distinct piece of data on the device.</span></span> <span data-ttu-id="3709c-157">たとえば、バッテリ レベル特性には、デバイスのバッテリ レベルを表す値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3709c-157">For example, the battery level characteristic has a value that represents the battery level of the device.</span></span>

<span data-ttu-id="3709c-158">特性のプロパティを読み取って、どのような操作がサポートされているかを特定します。</span><span class="sxs-lookup"><span data-stu-id="3709c-158">Read the characteristic properties to determine what operations are supported:</span></span>
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

<span data-ttu-id="3709c-159">読み取りがサポートされている場合は、値を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="3709c-159">If read is supported, you can read the value:</span></span> 
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
<span data-ttu-id="3709c-160">特性への書き込みは、同様のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="3709c-160">Writing to a characteristic follows a similar pattern:</span></span> 
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
> <span data-ttu-id="3709c-161">**ヒント**:使用してに慣れます[DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[datawriter の各](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="3709c-161">**Tip**: Get comfortable with using [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx) and [DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx).</span></span> <span data-ttu-id="3709c-162">多くの Bluetooth API から取得した未加工バッファーを操作するときは、これらの機能が不可欠です。</span><span class="sxs-lookup"><span data-stu-id="3709c-162">Their functionality will be indispensible when working with the raw buffers you get from many of the Bluetooth APIs.</span></span> 
## <a name="subscribing-for-notifications"></a><span data-ttu-id="3709c-163">通知の受信登録</span><span class="sxs-lookup"><span data-stu-id="3709c-163">Subscribing for notifications</span></span>

<span data-ttu-id="3709c-164">特性が Indicate または Notify をサポートしているかどうかを確認します (確認するには特性のプロパティを調べます)。</span><span class="sxs-lookup"><span data-stu-id="3709c-164">Make sure the characteristic supports either Indicate or Notify (check the characteristic properties to make sure).</span></span> 

> <span data-ttu-id="3709c-165">**確保**:示す各値が変更されたイベントは、クライアント デバイスからの受信確認と組み合わせて使用するためのより信頼性が高い。</span><span class="sxs-lookup"><span data-stu-id="3709c-165">**Aside**: Indicate is considered more reliable because each value changed event is coupled with an acknowledgement from the client device.</span></span> <span data-ttu-id="3709c-166">多くの GATT トランザクションでは、非常に高い信頼性よりも電力の節約が重視されるため、Notify の方が一般的です。</span><span class="sxs-lookup"><span data-stu-id="3709c-166">Notify is more prevalent because most GATT transactions would rather conserve power rather than be extremely reliable.</span></span> <span data-ttu-id="3709c-167">いずれの場合も、そのすべてがコントローラー レイヤーで処理されるため、アプリは関与しません。</span><span class="sxs-lookup"><span data-stu-id="3709c-167">In any case, all of that is handled at the controller layer so the app does not get involved.</span></span> <span data-ttu-id="3709c-168">これらを総称して単に「通知」と呼びますが、覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="3709c-168">We'll collectively refer to them as simply "notifications" but now you know.</span></span> 

<span data-ttu-id="3709c-169">通知を取得する前に処理することが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="3709c-169">There are two things to take care of before getting notifications:</span></span>
- <span data-ttu-id="3709c-170">Client Characteristic Configuration Descriptor (CCCD) への書き込み</span><span class="sxs-lookup"><span data-stu-id="3709c-170">Write to Client Characteristic Configuration Descriptor (CCCD)</span></span>
- <span data-ttu-id="3709c-171">Characteristic.ValueChanged イベントの処理</span><span class="sxs-lookup"><span data-stu-id="3709c-171">Handle the Characteristic.ValueChanged event</span></span>

<span data-ttu-id="3709c-172">CCCD への書き込みによって、特定の特性値が変化するたびに、このクライアントでその変化を把握する必要があることを、サーバー デバイスに指示します。</span><span class="sxs-lookup"><span data-stu-id="3709c-172">Writing to the CCCD tells the Server device that this client wants to know each time that particular characteristic value changes.</span></span> <span data-ttu-id="3709c-173">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3709c-173">To do this:</span></span> 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
<span data-ttu-id="3709c-174">これで、リモート デバイスで値が変更されるたび、GattCharacteristic の ValueChanged イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3709c-174">Now, the GattCharacteristic's ValueChanged event will get called each time the value gets changed on the remote device.</span></span> <span data-ttu-id="3709c-175">あとはハンドラーを実装するだけです。</span><span class="sxs-lookup"><span data-stu-id="3709c-175">All that's left is to implement the handler:</span></span> 

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


