---
title: /users/{ownerId}/summary
assetID: 63f8ed09-532d-381e-59e6-2849893df5bf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummary.html
description: " /users/{ownerId}/summary"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ca75261420449ac0b5af27ec34256ccef89fad2d
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8897189"
---
# <a name="usersowneridsummary"></a>/users/{ownerId}/summary
呼び出し元の観点から所有者に関する集計データにアクセスします。

  * [URI パラメーター](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。 値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、 <code>gt(SomeGamertag)</code>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/summary)](uri-usersowneridsummaryget.md)

&nbsp;&nbsp;呼び出し元の観点から、所有者に関する集計データを取得します。

<a id="ID4E3B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5B"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/summary]()
