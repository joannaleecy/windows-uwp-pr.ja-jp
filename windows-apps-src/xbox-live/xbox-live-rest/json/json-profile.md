---
title: Profile (JSON)
assetID: b92b1750-c2df-39b6-6c5c-f9e8068c8097
permalink: en-us/docs/xboxlive/rest/json-profile.html
author: KevinAsgari
description: " Profile (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ae5e95befc6611c5905e6efe2bb01a396167626
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4361093"
---
# <a name="profile-json"></a>Profile (JSON)
ユーザーの個人用プロファイル設定します。 
<a id="ID4EN"></a>

 
## <a name="profile"></a>プロファイル
 
プロファイル オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| AppDisplayName| string| アプリで表示するための名前です。 これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。 この設定は、アプリに表示するために使用するユーザーの id 文字列を表します。| 
| GameDisplayName| string| ゲームで表示するための名前です。 これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。 この設定は、ゲームで表示するために使用するユーザーの id 文字列を表します。| 
| Gamertag| string| ユーザーのゲーマータグです。| 
| AppDisplayPicRaw| string| アプリを直接表示 pic URL (下記参照)。| 
| GameDisplayPicRaw| string| 未加工のゲーム表示 pic URL (下記参照)。| 
| AccountTier| string| ユーザーには、アカウントの種類はありますか。 ゴールド、シルバー、または FamilyGold かどうか。| 
| TenureLevel| 32 ビット符号なし整数| 数年間ユーザーされた Xbox Live を使用しますか。| 
| ゲーマースコア| 32 ビット符号なし整数| ユーザーのゲーマー スコア。| 
  


> [!NOTE] 
> 画像は、ユーザーの '実際の図' またはプライバシーに応じて、XboxOne ゲーマー アイコンであることができます。 これらの設定では、クライアント上に表示するために使用するユーザーの画像の url を表します。 この画像は、(ユーザーが任意の画像を設定していないことを示す) が空にする場合があります。 


 
生の URL は、サイズ変更できる URL です。 サイズし、形式の追加を使用して、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`をその URI:
 
形式: png
 
サイズ: 64 x 64、208 x 208、424 x 424
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)

   