---
title: GameClip (JSON)
assetID: 204cb702-4ce4-85a8-f231-3b4fb243405f
permalink: en-us/docs/xboxlive/rest/json-gameclip.html
author: KevinAsgari
description: " GameClip (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c648e6c9ec85eb73c4019f14db6c117cda920b87
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5543898"
---
# <a name="gameclip-json"></a>GameClip (JSON)
 
<a id="ID4EO"></a>

 
## <a name="gameclip"></a>GameClip
 
GameClip オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>gameClipId</b>| string| ゲーム クリップに割り当てられている ID。| 
| <b>状態</b>| GameClipState| システムのゲーム クリップの状態。| 
| <b>dateRecorded</b>| DateTime| 日付と UTC (ISO 8601 形式) で、録画が開始された時刻。| 
| <b>lastModified</b>| DateTime| 最後に修正されたゲーム クリップまたは UTC (ISO 8601 形式) で、メタデータの時刻。| 
| <b>userCaption</b>| string| ユーザーが入力した以外にローカライズされた文字列ゲーム クリップの。| 
| <b>type</b>| GameClipTypes| クリップの種類です。 そうである場合をコンマで区切られたことが、複数の値ができます。| 
| <b>ソース</b>| GameClipSource| クリップが作成された方法です。| 
| <b>visibility</b>| GameClipVisibility| システムでの公開後に、ゲーム クリップの可視性です。| 
| <b>durationInSeconds</b>| 32 ビットの符号なし整数| 秒単位で、ゲーム クリップの期間です。| 
| <b>scid</b>| string| ゲームのクリップが関連付けられている SCID です。| 
| <b>rating</b>| 倍精度浮動小数点数| ゲームのクリップ, 0.0 に 5.0 の範囲内に関連付けられている評価します。| 
| <b>ratingCount</b>| 32 ビットの符号なし整数| このクリップが評価された回数。| 
| <b>表示モード</b>| 32 ビットの符号なし整数| ゲーム クリップに関連付けられたビューの数。| 
| <b>titleData</b>| string| タイトルに固有のプロパティ バッグです。| 
| <b>titleData</b>| string| コンソールに固有のプロパティ バッグです。| 
| <b>サムネイル</b>| GameClipThumbnail の配列| GameClipThumbnail オブジェクトの配列です。| 
| <b>gameClipUris</b>| GameClipUri の配列| GameClipUri オブジェクトの配列です。| 
| <b>xuid</b>| string| 文字列としてマーシャ リング、ゲーム クリップの所有者の XUID です。| 
| <b>clipName</b>| string| タイトルの管理システムから検索要求の入力のロケールに基づいて、クリップの名前のローカライズされたバージョンです。| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
     "id": "7ce5c1a7-1255-46d3-a90e-34a0e2dfab06",
     "xuid": "2716903703773872",
     "state": "Published", 
     "dateRecorded": "2012-12-23T12:00:00Z",
     "lastModified": "2012-10-31T10:45:00Z",
     "clipName": "Forza 4",
     "userCaption": "My awesome car flip",
     "type": "DeveloperInitiated, Achievement",
     "source": "TitleDirect",
     "visibility": "Default",
     "durationInSeconds": 30,
     "scid": "ecb5497e-76d4-4a8a-870d-e76a26306b7d",
     "rating": 1.0,
     "views": 5,
     "thumbnails": [
       {
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
     ]
   }
    
```

  
<a id="ID4E1H"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   