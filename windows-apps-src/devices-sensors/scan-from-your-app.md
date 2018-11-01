---
author: PatrickFarley
ms.assetid: 374D1983-60E0-4E18-ABBB-04775BAA0F0D
title: アプリからスキャンする
description: フラットベッド、フィーダー、自動構成の各スキャン ソースを使ってアプリからコンテンツをスキャンする方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f9128056cbb3b9218d164b243948d9dd16af0786
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5924391"
---
# <a name="scan-from-your-app"></a><span data-ttu-id="7a1b4-104">アプリからスキャンする</span><span class="sxs-lookup"><span data-stu-id="7a1b4-104">Scan from your app</span></span>


**<span data-ttu-id="7a1b4-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="7a1b4-105">Important APIs</span></span>**

-   [**<span data-ttu-id="7a1b4-106">Windows.Devices.Scanners</span><span class="sxs-lookup"><span data-stu-id="7a1b4-106">Windows.Devices.Scanners</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn264250)
-   [**<span data-ttu-id="7a1b4-107">DeviceInformation</span><span class="sxs-lookup"><span data-stu-id="7a1b4-107">DeviceInformation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225393)
-   [**<span data-ttu-id="7a1b4-108">DeviceClass</span><span class="sxs-lookup"><span data-stu-id="7a1b4-108">DeviceClass</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR225381)

<span data-ttu-id="7a1b4-109">フラットベッド、フィーダー、自動構成の各スキャン ソースを使ってアプリからコンテンツをスキャンする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-109">Learn here how to scan content from your app by using a flatbed, feeder, or auto-configured scan source.</span></span>

<span data-ttu-id="7a1b4-110">**重要な** [**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) Api は、デスクトップ[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/Dn894631)の一部です。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-110">**Important**The [**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) APIs are part of the desktop [device family](https://msdn.microsoft.com/library/windows/apps/Dn894631).</span></span> <span data-ttu-id="7a1b4-111">アプリでは、windows 10 のデスクトップ バージョンでのみこれらの Api を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-111">Apps can use these APIs only on the desktop version of Windows10.</span></span>

