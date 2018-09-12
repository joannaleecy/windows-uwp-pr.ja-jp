---
title: POST (/serviceconfigs//hoppers/{呼び出します})
assetID: 8cbf62aa-d639-e920-1e39-099133af17f8
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamepost.html
author: KevinAsgari
description: " POST (/serviceconfigs//hoppers/{呼び出します})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 089aba60b80e629a8068bcf39f009ac97fc6ad66
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881617"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a>POST (/serviceconfigs//hoppers/{呼び出します})

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

この HTTP/REST メソッドでは、サービス構成 ID (SCID) レベルで特定の名前をホッパーのマッチ チケットを作成します。 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッドでは、以下のメソッドをラップすることができます。  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成 id (SCID)。|
| 呼び出します | string | ホッパーの名前です。 |

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| 特権とデバイスの種類| 必須| ユーザーの deviceType がコンソールに設定されているとき、マッチメイ キング サービスへの呼び出しには、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。 | 403|
| デバイスの種類| 必須| ユーザーの deviceType が存在しない場合や、コンソール以外に、タイトルにマッチされるに設定することはできません、コンソール専用のタイトルとします。 | 403|
| タイトル ID/実証購入/デバイスの種類| 必須| タイトルに一致するには、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。 | 403|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4EFD"></a>


## <a name="request-body"></a>要求本文

<a id="ID4ELD"></a>


### <a name="required-members"></a>必要なメンバー

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| serviceConfig| GUID| セッションの SCID です。|
| 呼び出します| string| ホッパーの名前。|
| giveUpDuration| 32 ビットの符号付き整数| 最大待機時間 (秒の整数)。|
| preserveSession| 列挙| かどうかには、セッションに一致するセッションとして再利用を示す値。 値は"always"と「ことはありません」です。 |
| ticketSessionRef| MultiplayerSessionReference| されるプレイヤーまたはグループは、現在再生中のセッションの MultiplayerSessionReference オブジェクト。 |
| ticketAttributes| オブジェクトのコレクション| 属性とプレイヤーのグループのユーザーが指定した値です。|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a>禁止されているメンバー

要求では、他のすべてのメンバーが禁止されています。

<a id="ID4ECG"></a>


### <a name="sample-request"></a>要求の例

マッチ チケットを作成して、セッションは、プレイヤーに固有の属性と共に、対戦するプレイヤーを含める必要があります前に、 **ticketSessionRef**オブジェクトによって参照されるセッションを作成する必要があります。 各プレイヤーは、作成またはセッションにマッチが関連付けられている属性の追加、MPSD からセッションに参加する必要があります。 マッチの属性は、各プレイヤーに matchAttrs と呼ばれるカスタム プロパティのフィールドに配置されます。

作成または参加要求を送信する**http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。


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
| 待機時間| 32 ビットの符号付き整数| 平均時間 (秒の整数)、ホッパーを待機します。|


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

[/serviceconfigs//hoppers/{呼び出します}](uri-serviceconfigsscidhoppershoppername.md)