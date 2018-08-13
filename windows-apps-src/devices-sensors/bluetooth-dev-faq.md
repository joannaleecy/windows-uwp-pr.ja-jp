---
author: msatranjr
title: Bluetooth に関する開発者向け FAQ
description: この記事には、UWP Bluetooth API に関連するよく寄せられる質問に対する回答が含まれています。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: e7dee32d-3756-430d-a026-32c1ee288a85
ms.localizationpriority: medium
ms.openlocfilehash: c0af6a19e17a62ed82c32e68ea1732e1f51d4641
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "301926"
---
# <a name="bluetooth-developer-faq"></a><span data-ttu-id="128a4-104">Bluetooth に関する開発者向け FAQ</span><span class="sxs-lookup"><span data-stu-id="128a4-104">Bluetooth Developer FAQ</span></span>

<span data-ttu-id="128a4-105">この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。</span><span class="sxs-lookup"><span data-stu-id="128a4-105">This article contains answers to commonly asked UWP Bluetooth API questions.</span></span>

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a><span data-ttu-id="128a4-106">どのような Api を使用すればよいですか。</span><span class="sxs-lookup"><span data-stu-id="128a4-106">What APIs do I use?</span></span> <span data-ttu-id="128a4-107">Bluetooth クラシック (RFCOMM)、または Bluetooth 低エネルギー (GATT) ですか。</span><span class="sxs-lookup"><span data-stu-id="128a4-107">Bluetooth Classic (RFCOMM) or Bluetooth Low Energy (GATT)?</span></span>
<span data-ttu-id="128a4-108">Windows に関連する差に置かれてこの回答を保持してこの一般的なトピックに関するさまざまなディスカッションのオンラインがあります。</span><span class="sxs-lookup"><span data-stu-id="128a4-108">There are various discussions online around this general topic so let's keep this answer squarely on the difference with respect to Windows.</span></span> <span data-ttu-id="128a4-109">一般的なガイドラインを紹介します。</span><span class="sxs-lookup"><span data-stu-id="128a4-109">Here are some general guidelines:</span></span>

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a><span data-ttu-id="128a4-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span><span class="sxs-lookup"><span data-stu-id="128a4-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span></span>

<span data-ttu-id="128a4-111">Bluetooth 低エネルギーをサポートしているデバイスを使って通信する場合は、GATT Api を使用します。</span><span class="sxs-lookup"><span data-stu-id="128a4-111">Use the GATT APIs when you are communicating with a device that supports Bluetooth Low Energy.</span></span> <span data-ttu-id="128a4-112">使っている場合は大文字と小文字頻度が低い、低帯域幅が低の電源が必要です、Bluetooth 低エネルギーです。</span><span class="sxs-lookup"><span data-stu-id="128a4-112">If you're use case is infrequent, low bandwidth or requires low power, Bluetooth Low Energy is the answer.</span></span> <span data-ttu-id="128a4-113">この機能が含まれている主な名前空間は、 [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile)です。</span><span class="sxs-lookup"><span data-stu-id="128a4-113">The main namespace that includes this functionality is [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile).</span></span> 

**<span data-ttu-id="128a4-114">Bluetooth LE を使用しない場合</span><span class="sxs-lookup"><span data-stu-id="128a4-114">When not to use Bluetooth LE</span></span>**
- <span data-ttu-id="128a4-115">高帯域幅、頻度の高いシナリオします。</span><span class="sxs-lookup"><span data-stu-id="128a4-115">High bandwidth, high frequency scenarios.</span></span> <span data-ttu-id="128a4-116">頻繁に大量のデータとの同期を保持する必要がある場合は、Bluetooth クラシックまたはも WiFi の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="128a4-116">If you need to constantly keep sync with large amounts of data, consider using Bluetooth classic or maybe even WiFi.</span></span> 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a><span data-ttu-id="128a4-117">Bluetooth クラシック (Windows.Devices.Bluetooth.Rfcomm)</span><span class="sxs-lookup"><span data-stu-id="128a4-117">Bluetooth Classic (Windows.Devices.Bluetooth.Rfcomm)</span></span>

