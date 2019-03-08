---
title: /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
description: " /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9722d06af64c5fd24f53485a1bcfe765f89b08cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627317"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a><span data-ttu-id="f6e07-104">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="f6e07-104">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>

<span data-ttu-id="f6e07-105">一致するチケットの削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f6e07-105">Supports a DELETE operation for a match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f6e07-106">この URI は、コントラクト 103 以降で使用するためのものがおり、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。</span><span class="sxs-lookup"><span data-stu-id="f6e07-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="f6e07-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="f6e07-107">Domain</span></span>
<span data-ttu-id="f6e07-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="f6e07-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="remarks"></a><span data-ttu-id="f6e07-109">注釈</span><span class="sxs-lookup"><span data-stu-id="f6e07-109">Remarks</span></span>
<span data-ttu-id="f6e07-110">この URI は、ターゲット ユーザーの構成の所有者の識別子の値 xuid、gt、および私をサポートします。</span><span class="sxs-lookup"><span data-stu-id="f6e07-110">This URI supports the values xuid, gt, and me for the owner identifier in configuration of the target user.</span></span>  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a><span data-ttu-id="f6e07-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6e07-111">URI parameters</span></span>

| <span data-ttu-id="f6e07-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6e07-112">Parameter</span></span>| <span data-ttu-id="f6e07-113">種類</span><span class="sxs-lookup"><span data-stu-id="f6e07-113">Type</span></span>| <span data-ttu-id="f6e07-114">説明</span><span class="sxs-lookup"><span data-stu-id="f6e07-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="f6e07-115">scid</span><span class="sxs-lookup"><span data-stu-id="f6e07-115">scid</span></span>| <span data-ttu-id="f6e07-116">GUID</span><span class="sxs-lookup"><span data-stu-id="f6e07-116">GUID</span></span>| <span data-ttu-id="f6e07-117">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="f6e07-117">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="f6e07-118">name</span><span class="sxs-lookup"><span data-stu-id="f6e07-118">name</span></span>| <span data-ttu-id="f6e07-119">string</span><span class="sxs-lookup"><span data-stu-id="f6e07-119">string</span></span>| <span data-ttu-id="f6e07-120">Hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="f6e07-120">The name of the hopper.</span></span>|
| <span data-ttu-id="f6e07-121">TicketId</span><span class="sxs-lookup"><span data-stu-id="f6e07-121">ticketId</span></span>| <span data-ttu-id="f6e07-122">GUID</span><span class="sxs-lookup"><span data-stu-id="f6e07-122">GUID</span></span>| <span data-ttu-id="f6e07-123">チケット id。</span><span class="sxs-lookup"><span data-stu-id="f6e07-123">The ticket ID.</span></span>|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a><span data-ttu-id="f6e07-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f6e07-124">Valid methods</span></span>

[<span data-ttu-id="f6e07-125">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span><span class="sxs-lookup"><span data-stu-id="f6e07-125">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span></span>](uri-scidhoppernameticketiddelete.md)

<span data-ttu-id="f6e07-126">&nbsp;&nbsp;一致のチケットを削除します。</span><span class="sxs-lookup"><span data-stu-id="f6e07-126">&nbsp;&nbsp;Removes a match ticket.</span></span>

<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="f6e07-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="f6e07-127">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="f6e07-128">Parent</span><span class="sxs-lookup"><span data-stu-id="f6e07-128">Parent</span></span>  

[<span data-ttu-id="f6e07-129">Uri のマッチメイ キング</span><span class="sxs-lookup"><span data-stu-id="f6e07-129">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
