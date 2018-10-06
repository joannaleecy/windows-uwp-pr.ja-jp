---
author: eliotcowley
title: 取得し、磁気ストライプのデータを理解します。
description: 取得および磁気ストライプからデータを解釈する方法について説明します。
ms.author: elcowle
ms.date: 10/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 店舗販売時点サービス、pos、磁気ストライプ リーダー
ms.localizationpriority: medium
ms.openlocfilehash: ad954e8c03d92307fa72ead236d5428ac2bdddab
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4391454"
---
# <a name="obtain-and-understand-magnetic-stripe-data"></a><span data-ttu-id="d0133-104">取得し、磁気ストライプのデータを理解します。</span><span class="sxs-lookup"><span data-stu-id="d0133-104">Obtain and understand magnetic stripe data</span></span>

<span data-ttu-id="d0133-105">[Point of Service の概要](pos-basics.md)で説明する手順を使用して、アプリケーションで、磁気ストライプ リーダーをセットアップした後は、そこからデータを取得するを開始する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="d0133-105">Once you've set up your magnetic stripe reader in your application using the steps outlined in [Getting started with Point of Service](pos-basics.md), you're ready to start getting data from it.</span></span>

## <a name="subscribe-to-datareceived-events"></a><span data-ttu-id="d0133-106">サブスクライブする \* DataReceived イベント</span><span class="sxs-lookup"><span data-stu-id="d0133-106">Subscribe to \*DataReceived events</span></span>

<span data-ttu-id="d0133-107">リーダーでは、スワイプ カード、認識されるたびに 3 つのイベントのいずれかが発生します。</span><span class="sxs-lookup"><span data-stu-id="d0133-107">Whenever the reader recognizes a swiped card, it will raise one of three events:</span></span>

* <span data-ttu-id="d0133-108">[AamvaCardDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived): 自動車カードがスワイプしたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="d0133-108">[AamvaCardDataReceived Event](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived): Occurs when a motor vehicle card is swiped.</span></span>
* <span data-ttu-id="d0133-109">[BankCardDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived): 銀行カードがスワイプしたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="d0133-109">[BankCardDataReceived Event](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.aamvacarddatareceived): Occurs when a bank card is swiped.</span></span>
* <span data-ttu-id="d0133-110">[VendorSpecificDataReceived イベント](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.vendorspecificdatareceived): ベンダー固有のカードのスワイプしたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="d0133-110">[VendorSpecificDataReceived Event](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader.vendorspecificdatareceived): Occurs when a vendor-specific card is swiped.</span></span>

<span data-ttu-id="d0133-111">のみ、アプリケーションは、磁気ストライプ リーダーによってサポートされているイベントをサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0133-111">Your application only needs to subscribe to the events that are supported by the magnetic stripe reader.</span></span> <span data-ttu-id="d0133-112">[MagneticStripeReader.SupportedCardTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.supportedcardtypes
)でサポートされるカードの種類を確認できます。</span><span class="sxs-lookup"><span data-stu-id="d0133-112">You can see what types of cards are supported with [MagneticStripeReader.SupportedCardTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.supportedcardtypes
).</span></span>

<span data-ttu-id="d0133-113">次のコードは、3 つのサブスクライブを示しています \***DataReceived**イベント。</span><span class="sxs-lookup"><span data-stu-id="d0133-113">The following code demonstrates subscribing to the three \***DataReceived** events:</span></span>

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

<span data-ttu-id="d0133-114">イベント ハンドラーは、 [ClaimedMagneticStripeReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)と*引数*オブジェクトの型は、イベントによって異なりますが渡されます。</span><span class="sxs-lookup"><span data-stu-id="d0133-114">The event handler will be passed the [ClaimedMagneticStripeReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader) and an *args* object, whose type will vary depending on the event:</span></span>

* <span data-ttu-id="d0133-115">**AamvaCardDataReceived**イベント: [MagneticStripeReaderAamvaCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderaamvacarddatareceivedeventargs)</span><span class="sxs-lookup"><span data-stu-id="d0133-115">**AamvaCardDataReceived** event: [MagneticStripeReaderAamvaCardDataReceivedEventArgs Class](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderaamvacarddatareceivedeventargs)</span></span>
* <span data-ttu-id="d0133-116">**BankCardDataReceived**イベント: [MagneticStripeReaderBankCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderbankcarddatareceivedeventargs)</span><span class="sxs-lookup"><span data-stu-id="d0133-116">**BankCardDataReceived** event: [MagneticStripeReaderBankCardDataReceivedEventArgs Class](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderbankcarddatareceivedeventargs)</span></span>
* <span data-ttu-id="d0133-117">**VendorSpecificDataReceived**イベント: [MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadervendorspecificcarddatareceivedeventargs)</span><span class="sxs-lookup"><span data-stu-id="d0133-117">**VendorSpecificDataReceived** event: [MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs Class](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadervendorspecificcarddatareceivedeventargs)</span></span>

