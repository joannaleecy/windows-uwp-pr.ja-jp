---
title: GET (/users/xuid({xuid})/history/titles)
assetID: c0a6cb3b-bab6-03b8-a79e-87defaaa6421
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesgetv2.html
description: " GET (/users/xuid({xuid})/history/titles)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cadbf38385bbc321ef5bf23eb93c3fbc5c1a2417
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655587"
---
# <a name="get-usersxuidxuidhistorytitles"></a>GET (/users/xuid({xuid})/history/titles)
ユーザーがロックを解除またはその成績の進歩をタイトルの一覧を取得します。 この API では、タイトルの再生または起動のユーザーの完全な履歴は返されません。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EY)
  * [クエリ文字列パラメーター](#ID4EDB)
  * [承認](#ID4EFD)
  * [省略可能な要求ヘッダー](#ID4EGE)
  * [要求本文](#ID4ERF)
 
<a id="ID4EY"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID)、ユーザーがタイトル履歴にアクセスしているのです。| 
  
<a id="ID4EDB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 必須| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | 
| skipItems| X| 32 ビット符号付き整数| 指定されたアイテム数の後に開始アイテムを返します。 たとえば、 <b>skipItems =「3」</b>項目を取得以降の 4 番目の項目を取得します。 | 
| continuationToken| X| string| 指定された継続トークンで始まる項目を返します。 | 
| maxItems| X| 32 ビット符号付き整数| 組み合わせて使用できるコレクションから返されるアイテムの最大数<b>skipItems</b>と<b>continuationToken</b>を項目の範囲を返します。 場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b>結果の最後のページが返されていない場合でも、します。 | 
  
<a id="ID4EFD"></a>

 
## <a name="authorization"></a>Authorization
 
| 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| 呼び出し元は、Xbox LIVE 権限を持つユーザーです。| 呼び出し元は、Xbox LIVE の有効なユーザーである必要があります。| 403 許可されていません| 
  
<a id="ID4EGE"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b>X RequestedServiceVersion</b>| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。| 
| <b>x-xbl-contract-version</b>| 32 ビット符号なし整数| 存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。 それ以外の場合、V1 します。| 
  
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

[ユーザーのタイトル (JSON)](../../json/json-usertitlev2.md)

 [PagingInfo (JSON)](../../json/json-paginginfo.md)

 [ページングのパラメーター](../../additional/pagingparameters.md)

   