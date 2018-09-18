---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
author: KevinAsgari
description: " UserTitle (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 068ae15566d73dfc4610f8540972b7e80329de8e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4014859"
---
# <a name="usertitle-json"></a>UserTitle (JSON)
タイトルのユーザー データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a>ユーザー タイトル
 
ユーザー タイトル オブジェクトでは、次の仕様があります。 すべてのプロパティは、必要があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| lastUnlock| DateTime| 実績が最後に獲得した時刻。| 
| titleId| 32 ビット符号なし整数| タイトルの一意の識別子。| 
| titleVersion| string| タイトルのバージョンです。| 
| serviceConfigId| string| タイトルに関連付けられているプライマリ サービス構成のセットの ID です。| 
| タイトル| string| タイトルの種類。| 
| プラットフォーム| string| サポートされているプラットフォームです。| 
| name| string| このタイトルのテキストの名前。 最大長 22 です。| 
| earnedAchievements| 32 ビット符号なし整数| 実績の数は、ロック解除した実績を含む、タイトルの獲得し、課題が正常に完了します。| 
| currentGamerscore| 32 ビット符号なし整数| このユーザーがこのタイトルでの原因の合計ゲーマー スコア。| 
| maxGamerscore| 32 ビット符号なし整数| このタイトルの合計の考えられるゲーマー スコア。| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   