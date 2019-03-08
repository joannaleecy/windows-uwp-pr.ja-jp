---
title: PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: ed037b64-6525-99a2-b7f6-050fdf345de8
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.html
description: " PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f04deef3a7c9eba494fdce8e7df16d9815cfc1ba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594127"
---
# <a name="put-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a>PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
ファイルをアップロードします。 データおよびメタデータが送信される一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードや 1 つのメッセージで完全なアップロードには、データをアップロードできます。 1 つのメッセージとして 4 メガバイト未満のファイルのみを送信できます。 データ型の json は、複数のブロックのアップロードはサポートされていません。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [承認](#ID4EEB)
  * [省略可能なクエリ文字列パラメーター](#ID4ERB)
  * [必要な要求ヘッダー](#ID4EQE)
  * [省略可能な要求ヘッダー](#ID4EZF)
  * [要求本文](#ID4E3G)
  * [HTTP 状態コード](#ID4EHH)
  * [応答本文](#ID4E1EAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。| 
| scid| guid| 検索するサービス構成の ID。| 
| pathAndFileName| string| アクセスする項目のパスとファイル名。 有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。| 
| type| string| データの形式です。 有効値とは、バイナリまたは json です。| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。 ヘッダーが無効であるか不足している場合、サービスは、401 を返します。 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a>省略可能なクエリ文字列パラメーター 
 
1 つのメッセージのアップロードは、クエリ文字列パラメーターがあります。
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| clientFileTime| DateTime| どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。| 
| displayName| string| ユーザーに表示するファイルの名前。| 
 
複数のブロックのアップロードは、クエリ文字列パラメーターがあります。
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| clientFileTime| DateTime| どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。| 
| displayName| string| ユーザーに表示するファイルの名前。| 
| continuationToken| string| 前回のアップロード要求の応答から継続トークンです。 最初のブロックの場合は、これを指定しない必要があります。 | 
| finalBlock| bool| ファイルの最後のブロックに対して true に設定します。 その他のすべてのブロックに対して false に設定します。| 
  
<a id="ID4EQE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| STS の認証トークンです。 STSTokenString は、認証要求によって返されるトークンに置き換えられます。 STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EZF"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| If-Match| 操作を完了する既存の項目に一致する必要がある ETag を指定します。| 
| If-None-Match| 操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。| 
  
<a id="ID4E3G"></a>

 
## <a name="request-body"></a>要求本文 
 
要求本文には、アップロードするファイルの内容が含まれています。 1 つのメッセージのアップロード、本文は、ファイルの完全な内容です。 複数のブロックのアップロードは、本文は、クエリ文字列パラメーターで指定されたファイルの部分です。 
  
<a id="ID4EHH"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4E1EAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが複数のブロックの要求で、成功した場合、サービスは次のブロックと共に渡す continution トークンを返します。
 
<a id="ID4EGFAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4ESFAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EUFAC"></a>

 
##### <a name="parent"></a>Parent  

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   