<span data-ttu-id="128a4-118">RFCOMM Api では、開発者、socket 双方向のポート スタイルの通信を実行できます。</span><span class="sxs-lookup"><span data-stu-id="128a4-118">The RFCOMM APIs give developers a socket to perform bi-direction serial port style communication.</span></span> <span data-ttu-id="128a4-119">Socket がした後、そこから読み書きの方法は、標準。</span><span class="sxs-lookup"><span data-stu-id="128a4-119">Once you've got a socket, the methods of writing to and reading from it are fairly standard.</span></span> <span data-ttu-id="128a4-120">この実装[Rfcomm チャットのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)に表示されます。</span><span class="sxs-lookup"><span data-stu-id="128a4-120">An implementation of this is presented in the [Rfcomm Chat sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat).</span></span> 

**<span data-ttu-id="128a4-121">Bluetooth Rfcomm を使用しない場合</span><span class="sxs-lookup"><span data-stu-id="128a4-121">When not to use Bluetooth Rfcomm</span></span>** 
- <span data-ttu-id="128a4-122">通知します。</span><span class="sxs-lookup"><span data-stu-id="128a4-122">Notifications.</span></span> <span data-ttu-id="128a4-123">Bluetooth GATT プロトコルでは、この特定のコマンドがあり、小さい電力大幅と応答時間が短縮になります。</span><span class="sxs-lookup"><span data-stu-id="128a4-123">The Bluetooth GATT protocol has a specific command for this and will result in significantly less power draw and faster response times.</span></span> 
- <span data-ttu-id="128a4-124">類似性またはプレゼンスの検出を確認します。</span><span class="sxs-lookup"><span data-stu-id="128a4-124">Checking for proximity or presence detection.</span></span> <span data-ttu-id="128a4-125">[広告 Api](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement)を使用して Bluetooth LE 経由で接続が向上します。</span><span class="sxs-lookup"><span data-stu-id="128a4-125">Better to use the [Advertisement APIs](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement) and connect over Bluetooth LE.</span></span> 


## <a name="why-does-my-bluetooth-le-device-stop-responding-after-a-disconnect"></a><span data-ttu-id="128a4-126">Bluetooth LE デバイスが、切断後、応答を停止する理由を教えてください。</span><span class="sxs-lookup"><span data-stu-id="128a4-126">Why does my Bluetooth LE Device stop responding after a disconnect?</span></span>

<span data-ttu-id="128a4-127">この問題が発生する理由は、一般的にリモート デバイスのペアリング情報が失われるためです。</span><span class="sxs-lookup"><span data-stu-id="128a4-127">The common reason this happens is because the remote device has lost pairing information.</span></span> <span data-ttu-id="128a4-128">以前の Bluetooth デバイスの多くは、認証を必要としません。</span><span class="sxs-lookup"><span data-stu-id="128a4-128">A lot of earlier Bluetooth devices don't require authentication.</span></span> <span data-ttu-id="128a4-129">ユーザーを保護するために、設定アプリから実行されるすべてのペアリング処理では認証が要求されますが、一部のデバイスとの認証方法が不明対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="128a4-129">To protect the user, all pairing ceremonies performed from the Settings app will require authentication and some devices don't know how to deal with that.</span></span> 

<span data-ttu-id="128a4-130">Windows 10 リリース 1511 以降では、開発者はこのペアリング処理を制御できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="128a4-130">Starting with Windows 10 release 1511, developers have control over the pairing ceremony.</span></span> <span data-ttu-id="128a4-131">[デバイスの列挙とペアリングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)に関するページでは、新しいデバイスの関連付けのさまざまな側面について詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="128a4-131">The [Device Enumeration and Pairing Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing) details the various aspects of associating new devices.</span></span>

