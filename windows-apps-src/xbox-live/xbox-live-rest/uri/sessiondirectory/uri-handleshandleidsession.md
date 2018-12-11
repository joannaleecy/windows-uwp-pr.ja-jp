---
title: /handles/{handleId}/session
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
description: " /handles/{handleId}/session"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e7b6990917437c22dd4d9282492e2a0eab37893b
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8899245"
---
# <a name="handleshandleidsession"></a>/handles/{handleId}/session
PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用されます。  

 

> [!NOTE] 
> この URI は、現在 Xbox One 本体とサーバーのサービスの識別子を使用してアクセスできる外部のみです。  

 
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

   