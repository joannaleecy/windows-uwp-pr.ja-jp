---
title: POST (/users/batch)
assetID: bd0b18fe-8a6d-d591-5b13-bcd9643e945a
permalink: en-us/docs/xboxlive/rest/uri-usersbatchpost.html
description: " POST (/users/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47376338a1c515aa00a7e0247df4cc16ee0db8d2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655677"
---
# <a name="post-usersbatch"></a>POST (/users/batch)
ユーザーのバッチのプレゼンスを取得します。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [承認](#ID4EAB)
  * [リソースのプライバシーの設定の効果](#ID4EDC)
  * [必要な要求ヘッダー](#ID4EYF)
  * [省略可能な要求ヘッダー](#ID4EGAAC)
  * [要求本文](#ID4EGBAC)
  * [応答本文](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

このメソッドは、任意のクライアント、サービス、またはユーザーのバッチのプレゼンス情報を説明しようとしているタイトルを使用する必要があります。

このバッチ要求の応答には、深さとパスでフィルターを指定できます。 コンシューマーは、これを使用を確認し、一連のユーザーのプレゼンスを表示できます。 この API でのフィルターでは、プロパティで、プロパティが And or 検索として機能します。

<a id="ID4EAB"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- |
| XUID| 〇| 呼び出し元の Xbox ユーザー ID (XUID)| 403 許可されていません|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

このメソッドは常に、200 を返しますが、応答本文のコンテンツを返さなかった可能性があります。

| 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作|
| --- | --- | --- | --- | --- | --- | --- |
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

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。|
| OK| string| コンテンツ型が許容されます。 存在することによってサポートされている唯一は、application/json がヘッダーに指定する必要があります。|
| Accept Language| string| 応答内の文字列に対して許容されるロケール。 値の例: en-us (英語)。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|
| Content-Length| string| 要求の本文の長さ。 値の例:312.|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. |

<a id="ID4EGBAC"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EMBAC"></a>


### <a name="required-members"></a>必須メンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ユーザー| ユーザーについては、1100 Xuid、一度に最大でプレゼンスが Xuid をリストします。|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a>省略可能なメンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| deviceTypes| について知りたいユーザーによって使用されるデバイスの種類の一覧です。 配列が空のまま場合、すべての可能なデバイスの種類に既定値 (つまり、none、フィルターで除外)。|
| タイトル| デバイスの一覧について知りたいユーザーを種類します。 配列が空のまま場合、すべての可能なタイトルを既定値 (つまり、none、フィルターで除外)。|
| level| 設定可能な値: <ul><li>ユーザー - ユーザー ノードの取得</li><li>デバイスのユーザーを取得し、デバイス ノード</li><li>タイトル-タイトルの基本的なレベルの情報を取得します。</li><li>豊富なプレゼンス情報、メディア情報、またはその両方の取得 - すべて</li></ul><br> 既定では"title です"。|
| ガジェットの onlineOnly| このプロパティが true の場合、バッチ操作はユーザーがオフライン (クロークされているものを含む) でレコードが除外されます。 指定されていない場合は、オンラインとオフラインの両方のユーザーが返されます。|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a>禁止されているメンバー

要求では、その他のすべてのメンバーが禁止されています。

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a>要求のサンプル


```cpp
{
  users:
  [
    "1234567890",
    "4567890123",
    "7890123456"
  ]
}

```


<a id="ID4ESEAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4E1EAC"></a>


### <a name="sample-response"></a>応答のサンプル

このメソッドが戻る、 [PresenceRecord](../../json/json-presencerecord.md)します。


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


<a id="ID4EKFAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EMFAC"></a>


##### <a name="parent"></a>Parent

[/users/batch](uri-usersbatch.md)
