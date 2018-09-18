---
title: /serviceconfigs/{scid}/hoppers/{name}/stats
assetID: 56bb4398-445b-e8c5-a4ce-1651576ee7e7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestats.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{name}/stats"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0742ad87e68f7d0c6ed6346873aa3dd6c56edee0
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4022973"
---
# <a name="serviceconfigsscidhoppersnamestats"></a><span data-ttu-id="b9379-104">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="b9379-104">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>

<span data-ttu-id="b9379-105">ホッパーの統計情報を取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b9379-105">Supports a GET operation for retrieving statistics for a hopper.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b9379-106">この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="b9379-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="b9379-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="b9379-107">Domain</span></span>
<span data-ttu-id="b9379-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b9379-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="remarks"></a><span data-ttu-id="b9379-109">注釈</span><span class="sxs-lookup"><span data-stu-id="b9379-109">Remarks</span></span>
<span data-ttu-id="b9379-110">この URI は、対象ユーザーの構成では所有者識別子の値の xuid、gt、および me をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b9379-110">This URI supports the values xuid, gt, and me for the owner identifier in configuration of the target user.</span></span> <span data-ttu-id="b9379-111">チケットの作成者だけでは、チケットを削除したり、URI の状態を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="b9379-111">Only a ticket's creator can delete the ticket or retrieve the status of the URI.</span></span>  
<a id="ID4E6"></a>


## <a name="uri-parameters"></a><span data-ttu-id="b9379-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b9379-112">URI parameters</span></span>

| <span data-ttu-id="b9379-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b9379-113">Parameter</span></span>| <span data-ttu-id="b9379-114">型</span><span class="sxs-lookup"><span data-stu-id="b9379-114">Type</span></span>| <span data-ttu-id="b9379-115">説明</span><span class="sxs-lookup"><span data-stu-id="b9379-115">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="b9379-116">scid</span><span class="sxs-lookup"><span data-stu-id="b9379-116">scid</span></span>| <span data-ttu-id="b9379-117">GUID</span><span class="sxs-lookup"><span data-stu-id="b9379-117">GUID</span></span>| <span data-ttu-id="b9379-118">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="b9379-118">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="b9379-119">name</span><span class="sxs-lookup"><span data-stu-id="b9379-119">name</span></span>| <span data-ttu-id="b9379-120">string</span><span class="sxs-lookup"><span data-stu-id="b9379-120">string</span></span>| <span data-ttu-id="b9379-121">ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="b9379-121">The name of the hopper.</span></span>|

<a id="ID4EEC"></a>


## <a name="valid-methods"></a><span data-ttu-id="b9379-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b9379-122">Valid methods</span></span>

[<span data-ttu-id="b9379-123">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="b9379-123">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>](uri-serviceconfigsscidhoppershoppernamestatsget.md)

<span data-ttu-id="b9379-124">&nbsp;&nbsp;ホッパーの統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="b9379-124">&nbsp;&nbsp;Gets the statistics for a hopper.</span></span>

<a id="ID4EQC"></a>


## <a name="see-also"></a><span data-ttu-id="b9379-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="b9379-125">See also</span></span>

<a id="ID4ESC"></a>


##### <a name="parent"></a><span data-ttu-id="b9379-126">Parent</span><span class="sxs-lookup"><span data-stu-id="b9379-126">Parent</span></span>  

[<span data-ttu-id="b9379-127">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="b9379-127">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
