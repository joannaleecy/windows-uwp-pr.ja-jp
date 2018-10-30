---
title: POST (/handles/query?include=relatedInfo)
assetID: 66ecd1fe-24d4-4cd5-256d-8950ac658529
permalink: en-us/docs/xboxlive/rest/uri-handlesqueryincludepost.html
author: KevinAsgari
description: " POST (/handles/query?include=relatedInfo)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2caffd029e5b5c79eb411678621643a48f65e1f1
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5767938"
---
# <a name="post-handlesqueryincluderelatedinfo"></a>POST (/handles/query?include=relatedInfo)
セッションの関連する情報が含まれているセッション ハンドルに対するクエリを作成します。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4ECB)
  * [クエリ文字列パラメーター](#ID4EPB)
  * [HTTP ステータス コード](#ID4EAF)
  * [要求本文](#ID4EHF)
  * [応答本文](#ID4EZF)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、「含める」クエリ文字列で指定されたセッション情報を使ってデータのハンドルに対するクエリを作成します。 クエリ文字列値は、コンマ区切りリスト、たとえば、サポート、今後のクエリ オプションをサポートするために拡張できるように設計されています"かどうか。 含める = relatedInfo、セッション"します。 POST メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**でラップすることができます。

このメソッドの要求本文で型フィールドは、「アクティビティ」に設定する必要があります。 応答本文内の項目は、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**のプロパティに直接マップされます。

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a>URI パラメーター

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

クエリは、次の表にクエリ文字列パラメーターを使用して変更できます。

| <b>パラメーター</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- |
| キーワード| string| キーワード、たとえば、"foo"a を取得する場合は、セッションまたはテンプレートに含まれてする必要があります。 |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。 既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。 |
| 予約| boolean| セッションを含める場合は、ユーザーは、予約済みプレイヤーとして設定されますがしておらずアクティブのプレイヤーに参加していません。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| 非アクティブです| boolean| True に、ユーザーが受け入れたがアクティブに再生されていないセッションを含めます。 セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。 |
| プライベート| boolean| プライベート セッションを含める場合は true。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| visibility| string| セッションの可視性の状態。 設定可能な値は、 <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>によって定義されます。 このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。 <i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。 |
| version| 32 ビット符号付き整数| セッションの最大バージョンが含まれている場合があります。 たとえば、2 の値は、2 の主なセッションのバージョンとその専用のセッションを指定します。 または含まれている小さい必要があります。 バージョン番号は、要求のコントラクト バージョン mod 100 以内である必要があります。 |
| アプリ| 32 ビット符号付き整数| 取得するセッションの最大数。 この数は 0 ~ 100 の間にある必要があります。 |


*プライベート*または*予約*のいずれかを true に設定するには、セッションにサーバー レベルのアクセスが必要です。 代わりに、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。 それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。

<a id="ID4EAF"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される HTTP ステータス コードを返します。  
<a id="ID4EHF"></a>


## <a name="request-body"></a>要求本文

<a id="ID4ENF"></a>


### <a name="sample-request"></a>要求の例

ユーザーの「お気に入り」のソーシャル グラフのすべてのアクティビティを取得するには、次のようなポスト本文。


```cpp
{
  "type": "activity",
  "scid": "B5B1F71F-A328-4371-89E0-C3AD222D0E92"  // optional filter on scid
  "owners": {
     "people": {
       "moniker": "favorites",
       "monikerXuid": "3210"
     }
  }
}

```


<a id="ID4EZF"></a>


## <a name="response-body"></a>応答本文

結果は、各ハンドルに埋め込まれている一意の id、ハンドルの構造体の配列として返されます。 特定のセッションの情報は、 **relatedInfo**オブジェクトで返されます。 この情報は返されません正規の POST メソッドでこの URI に注意してください。

<a id="ID4EDG"></a>


### <a name="sample-response"></a>応答の例


```cpp
{
    "results": [{
        "id": "11111111-ebe0-42da-885f-033860a818f6",
        "type": "activity",
        "version": 1,
        "sessionRef": {
            "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
            "templateName": "party",
            "name": "e3a836aeac6f4cbe9bcab985494d3175"
        },

    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
        "relatedInfo": {
            "visibility": "open",
            "joinRestriction": "followed",
            "closed": true,
            "maxMembersCount": 8,
            "membersCount": 4,
        }
    },
    {
        "id": "11111111-ebe0-42da-885f-033860a818f7",
        "type": "activity",
        "version": 1,
        "sessionRef": {
            "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
            "templateName": "TitleStorageTestDefault",
            "name": "795fcaa7-8377-4281-bd7e-e86c12843632"
        },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
        "relatedInfo": {
            "visibility": "open",
            "joinRestriction": "followed",
            "closed": false,
            "maxMembersCount": 8,
            "membersCount": 4,
        }
    }]
}

```


<a id="ID4ENG"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EPG"></a>


##### <a name="parent"></a>Parent

[/handles/query](uri-handlesquery.md)
