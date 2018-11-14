---
title: データ型の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
author: KevinAsgari
description: " データ型の概要"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8129be6220dc6c9ae1d125087fee52ca17d33424
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6442346"
---
# <a name="data-type-overview"></a>データ型の概要
 
Xbox Live サービスは、さまざまな id と認証に関連するデータ型を使用します。 このトピックでは、それらの型の概要を示します。
 
| 種類| 説明| 
| --- | --- | 
| ゲーマータグ| ユーザーの人間が判読できる一意の画面の名前。| 
| プレイヤー| ユーザーの XUID とゲーマータグと同じようプレイヤーのインデックス、セッション (または「シート」) で、セッションおよびカスタム データの小さな blob で、プレイヤーがまだ参加しているかどうかを含む JSON オブジェクト。| 
| profile| ユーザー プロファイルの URI アドレスと HTTP メソッドでは、通常、ユーザーの UserSettings、を通じてアクセスが、ゲーマー カード、ゲーマータグ、XUID などの可能性もなどに関する情報。| 
| 設定| UserSettings オブジェクトでタイトルに固有の設定のいずれか。| 
| UserClaims| ユーザーの XUID とゲーマータグを含むシンプルな JSON オブジェクト。| 
| UserSettings| タイトルに固有の設定や、現在の認証されたユーザーの基本設定のコレクションを含む JSON オブジェクト。 UserSettings には、ゲーム内のアクティビティに関連する可能性があります、任意のデータを含めることができます。| 
| XUID| ユーザーの Xbox ユーザー ID、ユニークな署名されていない長の整数です。 人間が判読できるものはありません。| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a>参照[Player (JSON)](../json/json-player.md)

 [UserClaims (JSON)](../json/json-userclaims.md)

 [UserSettings (JSON)](../json/json-usersettings.md)

   