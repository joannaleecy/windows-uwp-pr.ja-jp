---
title: PointOfService デバイス要求し、モデルを有効にします。
description: PointOfService 要求について説明し、モデルを有効にします。
ms.date: 06/19/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 0e7d60c0b612a8067ac4c225dff9da5da428f1a1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639317"
---
# <a name="point-of-service-device-claim-and-enable-model"></a><span data-ttu-id="a3b99-104">ポイントのサービスのデバイス要求し、モデルを有効にします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-104">Point of Service device claim and enable model</span></span>

## <a name="claiming-for-exclusive-use"></a><span data-ttu-id="a3b99-105">主張して排他的に使用</span><span class="sxs-lookup"><span data-stu-id="a3b99-105">Claiming for exclusive use</span></span>

<span data-ttu-id="a3b99-106">PointOfService デバイス オブジェクトを正常に作成したら、入出力にデバイスを使用する前に、デバイスの種類に適切な要求方法を使用して要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3b99-106">After you have successfully created a PointOfService device object, you must claim it using the appropriate claim method for the device type before you can use the device for input or output.</span></span>  <span data-ttu-id="a3b99-107">要求により、多くのデバイスの機能に対する排他的アクセスがアプリケーションに付与され、あるアプリケーションが別のアプリケーションによるデバイスの使用を妨げないようにします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-107">Claim grants the application exclusive access to many of the device's functions to ensure that one application does not interfere with the use of the device by another application.</span></span>  <span data-ttu-id="a3b99-108">排他的使用のために一度に PointOfService デバイスを要求できるアプリケーションは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="a3b99-108">Only one application can claim a PointOfService device for exclusive use at a time.</span></span> 

