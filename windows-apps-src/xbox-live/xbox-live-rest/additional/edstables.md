---
title: EDS テーブル
assetID: 7fc0e498-9a45-61b9-a9b2-b7ceb8994e25
permalink: en-us/docs/xboxlive/rest/edstables.html
author: KevinAsgari
description: " EDS テーブル"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ae8c61d8afae6788f2f99e4e2beff262c011fc60
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3955975"
---
# <a name="eds-tables"></a><span data-ttu-id="08a52-104">EDS テーブル</span><span class="sxs-lookup"><span data-stu-id="08a52-104">EDS Tables</span></span>

  * [<span data-ttu-id="08a52-105">メディア項目のマップにメディア グループ</span><span class="sxs-lookup"><span data-stu-id="08a52-105">Media Group to Media Item Map</span></span>](#ID4EQ)
  * [<span data-ttu-id="08a52-106">有効なクライアントの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-106">Valid Client Type List</span></span>](#ID4EFD)
  * [<span data-ttu-id="08a52-107">有効なデバイスの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-107">Valid Device Type List</span></span>](#ID4EPE)
  * [<span data-ttu-id="08a52-108">入力方法の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-108">Input Method List</span></span>](#ID4ERF)

<a id="ID4EQ"></a>


## <a name="media-group-to-media-item-map"></a><span data-ttu-id="08a52-109">メディア項目のマップにメディア グループ</span><span class="sxs-lookup"><span data-stu-id="08a52-109">Media Group to Media Item Map</span></span>

| <span data-ttu-id="08a52-110">メディア グループ</span><span class="sxs-lookup"><span data-stu-id="08a52-110">Media Group</span></span>| <span data-ttu-id="08a52-111">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="08a52-111">Media Item Type</span></span>| 
| --- | --- |
| <span data-ttu-id="08a52-112">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="08a52-112">GameType</span></span>| <span data-ttu-id="08a52-113">Xbox360Game、XboxGameTrial、Xbox360GameContent、Xbox360GameDemo、XboxTheme、XboxOriginalGame、XboxGamerTile、XboxArcadeGame、XboxGameConsumable、XboxGameVideo、XboxGameTrailer、XboxBundle、XboxXnaCommunityGame、XboxMarketplace、AvatarItem、MobileGame、XboxMobilePDLC、XboxMobileConsumable、WebGame、MetroGame、MetroGameContent、MetroGameConsumable、DGame、DGameDemo、DConsumable、DDurable</span><span class="sxs-lookup"><span data-stu-id="08a52-113">Xbox360Game, XboxGameTrial, Xbox360GameContent, Xbox360GameDemo, XboxTheme, XboxOriginalGame, XboxGamerTile, XboxArcadeGame, XboxGameConsumable, XboxGameVideo, XboxGameTrailer, XboxBundle, XboxXnaCommunityGame, XboxMarketplace, AvatarItem, MobileGame, XboxMobilePDLC, XboxMobileConsumable, WebGame, MetroGame, MetroGameContent, MetroGameConsumable, DGame, DGameDemo, DConsumable, DDurable</span></span>|
| <span data-ttu-id="08a52-114">AppType</span><span class="sxs-lookup"><span data-stu-id="08a52-114">AppType</span></span>| <span data-ttu-id="08a52-115">XboxApp、DApp</span><span class="sxs-lookup"><span data-stu-id="08a52-115">XboxApp, DApp</span></span>|
| <span data-ttu-id="08a52-116">MovieType</span><span class="sxs-lookup"><span data-stu-id="08a52-116">MovieType</span></span>| <span data-ttu-id="08a52-117">映画</span><span class="sxs-lookup"><span data-stu-id="08a52-117">Movie</span></span>|
| <span data-ttu-id="08a52-118">TVType</span><span class="sxs-lookup"><span data-stu-id="08a52-118">TVType</span></span>| <span data-ttu-id="08a52-119">TVShow (1 回限りのテレビ番組) TVEpisode、TVSeries、TVSeason</span><span class="sxs-lookup"><span data-stu-id="08a52-119">TVShow (one-off TV shows), TVEpisode, TVSeries, TVSeason</span></span>|
| <span data-ttu-id="08a52-120">MusicType</span><span class="sxs-lookup"><span data-stu-id="08a52-120">MusicType</span></span>| <span data-ttu-id="08a52-121">アルバムのトラックで MusicVideo</span><span class="sxs-lookup"><span data-stu-id="08a52-121">Album, Track, MusicVideo</span></span>|
| <span data-ttu-id="08a52-122">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="08a52-122">MusicArtistType</span></span>| <span data-ttu-id="08a52-123">MusicArtist</span><span class="sxs-lookup"><span data-stu-id="08a52-123">MusicArtist</span></span>|
| <span data-ttu-id="08a52-124">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="08a52-124">WebVideoType</span></span>| <span data-ttu-id="08a52-125">WebVideo、WebVideoCollection</span><span class="sxs-lookup"><span data-stu-id="08a52-125">WebVideo, WebVideoCollection</span></span>|
| <span data-ttu-id="08a52-126">EnhancedContentType</span><span class="sxs-lookup"><span data-stu-id="08a52-126">EnhancedContentType</span></span>| <span data-ttu-id="08a52-127">GameLayer、GameActivity、AppActivity、VideoLayer、VideoActivity、DActivity、DNativeApp</span><span class="sxs-lookup"><span data-stu-id="08a52-127">GameLayer, GameActivity, AppActivity, VideoLayer, VideoActivity, DActivity, DNativeApp</span></span>|
| <span data-ttu-id="08a52-128">SubscriptionType</span><span class="sxs-lookup"><span data-stu-id="08a52-128">SubscriptionType</span></span>| <span data-ttu-id="08a52-129">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="08a52-129">Subscription</span></span>|

<a id="ID4EFD"></a>


## <a name="valid-client-type-list"></a><span data-ttu-id="08a52-130">有効なクライアントの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-130">Valid Client Type List</span></span>

   * <span data-ttu-id="08a52-131">App</span><span class="sxs-lookup"><span data-stu-id="08a52-131">App</span></span>
   * <span data-ttu-id="08a52-132">C13</span><span class="sxs-lookup"><span data-stu-id="08a52-132">C13</span></span>
   * <span data-ttu-id="08a52-133">CommercialService</span><span class="sxs-lookup"><span data-stu-id="08a52-133">CommercialService</span></span>
   * <span data-ttu-id="08a52-134">コンパニオン</span><span class="sxs-lookup"><span data-stu-id="08a52-134">Companion</span></span>
   * <span data-ttu-id="08a52-135">Console</span><span class="sxs-lookup"><span data-stu-id="08a52-135">Console</span></span>
   * <span data-ttu-id="08a52-136">刊行物</span><span class="sxs-lookup"><span data-stu-id="08a52-136">Editorial</span></span>
   * <span data-ttu-id="08a52-137">1stPartyApp</span><span class="sxs-lookup"><span data-stu-id="08a52-137">1stPartyApp</span></span>
   * <span data-ttu-id="08a52-138">MoLive</span><span class="sxs-lookup"><span data-stu-id="08a52-138">MoLive</span></span>
   * <span data-ttu-id="08a52-139">PhoneROM (Windows Phone 7)</span><span class="sxs-lookup"><span data-stu-id="08a52-139">PhoneROM (Windows Phone 7)</span></span>
   * <span data-ttu-id="08a52-140">RecommendationService</span><span class="sxs-lookup"><span data-stu-id="08a52-140">RecommendationService</span></span>
   * <span data-ttu-id="08a52-141">SAS</span><span class="sxs-lookup"><span data-stu-id="08a52-141">SAS</span></span>
   * <span data-ttu-id="08a52-142">SDS</span><span class="sxs-lookup"><span data-stu-id="08a52-142">SDS</span></span>
   * <span data-ttu-id="08a52-143">SubscriptionService</span><span class="sxs-lookup"><span data-stu-id="08a52-143">SubscriptionService</span></span>
   * <span data-ttu-id="08a52-144">X8</span><span class="sxs-lookup"><span data-stu-id="08a52-144">X8</span></span>
   * <span data-ttu-id="08a52-145">X13</span><span class="sxs-lookup"><span data-stu-id="08a52-145">X13</span></span>
   * <span data-ttu-id="08a52-146">Webblend</span><span class="sxs-lookup"><span data-stu-id="08a52-146">Webblend</span></span>
   * <span data-ttu-id="08a52-147">XboxCom</span><span class="sxs-lookup"><span data-stu-id="08a52-147">XboxCom</span></span>

<a id="ID4EPE"></a>


## <a name="valid-device-type-list"></a><span data-ttu-id="08a52-148">有効なデバイスの種類の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-148">Valid Device Type List</span></span>

   * <span data-ttu-id="08a52-149">Xbox360</span><span class="sxs-lookup"><span data-stu-id="08a52-149">Xbox360</span></span>
   * <span data-ttu-id="08a52-150">XboxDurango</span><span class="sxs-lookup"><span data-stu-id="08a52-150">XboxDurango</span></span>
   * <span data-ttu-id="08a52-151">Xbox</span><span class="sxs-lookup"><span data-stu-id="08a52-151">Xbox</span></span>
   * <span data-ttu-id="08a52-152">iOS</span><span class="sxs-lookup"><span data-stu-id="08a52-152">iOS</span></span>
   * <span data-ttu-id="08a52-153">iPhone</span><span class="sxs-lookup"><span data-stu-id="08a52-153">iPhone</span></span>
   * <span data-ttu-id="08a52-154">iPad</span><span class="sxs-lookup"><span data-stu-id="08a52-154">iPad</span></span>
   * <span data-ttu-id="08a52-155">Android</span><span class="sxs-lookup"><span data-stu-id="08a52-155">Android</span></span>
   * <span data-ttu-id="08a52-156">AndroidPhone</span><span class="sxs-lookup"><span data-stu-id="08a52-156">AndroidPhone</span></span>
   * <span data-ttu-id="08a52-157">AndroidSlate</span><span class="sxs-lookup"><span data-stu-id="08a52-157">AndroidSlate</span></span>
   * <span data-ttu-id="08a52-158">WindowsPC</span><span class="sxs-lookup"><span data-stu-id="08a52-158">WindowsPC</span></span>
   * <span data-ttu-id="08a52-159">WindowsPhone</span><span class="sxs-lookup"><span data-stu-id="08a52-159">WindowsPhone</span></span>
   * <span data-ttu-id="08a52-160">サービス</span><span class="sxs-lookup"><span data-stu-id="08a52-160">Service</span></span>
   * <span data-ttu-id="08a52-161">Web</span><span class="sxs-lookup"><span data-stu-id="08a52-161">Web</span></span>

<a id="ID4ERF"></a>


## <a name="input-method-list"></a><span data-ttu-id="08a52-162">入力方法の一覧</span><span class="sxs-lookup"><span data-stu-id="08a52-162">Input Method List</span></span>

   * <span data-ttu-id="08a52-163">管理者</span><span class="sxs-lookup"><span data-stu-id="08a52-163">Controller</span></span>
   * <span data-ttu-id="08a52-164">ControllerAutoSuggest</span><span class="sxs-lookup"><span data-stu-id="08a52-164">ControllerAutoSuggest</span></span>
   * <span data-ttu-id="08a52-165">ジェスチャ</span><span class="sxs-lookup"><span data-stu-id="08a52-165">Gesture</span></span>
   * <span data-ttu-id="08a52-166">GestureAutoSuggest</span><span class="sxs-lookup"><span data-stu-id="08a52-166">GestureAutoSuggest</span></span>
   * <span data-ttu-id="08a52-167">音声</span><span class="sxs-lookup"><span data-stu-id="08a52-167">Voice</span></span>
   * <span data-ttu-id="08a52-168">タッチ</span><span class="sxs-lookup"><span data-stu-id="08a52-168">Touch</span></span>
   * <span data-ttu-id="08a52-169">マウス</span><span class="sxs-lookup"><span data-stu-id="08a52-169">Mouse</span></span>
   * <span data-ttu-id="08a52-170">キーボード</span><span class="sxs-lookup"><span data-stu-id="08a52-170">Keyboard</span></span>

<a id="ID4EJG"></a>


## <a name="see-also"></a><span data-ttu-id="08a52-171">関連項目</span><span class="sxs-lookup"><span data-stu-id="08a52-171">See also</span></span>

<a id="ID4ELG"></a>


##### <a name="parent"></a><span data-ttu-id="08a52-172">Parent</span><span class="sxs-lookup"><span data-stu-id="08a52-172">Parent</span></span>  

[<span data-ttu-id="08a52-173">その他の参照</span><span class="sxs-lookup"><span data-stu-id="08a52-173">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)


<a id="ID4EXG"></a>


##### <a name="further-information"></a><span data-ttu-id="08a52-174">詳細情報</span><span class="sxs-lookup"><span data-stu-id="08a52-174">Further Information</span></span>

[<span data-ttu-id="08a52-175">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="08a52-175">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)
