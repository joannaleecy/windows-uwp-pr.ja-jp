---
author: mukin
title: "POS デバイスのサポート"
description: "この記事には、各 POS デバイス ファミリのデバイスのサポートに関する情報が含まれています。"
ms.author: mukin
ms.date: 05/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 58018385082f7f7e49edba0351d919bc840ade05
ms.sourcegitcommit: 53930c9871461f6106f785ae4fabb2296eb359f1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2017
---
# <a name="pos-device-support"></a><span data-ttu-id="16eea-104">POS デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="16eea-104">POS device support</span></span>

## <a name="barcode-scanner"></a><span data-ttu-id="16eea-105">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-105">Barcode scanner</span></span>
| <span data-ttu-id="16eea-106">接続</span><span class="sxs-lookup"><span data-stu-id="16eea-106">Connectivity</span></span> | <span data-ttu-id="16eea-107">サポート</span><span class="sxs-lookup"><span data-stu-id="16eea-107">Support</span></span> |
| -------------|-------------|
| <span data-ttu-id="16eea-108">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-108">USB</span></span>          | <p><span data-ttu-id="16eea-109">Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続のバーコード スキャナーのインボックス クラス ドライバーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="16eea-109">Windows contains a in-box class driver for USB connected barcode scanners which is based on the HID POS Scanner Usage Table (8c) specification defined by [USB.org](http://www.usb.org/developers/hidpage/).</span></span> <span data-ttu-id="16eea-110">既知の互換性のあるデバイスの一覧については、次の表を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16eea-110">See the table below for a list of known compatible devices.</span></span>  <span data-ttu-id="16eea-111">USB.HID.POS Scanner モードで構成できるかどうかを調べるには、バーコード スキャナーのマニュアルを参照するか、製造元に問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="16eea-111">Consult the manual for your barcode scanner or contact the manufacturer to determine if it can be configured in USB.HID.POS Scanner mode.</span></span> </p><p><span data-ttu-id="16eea-112">Windows では、USB.HID.POS Scanner 標準をサポートしない追加のバーコード スキャナーをサポートするために、ベンダー固有のドライバーの実装をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="16eea-112">Windows also supports implementation of vendor specific drivers to support additional barcode scanners that do not support the USB.HID.POS Scanner standard.</span></span> <span data-ttu-id="16eea-113">ベンダー固有のドライバーの利用可能性については、バーコード スキャナーの製造元に確認してください。</span><span class="sxs-lookup"><span data-stu-id="16eea-113">Please check with your barcode scanner manufacturer for vendor specific driver availability.</span></span></p>|
| <span data-ttu-id="16eea-114">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-114">Bluetooth</span></span>    | <p><span data-ttu-id="16eea-115">Windows では、SPP-SSI ベースの Bluetooth バーコード スキャナーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="16eea-115">Windows supports SPP-SSI based Bluetooth barcode scanners.</span></span> <span data-ttu-id="16eea-116">既知の互換性のあるデバイスの一覧については、次の表を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16eea-116">See the table below for a list of known compatible devices.</span></span></p> |

