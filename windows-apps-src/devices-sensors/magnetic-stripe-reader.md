---
author: mukin
title: "磁気ストライプ リーダー デバイスのサポート"
description: "この記事には、POS (店舗販売時点管理) デバイス ファミリの磁気ストライプ リーダーに関する情報が含まれています"
ms.author: mukin
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 8bf2d6bf355c20e673fd2180d3bd70cbdede920c
ms.sourcegitcommit: ca060f051e696da2c1e26e9dd4d2da3fa030103d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/03/2017
---
# <a name="magnetic-stripe-reader-device-support"></a><span data-ttu-id="b5de9-104">磁気ストライプ リーダー デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="b5de9-104">Magnetic stripe reader device support</span></span>

<span data-ttu-id="b5de9-105">Windows には、[USB.org](http://www.usb.org/developers/hidpage/) によって定義された HID POS Scanner Usage Table (8c) 仕様に基づく、USB 接続の磁気ストライプ リーダーのインボックス クラス ドライバーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b5de9-105">Windows contains a in-box class driver for USB connected Magnetic stripe readers, which is based on the HID POS Scanner Usage Table (8c) specification defined by [USB.org](http://www.usb.org/developers/hidpage/).</span></span>

## <a name="vendor-specific-support"></a><span data-ttu-id="b5de9-106">ベンダー固有のサポート</span><span class="sxs-lookup"><span data-stu-id="b5de9-106">Vendor specific support</span></span>
<span data-ttu-id="b5de9-107">Windows では、ベンダー ID と製品 ID (VID/PID) に基づいて、Magtek と IDTech の次の磁気ストライプ リーダーのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="b5de9-107">Windows provides support for the following magnetic stripe readers from Magtek and IDTech based on their Vendor ID and Product ID (VID/PID).</span></span>

| <span data-ttu-id="b5de9-108">製造元</span><span class="sxs-lookup"><span data-stu-id="b5de9-108">Manufacturer</span></span> |    <span data-ttu-id="b5de9-109">モデル</span><span class="sxs-lookup"><span data-stu-id="b5de9-109">Model(s)</span></span> |  <span data-ttu-id="b5de9-110">製品番号</span><span class="sxs-lookup"><span data-stu-id="b5de9-110">Part Number</span></span> |
|--------------|-----------|--------------|
| <span data-ttu-id="b5de9-111">IDTech</span><span class="sxs-lookup"><span data-stu-id="b5de9-111">IDTech</span></span> | <span data-ttu-id="b5de9-112">SecureMag (VID:0ACD PID:2010)</span><span class="sxs-lookup"><span data-stu-id="b5de9-112">SecureMag (VID:0ACD PID:2010)</span></span> | <span data-ttu-id="b5de9-113">IDRE-3x5xxxx</span><span class="sxs-lookup"><span data-stu-id="b5de9-113">IDRE-3x5xxxx</span></span> |
| | <span data-ttu-id="b5de9-114">MiniMag (VID:0ACD PID:0500)</span><span class="sxs-lookup"><span data-stu-id="b5de9-114">MiniMag (VID:0ACD PID:0500)</span></span> |   <span data-ttu-id="b5de9-115">IDMB-3x5xxxx</span><span class="sxs-lookup"><span data-stu-id="b5de9-115">IDMB-3x5xxxx</span></span> |
| <span data-ttu-id="b5de9-116">Magtek</span><span class="sxs-lookup"><span data-stu-id="b5de9-116">Magtek</span></span> | <span data-ttu-id="b5de9-117">MagneSafe (VID:0801 PID:0011)</span><span class="sxs-lookup"><span data-stu-id="b5de9-117">MagneSafe (VID:0801 PID:0011)</span></span> |  <span data-ttu-id="b5de9-118">210730xx</span><span class="sxs-lookup"><span data-stu-id="b5de9-118">210730xx</span></span> |
| | <span data-ttu-id="b5de9-119">Dynamag (VID:0801 PID:0002)</span><span class="sxs-lookup"><span data-stu-id="b5de9-119">Dynamag (VID:0801 PID:0002)</span></span> |   <span data-ttu-id="b5de9-120">210401xx</span><span class="sxs-lookup"><span data-stu-id="b5de9-120">210401xx</span></span> |

## <a name="custom-vendor-specific"></a><span data-ttu-id="b5de9-121">カスタムのベンダー固有</span><span class="sxs-lookup"><span data-stu-id="b5de9-121">Custom vendor specific</span></span>
<span data-ttu-id="b5de9-122">Windows では、追加の磁気ストライプ リーダーをサポートする追加のベンダー固有のドライバーの実装をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b5de9-122">Windows supports implementation of additional vendor specific drivers to support additional magnetic stripe readers.</span></span> <span data-ttu-id="b5de9-123">ベンダー固有のドライバーの有無については、磁気ストライプ リーダーの製造元に確認してください。</span><span class="sxs-lookup"><span data-stu-id="b5de9-123">Please check with your magnetic stripe reader manufacturer for availability.</span></span>

## <a name="see-also"></a><span data-ttu-id="b5de9-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="b5de9-124">See also</span></span>
+   [<span data-ttu-id="b5de9-125">Windows.Devices.PointOfService 名前空間</span><span class="sxs-lookup"><span data-stu-id="b5de9-125">Windows.Devices.PointOfService namespace</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice)
+   [<span data-ttu-id="b5de9-126">MagneticStripeReader クラス</span><span class="sxs-lookup"><span data-stu-id="b5de9-126">MagneticStripeReader class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.pointofservice.magneticstripereader)
+   [<span data-ttu-id="b5de9-127">磁気ストライプ リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="b5de9-127">Magnetic stripe reader sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
