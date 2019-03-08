---
title: Bluetooth に関する開発者向け FAQ
description: この記事には、UWP Bluetooth API に関連するよく寄せられる質問に対する回答が含まれています。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e7dee32d-3756-430d-a026-32c1ee288a85
ms.localizationpriority: medium
ms.openlocfilehash: 4cc1bafb90b20083d55a622873dea7be5efbf5b7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633487"
---
# <a name="bluetooth-developer-faq"></a><span data-ttu-id="4f2b5-104">Bluetooth に関する開発者向け FAQ</span><span class="sxs-lookup"><span data-stu-id="4f2b5-104">Bluetooth Developer FAQ</span></span>

<span data-ttu-id="4f2b5-105">この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-105">This article contains answers to commonly asked UWP Bluetooth API questions.</span></span>

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a><span data-ttu-id="4f2b5-106">どの API を使用すればよいですか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-106">What APIs do I use?</span></span> <span data-ttu-id="4f2b5-107">Bluetooth Classic (RFCOMM) と Bluetooth 低エネルギー (GATT) のどちらですか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-107">Bluetooth Classic (RFCOMM) or Bluetooth Low Energy (GATT)?</span></span>
<span data-ttu-id="4f2b5-108">この一般的なトピックに関してはオンラインでもさまざまな議論が行われています。そこで、この回答では Windows に関しての違いについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-108">There are various discussions online around this general topic so let's keep this answer squarely on the difference with respect to Windows.</span></span> <span data-ttu-id="4f2b5-109">ここでは、一般的なガイドラインをいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-109">Here are some general guidelines:</span></span>

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a><span data-ttu-id="4f2b5-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span><span class="sxs-lookup"><span data-stu-id="4f2b5-110">Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)</span></span>

<span data-ttu-id="4f2b5-111">Bluetooth 低エネルギーをサポートするデバイスと通信している場合は、GATT API を使用します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-111">Use the GATT APIs when you are communicating with a device that supports Bluetooth Low Energy.</span></span> <span data-ttu-id="4f2b5-112">使用事例が不定期、低帯域幅である場合や、低電力を必要とする場合は、Bluetooth 低エネルギーが適しています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-112">If you're use case is infrequent, low bandwidth or requires low power, Bluetooth Low Energy is the answer.</span></span> <span data-ttu-id="4f2b5-113">この機能を含む主な名前空間は、[Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile) です。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-113">The main namespace that includes this functionality is [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile).</span></span> 

<span data-ttu-id="4f2b5-114">**Bluetooth LE を使用しない場合**</span><span class="sxs-lookup"><span data-stu-id="4f2b5-114">**When not to use Bluetooth LE**</span></span>
- <span data-ttu-id="4f2b5-115">高帯域幅で使用頻度の高いシナリオ。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-115">High bandwidth, high frequency scenarios.</span></span> <span data-ttu-id="4f2b5-116">常に大量のデータを同期する必要がある場合は、Bluetooth Classic または WiFi の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-116">If you need to constantly keep sync with large amounts of data, consider using Bluetooth classic or maybe even WiFi.</span></span> 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a><span data-ttu-id="4f2b5-117">Bluetooth Classic (Windows.Devices.Bluetooth.Rfcomm)</span><span class="sxs-lookup"><span data-stu-id="4f2b5-117">Bluetooth Classic (Windows.Devices.Bluetooth.Rfcomm)</span></span>

<span data-ttu-id="4f2b5-118">RFCOMM API は、双方向のシリアル ポート スタイルの通信を実行するソケットを開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-118">The RFCOMM APIs give developers a socket to perform bi-direction serial port style communication.</span></span> <span data-ttu-id="4f2b5-119">ソケットを利用すると、ソケットへの書き込みやソケットからの読み取りの手法が標準的になります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-119">Once you've got a socket, the methods of writing to and reading from it are fairly standard.</span></span> <span data-ttu-id="4f2b5-120">この実装については、[Rfcomm チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-120">An implementation of this is presented in the [Rfcomm Chat sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat).</span></span> 

