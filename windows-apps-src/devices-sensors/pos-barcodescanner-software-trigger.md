---
title: ソフトウェア トリガーの使用
description: ソフトウェアのスキャンの動作を制御する方法について説明します。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 2b6f06ea66767a1bcdd7e20fa05aa7af275eb892
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645527"
---
# <a name="use-a-software-trigger"></a><span data-ttu-id="5ced8-104">ソフトウェア トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="5ced8-104">Use a software trigger</span></span>

<span data-ttu-id="5ced8-105">プレゼンテーション モードでバーコード スキャナーを使用している場合や、スキャナーにカメラ ベースのバーコード スキャナーなどの物理的なトリガーがない場合は、ソフトウェアからスキャンの動作を制御すると便利です。</span><span class="sxs-lookup"><span data-stu-id="5ced8-105">It can be useful to control the act of scanning from software if you are using a barcode scanner in presentation mode or if the scanner does not have a physical trigger such as a camera-based barcode scanner.</span></span> <span data-ttu-id="5ced8-106">スキャン プロセスを開始するには呼び出すことによって[StartSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync)します。</span><span class="sxs-lookup"><span data-stu-id="5ced8-106">You can initiate the scan process by calling [StartSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync).</span></span>

<span data-ttu-id="5ced8-107">値に応じて[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) 1 つだけのバーコードをスキャンし、停止またはを呼び出すまで継続的にスキャンがスキャナー [StopSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync)します。</span><span class="sxs-lookup"><span data-stu-id="5ced8-107">Depending on the value of [IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) the scanner may scan only one barcode then stop or scan continuously until you call [StopSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync).</span></span>

<span data-ttu-id="5ced8-108">目的の値を設定[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived)バーコードをデコードすると、スキャナーの動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="5ced8-108">Set the desired value of [IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) to control the scanner behavior when a barcode is decoded.</span></span>

| <span data-ttu-id="5ced8-109">Value</span><span class="sxs-lookup"><span data-stu-id="5ced8-109">Value</span></span> | <span data-ttu-id="5ced8-110">説明</span><span class="sxs-lookup"><span data-stu-id="5ced8-110">Description</span></span> |
| ----- | ----------- |
| <span data-ttu-id="5ced8-111">True</span><span class="sxs-lookup"><span data-stu-id="5ced8-111">True</span></span>   | <span data-ttu-id="5ced8-112">バーコードを 1 つだけスキャンして停止する</span><span class="sxs-lookup"><span data-stu-id="5ced8-112">Scan only one barcode then stop</span></span> |
| <span data-ttu-id="5ced8-113">False</span><span class="sxs-lookup"><span data-stu-id="5ced8-113">False</span></span>  | <span data-ttu-id="5ced8-114">停止せずに継続的にバーコードをスキャンする</span><span class="sxs-lookup"><span data-stu-id="5ced8-114">Continuously scan barcodes without stopping</span></span> |


> [!Important]
> <span data-ttu-id="5ced8-115">バーコード スキャナーが最初にプロパティをチェックして、ソフトウェア トリガーの使用をサポートしていることを確認します。 [IsSoftwareTriggerSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported)します。</span><span class="sxs-lookup"><span data-stu-id="5ced8-115">Confirm that your barcode scanner supports the use of software trigger by first checking the property [IsSoftwareTriggerSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported).</span></span>

<span data-ttu-id="5ced8-116">次の例では、1 つのバーコードをスキャン後のスキャンを停止するが、ソフトウェアのトリガーを使用してスキャンを開始する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="5ced8-116">The following example shows how to initiate scanning using a software trigger, which will stop scanning once it scans one barcode:</span></span>

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