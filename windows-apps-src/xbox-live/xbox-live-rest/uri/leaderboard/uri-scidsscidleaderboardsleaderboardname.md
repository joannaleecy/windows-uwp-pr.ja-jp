---
title: /scids/{scid}/leaderboards/{leaderboardname}
assetID: 16345a17-6025-5453-5694-eaf97f0e83e9
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardname.html
description: " /scids/{scid}/leaderboards/{leaderboardname}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b73ffc2d6d6b80159651a90aabbf5595b146560d
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337676"
---
# <a name="scidsscidleaderboardsleaderboardname"></a>/scids/{scid}/leaderboards/{leaderboardname}
定義済みグローバル ランキングにアクセスします。 これらの Uri のドメインが`leaderboards.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。| 
| leaderboardname| string| アクセス対象の定義済みのランキング リソースの一意の識別子。| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-scidsscidleaderboardsleaderboardnameget.md)

&nbsp;&nbsp;&nbsp;&nbsp;定義済みグローバル ランキングを取得します。


[値のメタデータを取得します。](uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.md)

&nbsp;&nbsp;&nbsp;&nbsp;ランキングの値に関連付けられたメタデータと共に定義済みグローバル ランキングを取得します。

 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a>Parent 

[ランキング URI](atoc-reference-leaderboard.md)

   