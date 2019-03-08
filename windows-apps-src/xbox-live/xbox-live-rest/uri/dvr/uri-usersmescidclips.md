---
title: /users/me/scids/{scid}/clips
assetID: ed8317f7-7898-47ad-d18d-cd5150daf293
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclips.html
description: " /users/me/scids/{scid}/clips"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 050d80be873d81e1db6a31742ceb6cfaf6602aaa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660067"
---
# <a name="usersmescidsscidclips"></a><span data-ttu-id="3f330-104">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="3f330-104">/users/me/scids/{scid}/clips</span></span>
<span data-ttu-id="3f330-105">初期のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="3f330-105">Access an initial upload request.</span></span> <span data-ttu-id="3f330-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="3f330-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="3f330-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f330-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3f330-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f330-108">URI parameters</span></span>
 
| <span data-ttu-id="3f330-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f330-109">Parameter</span></span>| <span data-ttu-id="3f330-110">種類</span><span class="sxs-lookup"><span data-stu-id="3f330-110">Type</span></span>| <span data-ttu-id="3f330-111">説明</span><span class="sxs-lookup"><span data-stu-id="3f330-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3f330-112">scid</span><span class="sxs-lookup"><span data-stu-id="3f330-112">scid</span></span>| <span data-ttu-id="3f330-113">string</span><span class="sxs-lookup"><span data-stu-id="3f330-113">string</span></span>| <span data-ttu-id="3f330-114">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="3f330-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="3f330-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f330-115">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="3f330-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="3f330-116">Valid methods</span></span>

[<span data-ttu-id="3f330-117">POST (/users/me/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="3f330-117">POST (/users/me/scids/{scid}/clips)</span></span>](uri-usersmescidclipspost.md)

<span data-ttu-id="3f330-118">&nbsp;&nbsp;初期アップロード要求を行います。</span><span class="sxs-lookup"><span data-stu-id="3f330-118">&nbsp;&nbsp;Make an initial upload request.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="3f330-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="3f330-119">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="3f330-120">Parent</span><span class="sxs-lookup"><span data-stu-id="3f330-120">Parent</span></span> 

[<span data-ttu-id="3f330-121">ゲーム録画 Uri</span><span class="sxs-lookup"><span data-stu-id="3f330-121">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   