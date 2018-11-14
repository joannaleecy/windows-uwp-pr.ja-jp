---
title: /users/xuid({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
author: KevinAsgari
description: " /users/xuid({xuid})/achievements/{scid}/{achievementid}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9766222ea3a1c8671eadd42458b1c5aceaf0f587
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6269767"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a><span data-ttu-id="bd1e6-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span><span class="sxs-lookup"><span data-stu-id="bd1e6-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span></span>
<span data-ttu-id="bd1e6-105">構成済みのメタデータとユーザー固有のデータを含む、実績の詳細を返します。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-105">Returns details about the achievement, including its configured metadata and user-specific data.</span></span> 

> [!NOTE] 
> <span data-ttu-id="bd1e6-106">プラットフォームでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-106">Only supported for the platform.</span></span> 

 
<span data-ttu-id="bd1e6-107">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-107">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bd1e6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1e6-108">URI parameters</span></span>](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bd1e6-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1e6-109">URI parameters</span></span>
 
| <span data-ttu-id="bd1e6-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bd1e6-110">Parameter</span></span>| <span data-ttu-id="bd1e6-111">型</span><span class="sxs-lookup"><span data-stu-id="bd1e6-111">Type</span></span>| <span data-ttu-id="bd1e6-112">説明</span><span class="sxs-lookup"><span data-stu-id="bd1e6-112">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="bd1e6-113">xuid</span><span class="sxs-lookup"><span data-stu-id="bd1e6-113">xuid</span></span>| <span data-ttu-id="bd1e6-114">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bd1e6-114">64-bit unsigned integer</span></span>| <span data-ttu-id="bd1e6-115">Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザー。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-115">Xbox User ID (XUID) of the user whose resource is being accessed.</span></span> <span data-ttu-id="bd1e6-116">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-116">Must match the XUID of the authenticated user.</span></span>| 
| <span data-ttu-id="bd1e6-117">scid</span><span class="sxs-lookup"><span data-stu-id="bd1e6-117">scid</span></span>| <span data-ttu-id="bd1e6-118">GUID</span><span class="sxs-lookup"><span data-stu-id="bd1e6-118">GUID</span></span>| <span data-ttu-id="bd1e6-119">その実績にアクセスしているサービス構成の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-119">Unique identifier of the service configuration whose achievement is being accessed.</span></span>| 
| <span data-ttu-id="bd1e6-120">achievementid</span><span class="sxs-lookup"><span data-stu-id="bd1e6-120">achievementid</span></span>| <span data-ttu-id="bd1e6-121">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bd1e6-121">32-bit unsigned integer</span></span>| <span data-ttu-id="bd1e6-122">アクセスされている実績を (指定された SCID) 内で一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-122">Unique (within the specified SCID) identifier of the achievement that is being accessed.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="bd1e6-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="bd1e6-123">Valid methods</span></span>

[<span data-ttu-id="bd1e6-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span><span class="sxs-lookup"><span data-stu-id="bd1e6-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span></span>](uri-usersxuidachievementsscidachievementidget.md)

<span data-ttu-id="bd1e6-125">&nbsp;&nbsp;実績の詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="bd1e6-125">&nbsp;&nbsp;Gets the details of the Achievement.</span></span>
 
<a id="ID4EWC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bd1e6-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="bd1e6-126">See also</span></span>
 
<a id="ID4EYC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bd1e6-127">Parent</span><span class="sxs-lookup"><span data-stu-id="bd1e6-127">Parent</span></span> 

[<span data-ttu-id="bd1e6-128">実績 URI</span><span class="sxs-lookup"><span data-stu-id="bd1e6-128">Achievements URIs</span></span>](atoc-reference-achievementsv2.md)

   