---
title: /users/me/scids/{scid}/clips/{gameClipId}
assetID: f5bead69-4fc9-f551-39cb-c8754645ac88
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipsgameclipid.html
description: " /users/me/scids/{scid}/clips/{gameClipId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3cbe2d2c996b466fd94287129f1add0868f05b05
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661777"
---
# <a name="usersmescidsscidclipsgameclipid"></a><span data-ttu-id="b1661-104">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="b1661-104">/users/me/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="b1661-105">ゲームのクリップのデータ アクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="b1661-105">Access game clip data and metadata.</span></span> <span data-ttu-id="b1661-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="b1661-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="b1661-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b1661-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b1661-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b1661-108">URI parameters</span></span>
 
| <span data-ttu-id="b1661-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b1661-109">Parameter</span></span>| <span data-ttu-id="b1661-110">種類</span><span class="sxs-lookup"><span data-stu-id="b1661-110">Type</span></span>| <span data-ttu-id="b1661-111">説明</span><span class="sxs-lookup"><span data-stu-id="b1661-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b1661-112">scid</span><span class="sxs-lookup"><span data-stu-id="b1661-112">scid</span></span>| <span data-ttu-id="b1661-113">string</span><span class="sxs-lookup"><span data-stu-id="b1661-113">string</span></span>| <span data-ttu-id="b1661-114">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="b1661-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="b1661-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1661-115">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="b1661-116">gameClipId</span><span class="sxs-lookup"><span data-stu-id="b1661-116">gameClipId</span></span>| <span data-ttu-id="b1661-117">string</span><span class="sxs-lookup"><span data-stu-id="b1661-117">string</span></span>| <span data-ttu-id="b1661-118">アクセスされているリソースの ID をゲーム クリップだった。</span><span class="sxs-lookup"><span data-stu-id="b1661-118">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b1661-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b1661-119">Valid methods</span></span>

[<span data-ttu-id="b1661-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="b1661-120">DELETE (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipiddelete.md)

<span data-ttu-id="b1661-121">&nbsp;&nbsp;ゲームのクリップを削除します。</span><span class="sxs-lookup"><span data-stu-id="b1661-121">&nbsp;&nbsp;Delete game clip</span></span>

[<span data-ttu-id="b1661-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="b1661-122">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersmescidclipsgameclipidpost.md)

<span data-ttu-id="b1661-123">&nbsp;&nbsp;ユーザーのデータのゲームのクリップのメタデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="b1661-123">&nbsp;&nbsp;Update game clip metadata for the user's own data.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b1661-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="b1661-124">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b1661-125">Parent</span><span class="sxs-lookup"><span data-stu-id="b1661-125">Parent</span></span> 

[<span data-ttu-id="b1661-126">ゲーム録画 Uri</span><span class="sxs-lookup"><span data-stu-id="b1661-126">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   