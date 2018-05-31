---
author: TerryWarwick
title: POS (店舗販売時点管理) デバイスのサポート
description: この記事には、POS (店舗販売時点管理) デバイス クラスの各ハードウェアのサポートに関する情報が含まれています
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ecb2468497115c9595f6fd17ab61b30caed507ab
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832096"
---
# <a name="supported-point-of-service-peripherals"></a>サポートされている POS 周辺機器

## <a name="barcode-scanner"></a>バーコード スキャナー
| 接続 | サポート |
| -------------|-------------|
| USB          | <p>Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続バーコード スキャナー用インボックス クラス ドライバーが含まれています。互換性のある既知のデバイスの一覧については、次の表をご覧ください。  **USB.HID.POS Scanner** モードでスキャナーを構成する方法については、バーコード スキャナーのマニュアルを参照するか、製造元にお問い合わせください。 </p><p>Windows では、USB.HID.POS Scanner 標準をサポートしない追加のバーコード スキャナーをサポートするために、ベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの利用可能性については、バーコード スキャナーの製造元に確認してください。</p><p>バーコード スキャナーのメーカー様は、カスタム バーコード スキャナー ドライバーの作成については、[バーコード スキャナー ドライバー設計ガイド](https://aka.ms/pointofservice-drv)をご覧ください。</p> |
| Bluetooth    | <p>Windows では、Serial Port Protocol - Simple Serial Interface (SPP-SSI) ベースの Bluetooth バーコード スキャナーがサポートされています。 既知の互換性のあるデバイスの一覧については、次の表を参照してください。 **SPP-SSI** モードでスキャナーを構成する方法については、バーコード スキャナーのマニュアルを参照するか、製造元にお問い合わせください。</p> |
| Web カメラ       | <p>Windows 10 バージョン 1803 以降では、ユニバーサル Windows アプリケーションから標準のカメラ レンズでバーコードを読み取ることができます。 オート フォーカスと 1920 x 1440 以上の解像度をサポートするカメラを使用することをお勧めします。  バーコードが十分な大きさで印刷されている場合、これより解像度の低いカメラでも標準的なバーコードを読み取ることができる可能性があります。  バーコードの要素が細い場合は、より高い解像度のカメラが必要になる可能性があります。</p>| 
|


### <a name="compatible-barcode-scanners"></a>互換性のあるバーコード スキャナー
| カテゴリ | 接続 | 製造元/モデル |
|--------------|-----------|-----------|
| **1D ハンドヘルド スキャナー** | **USB** |Honeywell Voyager 1200g<br/>Honeywell Voyager 1202g<br/>Honeywell Voyager 1202-bf<br/>Honeywell Voyager 145Xg (アップグレード可能)|
| **1D ハンドヘルド スキャナー** | **Bluetooth** |Socket Mobile CHS 7Ci<br/> Socket Mobile CHS 7Di<br/> Socket Mobile CHS 7Mi<br/> Socket Mobile CHS 7Pi<br/>Socket Mobile DuraScan D700<br/> Socket Mobile DuraScan D730<br/>Socket Mobile SocketScan S800 (旧 CHS 8Ci) <br/>|
|**2D ハンドヘルド スキャナー** | **USB** |Code Reader™ 950<br/>Code Reader™ 1021<br/>Code Reader™ 1421<br/> Honeywell Granit 198Xi<br/>Honeywell Granit 191Xi<br/>Honeywell Xenon 1900g<br/>Honeywell Xenon 1902g<br/>Honeywell Xenon 1902g-bf<br/>Honeywell Xenon 1900h<br/>Honeywell Xenon 1902h<br/>Honeywell Voyager 145Xg (アップグレード可能)<br/>Honeywell Voyager 1602g<br/>Intermec SG20<br/>Zebra DS2278<br/>Zebra DS8108 ¹<hr><small>¹ 最小ファームウェア 016 (2018.01.18) が必要です。 [123Scan](http://www.zebra.com/123Scan) を使用してアップグレード可能</small>|
|**2D ハンドヘルド スキャナー** | **Bluetooth** |Socket Mobile SocketScan S850 (旧 CHS 8Qi)|
| **プレゼンテーション スキャナー** | **USB** |Code Reader™ 5000<br/>Honeywell Genesis 7580g<br/>Honeywell Orbit 7190g|
| **インカウンター スキャナー** | **USB** |Honeywell Stratos 2700|
| **スキャン エンジン** | **USB** | Honeywell N5680<br/>Honeywell N3680|
| **Windows Mobile デバイス**| **組み込み** |Bluebird EF400<br/>Bluebird EF500<br/>Bluebird EF500R<br/>Honeywell CT50<br/>Honeywell D75e<br/>Janam XT2<br/>Panasonic FZ-E1<br/>Panasonic FZ-F1<br/>PointMobile PM80<br/>Zebra TC700j|
| **Windows Mobile デバイス**| **カスタム** | HP Elite X3 とバーコード スキャナー ジャケット |


## <a name="cash-drawer"></a>キャッシュ ドロワー
| 接続 | サポート |
| -------------|-------------|
| ネットワーク/Bluetooth | <p> キャッシュ ドロワー ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、キャッシュ ドロワーに直接接続できます。 </p><p>APG Cash Drawer: NetPRO、BluePRO</p> |
| DK ポート | <p> ネットワーク機能や Bluetooth 機能を持たないキャッシュ ドロワーは、サポートされているレシート プリンター上の DK ポートまたは Star Micronics DK-AirCash アクセサリ経由で接続できます。 </p>
| OPOS    | <p> 製造元から提供される OPOS サービス オブジェクトを介して、すべての OPOS 互換キャッシュ ドロワーをサポートします。 デバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。 </p> |


## <a name="customer-display-linedisplay"></a>カスタマー ディスプレイ (LineDisplay)
製造元から提供される OPOS サービス オブジェクトを介して、すべての OPOS 互換ライン ディスプレイをサポートします。 デバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。

## <a name="magnetic-stripe-reader"></a>磁気ストライプ リーダー
Windows では、ベンダー ID と製品 ID (VID/PID) に基づいて、Magtek と IDTech の次の磁気ストライプ リーダーのサポートを提供します。

| 製造元 |    モデル |  製品番号 |
|--------------|-----------|--------------|
| IDTech | SecureMag (VID:0ACD PID:2010) | IDRE-3x5xxxx |
| | MiniMag (VID:0ACD PID:0500) |   IDMB-3x5xxxx |
| Magtek | MagneSafe (VID:0801 PID:0011) |  210730xx |
| | Dynamag (VID:0801 PID:0002) |   210401xx |

 Windows では、追加の磁気ストライプ リーダーをサポートする追加のベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの有無については、磁気ストライプ リーダーの製造元に確認してください。 磁気ストライプ リーダーのメーカー様は、カスタム磁気ストライプ リーダー ドライバーの作成については、[磁気ストライプ リーダー設計ガイド](https://aka.ms/pointofservice-drv)をご覧ください。

## <a name="receipt-printer-posprinter"></a>レシート プリンター (POSPrinter)
| 接続 | サポート |
| -------------|-------------|
| ネットワークと Bluetooth | <p>Windows では、Epson ESC/POS プリンター制御言語を使用して、ネットワークおよび Bluetooth で接続されているレシート プリンターをサポートしています。  以下に示すプリンターは、POSPrinter API を使用して自動的に検出されます。 ESC/POS エミュレーションを提供するその他のレシート プリンターも使用できる可能性がありますが、[帯域外ペアリング](https://aka.ms/pointofservice-oobpairing) プロセスを使用して関連付ける必要があります。</p><p>注: この方法では、スリップ ステーションとジャーナル ステーションはサポートされません。</p> |
| OPOS    | <p> OPOS サービス オブジェクトを介して、OPOS 互換のレシート プリンターをサポートします。 デバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。 </p> |

### <a name="stationary-receipt-printers-networkbluetooth"></a>固定型レシート プリンター (ネットワーク/Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |   TM T88V、TM-T70、TM-T20、TM U220 |

### <a name="mobile-receipt-printers-bluetooth"></a>モバイル レシート プリンター (Bluetooth)
| 製造元 |    モデル |
|--------------|-----------|
| Epson |   Mobilink P20 (TM-P20)、Mobilink P60 (TM-P60)、Mobilink P80 (TM-P80) |
