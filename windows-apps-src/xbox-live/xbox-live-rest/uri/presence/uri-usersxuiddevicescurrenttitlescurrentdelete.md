---
title: DELETE (/users/xuid({xuid})/devices/current/titles/current)
assetID: 3bf75247-0a2a-0e4c-afcc-9e7654a89648
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentdelete.html
author: KevinAsgari
description: " DELETE (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92d2586662121b48701c7eb33f3b8f91e5243bd6
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6196881"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a>DELETE (/users/xuid({xuid})/devices/current/titles/current)
[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるまで待つの終了タイトルのプレゼンスを削除します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EZ)
  * [Authorization](#ID4EEB)
  * [必要な要求ヘッダー](#ID4ERD)
  * [オプションの要求ヘッダー](#ID4EVF)
  * [要求本文](#ID4EVG)
  * [応答本文](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) 対象ユーザーのです。| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a>Authorization
 
| 型| 必須かどうか| 説明| 不足している場合、応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| はい| 呼び出し元の Xbox ユーザー ID (XUID)| 403 Forbidden| 
| titleId| はい| タイトルの titleId| 403 Forbidden| 
| deviceId| Windows と Web 以外のすべての [はい] します。| 呼び出し元の deviceId| 403 Forbidden| 
| deviceType| Web 以外のすべての [はい]| 呼び出し元の deviceType| 403 Forbidden| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。| 
| x xbl コントラクト バージョン| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 値の例: 3, vnext します。| 
| Content-Type| string| 値の例の要求の本文の mime タイプ: アプリケーション/json します。| 
| Content-Length| string| 要求の本文の長さ。 値の例: 312 します。| 
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。 既定値: 1 です。| 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a>応答本文
 
、成功した場合、応答本文の HTTP ステータス コードが返されません。
 
エラー (4 xx の HTTP または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

   