---
author: mukin
title: "POS デバイスのサポート"
description: "この記事には、各 POS デバイス ファミリのデバイスのサポートに関する情報が含まれています。"
ms.author: mukin
ms.date: 05/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 58018385082f7f7e49edba0351d919bc840ade05
ms.sourcegitcommit: 53930c9871461f6106f785ae4fabb2296eb359f1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2017
---
# <a name="pos-device-support"></a>POS デバイスのサポート

## <a name="barcode-scanner"></a>バーコード スキャナー
| 接続 | サポート |
| -------------|-------------|
| USB          | <p>Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続のバーコード スキャナーのインボックス クラス ドライバーが含まれています。 既知の互換性のあるデバイスの一覧については、次の表を参照してください。  USB.HID.POS Scanner モードで構成できるかどうかを調べるには、バーコード スキャナーのマニュアルを参照するか、製造元に問い合わせてください。 </p><p>Windows では、USB.HID.POS Scanner 標準をサポートしない追加のバーコード スキャナーをサポートするために、ベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの利用可能性については、バーコード スキャナーの製造元に確認してください。</p>|
| Bluetooth    | <p>Windows では、SPP-SSI ベースの Bluetooth バーコード スキャナーをサポートしています。 既知の互換性のあるデバイスの一覧については、次の表を参照してください。</p> |

### <a name="compatible-hardware"></a>互換性のあるハードウェア
| カテゴリ | 接続 | 製造元/モデル |
|--------------|-----------|-----------|
| **1D ハンドヘルド スキャナー** | **USB** |Honeywell Voyager 1200g<br/>Honeywell Voyager 1202g<br/>Honeywell Voyager 1202-bf<br/>Honeywell Voyager 145Xg (アップグレード可能)|
| **1D ハンドヘルド スキャナー** | **Bluetooth** |Socket Mobile CHS 7Ci<br/> Socket Mobile CHS 7Di<br/> Socket Mobile CHS 7Mi<br/> Socket Mobile CHS 7Pi<br/>Socket Mobile DuraScan D700<br/> Socket Mobile DuraScan D730<br/>Socket Mobile SocketScan S800 (旧 CHS 8Ci) <br/>|
|**2D ハンドヘルド スキャナー** | **USB** |Code Reader™ 950<br/>Code Reader™ 1021<br/>Code Reader™ 1421<br/> Honeywell Granit 198Xi<br/>Honeywell Granit 191Xi<br/>Honeywell Xenon 1900g<br/>Honeywell Xenon 1902g<br/>Honeywell Xenon 1902g-bf<br/>Honeywell Xenon 1900h<br/>Honeywell Xenon 1902h<br/>Honeywell Voyager 145Xg (アップグレード可能)<br/>Honeywell Voyager 1602g<br/>Intermec SG20|
|**2D ハンドヘルド スキャナー** | **Bluetooth** |Socket Mobile SocketScan S850 (旧 CHS 8Qi)|
| **プレゼンテーション スキャナー** | **USB** |Code Reader™ 5000<br/>Honeywell Genesis 7580g<br/>Honeywell Orbit 7190g|
| **インカウンター スキャナー** | **USB** |Honeywell Stratos 2700|
| **スキャン エンジン** | **USB** | Honeywell N5680<br/>Honeywell N3680|
| **Windows Mobile デバイス**| **組み込み** |Bluebird EF400<br/>Bluebird EF500<br/>Bluebird EF500R<br/>Honeywell CT50<br/>Honeywell D75e<br/>Janam XT2<br/>Panasonic FZ-E1<br/>Panasonic FZ-F1<br/>PointMobile PM80<br/>Zebra TC700j|
| **Windows Mobile デバイス**| **カスタム** | HP Elite X3 とバーコード スキャナー ジャケット |

## <a name="cash-drawer"></a>キャッシュ ドロワー
| 接続 | サポート |
| -------------|-------------|
| ネットワーク/Bluetooth | <p> キャッシュ ドロワー ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、キャッシュ ドロワーに直接接続できます。 </p>|
| DK ポート | <p> ネットワーク機能や Bluetooth 機能を持たないキャッシュ ドロワーは、サポートされている POS プリンター上の DK ポート、つまり Star Micronics DK-AirCash アクセサリ経由で接続できます。 </p>
| OPOS    | <p> OPOS ドライバーをサポートするすべてのキャッシュ ドロワー デバイスをサポートし、OPOS サービス オブジェクトを提供します。 特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。 これにより、製造元の仕様に基づいて USB やその他の接続が有効になります。 </p> |

**注:** DK-AirCash の詳細については、Star Micronics にお問い合わせください。

### <a name="networkbluetooth"></a>ネットワーク/Bluetooth
| 製造元 |    モデル |
|--------------|-----------|
| APG Cash Drawer |    NetPRO、BluePRO |

## <a name="line-display"></a>ライン ディスプレイ
OPOS ドライバーをサポートするすべてのライン ディスプレイ デバイスをサポートし、OPOS サービス オブジェクトを提供します。 特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。

## <a name="magnetic-stripe-reader"></a>磁気ストライプ リーダー

Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続の磁気ストライプ リーダーのインボックス クラス ドライバーが含まれています。

### <a name="vendor-specific-support"></a>ベンダー固有のサポート
Windows では、ベンダー ID と製品 ID (VID/PID) に基づいて、Magtek と IDTech の次の磁気ストライプ リーダーのサポートを提供します。

| 製造元 |     モデル |    製品番号 |
|--------------|-----------|--------------|
| IDTech | SecureMag (VID:0ACD PID:2010) | IDRE-3x5xxxx |
| |    MiniMag (VID:0ACD PID:0500) |    IDMB-3x5xxxx |
| Magtek | MagneSafe (VID:0801 PID:0011) |    210730xx |
| |    Dynamag (VID:0801 PID:0002) |    210401xx |

### <a name="custom-vendor-specific"></a>カスタムのベンダー固有
Windows では、追加の磁気ストライプ リーダーをサポートする追加のベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの有無については、磁気ストライプ リーダーの製造元に確認してください。

## <a name="pos-printer"></a>POS プリンター
Windows では、Epson ESC/POS プリンター制御言語を使用して、ネットワークおよび Bluetooth で接続されているレシート プリンターで印刷する機能をサポートしています。 ESC/POS について詳しくは、[書式設定における Epson ESC/POS](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/epson-esc-pos-with-formatting)」をご覧ください。

API で公開されるクラス、列挙体、インターフェイスはレシート プリンター、スリップ プリンター、ジャーナル プリンターをサポートしていますが、ドライバー インターフェイスではレシート プリンターのみがサポートされます。 現時点でスリップ プリンターやジャーナル プリンターを使用しようとすると、未実装のステータスが返されます。

| 接続 | サポート |
| -------------|-------------|
| ネットワーク/Bluetooth | <p> POS プリンター ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、POS プリンターに直接接続できます。 </p>|
| OPOS    | <p> OPOS ドライバーをサポートするすべての POS プリンター デバイスをサポートし、OPOS サービス オブジェクトを提供します。 特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。 これにより、製造元の仕様に基づいて USB やその他の接続が有効になります。 </p> |

### <a name="stationary-pos-printers-networkbluetooth"></a>固定型 POSプリンター (ネットワーク/Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |    TM T88V、TM-T70、TM-T20、TM U220 |

### <a name="mobile-pos-printers-bluetooth"></a>モバイル POS プリンター (Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |    Mobilink P20 (TM-P20)、Mobilink P60 (TM-P60)、Mobilink P80 (TM-P80) |