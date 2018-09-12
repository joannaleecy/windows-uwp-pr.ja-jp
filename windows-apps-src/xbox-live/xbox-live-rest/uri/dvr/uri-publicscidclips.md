---
title: パブリック//global/scids/{scid} クリップ/
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
author: KevinAsgari
description: " パブリック//global/scids/{scid} クリップ/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b7c0c664b7fdff7eae607acdc4dd7ef78aeb3caf
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3932548"
---
# <a name="publicscidsscidclips"></a><span data-ttu-id="29a55-104">パブリック//global/scids/{scid} クリップ/</span><span class="sxs-lookup"><span data-stu-id="29a55-104">/public/scids/{scid}/clips</span></span>
<span data-ttu-id="29a55-105">クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="29a55-105">Access public clips.</span></span> <span data-ttu-id="29a55-106">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="29a55-106">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="29a55-107">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="29a55-107">See below for more details.</span></span> <span data-ttu-id="29a55-108">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="29a55-108">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="29a55-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="29a55-109">URI parameters</span></span>](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="29a55-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="29a55-110">URI parameters</span></span>
 
| <span data-ttu-id="29a55-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="29a55-111">Parameter</span></span>| <span data-ttu-id="29a55-112">型</span><span class="sxs-lookup"><span data-stu-id="29a55-112">Type</span></span>| <span data-ttu-id="29a55-113">説明</span><span class="sxs-lookup"><span data-stu-id="29a55-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="29a55-114">scid</span><span class="sxs-lookup"><span data-stu-id="29a55-114">scid</span></span>| <span data-ttu-id="29a55-115">string</span><span class="sxs-lookup"><span data-stu-id="29a55-115">string</span></span>| <span data-ttu-id="29a55-116">パブリック クリップの主要なサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="29a55-116">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="29a55-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="29a55-117">titleid</span></span>| <span data-ttu-id="29a55-118">string</span><span class="sxs-lookup"><span data-stu-id="29a55-118">string</span></span>| <span data-ttu-id="29a55-119">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="29a55-119">The titleId of the public clips.</span></span> <span data-ttu-id="29a55-120">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="29a55-120">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="29a55-121">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="29a55-121">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="29a55-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="29a55-122">Valid methods</span></span>

[<span data-ttu-id="29a55-123">取得する (パブリック//global/scids/{scid} クリップ/)</span><span class="sxs-lookup"><span data-stu-id="29a55-123">GET (/public/scids/{scid}/clips)</span></span>](uri-publicscidclipsget.md)

<span data-ttu-id="29a55-124">&nbsp;&nbsp;パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="29a55-124">&nbsp;&nbsp;List public clips.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="29a55-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="29a55-125">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="29a55-126">Parent</span><span class="sxs-lookup"><span data-stu-id="29a55-126">Parent</span></span> 

[<span data-ttu-id="29a55-127">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="29a55-127">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

   