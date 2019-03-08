---
title: GET (/users/xuid({xuid})/achievements)
assetID: 381d49d1-7a4b-4a1e-1baf-cf674f7e0d54
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsgetv2.html
description: " GET (/users/xuid({xuid})/achievements)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 720170e88808db7ef95b88896fbca4f1cda4a091
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655267"
---
# <a name="get-usersxuidxuidachievements"></a>GET (/users/xuid({xuid})/achievements)
タイトル、進行中のユーザーがまたは、ユーザーがロックを解除するもので定義された実績の一覧を取得します。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [クエリ文字列パラメーター](#ID4ECB)
  * [承認](#ID4ENF)
  * [必要な要求ヘッダー](#ID4ESG)
  * [省略可能な要求ヘッダー](#ID4ESH)
  * [要求本文](#ID4EIBAC)
  * [応答本文](#ID4ETBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID)、ユーザーが (リソース) がアクセスされているのです。 認証されたユーザーの XUID に一致する必要があります。| 
  
<a id="ID4ECB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 必須| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| <b>skipItems</b>| X| 32 ビット符号付き整数| 指定されたアイテム数の後に開始アイテムを返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降の 4 番目の項目を取得します。 | 
| <b>continuationToken</b>| X| string| 指定された継続トークンで始まる項目を返します。 | 
| <b>maxItems</b>| X| 32 ビット符号付き整数| 組み合わせて使用できるコレクションから返されるアイテムの最大数<b>skipItems</b>と<b>continuationToken</b>を項目の範囲を返します。 場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b>結果の最後のページが返されていない場合でも、します。 | 
| <b>titleId</b>| X| string| 返される結果をフィルターします。 1 つまたは複数のタイトルをコンマ区切りの 10 進識別子を受け取ります。| 
| <b>unlockedOnly</b>| X| ブール値| 返される結果を返すフィルター。 場合設定<b>true</b>ユーザーのロックを解除する実績をのみを返すには。 既定値は<b>false</b>します。| 
| <b>possibleOnly</b>| X| ブール値| 返される結果を返すフィルター。 場合に設定<b>true</b>、すべての可能な結果が返されますが、いないだけのメタデータのロックを解除 XMS から情報アチーブメントが獲得されました。 既定値は<b>false</b>します。| 
| <b>型</b>| X| string| 返される結果をフィルターします。 "Persistent"または「チャレンジ」を指定できます。 既定ではサポートされているすべての型です。| 
| <b>OrderBy</b>| X| string| 結果が返される順序を指定します。 「順不同」、"Title""UnlockTime"または"EndingSoon"を指定できます。 既定値は「順不同」。| 
  
<a id="ID4ENF"></a>

 
## <a name="authorization"></a>Authorization
 
| 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| 呼び出し元は、Xbox LIVE 権限を持つユーザーです。| 呼び出し元は、Xbox LIVE の有効なユーザーである必要があります。| 403 許可されていません| 
  
<a id="ID4ESG"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
  
<a id="ID4ESH"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>X RequestedServiceVersion</b>| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. | 
| <b>x-xbl-contract-version</b>| 32 ビット符号なし整数| 存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。 それ以外の場合、V1 します。| 
| <b>Accept-Language</b>| string| 目的のロケールとフォールバック (FR-FR、fr、EN-GB、en WW、EN-US など) の一覧です。 ローカライズされた文字列の一致が見つかるまで一覧をアチーブメント サービスの動作します。 見つからない場合、ユーザーの IP アドレスから付属しているユーザー トークンで定義されている場所を照合しようと試みます。 いない対応するローカライズされた文字列もが見つかった場合は、タイトルの開発者/発行元によって提供される既定の文字列を使用します。 | 
  
<a id="ID4EIBAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4ETBAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、の配列を返します[アチーブメントが獲得されました (JSON)](../../json/json-achievementv2.md)オブジェクトと[PagingInfo (JSON)](../../json/json-paginginfo.md)オブジェクト。
 
<a id="ID4ECCAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
    "achievements":
    [{
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
                "achievementState":"Achieved",
                "requirements":null,
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
        }],
        "pagingInfo":
        {
                "continuationToken":null,
                "totalRecords":1
        }
}
         
```

   
<a id="ID4EPCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/achievements](uri-achievementsusersxuidachievementsv2.md)

  
<a id="ID4E2CAC"></a>

 
##### <a name="reference"></a>リファレンス 

[アチーブメントが獲得されました (JSON)](../../json/json-achievementv2.md)

 [PagingInfo (JSON)](../../json/json-paginginfo.md)

 [ページングのパラメーター](../../additional/pagingparameters.md)

   