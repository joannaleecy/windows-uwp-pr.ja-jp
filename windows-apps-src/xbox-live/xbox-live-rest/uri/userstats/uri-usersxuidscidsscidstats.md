---
title: /users/xuid({xuid})/scids/{scid}/stats
assetID: 3cf9ffd4-9a8b-2658-402b-2e933f7f6f1b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstats.html
description: " /users/xuid({xuid})/scids/{scid}/stats"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 53a6c7bb0e7390b024b01e221d8061316a80509e
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8784165"
---
# <a name="usersxuidxuidscidsscidstats"></a><span data-ttu-id="178a0-104">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="178a0-104">/users/xuid({xuid})/scids/{scid}/stats</span></span>
<span data-ttu-id="178a0-105">スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストでサービス構成にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="178a0-105">Accesses a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span> <span data-ttu-id="178a0-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="178a0-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="178a0-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="178a0-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="178a0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="178a0-108">URI parameters</span></span>
 
| <span data-ttu-id="178a0-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="178a0-109">Parameter</span></span>| <span data-ttu-id="178a0-110">型</span><span class="sxs-lookup"><span data-stu-id="178a0-110">Type</span></span>| <span data-ttu-id="178a0-111">説明</span><span class="sxs-lookup"><span data-stu-id="178a0-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="178a0-112">xuid</span><span class="sxs-lookup"><span data-stu-id="178a0-112">xuid</span></span>| <span data-ttu-id="178a0-113">GUID</span><span class="sxs-lookup"><span data-stu-id="178a0-113">GUID</span></span>| <span data-ttu-id="178a0-114">Xbox ユーザー ID (XUID) がに代わってサービス構成にアクセスするユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="178a0-114">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>| 
| <span data-ttu-id="178a0-115">scid</span><span class="sxs-lookup"><span data-stu-id="178a0-115">scid</span></span>| <span data-ttu-id="178a0-116">GUID</span><span class="sxs-lookup"><span data-stu-id="178a0-116">GUID</span></span>| <span data-ttu-id="178a0-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="178a0-117">Identifier of the service configuration that contains the resource being accessed.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="178a0-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="178a0-118">Valid methods</span></span>

[<span data-ttu-id="178a0-119">GET</span><span class="sxs-lookup"><span data-stu-id="178a0-119">GET</span></span>](uri-usersxuidscidsscidstatsget.md)

<span data-ttu-id="178a0-120">&nbsp;&nbsp;スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストでサービス構成を取得します。</span><span class="sxs-lookup"><span data-stu-id="178a0-120">&nbsp;&nbsp;Gets a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span>

[<span data-ttu-id="178a0-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="178a0-121">GET with value metadata</span></span>](uri-usersxuidscidsscidstatsgetvaluemetadata.md)

<span data-ttu-id="178a0-122">&nbsp;&nbsp;指定されたサービス構成でのユーザーに対して、統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="178a0-122">&nbsp;&nbsp;Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="178a0-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="178a0-123">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="178a0-124">Parent</span><span class="sxs-lookup"><span data-stu-id="178a0-124">Parent</span></span> 

[<span data-ttu-id="178a0-125">ユーザー統計 URI</span><span class="sxs-lookup"><span data-stu-id="178a0-125">User Statistics URIs</span></span>](atoc-reference-userstats.md)

   