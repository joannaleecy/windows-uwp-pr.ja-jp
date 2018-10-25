---
title: inventoryItem (JSON)
assetID: 446cca28-b2d3-1b84-f973-94065519b391
permalink: en-us/docs/xboxlive/rest/json-inventoryitem.html
author: KevinAsgari
description: " inventoryItem (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0a7521de7da4ebd31f0a1d8c59bb7c0134eddc08
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5481936"
---
# <a name="inventoryitem-json"></a><span data-ttu-id="7ab64-104">inventoryItem (JSON)</span><span class="sxs-lookup"><span data-stu-id="7ab64-104">inventoryItem (JSON)</span></span>
<span data-ttu-id="7ab64-105">コアのインベントリ項目の権利を付与できる標準の項目を表します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-105">The core inventory item represents the standard item on which an entitlement can be granted.</span></span>
<a id="ID4EN"></a>


## <a name="inventoryitem"></a><span data-ttu-id="7ab64-106">inventoryItem</span><span class="sxs-lookup"><span data-stu-id="7ab64-106">inventoryItem</span></span>

<span data-ttu-id="7ab64-107">InventoryItem オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7ab64-107">The inventoryItem object has the following specification.</span></span>

| <span data-ttu-id="7ab64-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7ab64-108">Member</span></span>| <span data-ttu-id="7ab64-109">種類</span><span class="sxs-lookup"><span data-stu-id="7ab64-109">Type</span></span>| <span data-ttu-id="7ab64-110">説明</span><span class="sxs-lookup"><span data-stu-id="7ab64-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="7ab64-111">url</span><span class="sxs-lookup"><span data-stu-id="7ab64-111">url</span></span>| <span data-ttu-id="7ab64-112">string</span><span class="sxs-lookup"><span data-stu-id="7ab64-112">string</span></span>| <span data-ttu-id="7ab64-113">この特定のインベントリ項目の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="7ab64-113">Unique identifier for this specific inventory item.</span></span>|
| <span data-ttu-id="7ab64-114">itemType</span><span class="sxs-lookup"><span data-stu-id="7ab64-114">itemType</span></span>| <span data-ttu-id="7ab64-115">string</span><span class="sxs-lookup"><span data-stu-id="7ab64-115">string</span></span>| <span data-ttu-id="7ab64-116">項目の種類です。</span><span class="sxs-lookup"><span data-stu-id="7ab64-116">Type of the item.</span></span> <span data-ttu-id="7ab64-117">現在の値します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-117">Current values are</span></span> <ul><li><b><span data-ttu-id="7ab64-118">Unknown</span><span class="sxs-lookup"><span data-stu-id="7ab64-118">Unknown</span></span></b></li><li><b><span data-ttu-id="7ab64-119">Game</span><span class="sxs-lookup"><span data-stu-id="7ab64-119">Game</span></span></b></li><li><b><span data-ttu-id="7ab64-120">映画</span><span class="sxs-lookup"><span data-stu-id="7ab64-120">Movie</span></span></b></li><li> <b><span data-ttu-id="7ab64-121">TVShow</span><span class="sxs-lookup"><span data-stu-id="7ab64-121">TVShow</span></span></b></li><li><b><span data-ttu-id="7ab64-122">MusicVideo</span><span class="sxs-lookup"><span data-stu-id="7ab64-122">MusicVideo</span></span></b></li><li><b><span data-ttu-id="7ab64-123">GameTrial</span><span class="sxs-lookup"><span data-stu-id="7ab64-123">GameTrial</span></span></b></li><li><b><span data-ttu-id="7ab64-124">ViralVideo</span><span class="sxs-lookup"><span data-stu-id="7ab64-124">ViralVideo</span></span></b></li><li><b><span data-ttu-id="7ab64-125">TVEpisode</span><span class="sxs-lookup"><span data-stu-id="7ab64-125">TVEpisode</span></span></b></li><li><b><span data-ttu-id="7ab64-126">TVSeason</span><span class="sxs-lookup"><span data-stu-id="7ab64-126">TVSeason</span></span></b></li><li><b><span data-ttu-id="7ab64-127">TVSeries</span><span class="sxs-lookup"><span data-stu-id="7ab64-127">TVSeries</span></span></b></li><li><b><span data-ttu-id="7ab64-128">VideoPreview</span><span class="sxs-lookup"><span data-stu-id="7ab64-128">VideoPreview</span></span></b></li><li><b><span data-ttu-id="7ab64-129">ポスター</span><span class="sxs-lookup"><span data-stu-id="7ab64-129">Poster</span></span></b></li><li><b><span data-ttu-id="7ab64-130">ポッド キャスト</span><span class="sxs-lookup"><span data-stu-id="7ab64-130">Podcast</span></span></b></li><li><b><span data-ttu-id="7ab64-131">画像</span><span class="sxs-lookup"><span data-stu-id="7ab64-131">Image</span></span></b></li><li><b><span data-ttu-id="7ab64-132">BoxArt</span><span class="sxs-lookup"><span data-stu-id="7ab64-132">BoxArt</span></span></b></li><li><b><span data-ttu-id="7ab64-133">ArtistPicture</span><span class="sxs-lookup"><span data-stu-id="7ab64-133">ArtistPicture</span></span></b></li><li><b><span data-ttu-id="7ab64-134">GameContent</span><span class="sxs-lookup"><span data-stu-id="7ab64-134">GameContent</span></span></b></li><li><b><span data-ttu-id="7ab64-135">GameDemo</span><span class="sxs-lookup"><span data-stu-id="7ab64-135">GameDemo</span></span></b></li><li><b><span data-ttu-id="7ab64-136">Theme</span><span class="sxs-lookup"><span data-stu-id="7ab64-136">Theme</span></span></b></li><li><b><span data-ttu-id="7ab64-137">XboxOriginalGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-137">XboxOriginalGame</span></span></b></li><li><b><span data-ttu-id="7ab64-138">GamerTile</span><span class="sxs-lookup"><span data-stu-id="7ab64-138">GamerTile</span></span></b></li><li><b><span data-ttu-id="7ab64-139">ArcadeGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-139">ArcadeGame</span></span></b></li><li><b><span data-ttu-id="7ab64-140">GameConsumable</span><span class="sxs-lookup"><span data-stu-id="7ab64-140">GameConsumable</span></span></b></li><li><b><span data-ttu-id="7ab64-141">アルバム</span><span class="sxs-lookup"><span data-stu-id="7ab64-141">Album</span></span></b></li><li><b><span data-ttu-id="7ab64-142">AlbumDisc</span><span class="sxs-lookup"><span data-stu-id="7ab64-142">AlbumDisc</span></span></b></li><li><b><span data-ttu-id="7ab64-143">AlbumArt</span><span class="sxs-lookup"><span data-stu-id="7ab64-143">AlbumArt</span></span></b></li><li><b><span data-ttu-id="7ab64-144">GameVideo</span><span class="sxs-lookup"><span data-stu-id="7ab64-144">GameVideo</span></span></b></li><li><b><span data-ttu-id="7ab64-145">BackgroundArt</span><span class="sxs-lookup"><span data-stu-id="7ab64-145">BackgroundArt</span></span></b></li><li><b><span data-ttu-id="7ab64-146">TVTrailer</span><span class="sxs-lookup"><span data-stu-id="7ab64-146">TVTrailer</span></span></b></li><li><b><span data-ttu-id="7ab64-147">GameTrailer</span><span class="sxs-lookup"><span data-stu-id="7ab64-147">GameTrailer</span></span></b></li><li><b><span data-ttu-id="7ab64-148">VideoShort</span><span class="sxs-lookup"><span data-stu-id="7ab64-148">VideoShort</span></span></b></li><li><b><span data-ttu-id="7ab64-149">バンドル</span><span class="sxs-lookup"><span data-stu-id="7ab64-149">Bundle</span></span></b></li><li><b><span data-ttu-id="7ab64-150">XnaCommunityGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-150">XnaCommunityGame</span></span></b></li><li><b><span data-ttu-id="7ab64-151">プロモーション</span><span class="sxs-lookup"><span data-stu-id="7ab64-151">Promotional</span></span></b></li><li><b><span data-ttu-id="7ab64-152">MovieTrailer</span><span class="sxs-lookup"><span data-stu-id="7ab64-152">MovieTrailer</span></span></b></li><li><b><span data-ttu-id="7ab64-153">SlideshowPreviewImage</span><span class="sxs-lookup"><span data-stu-id="7ab64-153">SlideshowPreviewImage</span></span></b></li><li><b><span data-ttu-id="7ab64-154">ServerBackedGames</span><span class="sxs-lookup"><span data-stu-id="7ab64-154">ServerBackedGames</span></span></b></li><li><b><span data-ttu-id="7ab64-155">Marketplace</span><span class="sxs-lookup"><span data-stu-id="7ab64-155">Marketplace</span></span></b></li><li><b><span data-ttu-id="7ab64-156">AvatarItem</span><span class="sxs-lookup"><span data-stu-id="7ab64-156">AvatarItem</span></span></b></li><li><b><span data-ttu-id="7ab64-157">LiveApp</span><span class="sxs-lookup"><span data-stu-id="7ab64-157">LiveApp</span></span></b></li><li><b><span data-ttu-id="7ab64-158">WebGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-158">WebGame</span></span></b></li><li><b><span data-ttu-id="7ab64-159">MobileGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-159">MobileGame</span></span></b></li><li><b><span data-ttu-id="7ab64-160">MobilePdlc</span><span class="sxs-lookup"><span data-stu-id="7ab64-160">MobilePdlc</span></span></b></li><li><b><span data-ttu-id="7ab64-161">MobileConsumable</span><span class="sxs-lookup"><span data-stu-id="7ab64-161">MobileConsumable</span></span></b></li><li><b><span data-ttu-id="7ab64-162">App</span><span class="sxs-lookup"><span data-stu-id="7ab64-162">App</span></span></b></li><li><b><span data-ttu-id="7ab64-163">MetroGame</span><span class="sxs-lookup"><span data-stu-id="7ab64-163">MetroGame</span></span></b></li><li><b><span data-ttu-id="7ab64-164">MetroGameContent</span><span class="sxs-lookup"><span data-stu-id="7ab64-164">MetroGameContent</span></span></b></li><li><b><span data-ttu-id="7ab64-165">MetroGameConsumable</span><span class="sxs-lookup"><span data-stu-id="7ab64-165">MetroGameConsumable</span></span></b></li><li><b><span data-ttu-id="7ab64-166">GameLayer</span><span class="sxs-lookup"><span data-stu-id="7ab64-166">GameLayer</span></span></b></li><li><b><span data-ttu-id="7ab64-167">GameActivity</span><span class="sxs-lookup"><span data-stu-id="7ab64-167">GameActivity</span></span></b></li><li><b><span data-ttu-id="7ab64-168">GameV2</span><span class="sxs-lookup"><span data-stu-id="7ab64-168">GameV2</span></span></b></li><li><b><span data-ttu-id="7ab64-169">SubscriptionV2</span><span class="sxs-lookup"><span data-stu-id="7ab64-169">SubscriptionV2</span></span></b></li><li><b><span data-ttu-id="7ab64-170">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="7ab64-170">Subscription</span></span></b><br/><br/> <span data-ttu-id="7ab64-171">**注:** ゲームが**GameV2**によって指定される、コンシューマブルなアドオンです**GameConsumable**、永続的な DLC が**GameContent**します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-171">**Note:** Games are designated by **GameV2**, consumables are **GameConsumable**, and durable DLC is **GameContent**.</span></span> |
  | <span data-ttu-id="7ab64-172">コンテナー</span><span class="sxs-lookup"><span data-stu-id="7ab64-172">containers</span></span> | <span data-ttu-id="7ab64-173">string</span><span class="sxs-lookup"><span data-stu-id="7ab64-173">string</span></span> | <span data-ttu-id="7ab64-174">これは、この項目を含む「コンテナー」のセットです。</span><span class="sxs-lookup"><span data-stu-id="7ab64-174">This is the set of "containers" that contain this item.</span></span> <span data-ttu-id="7ab64-175">特定のコンテナーに参加している項目は、ユーザーのインベントリを照会できます。</span><span class="sxs-lookup"><span data-stu-id="7ab64-175">A user's inventory can be queried for items that belong to a specific container.</span></span> <span data-ttu-id="7ab64-176">これらのコンテナーは、項目に追加されると、インベントリの購入によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="7ab64-176">These containers are determined when the item is added to the inventory by purchase.</span></span> |
  | <span data-ttu-id="7ab64-177">取得</span><span class="sxs-lookup"><span data-stu-id="7ab64-177">obtained</span></span> | <span data-ttu-id="7ab64-178">DateTime</span><span class="sxs-lookup"><span data-stu-id="7ab64-178">DateTime</span></span> | <span data-ttu-id="7ab64-179">日付と時刻の項目は、ユーザーのインベントリに追加されました。</span><span class="sxs-lookup"><span data-stu-id="7ab64-179">Date and time the item was added to the user's inventory.</span></span> |
  | <span data-ttu-id="7ab64-180">startDate</span><span class="sxs-lookup"><span data-stu-id="7ab64-180">startDate</span></span> | <span data-ttu-id="7ab64-181">DateTime</span><span class="sxs-lookup"><span data-stu-id="7ab64-181">DateTime</span></span> | <span data-ttu-id="7ab64-182">日付と時刻になった、または使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="7ab64-182">Date and time the item became or will become available for use.</span></span> |
  | <span data-ttu-id="7ab64-183">endDate</span><span class="sxs-lookup"><span data-stu-id="7ab64-183">endDate</span></span> | <span data-ttu-id="7ab64-184">DateTime</span><span class="sxs-lookup"><span data-stu-id="7ab64-184">DateTime</span></span> | <span data-ttu-id="7ab64-185">日付と時刻になった、または使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="7ab64-185">Date and time the item became or will become unusable.</span></span> |
  | <span data-ttu-id="7ab64-186">状態</span><span class="sxs-lookup"><span data-stu-id="7ab64-186">state</span></span> | <span data-ttu-id="7ab64-187">string</span><span class="sxs-lookup"><span data-stu-id="7ab64-187">string</span></span> | <span data-ttu-id="7ab64-188">項目の状態。</span><span class="sxs-lookup"><span data-stu-id="7ab64-188">The state of the item.</span></span> <span data-ttu-id="7ab64-189">値は**有効になっている**、**中断**、**有効期限が切れて**、**キャンセル**、**更新**を許可します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-189">Allowed values are **Enabled**, **Suspended**, **Expired**, **Canceled**, **Renewed**.</span></span>  |
  | <span data-ttu-id="7ab64-190">trial</span><span class="sxs-lookup"><span data-stu-id="7ab64-190">trial</span></span> | <span data-ttu-id="7ab64-191">ブール値</span><span class="sxs-lookup"><span data-stu-id="7ab64-191">Boolean value</span></span> | <span data-ttu-id="7ab64-192">必須。</span><span class="sxs-lookup"><span data-stu-id="7ab64-192">Required.</span></span> <span data-ttu-id="7ab64-193">この権利が、試用版である場合は true。それ以外の場合は false です。</span><span class="sxs-lookup"><span data-stu-id="7ab64-193">True if this entitlement is a trial; otherwise, false.</span></span> <span data-ttu-id="7ab64-194">権利の試用版を購入し、通常版を購入する場合は、両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7ab64-194">If you buy the trial version of an entitlement and then buy the full version, you will receive both.</span></span> |
  | <span data-ttu-id="7ab64-195">trialTimeRemaining</span><span class="sxs-lookup"><span data-stu-id="7ab64-195">trialTimeRemaining</span></span> | <span data-ttu-id="7ab64-196">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="7ab64-196">TimeSpan</span></span> | <span data-ttu-id="7ab64-197">Null 許容します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-197">Nullable.</span></span> <span data-ttu-id="7ab64-198">どのくらいの時間は、分単位で、試用版に残っています。</span><span class="sxs-lookup"><span data-stu-id="7ab64-198">How much time is remaining on the trial, in minutes.</span></span> |
  | <span data-ttu-id="7ab64-199">コンシューマブル</span><span class="sxs-lookup"><span data-stu-id="7ab64-199">consumable</span></span> | <span data-ttu-id="7ab64-200">array</span><span class="sxs-lookup"><span data-stu-id="7ab64-200">array</span></span> | <span data-ttu-id="7ab64-201">項目がコンシューマブルの場合は、その現在の数量と同様に、コンシューマブルなインベントリ項目の一意の識別子 (リンク) の場合は、なインライン表現が含まれます。</span><span class="sxs-lookup"><span data-stu-id="7ab64-201">If the items is consumable, this contains an inline representation of the unique identifier (link) for the consumable inventory item, as well as its current quantity.</span></span> |

