---
title: GET (/users/xuid({xuid}))
assetID: c97ef943-8bea-8a41-90d7-faea874284c8
permalink: en-us/docs/xboxlive/rest/uri-usersxuidget.html
description: " GET (/users/xuid({xuid}))"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5fcc5d3b6a172eccab0656da39e6896b4df50840
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650927"
---
# <a name="get-usersxuidxuid"></a>GET (/users/xuid({xuid}))
別のユーザーまたはクライアントのプレゼンスを検出します。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EDB)
  * [クエリ文字列パラメーター](#ID4EOB)
  * [承認](#ID4E4C)
  * [リソースのプライバシーの設定の効果](#ID4EAE)
  * [必要な要求ヘッダー](#ID4EVH)
  * [省略可能な要求ヘッダー](#ID4E1BAC)
  * [要求本文](#ID4E1CAC)
  * [応答本文](#ID4EFDAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

一部を提供する応答をフィルター処理すること、 [PresenceRecord](../../json/json-presencerecord.md)コンシューマーはオブジェクト全体に興味がない場合。

> [!NOTE] 
> 返されるデータは、プライバシーとコンテンツの分離の規則によって制限されます。



<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) の対象ユーザーです。|

<a id="ID4EOB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- |
| level| string| (省略可能)。 <ul><li><b>ユーザー</b>:ユーザー ノードのみを返します。</li><li><b>デバイス</b>:ノードとデバイスのノードをユーザーに返されます。</li><li><b>タイトル</b>:既定。 アクティビティを除くツリー全体を返します。</li><li><b>すべて</b>:アクティビティ レベルのプレゼンスを含む、ツリー全体を返します。</li></ul> |

<a id="ID4E4C"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| XUID| 〇| 呼び出し元の Xbox ユーザー ID (XUID)| 403 許可されていません|

<a id="ID4EAE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

このメソッドは常に、200 を返しますが、応答本文のコンテンツを返さなかった可能性があります。

| 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Me| -| 200 OK|
| friend| すべてのユーザー| 200 OK|
| friend| 友達のみ| 200 OK|
| friend| ブロック済み| 200 OK|
| フレンド以外のユーザー| すべてのユーザー| 200 OK|
| フレンド以外のユーザー| 友達のみ| 200 OK|
| フレンド以外のユーザー| ブロック済み| 200 OK|
| サード パーティのサイト| すべてのユーザー| 200 OK|
| サード パーティのサイト| 友達のみ| 200 OK|
| サード パーティのサイト| ブロック済み| 200 OK|

<a id="ID4EVH"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。|
| OK| string| コンテンツ型が許容されます。 存在することによってサポートされている唯一は、application/json がヘッダーに指定する必要があります。|
| Accept Language| string| 応答内の文字列に対して許容されるロケール。 値の例: en-us (英語)。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|

<a id="ID4E1BAC"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. |

<a id="ID4E1CAC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EFDAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4ELDAC"></a>


### <a name="sample-response"></a>応答のサンプル

ユーザーの既存のレコードはありませんが、デバイスのレコードが返されます。


```cpp
{
  xuid:"0123456789",
  state:"online",
  devices:
  [{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  },
  {
    type:W8,
    titles:
    [{
      id:"23452345",
      name:"Contoso Gamehelp",
      state:"active",
      placement:"full",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Nirvana page",
      }
    }]
  }]
}

```


<a id="ID4EXDAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EZDAC"></a>


##### <a name="parent"></a>Parent

[/users/xuid({xuid})](uri-usersxuid.md)
