---
title: Bluetooth 低エネルギー
description: このトピックでは、UWP アプリでの Bluetooth LE の概要を示します。
ms.date: 03/19/2017
ms.topic: article
keywords: Windows 10, UWP, Bluetooth, Bluetooth LE, 低エネルギー, GATT, GAP, セントラル, ペリフェラル, クライアント, サーバー, ウォッチャー, パブリッシャー
ms.localizationpriority: medium
ms.openlocfilehash: 1714a4c21852a7582325fc26f7e6a1f0f969126e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629037"
---
# <a name="bluetooth-low-energy"></a>Bluetooth 低エネルギー
Bluetooth 低エネルギー (LE) は、検出と電力効率に優れたデバイス間の通信用のプロトコルを定義する仕様です。 デバイスの検出は、汎用アクセス プロファイル (GAP) プロトコルを使って行われます。 検出後、汎用属性 (GATT) プロトコルを使ってデバイス間の通信が行われます。 このトピックでは、UWP アプリでの Bluetooth LE の概要を示します。 Bluetooth LE の詳細については、Bluetooth LE が導入された [Bluetooth コア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0 をご覧ください。 

![Bluetooth LE の役割](images/gatt-roles.png)

*GATT とのギャップの役割は、Windows 10 バージョン 1703 で導入されました。*

次の名前空間を使って、UWP アプリで GATT および GAP プロトコルを実装できます。
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a>セントラルとペリフェラル
検出での 2 つの主な役割は、セントラルおよびペリフェラルと呼ばれます。 一般に、Windows はセントラル モードで動作し、さまざまなペリフェラル (周辺機器) デバイスに接続します。 

## <a name="attributes"></a>属性
Windows の Bluetooth API でよく使用される略語として GATT (汎用属性) があります。 GATT プロファイルは、2 つの Bluetooth LE デバイスが通信する際のデータの構造と動作のモードを定義します。 属性は GATT の主要な構成要素です。 主な属性の種類として、サービス、特性、記述子があります。 これらの属性は、クライアントとサーバーでは動作が異なるため、関連するセクションでクライアントとサーバーの対話について説明する方が効率的です。 

![一般的なプロファイルでの一般的な属性階層](images/gatt-service.png)

*心拍数のサービスは GATT Server API の形式で表されます*

## <a name="client-and-server"></a>クライアントとサーバー
接続が確立されると、データを格納しているデバイス (通常、小型の IoT センサーやウェアラブル デバイス) はサーバーと呼ばれます。 そのデータを使用して機能を実行するデバイスは、クライアントと呼ばれます。 たとえば、Windows PC (クライアント) は心拍数モニター (サーバー) からデータを読み取って、ユーザーが最適な運動をしていることを追跡します。 詳しくは、「[GATT クライアント](gatt-client.md)」と「[GATT サーバー](gatt-server.md)」のトピックをご覧ください。

## <a name="watchers-and-publishers-beacons"></a>ウォッチャーとパブリッシャー (ビーコン)
セントラルとペリフェラルの役割に加えて、オブザーバーとブロードキャスターの役割があります。 ブロードキャスターは、一般的にビーコンと呼ばれ、通信のためにアドバタイズ パケットで提供されている限られた領域を使用するため、GATT 上では通信しません。 同様に、オブザーバーでは、データを受信するために接続を確立する必要はなく、近くのアドバタイズをスキャンします。 近くのアドバタイズを監視するように Windows を構成するには、[BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher) クラスを使用します。 ビーコン ペイロードをブロードキャストするには、[BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher) クラスを使用します。 詳細については、[アドバタイズ](ble-beacon.md)に関するトピックを参照してください。

## <a name="see-also"></a>関連項目
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Bluetooth のコア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)