### <a name="compatible-hardware"></a><span data-ttu-id="16eea-117">互換性のあるハードウェア</span><span class="sxs-lookup"><span data-stu-id="16eea-117">Compatible Hardware</span></span>
| <span data-ttu-id="16eea-118">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="16eea-118">Category</span></span> | <span data-ttu-id="16eea-119">接続</span><span class="sxs-lookup"><span data-stu-id="16eea-119">Connectivity</span></span> | <span data-ttu-id="16eea-120">製造元/モデル</span><span class="sxs-lookup"><span data-stu-id="16eea-120">Manufacturer / Model</span></span> |
|--------------|-----------|-----------|
| **<span data-ttu-id="16eea-121">1D ハンドヘルド スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-121">1D Handheld Scanners</span></span>** | **<span data-ttu-id="16eea-122">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-122">USB</span></span>** |<span data-ttu-id="16eea-123">Honeywell Voyager 1200g</span><span class="sxs-lookup"><span data-stu-id="16eea-123">Honeywell Voyager 1200g</span></span><br/><span data-ttu-id="16eea-124">Honeywell Voyager 1202g</span><span class="sxs-lookup"><span data-stu-id="16eea-124">Honeywell Voyager 1202g</span></span><br/><span data-ttu-id="16eea-125">Honeywell Voyager 1202-bf</span><span class="sxs-lookup"><span data-stu-id="16eea-125">Honeywell Voyager 1202-bf</span></span><br/><span data-ttu-id="16eea-126">Honeywell Voyager 145Xg (アップグレード可能)</span><span class="sxs-lookup"><span data-stu-id="16eea-126">Honeywell Voyager 145Xg (Upgradable)</span></span>|
| **<span data-ttu-id="16eea-127">1D ハンドヘルド スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-127">1D Handheld Scanners</span></span>** | **<span data-ttu-id="16eea-128">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-128">Bluetooth</span></span>** |<span data-ttu-id="16eea-129">Socket Mobile CHS 7Ci</span><span class="sxs-lookup"><span data-stu-id="16eea-129">Socket Mobile CHS 7Ci</span></span><br/> <span data-ttu-id="16eea-130">Socket Mobile CHS 7Di</span><span class="sxs-lookup"><span data-stu-id="16eea-130">Socket Mobile CHS 7Di</span></span><br/> <span data-ttu-id="16eea-131">Socket Mobile CHS 7Mi</span><span class="sxs-lookup"><span data-stu-id="16eea-131">Socket Mobile CHS 7Mi</span></span><br/> <span data-ttu-id="16eea-132">Socket Mobile CHS 7Pi</span><span class="sxs-lookup"><span data-stu-id="16eea-132">Socket Mobile CHS 7Pi</span></span><br/><span data-ttu-id="16eea-133">Socket Mobile DuraScan D700</span><span class="sxs-lookup"><span data-stu-id="16eea-133">Socket Mobile DuraScan D700</span></span><br/> <span data-ttu-id="16eea-134">Socket Mobile DuraScan D730</span><span class="sxs-lookup"><span data-stu-id="16eea-134">Socket Mobile DuraScan D730</span></span><br/><span data-ttu-id="16eea-135">Socket Mobile SocketScan S800 (旧 CHS 8Ci)</span><span class="sxs-lookup"><span data-stu-id="16eea-135">Socket Mobile SocketScan S800 (formerly CHS 8Ci)</span></span> <br/>|
|**<span data-ttu-id="16eea-136">2D ハンドヘルド スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-136">2D Handheld Scanners</span></span>** | **<span data-ttu-id="16eea-137">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-137">USB</span></span>** |<span data-ttu-id="16eea-138">Code Reader™ 950</span><span class="sxs-lookup"><span data-stu-id="16eea-138">Code Reader™ 950</span></span><br/><span data-ttu-id="16eea-139">Code Reader™ 1021</span><span class="sxs-lookup"><span data-stu-id="16eea-139">Code Reader™ 1021</span></span><br/><span data-ttu-id="16eea-140">Code Reader™ 1421</span><span class="sxs-lookup"><span data-stu-id="16eea-140">Code Reader™ 1421</span></span><br/> <span data-ttu-id="16eea-141">Honeywell Granit 198Xi</span><span class="sxs-lookup"><span data-stu-id="16eea-141">Honeywell Granit 198Xi</span></span><br/><span data-ttu-id="16eea-142">Honeywell Granit 191Xi</span><span class="sxs-lookup"><span data-stu-id="16eea-142">Honeywell Granit 191Xi</span></span><br/><span data-ttu-id="16eea-143">Honeywell Xenon 1900g</span><span class="sxs-lookup"><span data-stu-id="16eea-143">Honeywell Xenon 1900g</span></span><br/><span data-ttu-id="16eea-144">Honeywell Xenon 1902g</span><span class="sxs-lookup"><span data-stu-id="16eea-144">Honeywell Xenon 1902g</span></span><br/><span data-ttu-id="16eea-145">Honeywell Xenon 1902g-bf</span><span class="sxs-lookup"><span data-stu-id="16eea-145">Honeywell Xenon 1902g-bf</span></span><br/><span data-ttu-id="16eea-146">Honeywell Xenon 1900h</span><span class="sxs-lookup"><span data-stu-id="16eea-146">Honeywell Xenon 1900h</span></span><br/><span data-ttu-id="16eea-147">Honeywell Xenon 1902h</span><span class="sxs-lookup"><span data-stu-id="16eea-147">Honeywell Xenon 1902h</span></span><br/><span data-ttu-id="16eea-148">Honeywell Voyager 145Xg (アップグレード可能)</span><span class="sxs-lookup"><span data-stu-id="16eea-148">Honeywell Voyager 145Xg (Upgradable)</span></span><br/><span data-ttu-id="16eea-149">Honeywell Voyager 1602g</span><span class="sxs-lookup"><span data-stu-id="16eea-149">Honeywell Voyager 1602g</span></span><br/><span data-ttu-id="16eea-150">Intermec SG20</span><span class="sxs-lookup"><span data-stu-id="16eea-150">Intermec SG20</span></span>|
|**<span data-ttu-id="16eea-151">2D ハンドヘルド スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-151">2D Handheld Scanners</span></span>** | **<span data-ttu-id="16eea-152">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-152">Bluetooth</span></span>** |<span data-ttu-id="16eea-153">Socket Mobile SocketScan S850 (旧 CHS 8Qi)</span><span class="sxs-lookup"><span data-stu-id="16eea-153">Socket Mobile SocketScan S850 (formerly CHS 8Qi)</span></span>|
| **<span data-ttu-id="16eea-154">プレゼンテーション スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-154">Presentation Scanners</span></span>** | **<span data-ttu-id="16eea-155">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-155">USB</span></span>** |<span data-ttu-id="16eea-156">Code Reader™ 5000</span><span class="sxs-lookup"><span data-stu-id="16eea-156">Code Reader™ 5000</span></span><br/><span data-ttu-id="16eea-157">Honeywell Genesis 7580g</span><span class="sxs-lookup"><span data-stu-id="16eea-157">Honeywell Genesis 7580g</span></span><br/><span data-ttu-id="16eea-158">Honeywell Orbit 7190g</span><span class="sxs-lookup"><span data-stu-id="16eea-158">Honeywell Orbit 7190g</span></span>|
| **<span data-ttu-id="16eea-159">インカウンター スキャナー</span><span class="sxs-lookup"><span data-stu-id="16eea-159">In-Counter Scanners</span></span>** | **<span data-ttu-id="16eea-160">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-160">USB</span></span>** |<span data-ttu-id="16eea-161">Honeywell Stratos 2700</span><span class="sxs-lookup"><span data-stu-id="16eea-161">Honeywell Stratos 2700</span></span>|
| **<span data-ttu-id="16eea-162">スキャン エンジン</span><span class="sxs-lookup"><span data-stu-id="16eea-162">Scan Engines</span></span>** | **<span data-ttu-id="16eea-163">USB</span><span class="sxs-lookup"><span data-stu-id="16eea-163">USB</span></span>** | <span data-ttu-id="16eea-164">Honeywell N5680</span><span class="sxs-lookup"><span data-stu-id="16eea-164">Honeywell N5680</span></span><br/><span data-ttu-id="16eea-165">Honeywell N3680</span><span class="sxs-lookup"><span data-stu-id="16eea-165">Honeywell N3680</span></span>|
| **<span data-ttu-id="16eea-166">Windows Mobile デバイス</span><span class="sxs-lookup"><span data-stu-id="16eea-166">Windows Mobile Devices</span></span>**| **<span data-ttu-id="16eea-167">組み込み</span><span class="sxs-lookup"><span data-stu-id="16eea-167">Built-in</span></span>** |<span data-ttu-id="16eea-168">Bluebird EF400</span><span class="sxs-lookup"><span data-stu-id="16eea-168">Bluebird EF400</span></span><br/><span data-ttu-id="16eea-169">Bluebird EF500</span><span class="sxs-lookup"><span data-stu-id="16eea-169">Bluebird EF500</span></span><br/><span data-ttu-id="16eea-170">Bluebird EF500R</span><span class="sxs-lookup"><span data-stu-id="16eea-170">Bluebird EF500R</span></span><br/><span data-ttu-id="16eea-171">Honeywell CT50</span><span class="sxs-lookup"><span data-stu-id="16eea-171">Honeywell CT50</span></span><br/><span data-ttu-id="16eea-172">Honeywell D75e</span><span class="sxs-lookup"><span data-stu-id="16eea-172">Honeywell D75e</span></span><br/><span data-ttu-id="16eea-173">Janam XT2</span><span class="sxs-lookup"><span data-stu-id="16eea-173">Janam XT2</span></span><br/><span data-ttu-id="16eea-174">Panasonic FZ-E1</span><span class="sxs-lookup"><span data-stu-id="16eea-174">Panasonic FZ-E1</span></span><br/><span data-ttu-id="16eea-175">Panasonic FZ-F1</span><span class="sxs-lookup"><span data-stu-id="16eea-175">Panasonic FZ-F1</span></span><br/><span data-ttu-id="16eea-176">PointMobile PM80</span><span class="sxs-lookup"><span data-stu-id="16eea-176">PointMobile PM80</span></span><br/><span data-ttu-id="16eea-177">Zebra TC700j</span><span class="sxs-lookup"><span data-stu-id="16eea-177">Zebra TC700j</span></span>|
| **<span data-ttu-id="16eea-178">Windows Mobile デバイス</span><span class="sxs-lookup"><span data-stu-id="16eea-178">Windows Mobile Devices</span></span>**| **<span data-ttu-id="16eea-179">カスタム</span><span class="sxs-lookup"><span data-stu-id="16eea-179">Custom</span></span>** | <span data-ttu-id="16eea-180">HP Elite X3 とバーコード スキャナー ジャケット</span><span class="sxs-lookup"><span data-stu-id="16eea-180">HP Elite X3 with Barcode Scanner Jacket</span></span> |

