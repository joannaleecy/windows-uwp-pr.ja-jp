---
title: /serviceconfigs/{scid}/sessions
assetID: d1932817-dcce-5a5c-d7e4-9fd97e1d287c
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessions.html
description: " /serviceconfigs/{scid}/sessions"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 700575ee9e9afa7bc7a1d34388dc071873d3b9ed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612577"
---
# <a name="serviceconfigsscidsessions"></a>/serviceconfigs/{scid}/sessions
セッションのドキュメントのセットを取得する GET 操作をサポートしています。 
<a id="ID4EO"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成の識別子 (SCID) です。 セッションの第 1 部 id。| 
| キーワード| string| 結果文字列で識別されるだけでセッションをフィルター処理するために使用するキーワードです。| 
| xuid| GUID| セッションを取得する対象のユーザーの Xbox ユーザー Id。 ユーザーは、セッションでアクティブである必要があります。| 
| 予約| string| セッションの一覧が、ユーザー同意していないものも含まれますかどうかを示す値。 このパラメーターを設定することができますのみ true に設定します。 この設定は、呼び出し元に、セッションにサーバー レベルのアクセスを要求または呼び出し元の XUID は Xbox のユーザー ID のフィルターに一致する要求。 | 
| 非アクティブ| string| セッションの一覧が、ユーザーが承諾しましたが、積極的に再生しないものを含むかどうかを示す値。 このパラメーターを設定することができますのみ true に設定します。| 
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することができますのみ true に設定します。 サーバーからサーバーを照会するときに、または自身のセッションのクエリを実行する場合にのみ有効です。 Xbox のユーザー ID のフィルターに一致する要求の呼び出し元の XUID または、呼び出し元に、セッションにサーバー レベルのアクセスを必要このパラメーターを true に設定します。 | 
| visibility| string| 結果をフィルター処理で使用される表示状態を示す列挙値。 現在このパラメーターのみ設定できます開くを開いているセッションを含める。 参照してください<b>MultiplayerSessionVisibility</b>します。| 
| version| string| 正の整数バージョンの主要なセッションまたはセッションの下位に含めます。 値は 100 剰余の要求のコントラクトのバージョン以下である必要があります。| 
| Take| string| 正の整数のセッションの最大数を取得します。| 
  
<a id="ID4E1D"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/sessions)](uri-serviceconfigsscidsessionsget.md)

&nbsp;&nbsp;指定したセッションの情報を取得します。
 
<a id="ID4EEE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリの Uri](atoc-reference-sessiondirectory.md)

   