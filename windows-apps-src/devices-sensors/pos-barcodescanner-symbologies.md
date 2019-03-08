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
# <a name="working-with-symbologies"></a>シンボル体系の操作
[バーコード シンボル体系](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)は、データと特定のバーコード形式のマッピングです。 UPC、コード 128、QR コード、およびなど、いくつかの一般的な記号が含まれます。  スキャナーがスキャナーを手動で構成しなくても、これらの記号をどのように処理する方法を制御するユニバーサル Windows プラットフォームのバーコード スキャナーの Api を使用できます。 

## <a name="determine-which-symbologies-are-supported"></a>サポートされているシンボル体系を判断する 
複数の製造元から提供されるさまざまなバーコード スキャナーのモデルでアプリケーションを使用できるようにするために、スキャナーに対してクエリを実行して、サポートされているシンボル体系のリストを特定することができます。  これは、アプリケーションがすべてのスキャナーでサポートされていない可能性がある特定のシンボル体系を必要とする場合や、スキャナーで手動またはプログラムによって無効になっているシンボル体系を有効にする必要がある場合に便利です。

[BarcodeScanner.FromIdAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を使用して [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner) オブジェクトを取得した後で、[GetSupportedSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getsupportedsymbologiesasync#Windows_Devices_PointOfService_BarcodeScanner_GetSupportedSymbologiesAsync) を呼び出して、デバイスでサポートされているシンボル体系のリストを取得します。

次の例では、バーコード スキャナーなどのサポートされている記号の一覧を取得し、テキスト ブロックに表示されます。

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
スキャナーが呼び出すことができます、特定のシンボルをサポートしているかを判断する[IsSymbologySupportedAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.issymbologysupportedasync#Windows_Devices_PointOfService_BarcodeScanner_IsSymbologySupportedAsync_System_UInt32_)します。

次の例は、バーコード スキャナ サポートしているかをチェック、 **Code32**シンボル。

```cs
bool symbologySupported = await barcodeScanner.IsSymbologySupportedAsync(BarcodeSymbologies.Code32);
```

## <a name="change-which-symbologies-are-recognized"></a>変更するバーコードを認識
場合によっては、バーコード スキャナーがサポートするシンボル体系のサブセットを使用することもできます。  これは、アプリケーションで使用する予定のないシンボル体系をブロックする場合に特に便利です。 たとえば、ユーザーが適切なバーコードをスキャンできるように、アイテムの SKU を取得するときにはスキャンを UPC または EAN に制限し、シリアル番号を取得するときにはスキャンを Code 128 に制限することができます。

スキャナーがサポートするシンボル体系がわかったら、スキャナーで認識するシンボル体系を設定できます。  これを確立した後、 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)オブジェクトを使用して[ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync)します。 [SetActiveSymbologiesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setactivesymbologiesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_SetActiveSymbologiesAsync_Windows_Foundation_Collections_IIterable_System_UInt32__) を呼び出して特定のシンボル体系のセットを有効にすることができます。リストから省略したシンボル体系は無効になります。

次の例では、設定を要求したバーコード スキャナーのアクティブなバーコード[Code39](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39#Windows_Devices_PointOfService_BarcodeSymbologies_Code39)と[Code39Ex](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.code39ex):

```cs
private async void SetSymbologies(ClaimedBarcodeScanner claimedBarcodeScanner) 
{
    var symbologies = new List<uint>{ BarcodeSymbologies.Code39, BarcodeSymbologies.Code39Ex };
    await claimedBarcodeScanner.SetActiveSymbologiesAsync(symbologies);
}
```

## <a name="barcode-symbology-attributes"></a>バーコード シンボル属性
別のバーコード バーコード サポートの複数の長さ、生のデータの一部としてホストにチェック ディジットの送信のデコード桁の検証の確認など、さまざまな属性は、ことができます。 [BarcodeSymbologyAttributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes)クラスを取得および設定できるこれらの属性を指定された[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)とバーコード シンボル。

指定されたコードの属性を取得する[GetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.getsymbologyattributesasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_GetSymbologyAttributesAsync_System_UInt32_)します。 次のコード スニペットの Upca コードの属性を取得する、 **ClaimedBarcodeScanner**します。

```cs
BarcodeSymbologyAttributes barcodeSymbologyAttributes = 
    await claimedBarcodeScanner.GetSymbologyAttributesAsync(BarcodeSymbologies.Upca);
```

属性およびそれらを設定できるように変更が完了したら、呼び出す[SetSymbologyAttributesAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.setsymbologyattributesasync)します。 このメソッドが戻る、 **bool**、これは**true**属性が正常に設定されている場合。

```cs
bool success = await claimedBarcodeScanner.SetSymbologyAttributesAsync(
    BarcodeSymbologies.Upca, barcodeSymbologyAttributes);
```

### <a name="restrict-scan-data-by-data-length"></a>スキャン データのデータの長さを制限します。
一部のシンボル体系 (Code 39 や Code 128 など) は可変長です。  これらの記号のバーコードは、特定の長さの多くの場合、別のデータを含む、互いに近くに配置できます。 必要なデータの特定の長さを設定することで、無効なスキャンを防止できます。

デコードの長さを設定する前に、バーコード シンボルが複数期間をサポートしているかどうかを確認[IsDecodeLengthSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.isdecodelengthsupported#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_IsDecodeLengthSupported)します。 設定することはサポートされていることがわかったら、 [DecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelengthkind#Windows_Devices_PointOfService_BarcodeSymbologyAttributes_DecodeLengthKind)、型の[BarcodeSymbologyDecodeLengthKind](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologydecodelengthkind)します。 このプロパティは、次の値のいずれかを使用できます。

* **AnyLength**:任意の数の長さをデコードします。
* **不連続**:いずれかの長さをデコード[DecodeLength1](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength1)または[DecodeLength2](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.decodelength2) 1 バイト文字。
* **範囲**:長さをデコード**DecodeLength1**と**DecodeLength2** 1 バイト文字。 順序**DecodeLength1**と**DecodeLength2** (いずれかのできる他のより高いまたは低い) でも操作を行います。

値を設定する最後に、 **DecodeLength1**と**DecodeLength2**が必要なデータの長さを制御します。

デコードの長さを設定する次のコード スニペットに示します。

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

### <a name="check-digit-transmission"></a>数字の転送を確認してください。

別の属性をコードに設定することができますが、かどうかチェック ディジットが送信されるホストに生データの一部として。 を設定する前に、コードがチェックをサポートすることを確認します桁伝送[IsCheckDigitTransmissionSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionsupported)します。 チェックの数字の転送が有効になっているかどうかを設定し、 [IsCheckDigitTransmissionEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigittransmissionenabled)します。

次のコード スニペットでは、チェック桁転送の設定を示しています。

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

### <a name="check-digit-validation"></a>桁の検証を確認してください。

バーコード チェック ディジットが検証されるかどうかを設定することもできます。 を設定する前に、コードがチェックをサポートすることを確認します桁の数字を使用して検証[IsCheckDigitValidationSupported](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationsupported)します。 チェックの桁の検証が有効になっているかどうかを設定し、 [IsCheckDigitValidationEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologyattributes.ischeckdigitvalidationenabled)します。

次のコード スニペットでは、チェックの桁の検証の設定を示しています。

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