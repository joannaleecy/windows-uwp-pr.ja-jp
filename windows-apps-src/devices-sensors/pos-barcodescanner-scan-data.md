---
author: eliotcowley
title: 取得し、バーコードのデータを理解します。
description: 取得して、スキャンしたバーコード データを解釈する方法について説明します。
ms.author: elcowle
ms.date: 08/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 0992ea54092063ba53f23871599905e58f1b456e
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4114520"
---
# <a name="obtain-and-understand-barcode-data"></a><span data-ttu-id="01d85-104">取得し、バーコードのデータを理解します。</span><span class="sxs-lookup"><span data-stu-id="01d85-104">Obtain and understand barcode data</span></span>

<span data-ttu-id="01d85-105">バーコード スキャナーを設定すると、当然のことながらしたら、データをスキャンすることを理解するための方法です。</span><span class="sxs-lookup"><span data-stu-id="01d85-105">Once you've set up your barcode scanner, you of course need a way of understanding the data that you scan.</span></span> <span data-ttu-id="01d85-106">バーコードをスキャンするときは、 [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="01d85-106">When you scan a barcode, the [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived) event is raised.</span></span> <span data-ttu-id="01d85-107">[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)は、このイベントをサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-107">The [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) should subscribe to this event.</span></span> <span data-ttu-id="01d85-108">**DataReceived**イベントは、バーコード データにアクセスするために使用できる[BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="01d85-108">The **DataReceived** event passes a [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs) object, which you can use to access the barcode data.</span></span>

## <a name="subscribe-to-the-datareceived-event"></a><span data-ttu-id="01d85-109">DataReceived イベントを購読します。</span><span class="sxs-lookup"><span data-stu-id="01d85-109">Subscribe to the DataReceived event</span></span>

<span data-ttu-id="01d85-110">した後、 **ClaimedBarcodeScanner**、 **DataReceived**イベントを購読することがあります。</span><span class="sxs-lookup"><span data-stu-id="01d85-110">Once you have a **ClaimedBarcodeScanner**, have it subscribe to the **DataReceived** event:</span></span>

```cs
claimedBarcodeScanner.DataReceived += ClaimedBarcodeScanner_DataReceived;
```

<span data-ttu-id="01d85-111">イベント ハンドラーは、 **ClaimedBarcodeScanner**と**BarcodeScannerDataReceivedEventArgs**オブジェクトに渡されます。</span><span class="sxs-lookup"><span data-stu-id="01d85-111">The event handler will be passed the **ClaimedBarcodeScanner** and a **BarcodeScannerDataReceivedEventArgs** object.</span></span> <span data-ttu-id="01d85-112">型[BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)は、このオブジェクトの[レポート](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report)プロパティで、バーコード データにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="01d85-112">You can access the barcode data through this object's [Report](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report) property, which is of type [BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport).</span></span>

```cs
private async void ClaimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    // Parse the data
}
```

## <a name="get-the-data"></a><span data-ttu-id="01d85-113">データを取得します。</span><span class="sxs-lookup"><span data-stu-id="01d85-113">Get the data</span></span>

<span data-ttu-id="01d85-114">**BarcodeScannerReport**を作成したらにアクセスし、バーコードのデータを解析できます。</span><span class="sxs-lookup"><span data-stu-id="01d85-114">Once you have the **BarcodeScannerReport**, you can access and parse the barcode data.</span></span> <span data-ttu-id="01d85-115">**BarcodeScannerReport**には、3 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="01d85-115">**BarcodeScannerReport** has three properties:</span></span>

* <span data-ttu-id="01d85-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): バーコードを完全な生データです。</span><span class="sxs-lookup"><span data-stu-id="01d85-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): The full, raw barcode data.</span></span>
* <span data-ttu-id="01d85-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): デコードされたバーコード ・ ラベルには、ヘッダー、チェックサム、およびその他の情報は含まれません。</span><span class="sxs-lookup"><span data-stu-id="01d85-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): The decoded barcode label, which does not include the header, checksum, and other miscellaneous information.</span></span>
* <span data-ttu-id="01d85-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): デコードされたバーコード ラベルの種類です。</span><span class="sxs-lookup"><span data-stu-id="01d85-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): The decoded barcode label type.</span></span> <span data-ttu-id="01d85-119">使用可能な値は、 [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)クラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="01d85-119">Possible values are defined in the [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies) class.</span></span>

<span data-ttu-id="01d85-120">**ScanDataLabel**または**ScanDataType**のいずれかにアクセスする場合は、 **true**に[IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled)を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-120">If you want to access either **ScanDataLabel** or **ScanDataType**, you must first set [IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled) to **true**.</span></span>

