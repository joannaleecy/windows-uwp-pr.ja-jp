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
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4130012"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="88754-104">/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}</span><span class="sxs-lookup"><span data-stu-id="88754-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="88754-105">ソーシャル (ランク付け) ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="88754-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="88754-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="88754-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="88754-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="88754-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="88754-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="88754-108">URI parameters</span></span>

| <span data-ttu-id="88754-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="88754-109">Parameter</span></span>| <span data-ttu-id="88754-110">型</span><span class="sxs-lookup"><span data-stu-id="88754-110">Type</span></span>| <span data-ttu-id="88754-111">説明</span><span class="sxs-lookup"><span data-stu-id="88754-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="88754-112">xuid</span><span class="sxs-lookup"><span data-stu-id="88754-112">xuid</span></span>| <span data-ttu-id="88754-113">string</span><span class="sxs-lookup"><span data-stu-id="88754-113">string</span></span>| <span data-ttu-id="88754-114">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="88754-114">Identifier of the user.</span></span>|
| <span data-ttu-id="88754-115">scid</span><span class="sxs-lookup"><span data-stu-id="88754-115">scid</span></span>| <span data-ttu-id="88754-116">string</span><span class="sxs-lookup"><span data-stu-id="88754-116">string</span></span>| <span data-ttu-id="88754-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="88754-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="88754-118">statname</span><span class="sxs-lookup"><span data-stu-id="88754-118">statname</span></span>| <span data-ttu-id="88754-119">string</span><span class="sxs-lookup"><span data-stu-id="88754-119">string</span></span>| <span data-ttu-id="88754-120">アクセス対象のユーザー統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="88754-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="88754-121">all\ | お気に入り</span><span class="sxs-lookup"><span data-stu-id="88754-121">all\|favorite</span></span>| <span data-ttu-id="88754-122">列挙値</span><span class="sxs-lookup"><span data-stu-id="88754-122">enumeration</span></span>| <span data-ttu-id="88754-123">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="88754-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="88754-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="88754-124">Valid methods</span></span>

[<span data-ttu-id="88754-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="88754-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="88754-126">&nbsp;&nbsp;ランキング、統計値のいずれかすべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア)、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="88754-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="88754-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="88754-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="88754-128">Parent</span><span class="sxs-lookup"><span data-stu-id="88754-128">Parent</span></span>

[<span data-ttu-id="88754-129">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="88754-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
