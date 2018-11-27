---
title: PointOfService デバイスの共有
description: PointOfService 周辺機器の共有
ms.date: 06/14/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 53dc22b2aa35b5e69854f6fb489ff6a454c73bf6
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7699089"
---
# <a name="pointofservice-device-sharing"></a><span data-ttu-id="8c5f8-104">PointOfService デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="8c5f8-104">PointOfService device sharing</span></span>

<span data-ttu-id="8c5f8-105">ネットワークまたは Bluetooth 接続されている周辺機器を複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターと共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-105">Learn how to share network or Bluetooth connected peripherals with other computers in an environment where multiple PCs rely on shared peripherals rather than dedicated peripherals attached to each computer.</span></span>

## <a name="device-sharing"></a><span data-ttu-id="8c5f8-106">デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="8c5f8-106">Device sharing</span></span>

<span data-ttu-id="8c5f8-107">ネットワークおよび Bluetooth 接続されている PointOfService 周辺機器は、通常使用環境 wheere で複数のクライアント デバイス日中同じ周辺機器を共有しています。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-107">Network and Bluetooth connected PointOfService peripherals are typically used in an environment wheere multiple client devices are sharing the same peripherals throughout the day.</span></span>  <span data-ttu-id="8c5f8-108">ビジー状態の販売チャネルまたは食料サービス環境では、クライアント デバイスの周辺機器に接続する機能の遅延は、同僚お客様と取引を閉じるし、へと移動するが、効率に影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-108">In a busy retail or food services environment any delay in the ability for a client device to attach to a peripheral has an impact on the efficiency in which an associate can close a transaction with the customer and move on to the next.</span></span> <span data-ttu-id="8c5f8-109">顧客の注文の詳細を準備キッチンに転送するキッチン プリンターとしてレシート プリンターが使用されているクイック サービス レストランのシナリオで顧客の注文を受ける複数のクライアント デバイスされます。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-109">In a quick service restaurant scenario where a receipt printer is used as a kitchen printer to transfer the details of a customer's order to the kitchen for preparation there will be multiple client devices taking orders from customers.</span></span>  <span data-ttu-id="8c5f8-110">注文が完了する各クライアント デバイスできる必要がありますが共有プリンターを要求して、すぐに、台所の順序を印刷します。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-110">Once the order is complete each client device should be able to claim the shared printer and immediately print the order for the kitchen.</span></span>

<span data-ttu-id="8c5f8-111">これらの環境でことが重要アプリケーションを完全にオブジェクトを**破棄**デバイス別、同じデバイスを要求できるようにします。</span><span class="sxs-lookup"><span data-stu-id="8c5f8-111">In these environments, it is important for the application to fully **dispose** the device object so that another can claim the same device.</span></span>

<span data-ttu-id="8c5f8-112">"Using"ブロックの終了時に pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="8c5f8-112">Disposing of a PosPrinter at the end of a ‘using’ block</span></span>

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


<span data-ttu-id="8c5f8-113">Dispose() を明示的に呼び出すことによって、pos プリンターの破棄</span><span class="sxs-lookup"><span data-stu-id="8c5f8-113">Disposing of a PosPrinter by calling Dispose() explicitly</span></span>

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a><span data-ttu-id="8c5f8-114">API のメソッドを使用</span><span class="sxs-lookup"><span data-stu-id="8c5f8-114">API methods used</span></span> 

+ [<span data-ttu-id="8c5f8-115">BarcodeScanner.Dispose</span><span class="sxs-lookup"><span data-stu-id="8c5f8-115">BarcodeScanner.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [<span data-ttu-id="8c5f8-116">CashDrawer.Dispose</span><span class="sxs-lookup"><span data-stu-id="8c5f8-116">CashDrawer.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [<span data-ttu-id="8c5f8-117">LineDisplay.Dispose</span><span class="sxs-lookup"><span data-stu-id="8c5f8-117">LineDisplay.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [<span data-ttu-id="8c5f8-118">MagneticStripeReader.Dispose</span><span class="sxs-lookup"><span data-stu-id="8c5f8-118">MagneticStripeReader.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [<span data-ttu-id="8c5f8-119">PosPrinter.Dispose</span><span class="sxs-lookup"><span data-stu-id="8c5f8-119">PosPrinter.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
