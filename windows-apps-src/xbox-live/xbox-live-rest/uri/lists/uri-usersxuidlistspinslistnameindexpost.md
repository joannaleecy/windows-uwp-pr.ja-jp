---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: df61be42-c229-7408-5e4c-dbf4ae95b52b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindexpost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1aecb7f73a49e7628b076fe943774ccf89aa71bc
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4173238"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a>POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
リスト項目をリスト内の異なる位置に移動します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EWC)
  * [要求本文](#ID4EVD)
  * [HTTP ステータス コード](#ID4EEE)
  * [必要な要求ヘッダー](#ID4E1BAC)
  * [応答本文](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
この呼び出しは、クライアントが単一の操作でリスト内のさまざまなインデックスに項目を簡単に移動できる提供されています。 一度に 1 つの項目を移動する場合があります。 移動する項目のインデックスが存在しない場合は、HTTP 400 が返されます。 挿入ポイントのインデックスは、標準的な挿入と同じ規則に従います。 既定値は 0 ~ リストの先頭と、リスト内の項目数よりも大きい任意の数は、一覧の最後の項目を再挿入します。 同様に insertIndex の「終了」を渡すことによって、リストの末尾を示すことができます。 
 
この呼び出しでは、itemId (またはプロバイダー/providerId コンボ) によって移動する項目を識別することもできます。 この場合、要求の本文で、itemId を渡す必要があります、リスト内の既存の項目に一致する必要があります。 その場合は、説明; IndexOutOfRange でエラーが返される、HTTP 400この特別なバージョンの呼び出しを移動する項目のインデックスとして「-1」を使用します。 
 
この呼び出しが必要とする"場合-マッチ: versionNumber"ヘッダーに含まれる要求で項目を指定する場合は、インデックスをします。 使って場合 itemId を移動するには、どの項目を示すために、"If-match"ヘッダーは省略可能です。 存在する場合、"If-match"ヘッダーが常に検証されます。 "If-match"ヘッダーで、versionNumber はリストの現在のバージョン番号です。 かどうかはない含まれている (および必須)、または、現在は一致しない一覧のバージョン番号、http/412 – の前提条件が失敗の状態コードが返され、応答の本文には現在のバージョン番号が含まれている一覧の最新のメタデータが含まれています. これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| リスト| string| 操作をするリストの名前。| 
| インデックス| string| 移動する項目の現在のインデックスを指定します。 インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。 ただし、インデックス値が「-1」の場合、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| insertIndex| string| 項目を挿入する一覧の場所を指定します。 許容値は、0、正の整数「終了」です。 「終了」は、現在のリストの最後に、項目を配置します。 指定された値がリストの最後を超える場合は、リストの最後に、項目が挿入されます。 | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a>要求本文 
 
要求本文は itemId またはプロバイダー/ProviderId を移動する項目を指定するときにのみ送信されます。
 
<a id="ID4E6D"></a>

  
要求の例 

```cpp
{
  "Item":
  {
    "ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId":  null,
    "Provider": null
  }
}
    
```

  
<a id="ID4EEE"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 ピンのサポート バージョン 2 です。 このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。| 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 "If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。 | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。 
 
<a id="ID4E1DAC"></a>

 
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

   
<a id="ID4EIEAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}](uri-usersxuidlistspinslistnameindex.md)

   