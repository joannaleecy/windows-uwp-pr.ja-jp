---
author: mukin
title: "バーコード スキャナー"
description: "この記事には、POS (店舗販売時点管理) デバイス ファミリのバーコード スキャナーに関する情報が含まれています"
ms.author: wdg-dev-content
ms.date: 02/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 8d9ef9bc08fa666c2af1348450f7a5fb0a0c7b65
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="barcode-scanner"></a>バーコード スキャナー
アプリケーション開発者が[バーコード スキャナー](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.barcodescanner)にアクセスして、ハードウェアからのサポートに応じて、UPC や QR コードなどのさまざまなバーコード記号表示法からデコードされたデータを取得できるようにします。 サポートされている記号表示法の一覧については、[BarcodeSymbologies](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.barcodesymbologies) クラスをご覧ください。

## <a name="requirements"></a>要件
この名前空間を必要とするアプリケーションでは、アプリ パッケージ マニフェストに "pointOfService" の [DeviceCapability](https://msdn.microsoft.com/library/4353c4fd-f038-4986-81ed-d2ec0c6235ef) を追加する必要があります。

## <a name="device-support"></a>デバイスのサポート

### <a name="usb"></a>USB

#### <a name="hidscanner"></a>HID.Scanner
Windows には、USB.org によって定義された HID.Scanner (8C) Usage Page に基づくバーコード スキャナー クラス ドライバーが含まれています。 このクラス ドライバーは、次のような、この標準を実装する任意のバーコード スキャナーをサポートしています。製造元    モデル Honeywell    1900GSR 2、1200 g-2 Intermec    SG20

USB.HID.Scanner として構成できるかどうかを調べるには、バーコード スキャナーのマニュアルを参照するか、製造元に問い合わせてください。

#### <a name="hidvendor-specific"></a>HID.Vendor 固有
Windows では、追加のバーコード スキャナーをサポートするベンダー固有のドライバーの実装をサポートしています。 デバイスがインボックス USB.HID.Scanner でサポートされていない場合は、バーコード スキャナーの製造元にドライバーの有無を確認してください。

### <a name="bluetooth"></a>Bluetooth
#### <a name="serial-port-protocol-spp--simple-serial-interface-ssi"></a>Serial Port Protocol (SPP) – Simple Serial Interface (SSI)
Windows では、SPP-SSI ベースの Bluetooth バーコード スキャナーをサポートしています。

| 製造元 |    モデル |
|--------------|-----------|
| Socket Mobile |    **CHS 7 シリーズ:** <br/> 7 Ci 1D Imager Barcode Scanner <br/> 7Di 1D Durable, Imager Barcode Scanner <br/> 7Mi 1D Laser Barcode Scanner <br/> 7Pi 1D Durable, LaserBarcode Scanner <br/> **DuraScan 700 シリーズ:** <br/> D700 1D Imager Barcode Scanner <br/> D730 1D Laser Barcode Scanner <br/> **SocketScan 800 シリーズ** <br/> S800 1D Imager Barcode Scanner (旧 CHS 8Ci) <br/> S850 2D Imager Barcode Scanner (旧 CHS 8Qi)

## <a name="examples"></a>例
実装例については、バーコード スキャナーのサンプルを参照してください。
+    [バーコード スキャナーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
