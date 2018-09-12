---
title: POST ({itemID})
assetID: 2c3c166b-e638-cfb9-d68e-9f8ab9a838d3
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurlpost.html
author: KevinAsgari
description: " POST ({itemID})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 910e2e46725c8628d6984983c808bf5fc9937f9f
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931253"
---
# <a name="post-itemid"></a>POST ({itemID})
または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント コンシューマブルを要求した量の数量。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EQB)
  * [要求本文](#ID4E2B)
  * [応答本文](#ID4ENC)

<a id="ID4EX"></a>


## <a name="remarks"></a>注釈

   * 数量を利用するよう求め、呼び出し元では、項目の残りの電源を超えている場合は、呼び出しが拒否されます。
   * 呼び出し元が利用するよう求め数量は 0 上の正の整数である必要があります。 消費量の値を 0 または小さい呼び出しが拒否されます。
   * 呼び出し元では、空のトランザクション ID を提供する場合は、要求が拒否されます。
   * 利用可能な場合は、どのタイトルによって報告されている使用量を決定することができるようにタイトル クレームが記録されます。
   * 同じ transactionId とその他の投稿は、いくつかの期間は無視されます。


> [!NOTE]
> この API の<b>x xbl コントラクト バージョン ヘッダー</b>は「4」です。


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- | --- |
| itemID| string| 単数形インベントリ項目の各ユーザーに一意の ID|

<a id="ID4E2B"></a>


## <a name="request-body"></a>要求本文

<a id="ID4EBC"></a>


### <a name="sample-request"></a>要求の例


```cpp
{
  "transactionId": String
  "removeQuantity": Int
}

```


削除の数量フィールドには、コンシューマブルの残りの数量から削除するコンシューマブルの数量を示すために、呼び出し元ことができます。 トランザクション ID] フィールドでは、同じの使用状況を 2 回にカウントのリスクを軽減しながらコンシューマブルなコンテンツの操作を使用して再試行する手段を呼び出し元を提供します。

<a id="ID4ENC"></a>


## <a name="response-body"></a>応答本文

認証に合格して適切な承認コンテキストが割り当てられていると想定すると、POST への応答は、POST 要求、コンシューマブルの項目の URL、および項目は新しいでサービスに渡すことと同じ transactionId 受領通知の acknolodgement数量の値。

<a id="ID4EVC"></a>


### <a name="sample-response"></a>応答の例


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

[ユーザー/me/コンシューマブル/{itemID}](uri-inventoryconsumablesitemurl.md)


<a id="ID4ELD"></a>


##### <a name="further-information"></a>詳細情報

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
