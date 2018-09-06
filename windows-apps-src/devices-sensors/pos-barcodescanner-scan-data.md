---
author: eliotcowley
title: 取得し、バーコード データを理解します。
description: 入手をスキャンするバーコード データを解釈する方法について説明します。
ms.author: elcowle
ms.date: 08/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 0992ea54092063ba53f23871599905e58f1b456e
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3411316"
---
# <a name="obtain-and-understand-barcode-data"></a><span data-ttu-id="66b11-104">取得し、バーコード データを理解します。</span><span class="sxs-lookup"><span data-stu-id="66b11-104">Obtain and understand barcode data</span></span>

<span data-ttu-id="66b11-105">バーコード スキャナーをセットアップした後は、もちろん方法をスキャンするデータの理解の必要があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-105">Once you've set up your barcode scanner, you of course need a way of understanding the data that you scan.</span></span> <span data-ttu-id="66b11-106">バーコードをスキャンする[DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="66b11-106">When you scan a barcode, the [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived) event is raised.</span></span> <span data-ttu-id="66b11-107">[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)は、このイベントにサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-107">The [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) should subscribe to this event.</span></span> <span data-ttu-id="66b11-108">**DataReceived**イベントは、バーコード データにアクセスするために使用できる、 [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="66b11-108">The **DataReceived** event passes a [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs) object, which you can use to access the barcode data.</span></span>

## <a name="subscribe-to-the-datareceived-event"></a><span data-ttu-id="66b11-109">DataReceived イベントにサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="66b11-109">Subscribe to the DataReceived event</span></span>

<span data-ttu-id="66b11-110">**ClaimedBarcodeScanner**したら、 **DataReceived**イベントをサブスクライブすることがあります。</span><span class="sxs-lookup"><span data-stu-id="66b11-110">Once you have a **ClaimedBarcodeScanner**, have it subscribe to the **DataReceived** event:</span></span>

```cs
claimedBarcodeScanner.DataReceived += ClaimedBarcodeScanner_DataReceived;
```

<span data-ttu-id="66b11-111">イベント ハンドラーは、 **ClaimedBarcodeScanner**と**BarcodeScannerDataReceivedEventArgs**オブジェクトが渡されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-111">The event handler will be passed the **ClaimedBarcodeScanner** and a **BarcodeScannerDataReceivedEventArgs** object.</span></span> <span data-ttu-id="66b11-112">このオブジェクトの[レポート](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report)プロパティの型は[BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)でバーコード データにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="66b11-112">You can access the barcode data through this object's [Report](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report) property, which is of type [BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport).</span></span>

```cs
private async void ClaimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    // Parse the data
}
```

## <a name="get-the-data"></a><span data-ttu-id="66b11-113">データを取得します。</span><span class="sxs-lookup"><span data-stu-id="66b11-113">Get the data</span></span>

<span data-ttu-id="66b11-114">**BarcodeScannerReport**したらにアクセスし、バーコード データを解析できます。</span><span class="sxs-lookup"><span data-stu-id="66b11-114">Once you have the **BarcodeScannerReport**, you can access and parse the barcode data.</span></span> <span data-ttu-id="66b11-115">**BarcodeScannerReport**では、3 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="66b11-115">**BarcodeScannerReport** has three properties:</span></span>

* <span data-ttu-id="66b11-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): 完全な生のバーコード データ。</span><span class="sxs-lookup"><span data-stu-id="66b11-116">[ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): The full, raw barcode data.</span></span>
* <span data-ttu-id="66b11-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): バーコードがデコードのラベル、ヘッダー、チェックサム、およびその他の情報は含まれません。</span><span class="sxs-lookup"><span data-stu-id="66b11-117">[ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): The decoded barcode label, which does not include the header, checksum, and other miscellaneous information.</span></span>
* <span data-ttu-id="66b11-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): バーコードがデコードされたラベルの種類。</span><span class="sxs-lookup"><span data-stu-id="66b11-118">[ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): The decoded barcode label type.</span></span> <span data-ttu-id="66b11-119">設定可能な値は、 [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)クラスで定義されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-119">Possible values are defined in the [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies) class.</span></span>

<span data-ttu-id="66b11-120">**ScanDataLabel**または**ScanDataType**のいずれかにアクセスする場合は、 **true**を[IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled)を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-120">If you want to access either **ScanDataLabel** or **ScanDataType**, you must first set [IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled) to **true**.</span></span>

```cs
claimedBarcodeScanner.IsDecodeDataEnabled = true;
```

### <a name="get-the-scan-data-type"></a><span data-ttu-id="66b11-121">スキャン データの種類を取得します。</span><span class="sxs-lookup"><span data-stu-id="66b11-121">Get the scan data type</span></span>

<span data-ttu-id="66b11-122">バーコードがデコードされたラベルの種類を取得するは非常に単純な&mdash; **ScanDataType**で[GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)を呼び出すことだけです。</span><span class="sxs-lookup"><span data-stu-id="66b11-122">Getting the decoded barcode label type is fairly trivial&mdash;we simply call [GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname) on **ScanDataType**.</span></span>

```cs
private string GetSymbology(BarcodeScannerDataReceivedEventArgs args)
{
    return BarcodeSymbologies.GetName(args.Report.ScanDataType);
}
```

### <a name="get-the-scan-data-label"></a><span data-ttu-id="66b11-123">スキャン データのラベルを取得します。</span><span class="sxs-lookup"><span data-stu-id="66b11-123">Get the scan data label</span></span>

<span data-ttu-id="66b11-124">デコードされたバーコード ラベルを取得するのには、注意すべきがあるいくつかの点があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-124">To get the decoded barcode label, there are a few things you have to be aware of.</span></span> <span data-ttu-id="66b11-125">特定のデータ型のみ含めるエンコードされたテキスト、できないため、まずかどうか、シンボル体系は、文字列に変換でき、utf-8 エンコードされた文字列を**ScanDataLabel**から入手して、バッファーを変換をチェックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-125">Only certain data types contain encoded text, so you should first check if the symbology can be converted to a string, and then convert the buffer we get from **ScanDataLabel** to an encoded UTF-8 string.</span></span>

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

### <a name="get-the-raw-scan-data"></a><span data-ttu-id="66b11-126">スキャンの生データを取得します。</span><span class="sxs-lookup"><span data-stu-id="66b11-126">Get the raw scan data</span></span>

<span data-ttu-id="66b11-127">"完全"を取得するのに、バーコードからの生データしますだけ変換、バッファーの文字列に**ScanData**から取得します。</span><span class="sxs-lookup"><span data-stu-id="66b11-127">To get the full, raw data from the barcode, we simply convert the buffer we get from **ScanData** into a string.</span></span>

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

<span data-ttu-id="66b11-128">これらのデータには、一般に、ように、スキャナーから配信される形式です。</span><span class="sxs-lookup"><span data-stu-id="66b11-128">These data are, in general, in the format as delivered from the scanner.</span></span> <span data-ttu-id="66b11-129">メッセージのヘッダーとトレーラーは削除されます。 ただし、ため、アプリケーションに関する有用な情報が含まれていませんがスキャナーに固有のする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-129">Message header and trailer information are removed, however, since they do not contain useful information for an application and are likely to be scanner-specific.</span></span>

<span data-ttu-id="66b11-130">一般的なヘッダー情報は、プレフィックス文字 (STX 文字の場合) などです。</span><span class="sxs-lookup"><span data-stu-id="66b11-130">Common header information is a prefix character (such as an STX character).</span></span> <span data-ttu-id="66b11-131">一般的なトレーラー情報は、(ETX または変更リクエスト文字では) などの終端文字とブロック チェック文字場合は 1 つは、スキャナーによって生成されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-131">Common trailer information is a terminator character (such as an ETX or CR character) and a block check character if one is generated by the scanner.</span></span>

<span data-ttu-id="66b11-132">いずれかがスキャナーで返された場合、このプロパティはシンボル体系の文字を含める必要があります (の**A**など、UPC A)。</span><span class="sxs-lookup"><span data-stu-id="66b11-132">This property should include a symbology character if one is returned by the scanner (for example, an **A** for UPC-A).</span></span> <span data-ttu-id="66b11-133">ラベルに存在する場合も、チェック桁の数字を含める必要があります、スキャナーで返されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-133">It should also include check digits if they are present in the label and returned by the scanner.</span></span> <span data-ttu-id="66b11-134">(するシンボル体系文字とチェック ディジットの両方かできない可能性がある、スキャナーの構成によってに注意してください。</span><span class="sxs-lookup"><span data-stu-id="66b11-134">(Note that both symbology characters and check digits may or may not be present, depending upon the scanner configuration.</span></span> <span data-ttu-id="66b11-135">スキャナーが戻す場合は、表示しますが、生成またはされませんこれらが存在しない場合は、それらを計算します)。</span><span class="sxs-lookup"><span data-stu-id="66b11-135">The scanner will return them if present, but will not generate or calculate them if they are absent.)</span></span>

<span data-ttu-id="66b11-136">補足的なバーコードでは、いくつかの商品をマークする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-136">Some merchandise may be marked with a supplemental barcode.</span></span> <span data-ttu-id="66b11-137">このバーコードは通常、メインのバーコードの右側に配置され、情報の追加 2 または 5 文字で構成されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-137">This barcode is typically placed to the right of the main barcode, and consists of an additional two or five characters of information.</span></span> <span data-ttu-id="66b11-138">含むメインと補助の両方のバーコード スキャナーは、商品を読み取る場合、補足的な文字がメインの文字に付加され、結果は、アプリケーションを 1 つのラベルとに配信されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-138">If the scanner reads merchandise that contains both main and supplemental barcodes, the supplemental characters are appended to the main characters, and the result is delivered to the application as one label.</span></span> <span data-ttu-id="66b11-139">(メモ、スキャナーがまたは補足的なコードの読み取りを無効にする構成をサポート可能性があります。)</span><span class="sxs-lookup"><span data-stu-id="66b11-139">(Note that a scanner may support a configuration that enables or disables the reading of supplemental codes.)</span></span>

<span data-ttu-id="66b11-140">一部の商品は、 *multisymbol ラベル*または*階層型のラベル*とも呼ばれる、複数のラベルでマークする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-140">Some merchandise may be marked with multiple labels, sometimes called *multisymbol labels* or *tiered labels*.</span></span> <span data-ttu-id="66b11-141">これらのバーコードは、垂直方向に配置されて通常して、同じまたは別のシンボル体系の可能性があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-141">These barcodes are typically arranged vertically, and may be of the same or different symbology.</span></span> <span data-ttu-id="66b11-142">スキャナーは、複数のラベルが含まれている商品を読み取り、各バーコードは、アプリケーションを別のラベルとに配信されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-142">If the scanner reads merchandise that contains multiple labels, each barcode is delivered to the application as a separate label.</span></span> <span data-ttu-id="66b11-143">現在、これらのバーコードの種類の標準化不足のために必要です。</span><span class="sxs-lookup"><span data-stu-id="66b11-143">This is necessary due to the current lack of standardization of these barcode types.</span></span> <span data-ttu-id="66b11-144">個々 のバーコード データに基づいてすべてのバリエーションを特定することがあります。</span><span class="sxs-lookup"><span data-stu-id="66b11-144">One is not able to determine all variations based upon the individual barcode data.</span></span> <span data-ttu-id="66b11-145">アプリケーションでは、複数のラベル バーコードがされて読み取り時から返されるデータに基づいて判断する必要があります。</span><span class="sxs-lookup"><span data-stu-id="66b11-145">Therefore, the application will need to determine when a multiple label barcode has been read based upon the data returned.</span></span> <span data-ttu-id="66b11-146">(詳しくは、スキャナーが場合も、複数のラベルの読み取り値をサポートしていませんを注意してください)。</span><span class="sxs-lookup"><span data-stu-id="66b11-146">(Note that a scanner may or may not support reading of multiple labels.)</span></span>

<span data-ttu-id="66b11-147">この値は、アプリケーションに発生する**DataReceived**イベントの前に設定されます。</span><span class="sxs-lookup"><span data-stu-id="66b11-147">This value is set prior to a **DataReceived** event being raised to the application.</span></span>

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a><span data-ttu-id="66b11-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="66b11-148">See also</span></span>
* [<span data-ttu-id="66b11-149">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="66b11-149">Barcode scanner</span></span>](pos-barcodescanner.md)
* [<span data-ttu-id="66b11-150">ClaimedBarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="66b11-150">ClaimedBarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)
* [<span data-ttu-id="66b11-151">BarcodeScannerDataReceivedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="66b11-151">BarcodeScannerDataReceivedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)
* [<span data-ttu-id="66b11-152">BarcodeScannerReport クラス</span><span class="sxs-lookup"><span data-stu-id="66b11-152">BarcodeScannerReport Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)
* [<span data-ttu-id="66b11-153">BarcodeSymbologies クラス</span><span class="sxs-lookup"><span data-stu-id="66b11-153">BarcodeSymbologies Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)