<span data-ttu-id="128a4-132">この例では、暗号化を使用していないデバイスとのペアリングを開始します。</span><span class="sxs-lookup"><span data-stu-id="128a4-132">In this example, we initiate pairing with a device using no encryption.</span></span> <span data-ttu-id="128a4-133">この例が動作するのは、リモート デバイスが暗号化や認証の機能を必要としない場合のみであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="128a4-133">Note, this will only work if the remote device does not require encryption or authentication to function.</span></span>

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

## <a name="do-i-have-to-pair-bluetooth-devices-before-using-them"></a><span data-ttu-id="128a4-134">Bluetooth デバイスを使用する前にペアリングする必要はありますか。</span><span class="sxs-lookup"><span data-stu-id="128a4-134">Do I have to pair Bluetooth devices before using them?</span></span>

<span data-ttu-id="128a4-135">Bluetooth RFCOMM (クラシック) デバイスでは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="128a4-135">You don't have to for Bluetooth RFCOMM (classic) devices.</span></span> <span data-ttu-id="128a4-136">Windows 10 リリース 1607 以降では、簡単に近くにあるデバイスを照会し、そのデバイスに接続できます。</span><span class="sxs-lookup"><span data-stu-id="128a4-136">Starting with Windows 10 release 1607, you can simply query for nearby devices and connect to them.</span></span> <span data-ttu-id="128a4-137">更新された[RFCOMM チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)で、この機能について説明しています。</span><span class="sxs-lookup"><span data-stu-id="128a4-137">The updated [RFCOMM Chat Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat) shows this functionality.</span></span> 

<span data-ttu-id="128a4-138">**(14393 と下)** この機能が Bluetooth 低エネルギー (GATT クライアント) で利用できるようにする必要がありますペア、[設定] ページまたは順序の access で[Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) Api を使用してこれらのデバイス</span><span class="sxs-lookup"><span data-stu-id="128a4-138">**(14393 and below)** This feature is not available for Bluetooth Low Energy (GATT Client), so you will still have to pair either through the Settings page or using the [Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) APIs in order access these devices.</span></span>

<span data-ttu-id="128a4-139">**(15030 および上)** Bluetooth デバイスをペアリングは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="128a4-139">**(15030 and above)** Pairing Bluetooth devices is no longer needed.</span></span> <span data-ttu-id="128a4-140">新しい非同期 Api の使用などの GetGattServicesAsync GetCharacteristicsAsync リモート デバイスの現在の状態のクエリを実行するためにします。</span><span class="sxs-lookup"><span data-stu-id="128a4-140">Use the new Async APIs like GetGattServicesAsync and GetCharacteristicsAsync in order to query the current state of the remote device.</span></span> <span data-ttu-id="128a4-141">詳細については、[クライアントのドキュメント](gatt-client.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="128a4-141">See the [Client docs](gatt-client.md) for more details.</span></span> 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a><span data-ttu-id="128a4-142">する必要がありますはペアリング デバイスと通信する前によいですか。</span><span class="sxs-lookup"><span data-stu-id="128a4-142">When should I pair with a device before communicating with it?</span></span>
<span data-ttu-id="128a4-143">一般的には、デバイスを使って信頼されている、長期的なデータの債券場合は、ペアリング (ユーザー設定] ページの参照を促すまたはデバイスの列挙およびペアリング Api を使って)。</span><span class="sxs-lookup"><span data-stu-id="128a4-143">Generally, if you require a trusted, long-term bond with a device, pair with it (either directing the user to the settings page or using the Device Enumeration and Pairing APIs).</span></span> <span data-ttu-id="128a4-144">(温度センサーまたはビーコン) は、デバイスが公開公開だけを読み取る情報が必要な場合、接続するか、広告の残存作業時間にデバイスのペアリングを作成せずにリッスンします。</span><span class="sxs-lookup"><span data-stu-id="128a4-144">If you simply need to read information off the device that is exposed publically (a temperature sensor or beacon), then connect or listen for advertisements without making any effort to pair with the device.</span></span> <span data-ttu-id="128a4-145">デバイスのホストの組み合わせがサポートしていないために、相互運用性の問題を長期的にこのできなくなります。</span><span class="sxs-lookup"><span data-stu-id="128a4-145">This will prevent interoperability problems in the long run because a host of devices do not support pairing.</span></span> 

