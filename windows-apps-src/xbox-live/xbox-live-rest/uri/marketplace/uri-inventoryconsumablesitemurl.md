---
title: /users/me/consumables/{itemID}
assetID: 45724827-5e35-326f-3f17-f49e606d9e08
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurl.html
author: KevinAsgari
description: ユーザーの Xbox コンシューマブルの項目の rESTful エンドポイントです。
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7ed278542fa538a1297069b0f7d67d413e180f30
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615957"
---
# <a name="usersmeconsumablesitemid"></a>/users/me/consumables/{itemID}
特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。
これらの Uri のドメインが`inventory.xboxlive.com`します。

  * [URI パラメーター](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| itemID| string| 単一のインベントリ項目の各ユーザーに一意の ID|

<a id="ID4ERB"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST ({itemID})](uri-inventoryconsumablesitemurlpost.md)

&nbsp;&nbsp;または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント要求の量によって、コンシューマブルの数量。

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
