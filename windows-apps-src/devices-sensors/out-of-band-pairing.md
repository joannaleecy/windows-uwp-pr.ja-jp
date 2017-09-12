---
author: mukin
ms.assetid: E9ADC88F-BD4F-4721-8893-0E19EA94C8BA
title: "帯域外ペアリング"
description: "帯域外ペアリングを使うと、アプリは検出を行わなくても店舗販売時点管理の周辺機器に接続できます。"
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 25836204ca2942d4bbafc31e1c632c479ef3288f
ms.sourcegitcommit: ca060f051e696da2c1e26e9dd4d2da3fa030103d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/03/2017
---
# <a name="out-of-band-pairing"></a><span data-ttu-id="7ae20-104">帯域外ペアリング</span><span class="sxs-lookup"><span data-stu-id="7ae20-104">Out-of-band pairing</span></span>

<span data-ttu-id="7ae20-105">帯域外ペアリングを使うと、アプリは検出を行わなくても店舗販売時点管理の周辺機器に接続できます。</span><span class="sxs-lookup"><span data-stu-id="7ae20-105">Out-of-band pairing allows apps to connect to a Point-of-Service peripheral without requiring discovery.</span></span> <span data-ttu-id="7ae20-106">アプリは、[**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/windows.devices.pointofservice.aspx) 名前空間を使って、専用の形式に設定された文字列 (帯域外 BLOB) を、目的の周辺機器用の適切な **FromIdAsync** メソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ae20-106">Apps must use the [**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/windows.devices.pointofservice.aspx) namespace and pass in a specifically formatted string (out-of-band blob) to the appropriate **FromIdAsync** method for the desired peripheral.</span></span> <span data-ttu-id="7ae20-107">**FromIdAsync** が実行されると、ホスト デバイスが周辺機器にペアリングして接続してから、操作が呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="7ae20-107">When **FromIdAsync** is executed, the host device pairs and connects to the peripheral before the operation returns to the caller.</span></span>

## <a name="out-of-band-blob-format"></a><span data-ttu-id="7ae20-108">帯域外 BLOB の形式</span><span class="sxs-lookup"><span data-stu-id="7ae20-108">Out-of-band blob format</span></span>

```json
    "connectionKind":"Network",
    "physicalAddress":"AA:BB:CC:DD:EE:FF",
    "connectionString":"192.168.1.1:9001",
    "peripheralKinds":"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}",
    "providerId":"{02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2}",
    "providerName":"PrinterProtocolProvider.dll"
```

<span data-ttu-id="7ae20-109">**connectionKind** - 接続の種類。</span><span class="sxs-lookup"><span data-stu-id="7ae20-109">**connectionKind** - The type of connection.</span></span> <span data-ttu-id="7ae20-110">有効な値は "Network" と "Bluetooth" です。</span><span class="sxs-lookup"><span data-stu-id="7ae20-110">Valid values are "Network" and "Bluetooth".</span></span>

<span data-ttu-id="7ae20-111">**physicalAddress** - 周辺機器の MAC アドレス。</span><span class="sxs-lookup"><span data-stu-id="7ae20-111">**physicalAddress** - The MAC address of the peripheral.</span></span> <span data-ttu-id="7ae20-112">たとえば、ネットワーク プリンターの場合は、プリンターのテスト シートに AA:BB:CC:DD:EE:FF の形式で表記される MAC アドレスです。</span><span class="sxs-lookup"><span data-stu-id="7ae20-112">For example, in case of a network printer, this would be the MAC address that is provided by the printer test sheet in AA:BB:CC:DD:EE:FF format.</span></span>

<span data-ttu-id="7ae20-113">**connectionString** - 周辺機器の接続文字列。</span><span class="sxs-lookup"><span data-stu-id="7ae20-113">**connectionString** - The connection string of the peripheral.</span></span> <span data-ttu-id="7ae20-114">たとえば、ネットワーク プリンターの場合は、プリンターのテスト シートに 192.168.1.1:9001 の形式で表記される IP アドレスです。</span><span class="sxs-lookup"><span data-stu-id="7ae20-114">For example, in the case of a network printer, this would be the IP address provided by the printer test sheet in 192.168.1.1:9001 format.</span></span> <span data-ttu-id="7ae20-115">このフィールドは、すべての Bluetooth 周辺機器で省略されます。</span><span class="sxs-lookup"><span data-stu-id="7ae20-115">This field is omitted for all Bluetooth peripherals.</span></span>

<span data-ttu-id="7ae20-116">**peripheralKinds** - デバイスの種類を示す GUID。</span><span class="sxs-lookup"><span data-stu-id="7ae20-116">**peripheralKinds** - The GUID for the device type.</span></span> <span data-ttu-id="7ae20-117">有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ae20-117">Valid values are:</span></span>

