---
title: /serviceconfigs/{scid}/sessions
assetID: d1932817-dcce-5a5c-d7e4-9fd97e1d287c
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessions"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fa14d1d12ee951dfcaf6cd7beb91e09e39e11d93
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6203151"
---
# <a name="serviceconfigsscidsessions"></a>/serviceconfigs/{scid}/sessions
セッション ドキュメントのセットを取得する GET 操作をサポートしています。 
<a id="ID4EO"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成 id (SCID)。 パート 1 セッションの id。| 
| キーワード| string| キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。| 
| xuid| GUID| セッションを取得する対象のユーザーの Xbox ユーザー Id。 ユーザーは、セッション内でアクティブである必要があります。| 
| 予約| string| 示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。 このパラメーターを設定することのみを true に設定します。 この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 | 
| 非アクティブです| string| セッションのリストが、ユーザーが受け入れたがアクティブにプレイしていないものを含むかどうかを示す値。 このパラメーターを設定することのみを true に設定します。| 
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することのみを true に設定します。 独自のセッションをクエリするときにのみ、またはサーバー間を照会すると、無効です。 このパラメーターを true に設定、呼び出し元が、セッションにサーバー レベルのアクセスを必要とまたは Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 | 
| visibility| string| 結果のフィルタ リングで使われる表示状態を示す列挙値。 現在このパラメーターのみに設定できます開くを開いているセッションを含めます。 <b>MultiplayerSessionVisibility</b>を参照してください。| 
| version| string| 正の整数を示すセッションのメジャー バージョンまたはセッションの下に含めます。 値は 100 モジュロ要求のコントラクト バージョン以下である必要があります。| 
| アプリでは| string| 正の整数セッションの最大数を示すを取得します。| 
  
<a id="ID4E1D"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/sessions)](uri-serviceconfigsscidsessionsget.md)

&nbsp;&nbsp;指定したセッション情報を取得します。
 
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   