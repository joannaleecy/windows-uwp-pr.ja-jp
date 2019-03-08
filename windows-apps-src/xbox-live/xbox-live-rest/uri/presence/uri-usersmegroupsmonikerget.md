---
title: GET (/users/me/groups/{moniker} )
assetID: c2527a08-411b-d4e4-422f-a8438804bfe6
permalink: en-us/docs/xboxlive/rest/uri-usersmegroupsmonikerget.html
description: " GET (/users/me/groups/{moniker} )"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 553ff55610ce30461bc6523aaed732aedc1efd18
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595117"
---
# <a name="get-usersmegroupsmoniker-"></a>GET (/users/me/groups/{moniker} )
グループ、PresenceRecord を取得します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [クエリ文字列パラメーター](#ID4EJB)
  * [承認](#ID4EKC)
  * [リソースのプライバシーの設定の効果](#ID4EQD)
  * [必要な要求ヘッダー](#ID4EEH)
  * [省略可能な要求ヘッダー](#ID4EMBAC)
  * [要求本文](#ID4EMCAC)
  * [HTTP 状態コード](#ID4EXCAC)
  * [必要な応答ヘッダー](#ID4E3GAC)
  * [省略可能な応答ヘッダー](#ID4EMJAC)
  * [応答本文](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
要求でユーザーに関連するモニカーで指定されたグループ内のユーザーを取得し、これらのユーザーに対して PresenceRecord を返します。 プライバシーやコンテンツの分離で区切られているデータは単に返されません。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| モニカー| string| ユーザーのグループを定義する文字列。 現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| level| string| このクエリ文字列で指定された詳細情報のレベルを返します。 有効なオプションには、"user"、"device"、"title"および「すべて」が含まれます。"User"、レベルは、DeviceRecord 入れ子になったオブジェクトがない PresenceRecord オブジェクトです。 「デバイス」のレベルは、TitleRecord 入れ子になったオブジェクトがない PresenceRecord と DeviceRecord オブジェクトです。 "Title"、レベルは、ActivityRecord 入れ子になったオブジェクトがない PresenceRecord、DeviceRecord、TitleRecord オブジェクトです。 「すべて」のレベルは、入れ子になったすべてのオブジェクトを含む、全体のレコードです。このパラメーターが指定されていない場合、サービスのタイトルのレベルに既定値 (タイトルの詳細には、このユーザーのプレゼンスを返します、)。| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 種類| 必須?| 値の例| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>xuid</b>| 64 ビット符号付き整数| ○| 1234567890| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
サービスは常に返します 200 OK 要求自体が正しく構成されている場合。 ただし、プライバシーに関するチェックが適合しない場合に、応答からの情報をフィルター処理には。
 
リソースのプライバシーの設定の効果 | 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Me| -| 前述のようにします。| 
| friend| すべてのユーザー| 前述のようにします。| 
| friend| 友達のみ| 前述のようにします。| 
| friend| ブロック済み| -の説明に従ってそのサービスと、データが除外されます。| 
| フレンド以外のユーザー| すべてのユーザー| 前述のようにします。| 
| フレンド以外のユーザー| 友達のみ| -の説明に従ってそのサービスと、データが除外されます。| 
| フレンド以外のユーザー| ブロック済み| -の説明に従ってそのサービスと、データが除外されます。| 
| サード パーティのサイト| すべてのユーザー| -の説明に従ってそのサービスと、データが除外されます。| 
| サード パーティのサイト| 友達のみ| -の説明に従ってそのサービスと、データが除外されます。| 
| サード パーティのサイト| ブロック済み| -の説明に従ってそのサービスと、データが除外されます。| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。| 
| OK| string| コンテンツ型が許容されます。 1 つだけの存在がサポートされますが<b>、application/json</b>が、まだ必要がありますに指定するヘッダー。| 
| Accept Language| string| 応答内の文字列に対して許容されるロケール。 値の例: en-us (英語)。| 
| Host| string| サーバーのドメイン名。 値の例: userpresence.xboxlive.com します。| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. | 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 405| 許可されていないメソッド| HTTP メソッドは、サポートされていないコンテンツの種類で使用されました。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 500| 要求のタイムアウト| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 503| 要求のタイムアウト| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:1、vnext。| 
| Content-Type| string| 要求の本文の mime の種類。 値の例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。 値の例:"no-cache"。| 
| X-XblCorrelationId| string| サーバーが返すし、クライアントによって受信されるを関連付けるためにサービスによって生成された値。 値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"。| 
| X のコンテンツの種類オプション| string| SDL 準拠の値を返します。 値の例:"nosniff"。| 
| 日付| string| 日付/時刻、メッセージが送信されました。 値の例:"(火)、17 年 2012年 11 月 10時 33分: 31 GMT」。| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 再試行後| string| 503 HTTP エラーで返されます。 クライアント呼び出しを再試行する前に待機する時間に知ることができます。 値の例:"120".| 
| Content-Length| string| 応答本文の長さ。 値の例:"527".| 
| コンテンツ エンコーディング| string| 応答のエンコードの種類。 値の例:"gzip"です。| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a>応答本文
 
この API は、要求から Xuid ごとに 1 つ PresenceRecord オブジェクトの配列を返します。
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
[
     {
         xuid:"0123456789",
         state:"online",
         devices:
         [
             {
                 type:"D",
                 titles:
                 [
                     {
                         id:"12341234",
                         name:"Contoso 5",
                         lastModified:"2012-09-17T07:15:23.4930000",
                         placement:"full",
                         state:"active",
                         activity:
                         {
                             richPresence:"Playing on Nirvana"
                         },
                     }
                 ]
             }
         ]
     },
     {
         xuid:"0123456780",
         state:"online",
         devices:
         [
             {
                 type:"D",
                 titles:
                 [
                     {
                         id:"12341235",
                         name:"Contoso Waypoint",
                         lastModified:"2012-09-17T07:15:23.4930000",
                         placement;"full",
                         state:"active",
                         activity:
                         {
                             richPresence:"Viewing stats"
                         },
                     }
                 ]
             }
         ]
     },
     {
         xuid:"0123456781",
         state:"online",
         devices:
         [
             {
                 type:"Win8",
                 titles:
                 [
                     {
                         id:"23452345",
                         name:"Contoso Gamehelp",
                         state:"active",
                         timestamp:"2012-09-17T07:15:23.4930000",
                         activity:
                         {
                             richPresence:"Viewing help"
                         }
                     }
                 ]
             }
         ]
     }
 ]
         
```

   
<a id="ID4EQLAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/groups/{moniker}](uri-usersmegroupsmoniker.md)

   