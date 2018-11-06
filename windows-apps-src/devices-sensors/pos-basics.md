---
author: TerryWarwick
title: POS (店舗販売時点管理) の概要
description: この記事には、PointOfService UWP API の概要に関する情報が含まれています。
ms.author: jken
ms.date: 06/13/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 46dd1f615e42f6e89ee9a92cb980299e9a0e5205
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6040210"
---
# <a name="getting-started-with-point-of-service"></a><span data-ttu-id="fae13-104">POS (店舗販売時点管理) の概要</span><span class="sxs-lookup"><span data-stu-id="fae13-104">Getting started with Point of Service</span></span>

## <a name="pointofservice-basics"></a><span data-ttu-id="fae13-105">PointOfService の基本</span><span class="sxs-lookup"><span data-stu-id="fae13-105">PointOfService basics</span></span>

<span data-ttu-id="fae13-106">このセクションには、すべての POS デバイス カテゴリに共通するトピックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fae13-106">This section contains topics that are common across all Point of Service device categories.</span></span>

|<span data-ttu-id="fae13-107">トピック</span><span class="sxs-lookup"><span data-stu-id="fae13-107">Topic</span></span> |<span data-ttu-id="fae13-108">説明</span><span class="sxs-lookup"><span data-stu-id="fae13-108">Description</span></span> |
|------|------------|
| [<span data-ttu-id="fae13-109">機能の宣言</span><span class="sxs-lookup"><span data-stu-id="fae13-109">Capability declaration</span></span>](pos-basics-capability.md)      | <span data-ttu-id="fae13-110">**pointOfService** 機能をアプリケーション マニフェストに追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-110">Learn how to add the **pointOfService** capability to your application manifest.</span></span>  <span data-ttu-id="fae13-111">Windows.Devices.PointOfService 名前空間の使用にはこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="fae13-111">This capability is required for use of Windows.Devices.PointOfService namespace.</span></span>  |
| [<span data-ttu-id="fae13-112">デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="fae13-112">Enumerating devices</span></span>](pos-basics-enumerating.md)        | <span data-ttu-id="fae13-113">システムが利用できるデバイスを照会するために使用するデバイス セレクターを定義し、このセレクターを使用して POS デバイスを列挙する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-113">Learn how to define a device selector that is used to query devices available to the system and use this selector to enumerate Point of Service devices.</span></span>  |
| [<span data-ttu-id="fae13-114">デバイス オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="fae13-114">Creating a device object</span></span>](pos-basics-deviceobject.md)  | <span data-ttu-id="fae13-115">周辺機器の読み取り専用のプロパティにアクセスできるようにする PointOfService デバイス オブジェクトを作成し、排他的使用のために周辺機器を要求する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-115">Learn how to create a PointOfService device object that will give you access to read-only properties of the peripheral and claim the peripheral for exclusive use.</span></span> |
| [<span data-ttu-id="fae13-116">要求と有効にします。</span><span class="sxs-lookup"><span data-stu-id="fae13-116">Claim and enable</span></span> ](pos-basics-claim.md)  | <span data-ttu-id="fae13-117">PointOfService 排他的使用の周辺機器を予約し、I/O 操作に対して有効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-117">Learn how to reserve a PointOfService peripheral for exclusive use and enable for I/O operations.</span></span>  |
| [<span data-ttu-id="fae13-118">周辺機器の共有</span><span class="sxs-lookup"><span data-stu-id="fae13-118">Sharing peripherals with others</span></span>](pos-basics-sharing.md) | <span data-ttu-id="fae13-119">複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターとネットワークまたは Bluetooth 接続されている周辺機器を共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-119">Learn how to share network or Bluetooth connected peripherals with other computers in an environment where multiple PCs rely on shared peripherals rather than dedicated peripherals attached to each computer.</span></span>
| [<span data-ttu-id="fae13-120">PointOfService エンド ツー エンド</span><span class="sxs-lookup"><span data-stu-id="fae13-120">PointOfService end-to-end</span></span>](pos-get-started.md)  | <span data-ttu-id="fae13-121">これは、上記の例を使用して PointOfService 周辺機器を操作する方法のエンド ツー エンド例を示します。</span><span class="sxs-lookup"><span data-stu-id="fae13-121">This is an end to end example of how to interact with PointOfService peripherals utilizing the examples above.</span></span> |
|

