---
title: Bluetooth 低エネルギー
description: このトピックでは、UWP アプリで Bluetooth LE の簡単な概要を説明します。
ms.date: 03/15/2017
ms.topic: article
keywords: windows 10、uwp、bluetooth、bluetooth LE、低エネルギー、gatt、ギャップ、中央、周辺機器、クライアント、サーバー、ウォッチャー、発行元
ms.localizationpriority: medium
ms.openlocfilehash: ecc78bd4bb079adbaaa58c981ce55457c522764b
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8938124"
---
# <a name="bluetooth-low-energy"></a>Bluetooth 低エネルギー
Bluetooth 低エネルギー (LE) は、検出と電源効率の高いデバイス間で通信プロトコルを定義する仕様です。 デバイスの検出は、汎用的なアクセス プロファイル (ギャップ) プロトコルを使って行われます。 後の検出、デバイスの通信は、Generic Attribute (GATT) プロトコルを使って行われます。 このトピックでは、UWP アプリで Bluetooth LE の簡単な概要を説明します。 Bluetooth LE の詳細を参照してください[Bluetooth Core 仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0 では、Bluetooth LE が導入されました。 

![Bluetooth LE の役割](images/gatt-roles.png)

*GATT と間隔の役割は Windows 10 バージョン 1703 で導入されました。*

GATT と間隔のプロトコルは、次の名前空間を使用して、UWP アプリで実装できます。
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a>集約型と周辺機器
中央および周辺機器の検出の 2 つの主な役割と呼びます。 一般に、Windows では、一元的なモードで動作し、さまざまな周辺機器に接続します。 

## <a name="attributes"></a>属性
Windows の Bluetooth Api に表示される一般的な略語は Generic Attribute (GATT) です。 GATT プロファイルは、データの構造とモードの 2 つの Bluetooth LE デバイス通信操作を定義します。 属性は、GATT のメインの基盤です。 メインの種類の属性は、サービス、特性、記述子は。 これらの属性として実行が異なるクライアントとサーバー間で関連する」のセクションで、対話式操作を説明すると便利です。 

![一般的なプロファイルで一般的な属性の階層](images/gatt-service.png)

*心拍数サービスは、GATT サーバー API の形式で表されます。*

## <a name="client-and-server"></a>クライアントとサーバー
接続が確立された後、(通常小さい IoT センサーまたはウェアラブル) のデータが含まれているデバイスは、サーバーと呼ばれます。 そのデータを使用して、関数を実行するデバイスは、クライアントと呼ばれます。 たとえば、Windows PC (クライアント) からデータを読み取り心拍モニターを追跡するには、(サーバー)、ユーザー最適に動作しています。 詳細については、 [GATT クライアント](gatt-client.md)と[GATT サーバー](gatt-server.md)のトピックをご覧ください。

## <a name="watchers-and-publishers-beacons"></a>ウォッチャーと発行元 (ビーコン)
中央と周辺機器のロールだけでなくオブザーバーとブロードキャストの役割があります。 アナウンサーはビーコンと呼ばれるよく、しない経由で通信 GATT 通信用の広告パケットで提供されている限られたスペースを使用するためです。 同様に、オブザーバーがデータを受信する接続を確立する必要はありません、近くにある広告をスキャンします。 広告の近くにあるを観察する Windows を構成するには、 [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher)クラスを使用します。 Beacon のペイロードをブロードキャストするために、 [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher)クラスを使用します。 詳細については、[広告](ble-beacon.md)のトピックを参照してください。

## <a name="see-also"></a>参照
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Bluetooth のコアの仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)