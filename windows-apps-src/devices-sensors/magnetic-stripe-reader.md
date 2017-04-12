---
author: mukin
title: "磁気ストライプ リーダー"
description: "この記事には、POS (店舗販売時点管理) デバイス ファミリの磁気ストライプ リーダーに関する情報が含まれています"
ms.author: wdg-dev-content
ms.date: 02/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a11fe7a63c0444ac986e7bfe0d50472249e5196e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="magnetic-stripe-reader"></a>磁気ストライプ リーダー

アプリケーション開発者が[磁気ストライプ リーダー](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.magneticstripereader)にアクセスして、クレジット/デビット カード、ポイント カード、アクセス カードなどの磁気ストライプ カードからデータを取得できるようにします。

## <a name="requirements"></a>要件
この名前空間を必要とするアプリケーションでは、アプリ パッケージ マニフェストに "pointOfService" の [DeviceCapability](https://msdn.microsoft.com/library/4353c4fd-f038-4986-81ed-d2ec0c6235ef) を追加する必要があります。

## <a name="device-support"></a>デバイスのサポート
### <a name="usb"></a>USB
### <a name="supported-vendor-specific"></a>サポートされているベンダー固有
Windows では、ベンダー ID と製品 ID (VID/PID) に基づいて、Magtek と IDTech の次の磁気ストライプ リーダーのサポートを提供します。

| 製造元 |     モデル |    製品番号 |
|--------------|-----------|--------------|
| IDTech | SecureMag (VID:0ACD PID:2010) | IDRE-3x5xxxx |
| |    MiniMag (VID:0ACD PID:0500) |    IDMB-3x5xxxx |
| Magtek | MagneSafe (VID:0801 PID:0011) |    210730xx |
| |    Dynamag (VID:0801 PID:0002) |    210401xx |

### <a name="custom-vendor-specific"></a>カスタムのベンダー固有
Windows では、追加の磁気ストライプ リーダーをサポートする追加のベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの有無については、磁気ストライプ リーダーの製造元に確認してください。

## <a name="examples"></a>例
実装例については、磁気ストライプ リーダーのサンプルを参照してください。
+    [磁気ストライプ リーダーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
