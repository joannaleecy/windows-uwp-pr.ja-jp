---
title: POST (/serviceconfigs/{scid}/batch)
assetID: b821a6eb-1add-ef91-bdf5-10e107082197
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidbatchpost.html
description: " POST (/serviceconfigs/{scid}/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e718fda26264667a7bf08c9254a462eb268dcd74
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603447"
---
# <a name="post-serviceconfigsscidbatch"></a>POST (/serviceconfigs/{scid}/batch)
サービスの構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4ELB)
  * [クエリ文字列パラメーター](#ID4EVB)
  * [HTTP 状態コード](#ID4EGF)
  * [要求本文](#ID4ENF)
  * [応答本文](#ID4EWF)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、サービス構成の ID (SCID) レベルで複数の Xbox ユーザー Id のバッチ クエリを作成します。 このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**します。

2015 マルチ プレーヤーに結合できます多くのクエリを 1 回の呼び出しのすべてのクエリが同じ場合で表されるように Xbox に異なるユーザー Id (Xuid) を扱う、 *xuid*クエリ文字列パラメーター。 クエリ文字列パラメーターと、応答は、通常のクエリとバッチ クエリと同じであるに注意してください。

バッチ クエリの場合は、各 XUID に属しているセッションと同じ順序で応答に書き込まれます、 *xuid*パラメーターは、要求で表示されます。 同じセッションごとに 1 回、応答で複数回を出現する可能性があります*xuid*これに一致します。

<a id="ID4ELB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|

<a id="ID4EVB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。

| <b>パラメーター</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- | --- | --- | --- |
| キーワード| string| キーワード、たとえば、"foo"と、a を取得する場合は、セッションまたはテンプレート内で検出する必要があります。 |
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID で、たとえば、「123」、セッション、クエリに含める。 既定では、ユーザーに含まれているセッションでアクティブにある必要があります。 |
| 予約| boolean| 対象のセッションが含まれる場合は true、ユーザーは、予約済みのプレーヤーとして設定されますが、作業中のプレーヤーに参加していません。 このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。 |
| 非アクティブ| boolean| ユーザーが受け入れたにもかかわらず再生されていないセッションは、true です。 セッションのユーザーが"ready"ですが「アクティブ」では、非アクティブとしてカウントします。 |
| プライベート| boolean| プライベート セッションを含めるには true です。 このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。 |
| visibility| string| セッションの表示状態。 使用可能な値が定義されている、 <b>MultiplayerSessionVisibility</b>します。 このパラメーターが「開いている」に設定されている場合、クエリはのみ開いているセッションを含める必要があります。 "Private"で、設定されている場合、<i>プライベート</i>パラメーターを設定する必要がありますを true にします。 |
| version| 32 ビット符号付き整数| 組み込む必要があるセッションの最大バージョン。 たとえば、2 の値が 2 の主要なセッションのバージョンでのみそのセッションを指定または小さい必要があります。 バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。 |
| Take| 32 ビット符号付き整数| 取得するセッションの最大数。 この数は、0 ~ 100 の範囲にある必要があります。 |


いずれかを設定*プライベート*または*予約*に true の場合、セッションにサーバー レベルのアクセスが必要です。 または、これらの設定では、呼び出し元の XUID 要求の URI に XUID フィルターに一致する必要があります。 それ以外の場合、HTTP/403 状態コードが返されます、このようなすべてのセッションが実際に存在するかどうか。

<a id="ID4EGF"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4ENF"></a>


## <a name="request-body"></a>要求本文


```cpp
{ "xuids": [ "1234", "5678" ] }

```


<a id="ID4EWF"></a>


## <a name="response-body"></a>応答本文

このメソッドからの戻り値は、いくつかのセッションに含まれるデータをインラインでのセッションの参照の JSON 配列です。


```cpp
{
    "results": [ {
      "xuid": "9876",    // If the session was found from a xuid, that xuid.
      "startTime": "2009-06-15T13:45:30.0900000Z",
      "sessionRef": {
        "scid": "foo",
        "templateName": "bar",
        "name": "session-seven"
      },
      "accepted": 4,    // Approximate number of non-reserved members.
      "status": "active",    // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
      "visibility": "open",    // or "private", "visible", or "full"
      "joinRestriction": "local",    // or "followed". Only present if 'visibility' is "open" or "full" and the session has a join restriction.
      "myTurn": true,    // Not present is the same as 'false'. Only present if the session was found using a xuid.
      "keywords": [ "one", "two" ]
    }
  ]
}

```


<a id="ID4EDG"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EFG"></a>


##### <a name="parent"></a>Parent

[/serviceconfigs/{scid}/batch](uri-serviceconfigsscidbatch.md)
