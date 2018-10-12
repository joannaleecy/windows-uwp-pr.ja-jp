---
title: /users/xuid({xuid})/history/titles
assetID: 2f8eb79a-42c2-0267-cbf2-8682bb28f270
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesv2.html
author: KevinAsgari
description: " /users/xuid({xuid})/history/titles"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a4780c92fc16adb697783ecee50d36523ff92998
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4563549"
---
# <a name="usersxuidxuidhistorytitles"></a>/users/xuid({xuid})/history/titles
 
このユニバーサル リソース識別子 (URI) は、ユーザーの実績に関連するタイトル履歴へのアクセスを提供します。
 
これらの Uri のドメインが`achievements.xboxlive.com`します。
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) がタイトル履歴にアクセスしているユーザー。| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-titlehistoryusersxuidhistorytitlesgetv2.md)

&nbsp;&nbsp;タイトルは、ユーザーがロックを解除またはに対するその実績の進行状況の一覧を取得します。 この API では、タイトルのプレイまたは起動のユーザーのすべての履歴は返されません。
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a>Parent 

[実績タイトル履歴 URI](atoc-reference-titlehistoryv2.md)

   