## <a name="get-the-data"></a><span data-ttu-id="d0133-118">データを取得します。</span><span class="sxs-lookup"><span data-stu-id="d0133-118">Get the data</span></span>

<span data-ttu-id="d0133-119">**AamvaCardDataReceived**と**BankCardDataReceived**イベントは、*引数*オブジェクトから直接、データの一部を取得できます。</span><span class="sxs-lookup"><span data-stu-id="d0133-119">For the **AamvaCardDataReceived** and **BankCardDataReceived** events, you can get some of the data directly from the *args* object.</span></span> <span data-ttu-id="d0133-120">次の例は、いくつかのプロパティを取得し、それらのメンバー変数に割り当てるには。</span><span class="sxs-lookup"><span data-stu-id="d0133-120">The following example demonstrates getting a few properties and assigning them to member variables:</span></span>

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

<span data-ttu-id="d0133-121">ただし、*引数*のパラメーターのプロパティは、**レポート**オブジェクトを通じて**VendorSpecificDataReceived**イベントからのすべてのデータを含む、いくつかのデータを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0133-121">However, some data, including all data from the **VendorSpecificDataReceived** event, must be retrieved through the **Report** object, which is a property of the *args* parameter.</span></span> <span data-ttu-id="d0133-122">これは、型[MagneticStripeReaderReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport)のです。</span><span class="sxs-lookup"><span data-stu-id="d0133-122">This is of type [MagneticStripeReaderReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport).</span></span>

<span data-ttu-id="d0133-123">[CardType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.cardtype)プロパティを使用して、どの種類のカードがスワイプされたいらいらして、 [Track1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track1)、 [Track2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track2)、 [Track3](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track3)、 [Track4](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track4)からデータを解釈する方法を通知するために使用していることができます。</span><span class="sxs-lookup"><span data-stu-id="d0133-123">You can use the [CardType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.cardtype) property to figure out what type of card has been swiped, and then use that to inform how you interpret the data from [Track1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track1), [Track2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track2), [Track3](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track3), and [Track4](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport.track4).</span></span>

<span data-ttu-id="d0133-124">各トラックのデータは、 [MagneticStripeReaderTrackData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata)オブジェクトとして表されます。</span><span class="sxs-lookup"><span data-stu-id="d0133-124">The data from each of the tracks are represented as [MagneticStripeReaderTrackData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata) objects.</span></span> <span data-ttu-id="d0133-125">このクラスからは、次の種類のデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d0133-125">From this class, you can get the following types of data:</span></span>

* <span data-ttu-id="d0133-126">[データ](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.data): raw またはデコードされたデータ。</span><span class="sxs-lookup"><span data-stu-id="d0133-126">[Data](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.data): The raw or decoded data.</span></span>
* <span data-ttu-id="d0133-127">[DiscretionaryData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.discretionarydata): 随意データ。</span><span class="sxs-lookup"><span data-stu-id="d0133-127">[DiscretionaryData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.discretionarydata): The discretionary data.</span></span> 
* <span data-ttu-id="d0133-128">[EncryptedData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.encrypteddata): 暗号化されたデータ。</span><span class="sxs-lookup"><span data-stu-id="d0133-128">[EncryptedData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata.encrypteddata): The encrypted data.</span></span>

<span data-ttu-id="d0133-129">次のコード スニペットは、レポートと track のデータを取得し、カードの種類を確認します。</span><span class="sxs-lookup"><span data-stu-id="d0133-129">The following code snippet gets the report and the track data, and then checks the card type:</span></span>

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

## <a name="see-also"></a><span data-ttu-id="d0133-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="d0133-130">See also</span></span>

* [<span data-ttu-id="d0133-131">磁気ストライプ リーダー</span><span class="sxs-lookup"><span data-stu-id="d0133-131">Magnetic stripe reader</span></span>](pos-magnetic-stripe-reader.md)
* [<span data-ttu-id="d0133-132">ClaimedMagneticStripeReader クラス</span><span class="sxs-lookup"><span data-stu-id="d0133-132">ClaimedMagneticStripeReader Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)
* [<span data-ttu-id="d0133-133">MagneticStripeReaderAamvaCardDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="d0133-133">MagneticStripeReaderAamvaCardDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderaamvacarddatareceivedeventargs)
* [<span data-ttu-id="d0133-134">MagneticStripeReaderBankCardDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="d0133-134">MagneticStripeReaderBankCardDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderbankcarddatareceivedeventargs)
* [<span data-ttu-id="d0133-135">MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="d0133-135">MagneticStripeReaderVendorSpecificCardDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadervendorspecificcarddatareceivedeventargs)
* [<span data-ttu-id="d0133-136">MagneticStripeReaderReport</span><span class="sxs-lookup"><span data-stu-id="d0133-136">MagneticStripeReaderReport</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereaderreport)
* [<span data-ttu-id="d0133-137">MagneticStripeReaderTrackData</span><span class="sxs-lookup"><span data-stu-id="d0133-137">MagneticStripeReaderTrackData</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereadertrackdata)