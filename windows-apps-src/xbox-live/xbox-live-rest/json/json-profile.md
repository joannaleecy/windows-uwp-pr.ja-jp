---
title: Profile (JSON)
assetID: b92b1750-c2df-39b6-6c5c-f9e8068c8097
permalink: en-us/docs/xboxlive/rest/json-profile.html
description: " Profile (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7299fcb4d375a3fc35ad67306b70f5fa4afde963
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607517"
---
# <a name="profile-json"></a>Profile (JSON)
ユーザーの個人プロファイルの設定。 
<a id="ID4EN"></a>

 
## <a name="profile"></a>Profile
 
プロファイル オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| AppDisplayName| string| アプリで表示するための名前。 ユーザーの「実際の名前」またはプライバシーによってそのゲーマータグことが考えられます。 この設定は、アプリでの表示に使用するユーザーの id 文字列を表します。| 
| GameDisplayName| string| ゲームで表示するための名前。 ユーザーの「実際の名前」またはプライバシーによってそのゲーマータグことが考えられます。 この設定は、ゲームでの表示に使用するユーザーの id 文字列を表します。| 
| Gamertag| string| ユーザーのゲーマータグです。| 
| AppDisplayPicRaw| string| 未加工のアプリ表示 pic URL (下記参照)。| 
| GameDisplayPicRaw| string| 未処理のゲーム表示 pic URL (下記参照)。| 
| AccountTier| string| ユーザーには、アカウントの種類はありますか。 Gold、Silver、または FamilyGold でしょうか。| 
| TenureLevel| 32 ビット符号なし整数| 数年の Xbox Live、ユーザーがでしたか。| 
| ゲーマースコア| 32 ビット符号なし整数| ユーザーのゲーマーします。| 
  


> [!NOTE] 
> 画像には、ユーザーの '実際の画像' またはプライバシーによってその XboxOne gamerpic を指定できます。 これらの設定は、クライアントの表示に使用するユーザーの画像の url を表します。 このイメージは、(ユーザーが任意の画像を設定していないことを示す) が空にすることがあります。 


 
生の URL は、サイズ変更可能な URL です。 サイズし、形式を使用して追加することで、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`uri:
 
形式: png
 
サイズ:64 x 64、208 x 208、424 x 424
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

   