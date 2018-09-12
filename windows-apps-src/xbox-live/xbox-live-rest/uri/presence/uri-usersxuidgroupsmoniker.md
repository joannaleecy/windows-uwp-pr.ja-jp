---
title: ユーザー/xuid ({xuid})/groups/{モニカー}
assetID: 7c73236b-95ee-723b-e5e0-68252c953e14
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmoniker.html
author: KevinAsgari
description: " ユーザー/xuid ({xuid})/groups/{モニカー}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 356afd69483968a3edd836eb9e031bc8fcfafd4c
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881543"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="70671-104">ユーザー/xuid ({xuid})/groups/{モニカー}</span><span class="sxs-lookup"><span data-stu-id="70671-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="70671-105">グループの presencerecord を要求してにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="70671-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="70671-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="70671-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="70671-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="70671-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="70671-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="70671-108">URI parameters</span></span>
 
| <span data-ttu-id="70671-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="70671-109">Parameter</span></span>| <span data-ttu-id="70671-110">型</span><span class="sxs-lookup"><span data-stu-id="70671-110">Type</span></span>| <span data-ttu-id="70671-111">説明</span><span class="sxs-lookup"><span data-stu-id="70671-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="70671-112">xuid</span><span class="sxs-lookup"><span data-stu-id="70671-112">xuid</span></span>| <span data-ttu-id="70671-113">string</span><span class="sxs-lookup"><span data-stu-id="70671-113">string</span></span>| <span data-ttu-id="70671-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="70671-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="70671-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="70671-115">moniker</span></span>| <span data-ttu-id="70671-116">string</span><span class="sxs-lookup"><span data-stu-id="70671-116">string</span></span>| <span data-ttu-id="70671-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="70671-117">String defining the group of users.</span></span> <span data-ttu-id="70671-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="70671-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="70671-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="70671-119">Valid methods</span></span>

[<span data-ttu-id="70671-120">(ユーザー/xuid ({xuid})/groups/{モニカー}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="70671-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="70671-121">&nbsp;&nbsp;グループの presencerecord を要求してを取得します。</span><span class="sxs-lookup"><span data-stu-id="70671-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="70671-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="70671-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="70671-123">Parent</span><span class="sxs-lookup"><span data-stu-id="70671-123">Parent</span></span> 

[<span data-ttu-id="70671-124">プレゼンス Uri</span><span class="sxs-lookup"><span data-stu-id="70671-124">Presence URIs</span></span>](atoc-reference-presence.md)

   