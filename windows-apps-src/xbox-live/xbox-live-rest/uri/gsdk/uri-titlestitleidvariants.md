---
title: /titles/{titleId}/variants
assetID: bca30c8f-1f09-729f-4955-38b7809404eb
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants.html
author: KevinAsgari
description: " /titles/{titleId}/variants"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 82b44cfab560cc7954ace22d703b0fba87883f91
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5860638"
---
# <a name="titlestitleidvariants"></a>/titles/{titleId}/variants
URI は、タイトルの利用可能な言語バリアントを取得するクライアントによって呼び出されます。 これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EU)
  * [ホスト名](#ID4EIB)
  * [有効なメソッド](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| タイトル id| 要求の操作のタイトルの ID です。| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a>ホスト名
 
gameserverds.xboxlive.com
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a>有効なメソッド
  
[POST](uri-titlestitleidvariants-post.md)
 
&nbsp;&nbsp;指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URI
   