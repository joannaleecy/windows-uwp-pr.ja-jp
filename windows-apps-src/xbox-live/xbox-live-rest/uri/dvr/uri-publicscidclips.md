---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " /public/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b7c0c664b7fdff7eae607acdc4dd7ef78aeb3caf
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4572461"
---
# <a name="publicscidsscidclips"></a><span data-ttu-id="b19ed-104">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="b19ed-104">/public/scids/{scid}/clips</span></span>
<span data-ttu-id="b19ed-105">クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b19ed-105">Access public clips.</span></span> <span data-ttu-id="b19ed-106">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="b19ed-106">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="b19ed-107">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b19ed-107">See below for more details.</span></span> <span data-ttu-id="b19ed-108">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b19ed-108">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b19ed-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b19ed-109">URI parameters</span></span>](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b19ed-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b19ed-110">URI parameters</span></span>
 
| <span data-ttu-id="b19ed-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b19ed-111">Parameter</span></span>| <span data-ttu-id="b19ed-112">型</span><span class="sxs-lookup"><span data-stu-id="b19ed-112">Type</span></span>| <span data-ttu-id="b19ed-113">説明</span><span class="sxs-lookup"><span data-stu-id="b19ed-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b19ed-114">scid</span><span class="sxs-lookup"><span data-stu-id="b19ed-114">scid</span></span>| <span data-ttu-id="b19ed-115">string</span><span class="sxs-lookup"><span data-stu-id="b19ed-115">string</span></span>| <span data-ttu-id="b19ed-116">パブリック クリップの主要なサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="b19ed-116">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="b19ed-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="b19ed-117">titleid</span></span>| <span data-ttu-id="b19ed-118">string</span><span class="sxs-lookup"><span data-stu-id="b19ed-118">string</span></span>| <span data-ttu-id="b19ed-119">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="b19ed-119">The titleId of the public clips.</span></span> <span data-ttu-id="b19ed-120">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="b19ed-120">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="b19ed-121">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="b19ed-121">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b19ed-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b19ed-122">Valid methods</span></span>

[<span data-ttu-id="b19ed-123">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="b19ed-123">GET (/public/scids/{scid}/clips)</span></span>](uri-publicscidclipsget.md)

<span data-ttu-id="b19ed-124">&nbsp;&nbsp;パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="b19ed-124">&nbsp;&nbsp;List public clips.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b19ed-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="b19ed-125">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b19ed-126">Parent</span><span class="sxs-lookup"><span data-stu-id="b19ed-126">Parent</span></span> 

[<span data-ttu-id="b19ed-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="b19ed-127">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

   