---
title: GET (/users/me)
assetID: 726c279b-73fb-02ea-cbff-700ff2dc31af
permalink: en-us/docs/xboxlive/rest/uri-usersmeget.html
author: KevinAsgari
description: " GET (/users/me)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 825b101ef5b450910f0bd9b2ab84991daa8074a7
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6151638"
---
# <a name="get-usersme"></a>GET (/users/me)
ユーザーの XUID を把握することがなく、現在のユーザーの[PresenceRecord](../../json/json-presencerecord.md)を取得します。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [クエリ文字列パラメーター](#ID4EZ)
  * [Authorization](#ID4EIC)
  * [必要な要求ヘッダー](#ID4ELD)
  * [オプションの要求ヘッダー](#ID4EPF)
  * [要求本文](#ID4EPG)
  * [応答本文](#ID4E1G)

<a id="ID4EZ"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| level| string| 省略可能。 <ul><li><b>ユーザー</b>: ユーザー ノードのみを返します。</li><li><b>デバイス</b>: ユーザーのノードとデバイス ノードを返します。</li><li><b>タイトル</b>: 既定値します。 アクティビティを除くツリー全体を返します。</li><li><b>すべて</b>: アクティビティ レベルのプレゼンスを含むツリー全体を返します。</li></ul> | 

<a id="ID4EIC"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- |
| XUID| はい| 呼び出し元の Xbox ユーザー ID (XUID)| 403 Forbidden|

<a id="ID4ELD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。|
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 値の例: 3, vnext します。|
| Accept| string| コンテンツの種類の受け入れられる。 プレゼンスでサポートされている 1 つのみがアプリケーション/json がヘッダーで指定する必要があります。|
| 同意言語| string| 応答で文字列を許容できるロケールです。 値の例: EN-US にします。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|

<a id="ID4EPF"></a>


## <a name="optional-request-headers"></a>オプションの要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 既定値: 1 です。|

<a id="ID4EPG"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E1G"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EAH"></a>


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


<a id="ID4EQH"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ESH"></a>


##### <a name="parent"></a>Parent

[/users/me](uri-usersme.md)
