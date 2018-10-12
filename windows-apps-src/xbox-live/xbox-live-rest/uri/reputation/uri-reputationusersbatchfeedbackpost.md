---
title: POST (/users/batchfeedback)
assetID: f94dcf19-a4e3-5bd0-5276-23e43bdcae52
permalink: en-us/docs/xboxlive/rest/uri-reputationusersbatchfeedbackpost.html
author: KevinAsgari
description: " POST (/users/batchfeedback)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d62e4f7106f7f0f2c324ca2c68ea8fe476bc7bfb
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4537679"
---
# <a name="post-usersbatchfeedback"></a>POST (/users/batchfeedback)
タイトルのインターフェイスの外部のバッチ形式でフィードバックを送信するタイトルのサービスによって使用されます。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [要求本文](#ID4EX)
  * [必要なヘッダー](#ID4E3E)
  * [HTTP ステータス コード](#ID4EWG)
  * [応答本文](#ID4EDAAC)
 
<a id="ID4EX"></a>

 
## <a name="request-body"></a>要求本文 
 
呼び出し元は、その web 要求オブジェクトの [ClientCertificates] セクションで、要求の証明書を含める必要があります。
 
<a id="ID4EBB"></a>

 
### <a name="required-members"></a>必要なメンバー 
 
要求は、 **BatchFeedback**オブジェクトの配列を含める必要があります。 
  
<a id="ID4EPB"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー 
 
要求では、その他のすべてのメンバーが禁止されています。
  
<a id="ID4E3B"></a>

 
### <a name="sample-request"></a>要求の例 
 

```cpp
{
    "items" :
    [
        {
            "targetXuid": "33445566778899",
            "titleId": "6487",
            "sessionRef":
            {
                "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
                "templateName": "CaptureFlag5",
                "name": "Halo556932",
            },
            "feedbackType": "FairPlayKillsTeammates",
            "textReason": "Killed 19 team members in a single session",
            "evidenceId": null
        },
        {
            "targetXuid": "33445566778899",
            "titleId": "6487",
            "sessionRef":
            {
                "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
                "templateName": "CaptureFlag5",
                "name": "Halo556932",
            },
            "feedbackType": "FairPlayQuitter",
            "textReason": "Quit 6 times from 9 sessions",
            "evidenceId": null
        }
    ]
}

      
```

 
| <b>フィールド</b>| <b>JSON 型</b>| <b>説明</b>| 
| --- | --- | --- | 
| items| array| フィードバックの JSON ドキュメントのコレクションです。| 
| targetXuid| string| ターゲット ユーザーの XUID| 
| titleId| string| このフィードバックから送信されたタイトルまたは NULL。| 
| sessionRef| object| MPSD セッションを表すオブジェクトです。 このフィードバックが関連して、または NULL。| 
| feedbackType| string| FeedbackType 列挙体の値の文字列バージョン。| 
| textReason| string| 送信者に送信されたフィードバックの詳細情報が追加されるパートナーが指定したテキストです。| 
| evidenceId| string| 送信されたフィードバックの証拠として使用できるリソースの ID です。 例: ビデオ ファイルの ID です。| 
   
<a id="ID4E3E"></a>

 
## <a name="required-headers"></a>必要なヘッダー
 
次のヘッダーは、Xbox Live サービス要求を行ったとき必要があります。 

> [!NOTE] 
> パートナーの要求の証明書は、バッチ フィードバックを送信するために、要求と共に送信する必要があります。 


 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 101| API コントラクト バージョンです。| 
| Content-Type| application/json| 送信されたデータの種類です。| 
| Authorization| "XBL3.0 x =&lt;userhash > です。&lt;トークン >"| HTTP 認証の資格情報を認証します。| 
| X RequestedServiceVersion| 101| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。| 
  
<a id="ID4EWG"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable| 要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。| 
  
<a id="ID4EDAAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合は、この応答からのオブジェクトは返されません。 それ以外の場合、サービスは、 [ServiceError](../../json/json-serviceerror.md)オブジェクトを返します。
  
<a id="ID4EXAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EZAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/batchfeedback](uri-reputationusersbatchfeedback.md)

  
<a id="ID4EFBAC"></a>

 
##### <a name="reference"></a>リファレンス 

[Feedback (JSON)](../../json/json-feedback.md)

 [ServiceError (JSON)](../../json/json-serviceerror.md)

   