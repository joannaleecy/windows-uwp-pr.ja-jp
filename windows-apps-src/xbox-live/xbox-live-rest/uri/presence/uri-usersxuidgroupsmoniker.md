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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617557"
---
# <a name="usersxuidxuidgroupsmoniker"></a><span data-ttu-id="3ecb2-104">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="3ecb2-104">/users/xuid({xuid})/groups/{moniker}</span></span>
<span data-ttu-id="3ecb2-105">グループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-105">Accesses the PresenceRecord for a group.</span></span> <span data-ttu-id="3ecb2-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3ecb2-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ecb2-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3ecb2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ecb2-108">URI parameters</span></span>
 
| <span data-ttu-id="3ecb2-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ecb2-109">Parameter</span></span>| <span data-ttu-id="3ecb2-110">種類</span><span class="sxs-lookup"><span data-stu-id="3ecb2-110">Type</span></span>| <span data-ttu-id="3ecb2-111">説明</span><span class="sxs-lookup"><span data-stu-id="3ecb2-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3ecb2-112">xuid</span><span class="sxs-lookup"><span data-stu-id="3ecb2-112">xuid</span></span>| <span data-ttu-id="3ecb2-113">string</span><span class="sxs-lookup"><span data-stu-id="3ecb2-113">string</span></span>| <span data-ttu-id="3ecb2-114">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="3ecb2-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="3ecb2-115">moniker</span></span>| <span data-ttu-id="3ecb2-116">string</span><span class="sxs-lookup"><span data-stu-id="3ecb2-116">string</span></span>| <span data-ttu-id="3ecb2-117">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-117">String defining the group of users.</span></span> <span data-ttu-id="3ecb2-118">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="3ecb2-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="3ecb2-119">Valid methods</span></span>

[<span data-ttu-id="3ecb2-120">GET (/users/xuid({xuid})/groups/{moniker} )</span><span class="sxs-lookup"><span data-stu-id="3ecb2-120">GET (/users/xuid({xuid})/groups/{moniker} )</span></span>](uri-usersxuidgroupsmonikerget.md)

<span data-ttu-id="3ecb2-121">&nbsp;&nbsp;グループの PresenceRecord を取得します。</span><span class="sxs-lookup"><span data-stu-id="3ecb2-121">&nbsp;&nbsp;Gets the PresenceRecord for a group.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="3ecb2-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="3ecb2-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3ecb2-123">Parent</span><span class="sxs-lookup"><span data-stu-id="3ecb2-123">Parent</span></span> 

[<span data-ttu-id="3ecb2-124">プレゼンスの Uri</span><span class="sxs-lookup"><span data-stu-id="3ecb2-124">Presence URIs</span></span>](atoc-reference-presence.md)

   