---
title: ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス
assetID: bbd7e3f3-77ac-6ffd-8951-fe4b8b48eb4c
permalink: en-us/docs/xboxlive/rest/atoc-gsdk-uri-reference.html
description: " ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a9a0a38cff9214485b2d7e8b1f8a28acb3207444
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8334474"
---
# <a name="game-server-universal-resource-identifier-uri-reference"></a><span data-ttu-id="88851-104">ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="88851-104">Game Server Universal Resource Identifier (URI) Reference</span></span>
<span data-ttu-id="88851-105">Uri のクライアントが、タイトルのゲーム サーバー開発キット サーバーのインスタンスを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="88851-105">URIs used by clients to create Game Server Development Kit server instances for a title.</span></span> <span data-ttu-id="88851-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="88851-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
<a id="ID4EY"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="88851-107">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="88851-107">In this section</span></span>

[<span data-ttu-id="88851-108">/qosservers</span><span class="sxs-lookup"><span data-stu-id="88851-108">/qosservers</span></span>](uri-qosservers.md)

<span data-ttu-id="88851-109">&nbsp;&nbsp;URI が利用可能な QoS サーバーの一覧を取得する Xbox Live エンジンで使用するためにクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="88851-109">&nbsp;&nbsp;URI called by a client to get the list of QoS servers available for use with Xbox Live Compute.</span></span>

[<span data-ttu-id="88851-110">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="88851-110">/titles/{titleId}/clusters</span></span>](uri-titlestitleidclusters.md)

<span data-ttu-id="88851-111">&nbsp;&nbsp;により、クライアントは、タイトルの Xbox Live Compute サーバー インスタンスを作成する URI。</span><span class="sxs-lookup"><span data-stu-id="88851-111">&nbsp;&nbsp;URI that allows a client to create an Xbox Live Compute server instance for a title.</span></span>

[<span data-ttu-id="88851-112">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="88851-112">/titles/{titleId}/variants</span></span>](uri-titlestitleidvariants.md)

<span data-ttu-id="88851-113">&nbsp;&nbsp;URI は、タイトルの利用可能な言語バリアントを取得するクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="88851-113">&nbsp;&nbsp;URI called by a client to get the available variants for a title.</span></span>

[<span data-ttu-id="88851-114">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="88851-114">/titles/{titleId}/sessionhosts</span></span>](uri-titlestitleidsessionhosts.md)

<span data-ttu-id="88851-115">&nbsp;&nbsp;指定されたタイトル id に割り当てられる Xbox Live Compute sessionhost を要求します。</span><span class="sxs-lookup"><span data-stu-id="88851-115">&nbsp;&nbsp;Requests a Xbox Live Compute sessionhost to be allocated for a given title id.</span></span>

[<span data-ttu-id="88851-116">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span><span class="sxs-lookup"><span data-stu-id="88851-116">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span></span>](uri-titlestitleidsessionssessionidallocationstatus.md)

<span data-ttu-id="88851-117">&nbsp;&nbsp;特定のタイトル id とセッション id、チケットの要求の状態を取得します。</span><span class="sxs-lookup"><span data-stu-id="88851-117">&nbsp;&nbsp;For the given title id and session id, get status of the ticket request.</span></span>
 