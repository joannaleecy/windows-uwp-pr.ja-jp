---
title: ハンドル/クエリ
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
author: KevinAsgari
description: " ハンドル/クエリ"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fbb8a823581f357e42cd13bb1331808584301f5e
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3956437"
---
# <a name="handlesquery"></a>ハンドル/クエリ
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

[POST (ハンドル/クエリ)](uri-handlesquerypost.md)

&nbsp;&nbsp;セッション ハンドルに対するクエリを作成します。

[POST (ハンドル/クエリかどうか含める relatedInfo =)。](uri-handlesqueryincludepost.md)

&nbsp;&nbsp;関連するセッションの情報が含まれるセッション ハンドルに対するクエリを作成します。
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ Uri](atoc-reference-sessiondirectory.md)

   