---
title: GET (/users/me/inventory)
assetID: 7b74dd08-2854-319d-3ed0-ddee75d922b9
permalink: en-us/docs/xboxlive/rest/uri-inventoryget.html
description: " GET (/users/me/inventory)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 31c787108fad84f06b02ded3958f9d2f99727cbe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632207"
---
# <a name="get-usersmeinventory"></a>GET (/users/me/inventory)
呼び出し元に指定されたユーザーに関連付けられているインベントリのセットを提供します。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [クエリ文字列パラメーター](#ID4EHB)
  * [要求のサンプル](#ID4EDE)
  * [応答本文](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ポリシー チェックを行わない、強制、または、この呼び出しの一部としてフィルター処理が発生します。 呼び出し元では、返される結果の範囲を限定するためにクエリ パラメーターを渡すことがあります。

前の応答で提供される、継続トークンを使用して結果を呼び出し元がページできます: **/users/me/inventory? continuationToken = continuationTokenString**します。

呼び出し元には、特定の項目の URL を使用した API の詳細を特定の項目に関する情報を表示するにはの呼び出しを行うことがあります。

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| 可用性| string| 返されるアイテムの現在の可用性。 既定値は、「使用可能」日付範囲にする対象の現在の日付が開始日と終了の間が項目を返します。 その他の値を含める"All"、すべての項目、および現在の日付の項目を返しますの"Unavailable"は開始日と終了の日付範囲とそのため現在使用できない外になりますが返されます。 |
| コンテナー| string| (省略可能)。 場合は、インベントリからの結果には、そのゲームに関連する項目にはのみが含まれます。 その後は、ゲームの製品 ID に、値を設定します。 これは、特定のゲームの製品まで結果をフィルター処理するようにサーバーからインベントリを呼び出すときに特に便利です。|
| expandSatisfyingEntitlements| string| 応答に、ユーザーが、結果内で返されるすべての満足できる権利が含まれますかどうかを示すフラグ。 既定では"false です"。 このパラメーターに Xbox 360 での購入は、サブスクリプションの特典、Xbox One に移行権利バンドルなどの項目を満たすを介してユーザーに与えられているすべての製品である"true"の値を使用するなどが、結果に追加されます。 この値が"false"の場合、バンドルの ProductID など、親アイテムのみが結果と個々 含まれる項目ではなく返されます。 **注:** ItemType パラメーターが URI に含まれていない場合にのみサポートされて"true"の値は、このパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。 |  
  | Productid | string |  具体的には、ユーザーのインベントリから取得する Productid のコレクションで区切られた ','。  ユーザーが指定された ProductID インベントリ結果に、その項目は、結果に API 呼び出しからいない表示されます。 True に expandSatisfyingEntitlements のパラメータ セットと共にバンドルの productID を渡す場合 (クエリ文字列で、Productid を指定したかどうか) かどうかの呼び出しの結果に、バンドルに含まれるすべての項目が返されます。   |
  | 状態 | string | 返されるアイテムの状態。 既定値は、すべての項目を返す"all"です。 その他の値は"Enabled"、そののみ itemsthat が有効になっていることを示しますが、返すべき「中断」中断されている項目のみが返されること、期限切れになった項目のみが返されることを示す、「期限切れ」を示す"キャンセル"ことを示します取り消される項目のみを返す必要がある"Renewed"書き換えられた項目のみが返されることを示します。  |

これらに加えて、リソースでは、標準のページングのメカニズムをサポートしています。

<a id="ID4EDE"></a>


## <a name="sample-request"></a>要求のサンプル

このメソッドに URI の完全修飾ドメイン名は `https://inventory.xboxlive.com/users/me/inventory.
         `

> [!NOTE] 
> どのユーザーがあると見なさによって異なります、提供されたトークンが複数のユーザーを含めることができます。 1 人のユーザーのインベントリを実行する場合は、排他的に検討する特定のユーザーのユーザーのハッシュを指定することも必要があります。

.

<a id="ID4ERE"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合、サービスは、インベントリ項目の配列を返します。 参照してください[inventoryItem (JSON)](../../json/json-inventoryitem.md)します。

<a id="ID4E4E"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
  "pagingInfo": {
    "continuationToken": string,
    "totalItems": int
  },
  "items":
  {
    "url": string,
    "itemType": "Music",
    "titleId": string,
    "containers": string,
    "obtained": DateTime,
    "startDate": DateTime,
    "endDate": DateTime,
    "state": "Enabled"  
}

```


<a id="ID4EHF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EJF"></a>


##### <a name="parent"></a>Parent

[/users/me/inventory](uri-inventory.md)


<a id="ID4ETF"></a>


##### <a name="further-information"></a>詳細情報

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
