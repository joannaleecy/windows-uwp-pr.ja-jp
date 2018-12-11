---
title: POST (/users/xuid(xuid)/lists/PINS/{listname})
assetID: 813c0bd2-aca9-a1f6-9e81-a84a4c897b1e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamepost.html
description: " POST (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e3c95620cb0b035334e0a54f950c936c381e27f9
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947710"
---
# <a name="post-usersxuidxuidlistspinslistname"></a>POST (/users/xuid(xuid)/lists/PINS/{listname})
クエリ文字列パラメーター **insertIndex**に基づいてインデックスの一覧に項目を挿入します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EY)
  * [URI パラメーター](#ID4ETB)
  * [クエリ文字列パラメーター](#ID4E5B)
  * [Authorization](#ID4EZC)
  * [HTTP ステータス コード](#ID4EGD)
  * [必要な要求ヘッダー](#ID4EEAAC)
  * [要求の例](#ID4E1BAC)
  * [応答本文](#ID4EPCAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a>注釈
 
この呼び出しは、クエリ文字列パラメーター **insertIndex** (既定値は 0 またはリストの先頭) に基づくインデックス リストに項目を挿入します。 要求本文のすべての項目は、その時点で一覧に挿入されます。 **InsertIndex**が既存のリスト内の項目の数よりも大きい場合は、最後に、新しい項目が挿入されます。
 
挿入する項目の必須フィールド機能仕様では、; に示されている必要があります。それ以外の場合、HTTP 400 が返されます。 同様に、挿入の結果は (リストの種類ごとに定義された) リストの最大サイズを超える場合、HTTP 400 が返されるし、何が挿入されます。
 
場合は、項目が*ない*または、リストの最後の先頭に挿入する、**場合-マッチ: versionNumber**ヘッダーは、要求に含める必要があります。 ヘッダーは、先頭または末尾の場合は、カーソルはオプションです。 存在する場合、ヘッダーが挿入場所に関係なく検証されます。 ヘッダー **VersionNumber**はリストの現在のバージョン番号です。 いない含まれており、必要な場合またはし、現在の一覧のバージョン番号、http/412 (precondition failed) に一致しない状態コードが返され、応答の本文には、現在のバージョン番号が含まれている一覧の最新のメタデータにが含まれます。 これは互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。
 
この呼び出しは、等; ではないことに注意してください。同じデータを繰り返し呼び出すと、複数の挿入する可能性があります。 ただし、一覧には、重複を現在サポートするものはないするため繰り返されている呼び出しが返されるコードの HTTP 400 を得られます。
  
<a id="ID4ETB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID) です。| 
| listtype| string| (その使用方法と動作) の一覧の種類です。 常に「ピン」これらのメソッドに関連します。| 
| リスト| string| リストの名前 (際に指定された listtype の一覧がどの)。 常に"XBLPins"の項目のピン留めします。| 
  
<a id="ID4E5B"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| insertIndex| string| 省略可能。 項目を挿入する位置を定義します。 サポートされる値: 0、正の整数と「終了」します。 インデックス値がリスト項目の数よりも大きいは、一覧の下部に新しい項目を追加し、一覧に「空白」は挿入されません。 既定値: 0 です。| 
  
<a id="ID4EZC"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを想定しています。 Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。 この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。 リスト自体では、同様の Xuid を識別し、リストの URI が含められます。 これを使用して、します、今後、一覧へのアクセスの共有のサポートがいる機能ではありませんこの時点でします。 現時点では、すべてのリストをユーザーにアクセスすることが、独自と共有へのアクセスはありません。 したがって、URI の Xuid は SAML クレーム トークンの Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。 


  
<a id="ID4EGD"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 要求は正常に完了しました。 応答本文では、(GET) 用、要求されたリソースを含める必要があります。 POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。| 
| 201| Created| 新しい一覧が作成されました。 これは初期の挿入のリストに返されます。 応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。| 
| 304| Not Modified| 取得で返されます。 クライアントに一覧の最新バージョンがあることを示します。 サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。 これらが等しい場合、304 取得データなしで返されます。| 
| 400| Bad Request| 要求が正しくありません。 無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。 不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。 <b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 呼び出し元では、リソースへのアクセスはありません。 これは、このような一覧が作成されていないことを示します。| 
| 412| Precondition Failed| 一覧のバージョンが変更された変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。 一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。| 
| 500| 内部サーバー エラー| サービスはサーバー側のエラーのための要求を拒否しています。| 
| 501| 実装されていません。| 呼び出し元では、サーバーで実装されていない URI を要求します。 (現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)| 
| 503| Service Unavailable| サーバーは、通常は負荷が高くなり、要求拒否しています。 遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。| 
  
<a id="ID4EEAAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 バージョン 2 のサポートのピン留めします。 このヘッダーが存在しないか、サービスには、400-が返されます後、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。| 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 "If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在の一覧のバージョン一覧データがないし、HTTP 304 存在し、渡されたバージョンに一致する – Not Modified コードが返されます。 | 
  
<a id="ID4E1BAC"></a>

 
## <a name="sample-request"></a>要求の例
 
**コンテンツ タイプ**、 **ItemId**または**ProviderId**、**プロバイダー** 、**ロケール**は必須です。
 

```cpp
{"Items":
  [{
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": "",
    "Provider": "",
    "ImageUrl": "http://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC", 
    "AltImageUrl": null, 
    "Title": "The Dark Knight", 
    "SubTitle": null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
  }]}
      
```

  
<a id="ID4EPCAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EVCAC"></a>

 
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

   
<a id="ID4E6CAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBDAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

   