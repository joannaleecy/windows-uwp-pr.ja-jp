---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " /public/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 131a1eb67d4a33c3fbd2f5f818499ffeea851f3d
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6191181"
---
# <a name="publicscidsscidclips"></a>/public/scids/{scid}/clips
クリップをパブリックにアクセスします。 この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| パブリック クリップをプライマリー サービス構成の識別子です。| 
| タイトル id| string| パブリック クリップのタイトル Id。 SCID と同じ URI で指定することはできません。 指定した場合はプライマリー SCID を検索するために使用されます。| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/public/scids/{scid}/clips)](uri-publicscidclipsget.md)

&nbsp;&nbsp;パブリック クリップを一覧表示します。
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](../marketplace/atoc-reference-marketplace.md)

   