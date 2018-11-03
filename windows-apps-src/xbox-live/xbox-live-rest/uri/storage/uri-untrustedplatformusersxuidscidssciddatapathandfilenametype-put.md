---
title: PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: b40a1a88-02c2-624f-de00-49664825bde3
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-put.html
author: KevinAsgari
description: " PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 49830ccfadf0ecaa7970af9dd5089c87c63b5411
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5977443"
---
# <a name="put-untrustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a>PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
ファイルをアップロードします。 データやメタデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。 1 つのメッセージとしては 4 つのメガバイトよりも小さいファイルのみを送信できます。 Json の種類のデータの複数のブロックのアップロードはサポートされていません。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [Authorization](#ID4EEB)
  * [オプションのクエリ文字列パラメーター](#ID4ERB)
  * [必要な要求ヘッダー](#ID4EOE)
  * [オプションの要求ヘッダー](#ID4EXF)
  * [要求本文](#ID4E1G)
  * [HTTP ステータス コード](#ID4EFH)
  * [応答本文](#ID4EYEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| pathAndFileName| string| アクセスできる項目のパスとファイルの名前です。 パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。| 
| type| 文字列| データの形式です。 可能な値は、バイナリまたは json です。| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。 ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a>オプションのクエリ文字列パラメーター 
1 つのメッセージのアップロードを行う、クエリ文字列パラメーターがあります。 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| clientFileTime| DateTime| どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。| 
| displayName| string| ユーザーに表示する必要があるファイルの名前。| 
 
複数のブロックのアップロードを行う、クエリ文字列パラメーターがあります。
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| clientFileTime| DateTime| どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。| 
| displayName| string| ユーザーに表示する必要があるファイルの名前。| 
| continuationToken| string| 前回のアップロード要求の応答からの継続トークン。 最初のブロックの場合は、これを指定しない必要があります。 | 
| finalBlock| bool| ファイルの最後のブロックを true に設定します。 その他のすべてのブロックでは false に設定します。| 
  
<a id="ID4EOE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
| Authorization| XBL3.0 x = [ハッシュ]。[トークン]| STS 認証トークンです。 STSTokenString は認証要求によって返されるトークンで置き換えられます。 STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EXF"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-Match| 操作を完了するにより既存項目に一致する必要がある ETag を指定します。| 
| If-None-Match| 操作を完了するにより既存項目に一致する必要があります ETag を指定します。| 
  
<a id="ID4E1G"></a>

 
## <a name="request-body"></a>要求本文 
 
要求本文には、アップロードされているファイルの内容が含まれています。 1 つのメッセージのアップロード、本文は、ファイルの完全な内容です。 複数のブロックのアップロードの本文は、クエリ文字列パラメーターで指定されたファイルの部分です。 
  
<a id="ID4EFH"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求が成功しました。| 
| 201| Created | エンティティが作成されました。| 
| 400| Bad Request | サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。 | リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト | 要求にかかった時間が長すぎます。| 
| 500| 内部サーバー エラー | サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable | 要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。| 
  
<a id="ID4EYEAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しでは、複数のブロック要求が成功した場合は、サービスは次のブロックを渡す continution トークンを返します。
 
<a id="ID4EEFAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4EQFAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESFAC"></a>

 
##### <a name="parent"></a>Parent  

[/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

   