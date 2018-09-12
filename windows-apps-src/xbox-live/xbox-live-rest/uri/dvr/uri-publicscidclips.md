---
title: パブリック///} クリップ/
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " パブリック///} クリップ/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b7c0c664b7fdff7eae607acdc4dd7ef78aeb3caf
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881491"
---
# <a name="publicscidsscidclips"></a>パブリック///} クリップ/
クリップのパブリック アクセスします。 この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| パブリック クリップのプライマリ サービス構成 id。| 
| タイトル id| string| パブリック クリップのタイトル Id。 SCID と同じ URI で指定することはできません。 指定した場合はプライマリー SCID を検索するために使用されます。| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (パブリック///} クリップ/)](uri-publicscidclipsget.md)

&nbsp;&nbsp;パブリック クリップを一覧表示します。
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace Uri](../marketplace/atoc-reference-marketplace.md)

   