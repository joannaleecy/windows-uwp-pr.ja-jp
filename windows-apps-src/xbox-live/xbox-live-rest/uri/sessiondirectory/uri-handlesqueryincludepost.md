---
title: POST (/handles/query?include=relatedInfo)
assetID: 66ecd1fe-24d4-4cd5-256d-8950ac658529
permalink: en-us/docs/xboxlive/rest/uri-handlesqueryincludepost.html
description: " POST (/handles/query?include=relatedInfo)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eb30561c91a085902dd9d79b6c4a2045dc709bfb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632557"
---
# <a name="post-handlesqueryincluderelatedinfo"></a>POST (/handles/query?include=relatedInfo)
関連するセッションの情報を含むセッション ハンドルのクエリを作成します。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4ECB)
  * [クエリ文字列パラメーター](#ID4EPB)
  * [HTTP 状態コード](#ID4EAF)
  * [要求本文](#ID4EHF)
  * [応答本文](#ID4EZF)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドでは、"include"クエリ文字列で指定されたセッション情報と共にハンドルのデータに対するクエリを作成します。 クエリ文字列の値は、コンマ区切りの一覧などをサポートしている、将来のクエリ オプションをサポートするために拡張できるように設計されています"でしょうか。 含める = relatedInfo、セッション"。 によって、POST メソッドをラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**します。

このメソッドの要求本文の型フィールドは、「アクティビティ」に設定する必要があります。 応答本文内の項目がマップのプロパティに直接、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**します。

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a>URI パラメーター

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。

| <b>パラメーター</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- |
| キーワード| string| キーワード、たとえば、"foo"と、a を取得する場合は、セッションまたはテンプレート内で検出する必要があります。 |
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID で、たとえば、「123」、セッション、クエリに含める。 既定では、ユーザーに含まれているセッションでアクティブにある必要があります。 |
| 予約| boolean| 対象のセッションが含まれる場合は true、ユーザーは、予約済みのプレーヤーとして設定されますが、作業中のプレーヤーに参加していません。 このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。 |
| 非アクティブ| boolean| ユーザーが受け入れたにもかかわらず再生されていないセッションは、true です。 セッションのユーザーが"ready"ですが「アクティブ」では、非アクティブとしてカウントします。 |
| プライベート| boolean| プライベート セッションを含めるには true です。 このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。 |
| visibility| string| セッションの表示状態。 使用可能な値が定義されている、 <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>します。 このパラメーターが「開いている」に設定されている場合、クエリはのみ開いているセッションを含める必要があります。 "Private"で、設定されている場合、<i>プライベート</i>パラメーターを設定する必要がありますを true にします。 |
| version| 32 ビット符号付き整数| 組み込む必要があるセッションの最大バージョン。 たとえば、2 の値が 2 の主要なセッションのバージョンでのみそのセッションを指定または小さい必要があります。 バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。 |
| Take| 32 ビット符号付き整数| 取得するセッションの最大数。 この数は、0 ~ 100 の範囲にある必要があります。 |


いずれかを設定*プライベート*または*予約*に true の場合、セッションにサーバー レベルのアクセスが必要です。 または、これらの設定では、呼び出し元の XUID 要求の URI に XUID フィルターに一致する必要があります。 それ以外の場合、HTTP/403 状態コードが返されます、このようなすべてのセッションが実際に存在するかどうか。

<a id="ID4EAF"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EHF"></a>


## <a name="request-body"></a>要求本文

<a id="ID4ENF"></a>


### <a name="sample-request"></a>要求のサンプル

にユーザーの「お気に入り」ソーシャル グラフのすべてのアクティビティを取得するには、POST の本文はようになります。


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

結果は、各ハンドルに埋め込まれている一意の id、ハンドルの構造体の配列として返されます。 特定のセッション情報が返される、 **relatedInfo**オブジェクト。 この情報はこの URI で正規の POST メソッドに返されませんことに注意してください。

<a id="ID4EDG"></a>


### <a name="sample-response"></a>応答のサンプル


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
