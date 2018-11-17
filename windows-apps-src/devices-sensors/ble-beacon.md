---
author: msatranjr
title: Bluetooth アドバタイズ
description: このセクションでは、API の AdvertisementWatcher と AdvertisementPublisher を使って、ユニバーサル Windows プラットフォーム (UWP) アプリに Bluetooth 低エネルギー (LE) アドバタイズを統合する方法に関する記事を取り上げています。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: ff10bbc0-03a7-492c-b5fe-c5b9ce8ca32e
ms.localizationpriority: medium
ms.openlocfilehash: 38f850cfb811260758377d5404e01c8e540e7ec2
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7169657"
---
# <a name="bluetooth-le-advertisements"></a>Bluetooth LE アドバタイズ


**重要な API**

-   [**Windows.Devices.Bluetooth.Advertisement**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.aspx)

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ向けの Bluetooth 低エネルギー (LE) アドバタイズ ビーコンの概要を示します。  

## <a name="overview"></a>概要

開発者が LE アドバタイズ API を使って実行できる機能には、主に次の 2 つがあります。

-   [アドバタイズ ウォッチャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.aspx): 近くのビーコンをリッスンし、ペイロードまたは近接度に基づいてフィルター処理します。  
-   [アドバタイズ パブリッシャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher.aspx): 開発者に代わって、Windows のペイロードを定義してアドバタイズします。  

完全なサンプル コードについては、GitHub の [Bluetooth アドバタイズ サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619990)をご覧ください。

## <a name="basic-setup"></a>基本セットアップ

ユニバーサル Windows プラットフォーム アプリで Bluetooth LE の基本的な機能を使用するには、Package.appxmanifest で Bluetooth の機能を確認する必要があります。

1. Package.appxmanifest を開きます。
2. [機能] タブに移動します。
3. 左側の一覧で Bluetooth を見つけ、その横にあるチェック ボックスをオンにします。

## <a name="publishing-advertisements"></a>アドバタイズのパブリッシュ

Bluetooth LE アドバタイズでは、デバイスから特定のペイロードを常時ビーコンできます。これをアドバタイズと呼びます。 近接範囲内にあり、この特定のアドバタイズをリッスンするように設定されたすべての Bluetooth LE 対応デバイスは、このアドバタイズを認識できます。

> **注**: アプリのユーザーのプライバシー、アドバタイズの寿命が関連付けられています。 BluetoothLEAdvertisementPublisher を作成し、バックグラウンド タスクで Start を呼び出して、バックグラウンドでアドバタイズを発行できます。 バックグラウンド タスクについて詳しくは、「[起動、再開、バックグラウンド タスク](https://msdn.microsoft.com/windows/uwp/launch-resume/index)」をご覧ください。

### <a name="basic-publishing"></a>基本的なパブリッシュ

アドバタイズにデータを追加するには、さまざまな方法があります。 この例では、会社固有のアドバタイズを作成する一般的な方法を示します。 

まず、デバイスが特定のアドバタイズをビーコンするかどうかを制御するアドバタイズ パブリッシャーを作成します。

```csharp
BluetoothLEAdvertisementPublisher publisher = new BluetoothLEAdvertisementPublisher();
```

次に、カスタム データ セクションを作成します。 この例では、未割り当ての **CompanyId** 値 *0xFFFE* を使うと共に、テキスト *Hello World* をアドバタイズに追加しています。 

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

これでパブリッシャーが作成され、セットアップされました。次に **Start** を呼び出してアドバタイズを開始します。

```csharp
publisher.Start();
```

## <a name="watching-for-advertisements"></a>アドバタイズのウォッチ

### <a name="basic-watching"></a>基本的なウォッチ

次のコードは、Bluetooth LE アドバタイズ ウォッチャーを作成し、コールバックを設定して、すべての LE アドバタイズのウォッチを開始する方法を示しています。

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

#### <a name="active-scanning"></a>アクティブ スキャン
スキャン応答のアドバタイズを併せて受信するには、ウォッチャーを作成した後、次を設定します。 この場合、電力消費量が大きくなり、またバックグラウンド モードでは使用できないことに注意してください。

```csharp
watcher.ScanningMode = BluetoothLEScanningMode.Active;
```

### <a name="watching-for-a-specific-advertisement-pattern"></a>特定のアドバタイズ パターンのウォッチ

状況によっては、特定のアドバタイズのみをリッスンする必要がある場合があります。 この例では、(0xFFFE として識別される) 作成企業が指定されたペイロードが含まれ、かつ文字列 *Hello World* が含まれたアドバタイズをリッスンします。 このコードは「基本的なパブリッシュ」の例に対応して、一方がアドバタイズする Windows マシン、もう片方がウォッチする Windows マシンとなります。 ウォッチャーを開始する前に、必ずこのアドバタイズ フィルターを設定してください。

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

### <a name="watching-for-a-nearby-advertisement"></a>近接範囲内のアドバタイズのウォッチ

アドバタイズしているデバイスが範囲内に入った場合のみ、ウォッチをトリガーするように設定することもできます。 範囲は独自に定義できますが、値は 0 ～ -128 の間にクリップされます。 

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

### <a name="gauging-distance"></a>距離の測定

Bluetooth LE ウォッチャーのコールバックがトリガーされたとき、eventArgs には受信シグナルの強さ (Bluetooth シグナルの強さ) を示す、RSSI 値が格納されています。

```csharp
private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
{
    // The received signal strength indicator (RSSI)
    Int16 rssi = eventArgs.RawSignalStrengthInDBm;
}
```

シグナルの強さからおよその距離を割り出すことができますが、電波はそれぞれ異なるため、正確な距離の測定に使うことはできません。 さまざまな環境因子が存在するため、距離の測定は困難です (電波の周囲の壁や覆い、さらに湿度によっても電波状態が左右されます)。

そこで、純粋な距離を判断する代わりに「バケット」を定義することができます。 電波は、発信源が非常に近い場合は 0 ～ -50 DBm、中程度の距離の場合は -50 ～ -90 DBm、遠く離れている場合は -90 DBm 未満を示す傾向があります。 アプリの作成にあたってこれらのバケットを判断するには、試行錯誤を繰り返すのが最良の方法です。