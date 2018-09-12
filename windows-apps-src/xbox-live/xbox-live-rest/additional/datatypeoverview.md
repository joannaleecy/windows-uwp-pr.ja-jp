---
title: データの種類の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
author: KevinAsgari
description: " データの種類の概要"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9340f4adb83932ef2c48aba271367e7faab645c3
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881492"
---
# <a name="data-type-overview"></a>データの種類の概要
 
Xbox Live サービスは、さまざまな id と認証に関連するデータ型を使用します。 このトピックでは、それらの型の概要を示します。
 
| 種類| 説明| 
| --- | --- | 
| ゲーマータグ| ユーザー、人間が判読できる一意の画面の名前。| 
| プレイヤー| ユーザーの XUID と、プレイヤーがまだセッションとカスタム データの小さな blob に参加しているかどうか、セッション (または「シート」) で、プレイヤーのインデックスを適切にゲーマータグを含む JSON オブジェクト。| 
| profile| ユーザー プロファイルの URI アドレスと、ユーザーのユーザーでは通常、HTTP メソッドを使用してアクセスが、ゲーマー カード、ゲーマータグ、XUID などの可能性もなどに関する情報。| 
| 設定| ユーザー オブジェクトの場合、タイトルに固有の設定のいずれか。| 
| UserClaims| ユーザーの XUID とゲーマータグを含むシンプルな JSON オブジェクト。| 
| ユーザー| タイトルに固有の設定、または現在の認証されたユーザーの基本設定のコレクションを含む JSON オブジェクト。 ユーザーは、ゲーム内のアクティビティに関連する可能性がある任意のデータを含めることができます。| 
| XUID| ユーザーの Xbox ユーザー ID、一意の長い符号なし整数。 人間が判読できるものではありません。| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a>参照[プレイヤー (JSON)](../json/json-player.md)

 [UserClaims (JSON)](../json/json-userclaims.md)

 [ユーザー (JSON)](../json/json-usersettings.md)

   