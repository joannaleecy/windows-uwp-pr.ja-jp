---
title: DELETE (/users/xuid({xuid})/inbox/{messageId})
assetID: c54eede3-3e3b-2cbe-1be9-8bf3a48171bc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageiddelete.html
description: " DELETE (/users/xuid({xuid})/inbox/{messageId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 80ec2a462648177cc6bfc846b9c84278821b0e5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594107"
---
# <a name="delete-usersxuidxuidinboxmessageid"></a>DELETE (/users/xuid({xuid})/inbox/{messageId})
ユーザーの受信トレイ内のユーザー メッセージを削除します。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ECB)
  * [承認](#ID4EPB)
  * [要求本文](#ID4E1B)
  * [HTTP 状態コード](#ID4EHC)
  * [JavaScript Object Notation (JSON) の応答](#ID4EAE)
  * [リソースのプライバシーの設定の効果](#ID4EYF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
削除操作は、べき等です。
 
この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid | 64 ビット符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。 | 
| メッセージ Id | string[50] | メッセージの取得中または削除の ID。 | 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a>Authorization 
 
要求のユーザー メッセージを削除して、独自のユーザーが必要です。
  
<a id="ID4E1B"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EHC"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード 
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 説明| 
| --- | --- | --- | --- | --- | 
| 204| 成功しました。| 
| 403| XUID を変換することはできませんまたは有効な XUID 要求が見つかりません。| 
| 404| URI にメッセージ ID を解析できないか、XUID が URI ではありません。| 
| 500| サーバー側の一般エラーです。| 
  
<a id="ID4EAE"></a>

 
## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答 
 
エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。
 
| プロパティ| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| errorSource| string| エラーの発生元を示します。| 
| エラー コード| int| (Null にすることができます)、エラーに関連付けられている数値コードです。| 
| エラー メッセージ| string| 詳細を表示するように構成してある場合、エラーの詳細です。| 
  
<a id="ID4EYF"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果 
 
のみ、独自のユーザー メッセージを削除することができます。 
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)

  
<a id="ID4ETG"></a>

 
##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)

   