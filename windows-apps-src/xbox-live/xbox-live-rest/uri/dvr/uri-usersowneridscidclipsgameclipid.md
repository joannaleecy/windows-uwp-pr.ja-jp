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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882160"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="aa2e4-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="aa2e4-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="aa2e4-105">すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-105">Access a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="aa2e4-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="aa2e4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="aa2e4-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="aa2e4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="aa2e4-108">URI parameters</span></span>
 
| <span data-ttu-id="aa2e4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="aa2e4-109">Parameter</span></span>| <span data-ttu-id="aa2e4-110">型</span><span class="sxs-lookup"><span data-stu-id="aa2e4-110">Type</span></span>| <span data-ttu-id="aa2e4-111">説明</span><span class="sxs-lookup"><span data-stu-id="aa2e4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="aa2e4-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="aa2e4-112">ownerId</span></span>| <span data-ttu-id="aa2e4-113">string</span><span class="sxs-lookup"><span data-stu-id="aa2e4-113">string</span></span>| <span data-ttu-id="aa2e4-114">そのリソースにアクセスしているユーザーのユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="aa2e4-115">サポートされる形式:"me"または"xuid(123456789)"。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="aa2e4-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-116">Maximum length: 16.</span></span>| 
| <span data-ttu-id="aa2e4-117">scid</span><span class="sxs-lookup"><span data-stu-id="aa2e4-117">scid</span></span>| <span data-ttu-id="aa2e4-118">string</span><span class="sxs-lookup"><span data-stu-id="aa2e4-118">string</span></span>| <span data-ttu-id="aa2e4-119">アクセスしているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-119">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="aa2e4-120">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-120">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="aa2e4-121">gameClipId</span><span class="sxs-lookup"><span data-stu-id="aa2e4-121">gameClipId</span></span>| <span data-ttu-id="aa2e4-122">string</span><span class="sxs-lookup"><span data-stu-id="aa2e4-122">string</span></span>| <span data-ttu-id="aa2e4-123">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-123">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="aa2e4-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="aa2e4-124">Valid methods</span></span>

[<span data-ttu-id="aa2e4-125">(/Users/{ownerId}/scids/{scid}/clips/{gameClipId}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersowneridscidclipsgameclipidget.md)

<span data-ttu-id="aa2e4-126">&nbsp;&nbsp;すべての Id を見つけることがわかっている場合、システムから 1 つのゲーム クリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="aa2e4-126">&nbsp;&nbsp;Get a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="aa2e4-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="aa2e4-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="aa2e4-128">Parent</span><span class="sxs-lookup"><span data-stu-id="aa2e4-128">Parent</span></span> 

[<span data-ttu-id="aa2e4-129">ゲーム DVR Uri</span><span class="sxs-lookup"><span data-stu-id="aa2e4-129">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   