---
title: POS (店舗販売時点管理) の概要
description: この記事には、POS (店舗販売時点管理) UWP API の概要に関する情報が含まれています。
ms.date: 05/1/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 0e537e40d5224f2522cb5ecebd92664d1794dd06
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8331128"
---
# <a name="getting-started-with-point-of-service"></a>POS (店舗販売時点管理) の概要

POS (店舗販売時点管理または販売時点管理) デバイスとは、小売トランザクションを進めやすくするために使われるコンピューター周辺機器です。 POS デバイスの例として、電子レジスター、バーコード スキャナー、磁気ストライプ リーダー、レシート プリンターなどがあります。

ここでは、ユニバーサル Windows プラットフォーム (UWP) PointOfService API を使った POS デバイスとのやり取りの基本について説明します。 ここで取り上げる内容には、デバイスの列挙、デバイス機能の確認、デバイスの要求、デバイスの共有が含まれます。 例としてバーコード スキャナーを使いますが、ここで説明するガイダンスのほとんどは、あらゆる UWP 互換 POS デバイスに適用されます  (サポートされているデバイスの一覧については、「[POS デバイスのサポート](pos-device-support.md)」をご覧ください)。

## <a name="finding-and-connecting-to-point-of-service-peripherals"></a>POS 周辺機器の検出と接続

アプリから POS デバイスを使用するには、アプリが実行されている PC とデバイスを事前にペアリングする必要があります。 POS デバイスに接続する方法はいくつかあり、プログラムによって接続するか、設定アプリを使います。

### <a name="connecting-to-devices-by-using-the-settings-app"></a>設定アプリを使ってデバイスに接続する
バーコード スキャナーなどの POS デバイスを PC に接続すると、他のデバイスと同じように表示されます。 デバイスは、設定アプリの **[デバイス] の [Bluetooth とその他のデバイス]** セクションに表示されます。 ここで **[Bluetooth またはその他のデバイスを追加する]** を選択して、POS デバイスとペアリングできます。

POS デバイスによっては、POS API を使ってプログラムから列挙されるまで設定アプリに表示されないことがあります。

### <a name="getting-a-single-point-of-service-device-with-getdefaultasync"></a>GetDefaultAsync で 1 台の POS デバイスを取得する
単純な例として、アプリを実行している PC に POS デバイスが 1 台だけ接続されていて、その 1 台をできるだけすばやくセットアップしたい場合があります。 これを実現するには、次に示すように、**GetDefaultAsync** メソッドを使って "既定" のデバイスを取得します。

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

既定のデバイスが見つかったら、取得されたデバイス オブジェクトを要求できます。 デバイスを "要求" すると、そのデバイスへの排他アクセスがアプリケーションに与えられるため、複数のプロセスから競合するコマンドが発行されるのを防ぐことができます。

> [!NOTE] 
> PC に複数の POS デバイスが接続されている場合、**GetDefaultAsync** は最初に見つかったデバイスを返します。 このため、アプリケーションから参照できる POS デバイスが 1 台だけであることが確実でなければ、**FindAllAsync** を使用してください。

### <a name="enumerating-a-collection-of-devices-with-findallasync"></a>FindAllAsync でデバイスのコレクションを列挙する

複数のデバイスが接続されている場合は、**PointOfService** デバイス オブジェクトのコレクションを列挙して、要求するデバイスを見つける必要があります。 たとば、次のコードでは、現在接続されているすべてのバーコード スキャナーのコレクションを作成し、そのコレクションから特定の名前を持つスキャナーを検索します。

```Csharp
using Windows.Devices.Enumeration;
using Windows.Devices.PointOfService;

string selector = BarcodeScanner.GetDeviceSelector();       
DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
    if (devInfo.Name.Contains("1200G"))
    {
        Debug.WriteLine(" Found one");
    }
}
```

