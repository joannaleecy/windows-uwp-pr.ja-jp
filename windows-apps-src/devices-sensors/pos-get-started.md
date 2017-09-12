---
author: muhsinking
title: "POS (店舗販売時点管理) の概要"
description: "この記事には、POS (店舗販売時点管理) UWP API の概要に関する情報が含まれています。"
ms.author: mukin
ms.date: 08/2/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 店舗販売時点管理, POS"
ms.openlocfilehash: 9fb23d1b52938a364c7ad8dd2b01b3dade9046e1
ms.sourcegitcommit: 968187e803a866b60cda0528718a3d31f07dc54c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/03/2017
---
# <a name="getting-started-with-point-of-service"></a><span data-ttu-id="6af22-104">POS (店舗販売時点管理) の概要</span><span class="sxs-lookup"><span data-stu-id="6af22-104">Getting started with point of service</span></span>

<span data-ttu-id="6af22-105">店舗販売時点管理デバイス、販売時点管理デバイス、または POS デバイスとは、小売トランザクションを進めやすくするために使われるコンピューター周辺機器です。</span><span class="sxs-lookup"><span data-stu-id="6af22-105">Point of service, point of sale, or POS devices are computer peripherals used to facilitate retail transactions.</span></span> <span data-ttu-id="6af22-106">POS デバイスの例として、電子レジスター、バーコード スキャナー、磁気ストライプ リーダー、レシート プリンターなどがあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-106">Examples of POS devices include electronic cash registers, barcode scanners, magnetic stripe readers, and receipt printers.</span></span>

<span data-ttu-id="6af22-107">ここでは、ユニバーサル Windows プラットフォーム (UWP) POS API を使った POS デバイスとのやり取りの基本について説明します。</span><span class="sxs-lookup"><span data-stu-id="6af22-107">Here you’ll learn the basics of interfacing with POS devices by using the Universal Windows Platform (UWP) POS APIs.</span></span> <span data-ttu-id="6af22-108">ここで取り上げる内容には、デバイスの列挙、デバイス機能の確認、デバイスの要求、デバイスの共有が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6af22-108">We’ll cover device enumeration, checking device capabilities, claiming devices, and device sharing.</span></span> <span data-ttu-id="6af22-109">例としてバーコード スキャナーを使いますが、ここで説明するガイダンスのほとんどは、あらゆる UWP 互換 POS デバイスに適用されます </span><span class="sxs-lookup"><span data-stu-id="6af22-109">We use a barcode scanner device as an example, but almost all the guidance here applies to any UWP-compatible POS device.</span></span> <span data-ttu-id="6af22-110">(サポートされているデバイスの一覧については、「[POS デバイスのサポート](pos-device-support.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="6af22-110">(For a list of supported devices, see [POS Device Support](pos-device-support.md)).</span></span>

## <a name="finding-and-connecting-to-pos-peripherals"></a><span data-ttu-id="6af22-111">POS 周辺機器の検出と接続</span><span class="sxs-lookup"><span data-stu-id="6af22-111">Finding and connecting to POS peripherals</span></span>

<span data-ttu-id="6af22-112">アプリから POS デバイスを使用するには、アプリが実行されている PC とデバイスを事前にペアリングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-112">Before a POS device can be used by an app, it must be paired with the PC where the app is running.</span></span> <span data-ttu-id="6af22-113">POS デバイスに接続する方法はいくつかあり、プログラムによって接続するか、設定アプリを使います。</span><span class="sxs-lookup"><span data-stu-id="6af22-113">There are several ways to connect to POS devices, either programmatically or through the Settings app.</span></span>

### <a name="connecting-to-devices-by-using-the-settings-app"></a><span data-ttu-id="6af22-114">設定アプリを使ってデバイスに接続する</span><span class="sxs-lookup"><span data-stu-id="6af22-114">Connecting to devices by using the Settings app</span></span>
<span data-ttu-id="6af22-115">バーコード スキャナーなどの POS デバイスを PC に接続すると、他のデバイスと同じように表示されます。</span><span class="sxs-lookup"><span data-stu-id="6af22-115">When you plug a POS device like a barcode scanner into a PC, it shows up just like any other device.</span></span> <span data-ttu-id="6af22-116">デバイスは、設定アプリの **[デバイス] の [Bluetooth とその他のデバイス]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="6af22-116">You can find it in the **Devices > Bluetooth & other devices** section of the Settings app.</span></span> <span data-ttu-id="6af22-117">ここで **[Bluetooth またはその他のデバイスを追加する]** を選択して、POS デバイスとペアリングできます。</span><span class="sxs-lookup"><span data-stu-id="6af22-117">There you can pair with a POS device by selecting **Add Bluetooth or other device**.</span></span>

