---
title: GET (/global/scids/{scid})
assetID: 7c8cd028-e94a-45e1-fe34-c9deae2d6042
permalink: en-us/docs/xboxlive/rest/uri-globalscidsscid-get.html
author: KevinAsgari
description: " GET (/global/scids/{scid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4087c9857e657bd2621ab1fdb85d06abbfd8f5ef
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4462453"
---
# <a name="get-globalscidsscid"></a>GET (/global/scids/{scid})
このストレージの種類のクォータ情報を取得します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EX)
  * [Authorization](#ID4ECB)
  * [必要な要求ヘッダー](#ID4ENB)
  * [要求本文](#ID4EWC)
  * [HTTP ステータス コード](#ID4EBD)
  * [応答本文](#ID4EUAAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| guid| ルックアップ サービス構成の ID です。| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a>Authorization
 
要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは 403 Forbidden 応答を返します。 ヘッダーが見つからないか無効な場合は、サービスは 401 承認されていない応答を返します。 
  
<a id="ID4ENB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 設定値| 説明| 
| --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 1| API コントラクト バージョンです。| 
| Authorization| XBL3.0 x = [ハッシュ]。[トークン]| STS 認証トークンです。 STSTokenString は認証要求によって返されるトークンで置き換えられます。 STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。| 
  
<a id="ID4EWC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EBD"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求が成功しました。| 
| 201| Created | エンティティが作成されました。| 
| 400| Bad Request | サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。 | リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト | 要求にかかった時間が長すぎます。| 
| 500| 内部サーバー エラー | サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable | 要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。| 
  
<a id="ID4EUAAC"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合は、サービスは[quotaInfo](../../json/json-quota.md)オブジェクトを返します。 
 
<a id="ID4ECBAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
  "quotaInfo":
  {
    "usedBytes":619,
    "quotaBytes":16777216
  }
}
         
```

   
<a id="ID4EOBAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a>Parent 

[/global/scids/{scid}](uri-globalscidsscid.md)

  
<a id="ID4E1BAC"></a>

 
##### <a name="reference"></a>リファレンス 

[quotaInfo (JSON)](../../json/json-quota.md)

   