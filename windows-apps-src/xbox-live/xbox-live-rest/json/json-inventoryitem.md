---
title: inventoryItem (JSON)
assetID: 446cca28-b2d3-1b84-f973-94065519b391
permalink: en-us/docs/xboxlive/rest/json-inventoryitem.html
description: " inventoryItem (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 240e527258923cff146009810c190e401e0574d0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628497"
---
# <a name="inventoryitem-json"></a><span data-ttu-id="b1c74-104">inventoryItem (JSON)</span><span class="sxs-lookup"><span data-stu-id="b1c74-104">inventoryItem (JSON)</span></span>
<span data-ttu-id="b1c74-105">Core の在庫品目は、権利を許可できる標準の項目を表します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-105">The core inventory item represents the standard item on which an entitlement can be granted.</span></span>
<a id="ID4EN"></a>


## <a name="inventoryitem"></a><span data-ttu-id="b1c74-106">inventoryItem</span><span class="sxs-lookup"><span data-stu-id="b1c74-106">inventoryItem</span></span>

<span data-ttu-id="b1c74-107">InventoryItem オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="b1c74-107">The inventoryItem object has the following specification.</span></span>

| <span data-ttu-id="b1c74-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="b1c74-108">Member</span></span>| <span data-ttu-id="b1c74-109">種類</span><span class="sxs-lookup"><span data-stu-id="b1c74-109">Type</span></span>| <span data-ttu-id="b1c74-110">説明</span><span class="sxs-lookup"><span data-stu-id="b1c74-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="b1c74-111">url</span><span class="sxs-lookup"><span data-stu-id="b1c74-111">url</span></span>| <span data-ttu-id="b1c74-112">string</span><span class="sxs-lookup"><span data-stu-id="b1c74-112">string</span></span>| <span data-ttu-id="b1c74-113">この特定のインベントリ項目の一意識別子。</span><span class="sxs-lookup"><span data-stu-id="b1c74-113">Unique identifier for this specific inventory item.</span></span>|
| <span data-ttu-id="b1c74-114">ItemType</span><span class="sxs-lookup"><span data-stu-id="b1c74-114">itemType</span></span>| <span data-ttu-id="b1c74-115">string</span><span class="sxs-lookup"><span data-stu-id="b1c74-115">string</span></span>| <span data-ttu-id="b1c74-116">項目の種類。</span><span class="sxs-lookup"><span data-stu-id="b1c74-116">Type of the item.</span></span> <span data-ttu-id="b1c74-117">現在の値します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-117">Current values are</span></span> <ul><li><span data-ttu-id="b1c74-118"><b>Unknown</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-118"><b>Unknown</b></span></span></li><li><span data-ttu-id="b1c74-119"><b>ゲーム</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-119"><b>Game</b></span></span></li><li><span data-ttu-id="b1c74-120"><b>ビデオ</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-120"><b>Movie</b></span></span></li><li> <span data-ttu-id="b1c74-121"><b>TVShow</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-121"><b>TVShow</b></span></span></li><li><span data-ttu-id="b1c74-122"><b>MusicVideo</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-122"><b>MusicVideo</b></span></span></li><li><span data-ttu-id="b1c74-123"><b>GameTrial</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-123"><b>GameTrial</b></span></span></li><li><span data-ttu-id="b1c74-124"><b>ViralVideo</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-124"><b>ViralVideo</b></span></span></li><li><span data-ttu-id="b1c74-125"><b>TVEpisode</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-125"><b>TVEpisode</b></span></span></li><li><span data-ttu-id="b1c74-126"><b>TVSeason</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-126"><b>TVSeason</b></span></span></li><li><span data-ttu-id="b1c74-127"><b>TVSeries</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-127"><b>TVSeries</b></span></span></li><li><span data-ttu-id="b1c74-128"><b>VideoPreview</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-128"><b>VideoPreview</b></span></span></li><li><span data-ttu-id="b1c74-129"><b>ポスター</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-129"><b>Poster</b></span></span></li><li><span data-ttu-id="b1c74-130"><b>ポッド キャスト</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-130"><b>Podcast</b></span></span></li><li><span data-ttu-id="b1c74-131"><b>画像</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-131"><b>Image</b></span></span></li><li><span data-ttu-id="b1c74-132"><b>[Boxart]</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-132"><b>BoxArt</b></span></span></li><li><span data-ttu-id="b1c74-133"><b>ArtistPicture</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-133"><b>ArtistPicture</b></span></span></li><li><span data-ttu-id="b1c74-134"><b>GameContent</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-134"><b>GameContent</b></span></span></li><li><span data-ttu-id="b1c74-135"><b>GameDemo</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-135"><b>GameDemo</b></span></span></li><li><span data-ttu-id="b1c74-136"><b>テーマ</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-136"><b>Theme</b></span></span></li><li><span data-ttu-id="b1c74-137"><b>XboxOriginalGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-137"><b>XboxOriginalGame</b></span></span></li><li><span data-ttu-id="b1c74-138"><b>GamerTile</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-138"><b>GamerTile</b></span></span></li><li><span data-ttu-id="b1c74-139"><b>ArcadeGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-139"><b>ArcadeGame</b></span></span></li><li><span data-ttu-id="b1c74-140"><b>GameConsumable</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-140"><b>GameConsumable</b></span></span></li><li><span data-ttu-id="b1c74-141"><b>アルバム</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-141"><b>Album</b></span></span></li><li><span data-ttu-id="b1c74-142"><b>AlbumDisc</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-142"><b>AlbumDisc</b></span></span></li><li><span data-ttu-id="b1c74-143"><b>AlbumArt</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-143"><b>AlbumArt</b></span></span></li><li><span data-ttu-id="b1c74-144"><b>GameVideo</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-144"><b>GameVideo</b></span></span></li><li><span data-ttu-id="b1c74-145"><b>BackgroundArt</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-145"><b>BackgroundArt</b></span></span></li><li><span data-ttu-id="b1c74-146"><b>TVTrailer</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-146"><b>TVTrailer</b></span></span></li><li><span data-ttu-id="b1c74-147"><b>GameTrailer</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-147"><b>GameTrailer</b></span></span></li><li><span data-ttu-id="b1c74-148"><b>VideoShort</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-148"><b>VideoShort</b></span></span></li><li><span data-ttu-id="b1c74-149"><b>バンドル</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-149"><b>Bundle</b></span></span></li><li><span data-ttu-id="b1c74-150"><b>XnaCommunityGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-150"><b>XnaCommunityGame</b></span></span></li><li><span data-ttu-id="b1c74-151"><b>キャンペーン</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-151"><b>Promotional</b></span></span></li><li><span data-ttu-id="b1c74-152"><b>MovieTrailer</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-152"><b>MovieTrailer</b></span></span></li><li><span data-ttu-id="b1c74-153"><b>SlideshowPreviewImage</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-153"><b>SlideshowPreviewImage</b></span></span></li><li><span data-ttu-id="b1c74-154"><b>ServerBackedGames</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-154"><b>ServerBackedGames</b></span></span></li><li><span data-ttu-id="b1c74-155"><b>マーケットプレース</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-155"><b>Marketplace</b></span></span></li><li><span data-ttu-id="b1c74-156"><b>AvatarItem</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-156"><b>AvatarItem</b></span></span></li><li><span data-ttu-id="b1c74-157"><b>LiveApp</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-157"><b>LiveApp</b></span></span></li><li><span data-ttu-id="b1c74-158"><b>WebGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-158"><b>WebGame</b></span></span></li><li><span data-ttu-id="b1c74-159"><b>MobileGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-159"><b>MobileGame</b></span></span></li><li><span data-ttu-id="b1c74-160"><b>MobilePdlc</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-160"><b>MobilePdlc</b></span></span></li><li><span data-ttu-id="b1c74-161"><b>MobileConsumable</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-161"><b>MobileConsumable</b></span></span></li><li><span data-ttu-id="b1c74-162"><b>アプリ</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-162"><b>App</b></span></span></li><li><span data-ttu-id="b1c74-163"><b>MetroGame</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-163"><b>MetroGame</b></span></span></li><li><span data-ttu-id="b1c74-164"><b>MetroGameContent</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-164"><b>MetroGameContent</b></span></span></li><li><span data-ttu-id="b1c74-165"><b>MetroGameConsumable</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-165"><b>MetroGameConsumable</b></span></span></li><li><span data-ttu-id="b1c74-166"><b>GameLayer</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-166"><b>GameLayer</b></span></span></li><li><span data-ttu-id="b1c74-167"><b>GameActivity</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-167"><b>GameActivity</b></span></span></li><li><span data-ttu-id="b1c74-168"><b>GameV2</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-168"><b>GameV2</b></span></span></li><li><span data-ttu-id="b1c74-169"><b>SubscriptionV2</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-169"><b>SubscriptionV2</b></span></span></li><li><span data-ttu-id="b1c74-170"><b>サブスクリプション</b></span><span class="sxs-lookup"><span data-stu-id="b1c74-170"><b>Subscription</b></span></span><br/><br/> <span data-ttu-id="b1c74-171">**注:** ゲームがで指定された**GameV2**、消耗品が**GameConsumable**、持続性のある DLC は**GameContent**します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-171">**Note:** Games are designated by **GameV2**, consumables are **GameConsumable**, and durable DLC is **GameContent**.</span></span> |
  | <span data-ttu-id="b1c74-172">コンテナー</span><span class="sxs-lookup"><span data-stu-id="b1c74-172">containers</span></span> | <span data-ttu-id="b1c74-173">string</span><span class="sxs-lookup"><span data-stu-id="b1c74-173">string</span></span> | <span data-ttu-id="b1c74-174">これは、この項目が含まれている「コンテナー」のセットです。</span><span class="sxs-lookup"><span data-stu-id="b1c74-174">This is the set of "containers" that contain this item.</span></span> <span data-ttu-id="b1c74-175">ユーザーのインベントリは、特定のコンテナーに属する項目の照会できます。</span><span class="sxs-lookup"><span data-stu-id="b1c74-175">A user's inventory can be queried for items that belong to a specific container.</span></span> <span data-ttu-id="b1c74-176">これらのコンテナーは、購入で、項目がインベントリに追加されたときに決定されます。</span><span class="sxs-lookup"><span data-stu-id="b1c74-176">These containers are determined when the item is added to the inventory by purchase.</span></span> |
  | <span data-ttu-id="b1c74-177">取得しました。</span><span class="sxs-lookup"><span data-stu-id="b1c74-177">obtained</span></span> | <span data-ttu-id="b1c74-178">DateTime</span><span class="sxs-lookup"><span data-stu-id="b1c74-178">DateTime</span></span> | <span data-ttu-id="b1c74-179">日付と時刻の項目は、ユーザーのインベントリに追加されました。</span><span class="sxs-lookup"><span data-stu-id="b1c74-179">Date and time the item was added to the user's inventory.</span></span> |
  | <span data-ttu-id="b1c74-180">startDate</span><span class="sxs-lookup"><span data-stu-id="b1c74-180">startDate</span></span> | <span data-ttu-id="b1c74-181">DateTime</span><span class="sxs-lookup"><span data-stu-id="b1c74-181">DateTime</span></span> | <span data-ttu-id="b1c74-182">日付と時刻、項目のようになりましたまたは使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="b1c74-182">Date and time the item became or will become available for use.</span></span> |
  | <span data-ttu-id="b1c74-183">endDate</span><span class="sxs-lookup"><span data-stu-id="b1c74-183">endDate</span></span> | <span data-ttu-id="b1c74-184">DateTime</span><span class="sxs-lookup"><span data-stu-id="b1c74-184">DateTime</span></span> | <span data-ttu-id="b1c74-185">日付と時刻、項目のようになりましたまたは使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="b1c74-185">Date and time the item became or will become unusable.</span></span> |
  | <span data-ttu-id="b1c74-186">状態</span><span class="sxs-lookup"><span data-stu-id="b1c74-186">state</span></span> | <span data-ttu-id="b1c74-187">string</span><span class="sxs-lookup"><span data-stu-id="b1c74-187">string</span></span> | <span data-ttu-id="b1c74-188">項目の状態。</span><span class="sxs-lookup"><span data-stu-id="b1c74-188">The state of the item.</span></span> <span data-ttu-id="b1c74-189">使用できる値は**有効**、 **Suspended**、**有効期限が切れた**、 **Canceled**、 **Renewed**します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-189">Allowed values are **Enabled**, **Suspended**, **Expired**, **Canceled**, **Renewed**.</span></span>  |
  | <span data-ttu-id="b1c74-190">trial</span><span class="sxs-lookup"><span data-stu-id="b1c74-190">trial</span></span> | <span data-ttu-id="b1c74-191">ブール値</span><span class="sxs-lookup"><span data-stu-id="b1c74-191">Boolean value</span></span> | <span data-ttu-id="b1c74-192">必須。</span><span class="sxs-lookup"><span data-stu-id="b1c74-192">Required.</span></span> <span data-ttu-id="b1c74-193">この権利は、試用版以外の場合は true。それ以外の場合、false です。</span><span class="sxs-lookup"><span data-stu-id="b1c74-193">True if this entitlement is a trial; otherwise, false.</span></span> <span data-ttu-id="b1c74-194">権利の試用版を購入し、製品版を購入すると、両方を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="b1c74-194">If you buy the trial version of an entitlement and then buy the full version, you will receive both.</span></span> |
  | <span data-ttu-id="b1c74-195">trialTimeRemaining</span><span class="sxs-lookup"><span data-stu-id="b1c74-195">trialTimeRemaining</span></span> | <span data-ttu-id="b1c74-196">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="b1c74-196">TimeSpan</span></span> | <span data-ttu-id="b1c74-197">Null 値を許容します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-197">Nullable.</span></span> <span data-ttu-id="b1c74-198">時間は分単位で、試用期間に残っています。</span><span class="sxs-lookup"><span data-stu-id="b1c74-198">How much time is remaining on the trial, in minutes.</span></span> |
  | <span data-ttu-id="b1c74-199">使用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c74-199">consumable</span></span> | <span data-ttu-id="b1c74-200">array</span><span class="sxs-lookup"><span data-stu-id="b1c74-200">array</span></span> | <span data-ttu-id="b1c74-201">項目が使用できる場合は、その現在の数量と同様に、使用できるインベントリ項目の一意の識別子 (リンク) のインライン表現を含みます。</span><span class="sxs-lookup"><span data-stu-id="b1c74-201">If the items is consumable, this contains an inline representation of the unique identifier (link) for the consumable inventory item, as well as its current quantity.</span></span> |

