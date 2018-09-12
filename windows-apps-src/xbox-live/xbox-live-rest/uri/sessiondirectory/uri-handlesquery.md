---
title: /ハンドル/クエリ
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
author: KevinAsgari
description: " /ハンドル/クエリ"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fbb8a823581f357e42cd13bb1331808584301f5e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881802"
---
# <a name="handlesquery"></a>/ハンドル/クエリ
セッション ハンドルのクエリを作成する POST 操作をサポートしています。 

> [!NOTE] 
> この URI は、2015年マルチプレイヤーでは使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。 テンプレート コントラクト 104/105 以降で使用して設計されています。  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
この URI は、ハンドルのクエリをサポートしています。 クエリ文字列とバッチであり、セッションのクエリとは異なり、ハンドルのクエリはクエリ プロセッサ スタイルを使用します。 最大 100 ハンドルがサポートされています。  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
なし   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[POST (/ハンドル/クエリ)](uri-handlesquerypost.md)

&nbsp;&nbsp;セッション ハンドルのクエリを作成します。

[POST (/ハンドル/クエリかどうか含める relatedInfo =)。](uri-handlesqueryincludepost.md)

&nbsp;&nbsp;関連するセッション情報を含むセッション ハンドルのクエリを作成します。
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ Uri](atoc-reference-sessiondirectory.md)

   