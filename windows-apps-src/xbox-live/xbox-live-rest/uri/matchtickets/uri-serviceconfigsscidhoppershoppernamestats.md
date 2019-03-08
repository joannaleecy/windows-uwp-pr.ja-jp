---
title: /serviceconfigs/{scid}/hoppers/{name}/stats
assetID: 56bb4398-445b-e8c5-a4ce-1651576ee7e7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestats.html
description: " /serviceconfigs/{scid}/hoppers/{name}/stats"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04376505b76296e052ea431f2a4e5fcfeac7b9e4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613937"
---
# <a name="serviceconfigsscidhoppersnamestats"></a><span data-ttu-id="63645-104">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="63645-104">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>

<span data-ttu-id="63645-105">Hopper の統計情報を取得するための GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="63645-105">Supports a GET operation for retrieving statistics for a hopper.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="63645-106">この URI は、コントラクト 103 以降で使用するためのものがおり、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。</span><span class="sxs-lookup"><span data-stu-id="63645-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="63645-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="63645-107">Domain</span></span>
<span data-ttu-id="63645-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="63645-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="remarks"></a><span data-ttu-id="63645-109">注釈</span><span class="sxs-lookup"><span data-stu-id="63645-109">Remarks</span></span>
<span data-ttu-id="63645-110">この URI は、ターゲット ユーザーの構成の所有者の識別子の値 xuid、gt、および私をサポートします。</span><span class="sxs-lookup"><span data-stu-id="63645-110">This URI supports the values xuid, gt, and me for the owner identifier in configuration of the target user.</span></span> <span data-ttu-id="63645-111">チケットの作成者だけでは、チケットを削除したり、URI の状態を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="63645-111">Only a ticket's creator can delete the ticket or retrieve the status of the URI.</span></span>  
<a id="ID4E6"></a>


## <a name="uri-parameters"></a><span data-ttu-id="63645-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="63645-112">URI parameters</span></span>

| <span data-ttu-id="63645-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="63645-113">Parameter</span></span>| <span data-ttu-id="63645-114">種類</span><span class="sxs-lookup"><span data-stu-id="63645-114">Type</span></span>| <span data-ttu-id="63645-115">説明</span><span class="sxs-lookup"><span data-stu-id="63645-115">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="63645-116">scid</span><span class="sxs-lookup"><span data-stu-id="63645-116">scid</span></span>| <span data-ttu-id="63645-117">GUID</span><span class="sxs-lookup"><span data-stu-id="63645-117">GUID</span></span>| <span data-ttu-id="63645-118">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="63645-118">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="63645-119">name</span><span class="sxs-lookup"><span data-stu-id="63645-119">name</span></span>| <span data-ttu-id="63645-120">string</span><span class="sxs-lookup"><span data-stu-id="63645-120">string</span></span>| <span data-ttu-id="63645-121">Hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="63645-121">The name of the hopper.</span></span>|

<a id="ID4EEC"></a>


## <a name="valid-methods"></a><span data-ttu-id="63645-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="63645-122">Valid methods</span></span>

[<span data-ttu-id="63645-123">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="63645-123">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>](uri-serviceconfigsscidhoppershoppernamestatsget.md)

<span data-ttu-id="63645-124">&nbsp;&nbsp;Hopper の統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="63645-124">&nbsp;&nbsp;Gets the statistics for a hopper.</span></span>

<a id="ID4EQC"></a>


## <a name="see-also"></a><span data-ttu-id="63645-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="63645-125">See also</span></span>

<a id="ID4ESC"></a>


##### <a name="parent"></a><span data-ttu-id="63645-126">Parent</span><span class="sxs-lookup"><span data-stu-id="63645-126">Parent</span></span>  

[<span data-ttu-id="63645-127">Uri のマッチメイ キング</span><span class="sxs-lookup"><span data-stu-id="63645-127">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
