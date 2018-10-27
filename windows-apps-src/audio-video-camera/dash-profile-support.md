---
author: drewbatgit
ms.assetid: 3E0FBB43-F6A4-4558-AA89-20E7760BA73F
description: この記事では、UWP アプリでサポートされる Dynamic Adaptive Streaming over HTTP (DASH) プロファイルの一覧を示します。
title: Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート
ms.author: drewbat
ms.date: 02/15/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7a4ec9f9e81010d39af496da156afa676f4b3714
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5690840"
---
# <a name="dynamic-adaptive-streaming-over-http-dash-profile-support"></a><span data-ttu-id="30a63-104">Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート</span><span class="sxs-lookup"><span data-stu-id="30a63-104">Dynamic Adaptive Streaming over HTTP (DASH) profile support</span></span>


## <a name="supported-dash-profiles"></a><span data-ttu-id="30a63-105">サポートされている DASH プロファイル</span><span class="sxs-lookup"><span data-stu-id="30a63-105">Supported DASH profiles</span></span>
<span data-ttu-id="30a63-106">次の表では、UWP アプリでサポートされている DASH プロファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="30a63-106">The following table lists the DASH profiles that are supported for UWP apps.</span></span>

|<span data-ttu-id="30a63-107">タグ</span><span class="sxs-lookup"><span data-stu-id="30a63-107">Tag</span></span> | <span data-ttu-id="30a63-108">マニフェストの種類</span><span class="sxs-lookup"><span data-stu-id="30a63-108">Manifest type</span></span> | <span data-ttu-id="30a63-109">説明</span><span class="sxs-lookup"><span data-stu-id="30a63-109">Notes</span></span>|<span data-ttu-id="30a63-110">7 月にリリースされた Windows 10</span><span class="sxs-lookup"><span data-stu-id="30a63-110">July release of Windows 10</span></span>|<span data-ttu-id="30a63-111">Windows 10 バージョン 1511</span><span class="sxs-lookup"><span data-stu-id="30a63-111">Windows 10, Version 1511</span></span>|<span data-ttu-id="30a63-112">Windows 10 バージョン 1607</span><span class="sxs-lookup"><span data-stu-id="30a63-112">Windows 10, Version 1607</span></span> |<span data-ttu-id="30a63-113">Windows 10 バージョン 1607</span><span class="sxs-lookup"><span data-stu-id="30a63-113">Windows 10, Version 1607</span></span> |<span data-ttu-id="30a63-114">Windows 10 Version 1703</span><span class="sxs-lookup"><span data-stu-id="30a63-114">Windows 10, Version 1703</span></span>|
|----------------|------|-------|-----------|--------------|---------|-------|--------|
|<span data-ttu-id="30a63-115">urn:mpeg&#58;dash:profile:isoff-live:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-115">urn:mpeg&#58;dash:profile:isoff-live:2011</span></span> | <span data-ttu-id="30a63-116">静的</span><span class="sxs-lookup"><span data-stu-id="30a63-116">Static</span></span> |     |<span data-ttu-id="30a63-117">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-117">Supported</span></span>            |  <span data-ttu-id="30a63-118">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-118">Supported</span></span>              | <span data-ttu-id="30a63-119">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-119">Supported</span></span>        |<span data-ttu-id="30a63-120">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-120">Supported</span></span>| <span data-ttu-id="30a63-121">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-121">Supported</span></span>|
|<span data-ttu-id="30a63-122">urn:mpeg&#58;dash:profile:isoff-main:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-122">urn:mpeg&#58;dash:profile:isoff-main:2011</span></span> |        | <span data-ttu-id="30a63-123">ベスト エフォート</span><span class="sxs-lookup"><span data-stu-id="30a63-123">Best effort</span></span> | <span data-ttu-id="30a63-124">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-124">Supported</span></span>            |  <span data-ttu-id="30a63-125">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-125">Supported</span></span>              | <span data-ttu-id="30a63-126">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-126">Supported</span></span>        |<span data-ttu-id="30a63-127">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-127">Supported</span></span>| <span data-ttu-id="30a63-128">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-128">Supported</span></span>|
|<span data-ttu-id="30a63-129">urn:mpeg&#58;dash:profile:isoff-live:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-129">urn:mpeg&#58;dash:profile:isoff-live:2011</span></span> | <span data-ttu-id="30a63-130">動的</span><span class="sxs-lookup"><span data-stu-id="30a63-130">Dynamic</span></span> | <span data-ttu-id="30a63-131">セグメント テンプレートで $Time$ はサポートされていますが、$Number$ はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="30a63-131">$Time$ is supported but $Number$ is unsupported in segment templates</span></span> | <span data-ttu-id="30a63-132">サポートされない</span><span class="sxs-lookup"><span data-stu-id="30a63-132">Not Supported</span></span>            | <span data-ttu-id="30a63-133">サポートされない</span><span class="sxs-lookup"><span data-stu-id="30a63-133">Not Supported</span></span>              | <span data-ttu-id="30a63-134">サポートされない</span><span class="sxs-lookup"><span data-stu-id="30a63-134">Not Supported</span></span>        |<span data-ttu-id="30a63-135">サポートされない</span><span class="sxs-lookup"><span data-stu-id="30a63-135">Not Supported</span></span>| <span data-ttu-id="30a63-136">サポートされる</span><span class="sxs-lookup"><span data-stu-id="30a63-136">Supported</span></span>|


## <a name="unsupported-dash-profiles"></a><span data-ttu-id="30a63-137">サポートされていない DASH プロファイル</span><span class="sxs-lookup"><span data-stu-id="30a63-137">Unsupported DASH profiles</span></span>
<span data-ttu-id="30a63-138">上の表に示されていないプロファイルはサポートされていません。これには、次のようなものが含まれますが、これらに限定されません。</span><span class="sxs-lookup"><span data-stu-id="30a63-138">Profiles not listed in the above table are unsupported, including but not limited to the following:</span></span>

* <span data-ttu-id="30a63-139">urn:mpeg&#58;dash:profile:full:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-139">urn:mpeg&#58;dash:profile:full:2011</span></span>
* <span data-ttu-id="30a63-140">urn:mpeg&#58;dash:profile:isoff-on-demand:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-140">urn:mpeg&#58;dash:profile:isoff-on-demand:2011</span></span>
* <span data-ttu-id="30a63-141">urn:mpeg&#58;dash:profile:mp2t-main:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-141">urn:mpeg&#58;dash:profile:mp2t-main:2011</span></span>
* <span data-ttu-id="30a63-142">urn:mpeg&#58;dash:profile:mp2t-simple:2011</span><span class="sxs-lookup"><span data-stu-id="30a63-142">urn:mpeg&#58;dash:profile:mp2t-simple:2011</span></span>


## <a name="related-topics"></a><span data-ttu-id="30a63-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="30a63-143">Related topics</span></span>

* [<span data-ttu-id="30a63-144">メディア再生</span><span class="sxs-lookup"><span data-stu-id="30a63-144">Media playback</span></span>](media-playback.md)
* [<span data-ttu-id="30a63-145">アダプティブ ストリーミング</span><span class="sxs-lookup"><span data-stu-id="30a63-145">Adaptive streaming</span></span>](adaptive-streaming.md)
 

 




