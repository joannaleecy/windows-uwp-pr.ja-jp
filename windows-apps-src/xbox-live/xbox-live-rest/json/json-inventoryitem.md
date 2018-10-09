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
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4460660"
---
# <a name="inventoryitem-json"></a><span data-ttu-id="ccf52-104">inventoryItem (JSON)</span><span class="sxs-lookup"><span data-stu-id="ccf52-104">inventoryItem (JSON)</span></span>
<span data-ttu-id="ccf52-105">コア インベントリ項目は、標準的なアイテムの権利を付与できるを表します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-105">The core inventory item represents the standard item on which an entitlement can be granted.</span></span>
<a id="ID4EN"></a>


## <a name="inventoryitem"></a><span data-ttu-id="ccf52-106">inventoryItem</span><span class="sxs-lookup"><span data-stu-id="ccf52-106">inventoryItem</span></span>

<span data-ttu-id="ccf52-107">InventoryItem オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ccf52-107">The inventoryItem object has the following specification.</span></span>

| <span data-ttu-id="ccf52-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="ccf52-108">Member</span></span>| <span data-ttu-id="ccf52-109">種類</span><span class="sxs-lookup"><span data-stu-id="ccf52-109">Type</span></span>| <span data-ttu-id="ccf52-110">説明</span><span class="sxs-lookup"><span data-stu-id="ccf52-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="ccf52-111">url</span><span class="sxs-lookup"><span data-stu-id="ccf52-111">url</span></span>| <span data-ttu-id="ccf52-112">string</span><span class="sxs-lookup"><span data-stu-id="ccf52-112">string</span></span>| <span data-ttu-id="ccf52-113">この特定のインベントリ項目の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="ccf52-113">Unique identifier for this specific inventory item.</span></span>|
| <span data-ttu-id="ccf52-114">itemType</span><span class="sxs-lookup"><span data-stu-id="ccf52-114">itemType</span></span>| <span data-ttu-id="ccf52-115">string</span><span class="sxs-lookup"><span data-stu-id="ccf52-115">string</span></span>| <span data-ttu-id="ccf52-116">項目の種類です。</span><span class="sxs-lookup"><span data-stu-id="ccf52-116">Type of the item.</span></span> <span data-ttu-id="ccf52-117">現在の値します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-117">Current values are</span></span> <ul><li><b><span data-ttu-id="ccf52-118">Unknown</span><span class="sxs-lookup"><span data-stu-id="ccf52-118">Unknown</span></span></b></li><li><b><span data-ttu-id="ccf52-119">Game</span><span class="sxs-lookup"><span data-stu-id="ccf52-119">Game</span></span></b></li><li><b><span data-ttu-id="ccf52-120">映画</span><span class="sxs-lookup"><span data-stu-id="ccf52-120">Movie</span></span></b></li><li> <b><span data-ttu-id="ccf52-121">TVShow</span><span class="sxs-lookup"><span data-stu-id="ccf52-121">TVShow</span></span></b></li><li><b><span data-ttu-id="ccf52-122">MusicVideo</span><span class="sxs-lookup"><span data-stu-id="ccf52-122">MusicVideo</span></span></b></li><li><b><span data-ttu-id="ccf52-123">GameTrial</span><span class="sxs-lookup"><span data-stu-id="ccf52-123">GameTrial</span></span></b></li><li><b><span data-ttu-id="ccf52-124">ViralVideo</span><span class="sxs-lookup"><span data-stu-id="ccf52-124">ViralVideo</span></span></b></li><li><b><span data-ttu-id="ccf52-125">TVEpisode</span><span class="sxs-lookup"><span data-stu-id="ccf52-125">TVEpisode</span></span></b></li><li><b><span data-ttu-id="ccf52-126">TVSeason</span><span class="sxs-lookup"><span data-stu-id="ccf52-126">TVSeason</span></span></b></li><li><b><span data-ttu-id="ccf52-127">TVSeries</span><span class="sxs-lookup"><span data-stu-id="ccf52-127">TVSeries</span></span></b></li><li><b><span data-ttu-id="ccf52-128">VideoPreview</span><span class="sxs-lookup"><span data-stu-id="ccf52-128">VideoPreview</span></span></b></li><li><b><span data-ttu-id="ccf52-129">ポスター</span><span class="sxs-lookup"><span data-stu-id="ccf52-129">Poster</span></span></b></li><li><b><span data-ttu-id="ccf52-130">ポッド キャスト</span><span class="sxs-lookup"><span data-stu-id="ccf52-130">Podcast</span></span></b></li><li><b><span data-ttu-id="ccf52-131">画像</span><span class="sxs-lookup"><span data-stu-id="ccf52-131">Image</span></span></b></li><li><b><span data-ttu-id="ccf52-132">BoxArt</span><span class="sxs-lookup"><span data-stu-id="ccf52-132">BoxArt</span></span></b></li><li><b><span data-ttu-id="ccf52-133">ArtistPicture</span><span class="sxs-lookup"><span data-stu-id="ccf52-133">ArtistPicture</span></span></b></li><li><b><span data-ttu-id="ccf52-134">GameContent</span><span class="sxs-lookup"><span data-stu-id="ccf52-134">GameContent</span></span></b></li><li><b><span data-ttu-id="ccf52-135">GameDemo</span><span class="sxs-lookup"><span data-stu-id="ccf52-135">GameDemo</span></span></b></li><li><b><span data-ttu-id="ccf52-136">Theme</span><span class="sxs-lookup"><span data-stu-id="ccf52-136">Theme</span></span></b></li><li><b><span data-ttu-id="ccf52-137">XboxOriginalGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-137">XboxOriginalGame</span></span></b></li><li><b><span data-ttu-id="ccf52-138">GamerTile</span><span class="sxs-lookup"><span data-stu-id="ccf52-138">GamerTile</span></span></b></li><li><b><span data-ttu-id="ccf52-139">ArcadeGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-139">ArcadeGame</span></span></b></li><li><b><span data-ttu-id="ccf52-140">GameConsumable</span><span class="sxs-lookup"><span data-stu-id="ccf52-140">GameConsumable</span></span></b></li><li><b><span data-ttu-id="ccf52-141">アルバム</span><span class="sxs-lookup"><span data-stu-id="ccf52-141">Album</span></span></b></li><li><b><span data-ttu-id="ccf52-142">AlbumDisc</span><span class="sxs-lookup"><span data-stu-id="ccf52-142">AlbumDisc</span></span></b></li><li><b><span data-ttu-id="ccf52-143">AlbumArt</span><span class="sxs-lookup"><span data-stu-id="ccf52-143">AlbumArt</span></span></b></li><li><b><span data-ttu-id="ccf52-144">GameVideo</span><span class="sxs-lookup"><span data-stu-id="ccf52-144">GameVideo</span></span></b></li><li><b><span data-ttu-id="ccf52-145">BackgroundArt</span><span class="sxs-lookup"><span data-stu-id="ccf52-145">BackgroundArt</span></span></b></li><li><b><span data-ttu-id="ccf52-146">TVTrailer</span><span class="sxs-lookup"><span data-stu-id="ccf52-146">TVTrailer</span></span></b></li><li><b><span data-ttu-id="ccf52-147">GameTrailer</span><span class="sxs-lookup"><span data-stu-id="ccf52-147">GameTrailer</span></span></b></li><li><b><span data-ttu-id="ccf52-148">VideoShort</span><span class="sxs-lookup"><span data-stu-id="ccf52-148">VideoShort</span></span></b></li><li><b><span data-ttu-id="ccf52-149">バンドル</span><span class="sxs-lookup"><span data-stu-id="ccf52-149">Bundle</span></span></b></li><li><b><span data-ttu-id="ccf52-150">XnaCommunityGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-150">XnaCommunityGame</span></span></b></li><li><b><span data-ttu-id="ccf52-151">プロモーション</span><span class="sxs-lookup"><span data-stu-id="ccf52-151">Promotional</span></span></b></li><li><b><span data-ttu-id="ccf52-152">MovieTrailer</span><span class="sxs-lookup"><span data-stu-id="ccf52-152">MovieTrailer</span></span></b></li><li><b><span data-ttu-id="ccf52-153">SlideshowPreviewImage</span><span class="sxs-lookup"><span data-stu-id="ccf52-153">SlideshowPreviewImage</span></span></b></li><li><b><span data-ttu-id="ccf52-154">ServerBackedGames</span><span class="sxs-lookup"><span data-stu-id="ccf52-154">ServerBackedGames</span></span></b></li><li><b><span data-ttu-id="ccf52-155">Marketplace</span><span class="sxs-lookup"><span data-stu-id="ccf52-155">Marketplace</span></span></b></li><li><b><span data-ttu-id="ccf52-156">AvatarItem</span><span class="sxs-lookup"><span data-stu-id="ccf52-156">AvatarItem</span></span></b></li><li><b><span data-ttu-id="ccf52-157">LiveApp</span><span class="sxs-lookup"><span data-stu-id="ccf52-157">LiveApp</span></span></b></li><li><b><span data-ttu-id="ccf52-158">WebGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-158">WebGame</span></span></b></li><li><b><span data-ttu-id="ccf52-159">MobileGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-159">MobileGame</span></span></b></li><li><b><span data-ttu-id="ccf52-160">MobilePdlc</span><span class="sxs-lookup"><span data-stu-id="ccf52-160">MobilePdlc</span></span></b></li><li><b><span data-ttu-id="ccf52-161">MobileConsumable</span><span class="sxs-lookup"><span data-stu-id="ccf52-161">MobileConsumable</span></span></b></li><li><b><span data-ttu-id="ccf52-162">App</span><span class="sxs-lookup"><span data-stu-id="ccf52-162">App</span></span></b></li><li><b><span data-ttu-id="ccf52-163">MetroGame</span><span class="sxs-lookup"><span data-stu-id="ccf52-163">MetroGame</span></span></b></li><li><b><span data-ttu-id="ccf52-164">MetroGameContent</span><span class="sxs-lookup"><span data-stu-id="ccf52-164">MetroGameContent</span></span></b></li><li><b><span data-ttu-id="ccf52-165">MetroGameConsumable</span><span class="sxs-lookup"><span data-stu-id="ccf52-165">MetroGameConsumable</span></span></b></li><li><b><span data-ttu-id="ccf52-166">GameLayer</span><span class="sxs-lookup"><span data-stu-id="ccf52-166">GameLayer</span></span></b></li><li><b><span data-ttu-id="ccf52-167">GameActivity</span><span class="sxs-lookup"><span data-stu-id="ccf52-167">GameActivity</span></span></b></li><li><b><span data-ttu-id="ccf52-168">GameV2</span><span class="sxs-lookup"><span data-stu-id="ccf52-168">GameV2</span></span></b></li><li><b><span data-ttu-id="ccf52-169">SubscriptionV2</span><span class="sxs-lookup"><span data-stu-id="ccf52-169">SubscriptionV2</span></span></b></li><li><b><span data-ttu-id="ccf52-170">サブスクリプション</span><span class="sxs-lookup"><span data-stu-id="ccf52-170">Subscription</span></span></b><br/><br/> <span data-ttu-id="ccf52-171">**注:** ゲームが**GameV2**によって指定される、コンシューマブルなアドオンです**GameConsumable**、永続的な DLC が**GameContent**します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-171">**Note:** Games are designated by **GameV2**, consumables are **GameConsumable**, and durable DLC is **GameContent**.</span></span> |
  | <span data-ttu-id="ccf52-172">コンテナー</span><span class="sxs-lookup"><span data-stu-id="ccf52-172">containers</span></span> | <span data-ttu-id="ccf52-173">string</span><span class="sxs-lookup"><span data-stu-id="ccf52-173">string</span></span> | <span data-ttu-id="ccf52-174">これは、この項目を含む「コンテナー」のセットです。</span><span class="sxs-lookup"><span data-stu-id="ccf52-174">This is the set of "containers" that contain this item.</span></span> <span data-ttu-id="ccf52-175">ユーザーのインベントリは、特定のコンテナーに参加している項目を照会することができます。</span><span class="sxs-lookup"><span data-stu-id="ccf52-175">A user's inventory can be queried for items that belong to a specific container.</span></span> <span data-ttu-id="ccf52-176">これらのコンテナーは、項目に追加されると、インベントリの購入によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="ccf52-176">These containers are determined when the item is added to the inventory by purchase.</span></span> |
  | <span data-ttu-id="ccf52-177">取得</span><span class="sxs-lookup"><span data-stu-id="ccf52-177">obtained</span></span> | <span data-ttu-id="ccf52-178">DateTime</span><span class="sxs-lookup"><span data-stu-id="ccf52-178">DateTime</span></span> | <span data-ttu-id="ccf52-179">日付と時刻、ユーザーのインベントリに、項目が追加されました。</span><span class="sxs-lookup"><span data-stu-id="ccf52-179">Date and time the item was added to the user's inventory.</span></span> |
  | <span data-ttu-id="ccf52-180">startDate</span><span class="sxs-lookup"><span data-stu-id="ccf52-180">startDate</span></span> | <span data-ttu-id="ccf52-181">DateTime</span><span class="sxs-lookup"><span data-stu-id="ccf52-181">DateTime</span></span> | <span data-ttu-id="ccf52-182">日付と時刻になった、または使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="ccf52-182">Date and time the item became or will become available for use.</span></span> |
  | <span data-ttu-id="ccf52-183">endDate</span><span class="sxs-lookup"><span data-stu-id="ccf52-183">endDate</span></span> | <span data-ttu-id="ccf52-184">DateTime</span><span class="sxs-lookup"><span data-stu-id="ccf52-184">DateTime</span></span> | <span data-ttu-id="ccf52-185">日付と時刻が項目のようになりましたまたは使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="ccf52-185">Date and time the item became or will become unusable.</span></span> |
  | <span data-ttu-id="ccf52-186">状態</span><span class="sxs-lookup"><span data-stu-id="ccf52-186">state</span></span> | <span data-ttu-id="ccf52-187">string</span><span class="sxs-lookup"><span data-stu-id="ccf52-187">string</span></span> | <span data-ttu-id="ccf52-188">項目の状態。</span><span class="sxs-lookup"><span data-stu-id="ccf52-188">The state of the item.</span></span> <span data-ttu-id="ccf52-189">値は、**有効になっている**、**中断**、**有効期限が切れて**、**キャンセル**、**更新**を許可します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-189">Allowed values are **Enabled**, **Suspended**, **Expired**, **Canceled**, **Renewed**.</span></span>  |
  | <span data-ttu-id="ccf52-190">trial</span><span class="sxs-lookup"><span data-stu-id="ccf52-190">trial</span></span> | <span data-ttu-id="ccf52-191">ブール値</span><span class="sxs-lookup"><span data-stu-id="ccf52-191">Boolean value</span></span> | <span data-ttu-id="ccf52-192">必須。</span><span class="sxs-lookup"><span data-stu-id="ccf52-192">Required.</span></span> <span data-ttu-id="ccf52-193">この権利が; 試用版である場合は true。それ以外の場合は false です。</span><span class="sxs-lookup"><span data-stu-id="ccf52-193">True if this entitlement is a trial; otherwise, false.</span></span> <span data-ttu-id="ccf52-194">権利の試用版を購入し、通常版を購入する場合は、両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ccf52-194">If you buy the trial version of an entitlement and then buy the full version, you will receive both.</span></span> |
  | <span data-ttu-id="ccf52-195">trialTimeRemaining</span><span class="sxs-lookup"><span data-stu-id="ccf52-195">trialTimeRemaining</span></span> | <span data-ttu-id="ccf52-196">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="ccf52-196">TimeSpan</span></span> | <span data-ttu-id="ccf52-197">Null 許容します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-197">Nullable.</span></span> <span data-ttu-id="ccf52-198">どのくらいの時間は、分単位で、試用版に残っています。</span><span class="sxs-lookup"><span data-stu-id="ccf52-198">How much time is remaining on the trial, in minutes.</span></span> |
  | <span data-ttu-id="ccf52-199">コンシューマブル</span><span class="sxs-lookup"><span data-stu-id="ccf52-199">consumable</span></span> | <span data-ttu-id="ccf52-200">array</span><span class="sxs-lookup"><span data-stu-id="ccf52-200">array</span></span> | <span data-ttu-id="ccf52-201">アイテムがコンシューマブルな場合は、その現在の数量と同様に、コンシューマブルなインベントリ項目の一意の識別子 (リンク) の場合は、なインライン表現が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ccf52-201">If the items is consumable, this contains an inline representation of the unique identifier (link) for the consumable inventory item, as well as its current quantity.</span></span> |

