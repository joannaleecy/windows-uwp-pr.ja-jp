---
title: POST (/users/xuid({xuid})/feedback)
assetID: 48a7a510-a658-f2a3-c6bc-28a3610006e7
permalink: en-us/docs/xboxlive/rest/uri-reputationusersxuidfeedbackpost.html
description: " POST (/users/xuid({xuid})/feedback)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d8a6e118811203fd34c310840e8688c2255c6beb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660047"
---
# <a name="post-usersxuidxuidfeedback"></a>POST (/users/xuid({xuid})/feedback)
シェルを使用するのではなく、ゲームのフィードバックのオプションを追加したい場合、タイトルから使用されます。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EZ)
  * [必要な要求ヘッダー](#ID4EEB)
  * [要求本文](#ID4ENC)
  * [必要なヘッダー](#ID4EDE)
  * [承認](#ID4EXF)
  * [HTTP 状態コード](#ID4EEG)
  * [応答本文](#ID4EZH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| ulong| Xbox ユーザー ID (XUID)、ユーザーが報告されているのです。| 
  
<a id="ID4EEB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:101.| 
  
<a id="ID4ENC"></a>

 
## <a name="request-body"></a>要求本文 
 
<a id="ID4EVC"></a>

 
### <a name="required-members"></a>必須メンバー 
 
要求に含める必要があります、[フィードバック](../../json/json-feedback.md)オブジェクト。 
  
<a id="ID4EED"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー 
 
要求では、その他のすべてのメンバーが禁止されています。
  
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a>要求のサンプル 
 

```cpp
{
    "sessionRef":
    {
        "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
        "templateName": "CaptureFlag5",
        "name": "Halo556932",
    },
    "feedbackType": "CommsAbusiveVoice",
    "textReason": "He called me a doodoo-head!",
    "voiceReasonId": null,
    "evidenceId": null
}

      
```

   
<a id="ID4EDE"></a>

 
## <a name="required-headers"></a>必要なヘッダー
 
Xbox Live サービス要求を行うときに、次のヘッダーが必要です。
 
| <b>ヘッダー</b>| <b>値</b>| <b>Deacription</b>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 101| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| STS の認証トークンです。 STSTokenString は、認証要求によって返されるトークンに置き換えられます。| 
Content-Type| 
application/json| 
送信されるデータの型。| 
  
<a id="ID4EXF"></a>

 
## <a name="authorization"></a>Authorization
 
要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 Forbidden コードを返します。 ヘッダーが無効であるか不足している場合、サービスは、401 未承認のコードを返します。
  
<a id="ID4EEG"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 204| コンテンツはありません| 要求が完了したらが、コンテンツを返すことはありません。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求がかかり過ぎて、完了します。| 
| 409| Conflict| 継続トークンが無効になりました。| 
  
<a id="ID4EZH"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合、この応答からのオブジェクトは返されません。 サービスを返しますそれ以外の場合、[サービス エラー](../../json/json-serviceerror.md)オブジェクト。
  
<a id="ID4EOAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/feedback](uri-reputationusersxuidfeedback.md)

  
<a id="ID4E3AAC"></a>

 
##### <a name="reference"></a>リファレンス 

[フィードバック (JSON)](../../json/json-feedback.md)

 [サービス エラー (JSON)](../../json/json-serviceerror.md)

   