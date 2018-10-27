---
title: /users/xuid({xuid})/scids/{scid}/stats
assetID: 3cf9ffd4-9a8b-2658-402b-2e933f7f6f1b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidscidsscidstats.html
author: KevinAsgari
description: " /users/xuid({xuid})/scids/{scid}/stats"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2dd3298c5191f5cfc2e470203567722251371ecb
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5694937"
---
# <a name="usersxuidxuidscidsscidstats"></a><span data-ttu-id="35714-104">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="35714-104">/users/xuid({xuid})/scids/{scid}/stats</span></span>
<span data-ttu-id="35714-105">スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストで、サービス構成にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="35714-105">Accesses a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span> <span data-ttu-id="35714-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="35714-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="35714-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="35714-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="35714-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="35714-108">URI parameters</span></span>
 
| <span data-ttu-id="35714-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="35714-109">Parameter</span></span>| <span data-ttu-id="35714-110">型</span><span class="sxs-lookup"><span data-stu-id="35714-110">Type</span></span>| <span data-ttu-id="35714-111">説明</span><span class="sxs-lookup"><span data-stu-id="35714-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="35714-112">xuid</span><span class="sxs-lookup"><span data-stu-id="35714-112">xuid</span></span>| <span data-ttu-id="35714-113">GUID</span><span class="sxs-lookup"><span data-stu-id="35714-113">GUID</span></span>| <span data-ttu-id="35714-114">Xbox ユーザー ID (XUID) がに代わってサービス構成にアクセスするユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="35714-114">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>| 
| <span data-ttu-id="35714-115">scid</span><span class="sxs-lookup"><span data-stu-id="35714-115">scid</span></span>| <span data-ttu-id="35714-116">GUID</span><span class="sxs-lookup"><span data-stu-id="35714-116">GUID</span></span>| <span data-ttu-id="35714-117">アクセス対象のリソースが含まれているサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="35714-117">Identifier of the service configuration that contains the resource being accessed.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="35714-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="35714-118">Valid methods</span></span>

[<span data-ttu-id="35714-119">GET</span><span class="sxs-lookup"><span data-stu-id="35714-119">GET</span></span>](uri-usersxuidscidsscidstatsget.md)

<span data-ttu-id="35714-120">&nbsp;&nbsp;スコープ指定されたユーザーに代わってユーザー統計情報名のコンマ区切りのリストで、サービス構成を取得します。</span><span class="sxs-lookup"><span data-stu-id="35714-120">&nbsp;&nbsp;Gets a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span>

[<span data-ttu-id="35714-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="35714-121">GET with value metadata</span></span>](uri-usersxuidscidsscidstatsgetvaluemetadata.md)

<span data-ttu-id="35714-122">&nbsp;&nbsp;指定されたサービス構成でのユーザーに対して、統計情報の値に関連付けられたメタデータを含む、指定された統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="35714-122">&nbsp;&nbsp;Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="35714-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="35714-123">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="35714-124">Parent</span><span class="sxs-lookup"><span data-stu-id="35714-124">Parent</span></span> 

[<span data-ttu-id="35714-125">ユーザー統計 URI</span><span class="sxs-lookup"><span data-stu-id="35714-125">User Statistics URIs</span></span>](atoc-reference-userstats.md)

   