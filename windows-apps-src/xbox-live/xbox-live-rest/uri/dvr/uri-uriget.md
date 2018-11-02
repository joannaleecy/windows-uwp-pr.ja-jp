---
title: GET (/{uri})
assetID: a67a3288-88f9-c504-5fa8-8fd06055d079
permalink: en-us/docs/xboxlive/rest/uri-uriget.html
author: KevinAsgari
description: " GET (/{uri})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd195ccc7cdb8e3d34c6236c44144050d2029ef2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5927852"
---
# <a name="get-uri"></a>GET (/{uri})
ゲーム クリップをダウンロードします。 これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EDB)
  * [必要な要求ヘッダー](#ID4EEC)
  * [オプションの要求ヘッダー](#ID4EQE)
  * [要求本文](#ID4EZF)
  * [必要な応答ヘッダー](#ID4EEG)
  * [HTTP ステータス コード](#ID4EYAAC)
  * [省略可能な応答ヘッダー](#ID4EOFAC)
  * [応答本文](#ID4EOGAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
クライアントは、クリップや公開済みの状態に達したと**GameClipUri**オブジェクトで指定されている、ダウンロード可能な型のサムネイルをダウンロードできます。 ユーザーやパブリック クリップの一覧を取得するときに、応答本文で、ファイルを要求の URI が含まれています。
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| <b>uri</b>| string| <b>GameClipUri</b>オブジェクト内で<b>uri</b>フィールド。| 
  
<a id="ID4EEC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例: <b>Xauth =&lt;authtoken ></b>| 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。| 
  
<a id="ID4EQE"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Accept-Encoding| string| 受け入れ可能な圧縮エンコードします。 値の例: gzip、圧縮の id。| 
| ETag| string| キャッシュの最適化のために使用します。 値の例:"686897696a7c876b7e"します。| 
  
<a id="ID4EZF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EEG"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1 の場合、vnext します。| 
| Content-Type| string| 応答本文の MIME タイプ。 例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。| 
| Accept| string| コンテンツの種類の利用可能な値です。 例:<b>アプリケーション/json</b>します。| 
| Retry-after| string| クライアントが利用できないサーバーの場合、後で再試行するように指示します。| 
| 異なる| string| 下位のプロキシの応答をキャッシュする方法を指示します。| 
  
<a id="ID4EYAAC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 301| 完全に移動| サービスは、さまざまな URI に移動しました。| 
| 307| 一時的なリダイレクト| サービスは、さまざまな URI に移動しました。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求にかかった時間が長すぎます。| 
| 410| なった| 要求されたリソースが利用可能ではなくなりました。| 
  
<a id="ID4EOFAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Etag| string| キャッシュの最適化のために使用します。 例:"686897696a7c876b7e"します。| 
  
<a id="ID4EOGAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EUGAC"></a>

  
 
成功した場合、サーバーはおそらく範囲要求ヘッダーに従って切り詰められている、ビデオ クリップを返します。 切り捨てられたクリップでは、応答は部分的なコンテンツ (206) になります。 サーバーがファイル全体を返す場合、[ok] (200) を応答します。 エラーが発生した**GameClipsServiceErrorResponse**オブジェクトを適切な HTTP ステータス コード (例: 416、要求された範囲が満たされていません) と共に返される可能性があります。
   
<a id="ID4E4GAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E6GAC"></a>

 
##### <a name="parent"></a>Parent 

[/{uri}](uri-uri.md)

   