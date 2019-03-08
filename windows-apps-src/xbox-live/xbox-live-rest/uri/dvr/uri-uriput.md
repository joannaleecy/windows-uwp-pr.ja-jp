---
title: PUT (/{uri})
assetID: 24a24c93-f43b-017e-91e0-29e190fec8a8
permalink: en-us/docs/xboxlive/rest/uri-uriput.html
description: " PUT (/{uri})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 862b956e29222bb9d28f98510f13d42fd1a51b6f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633117"
---
# <a name="put-uri"></a>PUT (/{uri})
ゲームのクリップのデータをアップロードします。
これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。

  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EQB)
  * [クエリ文字列パラメーター](#ID4ERC)
  * [必要な要求ヘッダー](#ID4EBE)
  * [省略可能な要求ヘッダー](#ID4ENG)
  * [要求本文](#ID4EWH)
  * [HTTP 状態コード](#ID4ECAAC)
  * [必要な応答ヘッダー](#ID4EYEAC)
  * [省略可能な応答ヘッダー](#ID4ELHAC)
  * [応答本文](#ID4ELIAC)

<a id="ID4EX"></a>


## <a name="remarks"></a>注釈

後に、 **InitialUploadResponse**返されるか、アップロードを行います、 **uploadUri**そのオブジェクトで返されます。 クライアントは、ファイルを分割する必要があります**expectedBlocks**シーケンシャル ブロックは、各 2 MB を超える。 並行でアップロードできます。

ブロック内のファイルをアップロードする場合、サーバーは各要求の承諾済み (202) の HTTP 状態コードが返されますを受け取るまで、すべての期待されるブロックの場合は、Created (201) を返す 1 つのファイルとしてすべてのブロックをコミットします。 このような場合は、応答に、オブジェクトが含まれていないと、サーバーは、追加の処理をスケジュール可能性があります。 エラーの場合、 **ServiceErrorResponse**オブジェクトは、適切な HTTP ステータス コードと共に返される可能性があります。

回復可能なエラー コード、クライアントは、標準的なバックオフの再試行メカニズムを使用して再試行する必要があります。

> [!NOTE] 
> 場合でも、アップロードが正常に完了すると、さらに処理する可能性があります上の理由からクリップがアップロードまたはメタデータに関連しない却下を補うためプロセス発生します。


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| <b>Uri</b>| string| <b>UploadUri</b>内でフィールド、 <b>InitialUploadResponse</b>オブジェクト。|

<a id="ID4ERC"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- |
| <b>blockNum</b>| 32 ビット符号なし整数| 場合に、必ず<b>expectedBlocks</b>設定されます。 ファイル内のブロックの順序を決定する、インデックス 0 のブロック数。 たとえば場合、 <b>expectedBlocks</b>は 7、 <b>blockNum</b>は、0 から 6 までです。 |
| <b>uploadId</b>| string| 必須。 不透明な ID で<b>GameClipsServiceUploadResponse</b>オブジェクト。|

<a id="ID4EBE"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:<b>Xauth=&lt;authtoken></b>|
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。|
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。|
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。|
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。|

<a id="ID4ENG"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Accept-Encoding| string| 許容される圧縮エンコーディング。 値の例: gzip、deflate の id。|
| ETag| string| キャッシュの最適化に使用されます。 値の例:"686897696a7c876b7e"。|

<a id="ID4EWH"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ECAAC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
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

<a id="ID4EYEAC"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。|
| Content-Type| string| 応答本文の MIME の種類。 例: <b>、application/json</b>します。|
| キャッシュ制御| string| キャッシュの動作を指定する正常な要求です。|
| OK| string| コンテンツの種類の許容される値。 例: <b>、application/json</b>します。|
| 再試行後| string| 後でもう一度お試しください利用不可のサーバーの場合にクライアントに指示します。|
| 異なる| string| ダウン ストリーム プロキシ応答をキャッシュする方法を指示します。|

<a id="ID4ELHAC"></a>


## <a name="optional-response-headers"></a>省略可能な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Etag| string| キャッシュの最適化に使用されます。 以下に例を示します。"686897696a7c876b7e"。|

<a id="ID4ELIAC"></a>


## <a name="response-body"></a>応答本文

応答の本文では、オブジェクトは送信されません。

<a id="ID4EWIAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EYIAC"></a>


##### <a name="parent"></a>Parent

[/{uri}](uri-uri.md)
