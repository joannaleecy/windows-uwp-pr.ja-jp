---
title: GET (/users/{ownerId}/summary)
assetID: 754190c9-b15d-f34b-1dca-5c92f6f67d12
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummaryget.html
description: " GET (/users/{ownerId}/summary)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3b228adab7b035ec8f4e65fc8b7458228a677987
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613997"
---
# <a name="get-usersowneridsummary"></a>GET (/users/{ownerId}/summary)
呼び出し元の観点から、所有者に関する概要データを取得します。

  * [URI パラメーター](#ID4EQ)
  * [承認](#ID4E2)
  * [必要な要求ヘッダー](#ID4EBC)
  * [省略可能な要求ヘッダー](#ID4EHD)
  * [要求本文](#ID4EXE)
  * [HTTP 状態コード](#ID4ECF)
  * [必要な応答ヘッダー](#ID4EZG)
  * [応答本文](#ID4EGAAC)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| リソースがアクセスされているユーザーの識別子。 使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。 値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、 <code>gt(SomeGamertag)</code>|

<a id="ID4E2"></a>


## <a name="authorization"></a>Authorization

| <b>名前</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- | --- | --- |
| xuid| 64 ビット符号なし整数| 必須。 呼び出し元のユーザー識別子。 値の例:2533274790395904|

<a id="ID4EBC"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Authorization| string| 承認データです。 これは、通常、暗号化された XSTS トークンです。 値の例:<b>XBL3.0 x=[hash];[token]</b>.|

<a id="ID4EHD"></a>


## <a name="optional-request-headers"></a>省略可能な要求ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| x-xbl-contract-version| string| この要求が送られるサービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。値の例:1|
| OK| string| コンテンツ型が許容されます。 すべての応答がなります<code>application/json</code>します。|

<a id="ID4EXE"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4ECF"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 400| 要求が正しくありません| ユーザー Id は、形式が正しくありませんでした。|
| 403| Forbidden| Authorization ヘッダーから XUID 要求を解析できませんでした。|

<a id="ID4EZG"></a>


## <a name="required-response-headers"></a>必要な応答ヘッダー

| Header| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Content-Length| string| 応答で送信されるバイト数。 値の例:232.|
| Content-Type| string| 応答本文の MIME の種類。 これでなければなりません<b>、application/json</b>します。|

<a id="ID4EGAAC"></a>


## <a name="response-body"></a>応答本文

参照してください[PersonSummary (JSON)](../../json/json-personsummary.md)します。

<a id="ID4ESAAC"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
    "targetFollowingCount": 87,
    "targetFollowerCount": 19,
    "isCallerFollowingTarget": true,
    "isTargetFollowingCaller": false,
    "hasCallerMarkedTargetAsFavorite": true,
    "hasCallerMarkedTargetAsKnown": true,
    "legacyFriendStatus": "None",
    "recentChangeCount": 5,
    "watermark": "5246775845000319351"
}

```


<a id="ID4E3AAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5AAC"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/summary](uri-usersowneridsummary.md)
