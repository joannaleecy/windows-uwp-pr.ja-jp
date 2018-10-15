---
title: マッチメイキング URI
assetID: 667b02a9-6f34-8165-001b-ee8782575202
permalink: en-us/docs/xboxlive/rest/atoc-reference-matchtickets.html
author: KevinAsgari
description: " マッチメイキング URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bfeb225c67567c392615686743828941c02f6d2
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4614413"
---
# <a name="matchmaking-uris"></a><span data-ttu-id="af698-104">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="af698-104">Matchmaking URIs</span></span>
 
<span data-ttu-id="af698-105">このセクションでは、マッチメイ キング サービス用の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられたハイパー テキスト トランスポート プロトコル (HTTP) メソッドについての詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="af698-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the matchmaking service.</span></span> 
 
<a id="ID4E6"></a>

 
## <a name="domain"></a><span data-ttu-id="af698-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="af698-106">Domain</span></span>
<span data-ttu-id="af698-107">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="af698-107">momatch.xboxlive.com</span></span>  
<a id="ID4EEB"></a>

 
## <a name="service-version"></a><span data-ttu-id="af698-108">サービスのバージョン</span><span class="sxs-lookup"><span data-stu-id="af698-108">Service version</span></span>
 
<span data-ttu-id="af698-109">これらの HTTP/REST Uri の呼び出し元渡す必要があります値 103 以降 X の Xbl のコントラクトのバージョン、サービス バージョンのエンターテインメント探索サービス (EDS) を指定する HTTP ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="af698-109">Callers of these HTTP/REST URIs must pass the value 103 or later for X-Xbl-Contract-Version, the HTTP header that specifies the service version of Entertainment Discovery Services (EDS).</span></span> 
  
<a id="ID4ELB"></a>

 
## <a name="system-objects-and-properties"></a><span data-ttu-id="af698-110">システム オブジェクトとプロパティ</span><span class="sxs-lookup"><span data-stu-id="af698-110">System objects and properties</span></span>
 
<span data-ttu-id="af698-111">現時点では、マッチメイ キング サービスのすべての構成が発生した手動で、 [Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com)または[Windows デベロッパー センター](https://partner.microsoft.com/dashboard/windows/overview)のサービス構成部分を使用します。</span><span class="sxs-lookup"><span data-stu-id="af698-111">Currently, all configuration of the matchmaking service occurs manually, using the service configuration portion of the [Xbox Developer Portal (XDP)](https://xdp.xboxlive.com) or the [Windows Dev Center](https://partner.microsoft.com/dashboard/windows/overview).</span></span> <span data-ttu-id="af698-112">一部のマッチメイ キング情報は、MPSD に定義されたオブジェクトにも反映されます。</span><span class="sxs-lookup"><span data-stu-id="af698-112">Some matchmaking information is also reflected in the objects defined for the MPSD.</span></span> 
 
<span data-ttu-id="af698-113">マッチメイ キングを構成するために、メインの JSON オブジェクトは、 [MatchTicket (JSON)](../../json/json-matchticket.md)と[HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)で定義されます。</span><span class="sxs-lookup"><span data-stu-id="af698-113">The main JSON objects used for configuring matchmaking are defined in [MatchTicket (JSON)](../../json/json-matchticket.md) and [HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md).</span></span> <span data-ttu-id="af698-114">すべてのマッチ チケットが他のユーザーと一致する必要があるプレイヤーが含まれているマルチプレイヤー セッションへの参照を提供する**ticketSessionRef**オブジェクトを定義する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="af698-114">Note that all match tickets must define a **ticketSessionRef** object to provide a reference to a multiplayer session containing the player or players who want to be matched with others.</span></span> 
  
<a id="ID4EBC"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="af698-115">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="af698-115">In this section</span></span>

[<span data-ttu-id="af698-116">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="af698-116">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>](uri-serviceconfigsscidhoppershoppername.md)

<span data-ttu-id="af698-117">&nbsp;&nbsp;マッチ チケットを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="af698-117">&nbsp;&nbsp;Supports a POST operation to create match tickets.</span></span> 

[<span data-ttu-id="af698-118">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="af698-118">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>](uri-serviceconfigsscidhoppershoppernamestats.md)

<span data-ttu-id="af698-119">&nbsp;&nbsp;ホッパーの統計情報を取得するための取得操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="af698-119">&nbsp;&nbsp;Supports a GET operation for retrieving statistics for a hopper.</span></span>

[<span data-ttu-id="af698-120">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="af698-120">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>](uri-scidhoppernameticketid.md)

<span data-ttu-id="af698-121">&nbsp;&nbsp;マッチ チケットの削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="af698-121">&nbsp;&nbsp;Supports a DELETE operation for a match ticket.</span></span>
 
<a id="ID4ENC"></a>

 
## <a name="see-also"></a><span data-ttu-id="af698-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="af698-122">See also</span></span>
 
<a id="ID4EPC"></a>

   [<span data-ttu-id="af698-123">MatchTicket (JSON)</span><span class="sxs-lookup"><span data-stu-id="af698-123">MatchTicket (JSON)</span></span>](../../json/json-matchticket.md)

 [<span data-ttu-id="af698-124">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="af698-124">HopperStatsResults (JSON)</span></span>](../../json/json-hopperstatsresults.md)

 [<span data-ttu-id="af698-125">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="af698-125">Session Directory URIs</span></span>](../sessiondirectory/atoc-reference-sessiondirectory.md)

  
<a id="ID4E2C"></a>

 
##### <a name="parent"></a><span data-ttu-id="af698-126">Parent</span><span class="sxs-lookup"><span data-stu-id="af698-126">Parent</span></span> 

[<span data-ttu-id="af698-127">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="af698-127">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   