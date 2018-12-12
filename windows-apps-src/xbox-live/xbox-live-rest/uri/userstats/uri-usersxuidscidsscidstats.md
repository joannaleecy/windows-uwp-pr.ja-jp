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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8933277"
---
# <a name="usersxuidxuidscidsscidstats"></a>/users/xuid({xuid})/scids/{scid}/stats
スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストでサービス構成にアクセスします。 これらの Uri のドメインが`userstats.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| GUID| Xbox ユーザー ID (XUID) がに代わってサービス構成にアクセスするユーザーのします。| 
| scid| GUID| アクセス対象のリソースが含まれているサービス構成の識別子です。| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET](uri-usersxuidscidsscidstatsget.md)

&nbsp;&nbsp;スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストでサービス構成を取得します。

[値のメタデータを取得します。](uri-usersxuidscidsscidstatsgetvaluemetadata.md)

&nbsp;&nbsp;指定されたサービス構成でのユーザーに対して、統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a>Parent 

[ユーザー統計 URI](atoc-reference-userstats.md)

   