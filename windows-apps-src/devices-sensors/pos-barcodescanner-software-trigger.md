---
author: eliotcowley
title: ソフトウェア トリガーの使用
description: ソフトウェアからスキャンの動作を制御する方法について説明します。
ms.author: elcowle
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 03fbed5a0145a093b1e7a2535012077644aaf2e2
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5974130"
---
# <a name="use-a-software-trigger"></a><span data-ttu-id="c5ded-104">ソフトウェア トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="c5ded-104">Use a software trigger</span></span>

<span data-ttu-id="c5ded-105">プレゼンテーション モードでバーコード スキャナーを使用している場合や、スキャナーにカメラ ベースのバーコード スキャナーなどの物理的なトリガーがない場合は、ソフトウェアからスキャンの動作を制御すると便利です。</span><span class="sxs-lookup"><span data-stu-id="c5ded-105">It can be useful to control the act of scanning from software if you are using a barcode scanner in presentation mode or if the scanner does not have a physical trigger such as a camera-based barcode scanner.</span></span> <span data-ttu-id="c5ded-106">[StartSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync) を呼び出すことでスキャン プロセスを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c5ded-106">You can initiate the scan process by calling [StartSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync).</span></span>

<span data-ttu-id="c5ded-107">[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) の値に応じて、スキャナーはバーコードを 1 つだけスキャンして停止することも、[StopSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync) を呼び出すまで継続的にスキャンすることもできます。</span><span class="sxs-lookup"><span data-stu-id="c5ded-107">Depending on the value of [IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) the scanner may scan only one barcode then stop or scan continuously until you call [StopSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync).</span></span>

<span data-ttu-id="c5ded-108">[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) を目的の値に設定することで、バーコードがデコードされたときのスキャナー動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="c5ded-108">Set the desired value of [IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) to control the scanner behavior when a barcode is decoded.</span></span>

| <span data-ttu-id="c5ded-109">値</span><span class="sxs-lookup"><span data-stu-id="c5ded-109">Value</span></span> | <span data-ttu-id="c5ded-110">説明</span><span class="sxs-lookup"><span data-stu-id="c5ded-110">Description</span></span> |
| ----- | ----------- |
| <span data-ttu-id="c5ded-111">True</span><span class="sxs-lookup"><span data-stu-id="c5ded-111">True</span></span>   | <span data-ttu-id="c5ded-112">バーコードを 1 つだけスキャンして停止する</span><span class="sxs-lookup"><span data-stu-id="c5ded-112">Scan only one barcode then stop</span></span> |
| <span data-ttu-id="c5ded-113">False</span><span class="sxs-lookup"><span data-stu-id="c5ded-113">False</span></span>  | <span data-ttu-id="c5ded-114">停止せずに継続的にバーコードをスキャンする</span><span class="sxs-lookup"><span data-stu-id="c5ded-114">Continuously scan barcodes without stopping</span></span> |


> [!Important]
> <span data-ttu-id="c5ded-115">まず、[IsSoftwareTriggerSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported) プロパティを調べることによって、バーコード スキャナーがソフトウェア トリガーの使用をサポートしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c5ded-115">Confirm that your barcode scanner supports the use of software trigger by first checking the property [IsSoftwareTriggerSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported).</span></span>

<span data-ttu-id="c5ded-116">次の例では、1 つのバーコードをスキャン後のスキャンを停止は、ソフトウェアのトリガーを使用してスキャンを開始する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c5ded-116">The following example shows how to initiate scanning using a software trigger, which will stop scanning once it scans one barcode:</span></span>

```cs
private void SoftwareTrigger(BarcodeScanner barcodeScanner, ClaimedBarcodeScanner claimedBarcodeScanner) 
{
    if (barcodeScanner.Capabilities.IsSoftwareTriggerSupported)
    {
        claimedBarcodeScanner.IsDisabledOnDataReceived = true;
        await claimedBarcodeScanner.StartSoftwareTriggerAsync();
    }
}
```

[!INCLUDE [feedback](./includes/pos-feedback.md)]