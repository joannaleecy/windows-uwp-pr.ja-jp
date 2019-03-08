---
title: バーコード データの取得と理解
description: 取得して、スキャンしたバーコード データを解釈する方法について説明します。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ece246ffd369ee21c089598f07b2566424757f55
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605967"
---
# <a name="obtain-and-understand-barcode-data"></a><span data-ttu-id="6adcf-104">バーコード データの取得と理解</span><span class="sxs-lookup"><span data-stu-id="6adcf-104">Obtain and understand barcode data</span></span>

<span data-ttu-id="6adcf-105">バーコード スキャナーをセットアップした後は、もちろん方法、スキャンするデータを理解することの必要があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-105">Once you've set up your barcode scanner, you of course need a way of understanding the data that you scan.</span></span> <span data-ttu-id="6adcf-106">バーコードをスキャンするときに、 [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-106">When you scan a barcode, the [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived) event is raised.</span></span> <span data-ttu-id="6adcf-107">[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)このイベントをサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-107">The [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) should subscribe to this event.</span></span> <span data-ttu-id="6adcf-108">**DataReceived**イベントを渡します、 [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)オブジェクトで、バーコード データへのアクセスに使用することができます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-108">The **DataReceived** event passes a [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs) object, which you can use to access the barcode data.</span></span>

## <a name="subscribe-to-the-datareceived-event"></a><span data-ttu-id="6adcf-109">DataReceived イベントをサブスクライブするには</span><span class="sxs-lookup"><span data-stu-id="6adcf-109">Subscribe to the DataReceived event</span></span>

<span data-ttu-id="6adcf-110">作成したら、 **ClaimedBarcodeScanner**、サブスクライブすることがある、 **DataReceived**イベント。</span><span class="sxs-lookup"><span data-stu-id="6adcf-110">Once you have a **ClaimedBarcodeScanner**, have it subscribe to the **DataReceived** event:</span></span>

```cs
claimedBarcodeScanner.DataReceived += ClaimedBarcodeScanner_DataReceived;
```

<span data-ttu-id="6adcf-111">イベント ハンドラーが渡される、 **ClaimedBarcodeScanner**と**BarcodeScannerDataReceivedEventArgs**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="6adcf-111">The event handler will be passed the **ClaimedBarcodeScanner** and a **BarcodeScannerDataReceivedEventArgs** object.</span></span> <span data-ttu-id="6adcf-112">このオブジェクトのバーコード データにアクセスできます[レポート](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report)型のプロパティ、 [BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-112">You can access the barcode data through this object's [Report](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report) property, which is of type [BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport).</span></span>

```cs
private async void ClaimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    // Parse the data
}
```

## <a name="get-the-data"></a><span data-ttu-id="6adcf-113">データを取得します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-113">Get the data</span></span>

<span data-ttu-id="6adcf-114">作成したら、 **BarcodeScannerReport**、アクセスし、バーコード データを解析することができます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-114">Once you have the **BarcodeScannerReport**, you can access and parse the barcode data.</span></span> <span data-ttu-id="6adcf-115">**BarcodeScannerReport**は 3 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-115">**BarcodeScannerReport** has three properties:</span></span>

* <span data-ttu-id="6adcf-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata):完全な生のバーコード データ。</span><span class="sxs-lookup"><span data-stu-id="6adcf-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): The full, raw barcode data.</span></span>
* <span data-ttu-id="6adcf-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel):デコードされたバーコード ラベル、ヘッダー、チェックサム、およびその他の情報は含まれません。</span><span class="sxs-lookup"><span data-stu-id="6adcf-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): The decoded barcode label, which does not include the header, checksum, and other miscellaneous information.</span></span>
* <span data-ttu-id="6adcf-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype):デコードされたバーコード ラベルの種類。</span><span class="sxs-lookup"><span data-stu-id="6adcf-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): The decoded barcode label type.</span></span> <span data-ttu-id="6adcf-119">使用可能な値が定義されている、 [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)クラス。</span><span class="sxs-lookup"><span data-stu-id="6adcf-119">Possible values are defined in the [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies) class.</span></span>

<span data-ttu-id="6adcf-120">いずれかにアクセスする場合**ScanDataLabel**または**ScanDataType**をまず設定する必要があります[IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled)に**true**します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-120">If you want to access either **ScanDataLabel** or **ScanDataType**, you must first set [IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled) to **true**.</span></span>

```cs
claimedBarcodeScanner.IsDecodeDataEnabled = true;
```

### <a name="get-the-scan-data-type"></a><span data-ttu-id="6adcf-121">スキャン データ型を取得します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-121">Get the scan data type</span></span>

<span data-ttu-id="6adcf-122">デコードされたバーコード ラベルの種類を取得することは簡単&mdash;呼び出して[GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)で**ScanDataType**します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-122">Getting the decoded barcode label type is fairly trivial&mdash;we simply call [GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname) on **ScanDataType**.</span></span>

