---
title: /users/xuid({xuid})/achievements/{scid}/{achievementid}
assetID: 656a6d63-1a11-b0a5-63d2-2b010abd62e7
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementid.html
description: " /users/xuid({xuid})/achievements/{scid}/{achievementid}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 00c577f60b67f15f75c47b5e737ca12819695110
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8339662"
---
# <a name="usersxuidxuidachievementsscidachievementid"></a><span data-ttu-id="9ee25-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span><span class="sxs-lookup"><span data-stu-id="9ee25-104">/users/xuid({xuid})/achievements/{scid}/{achievementid}</span></span>
<span data-ttu-id="9ee25-105">構成済みのメタデータとユーザー固有のデータを含む、実績についての詳細を返します。</span><span class="sxs-lookup"><span data-stu-id="9ee25-105">Returns details about the achievement, including its configured metadata and user-specific data.</span></span> 

> [!NOTE] 
> <span data-ttu-id="9ee25-106">プラットフォームでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="9ee25-106">Only supported for the platform.</span></span> 

 
<span data-ttu-id="9ee25-107">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9ee25-107">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9ee25-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9ee25-108">URI parameters</span></span>](#ID4E2)
 
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9ee25-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9ee25-109">URI parameters</span></span>
 
| <span data-ttu-id="9ee25-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9ee25-110">Parameter</span></span>| <span data-ttu-id="9ee25-111">型</span><span class="sxs-lookup"><span data-stu-id="9ee25-111">Type</span></span>| <span data-ttu-id="9ee25-112">説明</span><span class="sxs-lookup"><span data-stu-id="9ee25-112">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="9ee25-113">xuid</span><span class="sxs-lookup"><span data-stu-id="9ee25-113">xuid</span></span>| <span data-ttu-id="9ee25-114">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9ee25-114">64-bit unsigned integer</span></span>| <span data-ttu-id="9ee25-115">Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザー。</span><span class="sxs-lookup"><span data-stu-id="9ee25-115">Xbox User ID (XUID) of the user whose resource is being accessed.</span></span> <span data-ttu-id="9ee25-116">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9ee25-116">Must match the XUID of the authenticated user.</span></span>| 
| <span data-ttu-id="9ee25-117">scid</span><span class="sxs-lookup"><span data-stu-id="9ee25-117">scid</span></span>| <span data-ttu-id="9ee25-118">GUID</span><span class="sxs-lookup"><span data-stu-id="9ee25-118">GUID</span></span>| <span data-ttu-id="9ee25-119">その実績にアクセスしているサービス構成の一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="9ee25-119">Unique identifier of the service configuration whose achievement is being accessed.</span></span>| 
| <span data-ttu-id="9ee25-120">achievementid</span><span class="sxs-lookup"><span data-stu-id="9ee25-120">achievementid</span></span>| <span data-ttu-id="9ee25-121">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9ee25-121">32-bit unsigned integer</span></span>| <span data-ttu-id="9ee25-122">アクセスされている実績を (指定された SCID) 内で一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="9ee25-122">Unique (within the specified SCID) identifier of the achievement that is being accessed.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9ee25-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9ee25-123">Valid methods</span></span>

[<span data-ttu-id="9ee25-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span><span class="sxs-lookup"><span data-stu-id="9ee25-124">GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})</span></span>](uri-usersxuidachievementsscidachievementidget.md)

<span data-ttu-id="9ee25-125">&nbsp;&nbsp;実績の詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="9ee25-125">&nbsp;&nbsp;Gets the details of the Achievement.</span></span>
 
<a id="ID4EWC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9ee25-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="9ee25-126">See also</span></span>
 
<a id="ID4EYC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9ee25-127">Parent</span><span class="sxs-lookup"><span data-stu-id="9ee25-127">Parent</span></span> 

[<span data-ttu-id="9ee25-128">実績 URI</span><span class="sxs-lookup"><span data-stu-id="9ee25-128">Achievements URIs</span></span>](atoc-reference-achievementsv2.md)

   