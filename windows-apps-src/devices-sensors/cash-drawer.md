---
author: mukin
title: "キャッシュ ドロワー"
description: "この記事には、POS (店舗販売時点管理) デバイス ファミリのキャッシュ ドロワーに関する情報が含まれています"
ms.author: wdg-dev-content
ms.date: 02/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 
ms.openlocfilehash: 376272356cf720ddd9519f0077e771a1016abb1e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="cash-drawer"></a>キャッシュ ドロワー

アプリケーション開発者が[キャッシュ ドロワー](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.cashdrawer)を操作できるようにします。

## <a name="requirements"></a>要件
この名前空間を必要とするアプリケーションでは、アプリ パッケージ マニフェストに "pointOfService" の [DeviceCapability](https://msdn.microsoft.com/library/4353c4fd-f038-4986-81ed-d2ec0c6235ef) を追加する必要があります。

## <a name="device-support"></a>デバイスのサポート
キャッシュ ドロワー ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、キャッシュ ドロワーに直接接続できます。 さらに、ネットワーク機能や Bluetooth 機能を持たないキャッシュ ドロワーは、サポートされている POS プリンター上の DK ポート、つまり Star Micronics DK-AirCash アクセサリ経由で接続できます。 現時点では、USB またはシリアル ポート経由で接続されたキャッシュ ドロワーはサポートされていません。

**注:** DK-AirCash の詳細については、Star Micronics にお問い合わせください。

### <a name="networkbluetooth"></a>ネットワーク/Bluetooth
| 製造元 |    モデル |
|--------------|-----------|
| APG Cash Drawer |    NetPRO、BluePRO |

## <a name="examples"></a>例
実装例については、キャッシュ ドロワーのサンプルを参照してください。
+    [キャッシュ ドロワーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
