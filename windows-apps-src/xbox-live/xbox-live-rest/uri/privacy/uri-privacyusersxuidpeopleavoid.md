---
title: /users/{ownerId}/people/avoid
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
description: " /users/{ownerId}/people/avoid"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d0ae745f825d6afda87167859b12bcc52b899f18
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8898589"
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
