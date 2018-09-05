---
author: TerryWarwick
title: PointOfService デバイスの列挙
description: PointOfService デバイスを列挙する方法の詳細
ms.author: jken
ms.date: 08/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 4e42ebb2eba7b6465be271e6095100c03798826f
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3369958"
---
# <a name="enumerating-point-of-service-devices"></a>POS デバイスの列挙
このセクションでは、システムが利用できるデバイスを照会するために使用する[デバイス セレクターを定義](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)し、次のいずれかの方法でこのセレクターを使用して POS デバイスを列挙する方法について説明します。

**方法 1:**[デバイスの選択コントロールの使用](#method-1:-use-a-device-picker)
<br/>
デバイス ピッカー UI を表示して、ユーザーが接続されているデバイスを選択しています。 このメソッドは、デバイスが接続されているし、削除、一覧の更新を処理し、方が簡単かつ他の方法よりも安全です。

**方法 2:**[最初に利用可能なデバイスを取得します。](#Method-1:-get-first-available-device)<br />[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync)を使用して特定の店舗販売時点管理デバイス クラスで最初に利用可能なデバイスにアクセスします。

**方法 3:**[デバイスのスナップショット](#Method-2:-Snapshot-of-devices)<br />時間で特定の時点でシステムに存在する店舗販売時点管理デバイスのスナップショットを列挙します。 これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。 [Findallasync で結果列挙が完了するまでです。](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)

**方法 4:**[列挙と監視](#Method-3:-Enumerate-and-watch)<br />[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)は、現在存在するデバイスを列挙し、デバイスが追加されるか、システムから削除された場合に、通知を受け取ることもできる強力かつ柔軟な列挙モデルです。  これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。

## <a name="define-a-device-selector"></a>デバイス セレクターの定義
デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。  これは、オプションを選択するのみ関連する結果を取得し、目的のデバイスを列挙するのにかかる時間を短縮することができます。

その種類のデバイス セレクターを取得するを検討しているデバイスの種類、 **GetDeviceSelector**メソッドを使用することができます。 たとえば、 [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector)を使用するには、USB、ネットワークおよび Bluetooth POS プリンターなど、システムに接続されているすべての[PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)を列挙するセレクターが提供されます。

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

[PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)値をパラメーターとして受け取る**GetDeviceSelector**メソッドを使用して、制限できます、セレクターを列挙するローカル、ネットワーク、または Bluetooth で接続されている POS デバイスの場合は、クエリを完了するのにかかる時間を短縮します。  次のサンプルでは、ローカルのみをサポートするセレクターを定義するには、このメソッドを使用して POS プリンターの接続を示します。

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);
```

> [!TIP]
> より高度なセレクター文字列のビルドについては、「[デバイス セレクターのビルド](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)」を参照してください。

## <a name="method-1-use-a-device-picker"></a>方法 1: デバイスの選択コントロールを使用します。

> [!NOTE]
> このメソッドでは、最新の[Windows SDK Insider Preview](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)が必要です。

[DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker)クラスでは、ユーザーから選択するためのデバイスの一覧が含まれているピッカーのポップアップを表示することができます。 ピッカーを表示するのにデバイスの種類を選択するのに[フィルター](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter)プロパティを使用することができます。 このプロパティは、型[DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter)です。 デバイスの種類は、 [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses)または[SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors)プロパティを使用してフィルターを追加できます。

デバイス ピッカーを表示する準備ができたら、ピッカー UI を表示され、選択したデバイスを返す[PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync)メソッドを呼び出すことができます。 ポップアップが表示される場所を決定する[Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)を指定する必要があります。 このメソッドは、Api を使用することで、ポイントのサービスの[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクトを返します、する特定のデバイス クラスに**FromIdAsync**メソッドを使用する必要があります。 メソッドの*deviceId*のパラメーターとして[DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティを渡すし、戻り値としてデバイス クラスのインスタンスを取得します。

次のコード スニペットは**DevicePicker**を作成、追加、バーコード スキャナーのフィルターがユーザーの選択、デバイスとデバイス ID に基づいて**BarcodeScanner**オブジェクトを作成します。

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

## <a name="method-2-get-first-available-device"></a>方法 2: 最初の利用可能なデバイスを取得します。

**GetDefaultAsync**を使用すると、店舗販売時点管理デバイス クラス内で利用可能な最初のデバイスの取得を店舗販売時点管理デバイスを取得する最も簡単な方法です。 

次のサンプルでは、 [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)の[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync)の使用方法を示します。 コーディング パターンは、すべての店舗販売時点管理デバイス クラスに似ています。

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

> [!CAUTION]
> **GetDefaultAsync**次に 1 つのセッションから別のデバイスを返すことが慎重に使用する必要があります。 多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。 
> - コンピューターに接続されているカメラの変更 
> - お使いのコンピューターに接続されているデバイスのサービスのインポイント変更します。
> - ネットワークで利用できるの [店舗販売時点管理デバイスのネットワーク接続の変更します。
> - お使いのコンピューターの範囲内での Bluetooth Point of Service デバイスの変更します。 
> - Point of Service 構成の変更 
> - ドライバーまたは OPOS サービス オブジェクトのインストール
> - 店舗販売時点管理の拡張機能のインストール
> - Windows オペレーティング システムの更新

## <a name="method-3-snapshot-of-devices"></a>方法 3: デバイスのスナップショット

シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。  このような場合は、[DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) を使用して現在接続されている、またはシステムとペアリングされているデバイスのスナップショットを列挙する可能性があります。  この方法では列挙がすべて完了するまで結果が表示されません。

> [!TIP]
> **FindAllAsync**を使用して、クエリに必要な接続の種類を制限する場合に、 **GetDeviceSelector**メソッドを**PosConnectionTypes**パラメーターを使用することをお勧めします。  ネットワークおよび Bluetooth 接続は、 **FindAllAsync**結果が返される前に、列挙が完了する必要があります、結果を遅延することができます。

> [!CAUTION] 
> **FindAllAsync**では、デバイスの配列を返します。  この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。  [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)プロパティを使用して、結果をフィルター処理または、ユーザーから選択するための UI を提供します。

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
> [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) API を操作する場合は、[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) オブジェクトを頻繁に使用して特定のデバイスに関する情報を取得する必要があります。 たとえば、 [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティを使用してに回復して[DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name)プロパティは、アプリで表示目的で使用できます以降のセッションで利用可能な場合、同じデバイスを再利用できます。  利用可能なその他のプロパティについては、「[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)」リファレンス ページを参照してください。

## <a name="method-4-enumerate-and-watch"></a>方法 4: 列挙し、監視

デバイスをより強力かつ柔軟な方法で列挙するには、[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) を作成します。  デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。  **DeviceWatcher**には、ネットワークに接続されているデバイスがオンラインになったときに検出することは、Bluetooth デバイスが範囲内には、アプリケーション内で適切なアクションを実行できるように、ローカル接続されたデバイスが接続されていない場合と同様です。

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