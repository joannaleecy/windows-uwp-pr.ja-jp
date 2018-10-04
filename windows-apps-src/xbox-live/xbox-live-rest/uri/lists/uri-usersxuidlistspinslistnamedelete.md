---
title: DELETE (/users/xuid(xuid)/lists/PINS/{listname})
assetID: b43e3faa-7791-8bcb-3aec-7bdad8ffbebf
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamedelete.html
author: KevinAsgari
description: " DELETE (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0749229af844c7b71496351000cadece7544bfc6
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4314831"
---
# <a name="delete-usersxuidxuidlistspinslistname"></a>DELETE (/users/xuid(xuid)/lists/PINS/{listname})
一覧から項目を削除します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EIB)
  * [クエリ文字列パラメーター](#ID4ETB)
  * [Authorization](#ID4ETC)
  * [必要な要求ヘッダー](#ID4EAD)
  * [要求本文](#ID4EWE)
  * [HTTP ステータス コード](#ID4EBF)
  * [応答本文](#ID4E6BAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
削除する項目は、リスト内のインデックスで示されます、クエリ文字列パラメーター**インデックス**で識別されます。 コンマ区切りのインデックスのリストがある必要があります、1 回の呼び出しは 100 のインデックスを渡すことができます。 ただし、インデックスが (空のクエリ文字列パラメーター) を渡されていない場合、一覧の全体の内容が削除されます (バージョン番号がインクリメント引き続きし、空のリストはままです)。 項目が削除されると一覧が「キーを押してコンパクト」インデックスの順序で穴が残っていないようにします。 したがって、この呼び出しは、等ではありません。
 
この呼び出しに必要な**場合-マッチ: versionNumber** **versionNumber**がファイルの現在のバージョン番号は、要求に含まれるヘッダー。 またはし、現在の一覧のバージョン番号、http/412 (precondition failed) と一致しませんが、含まれていない場合は、ステータス コードが返されます、応答の本文には現在のバージョン番号を含む一覧の最新のメタデータが含まれています。 これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)。| 
| listtype| string| (その使用方法と動作) の一覧の種類です。 常に「ピン」これらのメソッドに関連します。| 
| リスト| string| リストの名前 (際に指定された listtype の一覧がどの)。 常に"XBLPins"の項目のピン留めします。| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| インデックス| string| 省略可能。 項目を削除する場所を指定します。 サポートされる値: 0、正の整数と「終了」です。 既定値: 0 です。| 
 
例:**インデックス = 1、8**インデックス 1 と 8 に項目を削除します。 インデックスは、一意である必要があります。 インデックスが指定されていない場合は、一覧全体がクリアされます。
  
<a id="ID4ETC"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しは、**承認**ヘッダーで XSTS SAML トークンを想定しています。 Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。 この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。 リスト自体では、同様の Xuid を識別し、リストの URI に含まれます。 これを使用して、お、今後リストに共有サポートへのアクセスがいる機能ではありませんこの時点でします。 現時点では、ユーザーがアクセスするすべてのリストが自分、共有へのアクセスはありません。 したがって、URI の Xuid は SAML クレーム トークン内の Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。 


  
<a id="ID4EAD"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 ピンのサポート バージョン 2 です。 このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。| 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 "If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。 | 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 要求が正常に完了しました。 応答本文では、(GET) 用、要求されたリソースを含める必要があります。 POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。| 
| 201| Created| 新しい一覧が作成されました。 これは初期の挿入のリストに返されます。 応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。| 
| 304| Not Modified| 取得で返されます。 クライアントに一覧の最新バージョンがあることを示します。 サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。 これらが等しい場合、304 取得データなしで返されます。| 
| 400| Bad Request| 要求が正しくありません。 無効な値または URI またはクエリ文字列パラメーターの型として使用できます。 不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。 <b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 呼び出し元では、リソースへのアクセスはありません。 これは、このような一覧が作成されていないことを示します。| 
| 412| Precondition Failed| 一覧のバージョンが変更された変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。 一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。| 
| 500| 内部サーバー エラー| サービスはサーバー側のエラーのための要求を拒否しています。| 
| 501| 実装されていません。| 呼び出し元がサーバーに実装されていない URI を要求します。 (現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)| 
| 503| Service Unavailable| サーバーは、通常は負荷が高くなり、要求拒否しています。 遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。| 
  
<a id="ID4E6BAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EFCAC"></a>

 
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

   
<a id="ID4EPCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

   