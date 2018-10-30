---
title: /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2c64d54b3f1d8515018e256400af8e04f77d8955
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5760324"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a><span data-ttu-id="6c141-104">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="6c141-104">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>

<span data-ttu-id="6c141-105">マッチ チケットの削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="6c141-105">Supports a DELETE operation for a match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6c141-106">この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="6c141-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="6c141-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="6c141-107">Domain</span></span>
<span data-ttu-id="6c141-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="6c141-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="remarks"></a><span data-ttu-id="6c141-109">注釈</span><span class="sxs-lookup"><span data-stu-id="6c141-109">Remarks</span></span>
<span data-ttu-id="6c141-110">この URI は、対象ユーザーの構成では所有者識別子の値の xuid、gt、および me をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="6c141-110">This URI supports the values xuid, gt, and me for the owner identifier in configuration of the target user.</span></span>  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a><span data-ttu-id="6c141-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c141-111">URI parameters</span></span>

| <span data-ttu-id="6c141-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c141-112">Parameter</span></span>| <span data-ttu-id="6c141-113">型</span><span class="sxs-lookup"><span data-stu-id="6c141-113">Type</span></span>| <span data-ttu-id="6c141-114">説明</span><span class="sxs-lookup"><span data-stu-id="6c141-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="6c141-115">scid</span><span class="sxs-lookup"><span data-stu-id="6c141-115">scid</span></span>| <span data-ttu-id="6c141-116">GUID</span><span class="sxs-lookup"><span data-stu-id="6c141-116">GUID</span></span>| <span data-ttu-id="6c141-117">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="6c141-117">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="6c141-118">name</span><span class="sxs-lookup"><span data-stu-id="6c141-118">name</span></span>| <span data-ttu-id="6c141-119">string</span><span class="sxs-lookup"><span data-stu-id="6c141-119">string</span></span>| <span data-ttu-id="6c141-120">ホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="6c141-120">The name of the hopper.</span></span>|
| <span data-ttu-id="6c141-121">ticketId</span><span class="sxs-lookup"><span data-stu-id="6c141-121">ticketId</span></span>| <span data-ttu-id="6c141-122">GUID</span><span class="sxs-lookup"><span data-stu-id="6c141-122">GUID</span></span>| <span data-ttu-id="6c141-123">チケットの id。</span><span class="sxs-lookup"><span data-stu-id="6c141-123">The ticket ID.</span></span>|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a><span data-ttu-id="6c141-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="6c141-124">Valid methods</span></span>

[<span data-ttu-id="6c141-125">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span><span class="sxs-lookup"><span data-stu-id="6c141-125">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span></span>](uri-scidhoppernameticketiddelete.md)

<span data-ttu-id="6c141-126">&nbsp;&nbsp;マッチ チケットを削除します。</span><span class="sxs-lookup"><span data-stu-id="6c141-126">&nbsp;&nbsp;Removes a match ticket.</span></span>

<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="6c141-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="6c141-127">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="6c141-128">Parent</span><span class="sxs-lookup"><span data-stu-id="6c141-128">Parent</span></span>  

[<span data-ttu-id="6c141-129">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="6c141-129">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
