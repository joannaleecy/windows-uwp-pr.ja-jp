---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: f7235c68-3214-db10-52ad-c3665b31b8cd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemspost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dbccbad78dd49db0bd4d4110424a7c32216eff3d
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4314037"
---
# <a name="post-usersxuidxuidlistspinslistnameremoveitems"></a>POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
ItemId によってリストから項目を削除します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EFB)
  * [クエリ文字列パラメーター](#ID4EOC)
  * [要求本文](#ID4EZC)
  * [HTTP ステータス コード](#ID4EED)
  * [必要な要求ヘッダー](#ID4E1AAC)
  * [応答本文](#ID4EQCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
インデックスではなく項目 id を指定することによって、一覧から項目を削除します。 1 つの呼び出しで削除するのには 100 項目が許可されている**項目が渡されていないかどうかは、一覧全体が削除されます (一覧のままになりますが、空のバージョン番号は引き続き増分).** 項目が削除されると一覧が「キーを押してコンパクト」インデックスの順序で穴が残っていないようにします。 
 
"場合、マッチ: versionNumber"ヘッダーはこの呼び出しの省略可能です。 それが含まれている場合は検証されます。 次のメッセージでは、ファイルの現在のバージョン番号です。 含まれているし、現在と一致しない場合は一覧のバージョン番号、http/412 – の前提条件が失敗の状態コードが返され、応答の本文には現在のバージョン番号が含まれている一覧の最新のメタデータが含まれています。 これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。 
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| リスト| string| 操作をするリストの名前。| 
  
<a id="ID4EOC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
クエリ パラメーターはサポートされていません。
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a>要求本文 
 

```cpp
{
   "Items":
   [{"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
      "ProviderId":  null,
      "Provider":  null
   }]
}

    
```

  
<a id="ID4EED"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 200| OK | 要求が正常に完了しました。 応答本文では、(GET) 用、要求されたリソースを含める必要があります。 POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。| 
| 201| Created | 新しい一覧が作成されました。 これは初期の挿入のリストに返されます。 応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。| 
| 304| Not Modified| 取得で返されます。 クライアントに一覧の最新バージョンがあることを示します。 サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。 これらが等しい場合、304 取得データなしで返されます。 | 
| 400| Bad Request | 要求が正しくありません。 無効な値または URI またはクエリ文字列パラメーターの型として使用できます。 不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。 <b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。 | 
| 401| 権限がありません | 要求には、ユーザー認証が必要です。| 
| 403| Forbidden | ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。 | 呼び出し元では、リソースへのアクセスはありません。 これは、このような一覧が作成されていないことを示します。| 
| 412| Precondition Failed | 一覧のバージョンが変更された変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。 一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。 | 
| 500| 内部サーバー エラー | サービスはサーバー側のエラーのための要求を拒否しています。| 
| 501| 実装されていません。 | 呼び出し元がサーバーに実装されていない URI を要求します。 (現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)| 
| 503| Service Unavailable | サーバーは、通常は負荷が高くなり、要求拒否しています。 遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。 | 
  
<a id="ID4E1AAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 ピンのサポート バージョン 2 です。 このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。 | 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 "If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。 | 
  
<a id="ID4EQCAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。 
 
<a id="ID4E1CAC"></a>

 
### <a name="sample-response"></a>応答の例 
 

```cpp
{
        "ListVersion":  1,
        "ListCount":  1,
        "MaxListSize": 200,
        "AllowDuplicates": "true",
        "AccessSetting":  "OwnerOnly"
        }

      
```

   
<a id="ID4EGDAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EIDAC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   