> [!Note]
> <span data-ttu-id="a3b99-109">要求アクションはデバイスに排他ロックを確立しますが、動作状態には配置されません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-109">The claim action establishes an exclusive lock to a device, but does not put it into an operational state.</span></span>  <span data-ttu-id="a3b99-110">参照してください[I/O 操作を有効にするデバイス](#enable-device-for-io-operations)詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-110">See [Enable device for I/O operations](#enable-device-for-io-operations) for more information.</span></span>

### <a name="apis-used-to-claim--release"></a><span data-ttu-id="a3b99-111">要求/リリースに使用する Api</span><span class="sxs-lookup"><span data-stu-id="a3b99-111">APIs used to claim / release</span></span>

|<span data-ttu-id="a3b99-112">デバイス</span><span class="sxs-lookup"><span data-stu-id="a3b99-112">Device</span></span>|<span data-ttu-id="a3b99-113">要求</span><span class="sxs-lookup"><span data-stu-id="a3b99-113">Claim</span></span> | <span data-ttu-id="a3b99-114">リリース</span><span class="sxs-lookup"><span data-stu-id="a3b99-114">Release</span></span> | 
|-|:-|:-|
|<span data-ttu-id="a3b99-115">BarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="a3b99-115">BarcodeScanner</span></span> | [<span data-ttu-id="a3b99-116">BarcodeScanner.ClaimScannerAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-116">BarcodeScanner.ClaimScannerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync) | [<span data-ttu-id="a3b99-117">ClaimedBarcodeScanner.Close</span><span class="sxs-lookup"><span data-stu-id="a3b99-117">ClaimedBarcodeScanner.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.close) |
|<span data-ttu-id="a3b99-118">CashDrawer</span><span class="sxs-lookup"><span data-stu-id="a3b99-118">CashDrawer</span></span> | [<span data-ttu-id="a3b99-119">CashDrawer.ClaimDrawerAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-119">CashDrawer.ClaimDrawerAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.claimdrawerasync) | [<span data-ttu-id="a3b99-120">ClaimedCashDrawer.Close</span><span class="sxs-lookup"><span data-stu-id="a3b99-120">ClaimedCashDrawer.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.close) | 
|<span data-ttu-id="a3b99-121">LineDisplay</span><span class="sxs-lookup"><span data-stu-id="a3b99-121">LineDisplay</span></span> | [<span data-ttu-id="a3b99-122">LineDisplay.ClaimAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-122">LineDisplay.ClaimAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.claimasync) |  [<span data-ttu-id="a3b99-123">ClaimedineDisplay.Close</span><span class="sxs-lookup"><span data-stu-id="a3b99-123">ClaimedineDisplay.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.close) | 
|<span data-ttu-id="a3b99-124">MagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="a3b99-124">MagneticStripeReader</span></span> | [<span data-ttu-id="a3b99-125">MagneticStripeReader.ClaimReaderAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-125">MagneticStripeReader.ClaimReaderAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.claimreaderasync) |  [<span data-ttu-id="a3b99-126">ClaimedMagneticStripeReader.Close</span><span class="sxs-lookup"><span data-stu-id="a3b99-126">ClaimedMagneticStripeReader.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.close) | 
|<span data-ttu-id="a3b99-127">PosPrinter</span><span class="sxs-lookup"><span data-stu-id="a3b99-127">PosPrinter</span></span> | [<span data-ttu-id="a3b99-128">PosPrinter.ClaimPrinterAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-128">PosPrinter.ClaimPrinterAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.claimprinterasync) |  [<span data-ttu-id="a3b99-129">ClaimedPosPrinter.Close</span><span class="sxs-lookup"><span data-stu-id="a3b99-129">ClaimedPosPrinter.Close</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.close) | 
 | 

## <a name="enable-device-for-io-operations"></a><span data-ttu-id="a3b99-130">デバイスの I/O 操作を有効にします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-130">Enable device for I/O operations</span></span>

<span data-ttu-id="a3b99-131">要求アクションは、デバイスに対して、排他的な権限を確立するだけですが動作状態には配置されません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-131">The claim action simply establishes an exclusive rights to the device, but does not put it into an operational state.</span></span>  <span data-ttu-id="a3b99-132">イベントを受信または出力操作を実行するために使用して、デバイスを有効する必要があります**EnableAsync**します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-132">In order to receive events or perform any output operations you must enable the device using **EnableAsync**.</span></span>  <span data-ttu-id="a3b99-133">逆に、呼び出すことができます**DisableAsync**デバイスからイベントをリッスンしているまたは出力の実行を停止します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-133">Conversely, you can call **DisableAsync** to stop listening to events from the device or performing output.</span></span>  <span data-ttu-id="a3b99-134">使用することも**IsEnabled**デバイスの状態を判断します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-134">You can also use **IsEnabled** to determine the state of your device.</span></span>

### <a name="apis-used-enable--disable"></a><span data-ttu-id="a3b99-135">Api の使用を有効にする/無効にします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-135">APIs used enable / disable</span></span>

| <span data-ttu-id="a3b99-136">デバイス</span><span class="sxs-lookup"><span data-stu-id="a3b99-136">Device</span></span> | <span data-ttu-id="a3b99-137">Enable</span><span class="sxs-lookup"><span data-stu-id="a3b99-137">Enable</span></span> | <span data-ttu-id="a3b99-138">無効</span><span class="sxs-lookup"><span data-stu-id="a3b99-138">Disable</span></span> | <span data-ttu-id="a3b99-139">IsEnabled でしょうか。</span><span class="sxs-lookup"><span data-stu-id="a3b99-139">IsEnabled?</span></span> |
|-|:-|:-|:-|
|<span data-ttu-id="a3b99-140">ClaimedBarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="a3b99-140">ClaimedBarcodeScanner</span></span> | [<span data-ttu-id="a3b99-141">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-141">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.enableasync) | [<span data-ttu-id="a3b99-142">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-142">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.disableasync) | [<span data-ttu-id="a3b99-143">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="a3b99-143">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isenabled) | 
|<span data-ttu-id="a3b99-144">ClaimedCashDrawer</span><span class="sxs-lookup"><span data-stu-id="a3b99-144">ClaimedCashDrawer</span></span> | [<span data-ttu-id="a3b99-145">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-145">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.enableasync) | [<span data-ttu-id="a3b99-146">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-146">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.disableasync) | [<span data-ttu-id="a3b99-147">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="a3b99-147">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.isenabled) |
|<span data-ttu-id="a3b99-148">ClaimedLineDisplay</span><span class="sxs-lookup"><span data-stu-id="a3b99-148">ClaimedLineDisplay</span></span> | <span data-ttu-id="a3b99-149">Applicable¹ されません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-149">Not Applicable¹</span></span> | <span data-ttu-id="a3b99-150">Applicable¹ されません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-150">Not Applicable¹</span></span> | <span data-ttu-id="a3b99-151">Applicable¹ されません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-151">Not Applicable¹</span></span> | 
|<span data-ttu-id="a3b99-152">ClaimedMagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="a3b99-152">ClaimedMagneticStripeReader</span></span> | [<span data-ttu-id="a3b99-153">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-153">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.enableasync) | [<span data-ttu-id="a3b99-154">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-154">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.disableasync) | [<span data-ttu-id="a3b99-155">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="a3b99-155">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.isenabled) |  
|<span data-ttu-id="a3b99-156">ClaimedPosPrinter</span><span class="sxs-lookup"><span data-stu-id="a3b99-156">ClaimedPosPrinter</span></span> | [<span data-ttu-id="a3b99-157">EnableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-157">EnableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.enableasync) | [<span data-ttu-id="a3b99-158">DisableAsync</span><span class="sxs-lookup"><span data-stu-id="a3b99-158">DisableAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.disableasyc) | [<span data-ttu-id="a3b99-159">IsEnabled</span><span class="sxs-lookup"><span data-stu-id="a3b99-159">IsEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.isenabled) |
|

<span data-ttu-id="a3b99-160">¹ の行の表示では、デバイスの I/O 操作を明示的に有効にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a3b99-160">¹ Line Display does not require you to explicitly enable the device for I/O operations.</span></span>  <span data-ttu-id="a3b99-161">有効化は、I/O を実行する PointOfService LineDisplay Api によって自動的に実行されます。</span><span class="sxs-lookup"><span data-stu-id="a3b99-161">Enabling is performed automatically by the PointOfService LineDisplay APIs which perform I/O.</span></span>

## <a name="code-sample-claim-and-enable"></a><span data-ttu-id="a3b99-162">コード サンプル: 要求し、有効にします。</span><span class="sxs-lookup"><span data-stu-id="a3b99-162">Code sample: claim and enable</span></span>

<span data-ttu-id="a3b99-163">次のサンプルでは、バーコード スキャナー オブジェクトを正常に作成した後で、バーコード スキャナーのデバイスを要求する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a3b99-163">This sample shows how to claim a barcode scanner device after you have successfully created a barcode scanner object.</span></span>

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
> <span data-ttu-id="a3b99-164">次のような場合に要求が失われることがあります。</span><span class="sxs-lookup"><span data-stu-id="a3b99-164">A claim can be lost in the following circumstances:</span></span>
> 1. <span data-ttu-id="a3b99-165">別のアプリで同じデバイスの要求がリクエストされ、アプリが **ReleaseDeviceRequested** イベントへの応答として **RetainDevice** を発行しなかった </span><span class="sxs-lookup"><span data-stu-id="a3b99-165">Another app has requested a claim of the same device and your app did not issue a **RetainDevice** in response to the **ReleaseDeviceRequested** event.</span></span>  <span data-ttu-id="a3b99-166">(詳細については、以下の「[要求のネゴシエーション](#Claim-negotiation)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="a3b99-166">(See [Claim negotiation](#Claim-negotiation) below for more information.)</span></span>
> 2. <span data-ttu-id="a3b99-167">アプリが中断され、その結果としてデバイス オブジェクトが終了し、結果的に要求が有効ではなくなった </span><span class="sxs-lookup"><span data-stu-id="a3b99-167">Your app has been suspended, which resulted in the device object being closed and as a result the claim is no longer valid.</span></span> <span data-ttu-id="a3b99-168">(詳細については、「[デバイス オブジェクトのライフサイクル](pos-basics-deviceobject.md#device-object-lifecycle)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="a3b99-168">(See [Device object lifecycle](pos-basics-deviceobject.md#device-object-lifecycle) for more information.)</span></span>


## <a name="claim-negotiation"></a><span data-ttu-id="a3b99-169">要求のネゴシエーション</span><span class="sxs-lookup"><span data-stu-id="a3b99-169">Claim negotiation</span></span>

<span data-ttu-id="a3b99-170">Windows はマルチタスク環境であるため、同じコンピューター上の複数のアプリケーションで連携して周辺機器にアクセスする必要がある可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a3b99-170">Since Windows is a multi-tasking environment it is possible for multiple applications on the same computer to require access to peripherals in a cooperative manner.</span></span>  <span data-ttu-id="a3b99-171">PointOfService API は、コンピューターに接続されている周辺機器を複数のアプリケーションが共有できるようにするネゴシエーション モデルを提供します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-171">The PointOfService APIs provide a negotiation model that allows for multiple applications to share peripherals connected to the computer.</span></span>

<span data-ttu-id="a3b99-172">同じコンピューター上の 2 番目のアプリケーションが別のアプリケーションによって既に要求された PointOfService 周辺機器への要求をリクエストすると、**ReleaseDeviceRequested**イベント通知が発行されます。</span><span class="sxs-lookup"><span data-stu-id="a3b99-172">When a second application on the same computer requests a Claim for a PointOfService peripheral that is already claimed by another application, a **ReleaseDeviceRequested** event notification is published.</span></span> <span data-ttu-id="a3b99-173">アクティブな要求のあるアプリケーションは、そのアプリケーションが現在デバイスを使用している場合は、要求を失うことを避けるために **RetainDevice** を呼び出してイベント通知に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3b99-173">The application with the active claim must respond to the event notification by calling **RetainDevice** if the application is currently using the device to avoid losing the claim.</span></span> 

<span data-ttu-id="a3b99-174">アクティブな要求を持つアプリケーションが **RetainDevice** ですぐに応答しない場合は、アプリケーションが中断されたか、またはデバイスが不要であると見なされ、要求が取り消されて新しいアプリケーションに渡されます。</span><span class="sxs-lookup"><span data-stu-id="a3b99-174">If the application with the active claim does not respond with **RetainDevice** right away it is assumed that the application has been suspended or does not need the device and the claim is revoked and given to the new application.</span></span> 

<span data-ttu-id="a3b99-175">イベント ハンドラーを作成するには、まず、 **ReleaseDeviceRequested**イベントと**RetainDevice**します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-175">The first step is to create an event handler which responds to the **ReleaseDeviceRequested** event with **RetainDevice**.</span></span>  

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

<span data-ttu-id="a3b99-176">要求されたデバイスとの関連付けでイベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="a3b99-176">Then register the event handler in association with your claimed device</span></span>

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



### <a name="apis-used-for-claim-negotiation"></a><span data-ttu-id="a3b99-177">要求のネゴシエーションに使用される API</span><span class="sxs-lookup"><span data-stu-id="a3b99-177">APIs used for claim negotiation</span></span>

|<span data-ttu-id="a3b99-178">要求されたデバイス</span><span class="sxs-lookup"><span data-stu-id="a3b99-178">Claimed device</span></span>|<span data-ttu-id="a3b99-179">リリースの通知</span><span class="sxs-lookup"><span data-stu-id="a3b99-179">Release Notification</span></span>| <span data-ttu-id="a3b99-180">デバイスの保持</span><span class="sxs-lookup"><span data-stu-id="a3b99-180">Retain Device</span></span> |
|-|:-|:-|
|<span data-ttu-id="a3b99-181">ClaimedBarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="a3b99-181">ClaimedBarcodeScanner</span></span> | [<span data-ttu-id="a3b99-182">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="a3b99-182">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.releasedevicerequested) | [<span data-ttu-id="a3b99-183">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="a3b99-183">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.retaindevice)
|<span data-ttu-id="a3b99-184">ClaimedCashDrawer</span><span class="sxs-lookup"><span data-stu-id="a3b99-184">ClaimedCashDrawer</span></span> | [<span data-ttu-id="a3b99-185">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="a3b99-185">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.releasedevicerequested) | [<span data-ttu-id="a3b99-186">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="a3b99-186">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.retaindevice)
|<span data-ttu-id="a3b99-187">ClaimedLineDisplay</span><span class="sxs-lookup"><span data-stu-id="a3b99-187">ClaimedLineDisplay</span></span> | [<span data-ttu-id="a3b99-188">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="a3b99-188">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.releasedevicerequested) | [<span data-ttu-id="a3b99-189">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="a3b99-189">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="a3b99-190">ClaimedMagneticStripeReader</span><span class="sxs-lookup"><span data-stu-id="a3b99-190">ClaimedMagneticStripeReader</span></span> | [<span data-ttu-id="a3b99-191">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="a3b99-191">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.releasedevicerequested) | [<span data-ttu-id="a3b99-192">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="a3b99-192">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|<span data-ttu-id="a3b99-193">ClaimedPosPrinter</span><span class="sxs-lookup"><span data-stu-id="a3b99-193">ClaimedPosPrinter</span></span> | [<span data-ttu-id="a3b99-194">ReleaseDeviceRequested</span><span class="sxs-lookup"><span data-stu-id="a3b99-194">ReleaseDeviceRequested</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.releasedevicerequested) | [<span data-ttu-id="a3b99-195">RetainDevice</span><span class="sxs-lookup"><span data-stu-id="a3b99-195">RetainDevice</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.retaindevice)
|
