---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
description: " /public/scids/{scid}/clips"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: db279d546780ed40158894f73ecb84687ef35ba6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627977"
---
# <a name="publicscidsscidclips"></a>/public/scids/{scid}/clips
クリップをパブリックにアクセスします。 この URI 実際に指定できます 2 つの形式で`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。 詳しくは、後のセクションをご覧ください。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [URI パラメーター](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| string| パブリックのクリップをプライマリ サービスの構成の識別子です。| 
| タイトル id| string| パブリックのクリップのタイトル Id。 同じ URI、SCID としてでは指定できません。 指定した場合は、プライマリ SCID 検索に使用されます。| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/public/scids/{scid}/clips)](uri-publicscidclipsget.md)

&nbsp;&nbsp;パブリックのクリップを一覧表示します。
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace の Uri](../marketplace/atoc-reference-marketplace.md)

   