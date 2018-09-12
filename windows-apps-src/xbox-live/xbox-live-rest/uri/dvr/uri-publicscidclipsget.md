---
title: 取得する (パブリック///} クリップ/)
assetID: 15b3e873-1f96-b1da-2f79-6dac1369a4c0
permalink: en-us/docs/xboxlive/rest/uri-publicscidclipsget.html
author: KevinAsgari
description: " 取得する (パブリック///} クリップ/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b945427118122e3b6d52210efc5e1de84a8c8d68
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882106"
---
# <a name="get-publicscidsscidclips"></a>取得する (パブリック///} クリップ/)
パブリック クリップを一覧表示します。 この URI のドメインが`gameclipsmetadata.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4ECB)
  * [クエリ文字列パラメーター](#ID4ENB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
この API は、さまざまな方法は、パブリック一覧クリップにできます。 クリップの一覧に基づいて返されたプライバシー チェックと要求元の XUID に対してコンテンツの分離チェックします。
 
クエリは、サービス構成 id (SCID) ごとに最適化されます。 さらにフィルターを使ってまたは並べ替え順序を以下に示す既定値以外を指定するいくつかの状況で長い時間がかかるに戻ります。 これは、ビデオのセットが大規模なより明確です。 クエリでは、順の並べ替え順序を指定できません。
 
公開のクリップを特定のコレクションを取得するのには、修飾子が必要です。 要求元のユーザーに要求された SCID にアクセスする必要があります、そうしないと http/403 が返されます。
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| string| パブリック クリップのプライマリ サービス構成 id。| 
| タイトル id| string| パブリック クリップのタイトル Id。 SCID と同じ URI で指定することはできません。 指定した場合はプライマリー SCID を検索するために使用されます。| 
  
<a id="ID4ENB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| <b>かどうか achievementId = {achievementId}。</b>| 最新のクリップが指定された<b>achievementId</b>に一致します。| 追加の並べ替えとフィルター処理することはサポートされていません。| 
| <b>かどうか greatestMomentId = {greatestMomentId}。</b>| 最新のクリップが指定された<b>greatestMomentId</b>に一致します。| 追加の並べ替えとフィルター処理することはサポートされていません。| 
| <b>かどうか修飾子 = 作成。 </b>| Most Recent| 必須。| 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a>Parent 

[パブリック///} クリップ/](uri-publicscidclips.md)

   