---
title: DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: ad049340-f752-e05e-8b34-62adb8e4771f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemsdelete.html
description: " DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d26d8eaf54dcc14de3e31d7c2b54cd4454f2029f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594097"
---
# <a name="delete-usersxuidxuidlistspinslistnameremoveitems"></a>DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
インデックスを使用して、一覧から項目を削除します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ECB)
  * [クエリ文字列パラメーター](#ID4ELC)
  * [要求本文](#ID4END)
  * [HTTP 状態コード](#ID4EYD)
  * [必要な要求ヘッダー](#ID4EOBAC)
  * [応答本文](#ID4EEDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
一覧から項目を削除します。 削除する項目はリスト内のインデックスで示されますされ、「インデックス」クエリ文字列パラメーターで識別されます。 インデックスの一覧がコンマ区切りにする必要があり、100 件のみインデックスを 1 回の呼び出しで渡すことができます。 ただし、インデックスに (空のクエリ文字列パラメーター) が渡されない場合、リスト全体の内容は削除されます (リストに残りますが、空の場合、バージョン番号はインクリメントする続行するが)。 項目が削除されると、リストは「圧縮」インデックスの順序に穴が残っていないようにします。 
 
この呼び出しが必要です、"場合に一致: versionNumber"versionNumber がファイルの現在のバージョン番号は、要求に含まれるヘッダー。 現在と一致しませんが、含まれていない場合リストのバージョン番号、HTTP 412 – precondition 失敗のステータス コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。 これは相互に踏み潰すさまざまなクライアントからの更新プログラムから保護するためです。 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| listname| string| 操作するリストの名前。| 
  
<a id="ID4ELC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| インデックス| string| 0 または正の整数。 連続する数値がありませんでした。 クエリ パラメーターのインデックスなど、1 = 8 1 から 8 のインデックスで項目が削除されます。 <b>インデックスが指定されていない場合は、リスト全体が削除されます。</b>| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a>要求本文 
 
要求本文は、この呼び出しを空にする必要があります。
  
<a id="ID4EYD"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4EOBAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、承認の要求に使用した STS トークンが含まれています。 必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。 | 
| X XBL コントラクト バージョン| API バージョンが要求された (正の整数) をされているを指定します。 バージョン 2 をサポートする pin。 このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。 | 
| Content-Type| 要求/応答本文の内容が json または xml であるかどうかを指定します。 サポートされる値は"application/json"および"application/xml"| 
| If-Match| このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または DELETE 動詞。 "If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。 (省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。 | 
  
<a id="ID4EEDAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合、サービスは、最新の一覧については、メタデータを返します。 
 
<a id="ID4EODAC"></a>

 
### <a name="sample-response"></a>応答のサンプル 
 

```cpp
{
        "ListVersion":  1,
        "ListCount":  1,
        "MaxListSize": 200,
        "AllowDuplicates": "true",
        "AccessSetting":  "OwnerOnly"
        }

      
```

   
<a id="ID4E1DAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E3DAC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   