---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
assetID: 8d55818f-99fd-146a-896b-0f100e78799f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0eff47ed041502838b5101cd5700dbba7a03f383
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882290"
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
| 予約| string| 値を示すかどうかは、ユーザーが受け入れしないもののセッションのリストが含まれます。 このパラメーターを設定することのみを true に設定します。 この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID のフィルターに一致するように、呼び出し元の XUID を要求します。 | 
| 非アクティブです| string| 値を示すかどうかは、ユーザーが受け入れがアクティブにプレイしていないのセッションのリストが含まれます。 このパラメーターを設定することのみを true に設定します。 | 
| プライベート| string| プライベート セッション、セッションの一覧を示す値。 このパラメーターを設定することのみを true に設定します。 サーバーからサーバーを照会するとまたは自分のセッションをクエリするときにのみ有効です。 呼び出し元が、セッションにサーバー レベルのアクセスを true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID のフィルターに一致するように、呼び出し元の XUID を要求します。 | 
| visibility| string| 結果のフィルタ リングで使われる表示状態を示す列挙値。 現在このパラメーターのみに設定できます開くを開いているセッションを含めます。 <b>MultiplayerSessionVisibility</b>を参照してください。 | 
| version| string| 正の整数セッションのメジャー バージョンを示す、セッションの下に含めます。 値は 100 モジュロ要求のコントラクト バージョン以内である必要があります。 | 
| アプリ| string| 正の整数セッションの最大数を示すを取得します。| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (/serviceconfigs/sessiontemplates/{sessionTemplateName}/セッション)](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ Uri](atoc-reference-sessiondirectory.md)

   