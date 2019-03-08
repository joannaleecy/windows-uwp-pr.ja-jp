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
# <a name="pointofservice-device-sharing"></a><span data-ttu-id="68a66-104">PointOfService デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="68a66-104">PointOfService device sharing</span></span>

<span data-ttu-id="68a66-105">複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存する、環境内の他のコンピューターとネットワークまたは接続されている Bluetooth 周辺機器を共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="68a66-105">Learn how to share network or Bluetooth connected peripherals with other computers in an environment where multiple PCs rely on shared peripherals rather than dedicated peripherals attached to each computer.</span></span>

## <a name="device-sharing"></a><span data-ttu-id="68a66-106">デバイスの共有</span><span class="sxs-lookup"><span data-stu-id="68a66-106">Device sharing</span></span>

<span data-ttu-id="68a66-107">ネットワーク、Bluetooth が接続されている PointOfService 周辺機器は、通常使用する環境 wheere で複数のクライアント デバイスが、1 日を通して同じ周辺機器を共有します。</span><span class="sxs-lookup"><span data-stu-id="68a66-107">Network and Bluetooth connected PointOfService peripherals are typically used in an environment wheere multiple client devices are sharing the same peripherals throughout the day.</span></span>  <span data-ttu-id="68a66-108">ビジー状態の製品版または食品サービス環境では、周辺機器を接続するクライアント デバイスの機能の遅延は、効率性を関連付けは、顧客とトランザクションを終了し、へと移動に影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="68a66-108">In a busy retail or food services environment any delay in the ability for a client device to attach to a peripheral has an impact on the efficiency in which an associate can close a transaction with the customer and move on to the next.</span></span> <span data-ttu-id="68a66-109">準備の台所に顧客の注文の詳細を転送するキッチン プリンターとしてレシート プリンターが使用されているサービスのクイック レストランのシナリオでは、顧客から注文を受け取り、複数のクライアント デバイスがあります。</span><span class="sxs-lookup"><span data-stu-id="68a66-109">In a quick service restaurant scenario where a receipt printer is used as a kitchen printer to transfer the details of a customer's order to the kitchen for preparation there will be multiple client devices taking orders from customers.</span></span>  <span data-ttu-id="68a66-110">注文が完了すると各クライアント デバイスが共有プリンターを要求して、すぐにキッチンの順序を印刷することがあります。</span><span class="sxs-lookup"><span data-stu-id="68a66-110">Once the order is complete each client device should be able to claim the shared printer and immediately print the order for the kitchen.</span></span>

<span data-ttu-id="68a66-111">これらの環境でことが重要にアプリケーションの完全**dispose**デバイス オブジェクトの別、同じデバイスを要求できるようにします。</span><span class="sxs-lookup"><span data-stu-id="68a66-111">In these environments, it is important for the application to fully **dispose** the device object so that another can claim the same device.</span></span>

<span data-ttu-id="68a66-112">'Using' ブロックの最後の PosPrinter の破棄</span><span class="sxs-lookup"><span data-stu-id="68a66-112">Disposing of a PosPrinter at the end of a ‘using’ block</span></span>

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


<span data-ttu-id="68a66-113">Dispose() を明示的に呼び出すことによって、PosPrinter の破棄</span><span class="sxs-lookup"><span data-stu-id="68a66-113">Disposing of a PosPrinter by calling Dispose() explicitly</span></span>

```Csharp 
using Windows.Devices.PointOfService;

PosPrinter printer = await PosPrinter.FromIdAsync("Device ID");
if (printer != null)
{
    // Exercise the printer, then dispose of the printer explicitly.
    printer.Dispose();
}
```

## <a name="api-methods-used"></a><span data-ttu-id="68a66-114">API メソッドの使用</span><span class="sxs-lookup"><span data-stu-id="68a66-114">API methods used</span></span> 

+ [<span data-ttu-id="68a66-115">BarcodeScanner.Dispose</span><span class="sxs-lookup"><span data-stu-id="68a66-115">BarcodeScanner.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.dispose) 
+ [<span data-ttu-id="68a66-116">CashDrawer.Dispose</span><span class="sxs-lookup"><span data-stu-id="68a66-116">CashDrawer.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.dispose) 
+ [<span data-ttu-id="68a66-117">LineDisplay.Dispose</span><span class="sxs-lookup"><span data-stu-id="68a66-117">LineDisplay.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.dispose) 
+ [<span data-ttu-id="68a66-118">MagneticStripeReader.Dispose</span><span class="sxs-lookup"><span data-stu-id="68a66-118">MagneticStripeReader.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.dispose)  
+ [<span data-ttu-id="68a66-119">PosPrinter.Dispose</span><span class="sxs-lookup"><span data-stu-id="68a66-119">PosPrinter.Dispose</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.dispose) 


[!INCLUDE [feedback](./includes/pos-feedback.md)]
