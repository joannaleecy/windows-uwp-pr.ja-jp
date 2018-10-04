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
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4350668"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="5a086-104">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="5a086-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="5a086-105">グループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="5a086-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="5a086-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5a086-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5a086-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5a086-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5a086-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5a086-108">URI parameters</span></span>
 
| <span data-ttu-id="5a086-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5a086-109">Parameter</span></span>| <span data-ttu-id="5a086-110">型</span><span class="sxs-lookup"><span data-stu-id="5a086-110">Type</span></span>| <span data-ttu-id="5a086-111">説明</span><span class="sxs-lookup"><span data-stu-id="5a086-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5a086-112">xuid</span><span class="sxs-lookup"><span data-stu-id="5a086-112">xuid</span></span>| <span data-ttu-id="5a086-113">string</span><span class="sxs-lookup"><span data-stu-id="5a086-113">string</span></span>| <span data-ttu-id="5a086-114">Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="5a086-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="5a086-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="5a086-115">moniker</span></span>| <span data-ttu-id="5a086-116">string</span><span class="sxs-lookup"><span data-stu-id="5a086-116">string</span></span>| <span data-ttu-id="5a086-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="5a086-117">String defining the group of users.</span></span> <span data-ttu-id="5a086-118">現時点では受け入れられるだけモニカーでは、'P' の首都を"People"でです。</span><span class="sxs-lookup"><span data-stu-id="5a086-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5a086-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5a086-119">Valid methods</span></span>

[<span data-ttu-id="5a086-120">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="5a086-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="5a086-121">&nbsp;&nbsp;グループの PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="5a086-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5a086-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="5a086-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5a086-123">Parent</span><span class="sxs-lookup"><span data-stu-id="5a086-123">Parent</span></span> 

[<span data-ttu-id="5a086-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="5a086-124">Presence URIs</span></span>](atoc-reference-presence.md)

   