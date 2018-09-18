---
title: Reward (JSON)
assetID: d1c92e8a-afbc-22c5-c0b5-6063963f8c4d
permalink: en-us/docs/xboxlive/rest/json-reward.html
author: KevinAsgari
description: " Reward (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ddecacdf77305b6c9449bd5e903a5e4c0fa74d7
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4016763"
---
# <a name="reward-json"></a>Reward (JSON)
実績に関連付けられているリワードです。
<a id="ID4EN"></a>


## <a name="reward"></a>リワード

リワード オブジェクトでは、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| name| string| ユーザーに表示されるリワードの名前です。|
| description| string| ユーザーに表示されるリワードの説明です。|
| value| string| リワードの値です。|
| type| RewardType 列挙| リワードの種類: <ul><li>無効 (0): 不明なおよびサポートされていないリワード型が構成されています。</li><li>(1): ゲーマー スコア リワードでは、プレイヤーのゲーマー スコアにポイントを追加します。</li><li>inApp (2): リワードが定義されているし、タイトルによって配信します。</li><li>アート (3): リワードは、デジタル資産です。</li></ul> | 
| valueType| ProgressValueDataType 列挙| 値の種類です。 詳細については、[要件 (JSON)](json-requirement.md)を参照してください。|

<a id="ID4EBD"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)
