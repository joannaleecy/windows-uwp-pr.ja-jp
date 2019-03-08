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
# <a name="bluetooth-gatt-client"></a>Bluetooth GATT クライアント


**重要な API**

-   [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性 (GATT) クライアント API の使用方法を、一般的な GATT クライアント タスクのサンプル コードを使って示します。
- 近くのデバイスの照会
- デバイスへの接続
- デバイスでサポートされているサービスやデバイスの特性の列挙
- 特性の読み取りと書き込み
- 特性値が変化したときの通知の受信登録

## <a name="overview"></a>概要
開発者は、[**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) 名前空間の API を使って Bluetooth LE デバイスにアクセスすることができます。 Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。

-   サービス
-   特性
-   記述子

サービスは、LE デバイスの機能的なコントラクトを定義するもので、サービスを定義する特性のコレクションを含みます。 これらの特性はさらに、その特性を表す記述子を含みます。 これら 3 つの用語は、一般的に、デバイスの属性と呼ばれます。

Bluetooth LE GATT API は、生のトランスポートにアクセスするのではなく、オブジェクトと関数を公開します。 また、GATT API で Bluetooth LE デバイスと連携することによって、次のことが可能となります。

-   属性の検出の実行
-   属性値の読み取りと書き込み
-   特性の ValueChanged イベントで呼び出されるコールバックの登録

実用的なアプリケーションを作成するためには、利用する GATT のサービスと特性についての予備知識が開発者に求められます。実際に必要な特性値を処理し、API から提供されるバイナリ データを実用的なデータに変換したうえで、ユーザーに提示しなければなりません。 Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。 データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。 プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。

Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。

## <a name="query-for-nearby-devices"></a>近くのデバイスの照会
近くのデバイスを照会するための主なメソッドは 2 つあります。
- Windows.Devices.Enumeration の DeviceWatcher
- Windows.Devices.Bluetooth.Advertisement の AdvertisementWatcher

2 つ目のメソッドについては、[アドバタイズ](ble-beacon.md)に関するドキュメントで詳しく説明されているため、ここでは簡単に説明します。基本的な考え方は、特定の[アドバタイズ フィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)の条件を満たす、近くにあるデバイスの Bluetooth アドレスを検出するということです。 アドレスを検出したら、[BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx) を呼び出して、デバイスへの参照を取得します。 

DeviceWatcher メソッドの説明に戻ります。 Bluetooth LE デバイスは、Windows の他のデバイスと同じように[列挙 API](https://msdn.microsoft.com/library/windows/apps/BR225459) を使って照会できます。 [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher) クラスを使用して、検索するデバイスを指定するクエリ文字列を渡します。 

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
DeviceWatcher を開始すると、対象のデバイスの [Added](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added) イベントのハンドラーで、クエリを満たすデバイスごとに [DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393) を受信します。 DeviceWatcher について詳しくは、[Github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing) にある完全なサンプルをご覧ください。 

## <a name="connecting-to-the-device"></a>デバイスへの接続
目的のデバイスが検出されたら、[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id) を使用して、対象のデバイスの Bluetooth LE デバイス オブジェクトを取得します。 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
一方、デバイスの BluetoothLEDevice オブジェクトへのすべての参照を破棄すると (システム上の他のアプリがそのデバイスを参照していない場合)、短いタイムアウト期間後に自動切断がトリガーされます。 

```csharp
bluetoothLeDevice.Dispose();
```
アプリが再びデバイスにアクセスする必要がある場合は、単にデバイス オブジェクトを再作成して特性にアクセスする (次のセクションで説明します) と、必要に応じて、OS による再接続がトリガーされます。 デバイスが近くにある場合は、デバイスへのアクセスが取得されます。近くにない場合は、DeviceUnreachable エラーと共に制御が戻ります。  

## <a name="enumerating-supported-services-and-characteristics"></a>サポートされているサービスと特性の列挙
BluetoothLEDevice オブジェクトが取得されたので、次の手順はデバイスが公開するデータを検出することです。 これを行うための最初の手順は、サービスの照会です。 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
対象のサービスが識別されたら、次の手順は特性の照会です。 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
OS は、操作を実行できる対象の GattCharacteristic オブジェクトの読み取り専用のリストを返します。

## <a name="perform-readwrite-operations-on-a-characteristic"></a>特性の読み取り/書き込み操作の実行

特性は、GATT ベースの通信の基本単位です。 これには、デバイス上の各種データを表す値が含まれています。 たとえば、バッテリ レベル特性には、デバイスのバッテリ レベルを表す値が含まれます。

特性のプロパティを読み取って、どのような操作がサポートされているかを特定します。
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

読み取りがサポートされている場合は、値を読み取ることができます。 
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
特性への書き込みは、同様のパターンに従います。 
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
> **ヒント**:使用してに慣れます[DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[datawriter の各](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)します。 多くの Bluetooth API から取得した未加工バッファーを操作するときは、これらの機能が不可欠です。 
## <a name="subscribing-for-notifications"></a>通知の受信登録

特性が Indicate または Notify をサポートしているかどうかを確認します (確認するには特性のプロパティを調べます)。 

> **確保**:示す各値が変更されたイベントは、クライアント デバイスからの受信確認と組み合わせて使用するためのより信頼性が高い。 多くの GATT トランザクションでは、非常に高い信頼性よりも電力の節約が重視されるため、Notify の方が一般的です。 いずれの場合も、そのすべてがコントローラー レイヤーで処理されるため、アプリは関与しません。 これらを総称して単に「通知」と呼びますが、覚えておいてください。 

通知を取得する前に処理することが 2 つあります。
- Client Characteristic Configuration Descriptor (CCCD) への書き込み
- Characteristic.ValueChanged イベントの処理

CCCD への書き込みによって、特定の特性値が変化するたびに、このクライアントでその変化を把握する必要があることを、サーバー デバイスに指示します。 これには、次の手順を実行します。 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
これで、リモート デバイスで値が変更されるたび、GattCharacteristic の ValueChanged イベントが呼び出されます。 あとはハンドラーを実装するだけです。 

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


