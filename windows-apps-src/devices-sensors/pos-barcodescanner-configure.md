---
author: TerryWarwick
title: バーコード スキャナーを構成します。
description: 目的の用途のバーコード スキャナーを構成する方法について説明します。
ms.author: jken
ms.date: 08/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: b33c1d33fe88a09de36e8f80a3034b915d338861
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3122985"
---
# <a name="configure-a-barcode-scanner"></a><span data-ttu-id="3e969-104">バーコード スキャナーを構成します。</span><span class="sxs-lookup"><span data-stu-id="3e969-104">Configure a barcode scanner</span></span>

<span data-ttu-id="3e969-105">バーコード スキャナーは、いくつかの異なるモードで構成することができます。</span><span class="sxs-lookup"><span data-stu-id="3e969-105">Barcode scanners can be configured in several different modes.</span></span>  <span data-ttu-id="3e969-106">目的の用途に合わせてバーコード スキャナーを正しく構成することが重要です。</span><span class="sxs-lookup"><span data-stu-id="3e969-106">It is important for your barcode scanner to be configured properly for the intended application.</span></span>

<span data-ttu-id="3e969-107">多くのバーコード スキャナーは、**キーボード ウェッジ** モードで構成できます。この場合、バーコード スキャナーは Windows に対してキーボードとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e969-107">Many barcode scanners can be configured in **keyboard wedge** mode which makes the barcode scanner appear as a keyboard to Windows.</span></span>  <span data-ttu-id="3e969-108">これにより、メモ帳などのバーコード スキャナーに対応していないアプリケーションにバーコードをスキャンすることができます。</span><span class="sxs-lookup"><span data-stu-id="3e969-108">This allows you to scan barcodes into applications that are not barcode scanner aware such as Notepad.</span></span>  <span data-ttu-id="3e969-109">このモードでバーコードをスキャンすると、キーボードを使用してデータを入力した場合と同様に、バーコード スキャナーからデコードされたデータが挿入ポイントに挿入されます。</span><span class="sxs-lookup"><span data-stu-id="3e969-109">When you scan a barcode in this mode, the decoded data from the barcode scanner gets inserted at your insertion point as if you typed the data using your keyboard.</span></span>  <span data-ttu-id="3e969-110">UWP アプリからバーコード スキャナーをより細かく制御する場合は、キーボード ウェッジ以外のモードでバーコード スキャナーを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e969-110">If you want more control over your barcode scanner from your UWP application, you will need to configure it in a non-keyboard wedge mode.</span></span>

## <a name="usb-barcode-scanner"></a><span data-ttu-id="3e969-111">USB バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="3e969-111">USB barcode scanner</span></span>
<span data-ttu-id="3e969-112">USB 接続されたバーコード スキャナーは、Windows に含まれているバーコード スキャナー ドライバーで動作するように、**HID POS スキャナー** モードで構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e969-112">A USB connected barcode scanner must be configured in **HID POS Scanner** mode to work with the barcode scanner driver that is included in Windows.</span></span> <span data-ttu-id="3e969-113">このドライバーは、 [USB HID](http://www.usb.org/developers/hidpage/)に公開**HID ポイントの用途に関する表**仕様の実装です。</span><span class="sxs-lookup"><span data-stu-id="3e969-113">This driver is an implementation of the **HID Point of Sale Usage Tables** specification published to [USB-HID](http://www.usb.org/developers/hidpage/).</span></span>  <span data-ttu-id="3e969-114">**HID POS スキャナー** モードを有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="3e969-114">Please refer to your barcode scanner documentation or contact your barcode scanner manufacturer for instructions to enable the **HID POS Scanner** mode.</span></span>  <span data-ttu-id="3e969-115">**HID POS スキャナー**として構成すると、バーコード スキャナーはデバイス マネージャーの **POS バーコード スキャナー** ノードに **POS HID バーコード スキャナー**として表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e969-115">Once configured as a **HID POS Scanner** your barcode scanner will appear in Device Manager under the **POS Barcode Scanner** node as **POS HID Barcode scanner**.</span></span>

<span data-ttu-id="3e969-116">バーコード スキャナーの製造元が、**HID POS スキャナー**以外のモードを使用して UWP バーコード スキャナー API をサポートする、ベンダー固有のドライバーを用意している可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="3e969-116">Your barcode scanner manufacturer may also have a vendor specific driver that supports the UWP Barcode Scanner APIs using a mode other than **HID POS Scanner**.</span></span>  <span data-ttu-id="3e969-117">既に UWP バーコード スキャナー Api と互換性のある製造元が提供する、ドライバーをインストールした場合は、 **POS バーコード スキャナー**デバイス マネージャーでの下に表示ベンダー固有のデバイスを表示があります。</span><span class="sxs-lookup"><span data-stu-id="3e969-117">If you have already installed a manufacturer-provided driver compatible with UWP Barcode Scanner APIs, you may see a vendor-specific device listed under **POS Barcode Scanner** in Device Manager.</span></span>

## <a name="bluetooth-barcode-scanner"></a><span data-ttu-id="3e969-118">Bluetooth バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="3e969-118">Bluetooth barcode scanner</span></span>
<span data-ttu-id="3e969-119">Bluetooth で接続されているスキャナーで UWP バーコード スキャナー API を使用するには、バーコード スキャナーを **Serial Port Protocol - Simple Serial Interface (SPP-SSI)** モードで構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e969-119">A Bluetooth connected scanner must be configured in **Serial Port Protocol - Simple Serial Interface (SPP-SSI)** mode to work with the UWP Barcode Scanner APIs.</span></span>  <span data-ttu-id="3e969-120">**SPP-SSI モード**を有効にする手順については、バーコード スキャナーの説明書を参照するか、バーコード スキャナーの製造元にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="3e969-120">Please refer to your barcode scanner documentation or contact your barcode scanner manufacturer for instructions to enable the **SPP-SSI mode**.</span></span>

<span data-ttu-id="3e969-121">使用してペアリングする必要があります、Bluetooth バーコード スキャナーを使用する前に**設定 > デバイス > Bluetooth とその他のデバイス > [Bluetooth またはその他のデバイス**します。</span><span class="sxs-lookup"><span data-stu-id="3e969-121">Before you can use your Bluetooth barcode scanner you must pair it using **Settings > Devices > Bluetooth & other devices > Add Bluetooth or other device**.</span></span>

<span data-ttu-id="3e969-122">開始し、 [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration)名前空間を使用して、ペアリング プロセスを制御できます。</span><span class="sxs-lookup"><span data-stu-id="3e969-122">You can initiate and control the pairing process using the [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration) namespace.</span></span>  <span data-ttu-id="3e969-123">詳細については、「[デバイスのペアリング](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3e969-123">See [Pair Devices](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices) for more information.</span></span>

[!INCLUDE [feedback](./includes/pos-feedback.md)]