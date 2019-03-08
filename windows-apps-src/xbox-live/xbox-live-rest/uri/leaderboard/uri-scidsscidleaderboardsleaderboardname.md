---
title: /scids/{scid}/leaderboards/{leaderboardname}
assetID: 16345a17-6025-5453-5694-eaf97f0e83e9
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardname.html
description: " /scids/{scid}/leaderboards/{leaderboardname}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b73ffc2d6d6b80159651a90aabbf5595b146560d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645627"
---
# <a name="scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="92d6a-104">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="92d6a-104">/scids/{scid}/leaderboards/{leaderboardname}</span></span>
<span data-ttu-id="92d6a-105">定義済みのグローバルなランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="92d6a-105">Accesses a predefined global leaderboard.</span></span> <span data-ttu-id="92d6a-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="92d6a-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="92d6a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92d6a-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="92d6a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92d6a-108">URI parameters</span></span>
 
| <span data-ttu-id="92d6a-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92d6a-109">Parameter</span></span>| <span data-ttu-id="92d6a-110">種類</span><span class="sxs-lookup"><span data-stu-id="92d6a-110">Type</span></span>| <span data-ttu-id="92d6a-111">説明</span><span class="sxs-lookup"><span data-stu-id="92d6a-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="92d6a-112">scid</span><span class="sxs-lookup"><span data-stu-id="92d6a-112">scid</span></span>| <span data-ttu-id="92d6a-113">GUID</span><span class="sxs-lookup"><span data-stu-id="92d6a-113">GUID</span></span>| <span data-ttu-id="92d6a-114">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="92d6a-114">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="92d6a-115">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="92d6a-115">leaderboardname</span></span>| <span data-ttu-id="92d6a-116">string</span><span class="sxs-lookup"><span data-stu-id="92d6a-116">string</span></span>| <span data-ttu-id="92d6a-117">アクセスされる定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="92d6a-117">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="92d6a-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="92d6a-118">Valid methods</span></span>

[<span data-ttu-id="92d6a-119">取得</span><span class="sxs-lookup"><span data-stu-id="92d6a-119">GET</span></span>](uri-scidsscidleaderboardsleaderboardnameget.md)

<span data-ttu-id="92d6a-120">&nbsp;&nbsp; &nbsp;&nbsp;定義済みのグローバルなランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="92d6a-120">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard.</span></span>


[<span data-ttu-id="92d6a-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="92d6a-121">GET with value metadata</span></span>](uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.md)

<span data-ttu-id="92d6a-122">&nbsp;&nbsp; &nbsp;&nbsp;ランキングの値に関連付けられたメタデータと共に定義済みのグローバルなランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="92d6a-122">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>

 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="92d6a-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="92d6a-123">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="92d6a-124">Parent</span><span class="sxs-lookup"><span data-stu-id="92d6a-124">Parent</span></span> 

[<span data-ttu-id="92d6a-125">Uri のランキング</span><span class="sxs-lookup"><span data-stu-id="92d6a-125">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)

   