<span data-ttu-id="4f2b5-121">**Bluetooth Rfcomm を使用しない場合**</span><span class="sxs-lookup"><span data-stu-id="4f2b5-121">**When not to use Bluetooth Rfcomm**</span></span> 
- <span data-ttu-id="4f2b5-122">通知。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-122">Notifications.</span></span> <span data-ttu-id="4f2b5-123">Bluetooth GATT プロトコルにはこのための特定のコマンドがあり、電力消費量が大幅に減少し、応答時間が高速になります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-123">The Bluetooth GATT protocol has a specific command for this and will result in significantly less power draw and faster response times.</span></span> 
- <span data-ttu-id="4f2b5-124">近接通信またはプレゼンスの検出の確認。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-124">Checking for proximity or presence detection.</span></span> <span data-ttu-id="4f2b5-125">[アドバタイズ API](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement) を使用し、Bluetooth LE 経由で接続することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-125">Better to use the [Advertisement APIs](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement) and connect over Bluetooth LE.</span></span> 


## <a name="why-does-my-bluetooth-le-device-stop-responding-after-a-disconnect"></a><span data-ttu-id="4f2b5-126">Bluetooth LE デバイスが、切断後、応答を停止する理由を教えてください。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-126">Why does my Bluetooth LE Device stop responding after a disconnect?</span></span>

<span data-ttu-id="4f2b5-127">この問題が発生する理由は、一般的にリモート デバイスのペアリング情報が失われるためです。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-127">The common reason this happens is because the remote device has lost pairing information.</span></span> <span data-ttu-id="4f2b5-128">以前の Bluetooth デバイスの多くは、認証を必要としません。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-128">A lot of earlier Bluetooth devices don't require authentication.</span></span> <span data-ttu-id="4f2b5-129">ユーザーを保護するために、設定アプリから実行されるすべてのペアリング処理では認証が要求されますが、一部のデバイスとの認証方法が不明対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-129">To protect the user, all pairing ceremonies performed from the Settings app will require authentication and some devices don't know how to deal with that.</span></span> 

<span data-ttu-id="4f2b5-130">Windows 10 リリース 1511 以降では、開発者はこのペアリング処理を制御できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-130">Starting with Windows 10 release 1511, developers have control over the pairing ceremony.</span></span> <span data-ttu-id="4f2b5-131">[デバイスの列挙とペアリングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)に関するページでは、新しいデバイスの関連付けのさまざまな側面について詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-131">The [Device Enumeration and Pairing Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing) details the various aspects of associating new devices.</span></span>

<span data-ttu-id="4f2b5-132">この例では、暗号化を使用していないデバイスとのペアリングを開始します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-132">In this example, we initiate pairing with a device using no encryption.</span></span> <span data-ttu-id="4f2b5-133">この例が動作するのは、リモート デバイスが暗号化や認証の機能を必要としない場合のみであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-133">Note, this will only work if the remote device does not require encryption or authentication to function.</span></span>

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

## <a name="do-i-have-to-pair-bluetooth-devices-before-using-them"></a><span data-ttu-id="4f2b5-134">Bluetooth デバイスを使用する前にペアリングする必要はありますか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-134">Do I have to pair Bluetooth devices before using them?</span></span>

<span data-ttu-id="4f2b5-135">Bluetooth RFCOMM (クラシック) デバイスでは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-135">You don't have to for Bluetooth RFCOMM (classic) devices.</span></span> <span data-ttu-id="4f2b5-136">Windows 10 リリース 1607 以降では、簡単に近くにあるデバイスを照会し、そのデバイスに接続できます。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-136">Starting with Windows 10 release 1607, you can simply query for nearby devices and connect to them.</span></span> <span data-ttu-id="4f2b5-137">更新された[RFCOMM チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)で、この機能について説明しています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-137">The updated [RFCOMM Chat Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat) shows this functionality.</span></span> 

<span data-ttu-id="4f2b5-138">**(14393 以下)** この機能は、Bluetooth 低エネルギー (GATT クライアント) では使用できないため、これらのデバイスにアクセスするために、[設定] ページで、または [Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) API を使ってペアリングを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-138">**(14393 and below)** This feature is not available for Bluetooth Low Energy (GATT Client), so you will still have to pair either through the Settings page or using the [Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) APIs in order access these devices.</span></span>

