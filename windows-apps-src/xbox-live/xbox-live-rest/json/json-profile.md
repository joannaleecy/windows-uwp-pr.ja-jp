---
title: Profile (JSON)
assetID: b92b1750-c2df-39b6-6c5c-f9e8068c8097
permalink: en-us/docs/xboxlive/rest/json-profile.html
author: KevinAsgari
description: " Profile (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 444f765101c1067b6a13125099040c64197848e4
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5744598"
---
# <a name="profile-json"></a>Profile (JSON)
ユーザーの個人用プロファイル設定します。 
<a id="ID4EN"></a>

 
## <a name="profile"></a>プロファイル
 
プロファイル オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| AppDisplayName| string| アプリで表示するための名前です。 これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。 この設定は、アプリに表示するために使用するユーザーの id 文字列を表します。| 
| GameDisplayName| string| ゲームで表示するための名前です。 これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。 この設定は、ゲームに表示するために使用するユーザーの id 文字列を表します。| 
| Gamertag| string| ユーザーのゲーマータグです。| 
| AppDisplayPicRaw| string| アプリを直接表示 pic URL (下記参照)。| 
| GameDisplayPicRaw| string| 未加工のゲーム表示 pic URL (下記参照)。| 
| AccountTier| string| ユーザーには、アカウントの種類はありますか。 ゴールド、シルバー、または FamilyGold かどうか。| 
| TenureLevel| 32 ビットの符号なし整数| 数年間ユーザーされた Xbox Live を使用しますか。| 
| ゲーマースコア| 32 ビットの符号なし整数| ユーザーのゲーマー スコア。| 
  


> [!NOTE] 
> 画像は、ユーザーの '実際の図' またはプライバシーに応じて、XboxOne ゲーマー アイコンであることができます。 これらの設定では、クライアント上に表示するために使用するユーザーの画像の url を表します。 この画像は、(ユーザーが任意の画像を設定していないことを示す) が空にする可能性があります。 


 
生の URL は、サイズ変更できる URL です。 サイズし、形式を追加して、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`をその URI:
 
形式: ピクセルの .png ファイル
 
サイズ: 64 x 64、208 x 208、424 x 424
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   