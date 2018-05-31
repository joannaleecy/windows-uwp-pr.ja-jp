---
author: TerryWarwick
title: バーコード スキャナーの概要
description: ユニバーサル Windows アプリケーションからバーコード スキャナーと対話する方法を説明します。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: ed0fa79f5bbdfdaf8ca1f3273fa8d741f17efe1d
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1833258"
---
# <a name="getting-started-with-barcode-scanners"></a>バーコード スキャナーの概要

ユニバーサル Windows アプリケーションからバーコード スキャナーと対話する方法を説明します。  このトピックでは、バーコード スキャナーに固有の機能に関する情報を提供します。

## <a name="configuring-your-barcode-scanner"></a>バーコード スキャナーの構成
バーコード スキャナーは、いくつかの異なるモードで構成することができます。  目的の用途に合わせてバーコード スキャナーを正しく構成することが重要です。  多くのバーコード スキャナーは、**キーボード ウェッジ** モードで構成できます。この場合、バーコード スキャナーは Windows に対してキーボードとして表示されます。  これにより、メモ帳などのバーコード スキャナーに対応していないアプリケーションにバーコードをスキャンすることができます。  このモードでバーコードをスキャンすると、キーボードを使用してデータを入力した場合と同様に、バーコード スキャナーからデコードされたデータが挿入ポイントに挿入されます。  UWP アプリからバーコード スキャナーをより細かく制御する場合は、キーボード ウェッジ以外のモードでバーコード スキャナーを構成する必要があります。

### <a name="usb-barcode-scanner"></a>USB バーコード スキャナー
USB 接続されたバーコード スキャナーは、Windows に含まれているバーコード スキャナー ドライバーで動作するように、**HID POS スキャナー** モードで構成する必要があります。 このドライバーは、[**USB-HID**](http://www.usb.org/developers/hidpage/) に公開されている **HID POS の用途に関する表**の仕様を実装したものです。  **HID POS スキャナー** モードを有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。  **HID POS スキャナー**として構成すると、バーコード スキャナーはデバイス マネージャーの **POS バーコード スキャナー** ノードに **POS HID バーコード スキャナー**として表示されます。
バーコード スキャナーの製造元が、**HID POS スキャナー**以外のモードを使用して UWP バーコード スキャナー API をサポートする、ベンダー固有のドライバーを用意している可能性もあります。  製造元が提供する UWP バーコード スキャナー API と互換性のあるドライバーを既にインストールしている場合、デバイス マネージャーの **POS バーコード スキャナー**の下に、ベンダー固有のデバイスが表示される可能性があります。

### <a name="bluetooth-barcode-scanner"></a>Bluetooth バーコード スキャナー
Bluetooth で接続されているスキャナーで UWP バーコード スキャナー API を使用するには、バーコード スキャナーを **Serial Port Protocol - Simple Serial Interface (SPP-SSI)** モードで構成する必要があります。  **SPP-SSI モード**を有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。  
Bluetooth バーコード スキャナーを使用する前に、[設定] - [デバイス] - [Bluetooth とその他のデバイス] - [Bluetooth またはその他のデバイスを追加する] の順に選択し、バーコード スキャナーをペアリングする必要があります。  
ペアリング手続きを開始および制御するには、**Windows.Devices.Enumeration** 名前空間を使用します。  詳しくは、「[**デバイスのペアリング**](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)」をご覧ください。

## <a name="working-with-symbologies"></a>シンボル体系の操作
[**バーコード シンボル体系**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。 一般的なシンボル体系には、UPC、Code 128、QR コードなどがあります。UWP バーコード スキャナー API は、スキャナーを手動で構成しなくても、アプリケーションがスキャナーでこれらのシンボル体系を処理する方法を制御できるようにします。 

### <a name="determine-which-symbologies-are-supported"></a>サポートされているシンボル体系を判断する 
複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。  これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。
[**BarcodeScanner.FromIdAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [**BarcodeScanner**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得したのち、[**GetSupportedSymbologiesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。

### <a name="determine-if-a-specific-symbology-is-supported"></a>特定のシンボル体系がサポートされているかどうかを判断する
スキャナーが特定のシンボル体系をサポートしているかどうかを判断するには、[**IsSymbologySupportedAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_) を呼び出します。

### <a name="changing-which-symbologies-are-recognized"></a>認識されるシンボル体系の変更
場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。  これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。 たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。
スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。  これは、[**ClaimScannerAsyc**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync) を使用して [**ClaimedBarcodeScanner**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) オブジェクトを設定した後で行うことができます。 [**SetActiveSymbologiesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。

### <a name="restricting-scan-data-by-data-length"></a>データ長によるスキャン データの制限
一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。  このシンボル体系のバーコードは、それぞれが特定の長さの異なるデータを含むものがまとめて配置されている場合があります。 必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。

| メソッド    | 説明 |
| :-------- | :---------- |
| [**SetSymbologyAttributesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetSymbologyAttributesAsync_System_UInt32_Windows_Devices_PointOfService_BarcodeSymbologyAttributes_) | デコードされたデータの目的の長さの範囲と、スキャナーがチェック ディジットを処理する方法を構成できます。 |
| [**GetSymbologyAttributesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_) | 現在の長さとチェック ディジットの構成を取得できます。 |

> [!Important] 
> まず、[**SetSymbologyAttributesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetSymbologyAttributesAsync_System_UInt32_Windows_Devices_PointOfService_BarcodeSymbologyAttributes_) または [**GetSymbologyAttributesAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_) プロパティを調べることによって、バーコード スキャナーがシンボル体系の属性の使用をサポートしていることを確認します。 | 現在の長さとチェック ディジットの構成を取得できます。 :
> - [**IsDecodeLengthSupported**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)
> - [**ICheckDigitTransmissionSupported**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsCheckDigitTransmissionSupported)
> - [**IsCheckDigitValidationSupported**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsCheckDigitValidationSupported)

## <a name="using-software-trigger-with-barcode-scanners"></a>バーコード スキャナーでのソフトウェア トリガーの使用
### <a name="initiate-scan-from-software"></a>ソフトウェアからスキャンを開始する
プレゼンテーション モードでバーコード スキャナーを使用している場合や、スキャナーにカメラ ベースのバーコード スキャナーなどの物理的なトリガーがない場合は、ソフトウェアからスキャンの動作を制御すると便利です。 [**StartSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync) を呼び出すことでスキャン プロセスを開始できます。  
[**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) の値に応じて、スキャナーはバーコードを 1 つだけスキャンして停止することも、[**StopSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync) を呼び出すまで継続的にスキャンすることもできます。

[**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) を目的の値に設定することで、バーコードがデコードされたときのスキャナー動作を制御します。

| 値 | 説明 |
| ----- | ----------- |
| True   | バーコードを 1 つだけスキャンして停止する |
| False  | 停止せずに継続的にバーコードをスキャンする |


> [!Important]
> まず、[**IsSoftwareTriggerSupported**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported) プロパティを調べることによって、バーコード スキャナーがソフトウェア トリガーの使用をサポートしていることを確認します。
