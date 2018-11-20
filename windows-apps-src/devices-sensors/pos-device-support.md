---
author: TerryWarwick
title: POS (店舗販売時点管理) デバイスのサポート
description: この記事には、POS (店舗販売時点管理) デバイス クラスの各ハードウェアのサポートに関する情報が含まれています
ms.author: jken
ms.date: 06/13/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: df6e2c15260759f164a37b68365e0268633b22d5
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419448"
---
# <a name="supported-point-of-service-peripherals"></a>サポートされている POS 周辺機器

## <a name="barcode-scanner"></a>バーコード スキャナー
| 接続 | サポート |
| -------------|-------------|
| USB          | <p>Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続バーコード スキャナー用インボックス クラス ドライバーが含まれています。互換性のある既知のデバイスの一覧については、次の表をご覧ください。  **USB.HID.POS Scanner** モードでスキャナーを構成する方法については、バーコード スキャナーのマニュアルを参照するか、製造元にお問い合わせください。 </p><p>Windows では、USB.HID.POS Scanner 標準をサポートしない追加のバーコード スキャナーをサポートするために、ベンダー固有のドライバーの実装をサポートしています。 ベンダー固有のドライバーの利用可能性については、バーコード スキャナーの製造元に確認してください。</p><p>バーコード スキャナーのメーカー様は、カスタム バーコード スキャナー ドライバーの作成については、[バーコード スキャナー ドライバー設計ガイド](https://aka.ms/pointofservice-drv)をご覧ください。</p> |
| Bluetooth    | <p>Windows では、Serial Port Protocol - Simple Serial Interface (SPP-SSI) ベースの Bluetooth バーコード スキャナーがサポートされています。 既知の互換性のあるデバイスの一覧については、次の表を参照してください。 **SPP-SSI** モードでスキャナーを構成する方法については、バーコード スキャナーのマニュアルを参照するか、製造元にお問い合わせください。</p> |
| Web カメラ       | <p>Windows 10 バージョン 1803 以降では、ユニバーサル Windows アプリケーションから標準のカメラ レンズでバーコードを読み取ることができます。 オート フォーカスと 1920 x 1440 以上の解像度をサポートするカメラを使用することをお勧めします。  バーコードが十分な大きさで印刷されている場合、これより解像度の低いカメラでも標準的なバーコードを読み取ることができる可能性があります。  バーコードの要素が細い場合は、より高い解像度のカメラが必要になる可能性があります。</p>| 
|


| 製造元  | モデル                          | 機能 | [接続]    | 種類         | Mode                      |
|---------------|--------------------------------|------------|--------------|--------------|---------------------------|
| コード          | Reader™ 950                    | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| コード          | Reader™ 1021                   | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| コード          | Reader™ 1421                   | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| コード          | Reader™ 5000                   | 2 D         | USB          | プレゼンテーション | HID POS スキャナー           |
| Honeywell     | Genesis 7580 g                  | 2 D         | USB          | プレゼンテーション | HID POS スキャナー           |
| Honeywell     | Granit 198Xi                   | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Granit 191Xi                   | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | N5680                          | 2 D         | 内部     | コンポーネント    | HID POS スキャナー           |
| Honeywell     | N3680                          | 2 D         | 内部     | コンポーネント    | HID POS スキャナー           |
| Honeywell     | オービット 7190 g                    | 2 D         | USB          | プレゼンテーション | HID POS スキャナー           |
| Honeywell     | Stratos 2700                   | 2 D         | USB          | カウンター   | HID POS スキャナー           |
| Honeywell     | Voyager 1200 g                  | 1D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Voyager 1202 g                  | 1D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Voyager 1202-bf                | 1D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Voyager 145Xg                  | 1D/2 D ¹   | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Voyager 1602 g                  | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Xenon 1900 g                    | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Xenon 1902 g                    | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Xenon 1902g-bf                 | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Xenon 1900h                    | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Honeywell     | Xenon 1902h                    | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| HP            | バーコード スキャナーの値 (HR2150) | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Intermec      | SG20                           | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Socket Mobile | CHS 7Ci                        | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | CHS 7Di                        | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | CHS 7mi                        | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | CHS 7Pi                        | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | CHS 8Ci                        | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | DuraScan D700                  | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | DuraScan D730                  | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | DuraScan D740                  | 2 D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | SocketScan S700                | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | SocketScan S730                | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | SocketScan S740                | 2 D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | SocketScan S800                | 1D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Socket Mobile | SocketScan S850                | 2 D         | Bluetooth    | ハンドヘルド     | シリアル ポート プロファイル (SPP) |
| Zebra         | DS2278                         | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
| Zebra         | DS8108²                        | 2 D         | USB          | ハンドヘルド     | HID POS スキャナー           |
|


Honeywell でバーコードを 2D をサポートするために ¹ Upgradable <br/>
² 最小ファームウェア 016 (2018.01.18) が必要です。 アップグレード Zebra [123 scan](http://www.zebra.com/123Scan)を使用します。 


<hr>

### <a name="windows-devices-with-built-in-barcode-scanner"></a>組み込みのバーコード スキャナーを使った Windows デバイス
| 製造元   | モデル | オペレーティング システム |
|----------------|-------|------------------|
| Innowi         | ChecOut M | Windows 10   |

### <a name="windows-mobile-devices-with-built-in-barcode-scanner"></a>組み込みのバーコード スキャナーを持つ Windows Mobile デバイス
| 製造元   | モデル | オペレーティング システム |
|----------------|-------|------------------|
| Bluebird       | EF400 | Windows Mobile   |
| Bluebird       | EF500 | Windows Mobile   |
| Bluebird       | EF500R | Windows Mobile   |
| Honeywell      | CT50   | Windows Mobile   |
| Honeywell      | D75e | Windows Mobile   |
| Janam          | XT2      | Windows Mobile   |
| Panasonic      | FZ-E1 | Windows Mobile   |
| Panasonic      | FZ-F1 |Windows Mobile   |
| PointMobile    | PM80 | Windows Mobile   |
| Zebra          | TC700j | Windows Mobile   |
| HP             | Elite X3 ジャケット | Windows Mobile   |




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
