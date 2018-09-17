---
title: /users/me/scids/{scid}/clips/{gameClipId}
assetID: f5bead69-4fc9-f551-39cb-c8754645ac88
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipid.html
author: KevinAsgari
description: " /users/me/scids/{scid}/clips/{gameClipId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6b5d33a8bb8b0f21ea05ac22a7d15ccb4b160b9a
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3985194"
---
# <a name="usersmescidsscidclipsgameclipid"></a><span data-ttu-id="df1ca-104">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="df1ca-104">/users/me/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="df1ca-105">ゲーム クリップ データへのアクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="df1ca-105">Access game clip data and metadata.</span></span> <span data-ttu-id="df1ca-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="df1ca-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="df1ca-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="df1ca-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="df1ca-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="df1ca-108">URI parameters</span></span>
 
| <span data-ttu-id="df1ca-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="df1ca-109">Parameter</span></span>| <span data-ttu-id="df1ca-110">型</span><span class="sxs-lookup"><span data-stu-id="df1ca-110">Type</span></span>| <span data-ttu-id="df1ca-111">説明</span><span class="sxs-lookup"><span data-stu-id="df1ca-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="df1ca-112">scid</span><span class="sxs-lookup"><span data-stu-id="df1ca-112">scid</span></span>| <span data-ttu-id="df1ca-113">string</span><span class="sxs-lookup"><span data-stu-id="df1ca-113">string</span></span>| <span data-ttu-id="df1ca-114">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="df1ca-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="df1ca-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="df1ca-115">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="df1ca-116">gameClipId</span><span class="sxs-lookup"><span data-stu-id="df1ca-116">gameClipId</span></span>| <span data-ttu-id="df1ca-117">string</span><span class="sxs-lookup"><span data-stu-id="df1ca-117">string</span></span>| <span data-ttu-id="df1ca-118">ゲーム クリップだったにアクセスしているリソースの ID です。</span><span class="sxs-lookup"><span data-stu-id="df1ca-118">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="df1ca-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="df1ca-119">Valid methods</span></span>

[<span data-ttu-id="df1ca-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="df1ca-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipiddelete.md)

<span data-ttu-id="df1ca-121">&nbsp;&nbsp;ゲーム クリップを削除します。</span><span class="sxs-lookup"><span data-stu-id="df1ca-121">&nbsp;&nbsp;Delete game clip</span></span>

[<span data-ttu-id="df1ca-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="df1ca-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipidpost.md)

<span data-ttu-id="df1ca-123">&nbsp;&nbsp;ユーザーのデータのゲーム クリップ メタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="df1ca-123">&nbsp;&nbsp;Update game clip metadata for the user's own data.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="df1ca-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="df1ca-124">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="df1ca-125">Parent</span><span class="sxs-lookup"><span data-stu-id="df1ca-125">Parent</span></span> 

[<span data-ttu-id="df1ca-126">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="df1ca-126">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   