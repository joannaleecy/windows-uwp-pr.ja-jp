---
author: TerryWarwick
title: PointOfService デバイスを要求し、モデルを有効にします。
description: PointOfService 要求について学習し、モデルを有効にします。
ms.author: jken
ms.date: 06/19/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: df9c4764b8f7d752a132d6759054660f481cce55
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6026005"
---
# <a name="point-of-service-device-claim-and-enable-model"></a>Point of Service デバイス要求およびモデルを有効にします。

## <a name="claiming-for-exclusive-use"></a>排他的使用のための要求

PointOfService デバイス オブジェクトを正常に作成したら、入出力にデバイスを使用する前に、デバイスの種類に適切な要求方法を使用して要求する必要があります。  要求により、多くのデバイスの機能に対する排他的アクセスがアプリケーションに付与され、あるアプリケーションが別のアプリケーションによるデバイスの使用を妨げないようにします。  排他的使用のために一度に PointOfService デバイスを要求できるアプリケーションは 1 つだけです。 

> [!Note]
> 要求アクションは、デバイスを排他的にロックを確立していますが、操作の状態には配置されません。  詳細については、 [I/O 操作用のデバイスを有効にする](#Enable-device-for-I/O-operations)を参照してください。

### <a name="apis-used-to-claim--release"></a>要求/リリースに使用する Api

|デバイス|要求 | Release | 
|-|:-|:-|
|BarcodeScanner | [BarcodeScanner.ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync) | [ClaimedBarcodeScanner.Close](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.close) |
|CashDrawer | [CashDrawer.ClaimDrawerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.claimdrawerasync) | [ClaimedCashDrawer.Close](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.close) | 
|LineDisplay | [LineDisplay.ClaimAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.claimasync) |  [ClaimedineDisplay.Close](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.close) | 
|MagneticStripeReader | [MagneticStripeReader.ClaimReaderAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.claimreaderasync) |  [ClaimedMagneticStripeReader.Close](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.close) | 
|PosPrinter | [PosPrinter.ClaimPrinterAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.claimprinterasync) |  [ClaimedPosPrinter.Close](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.close) | 
 | 

## <a name="enable-device-for-io-operations"></a>I/O 操作用のデバイスを有効にします。

要求アクションは単に、デバイスを排他的の権利を確立していますが、操作の状態には配置されません。  イベントを受信または出力の操作を実行するのには、 **EnableAsync**を使用してデバイスを有効にする必要があります。  逆に、デバイスまたは実行中の出力からイベントをリッスンしてを停止する**DisableAsync**を呼び出すことができます。  デバイスの状態を判断**IsEnabled**を使用することもできます。

### <a name="apis-used-enable--disable"></a>使用されている Api を有効にする/無効にします。

| デバイス | 有効化 | 無効 | IsEnabled かどうか。 |
|-|:-|:-|:-|
|ClaimedBarcodeScanner | [EnableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.enableasync) | [DisableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.disableasync) | [IsEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isenabled) | 
|ClaimedCashDrawer | [EnableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.enableasync) | [DisableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.disableasync) | [IsEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.isenabled) |
|ClaimedLineDisplay | Applicable¹ しません。 | Applicable¹ しません。 | Applicable¹ しません。 | 
|ClaimedMagneticStripeReader | [EnableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.enableasync) | [DisableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.disableasync) | [IsEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.isenabled) |  
|ClaimedPosPrinter | [EnableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.enableasync) | [DisableAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.disableasyc) | [IsEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.isenabled) |
|

¹ ライン ディスプレイでは、I/O 操作用にデバイスを明示的に有効にする必要はありません。  有効にするとは、I/O を実行する PointOfService LineDisplay Api によって自動的に実行されます。

## <a name="code-sample-claim-and-enable"></a>サンプル コード: 要求し、有効化

次のサンプルでは、バーコード スキャナー オブジェクトを正常に作成した後で、バーコード スキャナーのデバイスを要求する方法を示しています。

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
> 次のような場合に要求が失われることがあります。
> 1. 別のアプリで同じデバイスの要求がリクエストされ、アプリが **ReleaseDeviceRequested** イベントへの応答として **RetainDevice** を発行しなかった   (詳細については、以下の「[要求のネゴシエーション](#Claim-negotiation)」を参照してください)。
> 2. アプリが中断され、その結果としてデバイス オブジェクトが終了し、結果的に要求が有効ではなくなった  (詳細については、「[デバイス オブジェクトのライフサイクル](pos-basics-deviceobject.md#device-object-lifecycle)」を参照してください)。


## <a name="claim-negotiation"></a>要求のネゴシエーション

Windows はマルチタスク環境であるため、同じコンピューター上の複数のアプリケーションで連携して周辺機器にアクセスする必要がある可能性があります。  PointOfService API は、コンピューターに接続されている周辺機器を複数のアプリケーションが共有できるようにするネゴシエーション モデルを提供します。

同じコンピューター上の 2 番目のアプリケーションが別のアプリケーションによって既に要求された PointOfService 周辺機器への要求をリクエストすると、**ReleaseDeviceRequested**イベント通知が発行されます。 アクティブな要求のあるアプリケーションは、そのアプリケーションが現在デバイスを使用している場合は、要求を失うことを避けるために **RetainDevice** を呼び出してイベント通知に応答する必要があります。 

アクティブな要求を持つアプリケーションが **RetainDevice** ですぐに応答しない場合は、アプリケーションが中断されたか、またはデバイスが不要であると見なされ、要求が取り消されて新しいアプリケーションに渡されます。 

最初の手順では、 **RetainDevice**で**ReleaseDeviceRequested**イベントに応答するイベント ハンドラーを作成します。  

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

要求されたデバイスに関連付け、イベント ハンドラーを登録します。

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



### <a name="apis-used-for-claim-negotiation"></a>要求のネゴシエーションに使用される API

|要求されたデバイス|リリースの通知| デバイスの保持 |
|-|:-|:-|
|ClaimedBarcodeScanner | [ReleaseDeviceRequested](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.releasedevicerequested) | [RetainDevice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.retaindevice)
|ClaimedCashDrawer | [ReleaseDeviceRequested](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.releasedevicerequested) | [RetainDevice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer.retaindevice)
|ClaimedLineDisplay | [ReleaseDeviceRequested](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.releasedevicerequested) | [RetainDevice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|ClaimedMagneticStripeReader | [ReleaseDeviceRequested](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.releasedevicerequested) | [RetainDevice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay.retaindevice)
|ClaimedPosPrinter | [ReleaseDeviceRequested](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.releasedevicerequested) | [RetainDevice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter.retaindevice)
|
