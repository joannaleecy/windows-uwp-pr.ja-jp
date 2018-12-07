---
title: DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: b4ddc3d2-890d-f677-0109-45d318c3128d
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-delete.html
description: " DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8864892392e1cfddba7f510fc0f9e7efdb2dd036
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8752800"
---
# <a name="delete-sessionssessionidscidssciddatapathandfilenametype"></a>DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
ファイルを削除します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [Authorization](#ID4EEB)
  * [必要な要求ヘッダー](#ID4ERB)
  * [オプションの要求ヘッダー](#ID4E1C)
  * [要求本文](#ID4EWD)
  * [HTTP ステータス コード](#ID4EDE)
  * [応答本文](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| sessionId| string| 検索するセッションの ID。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイルの名前です。 パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。| 
| type| 文字列| データの形式です。 使用可能な値とは、バイナリまたは json です。| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。 ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
| Authorization| XBL3.0 x = [ハッシュ]。[トークン]| STS 認証トークンです。 STSTokenString は、認証要求によって返されるトークンに置き換えられます。 STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| If-Match| 操作を完了するにより既存項目に一致する必要があります ETag を指定します。| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK | ファイルは正常に削除されたか、存在しません。| 
| 201| Created | エンティティが作成されました。| 
| 400| Bad Request | サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。 | リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト | 要求にかかった時間が長すぎます。| 
| 500| 内部サーバー エラー | サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable | 要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a>応答本文 
 
応答の本文には、オブジェクトは送信されません。
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a>Parent  

[/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}](uri-sessionssessionidscidssciddatapathandfilenametype.md)

   