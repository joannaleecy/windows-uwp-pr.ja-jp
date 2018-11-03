---
title: PUT (/users/me/gamerpic)
assetID: ddf71c62-197d-a81d-35a7-47c6dc9e1b0c
permalink: en-us/docs/xboxlive/rest/uri-usersmegamerpicput.html
author: KevinAsgari
description: " PUT (/users/me/gamerpic)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0d9346303e82dea2dbbd60b542c4ee207dd40901
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5990445"
---
# <a name="put-usersmegamerpic"></a>PUT (/users/me/gamerpic)
1080 x 1080 ゲーマー アイコンをアップロードします。 
  * [要求本文](#ID4EQ)
  * [HTTP ステータス コード](#ID4EZ)
  * [応答本文](#ID4EXC)
 
<a id="ID4EQ"></a>

 
## <a name="request-body"></a>要求本文
 
要求本文は、ゲーマー アイコン (1080 x 1080 PNG ファイルです)。
  
<a id="ID4EZ"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | 
| 200| OK| 成功した取得します。| 
| 201| 作成されます。| アップロードが正常に完了しました。| 
| 403| Forbidden| 特権は失効されます。| 
| 500| エラー| 問題が発生しました。| 
  
<a id="ID4EXC"></a>

 
## <a name="response-body"></a>応答本文
 
応答の本文には、オブジェクトは送信されません。
  
<a id="ID4ECD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EED"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/gamerpic](uri-usersmegamerpic.md)

   