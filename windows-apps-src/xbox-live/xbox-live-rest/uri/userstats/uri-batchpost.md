---
title: POST (/batch)
assetID: f5997c8e-82c7-0fba-9991-ce1116db4830
permalink: en-us/docs/xboxlive/rest/uri-batchpost.html
description: " POST (/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a854fc830c87afbf675a379599916bf3db919539
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645837"
---
# <a name="post-batch"></a>POST (/batch)
複数のタイトル、プレーヤーの統計情報を複数の複雑なバッチ要求の GET メソッドとして機能するメソッドを投稿します。 これらの Uri のドメインが`userstats.xboxlive.com`します。
 
<a id="ID4ET"></a>

 
## <a name="remarks"></a>注釈
 
タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。
  
  * [注釈](#ID4ET)
  * [注釈](#ID4EFB)
  * [承認](#ID4EUB)
  * [必要な要求ヘッダー](#ID4ETC)
  * [省略可能な要求ヘッダー](#ID4E3D)
  * [要求本文](#ID4EAF)
  * [HTTP 状態コード](#ID4EWF)
  * [応答本文](#ID4ENBAC)
 
<a id="ID4EFB"></a>

 
## <a name="remarks"></a>注釈
 
呼び出し元は、ユーザー、サービスの構成 Id (SCIDs) およびこれらの統計情報を取得する対象の SCIDs ごとの統計名の一覧の配列で、メッセージ本文を提供します。
 
単純な 1 つ統計情報を確認するのには役に立つ場合があります[取得](uri-usersxuidscidsscidstatsget.md)メソッドのこの複雑ですが、バッチ モードのページを読む前にします。
  
<a id="ID4EUB"></a>

 
## <a name="authorization"></a>Authorization
 
コンテンツの分離とアクセス制御のシナリオで実装された承認ロジックがあります。
 
   * 呼び出し元の要求に有効な XSTS トークンを送信すること、任意のプラットフォーム上のクライアントからランキングおよびユーザーの両方の統計情報を読み取ることができます。 サポートされているクライアントに明らかに制限されています。 書き込みは、します。
   * タイトルの開発者は、オープンまたは XDP またはパートナー センターで制限付きとして統計をマークできます。 ランキングは、統計を開くです。 統計を開くはサンド ボックスに、ユーザーが承認されている限り、Smartglass、だけでなく iOS、Android、Windows、Windows Phone、および web アプリケーションでアクセスできます。 サンド ボックスにユーザーの承認は、XDP またはパートナー センターで管理されます。
  
次の例は、チェックの擬似コードに示します。
 

```cpp
If (!checkAccess(serviceConfigId, resource, CLAIM[userid, deviceid, titleid]))
{
        Reject request as Unauthorized
}

// else accept request.
         
```

  
<a id="ID4ETC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
  
<a id="ID4E3D"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求が送られるサービスの名前/番号をビルドします。 要求はのみにルーティング サービスの認証トークンの要求ヘッダーの有効性を確認した後と。 ［既定値］:1. | 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4EIF"></a>

 
### <a name="sample-request"></a>要求のサンプル
 
次の POST の本文は、2 人のユーザーの 2 つの異なる SCIDs から 4 つの統計情報が要求されていることをサービスに通知します。
 

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

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 304| 変更されていません| リソースされていない最後の要求以降に変更します。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。| 
  
<a id="ID4ENBAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EXBAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

   