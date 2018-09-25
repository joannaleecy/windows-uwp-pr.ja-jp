---
title: GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )
assetID: 2b2df42e-9b39-3906-36e4-fd9ff22add04
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcountget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e0915962803ddd304207bc726c0e5423ad0c8c77
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4175142"
---
# <a name="get-usersxuidxuidgroupsmonikerbroadcastingcount-"></a>GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )
URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [クエリ文字列パラメーター](#ID4EJB)
  * [Authorization](#ID4EKC)
  * [リソースのプライバシーの設定の効果](#ID4EQD)
  * [必要な要求ヘッダー](#ID4EEH)
  * [省略可能な要求ヘッダー](#ID4EMBAC)
  * [要求本文](#ID4EMCAC)
  * [HTTP ステータス コード](#ID4EXCAC)
  * [必要な応答ヘッダー](#ID4E3GAC)
  * [省略可能な応答ヘッダー](#ID4EMJAC)
  * [応答本文](#ID4E5KAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。| 
| モニカー| string| ユーザーのグループを定義する文字列です。 現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。| 
  
<a id="ID4EJB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| level| string| このクエリ文字列で指定された詳細レベルを返します。 有効なオプションには、「ユーザー」、「デバイス」、「タイトル」および"all"が含まれます。「ユーザー」レベルは、DeviceRecord 入れ子になったオブジェクトがない presencerecord を要求してオブジェクトです。 「デバイス」レベルでは、TitleRecord 入れ子になったオブジェクトがない presencerecord を要求してと DeviceRecord オブジェクトです。 「タイトル」レベルでは、ActivityRecord 入れ子になったオブジェクトがない presencerecord を要求して、DeviceRecord、TitleRecord オブジェクトです。 "All"レベルでは、すべての入れ子になったオブジェクトを含むレコード全体です。このパラメーターが指定されていない場合、サービスのレベルをタイトルに既定値 (タイトルの詳細は、このユーザーのプレゼンスを返す、)。| 
  
<a id="ID4EKC"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 種類| 必須?| 値の例| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>Xuid</b>| 64 ビットの符号付き整数| 必須| 1234567890| 
  
<a id="ID4EQD"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
サービスが常に返す 200 OK 要求自体が整形式である場合。 ただし、プライバシー チェックを渡さない場合、応答からの情報をフィルター処理には。
 
リソースのプライバシーの設定の効果 | ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| me| -| 前述のようにします。| 
| フレンド登録の依頼| すべてのユーザー| 前述のようにします。| 
| フレンド登録の依頼| フレンドのみ| 前述のようにします。| 
| フレンド登録の依頼| ブロックされています。| 説明に従って、サービスがデータをフィルター処理します。| 
| フレンド以外のユーザー| すべてのユーザー| 前述のようにします。| 
| フレンド以外のユーザー| フレンドのみ| 説明に従って、サービスがデータをフィルター処理します。| 
| フレンド以外のユーザー| ブロックされています。| 説明に従って、サービスがデータをフィルター処理します。| 
| サード パーティのサイト| すべてのユーザー| 説明に従って、サービスがデータをフィルター処理します。| 
| サード パーティのサイト| フレンドのみ| 説明に従って、サービスがデータをフィルター処理します。| 
| サード パーティのサイト| ブロックされています。| 説明に従って、サービスがデータをフィルター処理します。| 
  
<a id="ID4EEH"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。| 
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 値の例: 3, vnext します。| 
| Accept| string| コンテンツの種類の受け入れられるします。 1 つだけのプレゼンスがサポートは<b>アプリケーション/json</b>がでも指定ヘッダーで。| 
| 言語を受け入れる| string| 応答で文字列を許容できるロケールです。 値の例: EN-US にします。| 
| Host| string| サーバーのドメイン名。 値の例: userpresence.xboxlive.com します。| 
  
<a id="ID4EMBAC"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。| 
  
<a id="ID4EMCAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EXCAC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 405| Method Not Allowed| HTTP メソッドは、サポートされていないコンテンツの種類に対して使用されました。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 500| 要求のタイムアウト| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 503| 要求のタイムアウト| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
  
<a id="ID4E3GAC"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 値の例: 1、vnext します。| 
| Content-Type| string| 要求の本文の mime タイプ。 値の例:<b>アプリケーション/json</b>します。| 
| キャッシュ コントロール| string| キャッシュ動作を指定するていねい要求します。 値の例:"no-cache"します。| 
| X XblCorrelationId| string| サーバーが返すし、クライアントが受信を関連付けるサービスで生成された値です。 値の例:"4106d0bc-1cb3-47bd-83fd-57d041c6febe"です。| 
| X コンテンツの種類オプション| string| SDL 準拠の値を返します。 値の例:"nosniff"です。| 
| Date| string| メッセージが送信された日付/時刻。 値の例:"火曜日 2012 年 1 17 年 11 月 10時 33分: 31 GMT"します。| 
  
<a id="ID4EMJAC"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Retry-after| string| 503 HTTP エラーが返されます。 クライアントに呼び出しを再試行するまで待機する時間に知らせることができます。 値の例:「120」します。| 
| Content-Length| string| 応答本文の長さ。 値の例:「527」です。| 
| コンテンツ エンコード| string| 応答の種類をエンコードします。 値の例:"gzip"します。| 
  
<a id="ID4E5KAC"></a>

 
## <a name="response-body"></a>応答本文
 
この API は、現在のパラメーターを指定のブロードキャストの数の数を返します。
 
<a id="ID4EGLAC"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
    "count":42
 }

         
```

   
<a id="ID4EQLAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESLAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/groups/{moniker}](uri-usersxuidgroupsmoniker.md)

   