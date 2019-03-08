---
title: GET (/inventory/{itemID})
assetID: d3ca14a5-0214-ef42-091e-3f05f2a3482d
permalink: en-us/docs/xboxlive/rest/uri-inventoryitemurlget.html
description: " GET (/inventory/{itemID})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 446197eb20820304088ddac4a6379fa3b2510873
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606697"
---
# <a name="get-inventoryitemid"></a>GET (/inventory/{itemID})
特定のインベントリ項目の詳細情報の完全なセットを提供します。 これらの Uri のドメインが`inventory.xboxlive.com`します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EAB)
  * [応答本文](#ID4ELB)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ポリシー チェックを行わない、強制、または、この呼び出しの一部としてフィルター処理が発生します。
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| アイテム Id| string| 単数形のインベントリ項目のユーザーごとに一意の ID| 
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4ERB"></a>

 
### <a name="sample-response"></a>応答のサンプル
 
認証し、適切な承認コンテキストが割り当てられていると仮定すると、GET 要求に対する応答は、アイテムのプロパティの完全なセットを 1 つの在庫アイテムです。
 

```cpp
{inventoryItem}
         
```

   
<a id="ID4E4B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a>Parent 

[GET (/inventory/{itemID})](uri-inventoryget.md)

  
<a id="ID4EJC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   