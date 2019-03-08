---
title: GET (/public/scids/{scid}/clips)
assetID: 15b3e873-1f96-b1da-2f79-6dac1369a4c0
permalink: en-us/docs/xboxlive/rest/uri-publicscidclipsget.html
description: " GET (/public/scids/{scid}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5bce1dd261e0ad1172068a0287519cd0480da85f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589807"
---
# <a name="get-publicscidsscidclips"></a>GET (/public/scids/{scid}/clips)
パブリックのクリップを一覧表示します。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ECB)
  * [クエリ文字列パラメーター](#ID4ENB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
この API は、パブリックであるリスト クリップするさまざまな方法を使用できます。 クリップの一覧がプライバシーに関する確認と要求元 XUID に対してコンテンツの分離のチェックをベースに返されます。
 
クエリは、サービス構成の識別子 (SCID) ごとに最適化されます。 さらにフィルターまたは以下に示す既定値以外の並べ替え順序を指定するいくつかの状況で長い時間がかかるを返します。 ビデオのより大きなセットをより明らかになります。 クエリでは、昇順の並べ替え順序を指定できません。
 
公開のクリップを特定のコレクションを取得するには、修飾子が必要です。 要求元のユーザーは、要求された SCID にアクセスする必要があります、それ以外の場合 HTTP 403 が返されます。
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| string| パブリックのクリップをプライマリ サービスの構成の識別子です。| 
| タイトル id| string| パブリックのクリップのタイトル Id。 同じ URI、SCID としてでは指定できません。 指定した場合は、プライマリ SCID 検索に使用されます。| 
  
<a id="ID4ENB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| <b>?achievementId={achievementId}</b>| 指定された一致する最新のクリップ<b>achievementId</b>します。| 追加の並べ替え/フィルターはサポートされていません。| 
| <b>?greatestMomentId={greatestMomentId}</b>| 指定された一致する最新のクリップ<b>greatestMomentId</b>します。| 追加の並べ替え/フィルターはサポートされていません。| 
| <b>?qualifier=created </b>| 最新| 必須。| 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a>Parent 

[/public/scids/{scid}/clips](uri-publicscidclips.md)

   