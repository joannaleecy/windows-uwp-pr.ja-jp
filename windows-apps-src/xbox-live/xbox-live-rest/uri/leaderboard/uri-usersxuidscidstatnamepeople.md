---
title: /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
author: KevinAsgari
description: " /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 161c7e96faf3ec217aeb188ccb3b5b1e354d217e
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4210707"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="86730-104">/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}</span><span class="sxs-lookup"><span data-stu-id="86730-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="86730-105">ソーシャル (ランク付け) ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="86730-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="86730-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="86730-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="86730-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="86730-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="86730-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="86730-108">URI parameters</span></span>

| <span data-ttu-id="86730-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="86730-109">Parameter</span></span>| <span data-ttu-id="86730-110">型</span><span class="sxs-lookup"><span data-stu-id="86730-110">Type</span></span>| <span data-ttu-id="86730-111">説明</span><span class="sxs-lookup"><span data-stu-id="86730-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="86730-112">xuid</span><span class="sxs-lookup"><span data-stu-id="86730-112">xuid</span></span>| <span data-ttu-id="86730-113">string</span><span class="sxs-lookup"><span data-stu-id="86730-113">string</span></span>| <span data-ttu-id="86730-114">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="86730-114">Identifier of the user.</span></span>|
| <span data-ttu-id="86730-115">scid</span><span class="sxs-lookup"><span data-stu-id="86730-115">scid</span></span>| <span data-ttu-id="86730-116">string</span><span class="sxs-lookup"><span data-stu-id="86730-116">string</span></span>| <span data-ttu-id="86730-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="86730-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="86730-118">statname</span><span class="sxs-lookup"><span data-stu-id="86730-118">statname</span></span>| <span data-ttu-id="86730-119">string</span><span class="sxs-lookup"><span data-stu-id="86730-119">string</span></span>| <span data-ttu-id="86730-120">アクセス対象のユーザー統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="86730-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="86730-121">all\ | お気に入り</span><span class="sxs-lookup"><span data-stu-id="86730-121">all\|favorite</span></span>| <span data-ttu-id="86730-122">列挙値</span><span class="sxs-lookup"><span data-stu-id="86730-122">enumeration</span></span>| <span data-ttu-id="86730-123">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="86730-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="86730-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="86730-124">Valid methods</span></span>

[<span data-ttu-id="86730-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="86730-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="86730-126">&nbsp;&nbsp;ランキング、統計値のいずれかすべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア)、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="86730-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="86730-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="86730-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="86730-128">Parent</span><span class="sxs-lookup"><span data-stu-id="86730-128">Parent</span></span>

[<span data-ttu-id="86730-129">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="86730-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
