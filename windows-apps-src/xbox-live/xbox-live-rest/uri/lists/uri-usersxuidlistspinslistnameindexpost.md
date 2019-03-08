---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: df61be42-c229-7408-5e4c-dbf4ae95b52b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindexpost.html
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7711beee6551c40afe1afcb031278484a3dc5820
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627467"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a>POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
リストの項目を一覧内の別の位置に移動します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [クエリ文字列パラメーター](#ID4EWC)
  * [要求本文](#ID4EVD)
  * [HTTP 状態コード](#ID4EEE)
  * [必要な要求ヘッダー](#ID4E1BAC)
  * [応答本文](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
この呼び出しは、クライアントは、1 回の操作で、一覧内の別のインデックスに項目を簡単に移動できるように提供されています。 一度に 1 つの項目を移動する可能性があります。 移動する項目のインデックスが存在しない場合は、HTTP 400 が返されます。 カーソル位置のインデックスでは、標準的な挿入と同じ規則に従います。 0 – リストの先頭に既定では、リスト内の項目の数よりも大きい任意の数は、リストの末尾にある項目を再挿入します。 同様に"end"insertIndex を渡すことによって、リストの末尾を指示できます。 
 
この呼び出しでは、itemid である (またはプロバイダー/providerId コンボ) で移動するアイテムを識別することもできます。 ここでは、要求の本文に、itemId を渡す必要があるし、リスト内の既存の項目に一致する必要があります。 その場合はの説明で IndexOutOfRange で HTTP 400 エラーが返されます呼び出しのこの特殊なバージョンでは、移動する項目のインデックスとして「-1」を使用します。 
 
この呼び出しが必要です、"場合に一致: versionNumber"に含まれる要求の項目を指定する場合は、インデックスを使用してヘッダー。 ItemId を移動するには、どの項目を示すためを使用して場合、"If-match"ヘッダーは省略可能です。 存在する場合、"If-match"ヘッダーは常に検証されます。 "If-match"ヘッダーを次のメッセージは、リストの現在のバージョン番号です。 かどうかはないに含まれる (および必要な)、または現在に一致しないリストのバージョン番号、HTTP 412 – precondition 失敗のステータス コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます. これは相互に踏み潰すさまざまなクライアントからの更新プログラムから保護するためです。 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| XUID| string| ユーザーの XUID です。| 
| listname| string| 操作するリストの名前。| 
| インデックス| string| 移動するアイテムの現在のインデックスを指定します。 インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを呼び出しの要求本文を空にする必要があります。 ただし、インデックス値が「-1」の場合は、ItemId またはプロバイダー/ProviderID 呼び出しの要求本文内で移動する項目を指定してください。| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| insertIndex| string| 項目を挿入するリストの場所を指定します。 使用できる値は 0、正の整数、および"end"は。 "end"では、現在のリストの末尾に項目を配置します。 指定した値がリストの末尾を越える場合は、項目は、リストの末尾に挿入されます。 | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a>要求本文 
 
要求本文は itemid であるか、プロバイダー/ProviderId を移動するアイテムを指定する場合にのみ送信されます。
 
<a id="ID4E6D"></a>

  
要求のサンプル 

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
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、承認の要求に使用した STS トークンが含まれています。 必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。 | 
| X XBL コントラクト バージョン| API バージョンが要求された (正の整数) をされているを指定します。 バージョン 2 をサポートする pin。 このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。| 
| Content-Type| 要求/応答本文の内容が json または xml であるかどうかを指定します。 サポートされる値は"application/json"および"application/xml"| 
| If-Match| このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または DELETE 動詞。 "If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。 (省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。 | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a>応答本文 
 
呼び出しが成功した場合、サービスは、最新の一覧については、メタデータを返します。 
 
<a id="ID4E1DAC"></a>

 
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

   
<a id="ID4EIEAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}](uri-usersxuidlistspinslistnameindex.md)

   