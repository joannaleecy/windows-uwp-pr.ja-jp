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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650417"
---
# <a name="usersxuidxuidscidsscidstats"></a><span data-ttu-id="d099d-104">/users/xuid({xuid})/scids/{scid}/stats</span><span class="sxs-lookup"><span data-stu-id="d099d-104">/users/xuid({xuid})/scids/{scid}/stats</span></span>
<span data-ttu-id="d099d-105">サービス構成を指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d099d-105">Accesses a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span> <span data-ttu-id="d099d-106">これらの Uri のドメインが`userstats.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d099d-106">The domain for these URIs is `userstats.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d099d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d099d-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d099d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d099d-108">URI parameters</span></span>
 
| <span data-ttu-id="d099d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d099d-109">Parameter</span></span>| <span data-ttu-id="d099d-110">種類</span><span class="sxs-lookup"><span data-stu-id="d099d-110">Type</span></span>| <span data-ttu-id="d099d-111">説明</span><span class="sxs-lookup"><span data-stu-id="d099d-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d099d-112">xuid</span><span class="sxs-lookup"><span data-stu-id="d099d-112">xuid</span></span>| <span data-ttu-id="d099d-113">GUID</span><span class="sxs-lookup"><span data-stu-id="d099d-113">GUID</span></span>| <span data-ttu-id="d099d-114">Xbox ユーザー ID (XUID) の対象サービスの構成にアクセスするユーザーです。</span><span class="sxs-lookup"><span data-stu-id="d099d-114">Xbox User ID (XUID) of the user on whose behalf to access the service configuration.</span></span>| 
| <span data-ttu-id="d099d-115">scid</span><span class="sxs-lookup"><span data-stu-id="d099d-115">scid</span></span>| <span data-ttu-id="d099d-116">GUID</span><span class="sxs-lookup"><span data-stu-id="d099d-116">GUID</span></span>| <span data-ttu-id="d099d-117">アクセスされるリソースを含むサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="d099d-117">Identifier of the service configuration that contains the resource being accessed.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d099d-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d099d-118">Valid methods</span></span>

[<span data-ttu-id="d099d-119">取得</span><span class="sxs-lookup"><span data-stu-id="d099d-119">GET</span></span>](uri-usersxuidscidsscidstatsget.md)

<span data-ttu-id="d099d-120">&nbsp;&nbsp;指定したユーザーに代わってユーザー統計名のコンマ区切りリストによってスコープ サービス構成を取得します。</span><span class="sxs-lookup"><span data-stu-id="d099d-120">&nbsp;&nbsp;Gets a service configuration scoped by a comma-delimited list of user statistic names on behalf of the specified user.</span></span>

[<span data-ttu-id="d099d-121">値のメタデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="d099d-121">GET with value metadata</span></span>](uri-usersxuidscidsscidstatsgetvaluemetadata.md)

<span data-ttu-id="d099d-122">&nbsp;&nbsp;指定したサービス構成内のユーザーに対して、統計情報の値に関連付けられているメタデータを含む、指定した統計情報の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="d099d-122">&nbsp;&nbsp;Gets a list of specified statistics, including metadata associated with the statistic values, for a user in a specified service configuration.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d099d-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="d099d-123">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d099d-124">Parent</span><span class="sxs-lookup"><span data-stu-id="d099d-124">Parent</span></span> 

[<span data-ttu-id="d099d-125">ユーザーの統計情報の Uri</span><span class="sxs-lookup"><span data-stu-id="d099d-125">User Statistics URIs</span></span>](atoc-reference-userstats.md)

   