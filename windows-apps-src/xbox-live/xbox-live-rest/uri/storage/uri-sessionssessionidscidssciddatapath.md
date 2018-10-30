---
title: /sessions/{sessionId}/scids/{scid}/data/{path}
assetID: 932459b4-24b4-5b09-8146-ed214de0083a
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapath.html
author: KevinAsgari
description: " /sessions/{sessionId}/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 52f0e12347f4a314f8e3b925ca3ba6bb2291da63
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5755356"
---
# <a name="sessionssessionidscidssciddatapath"></a>/sessions/{sessionId}/scids/{scid}/data/{path}
指定されたパスのファイル情報の一覧を示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| sessionId| string| 検索するセッションの ID。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| path| string| 返されるデータ項目へのパス。 一致するすべてのディレクトリとサブディレクトリを取得する返されます。 有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。 空にすることがあります。 256 の最大の長さ。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-sessionssessionidscidssciddatapath-get.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   