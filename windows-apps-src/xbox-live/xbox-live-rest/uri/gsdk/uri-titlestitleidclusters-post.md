---
title: POST (/titles/{titleId}/clusters)
assetID: 0977b0b0-872d-f7ad-9ba0-30d56cff4912
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidclusters-post.html
author: KevinAsgari
description: " POST (/titles/{titleId}/clusters)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c87af8cb76ce452c067edddb55c382d8c604ca25
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6209862"
---
# <a name="post-titlestitleidclusters"></a>POST (/titles/{titleId}/clusters)
Xbox Live Compute サーバー インスタンスを作成するクライアントをできる URI。 これらの Uri のドメインが`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [必要な要求ヘッダー](#ID4EGB)
  * [Authorization](#ID4ELD)
  * [要求本文](#ID4EWD)
  * [必要な応答ヘッダー](#ID4EZE)
  * [応答本文](#ID4E5G)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| titleId| 要求の操作のタイトルの ID です。| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverms.xboxlive.com
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合、次の表に示すようにヘッダーは必要です。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | 
| ユーザー エージェント|  | 要求を行っているユーザー エージェントについて説明します。| 
| Content-Type| application/json| 送信されたデータの種類です。| 
| Host| gameserverms.xboxlive.com|  | 
| Content-Length|  | 要求のオブジェクトの長さ。| 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
| Authorization| XBL3.0 x = [ハッシュ]。[トークン]| 認証トークン。| 
  
<a id="ID4ELD"></a>

 
## <a name="authorization"></a>Authorization
 
要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは応答に 403 Forbidden を返します。 ヘッダーが見つからないか無効な場合は、サービスは応答で 401 Unauthorized を返します。
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a>要求本文
 
要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| sessionId| MPSD からセッション識別子です。| 
| abortIfQueued| 省略可能なパラメーターは、どの場合に true に設定する場合はすぐにフルフィルメントしないことができますが、リソースのこのセッションをキューに入れいない GSMS に指示します。 この値が true であるため、要求が中止されると、応答オブジェクトを含むは<code>"fulfillmentState" : "Aborted"</code>します。 | 
 
<a id="ID4ERE"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
{
  "sessionId" : "/serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/session/scott1",
  "abortIfQueued" : "true"
}

      
```

   
<a id="ID4EZE"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
応答は常に、次の表に示すようにヘッダーを含めます。
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| キャッシュ コントロール|  | ディレクティブ要求/応答のチェーンに沿ったのすべてのキャッシュ メカニズムによって obeyed する必要があります。| 
| Content-Type| application/json| 応答には、データの種類です。| 
| Content-Length|  | 応答本文の長さ。| 
| X コンテンツの種類オプション|  |  | 
| X XblCorrelationId|  | 応答本文の mime タイプ。| 
| Date|  |  | 
  
<a id="ID4E5G"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| pollIntervalMilliseconds| (ミリ秒) の完了をポーリング間隔をお勧めします。 注意がこれには、クラスターが準備ができたら、するときの推定値ではありませんが、サブスクリプションと要求とフルフィルメントの完了率の現在のプールを指定された状態を更新する頻度、呼び出し元のポーリングを行うための推奨事項ではなく。| 
| fulfillmentState| 提供されているセッションは、リソースをすぐに割り当てられたかどうか「フルフィルメント、」リソースの今後の可用性のキューに追加される「キューに入れ」を示すまたは中止され、「中止」、要求を処理することができない原因とすぐに、要求"true"と指定した abortIfQueued します。 | 
 
<a id="ID4EWH"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
  "pollIntervalMilliseconds" : "1000",
  "fulfillmentState" : "Fulfilled" | "Queued" | "Aborted"
}
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a>注釈
 
次の応答コードを受け取ったとき、タイトルはサービスへの呼び出しをのみ再試行する必要があります。
 
   * 408-サーバー タイムアウト
   * 429: too Many Requests
   * 500-サーバー エラー
   * 502-無効なゲートウェイ
   * 503-Service Unavailable
   * 504-ゲートウェイ タイムアウト
   
<a id="ID4EFBAC"></a>

 
## <a name="see-also"></a>関連項目
 [/titles/{titleId}/clusters](uri-titlestitleidclusters.md)

  