### <a name="scoping-the-device-selection"></a>デバイスの選択スコープを設定する
デバイスに接続するときには、アプリがアクセスできる POS 周辺機器のサブセットに限定して検索することができます。 **GetDeviceSelector** メソッドを使うと、選択スコープを設定して、特定の方法 (Bluetooth や USB など) で接続されているデバイスだけを取得できます。 接続の種類が **Bluetooth**、**IP**、**Local**、または **All** のデバイスを検索するセレクターを作成できます。 ワイヤレス デバイスの検出はローカル (有線) の検出に比べて時間がかかるため、この方法が役立つことがあります。 **FindAllAsync** で接続の種類を **Local** に限定すると、ローカル デバイス接続に対する待ち時間だけで検索を完了できます。 たとえば、次のコードでは、ローカル接続を通じてアクセスできるすべてのバーコード スキャナーを取得します。 

```Csharp
string selector = BarcodeScanner.GetDeviceSelector(PosConnectionTypes.Local);
DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);
```

### <a name="reacting-to-device-connection-changes-with-devicewatcher"></a>DeviceWatcher でデバイスの接続状態の変更に対応する

アプリの実行中に、デバイスが切断または更新されたり、新しいデバイスを追加する必要が生じたりすることがあります。 **DeviceWatcher** を使うと、デバイス関連のイベントにアクセスして、アプリで適切に対応できるようになります。 **DeviceWatcher** の使い方の例を次に示します。デバイスが追加、削除、または更新されると、メソッド スタブが呼び出されます。

```Csharp
DeviceWatcher deviceWatcher = DeviceInformation.CreateWatcher(selector);
deviceWatcher.Added += DeviceWatcher_Added;
deviceWatcher.Removed += DeviceWatcher_Removed;
deviceWatcher.Updated += DeviceWatcher_Updated;

void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
{
    // TODO: Add the DeviceInformation object to your collection
}

void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
{
    // TODO: Remove the item in your collection associated with DeviceInformationUpdate
}

void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
{
    // TODO: Update your collection with information from DeviceInformationUpdate
}
```

## <a name="checking-the-capabilities-of-a-point-of-service-device"></a>POS デバイスの機能の確認
デバイス クラスが同じでも (バーコード スキャナーなど)、各デバイスの属性はモデルによって大きく異なる可能性があります。 特定のデバイス機能を必要とするアプリでは、接続されている各デバイス オブジェクトを調べて、目的の属性がサポートされているかどうかを確認することが必要になる場合があります。 たとえば、ビジネスによっては、特定のバーコード印刷パターンを使ってラベルを作成する必要があることがあります。 以下に、接続されているバーコード スキャナーが特定のシンボル体系をサポートしているかどうかを確認する方法を示します。 

> [!NOTE]
> シンボル体系とは、バーコードでメッセージをエンコードするために使われる言語マッピングです。

```Csharp
try
{
    BarcodeScanner barcodeScanner = await BarcodeScanner.FromIdAsync(deviceId);
    if (await barcodeScanner.IsSymbologySupportedAsync(BarcodeSymbologies.Code32))
    {
        Debug.WriteLine("Has symbology");
    }
}
catch (Exception ex)
{
    Debug.WriteLine("FromIdAsync() - " + ex.Message);
}
```

### <a name="using-the-devicecapabilities-class"></a>Device.Capabilities クラスを使用する
**Device.Capabilities** クラスは、すべての POS デバイス クラスが持つ属性の 1 つであり、各デバイスに関する一般的な情報を取得するために使用できます。 次の例では、デバイスで統計レポートがサポートされているかどうかを確認し、サポートされているすべての種類の統計情報を取得します。

```Csharp
try
{
    if (barcodeScanner.Capabilities.IsStatisticsReportingSupported)
    {
        Debug.WriteLine("Statistics reporting is supported");

        string[] statTypes = new string[] {""};
        IBuffer ibuffer = await barcodeScanner.RetrieveStatisticsAsync(statTypes);
    }
}
catch (Exception ex)
{
    Debug.WriteLine("EX: RetrieveStatisticsAsync() - " + ex.Message);
}
```

