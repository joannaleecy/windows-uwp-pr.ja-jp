---
title: セッション ディレクトリ URI
assetID: e3ba951d-b21f-0014-c358-2603d549d118
permalink: en-us/docs/xboxlive/rest/atoc-reference-sessiondirectory.html
author: KevinAsgari
description: " セッション ディレクトリ URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b03c55b827b083c050451c12c1fe48834d7ae186
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4019977"
---
# <a name="session-directory-uris"></a><span data-ttu-id="7789d-104">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="7789d-104">Session Directory URIs</span></span>

<span data-ttu-id="7789d-105">このセクションでは、Xbox Live サービスのマルチプレイヤー セッション ディレクトリ (MPSD) からユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="7789d-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the Multiplayer Session Directory (MPSD).</span></span>


> [!NOTE] 
> <span data-ttu-id="7789d-106">Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームのタイトルのみには、セッション ディレクトリ Uri を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7789d-106">Only titles for games running on an Xbox 360, on a Windows Phone device, or on Xbox.com can use the session directory URIs.</span></span>  


  * [<span data-ttu-id="7789d-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="7789d-107">Domain</span></span>](#ID4EUB)
  * [<span data-ttu-id="7789d-108">サービスのバージョン</span><span class="sxs-lookup"><span data-stu-id="7789d-108">Service version</span></span>](#ID4EZB)
  * [<span data-ttu-id="7789d-109">システム オブジェクトとプロパティ</span><span class="sxs-lookup"><span data-stu-id="7789d-109">System objects and properties</span></span>](#ID4EAC)
  * [<span data-ttu-id="7789d-110">ハンドル</span><span class="sxs-lookup"><span data-stu-id="7789d-110">Handles</span></span>](#ID4EBE)

<a id="ID4EUB"></a>


## <a name="domain"></a><span data-ttu-id="7789d-111">ドメイン</span><span class="sxs-lookup"><span data-stu-id="7789d-111">Domain</span></span>
<span data-ttu-id="7789d-112">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="7789d-112">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EZB"></a>


## <a name="service-version"></a><span data-ttu-id="7789d-113">サービスのバージョン</span><span class="sxs-lookup"><span data-stu-id="7789d-113">Service version</span></span>

<span data-ttu-id="7789d-114">これらの Uri の残りの部分の呼び出し元渡す必要があります値 104/105 以降 X-Xbl-コントラクトのバージョン、サービス バージョン エンターテイメント探索サービス (EDS) を指定する HTTP ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="7789d-114">Callers of these REST URIs must pass the value 104/105 or later for X-Xbl-Contract-Version, the HTTP header that specifies the service version of Entertainment Discovery Services (EDS).</span></span>

<a id="ID4EAC"></a>


## <a name="system-objects-and-properties"></a><span data-ttu-id="7789d-115">システム オブジェクトとプロパティ</span><span class="sxs-lookup"><span data-stu-id="7789d-115">System objects and properties</span></span>

<span data-ttu-id="7789d-116">セッションとテンプレートを構成する、MPSD は、ディレクトリを適用および解釈される固定のスキーマに準拠しているセッションの JSON オブジェクトの数を使用します。</span><span class="sxs-lookup"><span data-stu-id="7789d-116">For configuration of its sessions and templates, the MPSD uses a number of session JSON objects that conform with fixed schemas that the directory enforces and interprets.</span></span> <span data-ttu-id="7789d-117">さまざまなセッション ディレクトリ Uri でサポートされているメソッドの呼び出し時にこれらのオブジェクトは検証およびマージに基づいて、サポートされているスキーマ。</span><span class="sxs-lookup"><span data-stu-id="7789d-117">During calls to the methods supported by the various session directory URIs, these objects are validated and merged, based on the supported schemas.</span></span> <span data-ttu-id="7789d-118">マルチプレイヤーの構成に関連付けられている主な JSON オブジェクトは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7789d-118">The main JSON objects associated with multiplayer configuration are:</span></span>

   *  [<span data-ttu-id="7789d-119">MultiplayerActivityDetails (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-119">MultiplayerActivityDetails (JSON)</span></span>](../../json/json-multiplayeractivitydetails.md)
   *  [<span data-ttu-id="7789d-120">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-120">MultiplayerSession (JSON)</span></span>](../../json/json-multiplayersession.md)
   *  [<span data-ttu-id="7789d-121">MultiplayerSessionReference (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-121">MultiplayerSessionReference (JSON)</span></span>](../../json/json-multiplayersessionreference.md)
   *  [<span data-ttu-id="7789d-122">MultiplayerSessionRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-122">MultiplayerSessionRequest (JSON)</span></span>](../../json/json-multiplayersessionrequest.md)


<span data-ttu-id="7789d-123">ゲームに具体的には関係が関連付けられている JSON オブジェクトは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7789d-123">Associated JSON objects that are concerned specifically with games are:</span></span>

   *  [<span data-ttu-id="7789d-124">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-124">GameMessage (JSON)</span></span>](../../json/json-gamemessage.md)
   *  [<span data-ttu-id="7789d-125">GameResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-125">GameResult (JSON)</span></span>](../../json/json-gameresult.md)
   *  [<span data-ttu-id="7789d-126">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-126">GameSession (JSON)</span></span>](../../json/json-gamesession.md)
   *  [<span data-ttu-id="7789d-127">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="7789d-127">GameSessionSummary (JSON)</span></span>](../../json/json-gamesessionsummary.md)


<a id="ID4EBE"></a>


## <a name="handles"></a><span data-ttu-id="7789d-128">ハンドル</span><span class="sxs-lookup"><span data-stu-id="7789d-128">Handles</span></span>

<span data-ttu-id="7789d-129">2015 マルチプレイヤーの場合のみ、セッションはセッション ハンドルを通じてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="7789d-129">For 2015 Multiplayer only, sessions can be accessed through session handles.</span></span> <span data-ttu-id="7789d-130">ハンドルをサポートする機能を提供するいくつかの Uri が追加されました。</span><span class="sxs-lookup"><span data-stu-id="7789d-130">Several URIs have been added to provide functionality to support handles.</span></span>  
<a id="ID4EFE"></a>


## <a name="in-this-section"></a><span data-ttu-id="7789d-131">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="7789d-131">In this section</span></span>

[<span data-ttu-id="7789d-132">/handles</span><span class="sxs-lookup"><span data-stu-id="7789d-132">/handles</span></span>](uri-handles.md)

<span data-ttu-id="7789d-133">&nbsp;&nbsp;Xbox One ダッシュ ボードのユーザー エクスペリエンスに表示されると、必要な場合は、セッション メンバーを招待するユーザーの現在のアクティビティのセッションを設定する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-133">&nbsp;&nbsp;Supports a POST operation to set the session for the user's current activity to be displayed in Xbox One dashboard user experience, and to invite session members if required.</span></span>

[<span data-ttu-id="7789d-134">/handles/{handleId}</span><span class="sxs-lookup"><span data-stu-id="7789d-134">/handles/{handleId}</span></span>](uri-handleshandleid.md)

<span data-ttu-id="7789d-135">&nbsp;&nbsp;識別子により指定されたセッション ハンドルを削除または取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-135">&nbsp;&nbsp;Supports DELETE and GET operations for session handles specified by identifier.</span></span>

[<span data-ttu-id="7789d-136">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="7789d-136">/handles/{handleId}/session</span></span>](uri-handleshandleidsession.md)

<span data-ttu-id="7789d-137">&nbsp;&nbsp;PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-137">&nbsp;&nbsp;Supports PUT and GET operations for a session, using handle dereferencing.</span></span>

[<span data-ttu-id="7789d-138">/handles/query</span><span class="sxs-lookup"><span data-stu-id="7789d-138">/handles/query</span></span>](uri-handlesquery.md)

<span data-ttu-id="7789d-139">&nbsp;&nbsp;セッション ハンドルのクエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-139">&nbsp;&nbsp;Supports POST operations to create queries for session handles.</span></span>

[<span data-ttu-id="7789d-140">/serviceconfigs/{scid}/batch</span><span class="sxs-lookup"><span data-stu-id="7789d-140">/serviceconfigs/{scid}/batch</span></span>](uri-serviceconfigsscidbatch.md)

<span data-ttu-id="7789d-141">&nbsp;&nbsp;サービス構成の識別子レベルでバッチ クエリの POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-141">&nbsp;&nbsp;Supports a POST operation for a batch query at the service configuration identifier level.</span></span>

[<span data-ttu-id="7789d-142">/serviceconfigs/{scid}/sessions</span><span class="sxs-lookup"><span data-stu-id="7789d-142">/serviceconfigs/{scid}/sessions</span></span>](uri-serviceconfigsscidsessions.md)

<span data-ttu-id="7789d-143">&nbsp;&nbsp;セッション ドキュメントのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-143">&nbsp;&nbsp;Supports a GET operation to retrieve a set of session documents.</span></span>

[<span data-ttu-id="7789d-144">/serviceconfigs/{scid}/sessiontemplates</span><span class="sxs-lookup"><span data-stu-id="7789d-144">/serviceconfigs/{scid}/sessiontemplates</span></span>](uri-serviceconfigsscidsessiontemplates.md)

<span data-ttu-id="7789d-145">&nbsp;&nbsp;MPSD セッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-145">&nbsp;&nbsp;Supports a GET operation to retrieve a set of MPSD session templates.</span></span>

[<span data-ttu-id="7789d-146">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span><span class="sxs-lookup"><span data-stu-id="7789d-146">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)

<span data-ttu-id="7789d-147">&nbsp;&nbsp;セッション テンプレート名のセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-147">&nbsp;&nbsp;Supports a GET operation to retrieve a set of session template names.</span></span>

[<span data-ttu-id="7789d-148">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span><span class="sxs-lookup"><span data-stu-id="7789d-148">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span></span>](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.md)

<span data-ttu-id="7789d-149">&nbsp;&nbsp;セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-149">&nbsp;&nbsp;Supports a POST operation to create a batch query at the session template level.</span></span>

[<span data-ttu-id="7789d-150">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="7789d-150">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)

<span data-ttu-id="7789d-151">&nbsp;&nbsp;指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-151">&nbsp;&nbsp;Supports a GET operation to retrieve a set of session templates with the specified template names.</span></span>

[<span data-ttu-id="7789d-152">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="7789d-152">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)

<span data-ttu-id="7789d-153">&nbsp;&nbsp;作成してセッションを取得する PUT と取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-153">&nbsp;&nbsp;Supports PUT and GET operations to create and retrieve sessions.</span></span>

[<span data-ttu-id="7789d-154">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span><span class="sxs-lookup"><span data-stu-id="7789d-154">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)

<span data-ttu-id="7789d-155">&nbsp;&nbsp;指定されたセッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-155">&nbsp;&nbsp;Supports a DELETE operation to remove the specified session member.</span></span>

[<span data-ttu-id="7789d-156">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="7789d-156">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)

<span data-ttu-id="7789d-157">&nbsp;&nbsp;セッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-157">&nbsp;&nbsp;Supports a DELETE operation to remove session members.</span></span>

[<span data-ttu-id="7789d-158">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="7789d-158">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)

<span data-ttu-id="7789d-159">&nbsp;&nbsp;セッションの指定されたサーバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7789d-159">&nbsp;&nbsp;Supports a DELETE operation to remove the specified server of a session.</span></span>

<a id="ID4ESF"></a>


## <a name="see-also"></a><span data-ttu-id="7789d-160">関連項目</span><span class="sxs-lookup"><span data-stu-id="7789d-160">See also</span></span>

<a id="ID4EUF"></a>

   [<span data-ttu-id="7789d-161">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="7789d-161">Matchmaking URIs</span></span>](../matchtickets/atoc-reference-matchtickets.md)


<a id="ID4E1F"></a>


##### <a name="parent"></a><span data-ttu-id="7789d-162">Parent</span><span class="sxs-lookup"><span data-stu-id="7789d-162">Parent</span></span>

[<span data-ttu-id="7789d-163">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="7789d-163">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)
