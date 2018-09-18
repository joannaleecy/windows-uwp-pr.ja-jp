---
title: /users/xuid({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
author: KevinAsgari
description: " /users/xuid({xuid})/achievements/{scid}/{achievementid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58b4b5f8cf135aaaad5e23095c4c00278dcec83
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4019401"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a><span data-ttu-id="319d9-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span><span class="sxs-lookup"><span data-stu-id="319d9-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span></span>
<span data-ttu-id="319d9-105">構成済みのメタデータとユーザー固有のデータを含む、実績を詳しく説明を返します。</span><span class="sxs-lookup"><span data-stu-id="319d9-105">Returns details about the achievement, including its configured metadata and user-specific data.</span></span> 

> [!NOTE] 
> <span data-ttu-id="319d9-106">プラットフォームでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="319d9-106">Only supported for the platform.</span></span> 

 
<span data-ttu-id="319d9-107">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="319d9-107">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="319d9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="319d9-108">URI parameters</span></span>](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="319d9-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="319d9-109">URI parameters</span></span>
 
| <span data-ttu-id="319d9-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="319d9-110">Parameter</span></span>| <span data-ttu-id="319d9-111">型</span><span class="sxs-lookup"><span data-stu-id="319d9-111">Type</span></span>| <span data-ttu-id="319d9-112">説明</span><span class="sxs-lookup"><span data-stu-id="319d9-112">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="319d9-113">xuid</span><span class="sxs-lookup"><span data-stu-id="319d9-113">xuid</span></span>| <span data-ttu-id="319d9-114">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="319d9-114">64-bit unsigned integer</span></span>| <span data-ttu-id="319d9-115">Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="319d9-115">Xbox User ID (XUID) of the user whose resource is being accessed.</span></span> <span data-ttu-id="319d9-116">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="319d9-116">Must match the XUID of the authenticated user.</span></span>| 
| <span data-ttu-id="319d9-117">scid</span><span class="sxs-lookup"><span data-stu-id="319d9-117">scid</span></span>| <span data-ttu-id="319d9-118">GUID</span><span class="sxs-lookup"><span data-stu-id="319d9-118">GUID</span></span>| <span data-ttu-id="319d9-119">その実績にアクセスしているサービス構成の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="319d9-119">Unique identifier of the service configuration whose achievement is being accessed.</span></span>| 
| <span data-ttu-id="319d9-120">achievementid</span><span class="sxs-lookup"><span data-stu-id="319d9-120">achievementid</span></span>| <span data-ttu-id="319d9-121">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="319d9-121">32-bit unsigned integer</span></span>| <span data-ttu-id="319d9-122">アクセスされている実績の (指定された SCID) 内で一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="319d9-122">Unique (within the specified SCID) identifier of the achievement that is being accessed.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="319d9-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="319d9-123">Valid methods</span></span>

[<span data-ttu-id="319d9-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span><span class="sxs-lookup"><span data-stu-id="319d9-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span></span>](uri-usersxuidachievementsscidachievementidget.md)

<span data-ttu-id="319d9-125">&nbsp;&nbsp;実績の詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="319d9-125">&nbsp;&nbsp;Gets the details of the Achievement.</span></span>
 
<a id="ID4EWC"></a>

 
## <a name="see-also"></a><span data-ttu-id="319d9-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="319d9-126">See also</span></span>
 
<a id="ID4EYC"></a>

 
##### <a name="parent"></a><span data-ttu-id="319d9-127">Parent</span><span class="sxs-lookup"><span data-stu-id="319d9-127">Parent</span></span> 

[<span data-ttu-id="319d9-128">実績 URI</span><span class="sxs-lookup"><span data-stu-id="319d9-128">Achievements URIs</span></span>](atoc-reference-achievementsv2.md)

   