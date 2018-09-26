---
title: /scids/{scid}/leaderboards/{leaderboardname}
assetID: 16345a17-6025-5453-5694-eaf97f0e83e9
permalink: en-us/docs/xboxlive/rest/uri-scidsscidleaderboardsleaderboardname.html
author: KevinAsgari
description: " /scids/{scid}/leaderboards/{leaderboardname}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 797a557b4bb7d443ecfdce1f136f5db2079b1990
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4206085"
---
# <a name="scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="90c44-104">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="90c44-104">/scids/{scid}/leaderboards/{leaderboardname}</span></span>
<span data-ttu-id="90c44-105">定義済みグローバル ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="90c44-105">Accesses a predefined global leaderboard.</span></span> <span data-ttu-id="90c44-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="90c44-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="90c44-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c44-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="90c44-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c44-108">URI parameters</span></span>
 
| <span data-ttu-id="90c44-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="90c44-109">Parameter</span></span>| <span data-ttu-id="90c44-110">型</span><span class="sxs-lookup"><span data-stu-id="90c44-110">Type</span></span>| <span data-ttu-id="90c44-111">説明</span><span class="sxs-lookup"><span data-stu-id="90c44-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="90c44-112">scid</span><span class="sxs-lookup"><span data-stu-id="90c44-112">scid</span></span>| <span data-ttu-id="90c44-113">GUID</span><span class="sxs-lookup"><span data-stu-id="90c44-113">GUID</span></span>| <span data-ttu-id="90c44-114">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="90c44-114">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="90c44-115">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="90c44-115">leaderboardname</span></span>| <span data-ttu-id="90c44-116">string</span><span class="sxs-lookup"><span data-stu-id="90c44-116">string</span></span>| <span data-ttu-id="90c44-117">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="90c44-117">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="90c44-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="90c44-118">Valid methods</span></span>

[<span data-ttu-id="90c44-119">GET</span><span class="sxs-lookup"><span data-stu-id="90c44-119">GET</span></span>](uri-scidsscidleaderboardsleaderboardnameget.md)

<span data-ttu-id="90c44-120">&nbsp;&nbsp;&nbsp;&nbsp;定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="90c44-120">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard.</span></span>


[<span data-ttu-id="90c44-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="90c44-121">GET with value metadata</span></span>](uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.md)

<span data-ttu-id="90c44-122">&nbsp;&nbsp;&nbsp;&nbsp;ランキングの値に関連付けられたメタデータと共に、定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="90c44-122">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>

 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="90c44-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="90c44-123">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="90c44-124">Parent</span><span class="sxs-lookup"><span data-stu-id="90c44-124">Parent</span></span> 

[<span data-ttu-id="90c44-125">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="90c44-125">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)

   