<a id="ID4EMAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="7ab64-202">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7ab64-202">Sample JSON syntax</span></span>


```json
inventoryItem {
  "url": string,
  "itemType": "Music" | "Video" | "Game" | "AvatarItem" | "Subscription" | "DLC" | "Consumable" | ...,
  "obtained": DateTime,
  "beginDate": DateTime,
  "endDate": DateTime,
  "state": "Unavailable" | "Available" | "Suspended" | "Expired",
  "trial": true,
  "trialTimeRemaining":"23:12:14",
  ("consumable": {"url": string, "quantity": int})
}

```


<a id="ID4EVAAC"></a>


## <a name="consumable-inventory-item"></a><span data-ttu-id="7ab64-203">コンシューマブルなインベントリ項目</span><span class="sxs-lookup"><span data-stu-id="7ab64-203">Consumable inventory item</span></span>

<span data-ttu-id="7ab64-204">コンシューマブルなエンティティは、最小限のコンシューマブルな項目のプロパティの設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="7ab64-204">The consumable entity presents the minimal set of properties for a consumable item.</span></span>

| <span data-ttu-id="7ab64-205">メンバー</span><span class="sxs-lookup"><span data-stu-id="7ab64-205">Member</span></span>| <span data-ttu-id="7ab64-206">種類</span><span class="sxs-lookup"><span data-stu-id="7ab64-206">Type</span></span>| <span data-ttu-id="7ab64-207">説明</span><span class="sxs-lookup"><span data-stu-id="7ab64-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="7ab64-208">url</span><span class="sxs-lookup"><span data-stu-id="7ab64-208">url</span></span>| <span data-ttu-id="7ab64-209">string</span><span class="sxs-lookup"><span data-stu-id="7ab64-209">string</span></span>| <span data-ttu-id="7ab64-210">特定のコンシューマブルなインベントリ項目の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="7ab64-210">Unique identifier for the specific consumable inventory item.</span></span>|
| <span data-ttu-id="7ab64-211">quantity</span><span class="sxs-lookup"><span data-stu-id="7ab64-211">quantity</span></span>| <span data-ttu-id="7ab64-212">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="7ab64-212">32-bit signed integer</span></span>| <span data-ttu-id="7ab64-213">このインベントリ アイテムの現在の数量。</span><span class="sxs-lookup"><span data-stu-id="7ab64-213">The current quantity of this inventory item.</span></span>|


