---
title: GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})
assetID: dbd60c93-9d8e-609b-0ae3-b3f7ee26ba2d
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipidget.html
author: KevinAsgari
description: " GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9599d6fa427184937928da9eaaebd136a24b8cde
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6040040"
---
# <a name="get-usersowneridscidsscidclipsgameclipid"></a>GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})
すべての Id を見つけることがわかっている場合は、システムから 1 つのゲーム クリップを取得します。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EVB)
  * [Authorization](#ID4EAC)
  * [必要な要求ヘッダー](#ID4EUH)
  * [オプションの要求ヘッダー](#ID4EBCAC)
  * [要求本文](#ID4ETDAC)
  * [HTTP ステータス コード](#ID4E5DAC)
  * [必要な応答ヘッダー](#ID4EQIAC)
  * [省略可能な応答ヘッダー](#ID4EJLAC)
  * [応答本文](#ID4EJMAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
クリップを照会するすべてのデータは**GameClip**オブジェクトとして任意のメタデータ クエリから返される利用できます。 この API を介して 1 つのゲーム クリップを取得するのには、 **XUID**、 **ServiceConfigId**、 **GameClipId**要求の要求で**SandboxId**が必要です。 ゲーム クリップが実施のフラグが設定された、またはコンテンツの分離またはプライバシー チェックがユーザーに特定のゲーム クリップを取得するためのアクセス許可が必要がない判断、API は 404 (見つかりません) の HTTP ステータス コードを返します。
 
**SandboxId**はできるようになりました、XToken で要求から取得し、適用します。 **SandboxId**が存在しない場合のエンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。
 
この API は、有効期限が切れた Uri の更新にも使用する必要があります。 クエリが完了したら、ゲーム クリップに有効期限が切れたな Uri が更新されたそれに応じて。 

> [!NOTE] 
> URI 更新を最大に 30 ~ 40 秒かかりますこの要求を完了後します。 URI の有効期限が切れた場合を使用してすぐにストリーミング操作しようとすると、IIS スムーズ ストリーミング サーバーから HTTP 500 ステータス コードが取得します。 これには、短縮する方法に取り組んでいます、この注がその作業の進行に応じて更新されます。 


  
<a id="ID4EVB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| ownerId| string| リソースにアクセスしているユーザーのユーザー id。 サポートされる形式:"me"または"xuid(123456789)"します。 最大長: 16 します。| 
| scid| string| アクセスされているリソースのサービス構成 ID。 認証されたユーザーの SCID が一致する必要があります。| 
| gameClipId| string| GameClip にアクセスしているリソースの ID です。| 
  
<a id="ID4EAC"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 種類| 必須?| 値の例| 注釈| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Xuid| 64 ビットの符号付き整数| 必須| 1234567890|  | 
| TitleId| 64 ビットの符号付き整数| 必須| 1234567890| <b>コンテンツ分離</b>チェックに使用されます。| 
| SandboxId| 16 進数のバイナリ| 必須|  | 検索では、適切な領域をシステムに指示し、<b>コンテンツ分離</b>チェックに使用します。| 
  
リソースのプライバシーの設定の効果 | ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| me| -| 前述のようにします。| 
| フレンド登録の依頼| すべてのユーザー| 禁止されています。| 
| フレンド登録の依頼| フレンドのみ| 禁止されています。| 
| フレンド登録の依頼| ブロック| 禁止されています。| 
| フレンド以外のユーザー| すべてのユーザー| 禁止されています。| 
| フレンド以外のユーザー| フレンドのみ| 禁止されています。| 
| フレンド以外のユーザー| ブロック| 禁止されています。| 
| サード パーティのサイト| すべてのユーザー| 禁止されています。| 
| サード パーティのサイト| フレンドのみ| 禁止されています。| 
| サード パーティのサイト| ブロック| 禁止されています。| 
 
<a id="ID4EUH"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例: <b>Xauth =&lt;authtoken ></b>| 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。| 
  
<a id="ID4EBCAC"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 受け入れ可能な圧縮エンコードします。 値の例: gzip、圧縮の id。| 
| ETag| string| キャッシュの最適化のために使用します。 値の例:"686897696a7c876b7e"します。| 
| 範囲| string|  | 
  
<a id="ID4ETDAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4E5DAC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 301| 完全に移動|  | 
| 307| 一時的なリダイレクト|  | 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求にかかった時間が長すぎます。| 
| 410| なった| 要求されたリソースが利用可能ではなくなりました。| 
  
<a id="ID4EQIAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。| 
| Retry-after| string| クライアントが利用できないサーバーの場合、後で再試行するように指示します。 例:<b>アプリケーション/json</b>します。| 
| 異なる| string| 下位のプロキシの応答をキャッシュする方法を指示します。 例:<b>アプリケーション/json</b>します。| 
  
<a id="ID4EJLAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ETag| string| キャッシュの最適化のために使用します。 値の例:"686897696a7c876b7e"します。| 
  
<a id="ID4EJMAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EPMAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
 "gameClip": {
   "xuid": "2716903703773872",
   "clipName": "1234567890",
   "titleName": "",
   "gameClipId": "cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
   "state": "Published",
   "dateRecorded": "2013-05-08T21:32:17.4201279Z",
   "lastModified": "2013-05-08T21:34:48.8117829Z",
   "userCaption": "",
   "type": "DeveloperInitiated",
   "source": "Console",
   "visibility": "Public",
   "durationInSeconds": 30,
   "scid": "00000000-0000-0012-0023-000000000070",
   "titleId": 0,
   "rating": 0,
   "ratingCount": 0,
   "views": 0,
   "titleData": "",
   "systemProperties": "",
   "savedByUser": false,
   "thumbnails": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/large",
       "fileSize": 0,
       "thumbnailType": "Large"
     },
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/small",
       "fileSize": 0,
       "thumbnailType": "Small"
     }
   ],
   "gameClipUris": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
       "fileSize": 9332015,
       "uriType": "Download",
       "expiration": "9999-12-31T23:59:59.9999999"
     }
   ]
 }
}
         
```

   
<a id="ID4EZMAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2MAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/{ownerId}/scids/{scid}/clips/{gameClipId}](uri-usersowneridscidclipsgameclipid.md)

  
<a id="ID4EFNAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[マーケットプレース URI](../marketplace/atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   