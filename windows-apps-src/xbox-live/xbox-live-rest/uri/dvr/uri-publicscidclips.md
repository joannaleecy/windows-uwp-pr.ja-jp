---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " /public/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b7c0c664b7fdff7eae607acdc4dd7ef78aeb3caf
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4204239"
---
# <a name="publicscidsscidclips"></a>/public/scids/{scid}/clips
クリップをパブリックにアクセスします。 この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| パブリック クリップの主要なサービス構成の識別子です。| 
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

   