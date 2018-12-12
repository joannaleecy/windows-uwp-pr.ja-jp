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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8930069"
---
# <a name="get-usersxuidxuid"></a>GET (/users/xuid({xuid}))
別のユーザーまたはクライアントの有無を検出します。
これらの Uri のドメインが`userpresence.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EDB)
  * [クエリ文字列パラメーター](#ID4EOB)
  * [Authorization](#ID4E4C)
  * [リソースのプライバシーの設定の効果](#ID4EAE)
  * [必要な要求ヘッダー](#ID4EVH)
  * [オプションの要求ヘッダー](#ID4E1BAC)
  * [要求本文](#ID4E1CAC)
  * [応答本文](#ID4EFDAC)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

応答には、コンシューマーは、全体のオブジェクトに興味がない場合は、 [PresenceRecord](../../json/json-presencerecord.md)の一部を提供するフィルターを適用できます。

> [!NOTE] 
> 返されるデータは、プライバシーとコンテンツの分離の規則によって制限されます。



<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) 対象ユーザーのします。|

<a id="ID4EOB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- |
| level| string| 省略可能。 <ul><li><b>ユーザー</b>: ユーザー ノードのみを返します。</li><li><b>デバイス</b>: ユーザーのノードとデバイス ノードを返します。</li><li><b>タイトル</b>: 既定値します。 アクティビティを除くツリー全体を返します。</li><li><b>すべて</b>: アクティビティ レベルのプレゼンスを含むツリー全体を返します。</li></ul> |

<a id="ID4E4C"></a>


## <a name="authorization"></a>Authorization

| 型| 必須かどうか| 説明| 不足している場合、応答|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| XUID| はい| 呼び出し元の Xbox ユーザー ID (XUID)| 403 Forbidden|

<a id="ID4EAE"></a>


## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果

このメソッドは常に 200 OK を返します。 がコンテンツを応答本文で返されない可能性があります。

| ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
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

<a id="ID4EVH"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。|
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 値の例: 3, vnext します。|
| Accept| string| コンテンツの種類の受け入れられる。 プレゼンスでサポートされている 1 つのみがアプリケーション/json がヘッダーで指定する必要があります。|
| 同意言語| string| 応答で文字列を許容できるロケールです。 値の例: EN-US にします。|
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。|

<a id="ID4E1BAC"></a>


## <a name="optional-request-headers"></a>オプションの要求ヘッダー

| ヘッダー| 型| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| X RequestedServiceVersion|  | この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。|

<a id="ID4E1CAC"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EFDAC"></a>


## <a name="response-body"></a>応答本文

<a id="ID4ELDAC"></a>


### <a name="sample-response"></a>応答の例

ユーザーの既存のレコードがない場合は、デバイスを持つレコードが返されます。


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
