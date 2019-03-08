---
title: POST (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 410aecad-57f9-c3dc-f35f-19c4d8dfb704
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipidpost.html
description: " POST (/users/me/scids/{scid}/clips/{gameClipId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 89f3b53631f5570ab6d0d0619f6678fc3e3c2dd2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645827"
---
# <a name="post-usersmescidsscidclipsgameclipid"></a>POST (/users/me/scids/{scid}/clips/{gameClipId})
ユーザーのデータのゲームのクリップのメタデータを更新します。 これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EAB)
  * [必要な要求ヘッダー](#ID4ELB)
  * [省略可能な要求ヘッダー](#ID4EXD)
  * [要求本文](#ID4EAF)
  * [必要な応答ヘッダー](#ID4EVF)
  * [省略可能な応答ヘッダー](#ID4EJAAC)
  * [応答本文](#ID4EJBAC)
  * [関連する Uri](#ID4EWBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ゲームのクリップのメタデータを更新するための API は、1 のゲームのクリップ、タイトル、アクセシビリティなどのメタデータを更新、および更新 (評価を適用することや、ビューのカウントをインクリメント) などのパブリック属性の 2 つのカテゴリに分類の他のゲームのクリップの。 URI に XUID が、要求で XUID が一致しない場合は、パブリック データのみを編集できるし、他のデータを編集するすべての要求は拒否されます。 編集を試行している複数のフィールドの場合とうち 1 つは、要求に対して無効です、全体の要求は失敗します。
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| string| サービス アクセスされているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| アクセスされているリソースの ID をゲーム クリップだった。| 
  
<a id="ID4ELB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>| 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
  
<a id="ID4EXD"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。| 
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a>要求本文
 
要求の本文にする必要があります、 [UpdateMetadataRequest](../../json/json-updatemetadatarequest.md) JSON 形式のオブジェクト。 例:
 
ユーザーのクリップの名前を変更して、可視性:
 

```cpp
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
(これはほんの一例であるため、このフィールドのスキーマは、呼び出し元) のタイトルのプロパティだけを変更するには。
 

```cpp
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EVF"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。| 
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。| 
  
<a id="ID4EJAAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Etag| string| キャッシュの最適化に使用されます。 以下に例を示します。"686897696a7c876b7e"。| 
  
<a id="ID4EJBAC"></a>

 
## <a name="response-body"></a>応答本文
 
HTTP 状態コード 200 のメタデータの更新の完了時に返されます。
 
それ以外の場合、適切な HTTP 状態コードで JSON 形式で ServiceErrorResponse オブジェクトが返されます。
  
<a id="ID4EWBAC"></a>

 
## <a name="related-uris"></a>関連する Uri
 
次の Uri は、メタデータにパブリック フィールドを更新します。 これらの要求に必要な本文はありません。 HTTP 状態コード 200 のメタデータの更新の完了時に返されます。 それ以外の場合、適切な HTTP 状態コードで JSON 形式で ServiceErrorResponse オブジェクトが返されます。
 
   * **POST/users/{ownerId} {scid}/scids//clips/{gameClipId}/ratings/評価 {value}** -指定したクリップを指定された評価が適用されます。 評価の値 1 から 5 まで整数である必要があります。
   * **/Users/{ownerId} {scid}/scids//clips/{gameClipId} を投稿/フラグ**-強制でチェックする可能性のある問題のあるコンテンツを格納するクリップのフラグを設定します。
   * **POST/users/{ownerId} {scid}/scids//clips/{gameClipId} ビュー/** -指定したゲームのクリップのビューのカウントをインクリメントします。 これはという名前のいない適切な再生の 75% ~ 80% が完了したときに再生が開始されるをお勧めします。
   
<a id="ID4EMCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOCAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/scids/{scid}/clips/{gameClipId}](uri-usersmescidclipsgameclipid.md)

   