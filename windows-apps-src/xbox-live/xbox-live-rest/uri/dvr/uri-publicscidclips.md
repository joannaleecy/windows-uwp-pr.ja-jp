---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " /public/scids/{scid}/clips"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e6257ba44f9bf32046a3850adc05a699156e67d6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5555583"
---
# <a name="publicscidsscidclips"></a><span data-ttu-id="50e96-104">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="50e96-104">/public/scids/{scid}/clips</span></span>
<span data-ttu-id="50e96-105">クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="50e96-105">Access public clips.</span></span> <span data-ttu-id="50e96-106">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="50e96-106">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="50e96-107">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="50e96-107">See below for more details.</span></span> <span data-ttu-id="50e96-108">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="50e96-108">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="50e96-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="50e96-109">URI parameters</span></span>](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="50e96-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="50e96-110">URI parameters</span></span>
 
| <span data-ttu-id="50e96-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="50e96-111">Parameter</span></span>| <span data-ttu-id="50e96-112">型</span><span class="sxs-lookup"><span data-stu-id="50e96-112">Type</span></span>| <span data-ttu-id="50e96-113">説明</span><span class="sxs-lookup"><span data-stu-id="50e96-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="50e96-114">scid</span><span class="sxs-lookup"><span data-stu-id="50e96-114">scid</span></span>| <span data-ttu-id="50e96-115">string</span><span class="sxs-lookup"><span data-stu-id="50e96-115">string</span></span>| <span data-ttu-id="50e96-116">パブリック クリップをプライマリー サービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="50e96-116">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="50e96-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="50e96-117">titleid</span></span>| <span data-ttu-id="50e96-118">string</span><span class="sxs-lookup"><span data-stu-id="50e96-118">string</span></span>| <span data-ttu-id="50e96-119">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="50e96-119">The titleId of the public clips.</span></span> <span data-ttu-id="50e96-120">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="50e96-120">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="50e96-121">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="50e96-121">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="50e96-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="50e96-122">Valid methods</span></span>

[<span data-ttu-id="50e96-123">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="50e96-123">GET (/public/scids/{scid}/clips)</span></span>](uri-publicscidclipsget.md)

<span data-ttu-id="50e96-124">&nbsp;&nbsp;パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="50e96-124">&nbsp;&nbsp;List public clips.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="50e96-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="50e96-125">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="50e96-126">Parent</span><span class="sxs-lookup"><span data-stu-id="50e96-126">Parent</span></span> 

[<span data-ttu-id="50e96-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="50e96-127">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

   