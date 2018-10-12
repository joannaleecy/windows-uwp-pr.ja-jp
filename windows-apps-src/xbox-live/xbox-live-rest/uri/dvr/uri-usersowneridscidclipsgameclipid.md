---
title: /users/{ownerId}/scids/{scid}/clips/{gameClipId}
assetID: 49b68418-71f1-c5a2-3a9b-869fd1fa663c
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipid.html
author: KevinAsgari
description: " /users/{ownerId}/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d12f9e530ee6d703aa324cb6380591aab31facfd
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4567108"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="f58ad-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="f58ad-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="f58ad-105">すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="f58ad-105">Access a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="f58ad-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に問題の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="f58ad-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="f58ad-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f58ad-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f58ad-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f58ad-108">URI parameters</span></span>
 
| <span data-ttu-id="f58ad-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f58ad-109">Parameter</span></span>| <span data-ttu-id="f58ad-110">型</span><span class="sxs-lookup"><span data-stu-id="f58ad-110">Type</span></span>| <span data-ttu-id="f58ad-111">説明</span><span class="sxs-lookup"><span data-stu-id="f58ad-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f58ad-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="f58ad-112">ownerId</span></span>| <span data-ttu-id="f58ad-113">string</span><span class="sxs-lookup"><span data-stu-id="f58ad-113">string</span></span>| <span data-ttu-id="f58ad-114">リソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="f58ad-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="f58ad-115">サポートされる形式:"me"または"xuid(123456789)"。</span><span class="sxs-lookup"><span data-stu-id="f58ad-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="f58ad-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="f58ad-116">Maximum length: 16.</span></span>| 
| <span data-ttu-id="f58ad-117">scid</span><span class="sxs-lookup"><span data-stu-id="f58ad-117">scid</span></span>| <span data-ttu-id="f58ad-118">string</span><span class="sxs-lookup"><span data-stu-id="f58ad-118">string</span></span>| <span data-ttu-id="f58ad-119">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="f58ad-119">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="f58ad-120">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f58ad-120">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="f58ad-121">gameClipId</span><span class="sxs-lookup"><span data-stu-id="f58ad-121">gameClipId</span></span>| <span data-ttu-id="f58ad-122">string</span><span class="sxs-lookup"><span data-stu-id="f58ad-122">string</span></span>| <span data-ttu-id="f58ad-123">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="f58ad-123">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f58ad-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f58ad-124">Valid methods</span></span>

[<span data-ttu-id="f58ad-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="f58ad-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersowneridscidclipsgameclipidget.md)

<span data-ttu-id="f58ad-126">&nbsp;&nbsp;すべての Id を見つけることがわかっている場合は、システムから 1 つのゲーム クリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="f58ad-126">&nbsp;&nbsp;Get a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f58ad-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="f58ad-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f58ad-128">Parent</span><span class="sxs-lookup"><span data-stu-id="f58ad-128">Parent</span></span> 

[<span data-ttu-id="f58ad-129">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="f58ad-129">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   