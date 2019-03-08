---
title: Reward (JSON)
assetID: d1c92e8a-afbc-22c5-c0b5-6063963f8c4d
permalink: en-us/docs/xboxlive/rest/json-reward.html
description: " Reward (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d58d34263e7e0e90091c41c1df4fd5e078f5055
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607497"
---
# <a name="reward-json"></a>Reward (JSON)
実績に関連付けられている特典です。
<a id="ID4EN"></a>


## <a name="reward"></a>報酬

Reward オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| name| string| 報酬のユーザーに表示される名前。|
| 説明| string| 報酬のユーザーに表示される説明です。|
| value| string| 報酬の値。|
| type| RewardType 列挙型| 報酬の種類: <ul><li>(0) が無効です。報酬を不明なサポートされていない型が構成されました。</li><li>ゲーマー (1):報酬は、プレーヤーのゲーマーにポイントを追加します。</li><li>inApp (2):報酬が定義され、タイトルに配信します。</li><li>アート (3):報酬は、デジタル資産です。</li></ul> | 
| ValueType| ProgressValueDataType 列挙型| 値の型。 参照してください[要件 (JSON)](json-requirement.md)詳細についてはします。|

<a id="ID4EBD"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


```json
{
  "name":null,
  "description":null,
  "value":"10",
  "type":"Gamerscore",
  "valueType":"Int"
}

```


<a id="ID4EKD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EMD"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)
