---
author: msatranjr
title: Bluetooth に関する開発者向け FAQ
description: この記事には、UWP Bluetooth API に関連するよく寄せられる質問に対する回答が含まれています。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: e7dee32d-3756-430d-a026-32c1ee288a85
ms.localizationpriority: medium
ms.openlocfilehash: 03ee8074a64b210d33498c8de135a76900d968f0
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5753109"
---
# <a name="bluetooth-developer-faq"></a><span data-ttu-id="6b0a1-104">Bluetooth に関する開発者向け FAQ</span><span class="sxs-lookup"><span data-stu-id="6b0a1-104">Bluetooth Developer FAQ</span></span>

<span data-ttu-id="6b0a1-105">この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-105">This article contains answers to commonly asked UWP Bluetooth API questions.</span></span>

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a><span data-ttu-id="6b0a1-106">どのような Api を使って行うかどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-106">What APIs do I use?</span></span> <span data-ttu-id="6b0a1-107">Bluetooth クラシック (RFCOMM)、または Bluetooth 低エネルギー (GATT) かどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-107">Bluetooth Classic (RFCOMM) or Bluetooth Low Energy (GATT)?</span></span>
<span data-ttu-id="6b0a1-108">この一般的なトピックに関するさまざまなコメント オンラインみましょうに関しては、Windows の違いの正方形に収まらないこの応答を維持がします。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-108">There are various discussions online around this general topic so let's keep this answer squarely on the difference with respect to Windows.</span></span> <span data-ttu-id="6b0a1-109">一般的なガイドラインを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-109">Here are some general guidelines:</span></span>

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a><span data-ttu-id="6b0a1-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span><span class="sxs-lookup"><span data-stu-id="6b0a1-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span></span>

<span data-ttu-id="6b0a1-111">Bluetooth 低エネルギーをサポートするデバイスと通信している場合は、GATT Api を使用します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-111">Use the GATT APIs when you are communicating with a device that supports Bluetooth Low Energy.</span></span> <span data-ttu-id="6b0a1-112">使用している場合、事例または不定期な低の帯域幅ですが、低電力が必要です Bluetooth 低エネルギーは、応答します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-112">If you're use case is infrequent, low bandwidth or requires low power, Bluetooth Low Energy is the answer.</span></span> <span data-ttu-id="6b0a1-113">この機能が含まれている主な名前空間では、 [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile)です。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-113">The main namespace that includes this functionality is [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile).</span></span> 

**<span data-ttu-id="6b0a1-114">Bluetooth LE を使用しない場合</span><span class="sxs-lookup"><span data-stu-id="6b0a1-114">When not to use Bluetooth LE</span></span>**
- <span data-ttu-id="6b0a1-115">高帯域幅、頻度の高いシナリオ。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-115">High bandwidth, high frequency scenarios.</span></span> <span data-ttu-id="6b0a1-116">常に大量のデータとの同期を維持する必要がある場合は、Bluetooth 従来型またはも WiFi の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-116">If you need to constantly keep sync with large amounts of data, consider using Bluetooth classic or maybe even WiFi.</span></span> 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a><span data-ttu-id="6b0a1-117">Bluetooth クラシック (Windows.Devices.Bluetooth.Rfcomm)</span><span class="sxs-lookup"><span data-stu-id="6b0a1-117">Bluetooth Classic (Windows.Devices.Bluetooth.Rfcomm)</span></span>

<span data-ttu-id="6b0a1-118">RFCOMM Api は、スタイル、シリアル ポートの双方向通信を実行する、ソケットを開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-118">The RFCOMM APIs give developers a socket to perform bi-direction serial port style communication.</span></span> <span data-ttu-id="6b0a1-119">ソケットをした後への書き込みと、そこからの読み取りの方法は、非常に標準的です。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-119">Once you've got a socket, the methods of writing to and reading from it are fairly standard.</span></span> <span data-ttu-id="6b0a1-120">[Rfcomm チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)では、この実装が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-120">An implementation of this is presented in the [Rfcomm Chat sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat).</span></span> 

**<span data-ttu-id="6b0a1-121">Bluetooth Rfcomm を使用しない場合</span><span class="sxs-lookup"><span data-stu-id="6b0a1-121">When not to use Bluetooth Rfcomm</span></span>** 
- <span data-ttu-id="6b0a1-122">通知します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-122">Notifications.</span></span> <span data-ttu-id="6b0a1-123">Bluetooth GATT プロトコルはこの特定のコマンドしほど電源描画大幅にし、応答時間が短縮が発生します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-123">The Bluetooth GATT protocol has a specific command for this and will result in significantly less power draw and faster response times.</span></span> 
- <span data-ttu-id="6b0a1-124">近接通信またはプレゼンスの検出を確認します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-124">Checking for proximity or presence detection.</span></span> <span data-ttu-id="6b0a1-125">[アドバタイズ Api](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement)を使用し、Bluetooth LE 経由で接続する方が適切です。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-125">Better to use the [Advertisement APIs](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement) and connect over Bluetooth LE.</span></span> 


