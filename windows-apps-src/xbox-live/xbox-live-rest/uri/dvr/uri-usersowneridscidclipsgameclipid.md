---
title: /users/{ownerId}/scids/{scid}/clips/{gameClipId}
assetID: 49b68418-71f1-c5a2-3a9b-869fd1fa663c
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipid.html
author: KevinAsgari
description: " /users/{ownerId}/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5a1dc20b484b4125327f7357c79f3a64d6cf5001
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5876771"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="b2116-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="b2116-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="b2116-105">すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b2116-105">Access a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="b2116-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="b2116-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="b2116-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2116-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b2116-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2116-108">URI parameters</span></span>
 
| <span data-ttu-id="b2116-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2116-109">Parameter</span></span>| <span data-ttu-id="b2116-110">型</span><span class="sxs-lookup"><span data-stu-id="b2116-110">Type</span></span>| <span data-ttu-id="b2116-111">説明</span><span class="sxs-lookup"><span data-stu-id="b2116-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b2116-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="b2116-112">ownerId</span></span>| <span data-ttu-id="b2116-113">string</span><span class="sxs-lookup"><span data-stu-id="b2116-113">string</span></span>| <span data-ttu-id="b2116-114">リソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="b2116-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="b2116-115">サポートされる形式:"me"または"xuid(123456789)"します。</span><span class="sxs-lookup"><span data-stu-id="b2116-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="b2116-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="b2116-116">Maximum length: 16.</span></span>| 
| <span data-ttu-id="b2116-117">scid</span><span class="sxs-lookup"><span data-stu-id="b2116-117">scid</span></span>| <span data-ttu-id="b2116-118">string</span><span class="sxs-lookup"><span data-stu-id="b2116-118">string</span></span>| <span data-ttu-id="b2116-119">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="b2116-119">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="b2116-120">認証されたユーザーの SCID が一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b2116-120">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="b2116-121">gameClipId</span><span class="sxs-lookup"><span data-stu-id="b2116-121">gameClipId</span></span>| <span data-ttu-id="b2116-122">string</span><span class="sxs-lookup"><span data-stu-id="b2116-122">string</span></span>| <span data-ttu-id="b2116-123">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="b2116-123">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b2116-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b2116-124">Valid methods</span></span>

[<span data-ttu-id="b2116-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="b2116-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersowneridscidclipsgameclipidget.md)

<span data-ttu-id="b2116-126">&nbsp;&nbsp;すべての Id を見つけることがわかっている場合は、システムから 1 つのゲーム クリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="b2116-126">&nbsp;&nbsp;Get a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b2116-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="b2116-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b2116-128">Parent</span><span class="sxs-lookup"><span data-stu-id="b2116-128">Parent</span></span> 

[<span data-ttu-id="b2116-129">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="b2116-129">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   