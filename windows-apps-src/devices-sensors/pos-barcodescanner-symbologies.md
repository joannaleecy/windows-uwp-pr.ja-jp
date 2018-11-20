---
author: TerryWarwick
title: バーコード スキャナーのシンボル体系の使用
description: この記事には、バーコード スキャナーのシンボル体系に関する情報が含まれています。
ms.author: jken
ms.date: 08/29/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 91e09fd881ea5ce2b5ae6482148cdbb730c7ef17
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304331"
---
# <a name="working-with-symbologies"></a>シンボル体系の操作
[バーコード シンボル体系](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。 一般的なシンボル体系には、UPC、Code 128、QR コード、およびなどが含まれます。  ユニバーサル Windows プラットフォームのバーコード スキャナー Api は、スキャナーを手動で構成しなくても、スキャナーがこれらのシンボル体系を処理する方法を制御するアプリケーションを許可します。 

## <a name="determine-which-symbologies-are-supported"></a>サポートされているシンボル体系を判断する 
複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。  これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。

[BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得した後で、[GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。

次の例は、バーコード スキャナーのサポートされているシンボル体系のリストを取得し、テキスト ブロックに表示されます。

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

## <a name="determine-if-a-specific-symbology-is-supported"></a>特定のシンボル体系がサポートされているかどうかを判断する
スキャナーが特定のシンボル体系をサポートしているかを判断するには、 [IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_)を呼び出すことができます。

次の例では、バーコード スキャナーが**Code32**シンボル体系をサポートしているかを確認します。

```cs
bool symbologySupported = await barcodeScanner.IsSymbologySupportedAsync(BarcodeSymbologies.Code32);
```

## <a name="change-which-symbologies-are-recognized"></a>認識体系の変更
場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。  これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。 たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。

スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。  これは、 [ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync)を使用して、 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)オブジェクトを確立した後に実行できます。 [SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。

次の例[Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39)と[Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex)解放バーコード スキャナーのシンボル体系アクティブに設定します。

```cs
private async void SetSymbologies(ClaimedBarcodeScanner claimedBarcodeScanner) 
{
    var symbologies = new List<uint>{ BarcodeSymbologies.Code39, BarcodeSymbologies.Code39Ex };
    await claimedBarcodeScanner.SetActiveSymbologiesAsync(symbologies);
}
```

## <a name="barcode-symbology-attributes"></a>バーコード シンボル体系の属性
さまざまなバーコード シンボル体系サポートの複数の長さ、生のデータの一部として、ホストにチェック ディジットの送信をデコードし、チェック ディジットの検証など、さまざまな属性は、ことができます。 [BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)クラスを取得でき、特定の[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)とバーコード シンボル体系のこれらの属性を設定できます。

[GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_)で特定のシンボル体系の属性を取得することができます。 次のコード スニペットは、 **ClaimedBarcodeScanner**の Upca シンボル体系の属性を取得します。

```cs
BarcodeSymbologyAttributes barcodeSymbologyAttributes = 
    await claimedBarcodeScanner.GetSymbologyAttributesAsync(BarcodeSymbologies.Upca);
```

属性の変更が完了したら、それらを設定する準備が[SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync)を呼び出すことができます。 このメソッドは、属性が正常に設定されている場合は**true** **ブール値**を返します。

```cs
bool success = await claimedBarcodeScanner.SetSymbologyAttributesAsync(
    BarcodeSymbologies.Upca, barcodeSymbologyAttributes);
```

### <a name="restrict-scan-data-by-data-length"></a>データ データ長によるスキャンを制限します。
一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。  これらのシンボル体系のバーコードを配置して、特定の長さの多くの場合、さまざまなデータを含む、互いに近いことができます。 必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。

デコードの長さを設定する前に、バーコード シンボル体系が[IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)で複数の長さをサポートしているかどうかを確認します。 サポートされているわかったら、 [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind)、タイプ[BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)を設定できます。 このプロパティは、次の値のいずれかを指定できます。

* **AnyLength**: 任意の数の長さをデコードします。
* **ディスクリート**: [DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1)または[DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2)のいずれかの 1 バイト文字の長さをデコードします。
* **範囲**: **DecodeLength1**と**DecodeLength2** 1 バイト文字間の長さをデコードします。 **DecodeLength1**と**DecodeLength2** do でも (いずれかでは、その他のより大きいまたは小さい) の順序です。

最後に、必要なデータの長さを制御するには、 **DecodeLength1**と**DecodeLength2**の値を設定することができます。

次のコード スニペットは、デコードの長さを設定を示しています。

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

### <a name="check-digit-transmission"></a>チェック ディジットの転送

もう 1 つの属性が特定のシンボル体系を設定できますが、かどうかチェック ディジットに送信されます、ホストの生データの一部として。 これを設定する前に、シンボル体系がチェックをサポートすることを確認します[IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported)と数字転送します。 次に、 [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled)とチェック ディジット転送が有効になっているかどうかを設定します。

次のコード スニペットは、設定チェック ディジットの転送を示しています。

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

### <a name="check-digit-validation"></a>チェック ディジットの検証

バーコード チェック ディジットが検証されているかどうかを設定することもできます。 これを設定する前に、シンボル体系がチェックをサポートすることを確認します[IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported)桁検証します。 次に、 [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled)とチェック ディジットの検証が有効になっているかどうかを設定します。

次のコード スニペットは、設定チェック ディジットの検証を示しています。

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

## <a name="see-also"></a>関連項目

* [バーコード スキャナー](pos-barcodescanner.md)
* [BarcodeSymbologies クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)
* [BarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [ClaimedBarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)
* [BarcodeSymbologyAttributes クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)
* [BarcodeSymbologyDecodeLengthKind 列挙型](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)