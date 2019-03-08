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
# <a name="bluetooth-developer-faq"></a>Bluetooth に関する開発者向け FAQ

この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a>どの API を使用すればよいですか。 Bluetooth Classic (RFCOMM) と Bluetooth 低エネルギー (GATT) のどちらですか。
この一般的なトピックに関してはオンラインでもさまざまな議論が行われています。そこで、この回答では Windows に関しての違いについて説明します。 ここでは、一般的なガイドラインをいくつか示します。

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a>Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)

Bluetooth 低エネルギーをサポートするデバイスと通信している場合は、GATT API を使用します。 使用事例が不定期、低帯域幅である場合や、低電力を必要とする場合は、Bluetooth 低エネルギーが適しています。 この機能を含む主な名前空間は、[Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile) です。 

**Bluetooth LE を使用しない場合**
- 高帯域幅で使用頻度の高いシナリオ。 常に大量のデータを同期する必要がある場合は、Bluetooth Classic または WiFi の使用を検討します。 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a>Bluetooth Classic (Windows.Devices.Bluetooth.Rfcomm)

RFCOMM API は、双方向のシリアル ポート スタイルの通信を実行するソケットを開発者に提供します。 ソケットを利用すると、ソケットへの書き込みやソケットからの読み取りの手法が標準的になります。 この実装については、[Rfcomm チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)をご覧ください。 

**Bluetooth Rfcomm を使用しない場合** 
- 通知。 Bluetooth GATT プロトコルにはこのための特定のコマンドがあり、電力消費量が大幅に減少し、応答時間が高速になります。 
- 近接通信またはプレゼンスの検出の確認。 [アドバタイズ API](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement) を使用し、Bluetooth LE 経由で接続することをお勧めします。 


## <a name="why-does-my-bluetooth-le-device-stop-responding-after-a-disconnect"></a>Bluetooth LE デバイスが、切断後、応答を停止する理由を教えてください。

この問題が発生する理由は、一般的にリモート デバイスのペアリング情報が失われるためです。 以前の Bluetooth デバイスの多くは、認証を必要としません。 ユーザーを保護するために、設定アプリから実行されるすべてのペアリング処理では認証が要求されますが、一部のデバイスとの認証方法が不明対処する必要があります。 

Windows 10 リリース 1511 以降では、開発者はこのペアリング処理を制御できるようになりました。 [デバイスの列挙とペアリングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/DeviceEnumerationAndPairing)に関するページでは、新しいデバイスの関連付けのさまざまな側面について詳しく説明しています。

この例では、暗号化を使用していないデバイスとのペアリングを開始します。 この例が動作するのは、リモート デバイスが暗号化や認証の機能を必要としない場合のみであることに注意してください。

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

## <a name="do-i-have-to-pair-bluetooth-devices-before-using-them"></a>Bluetooth デバイスを使用する前にペアリングする必要はありますか。

Bluetooth RFCOMM (クラシック) デバイスでは必要ありません。 Windows 10 リリース 1607 以降では、簡単に近くにあるデバイスを照会し、そのデバイスに接続できます。 更新された[RFCOMM チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)で、この機能について説明しています。 

**(14393 以下)** この機能は、Bluetooth 低エネルギー (GATT クライアント) では使用できないため、これらのデバイスにアクセスするために、[設定] ページで、または [Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) API を使ってペアリングを行う必要があります。

**(15030 以上)** Bluetooth デバイスのペアリングは不要になりました。 リモート デバイスの現在の状態を照会するために、GetGattServicesAsync や GetCharacteristicsAsync のような新しい非同期 API を使います。 詳しくは、[クライアントのマニュアル](gatt-client.md)をご覧ください。 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a>デバイスと通信する前にペアリングが必要になるのはどのような場合ですか。
一般に、デバイスとの信頼された長期的な接続が必要な場合は、([設定] ページにユーザーを誘導するか、デバイスの列挙とペアリングの API を使って) デバイスとペアリングします。 (温度センサーまたはビーコンなど) は、デバイスが一般公開から情報を読み取る必要な場合、接続するか、提供情報、デバイスとペアリングするすべての作業を加えずにリッスンします。 デバイスのホストはペアリングをサポートしていないため、これにより長期的な相互運用性の問題を防止できます。 

## <a name="do-all-windows-devices-support-peripheral-role"></a>すべての Windows デバイスが周辺機器の役割をサポートしていますか。

いいえ。これはハードウェア依存の機能ですが、この機能がサポートされているかどうかを照会するためのメソッド (BluetoothAdapter.IsPeripheralRoleSupported) が用意されています。  現在サポートされているデバイスには、8992 以上を搭載した Windows Phone や RPi3 (Windows IoT) が含まれます。 

## <a name="can-i-access-these-apis-from-win32"></a>Win32 からこれらの API にアクセスできますか。

はい。これらすべての API が機能します。 このブログでは、[デスクトップ アプリケーションから Windows API](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/) を呼び出す方法の詳細を説明しています。 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a>この機能は、*[-Insert SKU here-]* (ここに SKU を挿入) にも表示されますか。

**Bluetooth LE**:はい、すべての機能は OneCore であり、機能している Bluetooth LE スタックを使用した最新のデバイスで使用可能にする必要があります。 
> 注意:周辺のロールは、ハードウェアに依存して、一部の Windows Server エディションは、Bluetooth をサポートしません。 

**Bluetooth BR/EDR (クラシック)**:いくつかのバリエーションが存在しますが、プロファイル レベルのサポートとよく似ていますがあります。 [RFCOMM](send-or-receive-files-with-rfcomm.md) に関するドキュメントや、[PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles) や[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)でのこれらのサポートされるプロファイルに関するドキュメントをご覧ください。