```cs
claimedBarcodeScanner.IsDecodeDataEnabled = true;
```

### <a name="get-the-scan-data-type"></a><span data-ttu-id="01d85-121">スキャン データの種類を取得します。</span><span class="sxs-lookup"><span data-stu-id="01d85-121">Get the scan data type</span></span>

<span data-ttu-id="01d85-122">デコードされたバーコード ラベルの種類を取得するは非常に単純な&mdash; **ScanDataType**の[GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)を呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="01d85-122">Getting the decoded barcode label type is fairly trivial&mdash;we simply call [GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname) on **ScanDataType**.</span></span>

```cs
private string GetSymbology(BarcodeScannerDataReceivedEventArgs args)
{
    return BarcodeSymbologies.GetName(args.Report.ScanDataType);
}
```

### <a name="get-the-scan-data-label"></a><span data-ttu-id="01d85-123">スキャン データのラベルを取得します。</span><span class="sxs-lookup"><span data-stu-id="01d85-123">Get the scan data label</span></span>

<span data-ttu-id="01d85-124">デコードされたバーコード ラベルを取得するには、いくつかのことに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-124">To get the decoded barcode label, there are a few things you have to be aware of.</span></span> <span data-ttu-id="01d85-125">特定のデータ型だけでは、エンコードされたテキストが含まれているかどうか、シンボルは、文字列に変換することができ、 **ScanDataLabel**から UTF-8 エンコードされた文字列を取得するバッファーを変換を最初にチェックする必要がありますので。</span><span class="sxs-lookup"><span data-stu-id="01d85-125">Only certain data types contain encoded text, so you should first check if the symbology can be converted to a string, and then convert the buffer we get from **ScanDataLabel** to an encoded UTF-8 string.</span></span>

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

### <a name="get-the-raw-scan-data"></a><span data-ttu-id="01d85-126">生のスキャン データを取得します。</span><span class="sxs-lookup"><span data-stu-id="01d85-126">Get the raw scan data</span></span>

<span data-ttu-id="01d85-127">全体を取得するには、バーコードからの生のデータだけで変換バッファーの文字列を**ScanData**から取得します。</span><span class="sxs-lookup"><span data-stu-id="01d85-127">To get the full, raw data from the barcode, we simply convert the buffer we get from **ScanData** into a string.</span></span>

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

<span data-ttu-id="01d85-128">これらのデータは、一般的に、スキャナーから送信されたときの形式でです。</span><span class="sxs-lookup"><span data-stu-id="01d85-128">These data are, in general, in the format as delivered from the scanner.</span></span> <span data-ttu-id="01d85-129">メッセージのヘッダーとトレイラの情報は、ただし、アプリケーションに役立つ情報が含まれていないされ、特定のスキャナーを使用する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-129">Message header and trailer information are removed, however, since they do not contain useful information for an application and are likely to be scanner-specific.</span></span>

<span data-ttu-id="01d85-130">共通のヘッダー情報は、(STX 文字) などの接頭辞です。</span><span class="sxs-lookup"><span data-stu-id="01d85-130">Common header information is a prefix character (such as an STX character).</span></span> <span data-ttu-id="01d85-131">一般的なトレーラーの情報は、(ETX または CR 文字) などの終端文字とブロック チェック文字場合は、スキャナーによって生成された 1 つ。</span><span class="sxs-lookup"><span data-stu-id="01d85-131">Common trailer information is a terminator character (such as an ETX or CR character) and a block check character if one is generated by the scanner.</span></span>

<span data-ttu-id="01d85-132">スキャナーによって返されるいずれかの場合、このプロパティは、記号文字を含める必要があります (など、 **A**の UPC A)。</span><span class="sxs-lookup"><span data-stu-id="01d85-132">This property should include a symbology character if one is returned by the scanner (for example, an **A** for UPC-A).</span></span> <span data-ttu-id="01d85-133">ラベルに存在する場合はチェック数字を含める必要がありますし、スキャナーによって返されます。</span><span class="sxs-lookup"><span data-stu-id="01d85-133">It should also include check digits if they are present in the label and returned by the scanner.</span></span> <span data-ttu-id="01d85-134">(注する記号の文字と数字のチェックの両方かは表示されません、スキャナーの構成によって異なります。</span><span class="sxs-lookup"><span data-stu-id="01d85-134">(Note that both symbology characters and check digits may or may not be present, depending upon the scanner configuration.</span></span> <span data-ttu-id="01d85-135">スキャナーを返す場合は説明するが生成またはこれらが存在しない場合は、それらを計算します)。</span><span class="sxs-lookup"><span data-stu-id="01d85-135">The scanner will return them if present, but will not generate or calculate them if they are absent.)</span></span>

