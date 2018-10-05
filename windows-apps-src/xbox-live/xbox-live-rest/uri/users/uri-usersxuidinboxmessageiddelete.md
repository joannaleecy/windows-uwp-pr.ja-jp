---
title: DELETE (/users/xuid({xuid})/inbox/{messageId})
assetID: c54eede3-3e3b-2cbe-1be9-8bf3a48171bc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageiddelete.html
author: KevinAsgari
description: " DELETE (/users/xuid({xuid})/inbox/{messageId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e98608f8329407ccb728abb9490eeb341e72aec5
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4385556"
---
# <a name="delete-usersxuidxuidinboxmessageid"></a>DELETE (/users/xuid({xuid})/inbox/{messageId})
ユーザーの受信トレイでユーザーのメッセージを削除します。 これらの Uri のドメインが`msg.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ECB)
  * [Authorization](#ID4EPB)
  * [要求本文](#ID4E1B)
  * [HTTP ステータス コード](#ID4EHC)
  * [JavaScript Object Notation (JSON) の応答](#ID4EAE)
  * [リソースのプライバシーの設定の効果](#ID4EYF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈 
 
削除操作では、等です。
 
この API はサポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター 
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid | 64 ビットの符号なし整数 | Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。 | 
| メッセージ Id | 文字列 [50] | 取得または削除されるメッセージの ID です。 | 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a>Authorization 
 
独自のユーザーがユーザーのメッセージを削除する要求が必要です。
  
<a id="ID4E1B"></a>

 
## <a name="request-body"></a>要求本文 
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EHC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード 
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 説明| 
| --- | --- | --- | --- | --- | 
| 204| 成功します。| 
| 403| XUID に変換することはできませんか、有効な XUID クレームが見つかったことはできません。| 
| 404| URI のメッセージ ID を解析できませんまたは、XUID が URI ではありません。| 
| 500| サーバー側の一般的なエラーです。| 
  
<a id="ID4EAE"></a>

 
## <a name="javascript-object-notation-json-response"></a>JavaScript Object Notation (JSON) の応答 
 
エラーの場合、サービスは、サービスの環境から値を含めることができますが全て、errorResponse オブジェクトを返す可能性があります。
 
| プロパティ| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| errorSource| string| エラーの発生元の項目を示します。| 
| errorCode| int| (Null にすることができます) エラーに関連付けられている数値コードです。| 
| エラー メッセージ| string| 詳細を表示するように構成する場合のエラーの説明します。| 
  
<a id="ID4EYF"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果 
 
のみ、独自のユーザー メッセージを削除することができます。 
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a>Parent  

[/users/xuid({xuid})/inbox](uri-usersxuidinbox.md)

  
<a id="ID4ETG"></a>

 
##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a>参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)

   