```json
consumableInventoryItem {
  "url": string,
  "quantity": int
}

```


<a id="ID4E4BAC"></a>


## <a name="see-also"></a><span data-ttu-id="7ab64-214">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ab64-214">See also</span></span>

<a id="ID4E6BAC"></a>


##### <a name="parent"></a><span data-ttu-id="7ab64-215">Parent</span><span class="sxs-lookup"><span data-stu-id="7ab64-215">Parent</span></span>

[<span data-ttu-id="7ab64-216">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7ab64-216">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EJCAC"></a>


##### <a name="reference"></a><span data-ttu-id="7ab64-217">リファレンス</span><span class="sxs-lookup"><span data-stu-id="7ab64-217">Reference</span></span>

[<span data-ttu-id="7ab64-218">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="7ab64-218">/users/me/inventory</span></span>](../uri/marketplace/uri-inventory.md)

 [<span data-ttu-id="7ab64-219">インベントリ コンシューマブル/{itemID}/</span><span class="sxs-lookup"><span data-stu-id="7ab64-219">/inventory/consumables/{itemID}</span></span>](../uri/marketplace/uri-inventoryconsumablesitemurl.md)

 [<span data-ttu-id="7ab64-220">/inventory/{itemID}</span><span class="sxs-lookup"><span data-stu-id="7ab64-220">/inventory/{itemID}</span></span>](../uri/marketplace/uri-inventoryitemurl.md)
