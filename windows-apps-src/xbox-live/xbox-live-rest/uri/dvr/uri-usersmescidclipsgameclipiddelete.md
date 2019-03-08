---
title: DELETE (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 486fac60-6884-2e3f-9ef8-8de5da0ad8af
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipiddelete.html
description: " DELETE (/users/me/scids/{scid}/clips/{gameClipId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 391e4d79a389c358dea83509b52782d086201ffc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622837"
---
# <a name="delete-usersmescidsscidclipsgameclipid"></a>DELETE (/users/me/scids/{scid}/clips/{gameClipId})
これらの Uri のドメインは削除ゲーム クリップ`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4ECB)
  * [承認](#ID4ENB)
  * [必要な要求ヘッダー](#ID4EYB)
  * [省略可能な要求ヘッダー](#ID4EEE)
  * [要求本文](#ID4ENF)
  * [HTTP 状態コード](#ID4EYF)
  * [必要な応答ヘッダー](#ID4EIAAC)
  * [省略可能な応答ヘッダー](#ID4E2CAC)
  * [応答本文](#ID4E2DAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ゲーム クリップ サービスからユーザーのビデオを削除するためのメカニズムを提供します。 Delete、時にすべてのメタデータと (生成されたと元) は、実際のビデオ資産がシステムから削除されます。 これは、永続的な操作です。 

> [!NOTE] 
> 指定された所有者 ID を正常に削除要求の承認トークンで呼び出し元と一致する必要があります。 


  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | 
| scid| string| サービス アクセスされているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| アクセスされているリソースの ID をゲーム クリップだった。| 
  
<a id="ID4ENB"></a>

 
## <a name="authorization"></a>Authorization
 
Xuid 要求だけでは、このメソッドに必要です。
  
<a id="ID4EYB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>| 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
  
<a id="ID4EEE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。| 
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EYF"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 204| OK| クリップが正常に削除します。| 
| 401| 権限がありません| 要求の認証トークンの形式に問題があります。| 
| 403| Forbidden| 一部の必須の要求が見つかりません。| 
| 404| 検出不可| URL で指定したクリップが存在しなかった (または、2 回目に削除された)。| 
| 503| Not Acceptable| サービスまたはいくつかのダウン ストリームの依存関係がダウンします。 標準的なバックオフ動作で再試行してください。| 
  
<a id="ID4EIAAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。| 
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。| 
  
<a id="ID4E2CAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Etag| string| キャッシュの最適化に使用されます。 以下に例を示します。"686897696a7c876b7e"。| 
  
<a id="ID4E2DAC"></a>

 
## <a name="response-body"></a>応答本文
 
サービスは、HTTP 状態コード 204 (コンテンツなし) 正常に完了するので応答します。 しようとして、同じオブジェクトを削除するか、存在しないオブジェクトは 404 を返します。
 
エラーが発生した場合、 **ServiceErrorResponse**オブジェクトが返されます。
  
<a id="ID4EJEAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELEAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/scids/{scid}/clips/{gameClipId}](uri-usersmescidclipsgameclipid.md)

   