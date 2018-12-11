---
title: PointOfService デバイスの列挙
description: PointOfService デバイスを列挙する方法の詳細
ms.date: 10/08/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 7759186d45d3488336a1b793d173d6d1f21aa601
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8918937"
---
# <a name="enumerating-point-of-service-devices"></a>POS デバイスの列挙
このセクションでは、システムが利用できるデバイスを照会するために使用する[デバイス セレクターを定義](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)し、次のいずれかの方法でこのセレクターを使用して POS デバイスを列挙する方法について説明します。

**方法 1:**[デバイス ピッカーの使用](#method-1:-use-a-device-picker)
<br/>
デバイス ピッカー UI を表示して、ユーザーが接続されているデバイスを選択しています。 このメソッドは、デバイスが接続され、削除、一覧の更新を処理し、方が簡単かつ他の方法よりも安全です。

**方法 2:**[最初に利用可能なデバイスを取得します。](#Method-1:-get-first-available-device)<br />[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync)を使用して、特定の Point of Service デバイス クラスで最初に利用可能なデバイスにアクセスします。

**方法 3:**[デバイスのスナップショット](#Method-2:-Snapshot-of-devices)<br />指定した時点でシステムに存在する Point of Service デバイスのスナップショットを列挙します。 これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。 [Findallasync で結果列挙が完了するまでです。](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)

**方法 4:**[列挙と監視](#Method-3:-Enumerate-and-watch)<br />[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)は、現在存在するデバイスを列挙し、デバイスが追加されるか、システムから削除された場合に通知を受け取ることもできる強力かつ柔軟な列挙モデルです。  これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。

## <a name="define-a-device-selector"></a>デバイス セレクターの定義
デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。  これは、オプションを選択するのみ関連する結果を取得し、目的のデバイスを列挙するのにかかる時間を短縮することができます。

その種類のデバイス セレクターを取得するのに探しているデバイスの種類は、 **GetDeviceSelector**メソッドを使用できます。 たとえば、 [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector)を使用するには、USB、ネットワークおよび Bluetooth POS プリンターなど、システムに接続されているすべての[PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)を列挙するセレクターが提供されます。

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();
```

**GetDeviceSelector**メソッドは、さまざまなデバイスの種類は次のとおりです。

* [BarcodeScanner.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdeviceselector)
* [CashDrawer.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.getdeviceselector)
* [LineDisplay.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.getdeviceselector)
* [MagneticStripeReader.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.getdeviceselector)
* [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector)

[PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)値をパラメーターとして受け取る**GetDeviceSelector**メソッドを使用して、制限できます、セレクターを列挙するローカル、ネットワーク、または Bluetooth で接続されている POS デバイスの場合は、クエリを完了するのにかかる時間を短縮します。  次のサンプルでは、ローカルでのみをサポートするセレクターを定義するには、このメソッドを使用して POS プリンターの接続を示しています。

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);
```

> [!TIP]
> より高度なセレクター文字列のビルドについては、「[デバイス セレクターのビルド](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)」を参照してください。

## <a name="method-1-use-a-device-picker"></a>方法 1: デバイス ピッカーを使用します。

[DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker)クラスでは、ユーザーから選択するためのデバイスの一覧が含まれているピッカーのポップアップを表示することができます。 [フィルター](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter)のプロパティを使用すると、ピッカーを表示するのにデバイスの種類を選択します。 このプロパティは、種類[DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter)です。 デバイスの種類は、 [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses)または[SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors)プロパティを使用してフィルターを追加できます。

デバイス ピッカーを表示する準備ができたら、ピッカー UI を表示し、選択したデバイスを返す[PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync)メソッドを呼び出すことができます。 ポップアップが表示される場所を決定する[Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)を指定する必要があります。 このメソッドは、Api を使用することでポイントのサービスの[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクトを返します、する特定のデバイス クラスに**FromIdAsync**メソッドを使用する必要があります。 メソッドの*deviceId*のパラメーターとして[DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティを渡すし、戻り値としてデバイス クラスのインスタンスを取得します。

次のコード スニペットは、 **DevicePicker**の作成をバーコード スキャナーのフィルターがユーザーの選択、デバイスとデバイス ID に基づいて**BarcodeScanner**オブジェクトを作成し、追加します。

```cs
private async Task<BarcodeScanner> GetBarcodeScanner()
{
    DevicePicker devicePicker = new DevicePicker();
    devicePicker.Filter.SupportedDeviceSelectors.Add(BarcodeScanner.GetDeviceSelector());
    Rect rect = new Rect();
    DeviceInformation deviceInformation = await devicePicker.PickSingleDeviceAsync(rect);
    BarcodeScanner barcodeScanner = await BarcodeScanner.FromIdAsync(deviceInformation.Id);
    return barcodeScanner;
}
```

## <a name="method-2-get-first-available-device"></a>方法 2: 最初に利用可能なデバイスを取得します。

**GetDefaultAsync**を使用して Point of Service のデバイス クラス内で最初に利用可能なデバイスを取得する最も簡単な方法は、Point of Service デバイスことです。 

次のサンプルは、 [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)の[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync)の使い方を示しています。 コーディング パターンは、Point of Service のすべてのデバイス クラスに似ています。

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

> [!CAUTION]
> **GetDefaultAsync**は、次には 1 つのセッションからさまざまなデバイスを返すことがあります、注意して使用する必要があります。 多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。 
> - コンピューターに接続されているカメラの変更 
> - お使いのコンピューターに接続されているデバイスのサービスのインポイントを変更します。
> - ネットワークで接続されている Point of Service デバイスのネットワークで利用可能なの変更します。
> - コンピューターの範囲内での Bluetooth Point of Service デバイスの変更します。 
> - Point of Service 構成の変更 
> - ドライバーまたは OPOS サービス オブジェクトのインストール
> - Point of Service の拡張機能のインストール
> - Windows オペレーティング システムの更新

## <a name="method-3-snapshot-of-devices"></a>方法 3: デバイスのスナップショット

シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。  このような場合は、[DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) を使用して現在接続されている、またはシステムとペアリングされているデバイスのスナップショットを列挙する可能性があります。  この方法では列挙がすべて完了するまで結果が表示されません。

> [!TIP]
> **FindAllAsync**を使用して、クエリに必要な接続の種類を制限するときに、 **GetDeviceSelector**メソッドを**PosConnectionTypes**パラメーターで使用することをお勧めします。  ネットワークおよび Bluetooth 接続は、 **FindAllAsync**結果が返される前に、列挙が完了する必要があります、結果を延期することができます。

> [!CAUTION] 
> **FindAllAsync**では、デバイスの配列を返します。  この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。  [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)プロパティを使用して、結果をフィルター処理またはユーザーから選択するための UI を提供します。

このサンプルは、 **FindAllAsync**を使用してデバイスのスナップショットを取得する上で定義されたセレクターを使用し、各コレクションによって返される項目を列挙し、デバイス名と ID をデバッグ出力に書き込みます。 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) API を操作する場合は、[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) オブジェクトを頻繁に使用して特定のデバイスに関する情報を取得する必要があります。 たとえば、 [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティに回復して、今後のセッションで使用可能になるし、 [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name)プロパティは、アプリで表示目的で使用できますである場合は、同じデバイスを再使用できます。  利用可能なその他のプロパティについては、「[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)」リファレンス ページを参照してください。

## <a name="method-4-enumerate-and-watch"></a>方法 4: 列挙し、監視

デバイスをより強力かつ柔軟な方法で列挙するには、[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) を作成します。  デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。  **DeviceWatcher**には、ネットワークに接続されているデバイスがオンラインになったときに検出することが、Bluetooth デバイスが範囲、ローカル接続されたデバイスが接続されていないため、アプリケーション内で適切なアクションを実行できる場合と同様です。

このサンプル**DeviceWatcher**を作成する上で定義されたセレクターを使用するほか、 [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added) [Removed](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed)、 [Updated](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)通知のイベント ハンドラーを定義します。 各通知で実行するアクションの詳細を記入する必要があります。

```Csharp
using Windows.Devices.Enumeration;

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

> [!TIP]
> **DeviceWatcher**の使用について詳しくは、[デバイス]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)を参照してください。

## <a name="see-also"></a>関連項目
* [POS (店舗販売時点管理) の概要](pos-basics.md)
* [DeviceInformation クラス](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)
* [Pos プリンター クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)
* [PosConnectionTypes 列挙型](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)
* [BarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [DeviceWatcher クラス](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)

[!INCLUDE [feedback](./includes/pos-feedback.md)]