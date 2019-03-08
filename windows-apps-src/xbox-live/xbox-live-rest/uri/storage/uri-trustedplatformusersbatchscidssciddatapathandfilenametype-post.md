---
title: POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})
assetID: 0c89b845-c40f-b28e-f102-d2a96f58dcf9
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersbatchscidssciddatapathandfilenametype-post.html
description: " POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 504a73534b9ee536970caec1b5fd1ea6ce731b31
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650547"
---
# <a name="post-trustedplatformusersbatchscidssciddatapathandfilenametype"></a>POST (/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type})
同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [承認](#ID4ECB)
  * [要求本文](#ID4EPB)
  * [HTTP 状態コード](#ID4E3C)
  * [必要な応答ヘッダー](#ID4EPAAC)
  * [省略可能な応答ヘッダー](#ID4ESBAC)
  * [応答本文](#ID4E3CAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| guid| 検索するサービス構成の ID。| 
| pathAndFileName| string| アクセスする項目のパスとファイル名。 有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。| 
| type| string| データの形式です。 有効値とは、バイナリまたは json です。| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。 ヘッダーが無効であるか不足している場合、サービスは、401 を返します。 
  
<a id="ID4EPB"></a>

 
## <a name="request-body"></a>要求本文
 
| プロパティ| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| xuid| 64 ビットの符号なし整数の配列| ファイルをダウンロードする Xuid の一覧。| 
 
<a id="ID4EQC"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
{
    "xuids" : 
    [
      12345,
      45678,
      78901
    ]
}
      
```

   
<a id="ID4E3C"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求が成功します。| 
| 201| 作成日 | エンティティが作成されました。| 
| 400| 要求が正しくありません | サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可 | 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable | リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト | 要求がかかり過ぎて、完了します。| 
| 500| 内部サーバー エラー | サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。| 
| 503| サービス利用不可 | 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。| 
  
<a id="ID4EPAAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-disposition| パーツの内容について説明します。 ヘッダーの"name"および"filename"の部分は、このファイルが属しているユーザーの XUID です。| 
| HttpStatusCode| この特定のファイルを取得する HTTP ステータス コード。| 
  
<a id="ID4ESBAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ETag| ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。 その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。| 
| Content-Type| ファイルが正常に取得される場合、ファイルのコンテンツの種類になります。| 
| コンテンツ範囲| ファイルが正常に取得された、部分的なダウンロードが場合は、これは、応答に含まれているファイルのバイトの範囲です。 | 
  
<a id="ID4E3CAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、マルチパートの応答で、要求されたファイルの内容を返します。
 
<a id="ID4EGDAC"></a>

 
### <a name="sample-response"></a>応答のサンプル 
 

```cpp
HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: multipart/form-data; boundary=c0a9fd75-d036-4294-8b7b-85fea15a31bb

228
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="123"; filename="123"
HttpStatusCode: 200
ETag: 0x8CF327717411C31
Content-Type: application/octet-stream

asdf123
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="456"; filename="456"
HttpStatusCode: 200
ETag: 0x8CF32771E954BB8
Content-Type: application/octet-stream

asdf456
--c0a9fd75-d036-4294-8b7b-85fea15a31bb
Content-Disposition: binary; name="789"; filename="789"
HttpStatusCode: 404


--c0a9fd75-d036-4294-8b7b-85fea15a31bb--

0

```

   
<a id="ID4EUDAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EWDAC"></a>

 
##### <a name="parent"></a>Parent 

[/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

   