---
title: InitialUploadRequest (JSON)
assetID: 8b8bce98-cb5f-bbaf-5564-9be2f58d749b
permalink: en-us/docs/xboxlive/rest/json-initialuploadrequest.html
author: KevinAsgari
description: " InitialUploadRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eac2405b8668179fa60921ca45012a417e61b352
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3929355"
---
# <a name="initialuploadrequest-json"></a>InitialUploadRequest (JSON)
POST ゲーム クリップだったの本文は、要求をアップロードします。 
<a id="ID4EN"></a>

 
## <a name="initialuploadrequest"></a>InitialUploadRequest
 
InitialUploadRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>greatestMomentId</b>| string| クリップの名として使用する、テキスト文字列 ID。 これの管理し、タイトルの開発者によってタイトルの構成ファイル内のローカライズされました。| 
| <b>userCaption</b>| string| 省略可能。 ユーザー入力の代替名最大 250 文字の最大長ゲーム クリップされます。| 
| <b>sessionRef</b>| string| 省略可能。 ゲーム セッションのレコーディングの完了を参照します。| 
| <b>dateRecorded</b>| DateTime| UTC で、レコーディングを開始した時刻。 ISO 8601 形式の文字列としてマーシャ リング (詳細については、<a href="http://www.w3.org/TR/NOTE-datetime">日付と時刻の形式</a>を参照) の書式を設定します。| 
| <b>durationInSeconds</b>| 32 ビット符号なし整数| 秒単位でのクリップの長さ。| 
| <b>expectedBlocks</b>| 32 ビット符号なし整数| 省略可能。 ファイルを分類するブロックの数。 省略ファイルは、1 つの要求で送信されます。| 
| <b>fileSize</b>| 32 ビット符号なし整数| ファイル サイズのアップロードされるビデオのバイト数。| 
| <b>type</b>| [GameClipType 列挙](../enums/gvr-enum-gamecliptypes.md)| コンマ区切りで列挙の文字列値としてマーシャ リング、クリップの種類です。| 
| <b>ソース</b>| [GameClipSource 列挙](../enums/gvr-enum-gameclipsource.md)| クリップの元の指定、列挙体の文字列値としてマーシャ リングします。| 
| <b>visibility</b>| [GameClipVisibility 列挙](../enums/gvr-enum-gameclipvisibility.md)| システムの公開後に、ゲーム クリップの可視性を指定します。| 
| <b>titleData</b>| string| 省略可能。 このクリップに関連付けられているタイトル固有のプロパティのプロパティ バッグです。 格納され、として返されるのです。 タイトル デベロッパーは、クリップに関するメタデータを保持するため、このフィールドを使用できます。| 
| <b>titleData</b>| string| 省略可能。 このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグです。 格納され、として返されるのです。 本体のプラットフォームでは、クリップに関するメタデータを保持するため、このフィールドを使用できます。| 
| <b>systemProperties</b>| string| 省略可能。 このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグです。 格納され、として返されます。 本体のプラットフォームでは、クリップに関するメタデータを保持するため、このフィールドを使用できます。| 
| <b>usersInSession</b>| 文字列の配列| 省略可能。 現在のセッション内のユーザーの一覧。| 
| <b>thumbnailSource</b>| [ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)| 省略可能。 サムネイルのソース。| 
| <b>thumbnailOffsetMillseconds</b>| 32 ビット符号付き整数| 生成されたオフセットのサムネイルを (ミリ秒単位) のオフセットを指定します。 <b>ThumbnailSource</b>をオフセットを設定するときに指定だけです。| 
| <b>savedByUser</b>| ブール値| 省略可能。 FIFO 記憶域ではなく、ユーザーのクォータに保存するクリップを設定します。 既定値は false です。| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a>JSON 構文の例
 

```json
{
   "greatestMomentId": "123abc",
   "userCaption": "OMG Look at this!",
   "sessionRef": "4587552a-a5ad-4c4c-a787-5bc5af70e4c9",
   "dateRecorded": "2012-12-23T11:08:08Z",
   "durationInSeconds": 27,
   "expectedBlocks": 7,
   "fileSize": 1234567,
   "type": "MagicMoment, Achievement",
   "source": "Console",
   "visibility": "Default",
   "titleData": "{ 'Boss': 'The Invincible' }",
   "systemProperties": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }",
   "thumbnailSource": "Offset",
   "thumbnailOffsetMillseconds": 20000,
   "savedByUser": false
 }
    
```

  
<a id="ID4E1H"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   