<span data-ttu-id="6af22-118">POS デバイスによっては、POS API を使ってプログラムから列挙されるまで設定アプリに表示されないことがあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-118">Some POS devices may not appear in the Settings app until they are programmatically enumerated by using the POS APIs.</span></span>

### <a name="getting-a-single-pos-device-with-getdefaultasync"></a><span data-ttu-id="6af22-119">GetDefaultAsync で 1 台の POS デバイスを取得する</span><span class="sxs-lookup"><span data-stu-id="6af22-119">Getting a single POS device with GetDefaultAsync</span></span>
<span data-ttu-id="6af22-120">単純な例として、アプリを実行している PC に POS デバイスが 1 台だけ接続されていて、その 1 台をできるだけすばやくセットアップしたい場合があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-120">In a simple use case, you may have just one POS peripheral connected to the PC where the app is running, and want to set it up as quickly as possible.</span></span> <span data-ttu-id="6af22-121">これを実現するには、次に示すように、**GetDefaultAsync** メソッドを使って "既定" のデバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="6af22-121">To do that, retrieve the “default” device with the **GetDefaultAsync** method as shown here.</span></span>

```Csharp
using Windows.Devices.PointOfService;

BarcodeScanner barcodeScanner = await BarcodeScanner.GetDefaultAsync();
```

<span data-ttu-id="6af22-122">既定のデバイスが見つかったら、取得されたデバイス オブジェクトを要求できます。</span><span class="sxs-lookup"><span data-stu-id="6af22-122">If the default device is found, the device object retrieved is ready to be claimed.</span></span> <span data-ttu-id="6af22-123">デバイスを "要求" すると、そのデバイスへの排他アクセスがアプリケーションに与えられるため、複数のプロセスから競合するコマンドが発行されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="6af22-123">“Claiming” a device gives an application exclusive access to it, preventing conflicting commands from multiple processes.</span></span>

> [!NOTE] 
> <span data-ttu-id="6af22-124">PC に複数の POS デバイスが接続されている場合、**GetDefaultAsync** は最初に見つかったデバイスを返します。</span><span class="sxs-lookup"><span data-stu-id="6af22-124">If more than one POS device is connected to the PC, **GetDefaultAsync** returns the first device it finds.</span></span> <span data-ttu-id="6af22-125">このため、アプリケーションから参照できる POS デバイスが 1 台だけであることが確実でなければ、**FindAllAsync** を使用してください。</span><span class="sxs-lookup"><span data-stu-id="6af22-125">For this reason, use **FindAllAsync** unless you’re sure that only one POS device is visible to the application.</span></span>

### <a name="enumerating-a-collection-of-devices-with-findallasync"></a><span data-ttu-id="6af22-126">FindAllAsync でデバイスのコレクションを列挙する</span><span class="sxs-lookup"><span data-stu-id="6af22-126">Enumerating a collection of devices with FindAllAsync</span></span>

<span data-ttu-id="6af22-127">複数のデバイスが接続されている場合は、**PointOfService** デバイス オブジェクトのコレクションを列挙して、要求するデバイスを見つける必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-127">When connected to more than one device, you must enumerate the collection of **PointOfService** device objects to find the one you want to claim.</span></span> <span data-ttu-id="6af22-128">たとば、次のコードでは、現在接続されているすべてのバーコード スキャナーのコレクションを作成し、そのコレクションから特定の名前を持つスキャナーを検索します。</span><span class="sxs-lookup"><span data-stu-id="6af22-128">For example, the following code creates a collection of all the barcode scanners currently connected, and then searches the collection for a scanner with a specific name.</span></span>

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