<a id="ID4EMAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="ccf52-202">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="ccf52-202">Sample JSON syntax</span></span>


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


## <a name="consumable-inventory-item"></a><span data-ttu-id="ccf52-203">コンシューマブルなインベントリ項目</span><span class="sxs-lookup"><span data-stu-id="ccf52-203">Consumable inventory item</span></span>

<span data-ttu-id="ccf52-204">コンシューマブルなエンティティは、最小限のコンシューマブルな項目のプロパティの設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="ccf52-204">The consumable entity presents the minimal set of properties for a consumable item.</span></span>

| <span data-ttu-id="ccf52-205">メンバー</span><span class="sxs-lookup"><span data-stu-id="ccf52-205">Member</span></span>| <span data-ttu-id="ccf52-206">種類</span><span class="sxs-lookup"><span data-stu-id="ccf52-206">Type</span></span>| <span data-ttu-id="ccf52-207">説明</span><span class="sxs-lookup"><span data-stu-id="ccf52-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ccf52-208">url</span><span class="sxs-lookup"><span data-stu-id="ccf52-208">url</span></span>| <span data-ttu-id="ccf52-209">string</span><span class="sxs-lookup"><span data-stu-id="ccf52-209">string</span></span>| <span data-ttu-id="ccf52-210">特定のコンシューマブルなインベントリ項目の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="ccf52-210">Unique identifier for the specific consumable inventory item.</span></span>|
| <span data-ttu-id="ccf52-211">quantity</span><span class="sxs-lookup"><span data-stu-id="ccf52-211">quantity</span></span>| <span data-ttu-id="ccf52-212">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="ccf52-212">32-bit signed integer</span></span>| <span data-ttu-id="ccf52-213">このインベントリ項目の現在の数量。</span><span class="sxs-lookup"><span data-stu-id="ccf52-213">The current quantity of this inventory item.</span></span>|


