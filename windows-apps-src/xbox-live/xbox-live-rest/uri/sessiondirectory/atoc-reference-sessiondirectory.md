---
title: セッション ディレクトリ URI
assetID: e3ba951d-b21f-0014-c358-2603d549d118
permalink: en-us/docs/xboxlive/rest/atoc-reference-sessiondirectory.html
description: " セッション ディレクトリ URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9492ff3272af830404a546c9b01d62178adbac96
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651197"
---
# <a name="session-directory-uris"></a>セッション ディレクトリ URI

このセクションでは、Xbox Live サービスのマルチ プレーヤーのセッション ディレクトリ (MPSD) から Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供します。


> [!NOTE] 
> Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームのタイトルだけでは、セッション ディレクトリの Uri を使用できます。  


  * [ドメイン](#ID4EUB)
  * [サービスのバージョン](#ID4EZB)
  * [システム オブジェクトとプロパティ](#ID4EAC)
  * [ハンドル](#ID4EBE)

<a id="ID4EUB"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EZB"></a>


## <a name="service-version"></a>サービスのバージョン

これらの REST Uri の呼び出し元する必要があります値を渡す 104/105 以降 X Xbl-コントラクトのバージョン、エンターテイメント検出サービス (EDS) のサービスのバージョンを指定する HTTP ヘッダー。

<a id="ID4EAC"></a>


## <a name="system-objects-and-properties"></a>システム オブジェクトとプロパティ

セッションとテンプレートを構成する、MPSD はディレクトリを適用し、解釈固定スキーマに準拠する JSON オブジェクトをセッション数を使用します。 これらのオブジェクトが検証は、さまざまなセッション ディレクトリの Uri でサポートされるメソッドの呼び出し時には、マージ、およびサポートされているスキーマに基づきます。 マルチ プレーヤーの構成に関連付けられた主な JSON オブジェクトは次のとおりです。

   *  [MultiplayerActivityDetails (JSON)](../../json/json-multiplayeractivitydetails.md)
   *  [MultiplayerSession (JSON)](../../json/json-multiplayersession.md)
   *  [MultiplayerSessionReference (JSON)](../../json/json-multiplayersessionreference.md)
   *  [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)


ゲームで具体的に懸念を抱いている JSON オブジェクトが関連付けられている次のとおりです。

   *  [GameMessage (JSON)](../../json/json-gamemessage.md)
   *  [GameResult (JSON)](../../json/json-gameresult.md)
   *  [GameSession (JSON)](../../json/json-gamesession.md)
   *  [GameSessionSummary (JSON)](../../json/json-gamesessionsummary.md)


<a id="ID4EBE"></a>


## <a name="handles"></a>ハンドル数

2015 マルチ プレーヤーの場合のみ、セッションはセッション ハンドルを通じてアクセスできます。 ハンドルをサポートする機能を提供するいくつかの Uri が追加されました。  
<a id="ID4EFE"></a>


## <a name="in-this-section"></a>このセクションの内容

[/handles](uri-handles.md)

&nbsp;&nbsp;Xbox One のダッシュ ボード ユーザー エクスペリエンスに表示するために必要な場合は、セッションのメンバーを招待して、ユーザーの現在のアクティビティのセッションを設定する POST 操作をサポートしています。

[/handles/{handleId}](uri-handleshandleid.md)

&nbsp;&nbsp;識別子によって指定されたセッション ハンドルの削除と GET 操作をサポートしています。

[/handles/{handleId}/session](uri-handleshandleidsession.md)

&nbsp;&nbsp;PUT および GET の操作をサポート セッション ハンドルの逆参照を使用します。

[/handles/query](uri-handlesquery.md)

&nbsp;&nbsp;セッション ハンドルのクエリを作成する POST 操作をサポートしています。

[/serviceconfigs/{scid}/batch](uri-serviceconfigsscidbatch.md)

&nbsp;&nbsp;サービス構成の識別子のレベルでのバッチ クエリの POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessions](uri-serviceconfigsscidsessions.md)

&nbsp;&nbsp;セッションのドキュメントのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates](uri-serviceconfigsscidsessiontemplates.md)

&nbsp;&nbsp;MPSD セッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)

&nbsp;&nbsp;セッションのテンプレート名のセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.md)

&nbsp;&nbsp;セッションのテンプレート レベルで、バッチ クエリを作成する POST 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)

&nbsp;&nbsp;指定したテンプレートの名前を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)

&nbsp;&nbsp;作成およびセッションを取得する PUT および GET 操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)

&nbsp;&nbsp;指定したセッションのメンバーを削除する削除操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)

&nbsp;&nbsp;セッションのメンバーを削除する削除操作をサポートしています。

[/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)

&nbsp;&nbsp;セッションの指定したサーバーを削除する削除操作をサポートしています。

<a id="ID4ESF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EUF"></a>

   [Uri のマッチメイ キング](../matchtickets/atoc-reference-matchtickets.md)


<a id="ID4E1F"></a>


##### <a name="parent"></a>Parent

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)
