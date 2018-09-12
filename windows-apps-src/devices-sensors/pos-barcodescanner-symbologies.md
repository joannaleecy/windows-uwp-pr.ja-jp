---
author: TerryWarwick
title: バーコード スキャナーのシンボル体系の使用
description: この記事には、バーコード スキャナーのシンボル体系に関する情報が含まれています。
ms.author: jken
ms.date: 08/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 8bd1dffe4da7b3725ef7716fe9cf28bdf8eaf34f
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3936529"
---
# <a name="working-with-symbologies"></a><span data-ttu-id="b09ca-104">シンボル体系の操作</span><span class="sxs-lookup"><span data-stu-id="b09ca-104">Working with symbologies</span></span>
<span data-ttu-id="b09ca-105">[バーコード シンボル体系](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。</span><span class="sxs-lookup"><span data-stu-id="b09ca-105">A [barcode symbology](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies) is the mapping of data to a specific barcode format.</span></span> <span data-ttu-id="b09ca-106">一般的なシンボル体系には、UPC、Code 128、QR コード、およびなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-106">Some common symbologies include UPC, Code 128, QR Code, and so on.</span></span>  <span data-ttu-id="b09ca-107">ユニバーサル Windows プラットフォームのバーコード スキャナー Api は、スキャナーを手動で構成しなくても、スキャナーがこれらのシンボル体系を処理する方法を制御するアプリケーションを許可します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-107">The Universal Windows Platform barcode scanner APIs allow an application to control how the scanner processes these symbologies without manually configuring the scanner.</span></span> 

## <a name="determine-which-symbologies-are-supported"></a><span data-ttu-id="b09ca-108">サポートされているシンボル体系を判断する</span><span class="sxs-lookup"><span data-stu-id="b09ca-108">Determine which symbologies are supported</span></span> 
<span data-ttu-id="b09ca-109">複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-109">Since your application may be used with different barcode scanner models from multiple manufacturers, you may want to query the scanner to determine the list of symbologies that it supports.</span></span>  <span data-ttu-id="b09ca-110">これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="b09ca-110">This can be useful if your application requires a specific symbology that may not be supported by all scanners or you need to enable symbologies that have been either manually or programmatically disabled on the scanner.</span></span>

<span data-ttu-id="b09ca-111">[BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得した後で、[GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-111">Once you have a [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) object by using [BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync), call [GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) to obtain a list of symbologies supported by the device.</span></span>

<span data-ttu-id="b09ca-112">次の例は、バーコード スキャナーのサポートされているシンボル体系のリストを取得し、テキスト ブロックに表示されます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-112">The following example gets a list of the supported symbologies of the barcode scanner, and displays them in a text block:</span></span>

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

## <a name="determine-if-a-specific-symbology-is-supported"></a><span data-ttu-id="b09ca-113">特定のシンボル体系がサポートされているかどうかを判断する</span><span class="sxs-lookup"><span data-stu-id="b09ca-113">Determine if a specific symbology is supported</span></span>
<span data-ttu-id="b09ca-114">スキャナーが特定のシンボル体系をサポートしているかを判断するには、 [IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-114">To determine if the scanner supports a specific symbology you can call [IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_).</span></span>

<span data-ttu-id="b09ca-115">次の例では、バーコード スキャナーが**Code32**シンボル体系をサポートしているかを確認します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-115">The following example checks if the barcode scanner supports the **Code32** symbology:</span></span>

```cs
bool symbologySupported = await barcodeScanner.IsSymbologySupportedAsync(BarcodeSymbologies.Code32);
```

## <a name="change-which-symbologies-are-recognized"></a><span data-ttu-id="b09ca-116">認識はシンボル体系を変更します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-116">Change which symbologies are recognized</span></span>
<span data-ttu-id="b09ca-117">場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-117">In some cases, you may want to use a subset of symbologies that the barcode scanner supports.</span></span>  <span data-ttu-id="b09ca-118">これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="b09ca-118">This is particularly useful to block symbologies that you do not intend to use in your application.</span></span> <span data-ttu-id="b09ca-119">たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-119">For example, to ensure a user scans the right barcode, you could constrain scanning to UPC or EAN when acquiring item SKUs and constrain scanning to Code 128 when acquiring serial numbers.</span></span>

<span data-ttu-id="b09ca-120">スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-120">Once you know the symbologies that your scanner supports, you can set the symbologies that you want it to recognize.</span></span>  <span data-ttu-id="b09ca-121">これは、 [ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync)を使用して、 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)オブジェクトを確立した後に実行できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-121">This can be done after you have established a [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) object using [ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync).</span></span> <span data-ttu-id="b09ca-122">[SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。</span><span class="sxs-lookup"><span data-stu-id="b09ca-122">You can call [SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) to enable a specific set of symbologies while those omitted from your list are disabled.</span></span>

<span data-ttu-id="b09ca-123">次の例では、 [Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39)と[Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex)にアクティブな要求のバーコード スキャナーのシンボル体系を設定します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-123">The following example sets the active symbologies of a claimed barcode scanner to [Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39) and [Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex):</span></span>

```cs
private async void SetSymbologies(ClaimedBarcodeScanner claimedBarcodeScanner) 
{
    var symbologies = new List<uint>{ BarcodeSymbologies.Code39, BarcodeSymbologies.Code39Ex };
    await claimedBarcodeScanner.SetActiveSymbologiesAsync(symbologies);
}
```

## <a name="barcode-symbology-attributes"></a><span data-ttu-id="b09ca-124">バーコード シンボル体系の属性</span><span class="sxs-lookup"><span data-stu-id="b09ca-124">Barcode symbology attributes</span></span>
<span data-ttu-id="b09ca-125">さまざまなバーコード シンボル体系には、サポートの複数の長さ、生のデータの一部として、ホストにチェック ディジットの送信をデコードしてチェック ディジットの検証にさまざまな属性は、ことができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-125">Different barcode symbologies can have different attributes, such as supporting multiple decode lengths, transmitting the check digit to the host as part of the raw data, and check digit validation.</span></span> <span data-ttu-id="b09ca-126">[BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)クラスを取得でき、これらの特定の[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)とバーコード シンボル体系の属性を設定できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-126">With the [BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes) class, you can get and set these attributes for a given [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner) and barcode symbology.</span></span>

<span data-ttu-id="b09ca-127">[GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_)で特定のシンボル体系の属性を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-127">You can get the attributes of a given symbology with [GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_).</span></span> <span data-ttu-id="b09ca-128">次のコード スニペットは、 **ClaimedBarcodeScanner**の Upca シンボル体系の属性を取得します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-128">The following code snippet gets the attributes of the Upca symbology for a **ClaimedBarcodeScanner**.</span></span>

```cs
BarcodeSymbologyAttributes barcodeSymbologyAttributes = 
    await claimedBarcodeScanner.GetSymbologyAttributesAsync(BarcodeSymbologies.Upca);
```

<span data-ttu-id="b09ca-129">属性の変更が完了したら、それらを設定する準備がすると、 [SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-129">When you've finished modifying the attributes and are ready to set them, you can call [SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync).</span></span> <span data-ttu-id="b09ca-130">以下のメソッドでは、属性が正常に設定されている場合は**true** **ブール値**を返します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-130">This method returns a **bool**, which is **true** if the attributes were successfully set.</span></span>

```cs
bool success = await claimedBarcodeScanner.SetSymbologyAttributesAsync(
    BarcodeSymbologies.Upca, barcodeSymbologyAttributes);
```

### <a name="restrict-scan-data-by-data-length"></a><span data-ttu-id="b09ca-131">データ データ長によるスキャンを制限します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-131">Restrict scan data by data length</span></span>
<span data-ttu-id="b09ca-132">一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。</span><span class="sxs-lookup"><span data-stu-id="b09ca-132">Some symbologies are variable length such as Code 39 or Code 128.</span></span>  <span data-ttu-id="b09ca-133">これらのシンボル体系のバーコードを配置して、特定の長さの多くの場合、さまざまなデータを含む、互いに近いことができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-133">Barcodes of these symbologies can be located near each other containing different data often of specific length.</span></span> <span data-ttu-id="b09ca-134">必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-134">Setting the specific length of the data you require can prevent invalid scans.</span></span>

<span data-ttu-id="b09ca-135">デコードの長さを設定するには、前に、バーコード シンボル体系が[IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)で複数の長さをサポートしているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-135">Before setting the decode length, check whether the barcode symbology supports multiple lengths with [IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported).</span></span> <span data-ttu-id="b09ca-136">サポートされているわかったら、 [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind)、タイプ[BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)を設定できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-136">Once you know that it's supported, you can set the [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind), which is of type [BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind).</span></span> <span data-ttu-id="b09ca-137">このプロパティは、次の値のいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-137">This property can be any of the following values:</span></span>

* <span data-ttu-id="b09ca-138">**AnyLength**: 任意の数の長さをデコードします。</span><span class="sxs-lookup"><span data-stu-id="b09ca-138">**AnyLength**: Decode lengths of any number.</span></span>
* <span data-ttu-id="b09ca-139">**ディスクリート**: [DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1)または[DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2)のいずれかの 1 バイト文字の長さをデコードします。</span><span class="sxs-lookup"><span data-stu-id="b09ca-139">**Discrete**: Decode lengths of either [DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1) or [DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2) single-byte characters.</span></span>
* <span data-ttu-id="b09ca-140">**範囲**: **DecodeLength1**と**DecodeLength2** 1 バイト文字間の長さをデコードします。</span><span class="sxs-lookup"><span data-stu-id="b09ca-140">**Range**: Decode lengths between **DecodeLength1** and **DecodeLength2** single-byte characters.</span></span> <span data-ttu-id="b09ca-141">**DecodeLength1**および**DecodeLength2**では、(いずれかでは、その他のより大きいまたは小さい) でもの順序です。</span><span class="sxs-lookup"><span data-stu-id="b09ca-141">The order of **DecodeLength1** and **DecodeLength2** do not matter (either can be higher or lower than the other).</span></span>

<span data-ttu-id="b09ca-142">最後に、必要なデータの長さを制御するには、 **DecodeLength1**と**DecodeLength2**の値を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-142">Finally, you can set the values of **DecodeLength1** and **DecodeLength2** to control the length of the data you require.</span></span>

<span data-ttu-id="b09ca-143">次のコード スニペットは、デコードの長さを設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="b09ca-143">The following code snippet demonstrates setting the decode length:</span></span>

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

### <a name="check-digit-transmission"></a><span data-ttu-id="b09ca-144">チェック ディジットの転送</span><span class="sxs-lookup"><span data-stu-id="b09ca-144">Check digit transmission</span></span>

<span data-ttu-id="b09ca-145">別の属性が特定のシンボル体系に設定することができますが、かどうかチェック ディジットに送信されます、ホストの生データの一部として。</span><span class="sxs-lookup"><span data-stu-id="b09ca-145">Another attribute you can set on a symbology is whether the check digit will be transmitted to the host as part of the raw data.</span></span> <span data-ttu-id="b09ca-146">これを設定する前に、シンボル体系がチェックをサポートしていることを確認します[IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported)と数字転送します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-146">Before setting this, make sure that the symbology supports check digit transmission with [IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported).</span></span> <span data-ttu-id="b09ca-147">次に、 [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled)チェック ディジット転送が有効になっているかどうかを設定します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-147">Then, set whether check digit transmission is enabled with [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled).</span></span>

<span data-ttu-id="b09ca-148">次のコード スニペットは、設定チェック ディジットの転送を示しています。</span><span class="sxs-lookup"><span data-stu-id="b09ca-148">The following code snippet demonstrates setting check digit transmission:</span></span>

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

### <a name="check-digit-validation"></a><span data-ttu-id="b09ca-149">チェック ディジットの検証</span><span class="sxs-lookup"><span data-stu-id="b09ca-149">Check digit validation</span></span>

<span data-ttu-id="b09ca-150">バーコード チェック ディジットは検証されているかどうかを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="b09ca-150">You can also set whether the barcode check digit will be validated.</span></span> <span data-ttu-id="b09ca-151">これを設定する前に、シンボル体系がチェックをサポートしていることを確認します[IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported)桁検証します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-151">Before setting this, make sure that the symbology supports check digit validation with [IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported).</span></span> <span data-ttu-id="b09ca-152">次に、 [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled)とチェック ディジットの検証が有効になっているかどうかを設定します。</span><span class="sxs-lookup"><span data-stu-id="b09ca-152">Then, set whether check digit validation is enabled with [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled).</span></span>

<span data-ttu-id="b09ca-153">次のコード スニペットは、設定チェック ディジットの検証を示しています。</span><span class="sxs-lookup"><span data-stu-id="b09ca-153">The following code snippet demonstrates setting check digit validation:</span></span>

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

## <a name="see-also"></a><span data-ttu-id="b09ca-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="b09ca-154">See also</span></span>

* [<span data-ttu-id="b09ca-155">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="b09ca-155">Barcode scanner</span></span>](pos-barcodescanner.md)
* [<span data-ttu-id="b09ca-156">BarcodeSymbologies クラス</span><span class="sxs-lookup"><span data-stu-id="b09ca-156">BarcodeSymbologies Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)
* [<span data-ttu-id="b09ca-157">BarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="b09ca-157">BarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [<span data-ttu-id="b09ca-158">ClaimedBarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="b09ca-158">ClaimedBarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)
* [<span data-ttu-id="b09ca-159">BarcodeSymbologyAttributes クラス</span><span class="sxs-lookup"><span data-stu-id="b09ca-159">BarcodeSymbologyAttributes Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)
* [<span data-ttu-id="b09ca-160">BarcodeSymbologyDecodeLengthKind 列挙型</span><span class="sxs-lookup"><span data-stu-id="b09ca-160">BarcodeSymbologyDecodeLengthKind Enum</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)