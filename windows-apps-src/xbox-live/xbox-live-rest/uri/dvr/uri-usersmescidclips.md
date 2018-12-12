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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8934489"
---
# <a name="usersmescidsscidclips"></a><span data-ttu-id="ffa18-104">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="ffa18-104">/users/me/scids/{scid}/clips</span></span>
<span data-ttu-id="ffa18-105">最初のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="ffa18-105">Access an initial upload request.</span></span> <span data-ttu-id="ffa18-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="ffa18-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="ffa18-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffa18-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ffa18-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffa18-108">URI parameters</span></span>
 
| <span data-ttu-id="ffa18-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffa18-109">Parameter</span></span>| <span data-ttu-id="ffa18-110">型</span><span class="sxs-lookup"><span data-stu-id="ffa18-110">Type</span></span>| <span data-ttu-id="ffa18-111">説明</span><span class="sxs-lookup"><span data-stu-id="ffa18-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ffa18-112">scid</span><span class="sxs-lookup"><span data-stu-id="ffa18-112">scid</span></span>| <span data-ttu-id="ffa18-113">string</span><span class="sxs-lookup"><span data-stu-id="ffa18-113">string</span></span>| <span data-ttu-id="ffa18-114">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="ffa18-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="ffa18-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ffa18-115">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ffa18-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ffa18-116">Valid methods</span></span>

[<span data-ttu-id="ffa18-117">POST (/users/me/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="ffa18-117">POST (/users/me/scids/{scid}/clips)</span></span>](uri-usersmescidclipspost.md)

<span data-ttu-id="ffa18-118">&nbsp;&nbsp;初期のアップロード要求を実行します。</span><span class="sxs-lookup"><span data-stu-id="ffa18-118">&nbsp;&nbsp;Make an initial upload request.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="ffa18-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="ffa18-119">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="ffa18-120">Parent</span><span class="sxs-lookup"><span data-stu-id="ffa18-120">Parent</span></span> 

[<span data-ttu-id="ffa18-121">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="ffa18-121">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   