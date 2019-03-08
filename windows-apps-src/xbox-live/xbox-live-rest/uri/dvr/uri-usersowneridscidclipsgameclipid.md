---
title: /users/{ownerId}/scids/{scid}/clips/{gameClipId}
assetID: 49b68418-71f1-c5a2-3a9b-869fd1fa663c
permalink: en-us/docs/xboxlive/rest/uri-usersowneridscidclipsgameclipid.html
description: " /users/{ownerId}/scids/{scid}/clips/{gameClipId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e7ea92e89d54df17e8d82084d840a7ee9ef7d032
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658337"
---
# <a name="usersowneridscidsscidclipsgameclipid"></a><span data-ttu-id="cc8f4-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="cc8f4-104">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>
<span data-ttu-id="cc8f4-105">特定するすべての Id がわかっている場合は、ゲームの 1 つのクリップをシステムからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-105">Access a single game clip from the system if all the IDs to locate it are known.</span></span> <span data-ttu-id="cc8f4-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="cc8f4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc8f4-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cc8f4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc8f4-108">URI parameters</span></span>
 
| <span data-ttu-id="cc8f4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cc8f4-109">Parameter</span></span>| <span data-ttu-id="cc8f4-110">種類</span><span class="sxs-lookup"><span data-stu-id="cc8f4-110">Type</span></span>| <span data-ttu-id="cc8f4-111">説明</span><span class="sxs-lookup"><span data-stu-id="cc8f4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cc8f4-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="cc8f4-112">ownerId</span></span>| <span data-ttu-id="cc8f4-113">string</span><span class="sxs-lookup"><span data-stu-id="cc8f4-113">string</span></span>| <span data-ttu-id="cc8f4-114">リソースがアクセスされているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="cc8f4-115">サポートされている形式:"xuid(123456789)"または"me"。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="cc8f4-116">最大長:16.</span><span class="sxs-lookup"><span data-stu-id="cc8f4-116">Maximum length: 16.</span></span>| 
| <span data-ttu-id="cc8f4-117">scid</span><span class="sxs-lookup"><span data-stu-id="cc8f4-117">scid</span></span>| <span data-ttu-id="cc8f4-118">string</span><span class="sxs-lookup"><span data-stu-id="cc8f4-118">string</span></span>| <span data-ttu-id="cc8f4-119">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-119">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="cc8f4-120">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-120">Must match the SCID of the authenticated user.</span></span>| 
| <span data-ttu-id="cc8f4-121">gameClipId</span><span class="sxs-lookup"><span data-stu-id="cc8f4-121">gameClipId</span></span>| <span data-ttu-id="cc8f4-122">string</span><span class="sxs-lookup"><span data-stu-id="cc8f4-122">string</span></span>| <span data-ttu-id="cc8f4-123">アクセスされているリソースの ID をゲーム クリップだった。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-123">GameClip ID of the resource that is being accessed.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="cc8f4-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cc8f4-124">Valid methods</span></span>

[<span data-ttu-id="cc8f4-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="cc8f4-125">GET (/users/{ownerId}/scids/{scid}/clips/{gameClipId})</span></span>](uri-usersowneridscidclipsgameclipidget.md)

<span data-ttu-id="cc8f4-126">&nbsp;&nbsp;指定することのすべての Id がわかっている場合は、システムからゲームの 1 つのクリップを取得します。</span><span class="sxs-lookup"><span data-stu-id="cc8f4-126">&nbsp;&nbsp;Get a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cc8f4-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="cc8f4-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cc8f4-128">Parent</span><span class="sxs-lookup"><span data-stu-id="cc8f4-128">Parent</span></span> 

[<span data-ttu-id="cc8f4-129">ゲーム録画 Uri</span><span class="sxs-lookup"><span data-stu-id="cc8f4-129">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   