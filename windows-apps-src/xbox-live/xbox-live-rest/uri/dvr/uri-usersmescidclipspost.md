---
title: POST (ユーザー/me/global/scids/{scid} クリップ/)
assetID: 44535926-9fb8-5498-b1c8-514c0763e6c9
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipspost.html
author: KevinAsgari
description: " POST (ユーザー/me/global/scids/{scid} クリップ/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2e6cee1adbe9e9401bec2ce578ab0d04da921170
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3956513"
---
# <a name="post-usersmescidsscidclips"></a>POST (ユーザー/me/global/scids/{scid} クリップ/)
初期のアップロード要求を実行します。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EFB)
  * [Authorization](#ID4EQB)
  * [必要な要求ヘッダー](#ID4EKC)
  * [オプションの要求ヘッダー](#ID4ENE)
  * [要求本文](#ID4ENF)
  * [要求の例](#ID4E1F)
  * [HTTP ステータス コード](#ID4EDG)
  * [応答本文](#ID4EVAAC)
  * [応答の例](#ID4EFBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
これは、ゲーム クリップだったアップロード プロセスの最初の部分です。 ビデオのキャプチャ時にサービスを呼び出して、GameClips のビット、アップロードの ID と URI を取得するには、すぐをすぐに開始アップロードがスケジュールされていない場合でも、お勧めします。 この呼び出しは、ユーザー クォータ チェックやその他のチェックにして、ビデオがする必要があります、クライアントによってアップロードでもスケジュールするかどうかは、プライバシー、コンテンツの分離を通じて実行されます。 この呼び出しから正の応答では、サービスが許容アップロード用のビデオ クリップを示します。 アップロードされたすべてのクリップは、システムでは受け入れを (SCID) を通じて、特定のタイトルに関連付けする必要があります。
 
この呼び出しでない等です。後続の呼び出しと、別の Id と Uri が発行されます。 エラー発生時における再試行は、標準的なクライアント側バックオフ動作に従う必要があります。
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| アクセスされているリソースのサービス構成 ID。 認証されたユーザーの SCID に一致する必要があります。| 
  
<a id="ID4EQB"></a>

 
## <a name="authorization"></a>Authorization
 
次の要求は、このメソッドでは必要があります。
 
   * Xuid
   * DeviceType - デバイスをアップロードする必要があります。
   * DeviceId
   * TitleId
   * TitleSandboxId
   
<a id="ID4EKC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例: <b>Xauth =&lt;authtoken ></b>| 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの妥当性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
  
<a id="ID4ENE"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 受け入れ可能な圧縮エンコードします。 値の例: gzip、身元を圧縮します。| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a>要求本文
 
要求の本文には、JSON 形式で[InitialUploadRequest](../../json/json-initialuploadrequest.md)オブジェクトを使う必要があります。
  
<a id="ID4E1F"></a>

 
## <a name="sample-request"></a>要求の例
 

```cpp
{
   "clipNameStringId": "1193045",
   "userCaption": "OMG Look at this!",
   "sessionRef": "4587552a-a5ad-4c4c-a787-5bc5af70e4c9",
   "dateRecorded": "2012-12-23T11:08:08Z",
   "durationInSeconds": 27,
   "expectedBlocks": 7,
   "fileSize": 1234567,
   "type": "MagicMoment, Achievement",
   "source": "Console",
   "visibility": "Default",
   "titleData": "{ 'Boss': 'The Invincible' }",
   "systemProperties": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }",
   "thumbnailSource": "Offset",
   "thumbnailOffsetMillseconds": 20000,
   "savedByUser": false
 }
      
```

  
<a id="ID4EDG"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 400| Bad Request| 要求の本文でエラーが発生しましたまたはユーザーがそのクォータを超えています。| 
| 401| 権限がありません| 要求の認証トークンの形式で問題があります。| 
| 403| Forbidden| 一部の必須の要求がないか、または DeviceType はありません。| 
| 503| 許容できません。| サービスまたは一部ダウン ストリームの依存関係ダウンしています。 標準のバックオフ動作を指定して再試行します。| 
  
<a id="ID4EVAAC"></a>

 
## <a name="response-body"></a>応答本文
 
応答には、 [InitialUploadResponse](../../json/json-initialuploadresponse.md)オブジェクト、または JSON 形式で[ServiceErrorResponse](../../json/json-serviceerrorresponse.md)オブジェクトを指定します。
  
<a id="ID4EFBAC"></a>

 
## <a name="sample-response"></a>応答の例
 

```cpp
{
   "clipName": "ClipName",
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752",  
   "titleName": "TitleName",
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
         
```

  
<a id="ID4EOBAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a>Parent 

[ユーザー/me/global/scids/{scid} クリップ/](uri-usersmescidclips.md)

   