---
title: マッチメイキング URI
assetID: 667b02a9-6f34-8165-001b-ee8782575202
permalink: en-us/docs/xboxlive/rest/atoc-reference-matchtickets.html
description: " マッチメイキング URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c52abca7ed49d4a5e14520095ae944938b86f093
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590467"
---
# <a name="matchmaking-uris"></a><span data-ttu-id="b3b8b-104">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="b3b8b-104">Matchmaking URIs</span></span>
 
<span data-ttu-id="b3b8b-105">このセクションでは、マッチメイ キング サービスの Xbox Live サービスから Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the matchmaking service.</span></span> 
 
<a id="ID4E6"></a>

 
## <a name="domain"></a><span data-ttu-id="b3b8b-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="b3b8b-106">Domain</span></span>
<span data-ttu-id="b3b8b-107">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b3b8b-107">momatch.xboxlive.com</span></span>  
<a id="ID4EEB"></a>

 
## <a name="service-version"></a><span data-ttu-id="b3b8b-108">サービスのバージョン</span><span class="sxs-lookup"><span data-stu-id="b3b8b-108">Service version</span></span>
 
<span data-ttu-id="b3b8b-109">これらの HTTP/REST Uri の呼び出し元する必要があります値を渡す 103 以降 X Xbl-コントラクトのバージョン、エンターテイメント検出サービス (EDS) のサービスのバージョンを指定する HTTP ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-109">Callers of these HTTP/REST URIs must pass the value 103 or later for X-Xbl-Contract-Version, the HTTP header that specifies the service version of Entertainment Discovery Services (EDS).</span></span> 
  
<a id="ID4ELB"></a>

 
## <a name="system-objects-and-properties"></a><span data-ttu-id="b3b8b-110">システム オブジェクトとプロパティ</span><span class="sxs-lookup"><span data-stu-id="b3b8b-110">System objects and properties</span></span>
 
<span data-ttu-id="b3b8b-111">現時点では、サービス設定の部分を使用してマッチメイ キング サービスのすべての構成が手動で発生した、 [Xbox 開発者ポータル (XDP)](https://xdp.xboxlive.com)または[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-111">Currently, all configuration of the matchmaking service occurs manually, using the service configuration portion of the [Xbox Developer Portal (XDP)](https://xdp.xboxlive.com) or [Partner Center](https://partner.microsoft.com/dashboard).</span></span> <span data-ttu-id="b3b8b-112">いくつかのマッチメイ キング情報は、MPSD に対して定義されているオブジェクトにも反映されます。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-112">Some matchmaking information is also reflected in the objects defined for the MPSD.</span></span> 
 
<span data-ttu-id="b3b8b-113">マッチメイ キングを構成するために使用される主な JSON オブジェクトが定義されている[MatchTicket (JSON)](../../json/json-matchticket.md)と[HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)します。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-113">The main JSON objects used for configuring matchmaking are defined in [MatchTicket (JSON)](../../json/json-matchticket.md) and [HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md).</span></span> <span data-ttu-id="b3b8b-114">チケットが一致するすべてのメモを定義する必要があります、 **ticketSessionRef**プレーヤーまたは他のユーザーと一致することを希望するプレーヤーを含むマルチ プレーヤーのセッションへの参照を提供するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-114">Note that all match tickets must define a **ticketSessionRef** object to provide a reference to a multiplayer session containing the player or players who want to be matched with others.</span></span> 
  
<a id="ID4EBC"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="b3b8b-115">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="b3b8b-115">In this section</span></span>

[<span data-ttu-id="b3b8b-116">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="b3b8b-116">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>](uri-serviceconfigsscidhoppershoppername.md)

<span data-ttu-id="b3b8b-117">&nbsp;&nbsp;一致のチケットを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-117">&nbsp;&nbsp;Supports a POST operation to create match tickets.</span></span> 

[<span data-ttu-id="b3b8b-118">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="b3b8b-118">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>](uri-serviceconfigsscidhoppershoppernamestats.md)

<span data-ttu-id="b3b8b-119">&nbsp;&nbsp;Hopper の統計情報を取得するための GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-119">&nbsp;&nbsp;Supports a GET operation for retrieving statistics for a hopper.</span></span>

[<span data-ttu-id="b3b8b-120">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="b3b8b-120">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>](uri-scidhoppernameticketid.md)

<span data-ttu-id="b3b8b-121">&nbsp;&nbsp;一致するチケットの削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b3b8b-121">&nbsp;&nbsp;Supports a DELETE operation for a match ticket.</span></span>
 
<a id="ID4ENC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b3b8b-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="b3b8b-122">See also</span></span>
 
<a id="ID4EPC"></a>

   [<span data-ttu-id="b3b8b-123">MatchTicket (JSON)</span><span class="sxs-lookup"><span data-stu-id="b3b8b-123">MatchTicket (JSON)</span></span>](../../json/json-matchticket.md)

 [<span data-ttu-id="b3b8b-124">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="b3b8b-124">HopperStatsResults (JSON)</span></span>](../../json/json-hopperstatsresults.md)

 [<span data-ttu-id="b3b8b-125">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="b3b8b-125">Session Directory URIs</span></span>](../sessiondirectory/atoc-reference-sessiondirectory.md)

  
<a id="ID4E2C"></a>

 
##### <a name="parent"></a><span data-ttu-id="b3b8b-126">Parent</span><span class="sxs-lookup"><span data-stu-id="b3b8b-126">Parent</span></span> 

[<span data-ttu-id="b3b8b-127">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="b3b8b-127">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   