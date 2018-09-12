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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882486"
---
# <a name="session-directory-uris"></a>セッション ディレクトリ Uri

このセクションでは、Xbox Live サービスのマルチプレイヤー セッション ディレクトリ (MPSD) から、ユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。


> [!NOTE] 
> Xbox 360、Windows Phone デバイスの場合、または Xbox.com を実行しているゲーム用のタイトルのみには、セッション ディレクトリ Uri を使用できます。  


  * [ドメイン](#ID4EUB)
  * [サービスのバージョン](#ID4EZB)
  * [システム オブジェクトとプロパティ](#ID4EAC)
  * [ハンドル](#ID4EBE)

<a id="ID4EUB"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EZB"></a>


## <a name="service-version"></a>サービスのバージョン

これらの残りの部分の Uri の呼び出し元渡す必要があります、値 104/105 以降 X-Xbl-コントラクトのバージョン、サービスのバージョンのエンターテインメント探索サービス (EDS) を指定する HTTP ヘッダー。

<a id="ID4EAC"></a>


## <a name="system-objects-and-properties"></a>システム オブジェクトとプロパティ

そのセッションとテンプレートを構成する、MPSD は、ディレクトリを適用し、解釈される固定のスキーマをさまざまな準拠しているセッションの JSON オブジェクトを使用します。 これらのオブジェクトが検証は、さまざまなセッション ディレクトリ Uri でサポートされているメソッドを呼び出し中に、は、マージとサポートされているスキーマに基づいています。 マルチプレイヤーの構成に関連付けられている主な JSON オブジェクトは次のとおりです。

   *  [MultiplayerActivityDetails (JSON)](../../json/json-multiplayeractivitydetails.md)
   *  [MultiplayerSession (JSON)](../../json/json-multiplayersession.md)
   *  [MultiplayerSessionReference (JSON)](../../json/json-multiplayersessionreference.md)
   *  [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)


ゲームに具体的には関係が関連付けられている JSON オブジェクトは次のとおりです。

   *  [GameMessage (JSON)](../../json/json-gamemessage.md)
   *  [GameResult (JSON)](../../json/json-gameresult.md)
   *  [GameSession (JSON)](../../json/json-gamesession.md)
   *  [GameSessionSummary (JSON)](../../json/json-gamesessionsummary.md)


<a id="ID4EBE"></a>


## <a name="handles"></a>ハンドル

2015 マルチプレイヤーの場合のみ、セッションはセッション ハンドルを通じてアクセスできます。 ハンドルをサポートする機能を提供するのには、いくつかの Uri が追加されました。  
<a id="ID4EFE"></a>


## <a name="in-this-section"></a>このセクションの内容

[/handles](uri-handles.md)

&nbsp;&nbsp;ユーザーの現在のアクティビティを Xbox One ダッシュ ボードのユーザー エクスペリエンスを表示し、必要な場合は、セッション メンバーを招待するセッションを設定する POST 操作をサポートしています。

[/handles/{ハンドル id を使用}](uri-handleshandleid.md)

&nbsp;&nbsp;識別子により指定されたセッション ハンドルの削除を取得する操作をサポートしています。

[/handles/{ハンドル id を使用}/セッション](uri-handleshandleidsession.md)

&nbsp;&nbsp;PUT を取得する操作セッションでは、ハンドルを逆参照を使用してをサポートしています。

[/ハンドル/クエリ](uri-handlesquery.md)

&nbsp;&nbsp;セッション ハンドルのクエリを作成する POST 操作をサポートしています。

[/serviceconfigs/バッチ処理](uri-serviceconfigsscidbatch.md)

&nbsp;&nbsp;サービス構成の識別子レベルでバッチ クエリの POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessions](uri-serviceconfigsscidsessions.md)

&nbsp;&nbsp;セッション ドキュメントのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates](uri-serviceconfigsscidsessiontemplates.md)

&nbsp;&nbsp;MPSD セッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)

&nbsp;&nbsp;一連のセッション テンプレート名を取得する GET 操作をサポートしています。

[/serviceconfigs/sessiontemplates/{sessionTemplateName} バッチ処理/](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.md)

&nbsp;&nbsp;セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)

&nbsp;&nbsp;指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)

&nbsp;&nbsp;作成してセッションを取得する PUT を取得する操作をサポートしています。

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/members](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)

&nbsp;&nbsp;指定されたセッション メンバーを削除する削除操作をサポートしています。

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)

&nbsp;&nbsp;セッション メンバーを削除する削除操作をサポートしています。

[/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/servers/{サーバー名}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)

&nbsp;&nbsp;セッションの指定されたサーバーを削除する削除操作をサポートしています。

<a id="ID4ESF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EUF"></a>

   [マッチメイ キング Uri](../matchtickets/atoc-reference-matchtickets.md)


<a id="ID4E1F"></a>


##### <a name="parent"></a>Parent

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)
