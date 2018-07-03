---
author: TerryWarwick
title: PointOfService デバイスの要求モデル
description: PointOfService 要求モデルの詳細
ms.author: jken
ms.date: 06/4/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 202234530945e55ef9c0d0fb68cf9ca83d2e15c3
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983735"
---
# <a name="point-of-service-device-claim-model"></a><span data-ttu-id="e16ef-104">POS デバイスの要求モデル</span><span class="sxs-lookup"><span data-stu-id="e16ef-104">Point of Service device claim model</span></span>

## <a name="claiming-a-device-for-exclusive-use"></a><span data-ttu-id="e16ef-105">排他的使用のためのデバイスの要求</span><span class="sxs-lookup"><span data-stu-id="e16ef-105">Claiming a device for exclusive use</span></span>

<span data-ttu-id="e16ef-106">PointOfService デバイス オブジェクトを正常に作成したら、入出力にデバイスを使用する前に、デバイスの種類に適切な要求方法を使用して要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e16ef-106">After you have successfully created a PointOfService device object, you must claim it using the appropriate claim method for the device type before you can use the device for input or output.</span></span>  <span data-ttu-id="e16ef-107">要求により、多くのデバイスの機能に対する排他的アクセスがアプリケーションに付与され、あるアプリケーションが別のアプリケーションによるデバイスの使用を妨げないようにします。</span><span class="sxs-lookup"><span data-stu-id="e16ef-107">Claim grants the application exclusive access to many of the device's functions to ensure that one application does not interfere with the use of the device by another application.</span></span>  <span data-ttu-id="e16ef-108">排他的使用のために一度に PointOfService デバイスを要求できるアプリケーションは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="e16ef-108">Only one application can claim a PointOfService device for exclusive use at a time.</span></span> 

<span data-ttu-id="e16ef-109">次のサンプルでは、バーコード スキャナー オブジェクトを正常に作成した後で、バーコード スキャナーのデバイスを要求する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e16ef-109">This sample shows how to claim a barcode scanner device after you have successfully created a barcode scanner object.</span></span>

```Csharp
try
{
    claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();
}
catch (Exception ex)
{
    Debug.WriteLine("EX: ClaimScannerAsync() - " + ex.Message);
}
```

