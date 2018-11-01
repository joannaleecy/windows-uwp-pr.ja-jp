---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
assetID: 86ee6d1a-fb1f-b918-f605-a9b494c0e787
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamecontainsitemspost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f3deb042d03fbc8e15d12359d00a594cc36c1a87
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5866888"
---
# <a name="post-usersxuidxuidlistspinslistnamecontainsitems"></a>POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
完全な一覧を取得することがなく一連項目 (itemId により指定) にはが一覧に含まれて かどうかを決定します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4EJC)
  * [要求本文](#ID4EUC)
  * [HTTP ステータス コード](#ID4E6C)
  * [必要な要求ヘッダー](#ID4EVAAC)
  * [応答本文](#ID4ELCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
このエンドポイントでは、呼び出し元に 1 つまたは複数の項目が実際にリストを取得して、それ自体を検索することがなく、指定されたリストに存在かどうかを決定できます。 項目のセットが itemId (または、プロバイダー/providerId コンボ) によって識別され、戻り値のデータは、true または false ndicating のブール値を使用して一覧には、各項目が含まれているかどうかに渡されるデータ。 
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| リスト| string| 操作するリストの名前。| 
  
<a id="ID4EJC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
クエリ パラメーターはサポートされていません。
  
<a id="ID4EUC"></a>

 
## <a name="request-body"></a>要求本文 
 

```cpp
{
  "Items":
  [{"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId":  null,
    "Provider": null
  }]
}


    
```

  
<a id="ID4E6C"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求は正常に完了しました。 応答本文では、(GET) 用、要求されたリソースを含める必要があります。 POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。| 
| 201| Created | 新しい一覧が作成されました。 これは初期の挿入のリストに返されます。 応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。| 
| 304| Not Modified| 取得で返されます。 クライアントに一覧の最新バージョンがあることを示します。 サービスは、一覧のバージョンに<b>If-match</b>ヘッダーの値を比較します。 これらが等しい場合、304 取得データなしで返されます。 | 
| 400| Bad Request | 要求が正しくありません。 無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。 不足している必要なパラメーターの結果こともできますか、データの値、または要求に存在しないか、無効なバージョンの API が示されます。 <b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。 | 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 呼び出し元では、リソースへのアクセスはありません。 これは、このような一覧が作成されていないことを示します。| 
| 412| Precondition Failed | 一覧のバージョンが変更されていて、変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。 リストの現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。 | 
| 500| 内部サーバー エラー | サービスはサーバー側のエラーのための要求を拒否しています。| 
| 501| 実装されていません。 | 呼び出し元では、サーバーで実装されていない URI を要求します。 (現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)| 
| 503| Service Unavailable | サーバーは、通常は負荷が高くなり、要求拒否しています。 遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。 | 
  
<a id="ID4EVAAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 バージョン 2 のサポートのピン留めします。 このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。 | 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 現在のバージョン一覧の"If-match"ヘッダー内のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在、渡されたバージョン一覧の現在のバージョンし、一覧データがないと一致する HTTP 304 – Not Modified コードが返されます。 | 
  
<a id="ID4ELCAC"></a>

 
## <a name="response-body"></a>応答本文 
 
場合は、呼び出しが成功した場合、各項目のか、項目のリストにあるかどうかを指定するブール値と、項目の一覧が返されます。 
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a>応答の例 
 

```cpp
{
  "ContainedItems":
  [{"Contained": "true",
    "Item":
   {"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId": null,
    "Provider": null
   }
  }]
}


      
```

   
<a id="ID4EBDAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EDDAC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   