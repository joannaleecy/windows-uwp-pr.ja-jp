---
title: /handles/{handleId}
assetID: 5b722d3e-fe80-fec5-a26b-8b3db6422004
permalink: en-us/docs/xboxlive/rest/uri-handleshandleid.html
description: " /handles/{handleId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a312d3744e96755a899d73307a47c01e3dc79fd
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8945101"
---
# <a name="handleshandleid"></a>/handles/{handleId}
識別子により指定されたセッション ハンドルの削除と取得の操作をサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用されます。  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | 
| ハンドル id を使用| GUID| セッション ハンドルの一意の ID。| 
  
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

   