| <span data-ttu-id="7ae20-118">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="7ae20-118">Device type</span></span> | <span data-ttu-id="7ae20-119">GUID</span><span class="sxs-lookup"><span data-stu-id="7ae20-119">GUID</span></span> |
| ---- | ---- |
| *<span data-ttu-id="7ae20-120">POS プリンター</span><span class="sxs-lookup"><span data-stu-id="7ae20-120">POSPrinter</span></span>* | <span data-ttu-id="7ae20-121">C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33</span><span class="sxs-lookup"><span data-stu-id="7ae20-121">C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33</span></span> |
| *<span data-ttu-id="7ae20-122">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="7ae20-122">Barcode Scanner</span></span>* | <span data-ttu-id="7ae20-123">C243FFBD-3AFC-45E9-B3D3-2BA18BC7EBC5</span><span class="sxs-lookup"><span data-stu-id="7ae20-123">C243FFBD-3AFC-45E9-B3D3-2BA18BC7EBC5</span></span> |
| *<span data-ttu-id="7ae20-124">キャッシュ ドロワー</span><span class="sxs-lookup"><span data-stu-id="7ae20-124">Cash Drawer</span></span>* | <span data-ttu-id="7ae20-125">772E18F2-8925-4229-A5AC-6453CB482FDA</span><span class="sxs-lookup"><span data-stu-id="7ae20-125">772E18F2-8925-4229-A5AC-6453CB482FDA</span></span> |


<span data-ttu-id="7ae20-126">**providerId** - プロトコル プロバイダーのクラスを示す GUID。</span><span class="sxs-lookup"><span data-stu-id="7ae20-126">**providerId** - The GUID for the protocol provider class.</span></span> <span data-ttu-id="7ae20-127">有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ae20-127">Valid values are:</span></span>

| <span data-ttu-id="7ae20-128">プロトコル プロバイダーのクラス</span><span class="sxs-lookup"><span data-stu-id="7ae20-128">Protocol provider class</span></span> | <span data-ttu-id="7ae20-129">GUID</span><span class="sxs-lookup"><span data-stu-id="7ae20-129">GUID</span></span> |
| ---- | ---- |
| *<span data-ttu-id="7ae20-130">POS プリンター: ネットワーク - Epson</span><span class="sxs-lookup"><span data-stu-id="7ae20-130">POSPrinter: Network - Epson</span></span>* | <span data-ttu-id="7ae20-131">9F0F8BE3-4E59-4520-BFBA-AF77614A31CE</span><span class="sxs-lookup"><span data-stu-id="7ae20-131">9F0F8BE3-4E59-4520-BFBA-AF77614A31CE</span></span> |
| *<span data-ttu-id="7ae20-132">POS プリンター: ネットワーク - 汎用 (ESC/POS のみ)</span><span class="sxs-lookup"><span data-stu-id="7ae20-132">POSPrinter: Network - Generic (ESC/POS only)</span></span>* | <span data-ttu-id="7ae20-133">02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2</span><span class="sxs-lookup"><span data-stu-id="7ae20-133">02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2</span></span> |
| *<span data-ttu-id="7ae20-134">POS プリンター: ネットワーク - Star Micronics</span><span class="sxs-lookup"><span data-stu-id="7ae20-134">POSPrinter: Network - Star Micronics</span></span>* | <span data-ttu-id="7ae20-135">1E3A32C2-F411-4B8C-AC91-CC2C5FD21996</span><span class="sxs-lookup"><span data-stu-id="7ae20-135">1E3A32C2-F411-4B8C-AC91-CC2C5FD21996</span></span> |
| *<span data-ttu-id="7ae20-136">POS プリンター: Bluetooth - Epson</span><span class="sxs-lookup"><span data-stu-id="7ae20-136">POSPrinter: Bluetooth - Epson</span></span>* | <span data-ttu-id="7ae20-137">94917594-544F-4AF8-B53B-EC6D9F8A4464</span><span class="sxs-lookup"><span data-stu-id="7ae20-137">94917594-544F-4AF8-B53B-EC6D9F8A4464</span></span> |
| *<span data-ttu-id="7ae20-138">POS プリンター: Bluetooth - 汎用 (ESC/POS のみ)</span><span class="sxs-lookup"><span data-stu-id="7ae20-138">POSPrinter: Bluetooth - Generic (ESC/POS only)</span></span>* | <span data-ttu-id="7ae20-139">CCD5B810-95B9-4320-BA7E-78C223CAF418</span><span class="sxs-lookup"><span data-stu-id="7ae20-139">CCD5B810-95B9-4320-BA7E-78C223CAF418</span></span> |
| *<span data-ttu-id="7ae20-140">キャッシュ ドロワー: ネットワーク - APG</span><span class="sxs-lookup"><span data-stu-id="7ae20-140">Cash Drawer: Network - APG</span></span>* | <span data-ttu-id="7ae20-141">E619E2FE-9489-4C74-BF57-70AED670B9B0</span><span class="sxs-lookup"><span data-stu-id="7ae20-141">E619E2FE-9489-4C74-BF57-70AED670B9B0</span></span> |
| *<span data-ttu-id="7ae20-142">キャッシュ ドロワー: Bluetooth - APG</span><span class="sxs-lookup"><span data-stu-id="7ae20-142">Cash Drawer: Bluetooth - APG</span></span>* | <span data-ttu-id="7ae20-143">332E6550-2E01-42EB-9401-C6A112D80185</span><span class="sxs-lookup"><span data-stu-id="7ae20-143">332E6550-2E01-42EB-9401-C6A112D80185</span></span> |
| *<span data-ttu-id="7ae20-144">バーコード スキャナー: Bluetooth (SPP-SSI)</span><span class="sxs-lookup"><span data-stu-id="7ae20-144">Barcode Scanner: Bluetooth (SPP-SSI)</span></span>* | <span data-ttu-id="7ae20-145">6E7C8178-A006-405E-85C3-084244885AD2</span><span class="sxs-lookup"><span data-stu-id="7ae20-145">6E7C8178-A006-405E-85C3-084244885AD2</span></span> |

