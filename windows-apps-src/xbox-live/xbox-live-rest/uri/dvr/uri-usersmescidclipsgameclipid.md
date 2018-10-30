---
title: /users/me/scids/{scid}/clips/{gameClipId}
assetID: f5bead69-4fc9-f551-39cb-c8754645ac88
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipid.html
author: KevinAsgari
description: " /users/me/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 36be1a1f30c659bec70fdd67a02bbe5ad7ffad3d
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5747528"
---
# <a name="usersmescidsscidclipsgameclipid"></a><span data-ttu-id="81363-104">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="81363-104">/users/me/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="81363-105">ゲーム クリップ データへのアクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="81363-105">Access game clip data and metadata.</span></span> <span data-ttu-id="81363-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="81363-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="81363-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81363-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="81363-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81363-108">URI parameters</span></span>
 
| <span data-ttu-id="81363-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="81363-109">Parameter</span></span>| <span data-ttu-id="81363-110">型</span><span class="sxs-lookup"><span data-stu-id="81363-110">Type</span></span>| <span data-ttu-id="81363-111">説明</span><span class="sxs-lookup"><span data-stu-id="81363-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="81363-112">scid</span><span class="sxs-lookup"><span data-stu-id="81363-112">scid</span></span>| <span data-ttu-id="81363-113">string</span><span class="sxs-lookup"><span data-stu-id="81363-113">string</span></span>| <span data-ttu-id="81363-114">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="81363-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="81363-115">認証されたユーザーの SCID が一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="81363-115">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="81363-116">gameClipId</span><span class="sxs-lookup"><span data-stu-id="81363-116">gameClipId</span></span>| <span data-ttu-id="81363-117">string</span><span class="sxs-lookup"><span data-stu-id="81363-117">string</span></span>| <span data-ttu-id="81363-118">GameClip にアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="81363-118">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="81363-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="81363-119">Valid methods</span></span>

[<span data-ttu-id="81363-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="81363-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipiddelete.md)

<span data-ttu-id="81363-121">&nbsp;&nbsp;ゲーム クリップを削除します。</span><span class="sxs-lookup"><span data-stu-id="81363-121">&nbsp;&nbsp;Delete game clip</span></span>

[<span data-ttu-id="81363-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="81363-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipidpost.md)

<span data-ttu-id="81363-123">&nbsp;&nbsp;ユーザーのデータのゲーム クリップ メタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="81363-123">&nbsp;&nbsp;Update game clip metadata for the user's own data.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="81363-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="81363-124">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="81363-125">Parent</span><span class="sxs-lookup"><span data-stu-id="81363-125">Parent</span></span> 

[<span data-ttu-id="81363-126">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="81363-126">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   