### <a name="scoping-the-device-selection"></a><span data-ttu-id="6af22-129">デバイスの選択スコープを設定する</span><span class="sxs-lookup"><span data-stu-id="6af22-129">Scoping the device selection</span></span>
<span data-ttu-id="6af22-130">デバイスに接続するときには、アプリがアクセスできる POS 周辺機器のサブセットに限定して検索することができます。</span><span class="sxs-lookup"><span data-stu-id="6af22-130">When connecting to a device, you may want to limit your search to a subset of POS peripherals that your app has access to.</span></span> <span data-ttu-id="6af22-131">**GetDeviceSelector** メソッドを使うと、選択スコープを設定して、特定の方法 (Bluetooth や USB など) で接続されているデバイスだけを取得できます。</span><span class="sxs-lookup"><span data-stu-id="6af22-131">Using the **GetDeviceSelector** method, you can scope the selection to retrieve devices connected only by a certain method (Bluetooth, USB, etc.).</span></span> <span data-ttu-id="6af22-132">接続の種類が **Bluetooth**、**IP**、**Local**、または **All** のデバイスを検索するセレクターを作成できます。</span><span class="sxs-lookup"><span data-stu-id="6af22-132">You can create a selector that searches for devices over **Bluetooth**, **IP**, **Local**, or **All connection types**.</span></span> <span data-ttu-id="6af22-133">ワイヤレス デバイスの検出はローカル (有線) の検出に比べて時間がかかるため、この方法が役立つことがあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-133">This can be useful, as wireless device discovery takes a long time compared to local (wired) discovery.</span></span> <span data-ttu-id="6af22-134">**FindAllAsync** で接続の種類を **Local** に限定すると、ローカル デバイス接続に対する待ち時間だけで検索を完了できます。</span><span class="sxs-lookup"><span data-stu-id="6af22-134">You can ensure a deterministic wait time for local device connection by limiting **FindAllAsync** to **Local** connection types.</span></span> <span data-ttu-id="6af22-135">たとえば、次のコードでは、ローカル接続を通じてアクセスできるすべてのバーコード スキャナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="6af22-135">For example, this code retrieves all barcode scanners accessible via a local connection.</span></span> 

```Csharp
string selector = BarcodeScanner.GetDeviceSelector(PosConnectionTypes.Local);
DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);
```

### <a name="reacting-to-device-connection-changes-with-devicewatcher"></a><span data-ttu-id="6af22-136">DeviceWatcher でデバイスの接続状態の変更に対応する</span><span class="sxs-lookup"><span data-stu-id="6af22-136">Reacting to device connection changes with DeviceWatcher</span></span>

<span data-ttu-id="6af22-137">アプリの実行中に、デバイスが切断または更新されたり、新しいデバイスを追加する必要が生じたりすることがあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-137">As your app runs, sometimes devices will be disconnected or updated, or new devices will need to be added.</span></span> <span data-ttu-id="6af22-138">**DeviceWatcher** を使うと、デバイス関連のイベントにアクセスして、アプリで適切に対応できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6af22-138">You can use the **DeviceWatcher** class to access device-related events, so your app can respond accordingly.</span></span> <span data-ttu-id="6af22-139">**DeviceWatcher** の使い方の例を次に示します。デバイスが追加、削除、または更新されると、メソッド スタブが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6af22-139">Here’s example of how to use **DeviceWatcher**, with method stubs to be called if a device is added, removed, or updated.</span></span>

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

## <a name="checking-the-capabilities-of-a-pos-device"></a><span data-ttu-id="6af22-140">POS デバイスの機能の確認</span><span class="sxs-lookup"><span data-stu-id="6af22-140">Checking the capabilities of a POS device</span></span>
<span data-ttu-id="6af22-141">デバイス クラスが同じでも (バーコード スキャナーなど)、各デバイスの属性はモデルによって大きく異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-141">Even within a device class, such as barcode scanners, the attributes of each device may vary considerably between models.</span></span> <span data-ttu-id="6af22-142">特定のデバイス機能を必要とするアプリでは、接続されている各デバイス オブジェクトを調べて、目的の属性がサポートされているかどうかを確認することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-142">If your app requires a specific device attribute, you may need to inspect each connected device object to determine whether the attribute is supported.</span></span> <span data-ttu-id="6af22-143">たとえば、ビジネスによっては、特定のバーコード印刷パターンを使ってラベルを作成する必要があることがあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-143">For example, perhaps your business requires that labels be created using a specific barcode printing pattern.</span></span> <span data-ttu-id="6af22-144">以下に、接続されているバーコード スキャナーが特定のシンボル体系をサポートしているかどうかを確認する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6af22-144">Here’s how you could check to see whether a connected barcode scanner supports a particular symbology.</span></span> 

