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
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6273308"
---
# <a name="bluetooth-developer-faq"></a>Bluetooth に関する開発者向け FAQ

この記事には、UWP Bluetooth API のよく寄せられる質問に対する回答が含まれています。

## <a name="what-apis-do-i-use-bluetooth-classic-rfcomm-or-bluetooth-low-energy-gatt"></a>どのような Api を使って行うかどうか。 Bluetooth クラシック (RFCOMM)、または Bluetooth 低エネルギー (GATT) かどうか。
この一般的なトピックに関するさまざまなコメント オンラインみましょうに関しては、Windows の違いの正方形に収まらないこの応答を維持がします。 一般的なガイドラインを以下に示します。

### <a name="bluetooth-le-windowsdevicesbluetoothgenericattributeprofile"></a>Bluetooth LE (Windows.Devices.Bluetooth.GenericAttributeProfile)

Bluetooth 低エネルギーをサポートしているデバイスと通信している場合は、GATT Api を使用します。 使用している場合、事例または不定期な低の帯域幅ですが、低電力を必要と Bluetooth 低エネルギーは、応答。 この機能が含まれている主な名前空間では、 [Windows.Devices.Bluetooth.GenericAttributeProfile](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Bluetooth.GenericAttributeProfile)です。 

**Bluetooth LE を使用しない場合**
- 帯域幅を高く、頻度の高いシナリオ。 常に大量のデータとの同期を維持する必要がある場合は、Bluetooth 従来型またはも WiFi の使用を検討してください。 

### <a name="bluetooth-classic-windowsdevicesbluetoothrfcomm"></a>Bluetooth 従来の (Windows.Devices.Bluetooth.Rfcomm)

RFCOMM Api は、スタイル、シリアル ポートの双方向通信を実行するソケットを開発者に提供します。 ソケットをした後への書き込みと、そこからの読み取りの方法は、非常に標準的です。 [Rfcomm チャット サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BluetoothRfcommChat)では、この実装が表示されます。 

**Bluetooth Rfcomm を使用しない場合** 
- 通知します。 Bluetooth GATT プロトコルでは、この特定のコマンドを持つし、結果、以下の電力が大幅と応答時間が短縮します。 
- 近接通信またはプレゼンスの検出を確認します。 [アドバタイズ Api](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement)を使用し、Bluetooth LE 経由で接続する方が適切です。 


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

**(14393 と下)** まだ必要であるためペアのいずれかの設定ページまたはアクセスの順序で[Windows.Devices.Enumeration](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx) Api を使用してこれらのデバイスは、この機能を Bluetooth Low Energy (GATT クライアント) を利用できません。

**(15030 と上記)** Bluetooth デバイスのペアリングが不要になった。 新しい非同期 Api を使用して、リモート デバイスの現在の状態を照会するために GetGattServicesAsync や GetCharacteristicsAsync などの。 詳細については、[クライアントのドキュメント](gatt-client.md)を参照してください。 

## <a name="when-should-i-pair-with-a-device-before-communicating-with-it"></a>する必要がありますか、デバイスとペアリングと通信する前にかどうか。
一般に、デバイスで信頼されている、長期の接着状態を必要とする場合は、(設定のページにユーザーを誘導するか、デバイスの列挙とペアリングの Api を使用する) とペアリングします。 (温度センサーまたはビーコン) はデバイスが近日公開だけをオフの情報を読み取る必要がある場合、接続するか、デバイスとペアリングする任意の作業を行うことがなく、アドバタイズをリッスンします。 これにより、相互運用性の問題、長い目でデバイスのホストはペアリングをサポートしていないためです。 

## <a name="do-all-windows-devices-support-peripheral-role"></a>すべての Windows デバイスでは、周辺機器ロールをサポートしてかどうか。

No – これは、ハードウェアの依存する機能が、用意されているメソッド (BluetoothAdapter.IsPeripheralRoleSupported) クエリをサポートされているかどうかどうか。  現在サポートされているデバイスなどの Windows Phone 8992 + RPi3 (Windows IoT)。 

## <a name="can-i-access-these-apis-from-win32"></a>Win32 からこれらの Api にアクセスできますか。

はい、これらすべての Api が動作する必要があります。 このブログでは、[デスクトップ アプリケーションからの Windows Api](https://blogs.windows.com/buildingapps/2017/01/25/calling-windows-10-apis-desktop-application/)を呼び出す方法について説明します。 
## <a name="is-this-functionality-supposed-to-exist-on--insert-sku-here-"></a>この機能は *- 挿入 SKU こちら*の上に存在するべきかどうか。

**Bluetooth LE**: はい、すべての機能 OneCore では、機能の Bluetooth LE スタックで最新のデバイスで利用できる必要があります。 
> 注意: 周辺機器ロールは、ハードウェアに依存して、一部の Windows Server エディションは、Bluetooth をサポートしません。 

**Bluetooth BR/EDR (クラシック)**: いくつかのバリエーションの存在があって、プロファイル レベルのサポートとよく似ています。 [PC](https://support.microsoft.com/en-us/help/10568/windows-10-supported-bluetooth-profiles)と[電話](https://support.microsoft.com/en-us/help/10569/windows-10-mobile-supported-bluetooth-profiles)の[RFCOMM](send-or-receive-files-with-rfcomm.md)とこれらのサポートされているプロファイル ドキュメントにドキュメントをご覧ください。

