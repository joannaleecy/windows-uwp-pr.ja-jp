---
title: /users/xuid({xuid})/groups/{moniker}
assetID: 7c73236b-95ee-723b-e5e0-68252c953e14
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmoniker.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 640635458f50046a8fbc6a9cf539c659950e163e
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6251488"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="09b6e-104">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="09b6e-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="09b6e-105">グループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="09b6e-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="09b6e-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="09b6e-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="09b6e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b6e-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="09b6e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b6e-108">URI parameters</span></span>
 
| <span data-ttu-id="09b6e-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b6e-109">Parameter</span></span>| <span data-ttu-id="09b6e-110">型</span><span class="sxs-lookup"><span data-stu-id="09b6e-110">Type</span></span>| <span data-ttu-id="09b6e-111">説明</span><span class="sxs-lookup"><span data-stu-id="09b6e-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="09b6e-112">xuid</span><span class="sxs-lookup"><span data-stu-id="09b6e-112">xuid</span></span>| <span data-ttu-id="09b6e-113">string</span><span class="sxs-lookup"><span data-stu-id="09b6e-113">string</span></span>| <span data-ttu-id="09b6e-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連します。</span><span class="sxs-lookup"><span data-stu-id="09b6e-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="09b6e-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="09b6e-115">moniker</span></span>| <span data-ttu-id="09b6e-116">string</span><span class="sxs-lookup"><span data-stu-id="09b6e-116">string</span></span>| <span data-ttu-id="09b6e-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="09b6e-117">String defining the group of users.</span></span> <span data-ttu-id="09b6e-118">現時点でのみ受け入れたモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="09b6e-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="09b6e-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="09b6e-119">Valid methods</span></span>

[<span data-ttu-id="09b6e-120">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="09b6e-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="09b6e-121">&nbsp;&nbsp;グループの PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="09b6e-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="09b6e-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="09b6e-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="09b6e-123">Parent</span><span class="sxs-lookup"><span data-stu-id="09b6e-123">Parent</span></span> 

[<span data-ttu-id="09b6e-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="09b6e-124">Presence URIs</span></span>](atoc-reference-presence.md)

   