---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " /public/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 131a1eb67d4a33c3fbd2f5f818499ffeea851f3d
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5926711"
---
# <a name="publicscidsscidclips"></a><span data-ttu-id="e04d2-104">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="e04d2-104">/public/scids/{scid}/clips</span></span>
<span data-ttu-id="e04d2-105">クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e04d2-105">Access public clips.</span></span> <span data-ttu-id="e04d2-106">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="e04d2-106">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="e04d2-107">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e04d2-107">See below for more details.</span></span> <span data-ttu-id="e04d2-108">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e04d2-108">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e04d2-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e04d2-109">URI parameters</span></span>](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e04d2-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e04d2-110">URI parameters</span></span>
 
| <span data-ttu-id="e04d2-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e04d2-111">Parameter</span></span>| <span data-ttu-id="e04d2-112">型</span><span class="sxs-lookup"><span data-stu-id="e04d2-112">Type</span></span>| <span data-ttu-id="e04d2-113">説明</span><span class="sxs-lookup"><span data-stu-id="e04d2-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e04d2-114">scid</span><span class="sxs-lookup"><span data-stu-id="e04d2-114">scid</span></span>| <span data-ttu-id="e04d2-115">string</span><span class="sxs-lookup"><span data-stu-id="e04d2-115">string</span></span>| <span data-ttu-id="e04d2-116">パブリック クリップをプライマリー サービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="e04d2-116">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="e04d2-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="e04d2-117">titleid</span></span>| <span data-ttu-id="e04d2-118">string</span><span class="sxs-lookup"><span data-stu-id="e04d2-118">string</span></span>| <span data-ttu-id="e04d2-119">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="e04d2-119">The titleId of the public clips.</span></span> <span data-ttu-id="e04d2-120">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="e04d2-120">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="e04d2-121">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="e04d2-121">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e04d2-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e04d2-122">Valid methods</span></span>

[<span data-ttu-id="e04d2-123">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="e04d2-123">GET (/public/scids/{scid}/clips)</span></span>](uri-publicscidclipsget.md)

<span data-ttu-id="e04d2-124">&nbsp;&nbsp;パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="e04d2-124">&nbsp;&nbsp;List public clips.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e04d2-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="e04d2-125">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e04d2-126">Parent</span><span class="sxs-lookup"><span data-stu-id="e04d2-126">Parent</span></span> 

[<span data-ttu-id="e04d2-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="e04d2-127">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

   