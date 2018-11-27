---
title: Bluetooth GATT クライアント
description: この記事では、一般的な用途のサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリの Bluetooth 汎用属性プロファイル (GATT) のクライアントの概要を示します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3ae656b473a4dd5999588057b0ec970645703eec
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7703599"
---
# <a name="bluetooth-gatt-client"></a>Bluetooth GATT クライアント


**重要な API**

-   [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

この記事では、一般的な GATT クライアント タスクのサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth Generic Attribute (GATT) クライアント Api の使用方法を示しています。
- 近くにあるデバイスの照会
- デバイスへの接続します。
- サポートされているサービスとデバイスの特性を列挙します。
- 読み取りし、書き込み特性
- 通知の特性と値の変更をサブスクライブします。

## <a name="overview"></a>概要
開発者は、Bluetooth LE デバイスにアクセスするのに[**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)名前空間の Api を使用できます。 Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。

-   サービス
-   特性
-   記述子

サービスは、LE デバイスの機能的なコントラクトを定義し、サービスを定義する特性のコレクションを含めます。 これらの特性はさらに、その特性を表す記述子を含みます。 これら 3 つの用語は、一般的なデバイスの属性と呼ばれます。

Bluetooth LE GATT Api は、生のトランスポートへのアクセスではなく、オブジェクトと関数を公開します。 GATT Api には、次のタスクを実行する機能で Bluetooth LE デバイスと連携する開発者も有効にします。

-   属性の検出を実行します。
-   読み取りと書き込みの属性の値
-   特性の ValueChanged イベントのコールバックを登録します。

開発者は便利な実装を作成するには、必要があります予備知識を処理し、GATT のサービスと特性を使用しようとするアプリケーションの特定の特性値は、API によって提供されるバイナリ データに変換するようユーザーに提示する前に有用なデータ。 Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。 データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。 プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。

Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。

## <a name="query-for-nearby-devices"></a>近くにあるデバイスの照会
近くのデバイスを照会する主な方法は 2 つです。
- Windows.Devices.Enumeration で DeviceWatcher
- Windows.Devices.Bluetooth.Advertisement で AdvertisementWatcher

2 番目の方法が説明されているで[アドバタイズ](ble-beacon.md)のドキュメントに、説明しませんが多くここでは、基本的な概念が特定の[アドバタイズ フィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)を満たす近くのデバイスの Bluetooth アドレスを確認します。 アドレスを作成したら、デバイスへの参照を取得するのには、 [BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx)を呼び出すことができます。 

ここでは、DeviceWatcher メソッドに戻ります。 Bluetooth LE デバイスは、他のデバイスで Windows と同様、[列挙 Api](https://msdn.microsoft.com/library/windows/apps/BR225459)を使用して照会できます。 [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher)クラスを使って、検索するデバイスを指定するクエリ文字列を渡します。 

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
DeviceWatcher を開始した後は、対象のデバイスの[追加された](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added)イベントのハンドラーで、クエリに適合するデバイスごとに[DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393)が表示されます。 DeviceWatcher の詳細については、完全な[github](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)サンプルを参照してください。 

## <a name="connecting-to-the-device"></a>デバイスに接続します。
目的のデバイスを検出すると、対象のデバイスの Bluetooth LE デバイス オブジェクトを取得するのに[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id)を使用します。 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
その一方で、破棄、BluetoothLEDevice に対するすべての参照デバイス オブジェクト (と、システムでは、その他のアプリに、デバイスへの参照がないかどうか) をトリガーする自動小さなタイムアウト期間後に切断されます。 

```csharp
bluetoothLeDevice.Dispose();
```
アプリは、デバイスに再度アクセスする必要がある場合は、単に、デバイス オブジェクトを再作成して (次のセクションで説明します) の特性へのアクセスと再ときの接続に必要な OS がトリガーされます。 デバイスが近くにある場合は、それ以外のデバイスで DeviceUnreachable エラーが返されますへのアクセスが表示されます。  

## <a name="enumerating-supported-services-and-characteristics"></a>サポートされているサービスと特性を列挙します。
BluetoothLEDevice オブジェクトがある場合は、これで、次の手順は、デバイスが公開するどのようなデータを検出するには これを行うには、最初の手順が、サービスを照会します。 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
次の手順で、関心のあるサービスが識別されると、特性を照会します。 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
GattCharacteristic の読み取り専用リスト オブジェクトで操作をし実行する、OS が返されます。

## <a name="perform-readwrite-operations-on-a-characteristic"></a>読み取り/書き込み特性で操作します。

特性は、GATT の基本単位ベースの通信です。 デバイス上のデータの異なる部分を表す値が含まれています。 たとえば、バッテリ レベルの特性では、デバイスのバッテリ レベルを表す値があります。

特性のプロパティを調べて、どのような操作がサポートされているを参照してください。
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
> **ヒント**: [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)を使ってに慣れてを取得します。 Bluetooth Api の多くはから取得した raw バッファーを使用する場合、それらの機能は不可欠なできません。 
## <a name="subscribing-for-notifications"></a>通知のサブスクライブ

特性を示すまたは通知のいずれかをサポートするかどうかを確認 (チェック特性のプロパティを確認します)。 

> **確保**: 示すと見なされる信頼性の高い値が変化したイベントごとに、クライアント デバイスからの応答と組み合わされるためです。 通知が GATT 取引のほとんどはではなく電力を節約ではなく非常に信頼性が高くなるためにより一般的です。 どのような場合は、アプリは関与しないために、コント ローラー レイヤーで処理、そのすべてされます。 単に"notifications"としてそれらをまとめて呼びますがわかっているようになりました。 

これには通知を取得する前に対処する次の 2 つがあります。
- クライアント特性構成記述子 (CCCD) への書き込み
- Characteristic.ValueChanged イベントを処理します。

CCCD への書き込みは、このクライアントがその特定の特性値の変更を毎回に知っておく必要があることをサーバー デバイスに指示します。 これには、次の手順を実行します。 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
これで、GattCharacteristic の ValueChanged イベントを取得するたびに呼び出さ値は、リモート デバイスで変更を取得します。 ハンドラーを実装するだけです。 

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


