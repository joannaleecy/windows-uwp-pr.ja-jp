---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
description: " UserTitle (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 33901a5bde25fd17072c2b45d587a33209424378
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623027"
---
# <a name="usertitle-json"></a>UserTitle (JSON)
ユーザーのタイトルのデータが含まれています。 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a>ユーザー タイトル
 
ユーザー タイトル オブジェクトには、次の仕様があります。 すべてのプロパティが必要です。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| lastUnlock| DateTime| アチーブメントが獲得された最終時刻。| 
| titleId| 32 ビット符号なし整数| タイトルの一意の識別子。| 
| titleVersion| string| タイトルのバージョン。| 
| serviceConfigId| string| タイトルに関連付けられているプライマリ サービスの構成セットの ID。| 
| タイトル| string| タイトルの種類。| 
| プラットフォーム| string| サポートされているプラットフォーム。| 
| name| string| このタイトルのテキストの名前。 最大長 22 です。| 
| earnedAchievements| 32 ビット符号なし整数| アチーブメントの数は、タイトルなどのロック解除のアチーブメントの獲得し、課題を正常に完了しました。| 
| currentGamerscore| 32 ビット符号なし整数| 合計のゲーマーこのタイトルでこのユーザーを獲得しました。| 
| maxGamerscore| 32 ビット符号なし整数| このタイトルの可能な合計ゲーマーします。| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   