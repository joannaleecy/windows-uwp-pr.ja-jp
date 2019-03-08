---
title: ゲーム サーバー Universal Resource Identifier (URI) のリファレンス
assetID: bbd7e3f3-77ac-6ffd-8951-fe4b8b48eb4c
permalink: en-us/docs/xboxlive/rest/atoc-gsdk-uri-reference.html
description: " ゲーム サーバー Universal Resource Identifier (URI) のリファレンス"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a9a0a38cff9214485b2d7e8b1f8a28acb3207444
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662597"
---
# <a name="game-server-universal-resource-identifier-uri-reference"></a><span data-ttu-id="66689-104">ゲーム サーバー Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="66689-104">Game Server Universal Resource Identifier (URI) Reference</span></span>
<span data-ttu-id="66689-105">タイトルのゲーム Server 開発キットのサーバー インスタンスを作成するのに使用する Uri。</span><span class="sxs-lookup"><span data-stu-id="66689-105">URIs used by clients to create Game Server Development Kit server instances for a title.</span></span> <span data-ttu-id="66689-106">これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="66689-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
<a id="ID4EY"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="66689-107">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="66689-107">In this section</span></span>

[<span data-ttu-id="66689-108">/qosservers</span><span class="sxs-lookup"><span data-stu-id="66689-108">/qosservers</span></span>](uri-qosservers.md)

<span data-ttu-id="66689-109">&nbsp;&nbsp;Xbox Live コンピューティングで使用するために使用できる QoS サーバーの一覧を取得するクライアントから呼び出す URI。</span><span class="sxs-lookup"><span data-stu-id="66689-109">&nbsp;&nbsp;URI called by a client to get the list of QoS servers available for use with Xbox Live Compute.</span></span>

[<span data-ttu-id="66689-110">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="66689-110">/titles/{titleId}/clusters</span></span>](uri-titlestitleidclusters.md)

<span data-ttu-id="66689-111">&nbsp;&nbsp;により、クライアントはタイトルの Xbox Live コンピューティング サーバー インスタンスを作成する URI。</span><span class="sxs-lookup"><span data-stu-id="66689-111">&nbsp;&nbsp;URI that allows a client to create an Xbox Live Compute server instance for a title.</span></span>

[<span data-ttu-id="66689-112">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="66689-112">/titles/{titleId}/variants</span></span>](uri-titlestitleidvariants.md)

<span data-ttu-id="66689-113">&nbsp;&nbsp;タイトルの使用可能なバリエーションを取得するクライアントから呼び出す URI。</span><span class="sxs-lookup"><span data-stu-id="66689-113">&nbsp;&nbsp;URI called by a client to get the available variants for a title.</span></span>

[<span data-ttu-id="66689-114">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="66689-114">/titles/{titleId}/sessionhosts</span></span>](uri-titlestitleidsessionhosts.md)

<span data-ttu-id="66689-115">&nbsp;&nbsp;指定したタイトルの id に割り当てられる Xbox Live コンピューティング sessionhost を要求します。</span><span class="sxs-lookup"><span data-stu-id="66689-115">&nbsp;&nbsp;Requests a Xbox Live Compute sessionhost to be allocated for a given title id.</span></span>

[<span data-ttu-id="66689-116">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span><span class="sxs-lookup"><span data-stu-id="66689-116">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span></span>](uri-titlestitleidsessionssessionidallocationstatus.md)

<span data-ttu-id="66689-117">&nbsp;&nbsp;指定したタイトルの id とセッション id は、チケット要求の状態を取得します。</span><span class="sxs-lookup"><span data-stu-id="66689-117">&nbsp;&nbsp;For the given title id and session id, get status of the ticket request.</span></span>
 