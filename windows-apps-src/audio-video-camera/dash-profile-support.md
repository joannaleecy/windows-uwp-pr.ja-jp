---
ms.assetid: 3E0FBB43-F6A4-4558-AA89-20E7760BA73F
description: この記事では、UWP アプリでサポートされる Dynamic Adaptive Streaming over HTTP (DASH) プロファイルの一覧を示します。
title: Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート
ms.date: 02/15/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d680f7d4a3510f66cba74d1c8b30d8883b07369a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627207"
---
# <a name="dynamic-adaptive-streaming-over-http-dash-profile-support"></a><span data-ttu-id="102eb-104">Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート</span><span class="sxs-lookup"><span data-stu-id="102eb-104">Dynamic Adaptive Streaming over HTTP (DASH) profile support</span></span>


## <a name="supported-dash-profiles"></a><span data-ttu-id="102eb-105">サポートされている DASH プロファイル</span><span class="sxs-lookup"><span data-stu-id="102eb-105">Supported DASH profiles</span></span>
<span data-ttu-id="102eb-106">次の表では、UWP アプリでサポートされている DASH プロファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="102eb-106">The following table lists the DASH profiles that are supported for UWP apps.</span></span>

|<span data-ttu-id="102eb-107">Tag</span><span class="sxs-lookup"><span data-stu-id="102eb-107">Tag</span></span> | <span data-ttu-id="102eb-108">マニフェストの種類</span><span class="sxs-lookup"><span data-stu-id="102eb-108">Manifest type</span></span> | <span data-ttu-id="102eb-109">メモ</span><span class="sxs-lookup"><span data-stu-id="102eb-109">Notes</span></span>|<span data-ttu-id="102eb-110">7 月にリリースされた Windows 10</span><span class="sxs-lookup"><span data-stu-id="102eb-110">July release of Windows 10</span></span>|<span data-ttu-id="102eb-111">Windows 10 バージョン 1511</span><span class="sxs-lookup"><span data-stu-id="102eb-111">Windows 10, Version 1511</span></span>|<span data-ttu-id="102eb-112">Windows 10 バージョン 1607</span><span class="sxs-lookup"><span data-stu-id="102eb-112">Windows 10, Version 1607</span></span> |<span data-ttu-id="102eb-113">Windows 10 バージョン 1607</span><span class="sxs-lookup"><span data-stu-id="102eb-113">Windows 10, Version 1607</span></span> |<span data-ttu-id="102eb-114">Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="102eb-114">Windows 10, Version 1703</span></span>|
|----------------|------|-------|-----------|--------------|---------|-------|--------|
|<span data-ttu-id="102eb-115">urn:mpeg&#58;dash:profile:isoff-live:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-115">urn:mpeg&#58;dash:profile:isoff-live:2011</span></span> | <span data-ttu-id="102eb-116">静的</span><span class="sxs-lookup"><span data-stu-id="102eb-116">Static</span></span> |     |<span data-ttu-id="102eb-117">サポートされている</span><span class="sxs-lookup"><span data-stu-id="102eb-117">Supported</span></span>            |  <span data-ttu-id="102eb-118">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-118">Supported</span></span>              | <span data-ttu-id="102eb-119">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-119">Supported</span></span>        |<span data-ttu-id="102eb-120">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-120">Supported</span></span>| <span data-ttu-id="102eb-121">サポートされている</span><span class="sxs-lookup"><span data-stu-id="102eb-121">Supported</span></span>|
|<span data-ttu-id="102eb-122">urn:mpeg&#58;dash:profile:isoff-main:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-122">urn:mpeg&#58;dash:profile:isoff-main:2011</span></span> |        | <span data-ttu-id="102eb-123">ベスト エフォート</span><span class="sxs-lookup"><span data-stu-id="102eb-123">Best effort</span></span> | <span data-ttu-id="102eb-124">サポートされている</span><span class="sxs-lookup"><span data-stu-id="102eb-124">Supported</span></span>            |  <span data-ttu-id="102eb-125">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-125">Supported</span></span>              | <span data-ttu-id="102eb-126">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-126">Supported</span></span>        |<span data-ttu-id="102eb-127">サポート対象</span><span class="sxs-lookup"><span data-stu-id="102eb-127">Supported</span></span>| <span data-ttu-id="102eb-128">サポートされている</span><span class="sxs-lookup"><span data-stu-id="102eb-128">Supported</span></span>|
|<span data-ttu-id="102eb-129">urn:mpeg&#58;dash:profile:isoff-live:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-129">urn:mpeg&#58;dash:profile:isoff-live:2011</span></span> | <span data-ttu-id="102eb-130">動的</span><span class="sxs-lookup"><span data-stu-id="102eb-130">Dynamic</span></span> | <span data-ttu-id="102eb-131">セグメント テンプレートで $Time$ はサポートされていますが、$Number$ はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="102eb-131">$Time$ is supported but $Number$ is unsupported in segment templates</span></span> | <span data-ttu-id="102eb-132">サポートされない</span><span class="sxs-lookup"><span data-stu-id="102eb-132">Not Supported</span></span>            | <span data-ttu-id="102eb-133">サポートされない</span><span class="sxs-lookup"><span data-stu-id="102eb-133">Not Supported</span></span>              | <span data-ttu-id="102eb-134">サポートされない</span><span class="sxs-lookup"><span data-stu-id="102eb-134">Not Supported</span></span>        |<span data-ttu-id="102eb-135">サポートされない</span><span class="sxs-lookup"><span data-stu-id="102eb-135">Not Supported</span></span>| <span data-ttu-id="102eb-136">サポートされている</span><span class="sxs-lookup"><span data-stu-id="102eb-136">Supported</span></span>|


## <a name="unsupported-dash-profiles"></a><span data-ttu-id="102eb-137">サポートされていない DASH プロファイル</span><span class="sxs-lookup"><span data-stu-id="102eb-137">Unsupported DASH profiles</span></span>
<span data-ttu-id="102eb-138">上の表に示されていないプロファイルはサポートされていません。これには、次のようなものが含まれますが、これらに限定されません。</span><span class="sxs-lookup"><span data-stu-id="102eb-138">Profiles not listed in the above table are unsupported, including but not limited to the following:</span></span>

* <span data-ttu-id="102eb-139">urn:mpeg&#58;dash:profile:full:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-139">urn:mpeg&#58;dash:profile:full:2011</span></span>
* <span data-ttu-id="102eb-140">urn:mpeg&#58;dash:profile:isoff-on-demand:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-140">urn:mpeg&#58;dash:profile:isoff-on-demand:2011</span></span>
* <span data-ttu-id="102eb-141">urn:mpeg&#58;dash:profile:mp2t-main:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-141">urn:mpeg&#58;dash:profile:mp2t-main:2011</span></span>
* <span data-ttu-id="102eb-142">urn:mpeg&#58;dash:profile:mp2t-simple:2011</span><span class="sxs-lookup"><span data-stu-id="102eb-142">urn:mpeg&#58;dash:profile:mp2t-simple:2011</span></span>


## <a name="related-topics"></a><span data-ttu-id="102eb-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="102eb-143">Related topics</span></span>

* [<span data-ttu-id="102eb-144">メディア再生</span><span class="sxs-lookup"><span data-stu-id="102eb-144">Media playback</span></span>](media-playback.md)
* [<span data-ttu-id="102eb-145">アダプティブ ストリーミング</span><span class="sxs-lookup"><span data-stu-id="102eb-145">Adaptive streaming</span></span>](adaptive-streaming.md)
 

 




