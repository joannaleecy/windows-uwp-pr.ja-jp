---
author: msatranjr
title: Bluetooth 低エネルギー
description: ここでは、UWP アプリで Bluetooth LE の概要を紹介します。
ms.author: misatran
ms.date: 03/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、bluetooth、bluetooth LE、低エネルギー、gatt、ギャップ、中央、周辺、クライアント、サーバー、監視、publisher
ms.localizationpriority: medium
ms.openlocfilehash: 0d6cc1fb5a0b3cb96748b99c490b23a9e1df128f
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608806"
---
# <a name="bluetooth-low-energy"></a>Bluetooth 低エネルギー
Bluetooth 低エネルギー (LE) は、プロトコルの検出 power を効率的に使用するデバイス間の通信を定義する仕様です。 一般的なアクセス プロファイル (ギャップ) プロトコルを使って、デバイスの検出が行われます。 検出後は、一般的な属性 (GATT) プロトコルを使ってデバイスとデバイス通信が行われます。 ここでは、UWP アプリで Bluetooth LE の概要を紹介します。 Bluetooth LE に関する詳細情報を参照してください[Bluetooth コア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0、Bluetooth LE が導入されました。 

![Bluetooth LE の役割](images/gatt-roles.png)

*Windows 10 版 1703 で導入された GATT との間隔の役割*

次の名前空間を使用して、UWP アプリで GATT との間隔のプロトコルを実装できます。
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a>中央および周辺
検出の 2 つの主要な役割は、中央と周辺と呼ばれます。 一般に、Windows では、サーバーの全体のモードで動作し、周辺のさまざまなデバイスを接続します。 

## <a name="attributes"></a>属性
Windows Bluetooth Api に表示される共通の略語は、一般的な属性 (GATT) です。 GATT プロファイルは、データの構造と通信する 2 つの Bluetooth LE デバイスでの操作のモードを定義します。 属性は、GATT のメインの文書パーツです。 属性のメインの種類は、サービス、特性記述子します。 これらの属性を実行する異なるクライアントとサーバーのために、関連セクション内の相互作用を問い合わせて方が便利です。 

![一般的なプロファイルで一般的な属性の階層](images/gatt-service.png)

*ハート単価サービスは、GATT サーバー API フォームで表されます。*

## <a name="client-and-server"></a>クライアントとサーバー
接続を確立後は、(通常は小さい IoT センサーまたはウェアラブル) データが含まれているデバイスがサーバーと呼ばれます。 そのデータを使用して関数を実行するデバイスは、クライアントと呼ばれます。 たとえば、Windows PC の場合 (クライアント) からデータを読み取りハート単価モニター (サーバー) を追跡するユーザー最適に動作しています。 詳細については、 [GATT クライアント](gatt-client.md)と[GATT サーバー](gatt-server.md)のトピックを参照してください。

## <a name="watchers-and-publishers-beacons"></a>ウォッチャーと発行元 (ビーコン)
中央と周辺の役割のほか、オブザーバーとブロードキャスト発信元の役割があります。 アナウンサーはビーコンとも呼ばれます] がない間の通信 GATT コミュニケーションの広告パケットに表示される限られたスペースを使用するため。 同様に、データを受信する接続を確立する第三者がないの近くにある広告をスキャンします。 広告の近くに表示する Windows を設定するのには、 [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher)クラスを使用します。 ビーコン ペイロードをブロードキャストするために、 [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher)クラスを使用します。 詳細については、[広告](ble-beacon.md)のトピックを参照してください。

## <a name="see-also"></a>関連項目
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Bluetooth コアの仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)