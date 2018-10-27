---
title: /users/me/consumables/{itemID}
assetID: 45724827-5e35-326f-3f17-f49e606d9e08
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurl.html
author: KevinAsgari
description: ユーザーの Xbox コンシューマブルの項目の rESTful エンドポイントです。
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bbdf869cffae575f53555b31d9ed66647d3d09b2
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5683250"
---
# <a name="usersmeconsumablesitemid"></a>/users/me/consumables/{itemID}
特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [URI パラメーター](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| itemID| string| 単数形インベントリ項目の各ユーザーに一意の ID|

<a id="ID4ERB"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST ({itemID})](uri-inventoryconsumablesitemurlpost.md)

&nbsp;&nbsp;または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント、要求された時間の長さによって、コンシューマブルの数量。

<a id="ID4E4B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E6B"></a>


##### <a name="parent"></a>Parent

[マーケットプレース URI](atoc-reference-marketplace.md)


<a id="ID4EJC"></a>


##### <a name="further-information"></a>詳細情報

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)
