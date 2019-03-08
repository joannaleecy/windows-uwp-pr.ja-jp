---
title: データ型の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
description: " データ型の概要"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 62932a921d51a988a5533d7ee08f4968bb67a29d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659657"
---
# <a name="data-type-overview"></a>データ型の概要
 
Xbox Live サービスには、さまざまな id と認証に関連するデータ型が使用されます。 このトピックでは、これらの種類の概要を示します。
 
| 種類| 説明| 
| --- | --- | 
| ゲーマータグ| ユーザーの一意な人間が判読できる画面名。| 
| プレイヤー| ユーザーの XUID とゲーマータグ、だけでなく、プレイヤーのインデックス、セッション (または「座席」) で、プレーヤーが、セッション、およびカスタム データの小さな blob にまだ参加しているかどうかを含む JSON オブジェクト。| 
| プロファイル| ユーザーはプロファイルの URI アドレスと、ユーザーのユーザーは、通常の HTTP メソッドを使用してアクセス ゲーマー、ゲーマータグ、XUID、具合のもおそらくなどに関する情報。| 
| 設定| UserSettings オブジェクトのタイトルに固有の設定の 1 つ。| 
| UserClaims| ユーザーの XUID とゲーマータグを含む単純な JSON オブジェクト。| 
| UserSettings| タイトルに固有の設定や現在の認証済みユーザーの設定のコレクションを含む JSON オブジェクト。 ユーザーは、ゲーム内のアクティビティに関連する可能性がある任意のデータを含めることができます。| 
| XUID| ユーザーの Xbox ユーザー ID、一意の符号なし long 整数。 人間が判読できるものではありません。| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a>参照[Player (JSON)](../json/json-player.md)

 [UserClaims (JSON)](../json/json-userclaims.md)

 [UserSettings (JSON)](../json/json-usersettings.md)

   