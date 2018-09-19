---
title: GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: 203345eb-8092-7d38-6eab-cb7d53bda249
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.html
author: KevinAsgari
description: " GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 25666c76f5eaafe4f53aaf3ff76eba68d4be275d
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4059481"
---
# <a name="get-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a>GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
ファイルをダウンロードします。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [Authorization](#ID4ECB)
  * [オプションのクエリ文字列パラメーター](#ID4EPB)
  * [必要な要求ヘッダー](#ID4EQC)
  * [省略可能な要求ヘッダー](#ID4EZD)
  * [要求本文](#ID4EDF)
  * [HTTP ステータス コード](#ID4EQF)
  * [応答ヘッダー](#ID4EDDAC)
  * [応答本文](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイル名。 パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。| 
| type| 文字列| データの形式です。 可能な値は、バイナリまたは json です。| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは 403 Forbidden 応答を返します。 ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a>オプションのクエリ文字列パラメーター 
 
Blob の種類によって異なります。 バイナリ blob には、クエリ パラメーターをサポートしていません。
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 選択| string| 型は json ときにのみ使用します。 応答する必要がありますのみを含む特定プロパティ/値、JSON のこのパラメーターによって決定されるを指定します。 「ドット」(.) を使用して、サブプロパティ、角かっこを指定 ('['、']') 配列のインデックスを指定します。 たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
| Authorization| XBL3.0 x = [ハッシュ]。[トークン]| STS 認証トークンです。 STSTokenString は認証要求によって返されるトークンで置き換えられます。 STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-Match| 操作を完了するにより既存項目と一致する ETag を指定します。| 
| If-None-Match| 操作を完了するにより既存項目に一致する必要があります ETag を指定します。| 
| 範囲| ダウンロードするバイトの範囲を指定します。 標準の範囲の HTTP ヘッダーの形式に従います。| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求が成功しました。| 
| 201| Created | エンティティが作成されました。| 
| 400| Bad Request | サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。 | リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト | 要求にかかった時間が長すぎます。| 
| 500| 内部サーバー エラー | サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable | 要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a>応答ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ETag| ETag は、web サーバーの URL で見つかったリソースの特定のバージョンによって割り当てられる不透明な識別子です。 その URL でリソースのコンテンツが変更された場合は、新しいとは異なる ETag が割り当てられます。| 
| コンテンツ範囲| これは、部分的なダウンロードでしたが、このヘッダーは、ダウンロードされたバイト数の範囲を指定します。| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a>応答本文
呼び出しが成功した場合は、サービスは、ファイルの内容を返します。  
<a id="ID4EPEAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EREAC"></a>

 
##### <a name="parent"></a>Parent  

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

  
<a id="ID4E4EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a>参照[TitleBlob (JSON)](../../json/json-titleblob.md)

   