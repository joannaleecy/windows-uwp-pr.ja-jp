---
title: GET (/inventory/{itemID})
assetID: d3ca14a5-0214-ef42-091e-3f05f2a3482d
permalink: en-us/docs/xboxlive/rest/uri-inventoryitemurlget.html
author: KevinAsgari
description: " GET (/inventory/{itemID})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4a94493243178a503ae846608b172af598bf97dd
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3988818"
---
# <a name="get-inventoryitemid"></a>GET (/inventory/{itemID})
特定のインベントリ項目の詳細の完全なセットを提供します。 これらの Uri のドメインが`inventory.xboxlive.com`します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EAB)
  * [応答本文](#ID4ELB)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ポリシー チェックなし、実施、またはフィルタ リングがこの呼び出しの一部として行われます。
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| itemID| string| 単数形インベントリ項目の各ユーザーに一意の ID| 
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4ERB"></a>

 
### <a name="sample-response"></a>応答の例
 
認証に合格して、適切な承認コンテキストが割り当てられていると仮定すると、GET 要求に応答は、項目のプロパティの完全なセットを 1 つのインベントリ項目です。
 

```cpp
{inventoryItem}
         
```

   
<a id="ID4E4B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a>Parent 

[GET (/inventory/{itemID})]()

  
<a id="ID4EJC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   