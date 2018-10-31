---
title: /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
author: KevinAsgari
description: " /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c6967cb337da2188b0403450db373ee3c9088a2
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5838523"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="e0be6-104">/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}</span><span class="sxs-lookup"><span data-stu-id="e0be6-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="e0be6-105">ソーシャル (ランク付け) ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e0be6-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="e0be6-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e0be6-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="e0be6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0be6-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="e0be6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0be6-108">URI parameters</span></span>

| <span data-ttu-id="e0be6-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0be6-109">Parameter</span></span>| <span data-ttu-id="e0be6-110">型</span><span class="sxs-lookup"><span data-stu-id="e0be6-110">Type</span></span>| <span data-ttu-id="e0be6-111">説明</span><span class="sxs-lookup"><span data-stu-id="e0be6-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="e0be6-112">xuid</span><span class="sxs-lookup"><span data-stu-id="e0be6-112">xuid</span></span>| <span data-ttu-id="e0be6-113">string</span><span class="sxs-lookup"><span data-stu-id="e0be6-113">string</span></span>| <span data-ttu-id="e0be6-114">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="e0be6-114">Identifier of the user.</span></span>|
| <span data-ttu-id="e0be6-115">scid</span><span class="sxs-lookup"><span data-stu-id="e0be6-115">scid</span></span>| <span data-ttu-id="e0be6-116">string</span><span class="sxs-lookup"><span data-stu-id="e0be6-116">string</span></span>| <span data-ttu-id="e0be6-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="e0be6-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="e0be6-118">statname</span><span class="sxs-lookup"><span data-stu-id="e0be6-118">statname</span></span>| <span data-ttu-id="e0be6-119">string</span><span class="sxs-lookup"><span data-stu-id="e0be6-119">string</span></span>| <span data-ttu-id="e0be6-120">アクセス対象のユーザー統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="e0be6-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="e0be6-121">all\ | お気に入り</span><span class="sxs-lookup"><span data-stu-id="e0be6-121">all\|favorite</span></span>| <span data-ttu-id="e0be6-122">列挙型</span><span class="sxs-lookup"><span data-stu-id="e0be6-122">enumeration</span></span>| <span data-ttu-id="e0be6-123">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="e0be6-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="e0be6-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e0be6-124">Valid methods</span></span>

[<span data-ttu-id="e0be6-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="e0be6-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="e0be6-126">&nbsp;&nbsp;ランキング、統計の現在のユーザーのいずれかのすべての既知連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値によって、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="e0be6-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="e0be6-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="e0be6-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="e0be6-128">Parent</span><span class="sxs-lookup"><span data-stu-id="e0be6-128">Parent</span></span>

[<span data-ttu-id="e0be6-129">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="e0be6-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