```cs
private string GetSymbology(BarcodeScannerDataReceivedEventArgs args)
{
    return BarcodeSymbologies.GetName(args.Report.ScanDataType);
}
```

### <a name="get-the-scan-data-label"></a><span data-ttu-id="6adcf-123">スキャン データのラベルを取得します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-123">Get the scan data label</span></span>

<span data-ttu-id="6adcf-124">デコードされたバーコード ラベルを取得するには、いくつかの点を認識する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-124">To get the decoded barcode label, there are a few things you have to be aware of.</span></span> <span data-ttu-id="6adcf-125">特定のデータ型にエンコード済みのテキストが含まれている場合かどうか、シンボルは、文字列に変換することができからバッファーを変換をまず確認する必要がありますので専用**ScanDataLabel**を utf-8 でエンコードされた文字列。</span><span class="sxs-lookup"><span data-stu-id="6adcf-125">Only certain data types contain encoded text, so you should first check if the symbology can be converted to a string, and then convert the buffer we get from **ScanDataLabel** to an encoded UTF-8 string.</span></span>

```cs
private string GetDataLabel(BarcodeScannerDataReceivedEventArgs args)
{
    uint scanDataType = args.Report.ScanDataType;

    // Only certain data types contain encoded text.
    // To keep this simple, we'll just decode a few of them.
    if (args.Report.ScanDataLabel == null)
    {
        return "No data";
    }

    // This is not an exhaustive list of symbologies that can be converted to a string.
    else if (scanDataType == BarcodeSymbologies.Upca ||
        scanDataType == BarcodeSymbologies.UpcaAdd2 ||
        scanDataType == BarcodeSymbologies.UpcaAdd5 ||
        scanDataType == BarcodeSymbologies.Upce ||
        scanDataType == BarcodeSymbologies.UpceAdd2 ||
        scanDataType == BarcodeSymbologies.UpceAdd5 ||
        scanDataType == BarcodeSymbologies.Ean8 ||
        scanDataType == BarcodeSymbologies.TfStd)
    {
        // The UPC, EAN8, and 2 of 5 families encode the digits 0..9
        // which are then sent to the app in a UTF8 string (like "01234").
        return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, args.Report.ScanDataLabel);
    }

    // Some other symbologies (typically 2-D symbologies) contain binary data that
    // should not be converted to text.
    else
    {
        return "Decoded data unavailable.";
    }
}
```

### <a name="get-the-raw-scan-data"></a><span data-ttu-id="6adcf-126">生のスキャン データを取得します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-126">Get the raw scan data</span></span>

<span data-ttu-id="6adcf-127">バーコードから、完全な生データを取得することに単純に変換からバッファー **ScanData**を文字列にします。</span><span class="sxs-lookup"><span data-stu-id="6adcf-127">To get the full, raw data from the barcode, we simply convert the buffer we get from **ScanData** into a string.</span></span>

```cs
private string GetRawData(BarcodeScannerDataReceivedEventArgs args)
{
    // Get the full, raw barcode data.
    if (args.Report.ScanData == null)
    {
        return "No data";
    }

    // Just to show that we have the raw data, we'll print the value of the bytes.
    else
    {
        return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, args.Report.ScanData);
    }
}
```

<span data-ttu-id="6adcf-128">これらのデータは、一般に、スキャナーからの配信形式です。</span><span class="sxs-lookup"><span data-stu-id="6adcf-128">These data are, in general, in the format as delivered from the scanner.</span></span> <span data-ttu-id="6adcf-129">メッセージのヘッダーおよびトレーラの情報はために、削除、ただし、アプリケーションに関する有用な情報が含まれていないこれらとスキャナーに固有である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-129">Message header and trailer information are removed, however, since they do not contain useful information for an application and are likely to be scanner-specific.</span></span>

<span data-ttu-id="6adcf-130">一般的なヘッダー情報は、プレフィックス文字 (STX 文字の場合) などです。</span><span class="sxs-lookup"><span data-stu-id="6adcf-130">Common header information is a prefix character (such as an STX character).</span></span> <span data-ttu-id="6adcf-131">共通のトレーラー情報は、スキャナーが 1 つが生成される場合は、ETX または CR の文字) などの終端文字でチェックするブロック文字。</span><span class="sxs-lookup"><span data-stu-id="6adcf-131">Common trailer information is a terminator character (such as an ETX or CR character) and a block check character if one is generated by the scanner.</span></span>