## <a name="cash-drawer"></a><span data-ttu-id="16eea-181">キャッシュ ドロワー</span><span class="sxs-lookup"><span data-stu-id="16eea-181">Cash drawer</span></span>
| <span data-ttu-id="16eea-182">接続</span><span class="sxs-lookup"><span data-stu-id="16eea-182">Connectivity</span></span> | <span data-ttu-id="16eea-183">サポート</span><span class="sxs-lookup"><span data-stu-id="16eea-183">Support</span></span> |
| -------------|-------------|
| <span data-ttu-id="16eea-184">ネットワーク/Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-184">Network/Bluetooth</span></span> | <p> <span data-ttu-id="16eea-185">キャッシュ ドロワー ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、キャッシュ ドロワーに直接接続できます。</span><span class="sxs-lookup"><span data-stu-id="16eea-185">Connection directly to the cash drawer can be made over the network or through Bluetooth, depending on the capabilities of the cash drawer unit.</span></span> </p>|
| <span data-ttu-id="16eea-186">DK ポート</span><span class="sxs-lookup"><span data-stu-id="16eea-186">DK port</span></span> | <p> <span data-ttu-id="16eea-187">ネットワーク機能や Bluetooth 機能を持たないキャッシュ ドロワーは、サポートされている POS プリンター上の DK ポート、つまり Star Micronics DK-AirCash アクセサリ経由で接続できます。</span><span class="sxs-lookup"><span data-stu-id="16eea-187">Cash drawers that don’t have network or Bluetooth capabilities can be connected via the DK port on a supported POS printer, or the Star Micronics DK-AirCash accessory.</span></span> </p>
| <span data-ttu-id="16eea-188">OPOS</span><span class="sxs-lookup"><span data-stu-id="16eea-188">OPOS</span></span>    | <p> <span data-ttu-id="16eea-189">OPOS ドライバーをサポートするすべてのキャッシュ ドロワー デバイスをサポートし、OPOS サービス オブジェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="16eea-189">Supports any Cash Drawer devices that support OPOS drivers and/or provides OPOS service objects.</span></span> <span data-ttu-id="16eea-190">特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。</span><span class="sxs-lookup"><span data-stu-id="16eea-190">Install the OPOS drivers as per the particular device manufacturers installation instructions.</span></span> <span data-ttu-id="16eea-191">これにより、製造元の仕様に基づいて USB やその他の接続が有効になります。</span><span class="sxs-lookup"><span data-stu-id="16eea-191">This enables USB and other connectivity based on manufacterer specifications.</span></span> </p> |

