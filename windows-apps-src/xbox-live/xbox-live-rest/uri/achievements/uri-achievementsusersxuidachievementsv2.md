---
title: /users/xuid({xuid})/achievements
assetID: 4dd89962-ab73-c25b-7a11-3ed35475492e
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsv2.html
description: " /users/xuid({xuid})/achievements"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6d4ac8c1fbf3d5f3fcc645e284059c1644495d62
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8326156"
---
# <a name="usersxuidxuidachievements"></a><span data-ttu-id="ccbbf-104">/users/xuid({xuid})/achievements</span><span class="sxs-lookup"><span data-stu-id="ccbbf-104">/users/xuid({xuid})/achievements</span></span>
 
<span data-ttu-id="ccbbf-105">このユニバーサル リソース識別子 (URI) は、ユーザーの実績へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="ccbbf-105">This Universal Resource Identifier (URI) provides access to user achievements.</span></span>
 
<span data-ttu-id="ccbbf-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ccbbf-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ccbbf-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ccbbf-107">URI parameters</span></span>
 
| <span data-ttu-id="ccbbf-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ccbbf-108">Parameter</span></span>| <span data-ttu-id="ccbbf-109">型</span><span class="sxs-lookup"><span data-stu-id="ccbbf-109">Type</span></span>| <span data-ttu-id="ccbbf-110">説明</span><span class="sxs-lookup"><span data-stu-id="ccbbf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ccbbf-111">xuid</span><span class="sxs-lookup"><span data-stu-id="ccbbf-111">xuid</span></span>| <span data-ttu-id="ccbbf-112">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ccbbf-112">64-bit unsigned integer</span></span>| <span data-ttu-id="ccbbf-113">Xbox ユーザー ID (XUID) が (リソース) にアクセスしているユーザー。</span><span class="sxs-lookup"><span data-stu-id="ccbbf-113">Xbox User ID (XUID) of the user whose (resource) is being accessed.</span></span> <span data-ttu-id="ccbbf-114">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ccbbf-114">Must match the XUID of the authenticated user.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ccbbf-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ccbbf-115">Valid methods</span></span>

[<span data-ttu-id="ccbbf-116">GET</span><span class="sxs-lookup"><span data-stu-id="ccbbf-116">GET</span></span>](uri-achievementsusersxuidachievementsgetv2.md)

<span data-ttu-id="ccbbf-117">&nbsp;&nbsp;タイトル、進行中のユーザーが、または、ユーザーがロックを解除するもので定義されている実績の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="ccbbf-117">&nbsp;&nbsp;Gets the list of achievements defined on the title, those unlocked by the user, or those the user has in progress.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ccbbf-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="ccbbf-118">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ccbbf-119">Parent</span><span class="sxs-lookup"><span data-stu-id="ccbbf-119">Parent</span></span> 

[<span data-ttu-id="ccbbf-120">実績 URI</span><span class="sxs-lookup"><span data-stu-id="ccbbf-120">Achievements URIs</span></span>](atoc-reference-achievementsv2.md)

   