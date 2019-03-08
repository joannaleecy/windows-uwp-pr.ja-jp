---
title: /public/scids/{scid}/clips
assetID: 55a1f0ae-08bb-6d1e-a1da-cbeb481c42ee
permalink: en-us/docs/xboxlive/rest/uri-publicscidclips.html
description: " /public/scids/{scid}/clips"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: db279d546780ed40158894f73ecb84687ef35ba6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627977"
---
# <a name="publicscidsscidclips"></a><span data-ttu-id="ebc08-104">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="ebc08-104">/public/scids/{scid}/clips</span></span>
<span data-ttu-id="ebc08-105">クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ebc08-105">Access public clips.</span></span> <span data-ttu-id="ebc08-106">この URI 実際に指定できます 2 つの形式で`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="ebc08-106">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="ebc08-107">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebc08-107">See below for more details.</span></span> <span data-ttu-id="ebc08-108">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ebc08-108">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ebc08-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebc08-109">URI parameters</span></span>](#ID4E1)
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ebc08-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebc08-110">URI parameters</span></span>
 
| <span data-ttu-id="ebc08-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebc08-111">Parameter</span></span>| <span data-ttu-id="ebc08-112">種類</span><span class="sxs-lookup"><span data-stu-id="ebc08-112">Type</span></span>| <span data-ttu-id="ebc08-113">説明</span><span class="sxs-lookup"><span data-stu-id="ebc08-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ebc08-114">scid</span><span class="sxs-lookup"><span data-stu-id="ebc08-114">scid</span></span>| <span data-ttu-id="ebc08-115">string</span><span class="sxs-lookup"><span data-stu-id="ebc08-115">string</span></span>| <span data-ttu-id="ebc08-116">パブリックのクリップをプライマリ サービスの構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="ebc08-116">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="ebc08-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="ebc08-117">titleid</span></span>| <span data-ttu-id="ebc08-118">string</span><span class="sxs-lookup"><span data-stu-id="ebc08-118">string</span></span>| <span data-ttu-id="ebc08-119">パブリックのクリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="ebc08-119">The titleId of the public clips.</span></span> <span data-ttu-id="ebc08-120">同じ URI、SCID としてでは指定できません。</span><span class="sxs-lookup"><span data-stu-id="ebc08-120">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="ebc08-121">指定した場合は、プライマリ SCID 検索に使用されます。</span><span class="sxs-lookup"><span data-stu-id="ebc08-121">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ebc08-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ebc08-122">Valid methods</span></span>

[<span data-ttu-id="ebc08-123">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="ebc08-123">GET (/public/scids/{scid}/clips)</span></span>](uri-publicscidclipsget.md)

<span data-ttu-id="ebc08-124">&nbsp;&nbsp;パブリックのクリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="ebc08-124">&nbsp;&nbsp;List public clips.</span></span>
 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ebc08-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="ebc08-125">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ebc08-126">Parent</span><span class="sxs-lookup"><span data-stu-id="ebc08-126">Parent</span></span> 

[<span data-ttu-id="ebc08-127">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="ebc08-127">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

   