---
title: EDS の表
assetID: 7fc0e498-9a45-61b9-a9b2-b7ceb8994e25
permalink: en-us/docs/xboxlive/rest/edstables.html
author: KevinAsgari
description: " EDS の表"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ae8c61d8afae6788f2f99e4e2beff262c011fc60
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209279"
---
# <a name="eds-tables"></a><span data-ttu-id="12429-104">EDS の表</span><span class="sxs-lookup"><span data-stu-id="12429-104">EDS Tables</span></span>

  * [<span data-ttu-id="12429-105">メディア項目のマップにメディア グループ</span><span class="sxs-lookup"><span data-stu-id="12429-105">Media Group to Media Item Map</span></span>](#ID4EQ)
  * [<span data-ttu-id="12429-106">有効なクライアントの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-106">Valid Client Type List</span></span>](#ID4EFD)
  * [<span data-ttu-id="12429-107">有効なデバイスの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-107">Valid Device Type List</span></span>](#ID4EPE)
  * [<span data-ttu-id="12429-108">入力方法の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-108">Input Method List</span></span>](#ID4ERF)

<a id="ID4EQ"></a>


## <a name="media-group-to-media-item-map"></a><span data-ttu-id="12429-109">メディア項目のマップにメディア グループ</span><span class="sxs-lookup"><span data-stu-id="12429-109">Media Group to Media Item Map</span></span>

| <span data-ttu-id="12429-110">メディア グループ</span><span class="sxs-lookup"><span data-stu-id="12429-110">Media Group</span></span>| <span data-ttu-id="12429-111">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="12429-111">Media Item Type</span></span>| 
| --- | --- |
| <span data-ttu-id="12429-112">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="12429-112">GameType</span></span>| <span data-ttu-id="12429-113">Xbox360Game、XboxGameTrial、Xbox360GameContent、Xbox360GameDemo、XboxTheme、XboxOriginalGame、XboxGamerTile、XboxArcadeGame、XboxGameConsumable、XboxGameVideo、XboxGameTrailer、XboxBundle、XboxXnaCommunityGame、XboxMarketplace、AvatarItem、MobileGame、XboxMobilePDLC、XboxMobileConsumable、WebGame、MetroGame、MetroGameContent、MetroGameConsumable、DGame、DGameDemo、DConsumable、DDurable</span><span class="sxs-lookup"><span data-stu-id="12429-113">Xbox360Game, XboxGameTrial, Xbox360GameContent, Xbox360GameDemo, XboxTheme, XboxOriginalGame, XboxGamerTile, XboxArcadeGame, XboxGameConsumable, XboxGameVideo, XboxGameTrailer, XboxBundle, XboxXnaCommunityGame, XboxMarketplace, AvatarItem, MobileGame, XboxMobilePDLC, XboxMobileConsumable, WebGame, MetroGame, MetroGameContent, MetroGameConsumable, DGame, DGameDemo, DConsumable, DDurable</span></span>|
| <span data-ttu-id="12429-114">AppType</span><span class="sxs-lookup"><span data-stu-id="12429-114">AppType</span></span>| <span data-ttu-id="12429-115">XboxApp、DApp</span><span class="sxs-lookup"><span data-stu-id="12429-115">XboxApp, DApp</span></span>|
| <span data-ttu-id="12429-116">MovieType</span><span class="sxs-lookup"><span data-stu-id="12429-116">MovieType</span></span>| <span data-ttu-id="12429-117">映画</span><span class="sxs-lookup"><span data-stu-id="12429-117">Movie</span></span>|
| <span data-ttu-id="12429-118">TVType</span><span class="sxs-lookup"><span data-stu-id="12429-118">TVType</span></span>| <span data-ttu-id="12429-119">TVShow (1 回限りのテレビ番組) TVEpisode、TVSeries、TVSeason</span><span class="sxs-lookup"><span data-stu-id="12429-119">TVShow (one-off TV shows), TVEpisode, TVSeries, TVSeason</span></span>|
| <span data-ttu-id="12429-120">MusicType</span><span class="sxs-lookup"><span data-stu-id="12429-120">MusicType</span></span>| <span data-ttu-id="12429-121">アルバムのトラックで MusicVideo</span><span class="sxs-lookup"><span data-stu-id="12429-121">Album, Track, MusicVideo</span></span>|
| <span data-ttu-id="12429-122">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="12429-122">MusicArtistType</span></span>| <span data-ttu-id="12429-123">MusicArtist</span><span class="sxs-lookup"><span data-stu-id="12429-123">MusicArtist</span></span>|
| <span data-ttu-id="12429-124">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="12429-124">WebVideoType</span></span>| <span data-ttu-id="12429-125">WebVideo、WebVideoCollection</span><span class="sxs-lookup"><span data-stu-id="12429-125">WebVideo, WebVideoCollection</span></span>|
| <span data-ttu-id="12429-126">EnhancedContentType</span><span class="sxs-lookup"><span data-stu-id="12429-126">EnhancedContentType</span></span>| <span data-ttu-id="12429-127">GameLayer、GameActivity、AppActivity、VideoLayer、VideoActivity、DActivity、DNativeApp</span><span class="sxs-lookup"><span data-stu-id="12429-127">GameLayer, GameActivity, AppActivity, VideoLayer, VideoActivity, DActivity, DNativeApp</span></span>|
| <span data-ttu-id="12429-128">SubscriptionType</span><span class="sxs-lookup"><span data-stu-id="12429-128">SubscriptionType</span></span>| <span data-ttu-id="12429-129">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="12429-129">Subscription</span></span>|

<a id="ID4EFD"></a>


## <a name="valid-client-type-list"></a><span data-ttu-id="12429-130">有効なクライアントの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-130">Valid Client Type List</span></span>

   * <span data-ttu-id="12429-131">App</span><span class="sxs-lookup"><span data-stu-id="12429-131">App</span></span>
   * <span data-ttu-id="12429-132">C13</span><span class="sxs-lookup"><span data-stu-id="12429-132">C13</span></span>
   * <span data-ttu-id="12429-133">CommercialService</span><span class="sxs-lookup"><span data-stu-id="12429-133">CommercialService</span></span>
   * <span data-ttu-id="12429-134">コンパニオン</span><span class="sxs-lookup"><span data-stu-id="12429-134">Companion</span></span>
   * <span data-ttu-id="12429-135">Console</span><span class="sxs-lookup"><span data-stu-id="12429-135">Console</span></span>
   * <span data-ttu-id="12429-136">刊行物</span><span class="sxs-lookup"><span data-stu-id="12429-136">Editorial</span></span>
   * <span data-ttu-id="12429-137">1stPartyApp</span><span class="sxs-lookup"><span data-stu-id="12429-137">1stPartyApp</span></span>
   * <span data-ttu-id="12429-138">MoLive</span><span class="sxs-lookup"><span data-stu-id="12429-138">MoLive</span></span>
   * <span data-ttu-id="12429-139">PhoneROM (Windows Phone 7)</span><span class="sxs-lookup"><span data-stu-id="12429-139">PhoneROM (Windows Phone 7)</span></span>
   * <span data-ttu-id="12429-140">RecommendationService</span><span class="sxs-lookup"><span data-stu-id="12429-140">RecommendationService</span></span>
   * <span data-ttu-id="12429-141">SAS</span><span class="sxs-lookup"><span data-stu-id="12429-141">SAS</span></span>
   * <span data-ttu-id="12429-142">SDS</span><span class="sxs-lookup"><span data-stu-id="12429-142">SDS</span></span>
   * <span data-ttu-id="12429-143">SubscriptionService</span><span class="sxs-lookup"><span data-stu-id="12429-143">SubscriptionService</span></span>
   * <span data-ttu-id="12429-144">X8</span><span class="sxs-lookup"><span data-stu-id="12429-144">X8</span></span>
   * <span data-ttu-id="12429-145">X13</span><span class="sxs-lookup"><span data-stu-id="12429-145">X13</span></span>
   * <span data-ttu-id="12429-146">Webblend</span><span class="sxs-lookup"><span data-stu-id="12429-146">Webblend</span></span>
   * <span data-ttu-id="12429-147">XboxCom</span><span class="sxs-lookup"><span data-stu-id="12429-147">XboxCom</span></span>

<a id="ID4EPE"></a>


## <a name="valid-device-type-list"></a><span data-ttu-id="12429-148">有効なデバイスの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-148">Valid Device Type List</span></span>

   * <span data-ttu-id="12429-149">Xbox360</span><span class="sxs-lookup"><span data-stu-id="12429-149">Xbox360</span></span>
   * <span data-ttu-id="12429-150">XboxDurango</span><span class="sxs-lookup"><span data-stu-id="12429-150">XboxDurango</span></span>
   * <span data-ttu-id="12429-151">Xbox</span><span class="sxs-lookup"><span data-stu-id="12429-151">Xbox</span></span>
   * <span data-ttu-id="12429-152">iOS</span><span class="sxs-lookup"><span data-stu-id="12429-152">iOS</span></span>
   * <span data-ttu-id="12429-153">iPhone</span><span class="sxs-lookup"><span data-stu-id="12429-153">iPhone</span></span>
   * <span data-ttu-id="12429-154">iPad</span><span class="sxs-lookup"><span data-stu-id="12429-154">iPad</span></span>
   * <span data-ttu-id="12429-155">Android</span><span class="sxs-lookup"><span data-stu-id="12429-155">Android</span></span>
   * <span data-ttu-id="12429-156">AndroidPhone</span><span class="sxs-lookup"><span data-stu-id="12429-156">AndroidPhone</span></span>
   * <span data-ttu-id="12429-157">AndroidSlate</span><span class="sxs-lookup"><span data-stu-id="12429-157">AndroidSlate</span></span>
   * <span data-ttu-id="12429-158">WindowsPC</span><span class="sxs-lookup"><span data-stu-id="12429-158">WindowsPC</span></span>
   * <span data-ttu-id="12429-159">WindowsPhone</span><span class="sxs-lookup"><span data-stu-id="12429-159">WindowsPhone</span></span>
   * <span data-ttu-id="12429-160">サービス</span><span class="sxs-lookup"><span data-stu-id="12429-160">Service</span></span>
   * <span data-ttu-id="12429-161">Web</span><span class="sxs-lookup"><span data-stu-id="12429-161">Web</span></span>

<a id="ID4ERF"></a>


## <a name="input-method-list"></a><span data-ttu-id="12429-162">入力方法の一覧</span><span class="sxs-lookup"><span data-stu-id="12429-162">Input Method List</span></span>

   * <span data-ttu-id="12429-163">管理者</span><span class="sxs-lookup"><span data-stu-id="12429-163">Controller</span></span>
   * <span data-ttu-id="12429-164">ControllerAutoSuggest</span><span class="sxs-lookup"><span data-stu-id="12429-164">ControllerAutoSuggest</span></span>
   * <span data-ttu-id="12429-165">ジェスチャ</span><span class="sxs-lookup"><span data-stu-id="12429-165">Gesture</span></span>
   * <span data-ttu-id="12429-166">GestureAutoSuggest</span><span class="sxs-lookup"><span data-stu-id="12429-166">GestureAutoSuggest</span></span>
   * <span data-ttu-id="12429-167">音声</span><span class="sxs-lookup"><span data-stu-id="12429-167">Voice</span></span>
   * <span data-ttu-id="12429-168">タッチ</span><span class="sxs-lookup"><span data-stu-id="12429-168">Touch</span></span>
   * <span data-ttu-id="12429-169">マウス</span><span class="sxs-lookup"><span data-stu-id="12429-169">Mouse</span></span>
   * <span data-ttu-id="12429-170">キーボード</span><span class="sxs-lookup"><span data-stu-id="12429-170">Keyboard</span></span>

<a id="ID4EJG"></a>


## <a name="see-also"></a><span data-ttu-id="12429-171">関連項目</span><span class="sxs-lookup"><span data-stu-id="12429-171">See also</span></span>

<a id="ID4ELG"></a>


##### <a name="parent"></a><span data-ttu-id="12429-172">Parent</span><span class="sxs-lookup"><span data-stu-id="12429-172">Parent</span></span>  

[<span data-ttu-id="12429-173">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="12429-173">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)


<a id="ID4EXG"></a>


##### <a name="further-information"></a><span data-ttu-id="12429-174">詳細情報</span><span class="sxs-lookup"><span data-stu-id="12429-174">Further Information</span></span>

[<span data-ttu-id="12429-175">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="12429-175">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)
