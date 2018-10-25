---
title: /users/{userId}/profile/settings/people/{userList}?settings={settings}
assetID: 0ba20eba-f0ab-28ab-61d3-b4f9e4c07bc5
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlist.html
author: KevinAsgari
description: " /users/{userId}/profile/settings/people/{userList}?settings={settings}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 44341b5fc8f831e3a500f47a51b94978f587cb8c
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5473173"
---
# <a name="usersuseridprofilesettingspeopleuserlistsettingssettings"></a>/users/{userId}/profile/settings/people/{userList}?settings={settings}
ユーザーのプロファイルへのアクセスや、ユーザー, People モニカーをサポートします。 これらの Uri のドメインが`profile.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| ユーザー Id| string| 'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。| 
| userList| string| 名前付きの設定を取得するユーザーの一覧。 現時点では、ユーザーは、サポートされている唯一の一覧を示します。| 
  
<a id="ID4E1B"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{userId}/profile/settings/people/{userList})](uri-usersuseridprofilesettingspeopleuserlistget.md)

&nbsp;&nbsp;ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。
 
<a id="ID4EEC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a>Parent 

[プロフィール URI](atoc-reference-profiles.md)

 [Profile (JSON)](../../json/json-profile.md)

   