> [!NOTE]
> <span data-ttu-id="6af22-145">シンボル体系とは、バーコードでメッセージをエンコードするために使われる言語マッピングです。</span><span class="sxs-lookup"><span data-stu-id="6af22-145">A symbology is the language mapping that a barcode uses to encode messages.</span></span>

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

### <a name="using-the-devicecapabilities-class"></a><span data-ttu-id="6af22-146">Device.Capabilities クラスを使用する</span><span class="sxs-lookup"><span data-stu-id="6af22-146">Using the Device.Capabilities class</span></span>
<span data-ttu-id="6af22-147">**Device.Capabilities** クラスは、すべての POS デバイス クラスが持つ属性の 1 つであり、各デバイスに関する一般的な情報を取得するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="6af22-147">The **Device.Capabilities** class is an attribute of all POS device classes and can be used to get general information about each device.</span></span> <span data-ttu-id="6af22-148">次の例では、デバイスで統計レポートがサポートされているかどうかを確認し、サポートされているすべての種類の統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="6af22-148">For example, this example determines whether a device supports statistics reporting and, if it does, retrieves statistics for any types supported.</span></span>

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

## <a name="claiming-a-pos-device"></a><span data-ttu-id="6af22-149">POS デバイスの要求</span><span class="sxs-lookup"><span data-stu-id="6af22-149">Claiming a POS device</span></span>
<span data-ttu-id="6af22-150">POS デバイスからアクティブな入出力を利用するには、事前にデバイスを要求して、デバイス機能への排他アクセスをアプリケーションに与える必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-150">Before you can use a POS device for active input or output, you must claim it, granting the application exclusive access to many of its functions.</span></span> <span data-ttu-id="6af22-151">次のコードでは、既に説明した方法のいずれかを使ってバーコード スキャナー デバイスを検出した後、そのデバイスを要求する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6af22-151">This code shows how to claim a barcode scanner device, after you’ve found the device by using one of the methods described earlier.</span></span>

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

### <a name="retaining-the-device"></a><span data-ttu-id="6af22-152">デバイスの再起動</span><span class="sxs-lookup"><span data-stu-id="6af22-152">Retaining the device</span></span>
<span data-ttu-id="6af22-153">ネットワークまたは Bluetooth 接続経由で POS デバイスを使っているときに、デバイスをネットワーク上の他のアプリと共有したい場合があります </span><span class="sxs-lookup"><span data-stu-id="6af22-153">When using a POS device over a network or Bluetooth connection, you may wish to share the device with other apps on the network.</span></span> <span data-ttu-id="6af22-154">(これについては「デバイスの共有」[link] をご覧ください)。また、デバイスを長時間にわたって保持することが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-154">(For more info about this, see Sharing Devices[link].) In other cases, you may want to hold on to the device for prolonged use.</span></span> <span data-ttu-id="6af22-155">この例では、他のアプリからデバイスを解放するように要求されても、要求したバーコード スキャナーを保持し続ける方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6af22-155">This example shows how to retain a claimed barcode scanner after another app has requested that the device be released.</span></span>

```Csharp
claimedBarcodeScanner.ReleaseDeviceRequested += claimedBarcodeScanner_ReleaseDeviceRequested;

void claimedBarcodeScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner e)
{
    e.RetainDevice();  // Retain exclusive access to the device
}
```

## <a name="input-and-output"></a><span data-ttu-id="6af22-156">入力と出力</span><span class="sxs-lookup"><span data-stu-id="6af22-156">Input and output</span></span>

