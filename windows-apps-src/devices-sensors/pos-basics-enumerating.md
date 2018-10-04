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
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4357845"
---
# <a name="enumerating-point-of-service-devices"></a><span data-ttu-id="8a2e0-104">POS デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="8a2e0-104">Enumerating Point of Service devices</span></span>
<span data-ttu-id="8a2e0-105">このセクションでは、システムが利用できるデバイスを照会するために使用する[デバイス セレクターを定義](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)し、次のいずれかの方法でこのセレクターを使用して POS デバイスを列挙する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-105">In this section you will learn how to [define a device selector](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) that is used to query devices available to the system and use this selector to enumerate Point of Service devices using one of the following methods:</span></span>

<span data-ttu-id="8a2e0-106">**方法 1:**[デバイス ピッカーの使用](#method-1:-use-a-device-picker)</span><span class="sxs-lookup"><span data-stu-id="8a2e0-106">**Method 1:** [Use a device picker](#method-1:-use-a-device-picker)</span></span>
<br/>
<span data-ttu-id="8a2e0-107">デバイス ピッカー UI を表示して、ユーザーが接続されているデバイスを選択しています。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-107">Display a device picker UI and have the user choose a connected device.</span></span> <span data-ttu-id="8a2e0-108">このメソッドは、デバイスが接続されているし、削除、一覧の更新を処理し、方が簡単かつ他の方法よりも安全です。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-108">This method handles updating the list when devices are attached and removed, and is simpler and safer than other methods.</span></span>

<span data-ttu-id="8a2e0-109">**方法 2:**[最初に利用可能なデバイスを取得します。](#Method-1:-get-first-available-device)</span><span class="sxs-lookup"><span data-stu-id="8a2e0-109">**Method 2:** [Get first available device](#Method-1:-get-first-available-device)</span></span><br /><span data-ttu-id="8a2e0-110">[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync)を使用して、特定の Point of Service デバイス クラスで最初に利用可能なデバイスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-110">Use [GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync) to access the first available device in a specific Point of Service device class.</span></span>

<span data-ttu-id="8a2e0-111">**方法 3:**[デバイスのスナップショット](#Method-2:-Snapshot-of-devices)</span><span class="sxs-lookup"><span data-stu-id="8a2e0-111">**Method 3:** [Snapshot of devices](#Method-2:-Snapshot-of-devices)</span></span><br /><span data-ttu-id="8a2e0-112">時間内の特定の時点でシステムに存在する Point of Service デバイスのスナップショットを列挙します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-112">Enumerate a snapshot of Point of Service devices that are present on the system at a given point in time.</span></span> <span data-ttu-id="8a2e0-113">これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-113">This is useful when you want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span> <span data-ttu-id="8a2e0-114">[Findallasync で結果列挙が完了するまでです。](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)</span><span class="sxs-lookup"><span data-stu-id="8a2e0-114">[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) will hold back results until the entire enumeration is completed.</span></span>

<span data-ttu-id="8a2e0-115">**方法 4:**[列挙と監視](#Method-3:-Enumerate-and-watch)</span><span class="sxs-lookup"><span data-stu-id="8a2e0-115">**Method 4:** [Enumerate and watch](#Method-3:-Enumerate-and-watch)</span></span><br /><span data-ttu-id="8a2e0-116">[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)は、現在存在するデバイスを列挙してそれらのデバイスが追加されるか、システムから削除された場合に通知を受け取ることもできる強力かつ柔軟な列挙モデルです。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-116">[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) is a more powerful and flexible enumeration model that allows you to enumerate devices that are currently present, and also receive notifications when devices are added or removed from the system.</span></span>  <span data-ttu-id="8a2e0-117">これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-117">This is useful when you want to maintain a current list of devices in the background for displaying in your UI rather than waiting for a snapshot to occur.</span></span>

## <a name="define-a-device-selector"></a><span data-ttu-id="8a2e0-118">デバイス セレクターの定義</span><span class="sxs-lookup"><span data-stu-id="8a2e0-118">Define a device selector</span></span>
<span data-ttu-id="8a2e0-119">デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-119">A device selector will enable you to limit the devices you are searching through when enumerating devices.</span></span>  <span data-ttu-id="8a2e0-120">これは、オプションを選択するのみ関連する結果を取得し、目的のデバイスを列挙するのにかかる時間を短縮することができます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-120">This will allow you to only get relevant results and reduce the time it takes to enumerate the desired devices.</span></span>

<span data-ttu-id="8a2e0-121">その種類のデバイス セレクターを取得するのに探しているデバイスの種類は、 **GetDeviceSelector**メソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-121">You can use the **GetDeviceSelector** method for the type of device that you're looking for to get the device selector for that type.</span></span> <span data-ttu-id="8a2e0-122">たとえば、 [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector)を使用するには、USB、ネットワークおよび Bluetooth POS プリンターなど、システムに接続されているすべての[PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)を列挙するセレクターが提供されます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-122">For example, using [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector) will provide you with a selector to enumerate all [PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter) attached to the system, including USB, network and Bluetooth POS printers.</span></span>

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();
```

<span data-ttu-id="8a2e0-123">**GetDeviceSelector**メソッドは、さまざまなデバイスの種類は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-123">The **GetDeviceSelector** methods for the different device types are:</span></span>

* [<span data-ttu-id="8a2e0-124">BarcodeScanner.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="8a2e0-124">BarcodeScanner.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdeviceselector)
* [<span data-ttu-id="8a2e0-125">CashDrawer.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="8a2e0-125">CashDrawer.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.getdeviceselector)
* [<span data-ttu-id="8a2e0-126">LineDisplay.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="8a2e0-126">LineDisplay.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.getdeviceselector)
* [<span data-ttu-id="8a2e0-127">MagneticStripeReader.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="8a2e0-127">MagneticStripeReader.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.getdeviceselector)
* [<span data-ttu-id="8a2e0-128">PosPrinter.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="8a2e0-128">PosPrinter.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector)

<span data-ttu-id="8a2e0-129">[PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)値をパラメーターとして受け取る**GetDeviceSelector**メソッドを使用して、制限できます、セレクターを列挙するローカル、ネットワーク、または Bluetooth で接続されている POS デバイスの場合は、クエリを完了するのにかかる時間を短縮します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-129">Using a **GetDeviceSelector** method that takes a [PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes) value as a parameter, you can restrict your selector to enumerate local, network, or Bluetooth-attached POS devices, reducing the time it takes for the query to complete.</span></span>  <span data-ttu-id="8a2e0-130">次のサンプルでは、ローカルでのみをサポートするセレクターを定義するには、このメソッドを使用して POS プリンターの接続を示しています。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-130">The sample below shows a use of this method to define a selector that supports only locally attached POS printers.</span></span>

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);
```

> [!TIP]
> <span data-ttu-id="8a2e0-131">より高度なセレクター文字列のビルドについては、「[デバイス セレクターのビルド](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-131">See [Build a device selector](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) for building more advanced selector strings.</span></span>

## <a name="method-1-use-a-device-picker"></a><span data-ttu-id="8a2e0-132">方法 1: デバイス ピッカーを使用します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-132">Method 1: Use a device picker</span></span>

> [!NOTE]
> <span data-ttu-id="8a2e0-133">このメソッドでは、最新の[Windows SDK Insider Preview](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)が必要です。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-133">This method requires the latest [Windows SDK Insider Preview](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK).</span></span>

<span data-ttu-id="8a2e0-134">[DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker)クラスでは、ユーザーから選択するためのデバイスの一覧が含まれているピッカーのポップアップを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-134">The [DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker) class allows you to display a picker flyout that contains a list of devices for the user to choose from.</span></span> <span data-ttu-id="8a2e0-135">[フィルター](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter)のプロパティを使用すると、ピッカーを表示するのにデバイスの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-135">You can use the [Filter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter) property to choose which types of devices to show in the picker.</span></span> <span data-ttu-id="8a2e0-136">このプロパティは、型[DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter)です。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-136">This property is of type [DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter).</span></span> <span data-ttu-id="8a2e0-137">デバイスの種類は、 [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses)または[SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors)プロパティを使用してフィルターを追加できます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-137">You can add device types to the filter using the [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses) or [SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors) property.</span></span>

<span data-ttu-id="8a2e0-138">デバイス ピッカーを表示する準備ができたら、ピッカー UI を表示し、選択したデバイスを返す[PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync)メソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-138">When you are ready to show the device picker, you can call the [PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync) method, which will show the picker UI and return the selected device.</span></span> <span data-ttu-id="8a2e0-139">ポップアップが表示される場所を決定する[Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-139">You'll need to specify a [Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect) that will determine where the flyout appears.</span></span> <span data-ttu-id="8a2e0-140">このメソッドは、Api を使用することでポイントのサービスの[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクトを返します、する特定のデバイス クラスに**FromIdAsync**メソッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-140">This method will return a [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) object, so to use it with the Point of Service APIs, you'll need to use the **FromIdAsync** method for the particular device class that you want.</span></span> <span data-ttu-id="8a2e0-141">メソッドの*deviceId*のパラメーターとして[DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティを渡すし、戻り値としてデバイス クラスのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-141">You pass the [DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) property as the method's *deviceId* parameter, and get an instance of the device class as the return value.</span></span>

<span data-ttu-id="8a2e0-142">次のコード スニペットは、 **DevicePicker**を作成、バーコード スキャナーにフィルターをユーザーの選択、デバイスがあり、デバイス ID に基づいて**BarcodeScanner**オブジェクトを作成し、追加。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-142">The following code snippet creates a **DevicePicker**, adds a barcode scanner filter to it, has the user pick a device, and then creates a **BarcodeScanner** object based on the device ID:</span></span>

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

## <a name="method-2-get-first-available-device"></a><span data-ttu-id="8a2e0-143">方法 2: 最初に利用可能なデバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-143">Method 2: Get first available device</span></span>

<span data-ttu-id="8a2e0-144">**GetDefaultAsync**を使用して Point of Service のデバイス クラス内で最初に利用可能なデバイスを取得する最も簡単な方法は、Point of Service デバイスことです。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-144">The simplest way to get a Point of Service device is to use **GetDefaultAsync** to get the first available device within a Point of Service device class.</span></span> 

<span data-ttu-id="8a2e0-145">次のサンプルは、 [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)の[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync)の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-145">The sample below illustrates the use of [GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync) for [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner).</span></span> <span data-ttu-id="8a2e0-146">コーディング パターンは、Point of Service のすべてのデバイス クラスに似ています。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-146">The coding pattern is similar for all Point of Service device classes.</span></span>

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

> [!CAUTION]
> <span data-ttu-id="8a2e0-147">**GetDefaultAsync**は、次には 1 つのセッションからさまざまなデバイスを返すことがあります、注意して使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-147">**GetDefaultAsync** must be used with care as it may return a different device from one session to the next.</span></span> <span data-ttu-id="8a2e0-148">多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-148">Many events can influence this enumeration resulting in a different first available device, including:</span></span> 
> - <span data-ttu-id="8a2e0-149">コンピューターに接続されているカメラの変更</span><span class="sxs-lookup"><span data-stu-id="8a2e0-149">Change in cameras attached to your computer</span></span> 
> - <span data-ttu-id="8a2e0-150">お使いのコンピューターに接続されているデバイスのサービスのインポイントを変更します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-150">Change in Point of Service devices attached to your computer</span></span>
> - <span data-ttu-id="8a2e0-151">ネットワークで接続されている Point of Service デバイスのネットワークで利用可能なの変更します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-151">Change in network-attached Point of Service devices available on your network</span></span>
> - <span data-ttu-id="8a2e0-152">コンピューターの範囲内での Bluetooth Point of Service デバイスの変更します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-152">Change in Bluetooth Point of Service devices within range of your computer</span></span> 
> - <span data-ttu-id="8a2e0-153">Point of Service 構成の変更</span><span class="sxs-lookup"><span data-stu-id="8a2e0-153">Changes to the Point of Service configuration</span></span> 
> - <span data-ttu-id="8a2e0-154">ドライバーまたは OPOS サービス オブジェクトのインストール</span><span class="sxs-lookup"><span data-stu-id="8a2e0-154">Installation of drivers or OPOS service objects</span></span>
> - <span data-ttu-id="8a2e0-155">Point of Service の拡張機能のインストール</span><span class="sxs-lookup"><span data-stu-id="8a2e0-155">Installation of Point of Service extensions</span></span>
> - <span data-ttu-id="8a2e0-156">Windows オペレーティング システムの更新</span><span class="sxs-lookup"><span data-stu-id="8a2e0-156">Update to Windows operating system</span></span>

## <a name="method-3-snapshot-of-devices"></a><span data-ttu-id="8a2e0-157">方法 3: デバイスのスナップショット</span><span class="sxs-lookup"><span data-stu-id="8a2e0-157">Method 3: Snapshot of devices</span></span>

<span data-ttu-id="8a2e0-158">シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-158">In some scenarios you may want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span>  <span data-ttu-id="8a2e0-159">このような場合は、[DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) を使用して現在接続されている、またはシステムとペアリングされているデバイスのスナップショットを列挙する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-159">In these situations, you could enumerate a snapshot of devices that are currently connected or paired with the system using [DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync).</span></span>  <span data-ttu-id="8a2e0-160">この方法では列挙がすべて完了するまで結果が表示されません。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-160">This method will hold back any results until the entire enumeration is completed.</span></span>

> [!TIP]
> <span data-ttu-id="8a2e0-161">**FindAllAsync**を使用して、クエリに必要な接続の種類を制限するときに、 **GetDeviceSelector**メソッドを**PosConnectionTypes**パラメーターで使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-161">It is recommended to use the **GetDeviceSelector** method with the **PosConnectionTypes** parameter when using **FindAllAsync** to limit your query to the connection type desired.</span></span>  <span data-ttu-id="8a2e0-162">ネットワークおよび Bluetooth 接続できるため、結果遅延**FindAllAsync**結果が返される前に、列挙が完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-162">Network and Bluetooth connections can delay the results as their enumerations must complete before **FindAllAsync** results are returned.</span></span>

> [!CAUTION] 
> <span data-ttu-id="8a2e0-163">**FindAllAsync**では、デバイスの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-163">**FindAllAsync** returns an array of devices.</span></span>  <span data-ttu-id="8a2e0-164">この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-164">The order of this array can change from session to session, therefore it is not recommended to rely on a specific order by using a hardcoded index into the array.</span></span>  <span data-ttu-id="8a2e0-165">[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)プロパティを使用して、結果をフィルター処理またはユーザーから選択するための UI を提供します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-165">Use [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) properties to filter your results or provide a UI for the user to choose from.</span></span>

<span data-ttu-id="8a2e0-166">このサンプルは、 **FindAllAsync**を使用してデバイスのスナップショットを取得する上で定義されたセレクターを使用し、各コレクションによって返される項目を列挙し、デバイス名と ID をデバッグ出力に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-166">This sample uses the selector defined above to take a snapshot of devices using **FindAllAsync** then enumerates through each of the items returned by the collection and writes the device name and ID to the debug output.</span></span> 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> <span data-ttu-id="8a2e0-167">[Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) API を操作する場合は、[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) オブジェクトを頻繁に使用して特定のデバイスに関する情報を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-167">When working with the [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) APIs, you will frequently need to use [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) objects to obtain information about a specific device.</span></span> <span data-ttu-id="8a2e0-168">たとえば、 [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティに回復して、今後のセッションで利用可能なし、 [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name)プロパティは、アプリで表示目的で使用できますである場合は、同じデバイスを再使用できます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-168">For example, the [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) property can be used to recover and reuse the same device if it is available in a future session and the [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name) property can be used for display purposes in your app.</span></span>  <span data-ttu-id="8a2e0-169">利用可能なその他のプロパティについては、「[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)」リファレンス ページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-169">See the [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) reference page for information about additional properties available.</span></span>

## <a name="method-4-enumerate-and-watch"></a><span data-ttu-id="8a2e0-170">方法 4: 列挙し、監視</span><span class="sxs-lookup"><span data-stu-id="8a2e0-170">Method 4: Enumerate and watch</span></span>

<span data-ttu-id="8a2e0-171">デバイスをより強力かつ柔軟な方法で列挙するには、[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) を作成します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-171">A more powerful and flexible method of enumerating devices is creating a [DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher).</span></span>  <span data-ttu-id="8a2e0-172">デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-172">A device watcher enumerates devices dynamically, so that the application receives notifications if devices are added, removed, or changed  after the initial enumeration is complete.</span></span>  <span data-ttu-id="8a2e0-173">**DeviceWatcher**には、ネットワークに接続されているデバイスがオンラインになったときに検出することが、Bluetooth デバイスが範囲、ローカル接続されたデバイスが接続されていないため、アプリケーション内で適切なアクションを実行できる場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-173">A **DeviceWatcher** will allow you to detect when a network-connected device comes online, a Bluetooth device is in range, as well as if a locally connected device is unplugged so that you can take the appropriate action within your application.</span></span>

<span data-ttu-id="8a2e0-174">このサンプル**DeviceWatcher**を作成する上で定義されたセレクターを使用するほか、 [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added) [Removed](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed)、 [Updated](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)通知のイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-174">This sample uses the selector defined above to create a **DeviceWatcher** as well as defines event handlers for the [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added), [Removed](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed), and [Updated](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated) notifications.</span></span> <span data-ttu-id="8a2e0-175">各通知で実行するアクションの詳細を記入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-175">You will need to fill in the details of the actions that you wish to take upon each notification.</span></span>

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
> <span data-ttu-id="8a2e0-176">**DeviceWatcher**の使用について詳しくは、[デバイス]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8a2e0-176">See [Enumerate and watch devices]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices) for more details on the use of a **DeviceWatcher**.</span></span>

## <a name="see-also"></a><span data-ttu-id="8a2e0-177">関連項目</span><span class="sxs-lookup"><span data-stu-id="8a2e0-177">See also</span></span>
* [<span data-ttu-id="8a2e0-178">POS (店舗販売時点管理) の概要</span><span class="sxs-lookup"><span data-stu-id="8a2e0-178">Getting started with Point of Service</span></span>](pos-basics.md)
* [<span data-ttu-id="8a2e0-179">DeviceInformation クラス</span><span class="sxs-lookup"><span data-stu-id="8a2e0-179">DeviceInformation Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)
* [<span data-ttu-id="8a2e0-180">Pos プリンター クラス</span><span class="sxs-lookup"><span data-stu-id="8a2e0-180">PosPrinter Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)
* [<span data-ttu-id="8a2e0-181">PosConnectionTypes 列挙型</span><span class="sxs-lookup"><span data-stu-id="8a2e0-181">PosConnectionTypes Enum</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)
* [<span data-ttu-id="8a2e0-182">BarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="8a2e0-182">BarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [<span data-ttu-id="8a2e0-183">DeviceWatcher クラス</span><span class="sxs-lookup"><span data-stu-id="8a2e0-183">DeviceWatcher Class</span></span>](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)

[!INCLUDE [feedback](./includes/pos-feedback.md)]