---
title: アクセス許可が/users/{requestorId}/検証します。
assetID: 400a9721-bf43-76df-4cd1-9f2ae6ca5035
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidate.html
author: KevinAsgari
description: " アクセス許可が/users/{requestorId}/検証します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: faa0325a8540e1e3df9674a4acab2ab33e93dceb
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3927997"
---
# <a name="usersrequestoridpermissionvalidate"></a>アクセス許可が/users/{requestorId}/検証します。
 
  * [URI パラメーター](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| requestorId| string| 必須。 アクションを実行するユーザーの識別子です。 可能な値は<code>xuid({xuid})</code>と<code>me</code>します。 これは、ログインしているユーザーでなければなりません。 値の例:<code>xuid(0987654321)</code>します。| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (アクセス許可が/users/{requestorId}/検証)](uri-privacyusersrequestoridpermissionvalidateget.md)

&nbsp;&nbsp;ユーザーをターゲット ユーザーと指定した操作を実行できるかどうかに関するはいまたは no 応答を取得します。

[POST (アクセス許可が/users/{requestorId}/検証)](uri-privacyusersrequestoridpermissionvalidatepost.md)

&nbsp;&nbsp;一連のユーザーをターゲット ユーザーのセットを指定したアクションを実行できるかどうかに関するはいまたは no に対する回答を取得します。
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECC"></a>

   [プライバシー Uri](atoc-reference-privacyv2.md)

 [PermissionId 列挙](../../enums/privacy-enum-permissionid.md)

   