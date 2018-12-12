---
title: PUT (/users/xuid(xuid)/lists/PINS/{listname})
assetID: f7964d2e-a8c8-2caa-ca97-e0d76ef586f4
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameput.html
description: " PUT (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9483ca581345cd32b46978ec38c5e6015323b597
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8933019"
---
# <a name="put-usersxuidxuidlistspinslistname"></a>PUT (/users/xuid(xuid)/lists/PINS/{listname})
要求本文内の各項目に指定されたインデックスに従ってリスト内の項目を更新します。 これらの Uri のドメインが`eplists.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E1B)
  * [Authorization](#ID4EFC)
  * [HTTP ステータス コード](#ID4ESC)
  * [必要な要求ヘッダー](#ID4EPH)
  * [要求本文](#ID4EGBAC)
  * [応答本文](#ID4EWBAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
この呼び出しは、要求の本文内の各項目に指定されたインデックスに従ってリスト内の項目に更新されます。 この呼び出しリストに項目は挿入されませんなり、項目が指定されたインデックスが存在しない場合はし、呼び出しが 400 無効な要求の状態を返します。 1 つの呼び出しで複数の項目を更新することができますが、すべてが、現在の一覧に存在する必要があります。 すべてを取得するように更新または更新を取得します。
 
この呼び出しは、**インデックス**ではなく**itemId**によって指定される更新する項目をことができます。 これを行うには、単に、サービスに送信される**IndexedItems**構造内のインデックスを「-1」を使用します。 明らかにこの例では、 **itemId**は変更できませんして更新プログラムの一部としてため、その他のメタデータ フィールドへの変更が機能のみ。 **プロバイダー**/項目の識別に**itemId**代わり**providerId**コンボに使うことができます。 内部では、サービスは、これらの項目とを更新する適切なインデックスの図の一覧を検索します。 または複数の項目が見つからない場合 400 無効な要求の状態が返され、項目は更新されません。
 
この呼び出しに必要な**場合-マッチ: versionNumber**インデックスを使用して、項目を識別する場合、要求に含まれるヘッダー。 使用して項目の項目を識別する Id (一覧は、重複を許可しない) 場合、 **If-match**ヘッダーは省略可能です。 存在する場合、 **If-match**ヘッダーが常に検証されます。 ヘッダー、 **versionNumber**はリストの現在のバージョン番号です。 場合に一致し、現在の一覧のバージョン番号、HTTP 412 Precondition Failed のステータス コードが返されると、応答の本文いないが含まれて一覧の最新のメタデータがない含まれている (および必須)、または現在のバージョン番号が含まれます。 これは互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。
  
<a id="ID4E1B"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID) です。| 
| listtype| string| (その使用方法と動作) の一覧の種類です。 常に「ピン」これらのメソッドに関連します。| 
| リスト| string| リストの名前 (際に指定された listtype の一覧がどの)。 常に"XBLPins"の項目のピン留めします。| 
  
<a id="ID4EFC"></a>

 
## <a name="authorization"></a>Authorization
 
この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを想定しています。 Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。 この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。 リスト自体では、同様の Xuid を識別し、リストの URI が含められます。 これを使用して、します、今後、一覧へのアクセスの共有のサポートがいる機能ではありませんこの時点でします。 現時点では、すべてのリストをユーザーにアクセスすることが、独自と共有へのアクセスはありません。 したがって、URI の Xuid は SAML クレーム トークンの Xuid と一致する必要があります。 

> [!NOTE] 
> 現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。 


  
<a id="ID4ESC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
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
  
<a id="ID4EPH"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| 認証し、要求を承認する STS トークンが含まれています。 トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。 | 
| X XBL コントラクト バージョン| 要求された (正の整数) をされている API のバージョンを指定します。 バージョン 2 のサポートのピン留めします。 このヘッダーが存在しないか、サービスには、400-が返されます後、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。| 
| Content-Type| 要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。 サポートされる値は"アプリケーション/json"と"アプリケーション/xml"| 
| If-Match| このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。 変更要求の使用 PUT、POST、または動詞を削除します。 "If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。 (省略可能)また場合に使用できますの取得、現在の一覧のバージョン一覧データがないし、HTTP 304 存在し、渡されたバージョンに一致する – Not Modified コードが返されます。 | 
  
<a id="ID4EGBAC"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4EMBAC"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
{"IndexedItems":
 [{ "Index": 0, 
     "Item": 
     {
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": null,
    "Provider": null,
    "ImageUrl": "http://www.bing.com/thumb/...",
    "Title": "The Dark Knight",
    "SubTitle":null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
}
}]}      
      
```

   
<a id="ID4EWBAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4E3BAC"></a>

 
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

   
<a id="ID4EGCAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EICAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid(xuid)/lists/PINS/{listname}](uri-usersxuidlistspinslistname.md)

   