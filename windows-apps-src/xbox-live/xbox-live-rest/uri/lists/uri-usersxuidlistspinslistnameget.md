---
title: GET (/users/xuid(xuid)/lists/PINS/{listname})
assetID: a63f595a-61dd-5885-c405-9833230abb94
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameget.html
description: " GET (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a31e6a6b541276d3191ba5d40767a1929c70168
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641627"
---
# <a name="get-usersxuidxuidlistspinslistname"></a>GET (/users/xuid(xuid)/lists/PINS/{listname})
一覧の内容を返します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EIB)
  * [クエリ文字列パラメーター](#ID4ETB)
  * [承認](#ID4ESD)
  * [必要な要求ヘッダー](#ID4E6D)
  * [要求本文](#ID4EVF)
  * [HTTP 状態コード](#ID4EAG)
  * [応答本文](#ID4E5CAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
**ListCount**で返されるデータ フィールドは、項目の数が--よう、サービスによって保持される完全な一覧を示します、リストの末尾が、これは、可能性のある数から別の番号を判断するために使用できます特定の項目は、要求によって返されました。
 
リストがまだ存在しないかどうかは、結果には、リスト アイテムはありません、 **listCount**は 0 になります、 **listVersion**は 0 になります。
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox のユーザー ID (XUID)。| 
| listtype| string| (その使用方法およびどのように機能します) のリストの種類。 常に「ピン」これらのメソッドに関連します。| 
| listname| string| リストの名前 (を操作する特定の listtype のどのリスト)。 常に"XBLPins"の項目のピンです。| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| skipItems| 32 ビット符号付き整数| (省略可能)。 結果を返す前に列挙でスキップする項目の数。 ［既定値］:0。| 
| maxItems| 32 ビット符号付き整数| (省略可能)。 返されるアイテムの最大数。 既定では、25 件のアイテムが、要求の最大値が指定されていない場合は。 サービスでは、最大です。 この値に設定されません。値がリスト内の項目の数よりも大きい場合は、すべての項目がエラーなしで返されます。| 
| filterItemId| string| (省略可能)。 一覧で検索する項目を指定します。 リスト内の項目のすべてのインスタンスを返します。 クライアントはリストに項目がある場合、そのをすばやく確認できます。 大きなリスト全体の一覧を反復処理することがなく、項目のすべてのインスタンスを判断するのに便利です。 既定値: null。| 
| filterContentType| string| (省略可能)。 返すコンテンツの種類のコンマ区切りのリストを指定します (は一覧にない型を返すありませんが)。 一覧からのみ特定のコンテンツ タイプを取得するために使用します。 コンテンツの種類のコンマ区切りの一覧は、このフィルターに使用されます。 (複数のコンテンツ タイプを 1 回の呼び出しで照会できます)。サポートされているコンテンツの種類には、Entertainment 検出サービス (EDS) で定義されているすべてのメディアの種類が含まれます。 既定値: null (すべてのコンテンツ タイプ)。| 
| filterDeviceType| string| (省略可能)。 返されるデバイスの種類のコンマ区切りのリストを指定します (は一覧にない型を返すありませんが)。 デバイスの種類の特定のセットから挿入されている項目のみを返しますに戻り値の設定をフィルター処理します。 デバイスの種類のコンマ区切りの一覧は、(1 回の呼び出しで複数のデバイスの種類を問い合わせることができます)、このフィルターに使用されます。 設定可能な値:XboxOne、MCapensis、WindowsPhone、WindowsPhone7、Web、PC、MoLive します。 既定値: null (すべてのコンテンツ タイプ)。| 
  
<a id="ID4ESD"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。 Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。 この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。 リスト自体も Xuid によって識別され、一覧については、URI に含まれます。 これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。 現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。 したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。 


  
<a id="ID4E6D"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、承認の要求に使用した STS トークンが含まれています。 必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。 | 
| X XBL コントラクト バージョン| API バージョンが要求された (正の整数) をされているを指定します。 バージョン 2 をサポートする pin。 このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。| 
| Content-Type| 要求/応答本文の内容が json または xml であるかどうかを指定します。 サポートされる値は"application/json"および"application/xml"| 
| If-Match| このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または DELETE 動詞。 "If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。 (省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。 | 
  
<a id="ID4EVF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EAG"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4E5CAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EEDAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{ 
"ListMetadata":
  {"ListVersion": 12,
   "ListCount": 6,
   "MaxListSize": 200,
   "AccessSetting": "OwnerOnly",
   "AllowDuplicates": true
  },
"ListItems":
  [{ 
   "Index": 0,
   "DateAdded": "\/Date(1198908717056)/",
   "DateModified": "\/Date(1198908717056)/",
   "HydrationResult": "Indeterminate",
   "HydratedItem": null

   "Item":
   {
     "ContentType": "Movie",
     "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
     "ProviderId": null,
     "Provider": null,
     "ImageUrl": "https://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC",
     "Title": "The Dark Knight",
     "SubTitle": null,
     "Locale": "en-us",
     "AltImageUrl": null,
     "DeviceType": "XboxOne"
    }
  }]
}
         
```

   
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

  
<a id="ID4E1DAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace の Uri](../marketplace/atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   