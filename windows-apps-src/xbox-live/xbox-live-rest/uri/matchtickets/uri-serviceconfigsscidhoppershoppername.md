---
title: /serviceconfigs/{scid}/hoppers/{hoppername}
assetID: ba1e129d-b4c4-6535-46ce-fd184465c85f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppername.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/hoppers/{hoppername}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e02a4ea5ba9c21337032daad44579f6001360cd
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4740435"
---
# <a name="serviceconfigsscidhoppershoppername"></a><span data-ttu-id="da43c-104">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="da43c-104">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>

<span data-ttu-id="da43c-105">マッチ チケットを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="da43c-105">Supports a POST operation to create match tickets.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="da43c-106">この URI コントラクト 103 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="da43c-106">This URI is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="da43c-107">ドメイン</span><span class="sxs-lookup"><span data-stu-id="da43c-107">Domain</span></span>
<span data-ttu-id="da43c-108">momatch.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="da43c-108">momatch.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="da43c-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da43c-109">URI parameters</span></span>

| <span data-ttu-id="da43c-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="da43c-110">Parameter</span></span>| <span data-ttu-id="da43c-111">型</span><span class="sxs-lookup"><span data-stu-id="da43c-111">Type</span></span>| <span data-ttu-id="da43c-112">説明</span><span class="sxs-lookup"><span data-stu-id="da43c-112">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="da43c-113">scid</span><span class="sxs-lookup"><span data-stu-id="da43c-113">scid</span></span>| <span data-ttu-id="da43c-114">GUID</span><span class="sxs-lookup"><span data-stu-id="da43c-114">GUID</span></span>| <span data-ttu-id="da43c-115">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="da43c-115">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="da43c-116">hoppername</span><span class="sxs-lookup"><span data-stu-id="da43c-116">hoppername</span></span> | <span data-ttu-id="da43c-117">string</span><span class="sxs-lookup"><span data-stu-id="da43c-117">string</span></span> | <span data-ttu-id="da43c-118">ホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="da43c-118">The name of the hopper.</span></span> |

<a id="ID4E2B"></a>


## <a name="valid-methods"></a><span data-ttu-id="da43c-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="da43c-119">Valid methods</span></span>

[<span data-ttu-id="da43c-120">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span><span class="sxs-lookup"><span data-stu-id="da43c-120">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span></span>](uri-serviceconfigsscidhoppershoppernamepost.md)

<span data-ttu-id="da43c-121">&nbsp;&nbsp;指定したマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="da43c-121">&nbsp;&nbsp;Creates the specified match ticket.</span></span>

<a id="ID4EFC"></a>


## <a name="see-also"></a><span data-ttu-id="da43c-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="da43c-122">See also</span></span>

<a id="ID4EHC"></a>


##### <a name="parent"></a><span data-ttu-id="da43c-123">Parent</span><span class="sxs-lookup"><span data-stu-id="da43c-123">Parent</span></span>  

[<span data-ttu-id="da43c-124">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="da43c-124">Matchmaking URIs</span></span>](atoc-reference-matchtickets.md)