## <a name="why-does-my-bluetooth-le-device-stop-responding-after-a-disconnect"></a><span data-ttu-id="6b0a1-126">Bluetooth LE デバイスが、切断後、応答を停止する理由を教えてください。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-126">Why does my Bluetooth LE Device stop responding after a disconnect?</span></span>

<span data-ttu-id="6b0a1-127">この問題が発生する理由は、一般的にリモート デバイスのペアリング情報が失われるためです。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-127">The common reason this happens is because the remote device has lost pairing information.</span></span> <span data-ttu-id="6b0a1-128">以前の Bluetooth デバイスの多くは、認証を必要としません。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-128">A lot of earlier Bluetooth devices don't require authentication.</span></span> <span data-ttu-id="6b0a1-129">ユーザーを保護するために、設定アプリから実行されるすべてのペアリング処理では認証が要求されますが、一部のデバイスとの認証方法が不明対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-129">To protect the user, all pairing ceremonies performed from the Settings app will require authentication and some devices don't know how to deal with that.</span></span> 

<span data-ttu-id="6b0a1-130">Windows 10 リリース 1511 以降では、開発者はこのペアリング処理を制御できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-130">Starting with Windows 10 release 1511, developers have control over the pairing ceremony.</span></span> <span data-ttu-id="6b0a1-131">[デバイスの列挙とペアリングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)に関するページでは、新しいデバイスの関連付けのさまざまな側面について詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-131">The [Device Enumeration and Pairing Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing) details the various aspects of associating new devices.</span></span>

<span data-ttu-id="6b0a1-132">この例では、暗号化を使用していないデバイスとのペアリングを開始します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-132">In this example, we initiate pairing with a device using no encryption.</span></span> <span data-ttu-id="6b0a1-133">この例が動作するのは、リモート デバイスが暗号化や認証の機能を必要としない場合のみであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-133">Note, this will only work if the remote device does not require encryption or authentication to function.</span></span>

```csharp
// Get ceremony type and protection level selections
// You must select at least ConfirmOnly or the pairing attempt will fail
    DevicePairingKinds ceremonySelected = DevicePairingKinds.ConfirmOnly;

//  Workaround remote devices losing pairing information
    DevicePairingProtectionLevel protectionLevel = DevicePairingProtectionLevel.None

    DeviceInformationCustomPairing customPairing = deviceInfoDisp.DeviceInformation.Pairing.Custom;

// Declare an event handler - you don't need to do much in PairingRequestedHandler since the ceremony is "None"
    customPairing.PairingRequested += PairingRequestedHandler;
    DevicePairingResult result = await customPairing.PairAsync(ceremonySelected, protectionLevel);
```

## <a name="do-i-have-to-pair-bluetooth-devices-before-using-them"></a><span data-ttu-id="6b0a1-134">Bluetooth デバイスを使用する前にペアリングする必要はありますか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-134">Do I have to pair Bluetooth devices before using them?</span></span>

<span data-ttu-id="6b0a1-135">Bluetooth RFCOMM (クラシック) デバイスでは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-135">You don't have to for Bluetooth RFCOMM (classic) devices.</span></span> <span data-ttu-id="6b0a1-136">Windows 10 リリース 1607 以降では、簡単に近くにあるデバイスを照会し、そのデバイスに接続できます。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-136">Starting with Windows 10 release 1607, you can simply query for nearby devices and connect to them.</span></span> <span data-ttu-id="6b0a1-137">更新された[RFCOMM チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)で、この機能について説明しています。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-137">The updated [RFCOMM Chat Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat) shows this functionality.</span></span> 

<span data-ttu-id="6b0a1-138">**(14393 と下)** 引き続きしたイメージをペアのいずれかの設定] ページまたはアクセスの順序で[Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) Api を使用してこれらのデバイスは、この機能を Bluetooth Low Energy (GATT クライアント) を利用できません。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-138">**(14393 and below)** This feature is not available for Bluetooth Low Energy (GATT Client), so you will still have to pair either through the Settings page or using the [Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) APIs in order access these devices.</span></span>