```json
consumableInventoryItem {
  "url": string,
  "quantity": int
}

```


<a id="ID4E4BAC"></a>


## <a name="see-also"></a><span data-ttu-id="ccf52-214">関連項目</span><span class="sxs-lookup"><span data-stu-id="ccf52-214">See also</span></span>

<a id="ID4E6BAC"></a>


##### <a name="parent"></a><span data-ttu-id="ccf52-215">Parent</span><span class="sxs-lookup"><span data-stu-id="ccf52-215">Parent</span></span>

[<span data-ttu-id="ccf52-216">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="ccf52-216">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EJCAC"></a>


##### <a name="reference"></a><span data-ttu-id="ccf52-217">リファレンス</span><span class="sxs-lookup"><span data-stu-id="ccf52-217">Reference</span></span>

[<span data-ttu-id="ccf52-218">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="ccf52-218">/users/me/inventory</span></span>](../uri/marketplace/uri-inventory.md)

 [<span data-ttu-id="ccf52-219">インベントリの作成/コンシューマブル/{itemID}/</span><span class="sxs-lookup"><span data-stu-id="ccf52-219">/inventory/consumables/{itemID}</span></span>](../uri/marketplace/uri-inventoryconsumablesitemurl.md)

 [<span data-ttu-id="ccf52-220">/inventory/{itemID}</span><span class="sxs-lookup"><span data-stu-id="ccf52-220">/inventory/{itemID}</span></span>](../uri/marketplace/uri-inventoryitemurl.md)
