---
title: PointOfService デバイスを要求し、モデルを有効にします。
description: PointOfService 要求について学習し、モデルを有効にします。
ms.date: 06/19/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 7169848084b587793ba1537ea3d6ad78d31892d5
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8192932"
---
# <a name="point-of-service-device-claim-and-enable-model"></a><span data-ttu-id="4b1be-104">Point of Service デバイス要求およびモデルを有効にします。</span><span class="sxs-lookup"><span data-stu-id="4b1be-104">Point of Service device claim and enable model</span></span>

## <a name="claiming-for-exclusive-use"></a><span data-ttu-id="4b1be-105">排他的使用のための要求</span><span class="sxs-lookup"><span data-stu-id="4b1be-105">Claiming for exclusive use</span></span>

<span data-ttu-id="4b1be-106">PointOfService デバイス オブジェクトを正常に作成したら、入出力にデバイスを使用する前に、デバイスの種類に適切な要求方法を使用して要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b1be-106">After you have successfully created a PointOfService device object, you must claim it using the appropriate claim method for the device type before you can use the device for input or output.</span></span>  <span data-ttu-id="4b1be-107">要求により、多くのデバイスの機能に対する排他的アクセスがアプリケーションに付与され、あるアプリケーションが別のアプリケーションによるデバイスの使用を妨げないようにします。</span><span class="sxs-lookup"><span data-stu-id="4b1be-107">Claim grants the application exclusive access to many of the device's functions to ensure that one application does not interfere with the use of the device by another application.</span></span>  <span data-ttu-id="4b1be-108">排他的使用のために一度に PointOfService デバイスを要求できるアプリケーションは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="4b1be-108">Only one application can claim a PointOfService device for exclusive use at a time.</span></span> 

