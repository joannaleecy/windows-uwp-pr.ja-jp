---
author: TerryWarwick
title: PointOfService デバイスの列挙
description: PointOfService デバイスを列挙する方法の詳細
ms.author: jken
ms.date: 06/8/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: be1fdc42295fc03ff86a69e287a4089abe547689
ms.sourcegitcommit: ee77826642fe8fd9cfd9858d61bc05a96ff1bad7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/11/2018
ms.locfileid: "2018440"
---
# <a name="enumerating-point-of-service-devices"></a>POS デバイスの列挙
このセクションでは、システムが利用できるデバイスを照会するために使用する[**デバイス セレクターを定義**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)し、次のいずれかの方法でこのセレクターを使用して POS デバイスを列挙する方法について説明します。

**方法 1:**[**最初に利用可能なデバイスの取得**](#Method-1:-get-first-available-device)<br />このセクションでは、**GetDefaultAsync** を使用して特定の PointOfService デバイス クラスで最初に利用可能なデバイスにアクセスする方法について説明します。

**方法 2:**[**デバイスのスナップショット**](#Method-2:-Snapshot-of-devices)<br />このセクションでは、任意の時点でシステムに存在する PointOfService デバイスのスナップショットを列挙する方法を説明します。 これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。 FindAllAsync では列挙がすべて完了するまで結果が表示されません。

**方法 3:** [**列挙と監視**](#Method-3:-Enumerate-and-watch)<br />このセクションでは、現在存在するデバイスを列挙し、デバイスがシステムに対して追加または削除されたときに通知を受け取ることもできる、強力かつ柔軟な列挙モデルについて説明します。  これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。
 

---
## <a name="define-a-device-selector"></a>デバイス セレクターの定義
デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。  これにより、関連する結果のみを取得することができ、目的のデバイスを列挙するのにかかる時間を短縮できます。  

[**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector) を使用すると、USB、ネットワーク、および Bluetooth POSPrinters など、システムに接続されているすべての POSPrinters を列挙するセレクターが提供されます。

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();   

```

[**PosConnectionTypes**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes) をパラメーターとして受け取る [**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector_Windows_Devices_PointOfService_PosConnectionTypes_) メソッドを使用すると、セレクターがローカル、ネットワーク、または Bluetooth 接続の POSPrinters を列挙するように制限するため、クエリが完了するまでにかかる時間を短縮できます。  次のサンプルでは、この方法を使用してローカルに接続された POSPrinters のみをサポートするセレクターを定義する方法を示しています。

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);   

```
> [!TIP]
> より高度なセレクター文字列のビルドについては、「[**デバイス セレクターのビルド**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)」を参照してください。

---

## <a name="method-1-get-first-available-device"></a>方法 1: 最初に利用可能なデバイスの取得

PointOfService デバイスを取得する最も簡単な方法は、**GetDefaultAsync** を使用して PointOfService デバイス クラス内で最初に利用可能なデバイスを取得することです。 

次のサンプルは、BarcodeScanner の [**GetDefaultAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync) の使い方を示しています。 コーディング パターンは、すべての PointOfService デバイス クラスで同様です。

```Csharp

using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();

```

> [!CAUTION]
> GetDefaultAsync は、セッションごとに別のデバイスを返す可能性があるため、慎重に使用する必要があります。 多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。 
> - コンピューターに接続されているカメラの変更 
> - コンピューターに接続されている PointOfService デバイスの変更
> - ネットワークで利用できるネットワークに接続されている PointOfService デバイスの変更
> - コンピューターの範囲内での Bluetooth PointOfService デバイスの変更 
> - PointOfService 構成の変更 
> - ドライバーまたは OPOS サービス オブジェクトのインストール
> - PointOfService 拡張機能のインストール
> - Windows オペレーティング システムの更新

---

## <a name="method-2-snapshot-of-devices"></a>方法 2: デバイスのスナップショット

シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。  このような場合は、[**DeviceInformation.FindAllAsync**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) を使用して現在接続されている、またはシステムとペアリングされているデバイスのスナップショットを列挙する可能性があります。  この方法では列挙がすべて完了するまで結果が表示されません。

> [!TIP]
> FindAllAsync を使用して、クエリを目的の接続の種類に制限する場合は、GetDeviceSelector メソッドを PosConnectionTypes パラメーターと一緒に使用することをお勧めします。  ネットワークおよび Bluetooth 接続では、FindAllAsync 結果が返される前に列挙が完了する必要があるため、結果が遅延する可能性があります

>[!CAUTION] 
>FindAllAsync はデバイスの配列を返します。  この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。  DeviceInformation プロパティを使用して、結果をフィルター処理するか、またはユーザーが選択できる UI を提供します。

このサンプルでは、上で定義されたセレクターを使用して FindAllAsync でデバイスのスナップショットを取得し、コレクションで返された各項目を列挙してデバイス名と ID をデバッグ出力に書き込みます。 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> [**Windows.Devices.Enumeration**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) API を操作する場合は、[**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) オブジェクトを頻繁に使用して特定のデバイスに関する情報を取得する必要があります。 たとえば、[**DeviceInformation.ID**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) プロパティを使用して、同じデバイスが以降のセッションで利用可能である場合に回復して再び使うことができます。また、[**DeviceInformation.Name**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name) プロパティをアプリで表示目的で使用することができます。  利用可能なその他のプロパティについては、「[**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)」リファレンス ページを参照してください。

---

## <a name="method-3-enumerate-and-watch"></a>方法 3: 列挙と監視

デバイスをより強力かつ柔軟な方法で列挙するには、[**DeviceWatcher**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) を作成します。  デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。  DeviceWatcher により、ネットワーク接続されたデバイスがオンラインになったとき、Bluetooth デバイスが接続範囲内に入ったとき、さらに、ローカルに接続されたデバイスが接続されていない場合に検出して、アプリケーション内で適切なアクションを実行できるようにします。

このサンプルでは、上で定義されたセレクターを使用して DeviceWatcher を作成し、Added、Removed、Updated 通知のイベント ハンドラーを定義します。 各通知で実行するアクションの詳細を記入する必要があります。

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
> DeviceWatcher の使用の詳細については、「[**デバイスの列挙と監視**]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)」を参照してください
