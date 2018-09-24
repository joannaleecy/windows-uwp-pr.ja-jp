---
title: GET (/users/me/inventory)
assetID: 7b74dd08-2854-319d-3ed0-ddee75d922b9
permalink: en-us/docs/xboxlive/rest/uri-inventoryget.html
author: KevinAsgari
description: " GET (/users/me/inventory)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 270f36d354ee4561d12f78644436ad51e286768c
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4154526"
---
# <a name="get-usersmeinventory"></a>GET (/users/me/inventory)
呼び出し元に提供されているユーザーに関連付けられているインベントリのセットを提供します。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [クエリ文字列パラメーター](#ID4EHB)
  * [要求の例](#ID4EDE)
  * [応答本文](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ポリシー チェックなし、実施、またはフィルタ リングがこの呼び出しの一部として行われます。 呼び出し元では、返される結果の範囲を絞り込むためにクエリ パラメーターを渡すことのオプションがあります。

前の応答を通じて提供されるため、呼び出し元が継続トークンを使用して結果をページことができます: **/users/me/inventory?continuationToken = continuationTokenString**します。

呼び出し元では、特定の項目に関する情報を参照するために特定の項目の URL を使用して API の詳細への呼び出しをことがあります。

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| 使用可能状況| string| 現在利用可能な項目を返します。 既定では「使用可能」の日付範囲の開始日と終了の該当する現在の日付を返す項目です。 その他の値には"All"、すべての項目、および「利用不可」の項目を返します。 現在の日付の外側開始日と終了日の範囲したがって現在できないことを返すが含まれます。 |
| コンテナー| string| 省略可能。 場合は、ゲームの製品 ID を [値を設定すると、インベントリからの結果には、そのゲームに関連する項目にはのみが含まれます。 これは、特定のゲームの製品に結果をフィルター処理するようにサーバーから、インベントリを呼び出すときに特に便利です。|
| expandSatisfyingEntitlements| string| 応答に、ユーザーが、結果内で返されるすべてのニーズを満たして権利が含まれているかどうかを示すフラグ。 既定値は"false"です。 このパラメーターは、値"true"、Xbox 360 の購入に移行するサブスクリプション特典では、Xbox One、次のようにバンドルの権利の項目を満たすことによってユーザーに付与されているすべての製品を使用する場合などは、結果に追加されます。 この値は"false"とバンドルの ProductID などの親項目のみが結果と含まれている個々 の項目いないで返されます。 **注:** URI に itemType パラメーターが含まれていない場合のみサポートは、値"true"をこのパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。 |  
  | productIds | string |  具体的には、ユーザーの在庫から取得する ProductIds のコレクション コンマで区切って '、' です。  ユーザーが指定した ProductID、インベントリの結果で、その項目は表示されません結果に API の呼び出しから。 ExpandSatisfyingEntitlements パラメーター セットと共にバンドルの productID で渡すを true に設定すると、バンドルに含まれているすべての項目が呼び出しの結果で返されます (かは、クエリ文字列で、productIds を指定) かどうか。   |
  | 状態 | string | 返される項目の状態。 既定ではすべての項目を取得する"all"します。 その他の値は「有効」、だけその itemsthat が有効になっていることを示しますが、返すべき「一時停止」が中断されている項目のみを返すこと、"Expired"は、期限切れになった項目のみが返されることを示すを示す""を取り消した場合、することを示しますが取り消された項目のみを返す必要が、"Renewed"を示す更新されている項目のみを返す必要があります。  |

これらは、に加えては、リソースは、標準のページングのしくみをサポートします。

<a id="ID4EDE"></a>


## <a name="sample-request"></a>要求の例

このメソッドで URI の完全修飾ドメイン名が `https://inventory.xboxlive.com/users/me/inventory.
         `

> [!NOTE] 
> ユーザーと見なされるによって異なります、提供されたトークンが複数のユーザーを含めることができます。 1 人のユーザーのインベントリを設定する場合は、排他的を検討する特定のユーザーのユーザー ハッシュを提供することもする必要があります。

.

<a id="ID4ERE"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合は、サービスがインベントリ項目の配列を返します。 [InventoryItem (JSON)](../../json/json-inventoryitem.md)を参照してください。

<a id="ID4E4E"></a>


### <a name="sample-response"></a>応答の例


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

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)