<a id="ID4EMAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="b1c74-202">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="b1c74-202">Sample JSON syntax</span></span>


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


## <a name="consumable-inventory-item"></a><span data-ttu-id="b1c74-203">使用できるインベントリ項目</span><span class="sxs-lookup"><span data-stu-id="b1c74-203">Consumable inventory item</span></span>

<span data-ttu-id="b1c74-204">使用できるエンティティは、使用できる項目のプロパティの最小限のセットを表示します。</span><span class="sxs-lookup"><span data-stu-id="b1c74-204">The consumable entity presents the minimal set of properties for a consumable item.</span></span>

| <span data-ttu-id="b1c74-205">メンバー</span><span class="sxs-lookup"><span data-stu-id="b1c74-205">Member</span></span>| <span data-ttu-id="b1c74-206">種類</span><span class="sxs-lookup"><span data-stu-id="b1c74-206">Type</span></span>| <span data-ttu-id="b1c74-207">説明</span><span class="sxs-lookup"><span data-stu-id="b1c74-207">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="b1c74-208">url</span><span class="sxs-lookup"><span data-stu-id="b1c74-208">url</span></span>| <span data-ttu-id="b1c74-209">string</span><span class="sxs-lookup"><span data-stu-id="b1c74-209">string</span></span>| <span data-ttu-id="b1c74-210">特定の消耗インベントリ項目の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="b1c74-210">Unique identifier for the specific consumable inventory item.</span></span>|
| <span data-ttu-id="b1c74-211">quantity</span><span class="sxs-lookup"><span data-stu-id="b1c74-211">quantity</span></span>| <span data-ttu-id="b1c74-212">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="b1c74-212">32-bit signed integer</span></span>| <span data-ttu-id="b1c74-213">現在の在庫品目の数量。</span><span class="sxs-lookup"><span data-stu-id="b1c74-213">The current quantity of this inventory item.</span></span>|