> [!Warning]
> <span data-ttu-id="e16ef-110">次のような場合に要求が失われることがあります。</span><span class="sxs-lookup"><span data-stu-id="e16ef-110">A claim can be lost in the following circumstances:</span></span>
> 1. <span data-ttu-id="e16ef-111">別のアプリで同じデバイスの要求がリクエストされ、アプリが **ReleaseDeviceRequested** イベントへの応答として **RetainDevice** を発行しなかった </span><span class="sxs-lookup"><span data-stu-id="e16ef-111">Another app has requested a claim of the same device and your app did not issue a **RetainDevice** in response to the **ReleaseDeviceRequested** event.</span></span>  <span data-ttu-id="e16ef-112">(詳細については、以下の「[要求のネゴシエーション](#Claim-negotiation)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="e16ef-112">(See [Claim negotiation](#Claim-negotiation) below for more information.)</span></span>
> 2. <span data-ttu-id="e16ef-113">アプリが中断され、その結果としてデバイス オブジェクトが終了し、結果的に要求が有効ではなくなった </span><span class="sxs-lookup"><span data-stu-id="e16ef-113">Your app has been suspended, which resulted in the device object being closed and as a result the claim is no longer valid.</span></span> <span data-ttu-id="e16ef-114">(詳細については、「[デバイス オブジェクトのライフサイクル](pos-basics-deviceobject.md#device-object-lifecycle)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="e16ef-114">(See [Device object lifecycle](pos-basics-deviceobject.md#device-object-lifecycle) for more information.)</span></span>

### <a name="apis-used-for-claiming"></a><span data-ttu-id="e16ef-115">要求のために使用する API</span><span class="sxs-lookup"><span data-stu-id="e16ef-115">APIs used for claiming</span></span>

|<span data-ttu-id="e16ef-116">デバイス</span><span class="sxs-lookup"><span data-stu-id="e16ef-116">Device</span></span>|<span data-ttu-id="e16ef-117">要求</span><span class="sxs-lookup"><span data-stu-id="e16ef-117">Claim</span></span> |
|-|:-|
|<span data-ttu-id="e16ef-118">BarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="e16ef-118">BarcodeScanner</span></span> | [<span data-ttu-id="e16ef-119">ClaimScannerAsync</span><span class="sxs-lookup"><span data-stu-id="e16ef-119">ClaimScannerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync) | 
|<span data-ttu-id="e16ef-120">CashDrawer</span><span class="sxs-lookup"><span data-stu-id="e16ef-120">CashDrawer</span></span> | [<span data-ttu-id="e16ef-121">ClaimDrawerAsync</span><span class="sxs-lookup"><span data-stu-id="e16ef-121">ClaimDrawerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.claimdrawerasync) | 
|<span data-ttu-id="e16ef-122">LineDisplay</span><span class="sxs-lookup"><span data-stu-id="e16ef-122">LineDisplay</span></span> | [<span data-ttu-id="e16ef-123">ClaimAsync</span><span class="sxs-lookup"><span data-stu-id="e16ef-123">ClaimAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.claimasync) |
|<span data-ttu-id="e16ef-124">MagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="e16ef-124">MagneticStripeReader</span></span> | [<span data-ttu-id="e16ef-125">ClaimReaderAsync</span><span class="sxs-lookup"><span data-stu-id="e16ef-125">ClaimReaderAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.claimreaderasync) | 
|<span data-ttu-id="e16ef-126">PosPrinter</span><span class="sxs-lookup"><span data-stu-id="e16ef-126">PosPrinter</span></span> | [<span data-ttu-id="e16ef-127">ClaimPrinterAsync</span><span class="sxs-lookup"><span data-stu-id="e16ef-127">ClaimPrinterAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.claimprinterasync) | 
|

## <a name="claim-negotiation"></a><span data-ttu-id="e16ef-128">要求のネゴシエーション</span><span class="sxs-lookup"><span data-stu-id="e16ef-128">Claim negotiation</span></span>

<span data-ttu-id="e16ef-129">Windows はマルチタスク環境であるため、同じコンピューター上の複数のアプリケーションで連携して周辺機器にアクセスする必要がある可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e16ef-129">Since Windows is a multi-tasking environment it is possible for multiple applications on the same computer to require access to peripherals in a cooperative manner.</span></span>  <span data-ttu-id="e16ef-130">PointOfService API は、コンピューターに接続されている周辺機器を複数のアプリケーションが共有できるようにするネゴシエーション モデルを提供します。</span><span class="sxs-lookup"><span data-stu-id="e16ef-130">The PointOfService APIs provide a negotiation model that allows for multiple applications to share peripherals connected to the computer.</span></span>

<span data-ttu-id="e16ef-131">同じコンピューター上の 2 番目のアプリケーションが別のアプリケーションによって既に要求された PointOfService 周辺機器への要求をリクエストすると、**ReleaseDeviceRequested**イベント通知が発行されます。</span><span class="sxs-lookup"><span data-stu-id="e16ef-131">When a second application on the same computer requests a Claim for a PointOfService peripheral that is already claimed by another application, a **ReleaseDeviceRequested** event notification is published.</span></span> <span data-ttu-id="e16ef-132">アクティブな要求のあるアプリケーションは、そのアプリケーションが現在デバイスを使用している場合は、要求を失うことを避けるために **RetainDevice** を呼び出してイベント通知に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e16ef-132">The application with the active claim must respond to the event notification by calling **RetainDevice** if the application is currently using the device to avoid losing the claim.</span></span> 

<span data-ttu-id="e16ef-133">アクティブな要求を持つアプリケーションが **RetainDevice** ですぐに応答しない場合は、アプリケーションが中断されたか、またはデバイスが不要であると見なされ、要求が取り消されて新しいアプリケーションに渡されます。</span><span class="sxs-lookup"><span data-stu-id="e16ef-133">If the application with the active claim does not respond with **RetainDevice** right away it is assumed that the application has been suspended or does not need the device and the claim is revoked and given to the new application.</span></span> 

<span data-ttu-id="e16ef-134">この例では、他のアプリからデバイスを解放するように要求されても、要求したバーコード スキャナーを保持し続ける方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e16ef-134">This example shows how to retain a claimed barcode scanner after another app has requested that the device be released.</span></span>  

```Csharp
claimedBarcodeScanner.ReleaseDeviceRequested += claimedBarcodeScanner_ReleaseDeviceRequested;

void claimedBarcodeScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner myScanner)
{
    // Retain exclusive access to the device
    myScanner.RetainDevice();  
}
```
### <a name="apis-used-for-claim-negotiation"></a><span data-ttu-id="e16ef-135">要求のネゴシエーションに使用される API</span><span class="sxs-lookup"><span data-stu-id="e16ef-135">APIs used for claim negotiation</span></span>

|<span data-ttu-id="e16ef-136">要求されたデバイス</span><span class="sxs-lookup"><span data-stu-id="e16ef-136">Claimed device</span></span>|<span data-ttu-id="e16ef-137">リリースの通知</span><span class="sxs-lookup"><span data-stu-id="e16ef-137">Release Notification</span></span>| <span data-ttu-id="e16ef-138">デバイスの保持</span><span class="sxs-lookup"><span data-stu-id="e16ef-138">Retain Device</span></span> |
|-|:-|:-|
|<span data-ttu-id="e16ef-139">ClaimedBarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="e16ef-139">ClaimedBarcodeScanner</span></span> | [<span data-ttu-id="e16ef-140">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="e16ef-140">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.releasedevicerequested) | [<span data-ttu-id="e16ef-141">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="e16ef-141">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.retaindevice)
|<span data-ttu-id="e16ef-142">ClaimedCashDrawer</span><span class="sxs-lookup"><span data-stu-id="e16ef-142">ClaimedCashDrawer</span></span> | [<span data-ttu-id="e16ef-143">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="e16ef-143">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.releasedevicerequested) | [<span data-ttu-id="e16ef-144">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="e16ef-144">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.retaindevice)
|<span data-ttu-id="e16ef-145">ClaimedLineDisplay</span><span class="sxs-lookup"><span data-stu-id="e16ef-145">ClaimedLineDisplay</span></span> | [<span data-ttu-id="e16ef-146">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="e16ef-146">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.releasedevicerequested) | [<span data-ttu-id="e16ef-147">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="e16ef-147">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="e16ef-148">ClaimedMagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="e16ef-148">ClaimedMagneticStripeReader</span></span> | [<span data-ttu-id="e16ef-149">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="e16ef-149">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.releasedevicerequested) | [<span data-ttu-id="e16ef-150">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="e16ef-150">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="e16ef-151">ClaimedPosPrinter</span><span class="sxs-lookup"><span data-stu-id="e16ef-151">ClaimedPosPrinter</span></span> | [<span data-ttu-id="e16ef-152">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="e16ef-152">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.releasedevicerequested) | [<span data-ttu-id="e16ef-153">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="e16ef-153">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.retaindevice)
|
