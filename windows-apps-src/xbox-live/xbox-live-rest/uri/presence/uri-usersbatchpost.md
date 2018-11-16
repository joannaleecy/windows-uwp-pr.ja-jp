---
title: POST (/users/batch)
assetID: bd0b18fe-8a6d-d591-5b13-bcd9643e945a
permalink: en-us/docs/xboxlive/rest/uri-usersbatchpost.html
author: KevinAsgari
description: " POST (/users/batch)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9187aa43d3d4ee3a76ec834ac0352b66fe59167f
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837631"
---
# <a name="post-usersbatch"></a>POST (/users/batch)
ユーザーのバッチのプレゼンスを取得します。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [Authorization](#ID4EAB)
  * [リソースのプライバシーの設定の効果](#ID4EDC)
  * [必要な要求ヘッダー](#ID4EYF)
  * [オプションの要求ヘッダー](#ID4EGAAC)
  * [要求本文](#ID4EGBAC)
  * [応答本文](#ID4ESEAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

このメソッドは、すべてクライアント、サービス、またはユーザーのバッチのプレゼンス情報についてはしようとしているタイトルで使用する必要があります。

このバッチ要求の応答は、深度とパスによってフィルターできます。 消費者は、これを使用を確認し、一連のユーザーのプレゼンスを表示できます。 この API のフィルターでは、プロパティの間では、プロパティで And で Or として動作します。

<a id="ID4EAB"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- |
| XUID| はい| 呼び出し元の Xbox ユーザー ID (XUID)| 403 Forbidden|

<a id="ID4EDC"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

このメソッドは常に、200 を返しますがコンテンツを応答本文で返されない可能性があります。

| ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作|
| --- | --- | --- | --- | --- | --- | --- |
| me| -| 200 OK|
| フレンド登録の依頼| すべてのユーザー| 200 OK|
| フレンド登録の依頼| フレンドのみ| 200 OK|
| フレンド登録の依頼| ブロック| 200 OK|
| フレンド以外のユーザー| すべてのユーザー| 200 OK|
| フレンド以外のユーザー| フレンドのみ| 200 OK|
| フレンド以外のユーザー| ブロック| 200 OK|
| サード パーティのサイト| すべてのユーザー| 200 OK|
| サード パーティのサイト| フレンドのみ| 200 OK|
| サード パーティのサイト| ブロック| 200 OK|

<a id="ID4EYF"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。|
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 値の例: 3, vnext します。|
| Accept| string| コンテンツの種類の受け入れられる。 プレゼンスでサポートされている 1 つのみがアプリケーション/json がヘッダーで指定する必要があります。|
| 同意言語| string| 応答で文字列を許容できるロケールです。 値の例: EN-US にします。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|
| Content-Length| string| 要求の本文の長さ。 値の例: 312 します。|

<a id="ID4EGAAC"></a>


## <a name="optional-request-headers"></a>オプションの要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 既定値: 1 です。|

<a id="ID4EGBAC"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EMBAC"></a>


### <a name="required-members"></a>必要なメンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ユーザー| については、一度に 1100 Xuid の最大プレゼンスがユーザーの Xuid をリストします。|

<a id="ID4EHCAC"></a>


### <a name="optional-members"></a>省略可能なメンバー

| メンバー| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| deviceTypes| について知りたいユーザーに使用されるデバイスの種類の一覧です。 空の配列の場合、既定値はすべての可能なデバイスの種類 (つまり、none が除外されます)。|
| タイトル| デバイスの一覧について理解していることをユーザーを種類します。 空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。|
| level| 設定可能な値: <ul><li>ユーザーのユーザーのノードを入手します。</li><li>デバイスで入手するユーザーとデバイス ノード</li><li>タイトルのタイトルの基本的なレベルの情報の取得</li><li>リッチ プレゼンス情報やメディアについては、すべてを取得します。</li></ul><br> 既定値は、「タイトル」です。|
| ガジェットの onlineOnly| このプロパティが true の場合、バッチ操作がオフラインのユーザーが (回答が決まるものを含む) のレコードを絞り込まれます。 指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。|

<a id="ID4E4DAC"></a>


### <a name="prohibited-members"></a>禁止されているメンバー

要求では、他のすべてのメンバーが禁止されています。

<a id="ID4EIEAC"></a>


### <a name="sample-request"></a>要求の例


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


### <a name="sample-response"></a>応答の例

このメソッドは、 [PresenceRecord](../../json/json-presencerecord.md)を返します。


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
