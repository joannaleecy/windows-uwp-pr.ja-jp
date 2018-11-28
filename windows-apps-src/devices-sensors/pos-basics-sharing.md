---
title: PointOfService デバイスの共有
description: PointOfService 周辺機器の共有
ms.date: 06/14/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 53dc22b2aa35b5e69854f6fb489ff6a454c73bf6
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7853397"
---
# <a name="pointofservice-device-sharing"></a><span data-ttu-id="23f87-104">PointOfService デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="23f87-104">PointOfService device sharing</span></span>

<span data-ttu-id="23f87-105">複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターとネットワークまたは Bluetooth 接続されている周辺機器を共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="23f87-105">Learn how to share network or Bluetooth connected peripherals with other computers in an environment where multiple PCs rely on shared peripherals rather than dedicated peripherals attached to each computer.</span></span>

## <a name="device-sharing"></a><span data-ttu-id="23f87-106">デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="23f87-106">Device sharing</span></span>

<span data-ttu-id="23f87-107">ネットワークおよび Bluetooth 接続されている PointOfService 周辺機器は、通常使用する環境 wheere で複数のクライアント デバイス日中同じ周辺機器を共有しています。</span><span class="sxs-lookup"><span data-stu-id="23f87-107">Network and Bluetooth connected PointOfService peripherals are typically used in an environment wheere multiple client devices are sharing the same peripherals throughout the day.</span></span>  <span data-ttu-id="23f87-108">製品版または食料サービスの負荷が高い環境では、クライアント デバイスの周辺機器に接続する機能の遅延は、同僚、その顧客との取引を閉じるし、へと移動するが、効率に影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="23f87-108">In a busy retail or food services environment any delay in the ability for a client device to attach to a peripheral has an impact on the efficiency in which an associate can close a transaction with the customer and move on to the next.</span></span> <span data-ttu-id="23f87-109">キッチン準備のために、顧客の注文の詳細を転送するキッチン プリンターとしてレシート プリンターが使用されているサービスのクイック レストランのシナリオでは複数のクライアント デバイス顧客からの注文が受けるされます。</span><span class="sxs-lookup"><span data-stu-id="23f87-109">In a quick service restaurant scenario where a receipt printer is used as a kitchen printer to transfer the details of a customer's order to the kitchen for preparation there will be multiple client devices taking orders from customers.</span></span>  <span data-ttu-id="23f87-110">注文が完了する各クライアント デバイスできる必要がありますが共有プリンターを要求してすぐに、台所の順序を印刷します。</span><span class="sxs-lookup"><span data-stu-id="23f87-110">Once the order is complete each client device should be able to claim the shared printer and immediately print the order for the kitchen.</span></span>

<span data-ttu-id="23f87-111">これらの環境でことが重要アプリケーションを完全にオブジェクトを**破棄**デバイス別、同じデバイスを要求できるようにします。</span><span class="sxs-lookup"><span data-stu-id="23f87-111">In these environments, it is important for the application to fully **dispose** the device object so that another can claim the same device.</span></span>

<span data-ttu-id="23f87-112">"Using"ブロックの終了時に pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="23f87-112">Disposing of a PosPrinter at the end of a ‘using’ block</span></span>

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


<span data-ttu-id="23f87-113">Dispose() を明示的に呼び出すことによって、pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="23f87-113">Disposing of a PosPrinter by calling Dispose() explicitly</span></span>

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a><span data-ttu-id="23f87-114">API のメソッドを使用</span><span class="sxs-lookup"><span data-stu-id="23f87-114">API methods used</span></span> 

+ [<span data-ttu-id="23f87-115">BarcodeScanner.Dispose</span><span class="sxs-lookup"><span data-stu-id="23f87-115">BarcodeScanner.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [<span data-ttu-id="23f87-116">CashDrawer.Dispose</span><span class="sxs-lookup"><span data-stu-id="23f87-116">CashDrawer.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [<span data-ttu-id="23f87-117">LineDisplay.Dispose</span><span class="sxs-lookup"><span data-stu-id="23f87-117">LineDisplay.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [<span data-ttu-id="23f87-118">MagneticStripeReader.Dispose</span><span class="sxs-lookup"><span data-stu-id="23f87-118">MagneticStripeReader.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [<span data-ttu-id="23f87-119">PosPrinter.Dispose</span><span class="sxs-lookup"><span data-stu-id="23f87-119">PosPrinter.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
