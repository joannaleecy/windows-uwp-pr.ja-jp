---
title: /users/{requestorId}/permission/validate
assetID: 400a9721-bf43-76df-4cd1-9f2ae6ca5035
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidate.html
author: KevinAsgari
description: " /users/{requestorId}/permission/validate"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e3eb7f2c92be1b459a72dd32eef737d72e9ac84c
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5568986"
---
# <a name="usersrequestoridpermissionvalidate"></a>/users/{requestorId}/permission/validate
 
  * [URI パラメーター](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| requestorId| string| 必須。 アクションを実行するユーザーの識別子です。 設定可能な値は<code>xuid({xuid})</code>と<code>me</code>します。 これは、ログインしているユーザーでなければなりません。 値の例:<code>xuid(0987654321)</code>します。| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/users/{requestorId}/permission/validate)](uri-privacyusersrequestoridpermissionvalidateget.md)

&nbsp;&nbsp;ユーザーをターゲット ユーザーと、指定されたアクションの実行を許可するかどうかに関するはいまたは no 応答を取得します。

[POST (/users/{requestorId}/permission/validate)](uri-privacyusersrequestoridpermissionvalidatepost.md)

&nbsp;&nbsp;一連のユーザーをターゲット ユーザーのセットを指定したアクションを実行できるかどうかに関するはいまたは no に対する回答を取得します。
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECC"></a>

   [プライバシー URI](atoc-reference-privacyv2.md)

 [PermissionId 列挙型](../../enums/privacy-enum-permissionid.md)

   