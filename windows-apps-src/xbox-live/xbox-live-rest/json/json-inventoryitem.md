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
# <a name="inventoryitem-json"></a>inventoryItem (JSON)
Core の在庫品目は、権利を許可できる標準の項目を表します。
<a id="ID4EN"></a>


## <a name="inventoryitem"></a>inventoryItem

InventoryItem オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| url| string| この特定のインベントリ項目の一意識別子。|
| ItemType| string| 項目の種類。 現在の値します。 <ul><li><b>Unknown</b></li><li><b>ゲーム</b></li><li><b>ビデオ</b></li><li> <b>TVShow</b></li><li><b>MusicVideo</b></li><li><b>GameTrial</b></li><li><b>ViralVideo</b></li><li><b>TVEpisode</b></li><li><b>TVSeason</b></li><li><b>TVSeries</b></li><li><b>VideoPreview</b></li><li><b>ポスター</b></li><li><b>ポッド キャスト</b></li><li><b>画像</b></li><li><b>[Boxart]</b></li><li><b>ArtistPicture</b></li><li><b>GameContent</b></li><li><b>GameDemo</b></li><li><b>テーマ</b></li><li><b>XboxOriginalGame</b></li><li><b>GamerTile</b></li><li><b>ArcadeGame</b></li><li><b>GameConsumable</b></li><li><b>アルバム</b></li><li><b>AlbumDisc</b></li><li><b>AlbumArt</b></li><li><b>GameVideo</b></li><li><b>BackgroundArt</b></li><li><b>TVTrailer</b></li><li><b>GameTrailer</b></li><li><b>VideoShort</b></li><li><b>バンドル</b></li><li><b>XnaCommunityGame</b></li><li><b>キャンペーン</b></li><li><b>MovieTrailer</b></li><li><b>SlideshowPreviewImage</b></li><li><b>ServerBackedGames</b></li><li><b>マーケットプレース</b></li><li><b>AvatarItem</b></li><li><b>LiveApp</b></li><li><b>WebGame</b></li><li><b>MobileGame</b></li><li><b>MobilePdlc</b></li><li><b>MobileConsumable</b></li><li><b>アプリ</b></li><li><b>MetroGame</b></li><li><b>MetroGameContent</b></li><li><b>MetroGameConsumable</b></li><li><b>GameLayer</b></li><li><b>GameActivity</b></li><li><b>GameV2</b></li><li><b>SubscriptionV2</b></li><li><b>サブスクリプション</b><br/><br/> **注:** ゲームがで指定された**GameV2**、消耗品が**GameConsumable**、持続性のある DLC は**GameContent**します。 |
  | コンテナー | string | これは、この項目が含まれている「コンテナー」のセットです。 ユーザーのインベントリは、特定のコンテナーに属する項目の照会できます。 これらのコンテナーは、購入で、項目がインベントリに追加されたときに決定されます。 |
  | 取得しました。 | DateTime | 日付と時刻の項目は、ユーザーのインベントリに追加されました。 |
  | startDate | DateTime | 日付と時刻、項目のようになりましたまたは使用可能になります。 |
  | endDate | DateTime | 日付と時刻、項目のようになりましたまたは使用できなくなります。 |
  | 状態 | string | 項目の状態。 使用できる値は**有効**、 **Suspended**、**有効期限が切れた**、 **Canceled**、 **Renewed**します。  |
  | trial | ブール値 | 必須。 この権利は、試用版以外の場合は true。それ以外の場合、false です。 権利の試用版を購入し、製品版を購入すると、両方を受け取ります。 |
  | trialTimeRemaining | TimeSpan | Null 値を許容します。 時間は分単位で、試用期間に残っています。 |
  | 使用できます。 | array | 項目が使用できる場合は、その現在の数量と同様に、使用できるインベントリ項目の一意の識別子 (リンク) のインライン表現を含みます。 |

<a id="ID4EMAAC"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


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


## <a name="consumable-inventory-item"></a>使用できるインベントリ項目

使用できるエンティティは、使用できる項目のプロパティの最小限のセットを表示します。

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| url| string| 特定の消耗インベントリ項目の一意の識別子。|
| quantity| 32 ビット符号付き整数| 現在の在庫品目の数量。|


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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)


<a id="ID4EJCAC"></a>


##### <a name="reference"></a>リファレンス

[/users/me/inventory](../uri/marketplace/uri-inventory.md)

 [/inventory/consumables/{itemID}](../uri/marketplace/uri-inventoryconsumablesitemurl.md)

 [/inventory/{itemID}](../uri/marketplace/uri-inventoryitemurl.md)
