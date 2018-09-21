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
# <a name="obtain-and-understand-barcode-data"></a>取得し、バーコードのデータを理解します。

バーコード スキャナーを設定すると、当然のことながらしたら、データをスキャンすることを理解するための方法です。 バーコードをスキャンするときは、 [DataReceived](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.datareceived)イベントが発生します。 [ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)は、このイベントをサブスクライブする必要があります。 **DataReceived**イベントは、バーコード データにアクセスするために使用できる[BarcodeScannerDataReceivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)オブジェクトを渡します。

## <a name="subscribe-to-the-datareceived-event"></a>DataReceived イベントを購読します。

した後、 **ClaimedBarcodeScanner**、 **DataReceived**イベントを購読することがあります。

```cs
claimedBarcodeScanner.DataReceived += ClaimedBarcodeScanner_DataReceived;
```

イベント ハンドラーは、 **ClaimedBarcodeScanner**と**BarcodeScannerDataReceivedEventArgs**オブジェクトに渡されます。 型[BarcodeScannerReport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)は、このオブジェクトの[レポート](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs.report#Windows_Devices_PointOfService_BarcodeScannerDataReceivedEventArgs_Report)プロパティで、バーコード データにアクセスできます。

```cs
private async void ClaimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    // Parse the data
}
```

## <a name="get-the-data"></a>データを取得します。

**BarcodeScannerReport**を作成したらにアクセスし、バーコードのデータを解析できます。 **BarcodeScannerReport**には、3 つのプロパティがあります。

* [ScanData](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandata): バーコードを完全な生データです。
* [ScanDataLabel](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatalabel): デコードされたバーコード ・ ラベルには、ヘッダー、チェックサム、およびその他の情報は含まれません。
* [ScanDataType](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport.scandatatype): デコードされたバーコード ラベルの種類です。 使用可能な値は、 [BarcodeSymbologies](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)クラスで定義されます。

**ScanDataLabel**または**ScanDataType**のいずれかにアクセスする場合は、 **true**に[IsDecodeDataEnabled](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdecodedataenabled#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDecodeDataEnabled)を設定する必要があります。

```cs
claimedBarcodeScanner.IsDecodeDataEnabled = true;
```

### <a name="get-the-scan-data-type"></a>スキャン データの種類を取得します。

デコードされたバーコード ラベルの種類を取得するは非常に単純な&mdash; **ScanDataType**の[GetName](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)を呼び出しています。

```cs
private string GetSymbology(BarcodeScannerDataReceivedEventArgs args)
{
    return BarcodeSymbologies.GetName(args.Report.ScanDataType);
}
```

### <a name="get-the-scan-data-label"></a>スキャン データのラベルを取得します。

デコードされたバーコード ラベルを取得するには、いくつかのことに注意する必要があります。 特定のデータ型だけでは、エンコードされたテキストが含まれているかどうか、シンボルは、文字列に変換することができ、 **ScanDataLabel**から UTF-8 エンコードされた文字列を取得するバッファーを変換を最初にチェックする必要がありますので。

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

全体を取得するには、バーコードからの生のデータだけで変換バッファーの文字列を**ScanData**から取得します。

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

これらのデータは、一般的に、スキャナーから送信されたときの形式でです。 メッセージのヘッダーとトレイラの情報は、ただし、アプリケーションに役立つ情報が含まれていないされ、特定のスキャナーを使用する可能性があります。

共通のヘッダー情報は、(STX 文字) などの接頭辞です。 一般的なトレーラーの情報は、(ETX または CR 文字) などの終端文字とブロック チェック文字場合は、スキャナーによって生成された 1 つ。

スキャナーによって返されるいずれかの場合、このプロパティは、記号文字を含める必要があります (など、 **A**の UPC A)。 ラベルに存在する場合はチェック数字を含める必要がありますし、スキャナーによって返されます。 (注する記号の文字と数字のチェックの両方かは表示されません、スキャナーの構成によって異なります。 スキャナーを返す場合は説明するが生成またはこれらが存在しない場合は、それらを計算します)。

補足のバーコードでは、いくつかの商品をマークすることがあります。 このバーコードは、主要なバーコードの右側には通常、配置し、情報の追加または 2 つの 5 文字で構成されています。 スキャナーは、商品を読み取る場合は、メインと追加の両方のバーコードが含まれている補足的な文字は、メインの文字に追加されます。、結果が 1 つのラベルとしてアプリケーションに配信されます。 (スキャナーまたは補足的なコードの読み取りを無効にする構成をサポート可能性があることに注意してください)。

*Multisymbol ラベル*または*階層型のラベル*とも呼ばれる複数のラベルでは、いくつか商品をマークすることがあります。 バーコードの代表的な垂直方向にし、同じまたは別のコードの場合があります。 スキャナーでは、複数のラベルを含む商品を読み取り、各バーコードは、独立したラベルとしてアプリケーションに配信されます。 これらのバーコードの種類の標準化の現在の不足のために必要です。 個々 のバーコード データに基づくすべてのバリエーションを特定することがあります。 したがって、アプリケーションと、複数のラベルのバーコード読み取られた返されるデータに基づいて決定する必要があります。 (スキャナーが可能性がありますまたは複数のラベルの読み取りができない場合があることに注意してください)。

**DataReceived**イベントがアプリケーションに発生する前にこの値が設定されています。

[!INCLUDE [feedback](./includes/pos-feedback.md)]

## <a name="see-also"></a>関連項目
* [バーコード スキャナー](pos-barcodescanner.md)
* [ClaimedBarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies.getname)
* [BarcodeScannerDataReceivedEventArgs クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerdatareceivedeventargs)
* [BarcodeScannerReport クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)
* [BarcodeSymbologies クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodesymbologies)