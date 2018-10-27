---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
assetID: 8d55818f-99fd-146a-896b-0f100e78799f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b87625ec3ddd9b746b55adf33b10376c8bace69
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5694665"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。 
<a id="ID4EO"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成 id (SCID)。 パート 1 セッションの id。| 
| キーワード| string| キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。| 
| xuid| GUID| セッションを取得する対象のユーザーの Xbox ユーザー Id。 ユーザーは、セッション内でアクティブである必要があります。 | 
| 予約| string| 示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。 このパラメーターを設定することのみを true に設定します。 この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 | 
| 非アクティブです| string| セッションのリストが含まれますをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。 このパラメーターを設定することのみを true に設定します。 | 
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することのみを true に設定します。 自分のセッションをクエリするときにのみ、またはサーバーからサーバーを照会すると、無効です。 セッションへのサーバー レベルのアクセスが呼び出し元を true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。 | 
| visibility| string| 結果のフィルタ リングで使われる表示状態を示す列挙値。 現在このパラメーターのみに設定できます開くを開いているセッションを含めます。 <b>MultiplayerSessionVisibility</b>を参照してください。 | 
| version| string| 正の整数を示すセッションのメジャー バージョンまたはセッションの下に含めます。 値は 100 モジュロ要求のコントラクト バージョン以内である必要があります。 | 
| アプリ| string| 正の整数セッションの最大数を示すを取得します。| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   