## <a name="do-all-windows-devices-support-peripheral-role"></a><span data-ttu-id="128a4-146">すべての Windows デバイスでは、周辺の役割をサポートしてよいですか。</span><span class="sxs-lookup"><span data-stu-id="128a4-146">Do all Windows devices support Peripheral Role?</span></span>

<span data-ttu-id="128a4-147">いいえこのハードウェア依存する機能が、方法を提供されて (BluetoothAdapter.IsPeripheralRoleSupported) クエリにサポートされているかどうかどうか。</span><span class="sxs-lookup"><span data-stu-id="128a4-147">No – this is a hardware dependent feature, but a method is provided (BluetoothAdapter.IsPeripheralRoleSupported) to query whether it is supported or not.</span></span>  <span data-ttu-id="128a4-148">現在サポートされているデバイスは、Windows Phone の 8992 + RPi3 (Windows IoT)。</span><span class="sxs-lookup"><span data-stu-id="128a4-148">Currently supported devices include Windows Phone on 8992+ and RPi3 (Windows IoT).</span></span> 

## <a name="can-i-access-these-apis-from-win32"></a><span data-ttu-id="128a4-149">Win32 からこれらの Api にアクセスする方法</span><span class="sxs-lookup"><span data-stu-id="128a4-149">Can I access these APIs from Win32?</span></span>

<span data-ttu-id="128a4-150">はい、これらのすべての Api が連携する必要があります。</span><span class="sxs-lookup"><span data-stu-id="128a4-150">Yes, all these APIs should work.</span></span> <span data-ttu-id="128a4-151">このブログでは、[デスクトップ アプリケーションから Windows Api](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/)方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="128a4-151">This blog details the way to call [Windows APIs from Desktop applications](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/).</span></span> 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a><span data-ttu-id="128a4-152">この機能*の挿入 SKU ここ*の上に存在する予定ですか。</span><span class="sxs-lookup"><span data-stu-id="128a4-152">Is this functionality supposed to exist on *-Insert SKU here-*?</span></span>

<span data-ttu-id="128a4-153">**Bluetooth LE**: はい、すべての機能は OneCore があり、機能 Bluetooth LE 重ねると、最新のデバイスで利用可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="128a4-153">**Bluetooth LE**: Yes, all functionality is in OneCore and should be available on most recent devices w/ a functioning Bluetooth LE stack.</span></span> 
> <span data-ttu-id="128a4-154">注意: 周辺の役割はハードウェアに依存して一部の Windows Server エディション Bluetooth サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="128a4-154">Caveat: Peripheral Role is hardware dependent and some Windows Server Editions don't support Bluetooth.</span></span> 

<span data-ttu-id="128a4-155">**Bluetooth BR/EDR (クラシック)**: いくつかのバリエーションが存在しないが、プロファイル レベルのサポートが非常に似ています。</span><span class="sxs-lookup"><span data-stu-id="128a4-155">**Bluetooth BR/EDR (Classic)**: Some variations exist but by and large, they have very similar profile level support.</span></span> <span data-ttu-id="128a4-156">[PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles)と[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)の[RFCOMM](send-or-receive-files-with-rfcomm.md)でこれらのプロファイルがサポートされているドキュメントのドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="128a4-156">See the docs on [RFCOMM](send-or-receive-files-with-rfcomm.md) and these supported profile docs for [PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles) and [Phone](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)</span></span>

