---
title: ソフトウェア トリガーの使用
description: ソフトウェアからスキャンの動作を制御する方法について説明します。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 2b6f06ea66767a1bcdd7e20fa05aa7af275eb892
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7986576"
---
# <a name="use-a-software-trigger"></a>ソフトウェア トリガーの使用

プレゼンテーション モードでバーコード スキャナーを使用している場合や、スキャナーにカメラ ベースのバーコード スキャナーなどの物理的なトリガーがない場合は、ソフトウェアからスキャンの動作を制御すると便利です。 [StartSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync) を呼び出すことでスキャン プロセスを開始できます。

[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) の値に応じて、スキャナーはバーコードを 1 つだけスキャンして停止することも、[StopSoftwareTriggerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync) を呼び出すまで継続的にスキャンすることもできます。

[IsDisabledOnDataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) を目的の値に設定することで、バーコードがデコードされたときのスキャナー動作を制御します。

| 値 | 説明 |
| ----- | ----------- |
| True   | バーコードを 1 つだけスキャンして停止する |
| False  | 停止せずに継続的にバーコードをスキャンする |


> [!Important]
> まず、[IsSoftwareTriggerSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities.issoftwaretriggersupported#Windows_Devices_PointOfService_BarcodeScannerCapabilities_IsSoftwareTriggerSupported) プロパティを調べることによって、バーコード スキャナーがソフトウェア トリガーの使用をサポートしていることを確認します。

次の例では、バーコードを 1 つのスキャン後にスキャンが停止、ソフトウェアのトリガーを使用してスキャンを開始する方法を示します。

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