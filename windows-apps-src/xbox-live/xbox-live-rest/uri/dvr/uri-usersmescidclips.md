---
title: /users/me/scids/{scid}/clips
assetID: ed8317f7-7898-47ad-d18d-cd5150daf293
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclips.html
author: KevinAsgari
description: " /users/me/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ddb5800be9f96b7b90ed816f094cb38d83ee4727
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5400665"
---
# <a name="usersmescidsscidclips"></a><span data-ttu-id="39afc-104">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="39afc-104">/users/me/scids/{scid}/clips</span></span>
<span data-ttu-id="39afc-105">最初のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="39afc-105">Access an initial upload request.</span></span> <span data-ttu-id="39afc-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="39afc-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="39afc-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="39afc-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="39afc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="39afc-108">URI parameters</span></span>
 
| <span data-ttu-id="39afc-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="39afc-109">Parameter</span></span>| <span data-ttu-id="39afc-110">型</span><span class="sxs-lookup"><span data-stu-id="39afc-110">Type</span></span>| <span data-ttu-id="39afc-111">説明</span><span class="sxs-lookup"><span data-stu-id="39afc-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="39afc-112">scid</span><span class="sxs-lookup"><span data-stu-id="39afc-112">scid</span></span>| <span data-ttu-id="39afc-113">string</span><span class="sxs-lookup"><span data-stu-id="39afc-113">string</span></span>| <span data-ttu-id="39afc-114">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="39afc-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="39afc-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39afc-115">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="39afc-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="39afc-116">Valid methods</span></span>

[<span data-ttu-id="39afc-117">POST (/users/me/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="39afc-117">POST (/users/me/scids/{scid}/clips)</span></span>](uri-usersmescidclipspost.md)

<span data-ttu-id="39afc-118">&nbsp;&nbsp;初期のアップロード要求を実行します。</span><span class="sxs-lookup"><span data-stu-id="39afc-118">&nbsp;&nbsp;Make an initial upload request.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="39afc-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="39afc-119">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="39afc-120">Parent</span><span class="sxs-lookup"><span data-stu-id="39afc-120">Parent</span></span> 

[<span data-ttu-id="39afc-121">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="39afc-121">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   