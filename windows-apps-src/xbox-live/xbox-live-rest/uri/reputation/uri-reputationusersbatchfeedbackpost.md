---
title: POST (/users/batchfeedback)
assetID: f94dcf19-a4e3-5bd0-5276-23e43bdcae52
permalink: en-us/docs/xboxlive/rest/uri-reputationusersbatchfeedbackpost.html
description: " POST (/users/batchfeedback)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0906d32a0e15b2eaaf9c33e7f658e9e9f0cd5124
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622727"
---
# <a name="post-usersbatchfeedback"></a>POST (/users/batchfeedback)
タイトルのインターフェイスの外部でのバッチの形式でフィードバックを送信するタイトルのサービスで使用します。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [要求本文](#ID4EX)
  * [必要なヘッダー](#ID4E3E)
  * [HTTP 状態コード](#ID4EWG)
  * [応答本文](#ID4EDAAC)
 
<a id="ID4EX"></a>

 
## <a name="request-body"></a>要求本文 
 
呼び出し元は、web 要求オブジェクトの ClientCertificates セクションでは、要求証明書を含める必要があります。
 
<a id="ID4EBB"></a>

 
### <a name="required-members"></a>必須メンバー 
 
要求の配列を含める必要があります**BatchFeedback**オブジェクト。 
  
<a id="ID4EPB"></a>

 
### <a name="prohibited-members"></a>禁止されているメンバー 
 
要求では、その他のすべてのメンバーが禁止されています。
  
<a id="ID4E3B"></a>

 
### <a name="sample-request"></a>要求のサンプル 
 

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
| items| array| フィードバックの JSON ドキュメントのコレクション。| 
| targetXuid| string| ターゲット ユーザーの XUID| 
| titleId| string| このフィードバックから送信されたタイトルまたは NULL。| 
| sessionRef| オブジェクト| MPSD セッションを表すオブジェクトです。 このフィードバックは、または NULL を関連付けます。| 
| feedbackType| string| FeedbackType 列挙の値の文字列バージョン。| 
| textReason| string| 送信者は送信されたフィードバックの詳細情報を追加するパートナーが指定したテキストです。| 
| evidenceId| string| フィードバックの送信中の証拠として使用できるリソースの ID。 例: ビデオ ファイルの ID。| 
   
<a id="ID4E3E"></a>

 
## <a name="required-headers"></a>必要なヘッダー
 
Xbox Live サービス要求を行うときに、次のヘッダーが必要です。 

> [!NOTE] 
> パートナー要求の証明書は、バッチのフィードバックを送信するには、要求と共に送信する必要があります。 


 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 101| API コントラクトのバージョン。| 
| Content-Type| application/json| 送信されるデータの型。| 
| Authorization| "XBL3.0 x=&lt;userhash>;&lt;token>"| HTTP 認証の資格情報を認証します。| 
| X RequestedServiceVersion| 101| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。| 
  
<a id="ID4EWG"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。| 
| 503| サービス利用不可| 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。| 
  
<a id="ID4EDAAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合、この応答からのオブジェクトは返されません。 サービスを返しますそれ以外の場合、[サービス エラー](../../json/json-serviceerror.md)オブジェクト。
  
<a id="ID4EXAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EZAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/batchfeedback](uri-reputationusersbatchfeedback.md)

  
<a id="ID4EFBAC"></a>

 
##### <a name="reference"></a>リファレンス 

[フィードバック (JSON)](../../json/json-feedback.md)

 [サービス エラー (JSON)](../../json/json-serviceerror.md)

   