---
title: PUT (/users/me/gamerpic)
assetID: ddf71c62-197d-a81d-35a7-47c6dc9e1b0c
permalink: en-us/docs/xboxlive/rest/uri-usersmegamerpicput.html
description: " PUT (/users/me/gamerpic)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7aedc7cbd8366c9cb8d3a60e2cb1f5e843b24a8a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661657"
---
# <a name="put-usersmegamerpic"></a>PUT (/users/me/gamerpic)
1080 x 1080 gamerpic をアップロードします。 
  * [要求本文](#ID4EQ)
  * [HTTP 状態コード](#ID4EZ)
  * [応答本文](#ID4EXC)
 
<a id="ID4EQ"></a>

 
## <a name="request-body"></a>要求本文
 
要求本文は、gamerpic (1080 x 1080 の PNG ファイルです)。
  
<a id="ID4EZ"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | 
| 200| OK| 正常に取得します。| 
| 201| 作成されます。| アップロードが正常に完了しました。| 
| 403| Forbidden| 特権は失効します。| 
| 500| エラー| 問題が発生しました。| 
  
<a id="ID4EXC"></a>

 
## <a name="response-body"></a>応答本文
 
応答の本文では、オブジェクトは送信されません。
  
<a id="ID4ECD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EED"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/gamerpic](uri-usersmegamerpic.md)

   