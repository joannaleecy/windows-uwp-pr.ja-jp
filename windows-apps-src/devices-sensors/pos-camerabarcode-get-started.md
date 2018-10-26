---
author: TerryWarwick
title: カメラ バーコード スキャナーの概要
description: カメラ バーコード スキャナーの使用方法について説明します。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 12aabff66fc116f510dced78aa56f3df5f84c850
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5596637"
---
# <a name="getting-started-with-a-camera-barcode-scanner"></a><span data-ttu-id="10281-104">カメラ バーコード スキャナーの概要</span><span class="sxs-lookup"><span data-stu-id="10281-104">Getting started with a camera barcode scanner</span></span>
## <a name="step-1-add-capability-declarations-to-your-app-manifest"></a><span data-ttu-id="10281-105">手順 1: アプリ マニフェストに機能宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="10281-105">Step 1: Add capability declarations to your app manifest</span></span>
1. <span data-ttu-id="10281-106">Microsoft Visual Studio の**ソリューション エクスプローラー**で、**package.appxmanifest** 項目をダブルクリックしてアプリケーション マニフェストのデザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="10281-106">In Microsoft Visual Studio, in **Solution Explorer**, open the designer for the application manifest by double-clicking the **package.appxmanifest** item.</span></span>
2. <span data-ttu-id="10281-107">**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="10281-107">Select the **Capabilities** tab</span></span>
3. <span data-ttu-id="10281-108">**[Web カメラ]** と **[PointOfService]** のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="10281-108">Check the boxes for **Webcam** and **PointOfService**</span></span> 

>[!NOTE] 
> <span data-ttu-id="10281-109">**Web カメラ**機能は、アプリケーションからプレビューを表示するだけでなく、ソフトウェア デコーダーでカメラからデコードするフレームを受信するためにも必要です。</span><span class="sxs-lookup"><span data-stu-id="10281-109">The **Webcam** capability is required to for the software decoder to receive frames from the camera to decode as well as to provide a preview from your application</span></span>

## <a name="step-2-add-using-directives"></a><span data-ttu-id="10281-110">手順 2: using ディレクティブを追加する</span><span class="sxs-lookup"><span data-stu-id="10281-110">Step 2: Add using directives</span></span>

```Csharp
using Windows.Devices.Enumeration;
using Windows.Devices.PointOfService;
```
## <a name="step-3-define-your-device-selector"></a><span data-ttu-id="10281-111">手順 3: デバイス セレクターを定義する</span><span class="sxs-lookup"><span data-stu-id="10281-111">Step 3: Define your device selector</span></span>

### **<a name="option-a-find-all-barcode-scanners"></a><span data-ttu-id="10281-112">オプション A: すべてのバーコード スキャナーを検索する</span><span class="sxs-lookup"><span data-stu-id="10281-112">Option A: Find all barcode scanners</span></span>**

```Csharp
string selector = BarcodeScanner.GetDeviceSelector();       
```

### **<a name="option-b-scoping-device-selector-to-connection-type"></a><span data-ttu-id="10281-113">オプション B: デバイス セレクターで接続の種類を制限する</span><span class="sxs-lookup"><span data-stu-id="10281-113">Option B: Scoping device selector to connection type</span></span>**

```Csharp
string selector = BarcodeScanner.GetDeviceSelector(PosConnectionTypes.Local);
DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);
```

## <a name="step-4-enumerate-barcode-scanners"></a><span data-ttu-id="10281-114">手順 4: バーコード スキャナーを列挙する</span><span class="sxs-lookup"><span data-stu-id="10281-114">Step 4: Enumerate barcode scanners</span></span>
<span data-ttu-id="10281-115">アプリケーションの有効期間においてデバイスのリストが変化することを想定しない場合は、*FindAllAsync* を使用して、1 回だけスナップショットを列挙することができますが、アプリケーションの有効期間においてバーコード スキャナーのリストが変化する可能性がある場合は、代わりに *DeviceWatcher* を使用します。</span><span class="sxs-lookup"><span data-stu-id="10281-115">If you do not expect the list of devices to change over the lifespan of your application you can enumerate a snapshot just once with *FindAllAsync*, but if you believe that the list of barcode scanners could change over the lifespan of your application you should use a *DeviceWatcher* instead.</span></span>  

> [!Important] 
> <span data-ttu-id="10281-116">GetDefaultAsync を使用して PointOfService デバイスを列挙すると、結果の動作が一貫しない可能性があります。GetDefaultAsync は、クラスで見つかった最初のデバイスを返すだけであり、このデバイスはセッションによって変化する可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="10281-116">Using GetDefaultAsync to enumerate PointOfService devices can result in inconsistent behavior as it simply returns the first device found in the class and this can change from session to session.</span></span>

### **<a name="option-a-enumerate-a-snapshot-of-barcode-scanners"></a><span data-ttu-id="10281-117">オプション A: バーコード スキャナーのスナップショットを列挙する</span><span class="sxs-lookup"><span data-stu-id="10281-117">Option A: Enumerate a snapshot of barcode scanners</span></span>**
```Csharp
DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);
```