<span data-ttu-id="16eea-192">**注:** DK-AirCash の詳細については、Star Micronics にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="16eea-192">**Note:**  Contact Star Micronics for more information about the DK-AirCash.</span></span>

### <a name="networkbluetooth"></a><span data-ttu-id="16eea-193">ネットワーク/Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-193">Network/Bluetooth</span></span>
| <span data-ttu-id="16eea-194">製造元</span><span class="sxs-lookup"><span data-stu-id="16eea-194">Manufacturer</span></span> |    <span data-ttu-id="16eea-195">モデル</span><span class="sxs-lookup"><span data-stu-id="16eea-195">Model(s)</span></span> |
|--------------|-----------|
| <span data-ttu-id="16eea-196">APG Cash Drawer</span><span class="sxs-lookup"><span data-stu-id="16eea-196">APG Cash Drawer</span></span> |    <span data-ttu-id="16eea-197">NetPRO、BluePRO</span><span class="sxs-lookup"><span data-stu-id="16eea-197">NetPRO, BluePRO</span></span> |

## <a name="line-display"></a><span data-ttu-id="16eea-198">ライン ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="16eea-198">Line display</span></span>
<span data-ttu-id="16eea-199">OPOS ドライバーをサポートするすべてのライン ディスプレイ デバイスをサポートし、OPOS サービス オブジェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="16eea-199">Supports any line display devices that support OPOS drivers and/or provides OPOS service objects.</span></span> <span data-ttu-id="16eea-200">特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。</span><span class="sxs-lookup"><span data-stu-id="16eea-200">Install the OPOS drivers as per the particular device manufacturers installation instructions.</span></span>

