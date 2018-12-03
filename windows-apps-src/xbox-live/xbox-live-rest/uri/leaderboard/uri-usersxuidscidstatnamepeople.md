---
title: /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}
assetID: 0983dad0-59b7-45b7-505d-603e341fe0cc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidstatnamepeople.html
description: " /users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 85a6470a64ceef3b154384d1ca859fb28733aad3
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8322802"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="9d18c-104">/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}</span><span class="sxs-lookup"><span data-stu-id="9d18c-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="9d18c-105">ソーシャル (ランク付け) ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="9d18c-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="9d18c-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9d18c-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="9d18c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d18c-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="9d18c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d18c-108">URI parameters</span></span>

| <span data-ttu-id="9d18c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9d18c-109">Parameter</span></span>| <span data-ttu-id="9d18c-110">型</span><span class="sxs-lookup"><span data-stu-id="9d18c-110">Type</span></span>| <span data-ttu-id="9d18c-111">説明</span><span class="sxs-lookup"><span data-stu-id="9d18c-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9d18c-112">xuid</span><span class="sxs-lookup"><span data-stu-id="9d18c-112">xuid</span></span>| <span data-ttu-id="9d18c-113">string</span><span class="sxs-lookup"><span data-stu-id="9d18c-113">string</span></span>| <span data-ttu-id="9d18c-114">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="9d18c-114">Identifier of the user.</span></span>|
| <span data-ttu-id="9d18c-115">scid</span><span class="sxs-lookup"><span data-stu-id="9d18c-115">scid</span></span>| <span data-ttu-id="9d18c-116">string</span><span class="sxs-lookup"><span data-stu-id="9d18c-116">string</span></span>| <span data-ttu-id="9d18c-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="9d18c-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="9d18c-118">statname</span><span class="sxs-lookup"><span data-stu-id="9d18c-118">statname</span></span>| <span data-ttu-id="9d18c-119">string</span><span class="sxs-lookup"><span data-stu-id="9d18c-119">string</span></span>| <span data-ttu-id="9d18c-120">アクセス対象のユーザー統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="9d18c-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="9d18c-121">all\ | お気に入り</span><span class="sxs-lookup"><span data-stu-id="9d18c-121">all\|favorite</span></span>| <span data-ttu-id="9d18c-122">列挙型</span><span class="sxs-lookup"><span data-stu-id="9d18c-122">enumeration</span></span>| <span data-ttu-id="9d18c-123">現在のユーザーの既知のすべての連絡先や、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア) の値、統計をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="9d18c-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="9d18c-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9d18c-124">Valid methods</span></span>

[<span data-ttu-id="9d18c-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="9d18c-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="9d18c-126">&nbsp;&nbsp;ランキング、統計値は、すべての既知の連絡先の現在のユーザーや、そのユーザーのお気に入りユーザーとして指定された連絡先のみ (スコア)、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="9d18c-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="9d18c-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d18c-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="9d18c-128">Parent</span><span class="sxs-lookup"><span data-stu-id="9d18c-128">Parent</span></span>

[<span data-ttu-id="9d18c-129">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="9d18c-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