> [!Note]
> <span data-ttu-id="4b1be-109">要求アクションは、デバイスを排他的にロックを確立していますが、操作の状態には配置されません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-109">The claim action establishes an exclusive lock to a device, but does not put it into an operational state.</span></span>  <span data-ttu-id="4b1be-110">詳細については、 [I/O 操作用のデバイスを有効にする](#Enable-device-for-I/O-operations)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4b1be-110">See [Enable device for I/O operations](#Enable-device-for-I/O-operations) for more information.</span></span>

### <a name="apis-used-to-claim--release"></a><span data-ttu-id="4b1be-111">要求/リリースに使用する Api</span><span class="sxs-lookup"><span data-stu-id="4b1be-111">APIs used to claim / release</span></span>

|<span data-ttu-id="4b1be-112">デバイス</span><span class="sxs-lookup"><span data-stu-id="4b1be-112">Device</span></span>|<span data-ttu-id="4b1be-113">要求</span><span class="sxs-lookup"><span data-stu-id="4b1be-113">Claim</span></span> | <span data-ttu-id="4b1be-114">Release</span><span class="sxs-lookup"><span data-stu-id="4b1be-114">Release</span></span> | 
|-|:-|:-|
|<span data-ttu-id="4b1be-115">BarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="4b1be-115">BarcodeScanner</span></span> | [<span data-ttu-id="4b1be-116">BarcodeScanner.ClaimScannerAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-116">BarcodeScanner.ClaimScannerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync) | [<span data-ttu-id="4b1be-117">ClaimedBarcodeScanner.Close</span><span class="sxs-lookup"><span data-stu-id="4b1be-117">ClaimedBarcodeScanner.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.close) |
|<span data-ttu-id="4b1be-118">CashDrawer</span><span class="sxs-lookup"><span data-stu-id="4b1be-118">CashDrawer</span></span> | [<span data-ttu-id="4b1be-119">CashDrawer.ClaimDrawerAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-119">CashDrawer.ClaimDrawerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.claimdrawerasync) | [<span data-ttu-id="4b1be-120">ClaimedCashDrawer.Close</span><span class="sxs-lookup"><span data-stu-id="4b1be-120">ClaimedCashDrawer.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.close) | 
|<span data-ttu-id="4b1be-121">LineDisplay</span><span class="sxs-lookup"><span data-stu-id="4b1be-121">LineDisplay</span></span> | [<span data-ttu-id="4b1be-122">LineDisplay.ClaimAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-122">LineDisplay.ClaimAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.claimasync) |  [<span data-ttu-id="4b1be-123">ClaimedineDisplay.Close</span><span class="sxs-lookup"><span data-stu-id="4b1be-123">ClaimedineDisplay.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.close) | 
|<span data-ttu-id="4b1be-124">MagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="4b1be-124">MagneticStripeReader</span></span> | [<span data-ttu-id="4b1be-125">MagneticStripeReader.ClaimReaderAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-125">MagneticStripeReader.ClaimReaderAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.claimreaderasync) |  [<span data-ttu-id="4b1be-126">ClaimedMagneticStripeReader.Close</span><span class="sxs-lookup"><span data-stu-id="4b1be-126">ClaimedMagneticStripeReader.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.close) | 
|<span data-ttu-id="4b1be-127">PosPrinter</span><span class="sxs-lookup"><span data-stu-id="4b1be-127">PosPrinter</span></span> | [<span data-ttu-id="4b1be-128">PosPrinter.ClaimPrinterAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-128">PosPrinter.ClaimPrinterAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.claimprinterasync) |  [<span data-ttu-id="4b1be-129">ClaimedPosPrinter.Close</span><span class="sxs-lookup"><span data-stu-id="4b1be-129">ClaimedPosPrinter.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.close) | 
 | 

## <a name="enable-device-for-io-operations"></a><span data-ttu-id="4b1be-130">I/O 操作用のデバイスを有効にします。</span><span class="sxs-lookup"><span data-stu-id="4b1be-130">Enable device for I/O operations</span></span>

<span data-ttu-id="4b1be-131">要求アクションは単に、デバイスを排他的の権利を確立していますが、操作の状態には配置されません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-131">The claim action simply establishes an exclusive rights to the device, but does not put it into an operational state.</span></span>  <span data-ttu-id="4b1be-132">イベントを受信または出力の操作を実行するのには、 **EnableAsync**を使用してデバイスを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b1be-132">In order to receive events or perform any output operations you must enable the device using **EnableAsync**.</span></span>  <span data-ttu-id="4b1be-133">逆に、デバイスまたは実行中の出力からイベントをリッスンしてを停止する**DisableAsync**を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4b1be-133">Conversely, you can call **DisableAsync** to stop listening to events from the device or performing output.</span></span>  <span data-ttu-id="4b1be-134">お使いのデバイスの状態を判断**IsEnabled**を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="4b1be-134">You can also use **IsEnabled** to determine the state of your device.</span></span>

### <a name="apis-used-enable--disable"></a><span data-ttu-id="4b1be-135">使用されている Api を有効にする/無効にします。</span><span class="sxs-lookup"><span data-stu-id="4b1be-135">APIs used enable / disable</span></span>

| <span data-ttu-id="4b1be-136">デバイス</span><span class="sxs-lookup"><span data-stu-id="4b1be-136">Device</span></span> | <span data-ttu-id="4b1be-137">有効化</span><span class="sxs-lookup"><span data-stu-id="4b1be-137">Enable</span></span> | <span data-ttu-id="4b1be-138">無効</span><span class="sxs-lookup"><span data-stu-id="4b1be-138">Disable</span></span> | <span data-ttu-id="4b1be-139">IsEnabled かどうか。</span><span class="sxs-lookup"><span data-stu-id="4b1be-139">IsEnabled?</span></span> |
|-|:-|:-|:-|
|<span data-ttu-id="4b1be-140">ClaimedBarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="4b1be-140">ClaimedBarcodeScanner</span></span> | [<span data-ttu-id="4b1be-141">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-141">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.enableasync) | [<span data-ttu-id="4b1be-142">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-142">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.disableasync) | [<span data-ttu-id="4b1be-143">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="4b1be-143">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isenabled) | 
|<span data-ttu-id="4b1be-144">ClaimedCashDrawer</span><span class="sxs-lookup"><span data-stu-id="4b1be-144">ClaimedCashDrawer</span></span> | [<span data-ttu-id="4b1be-145">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-145">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.enableasync) | [<span data-ttu-id="4b1be-146">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-146">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.disableasync) | [<span data-ttu-id="4b1be-147">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="4b1be-147">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.isenabled) |
|<span data-ttu-id="4b1be-148">ClaimedLineDisplay</span><span class="sxs-lookup"><span data-stu-id="4b1be-148">ClaimedLineDisplay</span></span> | <span data-ttu-id="4b1be-149">Applicable¹ しません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-149">Not Applicable¹</span></span> | <span data-ttu-id="4b1be-150">Applicable¹ しません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-150">Not Applicable¹</span></span> | <span data-ttu-id="4b1be-151">Applicable¹ しません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-151">Not Applicable¹</span></span> | 
|<span data-ttu-id="4b1be-152">ClaimedMagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="4b1be-152">ClaimedMagneticStripeReader</span></span> | [<span data-ttu-id="4b1be-153">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-153">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.enableasync) | [<span data-ttu-id="4b1be-154">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-154">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.disableasync) | [<span data-ttu-id="4b1be-155">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="4b1be-155">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.isenabled) |  
|<span data-ttu-id="4b1be-156">ClaimedPosPrinter</span><span class="sxs-lookup"><span data-stu-id="4b1be-156">ClaimedPosPrinter</span></span> | [<span data-ttu-id="4b1be-157">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-157">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.enableasync) | [<span data-ttu-id="4b1be-158">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="4b1be-158">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.disableasyc) | [<span data-ttu-id="4b1be-159">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="4b1be-159">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.isenabled) |
|

<span data-ttu-id="4b1be-160">¹ ライン ディスプレイでは、I/O 操作用にデバイスを明示的に有効にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4b1be-160">¹ Line Display does not require you to explicitly enable the device for I/O operations.</span></span>  <span data-ttu-id="4b1be-161">有効にするとは、I/O を実行する PointOfService LineDisplay Api によって自動的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="4b1be-161">Enabling is performed automatically by the PointOfService LineDisplay APIs which perform I/O.</span></span>

## <a name="code-sample-claim-and-enable"></a><span data-ttu-id="4b1be-162">サンプル コード: 要求し、有効化</span><span class="sxs-lookup"><span data-stu-id="4b1be-162">Code sample: claim and enable</span></span>

<span data-ttu-id="4b1be-163">次のサンプルでは、バーコード スキャナー オブジェクトを正常に作成した後で、バーコード スキャナーのデバイスを要求する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4b1be-163">This sample shows how to claim a barcode scanner device after you have successfully created a barcode scanner object.</span></span>

```Csharp

    BarcodeScanner barcodeScanner = await BarcodeScanner.FromIdAsync(DeviceId);

    if(barcodeScanner != null)
    {
        // after successful creation, claim the scanner for exclusive use 
        claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();

        if(claimedBarcodeScanner != null)
        {
            // after successful claim, enable scanner for data events to fire
            await claimedBarcodeScanner.EnableAsync();
        }
        else
        {
            Debug.WriteLine("Failure to claim barcodeScanner");
        }
    }
    else
    {
        Debug.WriteLine("Failure to create barcodeScanner object");
    }
    
```

> [!Warning]
> <span data-ttu-id="4b1be-164">次のような場合に要求が失われることがあります。</span><span class="sxs-lookup"><span data-stu-id="4b1be-164">A claim can be lost in the following circumstances:</span></span>
> 1. <span data-ttu-id="4b1be-165">別のアプリで同じデバイスの要求がリクエストされ、アプリが **ReleaseDeviceRequested** イベントへの応答として **RetainDevice** を発行しなかった </span><span class="sxs-lookup"><span data-stu-id="4b1be-165">Another app has requested a claim of the same device and your app did not issue a **RetainDevice** in response to the **ReleaseDeviceRequested** event.</span></span>  <span data-ttu-id="4b1be-166">(詳細については、以下の「[要求のネゴシエーション](#Claim-negotiation)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="4b1be-166">(See [Claim negotiation](#Claim-negotiation) below for more information.)</span></span>
> 2. <span data-ttu-id="4b1be-167">アプリが中断され、その結果としてデバイス オブジェクトが終了し、結果的に要求が有効ではなくなった </span><span class="sxs-lookup"><span data-stu-id="4b1be-167">Your app has been suspended, which resulted in the device object being closed and as a result the claim is no longer valid.</span></span> <span data-ttu-id="4b1be-168">(詳細については、「[デバイス オブジェクトのライフサイクル](pos-basics-deviceobject.md#device-object-lifecycle)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="4b1be-168">(See [Device object lifecycle](pos-basics-deviceobject.md#device-object-lifecycle) for more information.)</span></span>


## <a name="claim-negotiation"></a><span data-ttu-id="4b1be-169">要求のネゴシエーション</span><span class="sxs-lookup"><span data-stu-id="4b1be-169">Claim negotiation</span></span>

<span data-ttu-id="4b1be-170">Windows はマルチタスク環境であるため、同じコンピューター上の複数のアプリケーションで連携して周辺機器にアクセスする必要がある可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4b1be-170">Since Windows is a multi-tasking environment it is possible for multiple applications on the same computer to require access to peripherals in a cooperative manner.</span></span>  <span data-ttu-id="4b1be-171">PointOfService API は、コンピューターに接続されている周辺機器を複数のアプリケーションが共有できるようにするネゴシエーション モデルを提供します。</span><span class="sxs-lookup"><span data-stu-id="4b1be-171">The PointOfService APIs provide a negotiation model that allows for multiple applications to share peripherals connected to the computer.</span></span>

<span data-ttu-id="4b1be-172">同じコンピューター上の 2 番目のアプリケーションが別のアプリケーションによって既に要求された PointOfService 周辺機器への要求をリクエストすると、**ReleaseDeviceRequested**イベント通知が発行されます。</span><span class="sxs-lookup"><span data-stu-id="4b1be-172">When a second application on the same computer requests a Claim for a PointOfService peripheral that is already claimed by another application, a **ReleaseDeviceRequested** event notification is published.</span></span> <span data-ttu-id="4b1be-173">アクティブな要求のあるアプリケーションは、そのアプリケーションが現在デバイスを使用している場合は、要求を失うことを避けるために **RetainDevice** を呼び出してイベント通知に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b1be-173">The application with the active claim must respond to the event notification by calling **RetainDevice** if the application is currently using the device to avoid losing the claim.</span></span> 

<span data-ttu-id="4b1be-174">アクティブな要求を持つアプリケーションが **RetainDevice** ですぐに応答しない場合は、アプリケーションが中断されたか、またはデバイスが不要であると見なされ、要求が取り消されて新しいアプリケーションに渡されます。</span><span class="sxs-lookup"><span data-stu-id="4b1be-174">If the application with the active claim does not respond with **RetainDevice** right away it is assumed that the application has been suspended or does not need the device and the claim is revoked and given to the new application.</span></span> 

<span data-ttu-id="4b1be-175">最初の手順では、 **RetainDevice**で**ReleaseDeviceRequested**イベントに応答するイベント ハンドラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="4b1be-175">The first step is to create an event handler which responds to the **ReleaseDeviceRequested** event with **RetainDevice**.</span></span>  

```Csharp
    /// <summary>
    /// Event handler for the ReleaseDeviceRequested event which occurs when 
    /// the claimed barcode scanner receives a Claim request from another application
    /// </summary>
    void claimedBarcodeScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner myScanner)
    {
        // Retain exclusive access to the device
        myScanner.RetainDevice();
    }
```

<span data-ttu-id="4b1be-176">要求されたデバイスに関連付け、イベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="4b1be-176">Then register the event handler in association with your claimed device</span></span>

```Csharp
    BarcodeScanner barcodeScanner = await BarcodeScanner.FromIdAsync(DeviceId);

    if(barcodeScanner != null)
    {
        // after successful creation, claim the scanner for exclusive use 
        claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();

        if(claimedBarcodeScanner != null)
        {
            // register a release request handler to prevent loss of scanner during active use
            claimedBarcodeScanner.ReleaseDeviceRequested += claimedBarcodeScanner_ReleaseDeviceRequested;

            // after successful claim, enable scanner for data events to fire
            await claimedBarcodeScanner.EnableAsync();          
        }
        else
        {
            Debug.WriteLine("Failure to claim barcodeScanner");
        }
    }
    else
    {
        Debug.WriteLine("Failure to create barcodeScanner object");
    }
```



### <a name="apis-used-for-claim-negotiation"></a><span data-ttu-id="4b1be-177">要求のネゴシエーションに使用される API</span><span class="sxs-lookup"><span data-stu-id="4b1be-177">APIs used for claim negotiation</span></span>

|<span data-ttu-id="4b1be-178">要求されたデバイス</span><span class="sxs-lookup"><span data-stu-id="4b1be-178">Claimed device</span></span>|<span data-ttu-id="4b1be-179">リリースの通知</span><span class="sxs-lookup"><span data-stu-id="4b1be-179">Release Notification</span></span>| <span data-ttu-id="4b1be-180">デバイスの保持</span><span class="sxs-lookup"><span data-stu-id="4b1be-180">Retain Device</span></span> |
|-|:-|:-|
|<span data-ttu-id="4b1be-181">ClaimedBarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="4b1be-181">ClaimedBarcodeScanner</span></span> | [<span data-ttu-id="4b1be-182">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="4b1be-182">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.releasedevicerequested) | [<span data-ttu-id="4b1be-183">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="4b1be-183">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.retaindevice)
|<span data-ttu-id="4b1be-184">ClaimedCashDrawer</span><span class="sxs-lookup"><span data-stu-id="4b1be-184">ClaimedCashDrawer</span></span> | [<span data-ttu-id="4b1be-185">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="4b1be-185">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.releasedevicerequested) | [<span data-ttu-id="4b1be-186">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="4b1be-186">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.retaindevice)
|<span data-ttu-id="4b1be-187">ClaimedLineDisplay</span><span class="sxs-lookup"><span data-stu-id="4b1be-187">ClaimedLineDisplay</span></span> | [<span data-ttu-id="4b1be-188">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="4b1be-188">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.releasedevicerequested) | [<span data-ttu-id="4b1be-189">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="4b1be-189">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="4b1be-190">ClaimedMagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="4b1be-190">ClaimedMagneticStripeReader</span></span> | [<span data-ttu-id="4b1be-191">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="4b1be-191">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.releasedevicerequested) | [<span data-ttu-id="4b1be-192">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="4b1be-192">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="4b1be-193">ClaimedPosPrinter</span><span class="sxs-lookup"><span data-stu-id="4b1be-193">ClaimedPosPrinter</span></span> | [<span data-ttu-id="4b1be-194">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="4b1be-194">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.releasedevicerequested) | [<span data-ttu-id="4b1be-195">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="4b1be-195">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.retaindevice)
|
