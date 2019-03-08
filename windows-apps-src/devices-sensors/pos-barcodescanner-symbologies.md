---
title: バーコード スキャナーのシンボル体系の使用
description: この記事には、バーコード スキャナーのシンボル体系に関する情報が含まれています。
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 690b6b8ee688f62dcae375ed48e07797c921bf43
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637597"
---
# <a name="working-with-symbologies"></a><span data-ttu-id="ca298-104">シンボル体系の操作</span><span class="sxs-lookup"><span data-stu-id="ca298-104">Working with symbologies</span></span>
<span data-ttu-id="ca298-105">[バーコード シンボル体系](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。</span><span class="sxs-lookup"><span data-stu-id="ca298-105">A [barcode symbology](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies) is the mapping of data to a specific barcode format.</span></span> <span data-ttu-id="ca298-106">UPC、コード 128、QR コード、およびなど、いくつかの一般的な記号が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ca298-106">Some common symbologies include UPC, Code 128, QR Code, and so on.</span></span>  <span data-ttu-id="ca298-107">スキャナーがスキャナーを手動で構成しなくても、これらの記号をどのように処理する方法を制御するユニバーサル Windows プラットフォームのバーコード スキャナーの Api を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ca298-107">The Universal Windows Platform barcode scanner APIs allow an application to control how the scanner processes these symbologies without manually configuring the scanner.</span></span> 

## <a name="determine-which-symbologies-are-supported"></a><span data-ttu-id="ca298-108">サポートされているシンボル体系を判断する</span><span class="sxs-lookup"><span data-stu-id="ca298-108">Determine which symbologies are supported</span></span> 
<span data-ttu-id="ca298-109">複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。</span><span class="sxs-lookup"><span data-stu-id="ca298-109">Since your application may be used with different barcode scanner models from multiple manufacturers, you may want to query the scanner to determine the list of symbologies that it supports.</span></span>  <span data-ttu-id="ca298-110">これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ca298-110">This can be useful if your application requires a specific symbology that may not be supported by all scanners or you need to enable symbologies that have been either manually or programmatically disabled on the scanner.</span></span>

<span data-ttu-id="ca298-111">[BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得した後で、[GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。</span><span class="sxs-lookup"><span data-stu-id="ca298-111">Once you have a [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) object by using [BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync), call [GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) to obtain a list of symbologies supported by the device.</span></span>

<span data-ttu-id="ca298-112">次の例では、バーコード スキャナーなどのサポートされている記号の一覧を取得し、テキスト ブロックに表示されます。</span><span class="sxs-lookup"><span data-stu-id="ca298-112">The following example gets a list of the supported symbologies of the barcode scanner, and displays them in a text block:</span></span>

```cs
private void DisplaySupportedSymbologies(BarcodeScanner barcodeScanner, TextBlock textBlock) 
{
    var supportedSymbologies = await barcodeScanner.GetSupportedSymbologiesAsync();

    foreach (uint item in supportedSymbologies)
    {
        string symbology = BarcodeSymbologies.GetName(item);
        textBlock.Text += (symbology + "\n");
    }
}
```

## <a name="determine-if-a-specific-symbology-is-supported"></a><span data-ttu-id="ca298-113">特定のシンボル体系がサポートされているかどうかを判断する</span><span class="sxs-lookup"><span data-stu-id="ca298-113">Determine if a specific symbology is supported</span></span>
<span data-ttu-id="ca298-114">スキャナーが呼び出すことができます、特定のシンボルをサポートしているかを判断する[IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-114">To determine if the scanner supports a specific symbology you can call [IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_).</span></span>

<span data-ttu-id="ca298-115">次の例は、バーコード スキャナ サポートしているかをチェック、 **Code32**シンボル。</span><span class="sxs-lookup"><span data-stu-id="ca298-115">The following example checks if the barcode scanner supports the **Code32** symbology:</span></span>

```cs
bool symbologySupported = await barcodeScanner.IsSymbologySupportedAsync(BarcodeSymbologies.Code32);
```

## <a name="change-which-symbologies-are-recognized"></a><span data-ttu-id="ca298-116">変更するバーコードを認識</span><span class="sxs-lookup"><span data-stu-id="ca298-116">Change which symbologies are recognized</span></span>
<span data-ttu-id="ca298-117">場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="ca298-117">In some cases, you may want to use a subset of symbologies that the barcode scanner supports.</span></span>  <span data-ttu-id="ca298-118">これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="ca298-118">This is particularly useful to block symbologies that you do not intend to use in your application.</span></span> <span data-ttu-id="ca298-119">たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。</span><span class="sxs-lookup"><span data-stu-id="ca298-119">For example, to ensure a user scans the right barcode, you could constrain scanning to UPC or EAN when acquiring item SKUs and constrain scanning to Code 128 when acquiring serial numbers.</span></span>

<span data-ttu-id="ca298-120">スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。</span><span class="sxs-lookup"><span data-stu-id="ca298-120">Once you know the symbologies that your scanner supports, you can set the symbologies that you want it to recognize.</span></span>  <span data-ttu-id="ca298-121">これを確立した後、 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)オブジェクトを使用して[ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-121">This can be done after you have established a [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) object using [ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync).</span></span> <span data-ttu-id="ca298-122">[SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。</span><span class="sxs-lookup"><span data-stu-id="ca298-122">You can call [SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) to enable a specific set of symbologies while those omitted from your list are disabled.</span></span>

<span data-ttu-id="ca298-123">次の例では、設定を要求したバーコード スキャナーのアクティブなバーコード[Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39)と[Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex):</span><span class="sxs-lookup"><span data-stu-id="ca298-123">The following example sets the active symbologies of a claimed barcode scanner to [Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39) and [Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex):</span></span>

```cs
private async void SetSymbologies(ClaimedBarcodeScanner claimedBarcodeScanner) 
{
    var symbologies = new List<uint>{ BarcodeSymbologies.Code39, BarcodeSymbologies.Code39Ex };
    await claimedBarcodeScanner.SetActiveSymbologiesAsync(symbologies);
}
```

## <a name="barcode-symbology-attributes"></a><span data-ttu-id="ca298-124">バーコード シンボル属性</span><span class="sxs-lookup"><span data-stu-id="ca298-124">Barcode symbology attributes</span></span>
<span data-ttu-id="ca298-125">別のバーコード バーコード サポートの複数の長さ、生のデータの一部としてホストにチェック ディジットの送信のデコード桁の検証の確認など、さまざまな属性は、ことができます。</span><span class="sxs-lookup"><span data-stu-id="ca298-125">Different barcode symbologies can have different attributes, such as supporting multiple decode lengths, transmitting the check digit to the host as part of the raw data, and check digit validation.</span></span> <span data-ttu-id="ca298-126">[BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)クラスを取得および設定できるこれらの属性を指定された[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)とバーコード シンボル。</span><span class="sxs-lookup"><span data-stu-id="ca298-126">With the [BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes) class, you can get and set these attributes for a given [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) and barcode symbology.</span></span>

<span data-ttu-id="ca298-127">指定されたコードの属性を取得する[GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-127">You can get the attributes of a given symbology with [GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_).</span></span> <span data-ttu-id="ca298-128">次のコード スニペットの Upca コードの属性を取得する、 **ClaimedBarcodeScanner**します。</span><span class="sxs-lookup"><span data-stu-id="ca298-128">The following code snippet gets the attributes of the Upca symbology for a **ClaimedBarcodeScanner**.</span></span>

```cs
BarcodeSymbologyAttributes barcodeSymbologyAttributes = 
    await claimedBarcodeScanner.GetSymbologyAttributesAsync(BarcodeSymbologies.Upca);
```

<span data-ttu-id="ca298-129">属性およびそれらを設定できるように変更が完了したら、呼び出す[SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-129">When you've finished modifying the attributes and are ready to set them, you can call [SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync).</span></span> <span data-ttu-id="ca298-130">このメソッドが戻る、 **bool**、これは**true**属性が正常に設定されている場合。</span><span class="sxs-lookup"><span data-stu-id="ca298-130">This method returns a **bool**, which is **true** if the attributes were successfully set.</span></span>

```cs
bool success = await claimedBarcodeScanner.SetSymbologyAttributesAsync(
    BarcodeSymbologies.Upca, barcodeSymbologyAttributes);
```

### <a name="restrict-scan-data-by-data-length"></a><span data-ttu-id="ca298-131">スキャン データのデータの長さを制限します。</span><span class="sxs-lookup"><span data-stu-id="ca298-131">Restrict scan data by data length</span></span>
<span data-ttu-id="ca298-132">一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。</span><span class="sxs-lookup"><span data-stu-id="ca298-132">Some symbologies are variable length such as Code 39 or Code 128.</span></span>  <span data-ttu-id="ca298-133">これらの記号のバーコードは、特定の長さの多くの場合、別のデータを含む、互いに近くに配置できます。</span><span class="sxs-lookup"><span data-stu-id="ca298-133">Barcodes of these symbologies can be located near each other containing different data often of specific length.</span></span> <span data-ttu-id="ca298-134">必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。</span><span class="sxs-lookup"><span data-stu-id="ca298-134">Setting the specific length of the data you require can prevent invalid scans.</span></span>

<span data-ttu-id="ca298-135">デコードの長さを設定する前に、バーコード シンボルが複数期間をサポートしているかどうかを確認[IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-135">Before setting the decode length, check whether the barcode symbology supports multiple lengths with [IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported).</span></span> <span data-ttu-id="ca298-136">設定することはサポートされていることがわかったら、 [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind)、型の[BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-136">Once you know that it's supported, you can set the [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind), which is of type [BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind).</span></span> <span data-ttu-id="ca298-137">このプロパティは、次の値のいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ca298-137">This property can be any of the following values:</span></span>

* <span data-ttu-id="ca298-138">**AnyLength**:任意の数の長さをデコードします。</span><span class="sxs-lookup"><span data-stu-id="ca298-138">**AnyLength**: Decode lengths of any number.</span></span>
* <span data-ttu-id="ca298-139">**不連続**:いずれかの長さをデコード[DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1)または[DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2) 1 バイト文字。</span><span class="sxs-lookup"><span data-stu-id="ca298-139">**Discrete**: Decode lengths of either [DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1) or [DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2) single-byte characters.</span></span>
* <span data-ttu-id="ca298-140">**範囲**:長さをデコード**DecodeLength1**と**DecodeLength2** 1 バイト文字。</span><span class="sxs-lookup"><span data-stu-id="ca298-140">**Range**: Decode lengths between **DecodeLength1** and **DecodeLength2** single-byte characters.</span></span> <span data-ttu-id="ca298-141">順序**DecodeLength1**と**DecodeLength2** (いずれかのできる他のより高いまたは低い) でも操作を行います。</span><span class="sxs-lookup"><span data-stu-id="ca298-141">The order of **DecodeLength1** and **DecodeLength2** do not matter (either can be higher or lower than the other).</span></span>

<span data-ttu-id="ca298-142">値を設定する最後に、 **DecodeLength1**と**DecodeLength2**が必要なデータの長さを制御します。</span><span class="sxs-lookup"><span data-stu-id="ca298-142">Finally, you can set the values of **DecodeLength1** and **DecodeLength2** to control the length of the data you require.</span></span>

<span data-ttu-id="ca298-143">デコードの長さを設定する次のコード スニペットに示します。</span><span class="sxs-lookup"><span data-stu-id="ca298-143">The following code snippet demonstrates setting the decode length:</span></span>

```cs
private async Task<bool> SetDecodeLength(
    ClaimedBarcodeScanner scanner,
    uint symbology, 
    BarcodeSymbologyDecodeLengthKind kind, 
    uint decodeLength1, 
    uint decodeLength2)
{
    bool success = false;
    BarcodeSymbologyAttributes attributes = await scanner.GetSymbologyAttributesAsync(symbology);

    if (attributes.IsDecodeLengthSupported)
    {
        attributes.DecodeLengthKind = kind;
        attributes.DecodeLength1 = decodeLength1;
        attributes.DecodeLength2 = decodeLength2;
        success = await scanner.SetSymbologyAttributesAsync(symbology, attributes);
    }

    return success;
}
```

### <a name="check-digit-transmission"></a><span data-ttu-id="ca298-144">数字の転送を確認してください。</span><span class="sxs-lookup"><span data-stu-id="ca298-144">Check digit transmission</span></span>

<span data-ttu-id="ca298-145">別の属性をコードに設定することができますが、かどうかチェック ディジットが送信されるホストに生データの一部として。</span><span class="sxs-lookup"><span data-stu-id="ca298-145">Another attribute you can set on a symbology is whether the check digit will be transmitted to the host as part of the raw data.</span></span> <span data-ttu-id="ca298-146">を設定する前に、コードがチェックをサポートすることを確認します桁伝送[IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-146">Before setting this, make sure that the symbology supports check digit transmission with [IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported).</span></span> <span data-ttu-id="ca298-147">チェックの数字の転送が有効になっているかどうかを設定し、 [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-147">Then, set whether check digit transmission is enabled with [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled).</span></span>

<span data-ttu-id="ca298-148">次のコード スニペットでは、チェック桁転送の設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="ca298-148">The following code snippet demonstrates setting check digit transmission:</span></span>

```cs
private async Task<bool> SetCheckDigitTransmission(ClaimedBarcodeScanner scanner, uint symbology, bool isEnabled)
{
    bool success = false;
    BarcodeSymbologyAttributes attributes = await scanner.GetSymbologyAttributesAsync(symbology);

    if (attributes.IsCheckDigitTransmissionSupported)
    {
        attributes.IsCheckDigitTransmissionEnabled = isEnabled;
        success = await scanner.SetSymbologyAttributesAsync(symbology, attributes);
    }

    return success;
}
```

### <a name="check-digit-validation"></a><span data-ttu-id="ca298-149">桁の検証を確認してください。</span><span class="sxs-lookup"><span data-stu-id="ca298-149">Check digit validation</span></span>

<span data-ttu-id="ca298-150">バーコード チェック ディジットが検証されるかどうかを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="ca298-150">You can also set whether the barcode check digit will be validated.</span></span> <span data-ttu-id="ca298-151">を設定する前に、コードがチェックをサポートすることを確認します桁の数字を使用して検証[IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-151">Before setting this, make sure that the symbology supports check digit validation with [IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported).</span></span> <span data-ttu-id="ca298-152">チェックの桁の検証が有効になっているかどうかを設定し、 [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled)します。</span><span class="sxs-lookup"><span data-stu-id="ca298-152">Then, set whether check digit validation is enabled with [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled).</span></span>

<span data-ttu-id="ca298-153">次のコード スニペットでは、チェックの桁の検証の設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="ca298-153">The following code snippet demonstrates setting check digit validation:</span></span>

```cs
private async Task<bool> SetCheckDigitValidation(ClaimedBarcodeScanner scanner, uint symbology, bool isEnabled)
{
    bool success = false;
    BarcodeSymbologyAttributes attributes = await scanner.GetSymbologyAttributesAsync(symbology);

    if (attributes.IsCheckDigitValidationSupported)
    {
        attributes.IsCheckDigitValidationEnabled = isEnabled;
        success = await scanner.SetSymbologyAttributesAsync(symbology, attributes);
    }

    return success;
}
```

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a><span data-ttu-id="ca298-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="ca298-154">See also</span></span>

* [<span data-ttu-id="ca298-155">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="ca298-155">Barcode scanner</span></span>](pos-barcodescanner.md)
* [<span data-ttu-id="ca298-156">BarcodeSymbologies クラス</span><span class="sxs-lookup"><span data-stu-id="ca298-156">BarcodeSymbologies Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)
* [<span data-ttu-id="ca298-157">BarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="ca298-157">BarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [<span data-ttu-id="ca298-158">ClaimedBarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="ca298-158">ClaimedBarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)
* [<span data-ttu-id="ca298-159">BarcodeSymbologyAttributes クラス</span><span class="sxs-lookup"><span data-stu-id="ca298-159">BarcodeSymbologyAttributes Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)
* [<span data-ttu-id="ca298-160">BarcodeSymbologyDecodeLengthKind 列挙型</span><span class="sxs-lookup"><span data-stu-id="ca298-160">BarcodeSymbologyDecodeLengthKind Enum</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)