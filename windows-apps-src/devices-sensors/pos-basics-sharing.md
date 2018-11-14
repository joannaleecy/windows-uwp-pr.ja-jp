---
author: TerryWarwick
title: PointOfService デバイスの共有
description: PointOfService 周辺機器の共有
ms.author: jken
ms.date: 06/14/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 591ba592d1c17b03ae29c6fb98ef546bc18b8bdc
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6191316"
---
# <a name="pointofservice-device-sharing"></a>PointOfService デバイスの共有

ネットワークまたは Bluetooth 接続されている周辺機器を複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターと共有する方法について説明します。

## <a name="device-sharing"></a>デバイスの共有

ネットワークおよび Bluetooth 接続されている PointOfService 周辺機器は、通常使用環境 wheere で複数のクライアント デバイス日中同じ周辺機器を共有しています。  ビジー状態の販売チャネルまたは食料サービス環境では、クライアント デバイスの周辺機器に接続する機能の遅延は、同僚お客様と取引を閉じるし、へと移動するが、効率に影響を及ぼします。 顧客の注文の詳細を準備キッチンに転送するキッチン プリンターとしてレシート プリンターが使用されているクイック サービス レストランのシナリオで顧客の注文を受ける複数のクライアント デバイスされます。  注文が完了する各クライアント デバイスできる必要がありますが共有プリンターを要求して、すぐに、台所の順序を印刷します。

これらの環境でことが重要アプリケーションを完全にオブジェクトを**破棄**デバイス別、同じデバイスを要求できるようにします。

"Using"ブロックの終了時に pos プリンターの破棄

```Csharp 
using Windows.Devices.PointOfService;
using(PosPrinter printer = await PosPrinter.FromIdAsync("Device ID"))
{
    if (printer != null)
    {
        // Exercise the printer.
    }

    // When leaving this scope, printer.Dispose() is automatically invoked, 
    // releasing the session we have with the printer.
}
```


Dispose() を明示的に呼び出すことによって、pos プリンターの破棄

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a>API のメソッドを使用 

+ [BarcodeScanner.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [CashDrawer.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [LineDisplay.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [MagneticStripeReader.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [PosPrinter.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
