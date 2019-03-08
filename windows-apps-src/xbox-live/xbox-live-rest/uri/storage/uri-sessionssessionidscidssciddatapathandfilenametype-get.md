---
title: GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: eef3c530-2f56-442a-fa47-f459a77f5798
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-get.html
description: " GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e97a193e4f821b9fcd31b26d3d023929f1dfda8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661927"
---
# <a name="get-sessionssessionidscidssciddatapathandfilenametype"></a>GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
ファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [承認](#ID4ECB)
  * [省略可能なクエリ文字列パラメーター](#ID4EPB)
  * [必要な要求ヘッダー](#ID4EQC)
  * [省略可能な要求ヘッダー](#ID4EZD)
  * [要求本文](#ID4EDF)
  * [HTTP 状態コード](#ID4EQF)
  * [応答ヘッダー](#ID4EDDAC)
  * [応答本文](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| sessionId| string| 検索する、セッションの ID。| 
| scid| guid| 検索するサービス構成の ID。| 
| pathAndFileName| string| アクセスする項目のパスとファイル名。 有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。| 
| type| string| データの形式です。 有効値とは、バイナリまたは json です。| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。 ヘッダーが無効であるか不足している場合、サービスは、401 を返します。 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a>省略可能なクエリ文字列パラメーター 
 
Blob の種類によって異なります。 バイナリの blob は、クエリ パラメーターをサポートしていません。
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 選択| string| 型が json である場合のみ使用できます。 応答する必要がありますだけを格納するプロパティ/の特定の値、JSON では、このパラメーターによって決定されるかを指定します。 「ドット」(.) を使用して、サブプロパティと角かっこ ('[' と ']') 配列のインデックスを指定します。 たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| STS の認証トークンです。 STSTokenString は、認証要求によって返されるトークンに置き換えられます。 STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-Match| 操作を完了する既存の項目に一致する必要がある ETag を指定します。| 
| If-None-Match| 操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。| 
| 範囲| ダウンロードするバイトの範囲を指定します。 標準の HTTP 範囲ヘッダーの形式に従います。| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ETag| ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。 その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。| 
| コンテンツ範囲| これが部分的なダウンロードである場合、このヘッダーは、ダウンロードされるバイトの範囲を指定します。| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、ファイルの内容を返します。
  
<a id="ID4EREAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETEAC"></a>

 
##### <a name="parent"></a>Parent  

[/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}](uri-sessionssessionidscidssciddatapathandfilenametype.md)

  
<a id="ID4E6EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a>参照[TitleBlob (JSON)](../../json/json-titleblob.md)

   