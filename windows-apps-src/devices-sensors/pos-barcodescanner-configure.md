---
title: バーコード スキャナーの構成
description: 目的のアプリケーションのバーコード スキャナーを構成する方法について説明します。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 792fb50858620ff5dd269a0d7a3b8e491b9f247b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57591067"
---
# <a name="configure-a-barcode-scanner"></a>バーコード スキャナーの構成

バーコード スキャナーは、いくつかの異なるモードで構成することができます。  目的の用途に合わせてバーコード スキャナーを正しく構成することが重要です。

多くのバーコード スキャナーは、**キーボード ウェッジ** モードで構成できます。この場合、バーコード スキャナーは Windows に対してキーボードとして表示されます。  これにより、メモ帳などのバーコード スキャナーに対応していないアプリケーションにバーコードをスキャンすることができます。  このモードでバーコードをスキャンすると、キーボードを使用してデータを入力した場合と同様に、バーコード スキャナーからデコードされたデータが挿入ポイントに挿入されます。  UWP アプリからバーコード スキャナーをより細かく制御する場合は、キーボード ウェッジ以外のモードでバーコード スキャナーを構成する必要があります。

## <a name="usb-barcode-scanner"></a>USB バーコード スキャナー
USB 接続されたバーコード スキャナーは、Windows に含まれているバーコード スキャナー ドライバーで動作するように、**HID POS スキャナー** モードで構成する必要があります。 このドライバーは、実装、 **HID ポイントの販売 Usage Tables**に発行された仕様[USB HID](https://www.usb.org/developers/hidpage/)します。  **HID POS スキャナー** モードを有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。  **HID POS スキャナー**として構成すると、バーコード スキャナーはデバイス マネージャーの **POS バーコード スキャナー** ノードに **POS HID バーコード スキャナー**として表示されます。

バーコード スキャナーの製造元が、**HID POS スキャナー**以外のモードを使用して UWP バーコード スキャナー API をサポートする、ベンダー固有のドライバーを用意している可能性もあります。  バーコード スキャナーの UWP Api と互換性のある製造元で提供されるドライバーを既にインストールした場合、下に一覧表示、ベンダー固有のデバイスを参照してください可能性があります**POS バーコード スキャナー**デバイス マネージャーでします。

## <a name="bluetooth-barcode-scanner"></a>Bluetooth バーコード スキャナー
Bluetooth で接続されているスキャナーで UWP バーコード スキャナー API を使用するには、バーコード スキャナーを **Serial Port Protocol - Simple Serial Interface (SPP-SSI)** モードで構成する必要があります。  **SPP-SSI モード**を有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。

使用してペアリングする必要があります、Bluetooth のバーコード スキャナーを使用する前に**設定 > デバイス > Bluetooth (& a) その他のデバイス > Bluetooth の追加または他のデバイス**します。

開始しを使用してペアリング プロセスを制御することができます、 [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration)名前空間。  参照してください[ペア デバイス](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)詳細についてはします。

[!INCLUDE [feedback](./includes/pos-feedback.md)]