## <a name="magnetic-stripe-reader"></a><span data-ttu-id="16eea-201">磁気ストライプ リーダー</span><span class="sxs-lookup"><span data-stu-id="16eea-201">Magnetic stripe reader</span></span>

<span data-ttu-id="16eea-202">Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続の磁気ストライプ リーダーのインボックス クラス ドライバーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="16eea-202">Windows contains a in-box class driver for USB connected Magnetic stripe readers, which is based on the HID POS Scanner Usage Table (8c) specification defined by [USB.org](http://www.usb.org/developers/hidpage/).</span></span>

### <a name="vendor-specific-support"></a><span data-ttu-id="16eea-203">ベンダー固有のサポート</span><span class="sxs-lookup"><span data-stu-id="16eea-203">Vendor specific support</span></span>
<span data-ttu-id="16eea-204">Windows では、ベンダー ID と製品 ID (VID/PID) に基づいて、Magtek と IDTech の次の磁気ストライプ リーダーのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="16eea-204">Windows provides support for the following magnetic stripe readers from Magtek and IDTech based on their Vendor ID and Product ID (VID/PID).</span></span>

| <span data-ttu-id="16eea-205">製造元</span><span class="sxs-lookup"><span data-stu-id="16eea-205">Manufacturer</span></span> |     <span data-ttu-id="16eea-206">モデル</span><span class="sxs-lookup"><span data-stu-id="16eea-206">Model(s)</span></span> |    <span data-ttu-id="16eea-207">製品番号</span><span class="sxs-lookup"><span data-stu-id="16eea-207">Part Number</span></span> |
|--------------|-----------|--------------|
| <span data-ttu-id="16eea-208">IDTech</span><span class="sxs-lookup"><span data-stu-id="16eea-208">IDTech</span></span> | <span data-ttu-id="16eea-209">SecureMag (VID:0ACD PID:2010)</span><span class="sxs-lookup"><span data-stu-id="16eea-209">SecureMag (VID:0ACD PID:2010)</span></span> | <span data-ttu-id="16eea-210">IDRE-3x5xxxx</span><span class="sxs-lookup"><span data-stu-id="16eea-210">IDRE-3x5xxxx</span></span> |
| |    <span data-ttu-id="16eea-211">MiniMag (VID:0ACD PID:0500)</span><span class="sxs-lookup"><span data-stu-id="16eea-211">MiniMag (VID:0ACD PID:0500)</span></span> |    <span data-ttu-id="16eea-212">IDMB-3x5xxxx</span><span class="sxs-lookup"><span data-stu-id="16eea-212">IDMB-3x5xxxx</span></span> |
| <span data-ttu-id="16eea-213">Magtek</span><span class="sxs-lookup"><span data-stu-id="16eea-213">Magtek</span></span> | <span data-ttu-id="16eea-214">MagneSafe (VID:0801 PID:0011)</span><span class="sxs-lookup"><span data-stu-id="16eea-214">MagneSafe (VID:0801 PID:0011)</span></span> |    <span data-ttu-id="16eea-215">210730xx</span><span class="sxs-lookup"><span data-stu-id="16eea-215">210730xx</span></span> |
| |    <span data-ttu-id="16eea-216">Dynamag (VID:0801 PID:0002)</span><span class="sxs-lookup"><span data-stu-id="16eea-216">Dynamag (VID:0801 PID:0002)</span></span> |    <span data-ttu-id="16eea-217">210401xx</span><span class="sxs-lookup"><span data-stu-id="16eea-217">210401xx</span></span> |

### <a name="custom-vendor-specific"></a><span data-ttu-id="16eea-218">カスタムのベンダー固有</span><span class="sxs-lookup"><span data-stu-id="16eea-218">Custom vendor specific</span></span>
<span data-ttu-id="16eea-219">Windows では、追加の磁気ストライプ リーダーをサポートする追加のベンダー固有のドライバーの実装をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="16eea-219">Windows supports implementation of additional vendor specific drivers to support additional magnetic stripe readers.</span></span> <span data-ttu-id="16eea-220">ベンダー固有のドライバーの有無については、磁気ストライプ リーダーの製造元に確認してください。</span><span class="sxs-lookup"><span data-stu-id="16eea-220">Please check with your magnetic stripe reader manufacturer for availability.</span></span>

## <a name="pos-printer"></a><span data-ttu-id="16eea-221">POS プリンター</span><span class="sxs-lookup"><span data-stu-id="16eea-221">POS printer</span></span>
<span data-ttu-id="16eea-222">Windows では、Epson ESC/POS プリンター制御言語を使用して、ネットワークおよび Bluetooth で接続されているレシート プリンターで印刷する機能をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="16eea-222">Windows supports the ability to print to network and Bluetooth connected receipt printers using the Epson ESC/POS printer control language.</span></span> <span data-ttu-id="16eea-223">ESC/POS について詳しくは、[書式設定における Epson ESC/POS](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/epson-esc-pos-with-formatting)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16eea-223">For more information on ESC/POS, see [Epson ESC/POS with formatting](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/epson-esc-pos-with-formatting).</span></span>

<span data-ttu-id="16eea-224">API で公開されるクラス、列挙体、インターフェイスはレシート プリンター、スリップ プリンター、ジャーナル プリンターをサポートしていますが、ドライバー インターフェイスではレシート プリンターのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="16eea-224">While the classes, enumerations, and interfaces exposed in the API support receipt printer, slip printer, and journal printer, the driver interface only supports receipt printer.</span></span> <span data-ttu-id="16eea-225">現時点でスリップ プリンターやジャーナル プリンターを使用しようとすると、未実装のステータスが返されます。</span><span class="sxs-lookup"><span data-stu-id="16eea-225">Attempting to use slip printer or journal printer at this time will return a status of not implemented.</span></span>

| <span data-ttu-id="16eea-226">接続</span><span class="sxs-lookup"><span data-stu-id="16eea-226">Connectivity</span></span> | <span data-ttu-id="16eea-227">サポート</span><span class="sxs-lookup"><span data-stu-id="16eea-227">Support</span></span> |
| -------------|-------------|
| <span data-ttu-id="16eea-228">ネットワーク/Bluetooth</span><span class="sxs-lookup"><span data-stu-id="16eea-228">Network/Bluetooth</span></span> | <p> <span data-ttu-id="16eea-229">POS プリンター ユニットの機能に応じて、ネットワーク経由または Bluetooth によって、POS プリンターに直接接続できます。</span><span class="sxs-lookup"><span data-stu-id="16eea-229">Connection directly to the POS printer can be made over the network or through Bluetooth, depending on the capabilities of the POS printer unit.</span></span> </p>|
| <span data-ttu-id="16eea-230">OPOS</span><span class="sxs-lookup"><span data-stu-id="16eea-230">OPOS</span></span>    | <p> <span data-ttu-id="16eea-231">OPOS ドライバーをサポートするすべての POS プリンター デバイスをサポートし、OPOS サービス オブジェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="16eea-231">Supports any POS printer devices that support OPOS drivers and/or provides OPOS service objects.</span></span> <span data-ttu-id="16eea-232">特定のデバイスの製造元のインストール手順に従って、OPOS ドライバーをインストールします。</span><span class="sxs-lookup"><span data-stu-id="16eea-232">Install the OPOS drivers as per the particular device manufacturers installation instructions.</span></span> <span data-ttu-id="16eea-233">これにより、製造元の仕様に基づいて USB やその他の接続が有効になります。</span><span class="sxs-lookup"><span data-stu-id="16eea-233">This enables USB and other connectivity based on manufacterer specifications.</span></span> </p> |

### <a name="stationary-pos-printers-networkbluetooth"></a><span data-ttu-id="16eea-234">固定型 POSプリンター (ネットワーク/Bluetooth)</span><span class="sxs-lookup"><span data-stu-id="16eea-234">Stationary POS printers (Network/Bluetooth)</span></span>
| <span data-ttu-id="16eea-235">製造元</span><span class="sxs-lookup"><span data-stu-id="16eea-235">Manufacturer</span></span> |    <span data-ttu-id="16eea-236">モデル</span><span class="sxs-lookup"><span data-stu-id="16eea-236">Model(s)</span></span> |
|--------------|-----------|
| <span data-ttu-id="16eea-237">Epson</span><span class="sxs-lookup"><span data-stu-id="16eea-237">Epson</span></span> |    <span data-ttu-id="16eea-238">TM T88V、TM-T70、TM-T20、TM U220</span><span class="sxs-lookup"><span data-stu-id="16eea-238">TM-T88V, TM-T70, TM-T20, TM-U220</span></span> |

### <a name="mobile-pos-printers-bluetooth"></a><span data-ttu-id="16eea-239">モバイル POS プリンター (Bluetooth)</span><span class="sxs-lookup"><span data-stu-id="16eea-239">Mobile POS printers (Bluetooth)</span></span>
| <span data-ttu-id="16eea-240">製造元</span><span class="sxs-lookup"><span data-stu-id="16eea-240">Manufacturer</span></span> |    <span data-ttu-id="16eea-241">モデル</span><span class="sxs-lookup"><span data-stu-id="16eea-241">Model(s)</span></span> |
|--------------|-----------|
| <span data-ttu-id="16eea-242">Epson</span><span class="sxs-lookup"><span data-stu-id="16eea-242">Epson</span></span> |    <span data-ttu-id="16eea-243">Mobilink P20 (TM-P20)、Mobilink P60 (TM-P60)、Mobilink P80 (TM-P80)</span><span class="sxs-lookup"><span data-stu-id="16eea-243">Mobilink P20 (TM-P20), Mobilink P60 (TM-P60), Mobilink P80 (TM-P80)</span></span> |