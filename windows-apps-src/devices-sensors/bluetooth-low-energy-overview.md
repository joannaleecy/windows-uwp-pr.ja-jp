---
author: msatranjr
title: Bluetooth 低エネルギー
description: UWP のアプリケーションで Bluetooth LE の概要を説明します。
ms.author: misatran
ms.date: 03/15/2017
ms.topic: article
keywords: ウィンドウ 10、uwp、bluetooth、bluetooth LE、省電力性、gatt、ギャップ、中央、周辺機器、クライアント、サーバー、監視者、出版社
ms.localizationpriority: medium
ms.openlocfilehash: 9e5bef16c76ee14c2abb7a5a41ab02d150a97333
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919130"
---
# <a name="bluetooth-low-energy"></a>Bluetooth 低エネルギー
Bluetooth 低エネルギー (LE) は、検出および電力効率の高いデバイス間の通信用のプロトコルを定義する仕様です。 汎用アクセス プロファイル (GAP) プロトコルを使って、デバイスの検出が行われます。 検出後は、汎用的な属性 (GATT) プロトコルを使ってデバイスとデバイスの通信が行われます。 UWP のアプリケーションで Bluetooth LE の概要を説明します。 Bluetooth LE の詳細についてを参照してください[Bluetooth コア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0 では、Bluetooth の LE が導入されました。 

![Bluetooth LE の役割](images/gatt-roles.png)

*10 1703 のバージョンの Windows で導入された GATT とギャップの役割*

GATT とギャップのプロトコルは、次の名前空間を使用して、UWP のアプリで実装できます。
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a>中央および周辺機器
検出の 2 つの主要な役割は、中央と周辺機器と呼ばれます。 一般に、Windows では、中心的なモードで動作し、さまざまな周辺機器に接続します。 

## <a name="attributes"></a>属性
Windows Bluetooth Api に表示される、一般的な頭字語は、汎用的な属性 (GATT) です。 GATT のプロファイルでは、データの構造との 2 つの LE の Bluetooth デバイスが通信する操作モードを定義します。 属性は、GATT の主要なビルディング ブロックです。 メインの種類の属性は、サービス、特性および記述子です。 関連するセクションでの相互作用を説明する方が便利ですので、これらの属性はクライアントとサーバーの間とは異なる実行します。 

![共通のプロファイルの一般的な属性の階層](images/gatt-service.png)

*心拍数のサービスは、GATT サーバー API の形式で表されます。*

## <a name="client-and-server"></a>クライアントとサーバー
接続が確立されると、(通常小さい IoT センサーやウェアラブル) のデータを格納しているデバイスはサーバーと呼ばれます。 そのデータを使用して関数を実行するデバイスは、クライアントと呼ばれます。 など Windows PC (クライアント) からデータを読み取り、心拍数のモニターを追跡するには、(サーバー) ユーザー最適に動作しています。 詳細については、 [GATT のクライアント](gatt-client.md)と[サーバーの GATT](gatt-server.md)のトピックを参照してください。

## <a name="watchers-and-publishers-beacons"></a>有力者や出版社 (ビーコン)
中央および周辺機器の役割、オブザーバーと放送局の役割があります。 放送局は、ビーコンとも呼ばれます、これらしない経由で通信 GATT 通信の提供情報のパケットで提供されている限られたスペースを使用するためです。 同様に、第三者がデータを受信する接続を確立するためにの近くにある広告をスキャンします。 近くの提供情報を確認するのには Windows を構成するには、 [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher)クラスを使用します。 ペイロードのビーコンをブロードキャストするのには、 [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher)クラスを使用します。 詳細については、[提供情報](ble-beacon.md)を参照してください。

## <a name="see-also"></a>参照
- [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Windows.Devices.Bluetooth.Advertisement](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [Bluetooth コア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)