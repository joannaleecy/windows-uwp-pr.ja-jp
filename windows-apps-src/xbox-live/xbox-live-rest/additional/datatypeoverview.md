---
title: データ型の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
author: KevinAsgari
description: " データ型の概要"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9340f4adb83932ef2c48aba271367e7faab645c3
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4315035"
---
# <a name="data-type-overview"></a>データ型の概要
 
Xbox Live サービスは、さまざまな id と認証に関連するデータ型を使用します。 このトピックでは、それらの型の概要を示します。
 
| 種類| 説明| 
| --- | --- | 
| ゲーマータグ| ユーザーの人間が判読できる一意の画面の名前。| 
| プレイヤー| ユーザーの XUID と、セッションおよびカスタム データの小さな blob で、プレイヤーがまだ参加しているかどうか、セッション (または「シート」)、プレイヤーのインデックスを適切にゲーマータグを含む JSON オブジェクト。| 
| profile| ユーザー プロファイルの URI アドレスと、ユーザーのユーザーでは通常の HTTP メソッドを使用してアクセスが、ゲーマー、ゲーマータグ、XUID などの可能性もなどについて説明します。| 
| 設定| ユーザー オブジェクトのタイトルに固有の設定のいずれか。| 
| UserClaims| ユーザーの XUID とゲーマータグを含むシンプルな JSON オブジェクト。| 
| ユーザー| タイトルに固有の設定、または現在の認証されたユーザーの基本設定のコレクションを含む JSON オブジェクト。 ユーザーは、ゲーム内のアクティビティに関連する可能性があります、任意のデータを含めることができます。| 
| XUID| ユーザーの Xbox ユーザー ID、ユニークな署名されていない長の整数です。 判読するものではありません。| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a>参照[プレイヤー (JSON)](../json/json-player.md)

 [UserClaims (JSON)](../json/json-userclaims.md)

 [UserSettings (JSON)](../json/json-usersettings.md)

   