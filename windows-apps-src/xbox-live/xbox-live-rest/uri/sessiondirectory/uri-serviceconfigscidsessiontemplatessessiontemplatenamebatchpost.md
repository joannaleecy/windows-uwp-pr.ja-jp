---
title: POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)
assetID: 1a0a62ca-e120-e705-3c93-efd4697e2ccf
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigscidsessiontemplatessessiontemplatenamebatchpost.html
description: " POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 833b3c6b532dd65856342678d646798c5f24a6c1
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8350924"
---
# <a name="post-serviceconfigsscidsessiontemplatessessiontemplatenamebatch"></a>POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)
複数の Xbox ユーザー Id には、バッチ クエリを作成します。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EKB)
  * [クエリ文字列パラメーター](#ID4EVB)
  * [HTTP ステータス コード](#ID4EGF)
  * [要求本文](#ID4ENF)
  * [応答本文](#ID4EWF)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、複数の Xbox ユーザー Id、セッション テンプレート レベルでバッチ クエリを作成します。 このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**でラップすることができます。

2015 マルチプレイヤーを組み合わせます多くのクエリを 1 つの呼び出しにすべてのクエリが同じ場合、 *xuid*がクエリ文字列パラメーターで表されるさまざまな Xbox ユーザー Id (Xuid) を処理します。 クエリ文字列パラメーターと、応答は、定期的なクエリおよびバッチ クエリの同じである注意してください。

バッチ クエリでは、各 XUID に属するセッションは、 *xuid*パラメーターが要求されると同じ順序で応答に書き込まれます。 同じセッションと一致する各*xuid*に 1 回、応答を複数回のことができます。

<a id="ID4EKB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成 id (SCID)。 セッション識別子のパート 1 です。|
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 セッション識別子のパート 2 です。|

<a id="ID4EVB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。

| <b>パラメーター</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- | --- | --- | --- |
| キーワード| string| キーワード、たとえば、"foo"a を取得する場合は、セッションまたはテンプレートに含まれてする必要があります。 |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。 既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。 |
| 予約| boolean| セッションが含まれる場合は true、ユーザーは、予約済みプレイヤーとして設定されますが、アクティブなプレイヤーが参加していません。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| 非アクティブです| boolean| True に、ユーザーが受け入れたがアクティブに再生されていないセッションを含めます。 セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。 |
| プライベート| boolean| プライベート セッションを含める場合は true。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| visibility| string| セッションの可視性の状態。 設定可能な値は、 <b>MultiplayerSessionVisibility</b>によって定義されます。 このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。 <i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。 |
| version| 32 ビット符号付き整数| セッションの最大バージョンが含まれている場合があります。 たとえば、2 の値は、2 のセッションのメジャー バージョンとその専用のセッションを指定します。 または含まれている小さい必要があります。 バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。 |
| アプリでは| 32 ビット符号付き整数| 取得するセッションの最大数。 この数は 0 ~ 100 の間にある必要があります。 |


*プライベート*または*予約*のいずれかを true に設定すると、セッションにサーバー レベルのアクセスが必要です。 代わりに、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。 それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。

<a id="ID4EGF"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4ENF"></a>


## <a name="request-body"></a>要求本文


```cpp
{ "xuids": [ "1234", "5678" ] }

```


<a id="ID4EWF"></a>


## <a name="response-body"></a>応答本文

このメソッドからの戻り値は、いくつかのセッション データが含まれているインラインでのセッション参照の JSON 配列です。


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

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.md)
