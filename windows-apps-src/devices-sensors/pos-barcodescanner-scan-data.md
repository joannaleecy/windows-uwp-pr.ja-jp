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
# <a name="obtain-and-understand-barcode-data"></a>バーコード データの取得と理解

バーコード スキャナーをセットアップした後は、もちろん方法、スキャンするデータを理解することの必要があります。 バーコードをスキャンするときに、 [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived)イベントが発生します。 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)このイベントをサブスクライブする必要があります。 **DataReceived**イベントを渡します、 [BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)オブジェクトで、バーコード データへのアクセスに使用することができます。

## <a name="subscribe-to-the-datareceived-event"></a>DataReceived イベントをサブスクライブするには

作成したら、 **ClaimedBarcodeScanner**、サブスクライブすることがある、 **DataReceived**イベント。

```cs
claimedBarcodeScanner.DataReceived += ClaimedBarcodeScanner_DataReceived;
```

イベント ハンドラーが渡される、 **ClaimedBarcodeScanner**と**BarcodeScannerDataReceivedEventArgs**オブジェクト。 このオブジェクトのバーコード データにアクセスできます[レポート](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report)型のプロパティ、 [BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)します。

```cs
private async void ClaimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    // Parse the data
}
```

## <a name="get-the-data"></a>データを取得します。

作成したら、 **BarcodeScannerReport**、アクセスし、バーコード データを解析することができます。 **BarcodeScannerReport**は 3 つのプロパティがあります。

* [ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata):完全な生のバーコード データ。
* [ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel):デコードされたバーコード ラベル、ヘッダー、チェックサム、およびその他の情報は含まれません。
* [ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype):デコードされたバーコード ラベルの種類。 使用可能な値が定義されている、 [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)クラス。

いずれかにアクセスする場合**ScanDataLabel**または**ScanDataType**をまず設定する必要があります[IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled)に**true**します。

```cs
claimedBarcodeScanner.IsDecodeDataEnabled = true;
```

### <a name="get-the-scan-data-type"></a>スキャン データ型を取得します。

デコードされたバーコード ラベルの種類を取得することは簡単&mdash;呼び出して[GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)で**ScanDataType**します。

```cs
private string GetSymbology(BarcodeScannerDataReceivedEventArgs args)
{
    return BarcodeSymbologies.GetName(args.Report.ScanDataType);
}
```

### <a name="get-the-scan-data-label"></a>スキャン データのラベルを取得します。

デコードされたバーコード ラベルを取得するには、いくつかの点を認識する必要があります。 特定のデータ型にエンコード済みのテキストが含まれている場合かどうか、シンボルは、文字列に変換することができからバッファーを変換をまず確認する必要がありますので専用**ScanDataLabel**を utf-8 でエンコードされた文字列。

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

### <a name="get-the-raw-scan-data"></a>生のスキャン データを取得します。

バーコードから、完全な生データを取得することに単純に変換からバッファー **ScanData**を文字列にします。

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

これらのデータは、一般に、スキャナーからの配信形式です。 メッセージのヘッダーおよびトレーラの情報はために、削除、ただし、アプリケーションに関する有用な情報が含まれていないこれらとスキャナーに固有である可能性があります。

一般的なヘッダー情報は、プレフィックス文字 (STX 文字の場合) などです。 共通のトレーラー情報は、スキャナーが 1 つが生成される場合は、ETX または CR の文字) などの終端文字でチェックするブロック文字。

1 つが、スキャナーによって返された場合、このプロパティは記号文字を含める必要があります (たとえば、 **A**の UPC A)。 ラベルに存在する場合は、チェックの数字を含める必要がありますし、スキャナーで返されます。 (記号文字とチェック ディジット可能性がありますか、表示されない可能性が、スキャナーの構成に応じてに注意してください。 スキャナーは場合を返しますに存在するがない生成またはこれらが存在しない場合は、それらを計算します)。

補足のバーコードでは、いくつかの商品をマークすることがあります。 このバーコードは、通常はメインのバーコードの右側に配置し、情報の追加 2 つまたは 5 文字から成ます。 スキャナーが商品を読み取る場合は、メインと補足の両方のバーコードを格納していると、補助文字は、メインの文字に付加されます結果が 1 つのラベルとしてアプリケーションに配信されます。 (または補足コードの読み取りを無効にする構成をスキャナーは対応する必要があることに注意してください)。

いくつかの商品とも呼ばれる複数のラベルでマークすることがあります*multisymbol ラベル*または*ラベルを階層化*します。 バーコードは通常垂直方向に配置され、同じまたは別のコードの可能性があります。 スキャナーは、複数のラベルを含む商品を読み取り、各バーコードは別のラベルとしてアプリケーションに配信されます。 これは、現在のバーコードのような標準化の欠如のために必要です。 1 つは個々 のバーコード データに基づくすべてのバリエーションを特定できません。 アプリケーションでは、ときに、複数のラベルのバーコードが読み取られた返されるデータに基づいて決定する必要があります。 (スキャナーが可能性がありますか、複数のラベルの読み取りをサポートしない可能性がありますに注意してください)。

この値より前のバージョンに設定されます、 **DataReceived**イベントがアプリケーションに発生します。

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a>関連項目
* [バーコード スキャナー](pos-barcodescanner.md)
* [ClaimedBarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)
* [BarcodeScannerDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)
* [BarcodeScannerReport クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)
* [BarcodeSymbologies クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)
