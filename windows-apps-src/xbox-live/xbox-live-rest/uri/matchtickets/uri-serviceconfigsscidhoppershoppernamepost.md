---
title: POST (/serviceconfigs/{scid}/hoppers/{hoppername})
assetID: 8cbf62aa-d639-e920-1e39-099133af17f8
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamepost.html
author: KevinAsgari
description: " POST (/serviceconfigs/{scid}/hoppers/{hoppername})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e585f4a16ec54ad23fe1a458294d6c0cd13eb6ed
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5872030"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a>POST (/serviceconfigs/{scid}/hoppers/{hoppername})

指定したマッチ チケットを作成します。

> [!IMPORTANT]
> このメソッドは、コントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [HTTP ステータス コード](#ID4E3C)
  * [要求本文](#ID4EFD)
  * [応答本文](#ID4E3G)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、サービス構成 ID (SCID) レベルで特定の名前をホッパーのマッチ チケットを作成します。 このメソッドは、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッドでラップすることができます。  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| hoppername | string | ホッパーの名前。 |

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| 特権とデバイスの種類| 必須| ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しには、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。 | 403|
| デバイスの種類| 必須| とき、ユーザーの deviceType が省略されてか以外のコンソールに一致するタイトルに設定する必要がありますないコンソール専用のタイトル。 | 403|
| タイトル ID/実証購入/デバイスの種類| 必須| タイトルに一致するには、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。 | 403|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EFD"></a>


## <a name="request-body"></a>要求本文

<a id="ID4ELD"></a>


### <a name="required-members"></a>必要なメンバー

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| serviceConfig| GUID| セッションの SCID です。|
| hopperName| string| ホッパーの名前です。|
| giveUpDuration| 32 ビット符号付き整数| 最大待機時間 (秒の整数)。|
| preserveSession| 列挙型| かどうかには、セッションに一致するセッションとして再利用を示す値。 値は、「ことはありません」と"always"します。 |
| ticketSessionRef| MultiplayerSessionReference| プレイヤーまたはグループは、現在再生中のセッションの MultiplayerSessionReference オブジェクト。 |
| ticketAttributes| オブジェクトのコレクション| 属性とプレイヤーのグループのユーザーが指定した値です。|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a>禁止されているメンバー

要求では、その他のすべてのメンバーが禁止されています。

<a id="ID4ECG"></a>


### <a name="sample-request"></a>要求の例

マッチ チケットを作成して、セッションは、プレイヤーに固有の属性と共に、一致するプレイヤーを含める必要があります前に、 **ticketSessionRef**オブジェクトによって参照されるセッションを作成する必要があります。 各プレイヤーは、作成またはセッションにマッチが関連付けられている属性の追加、MPSD からセッションに参加する必要があります。 マッチの属性は、プレイヤーごとに matchAttrs と呼ばれるカスタム プロパティのフィールドに配置されます。

作成または参加要求を提出する**http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。


```cpp
{
   "members": {
     "me": {
       "constants": {
         "system": {
           "xuid": 2535285330879750
         }
      },
      "properties": {
         "custom": {
           "matchAttrs": {
             "skill": 5,
             "ageRange": "teenager"
           }
         }
      }
    }
  }
}

```


セッションが作成されたら、タイトルはそのセッションのチケットを作成するマッチメイ キング サービスを呼び出すことができます。


> [!NOTE] 
> タイトルでは、この呼び出しを再試行するユーザーを有効にすることができますが、再試行しないでください。 が自動的にデータが失敗した場合。  



```cpp
POST /serviceconfigs/{scid}/hoppers/{hoppername}

{
  "giveUpDuration":10,
  "preserveSession": "never",
  "ticketSessionRef": {
     "scid": "ABBACDDC-0000-0000-0000-000000000001",  
     "templateName": "TestTemplate",
     "name": "5E55104-0000-0000-0000-000000000001"
  },
  "ticketAttributes": {
    "desiredMap": "Test Map",
    "desiredGameType": "Test GameType"
  }
}

```


<a id="ID4E3G"></a>


## <a name="response-body"></a>応答本文

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ticketId| GUID| チケットの作成中の ID です。|
| 待機時間| 32 ビット符号付き整数| 平均の待機時間 (秒の整数)、ホッパー。|


```cpp
{
  "ticketId":"0584338f-a2ff-4eb9-b167-c0e8ddecae72",
  "waitTime":60
}

```


<a id="ID4EHAAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EJAAC"></a>


##### <a name="parent"></a>Parent  

[/serviceconfigs/{scid}/hoppers/{hoppername}](uri-serviceconfigsscidhoppershoppername.md)
