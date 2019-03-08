---
title: POST (/users/xuid(xuid)/lists/PINS/{listname})
assetID: 813c0bd2-aca9-a1f6-9e81-a84a4c897b1e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamepost.html
description: " POST (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d30e5407be128032947f3f701f59ef25a16daaea
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589977"
---
# <a name="post-usersxuidxuidlistspinslistname"></a>POST (/users/xuid(xuid)/lists/PINS/{listname})
クエリ文字列パラメーターに基づいてインデックス位置にある一覧に項目を挿入**insertIndex**します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EY)
  * [URI パラメーター](#ID4ETB)
  * [クエリ文字列パラメーター](#ID4E5B)
  * [承認](#ID4EZC)
  * [HTTP 状態コード](#ID4EGD)
  * [必要な要求ヘッダー](#ID4EEAAC)
  * [要求のサンプル](#ID4E1BAC)
  * [応答本文](#ID4EPCAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a>注釈
 
この呼び出しは、リスト、クエリ文字列パラメーターに基づいてインデックス位置に項目を挿入**insertIndex** (0 またはリストの先頭に既定値)。 要求本文のすべての項目は、一覧でその時点で挿入されます。 場合、 **insertIndex**数よりも大きいが、最後に、既存の一覧で項目の新しい項目が挿入されます。
 
挿入する項目を必要なフィールドが; 機能仕様に示されている必要があります。それ以外の場合、HTTP 400 が返されます。 同様に、挿入の結果は (リストの種類ごとに定義された) リストの最大サイズを超える場合、HTTP 400 が返されます、何も挿入されます。
 
項目が場合*いない*、先頭またはリストの末尾に挿入する、**場合-一致: versionNumber**ヘッダーが要求に含まれている必要。 ヘッダーでは、カーソルが先頭または末尾の場合は省略可能です。 存在する場合は、挿入場所に関係なく、ヘッダーが検証されます。 ヘッダーに**VersionNumber**リストの現在のバージョン番号です。 いない含まれており、必要な場合または現在のリストのバージョン番号、HTTP 412 (precondition できませんでした) に一致しない状態コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。 これは、いずれかの別の踏み潰す別のクライアントからの更新を防ぐ。
 
この呼び出しがべき等である; ではないことに注意してください。同じデータを繰り返し呼び出すは、複数の挿入になる可能性があります。 ただし、一覧には、重複部分を現在サポートするものはありません、ために繰り返される呼び出しは HTTP 400 で可能性の高い結果コードが返されます。
  
<a id="ID4ETB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox のユーザー ID (XUID)。| 
| listtype| string| (その使用方法およびどのように機能します) のリストの種類。 常に「ピン」これらのメソッドに関連します。| 
| listname| string| リストの名前 (を操作する特定の listtype のどのリスト)。 常に"XBLPins"の項目のピンです。| 
  
<a id="ID4E5B"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| insertIndex| string| (省略可能)。 項目を挿入する位置を定義します。 サポートされる値:0、正の整数と「終了」です。 リスト項目の数より大きいインデックス値は、一覧の下部にある新しい項目を追加し、一覧で"blank"のスペースは挿入されません。 ［既定値］:0。| 
  
<a id="ID4EZC"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。 Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。 この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。 リスト自体も Xuid によって識別され、一覧については、URI に含まれます。 これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。 現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。 したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。 


  
<a id="ID4EGD"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 要求は正常に完了しました。 応答本文は、(GET) の要求されたリソースを含める必要があります。 POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。| 
| 201| 作成日| 新しいリストが作成されました。 これが初期の挿入時のリストに返されます。 応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。| 
| 304| 変更されていません| 返されるを取得します。 クライアントが最新バージョンの一覧を示します。 サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。 等しい場合、304 取得データなしで返されます。| 
| 400| 要求が正しくありません| 要求が正しくありません。 無効な値または URI またはクエリ文字列パラメーターの型です。 不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。 参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 呼び出し元には、リソースへのアクセスはありません。 これは、このようなリストが作成されていないことを示します。| 
| 412| Precondition Failed| リストのバージョンが変更された変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。 リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。| 
| 500| 内部サーバー エラー| サービスは、サーバー側エラーのために要求拒否しています。| 
| 501| 実装されていません| 呼び出し元は要求がサーバー上に実装されていない URI です。 (現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)| 
| 503| サービス利用不可| サーバーは、通常の負荷が高すぎるため、要求拒否しています。 遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。| 
  
<a id="ID4EEAAC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、承認の要求に使用した STS トークンが含まれています。 必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。 | 
| X XBL コントラクト バージョン| API バージョンが要求された (正の整数) をされているを指定します。 バージョン 2 をサポートする pin。 このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。| 
| Content-Type| 要求/応答本文の内容が json または xml であるかどうかを指定します。 サポートされる値は"application/json"および"application/xml"| 
| If-Match| このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または DELETE 動詞。 "If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。 (省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。 | 
  
<a id="ID4E1BAC"></a>

 
## <a name="sample-request"></a>要求のサンプル
 
**ContentType**、 **ItemId**または**ProviderId**、**プロバイダー**と**ロケール**は必須です。
 

```cpp
{"Items":
  [{
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": "",
    "Provider": "",
    "ImageUrl": "https://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC", 
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

   
<a id="ID4E6CAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBDAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

   