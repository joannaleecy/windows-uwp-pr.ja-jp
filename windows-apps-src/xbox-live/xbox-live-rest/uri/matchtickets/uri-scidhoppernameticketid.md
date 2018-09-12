---
title: /serviceconfigs/{scid} {hoppername}/hoppers//tickets/{ticketid}
assetID: 25deb7fe-859c-01d2-d14f-455a36c08a7c
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketid.html
author: KevinAsgari
description: " /serviceconfigs/{scid} {hoppername}/hoppers//tickets/{ticketid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dd7ed139fffb8bdb10ac5074d5e9725753678f1c
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3930301"
---
# <a name="serviceconfigsscidhoppershoppernameticketsticketid"></a><span data-ttu-id="0b358-104">/serviceconfigs/{scid} {hoppername}/hoppers//tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="0b358-104">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>

<span data-ttu-id="0b358-105">マッチ チケットの削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="0b358-105">Supports a DELETE operation for a match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0b358-106">この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="0b358-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="0b358-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="0b358-107">Domain</span></span>
<span data-ttu-id="0b358-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="0b358-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="remarks"></a><span data-ttu-id="0b358-109">注釈</span><span class="sxs-lookup"><span data-stu-id="0b358-109">Remarks</span></span>
<span data-ttu-id="0b358-110">この URI は、対象ユーザーの構成では所有者識別子の値の xuid、gt、および me をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="0b358-110">This URI supports the values xuid, gt, and me for the owner identifier in configuration of the target user.</span></span>  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a><span data-ttu-id="0b358-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b358-111">URI parameters</span></span>

| <span data-ttu-id="0b358-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b358-112">Parameter</span></span>| <span data-ttu-id="0b358-113">型</span><span class="sxs-lookup"><span data-stu-id="0b358-113">Type</span></span>| <span data-ttu-id="0b358-114">説明</span><span class="sxs-lookup"><span data-stu-id="0b358-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="0b358-115">scid</span><span class="sxs-lookup"><span data-stu-id="0b358-115">scid</span></span>| <span data-ttu-id="0b358-116">GUID</span><span class="sxs-lookup"><span data-stu-id="0b358-116">GUID</span></span>| <span data-ttu-id="0b358-117">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="0b358-117">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="0b358-118">name</span><span class="sxs-lookup"><span data-stu-id="0b358-118">name</span></span>| <span data-ttu-id="0b358-119">string</span><span class="sxs-lookup"><span data-stu-id="0b358-119">string</span></span>| <span data-ttu-id="0b358-120">ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="0b358-120">The name of the hopper.</span></span>|
| <span data-ttu-id="0b358-121">ticketId</span><span class="sxs-lookup"><span data-stu-id="0b358-121">ticketId</span></span>| <span data-ttu-id="0b358-122">GUID</span><span class="sxs-lookup"><span data-stu-id="0b358-122">GUID</span></span>| <span data-ttu-id="0b358-123">チケットの id。</span><span class="sxs-lookup"><span data-stu-id="0b358-123">The ticket ID.</span></span>|

<a id="ID4EJC"></a>


## <a name="valid-methods"></a><span data-ttu-id="0b358-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="0b358-124">Valid methods</span></span>

[<span data-ttu-id="0b358-125">(/Serviceconfigs/{scid} {hoppername}/hoppers//tickets/{ticketid}) を削除します。</span><span class="sxs-lookup"><span data-stu-id="0b358-125">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span></span>](uri-scidhoppernameticketiddelete.md)

<span data-ttu-id="0b358-126">&nbsp;&nbsp;マッチ チケットを削除します。</span><span class="sxs-lookup"><span data-stu-id="0b358-126">&nbsp;&nbsp;Removes a match ticket.</span></span>

<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="0b358-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="0b358-127">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="0b358-128">Parent</span><span class="sxs-lookup"><span data-stu-id="0b358-128">Parent</span></span>  

[<span data-ttu-id="0b358-129">マッチメイ キング Uri</span><span class="sxs-lookup"><span data-stu-id="0b358-129">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
