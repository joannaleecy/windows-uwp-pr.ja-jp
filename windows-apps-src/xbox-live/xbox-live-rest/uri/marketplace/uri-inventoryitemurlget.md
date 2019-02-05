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
ms.sourcegitcommit: b975c8fc8cf0770dd73d8749733ae5636f2ee296
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9058483"
---
# <a name="get-inventoryitemid"></a>GET (/inventory/{itemID})
特定のインベントリ項目の詳細の完全なセットを提供します。 これらの Uri のドメインが`inventory.xboxlive.com`します。
 
  * [注釈](#ID4EX)
  * [URI パラメーター](#ID4EAB)
  * [応答本文](#ID4ELB)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a>注釈
 
ポリシー チェックを行わない、実施、またはこの呼び出しの一部としてフィルタ リングが発生します。
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| itemID| string| 単数形インベントリ項目の各ユーザーに一意の ID| 
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4ERB"></a>

 
### <a name="sample-response"></a>応答の例
 
認証に合格して、適切な承認コンテキストが割り当てられていると想定すると、GET 要求に応答は、項目のプロパティの完全なセットを 1 つのインベントリ項目です。
 

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

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   