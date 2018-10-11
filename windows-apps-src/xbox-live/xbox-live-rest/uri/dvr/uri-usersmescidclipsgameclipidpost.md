---
title: POST (/users/me/scids/{scid}/clips/{gameClipId})
assetID: 410aecad-57f9-c3dc-f35f-19c4d8dfb704
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipidpost.html
author: KevinAsgari
description: " POST (/users/me/scids/{scid}/clips/{gameClipId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 28c8b9e20e990c51c6b3d7e56e72f4d5d6551b39
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4530675"
---
# <a name="post-usersmescidsscidclipsgameclipid"></a>POST (/users/me/scids/{scid}/clips/{gameClipId})
ユーザーのデータのゲーム クリップ メタデータを更新します。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に問題の URI の機能に依存します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EAB)
  * [必要な要求ヘッダー](#ID4ELB)
  * [オプションの要求ヘッダー](#ID4EXD)
  * [要求本文](#ID4EAF)
  * [必要な応答ヘッダー](#ID4EVF)
  * [省略可能な応答ヘッダー](#ID4EJAAC)
  * [応答本文](#ID4EJBAC)
  * [関連する Uri](#ID4EWBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ゲーム クリップ メタデータを更新するための API は、自分自身のゲーム クリップのアクセシビリティやタイトルなどのメタデータを更新し、パブリックの属性 (に評価を適用することや、ビュー カウントをインクリメント) などの更新は、2 つのカテゴリに分類されます。 その他の任意のゲーム クリップのします。 URI の XUID での要求で XUID が一致しない場合、パブリック データのみを編集できるし、他のデータを編集するすべての要求が拒否されます。 編集する場合は、複数のフィールドがしようとして、それらのいずれかが正しくない要求の全体の要求は失敗します。
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| アクセスされているリソースのサービス構成 ID。 認証されたユーザーの SCID に一致する必要があります。| 
| gameClipId| string| GameClip にアクセスしているリソースの ID です。| 
  
<a id="ID4ELB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例: <b>Xauth =&lt;authtoken ></b>| 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定する正し要求します。| 
  
<a id="ID4EXD"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 受け入れ可能な圧縮エンコードします。 値の例: gzip、身元を圧縮します。| 
| ETag| string| キャッシュの最適化のために使用します。 値の例:"686897696a7c876b7e"。| 
  
<a id="ID4EAF"></a>

 
## <a name="request-body"></a>要求本文
 
要求の本文には、JSON 形式で[UpdateMetadataRequest](../../json/json-updatemetadatarequest.md)オブジェクトを使う必要があります。 例:
 
ユーザーのクリップ名と認知度を変更します。
 

```cpp
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。
 

```cpp
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EVF"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定する正し要求します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| Retry-after| string| クライアントが利用できないサーバーの場合、後で再試行するように指示します。| 
| 異なる| string| 下位のプロキシ応答をキャッシュする方法を指示します。| 
  
<a id="ID4EJAAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Etag| string| キャッシュの最適化のために使用します。 例:"686897696a7c876b7e"。| 
  
<a id="ID4EJBAC"></a>

 
## <a name="response-body"></a>応答本文
 
HTTP ステータス コード 200 メタデータの更新が成功時に返されます。
 
それ以外の場合、適切な HTTP 状態コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。
  
<a id="ID4EWBAC"></a>

 
## <a name="related-uris"></a>関連する Uri
 
次の Uri は、メタデータのパブリック フィールドを更新します。 これらの要求に必要な本文はありません。 HTTP ステータス コード 200 メタデータの更新が成功時に返されます。 それ以外の場合、適切な HTTP 状態コードを JSON 形式で ServiceErrorResponse オブジェクトが返されます。
 
   * **POST/users/{ownerId} {scid}/scids//clips/{gameClipId}/ratings/{評価値}** - には、指定したクリップに指定した評価が適用されます。 評価値 1 ~ 5 間整数である必要があります。
   * **/Users/{ownerId} {scid}/scids//clips/{gameClipId} を投稿/フラグ**- クリップを実施してがオンにする可能性のある問題のあるコンテンツが含まフラグが設定されます。
   * **POST/users/{ownerId} {scid}/scids//clips/{gameClipId} ビュー/** -指定されたゲーム クリップのビューのカウントをインクリメントします。 これはという名前のない適切な再生の 75%-80% が完了したとき、再生が開始されるをお勧めします。
   
<a id="ID4EMCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOCAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/scids/{scid}/clips/{gameClipId}](uri-usersmescidclipsgameclipid.md)

   