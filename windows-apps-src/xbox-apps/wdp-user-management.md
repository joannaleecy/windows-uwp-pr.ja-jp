---
author: WilliamsJason
title: "Xbox Live テスト ユーザー管理 API のリファレンス"
description: "ユーザー管理 API にプログラムでアクセスする方法について説明します。"
ms.author: jaswill
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 70876ab6-8222-4940-b4fb-65b581a77d6a
ms.openlocfilehash: c1a2517aa8716cff9201351a12a3c391110aafab
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
#<a name="xbox-live-user-management"></a>Xbox Live ユーザー管理#

**要求**

本体のユーザーの一覧を取得したり、一覧を更新したりできます。更新では、既存のユーザーの追加、削除、サインイン、サインアウト、または変更を行うことができます。

| メソッド        | 要求 URI     | 
| ------------- |-----------------|
| GET           | /ext/user |
| PUT           | /ext/user |
<br>

**URI パラメーター**

* なし

**要求ヘッダー**

* なし

**要求本文**

PUT メソッドの呼び出しには、次の構造の JSON 配列を含める必要があります。

* Users
  * AutoSignIn (省略可能): EmailAddress や UserId で指定されたアカウントの自動サインインを無効または有効にするブール値。
  * EmailAddress (省略可能。ただし、スポンサー ユーザーにサインインしている場合を除き、UserId が指定されていない場合は必須): 変更、追加、削除を行うユーザーを指定するメール アドレス。
  * Password (省略可能。ただし、ユーザーが現在本体にサインインしていない場合は必須): 新しいユーザーを本体に追加するために使うパスワード。
  * SignedIn (省略可能): 指定されたアカウントでサインインまたはサインアウトする必要があるかどうかを指定するブール値。
  * UserId (省略可能。ただし、スポンサー ユーザーにサインインしている場合を除き、EmailAddress が指定されていない場合は必須): 変更、追加、削除を行うユーザーを指定するユーザー ID。
  * SponsoredUser (省略可能): スポンサー ユーザーを追加するかどうかを指定するブール値。
  * Delete (省略可能): 本体からこのユーザーを削除することを指定するブール値。

###<a name="response"></a>応答###

**応答本文**

GET メソッドの呼び出しでは、次のプロパティが指定された JSON 配列を返します。

* Users
  * AutoSignIn (省略可能)
  * EmailAddress (省略可能)
  * Gamertag
  * SignedIn
  * UserId
  * XboxUserId
  * SponsoredUser (省略可能)
  
**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード   | 説明     | 
| ------------------ |-----------------|
| 200                | GET メソッドの呼び出しが成功し、ユーザーの JSON 配列が応答本文で返されました |
| 204                | PUT メソッドの呼び出しが成功し、本体のユーザーが更新されました |
| 4XX                | 無効な要求データまたは形式を示すさまざまなエラー |
| 5XX                | 予期しないエラーのエラー コード |
<br>


