---
author: IvorB
ms.assetid: E9ADC88F-BD4F-4721-8893-0E19EA94C8BA
title: "帯域外ペアリング"
description: "帯域外ペアリングを使うと、アプリは検出を行わなくても店舗販売時点管理の周辺機器に接続できます。"
ms.author: ivorb
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ef9d4c390112be66035ab2ace6b6b799ee9d99ef
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="out-of-band-pairing"></a>帯域外ペアリング

帯域外ペアリングを使うと、アプリは検出を行わなくても店舗販売時点管理の周辺機器に接続できます。 アプリは、[**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/windows.devices.pointofservice.aspx) 名前空間を使って、専用の形式に設定された文字列 (帯域外 BLOB) を、目的の周辺機器用の適切な **FromIdAsync** メソッドに渡す必要があります。 **FromIdAsync** が実行されると、ホスト デバイスが周辺機器にペアリングして接続してから、操作が呼び出し元に返されます。

## <a name="out-of-band-blob-format"></a>帯域外 BLOB の形式

```json
    "connectionKind":"Network",
    "physicalAddress":"AA:BB:CC:DD:EE:FF",
    "connectionString":"192.168.1.1:9001",
    "peripheralKinds":"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}",
    "providerId":"{02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2}",
    "providerName":"PrinterProtocolProvider.dll"
```

**connectionKind** - 接続の種類。 有効な値は "Network" と "Bluetooth" です。

**physicalAddress** - 周辺機器の MAC アドレス。 たとえば、ネットワーク プリンターの場合は、プリンターのテスト シートに AA:BB:CC:DD:EE:FF の形式で表記される MAC アドレスです。

**connectionString** - 周辺機器の接続文字列。 たとえば、ネットワーク プリンターの場合は、プリンターのテスト シートに 192.168.1.1:9001 の形式で表記される IP アドレスです。 このフィールドは、すべての Bluetooth 周辺機器で省略されます。

**peripheralKinds** - デバイスの種類を示す GUID。 有効な値は次のとおりです。

| デバイスの種類 | GUID |
| ---- | ---- |
| *POS プリンター* | C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33 |
| *バーコード スキャナー* | C243FFBD-3AFC-45E9-B3D3-2BA18BC7EBC5 |
| *キャッシュ ドロワー* | 772E18F2-8925-4229-A5AC-6453CB482FDA |


**providerId** - プロトコル プロバイダーのクラスを示す GUID。 有効な値は次のとおりです。

| プロトコル プロバイダーのクラス | GUID |
| ---- | ---- |
| *一般的な ESC/POS ネットワーク プリンター* | 02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2 |
| *一般的な ESC/POS BT プリンター* | CCD5B810-95B9-4320-BA7E-78C223CAF418 |
| *Epson BT プリンター* | 94917594-544F-4AF8-B53B-EC6D9F8A4464 |
| *Epson ネットワーク プリンター* | 9F0F8BE3-4E59-4520-BFBA-AF77614A31CE |
| *Star ネットワーク プリンター* | 1E3A32C2-F411-4B8C-AC91-CC2C5FD21996 |
| *ソケット BT スキャナー* | 6E7C8178-A006-405E-85C3-084244885AD2 |
| *APG ネットワーク ドロワー* | E619E2FE-9489-4C74-BF57-70AED670B9B0 |
| *APG BT ドロワー* | 332E6550-2E01-42EB-9401-C6A112D80185 |


**providerName** - プロバイダー DLL の名前。 既定のプロバイダーは次のとおりです。

| プロバイダー | DLL 名 |
| ---- | ---- |
| プリンター | PrinterProtocolProvider.dll |
| キャッシュ ドロワー | CashDrawerProtocolProvider.dll |
| スキャナー | BarcodeScannerProtocolProvider.dll |

## <a name="usage-example-network-printer"></a>使用例: ネットワーク プリンター

```csharp
String oobBlobNetworkPrinter =
  "{\"connectionKind\":\"Network\"," +
  "\"physicalAddress\":\"AA:BB:CC:DD:EE:FF\"," +
  "\"connectionString\":\"192.168.1.1:9001\"," +
  "\"peripheralKinds\":\"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}\"," +
  "\"providerId\":\"{02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2}\"," +
  "\"providerName\":\"PrinterProtocolProvider.dll\"}";

printer = await PosPrinter.FromIdAsync(oobBlobNetworkPrinter);
```

## <a name="usage-example-bluetooth-printer"></a>使用例: Bluetooth プリンター

```csharp
string oobBlobBTPrinter =
    "{\"connectionKind\":\"Bluetooth\"," +
    "\"physicalAddress\":\"AA:BB:CC:DD:EE:FF\"," +
    "\"peripheralKinds\":\"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}\"," +
    "\"providerId\":\"{CCD5B810-95B9-4320-BA7E-78C223CAF418}\"," +
    "\"providerName\":\"PrinterProtocolProvider.dll\"}";

printer = await PosPrinter.FromIdAsync(oobBlobBTPrinter);

```
