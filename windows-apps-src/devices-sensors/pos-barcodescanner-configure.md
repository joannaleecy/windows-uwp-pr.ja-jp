---
title: バーコード スキャナーの構成
description: 目的の用途のバーコード スキャナーを構成する方法について説明します。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 8f88b376dca80043f88260700bb7ef4168b3a445
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8458088"
---
# <a name="configure-a-barcode-scanner"></a>バーコード スキャナーの構成

バーコード スキャナーは、いくつかの異なるモードで構成することができます。  目的の用途に合わせてバーコード スキャナーを正しく構成することが重要です。

多くのバーコード スキャナーは、**キーボード ウェッジ** モードで構成できます。この場合、バーコード スキャナーは Windows に対してキーボードとして表示されます。  これにより、メモ帳などのバーコード スキャナーに対応していないアプリケーションにバーコードをスキャンすることができます。  このモードでバーコードをスキャンすると、キーボードを使用してデータを入力した場合と同様に、バーコード スキャナーからデコードされたデータが挿入ポイントに挿入されます。  UWP アプリからバーコード スキャナーをより細かく制御する場合は、キーボード ウェッジ以外のモードでバーコード スキャナーを構成する必要があります。

## <a name="usb-barcode-scanner"></a>USB バーコード スキャナー
USB 接続されたバーコード スキャナーは、Windows に含まれているバーコード スキャナー ドライバーで動作するように、**HID POS スキャナー** モードで構成する必要があります。 このドライバーは、 [USB HID](http://www.usb.org/developers/hidpage/)に公開**HID ポイントの用途に関する表**仕様の実装です。  **HID POS スキャナー** モードを有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。  **HID POS スキャナー**として構成すると、バーコード スキャナーはデバイス マネージャーの **POS バーコード スキャナー** ノードに **POS HID バーコード スキャナー**として表示されます。

バーコード スキャナーの製造元が、**HID POS スキャナー**以外のモードを使用して UWP バーコード スキャナー API をサポートする、ベンダー固有のドライバーを用意している可能性もあります。  既に UWP バーコード スキャナー Api と互換性のある製造元によって提供されるドライバーをインストールした場合は、デバイス マネージャーで**POS バーコード スキャナー**の下に表示されるベンダー固有のデバイスを参照してください可能性があります。

## <a name="bluetooth-barcode-scanner"></a>Bluetooth バーコード スキャナー
Bluetooth で接続されているスキャナーで UWP バーコード スキャナー API を使用するには、バーコード スキャナーを **Serial Port Protocol - Simple Serial Interface (SPP-SSI)** モードで構成する必要があります。  **SPP-SSI モード**を有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。

使用してペアリングする必要があります、Bluetooth バーコード スキャナーを使用する前に**設定 > デバイス > Bluetooth とその他のデバイス > [Bluetooth またはその他のデバイス**します。

開始および[Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration)名前空間を使用して、ペアリング プロセスを制御することができます。  詳細については、「[デバイスのペアリング](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)」を参照してください。

[!INCLUDE [feedback](./includes/pos-feedback.md)]