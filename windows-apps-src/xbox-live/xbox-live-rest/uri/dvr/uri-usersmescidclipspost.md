---
title: POST (/users/me/scids/{scid}/clips)
assetID: 44535926-9fb8-5498-b1c8-514c0763e6c9
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipspost.html
description: " POST (/users/me/scids/{scid}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7a8973390ccbf5dd9980410f60f03a7edd78c134
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608787"
---
# <a name="post-usersmescidsscidclips"></a>POST (/users/me/scids/{scid}/clips)
初期アップロード要求を行います。 これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EFB)
  * [承認](#ID4EQB)
  * [必要な要求ヘッダー](#ID4EKC)
  * [省略可能な要求ヘッダー](#ID4ENE)
  * [要求本文](#ID4ENF)
  * [要求のサンプル](#ID4E1F)
  * [HTTP 状態コード](#ID4EDG)
  * [応答本文](#ID4EVAAC)
  * [応答のサンプル](#ID4EFBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
これは、ゲーム クリップだったアップロード プロセスの最初の部分です。 ビデオのキャプチャ時をすぐに開始、アップロードがスケジュールされていない場合でも、bits のアップロードの ID と URI を取得するには、すぐにゲーム クリップ サービスを呼び出すことが推奨されます。 この呼び出しはユーザーのクォータ チェックとビデオがする必要があります、クライアントによってアップロードもスケジュールされるかどうかを参照してください、という具合に、プライバシー、コンテンツの分離によるその他のチェックを実行します。 この呼び出しから肯定応答では、サービスがアップロードのビデオ クリップを許容できることを示します。 承諾するのには、システムには、(、SCID) を通じて特定のタイトルのアップロードのすべてのクリップが関連付けられている必要があります。
 
この呼び出しはべき等です。後続の呼び出しは、別の Id と Uri を発行できるになります。 エラー発生時の再試行は、標準的なクライアント側、バックオフ動作に従う必要があります。
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| string| サービス アクセスされているリソースの ID を構成します。 認証されたユーザーの SCID に一致する必要があります。| 
  
<a id="ID4EQB"></a>

 
## <a name="authorization"></a>Authorization
 
次の要求は、このメソッドに必要です。
 
   * xuid
   * DeviceType - デバイスをアップロードする必要があります。
   * DeviceId
   * TitleId
   * TitleSandboxId
   
<a id="ID4EKC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>| 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
  
<a id="ID4ENE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a>要求本文
 
要求の本文にする必要があります、 [InitialUploadRequest](../../json/json-initialuploadrequest.md) JSON 形式のオブジェクト。
  
<a id="ID4E1F"></a>

 
## <a name="sample-request"></a>要求のサンプル
 

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

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 400| 要求が正しくありません| 要求の本文にエラーが発生しました。 または、ユーザーは、そのクォータを超えて。| 
| 401| 権限がありません| 要求の認証トークンの形式に問題があります。| 
| 403| Forbidden| 一部の必須の要求がないか、または DeviceType はありません。| 
| 503| Not Acceptable| サービスまたはいくつかのダウン ストリームの依存関係がダウンします。 標準的なバックオフ動作で再試行してください。| 
  
<a id="ID4EVAAC"></a>

 
## <a name="response-body"></a>応答本文
 
応答ができます、 [InitialUploadResponse](../../json/json-initialuploadresponse.md)オブジェクトまたは[ServiceErrorResponse](../../json/json-serviceerrorresponse.md) JSON 形式のオブジェクト。
  
<a id="ID4EFBAC"></a>

 
## <a name="sample-response"></a>応答のサンプル
 

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

[/users/me/scids/{scid}/clips](uri-usersmescidclips.md)

   