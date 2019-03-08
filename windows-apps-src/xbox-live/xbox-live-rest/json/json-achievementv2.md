---
title: Achievement (JSON)
assetID: d3b52f66-ddc7-e676-b419-82209caf71d6
permalink: en-us/docs/xboxlive/rest/json-achievementv2.html
description: " Achievement (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0e20f46a0d97cba496df5c6fb9cda14fbeccccd
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628477"
---
# <a name="achievement-json"></a>Achievement (JSON)
アチーブメント オブジェクト (バージョン 2)。
<a id="ID4EN"></a>


## <a name="achievement"></a>アチーブメントが獲得されました

アチーブメント オブジェクトには、次の仕様があります。 すべてのメンバーが必要です。

| メンバー| 種類| 説明|
| --- | --- | --- |
| id| string| リソースの識別子です。|
| serviceConfigId| string| このリソースの SCID します。 この実績に関連するタイトルを識別します。 |
| name| string| ローカライズされたアチーブメント名前。|
| titleAssociations| 配列[TitleAssociation](json-titleassociation.md)| TitleAssociation の配列。|
| progressState| **ProgressState**列挙型| 進行状況の状態。 <ul><li>(0) が無効です。アチーブメントの進行状況は、不明な状態です。</li><li>(1) を実現するには。アチーブメントのロックが解除されました。</li><li>処理中 (2):実績はロックされていますが、ロックの解除に向けた進行状況をユーザーが行ったします。</li><li>notStarted (3):実績がロックされているし、ユーザーがロックの解除進行を行っていません。</li></ul> | 
| 進行状況| [進行状況](json-progression.md)| アチーブメント内で、ユーザーの進行状況。|
| mediaAssets| 配列[MediaAsset](json-mediaasset.md)| イメージ Id など、実績に関連付けられているメディア資産。 |
| プラットフォーム| string| プラットフォームの実績を獲得します。|
| isSecret| ブール値| 実績がシークレットかどうか。|
| 説明| string| ロック解除する場合は、実績の説明です。|
| lockedDescription| string| ロックが解除する前に、実績の説明です。|
| productId| string| ProductId 実績はと共にリリースされました。|
| achievementType| **AchievementType**列挙型| アチーブメントが獲得されました (いないと同じレガシ アチーブメントの前の型) の種類: <ul><li>(0) が無効です。不明なとサポート非対象のアチーブメント型の場合。</li><li>永続的な (1):終了日を持たず、任意の時点でロックできるを達成します。</li><li>課題 (2):ない場合がロックされている特定の時間枠を持つ達成します。</li></ul> |
| participationType| **ParticipationType**列挙型| アチーブメントの参加の種類。 有効な値は、個人またはグループは。|
| Timewindow プロパティ| Timewindow プロパティ| 達成できない可能性がありますロックされた時間枠。 課題のみサポートされます。|
| 報酬| 配列の[報酬](json-reward.md)| ロック解除する場合に達成報酬のコレクション。|
| EstimatedTime| TimeSpan| 推定所要時間を獲得する実績になります。|
| ディープ リンク| string| タイトルにディープ リンク。|
| isRevoked| ブール値| かどうか実績は、強制では失効します。|

<a id="ID4EIAAC"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


```json
{
        "id":"3",
        "serviceConfigId":"b5dd9daf-0000-0000-0000-000000000000",
        "name":"Default NameString for Microsoft Achievements Sample Achievement 3",
        "titleAssociations":
        [{
                "name":"Microsoft Achievements Sample",
                "id":3051199919,
                "version":"abc"
        }],
        "progressState":"Achieved",
        "progression":
        {
          "requirements":
          [{
            "id":"12345678-1234-1234-1234-123456789012",
            "current":null,
            "target":"100"
          }],
          "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
        },
        "mediaAssets":
        [{
                "name":"Icon Name",
                "type":"Icon",
                "url":"https://www.xbox.com"
        }],
        "platform":"D",
        "isSecret":true,
        "description":"Default DescriptionString for Microsoft Achievements Sample Achievement 3",
        "lockedDescription":"Default UnachievedString for Microsoft Achievements Sample Achievement 3",
        "productId":"12345678-1234-1234-1234-123456789012",
        "achievementType":"Challenge",
        "participationType":"Individual",
        "timeWindow":
        {
                "startDate":"2013-02-01T00:00:00Z",
                "endDate":"2100-07-01T00:00:00Z"
        },
        "rewards":
        [{
                "name":null,
                "description":null,
                "value":"10",
                "type":"Gamerscore",
                "valueType":"Int"
        },
        {
                "name":"Default Name for InAppReward for Microsoft Achievements Sample Achievement 3",
                "description":"Default Description for InAppReward for Microsoft Achievements Sample Achievement 3",
                "value":"1",
                "type":"InApp",
                "valueType":"String"
        }],
        "estimatedTime":"06:12:14",
        "deeplink":"aWFtYWRlZXBsaW5r",
        "isRevoked":false
    }

```


<a id="ID4ERAAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ETAAC"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)
