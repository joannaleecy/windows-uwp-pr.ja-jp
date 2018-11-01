---
title: /users/{ownerId}/people/avoid
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
author: KevinAsgari
description: " /users/{ownerId}/people/avoid"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f4e7523790f527cc8c5816a01dd10ae92112af8
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5880021"
---
# <a name="usersowneridpeopleavoid"></a>/users/{ownerId}/people/avoid
ユーザーの回避一覧にアクセスします。

  * [URI パラメーター](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 そのリソースにアクセスしているユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>します。 認証されたユーザーである必要があります。 値の例:<code>xuid(2603643534573581)</code>します。 最大サイズ: なし。 |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/people/avoid)](uri-privacyusersxuidpeopleavoidget.md)

&nbsp;&nbsp;ユーザーの回避一覧を取得します。

<a id="ID4E2B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E4B"></a>


##### <a name="parent"></a>Parent

[プライバシー URI](atoc-reference-privacyv2.md)
