---
title: GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})
assetID: dbd60c93-9d8e-609b-0ae3-b3f7ee26ba2d
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipidget.html
description: " GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5d2858b11bf8fb902ea07a016c8f41db375013f9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640957"
---
# <a name="get-usersowneridscidsscidclipsgameclipid"></a>GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})
指定することのすべての Id がわかっている場合は、システムからゲームの 1 つのクリップを取得します。 これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EVB)
  * [承認](#ID4EAC)
  * [必要な要求ヘッダー](#ID4EUH)
  * [省略可能な要求ヘッダー](#ID4EBCAC)
  * [要求本文](#ID4ETDAC)
  * [HTTP 状態コード](#ID4E5DAC)
  * [必要な応答ヘッダー](#ID4EQIAC)
  * [省略可能な応答ヘッダー](#ID4EJLAC)
  * [応答本文](#ID4EJMAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
すべてのデータをクエリでは、クリップ、**ゲーム クリップだった**メタデータ クエリから返されるオブジェクトします。 **XUID**、 **ServiceConfigId**、 **GameClipId**と**SandboxId**この API を使用して 1 つのゲーム クリップを取得する要求の要求でが必要です。 ゲームのクリップは強制は、フラグが設定されている、またはコンテンツの分離やプライバシーを確認、ユーザーが特定のゲームのクリップを取得するアクセス許可を持たないことを確認、API は HTTP ステータス コード 404 (Not Found) を返します。
 
**SandboxId**今すぐ、XToken 内の要求から取得され、適用します。 場合、 **SandboxId**エンターテイメント検出サービス (EDS) は 400 Bad request エラーをスローしが存在しません。
 
この API は、有効期限が切れた Uri を更新にも使用する必要があります。 クエリが完了したら、ゲームのクリップの任意の有効期限が切れた Uri が適宜更新すること。 

> [!NOTE] 
> URI の更新は、最大 30 ~ 40 秒この要求が完了した後にかかります。 URI の有効期限が切れている場合、ストリーミング操作をすぐに使用しようとしています。 に HTTP 500 ステータス コードが IIS Smooth Streaming サーバーから取得されます。 これを短縮する方法に取り組んでいます、この注はその作業の進行状況と、それに従って更新されます。 


  
<a id="ID4EVB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | 
| ownerId| string| リソースがアクセスされているユーザーのユーザー id。 サポートされている形式:"xuid(123456789)"または"me"。 最大長:16.| 
| scid| string| サービス アクセスされているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| アクセスされているリソースの ID をゲーム クリップだった。| 
  
<a id="ID4EAC"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 種類| 必須?| 値の例| 注釈| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| xuid| 64 ビット符号付き整数| ○| 1234567890|  | 
| TitleId| 64 ビット符号付き整数| ○| 1234567890| 使用される<b>コンテンツ分離</b>を確認します。| 
| sandboxId| 16 進数のバイナリ| ○|  | 参照する場合の適切な領域をシステムに指示され、使用<b>コンテンツ分離</b>を確認します。| 
  
リソースのプライバシーの設定の効果 | 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Me| -| 前述のようにします。| 
| friend| すべてのユーザー| 禁止されています。| 
| friend| 友達のみ| 禁止されています。| 
| friend| ブロック済み| 禁止されています。| 
| フレンド以外のユーザー| すべてのユーザー| 禁止されています。| 
| フレンド以外のユーザー| 友達のみ| 禁止されています。| 
| フレンド以外のユーザー| ブロック済み| 禁止されています。| 
| サード パーティのサイト| すべてのユーザー| 禁止されています。| 
| サード パーティのサイト| 友達のみ| 禁止されています。| 
| サード パーティのサイト| ブロック済み| 禁止されています。| 
 
<a id="ID4EUH"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>| 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
  
<a id="ID4EBCAC"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。| 
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。| 
| 範囲| string|  | 
  
<a id="ID4ETDAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4E5DAC"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 301| 完全に移動|  | 
| 307| 一時的なリダイレクト|  | 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求がかかり過ぎて、完了します。| 
| 410| なった| 要求されたリソースは使用できなくします。| 
  
<a id="ID4EQIAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。 例: <b>、application/json</b>します。| 
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。 例: <b>、application/json</b>します。| 
  
<a id="ID4EJLAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。| 
  
<a id="ID4EJMAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EPMAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

[Marketplace の Uri](../marketplace/atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   