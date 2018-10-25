---
title: /json/users/xuid({xuid})/scids/{scid}/data/{path}
assetID: c2745955-5e52-ea2b-7389-cb85202e01c3
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapath.html
author: KevinAsgari
description: " /json/users/xuid({xuid})/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1ad40749e2ef4ab19ba8ef181f9f39c1196b4682
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5469186"
---
# <a name="jsonusersxuidxuidscidssciddatapath"></a>/json/users/xuid({xuid})/scids/{scid}/data/{path}
指定されたパスのファイル情報の一覧を示します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。| 
| scid| guid| ルックアップ サービス構成の ID です。| 
| path| string| 返されるデータ項目へのパス。 一致するすべてのディレクトリとサブディレクトリを取得する返されます。 有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。 空にすることがあります。 256 の最大の長さ。| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-jsonusersxuidscidssciddatapath-get.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   