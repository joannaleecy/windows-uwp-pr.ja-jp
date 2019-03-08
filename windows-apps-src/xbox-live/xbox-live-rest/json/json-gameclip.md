---
title: GameClip (JSON)
assetID: 204cb702-4ce4-85a8-f231-3b4fb243405f
permalink: en-us/docs/xboxlive/rest/json-gameclip.html
description: " GameClip (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4cfc2ac0a635e4aacdc9eeefb5097c6bd946a518
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646507"
---
# <a name="gameclip-json"></a>GameClip (JSON)
 
<a id="ID4EO"></a>

 
## <a name="gameclip"></a>ゲーム クリップだった
 
ゲーム クリップだったオブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>gameClipId</b>| string| ゲームのクリップに割り当てられた ID。| 
| <b>state</b>| GameClipState| システムのゲームのクリップの状態。| 
| <b>dateRecorded</b>| DateTime| 日付と時刻 (utc) (ISO 8601 形式) の記録が開始されました。| 
| <b>LastModified</b>| DateTime| ゲームのクリップまたは UTC (ISO 8601 形式) でそのメタデータの時間を最後に変更します。| 
| <b>userCaption</b>| string| ユーザーが入力したローカライズされていない文字列のゲームのクリップの。| 
| <b>型</b>| GameClipTypes| クリップの種類。 複数の値を指定でき、その場合のコンマ区切りになります。| 
| <b>ソース</b>| GameClipSource| どのようにクリップのソースとなった。| 
| <b>可視性</b>| GameClipVisibility| システムで発行されたが、ゲームのクリップの可視性。| 
| <b>durationInSeconds</b>| 32 ビット符号なし整数| 秒単位でゲームのクリップの期間です。| 
| <b>scid</b>| string| ゲームのクリップが関連付けられている SCID します。| 
| <b>rating</b>| 倍精度浮動小数点数| 範囲 0.0 に 5.0 で、ゲームのクリップに関連する評価します。| 
| <b>ratingCount</b>| 32 ビット符号なし整数| このクリップが評価された回数。| 
| <b>表示モード</b>| 32 ビット符号なし整数| ゲームのクリップに関連付けられたビューの数。| 
| <b>titleData</b>| string| タイトルに固有のプロパティ バッグ。| 
| <b>titleData</b>| string| コンソールに固有のプロパティ バッグ。| 
| <b>サムネイル</b>| GameClipThumbnail の配列| GameClipThumbnail オブジェクトの配列。| 
| <b>gameClipUris</b>| GameClipUri の配列| GameClipUri オブジェクトの配列。| 
| <b>xuid</b>| string| 文字列としてマーシャ リング、ゲームのクリップの所有者の XUID です。| 
| <b>clipName</b>| string| タイトルの管理システムからのクリップの名前、として要求の入力ロケールに基づいてローカライズされたバージョンを検索します。| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "https://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   