> [!TIP]
> <span data-ttu-id="10281-118">*FindAllAsync* の使用方法の詳細については、「[*デバイスのスナップショットの列挙*](https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-a-snapshot-of-devices)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="10281-118">See [*Enumerate a snapshot of devices*](https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-a-snapshot-of-devices) for more information on using *FindAllAsync*.</span></span>

### **<a name="option-b-enumerate-and-watch-for-changes-in-available-barcode-scanners"></a><span data-ttu-id="10281-119">オプション B: 利用可能なバーコード スキャナーを列挙し、その変更を監視する</span><span class="sxs-lookup"><span data-stu-id="10281-119">Option B: Enumerate and watch for changes in available barcode scanners</span></span>**
```Csharp
DeviceWatcher deviceWatcher = DeviceInformation.CreateWatcher(selector);

// TODO: Add Event Listeners and Handlers
```
> [!TIP]
> <span data-ttu-id="10281-120">詳細については、「[*デバイスの列挙と監視*](https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices)」と「[*DeviceWatcher*](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="10281-120">See [*Enumerate and watch device changes*](https://docs.microsoft.com/windows/uwp/devices-sensors/enumerate-devices#enumerate-and-watch-devices) and [*DeviceWatcher*](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceWatcher) for more information.</span></span>

## <a name="step-5-identify-camera-barcode-scanners"></a><span data-ttu-id="10281-121">手順 5: カメラ バーコード スキャナーの識別</span><span class="sxs-lookup"><span data-stu-id="10281-121">Step 5: Identify camera barcode scanners</span></span>
<span data-ttu-id="10281-122">カメラ バーコード スキャナーは、Windows によって、コンピューターに接続されているカメラとソフトウェア デコーダーがペアリングされたときに動的に作成されます。</span><span class="sxs-lookup"><span data-stu-id="10281-122">A camera barcode scanner is created dynamically as Windows pairs the camera(s) attached to your computer with a software decoder.</span></span>  <span data-ttu-id="10281-123">カメラとデコーダーのペアはそれぞれ完全な機能を持つバーコード スキャナーです。</span><span class="sxs-lookup"><span data-stu-id="10281-123">Each camera - decoder pair is a fully functional barcode scanner.</span></span>

<span data-ttu-id="10281-124">結果として得られるデバイス コレクションの各バーコード スキャナーについて、[*BarcodeScanner.VideoDeviceID*](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.videodeviceid#Windows_Devices_PointOfService_BarcodeScanner_VideoDeviceId) プロパティを確認することによって、カメラ バーコード スキャナーと物理バーコード スキャナーを区別することができます。</span><span class="sxs-lookup"><span data-stu-id="10281-124">For each barcode scanner in the resulting device collection, you can determine which are camera barcode scanners verses physical barcode scanners by checking the [*BarcodeScanner.VideoDeviceID*](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.videodeviceid#Windows_Devices_PointOfService_BarcodeScanner_VideoDeviceId) property.</span></span>  <span data-ttu-id="10281-125">VideoDeviceID が NULL 以外である場合は、デバイス コレクションのバーコード スキャナー オブジェクトがカメラ バーコード スキャナーであることを示します。</span><span class="sxs-lookup"><span data-stu-id="10281-125">A non-NULL VideoDeviceID will indicate that the barcode scanner object from your device collection is a camera barcode scanner.</span></span>  <span data-ttu-id="10281-126">複数のカメラ バーコード スキャナーがある場合は、物理バーコード スキャナーを含まない別のコレクションを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="10281-126">If you have more than one camera barcode scanner you may want to build a separate collection which excludes physical barcode scanners.</span></span> 

<span data-ttu-id="10281-127">Windows に付属しているデコーダーを使用するカメラ バーコード スキャナーは、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="10281-127">Camera barcode scanners using the decoder that ships with Windows will appear as:</span></span> 

> <span data-ttu-id="10281-128">Microsoft BarcodeScanner (*使用しているカメラの名前*)</span><span class="sxs-lookup"><span data-stu-id="10281-128">Microsoft BarcodeScanner (*name of your camera here*)</span></span>

<span data-ttu-id="10281-129">カメラがコンピューターのシャーシに組み込まれており、複数のカメラがある場合、名前は*前面*と*背面*で区別されます。</span><span class="sxs-lookup"><span data-stu-id="10281-129">If your camera is built in to the chassis of your computer, the name may differentiate between *front* and *rear* if you have more than one camera.</span></span>  <span data-ttu-id="10281-130">今後、新しいソフトウェア デコーダーが利用可能になり、別の命名規則が適用される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="10281-130">In the future, additional software decoders may be available and carry a different naming scheme.</span></span>

## <a name="step-6-claim-the-camera-barcode-scanner"></a><span data-ttu-id="10281-131">手順 6: カメラ バーコード スキャナーを要求する</span><span class="sxs-lookup"><span data-stu-id="10281-131">Step 6: Claim the camera barcode scanner</span></span> 
<span data-ttu-id="10281-132">[BarcodeScanner.ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync) を使用して、カメラ バーコード スキャナーの排他的使用を取得します。</span><span class="sxs-lookup"><span data-stu-id="10281-132">Use [BarcodeScanner.ClaimScannerAsync](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.claimscannerasync#Windows_Devices_PointOfService_BarcodeScanner_ClaimScannerAsync) to obtain exclusive use of the camera barcode scanner.</span></span>

## <a name="step-7-system-provided-preview"></a><span data-ttu-id="10281-133">手順 7: システムが提供するプレビュー</span><span class="sxs-lookup"><span data-stu-id="10281-133">Step 7: System provided preview</span></span>
<span data-ttu-id="10281-134">ユーザーがカメラを正しくバーコードに向けるには、カメラ プレビューが必要です。</span><span class="sxs-lookup"><span data-stu-id="10281-134">A camera preview is needed for the user to successfully aim the camera at barcodes.</span></span>  <span data-ttu-id="10281-135">Windows には、カメラ バーコード スキャナーの基本的なコントロールを提供するためのダイアログを起動するシンプルなカメラ プレビューが用意されています。</span><span class="sxs-lookup"><span data-stu-id="10281-135">Windows provides a simple camera preview that will launch a dialog that enables basic control of the camera barcode scanner.</span></span>  <span data-ttu-id="10281-136">ダイアログを開くときは [ClaimedBarcodeScanner.ShowVideoPreview](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.showvideopreviewasync) を呼び出し、作業が終わってダイアログを閉じるときは [ClaimedBarcodeScanner.HideVideoPreview](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.hidevideopreview) を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="10281-136">Simply call [ClaimedBarcodeScanner.ShowVideoPreview](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.showvideopreviewasync) to open the dialog and [ClaimedBarcodeScanner.HideVideoPreview](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.hidevideopreview) to close it when finished.</span></span>

> [!TIP]
> <span data-ttu-id="10281-137">アプリケーションでカメラ バーコード スキャナーのプレビューをホストする方法については、「[プレビューのホスト](pos-camerabarcode-hosting-preview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="10281-137">See [Hosting Preview](pos-camerabarcode-hosting-preview.md) to host the preview for camera barcode scanner in your application.</span></span>

## <a name="step-8-initiate-scan"></a><span data-ttu-id="10281-138">手順 8: 開始スキャン</span><span class="sxs-lookup"><span data-stu-id="10281-138">Step 8: Initiate scan</span></span> 
<span data-ttu-id="10281-139">[**StartSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync) を呼び出すことでスキャン プロセスを開始できます。</span><span class="sxs-lookup"><span data-stu-id="10281-139">You can initiate the scan process by calling [**StartSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.startsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StartSoftwareTriggerAsync).</span></span>  
<span data-ttu-id="10281-140">[**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) の値に応じて、スキャナーはバーコードを 1 つだけスキャンして停止することも、[**StopSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync) を呼び出すまで継続的にスキャンすることもできます。</span><span class="sxs-lookup"><span data-stu-id="10281-140">Depending on the value of [**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) the scanner may scan only one barcode then stop or scan continuously until you call [**StopSoftwareTriggerAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.stopsoftwaretriggerasync#Windows_Devices_PointOfService_ClaimedBarcodeScanner_StopSoftwareTriggerAsync).</span></span>

<span data-ttu-id="10281-141">[**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) を目的の値に設定することで、バーコードがデコードされたときのスキャナー動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="10281-141">Set the desired value of [**IsDisabledOnDataReceived**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner.isdisabledondatareceived#Windows_Devices_PointOfService_ClaimedBarcodeScanner_IsDisabledOnDataReceived) to control the scanner behavior when a barcode is decoded.</span></span>

| <span data-ttu-id="10281-142">値</span><span class="sxs-lookup"><span data-stu-id="10281-142">Value</span></span> | <span data-ttu-id="10281-143">説明</span><span class="sxs-lookup"><span data-stu-id="10281-143">Description</span></span> |
| ----- | ----------- |
| <span data-ttu-id="10281-144">True</span><span class="sxs-lookup"><span data-stu-id="10281-144">True</span></span>   | <span data-ttu-id="10281-145">バーコードを 1 つだけスキャンして停止する</span><span class="sxs-lookup"><span data-stu-id="10281-145">Scan only one barcode then stop</span></span> |
| <span data-ttu-id="10281-146">False</span><span class="sxs-lookup"><span data-stu-id="10281-146">False</span></span>  | <span data-ttu-id="10281-147">停止せずに継続的にバーコードをスキャンする</span><span class="sxs-lookup"><span data-stu-id="10281-147">Continuously scan barcodes without stopping</span></span> |