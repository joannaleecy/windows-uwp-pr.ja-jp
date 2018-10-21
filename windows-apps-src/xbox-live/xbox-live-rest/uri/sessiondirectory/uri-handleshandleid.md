---
title: /handles/{handleId}
assetID: 5b722d3e-fe80-fec5-a26b-8b3db6422004
permalink: en-us/docs/xboxlive/rest/uri-handleshandleid.html
author: KevinAsgari
description: " /handles/{handleId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47dda291a9a86ccbee69e1e51ca71be373f5dc1d
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5170708"
---
# <a name="handleshandleid"></a>/handles/{handleId}
識別子により指定されたセッション ハンドルを削除または取得の操作をサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、および後でそのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用されます。  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| ハンドル id を使用| GUID| セッションのハンドルを一意の ID。| 
  
<a id="ID4ERB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE (/handles/{handleId})](uri-handleshandleiddelete.md)

&nbsp;&nbsp;ハンドル ID で指定されたハンドルを削除します。

[GET (/handles/{handle-id})](uri-handleshandleidget.md)

&nbsp;&nbsp;ハンドル ID で指定されたハンドルを取得します。
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   