<span data-ttu-id="6af22-157">デバイスを要求したら、デバイスを使う準備はほとんど完了です。</span><span class="sxs-lookup"><span data-stu-id="6af22-157">After you’ve claimed a device, you’re almost ready to use it.</span></span> <span data-ttu-id="6af22-158">デバイスから入力を受け取るには、データを受信するデリゲートを設定して有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-158">To receive input from the device, you must set up and enable a delegate to receive data.</span></span> <span data-ttu-id="6af22-159">次の例では、バーコード スキャナー デバイスを要求し、デコード プロパティを設定します。その後、**EnableAsync** を呼び出して、デコードされたデバイス入力を有効にします。</span><span class="sxs-lookup"><span data-stu-id="6af22-159">In the example below, we claim a barcode scanner device, set its decode property, and then call **EnableAsync** to enable decoded input from the device.</span></span> <span data-ttu-id="6af22-160">このプロセスはデバイス クラスによって異なるため、バーコード デバイス以外のデリゲートを設定する方法のガイダンスについては、関連する [UWP アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples#devices-and-sensors)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6af22-160">This process varies between device classes, so for guidance about how to set up a delegate for non-barcode devices, refer to the relevant [UWP app sample](https://github.com/Microsoft/Windows-universal-samples#devices-and-sensors).</span></span>

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

## <a name="sharing-a-device-between-apps"></a><span data-ttu-id="6af22-161">アプリ間でのデバイスの共有</span><span class="sxs-lookup"><span data-stu-id="6af22-161">Sharing a device between apps</span></span>

<span data-ttu-id="6af22-162">POS デバイスは、短時間に複数のアプリからアクセスされる状況で使われることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="6af22-162">POS devices are often used in cases where more than one app will need to access them in a short period.</span></span>  <span data-ttu-id="6af22-163">デバイスが複数のアプリにローカルに (USB などの有線接続で) 接続されている場合、または Bluetooth や IP ネットワークで接続されている場合、デバイスをアプリ間で共有することができます。</span><span class="sxs-lookup"><span data-stu-id="6af22-163">A device can be shared when connected to multiple apps locally (USB or other wired connection), or through a Bluetooth or IP network.</span></span> <span data-ttu-id="6af22-164">各アプリのニーズに応じて、プロセスでデバイスの要求を解放することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="6af22-164">Depending on the needs of each app, one process may need to dispose of its claim on the device.</span></span> <span data-ttu-id="6af22-165">次のコードでは、要求したバーコード スキャナー デバイスを解放し、他のアプリが要求して使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="6af22-165">This code disposes of our claimed barcode scanner device, allowing other apps to claim and use it.</span></span>

```Csharp
if (claimedBarcodeScanner != null)
{
    claimedBarcodeScanner.Dispose();
    claimedBarcodeScanner = null;
}
```

> [!NOTE]
> <span data-ttu-id="6af22-166">POS デバイス クラスには、要求状態にかかわらず [IClosable インターフェイス](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.iclosable)が実装されています。</span><span class="sxs-lookup"><span data-stu-id="6af22-166">Both the claimed and unclaimed POS device classes implement the [IClosable interface](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.iclosable).</span></span> <span data-ttu-id="6af22-167">デバイスがネットワークまたは Bluetooth を通じてアプリに接続されている場合、要求されているオブジェクトも要求されていないオブジェクトも、解放されるまで他のアプリが接続することはできません。</span><span class="sxs-lookup"><span data-stu-id="6af22-167">If a device is connected to an app via network or bluetooth, both the claimed and unclaimed objects must disposed of before another app can connect.</span></span>

## <a name="see-also"></a><span data-ttu-id="6af22-168">関連項目</span><span class="sxs-lookup"><span data-stu-id="6af22-168">See also</span></span>
+ [<span data-ttu-id="6af22-169">バーコード スキャナーのサンプル</span><span class="sxs-lookup"><span data-stu-id="6af22-169">Barcode scanner sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [<span data-ttu-id="6af22-170">キャッシュ ドロワーのサンプル</span><span class="sxs-lookup"><span data-stu-id="6af22-170">Cash drawer sample</span></span>]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [<span data-ttu-id="6af22-171">ライン ディスプレイのサンプル</span><span class="sxs-lookup"><span data-stu-id="6af22-171">Line display sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [<span data-ttu-id="6af22-172">磁気ストライプ リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="6af22-172">Magnetic stripe reader sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [<span data-ttu-id="6af22-173">POS プリンターのサンプル</span><span class="sxs-lookup"><span data-stu-id="6af22-173">POS printer sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

