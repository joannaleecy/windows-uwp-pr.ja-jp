---
title: GET (/users/me)
assetID: 726c279b-73fb-02ea-cbff-700ff2dc31af
permalink: en-us/docs/xboxlive/rest/uri-usersmeget.html
description: " GET (/users/me)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b06305fde989d0c30570beda5d4b0aabe7bf0518
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606727"
---
# <a name="get-usersme"></a>GET (/users/me)
現在のユーザーの取得[PresenceRecord](../../json/json-presencerecord.md)ユーザーの XUID を把握する必要はありません。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [クエリ文字列パラメーター](#ID4EZ)
  * [承認](#ID4EIC)
  * [必要な要求ヘッダー](#ID4ELD)
  * [省略可能な要求ヘッダー](#ID4EPF)
  * [要求本文](#ID4EPG)
  * [応答本文](#ID4E1G)

<a id="ID4EZ"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| level| string| (省略可能)。 <ul><li><b>ユーザー</b>:ユーザー ノードのみを返します。</li><li><b>デバイス</b>:ノードとデバイスのノードをユーザーに返されます。</li><li><b>タイトル</b>:既定。 アクティビティを除くツリー全体を返します。</li><li><b>すべて</b>:アクティビティ レベルのプレゼンスを含む、ツリー全体を返します。</li></ul> | 

<a id="ID4EIC"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- |
| XUID| 〇| 呼び出し元の Xbox ユーザー ID (XUID)| 403 許可されていません|

<a id="ID4ELD"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。|
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。|
| OK| string| コンテンツ型が許容されます。 存在することによってサポートされている唯一は、application/json がヘッダーに指定する必要があります。|
| Accept Language| string| 応答内の文字列に対して許容されるロケール。 値の例: en-us (英語)。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|

<a id="ID4EPF"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. |

<a id="ID4EPG"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4E1G"></a>


## <a name="response-body"></a>応答本文

<a id="ID4EAH"></a>


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


<a id="ID4EQH"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ESH"></a>


##### <a name="parent"></a>Parent

[/users/me](uri-usersme.md)
