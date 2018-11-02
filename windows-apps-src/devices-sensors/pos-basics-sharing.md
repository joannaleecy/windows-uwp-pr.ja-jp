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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5937165"
---
# <a name="pointofservice-device-sharing"></a><span data-ttu-id="33fd3-104">PointOfService デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="33fd3-104">PointOfService device sharing</span></span>

<span data-ttu-id="33fd3-105">複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターとネットワークまたは Bluetooth 接続されている周辺機器を共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="33fd3-105">Learn how to share network or Bluetooth connected peripherals with other computers in an environment where multiple PCs rely on shared peripherals rather than dedicated peripherals attached to each computer.</span></span>

## <a name="device-sharing"></a><span data-ttu-id="33fd3-106">デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="33fd3-106">Device sharing</span></span>

<span data-ttu-id="33fd3-107">ネットワークおよび Bluetooth 接続されている PointOfService 周辺機器は、通常使用する環境 wheere で複数のクライアント デバイス日中同じ周辺機器を共有しています。</span><span class="sxs-lookup"><span data-stu-id="33fd3-107">Network and Bluetooth connected PointOfService peripherals are typically used in an environment wheere multiple client devices are sharing the same peripherals throughout the day.</span></span>  <span data-ttu-id="33fd3-108">ビジー状態の販売チャネルまたは食料サービス環境では、クライアント デバイスの周辺機器に接続する機能の遅延はされるため、関連付けることができます、その顧客との取引を閉じるし、へと移動効率に影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="33fd3-108">In a busy retail or food services environment any delay in the ability for a client device to attach to a peripheral has an impact on the efficiency in which an associate can close a transaction with the customer and move on to the next.</span></span> <span data-ttu-id="33fd3-109">キッチン準備のために、顧客の注文の詳細を転送するキッチン プリンターとしてレシート プリンターが使用されているサービスのクイック レストランのシナリオでは、顧客の注文を受ける複数のクライアント デバイスがあります。</span><span class="sxs-lookup"><span data-stu-id="33fd3-109">In a quick service restaurant scenario where a receipt printer is used as a kitchen printer to transfer the details of a customer's order to the kitchen for preparation there will be multiple client devices taking orders from customers.</span></span>  <span data-ttu-id="33fd3-110">順序が完了する各クライアント デバイスできる必要がありますが、共有のプリンターを要求して、台所の順序をすぐに印刷します。</span><span class="sxs-lookup"><span data-stu-id="33fd3-110">Once the order is complete each client device should be able to claim the shared printer and immediately print the order for the kitchen.</span></span>

<span data-ttu-id="33fd3-111">これらの環境でことが重要アプリケーションを完全にオブジェクトを**破棄**デバイス別、同じデバイスを要求できるようにします。</span><span class="sxs-lookup"><span data-stu-id="33fd3-111">In these environments, it is important for the application to fully **dispose** the device object so that another can claim the same device.</span></span>

<span data-ttu-id="33fd3-112">"Using"ブロックの終了時に pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="33fd3-112">Disposing of a PosPrinter at the end of a ‘using’ block</span></span>

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


<span data-ttu-id="33fd3-113">Dispose() を明示的に呼び出すことによって、pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="33fd3-113">Disposing of a PosPrinter by calling Dispose() explicitly</span></span>

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a><span data-ttu-id="33fd3-114">API のメソッドを使用</span><span class="sxs-lookup"><span data-stu-id="33fd3-114">API methods used</span></span> 

+ [<span data-ttu-id="33fd3-115">BarcodeScanner.Dispose</span><span class="sxs-lookup"><span data-stu-id="33fd3-115">BarcodeScanner.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [<span data-ttu-id="33fd3-116">CashDrawer.Dispose</span><span class="sxs-lookup"><span data-stu-id="33fd3-116">CashDrawer.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [<span data-ttu-id="33fd3-117">LineDisplay.Dispose</span><span class="sxs-lookup"><span data-stu-id="33fd3-117">LineDisplay.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [<span data-ttu-id="33fd3-118">MagneticStripeReader.Dispose</span><span class="sxs-lookup"><span data-stu-id="33fd3-118">MagneticStripeReader.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [<span data-ttu-id="33fd3-119">PosPrinter.Dispose</span><span class="sxs-lookup"><span data-stu-id="33fd3-119">PosPrinter.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
