---
title: GET (/users/xuid(xuid)/lists/PINS/{listname})
assetID: a63f595a-61dd-5885-c405-9833230abb94
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameget.html
author: KevinAsgari
description: " GET (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 42f40428f79110e55aae7e881c25a3789899fee7
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881509"
---
# <a name="get-usersxuidxuidlistspinslistname"></a>GET (/users/xuid(xuid)/lists/PINS/{listname})
リストの内容を返します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EIB)
  * [クエリ文字列パラメーター](#ID4ETB)
  * [Authorization](#ID4ESD)
  * [必要な要求ヘッダー](#ID4E6D)
  * [要求本文](#ID4EVF)
  * [HTTP ステータス コード](#ID4EAG)
  * [応答本文](#ID4E5CAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
返されるデータの**行数**フィールドは、項目の数はサービスによって--ようを管理する合計リストを示し、リストの末尾、あり、これは、可能性のある特定の数の項目が retu から別の数字を判断するために使用できます。要求によって rned します。
 
一覧がまだ存在しない場合、結果がリスト項目はありません、**数える**は 0 になります、 **listVersion**は 0 になります。
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)。| 
| listtype| string| (その使用方法と動作) の一覧の種類です。 常に「ピン」これらのメソッドを関連します。| 
| リスト| string| 一覧の名前 (際に特定の listtype の一覧がどの)。 常に"XBLPins"の項目を Pin にします。| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| skipItems| 32 ビットの符号付き整数| 省略可能。 結果を返す前に列挙でスキップされる項目の数。 既定値: 0 です。| 
| maxItems| 32 ビットの符号付き整数| 省略可能。 返される項目の最大数。 要求で最大値が指定されていない場合、既定値は 25 項目はします。 サービスがこの値は最大を配置しません。値が大きい場合、リスト内の項目の数よりも、エラーなしですべての項目が返されます。| 
| filterItemId| string| 省略可能。 一覧で検索する項目を指定します。 リストの項目のすべてのインスタンスを返します。 リスト内の項目は、そのをすばやく判断クライアントできます。 完全な一覧を反復処理することがなく、項目のすべてのインスタンスを判断する大規模なリストに便利です。 既定値: null。| 
| filterContentType| string| 省略可能。 コンテンツの種類を返すのコンマ区切りの一覧で指定します (戻りませんの種類の一覧ではなく)。 特定のコンテンツの種類を一覧からのみ取得するために使用します。 コンテンツの種類のコンマ区切りの一覧は、このフィルターに使用されます。 (複数のコンテンツの種類を 1 つの呼び出しで照会できます)。サポートされているコンテンツの種類には、エンターテインメント探索サービス (EDS) で定義されているすべてのメディアの種類が含まれます。 既定値: null (すべてのコンテンツの種類)。| 
| filterDeviceType| string| 省略可能。 デバイスの種類を返すのコンマ区切りの一覧で指定します (戻りませんの種類の一覧ではなく)。 戻り値のセットを特定のデバイスの種類のセットから挿入されている項目を返すだけをフィルター処理します。 デバイスの種類のコンマ区切りの一覧は、このフィルター (1 つの呼び出しでは複数の種類のデバイスを照会できます) に使用されます。 設定可能な値: XboxOne、MCapensis、WindowsPhone、WindowsPhone7、Web、PC、MoLive します。 既定値: null (すべてのコンテンツの種類)。| 
  
<a id="ID4ESD"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを想定しています。 Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。 この値は、呼び出し元に該当する一覧データへのアクセス権かどうかを使用します。 一覧自体では、同様の Xuid を識別し、一覧については、URI が追加します。 これを使用して、します、今後、一覧へのアクセスの共有のサポートがいる機能ではありませんこの時点で。 現時点では、ユーザーがアクセスするすべてのリストが独自と共有アクセスができなくなります。 したがって、URI の Xuid は SAML 要求トークンの Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL 認証 2.0 と 3.0 トークンの両方がサポートされています。 


  
<a id="ID4E6D"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認するために使用 STS トークンが含まれています。 トークンが XSTS サービスからと、要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API バージョンを指定します。 バージョン 2 でピンをサポートしています。 このヘッダーが存在しないか、サービスは、400-を返します、値がサポートされていない状態の説明に「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。| 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行うときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 現在のバージョン一覧の"If-match"ヘッダー内のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)使用できますの取得、現在の一覧のバージョンし一覧データがないと、HTTP 304 存在と渡されたバージョンに一致する場合は変更されませんコードが返されます。 | 
  
<a id="ID4EVF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EAG"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| 要求は正常に完了しました。 応答本文では、(GET) 用、要求されたリソースを含める必要があります。 POST、PUT 要求は、最新の状態の一覧のメタデータ (一覧のバージョン、数など) に表示されます。| 
| 201| Created| 新しい一覧が作成されました。 これは、最初の挿入の一覧に返されます。 応答には、一覧の最新の状態のメタデータが含まれています。 と場所ヘッダーには、リストの URI が含まれています。| 
| 304| Not Modified| 取得で返されます。 クライアントに一覧の最新バージョンがあることを示します。 サービスは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。 これらが等しい場合、304 取得データなしで返されます。| 
| 400| Bad Request| 要求が正しくありません。 無効な値、または URI またはクエリ文字列パラメーターの型にすることができます。 不足している必要なパラメーターの結果ことができます。 またはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。 <b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| 要求は、ユーザーまたはサービスは許可されません。| 
| 404| Not Found します。| 呼び出し元では、リソースへのアクセスはありません。 これは、このような一覧が作成されていないことを示します。| 
| 412| Precondition Failed| 一覧のバージョンが変更されていて、変更要求が失敗したことを示します。 変更要求は、挿入、更新、または削除します。 サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。 一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在の一覧メタデータ (を現在のバージョンを含む) と共に返されます。| 
| 500| 内部サーバー エラー| サービスはサーバー側のエラーのための要求を拒否しています。| 
| 501| 実装されていません。| 呼び出し元では、サーバーで実装されていない URI を要求します。 (現在だけの場合、要求の対象となるがホワイト リスト名。)| 
| 503| Service Unavailable| サーバーは通常負荷が高くなり、要求を拒否します。 遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。| 
  
<a id="ID4E5CAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EEDAC"></a>

 
### <a name="sample-response"></a>応答の例
 

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
     "ImageUrl": "http://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC",
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

[ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します](uri-usersxuidlistspinslistname.md)

  
<a id="ID4E1DAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace Uri](../marketplace/atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   