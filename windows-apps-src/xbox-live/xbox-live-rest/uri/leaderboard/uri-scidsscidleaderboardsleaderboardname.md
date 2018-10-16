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
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4623085"
---
# <a name="scidsscidleaderboardsleaderboardname"></a><span data-ttu-id="8e366-104">/scids/{scid}/leaderboards/{leaderboardname}</span><span class="sxs-lookup"><span data-stu-id="8e366-104">/scids/{scid}/leaderboards/{leaderboardname}</span></span>
<span data-ttu-id="8e366-105">定義済みグローバル ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="8e366-105">Accesses a predefined global leaderboard.</span></span> <span data-ttu-id="8e366-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8e366-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8e366-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e366-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8e366-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e366-108">URI parameters</span></span>
 
| <span data-ttu-id="8e366-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e366-109">Parameter</span></span>| <span data-ttu-id="8e366-110">型</span><span class="sxs-lookup"><span data-stu-id="8e366-110">Type</span></span>| <span data-ttu-id="8e366-111">説明</span><span class="sxs-lookup"><span data-stu-id="8e366-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8e366-112">scid</span><span class="sxs-lookup"><span data-stu-id="8e366-112">scid</span></span>| <span data-ttu-id="8e366-113">GUID</span><span class="sxs-lookup"><span data-stu-id="8e366-113">GUID</span></span>| <span data-ttu-id="8e366-114">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="8e366-114">Identifier of the service configuration which contains the resource being accessed.</span></span>| 
| <span data-ttu-id="8e366-115">leaderboardname</span><span class="sxs-lookup"><span data-stu-id="8e366-115">leaderboardname</span></span>| <span data-ttu-id="8e366-116">string</span><span class="sxs-lookup"><span data-stu-id="8e366-116">string</span></span>| <span data-ttu-id="8e366-117">アクセス対象の定義済みのランキング リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="8e366-117">Unique identifier of the predefined leaderboard resource being accessed.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="8e366-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="8e366-118">Valid methods</span></span>

[<span data-ttu-id="8e366-119">GET</span><span class="sxs-lookup"><span data-stu-id="8e366-119">GET</span></span>](uri-scidsscidleaderboardsleaderboardnameget.md)

<span data-ttu-id="8e366-120">&nbsp;&nbsp;&nbsp;&nbsp;定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="8e366-120">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard.</span></span>


[<span data-ttu-id="8e366-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="8e366-121">GET with value metadata</span></span>](uri-scidsscidleaderboardsleaderboardnamegetvaluemetadata.md)

<span data-ttu-id="8e366-122">&nbsp;&nbsp;&nbsp;&nbsp;ランキングの値に関連付けられたメタデータと共に定義済みグローバル ランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="8e366-122">&nbsp;&nbsp; &nbsp;&nbsp;Gets a predefined global leaderboard along with any metadata associated with the leaderboard values.</span></span>

 
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="8e366-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="8e366-123">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="8e366-124">Parent</span><span class="sxs-lookup"><span data-stu-id="8e366-124">Parent</span></span> 

[<span data-ttu-id="8e366-125">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="8e366-125">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)

   