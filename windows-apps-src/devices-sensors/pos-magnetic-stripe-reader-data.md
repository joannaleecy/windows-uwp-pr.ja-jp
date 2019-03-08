---
title: 磁気ストライプ データの取得と理解
description: 取得して、磁気ストライプからのデータを解釈する方法について説明します。
ms.date: 10/04/2018
ms.topic: article
keywords: windows 10、uwp は、サービス、pos、磁気ストライプ リーダーのポイントします。
ms.localizationpriority: medium
ms.openlocfilehash: 1805213c7c30ccbc67fb96098f11480703589bb4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651607"
---
# <a name="obtain-and-understand-magnetic-stripe-data"></a>磁気ストライプ データの取得と理解

後で説明する手順を使用して、アプリケーションで、磁気ストライプ リーダーを設定した[Point of Service の概要](pos-basics.md)、そこからのデータの取得を開始する準備ができました。

## <a name="subscribe-to-datareceived-events"></a>購読 * DataReceived イベント

リーダーがいるカードが認識されるたびに 3 つのイベントのいずれかが発生します。

* [AamvaCardDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived):車両のカードが読み取られるときに発生します。
* [BankCardDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived):銀行のカードが読み取られるときに発生します。
* [VendorSpecificDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.vendorspecificdatareceived):ベンダー固有のカードが読み取られるときに発生します。

のみ、アプリケーションは、磁気ストライプ リーダーでサポートされているイベントをサブスクライブする必要があります。 サポートされるカードの種類を参照してください[MagneticStripeReader.SupportedCardTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.supportedcardtypes
)します。

次のコードは、3 つのサブスクライブ ***DataReceived**イベント。

```cs
private void SubscribeToEvents(ClaimedMagneticStripeReader claimedReader, MagneticStripeReader reader)
{
    foreach (var type in reader.SupportedCardTypes)
    {
        if (item == MagneticStripeReaderCardTypes.Aamva)
        {
            claimedReader.AamvaCardDataReceived += Reader_AamvaCardDataReceived;
        }
        else if (item == MagneticStripeReaderCardTypes.Bank)
        {
            claimedReader.BankCardDataReceived += Reader_BankCardDataReceived;
        }
        else if (item == MagneticStripeReaderCardTypes.ExtendedBase)
        {
            claimedReader.VendorSpecificDataReceived += Reader_VendorSpecificDataReceived;
        }
    }
}
```

イベント ハンドラーが渡される、 [ClaimedMagneticStripeReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)と*args*オブジェクト、型は、イベントによって異なります。

* **AamvaCardDataReceived**イベント。[MagneticStripeReaderAamvaCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderaamvacarddatareceivedeventargs)
* **BankCardDataReceived**イベント。[MagneticStripeReaderBankCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderbankcarddatareceivedeventargs)
* **VendorSpecificDataReceived**イベント。[MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadervendorspecificcarddatareceivedeventargs)

## <a name="get-the-data"></a>データを取得します。

**AamvaCardDataReceived**と**BankCardDataReceived**イベントを取得できますから直接データの一部、 *args*オブジェクト。 次の例では、いくつかのプロパティを取得して、メンバー変数を割り当てることを示しています。

```cs
private string _accountNumber;
private string _expirationDate;
private string _firstName;

private void Reader_BankCardDataReceived(
    ClaimedMagneticStripeReader sender, 
    MagneticStripeReaderBankCardDataReceivedEventArgs args)
{
    _accountNumber = args.AccountNumber;
    _expirationDate = args.ExpirationDate;
    _firstName = args.FirstName;
    // etc...
}
```

ただしのすべてのデータを含む、一部のデータ、 **VendorSpecificDataReceived**を通じてイベントを取得する必要があります、**レポート**プロパティであるオブジェクトの*args*パラメーター。 これは、型の[MagneticStripeReaderReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport)します。

使用することができます、 [CardType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.cardtype)カードの種類が読み取られると、確認しからのデータを解釈する方法を通知するために使用するプロパティ[Track1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track1)、 [Track2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track2)、 [Track3](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track3)、および[Track4](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track4)します。

各トラックからのデータとして表される[MagneticStripeReaderTrackData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata)オブジェクト。 このクラスから、次の種類のデータを取得できます。

* [データ](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.data):生またはデコードされたデータ。
* [DiscretionaryData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.discretionarydata):任意のデータ。 
* [EncryptedData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.encrypteddata):暗号化されたデータ。

次のコード スニペットでは、レポートと、追跡データを取得し、し、カードの種類を確認します。

```cs
private void GetTrackData(MagneticStripeReaderBankCardDataReceivedEventArgs args)
{
    MagneticStripeReaderReport report = args.Report;
    IBuffer track1 = report.Track1.Data;
    IBuffer track2 = report.Track2.Data;
    IBuffer track3 = report.Track3.Data;
    IBuffer track4 = report.Track4.Data;

    if (report.CardType == MagneticStripeReaderCardTypes.Aamva)
    {
        // Card type is AAMVA
    }
    else if (report.CardType == MagneticStripeReaderCardTypes.Bank)
    {
        // Card type is bank card
    }
    else if (report.CardType == MagneticStripeReaderCardTypes.ExtendedBase)
    {
        // Card type is vendor-specific
    }
    else if (report.CardType == MagneticStripeReaderCardTypes.Unknown)
    {
        // Card type is unknown
    }
}
```

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a>関連項目

* [磁気ストライプ リーダー](pos-magnetic-stripe-reader.md)
* [ClaimedMagneticStripeReader クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)
* [MagneticStripeReaderAamvaCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderaamvacarddatareceivedeventargs)
* [MagneticStripeReaderBankCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderbankcarddatareceivedeventargs)
* [MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadervendorspecificcarddatareceivedeventargs)
* [MagneticStripeReaderReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport)
* [MagneticStripeReaderTrackData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata)