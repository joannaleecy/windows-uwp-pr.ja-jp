---
title: PointOfService デバイスの列挙
description: PointOfService デバイスを列挙する方法の詳細
ms.date: 10/08/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 27d25864941b9d73c9b12e6329eab79fac1b15bf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620907"
---
# <a name="enumerating-point-of-service-devices"></a>POS デバイスの列挙
このセクションで説明する方法[デバイス セレクターの定義](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)システムで使用できるデバイスをクエリして、このセレクターを使用して、Point of Service のデバイスを使用して次のいずれかの列挙に使用します。

**方法 1:**[デバイスの選択を使用します。](#method-1-use-a-device-picker)
<br/>
デバイスの選択 UI を表示し、ユーザーに、接続されたデバイスを選択します。 このメソッドは、デバイスが接続され、削除、一覧の更新を処理し、簡単かつ他の方法よりも安全ですが。

**方法 2:**[最初に利用できるデバイスを取得します。](#method-2-get-first-available-device)<br />使用[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync)特定 Point of Service デバイス クラスで使用可能な最初のデバイスにアクセスします。

**方法 3:**[デバイスのスナップショット](#method-3-snapshot-of-devices)<br />特定の時点にシステム上に存在する Point of Service デバイスのスナップショットを列挙します。 これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。 [FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)遅れます結果、すべての列挙が完了するまでです。

**方法 4:**[列挙し、を見る](#method-4-enumerate-and-watch)<br />[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)より強力で柔軟な列挙型モデルに現在存在するデバイスを列挙し、デバイスの追加またはシステムから削除するときにも通知を受信することができますです。  これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。

## <a name="define-a-device-selector"></a>デバイス セレクターの定義
デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。  これは、オプションを選択するだけ適切な結果を取得し、目的のデバイスを列挙するためにかかる時間を短縮することができます。

使用することができます、 **GetDeviceSelector**の型のデバイス セレクターの取得を探しているデバイスの種類のメソッド。 を使用するなど[PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector)セレクターをすべて列挙する時期に備えた[PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter) USB、ネットワーク、Bluetooth の POS のプリンターを含む、システムに接続されています。

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();
```

**GetDeviceSelector**をさまざまなデバイスの種類の方法。

* [BarcodeScanner.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdeviceselector)
* [CashDrawer.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.getdeviceselector)
* [LineDisplay.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.getdeviceselector)
* [MagneticStripeReader.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.getdeviceselector)
* [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector)

使用して、 **GetDeviceSelector**を受け取るメソッドを[PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)値をパラメーターとしてを制限できます、ローカルの列挙、ネットワーク、セレクターまたは Bluetooth 接続の POS デバイス、削減しますクエリが完了するためにかかる時間です。  ローカルでのみをサポートするセレクターを定義するには、このメソッドの使用には、POS プリンターが接続されている次の例を示しています。

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);
```

> [!TIP]
> 参照してください[デバイス セレクターのビルド](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)詳細を構築するための advanced セレクター文字列。

## <a name="method-1-use-a-device-picker"></a>方法 1:デバイスの選択を使用します。

[DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker)クラスでは、選択できるユーザーのデバイスの一覧を含むピッカー フライアウトを表示できます。 使用することができます、[フィルター](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter)ピッカーを表示するデバイスの種類を選択するプロパティ。 このプロパティの型は[DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter)します。 デバイスの種類を追加するには、フィルターを使用する、 [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses)または[SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors)プロパティ。

デバイスの選択を表示する準備ができたらを呼び出すことができます、 [PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync)メソッドは、選択の UI を表示し、選択したデバイスを返します。 指定する必要があります、 [Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)フライアウトが表示される場所が決定します。 このメソッドは、 [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクト、Api を使用することでポイントのサービスを使用する必要がありますので、 **FromIdAsync**する特定のデバイス クラスのメソッド。 渡す、 [DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティ、メソッドのとして*deviceId*パラメーターと戻り値としてデバイス クラスのインスタンスを取得します。

次のコード スニペットを作成、 **DevicePicker**、バーコード スキャナー フィルターを追加し、作成して、デバイスを選んで、ユーザーが、 **BarcodeScanner**デバイス ID に基づいて、オブジェクト。

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

## <a name="method-2-get-first-available-device"></a>方法 2:最初に利用できるデバイスを取得します。

Point of Service デバイスを取得する最も簡単な方法は、使用することです。 **GetDefaultAsync** Point of Service デバイス クラス内で使用可能な最初のデバイスを取得します。 

以下のサンプルの使用を示します[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync)の[BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)します。 コーディング パターンは、Point of Service のすべてのデバイス クラスに似ています。

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

> [!CAUTION]
> **GetDefaultAsync**ように、[次へ] を 1 つのセッションから別のデバイスを返すこと可能性がありますに注意して使用する必要があります。 多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。 
> - コンピューターに接続されているカメラの変更 
> - コンピューターに接続されているサービスのデバイスのインポイント変更します。
> - ネットワーク接続ポイントのサービスのデバイスのネットワーク上で利用での変更します。
> - コンピューターの範囲内でデバイスの Bluetooth Point of Service での変更します。 
> - Point of Service の構成を変更する 
> - ドライバーまたは OPOS サービス オブジェクトのインストール
> - Point of Service 拡張機能のインストール
> - Windows オペレーティング システムの更新

## <a name="method-3-snapshot-of-devices"></a>方法 3:デバイスのスナップショット

シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。  このような状況では、現在接続されているかを使用して、システムと組み合わせて使用するデバイスのスナップショットを列挙するでした[DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)します。  この方法では列挙がすべて完了するまで結果が表示されません。

> [!TIP]
> 使用することをお勧め、 **GetDeviceSelector**メソッドを**PosConnectionTypes**パラメーターを使用する場合**FindAllAsync**クエリ、接続の種類を制限するには必要です。  前に、列挙が完了する必要があります、ネットワーク、Bluetooth の接続は、結果に遅れる**FindAllAsync**結果が返されます。

> [!CAUTION] 
> **FindAllAsync**デバイスの配列を返します。  この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。  使用[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)を結果をフィルター処理するか、ユーザーから選択するための UI を提供します。

このサンプルでは、セレクターを使用してデバイスのスナップショットを取得する上で定義した**FindAllAsync**の各コレクションによって返される項目を列挙し、デバイス名と ID をデバッグ出力に書き込みます。 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> 使用する場合、 [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) Api は頻繁に使用する必要が[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクトは、特定のデバイスに関する情報を取得します。 たとえば、 [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)回復、今後のセッションで使用できる場合は、同じデバイスを再利用してプロパティを使用できます、 [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name)表示のプロパティを使用できますアプリでの目的。  参照してください、 [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)リファレンス ページの使用可能な追加のプロパティに関する情報。

## <a name="method-4-enumerate-and-watch"></a>方法 4:列挙し、を見る

デバイスの列挙のより強力で柔軟なメソッドを作成、 [DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)します。  デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。  A **DeviceWatcher**デバイスがオンラインになる、Bluetooth デバイスが範囲、ネットワークに接続されたときを検出することがローカルに接続されたデバイスで内で適切なアクションを実行できるように接続されてない場合にも、アプリケーション。

このサンプルを作成する上で定義したセレクターを使用して、 **DeviceWatcher**のイベント ハンドラーを定義としても、 [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added)、[から削除された](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed)、および[更新日](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)通知します。 各通知で実行するアクションの詳細を記入する必要があります。

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
> 参照してください[列挙および watch デバイス]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)の使用方法の詳細については、 **DeviceWatcher**します。

## <a name="see-also"></a>関連項目
* [Point of Service の概要](pos-basics.md)
* [DeviceInformation クラス](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)
* [PosPrinter クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)
* [PosConnectionTypes 列挙型](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)
* [BarcodeScanner クラス](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [DeviceWatcher クラス](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)

[!INCLUDE [feedback](./includes/pos-feedback.md)]