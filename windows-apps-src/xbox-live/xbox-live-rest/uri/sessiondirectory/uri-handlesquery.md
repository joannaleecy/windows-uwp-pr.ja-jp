---
title: /handles/query
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
author: KevinAsgari
description: " /handles/query"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fbb8a823581f357e42cd13bb1331808584301f5e
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5432496"
---
# <a name="handlesquery"></a>/handles/query
セッション ハンドルのクエリを作成する POST 操作をサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーで使用され、および後でそのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用されます。  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
この URI は、ハンドルのクエリをサポートします。 セッションのクエリ文字列とバッチのクエリであるとは異なり、ハンドルのクエリはクエリ プロセッサ スタイルを使用します。 最大 100 ハンドルがサポートされています。  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
なし   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST (/handles/query)](uri-handlesquerypost.md)

&nbsp;&nbsp;セッション ハンドルに対するクエリを作成します。

[POST (/handles/query?include=relatedInfo)](uri-handlesqueryincludepost.md)

&nbsp;&nbsp;関連するセッションの情報が含まれるセッション ハンドルに対するクエリを作成します。
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   