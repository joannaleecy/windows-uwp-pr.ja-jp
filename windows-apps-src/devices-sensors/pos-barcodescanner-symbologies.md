---
author: TerryWarwick
title: バーコード スキャナーのシンボル体系の使用
description: この記事には、バーコード スキャナーのシンボル体系に関する情報が含まれています。
ms.author: jken
ms.date: 05/3/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: f6e03d62316a1b842330f39ac958e4471a895815
ms.sourcegitcommit: dc3389ef2e2c94b324872a086877314d6f963358
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/11/2018
ms.locfileid: "1874529"
---
# <a name="working-with-symbologies"></a>シンボル体系の操作
[バーコード シンボル体系](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。 一般的なシンボル体系には、UPC、Code 128、QR コードなどがあります。UWP バーコード スキャナー API は、スキャナーを手動で構成しなくても、アプリケーションがスキャナーでこれらのシンボル体系を処理する方法を制御できるようにします。 

## <a name="determine-which-symbologies-are-supported"></a>サポートされているシンボル体系を判断する 
複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。  これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。
[BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得した後で、[GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。

## <a name="determine-if-a-specific-symbology-is-supported"></a>特定のシンボル体系がサポートされているかどうかを判断する
スキャナーが特定のシンボル体系をサポートしているかどうかを判断するには、[IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_) を呼び出します。

## <a name="changing-which-symbologies-are-recognized"></a>認識されるシンボル体系の変更
場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。  これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。 たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。
スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。  これは、[ClaimScannerAsyc](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync) を使用して [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) オブジェクトを設定した後で行うことができます。 [SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。

## <a name="restricting-scan-data-by-data-length"></a>データ長によるスキャン データの制限
一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。  このシンボル体系のバーコードは、それぞれが特定の長さの異なるデータを含むものがまとめて配置されている場合があります。 必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。

| メソッド    | 説明 |
| :-------- | :---------- |
| [SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetSymbologyAttributesAsync_System_UInt32_Windows_Devices_PointOfService_BarcodeSymbologyAttributes_) | デコードされたデータの目的の長さの範囲と、スキャナーがチェック ディジットを処理する方法を構成できます。 |
| [GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_) | 現在の長さとチェック ディジットの構成を取得できます。 |

> [!Important] 
> まず、次のプロパティを調べることによって、バーコード スキャナーがシンボル体系の属性の使用をサポートしていることを確認します。 
> - [IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)
> - [ICheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsCheckDigitTransmissionSupported)
> - [IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsCheckDigitValidationSupported)
