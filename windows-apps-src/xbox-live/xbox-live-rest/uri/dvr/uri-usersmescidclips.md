---
title: ユーザー/me/global/scids/{scid} クリップ/
assetID: ed8317f7-7898-47ad-d18d-cd5150daf293
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclips.html
author: KevinAsgari
description: " ユーザー/me/global/scids/{scid} クリップ/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ddb5800be9f96b7b90ed816f094cb38d83ee4727
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935138"
---
# <a name="usersmescidsscidclips"></a><span data-ttu-id="5408c-104">ユーザー/me/global/scids/{scid} クリップ/</span><span class="sxs-lookup"><span data-stu-id="5408c-104">/users/me/scids/{scid}/clips</span></span>
<span data-ttu-id="5408c-105">最初のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="5408c-105">Access an initial upload request.</span></span> <span data-ttu-id="5408c-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="5408c-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="5408c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5408c-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5408c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5408c-108">URI parameters</span></span>
 
| <span data-ttu-id="5408c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5408c-109">Parameter</span></span>| <span data-ttu-id="5408c-110">型</span><span class="sxs-lookup"><span data-stu-id="5408c-110">Type</span></span>| <span data-ttu-id="5408c-111">説明</span><span class="sxs-lookup"><span data-stu-id="5408c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5408c-112">scid</span><span class="sxs-lookup"><span data-stu-id="5408c-112">scid</span></span>| <span data-ttu-id="5408c-113">string</span><span class="sxs-lookup"><span data-stu-id="5408c-113">string</span></span>| <span data-ttu-id="5408c-114">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="5408c-114">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="5408c-115">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5408c-115">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5408c-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5408c-116">Valid methods</span></span>

[<span data-ttu-id="5408c-117">POST (ユーザー/me/global/scids/{scid} クリップ/)</span><span class="sxs-lookup"><span data-stu-id="5408c-117">POST (/users/me/scids/{scid}/clips)</span></span>](uri-usersmescidclipspost.md)

<span data-ttu-id="5408c-118">&nbsp;&nbsp;初期のアップロード要求を実行します。</span><span class="sxs-lookup"><span data-stu-id="5408c-118">&nbsp;&nbsp;Make an initial upload request.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="5408c-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="5408c-119">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="5408c-120">Parent</span><span class="sxs-lookup"><span data-stu-id="5408c-120">Parent</span></span> 

[<span data-ttu-id="5408c-121">ゲーム DVR Uri</span><span class="sxs-lookup"><span data-stu-id="5408c-121">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   