<span data-ttu-id="4f2b5-139">**(15030 以上)** Bluetooth デバイスのペアリングは不要になりました。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-139">**(15030 and above)** Pairing Bluetooth devices is no longer needed.</span></span> <span data-ttu-id="4f2b5-140">リモート デバイスの現在の状態を照会するために、GetGattServicesAsync や GetCharacteristicsAsync のような新しい非同期 API を使います。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-140">Use the new Async APIs like GetGattServicesAsync and GetCharacteristicsAsync in order to query the current state of the remote device.</span></span> <span data-ttu-id="4f2b5-141">詳しくは、[クライアントのマニュアル](gatt-client.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-141">See the [Client docs](gatt-client.md) for more details.</span></span> 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a><span data-ttu-id="4f2b5-142">デバイスと通信する前にペアリングが必要になるのはどのような場合ですか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-142">When should I pair with a device before communicating with it?</span></span>
<span data-ttu-id="4f2b5-143">一般に、デバイスとの信頼された長期的な接続が必要な場合は、([設定] ページにユーザーを誘導するか、デバイスの列挙とペアリングの API を使って) デバイスとペアリングします。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-143">Generally, if you require a trusted, long-term bond with a device, pair with it (either directing the user to the settings page or using the Device Enumeration and Pairing APIs).</span></span> <span data-ttu-id="4f2b5-144">(温度センサーまたはビーコンなど) は、デバイスが一般公開から情報を読み取る必要な場合、接続するか、提供情報、デバイスとペアリングするすべての作業を加えずにリッスンします。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-144">If you simply need to read information off the device that is exposed publicly (a temperature sensor or beacon), then connect or listen for advertisements without making any effort to pair with the device.</span></span> <span data-ttu-id="4f2b5-145">デバイスのホストはペアリングをサポートしていないため、これにより長期的な相互運用性の問題を防止できます。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-145">This will prevent interoperability problems in the long run because a host of devices do not support pairing.</span></span> 

## <a name="do-all-windows-devices-support-peripheral-role"></a><span data-ttu-id="4f2b5-146">すべての Windows デバイスが周辺機器の役割をサポートしていますか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-146">Do all Windows devices support Peripheral Role?</span></span>

<span data-ttu-id="4f2b5-147">いいえ。これはハードウェア依存の機能ですが、この機能がサポートされているかどうかを照会するためのメソッド (BluetoothAdapter.IsPeripheralRoleSupported) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-147">No – this is a hardware dependent feature, but a method is provided (BluetoothAdapter.IsPeripheralRoleSupported) to query whether it is supported or not.</span></span>  <span data-ttu-id="4f2b5-148">現在サポートされているデバイスには、8992 以上を搭載した Windows Phone や RPi3 (Windows IoT) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-148">Currently supported devices include Windows Phone on 8992+ and RPi3 (Windows IoT).</span></span> 

## <a name="can-i-access-these-apis-from-win32"></a><span data-ttu-id="4f2b5-149">Win32 からこれらの API にアクセスできますか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-149">Can I access these APIs from Win32?</span></span>

<span data-ttu-id="4f2b5-150">はい。これらすべての API が機能します。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-150">Yes, all these APIs should work.</span></span> <span data-ttu-id="4f2b5-151">このブログでは、[デスクトップ アプリケーションから Windows API](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/) を呼び出す方法の詳細を説明しています。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-151">This blog details the way to call [Windows APIs from Desktop applications](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/).</span></span> 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a><span data-ttu-id="4f2b5-152">この機能は、*[-Insert SKU here-]* (ここに SKU を挿入) にも表示されますか。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-152">Is this functionality supposed to exist on *-Insert SKU here-*?</span></span>

<span data-ttu-id="4f2b5-153">**Bluetooth LE**:はい、すべての機能は OneCore であり、機能している Bluetooth LE スタックを使用した最新のデバイスで使用可能にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-153">**Bluetooth LE**: Yes, all functionality is in OneCore and should be available on most recent devices w/ a functioning Bluetooth LE stack.</span></span> 
> <span data-ttu-id="4f2b5-154">注意:周辺のロールは、ハードウェアに依存して、一部の Windows Server エディションは、Bluetooth をサポートしません。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-154">Caveat: Peripheral Role is hardware dependent and some Windows Server Editions don't support Bluetooth.</span></span> 

<span data-ttu-id="4f2b5-155">**Bluetooth BR/EDR (クラシック)**:いくつかのバリエーションが存在しますが、プロファイル レベルのサポートとよく似ていますがあります。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-155">**Bluetooth BR/EDR (Classic)**: Some variations exist but by and large, they have very similar profile level support.</span></span> <span data-ttu-id="4f2b5-156">[RFCOMM](send-or-receive-files-with-rfcomm.md) に関するドキュメントや、[PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles) や[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)でのこれらのサポートされるプロファイルに関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f2b5-156">See the docs on [RFCOMM](send-or-receive-files-with-rfcomm.md) and these supported profile docs for [PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles) and [Phone](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)</span></span>

