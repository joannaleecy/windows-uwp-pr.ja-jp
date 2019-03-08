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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632577"
---
# <a name="usersxuidxuidscidsscidstatsstatnamepeopleallfavorite"></a><span data-ttu-id="8668d-104">/users/xuid({xuid})/scids/{scid}/stats/{statname}/people/{all|favorite}</span><span class="sxs-lookup"><span data-stu-id="8668d-104">/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all|favorite}</span></span>
<span data-ttu-id="8668d-105">ソーシャル (ランク付け) ランキングにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="8668d-105">Accesses a social (ranked) leaderboard.</span></span>
<span data-ttu-id="8668d-106">これらの Uri のドメインが`leaderboards.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8668d-106">The domain for these URIs is `leaderboards.xboxlive.com`.</span></span>

  * [<span data-ttu-id="8668d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8668d-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8668d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8668d-108">URI parameters</span></span>

| <span data-ttu-id="8668d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8668d-109">Parameter</span></span>| <span data-ttu-id="8668d-110">種類</span><span class="sxs-lookup"><span data-stu-id="8668d-110">Type</span></span>| <span data-ttu-id="8668d-111">説明</span><span class="sxs-lookup"><span data-stu-id="8668d-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="8668d-112">xuid</span><span class="sxs-lookup"><span data-stu-id="8668d-112">xuid</span></span>| <span data-ttu-id="8668d-113">string</span><span class="sxs-lookup"><span data-stu-id="8668d-113">string</span></span>| <span data-ttu-id="8668d-114">ユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="8668d-114">Identifier of the user.</span></span>|
| <span data-ttu-id="8668d-115">scid</span><span class="sxs-lookup"><span data-stu-id="8668d-115">scid</span></span>| <span data-ttu-id="8668d-116">string</span><span class="sxs-lookup"><span data-stu-id="8668d-116">string</span></span>| <span data-ttu-id="8668d-117">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="8668d-117">Identifier of the service configuration that contains the resource being accessed.</span></span>|
| <span data-ttu-id="8668d-118">statname</span><span class="sxs-lookup"><span data-stu-id="8668d-118">statname</span></span>| <span data-ttu-id="8668d-119">string</span><span class="sxs-lookup"><span data-stu-id="8668d-119">string</span></span>| <span data-ttu-id="8668d-120">アクセスされているユーザーの統計リソースの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="8668d-120">Unique identifier of the user stat resource being accessed.</span></span>|
| <span data-ttu-id="8668d-121">すべて\|お気に入り</span><span class="sxs-lookup"><span data-stu-id="8668d-121">all\|favorite</span></span>| <span data-ttu-id="8668d-122">列挙</span><span class="sxs-lookup"><span data-stu-id="8668d-122">enumeration</span></span>| <span data-ttu-id="8668d-123">現在のユーザーのすべての既知の連絡先またはお気に入りのユーザーとしてそのユーザーによって指定された連絡先のみ (スコア) の値、stat をランク付けするかどうか。</span><span class="sxs-lookup"><span data-stu-id="8668d-123">Whether to rank the stat values (scores) for all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="8668d-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="8668d-124">Valid methods</span></span>

[<span data-ttu-id="8668d-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span><span class="sxs-lookup"><span data-stu-id="8668d-125">GET (/users/xuid({xuid})/scids/{scid}/stats/{statname)/people/{all\|favorite})</span></span>](uri-usersxuidscidstatnamepeopleget.md)

<span data-ttu-id="8668d-126">&nbsp;&nbsp;順位付け、stat かすべての既知の連絡先、現在のユーザーまたはユーザーのお気に入りとしてそのユーザーによって指定された連絡先のみ (スコア) の値では、ソーシャル ランキングを返します。</span><span class="sxs-lookup"><span data-stu-id="8668d-126">&nbsp;&nbsp;Returns a social leaderboard by ranking the stat values (scores) for either all known contacts of the current user or only those contacts designated as favorite people by that user.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="8668d-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="8668d-127">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="8668d-128">Parent</span><span class="sxs-lookup"><span data-stu-id="8668d-128">Parent</span></span>

[<span data-ttu-id="8668d-129">Uri のランキング</span><span class="sxs-lookup"><span data-stu-id="8668d-129">Leaderboards URIs</span></span>](atoc-reference-leaderboard.md)
