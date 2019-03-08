---
title: DELETE (/users/xuid({xuid})/devices/current/titles/current)
assetID: 3bf75247-0a2a-0e4c-afcc-9e7654a89648
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentdelete.html
description: " DELETE (/users/xuid({xuid})/devices/current/titles/current)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dd916fee5455276d45e4437e4ee90cacbde30bf9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604217"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a>DELETE (/users/xuid({xuid})/devices/current/titles/current)
待つのではなく、終了のタイトルのプレゼンスを削除、 [PresenceRecord](../../json/json-presencerecord.md)期限切れにします。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EZ)
  * [承認](#ID4EEB)
  * [必要な要求ヘッダー](#ID4ERD)
  * [省略可能な要求ヘッダー](#ID4EVF)
  * [要求本文](#ID4EVG)
  * [応答本文](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) の対象ユーザーです。| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a>Authorization
 
| 種類| 必須| 説明| 不足している場合の応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| 〇| 呼び出し元の Xbox ユーザー ID (XUID)| 403 許可されていません| 
| titleId| 〇| タイトルのタイトルの Id| 403 許可されていません| 
| deviceId| Windows と Web 以外のすべての場合ははい| 呼び出し元の deviceId| 403 許可されていません| 
| deviceType| Web 以外のすべての場合ははい| 呼び出し元の deviceType| 403 許可されていません| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。| 
| Content-Type| string| 要求の値の例の本文の mime の種類: アプリケーション/json します。| 
| Content-Length| string| 要求の本文の長さ。 値の例:312.| 
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. | 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合が発生した場合、応答本文なしで HTTP ステータス コードが返されます。
 
エラー (HTTP 4 xx または 5 xx) が発生した場合は、適切なエラー情報は、応答本文で返されます。
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

   