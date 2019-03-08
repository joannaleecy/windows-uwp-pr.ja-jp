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
# <a name="enumerating-point-of-service-devices"></a><span data-ttu-id="386b6-104">POS デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="386b6-104">Enumerating Point of Service devices</span></span>
<span data-ttu-id="386b6-105">このセクションで説明する方法[デバイス セレクターの定義](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)システムで使用できるデバイスをクエリして、このセレクターを使用して、Point of Service のデバイスを使用して次のいずれかの列挙に使用します。</span><span class="sxs-lookup"><span data-stu-id="386b6-105">In this section you will learn how to [define a device selector](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) that is used to query devices available to the system and use this selector to enumerate Point of Service devices using one of the following methods:</span></span>

<span data-ttu-id="386b6-106">**方法 1:**[デバイスの選択を使用します。](#method-1-use-a-device-picker)</span><span class="sxs-lookup"><span data-stu-id="386b6-106">**Method 1:** [Use a device picker](#method-1-use-a-device-picker)</span></span>
<br/>
<span data-ttu-id="386b6-107">デバイスの選択 UI を表示し、ユーザーに、接続されたデバイスを選択します。</span><span class="sxs-lookup"><span data-stu-id="386b6-107">Display a device picker UI and have the user choose a connected device.</span></span> <span data-ttu-id="386b6-108">このメソッドは、デバイスが接続され、削除、一覧の更新を処理し、簡単かつ他の方法よりも安全ですが。</span><span class="sxs-lookup"><span data-stu-id="386b6-108">This method handles updating the list when devices are attached and removed, and is simpler and safer than other methods.</span></span>

<span data-ttu-id="386b6-109">**方法 2:**[最初に利用できるデバイスを取得します。](#method-2-get-first-available-device)</span><span class="sxs-lookup"><span data-stu-id="386b6-109">**Method 2:** [Get first available device](#method-2-get-first-available-device)</span></span><br /><span data-ttu-id="386b6-110">使用[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync)特定 Point of Service デバイス クラスで使用可能な最初のデバイスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="386b6-110">Use [GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync) to access the first available device in a specific Point of Service device class.</span></span>

<span data-ttu-id="386b6-111">**方法 3:**[デバイスのスナップショット](#method-3-snapshot-of-devices)</span><span class="sxs-lookup"><span data-stu-id="386b6-111">**Method 3:** [Snapshot of devices](#method-3-snapshot-of-devices)</span></span><br /><span data-ttu-id="386b6-112">特定の時点にシステム上に存在する Point of Service デバイスのスナップショットを列挙します。</span><span class="sxs-lookup"><span data-stu-id="386b6-112">Enumerate a snapshot of Point of Service devices that are present on the system at a given point in time.</span></span> <span data-ttu-id="386b6-113">これは、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="386b6-113">This is useful when you want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span> <span data-ttu-id="386b6-114">[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)遅れます結果、すべての列挙が完了するまでです。</span><span class="sxs-lookup"><span data-stu-id="386b6-114">[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync) will hold back results until the entire enumeration is completed.</span></span>

<span data-ttu-id="386b6-115">**方法 4:**[列挙し、を見る](#method-4-enumerate-and-watch)</span><span class="sxs-lookup"><span data-stu-id="386b6-115">**Method 4:** [Enumerate and watch](#method-4-enumerate-and-watch)</span></span><br /><span data-ttu-id="386b6-116">[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)より強力で柔軟な列挙型モデルに現在存在するデバイスを列挙し、デバイスの追加またはシステムから削除するときにも通知を受信することができますです。</span><span class="sxs-lookup"><span data-stu-id="386b6-116">[DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) is a more powerful and flexible enumeration model that allows you to enumerate devices that are currently present, and also receive notifications when devices are added or removed from the system.</span></span>  <span data-ttu-id="386b6-117">これは、スナップショットが発生するのを待機するのではなく、UI で表示するためにバックグラウンドでデバイスの現在の一覧を維持する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="386b6-117">This is useful when you want to maintain a current list of devices in the background for displaying in your UI rather than waiting for a snapshot to occur.</span></span>

## <a name="define-a-device-selector"></a><span data-ttu-id="386b6-118">デバイス セレクターの定義</span><span class="sxs-lookup"><span data-stu-id="386b6-118">Define a device selector</span></span>
<span data-ttu-id="386b6-119">デバイス セレクターにより、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="386b6-119">A device selector will enable you to limit the devices you are searching through when enumerating devices.</span></span>  <span data-ttu-id="386b6-120">これは、オプションを選択するだけ適切な結果を取得し、目的のデバイスを列挙するためにかかる時間を短縮することができます。</span><span class="sxs-lookup"><span data-stu-id="386b6-120">This will allow you to only get relevant results and reduce the time it takes to enumerate the desired devices.</span></span>

<span data-ttu-id="386b6-121">使用することができます、 **GetDeviceSelector**の型のデバイス セレクターの取得を探しているデバイスの種類のメソッド。</span><span class="sxs-lookup"><span data-stu-id="386b6-121">You can use the **GetDeviceSelector** method for the type of device that you're looking for to get the device selector for that type.</span></span> <span data-ttu-id="386b6-122">を使用するなど[PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector)セレクターをすべて列挙する時期に備えた[PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter) USB、ネットワーク、Bluetooth の POS のプリンターを含む、システムに接続されています。</span><span class="sxs-lookup"><span data-stu-id="386b6-122">For example, using [PosPrinter.GetDeviceSelector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector#Windows_Devices_PointOfService_PosPrinter_GetDeviceSelector) will provide you with a selector to enumerate all [PosPrinters](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter) attached to the system, including USB, network and Bluetooth POS printers.</span></span>

```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector();
```

<span data-ttu-id="386b6-123">**GetDeviceSelector**をさまざまなデバイスの種類の方法。</span><span class="sxs-lookup"><span data-stu-id="386b6-123">The **GetDeviceSelector** methods for the different device types are:</span></span>

* [<span data-ttu-id="386b6-124">BarcodeScanner.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="386b6-124">BarcodeScanner.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdeviceselector)
* [<span data-ttu-id="386b6-125">CashDrawer.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="386b6-125">CashDrawer.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.cashdrawer.getdeviceselector)
* [<span data-ttu-id="386b6-126">LineDisplay.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="386b6-126">LineDisplay.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay.getdeviceselector)
* [<span data-ttu-id="386b6-127">MagneticStripeReader.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="386b6-127">MagneticStripeReader.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.magneticstripereader.getdeviceselector)
* [<span data-ttu-id="386b6-128">PosPrinter.GetDeviceSelector</span><span class="sxs-lookup"><span data-stu-id="386b6-128">PosPrinter.GetDeviceSelector</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter.getdeviceselector)

<span data-ttu-id="386b6-129">使用して、 **GetDeviceSelector**を受け取るメソッドを[PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)値をパラメーターとしてを制限できます、ローカルの列挙、ネットワーク、セレクターまたは Bluetooth 接続の POS デバイス、削減しますクエリが完了するためにかかる時間です。</span><span class="sxs-lookup"><span data-stu-id="386b6-129">Using a **GetDeviceSelector** method that takes a [PosConnectionTypes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes) value as a parameter, you can restrict your selector to enumerate local, network, or Bluetooth-attached POS devices, reducing the time it takes for the query to complete.</span></span>  <span data-ttu-id="386b6-130">ローカルでのみをサポートするセレクターを定義するには、このメソッドの使用には、POS プリンターが接続されている次の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="386b6-130">The sample below shows a use of this method to define a selector that supports only locally attached POS printers.</span></span>

 ```Csharp
using Windows.Devices.PointOfService;

string selector = POSPrinter.GetDeviceSelector(PosConnectionTypes.Local);
```

> [!TIP]
> <span data-ttu-id="386b6-131">参照してください[デバイス セレクターのビルド](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector)詳細を構築するための advanced セレクター文字列。</span><span class="sxs-lookup"><span data-stu-id="386b6-131">See [Build a device selector](https://docs.microsoft.com/windows/uwp/devices-sensors/build-a-device-selector) for building more advanced selector strings.</span></span>

## <a name="method-1-use-a-device-picker"></a><span data-ttu-id="386b6-132">方法 1:デバイスの選択を使用します。</span><span class="sxs-lookup"><span data-stu-id="386b6-132">Method 1: Use a device picker</span></span>

<span data-ttu-id="386b6-133">[DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker)クラスでは、選択できるユーザーのデバイスの一覧を含むピッカー フライアウトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="386b6-133">The [DevicePicker](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker) class allows you to display a picker flyout that contains a list of devices for the user to choose from.</span></span> <span data-ttu-id="386b6-134">使用することができます、[フィルター](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter)ピッカーを表示するデバイスの種類を選択するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="386b6-134">You can use the [Filter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.filter) property to choose which types of devices to show in the picker.</span></span> <span data-ttu-id="386b6-135">このプロパティの型は[DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter)します。</span><span class="sxs-lookup"><span data-stu-id="386b6-135">This property is of type [DevicePickerFilter](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter).</span></span> <span data-ttu-id="386b6-136">デバイスの種類を追加するには、フィルターを使用する、 [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses)または[SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="386b6-136">You can add device types to the filter using the [SupportedDeviceClasses](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceclasses) or [SupportedDeviceSelectors](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepickerfilter.supporteddeviceselectors) property.</span></span>

<span data-ttu-id="386b6-137">デバイスの選択を表示する準備ができたらを呼び出すことができます、 [PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync)メソッドは、選択の UI を表示し、選択したデバイスを返します。</span><span class="sxs-lookup"><span data-stu-id="386b6-137">When you are ready to show the device picker, you can call the [PickSingleDeviceAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicepicker.picksingledeviceasync) method, which will show the picker UI and return the selected device.</span></span> <span data-ttu-id="386b6-138">指定する必要があります、 [Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)フライアウトが表示される場所が決定します。</span><span class="sxs-lookup"><span data-stu-id="386b6-138">You'll need to specify a [Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect) that will determine where the flyout appears.</span></span> <span data-ttu-id="386b6-139">このメソッドは、 [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクト、Api を使用することでポイントのサービスを使用する必要がありますので、 **FromIdAsync**する特定のデバイス クラスのメソッド。</span><span class="sxs-lookup"><span data-stu-id="386b6-139">This method will return a [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) object, so to use it with the Point of Service APIs, you'll need to use the **FromIdAsync** method for the particular device class that you want.</span></span> <span data-ttu-id="386b6-140">渡す、 [DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)プロパティ、メソッドのとして*deviceId*パラメーターと戻り値としてデバイス クラスのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="386b6-140">You pass the [DeviceInformation.Id](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) property as the method's *deviceId* parameter, and get an instance of the device class as the return value.</span></span>

<span data-ttu-id="386b6-141">次のコード スニペットを作成、 **DevicePicker**、バーコード スキャナー フィルターを追加し、作成して、デバイスを選んで、ユーザーが、 **BarcodeScanner**デバイス ID に基づいて、オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="386b6-141">The following code snippet creates a **DevicePicker**, adds a barcode scanner filter to it, has the user pick a device, and then creates a **BarcodeScanner** object based on the device ID:</span></span>

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

## <a name="method-2-get-first-available-device"></a><span data-ttu-id="386b6-142">方法 2:最初に利用できるデバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="386b6-142">Method 2: Get first available device</span></span>

<span data-ttu-id="386b6-143">Point of Service デバイスを取得する最も簡単な方法は、使用することです。 **GetDefaultAsync** Point of Service デバイス クラス内で使用可能な最初のデバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="386b6-143">The simplest way to get a Point of Service device is to use **GetDefaultAsync** to get the first available device within a Point of Service device class.</span></span> 

<span data-ttu-id="386b6-144">以下のサンプルの使用を示します[GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync)の[BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)します。</span><span class="sxs-lookup"><span data-stu-id="386b6-144">The sample below illustrates the use of [GetDefaultAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.getdefaultasync#Windows_Devices_PointOfService_BarcodeScanner_GetDefaultAsync) for [BarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner).</span></span> <span data-ttu-id="386b6-145">コーディング パターンは、Point of Service のすべてのデバイス クラスに似ています。</span><span class="sxs-lookup"><span data-stu-id="386b6-145">The coding pattern is similar for all Point of Service device classes.</span></span>

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

> [!CAUTION]
> <span data-ttu-id="386b6-146">**GetDefaultAsync**ように、[次へ] を 1 つのセッションから別のデバイスを返すこと可能性がありますに注意して使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="386b6-146">**GetDefaultAsync** must be used with care as it may return a different device from one session to the next.</span></span> <span data-ttu-id="386b6-147">多くのイベントがこの列挙に影響を与え、次のように最初に利用できるデバイスが異なる結果になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="386b6-147">Many events can influence this enumeration resulting in a different first available device, including:</span></span> 
> - <span data-ttu-id="386b6-148">コンピューターに接続されているカメラの変更</span><span class="sxs-lookup"><span data-stu-id="386b6-148">Change in cameras attached to your computer</span></span> 
> - <span data-ttu-id="386b6-149">コンピューターに接続されているサービスのデバイスのインポイント変更します。</span><span class="sxs-lookup"><span data-stu-id="386b6-149">Change in Point of Service devices attached to your computer</span></span>
> - <span data-ttu-id="386b6-150">ネットワーク接続ポイントのサービスのデバイスのネットワーク上で利用での変更します。</span><span class="sxs-lookup"><span data-stu-id="386b6-150">Change in network-attached Point of Service devices available on your network</span></span>
> - <span data-ttu-id="386b6-151">コンピューターの範囲内でデバイスの Bluetooth Point of Service での変更します。</span><span class="sxs-lookup"><span data-stu-id="386b6-151">Change in Bluetooth Point of Service devices within range of your computer</span></span> 
> - <span data-ttu-id="386b6-152">Point of Service の構成を変更する</span><span class="sxs-lookup"><span data-stu-id="386b6-152">Changes to the Point of Service configuration</span></span> 
> - <span data-ttu-id="386b6-153">ドライバーまたは OPOS サービス オブジェクトのインストール</span><span class="sxs-lookup"><span data-stu-id="386b6-153">Installation of drivers or OPOS service objects</span></span>
> - <span data-ttu-id="386b6-154">Point of Service 拡張機能のインストール</span><span class="sxs-lookup"><span data-stu-id="386b6-154">Installation of Point of Service extensions</span></span>
> - <span data-ttu-id="386b6-155">Windows オペレーティング システムの更新</span><span class="sxs-lookup"><span data-stu-id="386b6-155">Update to Windows operating system</span></span>

## <a name="method-3-snapshot-of-devices"></a><span data-ttu-id="386b6-156">方法 3:デバイスのスナップショット</span><span class="sxs-lookup"><span data-stu-id="386b6-156">Method 3: Snapshot of devices</span></span>

<span data-ttu-id="386b6-157">シナリオによっては、独自の UI を作成する場合や、ユーザーに UI を表示せずにデバイスを列挙する場合などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="386b6-157">In some scenarios you may want to build your own UI or need to enumerate devices without displaying a UI to the user.</span></span>  <span data-ttu-id="386b6-158">このような状況では、現在接続されているかを使用して、システムと組み合わせて使用するデバイスのスナップショットを列挙するでした[DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync)します。</span><span class="sxs-lookup"><span data-stu-id="386b6-158">In these situations, you could enumerate a snapshot of devices that are currently connected or paired with the system using [DeviceInformation.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.findallasync).</span></span>  <span data-ttu-id="386b6-159">この方法では列挙がすべて完了するまで結果が表示されません。</span><span class="sxs-lookup"><span data-stu-id="386b6-159">This method will hold back any results until the entire enumeration is completed.</span></span>

> [!TIP]
> <span data-ttu-id="386b6-160">使用することをお勧め、 **GetDeviceSelector**メソッドを**PosConnectionTypes**パラメーターを使用する場合**FindAllAsync**クエリ、接続の種類を制限するには必要です。</span><span class="sxs-lookup"><span data-stu-id="386b6-160">It is recommended to use the **GetDeviceSelector** method with the **PosConnectionTypes** parameter when using **FindAllAsync** to limit your query to the connection type desired.</span></span>  <span data-ttu-id="386b6-161">前に、列挙が完了する必要があります、ネットワーク、Bluetooth の接続は、結果に遅れる**FindAllAsync**結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="386b6-161">Network and Bluetooth connections can delay the results as their enumerations must complete before **FindAllAsync** results are returned.</span></span>

> [!CAUTION] 
> <span data-ttu-id="386b6-162">**FindAllAsync**デバイスの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="386b6-162">**FindAllAsync** returns an array of devices.</span></span>  <span data-ttu-id="386b6-163">この配列の順序はセッションごとに変わる可能性があるため、配列にハードコードされたインデックスを使用することで特定の順序に依存しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="386b6-163">The order of this array can change from session to session, therefore it is not recommended to rely on a specific order by using a hardcoded index into the array.</span></span>  <span data-ttu-id="386b6-164">使用[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)を結果をフィルター処理するか、ユーザーから選択するための UI を提供します。</span><span class="sxs-lookup"><span data-stu-id="386b6-164">Use [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) properties to filter your results or provide a UI for the user to choose from.</span></span>

<span data-ttu-id="386b6-165">このサンプルでは、セレクターを使用してデバイスのスナップショットを取得する上で定義した**FindAllAsync**の各コレクションによって返される項目を列挙し、デバイス名と ID をデバッグ出力に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="386b6-165">This sample uses the selector defined above to take a snapshot of devices using **FindAllAsync** then enumerates through each of the items returned by the collection and writes the device name and ID to the debug output.</span></span> 

```Csharp
using Windows.Devices.Enumeration;

DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation devInfo in deviceCollection)
{
    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
}
```

> [!TIP] 
> <span data-ttu-id="386b6-166">使用する場合、 [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) Api は頻繁に使用する必要が[DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)オブジェクトは、特定のデバイスに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="386b6-166">When working with the [Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration) APIs, you will frequently need to use [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) objects to obtain information about a specific device.</span></span> <span data-ttu-id="386b6-167">たとえば、 [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id)回復、今後のセッションで使用できる場合は、同じデバイスを再利用してプロパティを使用できます、 [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name)表示のプロパティを使用できますアプリでの目的。</span><span class="sxs-lookup"><span data-stu-id="386b6-167">For example, the [DeviceInformation.ID](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) property can be used to recover and reuse the same device if it is available in a future session and the [DeviceInformation.Name](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.name) property can be used for display purposes in your app.</span></span>  <span data-ttu-id="386b6-168">参照してください、 [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)リファレンス ページの使用可能な追加のプロパティに関する情報。</span><span class="sxs-lookup"><span data-stu-id="386b6-168">See the [DeviceInformation](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation) reference page for information about additional properties available.</span></span>

## <a name="method-4-enumerate-and-watch"></a><span data-ttu-id="386b6-169">方法 4:列挙し、を見る</span><span class="sxs-lookup"><span data-stu-id="386b6-169">Method 4: Enumerate and watch</span></span>

<span data-ttu-id="386b6-170">デバイスの列挙のより強力で柔軟なメソッドを作成、 [DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)します。</span><span class="sxs-lookup"><span data-stu-id="386b6-170">A more powerful and flexible method of enumerating devices is creating a [DeviceWatcher](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher).</span></span>  <span data-ttu-id="386b6-171">デバイス ウォッチャーはデバイスを動的に列挙します。これにより、初回の列挙が完了した後にデバイスが追加、削除、変更された場合、アプリケーションが通知を受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="386b6-171">A device watcher enumerates devices dynamically, so that the application receives notifications if devices are added, removed, or changed  after the initial enumeration is complete.</span></span>  <span data-ttu-id="386b6-172">A **DeviceWatcher**デバイスがオンラインになる、Bluetooth デバイスが範囲、ネットワークに接続されたときを検出することがローカルに接続されたデバイスで内で適切なアクションを実行できるように接続されてない場合にも、アプリケーション。</span><span class="sxs-lookup"><span data-stu-id="386b6-172">A **DeviceWatcher** will allow you to detect when a network-connected device comes online, a Bluetooth device is in range, as well as if a locally connected device is unplugged so that you can take the appropriate action within your application.</span></span>

<span data-ttu-id="386b6-173">このサンプルを作成する上で定義したセレクターを使用して、 **DeviceWatcher**のイベント ハンドラーを定義としても、 [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added)、[から削除された](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed)、および[更新日](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)通知します。</span><span class="sxs-lookup"><span data-stu-id="386b6-173">This sample uses the selector defined above to create a **DeviceWatcher** as well as defines event handlers for the [Added](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added), [Removed](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.removed), and [Updated](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated) notifications.</span></span> <span data-ttu-id="386b6-174">各通知で実行するアクションの詳細を記入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="386b6-174">You will need to fill in the details of the actions that you wish to take upon each notification.</span></span>

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
> <span data-ttu-id="386b6-175">参照してください[列挙および watch デバイス]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)の使用方法の詳細については、 **DeviceWatcher**します。</span><span class="sxs-lookup"><span data-stu-id="386b6-175">See [Enumerate and watch devices]( https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices) for more details on the use of a **DeviceWatcher**.</span></span>

## <a name="see-also"></a><span data-ttu-id="386b6-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="386b6-176">See also</span></span>
* [<span data-ttu-id="386b6-177">Point of Service の概要</span><span class="sxs-lookup"><span data-stu-id="386b6-177">Getting started with Point of Service</span></span>](pos-basics.md)
* [<span data-ttu-id="386b6-178">DeviceInformation クラス</span><span class="sxs-lookup"><span data-stu-id="386b6-178">DeviceInformation Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation)
* [<span data-ttu-id="386b6-179">PosPrinter クラス</span><span class="sxs-lookup"><span data-stu-id="386b6-179">PosPrinter Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posprinter)
* [<span data-ttu-id="386b6-180">PosConnectionTypes 列挙型</span><span class="sxs-lookup"><span data-stu-id="386b6-180">PosConnectionTypes Enum</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.posconnectiontypes)
* [<span data-ttu-id="386b6-181">BarcodeScanner クラス</span><span class="sxs-lookup"><span data-stu-id="386b6-181">BarcodeScanner Class</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner)
* [<span data-ttu-id="386b6-182">DeviceWatcher クラス</span><span class="sxs-lookup"><span data-stu-id="386b6-182">DeviceWatcher Class</span></span>](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)

[!INCLUDE [feedback](./includes/pos-feedback.md)]