---
title: /handles/query
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
author: KevinAsgari
description: " /handles/query"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d4ce38768923f9adb2cdb8e2237e9afcb774433b
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5695161"
---
# <a name="handlesquery"></a>/handles/query
セッション ハンドルのクエリを作成する POST 操作をサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用する概念があることです。  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
この URI は、ハンドルのクエリをサポートします。 クエリ文字列とバッチであり、セッション クエリとは異なり、ハンドルのクエリはクエリ プロセッサ スタイルを使用します。 最大 100 ハンドルがサポートされています。  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
なし   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST (/handles/query)](uri-handlesquerypost.md)

&nbsp;&nbsp;セッション ハンドルに対するクエリを作成します。

[POST (/handles/query?include=relatedInfo)](uri-handlesqueryincludepost.md)

&nbsp;&nbsp;セッションの関連する情報が含まれているセッション ハンドルに対するクエリを作成します。
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   