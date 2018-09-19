---
title: /users/xuid({xuid})/achievements
assetID: 4dd89962-ab73-c25b-7a11-3ed35475492e
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsv2.html
author: KevinAsgari
description: " /users/xuid({xuid})/achievements"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3ece582e46601fd63ba16a99a071ae40ecaff2d4
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055959"
---
# <a name="usersxuidxuidachievements"></a><span data-ttu-id="14d3d-104">/users/xuid({xuid})/achievements</span><span class="sxs-lookup"><span data-stu-id="14d3d-104">/users/xuid({xuid})/achievements</span></span>
 
<span data-ttu-id="14d3d-105">このユニバーサル Resource Identifier (URI) は、ユーザーの実績へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="14d3d-105">This Universal Resource Identifier (URI) provides access to user achievements.</span></span>
 
<span data-ttu-id="14d3d-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="14d3d-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="14d3d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="14d3d-107">URI parameters</span></span>
 
| <span data-ttu-id="14d3d-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="14d3d-108">Parameter</span></span>| <span data-ttu-id="14d3d-109">型</span><span class="sxs-lookup"><span data-stu-id="14d3d-109">Type</span></span>| <span data-ttu-id="14d3d-110">説明</span><span class="sxs-lookup"><span data-stu-id="14d3d-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="14d3d-111">xuid</span><span class="sxs-lookup"><span data-stu-id="14d3d-111">xuid</span></span>| <span data-ttu-id="14d3d-112">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="14d3d-112">64-bit unsigned integer</span></span>| <span data-ttu-id="14d3d-113">Xbox ユーザー ID (XUID) が (リソース) にアクセスしているユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="14d3d-113">Xbox User ID (XUID) of the user whose (resource) is being accessed.</span></span> <span data-ttu-id="14d3d-114">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14d3d-114">Must match the XUID of the authenticated user.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="14d3d-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="14d3d-115">Valid methods</span></span>

[<span data-ttu-id="14d3d-116">GET</span><span class="sxs-lookup"><span data-stu-id="14d3d-116">GET</span></span>](uri-achievementsusersxuidachievementsgetv2.md)

<span data-ttu-id="14d3d-117">&nbsp;&nbsp;タイトル、進行中のユーザーが持っているまたは、ユーザーがロックを解除するもので定義されている実績の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="14d3d-117">&nbsp;&nbsp;Gets the list of achievements defined on the title, those unlocked by the user, or those the user has in progress.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="14d3d-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="14d3d-118">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="14d3d-119">Parent</span><span class="sxs-lookup"><span data-stu-id="14d3d-119">Parent</span></span> 

[<span data-ttu-id="14d3d-120">実績 URI</span><span class="sxs-lookup"><span data-stu-id="14d3d-120">Achievements URIs</span></span>](atoc-reference-achievementsv2.md)

   