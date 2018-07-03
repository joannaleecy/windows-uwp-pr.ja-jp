---
author: TerryWarwick
title: POS (店舗販売時点管理) の概要
description: この記事には、PointOfService UWP API の概要に関する情報が含まれています。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: a0583adbcef9e45dfe0b2e56e03ce7e0451ac5bb
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983545"
---
# <a name="getting-started-with-point-of-service"></a><span data-ttu-id="9f7b6-104">POS (店舗販売時点管理) の概要</span><span class="sxs-lookup"><span data-stu-id="9f7b6-104">Getting started with Point of Service</span></span>

<span data-ttu-id="9f7b6-105">このセクションには、すべての POS デバイス カテゴリに共通するトピックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-105">This section contains topics that are common across all Point of Service device categories.</span></span>

|<span data-ttu-id="9f7b6-106">トピック</span><span class="sxs-lookup"><span data-stu-id="9f7b6-106">Topic</span></span> |<span data-ttu-id="9f7b6-107">説明</span><span class="sxs-lookup"><span data-stu-id="9f7b6-107">Description</span></span> |
|------|------------|
| [<span data-ttu-id="9f7b6-108">機能の宣言</span><span class="sxs-lookup"><span data-stu-id="9f7b6-108">Capability declaration</span></span>](pos-basics-capability.md)      | <span data-ttu-id="9f7b6-109">**pointOfService** 機能をアプリケーション マニフェストに追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-109">Learn how to add the **pointOfService** capability to your application manifest.</span></span>  <span data-ttu-id="9f7b6-110">Windows.Devices.PointOfService 名前空間の使用にはこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-110">This capability is required for use of Windows.Devices.PointOfService namespace.</span></span>  |
| [<span data-ttu-id="9f7b6-111">デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="9f7b6-111">Enumerating devices</span></span>](pos-basics-enumerating.md)        | <span data-ttu-id="9f7b6-112">システムが利用できるデバイスを照会するために使用するデバイス セレクターを定義し、このセレクターを使用して POS デバイスを列挙する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-112">Learn how to define a device selector that is used to query devices available to the system and use this selector to enumerate Point of Service devices.</span></span>  |
| [<span data-ttu-id="9f7b6-113">デバイス オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="9f7b6-113">Creating a device object</span></span>](pos-basics-deviceobject.md)  | <span data-ttu-id="9f7b6-114">周辺機器の読み取り専用のプロパティにアクセスできるようにする PointOfService デバイス オブジェクトを作成し、排他的使用のために周辺機器を要求する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-114">Learn how to create a PointOfService device object that will give you access to read-only properties of the peripheral and claim the peripheral for exclusive use.</span></span> |
| [<span data-ttu-id="9f7b6-115">排他的使用のためのデバイスの要求</span><span class="sxs-lookup"><span data-stu-id="9f7b6-115">Claiming a device for exclusive use</span></span> ](pos-basics-claim.md)  | <span data-ttu-id="9f7b6-116">PointOfService 要求モデルを使用して排他的使用のために PointOfService 周辺機器を予約し、同じコンピューター上の他のアプリケーションが排他的使用を必要とするときに PointOfService 周辺機器にアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="9f7b6-116">Learn how to reserve a PointOfService peripheral for exclusive use with the PointOfService claim model while allowing other applications on the same computer access to the PointOfService peripheral when they need exclusive use.</span></span>  |
|

## <a name="see-also"></a><span data-ttu-id="9f7b6-117">関連項目</span><span class="sxs-lookup"><span data-stu-id="9f7b6-117">See also</span></span>
[<span data-ttu-id="9f7b6-118">Windows.Devices.PointOfService の概要</span><span class="sxs-lookup"><span data-stu-id="9f7b6-118">Getting started with Windows.Devices.PointOfService</span></span>](pos-get-started.md)


## <a name="sample-code"></a><span data-ttu-id="9f7b6-119">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="9f7b6-119">Sample code</span></span>
+ [<span data-ttu-id="9f7b6-120">バーコード スキャナーのサンプル</span><span class="sxs-lookup"><span data-stu-id="9f7b6-120">Barcode scanner sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [<span data-ttu-id="9f7b6-121">キャッシュ ドロワーのサンプル</span><span class="sxs-lookup"><span data-stu-id="9f7b6-121">Cash drawer sample</span></span>]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [<span data-ttu-id="9f7b6-122">ライン ディスプレイのサンプル</span><span class="sxs-lookup"><span data-stu-id="9f7b6-122">Line display sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [<span data-ttu-id="9f7b6-123">磁気ストライプ リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="9f7b6-123">Magnetic stripe reader sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [<span data-ttu-id="9f7b6-124">POS プリンターのサンプル</span><span class="sxs-lookup"><span data-stu-id="9f7b6-124">POSPrinter sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

