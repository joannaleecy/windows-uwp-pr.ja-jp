---
title: POST (/handles/query)
assetID: a1a47d49-5c3f-8021-a213-13eb8bddf16a
permalink: en-us/docs/xboxlive/rest/uri-handlesquerypost.html
author: KevinAsgari
description: " POST (/handles/query)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5caed8863133129c7bc2f0ee3dcb87f1c4a935e
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5158992"
---
# <a name="post-handlesquery"></a>POST (/handles/query)
セッション ハンドルに対するクエリを作成します。

> [!IMPORTANT]
> このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4EDB)
  * [クエリ文字列パラメーター](#ID4EQB)
  * [HTTP ステータス コード](#ID4EBF)
  * [要求本文](#ID4EIF)
  * [応答本文](#ID4ETF)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈

この HTTP/REST メソッドは、セッション情報せず、ハンドルのデータのみのクエリを作成します。 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForSocialGroupAsync**を折り返すことができます。

このメソッドの要求本文の型フィールドは、「アクティビティ」に設定する必要があります。 応答本文内の項目は、 **MultiplayerActivityDetails**のプロパティに直接マップされます。

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a>URI パラメーター

<a id="ID4EQB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。

| <b>パラメーター</b>| <b>型</b>| <b>説明</b>|
| --- | --- | --- | --- |
| キーワード| string| キーワード、たとえば、"foo"の a を取得する場合は、セッションまたはテンプレートに含まれてする必要があります。 |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。 既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。 |
| 予約| boolean| セッションを含める場合は、ユーザーによって予約済みプレイヤーとして設定されますが、しておらずアクティブ プレイヤーに参加していません。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| 非アクティブ| boolean| ユーザーが受け入れたがアクティブにプレイしていないセッションを 場合は true。 セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。 |
| プライベート| boolean| プライベート セッションを含める場合は true。 自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。 |
| visibility| string| セッションの可視性の状態。 使用可能な値は、 <b>MultiplayerSessionVisibility</b>によって定義されます。 このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。 <i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。 |
| version| 32 ビット符号付き整数| セッションの最大バージョンが含まれている場合があります。 たとえば、以下を含めるようにまたは 2 の値が 2 の主なセッションのバージョンでのみそのセッションを指定します。 バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。 |
| アプリでは| 32 ビット符号付き整数| 取得するセッションの最大数。 この数は、0 ~ 100 の間にある必要があります。 |


*プライベート*または*予約*のいずれかを true に設定するには、セッションにサーバー レベルのアクセスが必要です。 また、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。 それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。

<a id="ID4EBF"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード
サービスは、MPSD に適用される、HTTP ステータス コードを返します。  
<a id="ID4EIF"></a>


## <a name="request-body"></a>要求本文

ユーザーの「お気に入り」のソーシャル グラフのすべてのアクティビティ、要求本文は次のような。


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


<a id="ID4ETF"></a>


## <a name="response-body"></a>応答本文

ハンドルは、各構造体に埋め込まれている一意の id、ハンドルの構造体の配列として取得されます。


```cpp
{
  "results": [
    {
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
    }
  }]
}

```


<a id="ID4E4F"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E6F"></a>


##### <a name="parent"></a>Parent

[/handles/query](uri-handlesquery.md)
