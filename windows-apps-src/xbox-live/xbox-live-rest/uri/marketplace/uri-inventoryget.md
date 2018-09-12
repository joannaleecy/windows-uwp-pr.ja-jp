---
title: 取得する (/ユーザー/me/インベントリ)
assetID: 7b74dd08-2854-319d-3ed0-ddee75d922b9
permalink: en-us/docs/xboxlive/rest/uri-inventoryget.html
author: KevinAsgari
description: " 取得する (/ユーザー/me/インベントリ)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 270f36d354ee4561d12f78644436ad51e286768c
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882517"
---
# <a name="get-usersmeinventory"></a>取得する (/ユーザー/me/インベントリ)
呼び出し元に提供されているユーザーに関連付けられているインベントリのセットを提供します。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [注釈](#ID4EV)
  * [クエリ文字列パラメーター](#ID4EHB)
  * [要求の例](#ID4EDE)
  * [応答本文](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a>注釈

ポリシー チェックを行わない、実施、またはこの呼び出しの一部としてフィルタ リングが発生します。 呼び出し元では、返される結果の範囲を限定するためにクエリ パラメーターを渡すことのオプションがあります。

前の応答で提供される、継続トークンを使用して結果を呼び出し元がページことができます。 **/users/me/inventory?continuationToken = continuationTokenString**します。

呼び出し元では、特定の項目に関する情報を表示するために API を特定の項目の URL の詳細への呼び出しをことがあります。

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| 使用可能状況]| string| 返される項目の現在の利用可否]。 既定では、「使用可能」の日付範囲の開始日と終了の間に、現在の日付で次が返す項目です。 その他の値を含める"All"、すべての項目と、現在の日付に項目を返す「利用不可」の外側開始日と終了の日付範囲や、したがって現在利用できませんが返されます。 |
| コンテナー| string| 省略可能。 ゲームの製品 ID を値を設定した場合、在庫から結果のみを含めるそのゲームに関連する項目。 これは、特定のゲームの製品の下の結果をフィルター処理するようにサーバーから、インベントリを呼び出すときに特に便利です。|
| expandSatisfyingEntitlements| string| 応答には、ユーザーが、結果内で返されるすべてのニーズを満たして権利が含まれて かどうかを示すフラグ。 既定値は"false"です。 このパラメーターは、値"true"、Xbox 360 の購入に移行するサブスクリプション特典では、Xbox One では、次のようにバンドルの権利の項目を満たすを使ってユーザーに付与されているすべての製品を使用する場合などが、結果に追加されます。 この値は"false"ときなど、バンドルの ProductID 親項目のみは結果に含まれている個々 の項目いない返されます。 **注:** URI に itemType パラメーターが含まれていない場合にのみサポートは、値を"true"のこのパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。 |  
  | productIds | string |  具体的には、ユーザーの在庫から取得する ProductIds のコレクションがで区切られた '、'。  ユーザーが指定した ProductID、インベントリの結果で、その項目は表示されません結果に API の呼び出しから。 True に、バンドルと共に expandSatisfyingEntitlements パラメーター セットの productID で渡す場合 (クエリ文字列で、productIds を指定したかどうか) かどうか、バンドルに含まれているすべての項目が呼び出しの結果に返されます。   |
  | 状態 | string | 返される項目の状態。 既定ではすべての項目を取得する"all"です。 その他の値は「有効」、だけその itemsthat が有効になっていることを示しますが返される、「一時停止」が中断されている項目のみを返すこと、"Expired"は、期限切れになった項目のみが返されることを示すを示す"取り消された項目のみする必要がありますが返され、"Renewed"ことを示しますが、更新された項目のみが返されることを示す"を取り消した場合、します。  |

これらは、に加えては、リソースは、標準のページングのしくみをサポートします。

<a id="ID4EDE"></a>


## <a name="sample-request"></a>要求の例

この URI メソッドの完全修飾ドメイン名します。 `https://inventory.xboxlive.com/users/me/inventory.
         `

> [!NOTE] 
> ユーザーと見なされるによって異なります、提供されたトークンが複数のユーザーを含めることができます。 1 人のユーザーのインベントリを設定する場合は、のみを検討する特定のユーザーのユーザーのハッシュを提供することもする必要があります。

.

<a id="ID4ERE"></a>


## <a name="response-body"></a>応答本文

呼び出しが成功した場合、サービスがインベントリ項目の配列を返します。 [InventoryItem (JSON)](../../json/json-inventoryitem.md)を参照してください。

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

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
