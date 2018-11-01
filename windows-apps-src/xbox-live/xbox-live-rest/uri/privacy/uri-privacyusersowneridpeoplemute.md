---
title: /users/{ownerId}/people/mute
assetID: efb929d8-79a7-83f0-c348-c92ced42bc05
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemute.html
author: KevinAsgari
description: " /users/{ownerId}/people/mute"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 569aa173a0074fd147092716b9a36d53acaef0db
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5875647"
---
# <a name="usersowneridpeoplemute"></a>/users/{ownerId}/people/mute
ユーザーのミュート リストにアクセスします。

  * [URI パラメーター](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 そのリソースにアクセスしているユーザーの識別子です。 設定可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。 認証されたユーザーである必要があります。 値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。 最大サイズ: なし。 |

<a id="ID4ETB"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/people/mute)](uri-privacyusersowneridpeoplemuteget.md)

&nbsp;&nbsp;ユーザーのミュートの一覧を取得します。

<a id="ID4E4B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E6B"></a>


##### <a name="parent"></a>Parent

[プライバシー URI](atoc-reference-privacyv2.md)
