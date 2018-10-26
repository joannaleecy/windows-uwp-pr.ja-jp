---
title: /users/{ownerId}/summary
assetID: 63f8ed09-532d-381e-59e6-2849893df5bf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummary.html
author: KevinAsgari
description: " /users/{ownerId}/summary"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 67b7d207eee53a2e78b5e7ea4bcb37bb47ef9436
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5543562"
---
# <a name="usersowneridsummary"></a>/users/{ownerId}/summary
呼び出し元の観点から所有者に関する集計データにアクセスします。

  * [URI パラメーター](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| ownerId| string| そのリソースにアクセスしているユーザーの識別子です。 可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。 値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、 <code>gt(SomeGamertag)</code>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{ownerId}/summary)](uri-usersowneridsummaryget.md)

&nbsp;&nbsp;呼び出し元の観点から所有者に関する集計データを取得します。

<a id="ID4E3B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5B"></a>


##### <a name="parent"></a>Parent

[/users/{ownerId}/summary]()