<span data-ttu-id="01d85-136">補足のバーコードでは、いくつかの商品をマークすることがあります。</span><span class="sxs-lookup"><span data-stu-id="01d85-136">Some merchandise may be marked with a supplemental barcode.</span></span> <span data-ttu-id="01d85-137">このバーコードは、主要なバーコードの右側には通常、配置し、情報の追加または 2 つの 5 文字で構成されています。</span><span class="sxs-lookup"><span data-stu-id="01d85-137">This barcode is typically placed to the right of the main barcode, and consists of an additional two or five characters of information.</span></span> <span data-ttu-id="01d85-138">スキャナーは、商品を読み取る場合は、メインと追加の両方のバーコードが含まれている補足的な文字は、メインの文字に追加されます。、結果が 1 つのラベルとしてアプリケーションに配信されます。</span><span class="sxs-lookup"><span data-stu-id="01d85-138">If the scanner reads merchandise that contains both main and supplemental barcodes, the supplemental characters are appended to the main characters, and the result is delivered to the application as one label.</span></span> <span data-ttu-id="01d85-139">(スキャナーまたは補足的なコードの読み取りを無効にする構成をサポート可能性があることに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="01d85-139">(Note that a scanner may support a configuration that enables or disables the reading of supplemental codes.)</span></span>

<span data-ttu-id="01d85-140">*Multisymbol ラベル*または*階層型のラベル*とも呼ばれる複数のラベルでは、いくつか商品をマークすることがあります。</span><span class="sxs-lookup"><span data-stu-id="01d85-140">Some merchandise may be marked with multiple labels, sometimes called *multisymbol labels* or *tiered labels*.</span></span> <span data-ttu-id="01d85-141">バーコードの代表的な垂直方向にし、同じまたは別のコードの場合があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-141">These barcodes are typically arranged vertically, and may be of the same or different symbology.</span></span> <span data-ttu-id="01d85-142">スキャナーでは、複数のラベルを含む商品を読み取り、各バーコードは、独立したラベルとしてアプリケーションに配信されます。</span><span class="sxs-lookup"><span data-stu-id="01d85-142">If the scanner reads merchandise that contains multiple labels, each barcode is delivered to the application as a separate label.</span></span> <span data-ttu-id="01d85-143">これらのバーコードの種類の標準化の現在の不足のために必要です。</span><span class="sxs-lookup"><span data-stu-id="01d85-143">This is necessary due to the current lack of standardization of these barcode types.</span></span> <span data-ttu-id="01d85-144">個々 のバーコード データに基づくすべてのバリエーションを特定することがあります。</span><span class="sxs-lookup"><span data-stu-id="01d85-144">One is not able to determine all variations based upon the individual barcode data.</span></span> <span data-ttu-id="01d85-145">したがって、アプリケーションと、複数のラベルのバーコード読み取られた返されるデータに基づいて決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01d85-145">Therefore, the application will need to determine when a multiple label barcode has been read based upon the data returned.</span></span> <span data-ttu-id="01d85-146">(スキャナーが可能性がありますまたは複数のラベルの読み取りができない場合があることに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="01d85-146">(Note that a scanner may or may not support reading of multiple labels.)</span></span>

<span data-ttu-id="01d85-147">**DataReceived**イベントがアプリケーションに発生する前にこの値が設定されています。</span><span class="sxs-lookup"><span data-stu-id="01d85-147">This value is set prior to a **DataReceived** event being raised to the application.</span></span>

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a><span data-ttu-id="01d85-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="01d85-148">See also</span></span>
* [<span data-ttu-id="01d85-149">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="01d85-149">Barcode scanner</span></span>](pos-barcodescanner.md)
* [<span data-ttu-id="01d85-150">ClaimedBarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="01d85-150">ClaimedBarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)
* [<span data-ttu-id="01d85-151">BarcodeScannerDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="01d85-151">BarcodeScannerDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)
* [<span data-ttu-id="01d85-152">BarcodeScannerReport クラス</span><span class="sxs-lookup"><span data-stu-id="01d85-152">BarcodeScannerReport Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)
* [<span data-ttu-id="01d85-153">BarcodeSymbologies クラス</span><span class="sxs-lookup"><span data-stu-id="01d85-153">BarcodeSymbologies Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)