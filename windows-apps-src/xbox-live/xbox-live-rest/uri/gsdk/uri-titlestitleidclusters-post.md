---
title: POST (/titles/{titleId}/clusters)
assetID: 0977b0b0-872d-f7ad-9ba0-30d56cff4912
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidclusters-post.html
description: " POST (/titles/{titleId}/clusters)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 91d7c49628914f887c5d2243942e10e47d47b095
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608907"
---
# <a name="post-titlestitleidclusters"></a>POST (/titles/{titleId}/clusters)
により、クライアントは Xbox Live コンピューティング サーバー インスタンスを作成する URI。 これらの Uri のドメインが`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [必要な要求ヘッダー](#ID4EGB)
  * [承認](#ID4ELD)
  * [要求本文](#ID4EWD)
  * [必要な応答ヘッダー](#ID4EZE)
  * [応答本文](#ID4E5G)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作対象のタイトルの ID。| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverms.xboxlive.com
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合は、次の表に示されているヘッダーが必要です。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | 
| ユーザー エージェント|  | 要求を行うユーザー エージェントに関する情報。| 
| Content-Type| application/json| 送信されるデータの型。| 
| Host| gameserverms.xboxlive.com|  | 
| Content-Length|  | 要求オブジェクトの長さ。| 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| 認証トークンです。| 
  
<a id="ID4ELD"></a>

 
## <a name="authorization"></a>Authorization
 
要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは応答 403 Forbidden を返します。 ヘッダーが無効であるか不足している場合、サービスは応答で 401 Unauthorized を返します。
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a>要求本文
 
要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| sessionId| MPSD からセッション識別子。| 
| abortIfQueued| 省略可能なパラメーターは、どの場合に true に設定されませんをすぐに実行しないことができます、場合にリソースとして、このセッションをキューに GSMS に指示します。 応答オブジェクトには、要求が中止されたは、この値が true であるため場合、<code>"fulfillmentState" : "Aborted"</code>します。 | 
 
<a id="ID4ERE"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
{
  "sessionId" : "/serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/session/scott1",
  "abortIfQueued" : "true"
}

      
```

   
<a id="ID4EZE"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
応答には、常に、次の表に示すようにヘッダーが含まれます。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| キャッシュ制御|  | 要求/応答のチェーンに沿ってすべてのキャッシュ メカニズムによって obeyed する必要がありますディレクティブ。| 
| Content-Type| application/json| 応答内のデータの型。| 
| Content-Length|  | 応答本文の長さ。| 
| X のコンテンツの種類オプション|  |  | 
| X-XblCorrelationId|  | 応答本文の mime の種類。| 
| 日付|  |  | 
  
<a id="ID4E5G"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| pollIntervalMilliseconds| (ミリ秒) の完了をポーリングする間隔をお勧めします。 これには、クラスターが準備完了となる場合の推定値ではありませんので注意が、呼び出し元がサブスクリプションと要求と調達の料金の現在のプールを指定された状態の更新をポーリングする頻度の推奨事項ではなく。| 
| fulfillmentState| 指定されたセッションは、リソースをすぐに割り当てられたかどうか"Fulfilled、"将来のリソースの可用性のためにキューに追加された"Queued"、ことを示しますまたは中止され、「中止」、要求を処理することができないのためすぐに要求"true"として abortIfQueued を指定します。 | 
 
<a id="ID4EWH"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
  "pollIntervalMilliseconds" : "1000",
  "fulfillmentState" : "Fulfilled" | "Queued" | "Aborted"
}
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a>注釈
 
タイトルがサービスへの呼び出しを再試行する必要がありますは、次の応答コードが受信したときにのみ。
 
   * 408-サーバーのタイムアウト
   * 429: 要求が多すぎます
   * 500-サーバー エラー
   * 502-無効なゲートウェイ
   * 503-サービス利用不可
   * 504-ゲートウェイ タイムアウト
   
<a id="ID4EFBAC"></a>

 
## <a name="see-also"></a>関連項目
 [/titles/{titleId}/clusters](uri-titlestitleidclusters.md)

  