```json
consumableInventoryItem {
  "url": string,
  "quantity": int
}

```


<a id="ID4E4BAC"></a>


## <a name="see-also"></a><span data-ttu-id="b1c74-214">関連項目</span><span class="sxs-lookup"><span data-stu-id="b1c74-214">See also</span></span>

<a id="ID4E6BAC"></a>


##### <a name="parent"></a><span data-ttu-id="b1c74-215">Parent</span><span class="sxs-lookup"><span data-stu-id="b1c74-215">Parent</span></span>

[<span data-ttu-id="b1c74-216">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="b1c74-216">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EJCAC"></a>


##### <a name="reference"></a><span data-ttu-id="b1c74-217">リファレンス</span><span class="sxs-lookup"><span data-stu-id="b1c74-217">Reference</span></span>

[<span data-ttu-id="b1c74-218">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="b1c74-218">/users/me/inventory</span></span>](../uri/marketplace/uri-inventory.md)

 [<span data-ttu-id="b1c74-219">/inventory/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="b1c74-219">/inventory/consumables/{itemID}</span></span>](../uri/marketplace/uri-inventoryconsumablesitemurl.md)

 [<span data-ttu-id="b1c74-220">/inventory/{itemID}</span><span class="sxs-lookup"><span data-stu-id="b1c74-220">/inventory/{itemID}</span></span>](../uri/marketplace/uri-inventoryitemurl.md)
