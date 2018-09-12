---
title: ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
author: KevinAsgari
description: " ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 161c7e96faf3ec217aeb188ccb3b5b1e354d217e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882302"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="b15e1-104">ユーザー/xuid ({xuid})/scids/{scid}/stats/{statname) そして {すべて | お気に入り}</span><span class="sxs-lookup"><span data-stu-id="b15e1-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="b15e1-105">(ランク付け) のソーシャル ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b15e1-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="b15e1-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b15e1-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="b15e1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b15e1-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="b15e1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b15e1-108">URI parameters</span></span>

| <span data-ttu-id="b15e1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b15e1-109">Parameter</span></span>| <span data-ttu-id="b15e1-110">型</span><span class="sxs-lookup"><span data-stu-id="b15e1-110">Type</span></span>| <span data-ttu-id="b15e1-111">説明</span><span class="sxs-lookup"><span data-stu-id="b15e1-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="b15e1-112">xuid</span><span class="sxs-lookup"><span data-stu-id="b15e1-112">xuid</span></span>| <span data-ttu-id="b15e1-113">string</span><span class="sxs-lookup"><span data-stu-id="b15e1-113">string</span></span>| <span data-ttu-id="b15e1-114">ユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="b15e1-114">Identifier of the user.</span></span>|
| <span data-ttu-id="b15e1-115">scid</span><span class="sxs-lookup"><span data-stu-id="b15e1-115">scid</span></span>| <span data-ttu-id="b15e1-116">string</span><span class="sxs-lookup"><span data-stu-id="b15e1-116">string</span></span>| <span data-ttu-id="b15e1-117">アクセス対象のリソースが含まれているサービス構成の識別子。</span><span class="sxs-lookup"><span data-stu-id="b15e1-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="b15e1-118">statname</span><span class="sxs-lookup"><span data-stu-id="b15e1-118">statname</span></span>| <span data-ttu-id="b15e1-119">string</span><span class="sxs-lookup"><span data-stu-id="b15e1-119">string</span></span>| <span data-ttu-id="b15e1-120">アクセスしているユーザーの統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="b15e1-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="b15e1-121">all\ | お気に入り</span><span class="sxs-lookup"><span data-stu-id="b15e1-121">all\|favorite</span></span>| <span data-ttu-id="b15e1-122">列挙</span><span class="sxs-lookup"><span data-stu-id="b15e1-122">enumeration</span></span>| <span data-ttu-id="b15e1-123">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみの値、統計をランク付けするかどうか (スコア) ください。</span><span class="sxs-lookup"><span data-stu-id="b15e1-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="b15e1-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b15e1-124">Valid methods</span></span>

[<span data-ttu-id="b15e1-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="b15e1-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="b15e1-126">&nbsp;&nbsp;ランキング、統計値は、すべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) によって、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="b15e1-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="b15e1-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="b15e1-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="b15e1-128">Parent</span><span class="sxs-lookup"><span data-stu-id="b15e1-128">Parent</span></span>

[<span data-ttu-id="b15e1-129">ランキングの Uri</span><span class="sxs-lookup"><span data-stu-id="b15e1-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
