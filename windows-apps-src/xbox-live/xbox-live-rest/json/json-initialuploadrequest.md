---
title: InitialUploadRequest (JSON)
assetID: 8b8bce98-cb5f-bbaf-5564-9be2f58d749b
permalink: en-us/docs/xboxlive/rest/json-initialuploadrequest.html
description: " InitialUploadRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2fbb2417f743d97b487ad16abd241fcb5eea62bb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646637"
---
# <a name="initialuploadrequest-json"></a>InitialUploadRequest (JSON)
要求の POST ゲームのクリップだったの本文にアップロードします。 
<a id="ID4EN"></a>

 
## <a name="initialuploadrequest"></a>InitialUploadRequest
 
InitialUploadRequest オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| <b>greatestMomentId</b>| string| クリップの名前として使用するテキストの文字列 ID。 これの管理し、開発者のタイトルのタイトルの構成ファイルでローカライズされました。| 
| <b>userCaption</b>| string| (省略可能)。 ユーザー入力の代替名 250 文字の最大長までゲームにクリップします。| 
| <b>sessionRef</b>| string| (省略可能)。 ゲーム セッションの記録の実行を参照。| 
| <b>dateRecorded</b>| DateTime| (Utc)、記録の開始時刻。 ISO 8601 形式の文字列としてマーシャ リング (を参照してください<a href="https://www.w3.org/TR/NOTE-datetime">日付および時刻書式</a>詳細については)。| 
| <b>durationInSeconds</b>| 32 ビット符号なし整数| 秒単位で、クリップの長さ。| 
| <b>expectedBlocks</b>| 32 ビット符号なし整数| (省略可能)。 ファイルの分割にするブロックの数。 ファイルが 1 つの要求で送信される場合は省略します。| 
| <b>fileSize</b>| 32 ビット符号なし整数| アップロードされるビデオのバイト単位のサイズ。| 
| <b>型</b>| [GameClipType 列挙型](../enums/gvr-enum-gamecliptypes.md)| コンマ区切りである列挙体の文字列値としてマーシャ リング、クリップの種類。| 
| <b>ソース</b>| [GameClipSource 列挙型](../enums/gvr-enum-gameclipsource.md)| クリップの元を示す列挙体の文字列値としてマーシャ リングします。| 
| <b>可視性</b>| [GameClipVisibility 列挙型](../enums/gvr-enum-gameclipvisibility.md)| システムで発行されたが、ゲームのクリップの可視性を指定します。| 
| <b>titleData</b>| string| (省略可能)。 このクリップに関連付けられているタイトルに固有のプロパティのプロパティ バッグ。 格納されているし、として返されるは。 タイトル開発者は、このフィールドを使用して、クリップに関するメタデータを保持することができます。| 
| <b>titleData</b>| string| (省略可能)。 このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグ。 格納されているし、として返されるは。 コンソールのプラットフォームでは、クリップに関するメタデータを保持するのに、このフィールドを使用できます。| 
| <b>systemProperties</b>| string| (省略可能)。 このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグ。 格納されているしが返されます。 コンソールのプラットフォームでは、クリップに関するメタデータを保持するのに、このフィールドを使用できます。| 
| <b>usersInSession</b>| 文字列の配列| (省略可能)。 現在のセッションでのユーザーの一覧。| 
| <b>thumbnailSource</b>| [ThumbnailSource 列挙型](../enums/gvr-enum-thumbnailsource.md)| (省略可能)。 サムネイルのソース。| 
| <b>thumbnailOffsetMillseconds</b>| 32 ビット符号付き整数| 生成されたサムネイルのオフセットをミリ秒単位のオフセットを指定します。 指定した場合にのみ<b>thumbnailSource</b>オフセットを設定します。| 
| <b>savedByUser</b>| ブール値| (省略可能)。 FIFO storage ではなく、ユーザーのクォータに保存するクリップを設定します。 既定値は false。| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   