---
title: /users/xuid({xuid})/scids/{scid}/stats
assetID: 3cf9ffd4-9a8b-2658-402b-2e933f7f6f1b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstats.html
description: " /users/xuid({xuid})/scids/{scid}/stats"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 53a6c7bb0e7390b024b01e221d8061316a80509e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650417"
---
# <a name="usersxuidxuidscidsscidstats"></a>/users/xuid({xuid})/scids/{scid}/stats
サービス構成を指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープにアクセスします。 これらの Uri のドメインが`userstats.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| GUID| Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。| 
| scid| GUID| アクセスされるリソースを含むサービス構成の識別子です。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得](uri-usersxuidscidsscidstatsget.md)

&nbsp;&nbsp;指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープ サービス構成を取得します。

[値のメタデータを取得します。](uri-usersxuidscidsscidstatsgetvaluemetadata.md)

&nbsp;&nbsp;指定したサービス構成内のユーザーに対して、統計情報の値に関連付けられているメタデータを含む、指定した統計情報の一覧を取得します。
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a>Parent 

[ユーザーの統計情報の Uri](atoc-reference-userstats.md)

   