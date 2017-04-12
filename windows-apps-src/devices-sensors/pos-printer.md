---
author: mukin
title: "POS プリンター"
description: "この記事には、POS (店舗販売時点管理) プリンター デバイス ファミリに関する情報が含まれています"
ms.author: wdg-dev-content
ms.date: 02/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d8340af651157bb6fae82785812f259c16d0a6c0
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="pos-printer"></a>POS プリンター

アプリケーション開発者が、Epson ESC/POS プリンター制御言語を使用して、ネットワークおよび Bluetooth で接続されている[レシート プリンター](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.posprinter)で印刷できるようにします。

## <a name="requirements"></a>要件
この名前空間を必要とするアプリケーションでは、アプリ パッケージ マニフェストに "pointOfService" の [DeviceCapability](https://msdn.microsoft.com/library/4353c4fd-f038-4986-81ed-d2ec0c6235ef) を追加する必要があります。

## <a name="device-support"></a>デバイスのサポート
Windows では、Epson ESC/POS プリンター制御言語を使用して、ネットワークおよび Bluetooth で接続されているレシート プリンターで印刷する機能をサポートしています。 ESC/POS について詳しくは、[書式設定における Epson ESC/POS](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/epson-esc-pos-with-formatting)」をご覧ください。

API で公開されるクラス、列挙体、インターフェイスはレシート プリンター、スリップ プリンター、ジャーナル プリンターをサポートしていますが、ドライバー インターフェイスではレシート プリンターのみがサポートされます。 現時点でスリップ プリンターやジャーナル プリンターを使用しようとすると、未実装のステータスが返されます。

現在、サポートは、次の表に示されているネットワークおよび Bluetooth デバイス モデルに制限されます。 USB 接続されたプリンターは現在サポートされていません。 将来追加される新しいサポートを確認してください。

### <a name="stationary-pos-printers-network-bluetooth"></a>固定型 POSプリンター (ネットワーク、Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |    TM T88V、TM-T70、TM-T20、TM U220 |

### <a name="mobile-pos-printers-bluetooth"></a>モバイル POS プリンター (Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |    Mobilink P20 (TM-P20)、Mobilink P60 (TM-P60)、Mobilink P80 (TM-P80) |

## <a name="examples"></a>例
実装例については、POS プリンターのサンプルを参照してください。
+ [POS プリンターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)