## <a name="see-also"></a><span data-ttu-id="fae13-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="fae13-122">See also</span></span>

| <span data-ttu-id="fae13-123">トピック</span><span class="sxs-lookup"><span data-stu-id="fae13-123">Topic</span></span>   | <span data-ttu-id="fae13-124">説明</span><span class="sxs-lookup"><span data-stu-id="fae13-124">Description</span></span> |
|:--------|:------------|
| [<span data-ttu-id="fae13-125">アプリケーションの配布</span><span class="sxs-lookup"><span data-stu-id="fae13-125">Application distribution</span></span>](../publish/distribute-lob-apps-to-enterprises.md) | <span data-ttu-id="fae13-126">企業のお客様にアプリを配布するためのオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-126">Learn about the options for distributing your app to enterprise customers.</span></span> |
| [<span data-ttu-id="fae13-127">アプリケーションのライフ サイクル</span><span class="sxs-lookup"><span data-stu-id="fae13-127">Application lifecycle</span></span>](../launch-resume/app-lifecycle.md) | <span data-ttu-id="fae13-128">UWP アプリケーションのライフ サイクルと、Windows が起動、中断、およびアプリを再開するときの動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-128">Learn about the life cycle of a UWP application and what happens when Windows launches, suspends, and resumes your app.</span></span> |
| [<span data-ttu-id="fae13-129">アプリケーション リソース</span><span class="sxs-lookup"><span data-stu-id="fae13-129">Application resources</span></span>](../app-resources/index.md) | <span data-ttu-id="fae13-130">パッケージを作成して、アプリの文字列、イメージ、およびファイル リソースを利用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-130">Learn how to author, package, and consume your app's string, image, and file resources.</span></span> |
| [<span data-ttu-id="fae13-131">データ バインディング</span><span class="sxs-lookup"><span data-stu-id="fae13-131">Data binding</span></span>](../data-binding/index.md) | <span data-ttu-id="fae13-132">データ バインディングを使用して、アプリの UI でデータを表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-132">Learn how to use data binding to display data in your app's UI.</span></span> |
| [<span data-ttu-id="fae13-133">デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="fae13-133">Device enumeration</span></span>](enumerate-devices.md) | <span data-ttu-id="fae13-134">周辺機器を検索する高度な使用列挙手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fae13-134">Learn use advanced enumeration techniques to find your peripherals.</span></span>|
| [<span data-ttu-id="fae13-135">バージョン アダプティブ アプリケーション</span><span class="sxs-lookup"><span data-stu-id="fae13-135">Version adaptive applications</span></span>](../debug-test-perf/version-adaptive-apps.md) | <span data-ttu-id="fae13-136">複数のバージョンの Windows 10 で実行されるようにアプリを設計する方法を薄きます。</span><span class="sxs-lookup"><span data-stu-id="fae13-136">Lean how to design your app so that it runs on multiple versions of Windows 10.</span></span>|
|


## <a name="sample-code"></a><span data-ttu-id="fae13-137">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="fae13-137">Sample code</span></span>
+ [<span data-ttu-id="fae13-138">バーコード スキャナーのサンプル</span><span class="sxs-lookup"><span data-stu-id="fae13-138">Barcode scanner sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [<span data-ttu-id="fae13-139">キャッシュ ドロワーのサンプル</span><span class="sxs-lookup"><span data-stu-id="fae13-139">Cash drawer sample</span></span>]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [<span data-ttu-id="fae13-140">ライン ディスプレイのサンプル</span><span class="sxs-lookup"><span data-stu-id="fae13-140">Line display sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [<span data-ttu-id="fae13-141">磁気ストライプ リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="fae13-141">Magnetic stripe reader sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [<span data-ttu-id="fae13-142">POS プリンターのサンプル</span><span class="sxs-lookup"><span data-stu-id="fae13-142">POSPrinter sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

