---
title: /handles/{handleId}/session
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
author: KevinAsgari
description: " /handles/{handleId}/session"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 38fa1ad62b2e76dceda79744c59eb59ddc50ea90
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7567851"
---
# <a name="handleshandleidsession"></a>/handles/{handleId}/session
PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用されます。  

 

> [!NOTE] 
> この URI は、現在 Xbox One 本体とサービスの識別子を使用してサーバーによって外部的にもアクセスのみです。  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | 
| ハンドル id を使用| GUID| セッション ハンドルの一意の ID。| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/handles/{handleId}/session)](uri-handleshandleidsessionget.md)

&nbsp;&nbsp;指定したハンドル識別子セッション オブジェクトを取得します。 

[PUT (/handles/{handle-id}/session)](uri-handleshandleidsessionput.md)

&nbsp;&nbsp;作成またはハンドルを逆参照によって、セッションを更新します。
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   