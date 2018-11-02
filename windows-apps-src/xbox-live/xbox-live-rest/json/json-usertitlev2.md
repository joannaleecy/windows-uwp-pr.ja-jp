---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
author: KevinAsgari
description: " UserTitle (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1735b7fcedd358c290b289b97417e0ea3a6c090b
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5920894"
---
# <a name="usertitle-json"></a>UserTitle (JSON)
ユーザーのタイトル データが含まれています。 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a>UserTitle
 
UserTitle オブジェクトには、次の仕様があります。 すべてのプロパティは、必要があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| lastUnlock| DateTime| 実績を獲得した最後の時刻。| 
| titleId| 32 ビットの符号なし整数| タイトルの一意の識別子。| 
| titleVersion| string| タイトルのバージョン。| 
| serviceConfigId| string| タイトルに関連付けられているプライマリ サービス構成のセットの ID です。| 
| タイトル| string| タイトルの種類。| 
| プラットフォーム| string| サポートされているプラットフォームです。| 
| name| string| このタイトルのテキストの名前。 最大長 22 です。| 
| earnedAchievements| 32 ビットの符号なし整数| 実績の数は、ロック解除した実績を含む、タイトルの獲得し、チャレンジを正常に完了しました。| 
| currentGamerscore| 32 ビットの符号なし整数| このユーザーがこのタイトルでの原因の合計ゲーマー スコア。| 
| maxGamerscore| 32 ビットの符号なし整数| このタイトルの合計の可能なゲーマー スコア。| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   