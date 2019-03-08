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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607487"
---
# <a name="usersowneridpeopleavoid"></a>/users/{ownerId}/people/avoid
ユーザーの避け一覧にアクセスします。

  * [URI パラメーター](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| ownerId| string| 必須。 リソースがアクセスされているユーザーの識別子。 指定できる値は<code>xuid({xuid})</code>します。 認証されたユーザーである必要があります。 値の例:<code>xuid(2603643534573581)</code>します。 最大サイズ: なし。 |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/people/avoid)](uri-privacyusersxuidpeopleavoidget.md)

&nbsp;&nbsp;ユーザーの避け一覧を取得します。

<a id="ID4E2B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E4B"></a>


##### <a name="parent"></a>Parent

[プライバシーの Uri](atoc-reference-privacyv2.md)
