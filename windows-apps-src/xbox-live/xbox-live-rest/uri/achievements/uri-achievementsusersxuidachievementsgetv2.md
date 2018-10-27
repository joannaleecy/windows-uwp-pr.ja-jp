---
title: GET (/users/xuid({xuid})/achievements)
assetID: 381d49d1-7a4b-4a1e-1baf-cf674f7e0d54
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsgetv2.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/achievements)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 550a835bf729b22c9adc79a15ef643fa1cb009b2
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5684252"
---
# <a name="get-usersxuidxuidachievements"></a>GET (/users/xuid({xuid})/achievements)
タイトル、進行中のユーザーが、または、ユーザーがロックを解除するもので定義されている実績の一覧を取得します。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [クエリ文字列パラメーター](#ID4ECB)
  * [Authorization](#ID4ENF)
  * [必要な要求ヘッダー](#ID4ESG)
  * [オプションの要求ヘッダー](#ID4ESH)
  * [要求本文](#ID4EIBAC)
  * [応答本文](#ID4ETBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) が (リソース) にアクセスしているユーザーのします。 認証されたユーザーの XUID が一致する必要があります。| 
  
<a id="ID4ECB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 必須かどうか| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| <b>skipItems</b>| いいえ| 32 ビット符号付き整数| 特定の項目数後以降の項目を返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。 | 
| <b>continuationToken</b>| いいえ| string| 特定の継続トークンから始まる項目を返します。 | 
| <b>maxItems</b>| いいえ| 32 ビット符号付き整数| <b>SkipItems</b>と項目の範囲を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。 サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。 | 
| <b>titleId</b>| いいえ| string| 返される結果のフィルターします。 1 つまたは複数のコンマで区切られた、10 進数のタイトル id を受け取ります。| 
| <b>unlockedOnly</b>| いいえ| ブール値| 返された結果をフィルター処理します。 場合を<b>true</b>に設定、ユーザーのロック解除した実績をのみが返さになります。 既定値は<b>false</b>。| 
| <b>possibleOnly</b>| いいえ| ブール値| 返された結果をフィルター処理します。 場合<b>は true</b>に設定、使用可能なすべての結果がロックされていないいないメタデータ - XMS の実績情報だけが返されます。 既定値は<b>false</b>。| 
| <b>種類</b>| いいえ| string| 返される結果のフィルターします。 「固定」または"Challenge"できます。 既定ではサポートされているすべての種類です。| 
| <b>orderBy</b>| いいえ| string| 結果が返される順序を指定します。 「順序指定されていない」、「タイトル」、"UnlockTime"または"EndingSoon"を指定できます。 既定値は「順序なし」します。| 
  
<a id="ID4ENF"></a>

 
## <a name="authorization"></a>Authorization
 
| 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| 呼び出し元が、承認された Xbox LIVE ユーザーです。| 呼び出し元では、Xbox LIVE で有効なユーザーを指定する必要があります。| 403 Forbidden| 
  
<a id="ID4ESG"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"します。| 
  
<a id="ID4ESH"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>X RequestedServiceVersion</b>| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。| 
| <b>x xbl コントラクト バージョン</b>| 32 ビットの符号なし整数| 存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。 それ以外の場合、V1 します。| 
| <b>同意言語</b>| string| 目的のロケールとフォールバック (FR-FR, fr, EN-GB、en 世界、EN-US など) の一覧です。 ローカライズされた文字列の一致が見つかるまで、実績サービスは、一覧で動作します。 見つからない場合は、ユーザーの IP アドレスに由来するユーザーのトークンで定義されている場所と一致しようとします。 まだ一致するローカライズされた文字列はありません。 が見つかった場合、タイトル開発者または発行元によって提供される既定の文字列を使用します。 | 
  
<a id="ID4EIBAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4ETBAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、[実績 (JSON)](../../json/json-achievementv2.md)オブジェクトと[PagingInfo (JSON)](../../json/json-paginginfo.md)オブジェクトの配列を返します。
 
<a id="ID4ECCAC"></a>

 
### <a name="sample-response"></a>応答の例
 

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
                "url":"http://www.xbox.com"
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

[Achievement (JSON)](../../json/json-achievementv2.md)

 [PagingInfo (JSON)](../../json/json-paginginfo.md)

 [ページング パラメーター](../../additional/pagingparameters.md)

   