<span data-ttu-id="6adcf-132">1 つが、スキャナーによって返された場合、このプロパティは記号文字を含める必要があります (たとえば、 **A**の UPC A)。</span><span class="sxs-lookup"><span data-stu-id="6adcf-132">This property should include a symbology character if one is returned by the scanner (for example, an **A** for UPC-A).</span></span> <span data-ttu-id="6adcf-133">ラベルに存在する場合は、チェックの数字を含める必要がありますし、スキャナーで返されます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-133">It should also include check digits if they are present in the label and returned by the scanner.</span></span> <span data-ttu-id="6adcf-134">(記号文字とチェック ディジット可能性がありますか、表示されない可能性が、スキャナーの構成に応じてに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6adcf-134">(Note that both symbology characters and check digits may or may not be present, depending upon the scanner configuration.</span></span> <span data-ttu-id="6adcf-135">スキャナーは場合を返しますに存在するがない生成またはこれらが存在しない場合は、それらを計算します)。</span><span class="sxs-lookup"><span data-stu-id="6adcf-135">The scanner will return them if present, but will not generate or calculate them if they are absent.)</span></span>

<span data-ttu-id="6adcf-136">補足のバーコードでは、いくつかの商品をマークすることがあります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-136">Some merchandise may be marked with a supplemental barcode.</span></span> <span data-ttu-id="6adcf-137">このバーコードは、通常はメインのバーコードの右側に配置し、情報の追加 2 つまたは 5 文字から成ます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-137">This barcode is typically placed to the right of the main barcode, and consists of an additional two or five characters of information.</span></span> <span data-ttu-id="6adcf-138">スキャナーが商品を読み取る場合は、メインと補足の両方のバーコードを格納していると、補助文字は、メインの文字に付加されます結果が 1 つのラベルとしてアプリケーションに配信されます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-138">If the scanner reads merchandise that contains both main and supplemental barcodes, the supplemental characters are appended to the main characters, and the result is delivered to the application as one label.</span></span> <span data-ttu-id="6adcf-139">(または補足コードの読み取りを無効にする構成をスキャナーは対応する必要があることに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="6adcf-139">(Note that a scanner may support a configuration that enables or disables the reading of supplemental codes.)</span></span>

<span data-ttu-id="6adcf-140">いくつかの商品とも呼ばれる複数のラベルでマークすることがあります*multisymbol ラベル*または*ラベルを階層化*します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-140">Some merchandise may be marked with multiple labels, sometimes called *multisymbol labels* or *tiered labels*.</span></span> <span data-ttu-id="6adcf-141">バーコードは通常垂直方向に配置され、同じまたは別のコードの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-141">These barcodes are typically arranged vertically, and may be of the same or different symbology.</span></span> <span data-ttu-id="6adcf-142">スキャナーは、複数のラベルを含む商品を読み取り、各バーコードは別のラベルとしてアプリケーションに配信されます。</span><span class="sxs-lookup"><span data-stu-id="6adcf-142">If the scanner reads merchandise that contains multiple labels, each barcode is delivered to the application as a separate label.</span></span> <span data-ttu-id="6adcf-143">これは、現在のバーコードのような標準化の欠如のために必要です。</span><span class="sxs-lookup"><span data-stu-id="6adcf-143">This is necessary due to the current lack of standardization of these barcode types.</span></span> <span data-ttu-id="6adcf-144">1 つは個々 のバーコード データに基づくすべてのバリエーションを特定できません。</span><span class="sxs-lookup"><span data-stu-id="6adcf-144">One is not able to determine all variations based upon the individual barcode data.</span></span> <span data-ttu-id="6adcf-145">アプリケーションでは、ときに、複数のラベルのバーコードが読み取られた返されるデータに基づいて決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6adcf-145">Therefore, the application will need to determine when a multiple label barcode has been read based upon the data returned.</span></span> <span data-ttu-id="6adcf-146">(スキャナーが可能性がありますか、複数のラベルの読み取りをサポートしない可能性がありますに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="6adcf-146">(Note that a scanner may or may not support reading of multiple labels.)</span></span>

<span data-ttu-id="6adcf-147">この値より前のバージョンに設定されます、 **DataReceived**イベントがアプリケーションに発生します。</span><span class="sxs-lookup"><span data-stu-id="6adcf-147">This value is set prior to a **DataReceived** event being raised to the application.</span></span>

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a><span data-ttu-id="6adcf-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="6adcf-148">See also</span></span>
* [<span data-ttu-id="6adcf-149">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="6adcf-149">Barcode scanner</span></span>](pos-barcodescanner.md)
* [<span data-ttu-id="6adcf-150">ClaimedBarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="6adcf-150">ClaimedBarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)
* [<span data-ttu-id="6adcf-151">BarcodeScannerDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="6adcf-151">BarcodeScannerDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)
* [<span data-ttu-id="6adcf-152">BarcodeScannerReport クラス</span><span class="sxs-lookup"><span data-stu-id="6adcf-152">BarcodeScannerReport Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)
* [<span data-ttu-id="6adcf-153">BarcodeSymbologies クラス</span><span class="sxs-lookup"><span data-stu-id="6adcf-153">BarcodeSymbologies Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)
