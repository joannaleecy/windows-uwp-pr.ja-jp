---
title: GET (/users/xuid({xuid})/history/titles)
assetID: c0a6cb3b-bab6-03b8-a79e-87defaaa6421
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesgetv2.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/history/titles)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 966ff94004d6fd6bfc404800c5ea6561ae3a3864
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4508571"
---
# <a name="get-usersxuidxuidhistorytitles"></a>GET (/users/xuid({xuid})/history/titles)
タイトルは、ユーザーがロックを解除またはに対するその実績の進行状況の一覧を取得します。 この API では、タイトルのプレイまたは起動のユーザーのすべての履歴は返されません。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EY)
  * [クエリ文字列パラメーター](#ID4EDB)
  * [Authorization](#ID4EFD)
  * [オプションの要求ヘッダー](#ID4EGE)
  * [要求本文](#ID4ERF)
 
<a id="ID4EY"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) がタイトル履歴にアクセスしているユーザー。| 
  
<a id="ID4EDB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 必須かどうか| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| skipItems| いいえ| 32 ビット符号付き整数| 特定の項目数後から始まって項目を返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。 | 
| continuationToken| いいえ| string| 特定の継続トークンで始まる項目を返します。 | 
| maxItems| いいえ| 32 ビット符号付き整数| <b>SkipItems</b>と項目の範囲を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。 サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。 | 
  
<a id="ID4EFD"></a>

 
## <a name="authorization"></a>Authorization
 
| 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| 呼び出し元は、承認された Xbox LIVE ユーザーです。| 呼び出し元は、Xbox LIVE で有効なユーザーをする必要があります。| 403 Forbidden| 
  
<a id="ID4EGE"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>X RequestedServiceVersion</b>| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。| 
| <b>x xbl コントラクト バージョン</b>| 32 ビット符号なし整数| 存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。 それ以外の場合、V1 します。| 
  
<a id="ID4ERF"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/history/titles](uri-titlehistoryusersxuidhistorytitlesv2.md)

  
<a id="ID4EPG"></a>

 
##### <a name="reference"></a>リファレンス 

[UserTitle (JSON)](../../json/json-usertitlev2.md)

 [PagingInfo (JSON)](../../json/json-paginginfo.md)

 [ページング パラメーター](../../additional/pagingparameters.md)

   