<span data-ttu-id="6b0a1-139">**(15030 以降)** Bluetooth デバイスのペアリングが不要になった。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-139">**(15030 and above)** Pairing Bluetooth devices is no longer needed.</span></span> <span data-ttu-id="6b0a1-140">新しい非同期 Api を使用して、リモート デバイスの現在の状態を照会するために GetGattServicesAsync や GetCharacteristicsAsync などの。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-140">Use the new Async APIs like GetGattServicesAsync and GetCharacteristicsAsync in order to query the current state of the remote device.</span></span> <span data-ttu-id="6b0a1-141">詳細については、[クライアントのドキュメント](gatt-client.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-141">See the [Client docs](gatt-client.md) for more details.</span></span> 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a><span data-ttu-id="6b0a1-142">する必要がありますか、デバイスとペアリングと通信する前にかどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-142">When should I pair with a device before communicating with it?</span></span>
<span data-ttu-id="6b0a1-143">一般に、デバイスで、信頼されている、長期的な接着状態を必要とする場合は、([設定] ページにユーザーを誘導するまたはデバイスの列挙とペアリングの Api を使用する) とペアリングします。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-143">Generally, if you require a trusted, long-term bond with a device, pair with it (either directing the user to the settings page or using the Device Enumeration and Pairing APIs).</span></span> <span data-ttu-id="6b0a1-144">(温度センサーまたはビーコン) をデバイスが近日公開だけをオフの情報を読み取る必要がある場合、接続するしたり、デバイスとペアリングする任意の作業を行うことがなくアドバタイズをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-144">If you simply need to read information off the device that is exposed publically (a temperature sensor or beacon), then connect or listen for advertisements without making any effort to pair with the device.</span></span> <span data-ttu-id="6b0a1-145">これにより、相互運用性の問題、長い目でデバイスのホストはペアリングをサポートしていないためです。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-145">This will prevent interoperability problems in the long run because a host of devices do not support pairing.</span></span> 

## <a name="do-all-windows-devices-support-peripheral-role"></a><span data-ttu-id="6b0a1-146">すべての Windows デバイスでは、周辺機器ロールをサポートしてかどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-146">Do all Windows devices support Peripheral Role?</span></span>

<span data-ttu-id="6b0a1-147">No – これは、ハードウェア依存する機能が、用意されているメソッド (BluetoothAdapter.IsPeripheralRoleSupported) クエリをサポートされているかどうかどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-147">No – this is a hardware dependent feature, but a method is provided (BluetoothAdapter.IsPeripheralRoleSupported) to query whether it is supported or not.</span></span>  <span data-ttu-id="6b0a1-148">現在サポートされているデバイスには、Windows Phone 8992 + および RPi3 (Windows IoT)。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-148">Currently supported devices include Windows Phone on 8992+ and RPi3 (Windows IoT).</span></span> 

## <a name="can-i-access-these-apis-from-win32"></a><span data-ttu-id="6b0a1-149">Win32 からこれらの Api にアクセスできますか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-149">Can I access these APIs from Win32?</span></span>

<span data-ttu-id="6b0a1-150">はい、これらすべての Api が動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-150">Yes, all these APIs should work.</span></span> <span data-ttu-id="6b0a1-151">このブログでは、[デスクトップ アプリケーションからの Windows Api](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/)を呼び出す方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-151">This blog details the way to call [Windows APIs from Desktop applications](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/).</span></span> 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a><span data-ttu-id="6b0a1-152">この機能なって *- 挿入 SKU ここで*の上に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-152">Is this functionality supposed to exist on *-Insert SKU here-*?</span></span>

<span data-ttu-id="6b0a1-153">**Bluetooth LE**: はい、すべての機能 OneCore では、Bluetooth LE スタックに機能するいると、最新のデバイスで利用可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-153">**Bluetooth LE**: Yes, all functionality is in OneCore and should be available on most recent devices w/ a functioning Bluetooth LE stack.</span></span> 
> <span data-ttu-id="6b0a1-154">注意: 周辺機器ロールは、ハードウェアに依存して、Bluetooth をサポートしていない一部の Windows Server エディション。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-154">Caveat: Peripheral Role is hardware dependent and some Windows Server Editions don't support Bluetooth.</span></span> 

<span data-ttu-id="6b0a1-155">**Bluetooth BR/EDR (クラシック)**: いくつかのバリエーションの存在があって、プロファイル レベルのサポートとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-155">**Bluetooth BR/EDR (Classic)**: Some variations exist but by and large, they have very similar profile level support.</span></span> <span data-ttu-id="6b0a1-156">[PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles)と[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)の[RFCOMM](send-or-receive-files-with-rfcomm.md)とこれらのサポートされているプロファイル ドキュメントにドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b0a1-156">See the docs on [RFCOMM](send-or-receive-files-with-rfcomm.md) and these supported profile docs for [PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles) and [Phone](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)</span></span>