## <a name="claiming-a-point-of-service-device"></a>POS デバイスの要求
POS デバイスからアクティブな入出力を利用するには、事前にデバイスを要求して、デバイス機能への排他アクセスをアプリケーションに与える必要があります。 次のコードでは、既に説明した方法のいずれかを使ってバーコード スキャナー デバイスを検出した後、そのデバイスを要求する方法を示します。

```Csharp
try
{
    claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();
}
catch (Exception ex)
{
    Debug.WriteLine("EX: ClaimScannerAsync() - " + ex.Message);
}
```

### <a name="retaining-the-device"></a>デバイスの再起動
ネットワークまたは Bluetooth 接続経由で POS デバイスを使っているときに、デバイスをネットワーク上の他のアプリと共有したい場合があります  (これについては「[デバイスの共有](#sharing-a-device-between-apps)」をご覧ください)。また、デバイスを長時間にわたって保持することが必要になる場合もあります。 この例では、他のアプリからデバイスを解放するように要求されても、要求したバーコード スキャナーを保持し続ける方法を示します。

```Csharp
claimedBarcodeScanner.ReleaseDeviceRequested += claimedBarcodeScanner_ReleaseDeviceRequested;

void claimedBarcodeScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner e)
{
    e.RetainDevice();  // Retain exclusive access to the device
}
```

## <a name="input-and-output"></a>入力と出力

デバイスを要求したら、デバイスを使う準備はほとんど完了です。 デバイスから入力を受け取るには、データを受信するデリゲートを設定して有効にする必要があります。 次の例では、バーコード スキャナー デバイスを要求し、デコード プロパティを設定します。その後、**EnableAsync** を呼び出して、デコードされたデバイス入力を有効にします。 このプロセスはデバイス クラスによって異なるため、バーコード デバイス以外のデリゲートを設定する方法のガイダンスについては、関連する [UWP アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples#devices-and-sensors)をご覧ください。

```Csharp
try
{
    claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();
    if (claimedBarcodeScanner != null)
    {
        claimedBarcodeScanner.DataReceived += claimedBarcodeScanner_DataReceived;
        claimedBarcodeScanner.IsDecodeDataEnabled = true;
        await claimedBarcodeScanner.EnableAsync();
    }
}
catch (Exception ex)
{
    Debug.WriteLine("EX: ClaimScannerAsync() - " + ex.Message);
}


void claimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
{
    string symbologyName = BarcodeSymbologies.GetName(args.Report.ScanDataType);
    var scanDataLabelReader = DataReader.FromBuffer(args.Report.ScanDataLabel);
    string barcode = scanDataLabelReader.ReadString(args.Report.ScanDataLabel.Length);
}
```

## <a name="sharing-a-device-between-apps"></a>アプリ間でのデバイスの共有

POS デバイスは、短時間に複数のアプリからアクセスされる状況で使われることがよくあります。  デバイスが複数のアプリにローカルに (USB などの有線接続で) 接続されている場合、または Bluetooth や IP ネットワークで接続されている場合、デバイスをアプリ間で共有することができます。 各アプリのニーズに応じて、プロセスでデバイスの要求を解放することが必要になる場合があります。 次のコードでは、要求したバーコード スキャナー デバイスを解放し、他のアプリが要求して使用できるようにします。

```Csharp
if (claimedBarcodeScanner != null)
{
    claimedBarcodeScanner.Dispose();
    claimedBarcodeScanner = null;
}
```

> [!NOTE]
> POS デバイス クラスには、要求状態にかかわらず [IClosable インターフェイス](https://docs.microsoft.com/uwp/api/windows.foundation.iclosable)が実装されています。 デバイスがネットワークまたは Bluetooth を通じてアプリに接続されている場合、要求されているオブジェクトも要求されていないオブジェクトも、解放されるまで他のアプリが接続することはできません。

## <a name="see-also"></a>関連項目
+ [バーコード スキャナーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [キャッシュ ドロワーのサンプル]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [ライン ディスプレイのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [磁気ストライプ リーダーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [POS プリンターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

