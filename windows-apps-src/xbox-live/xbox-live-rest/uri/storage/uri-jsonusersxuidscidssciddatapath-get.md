---
title: GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})
assetID: ab73c1af-d914-b498-6a12-8f74eec349d0
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapath-get.html
description: " GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f292ca5d1d0968445d91a507384188af1db5cf5b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594047"
---
# <a name="get-jsonusersxuidxuidscidssciddatapath"></a>GET (/json/users/xuid({xuid})/scids/{scid}/data/{path})
指定されたパスにファイル情報を一覧表示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [省略可能なクエリ文字列パラメーター](#ID4ECB)
  * [承認](#ID4EUC)
  * [必要な要求ヘッダー](#ID4EBD)
  * [要求本文](#ID4EKE)
  * [HTTP 状態コード](#ID4EXE)
  * [応答本文](#ID4EKCAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。| 
| scid| guid| 検索するサービス構成の ID。| 
| パス| string| 返されるデータのアイテムへのパス。 一致するすべてのディレクトリとサブディレクトリが返されるを取得します。 有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。 空にすることがあります。 最大長は 256 です。| 
  
<a id="ID4ECB"></a>

 
## <a name="optional-query-string-parameters"></a>省略可能なクエリ文字列パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| skipItems| int| N 個の項目をスキップする、コレクション内の N + 1 で始まる項目を返します。| 
| continuationToken| string| 指定された継続トークンで始まる項目を返します。 ContinuationToken パラメーターよりも優先 skipItems 両方を指定しない場合。 つまり、skipItems パラメーターには、continuationToken パラメーターが存在する場合は無視されます。| 
| maxItems| int| SkipItems と項目の範囲を取得するように continuationToken と組み合わせて使用できるコレクションから返されるアイテムの最大数。 MaxItems が存在しないと、maxItems、未満を返すことが場合の結果の最後のページが返されていない場合でも、サービスに、既定値であると指定可能性があります。 | 
  
<a id="ID4EUC"></a>

 
## <a name="authorization"></a>Authorization 
 
要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。 ヘッダーが無効であるか不足している場合、サービスは、401 を返します。 
  
<a id="ID4EBD"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| STS の認証トークンです。 STSTokenString は、認証要求によって返されるトークンに置き換えられます。 STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EKE"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EXE"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4EKCAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、の配列を返しますが[TitleBlob](../../json/json-titleblob.md)オブジェクト。
 
<a id="ID4EYCAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
"blobs":
[
    {
        "fileName":"foo\bar\blob.txt,json",
        "clientFileTime":"2012-01-01T01:02:03.1234567Z",
        "displayName":"Friendly Name",
        "size":12,
        "etag":"0x8CEB3E4F8F3A5BF"
    },
    {
        "fileName":"foo\bar\blob2.txt,json",
        "displayName":"Blob 2",
        "size":4,
        "etag":"0x8CEB3FE57F1A142"
    },
    {
        "fileName":"foo\jsonblob.txt,json",
        "size":15,
        "etag":"0x8CEB40152B4A6F8"
    }
],
"pagingInfo":
    {
        "continuationToken":"54",
    }
}
         
```

   
<a id="ID4EEDAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGDAC"></a>

 
##### <a name="parent"></a>Parent  

[/json/users/xuid({xuid})/scids/{scid}/data/{path}](uri-jsonusersxuidscidssciddatapath.md)

  
<a id="ID4ESDAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a>参照[TitleBlob (JSON)](../../json/json-titleblob.md)

 [PagingInfo (JSON)](../../json/json-paginginfo.md)

   