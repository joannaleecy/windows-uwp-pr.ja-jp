---
title: POST ({itemID})
assetID: 2c3c166b-e638-cfb9-d68e-9f8ab9a838d3
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurlpost.html
description: " POST ({itemID})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 877986ce9d48269295a68dbfd644f14785916b88
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640857"
---
# <a name="post-itemid"></a>POST ({itemID})
または使用できるインベントリ項目の一部が使用されていることを示しますおよびデクリメントの要求の量で使用できる数量。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EQB)
  * [要求本文](#ID4E2B)
  * [応答本文](#ID4ENC)

<a id="ID4EX"></a>


## <a name="remarks"></a>注釈

   * 呼び出し元が使用するように求められる数量が、項目の残りの提供を超えている場合、呼び出しは拒否されます。
   * 呼び出し元が使用するように求められる数量は 0 より大きい正の整数である必要があります。 消費値は 0 以下の呼び出しは拒否されます。
   * 呼び出し元は、空のトランザクション ID を提供する場合は、要求は拒否されます。
   * 使用可能な場合は、消費量を報告するタイトルを特定することができるように、タイトルの要求が記録されます。
   * 一定の期間には、同じ transactionId の他の投稿が無視されます。


> [!NOTE]
> <b>X xbl コントラクト バージョン ヘッダー</b>この API は、「4」にします。


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| アイテム Id| string| 単数形のインベントリ項目のユーザーごとに一意の ID|

<a id="ID4E2B"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EBC"></a>


### <a name="sample-request"></a>要求のサンプル


```cpp
{
  "transactionId": String
  "removeQuantity": Int
}

```


削除の quantity フィールドを使用できる、消耗品の残りの数量から削除するの数量を示すために、呼び出し元を使用できます。 トランザクション ID フィールドには、同じ使用状況を 2 回カウントのリスクを制限しながら使用できるコンテンツの操作を使用して再試行するための手段を呼び出し元が提供します。

<a id="ID4ENC"></a>


## <a name="response-body"></a>応答本文

認証を渡し、適切な承認コンテキストが割り当てられていると仮定した場合、POST に対する応答は、POST 要求、使用できる項目の URL、および項目は新しいサービスに渡される、acknolodgement の同じ transactionId を含む受信数量の値。

<a id="ID4EVC"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
  "transactionId": String
  "url": String
  "newQuantity": Int
}

```


<a id="ID4E6C"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EBD"></a>


##### <a name="parent"></a>Parent

[/users/me/consumables/{itemID}](uri-inventoryconsumablesitemurl.md)


<a id="ID4ELD"></a>


##### <a name="further-information"></a>詳細情報

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