<span data-ttu-id="7a1b4-112">アプリからスキャンを実行するにはまず、新しい [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを宣言し、[**DeviceClass**](https://msdn.microsoft.com/library/windows/apps/BR225381) 型を取得することによって、利用できるスキャナーをリストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-112">To scan from your app, you must first list the available scanners by declaring a new [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) object and getting the [**DeviceClass**](https://msdn.microsoft.com/library/windows/apps/BR225381) type.</span></span> <span data-ttu-id="7a1b4-113">WIA ドライバーと共にインストールされているローカルのスキャナーのみがリストされ、アプリから利用することができます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-113">Only scanners that are installed locally with WIA drivers are listed and available to your app.</span></span>

<span data-ttu-id="7a1b4-114">利用できるスキャナーをリストしたら、スキャナーの種類に基づく自動構成のスキャン設定を使うか、フラットベッドとフィーダーのいずれかのスキャン ソースを使ってスキャンのみを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-114">After your app has listed available scanners, it can use the auto-configured scan settings based on the scanner type, or just scan using the available flatbed or feeder scan source.</span></span> <span data-ttu-id="7a1b4-115">自動構成設定を使うには、スキャナーが自動構成に対応し、なおかつ、フラットベッドとフィーダーのどちらか一方のみを備えたスキャナーであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-115">To use auto-configured settings, the scanner must be enabled for auto-configuration must not be equipped with both a flatbed and a feeder scanner.</span></span> <span data-ttu-id="7a1b4-116">詳細については、[自動構成スキャン](https://msdn.microsoft.com/library/windows/hardware/Ff539393)に関するページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-116">For more info, see [Auto-Configured Scanning](https://msdn.microsoft.com/library/windows/hardware/Ff539393).</span></span>

## <a name="enumerate-available-scanners"></a><span data-ttu-id="7a1b4-117">利用できるスキャナーを列挙する</span><span class="sxs-lookup"><span data-stu-id="7a1b4-117">Enumerate available scanners</span></span>

<span data-ttu-id="7a1b4-118">Windows はスキャナーを自動的には検出しません。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-118">Windows does not detect scanners automatically.</span></span> <span data-ttu-id="7a1b4-119">アプリがスキャナーと通信するためには、次の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-119">You must perform this step in order for your app to communicate with the scanner.</span></span> <span data-ttu-id="7a1b4-120">この例では、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) 名前空間を使ってスキャナー デバイスの列挙処理を実行しています。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-120">In this example, the scanner device enumeration is done using the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) namespace.</span></span>

1.  <span data-ttu-id="7a1b4-121">まず、クラス定義ファイルに次の using ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-121">First, add these using statements to your class definition file.</span></span>

``` csharp
    using Windows.Devices.Enumeration;
    using Windows.Devices.Scanners;
```

2.  <span data-ttu-id="7a1b4-122">次に、スキャナーの列挙処理を開始するためのデバイス ウォッチャーを実装します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-122">Next, implement a device watcher to start enumerating scanners.</span></span> <span data-ttu-id="7a1b4-123">詳しくは、「[デバイスの列挙](enumerate-devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-123">For more info, see [Enumerate devices](enumerate-devices.md).</span></span>

```csharp
    void InitDeviceWatcher()
    {
       // Create a Device Watcher class for type Image Scanner for enumerating scanners
       scannerWatcher = DeviceInformation.CreateWatcher(DeviceClass.ImageScanner);

       scannerWatcher.Added += OnScannerAdded;
       scannerWatcher.Removed += OnScannerRemoved;
       scannerWatcher.EnumerationCompleted += OnScannerEnumerationComplete;
    }
```

3.  <span data-ttu-id="7a1b4-124">スキャナーが追加されたタイミングで実行されるイベント ハンドラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-124">Create an event handler for when a scanner is added.</span></span>

```csharp
    private async void OnScannerAdded(DeviceWatcher sender,  DeviceInformation deviceInfo)
    {
       await
       MainPage.Current.Dispatcher.RunAsync(
             Windows.UI.Core.CoreDispatcherPriority.Normal,
             () =>
             {
                MainPage.Current.NotifyUser(String.Format("Scanner with device id {0} has been added", deviceInfo.Id), NotifyType.StatusMessage);

                // search the device list for a device with a matching device id
                ScannerDataItem match = FindInList(deviceInfo.Id);

                // If we found a match then mark it as verified and return
                if (match != null)
                {
                   match.Matched = true;
                   return;
                }

                // Add the new element to the end of the list of devices
                AppendToList(deviceInfo);
             }
       );
    }
```

## <a name="scan"></a><span data-ttu-id="7a1b4-125">スキャン</span><span class="sxs-lookup"><span data-stu-id="7a1b4-125">Scan</span></span>

1.  **<span data-ttu-id="7a1b4-126">ImageScanner オブジェクトを取得する</span><span class="sxs-lookup"><span data-stu-id="7a1b4-126">Get an ImageScanner object</span></span>**

<span data-ttu-id="7a1b4-127">[**ImageScannerScanSource**](https://msdn.microsoft.com/library/windows/apps/Dn264238) 列挙型の各メンバーに対しては、**Default**、**AutoConfigured**、**Flatbed**、**Feeder** のいずれであれ、最初に [**ImageScanner.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.scanners.imagescanner.fromidasync) メソッドを呼び出して [**ImageScanner**](https://msdn.microsoft.com/library/windows/apps/Dn263806) オブジェクトを作成する必要があります。その例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-127">For each [**ImageScannerScanSource**](https://msdn.microsoft.com/library/windows/apps/Dn264238) enumeration type, whether it's **Default**, **AutoConfigured**, **Flatbed**, or **Feeder**, you must first create an [**ImageScanner**](https://msdn.microsoft.com/library/windows/apps/Dn263806) object by calling the [**ImageScanner.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.scanners.imagescanner.fromidasync) method, like this.</span></span>

 ```csharp
    ImageScanner myScanner = await ImageScanner.FromIdAsync(deviceId);
 ```

2.  **<span data-ttu-id="7a1b4-128">スキャンのみ</span><span class="sxs-lookup"><span data-stu-id="7a1b4-128">Just scan</span></span>**

<span data-ttu-id="7a1b4-129">既定の設定でスキャンを行う場合、アプリは、[**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) 名前空間を使ってスキャナーを選び、そのソースからスキャンを実行します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-129">To scan with the default settings, your app relies on the [**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) namespace to select a scanner and scans from that source.</span></span> <span data-ttu-id="7a1b4-130">スキャンの設定は変更されません。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-130">No scan settings are changed.</span></span> <span data-ttu-id="7a1b4-131">この場合、自動構成、フラットベッド、フィーダーのいずれかのスキャナーが選ばれます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-131">The possible scanners are auto-configure, flatbed, or feeder.</span></span> <span data-ttu-id="7a1b4-132">このタイプのスキャンは、意図しないソースからスキャンが実行されたとしても (意図したフィーダーではなくフラットベッドからスキャンされるなど) スキャン操作が正常に実行される可能性は最も高くなります。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-132">This type of scan will most likely produce a successful scan operation, even if it scans from the wrong source, like flatbed instead of feeder.</span></span>

<span data-ttu-id="7a1b4-133">**注:** フィーダーでスキャンするドキュメントを配置して、ユーザー場合と、スキャナーが代わりに、フラット ベッドからスキャンされます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-133">**Note**If the user places the document to scan in the feeder, the scanner will scan from the flatbed instead.</span></span> <span data-ttu-id="7a1b4-134">空のフィーダーからスキャンを実行した場合、スキャン ジョブからは一切、スキャンしたファイルが生成されません。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-134">If the user tries to scan from an empty feeder, the scan job won't produce any scanned files.</span></span>
 
```csharp
    var result = await myScanner.ScanFilesToFolderAsync(ImageScannerScanSource.Default,
        folder).AsTask(cancellationToken.Token, progress);
```

3.  **<span data-ttu-id="7a1b4-135">自動構成、フラットベッド、フィーダーのいずれかのソースからスキャンする</span><span class="sxs-lookup"><span data-stu-id="7a1b4-135">Scan from Auto-configured, Flatbed, or Feeder source</span></span>**

<span data-ttu-id="7a1b4-136">デバイスの[自動構成スキャン](https://msdn.microsoft.com/library/windows/hardware/Ff539393)を使うと、最適なスキャン設定でスキャンを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-136">Your app can use the device's [Auto-Configured Scanning](https://msdn.microsoft.com/library/windows/hardware/Ff539393) to scan with the most optimal scan settings.</span></span> <span data-ttu-id="7a1b4-137">このオプションでは、スキャン対象のコンテンツに応じた最適なスキャン設定 (カラー モード、スキャン解像度など) をデバイスが自動的に判断します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-137">With this option, the device itself can determine the best scan settings, like color mode and scan resolution, based on the content being scanned.</span></span> <span data-ttu-id="7a1b4-138">スキャン設定は、新しいスキャン ジョブの実行時にその都度選択されます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-138">The device selects the scan settings at run time for each new scan job.</span></span>

<span data-ttu-id="7a1b4-139">**注:**、アプリでこの設定を使用する前に、スキャナーがこの機能をサポートしているかを確認する必要がありますので、すべてのスキャナーがこの機能をサポートします。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-139">**Note**Not all scanners support this feature, so the app must check if the scanner supports this feature before using this setting.</span></span>

<span data-ttu-id="7a1b4-140">この例では、スキャナーが自動構成に対応しているかどうかをアプリがまずチェックしたうえで、スキャンを実行しています。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-140">In this example, the app first checks if the scanner is capable of auto-configuration and then scans.</span></span> <span data-ttu-id="7a1b4-141">フラットベッド スキャナーまたはフィーダー スキャナーを指定する場合は、単に **AutoConfigured** を **Flatbed** または **Feeder** に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-141">To specify either flatbed or feeder scanner, simply replace **AutoConfigured** with **Flatbed** or **Feeder**.</span></span>

```csharp
    if (myScanner.IsScanSourceSupported(ImageScannerScanSource.AutoConfigured))
    {
        ...
        // Scan API call to start scanning with Auto-Configured settings.
        var result = await myScanner.ScanFilesToFolderAsync(
            ImageScannerScanSource.AutoConfigured, folder).AsTask(cancellationToken.Token, progress);
        ...
    }
```

## <a name="preview-the-scan"></a><span data-ttu-id="7a1b4-142">スキャンをプレビューする</span><span class="sxs-lookup"><span data-stu-id="7a1b4-142">Preview the scan</span></span>

<span data-ttu-id="7a1b4-143">フォルダーに格納する前にスキャン結果をプレビューするコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-143">You can add code to preview the scan before scanning to a folder.</span></span> <span data-ttu-id="7a1b4-144">以下の例では、**Flatbed** スキャナーがプレビューをサポートしているかどうかをアプリでチェックした後、スキャン結果をプレビューしています。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-144">In the example below, the app checks if the **Flatbed** scanner supports preview, then previews the scan.</span></span>

```csharp
if (myScanner.IsPreviewSupported(ImageScannerScanSource.Flatbed))
{
    rootPage.NotifyUser("Scanning", NotifyType.StatusMessage);
                // Scan API call to get preview from the flatbed.
                var result = await myScanner.ScanPreviewToStreamAsync(
                    ImageScannerScanSource.Flatbed, stream);
```

## <a name="cancel-the-scan"></a><span data-ttu-id="7a1b4-145">スキャンを取り消す</span><span class="sxs-lookup"><span data-stu-id="7a1b4-145">Cancel the scan</span></span>

<span data-ttu-id="7a1b4-146">スキャンの途中でユーザーがスキャン ジョブを取り消すことができるようにする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-146">You can let users cancel the scan job midway through a scan, like this.</span></span>

```csharp
void CancelScanning()
{
    if (ModelDataContext.ScenarioRunning)
    {
        if (cancellationToken != null)
        {
            cancellationToken.Cancel();
        }                
        DisplayImage.Source = null;
        ModelDataContext.ScenarioRunning = false;
        ModelDataContext.ClearFileList();
    }
}
```

## <a name="scan-with-progress"></a><span data-ttu-id="7a1b4-147">スキャンの進行状況を表示する</span><span class="sxs-lookup"><span data-stu-id="7a1b4-147">Scan with progress</span></span>

1.  <span data-ttu-id="7a1b4-148">**System.Threading.CancellationTokenSource** オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-148">Create a **System.Threading.CancellationTokenSource** object.</span></span>

```csharp
cancellationToken = new CancellationTokenSource();
```

2.  <span data-ttu-id="7a1b4-149">進行状況のイベント ハンドラーを設定してスキャンの進行状況を取得します。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-149">Set up the progress event handler and get the progress of the scan.</span></span>

```csharp
    rootPage.NotifyUser("Scanning", NotifyType.StatusMessage);
    var progress = new Progress<UInt32>(ScanProgress);
```

## <a name="scanning-to-the-pictures-library"></a><span data-ttu-id="7a1b4-150">画像ライブラリにスキャンする</span><span class="sxs-lookup"><span data-stu-id="7a1b4-150">Scanning to the pictures library</span></span>

<span data-ttu-id="7a1b4-151">[**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/BR207881) クラスを使うことで、ユーザーは任意のフォルダーにスキャン結果を動的に格納することができます。ただし、画像ライブラリ フォルダーにスキャン結果を格納できるようにするには、*画像ライブラリ*の機能をマニフェストで宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-151">Users can scan to any folder dynamically using the [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/BR207881) class, but you must declare the *Pictures Library* capability in the manifest to allow users to scan to that folder.</span></span> <span data-ttu-id="7a1b4-152">アプリの機能の詳細については、「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/Mt270968)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7a1b4-152">For more info on app capabilities, see [App capability declarations](https://msdn.microsoft.com/library/windows/apps/Mt270968).</span></span>
