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
# <a name="enumerating-point-of-service-devices"></a><span data-ttu-id="fb51b-104">POS デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="fb51b-104">Enumerating Point of Service devices</span></span>
<span data-ttu-id="fb51b-105">このセクションでは、システムが利用できるデバイスを照会するために使用する[**デバイス セレクターを定義**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)し、次のいずれかの方法でこのセレクターを使用して POS デバイスを列挙する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-105">In this section you will learn how to [**define a device selector**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) that is used to query devices available to the system and use this selector to enumerate Point of Service devices using one of the following methods:</span></span>

<span data-ttu-id="fb51b-106">**方法 1:**[**最初に利用可能なデバイスの取得**](#Method-1:-get-first-available-device)</span><span class="sxs-lookup"><span data-stu-id="fb51b-106">**Method 1:** [**Get first available device**](#Method-1:-get-first-available-device)</span></span><br /><span data-ttu-id="fb51b-107">このセクションでは、**GetDefaultAsync** を使用して特定の PointOfService デバイス クラスで最初に利用可能なデバイスにアクセスする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-107">In this section you will learn how to use **GetDefaultAsync** to access the first available device in a specific PointOfService device class.</span></span>

<span data-ttu-id="fb51b-108">**方法 2:**[**デバイスのスナップショット**](#Method-2:-Snapshot-of-devices)</span><span class="sxs-lookup"><span data-stu-id="fb51b-108">**Method 2:** [**Snapshot of devices**](#Method-2:-Snapshot-of-devices)</span></span><br /><span data-ttu-id="fb51b-109">このセクションでは、任意の時点でシステムに存在する PointOfService デバイスのスナップショットを列挙する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-109">In this section you will learn how to enumerate a snapshot of PointOfService devices that are present on the system at a given point in time.</span></span> <span data-ttu-id="fb51b-110">これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-110">This is useful when you want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span> <span data-ttu-id="fb51b-111">FindAllAsync では列挙がすべて完了するまで結果が表示されません。</span><span class="sxs-lookup"><span data-stu-id="fb51b-111">FindAllAsync will hold back results until the entire enumeration is completed.</span></span>

<span data-ttu-id="fb51b-112">**方法 3:** [**列挙と監視**](#Method-3:-Enumerate-and-watch)</span><span class="sxs-lookup"><span data-stu-id="fb51b-112">**Method 3:** [**Enumerate and watch**](#Method-3:-Enumerate-and-watch)</span></span><br /><span data-ttu-id="fb51b-113">このセクションでは、現在存在するデバイスを列挙し、デバイスがシステムに対して追加または削除されたときに通知を受け取ることもできる、強力かつ柔軟な列挙モデルについて説明します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-113">In this section you will learn about a more powerful and flexible enumeration model that allows you to enumerate devices that are currently present, and also receive notifications when devices are added or removed from the system.</span></span>  <span data-ttu-id="fb51b-114">これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-114">This is useful when you want to maintain a current list of devices in the background for displaying in your UI rather than waiting for a snapshot to occur.</span></span>
 

---
## <a name="define-a-device-selector"></a><span data-ttu-id="fb51b-115">デバイス セレクターの定義</span><span class="sxs-lookup"><span data-stu-id="fb51b-115">Define a device selector</span></span>
<span data-ttu-id="fb51b-116">デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-116">A device selector will enable you to limit the devices you are searching through when enumerating devices.</span></span>  <span data-ttu-id="fb51b-117">これにより、関連する結果のみを取得することができ、目的のデバイスを列挙するのにかかる時間を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-117">This will enable you to only get relevant results and reduce the time it takes to enumerate the desired devices.</span></span>  

<span data-ttu-id="fb51b-118">[**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector) を使用すると、USB、ネットワーク、および Bluetooth POSPrinters など、システムに接続されているすべての POSPrinters を列挙するセレクターが提供されます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-118">Using [**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector) will provide you with a selector to enumerate all POSPrinters attached to the system, including USB, network and Bluetooth POSPrinters.</span></span>

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();   

```

<span data-ttu-id="fb51b-119">[**PosConnectionTypes**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes) をパラメーターとして受け取る [**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector_Windows_Devices_PointOfService_PosConnectionTypes_) メソッドを使用すると、セレクターがローカル、ネットワーク、または Bluetooth 接続の POSPrinters を列挙するように制限するため、クエリが完了するまでにかかる時間を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-119">Using the [**GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector_Windows_Devices_PointOfService_PosConnectionTypes_) method that takes [**PosConnectionTypes**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes) as a parameter, you can restrict your selector to enumerate local, network or Bluetooth attached POSPrinters reducing the time it takes for the query to complete.</span></span>  <span data-ttu-id="fb51b-120">次のサンプルでは、この方法を使用してローカルに接続された POSPrinters のみをサポートするセレクターを定義する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fb51b-120">The sample below shows the use of this method to define a selctor that support only locally attached POSPrinters.</span></span>

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);   

```
> [!TIP]
> <span data-ttu-id="fb51b-121">より高度なセレクター文字列のビルドについては、「[**デバイス セレクターのビルド**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb51b-121">See [**Build a device selector**](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) for building more advanced selector strings.</span></span>

---

## <a name="method-1-get-first-available-device"></a><span data-ttu-id="fb51b-122">方法 1: 最初に利用可能なデバイスの取得</span><span class="sxs-lookup"><span data-stu-id="fb51b-122">Method 1: Get first available device</span></span>

<span data-ttu-id="fb51b-123">PointOfService デバイスを取得する最も簡単な方法は、**GetDefaultAsync** を使用して PointOfService デバイス クラス内で最初に利用可能なデバイスを取得することです。</span><span class="sxs-lookup"><span data-stu-id="fb51b-123">The simplest way to get a PointOfService device is to use **GetDefaultAsync** to get the first available device within a PointOfService device class.</span></span> 

<span data-ttu-id="fb51b-124">次のサンプルは、BarcodeScanner の [**GetDefaultAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync) の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="fb51b-124">The sample below illustrates the use of [**GetDefaultAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync) for BarcodeScanner.</span></span> <span data-ttu-id="fb51b-125">コーディング パターンは、すべての PointOfService デバイス クラスで同様です。</span><span class="sxs-lookup"><span data-stu-id="fb51b-125">The coding pattern is similar for all PointOfService device classes.</span></span>

```Csharp

using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();

```

> [!CAUTION]
> <span data-ttu-id="fb51b-126">GetDefaultAsync は、セッションごとに別のデバイスを返す可能性があるため、慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-126">GetDefaultAsync must be used with care as it may return a different device from one session to the next.</span></span> <span data-ttu-id="fb51b-127">多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-127">Many events can influence this enumeration resulting in a different first available device, including:</span></span> 
> - <span data-ttu-id="fb51b-128">コンピューターに接続されているカメラの変更</span><span class="sxs-lookup"><span data-stu-id="fb51b-128">Change in cameras attached to your computer</span></span> 
> - <span data-ttu-id="fb51b-129">コンピューターに接続されている PointOfService デバイスの変更</span><span class="sxs-lookup"><span data-stu-id="fb51b-129">Change in PointOfService devices attached to your computer</span></span>
> - <span data-ttu-id="fb51b-130">ネットワークで利用できるネットワークに接続されている PointOfService デバイスの変更</span><span class="sxs-lookup"><span data-stu-id="fb51b-130">Change in network attached PointOfService devices available on your network</span></span>
> - <span data-ttu-id="fb51b-131">コンピューターの範囲内での Bluetooth PointOfService デバイスの変更</span><span class="sxs-lookup"><span data-stu-id="fb51b-131">Change in Bluetooth PointOfService devices within range of your computer</span></span> 
> - <span data-ttu-id="fb51b-132">PointOfService 構成の変更</span><span class="sxs-lookup"><span data-stu-id="fb51b-132">Changes to the PointOfService configuration</span></span> 
> - <span data-ttu-id="fb51b-133">ドライバーまたは OPOS サービス オブジェクトのインストール</span><span class="sxs-lookup"><span data-stu-id="fb51b-133">Installation of drivers or OPOS service objects</span></span>
> - <span data-ttu-id="fb51b-134">PointOfService 拡張機能のインストール</span><span class="sxs-lookup"><span data-stu-id="fb51b-134">Installation of PointOfService extensions</span></span>
> - <span data-ttu-id="fb51b-135">Windows オペレーティング システムの更新</span><span class="sxs-lookup"><span data-stu-id="fb51b-135">Update to Windows operating system</span></span>

---

## <a name="method-2-snapshot-of-devices"></a><span data-ttu-id="fb51b-136">方法 2: デバイスのスナップショット</span><span class="sxs-lookup"><span data-stu-id="fb51b-136">Method 2: Snapshot of devices</span></span>

<span data-ttu-id="fb51b-137">シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-137">In some scenarios you may want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span>  <span data-ttu-id="fb51b-138">このような場合は、[**DeviceInformation.FindAllAsync**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) を使用して現在接続されている、またはシステムとペアリングされているデバイスのスナップショットを列挙する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-138">In these situations, you could enumerate a snapshot of devices that are currently connected or paired with the system using [**DeviceInformation.FindAllAsync**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync).</span></span>  <span data-ttu-id="fb51b-139">この方法では列挙がすべて完了するまで結果が表示されません。</span><span class="sxs-lookup"><span data-stu-id="fb51b-139">This method will hold back any results until the entire enumeration is completed.</span></span>

> [!TIP]
> <span data-ttu-id="fb51b-140">FindAllAsync を使用して、クエリを目的の接続の種類に制限する場合は、GetDeviceSelector メソッドを PosConnectionTypes パラメーターと一緒に使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fb51b-140">It is recommended to use GetDeviceSelector method with the PosConnectionTypes parameter when using FindAllAsync to limit your query to the connection type desired.</span></span>  <span data-ttu-id="fb51b-141">ネットワークおよび Bluetooth 接続では、FindAllAsync 結果が返される前に列挙が完了する必要があるため、結果が遅延する可能性があります</span><span class="sxs-lookup"><span data-stu-id="fb51b-141">Network and Bluetooth connections can delay the results as their enumerations must complete before FindAllAsync results are returned.</span></span>

>[!CAUTION] 
><span data-ttu-id="fb51b-142">FindAllAsync はデバイスの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-142">FindAllAsync returns an array of devices.</span></span>  <span data-ttu-id="fb51b-143">この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fb51b-143">The order of this array can change from session to session, therefore it is not recommended to rely on a specific order by using a hardcoded index into the array.</span></span>  <span data-ttu-id="fb51b-144">DeviceInformation プロパティを使用して、結果をフィルター処理するか、またはユーザーが選択できる UI を提供します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-144">Use DeviceInformation properties to filter your results or provide an UI for the user to choose from.</span></span>

<span data-ttu-id="fb51b-145">このサンプルでは、上で定義されたセレクターを使用して FindAllAsync でデバイスのスナップショットを取得し、コレクションで返された各項目を列挙してデバイス名と ID をデバッグ出力に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-145">This sample uses the selector defined above to take a snapshot of devices using FindAllAsync then enumerates through each of the items returned by the collection and writes the device name and ID to the debug output.</span></span> 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> <span data-ttu-id="fb51b-146">[**Windows.Devices.Enumeration**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) API を操作する場合は、[**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) オブジェクトを頻繁に使用して特定のデバイスに関する情報を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-146">When working with the [**Windows.Devices.Enumeration**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) APIs, you will frequently need to use [**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) objects to obtain information about a specific device.</span></span> <span data-ttu-id="fb51b-147">たとえば、[**DeviceInformation.ID**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) プロパティを使用して、同じデバイスが以降のセッションで利用可能である場合に回復して再び使うことができます。また、[**DeviceInformation.Name**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name) プロパティをアプリで表示目的で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-147">For example, [**DeviceInformation.ID**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) property can be used to recover and reuse the same device if it is available in a future session and [**DeviceInformation.Name**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name) property can be used for display purposes in your app.</span></span>  <span data-ttu-id="fb51b-148">利用可能なその他のプロパティについては、「[**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)」リファレンス ページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb51b-148">See the [**DeviceInformation**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) reference page for information about additional properties available.</span></span>

---

## <a name="method-3-enumerate-and-watch"></a><span data-ttu-id="fb51b-149">方法 3: 列挙と監視</span><span class="sxs-lookup"><span data-stu-id="fb51b-149">Method 3: Enumerate and watch</span></span>

<span data-ttu-id="fb51b-150">デバイスをより強力かつ柔軟な方法で列挙するには、[**DeviceWatcher**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) を作成します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-150">A more powerful and flexible method of enumerating devices is creating a [**DeviceWatcher**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher).</span></span>  <span data-ttu-id="fb51b-151">デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="fb51b-151">A device watcher enumerates devices dynamically, so that the application receives notifications if devices are added, removed, or changed  after the initial enumeration is complete.</span></span>  <span data-ttu-id="fb51b-152">DeviceWatcher により、ネットワーク接続されたデバイスがオンラインになったとき、Bluetooth デバイスが接続範囲内に入ったとき、さらに、ローカルに接続されたデバイスが接続されていない場合に検出して、アプリケーション内で適切なアクションを実行できるようにします。</span><span class="sxs-lookup"><span data-stu-id="fb51b-152">A DeviceWatcher will allow you to detect when a network connected device comes online, a Bluetooth device is in range, as well as if a locally connected device is unplugged so that you can take the appropriate action within your application.</span></span>

<span data-ttu-id="fb51b-153">このサンプルでは、上で定義されたセレクターを使用して DeviceWatcher を作成し、Added、Removed、Updated 通知のイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="fb51b-153">This sample uses the selector defined above to create a DeviceWatcher as well as defines event handlers for the Added, Removed and Updated notifications.</span></span> <span data-ttu-id="fb51b-154">各通知で実行するアクションの詳細を記入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb51b-154">You will need to fill in the details of the actions that you wish to take upon each notification.</span></span>

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
> <span data-ttu-id="fb51b-155">DeviceWatcher の使用の詳細については、「[**デバイスの列挙と監視**]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)」を参照してください</span><span class="sxs-lookup"><span data-stu-id="fb51b-155">See [**Enumerate and watch devices**]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices) for more details on the use of a DeviceWatcher</span></span>
