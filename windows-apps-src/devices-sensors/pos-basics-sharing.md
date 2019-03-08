---
title: PointOfService デバイスの共有
description: PointOfService 周辺機器を他のユーザーと共有
ms.date: 06/14/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 53dc22b2aa35b5e69854f6fb489ff6a454c73bf6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618947"
---
# <a name="pointofservice-device-sharing"></a>PointOfService デバイスの共有

複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存する、環境内の他のコンピューターとネットワークまたは接続されている Bluetooth 周辺機器を共有する方法について説明します。

## <a name="device-sharing"></a>デバイスの共有

ネットワーク、Bluetooth が接続されている PointOfService 周辺機器は、通常使用する環境 wheere で複数のクライアント デバイスが、1 日を通して同じ周辺機器を共有します。  ビジー状態の製品版または食品サービス環境では、周辺機器を接続するクライアント デバイスの機能の遅延は、効率性を関連付けは、顧客とトランザクションを終了し、へと移動に影響を与えます。 準備の台所に顧客の注文の詳細を転送するキッチン プリンターとしてレシート プリンターが使用されているサービスのクイック レストランのシナリオでは、顧客から注文を受け取り、複数のクライアント デバイスがあります。  注文が完了すると各クライアント デバイスが共有プリンターを要求して、すぐにキッチンの順序を印刷することがあります。

これらの環境でことが重要にアプリケーションの完全**dispose**デバイス オブジェクトの別、同じデバイスを要求できるようにします。

'Using' ブロックの最後の PosPrinter の破棄

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


Dispose() を明示的に呼び出すことによって、PosPrinter の破棄

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a>API メソッドの使用 

+ [BarcodeScanner.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [CashDrawer.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [LineDisplay.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [MagneticStripeReader.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [PosPrinter.Dispose](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