<span data-ttu-id="7ae20-146">**providerName** - プロバイダー DLL の名前。</span><span class="sxs-lookup"><span data-stu-id="7ae20-146">**providerName** - The name of the provider DLL.</span></span> <span data-ttu-id="7ae20-147">既定のプロバイダーは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ae20-147">The default providers are:</span></span>

| <span data-ttu-id="7ae20-148">プロバイダー</span><span class="sxs-lookup"><span data-stu-id="7ae20-148">Provider</span></span> | <span data-ttu-id="7ae20-149">DLL 名</span><span class="sxs-lookup"><span data-stu-id="7ae20-149">DLL name</span></span> |
| ---- | ---- |
| <span data-ttu-id="7ae20-150">POS プリンター</span><span class="sxs-lookup"><span data-stu-id="7ae20-150">POSPrinter</span></span> | <span data-ttu-id="7ae20-151">PrinterProtocolProvider.dll</span><span class="sxs-lookup"><span data-stu-id="7ae20-151">PrinterProtocolProvider.dll</span></span> |
| <span data-ttu-id="7ae20-152">キャッシュ ドロワー</span><span class="sxs-lookup"><span data-stu-id="7ae20-152">Cash Drawer</span></span> | <span data-ttu-id="7ae20-153">CashDrawerProtocolProvider.dll</span><span class="sxs-lookup"><span data-stu-id="7ae20-153">CashDrawerProtocolProvider.dll</span></span> |
| <span data-ttu-id="7ae20-154">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="7ae20-154">Barcode Scanner</span></span> | <span data-ttu-id="7ae20-155">BarcodeScannerProtocolProvider.dll</span><span class="sxs-lookup"><span data-stu-id="7ae20-155">BarcodeScannerProtocolProvider.dll</span></span> |

## <a name="usage-example-network-posprinter"></a><span data-ttu-id="7ae20-156">使用例: ネットワーク POS プリンター</span><span class="sxs-lookup"><span data-stu-id="7ae20-156">Usage example: Network POSPrinter</span></span>

```csharp
String oobBlobNetworkPrinter =
  "{\"connectionKind\":\"Network\"," +
  "\"physicalAddress\":\"AA:BB:CC:DD:EE:FF\"," +
  "\"connectionString\":\"192.168.1.1:9001\"," +
  "\"peripheralKinds\":\"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}\"," +
  "\"providerId\":\"{02FFF12E-7291-4A5D-ADFA-DA8FB7769CD2}\"," +
  "\"providerName\":\"PrinterProtocolProvider.dll\"}";

printer = await PosPrinter.FromIdAsync(oobBlobNetworkPrinter);
```

## <a name="usage-example-bluetooth-posprinter"></a><span data-ttu-id="7ae20-157">使用例: Bluetooth POS プリンター</span><span class="sxs-lookup"><span data-stu-id="7ae20-157">Usage example: Bluetooth POSPrinter</span></span>

```csharp
string oobBlobBTPrinter =
    "{\"connectionKind\":\"Bluetooth\"," +
    "\"physicalAddress\":\"AA:BB:CC:DD:EE:FF\"," +
    "\"peripheralKinds\":\"{C7BC9B22-21F0-4F0D-9BB6-66C229B8CD33}\"," +
    "\"providerId\":\"{CCD5B810-95B9-4320-BA7E-78C223CAF418}\"," +
    "\"providerName\":\"PrinterProtocolProvider.dll\"}";

printer = await PosPrinter.FromIdAsync(oobBlobBTPrinter);

```
