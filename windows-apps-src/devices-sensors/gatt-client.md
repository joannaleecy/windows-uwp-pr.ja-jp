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
# <a name="bluetooth-gatt-client"></a>Bluetooth GATT クライアント


**重要な API**

-   [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

この記事では、GATT クライアントの一般的なタスクのサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性 (GATT) クライアント Api の使用を示します。
- クエリの近くにあるデバイス
- デバイスに接続します。
- サポートされているサービスおよびデバイスの特性を列挙します。
- 読み取りし、書き込み特性
- 購読特性ときの通知の値の変更

## <a name="overview"></a>概要
開発者は、 [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)名前空間の Api を使用して Bluetooth LE デバイスにアクセスします。 Bluetooth LE デバイスは、その機能をコレクションを通じて公開します。コレクションには次の情報が含まれています。

-   サービス
-   特性
-   記述子

サービスを LE デバイスの機能の契約を定義し、サービスの特性のコレクションを含みます。 これらの特性はさらに、その特性を表す記述子を含みます。 これら 3 つの条件は、一般的なデバイスの属性という名称でした。

Bluetooth LE GATT Api は、生トランスポートへのアクセスではなく、および関数のオブジェクトを公開します。 GATT Api には、次のタスクを実行する権限を持つ Bluetooth LE デバイスを操作する開発者も有効にします。

-   属性の検出を実行します。
-   読み取りおよび書き込み属性の値
-   特徴 ValueChanged イベントのコールバックを登録します。

開発者の便利な環境を構築するには、必要があります知識 GATT サービスおよび特性を使用しようとしているアプリケーションとプロセスに固有の特性の値を API によって提供されるバイナリ データを変換します。ユーザーに表示される前にデータに便利です。 Bluetooth GATT API が公開するのは、Bluetooth LE デバイスとの通信に必要な基本的なプリミティブだけです。 データを解釈するためには、Bluetooth SIG の標準のプロファイルか、デバイスのベンダーが実装したカスタム プロファイルによって、アプリケーション プロファイルを定義する必要があります。 プロファイルは、交換されるデータが表す内容や、その解釈の方法に関して、アプリケーションとデバイスとの間で交わされるバインド コントラクトを形成します。

Bluetooth SIG は、利便性向上のため、[一連のプロファイル](https://www.bluetooth.com/specifications/adopted-specifications#gattspec)を一般公開しています。

## <a name="query-for-nearby-devices"></a>クエリの近くにあるデバイス
近くにあるデバイスに対するクエリを 2 つの主な方法があります。
- Windows.Devices.Enumeration で DeviceWatcher
- Windows.Devices.Bluetooth.Advertisement で AdvertisementWatcher

第 2 の方法を説明したで[広告](ble-beacon.md)のドキュメントでは説明しません量ここでは基本的な考え方は特定の[広告のフィルター](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.advertisementfilter.aspx)を満たす近くにあるデバイスの Bluetooth アドレスを検索します。 アドレスを作成したら、デバイスへの参照を取得する[BluetoothLEDevice.FromBluetoothAddressAsync](https://msdn.microsoft.com/en-us/library/windows/apps/mt608819.aspx)を呼び出すことができます。 

ここでは、DeviceWatcher メソッドに戻る。 Bluetooth LE デバイスは Windows の他のデバイスと同じように、[列挙 Api](https://msdn.microsoft.com/library/windows/apps/BR225459)を使用して問い合わせることができます。 [DeviceWatcher](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher)クラスを使用して、検索するデバイスを指定するクエリ文字列を渡します。 

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
[DeviceWatcher を開始すると、該当のデバイスに[追加された](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.devicewatcher.added)イベント ハンドラーでクエリを満たしているデバイスごとに[DeviceInformation](https://msdn.microsoft.com/library/windows/apps/br225393)が提供されます。 DeviceWatcher で詳細を確認する、完全な[Github 上](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)の例を参照してください。 

## <a name="connecting-to-the-device"></a>デバイスに接続します。
目的のデバイスを検出すると、該当のデバイスの Bluetooth LE デバイス オブジェクトを取得するのに[DeviceInformation.Id](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.id)を使用します。 

```csharp
async void ConnectDevice(DeviceInformation deviceInfo)
{
    // Note: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
    // ...
}
```
その一方で、すべての参照を BluetoothLEDevice の破棄のデバイスのオブジェクト (と、システムの他のアプリにデバイスへの参照がないかどうか) をトリガー自動 small タイムアウトから切断します。 

```csharp
bluetoothLeDevice.Dispose();
```
アプリもう一度デバイスにアクセスする場合は、デバイス オブジェクトを再作成して、特性 (次のセクションで説明する) にアクセスするだけでトリガー OS に必要な場合をもう一度接続します。 デバイスの近くにある場合、それ以外のデバイスと DeviceUnreachable のエラーが返されますへのアクセスが表示されます。  

## <a name="enumerating-supported-services-and-characteristics"></a>サポートされているサービスとの特性を列挙します。
BluetoothLEDevice のオブジェクトがある場合は、これで、次の手順では、デバイスを公開データを検出します。 これを行うには、まずサービスのクエリを実行します。 

```csharp
GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var services = result.Services;
    // ...
}
```
次の手順で、興味のあるサービスが識別されると、特性のクエリを実行します。 

```csharp
GattCharacteristicsResult result = await service.GetCharacteristicsAsync();
                
if (result.Status == GattCommunicationStatus.Success)
{
    var characteristics = result.Characteristics;
    // ...
}
```  
OS の操作を実行できますし、オブジェクトを GattCharacteristic の読み取り専用リストを返します。

## <a name="perform-readwrite-operations-on-a-characteristic"></a>読み取り/書き込みの特徴に操作します。

特性が GATT の基本単位通信います。 デバイス上のデータの重複しない値の部分を表す値が含まれています。 たとえば、バッテリ レベルの特徴では、デバイスのバッテリ レベルを表す値があります。

どのような操作がサポートされるかを決定する特性のプロパティを参照してください。
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

読み取りがサポートされる場合は、値を読み取ることができます。 
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
特性への書き込みは次のようなパターンです。 
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
> **ヒント**: [DataReader](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datareader.aspx)と[DataWriter](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.datawriter.aspx)の使用に慣れます。 さまざまな Bluetooth Api から取得した生のバッファーを操作するときに、それぞれの機能は不可欠なできません。 
## <a name="subscribing-for-notifications"></a>通知の購読

特性を示すか、通知をサポートしているかどうかを確認 (ことを確認する特性のプロパティを確認する)。 

> **確保し、**: を示すと見なされる信頼性の高い各値が変更されましたイベントがクライアント デバイスからの応答を結合します。 通知多いは、ほとんどの GATT トランザクションとではなく電源を節約することがなく信頼性の高いためです。 どのような場合は、アプリが関与しないように、コント ローラー レイヤーで処理をされます。 それらを単に"通知] と呼びますがまとめてがわかるようになりました。 

通知を開始する前に対処する次の 2 つがあります。
- クライアントの特性の構成表して (CCCD) に書き込む
- Characteristic.ValueChanged イベントを処理します。

CCCD への書き込みをこのを知りたいたびにその特性の特定の値の変更をサーバーのデバイスに説明します。 これには、次の手順を実行します。 

```csharp
GattCommunicationStatus status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Notify);
if(status == GattCommunicationStatus.Success)
{
    // Server has been informed of clients interest.
}
```
これで、GattCharacteristic の ValueChanged イベントが呼び出されるリモート デバイス上の値を変更するたびにします。 残りのハンドラーを実装するだけです。 

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


