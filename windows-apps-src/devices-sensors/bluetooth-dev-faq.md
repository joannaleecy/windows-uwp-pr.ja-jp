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
# <a name="bluetooth-developer-faq"></a>Bluetooth に関する開発者向け FAQ

この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a>どのような Api を使用すればよいですか。 Bluetooth クラシック (RFCOMM)、または Bluetooth 低エネルギー (GATT) ですか。
Windows に関連する差に置かれてこの回答を保持してこの一般的なトピックに関するさまざまなディスカッションのオンラインがあります。 一般的なガイドラインを紹介します。

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a>Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)

Bluetooth 低エネルギーをサポートしているデバイスを使って通信する場合は、GATT Api を使用します。 使っている場合は大文字と小文字頻度が低い、低帯域幅が低の電源が必要です、Bluetooth 低エネルギーです。 この機能が含まれている主な名前空間は、 [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile)です。 

**Bluetooth LE を使用しない場合**
- 高帯域幅、頻度の高いシナリオします。 頻繁に大量のデータとの同期を保持する必要がある場合は、Bluetooth クラシックまたはも WiFi の使用を検討してください。 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a>Bluetooth クラシック (Windows.Devices.Bluetooth.Rfcomm)

RFCOMM Api では、開発者、socket 双方向のポート スタイルの通信を実行できます。 Socket がした後、そこから読み書きの方法は、標準。 この実装[Rfcomm チャットのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)に表示されます。 

**Bluetooth Rfcomm を使用しない場合** 
- 通知します。 Bluetooth GATT プロトコルでは、この特定のコマンドがあり、小さい電力大幅と応答時間が短縮になります。 
- 類似性またはプレゼンスの検出を確認します。 [広告 Api](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement)を使用して Bluetooth LE 経由で接続が向上します。 


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

**(14393 と下)** この機能が Bluetooth 低エネルギー (GATT クライアント) で利用できるようにする必要がありますペア、[設定] ページまたは順序の access で[Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) Api を使用してこれらのデバイス

**(15030 および上)** Bluetooth デバイスをペアリングは必要ありません。 新しい非同期 Api の使用などの GetGattServicesAsync GetCharacteristicsAsync リモート デバイスの現在の状態のクエリを実行するためにします。 詳細については、[クライアントのドキュメント](gatt-client.md)を参照してください。 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a>する必要がありますはペアリング デバイスと通信する前によいですか。
一般的には、デバイスを使って信頼されている、長期的なデータの債券場合は、ペアリング (ユーザー設定] ページの参照を促すまたはデバイスの列挙およびペアリング Api を使って)。 (温度センサーまたはビーコン) は、デバイスが公開公開だけを読み取る情報が必要な場合、接続するか、広告の残存作業時間にデバイスのペアリングを作成せずにリッスンします。 デバイスのホストの組み合わせがサポートしていないために、相互運用性の問題を長期的にこのできなくなります。 

## <a name="do-all-windows-devices-support-peripheral-role"></a>すべての Windows デバイスでは、周辺の役割をサポートしてよいですか。

いいえこのハードウェア依存する機能が、方法を提供されて (BluetoothAdapter.IsPeripheralRoleSupported) クエリにサポートされているかどうかどうか。  現在サポートされているデバイスは、Windows Phone の 8992 + RPi3 (Windows IoT)。 

## <a name="can-i-access-these-apis-from-win32"></a>Win32 からこれらの Api にアクセスする方法

はい、これらのすべての Api が連携する必要があります。 このブログでは、[デスクトップ アプリケーションから Windows Api](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/)方法について説明します。 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a>この機能*の挿入 SKU ここ*の上に存在する予定ですか。

**Bluetooth LE**: はい、すべての機能は OneCore があり、機能 Bluetooth LE 重ねると、最新のデバイスで利用可能にする必要があります。 
> 注意: 周辺の役割はハードウェアに依存して一部の Windows Server エディション Bluetooth サポートされていません。 

**Bluetooth BR/EDR (クラシック)**: いくつかのバリエーションが存在しないが、プロファイル レベルのサポートが非常に似ています。 [PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles)と[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)の[RFCOMM](send-or-receive-files-with-rfcomm.md)でこれらのプロファイルがサポートされているドキュメントのドキュメントを参照してください。

