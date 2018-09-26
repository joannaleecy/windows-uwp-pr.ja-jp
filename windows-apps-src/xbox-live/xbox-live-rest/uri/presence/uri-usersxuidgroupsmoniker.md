---
title: /users/xuid({xuid})/groups/{moniker}
assetID: 7c73236b-95ee-723b-e5e0-68252c953e14
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmoniker.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 356afd69483968a3edd836eb9e031bc8fcfafd4c
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4175402"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="7be2d-104">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="7be2d-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="7be2d-105">グループの presencerecord を要求してにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7be2d-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="7be2d-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7be2d-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7be2d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7be2d-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7be2d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7be2d-108">URI parameters</span></span>
 
| <span data-ttu-id="7be2d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7be2d-109">Parameter</span></span>| <span data-ttu-id="7be2d-110">型</span><span class="sxs-lookup"><span data-stu-id="7be2d-110">Type</span></span>| <span data-ttu-id="7be2d-111">説明</span><span class="sxs-lookup"><span data-stu-id="7be2d-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7be2d-112">xuid</span><span class="sxs-lookup"><span data-stu-id="7be2d-112">xuid</span></span>| <span data-ttu-id="7be2d-113">string</span><span class="sxs-lookup"><span data-stu-id="7be2d-113">string</span></span>| <span data-ttu-id="7be2d-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="7be2d-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="7be2d-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="7be2d-115">moniker</span></span>| <span data-ttu-id="7be2d-116">string</span><span class="sxs-lookup"><span data-stu-id="7be2d-116">string</span></span>| <span data-ttu-id="7be2d-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="7be2d-117">String defining the group of users.</span></span> <span data-ttu-id="7be2d-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="7be2d-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7be2d-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7be2d-119">Valid methods</span></span>

[<span data-ttu-id="7be2d-120">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="7be2d-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="7be2d-121">&nbsp;&nbsp;グループの presencerecord を要求してを取得します。</span><span class="sxs-lookup"><span data-stu-id="7be2d-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7be2d-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="7be2d-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7be2d-123">Parent</span><span class="sxs-lookup"><span data-stu-id="7be2d-123">Parent</span></span> 

[<span data-ttu-id="7be2d-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="7be2d-124">Presence URIs</span></span>](atoc-reference-presence.md)

   