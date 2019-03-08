---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
assetID: 86ee6d1a-fb1f-b918-f605-a9b494c0e787
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamecontainsitemspost.html
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c18bf70773de60d4c831d4be891255f98750efa8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636877"
---
# <a name="post-usersxuidxuidlistspinslistnamecontainsitems"></a>POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
全体の一覧を取得せず、(itemId で指定された) 項目のセットが一覧に含まれて かどうかを判断します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EAB)
  * [クエリ文字列パラメーター](#ID4EJC)
  * [要求本文](#ID4EUC)
  * [HTTP 状態コード](#ID4E6C)
  * [必要な要求ヘッダー](#ID4EVAAC)
  * [応答本文](#ID4ELCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
このエンドポイントは、1 つまたは複数の項目が検索自体を実際に、一覧を取得せず、指定されたリスト内に存在かどうかを決定する、呼び出し元を使用できます。 項目のセットが itemid である (またはプロバイダー/providerId コンボ) によって識別され、戻り値のデータが一覧には、各項目が含まれて かどうか ndicating の true または false のブール値で渡されるデータ。 
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| listname| string| 操作するリストの名前。| 
  
<a id="ID4EJC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
クエリ パラメーターがサポートされていません。
  
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

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求は正常に完了しました。 応答本文は、(GET) の要求されたリソースを含める必要があります。 POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。| 
| 201| 作成日 | 新しいリストが作成されました。 これが初期の挿入時のリストに返されます。 応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。| 
| 304| 変更されていません| 返されるを取得します。 クライアントが最新バージョンの一覧を示します。 サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。 等しい場合、304 取得データなしで返されます。 | 
| 400| 要求が正しくありません | 要求が正しくありません。 無効な値または URI またはクエリ文字列パラメーターの型です。 不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。 参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。 | 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可 | 呼び出し元には、リソースへのアクセスはありません。 これは、このようなリストが作成されていないことを示します。| 
| 412| Precondition Failed | リストのバージョンが変更された変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。 リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。 | 
| 500| 内部サーバー エラー | サービスは、サーバー側エラーのために要求拒否しています。| 
| 501| 実装されていません | 呼び出し元は要求がサーバー上に実装されていない URI です。 (現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)| 
| 503| サービス利用不可 | サーバーは、通常の負荷が高すぎるため、要求拒否しています。 遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。 | 
  
<a id="ID4EVAAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、承認の要求に使用した STS トークンが含まれています。 必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。 | 
| X XBL コントラクト バージョン| API バージョンが要求された (正の整数) をされているを指定します。 バージョン 2 をサポートする pin。 このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。 | 
| Content-Type| 要求/応答本文の内容が json または xml であるかどうかを指定します。 サポートされる値は"application/json"および"application/xml"| 
| If-Match| このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または DELETE 動詞。 "If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。 (省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。 | 
  
<a id="ID4ELCAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合か、項目が一覧にあるかどうかを指定する各項目のブール値と共に項目の一覧が返されます。 
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a>応答のサンプル 
 

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

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   