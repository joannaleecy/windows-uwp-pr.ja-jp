---
title: GET (/{uri})
assetID: a67a3288-88f9-c504-5fa8-8fd06055d079
permalink: en-us/docs/xboxlive/rest/uri-uriget.html
description: " GET (/{uri})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 757d84c9ad5a005e042b42d699ada08504dc57ff
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650617"
---
# <a name="get-uri"></a>GET (/{uri})
ゲームのクリップをダウンロードします。 これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EDB)
  * [必要な要求ヘッダー](#ID4EEC)
  * [省略可能な要求ヘッダー](#ID4EQE)
  * [要求本文](#ID4EZF)
  * [必要な応答ヘッダー](#ID4EEG)
  * [HTTP 状態コード](#ID4EYAAC)
  * [省略可能な応答ヘッダー](#ID4EOFAC)
  * [応答本文](#ID4EOGAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
クリップまたは縮小表示が発行済み状態に達するし、ダウンロード可能な型で指定されているは、クライアントがダウンロードできる、 **GameClipUri**オブジェクト。 ユーザーまたはパブリックのクリップの一覧を取得するときに、応答本文で、ファイルを要求するための URI が含まれます。
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| <b>Uri</b>| string| <b>Uri</b>内でフィールド、 <b>GameClipUri</b>オブジェクト。| 
  
<a id="ID4EEC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>| 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
  
<a id="ID4EQE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。| 
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。| 
  
<a id="ID4EZF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EEG"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。| 
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。| 
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。| 
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。| 
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。| 
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。| 
  
<a id="ID4EYAAC"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 301| 完全に移動| サービスが別の URI に移動します。| 
| 307| 一時的なリダイレクト| サービスが別の URI に移動します。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求がかかり過ぎて、完了します。| 
| 410| なった| 要求されたリソースは使用できなくします。| 
  
<a id="ID4EOFAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Etag| string| キャッシュの最適化に使用されます。 以下に例を示します。"686897696a7c876b7e"。| 
  
<a id="ID4EOGAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EUGAC"></a>

  
 
成功した場合、サーバーは範囲の要求ヘッダーに従って切り捨てられる可能性があります、ビデオ クリップを返します。 切り捨てられたクリップ、応答を Partial Content (206) になります。 サーバーは、ファイル全体を返します、これは OK (200) が応答します。 エラーの場合、 **GameClipsServiceErrorResponse**オブジェクトは、適切な HTTP ステータス コード (例: 416、Requested Range Not Satisfiable) と共に返される可能性があります。
   
<a id="ID4E4GAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E6GAC"></a>

 
##### <a name="parent"></a>Parent 

[/{uri}](uri-uri.md)

   