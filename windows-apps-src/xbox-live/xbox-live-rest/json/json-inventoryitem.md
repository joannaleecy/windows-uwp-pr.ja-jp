---
title: inventoryItem (JSON)
assetID: 446cca28-b2d3-1b84-f973-94065519b391
permalink: en-us/docs/xboxlive/rest/json-inventoryitem.html
author: KevinAsgari
description: " inventoryItem (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2997dd22b64103ed910f32dd2cc1430d3758fdfd
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5835134"
---
# <a name="inventoryitem-json"></a>inventoryItem (JSON)
コアのインベントリ項目の権利を付与できる標準の項目を表します。
<a id="ID4EN"></a>


## <a name="inventoryitem"></a>inventoryItem

InventoryItem オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| url| string| この特定のインベントリ項目の一意の識別子。|
| itemType| string| 項目の種類です。 現在の値します。 <ul><li><b>Unknown</b></li><li><b>Game</b></li><li><b>映画</b></li><li> <b>TVShow</b></li><li><b>MusicVideo</b></li><li><b>GameTrial</b></li><li><b>ViralVideo</b></li><li><b>TVEpisode</b></li><li><b>TVSeason</b></li><li><b>TVSeries</b></li><li><b>VideoPreview</b></li><li><b>ポスター</b></li><li><b>ポッド キャスト</b></li><li><b>画像</b></li><li><b>BoxArt</b></li><li><b>ArtistPicture</b></li><li><b>GameContent</b></li><li><b>GameDemo</b></li><li><b>Theme</b></li><li><b>XboxOriginalGame</b></li><li><b>GamerTile</b></li><li><b>ArcadeGame</b></li><li><b>GameConsumable</b></li><li><b>アルバム</b></li><li><b>AlbumDisc</b></li><li><b>AlbumArt</b></li><li><b>GameVideo</b></li><li><b>BackgroundArt</b></li><li><b>TVTrailer</b></li><li><b>GameTrailer</b></li><li><b>VideoShort</b></li><li><b>バンドル</b></li><li><b>XnaCommunityGame</b></li><li><b>プロモーション</b></li><li><b>MovieTrailer</b></li><li><b>SlideshowPreviewImage</b></li><li><b>ServerBackedGames</b></li><li><b>Marketplace</b></li><li><b>AvatarItem</b></li><li><b>LiveApp</b></li><li><b>WebGame</b></li><li><b>MobileGame</b></li><li><b>MobilePdlc</b></li><li><b>MobileConsumable</b></li><li><b>App</b></li><li><b>MetroGame</b></li><li><b>MetroGameContent</b></li><li><b>MetroGameConsumable</b></li><li><b>GameLayer</b></li><li><b>GameActivity</b></li><li><b>GameV2</b></li><li><b>SubscriptionV2</b></li><li><b>サブスクリプション</b><br/><br/> **注:** ゲームが**GameV2**によって指定される、コンシューマブルなアドオンです**GameConsumable**、永続的な DLC が**GameContent**します。 |
  | コンテナー | string | これは、この項目を含む「コンテナー」のセットです。 特定のコンテナーに参加している項目は、ユーザーのインベントリを照会できます。 これらのコンテナーは、項目に追加されると、インベントリの購入によって決定されます。 |
  | 取得 | DateTime | 日付と時刻の項目は、ユーザーのインベントリに追加されました。 |
  | startDate | DateTime | 日付と時刻になった、または使用可能になります。 |
  | endDate | DateTime | 日付と時刻になった、または使用できなくなります。 |
  | 状態 | string | 項目の状態。 値は**有効になっている**、**中断**、**有効期限が切れて**、**キャンセル**、**更新**を許可します。  |
  | trial | ブール値 | 必須。 この権利が、試用版である場合は true。それ以外の場合は false です。 権利の試用版を購入し、通常版を購入する場合は、両方が表示されます。 |
  | trialTimeRemaining | TimeSpan | Null 許容します。 どのくらいの時間は、分単位で、試用版に残っています。 |
  | コンシューマブル | array | 項目がコンシューマブルの場合は、その現在の数量と同様に、コンシューマブルなインベントリ項目の一意の識別子 (リンク) の場合は、なインライン表現が含まれます。 |

<a id="ID4EMAAC"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


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


## <a name="consumable-inventory-item"></a>コンシューマブルなインベントリ項目

コンシューマブルなエンティティは、最小限のコンシューマブルな項目のプロパティの設定を表示します。

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| url| string| 特定のコンシューマブルなインベントリ項目の一意の識別子。|
| quantity| 32 ビット符号付き整数| このインベントリ アイテムの現在の数量。|


```json
consumableInventoryItem {
  "url": string,
  "quantity": int
}

```


<a id="ID4E4BAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E6BAC"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)


<a id="ID4EJCAC"></a>


##### <a name="reference"></a>リファレンス

[/users/me/inventory](../uri/marketplace/uri-inventory.md)

 [インベントリ コンシューマブル/{itemID}/](../uri/marketplace/uri-inventoryconsumablesitemurl.md)

 [/inventory/{itemID}](../uri/marketplace/uri-inventoryitemurl.md)
