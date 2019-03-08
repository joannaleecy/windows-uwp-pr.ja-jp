---
title: POST (/serviceconfigs/{scid}/hoppers/{hoppername})
assetID: 8cbf62aa-d639-e920-1e39-099133af17f8
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamepost.html
description: " POST (/serviceconfigs/{scid}/hoppers/{hoppername})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7682b92ec61c98679904825e360d73318e9fee90
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659837"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a>POST (/serviceconfigs/{scid}/hoppers/{hoppername})

指定した一致のチケットを作成します。

> [!IMPORTANT]
> このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [HTTP 状態コード](#ID4E3C)
  * [要求本文](#ID4EFD)
  * [応答本文](#ID4E3G)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、サービス構成の ID (SCID) レベルで特定の名前を hopper の一致のチケットを作成します。 このメソッドをラップすることができます、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッド。  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| hoppername | string | Hopper の名前。 |

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| 特権とデバイスの種類| ○| ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。 | 403|
| デバイスの種類| ○| ときに、ユーザーの deviceType が存在しないまたはコンソール以外でに一致するタイトルに設定するには、コンソールのみのタイトルがすることはできません。 | 403|
| タイトルの購入/デバイスの種類 ID/実証| ○| 一致するタイトルは、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。 | 403|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EFD"></a>


## <a name="request-body"></a>要求本文

<a id="ID4ELD"></a>


### <a name="required-members"></a>必須メンバー

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| serviceConfig| GUID| セッションの SCID します。|
| hopperName| string| Hopper の名前です。|
| giveUpDuration| 32 ビット符号付き整数| 最大待機時間 (秒単位の整数)。|
| preserveSession| 列挙| かどうかに一致するセッションとセッションは再利用を示す値。 指定できる値は、"never"と「常に」です。 |
| ticketSessionRef| MultiplayerSessionReference| プレーヤーまたはグループが現在を再生中のセッションの MultiplayerSessionReference オブジェクト。 |
| ticketAttributes| オブジェクトのコレクション| 属性とプレイヤーのグループについて、ユーザーによって提供される値。|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a>禁止されているメンバー

要求では、その他のすべてのメンバーが禁止されています。

<a id="ID4ECG"></a>


### <a name="sample-request"></a>要求のサンプル

によって参照される、セッション、 **ticketSessionRef**一致チケットを作成して、セッションは、プレーヤーに固有の属性と、一致するプレーヤーを含める必要があります前に、オブジェクトを作成する必要があります。 各プレーヤーは、作成またはセッションに関連する一致属性を追加、MPSD に対してセッションに参加する必要があります。 一致する属性は、各プレーヤーの matchAttrs をという名前のカスタム プロパティ フィールドに配置されます。

作成または参加要求が送信される**https://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。


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


セッションが作成されたら、タイトルは、そのセッションのチケットを作成するマッチメイ キング サービスを呼び出すことができます。


> [!NOTE] 
> タイトルは、この呼び出しを再試行するユーザーを有効にできますが、再試行できませんに自動的にデータが失敗した場合。  



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
| TicketId| GUID| 作成されるチケットの ID。|
| 待機時間| 32 ビット符号付き整数| 平均の待機時間 (秒単位の整数) hopper。|


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
