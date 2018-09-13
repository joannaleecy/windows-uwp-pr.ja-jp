---
title: セッション ディレクトリ Uri
assetID: e3ba951d-b21f-0014-c358-2603d549d118
permalink: en-us/docs/xboxlive/rest/atoc-reference-sessiondirectory.html
author: KevinAsgari
description: " セッション ディレクトリ Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b03c55b827b083c050451c12c1fe48834d7ae186
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958901"
---
# <a name="session-directory-uris"></a>セッション ディレクトリ Uri

このセクションでは、Xbox Live サービスのマルチプレイヤー セッション ディレクトリ (MPSD) からユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法についての詳細を提供します。


> [!NOTE] 
> Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームのタイトルのみには、セッション ディレクトリ Uri を使用できます。  


  * [ドメイン](#ID4EUB)
  * [サービスのバージョン](#ID4EZB)
  * [システム オブジェクトとプロパティ](#ID4EAC)
  * [ハンドル](#ID4EBE)

<a id="ID4EUB"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EZB"></a>


## <a name="service-version"></a>サービスのバージョン

これらの残りの部分の Uri の呼び出し元する必要があります値を渡す 104/105 以降 X-Xbl-コントラクトのバージョン、サービスのバージョンのエンターテインメント探索サービス (EDS) を指定する HTTP ヘッダー。

<a id="ID4EAC"></a>


## <a name="system-objects-and-properties"></a>システム オブジェクトとプロパティ

セッションとテンプレートを構成する、MPSD は、ディレクトリを適用および解釈される固定のスキーマを多数の準拠しているセッションの JSON オブジェクトを使用します。 さまざまなセッション ディレクトリ Uri でサポートされているメソッドの呼び出し時にこれらのオブジェクトは検証およびマージに基づいて、サポートされているスキーマ。 マルチプレイヤーの構成に関連付けられている主な JSON オブジェクトは次のとおりです。

   *  [MultiplayerActivityDetails (JSON)](../../json/json-multiplayeractivitydetails.md)
   *  [MultiplayerSession (JSON)](../../json/json-multiplayersession.md)
   *  [MultiplayerSessionReference (JSON)](../../json/json-multiplayersessionreference.md)
   *  [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)


ゲームで具体的には関係している関連付けられている JSON オブジェクトは次のとおりです。

   *  [GameMessage (JSON)](../../json/json-gamemessage.md)
   *  [GameResult (JSON)](../../json/json-gameresult.md)
   *  [GameSession (JSON)](../../json/json-gamesession.md)
   *  [GameSessionSummary (JSON)](../../json/json-gamesessionsummary.md)


<a id="ID4EBE"></a>


## <a name="handles"></a>ハンドル

2015 マルチプレイヤーの場合のみ、セッションはセッション ハンドルを通じてアクセスできます。 ハンドルをサポートする機能を提供するいくつかの Uri が追加されました。  
<a id="ID4EFE"></a>


## <a name="in-this-section"></a>このセクションの内容

[/handles](uri-handles.md)

&nbsp;&nbsp;Xbox One ダッシュ ボードのユーザー エクスペリエンスに表示されると、必要な場合は、セッション メンバーを招待するユーザーの現在のアクティビティのセッションを設定する POST 操作をサポートしています。

[/handles/{ハンドル id を使用}](uri-handleshandleid.md)

&nbsp;&nbsp;識別子により指定されたセッション ハンドルを削除または取得の操作をサポートしています。

[/handles/{ハンドル id を使用}/セッション](uri-handleshandleidsession.md)

&nbsp;&nbsp;PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。

[ハンドル/クエリ](uri-handlesquery.md)

&nbsp;&nbsp;セッション ハンドルのクエリを作成する POST 操作をサポートしています。

[/serviceconfigs/{scid} バッチ/](uri-serviceconfigsscidbatch.md)

&nbsp;&nbsp;サービス構成の識別子レベルでバッチ クエリの POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessions](uri-serviceconfigsscidsessions.md)

&nbsp;&nbsp;セッション ドキュメントのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates](uri-serviceconfigsscidsessiontemplates.md)

&nbsp;&nbsp;MPSD セッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)

&nbsp;&nbsp;セッション テンプレート名のセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName} バッチ/](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.md)

&nbsp;&nbsp;セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)

&nbsp;&nbsp;指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)

&nbsp;&nbsp;作成してセッションを取得する PUT と取得の操作をサポートしています。

[/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)

&nbsp;&nbsp;指定されたセッション メンバーを削除する削除操作をサポートしています。

[/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション} メンバー/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)

&nbsp;&nbsp;セッション メンバーを削除する削除操作をサポートしています。

[/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/servers/{サーバー名}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)

&nbsp;&nbsp;セッションの指定されたサーバーを削除する削除操作をサポートしています。

<a id="ID4ESF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EUF"></a>

   [マッチメイ キング Uri](../matchtickets/atoc-reference-matchtickets.md)


<a id="ID4E1F"></a>


##### <a name="parent"></a>Parent

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)
