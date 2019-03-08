---
title: BatchRequest (JSON)
assetID: 2ca34506-8801-efc5-7c83-3c9ec5572276
permalink: en-us/docs/xboxlive/rest/json-batchrequest.html
description: " BatchRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51073c71700613edcd7c22e18cc0c00a9222d7e5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654157"
---
# <a name="batchrequest-json"></a>BatchRequest (JSON)
ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理に使用するプロパティの配列。
<a id="ID4EN"></a>


## <a name="batchrequest"></a>BatchRequest

BatchRequest オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| ユーザー| 文字列の配列| ユーザーについては、1100 Xuid、一度に最大でプレゼンスが Xuid をリストします。|
| deviceTypes| 文字列の配列| について知りたいユーザーによって使用されるデバイスの種類の一覧です。 配列が空のまま場合、すべての可能なデバイスの種類に既定値 (つまり、none、フィルターで除外)。|
| タイトル| 32 ビット符号なし整数の配列| デバイスの一覧について知りたいユーザーを種類します。 配列が空のまま場合、すべての可能なタイトルを既定値 (つまり、none、フィルターで除外)。|
| level| string| 設定可能な値: <ul><li>ユーザー - ユーザー ノードの取得</li><li>デバイスのユーザーを取得し、デバイス ノード</li><li>タイトル-タイトルの基本的なレベルの情報を取得します。</li><li>豊富なプレゼンス情報、メディア情報、またはその両方の取得 - すべて</li></ul>既定では"title です"。| 
| ガジェットの onlineOnly| ブール値| このプロパティが true の場合、バッチ操作はユーザーがオフライン (クロークされているものを含む) でレコードが除外されます。 指定されていない場合は、オンラインとオフラインの両方のユーザーが返されます。|

<a id="ID4EAD"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


```json
{
  users:
  [
    "1234567890",
    "4567890123",
    "7890123456"
  ]
}


```


<a id="ID4EJD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELD"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a>リファレンス   
