---
title: POST (/batch)
assetID: f5997c8e-82c7-0fba-9991-ce1116db4830
permalink: en-us/docs/xboxlive/rest/uri-batchpost.html
author: KevinAsgari
description: " POST (/batch)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: db832032a40b40d4b3a774a56487f7065d9cd8ff
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4463329"
---
# <a name="post-batch"></a>POST (/batch)
POST メソッドは複数のタイトルに複数のプレイヤーの統計情報の複雑なバッチ要求の GET メソッドとして機能します。 これらの Uri のドメインが`userstats.xboxlive.com`します。
 
<a id="ID4ET"></a>

 
## <a name="remarks"></a>注釈
 
タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。
  
  * [注釈](#ID4ET)
  * [注釈](#ID4EFB)
  * [Authorization](#ID4EUB)
  * [必要な要求ヘッダー](#ID4ETC)
  * [オプションの要求ヘッダー](#ID4E3D)
  * [要求本文](#ID4EAF)
  * [HTTP ステータス コード](#ID4EWF)
  * [応答本文](#ID4ENBAC)
 
<a id="ID4EFB"></a>

 
## <a name="remarks"></a>注釈
 
呼び出し元では、ユーザー、サービス構成 Id (Scid)、およびそれらの統計情報を取得するための Scid ごとの統計情報名の一覧の配列でメッセージの本文が提供されます。
 
詳しくは、見つけることがある前に[GET](uri-usersxuidscidsscidstatsget.md)メソッド読み取りより複雑なこのバッチ モード ページ、シンプルな単一統計情報を確認すると便利です。
  
<a id="ID4EUB"></a>

 
## <a name="authorization"></a>Authorization
 
コンテンツ分離とアクセス制御のシナリオ向けに実装承認ロジックがあります。
 
   * ランキング、およびユーザーの両方の統計情報は、呼び出し元が要求に有効な XSTS トークンを送信している、任意のプラットフォーム上のクライアントから読み取ることができます。 書き込みはでサポートされているクライアントに明らかに制限します。
   * タイトル デベロッパーは、open または XDP またはデベロッパー センターで制限付きの統計情報をマークできます。 ランキングは、統計を開くです。 開いている統計情報は、サンド ボックスに、ユーザーが承認されている限り、Smartglass、ほか、iOS、Android、Windows、Windows Phone、および web アプリケーションによってアクセスできます。 サンド ボックスへのユーザーの承認は XDP またはデベロッパー センターで管理されます。
  
次の例では、チェックの擬似コードを示します。
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4ETC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。| 
  
<a id="ID4E3D"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求を送信する必要があります、サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4EIF"></a>

 
### <a name="sample-request"></a>要求の例
 
次の POST 本文には、2 つの異なるユーザーに対する 2 つの異なる Scid から 4 つの統計情報が要求されているサービスが通知されます。
 

```cpp
{    
"requestedusers": [
                1234567890123460,
                1234567890123234
            ],
            "requestedscids": [
                {
                    "scid": "c402ff50-3e76-11e2-a25f-0800200c1212",
                    "requestedstats": [
                        "Test4FirefightKills",
                        "Test4FirefightHeadshots"
                    ]
                },
                {
                    "scid": "c402ff50-3e76-11e2-a25f-0800200c0343",
                    "requestedstats": [
                        "OverallTestKills",
                        "TestHeadshots"
                    ]
                }
            ] 
}
      
```

   
<a id="ID4EWF"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 304| Not Modified| リソースされていない以降に変更するように要求します。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC レイヤーによって拒否する必要があります。| 
  
<a id="ID4ENBAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EXBAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{    
   "users":[          
       {    
      "xuid": "123456789"
        "gamertag": "WarriorSaint",
        "scids":[
          {
             "scid":"c402ff50-3e76-11e2-a25f-0800200c1212",
             "stats":  [
          {
                 "statname":"Test4FirefightKills",
                 "type":"Integer",
                 "value":7
             },
          {
                 "statname":"Test4FirefightHeadshots",
                 "type":"Integer",
                 "value":4
             }]
                        },
          {
             "scid":"c402ff50-3e76-11e2-a25f-0800200c0343",
             "stats":  [
          {
                 "statname":"OverallTestKills",
                 "type":"Integer",
                 "value":3434
             },
          {
                 "statname":"TestHeadshots",
                 "type":"Integer",
                 "value":41
             }]
          }],
                   },
    {    
                   "gamertag":"TigerShark",
                   "xuid":1234567890123234
        "scids":[
          {
             "scid":"123456789",
             "stats":  [
          {
                 "statname":"Test4FirefightKills",
                 "type":"Integer",
                 "value":63
             },
          {
                 "statname":"Test4FirefightHeadshots",
                 "type":"Integer",
                 "value":12
             }]
                        },
          {
"scid":"987654321",
             "stats":  [
          {
                 "statname":"OverallTestKills",
                 "type":"Integer",
                 "value":375
             },
          {
                 "statname":"TestHeadshots",
                 "type":"Integer",
                 "value":34
             }]
          }],
                   }]
}
         
```

   
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a>Parent 

[/batch](uri-batch.md)

   