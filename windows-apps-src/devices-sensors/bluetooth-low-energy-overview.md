---
title: Bluetooth 低エネルギー
description: このトピックでは、UWP アプリで Bluetooth LE の簡単な概要を示します。
ms.date: 03/15/2017
ms.topic: article
keywords: windows 10、uwp、bluetooth、bluetooth LE、低エネルギー、gatt、ギャップ、中央、周辺機器、クライアント、サーバー、ウォッチャー、発行元
ms.localizationpriority: medium
ms.openlocfilehash: 3853003e54e58b3949c248fb03cb0a83e2d6d112
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7983952"
---
# <a name="bluetooth-low-energy"></a>Bluetooth 低エネルギー
Bluetooth 低エネルギー (LE) は、プロトコルの検出、電源効率の高いデバイス間の通信を定義する仕様です。 デバイスの検出は、汎用的なアクセス プロファイル (ギャップ) プロトコルを使って行われます。 後の検出、デバイスの通信は、Generic Attribute (GATT) プロトコルを使って行われます。 このトピックでは、UWP アプリで Bluetooth LE の簡単な概要を示します。 Bluetooth LE の詳細を参照してください[Bluetooth Core 仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0 では、Bluetooth LE が導入されました。 

![Bluetooth LE の役割](images/gatt-roles.png)

*Windows 10 バージョン 1703 で導入された GATT と間隔の役割*

GATT およびギャップ プロトコルは、次の名前空間を使用して、UWP アプリで実装できます。
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a>集約型と周辺機器
中央および周辺機器の検出の 2 つの主な役割と呼びます。 一般に、Windows では、一元的なモードで動作し、さまざまな周辺機器に接続します。 

## <a name="attributes"></a>属性
Windows の Bluetooth Api に表示される一般的な略語は Generic Attribute (GATT) です。 GATT プロファイルは、データの構造とモードの 2 つの Bluetooth LE デバイスが通信する操作を定義します。 属性は、GATT のメインの基盤です。 メインの種類の属性は、サービス、特性、記述子は。 これらの属性として実行が異なるクライアントとサーバー間で関連する」のセクションで、対話式操作を説明すると便利です。 

![一般的なプロファイルで一般的な属性階層](images/gatt-service.png)

*心拍サービスは、GATT サーバー API の形式で表されます。*

## <a name="client-and-server"></a>クライアントとサーバー
接続が確立された後、(通常は小さな IoT センサーまたはウェアラブル) のデータが含まれているデバイスは、サーバーと呼ばれます。 そのデータを使用して、関数を実行するデバイスは、クライアントと呼ばれます。 たとえば、Windows PC (クライアント) からデータを読み取り心拍モニターを追跡するには、(サーバー)、ユーザー最適に動作しています。 詳細については、 [GATT クライアント](gatt-client.md)と[GATT サーバー](gatt-server.md)のトピックをご覧ください。

## <a name="watchers-and-publishers-beacons"></a>ウォッチャーと発行元 (ビーコン)
中央と周辺機器ロール、オブザーバーとブロードキャストの役割があります。 アナウンサーはビーコンと呼ばれる一般的、しない経由で通信 GATT 通信用の広告パケットで提供されている限られたスペースを使用するためです。 同様に、オブザーバーがデータを受信する接続を確立する必要はありません、近くにある広告をスキャンします。 広告の近くにあるを観察する Windows を構成するには、 [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher)クラスを使用します。 Beacon のペイロードをブロードキャストするために、 [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher)クラスを使用します。 詳細については、[広告](ble-beacon.md)のトピックを参照してください。

## <a name="see-also"></a>参照
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Bluetooth のコアの仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)