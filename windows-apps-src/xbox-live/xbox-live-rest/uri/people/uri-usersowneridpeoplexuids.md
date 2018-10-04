---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " /users/{ownerId}/people/xuids"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 715659b8bb001697fc9386be6ec587b3682793c5
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4309709"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="59b15-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="59b15-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="59b15-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="59b15-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="59b15-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="59b15-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="59b15-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="59b15-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="59b15-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="59b15-108">URI parameters</span></span>
 
| <span data-ttu-id="59b15-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="59b15-109">Parameter</span></span>| <span data-ttu-id="59b15-110">型</span><span class="sxs-lookup"><span data-stu-id="59b15-110">Type</span></span>| <span data-ttu-id="59b15-111">説明</span><span class="sxs-lookup"><span data-stu-id="59b15-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="59b15-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="59b15-112">ownerId</span></span>| <span data-ttu-id="59b15-113">string</span><span class="sxs-lookup"><span data-stu-id="59b15-113">string</span></span>| <span data-ttu-id="59b15-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="59b15-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="59b15-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="59b15-115">Must match the authenticated user.</span></span> <span data-ttu-id="59b15-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="59b15-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="59b15-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="59b15-117">Valid methods</span></span>

[<span data-ttu-id="59b15-118">POST</span><span class="sxs-lookup"><span data-stu-id="59b15-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="59b15-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="59b15-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="59b15-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="59b15-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="59b15-121">Parent</span><span class="sxs-lookup"><span data-stu-id="59b15-121">Parent</span></span> 

[<span data-ttu-id="59b15-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="59b15-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   