---
title: /users/xuid({xuid})/groups/{moniker}
assetID: 7c73236b-95ee-723b-e5e0-68252c953e14
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmoniker.html
description: " /users/xuid({xuid})/groups/{moniker}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 25ddc8120f05f04d5285fbbe4efc5a41f98265ef
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8794091"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="94cfc-104">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="94cfc-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="94cfc-105">グループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="94cfc-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="94cfc-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="94cfc-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="94cfc-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="94cfc-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="94cfc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="94cfc-108">URI parameters</span></span>
 
| <span data-ttu-id="94cfc-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="94cfc-109">Parameter</span></span>| <span data-ttu-id="94cfc-110">型</span><span class="sxs-lookup"><span data-stu-id="94cfc-110">Type</span></span>| <span data-ttu-id="94cfc-111">説明</span><span class="sxs-lookup"><span data-stu-id="94cfc-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="94cfc-112">xuid</span><span class="sxs-lookup"><span data-stu-id="94cfc-112">xuid</span></span>| <span data-ttu-id="94cfc-113">string</span><span class="sxs-lookup"><span data-stu-id="94cfc-113">string</span></span>| <span data-ttu-id="94cfc-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連します。</span><span class="sxs-lookup"><span data-stu-id="94cfc-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="94cfc-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="94cfc-115">moniker</span></span>| <span data-ttu-id="94cfc-116">string</span><span class="sxs-lookup"><span data-stu-id="94cfc-116">string</span></span>| <span data-ttu-id="94cfc-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="94cfc-117">String defining the group of users.</span></span> <span data-ttu-id="94cfc-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="94cfc-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="94cfc-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="94cfc-119">Valid methods</span></span>

[<span data-ttu-id="94cfc-120">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="94cfc-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="94cfc-121">&nbsp;&nbsp;グループの PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="94cfc-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="94cfc-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="94cfc-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="94cfc-123">Parent</span><span class="sxs-lookup"><span data-stu-id="94cfc-123">Parent</span></span> 

[<span data-ttu-id="94cfc-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="94cfc-124">Presence URIs</span></span>](atoc-reference-presence.md)

   